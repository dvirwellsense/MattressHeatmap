using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class SerialPortDataSender
    {
        public Queue<double[,]> DataToSend { get; set; }
        public string ComPort { get; set; }
        public SerialPort SerialPort { get; set; }

        private static int MAX_VALUE = 65535;
        private static int MAX_QUEUE = 20; //5
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

        public SerialPortDataSender(string comPort)
        {
            DataToSend = new Queue<double[,]>();
            ComPort = comPort;
            SerialPort = null;

            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
        }

        public void Start()
        {
            Task SendDataTask = Task.Run(() =>
            {
                SerialPort port;
                if (SerialPort == null)
                {
                    port = new SerialPort(ComPort, 115200, Parity.None, 8, StopBits.One);
                    port.Open();
                }
                else port = SerialPort;

                try
                {
                    List<byte> dataBytes;

                    while (true)
                    {
                        if (DataToSend.Count > 0 && port != null && port.IsOpen)
                        {
                            dataBytes = GetDataInBytes(DataToSend.Dequeue());
                            WriteDataToPortInSegments(port, dataBytes, 100); //1000 / dataBytes.Count
                            //port.Write(dataBytes.ToArray(), 0, dataBytes.Count);
                        }

                        if (DataToSend.Count > MAX_QUEUE) DataToSend.Clear();

                        cancellationToken.ThrowIfCancellationRequested();

                        Thread.Sleep(100);
                    }

                    //port.Write(new byte[] { 0x0A, 0xE2, 0xFF }, 0, 3);

                }
                catch (OperationCanceledException e)
                {
                    //if(SerialPort == null)
                    port.Close();
                    DataToSend.Clear();

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

        private void WriteDataToPortInSegments(SerialPort port, List<byte> data, int segmentLength)
        {
            int delay = 10;
            byte[] dataSegment;
            int iterations = data.Count / segmentLength;
            for (int i = 0; i < iterations; i++)
            {
                Thread.Sleep(delay);
                dataSegment = data.GetRange(i * segmentLength, segmentLength).ToArray();
                cancellationToken.ThrowIfCancellationRequested();
                port.Write(dataSegment, 0, segmentLength);
            }
            int remainingLength = data.Count % segmentLength;
            dataSegment = data.GetRange(iterations * segmentLength, remainingLength).ToArray();
            cancellationToken.ThrowIfCancellationRequested();
            port.Write(dataSegment, 0, remainingLength);
            Thread.Sleep(delay);
        }

        private void WriteDataToPortInSegments1(SerialPort port, List<byte> data)
        {
            int segmentLength = data.Count; //100;
            for (int i = 0; i < data.Count; i += segmentLength)
            {
                if (data.Count < i + segmentLength) segmentLength = data.Count - i;
                byte[] dataSegment = data.GetRange(i, segmentLength).ToArray();
                port.Write(dataSegment, 0, dataSegment.Length);
                Thread.Sleep(10);
                cancellationToken.ThrowIfCancellationRequested();
            }

        }


        private List<byte> GetDataInBytes(double[,] data)
        {
            List<byte> bytes = new List<byte>();

            for (int i = 0; i < data.GetLength(0); i++)
            {
                List<byte> rowBytes = GetDataRow(data, i);
                bytes.AddRange(rowBytes);
            }

            return bytes;
        }

        private List<byte> GetDataRow(double[,] data, int rowIndex)
        {
            List<byte> dataRow = new List<byte>();

            byte[] sync = new byte[] { 0xAA, 0xBB, 0xBB, 0xAA };
            byte messageNumber = 0x00;
            short messageLength = (short)data.GetLength(0);
            byte status = 0;
            byte category = 4;
            byte subType = 25;
            byte index = (byte)rowIndex;
            byte size = (byte)data.GetLength(1);

            List<short> values = GetValues(data, rowIndex);
            List<byte> amps = GetAmps(data, rowIndex);

            dataRow.AddRange(sync);
            dataRow.Add(messageNumber);
            dataRow.Add(BitConverter.GetBytes(messageLength)[0]);
            dataRow.Add(status);
            dataRow.Add(category);
            dataRow.Add(subType);
            dataRow.Add(index);
            dataRow.Add(size);

            dataRow.AddRange(GetValuesBytes(values));
            dataRow.AddRange(amps);

            return dataRow;
        }

        private List<short> GetValues(double[,] data, int rowIndex)
        {
            List<short> values = new List<short>();

            for (int i = 0; i < data.GetLength(1); i++)
            {
                double dataValue = data[rowIndex, i];
                int numberValue = (int)(dataValue * MAX_VALUE);
                int resultValue = numberValue / 256;
                int remainder = numberValue % 256;
                values.Add((short)remainder);
                values.Add((short)resultValue);
            }

            return values;
        }

        private List<byte> GetAmps(double[,] data, int rowIndex)
        {
            List<byte> amps = new List<byte>();

            for (int i = 0; i < data.GetLength(1); i++)
            {
                amps.Add(0x08);
            }

            return amps;
        }

        private List<byte> GetValuesBytes(List<short> values)
        {
            List<byte> valuesBytes = new List<byte>();

            for (int i = 0; i < values.Count; i++)
            {
                valuesBytes.Add(BitConverter.GetBytes(values[i])[0]);
            }

            return valuesBytes;
        }
    }
}
