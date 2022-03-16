using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using CF.Web.Security;

namespace ISCS.Admin
{
    public partial class RequestList : System.Web.UI.Page
    {
        protected string strHeading = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                ViewState["SearchKey"] = "";
                ViewState["SortOrder"] = "ShipFromDate desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;

            if (Request.QueryString["RequestType"] != null && Request.QueryString["RequestType"].ToUpper() == "ALL")
            {
                ds = PickupRequestBL.FetchAllPickupRequest("All");
                strHeading = "All Pickup Requests List";
                DataView dv = new DataView();
                dv.Table = ds.Tables[0];
                dv.Sort = ViewState["SortOrder"].ToString();
                gridAll.DataSource = dv;
                gridAll.DataBind();
                gridAll.Visible = true;
                gridNonPending.Visible = false;
                gridPending.Visible = false;
            }
            else if (Request.QueryString["RequestType"] != null && Request.QueryString["RequestType"].ToUpper() == "PENDING")
            {
                ds = PickupRequestBL.FetchAllPickupRequest("Pending");
                strHeading = "Pending Pickup Requests List";
                DataView dv = new DataView();
                dv.Table = ds.Tables[0];
                dv.Sort = ViewState["SortOrder"].ToString();
                gridPending.DataSource = dv;
                gridPending.DataBind();
                gridPending.Visible = true;
                gridAll.Visible = false;
                gridNonPending.Visible = false;
            }
            else
            {
                ds = PickupRequestBL.FetchAllPickupRequest("NonPending");
                strHeading = "Non Pending Pickup Requests List";
                DataView dv = new DataView();
                dv.Table = ds.Tables[0];
                dv.Sort = ViewState["SortOrder"].ToString();
                gridNonPending.DataSource = dv;
                gridNonPending.DataBind();
                gridNonPending.Visible = true;
                gridAll.Visible = false;
                gridPending.Visible = false;
            }
            
        }
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;            
            int stat = PickupRequestBL.DeletePickupRequest(Convert.ToInt32(btnSender.CommandArgument));            
            if (stat >0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "The PickupRequest has been deleted Successfully.";
                BindGrid();
            }
            if (stat == -547)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Cannot delete record due to database exception.";
            }
        }
        protected void btnEditUserP_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            hidFUserid.Value = btnSender.CommandArgument;
            string reqType = ((Label)btnSender.NamingContainer.FindControl("lblRequestType")).Text;
            string strReqIDEncode = SecurityUtils.UrlEncode(Convert.ToString(btnSender.CommandArgument));
            if (reqType == "2")
            {                
                Response.Redirect("AddPickUpRequestIntl.aspx?stat=p&id=" + strReqIDEncode);
            }
            else
            {                
                Response.Redirect("AddPickupRequest.aspx?stat=p&id=" + strReqIDEncode);
            }            
        }
        protected void btnEditUserNP_Click(object sender, EventArgs e)
        {
            ImageButton btnSender = (ImageButton)sender;
            hidFUserid.Value = btnSender.CommandArgument;
            string reqType = ((Label)btnSender.NamingContainer.FindControl("lblRequestTypeNP")).Text;
            string strReqIDEncode = SecurityUtils.UrlEncode(Convert.ToString(btnSender.CommandArgument));            
            if (reqType == "2")
            {
                Response.Redirect("AddPickUpRequestIntl.aspx?stat=n&id=" + strReqIDEncode);
            }
            else
            {
                Response.Redirect("AddPickupRequest.aspx?stat=n&id=" + strReqIDEncode);
            }
        }        

        protected void gridNonPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridNonPending.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridNonPending_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortShipFromDate")
            {
                if (ViewState["SortOrder"].ToString() == "ShipFromDate desc")
                {
                    ViewState["SortOrder"] = "ShipFromDate asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ShipFromDate desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortGLSTrackingNumber")
            {

                if (ViewState["SortOrder"].ToString() == "GLSTrackingNumber desc")
                {
                    ViewState["SortOrder"] = "GLSTrackingNumber asc";
                }
                else
                {
                    ViewState["SortOrder"] = "GLSTrackingNumber desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortFromContact")
            {

                if (ViewState["SortOrder"].ToString() == "FromContact desc")
                {
                    ViewState["SortOrder"] = "FromContact asc";
                }
                else
                {
                    ViewState["SortOrder"] = "FromContact desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortToContact")
            {

                if (ViewState["SortOrder"].ToString() == "ToContact desc")
                {
                    ViewState["SortOrder"] = "ToContact asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ToContact desc";
                }
                BindGrid();

            }

        }

        protected void gridNonPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {              
                string strShipDate = ((Label)e.Row.FindControl("lblShipDate")).Text;
                ((Label)e.Row.FindControl("lblShipFromDate")).Text = Convert.ToDateTime(strShipDate).ToString("MM/dd/yyyy");
                string strRequestTypeNP = ((Label)e.Row.FindControl("lblRequestTypeNP")).Text;
                if (strRequestTypeNP == "2")
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#E8FFE9");
                }
                string strTransMode = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TransMode"));
                string strTransModeName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TransModeName"));
                string strStatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status"));
                string strPickupRequestId=Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PickupRequestId"));
                if (strTransMode == "1" || strTransMode == "0")
                {                    
                    string strReqIDEncode = SecurityUtils.UrlEncode(Convert.ToString(strPickupRequestId));
                    ((System.Web.UI.HtmlControls.HtmlAnchor)e.Row.FindControl("ancBill")).Attributes.Add("onclick", "window.open('BillOfLading_Vics.aspx?PickupRequestId=" + strReqIDEncode + "','_blank');");
                }
                if (strTransMode == "2")
                {                    
                    string strReqIDEncode = SecurityUtils.UrlEncode(Convert.ToString(strPickupRequestId));
                    ((System.Web.UI.HtmlControls.HtmlAnchor)e.Row.FindControl("ancBill")).Attributes.Add("onclick", "window.open('AirWaybill.aspx?PickupRequestId=" + strReqIDEncode + "','_blank');");
                }
                if (strTransMode == "3" || strTransMode == "4")
                {                    
                    string strReqIDEncode = SecurityUtils.UrlEncode(Convert.ToString(strPickupRequestId));
                    ((System.Web.UI.HtmlControls.HtmlAnchor)e.Row.FindControl("ancBill")).Attributes.Add("onclick", "window.open('SED-SLI.aspx?PickupRequestId=" + strReqIDEncode + "','_blank');");
                }

                if (strTransModeName.Trim() != "")
                { e.Row.ToolTip = strStatus.Trim() + " - " + strTransModeName.Trim(); }
                else if (strTransModeName.Trim() == "")
                { e.Row.ToolTip = strStatus.Trim(); }

                string WarehouseTypeFlag = ((Label)e.Row.FindControl("lblWarehouseTypeFlag")).Text;

                if (WarehouseTypeFlag == "0")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = " N/A &nbsp;";
                else if (WarehouseTypeFlag == "1")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = " To Warehouse &nbsp;";
                else if (WarehouseTypeFlag == "2")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = "From Warehouse &nbsp;";
                else if (WarehouseTypeFlag == "3")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = "From Warehouse To Warehouse &nbsp;";

            }
        }

        protected void gridPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPending.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridPending_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortShipFromDate")
            {
                if (ViewState["SortOrder"].ToString() == "ShipFromDate desc")
                {
                    ViewState["SortOrder"] = "ShipFromDate asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ShipFromDate desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortGLSTrackingNumber")
            {

                if (ViewState["SortOrder"].ToString() == "GLSTrackingNumber desc")
                {
                    ViewState["SortOrder"] = "GLSTrackingNumber asc";
                }
                else
                {
                    ViewState["SortOrder"] = "GLSTrackingNumber desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortFromContact")
            {

                if (ViewState["SortOrder"].ToString() == "FromContact desc")
                {
                    ViewState["SortOrder"] = "FromContact asc";
                }
                else
                {
                    ViewState["SortOrder"] = "FromContact desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortToContact")
            {

                if (ViewState["SortOrder"].ToString() == "ToContact desc")
                {
                    ViewState["SortOrder"] = "ToContact asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ToContact desc";
                }
                BindGrid();

            }
        }

        protected void gridPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strShipDate = ((Label)e.Row.FindControl("lblShipDate")).Text;
                ((Label)e.Row.FindControl("lblShipFromDate")).Text = Convert.ToDateTime(strShipDate).ToString("MM/dd/yyyy");
                string strRequestTypeP = ((Label)e.Row.FindControl("lblRequestType")).Text;
                if (strRequestTypeP == "2")
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#E8FFE9");
                }                
                string strTransModeName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TransModeName"));
                string strStatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status"));
                
                if (strTransModeName.Trim() != "")
                { e.Row.ToolTip = strStatus.Trim() + " - " + strTransModeName.Trim(); }
                else if(strTransModeName.Trim() == "")
                { e.Row.ToolTip = strStatus.Trim(); }

                string WarehouseTypeFlag = ((Label)e.Row.FindControl("lblWarehouseTypeFlag")).Text;

                if (WarehouseTypeFlag == "0")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = " N/A &nbsp;";
                else if (WarehouseTypeFlag == "1")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = " To Warehouse &nbsp;";
                else if (WarehouseTypeFlag == "2")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = "From Warehouse &nbsp;";
                else if (WarehouseTypeFlag == "3")
                    ((Label)e.Row.FindControl("lblWarehouseType")).Text = "From Warehouse To Warehouse &nbsp;";

                
                string strLocked = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Locked"));
                string strLockedUser = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LockedUser"));
                if (strLocked != "" && strLocked != "0")
                {
                    ((Label)e.Row.FindControl("lblLockedMsg")).Text = "Locked By:<b>" + strLockedUser + "</b>";
                    ((ImageButton)e.Row.FindControl("btnEditUserP")).Visible = false;
                    ((ImageButton)e.Row.FindControl("btnDeleteUser")).Visible = false;
                }
                else
                    ((Label)e.Row.FindControl("lblLockedMsg")).Text = "";
            }
        }

        protected void gridAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridAll.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridAll_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortShipFromDate")
            {
                if (ViewState["SortOrder"].ToString() == "ShipFromDate desc")
                {
                    ViewState["SortOrder"] = "ShipFromDate asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ShipFromDate desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortGLSTrackingNumber")
            {

                if (ViewState["SortOrder"].ToString() == "GLSTrackingNumber desc")
                {
                    ViewState["SortOrder"] = "GLSTrackingNumber asc";
                }
                else
                {
                    ViewState["SortOrder"] = "GLSTrackingNumber desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortFromContact")
            {

                if (ViewState["SortOrder"].ToString() == "FromContact desc")
                {
                    ViewState["SortOrder"] = "FromContact asc";
                }
                else
                {
                    ViewState["SortOrder"] = "FromContact desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortToContact")
            {

                if (ViewState["SortOrder"].ToString() == "ToContact desc")
                {
                    ViewState["SortOrder"] = "ToContact asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ToContact desc";
                }
                BindGrid();

            }

        }

        protected void gridAll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                string strShipDate = ((Label)e.Row.FindControl("lblShipDate")).Text;
                ((Label)e.Row.FindControl("lblShipFromDate")).Text = Convert.ToDateTime(strShipDate).ToString("MM/dd/yyyy");                
                e.Row.Attributes.Add("onmouseover", "document.getElementById('" + e.Row.ClientID + "').style.backgroundColor = '#ffffda'; document.getElementById('" + e.Row.ClientID + "').style.cursor = 'pointer';");
                

                string strPickReqID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PickupRequestId"));
                string strReqIDEncode = SecurityUtils.UrlEncode(Convert.ToString(strPickReqID));

                string strTransModeName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TransModeName"));
                string strStatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status"));
                string strReqType = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PickupRequestType"));
                string strPageName = "";
                if (strReqType == "2")
                {
                    strPageName = "AddPickUpRequestIntl.aspx";
                    e.Row.BackColor = System.Drawing.Color.FromName("#E8FFE9");
                    e.Row.Attributes.Add("onmouseout", "document.getElementById('" + e.Row.ClientID + "').style.backgroundColor = '#E8FFE9';");
                }
                else
                {
                    strPageName = "AddPickupRequest.aspx";
                    e.Row.Attributes.Add("onmouseout", "document.getElementById('" + e.Row.ClientID + "').style.backgroundColor = '#ffffff';");
                }

                if (strTransModeName.Trim() != "")
                { e.Row.ToolTip = strStatus.Trim() + " - " + strTransModeName.Trim(); }
                else if (strTransModeName.Trim() == "")
                { e.Row.ToolTip = strStatus.Trim(); }

                if (strStatus.ToUpper() == "PND")
                {                    
                    e.Row.Attributes.Add("onclick", "location.href='" + strPageName + "?stat=p&id=" + strReqIDEncode + "';");
                }
                else
                {                    
                    e.Row.Attributes.Add("onclick", "location.href='" + strPageName + "?stat=n&id=" + strReqIDEncode + "';");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["SearchKey"] = txtSearchKey.Text.ToString().Trim();
            BindGrid();
        }
    }
}
