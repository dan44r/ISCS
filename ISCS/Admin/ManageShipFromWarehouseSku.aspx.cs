using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using CF.Web.Security;
using EntityLayer;

namespace ISCS.Admin
{
    public partial class ManageShipFromWarehouseSku : System.Web.UI.Page
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
                ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
                HiddenField hfskuid = (HiddenField)contentPh.FindControl("hidFSkuid");                
                strSkuid = IsInteger(hfskuid.Value);
                ViewState["strSkuid"] = strSkuid;
            }
            else
            {                
                strSkuid = IsInteger(Convert.ToString(ViewState["strSkuid"]));
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
                int availableqty = IsInteger(((Label)e.Row.FindControl("lblavailableqty")).Text);
                int iInventoryID = IsInteger(((HiddenField)e.Row.FindControl("hidFInventoryid")).Value);
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
            
            int iSkuid = IsInteger(Convert.ToString(ViewState["strSkuid"]));
            string pickupreqid = "";
            objWarehouse.SkidId_WI = iSkuid;            
            objWarehouse.AdminUserId = IsInteger(Convert.ToString(Session["cacheUserId"]));
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
            Boolean stat = WarehouseShipmentItemsBL.AddShipAllItemsFromWarehouse(objWarehouse);
            pickupreqid = ((Label)gridUsers.Rows[gridUsers.Rows.Count-1].FindControl("lblPickupRequestid")).Text;
            string strReqIdEncode = SecurityUtils.UrlEncode(Convert.ToString(objWarehouse.PickupRequestId));
            BindGrid();
            if (iPickupRequestType == 1)
            {
                string strtrackingNo = ((HiddenField)gridUsers.Rows[0].FindControl("hidtrackingNo")).Value;
                string strMaskedID = ((Label)gridUsers.Rows[0].FindControl("lblmaskedskid")).Text;
                string strContactEmail = ((HiddenField)gridUsers.Rows[0].FindControl("hidContactEmail")).Value;               
                Response.Redirect("AddPickUpRequest.aspx?id=" + strReqIdEncode + "&skid=" + objWarehouse.SkidId_SI + "&pid=" + pickupreqid + "&ChooseWHlist=ChooseWHlist");
            }
            else if (iPickupRequestType == 2)
            {
                string strtrackingNo = ((HiddenField)gridUsers.Rows[0].FindControl("hidtrackingNo")).Value;
                string strMaskedID = ((Label)gridUsers.Rows[0].FindControl("lblmaskedskid")).Text;
                string strContactEmail = ((HiddenField)gridUsers.Rows[0].FindControl("hidContactEmail")).Value;               
                Response.Redirect("AddPickUpRequestIntl.aspx?id=" + strReqIdEncode + "&skid=" + objWarehouse.SkidId_SI + "&pid=" + pickupreqid + "&ChooseWHlist=ChooseWHlist");                
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
                    int availableqty = IsInteger(((Label)gridUsers.Rows[i].FindControl("lblavailableqty")).Text);
                     pickupreqid = ((Label)gridUsers.Rows[i].FindControl("lblPickupRequestid")).Text;                    
                     int iSkuid = IsInteger(Convert.ToString(ViewState["strSkuid"]));
                    string strIDandQty = Convert.ToString(((DropDownList)gridUsers.Rows[i].FindControl("drpPickQ")).SelectedValue);
                    string [] strArr=strIDandQty.Split('|');                    
                    int InventoryID = IsInteger(strArr[0]);
                    int pickedqty = IsInteger(strArr[1]);
                    objWarehouse.SkidId_WI = iSkuid;                    
                    objWarehouse.AdminUserId = IsInteger(Convert.ToString(Session["cacheUserId"]));
                    objWarehouse.PickupRequestType = iPickupRequestType;
                    objWarehouse.InventoryId = InventoryID;
                    objWarehouse.QtyAdded = pickedqty;
                    Boolean stat = WarehouseShipmentItemsBL.AddPickedItemsFromWarehouse(objWarehouse);
                    string strPackType= ((Label)gridUsers.Rows[i].FindControl("lblItemPackageType")).Text;
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
                Response.Redirect("AddPickUpRequest.aspx?id=" + strReqIdEncode + "&skid=" + objWarehouse.SkidId_SI + "&pid=" + pickupreqid + "&ChooseWHlist=ChooseWHlist");
            }
            else if (iPickupRequestType == 2)
            {
                string strtrackingNo = ((HiddenField)gridUsers.Rows[0].FindControl("hidtrackingNo")).Value;
                string strMaskedID = ((Label)gridUsers.Rows[0].FindControl("lblmaskedskid")).Text;
                string strContactEmail = ((HiddenField)gridUsers.Rows[0].FindControl("hidContactEmail")).Value;              
                Response.Redirect("AddPickUpRequestIntl.aspx?id=" + strReqIdEncode + "&skid=" + objWarehouse.SkidId_SI + "&pid=" + pickupreqid + "&ChooseWHlist=ChooseWHlist");
            }
        }        

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
    }
}
