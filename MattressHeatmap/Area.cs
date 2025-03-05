using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class Area
    {
        public int XStart { get; set; }
        public int XEnd { get; set; }
        public int YStart { get; set; }
        public int YEnd { get; set; }

        public Area()
        {
            XStart = 0;
            XEnd = 0;
            YStart = 0;
            YEnd = 0;
        }

        public Area(int xStart, int xEnd, int yStart, int yEnd)
        {
            XStart = xStart;
            XEnd = xEnd;
            YStart = yStart;
            YEnd = yEnd;
        }

        public Area(Point start, Point end)
        {
            XStart = start.X;
            XEnd = end.X;
            YStart = start.Y;
            YEnd = end.Y;
        }

        public bool IsInArea(int x, int y)
        {
            bool isXInArea = false;
            bool isYInArea = false;

            if (XStart <= x && x <= XEnd) isXInArea = true;
            else if (XEnd <= x && x <= XStart) isXInArea = true;

            if (YStart <= y && y <= YEnd) isYInArea = true;
            else if (YEnd <= y && y <= YStart) isYInArea = true;

            return (isXInArea && isYInArea);
        }

        public int GetLeftX()
        {
            return Math.Min(XStart, XEnd);
        }

        public int GetRightX()
        {
            return Math.Max(XStart, XEnd);
        }

        public int GetTopY()
        {
            return Math.Min(YStart, YEnd);
        }

        public int GetBottomY()
        {
            return Math.Max(YStart, YEnd);
        }

        public Size GetSize()
        {
            int width = Math.Abs(XEnd - XStart) + 1;
            int height = Math.Abs(YEnd - YStart) + 1;

            return new Size(width, height);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(new Point(GetLeftX(), GetTopY()), GetSize());
        }

        public override string ToString()
        {
            string result = "Row";

            Size size = GetSize();

            if (size.Height == 1) result += " " + GetTopY() + ", Column";
            else result += "s " + GetTopY() + " - " + GetBottomY() + ", Column";

            if (size.Width == 1) result += " " + GetLeftX() + ", Size ";
            else result += "s " + GetLeftX() + " - " + GetRightX() + ", Size ";

            result += size.Width + " X " + size.Height + '.';

            return result;
        }
    }
}
