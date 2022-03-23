using BusinessLogicLayer;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class Track_shipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTimeframe();
            }
        }
        protected void BindTimeframe()
        {
            dpTimeframe.Items.Add(new ListItem("All Dates", "1/1/2000"));
            dpTimeframe1.Items.Add(new ListItem("All Dates", "1/1/2000"));

            for (int i = 1; i <= 29; i++)
            {
                if (i == 1)
                {
                    dpTimeframe.Items.Add(new ListItem("24 Hours", DateTime.Now.AddHours(-24).ToString("MM/dd/yyyy")));
                    dpTimeframe1.Items.Add(new ListItem("24 Hours", DateTime.Now.AddHours(-24).ToString("MM/dd/yyyy")));
                }
                if (i == 7)
                {
                    dpTimeframe.Items.Add(new ListItem("1 Week", DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy")));
                    dpTimeframe1.Items.Add(new ListItem("1 Week", DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy")));
                }
                if (i == 14)
                {
                    dpTimeframe.Items.Add(new ListItem("2 Weeks", DateTime.Now.AddDays(-14).ToString("MM/dd/yyyy")));
                    dpTimeframe1.Items.Add(new ListItem("2 Weeks", DateTime.Now.AddDays(-14).ToString("MM/dd/yyyy")));
                }
                if (i == 21)
                {
                    dpTimeframe.Items.Add(new ListItem("3 Weeks", DateTime.Now.AddDays(-21).ToString("MM/dd/yyyy")));
                    dpTimeframe1.Items.Add(new ListItem("3 Weeks", DateTime.Now.AddDays(-21).ToString("MM/dd/yyyy")));
                }
                if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6)
                {
                    dpTimeframe.Items.Add(new ListItem(i.ToString() + " Days", DateTime.Now.AddDays(-i).ToString("MM/dd/yyyy")));
                    dpTimeframe1.Items.Add(new ListItem(i.ToString() + " Days", DateTime.Now.AddDays(-i).ToString("MM/dd/yyyy")));
                }
            }

            dpTimeframe.Items.Add(new ListItem("Month", DateTime.Now.AddMonths(-1).ToString("MM/dd/yyyy")));
            dpTimeframe1.Items.Add(new ListItem("Month", DateTime.Now.AddMonths(-1).ToString("MM/dd/yyyy")));
        }



        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            int userId = 0;
            int accountcodeId = 0;
            DateTime strshippeddt = Convert.ToDateTime("1/1/1753 12:00:00 AM");

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
            }
            hdnAccountCodeId.Value = accountcodeId.ToString();
            hdnTrackingNumber.Value = txtTrackingNo.Text.Trim();
            Session["iAccountCodeId"] = accountcodeId.ToString();
            Session["iTrackingNumber"] = txtTrackingNo.Text.Trim();
            Response.Redirect("Shipment_ListingUser.aspx");
        }

        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            txtTrackingNo.Text = "";
            int userId = 0;
            int accountcodeId = 0;
            DateTime strshippeddt = Convert.ToDateTime("1/1/1753 12:00:00 AM");

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
            }
            hdnAccountCodeId.Value = accountcodeId.ToString();
            hdnShippedDates.Value = dpTimeframe.SelectedItem.Value;

            Session["iAccountCodeId"] = accountcodeId.ToString();
            Session["iShippedDates"] = dpTimeframe.SelectedItem.Value;
            Response.Redirect("Shipment_ListingUser.aspx");
        }

        protected void btnSearchPO_Click(object sender, EventArgs e)
        {
            int userId = 0;
            int accountcodeId = 0;
            DateTime strshippeddt = Convert.ToDateTime("1/1/1753 12:00:00 AM");

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
            }
            hdnAccountCodeId.Value = accountcodeId.ToString();
            hdnTrackingNumber.Value = txtPONo.Text.Trim();
            Session["iAccountCodeId"] = accountcodeId.ToString();
            Session["iTrackingNumber"] = txtPONo.Text.Trim();
            Session["POFlag"] = "1";
            Response.Redirect("Shipment_ListingUserPO.aspx");
        }

        protected void btnSearchAllByPO_Click(object sender, EventArgs e)
        {
            txtTrackingNo.Text = "";
            int userId = 0;
            int accountcodeId = 0;
            DateTime strshippeddt = Convert.ToDateTime("1/1/1753 12:00:00 AM");

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
            }
            hdnAccountCodeId.Value = accountcodeId.ToString();
            hdnShippedDates.Value = dpTimeframe1.SelectedItem.Value;

            Session["iAccountCodeId"] = accountcodeId.ToString();
            Session["iShippedDates"] = dpTimeframe1.SelectedItem.Value;
            Session["POFlag"] = "1";
            Response.Redirect("Shipment_ListingUserPO.aspx");
        }
    }
}
