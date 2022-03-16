using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class ViewInformationRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                BindValues();
            }
        }

        protected void BindValues()
        {
            ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
            HiddenField hfInfoReqid = (HiddenField)contentPh.FindControl("hidFInfoReqid");
            int strInfoReqid = Convert.ToInt32(hfInfoReqid.Value);            

            DataTable dtInfoRequest = InformationRequestBL.FetchInfoRequestByID(strInfoReqid).Tables[0];
            if (dtInfoRequest.Rows != null && dtInfoRequest.Rows.Count > 0)
            {
                lblServiceType.Text = dtInfoRequest.Rows[0]["ServiceType"].ToString().Trim();
                lblName.Text = dtInfoRequest.Rows[0]["Name"].ToString().Trim();
                lblAddress.Text = dtInfoRequest.Rows[0]["Address"].ToString().Trim();
                lblCity.Text = dtInfoRequest.Rows[0]["City"].ToString().Trim();
                lblState.Text = dtInfoRequest.Rows[0]["State"].ToString().Trim();
                lblZip.Text = dtInfoRequest.Rows[0]["Zip"].ToString().Trim();
                lblPhone.Text = dtInfoRequest.Rows[0]["Phone"].ToString().Trim();
                lblEmail.Text = dtInfoRequest.Rows[0]["Email"].ToString().Trim();
                lblReplied.Text = dtInfoRequest.Rows[0]["Reply"].ToString().Trim();
            }
        }

        protected void btnRetuen_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageInformationRequest.aspx");
        }
    }
}
