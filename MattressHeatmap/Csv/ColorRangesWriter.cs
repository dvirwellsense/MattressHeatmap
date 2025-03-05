using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public static class ColorRangesWriter
    {
        public static void SaveColorRanges(List<ColorRange> colorRanges, HeatMapType type)
        {
            string allText = GetHeader() + GetRows(colorRanges);
            File.WriteAllText(GetPath(type), allText);
        }

        public static List<ColorRange> LoadColorRanges(HeatMapType type)
        {
            string[] lines = File.ReadAllLines(GetPath(type));
            return GetColorRanges(lines);
        }

        private static string GetHeader()
        {
            return "Red,Green,Blue,Start,End\r\n";
        }

        private static string GetRow(ColorRange colorRange)
        {
            return "" + (int)colorRange.Color.R + "," + (int)colorRange.Color.G + "," + (int)colorRange.Color.B
                + "," + colorRange.Start.ToString() + ',' + colorRange.End.ToString();
        }

        private static string GetRows(List<ColorRange> colorRanges)
        {
            string result = "";

            for(int i = 0; i < colorRanges.Count; i++)
            {
                result += GetRow(colorRanges[i]);
                if (i < colorRanges.Count - 1) result += "\r\n";
            }

            return result;
        }

        private static List<ColorRange> GetColorRanges(string[] csvLines)
        {
            List<ColorRange> colorRanges = new List<ColorRange>();

            for(int i = 1; i < csvLines.Length; i++)
            {
                colorRanges.Add(GetColorRange(csvLines[i]));
            }

            return colorRanges;
        }

        private static ColorRange GetColorRange(string line)
        {
            string[] fields = line.Split(',');

            int red = int.Parse(fields[0]);
            int green = int.Parse(fields[1]);
            int blue = int.Parse(fields[2]);

            double start = double.Parse(fields[3]);
            double end = double.Parse(fields[4]);

            Color color = Color.FromArgb(red, green, blue);

            return new ColorRange(start, end, color);
        }

        private static string GetPath(HeatMapType type)
        {
            if(type == HeatMapType.Caps)
                return Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\ColorRanges\\Caps.csv";
            else return Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\ColorRanges\\Pressures.csv";
        }

        public static string Test()
        {
            return "";
        }
    }
}
