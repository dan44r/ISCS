using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityLayer;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class ManageShipFromWarehousePop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SearchKey"] = "";
                ViewState["SortOrder"] = "WareHouseName desc";
                BindGrid();
                hidPickReqId.Value = Convert.ToString(Request.QueryString["pickuprequestid"]);
                hidFSkuid_SI.Value = Convert.ToString(Request.QueryString["skidid"]);
            }
        }
        protected void BindGrid()
        {
            if (Session["cacheUserRole"] != null)
            {
                int userTypeId = Convert.ToInt32(Session["cacheUserRole"]);
                if (userTypeId != 0)
                {
                    DataSet ds;
                    DataTable dtUserType = UserTypesBL.FetchUserTypeAllById(userTypeId);
                    DataTable dtUser = UserBL.GetUserByUserId(Convert.ToInt32(Session["cacheUserId"]));
                    DataSet dsPR = null;
                    if (Request.QueryString["pickuprequestid"] != null)
                    {
                        dsPR = PickupRequestBL.FetchSinglePickupRequest(Convert.ToInt32(Request.QueryString["pickuprequestid"]));
                    }
                    int iAccID = 0;
                    if (dtUser.Rows[0]["AccountCodeId"] != DBNull.Value)
                    {
                        iAccID = Convert.ToInt32(dtUser.Rows[0]["AccountCodeId"]);
                    }
                    int WarehouseShipFromLocationId = 0;
                    if (dsPR.Tables[0].Rows[0]["ShipFromLocationId"] != DBNull.Value)
                    {
                        WarehouseShipFromLocationId = Convert.ToInt32(dsPR.Tables[0].Rows[0]["ShipFromLocationId"]);
                    }
                    if (drpSearchCol.SelectedIndex > 0)
                    {
                        ds = WarehouseShipmentItemsBL.FetchAllWarehouseShipmentItemsByLocation(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Value, Convert.ToInt32(dtUserType.Rows[0]["UserCode"]), iAccID, WarehouseShipFromLocationId);
                    }

                    else
                    {
                        ds = WarehouseShipmentItemsBL.FetchAllWarehouseShipmentItemsByLocation(Convert.ToInt32(dtUserType.Rows[0]["UserCode"]), iAccID, WarehouseShipFromLocationId);
                    }

                    DataView dv = new DataView();
                    dv.Table = ds.Tables[0];
                    dv.Sort = ViewState["SortOrder"].ToString();
                    gridUsers.DataSource = dv;
                    gridUsers.DataBind();
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
        
        protected void lnkmaskedskidClick_Click(object sender, EventArgs e)
        {
            LinkButton btnSender = (LinkButton)sender;
            hidFSkuid.Value = btnSender.CommandArgument;            
        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortWarehouseName")
            {
                if (ViewState["SortOrder"].ToString() == "WareHouseName desc")
                {
                    ViewState["SortOrder"] = "WareHouseName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "WareHouseName desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortmaskedskid")
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchKey"] = txtSearchKey.Text.ToString().Trim();
            BindGrid();
        }
    }
}
