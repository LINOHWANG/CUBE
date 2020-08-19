using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.PinPad
{
    public class CTTransactionTypes
    {
        public const string SalePurchase = "00";
        public const string PreAuth = "01";
        public const string PreAuthCompletion = "02";
        public const string Refund = "03";
        public const string Force = "04";
        public const string Void = "05";
        public const string CardBalanceInquiry = "06";
        public const string AuthOnly = "07";
        public const string IncrementalAuth = "08";
        public const string Settlement = "20";
        public const string AutoSettlement = "21";
        public const string ReprintReceipt = "22";
        public const string DetailReport = "30";
        public const string SummaryReport = "31";
        public const string EMVLastTransactionReport = "32";
        public const string ClerkSummaryReport = "33";
        public const string ParametersReport = "34";
        public const string OpenPreAuth = "35";
        public const string RecentError = "36";
        public const string ActivityReport = "37";
        public const string ClerkIdList = "38";
        public const string EMVParameters = "39";
        public const string EMVStatistic = "40";
        public const string EMVPublicKey = "41";
        public const string TerminalInfo = "42";
        public const string EMVKeyDate = "43";
        public const string IssuanceReload = "50";
        public const string Activation = "51";
        public const string BlockActivation = "52";
        public const string Redemption = "53";
        public const string AddTip = "54";
        public const string ForceIssuance = "55";
        public const string ForceActivation = "56";
        public const string ForceRedemption = "57";
        public const string Deactivation = "58";
        public const string BlockDeactivation = "59";
        public const string Reactivation = "60";
        public const string ZeroGiftCardBalance = "61";
        public const string BlockReactivation = "63";
        public const string CashDrawerStatus = "70";
        public const string CashDrawerOpen = "71";
        public const string CashDrawerCapability = "72";
        public static string GetTypeName(string code)
        {
            foreach (var field in typeof(CTTransactionTypes).GetFields())
            {
                if ((string)field.GetValue(null) == code)
                    return field.Name.ToString();
            }
            return "";
        }
    }
}
