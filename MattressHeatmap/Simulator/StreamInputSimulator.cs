using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class StreamInputSimulator
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<StreamPressurePoint> PressurePoints { get; set; }
        public double Step { get; set; }
        public Queue<double[,]> InputArrays { get; set; }
        public int Interval { get; set; }
        public int NumberOfPressurePoints { get; set; }
        public bool IsActive { get; set; }
        public string ComPort { get; set; }


        private Random rnd;
        private SerialPortDataSender serialPortDataSender;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

        public delegate void EventHandler_InputUpdated(double[,] newInput);
        public event EventHandler_InputUpdated InputUpdated_Event;

        public StreamInputSimulator(int width, int height, int numberOfPressurePoints, string comPort)
        {
            Width = width;
            Height = height;
            PressurePoints = new List<StreamPressurePoint>();
            Step = 0.075;
            InputArrays = new Queue<double[,]>();
            Interval = 1000;
            NumberOfPressurePoints = numberOfPressurePoints;
            IsActive = false;
            ComPort = comPort;

            rnd = new Random();
            serialPortDataSender = new SerialPortDataSender(ComPort);
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            for (int i = 0; i < NumberOfPressurePoints; i++)
            {
                PressurePoints.Add(GetNewPressurePoint());
            }
        }

        public void Start()
        {
            serialPortDataSender.Start();
            IsActive = true;
            Task SimulatorTask = Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        for (int i = PressurePoints.Count - 1; i >= 0; i--)
                        {
                            StreamPressurePoint pressurePoint = PressurePoints[i];

                            AdjustDensitySimple(pressurePoint);

                            if (pressurePoint.Density >= GetMaxDensity(pressurePoint))
                            {
                                PressurePoints.Remove(pressurePoint);
                            }
                        }
                        while (PressurePoints.Count < NumberOfPressurePoints)
                        {
                            PressurePoints.Add(GetNewPressurePoint());
                        }

                        //InputArrays.Enqueue(GenerateArray());
                        //InputUpdated_Event?.Invoke(GenerateArray());
                        serialPortDataSender.DataToSend.Enqueue(GenerateArray());

                        cancellationToken.ThrowIfCancellationRequested();

                        Thread.Sleep(Interval);
                    }

                }
                catch (OperationCanceledException e)
                {
                    serialPortDataSender.Stop();

                    cancellationTokenSource.Dispose();
                    cancellationTokenSource = new CancellationTokenSource();
                    cancellationToken = cancellationTokenSource.Token;
                }

            }, cancellationToken);
        }

        public void Stop()
        {
            cancellationTokenSource.Cancel();
        }

        private StreamPressurePoint GetNewPressurePoint()
        {
            double heatMin = 0.7;

            int line = rnd.Next(Height);
            int col = rnd.Next(Width);
            double heatValue = rnd.NextDouble() * (1 - heatMin) + heatMin;
            double density = heatValue / 2;
            double minDensity = 0.06 + (rnd.NextDouble() * 0.03);
            double speed = 0.01;

            return new StreamPressurePoint(col, line, heatValue, density, minDensity, PressurePointState.FadeIn, speed);
        }

        private void AdjustDensitySimple(StreamPressurePoint pressurePoint)
        {
            double currentDensity = pressurePoint.Density;
            double increment = pressurePoint.Speed;
            double densityRatio = (currentDensity - pressurePoint.MinDensity)
                / (GetMaxDensity(pressurePoint) - pressurePoint.MinDensity);
            if (densityRatio > 0.5) increment *= 3;
            if (pressurePoint.State == PressurePointState.FadeIn)
            {
                pressurePoint.Density = currentDensity - increment;
                if (pressurePoint.Density <= pressurePoint.MinDensity)
                    pressurePoint.State = PressurePointState.FadeOut;
            }
            else if (pressurePoint.State == PressurePointState.FadeOut)
                pressurePoint.Density = currentDensity + increment;
        }

        private void AdjustDensity(StreamPressurePoint pressurePoint)
        {
            double functionMinX = 1;
            double functionMaxX = 6;

            double functionMinY = ApplyDensityFunction(functionMinX);
            double functionMaxY = ApplyDensityFunction(functionMaxX);

            double minDensity = pressurePoint.MinDensity;
            double maxDensity = GetMaxDensity(pressurePoint);

            double currentDensity = pressurePoint.Density;

            // 0 to 1
            double ratioX = (currentDensity - minDensity) / (maxDensity - minDensity);

            if (pressurePoint.State == PressurePointState.FadeIn)
                ratioX = ratioX - pressurePoint.Speed;
            else if (pressurePoint.State == PressurePointState.FadeOut)
                ratioX = ratioX + pressurePoint.Speed;

            if (ratioX > 1) ratioX = 1;
            if (ratioX < 0)
            {
                ratioX = 0;
                if (pressurePoint.State == PressurePointState.FadeIn)
                    pressurePoint.State = PressurePointState.FadeOut;
            }


            double functionCurrentX = functionMinX + (ratioX * (functionMaxX - functionMinX));

            double functionResult = ApplyDensityFunction(functionCurrentX);

            double ratioY = (functionResult - functionMinY) / (functionMaxY - functionMinY);

            double resultDensity = minDensity + (ratioY * (maxDensity - minDensity));

            pressurePoint.Density = resultDensity;
        }

        private double ApplyDensityFunction(double value)
        {
            //return Math.Log10(value);
            return (1 / value);
        }

        private static double GetMaxDensity(StreamPressurePoint pressurePoint)
        {
            return pressurePoint.HeatValue / 2;
        }

        public void SetSerialPortByReference(SerialPort port)
        {
            serialPortDataSender.SerialPort = port;
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
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    StreamPressurePoint pressurePoint = GetNearestPressurePoint(i, j);
                    double distance = GetDistance(i, j, pressurePoint);
                    double heatValue = -1;
                    if (distance == 0) heatValue = pressurePoint.HeatValue;
                    else
                    {
                        heatValue = pressurePoint.HeatValue - (pressurePoint.Density * distance);
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
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = 0;
                }
            }
            return arr;
        }

        private StreamPressurePoint GetNearestPressurePoint(int line, int col)
        {
            double minDistance = double.MaxValue;
            int nearestPressurePointIndex = -1;
            for (int i = 0; i < PressurePoints.Count; i++)
            {
                StreamPressurePoint pressurePoint = PressurePoints[i];
                double distance = GetDistance(line, col, pressurePoint);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestPressurePointIndex = i;
                }
            }
            return PressurePoints[nearestPressurePointIndex];
        }

        private double GetDistance(int x, int y, StreamPressurePoint pressurePoint)
        {
            return Math.Sqrt(Math.Pow(x - pressurePoint.X, 2) + Math.Pow(y - pressurePoint.Y, 2));
        }

        public string WriteArrayAsParameters()
        {
            string result = "{";
            double[,] arr = GenerateArray();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                result = result + "{";
                for (int j = 0; j < arr.GetLength(1); j++)
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

        public int GetDataQueueCount()
        {
            return serialPortDataSender.DataToSend.Count;
        }
    }
}
