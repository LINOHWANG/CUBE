using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDCafeSales.Views
{
    public partial class frmYesNo : Form
    {
        frmSalesMain FrmSalesMain;
        public string p_strTitle { get; set; }
        public string p_strMessage { get; set; }
        public Boolean bYesNo = false;
        public frmYesNo(frmSalesMain _FrmSalesMain)
        {
            InitializeComponent();
            this.FrmSalesMain = _FrmSalesMain;
            bYesNo = false;
        }
        public void Set_Title(string strTitle)
        {
            p_strTitle = strTitle;
            this.Text = p_strTitle;
        }
        public void Set_Message(string strMessage)
        {
            p_strMessage = strMessage;
            lbl_Message.Text = p_strMessage;
            lbl_Message.Left = (this.Width / 2) - (lbl_Message.Width / 2);
        }

        private void bt_Yes_Click(object sender, EventArgs e)
        {
            bYesNo = true;
            this.Close();
        }

        private void bt_No_Click(object sender, EventArgs e)
        {
            bYesNo = false;
            this.Close();
        }
    }
}
