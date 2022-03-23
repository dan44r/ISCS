using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class AddEditWarehouseLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                BindDrpState();
                BindDrpCountry();
                if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
                {
                    BindValues();
                }
            }
        }
        protected void BindValues()
        {
            ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
            HiddenField hWHLocation = (HiddenField)contentPh.FindControl("hidWHLocationId");
            int whLocation = Convert.ToInt32(hWHLocation.Value);
            WarehouseLocationEL objEL = new WarehouseLocationEL();
            ViewState["whLocation"] = whLocation;
            objEL = BusinessLogicLayer.WarehouseLocationBL.SingleWarehouseLocation(whLocation);
            txtCompanyName.Text = objEL.CompanyName;
            txtAddress.Text = objEL.Address;
            txtCity.Text = objEL.City;
            drpState.Items.FindByValue(Convert.ToString(objEL.StateId)).Selected = true;
            txtPostalCode.Text = objEL.PostalCode;
            txtContactName.Text = objEL.ContactName;
            txtContactPhone.Text = objEL.ContactPhone;
            drpCountry.ClearSelection();
            drpCountry.Items.FindByValue(Convert.ToString(objEL.CountryId)).Selected = true;
            txtContactFax.Text = objEL.ContactFax;
            txtContactEmail.Text = objEL.ContactEmail;
            txtContactPhone.Text = objEL.ContactPhone;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WarehouseLocationEL whLocationEL = new WarehouseLocationEL();
            if (Session["cacheUserId"] != null)
            {
                whLocationEL.UserId = Convert.ToInt32(Session["cacheUserId"]);
            }
            whLocationEL.CompanyName = txtCompanyName.Text.ToString().Trim();
            whLocationEL.Address = txtAddress.Text.ToString().Trim();
            whLocationEL.City = txtCity.Text.ToString().Trim();
            whLocationEL.StateId = Convert.ToInt32(drpState.SelectedValue);
            whLocationEL.PostalCode = txtPostalCode.Text.ToString().Trim();
            whLocationEL.CountryId = Convert.ToInt32(drpCountry.SelectedValue);
            whLocationEL.ContactName = txtContactName.Text.ToString().Trim();
            whLocationEL.ContactPhone = txtContactPhone.Text.ToString().Trim();
            whLocationEL.ContactFax = txtContactFax.Text.ToString().Trim();
            whLocationEL.ContactEmail = txtContactEmail.Text.ToString().Trim();
            bool stat = false;
            if (ViewState["whLocation"] == null)
            {
                stat = WarehouseLocationBL.AddWarehouseLocation(whLocationEL);
                if (stat == true)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Warehouse location has been added successfully";
                }
            }
            else
            {
                whLocationEL.Id = Convert.ToInt32(ViewState["whLocation"].ToString());
                stat = BusinessLogicLayer.WarehouseLocationBL.UpdateWarehouseLocation(whLocationEL);
                if (stat == true)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Warehouse location has been updated successfully";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageWarehouseLocation.aspx");
        }
    }
}
