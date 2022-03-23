using BusinessLogicLayer;
using CF.Web.Security;
using EntityLayer;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class ManageShipFromWarehouseSkuPop : System.Web.UI.Page
    {
        protected string strItemlist = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["SortOrder"] = "PartNumber_WI desc";
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                BindGrid();
            }
            chkdomestic.InputAttributes["class"] = "checkbox";
            chkinternational.InputAttributes["class"] = "checkbox";
        }
        protected void BindGrid()
        {
            int strSkuid = 0;
            if (Page.PreviousPage != null)
            {
                HiddenField hfskuid = (HiddenField)Page.PreviousPage.Form.FindControl("hidFSkuid");
                strSkuid = Convert.ToInt32(hfskuid.Value);
                ViewState["strSkuid"] = strSkuid;
                HiddenField hfSkuid_SI = (HiddenField)Page.PreviousPage.Form.FindControl("hidFSkuid_SI");
                ViewState["strSkuid_SI"] = hfSkuid_SI.Value;
                HiddenField hfPickReqId = (HiddenField)Page.PreviousPage.Form.FindControl("hidPickReqId");
                ViewState["strPRid"] = hfPickReqId.Value;
            }
            else
            {
                strSkuid = Convert.ToInt32(ViewState["strSkuid"]);
            }

            DataSet ds;

            ds = WarehouseShipmentItemsBL.FetchAllWarehouseShipmentItemsBySkuId(strSkuid);

            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridUsers.DataSource = dv;
            gridUsers.DataBind();
        }

        protected void gridUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int availableqty = Convert.ToInt32(((Label)e.Row.FindControl("lblavailableqty")).Text);
                int iInventoryID = Convert.ToInt32(((HiddenField)e.Row.FindControl("hidFInventoryid")).Value);

                for (int i = 1; i <= availableqty; i++)
                {
                    ListItem lst = new ListItem(i.ToString(), iInventoryID.ToString() + "|" + i.ToString());
                    ((DropDownList)e.Row.FindControl("drpPickQ")).Items.Add(lst);
                }
                ((CheckBox)e.Row.FindControl("chkselect")).InputAttributes["class"] = "checkbox";
            }
        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortmaskedskid")
            {
                if (ViewState["SortOrder"].ToString() == "maskedskid desc")
                {
                    ViewState["SortOrder"] = "maskedskid asc";
                }
                else
                {
                    ViewState["SortOrder"] = "maskedskid desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortPartNumber")
            {
                if (ViewState["SortOrder"].ToString() == "PartNumber_WI desc")
                {
                    ViewState["SortOrder"] = "PartNumber_WI asc";
                }
                else
                {
                    ViewState["SortOrder"] = "PartNumber_WI desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortLotNumber")
            {
                if (ViewState["SortOrder"].ToString() == "LotNumber_WI desc")
                {
                    ViewState["SortOrder"] = "LotNumber_WI asc";
                }
                else
                {
                    ViewState["SortOrder"] = "LotNumber_WI desc";
                }
                BindGrid();
            }
        }

        protected void btnshipall_Click(object sender, EventArgs e)
        {
            WarehouseShipmentItems objWarehouse = new WarehouseShipmentItems();

            int iPickupRequestType = 0;

            if (chkdomestic.Checked)
                iPickupRequestType = 1;

            if (chkinternational.Checked)
                iPickupRequestType = 2;

            int iSkuid = Convert.ToInt32(ViewState["strSkuid_SI"]);
            string pickupreqid = "";
            pickupreqid = Convert.ToString(ViewState["strPRid"]);
            objWarehouse.PickupRequestId = Convert.ToInt32(pickupreqid);
            objWarehouse.SkidId_WI = iSkuid;
            objWarehouse.SkidId_SI = Convert.ToInt32(ViewState["strSkuid"]);
            objWarehouse.AdminUserId = Convert.ToInt32(Session["cacheUserId"]);
            objWarehouse.PickupRequestType = iPickupRequestType;

            for (int i = 0; i < gridUsers.Rows.Count; i++)
            {
                string strPackType = ((Label)gridUsers.Rows[i].FindControl("lblItemPackageType")).Text;
                string strPartNumber = ((Label)gridUsers.Rows[i].FindControl("lblPartNumber")).Text;
                string strItemDescription = ((Label)gridUsers.Rows[i].FindControl("lblItemDescription")).Text;
                string strQty = ((DropDownList)gridUsers.Rows[i].FindControl("drpPickQ")).SelectedItem.Text;
                strItemlist += "<tr><td>" + strQty.ToString() + "</td>";
                strItemlist += "<td>" + strPackType.ToString() + "</td>";
                strItemlist += "<td>" + strPartNumber.ToString() + "</td>";
                strItemlist += "<td>" + strItemDescription.ToString() + "</td>";
                strItemlist += "<td></td>";
                strItemlist += "<td></td>";
                strItemlist += "</tr>";
            }
            Boolean stat = WarehouseShipmentItemsBL.AddShipAllItemsFromWarehouseUpdate(objWarehouse);
            pickupreqid = ((Label)gridUsers.Rows[gridUsers.Rows.Count - 1].FindControl("lblPickupRequestid")).Text;
            string strReqIdEncode = SecurityUtils.UrlEncode(Convert.ToString(objWarehouse.PickupRequestId));
            BindGrid();
            if (iPickupRequestType == 1)
            {
                string strtrackingNo = ((HiddenField)gridUsers.Rows[0].FindControl("hidtrackingNo")).Value;
                string strMaskedID = ((Label)gridUsers.Rows[0].FindControl("lblmaskedskid")).Text;
                string strContactEmail = ((HiddenField)gridUsers.Rows[0].FindControl("hidContactEmail")).Value;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shipclose", "parent.parent.GB_hide();parent.parent.CallMe();", true);
            }
            else if (iPickupRequestType == 2)
            {
                string strtrackingNo = ((HiddenField)gridUsers.Rows[0].FindControl("hidtrackingNo")).Value;
                string strMaskedID = ((Label)gridUsers.Rows[0].FindControl("lblmaskedskid")).Text;
                string strContactEmail = ((HiddenField)gridUsers.Rows[0].FindControl("hidContactEmail")).Value;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shipclose", "parent.parent.GB_hide();parent.parent.CallMe();", true);
            }
        }

        protected void btnshipselected_Click(object sender, EventArgs e)
        {
            WarehouseShipmentItems objWarehouse = new WarehouseShipmentItems();

            int iPickupRequestType = 0;

            if (chkdomestic.Checked)
                iPickupRequestType = 1;

            if (chkinternational.Checked)
                iPickupRequestType = 2;
            string pickupreqid = "";
            for (int i = 0; i < gridUsers.Rows.Count; i++)
            {
                if (((CheckBox)gridUsers.Rows[i].FindControl("chkselect")).Checked)
                {
                    int availableqty = Convert.ToInt32(((Label)gridUsers.Rows[i].FindControl("lblavailableqty")).Text);
                    pickupreqid = Convert.ToString(ViewState["strPRid"]);
                    int iSkuid = Convert.ToInt32(ViewState["strSkuid_SI"]);
                    string strIDandQty = Convert.ToString(((DropDownList)gridUsers.Rows[i].FindControl("drpPickQ")).SelectedValue);
                    string[] strArr = strIDandQty.Split('|');
                    int InventoryID = Convert.ToInt32(strArr[0]);
                    int pickedqty = Convert.ToInt32(strArr[1]);
                    objWarehouse.PickupRequestId = Convert.ToInt32(pickupreqid);
                    objWarehouse.SkidId_WI = iSkuid;
                    objWarehouse.AdminUserId = Convert.ToInt32(Session["cacheUserId"]);
                    objWarehouse.PickupRequestType = iPickupRequestType;
                    objWarehouse.InventoryId = InventoryID;
                    objWarehouse.QtyAdded = pickedqty;
                    Boolean stat = WarehouseShipmentItemsBL.AddPickedItemsFromWarehouseUpdate(objWarehouse);
                    string strPackType = ((Label)gridUsers.Rows[i].FindControl("lblItemPackageType")).Text;
                    string strPartNumber = ((Label)gridUsers.Rows[i].FindControl("lblPartNumber")).Text;
                    string strItemDescription = ((Label)gridUsers.Rows[i].FindControl("lblItemDescription")).Text;
                    strItemlist += "<tr><td>" + pickedqty.ToString() + "</td>";
                    strItemlist += "<td>" + strPackType.ToString() + "</td>";
                    strItemlist += "<td>" + strPartNumber.ToString() + "</td>";
                    strItemlist += "<td>" + strItemDescription.ToString() + "</td>";
                    strItemlist += "<td></td>";
                    strItemlist += "<td></td>";
                    strItemlist += "</tr>";
                }
            }
            BindGrid();
            string strReqIdEncode = SecurityUtils.UrlEncode(Convert.ToString(objWarehouse.PickupRequestId));
            if (iPickupRequestType == 1)
            {
                string strtrackingNo = ((HiddenField)gridUsers.Rows[0].FindControl("hidtrackingNo")).Value;
                string strMaskedID = ((Label)gridUsers.Rows[0].FindControl("lblmaskedskid")).Text;
                string strContactEmail = ((HiddenField)gridUsers.Rows[0].FindControl("hidContactEmail")).Value;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shipclose", "parent.parent.GB_hide();parent.parent.CallMe();", true);
            }
            else if (iPickupRequestType == 2)
            {
                string strtrackingNo = ((HiddenField)gridUsers.Rows[0].FindControl("hidtrackingNo")).Value;
                string strMaskedID = ((Label)gridUsers.Rows[0].FindControl("lblmaskedskid")).Text;
                string strContactEmail = ((HiddenField)gridUsers.Rows[0].FindControl("hidContactEmail")).Value;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "shipclose", "parent.parent.GB_hide();parent.parent.CallMe();", true);
            }
        }
    }
}
