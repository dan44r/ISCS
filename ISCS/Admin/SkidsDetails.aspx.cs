using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class SkidsDetails : System.Web.UI.Page
    {
        #region protected void Page_Load(object sender, EventArgs e)
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                BindData();

                if (Request.QueryString["sec"] != null) // Edit record in Handling Unit grid from AddPickupRequest page
                {

                    if (Request.QueryString["sec"].ToString() == "ship") //Shipment Items
                    {
                        FetchShipments();
                        Panel1.Visible = false;
                    }
                    else //Handling Unit
                    {
                        FetchHandlingUnits();
                        Panel2.Visible = false;
                    }
                    btnUpdate.Visible = true;
                    btnSubmit.Visible = false;
                    btnAddMore.Visible = false;
                }
                else if (Request.QueryString["addship"] != null) // Add Shipment Item for a Handling Unit
                {
                    Panel1.Visible = false;
                    btnUpdate.Visible = false;
                    btnSubmit.Visible = true;
                    btnAddMore.Visible = true;
                }
                else // Add new record for Handling Unit and Shipment Items
                {
                    btnUpdate.Visible = false;
                    btnSubmit.Visible = true;
                    btnAddMore.Visible = true;
                }

                if (Request.QueryString["skid"] != null)
                {
                    // Initiating new Pickup Request from Warehouse(click ship item button)
                    // getting skid from old Pickup Request, if skid supplied ,
                    // add both Handling unit and Shipment item
                    hidSkid.Value = Request.QueryString["skid"].ToString();
                    trWeight1.Visible = false;
                    trWeight2.Visible = false;
                    Panel2.Visible = false;
                }

                if (Request.QueryString["ChooseWHlist"] != null)
                {
                    // Adding from other PickupRequest's skid from Warehouse list popup, 
                    // if no skid supplied , only add Handling unit, dont add Shipment item.                    
                    Panel2.Visible = false;
                }
            }
        }
        #endregion

        #region protected void BindData()
        protected void BindData()
        {
            DataSet ds = PackageTypeBL.FetchPackageTypes("", "");

            drpHandlingUnitType.DataSource = ds;
            drpHandlingUnitType.DataTextField = "PackageType";
            drpHandlingUnitType.DataValueField = "PackageTypeId";
            drpHandlingUnitType.DataBind();
            drpHandlingUnitType.Items.Insert(0, new ListItem("Please Select", "0"));

            drpPackageType.DataSource = ds;
            drpPackageType.DataTextField = "PackageType";
            drpPackageType.DataValueField = "PackageTypeId";
            drpPackageType.DataBind();
            drpPackageType.Items.Insert(0, new ListItem("Please Select", "0"));
        }
        #endregion

        #region protected void FetchShipments()
        protected void FetchShipments()
        {
            DataSet ds = ShipmentItemsBL.FetchShipmentSingle(IsInteger(Request.QueryString["shipid"].ToString()));
            if (ds.Tables.Count > 0)
            {
                txtPackageQuantity.Text = Convert.ToString(ds.Tables[0].Rows[0]["PackageQuantity_SI"]);

                string strPackageType = Convert.ToString(ds.Tables[0].Rows[0]["PackageType_SI"]);
                if (strPackageType != "")
                {
                    for (int i = 0; i < drpPackageType.Items.Count; i++)
                    {
                        if (drpPackageType.Items[i].Text.Trim().ToUpper() == strPackageType.Trim().ToUpper())
                        {
                            drpPackageType.ClearSelection();
                            drpPackageType.Items[i].Selected = true;
                        }
                    }
                }
                //txtWeight.Text = Convert.ToString(ds.Tables[0].Rows[0]["Weight_SI"]);
                txtareaProdDescription.Value = Convert.ToString(ds.Tables[0].Rows[0]["Description_SI"]);
                txtPartNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartNumber_SI"]);
                txtPONumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["PurchaseOrderNumber_SI"]);
                txtLotNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["LotNumber_SI"]);
                txtDeclaredValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["DeclaredValue_SI"]);
            }
        }
        #endregion

        #region protected void FetchHandlingUnits()
        protected void FetchHandlingUnits()
        {
            DataSet ds = HandlingUnitBL.FetchHandlingUnitSingle(IsInteger(Request.QueryString["huid"].ToString()));
            if (ds.Tables.Count > 0)
            {
                string strHandlingUnitType = Convert.ToString(ds.Tables[0].Rows[0]["HandlingUnitType"]);
                if (strHandlingUnitType != "")
                {
                    for (int i = 0; i < drpHandlingUnitType.Items.Count; i++)
                    {
                        if (drpHandlingUnitType.Items[i].Text.Trim().ToUpper() == strHandlingUnitType.Trim().ToUpper())
                        {
                            drpHandlingUnitType.ClearSelection();
                            drpHandlingUnitType.Items[i].Selected = true;
                        }
                    }
                }
                txtLength.Text = Convert.ToString(ds.Tables[0].Rows[0]["Length"]);
                txtWidth.Text = Convert.ToString(ds.Tables[0].Rows[0]["Width"]);
                txtHeight.Text = Convert.ToString(ds.Tables[0].Rows[0]["Height"]);
                txtWeight.Text = Convert.ToString(ds.Tables[0].Rows[0]["Weight_SI"]);
                if (IsInteger(Convert.ToString(ds.Tables[0].Rows[0]["HazMat"])) == 1)
                {
                    chkHazmat.Checked = true;
                }
                txtPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["HazMatEmergencyPhone"]);
                txtClass.Text = Convert.ToString(ds.Tables[0].Rows[0]["Class"]);
                txtNMFCCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["NMFCCode"]);
                txtCommoDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["CommodityDescription"]);
            }

        }
        #endregion

        #region protected void btnSubmit_Click(object sender, EventArgs e)
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["addship"] != null) // Add Shipment Item for a Handling Unit
            {
                Boolean stat1 = AddShipmentItem();
                if (stat1 == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shipclose", "parent.parent.GB_hide();parent.parent.CallMe();", true);
                    return;
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Sorry, not updated.Please try again.";
                    return;
                }
            }
            if (Request.QueryString["pickuprequestid"] != null)
            {
                HandlingUnitEL objEL = new HandlingUnitEL();
                objEL.PickupRequestId = IsInteger(Request.QueryString["pickuprequestid"].ToString());
                objEL.HandlingUnitType = drpHandlingUnitType.SelectedItem.Text;
                objEL.Length = IsInteger(txtLength.Text.ToString().Trim());
                objEL.Width = IsInteger(txtWidth.Text.ToString().Trim());
                objEL.Height = IsInteger(txtHeight.Text.ToString().Trim());
                objEL.Weight_SI = IsInteger(txtWeight.Text.ToString().Trim());
                if (chkHazmat.Checked == true)
                {
                    objEL.HazMat = 1;
                }
                else
                {
                    objEL.HazMat = 0;
                }
                objEL.Class = txtClass.Text.ToString().Trim();
                objEL.NMFCCode = txtNMFCCode.Text.ToString().Trim();
                objEL.CommodityDescription = txtCommoDesc.Text.ToString().Trim();
                objEL.HazMatEmergencyPhone = txtPhone.Text.ToString().Trim();
                objEL.DateModified = DateTime.Now;
                objEL.DateAdded = DateTime.Now;
                Boolean stat = false;
                if (hidSkid.Value != "")
                {
                    // Update existing record for Handling Unit
                    objEL.SkidId = IsInteger(hidSkid.Value);
                    stat = HandlingUnitBL.UpdateHandlingUnitItem(objEL);
                    hidSkid.Value = "";
                }
                else
                {
                    // Add new record for Handling Unit
                    stat = HandlingUnitBL.AddHandlingUnit(objEL);
                }

                if (stat == true && Request.QueryString["ChooseWHlist"] == null && Request.QueryString["skid"] == null)
                {
                    // Add new record for Shipment Items when creating fresh Pickup Request
                    ShipmentItemsEL objEL1 = new ShipmentItemsEL();
                    objEL1.PackageQuantity_SI = IsInteger(txtPackageQuantity.Text.ToString().Trim());
                    objEL1.PackageType_SI = drpHandlingUnitType.SelectedItem.Text;// drpPackageType.SelectedItem.Text;
                    objEL1.Weight_SI = IsInteger(txtWeight.Text.ToString().Trim());
                    objEL1.Description_SI = txtareaProdDescription.Value.ToString().Trim();
                    objEL1.PartNumber_SI = txtPartNumber.Text.ToString().Trim();
                    objEL1.PurchaseOrderNumber_SI = txtPONumber.Text.ToString().Trim();
                    objEL1.LotNumber_SI = txtLotNumber.Text.ToString().Trim();
                    if (txtDeclaredValue.Text.ToString().Trim() != "")
                    {
                        objEL1.DeclaredValue_SI = IsDecimal(txtDeclaredValue.Text.ToString().Trim());
                    }
                    objEL1.PickupRequestId_SI = IsInteger(Request.QueryString["pickuprequestid"].ToString());
                    objEL1.SkidId_SI = objEL.SkidId;
                    objEL1.DateAdded_SI = DateTime.Now;
                    objEL1.DateModified_SI = DateTime.Now;
                    Boolean stat1 = false;
                    if (hidSkid.Value == "")
                    {
                        stat1 = ShipmentItemsBL.AddShipmentItem(objEL1);
                    }
                    else
                    {
                        stat1 = stat;
                    }
                    if (stat1 == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shipclose", "parent.parent.GB_hide();parent.parent.CallMe();", true);
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Sorry, not updated.Please try again.";
                        return;
                    }
                }
                else if (stat == true && Request.QueryString["ChooseWHlist"] != null)
                {
                    // Adding from other PickupRequest's skid from Warehouse list popup, 
                    // just close Handling unit popup
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shipclose", "parent.parent.GB_hide();parent.parent.CallMe();", true);
                }
                else if (stat == false)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Sorry, not updated.Please try again.";
                    return;
                }
            }
        }
        #endregion

        #region protected void btnAddMore_Click(object sender, EventArgs e)
        protected void btnAddMore_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["addship"] != null) // Add Shipment Item for a Handling Unit
            {
                Boolean stat2 = false;
                stat2 = AddShipmentItem();

                if (stat2 == true)
                {
                    ClearAllFields();
                    return;
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Sorry, not updated.Please try again.";
                    return;
                }
            }
            HandlingUnitEL objEL = new HandlingUnitEL();
            if (Request.QueryString["pickuprequestid"] != null)
            {
                objEL.PickupRequestId = IsInteger(Request.QueryString["pickuprequestid"].ToString());
                objEL.HandlingUnitType = drpHandlingUnitType.SelectedItem.Text;
                objEL.Length = IsInteger(txtLength.Text.ToString().Trim());
                objEL.Width = IsInteger(txtWidth.Text.ToString().Trim());
                objEL.Height = IsInteger(txtHeight.Text.ToString().Trim());
                objEL.Weight_SI = IsInteger(txtWeight.Text.ToString().Trim());
                if (chkHazmat.Checked == true)
                {
                    objEL.HazMat = 1;
                }
                else
                {
                    objEL.HazMat = 0;
                }
                objEL.Class = txtClass.Text.ToString().Trim();
                objEL.NMFCCode = txtNMFCCode.Text.ToString().Trim();
                objEL.CommodityDescription = txtCommoDesc.Text.ToString().Trim();
                objEL.HazMatEmergencyPhone = txtPhone.Text.ToString().Trim();
                objEL.DateModified = DateTime.Now;
                objEL.DateAdded = DateTime.Now;
                Boolean stat = false;
                if (hidSkid.Value != "")
                {
                    // Update existing record for Handling Unit
                    objEL.SkidId = IsInteger(hidSkid.Value);
                    stat = HandlingUnitBL.UpdateHandlingUnitItem(objEL);
                    hidSkid.Value = "";
                }
                else
                {
                    // Add new record for Handling Unit
                    stat = HandlingUnitBL.AddHandlingUnit(objEL);
                }

                if (stat == true && Request.QueryString["ChooseWHlist"] == null && Request.QueryString["skid"] == null)
                {
                    // Add new record for Shipment Items when creating fresh Pickup Request
                    ShipmentItemsEL objEL1 = new ShipmentItemsEL();
                    objEL1.PackageQuantity_SI = IsInteger(txtPackageQuantity.Text.ToString().Trim());
                    objEL1.PackageType_SI = drpPackageType.SelectedItem.Text;
                    objEL1.Weight_SI = IsInteger(txtWeight.Text.ToString().Trim());
                    objEL1.Description_SI = txtareaProdDescription.Value.ToString().Trim();
                    objEL1.PartNumber_SI = txtPartNumber.Text.ToString().Trim();
                    objEL1.PurchaseOrderNumber_SI = txtPONumber.Text.ToString().Trim();
                    objEL1.LotNumber_SI = txtLotNumber.Text.ToString().Trim();
                    if (txtDeclaredValue.Text.ToString().Trim() != "")
                    {
                        objEL1.DeclaredValue_SI = IsDecimal(txtDeclaredValue.Text.ToString().Trim());
                    }
                    objEL1.PickupRequestId_SI = IsInteger(Request.QueryString["pickuprequestid"].ToString());
                    objEL1.SkidId_SI = objEL.SkidId;
                    objEL1.DateAdded_SI = DateTime.Now;
                    objEL1.DateModified_SI = DateTime.Now;
                    Boolean stat1;
                    if (hidSkid.Value == "")
                    {
                        stat1 = ShipmentItemsBL.AddShipmentItem(objEL1);
                    }
                    else
                    {
                        stat1 = stat;
                    }
                    if (stat1 == true)
                    {
                        ClearAllFields();
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Sorry, not updated.Please try again.";
                        return;
                    }
                }
                else if (stat == true && Request.QueryString["ChooseWHlist"] != null)
                {
                    // Adding from other PickupRequest's skid from Warehouse list popup, 
                    // just open Warehouse list popup
                    Response.Redirect("ManageShipFromWarehousePop.aspx?skidid=" + objEL.SkidId.ToString() + "&pickuprequestid=" + Request.QueryString["pickuprequestid"].ToString());
                }
                else if (stat == false)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Sorry, not updated.Please try again.";
                    return;
                }
            }
        }
        #endregion

        #region protected void btnUpdate_Click(object sender, EventArgs e)
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["sec"].ToString() == "ship")
            {
                ShipmentItemsEL objEL = new ShipmentItemsEL();
                objEL.PackageQuantity_SI = IsInteger(txtPackageQuantity.Text.ToString().Trim());
                objEL.PackageType_SI = drpPackageType.SelectedItem.Text;
                //objEL.Weight_SI = IsInteger(txtWeight.Text.ToString().Trim());
                objEL.Description_SI = txtareaProdDescription.Value.ToString().Trim();
                objEL.PartNumber_SI = txtPartNumber.Text.ToString().Trim();
                objEL.PurchaseOrderNumber_SI = txtPONumber.Text.ToString().Trim();
                objEL.LotNumber_SI = txtLotNumber.Text.ToString().Trim();
                objEL.DeclaredValue_SI = IsDecimal(txtDeclaredValue.Text.ToString().Trim());
                objEL.DateModified_SI = DateTime.Now;
                objEL.ShipmentItemId = IsInteger(Request.QueryString["shipid"].ToString());
                bool stat = ShipmentItemsBL.UpdateShipmentItem(objEL);
                if (stat == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shipclose", "parent.parent.GB_hide();parent.parent.CallMe();", true);
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Sorry,there are some problem, please try again.";
                }
            }
            else
            {
                HandlingUnitEL objEL = new HandlingUnitEL();
                objEL.HandlingUnitType = drpHandlingUnitType.SelectedItem.Text;
                objEL.Length = IsInteger(txtLength.Text.ToString().Trim());
                objEL.Width = IsInteger(txtWidth.Text.ToString().Trim());
                objEL.Height = IsInteger(txtHeight.Text.ToString().Trim());
                objEL.Weight_SI = IsInteger(txtWeight.Text.ToString().Trim());
                if (chkHazmat.Checked == true)
                {
                    objEL.HazMat = 1;
                }
                else
                {
                    objEL.HazMat = 0;
                }
                objEL.Class = txtClass.Text.ToString().Trim();
                objEL.NMFCCode = txtNMFCCode.Text.ToString().Trim();
                objEL.CommodityDescription = txtCommoDesc.Text.ToString().Trim();
                objEL.HazMatEmergencyPhone = txtPhone.Text.ToString().Trim();
                objEL.DateModified = DateTime.Now;
                objEL.SkidId = IsInteger(Request.QueryString["huid"].ToString());
                bool stat = HandlingUnitBL.UpdateHandlingUnitItem(objEL);
                if (stat == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shipclose", "parent.parent.GB_hide();parent.parent.CallMe();", true);
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Sorry,there are some problem, please try again.";
                }
            }
        }
        #endregion

        #region private void ClearAllFields()
        private void ClearAllFields()
        {
            drpHandlingUnitType.SelectedIndex = 0;
            txtLength.Text = "";
            txtWidth.Text = "";
            txtHeight.Text = "";
            txtWeight.Text = "";
            chkHazmat.Checked = false;
            txtPhone.Text = "";
            txtClass.Text = "";
            txtNMFCCode.Text = "";
            txtCommoDesc.Text = "";
            txtPackageQuantity.Text = "";
            drpPackageType.SelectedIndex = 0;
            txtareaProdDescription.Value = "";
            txtPartNumber.Text = "";
            txtPONumber.Text = "";
            txtLotNumber.Text = "";
            txtDeclaredValue.Text = "";
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

        protected Boolean AddShipmentItem()
        {
            // Add new record for Shipment Items when creating fresh Pickup Request
            ShipmentItemsEL objEL1 = new ShipmentItemsEL();
            objEL1.PackageQuantity_SI = IsInteger(txtPackageQuantity.Text.ToString().Trim());
            objEL1.PackageType_SI = drpHandlingUnitType.SelectedItem.Text;
            objEL1.Weight_SI = IsInteger(txtWeight.Text.ToString().Trim());
            objEL1.Description_SI = txtareaProdDescription.Value.ToString().Trim();
            objEL1.PartNumber_SI = txtPartNumber.Text.ToString().Trim();
            objEL1.PurchaseOrderNumber_SI = txtPONumber.Text.ToString().Trim();
            objEL1.LotNumber_SI = txtLotNumber.Text.ToString().Trim();
            if (txtDeclaredValue.Text.ToString().Trim() != "")
            {
                objEL1.DeclaredValue_SI = IsDecimal(txtDeclaredValue.Text.ToString().Trim());
            }
            objEL1.PickupRequestId_SI = IsInteger(Request.QueryString["pickuprequestid"].ToString());
            objEL1.SkidId_SI = IsInteger(Request.QueryString["huid"].ToString());
            objEL1.DateAdded_SI = DateTime.Now;
            objEL1.DateModified_SI = DateTime.Now;
            Boolean stat1 = false;
            if (hidSkid.Value == "")
            {
                stat1 = ShipmentItemsBL.AddShipmentItem(objEL1);
            }
            return stat1;
        }
    }
}
