using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SDCafeCommon.PinPad
{
    public class CCardProcess
    {
        Utility util = new Utility();
        //public enum PTActionTypes : int
        public Dictionary<string, string> PTActionTypes = new Dictionary<string, string>()
        {
            {"Purchase","00" },
            {"Tokenization","09"},
            {"Refund","10"},
            {"PreAuth","17"},
            {"PreAuthComplete","18"},
            {"Void","38"},
            {"CommitTrans","40"},
            {"CloseBatch","51"},
            {"GetBatchTotal","56"}
        };
        //public enum PTRequestType : int
        public Dictionary<string, string> PTRequestType = new Dictionary<string, string>()
        {
            {"Card","00" },
            {"EBT","15" }
        };
        public Dictionary<string, string> dicCardTranType = new Dictionary<string, string>()
        {
            {"Purchase","00" },
            {"PreAuth","01" },
            {"PreAuthComplete" , "02" },
            {"Refund" , "03" },
            {"Return" , "03" },
            {"Force" , "04" },
            {"Void" , "05" },
            {"Incremental Auth" , "08" },
        };


        public string processData(string strData, int p_iInvNo, string p_Station, string p_UserName)
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
            string strReturnStatusCode = "";

            util.Logger(" ==> Total processData count : " + strlist.Count());
            foreach (String s in strlist)
            {
                if (index == 0)
                {
                    //strTranStatus = s.Substring(0, 2);
                    strTranStatus = s.Substring(0, 2);      // Transaction Status
                    strSeqNo = s.Substring(2);              // Multi - Tran Flag
                    util.Logger(" ==> index " + index.ToString() + ", strTranStatus (CTTransactionStatuses) : " + strTranStatus + ", SeqNo : " + strSeqNo);
                }
                else
                {
                    strTagNo = s.Substring(0, 3);
                    strTagVal = s.Substring(3);
                    if (strTranStatus == CTTransactionStatuses.Receipt) // 99
                    {
                        if (strTagNo == CTTags.TransactionType) cardReceipt.TransactionType = strTagVal;
                        if (strTagNo == CTTags.TransactionStatus)
                        {
                            cardReceipt.TransactionStatus = strTagVal;
                        }
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
                strReturnStatusCode = cardReceipt.TransactionStatus;
            }
            else // if (strTranStatus == CTTransactionStatuses.Approved)
            {
                cardTran.TransactionStatus = strTranStatus;
                cardTran.CreateInvoiceNo = p_iInvNo;
                cardTran.CreateStation = p_Station;
                cardTran.CreateUserName = p_UserName;
                cardReceipt.CreateDate = DateTime.Now.ToShortDateString();
                cardReceipt.CreateTime = DateTime.Now.ToShortTimeString();
                int iInsertCount = dbCard.Insert_CardTran(cardTran);
                util.Logger(" ==> processData CardTran Inserted <== " + iInsertCount);
                strReturnStatusCode = cardReceipt.TransactionStatus;
            }
            util.Logger(" ==> processData finished <== " + strReturnStatusCode);
            return strReturnStatusCode;
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

        public string processPmTreeData(POS_PmTreeRespModel p_posPmTreeResp, int p_InvoiceNo, string p_Station, string p_UserName, string p_TransactionType)
        {
            DataAccessCard dbCard = new DataAccessCard();
            string strTranStatus = "";
            string strSeqNo = "";
            string strTagNo = "";
            string strTagVal = "";
            string strReturnStatusCode = p_posPmTreeResp.TransRespCode;

            // String exception handling
            if (p_posPmTreeResp.Header.Length > 50)
                p_posPmTreeResp.Header = p_posPmTreeResp.Header.Substring(0, 10);
            if (p_UserName.Length > 20)
                p_UserName = p_UserName.Substring(0, 20);
            if (p_posPmTreeResp.TransactionStatus.Length > 2)
                p_posPmTreeResp.TransactionStatus = p_posPmTreeResp.TransactionStatus.Substring(0, 2);
            if (p_posPmTreeResp.EmvTvr.Length > 2)
                p_posPmTreeResp.EmvTvr = p_posPmTreeResp.EmvTvr.Substring(0, 10);
            if (p_posPmTreeResp.EmvTsi.Length > 4)
                p_posPmTreeResp.EmvTsi = p_posPmTreeResp.EmvTsi.Substring(0, 4);
            if (p_posPmTreeResp.CvmResult.Length > 1)
                p_posPmTreeResp.CvmResult = p_posPmTreeResp.CvmResult.Substring(0, 1);
            if (p_posPmTreeResp.TransactionStatus.Length > 2)
                p_posPmTreeResp.TransactionStatus = p_posPmTreeResp.TransactionStatus.Substring(0, 2);
            if (p_posPmTreeResp.HostResponseCode.Length > 2)
                p_posPmTreeResp.HostResponseCode = p_posPmTreeResp.HostResponseCode.Substring(0, 2);
            if (p_posPmTreeResp.TipAmt == "")
                p_posPmTreeResp.TipAmt = "0";
            if (p_posPmTreeResp.ProcessedAmount == "")
                p_posPmTreeResp.ProcessedAmount = "0";

            string strTranType = dicCardTranType[p_TransactionType];

            CCardTran cardTran = new CCardTran
            {
                TransactionStatus = p_posPmTreeResp.TransRespCode,
                MultiTranFlag = "0",
                TransactionType = strTranType,
                TransactionDate = DateTime.Now.ToString("yyMMdd"),
                TransactionTime = DateTime.Now.ToString("hhmmss"),
                TransactionAmount = p_posPmTreeResp.ProcessedAmount,
                TipAmount = p_posPmTreeResp.TipAmt,
                TotalAmount = (int.Parse(p_posPmTreeResp.ProcessedAmount) + int.Parse(p_posPmTreeResp.TipAmt)).ToString("D"),
                CashBackAmount = "0",
                SurchargeAmount = p_posPmTreeResp.SurCharge,
                TaxAmount = "0",
                InvoiceNo = p_InvoiceNo.ToString(),
                PurchaseOrderNo = p_InvoiceNo.ToString(),
                ReferenceNo = p_posPmTreeResp.TerminalReference,
                TransactionSequenceNo = p_posPmTreeResp.SequenceNumber,
                TicketNo = p_posPmTreeResp.PAYLinqTransId,
                VoucherNo = "",
                ClerkId = p_UserName,
                GiftCardReferenceNo = "",
                OriginalTransactionType = PTRequestType["Card"],
                CustomerCardType = GetCardTypeCodeByPmCardCode(p_posPmTreeResp.CardCode),
                CustomerAccountNumber = p_posPmTreeResp.CardNo,
                CustomerCardEntryMode = p_posPmTreeResp.cardentrymode,
                CardNotPresent = "",
                AuthorizationNo = p_posPmTreeResp.ProviderTransID,
                HostResponseCode = p_posPmTreeResp.HostResponseCode,
                HostResponseText = p_posPmTreeResp.HostResponseMsg,
                HostResponseISOCode = p_posPmTreeResp.TransactionStatus,
                AmountDue = p_posPmTreeResp.ProcessedAmount,
                CardBalance = p_posPmTreeResp.CardBalance,
                HostTransactionRefNbr = p_posPmTreeResp.TerminalReference,
                TerminalId = p_posPmTreeResp.TerminalId,
                DemoMode = "",
                TransactionData = "",
                CreateInvoiceNo = p_InvoiceNo,
                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"),
                CreateTime = DateTime.Now.ToString("hh:mm:ss"),
                CreateUserId = 0,
                CreateUserName = p_UserName,
                CreateStation = p_Station
            };

            CCardReceipt cardReceipt = new CCardReceipt()
            {
                TransactionStatus = p_posPmTreeResp.TransRespCode,
                ReceiptInformation = CTTransactionStatuses.Receipt,
                SeqNo = "0",
                TransactionType = strTranType,
                TransactionDate = DateTime.Now.ToString("yyMMdd"),
                TransactionTime = DateTime.Now.ToString("hhmmss"),
                TransactionAmount = p_posPmTreeResp.ProcessedAmount,
                TipAmount = p_posPmTreeResp.TipAmt,
                TotalAmount = (int.Parse(p_posPmTreeResp.ProcessedAmount) + int.Parse(p_posPmTreeResp.TipAmt)).ToString("D"),
                CashBackAmount = "0",
                SurchargeAmount = p_posPmTreeResp.SurCharge,
                TaxAmount = "0",
                InvoiceNo = p_InvoiceNo.ToString(),
                PurchaseOrderNo = p_InvoiceNo.ToString(),
                ReferenceNo = p_posPmTreeResp.TerminalReference,
                TransactionSequenceNo = p_posPmTreeResp.SequenceNumber,
                TicketNo = p_posPmTreeResp.PAYLinqTransId,
                VoucherNo = "",
                ClerkId = p_UserName,
                GiftCardReferenceNo = "",
                OriginalTransactionType = PTRequestType["Card"],
                CustomerCardType = GetCardTypeCodeByPmCardCode(p_posPmTreeResp.CardCode),
                CustomerAccountNumber = p_posPmTreeResp.CardNo,
                CustomerCardEntryMode = p_posPmTreeResp.cardentrymode,
                CustomerCardDescription = p_posPmTreeResp.CardTypeUsed,
                EmvAid = p_posPmTreeResp.EmvAid,
                EmvTvr = p_posPmTreeResp.EmvTvr,
                EmvTsi = p_posPmTreeResp.EmvTsi,
                EMVApplicationLabel = p_posPmTreeResp.EmvName,
                CVMResult = p_posPmTreeResp.CvmResult,
                AuthorizationNo = p_posPmTreeResp.ProviderTransID,
                HostResponseCode = p_posPmTreeResp.HostResponseCode,
                HostResponseText = p_posPmTreeResp.HostResponseMsg,
                HostResponseISOCode = p_posPmTreeResp.TransactionStatus,
                AmountDue = p_posPmTreeResp.ProcessedAmount,
                TraceNo = p_posPmTreeResp.Trace,
                CardBalance = p_posPmTreeResp.CardBalance,
                HostTransactionRefNbr = p_posPmTreeResp.TerminalReference,
                BatchNumber = p_posPmTreeResp.BatchNo,
                TerminalId = p_posPmTreeResp.TerminalId,
                DemoMode = "",
                MerchId = p_posPmTreeResp.MerchantID,
                MerchCurrencyCode = "",
                ReceiptHeader1 = "",
                EmvRespCode = p_posPmTreeResp.HostResponseCode,
                TransactionData = "",
                CreateInvoiceNo = p_InvoiceNo,
                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"),
                CreateTime = DateTime.Now.ToString("hh:mm:ss"),
                CreateUserId = 0,
                CreateUserName = p_UserName,
                CreateStation = p_Station
            };

            util.Logger(" ==> processPmTreeData started <== StatusCode :" + strReturnStatusCode);
            // 2024-09-18 : need to start coding from here
            // if statuscode is not approved, then insert into CardReceipt
            if (strReturnStatusCode == "0")
            {
                try
                {
                    int iReceiptInsertCount = dbCard.Insert_CardReceipt(cardReceipt);
                    util.Logger(" ==> processPmTreeData CardReceipt Inserted <== " + iReceiptInsertCount);
                    int iTranInsertCount = dbCard.Insert_CardTran(cardTran);
                    util.Logger(" ==> processPmTreeData CardTran Inserted <== " + iTranInsertCount);
                }
                catch (Exception ex)
                {
                    util.Logger(" ==> processPmTreeData Exception : " + ex.Message + " " + ex.StackTrace);
                }

            }
            return strReturnStatusCode;
        }

        private string GetCardTypeCodeByPmCardCode(string p_strPMCardCode)
        {
            string strCardTypeCode = "";
            if (p_strPMCardCode == "ACKGC")
                strCardTypeCode = "09";
            else if (p_strPMCardCode == "ACKLC")
                strCardTypeCode = "09";
            else if (p_strPMCardCode == "AMEX")
                strCardTypeCode = "03";
            else if (p_strPMCardCode == "BLANCHE")
                strCardTypeCode = "01";
            else if (p_strPMCardCode == "CASH")
                strCardTypeCode = "10";
            else if (p_strPMCardCode == "DEBIT")
                strCardTypeCode = "00";
            else if (p_strPMCardCode == "DINERS")
                strCardTypeCode = "04";
            else if (p_strPMCardCode == "DISCOVER")
                strCardTypeCode = "05";
            else if (p_strPMCardCode == "EBT")
                strCardTypeCode = "11";
            else if (p_strPMCardCode == "EBTCASH")
                strCardTypeCode = "11";
            else if (p_strPMCardCode == "EBTFOODSTAMP")
                strCardTypeCode = "12";
            else if (p_strPMCardCode == "GIFT")
                strCardTypeCode = "09";
            else if (p_strPMCardCode == "GIVEXGC")
                strCardTypeCode = "09";
            else if (p_strPMCardCode == "JCB")
                strCardTypeCode = "06";
            else if (p_strPMCardCode == "LASER")
                strCardTypeCode = "01";
            else if (p_strPMCardCode == "MAESTRO")
                strCardTypeCode = "01";
            else if (p_strPMCardCode == "M/C")
                strCardTypeCode = "02";
            else if (p_strPMCardCode == "UNKNOWN")
                strCardTypeCode = "01";
            else if (p_strPMCardCode == "PTREEGC")
                strCardTypeCode = "01";
            else if (p_strPMCardCode == "PROMO")
                strCardTypeCode = "01";
            else if (p_strPMCardCode == "UNIONPAY")
                strCardTypeCode = "07";
            else if (p_strPMCardCode == "VISA")
                strCardTypeCode = "01";
            else
                strCardTypeCode = "01";
            return strCardTypeCode;
        }
    }
}
