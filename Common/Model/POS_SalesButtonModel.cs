using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_SalesButtonModel
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public float ButtonLeft { get; set; }
        public float ButtonTop { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string FontName { get; set; }
        public float FontSize { get; set; }
        public int FontStyle { get; set; }
        public string ForeColor { get; set; }
        public string BackColor { get; set; }
        public int ProductId { get; set; }
        public bool IsVisible { get; set; }
        public bool IsBIB { get; set; }
    }
}
