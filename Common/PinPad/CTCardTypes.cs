using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.PinPad
{
    public class CTCardTypes
    {
        public const string Debit = "00";
        public const string Visa = "01";
        public const string MasterCard = "02";
        public const string Amex = "03";
        public const string DinersClub = "04";
        public const string DiscoverCard = "05";
        public const string JCB = "06";
        public const string UnionPayCard = "07";
        public const string OtherCreditCard = "08";
        public const string GiftCard = "09";
        public const string Cash = "10";
        public const string EBTFoodStamp = "11";
        public const string EBTCashBenefit = "12";
        public static string GetTypeName(string code)
        {
            foreach (var field in typeof(CTCardTypes).GetFields())
            {
                if ((string)field.GetValue(null) == code)
                    return field.Name.ToString();
            }
            return "";
        }
    }
}
