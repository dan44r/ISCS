using BusinessLogicLayer;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class SpecialServicesCodeLookUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                ViewState["SortOrder"] = "SpecialServiceName asc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet dt;
            dt = SpecialServicesBL.FetchAllSpecialServices();
            DataView dv = new DataView();
            dv.Table = dt.Tables[0];
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
            if (e.CommandName == "sortName")
            {
                if (ViewState["SortOrder"].ToString() == "SpecialServiceName desc")
                {
                    ViewState["SortOrder"] = "SpecialServiceName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "SpecialServiceName desc";
                }
                BindGrid();
            }
        }
    }
}
