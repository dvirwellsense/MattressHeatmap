using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class BluetoothCalibration_Old
    {
        public Single A1 { get; set; }
        public Single A2 { get; set; }
        public Single B1 { get; set; }
        public Single B2 { get; set; }
        public Single Cap1 { get; set; }
        public Single Cap2 { get; set; }
        public Single Cap3 { get; set; }
        public Single Cap_Ad1 { get; set; }
        public Single Cap_Ad2 { get; set; }
        public Single Cap_Ad3 { get; set; }
        public bool IsValid { get; set; }

        public BluetoothCalibration_Old()
        {

        }

        public BluetoothCalibration_Old(BluetoothMessage message)
        {
            ParseData(message);
        }

        public void ParseData(BluetoothMessage message)
        {
            byte[] dataArray = message.Data.GetRange(0, message.BasicMessage.MessageLength).ToArray();
            try
            {
                Single RefCap1 = ((Single)((UInt16)dataArray[9] + (UInt16)dataArray[8] * 256)) / 10;
                Single RefCap2 = ((Single)((UInt16)dataArray[11] + (UInt16)dataArray[10] * 256)) / 10;
                Single RefCap3 = ((Single)((UInt16)dataArray[13] + (UInt16)dataArray[12] * 256)) / 10;
                Single RefCapAd1 = (Single)((UInt16)dataArray[15] + (UInt16)dataArray[14] * 256);
                Single RefCapAd2 = (Single)((UInt16)dataArray[17] + (UInt16)dataArray[16] * 256);
                Single RefCapAd3 = (Single)((UInt16)dataArray[19] + (UInt16)dataArray[18] * 256);


                Cap_Ad1 = RefCapAd1;
                Cap_Ad2 = RefCapAd2;
                Cap_Ad3 = RefCapAd3;

                Cap1 = RefCap1;
                Cap2 = RefCap2;
                Cap3 = RefCap3;

                A1 = (RefCap2 - RefCap1) / (RefCapAd2 - RefCapAd1);
                A2 = (RefCap3 - RefCap2) / (RefCapAd3 - RefCapAd2);

                B1 = RefCap2 - A1 * RefCapAd2;
                B2 = RefCap3 - A2 * RefCapAd3;
                Cap_Ad2 = RefCapAd2;
                IsValid = true;
                EventPublisher.RaiseEvent_GotCalibration();
            }
            catch { IsValid = false; }
        }
    }
}
