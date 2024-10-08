using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_StationModel
    {
        public string ComputerName { get; set; }
        public string Station { get; set; }
        public string StationName { get; set; }
        public string Created_Dttm { get; set; }
        public string Modified_Dttm { get; set; }
        public string IP_Addr { get; set; }
        public int StationNo { get; set; }
        public int IPS_Port { get; set; }
        public int POLE_COM_Port { get; set; }
        public string POLE_COM_Settings { get; set; }
        public int CAS_COM_Port { get; set; }
        public string CAS_COM_Settings { get; set; }
        public string CAS_Init_Char { get; set; }
        public string CAS_Req_Char { get; set; }
        public bool Enabled { get; set; }
        //* Paymentree is a flag to indicate if this station is a paymentree station -----------------
        public bool IsPaymentree { get; set; }
        public string Client_Id { get; set; }
        public string Location { get; set; }
        public string Register { get; set; }
    }
}
