using BusinessLogicLayer;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class CarriersPop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["dt"] != null)
                {
                    hidType.Value = Request.QueryString["dt"].ToString();
                }
                BindData();
            }
        }

        protected void BindData()
        {
            DataSet ds = null;
            if (Session["cacheUserId"] != null)
            {
                ds = CarriersBL.FetchAllCarriersforpopup(Convert.ToInt32(Session["cacheUserCode"].ToString()), Convert.ToInt32(Session["cacheUserId"].ToString()));
            }
            gridCarriers.DataSource = ds;
            gridCarriers.DataBind();
        }
        protected void imgBtnDelLocation_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            bool stat = CarriersBL.DeleteCarriers(Convert.ToInt32(btnSender.CommandArgument));
            if (stat == true)
            {
                BindData();
            }
        }
    }
}
