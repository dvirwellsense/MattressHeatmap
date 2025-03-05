using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class BluetoothDeviceDisplay
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public bool Paired { get; set; }
        public bool Connected { get; set; }
        public bool Connectable { get; set; }
        public int SignalStrength { get; set; }

        public BluetoothDeviceDisplay(BluetoothDevice device)
        {
            Update(device);
        }

        public void Update(BluetoothDevice device)
        {
            Name = device.Name;
            Id = device.Id;
            Address = device.BtAddress;
            Paired = device.IsPaired;
            Connected = device.IsConnected;
            Connectable = device.IsConnectable;
            SignalStrength = device.Rssi;
        }
    }
}
