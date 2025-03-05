using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class Global
    {
        public static Lut Lut = new Lut();

        public static List<BluetoothDevice> Devices;
        public static BluetoothDevice CurrentDevice;
        public static Logger BluetoothLogger;
        public static BluetoothControlCharacteristics ControlCharacteristics;
        public static BluetoothCalibration BluetoothCalibration;
        public static BluetoothDetails BluetoothDetails = null;

        public static double DevelopmentA;
        public static double DevelopmentB;
        public static double DevelopmentC;
        public static bool IsParseBusy = false;

        public static BluetoothDevice GetDeviceById(string id)
        {
            foreach (BluetoothDevice device in Devices)
            {
                if (device.DeviceInfo.Id.Equals(id)) return device;
            }
            return null;
        }
    }
}
