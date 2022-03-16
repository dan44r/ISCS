using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using EntityLayer;

namespace ISCS.Admin
{
    public partial class ManageWarehouseSkuUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                BindDrpPackageType();
            }
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                BindValues();
            }
        }
        protected void BindValues()
        {
            ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
            HiddenField hfinventoryid = (HiddenField)contentPh.FindControl("hidFInventoryid");
            int strinventoryid = Convert.ToInt32(hfinventoryid.Value);
            ViewState["InvenId"] = strinventoryid;
            DataTable dtItem = WarehouseShipmentItemsBL.FetchAllWarehouseShipmentItemByInvId(strinventoryid);
            txtpartnumber.Text = dtItem.Rows[0]["PartNumber_WI"].ToString().Trim();
            txtlotnumber.Text = dtItem.Rows[0]["LotNumber_WI"].ToString().Trim();
            txtdescription.Text = dtItem.Rows[0]["Description_WI"].ToString().Trim();
            drpPackageType.SelectedValue = dtItem.Rows[0]["PackageType_WI"].ToString().Trim();
            txtonhand.Text = dtItem.Rows[0]["OnHandQuantity"].ToString().Trim();
            txtpending.Text = dtItem.Rows[0]["PendingPickQuantity"].ToString().Trim();
            lblAvailableQty.Text = dtItem.Rows[0]["AvailableQuantity"].ToString().Trim();
        }

        protected void BindDrpPackageType()
        {
            DataSet dtpackagetype = PackageTypeBL.FetchPackageTypes("", "");
            drpPackageType.DataSource = dtpackagetype.Tables[0];
            drpPackageType.DataValueField = "PackageType";
            drpPackageType.DataTextField = "PackageType";
            drpPackageType.DataBind();
            ListItem lstItem = new ListItem("--Select--", "0");
            drpPackageType.Items.Insert(0, lstItem);
        }

        protected void btnRetuen_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageWarehouse.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean res = false;
            WarehouseShipmentItems objWarehouseShipmentItems = new WarehouseShipmentItems();
            objWarehouseShipmentItems.PartNumber_WI = txtpartnumber.Text.ToString().Trim();
            objWarehouseShipmentItems.LotNumber_WI = txtlotnumber.Text.ToString().Trim();
            objWarehouseShipmentItems.Description_WI = txtdescription.Text.ToString().Trim();
            objWarehouseShipmentItems.PackageType_WI = drpPackageType.SelectedItem.Value;

            int ionhand = 0;
            try
            {
                ionhand = Convert.ToInt32(txtonhand.Text.ToString().Trim());
            }
            catch
            {
                ionhand = 0;
                txtonhand.Text = "0";
            }
            objWarehouseShipmentItems.OnHandQuantity = ionhand;
            int ipending = 0;
            try
            {
                ipending = Convert.ToInt32(txtpending.Text.ToString().Trim());
            }
            catch
            {
                ipending = 0;
                txtpending.Text = "0";
            }
            objWarehouseShipmentItems.PendingPickQuantity = ipending;
            int strinvid = Convert.ToInt32(ViewState["InvenId"]);
            objWarehouseShipmentItems.InventoryId = strinvid;
            res = WarehouseShipmentItemsBL.UpdateWarehouseShipmentItems(objWarehouseShipmentItems);

            if (res)
            {
                DataTable dtItem1 = WarehouseShipmentItemsBL.FetchAllWarehouseShipmentItemByInvId(strinvid);
                lblAvailableQty.Text = dtItem1.Rows[0]["AvailableQuantity"].ToString().Trim();
                lblMsg.Visible = true;
                lblMsg.Text = "Item update has been successfully done.";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Sorry, please try again later.";
            }
        }
    }
}
