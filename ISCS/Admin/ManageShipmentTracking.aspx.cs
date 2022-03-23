using BusinessLogicLayer;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class ManageShipmentTracking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {

                string strpagename = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath);
                int userTypeId = Convert.ToInt32(Session["cacheUserRole"]);
                DataTable dtUserTypeSectionXref = UserTypeSectionsXrefBL.GetSectionIdByUserTypeId(userTypeId);
                bool redirectionflg = true;
                foreach (DataRow dr in dtUserTypeSectionXref.Rows)
                {
                    DataTable dtSection = SectionsBL.GetSectionById(Convert.ToInt32(dr["SectionId"]));
                    if (strpagename == dtSection.Rows[0]["SectionUrl"].ToString())
                    {
                        redirectionflg = false;
                    }
                }
                if (redirectionflg)
                {
                    Response.Redirect(ResolveUrl("~/Admin/Error.aspx"));
                }

                BindDrpBills();
                BindDrpAgents();
                BindDrpShipper();
                BindDrpConsignee();
                BindDrpShippedDates();
            }
        }

        protected void BindDrpBills()
        {
            if (Session["cacheUserRole"] != null)
            {
                int userTypeId = Convert.ToInt32(Session["cacheUserRole"]);
                if (userTypeId != 0)
                {
                    DataTable dtUserType = UserTypesBL.FetchUserTypeAllById(userTypeId);
                    DataSet dtbills = TBillsBL.FetchAllBills(Convert.ToInt32(dtUserType.Rows[0]["UserCode"]), Convert.ToInt32(dtUserType.Rows[0]["UserTypeId"]));
                    drpBills.DataSource = dtbills.Tables[0];
                    drpBills.DataValueField = "TrackingBillId";
                    drpBills.DataTextField = "tracking_no";
                    drpBills.DataBind();
                }
                else
                {
                    Response.Redirect(ResolveUrl("~/SecureLogin.aspx"));
                }
            }
            else
            {
                Response.Redirect(ResolveUrl("~/SecureLogin.aspx"));
            }
        }

        protected void BindDrpAgents()
        {
            //Get Agents
            DataTable dtAgent = UserBL.GetByUserTypeId(7);
            drpAgents.DataSource = dtAgent;
            drpAgents.DataValueField = "UserId";
            drpAgents.DataTextField = "FirstName";
            drpAgents.DataBind();
            ListItem lstItem = new ListItem("--All Agents--", "0");
            drpAgents.Items.Insert(0, lstItem);
        }

        protected void BindDrpShipper()
        {
            DataSet dtShipper = TBillsBL.FetchAllShipper();
            drpShipper.DataSource = dtShipper.Tables[0];
            drpShipper.DataValueField = "ShipFromCompany";
            drpShipper.DataTextField = "ShipFromCompany";
            drpShipper.DataBind();
            ListItem lstItem = new ListItem("--All Shipper--", "0");
            drpShipper.Items.Insert(0, lstItem);
        }

        protected void BindDrpConsignee()
        {
            DataSet dtConsignee = TBillsBL.FetchAllConsignee();
            drpConsignee.DataSource = dtConsignee.Tables[0];
            drpConsignee.DataValueField = "ShipToCompany";
            drpConsignee.DataTextField = "ShipToCompany";
            drpConsignee.DataBind();
            ListItem lstItem = new ListItem("--All Consignee--", "0");
            drpConsignee.Items.Insert(0, lstItem);
        }

        protected void BindDrpShippedDates()
        {
            for (int i = 1; i <= 29; i++)
            {
                if (i == 1)
                {
                    ListItem lstItem = new ListItem("24 Hours", DateTime.Today.AddHours(-24).ToString());
                    drpShippedDates.Items.Add(lstItem);
                }
                else if (i == 7)
                {
                    ListItem lstItem = new ListItem("1 Week", DateTime.Today.AddDays(-7).ToString());
                    drpShippedDates.Items.Add(lstItem);
                }
                else if (i == 14)
                {
                    ListItem lstItem = new ListItem("2 Weeks", DateTime.Today.AddDays(-14).ToString());
                    drpShippedDates.Items.Add(lstItem);
                }
                else if (i == 21)
                {
                    ListItem lstItem = new ListItem("3 Weeks", DateTime.Today.AddDays(-21).ToString());
                    drpShippedDates.Items.Add(lstItem);
                }
                else if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6)
                {
                    ListItem lstItem = new ListItem(i + " Days", DateTime.Today.AddDays(-i).ToString());
                    drpShippedDates.Items.Add(lstItem);
                }
            }

            ListItem lstItemMon = new ListItem("Month", DateTime.Today.AddMonths(-1).ToString());
            drpShippedDates.Items.Add(lstItemMon);
            ListItem lstItemAll = new ListItem("All Dates", "");
            drpShippedDates.Items.Insert(0, lstItemAll);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            drpBills.SelectedIndex = 0;
            txtBillnumber.Text = "";
            drpAgents.SelectedIndex = 0;
            drpShipper.SelectedIndex = 0;
            drpConsignee.SelectedIndex = 0;
            drpShippedDates.SelectedIndex = 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            hdnAgentId.Value = drpAgents.SelectedItem.Value;
            hdnShipFromCompany.Value = drpShipper.SelectedItem.Value;
            hdnShipToCompany.Value = drpConsignee.SelectedItem.Value;
            hdnShippedDates.Value = drpShippedDates.SelectedItem.Value;
        }

        protected void editdrp_Click(object sender, EventArgs e)
        {
            hdnTrackingBillId.Value = drpBills.SelectedItem.Value;
        }

        protected void edittrackno_Click(object sender, EventArgs e)
        {
            hdnTrackingNumber.Value = txtBillnumber.Text.Trim().ToString();
        }
    }
}
