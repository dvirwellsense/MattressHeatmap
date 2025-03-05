using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public enum RequestType { Ready, PowerConfig, PowerStatus, SelfTest, GetHwcParamsAtOnce, GotAllHwcParams, GetOvcParamsAtOnce, GetLutAtOnce, GotOverlayParams, Start, Reset }
    public class Request
    {
        public byte[] Sync { get; set; }
        public byte MessageNumber { get; set; }
        public short MessageLength { get; set; }
        public CategoryT Category { get; set; }
        public SubTypeT Subtype { get; set; }
        public Status Status { get; set; }

        public static byte MessageCounter = 0;
        private static CancellationTokenSource StartSequenceCancellationTokenSource = null;
        private static CancellationToken StartSequenceCancellationToken = new CancellationToken();

        public Request()
        {
            Init();
        }

        public Request(SubTypeT type)
        {
            Init(type);
        }

        public Request(RequestType requestType)
        {
            Init(requestType);
        }

        public List<byte> GetData(bool includeStatus)
        {
            List<byte> data = new List<byte>();

            data.AddRange(Sync);
            data.Add(MessageNumber);
            data.AddRange(BitConverter.GetBytes(MessageLength));
            data.Add((byte)Category);
            data.Add((byte)Subtype);
            if (includeStatus) data.Add((byte)Status);

            return data;
        }

        private void Init()
        {
            Sync = new byte[] { 0xAA, 0xBB, 0xBB, 0xAA };
            MessageNumber = GetNewMessageNumber();
            MessageLength = 3;
            Category = CategoryT.kRequest;
            Subtype = SubTypeT.kReady;
            Status = Status.kSuccess;
        }

        private void Init(SubTypeT type)
        {
            Init();
            Subtype = type;
        }

        //Ready, PowerConfig, PowerStatus, SelfTest, GetHwcParamsAtOnce, GotAllHwcParams, GetOvcParamsAtOnce, GotOverlayParams, Start, Reset
        private void Init(RequestType requestType)
        {
            Init(GetType(requestType));
            if (requestType == RequestType.PowerConfig) MessageLength = 14;
        }

        private byte GetNewMessageNumber()
        {
            MessageCounter = (byte)((MessageCounter + 1) % 255);
            return MessageCounter;
        }

        private SubTypeT GetType(RequestType requestType)
        {
            switch (requestType)
            {
                case RequestType.Ready: return SubTypeT.kReady;
                case RequestType.PowerConfig: return SubTypeT.kPowerConfig;
                case RequestType.PowerStatus: return SubTypeT.kPowerStatus;
                case RequestType.SelfTest: return SubTypeT.kSelfTest;
                case RequestType.GetHwcParamsAtOnce: return SubTypeT.kGetHwcParamsAtOnce;
                case RequestType.GotAllHwcParams: return SubTypeT.kGotAllHwcParams;
                case RequestType.GetOvcParamsAtOnce: return SubTypeT.kGetOvcParamsAtOnce;
                case RequestType.GetLutAtOnce: return SubTypeT.kGetLutAtOnce;
                case RequestType.GotOverlayParams: return SubTypeT.kGotOverlayParams;
                case RequestType.Start: return SubTypeT.kStart;
                case RequestType.Reset: return SubTypeT.kReset;
            }
            return SubTypeT.kReady;
        }

        private static void AddPowerConfigData(List<byte> data, float refreshRate, float batteryImageDelay, float lowBatteryImageDelay)
        {
            data.AddRange(BitConverter.GetBytes(refreshRate));
            data.AddRange(BitConverter.GetBytes(batteryImageDelay));
            data.AddRange(BitConverter.GetBytes(lowBatteryImageDelay));
        }

        private static void AddPowerStatusData(List<byte> data, byte chunkNum)
        {
            data.Add(chunkNum);
        }

        public static List<byte> CreateData(RequestType requestType)
        {
            Request request = new Request(requestType);
            bool includeStatus = (requestType != RequestType.PowerConfig
                && requestType != RequestType.PowerStatus);
            List<byte> data = request.GetData(includeStatus);

            if (requestType == RequestType.PowerConfig) AddPowerConfigData(data, 2F, 1F, 10F);
            if (requestType == RequestType.PowerStatus) AddPowerStatusData(data, 0);

            return data;
        }

        public static void Send(Request request, SerialPort port)
        {
            List<byte> data = request.GetData(true);
            port.Write(data.ToArray(), 0, data.Count);
        }

        public static void Send(RequestType requestType, SerialPort port)
        {
            List<byte> data = CreateData(requestType);
            port.Write(data.ToArray(), 0, data.Count);
        }

        public static void SendStartSequence(SerialPort port)
        {
            int delay = 1000;

            Send(RequestType.Ready, port);
            Thread.Sleep(delay);

            Send(RequestType.PowerConfig, port);
            Thread.Sleep(delay);

            Send(RequestType.PowerStatus, port);
            Thread.Sleep(delay);

            Send(RequestType.SelfTest, port);
            Thread.Sleep(delay);

            Send(RequestType.GetHwcParamsAtOnce, port);
            Thread.Sleep(delay);

            Send(RequestType.GotAllHwcParams, port);
            Thread.Sleep(delay);

            Send(RequestType.GetOvcParamsAtOnce, port);
            Thread.Sleep(delay);

            Send(RequestType.GetLutAtOnce, port);
            Thread.Sleep(delay);

            Send(RequestType.GotOverlayParams, port);
            Thread.Sleep(delay);

            Send(RequestType.Start, port);
            Thread.Sleep(delay);
        }

        public static void SendStartSequenceAsync(SerialPort port)
        {
            StartSequenceCancellationTokenSource = new CancellationTokenSource();
            StartSequenceCancellationToken = StartSequenceCancellationTokenSource.Token;

            Task StartSequenceTask = Task.Run(() =>
            {
                try
                {
                    int delay = 1000;

                    Send(RequestType.Ready, port);
                    EventPublisher.RaiseEvent_StartSequenceStepFinished(0, "Ready");
                    Thread.Sleep(delay);
                    StartSequenceCancellationToken.ThrowIfCancellationRequested();

                    Send(RequestType.PowerConfig, port);
                    EventPublisher.RaiseEvent_StartSequenceStepFinished(1, "Power Config");
                    Thread.Sleep(delay);
                    StartSequenceCancellationToken.ThrowIfCancellationRequested();

                    Send(RequestType.PowerStatus, port);
                    EventPublisher.RaiseEvent_StartSequenceStepFinished(2, "Power Status");
                    Thread.Sleep(delay);
                    StartSequenceCancellationToken.ThrowIfCancellationRequested();

                    Send(RequestType.SelfTest, port);
                    EventPublisher.RaiseEvent_StartSequenceStepFinished(3, "Self Test");
                    Thread.Sleep(delay);
                    StartSequenceCancellationToken.ThrowIfCancellationRequested();

                    Send(RequestType.GetHwcParamsAtOnce, port);
                    EventPublisher.RaiseEvent_StartSequenceStepFinished(4, "Get Hwc Params At Once");
                    Thread.Sleep(delay);
                    StartSequenceCancellationToken.ThrowIfCancellationRequested();

                    Send(RequestType.GotAllHwcParams, port);
                    EventPublisher.RaiseEvent_StartSequenceStepFinished(5, "Got All Hwc Params");
                    Thread.Sleep(delay);
                    StartSequenceCancellationToken.ThrowIfCancellationRequested();

                    Send(RequestType.GetOvcParamsAtOnce, port);
                    EventPublisher.RaiseEvent_StartSequenceStepFinished(6, "Get Ovc Params At Once");
                    Thread.Sleep(delay);
                    StartSequenceCancellationToken.ThrowIfCancellationRequested();

                    Send(RequestType.GetLutAtOnce, port);
                    EventPublisher.RaiseEvent_StartSequenceStepFinished(7, "Get Lut At Once");
                    Thread.Sleep(delay);
                    StartSequenceCancellationToken.ThrowIfCancellationRequested();

                    Send(RequestType.GotOverlayParams, port);
                    EventPublisher.RaiseEvent_StartSequenceStepFinished(8, "Got Overlay Params");
                    Thread.Sleep(delay);
                    StartSequenceCancellationToken.ThrowIfCancellationRequested();

                    Send(RequestType.Start, port);
                    EventPublisher.RaiseEvent_StartSequenceStepFinished(9, "Start");
                    Thread.Sleep(delay);
                }
                catch (OperationCanceledException e)
                {
                    StartSequenceCancellationTokenSource.Dispose();
                    StartSequenceCancellationTokenSource = null;
                }
                catch(Exception ex)
                {
                    
                }

            }, StartSequenceCancellationToken);
        }

        public static void StopStartSequence()
        {
            if(StartSequenceCancellationTokenSource != null) StartSequenceCancellationTokenSource.Cancel();
        }
    }
}
