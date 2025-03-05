using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap

{
    /// <summary>
    /// Manager for serial port data
    /// </summary>
    public class SerialPortManager : IDisposable
    {
        int MsgCounter = 0;
        string RxBuffer = "";
        List<byte> RxPack = new List<byte>();
        public static object Locker = new object();
        public delegate void EventHandler_string(string value);

        //        public event Global.EventHandler_TesterMsg DataArrived_Event;
        public event EventHandler_string SendOutMsg_Event;
        public event EventHandler_string DataArrived_Event;
        //public event Global.EventHandler_MachineState DataArrived_Event;
        // public event Global.EventHandler_string MessageArrived_Event;

        public SerialPortManager()
        {
        }
        /// <summary>
        /// Connects to a serial port defined through the current settings
        /// </summary>
        public string Connect(string portName, int baudrate, Parity parity, int dataBits, StopBits stopBits)
        {
            //                return ("Failed to open com port \r\n\r\n" + portName);
            try
            {

                if (_serialPort != null && _serialPort.IsOpen) _serialPort.Close();
                _serialPort = new SerialPort(portName, baudrate, parity, dataBits, stopBits);
                _serialPort.RtsEnable = true;
                _serialPort.DtrEnable = true;
                _serialPort.Handshake = Handshake.None;
                _serialPort.DiscardNull = true;
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                _serialPort.Open();
                return "OK";
            }
            catch (Exception ex)
            {
                return ("Error: Failed to open com port \r\n\r\n" + portName);
            }
        }


        ~SerialPortManager()
        {
            Dispose(false);
        }


        #region Fields
        private SerialPort _serialPort;
        private string _latestRecieved = String.Empty;

        #endregion

        int indexMessage;
        int indexMessageEnd;

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lock (Locker)
                {
                    int msgSize = 46;
                    int nbrDataRead;
                    string msg;
                    int dataLength = _serialPort.BytesToRead;
                    byte[] data = new byte[dataLength];
                    if (data.Length > 10)
                    {
                        nbrDataRead = _serialPort.Read(data, 0, dataLength);
                        msg = System.Text.Encoding.Default.GetString(data);
                        DataArrived_Event?.Invoke(msg);
                        //if (RxBuffer.Length > 1000) RxBuffer = "";
                        //if (RxBuffer.Contains('\n'))
                        //{
                        //    if (RxBuffer.Contains("<"))
                        //    {
                        //        indexMessage = RxBuffer.LastIndexOf("<") + 1;
                        //        indexMessageEnd = RxBuffer.LastIndexOf(">");
                        //        string message = RxBuffer.Substring(indexMessage, indexMessageEnd - indexMessage);
                        //        DataArrived_Event?.Invoke(new MachineState(message));
                        //        MessageArrived_Event?.Invoke(message);
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex) { };
        }

        /// <summary>
        /// Closes the serial port
        /// </summary>
        public void StopListening()
        {
            _serialPort.Close();
        }



        // Call to release serial port
        public void Dispose()
        {
            Dispose(true);
        }

        // Part of basic design pattern for implementing Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serialPort.DataReceived -= new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            }
            // Releasing serial port (and other unmanaged objects)
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort.Dispose();
            }
        }

        public void SendOut(string msg)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                msg = msg + "\r\n";
                _serialPort.Write(msg);
                SendOutMsg_Event?.Invoke(msg);
            }
        }
    }






}