using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public static class SamplesWriter
    {
        private static string path = "";
        private static Area area = null;
        private static bool includePressures = true;
        private static object locker = new object();

        public static void StartWriting(Area chosenArea, bool isIncludePressures)
        {
            path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Temp\\temp.csv";

            area = chosenArea;
            includePressures = isIncludePressures;

            if (File.Exists(path)) File.Delete(path);

            string headerText = GetHeaderText();

            File.WriteAllText(path, headerText);
        }

        public static void WriteFrame(Frame frame, int time)
        {
            Task frameWriteTask = Task.Run(() =>
            {
                lock (locker)
                {
                    File.AppendAllText(path, GetFrameText(frame, time));
                }
            });
        }

        public static int StopWriting(string destinationPath)
        {
            try
            {
                if (File.Exists(destinationPath)) File.Delete(destinationPath);

                File.Move(path, destinationPath);

                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        private static string GetFrameText(Frame frame, int time)
        {
            string text = GetTimeString(time) + ',';

            int rows = frame.Caps.GetLength(0);
            int columns = frame.Caps.GetLength(1);

            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (k == 0) text += frame.Caps[i, j].ToString();
                        else text += frame.Pressures[i, j].ToString();
                        if (i < rows - 1 || j < columns - 1 || k == 0) text += ',';
                    }
                }

                if (!includePressures) k++;
                if (k == 0) text += ',';
            }

            text += "\r\n";

            return text;
        }

        private static string GetHeaderText()
        {
            string text = "Time [h : m : s : ms],Caps";

            Size size = area.GetSize();
            int rows = size.Height;
            int columns = size.Width;
            int startRow = area.GetTopY();
            int startColumn = area.GetLeftX();

            if (includePressures)
            {
                int fields = rows * columns;
                for (int i = 0; i < fields + 1; i++)
                {
                    text += ',';
                }

                text += "Pressures";
            }

            text += "\r\nRow,";

            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        text += (i + startRow).ToString() + ',';
                    }
                }

                if (!includePressures) k++;
                if (k == 0) text += ',';
            }

            text += "\r\nColumn,";

            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        text += (j + startColumn).ToString();
                        if (i < rows - 1 || j < columns - 1 || k == 0) text += ',';
                    }
                }

                if (!includePressures) k++;
                if (k == 0) text += ',';
            }

            text += "\r\n";

            return text;
        }

        private static string GetTimeString(int time)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(time);
            return timeSpan.ToString("h' : 'm' : 's' : '") + timeSpan.Milliseconds.ToString();
            //return timeSpan.ToString("h'h 'm'm 's's'") + ' ' + timeSpan.Milliseconds.ToString() + "ms";
        }

        public static string Test()
        {
            return GetTimeString(1234);
            //return GetTimeString(3849234);
        }
    }
}
