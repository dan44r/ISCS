using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class AddShipmentItemsPop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            lblMsg.Text = "";
        }

        protected void BindData()
        {
            DataSet ds = PackageTypeBL.FetchPackageTypes("", "");
            drpPackageType.DataSource = ds;
            drpPackageType.DataTextField = "PackageType";
            drpPackageType.DataValueField = "PackageTypeId";
            drpPackageType.DataBind();
            drpPackageType.Items.Insert(0, new ListItem("Please Select", "0"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShipmentItemsEL objEL = new ShipmentItemsEL();
            objEL.PackageQuantity_SI = Convert.ToInt32(txtPackageQuantity.Text.ToString().Trim());
            objEL.PackageType_SI = drpPackageType.SelectedItem.Text;
            objEL.Weight_SI = Convert.ToInt32(txtWeight.Text.ToString().Trim());
            objEL.Description_SI = txtareaProdDescription.Value.ToString().Trim();
            objEL.PartNumber_SI = txtPartNumber.Text.ToString().Trim();
            objEL.PurchaseOrderNumber_SI = txtPONumber.Text.ToString().Trim();
            objEL.LotNumber_SI = txtLotNumber.Text.ToString().Trim();
            if (txtDeclaredValue.Text.ToString().Trim() != "")
            {
                int j = 0;
                if (int.TryParse(txtDeclaredValue.Text.ToString().Trim(), out j) == true)
                {
                    objEL.DeclaredValue_SI = Convert.ToDecimal(txtDeclaredValue.Text.ToString().Trim());
                }
            }
            objEL.PickupRequestId_SI = Convert.ToInt32(Request.QueryString["pickuprequestid"].ToString());
            objEL.SkidId_SI = Convert.ToInt32(Request.QueryString["skidid"].ToString());
            objEL.Export_MFG_SI = "Domestic";
            objEL.DateAdded_SI = DateTime.Now;
            objEL.DateModified_SI = DateTime.Now;
            Boolean stat = ShipmentItemsBL.AddShipmentItem(objEL);
            if (stat == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shipclose", "parent.parent.GB_hide();parent.parent.CallMe();", true);
            }
            else
            {
                lblMsg.Text = "Sorry, not updated. Please try again.";
            }
        }
    }
}
