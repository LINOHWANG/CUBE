using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.PinPad
{
    public class CTTransactionStatuses
    {
        public const string Approved = "00";
        public const string PartialApproved = "01";
        public const string DeclinedByHostOrCard = "10";
        public const string CommunicationError = "11";
        public const string CancelledByUser = "12";
        public const string TimedOutOnUserInput = "13";
        public const string TransactionNotCompleted = "14";
        public const string BatchEmpty = "15";
        public const string DeclinedByMerchant = "16";
        public const string RecordNotFound = "17";
        public const string TransactionVoided = "18";
        public const string InvalidECRParameter = "30";
        public const string BatteryLow = "31";
        public const string CashDrawerSuccess = "40";
        public const string CashDrawerFailed = "41";
        public const string NotTSIMode = "95";
        public const string Receipt = "99";
    }
}
