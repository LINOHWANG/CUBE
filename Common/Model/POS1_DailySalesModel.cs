using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS1_DailySalesModel
    {
        public string TranDate { get; set; }
        public double Amount { get; set; }
        public double Tax1 { get; set; }
        public double Tax2 { get; set; }
        public double Tax3 { get; set; }
        public double TotalSales { get; set; }
        public double Cash { get; set; }
        public double Debit { get; set; }
        public double Visa { get; set; }
        public double Master { get; set; }
        public double Amex { get; set; }
        public double GiftCard { get; set; }
        public double Cheque { get; set; }
        public double Charge { get; set; }
        
        public int Trans { get; set; }
    }
}
