using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_ButtonInButtonsModel
    {
        public int Id { get; set; }
        public int ButtonProdId { get; set; }
        public string ButtonName { get; set; }
        public int ProductId { get; set; }
        public int SortOrder { get; set; }
    }
}
