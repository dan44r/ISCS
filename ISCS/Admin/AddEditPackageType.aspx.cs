using BusinessLogicLayer;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class AddEditPackageType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
                {
                    ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
                    HiddenField hpType = (HiddenField)contentPh.FindControl("hidPType");
                    string strUserid = hpType.Value;
                    char[] splitChar = { '~' };
                    String[] arrPType = strUserid.Split('~');
                    ViewState["PTypeid"] = arrPType[0];
                    ViewState["PType"] = arrPType[1];
                    txtPackageType.Text = ViewState["PType"].ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int isExist = 0;
            Boolean stat = false;
            if (ViewState["PTypeid"] == null)
            {
                stat = PackageTypeBL.AddPackageType(txtPackageType.Text.ToString().Trim(), ref isExist);

            }
            else
            {
                stat = PackageTypeBL.UpdatePackageType(Convert.ToInt32(ViewState["PTypeid"].ToString()), txtPackageType.Text.ToString().Trim(), ref isExist);
            }

            if (isExist > 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "This package type is already exists.";

            }
            if (stat == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Package type has been added successfully";

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagePackageTypes.aspx");
        }
    }
}
