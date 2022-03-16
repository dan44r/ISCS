using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class UserLocationWarehousePop : System.Web.UI.Page
    {
        protected string strCompanyArr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["search"]="d";
                BindData();
            }
        }
        protected void BindData()
        {
            DataSet ds = null;
            ds = WarehouseLocationBL.FetchWarehouseLocationAllPop(ViewState["search"].ToString(), txtCompany.Text.Trim());          
            gridUserLocations.DataSource = ds;
            gridUserLocations.DataBind();
            if (strCompanyArr != "")
            {
                strCompanyArr = strCompanyArr.Substring(0, strCompanyArr.Length - 1);
                if (Session["CompanyArrWarehouse"] != null)
                {
                    return;
                }
                if (Session["CompanyArrWarehouse"] == null)
                {
                    Session["CompanyArrWarehouse"] = strCompanyArr;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnListAll_Click(object sender, EventArgs e)
        {
            txtCompany.Text = "";
            BindData();
        }

        protected void gridUserLocations_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Label)e.Row.FindControl("lblCompanyName")).Attributes.Add("onclick", "SelectLocation(this.id);");
                strCompanyArr += "'" + ((Label)e.Row.FindControl("lblCompanyName")).Text.Replace("'", " ") + "',";                
            }
        }
        protected void imgBtnDelLocation_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            bool stat = UserLocationBL.DeleteLocation(Convert.ToInt32(btnSender.CommandArgument));
            if (stat == true)
            {
                lblMsg.Text = "The warehouse has been deleted Successfully";
                BindData();
            }
        }
    }
}
