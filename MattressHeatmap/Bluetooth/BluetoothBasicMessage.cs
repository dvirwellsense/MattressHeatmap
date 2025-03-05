using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public enum BleMessageStatus
    {
        kUnknownCommand = 0,
        kSuccess = 1,
        kFailed = 2
    };

    public enum BleMessageType : byte
    {
        kSelfTest = 1,
        kGetDetails = 2,
        kUpdateDetails = 3,
        kGetCalibrationValues = 4,
        kStartMeasure = 5,
        kMeasureOneFrame = 6,
        kMeasureOneRow = 7,
        kStopMeasure = 8,
        kKeepAlive = 9,
        kGetBatteryStatus = 10,
        kReset = 11,
        kMatConnection = 12,
        kReturnRow = 13,
        kFWUpdate = 14
    };

    public class BluetoothBasicMessage
    {
        public List<byte> Data { get; set; }
        public List<byte> Sync { get; set; }
        public int MessageLength { get; set; }
        public BleMessageType Type { get; set; }
        public BleMessageStatus Status { get; set; }

        public BluetoothBasicMessage(List<byte> data)
        {
            Data = data;
            ParseMessage();
        }

        public void ParseMessage()
        {
            Sync = Data.GetRange(0, 4);
            MessageLength = BitConverter.ToInt16(Data.ToArray(), 4);
            Type = (BleMessageType)Data[6];
            Status = (BleMessageStatus)Data[7];
        }
    }
}
