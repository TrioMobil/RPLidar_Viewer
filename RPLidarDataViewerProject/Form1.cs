using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RPLidarDataViewerProject.Form1;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace RPLidarDataViewerProject
{
    public partial class Form1 : Form
    {
        //RPLidar data structure
        public struct RPLidarData
        {
            public bool StartFlagBit;
            public bool InversedStartFlagBit;
            public uint Quality;
            public bool CheckBit;   //Constantly set to 1.
            public float Angle;
            public float Distance;
        }

        //Buffer variables
        Byte[] rpLidarScanIDResponse = new Byte[] { 0xA5, 0x5A, 0x05, 0x00, 0x00, 0x40, 0x81 };
        Byte[] rpLidarScanIDResponseData = new Byte[7];
        Byte[] spLidarScanRawDataBuf = new Byte[5];

        RPLidarData[] rPLidarData = new RPLidarData[2000];
        int serialPortRPLidarDataIndex = 0;
        List<RPLidarData> rpLidarDatas = new List<RPLidarData>();   //NOTE: Not using now.

        //LidarZone Object
        LidarZone[] zones = new LidarZone[2];

        //Forklift speed.(30112022)
        public enum SpeedStatus
        {
            LowSpeed,
            MidSpeed,
            MaxSpeed,
        }
        SpeedStatus lidarZoneOldState = SpeedStatus.MaxSpeed;
        SpeedStatus lidarZoneCurrentState = SpeedStatus.MaxSpeed;

        //Zone dışına çıkışlarında timeout kullanımı için eklendi.(16012023)
        int zoneOutTimeout_ms = 0;
        int zoneOutTimeoutThreshold_ms = 1000;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Port names of serialport added in to comboBox.
            string[] serialPortListArray = SerialPort.GetPortNames();
            foreach (string serialPort in serialPortListArray)
            {
                comboBoxSeriPortList.Items.Add(serialPort);
            }

            int serialPortCounts = comboBoxSeriPortList.Items.Count;
            if (serialPortCounts > 0) comboBoxSeriPortList.SelectedIndex = 0;
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            //Slected the file address
            string fileAddress;
            openFileDialog1.ShowDialog(this);
            fileAddress = @"" + openFileDialog1.FileName;   //Okunacak dosya path'i adrese ceviriliyor.
            if (fileAddress == "") return;   //Bos dosya adresi gelir ise fonksiyondan cıkacak.

            //Read file from file address.
            string fileText;
            StreamReader sr = new StreamReader(fileAddress);
            fileText = sr.ReadToEnd();
            sr.Close();
            textBoxOpenFile.Text = fileText;    //Okunan dosya icerigi gosteriliyor.

            //File to Raw Lidar Data Convert
            List<byte[]> lidarRawDatas = new List<byte[]>();    //5 byte'lık lidar raw data dizisi.
            lidarRawDatas = readRecieveLidarDataFromFile(fileText); //Okunan text 

            //Lidar Raw Data To Lidar Data Convert
            Array.Clear(rPLidarData, 0, rPLidarData.Length);//NOTE: veriler üst üste yazılmasın diye dizi temizleniyor.
            for (int index = 0; index < lidarRawDatas.Count; index++)
            {
                rPLidarData[index] = createRPlidarDataFromRawData(lidarRawDatas[index]);
            }

            //Asağısı düzeltilecek.(15112022)
            //Kullanılacak list box icerigi her dosya acmada temizleniyor.
            listBoxRPLidarData.Items.Clear();
            listBoxRPLidarStartBits.Items.Clear();
            listBoxRPLidarDataQuality.Items.Clear();

            //Lidar data viewer.
            float distanceThreshod = (float)Convert.ToUInt32(textBoxViewLidarDistance.Text);
            float qualityThreshold = (float)Convert.ToUInt32(textBoxDataQualityThreshold.Text);

            //Lidar data viewer Mid ve Low degerleri.
            float LowDistanceThreshod = (float)Convert.ToUInt32(textBoxLidarLowDistance.Text);
            float MidDistanceThreshod = (float)Convert.ToUInt32(textBoxLidarMidDistance.Text);

            //Lidar Zone 'Width' , 'Height' ve offset  degerleri.
            float lidarZoneHeight = (float)Convert.ToUInt32(numericUpDownLidarZoneHeight.Value);
            float lidarZoneHeightOffset = (float)Convert.ToInt32(numericUpDownLidarZoneHeightOffset.Value);
            float lidarZoneWidth = (float)Convert.ToUInt32(numericUpDownLidarZoneWidth.Value);
            float lidarZoneWidthOffset = (float)Convert.ToInt32(numericUpDownLidarZoneWidthOffset.Value);

            float zoneCenterX = lidarZoneWidth / 2;
            float zoneCenterY = lidarZoneHeight / 2;

            int lidarZoneMin_X = (int)(lidarZoneWidthOffset - (zoneCenterX));
            int lidarZoneMax_X = (int)(lidarZoneWidthOffset + (zoneCenterX));
            int lidarZoneMin_Y = (int)(lidarZoneHeightOffset * (-1) - (zoneCenterY));
            int lidarZoneMax_Y = (int)(lidarZoneHeightOffset * (-1) + (zoneCenterY));

            //Lidar zone çizdiriliyor.
            //NOTE: İlk zone çizdirme işlemi yapılıyordu.(28112022 tarihinde silindi.)

            //RPLidar datası istenen bir text formatına çevrildi.
            for (int i = 0; i < rPLidarData.Length; i++)
            {
                //string tempText =$"{(i + 1).ToString()} )\t";
                //tempText +=$"Start Bit:\t{(tempStartBit.ToString())}";
                //tempText +=$"\tQuality:\t{(tempQuality.ToString("00"))}";
                //tempText +=$"\tAngle:\t{(tempAngle.ToString("0.0"))}";
                //tempText +=$"\tDistance:\t{(tempDistance.ToString("0.0"))}mm";

                //listBoxRPLidarData.Items.Add(tempText);
                //lidarDataCount++;

                //Start Bitleri filtrelendi.
                //if (Convert.ToBoolean(tempStartBit & 0x01))
                //{
                //    listBoxRPLidarStartBits.Items.Add(tempText);
                //    lidarStartBitCount++;
                //}

                //Data Quality filtrelendi.
                //lidarDataQualityThreshold = Convert.ToUInt32(textBoxDataQualityThreshold.Text);
                //if (tempQuality >= lidarDataQualityThreshold)
                //{
                //    listBoxRPLidarDataQuality.Items.Add(tempText);
                //    lidarDataQualityCount++;
                //}

                //Lidar datası zone alanı için kontrol ediliyor.
                //bool detectionZoneFlag = false;
                //detectionZoneFlag = checkTheLidarDetectionZone((float)tempAngle, (float)tempDistance, lidarZoneMin_X, lidarZoneMax_X, lidarZoneMin_Y, lidarZoneMax_Y);

                /*//lidar datası grafiğe çizdiriliyor.
                if ( (tempDistance <= distanceThreshod) && (tempQuality >= qualityThreshold) )
                {
                    //Draving lidar data 'x' and 'y' coordinate.
                    if (tempDistance <= LowDistanceThreshod && detectionZoneFlag == true)
                    {
                        bmp = createLidarDataGraph(new Pen(Brushes.Red, 3), (float)tempAngle, (float)tempDistance, bmp, 150, 6000);
                    }
                    else if(tempDistance > LowDistanceThreshod && tempDistance <= MidDistanceThreshod && detectionZoneFlag == true)
                    {
                        bmp = createLidarDataGraph(new Pen(Brushes.Yellow, 3), (float)tempAngle, (float)tempDistance, bmp, 150, 6000);
                    }
                    else
                    {
                        bmp = createLidarDataGraph(new Pen(Brushes.Green, 3), (float)tempAngle, (float)tempDistance, bmp, 150, 6000);
                    }

                    //pictureBoxRPLidarDataViewer.BackColor = Color.Black;//NOTE: picture box default olarak background ayarı yapıdı.
                    pictureBoxRPLidarDataViewer.Image = bmp;
                }*/
            }

            //Invalidate();//NOTE: Kaldırılsada veri güncelleniyor neden.

            //list box icin elde edilen count degerleri label uzerine yazdiriliyor.
            /*labelLidarData.Text = $"Lidar Data: {lidarDataCount}";
            labelLİdarDataStartBits.Text = $"Lidar Data Start Bits: {lidarStartBitCount}";
            labelLidarDataQuality.Text = $"Selected Data Quality List: {lidarDataQualityCount}";*/
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!checkResponseData(rpLidarScanIDResponse, rpLidarScanIDResponseData))
            {
                //lidar Response Descriptor reading.
                serialPort1.Read(rpLidarScanIDResponseData, 0, 7);
            }
            else if (checkResponseData(rpLidarScanIDResponse, rpLidarScanIDResponseData) && serialPortRPLidarDataIndex < rPLidarData.Length)
            {
                //Lidar Response Data reading.
                if (serialPort1.BytesToRead < 5) return;

                int serialPortBytesToRead = serialPort1.BytesToRead;
                int bufferSize = (serialPortBytesToRead - (serialPortBytesToRead % 5));
                int reminderLidarDataBufferSize = (rPLidarData.Length - serialPortRPLidarDataIndex) * 5;

                if (bufferSize > reminderLidarDataBufferSize) bufferSize = reminderLidarDataBufferSize;
                byte[] buffer = new byte[bufferSize];

                serialPort1.Read(buffer, 0, buffer.Length);

                for (int bufferOffset = 0; bufferOffset < buffer.Length; bufferOffset += 5)
                {
                    Buffer.BlockCopy(buffer, bufferOffset, spLidarScanRawDataBuf, 0, 5);

                    RPLidarData tempOneSampleOfRPLidarData = createRPlidarDataFromRawData(spLidarScanRawDataBuf); //(30112022)

                    rPLidarData[serialPortRPLidarDataIndex] = tempOneSampleOfRPLidarData;
                    //textBoxSeriPortDataReceive.Invoke(new showTextSerialPortData(writeToTextBox), rPLidarData[serialPortRPLidarDataIndex]);

                    if (rPLidarData[serialPortRPLidarDataIndex].StartFlagBit == true)
                    {
                        pictureBoxRPLidarDataViewer.Invalidate();
                    }
                    else
                    {
                        serialPortRPLidarDataIndex++;
                    }
                }
            }
        }

        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show($"Serial Port Error.\n{e.EventType}", "Error", MessageBoxButtons.OK);
        }

        private void buttonSeriPortCon_MouseClick(object sender, MouseEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //Open File button enable.
                buttonOpenFile.Enabled = true;

                //Combo box enable.
                comboBoxSeriPortList.Enabled = true;

                try
                {
                    serialPort1.Close();
                    buttonSeriPortCon.Text = "Serial Port Connect";

                    labelSerialPortInfo.Text = "Serial Port Info:";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Serial Port Not Closed.\n{ex.Message}", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                //Open File button enable.
                buttonOpenFile.Enabled = false;

                //Combo box disable.
                comboBoxSeriPortList.Enabled = false;

                //Serial Port Parameters setting.
                serialPort1.PortName = comboBoxSeriPortList.Text;

                //Open serial port
                try
                {
                    serialPort1.Open();
                    buttonSeriPortCon.Text = "Serial Port Discon.";

                    string[] serialPortİnfo = new string[5];
                    serialPortİnfo[0] = serialPort1.PortName;
                    serialPortİnfo[1] = serialPort1.BaudRate.ToString();
                    serialPortİnfo[2] = serialPort1.Parity.ToString();
                    serialPortİnfo[3] = serialPort1.StopBits.ToString();
                    serialPortİnfo[4] = serialPort1.DataBits.ToString();

                    labelSerialPortInfo.Text = "Serial Port Info:";

                    foreach (var info in serialPortİnfo)
                    {
                        labelSerialPortInfo.Text += "  " + info;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Serial Port Not Opened.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRPLidarScanID_Click(object sender, EventArgs e)
        {
            Array.Clear(rpLidarScanIDResponseData, 0, rpLidarScanIDResponseData.Length);
            if (serialPort1.IsOpen) serialPort1.DiscardInBuffer();

            //SCAN Request sending.
            if (serialPort1.IsOpen) serialPort1.Write(new byte[] { 0xA5, 0x20 }, 0, 2);
        }

        private void buttonRPLidarStopID_Click(object sender, EventArgs e)
        {
            //STOP Request sending.
            if (serialPort1.IsOpen) serialPort1.Write(new byte[] { 0xA5, 0x25 }, 0, 2);

            Array.Clear(rpLidarScanIDResponseData, 0, rpLidarScanIDResponseData.Length);
            if (serialPort1.IsOpen) serialPort1.DiscardInBuffer();
        }

        private void pictureBoxRPLidarDataViewer_Paint(object sender, PaintEventArgs e)
        {
            Graphics pictureBoxGraphics = e.Graphics;

            //LidarZone data reading and zone creating.
            Size zoneSize = new Size((int)Convert.ToUInt32(numericUpDownLidarZoneWidth.Value), (int)Convert.ToUInt32(numericUpDownLidarZoneHeight.Value));
            Size zoneSizeOffset = new Size((int)Convert.ToInt32(numericUpDownLidarZoneWidthOffset.Value), (int)Convert.ToInt32(numericUpDownLidarZoneHeightOffset.Value));
            zones[0] = new LidarZone(LidarZone.ZoneDistanceTypes.Low, zoneSize, zoneSizeOffset);

            Size zoneSize_2 = new Size((int)Convert.ToUInt32(numericUpDownLidarZoneWidth_2.Value), (int)Convert.ToUInt32(numericUpDownLidarZoneHeight_2.Value));
            Size zoneSizeOffset_2 = new Size((int)Convert.ToInt32(numericUpDownLidarZoneWidthOffset_2.Value), (int)Convert.ToInt32(numericUpDownLidarZoneHeightOffset_2.Value));
            zones[1] = new LidarZone(LidarZone.ZoneDistanceTypes.Mid, zoneSize_2, zoneSizeOffset_2);

            //lidar sample data drawing
            if (rPLidarData != null)
            {
                //pictureBoxGraphics = drawLidarData(rPLidarData, pictureBoxGraphics, pictureBoxRPLidarDataViewer);//Without zone.
                //pictureBoxGraphics = drawLidarData(rPLidarData, pictureBoxGraphics, pictureBoxRPLidarDataViewer, zone);
                pictureBoxGraphics = drawLidarData(rPLidarData, pictureBoxGraphics, pictureBoxRPLidarDataViewer, zones);
            }

            serialPortRPLidarDataIndex = 0;

            //Clear RPLidardatas
            Array.Clear(rPLidarData, 0, rPLidarData.Length);//(30112022)

            //Lidar zone drawing.
            //pictureBoxGraphics = zone.drawLidarZone(pictureBoxGraphics);//Unscaled zone.
            //pictureBoxGraphics = zone.drawLidarZone(pictureBoxGraphics, calculateScaleRation(0.0f, 12000.0f, 0.0f, (float)pictureBoxRPLidarDataViewer.Width));

            //Mid Lidar zones drawing.
            for (int midZoneIndex = 0; midZoneIndex < zones.Length; midZoneIndex++)
            {
                if (zones[midZoneIndex].DistanceType == LidarZone.ZoneDistanceTypes.Mid)
                {
                    pictureBoxGraphics = zones[midZoneIndex].drawLidarZone(pictureBoxGraphics, calculateScaleRation(0.0f, 12000.0f, 0.0f, (float)pictureBoxRPLidarDataViewer.Width));
                }
            }
            //Low Lidar zones drawing.
            for (int lowZoneIndex = 0; lowZoneIndex < zones.Length; lowZoneIndex++)
            {
                if (zones[lowZoneIndex].DistanceType == LidarZone.ZoneDistanceTypes.Low)
                {
                    pictureBoxGraphics = zones[lowZoneIndex].drawLidarZone(pictureBoxGraphics, calculateScaleRation(0.0f, 12000.0f, 0.0f, (float)pictureBoxRPLidarDataViewer.Width));
                }
            }

            //Speed status check.(30112022)
            if (zones[0].SampleDetected == true)//Low type zone
            {
                //Timeout counter Stop edilip sıfırlanıyor. Aynı zamanda Mid->Low veya Max->Low geçişlerinde timer çalıştı ise sayılmış değeri siliyor.(17012023)
                if (timer1.Enabled == true)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    zoneOutTimeout_ms = 0;
                }

                lidarZoneCurrentState = SpeedStatus.LowSpeed;
                lidarZoneOldState = lidarZoneCurrentState;

                panelSpeedStatus.BackColor = Color.Red;
            }
            else if (zones[1].SampleDetected == true)//Mid type zone
            {
                if (lidarZoneOldState == SpeedStatus.LowSpeed)
                {
                    if (timer1.Enabled == false)
                    {
                        timer1.Start();
                        timer1.Enabled = true;
                    }
                    else if (zoneOutTimeout_ms > zoneOutTimeoutThreshold_ms)
                    {
                        timer1.Stop();//Mid -> Low geçişlerinde Hız Max durumda iken bir defa timeout çalışması için sadece timer durdurudu.(17012023)

                        lidarZoneCurrentState = SpeedStatus.MaxSpeed;

                        panelSpeedStatus.BackColor = Color.Green;
                    }
                }
                else
                {
                    //Timeout counter Stop edilip sıfırlanıyor. Aynı zamanda Max->Mid geçişlerinde timer çalıştı ise sayılmış değeri siliyor.(17012023)
                    if (timer1.Enabled == true)
                    {
                        timer1.Stop();
                        timer1.Enabled = false;
                        zoneOutTimeout_ms = 0;
                    }

                    lidarZoneCurrentState = SpeedStatus.MidSpeed;
                    lidarZoneOldState = lidarZoneCurrentState;

                    panelSpeedStatus.BackColor = Color.Yellow;
                }
            }
            else
            {
                //Mid Zone alanından çıkış yaptığında ve tekrar Mid alanına girdiğinde Mid hizına dönmesi için belirli bir timeout kullanılacak (16012023)
                if (lidarZoneOldState == SpeedStatus.LowSpeed || lidarZoneOldState == SpeedStatus.MidSpeed)
                {
                    if(timer1.Enabled == false)
                    {
                        timer1.Start();
                        timer1.Enabled = true;
                    }
                    else if (zoneOutTimeout_ms > zoneOutTimeoutThreshold_ms)
                    {
                        timer1.Stop();
                        timer1.Enabled = false;
                        zoneOutTimeout_ms = 0;

                        lidarZoneCurrentState = SpeedStatus.MaxSpeed;
                        lidarZoneOldState = lidarZoneCurrentState;

                        panelSpeedStatus.BackColor = Color.Green;
                    }
                }
                else
                {
                    lidarZoneCurrentState = SpeedStatus.MaxSpeed;
                    lidarZoneOldState = lidarZoneCurrentState;

                    panelSpeedStatus.BackColor = Color.Green;
                }

            }

            ////Clear detected sample count
            //for (int zoneIndex = 0; zoneIndex<zones.Length; zoneIndex++)
            //{
            //    zones[zoneIndex].clearDetectedSampleCount();
            //}
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            zoneOutTimeout_ms += timer1.Interval;
        }


        //Dosyadan okunan işlemi için raw data okuma ve raw datadan anlamla dataya çevirme işlemleri.
        public List<byte[]> readRecieveLidarDataFromFile(string fileText)
        {
            Byte[] bytes = new Byte[4];//Genişletilebilir olmalı.
            string[] textArray;

            textArray = fileText.Split('\n');  //Satır satır split edildi.

            //Okunan hex dosyasının hex kısmı alınıyor.
            for (uint i = 0; i < textArray.Length; i++)
            {
                string arrayHeader = " - ";
                int startIndexNumOfString = textArray[i].IndexOf(arrayHeader);

                if (startIndexNumOfString != -1)
                {
                    textArray[i] = textArray[i].Remove(textArray[i].Length - 1, 1);   //Satır sonu \r karakterleri kaldırıldı.
                    textArray[i] = textArray[i].Substring((startIndexNumOfString + arrayHeader.Length));  //Satır içerisinde hex datasını bulunduğu bölüm alındı.

                    string[] tempArray = textArray[i].Split(' ');  //Starır içerisinde yer alan boşluk karakterleri kaldırıldı.
                    textArray[i] = textArray[i].Remove(0, textArray[i].Length); //textArray araması yeniden yapılabilmesi için her indeksi silinmiş oldu.

                    foreach (string tempArrayString in tempArray)
                    {
                        textArray[i] += tempArrayString;   //Birteştirilmiş hex kodu her text array indeksi için atanıyor.
                    }
                }
            }

            int hexDataIndex = 2;
            List<byte[]> tempLidarRawDatas = new List<byte[]>();

            //RPlidar datası veri yapısı içerisine eklendi.
            for (int index = 0; index < (textArray[hexDataIndex].Length / 10); index++)
            {
                int startIndex, indexLength;
                startIndex = (index * 10);
                indexLength = 2;
                byte[] LidarDataFrame = new byte[5];

                string tempQuality = "0x" + textArray[hexDataIndex].Substring(startIndex, indexLength);

                //Angle degerinin bulunduğu 2 baytlık hex kodu capraz alındı.
                string tempAngle_L = "0x" + textArray[hexDataIndex].Substring(startIndex + 4, indexLength);
                string tempAngle_H = "0x" + textArray[hexDataIndex].Substring(startIndex + 2, indexLength);

                //Distance degerinin bulunduğu 2 baytlık hex kodu capraz alındı.
                string tempDistance_L = "0x" + textArray[hexDataIndex].Substring(startIndex + 8, indexLength);
                string tempDistance_H = "0x" + textArray[hexDataIndex].Substring(startIndex + 6, indexLength);

                LidarDataFrame[0] = Convert.ToByte(tempQuality, 16);
                LidarDataFrame[1] = Convert.ToByte(tempAngle_H, 16);
                LidarDataFrame[2] = Convert.ToByte(tempAngle_L, 16);
                LidarDataFrame[3] = Convert.ToByte(tempDistance_H, 16);
                LidarDataFrame[4] = Convert.ToByte(tempDistance_L, 16);

                tempLidarRawDatas.Add(LidarDataFrame);
            }

            return tempLidarRawDatas;
        }
        
        //lidar data creater.
        public RPLidarData createRPlidarDataFromRawData(Byte[] bytesOfRawLidarDataFrame)
        {
            RPLidarData tempRPLidarData = new RPLidarData();

            bool tempStartFlagBit = false;
            bool tempInvertedStartFlagBit = false;
            byte tempQuality = 0;
            bool tempCheckBit = false;
            double tempAngle = 0;
            double tempDistance = 0;

            //Temp Star Flag Bit, Inverted Start Flag Bit and Quality Value convert.
            tempStartFlagBit = Convert.ToBoolean(((byte)bytesOfRawLidarDataFrame[0]) & ((byte)0x01));
            tempInvertedStartFlagBit = Convert.ToBoolean(((byte)bytesOfRawLidarDataFrame[0] >> 1) & ((byte)0x01));
            tempQuality = (byte)(bytesOfRawLidarDataFrame[0] >> 2);

            //Temp Check Bit and Angle Value convert.
            tempCheckBit = Convert.ToBoolean(((byte)bytesOfRawLidarDataFrame[1]) & ((byte)0x01));
            tempAngle = (((ushort)(bytesOfRawLidarDataFrame[2] << 8)) + ((ushort)bytesOfRawLidarDataFrame[1])) >> 1;
            tempAngle = tempAngle / 64.0f;

            //Temp Distance convert.
            tempDistance = ((ushort)(bytesOfRawLidarDataFrame[4] << 8)) + ((ushort)bytesOfRawLidarDataFrame[3]);
            tempDistance = tempDistance / 4.0f;

            //Temp RPLidar Data type assignment.
            tempRPLidarData.StartFlagBit = tempStartFlagBit;
            tempRPLidarData.InversedStartFlagBit = tempInvertedStartFlagBit;
            tempRPLidarData.Quality = (uint)tempQuality;
            tempRPLidarData.CheckBit = tempCheckBit;
            tempRPLidarData.Angle = (float)tempAngle;
            tempRPLidarData.Distance = (float)tempDistance;

            return tempRPLidarData;
        }

        //SCAN ID responsu kontrol ediliyor.
        public bool checkResponseData(Byte[] firstBytes, Byte[] secondBytes)
        {
            return firstBytes.SequenceEqual(secondBytes);
        }

        //Lidar Data Kontrol ediliyor.
        public bool checkLidarData(RPLidarData oneSampleOfRPLidarData)  //(30112022)
        {
            bool checkFlag = false;

            int lidarMinDistanceThreshold_mm = 75;

            if (oneSampleOfRPLidarData.Quality >= 15 && oneSampleOfRPLidarData.Distance > lidarMinDistanceThreshold_mm) checkFlag = true;
            else checkFlag = false;

            return checkFlag;
        }


        //Polar to Cartesian converter functions.
        public (int x, int y) convertPolarToCartesian(float angle, float distance, int coordinateOriginX, int coordinateOriginY)
        {
            //Convert lidar angle to polar angle
            float degree360 = 360;
            float degree270 = 270;
            float degree180 = 180;
            float degree90 = 90;
            float newAngle = 0;

            if (angle > 0 && angle <= 90)
            {
                newAngle = (degree90 - angle);  //1. Bölge
            }
            else if (angle > 90 && angle <= 180)
            {
                newAngle = (degree180 - angle) + degree270; //4. Bölge
            }
            else if (angle > 180 && angle <= 270)
            {
                newAngle = (degree270 - angle) + degree180; //3. Bölge
            }
            else if (angle > 270 && angle <= 360)
            {
                newAngle = (degree360 - angle) + degree90; //2. Bölge
            }

            int x, y;
            double radian = Math.PI * newAngle / 180.0;

            x = (int)(distance * Math.Cos(radian));
            y = (int)(distance * Math.Sin(radian));

            x = coordinateOriginX + x;  //NOTE: Eklendi fakat kontrol edilmedi. Orjin değiştirmek için.!! (Kesindeğil)
            y = coordinateOriginY + y;  //NOTE: Eklendi fakat kontrol edilmedi. Orjin değiştirmek için.!! (Kesindeğil)

            return (x, y);
        }
        public (int x, int y) convertPolarToCartesian(float angle, float distance)
        {
            //Convert lidar angle to polar angle
            float degree360 = 360;
            float degree270 = 270;
            float degree180 = 180;
            float degree90 = 90;
            float newAngle = 0;

            if(angle > 0 && angle <= 90)
            {
                newAngle = (degree90 - angle);  //1. Bölge
            }
            else if(angle > 90 && angle <= 180)
            {
                newAngle = (degree180 - angle) + degree270; //4. Bölge
            }
            else if(angle > 180 && angle <= 270)
            {
                newAngle = (degree270 - angle) + degree180; //3. Bölge
            }
            else if(angle > 270 && angle <= 360)
            {
                newAngle = (degree360 - angle) + degree90; //2. Bölge
            }

            int x, y;
            double radian = Math.PI * newAngle / 180.0;

            x = (int)(distance * Math.Cos(radian));
            y = (int)(distance * Math.Sin(radian));

            return (x, y);
        }


        //Scale functions.
        public float scale(float value, float minValue, float maxValue, float minScaledValued, float maxScaledValue)
        {
            float scaleRation;
            scaleRation = (float)(maxScaledValue - minScaledValued) / (float)(maxValue - minValue);
            value = scaleRation * value;

            return value;
        }
        public float calculateScaleRation(float minValue, float maxValue, float minScaledValued, float maxScaledValue)
        {
            float scaleRation;
            scaleRation = (float)(maxScaledValue - minScaledValued) / (float)(maxValue - minValue);

            return scaleRation;
        }


        //Draw lidar background function.
        public Graphics drawLidarViwerBackground(Graphics graphicsObject, PictureBox pictureBoxObject)
        {
            int pictureBoxSizeWidth = pictureBoxObject.Size.Width;
            int pictureBoxSizeHeight = pictureBoxObject.Size.Height;

            int centerX = pictureBoxSizeWidth / 2;
            int centerY = pictureBoxSizeHeight / 2;

            Pen p = new Pen(Brushes.DarkGreen, 1);

            graphicsObject.TranslateTransform(centerX, centerY);

            //Draw Ellipse
            p.DashPattern = new float[3] { 1, 5, 5 };
            //p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

            uint ellipseCount = 6;
            uint ellipseMaxSize = (uint)((pictureBoxSizeWidth < pictureBoxSizeHeight) ? pictureBoxSizeWidth : pictureBoxSizeHeight);

            for (uint i = 1; i < ellipseCount + 1; i++)
            {
                uint ellipseSize = (ellipseMaxSize / ellipseCount) * i;
                int ellipseCenter = (int)(ellipseSize / 2) * (-1);

                graphicsObject.DrawEllipse(p, ellipseCenter, ellipseCenter, ellipseSize, ellipseSize);
            }

            //Draw Perpendicular Line
            //p.DashPattern = new float[3] { 1, 3, 3 };
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            int rotationAngle = 30;
            Font drawStringFont = new Font(new FontFamily("Arial"), 10);

            for (int i = 0; i < (360 / rotationAngle); i += 1)
            {
                graphicsObject.DrawLine(p, new Point(0, 0), new Point(0, -centerY));
                graphicsObject.DrawString($"{rotationAngle * i}", drawStringFont, Brushes.Green, new Point(0, -centerY));
                graphicsObject.RotateTransform(rotationAngle);
            }

            return (graphicsObject);
        }


        //Lidar sample data drawer functions.
        Graphics drawLidarDataSample(Graphics graphicsObject, PictureBox pictureBoxObject, Pen pen, float angleDataOfLidar, float distaceInAngleDataOflidar_mm, uint minLidarDistance_mm, uint maxLidarDistance_mm)
        {
            int pictureBoxSizeWidth = pictureBoxObject.Size.Width;
            int pictureBoxSizeHeight = pictureBoxObject.Size.Height;

            int centerX = pictureBoxSizeWidth / 2;
            int centerY = pictureBoxSizeHeight / 2;

            //lidar sample scale.
            int scaledLidarDataSample_X, scaledLidarDataSample_Y;
            float scaledLidarDistance_mm = distaceInAngleDataOflidar_mm * calculateScaleRation(minLidarDistance_mm, maxLidarDistance_mm, 0, centerX);
            var scaledCoordinate = convertPolarToCartesian(angleDataOfLidar, scaledLidarDistance_mm);
            scaledLidarDataSample_X = scaledCoordinate.x;
            scaledLidarDataSample_Y = (-1) * scaledCoordinate.y;//Scaled y axis value converted to graphic y axis value.

            graphicsObject.FillEllipse(pen.Brush, scaledLidarDataSample_X - 1, scaledLidarDataSample_Y - 1, 3, 3);

            return (graphicsObject);
        }
        Graphics drawLidarDataSample(Graphics graphicsObject, PictureBox pictureBoxObject, Pen pen, float angleDataOfLidar, float distaceInAngleDataOflidar_mm, uint minLidarDistance_mm, uint maxLidarDistance_mm, LidarZone lidarZone)
        {
            int pictureBoxSizeWidth = pictureBoxObject.Size.Width;
            int pictureBoxSizeHeight = pictureBoxObject.Size.Height;

            int centerX = pictureBoxSizeWidth / 2;
            int centerY = pictureBoxSizeHeight / 2;

            //Lidar sample in zone check.
            var coordinate = convertPolarToCartesian(angleDataOfLidar, distaceInAngleDataOflidar_mm);
            if (lidarZone.checkInTheZone((float)coordinate.x, (float)(coordinate.y)) == true)
            {
                if (lidarZone.DistanceType == LidarZone.ZoneDistanceTypes.Mid) pen.Brush = Brushes.Yellow;
                if (lidarZone.DistanceType == LidarZone.ZoneDistanceTypes.Low) pen.Brush = Brushes.Red; //(30112022)
            }
            else
            {
                pen.Brush = Brushes.Purple;
            }

            //lidar sample scale.
            int scaledLidarDataSample_X, scaledLidarDataSample_Y;
            float scaledLidarDistance_mm = distaceInAngleDataOflidar_mm * calculateScaleRation(minLidarDistance_mm, maxLidarDistance_mm, 0, centerX);
            var scaledCoordinate = convertPolarToCartesian(angleDataOfLidar, scaledLidarDistance_mm);
            scaledLidarDataSample_X = scaledCoordinate.x;
            scaledLidarDataSample_Y = (-1) * scaledCoordinate.y;//Scaled y axis value converted to graphic y axis value.

            graphicsObject.FillEllipse(pen.Brush,scaledLidarDataSample_X - 1, scaledLidarDataSample_Y - 1, 3, 3);

            return (graphicsObject);
        }
        //Graphics drawLidarDataSample(Graphics graphicsObject, PictureBox pictureBoxObject, Pen pen, float angleDataOfLidar, float distaceInAngleDataOflidar_mm, uint minLidarDistance_mm, uint maxLidarDistance_mm, LidarZone[] lidarZones)
        //{
        //    int pictureBoxSizeWidth = pictureBoxObject.Size.Width;
        //    int pictureBoxSizeHeight = pictureBoxObject.Size.Height;

        //    int centerX = pictureBoxSizeWidth / 2;
        //    int centerY = pictureBoxSizeHeight / 2;

        //    //Lidar sample in zone check.
        //    var coordinate = convertPolarToCartesian(angleDataOfLidar, distaceInAngleDataOflidar_mm);
        //    if (lidarZones[0].checkInTheZone((float)coordinate.x, (float)(coordinate.y)) == true)
        //    {
        //        pen.Brush = Brushes.Red;
        //    }
        //    else if (lidarZones[1].checkInTheZone((float)coordinate.x, (float)(coordinate.y)) == true)
        //    {
        //        pen.Brush = Brushes.Yellow;
        //    }
        //    else
        //    {
        //        pen.Brush = Brushes.Purple;
        //    }

        //    //lidar sample scale.
        //    int scaledLidarDataSample_X, scaledLidarDataSample_Y;
        //    float scaledLidarDistance_mm = distaceInAngleDataOflidar_mm * calculateScaleRation(minLidarDistance_mm, maxLidarDistance_mm, 0, centerX);
        //    var scaledCoordinate = convertPolarToCartesian(angleDataOfLidar, scaledLidarDistance_mm);
        //    scaledLidarDataSample_X = scaledCoordinate.x;
        //    scaledLidarDataSample_Y = (-1) * scaledCoordinate.y;//Scaled y axis value converted to graphic y axis value.

        //    graphicsObject.FillEllipse(pen.Brush, scaledLidarDataSample_X - 1, scaledLidarDataSample_Y - 1, 3, 3);

        //    return (graphicsObject);
        //}


        //Lidar Data drawer functions.
        
        public Graphics drawLidarData(RPLidarData[] lidarData, Graphics graphicsObject, PictureBox pictureBoxObject)
        {
            //Lidar viewer backgroung create
            graphicsObject = drawLidarViwerBackground(graphicsObject, pictureBoxObject);

            //Lidar data draw
            for (int i = 0; i < lidarData.Length; i++)
            {
                graphicsObject = drawLidarDataSample(graphicsObject, pictureBoxObject, new Pen(Brushes.Purple, 3), lidarData[i].Angle, lidarData[i].Distance, 150, 6000);
            }

            return (graphicsObject);
        }
        public Graphics drawLidarData(RPLidarData[] lidarData, Graphics graphicsObject, PictureBox pictureBoxObject, LidarZone lidarZone)
        {
            //Lidar viewer backgroung create
            graphicsObject = drawLidarViwerBackground(graphicsObject, pictureBoxObject);

            //Lidar data draw
            Pen lidarSampleDrawPen = new Pen(Brushes.Purple, 3);
            for (int i = 0; i < lidarData.Length; i++)
            {
                graphicsObject = drawLidarDataSample(graphicsObject, pictureBoxObject, lidarSampleDrawPen, lidarData[i].Angle, lidarData[i].Distance, 150, 6000, lidarZone);
            }

            return (graphicsObject);
        }
        public Graphics drawLidarData(RPLidarData[] lidarData, Graphics graphicsObject, PictureBox pictureBoxObject, LidarZone[] lidarZones)
        {
            //Lidar viewer backgroung create
            graphicsObject = drawLidarViwerBackground(graphicsObject, pictureBoxObject);

            //Lidar data draw
            Pen lidarSampleDrawPen = new Pen(Brushes.Purple, 3);
            for (int i = 0; i < lidarData.Length; i++)
            {
                //Buraya lidar data kontrıolü ekle continuo kullan.!!!!(30112022) Data okumaya ekleyemez isen buraya ekle.buraya şart olarak ekle.
                if (checkLidarData(lidarData[i]) == false) continue;

                //Default color assignment for each lidar sample.
                lidarSampleDrawPen.Brush = Brushes.Purple;

                //Lidar sample in Mid zones check.
                var coordinate = convertPolarToCartesian(lidarData[i].Angle, lidarData[i].Distance);
                for (int MidzonesIndex = 0; MidzonesIndex < lidarZones.Length; MidzonesIndex++)
                {
                    if (lidarZones[MidzonesIndex].checkInTheZone((float)coordinate.x, (float)(coordinate.y)) == true)
                    {
                        if (lidarZones[MidzonesIndex].DistanceType == LidarZone.ZoneDistanceTypes.Mid)
                        {
                            lidarSampleDrawPen.Brush = Brushes.Yellow;
                        }
                    }
                }

                //Lidar sample in Low zones check.
                for (int LowZonesIndex = 0; LowZonesIndex < lidarZones.Length; LowZonesIndex++)
                {
                    if (lidarZones[LowZonesIndex].checkInTheZone((float)coordinate.x, (float)(coordinate.y)) == true)
                    {
                        if (lidarZones[LowZonesIndex].DistanceType == LidarZone.ZoneDistanceTypes.Low)
                        {
                            lidarSampleDrawPen.Brush = Brushes.Red;
                        }
                    }
                }

                graphicsObject = drawLidarDataSample(graphicsObject, pictureBoxObject, lidarSampleDrawPen, lidarData[i].Angle, lidarData[i].Distance, 150, 6000);
            }

            return (graphicsObject);
        }


        //Tread cakısması hatasının giderilmesi icin kullanılmıstır.
        public delegate void showTextSerialPortData(RPLidarData data);
        public void writeToTextBox(RPLidarData data)
        {
            //NOTE: veri yapısı reel değerlerine çevirildiği için buradaki veri çevrimine ihtiyaç kalmamıştır.
            uint tempQuality = (uint)data.Quality;
            float tempAngle = (float)((double)data.Angle / 64.0);
            float tempDistance = (float)((double)data.Distance / 4.0);

            textBoxSeriPortDataReceive.Text += "Quality:" + tempQuality + "\t";
            textBoxSeriPortDataReceive.Text += "Angle:" + tempAngle + "\t";
            textBoxSeriPortDataReceive.Text += "Distance:" + tempDistance + "\t";
            textBoxSeriPortDataReceive.Text += "\r\n";
        }


        //Zone Class Definition
        public class LidarZone
        {
            public enum ZoneDistanceTypes
            {
                Low,
                Mid,
            }

            private ZoneDistanceTypes distanceType;
            private Size size;
            private Size offsetSize;
            private Point positionOfStarting;
            private Point positionOfStartingForGraphic;
            private Point positionOfCornerMin;
            private Point positionOfCornerMax;
            private bool sampleDetected;
            private uint detectedSampleCount;

            public ZoneDistanceTypes DistanceType
            {
                get{return this.distanceType;}
                set{this.distanceType = value;}
            }
            public Size Size
            {
                get{return this.size;}
                set
                {
                    if((value.Width >= 0) && (value.Height >= 0))
                    {
                        this.size.Width = value.Width;
                        this.size.Height = value.Height;
                    }
                    else
                    {
                        this.size.Width = 0;
                        this.size.Height = 0;
                    }
                }
            }
            public Size OffsetSize
            {
                get{return this.offsetSize;}
                set
                {
                    this.offsetSize.Width = value.Width;
                    this.offsetSize.Height = value.Height;
                }
            }
            public Point PositionOfStarting
            {
                get{return this.positionOfStarting;}
            }
            public Point PositionOfStartingForGraphic
            {
                get{return this.positionOfStartingForGraphic; }
            }
            public Point PositionOfCornerMin
            {
                get{return this.positionOfCornerMin;}
            }
            public Point PositionOfCornerMax
            {
                get{return this.positionOfCornerMax;}
            }
            public bool SampleDetected
            {
                get { return this.sampleDetected; }
                set { this.sampleDetected = value; }
            }
            public uint DetectedSampleCount
            {
                get { return this.detectedSampleCount; }
                set { this.detectedSampleCount = value; }
            }


            public LidarZone()
            {
                this.DistanceType = ZoneDistanceTypes.Mid;
                this.Size = new Size(0, 0);
                this.OffsetSize = new Size(0, 0);
                this.positionOfStarting = calculateZoneStartPosition(this.Size, this.OffsetSize);
                this.positionOfStartingForGraphic = calculateZoneStartPositionForGraphic(this.Size, this.OffsetSize);
                var corner = calculateTheMaxAndMinCornerCoordinatesOfTheZone(this.Size, this.positionOfStarting);//NOTE: Bu fonksiyon değer döndüren hale getirilecek döndürdüğü yapı tüm pozisyonları içeren bir yapı şekilnde olabilir.Bakılacak!! Şuan corner max min şeklinde iki ayrı Point nesnesi.
                this.positionOfCornerMin = corner.Min;
                this.positionOfCornerMax = corner.Max;
                this.SampleDetected = false;
                this.DetectedSampleCount = 0;
            }
            public LidarZone(ZoneDistanceTypes zoneDistanceType, Size zoneSize, Size zoneOffsetSize)
            {
                this.DistanceType = zoneDistanceType;
                this.Size = new Size(zoneSize.Width, zoneSize.Height);
                this.OffsetSize = new Size(zoneOffsetSize.Width, zoneOffsetSize.Height);
                this.positionOfStarting = calculateZoneStartPosition(this.Size, this.OffsetSize);
                this.positionOfStartingForGraphic = calculateZoneStartPositionForGraphic(this.Size, this.OffsetSize);
                var corner = calculateTheMaxAndMinCornerCoordinatesOfTheZone(this.Size, this.positionOfStarting);//NOTE: Bu fonksiyon değer döndüren hale getirilecek döndürdüğü yapı tüm pozisyonları içeren bir yapı şekilnde olabilir.Bakılacak!! Şuan corner max min şeklinde iki ayrı Point nesnesi.
                this.positionOfCornerMin = corner.Min;
                this.positionOfCornerMax = corner.Max;
                this.SampleDetected = false;
                this.DetectedSampleCount = 0;
            }

            Point calculateZoneStartPosition(Size zoneSize, Size zoneOffsetSize)
            {
                Point zoneStartPosition = new Point();

                zoneStartPosition.X = (-1) * (zoneSize.Width / 2);
                zoneStartPosition.Y = (zoneSize.Height / 2);

                zoneStartPosition.X = zoneStartPosition.X + zoneOffsetSize.Width;
                zoneStartPosition.Y = zoneStartPosition.Y + zoneOffsetSize.Height;

                return zoneStartPosition;
            }
            Point calculateZoneStartPositionForGraphic(Size zoneSize, Size zoneOffsetSize)
            {
                Point zoneStartPositionForGraphic = new Point();

                int rectangleCenterX = (zoneSize.Width / 2);
                int rectangleCenterY = (zoneSize.Height / 2);

                int lidarOriginOffsetOfRectangleCenterX = ((-1) * rectangleCenterX);
                int lidarOriginOffsetOfRectangleCenterY = ((-1) * rectangleCenterY);

                zoneStartPositionForGraphic.X = lidarOriginOffsetOfRectangleCenterX + zoneOffsetSize.Width;
                zoneStartPositionForGraphic.Y = lidarOriginOffsetOfRectangleCenterY + (zoneOffsetSize.Height * (-1));  //'Y (Height)' axis was reversed for drawing are with '* (-1)'.

                return zoneStartPositionForGraphic;
            }
            (Point Min, Point Max) calculateTheMaxAndMinCornerCoordinatesOfTheZone(Size zoneSize, Point zoneStartPosition)
            {
                Point cornerMin = new Point();
                Point cornerMax = new Point();

                cornerMin.X = zoneStartPosition.X;
                cornerMin.Y = zoneStartPosition.Y - zoneSize.Height;
                cornerMax.X = zoneStartPosition.X + zoneSize.Width;
                cornerMax.Y = zoneStartPosition.Y;

                return (cornerMin, cornerMax);
            }

            public Graphics drawLidarZone(Graphics graphicsObject)
            {
                Pen zoneDrawPen = new Pen(Brushes.White, 2);

                if (this.DistanceType == ZoneDistanceTypes.Low) zoneDrawPen.Brush = Brushes.Red;
                if (this.DistanceType == ZoneDistanceTypes.Mid) zoneDrawPen.Brush = Brushes.Yellow;

                Rectangle zoneRectangle = new Rectangle(this.PositionOfStartingForGraphic, this.Size);
                graphicsObject.DrawRectangle(zoneDrawPen, zoneRectangle);

                return graphicsObject;
            }
            public Graphics drawLidarZone(Graphics graphicsObject, float scaleRation)
            {
                Pen zoneDrawPen = new Pen(Brushes.White, 2);

                if (this.DistanceType == ZoneDistanceTypes.Low) zoneDrawPen.Brush = Brushes.Red;
                if (this.DistanceType == ZoneDistanceTypes.Mid) zoneDrawPen.Brush = Brushes.Yellow;

                Point scaledStartPosition = new Point();
                Size scaledSize = new Size();

                scaledStartPosition.X = (int)((float)this.PositionOfStartingForGraphic.X * scaleRation);
                scaledStartPosition.Y = (int)((float)this.PositionOfStartingForGraphic.Y * scaleRation);
                scaledSize.Width = (int)((float)this.Size.Width * scaleRation);
                scaledSize.Height = (int)((float)this.Size.Height * scaleRation);

                Rectangle zoneRectangle = new Rectangle(scaledStartPosition, scaledSize);
                graphicsObject.DrawRectangle(zoneDrawPen, zoneRectangle);

                return graphicsObject;
            }
            public bool checkInTheZone(float coordinateX, float coordinateY)
            {
                bool detectedOfSample = false;

                if((coordinateX >= this.positionOfCornerMin.X) && (coordinateY >= this.positionOfCornerMin.Y) && (coordinateX <= this.positionOfCornerMax.X) && (coordinateY <= this.positionOfCornerMax.Y))
                {
                    detectedOfSample = true;

                    this.DetectedSampleCount++;//(30112022)
                    this.SampleDetected = true;
                }
                else
                {
                    detectedOfSample = false;
                }

                return detectedOfSample;
            }
            public void clearDetectedSampleCount()//(30112022)
            {
                this.DetectedSampleCount = 0;
                this.SampleDetected = false;
            }
        }
    }
}
/*NOTE: 28/11/2022 yapılacak notu!
 * - Fonksiyonlar için kullanılan parametre tiplerini tekrar düzenle.
 * - RPLidar aray tipini Arraylist veya list yapısına çevir, bilinmeyen boyut için rahat işlem yapabilesin.
 * - Kapatılan list box yazdırmalarını ayrı ayrı buton altına alabilirsin.(önemsiz.)
 * 
 * - Görselleştirme alanı için zom in/zom out yapılabilmesi için çizme fonksiyonunen scale edilmesi için
 * geçilen max lidar mesafe değeri değiştirilerek yapılabilir. Beraberinde çizdirilen çizdirilen elipsler bu değerle ölçekli 1metre
 * gösterecek şekilde ölçeklendirilebilir.
 */