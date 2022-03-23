using BusinessLogicLayer;
using CF.Web.Security;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS
{
    public partial class PackingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pickupreqid = 0;
            if (!IsPostBack)
            {
                if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
                {
                    ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
                    HiddenField hfPickUpRequestid = (HiddenField)contentPh.FindControl("hdPickupRequestId");
                    pickupreqid = Convert.ToInt32(hfPickUpRequestid.Value);
                    ViewState["pickupreqid"] = pickupreqid;
                }
                if (Request.QueryString["id"] != null)
                {
                    string strReqIDDecode = SecurityUtils.UrlDecode(Convert.ToString(Request.QueryString["id"]));
                    ViewState["pickupreqid"] = strReqIDDecode;
                    pickupreqid = Convert.ToInt32(strReqIDDecode);
                }
                BindGrid(pickupreqid);
            }
        }

        protected void BindGrid(int pickupreqid)
        {
            DataSet dsPL = ShipmentItemsBL.FetchShipmentUnit(pickupreqid);
            if (dsPL.Tables[0].Rows.Count > 0)
            {
                lblGlsTrackingNumber.Text = dsPL.Tables[0].Rows[0]["GlsTrackingNumber"].ToString();

                gridUsers.DataSource = dsPL.Tables[0];
                gridUsers.DataBind();
            }
        }
    }
}
