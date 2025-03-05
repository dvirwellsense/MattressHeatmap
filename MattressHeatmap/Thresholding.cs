using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public static class Thresholding
    {
        public static Bitmap ApplyThresholding(Bitmap bitmap, List<Color> colors)
        {
            Color[,] pixels = GetPixels(bitmap);

            DirectBitmap directBitmap = new DirectBitmap(bitmap.Width, bitmap.Height);

            Color closestColor;
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    closestColor = GetClosestColorByRGB(colors, pixels[y, x]);
                    //closestColor = GetClosestColorByHues(colors, pixels[y, x]);
                    //closestColor = GetClosestColorWeighed(colors, pixels[y, x]);
                    directBitmap.SetPixel(x, y, closestColor);
                }
            }

            Bitmap result = new Bitmap(directBitmap.Bitmap);
            directBitmap.Dispose();
            return result;
        }



        private static Color[,] GetPixels(Bitmap bitmap)
        {
            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            Color[,] colors = new Color[bitmap.Height, bmpData.Width];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            int counter = 0;
            int stride = bmpData.Stride;

            byte red;
            byte green;
            byte blue;

            for (int row = 0; row < bmpData.Height; row++)
            {
                for (int column = 0; column < bmpData.Width; column++)
                {
                    blue = (byte)(rgbValues[(row * stride) + (column * 3)]);
                    green = (byte)(rgbValues[(row * stride) + (column * 3) + 1]);
                    red = (byte)(rgbValues[(row * stride) + (column * 3) + 2]);

                    colors[row, column] = Color.FromArgb((int)red, (int)green, (int)blue);

                    counter++;
                }
            }

            return colors;
        }

        // closed match for hues only:
        private static Color GetClosestColorByHues(List<Color> colors, Color color)
        {
            var hue1 = color.GetHue();
            var diffs = colors.Select(n => GetHueDistance(n.GetHue(), hue1));
            var diffMin = diffs.Min(n => n);
            int index = diffs.ToList().FindIndex(n => n == diffMin);
            return colors[index];
        }

        // closed match in RGB space
        private static Color GetClosestColorByRGB(List<Color> colors, Color color)
        {
            var colorDiffs = colors.Select(n => GetColorDifference(n, color)).Min(n => n);
            int index = colors.FindIndex(n => GetColorDifference(n, color) == colorDiffs);
            return colors[index];
        }

        // weighed distance using hue, saturation and brightness
        private static Color GetClosestColorWeighed(List<Color> colors, Color color)
        {
            float saturationFactor = 100;
            float brightnessFactor = 100;

            float hue1 = color.GetHue();
            var num1 = GetColorNum(color, saturationFactor, brightnessFactor);
            var diffs = colors.Select(n => Math.Abs(GetColorNum(n, saturationFactor, brightnessFactor) -
                num1) + GetHueDistance(n.GetHue(), hue1));
            var diffMin = diffs.Min(x => x);
            int index = diffs.ToList().FindIndex(n => n == diffMin);
            return colors[index];
        }

        // color brightness as perceived:
        private static float GetBrightness(Color color)
        {
            return (color.R * 0.299f + color.G * 0.587f + color.B * 0.114f) / 256f;
        }

        // distance between two hues:
        private static float GetHueDistance(float hue1, float hue2)
        {
            float d = Math.Abs(hue1 - hue2);
            return d > 180 ? 360 - d : d;
        }

        //  weighed only by saturation and brightness
        private static float GetColorNum(Color color, float saturationFactor, float brightnessFactor) //100, 100
        {
            return color.GetSaturation() * saturationFactor + GetBrightness(color) * brightnessFactor;
        }

        // distance in RGB space
        private static int GetColorDifference(Color color1, Color color2)
        {
            return (int)Math.Sqrt((color1.R - color2.R) * (color1.R - color2.R)
                                   + (color1.G - color2.G) * (color1.G - color2.G)
                                   + (color1.B - color2.B) * (color1.B - color2.B));
        }
    }
}
