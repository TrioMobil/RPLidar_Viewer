namespace RPLidarDataViewerProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxOpenFile = new System.Windows.Forms.TextBox();
            this.listBoxRPLidarData = new System.Windows.Forms.ListBox();
            this.labelLidarData = new System.Windows.Forms.Label();
            this.listBoxRPLidarStartBits = new System.Windows.Forms.ListBox();
            this.labelLİdarDataStartBits = new System.Windows.Forms.Label();
            this.labelLidarDataQuality = new System.Windows.Forms.Label();
            this.listBoxRPLidarDataQuality = new System.Windows.Forms.ListBox();
            this.textBoxDataQualityThreshold = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxRPLidarDataViewer = new System.Windows.Forms.PictureBox();
            this.labelLidarDataViewer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelViewDistance = new System.Windows.Forms.Label();
            this.textBoxViewLidarDistance = new System.Windows.Forms.TextBox();
            this.textBoxViewDataQuality = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLidarZoneHeightOffset = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxLidarZoneHeight = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxLidarMidDistance = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxLidarLowDistance = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxLidarZoneWidth = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxLidarZoneWidthOffset = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRPLidarStopID = new System.Windows.Forms.Button();
            this.labelSeriPortName = new System.Windows.Forms.Label();
            this.buttonRPLidarScanID = new System.Windows.Forms.Button();
            this.labelSerialPortInfo = new System.Windows.Forms.Label();
            this.textBoxSeriPortDataReceive = new System.Windows.Forms.TextBox();
            this.buttonSeriPortCon = new System.Windows.Forms.Button();
            this.comboBoxSeriPortList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRPLidarDataViewer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOpenFile.Location = new System.Drawing.Point(12, 193);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(300, 53);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // textBoxOpenFile
            // 
            this.textBoxOpenFile.Location = new System.Drawing.Point(12, 12);
            this.textBoxOpenFile.Multiline = true;
            this.textBoxOpenFile.Name = "textBoxOpenFile";
            this.textBoxOpenFile.ReadOnly = true;
            this.textBoxOpenFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOpenFile.Size = new System.Drawing.Size(500, 175);
            this.textBoxOpenFile.TabIndex = 2;
            // 
            // listBoxRPLidarData
            // 
            this.listBoxRPLidarData.FormattingEnabled = true;
            this.listBoxRPLidarData.Location = new System.Drawing.Point(577, 37);
            this.listBoxRPLidarData.Name = "listBoxRPLidarData";
            this.listBoxRPLidarData.Size = new System.Drawing.Size(500, 121);
            this.listBoxRPLidarData.TabIndex = 3;
            // 
            // labelLidarData
            // 
            this.labelLidarData.AutoSize = true;
            this.labelLidarData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLidarData.Location = new System.Drawing.Point(577, 9);
            this.labelLidarData.Name = "labelLidarData";
            this.labelLidarData.Size = new System.Drawing.Size(128, 25);
            this.labelLidarData.TabIndex = 4;
            this.labelLidarData.Text = "Lidar Data:";
            // 
            // listBoxRPLidarStartBits
            // 
            this.listBoxRPLidarStartBits.FormattingEnabled = true;
            this.listBoxRPLidarStartBits.Location = new System.Drawing.Point(577, 189);
            this.listBoxRPLidarStartBits.Name = "listBoxRPLidarStartBits";
            this.listBoxRPLidarStartBits.Size = new System.Drawing.Size(500, 121);
            this.listBoxRPLidarStartBits.TabIndex = 5;
            // 
            // labelLİdarDataStartBits
            // 
            this.labelLİdarDataStartBits.AutoSize = true;
            this.labelLİdarDataStartBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLİdarDataStartBits.Location = new System.Drawing.Point(577, 161);
            this.labelLİdarDataStartBits.Name = "labelLİdarDataStartBits";
            this.labelLİdarDataStartBits.Size = new System.Drawing.Size(232, 25);
            this.labelLİdarDataStartBits.TabIndex = 6;
            this.labelLİdarDataStartBits.Text = "Lidar Data Start Bits:";
            // 
            // labelLidarDataQuality
            // 
            this.labelLidarDataQuality.AutoSize = true;
            this.labelLidarDataQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLidarDataQuality.Location = new System.Drawing.Point(572, 313);
            this.labelLidarDataQuality.Name = "labelLidarDataQuality";
            this.labelLidarDataQuality.Size = new System.Drawing.Size(293, 25);
            this.labelLidarDataQuality.TabIndex = 8;
            this.labelLidarDataQuality.Text = "Selected Data Quality List:";
            // 
            // listBoxRPLidarDataQuality
            // 
            this.listBoxRPLidarDataQuality.FormattingEnabled = true;
            this.listBoxRPLidarDataQuality.Location = new System.Drawing.Point(577, 364);
            this.listBoxRPLidarDataQuality.Name = "listBoxRPLidarDataQuality";
            this.listBoxRPLidarDataQuality.Size = new System.Drawing.Size(500, 121);
            this.listBoxRPLidarDataQuality.TabIndex = 7;
            // 
            // textBoxDataQualityThreshold
            // 
            this.textBoxDataQualityThreshold.Location = new System.Drawing.Point(758, 341);
            this.textBoxDataQualityThreshold.Name = "textBoxDataQualityThreshold";
            this.textBoxDataQualityThreshold.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDataQualityThreshold.Size = new System.Drawing.Size(51, 20);
            this.textBoxDataQualityThreshold.TabIndex = 9;
            this.textBoxDataQualityThreshold.Text = "15";
            this.textBoxDataQualityThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(578, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Data Quality Threshold:";
            // 
            // pictureBoxRPLidarDataViewer
            // 
            this.pictureBoxRPLidarDataViewer.BackColor = System.Drawing.Color.Black;
            this.pictureBoxRPLidarDataViewer.Location = new System.Drawing.Point(12, 399);
            this.pictureBoxRPLidarDataViewer.Name = "pictureBoxRPLidarDataViewer";
            this.pictureBoxRPLidarDataViewer.Size = new System.Drawing.Size(500, 500);
            this.pictureBoxRPLidarDataViewer.TabIndex = 11;
            this.pictureBoxRPLidarDataViewer.TabStop = false;
            this.pictureBoxRPLidarDataViewer.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxRPLidarDataViewer_Paint);
            // 
            // labelLidarDataViewer
            // 
            this.labelLidarDataViewer.AutoSize = true;
            this.labelLidarDataViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLidarDataViewer.Location = new System.Drawing.Point(12, 256);
            this.labelLidarDataViewer.Name = "labelLidarDataViewer";
            this.labelLidarDataViewer.Size = new System.Drawing.Size(206, 25);
            this.labelLidarDataViewer.TabIndex = 12;
            this.labelLidarDataViewer.Text = "Lidar Data Viewer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(21, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Data Quality >=";
            // 
            // labelViewDistance
            // 
            this.labelViewDistance.AutoSize = true;
            this.labelViewDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelViewDistance.Location = new System.Drawing.Point(7, 324);
            this.labelViewDistance.Name = "labelViewDistance";
            this.labelViewDistance.Size = new System.Drawing.Size(132, 20);
            this.labelViewDistance.TabIndex = 16;
            this.labelViewDistance.Text = "View Distance <=";
            // 
            // textBoxViewLidarDistance
            // 
            this.textBoxViewLidarDistance.Location = new System.Drawing.Point(145, 324);
            this.textBoxViewLidarDistance.Name = "textBoxViewLidarDistance";
            this.textBoxViewLidarDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxViewLidarDistance.Size = new System.Drawing.Size(60, 20);
            this.textBoxViewLidarDistance.TabIndex = 15;
            this.textBoxViewLidarDistance.Text = "6000";
            this.textBoxViewLidarDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxViewDataQuality
            // 
            this.textBoxViewDataQuality.Location = new System.Drawing.Point(145, 298);
            this.textBoxViewDataQuality.Name = "textBoxViewDataQuality";
            this.textBoxViewDataQuality.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxViewDataQuality.Size = new System.Drawing.Size(44, 20);
            this.textBoxViewDataQuality.TabIndex = 17;
            this.textBoxViewDataQuality.Text = "15";
            this.textBoxViewDataQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(211, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(477, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "mm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(260, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Zone Height Offset";
            // 
            // textBoxLidarZoneHeightOffset
            // 
            this.textBoxLidarZoneHeightOffset.Location = new System.Drawing.Point(411, 324);
            this.textBoxLidarZoneHeightOffset.Name = "textBoxLidarZoneHeightOffset";
            this.textBoxLidarZoneHeightOffset.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLidarZoneHeightOffset.Size = new System.Drawing.Size(60, 20);
            this.textBoxLidarZoneHeightOffset.TabIndex = 19;
            this.textBoxLidarZoneHeightOffset.Text = "1000";
            this.textBoxLidarZoneHeightOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(477, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "mm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(308, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Zone Height";
            // 
            // textBoxLidarZoneHeight
            // 
            this.textBoxLidarZoneHeight.Location = new System.Drawing.Point(411, 298);
            this.textBoxLidarZoneHeight.Name = "textBoxLidarZoneHeight";
            this.textBoxLidarZoneHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLidarZoneHeight.Size = new System.Drawing.Size(60, 20);
            this.textBoxLidarZoneHeight.TabIndex = 22;
            this.textBoxLidarZoneHeight.Text = "4000";
            this.textBoxLidarZoneHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(211, 348);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "mm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(16, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 20);
            this.label9.TabIndex = 29;
            this.label9.Text = "Mid Distance <=";
            // 
            // textBoxLidarMidDistance
            // 
            this.textBoxLidarMidDistance.Location = new System.Drawing.Point(145, 350);
            this.textBoxLidarMidDistance.Name = "textBoxLidarMidDistance";
            this.textBoxLidarMidDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLidarMidDistance.Size = new System.Drawing.Size(60, 20);
            this.textBoxLidarMidDistance.TabIndex = 28;
            this.textBoxLidarMidDistance.Text = "3000";
            this.textBoxLidarMidDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(211, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "mm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(12, 376);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Low Distance <=";
            // 
            // textBoxLidarLowDistance
            // 
            this.textBoxLidarLowDistance.Location = new System.Drawing.Point(145, 376);
            this.textBoxLidarLowDistance.Name = "textBoxLidarLowDistance";
            this.textBoxLidarLowDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLidarLowDistance.Size = new System.Drawing.Size(60, 20);
            this.textBoxLidarLowDistance.TabIndex = 25;
            this.textBoxLidarLowDistance.Text = "2000";
            this.textBoxLidarLowDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(477, 350);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 20);
            this.label12.TabIndex = 36;
            this.label12.Text = "mm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(314, 350);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 20);
            this.label13.TabIndex = 35;
            this.label13.Text = "Zone Width";
            // 
            // textBoxLidarZoneWidth
            // 
            this.textBoxLidarZoneWidth.Location = new System.Drawing.Point(411, 350);
            this.textBoxLidarZoneWidth.Name = "textBoxLidarZoneWidth";
            this.textBoxLidarZoneWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLidarZoneWidth.Size = new System.Drawing.Size(60, 20);
            this.textBoxLidarZoneWidth.TabIndex = 34;
            this.textBoxLidarZoneWidth.Text = "2000";
            this.textBoxLidarZoneWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(477, 376);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 20);
            this.label14.TabIndex = 33;
            this.label14.Text = "mm";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(266, 376);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(139, 20);
            this.label15.TabIndex = 32;
            this.label15.Text = "Zone Width Offset";
            // 
            // textBoxLidarZoneWidthOffset
            // 
            this.textBoxLidarZoneWidthOffset.Location = new System.Drawing.Point(411, 376);
            this.textBoxLidarZoneWidthOffset.Name = "textBoxLidarZoneWidthOffset";
            this.textBoxLidarZoneWidthOffset.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLidarZoneWidthOffset.Size = new System.Drawing.Size(60, 20);
            this.textBoxLidarZoneWidthOffset.TabIndex = 31;
            this.textBoxLidarZoneWidthOffset.Text = "0";
            this.textBoxLidarZoneWidthOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.ReadBufferSize = 20480;
            this.serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort1_ErrorReceived);
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRPLidarStopID);
            this.groupBox1.Controls.Add(this.labelSeriPortName);
            this.groupBox1.Controls.Add(this.buttonRPLidarScanID);
            this.groupBox1.Controls.Add(this.labelSerialPortInfo);
            this.groupBox1.Controls.Add(this.textBoxSeriPortDataReceive);
            this.groupBox1.Controls.Add(this.buttonSeriPortCon);
            this.groupBox1.Controls.Add(this.comboBoxSeriPortList);
            this.groupBox1.Location = new System.Drawing.Point(577, 508);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 391);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port Settings";
            // 
            // buttonRPLidarStopID
            // 
            this.buttonRPLidarStopID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonRPLidarStopID.Location = new System.Drawing.Point(140, 325);
            this.buttonRPLidarStopID.Name = "buttonRPLidarStopID";
            this.buttonRPLidarStopID.Size = new System.Drawing.Size(128, 60);
            this.buttonRPLidarStopID.TabIndex = 40;
            this.buttonRPLidarStopID.Text = "Stop";
            this.buttonRPLidarStopID.UseVisualStyleBackColor = true;
            this.buttonRPLidarStopID.Click += new System.EventHandler(this.buttonRPLidarStopID_Click);
            // 
            // labelSeriPortName
            // 
            this.labelSeriPortName.AutoSize = true;
            this.labelSeriPortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSeriPortName.Location = new System.Drawing.Point(6, 16);
            this.labelSeriPortName.Name = "labelSeriPortName";
            this.labelSeriPortName.Size = new System.Drawing.Size(115, 16);
            this.labelSeriPortName.TabIndex = 12;
            this.labelSeriPortName.Text = "Serial Port Name :";
            // 
            // buttonRPLidarScanID
            // 
            this.buttonRPLidarScanID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonRPLidarScanID.Location = new System.Drawing.Point(6, 325);
            this.buttonRPLidarScanID.Name = "buttonRPLidarScanID";
            this.buttonRPLidarScanID.Size = new System.Drawing.Size(128, 60);
            this.buttonRPLidarScanID.TabIndex = 39;
            this.buttonRPLidarScanID.Text = "Scan";
            this.buttonRPLidarScanID.UseVisualStyleBackColor = true;
            this.buttonRPLidarScanID.Click += new System.EventHandler(this.buttonRPLidarScanID_Click);
            // 
            // labelSerialPortInfo
            // 
            this.labelSerialPortInfo.AutoSize = true;
            this.labelSerialPortInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSerialPortInfo.Location = new System.Drawing.Point(14, 48);
            this.labelSerialPortInfo.Name = "labelSerialPortInfo";
            this.labelSerialPortInfo.Size = new System.Drawing.Size(135, 20);
            this.labelSerialPortInfo.TabIndex = 11;
            this.labelSerialPortInfo.Text = "Serial Port Info:";
            // 
            // textBoxSeriPortDataReceive
            // 
            this.textBoxSeriPortDataReceive.Location = new System.Drawing.Point(10, 89);
            this.textBoxSeriPortDataReceive.Multiline = true;
            this.textBoxSeriPortDataReceive.Name = "textBoxSeriPortDataReceive";
            this.textBoxSeriPortDataReceive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSeriPortDataReceive.Size = new System.Drawing.Size(480, 220);
            this.textBoxSeriPortDataReceive.TabIndex = 38;
            // 
            // buttonSeriPortCon
            // 
            this.buttonSeriPortCon.Location = new System.Drawing.Point(260, 13);
            this.buttonSeriPortCon.Name = "buttonSeriPortCon";
            this.buttonSeriPortCon.Size = new System.Drawing.Size(109, 23);
            this.buttonSeriPortCon.TabIndex = 10;
            this.buttonSeriPortCon.Text = "Serial Port Connect";
            this.buttonSeriPortCon.UseVisualStyleBackColor = true;
            this.buttonSeriPortCon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSeriPortCon_MouseClick);
            // 
            // comboBoxSeriPortList
            // 
            this.comboBoxSeriPortList.FormattingEnabled = true;
            this.comboBoxSeriPortList.Location = new System.Drawing.Point(136, 14);
            this.comboBoxSeriPortList.Name = "comboBoxSeriPortList";
            this.comboBoxSeriPortList.Size = new System.Drawing.Size(109, 21);
            this.comboBoxSeriPortList.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 911);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxLidarZoneWidth);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxLidarZoneWidthOffset);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxLidarMidDistance);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxLidarLowDistance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxLidarZoneHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxLidarZoneHeightOffset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxViewDataQuality);
            this.Controls.Add(this.labelViewDistance);
            this.Controls.Add(this.textBoxViewLidarDistance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelLidarDataViewer);
            this.Controls.Add(this.pictureBoxRPLidarDataViewer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDataQualityThreshold);
            this.Controls.Add(this.labelLidarDataQuality);
            this.Controls.Add(this.listBoxRPLidarDataQuality);
            this.Controls.Add(this.labelLİdarDataStartBits);
            this.Controls.Add(this.listBoxRPLidarStartBits);
            this.Controls.Add(this.labelLidarData);
            this.Controls.Add(this.listBoxRPLidarData);
            this.Controls.Add(this.textBoxOpenFile);
            this.Controls.Add(this.buttonOpenFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRPLidarDataViewer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxOpenFile;
        private System.Windows.Forms.ListBox listBoxRPLidarData;
        private System.Windows.Forms.Label labelLidarData;
        private System.Windows.Forms.ListBox listBoxRPLidarStartBits;
        private System.Windows.Forms.Label labelLİdarDataStartBits;
        private System.Windows.Forms.Label labelLidarDataQuality;
        private System.Windows.Forms.ListBox listBoxRPLidarDataQuality;
        private System.Windows.Forms.TextBox textBoxDataQualityThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxRPLidarDataViewer;
        private System.Windows.Forms.Label labelLidarDataViewer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelViewDistance;
        private System.Windows.Forms.TextBox textBoxViewLidarDistance;
        private System.Windows.Forms.TextBox textBoxViewDataQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLidarZoneHeightOffset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxLidarZoneHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxLidarMidDistance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxLidarLowDistance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxLidarZoneWidth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxLidarZoneWidthOffset;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelSeriPortName;
        private System.Windows.Forms.Label labelSerialPortInfo;
        private System.Windows.Forms.Button buttonSeriPortCon;
        private System.Windows.Forms.ComboBox comboBoxSeriPortList;
        private System.Windows.Forms.Button buttonRPLidarStopID;
        private System.Windows.Forms.Button buttonRPLidarScanID;
        private System.Windows.Forms.TextBox textBoxSeriPortDataReceive;
    }
}

