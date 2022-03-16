using System;
using System.Data;
using System.IO;
using System.Net;
using System.Xml;
using EntityLayer;

namespace BusinessLogicLayer
{
    public class QuickBookBL
    {
        #region public static string VendorADD(int CarrierID)
        public static string VendorADD(int CarrierID)
        {
            string requestUrl = null;
            string Results = "";
            string vendoeAdd = "";
            requestUrl = "https://apps.quickbooks.com/j/AppGateway";

            HttpWebRequest WebRequestObject = null;
            StreamReader sr = null;
            HttpWebResponse WebResponseObject = null;
            StreamWriter swr = null;
            DataTable dt = CarriersBL.GetCarrierByCarrierId(CarrierID);
            if (dt == null || dt.Rows == null || dt.Rows.Count == 0)
            { return ""; }
            DataSet dtState = StatesBL.FetchStateById(Convert.ToInt32(dt.Rows[0]["StateId"]));
            if (dtState.Tables[0] == null || dtState.Tables[0].Rows == null || dtState.Tables[0].Rows.Count == 0)
            { return ""; }
            try
            {
                WebRequestObject = (HttpWebRequest)WebRequest.Create(requestUrl);
                WebRequestObject.Method = "POST";
                WebRequestObject.ContentType = "application/x-qbxml";
                WebRequestObject.AllowAutoRedirect = false;
                vendoeAdd += @"<?xml version=""1.0"" encoding=""utf-8"" ?>  
                  <?qbxml version=""6.0""?>  
                <QBXML> 
                 <SignonMsgsRq> 
                 <SignonDesktopRq> 
                 <ClientDateTime>%%CLIENT_DATE_TIME%%</ClientDateTime>
                <ApplicationLogin>int3.3plintegration.com</ApplicationLogin>
                <ConnectionTicket>TGT-181-YVkfJkX6Oxtx3HdlhrdusA</ConnectionTicket>
                <Language>English</Language>
                <AppID>477329740</AppID>
                <AppVer>1</AppVer>
                  </SignonDesktopRq> 
                  </SignonMsgsRq> 
                 <QBXMLMsgsRq onError=""stopOnError""> 
                 <VendorAddRq requestID=""1"">
                 <VendorAdd>";

                vendoeAdd += "<Name>" + Convert.ToString(dt.Rows[0]["CarrierName"]).Trim().Replace("&", "&amp;") + "</Name>";
                vendoeAdd += "<IsActive>1</IsActive>";
                  vendoeAdd +=@"<CompanyName /> 
                  <Salutation /> 
                  <FirstName /> 
                  <LastName /> 
                 <VendorAddress>";
                  vendoeAdd += "<Addr1>" + Convert.ToString(dt.Rows[0]["Address"]).Trim().Replace("&", "&amp;") + "</Addr1> ";
                  vendoeAdd +="<Addr2 /> ";
                  vendoeAdd += "<City>" + Convert.ToString(dt.Rows[0]["City"]).Trim().Replace("&", "&amp;") + "</City> ";
                  vendoeAdd += "<State>" + Convert.ToString(dtState.Tables[0].Rows[0]["Abbreviation"]).Trim().Replace("&", "&amp;") + "</State> ";
                  vendoeAdd += "<PostalCode>" + Convert.ToString(dt.Rows[0]["PostalCode"]).Trim().Replace("&", "&amp;") + "</PostalCode> ";
                  vendoeAdd +="<Country /> ";
                  vendoeAdd +="</VendorAddress>";
                  vendoeAdd += "<Phone>" + Convert.ToString(dt.Rows[0]["ContactPhone"]).Trim().Replace("&", "&amp;") + "</Phone> ";
                  vendoeAdd +="<Mobile /> ";
                  vendoeAdd +="<AltPhone /> ";
                  vendoeAdd += "<Fax>" + Convert.ToString(dt.Rows[0]["ContactFax"]).Trim().Replace("&", "&amp;") + "</Fax> ";
                  vendoeAdd += "<Email>" + Convert.ToString(dt.Rows[0]["ContactEmail"]).Trim().Replace("&", "&amp;") + "</Email> ";
                  vendoeAdd += "<Contact>" + Convert.ToString(dt.Rows[0]["ContactName"]).Trim().Replace("&", "&amp;") + "</Contact> ";
                  vendoeAdd +=@"<NameOnCheck /> 
                  <AccountNumber /> 
                 <VendorTypeRef>";
                  vendoeAdd += "<FullName>" + Convert.ToString(dt.Rows[0]["CarrierName"]).Trim().Replace("&", "&amp;") + "</FullName> ";
                  vendoeAdd +=@"</VendorTypeRef>
                 
                  <CreditLimit /> 
                  </VendorAdd>
                  </VendorAddRq>

                  </QBXMLMsgsRq> 
                  </QBXML>";

                vendoeAdd = vendoeAdd.Replace("%%CLIENT_DATE_TIME%%", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(vendoeAdd);

                vendoeAdd = xmlDoc.InnerXml;

                WebRequestObject.ContentLength = vendoeAdd.Length;
                swr = new StreamWriter(WebRequestObject.GetRequestStream());

                swr.Write(vendoeAdd);
                swr.Close();
                WebResponseObject = (HttpWebResponse)WebRequestObject.GetResponse();
                sr = new StreamReader(WebResponseObject.GetResponseStream());
                Results = sr.ReadToEnd();

            }
            finally
            {
                try
                {
                    sr.Close();
                }
                catch
                {
                }

                try
                {
                    WebResponseObject.Close();
                    WebRequestObject.Abort();
                }
                catch
                {
                }
            }
            return Results;
        }
        #endregion

        #region public static string VendorAmountADD(QuickBookEL oQuickEL)
        public static string VendorAmountADD(QuickBookEL oQuickEL)
        {
            string requestUrl = null;
            string Results = "";
            string vendoeAdd = "";
            requestUrl = "https://apps.quickbooks.com/j/AppGateway";

            HttpWebRequest WebRequestObject = null;
            StreamReader sr = null;
            HttpWebResponse WebResponseObject = null;
            StreamWriter swr = null;
            
            try
            {
                WebRequestObject = (HttpWebRequest)WebRequest.Create(requestUrl);
                WebRequestObject.Method = "POST";
                WebRequestObject.ContentType = "application/x-qbxml";
                WebRequestObject.AllowAutoRedirect = false;                
                vendoeAdd += @"<?xml version=""1.0"" encoding=""utf-8"" ?>  
                  <?qbxml version=""6.0""?>  
                <QBXML> 
                 <SignonMsgsRq> 
                 <SignonDesktopRq> 
                 <ClientDateTime>%%CLIENT_DATE_TIME%%</ClientDateTime>
                <ApplicationLogin>int3.3plintegration.com</ApplicationLogin>
                <ConnectionTicket>TGT-181-YVkfJkX6Oxtx3HdlhrdusA</ConnectionTicket>
                <Language>English</Language>
                <AppID>477329740</AppID>
                <AppVer>1</AppVer>
                  </SignonDesktopRq> 
                  </SignonMsgsRq> 
                 <QBXMLMsgsRq onError=""stopOnError""> 
                 <BillAddRq requestID =""1"">
                <BillAdd>
                 <VendorRef>";
                vendoeAdd += "<FullName>" + oQuickEL.VendorName.Trim().Replace("&", "&amp;") + "</FullName> ";
                vendoeAdd +=  "</VendorRef>";
                vendoeAdd +=  "<TxnDate>"+DateTime.Now.ToString("yyyy-MM-dd")+"</TxnDate> ";
                vendoeAdd +=  "<DueDate /> ";
                vendoeAdd +=  "<RefNumber /> ";
                vendoeAdd += @"<TermsRef>
                  <FullName>Net 30</FullName> 
                  </TermsRef>
                  <Memo /> ";

                vendoeAdd += @"<ExpenseLineAdd>
                 <AccountRef>
                  <FullName>Miscellaneous</FullName> 
                  </AccountRef>";
                vendoeAdd += "<Amount>" + Convert.ToString((oQuickEL.VendorAccessorialAmt1 + oQuickEL.VendorBuyBrokerageAmt1 + oQuickEL.VendorBuyDutyAmt1).ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount> ";
                vendoeAdd +=  @"<Memo>Test Comments</Memo> 
                  </ExpenseLineAdd>";
                vendoeAdd += @"<ExpenseLineAdd>
                 <AccountRef>
                  <FullName>Fuel Expense</FullName> 
                  </AccountRef>";
                vendoeAdd += "<Amount>" + Convert.ToString(oQuickEL.VendorFuelSurchargeAmt1.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount> ";
                vendoeAdd +=  @"<Memo>Test Comments</Memo> 
                  </ExpenseLineAdd>";

                vendoeAdd += @"<ExpenseLineAdd>
                 <AccountRef>
                  <FullName>Insurance</FullName> 
                  </AccountRef>";
                vendoeAdd += "<Amount>" + Convert.ToString(oQuickEL.VendorInsuranceAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount> ";
                vendoeAdd += @"<Memo>Test Comments</Memo> 
                  </ExpenseLineAdd>";

                vendoeAdd += @"<ExpenseLineAdd>
                 <AccountRef>
                  <FullName>Cost of Goods Sold</FullName> 
                  </AccountRef>";
                vendoeAdd += "<Amount>" + Convert.ToString((oQuickEL.VendorCODFeeAmt + oQuickEL.VendorTransportAmt1).ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount> ";
                vendoeAdd += @"<Memo>Test Comments</Memo> 
                  </ExpenseLineAdd>";

                 vendoeAdd += @"<ItemLineAdd>
                 <ItemRef>
                  <FullName>Digital Camera</FullName> 
                  </ItemRef>
                  <Desc>Digital Camera</Desc> 
                  <Quantity>2</Quantity> 
                  <Cost>2.00</Cost> 
                  <Amount>2.00</Amount> 
                  </ItemLineAdd>
                 <ItemLineAdd>
                 <ItemRef>
                  <FullName>Laser Printer</FullName> 
                  </ItemRef>
                  <Desc>Laser Printer</Desc> 
                  <Quantity>1</Quantity> 
                  <Cost>3.00</Cost> 
                  <Amount>3.00</Amount> 
                  </ItemLineAdd>
                  </BillAdd>
                </BillAddRq>
                  </QBXMLMsgsRq> 
                  </QBXML>";

                vendoeAdd = vendoeAdd.Replace("%%CLIENT_DATE_TIME%%", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(vendoeAdd);

                vendoeAdd = xmlDoc.InnerXml;

                WebRequestObject.ContentLength = vendoeAdd.Length;
                swr = new StreamWriter(WebRequestObject.GetRequestStream());

                swr.Write(vendoeAdd);
                swr.Close();
                WebResponseObject = (HttpWebResponse)WebRequestObject.GetResponse();
                sr = new StreamReader(WebResponseObject.GetResponseStream());
                Results = sr.ReadToEnd();
                
            }
            finally
            {
                try
                {
                    sr.Close();
                }
                catch
                {
                }

                try
                {
                    WebResponseObject.Close();
                    WebRequestObject.Abort();
                }
                catch
                {
                }
            }
            return Results;
        }
        #endregion

        #region public static string CustomerADD(int LocationID)
        public static string CustomerADD(QuickBookEL oQuickEL)
        {
            string requestUrl = null;
            string Results = "";
            string vendoeAdd = "";
            requestUrl = "https://apps.quickbooks.com/j/AppGateway";

            HttpWebRequest WebRequestObject = null;
            StreamReader sr = null;
            HttpWebResponse WebResponseObject = null;
            StreamWriter swr = null;
            
            try
            {
                WebRequestObject = (HttpWebRequest)WebRequest.Create(requestUrl);
                WebRequestObject.Method = "POST";
                WebRequestObject.ContentType = "application/x-qbxml";
                WebRequestObject.AllowAutoRedirect = false;
                vendoeAdd += @"<?xml version=""1.0"" encoding=""utf-8"" ?>  
                  <?qbxml version=""6.0""?>  
                <QBXML> 
                 <SignonMsgsRq> 
                 <SignonDesktopRq> 
                 <ClientDateTime>%%CLIENT_DATE_TIME%%</ClientDateTime>
                <ApplicationLogin>int3.3plintegration.com</ApplicationLogin>
                <ConnectionTicket>TGT-181-YVkfJkX6Oxtx3HdlhrdusA</ConnectionTicket>
                <Language>English</Language>
                <AppID>477329740</AppID>
                <AppVer>1</AppVer>
                  </SignonDesktopRq> 
                  </SignonMsgsRq> 
                 <QBXMLMsgsRq onError=""stopOnError""> 
                 <CustomerAddRq requestID=""15"">
			     <CustomerAdd>";

                vendoeAdd += "<Name>" + Convert.ToString(oQuickEL.CustomerName).Trim().Replace("&", "&amp;") + "</Name>";
                vendoeAdd += "<CompanyName>" + Convert.ToString(oQuickEL.CustomerCompanyName).Trim().Replace("&", "&amp;") + "</CompanyName>";
                vendoeAdd += "<FirstName>" + Convert.ToString(oQuickEL.CustomerFirstName).Trim().Replace("&", "&amp;") + "</FirstName>";
                vendoeAdd += "<LastName>" + Convert.ToString(oQuickEL.CustomerLastName).Trim().Replace("&", "&amp;") + "</LastName>";
                vendoeAdd += "<BillAddress>";
                vendoeAdd += "<Addr1>" + Convert.ToString(oQuickEL.CustomerAddr1).Trim().Replace("&", "&amp;") + "</Addr1>";
                vendoeAdd += "<Addr2>" + Convert.ToString(oQuickEL.CustomerAddr2).Trim().Replace("&", "&amp;") + "</Addr2>";
                vendoeAdd += "<Addr3>" + Convert.ToString(oQuickEL.CustomerAddr3).Trim().Replace("&", "&amp;") + "</Addr3>";
                vendoeAdd += "<City>" + Convert.ToString(oQuickEL.CustomerCity).Trim().Replace("&", "&amp;") + "</City>";
                vendoeAdd += "<State>" + Convert.ToString(oQuickEL.CustomerState).Trim().Replace("&", "&amp;") + "</State>";
                vendoeAdd += "<PostalCode>" + Convert.ToString(oQuickEL.CustomerPostalCode).Trim().Replace("&", "&amp;") + "</PostalCode>";
                vendoeAdd += "<Country>" + Convert.ToString(oQuickEL.CustomerCountry).Trim().Replace("&", "&amp;") + "</Country>";
                vendoeAdd += "</BillAddress>";
                vendoeAdd += "<Phone>" + Convert.ToString(oQuickEL.CustomerPhone).Trim().Replace("&", "&amp;") + "</Phone>";
                vendoeAdd += "<AltPhone>" + Convert.ToString(oQuickEL.CustomerAltPhone).Trim().Replace("&", "&amp;") + "</AltPhone>";
                vendoeAdd += "<Fax>" + Convert.ToString(oQuickEL.CustomerFax).Trim().Replace("&", "&amp;") + "</Fax>";
                vendoeAdd += "<Email>" + Convert.ToString(oQuickEL.CustomerEmail).Trim().Replace("&", "&amp;") + "</Email>";
                vendoeAdd += "<Contact>" + Convert.ToString(oQuickEL.CustomerContact).Trim().Replace("&", "&amp;") + "</Contact>";

                vendoeAdd += @"</CustomerAdd>
		                        </CustomerAddRq>

                                  </QBXMLMsgsRq> 
                                  </QBXML>";

                vendoeAdd = vendoeAdd.Replace("%%CLIENT_DATE_TIME%%", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(vendoeAdd);

                vendoeAdd = xmlDoc.InnerXml;

                WebRequestObject.ContentLength = vendoeAdd.Length;
                swr = new StreamWriter(WebRequestObject.GetRequestStream());

                swr.Write(vendoeAdd);
                swr.Close();
                WebResponseObject = (HttpWebResponse)WebRequestObject.GetResponse();
                sr = new StreamReader(WebResponseObject.GetResponseStream());
                Results = sr.ReadToEnd();

            }
            finally
            {
                try
                {
                    sr.Close();
                }
                catch
                {
                }

                try
                {
                    WebResponseObject.Close();
                    WebRequestObject.Abort();
                }
                catch
                {
                }
            }
            return Results;
        }
        #endregion

        #region public static string CustomerAmountADD(QuickBookEL oQuickEL)
        public static string CustomerAmountADD(QuickBookEL oQuickEL)
        {
            string requestUrl = null;
            string Results = "";
            string vendoeAdd = "";
            requestUrl = "https://apps.quickbooks.com/j/AppGateway";

            HttpWebRequest WebRequestObject = null;
            StreamReader sr = null;
            HttpWebResponse WebResponseObject = null;
            StreamWriter swr = null;
            
            try
            {
                WebRequestObject = (HttpWebRequest)WebRequest.Create(requestUrl);
                WebRequestObject.Method = "POST";
                WebRequestObject.ContentType = "application/x-qbxml";
                WebRequestObject.AllowAutoRedirect = false;
                vendoeAdd += @"<?xml version=""1.0"" encoding=""utf-8"" ?>  
                  <?qbxml version=""6.0""?>  
                <QBXML> 
                 <SignonMsgsRq> 
                 <SignonDesktopRq> 
                 <ClientDateTime>%%CLIENT_DATE_TIME%%</ClientDateTime>
                <ApplicationLogin>int3.3plintegration.com</ApplicationLogin>
                <ConnectionTicket>TGT-181-YVkfJkX6Oxtx3HdlhrdusA</ConnectionTicket>
                <Language>English</Language>
                <AppID>477329740</AppID>
                <AppVer>1</AppVer>
                  </SignonDesktopRq> 
                  </SignonMsgsRq> 
                 <QBXMLMsgsRq onError=""stopOnError""> 
                 <InvoiceAddRq requestID=""2"">
			     <InvoiceAdd>";
                vendoeAdd += "<CustomerRef>";
                vendoeAdd += "<FullName>" + Convert.ToString(oQuickEL.CustomerName).Trim().Replace("&", "&amp;") + "</FullName>";
                vendoeAdd += "</CustomerRef>";
                vendoeAdd += "<TxnDate>" + DateTime.Now.ToString("yyyy-MM-dd") + "</TxnDate>";
                //vendoeAdd += "<RefNumber>" + Convert.ToString(oQuickEL.CustomerFirstName).Trim().Replace("&", "&amp;") + "</RefNumber>";
                vendoeAdd += "<RefNumber>" + Convert.ToString(oQuickEL.CustomerInvoiceNo).Trim().Replace("&", "&amp;") + "</RefNumber>";

                vendoeAdd += "<BillAddress>";
                vendoeAdd += "<Addr1>" + Convert.ToString(oQuickEL.CustomerAddr1).Trim().Replace("&", "&amp;") + "</Addr1>";
                vendoeAdd += "<City>" + Convert.ToString(oQuickEL.CustomerCity).Trim().Replace("&", "&amp;") + "</City>";
                vendoeAdd += "<State>" + Convert.ToString(oQuickEL.CustomerState).Trim().Replace("&", "&amp;") + "</State>";
                vendoeAdd += "<PostalCode>" + Convert.ToString(oQuickEL.CustomerPostalCode).Trim().Replace("&", "&amp;") + "</PostalCode>";
                vendoeAdd += "<Country>" + Convert.ToString(oQuickEL.CustomerCountry).Trim().Replace("&", "&amp;") + "</Country>";
                vendoeAdd += "</BillAddress>";
                vendoeAdd += @"<PONumber></PONumber>
				<Memo></Memo>";

                vendoeAdd += "<InvoiceLineAdd>";
                vendoeAdd += "<ItemRef>";
                vendoeAdd += "<FullName>Transportation</FullName>";
                vendoeAdd += "</ItemRef>";
                vendoeAdd += "<Desc>" + Convert.ToString(oQuickEL.CustomerInvoiceDesc).Trim().Replace("&", "&amp;") + "</Desc>";
                
                vendoeAdd += "<Quantity>" + Convert.ToString(oQuickEL.CustomerTotalQty).Trim().Replace("&", "&amp;") + "</Quantity>";
                vendoeAdd += "<Rate>" + Convert.ToString(oQuickEL.CustomerTotalAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Rate>";
                vendoeAdd += "<Amount>" + Convert.ToString(oQuickEL.CustomerTotalAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount>";
                vendoeAdd += "</InvoiceLineAdd>";

               

                vendoeAdd += @"</InvoiceAdd>
		                    </InvoiceAddRq>
	                        </QBXMLMsgsRq>
                            </QBXML>";

                vendoeAdd = vendoeAdd.Replace("%%CLIENT_DATE_TIME%%", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(vendoeAdd);

                vendoeAdd = xmlDoc.InnerXml;

                WebRequestObject.ContentLength = vendoeAdd.Length;
                swr = new StreamWriter(WebRequestObject.GetRequestStream());

                swr.Write(vendoeAdd);
                swr.Close();
                WebResponseObject = (HttpWebResponse)WebRequestObject.GetResponse();
                sr = new StreamReader(WebResponseObject.GetResponseStream());
                Results = sr.ReadToEnd();

            }
            finally
            {
                try
                {
                    sr.Close();
                }
                catch
                {
                }

                try
                {
                    WebResponseObject.Close();
                    WebRequestObject.Abort();
                }
                catch
                {
                }
            }
            return Results;
        }
        #endregion
    }
}
