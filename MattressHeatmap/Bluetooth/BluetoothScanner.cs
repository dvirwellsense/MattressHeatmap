using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;

namespace MattressHeatmap
{
    public class BluetoothScanner
    {
        private DeviceWatcher deviceWatcher;
        private string[] requestedProperties;
        private string aqsAllBluetoothLEDevices;

        public delegate void EventHandler_Device(BluetoothDevice device);
        public delegate void EventHandler_Void();

        public event EventHandler_Void ScanStarted_Event;
        public event EventHandler_Void ScanEnded_Event;
        public event EventHandler_Device DeviceAdded_Event;
        public event EventHandler_Device DeviceUpdated_Event;
        public event EventHandler_Device DeviceRemoved_Event;

        public BluetoothScanner()
        {
            requestedProperties = new string[]
               {
                "System.Devices.Connected",
                    "System.Devices.Aep.Category",
                    "System.Devices.Aep.ContainerId",
                    "System.Devices.Aep.DeviceAddress",
                    "System.Devices.Aep.IsConnected",
                    "System.Devices.Aep.IsPaired",
                    "System.Devices.Aep.IsPresent",
                    "System.Devices.Aep.ProtocolId",
                    "System.Devices.Aep.Bluetooth.Le.IsConnectable",
                    "System.Devices.Aep.SignalStrength"
                };

            aqsAllBluetoothLEDevices = "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";
        }

        public void StartScan()
        {
            StopScan();

            if (Global.Devices != null) Global.Devices.Clear();

            deviceWatcher = DeviceInformation.CreateWatcher(
                  aqsAllBluetoothLEDevices,
                  requestedProperties,
                  DeviceInformationKind.AssociationEndpoint);

            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Updated += DeviceWatcher_Updated;
            deviceWatcher.Removed += DeviceWatcher_Removed;
            deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            deviceWatcher.Stopped += DeviceWatcher_Stopped;

            deviceWatcher.Start();
            ScanStarted_Event?.Invoke();
        }

        public void StopScan()
        {
            try
            {
                if (deviceWatcher == null) return;
             
                deviceWatcher.Added -= DeviceWatcher_Added;
                deviceWatcher.Updated -= DeviceWatcher_Updated;
                deviceWatcher.Removed -= DeviceWatcher_Removed;
                deviceWatcher.EnumerationCompleted -= DeviceWatcher_EnumerationCompleted;
                deviceWatcher.Stopped -= DeviceWatcher_Stopped;

                deviceWatcher.Stop();
                deviceWatcher = null;
                ScanEnded_Event?.Invoke();
            }
            catch { };
        }

        private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation deviceInfo)
        {
            if (sender != deviceWatcher) return;
            BluetoothDevice device = new BluetoothDevice(deviceInfo);
            if (Global.GetDeviceById(device.Id) == null)
            {
                Global.Devices.Add(device);
                DeviceAdded_Event?.Invoke(device);
            }
        }

        private async void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate deviceInfoUpdate)
        {
            if (sender != deviceWatcher) return;
            BluetoothDevice device = Global.GetDeviceById(deviceInfoUpdate.Id);
            if (device == null) return;
            DeviceInformation deviceInfo = device.DeviceInfo;
            if (deviceInfo != null)
            {
                deviceInfo.Update(deviceInfoUpdate);
                device.Update();
                DeviceUpdated_Event?.Invoke(device);
            }
        }

        private async void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate deviceInfoUpdate)
        {
            if (sender != deviceWatcher) return;
            BluetoothDevice device = Global.GetDeviceById(deviceInfoUpdate.Id);
            if (device == null) return;
            Global.Devices.Remove(device);
            DeviceRemoved_Event?.Invoke(device);
        }

        private async void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object e)
        {
            if (sender == deviceWatcher) StopScan();
        }

        private async void DeviceWatcher_Stopped(DeviceWatcher sender, object e)
        {
            if (sender != deviceWatcher) return;
            ScanEnded_Event?.Invoke();
        }
    }
}
