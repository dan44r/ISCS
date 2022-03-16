using System;
using System.Data;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class UserLocationPop : System.Web.UI.Page
    {
        protected string strCompanyArr = "";
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                if (Request.QueryString["dt"]!=null && Request.QueryString["dt"].ToString() == "1")
                {
                    hidType.Value = "1";
                }
                else
                {
                    hidType.Value = "2";
                }
                BindData();
            }     
        }

        protected void BindData()
        {
            DataSet ds=null;
            if (Session["cacheUserId"] != null)
            {                
                ds = UserLocationBL.FetchUserLocation(Convert.ToInt32(Session["cacheUserId"].ToString()), Convert.ToInt32(Session["cacheUserCode"].ToString()), "", txtCompany.Text.Trim());                
            }
            if (ds != null && ds.Tables[0].Rows.Count == 0)
            {
                lblMsg.Text = "No matches found.";
            }
            gridUserLocations.DataSource = ds;
            gridUserLocations.DataBind();
            if (strCompanyArr != "")
            {
                strCompanyArr = strCompanyArr.Substring(0, strCompanyArr.Length - 1);
                if (Session["CompanyArr"] != null)
                {
                    return;
                }
                if (Session["CompanyArr"] == null)
                {
                    Session["CompanyArr"] = strCompanyArr;
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
                strCompanyArr += "'"+((Label)e.Row.FindControl("lblCompanyName")).Text.Replace("'"," ") + "',";                
            }
        }
        protected void imgBtnDelLocation_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            bool stat = UserLocationBL.DeleteLocation(Convert.ToInt32(btnSender.CommandArgument));
            if (stat == true)
            {
                lblMsg.Text = "The location has been deleted Successfully";
                BindData();
            }
        }
    }
}
