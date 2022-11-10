using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Seri Port İsimleri combobox icerisine eklendi.
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
            //Kullanılan degiskenler
            string fileAddress;
            string fileText;
            string[] textArray;

            openFileDialog1.ShowDialog(this);
            fileAddress = @"" + openFileDialog1.FileName;   //Okunacak dosya path'i adrese ceviriliyor.
            if(fileAddress == "") return;   //Bos dosya adresi gelir ise fonksiyondan cıkacak.

            //Dosya okuma işlemi yapılıyor.
            StreamReader sr = new StreamReader(fileAddress);
            fileText = sr.ReadToEnd();
            sr.Close();

            textBoxOpenFile.Text = fileText;    //Okunan dosya icerigi gosteriliyor.

            textArray = fileText.Split('\n');  //Satır satır split edildi.

            //Okunan hex dosyasının hex kısmı alınıyor.
            for (uint i = 0; i < textArray.Length; i++ )
            {
                string arrayHeader = " - ";
                int startIndexNumOfString = textArray[i].IndexOf(arrayHeader);

                if (startIndexNumOfString != -1)
                {
                    textArray[i] = textArray[i].Remove(textArray[i].Length - 1, 1);   //Satır sonu \r karakterleri kaldırıldı.
                    textArray[i] = textArray[i].Substring( (startIndexNumOfString + arrayHeader.Length) );  //Satır içerisinde hex datasını bulunduğu bölüm alındı.

                    string[] tempArray = textArray[i].Split(' ');  //Starır içerisinde yer alan boşluk karakterleri kaldırıldı.
                    textArray[i] = textArray[i].Remove(0, textArray[i].Length); //textArray araması yeniden yapılabilmesi için her indeksi silinmiş oldu.

                    foreach (string tempArrayString in tempArray)
                    {
                        textArray[i] += tempArrayString;   //Birteştirilmiş hex kodu her text array indeksi için atanıyor.
                    }
                }
            }

            //textBoxOpenFile.Text += textArray[2]; //Test için satır yazdırma kullanıldı.

            /* //Test için yazdırma kullanıldı.
            foreach (string line in textArray)
            {
                textBoxOpenFile.Text += line;
            }*/

            int hexDataIndex = 2;
            RPLidarData[] rPLidarData;
            rPLidarData = new RPLidarData[textArray[hexDataIndex].Length/10];

            //RPlidar datası veri yapısı içerisine eklendi.
            for(int index = 0; index < (textArray[hexDataIndex].Length / 10); index++)
            {
                int startIndex, indexLength;
                startIndex = (index * 10);
                indexLength = 2;

                string tempQuality = textArray[hexDataIndex].Substring(startIndex, indexLength);
                tempQuality = "0x" + tempQuality;

                //Angle degerinin bulunduğu 2 baytlık hex kodu capraz alındı.
                string tempAngle ="0x" + textArray[hexDataIndex].Substring(startIndex + 4, indexLength);
                tempAngle += textArray[hexDataIndex].Substring(startIndex + 2, indexLength);

                //Distance degerinin bulunduğu 2 baytlık hex kodu capraz alındı.
                string tempDistance ="0x" + textArray[hexDataIndex].Substring(startIndex + 8, indexLength);
                tempDistance += textArray[hexDataIndex].Substring(startIndex + 6, indexLength);

                rPLidarData[index].quality = Convert.ToByte(tempQuality, 16);
                rPLidarData[index].angle = Convert.ToUInt16(tempAngle, 16);
                rPLidarData[index].distance = Convert.ToUInt16(tempDistance, 16);
            }

            //RPLidar list box içerisinde listelenecek data icin kullanılan degisken tanımları.
            uint lidarDataCount = 0;
            uint lidarStartBitCount = 0;
            uint lidarDataQualityThreshold = 0;
            uint lidarDataQualityCount = 0;

            //Kullanılacak list box icerigi her dosya acmada temizleniyor.
            listBoxRPLidarData.Items.Clear();
            listBoxRPLidarStartBits.Items.Clear();
            listBoxRPLidarDataQuality.Items.Clear();

            //Lidar data viewer icin bitmap tanımı.
            Bitmap bmp = createLidarViewerPanel(pictureBoxRPLidarDataViewer.Size.Width, pictureBoxRPLidarDataViewer.Size.Height);
            
            //Lidar data viewer.
            float distanceThreshod = (float)Convert.ToUInt32(textBoxViewLidarDistance.Text);
            float qualityThreshold = (float)Convert.ToUInt32(textBoxDataQualityThreshold.Text);

            //Lidar data viewer Mid ve Low degerleri.
            float LowDistanceThreshod = (float)Convert.ToUInt32(textBoxLidarLowDistance.Text);
            float MidDistanceThreshod = (float)Convert.ToUInt32(textBoxLidarMidDistance.Text);

            //Lidar Zone 'Width' , 'Height' ve offset  degerleri.
            float lidarZoneHeight = (float)Convert.ToUInt32(textBoxLidarZoneHeight.Text);
            float lidarZoneHeightOffset = (float)Convert.ToInt32(textBoxLidarZoneHeightOffset.Text);
            float lidarZoneWidth = (float)Convert.ToUInt32(textBoxLidarZoneWidth.Text);
            float lidarZoneWidthOffset = (float)Convert.ToInt32(textBoxLidarZoneWidthOffset.Text);
            
            float zoneCenterX = lidarZoneWidth / 2;
            float zoneCenterY = lidarZoneHeight / 2;

            int lidarZoneMin_X = (int)(lidarZoneWidthOffset - (zoneCenterX));
            int lidarZoneMax_X = (int)(lidarZoneWidthOffset + (zoneCenterX));
            int lidarZoneMin_Y = (int)(lidarZoneHeightOffset*(-1) - (zoneCenterY));
            int lidarZoneMax_Y = (int)(lidarZoneHeightOffset*(-1) + (zoneCenterY));

            //Lidar zone çizdiriliyor.
            bmp = createLidarDetectZoneViewer(bmp, lidarZoneWidth, lidarZoneWidthOffset, lidarZoneHeight, lidarZoneHeightOffset);

            //RPLidar datası istenen bir text formatına çevrildi.
            for (int i = 0; i<rPLidarData.Length; i++)
            {
                uint tempStartBit = (uint)rPLidarData[i].quality & 0x01;
                uint tempQuality = (uint)rPLidarData[i].quality >> 2;
                float tempAngle = (float)((rPLidarData[i].angle >> 1) / 64.0);
                float tempDistance = (float)(rPLidarData[i].distance / 4.0);

                string tempText =$"{(i + 1).ToString()} )\t";
                tempText +=$"Start Bit:\t{(tempStartBit.ToString())}";
                tempText +=$"\tQuality:\t{(tempQuality.ToString("00"))}";
                tempText +=$"\tAngle:\t{(tempAngle.ToString("0.0"))}";
                tempText +=$"\tDistance:\t{(tempDistance.ToString("0.0"))}mm";

                listBoxRPLidarData.Items.Add(tempText);
                lidarDataCount++;

                //Start Bitleri filtrelendi.
                if (Convert.ToBoolean(tempStartBit & 0x01))
                {
                    listBoxRPLidarStartBits.Items.Add(tempText);
                    lidarStartBitCount++;
                }

                //Data Quality filtrelendi.
                lidarDataQualityThreshold = Convert.ToUInt32(textBoxDataQualityThreshold.Text);
                if (tempQuality >= lidarDataQualityThreshold)
                {
                    listBoxRPLidarDataQuality.Items.Add(tempText);
                    lidarDataQualityCount++;
                }

                //Lidar datası zone alanı için kontrol ediliyor.
                bool detectionZoneFlag = checkTheLidarDetectionZone((float)tempAngle, (float)tempDistance, lidarZoneMin_X, lidarZoneMax_X, lidarZoneMin_Y, lidarZoneMax_Y);

                //lidar datası grafiğe çizdiriliyor.
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

                    pictureBoxRPLidarDataViewer.BackColor = Color.Black;
                    pictureBoxRPLidarDataViewer.Image = bmp;
                }
            }

            //list box icin elde edilen count degerleri label uzerine yazdiriliyor.
            labelLidarData.Text = $"Lidar Data: {lidarDataCount}";
            labelLİdarDataStartBits.Text = $"Lidar Data Start Bits: {lidarStartBitCount}";
            labelLidarDataQuality.Text = $"Selected Data Quality List: {lidarDataQualityCount}";
        }

        //RPLidar datası için kullanılan veri yapısı.
        public struct RPLidarData
        {
            public byte quality;
            public UInt16 angle;
            public UInt16 distance;
        }

        //Kutupsal gösterimden koordinat dikdörtgensel gösterime çevirme fonksiyon tanımı.
        public (int x, int y) convertPolarToRectangular(float angle, float distance, int coordinateOriginX, int coordinateOriginY)
        {
            int x, y;
            double radian = Math.PI * angle / 180.0;

            if (angle >= 0 && angle <= 180)
            {
                x = coordinateOriginX + (int)(distance * Math.Sin(radian));
                y = coordinateOriginY - (int)(distance * Math.Cos(radian));
            }
            else
            {
                x = coordinateOriginX - (int)(distance * -Math.Sin(radian));
                y = coordinateOriginY - (int)(distance * Math.Cos(radian));
            }

            return (x, y);
        }

        //Lidar viewer creater fonksiyonu.
        public Bitmap createLidarViewerPanel(int panelWidth, int panelHeight)
        {
            int centerX = panelWidth / 2;
            int centerY = panelHeight / 2;

            Bitmap viewerBitMap = new Bitmap(panelWidth, panelHeight);
            Pen p = new Pen(Brushes.DarkGreen, 1);
            Graphics viewerGraphic = Graphics.FromImage(viewerBitMap);

            //draw circle
            viewerGraphic.DrawEllipse(p, 0 + 1, 0 + 1, panelWidth - 3, panelHeight - 3);  //bigger circle
            viewerGraphic.DrawEllipse(p, 80, 80, panelWidth - 160, panelHeight - 160);    //smaller circle

            //draw perpendicular line
            viewerGraphic.DrawLine(p, new Point(centerX, 0), new Point(centerX, panelHeight)); // UP-DOWN
            viewerGraphic.DrawLine(p, new Point(0, centerY), new Point(panelWidth, centerY)); //LEFT-RIGHT
            int crossLO = 74;//Capraz cizilen cizgiler bitmap e göre dinamik değildir.Gerektigidurumda dinamik yapılacaktır.
            viewerGraphic.DrawLine(p, new Point(centerX, centerY), new Point(panelWidth - crossLO, 0 + crossLO)); //Right Up Cross Line
            viewerGraphic.DrawLine(p, new Point(centerX, centerY), new Point(panelWidth - crossLO, panelHeight - crossLO)); //Right Down Cross Line
            viewerGraphic.DrawLine(p, new Point(centerX, centerY), new Point(0 + crossLO, panelHeight - crossLO)); //Left Down Cross Line
            viewerGraphic.DrawLine(p, new Point(centerX, centerY), new Point(0 + crossLO, 0 + crossLO)); //Left UP Cross Line

            return (viewerBitMap);
        }

        //Lidar Zone viewer.
        public Bitmap createLidarDetectZoneViewer(Bitmap lidarPanelBitmap, float zoneWidth, float zoneWidthOffset, float zoneHeight , float zoneHeightOffset)
        {
            Pen p = new Pen(Brushes.Blue, 2);
            Graphics zoneViewerGraphic = Graphics.FromImage(lidarPanelBitmap);

            int bmpCenterX = lidarPanelBitmap.Size.Width / 2;
            int bmpCenterY = lidarPanelBitmap.Size.Height / 2;

            float newZoneWidthOffset;
            float newZoneHeightOffset;

            //Width değerleri için ölçekleme yapılıyor.
            zoneWidth = scale(zoneWidth, (float)0, (float)12000, (float)0, (float)lidarPanelBitmap.Size.Width);
            newZoneWidthOffset = scale(Math.Abs(zoneWidthOffset), (float)0, (float)6000, (float)0, (float)lidarPanelBitmap.Size.Width / 2);
            newZoneWidthOffset = (zoneWidthOffset < 0) ? (newZoneWidthOffset * (-1)) : newZoneWidthOffset;

            //Height değerleri için ölçekleme yapılıyor.
            zoneHeight = scale(zoneHeight, (float)0, (float)12000, (float)0, (float)lidarPanelBitmap.Size.Height);
            newZoneHeightOffset = scale(Math.Abs(zoneHeightOffset), (float)0, (float)6000, (float)0, (float)lidarPanelBitmap.Size.Height / 2);
            newZoneHeightOffset = (zoneHeightOffset < 0) ? (newZoneHeightOffset * (-1)) : newZoneHeightOffset;

            //Ölceklenmiş değerler için, 'X(Width)' için sağ yani '+' , 'Y(Height)' için aşağı yani '-' işlemleri uygulanarak zone enter hesaplanıyor.
            float ZoneCenterX = (zoneWidth / 2) - (newZoneWidthOffset);
            float ZoneCenterY = (zoneHeight / 2) + (newZoneHeightOffset);

            zoneViewerGraphic.DrawRectangle(p, (bmpCenterX - ZoneCenterX), (bmpCenterY - ZoneCenterY), zoneWidth, zoneHeight);
            zoneViewerGraphic.FillEllipse(Brushes.Blue, ((bmpCenterX - ZoneCenterX) + zoneWidth / 2) - 3, ((bmpCenterY - ZoneCenterY) + zoneHeight / 2) - 3, 6, 6);
            return (lidarPanelBitmap);
        }

        //Lidar verisi zone alanındamı kontrolü.
        public bool checkTheLidarDetectionZone(float lidarAngle, float lidarDistance, float lidarZoneMinX, float lidarZoneMaxX, float lidarZoneMinY, float lidarZoneMaxY)
        {
            bool detectionZone = false;

            var lidarSampleCoordinate = convertPolarToRectangular(lidarAngle, lidarDistance, 0, 0);

            if ((lidarSampleCoordinate.x >= lidarZoneMinX && lidarSampleCoordinate.x <= lidarZoneMaxX) && (lidarSampleCoordinate.y >= lidarZoneMinY && lidarSampleCoordinate.y <= lidarZoneMaxY))
            {
                detectionZone = true;
            }
            else
            {
                detectionZone = false;
            }

            return (detectionZone);
        }

        //Lİdar datası görselleştiriliyor.
        public Bitmap createLidarDataGraph(Pen pen, float angleDataOfLidar, float distaceInAngleDataOflidar_mm, Bitmap bitmap, uint minLidarDistance_mm, uint maxLidarDistance_mm)
        {
            int x, y;
            int cx, cy;

            cx = bitmap.Size.Width / 2;
            cy = bitmap.Size.Height / 2;

            float scaledLidarDistance_mm = scale(distaceInAngleDataOflidar_mm, minLidarDistance_mm, maxLidarDistance_mm, 0, cx);

            var coordinate = convertPolarToRectangular(angleDataOfLidar, scaledLidarDistance_mm, cx, cy);
            x = coordinate.x;
            y = coordinate.y;

            Graphics lidarDataGraph = Graphics.FromImage(bitmap);
            lidarDataGraph.DrawLine(pen, new Point(x - 2, y), new Point(x + 2, y));
            return (bitmap);
        }

        //uzunluk ölceklendirme fonksiyonu.
        public float scale(float value, float minValue, float maxValue, float scaledMin, float scaledMax)
        {
            float scale = (float)(scaledMax - scaledMin) / (float)(maxValue - minValue);
            float offset = minValue * scale - scaledMin;

            float scaledValue = (value * scale) - offset;
            return (scaledValue);
        }

        //Serial Port Data Recieved Event
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {           
            if(!checkResponseData(rpLidarScanIDResponse, rpLidarScanIDResponseData))
            {
                serialPort1.Read(rpLidarScanIDResponseData, 0, 7);
            }
            else if(checkResponseData(rpLidarScanIDResponse, rpLidarScanIDResponseData) && serialPortRPLidarDataIndex < 30)
            {
                serialPort1.Read(spLidarScanRawDataBuf, 0, 5);
                serialPortRPLidarData[serialPortRPLidarDataIndex] = createRPlidarDataFromRawData(spLidarScanRawDataBuf);
                textBoxSeriPortDataReceive.Invoke(new showTextSerialPortData(writeToTextBox), serialPortRPLidarData[serialPortRPLidarDataIndex]);
                serialPortRPLidarDataIndex++;
            }
            else
            {
                serialPort1.Write(new byte[] { 0xA5, 0x25 }, 0, 2);
                serialPort1.Write(new byte[] { 0xA5, 0x25 }, 0, 2);
                serialPort1.Close();
            }
        }

        //Tread cakısması hatasının giderilmesi icin kullanılmıstır.
        public delegate void showTextSerialPortData(RPLidarData data);
        public void writeToTextBox(RPLidarData data)
        {
            uint tempQuality = (uint)data.quality;
            float tempAngle = (float)((double)data.angle / 64.0);
            float tempDistance = (float)((double)data.distance / 4.0);

            textBoxSeriPortDataReceive.Text += "Quality:" + tempQuality + "\t";
            textBoxSeriPortDataReceive.Text += "Angle:" + tempAngle + "\t";
            textBoxSeriPortDataReceive.Text += "Distance:" + tempDistance + "\t";
            textBoxSeriPortDataReceive.Text += "\r\n";
        }

        private void buttonSeriPortCon_MouseClick(object sender, MouseEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //Open File button enable hale getiriliyor.
                buttonOpenFile.Enabled = true;

                //Combo box enable hale getiriliyor.
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
                //Open File button enable hale getiriliyor.
                buttonOpenFile.Enabled = false;

                //Combo box disable hale getiriliyor.
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
        
        //List<RPLidarData> rpLidarDataList = new List<RPLidarData>();
        RPLidarData[] serialPortRPLidarData = new RPLidarData[30];
        int serialPortRPLidarDataIndex = 0;
        Byte[] spLidarScanRawDataBuf = new Byte[5];
        Byte[] rpLidarScanIDResponse = new Byte[] {0xA5, 0x5A, 0x05, 0x00, 0x00, 0x40, 0x81};
        Byte[] rpLidarScanIDResponseData = new Byte[7];

        public bool checkResponseData(Byte[] firstBytes, Byte[] secondBytes)
        {
            return firstBytes.SequenceEqual(secondBytes);
        }

        private void buttonRPLidarScanID_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen) serialPort1.Write(new byte[] { 0xA5, 0x20 }, 0, 2);
        }

        private void buttonRPLidarStopID_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Write(new byte[] { 0xA5, 0x25 }, 0, 2);
        }

        public void drawLidarScreen(RPLidarData[] data, uint dataCount, Bitmap bmp)
        {
            //Lidar data viewer icin bitmap tanımı.
            Bitmap lidarBmp = createLidarViewerPanel(pictureBoxRPLidarDataViewer.Size.Width, pictureBoxRPLidarDataViewer.Size.Height);

            for (int i = 0; i < dataCount; i++)
            {
                uint tempQuality = (uint)data[i].quality;
                float tempAngle = (float)((double)data[i].angle / 64.0);
                float tempDistance = (float)((double)data[i].distance / 4.0);

                lidarBmp = createLidarDataGraph(new Pen(Brushes.Yellow, 3), (float)tempAngle, (float)tempDistance, bmp, 150, 6000);
            }

            pictureBoxRPLidarDataViewer.Image = lidarBmp;
        }

        public RPLidarData createRPlidarDataFromRawData(Byte[] bytes)
        {
            RPLidarData tempRPLidarData = new RPLidarData();

            //Quality
            tempRPLidarData.quality = (byte)(bytes[0] >> 2);
            //Angle
            tempRPLidarData.angle = (UInt16)(bytes[1] << 8);
            tempRPLidarData.angle += (UInt16)bytes[2];
            tempRPLidarData.angle = (UInt16)(tempRPLidarData.angle >> 1);
            //Distance
            tempRPLidarData.distance = (UInt16)(bytes[3] << 8);
            tempRPLidarData.distance += (UInt16)bytes[4];

            return tempRPLidarData;
        }
    }
}
