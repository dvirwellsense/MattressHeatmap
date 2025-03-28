﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace MattressHeatmap
{
    public static class BluetoothLib
    {
        public static string GetErrorString(byte? errorValue)
        {
            string ret = "Protocol Error";

            if (errorValue.HasValue == false)
            {
                return ret;
            }

            if (errorValue == GattProtocolError.AttributeNotFound)
            {
                return "Attribute Not Found";
            }
            else if (errorValue == GattProtocolError.AttributeNotLong)
            {
                return "Attribute Not Long";
            }
            else if (errorValue == GattProtocolError.InsufficientAuthentication)
            {
                return "Insufficient Authentication";
            }
            else if (errorValue == GattProtocolError.InsufficientAuthorization)
            {
                return "Insufficient Authorization";
            }
            else if (errorValue == GattProtocolError.InsufficientEncryption)
            {
                return "Insufficient Encryption";
            }
            else if (errorValue == GattProtocolError.InsufficientEncryptionKeySize)
            {
                return "Insufficient Encryption Key Size";
            }
            else if (errorValue == GattProtocolError.InsufficientResources)
            {
                return "Insufficient Resources";
            }
            else if (errorValue == GattProtocolError.InvalidAttributeValueLength)
            {
                return "Invalid Attribute Value Length";
            }
            else if (errorValue == GattProtocolError.InvalidHandle)
            {
                return "Invalid Handle";
            }
            else if (errorValue == GattProtocolError.InvalidOffset)
            {
                return "Invalid Offset";
            }
            else if (errorValue == GattProtocolError.InvalidPdu)
            {
                return "Invalid Pdu";
            }
            else if (errorValue == GattProtocolError.PrepareQueueFull)
            {
                return "Prepare Queue Full";
            }
            else if (errorValue == GattProtocolError.ReadNotPermitted)
            {
                return "Read Not Permitted";
            }
            else if (errorValue == GattProtocolError.RequestNotSupported)
            {
                return "Request Not Supported";
            }
            else if (errorValue == GattProtocolError.UnlikelyError)
            {
                return "UnlikelyError";
            }
            else if (errorValue == GattProtocolError.UnsupportedGroupType)
            {
                return "Unsupported Group Type";
            }
            else if (errorValue == GattProtocolError.WriteNotPermitted)
            {
                return "Write Not Permitted";
            }

            return ret;
        }
    }
}
