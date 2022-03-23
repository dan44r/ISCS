using BusinessLogicLayer;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class UserTypelookUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                ViewState["SortOrder"] = "UserCode asc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataTable dt;
            dt = UserTypesBL.FetchAllUserTypes();
            DataView dv = new DataView();
            dv.Table = dt;
            dv.Sort = ViewState["SortOrder"].ToString();
            gridUTypeCode.DataSource = dv;
            gridUTypeCode.DataBind();
        }

        protected void gridFeedback_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUTypeCode.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridUTypeCode_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortCode")
            {
                if (ViewState["SortOrder"].ToString() == "UserCode desc")
                {
                    ViewState["SortOrder"] = "UserCode asc";
                }
                else
                {
                    ViewState["SortOrder"] = "UserCode desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortUserType")
            {

                if (ViewState["SortOrder"].ToString() == "UserType desc")
                {
                    ViewState["SortOrder"] = "UserType asc";
                }
                else
                {
                    ViewState["SortOrder"] = "UserType desc";
                }
                BindGrid();

            }
        }
    }
}
