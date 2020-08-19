using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;

namespace SDCafeOffice.Views
{
    public partial class frmStations : Form
    {
        List<POS_StationModel> stations = new List<POS_StationModel>();
        Utility util = new Utility();
        bool isInsert = false;
        public frmStations()
        {
            InitializeComponent();
        }
        public frmStations(String strHostName)
        {
            InitializeComponent();
            txt_HostName.Text = strHostName;
            //txt_HostName.Enabled = false;
            if (String.IsNullOrEmpty(txt_HostName.Text))
            {
                txtMessage.Text = "No Station was selected. Insert(Save) mode is on!";
                isInsert = true;
            }
            else
            {
                txtMessage.Text = "Selected HostName : " + strHostName;
                Load_Station_Info(strHostName);
                isInsert = false;
            }
        }

        private void Load_Station_Info(string strHostName)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            stations.Clear();
            stations = dbPOS.Get_Station_By_HostName(strHostName);
            if (stations.Count == 1)
            {
                txt_HostName.Text = stations[0].ComputerName;
                txt_Station.Text = stations[0].Station;
                txt_StationName.Text = stations[0].StationName;
                txt_IPAddr.Text = stations[0].IP_Addr;
                txt_IPS_Port.Text = stations[0].IPS_Port.ToString();
                if (stations[0].Enabled)
                {
                    check_IsActive.Checked = true;
                }
                else
                {
                    check_IsActive.Checked = false;
                }
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (isInsert)
            {
                Insert_Station_From_View();
            }
            else
            {
                Update_Station_From_View();
            }
        }

        private void Update_Station_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";

            stations.Clear();
            stations.Add(new POS_StationModel()
            {
                ComputerName = txt_HostName.Text,
                Station = txt_Station.Text,
                StationName = txt_StationName.Text,
                IP_Addr = txt_IPAddr.Text,
                StationNo = int.Parse(txt_StationNo.Text),
                IPS_Port = int.Parse(txt_IPS_Port.Text),
                Enabled = check_IsActive.Checked
            });
            int iProdCnt = dbPOS.Update_Station(stations[0]);
        }

        private void Insert_Station_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";

            stations.Clear();
            stations.Add(new POS_StationModel()
            {
                ComputerName = txt_HostName.Text,
                Station = txt_Station.Text,
                StationName = txt_StationName.Text,
                IP_Addr = txt_IPAddr.Text,
                StationNo = int.Parse(txt_StationNo.Text),
                IPS_Port = int.Parse(txt_IPS_Port.Text),
                Enabled = check_IsActive.Checked
            });
            int iProdCnt = dbPOS.Insert_Station(stations[0]);
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }
    }
}
