using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class BluetoothControlCharacteristics
    {
        public BluetoothCharacteristic CommandCharacteristic { get; set; }
        public BluetoothCharacteristic ResponseCharacteristic { get; set; }
        public BluetoothCharacteristic DataCharacteristic { get; set; }
        public string ControlServiceName { get; set; }
        public string CommandCharacteristicName { get; set; }
        public string ResponseCharacteristicName { get; set; }
        public string DataCharacteristicName { get; set; }

        public BluetoothControlCharacteristics()
        {
            CommandCharacteristic = null;
            ResponseCharacteristic = null;
            DataCharacteristic = null;

            ControlServiceName = Properties.Settings.Default.ControlServiceName;
            CommandCharacteristicName = Properties.Settings.Default.CommandCharacteristicName;
            ResponseCharacteristicName = Properties.Settings.Default.ResponseCharacteristicName;
            DataCharacteristicName = Properties.Settings.Default.DataCharacteristicName;
        }

        public void Load()
        {
            if (Global.CurrentDevice == null) return;
            CommandCharacteristic = Global.CurrentDevice.GetCharacteristic(ControlServiceName, CommandCharacteristicName);
            ResponseCharacteristic = Global.CurrentDevice.GetCharacteristic(ControlServiceName, ResponseCharacteristicName);
            DataCharacteristic = Global.CurrentDevice.GetCharacteristic(ControlServiceName, DataCharacteristicName);
        }
    }
}
