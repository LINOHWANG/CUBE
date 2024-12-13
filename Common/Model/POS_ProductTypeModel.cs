using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_ProductTypeModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public bool IsLiquor { get; set; }
        public int SortOrder { get; set; }
        public bool IsRestaurant { get; set; }
        public bool IsBatchDonation { get; set; }
        public bool IsBatchDiscount { get; set; }

        public string ForeColor { get; set; }
        public string BackColor { get; set; }

    }
}
