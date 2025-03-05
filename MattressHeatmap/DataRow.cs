using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public enum SubTypeT : byte
    {
        kEmptySubType = 0,//		= 0,
        kStart = 1,
        kStop = 2,
        kSelfTest = 3,
        kGetOverlayId = 4,
        kGetOverlayTemp = 5,
        kGetOverlayLife = 6,
        kSetOverlayLife = 7,
        kGetOverlayLut = 8,
        kGetOverlaySize = 9,
        kMeasureSpecificArea = 10,
        kGetAcFreq = 11,
        kGetOverlayManDate = 12,
        kPeriodicTest = 13,
        kError = 14,
        kLogMessage = 15,
        kReturnOverlayId = 16,
        kReturnOverlayTemp = 17,
        kReturnOverlayLife = 18,
        kReturnOverlayLut = 19,
        kReturnOverlaySize = 20,
        kReturnAcFreq = 21,
        kReturnOverlayManDate = 22,
        kOverlayDisconnected = 23,
        kOverlayReconnected = 24,
        kReturnRow = 25,
        kReturnSelfTestRes = 26,
        kGetHwcVersion = 27,
        kReturnHwcVersion = 28,
        kGetCellSize = 29,
        kReturnCellSize = 30,
        kGetAdcFactor = 31,
        kReturnAdcFactor = 32,
        kReady = 33,
        kStarted = 34,
        kStopped = 35,
        kGotOverlayParams = 36,
        kGotOverlayParamsResponse = 37,
        kReturnPeriodicTestResults = 38,
        kGetOverlayVersion = 39,
        kReturnOverlayVersion = 40,
        kSetOverlayLifeResponse = 41,
        kGetRl = 42,
        kReturnRl = 43,
        kGetCp = 44,
        kReturnCp = 45,
        kGetAcPk2Pk = 46,
        kReturnAcPk2Pk = 47,
        kGetFirstActDate = 48,
        kReturnFirstActDate = 49,
        kGetChecksum = 50,
        kReturnCheckSum = 51,
        kSetFirstActDate = 52,
        kSetFirstActDateResponse = 53,
        kReadyResponse = 54,
        kKeepAliveResponse = 55,
        kOlayEepromBurnData = 56,
        kOlayEepromBurnDataResponse = 57,
        kRequestOlayEepromCurrentData = 58,
        kReturnOlayEepromCurrentData = 59,
        kGotAllHwcParams = 60,
        kGotAllHwcParamsResponse = 61,
        kGotoHwcParams = 62,
        kGotoHwcParamsResponse = 63,
        KGotEventResponse = 64,
        kGetConstAmp = 65,
        kReturnConstAmp = 66,
        kGetConstCap = 67,
        kReturnConstCap = 68,
        kReset = 69,
        kResetResponse = 70,
        kGetHwcParamsAtOnce = 71,
        kGetHwcParamsAtOnceResponse = 72,
        kGetOvcParamsAtOnce = 73,
        kGetOvcParamsAtOnceResponse = 74,
        kGetLutAtOnce = 75,
        kGetLutAtOnceResponse = 76,
        kKeepAlive = 77,
        kUpgradeHwc = 78,
        kUpgradeHwcAck = 79,
        kUpgradeHwcVerified = 80,
        kUpgradeHwcVerifiedAck = 81,
        kStartImageTransferSession = 82,
        kStartImageTransferSessionResponse = 83,
        kEndImageTransferSession = 84,
        kEndImageTransferSessionResponse = 85,
        kCheckUpgradeValidity = 86,
        kCheckUpgradeValidityResponse = 87,
        kStartImageTransfer = 88,
        kStartImageTransferResponse = 89,
        kSendNextImageBlock = 90,
        kSendNextImageBlockResponse = 91,
        kEndImageTransfer = 92,
        kEndImageTransferResponse = 93,
        kPowerStatus = 94,
        kPowerStatusResponse = 95,
        kPowerPlugged = 96,
        kPowerUnplugged = 97,
        kPowerConfig = 98,//TODO: add in final code 98
        kPowerConfigResponse = 99,
        kHwcUpgrade = 100,
        kLastSubType = kEndImageTransferResponse
    };

    public enum Status : byte //asaf
    {
        kSuccess = 0,
        kFailed = 1,
        kUnknownCommand = 2,
        kInvalidParameter = 3,
        kTimeout = 4,
        kDisconnect = 5,
        kInvalidRequest = 6,    //will be sent from the HWC when an illegal request was recieved according to the state machine
        kMsgToLongHwc = 7,
        kNoCallback = 8,
        kGetNextParamOutOfBounds = 12,
        kStatus_InternalError = 13,

        kImageTooLarge,     // The total size of the transferred image blocks exceeds the maximum available size
        kInvalidImageSize,  // Transferred image size mismatches the sum of individual blocks
        kInvalidImageChecksum,  // Transferred image failed checksum verification

        kFlashProgramError      // IAP failed
    };

    public enum CategoryT : byte
    {
        kRequest = 1,
        kResponse = 2,
        kEvent = 3,
        kEventNoResponse = 4
    };

    public class DataRow
    {
        public byte[] Sync { get; set; }
        public byte MessageNumber { get; set; }
        public short MessageLength { get; set; }
        public CategoryT Category { get; set; }
        public SubTypeT SubType { get; set; }
        public Status Status { get; set; }
        public byte Size { get; set; }
        public byte Index { get; set; }
        public List<Int16> Values { get; set; }
        public List<byte> Amps { get; set; }
        public Int16 RefValue { get; set; }
        public byte RefAmp { get; set; }

        public bool IsValid { get; set; }

        public DataRow()
        {

        }

        public DataRow(List<byte> data)
        {
            ParseData(data);
        }

        public void ParseData(List<byte> data)
        {
            if ((SubTypeT)data[8] == SubTypeT.kReturnRow) IsValid = true;
            else
            {
                IsValid = false;
                return;
            }

            Sync = data.GetRange(0, 4).ToArray();
            MessageNumber = data[4];
            MessageLength = BitConverter.ToInt16(data.GetRange(5, 2).ToArray(), 0);
            //Status = (Status)data[9];
            Status = (Status)data[6];
            // ^ Change Later ^
            Category = (CategoryT)data[7];
            SubType = (SubTypeT)data[8];

            Index = data[9];
            Size = data[10];

            Values = new List<Int16>();
            Amps = new List<byte>();

            for (int i = 0; i < Size; i++)
            {
                Values.Add((Int16)(data[i * 2 + 11] + data[i * 2 + 12] * 256));
                Amps.Add(data[i + Size * 2 + 11]);
            }

            RefValue = Values[Size - 1];
            RefAmp = Amps[Size - 1];
        }
    }
}
