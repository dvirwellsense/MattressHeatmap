using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace MattressHeatmap
{
    public enum HeatMapType { Caps, Pressures }
    public enum SerialDeviceStatus { Connected, Unavailable, Unresponsive }

    public partial class Form1 : Form
    {
        private HeatMapInputSimulator simulator;
        private StreamInputSimulator streamSimulator;
        private Random rnd;
        private bool isSerialSimulatorRunning;
        private int heatmapStartLocationX;
        private SerialDeviceStatus serialDeviceStatus;
        private Area samplingArea;
        private Stopwatch watch;
        private bool isSampling;
        private frmSampling samplingForm;
        private bool isDisconnectedByUI = false;

        public delegate void EventHandler_HeatmapData(string data);
        public event EventHandler_HeatmapData HeatmapDataGenerated_Event;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ucColorRangesCaps.Init();
            ucColorRangesPressures.Init();
            simulator = new HeatMapInputSimulator((int)numWidth.Value, (int)numHeight.Value);
            simulator.PressurePoints.Add(new PressurePoint(20, 20, 0.9));
            simulator.PressurePoints.Add(new PressurePoint(45, 45, 0.8));
            simulator.PressurePoints.Add(new PressurePoint(30, 30, 0.8));

            streamSimulator = new StreamInputSimulator((int)numWidth.Value, (int)numHeight.Value, 3, "COM8");
            streamSimulator.InputUpdated_Event += StreamSimulator_InputUpdated_Event;
            isSerialSimulatorRunning = false;
            //heatmapStartLocationX = ucHeatMapMain.Location.X;
            heatmapStartLocationX = 17;
            samplingArea = null;
            watch = null;
            isSampling = false;
            samplingForm = null;

            UpdateConnectionTypeLabel(ConnectionType.NotConnected);

            //serialPortDataReciever = new SerialPortDataReciever("COM8");
            //serialPortDataReciever.RawDataArrived_Event += SerialPortDataReciever_RawDataArrived_Event;
            //serialPortDataReciever.DataArrived_Event += SerialPortDataReciever_DataArrived_Event;

            ucHeatMapMain.SetColorRanges(ucColorRangesCaps.GetColorRanges(), HeatMapType.Caps);
            ucHeatMapMain.SetColorRanges(ucColorRangesPressures.GetColorRanges(), HeatMapType.Pressures);

            SetupTxtCoefs();

            UpdateComboPortsItems();

            /*
            ucHeatMapMain.ColorRanges.Add(new ColorRange(0, 0.1, Color.Cyan));
            ucHeatMapMain.ColorRanges.Add(new ColorRange(0.1, 0.2, Color.Blue));
            ucHeatMapMain.ColorRanges.Add(new ColorRange(0.2, 0.3, Color.Green));
            ucHeatMapMain.ColorRanges.Add(new ColorRange(0.3, 0.4, Color.LightGreen));
            ucHeatMapMain.ColorRanges.Add(new ColorRange(0.4, 0.5, Color.Yellow));
            ucHeatMapMain.ColorRanges.Add(new ColorRange(0.5, 0.6, Color.Orange));
            ucHeatMapMain.ColorRanges.Add(new ColorRange(0.6, 0.7, Color.DarkOrange));
            ucHeatMapMain.ColorRanges.Add(new ColorRange(0.7, 0.8, Color.Salmon));
            ucHeatMapMain.ColorRanges.Add(new ColorRange(0.8, 0.9, Color.Red));
            ucHeatMapMain.ColorRanges.Add(new ColorRange(0.9, 1, Color.DarkRed));
            */
            rnd = new Random();

            ucHeatMapMain.SetManualLut(checkManualLut.Checked);
            ucHeatMapMain.SetStretchToMaxMode(true);
            UpdateHeatmapMaxSize();
            UpdateHeatmapLocation();
            UpdateHeatmapLabels();

            EventPublisher.BluetoothDataArrived_Event += EventPublisher_BluetoothDataArrived_Event;
            ucHeatMapMain.ConnectionTypeChanged_Event += UcHeatMapMain_ConnectionTypeChanged_Event;
            ucHeatMapMain.SizeChanged_Event += UcHeatMapMain_SizeChanged_Event;
            ucHeatMapMain.GotBluetoothDetails_Event += UcHeatMapMain_GotBluetoothDetails_Event;
            ucHeatMapMain.SelectedFrameArrived_Event += UcHeatMapMain_SelectedFrameArrived_Event;
            ucHeatMapMain.SerialPortClosed_Event += UcHeatMapMain_SerialPortClosed_Event;
            ucColorRangesCaps.ColorRangesChanged_Event += UcColorRanges_ColorRangesChanged_Event;
            ucColorRangesPressures.ColorRangesChanged_Event += UcColorRanges_ColorRangesChanged_Event;

            ucHeatMapMain.MetaSend_Event += UcHeatMapMain_MetaArrived_Event;

            HeatmapDataGenerated_Event += ucHeatMapMain.SetNewInputString;

            serialDeviceStatus = SerialDeviceStatus.Unavailable;

            //ConnectToDeviceIfAvailable();
        }

        private void EventPublisher_BluetoothDataArrived_Event(byte[] data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventPublisher.EventHandler_ByteArray(EventPublisher_BluetoothDataArrived_Event), new object[] { data });
                return;
            }

            ucHeatMapMain.ProcessBluetoothData(data);
        }

        private void UcHeatMapMain_MetaArrived_Event(List<string> metadata)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ucHeatMap.EventHandler_Meta(UcHeatMapMain_MetaArrived_Event), new object[] { metadata });
                return;
            }
            if (metadata.Count > 0)
            {
                Status_text.Text = metadata[0].Substring(4);
                Frame_text.Text = metadata[1];
                MatNum_text.Text = metadata[2];
                Row_text.Text = metadata[3];
                Columns_text.Text = metadata[4];
                Temp_text.Text = metadata[8].Remove(metadata[8].Length - 1) + "°C";
                Humidity_text.Text = metadata[9];
                LifeTime_text.Text = metadata[10];
                FW_Version_text.Text = metadata[13]+","+metadata[14];
                Frame_text.Text = metadata[1];
            }
        }


        private void SerialPortDataReciever_RawDataArrived_Event(string value)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SerialPortDataReciever.EventHandler_String(SerialPortDataReciever_RawDataArrived_Event), new object[] { value });
                return;
            }
            txtRawSerialData.Text += value;
        }

        private void StreamSimulator_InputUpdated_Event(double[,] newInput)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new StreamInputSimulator.EventHandler_InputUpdated(StreamSimulator_InputUpdated_Event), new object[] { newInput });
                return;
            }
            ucHeatMapMain.SetNewInputArray(newInput);
        }

        private void UcHeatMapMain_ConnectionTypeChanged_Event(ConnectionType connectionType)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ucHeatMap.EventHandler_ConnectionType(UcHeatMapMain_ConnectionTypeChanged_Event), new object[] { connectionType });
                return;
            }

            UpdateConnectionTypeLabel(connectionType);
            if (connectionType == ConnectionType.Serial)
            {
                lblMatId.Text = "Mat Id: " + Global.Lut.MatId;
                lblMatId.Visible = true;
            }
            //else if (connectionType == ConnectionType.NotConnected) serialDeviceStatus = SerialDeviceStatus.Unavailable; //timerSerialConnection.Start();
        }

        private void UcHeatMapMain_SerialPortClosed_Event()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ucHeatMap.EventHandler_Void(UcHeatMapMain_SerialPortClosed_Event), new object[] { });
                return;
            }

            serialDeviceStatus = SerialDeviceStatus.Unavailable;
        }

        private void UcHeatMapMain_SizeChanged_Event(Size size)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ucHeatMap.EventHandler_Size(UcHeatMapMain_SizeChanged_Event), new object[] { size });
                return;
            }

            UpdateHeatmapLocation();
            UpdateHeatmapLabels();
        }

        private void UcHeatMapMain_GotBluetoothDetails_Event()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ucHeatMap.EventHandler_Void(UcHeatMapMain_GotBluetoothDetails_Event), new object[] { });
                return;
            }
            int minorVersion = Global.BluetoothDetails.MatMinorVersion;
            lblMatId.Text = "Mat Id (minor version): " + minorVersion;
            lblMatId.Visible = true;
        }

        private void UcHeatMapMain_SelectedFrameArrived_Event(Frame frame)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ucHeatMap.EventHandler_Frame(UcHeatMapMain_SelectedFrameArrived_Event), new object[] { frame });
                return;
            }

            if (isSampling) WriteSampleFrame(frame);
        }

        private void UcColorRanges_ColorRangesChanged_Event(List<ColorRange> colorRanges, HeatMapType type)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ucColorRanges.EventHandler_ColorRanges(UcColorRanges_ColorRangesChanged_Event), new object[] { colorRanges, type });
                return;
            }

            ucHeatMapMain.SetColorRanges(colorRanges, type);
        }

        private void btnGenerateHeatMap_Click(object sender, EventArgs e)
        {
            GenerateHeatMap();
        }

        private void GenerateHeatMap()
        {
            simulator.PressurePoints.Clear();
            simulator.Width = (int)numWidth.Value;
            simulator.Height = (int)numHeight.Value;
            simulator.Step = GetSimulatorStep();

            int count = (int)numPressurePoints.Value;
            for (int i = 0; i < count; i++)
            {
                simulator.PressurePoints.Add(GetRandomPressurePoint());
            }

            //ucHeatMapMain.SetNewInput(simulator.GenerateInput());
            ucHeatMapMain.SetNewInputArray(simulator.GenerateArray());
        }

        private PressurePoint GetRandomPressurePoint()
        {
            int width = (int)numWidth.Value;
            int height = (int)numHeight.Value;
            double heatMin = 0.7;

            int line = rnd.Next(height);
            int col = rnd.Next(width);
            double heatValue = rnd.NextDouble() * (1 - heatMin) + heatMin;

            return new PressurePoint(col, line, heatValue);
        }

        private double GetSimulatorStep()
        {
            int density = trackDensity.Value;
            double stepChange = -((double)density / 100);
            return 0.075 + stepChange;
        }

        private void trackDensity_Scroll(object sender, EventArgs e)
        {
            simulator.Step = GetSimulatorStep();
            //ucHeatMapMain.SetNewInput(simulator.GenerateInput());
            ucHeatMapMain.SetNewInputArray(simulator.GenerateArray());
        }

        private void numPressurePoints_ValueChanged(object sender, EventArgs e)
        {
            if (streamSimulator.IsActive)
            {
                streamSimulator.NumberOfPressurePoints = (int)numPressurePoints.Value;
                return;
            }
            bool isGreater = (int)numPressurePoints.Value > simulator.PressurePoints.Count;
            while ((int)numPressurePoints.Value != simulator.PressurePoints.Count)
            {
                if (isGreater) simulator.PressurePoints.Add(GetRandomPressurePoint());
                else simulator.PressurePoints.RemoveAt(0);
            }
            //ucHeatMapMain.SetNewInput(simulator.GenerateInput());
            ucHeatMapMain.SetNewInputArray(simulator.GenerateArray());
        }

        private void numsSize_ValueChanged(object sender, EventArgs e)
        {
            GenerateHeatMap();
        }

        private void btnBlurr_Click(object sender, EventArgs e)
        {
            //ucHeatMapMain.ApplyGaussianBlurr();
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            ucHeatMapMain.PaintImage();
        }

        private void btnThreshholding_Click(object sender, EventArgs e)
        {
            //ucHeatMapMain.ApplyThreshholding();
        }

        private void checkSmoothImage_CheckedChanged(object sender, EventArgs e)
        {
            bool smoothImage = checkSmoothImage.Checked;
            ucHeatMapMain.SetSmoothImage(smoothImage);
        }

        private void btnStream_Click(object sender, EventArgs e)
        {
            StartSerialConnection();
        }

        private bool StartSerialConnection()
        {
            return StartSerialConnection(true);
        }

        private bool StartSerialConnection(bool isShowMessages)
        {
            ucHeatMapMain.SetDevelopmentMode(false);
            bool isConnected = ucHeatMapMain.ConnectToSerialPort(isShowMessages);
            if (!isConnected) return false;

            frmSerialConnection form = new frmSerialConnection();
            form.MainForm = this;
            form.Show();

            return true;
        }

        public void ConnectToSerial()
        {
            ucHeatMapMain.StartRequestSequence();
        }

        public void CancelConnectingToSerial()
        {
            ucHeatMapMain.StopRequestSequence();
        }

        private void btnStream2_Click(object sender, EventArgs e)
        {
            if (isSerialSimulatorRunning)
            {
                btnStream.Text = "Start Serial Streaming";
                timerDebug.Enabled = false;
                ucHeatMapMain.CancelSerialPortConnection();
                streamSimulator.Stop();
                isSerialSimulatorRunning = false;
            }
            else
            {
                bool isConnected = ucHeatMapMain.ConnectToSerialPort();
                if (!isConnected) return;

                streamSimulator.SetSerialPortByReference(ucHeatMapMain.GetSerialPort());

                btnStream.Text = "Stop";
                streamSimulator.Start();
                isSerialSimulatorRunning = true;

                timerDebug.Enabled = true;
            }

        }

        private void SetupTxtCoefs()
        {
            txtCoef0.Text = Properties.Settings.Default.ManualCoef0.ToString();
            txtCoef1.Text = Properties.Settings.Default.ManualCoef1.ToString();
            txtCoef2.Text = Properties.Settings.Default.ManualCoef2.ToString();
            txtCoef3.Text = Properties.Settings.Default.ManualCoef3.ToString();
        }

        private void timerDebug_Tick(object sender, EventArgs e)
        {
            //lblBufferSize.Text = serialPortDataReciever.GetBufferCount().ToString();
            //lblRowsCount.Text = serialPortDataReciever.GetRowsCount().ToString();
            lblDataQueueSiize.Text = streamSimulator.GetDataQueueCount().ToString();
        }

        private void btnSendSerial_Click(object sender, EventArgs e)
        {

        }

        private void checkManualLut_CheckedChanged(object sender, EventArgs e)
        {
            ucHeatMapMain.SetManualLut(checkManualLut.Checked);
            if (checkManualLut.Checked) panelManualLut.Visible = true;
            else panelManualLut.Visible = false;
        }

        private void txtCoef0_TextChanged(object sender, EventArgs e)
        {
            double value;
            bool isValid = double.TryParse(txtCoef0.Text, out value);
            if (isValid) ucHeatMapMain.SetManualCoefficient(0, value);
            else ucHeatMapMain.SetManualCoefficient(0, 0);
        }

        private void txtCoef1_TextChanged(object sender, EventArgs e)
        {
            double value;
            bool isValid = double.TryParse(txtCoef1.Text, out value);
            if (isValid) ucHeatMapMain.SetManualCoefficient(1, value);
            else ucHeatMapMain.SetManualCoefficient(1, 0);
        }

        private void txtCoef2_TextChanged(object sender, EventArgs e)
        {
            double value;
            bool isValid = double.TryParse(txtCoef2.Text, out value);
            if (isValid) ucHeatMapMain.SetManualCoefficient(2, value);
            else ucHeatMapMain.SetManualCoefficient(2, 0);
        }

        private void txtCoef3_TextChanged(object sender, EventArgs e)
        {
            double value;
            bool isValid = double.TryParse(txtCoef3.Text, out value);
            if (isValid) ucHeatMapMain.SetManualCoefficient(3, value);
            else ucHeatMapMain.SetManualCoefficient(3, 0);
        }

        private void btnConnectWithBluetooth_Click(object sender, EventArgs e)
        {
            frmBluetooth form = new frmBluetooth();
            form.Show();
        }

        private void UpdateHeatmapMaxSize()
        {
            ucHeatMapMain.SetMaxSize(new Size(panelColorRanges.Bounds.Left - 20 - heatmapStartLocationX,
                ClientSize.Height - ucHeatMapMain.Bounds.Top - 75));
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateHeatmapMaxSize();
            UpdateHeatmapLocation();
            UpdateHeatmapLabels();
        }

        private void UpdateHeatmapLocation()
        {
            int centerX = heatmapStartLocationX + ((panelColorRanges.Bounds.Left - heatmapStartLocationX - 20) / 2);
            ucHeatMapMain.Location = new Point(centerX - (ucHeatMapMain.Size.Width / 2), ucHeatMapMain.Location.Y);
        }

        private void UpdateHeatmapLabels()
        {
            int buffer = ucHeatMapMain.GetDividerLength();
            int singleHeatmapWidth = (ucHeatMapMain.Size.Width / 2) - (buffer / 2);
            int capsX = ucHeatMapMain.Bounds.Left + (singleHeatmapWidth / 2) - (lblCaps.Size.Width / 2);
            int pressuresX = ucHeatMapMain.Bounds.Right - (singleHeatmapWidth / 2) - (lblPressures.Size.Width / 2);

            lblCaps.Location = new Point(capsX, lblCaps.Location.Y);
            lblPressures.Location = new Point(pressuresX, lblPressures.Location.Y);
        }

        private void UpdateConnectionTypeLabel(ConnectionType connectionType)
        {
            switch (connectionType)
            {
                case ConnectionType.Bluetooth:
                    lblConnectionType.Text = "Connected To Bluetooth";
                    lblConnectionType.ForeColor = Color.Green;
                    break;

                case ConnectionType.Serial:
                    lblConnectionType.Text = "Connected To Serial";
                    lblConnectionType.ForeColor = Color.Green;
                    break;

                case ConnectionType.NotConnected:
                    lblConnectionType.Text = "Not Conneccted";
                    lblConnectionType.ForeColor = Color.Red;
                    lblMatId.Visible = false;
                    break;
            }
        }

        private void UpdateComboPortsItems()
        {
            string[] availablePorts = SerialPort.GetPortNames();
            string selectedValue = comboPorts.SelectedIndex == -1 ? "" : comboPorts.Items[comboPorts.SelectedIndex].ToString();

            comboPorts.Items.Clear();

            // Add all available ports to the combo box
            foreach (string port in availablePorts)
            {
                comboPorts.Items.Add(port);
            }

            if (availablePorts.Length == 1)
            {
                // If there is only one port, select it automatically
                comboPorts.SelectedIndex = 0;
            }
            else if (!string.IsNullOrEmpty(selectedValue) && availablePorts.Contains(selectedValue))
            {
                // If the previously selected port is still available, keep it selected
                comboPorts.SelectedIndex = comboPorts.Items.IndexOf(selectedValue);
            }
            else
            {
                // If no selection is possible, clear the combo box selection
                comboPorts.Text = "";
            }
        }



        private SerialDeviceStatus ConnectToDeviceIfAvailable()
        {
            string comPort = GetDeviceComPort();
            if (comPort == null) return SerialDeviceStatus.Unavailable;
            comboPorts.SelectedIndex = comboPorts.Items.IndexOf(comPort);
            ucHeatMapMain.ComPort = comPort;
            if (StartSerialConnection(false)) return SerialDeviceStatus.Connected;
            return SerialDeviceStatus.Unresponsive;
        }

        private string GetDeviceComPort()
        {
            return GetDeviceComPorts("FFFF", "0005").FirstOrDefault();
        }

        private List<string> GetDeviceComPorts(String VID, String PID)
        {
            String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> comPorts = new List<string>();

            RegistryKey key1 = Registry.LocalMachine;
            RegistryKey key2 = key1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");

            foreach (String subKey3 in key2.GetSubKeyNames())
            {
                RegistryKey key3 = key2.OpenSubKey(subKey3);
                foreach (String s in key3.GetSubKeyNames())
                {
                    if (regex.Match(s).Success)
                    {
                        RegistryKey key4 = key3.OpenSubKey(s);
                        foreach (String subKey2 in key4.GetSubKeyNames())
                        {
                            RegistryKey key5 = key4.OpenSubKey(subKey2);
                            string location = (string)key5.GetValue("LocationInformation");
                            RegistryKey key6 = key5.OpenSubKey("Device Parameters");
                            string portName = (string)key6.GetValue("PortName");
                            if (!String.IsNullOrEmpty(portName) && SerialPort.GetPortNames().Contains(portName))
                                comPorts.Add((string)key6.GetValue("PortName"));
                        }
                    }
                }
            }
            return comPorts;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            isDisconnectedByUI = true;
            ConnectionType connectionType = ucHeatMapMain.GetConnectionType();
            if (connectionType == ConnectionType.Serial) ucHeatMapMain.DisconnectFromSerialPort();
            else if (connectionType == ConnectionType.Bluetooth) DisconnectFromBluetooth();
            //serialDeviceStatus = SerialDeviceStatus.Unresponsive;
            System.Diagnostics.Debug.WriteLine("my message" + DateTime.Now.ToString());
            //MessageBox.Show("" + BitConverter.ToUInt32(new byte[] { 0x01, 0xF3, 0x03, 0x00 }, 0));
            //MessageBox.Show("" + BitConverter.ToUInt32(new byte[] { 0xF3, 0x03, 0x00, 0x00 }, 0));
        }

        private void DisconnectFromBluetooth()
        {
            Global.CurrentDevice.Disconnect();
            ucHeatMapMain.SetConnectionType(ConnectionType.NotConnected);
        }

        private void btnDevelopment_Click(object sender, EventArgs e)
        {
            frmDevelopment form = new frmDevelopment();
            form.MainForm = this;
            form.Show();
        }

        public void StartDevelopment()
        {
            ucHeatMapMain.SetDevelopmentMode(true);
            ucHeatMapMain.ConnectToSerialPort();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Frame frame = CsvManager.ReadCsv("C:\\work\\MattressHeatmap\\Csv\\test2.csv");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Csv File";
            openFileDialog.Filter = "CSV files|*.csv";
            string csvFolder = GetCsvFolder();
            if (!csvFolder.Equals("None")) openFileDialog.InitialDirectory = csvFolder;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                if (!CheckFileFree(path)) return;

                Frame frame = CsvManager.ReadCsv(path);
                Disconnect();

                ucHeatMapMain.SetFrame(frame);

                string matId = Path.GetFileName(Path.GetDirectoryName(path));
                string fileName = Path.GetFileName(path).Replace(".csv", "");
                lblMatId.Text = "Mat Id: " + matId + ". File: " + fileName + ".";
                lblMatId.Visible = true;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void Export()
        {
            Frame frame = ucHeatMapMain.GetFrame();

            if (ucHeatMapMain.GetConnectionType() == ConnectionType.NotConnected)
            {
                MessageBox.Show("Not connected to Mat");
                return;
            }

            Export(frame);
        }

        private void Export(Frame frame)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Csv File";
            saveFileDialog.Filter = "CSV files (*.csv) | *.csv";
            saveFileDialog.OverwritePrompt = false;
            string csvFolder = GetCsvFolder();
            if (!csvFolder.Equals("None")) saveFileDialog.InitialDirectory = csvFolder;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                string savePath = GetSaveLocation(path);
                if (File.Exists(savePath))
                {
                    MessageBox.Show("The file: " + savePath + " exists already.");
                    Export(frame);
                    return;
                }

                CsvManager.WriteCsv(savePath, frame);

                string dir = Path.GetDirectoryName(Path.GetDirectoryName(savePath));
                if (!dir.Equals(Properties.Settings.Default.CsvFolder))
                {
                    Properties.Settings.Default.CsvFolder = dir;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private string GetSaveLocation(string path) //Also creates parent folder if necessary
        {
            string matId = GetMatId().ToString(); //Global.Lut.MatId.ToString();

            string folder = Path.GetDirectoryName(path);
            string folderName = Path.GetFileName(folder);
            string fileName = Path.GetFileName(path);

            if (folderName.Equals(matId)) return path;

            string parentFolder = folder + '\\' + matId;
            Directory.CreateDirectory(parentFolder);
            return parentFolder + '\\' + fileName;
        }

        private string GetSaveLocation_Old(string path)
        {
            string resultPath;
            string matId = Global.Lut.MatId.ToString();

            string folder = Path.GetDirectoryName(path);
            string folderName = Path.GetFileName(folder);
            string fileName = Path.GetFileName(path);

            if (folderName.Equals(matId)) resultPath = path;
            else
            {
                string parentFolder = folder + '\\' + matId;
                Directory.CreateDirectory(parentFolder);
                resultPath = parentFolder + '\\' + fileName;
            }

            if (File.Exists(resultPath)) return "Exists";

            return resultPath;
        }

        private string GetCsvFolder()
        {
            string csvFolder = Properties.Settings.Default.CsvFolder;

            return GetMatFolder(csvFolder);
        }

        private int GetMatId()
        {
            ConnectionType connectionType = ucHeatMapMain.GetConnectionType();
            switch (connectionType)
            {
                case ConnectionType.Serial: return Global.Lut.MatId;
                case ConnectionType.Bluetooth: return Global.BluetoothDetails.MatMinorVersion;
            }

            return -1;
        }

        private bool CheckFileFree(string filePath)
        {
            if (IsFileLocked(filePath))
            {
                string fileName = Path.GetFileName(filePath);
                DialogResult fileLockedMessageBoxResult = MessageBox.Show("Can't read from file: " + fileName + " because it is open in another program.", "File Locked", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                while (fileLockedMessageBoxResult == DialogResult.Retry && IsFileLocked(filePath))
                {
                    fileLockedMessageBoxResult = MessageBox.Show("Can't read from file: " + fileName + " because it is open in another program.", "File Still Locked", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                }
                if (fileLockedMessageBoxResult != DialogResult.Retry) return false;
                else if (!IsFileLocked(filePath)) return true;
                else return false;
            }
            else return true;
        }

        private bool IsFileLocked(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }

        private void timerInitialConnection_Tick(object sender, EventArgs e)
        {
            timerInitialConnection.Stop();
            if (ConnectToDeviceIfAvailable() == SerialDeviceStatus.Unavailable) timerSerialConnection.Start();
        }

        private void comboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPorts.SelectedIndex != -1) ucHeatMapMain.ComPort = comboPorts.Items[comboPorts.SelectedIndex].ToString();
        }

        private void btnRefreshComboPorts_Click(object sender, EventArgs e)
        {
            UpdateComboPortsItems();
        }

        private void timerSerialConnection_Tick(object sender, EventArgs e)
        {
            if (serialDeviceStatus != SerialDeviceStatus.Connected)
            {
                serialDeviceStatus = ConnectToDeviceIfAvailable();
                UpdateComboPortsItems();
            }
        }

        private void timerDisconnectedDelay_Tick(object sender, EventArgs e)
        {
            timerDisconnectedDelay.Stop();
            serialDeviceStatus = SerialDeviceStatus.Unresponsive;
        }

        private void btnSetOffset_Click(object sender, EventArgs e)
        {
            ucHeatMapMain.SetOffset();
        }

        private void btnCancelOffset_Click(object sender, EventArgs e)
        {
            ucHeatMapMain.ClearOffset();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) ucHeatMapMain.ClearSelection();
        }

        private void btnSample_Click(object sender, EventArgs e)
        {
            if (ucHeatMapMain.GetConnectionType() == ConnectionType.NotConnected)
            {
                MessageBox.Show("Not Connected");
                return;
            }

            samplingArea = ucHeatMapMain.GetSelectedArea();

            if (samplingArea == null)
            {
                MessageBox.Show("No Pixels Selected");
                return;
            }

            ucHeatMapMain.BlockSelection();

            frmSampling form = new frmSampling();
            form.MainForm = this;
            form.Area = samplingArea;
            form.Show();

            samplingForm = form;
        }

        public void StartSampling(SamplingParameters parameters)
        {
            SamplesWriter.StartWriting(samplingArea, parameters.IncludePressures);

            watch = Stopwatch.StartNew();

            if (parameters.AllFrames) isSampling = true;
            else
            {
                timerSampling.Interval = parameters.Interval;
                timerSampling.Start();
            }
        }

        private void timerSampling_Tick(object sender, EventArgs e)
        {
            Frame frame = ucHeatMapMain.GetSelectedAreaFrame();
            WriteSampleFrame(frame);
        }

        private void WriteSampleFrame(Frame frame)
        {
            int time = (int)watch.ElapsedMilliseconds;
            SamplesWriter.WriteFrame(frame, time);
            samplingForm.IncrementSamplesCount();
        }

        public void StopSampling()
        {
            timerSampling.Stop();
            isSampling = false;

            string selectedPath = SelectPath();

            if (selectedPath.Equals(""))
            {
                if (!SendAreYouSureMessage("Are you sure you want to avoid saving the samples\' csv file? The data might be discarded.")) StopSampling();
                return;
            }

            int result = SamplesWriter.StopWriting(selectedPath);

            if (result == 0) MessageBox.Show("The file was saved successfully.");
            else if (result == -1)
            {
                MessageBox.Show("An unknown error occured.");
                StopSampling();
            }
        }

        public void AllowAreaSelection()
        {
            ucHeatMapMain.UnblockSelection();
        }

        private string SelectPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Csv File";
            saveFileDialog.Filter = "CSV files (*.csv) | *.csv";
            saveFileDialog.OverwritePrompt = false;
            string samplingFolder = GetSamplingFolder();
            if (!samplingFolder.Equals("None")) saveFileDialog.InitialDirectory = samplingFolder;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                string savePath = GetSaveLocation(path);
                if (File.Exists(savePath))
                {
                    MessageBox.Show("The file: " + savePath + " exists already.");
                    return SelectPath();
                }

                string dir = Path.GetDirectoryName(Path.GetDirectoryName(savePath));
                if (!dir.Equals(Properties.Settings.Default.SamplingFolder))
                {
                    Properties.Settings.Default.SamplingFolder = dir;
                    Properties.Settings.Default.Save();
                }

                return savePath;
            }

            return "";
        }

        private string GetSamplingFolder()
        {
            string folder = Properties.Settings.Default.SamplingFolder;
            return GetMatFolder(folder);
        }

        private string GetMatFolder(string folder)
        {
            if (folder.Equals("None")) return "None";
            if (!Directory.Exists(folder)) return "None";

            string matFolder = folder + '\\' + GetMatId();
            if (Directory.Exists(matFolder)) return matFolder;

            return folder;
        }

        private bool SendAreYouSureMessage(string message)
        {
            DialogResult areYouSureMessageBooxResult = MessageBox.Show(message, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return areYouSureMessageBooxResult == DialogResult.Yes;
        }

        private void TestSampling()
        {
            Area area = ucHeatMapMain.GetSelectedArea();
            Frame frame = ucHeatMapMain.GetSelectedAreaFrame();
            SamplesWriter.StartWriting(area, true);
            SamplesWriter.WriteFrame(frame, 1234);
            //MessageBox.Show(SamplesWriter.Test());
            MessageBox.Show("Stopping.");
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            ucHeatMapMain.SimulateDevelopment();
        }

        private void btnToggleBlur_Click(object sender, EventArgs e)
        {
            ucHeatMapMain.ToggleBlur();
        }

        private void checkTau_CheckedChanged(object sender, EventArgs e)
        {
            ucHeatMapMain.SetIsTauAdjustmentOn(checkTau.Checked);

        }

        private void numTau_ValueChanged(object sender, EventArgs e)
        {
            ucHeatMapMain.SetTauAdjustmentValue((double)numTau.Value);
        }

        private void SendText_Click(object sender, EventArgs e)
        {
            string textToSend = SendBox.Text;
            if (!string.IsNullOrWhiteSpace(textToSend))
            {
                HeatmapDataGenerated_Event?.Invoke(textToSend);
                SendBox.Text = "";
            }
        }
    }
}
