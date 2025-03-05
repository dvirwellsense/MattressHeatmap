using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;

namespace MattressHeatmap
{
    public class BluetoothService
    {
        public GattDeviceService ServiceInfo { get; set; }
        public Guid Uuid { get; set; }
        public BluetoothDevice Device { get; set; }
        public List<BluetoothCharacteristic> Characteristics { get; set; }
        public BluetoothCharacteristic selectedCharacteristic;
        public string Name { get; set; }
        public string LogPrefix { get; set; }

        public BluetoothService(BluetoothDevice device, GattDeviceService service)
        {
            Characteristics = new List<BluetoothCharacteristic>();
            ServiceInfo = service;
            Uuid = service.Uuid;
            Device = device;
            Name = GattUuidsLib.ConvertUuidToName(service.Uuid);
            LogPrefix = "Service_" + Name + " => ";
        }

        public async void GetCharacteristics()
        {
            //var attributeInfoDisp = (BluetoothLEAttributeDisplay)ServiceList.SelectedItem;
            Global.BluetoothLogger.Log(LogPrefix + "Starting to get Characteristics");

            Characteristics.Clear();

            IReadOnlyList<GattCharacteristic> characteristics = null;
            try
            {
                // Ensure we have access to the device.
                var accessStatus = await this.ServiceInfo.RequestAccessAsync();
                if (accessStatus == DeviceAccessStatus.Allowed)
                {
                    // BT_Code: Get all the child characteristics of a service. Use the cache mode to specify uncached characterstics only 
                    // and the new Async functions to get the characteristics of unpaired devices as well. 
                    var result = await this.ServiceInfo.GetCharacteristicsAsync(BluetoothCacheMode.Uncached);
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        characteristics = result.Characteristics;
                        Global.BluetoothLogger.Log("Successfully Got Characteristics:");
                    }
                    else
                    {
                        Global.BluetoothLogger.Log(LogPrefix + "Error accessing service: " + result.Status);
                        characteristics = new List<GattCharacteristic>();
                    }
                }
                else
                {
                    // Not granted access
                    Global.BluetoothLogger.Log(LogPrefix + "Error accessing service: Not Allowed");

                    // On error, act as if there are no characteristics.
                    characteristics = new List<GattCharacteristic>();
                }
            }
            catch (Exception ex)
            {
                Global.BluetoothLogger.Log(LogPrefix + "Restricted service. Can't read characteristics: ");
                // On error, act as if there are no characteristics.
                characteristics = new List<GattCharacteristic>();
            }

            foreach (GattCharacteristic characteristic in characteristics)
            {
                Characteristics.Add(new BluetoothCharacteristic(this, characteristic));
                EventPublisher.RaiseEvent_CharacteristicFound_Event(characteristic);
                Global.BluetoothLogger.Log(LogPrefix + characteristic.Uuid.ToString());
            }
            EventPublisher.RaiseEvent_AllCharacteristicsFound(this);
            Device.State = DeviceState.GotCharacterstics;
            EventPublisher.RaiseEvent_FlowState(Device);
        }

        public BluetoothCharacteristic GetCharacteristicByName(string characteristicName)
        {
            for (int i = 0; i < Characteristics.Count; i++)
            {
                if (Characteristics[i].Name.Equals(characteristicName)) return Characteristics[i];
            }
            return null;
        }

        public void Disconnect()
        {
            for (int i = 0; i < Characteristics.Count; i++)
            {
                Characteristics[i].Disconnect();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
