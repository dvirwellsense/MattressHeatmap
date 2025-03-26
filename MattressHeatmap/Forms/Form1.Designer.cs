namespace MattressHeatmap
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
            this.btnGenerateHeatMap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackDensity = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.numPressurePoints = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCoef3 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCoef2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCoef1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCoef0 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.checkManualLut = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkSmoothImage = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnStream = new System.Windows.Forms.Button();
            this.txtRawSerialData = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.timerDebug = new System.Windows.Forms.Timer(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.btnConnectWithBluetooth = new System.Windows.Forms.Button();
            this.panelManualLut = new System.Windows.Forms.Panel();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCaps = new System.Windows.Forms.Label();
            this.lblPressures = new System.Windows.Forms.Label();
            this.lblMatId = new System.Windows.Forms.Label();
            this.btnDevelopment = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.timerInitialConnection = new System.Windows.Forms.Timer(this.components);
            this.btnRefreshComboPorts = new System.Windows.Forms.Button();
            this.timerSerialConnection = new System.Windows.Forms.Timer(this.components);
            this.timerDisconnectedDelay = new System.Windows.Forms.Timer(this.components);
            this.btnSetOffset = new System.Windows.Forms.Button();
            this.btnCancelOffset = new System.Windows.Forms.Button();
            this.btnSample = new System.Windows.Forms.Button();
            this.timerSampling = new System.Windows.Forms.Timer(this.components);
            this.lblBufferSize = new System.Windows.Forms.Label();
            this.lblRowsCount = new System.Windows.Forms.Label();
            this.lblDataQueueSiize = new System.Windows.Forms.Label();
            this.panelColorRanges = new System.Windows.Forms.Panel();
            this.ucColorRangesPressures = new MattressHeatmap.ucColorRanges();
            this.ucColorRangesCaps = new MattressHeatmap.ucColorRanges();
            this.label22 = new System.Windows.Forms.Label();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.btnToggleBlur = new System.Windows.Forms.Button();
            this.checkTau = new System.Windows.Forms.CheckBox();
            this.numTau = new System.Windows.Forms.NumericUpDown();
            this.ucHeatMapMain = new MattressHeatmap.ucHeatMap();
            this.Status_text = new System.Windows.Forms.TextBox();
            this.Frame_text = new System.Windows.Forms.TextBox();
            this.MatNum_text = new System.Windows.Forms.TextBox();
            this.LifeTime_text = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.Label();
            this.Frame = new System.Windows.Forms.Label();
            this.MatNum = new System.Windows.Forms.Label();
            this.LifeTime = new System.Windows.Forms.Label();
            this.Temp_text = new System.Windows.Forms.TextBox();
            this.Humidity_text = new System.Windows.Forms.TextBox();
            this.Row_text = new System.Windows.Forms.TextBox();
            this.Columns_text = new System.Windows.Forms.TextBox();
            this.Temp = new System.Windows.Forms.Label();
            this.Humidity = new System.Windows.Forms.Label();
            this.Rows = new System.Windows.Forms.Label();
            this.Columns = new System.Windows.Forms.Label();
            this.FW_Version_text = new System.Windows.Forms.TextBox();
            this.FW_Version = new System.Windows.Forms.Label();
            this.SendText = new System.Windows.Forms.Button();
            this.SendBox = new System.Windows.Forms.TextBox();
            this.Version = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPressurePoints)).BeginInit();
            this.panelManualLut.SuspendLayout();
            this.panelColorRanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTau)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateHeatMap
            // 
            this.btnGenerateHeatMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnGenerateHeatMap.Location = new System.Drawing.Point(20, 882);
            this.btnGenerateHeatMap.Name = "btnGenerateHeatMap";
            this.btnGenerateHeatMap.Size = new System.Drawing.Size(504, 50);
            this.btnGenerateHeatMap.TabIndex = 4;
            this.btnGenerateHeatMap.Text = "Generate New";
            this.btnGenerateHeatMap.UseVisualStyleBackColor = true;
            this.btnGenerateHeatMap.Visible = false;
            this.btnGenerateHeatMap.Click += new System.EventHandler(this.btnGenerateHeatMap_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numHeight);
            this.panel1.Controls.Add(this.numWidth);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.trackDensity);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numPressurePoints);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(836, 889);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 412);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // numHeight
            // 
            this.numHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numHeight.Location = new System.Drawing.Point(124, 143);
            this.numHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(90, 28);
            this.numHeight.TabIndex = 9;
            this.numHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.numsSize_ValueChanged);
            // 
            // numWidth
            // 
            this.numWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numWidth.Location = new System.Drawing.Point(124, 109);
            this.numWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(90, 28);
            this.numWidth.TabIndex = 8;
            this.numWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.numsSize_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(49, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Height:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(49, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Width:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(22, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "■ Size:";
            // 
            // trackDensity
            // 
            this.trackDensity.Location = new System.Drawing.Point(49, 356);
            this.trackDensity.Maximum = 7;
            this.trackDensity.Minimum = -7;
            this.trackDensity.Name = "trackDensity";
            this.trackDensity.Size = new System.Drawing.Size(241, 56);
            this.trackDensity.TabIndex = 4;
            this.trackDensity.Scroll += new System.EventHandler(this.trackDensity_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(22, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "■ Density:";
            // 
            // numPressurePoints
            // 
            this.numPressurePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numPressurePoints.Location = new System.Drawing.Point(97, 249);
            this.numPressurePoints.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numPressurePoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPressurePoints.Name = "numPressurePoints";
            this.numPressurePoints.Size = new System.Drawing.Size(84, 30);
            this.numPressurePoints.TabIndex = 2;
            this.numPressurePoints.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numPressurePoints.ValueChanged += new System.EventHandler(this.numPressurePoints_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(22, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "■ Number of Pressure Points:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(48, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Generation";
            // 
            // txtCoef3
            // 
            this.txtCoef3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCoef3.Location = new System.Drawing.Point(318, 40);
            this.txtCoef3.Name = "txtCoef3";
            this.txtCoef3.Size = new System.Drawing.Size(134, 27);
            this.txtCoef3.TabIndex = 24;
            this.txtCoef3.TextChanged += new System.EventHandler(this.txtCoef3_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label18.Location = new System.Drawing.Point(236, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 25);
            this.label18.TabIndex = 23;
            this.label18.Text = "Coef 3:";
            // 
            // txtCoef2
            // 
            this.txtCoef2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCoef2.Location = new System.Drawing.Point(86, 43);
            this.txtCoef2.Name = "txtCoef2";
            this.txtCoef2.Size = new System.Drawing.Size(134, 27);
            this.txtCoef2.TabIndex = 22;
            this.txtCoef2.TextChanged += new System.EventHandler(this.txtCoef2_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label17.Location = new System.Drawing.Point(4, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 25);
            this.label17.TabIndex = 21;
            this.label17.Text = "Coef 2:";
            // 
            // txtCoef1
            // 
            this.txtCoef1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCoef1.Location = new System.Drawing.Point(316, 3);
            this.txtCoef1.Name = "txtCoef1";
            this.txtCoef1.Size = new System.Drawing.Size(134, 27);
            this.txtCoef1.TabIndex = 20;
            this.txtCoef1.TextChanged += new System.EventHandler(this.txtCoef1_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label16.Location = new System.Drawing.Point(234, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 25);
            this.label16.TabIndex = 19;
            this.label16.Text = "Coef 1:";
            // 
            // txtCoef0
            // 
            this.txtCoef0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCoef0.Location = new System.Drawing.Point(86, 3);
            this.txtCoef0.Name = "txtCoef0";
            this.txtCoef0.Size = new System.Drawing.Size(134, 27);
            this.txtCoef0.TabIndex = 18;
            this.txtCoef0.TextChanged += new System.EventHandler(this.txtCoef0_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label15.Location = new System.Drawing.Point(4, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 25);
            this.label15.TabIndex = 17;
            this.label15.Text = "Coef 0:";
            // 
            // checkManualLut
            // 
            this.checkManualLut.AutoSize = true;
            this.checkManualLut.Checked = true;
            this.checkManualLut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkManualLut.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkManualLut.Location = new System.Drawing.Point(352, 130);
            this.checkManualLut.Name = "checkManualLut";
            this.checkManualLut.Size = new System.Drawing.Size(18, 17);
            this.checkManualLut.TabIndex = 16;
            this.checkManualLut.UseVisualStyleBackColor = true;
            this.checkManualLut.CheckedChanged += new System.EventHandler(this.checkManualLut_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.Location = new System.Drawing.Point(213, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 25);
            this.label13.TabIndex = 15;
            this.label13.Text = "■ Manual Lut:";
            // 
            // checkSmoothImage
            // 
            this.checkSmoothImage.AutoSize = true;
            this.checkSmoothImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkSmoothImage.Location = new System.Drawing.Point(181, 132);
            this.checkSmoothImage.Name = "checkSmoothImage";
            this.checkSmoothImage.Size = new System.Drawing.Size(18, 17);
            this.checkSmoothImage.TabIndex = 14;
            this.checkSmoothImage.UseVisualStyleBackColor = true;
            this.checkSmoothImage.CheckedChanged += new System.EventHandler(this.checkSmoothImage_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(12, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 25);
            this.label10.TabIndex = 13;
            this.label10.Text = "■ Smooth Image:";
            // 
            // btnStream
            // 
            this.btnStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnStream.Location = new System.Drawing.Point(231, 12);
            this.btnStream.Name = "btnStream";
            this.btnStream.Size = new System.Drawing.Size(213, 50);
            this.btnStream.TabIndex = 15;
            this.btnStream.Text = "Connect With Serial";
            this.btnStream.UseVisualStyleBackColor = true;
            this.btnStream.Visible = false;
            this.btnStream.Click += new System.EventHandler(this.btnStream_Click);
            // 
            // txtRawSerialData
            // 
            this.txtRawSerialData.Location = new System.Drawing.Point(-73, 885);
            this.txtRawSerialData.Multiline = true;
            this.txtRawSerialData.Name = "txtRawSerialData";
            this.txtRawSerialData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRawSerialData.Size = new System.Drawing.Size(454, 284);
            this.txtRawSerialData.TabIndex = 17;
            this.txtRawSerialData.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(665, 325);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 24);
            this.label11.TabIndex = 18;
            this.label11.Text = "Buffer Size:";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(665, 362);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 24);
            this.label12.TabIndex = 19;
            this.label12.Text = "Rows Count:";
            this.label12.Visible = false;
            // 
            // timerDebug
            // 
            this.timerDebug.Tick += new System.EventHandler(this.timerDebug_Tick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label14.Location = new System.Drawing.Point(665, 287);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 24);
            this.label14.TabIndex = 22;
            this.label14.Text = "Data Queue:";
            this.label14.Visible = false;
            // 
            // btnConnectWithBluetooth
            // 
            this.btnConnectWithBluetooth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnConnectWithBluetooth.Location = new System.Drawing.Point(12, 12);
            this.btnConnectWithBluetooth.Name = "btnConnectWithBluetooth";
            this.btnConnectWithBluetooth.Size = new System.Drawing.Size(213, 50);
            this.btnConnectWithBluetooth.TabIndex = 32;
            this.btnConnectWithBluetooth.Text = "Connect With Bluetooth";
            this.btnConnectWithBluetooth.UseVisualStyleBackColor = true;
            this.btnConnectWithBluetooth.Visible = false;
            this.btnConnectWithBluetooth.Click += new System.EventHandler(this.btnConnectWithBluetooth_Click);
            // 
            // panelManualLut
            // 
            this.panelManualLut.Controls.Add(this.txtCoef3);
            this.panelManualLut.Controls.Add(this.label18);
            this.panelManualLut.Controls.Add(this.txtCoef2);
            this.panelManualLut.Controls.Add(this.label17);
            this.panelManualLut.Controls.Add(this.txtCoef1);
            this.panelManualLut.Controls.Add(this.label16);
            this.panelManualLut.Controls.Add(this.txtCoef0);
            this.panelManualLut.Controls.Add(this.label15);
            this.panelManualLut.Location = new System.Drawing.Point(376, 103);
            this.panelManualLut.Name = "panelManualLut";
            this.panelManualLut.Size = new System.Drawing.Size(467, 74);
            this.panelManualLut.TabIndex = 34;
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblConnectionType.ForeColor = System.Drawing.Color.Green;
            this.lblConnectionType.Location = new System.Drawing.Point(692, 12);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(134, 50);
            this.lblConnectionType.TabIndex = 35;
            this.lblConnectionType.Text = "Connected to Bluetooth";
            this.lblConnectionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnDisconnect.Location = new System.Drawing.Point(270, 68);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(130, 29);
            this.btnDisconnect.TabIndex = 36;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(524, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 24);
            this.label7.TabIndex = 37;
            this.label7.Text = "Com port:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(522, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(2, 26);
            this.label8.TabIndex = 38;
            // 
            // lblCaps
            // 
            this.lblCaps.AutoSize = true;
            this.lblCaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCaps.Location = new System.Drawing.Point(55, 195);
            this.lblCaps.Name = "lblCaps";
            this.lblCaps.Size = new System.Drawing.Size(59, 25);
            this.lblCaps.TabIndex = 39;
            this.lblCaps.Text = "Caps";
            // 
            // lblPressures
            // 
            this.lblPressures.AutoSize = true;
            this.lblPressures.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPressures.Location = new System.Drawing.Point(213, 195);
            this.lblPressures.Name = "lblPressures";
            this.lblPressures.Size = new System.Drawing.Size(100, 25);
            this.lblPressures.TabIndex = 40;
            this.lblPressures.Text = "Pressures";
            // 
            // lblMatId
            // 
            this.lblMatId.AutoSize = true;
            this.lblMatId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMatId.Location = new System.Drawing.Point(12, 164);
            this.lblMatId.Name = "lblMatId";
            this.lblMatId.Size = new System.Drawing.Size(66, 25);
            this.lblMatId.TabIndex = 41;
            this.lblMatId.Text = "Mat Id";
            this.lblMatId.Visible = false;
            // 
            // btnDevelopment
            // 
            this.btnDevelopment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnDevelopment.Location = new System.Drawing.Point(450, 12);
            this.btnDevelopment.Name = "btnDevelopment";
            this.btnDevelopment.Size = new System.Drawing.Size(213, 50);
            this.btnDevelopment.TabIndex = 42;
            this.btnDevelopment.Text = "Development";
            this.btnDevelopment.UseVisualStyleBackColor = true;
            this.btnDevelopment.Click += new System.EventHandler(this.btnDevelopment_Click);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnImport.Location = new System.Drawing.Point(12, 69);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(118, 54);
            this.btnImport.TabIndex = 43;
            this.btnImport.Text = "Import Frame";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnExport.Location = new System.Drawing.Point(136, 67);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(128, 56);
            this.btnExport.TabIndex = 44;
            this.btnExport.Text = "Export Frame";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // comboPorts
            // 
            this.comboPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(615, 68);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(126, 28);
            this.comboPorts.TabIndex = 45;
            this.comboPorts.SelectedIndexChanged += new System.EventHandler(this.comboPorts_SelectedIndexChanged);
            // 
            // timerInitialConnection
            // 
            this.timerInitialConnection.Interval = 1000;
            this.timerInitialConnection.Tick += new System.EventHandler(this.timerInitialConnection_Tick);
            // 
            // btnRefreshComboPorts
            // 
            this.btnRefreshComboPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnRefreshComboPorts.Image = global::MattressHeatmap.Properties.Resources.refresh1;
            this.btnRefreshComboPorts.Location = new System.Drawing.Point(747, 68);
            this.btnRefreshComboPorts.Name = "btnRefreshComboPorts";
            this.btnRefreshComboPorts.Size = new System.Drawing.Size(36, 29);
            this.btnRefreshComboPorts.TabIndex = 46;
            this.btnRefreshComboPorts.UseVisualStyleBackColor = true;
            this.btnRefreshComboPorts.Click += new System.EventHandler(this.btnRefreshComboPorts_Click);
            // 
            // timerSerialConnection
            // 
            this.timerSerialConnection.Interval = 2000;
            this.timerSerialConnection.Tick += new System.EventHandler(this.timerSerialConnection_Tick);
            // 
            // timerDisconnectedDelay
            // 
            this.timerDisconnectedDelay.Interval = 1000;
            this.timerDisconnectedDelay.Tick += new System.EventHandler(this.timerDisconnectedDelay_Tick);
            // 
            // btnSetOffset
            // 
            this.btnSetOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSetOffset.Location = new System.Drawing.Point(12, 958);
            this.btnSetOffset.Name = "btnSetOffset";
            this.btnSetOffset.Size = new System.Drawing.Size(213, 50);
            this.btnSetOffset.TabIndex = 47;
            this.btnSetOffset.Text = "Set Offset";
            this.btnSetOffset.UseVisualStyleBackColor = true;
            this.btnSetOffset.Click += new System.EventHandler(this.btnSetOffset_Click);
            // 
            // btnCancelOffset
            // 
            this.btnCancelOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancelOffset.Location = new System.Drawing.Point(231, 958);
            this.btnCancelOffset.Name = "btnCancelOffset";
            this.btnCancelOffset.Size = new System.Drawing.Size(213, 50);
            this.btnCancelOffset.TabIndex = 48;
            this.btnCancelOffset.Text = "Cancel Offset";
            this.btnCancelOffset.UseVisualStyleBackColor = true;
            this.btnCancelOffset.Click += new System.EventHandler(this.btnCancelOffset_Click);
            // 
            // btnSample
            // 
            this.btnSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSample.Location = new System.Drawing.Point(1215, 958);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(213, 50);
            this.btnSample.TabIndex = 49;
            this.btnSample.Text = "Sample";
            this.btnSample.UseVisualStyleBackColor = true;
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
            // 
            // timerSampling
            // 
            this.timerSampling.Interval = 1000;
            this.timerSampling.Tick += new System.EventHandler(this.timerSampling_Tick);
            // 
            // lblBufferSize
            // 
            this.lblBufferSize.AutoSize = true;
            this.lblBufferSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblBufferSize.Location = new System.Drawing.Point(7, 318);
            this.lblBufferSize.Name = "lblBufferSize";
            this.lblBufferSize.Size = new System.Drawing.Size(0, 24);
            this.lblBufferSize.TabIndex = 20;
            this.lblBufferSize.Visible = false;
            // 
            // lblRowsCount
            // 
            this.lblRowsCount.AutoSize = true;
            this.lblRowsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRowsCount.Location = new System.Drawing.Point(7, 355);
            this.lblRowsCount.Name = "lblRowsCount";
            this.lblRowsCount.Size = new System.Drawing.Size(0, 24);
            this.lblRowsCount.TabIndex = 21;
            this.lblRowsCount.Visible = false;
            // 
            // lblDataQueueSiize
            // 
            this.lblDataQueueSiize.AutoSize = true;
            this.lblDataQueueSiize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDataQueueSiize.Location = new System.Drawing.Point(7, 280);
            this.lblDataQueueSiize.Name = "lblDataQueueSiize";
            this.lblDataQueueSiize.Size = new System.Drawing.Size(0, 24);
            this.lblDataQueueSiize.TabIndex = 23;
            this.lblDataQueueSiize.Visible = false;
            // 
            // panelColorRanges
            // 
            this.panelColorRanges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColorRanges.Controls.Add(this.ucColorRangesPressures);
            this.panelColorRanges.Controls.Add(this.ucColorRangesCaps);
            this.panelColorRanges.Controls.Add(this.label22);
            this.panelColorRanges.Controls.Add(this.lblDataQueueSiize);
            this.panelColorRanges.Controls.Add(this.lblRowsCount);
            this.panelColorRanges.Controls.Add(this.lblBufferSize);
            this.panelColorRanges.Controls.Add(this.txtRawSerialData);
            this.panelColorRanges.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelColorRanges.Location = new System.Drawing.Point(1434, 0);
            this.panelColorRanges.Name = "panelColorRanges";
            this.panelColorRanges.Size = new System.Drawing.Size(396, 1020);
            this.panelColorRanges.TabIndex = 33;
            // 
            // ucColorRangesPressures
            // 
            this.ucColorRangesPressures.Location = new System.Drawing.Point(4, 434);
            this.ucColorRangesPressures.Name = "ucColorRangesPressures";
            this.ucColorRangesPressures.Size = new System.Drawing.Size(391, 415);
            this.ucColorRangesPressures.TabIndex = 53;
            this.ucColorRangesPressures.Type = MattressHeatmap.HeatMapType.Pressures;
            // 
            // ucColorRangesCaps
            // 
            this.ucColorRangesCaps.Location = new System.Drawing.Point(3, 3);
            this.ucColorRangesCaps.Name = "ucColorRangesCaps";
            this.ucColorRangesCaps.Size = new System.Drawing.Size(387, 425);
            this.ucColorRangesCaps.TabIndex = 52;
            this.ucColorRangesCaps.Type = MattressHeatmap.HeatMapType.Caps;
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label22.Location = new System.Drawing.Point(11, 432);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(370, 2);
            this.label22.TabIndex = 51;
            // 
            // btnSimulate
            // 
            this.btnSimulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSimulate.Location = new System.Drawing.Point(1329, 902);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(99, 50);
            this.btnSimulate.TabIndex = 50;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // btnToggleBlur
            // 
            this.btnToggleBlur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleBlur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnToggleBlur.Location = new System.Drawing.Point(1045, 958);
            this.btnToggleBlur.Name = "btnToggleBlur";
            this.btnToggleBlur.Size = new System.Drawing.Size(59, 50);
            this.btnToggleBlur.TabIndex = 51;
            this.btnToggleBlur.Text = "Blur";
            this.btnToggleBlur.UseVisualStyleBackColor = true;
            this.btnToggleBlur.Visible = false;
            this.btnToggleBlur.Click += new System.EventHandler(this.btnToggleBlur_Click);
            // 
            // checkTau
            // 
            this.checkTau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkTau.AutoSize = true;
            this.checkTau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkTau.Location = new System.Drawing.Point(1052, 975);
            this.checkTau.Name = "checkTau";
            this.checkTau.Size = new System.Drawing.Size(64, 24);
            this.checkTau.TabIndex = 52;
            this.checkTau.Text = "Tau:";
            this.checkTau.UseVisualStyleBackColor = true;
            this.checkTau.CheckedChanged += new System.EventHandler(this.checkTau_CheckedChanged);
            // 
            // numTau
            // 
            this.numTau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTau.DecimalPlaces = 3;
            this.numTau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numTau.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numTau.Location = new System.Drawing.Point(1122, 972);
            this.numTau.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTau.Name = "numTau";
            this.numTau.Size = new System.Drawing.Size(76, 27);
            this.numTau.TabIndex = 53;
            this.numTau.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.numTau.ValueChanged += new System.EventHandler(this.numTau_ValueChanged);
            // 
            // ucHeatMapMain
            // 
            this.ucHeatMapMain.ComPort = "COM5";
            this.ucHeatMapMain.EndChar = '>';
            this.ucHeatMapMain.Input = "";
            this.ucHeatMapMain.LineSeperatorChar = ':';
            this.ucHeatMapMain.Location = new System.Drawing.Point(17, 232);
            this.ucHeatMapMain.ManualCoef0 = 0D;
            this.ucHeatMapMain.ManualCoef1 = 1D;
            this.ucHeatMapMain.ManualCoef2 = 2D;
            this.ucHeatMapMain.ManualCoef3 = 3D;
            this.ucHeatMapMain.ManualLut = false;
            this.ucHeatMapMain.Name = "ucHeatMapMain";
            this.ucHeatMapMain.ranges = new string[0];
            this.ucHeatMapMain.ScaleMultiplier = 1D;
            this.ucHeatMapMain.Size = new System.Drawing.Size(801, 389);
            this.ucHeatMapMain.SmoothImage = false;
            this.ucHeatMapMain.StartChar = '<';
            this.ucHeatMapMain.StretchDirection = MattressHeatmap.StretchDirection.Vertical;
            this.ucHeatMapMain.StretchToMaxMode = false;
            this.ucHeatMapMain.TabIndex = 14;
            this.ucHeatMapMain.ValueSeperatorChar = ',';
            // 
            // Status_text
            // 
            this.Status_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Status_text.Location = new System.Drawing.Point(909, 37);
            this.Status_text.Name = "Status_text";
            this.Status_text.Size = new System.Drawing.Size(134, 27);
            this.Status_text.TabIndex = 90;
            // 
            // Frame_text
            // 
            this.Frame_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Frame_text.Location = new System.Drawing.Point(1086, 37);
            this.Frame_text.Name = "Frame_text";
            this.Frame_text.Size = new System.Drawing.Size(134, 27);
            this.Frame_text.TabIndex = 91;
            // 
            // MatNum_text
            // 
            this.MatNum_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MatNum_text.Location = new System.Drawing.Point(909, 98);
            this.MatNum_text.Name = "MatNum_text";
            this.MatNum_text.Size = new System.Drawing.Size(134, 27);
            this.MatNum_text.TabIndex = 92;
            // 
            // LifeTime_text
            // 
            this.LifeTime_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LifeTime_text.Location = new System.Drawing.Point(1086, 98);
            this.LifeTime_text.Name = "LifeTime_text";
            this.LifeTime_text.Size = new System.Drawing.Size(134, 27);
            this.LifeTime_text.TabIndex = 93;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Status.Location = new System.Drawing.Point(941, 12);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(74, 25);
            this.Status.TabIndex = 94;
            this.Status.Text = "Status:";
            // 
            // Frame
            // 
            this.Frame.AutoSize = true;
            this.Frame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Frame.Location = new System.Drawing.Point(1117, 12);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(74, 25);
            this.Frame.TabIndex = 95;
            this.Frame.Text = "Frame:";
            // 
            // MatNum
            // 
            this.MatNum.AutoSize = true;
            this.MatNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MatNum.Location = new System.Drawing.Point(914, 73);
            this.MatNum.Name = "MatNum";
            this.MatNum.Size = new System.Drawing.Size(125, 25);
            this.MatNum.TabIndex = 96;
            this.MatNum.Text = "Mat Number:";
            // 
            // LifeTime
            // 
            this.LifeTime.AutoSize = true;
            this.LifeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LifeTime.Location = new System.Drawing.Point(1104, 73);
            this.LifeTime.Name = "LifeTime";
            this.LifeTime.Size = new System.Drawing.Size(98, 25);
            this.LifeTime.TabIndex = 97;
            this.LifeTime.Text = "Life Time:";
            // 
            // Temp_text
            // 
            this.Temp_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Temp_text.Location = new System.Drawing.Point(909, 157);
            this.Temp_text.Name = "Temp_text";
            this.Temp_text.Size = new System.Drawing.Size(134, 27);
            this.Temp_text.TabIndex = 98;
            // 
            // Humidity_text
            // 
            this.Humidity_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Humidity_text.Location = new System.Drawing.Point(1086, 157);
            this.Humidity_text.Name = "Humidity_text";
            this.Humidity_text.Size = new System.Drawing.Size(134, 27);
            this.Humidity_text.TabIndex = 99;
            // 
            // Row_text
            // 
            this.Row_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Row_text.Location = new System.Drawing.Point(1262, 37);
            this.Row_text.Name = "Row_text";
            this.Row_text.Size = new System.Drawing.Size(134, 27);
            this.Row_text.TabIndex = 100;
            // 
            // Columns_text
            // 
            this.Columns_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Columns_text.Location = new System.Drawing.Point(1262, 98);
            this.Columns_text.Name = "Columns_text";
            this.Columns_text.Size = new System.Drawing.Size(134, 27);
            this.Columns_text.TabIndex = 101;
            // 
            // Temp
            // 
            this.Temp.AutoSize = true;
            this.Temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Temp.Location = new System.Drawing.Point(941, 132);
            this.Temp.Name = "Temp";
            this.Temp.Size = new System.Drawing.Size(69, 25);
            this.Temp.TabIndex = 102;
            this.Temp.Text = "Temp:";
            // 
            // Humidity
            // 
            this.Humidity.AutoSize = true;
            this.Humidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Humidity.Location = new System.Drawing.Point(1109, 132);
            this.Humidity.Name = "Humidity";
            this.Humidity.Size = new System.Drawing.Size(93, 25);
            this.Humidity.TabIndex = 103;
            this.Humidity.Text = "Humidity:";
            // 
            // Rows
            // 
            this.Rows.AutoSize = true;
            this.Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Rows.Location = new System.Drawing.Point(1302, 12);
            this.Rows.Name = "Rows";
            this.Rows.Size = new System.Drawing.Size(56, 25);
            this.Rows.TabIndex = 104;
            this.Rows.Text = "Row:";
            // 
            // Columns
            // 
            this.Columns.AutoSize = true;
            this.Columns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Columns.Location = new System.Drawing.Point(1280, 73);
            this.Columns.Name = "Columns";
            this.Columns.Size = new System.Drawing.Size(96, 25);
            this.Columns.TabIndex = 105;
            this.Columns.Text = "Columns:";
            // 
            // FW_Version_text
            // 
            this.FW_Version_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FW_Version_text.Location = new System.Drawing.Point(1262, 157);
            this.FW_Version_text.Name = "FW_Version_text";
            this.FW_Version_text.Size = new System.Drawing.Size(134, 27);
            this.FW_Version_text.TabIndex = 106;
            // 
            // FW_Version
            // 
            this.FW_Version.AutoSize = true;
            this.FW_Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FW_Version.Location = new System.Drawing.Point(1265, 132);
            this.FW_Version.Name = "FW_Version";
            this.FW_Version.Size = new System.Drawing.Size(128, 25);
            this.FW_Version.TabIndex = 107;
            this.FW_Version.Text = "FW_Version:";
            // 
            // SendText
            // 
            this.SendText.Location = new System.Drawing.Point(450, 922);
            this.SendText.Name = "SendText";
            this.SendText.Size = new System.Drawing.Size(213, 50);
            this.SendText.TabIndex = 108;
            this.SendText.Text = "Send";
            this.SendText.UseVisualStyleBackColor = true;
            this.SendText.Click += new System.EventHandler(this.SendText_Click);
            // 
            // SendBox
            // 
            this.SendBox.AcceptsReturn = true;
            this.SendBox.AcceptsTab = true;
            this.SendBox.Location = new System.Drawing.Point(669, 922);
            this.SendBox.Multiline = true;
            this.SendBox.Name = "SendBox";
            this.SendBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SendBox.Size = new System.Drawing.Size(390, 50);
            this.SendBox.TabIndex = 109;
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Version.Location = new System.Drawing.Point(4, 4);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(53, 25);
            this.Version.TabIndex = 110;
            this.Version.Text = "V1.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1830, 1020);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.SendBox);
            this.Controls.Add(this.SendText);
            this.Controls.Add(this.FW_Version);
            this.Controls.Add(this.FW_Version_text);
            this.Controls.Add(this.Columns);
            this.Controls.Add(this.Rows);
            this.Controls.Add(this.Humidity);
            this.Controls.Add(this.Temp);
            this.Controls.Add(this.Columns_text);
            this.Controls.Add(this.Row_text);
            this.Controls.Add(this.Humidity_text);
            this.Controls.Add(this.Temp_text);
            this.Controls.Add(this.LifeTime);
            this.Controls.Add(this.MatNum);
            this.Controls.Add(this.Frame);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.LifeTime_text);
            this.Controls.Add(this.MatNum_text);
            this.Controls.Add(this.Frame_text);
            this.Controls.Add(this.Status_text);
            this.Controls.Add(this.numTau);
            this.Controls.Add(this.checkTau);
            this.Controls.Add(this.btnToggleBlur);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.btnSample);
            this.Controls.Add(this.btnCancelOffset);
            this.Controls.Add(this.btnSetOffset);
            this.Controls.Add(this.btnRefreshComboPorts);
            this.Controls.Add(this.comboPorts);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnDevelopment);
            this.Controls.Add(this.lblMatId);
            this.Controls.Add(this.lblPressures);
            this.Controls.Add(this.lblCaps);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.lblConnectionType);
            this.Controls.Add(this.panelManualLut);
            this.Controls.Add(this.btnConnectWithBluetooth);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.checkManualLut);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.checkSmoothImage);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnStream);
            this.Controls.Add(this.ucHeatMapMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerateHeatMap);
            this.Controls.Add(this.panelColorRanges);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Heat Map";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPressurePoints)).EndInit();
            this.panelManualLut.ResumeLayout(false);
            this.panelManualLut.PerformLayout();
            this.panelColorRanges.ResumeLayout(false);
            this.panelColorRanges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerateHeatMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackDensity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPressurePoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ucHeatMap ucHeatMapMain;
        private System.Windows.Forms.CheckBox checkSmoothImage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnStream;
        private System.Windows.Forms.TextBox txtRawSerialData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timerDebug;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox checkManualLut;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCoef0;
        private System.Windows.Forms.TextBox txtCoef3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCoef2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCoef1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnConnectWithBluetooth;
        private System.Windows.Forms.Panel panelManualLut;
        private System.Windows.Forms.Label lblConnectionType;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCaps;
        private System.Windows.Forms.Label lblPressures;
        private System.Windows.Forms.Label lblMatId;
        private System.Windows.Forms.Button btnDevelopment;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox comboPorts;
        private System.Windows.Forms.Timer timerInitialConnection;
        private System.Windows.Forms.Button btnRefreshComboPorts;
        private System.Windows.Forms.Timer timerSerialConnection;
        private System.Windows.Forms.Timer timerDisconnectedDelay;
        private System.Windows.Forms.Button btnSetOffset;
        private System.Windows.Forms.Button btnCancelOffset;
        private System.Windows.Forms.Button btnSample;
        private System.Windows.Forms.Timer timerSampling;
        private System.Windows.Forms.Label lblBufferSize;
        private System.Windows.Forms.Label lblRowsCount;
        private System.Windows.Forms.Label lblDataQueueSiize;
        private System.Windows.Forms.Panel panelColorRanges;
        private System.Windows.Forms.Label label22;
        private ucColorRanges ucColorRangesCaps;
        private ucColorRanges ucColorRangesPressures;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.Button btnToggleBlur;
        private System.Windows.Forms.CheckBox checkTau;
        private System.Windows.Forms.NumericUpDown numTau;
        private System.Windows.Forms.TextBox Status_text;
        private System.Windows.Forms.TextBox Frame_text;
        private System.Windows.Forms.TextBox MatNum_text;
        private System.Windows.Forms.TextBox LifeTime_text;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label Frame;
        private System.Windows.Forms.Label MatNum;
        private System.Windows.Forms.Label LifeTime;
        private System.Windows.Forms.TextBox Temp_text;
        private System.Windows.Forms.TextBox Humidity_text;
        private System.Windows.Forms.TextBox Row_text;
        private System.Windows.Forms.TextBox Columns_text;
        private System.Windows.Forms.Label Temp;
        private System.Windows.Forms.Label Humidity;
        private System.Windows.Forms.Label Rows;
        private System.Windows.Forms.Label Columns;
        private System.Windows.Forms.TextBox FW_Version_text;
        private System.Windows.Forms.Label FW_Version;
        private System.Windows.Forms.Button SendText;
        private System.Windows.Forms.TextBox SendBox;
        private System.Windows.Forms.Label Version;
    }
}

