using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class Lut
    {
        public double[,,] Values { get; set; }
        public int MatId { get; set; }
        public bool IsValid { get; set; }

        public Lut()
        {
            Values = null;
            MatId = -1;
            IsValid = false;
        }

        public void ParseOvcParams(List<byte> data)
        {
            try
            {
                byte numberOfRows = data[25];
                byte numberOfColumns = Convert.ToByte(data[24] + 1);

                MatId = (int)BitConverter.ToUInt32(data.ToArray(), 16);

                Values = new double[numberOfRows, numberOfColumns, 4];
                IsValid = true;
            }
            catch
            {
                IsValid = false;
            }
            
        }

        public void ParseLutRow(List<byte> data)
        {
            try
            {
                int rowIndex = data[12] << data[13];

                for (int i = 0; i < Values.GetLength(1) - 1; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Values[rowIndex, i, j] = BitConverter.ToSingle(data.ToArray(), (14 + (4 * j) + (i * 16)));
                    }
                }

                IsValid = true;
            }
            catch
            {
                IsValid = false;
            }
        }

        public void ParseData(List<byte> data)
        {
            SubTypeT type = (SubTypeT)data[8];
            if (type == SubTypeT.kGetOvcParamsAtOnceResponse) ParseOvcParams(data);
            else if (type == SubTypeT.kGetLutAtOnceResponse) ParseLutRow(data);
        }
    }
}
