using BusinessLogicLayer;
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class ActiveShipmentReport : System.Web.UI.Page
    {
        DataTable dt1 = null;
        public string strCostSummary = "";
        string strOrderNo = "";
        int days = 0;
        double AddCost = 0.00;
        public static string strTotalCost = string.Empty;
        public static string OrderNo = string.Empty;
        public static string CurrentDate = DateTime.Now.ToString();
        public static string CompanyName = string.Empty;

        int userId = 0;
        int accountcodeId = 0;
        string email = "";
        string company = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();

            }

        }
        protected void BindGrid()
        {

            DataSet ds;
            int userId = 0;
            int accountcodeId = 0;
            string email = "";
            string company = "";

            if (Session["cacheUserId"] != null)
            {
                userId = Convert.ToInt32(Session["cacheUserId"]);
            }
            DataTable dtUser = UserBL.GetUserByUserId(userId);
            if (dtUser.Rows.Count > 0)
            {
                if (dtUser.Rows[0]["AccountCodeId"] != null && Convert.ToString(dtUser.Rows[0]["AccountCodeId"]).Trim() != "")
                {
                    accountcodeId = Convert.ToInt32(dtUser.Rows[0]["AccountCodeId"]);
                }
                email = dtUser.Rows[0]["EMail"].ToString();
                ViewState["thisEmail"] = email;
                company = dtUser.Rows[0]["CompanyName"].ToString();
                ViewState["thisCompany"] = company;
            }

            ds = PickupRequestBL.FetchActiveShipmentReport(accountcodeId);

            DataView dv = new DataView();
            dv.Table = ds.Tables[0];

            ViewState["thisDT"] = ds.Tables[0];
            dt1 = ds.Tables[0];
            if (dt1.Rows.Count == 0)
            {

            }
            else
            {
                gridActiveShipment.DataSource = dv;
                gridActiveShipment.DataBind();
                btnExport.Visible = true;
                btnEmail.Visible = true;
            }
        }
        protected void PopulateReport()
        {
            if (Request.QueryString["on"] != null)
            {
                OrderNo = Request.QueryString["on"].ToString();
            }
            AddCost = 0.00;
            DataSet dsPR = PickupRequestBL.FetchCostSummaryByOrderNoReport(strOrderNo, accountcodeId);
            if (dsPR.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsPR.Tables[0].Rows.Count; i++)
                {
                    AddCost = AddCost + Convert.ToDouble(dsPR.Tables[0].Rows[i]["GLSTotalSellRate"]);
                }
                strTotalCost = string.Format("{0:0.00}", AddCost);
                CompanyName = Convert.ToString(dsPR.Tables[0].Rows[0]["ShipFromCompany"]);
                rpt1.DataSource = dsPR.Tables[0];
                rpt1.DataBind();
            }



        }
        public string DateFormat(string date)
        {
            string str = Convert.ToString(Convert.ToDateTime(date).ToShortDateString());
            return str;
        }
        public string DifferenceDate(string dateFrom, string dateTo)
        {
            DateTime FromDate = Convert.ToDateTime(dateFrom);
            DateTime ToDate = Convert.ToDateTime(dateTo);
            TimeSpan ts = FromDate.Subtract(ToDate);
            days = ts.Days;
            string strDays = string.Empty;
            if (days > 1)
            {
                strDays = strDays + days + " Days";
            }
            else
            {
                strDays = strDays + days + " Day";
            }

            return strDays;
        }
        protected void BindGrid1()
        {




            if (Session["cacheUserId"] != null)
            {
                userId = Convert.ToInt32(Session["cacheUserId"]);
            }
            DataTable dtUser = UserBL.GetUserByUserId(userId);
            if (dtUser.Rows.Count > 0)
            {
                if (dtUser.Rows[0]["AccountCodeId"] != null && Convert.ToString(dtUser.Rows[0]["AccountCodeId"]).Trim() != "")
                {
                    accountcodeId = Convert.ToInt32(dtUser.Rows[0]["AccountCodeId"]);
                }
                email = dtUser.Rows[0]["EMail"].ToString();
                ViewState["thisEmail"] = email;
                company = dtUser.Rows[0]["CompanyName"].ToString();
                ViewState["thisCompany"] = company;
            }

            StringBuilder sbMailBody = new StringBuilder();
            DataSet dsPR = PickupRequestBL.FetchCostSummaryByOrderNoReport(strOrderNo, accountcodeId);
            if (dsPR.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsPR.Tables[0].Rows.Count; i++)
                {
                    AddCost = AddCost + Convert.ToDouble(dsPR.Tables[0].Rows[i]["GLSTotalSellRate"]);
                }
            }
            string strTotalCost = string.Format("{0:0.00}", AddCost);

            if (dsPR.Tables[0].Rows.Count > 0)
            {
                sbMailBody.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 10px;\">");
                sbMailBody.Append("<table width=\"100%\"><tr><td style=\"width=30%\"><b>Order No:</b> " + strOrderNo);
                sbMailBody.Append("</td><td style=\"width=40%\"></td>");
                sbMailBody.Append("<td align=\"right\" style=\"text-align:right;width:30%\"><b>Total Cost: " + strTotalCost + "</b> ");

                sbMailBody.Append("</td>");
                sbMailBody.Append("</tr>");
                sbMailBody.Append("<tr>");
                sbMailBody.Append("<td style=\"width=30%\"><b>3PL Integration, LLC<br>508 210-2164</b>");
                sbMailBody.Append("</td><td style=\"width=40%\"></td>");
                sbMailBody.Append("<td style=\"width=30%\" align=\"right\"><b>Run Date:</b> " + DateTime.Now.ToString());
                sbMailBody.Append("</td>");
                sbMailBody.Append("</tr>");
                sbMailBody.Append("<tr>");
                sbMailBody.Append("<td colspan=\"3\" align=\"center\"><b>COST SUMMARY BY ORDER NUMBER REPORT</b>");
                sbMailBody.Append("</td>");
                sbMailBody.Append("</tr>");
                sbMailBody.Append("<tr>");
                sbMailBody.Append("<td colspan=\"3\" align=\"center\"><b>" + Convert.ToString(dsPR.Tables[0].Rows[0]["ShipFromCompany"]) + "</b>");
                sbMailBody.Append("</td>");
                sbMailBody.Append("</tr>");
                sbMailBody.Append("</table>");
                sbMailBody.Append("<hr style=\"height: 10px; color: black;\" />");

                if (dsPR.Tables[0].Rows.Count > 0)
                {
                    sbMailBody.Append("");
                    for (int i = 0; i < dsPR.Tables[0].Rows.Count; i++)
                    {
                        DateTime FromDate = Convert.ToDateTime(dsPR.Tables[0].Rows[i]["ShipFromDate"]);
                        DateTime ToDate = Convert.ToDateTime(dsPR.Tables[0].Rows[i]["ShipToDate"]);
                        TimeSpan ts = FromDate.Subtract(ToDate);
                        days = ts.Days;
                        string strDays = string.Empty;
                        if (days > 1)
                        {
                            strDays = strDays + days + " Days";
                        }
                        else
                        {
                            strDays = strDays + days + " Day";
                        }
                        sbMailBody.Append("<table><tr><td valign=\"top\" style=\"width=30%\">" + Convert.ToString(dsPR.Tables[0].Rows[i]["TrackingNumber"]));

                        sbMailBody.Append("&nbsp;&nbsp;&nbsp;&nbsp; <b>Order No:</b> " + Convert.ToString(dsPR.Tables[0].Rows[i]["ShipFromRefNumber"]));
                        sbMailBody.Append("<br /><b>CID:</b> " + Convert.ToString(dsPR.Tables[0].Rows[i]["ShipToConsigneeRefNumber"]));
                        sbMailBody.Append("</td>");
                        sbMailBody.Append("<td style=\"width=40%\">" + Convert.ToString(dsPR.Tables[0].Rows[i]["Description1"]));
                        sbMailBody.Append("</td>");
                        sbMailBody.Append("<td align=\"center\" valign=\"top\" style=\"width=30%\"><b>Status:</b> " + Convert.ToString(dsPR.Tables[0].Rows[i]["Description2"]));
                        sbMailBody.Append("<br />" + Convert.ToString(dsPR.Tables[0].Rows[i]["Notes"]));
                        sbMailBody.Append("</td>");
                        sbMailBody.Append("</tr>");
                        sbMailBody.Append("<tr>");
                        sbMailBody.Append("<td><b>Ship Date:</b> " + Convert.ToString(Convert.ToDateTime(dsPR.Tables[0].Rows[i]["ShipFromDate"]).ToShortDateString()));
                        sbMailBody.Append("<br /><b>Transit Time To Date:</b> " + Convert.ToString(Convert.ToDateTime(dsPR.Tables[0].Rows[i]["ShipToDate"]).ToShortDateString()));
                        sbMailBody.Append("<br /><b>Carrier:</b> " + Convert.ToString(dsPR.Tables[0].Rows[i]["CarrierName"]));
                        sbMailBody.Append("<br /><b>Cost:</b> " + Convert.ToString(dsPR.Tables[0].Rows[i]["GLSTotalSellRate"]));
                        sbMailBody.Append("</td>");
                        sbMailBody.Append("<td> ");
                        sbMailBody.Append("</td>");
                        sbMailBody.Append("<td>");
                        sbMailBody.Append("</td>");
                        sbMailBody.Append("</tr>");
                        sbMailBody.Append("<tr>");
                        sbMailBody.Append("<td><b>Last Updated:</b> " + Convert.ToString(Convert.ToDateTime(dsPR.Tables[0].Rows[i]["DateLastUpdated"]).ToShortDateString()));
                        sbMailBody.Append("</td>");
                        sbMailBody.Append("<td><b>Service:</b> " + Convert.ToString(dsPR.Tables[0].Rows[i]["Service1"]));
                        sbMailBody.Append("</td>");
                        sbMailBody.Append("<td>");
                        sbMailBody.Append("</td>");
                        sbMailBody.Append("</tr>");
                        sbMailBody.Append("</table>");
                        sbMailBody.Append("<hr style=\"height: 10px; color: black!important;\" width=\"100%\"/>");
                    }

                }
                else
                {
                    btnExport.Visible = false;
                    btnEmail.Visible = false;
                }
                sbMailBody.Append("</div>");
                ViewState["thisDT1"] = sbMailBody.ToString();
                ltCostSum.Text = sbMailBody.ToString();
            }
            else
            {
                btnExport.Visible = false;
                btnEmail.Visible = false;
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {

                if (ViewState["thisDT"] != null)
                { dt1 = (DataTable)ViewState["thisDT"]; }
                Convert1(dt1, Response);
            }
            catch (Exception ex) { }
        }
        protected void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {

                if (ViewState["thisDT"] != null)
                { dt1 = (DataTable)ViewState["thisDT"]; }
                GenerateSendMail(dt1, Response);
            }
            catch (Exception ex) { }
        }

        public void Convert1(DataTable dt, HttpResponse Response)
        {
            try
            {
                string email = "";
                string company = "";
                if (ViewState["thisEmail"] != null) { email = Convert.ToString(ViewState["thisEmail"]); }
                if (ViewState["thisCompany"] != null) { company = Convert.ToString(ViewState["thisCompany"]); }
                Response.Clear();
                Response.Charset = "";
                string fname = company.Replace(" ", "_") + "_Active_Shipment_Query_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + fname);
                Response.ContentType = "application/vnd.ms-excel";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
                System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
                dg.DataSource = dt;
                dg.DataBind();
                dg.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#c0c0c0");
                dg.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch { }
        }

        public void GenerateSendMail(DataTable dt, HttpResponse Response)
        {
            try
            {
                string email = "";
                string company = "";
                if (ViewState["thisEmail"] != null) { email = Convert.ToString(ViewState["thisEmail"]); }
                if (ViewState["thisCompany"] != null) { company = Convert.ToString(ViewState["thisCompany"]); }
                string fname = company.Replace(" ", "_") + "_Active_Shipment_Query_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
                System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
                dg.DataSource = dt;
                dg.DataBind();
                dg.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#c0c0c0");
                dg.RenderControl(htmlWrite);
                byte[] byteArray = System.Text.Encoding.Default.GetBytes(stringWrite.ToString());
                using (System.IO.FileStream fileStream = new System.IO.FileStream(Server.MapPath("../QBFiles/Reports/" + fname), System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    fileStream.Write(byteArray, 0, byteArray.Length);
                    fileStream.Close();
                }
                StringBuilder sbMailBody = new StringBuilder();
                sbMailBody.Append("<table><tr><td>Please find the attached Active Shipment Query.");
                sbMailBody.Append("</td></tr> ");
                sbMailBody.Append("</table>");
                if (email.Trim() == "admin@admin.com") { email = ConfigurationManager.AppSettings["AdminEmail"].Trim(); }
                int iStat = CommonBL.sendMailWithAttch("ops@3plintegration.com", email, company + " Active Shipment Query", sbMailBody.ToString(), Server.MapPath("../QBFiles/Reports/" + fname));
                if (iStat > 0)
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dfgdfg1", "alert('This report has been sent to Email address " + email.ToString() + "');", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hjhj1", "alert('Sorry, please try again.');", true);
                }

            }
            catch { }
        }

        public void pdfFunction1(string strBody)
        {



            string email = "";
            string company = "";
            if (ViewState["thisEmail"] != null) { email = Convert.ToString(ViewState["thisEmail"]); }
            if (ViewState["thisCompany"] != null) { company = Convert.ToString(ViewState["thisCompany"]); }
            Response.Clear();
            Response.Charset = "";
            string fname = company.Replace(" ", "_") + "_Cost_Summary_By_Order_Number_Report" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + fname);
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(strBody.ToString());
            Response.End();
            string sHTML = "<div style='width: 416px; font-family: @Arial Unicode MS; font-size: 10px;'>dfgfdg</div>";

        }

        public void GenerateSendMail(string strBody)
        {



            string email = "";
            string company = "";
            if (ViewState["thisEmail"] != null) { email = Convert.ToString(ViewState["thisEmail"]); }
            if (ViewState["thisCompany"] != null) { company = Convert.ToString(ViewState["thisCompany"]); }
            string fname = company.Replace(" ", "_") + "_Cost_Summary_By_Order_Number_Report" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xls";

            byte[] byteArray = System.Text.Encoding.Default.GetBytes(strBody.ToString());
            using (System.IO.FileStream fileStream = new System.IO.FileStream(Server.MapPath("../QBFiles/Reports/" + fname), System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                fileStream.Write(byteArray, 0, byteArray.Length);
                fileStream.Close();
            }
            StringBuilder sbMailBody1 = new StringBuilder();
            sbMailBody1.Append("<table><tr><td>Please find the attached Cost Summary By Order Number Report.");
            sbMailBody1.Append("</td></tr> ");
            sbMailBody1.Append("</table>");
            if (email.Trim() == "admin@admin.com") { email = ConfigurationManager.AppSettings["AdminEmail"].Trim(); }
            CommonBL.sendMailWithAttch("ops@3plintegration.com", email, company + " Cost Summary By Order Number Report", sbMailBody1.ToString(), Server.MapPath("../QBFiles/Reports/" + fname));

            string sHTML = "<div style='width: 416px; font-family: @Arial Unicode MS; font-size: 10px;'>dfgfdg</div>";

        }

        protected void gridActiveShipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridActiveShipment.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}
