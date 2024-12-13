using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{

    public class POS_CategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsSeparateReport { get; set; }
        public bool IsDCException { get; set; }
    }
}