using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class BluetoothDataRow
    {
        public BluetoothBasicMessage BasicMessage { get; set; }
        public int RowNumber { get; set; }
        public List<Int16> Caps { get; set; }
        public double[] CapValues { get; set; }

        public BluetoothDataRow(BluetoothMessage message)
        {
            BasicMessage = message.BasicMessage;
            RowNumber = -1;
            Caps = new List<Int16>();
            ParseData(message.Data.GetRange(0, BasicMessage.MessageLength));
            CapValues = new double[Caps.Count];
        }

        private void ParseData(List<byte> data)
        {
            RowNumber = data[8];
            for (int i = 9; i <data.Count; i++)
            {
                Caps.Add(data[i]);
            }
        }

        public void LoadCapValues()
        {
            for(int i = 0; i < Caps.Count; i++)
            {
                try
                {
                    //   Capacitor = a * b * c;
                    //Single capValue = (Single)((Caps[i] * 8 + 2000));
                    Single capValue = (Single)(Caps[i] * 8 + 500);
                    if (capValue > Global.BluetoothCalibration.Cap2)
                    {
                        capValue = capValue * Global.BluetoothCalibration.A2 + Global.BluetoothCalibration.B2;
                    }
                    else
                    {
                        capValue = capValue * Global.BluetoothCalibration.A1 + Global.BluetoothCalibration.B1;
                    }
                    CapValues[i] = capValue;
                }
                catch { CapValues[i] = 0; }
            }
        }
    }
}
