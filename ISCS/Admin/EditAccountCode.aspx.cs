using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using EntityLayer;

namespace ISCS.Admin
{
    public partial class EditAccountCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                BindValues();
            }
            if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "update")
            {
                btnAdd.Text = "Update";
            }
        }
        protected void BindValues()
        {
            ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
            HiddenField hfAccountid = (HiddenField)contentPh.FindControl("hidFAccountid");
            int strAccountid = Convert.ToInt32(hfAccountid.Value);
            ViewState["AccountId"] = strAccountid;
            DataTable dtAccountCode = AccountCodesBL.GetAccountCodeByAccountId(strAccountid);
            txtAccountCode.Text = dtAccountCode.Rows[0]["AccountCode"].ToString().Trim();
            txtAccountName.Text = dtAccountCode.Rows[0]["AccountName"].ToString().Trim();
            txtMargin.Text = dtAccountCode.Rows[0]["Margin"].ToString().Trim();
        }

        protected void btnRetuen_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageAccountCode.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean res = false;
            AccountCodes objAccountCodes = new AccountCodes();
            objAccountCodes.AccountCode = txtAccountCode.Text.ToString().Trim().ToUpper();
            objAccountCodes.AccountName = txtAccountName.Text.ToString().Trim();

            decimal dMargin = 0;
            try
            {
                dMargin = Convert.ToDecimal(txtMargin.Text.ToString().Trim());
            }
            catch
            {
                dMargin = 0;
                txtMargin.Text = "0.00";
            }
            objAccountCodes.Margin = dMargin;

            if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "update")
            {
                int strAccountId = Convert.ToInt32(ViewState["AccountId"]);
                objAccountCodes.AccountId = strAccountId;
                res = AccountCodesBL.UpdateAccountCode(objAccountCodes);
            }
            else
            {
                res = AccountCodesBL.InsertAccountCode(objAccountCodes);
            }
            if (res)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Account Code Add / Update has been successfully done.";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Sorry, please try again later.";
            }

        }
    }
}
