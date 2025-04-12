using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_TaxModel
    {
        public string Code { get; set; }
        public float Tax1 { get; set; }
        public float Tax2 { get; set; }
        public float Tax3 { get; set; }

        public bool IsTax3IncTax1 { get; set; }

        public string Tax1Name { get; set; }
        public string Tax2Name { get; set; }
        public string Tax3Name { get; set; }
    }
}
