using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace MattressHeatmap
{
    public static class EventPublisher
    {
        public delegate void EventHandler_Void();
        public delegate void EventHandler_ByteArray(byte[] data);
        public delegate void EventHandler_CharacteristicRead(BluetoothCharacteristic characteristic, byte[] data);
        public delegate void EventHandler_GattCharacteristic(GattCharacteristic characteristic);
        public delegate void EventHandler_Service(BluetoothService service);
        public delegate void EventHandler_Device(BluetoothDevice device);
        public delegate void EventHandler_Characteristic(BluetoothCharacteristic characteristic);
        public delegate void EventHandler_CharacteristicReadString(BluetoothCharacteristic characteristic, string value);
        public delegate void EventHandler_StartSequenceStep(int stepIndex, string operationName);

        public static event EventHandler_ByteArray BluetoothDataArrived_Event;
        public static event EventHandler_CharacteristicRead CharacteristiclDataRead_Event;
        public static event EventHandler_GattCharacteristic CharacteristicFound_Event;
        public static event EventHandler_Service AllCharacteristicsFound_Event;
        public static event EventHandler_Device FlowState_Event;
        public static event EventHandler_Device AllServicesFound_Event;
        public static event EventHandler_CharacteristicReadString CharacteristicStringDataRead_Event;
        public static event EventHandler_Characteristic CharacteristicNotificationsStarted_Event;
        public static event EventHandler_Void GotCalibration_Event;
        public static event EventHandler_StartSequenceStep StartSequenceStepFinished_Event;

        public static void RaiseEvent_BluetoothDataArrived_Event(byte[] data)
        {
            BluetoothDataArrived_Event?.Invoke(data);
        }

        public static void RaiseEvent_CharacteristiclDataRead(BluetoothCharacteristic characteristic, byte[] data)
        {
            CharacteristiclDataRead_Event?.Invoke(characteristic, data);
        }

        public static void RaiseEvent_CharacteristicStringDataRead(BluetoothCharacteristic characteristic, string value)
        {
            CharacteristicStringDataRead_Event?.Invoke(characteristic, value);
        }

        public static void RaiseEvent_CharacteristicFound_Event(GattCharacteristic characteristic)
        {
            CharacteristicFound_Event?.Invoke(characteristic);
        }

        public static void RaiseEvent_AllCharacteristicsFound(BluetoothService service)
        {
            if (AllCharacteristicsFound_Event != null) AllCharacteristicsFound_Event(service);
        }

        public static void RaiseEvent_FlowState(BluetoothDevice device)
        {
            if (FlowState_Event != null) FlowState_Event(device);
        }

        public static void RaiseEvent_AllServicesFound(BluetoothDevice device)
        {
            if (AllServicesFound_Event != null) AllServicesFound_Event(device);
        }

        public static void RaiseEvent_CharacteristicNotificationsStarted(BluetoothCharacteristic characteristic)
        {
            CharacteristicNotificationsStarted_Event?.Invoke(characteristic);
        }

        public static void RaiseEvent_GotCalibration()
        {
            GotCalibration_Event?.Invoke();
        }

        public static void RaiseEvent_StartSequenceStepFinished(int stepIndex, string operationName)
        {
            StartSequenceStepFinished_Event?.Invoke(stepIndex, operationName);
        }
    }
}
