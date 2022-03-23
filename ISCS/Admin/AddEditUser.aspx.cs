using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class AddEditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                BindDrpuserTypes();
                BindDrpAccountCode();
                BindDrpState();
                BindDrpCountry();
            }
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
            HiddenField hfUserid = (HiddenField)contentPh.FindControl("hidFUserid");
            int strUserid = Convert.ToInt32(hfUserid.Value);

            ViewState["userId"] = strUserid;

            DataTable dtUser = UserBL.GetUserByUserId(strUserid);
            txtFirstName.Text = dtUser.Rows[0]["FirstName"].ToString().Trim();
            txtLastName.Text = dtUser.Rows[0]["LastName"].ToString().Trim();
            txtPhone.Text = dtUser.Rows[0]["Phone"].ToString().Trim();
            txtFax.Text = dtUser.Rows[0]["Fax"].ToString().Trim();
            txtEmail.Text = dtUser.Rows[0]["Email"].ToString().Trim();
            txtPassword.Text = dtUser.Rows[0]["Password"].ToString().Trim();
            txtCompany.Text = dtUser.Rows[0]["CompanyName"].ToString().Trim();
            txtAddress1.Text = dtUser.Rows[0]["Address1"].ToString().Trim();
            txtAddress2.Text = dtUser.Rows[0]["Address2"].ToString().Trim();
            txtCity.Text = dtUser.Rows[0]["City"].ToString().Trim();
            txtPostalCode.Text = dtUser.Rows[0]["PostalCode"].ToString().Trim();
            drpUserType.SelectedValue = dtUser.Rows[0]["UserTypeId"].ToString().Trim();
            drpCountry.SelectedValue = dtUser.Rows[0]["CountryId"].ToString().Trim();
            drpState.SelectedValue = dtUser.Rows[0]["StateId"].ToString().Trim();
            drpAccountCode.SelectedValue = dtUser.Rows[0]["AccountCodeId"].ToString().Trim();

            if (dtUser.Rows[0]["Active"].ToString() == "False")
            {
                drpActive.SelectedValue = "deactive";
            }
            else if (dtUser.Rows[0]["Active"].ToString() == "True")
            {
                drpActive.SelectedValue = "active";
            }
        }

        protected void BindDrpAccountCode()
        {
            DataSet dtAccountCodes = AccountCodesBL.FetchAllAccountCodesWithMargins();
            drpAccountCode.DataSource = dtAccountCodes;
            drpAccountCode.DataValueField = "Id";
            drpAccountCode.DataTextField = "Value";
            drpAccountCode.DataBind();
            ListItem lstItem = new ListItem("--Select Code--", "0");
            drpAccountCode.Items.Insert(0, lstItem);
        }

        protected void BindDrpState()
        {
            DataSet dtStates = StatesBL.FetchAllStates();
            drpState.DataSource = dtStates.Tables[0];
            drpState.DataValueField = "StateId";
            drpState.DataTextField = "Name";
            drpState.DataBind();
            ListItem lstItem = new ListItem("--Select State--", "0");
            drpState.Items.Insert(0, lstItem);
        }

        protected void BindDrpCountry()
        {
            DataSet dtCountries = CountriesBL.FetchAllCountries();
            drpCountry.DataSource = dtCountries.Tables[0];
            drpCountry.DataValueField = "CountryId";
            drpCountry.DataTextField = "Name";
            drpCountry.DataBind();
            ListItem lstItem = new ListItem("--Select Country--", "0");
            drpCountry.Items.Insert(0, lstItem);
            for (int i = 0; i < drpCountry.Items.Count; i++)
            {
                if (drpCountry.Items[i].Text.Trim().ToUpper() == "UNITED STATES")
                {
                    drpCountry.ClearSelection();
                    drpCountry.Items[i].Selected = true;
                }
            }
        }

        protected void BindDrpuserTypes()
        {
            DataTable dtUserTypes = UserTypesBL.FetchAllUserTypes();
            int UserTypeId = Convert.ToInt32(Session["cacheUserRole"]);
            string UserType = UserTypesBL.FetchUserTypeById(UserTypeId);
            drpUserType.DataSource = dtUserTypes;
            drpUserType.DataValueField = "UserTypeId";
            drpUserType.DataTextField = "UserType";
            drpUserType.DataBind();
            ListItem lstItem = new ListItem("--Select Role--", "0");
            drpUserType.Items.Insert(0, lstItem);
        }

        protected void btnRetuen_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllUsers.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean res = false;
            Users objUsers = new Users();
            objUsers.FirstName = txtFirstName.Text.ToString().Trim();
            objUsers.LastName = txtLastName.Text.ToString().Trim();
            objUsers.UserTypeId = Convert.ToInt32(drpUserType.SelectedItem.Value);
            objUsers.AccountCodeId = Convert.ToInt32(drpAccountCode.SelectedItem.Value);
            objUsers.Phone = txtPhone.Text.ToString().Trim();
            objUsers.Fax = txtFax.Text.ToString().Trim();
            objUsers.Email = txtEmail.Text.ToString().Trim();
            objUsers.Password = txtPassword.Text.ToString().Trim();
            if (drpActive.SelectedItem.Value == "deactive")
            {
                objUsers.Active = false;
            }
            else if (drpActive.SelectedItem.Value == "active")
            {
                objUsers.Active = true;
            }
            objUsers.CompanyName = txtCompany.Text.ToString().Trim();
            objUsers.Address1 = txtAddress1.Text.ToString().Trim();
            objUsers.Address2 = txtAddress2.Text.ToString().Trim();
            objUsers.City = txtCity.Text.ToString().Trim();
            objUsers.StateId = Convert.ToInt32(drpState.SelectedItem.Value);
            objUsers.PostalCode = txtPostalCode.Text.ToString().Trim();
            objUsers.CountryId = Convert.ToInt32(drpCountry.SelectedItem.Value);

            if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "update")
            {
                int strUserid = Convert.ToInt32(ViewState["userId"]);
                objUsers.UserId = strUserid;
                DataTable dtuser = UserBL.GetUserByUserName(txtEmail.Text.ToString().Trim());
                if (dtuser.Rows.Count <= 0)
                {
                    res = UserBL.UpdateUser(objUsers);
                }
                else if (dtuser.Rows.Count > 0)
                {
                    int Count = 0;
                    for (int i = 0; i < dtuser.Rows.Count; i++)
                    {
                        if (dtuser.Rows[i]["Password"] != null && Convert.ToString(dtuser.Rows[i]["Password"]) == txtPassword.Text.ToString().Trim() && Convert.ToString(dtuser.Rows[i]["UserId"]) != strUserid.ToString().Trim())
                        {
                            Count++;
                        }
                    }
                    if (Count == 0)
                    {
                        res = UserBL.UpdateUser(objUsers);
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "This email / password combination you supplied belongs to another user, please try other combination.";
                        return;
                    }
                }
            }
            else
            {
                DataTable dtuser = UserBL.GetUserByUserName(txtEmail.Text.ToString().Trim());
                if (dtuser.Rows.Count <= 0)
                {
                    res = UserBL.InsertUser(objUsers);
                }
                else if (dtuser.Rows.Count > 0)
                {
                    if (dtuser.Rows[0]["Password"] != null && Convert.ToString(dtuser.Rows[0]["Password"]) == txtPassword.Text.ToString().Trim())
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "This email / password combination you supplied belongs to another user, please try other combination.";
                        return;
                    }
                    else if (dtuser.Rows[0]["Password"] != null && Convert.ToString(dtuser.Rows[0]["Password"]) != txtPassword.Text.ToString().Trim())
                    {
                        res = UserBL.InsertUser(objUsers);
                    }
                }
            }
            if (res)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "User Add / Update has been successfully done.";
                return;
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Sorry, please try again later.";
                return;
            }
        }
    }
}
