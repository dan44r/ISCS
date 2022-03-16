using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using EntityLayer;

namespace ISCS.Admin
{
    public partial class AddEditCarrier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                BindDrpState();
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
            HiddenField hfcarrierid = (HiddenField)contentPh.FindControl("hidFCarrierid");
            int strCarrierid = Convert.ToInt32(hfcarrierid.Value);

            ViewState["CarrierId"] = strCarrierid;

            DataTable dtCarrier = CarriersBL.GetCarrierByCarrierId(strCarrierid);
            txtCarrierName.Text = dtCarrier.Rows[0]["CarrierName"].ToString().Trim();
            txtAddress.Text = dtCarrier.Rows[0]["Address"].ToString().Trim();
            txtCity.Text = dtCarrier.Rows[0]["City"].ToString().Trim();
            drpState.SelectedValue = dtCarrier.Rows[0]["stateid"].ToString().Trim();
            txtPostalCode.Text = dtCarrier.Rows[0]["postalcode"].ToString().Trim();
            txtContactName.Text = dtCarrier.Rows[0]["ContactName"].ToString().Trim();
            txtContactPhone.Text = dtCarrier.Rows[0]["ContactPhone"].ToString().Trim();
            txtContactFax.Text = dtCarrier.Rows[0]["ContactFax"].ToString().Trim();
            txtEmail.Text = dtCarrier.Rows[0]["ContactEmail"].ToString().Trim();            
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

        protected void btnRetuen_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageCarrier.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Session["cacheUserId"] != null)
            {
                int userId = Convert.ToInt32(Session["cacheUserId"]);

                if (userId != 0)
                {
                    Boolean res = false;
                    Carriers objUsers = new Carriers();

                    objUsers.UserId = userId;
                    objUsers.CarrierName = txtCarrierName.Text.ToString().Trim();
                    objUsers.Address = txtAddress.Text.ToString().Trim();
                    objUsers.City = txtCity.Text.ToString().Trim();
                    objUsers.StateId = Convert.ToInt32(drpState.SelectedItem.Value);
                    objUsers.PostalCode = txtPostalCode.Text.ToString().Trim();
                    objUsers.ContactName = txtContactName.Text.ToString().Trim();
                    objUsers.ContactPhone = txtContactPhone.Text.ToString().Trim();

                    objUsers.ContactFax = txtContactFax.Text.ToString().Trim();
                    objUsers.ContactEmail = txtEmail.Text.ToString().Trim();


                    if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "update")
                    {
                        int strCarrierid = Convert.ToInt32(ViewState["CarrierId"]);
                        objUsers.Id = strCarrierid;
                        res = CarriersBL.UpdateCarrier(objUsers);
                    }
                    else
                    {
                        res = CarriersBL.InsertCarrier(objUsers);
                    }
                    if (res)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Carrier Add / Update has been successfully done.";
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Sorry, please try again later.";
                    }
                }
                else
                {
                    Response.Redirect(ResolveUrl("~/SecureLogin.aspx"));
                }
            }
            else
            {
                Response.Redirect(ResolveUrl("~/SecureLogin.aspx"));
            }
            
        }
    }
}
