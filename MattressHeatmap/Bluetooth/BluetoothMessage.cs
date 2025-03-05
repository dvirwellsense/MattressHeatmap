using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class BluetoothMessage
    {
        public List<byte> Data { get; set; }
        public BluetoothBasicMessage BasicMessage { get; set; }

        public BluetoothMessage(List<byte> data)
        {
            Data = data;
            BasicMessage = new BluetoothBasicMessage(Data.GetRange(0, 8));
        }
    }
}
