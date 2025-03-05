using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class BluetoothDetails
    {
        public int PcbMajorVersion { get; set; }
        public int PcbMinorVersion { get; set; }
        public int FwMajorVersion { get; set; }
        public int FwMinorVersion { get; set; }
        public int FwBuildVersion { get; set; }
        public int MatMajorVersion { get; set; }
        public int MatMinorVersion { get; set; }
        public int NumOfRows { get; set; }
        public int NumOfCols { get; set; }
        public int MeasuringRate { get; set; }

        public BluetoothDetails()
        {

        }

        public BluetoothDetails(BluetoothMessage message)
        {
            ParseData(message.Data.GetRange(0, message.BasicMessage.MessageLength).ToArray());
        }

        public void ParseData(byte[] data)
        {
            PcbMajorVersion = data[8];
            PcbMinorVersion = data[9];
            FwMajorVersion = data[10];
            FwMinorVersion = data[11];
            FwBuildVersion = data[12];
            MatMajorVersion = data[13];
            MatMinorVersion = data[14];
            NumOfRows = data[15];
            NumOfCols = data[16];
            MeasuringRate = data[17];
        }
    }
}
