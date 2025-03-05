using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

namespace MattressHeatmap
{
    public enum DisplayType { NotSet, Bool, Decimal, Hex, UTF8, UTF16, Unsupported }

    public class BluetoothCharacteristic
    {
        public GattCharacteristic CharacteristicInfo { get; set; }
        public GattDescriptor Descriptor { get; set; }
        public BluetoothService Service { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public ushort AttributeHandle { get; set; }
        public string Value { get; set; }
        public bool IsNotifySet { get; set; }
        public GattCharacteristicProperties Properties { get; set; }
        public bool IsPolling { get; set; }

        public string LogPrefix;

        private IBuffer rawData;
        private byte[] data;
        private GattPresentationFormat presentationFormat;

        private DisplayType displayType = DisplayType.NotSet;
        public DisplayType DisplayType
        {
            get { return displayType; }
            set { displayType = value; }
        }

        public BluetoothCharacteristic(BluetoothService service, GattCharacteristic characteristic)
        {

            try
            {
                IsPolling = false;
                IsNotifySet = false;
                Service = service;
                CharacteristicInfo = characteristic;
                Uuid = characteristic.Uuid;
                Name = GattUuidsLib.ConvertUuidToName(characteristic.Uuid);
                AttributeHandle = CharacteristicInfo.AttributeHandle;
                Properties = CharacteristicInfo.CharacteristicProperties;
                LogPrefix = "Characteristic_ " + Name + " => ";
                if (Name == "5121") displayType = DisplayType.UTF8;

                ReadData(DisplayType);
                characteristic.ValueChanged += Characteristic_ValueChanged;

            }
            catch (Exception ex)
            {
                int k = 1;
            }
        }

        private void Characteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            SetValue(args.CharacteristicValue);
        }

        public async void WriteData(string data)
        {
            IBuffer writeBuffer = null;
            //writeBuffer = CryptographicBuffer.ConvertStringToBinary(data, BinaryStringEncoding.Utf8);

            if (!String.IsNullOrEmpty(data))
            {
                Global.BluetoothLogger.Log(LogPrefix + "Writing " + data);
                //if (WriteType == WriteTypes.Decimal)
                //{
                //    DataWriter writer = new DataWriter();
                //    writer.ByteOrder = ByteOrder.LittleEndian;
                //    writer.WriteInt32(Int32.Parse(ValueToWrite));
                //    writeBuffer = writer.DetachBuffer();
                //}
                //else if (WriteType == WriteTypes.Hex)
                //{
                try
                {
                    // pad the value if we've received odd number of bytes
                    if (data.Length % 2 == 1)
                    {
                        writeBuffer = GattConvert.ToIBufferFromHexString("0" + data);
                    }
                    else
                    {
                        writeBuffer = GattConvert.ToIBufferFromHexString(data);
                    }
                }
                catch (Exception ex)
                {
                    Global.BluetoothLogger.Log(ex.Message);
                    return;
                }
                //else if (WriteType == WriteTypes.UTF8)
                //{
                //    writeBuffer = CryptographicBuffer.ConvertStringToBinary(ValueToWrite,
                //    BinaryStringEncoding.Utf8);
                //}

                try
                {
                    // BT_Code: Writes the value from the buffer to the characteristic.
                    GattCommunicationStatus result = await CharacteristicInfo.WriteValueAsync(writeBuffer);

                    if (result == GattCommunicationStatus.Unreachable)
                    {
                        Global.BluetoothLogger.Log(LogPrefix + "Unable to write data - Device unreachable");
                    }
                    else if (result == GattCommunicationStatus.ProtocolError)
                    {
                        Global.BluetoothLogger.Log(LogPrefix + "Unable to write data - Protocol error");
                    }
                    else
                    {
                        Global.BluetoothLogger.Log(LogPrefix + "Write data Succsess. Data: " + data);
                    }
                }
                catch (Exception ex) when ((uint)ex.HResult == 0x80650003 || (uint)ex.HResult == 0x80070005)
                {
                    // E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED or E_ACCESSDENIED
                    // This usually happens when a device reports that it support writing, but it actually doesn't.
                    Global.BluetoothLogger.Log("Error writing to characteristic. This usually happens when a device reports that it support writing, but it actually doesn't.");
                }
                catch (Exception ex)
                {
                    Global.BluetoothLogger.Log("Error.");
                }
            }
            else
            {
                Global.BluetoothLogger.Log("No data to write to device");
            }
        }

        public async void WriteString(string data)
        {
            IBuffer writeBuffer = null;
            data = data + "\r\n";

            if (!String.IsNullOrEmpty(data))
            {
                Global.BluetoothLogger.Log(LogPrefix + "Writing " + data);
                writeBuffer = CryptographicBuffer.ConvertStringToBinary(data, BinaryStringEncoding.Utf8);
                Global.BluetoothLogger.Log("In bytes: " + GattConvert.ToHexString(writeBuffer));

                try
                {
                    // BT_Code: Writes the value from the buffer to the characteristic.
                    GattCommunicationStatus result = await CharacteristicInfo.WriteValueAsync(writeBuffer);

                    if (result == GattCommunicationStatus.Unreachable)
                    {
                        Global.BluetoothLogger.Log(LogPrefix + "Unable to write data - Device unreachable");
                    }
                    else if (result == GattCommunicationStatus.ProtocolError)
                    {
                        Global.BluetoothLogger.Log(LogPrefix + "Unable to write data - Protocol error");
                    }
                    else
                    {
                        Global.BluetoothLogger.Log(LogPrefix + "Write data Success. Data: " + data);
                    }
                }
                catch (Exception ex) when ((uint)ex.HResult == 0x80650003 || (uint)ex.HResult == 0x80070005)
                {
                    // E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED or E_ACCESSDENIED
                    // This usually happens when a device reports that it support writing, but it actually doesn't.
                    Global.BluetoothLogger.Log("Error writing to characteristic. This usually happens when a device reports that it support writing, but it actually doesn't.");
                }
                catch (Exception ex)
                {
                    Global.BluetoothLogger.Log("Error.");
                }
            }
            else
            {
                Global.BluetoothLogger.Log("No data to write to device");
            }
        }

        public async void ReadData(DisplayType displayType)
        {
            try
            {
                DisplayType = displayType;
                Global.BluetoothLogger.Log(LogPrefix + "Reading Data");
                GattReadResult result = await CharacteristicInfo.ReadValueAsync(BluetoothCacheMode.Uncached);
                if (result.Status == GattCommunicationStatus.Success)
                {
                    Global.BluetoothLogger.Log(LogPrefix + "Value Read Result: " + result.Value.ToString());

                    Value = GattConvert.ToHexString(result.Value);
                    Global.BluetoothLogger.Log(LogPrefix + "Data = " + Value);

                    SetValue(result.Value);

                }
                else if (result.Status == GattCommunicationStatus.ProtocolError)
                {
                    Value = BluetoothLib.GetErrorString(result.ProtocolError);
                }
                else Value = "Unreachable";
            }
            catch (Exception ex)
            {
                Global.BluetoothLogger.Log(LogPrefix + "Exception: " + ex.Message);
                Value = "Exception!";
            }
        }

        private void SetValue(IBuffer buffer)
        {
            rawData = buffer;
            CryptographicBuffer.CopyToByteArray(rawData, out data);
            SetValue();
        }


        private void SetValue()
        {
            if (data == null) 
            {
                Value = "NULL";
                return;
            }

            GattPresentationFormat format = null;
            if (CharacteristicInfo.PresentationFormats.Count > 0)
            {
                format = CharacteristicInfo.PresentationFormats[0];
            }

            SetDisplayType(format);

            byte[] dataArray = GattConvert.ToByteArray(rawData);
            if(Name.Equals(Global.ControlCharacteristics.DataCharacteristicName))
                EventPublisher.RaiseEvent_BluetoothDataArrived_Event(dataArray);
            EventPublisher.RaiseEvent_CharacteristiclDataRead(this, dataArray);

            switch (DisplayType)
            {
                case DisplayType.Unsupported: Value = GattConvert.ToHexString(rawData); break;
                case DisplayType.Hex: Value = GattConvert.ToHexString(rawData); break;
                case DisplayType.Decimal: Value = GattConvert.ToInt32(rawData).ToString(); break;
                case DisplayType.UTF8: Value = GattConvert.ToUTF8String(rawData); break;
                case DisplayType.UTF16: Value = GattConvert.ToUTF16String(rawData); break;
            }

            EventPublisher.RaiseEvent_CharacteristicStringDataRead(this, Value);
        }

        private void SetDisplayType(GattPresentationFormat format)
        {
            if (format == null && DisplayType == DisplayType.NotSet)
            {
                if (Name.Equals("DeviceName"))
                {
                    // All devices have DeviceName so this is a special case. 
                    DisplayType = DisplayType.UTF8;
                }
                else
                {
                    bool isString = IsRawDataIsString();
                    DisplayType = isString ? DisplayType.UTF8 : DisplayType = DisplayType.Hex;
                }
            }
            else if (format != null && DisplayType == DisplayType.NotSet)
            {
                if (format.FormatType == GattPresentationFormatTypes.Boolean ||
                    format.FormatType == GattPresentationFormatTypes.Bit2 ||
                    format.FormatType == GattPresentationFormatTypes.Nibble ||
                    format.FormatType == GattPresentationFormatTypes.UInt8 ||
                    format.FormatType == GattPresentationFormatTypes.UInt12 ||
                    format.FormatType == GattPresentationFormatTypes.UInt16 ||
                    format.FormatType == GattPresentationFormatTypes.UInt24 ||
                    format.FormatType == GattPresentationFormatTypes.UInt32 ||
                    format.FormatType == GattPresentationFormatTypes.UInt48 ||
                    format.FormatType == GattPresentationFormatTypes.UInt64 ||
                    format.FormatType == GattPresentationFormatTypes.SInt8 ||
                    format.FormatType == GattPresentationFormatTypes.SInt12 ||
                    format.FormatType == GattPresentationFormatTypes.SInt16 ||
                    format.FormatType == GattPresentationFormatTypes.SInt24 ||
                    format.FormatType == GattPresentationFormatTypes.SInt32)
                {
                    DisplayType = DisplayType.Decimal;
                }
                else if (format.FormatType == GattPresentationFormatTypes.Utf8)
                {
                    DisplayType = DisplayType.UTF8;
                }
                else if (format.FormatType == GattPresentationFormatTypes.Utf16)
                {
                    DisplayType = DisplayType.UTF16;
                }
                else if (format.FormatType == GattPresentationFormatTypes.UInt128 ||
                    format.FormatType == GattPresentationFormatTypes.SInt128 ||
                    format.FormatType == GattPresentationFormatTypes.DUInt16 ||
                    format.FormatType == GattPresentationFormatTypes.SInt64 ||
                    format.FormatType == GattPresentationFormatTypes.Struct ||
                    format.FormatType == GattPresentationFormatTypes.Float ||
                    format.FormatType == GattPresentationFormatTypes.Float32 ||
                    format.FormatType == GattPresentationFormatTypes.Float64)
                {
                    DisplayType = DisplayType.Unsupported;
                }
                else
                {
                    DisplayType = DisplayType.Unsupported;
                }
            }
        }

        private bool IsRawDataIsString()
        {
            string buffer = string.Empty;

            try { buffer = GattConvert.ToUTF8String(rawData); }
            catch (Exception) { return false; }

            // if buffer is only 1 char or 2 char with 0 at end then let's assume it's hex
            if (buffer.Length == 1) { return false; }
            else if (buffer.Length == 2 && buffer[1] == 0) { return false; }
            else
            {
                foreach (char b in buffer)
                {
                    // if within the reasonable range of used characters and not null, let's assume it's a UTF8 string by default, else hex
                    if ((b < ' ' || b > '~') && b != 0) { return false; }
                }
            }
            return true;
        }

        public async void StartNotify()
        {
            if (IsNotifySet == true) return;

            try
            {
                // BT_Code: Must write the CCCD in order for server to send indications.
                // We receive them in the ValueChanged event handler.
                // Note that this sample configures either Indicate or Notify, but not both.
                var result = await
                        CharacteristicInfo.WriteClientCharacteristicConfigurationDescriptorAsync(
                            GattClientCharacteristicConfigurationDescriptorValue.Notify);
                if (result == GattCommunicationStatus.Success)
                {
                    Global.BluetoothLogger.Log(LogPrefix + "Notification Started Successfully");
                    IsNotifySet = true;
                    EventPublisher.RaiseEvent_CharacteristicNotificationsStarted(this);
                    return;
                }
                else if (result == GattCommunicationStatus.ProtocolError)
                {
                    Global.BluetoothLogger.Log(LogPrefix + "Error registering for notifications: Protocol Error");
                    IsNotifySet = false;
                    return;
                }
                else if (result == GattCommunicationStatus.Unreachable)
                {
                    Global.BluetoothLogger.Log(LogPrefix + "Error registering for notifications: Unreachable");
                    IsNotifySet = false;
                    return;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // This usually happens when a device reports that it support indicate, but it actually doesn't.
                Global.BluetoothLogger.Log(LogPrefix + "Unauthorized Exception (This usually happens when a device reports that it support indicate, but it actually doesn't.): " + ex.Message);
                IsNotifySet = false;
                return;
            }
            catch (Exception ex)
            {
                Global.BluetoothLogger.Log(LogPrefix + "Generic Exception: " + ex.Message);
                IsNotifySet = false;
                return;
            }

            IsNotifySet = false;
            return;
        }

        public async Task StopNotify()
        {
            //   if (IsNotifySet == false) return;
            try
            {
                // BT_Code: Must write the CCCD in order for server to send indications.
                // We receive them in the ValueChanged event handler.
                // Note that this sample configures either Indicate or Notify, but not both.
                var result = await
                        CharacteristicInfo.WriteClientCharacteristicConfigurationDescriptorAsync(
                            GattClientCharacteristicConfigurationDescriptorValue.None);
                if (result == GattCommunicationStatus.Success)
                {
                    Global.BluetoothLogger.Log(LogPrefix + "Notification Stopped Successfully");
                    IsNotifySet = false;
                    return;
                }
                else if (result == GattCommunicationStatus.ProtocolError)
                {
                    Global.BluetoothLogger.Log(LogPrefix + "Error un-registering for notifications: Protocol Error");
                    IsNotifySet = true;
                    return;
                }
                else if (result == GattCommunicationStatus.Unreachable)
                {
                    Global.BluetoothLogger.Log(LogPrefix + "Error un-registering for notifications: Unreachable");
                    IsNotifySet = true;
                    return;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // This usually happens when a device reports that it support indicate, but it actually doesn't.
                Global.BluetoothLogger.Log(LogPrefix + "Exception (This usually happens when a device reports that it support indicate, but it actually doesn't.): " + ex.Message);
                IsNotifySet = true;
                return;
            }

            return;
        }

        public async void Disconnect()
        {
            if (CharacteristicInfo != null) CharacteristicInfo.ValueChanged -= Characteristic_ValueChanged;
            if (IsNotifySet) await StopNotify();
        }
    }
}
