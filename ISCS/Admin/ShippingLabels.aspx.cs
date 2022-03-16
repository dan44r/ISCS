using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using CF.Web.Security;

namespace ISCS.Admin
{
    public partial class ShippingLabels : System.Web.UI.Page
    {
        public int count = 1;
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
                DataTable dtSelectBOL = PickupRequestBL.FetchBillofLading(pickupreqid);

                if (dtSelectBOL.Rows.Count > 0)
                {
                    pnldoc.Visible = true;
                    pnlnorecord.Visible = false;

                    lblGlsTrackingNumber.Text = dtSelectBOL.Rows[0]["GLSTrackingNumber"].ToString();

                    gridUsers.DataSource = dtSelectBOL;
                    gridUsers.DataBind();
                }
                else
                {
                    pnlnorecord.Visible = true;
                    pnldoc.Visible = false;
                }                
            }
            else
            {
                pnlnorecord.Visible = true;
                pnldoc.Visible = false;
            }
        }

        protected void gridUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Label)e.Row.FindControl("lblintSkidCounter")).Text = count.ToString();
                count++;

                DataSet dsPL1 = ShipmentItemsBL.FetchShipmentUnit(Convert.ToInt32(ViewState["pickupreqid"]));
                ((Label)e.Row.FindControl("lblintSkidId_SI")).Text = Convert.ToString(dsPL1.Tables[0].Rows[0]["SkidId_SI"]);
                ((Label)e.Row.FindControl("lblintSkidCount")).Text = Convert.ToString(dsPL1.Tables[0].Rows[0]["SkidCount"]);

                DataSet dtSelectBOLL = ShipmentItemsBL.FetchShipmentUnit(Convert.ToInt32(ViewState["pickupreqid"]));

                if (dtSelectBOLL.Tables[0].Rows.Count > 0)
                {
                    ((GridView)e.Row.FindControl("gridContents")).DataSource = dtSelectBOLL.Tables[0];
                    ((GridView)e.Row.FindControl("gridContents")).DataBind();
                }
            }
        }

        protected void gridContents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
    }
}
