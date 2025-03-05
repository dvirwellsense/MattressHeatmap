using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public enum Axis { X, Y }

    public static class Interpolation
    {
        public static double[,] PerformLinearInterpolation(double[,] heatValues, int destWidth, int destHeight)
        {
            double[,] intensities = GetEmptyArray(destWidth, destHeight);
            Point[,] heatValueLocations = InsertValuesToArray(heatValues, intensities);

            Interpolate(intensities, heatValueLocations);

            return intensities;
        }

        public static Bitmap PerformLinearInterpolation(double[,] heatValues, int destWidth, int destHeight, List<ColorRange> colorRanges, HeatMapType type)
        {
            double[,] intensities = PerformLinearInterpolation(heatValues, destWidth, destHeight);

            DirectBitmap directBitmap = new DirectBitmap(destWidth, destHeight);
            Color pixelColor;

            for (int y = 0; y < destHeight; y++)
            {
                for (int x = 0; x < destWidth; x++)
                {
                    pixelColor = Lib.GetColor(intensities[y, x], colorRanges, type);
                    directBitmap.SetPixel(x, y, pixelColor);
                }
            }

            Bitmap result = new Bitmap(directBitmap.Bitmap);
            directBitmap.Dispose();
            return result;
        }

        private static Point[,] InsertValuesToArray(double[,] inputArr, double[,] destArr)
        {
            Point[,] locations = new Point[inputArr.GetLength(0), inputArr.GetLength(1)];

            SizeF stepSize = GetStepSize(inputArr, destArr);

            for (int y = 0; y < inputArr.GetLength(0); y++)
            {
                for (int x = 0; x < inputArr.GetLength(1); x++)
                {
                    int destX = (int)((stepSize.Width / 2F) + ((float)x * stepSize.Width));
                    int destY = (int)((stepSize.Height / 2F) + ((float)y * stepSize.Height));

                    destArr[destY, destX] = inputArr[y, x];

                    locations[y, x] = new Point(destX, destY);
                }
            }

            return locations;
        }

        private static void Interpolate(double[,] arr, Point[,] locations)
        {
            InterpolateYAxis(arr, locations);
            InterpolateXAxis(arr, locations);
            FillEdges(arr, locations[0, 0], locations[locations.GetLength(0) - 1, locations.GetLength(1) - 1]);
        }

        private static void Interpolate(double[,] arr, SizeF stepSize)
        {
            InterpolateYAxis(arr, stepSize);
            InterpolateXAxis(arr, stepSize);
        }

        private static void InterpolateYAxis(double[,] arr, Point[,] locations) //Traverses only the value contained locations
        {
            for (int x = 0; x < locations.GetLength(1); x++)
            {
                for (int y = 0; y < locations.GetLength(0) - 1; y++)
                {
                    InterpolateSpan(arr, locations[y, x], locations[y + 1, x]);
                }

                //InterpolateSpan(arr, locations[locations.GetLength(0) - 1, x], Axis.Y);
            }
        }

        private static void InterpolateYAxis(double[,] arr, SizeF stepSize) //Traverses only the value contained locations
        {
            for (float x = (stepSize.Width / 2F); x < arr.GetLength(1); x += stepSize.Width)
            {
                for (float y = stepSize.Height / 2F; y < arr.GetLength(0); y += stepSize.Height)
                {
                    int step = (int)(y + stepSize.Height) - (int)y;
                    InterpolateSpan(arr, (int)x, (int)y, step, Axis.Y);
                }
            }
        }

        private static void InterpolateXAxis(double[,] arr, Point[,] locations) //Traverses all locations
        {
            for (int y = 0; y < locations.GetLength(0) - 1; y++)
            {
                for (int x = 0; x < locations.GetLength(1) - 1; x++)
                {
                    Point start = locations[y, x];
                    Point end = locations[y + 1, x + 1];

                    for (int yReal = start.Y; yReal < end.Y; yReal++)
                    {
                        InterpolateSpan(arr, new Point(start.X, yReal), new Point(end.X, yReal));
                    }
                }

                //Interpolate
            }
        }

        private static void InterpolateXAxis(double[,] arr, SizeF stepSize) //Traverses all locations
        {
            for (int y = (int)stepSize.Height / 2; y < arr.GetLength(0); y++)
            {
                for (float x = stepSize.Width / 2F; x < arr.GetLength(1); x += stepSize.Width)
                {
                    int step = (int)(x + stepSize.Width) - (int)x;
                    InterpolateSpan(arr, (int)x, y, step, Axis.X);
                }
            }
        }

        private static void FillEdges(double[,] arr, Point edgesStart, Point edgesEnd)
        {
            for(int x = edgesStart.X; x < edgesEnd.X; x++)
            {
                InterpolateSpan(arr, new Point(x, edgesStart.Y), Axis.Y, true);
                InterpolateSpan(arr, new Point(x, edgesEnd.Y), Axis.Y, false);
            }

            for(int y = 0; y < arr.GetLength(0); y++)
            {
                InterpolateSpan(arr, new Point(edgesStart.X, y), Axis.X, true);
                InterpolateSpan(arr, new Point(edgesEnd.X, y), Axis.X, false);
            }
        }

        private static void InterpolateSpan(double[,] arr, Point start, Point end)
        {
            double diffIncrement;

            if (start.Y == end.Y) //X Axis
            {
                diffIncrement = (arr[end.Y, end.X] - arr[start.Y, start.X]) / (end.X - start.X);

                for (int i = start.X + 1; i < end.X; i++)
                {
                    arr[start.Y, i] = arr[start.Y, start.X] + (diffIncrement * (i - start.X));
                    if (arr[start.Y, i] < 0) arr[start.Y, i] = 0;
                }
            }
            else
            {
                diffIncrement = (arr[end.Y, end.X] - arr[start.Y, start.X]) / (end.Y - start.Y);

                for (int i = start.Y + 1; i < end.Y; i++)
                {
                    arr[i, start.X] = arr[start.Y, start.X] + (diffIncrement * (i - start.Y));
                    if (arr[i, start.X] < 0) arr[i, start.X] = 0;
                }
            }
        }

        private static void InterpolateSpan(double[,] arr, Point start, Axis axis, bool isReverse)
        {
            double value = arr[start.Y, start.X];

            if (isReverse)
            {
                if (axis == Axis.X)
                {
                    for (int i = start.X - 1; i >= 0; i--)
                    {
                        arr[start.Y, i] = value;
                    }
                }
                else
                {
                    for (int i = start.Y - 1; i >= 0; i--)
                    {
                        arr[i, start.X] = value;
                    }
                }
            }
            else
            {
                if (axis == Axis.X)
                {
                    for (int i = start.X + 1; i < arr.GetLength(1); i++)
                    {
                        arr[start.Y, i] = value;
                    }
                }
                else
                {
                    for (int i = start.Y + 1; i < arr.GetLength(0); i++)
                    {
                        arr[i, start.X] = value;
                    }
                }
            }
        }


        private static void InterpolateSpan(double[,] arr, int x, int y, int step, Axis axis)
        {
            int nextLocationValue;
            double diffIncrement;

            if (axis == Axis.X)
            {
                nextLocationValue = x + step;

                if (nextLocationValue < arr.GetLength(1))
                {
                    diffIncrement = (arr[y, nextLocationValue] - arr[y, x]) / (nextLocationValue - x);

                    for (int i = x + 1; i < nextLocationValue; i++)
                    {
                        arr[y, i] = arr[y, x] + (diffIncrement * (i - x));
                        if (arr[y, i] < 0) arr[y, i] = 0;
                    }
                }
                else
                {
                    for (int i = x + 1; i < arr.GetLength(1); i++)
                    {
                        arr[y, i] = arr[y, x];
                    }
                }

            }
            else
            {
                nextLocationValue = y + step;

                if (nextLocationValue < arr.GetLength(0))
                {
                    diffIncrement = (arr[nextLocationValue, x] - arr[y, x]) / (nextLocationValue - y);

                    for (int i = y + 1; i < nextLocationValue; i++)
                    {
                        arr[i, x] = arr[y, x] + (diffIncrement * (i - y));
                        if (arr[i, x] < 0) arr[i, x] = 0;
                    }
                }
                else
                {
                    for (int i = y + 1; i < arr.GetLength(0); i++)
                    {
                        arr[i, x] = arr[y, x];
                    }
                }
            }
        }

        private static SizeF GetStepSize(double[,] inputArr, double[,] destArr)
        {
            float stepWidth = (float)destArr.GetLength(1) / (float)inputArr.GetLength(1);
            float stepHeight = (float)destArr.GetLength(0) / (float)inputArr.GetLength(0);

            return new SizeF(stepWidth, stepHeight);
        }

        private static double[,] GetEmptyArray(int width, int height)
        {
            double[,] result = new double[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result[y, x] = 0;
                }
            }

            return result;
        }
    }
}
