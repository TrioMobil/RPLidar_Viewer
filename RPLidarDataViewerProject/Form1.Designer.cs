﻿namespace RPLidarDataViewerProject
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
            this.labelDataQuality = new System.Windows.Forms.Label();
            this.labelViewDistance = new System.Windows.Forms.Label();
            this.textBoxViewLidarDistance = new System.Windows.Forms.TextBox();
            this.textBoxViewDataQuality = new System.Windows.Forms.TextBox();
            this.labelViewDistance_mm = new System.Windows.Forms.Label();
            this.labelMidDistance_mm = new System.Windows.Forms.Label();
            this.labelMidDistance = new System.Windows.Forms.Label();
            this.textBoxLidarMidDistance = new System.Windows.Forms.TextBox();
            this.labelLowDistance_mm = new System.Windows.Forms.Label();
            this.labelLowDistance = new System.Windows.Forms.Label();
            this.textBoxLidarLowDistance = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRPLidarStopID = new System.Windows.Forms.Button();
            this.labelSeriPortName = new System.Windows.Forms.Label();
            this.buttonRPLidarScanID = new System.Windows.Forms.Button();
            this.labelSerialPortInfo = new System.Windows.Forms.Label();
            this.textBoxSeriPortDataReceive = new System.Windows.Forms.TextBox();
            this.buttonSeriPortCon = new System.Windows.Forms.Button();
            this.comboBoxSeriPortList = new System.Windows.Forms.ComboBox();
            this.groupBoxLidarViewer = new System.Windows.Forms.GroupBox();
            this.panelSpeedStatus = new System.Windows.Forms.Panel();
            this.groupBoxZoneSettings_2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownLidarMidZoneWidthOffset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLidarMidZoneWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLidarMidZoneHeightOffset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLidarMidZoneHeight = new System.Windows.Forms.NumericUpDown();
            this.labelMidZoneHeight = new System.Windows.Forms.Label();
            this.labelMidZoneWidth_mm = new System.Windows.Forms.Label();
            this.labelMidZoneHeightOffset = new System.Windows.Forms.Label();
            this.labelMidZoneWidth = new System.Windows.Forms.Label();
            this.labelMidZoneHeightOffse_mm = new System.Windows.Forms.Label();
            this.labelMidZoneWidthOffset_mm = new System.Windows.Forms.Label();
            this.labelMidZoneHeight_mm = new System.Windows.Forms.Label();
            this.labelMidZoneWidthOffset = new System.Windows.Forms.Label();
            this.groupBoxZoneSettings = new System.Windows.Forms.GroupBox();
            this.numericUpDownLidarLowZoneWidthOffset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLidarLowZoneWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLidarLowZoneHeightOffset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLidarLowZoneHeight = new System.Windows.Forms.NumericUpDown();
            this.labelLowZoneHeight = new System.Windows.Forms.Label();
            this.labelLowZoneWidth_mm = new System.Windows.Forms.Label();
            this.labelLowZoneHeightOffset = new System.Windows.Forms.Label();
            this.labelLowZoneWidth = new System.Windows.Forms.Label();
            this.labelLowZoneHeightOffse_mm = new System.Windows.Forms.Label();
            this.labelLowZoneWidthOffset_mm = new System.Windows.Forms.Label();
            this.labelLowZoneHeight_mm = new System.Windows.Forms.Label();
            this.labelLowZoneWidthOffset = new System.Windows.Forms.Label();
            this.groupBoxDataSettings = new System.Windows.Forms.GroupBox();
            this.groupBoxLidarDatas = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRPLidarDataViewer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxLidarViewer.SuspendLayout();
            this.groupBoxZoneSettings_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarMidZoneWidthOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarMidZoneWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarMidZoneHeightOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarMidZoneHeight)).BeginInit();
            this.groupBoxZoneSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarLowZoneWidthOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarLowZoneWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarLowZoneHeightOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarLowZoneHeight)).BeginInit();
            this.groupBoxDataSettings.SuspendLayout();
            this.groupBoxLidarDatas.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOpenFile.Location = new System.Drawing.Point(6, 135);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(120, 30);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // textBoxOpenFile
            // 
            this.textBoxOpenFile.Location = new System.Drawing.Point(6, 29);
            this.textBoxOpenFile.Multiline = true;
            this.textBoxOpenFile.Name = "textBoxOpenFile";
            this.textBoxOpenFile.ReadOnly = true;
            this.textBoxOpenFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOpenFile.Size = new System.Drawing.Size(480, 100);
            this.textBoxOpenFile.TabIndex = 2;
            // 
            // listBoxRPLidarData
            // 
            this.listBoxRPLidarData.FormattingEnabled = true;
            this.listBoxRPLidarData.Location = new System.Drawing.Point(6, 197);
            this.listBoxRPLidarData.Name = "listBoxRPLidarData";
            this.listBoxRPLidarData.Size = new System.Drawing.Size(480, 108);
            this.listBoxRPLidarData.TabIndex = 3;
            // 
            // labelLidarData
            // 
            this.labelLidarData.AutoSize = true;
            this.labelLidarData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLidarData.Location = new System.Drawing.Point(6, 178);
            this.labelLidarData.Name = "labelLidarData";
            this.labelLidarData.Size = new System.Drawing.Size(83, 16);
            this.labelLidarData.TabIndex = 4;
            this.labelLidarData.Text = "Lidar Data:";
            // 
            // listBoxRPLidarStartBits
            // 
            this.listBoxRPLidarStartBits.FormattingEnabled = true;
            this.listBoxRPLidarStartBits.Location = new System.Drawing.Point(6, 342);
            this.listBoxRPLidarStartBits.Name = "listBoxRPLidarStartBits";
            this.listBoxRPLidarStartBits.Size = new System.Drawing.Size(480, 108);
            this.listBoxRPLidarStartBits.TabIndex = 5;
            // 
            // labelLİdarDataStartBits
            // 
            this.labelLİdarDataStartBits.AutoSize = true;
            this.labelLİdarDataStartBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLİdarDataStartBits.Location = new System.Drawing.Point(6, 323);
            this.labelLİdarDataStartBits.Name = "labelLİdarDataStartBits";
            this.labelLİdarDataStartBits.Size = new System.Drawing.Size(149, 16);
            this.labelLİdarDataStartBits.TabIndex = 6;
            this.labelLİdarDataStartBits.Text = "Lidar Data Start Bits:";
            // 
            // labelLidarDataQuality
            // 
            this.labelLidarDataQuality.AutoSize = true;
            this.labelLidarDataQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLidarDataQuality.Location = new System.Drawing.Point(6, 467);
            this.labelLidarDataQuality.Name = "labelLidarDataQuality";
            this.labelLidarDataQuality.Size = new System.Drawing.Size(190, 16);
            this.labelLidarDataQuality.TabIndex = 8;
            this.labelLidarDataQuality.Text = "Selected Data Quality List:";
            // 
            // listBoxRPLidarDataQuality
            // 
            this.listBoxRPLidarDataQuality.FormattingEnabled = true;
            this.listBoxRPLidarDataQuality.Location = new System.Drawing.Point(6, 486);
            this.listBoxRPLidarDataQuality.Name = "listBoxRPLidarDataQuality";
            this.listBoxRPLidarDataQuality.Size = new System.Drawing.Size(480, 108);
            this.listBoxRPLidarDataQuality.TabIndex = 7;
            // 
            // textBoxDataQualityThreshold
            // 
            this.textBoxDataQualityThreshold.Location = new System.Drawing.Point(159, 596);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 597);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Data Quality Threshold:";
            // 
            // pictureBoxRPLidarDataViewer
            // 
            this.pictureBoxRPLidarDataViewer.BackColor = System.Drawing.Color.Black;
            this.pictureBoxRPLidarDataViewer.Location = new System.Drawing.Point(9, 13);
            this.pictureBoxRPLidarDataViewer.Name = "pictureBoxRPLidarDataViewer";
            this.pictureBoxRPLidarDataViewer.Size = new System.Drawing.Size(900, 900);
            this.pictureBoxRPLidarDataViewer.TabIndex = 11;
            this.pictureBoxRPLidarDataViewer.TabStop = false;
            this.pictureBoxRPLidarDataViewer.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxRPLidarDataViewer_Paint);
            // 
            // labelDataQuality
            // 
            this.labelDataQuality.AutoSize = true;
            this.labelDataQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDataQuality.Location = new System.Drawing.Point(18, 16);
            this.labelDataQuality.Name = "labelDataQuality";
            this.labelDataQuality.Size = new System.Drawing.Size(97, 16);
            this.labelDataQuality.TabIndex = 14;
            this.labelDataQuality.Text = "Data Quality >=";
            // 
            // labelViewDistance
            // 
            this.labelViewDistance.AutoSize = true;
            this.labelViewDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelViewDistance.Location = new System.Drawing.Point(6, 42);
            this.labelViewDistance.Name = "labelViewDistance";
            this.labelViewDistance.Size = new System.Drawing.Size(109, 16);
            this.labelViewDistance.TabIndex = 16;
            this.labelViewDistance.Text = "View Distance <=";
            // 
            // textBoxViewLidarDistance
            // 
            this.textBoxViewLidarDistance.Location = new System.Drawing.Point(121, 41);
            this.textBoxViewLidarDistance.Name = "textBoxViewLidarDistance";
            this.textBoxViewLidarDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxViewLidarDistance.Size = new System.Drawing.Size(60, 20);
            this.textBoxViewLidarDistance.TabIndex = 15;
            this.textBoxViewLidarDistance.Text = "6000";
            this.textBoxViewLidarDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxViewDataQuality
            // 
            this.textBoxViewDataQuality.Location = new System.Drawing.Point(121, 15);
            this.textBoxViewDataQuality.Name = "textBoxViewDataQuality";
            this.textBoxViewDataQuality.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxViewDataQuality.Size = new System.Drawing.Size(44, 20);
            this.textBoxViewDataQuality.TabIndex = 17;
            this.textBoxViewDataQuality.Text = "15";
            this.textBoxViewDataQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelViewDistance_mm
            // 
            this.labelViewDistance_mm.AutoSize = true;
            this.labelViewDistance_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelViewDistance_mm.Location = new System.Drawing.Point(187, 42);
            this.labelViewDistance_mm.Name = "labelViewDistance_mm";
            this.labelViewDistance_mm.Size = new System.Drawing.Size(29, 16);
            this.labelViewDistance_mm.TabIndex = 18;
            this.labelViewDistance_mm.Text = "mm";
            // 
            // labelMidDistance_mm
            // 
            this.labelMidDistance_mm.AutoSize = true;
            this.labelMidDistance_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMidDistance_mm.Location = new System.Drawing.Point(187, 68);
            this.labelMidDistance_mm.Name = "labelMidDistance_mm";
            this.labelMidDistance_mm.Size = new System.Drawing.Size(29, 16);
            this.labelMidDistance_mm.TabIndex = 30;
            this.labelMidDistance_mm.Text = "mm";
            // 
            // labelMidDistance
            // 
            this.labelMidDistance.AutoSize = true;
            this.labelMidDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMidDistance.Location = new System.Drawing.Point(13, 68);
            this.labelMidDistance.Name = "labelMidDistance";
            this.labelMidDistance.Size = new System.Drawing.Size(102, 16);
            this.labelMidDistance.TabIndex = 29;
            this.labelMidDistance.Text = "Mid Distance <=";
            // 
            // textBoxLidarMidDistance
            // 
            this.textBoxLidarMidDistance.Location = new System.Drawing.Point(121, 67);
            this.textBoxLidarMidDistance.Name = "textBoxLidarMidDistance";
            this.textBoxLidarMidDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLidarMidDistance.Size = new System.Drawing.Size(60, 20);
            this.textBoxLidarMidDistance.TabIndex = 28;
            this.textBoxLidarMidDistance.Text = "3000";
            this.textBoxLidarMidDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelLowDistance_mm
            // 
            this.labelLowDistance_mm.AutoSize = true;
            this.labelLowDistance_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLowDistance_mm.Location = new System.Drawing.Point(187, 94);
            this.labelLowDistance_mm.Name = "labelLowDistance_mm";
            this.labelLowDistance_mm.Size = new System.Drawing.Size(29, 16);
            this.labelLowDistance_mm.TabIndex = 27;
            this.labelLowDistance_mm.Text = "mm";
            // 
            // labelLowDistance
            // 
            this.labelLowDistance.AutoSize = true;
            this.labelLowDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLowDistance.Location = new System.Drawing.Point(11, 94);
            this.labelLowDistance.Name = "labelLowDistance";
            this.labelLowDistance.Size = new System.Drawing.Size(104, 16);
            this.labelLowDistance.TabIndex = 26;
            this.labelLowDistance.Text = "Low Distance <=";
            // 
            // textBoxLidarLowDistance
            // 
            this.textBoxLidarLowDistance.Location = new System.Drawing.Point(121, 93);
            this.textBoxLidarLowDistance.Name = "textBoxLidarLowDistance";
            this.textBoxLidarLowDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLidarLowDistance.Size = new System.Drawing.Size(60, 20);
            this.textBoxLidarLowDistance.TabIndex = 25;
            this.textBoxLidarLowDistance.Text = "2000";
            this.textBoxLidarLowDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(1182, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 289);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port Settings";
            // 
            // buttonRPLidarStopID
            // 
            this.buttonRPLidarStopID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonRPLidarStopID.Location = new System.Drawing.Point(140, 224);
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
            this.buttonRPLidarScanID.Location = new System.Drawing.Point(6, 224);
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
            this.labelSerialPortInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSerialPortInfo.Location = new System.Drawing.Point(6, 50);
            this.labelSerialPortInfo.Name = "labelSerialPortInfo";
            this.labelSerialPortInfo.Size = new System.Drawing.Size(113, 16);
            this.labelSerialPortInfo.TabIndex = 11;
            this.labelSerialPortInfo.Text = "Serial Port Info:";
            // 
            // textBoxSeriPortDataReceive
            // 
            this.textBoxSeriPortDataReceive.Location = new System.Drawing.Point(6, 68);
            this.textBoxSeriPortDataReceive.Multiline = true;
            this.textBoxSeriPortDataReceive.Name = "textBoxSeriPortDataReceive";
            this.textBoxSeriPortDataReceive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSeriPortDataReceive.Size = new System.Drawing.Size(480, 150);
            this.textBoxSeriPortDataReceive.TabIndex = 38;
            // 
            // buttonSeriPortCon
            // 
            this.buttonSeriPortCon.Location = new System.Drawing.Point(260, 13);
            this.buttonSeriPortCon.Name = "buttonSeriPortCon";
            this.buttonSeriPortCon.Size = new System.Drawing.Size(125, 23);
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
            // groupBoxLidarViewer
            // 
            this.groupBoxLidarViewer.Controls.Add(this.panelSpeedStatus);
            this.groupBoxLidarViewer.Controls.Add(this.groupBoxZoneSettings_2);
            this.groupBoxLidarViewer.Controls.Add(this.groupBoxZoneSettings);
            this.groupBoxLidarViewer.Controls.Add(this.groupBoxDataSettings);
            this.groupBoxLidarViewer.Controls.Add(this.pictureBoxRPLidarDataViewer);
            this.groupBoxLidarViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxLidarViewer.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLidarViewer.Name = "groupBoxLidarViewer";
            this.groupBoxLidarViewer.Size = new System.Drawing.Size(1150, 920);
            this.groupBoxLidarViewer.TabIndex = 38;
            this.groupBoxLidarViewer.TabStop = false;
            this.groupBoxLidarViewer.Text = "Lidar Data Viewer";
            // 
            // panelSpeedStatus
            // 
            this.panelSpeedStatus.BackColor = System.Drawing.Color.White;
            this.panelSpeedStatus.Location = new System.Drawing.Point(980, 434);
            this.panelSpeedStatus.Name = "panelSpeedStatus";
            this.panelSpeedStatus.Size = new System.Drawing.Size(100, 50);
            this.panelSpeedStatus.TabIndex = 42;
            // 
            // groupBoxZoneSettings_2
            // 
            this.groupBoxZoneSettings_2.Controls.Add(this.numericUpDownLidarMidZoneWidthOffset);
            this.groupBoxZoneSettings_2.Controls.Add(this.numericUpDownLidarMidZoneWidth);
            this.groupBoxZoneSettings_2.Controls.Add(this.numericUpDownLidarMidZoneHeightOffset);
            this.groupBoxZoneSettings_2.Controls.Add(this.numericUpDownLidarMidZoneHeight);
            this.groupBoxZoneSettings_2.Controls.Add(this.labelMidZoneHeight);
            this.groupBoxZoneSettings_2.Controls.Add(this.labelMidZoneWidth_mm);
            this.groupBoxZoneSettings_2.Controls.Add(this.labelMidZoneHeightOffset);
            this.groupBoxZoneSettings_2.Controls.Add(this.labelMidZoneWidth);
            this.groupBoxZoneSettings_2.Controls.Add(this.labelMidZoneHeightOffse_mm);
            this.groupBoxZoneSettings_2.Controls.Add(this.labelMidZoneWidthOffset_mm);
            this.groupBoxZoneSettings_2.Controls.Add(this.labelMidZoneHeight_mm);
            this.groupBoxZoneSettings_2.Controls.Add(this.labelMidZoneWidthOffset);
            this.groupBoxZoneSettings_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxZoneSettings_2.Location = new System.Drawing.Point(915, 263);
            this.groupBoxZoneSettings_2.Name = "groupBoxZoneSettings_2";
            this.groupBoxZoneSettings_2.Size = new System.Drawing.Size(229, 119);
            this.groupBoxZoneSettings_2.TabIndex = 40;
            this.groupBoxZoneSettings_2.TabStop = false;
            this.groupBoxZoneSettings_2.Text = "Mid Zone Settings";
            // 
            // numericUpDownLidarMidZoneWidthOffset
            // 
            this.numericUpDownLidarMidZoneWidthOffset.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLidarMidZoneWidthOffset.Location = new System.Drawing.Point(129, 94);
            this.numericUpDownLidarMidZoneWidthOffset.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numericUpDownLidarMidZoneWidthOffset.Minimum = new decimal(new int[] {
            6000,
            0,
            0,
            -2147483648});
            this.numericUpDownLidarMidZoneWidthOffset.Name = "numericUpDownLidarMidZoneWidthOffset";
            this.numericUpDownLidarMidZoneWidthOffset.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownLidarMidZoneWidthOffset.TabIndex = 42;
            // 
            // numericUpDownLidarMidZoneWidth
            // 
            this.numericUpDownLidarMidZoneWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLidarMidZoneWidth.Location = new System.Drawing.Point(129, 68);
            this.numericUpDownLidarMidZoneWidth.Maximum = new decimal(new int[] {
            12000,
            0,
            0,
            0});
            this.numericUpDownLidarMidZoneWidth.Name = "numericUpDownLidarMidZoneWidth";
            this.numericUpDownLidarMidZoneWidth.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownLidarMidZoneWidth.TabIndex = 41;
            this.numericUpDownLidarMidZoneWidth.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numericUpDownLidarMidZoneHeightOffset
            // 
            this.numericUpDownLidarMidZoneHeightOffset.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLidarMidZoneHeightOffset.Location = new System.Drawing.Point(129, 42);
            this.numericUpDownLidarMidZoneHeightOffset.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numericUpDownLidarMidZoneHeightOffset.Minimum = new decimal(new int[] {
            6000,
            0,
            0,
            -2147483648});
            this.numericUpDownLidarMidZoneHeightOffset.Name = "numericUpDownLidarMidZoneHeightOffset";
            this.numericUpDownLidarMidZoneHeightOffset.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownLidarMidZoneHeightOffset.TabIndex = 40;
            this.numericUpDownLidarMidZoneHeightOffset.Value = new decimal(new int[] {
            1250,
            0,
            0,
            0});
            // 
            // numericUpDownLidarMidZoneHeight
            // 
            this.numericUpDownLidarMidZoneHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLidarMidZoneHeight.Location = new System.Drawing.Point(129, 16);
            this.numericUpDownLidarMidZoneHeight.Maximum = new decimal(new int[] {
            12000,
            0,
            0,
            0});
            this.numericUpDownLidarMidZoneHeight.Name = "numericUpDownLidarMidZoneHeight";
            this.numericUpDownLidarMidZoneHeight.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownLidarMidZoneHeight.TabIndex = 39;
            this.numericUpDownLidarMidZoneHeight.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // labelMidZoneHeight
            // 
            this.labelMidZoneHeight.AutoSize = true;
            this.labelMidZoneHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMidZoneHeight.Location = new System.Drawing.Point(43, 17);
            this.labelMidZoneHeight.Name = "labelMidZoneHeight";
            this.labelMidZoneHeight.Size = new System.Drawing.Size(80, 16);
            this.labelMidZoneHeight.TabIndex = 23;
            this.labelMidZoneHeight.Text = "Zone Height";
            // 
            // labelMidZoneWidth_mm
            // 
            this.labelMidZoneWidth_mm.AutoSize = true;
            this.labelMidZoneWidth_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMidZoneWidth_mm.Location = new System.Drawing.Point(195, 69);
            this.labelMidZoneWidth_mm.Name = "labelMidZoneWidth_mm";
            this.labelMidZoneWidth_mm.Size = new System.Drawing.Size(29, 16);
            this.labelMidZoneWidth_mm.TabIndex = 36;
            this.labelMidZoneWidth_mm.Text = "mm";
            // 
            // labelMidZoneHeightOffset
            // 
            this.labelMidZoneHeightOffset.AutoSize = true;
            this.labelMidZoneHeightOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMidZoneHeightOffset.Location = new System.Drawing.Point(6, 43);
            this.labelMidZoneHeightOffset.Name = "labelMidZoneHeightOffset";
            this.labelMidZoneHeightOffset.Size = new System.Drawing.Size(117, 16);
            this.labelMidZoneHeightOffset.TabIndex = 20;
            this.labelMidZoneHeightOffset.Text = "Zone Height Offset";
            // 
            // labelMidZoneWidth
            // 
            this.labelMidZoneWidth.AutoSize = true;
            this.labelMidZoneWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMidZoneWidth.Location = new System.Drawing.Point(48, 69);
            this.labelMidZoneWidth.Name = "labelMidZoneWidth";
            this.labelMidZoneWidth.Size = new System.Drawing.Size(75, 16);
            this.labelMidZoneWidth.TabIndex = 35;
            this.labelMidZoneWidth.Text = "Zone Width";
            // 
            // labelMidZoneHeightOffse_mm
            // 
            this.labelMidZoneHeightOffse_mm.AutoSize = true;
            this.labelMidZoneHeightOffse_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMidZoneHeightOffse_mm.Location = new System.Drawing.Point(195, 43);
            this.labelMidZoneHeightOffse_mm.Name = "labelMidZoneHeightOffse_mm";
            this.labelMidZoneHeightOffse_mm.Size = new System.Drawing.Size(29, 16);
            this.labelMidZoneHeightOffse_mm.TabIndex = 21;
            this.labelMidZoneHeightOffse_mm.Text = "mm";
            // 
            // labelMidZoneWidthOffset_mm
            // 
            this.labelMidZoneWidthOffset_mm.AutoSize = true;
            this.labelMidZoneWidthOffset_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMidZoneWidthOffset_mm.Location = new System.Drawing.Point(195, 95);
            this.labelMidZoneWidthOffset_mm.Name = "labelMidZoneWidthOffset_mm";
            this.labelMidZoneWidthOffset_mm.Size = new System.Drawing.Size(29, 16);
            this.labelMidZoneWidthOffset_mm.TabIndex = 33;
            this.labelMidZoneWidthOffset_mm.Text = "mm";
            // 
            // labelMidZoneHeight_mm
            // 
            this.labelMidZoneHeight_mm.AutoSize = true;
            this.labelMidZoneHeight_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMidZoneHeight_mm.Location = new System.Drawing.Point(195, 17);
            this.labelMidZoneHeight_mm.Name = "labelMidZoneHeight_mm";
            this.labelMidZoneHeight_mm.Size = new System.Drawing.Size(29, 16);
            this.labelMidZoneHeight_mm.TabIndex = 24;
            this.labelMidZoneHeight_mm.Text = "mm";
            // 
            // labelMidZoneWidthOffset
            // 
            this.labelMidZoneWidthOffset.AutoSize = true;
            this.labelMidZoneWidthOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMidZoneWidthOffset.Location = new System.Drawing.Point(11, 95);
            this.labelMidZoneWidthOffset.Name = "labelMidZoneWidthOffset";
            this.labelMidZoneWidthOffset.Size = new System.Drawing.Size(112, 16);
            this.labelMidZoneWidthOffset.TabIndex = 32;
            this.labelMidZoneWidthOffset.Text = "Zone Width Offset";
            // 
            // groupBoxZoneSettings
            // 
            this.groupBoxZoneSettings.Controls.Add(this.numericUpDownLidarLowZoneWidthOffset);
            this.groupBoxZoneSettings.Controls.Add(this.numericUpDownLidarLowZoneWidth);
            this.groupBoxZoneSettings.Controls.Add(this.numericUpDownLidarLowZoneHeightOffset);
            this.groupBoxZoneSettings.Controls.Add(this.numericUpDownLidarLowZoneHeight);
            this.groupBoxZoneSettings.Controls.Add(this.labelLowZoneHeight);
            this.groupBoxZoneSettings.Controls.Add(this.labelLowZoneWidth_mm);
            this.groupBoxZoneSettings.Controls.Add(this.labelLowZoneHeightOffset);
            this.groupBoxZoneSettings.Controls.Add(this.labelLowZoneWidth);
            this.groupBoxZoneSettings.Controls.Add(this.labelLowZoneHeightOffse_mm);
            this.groupBoxZoneSettings.Controls.Add(this.labelLowZoneWidthOffset_mm);
            this.groupBoxZoneSettings.Controls.Add(this.labelLowZoneHeight_mm);
            this.groupBoxZoneSettings.Controls.Add(this.labelLowZoneWidthOffset);
            this.groupBoxZoneSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxZoneSettings.Location = new System.Drawing.Point(915, 138);
            this.groupBoxZoneSettings.Name = "groupBoxZoneSettings";
            this.groupBoxZoneSettings.Size = new System.Drawing.Size(229, 119);
            this.groupBoxZoneSettings.TabIndex = 39;
            this.groupBoxZoneSettings.TabStop = false;
            this.groupBoxZoneSettings.Text = "Low Zone Settings";
            // 
            // numericUpDownLidarLowZoneWidthOffset
            // 
            this.numericUpDownLidarLowZoneWidthOffset.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLidarLowZoneWidthOffset.Location = new System.Drawing.Point(129, 94);
            this.numericUpDownLidarLowZoneWidthOffset.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numericUpDownLidarLowZoneWidthOffset.Minimum = new decimal(new int[] {
            6000,
            0,
            0,
            -2147483648});
            this.numericUpDownLidarLowZoneWidthOffset.Name = "numericUpDownLidarLowZoneWidthOffset";
            this.numericUpDownLidarLowZoneWidthOffset.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownLidarLowZoneWidthOffset.TabIndex = 42;
            // 
            // numericUpDownLidarLowZoneWidth
            // 
            this.numericUpDownLidarLowZoneWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLidarLowZoneWidth.Location = new System.Drawing.Point(129, 68);
            this.numericUpDownLidarLowZoneWidth.Maximum = new decimal(new int[] {
            12000,
            0,
            0,
            0});
            this.numericUpDownLidarLowZoneWidth.Name = "numericUpDownLidarLowZoneWidth";
            this.numericUpDownLidarLowZoneWidth.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownLidarLowZoneWidth.TabIndex = 41;
            this.numericUpDownLidarLowZoneWidth.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numericUpDownLidarLowZoneHeightOffset
            // 
            this.numericUpDownLidarLowZoneHeightOffset.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLidarLowZoneHeightOffset.Location = new System.Drawing.Point(129, 42);
            this.numericUpDownLidarLowZoneHeightOffset.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numericUpDownLidarLowZoneHeightOffset.Minimum = new decimal(new int[] {
            6000,
            0,
            0,
            -2147483648});
            this.numericUpDownLidarLowZoneHeightOffset.Name = "numericUpDownLidarLowZoneHeightOffset";
            this.numericUpDownLidarLowZoneHeightOffset.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownLidarLowZoneHeightOffset.TabIndex = 40;
            this.numericUpDownLidarLowZoneHeightOffset.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericUpDownLidarLowZoneHeight
            // 
            this.numericUpDownLidarLowZoneHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLidarLowZoneHeight.Location = new System.Drawing.Point(129, 16);
            this.numericUpDownLidarLowZoneHeight.Maximum = new decimal(new int[] {
            12000,
            0,
            0,
            0});
            this.numericUpDownLidarLowZoneHeight.Name = "numericUpDownLidarLowZoneHeight";
            this.numericUpDownLidarLowZoneHeight.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownLidarLowZoneHeight.TabIndex = 39;
            this.numericUpDownLidarLowZoneHeight.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // labelLowZoneHeight
            // 
            this.labelLowZoneHeight.AutoSize = true;
            this.labelLowZoneHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLowZoneHeight.Location = new System.Drawing.Point(43, 17);
            this.labelLowZoneHeight.Name = "labelLowZoneHeight";
            this.labelLowZoneHeight.Size = new System.Drawing.Size(80, 16);
            this.labelLowZoneHeight.TabIndex = 23;
            this.labelLowZoneHeight.Text = "Zone Height";
            // 
            // labelLowZoneWidth_mm
            // 
            this.labelLowZoneWidth_mm.AutoSize = true;
            this.labelLowZoneWidth_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLowZoneWidth_mm.Location = new System.Drawing.Point(195, 69);
            this.labelLowZoneWidth_mm.Name = "labelLowZoneWidth_mm";
            this.labelLowZoneWidth_mm.Size = new System.Drawing.Size(29, 16);
            this.labelLowZoneWidth_mm.TabIndex = 36;
            this.labelLowZoneWidth_mm.Text = "mm";
            // 
            // labelLowZoneHeightOffset
            // 
            this.labelLowZoneHeightOffset.AutoSize = true;
            this.labelLowZoneHeightOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLowZoneHeightOffset.Location = new System.Drawing.Point(6, 43);
            this.labelLowZoneHeightOffset.Name = "labelLowZoneHeightOffset";
            this.labelLowZoneHeightOffset.Size = new System.Drawing.Size(117, 16);
            this.labelLowZoneHeightOffset.TabIndex = 20;
            this.labelLowZoneHeightOffset.Text = "Zone Height Offset";
            // 
            // labelLowZoneWidth
            // 
            this.labelLowZoneWidth.AutoSize = true;
            this.labelLowZoneWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLowZoneWidth.Location = new System.Drawing.Point(48, 69);
            this.labelLowZoneWidth.Name = "labelLowZoneWidth";
            this.labelLowZoneWidth.Size = new System.Drawing.Size(75, 16);
            this.labelLowZoneWidth.TabIndex = 35;
            this.labelLowZoneWidth.Text = "Zone Width";
            // 
            // labelLowZoneHeightOffse_mm
            // 
            this.labelLowZoneHeightOffse_mm.AutoSize = true;
            this.labelLowZoneHeightOffse_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLowZoneHeightOffse_mm.Location = new System.Drawing.Point(195, 43);
            this.labelLowZoneHeightOffse_mm.Name = "labelLowZoneHeightOffse_mm";
            this.labelLowZoneHeightOffse_mm.Size = new System.Drawing.Size(29, 16);
            this.labelLowZoneHeightOffse_mm.TabIndex = 21;
            this.labelLowZoneHeightOffse_mm.Text = "mm";
            // 
            // labelLowZoneWidthOffset_mm
            // 
            this.labelLowZoneWidthOffset_mm.AutoSize = true;
            this.labelLowZoneWidthOffset_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLowZoneWidthOffset_mm.Location = new System.Drawing.Point(195, 95);
            this.labelLowZoneWidthOffset_mm.Name = "labelLowZoneWidthOffset_mm";
            this.labelLowZoneWidthOffset_mm.Size = new System.Drawing.Size(29, 16);
            this.labelLowZoneWidthOffset_mm.TabIndex = 33;
            this.labelLowZoneWidthOffset_mm.Text = "mm";
            // 
            // labelLowZoneHeight_mm
            // 
            this.labelLowZoneHeight_mm.AutoSize = true;
            this.labelLowZoneHeight_mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLowZoneHeight_mm.Location = new System.Drawing.Point(195, 17);
            this.labelLowZoneHeight_mm.Name = "labelLowZoneHeight_mm";
            this.labelLowZoneHeight_mm.Size = new System.Drawing.Size(29, 16);
            this.labelLowZoneHeight_mm.TabIndex = 24;
            this.labelLowZoneHeight_mm.Text = "mm";
            // 
            // labelLowZoneWidthOffset
            // 
            this.labelLowZoneWidthOffset.AutoSize = true;
            this.labelLowZoneWidthOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLowZoneWidthOffset.Location = new System.Drawing.Point(11, 95);
            this.labelLowZoneWidthOffset.Name = "labelLowZoneWidthOffset";
            this.labelLowZoneWidthOffset.Size = new System.Drawing.Size(112, 16);
            this.labelLowZoneWidthOffset.TabIndex = 32;
            this.labelLowZoneWidthOffset.Text = "Zone Width Offset";
            // 
            // groupBoxDataSettings
            // 
            this.groupBoxDataSettings.Controls.Add(this.labelViewDistance);
            this.groupBoxDataSettings.Controls.Add(this.labelDataQuality);
            this.groupBoxDataSettings.Controls.Add(this.textBoxViewLidarDistance);
            this.groupBoxDataSettings.Controls.Add(this.labelMidDistance_mm);
            this.groupBoxDataSettings.Controls.Add(this.textBoxViewDataQuality);
            this.groupBoxDataSettings.Controls.Add(this.labelMidDistance);
            this.groupBoxDataSettings.Controls.Add(this.labelViewDistance_mm);
            this.groupBoxDataSettings.Controls.Add(this.textBoxLidarMidDistance);
            this.groupBoxDataSettings.Controls.Add(this.textBoxLidarLowDistance);
            this.groupBoxDataSettings.Controls.Add(this.labelLowDistance_mm);
            this.groupBoxDataSettings.Controls.Add(this.labelLowDistance);
            this.groupBoxDataSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxDataSettings.Location = new System.Drawing.Point(915, 13);
            this.groupBoxDataSettings.Name = "groupBoxDataSettings";
            this.groupBoxDataSettings.Size = new System.Drawing.Size(228, 119);
            this.groupBoxDataSettings.TabIndex = 38;
            this.groupBoxDataSettings.TabStop = false;
            this.groupBoxDataSettings.Text = "Data Settings";
            // 
            // groupBoxLidarDatas
            // 
            this.groupBoxLidarDatas.Controls.Add(this.label1);
            this.groupBoxLidarDatas.Controls.Add(this.textBoxDataQualityThreshold);
            this.groupBoxLidarDatas.Controls.Add(this.buttonOpenFile);
            this.groupBoxLidarDatas.Controls.Add(this.textBoxOpenFile);
            this.groupBoxLidarDatas.Controls.Add(this.labelLidarDataQuality);
            this.groupBoxLidarDatas.Controls.Add(this.listBoxRPLidarDataQuality);
            this.groupBoxLidarDatas.Controls.Add(this.labelLİdarDataStartBits);
            this.groupBoxLidarDatas.Controls.Add(this.listBoxRPLidarStartBits);
            this.groupBoxLidarDatas.Controls.Add(this.labelLidarData);
            this.groupBoxLidarDatas.Controls.Add(this.listBoxRPLidarData);
            this.groupBoxLidarDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxLidarDatas.Location = new System.Drawing.Point(1182, 311);
            this.groupBoxLidarDatas.Name = "groupBoxLidarDatas";
            this.groupBoxLidarDatas.Size = new System.Drawing.Size(490, 621);
            this.groupBoxLidarDatas.TabIndex = 39;
            this.groupBoxLidarDatas.TabStop = false;
            this.groupBoxLidarDatas.Text = "Lidar Datas";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 941);
            this.Controls.Add(this.groupBoxLidarDatas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxLidarViewer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRPLidarDataViewer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxLidarViewer.ResumeLayout(false);
            this.groupBoxZoneSettings_2.ResumeLayout(false);
            this.groupBoxZoneSettings_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarMidZoneWidthOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarMidZoneWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarMidZoneHeightOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarMidZoneHeight)).EndInit();
            this.groupBoxZoneSettings.ResumeLayout(false);
            this.groupBoxZoneSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarLowZoneWidthOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarLowZoneWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarLowZoneHeightOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLidarLowZoneHeight)).EndInit();
            this.groupBoxDataSettings.ResumeLayout(false);
            this.groupBoxDataSettings.PerformLayout();
            this.groupBoxLidarDatas.ResumeLayout(false);
            this.groupBoxLidarDatas.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label labelDataQuality;
        private System.Windows.Forms.Label labelViewDistance;
        private System.Windows.Forms.TextBox textBoxViewLidarDistance;
        private System.Windows.Forms.TextBox textBoxViewDataQuality;
        private System.Windows.Forms.Label labelViewDistance_mm;
        private System.Windows.Forms.Label labelMidDistance_mm;
        private System.Windows.Forms.Label labelMidDistance;
        private System.Windows.Forms.TextBox textBoxLidarMidDistance;
        private System.Windows.Forms.Label labelLowDistance_mm;
        private System.Windows.Forms.Label labelLowDistance;
        private System.Windows.Forms.TextBox textBoxLidarLowDistance;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelSeriPortName;
        private System.Windows.Forms.Label labelSerialPortInfo;
        private System.Windows.Forms.Button buttonSeriPortCon;
        private System.Windows.Forms.ComboBox comboBoxSeriPortList;
        private System.Windows.Forms.Button buttonRPLidarStopID;
        private System.Windows.Forms.Button buttonRPLidarScanID;
        private System.Windows.Forms.TextBox textBoxSeriPortDataReceive;
        private System.Windows.Forms.GroupBox groupBoxLidarViewer;
        private System.Windows.Forms.GroupBox groupBoxLidarDatas;
        private System.Windows.Forms.GroupBox groupBoxDataSettings;
        private System.Windows.Forms.GroupBox groupBoxZoneSettings;
        private System.Windows.Forms.NumericUpDown numericUpDownLidarLowZoneWidthOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownLidarLowZoneWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownLidarLowZoneHeightOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownLidarLowZoneHeight;
        private System.Windows.Forms.Label labelLowZoneHeight;
        private System.Windows.Forms.Label labelLowZoneWidth_mm;
        private System.Windows.Forms.Label labelLowZoneHeightOffset;
        private System.Windows.Forms.Label labelLowZoneWidth;
        private System.Windows.Forms.Label labelLowZoneHeightOffse_mm;
        private System.Windows.Forms.Label labelLowZoneWidthOffset_mm;
        private System.Windows.Forms.Label labelLowZoneHeight_mm;
        private System.Windows.Forms.Label labelLowZoneWidthOffset;
        private System.Windows.Forms.GroupBox groupBoxZoneSettings_2;
        private System.Windows.Forms.NumericUpDown numericUpDownLidarMidZoneWidthOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownLidarMidZoneWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownLidarMidZoneHeightOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownLidarMidZoneHeight;
        private System.Windows.Forms.Label labelMidZoneHeight;
        private System.Windows.Forms.Label labelMidZoneWidth_mm;
        private System.Windows.Forms.Label labelMidZoneHeightOffset;
        private System.Windows.Forms.Label labelMidZoneWidth;
        private System.Windows.Forms.Label labelMidZoneHeightOffse_mm;
        private System.Windows.Forms.Label labelMidZoneWidthOffset_mm;
        private System.Windows.Forms.Label labelMidZoneHeight_mm;
        private System.Windows.Forms.Label labelMidZoneWidthOffset;
        private System.Windows.Forms.Panel panelSpeedStatus;
        private System.Windows.Forms.Timer timer1;
    }
}

