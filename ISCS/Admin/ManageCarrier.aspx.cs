using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class ManageCarrier : System.Web.UI.Page
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


                ViewState["SearchKey"] = "";
                ViewState["SortOrder"] = "CarrierName desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;
            if (drpSearchCol.SelectedIndex > 0)
            {
                ds = CarriersBL.FetchAllCarriers(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Value);
            }
            else
            {
                ds = CarriersBL.FetchAllCarriers();
            }
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridUsers.DataSource = dv;
            gridUsers.DataBind();
        }
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            Boolean stat = CarriersBL.DeleteCarriers(Convert.ToInt32(btnSender.CommandArgument));
            if (stat == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The Carrier has been deleted Successfully.";
                BindGrid();
            }
        }
        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            hidFCarrierid.Value = btnSender.CommandArgument;
        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortCarrierName")
            {
                if (ViewState["SortOrder"].ToString() == "CarrierName desc")
                {
                    ViewState["SortOrder"] = "CarrierName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "CarrierName desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortCity")
            {

                if (ViewState["SortOrder"].ToString() == "city desc")
                {
                    ViewState["SortOrder"] = "city asc";
                }
                else
                {
                    ViewState["SortOrder"] = "city desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortState")
            {

                if (ViewState["SortOrder"].ToString() == "state desc")
                {
                    ViewState["SortOrder"] = "state asc";
                }
                else
                {
                    ViewState["SortOrder"] = "state desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortContact")
            {

                if (ViewState["SortOrder"].ToString() == "ContactName desc")
                {
                    ViewState["SortOrder"] = "ContactName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ContactName desc";
                }
                BindGrid();

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchKey"] = txtSearchKey.Text.ToString().Trim();
            BindGrid();
        }
    }
}
