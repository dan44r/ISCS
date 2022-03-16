using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class ManageShipFromWarehouse : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                
                string strpagename = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath);                
                int userTypeId = IsInteger(Convert.ToString(Session["cacheUserRole"]));
                DataTable dtUserTypeSectionXref = UserTypeSectionsXrefBL.GetSectionIdByUserTypeId(userTypeId);
                bool redirectionflg = true;
                foreach (DataRow dr in dtUserTypeSectionXref.Rows)
                {                    
                    DataTable dtSection = SectionsBL.GetSectionById(IsInteger(Convert.ToString(dr["SectionId"])));
                    if (strpagename == dtSection.Rows[0]["SectionUrl"].ToString())
                    {
                        redirectionflg = false;
                    }
                }
                if (redirectionflg)
                {
                    Response.Redirect(ResolveUrl("~/Admin/Error.aspx"));
                }
                

                ViewState["SearchKey"] = "";
                ViewState["SortOrder"] = "WareHouseName desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            if (Session["cacheUserRole"] != null)
            {                
                int userTypeId = IsInteger(Convert.ToString(Session["cacheUserRole"]));
                if (userTypeId != 0)
                {
                    DataSet ds;
                    DataTable dtUserType = UserTypesBL.FetchUserTypeAllById(userTypeId);                    
                    DataTable dtUser = UserBL.GetUserByUserId(IsInteger(Convert.ToString(Session["cacheUserId"])));
                    int iAccID = 0;
                    if (dtUser.Rows[0]["AccountCodeId"] != DBNull.Value)
                    {                        
                        iAccID =IsInteger(Convert.ToString(dtUser.Rows[0]["AccountCodeId"]));
                    }
                    if (drpSearchCol.SelectedIndex > 0)
                    {                        
                        ds = WarehouseShipmentItemsBL.FetchAllWarehouseShipmentItems(ViewState["SearchKey"].ToString(), drpSearchCol.SelectedItem.Value,IsInteger(Convert.ToString(dtUserType.Rows[0]["UserCode"])), iAccID);
                    }
                    else
                    {                        
                        ds = WarehouseShipmentItemsBL.FetchAllWarehouseShipmentItems(IsInteger(Convert.ToString(dtUserType.Rows[0]["UserCode"])), iAccID);
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
