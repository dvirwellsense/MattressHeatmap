using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class BluetoothCalibration
    {
        public Single Cap1 { get; set; }
        public Single Cap2 { get; set; }
        public Single Cap3 { get; set; }
        public int ADC1 { get; set; }
        public int ADC2 { get; set; }
        public int ADC3 { get; set; }
        public Single A1 { get; set; }
        public Single B1 { get; set; }
        public Single A2 { get; set; }
        public Single B2 { get; set; }
        public bool IsValid { get; set; }

        public BluetoothCalibration()
        {

        }

        public BluetoothCalibration(BluetoothMessage message)
        {
            ParseData(message.Data.GetRange(0, message.BasicMessage.MessageLength).ToArray());
        }

        public void ParseData(byte[] data)
        {
            try
            {
                Single multiplier = 1E-12f;

                Cap1 = (Single)(UInt16)data[8] * multiplier;
                Cap2 = (Single)(UInt16)data[9] * multiplier;
                Cap3 = (Single)(UInt16)data[10] * multiplier;

                ADC1 = BitConverter.ToInt16(data, 11);
                ADC2 = BitConverter.ToInt16(data, 13);
                ADC3 = BitConverter.ToInt16(data, 15);

                A1 = (Cap2 - Cap1) / (ADC2 - ADC1);
                A2 = (Cap3 - Cap2) / (ADC3 - ADC2);

                B1 = Cap2 - A1 * ADC2;
                B2 = Cap3 - A2 * ADC3;

                IsValid = true;
                EventPublisher.RaiseEvent_GotCalibration();
            }
            catch { IsValid = false; }
        }

    }
}
