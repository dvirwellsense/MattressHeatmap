using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class HeatMapInputSimulator
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<PressurePoint> PressurePoints { get; set; }
        public double Step { get; set; }

        public HeatMapInputSimulator(int width, int height)
        {
            Width = width;
            Height = height;
            PressurePoints = new List<PressurePoint>();
            Step = 0.075;
        }

        public string GenerateInput()
        {
            return ConvertArrayToInput(GenerateArray());
        }

        public double[,] GenerateArray()
        {
            double[,] arr = CreateSetupArray();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    PressurePoint pressurePoint = GetNearestPressurePoint(i, j);
                    double distance = GetDistance(i, j, pressurePoint);
                    double heatValue = -1;
                    if (distance == 0) heatValue = pressurePoint.HeatValue;
                    else
                    {
                        heatValue = pressurePoint.HeatValue - (Step * distance);
                        if (heatValue < 0) heatValue = 0;
                    }
                    arr[i, j] = heatValue;
                }
            }
            return arr;
        }

        private string ConvertArrayToInput(double[,] arr)
        {
            string result = "<";
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    result = result + arr[i, j].ToString();
                    if (j < arr.GetLength(1) - 1) result = result + ",";
                }
                if (i < arr.GetLength(0) - 1) result = result + ":";
            }
            result = result + ">";
            return result;
        }

        private double[,] CreateSetupArray()
        {
            double[,] arr = new double[Width, Height];
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = 0;
                }
            }
            return arr;
        }

        private PressurePoint GetNearestPressurePoint(int line, int col)
        {
            double minDistance = double.MaxValue;
            int nearestPressurePointIndex = -1;
            for(int i = 0; i < PressurePoints.Count; i++)
            {
                PressurePoint pressurePoint = PressurePoints[i];
                double distance = GetDistance(line, col, pressurePoint);
                if (distance < minDistance) 
                {
                    minDistance = distance;
                    nearestPressurePointIndex = i;
                } 
            }
            return PressurePoints[nearestPressurePointIndex];
        }

        private double GetDistance(int x, int y, PressurePoint pressurePoint)
        {
            return Math.Sqrt(Math.Pow(x - pressurePoint.X, 2) + Math.Pow(y - pressurePoint.Y, 2));
        }

        public string WriteArrayAsParameters()
        {
            string result = "{";
            double[,] arr = GenerateArray();
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                result = result + "{";
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    result = result + arr[i, j].ToString();
                    if (j < arr.GetLength(1) - 1) result = result + ", ";
                }
                result = result + "}";
                if (i < arr.GetLength(0) - 1) result = result + ",";
            }
            result = result + "};";
            return result;
        }

    }
}
