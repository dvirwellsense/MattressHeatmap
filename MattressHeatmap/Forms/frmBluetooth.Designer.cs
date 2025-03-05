namespace MattressHeatmap
{
    partial class frmBluetooth
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
            this.btnScan = new System.Windows.Forms.Button();
            this.dataGridViewDevices = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pairedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.connectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.connectableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.signalStrengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bluetoothDeviceDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblScanning = new System.Windows.Forms.Label();
            this.timerScanningLabel = new System.Windows.Forms.Timer(this.components);
            this.timerConnection = new System.Windows.Forms.Timer(this.components);
            this.listLogs = new System.Windows.Forms.ListBox();
            this.checkShowLogs = new System.Windows.Forms.CheckBox();
            this.btnSendControlMessage = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.btnSendCalibrationMessage = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.panelDevice = new System.Windows.Forms.Panel();
            this.lblDeviceAddress = new System.Windows.Forms.Label();
            this.lblDeviceConnected = new System.Windows.Forms.Label();
            this.lblDeviceSignal = new System.Windows.Forms.Label();
            this.lblDeviceConnectable = new System.Windows.Forms.Label();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.timerConnectingLabel = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluetoothDeviceDisplayBindingSource)).BeginInit();
            this.panelDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnScan.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnScan.Location = new System.Drawing.Point(132, 47);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(728, 40);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan for Devices";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // dataGridViewDevices
            // 
            this.dataGridViewDevices.AutoGenerateColumns = false;
            this.dataGridViewDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.pairedDataGridViewCheckBoxColumn,
            this.connectedDataGridViewCheckBoxColumn,
            this.connectableDataGridViewCheckBoxColumn,
            this.signalStrengthDataGridViewTextBoxColumn});
            this.dataGridViewDevices.DataSource = this.bluetoothDeviceDisplayBindingSource;
            this.dataGridViewDevices.Location = new System.Drawing.Point(38, 109);
            this.dataGridViewDevices.Name = "dataGridViewDevices";
            this.dataGridViewDevices.ReadOnly = true;
            this.dataGridViewDevices.RowHeadersWidth = 51;
            this.dataGridViewDevices.RowTemplate.Height = 24;
            this.dataGridViewDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDevices.Size = new System.Drawing.Size(930, 223);
            this.dataGridViewDevices.TabIndex = 2;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 125;
            // 
            // pairedDataGridViewCheckBoxColumn
            // 
            this.pairedDataGridViewCheckBoxColumn.DataPropertyName = "Paired";
            this.pairedDataGridViewCheckBoxColumn.HeaderText = "Paired";
            this.pairedDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.pairedDataGridViewCheckBoxColumn.Name = "pairedDataGridViewCheckBoxColumn";
            this.pairedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.pairedDataGridViewCheckBoxColumn.Width = 125;
            // 
            // connectedDataGridViewCheckBoxColumn
            // 
            this.connectedDataGridViewCheckBoxColumn.DataPropertyName = "Connected";
            this.connectedDataGridViewCheckBoxColumn.HeaderText = "Connected";
            this.connectedDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.connectedDataGridViewCheckBoxColumn.Name = "connectedDataGridViewCheckBoxColumn";
            this.connectedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.connectedDataGridViewCheckBoxColumn.Width = 125;
            // 
            // connectableDataGridViewCheckBoxColumn
            // 
            this.connectableDataGridViewCheckBoxColumn.DataPropertyName = "Connectable";
            this.connectableDataGridViewCheckBoxColumn.HeaderText = "Connectable";
            this.connectableDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.connectableDataGridViewCheckBoxColumn.Name = "connectableDataGridViewCheckBoxColumn";
            this.connectableDataGridViewCheckBoxColumn.ReadOnly = true;
            this.connectableDataGridViewCheckBoxColumn.Width = 125;
            // 
            // signalStrengthDataGridViewTextBoxColumn
            // 
            this.signalStrengthDataGridViewTextBoxColumn.DataPropertyName = "SignalStrength";
            this.signalStrengthDataGridViewTextBoxColumn.HeaderText = "SignalStrength";
            this.signalStrengthDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.signalStrengthDataGridViewTextBoxColumn.Name = "signalStrengthDataGridViewTextBoxColumn";
            this.signalStrengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.signalStrengthDataGridViewTextBoxColumn.Width = 125;
            // 
            // bluetoothDeviceDisplayBindingSource
            // 
            this.bluetoothDeviceDisplayBindingSource.DataSource = typeof(MattressHeatmap.BluetoothDeviceDisplay);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnConnect.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnConnect.Location = new System.Drawing.Point(132, 406);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(728, 40);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect to Device";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblScanning
            // 
            this.lblScanning.AutoSize = true;
            this.lblScanning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblScanning.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScanning.Location = new System.Drawing.Point(41, 84);
            this.lblScanning.Name = "lblScanning";
            this.lblScanning.Size = new System.Drawing.Size(85, 22);
            this.lblScanning.TabIndex = 4;
            this.lblScanning.Text = "Scanning";
            this.lblScanning.Visible = false;
            // 
            // timerScanningLabel
            // 
            this.timerScanningLabel.Interval = 500;
            this.timerScanningLabel.Tick += new System.EventHandler(this.timerScanningLabel_Tick);
            // 
            // timerConnection
            // 
            this.timerConnection.Interval = 200;
            this.timerConnection.Tick += new System.EventHandler(this.timerConnection_Tick);
            // 
            // listLogs
            // 
            this.listLogs.FormattingEnabled = true;
            this.listLogs.ItemHeight = 16;
            this.listLogs.Location = new System.Drawing.Point(212, 482);
            this.listLogs.Name = "listLogs";
            this.listLogs.Size = new System.Drawing.Size(596, 148);
            this.listLogs.TabIndex = 5;
            this.listLogs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listLogs_MouseDoubleClick);
            // 
            // checkShowLogs
            // 
            this.checkShowLogs.AutoSize = true;
            this.checkShowLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkShowLogs.Location = new System.Drawing.Point(401, 452);
            this.checkShowLogs.Name = "checkShowLogs";
            this.checkShowLogs.Size = new System.Drawing.Size(194, 24);
            this.checkShowLogs.TabIndex = 6;
            this.checkShowLogs.Text = "Show connection logs";
            this.checkShowLogs.UseVisualStyleBackColor = true;
            this.checkShowLogs.CheckedChanged += new System.EventHandler(this.checkShowLogs_CheckedChanged);
            // 
            // btnSendControlMessage
            // 
            this.btnSendControlMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSendControlMessage.Location = new System.Drawing.Point(58, 482);
            this.btnSendControlMessage.Name = "btnSendControlMessage";
            this.btnSendControlMessage.Size = new System.Drawing.Size(124, 59);
            this.btnSendControlMessage.TabIndex = 7;
            this.btnSendControlMessage.Text = "Send Control Message";
            this.btnSendControlMessage.UseVisualStyleBackColor = true;
            this.btnSendControlMessage.Click += new System.EventHandler(this.btnSendControlMessage_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCopy.Location = new System.Drawing.Point(829, 482);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(167, 34);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(821, 534);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(174, 95);
            this.txtLogs.TabIndex = 9;
            this.txtLogs.Visible = false;
            // 
            // btnSendCalibrationMessage
            // 
            this.btnSendCalibrationMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSendCalibrationMessage.Location = new System.Drawing.Point(58, 547);
            this.btnSendCalibrationMessage.Name = "btnSendCalibrationMessage";
            this.btnSendCalibrationMessage.Size = new System.Drawing.Size(124, 59);
            this.btnSendCalibrationMessage.TabIndex = 10;
            this.btnSendCalibrationMessage.Text = "Send Calibration Message";
            this.btnSendCalibrationMessage.UseVisualStyleBackColor = true;
            this.btnSendCalibrationMessage.Click += new System.EventHandler(this.btnSendCalibrationMessage_Click);
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnTest.Location = new System.Drawing.Point(21, 406);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(105, 59);
            this.btnTest.TabIndex = 11;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // panelDevice
            // 
            this.panelDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDevice.Controls.Add(this.lblDeviceAddress);
            this.panelDevice.Controls.Add(this.lblDeviceConnected);
            this.panelDevice.Controls.Add(this.lblDeviceSignal);
            this.panelDevice.Controls.Add(this.lblDeviceConnectable);
            this.panelDevice.Controls.Add(this.lblDeviceName);
            this.panelDevice.Location = new System.Drawing.Point(38, 338);
            this.panelDevice.Name = "panelDevice";
            this.panelDevice.Size = new System.Drawing.Size(930, 59);
            this.panelDevice.TabIndex = 12;
            this.panelDevice.Visible = false;
            // 
            // lblDeviceAddress
            // 
            this.lblDeviceAddress.AutoSize = true;
            this.lblDeviceAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDeviceAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeviceAddress.Location = new System.Drawing.Point(4, 34);
            this.lblDeviceAddress.Name = "lblDeviceAddress";
            this.lblDeviceAddress.Size = new System.Drawing.Size(61, 18);
            this.lblDeviceAddress.TabIndex = 4;
            this.lblDeviceAddress.Text = "address";
            // 
            // lblDeviceConnected
            // 
            this.lblDeviceConnected.AutoSize = true;
            this.lblDeviceConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDeviceConnected.ForeColor = System.Drawing.Color.Green;
            this.lblDeviceConnected.Location = new System.Drawing.Point(358, 27);
            this.lblDeviceConnected.Name = "lblDeviceConnected";
            this.lblDeviceConnected.Size = new System.Drawing.Size(117, 25);
            this.lblDeviceConnected.TabIndex = 3;
            this.lblDeviceConnected.Text = "Connected";
            // 
            // lblDeviceSignal
            // 
            this.lblDeviceSignal.AutoSize = true;
            this.lblDeviceSignal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDeviceSignal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeviceSignal.Location = new System.Drawing.Point(279, 27);
            this.lblDeviceSignal.Name = "lblDeviceSignal";
            this.lblDeviceSignal.Size = new System.Drawing.Size(73, 25);
            this.lblDeviceSignal.TabIndex = 2;
            this.lblDeviceSignal.Text = "Signal:";
            // 
            // lblDeviceConnectable
            // 
            this.lblDeviceConnectable.AutoSize = true;
            this.lblDeviceConnectable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDeviceConnectable.ForeColor = System.Drawing.Color.Green;
            this.lblDeviceConnectable.Location = new System.Drawing.Point(150, 27);
            this.lblDeviceConnectable.Name = "lblDeviceConnectable";
            this.lblDeviceConnectable.Size = new System.Drawing.Size(123, 25);
            this.lblDeviceConnectable.TabIndex = 1;
            this.lblDeviceConnectable.Text = "Connectable";
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDeviceName.Location = new System.Drawing.Point(4, 9);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(140, 25);
            this.lblDeviceName.TabIndex = 0;
            this.lblDeviceName.Text = "Device Name";
            // 
            // timerConnectingLabel
            // 
            this.timerConnectingLabel.Interval = 500;
            this.timerConnectingLabel.Tick += new System.EventHandler(this.timerConnectingLabel_Tick);
            // 
            // frmBluetooth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 651);
            this.Controls.Add(this.panelDevice);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnSendCalibrationMessage);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnSendControlMessage);
            this.Controls.Add(this.checkShowLogs);
            this.Controls.Add(this.listLogs);
            this.Controls.Add(this.lblScanning);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.dataGridViewDevices);
            this.Controls.Add(this.btnScan);
            this.Name = "frmBluetooth";
            this.Text = "Bluetooth";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBluetooth_FormClosing);
            this.Load += new System.EventHandler(this.frmBluetooth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluetoothDeviceDisplayBindingSource)).EndInit();
            this.panelDevice.ResumeLayout(false);
            this.panelDevice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.DataGridView dataGridViewDevices;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pairedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn connectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn connectableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn signalStrengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bluetoothDeviceDisplayBindingSource;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblScanning;
        private System.Windows.Forms.Timer timerScanningLabel;
        private System.Windows.Forms.Timer timerConnection;
        private System.Windows.Forms.ListBox listLogs;
        private System.Windows.Forms.CheckBox checkShowLogs;
        private System.Windows.Forms.Button btnSendControlMessage;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btnSendCalibrationMessage;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Panel panelDevice;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblDeviceAddress;
        private System.Windows.Forms.Label lblDeviceConnected;
        private System.Windows.Forms.Label lblDeviceSignal;
        private System.Windows.Forms.Label lblDeviceConnectable;
        private System.Windows.Forms.Timer timerConnectingLabel;
    }
}