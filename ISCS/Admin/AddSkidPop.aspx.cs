using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class AddSkidPop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            DataSet ds = PackageTypeBL.FetchPackageTypes("", "");
            drpHandlingUnitType.DataSource = ds;
            drpHandlingUnitType.DataTextField = "PackageType";
            drpHandlingUnitType.DataValueField = "PackageTypeId";
            drpHandlingUnitType.DataBind();
            drpHandlingUnitType.Items.Insert(0, new ListItem("Please Select", "0"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["pickuprequestid"] != null)
            {
                HandlingUnitEL objEL = new HandlingUnitEL();
                objEL.PickupRequestId = Convert.ToInt32(Request.QueryString["pickuprequestid"].ToString());
                objEL.HandlingUnitType = drpHandlingUnitType.SelectedItem.Text;
                objEL.Length = Convert.ToInt32(txtLength.Text.ToString().Trim());
                objEL.Width = Convert.ToInt32(txtWidth.Text.ToString().Trim());
                objEL.Height = Convert.ToInt32(txtHeight.Text.ToString().Trim());
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
                Boolean stat = false;
                stat = HandlingUnitBL.AddHandlingUnit(objEL);
                if (stat == true)
                {
                    Response.Redirect("AddShipmentItemsPop.aspx?skidid=" + objEL.SkidId + "&pickuprequestid=" + objEL.PickupRequestId);
                }
            }
        }
    }
}
