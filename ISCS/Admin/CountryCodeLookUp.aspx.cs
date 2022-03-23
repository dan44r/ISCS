using BusinessLogicLayer;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class CountryCodeLookUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                ViewState["SortOrder"] = "Abbreviation asc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet dt;
            dt = CountriesBL.FetchAllCountries();
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
            if (e.CommandName == "sortAbbr")
            {
                if (ViewState["SortOrder"].ToString() == "Abbreviation desc")
                {
                    ViewState["SortOrder"] = "Abbreviation asc";
                }
                else
                {
                    ViewState["SortOrder"] = "Abbreviation desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortName")
            {
                if (ViewState["SortOrder"].ToString() == "Name desc")
                {
                    ViewState["SortOrder"] = "Name asc";
                }
                else
                {
                    ViewState["SortOrder"] = "Name desc";
                }
                BindGrid();
            }
        }
    }
}
