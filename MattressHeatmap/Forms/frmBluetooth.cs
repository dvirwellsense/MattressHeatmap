using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MattressHeatmap
{
    public enum ConnectionStatus { NotConnected, Connecting, Connected } //Connected for when mat data is being received

    public partial class frmBluetooth : Form
    {
        private BluetoothScanner scanner;
        private BindingList<BluetoothDeviceDisplay> deviceDisplays;
        private int flowCounter;

        private bool responseNotificationsStarted;
        private bool dataNotificationsStarted;
        private ConnectionStatus currentDeviceConnectionStatus;
        private bool firstDataArrived;

        public frmBluetooth()
        {
            InitializeComponent();
        }

        private void frmBluetooth_Load(object sender, EventArgs e)
        {
            scanner = new BluetoothScanner();
            Global.Devices = new List<BluetoothDevice>();
            Global.BluetoothLogger = new Logger();
            Global.ControlCharacteristics = new BluetoothControlCharacteristics();
            deviceDisplays = new BindingList<BluetoothDeviceDisplay>();
            flowCounter = -1;
            responseNotificationsStarted = false;
            dataNotificationsStarted = false;
            currentDeviceConnectionStatus = ConnectionStatus.NotConnected;
            firstDataArrived = false;

            UpdateShowLogs();

            dataGridViewDevices.DataSource = deviceDisplays;

            scanner.ScanStarted_Event += Scanner_ScanStarted_Event;
            scanner.ScanEnded_Event += Scanner_ScanEnded_Event;
            scanner.DeviceAdded_Event += Scanner_DeviceAdded_Event;
            scanner.DeviceUpdated_Event += Scanner_DeviceUpdated_Event;
            scanner.DeviceRemoved_Event += Scanner_DeviceRemoved_Event;

            Global.BluetoothLogger.MessageReceived_Event += BluetoothLogger_MessageReceived_Event;

            EventPublisher.CharacteristiclDataRead_Event += EventPublisher_CharacteristiclDataRead_Event;
            EventPublisher.CharacteristicStringDataRead_Event += EventPublisher_CharacteristicStringDataRead_Event;
            EventPublisher.CharacteristicNotificationsStarted_Event += EventPublisher_CharacteristicNotificationsStarted_Event;
        }

        private void EventPublisher_CharacteristicNotificationsStarted_Event(BluetoothCharacteristic characteristic)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventPublisher.EventHandler_Characteristic(EventPublisher_CharacteristicNotificationsStarted_Event), new object[] { characteristic });
                return;
            }

            if (characteristic.Name.Equals(Global.ControlCharacteristics.ResponseCharacteristicName)) responseNotificationsStarted = true;
            if (characteristic.Name.Equals(Global.ControlCharacteristics.DataCharacteristicName)) dataNotificationsStarted = true;
        }

        private void EventPublisher_CharacteristicStringDataRead_Event(BluetoothCharacteristic characteristic, string value)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventPublisher.EventHandler_CharacteristicReadString(EventPublisher_CharacteristicStringDataRead_Event), new object[] { characteristic, value });
                return;
            }

            if (characteristic.Name.Equals(Global.ControlCharacteristics.DataCharacteristicName)) Global.BluetoothLogger.Log("Data Arrived: " + value);
            if (characteristic.Name.Equals(Global.ControlCharacteristics.ResponseCharacteristicName)) Global.BluetoothLogger.Log("Response Arrived: " + value);
        }

        private void EventPublisher_CharacteristiclDataRead_Event(BluetoothCharacteristic characteristic, byte[] data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventPublisher.EventHandler_CharacteristicRead(EventPublisher_CharacteristiclDataRead_Event), new object[] { characteristic, data });
                return;
            }

            if (characteristic.Name.Equals(Global.ControlCharacteristics.DataCharacteristicName))
            {
                //Global.BluetoothLogger.Log("Got " + ParseRowAsString(data.ToList()));

                //BluetoothDataParser parser = new BluetoothDataParser(data.ToList());
                //parser.HandleMessage();
                if (!firstDataArrived)
                {
                    BluetoothMessage message = new BluetoothMessage(data.ToList());
                    if(message.BasicMessage.Type == BleMessageType.kReturnRow)
                    {
                        firstDataArrived = true;
                        SetDevicePanelConnectionStatus(ConnectionStatus.Connected);
                    }
                }
            }
            if (characteristic.Name.Equals(Global.ControlCharacteristics.ResponseCharacteristicName)) Global.BluetoothLogger.Log("Got " + ParseRowAsString(data.ToList()));
        }

        private void BluetoothLogger_MessageReceived_Event(string value)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Logger.EventHandler_String(BluetoothLogger_MessageReceived_Event), new object[] { value });
                return;
            }

            AddLogMessage(value);
        }

        private void Scanner_ScanStarted_Event()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new BluetoothScanner.EventHandler_Void(Scanner_ScanStarted_Event), new object[] { });
                return;
            }
            timerScanningLabel.Start();
            if (deviceDisplays != null) deviceDisplays.Clear();
        }

        private void Scanner_ScanEnded_Event()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new BluetoothScanner.EventHandler_Void(Scanner_ScanEnded_Event), new object[] { });
                return;
            }

            timerScanningLabel.Stop();
            lblScanning.Visible = false;
        }

        private void Scanner_DeviceRemoved_Event(BluetoothDevice device)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new BluetoothScanner.EventHandler_Device(Scanner_DeviceRemoved_Event), new object[] { device });
                return;
            }

            RemoveDisplay(device);
        }

        private void Scanner_DeviceUpdated_Event(BluetoothDevice device)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new BluetoothScanner.EventHandler_Device(Scanner_DeviceUpdated_Event), new object[] { device });
                return;
            }

            UpdateDisplay(device);
        }

        private void Scanner_DeviceAdded_Event(BluetoothDevice device)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new BluetoothScanner.EventHandler_Device(Scanner_DeviceAdded_Event), new object[] { device });
                return;
            }

            AddDisplay(device);
        }

        private void UpdateDisplay()
        {
            deviceDisplays.Clear();
            for (int i = 0; i < Global.Devices.Count; i++)
            {
                deviceDisplays.Add(new BluetoothDeviceDisplay(Global.Devices[i]));
            }
        }

        private void UpdateDisplay(BluetoothDevice device)
        {
            int currentRowIndex = 0;
            if(dataGridViewDevices.CurrentRow != null) currentRowIndex = dataGridViewDevices.CurrentRow.Index;
            for (int i = 0; i < deviceDisplays.Count; i++)
            {
                if (deviceDisplays[i].Id.Equals(device.Id))
                {
                    deviceDisplays[i].Update(device);
                    return;
                }
            }
            dataGridViewDevices.FirstDisplayedScrollingRowIndex = currentRowIndex;
        }

        private void AddDisplay(BluetoothDevice device)
        {
            if (GetDeviceDisplayById(device.Id) == null)
                deviceDisplays.Add(new BluetoothDeviceDisplay(device));
        }

        private void RemoveDisplay(BluetoothDevice device)
        {
            BluetoothDeviceDisplay deviceDisplay = GetDeviceDisplayById(device.Id);
            if (deviceDisplay != null) deviceDisplays.Remove(deviceDisplay);
        }

        private BluetoothDeviceDisplay GetDeviceDisplayById(string id)
        {
            for (int i = 0; i < deviceDisplays.Count; i++)
            {
                if (deviceDisplays[i].Id.Equals(id)) return deviceDisplays[i];
            }
            return null;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            scanner.StartScan();
        }

        private BluetoothDevice GetSelectedDevice() //With Prompts
        {
            int index = GetSelectedDeviceIndex();

            if (index == -1)
            {
                MessageBox.Show("No Device Selected");
                return null;
            }

            if (index == -2)
            {
                MessageBox.Show("Please select only one device");
                return null;
            }

            string id = deviceDisplays[index].Id;
            BluetoothDevice device = Global.GetDeviceById(id);
            if (device == null) MessageBox.Show("Error selecting device");

            return device;
        }

        private int GetSelectedDeviceIndex()
        {
            int selectedCellCount = dataGridViewDevices.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int rowIndex = -1;
                for (int i = 0; i < selectedCellCount; i++)
                {
                    int selectedCellRowIndex = dataGridViewDevices.SelectedCells[i].RowIndex;
                    if (selectedCellRowIndex != rowIndex)
                    {
                        if (rowIndex == -1) rowIndex = selectedCellRowIndex;
                        else return -2;
                    }
                }
                return rowIndex;
            }
            else return -1;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Global.CurrentDevice = GetSelectedDevice();
            if (Global.CurrentDevice == null) return;
            Global.CurrentDevice.Update();
            SetDevicePanelDevice(Global.CurrentDevice);
            SetDevicePanelConnectionStatus(ConnectionStatus.Connecting);
            scanner.StopScan();
            responseNotificationsStarted = false;
            dataNotificationsStarted = false;
            flowCounter = 1;
            timerConnection.Start();
        }

        private void timerScanningLabel_Tick(object sender, EventArgs e)
        {
            if (lblScanning.Visible) lblScanning.Visible = false;
            else lblScanning.Visible = true;
        }

        private void timerConnection_Tick(object sender, EventArgs e)
        {
            switch (flowCounter)
            {
                case 1:
                    flowCounter++;
                    break;

                case 2:
                    Global.CurrentDevice.Connect();
                    flowCounter++;
                    break;

                case 3:
                    if (Global.CurrentDevice.State == DeviceState.Connected)
                    {
                        flowCounter++;
                    }
                    break;

                case 4:
                    Global.CurrentDevice.GetAllServices();
                    flowCounter++;
                    break;

                case 5:
                    if (Global.CurrentDevice.State == DeviceState.GotServices)
                    {
                        flowCounter++;
                    }
                    break;

                case 6:

                    foreach (BluetoothService service in Global.CurrentDevice.Services)
                    {
                        service.GetCharacteristics();
                        Thread.Sleep(200);
                    }
                    flowCounter++;
                    break;

                case 7:
                    if (Global.CurrentDevice.State == DeviceState.GotCharacterstics)
                    {
                        Thread.Sleep(1000);
                        flowCounter++;
                    }
                    break;

                case 8:
                    Global.ControlCharacteristics.Load();
                    if (Global.ControlCharacteristics.DataCharacteristic != null) flowCounter++;
                    else
                    {
                        timerConnection.Stop();
                        Global.BluetoothLogger.Log("Can't find characteristic: " + Global.ControlCharacteristics.DataCharacteristicName + " and / or service: " + Global.ControlCharacteristics.ControlServiceName + ". Can't receive data.");
                    }
                    break;

                case 9:
                    Global.ControlCharacteristics.DataCharacteristic.StartNotify();
                    flowCounter++;
                    break;

                case 10:
                    if (dataNotificationsStarted) flowCounter++;
                    break;

                case 11:
                    if (Global.ControlCharacteristics.ResponseCharacteristic == null)
                    {
                        timerConnection.Stop();
                        Global.BluetoothLogger.Log("Can't find characteristic: " + Global.ControlCharacteristics.ResponseCharacteristicName + " and / or service: " + Global.ControlCharacteristics.ControlServiceName + ". Can't receive responses.");
                    }
                    else
                    {
                        Global.ControlCharacteristics.ResponseCharacteristic.StartNotify();
                        flowCounter++;
                    }
                    break;

                case 12:
                    if (responseNotificationsStarted) flowCounter++;
                    break;

                case 13:
                    if (Global.ControlCharacteristics.CommandCharacteristic == null)
                    {
                        timerConnection.Stop();
                        Global.BluetoothLogger.Log("Can't find characteristic: " + Global.ControlCharacteristics.CommandCharacteristicName + " and / or service: " + Global.ControlCharacteristics.ControlServiceName + ". Can't send commands.");
                    }
                    else
                    {
                        Global.ControlCharacteristics.CommandCharacteristic.WriteString("GC");
                        flowCounter++;
                    }
                    break;

                case int n when (n > 13 && n < 25):
                    flowCounter++;
                    break;

                case 25:
                    Global.ControlCharacteristics.CommandCharacteristic.WriteString("GD");
                    flowCounter++;
                    break;

                case int n when (n > 25 && n < 40):
                    flowCounter++;
                    break;

                case 40:
                    Global.ControlCharacteristics.CommandCharacteristic.WriteString("SM");
                    flowCounter = 50;
                    break;

                case 50:
                    flowCounter = -1;
                    timerConnection.Stop();
                    break;
            }
        }

        private void AddLogMessage(string message)
        {
            listLogs.Items.Add(message);
            listLogs.SelectedIndex = listLogs.Items.Count - 1;
        }

        private void UpdateShowLogs()
        {
            int buffer = 10;
            bool showLogs = checkShowLogs.Checked;
            if (showLogs)
            {
                listLogs.Visible = true;
                ClientSize = new Size(ClientSize.Width, listLogs.Bounds.Bottom + buffer);
            }
            else
            {
                listLogs.Visible = false;
                ClientSize = new Size(ClientSize.Width, checkShowLogs.Bounds.Bottom + buffer);
            }
        }

        private void checkShowLogs_CheckedChanged(object sender, EventArgs e)
        {
            UpdateShowLogs();
        }

        private void btnSendControlMessage_Click(object sender, EventArgs e)
        {
            Global.ControlCharacteristics.CommandCharacteristic.WriteString("SM");
        }

        private string ParseRowAsString(List<byte> data)
        {
            int type = data[6];
            BleMessageStatus status = (BleMessageStatus)data[7];
            int rowNumber = data[8];

            return "Row number " + rowNumber + ": Type=" + type + ", Status=" + GetBleMessageStatusString(status) + '.';
        }

        private string GetBleMessageStatusString(BleMessageStatus status)
        {
            switch (status)
            {
                case BleMessageStatus.kSuccess: return "Success";
                case BleMessageStatus.kFailed: return "Failed";
                case BleMessageStatus.kUnknownCommand: return "Unknown Command";
            }

            return "Unknown";
        }

        private void listLogs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listLogs.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                FormShowText form = new FormShowText();
                form.Text = listLogs.Items[index].ToString();
                form.Show();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string logsText = "";
            for (int i = 0; i < listLogs.Items.Count; i++)
            {
                logsText += listLogs.Items[i].ToString() + Environment.NewLine;
            }
            txtLogs.Text = logsText;
            txtLogs.Visible = true;
        }

        private void btnSendCalibrationMessage_Click(object sender, EventArgs e)
        {
            Global.ControlCharacteristics.CommandCharacteristic.WriteString("GC");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string str = "";

            str += "5 --> " + GetIntInBytesString(5, 1) + Environment.NewLine;
            str += "10 --> " + GetIntInBytesString(10, 1) + Environment.NewLine;
            str += "15 --> " + GetIntInBytesString(15, 1) + Environment.NewLine;

            str += "500 --> " + GetIntInBytesString(500, 2) + Environment.NewLine;
            str += "1000 --> " + GetIntInBytesString(1000, 2) + Environment.NewLine;
            str += "1400 --> " + GetIntInBytesString(1400, 2) + Environment.NewLine;

            MessageBox.Show(str);
            MessageBox.Show(GetIntInBytesString(17, 1));
        }

        private string GetIntInBytesString(int number, int numberOfBytes)
        {
            byte[] byteArr;

            if (numberOfBytes == 2)
            {
                byte b0 = (byte)number,
                    b1 = (byte)(number >> 8);

                byteArr = new byte[] { b0, b1 };
            }
            else if (numberOfBytes == 1)
            {
                byteArr = new byte[] { (byte)number };
            }
            else byteArr = new byte[] { 0x00 };
            
            return BitConverter.ToString(byteArr);
        }

        private void SetDevicePanelDevice(BluetoothDevice device)
        {
            lblDeviceName.Text = device.Name;
            lblDeviceAddress.Text = device.BtAddress;
            lblDeviceConnectable.Text = device.IsConnectable ? "Connectable" : "Not Connectable";
            lblDeviceConnectable.ForeColor = device.IsConnectable ? Color.Green : SystemColors.ControlText;
            lblDeviceSignal.Text = "Signal: " + device.Rssi;
            lblDeviceConnected.Text = device.IsConnected ? "Connected" : "Not Connected";

            AdjustDevicePanel();

            panelDevice.Visible = true;
        }

        private void AdjustDevicePanel()
        {
            int buffer = 15;

            int identityLabelsWidth = Math.Max(lblDeviceName.Size.Width, lblDeviceAddress.Size.Width);
            int panelWidth = buffer + identityLabelsWidth + buffer + lblDeviceConnectable.Size.Width + buffer
                + lblDeviceSignal.Size.Width + buffer + lblDeviceConnected.Size.Width + buffer;
            panelDevice.Size = new Size(panelWidth, panelDevice.Size.Height);
            
            int dataGridHalfWidth = dataGridViewDevices.Size.Width / 2;
            int panelHalfWidth = panelDevice.Size.Width / 2;
            int panelX = dataGridViewDevices.Bounds.Left + dataGridHalfWidth - panelHalfWidth;
            panelDevice.Location = new Point(panelX, panelDevice.Location.Y);

            lblDeviceName.Location = new Point(buffer, lblDeviceName.Location.Y);
            lblDeviceAddress.Location = new Point(buffer, lblDeviceAddress.Location.Y);
            int identityLabelsRightBound = Math.Max(lblDeviceName.Bounds.Right, lblDeviceAddress.Bounds.Right);
            lblDeviceConnectable.Location = new Point(identityLabelsRightBound + buffer, lblDeviceConnectable.Location.Y);
            lblDeviceSignal.Location = new Point(lblDeviceConnectable.Bounds.Right + buffer, lblDeviceSignal.Location.Y);
            lblDeviceConnected.Location = new Point(lblDeviceSignal.Bounds.Right + buffer, lblDeviceConnected.Location.Y);
        }

        private void SetDevicePanelConnectionStatus(ConnectionStatus connectionStatus)
        {
            if (currentDeviceConnectionStatus == connectionStatus) return;
            if (currentDeviceConnectionStatus == ConnectionStatus.Connecting)
            {
                timerConnectingLabel.Stop();
                lblDeviceConnected.Visible = true;
            }
            currentDeviceConnectionStatus = connectionStatus;
            switch (currentDeviceConnectionStatus)
            {
                case ConnectionStatus.Connected:
                    lblDeviceConnected.Text = "Connected";
                    break;

                case ConnectionStatus.NotConnected:
                    lblDeviceConnected.Text = "Not Connected";
                    break;

                case ConnectionStatus.Connecting:
                    lblDeviceConnected.Text = "Connecting";
                    timerConnectingLabel.Start();
                    break;
            }
        }

        private void timerConnectingLabel_Tick(object sender, EventArgs e)
        {
            if (lblDeviceConnected.Visible) lblDeviceConnected.Visible = false;
            else lblDeviceConnected.Visible = true;
        }

        private void frmBluetooth_FormClosing(object sender, FormClosingEventArgs e)
        {
            scanner.StopScan();
        }
    }
}
