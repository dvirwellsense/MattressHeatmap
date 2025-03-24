using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media.Audio;

namespace MattressHeatmap
{
    public class SerialPortDataReciever
    {
        public string ComPort { get; set; }

        public SerialPort port { get; set; }

        public bool IsDevelopmentMode { get; set; }

        public delegate void EventHandler_Void();
        public delegate void EventHandler_String(string value);
        public delegate void EventHandler_Data(double[,] data);
        public delegate void EventHandler_Meta(List<string> metadata);
        public delegate void EventHandler_Messages(List<List<byte>> messages);

        public event EventHandler_Void PortClosed_Event;
        public event EventHandler_String RawDataArrived_Event;
        public event EventHandler_Data DataArrived_Event;
        public event EventHandler_Meta MetaArrived_Event;
        public event EventHandler_Messages MessagesArrived_Event;


        public static object Locker = new object();

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

        private List<byte> buffer;
        private List<DataRow> rowsBuffer;
        private DataRow[] rowsArr;
        private List<List<byte>> messagesBuffer;

        private bool isLutDone;

        private string developmentBuffer;
        private List<DevelopmentDataRow> developmentRowsBuffer;
        private List<string> developmentMessagesBuffer;

        System.Diagnostics.Stopwatch watch;
        System.Diagnostics.Stopwatch watch2;
        private bool debugMessagesOn;
        private int debugMessagesCounter;

        private string testBuffer;

        private SerialPortManager serialPortManager;

        private bool inProgress;

        public static int MAX_VALUE = 500; //65535

        private static readonly double[] ReferenceCapacitors = { 5e-12, 10e-12, 15e-12 };

        public SerialPortDataReciever(string comPort)
        {
            ComPort = comPort;
            IsDevelopmentMode = false;

            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            watch = System.Diagnostics.Stopwatch.StartNew();
            watch2 = System.Diagnostics.Stopwatch.StartNew();
            debugMessagesOn = true;
            debugMessagesCounter = 0;

            buffer = new List<byte>();
            rowsBuffer = new List<DataRow>();
            rowsArr = null;
            messagesBuffer = new List<List<byte>>();

            developmentBuffer = "";
            developmentRowsBuffer = new List<DevelopmentDataRow>();
            developmentMessagesBuffer = new List<string>();

            

            isLutDone = false;

            testBuffer = "";

            serialPortManager = new SerialPortManager();

            inProgress = false;

            serialPortManager.DataArrived_Event += SerialPortManager_DataArrived_Event;
        }

        public bool Connect(bool isShowMessages)
        {//115200
            if (port != null && port.IsOpen) port.Close();

            if (IsDevelopmentMode)
            {
                serialPortManager.Connect(ComPort, 9600, Parity.None, 8, StopBits.One);
                Start();
                return true; //Add Checks
            }


            port = new SerialPort(ComPort, 115200, Parity.None, 8, StopBits.One);
            //port.DataReceived += Port_DataReceived;
            try
            {
                port.Open();
            }
            catch (IOException ex)
            {
                if(isShowMessages) MessageBox.Show("Can't connect to com port. Make sure the com port value is correct and that the device is responsive.");
                return false;
            }
            catch (Exception e)
            {
                if(isShowMessages) MessageBox.Show("Error connecting to com port");
                return false; ;
            }

            Start();
            return true;
        }

        public void Disconnect()
        {
            Stop();
        }

        public bool IsInProgress()
        {
            return inProgress;
        }

        public void Start()
        {
            Task SendDataTask = Task.Run(() =>
            {
                try
                {
                    inProgress = true;
                    if (IsDevelopmentMode)
                    {
                        while (true)
                        {
                            if (!Global.IsParseBusy && developmentBuffer.Length > 10) ParseDevelopmentData();
                            cancellationToken.ThrowIfCancellationRequested();
                            Thread.Sleep(50);
                        }
                    }
                    while (port.IsOpen)
                    {
                        int nbrDataRead;
                        int dataLength = port.BytesToRead;
                        byte[] data = new byte[dataLength];
                        string message;

                        if (data.Length > 30) //100
                        {
                            nbrDataRead = port.Read(data, 0, dataLength);

                            message = BitConverter.ToString(data);
                            if (message.Contains("19-01"))
                            {
                                //Code To Measure
                                if(watch != null)
                                {
                                    watch.Stop();
                                    var elapsedMs = watch.ElapsedMilliseconds;
                                    System.Diagnostics.Debug.WriteLine("New Line:" + elapsedMs + " Milliseconds.");
                                    watch = System.Diagnostics.Stopwatch.StartNew();
                                }
                            }
                            RawDataArrived_Event?.Invoke(message);


                            if (IsDevelopmentMode)
                            {
                                developmentBuffer += message;
                               
                                ParseDevelopmentData();

                            }
                            else
                            {
                                buffer.AddRange(data);
                                ParseData();
                            }
                        }

                        cancellationToken.ThrowIfCancellationRequested();

                        Thread.Sleep(50); //10
                    }
                    inProgress = false;
                    PortClosed_Event?.Invoke();
                }
                catch (OperationCanceledException e)
                {

                    cancellationTokenSource.Dispose();
                    cancellationTokenSource = new CancellationTokenSource();
                    cancellationToken = cancellationTokenSource.Token;
                    if (port != null && port.IsOpen)
                    {
                        port.Close();
                        port = null;
                    }
                    rowsArr = null;
                    inProgress = false;
                }

            }, cancellationToken);
        }

        private void SerialPortManager_DataArrived_Event(string value)
        {
            developmentBuffer += value.Replace("\0", "");
            //System.Diagnostics.Debug.WriteLine($"developmentBuffer.Length={developmentBuffer.Length}");

            //developmentBuffer += value.Replace("\r\n", "");

            //ParseDevelopmentData();
        }

        private void SerialPortManager_MetaArrived_Event(string value)
        {
            developmentBuffer += value.Replace("\0", "");
            //System.Diagnostics.Debug.WriteLine($"developmentBuffer.Length={developmentBuffer.Length}");
        }

        public void Stop()
        {
            if (inProgress) cancellationTokenSource.Cancel();
        }

        public void SimulateDevelopment()
        {
            IsDevelopmentMode = true;
            Global.DevelopmentA = Properties.Settings.Default.DevelopmentDefaultA;
            Global.DevelopmentB = Properties.Settings.Default.DevelopmentDefaultB;
            Global.DevelopmentB = Properties.Settings.Default.DevelopmentDefaultC;
            string dataPath = "C:\\work\\MattressHeatmap\\Development\\Simulator\\SimulatorData.txt";
            string[] lines = File.ReadAllLines(dataPath);
            int index = 0;

            Task simulateDevelopmentReadTask = Task.Run(() =>
            {
                while (true)
                {
                    if (developmentBuffer.Length > 10) ParseDevelopmentData();
                    Thread.Sleep(50);
                }
            });

            Task simulateDevelopmentWriteTask = Task.Run(() =>
            {
                while (true)
                {
                    developmentBuffer += lines[index] + "\r\n";
                    index++;
                    if (index >= lines.Length) index = 0;

                    Thread.Sleep(100);
                }
            });
        }

        private void ParseData()
        {
            //System.Diagnostics.Debug.WriteLine($"ParseData {buffer.Count}");

            if (buffer.Count > 1000)
            {
                buffer.Clear();
                return;
            }
            //System.Diagnostics.Debug.WriteLine($"*ParseData {buffer.Count}");

            byte[] sync = new byte[] { 0xAA, 0xBB, 0xBB, 0xAA };

            List<List<byte>> dataRows = SplitData(buffer, sync.ToList());
            if (dataRows.Count == 0) return;

            if(!isLutDone) ProcessLut(dataRows);

            if (Global.Lut.Values == null) return;

            bool isException = false;
            int sizeException = dataRows[0].Count;
            for (int i = 0; i < dataRows.Count; i++)
            {
                if (dataRows[i].Count != sizeException) isException = true;
            }
            if (isException)
            {
                System.Diagnostics.Debug.WriteLine("------------------Exception---------------------");
            }

            if (rowsArr == null) rowsArr = new DataRow[Global.Lut.Values.GetLength(0)];

            bool stop = false;
            //int index = dataRows.Count - 1;
            int index = 0;
            while (!stop && !IsRowsArrayFull(rowsArr))
            {
                DataRow row = new DataRow(dataRows[index]);

                if (row.IsValid) rowsArr[row.Index] = row;
                                                                                                                           
                index++;
                if (index > dataRows.Count - 1) stop = true;
            }

            //WriteDebugMessage(GetArrayFullnessString(rowsArr));
            //WriteDebugMessage("");

            if (IsRowsArrayFull(rowsArr))
            {
                ParseRows();
                rowsArr = null;
                isLutDone = true;
            }
            buffer.Clear();
        }

        private void WriteDebugMessage(string message)
        {
            if (debugMessagesOn)
            {
                System.Diagnostics.Debug.WriteLine(message);
                debugMessagesCounter++;
            }

            if (debugMessagesCounter > 1500) debugMessagesOn = false;
        }

        private string GetArrayFullnessString(DataRow[] arr)
        {
            string result = "";
            for(int i = 0; i < arr.Length; i++)
            {
                result += i + ": ";
                if (arr[i] == null) result += '0';
                else result += '1';
                result += Environment.NewLine;
            }
            return result;
        }

        private void ProcessLut(List<List<byte>> dataRows)
        {
            for (int i = 0; i < dataRows.Count; i++)
            {
                SubTypeT type = (SubTypeT)dataRows[i][8];

                if (type == SubTypeT.kGetOvcParamsAtOnceResponse || type == SubTypeT.kGetLutAtOnceResponse)
                    Global.Lut.ParseData(dataRows[i]);
            }
        }

        private void ParseData2()
        {
            byte[] sync = new byte[] { 0xAA, 0xBB, 0xBB, 0xAA };
            int syncIndex = GetIndexOfRange(sync.ToList());
            if (syncIndex == -1) return;
            if (syncIndex != 0) buffer.RemoveRange(0, syncIndex);
            int nextSyncIndex = GetIndexOfRange(sync.ToList(), 2);
            List<List<byte>> msgsBuffer = new List<List<byte>>();
            while (nextSyncIndex != -1)
            {
                List<byte> data = buffer.GetRange(0, nextSyncIndex);
                DataRow row = new DataRow(data);
                if (row.IsValid) rowsBuffer.Add(row);
                else Global.Lut.ParseData(data);
                //messagesBuffer.Add(buffer.GetRange(0, nextSyncIndex));
                msgsBuffer.Add(buffer.GetRange(0, nextSyncIndex));
                buffer.RemoveRange(0, nextSyncIndex);
                nextSyncIndex = GetIndexOfRange(sync.ToList(), 2);
            }
            ParseRows();
            MessagesArrived_Event?.Invoke(msgsBuffer);
            messagesBuffer.Clear();
        }


        //buffer = buffer.GetRange(syncIndex, buffer.Count - syncIndex);

        private void ParseRows()
        {
            double[,] result = new double[rowsArr.Length, rowsArr[0].Size];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = GetDoubleValue(rowsArr[i], j);
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("New Parse:" + elapsedMs + " Milliseconds.");
            //WriteDebugMessage("New Parse:" + elapsedMs + " Milliseconds.");
            watch = System.Diagnostics.Stopwatch.StartNew();
            DataArrived_Event?.Invoke(result);
        }

        private void ParseRows2()
        {
            int startIndex = GetStartRowIndex();
            if (startIndex == -1) return;
            if (startIndex != 0) rowsBuffer.RemoveRange(0, startIndex);
            int nextStartIndex = GetStartRowIndex(2);
            while (nextStartIndex != -1)
            {
                ParseRows(rowsBuffer.GetRange(0, nextStartIndex));
                rowsBuffer.RemoveRange(0, nextStartIndex);
                nextStartIndex = GetStartRowIndex(2);
                Thread.Sleep(10);
            }
        }

        private void ParseRows(List<DataRow> rows)
        {
            double[,] result = new double[rows.Count, rows[0].Size];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    //result[i, j] = GetDoubleValue(rows[i].Values[j]);
                    result[i, j] = GetDoubleValue(rows[i], j);
                }
            }
            DataArrived_Event?.Invoke(result);
        }

        private void ParseDevelopmentData()
        {
            Global.IsParseBusy = true;
            try
            {
                
                if (developmentBuffer.Length > 8000)
                {
                    int k = 1;
                }
                if (developmentBuffer.Length > 200000)
                {
                    developmentBuffer = "";
                    return;
                }

                int metaStart = -1;
                int metaEnd = -1;
                int dataStart = -1;
                int dataEnd = -1;

                metaStart = developmentBuffer.IndexOf("Mat ");
                if (metaStart == -1)
                {
                    return;
                }

                metaEnd = developmentBuffer.IndexOf("Row1,", metaStart);
                if (metaEnd == -1)
                {
                    return;
                }

                dataStart = metaEnd;
                dataEnd = developmentBuffer.IndexOf("\r\n\r\n", dataStart);

                if (dataEnd == -1)
                {
                    return;
                }
                string currentMate = "";
                string currentMeta = "";
                if (dataEnd >= 0)
                {
                    currentMeta = developmentBuffer.Substring(metaStart, metaEnd - metaStart);
                    currentMate = developmentBuffer.Substring(dataStart, dataEnd - dataStart);
                    var d = developmentBuffer.Substring(dataEnd - 10);
                    developmentBuffer = d;
                }
                if (currentMate == "") return;

                List<string> metadata = new List<string>();

                string[] metaStr = currentMeta.Replace("\r\n", "+").Split('+');
                if (metaStr.Length == 0) return;

                for (int i = 0; i < metaStr.Length; i++)
                {
                    string[] parts = metaStr[i].Split(',');

                    if (i == 0) // status
                    {
                        metadata.Add(parts[0].Trim());
                    }
                    else if (parts.Length > 1)
                    {
                        metadata.AddRange(parts.Skip(1).Select(v => v.Trim()));
                    }
                }

                string mat = currentMate;// mats[mats.Length - 2];

                string[] rowsStr = mat.Replace("\r\n", "+").Split('+');
                if (rowsStr.Length == 0) return;
                List<DevelopmentDataRow> rows = new List<DevelopmentDataRow>();
                for (int i = 0; i < rowsStr.Length; i++)
                {
                    rows.Add(new DevelopmentDataRow(rowsStr[i]));
                }

                ParseDevelopmentRows(rows);
                ParseDevelopmentMeta(metadata);
                //developmentBuffer = "";
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString());
            }
            finally
            {
                Global.IsParseBusy = false;
            }
        }


        private void ParseDevelopmentData2()
        {
            if (developmentBuffer.Length > 1000)
            {
                developmentBuffer = "";
                return;
            }

            int startIndex = developmentBuffer.IndexOf("Row");
            if (startIndex == -1) return;
            if (startIndex != 0) developmentBuffer = developmentBuffer.Remove(0, startIndex);
            int endIndex = developmentBuffer.IndexOf("Row", 1);
            if (endIndex == -1) return;
            //System.Diagnostics.Debug.WriteLine(developmentBuffer.Length);
            while (endIndex != -1)
            {
                string message = developmentBuffer.Substring(0, endIndex);
                DevelopmentDataRow row = new DevelopmentDataRow(message);
                if (row.IsValid) developmentRowsBuffer.Add(row);
                developmentBuffer = developmentBuffer.Remove(0, endIndex);
                endIndex = developmentBuffer.IndexOf("Row", 1);
            }

            ParseDevelopmentRows();
            //developmentRowsBuffer.Clear();
        }

        private void ParseDevelopmentRows()
        {
            int startIndex = GetStartDevelopmentRowIndex();
            if (startIndex == -1) return;
            if (startIndex != 0) developmentRowsBuffer.RemoveRange(0, startIndex);
            int nextStartIndex = GetStartDevelopmentRowIndex(2);

            while (nextStartIndex != -1)
            {
                ParseDevelopmentRows(developmentRowsBuffer.GetRange(0, nextStartIndex));
                developmentRowsBuffer.RemoveRange(0, nextStartIndex);
                nextStartIndex = GetStartDevelopmentRowIndex(2);
                //Thread.Sleep(10);
            }
        }

        //private void ParseDevelopmentRows(List<DevelopmentDataRow> rows)
        //{
        //    if (!CheckDevelopmentRows(rows)) return;

        //    double[,] result = new double[rows.Count, rows[0].Values.Count];
        //    for (int i = 0; i < result.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < result.GetLength(1); j++)
        //        {
        //            result[i, j] = GetDoubleValue(rows[i].Values[j]);
        //        }
        //    }
        //    DataArrived_Event?.Invoke(result);
        //}

        private void ParseDevelopmentRows(List<DevelopmentDataRow> rows)
        {
            if (!CheckDevelopmentRows(rows)) return;

            int numRows = rows.Count;
            int numCols = rows[0].Values.Count;

            double[,] result = new double[numRows, numCols];

            if (!Global.IsManual)
            {
                for (int i = 0; i < numRows; i++)
                {
                    double[] x = new double[3];
                    double[] y = new double[3];

                    for (int j = 0; j < 3; j++)
                    {
                        x[j] = rows[i].Values[30 + j];
                        y[j] = ReferenceCapacitors[j];
                    }

                    var (a, b, c) = FitQuadratic(x, y);

                    for (int j = 0; j < numCols; j++)
                    {
                        double measuredValue = rows[i].Values[j];
                        result[i, j] = a * measuredValue * measuredValue + b * measuredValue + c;
                    }
                }
            }
            else
            {
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = GetDoubleValue(rows[i].Values[j]);
                    }
                }
            }

            DataArrived_Event?.Invoke(result);
        }


        private void ParseDevelopmentMeta(List<string> metadata)
        {
            MetaArrived_Event?.Invoke(metadata);
        }


        private bool CheckDevelopmentRows(List<DevelopmentDataRow> rows)
        {
            for (int i = 0; i < rows.Count; i++)
            {
       //         System.Diagnostics.Debug.WriteLine(i.ToString());
                if (rows[i].Index != i) return false;
            }
            return true;
        }

        private double GetDoubleValue(DataRow row, int col)
        {
            Single a = ((Single)row.Values[col] / (Single)row.Amps[col]);
            Single b = ((Single)row.RefAmp / (Single)row.RefValue);
            Single c = (Single)8.2e-12;

            Single cap = a * b * c;
            return (double)cap;
        }

        private double GetDoubleValue(int developmentValue)
        {
            return (Global.DevelopmentA * (double)developmentValue * (double)developmentValue) +
                (Global.DevelopmentB * (double)developmentValue) + Global.DevelopmentC;
        }

        private double GetDoubleValue2(int value)
        {
            return (double)value / (double)MAX_VALUE;
        }

        private int GetStartRowIndex(int occurence)
        {
            int occurenceCounter = 0;
            for (int i = 0; i < rowsBuffer.Count; i++)
            {
                if (rowsBuffer[i].Index == 0)
                {
                    occurenceCounter++;
                    if (occurenceCounter == occurence) return i;
                }
            }
            return -1;
        }

        private int GetStartRowIndex()
        {
            for (int i = 0; i < rowsBuffer.Count; i++)
            {
                if (rowsBuffer[i].Index == 0) return i;
            }

            return -1;
        }

        private int GetStartDevelopmentRowIndex()
        {
            for (int i = 0; i < developmentRowsBuffer.Count; i++)
            {
                if (developmentRowsBuffer[i].Index == 0) return i;
            }

            return -1;
        }

        private int GetStartDevelopmentRowIndex(int occurence)
        {
            int occurenceCounter = 0;
            for (int i = 0; i < developmentRowsBuffer.Count; i++)
            {
                if (developmentRowsBuffer[i].Index == 0)
                {
                    occurenceCounter++;
                    if (occurenceCounter == occurence) return i;
                }
            }

            return -1;
        }

        private int GetIndexOfRange(List<byte> range, int occurence)
        {
            return GetIndexOfRange(buffer, range, occurence);
        }

        private int GetIndexOfRange(List<byte> data, List<byte> range, int occurence)
        {
            List<byte> checkedRange;
            int occurenceCounter = 0;
            for (int i = 0; i < data.Count - range.Count + 1; i++)
            {
                checkedRange = data.GetRange(i, range.Count);
                if (RangesEqual(range, checkedRange))
                {
                    occurenceCounter++;
                    if (occurenceCounter == occurence) return i;
                }
            }
            return -1;
        }

        private int GetIndexOfRange(List<byte> range)
        {
            return GetIndexOfRange(range, 1);
        }

        private int GetIndexOfRange(List<byte> data, List<byte> range)
        {
            return GetIndexOfRange(data, range, 1);
        }

        private int GetIndexOfChar(string str, char c, int occurence)
        {
            int occurenceCounter = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    occurenceCounter++;
                    if (occurenceCounter == occurence) return i;
                }
            }

            return -1;
        }

        private bool IsRowsArrayFull(DataRow[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null) return false;
            }
            return true;
        }

        private List<List<byte>> SplitData(List<byte> data, List<byte> sync)
        {
            List<List<byte>> result = new List<List<byte>>();
            int syncIndex = GetIndexOfRange(data, sync);
            int occurence = 3;
            if (syncIndex == -1) return result;
            if (syncIndex != 0)
            {
                //result.Add(data.GetRange(0, syncIndex)); //Maybe remove this
            }
            int nextSyncIndex = GetIndexOfRange(data, sync, 2);

            while (nextSyncIndex != -1)
            {
                result.Add(data.GetRange(syncIndex, nextSyncIndex - syncIndex));
                syncIndex = nextSyncIndex;
                nextSyncIndex = GetIndexOfRange(data, sync, occurence);
                occurence++;
            }

            result.Add(data.GetRange(syncIndex, data.Count - syncIndex));

            return result;
        }

        private bool RangesEqual(List<byte> range1, List<byte> range2)
        {
            if (range1.Count != range2.Count) return false;
            for (int i = 0; i < range1.Count; i++)
            {
                if (range1[i] != range2[i]) return false;
            }
            return true;
        }



        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lock (Locker)
                {
                    int nbrDataRead;
                    int dataLength = port.BytesToRead;
                    byte[] data = new byte[dataLength];
                    string message;
                    if (data.Length > 10)
                    {
                        nbrDataRead = port.Read(data, 0, dataLength);

                        message = BitConverter.ToString(data);
                        RawDataArrived_Event?.Invoke(message);
                    }
                }
            }
            catch (Exception ex) { };
        }

        public int GetBufferCount()
        {
            return buffer.Count;
        }


        public int GetRowsCount()
        {
            return rowsBuffer.Count;
        }

        public static (double a, double b, double c) FitQuadratic(double[] x, double[] y)
        {
            int n = 3;

            double sumX = x.Sum();
            double sumX2 = x.Select(v => v * v).Sum();
            double sumX3 = x.Select(v => v * v * v).Sum();
            double sumX4 = x.Select(v => v * v * v * v).Sum();
            double sumY = y.Sum();
            double sumXY = x.Zip(y, (xi, yi) => xi * yi).Sum();
            double sumX2Y = x.Zip(y, (xi, yi) => xi * xi * yi).Sum();

            double[,] A = {
            { n, sumX, sumX2 },
            { sumX, sumX2, sumX3 },
            { sumX2, sumX3, sumX4 }
        };
            double[] B = { sumY, sumXY, sumX2Y };

            return SolveLinearSystem(A, B);
        }

        private static (double a, double b, double c) SolveLinearSystem(double[,] A, double[] B)
        {
            int n = B.Length;
            double[] X = new double[n];

            for (int i = 0; i < n; i++)
            {
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                    if (Math.Abs(A[k, i]) > Math.Abs(A[maxRow, i])) maxRow = k;

                for (int k = i; k < n; k++)
                {
                    double tmp = A[maxRow, k];
                    A[maxRow, k] = A[i, k];
                    A[i, k] = tmp;
                }

                double tmpB = B[maxRow];
                B[maxRow] = B[i];
                B[i] = tmpB;

                for (int k = i + 1; k < n; k++)
                {
                    double factor = A[k, i] / A[i, i];
                    B[k] -= factor * B[i];
                    for (int j = i; j < n; j++)
                        A[k, j] -= factor * A[i, j];
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                X[i] = B[i] / A[i, i];
                for (int k = 0; k < i; k++)
                    B[k] -= A[k, i] * X[i];
            }

            return (X[2], X[1], X[0]);
        }

        public void SendHeatmapData(string data)
        {
            if (serialPortManager != null)
            {
                serialPortManager.SendOut(data);
            }
        }
    }
}