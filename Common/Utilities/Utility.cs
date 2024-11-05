using SDCafeCommon.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SDCafeCommon.Model;
using System.Xml;

namespace SDCafeCommon.Utilities
{
    public class Utility
    {
        private string strmsg = "";
        public void Logger(String msg)
        {
            // Set a variable to the Documents path.
            string logPath = Directory.GetCurrentDirectory() + "\\Logs\\";
            // Determine whether the directory exists.
            if (!Directory.Exists(logPath))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(logPath);
            }

            // Write the string to a file.append mode is enabled so that the log
            // lines get appended to  test.txt than wiping content and writing the log
            strmsg = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff ") + msg;
            System.IO.StreamWriter file = new System.IO.StreamWriter(logPath + "Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
            file.WriteLine(strmsg);

            file.Close();

            // Remove 14 days old files
            string[] files = Directory.GetFiles(logPath);

            foreach (string onefile in files)
            {
                FileInfo fi = new FileInfo(onefile);

                if (fi.LastAccessTime < DateTime.Now.AddDays(-14))
                {
                    fi.Delete();
                }
            }

        }
        public string ToXML(POS_PmTreeTranModel p_PmTreeTran)
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(p_PmTreeTran.GetType());
            var settings = new XmlWriterSettings();
            string strXML = "";
            string strXML2Return = "";
            settings.Indent = false;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, p_PmTreeTran, emptyNamespaces);
                strXML = stream.ToString();
            }
            strXML = strXML.Replace("POS_PmTreeTranModel", "TRANS");
            strXML = strXML.Replace("<Id>0</Id>", "");
            strXML = strXML.Replace("<Token />", "<TOKEN></TOKEN>");
            strXML = strXML.Replace("<Dynamic_Ip />", "<DYNAMIC_IP></DYNAMIC_IP>");
            strXML = strXML.Replace("<Dynamic_Port>0</Dynamic_Port>", "<DYNAMIC_PORT></DYNAMIC_PORT>");
            // change strXML string to capital letters
            strXML = strXML.ToUpper();

            return strXML;
        }
        public bool SendEmail(string strSubject, string strBody, string strAttachmentFile)
        {
            Utility util = new Utility();
            DataAccessPOS dbPOS = new DataAccessPOS();
            MailAddress from = null;
            MailAddress to = null;
            try 
            {
                from = new MailAddress(dbPOS.Get_SysConfig_By_Name("CON_EMAIL_SENDFROM")[0].ConfigValue.Trim());
                to = new MailAddress(dbPOS.Get_SysConfig_By_Name("CON_EMAIL_SENDTO")[0].ConfigValue.Trim()); 
            }
            catch (Exception ex)
            {
                //util.ex.ToString());
                return false;
            }

            MailMessage email = new MailMessage(from, to);
            email.Subject = strSubject;
            email.IsBodyHtml = true;
            email.Body = strBody;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = dbPOS.Get_SysConfig_By_Name("CON_EMAIL_SMTPSERVER")[0].ConfigValue.Trim();
            string strUser = dbPOS.Get_SysConfig_By_Name("CON_EMAIL_SENDUSERNAME")[0].ConfigValue.Trim();
            string strpassword = dbPOS.Get_SysConfig_By_Name("CON_EMAIL_SENDPASSWORD")[0].ConfigValue.Trim();
            
            AesEncryption aes = new AesEncryption();
            // Encrypt Feature #3593
            //var key = "1234567890123456"; // 16 bytes (128bits)
            var key =   "tsent2011tsent20";
            var encryptedString = aes.EncryptString(key, strpassword);
            util.Logger("Encrypted String: " + encryptedString);
            // Decrypt
            var decryptedString = aes.DecryptString(key, strpassword);
            //util.Logger("Decrypted String: " + decryptedString);
            strpassword = decryptedString;

            smtp.Port = 587; // 25;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(strUser, strpassword);

            if (!String.IsNullOrEmpty(strAttachmentFile))
            {
                email.Attachments.Add(new Attachment(strAttachmentFile));
            }

            try
            {
                // Send method called below is what will send off our email 
                // unless an exception is thrown.
                //
                smtp.Send(email);
            }
            catch (SmtpException ex)
            {
                Logger(ex.ToString());
                return false;
            }

            return true;
        }
        public float CalculateElapsedHours(DateTime dtStart, DateTime dtEnd)
        {
            TimeSpan TS = dtEnd - dtStart;
            float fDays = TS.Days;
            float fHour = TS.Hours;
            float fMins = TS.Minutes;
            //float fSecs = TS.Seconds;

            float fElapsedHours = (fDays * 24) + fHour + (fMins / 60);
            return fElapsedHours;
        }
        public byte[][] Separate(byte[] source, byte[] separator)
        {
            var Parts = new List<byte[]>();
            var Index = 0;
            byte[] Part;
            for (var I = 0; I < source.Length; ++I)
            {
                if (Equals(source, separator, I))
                {
                    Part = new byte[I - Index];
                    Array.Copy(source, Index, Part, 0, Part.Length);
                    Parts.Add(Part);
                    Index = I + separator.Length;
                    I += separator.Length - 1;
                }
            }
            Part = new byte[source.Length - Index];
            Array.Copy(source, Index, Part, 0, Part.Length);
            Parts.Add(Part);
            return Parts.ToArray();
        }

        private bool Equals(byte[] source, byte[] separator, int index)
        {
            for (int i = 0; i < separator.Length; ++i)
                if (index + i >= source.Length || source[index + i] != separator[i])
                    return false;
            return true;
        }
        public char GetCharFromHex(string strHex)
        {
            return System.Convert.ToChar(System.Convert.ToUInt32(strHex, 16));
        }
        public byte[] GetBytesFromHex(string strHex)
        {
            return Enumerable.Range(0, strHex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(strHex.Substring(x, 2), 16))
                             .ToArray();
        }

        public POS_PmTreeRespModel LoadFromXML(string p_content)
        {
            using (var stringReader = new System.IO.StringReader(p_content))
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "TRANS";
                xRoot.IsNullable = true;
                var serializer = new XmlSerializer(typeof(POS_PmTreeRespModel),xRoot);
                return serializer.Deserialize(stringReader) as POS_PmTreeRespModel;
            }
        }

        public Dictionary<string, string> dicTranStates = new Dictionary<string, string>()
        {
            {"Approved","00"},
            {"PartialApproved","01"},
            {"DeclinedByHostOrCard","10"},
            {"CommunicationError","11"},
            {"CancelledByUser","12"},
            {"TimedOutOnUserInput","13"},
            {"TransactionNotCompleted","14"},
            {"BatchEmpty","15"},
            {"DeclinedByMerchant","16"},
            {"RecordNotFound","17"},
            {"TransactionVoided","18"},
            {"InvalidECRParameter","30"},
            {"BatteryLow","31"},
            {"CashDrawerSuccess","40"},
            {"CashDrawerFailed","41"},
            {"Receipt","99"}
        };

        public Dictionary<string, string> dicTranTypes = new Dictionary<string, string>()
        {
                {"SalePurchase","00"},
                {"PreAuth","01"},
                {"PreAuthCompletion","02"},
                {"Refund","03"},
                {"Force","04"},
                {"Void","05"},
                {"CardBalanceInquiry","06"},
                {"AuthOnly","07"},
                {"IncrementalAuth","08"},
                {"Settlement","20"},
                {"AutoSettlement","21"},
                {"ReprintReceipt","22"},
                {"DetailReport","30"},
                {"SummaryReport","31"},
                {"EMVLastTransactionReport","32"},
                {"ClerkSummaryReport","33"},
                {"ParametersReport","34"},
                {"OpenPreAuth","35"},
                {"RecentError","36"},
                {"ActivityReport","37"},
                {"ClerkIdList","38"},
                {"EMVParameters","39"},
                {"EMVStatistic","40"},
                {"EMVPublicKey","41"},
                {"TerminalInfo","42"},
                {"EMVKeyDate","43"},
                {"IssuanceReload","50"},
                {"Activation","51"},
                {"BlockActivation","52"},
                {"Redemption","53"},
                {"AddTip","54"},
                {"ForceIssuance","55"},
                {"ForceActivation","56"},
                {"ForceRedemption","57"},
                {"Deactivation","58"},
                {"BlockDeactivation","59"},
                {"Reactivation","60"},
                {"ZeroGiftCardBalance","61"},
                {"BlockReactivation","63"},
                {"CashDrawerStatus","70"},
                {"CashDrawerOpen","71"},
                {"CashDrawerCapability","72"}
        };

        public Dictionary<string, string> dicTags = new Dictionary<string, string>()
        {
            {"ECRTransactionAmount", "001"},
            {"ECRTenderType", "002"},
            {"ECRClerkId", "003"},
            {"ECRInvoiceNo", "004"},
            {"ECRAuthCode", "005"},
            {"ECRCustomerRefNo", "010"},
            {"ECRReferenceNo", "011"},
            {"ECRPANLast4", "012"},
            {"ECRTranTypeClass", "013"},
            {"ECRReprintType", "050"},
            {"ECRParameterType", "051"},
            {"TransactionType", "100"},
            {"TransactionStatus", "101"},
            {"TransactionDate", "102"},
            {"TransactionTime", "103"},
            {"TransactionAmount", "104"},
            {"TipAmount", "105"},
            {"CashBackAmount", "106"},
            {"SurchargeAmount", "107"},
            {"TaxAmount", "108"},
            {"TotalAmount", "109"},
            {"InvoiceNo", "110"},
            {"PurchaseOrderNo", "111"},
            {"ReferenceNo", "112"},
            {"TransactionSequenceNo", "113"},
            {"TableNo", "114"},
            {"TicketNo", "115"},
            {"VoucherNo", "116"},
            {"ShipToPostal", "117"},
            {"ClerkId", "118"},
            {"ClerkName", "119"},
            {"NumberOfCards", "120"},
            {"DCCOptInFlag", "121"},
            {"DCCConventionRate", "122"},
            {"DCCCurrencyAlphaCode", "123"},
            {"DCCAmount", "124"},
            {"DCCTipAmount", "125"},
            {"DCCTotalAmount", "126"},
            {"OriginalTransactionAmount", "127"},
            {"OriginalTipAmount", "128"},
            {"OriginalCashBackAmount", "129"},
            {"OriginalSurchargeAmount", "130"},
            {"OriginalTaxAmount", "131"},
            {"OriginalTotalAmount", "132"},
            {"GiftCardReferenceNo", "133"},
            {"OriginalTransactionType", "134"},
            {"NumberOfCustomers", "135"},
            {"CustomerCardType", "300"},
            {"CustomerCardDescription", "301"},
            {"CustomerAccountNumber", "302"},
            {"CustomerLanguage", "303"},
            {"CustomerName", "304"},
            {"CustomerAccountType", "305"},
            {"CustomerCardEntryMode", "306"},
            {"CustomerNumber", "307"},
            {"EmvAid", "308"},
            {"EmvTvr", "309"},
            {"EmvTsi", "310"},
            {"EMVApplicationLabel", "311"},
            {"CVMResult", "312"},
            {"CardNotPresent", "313"},
            {"AmountDuePaymentType", "314"},
            {"CustomerReferenceNumber", "315"},
            {"EmvTc", "316"},
            {"AuthorizationNo", "400"},
            {"HostResponseCode", "401"},
            {"HostResponseText", "402"},
            {"HostResponseISOCode", "403"},
            {"RetrievalReferenceNo", "404"},
            {"AmountDue", "405"},
            {"TraceNo", "406"},
            {"AVSResult", "407"},
            {"CVVResult", "408"},
            {"CardBalance", "409"},
            {"EBTFoodBalance", "410"},
            {"CashOutAmount", "411"},
            {"HostTransactionRefNbr", "412"},
            {"BatchNumber", "500"},
            {"BatchTotalBalanceFlag", "501"},
            {"BatchTotalAmount", "502"},
            {"BatchTotalCount", "503"},
            {"BatchSaleAmount", "504"},
            {"BatchSaleCount", "505"},
            {"BatchRefundAmount", "506"},
            {"BatchRefundCount", "507"},
            {"BatchVoidAmount", "508"},
            {"BatchVoidCount", "509"},
            {"BatchTipAmount", "510"},
            {"BatchVoidTipAmount", "511"},
            {"BatchCashBackAmount", "512"},
            {"BatchVoidCashBackAmount", "513"},
            {"BatchSurchargeAmount", "514"},
            {"BatchVoidSurchargeAmount", "515"},
            {"BatchTaxAmount", "516"},
            {"BatchVoidTaxAmount", "517"},
            {"BatchGiftAmount", "518"},
            {"BatchGiftCount", "519"},
            {"BatchGiftActivationAmount", "520"},
            {"BatchGiftActivationCount", "521"},
            {"BatchGiftRedemptionAmt", "522"},
            {"BatchGiftRedemptionCount", "523"},
            {"BatchGiftRefundAmount", "524"},
            {"BatchGiftRefundCount", "525"},
            {"BatchGiftIssuanceAmount", "526"},
            {"BatchGiftIssuanceCount", "527"},
            {"BatchGiftZeroCardAmount", "528"},
            {"BatchGiftZeroCardCount", "529"},
            {"SaleNetworkFeeAmount", "530"},
            {"VoidNetworkFeeAmount", "531"},
            {"GiftAddTipAmount", "532"},
            {"GiftAddTipCount", "533"},
            {"GiftDeactivationAmount", "534"},
            {"GiftDeactivationCount", "535"},
            {"GiftReactivationAmount", "536"},
            {"GiftReactivationCount", "537"},
            {"NetTipAmount", "538"},
            {"NetCashBackAmount", "539"},
            {"BatchReturnTipAmount", "540"},
            {"HostName", "550"},
            {"DemoIndicator", "600"},
            {"TerminalId", "601"},
            {"MerchId", "602"},
            {"MerchCurrencyAlphaCode", "603"},
            {"ReceiptHeader1", "700"},
            {"ReceiptHeader2", "701"},
            {"ReceiptHeader3", "702"},
            {"ReceiptHeader4", "703"},
            {"ReceiptHeader5", "704"},
            {"ReceiptHeader6", "705"},
            {"ReceiptHeader7", "706"},
            {"ReceiptFooter1", "707"},
            {"ReceiptFooter2", "708"},
            {"ReceiptFooter3", "709"},
            {"ReceiptFooter4", "710"},
            {"ReceiptFooter5", "711"},
            {"ReceiptFooter6", "712"},
            {"ReceiptFooter7", "713"},
            {"EndorsementLine1", "714"},
            {"EndorsementLine2", "715"},
            {"EndorsementLine3", "716"},
            {"EndorsementLine4", "717"},
            {"EndorsementLine5", "718"},
            {"EndorsementLine6", "719"},
            {"CustomerEndorsementLine1", "720"},
            {"CustomerEndorsementLine2", "721"},
            {"CustomerEndorsementLine3", "722"},
            {"CustomerEndorsementLine4", "723"},
            {"CustomerEndorsementLine5", "724"},
            {"CustomerEndorsementLine6", "725"},
            {"BlankTipLineIndicator", "726"},
            {"TipAssistLine", "727"},
            {"TaxRegistrationNo", "728"},
            {"TaxLabel", "729"},
            {"EmvRespCode", "730"},
            {"AuthCodesHistory", "731"},
            {"InstitutionIdentificationNo", "732"},
            {"TerminalCapabilities", "800"},
            {"AdditionalCapabilities", "801"},
            {"CountryCode", "802"},
            {"TerminalType", "803"},
            {"TransCurrencyCode", "804"},
            {"TransCurrExponent", "805"},
            {"AcquirerId", "806"},
            {"MerchantCatCode", "807"},
            {"MerchIdentifier", "808"},
            {"TransRefCurrencyCode", "809"},
            {"TransRefCurrExponent", "810"},
            {"RefCurrencyConversion", "811"},
            {"ReportScheme", "812"},
            {"ReportAID", "813"},
            {"AppName", "814"},
            {"AppVersion", "815"},
            {"PartialNameSel", "816"},
            {"EnableAutoSelect", "817"},
            {"FallBackIndicator", "818"},
            {"FloorLimit", "819"},
            {"ThresholdValRDMSelect", "820"},
            {"TacDefault", "821"},
            {"TacDenial", "822"},
            {"TacOnline", "823"},
            {"MaxTargetPercent", "824"},
            {"TargetPercent", "825"},
            {"DDOL", "826"},
            {"TDOL", "827"},
            {"EVTRNCAT", "828"},
            {"ReportOption", "829"},
            {"TmLmt", "830"},
            {"CvmLmt", "831"},
            {"TTQ", "832"},
            {"MAGAVN", "833"},
            {"EmvAvn", "834"},
            {"TCPCVM", "835"},
            {"TCPNoCVM", "836"},
            {"MTI", "837"},
            {"UDOL", "838"},
            {"MStripe", "839"},
            {"EmvAvn2", "840"},
            {"TTI", "841"},
            {"TOS", "842"},
            {"RRL", "843"},
            {"RId", "844"},
            {"KeyIndex", "845"},
            {"KeyModulus", "846"},
            {"KeyExponent", "847"},
            {"EMVKeyDate", "848"},
            {"InputCap", "849"},
            {"SecureCap", "850"},
            {"CVMCapEMVCVM", "851"},
            {"CVMCapEMVNoCVM", "852"},
            {"CVMCapMAGCVM", "853"},
            {"CVMCapMAGNoCVM", "854"},
            {"TmLmtCard", "855"},
            {"TmLmtMobile", "856"},
            {"KernelConfig", "857"},
            {"MagAvnSingle", "858"},
            {"TornTnxLife", "859"},
            {"TornTnxMax", "860"},
            {"EmvAvn3", "861"},
            {"UnpredictNR", "862"},
            {"TnxCap", "863"},
            {"TermRiskMngmt", "864"},
            {"TransactionRecord", "900"},
            {"RawPrintDataSize", "920"},
            {"RawPrintDataText", "921"},
            {"EMVDataTag", "930"},
            {"EMVDataValue", "931"},
            {"ReportTagLabel", "932"},
            {"ReportTagValue", "933"},
            {"ErrorResultCode", "934"},
            {"ErrorMessage", "935"},
            {"ActivityEvent", "936"},
            {"ActivityDataAffected", "937"},
            {"TotalNumberOfRecord", "938"},
            {"CashDrawerStatus", "939"},
            {"CashDrawerCapability", "940"}
        };
    }
}
