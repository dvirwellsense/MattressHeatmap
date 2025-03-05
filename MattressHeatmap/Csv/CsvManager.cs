using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public static class CsvManager
    {
        public static void WriteCsv(string path, Frame frame)
        {
            string allText = "Caps\r\n" + GetArrayValuesString(frame.Caps) + "\r\n\r\nPressures\r\n" + GetArrayValuesString(frame.Pressures);
            File.WriteAllText(path, allText);
        }

        public static Frame ReadCsv(string path)
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            int seperatorIndex = lines.IndexOf("");
            double[,] caps = GetArray(lines.GetRange(2, seperatorIndex - 2));
            double[,] pressures = GetArray(lines.GetRange(seperatorIndex + 3, lines.Count - seperatorIndex - 3)); //Can also use the first length
            return new Frame(caps, pressures);
        }

        private static string GetArrayValuesString(double[,] arr)
        {
            string result = GetArrayValuesHeader(arr.GetLength(1));

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                result += "Row " + i + ",";
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result += arr[i, j].ToString();
                    if (j < arr.GetLength(1) - 1) result += ",";
                }
                if (i < arr.GetLength(0) - 1) result += "\r\n";
            }

            return result;
        }

        private static string GetArrayValuesHeader(int numOfCols)
        {
            string result = "\\,";

            for (int i = 0; i < numOfCols; i++)
            {
                result += "Col " + i;
                if (i < numOfCols - 1) result += ",";
            }

            result += "\r\n";
            return result;
        }

        private static double[,] GetArray(List<string> lines)
        {
            double[,] arr = new double[lines.Count, lines[0].Split(',').Length - 1];

            for (int i = 0; i < lines.Count; i++)
            {
                string[] fields = lines[i].Split(',');
                for (int j = 1; j < fields.Length; j++)
                {
                    arr[i, j - 1] = double.Parse(fields[j]);
                }
            }

            return arr;
        }

        private static void Test()
        {
            File.WriteAllText("C:\\work\\MattressHeatmap\\Csv\\test.csv", "1,2,3,4,5\r\n6,7,8,9,10");
        }
    }
}
