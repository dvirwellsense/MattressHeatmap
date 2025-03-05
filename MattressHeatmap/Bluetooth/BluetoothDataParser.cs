using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    

    public class BluetoothDataParser
    {
        public List<byte> Data { get; set; }
        public BluetoothBasicMessage BasicMessage { get; set; }

        public BluetoothDataParser(List<byte> data)
        {
            Data = data;
            BasicMessage = new BluetoothBasicMessage(Data.GetRange(0, 8));
        }

        public void HandleMessage()
        {
            switch (BasicMessage.Type)
            {
                case BleMessageType.kGetCalibrationValues:
                    HandleCalibrationMessage();
                    break;

                case BleMessageType.kGetDetails:
                    HandleDetailsMessage();
                    break;

                case BleMessageType.kReturnRow:
                    HandleRowMessage();
                    break;
            }
        }

        private void HandleCalibrationMessage()
        {
            //Global.BluetoothCalibration = new BluetoothCalibration(this);
        }

        private void HandleDetailsMessage()
        {

        }

        private void HandleRowMessage()
        {

        }
    }
}
