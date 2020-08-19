using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;

namespace SDCafeCommon.PinPad
{
    public class CCardProcess
    {
        Utility util = new Utility();
        public Boolean processData(string strData, int p_iInvNo, string p_Station, string p_UserName)
        {
            DataAccessCard dbCard = new DataAccessCard();
            CCardReceipt cardReceipt = new CCardReceipt();
            CCardTran cardTran = new CCardTran();
            string strTranStatus = "";
            string strSeqNo = "";
            string strTagNo = "";
            string strTagVal = "";
            util.Logger(" ==> processData started <==");
            String[] strlist = strData.Split(util.GetCharFromHex(CCardTranConst.CON_CT_FS));
            int index = 0;

            util.Logger(" ==> Total processData count : " + strlist.Count());
            foreach (String s in strlist)
            {
                if (index == 0)
                {
                    strTranStatus = s.Substring(0, 2);
                    strSeqNo = s.Substring(2);
                }
                else
                {
                    strTagNo = s.Substring(0, 3);
                    strTagVal = s.Substring(3);
                    if (strTranStatus == CTTransactionStatuses.Receipt)
                    {
                        if (strTagNo == CTTags.TransactionType) cardReceipt.TransactionType = strTagVal;
                        if (strTagNo == CTTags.TransactionStatus) cardReceipt.TransactionStatus = strTagVal;
                        if (strTagNo == CTTags.TransactionDate) cardReceipt.TransactionDate = strTagVal;
                        if (strTagNo == CTTags.TransactionTime) cardReceipt.TransactionTime = strTagVal;
                        if (strTagNo == CTTags.TransactionAmount) cardReceipt.TransactionAmount = strTagVal;
                        if (strTagNo == CTTags.TipAmount) cardReceipt.TipAmount = strTagVal;
                        if (strTagNo == CTTags.TotalAmount) cardReceipt.TotalAmount = strTagVal;
                        if (strTagNo == CTTags.ReferenceNo) cardReceipt.ReferenceNo = strTagVal;
                        if (strTagNo == CTTags.CustomerCardType) cardReceipt.CustomerCardType = strTagVal;
                        if (strTagNo == CTTags.CustomerCardDescription) cardReceipt.CustomerCardDescription = strTagVal;
                        if (strTagNo == CTTags.CustomerAccountNumber) cardReceipt.CustomerAccountNumber = strTagVal;
                        if (strTagNo == CTTags.CustomerLanguage) cardReceipt.CustomerLanguage = strTagVal;
                        if (strTagNo == CTTags.CustomerCardEntryMode) cardReceipt.CustomerCardEntryMode = strTagVal;
                        if (strTagNo == CTTags.EmvAid) cardReceipt.EmvAid = strTagVal;
                        if (strTagNo == CTTags.EmvTvr) cardReceipt.EmvTvr = strTagVal;
                        if (strTagNo == CTTags.EmvTsi) cardReceipt.EmvTsi = strTagVal;
                        if (strTagNo == CTTags.EMVApplicationLabel) cardReceipt.EMVApplicationLabel = strTagVal;
                        if (strTagNo == CTTags.CVMResult) cardReceipt.CVMResult = strTagVal;
                        if (strTagNo == CTTags.AuthorizationNo) cardReceipt.AuthorizationNo = strTagVal;
                        if (strTagNo == CTTags.HostResponseCode) cardReceipt.HostResponseCode = strTagVal;
                        if (strTagNo == CTTags.HostResponseText) cardReceipt.HostResponseText = strTagVal;
                        if (strTagNo == CTTags.TraceNo) cardReceipt.TraceNo = strTagVal;
                        if (strTagNo == CTTags.HostTransactionRefNbr) cardReceipt.HostTransactionRefNbr = strTagVal;
                        if (strTagNo == CTTags.BatchNumber) cardReceipt.BatchNumber = strTagVal;
                        if (strTagNo == CTTags.TerminalId) cardReceipt.TerminalId = strTagVal;
                        if (strTagNo == CTTags.MerchId) cardReceipt.MerchId = strTagVal;
                        if (strTagNo == CTTags.HostTransactionRefNbr) cardReceipt.HostTransactionRefNbr = strTagVal;
                        if (strTagNo == CTTags.ReceiptHeader1) cardReceipt.ReceiptHeader1 = strTagVal;
                        if (strTagNo == CTTags.ReceiptHeader2) cardReceipt.ReceiptHeader2 = strTagVal;
                        if (strTagNo == CTTags.ReceiptHeader3) cardReceipt.ReceiptHeader3 = strTagVal;
                        if (strTagNo == CTTags.ReceiptHeader4) cardReceipt.ReceiptHeader4 = strTagVal;
                        if (strTagNo == CTTags.ReceiptFooter1) cardReceipt.ReceiptFooter1 = strTagVal;
                        if (strTagNo == CTTags.EndorsementLine1) cardReceipt.EndorsementLine1 = strTagVal;
                        if (strTagNo == CTTags.EndorsementLine2) cardReceipt.EndorsementLine2 = strTagVal;
                        if (strTagNo == CTTags.EndorsementLine3) cardReceipt.EndorsementLine3 = strTagVal;
                        if (strTagNo == CTTags.EmvRespCode) cardReceipt.EmvRespCode = strTagVal;
                    }
                    if (strTranStatus == CTTransactionStatuses.Approved)
                    {
                        if (strTagNo == CTTags.TransactionType) cardTran.TransactionType = strTagVal;
                        if (strTagNo == CTTags.TransactionDate) cardTran.TransactionDate = strTagVal;
                        if (strTagNo == CTTags.TransactionTime) cardTran.TransactionTime = strTagVal;
                        if (strTagNo == CTTags.TransactionAmount) cardTran.TransactionAmount = strTagVal;
                        if (strTagNo == CTTags.TipAmount) cardTran.TipAmount = strTagVal;
                        if (strTagNo == CTTags.TotalAmount) cardTran.TotalAmount = strTagVal;
                        if (strTagNo == CTTags.ReferenceNo) cardTran.ReferenceNo = strTagVal;
                        if (strTagNo == CTTags.CustomerCardType) cardTran.CustomerCardType = strTagVal;
                        if (strTagNo == CTTags.CustomerAccountNumber) cardTran.CustomerAccountNumber = strTagVal;
                        if (strTagNo == CTTags.CustomerCardEntryMode) cardTran.CustomerCardEntryMode = strTagVal;
                        if (strTagNo == CTTags.AuthorizationNo) cardTran.AuthorizationNo = strTagVal;
                        if (strTagNo == CTTags.HostResponseCode) cardTran.HostResponseCode = strTagVal;
                        if (strTagNo == CTTags.HostResponseText) cardTran.HostResponseText = strTagVal;
                        if (strTagNo == CTTags.HostTransactionRefNbr) cardTran.HostTransactionRefNbr = strTagVal;
                        if (strTagNo == CTTags.TerminalId) cardTran.TerminalId = strTagVal;
                    }
                }
                util.Logger(" ==> Index : " + index.ToString("D3") + " Tag " + s.Substring(0, 3) 
                                            + " [" + CTTags.GetTagName(s.Substring(0, 3)) + "] : " + s.Substring(3));
                index++;
            }
            if (strTranStatus == CTTransactionStatuses.Receipt)
            {
                cardReceipt.ReceiptInformation = strTranStatus;
                cardReceipt.SeqNo = strSeqNo;
                cardReceipt.CreateInvoiceNo = p_iInvNo;
                cardReceipt.CreateStation = p_Station;
                cardReceipt.CreateUserName = p_UserName;
                cardReceipt.CreateDate = DateTime.Now.ToShortDateString();
                cardReceipt.CreateTime = DateTime.Now.ToShortTimeString();
                int iInsertCount = dbCard.Insert_CardReceipt(cardReceipt);
                util.Logger(" ==> processData CardReceipt Inserted <== " + iInsertCount);
            }
            else if (strTranStatus == CTTransactionStatuses.Approved)
            {
                cardTran.TransactionStatus = strTranStatus;
                cardTran.CreateInvoiceNo = p_iInvNo;
                cardTran.CreateStation = p_Station;
                cardTran.CreateUserName = p_UserName;
                cardReceipt.CreateDate = DateTime.Now.ToShortDateString();
                cardReceipt.CreateTime = DateTime.Now.ToShortTimeString();
                int iInsertCount = dbCard.Insert_CardTran(cardTran);
                util.Logger(" ==> processData CardTran Inserted <== " + iInsertCount);
            }
            util.Logger(" ==> processData finished <== ");
            return true;
        }

        public string GetCustomerCardType(string strData)
        {
            DataAccessCard dbCard = new DataAccessCard();
            CCardReceipt cardReceipt = new CCardReceipt();
            CCardTran cardTran = new CCardTran();
            string strTranStatus = "";
            string strSeqNo = "";
            string strTagNo = "";
            string strTagVal = "";
            util.Logger(" ==> GetCustomerCardType started <==");
            String[] strlist = strData.Split(util.GetCharFromHex(CCardTranConst.CON_CT_FS));
            int index = 0;

            util.Logger(" ==> Total GetCustomerCardType count : " + strlist.Count());
            foreach (String s in strlist)
            {
                if (index == 0)
                {
                    strTranStatus = s.Substring(0, 2);
                    strSeqNo = s.Substring(2);
                }
                else
                {
                    strTagNo = s.Substring(0, 3);
                    strTagVal = s.Substring(3);
                    if (strTranStatus == CTTransactionStatuses.Receipt)
                    {
                        if (strTagNo == CTTags.CustomerCardType) cardReceipt.CustomerCardType = strTagVal;
                        if (strTagNo == CTTags.CustomerCardDescription) cardReceipt.CustomerCardDescription = strTagVal;
                    }
                    if (strTranStatus == CTTransactionStatuses.Approved)
                    {
                        if (strTagNo == CTTags.CustomerCardType)
                        {
                            cardTran.CustomerCardType = strTagVal;
                            util.Logger(" ==> GetCustomerCardType : " + strTagVal);
                            return cardTran.CustomerCardType;
                        }
                    }
                }
//                util.Logger(" ==> Index : " + index.ToString("D3") + " Tag " + s.Substring(0, 3)
//                                            + " [" + CTTags.GetTagName(s.Substring(0, 3)) + "] : " + s.Substring(3));
                index++;
            }
            return "";
        }
    }
}
