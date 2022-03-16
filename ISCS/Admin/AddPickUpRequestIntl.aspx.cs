using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using CF.Web.Security;
using EntityLayer;

namespace ISCS.Admin
{
    public partial class AddPickUpRequestIntl : System.Web.UI.Page
    {
        public string strMainURL = ConfigurationManager.AppSettings["rootpath"].Trim();

        #region protected void Page_Load(object sender, EventArgs e)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cacheUserCode"] == null)
            {
                Response.Redirect(ResolveUrl("~/SecureLogin.aspx"));
            }            
            if (!IsPostBack)
            {
                lblSkidCount.Text = "0";
                ViewState["shppedwt"] = "0";
                ViewState["shipPiece"] = "0";         
                btnContinue.Visible = false;
                btnAccept.Visible = false;

                //Checking whether user is admin/superadmin or other type of user
                if (Session["cacheUserCode"].ToString() == "1000" || Session["cacheUserCode"].ToString() == "7000")
                {
                    lnkWarehouseDelivLoc.Visible = true;                    
                }
                else
                {
                    lnkWarehouseDelivLoc.Visible = false;
                    lblWAreHoseLocationId.Attributes.Add("Style", "display: none");
                    lblWAreHoseLocationIdText.Attributes.Add("Style", "display: none");                    
                }
                drpBillToCompany.Attributes.Add("onchange", "changeaddress(this)");
                BindControls();
                //Checking whether new request or edit request(if "id" exists then request is editing)
                if (Request.QueryString["id"] == null)
                {                    
                    txtBillToAddress.Text = "900 Rt. 134, Mailbox 535";
                    txtBillToCity.Text = "S. Dennis";
                    txtBillToState.Text = "Massachusetts";
                    txtBillToZip.Text = "02660";
                    txtBillToCountry.Text = "United States";
                    btnHUnit.Visible = false;
                    tblBillingInfo.Visible = false;
                    tblRequestedService.Visible = false;
                    tabInsuranceRequired.Visible = false;
                    tblShipmentCharges.Visible = false;
                    tblShipmentInfo.Visible = false;
                    tblSpecialServices.Visible = false;
                    cvalidSkids.Enabled = false;
                    if (Session["cacheUserCode"].ToString() != "1000" && Session["cacheUserCode"].ToString() != "7000")
                    {
                        FetchUserDetails();
                    }
                }
                else
                {
                    if (Session["cacheUserCode"].ToString() == "1000" || Session["cacheUserCode"].ToString() == "7000")
                    {
                        tblShipmentCharges.Visible = true;
                        tblShipmentInfo.Visible = true;
                        tblBillingInfo.Visible = true;
                    }
                    else
                    {
                        tblShipmentCharges.Visible = false;
                        tblShipmentInfo.Visible = false;
                        tblBillingInfo.Visible = false;
                        btnContinue.Text = "Submit";
                    }

                    btnContinue.Visible = true;
                    cvalidSkids.Enabled = true;
                    if (Request.QueryString["stat"] != null)
                    {
                        //Checking whether request to be edited is pending or non-pending
                        if (Request.QueryString["stat"].ToString() == "n")
                        {
                            btnAccept.Visible = false;
                            if (Session["cacheUserCode"].ToString() == "1000" || Session["cacheUserCode"].ToString() == "7000")
                            {
                                btnHUnit.Visible = true;
                            }
                            else
                            {
                                btnHUnit.Visible = false;
                            }
                        }
                        else
                        {
                            if (Session["cacheUserCode"].ToString() == "1000" || Session["cacheUserCode"].ToString() == "7000")
                            {
                                btnAccept.Visible = true;
                            }
                            else
                            {
                                btnAccept.Visible = false;
                            }
                            string strReqIDDecode1 = "";
                            if (Request.QueryString["id"] != null)
                            {
                                strReqIDDecode1 = SecurityUtils.UrlDecode(Convert.ToString(Request.QueryString["id"]));
                                LockPickupRequest(IsInteger(strReqIDDecode1), IsInteger(Convert.ToString(Session["cacheUserId"])), true);
                            }
                        }
                    }
                    //Old request id "pid" coming from AddShipAllItemsFromWarehouse
                    if (Request.QueryString["pid"] != null)
                    {
                        if (Session["cacheUserCode"].ToString() == "1000" || Session["cacheUserCode"].ToString() == "7000")
                        {
                            btnAccept.Visible = true;
                        }
                        else
                        {
                            btnAccept.Visible = false;
                        }
                    }     
                    string strReqIDDecode = SecurityUtils.UrlDecode(Convert.ToString(Request.QueryString["id"]));                    
                    ViewState["PickupReuestId"] = strReqIDDecode;
                    btnSave.Visible = false;                    
                    FetchShipments();
                    FetchSkids();
                    //new skid id coming from View or Ship Warehouse Items
                    if (Request.QueryString["skid"] == null)
                    {
                        FetchAllValues(strReqIDDecode);
                    }
                    else
                    {
                        FetchpickupLocationWh();
                        lnkPickLocation.Visible = false;
                        if (Request.QueryString["ChooseWHlist"] != null)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "skidpopwh", "OpenskidpopChooseWHlist(" + ViewState["PickupReuestId"].ToString() + "," + Request.QueryString["skid"].ToString() + ");", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "skidpopwh", "Openskidpopwh(" + ViewState["PickupReuestId"].ToString() + "," + Request.QueryString["skid"].ToString() + ");", true);
                        }
                    }
                }                
            }
            //if (Session["cacheUserCode"].ToString() == "1000" || Session["cacheUserCode"].ToString() == "7000")
            //{
            //    tblShipmentCharges.Visible = true;
            //    tblShipmentInfo.Visible = true;
            //    tblBillingInfo.Visible = true;

            //}
            //else
            //{
            //    tblShipmentCharges.Visible = false;
            //    tblShipmentInfo.Visible = false;
            //    tblBillingInfo.Visible = false;
            //    btnContinue.Text = "Submit";
            //}
            lblMsg.Text = "";
            lblSubMsg.Text = "";
            lblSubMsg.Visible = false;
            lblMsg.Visible = false;
            rbInternAir.InputAttributes["class"] = "redio";
            rbInternOcean.InputAttributes["class"] = "redio";
            rbISCSAdvantage.InputAttributes["class"] = "redio";
            chkPartyTransaction.InputAttributes["class"] = "redio";
            btnloadskids.Attributes.Add("onclick", "javascript:CallMe();");
            drpInternAirTypeService1.Attributes.Add("disabled", "true");
            drpInternAirTypeService2.Attributes.Add("disabled", "true");
            drpInternOceanTypeService1.Attributes.Add("disabled", "true");
            drpInternOceanTypeService2.Attributes.Add("disabled", "true");
            rbInternAir.Attributes.Add("onclick", "EnableModeOfTransport('rbInternAir');");
            rbInternOcean.Attributes.Add("onclick", "EnableModeOfTransport('rbInternOcean');");

            
            if (drpBillToCompany.SelectedItem.Text.Trim().ToLower().IndexOf("3pl") != -1)
            {
               
                txtBillToAddress.Text = "900 Route 134, Ste 2-17";
                txtBillToCity.Text = "S. Dennis";
                txtBillToState.Text = "Massachusetts";
                txtBillToZip.Text = "02660";
                txtBillToCountry.Text = "United States";
            }
            else if (drpBillToCompany.SelectedItem.Text.Trim().ToLower().IndexOf("quad") != -1)
            {
                //txtBillToAddress.Text = "1000 Remington Blvd., Ste 300";
                //txtBillToCity.Text = "Bolingbrook";
                //txtBillToState.Text = "Illinois";
                //txtBillToZip.Text = "60440";
                //txtBillToCountry.Text = "United States";
                txtBillToAddress.Text = "1415 W.Diehl Rd, Ste 300S";
                txtBillToCity.Text = "Naperville";
                txtBillToState.Text = "Illinois";
                txtBillToZip.Text = "60563";
                txtBillToCountry.Text = "United States";
            }
        }
        #endregion

        #region protected void BindControls()
        protected void BindControls()
        {
            DataSet dsStates = StatesBL.FetchAllStates();
            drpFromState.DataSource = dsStates.Tables[0];
            drpFromState.DataValueField = "StateId";
            drpFromState.DataTextField = "Name";
            drpFromState.DataBind();
            ListItem lstItem = new ListItem("--Select--", "0");
            drpFromState.Items.Insert(0, lstItem);            

            DataSet dsCountries = CountriesBL.FetchAllCountries();
            drpFromCountry.DataSource = dsCountries.Tables[0];
            //drpFromCountry.DataValueField = "SelectedIndex";
            drpFromCountry.DataValueField = "CountryId";
            drpFromCountry.DataTextField = "Name";
            drpFromCountry.DataBind();            
            drpFromCountry.Items.Insert(0, lstItem);
            for (int i = 0; i < drpFromCountry.Items.Count; i++)
            {
                if (drpFromCountry.Items[i].Text.Trim().ToUpper() == "UNITED STATES")
                {
                    drpFromCountry.ClearSelection();
                    drpFromCountry.Items[i].Selected = true;
                }
            }

            drpToCountry.DataSource = dsCountries.Tables[0];
            //drpToCountry.DataValueField = "SelectedIndex";
            drpToCountry.DataValueField = "CountryId";
            drpToCountry.DataTextField = "Name";
            drpToCountry.DataBind();
            drpToCountry.Items.Insert(0, lstItem);
            for (int i = 0; i < drpToCountry.Items.Count; i++)
            {
                if (drpToCountry.Items[i].Text.Trim().ToUpper() == "UNITED STATES")
                {
                    drpToCountry.ClearSelection();
                    drpToCountry.Items[i].Selected = true;
                }
            }

            drpCountry.DataSource = dsCountries.Tables[0];
            //drpCountry.DataValueField = "SelectedIndex";
            drpCountry.DataValueField = "CountryId";
            drpCountry.DataTextField = "Name";
            drpCountry.DataBind();
            drpCountry.Items.Insert(0, lstItem);
            for (int i = 0; i < drpCountry.Items.Count; i++)
            {
                if (drpCountry.Items[i].Text.Trim().ToUpper() == "UNITED STATES")
                {
                    drpCountry.ClearSelection();
                    drpCountry.Items[i].Selected = true;
                }
            }            

            drpReadyTime.Items.Add(new ListItem("--Select--", "0"));
            drpLatestPickup.Items.Add(new ListItem("--Select--", "0"));

            drpReadyTime.Items.Add(new ListItem("12:00 AM", "12:00 AM"));
            drpReadyTime.Items.Add(new ListItem("12:30 AM", "12:30 AM"));
            drpLatestPickup.Items.Add(new ListItem("12:00 AM", "12:00 AM"));
            drpLatestPickup.Items.Add(new ListItem("12:30 AM", "12:30 AM"));
            for (int i = 1; i <= 11; i++)
            {
                drpReadyTime.Items.Add(new ListItem(i.ToString() + ":00 AM", i.ToString() + ":00 AM"));
                drpReadyTime.Items.Add(new ListItem(i.ToString() + ":30 AM", i.ToString() + ":30 AM"));
                drpLatestPickup.Items.Add(new ListItem(i.ToString() + ":00 AM", i.ToString() + ":00 AM"));
                drpLatestPickup.Items.Add(new ListItem(i.ToString() + ":30 AM", i.ToString() + ":30 AM"));
            }
            drpReadyTime.Items.Add(new ListItem("12:00 PM", "12:00 PM"));
            drpReadyTime.Items.Add(new ListItem("12:30 PM", "12:30 PM"));
            drpLatestPickup.Items.Add(new ListItem("12:00 PM", "12:00 PM"));
            drpLatestPickup.Items.Add(new ListItem("12:30 PM", "12:30 PM"));
            for (int i = 1; i <= 11; i++)
            {
                drpReadyTime.Items.Add(new ListItem(i.ToString() + ":00 PM", i.ToString() + ":00 PM"));
                drpReadyTime.Items.Add(new ListItem(i.ToString() + ":30 PM", i.ToString() + ":30 PM"));
                drpLatestPickup.Items.Add(new ListItem(i.ToString() + ":00 PM", i.ToString() + ":00 PM"));
                drpLatestPickup.Items.Add(new ListItem(i.ToString() + ":30 PM", i.ToString() + ":30 PM"));
            }
            drpAccountCode.DataSource = AccountCodesBL.FetchAllAccountCodesWithMargins();
            drpAccountCode.DataTextField = "Value";
            drpAccountCode.DataValueField = "Id";
            drpAccountCode.DataBind();
            drpAccountCode.Items.Insert(0, new ListItem("--Select--", "0"));
            
            drpInternAirTypeService1.Items.Add(new ListItem("--Select--", "0"));
            drpInternAirTypeService1.Items.Add(new ListItem("Economy", "Economy"));
            drpInternAirTypeService1.Items.Add(new ListItem("Expedited", "Expedited"));

            drpInternAirTypeService2.Items.Add(new ListItem("--Select--", "0"));
            drpInternAirTypeService2.Items.Add(new ListItem("DTD (Door to Door)", "DTD"));
            drpInternAirTypeService2.Items.Add(new ListItem("DTA (Door to Airport)", "DTA"));
            drpInternAirTypeService2.Items.Add(new ListItem("ATA (Airport to Airport)", "ATA"));
            drpInternAirTypeService2.Items.Add(new ListItem("ATD (Airport to Door)", "ATD"));

            drpInternOceanTypeService1.Items.Add(new ListItem("--Select--", "0"));
            drpInternOceanTypeService1.Items.Add(new ListItem("LCL (Less than Container Load)", "LCL"));
            drpInternOceanTypeService1.Items.Add(new ListItem("FCL (Full Container Load 20 Ft)", "FCL 20"));
            drpInternOceanTypeService1.Items.Add(new ListItem("FCL (Full Container Load 20 Ft HQ)", "FCL 20 HQ"));
            drpInternOceanTypeService1.Items.Add(new ListItem("FCL (Full Container Load 40 Ft)", "FCL 40"));
            drpInternOceanTypeService1.Items.Add(new ListItem("FCL (Full Container Load 40 Ft HQ)", "FCL 40 HQ"));
            drpInternOceanTypeService1.Items.Add(new ListItem("Other", "Other"));

            drpInternOceanTypeService2.Items.Add(new ListItem("--Select--", "0"));
            drpInternOceanTypeService2.Items.Add(new ListItem("DTD (Door to Door)", "DTD"));
            drpInternOceanTypeService2.Items.Add(new ListItem("DTP (Door to Port)", "DTP"));
            drpInternOceanTypeService2.Items.Add(new ListItem("PTP (Port to Port)", "PTP"));
            drpInternOceanTypeService2.Items.Add(new ListItem("ATD (Port to Door)", "PTD"));
           
            drpPaymentMethod.Items.Add("Other");
            drpPaymentMethod.Items.Add("Prepaid");
            drpPaymentMethod.Items.Add("Collect");
            drpPaymentMethod.Items.Add("Collect");

            
            drpBillToCompany.Items.Add("3PL Integration");
            //drpBillToCompany.Items.Add("QWE Logistics, Inc.");
            drpBillToCompany.Items.Add("Quad Express");
        }
        #endregion

        #region protected void FetchAllValues(string strRequestId)
        protected void FetchAllValues(string strRequestId)
        {            
            int intPickupreqid = Convert.ToInt32(strRequestId);
            DataSet ds = PickupRequestBL.FetchSinglePickupRequest(intPickupreqid);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0].IsNull("ShipFromLocationId") == false && ds.Tables[0].Rows[0]["ShipFromLocationId"].ToString() != "" && ds.Tables[0].Rows[0]["ShipFromLocationId"].ToString() != "0")
                {
                    hidFromLocationid.Value = ds.Tables[0].Rows[0]["ShipFromLocationId"].ToString();
                }
                else
                {
                    hidFromLocationid.Value = "0";
                }

                txtShipFromCompany.Text = ds.Tables[0].Rows[0]["ShipFromCompany"].ToString();
                txtShipperRefNo.Text = ds.Tables[0].Rows[0]["ShipFromRefNumber"].ToString();
                txtFromAddress.Text = ds.Tables[0].Rows[0]["ShipFromAddress"].ToString();
                txtFromCity.Text = ds.Tables[0].Rows[0]["ShipFromCity"].ToString();
                if (ds.Tables[0].Rows[0].IsNull("ShipFromState") == false && ds.Tables[0].Rows[0]["ShipFromState"].ToString() != "" && ds.Tables[0].Rows[0]["ShipFromState"].ToString() != "0")
                {
                    for (int i = 0; i < drpFromState.Items.Count; i++)
                    {
                        if (drpFromState.Items[i].Text == ds.Tables[0].Rows[0]["ShipFromState"].ToString())
                        {
                            drpFromState.ClearSelection();
                            drpFromState.Items[i].Selected = true;
                        }
                    }
                }

                txtFromPostalCode.Text = ds.Tables[0].Rows[0]["ShipFromPostalCode"].ToString();
                if (ds.Tables[0].Rows[0].IsNull("ShipFromCountry") == false && ds.Tables[0].Rows[0]["ShipFromCountry"].ToString() != "" && ds.Tables[0].Rows[0]["ShipFromCountry"].ToString() != "0")
                {
                    for (int i = 0; i < drpFromCountry.Items.Count; i++)
                    {
                        if (drpFromCountry.Items[i].Text == ds.Tables[0].Rows[0]["ShipFromCountry"].ToString())
                        {
                            drpFromCountry.ClearSelection();
                            drpFromCountry.Items[i].Selected = true;
                        }
                    }
                }

                txtFromContact.Text = ds.Tables[0].Rows[0]["ShipFromContact"].ToString();
                txtFromPhone.Text = ds.Tables[0].Rows[0]["ShipFromPhone"].ToString();
                txtFromFax.Text = ds.Tables[0].Rows[0]["ShipFromFax"].ToString();
                txtFromEmail.Text = ds.Tables[0].Rows[0]["ShipFromEmail"].ToString();
                txtPickUpDate.Text = IsDatetime(ds.Tables[0].Rows[0]["ShipFromDate"].ToString()).ToString("d");

                if (ds.Tables[0].Rows[0].IsNull("ShipFromTimeReady") == false && ds.Tables[0].Rows[0]["ShipFromTimeReady"].ToString() != "" && ds.Tables[0].Rows[0]["ShipFromTimeReady"].ToString() != "0")
                {
                    for (int i = 0; i < drpReadyTime.Items.Count; i++)
                    {
                        if (drpReadyTime.Items[i].Text == ds.Tables[0].Rows[0]["ShipFromTimeReady"].ToString())
                        {
                            drpReadyTime.ClearSelection();
                            drpReadyTime.Items[i].Selected = true;
                        }
                    }
                }

                if (ds.Tables[0].Rows[0].IsNull("ShipFromTimeNLT") == false && ds.Tables[0].Rows[0]["ShipFromTimeNLT"].ToString() != "" && ds.Tables[0].Rows[0]["ShipFromTimeNLT"].ToString() != "0")
                {
                    for (int i = 0; i < drpLatestPickup.Items.Count; i++)
                    {
                        if (drpLatestPickup.Items[i].Text == ds.Tables[0].Rows[0]["ShipFromTimeNLT"].ToString())
                        {
                            drpLatestPickup.ClearSelection();
                            drpLatestPickup.Items[i].Selected = true;
                        }
                    }
                }

                txtExporterEIN.Text = ds.Tables[0].Rows[0]["ExportEIN"].ToString();
                txtShipToCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ShipToCompany"]).ToString().Replace("–", "-");
                txtConsigneeRefNo.Text = ds.Tables[0].Rows[0]["ShipToConsigneeRefNumber"].ToString();
                txtToAddress.Text = ds.Tables[0].Rows[0]["ShipToAddress"].ToString();
                txtToCity.Text = ds.Tables[0].Rows[0]["ShipToCity"].ToString();
                if (ds.Tables[0].Rows[0].IsNull("PartiesToTransaction") == false && ds.Tables[0].Rows[0]["PartiesToTransaction"].ToString() != "" && ds.Tables[0].Rows[0]["PartiesToTransaction"].ToString() != "0")
                {
                    if (ds.Tables[0].Rows[0]["PartiesToTransaction"].ToString() == "1")
                    {
                        chkPartyTransaction.Checked = true;
                    }
                }                

                if (ds.Tables[0].Rows[0].IsNull("ShipToLocationId") == false)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["ShipToLocationId"]) == 0)
                    {
                        HidWarehouseid.Value = "0";
                        lblWAreHoseLocationId.Text = "0";
                    }
                    else
                    {
                        HidWarehouseid.Value = Convert.ToString(ds.Tables[0].Rows[0]["ShipToLocationId"]);
                        lblWAreHoseLocationId.Text = Convert.ToString(ds.Tables[0].Rows[0]["ShipToLocationId"]);
                    }
                }
                else
                {
                    HidWarehouseid.Value = "0";
                    lblWAreHoseLocationId.Text = "0";
                }

                txtToPostalCode.Text = ds.Tables[0].Rows[0]["ShipToPostalCode"].ToString();
                for (int i = 0; i < drpToCountry.Items.Count; i++)
                {
                    if (drpToCountry.Items[i].Text == ds.Tables[0].Rows[0]["ShipToCountry"].ToString())
                    {
                        drpToCountry.ClearSelection();
                        drpToCountry.Items[i].Selected = true;
                    }
                }

                txtToContact.Text = ds.Tables[0].Rows[0]["ShipToContact"].ToString();
                txtToPhone.Text = ds.Tables[0].Rows[0]["ShipToPhone"].ToString();
                txtToFax.Text = ds.Tables[0].Rows[0]["ShipToFax"].ToString();                
                txtDeliveryDate.Text = IsDatetime(ds.Tables[0].Rows[0]["ShipToDate"].ToString()).ToString("d");
                txtIntermediateConsignee.Text = ds.Tables[0].Rows[0]["ExportIntermediateConsignee"].ToString();
                txtContactName.Text = ds.Tables[0].Rows[0]["ExportIntermediateContact"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["ExportAddress"].ToString();
                txtTelephone.Text = ds.Tables[0].Rows[0]["ExportIntermediatePhone"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["ExportCity"].ToString();
                txtPostalCode.Text = ds.Tables[0].Rows[0]["ExportPostalCode"].ToString();
                txtValidLicenseNo.Text = ds.Tables[0].Rows[0]["ExportLicence"].ToString();
                txtECCN.Text = ds.Tables[0].Rows[0]["ExportECCN"].ToString();

                if (ds.Tables[0].Rows[0].IsNull("ExportCountry") == false && ds.Tables[0].Rows[0]["ExportCountry"].ToString() != "")
                {
                    //drpCountry.ClearSelection();
                    //drpCountry.Items.FindByText(ds.Tables[0].Rows[0]["ExportCountry"].ToString()).Selected = true;
                    for (int i = 0; i < drpCountry.Items.Count; i++)
                    {
                        if (drpCountry.Items[i].Text.Trim() == ds.Tables[0].Rows[0]["ExportCountry"].ToString().Trim())
                        {
                            drpCountry.ClearSelection();
                            drpCountry.Items[i].Selected = true;
                        }
                    }
                }
                
                if (ds.Tables[0].Rows[0].IsNull("TransMode") == false)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["TransMode"]) == 3)
                    {
                        rbISCSAdvantage.Checked = false;
                        rbInternAir.Checked = true;
                        if (ds.Tables[0].Rows[0].IsNull("TransModeService1") == false)
                        {
                            for (int i = 0; i < drpInternAirTypeService1.Items.Count; i++)
                            {
                                if (drpInternAirTypeService1.Items[i].Value == ds.Tables[0].Rows[0]["TransModeService1"].ToString())
                                {
                                    drpInternAirTypeService1.ClearSelection();
                                    drpInternAirTypeService1.Items[i].Selected = true;
                                }
                            }
                        }

                        if (ds.Tables[0].Rows[0].IsNull("TransModeService2") == false)
                        {
                            for (int i = 0; i < drpInternAirTypeService2.Items.Count; i++)
                            {
                                if (drpInternAirTypeService2.Items[i].Value == ds.Tables[0].Rows[0]["TransModeService2"].ToString())
                                {
                                    drpInternAirTypeService2.ClearSelection();
                                    drpInternAirTypeService2.Items[i].Selected = true;
                                }
                            }
                        }
                    }
                    else if (Convert.ToInt32(ds.Tables[0].Rows[0]["TransMode"]) == 4)
                    {
                        rbISCSAdvantage.Checked = false;
                        rbInternOcean.Checked = true;
                        if (ds.Tables[0].Rows[0].IsNull("TransModeService1") == false)
                        {
                            for (int i = 0; i < drpInternOceanTypeService1.Items.Count; i++)
                            {
                                if (drpInternOceanTypeService1.Items[i].Value == ds.Tables[0].Rows[0]["TransModeService1"].ToString())
                                {
                                    drpInternOceanTypeService1.ClearSelection();
                                    drpInternOceanTypeService1.Items[i].Selected = true;
                                }
                            }
                        }

                        if (ds.Tables[0].Rows[0].IsNull("TransModeService2") == false)
                        {
                            for (int i = 0; i < drpInternOceanTypeService2.Items.Count; i++)
                            {
                                if (drpInternOceanTypeService2.Items[i].Value == ds.Tables[0].Rows[0]["TransModeService2"].ToString())
                                {
                                    drpInternOceanTypeService2.ClearSelection();
                                    drpInternOceanTypeService2.Items[i].Selected = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        rbISCSAdvantage.Checked = true;
                    }
                }
                else
                {
                    rbISCSAdvantage.Checked = true;
                }
                if (ds.Tables[0].Rows[0].IsNull("InsuredValue") == false && ds.Tables[0].Rows[0]["InsuredValue"].ToString() != "")
                {
                    txtInsuredValue.Text = ds.Tables[0].Rows[0]["InsuredValue"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("InsuranceRequired") == false && ds.Tables[0].Rows[0]["InsuranceRequired"].ToString() != "")
                {
                    for (int i = 0; i < rbInsuranceRequired.Items.Count; i++)
                    {
                        if (rbInsuranceRequired.Items[i].Value == ds.Tables[0].Rows[0]["InsuranceRequired"].ToString())
                        {
                            rbInsuranceRequired.ClearSelection();
                            rbInsuranceRequired.Items[i].Selected = true;
                        }
                    }
                }

                if (ds.Tables[0].Rows[0].IsNull("SpecialServiceCodes") == false && ds.Tables[0].Rows[0]["SpecialServiceCodes"].ToString() != "")
                {
                    string[] arrTsService = null;                    
                    arrTsService = ds.Tables[0].Rows[0]["SpecialServiceCodes"].ToString().Split('|');
                    if (arrTsService.Length > 0)
                    {
                        for (int i = 0; i < arrTsService.Length; i++)
                        {
                            for (int j = 0; j < chkLLiftGate.Items.Count; j++)
                            {
                                if (chkLLiftGate.Items[j].Value == arrTsService[i].ToString())
                                {
                                    chkLLiftGate.Items[j].Selected = true;
                                }
                            }

                            for (int j = 0; j < chkLPalletJack.Items.Count; j++)
                            {
                                if (chkLPalletJack.Items[j].Value == arrTsService[i].ToString())
                                {
                                    chkLPalletJack.Items[j].Selected = true;
                                }
                            }

                            for (int j = 0; j < chkLLocatedInside.Items.Count; j++)
                            {
                                if (chkLLocatedInside.Items[j].Value == arrTsService[i].ToString())
                                {
                                    chkLLocatedInside.Items[j].Selected = true;
                                }
                            }

                            for (int j = 0; j < chkLSaturdayService.Items.Count; j++)
                            {
                                if (chkLSaturdayService.Items[j].Value == arrTsService[i].ToString())
                                {
                                    chkLSaturdayService.Items[j].Selected = true;
                                }
                            }

                            for (int j = 0; j < chkLConvention.Items.Count; j++)
                            {
                                if (chkLConvention.Items[j].Value == arrTsService[i].ToString())
                                {
                                    chkLConvention.Items[j].Selected = true;
                                }
                            }

                            for (int j = 0; j < chkLResidentialLocation.Items.Count; j++)
                            {
                                if (chkLResidentialLocation.Items[j].Value == arrTsService[i].ToString())
                                {
                                    chkLResidentialLocation.Items[j].Selected = true;
                                }
                            }
                        }
                    }
                }

                if (ds.Tables[0].Rows[0].IsNull("SpecialInstructions") == false)
                {
                    txtareaSpecialInTructions.Value = ds.Tables[0].Rows[0]["SpecialInstructions"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("ShippersInstructions") == false)
                {
                    txtareaShippersInstructions.Value = ds.Tables[0].Rows[0]["ShippersInstructions"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("DocumentsEnclosed") == false)
                {
                    txtareaDocumentEnclosed.Value = ds.Tables[0].Rows[0]["DocumentsEnclosed"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("ExportLoadingPort") == false)
                {
                    txtPortAirExport.Text = ds.Tables[0].Rows[0]["ExportLoadingPort"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("ExportContanerized") == false && ds.Tables[0].Rows[0]["ExportContanerized"].ToString() != "")
                {
                    for (int i = 0; i < rblistContainerized.Items.Count; i++)
                    {
                        if (rblistContainerized.Items[i].Value == ds.Tables[0].Rows[0]["ExportContanerized"].ToString())
                        {
                            rblistContainerized.ClearSelection();
                            rblistContainerized.Items[i].Selected = true;
                        }
                    }
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSAccountId") == false && ds.Tables[0].Rows[0]["GLSAccountId"].ToString() != "")
                {
                    for (int i = 0; i < drpAccountCode.Items.Count; i++)
                    {
                        if (drpAccountCode.Items[i].Value == ds.Tables[0].Rows[0]["GLSAccountId"].ToString())
                        {
                            drpAccountCode.ClearSelection();
                            drpAccountCode.Items[i].Selected = true;
                        }
                    }
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSKnownShipper") == false)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["GLSKnownShipper"]) == 1)
                    {
                        chkShipmentInfo.Items[0].Selected = true;
                    }
                    else
                    {
                        chkShipmentInfo.Items[0].Selected = false;
                    }
                }
                else
                {
                    chkShipmentInfo.Items[0].Selected = false;
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSShippedWeight") == false)
                {
                    txtShippedWeight.Text = ds.Tables[0].Rows[0]["GLSShippedWeight"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSCarrierName") == false)
                {
                    txtPickupCarrier.Text = ds.Tables[0].Rows[0]["GLSCarrierName"].ToString();
                    hdCarrierID.Value = ds.Tables[0].Rows[0]["GLSCarrierId"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSCarrierNameInterm") == false)
                {
                    txtIntermediateCarrier.Text = ds.Tables[0].Rows[0]["GLSCarrierNameInterm"].ToString();
                    hdIntermediateCarrierID.Value = ds.Tables[0].Rows[0]["GLSCarrierIdInterm"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSCarrierNameDelivery") == false)
                {
                    txtDeliveryCarrier.Text = ds.Tables[0].Rows[0]["GLSCarrierNameDelivery"].ToString();
                    hdDeliveryCarrierID.Value = ds.Tables[0].Rows[0]["GLSCarrierIdDelivery"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSCarrierNameOther") == false)
                {
                    txtOtherCarrier.Text = ds.Tables[0].Rows[0]["GLSCarrierNameOther"].ToString();
                    hdOtherCarrierID.Value = ds.Tables[0].Rows[0]["GLSCarrierIdOther"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("Margin") == false)
                {
                    txtMargin.Text = ds.Tables[0].Rows[0]["Margin"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateTransportCharge") == false)
                {
                    txtTransportCost1.Text = ds.Tables[0].Rows[0]["GLSBuyRateTransportCharge"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateTransportChargeInterm") == false)
                {
                    txtTransportCost2.Text = ds.Tables[0].Rows[0]["GLSBuyRateTransportChargeInterm"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateTransportChargeDelivery") == false)
                {
                    txtTransportCost3.Text = ds.Tables[0].Rows[0]["GLSBuyRateTransportChargeDelivery"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateTransportChargeOther") == false)
                {
                    txtTransportCost4.Text = ds.Tables[0].Rows[0]["GLSBuyRateTransportChargeOther"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSSellRateTransportCharge") == false)
                {
                    txtTransport.Text = ds.Tables[0].Rows[0]["GLSSellRateTransportCharge"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateAccessorialCharge") == false)
                {
                    txtAccessorialCost1.Text = ds.Tables[0].Rows[0]["GLSBuyRateAccessorialCharge"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateAccessorialChargeInterm") == false)
                {
                    txtAccessorialCost2.Text = ds.Tables[0].Rows[0]["GLSBuyRateAccessorialChargeInterm"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateAccessorialChargeDelivery") == false)
                {
                    txtAccessorialCost3.Text = ds.Tables[0].Rows[0]["GLSBuyRateAccessorialChargeDelivery"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateAccessorialChargeOther") == false)
                {
                    txtAccessorialCost4.Text = ds.Tables[0].Rows[0]["GLSBuyRateAccessorialChargeOther"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSSellRateAccessorialCharge") == false)
                {
                    txtAccessorial.Text = ds.Tables[0].Rows[0]["GLSSellRateAccessorialCharge"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateFuelCharge") == false)
                {
                    txtFuelSurcharge1.Text = ds.Tables[0].Rows[0]["GLSBuyRateFuelCharge"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateFuelChargeInterm") == false)
                {
                    txtFuelSurcharge2.Text = ds.Tables[0].Rows[0]["GLSBuyRateFuelChargeInterm"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateFuelChargeDelivery") == false)
                {
                    txtFuelSurcharge3.Text = ds.Tables[0].Rows[0]["GLSBuyRateFuelChargeDelivery"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateFuelChargeOther") == false)
                {
                    txtFuelSurcharge4.Text = ds.Tables[0].Rows[0]["GLSBuyRateFuelChargeOther"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSSellRateFuelCharge") == false)
                {
                    txtFuelSurcharge.Text = ds.Tables[0].Rows[0]["GLSSellRateFuelCharge"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateBrokerage") == false)
                {
                    txtBuyBrokerage.Text = ds.Tables[0].Rows[0]["GLSBuyRateBrokerage"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateDuty") == false)
                {
                    txtBuyDuty.Text = ds.Tables[0].Rows[0]["GLSBuyRateDuty"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("GLSSellRateDuty") == false)
                {
                    txtSellDuty.Text = ds.Tables[0].Rows[0]["GLSSellRateDuty"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSSellRateBrokerage") == false)
                {
                    txtSellBrokerage.Text = ds.Tables[0].Rows[0]["GLSSellRateBrokerage"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSInsured") == false)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["GLSInsured"]) == 1)
                    {
                        rblInsured.Items[1].Selected = false;
                        rblInsured.Items[0].Selected = true;
                    }
                    else
                    {
                        rblInsured.Items[0].Selected = false;
                        rblInsured.Items[1].Selected = true;
                    }
                }
                else
                {
                    rblInsured.Items[0].Selected = false;
                    rblInsured.Items[1].Selected = true;
                }
                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateInsuraceCharge") == false)
                {
                    txtInsurance1.Text = ds.Tables[0].Rows[0]["GLSBuyRateInsuraceCharge"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("GLSSellRateInsuraceCharge") == false)
                {
                    txtInsurance.Text = ds.Tables[0].Rows[0]["GLSSellRateInsuraceCharge"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("GLSBuyRateCodFee") == false)
                {
                    txtCodFee1.Text = ds.Tables[0].Rows[0]["GLSBuyRateCodFee"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("GLSSellRateCodFee") == false)
                {
                    txtCodFee.Text = ds.Tables[0].Rows[0]["GLSSellRateCodFee"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("GLSTotalBuyRate") == false)
                {
                    txtTotal1.Text = ds.Tables[0].Rows[0]["GLSTotalBuyRate"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("GLSTotalSellRate") == false)
                {
                    txtTotal.Text = ds.Tables[0].Rows[0]["GLSTotalSellRate"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSPaymentMethod") == false)
                {
                    for (int i = 0; i < drpPaymentMethod.Items.Count; i++)
                    {
                        if (drpPaymentMethod.Items[i].Value == ds.Tables[0].Rows[0]["GLSPaymentMethod"].ToString())
                        {
                            drpPaymentMethod.ClearSelection();
                            drpPaymentMethod.Items[i].Selected = true;
                        }
                    }
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSCertifiedCheck") == false)
                {
                    for (int i = 0; i < rbCertifiedCheck.Items.Count; i++)
                    {
                        if (rbCertifiedCheck.Items[i].Text == ds.Tables[0].Rows[0]["GLSCertifiedCheck"].ToString())
                        {
                            rbCertifiedCheck.ClearSelection();
                            rbCertifiedCheck.Items[i].Selected = true;
                        }
                    }
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBillCompany") == false && ds.Tables[0].Rows[0]["GLSBillCompany"].ToString() != "")
                {
                    for (int i = 0; i < drpBillToCompany.Items.Count; i++)
                    {
                        if (drpBillToCompany.Items[i].Text == ds.Tables[0].Rows[0]["GLSBillCompany"].ToString())
                        {
                            drpBillToCompany.ClearSelection();
                            drpBillToCompany.Items[i].Selected = true;
                        }
                    }                    
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBillAddress") == false)
                {
                    txtBillToAddress.Text = ds.Tables[0].Rows[0]["GLSBillAddress"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBillCity") == false)
                {
                    txtBillToCity.Text = ds.Tables[0].Rows[0]["GLSBillCity"].ToString();
                }

                if (ds.Tables[0].Rows[0].IsNull("GLSBillStateName") == false && ds.Tables[0].Rows[0]["GLSBillStateName"].ToString() != "" && ds.Tables[0].Rows[0]["GLSBillStateName"].ToString() != "0")
                {
                    txtBillToState.Text = ds.Tables[0].Rows[0]["GLSBillStateName"].ToString();
                }                

                if (ds.Tables[0].Rows[0].IsNull("GLSBillPostalCode") == false)
                {
                    txtBillToZip.Text = ds.Tables[0].Rows[0]["GLSBillPostalCode"].ToString();
                }
                if (ds.Tables[0].Rows[0].IsNull("GLSBillCountryName") == false && ds.Tables[0].Rows[0]["GLSBillCountryName"].ToString() != "" && ds.Tables[0].Rows[0]["GLSBillCountryName"].ToString() != "0")
                {
                    txtBillToCountry.Text = ds.Tables[0].Rows[0]["GLSBillCountryName"].ToString();
                }                

                if (ds.Tables[0].Rows[0].IsNull("GLSNotes") == false)
                {
                    txtareaNotes.Value = ds.Tables[0].Rows[0]["GLSNotes"].ToString();
                }
            }
        }
        #endregion

        #region protected void FetchShipments()
        protected void FetchShipments()
        {
            if (ViewState["PickupReuestId"] != null)
            {                
                DataSet ds = ShipmentItemsBL.FetchShipmentUnit(IsInteger(ViewState["PickupReuestId"].ToString()));
                gridShipments.DataSource = ds;
                gridShipments.DataBind();
                if (ds.Tables.Count > 0)
                {
                    tblShipmentItems.Visible = true;
                }
                else
                {
                    tblShipmentItems.Visible = false;
                }
                if (Request.QueryString["stat"] != null)
                {
                    if (Request.QueryString["stat"].ToString() == "n")
                    {
                        if (Session["cacheUserCode"].ToString() == "1000" || Session["cacheUserCode"].ToString() == "7000")
                        {
                            gridShipments.Columns[gridShipments.Columns.Count - 1].Visible = true;
                        }
                        else
                        {
                            gridShipments.Columns[gridShipments.Columns.Count - 1].Visible = false;
                        }
                    }
                }
            }
        }
        #endregion

        #region protected void FetchSkids()
        protected void FetchSkids()
        {
            if (ViewState["PickupReuestId"] != null)
            {                
                DataSet ds = HandlingUnitBL.FetchHandlingUnit(IsInteger(ViewState["PickupReuestId"].ToString()), 1);
                ViewState["cubicweight"] = null;
                int cubicwt = 0;
                gridHandlingUnits.DataSource = ds;
                gridHandlingUnits.DataBind();
                if (ds.Tables.Count > 0)
                {
                    tblHandlingdetails.Visible = true;
                    lblSkidCount.Text = ds.Tables[0].Rows.Count.ToString();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        cubicwt = cubicwt + Convert.ToInt32(ds.Tables[0].Rows[i]["SkidCubicWeight"]);
                    }
                }
                else
                {
                    tblHandlingdetails.Visible = false;
                    lblSkidCount.Text = "0";
                }
                ViewState["cubicweight"] = cubicwt;
                if (ViewState["shppedwt"].ToString() != "")
                {
                    txtShippedWeight.Text = ViewState["shppedwt"].ToString();
                }
                if (Request.QueryString["stat"] != null)
                {
                    if (Request.QueryString["stat"].ToString() == "n")
                    {
                        if (Session["cacheUserCode"].ToString() == "1000" || Session["cacheUserCode"].ToString() == "7000")
                        {
                            gridHandlingUnits.Columns[gridHandlingUnits.Columns.Count - 1].Visible = true;
                        }
                        else
                        {
                            gridHandlingUnits.Columns[gridHandlingUnits.Columns.Count - 1].Visible = false;
                        }
                    }
                }
            }
        }
        #endregion

        #region private int IsInteger(string InputValue)
        private int IsInteger(string InputValue)
        {
            int OutputValue = 0;
            try { OutputValue = Convert.ToInt32(InputValue.Trim()); }
            catch { }
            return OutputValue;
        }
        #endregion

        #region private decimal IsDecimal(string InputValue)
        private decimal IsDecimal(string InputValue)
        {
            decimal OutputValue = 0;
            try { OutputValue = Convert.ToDecimal(InputValue.Trim()); }
            catch { }
            return OutputValue;
        }
        #endregion

        #region private double IsDouble(string InputValue)
        private double IsDouble(string InputValue)
        {
            double OutputValue = 0.00;
            try { OutputValue = Convert.ToDouble(InputValue.Trim()); }
            catch { }
            return OutputValue;
        }
        #endregion

        #region private DateTime IsDatetime(string InputValue)
        private DateTime IsDatetime(string InputValue)
        {
            DateTime OutputValue = new DateTime();
            try { OutputValue = Convert.ToDateTime(InputValue.Trim()); }
            catch { }
            return OutputValue;
        }
        #endregion

        #region protected void btnContinue_Click(object sender, EventArgs e)
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (CommonBL.isDate(txtPickUpDate.Text.ToString().Trim()) == true && CommonBL.isDate(txtDeliveryDate.Text.ToString().Trim()) == true)
            {                
                PickupRequestEL objEL = new PickupRequestEL();                
                objEL.PickupRequestId = IsInteger(ViewState["PickupReuestId"].ToString());
                objEL.ShipFromCompany = txtShipFromCompany.Text.ToString().Trim();
                objEL.ShipFromRefNumber = txtShipperRefNo.Text.ToString().Trim();
                objEL.ShipFromAddress = txtFromAddress.Text.ToString().Trim();
                objEL.ShipFromCity = txtFromCity.Text.ToString().Trim();
                if (drpFromState.SelectedIndex > 0)
                {
                    objEL.ShipFromState = drpFromState.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromState = "";
                }
                objEL.ShipFromPostalCode = txtFromPostalCode.Text.ToString().Trim();
                if (drpFromCountry.SelectedIndex > 0)
                {
                    objEL.ShipFromCountry = drpFromCountry.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromCountry = "";
                }

                objEL.ShipFromContact = txtFromContact.Text.ToString().Trim();
                objEL.ShipFromPhone = txtFromPhone.Text.ToString().Trim();
                objEL.ShipFromFax = txtFromFax.Text.ToString().Trim();
                objEL.ShipFromEmail = txtFromEmail.Text.ToString().Trim();
                objEL.ShipFromDate = Convert.ToDateTime(txtPickUpDate.Text.ToString().Trim());
                if (drpReadyTime.SelectedIndex > 0)
                {
                    objEL.ShipFromTimeReady = drpReadyTime.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromTimeReady = "";
                }
                if (drpLatestPickup.SelectedIndex > 0)
                {
                    objEL.ShipFromTimeNLT = drpLatestPickup.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromTimeNLT = "";
                }

                objEL.ExportEIN = txtExporterEIN.Text.ToString().Trim();
                
                if (chkPartyTransaction.Checked == true)
                {
                    objEL.ExportPartyTrans = 1;
                }
                else
                {
                    objEL.ExportPartyTrans = 0;
                }

                objEL.ExportIntermediateConsignee = txtIntermediateConsignee.Text.ToString().Trim();
                objEL.ExportIntermediateContact = txtContactName.Text.ToString().Trim();
                objEL.ExportAddress = txtAddress.Text.ToString().Trim();
                objEL.ExportIntermediatePhone = txtTelephone.Text.ToString().Trim();
                objEL.ExportCity = txtCity.Text.ToString().Trim();
                objEL.ExportPostalCode = txtPostalCode.Text.ToString().Trim();
                if (drpCountry.SelectedIndex > 0)
                {
                    objEL.ExportCountry = drpCountry.SelectedItem.Text;
                }
                objEL.ExportLicence = txtValidLicenseNo.Text.ToString().Trim();
                objEL.ExportECCN = txtECCN.Text.ToString().Trim();
                objEL.ShipToCompany = txtShipToCompany.Text.ToString().Trim().Replace("–", "-");
                objEL.ShipToConsigneeRefNumber = txtConsigneeRefNo.Text.ToString().Trim();
                objEL.ShipToAddress = txtToAddress.Text.ToString().Trim();
                objEL.ShipToCity = txtToCity.Text.ToString().Trim();                
                objEL.ShipToPostalCode = txtToPostalCode.Text.ToString().Trim();
                if (drpToCountry.SelectedIndex > 0)
                {
                    objEL.ShipToCountry = drpToCountry.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipToCountry = "";
                }
                objEL.ShipToContact = txtToContact.Text.ToString().Trim();
                objEL.ShipToPhone = txtToPhone.Text.ToString().Trim();
                objEL.ShipToFax = txtToFax.Text.ToString().Trim();                
                objEL.ShipToDate = Convert.ToDateTime(txtDeliveryDate.Text.ToString().Trim());
                if (rbInsuranceRequired.Items[0].Selected == true)
                {
                    objEL.Insured = 0;
                }
                else
                {
                    objEL.Insured = 1;
                }
                if (txtInsuredValue.Text.ToString() != "")
                {
                    objEL.InsuredValue = IsDecimal(txtInsuredValue.Text.ToString().Trim());
                }                
                objEL.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));                
                objEL.StatusCode = "SAME";
                if (HidWarehouseid.Value != null && HidWarehouseid.Value != "" && HidWarehouseid.Value != "0")
                {                    
                    objEL.ShipToLocationId = IsInteger(HidWarehouseid.Value);
                    objEL.PickupRequestTypeWarehouse = 1;
                    lblWAreHoseLocationId.Text = HidWarehouseid.Value;
                }
                else
                {
                    objEL.ShipToLocationId = 0;
                    objEL.PickupRequestTypeWarehouse = 0;
                    lblWAreHoseLocationId.Text = "0";
                }

                objEL.PickupRequestType = 2;
                
                //new                

                objEL.WeightType = "lbs";
                if (rbInternAir.Checked == true)
                {
                    objEL.TransMode = 3;
                    objEL.TransModeName = rbInternAir.Text;
                    objEL.TransModeService1 = drpInternAirTypeService1.SelectedItem.Value;
                    objEL.TransModeService2 = drpInternAirTypeService2.SelectedItem.Value;
                }
                else if (rbInternOcean.Checked == true)
                {
                    objEL.TransMode = 4;
                    objEL.TransModeName = rbInternOcean.Text;
                    objEL.TransModeService1 = drpInternOceanTypeService1.SelectedItem.Value;
                    objEL.TransModeService2 = drpInternOceanTypeService2.SelectedItem.Value;
                }
                else if (rbISCSAdvantage.Checked == true)
                {
                    objEL.TransMode = 0;
                    objEL.TransModeName = rbISCSAdvantage.Text;
                }
               
                string strSServices = "";
                for (int i = 0; i < chkLLiftGate.Items.Count; i++)
                {
                    if (chkLLiftGate.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLLiftGate.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLLiftGate.Items[i].Value;
                        }
                    }
                }

                for (int i = 0; i < chkLPalletJack.Items.Count; i++)
                {
                    if (chkLPalletJack.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLPalletJack.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLPalletJack.Items[i].Value;
                        }
                    }
                }

                for (int i = 0; i < chkLLocatedInside.Items.Count; i++)
                {
                    if (chkLLocatedInside.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLLocatedInside.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLLocatedInside.Items[i].Value;
                        }
                    }
                }

                for (int i = 0; i < chkLSaturdayService.Items.Count; i++)
                {
                    if (chkLSaturdayService.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLSaturdayService.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLSaturdayService.Items[i].Value;
                        }
                    }
                }

                for (int i = 0; i < chkLConvention.Items.Count; i++)
                {
                    if (chkLConvention.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLConvention.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLConvention.Items[i].Value;
                        }
                    }
                }

                for (int i = 0; i < chkLResidentialLocation.Items.Count; i++)
                {
                    if (chkLResidentialLocation.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLResidentialLocation.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLResidentialLocation.Items[i].Value;
                        }
                    }
                }

                objEL.SpecialServiceCodes = strSServices;
                objEL.SpecialInstructions = txtareaSpecialInTructions.Value;
                objEL.ShippersInstructions = txtareaShippersInstructions.Value;
                objEL.DocumentsEnclosed = txtareaDocumentEnclosed.Value;
                objEL.GLSTrackingNumber = "";
                objEL.GLSAccountId = Convert.ToInt32(drpAccountCode.SelectedValue);
                objEL.GLSCarrierName = txtPickupCarrier.Text.ToString().Trim();                
                objEL.GLSShippedWeight = IsDecimal(txtShippedWeight.Text.ToString().Trim());
                objEL.ExportLoadingPort = txtPortAirExport.Text.ToString().Trim();
                if (rblistContainerized.Items[0].Selected == true)
                {
                    objEL.ExportContanerized = 0;
                }
                else
                {
                    objEL.ExportContanerized = 1;
                }                
                objEL.GLSCubicWeight = Convert.ToInt32(ViewState["cubicweight"]);                
                objEL.GLSInsured = IsInteger(rblInsured.SelectedItem.Value);
                objEL.GLSNotes = txtareaNotes.Value;                
                objEL.GLSBuyRateTransportCharge = IsDecimal(txtTransportCost1.Text.ToString().Trim());                
                objEL.GLSBuyRateAccessorialCharge = IsDecimal(txtAccessorialCost1.Text.ToString().Trim());                
                objEL.GLSBuyRateFuelCharge = IsDecimal(txtFuelSurcharge1.Text.ToString().Trim());                
                objEL.GLSBuyRateInsuraceCharge = IsDecimal(txtInsurance1.Text.ToString().Trim());                
                objEL.GLSBuyRateCodFee = IsDecimal(txtCodFee1.Text.ToString().Trim());                
                objEL.GLSSellRateTransportCharge = IsDecimal(txtTransport.Text.ToString().Trim());                
                objEL.GLSSellRateAccessorialCharge = IsDecimal(txtAccessorial.Text.ToString().Trim());                
                objEL.GLSSellRateFuelCharge = IsDecimal(txtFuelSurcharge.Text.ToString().Trim());                
                objEL.GLSSellRateInsuraceCharge = IsDecimal(txtInsurance.Text.ToString().Trim());                
                objEL.GLSSellRateCodFee = IsDecimal(txtCodFee.Text.ToString().Trim());
                objEL.GLSCarrierNameInterm = txtIntermediateCarrier.Text.ToString().Trim();
                objEL.GLSCarrierNameDelivery = txtDeliveryCarrier.Text.ToString().Trim();
                objEL.GLSCarrierNameOther = txtOtherCarrier.Text.ToString().Trim();                
                objEL.GLSBuyRateTransportChargeInterm = IsDecimal(txtTransportCost2.Text.ToString().Trim());                
                objEL.GLSBuyRateTransportChargeDelivery = IsDecimal(txtTransportCost3.Text.ToString().Trim());                
                objEL.GLSBuyRateTransportChargeOther = IsDecimal(txtTransportCost4.Text.ToString().Trim());                
                objEL.GLSBuyRateAccessorialChargeInterm = IsDecimal(txtAccessorialCost2.Text.ToString().Trim());                
                objEL.GLSBuyRateAccessorialChargeDelivery = IsDecimal(txtAccessorialCost3.Text.ToString().Trim());                
                objEL.GLSBuyRateAccessorialChargeOther = IsDecimal(txtAccessorialCost4.Text.ToString().Trim());                
                objEL.GLSBuyRateFuelChargeInterm = IsDecimal(txtFuelSurcharge1.Text.ToString().Trim());                
                objEL.GLSBuyRateFuelChargeDelivery = IsDecimal(txtFuelSurcharge2.Text.ToString().Trim());                
                objEL.GLSBuyRateFuelChargeOther = IsDecimal(txtFuelSurcharge3.Text.ToString().Trim());                
                objEL.GLSTotalBuyRate = IsDecimal(txtTransportCost1.Text.ToString().Trim()) + IsDecimal(txtTransportCost2.Text.ToString().Trim()) + IsDecimal(txtTransportCost3.Text.ToString().Trim()) + IsDecimal(txtTransportCost4.Text.ToString().Trim()) + IsDecimal(txtAccessorialCost1.Text.ToString().Trim())
                    + IsDecimal(txtAccessorialCost2.Text.ToString().Trim()) + IsDecimal(txtAccessorialCost3.Text.ToString().Trim()) + IsDecimal(txtAccessorialCost4.Text.ToString().Trim()) + IsDecimal(txtFuelSurcharge1.Text.ToString().Trim()) + IsDecimal(txtFuelSurcharge2.Text.ToString().Trim()) +
                    IsDecimal(txtFuelSurcharge3.Text.ToString().Trim()) + IsDecimal(txtFuelSurcharge4.Text.ToString().Trim()) + IsDecimal(txtInsurance1.Text.ToString().Trim()) + IsDecimal(txtCodFee1.Text.ToString().Trim()) + IsDecimal(txtBuyBrokerage.Text.ToString().Trim()) + IsDecimal(txtBuyDuty.Text.ToString().Trim());
                
                objEL.GLSTotalSellRate = IsDecimal(txtTransport.Text.ToString().Trim()) + IsDecimal(txtAccessorial.Text.ToString().Trim()) + IsDecimal(txtFuelSurcharge.Text.ToString().Trim()) + IsDecimal(txtInsurance.Text.ToString().Trim()) + IsDecimal(txtCodFee.Text.ToString().Trim()) + IsDecimal(txtSellBrokerage.Text.ToString().Trim()) + IsDecimal(txtSellDuty.Text.ToString().Trim());
                if (chkShipmentInfo.Items[0].Selected == true)
                {
                    objEL.GLSKnownShipper = 1;
                }
                else
                {
                    objEL.GLSKnownShipper = 0;
                }
                objEL.GLSBuyRateBrokerage = IsDecimal(txtBuyBrokerage.Text.ToString().Trim());
                objEL.GLSSellRateBrokerage = IsDecimal(txtSellBrokerage.Text.ToString().Trim());
                objEL.GLSBuyRateDuty = IsDecimal(txtBuyDuty.Text.ToString().Trim());
                objEL.GLSSellRateDuty = IsDecimal(txtSellDuty.Text.ToString().Trim());
                objEL.GLSPaymentMethod = drpPaymentMethod.SelectedItem.Text;
                objEL.GLSCertifiedCheck = rbCertifiedCheck.SelectedItem.Text;                
                objEL.GLSBillCompany = drpBillToCompany.SelectedItem.Text;
                objEL.GLSBillAddress = txtBillToAddress.Text.ToString().Trim();
                objEL.GLSBillCity = txtBillToCity.Text.ToString().Trim();                
                objEL.BillToStateName = txtBillToState.Text.ToString().Trim();
                objEL.GLSBillPostalCode = txtBillToZip.Text.ToString().Trim();                
                objEL.BillToCountryName = txtBillToCountry.Text.ToString().Trim();                
                objEL.Margin = IsDecimal(txtMargin.Text.ToString().Trim());
                objEL.SkeletonRecord = 0;
                //Checking whether request is pending or non-pending
                if (Request.QueryString["stat"] != null)
                {
                    if (Request.QueryString["stat"].ToString() == "n")
                    {
                        btnAccept.Visible = false;
                        objEL.WarehouseFlag = 1;
                    }
                    else
                    {
                        objEL.WarehouseFlag = 0;
                    }
                }
                else
                {
                    objEL.WarehouseFlag = 0;
                }
                EntityLayer.Carriers objCarrierEl = new EntityLayer.Carriers();
                objCarrierEl.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));

                if (CheckBoxList8.Items[0].Selected == true && txtPickupCarrier.Text.ToString().Trim()!="")
                {
                    objCarrierEl.CarrierName = txtPickupCarrier.Text.ToString().Trim();
                    CarriersBL.InsertCarrier(objCarrierEl);
                }

                if (CheckBoxList9.Items[0].Selected == true && txtIntermediateCarrier.Text.ToString().Trim()!="")
                {
                    objCarrierEl.CarrierName = txtIntermediateCarrier.Text.ToString().Trim();
                    CarriersBL.InsertCarrier(objCarrierEl);
                }

                if (CheckBoxList10.Items[0].Selected == true && txtDeliveryCarrier.Text.ToString().Trim()!="")
                {
                    objCarrierEl.CarrierName = txtDeliveryCarrier.Text.ToString().Trim();
                    CarriersBL.InsertCarrier(objCarrierEl);
                }

                if (CheckBoxList11.Items[0].Selected == true && txtOtherCarrier.Text.ToString().Trim()!="")
                {
                    objCarrierEl.CarrierName = txtOtherCarrier.Text.ToString().Trim();
                    CarriersBL.InsertCarrier(objCarrierEl);
                }

                // Add Userlocation for future use
                if (chkSaveShipFromInfo.Checked)
                {
                    UserLocationEL objUserLocationEL = new UserLocationEL();
                    objUserLocationEL.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));
                    objUserLocationEL.CompanyName = txtShipFromCompany.Text.ToString().Trim();
                    objUserLocationEL.Address = txtFromAddress.Text.ToString().Trim();
                    objUserLocationEL.City = txtFromCity.Text.ToString().Trim();
                    if (drpFromState.SelectedIndex > 0)
                    {
                        objUserLocationEL.StateId = IsInteger(drpFromState.SelectedValue);
                    }
                    objUserLocationEL.PostalCode = txtFromPostalCode.Text.ToString().Trim();
                    if (drpFromCountry.SelectedIndex > 0)
                    {
                        objUserLocationEL.CountryId = IsInteger(drpFromCountry.SelectedValue);
                    }
                    objUserLocationEL.ContactName = txtFromContact.Text.ToString().Trim();
                    objUserLocationEL.ContactPhone = txtFromPhone.Text.ToString().Trim();
                    objUserLocationEL.ContactFax = txtFromFax.Text.ToString().Trim();
                    objUserLocationEL.ContactEmail = txtFromEmail.Text.ToString().Trim();
                    Boolean statUL = UserLocationBL.AddLocation(objUserLocationEL);
                }
                if (chkSaveShipToInfo.Checked)
                {
                    UserLocationEL objUserLocationEL = new UserLocationEL();
                    objUserLocationEL.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));
                    objUserLocationEL.CompanyName = txtShipToCompany.Text.ToString().Trim().Replace("–", "-");
                    objUserLocationEL.Address = txtToAddress.Text.ToString().Trim();
                    objUserLocationEL.City = txtToCity.Text.ToString().Trim();
                    
                    objUserLocationEL.PostalCode = txtToPostalCode.Text.ToString().Trim();
                    if (drpToCountry.SelectedIndex > 0)
                    {
                        objUserLocationEL.CountryId = IsInteger(drpToCountry.SelectedValue);
                    }
                    objUserLocationEL.ContactName = txtToContact.Text.ToString().Trim();
                    objUserLocationEL.ContactPhone = txtToPhone.Text.ToString().Trim();
                    objUserLocationEL.ContactFax = txtToFax.Text.ToString().Trim();
                    
                    Boolean statUL = UserLocationBL.AddLocation(objUserLocationEL);
                }
                // Add Userlocation for future use

                Boolean stat = PickupRequestBL.UpdatePickupRequest(objEL);
                if (stat == true)
                {
                    LockPickupRequest(IsInteger(ViewState["PickupReuestId"].ToString()), IsInteger(Convert.ToString(Session["cacheUserId"])), false);
                    
                    DataSet dsPickupRequest = PickupRequestBL.FetchAllPickupRequest(IsInteger(ViewState["PickupReuestId"].ToString()));                    
                    string strtracking_no = Convert.ToString(dsPickupRequest.Tables[0].Rows[0]["GLSTrackingNumber"]);
                    if (strtracking_no.Trim() == "")
                    {
                        UpdateMailToAdmin(ConfigurationManager.AppSettings["AdminEmail"].Trim());
                        //AdminEmailNewRequest(ConfigurationManager.AppSettings["AdminEmail"].Trim());
                    }
                    if (Request.QueryString["stat"] != null && Request.QueryString["stat"].ToString().Trim().ToUpper() == "N")
                    {                        
                        Response.Write("<script language='javascript'>alert('Record saved successfully');location.href='RequestList.aspx?RequestType=NonPending';</script>");
                    }
                    else if (Request.QueryString["stat"] != null && Request.QueryString["stat"].ToString().Trim().ToUpper() == "P")
                    {                        
                        Response.Write("<script language='javascript'>alert('Record saved successfully');location.href='RequestList.aspx?RequestType=Pending';</script>");
                    }
                    else
                    {                        
                        Response.Write("<script language='javascript'>alert('Record saved successfully');location.href='AddPickUpRequestIntl.aspx';</script>");
                    }                    
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please enter proper date";
            }
        }
        #endregion

        #region protected void btnAccept_Click(object sender, EventArgs e)
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (CommonBL.isDate(txtPickUpDate.Text.ToString().Trim()) == true && CommonBL.isDate(txtDeliveryDate.Text.ToString().Trim()) == true)
            {
                PickupRequestEL objEL = new PickupRequestEL();                
                objEL.PickupRequestId = IsInteger(ViewState["PickupReuestId"].ToString());
                objEL.ShipFromCompany = txtShipFromCompany.Text.ToString().Trim();
                objEL.ShipFromRefNumber = txtShipperRefNo.Text.ToString().Trim();
                objEL.ShipFromAddress = txtFromAddress.Text.ToString().Trim();
                objEL.ShipFromCity = txtFromCity.Text.ToString().Trim();
                if (drpFromState.SelectedIndex > 0)
                {
                    objEL.ShipFromState = drpFromState.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromState = "";
                }
                objEL.ShipFromPostalCode = txtFromPostalCode.Text.ToString().Trim();
                if (drpFromCountry.SelectedIndex > 0)
                {
                    objEL.ShipFromCountry = drpFromCountry.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromCountry = "";
                }

                objEL.ShipFromContact = txtFromContact.Text.ToString().Trim();
                objEL.ShipFromPhone = txtFromPhone.Text.ToString().Trim();
                objEL.ShipFromFax = txtFromFax.Text.ToString().Trim();
                objEL.ShipFromEmail = txtFromEmail.Text.ToString().Trim();
                objEL.ShipFromDate = Convert.ToDateTime(txtPickUpDate.Text.ToString().Trim());
                if (drpReadyTime.SelectedIndex > 0)
                {
                    objEL.ShipFromTimeReady = drpReadyTime.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromTimeReady = "";
                }

                if (drpLatestPickup.SelectedIndex > 0)
                {
                    objEL.ShipFromTimeNLT = drpLatestPickup.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromTimeNLT = "";
                }

                objEL.ExportEIN = txtExporterEIN.Text.ToString().Trim();
                if (chkPartyTransaction.Checked == true)
                {
                    objEL.ExportPartyTrans = 1;
                }
                else
                {
                    objEL.ExportPartyTrans = 0;
                }

                objEL.ExportIntermediateConsignee = txtIntermediateConsignee.Text.ToString().Trim();
                objEL.ExportIntermediateContact = txtContactName.Text.ToString().Trim();
                objEL.ExportAddress = txtAddress.Text.ToString().Trim();
                objEL.ExportIntermediatePhone = txtTelephone.Text.ToString().Trim();
                objEL.ExportCity = txtCity.Text.ToString().Trim();
                objEL.ExportPostalCode = txtPostalCode.Text.ToString().Trim();
                if (drpCountry.SelectedIndex > 0)
                {
                    objEL.ExportCountry = drpCountry.SelectedItem.Text;
                }
                objEL.ExportLicence = txtValidLicenseNo.Text.ToString().Trim();
                objEL.ExportECCN = txtECCN.Text.ToString().Trim();
                objEL.ShipToCompany = txtShipToCompany.Text.ToString().Trim().Replace("–", "-");
                objEL.ShipToConsigneeRefNumber = txtConsigneeRefNo.Text.ToString().Trim();
                objEL.ShipToAddress = txtToAddress.Text.ToString().Trim();
                objEL.ShipToCity = txtToCity.Text.ToString().Trim();                
                objEL.ShipToPostalCode = txtToPostalCode.Text.ToString().Trim();
                if (drpToCountry.SelectedIndex > 0)
                {
                    objEL.ShipToCountry = drpToCountry.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipToCountry = "";
                }
                objEL.ShipToContact = txtToContact.Text.ToString().Trim();
                objEL.ShipToPhone = txtToPhone.Text.ToString().Trim();
                objEL.ShipToFax = txtToFax.Text.ToString().Trim();                
                objEL.ShipToDate = Convert.ToDateTime(txtDeliveryDate.Text.ToString().Trim());
                if (rbInsuranceRequired.Items[0].Selected == true)
                {
                    objEL.Insured = 0;
                }
                else
                {
                    objEL.Insured = 1;
                }
                if (txtInsuredValue.Text.ToString() != "")
                {
                    objEL.InsuredValue = IsDecimal(txtInsuredValue.Text.ToString().Trim());
                }                
                objEL.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));
                objEL.StatusCode = "SUP";
                //Checking whether destination location is warehouse.The hidden field holds the id of the destination warehouse
                if (HidWarehouseid.Value != null && HidWarehouseid.Value != "" && HidWarehouseid.Value != "0")
                {                    
                    objEL.ShipToLocationId = IsInteger(HidWarehouseid.Value);
                    objEL.PickupRequestTypeWarehouse = 1;
                    lblWAreHoseLocationId.Text = HidWarehouseid.Value;
                }
                else
                {
                    objEL.ShipToLocationId = 0;
                    objEL.PickupRequestTypeWarehouse = 0;
                    lblWAreHoseLocationId.Text = "0";
                }

                objEL.PickupRequestType = 2;

                //new               

                objEL.WeightType = "lbs";
                if (rbInternAir.Checked == true)
                {
                    objEL.TransMode = 3;
                    objEL.TransModeName = rbInternAir.Text;
                    objEL.TransModeService1 = drpInternAirTypeService1.SelectedItem.Value;
                    objEL.TransModeService2 = drpInternAirTypeService2.SelectedItem.Value;
                }
                else if (rbInternOcean.Checked == true)
                {
                    objEL.TransMode = 4;
                    objEL.TransModeName = rbInternOcean.Text;
                    objEL.TransModeService1 = drpInternOceanTypeService1.SelectedItem.Value;
                    objEL.TransModeService2 = drpInternOceanTypeService2.SelectedItem.Value;
                }
                else if (rbISCSAdvantage.Checked == true)
                {
                    objEL.TransMode = 0;
                    objEL.TransModeName = rbISCSAdvantage.Text;
                }
                
                string strSServices = "";
                for (int i = 0; i < chkLLiftGate.Items.Count; i++)
                {
                    if (chkLLiftGate.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLLiftGate.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLLiftGate.Items[i].Value;
                        }
                    }
                }

                for (int i = 0; i < chkLPalletJack.Items.Count; i++)
                {
                    if (chkLPalletJack.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLPalletJack.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLPalletJack.Items[i].Value;
                        }
                    }
                }

                for (int i = 0; i < chkLLocatedInside.Items.Count; i++)
                {
                    if (chkLLocatedInside.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLLocatedInside.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLLocatedInside.Items[i].Value;
                        }
                    }
                }

                for (int i = 0; i < chkLSaturdayService.Items.Count; i++)
                {
                    if (chkLSaturdayService.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLSaturdayService.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLSaturdayService.Items[i].Value;
                        }
                    }
                }

                for (int i = 0; i < chkLConvention.Items.Count; i++)
                {
                    if (chkLConvention.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLConvention.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLConvention.Items[i].Value;
                        }
                    }
                }

                for (int i = 0; i < chkLResidentialLocation.Items.Count; i++)
                {
                    if (chkLResidentialLocation.Items[i].Selected == true)
                    {
                        if (strSServices == "")
                        {
                            strSServices = chkLResidentialLocation.Items[i].Value;
                        }
                        else
                        {
                            strSServices = strSServices + "|" + chkLResidentialLocation.Items[i].Value;
                        }
                    }
                }

                objEL.SpecialServiceCodes = strSServices;
                objEL.SpecialInstructions = txtareaSpecialInTructions.Value;
                objEL.ShippersInstructions = txtareaShippersInstructions.Value;
                objEL.DocumentsEnclosed = txtareaDocumentEnclosed.Value;
                objEL.GLSTrackingNumber = "";
                objEL.GLSAccountId = Convert.ToInt32(drpAccountCode.SelectedValue);
                objEL.GLSCarrierName = txtPickupCarrier.Text.ToString().Trim();
                objEL.ExportLoadingPort = txtPortAirExport.Text.ToString().Trim();
                if (rblistContainerized.Items[0].Selected == true)
                {
                    objEL.ExportContanerized = 0;
                }
                else
                {
                    objEL.ExportContanerized = 1;
                }                
                objEL.GLSShippedWeight = IsInteger(txtShippedWeight.Text.ToString().Trim());                
                objEL.GLSInsured = IsInteger(rblInsured.SelectedItem.Value);
                objEL.GLSNotes = txtareaNotes.Value;                

                objEL.GLSBuyRateTransportCharge = IsDecimal(txtTransportCost1.Text.ToString().Trim());
                objEL.GLSBuyRateAccessorialCharge = IsDecimal(txtAccessorialCost1.Text.ToString().Trim());
                objEL.GLSBuyRateFuelCharge = IsDecimal(txtFuelSurcharge1.Text.ToString().Trim());
                objEL.GLSBuyRateInsuraceCharge = IsDecimal(txtInsurance1.Text.ToString().Trim());
                objEL.GLSBuyRateCodFee = IsDecimal(txtCodFee1.Text.ToString().Trim());
                objEL.GLSSellRateTransportCharge = IsDecimal(txtTransport.Text.ToString().Trim());
                objEL.GLSSellRateAccessorialCharge = IsDecimal(txtAccessorial.Text.ToString().Trim());
                objEL.GLSSellRateFuelCharge = IsDecimal(txtFuelSurcharge.Text.ToString().Trim());
                objEL.GLSSellRateInsuraceCharge = IsDecimal(txtInsurance.Text.ToString().Trim());
                objEL.GLSSellRateCodFee = IsDecimal(txtCodFee.Text.ToString().Trim());

                objEL.GLSCarrierNameInterm = txtIntermediateCarrier.Text.ToString().Trim();
                objEL.GLSCarrierNameDelivery = txtDeliveryCarrier.Text.ToString().Trim();
                objEL.GLSCarrierNameOther = txtOtherCarrier.Text.ToString().Trim();                

                objEL.GLSBuyRateTransportChargeInterm = IsDecimal(txtTransportCost2.Text.ToString().Trim());
                objEL.GLSBuyRateTransportChargeDelivery = IsDecimal(txtTransportCost3.Text.ToString().Trim());
                objEL.GLSBuyRateTransportChargeOther = IsDecimal(txtTransportCost4.Text.ToString().Trim());
                objEL.GLSBuyRateAccessorialChargeInterm = IsDecimal(txtAccessorialCost2.Text.ToString().Trim());
                objEL.GLSBuyRateAccessorialChargeDelivery = IsDecimal(txtAccessorialCost3.Text.ToString().Trim());
                objEL.GLSBuyRateAccessorialChargeOther = IsDecimal(txtAccessorialCost4.Text.ToString().Trim());
                objEL.GLSBuyRateFuelChargeInterm = IsDecimal(txtFuelSurcharge1.Text.ToString().Trim());
                objEL.GLSBuyRateFuelChargeDelivery = IsDecimal(txtFuelSurcharge2.Text.ToString().Trim());
                objEL.GLSBuyRateFuelChargeOther = IsDecimal(txtFuelSurcharge3.Text.ToString().Trim());
                
                objEL.GLSTotalBuyRate = IsDecimal(txtTransportCost1.Text.ToString().Trim()) + IsDecimal(txtTransportCost2.Text.ToString().Trim()) + IsDecimal(txtTransportCost3.Text.ToString().Trim()) + IsDecimal(txtTransportCost4.Text.ToString().Trim()) + IsDecimal(txtAccessorialCost1.Text.ToString().Trim())
                    + IsDecimal(txtAccessorialCost2.Text.ToString().Trim()) + IsDecimal(txtAccessorialCost3.Text.ToString().Trim()) + IsDecimal(txtAccessorialCost4.Text.ToString().Trim()) + IsDecimal(txtFuelSurcharge1.Text.ToString().Trim()) + IsDecimal(txtFuelSurcharge2.Text.ToString().Trim()) +
                    IsDecimal(txtFuelSurcharge3.Text.ToString().Trim()) + IsDecimal(txtFuelSurcharge4.Text.ToString().Trim()) + IsDecimal(txtInsurance1.Text.ToString().Trim()) + IsDecimal(txtCodFee1.Text.ToString().Trim()) + IsDecimal(txtBuyBrokerage.Text.ToString().Trim()) + IsDecimal(txtBuyDuty.Text.ToString().Trim());
               
                objEL.GLSTotalSellRate = IsDecimal(txtTransport.Text.ToString().Trim()) + IsDecimal(txtAccessorial.Text.ToString().Trim()) + IsDecimal(txtFuelSurcharge.Text.ToString().Trim()) + IsDecimal(txtInsurance.Text.ToString().Trim()) + IsDecimal(txtCodFee.Text.ToString().Trim()) + IsDecimal(txtSellBrokerage.Text.ToString().Trim()) + IsDecimal(txtSellDuty.Text.ToString().Trim());

                if (chkShipmentInfo.Items[0].Selected == true)
                {
                    objEL.GLSKnownShipper = 1;
                }
                else
                {
                    objEL.GLSKnownShipper = 0;
                }
                objEL.GLSBuyRateBrokerage = IsDecimal(txtBuyBrokerage.Text.ToString().Trim());
                objEL.GLSSellRateBrokerage = IsDecimal(txtSellBrokerage.Text.ToString().Trim());
                objEL.GLSBuyRateDuty = IsDecimal(txtBuyDuty.Text.ToString().Trim());
                objEL.GLSSellRateDuty = IsDecimal(txtSellDuty.Text.ToString().Trim());
                objEL.GLSPaymentMethod = drpPaymentMethod.SelectedItem.Text;
                objEL.GLSCertifiedCheck = rbCertifiedCheck.SelectedItem.Text;                
                objEL.GLSBillCompany = drpBillToCompany.SelectedItem.Text;
                objEL.GLSBillAddress = txtBillToAddress.Text.ToString().Trim();
                objEL.GLSBillCity = txtBillToCity.Text.ToString().Trim();                
                objEL.GLSBillPostalCode = txtBillToZip.Text.ToString().Trim();                
                objEL.BillToStateName = txtBillToState.Text.ToString().Trim();
                objEL.BillToCountryName = txtBillToCountry.Text.ToString().Trim();                
                objEL.Margin = IsDecimal(txtMargin.Text.ToString().Trim());
                objEL.SkeletonRecord = 0;
                objEL.WarehouseFlag = 1;

                EntityLayer.Carriers objCarrierEl = new EntityLayer.Carriers();
                objCarrierEl.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));

                if (CheckBoxList8.Items[0].Selected == true && txtPickupCarrier.Text.ToString().Trim() != "")
                {
                    objCarrierEl.CarrierName = txtPickupCarrier.Text.ToString().Trim();
                    CarriersBL.InsertCarrier(objCarrierEl);
                }

                if (CheckBoxList9.Items[0].Selected == true && txtIntermediateCarrier.Text.ToString().Trim() != "")
                {
                    objCarrierEl.CarrierName = txtIntermediateCarrier.Text.ToString().Trim();
                    CarriersBL.InsertCarrier(objCarrierEl);
                }

                if (CheckBoxList10.Items[0].Selected == true && txtDeliveryCarrier.Text.ToString().Trim() != "")
                {
                    objCarrierEl.CarrierName = txtDeliveryCarrier.Text.ToString().Trim();
                    CarriersBL.InsertCarrier(objCarrierEl);
                }

                if (CheckBoxList11.Items[0].Selected == true && txtOtherCarrier.Text.ToString().Trim() != "")
                {
                    objCarrierEl.CarrierName = txtOtherCarrier.Text.ToString().Trim();
                    CarriersBL.InsertCarrier(objCarrierEl);
                }

                // Add Userlocation for future use
                if (chkSaveShipFromInfo.Checked)
                {
                    UserLocationEL objUserLocationEL = new UserLocationEL();
                    objUserLocationEL.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));
                    objUserLocationEL.CompanyName = txtShipFromCompany.Text.ToString().Trim();
                    objUserLocationEL.Address = txtFromAddress.Text.ToString().Trim();
                    objUserLocationEL.City = txtFromCity.Text.ToString().Trim();
                    if (drpFromState.SelectedIndex > 0)
                    {
                        objUserLocationEL.StateId = IsInteger(drpFromState.SelectedValue);
                    }
                    objUserLocationEL.PostalCode = txtFromPostalCode.Text.ToString().Trim();
                    if (drpFromCountry.SelectedIndex > 0)
                    {
                        objUserLocationEL.CountryId = IsInteger(drpFromCountry.SelectedValue);
                    }
                    objUserLocationEL.ContactName = txtFromContact.Text.ToString().Trim();
                    objUserLocationEL.ContactPhone = txtFromPhone.Text.ToString().Trim();
                    objUserLocationEL.ContactFax = txtFromFax.Text.ToString().Trim();
                    objUserLocationEL.ContactEmail = txtFromEmail.Text.ToString().Trim();
                    Boolean statUL = UserLocationBL.AddLocation(objUserLocationEL);
                }
                if (chkSaveShipToInfo.Checked)
                {
                    UserLocationEL objUserLocationEL = new UserLocationEL();
                    objUserLocationEL.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));
                    objUserLocationEL.CompanyName = txtShipToCompany.Text.ToString().Trim().Replace("–", "-");
                    objUserLocationEL.Address = txtToAddress.Text.ToString().Trim();
                    objUserLocationEL.City = txtToCity.Text.ToString().Trim();                    
                    objUserLocationEL.PostalCode = txtToPostalCode.Text.ToString().Trim();
                    if (drpToCountry.SelectedIndex > 0)
                    {
                        objUserLocationEL.CountryId = IsInteger(drpToCountry.SelectedValue);
                    }
                    objUserLocationEL.ContactName = txtToContact.Text.ToString().Trim();
                    objUserLocationEL.ContactPhone = txtToPhone.Text.ToString().Trim();
                    objUserLocationEL.ContactFax = txtToFax.Text.ToString().Trim();                    
                    Boolean statUL = UserLocationBL.AddLocation(objUserLocationEL);
                }
                // Add Userlocation for future use

                Boolean stat = PickupRequestBL.UpdatePickupRequest(objEL);

                DataSet dsShipmentItems = ShipmentItemsBL.FetchShipmentUnit(IsInteger(ViewState["PickupReuestId"].ToString()));
                decimal dactual_weight = 0;
                if (dsShipmentItems != null && dsShipmentItems.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsShipmentItems.Tables[0].Rows.Count; i++)
                    {
                        dactual_weight = IsDecimal(Convert.ToString(dsShipmentItems.Tables[0].Rows[i]["Weight_SI"]));
                    }
                }

                DataSet dsSKIDs = HandlingUnitBL.FetchHandlingUnit(IsInteger(ViewState["PickupReuestId"].ToString()), 1);
                decimal ddim_weight = 0;
                if (dsSKIDs != null && dsSKIDs.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSKIDs.Tables[0].Rows.Count; i++)
                    {
                        ddim_weight = IsDecimal(Convert.ToString(dsSKIDs.Tables[0].Rows[i]["SkidCubicWeight"]));
                    }
                }
                objEL.GLSCubicWeight = ddim_weight;
                DataSet dsPickupRequest = PickupRequestBL.FetchAllPickupRequest(IsInteger(ViewState["PickupReuestId"].ToString()));

                // TBills Entity Layer
                TBills objTBillsEL = new TBills();
                objTBillsEL.tracking_no = Convert.ToString(dsPickupRequest.Tables[0].Rows[0]["GLSTrackingNumber"]);
                objTBillsEL.PickupRequestId = IsInteger(ViewState["PickupReuestId"].ToString());
                objTBillsEL.pieces = 0;
                objTBillsEL.actual_weight = dactual_weight;
                objTBillsEL.dim_weight = ddim_weight;
                //objTBillsEL.agent_id = IsInteger(Convert.ToString(Session["cacheUserId"]));
                objTBillsEL.agent_id = IsInteger(Convert.ToString(dsPickupRequest.Tables[0].Rows[0]["UserId"]));
                objTBillsEL.status_id = 0;
                objTBillsEL.AccountCodeId = IsInteger(Convert.ToString(dsPickupRequest.Tables[0].Rows[0]["GLSAccountId"]));
                objTBillsEL.GLSCarrierName = Convert.ToString(dsPickupRequest.Tables[0].Rows[0]["GLSCarrierName"]);
                objTBillsEL.GLSCarrierNameInterm = Convert.ToString(dsPickupRequest.Tables[0].Rows[0]["GLSCarrierNameInterm"]);
                objTBillsEL.GLSCarrierNameDelivery = Convert.ToString(dsPickupRequest.Tables[0].Rows[0]["GLSCarrierNameDelivery"]);
                objTBillsEL.GLSCarrierNameOther = Convert.ToString(dsPickupRequest.Tables[0].Rows[0]["GLSCarrierNameOther"]);

                // TBills Business Logic Layer
                Boolean statBills = TBillsBL.AddNewTbills(objTBillsEL);                

                if (stat == true)
                {
                    if (HidWarehouseid.Value != null && HidWarehouseid.Value != "" && HidWarehouseid.Value != "0")
                    {
                        WarehouseLocationEL objWhEl = new WarehouseLocationEL();
                        objWhEl = WarehouseLocationBL.SingleWarehouseLocation(Convert.ToInt32(HidWarehouseid.Value));
                        WhRptPreAlert(objWhEl.ContactEmail, objTBillsEL.tracking_no.Trim());
                    }

                    //new request from "View or Ship Warehouse Items" page
                    if (hidFromLocationid.Value != null && hidFromLocationid.Value != "" && hidFromLocationid.Value != "0")
                    {
                        WarehouseLocationEL objWhEl = new WarehouseLocationEL();
                        objWhEl = WarehouseLocationBL.SingleWarehouseLocation(Convert.ToInt32(hidFromLocationid.Value));
                        WhPickListAlert(objWhEl.ContactEmail);
                    }
                    LockPickupRequest(IsInteger(ViewState["PickupReuestId"].ToString()), IsInteger(Convert.ToString(Session["cacheUserId"])), false);
                    int iInitiatorUserID = 0;
                    int iInitiatorUserTypeID = 0;
                    string iInitiatorEmail = "";
                    if (dsPickupRequest.Tables[0].Rows[0]["UserId"] != DBNull.Value)
                    {
                        iInitiatorUserID = Convert.ToInt32(dsPickupRequest.Tables[0].Rows[0]["UserId"]);
                    }
                    DataTable dtInitiatorUser = UserBL.GetUserByUserId(iInitiatorUserID);
                    if (dtInitiatorUser != null)
                    {
                        if (dtInitiatorUser.Rows.Count > 0)
                        {
                            iInitiatorUserTypeID = Convert.ToInt32(dtInitiatorUser.Rows[0]["UserTypeId"]);
                            iInitiatorEmail = Convert.ToString(dtInitiatorUser.Rows[0]["Email"]);
                        }
                    }
                    RequestAcceptByISCS(objTBillsEL.tracking_no, txtFromEmail.Text.ToString().Trim(), iInitiatorEmail.Trim(), objEL.GLSTotalSellRate, Convert.ToInt32(drpAccountCode.SelectedValue), iInitiatorUserTypeID);
                    if (drpBillToCompany.SelectedItem.Text.Trim().ToUpper().IndexOf("QUAD") != -1)
                    {
                        RequestAcceptByISCS(objTBillsEL.tracking_no, ConfigurationManager.AppSettings["QWEEmail"].Trim(), ConfigurationManager.AppSettings["QWEEmail"].Trim(), objEL.GLSTotalSellRate, Convert.ToInt32(drpAccountCode.SelectedValue), iInitiatorUserTypeID);
                        AddQWEVendor2QuickBook(objTBillsEL.tracking_no); //Commented on 25.04.2012 Client Request(Disable QB)
                    }
                    else
                    {
                        AddVendor2QuickBook(objTBillsEL.tracking_no); //Commented on 25.04.2012 Client Request(Disable QB)
                    }
                    AddCustomer2QuickBook(objTBillsEL.tracking_no); //Commented on 25.04.2012 Client Request(Disable QB)
                    Response.Write("<script language='javascript'>alert('The request has been accepted');location.href='AddPickUpRequestIntl.aspx';</script>");                    
                }
                else
                {
                    lblSubMsg.Visible = true;
                    lblSubMsg.Text = "Sorry,the accept request is not successfull.Please try again.";
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please enter proper date";
            }

        }
        #endregion

        #region protected void btnloadskids_Click(object sender, EventArgs e)
        protected void btnloadskids_Click(object sender, EventArgs e)
        {
            FetchShipments();
            FetchSkids();
        }
        #endregion

        #region protected void btnSave_Click(object sender, EventArgs e)
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CommonBL.isDate(txtPickUpDate.Text.ToString().Trim()) == true && CommonBL.isDate(txtDeliveryDate.Text.ToString().Trim()) == true)
            {                
                PickupRequestEL objEL = new PickupRequestEL();
                objEL.ShipFromCompany = txtShipFromCompany.Text.ToString().Trim();
                objEL.ShipFromRefNumber = txtShipperRefNo.Text.ToString().Trim();
                objEL.ShipFromAddress = txtFromAddress.Text.ToString().Trim();
                objEL.ShipFromCity = txtFromCity.Text.ToString().Trim();
                if (drpFromState.SelectedIndex > 0)
                {
                    objEL.ShipFromState = drpFromState.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromState = "";
                }
                objEL.ShipFromPostalCode = txtFromPostalCode.Text.ToString().Trim();
                if (drpFromCountry.SelectedIndex > 0)
                {
                    objEL.ShipFromCountry = drpFromCountry.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromCountry = "";
                }                
                objEL.ShipFromContact = txtFromContact.Text.ToString().Trim();
                objEL.ShipFromPhone = txtFromPhone.Text.ToString().Trim();
                objEL.ShipFromFax = txtFromFax.Text.ToString().Trim();
                objEL.ShipFromEmail = txtFromEmail.Text.ToString().Trim();
                objEL.ShipFromDate = Convert.ToDateTime(txtPickUpDate.Text.ToString().Trim());
                if (drpReadyTime.SelectedIndex > 0)
                {
                    objEL.ShipFromTimeReady = drpReadyTime.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromTimeReady = "";
                }

                if (drpLatestPickup.SelectedIndex > 0)
                {
                    objEL.ShipFromTimeNLT = drpLatestPickup.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipFromTimeNLT = "";
                }

                objEL.ExportEIN = txtExporterEIN.Text.ToString().Trim();
                if(chkPartyTransaction.Checked==true)
                {
                    objEL.ExportPartyTrans = 1;
                }
                else
                {
                    objEL.ExportPartyTrans = 0;
                }

                objEL.ExportIntermediateConsignee = txtIntermediateConsignee.Text.ToString().Trim();
                objEL.ExportIntermediateContact = txtContactName.Text.ToString().Trim();
                objEL.ExportAddress = txtAddress.Text.ToString().Trim();
                objEL.ExportIntermediatePhone = txtTelephone.Text.ToString().Trim();
                objEL.ExportCity = txtCity.Text.ToString().Trim();
                objEL.ExportPostalCode = txtPostalCode.Text.ToString().Trim();
                if (drpCountry.SelectedIndex > 0)
                {
                    objEL.ExportCountry = drpCountry.SelectedItem.Text;
                }
                objEL.ExportLicence = txtValidLicenseNo.Text.ToString().Trim();
                objEL.ExportECCN = txtECCN.Text.ToString().Trim();
                objEL.ShipToCompany = txtShipToCompany.Text.ToString().Trim().Replace("–", "-");
                objEL.ShipToConsigneeRefNumber = txtConsigneeRefNo.Text.ToString().Trim();
                objEL.ShipToAddress = txtToAddress.Text.ToString().Trim();
                objEL.ShipToCity = txtToCity.Text.ToString().Trim();                
                objEL.ShipToPostalCode = txtToPostalCode.Text.ToString().Trim();
                if (drpToCountry.SelectedIndex > 0)
                {
                    objEL.ShipToCountry = drpToCountry.SelectedItem.Text;
                }
                else
                {
                    objEL.ShipToCountry = "";
                }
                objEL.ShipToContact = txtToContact.Text.ToString().Trim();
                objEL.ShipToPhone = txtToPhone.Text.ToString().Trim();
                objEL.ShipToFax = txtToFax.Text.ToString().Trim();                
                objEL.ShipToDate = Convert.ToDateTime(txtDeliveryDate.Text.ToString().Trim());
                if (rbInsuranceRequired.Items[0].Selected == true)
                {
                    objEL.Insured = 0;
                }
                else
                {
                    objEL.Insured = 1;
                }
                if (txtInsuredValue.Text.ToString() != "")
                {
                    objEL.InsuredValue = IsDecimal(txtInsuredValue.Text.ToString().Trim());
                }                
                
                objEL.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));
                objEL.StatusCode = "PND";
                if (HidWarehouseid.Value != null && HidWarehouseid.Value != "" && HidWarehouseid.Value != "0")
                {                    
                    objEL.ShipToLocationId = IsInteger(HidWarehouseid.Value);
                    objEL.PickupRequestTypeWarehouse = 1;
                    lblWAreHoseLocationId.Text = HidWarehouseid.Value;
                }
                else
                {
                    objEL.ShipToLocationId = 0;
                    objEL.PickupRequestTypeWarehouse = 0;
                    lblWAreHoseLocationId.Text = "0";
                }
                objEL.PickupRequestType = 2;

                // Add Userlocation for future use
                if (chkSaveShipFromInfo.Checked)
                {
                    UserLocationEL objUserLocationEL = new UserLocationEL();
                    objUserLocationEL.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));
                    objUserLocationEL.CompanyName = txtShipFromCompany.Text.ToString().Trim();
                    objUserLocationEL.Address = txtFromAddress.Text.ToString().Trim();
                    objUserLocationEL.City = txtFromCity.Text.ToString().Trim();
                    if (drpFromState.SelectedIndex > 0)
                    {
                        objUserLocationEL.StateId = IsInteger(drpFromState.SelectedValue);
                    }
                    objUserLocationEL.PostalCode = txtFromPostalCode.Text.ToString().Trim();
                    if (drpFromCountry.SelectedIndex > 0)
                    {
                        objUserLocationEL.CountryId = IsInteger(drpFromCountry.SelectedValue);
                    }
                    objUserLocationEL.ContactName = txtFromContact.Text.ToString().Trim();
                    objUserLocationEL.ContactPhone = txtFromPhone.Text.ToString().Trim();
                    objUserLocationEL.ContactFax = txtFromFax.Text.ToString().Trim();
                    objUserLocationEL.ContactEmail = txtFromEmail.Text.ToString().Trim();
                    objUserLocationEL.ExportEIN = txtExporterEIN.Text.ToString().Trim();
                    if (chkPartyTransaction.Checked)
                    {
                        objUserLocationEL.PartiesToTransaction = 1;
                    }
                    Boolean statUL = UserLocationBL.AddLocationIntl(objUserLocationEL);
                }
                if (chkSaveShipToInfo.Checked)
                {
                    UserLocationEL objUserLocationEL = new UserLocationEL();
                    objUserLocationEL.UserId = IsInteger(Convert.ToString(Session["cacheUserId"]));
                    objUserLocationEL.CompanyName = txtShipToCompany.Text.ToString().Trim().Replace("–", "-");
                    objUserLocationEL.Address = txtToAddress.Text.ToString().Trim();
                    objUserLocationEL.City = txtToCity.Text.ToString().Trim();                    
                    objUserLocationEL.PostalCode = txtToPostalCode.Text.ToString().Trim();
                    if (drpToCountry.SelectedIndex > 0)
                    {
                        objUserLocationEL.CountryId = IsInteger(drpToCountry.SelectedValue);
                    }
                    objUserLocationEL.ContactName = txtToContact.Text.ToString().Trim();
                    objUserLocationEL.ContactPhone = txtToPhone.Text.ToString().Trim();
                    objUserLocationEL.ContactFax = txtToFax.Text.ToString().Trim();
                    objUserLocationEL.ExportIntermediateConsignee = txtIntermediateConsignee.Text.ToString().Trim();
                    objUserLocationEL.ExportAddress = txtAddress.Text.ToString().Trim();
                    objUserLocationEL.ExportCity = txtCity.Text.ToString().Trim();
                    objUserLocationEL.ExportPostalCode = txtPostalCode.Text.ToString().Trim();
                    if (drpCountry.SelectedIndex > 0)
                    {
                        objUserLocationEL.ExportCountryId = IsInteger(drpCountry.SelectedValue);
                    }
                    objUserLocationEL.ExportIntermediateContact = txtContactName.Text.ToString().Trim();
                    objUserLocationEL.ExportIntermediatePhone = txtTelephone.Text.ToString().Trim();
                    Boolean statUL = UserLocationBL.AddLocationIntl(objUserLocationEL);
                }
                // Add Userlocation for future use

                Boolean stat = PickupRequestBL.AddPickupRequest(objEL);
                ViewState["PickupReuestId"] = objEL.PickupRequestId;         
                DataSet dsPickupRequest = PickupRequestBL.FetchAllPickupRequest(IsInteger(ViewState["PickupReuestId"].ToString()));                    
                string strtracking_no = Convert.ToString(dsPickupRequest.Tables[0].Rows[0]["GLSTrackingNumber"]);
                if (strtracking_no.Trim() == "")
                {
                    //AdminEmailNewRequest(ConfigurationManager.AppSettings["AdminEmail"].Trim());
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "skidpop", "Openskidpop(" + ViewState["PickupReuestId"].ToString() + ");", true);
                btnSave.Visible = false;
                btnHUnit.Visible = true;
                tblRequestedService.Visible = true;
                tabInsuranceRequired.Visible =true;              
                tblSpecialServices.Visible = true;
                btnContinue.Visible = true;
                cvalidSkids.Enabled = true;
                if (Session["cacheUserCode"].ToString() == "1000" || Session["cacheUserCode"].ToString() == "7000")
                {
                    tblShipmentCharges.Visible = true;
                    tblShipmentInfo.Visible = true;
                    tblBillingInfo.Visible = true;
                    btnAccept.Visible = true;
                }

                else
                {
                    tblShipmentCharges.Visible = false;
                    tblShipmentInfo.Visible = false;
                    tblBillingInfo.Visible = false;
                    btnAccept.Visible = false;
                    btnContinue.Text = "Submit";
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please enter proper date";
            }
        }
        #endregion

        #region protected void btnHUnit_Click(object sender, EventArgs e)
        protected void btnHUnit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["skid"] != null)
            {
                if (hidPickupRequestTypeWarehouse.Value == "2" || hidPickupRequestTypeWarehouse.Value == "3")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "skidpop", "OpenskidpopChooseWHlistwithoutSkid(" + ViewState["PickupReuestId"].ToString() + ");", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "skidpop", "Openskidpop(" + ViewState["PickupReuestId"].ToString() + ");", true);
            }
        }
        #endregion

        #region protected void btnEditHandlingUnit_Click(object sender, EventArgs e)
        protected void btnEditHandlingUnit_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;            
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hupop", "OpenHupop(" + btnSender.CommandArgument + ");", true);
        }
        #endregion

        #region protected void btnAddShipmentItems_Click(object sender, EventArgs e)
        protected void btnAddShipmentItems_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;            
            string strPickReqId = ((Label)btnSender.NamingContainer.FindControl("lblPickReqidHU")).Text;
            if (Request.QueryString["ChooseWHlist"] != null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "skidpopwh", "OpenChooseWHlistShipmentItems(" + ViewState["PickupReuestId"].ToString() + "," + Request.QueryString["skid"].ToString() + ");", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hupop", "OpenAddShippop(" + strPickReqId + "," + btnSender.CommandArgument + ");", true);
            }
        }
        #endregion

        #region protected void btnEditShipment_Click(object sender, EventArgs e)
        protected void btnEditShipment_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            string strShipSkidId = ((Label)btnSender.NamingContainer.FindControl("lblShipSkidId")).Text;
            string strPickReqId = ((Label)btnSender.NamingContainer.FindControl("lblPickReqid")).Text;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shippop", "OpenShippop(" + strPickReqId + "," + strShipSkidId + "," + btnSender.CommandArgument + ");", true);
        }
        #endregion

        #region protected void btnDeleteHandlingUnit_Click(object sender, EventArgs e)
        protected void btnDeleteHandlingUnit_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            bool stat = HandlingUnitBL.DeleteHandlingUnit(IsInteger(btnSender.CommandArgument));
            if (stat == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The handling unit has been deleted Successfully.";
                FetchSkids();
                FetchShipments();
            }
        }
        #endregion

        #region protected void btnDeleteShipment_Click(object sender, EventArgs e)
        protected void btnDeleteShipment_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;            
            Boolean stat = ShipmentItemsBL.DeleteShipment(IsInteger(btnSender.CommandArgument));
            if (stat == true)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The shipment has been deleted Successfully.";
                FetchSkids();
                FetchShipments();
            }
        }
        #endregion

        #region protected void gridHandlingUnits_PageIndexChanging(object sender, GridViewPageEventArgs e)
        protected void gridHandlingUnits_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        #endregion

        #region protected void gridShipments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        protected void gridShipments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        #endregion

        private int ishppedwt = 0;

        #region protected void gridHandlingUnits_RowDataBound(object sender, GridViewRowEventArgs e)
        protected void gridHandlingUnits_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strWeight = ((Label)e.Row.FindControl("lblWeight")).Text.ToString();
                if (strWeight != "")
                {
                    ishppedwt = ishppedwt + Convert.ToInt32(((Label)e.Row.FindControl("lblWeight")).Text.ToString());
                }
                string skidid= ((ImageButton)e.Row.FindControl("btnEditSkids")).CommandArgument;
                string trackingno = ((Label)e.Row.FindControl("lblTrackingNo")).Text;
                string unitid = "";
                if (Convert.ToInt32(skidid) > 99)
                {
                    skidid = skidid.Substring(skidid.Length - 2);
                }
                if (trackingno != null && trackingno != "")
                {
                    unitid = skidid + trackingno;
                }
                else
                {
                    unitid = skidid;
                }
                ((Label)e.Row.FindControl("lblUnitId")).Text = unitid;
            }
            ViewState["shppedwt"] = ishppedwt;
        }
        #endregion

        private int ipieces = 0;

        #region protected void gridShipments_RowDataBound(object sender, GridViewRowEventArgs e)
        protected void gridShipments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strPiece = ((Label)e.Row.FindControl("lblPackageQuantity")).Text.ToString();
                if (strPiece != "")
                {
                    ipieces = ipieces + Convert.ToInt32(((Label)e.Row.FindControl("lblPackageQuantity")).Text.ToString());
                }
                string skidid = ((Label)e.Row.FindControl("lblShipSkidId")).Text;
                string trackingno = ((Label)e.Row.FindControl("lblSTrackingNo")).Text;
                string unitid = "";
                if (Convert.ToInt32(skidid) > 99)
                {
                    skidid = skidid.Substring(skidid.Length - 2);
                }
                if (trackingno != null && trackingno != "")
                {
                    unitid = skidid + trackingno;
                }
                else
                {
                    unitid = skidid;
                }
                ((Label)e.Row.FindControl("lblShipUnitId")).Text = unitid;
            }
            ViewState["shipPiece"] = ipieces;
        }
        #endregion

        #region protected void FetchpickupLocationWh()
        protected void FetchpickupLocationWh()
        {
            // "pid" is the old request id coming from View or Ship Warehouse Items
            int intPickupreqid = Convert.ToInt32(Request.QueryString["pid"].ToString());
            DataSet ds = PickupRequestBL.FetchSinglePickupRequest(intPickupreqid);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtShipFromCompany.Text = ds.Tables[0].Rows[0]["ShipToCompany"].ToString();
                txtShipperRefNo.Text = ds.Tables[0].Rows[0]["ShipToConsigneeRefNumber"].ToString();
                txtFromAddress.Text = ds.Tables[0].Rows[0]["ShipToAddress"].ToString();
                txtFromCity.Text = ds.Tables[0].Rows[0]["ShipToCity"].ToString();
                if (ds.Tables[0].Rows[0].IsNull("ShipToState") == false && ds.Tables[0].Rows[0]["ShipToState"].ToString() != "" && ds.Tables[0].Rows[0]["ShipToState"].ToString() != "0")
                {
                    for (int i = 0; i < drpFromState.Items.Count; i++)
                    {
                        if (drpFromState.Items[i].Text == ds.Tables[0].Rows[0]["ShipToState"].ToString())
                        {
                            drpFromState.ClearSelection();
                            drpFromState.Items[i].Selected = true;
                        }
                    }
                }
                txtFromPostalCode.Text = ds.Tables[0].Rows[0]["ShipToPostalCode"].ToString();
                if (ds.Tables[0].Rows[0].IsNull("ShipToCountry") == false && ds.Tables[0].Rows[0]["ShipToCountry"].ToString() != "" && ds.Tables[0].Rows[0]["ShipToCountry"].ToString() != "0")
                {
                    for (int i = 0; i < drpFromCountry.Items.Count; i++)
                    {
                        if (drpFromCountry.Items[i].Text == ds.Tables[0].Rows[0]["ShipToCountry"].ToString())
                        {
                            drpFromCountry.ClearSelection();
                            drpFromCountry.Items[i].Selected = true;
                        }
                    }
                }
                txtFromContact.Text = ds.Tables[0].Rows[0]["ShipToContact"].ToString();
                txtFromPhone.Text = ds.Tables[0].Rows[0]["ShipToPhone"].ToString();
                txtFromFax.Text = ds.Tables[0].Rows[0]["ShipToFax"].ToString();                
                if (ds.Tables[0].Rows[0].IsNull("GLSBillCompany") == false && ds.Tables[0].Rows[0]["GLSBillCompany"].ToString() != "")
                {
                    for (int i = 0; i < drpBillToCompany.Items.Count; i++)
                    {
                        if (drpBillToCompany.Items[i].Text == ds.Tables[0].Rows[0]["GLSBillCompany"].ToString())
                        {
                            drpBillToCompany.Items[i].Selected = true;
                        }
                    }
                }
                txtBillToAddress.Text = ds.Tables[0].Rows[0]["GLSBillAddress"].ToString();
                txtBillToCity.Text = ds.Tables[0].Rows[0]["GLSBillCity"].ToString();
                txtBillToState.Text = ds.Tables[0].Rows[0]["GLSBillStateName"].ToString();
                txtBillToZip.Text = ds.Tables[0].Rows[0]["GLSBillPostalCode"].ToString();
                txtBillToCountry.Text = ds.Tables[0].Rows[0]["GLSBillCountryName"].ToString();                
            }

            ds = null;
            if (Request.QueryString["id"] != null)
            {                
                ds = PickupRequestBL.FetchSinglePickupRequest(Convert.ToInt32(ViewState["PickupReuestId"].ToString()));
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0].IsNull("PickupRequestTypeWarehouse") == false)
                    {
                        hidPickupRequestTypeWarehouse.Value = Convert.ToString(ds.Tables[0].Rows[0]["PickupRequestTypeWarehouse"]);
                    }
                    if (ds.Tables[0].Rows[0].IsNull("ShipFromEmail") == false)
                    {
                        txtFromEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ShipFromEmail"]);
                    }
                    if (ds.Tables[0].Rows[0].IsNull("ShipFromLocationId") == false)
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["ShipFromLocationId"]) == 0)
                        {
                            hidFromLocationid.Value = "0";
                        }
                        else
                        {
                            hidFromLocationid.Value = Convert.ToString(ds.Tables[0].Rows[0]["ShipFromLocationId"]);
                        }
                    }
                    else
                    {
                        hidFromLocationid.Value = "0";
                    }
                }
            }

            txtShipFromCompany.ReadOnly = true;
            txtFromAddress.ReadOnly = true;
            txtFromCity.ReadOnly = true;
            txtFromPostalCode.ReadOnly = true;
            txtFromContact.ReadOnly = true;
            txtFromPhone.ReadOnly = true;
            txtFromFax.ReadOnly = true;            
        }
        #endregion

        #region protected void UpdateMailToAdmin(string strToMail)
        //Mail goes to admin at time of updating
        protected void UpdateMailToAdmin(string strToMail)
        {
            StringBuilder sbMailBody = new StringBuilder();
            sbMailBody.Append("<table><tr><td>Below is a summary of items updated for shipping request along with ");
            sbMailBody.Append("anticipated delivery date.</td></tr> ");            
            sbMailBody.Append("<tr><td><b>Estimated arrival Date:</b>" + txtDeliveryDate.Text.ToString().Trim() + "</td></tr>");
            sbMailBody.Append("<tr><td><table border='1' cellspacing='3' cellpadding='3'><tr><td>Unit Id</td>");
            sbMailBody.Append("<td>Pkg Type</td><td>L</td><td>W</td>");
            sbMailBody.Append("<td>H</td><td>Weight</td></tr>");
            for (int i = 0; i < gridHandlingUnits.Rows.Count; i++)
            {
                sbMailBody.Append("<tr><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblUnitId")).Text);
                sbMailBody.Append("</td><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblHandlingUnit")).Text);
                sbMailBody.Append("</td><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblLength")).Text);
                sbMailBody.Append("</td><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblWidth")).Text);
                sbMailBody.Append("</td><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblHeight")).Text);
                sbMailBody.Append("</td><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblWeight")).Text);
                sbMailBody.Append("</td></tr>");
            }
            sbMailBody.Append("</table></td></tr></table>");
            //CommonBL.sendMailInHtmlFormat("admin@impact-scs.com", strToMail, "Request Updates", sbMailBody.ToString());
            CommonBL.sendMailInHtmlFormat("ops@3plintegration.com", strToMail, "Request Updates", sbMailBody.ToString());
        }
        #endregion

        #region protected void WhRptPreAlert(string strToMail, string TrackingNo)
        //Warehouse reciept pre alert.Mail goes to mail id coressding to destination warehouse
        protected void WhRptPreAlert(string strToMail, string TrackingNo)
        {
            StringBuilder sbMailBody = new StringBuilder();
            sbMailBody.Append("<table><tr><td>Below is a summary of items being sent to your warehouse location along with ");
            sbMailBody.Append("anticipated delivery date. An updated status of delivery date can be obtained by");
            //sbMailBody.Append(" accessing our website at www.impact-scs.com and entering the below reference tracking");
            sbMailBody.Append(" accessing our website at www.3plintegration.com and entering the below reference tracking");
            sbMailBody.Append("number in the provided tracking window. If you have any questions, please contact us at :</td></tr> ");
            sbMailBody.Append("<tr><td>3PL Integration, LLC<br />");
            sbMailBody.Append("900 Route 134, Ste 2-17<br />");
            sbMailBody.Append("S. Dennis, MA 02660</td></tr>");            
            //sbMailBody.Append("<tr><td>Tel: 508.444.0332, Fax: 508.385.6836<br />Email: admin@impact-scs.com</td></tr>");
            sbMailBody.Append("<tr><td>Tel: 508.210.2164, Fax: 508.210.2158<br />Email: ops@3plintegration.com</td></tr>");
            sbMailBody.Append("<tr><td><b>3PL Integration Tracking Number:</b>" + TrackingNo + "</td></tr>");
            sbMailBody.Append("<tr><td><b>Estimated arrival Date:</b>" + txtDeliveryDate.Text.ToString().Trim() + "</td></tr>");
            sbMailBody.Append("<tr><td><table border='1' cellspacing='3' cellpadding='3'><tr><td>Unit Id</td>");
            sbMailBody.Append("<td>Pkg Type</td><td>L</td><td>W</td>");
            sbMailBody.Append("<td>H</td><td>Weight</td></tr>");           
           
            for (int i = 0; i < gridHandlingUnits.Rows.Count; i++)
            {                
                sbMailBody.Append("<tr><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblUnitId")).Text);
                sbMailBody.Append("</td><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblHandlingUnit")).Text);
                sbMailBody.Append("</td><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblLength")).Text);
                sbMailBody.Append("</td><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblWidth")).Text);
                sbMailBody.Append("</td><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblHeight")).Text);
                sbMailBody.Append("</td><td>");
                sbMailBody.Append(((Label)gridHandlingUnits.Rows[i].FindControl("lblWeight")).Text);
                sbMailBody.Append("</td></tr>");                
            }
            sbMailBody.Append("</table></td></tr></table>");
            //CommonBL.sendMailInHtmlFormat("admin@impact-scs.com", strToMail, "Pending Warehouse Receipt", sbMailBody.ToString());
            CommonBL.sendMailInHtmlFormat("ops@3plintegration.com", strToMail, "Pending Warehouse Receipt", sbMailBody.ToString());
        }
        #endregion

        #region protected void WhPickListAlert(string strToMail)
        //Warehouse pick list alert.Mail goes to  mail id coresponding to from warehouse
        protected void WhPickListAlert(string strToMail)
        {
            StringBuilder sbMailBody = new StringBuilder();
            sbMailBody.Append("<table><tr><td>Below is a pick list of items to be shipped from your warehouse.");
            sbMailBody.Append("The 3PL Integration tracking number and ship date/pickup window, along with ");
            sbMailBody.Append("the pickup carrier,are also included.The shipping documents can be ");
            //sbMailBody.Append("printed by accessing our website at www.impact-scs.com entering the");
            sbMailBody.Append("printed by accessing our website at www.3plintegration.com entering the");
            sbMailBody.Append(" tracking number in the tracking window and selecting ");
            sbMailBody.Append("'View and Print Shipping Documents' at the bottom of the web page.");
            sbMailBody.Append("Should you have any questions,please contact us at:</td></tr>");
            sbMailBody.Append("<tr><td>3PL Integration, LLC<br />");
            sbMailBody.Append("900 Route 134, Ste 2-17<br />");
            sbMailBody.Append("S. Dennis, MA 02660</td></tr>");            
            //sbMailBody.Append("<tr><td>Tel: 508.444.0332, Fax: 508.385.6836<br />Email: admin@impact-scs.com<br /></td></tr>");
            sbMailBody.Append("<tr><td>Tel: 508.210.2164, Fax: 508.210.2158<br />Email: ops@3plintegration.com<br /></td></tr>");
            string strTrackingNo = "";
            DataSet ds = null;
            if (Request.QueryString["skid"] != null)
            {
                ds = ShipmentItemsBL.FetchShipmentForMailList(IsInteger(Request.QueryString["skid"].ToString()));
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0].IsNull("GLSTrackingNumber") == false)
                    {
                        strTrackingNo = Convert.ToString(ds.Tables[0].Rows[0]["GLSTrackingNumber"]);
                    }
                }
            }
            else
            {
                if (gridHandlingUnits.Rows.Count > 0)
                {
                    ds = ShipmentItemsBL.FetchShipmentForMailList(IsInteger(((ImageButton)gridHandlingUnits.Rows[0].FindControl("btnEditSkids")).CommandArgument));
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0].IsNull("GLSTrackingNumber") == false)
                        {
                            strTrackingNo = Convert.ToString(ds.Tables[0].Rows[0]["GLSTrackingNumber"]);
                        }
                    }
                }
            }
            sbMailBody.Append("<tr><td><b>3PL Integration Tracking Number:</b>" + strTrackingNo + "<br /><br /></td></tr>");
            sbMailBody.Append("<tr><td><b>Ship Date:</b>" + txtPickUpDate.Text.ToString().Trim() + "<br />");
            sbMailBody.Append("<b>Estimated Pickup Time:</b>" + drpLatestPickup.SelectedItem.Text + "<br />");
            sbMailBody.Append("<b>Pickup Carrier:</b>" + txtPickupCarrier.Text.ToString().Trim() + "<br />");
            sbMailBody.Append("<b>Requested Delivery Date:</b>" + txtDeliveryDate.Text.ToString().Trim() + "<br /></td></tr>");
            sbMailBody.Append("<tr><td>Special Instructions:" + txtareaSpecialInTructions.Value.ToString().Trim() + "</td></tr>");            
            sbMailBody.Append("<tr><td align='center'><b>Pick List</b></td></tr>");
            
            int totalWeight = 0;
            if (Request.QueryString["skid"] != null)
            {               
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string skidid = ds.Tables[0].Rows[i]["SkidId"].ToString();
                        string skidid_WI = ds.Tables[0].Rows[i]["SkidId_WI"].ToString();
                        string strTrackingNo_WI = ds.Tables[0].Rows[i]["ISCSTrackingNumber_WI"].ToString();
                        string unitid_WI = "";
                        string unitid = "";
                        if (IsInteger(skidid) > 99)
                        {
                            skidid = skidid.Substring(skidid.Length - 2);
                        }

                        if (strTrackingNo != null && strTrackingNo != "")
                        {
                            unitid = skidid + strTrackingNo;
                        }
                        else
                        {
                            unitid = skidid;
                        }
                        if (IsInteger(skidid_WI) > 99)
                        {
                            skidid_WI = skidid_WI.Substring(skidid_WI.Length - 2);
                        }

                        if (strTrackingNo_WI != null && strTrackingNo_WI != "")
                        {
                            unitid_WI = skidid_WI + strTrackingNo_WI;
                        }
                        else
                        {
                            unitid_WI = skidid_WI;
                        }
                        string strHandlingUnitType = ds.Tables[0].Rows[i]["HandlingUnitType"].ToString();
                        sbMailBody.Append("<tr><td><b>Handling Unit:</b>" + strHandlingUnitType + " <b>ID Number:</b>" + unitid + "</td></tr>");
                        sbMailBody.Append("<tr><td><table border='0' cellspacing='3' cellpadding='3'><tr>");
                        sbMailBody.Append("<td><b>Qty</b></td><td><b>Pkg Type</b></td><td><b>Part No</b></td><td><b>Lot No.</b></td><td><b>Description</b></td>");
                        sbMailBody.Append("<td><b>Location</b></td><td><b>Weight</b></td></tr>");

                        sbMailBody.Append("<tr><td>");
                        
                        sbMailBody.Append(ds.Tables[0].Rows[i]["PackageQuantity_SI"].ToString());
                        sbMailBody.Append("</td><td>");
                        sbMailBody.Append(ds.Tables[0].Rows[i]["PackageType_SI"].ToString());
                        sbMailBody.Append("</td><td>");
                        sbMailBody.Append(ds.Tables[0].Rows[i]["PartNumber_SI"].ToString());
                        sbMailBody.Append("</td><td>");
                        sbMailBody.Append(ds.Tables[0].Rows[i]["LotNumber_SI"].ToString());
                        sbMailBody.Append("</td><td>");
                        sbMailBody.Append(ds.Tables[0].Rows[i]["description_Si"].ToString());
                        sbMailBody.Append("</td><td>");
                        sbMailBody.Append(unitid_WI);
                        sbMailBody.Append("</td><td>");
                        sbMailBody.Append(ds.Tables[0].Rows[i]["Weight_SI"].ToString());
                        sbMailBody.Append("</td></tr>");
                        totalWeight = totalWeight + IsInteger(ds.Tables[0].Rows[i]["Weight_SI"].ToString());
                    }
                    sbMailBody.Append("<tr><td></td><td></td><td></td><td></td><td><b>Total Weight:</b></td><td>");
                    sbMailBody.Append(totalWeight);
                    sbMailBody.Append("</td></tr>");
                }
            }
            else
            {
                if (gridHandlingUnits.Rows.Count > 0)
                {
                    for (int i = 0; i < gridHandlingUnits.Rows.Count; i++)
                    {
                        ds = ShipmentItemsBL.FetchShipmentForMailList(IsInteger(((ImageButton)gridHandlingUnits.Rows[i].FindControl("btnEditSkids")).CommandArgument));
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                //string skidid = ds.Tables[0].Rows[i]["SkidId"].ToString();
                                string skidid = ds.Tables[0].Rows[j]["SkidId"].ToString();
                                //string skidid_WI = ds.Tables[0].Rows[i]["SkidId_WI"].ToString();
                                string skidid_WI = ds.Tables[0].Rows[j]["SkidId_WI"].ToString();
                                //string strTrackingNo_WI = ds.Tables[0].Rows[i]["ISCSTrackingNumber_WI"].ToString();
                                string strTrackingNo_WI = ds.Tables[0].Rows[j]["ISCSTrackingNumber_WI"].ToString();
                                string unitid_WI = "";
                                string unitid = "";
                                if (IsInteger(skidid) > 99)
                                {
                                    skidid = skidid.Substring(skidid.Length - 2);
                                }

                                if (strTrackingNo != null && strTrackingNo != "")
                                {
                                    unitid = skidid + strTrackingNo;
                                }
                                else
                                {
                                    unitid = skidid;
                                }
                                if (IsInteger(skidid_WI) > 99)
                                {
                                    skidid_WI = skidid_WI.Substring(skidid_WI.Length - 2);
                                }

                                if (strTrackingNo_WI != null && strTrackingNo_WI != "")
                                {
                                    unitid_WI = skidid_WI + strTrackingNo_WI;
                                }
                                else
                                {
                                    unitid_WI = skidid_WI;
                                }
                                //string strHandlingUnitType = ds.Tables[0].Rows[i]["HandlingUnitType"].ToString();
                                string strHandlingUnitType = ds.Tables[0].Rows[j]["HandlingUnitType"].ToString();
                                sbMailBody.Append("<tr><td><b>Handling Unit:</b>" + strHandlingUnitType + " <b>ID Number:</b>" + unitid + "</td></tr>");
                                sbMailBody.Append("<tr><td><table border='0' cellspacing='3' cellpadding='3'><tr>");
                                sbMailBody.Append("<td><b>Qty</b></td><td><b>Pkg Type</b></td><td><b>Part No</b></td><td><b>Lot No.</b></td><td><b>Description</b></td>");
                                sbMailBody.Append("<td><b>Location</b></td><td><b>Weight</b></td></tr>");

                                sbMailBody.Append("<tr><td>");
                                
                                sbMailBody.Append(ds.Tables[0].Rows[j]["PackageQuantity_SI"].ToString());
                                sbMailBody.Append("</td><td>");
                                //sbMailBody.Append(ds.Tables[0].Rows[i]["PackageType_SI"].ToString());
                                sbMailBody.Append(ds.Tables[0].Rows[j]["PackageType_SI"].ToString());
                                sbMailBody.Append("</td><td>");
                                sbMailBody.Append(ds.Tables[0].Rows[j]["PartNumber_SI"].ToString());
                                sbMailBody.Append("</td><td>");
                                //sbMailBody.Append(ds.Tables[0].Rows[i]["LotNumber_SI"].ToString());
                                sbMailBody.Append(ds.Tables[0].Rows[j]["LotNumber_SI"].ToString());
                                sbMailBody.Append("</td><td>");
                                sbMailBody.Append(ds.Tables[0].Rows[j]["description_Si"].ToString());
                                sbMailBody.Append("</td><td>");
                                sbMailBody.Append(unitid_WI);
                                sbMailBody.Append("</td><td>");
                                sbMailBody.Append(ds.Tables[0].Rows[j]["Weight_SI"].ToString());
                                sbMailBody.Append("</td></tr>");
                                //totalWeight = totalWeight + IsInteger(ds.Tables[0].Rows[i]["Weight_SI"].ToString());
                                totalWeight = totalWeight + IsInteger(ds.Tables[0].Rows[j]["Weight_SI"].ToString());
                            }
                        }
                    }

                    sbMailBody.Append("<tr><td></td><td></td><td></td><td></td><td><b>Total Weight:</b></td><td>");
                    sbMailBody.Append(totalWeight);
                    sbMailBody.Append("</td></tr>");
                }
            }
            sbMailBody.Append("</table></td></tr></table>");
            //CommonBL.sendMailInHtmlFormat("admin@impact-scs.com", strToMail, "Pending Shipment from your warehouse", sbMailBody.ToString());
            CommonBL.sendMailInHtmlFormat("ops@3plintegration.com", strToMail, "Pending Shipment from your warehouse", sbMailBody.ToString());
        }
        #endregion

        #region protected void RequestAcceptByISCS(string strTrackingNo, string strToMail)
        //Mail goes to corresponding mail id of a request
        protected void RequestAcceptByISCS(string strTrackingNo, string strToMail, string InitiatorEmail, decimal dGLSTotalSellRate, int iGLSAccountId, int InitiatorUserTypeID)
        {
            StringBuilder sbMailBody = new StringBuilder();            
            sbMailBody.Append("<table><tr><td>Your Pickup request of " + ViewState["shipPiece"].ToString() + " pieces @ " + ViewState["shppedwt"].ToString() + " lbs going from:");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtShipFromCompany.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtFromAddress.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtFromCity.Text.ToString().Trim() + "," + drpFromState.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtFromPostalCode.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + drpFromCountry.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />To:");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtShipToCompany.Text.ToString().Trim().Replace("–", "-"));
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtToAddress.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtToCity.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");            
            sbMailBody.Append("<tr><td>" + txtToPostalCode.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + drpToCountry.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />has been accepted by 3PL Integration.");
            DataSet dsCompareAccountCodes = UserBL.CompareAccountCodes(InitiatorEmail);
            int ShipperAccountCodeId = 0;
            if (dsCompareAccountCodes != null && dsCompareAccountCodes.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsCompareAccountCodes.Tables[0].Rows.Count; i++)
                {
                    ShipperAccountCodeId=IsInteger(Convert.ToString(dsCompareAccountCodes.Tables[0].Rows[0]["AccountCodeId"]));
                    if (ShipperAccountCodeId == iGLSAccountId)
                    {
                        break;
                    }
                }
            }
            if (InitiatorUserTypeID == 5 || InitiatorUserTypeID == 8)
            {
                if (ShipperAccountCodeId == iGLSAccountId)
                {
                    if (dGLSTotalSellRate > 0)
                    {
                        sbMailBody.Append("The quoted price for this <br />service is $" + dGLSTotalSellRate.ToString() + ".");
                    }
                }
            }
            sbMailBody.Append("<br />Your tracking number is: " + strTrackingNo);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />Please review the following shipment summary:");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>Pick up Location:");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtShipFromCompany.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtFromAddress.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtFromCity.Text.ToString().Trim() + "," + drpFromState.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtFromPostalCode.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + drpFromCountry.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />Requested pick up Date: " + txtPickUpDate.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>Requested pick up Time: range " + drpReadyTime.SelectedItem.Text + " to " + drpLatestPickup.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />Delivery Location:");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtShipToCompany.Text.ToString().Trim().Replace("–", "-"));
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtToAddress.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtToCity.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");            
            sbMailBody.Append("<tr><td>" + txtToPostalCode.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + drpToCountry.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />Requested delivery Date: " + txtDeliveryDate.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            if (rbInternAir.Checked == true)
            {
                sbMailBody.Append("<tr><td>Service Level: " + drpInternAirTypeService2.SelectedValue);
            }
            else if (rbInternOcean.Checked == true)
            {
                sbMailBody.Append("<tr><td>Service Level: " + drpInternOceanTypeService2.SelectedValue);
            }
            else
            {
                //sbMailBody.Append("<tr><td>Service Level: Impact Preferred");
                sbMailBody.Append("<tr><td>Service Level: 3PL Preferred");
            }
            sbMailBody.Append("</td></tr>");            
            sbMailBody.Append("<tr><td><br />Special Instructions: " + txtareaSpecialInTructions.Value.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />The Carrier for this shipment will be: " + txtPickupCarrier.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />Thank you for using 3PL Integration for your shipping needs: ");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />Use the hyperlink to print the shipping documents. ");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>THESE DOCUMENTS MUST ACCOMPANY THE SHIPMENT AND BE PRESENTED TO THE DRIVER AT PICK UP TO ENSURE PROPER 3RD PARTY BILLING.");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>NOTE: you must be logged into the system first for the links to work ");
            sbMailBody.Append("</td></tr>");           
            string strUrlBill = strMainURL + "/Admin/BillOfLading_Vics.aspx?PickupRequestId=" + SecurityUtils.UrlEncode(ViewState["PickupReuestId"].ToString());
            sbMailBody.Append("<tr><td><a href='" + strUrlBill + "'>Shipment Bill</a>");
            sbMailBody.Append("</td></tr>");
            //sbMailBody.Append("<tr><td><br />To view the status of this shipment go to : http://www.impact-scs.com and click the Log in link. ");
            sbMailBody.Append("<tr><td><br />To view the status of this shipment go to : http://www.3plintegration.com and click the Log in link. ");
            sbMailBody.Append("</td></tr>");
            //sbMailBody.Append("<tr><td><br />If you do not have a password to the http://www.impact-scs.com website, you may obtain a copy of the BOL where prompted to \"TRACK SHIPMENT\",  by entering the tracking number, and click option entitled  \"View and Print Shipping Documents\". ");
            //sbMailBody.Append("<tr><td><br />If you do not have a password, you can obtain a copy of the BOL by logging on to http://www.impact-scs.com and where prompted to \"Track a Shipment,\" enter your tracking number.  Once you open the tracking page, select \"View and Print Shipping Documents\" to print the BOL. ");
            sbMailBody.Append("<tr><td><br />If you do not have a password, you can obtain a copy of the BOL by logging on to http://www.3plintegration.com and where prompted to \"Track a Shipment,\" enter your tracking number.  Once you open the tracking page, select \"View and Print Shipping Documents\" to print the BOL. ");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />3PL Integration, LLC ");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>Telephone: 508.210.2164");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>Fax: 508.210.2158");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>900 Route 134, Ste 2-17,");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>S. Dennis, MA 02660");
            sbMailBody.Append("</td></tr>");
            //sbMailBody.Append("<tr><td>General Information: info@impact-scs.com");
            sbMailBody.Append("<tr><td>General Information: ops@3plintegration.com");
            sbMailBody.Append("</td></tr>");
            //sbMailBody.Append("<tr><td>Sales: info@impact-scs.com");
            sbMailBody.Append("<tr><td>Sales: ops@3plintegration.com");
            sbMailBody.Append("</td></tr>");
            //sbMailBody.Append("<tr><td>Customer support: info@impact-scs.com");
            sbMailBody.Append("<tr><td>Customer support: ops@3plintegration.com");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("</table>");
            if (Session["userEmail"] != null)
            {
                if (InitiatorEmail != strToMail)
                {
                    //CommonBL.sendMailInHtmlFormat("admin@impact-scs.com", InitiatorEmail+","+strToMail, "Impact Supply Chain Solution Pickup Request Confirmation", sbMailBody.ToString());
                    // Overloaded
                    //CommonBL.sendMailInHtmlFormat("admin@impact-scs.com", InitiatorEmail, strToMail, "Impact Supply Chain Solution Pickup Request Confirmation", sbMailBody.ToString());
                    CommonBL.sendMailInHtmlFormat("ops@3plintegration.com", InitiatorEmail, strToMail, "3PL Integration Pickup Request Confirmation", sbMailBody.ToString());
                }
                else
                {
                    //CommonBL.sendMailInHtmlFormat("admin@impact-scs.com", strToMail, "Impact Supply Chain Solution Pickup Request Confirmation", sbMailBody.ToString());
                    CommonBL.sendMailInHtmlFormat("ops@3plintegration.com", strToMail, "3PL Integration Pickup Request Confirmation", sbMailBody.ToString());
                }
            }
        }
        #endregion

        #region protected void AdminEmailNewRequest()
        //Mail goes to corresponding mail id of a request
        protected void AdminEmailNewRequest(string strToMail)
        {
            StringBuilder sbMailBody = new StringBuilder();
            DataSet dsPR = PickupRequestBL.FetchSinglePickupRequest(Convert.ToInt32(Convert.ToString(ViewState["PickupReuestId"])));            
            sbMailBody.Append("<table><tr><td>" + txtShipFromCompany.Text.ToString().Trim() + " has submitted a pick up request on " + Convert.ToString(Convert.ToDateTime(dsPR.Tables[0].Rows[0]["DateCreated"].ToString()).ToString("MM/dd/yyyy hh:mm:ss")));
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>User Email Address: " + txtFromEmail.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>Shipper Email Address: " + txtFromEmail.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>Your Pickup request of " + ViewState["shipPiece"].ToString() + " pieces @ " + ViewState["shppedwt"].ToString() + " lbs going <br />from:");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtShipFromCompany.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtFromAddress.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtFromCity.Text.ToString().Trim() + "," + drpFromState.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtFromPostalCode.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + drpFromCountry.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />To:");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtShipToCompany.Text.ToString().Trim().Replace("–", "-"));
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtToAddress.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtToCity.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + txtToPostalCode.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>" + drpToCountry.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />Requested Pick Up Date: " + txtPickUpDate.Text.ToString().Trim());
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td>Requested Pick Up Time: " + drpLatestPickup.SelectedItem.Text);
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("<tr><td><br />Use the hyperlink to log in and view and approve this request. ");
            sbMailBody.Append("</td></tr>");
            string strUrlPickRequest = strMainURL + "/Admin/AddPickUpRequestIntl.aspx?PickupRequestId=" + SecurityUtils.UrlEncode(ViewState["PickupReuestId"].ToString());
            sbMailBody.Append("<tr><td><a href='" + strUrlPickRequest + "'>" + strUrlPickRequest + "</a>");
            sbMailBody.Append("</td></tr>");
            sbMailBody.Append("</table>");
            if (Session["userEmail"] != null)
            {
                //CommonBL.sendMailInHtmlFormat("admin@impact-scs.com", strToMail, "New Pickup Request", sbMailBody.ToString());
                CommonBL.sendMailInHtmlFormat("ops@3plintegration.com", strToMail, "New Pickup Request", sbMailBody.ToString());
            }
        }
        #endregion

        #region protected void FetchUserDetails()
        protected void FetchUserDetails()
        {
            if (Session["cacheUserId"] != null)
            {
                int userid = Convert.ToInt32(Session["cacheUserId"]);
                DataSet ds = UserBL.GetUserStateCountryByUserId(userid);

                if (ds.Tables[0].Rows[0].IsNull("Margin") == false)
                {
                    txtMargin.Text = Convert.ToString(ds.Tables[0].Rows[0]["Margin"]);
                }
                if (ds.Tables[0].Rows[0].IsNull("CompanyName") == false)
                {
                    txtShipFromCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                }
                if (ds.Tables[0].Rows[0].IsNull("Address1") == false)
                {
                    txtFromAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address1"]);
                }
                if (ds.Tables[0].Rows[0].IsNull("City") == false)
                {
                    txtFromCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                }
                if (ds.Tables[0].Rows[0].IsNull("StateId") == false && Convert.ToString(ds.Tables[0].Rows[0]["StateId"]) != "0")
                {
                    for (int i = 0; i < drpFromState.Items.Count; i++)
                    {
                        if (drpFromState.Items[i].Value == Convert.ToString(ds.Tables[0].Rows[0]["StateId"]))
                        {
                            drpFromState.ClearSelection();
                            drpFromState.Items[i].Selected = true;
                        }
                    }
                }
                if (ds.Tables[0].Rows[0].IsNull("PostalCode") == false)
                {
                    txtFromPostalCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PostalCode"]);
                }

                if (ds.Tables[0].Rows[0].IsNull("CountryId") == false && Convert.ToString(ds.Tables[0].Rows[0]["CountryId"]) != "0")
                {
                    for (int i = 0; i < drpFromCountry.Items.Count; i++)
                    {
                        if (drpFromCountry.Items[i].Value == Convert.ToString(ds.Tables[0].Rows[0]["CountryId"]))
                        {
                            drpFromCountry.ClearSelection();
                            drpFromCountry.Items[i].Selected = true;
                        }
                    }
                }

                if (ds.Tables[0].Rows[0].IsNull("ShipFromContact") == false)
                {
                    txtFromContact.Text = Convert.ToString(ds.Tables[0].Rows[0]["ShipFromContact"]);
                }

                if (ds.Tables[0].Rows[0].IsNull("Phone") == false)
                {
                    txtFromPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
                }

                if (ds.Tables[0].Rows[0].IsNull("Fax") == false)
                {
                    txtFromFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
                }
                if (ds.Tables[0].Rows[0].IsNull("Email") == false)
                {
                    txtFromEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                }
            }
        }
        #endregion

        #region public void AddVendor2QuickBook()
        public void AddVendor2QuickBook(string strRefNo)
        {
            // Add Vendor to Quickbook
            QuickBookEL oQuickBookEL = new QuickBookEL();
            oQuickBookEL.CustomerInvoiceNo = Convert.ToString(strRefNo);
            oQuickBookEL.VendorInsuranceAmt = IsDouble(txtInsurance1.Text);
            oQuickBookEL.VendorCODFeeAmt = IsDouble(txtCodFee1.Text);
            oQuickBookEL.VendorBuyBrokerageAmt1 = IsDouble(txtBuyBrokerage.Text);
            oQuickBookEL.VendorBuyDutyAmt1 = IsDouble(txtBuyDuty.Text);
            if (IsInteger(hdCarrierID.Value) > 0 || txtPickupCarrier.Text.Trim() != "" || IsDouble(txtTransportCost1.Text) > 0.00 || IsDouble(txtAccessorialCost1.Text) > 0.00 || IsDouble(txtFuelSurcharge1.Text) > 0.00)
            {
                //string strRes = QuickBookBL.VendorADD(IsInteger(hdCarrierID.Value));
                string strRes = PrepareVendorAddXML(IsInteger(hdCarrierID.Value),"");
                if (txtPickupCarrier.Text.Trim() != "")
                {
                    oQuickBookEL.VendorName = txtPickupCarrier.Text.Trim();
                }
                oQuickBookEL.VendorTransportAmt1 = IsDouble(txtTransportCost1.Text);
                oQuickBookEL.VendorAccessorialAmt1 = IsDouble(txtAccessorialCost1.Text);
                oQuickBookEL.VendorFuelSurchargeAmt1 = IsDouble(txtFuelSurcharge1.Text);
                
                //string strRes4 = QuickBookBL.VendorAmountADD(oQuickBookEL);
                string strRes4 = PrepareVendorAmtAddXML(oQuickBookEL,"");
            }
            if (IsInteger(hdIntermediateCarrierID.Value) > 0 || txtIntermediateCarrier.Text.Trim() != "" || IsDouble(txtTransportCost2.Text) > 0.00 || IsDouble(txtAccessorialCost2.Text) > 0.00 || IsDouble(txtFuelSurcharge2.Text) > 0.00)
            {
                //string strRes1 = QuickBookBL.VendorADD(IsInteger(hdIntermediateCarrierID.Value));
                string strRes1 = PrepareVendorAddXML(IsInteger(hdIntermediateCarrierID.Value), "Intermediate");
                if (txtIntermediateCarrier.Text.Trim() != "")
                {
                    oQuickBookEL.VendorName = txtIntermediateCarrier.Text.Trim();
                }
                oQuickBookEL.VendorTransportAmt1 = IsDouble(txtTransportCost2.Text);
                oQuickBookEL.VendorAccessorialAmt1 = IsDouble(txtAccessorialCost2.Text);
                oQuickBookEL.VendorFuelSurchargeAmt1 = IsDouble(txtFuelSurcharge2.Text);
                
                //string strRes4 = QuickBookBL.VendorAmountADD(oQuickBookEL);
                string strRes4 = PrepareVendorAmtAddXML(oQuickBookEL, "Intermediate");
            }
            if (IsInteger(hdDeliveryCarrierID.Value) > 0 || txtDeliveryCarrier.Text.Trim() != "" || IsDouble(txtTransportCost3.Text) > 0.00 || IsDouble(txtAccessorialCost3.Text) > 0.00 || IsDouble(txtFuelSurcharge3.Text) > 0.00)
            {
                //string strRes2 = QuickBookBL.VendorADD(IsInteger(hdDeliveryCarrierID.Value));
                string strRes2 = PrepareVendorAddXML(IsInteger(hdDeliveryCarrierID.Value), "Delivery");
                if (txtDeliveryCarrier.Text.Trim() != "")
                {
                    oQuickBookEL.VendorName = txtDeliveryCarrier.Text.Trim();
                }
                oQuickBookEL.VendorTransportAmt1 = IsDouble(txtTransportCost3.Text);
                oQuickBookEL.VendorAccessorialAmt1 = IsDouble(txtAccessorialCost3.Text);
                oQuickBookEL.VendorFuelSurchargeAmt1 = IsDouble(txtFuelSurcharge3.Text);
                
                //string strRes4 = QuickBookBL.VendorAmountADD(oQuickBookEL);
                string strRes4 = PrepareVendorAmtAddXML(oQuickBookEL, "Delivery");
            }
            if (IsInteger(hdOtherCarrierID.Value) > 0 || txtOtherCarrier.Text.Trim() != "" || IsDouble(txtTransportCost4.Text) > 0.00 || IsDouble(txtAccessorialCost4.Text) > 0.00 || IsDouble(txtFuelSurcharge4.Text) > 0.00)
            {
                //string strRes3 = QuickBookBL.VendorADD(IsInteger(hdOtherCarrierID.Value));
                string strRes3 = PrepareVendorAddXML(IsInteger(hdOtherCarrierID.Value), "Other");
                if (txtOtherCarrier.Text.Trim() != "")
                {
                    oQuickBookEL.VendorName = txtOtherCarrier.Text.Trim();
                }
                oQuickBookEL.VendorTransportAmt1 = IsDouble(txtTransportCost4.Text);
                oQuickBookEL.VendorAccessorialAmt1 = IsDouble(txtAccessorialCost4.Text);
                oQuickBookEL.VendorFuelSurchargeAmt1 = IsDouble(txtFuelSurcharge4.Text);
                
                //string strRes4 = QuickBookBL.VendorAmountADD(oQuickBookEL);
                string strRes4 = PrepareVendorAmtAddXML(oQuickBookEL, "Other");
            }
            // Add Vendor to Quickbook
        }
        #endregion public void AddVendor2QuickBook()

        #region public void AddCustomer2QuickBook(string strRefNo)
        public void AddCustomer2QuickBook(string strRefNo)
        {
            QuickBookEL oQuickBookEL = new QuickBookEL();
            //oQuickBookEL.CustomerName = txtShipFromCompany.Text.Trim();
            //oQuickBookEL.CustomerCompanyName = txtShipFromCompany.Text.Trim();
            if (drpAccountCode.SelectedItem.Text.Trim().IndexOf('-') != -1)
            {
                string[] arrCustName = drpAccountCode.SelectedItem.Text.Trim().Split('-');
                oQuickBookEL.CustomerName = arrCustName[1].Trim();
                oQuickBookEL.CustomerCompanyName = arrCustName[1].Trim();
            }
            else
            {
                oQuickBookEL.CustomerName = drpAccountCode.SelectedItem.Text.Trim();
                oQuickBookEL.CustomerCompanyName = drpAccountCode.SelectedItem.Text.Trim();
            }
            //if (txtFromContact.Text.Trim() != "")
            //{
            //    if (txtFromContact.Text.Trim().IndexOf(' ') != -1)
            //    {
            //        string[] arrContactName = txtFromContact.Text.Trim().Split(' ');
            //        oQuickBookEL.CustomerFirstName = arrContactName[0];
            //        oQuickBookEL.CustomerLastName = arrContactName[1];
            //    }
            //    else
            //    {
            //        oQuickBookEL.CustomerFirstName = txtFromContact.Text.Trim();
            //        oQuickBookEL.CustomerLastName = txtFromContact.Text.Trim();
            //    }
            //}
            //oQuickBookEL.CustomerAddr1 = txtFromAddress.Text.Trim();
            oQuickBookEL.CustomerAddr2 = "";
            oQuickBookEL.CustomerAddr3 = "";
            //oQuickBookEL.CustomerCity = txtFromCity.Text.Trim();
            //oQuickBookEL.CustomerState = drpFromState.SelectedItem.Text.Trim();
            //oQuickBookEL.CustomerPostalCode = txtFromPostalCode.Text.Trim();

            //oQuickBookEL.CustomerCountry = drpFromCountry.SelectedItem.Text.Trim();
            //oQuickBookEL.CustomerPhone = txtFromPhone.Text.Trim();
            oQuickBookEL.CustomerAltPhone = "";
            //oQuickBookEL.CustomerFax = txtFromFax.Text.Trim();

            oQuickBookEL.CustomerEmail = txtFromEmail.Text.Trim();
            //oQuickBookEL.CustomerContact = txtFromContact.Text.Trim();

            oQuickBookEL.CustomerTransportAmt = IsDouble(txtTransport.Text);
            oQuickBookEL.CustomerAccessorialAmt = IsDouble(txtAccessorial.Text);
            oQuickBookEL.CustomerFuelSurchargeAmt = IsDouble(txtFuelSurcharge.Text);
            oQuickBookEL.CustomerSellBrokerageAmt = IsDouble(txtSellBrokerage.Text);
            oQuickBookEL.CustomerSellDutyAmt = IsDouble(txtSellDuty.Text);
            oQuickBookEL.CustomerInsuranceAmt = IsDouble(txtInsurance.Text);
            oQuickBookEL.CustomerCODFeeAmt = IsDouble(txtCodFee.Text);

            oQuickBookEL.CustomerInvoiceDesc = ViewState["shipPiece"].ToString() + " @ " + ViewState["shppedwt"].ToString() + " lbs shipped from " + txtShipFromCompany.Text.Trim() + " in " + txtFromCity.Text.Trim() + ", " + drpFromState.SelectedItem.Text.Trim() + " to " + txtShipToCompany.Text.Trim().Replace("–", "-") + " in " + txtToCity.Text.Trim() + " using ";
            //oQuickBookEL.CustomerInvoiceDesc = ViewState["shipPiece"].ToString() + " @ " + ViewState["shppedwt"].ToString() + " lbs shipped from " + drpAccountCode.SelectedItem.Text.Trim() + " to " + txtShipToCompany.Text.Trim() + " in " + txtToCity.Text.Trim() + " using ";
            oQuickBookEL.CustomerTotalAmt = IsDouble(txtTransport.Text.ToString().Trim()) + IsDouble(txtAccessorial.Text.ToString().Trim()) + IsDouble(txtFuelSurcharge.Text.ToString().Trim()) + IsDouble(txtSellBrokerage.Text.ToString().Trim()) + IsDouble(txtSellDuty.Text.ToString().Trim()) + IsDouble(txtInsurance.Text.ToString().Trim()) + IsDouble(txtCodFee.Text.ToString().Trim());
            oQuickBookEL.CustomerTotalQty = Convert.ToInt32(ViewState["shipPiece"].ToString());

            if (rbInternAir.Checked == true)
            {
                oQuickBookEL.CustomerInvoiceDesc += rbInternAir.Text + ", " + drpInternAirTypeService1.SelectedItem.Text.Trim() + ", " + drpInternAirTypeService2.SelectedItem.Text.Trim();
            }
            else if (rbInternOcean.Checked == true)
            {
                oQuickBookEL.CustomerInvoiceDesc += rbInternOcean.Text + ", " + drpInternOceanTypeService1.SelectedItem.Text.Trim() + ", " + drpInternOceanTypeService2.SelectedItem.Text.Trim();
            }
            else if (rbISCSAdvantage.Checked == true)
            {
                //oQuickBookEL.CustomerInvoiceDesc += rbISCSAdvantage.Text + ", Impact Preferred";
                oQuickBookEL.CustomerInvoiceDesc += rbISCSAdvantage.Text + ", 3PL Preferred";
            }
            oQuickBookEL.CustomerInvoiceNo = Convert.ToString(strRefNo);
            //string strRes4 = QuickBookBL.CustomerADD(oQuickBookEL);
            //string strRes5 = QuickBookBL.CustomerAmountADD(oQuickBookEL);
            string strRes4 = PrepareCustomerAddXML(oQuickBookEL);
            string strRes5 = PrepareCustomerAmtAddXML(oQuickBookEL);
        }
        #endregion public void AddCustomer2QuickBook(string strRefNo)

        #region public string PrepareVendorAddXML(int CarrierID,string CarrierType)
        public string PrepareVendorAddXML(int CarrierID,string CarrierType)
        {
            string vendoeAdd = "";
            DataTable dt = CarriersBL.GetCarrierByCarrierId(CarrierID);
            if (dt == null || dt.Rows == null || dt.Rows.Count == 0)
            { return ""; }
            DataSet dtState = StatesBL.FetchStateById(Convert.ToInt32(dt.Rows[0]["StateId"]));
            string strState = "";            
            if (dtState.Tables[0] != null && dtState.Tables[0].Rows != null && dtState.Tables[0].Rows.Count > 0)
            { strState = Convert.ToString(dtState.Tables[0].Rows[0]["Abbreviation"]).Trim(); }
            
//            vendoeAdd += @"<?xml version=""1.0"" encoding=""utf-8"" ?>  
//                  <?qbxml version=""6.0""?>  
//                <QBXML> 
//                 <SignonMsgsRq> 
//                 <SignonDesktopRq> 
//                 <ClientDateTime>%%CLIENT_DATE_TIME%%</ClientDateTime>
//                <ApplicationLogin>iscsqb2.www.impact-scs.com</ApplicationLogin>
//                <ConnectionTicket>TGT-105-vtCBiYdfD6MZbXic9EfCtw</ConnectionTicket>
//                <Language>English</Language>
//                <AppID>203083553</AppID>
//                <AppVer>1</AppVer>
//                  </SignonDesktopRq> 
//                  </SignonMsgsRq> 
//                 <QBXMLMsgsRq onError=""stopOnError""> 
//                 <VendorAddRq requestID=""1"">
//                 <VendorAdd>";

            vendoeAdd += @"<VendorAddRq requestID=""1"">
                 <VendorAdd>";

            vendoeAdd += "<Name>" + Convert.ToString(dt.Rows[0]["CarrierName"]).Trim().Replace("&", "&amp;") + "</Name>";
            vendoeAdd += "<IsActive>1</IsActive>";
            vendoeAdd += @"<CompanyName /> 
                  <Salutation /> 
                  <FirstName /> 
                  <LastName /> 
                 <VendorAddress>";
            vendoeAdd += "<Addr1>" + Convert.ToString(dt.Rows[0]["Address"]).Trim().Replace("&", "&amp;") + "</Addr1> ";
            vendoeAdd += "<Addr2 /> ";
            vendoeAdd += "<City>" + Convert.ToString(dt.Rows[0]["City"]).Trim().Replace("&", "&amp;") + "</City> ";
            vendoeAdd += "<State>" + strState.Replace("&", "&amp;") + "</State> ";
            vendoeAdd += "<PostalCode>" + Convert.ToString(dt.Rows[0]["PostalCode"]).Trim().Replace("&", "&amp;") + "</PostalCode> ";
            vendoeAdd += "<Country /> ";
            vendoeAdd += "</VendorAddress>";
            vendoeAdd += "<Phone>" + Convert.ToString(dt.Rows[0]["ContactPhone"]).Trim().Replace("&", "&amp;") + "</Phone> ";
            vendoeAdd += "<Mobile /> ";
            vendoeAdd += "<AltPhone /> ";
            vendoeAdd += "<Fax>" + Convert.ToString(dt.Rows[0]["ContactFax"]).Trim().Replace("&", "&amp;") + "</Fax> ";
            vendoeAdd += "<Email>" + Convert.ToString(dt.Rows[0]["ContactEmail"]).Trim().Replace("&", "&amp;") + "</Email> ";
            vendoeAdd += "<Contact>" + Convert.ToString(dt.Rows[0]["ContactName"]).Trim().Replace("&", "&amp;") + "</Contact> ";
            vendoeAdd += @"<NameOnCheck /> 
                  <AccountNumber /> 
                 <VendorTypeRef>";
            vendoeAdd += "<FullName>" + Convert.ToString(dt.Rows[0]["CarrierName"]).Trim().Replace("&", "&amp;") + "</FullName> ";
            vendoeAdd += @"</VendorTypeRef>
                 
                  <CreditLimit /> 
                  </VendorAdd>
                  </VendorAddRq>";

                  //</QBXMLMsgsRq> 
                  //</QBXML>";

            vendoeAdd = vendoeAdd.Replace("%%CLIENT_DATE_TIME%%", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            StreamWriter tw = null;
            string strToday = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
            //tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + strToday + "QBxml.txt", true);
            tw = new StreamWriter(Server.MapPath("../QBFiles/UnProcessed/" + strToday + "QBxml.txt"), true);
            //if (CarrierType.Trim().ToLower() == "")
            //{
            //    tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + Convert.ToString(ViewState["PickupReuestId"]) + "VendorAdd.txt");
            //}
            //if (CarrierType.Trim().ToLower() == "intermediate")
            //{
            //    tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + Convert.ToString(ViewState["PickupReuestId"]) + "VendorAddIntermediate.txt");
            //}
            //if (CarrierType.Trim().ToLower() == "delivery")
            //{
            //    tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + Convert.ToString(ViewState["PickupReuestId"]) + "VendorAddDelivery.txt");
            //}
            //if (CarrierType.Trim().ToLower() == "other")
            //{
            //    tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + Convert.ToString(ViewState["PickupReuestId"]) + "VendorAddOther.txt");
            //}
            tw.WriteLine(vendoeAdd);
            tw.Close();
            return vendoeAdd;

        }
        #endregion public string PrepareVendorAddXML(int CarrierID,string CarrierType)

        #region public string PrepareVendorAmtAddXML(QuickBookEL oQuickEL, string CarrierType)
        public string PrepareVendorAmtAddXML(QuickBookEL oQuickEL, string CarrierType)
        {

            string vendoeAdd = "";

//            vendoeAdd += @"<?xml version=""1.0"" encoding=""utf-8"" ?>  
//                  <?qbxml version=""6.0""?>  
//                <QBXML> 
//                 <SignonMsgsRq> 
//                 <SignonDesktopRq> 
//                 <ClientDateTime>%%CLIENT_DATE_TIME%%</ClientDateTime>
//                <ApplicationLogin>iscsqb2.www.impact-scs.com</ApplicationLogin>
//                <ConnectionTicket>TGT-105-vtCBiYdfD6MZbXic9EfCtw</ConnectionTicket>
//                <Language>English</Language>
//                <AppID>203083553</AppID>
//                <AppVer>1</AppVer>
//                  </SignonDesktopRq> 
//                  </SignonMsgsRq> 
//                 <QBXMLMsgsRq onError=""stopOnError""> 
//                 <BillAddRq requestID =""1"">
//                <BillAdd>
//                 <VendorRef>";

            vendoeAdd += @"<BillAddRq requestID =""1"">
                <BillAdd>
                 <VendorRef>";

            vendoeAdd += "<FullName>" + oQuickEL.VendorName.Trim().Replace("&", "&amp;") + "</FullName> ";
            vendoeAdd += "</VendorRef>";
            vendoeAdd += "<TxnDate>" + DateTime.Now.ToString("yyyy-MM-dd") + "</TxnDate> ";
            vendoeAdd += "<DueDate /> ";
            vendoeAdd += "<RefNumber /> ";
            //vendoeAdd += "<RefNumber>" + Convert.ToString(oQuickEL.CustomerInvoiceNo).Trim().Replace("&", "&amp;") + "</RefNumber>";
            vendoeAdd += @"<TermsRef>
                  <FullName>Net 30</FullName> 
                  </TermsRef>
                  <Memo /> ";
//            vendoeAdd += @"<ExpenseLineAdd>
//                 <AccountRef>
//                  <FullName>Travel</FullName> 
//                  </AccountRef>";
//            vendoeAdd += "<Amount>" + Convert.ToString(oQuickEL.VendorTransportAmt1.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount> ";
//            vendoeAdd += @"<Memo>Test Comments</Memo> 
//                  </ExpenseLineAdd>";
            vendoeAdd += @"<ExpenseLineAdd>
                 <AccountRef>
                  <FullName>Miscellaneous</FullName> 
                  </AccountRef>";
            vendoeAdd += "<Amount>" + Convert.ToString((oQuickEL.VendorAccessorialAmt1 + oQuickEL.VendorBuyBrokerageAmt1 + oQuickEL.VendorBuyDutyAmt1).ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount> ";
            vendoeAdd += @"<Memo>Test Comments</Memo> 
                  </ExpenseLineAdd>";
            vendoeAdd += @"<ExpenseLineAdd>
                 <AccountRef>
                  <FullName>Fuel Expense</FullName> 
                  </AccountRef>";
            vendoeAdd += "<Amount>" + Convert.ToString(oQuickEL.VendorFuelSurchargeAmt1.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount> ";
            vendoeAdd += @"<Memo>Test Comments</Memo> 
                  </ExpenseLineAdd>";

            vendoeAdd += @"<ExpenseLineAdd>
                 <AccountRef>
                  <FullName>Insurance</FullName> 
                  </AccountRef>";
            vendoeAdd += "<Amount>" + Convert.ToString(oQuickEL.VendorInsuranceAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount> ";
            vendoeAdd += @"<Memo>Test Comments</Memo> 
                  </ExpenseLineAdd>";

            vendoeAdd += @"<ExpenseLineAdd>
                 <AccountRef>
                  <FullName>Cost of Goods Sold</FullName> 
                  </AccountRef>";
            vendoeAdd += "<Amount>" + Convert.ToString((oQuickEL.VendorCODFeeAmt + oQuickEL.VendorTransportAmt1).ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount> ";
            vendoeAdd += @"<Memo>Test Comments</Memo> 
                  </ExpenseLineAdd>";

            vendoeAdd += @"<ItemLineAdd>
                 <ItemRef>
                  <FullName>Digital Camera</FullName> 
                  </ItemRef>
                  <Desc>Digital Camera</Desc> 
                  <Quantity>2</Quantity> 
                  <Cost>2.00</Cost> 
                  <Amount>2.00</Amount> 
                  </ItemLineAdd>
                 <ItemLineAdd>
                 <ItemRef>
                  <FullName>Laser Printer</FullName> 
                  </ItemRef>
                  <Desc>Laser Printer</Desc> 
                  <Quantity>1</Quantity> 
                  <Cost>3.00</Cost> 
                  <Amount>3.00</Amount> 
                  </ItemLineAdd>
                  </BillAdd>
                </BillAddRq>";

                  //</QBXMLMsgsRq> 
                  //</QBXML>";

            vendoeAdd = vendoeAdd.Replace("%%CLIENT_DATE_TIME%%", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            StreamWriter tw = null;
            string strToday = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
            //tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + strToday + "QBxml.txt", true);
            tw = new StreamWriter(Server.MapPath("../QBFiles/UnProcessed/" + strToday + "QBxml.txt"), true);
            //string UnProcessedPath = ConfigurationManager.AppSettings["UnProcessedPath"].ToString();
            //tw = new StreamWriter(UnProcessedPath + strToday + "QBxml.txt", true);

            //if (CarrierType.Trim().ToLower() == "")
            //{
            //    tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + Convert.ToString(ViewState["PickupReuestId"]) + "VendorAmtAdd.txt");
            //}
            //if (CarrierType.Trim().ToLower() == "intermediate")
            //{
            //    tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + Convert.ToString(ViewState["PickupReuestId"]) + "VendorAmtAddIntermediate.txt");
            //}
            //if (CarrierType.Trim().ToLower() == "delivery")
            //{
            //    tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + Convert.ToString(ViewState["PickupReuestId"]) + "VendorAmtAddDelivery.txt");
            //}
            //if (CarrierType.Trim().ToLower() == "other")
            //{
            //    tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + Convert.ToString(ViewState["PickupReuestId"]) + "VendorAmtAddOther.txt");
            //}
            tw.WriteLine(vendoeAdd);
            tw.Close();
            return vendoeAdd;

        }
        #endregion public string PrepareVendorAmtAddXML(QuickBookEL oQuickEL, string CarrierType)

        #region public string PrepareCustomerAddXML(QuickBookEL oQuickEL)
        public string PrepareCustomerAddXML(QuickBookEL oQuickEL)
        {

            string vendoeAdd = "";

//            vendoeAdd += @"<?xml version=""1.0"" encoding=""utf-8"" ?>  
//                  <?qbxml version=""6.0""?>  
//                <QBXML> 
//                 <SignonMsgsRq> 
//                 <SignonDesktopRq> 
//                 <ClientDateTime>%%CLIENT_DATE_TIME%%</ClientDateTime>
//                <ApplicationLogin>iscsqb2.www.impact-scs.com</ApplicationLogin>
//                <ConnectionTicket>TGT-105-vtCBiYdfD6MZbXic9EfCtw</ConnectionTicket>
//                <Language>English</Language>
//                <AppID>203083553</AppID>
//                <AppVer>1</AppVer>
//                  </SignonDesktopRq> 
//                  </SignonMsgsRq> 
//                 <QBXMLMsgsRq onError=""stopOnError""> 
//                 <CustomerAddRq requestID=""15"">
//			     <CustomerAdd>";

            vendoeAdd += @"<CustomerAddRq requestID=""15"">
			     <CustomerAdd>";

            vendoeAdd += "<Name>" + Convert.ToString(oQuickEL.CustomerName).Trim().Replace("&", "&amp;") + "</Name>";
            vendoeAdd += "<CompanyName>" + Convert.ToString(oQuickEL.CustomerCompanyName).Trim().Replace("&", "&amp;") + "</CompanyName>";
            //vendoeAdd += "<FirstName>" + Convert.ToString(oQuickEL.CustomerFirstName).Trim().Replace("&", "&amp;") + "</FirstName>";
            //vendoeAdd += "<LastName>" + Convert.ToString(oQuickEL.CustomerLastName).Trim().Replace("&", "&amp;") + "</LastName>";
            vendoeAdd += "<BillAddress>";
            //vendoeAdd += "<Addr1>" + Convert.ToString(oQuickEL.CustomerAddr1).Trim().Replace("&", "&amp;") + "</Addr1>";
            //vendoeAdd += "<Addr2>" + Convert.ToString(oQuickEL.CustomerAddr2).Trim().Replace("&", "&amp;") + "</Addr2>";
            //vendoeAdd += "<Addr3>" + Convert.ToString(oQuickEL.CustomerAddr3).Trim().Replace("&", "&amp;") + "</Addr3>";
            //vendoeAdd += "<City>" + Convert.ToString(oQuickEL.CustomerCity).Trim().Replace("&", "&amp;") + "</City>";
            //vendoeAdd += "<State>" + Convert.ToString(oQuickEL.CustomerState).Trim().Replace("&", "&amp;") + "</State>";
            //vendoeAdd += "<PostalCode>" + Convert.ToString(oQuickEL.CustomerPostalCode).Trim().Replace("&", "&amp;") + "</PostalCode>";
            //vendoeAdd += "<Country>" + Convert.ToString(oQuickEL.CustomerCountry).Trim().Replace("&", "&amp;") + "</Country>";
            vendoeAdd += "</BillAddress>";
            //vendoeAdd += "<Phone>" + Convert.ToString(oQuickEL.CustomerPhone).Trim().Replace("&", "&amp;") + "</Phone>";
            //vendoeAdd += "<AltPhone>" + Convert.ToString(oQuickEL.CustomerAltPhone).Trim().Replace("&", "&amp;") + "</AltPhone>";
            //vendoeAdd += "<Fax>" + Convert.ToString(oQuickEL.CustomerFax).Trim().Replace("&", "&amp;") + "</Fax>";
            vendoeAdd += "<Email>" + Convert.ToString(oQuickEL.CustomerEmail).Trim().Replace("&", "&amp;") + "</Email>";
            //vendoeAdd += "<Contact>" + Convert.ToString(oQuickEL.CustomerContact).Trim().Replace("&", "&amp;") + "</Contact>";

            vendoeAdd += @"</CustomerAdd>
		                        </CustomerAddRq>";

                                  //</QBXMLMsgsRq> 
                                  //</QBXML>";

            vendoeAdd = vendoeAdd.Replace("%%CLIENT_DATE_TIME%%", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            StreamWriter tw = null;
            string strToday = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
            //tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + strToday + "QBxml.txt", true);
            tw = new StreamWriter(Server.MapPath("../QBFiles/UnProcessed/" + strToday + "QBxml.txt"), true);
            //StreamWriter tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + Convert.ToString(ViewState["PickupReuestId"]) + "CustomerAdd.txt");
            tw.WriteLine(vendoeAdd);
            tw.Close();
            return vendoeAdd;

        }
        #endregion public string PrepareCustomerAddXML(QuickBookEL oQuickEL)

        #region public string PrepareCustomerAmtAddXML(QuickBookEL oQuickEL)
        public string PrepareCustomerAmtAddXML(QuickBookEL oQuickEL)
        {

            string vendoeAdd = "";

//            vendoeAdd += @"<?xml version=""1.0"" encoding=""utf-8"" ?>  
//                  <?qbxml version=""6.0""?>  
//                <QBXML> 
//                 <SignonMsgsRq> 
//                 <SignonDesktopRq> 
//                 <ClientDateTime>%%CLIENT_DATE_TIME%%</ClientDateTime>
//                <ApplicationLogin>iscsqb2.www.impact-scs.com</ApplicationLogin>
//                <ConnectionTicket>TGT-105-vtCBiYdfD6MZbXic9EfCtw</ConnectionTicket>
//                <Language>English</Language>
//                <AppID>203083553</AppID>
//                <AppVer>1</AppVer>
//                  </SignonDesktopRq> 
//                  </SignonMsgsRq> 
//                 <QBXMLMsgsRq onError=""stopOnError""> 
//                 <InvoiceAddRq requestID=""2"">
//			     <InvoiceAdd>";

            vendoeAdd += @"<InvoiceAddRq requestID=""2"">
			     <InvoiceAdd>";

            vendoeAdd += "<CustomerRef>";
            vendoeAdd += "<FullName>" + Convert.ToString(oQuickEL.CustomerName).Trim().Replace("&", "&amp;") + "</FullName>";
            vendoeAdd += "</CustomerRef>";
            vendoeAdd += "<TxnDate>" + DateTime.Now.ToString("yyyy-MM-dd") + "</TxnDate>";
            //vendoeAdd += "<RefNumber>" + Convert.ToString(oQuickEL.CustomerFirstName).Trim().Replace("&", "&amp;") + "</RefNumber>";
            vendoeAdd += "<RefNumber>" + Convert.ToString(oQuickEL.CustomerInvoiceNo).Trim().Replace("&", "&amp;") + "</RefNumber>";

            vendoeAdd += "<BillAddress>";
            //vendoeAdd += "<Addr1>" + Convert.ToString(oQuickEL.CustomerAddr1).Trim().Replace("&", "&amp;") + "</Addr1>";
            //vendoeAdd += "<City>" + Convert.ToString(oQuickEL.CustomerCity).Trim().Replace("&", "&amp;") + "</City>";
            //vendoeAdd += "<State>" + Convert.ToString(oQuickEL.CustomerState).Trim().Replace("&", "&amp;") + "</State>";
            //vendoeAdd += "<PostalCode>" + Convert.ToString(oQuickEL.CustomerPostalCode).Trim().Replace("&", "&amp;") + "</PostalCode>";
            //vendoeAdd += "<Country>" + Convert.ToString(oQuickEL.CustomerCountry).Trim().Replace("&", "&amp;") + "</Country>";
            vendoeAdd += "</BillAddress>";
            vendoeAdd += @"<PONumber></PONumber>
				<Memo></Memo>";

            vendoeAdd += "<InvoiceLineAdd>";
            vendoeAdd += "<ItemRef>";
            vendoeAdd += "<FullName>Transportation</FullName>";
            vendoeAdd += "</ItemRef>";
            vendoeAdd += "<Desc>" + Convert.ToString(oQuickEL.CustomerInvoiceDesc).Trim().Replace("&", "&amp;") + "</Desc>";
            //vendoeAdd += "<Quantity>1</Quantity>";
            //vendoeAdd += "<Rate>" + Convert.ToString(oQuickEL.CustomerTransportAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Rate>";
            vendoeAdd += "<Quantity>" + Convert.ToString(oQuickEL.CustomerTotalQty).Trim().Replace("&", "&amp;") + "</Quantity>";
            vendoeAdd += "<Rate>" + Convert.ToString(oQuickEL.CustomerTotalAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Rate>";
            vendoeAdd += "<Amount>" + Convert.ToString(oQuickEL.CustomerTotalAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Amount>";
            vendoeAdd += "</InvoiceLineAdd>";

            //vendoeAdd += "<InvoiceLineAdd>";
            //vendoeAdd += "<ItemRef>";
            //vendoeAdd += "<FullName>Accessorial</FullName>";
            //vendoeAdd += "</ItemRef>";
            //vendoeAdd += "<Desc>" + Convert.ToString(oQuickEL.CustomerInvoiceDesc).Trim().Replace("&", "&amp;") + "</Desc>";
            //vendoeAdd += "<Quantity>1</Quantity>";
            //vendoeAdd += "<Rate>" + Convert.ToString(oQuickEL.CustomerAccessorialAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Rate>";
            //vendoeAdd += "</InvoiceLineAdd>";

            //vendoeAdd += "<InvoiceLineAdd>";
            //vendoeAdd += "<ItemRef>";
            //vendoeAdd += "<FullName>Fuel Expense</FullName>";
            //vendoeAdd += "</ItemRef>";
            //vendoeAdd += "<Desc>" + Convert.ToString(oQuickEL.CustomerInvoiceDesc).Trim().Replace("&", "&amp;") + "</Desc>";
            //vendoeAdd += "<Quantity>1</Quantity>";
            //vendoeAdd += "<Rate>" + Convert.ToString(oQuickEL.CustomerFuelSurchargeAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Rate>";
            //vendoeAdd += "</InvoiceLineAdd>";

            //vendoeAdd += "<InvoiceLineAdd>";
            //vendoeAdd += "<ItemRef>";
            //vendoeAdd += "<FullName>Insurance</FullName>";
            //vendoeAdd += "</ItemRef>";
            //vendoeAdd += "<Desc>" + Convert.ToString(oQuickEL.CustomerInvoiceDesc).Trim().Replace("&", "&amp;") + "</Desc>";
            //vendoeAdd += "<Quantity>1</Quantity>";
            //vendoeAdd += "<Rate>" + Convert.ToString(oQuickEL.CustomerInsuranceAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Rate>";
            //vendoeAdd += "</InvoiceLineAdd>";

            //vendoeAdd += "<InvoiceLineAdd>";
            //vendoeAdd += "<ItemRef>";
            //vendoeAdd += "<FullName>Cost of Goods Sold</FullName>";
            //vendoeAdd += "</ItemRef>";
            //vendoeAdd += "<Desc>" + Convert.ToString(oQuickEL.CustomerInvoiceDesc).Trim().Replace("&", "&amp;") + "</Desc>";
            //vendoeAdd += "<Quantity>1</Quantity>";
            //vendoeAdd += "<Rate>" + Convert.ToString(oQuickEL.CustomerCODFeeAmt.ToString("#0.00")).Trim().Replace("&", "&amp;") + "</Rate>";
            //vendoeAdd += "</InvoiceLineAdd>";

            vendoeAdd += @"</InvoiceAdd>
		                    </InvoiceAddRq>";

                            //</QBXMLMsgsRq>
                            //</QBXML>";

            vendoeAdd = vendoeAdd.Replace("%%CLIENT_DATE_TIME%%", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            StreamWriter tw = null;
            string strToday = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
            //tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + strToday + "QBxml.txt", true);
            tw = new StreamWriter(Server.MapPath("../QBFiles/UnProcessed/" + strToday + "QBxml.txt"), true);
            //StreamWriter tw = new StreamWriter(@"F:\VSS_Project\ISCS\ISCS\ISCS\QBFiles\UnProcessed\" + Convert.ToString(ViewState["PickupReuestId"]) + "CustomerAmtAdd.txt");
            tw.WriteLine(vendoeAdd);
            tw.Close();
            return vendoeAdd;

        }
        #endregion public string PrepareCustomerAmtAddXML(QuickBookEL oQuickEL)

        private void LockPickupRequest(int iPickupRequestID, int iUserID, bool istat)
        {
            Boolean stat = PickupRequestBL.LockPickupRequest(iPickupRequestID, iUserID, istat);
        }

        #region public void AddQWEVendor2QuickBook()
        public void AddQWEVendor2QuickBook(string strRefNo)
        {
            // Add Vendor to Quickbook
            QuickBookEL oQuickBookEL = new QuickBookEL();
            oQuickBookEL.CustomerInvoiceNo = Convert.ToString(strRefNo);
            oQuickBookEL.VendorInsuranceAmt = IsDouble(txtInsurance1.Text);
            oQuickBookEL.VendorCODFeeAmt = IsDouble(txtCodFee1.Text);
            oQuickBookEL.VendorBuyBrokerageAmt1 = IsDouble(txtBuyBrokerage.Text);
            oQuickBookEL.VendorBuyDutyAmt1 = IsDouble(txtBuyDuty.Text);
            string strRes = PrepareQWEVendorAddXML();

            oQuickBookEL.VendorName = drpBillToCompany.SelectedItem.Text.Trim();
            if (IsDouble(txtTransportCost1.Text) > 0.00 || IsDouble(txtAccessorialCost1.Text) > 0.00 || IsDouble(txtFuelSurcharge1.Text) > 0.00)
            {               
                oQuickBookEL.VendorTransportAmt1 += IsDouble(txtTransportCost1.Text);
                oQuickBookEL.VendorAccessorialAmt1 += IsDouble(txtAccessorialCost1.Text);
                oQuickBookEL.VendorFuelSurchargeAmt1 += IsDouble(txtFuelSurcharge1.Text);                
            }
            if (IsDouble(txtTransportCost2.Text) > 0.00 || IsDouble(txtAccessorialCost2.Text) > 0.00 || IsDouble(txtFuelSurcharge2.Text) > 0.00)
            {               
                oQuickBookEL.VendorTransportAmt1 += IsDouble(txtTransportCost2.Text);
                oQuickBookEL.VendorAccessorialAmt1 += IsDouble(txtAccessorialCost2.Text);
                oQuickBookEL.VendorFuelSurchargeAmt1 += IsDouble(txtFuelSurcharge2.Text);                
            }
            if (IsDouble(txtTransportCost3.Text) > 0.00 || IsDouble(txtAccessorialCost3.Text) > 0.00 || IsDouble(txtFuelSurcharge3.Text) > 0.00)
            {               
                oQuickBookEL.VendorTransportAmt1 += IsDouble(txtTransportCost3.Text);
                oQuickBookEL.VendorAccessorialAmt1 += IsDouble(txtAccessorialCost3.Text);
                oQuickBookEL.VendorFuelSurchargeAmt1 += IsDouble(txtFuelSurcharge3.Text);                
            }
            if (IsDouble(txtTransportCost4.Text) > 0.00 || IsDouble(txtAccessorialCost4.Text) > 0.00 || IsDouble(txtFuelSurcharge4.Text) > 0.00)
            {               
                oQuickBookEL.VendorTransportAmt1 += IsDouble(txtTransportCost4.Text);
                oQuickBookEL.VendorAccessorialAmt1 += IsDouble(txtAccessorialCost4.Text);
                oQuickBookEL.VendorFuelSurchargeAmt1 += IsDouble(txtFuelSurcharge4.Text);                
            }
            string strRes4 = PrepareVendorAmtAddXML(oQuickBookEL, "");
            // Add Vendor to Quickbook
        }
        #endregion public void AddVendor2QuickBook()

        #region public string PrepareVendorAddXML(int CarrierID,string CarrierType)
        public string PrepareQWEVendorAddXML()
        {
            //string UnProcessedPath = ConfigurationManager.AppSettings["UnProcessedPath"].ToString();
            string vendoeAdd = "";

            vendoeAdd += @"<VendorAddRq requestID=""1"">
                 <VendorAdd>";

            vendoeAdd += "<Name>" + Convert.ToString(drpBillToCompany.SelectedItem.Text).Trim().Replace("&", "&amp;") + "</Name>";
            vendoeAdd += "<IsActive>1</IsActive>";
            vendoeAdd += @"<CompanyName /> 
                  <Salutation /> 
                  <FirstName /> 
                  <LastName /> 
                 <VendorAddress>";
            vendoeAdd += "<Addr1>" + Convert.ToString(txtBillToAddress.Text).Trim().Replace("&", "&amp;") + "</Addr1> ";
            vendoeAdd += "<Addr2 /> ";
            vendoeAdd += "<City>" + Convert.ToString(txtBillToCity.Text).Trim().Replace("&", "&amp;") + "</City> ";
            vendoeAdd += "<State>" + Convert.ToString(txtBillToState.Text).Trim().Replace("&", "&amp;") + "</State> ";
            vendoeAdd += "<PostalCode>" + Convert.ToString(txtBillToZip.Text).Trim().Replace("&", "&amp;") + "</PostalCode> ";
            vendoeAdd += "<Country /> ";
            vendoeAdd += "</VendorAddress>";
            vendoeAdd += "<Phone /> ";
            vendoeAdd += "<Mobile /> ";
            vendoeAdd += "<AltPhone /> ";
            vendoeAdd += "<Fax /> ";
            vendoeAdd += "<Email /> ";
            vendoeAdd += "<Contact /> ";
            vendoeAdd += @"<NameOnCheck /> 
                  <AccountNumber /> 
                 <VendorTypeRef>";
            vendoeAdd += "<FullName>" + Convert.ToString(drpBillToCompany.SelectedItem.Text).Trim().Replace("&", "&amp;") + "</FullName> ";
            vendoeAdd += @"</VendorTypeRef>
                 
                  <CreditLimit /> 
                  </VendorAdd>
                  </VendorAddRq>";            

            vendoeAdd = vendoeAdd.Replace("%%CLIENT_DATE_TIME%%", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            StreamWriter tw = null;
            string strToday = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));            
            tw = new StreamWriter(Server.MapPath("../QBFiles/UnProcessed/" + strToday + "QBxml.txt"), true);
            
            //tw = new StreamWriter(UnProcessedPath + strToday + "QBxml.txt", true);
            tw.WriteLine(vendoeAdd);
            tw.Close();
            return vendoeAdd;

        }
        #endregion public string PrepareVendorAddXML(int CarrierID,string CarrierType)
    }
}
