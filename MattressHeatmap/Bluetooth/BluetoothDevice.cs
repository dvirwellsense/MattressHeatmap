using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;

namespace MattressHeatmap
{
    public enum DeviceState : byte { Mone = 0, Connected, GotServices, GotCharacterstics }

    public class BluetoothDevice
    {
        private Queue<int> rssiQueue = new Queue<int>(0);
        private GattDeviceServicesResult result;

        public List<BluetoothService> Services { get; set; }
        public DeviceInformation DeviceInfo { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string BtAddress { get; set; }
        public bool IsPaired { get; set; }
        public bool IsConnected { get; set; }
        public bool IsConnectable { get; set; }
        public DeviceState State { get; set; }

        private BluetoothLEDevice bluetoothLEDevice;
        public BluetoothLEDevice BluetoothLEDevice
        {
            get { return bluetoothLEDevice; }
            private set { bluetoothLEDevice = value; }
        }

        private int rssi;
        public int Rssi
        {
            get { return rssi; }
            private set
            {

                if (rssiQueue.Count >= 4) rssiQueue.Dequeue();
                rssiQueue.Enqueue(value);
                rssi = (int)Math.Round(rssiQueue.Average(), 0);
            }
        }

        public BluetoothDevice(DeviceInformation deviceInfo)
        {
            DeviceInfo = deviceInfo;
            Services = new List<BluetoothService>();
            Update();
        }

        public void Update()
        {
            try
            {
                if (DeviceInfo == null) return;
                Name = DeviceInfo.Name;
                Id = DeviceInfo.Id;

                IsPaired = DeviceInfo.Pairing.IsPaired;
                IsConnected = (bool?)DeviceInfo.Properties["System.Devices.Aep.IsConnected"] == true;
                IsConnectable = (bool?)DeviceInfo.Properties["System.Devices.Aep.Bluetooth.Le.IsConnectable"] == true;

                if (DeviceInfo.Properties.ContainsKey("System.Devices.Aep.DeviceAddress") && DeviceInfo.Properties["System.Devices.Aep.DeviceAddress"] != null)
                {
                    BtAddress = DeviceInfo.Properties["System.Devices.Aep.DeviceAddress"].ToString();
                }

                if (DeviceInfo.Properties.ContainsKey("System.Devices.Aep.SignalStrength") && DeviceInfo.Properties["System.Devices.Aep.SignalStrength"] != null)
                {
                    Rssi = (int)DeviceInfo.Properties["System.Devices.Aep.SignalStrength"];
                }
            }
            catch (Exception ex) { };
        }

        public async Task<bool> Connect()
        {
            Global.BluetoothLogger.Log("Connection Start");

            try
            {
                if (BluetoothLEDevice == null)
                {
                    BluetoothLEDevice = await BluetoothLEDevice.FromIdAsync(DeviceInfo.Id);
                    Global.BluetoothLogger.Log("Connectiong to Device");
                }
                else Global.BluetoothLogger.Log("Previously Connected");

                if (BluetoothLEDevice == null)
                {
                    Global.BluetoothLogger.Log("Connection Error");
                    return false;
                }

                Global.BluetoothLogger.Log("Connected");
                State = DeviceState.Connected;
                //RaiseEvent_FlowState(this);

                BluetoothLEDevice.ConnectionStatusChanged += BluetoothLEDevice_ConnectionStatusChanged;
                BluetoothLEDevice.NameChanged += BluetoothLEDevice_NameChanged;
                IsPaired = DeviceInfo.Pairing.IsPaired;
                IsConnected = (BluetoothLEDevice.ConnectionStatus == BluetoothConnectionStatus.Connected);
                Name = BluetoothLEDevice.Name;
                return true;
            }
            catch (Exception ex)
            {
                Global.BluetoothLogger.Log("Connection Exception - " + ex.Message);
                string message = String.Format("Message:\n{0}\n\nInnerException:\n{1}\n\nStack:\n{2}", ex.Message, ex.InnerException, ex.StackTrace);
                Global.BluetoothLogger.Log(message);
                return false;
            }
        }

        public void Disconnect()
        {
            if (BluetoothLEDevice != null) BluetoothLEDevice.Dispose();
            DisconnectCharacteristics();
        }

        private void DisconnectCharacteristics()
        {
            for(int i =0; i < Services.Count; i++)
            {
                Services[i].Disconnect();
            }
        }

        public async void GetAllServices()
        {
            try
            {
                Global.BluetoothLogger.Log("Getting Services");
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(5000);
                var GetGattServicesTask = Task.Run(() => BluetoothLEDevice.GetGattServicesAsync(BluetoothCacheMode.Uncached), cancellationTokenSource.Token);
                result = await GetGattServicesTask.Result;
                if (result.Status == GattCommunicationStatus.Success)
                {
                    Global.BluetoothLogger.Log("Successfully Got Gatt Services");
                    AddServices();
                    return;
                }
                Global.BluetoothLogger.Log("Error getting gatt services: " + result.ProtocolError.Value);

            }
            catch (Exception ex)
            {
                Global.BluetoothLogger.Log("Getting Services  Exception - " + ex.Message);
                string message = String.Format("Message:\n{0}\n\nInnerException:\n{1}\n\nStack:\n{2}", ex.Message, ex.InnerException, ex.StackTrace);
                Global.BluetoothLogger.Log(message);
            }
        }

        private void AddServices()
        {
            // In case we connected before, clear the service list and recreate it
            Services.Clear();

            Global.BluetoothLogger.Log("Services Found");

            foreach (GattDeviceService service in result.Services)
            {
                BluetoothService newService = new BluetoothService(this, service);
                Services.Add(newService);
                //    Publisher.RaiseEvent_ServiceFound_Event(newService);
                Global.BluetoothLogger.Log("    Service = " + newService.ToString());
            }
            EventPublisher.RaiseEvent_AllServicesFound(this);
            State = DeviceState.GotServices;
            EventPublisher.RaiseEvent_FlowState(this);
        }

        private void BluetoothLEDevice_ConnectionStatusChanged(BluetoothLEDevice sender, object args)
        {
            IsPaired = DeviceInfo.Pairing.IsPaired;
            IsConnected = (BluetoothLEDevice.ConnectionStatus == BluetoothConnectionStatus.Connected);
        }

        private void BluetoothLEDevice_NameChanged(BluetoothLEDevice sender, object args)
        {
            Name = BluetoothLEDevice.Name;
        }

        public BluetoothService GetServiceByName(string serviceName)
        {
            for (int i = 0; i < Services.Count; i++)
            {
                if (Services[i].Name.Equals(serviceName)) return Services[i];
            }
            return null;
        }

        public BluetoothCharacteristic GetCharacteristic(string serviceName, string characteristicName)
        {
            BluetoothService service = GetServiceByName(serviceName);
            if (service == null) return null;
            return service.GetCharacteristicByName(characteristicName);
        }
    }
}
