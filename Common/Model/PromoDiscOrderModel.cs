using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class PromoDiscOrderModel
    {
        public int iPromoId { get; set; }
        public string PromoName { get; set; }
        public double OutUnitPrice { get; set; }

        public double Amount { get; set; }
        public double Qty { get; set; }
        public bool IsTax1 { get; set; }
        public bool IsTax2 { get; set; }
        public bool IsTax3 { get; set; }

    }
}
