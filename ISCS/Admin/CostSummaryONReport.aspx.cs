using BusinessLogicLayer;
using System;
using System.Configuration;
using System.Data;
using System.Text;

namespace ISCS.Admin
{
    public partial class CostSummaryONReport : System.Web.UI.Page
    {
        DataTable dt1 = null;
        public string strCostSummary = "";
        public static string OrderNumber = string.Empty;

        int userId = 0;
        int accountcodeId = 0;
        string email = "";
        string company = "";
        double AddCost = 0.00;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                btnCostSummaryExp.Visible = false;

            }

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
            DataSet dsPR = PickupRequestBL.FetchCostSummaryByOrderNoReport(txtOrderNo.Text, accountcodeId);
            if (dsPR.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsPR.Tables[0].Rows.Count; i++)
                {
                    AddCost = AddCost + Convert.ToDouble(dsPR.Tables[0].Rows[i]["GLSTotalBuyRate"]);
                }
            }
            string strTotalCost = string.Format("{0:0.00}", AddCost);


            sbMailBody.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 10px;\">");
            sbMailBody.Append("<table style=\"width=100%\"><tr><td><b>Order No:</b> " + txtOrderNo.Text);
            sbMailBody.Append("</td>");
            sbMailBody.Append("<td align=\"right\" style=\"text-align:right;\"><b>Total Cost: " + strTotalCost + "</b> ");
            sbMailBody.Append("</td>");
            sbMailBody.Append("</tr>");
            sbMailBody.Append("<tr>");
            sbMailBody.Append("<td><b>3PL Integration, LLC<br>508 210-2164</b>");
            sbMailBody.Append("</td>");
            sbMailBody.Append("<td align=\"right\"><b>Run Date:</b> " + DateTime.Now.ToString());
            sbMailBody.Append("</td>");
            sbMailBody.Append("</tr>");
            sbMailBody.Append("<tr>");
            sbMailBody.Append("<td colspan=\"2\" align=\"center\"><b>COST SUMMARY BY ORDER NUMBER REPORT</b>");
            sbMailBody.Append("</td>");
            sbMailBody.Append("</tr>");
            sbMailBody.Append("<tr>");
            sbMailBody.Append("<td colspan=\"2\" align=\"center\"><b>" + Convert.ToString(dsPR.Tables[0].Rows[0]["ShipFromCompany"]) + "</b>");
            sbMailBody.Append("</td>");
            sbMailBody.Append("</tr>");
            sbMailBody.Append("</table>");
            sbMailBody.Append("<hr style=\"height: 10px; color: black;\" />");

            if (dsPR.Tables[0].Rows.Count > 0)
            {
                sbMailBody.Append("");
                for (int i = 0; i < dsPR.Tables[0].Rows.Count; i++)
                {
                    sbMailBody.Append("<table><tr><td valign=\"top\" style=\"width=30%\">" + Convert.ToString(dsPR.Tables[0].Rows[i]["TrackingNumber"]));
                    sbMailBody.Append("&nbsp;&nbsp;&nbsp;&nbsp;  <b>Order No:</b> " + Convert.ToString(dsPR.Tables[0].Rows[i]["ShipFromRefNumber"]));
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
                    sbMailBody.Append("<br /><b>Transit Time To Date:</b> " + Convert.ToString(Convert.ToDateTime(dsPR.Tables[0].Rows[i]["ShipFromDate"]).ToShortDateString()));
                    sbMailBody.Append("<br /><b>Carrier:</b> " + Convert.ToString(dsPR.Tables[0].Rows[i]["CarrierName"]));
                    sbMailBody.Append("<br /><b>Cost:</b> " + Convert.ToString(dsPR.Tables[0].Rows[i]["GLSTotalBuyRate"]));
                    sbMailBody.Append("</td>");
                    sbMailBody.Append("<td><b>Dimensional weight:</b> " + Convert.ToString(dsPR.Tables[0].Rows[i]["GLSCubicWeight"]));
                    sbMailBody.Append("</td>");
                    sbMailBody.Append("<td>");
                    sbMailBody.Append("</td>");
                    sbMailBody.Append("</tr>");
                    sbMailBody.Append("<tr>");
                    sbMailBody.Append("<td><b>Last Updated:</b> " + Convert.ToString(Convert.ToDateTime(dsPR.Tables[0].Rows[i]["DateLastUpdated"]).ToShortDateString()));
                    sbMailBody.Append("</td>");
                    sbMailBody.Append("<td><b>Service:</b> " + "Transport");
                    sbMailBody.Append("</td>");
                    sbMailBody.Append("<td>");
                    sbMailBody.Append("</td>");
                    sbMailBody.Append("</tr>");
                    sbMailBody.Append("</table>");
                    sbMailBody.Append("<hr />");
                }
                btnCostSummaryExp.Visible = true;
            }
            sbMailBody.Append("</div>");
            ViewState["thisDT1"] = sbMailBody.ToString();
            ltCostSum.Text = sbMailBody.ToString();
        }
        protected void btnCostSummary_Click(object sender, EventArgs e)
        {
            // //BindGrid1();
            // string url = "CostSummaryReport.aspx?on=" + txtOrderNo.Text;    
            // //Response.Write("<script>");
            // //Response.Write("window.open(" + url + ")");
            // //Response.Write("</script>");


            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "openNewWin('" + url + "')", true);
        }
        protected void btnCostSummaryExp_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["thisDT1"] != null)
                { strCostSummary = Convert.ToString(ViewState["thisDT1"]); }
                pdfFunction1(strCostSummary);
            }
            catch (Exception ex) { }
        }

        public void pdfFunction1(string strBody)
        {



            string email = "";
            string company = "";
            if (ViewState["thisEmail"] != null) { email = Convert.ToString(ViewState["thisEmail"]); }
            if (ViewState["thisCompany"] != null) { company = Convert.ToString(ViewState["thisCompany"]); }
            Response.Clear();
            Response.Charset = "";
            string fname = company.Replace(" ", "_") + "_Cost_Summary_By_Order_Number_Report_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + fname);
            Response.ContentType = "application/vnd.ms-excel";


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

            Response.Write(strBody.ToString());
            Response.End();

            string sHTML = "<div style='width: 416px; font-family: @Arial Unicode MS; font-size: 10px;'>dfgfdg</div>";

        }
    }
}
