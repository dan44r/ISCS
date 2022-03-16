using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using EntityLayer;

namespace ISCS.Admin
{
    public partial class ManageRoleAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                BindGrid();


                string strpagename = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath);
                int userTypeId = Convert.ToInt32(Session["cacheUserRole"]);
                DataTable dtUserTypeSectionXref = UserTypeSectionsXrefBL.GetSectionIdByUserTypeId(userTypeId);
                bool redirectionflg = true;
                foreach (DataRow dr in dtUserTypeSectionXref.Rows)
                {
                    DataTable dtSection = SectionsBL.GetSectionById(Convert.ToInt32(dr["SectionId"]));
                    if (strpagename == dtSection.Rows[0]["SectionUrl"].ToString())
                    {
                        redirectionflg = false;
                    }
                }
                if (redirectionflg)
                {
                    Response.Redirect(ResolveUrl("~/Admin/Error.aspx"));
                }


            }
        }
        protected void BindGrid()
        {
            DataTable dtSection = SectionsBL.FetchAllSectionsOmitParent();
            int UserTypeId = Convert.ToInt32(Session["cacheUserRole"]);
            string UserType = UserTypesBL.FetchUserTypeById(UserTypeId);
            if (UserType == "Administrator (ISCS Employee)")
            {
                List<DataRow> objListDR = dtSection.AsEnumerable().ToList();
                var objListDRExceptManageRoleAccess = from ob in objListDR where ob["Section"].ToString() != "Manage Role Access" select ob;
                dtSection = objListDRExceptManageRoleAccess.CopyToDataTable();
            }
            dlRoleAccess.DataSource = dtSection;
            dlRoleAccess.DataBind();
        }

        protected void BindDropDown()
        {
            DataTable dtUserTypes = UserTypesBL.FetchAllUserTypes();
            int UserTypeId = Convert.ToInt32(Session["cacheUserRole"]);
            string UserType = UserTypesBL.FetchUserTypeById(UserTypeId);
            ddlUserTypes.DataSource = dtUserTypes;
            ddlUserTypes.DataValueField = "UserTypeId";
            ddlUserTypes.DataTextField = "UserType";
            ddlUserTypes.DataBind();
            ListItem lstItem = new ListItem("--Select Role--", "0");
            ddlUserTypes.Items.Insert(0, lstItem);
        }

        protected void dlRoleAccess_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (ddlUserTypes.SelectedItem.Value != null && ddlUserTypes.SelectedItem.Value != "0")
            {
                DataTable dtUserTypeSectionXref = UserTypeSectionsXrefBL.GetSectionIdByUserTypeId(Convert.ToInt32(ddlUserTypes.SelectedItem.Value));
                if (dtUserTypeSectionXref.Rows.Count > 0)
                {
                    foreach (DataRow drUserTypeSectionXref in dtUserTypeSectionXref.Rows)
                    {
                        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
                        {
                            string SectionId = ((HiddenField)e.Item.FindControl("hdnSectionId")).Value;
                            if (SectionId == drUserTypeSectionXref["SectionId"].ToString())
                            {
                                ((CheckBox)e.Item.FindControl("chkSection")).Checked = true;
                                break;
                            }
                        }
                    }
                }
            }
            ((CheckBox)e.Item.FindControl("chkSection")).InputAttributes["class"] = "checkbox";
        }

        protected void ddlUserTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnRoleAccess_Click(object sender, EventArgs e)
        {
            Boolean res = UserTypeSectionsXrefBL.DeleteUserTypeSectionXref(Convert.ToInt32(ddlUserTypes.SelectedItem.Value));
            if (res)
            {
                res = false;
                foreach (DataListItem dlSectionItem in dlRoleAccess.Items)
                {
                    if (((CheckBox)dlSectionItem.FindControl("chkSection")).Checked == true)
                    {
                        UserTypeSectionsXref objUserTypeSectionsXref = new UserTypeSectionsXref();
                        objUserTypeSectionsXref.SectionId = Convert.ToInt32(((HiddenField)dlSectionItem.FindControl("hdnSectionId")).Value);
                        objUserTypeSectionsXref.UserTypeId = Convert.ToInt32(ddlUserTypes.SelectedItem.Value);
                        res = UserTypeSectionsXrefBL.InsertUserTypeSectionXref(objUserTypeSectionsXref);
                    }
                }
                if (res)
                {
                    lblMsg.Text = "Sorry, please try again later.";
                }
                else
                {
                    lblMsg.Text = "Role access has been defined sucessfully";
                    BindGrid();
                    Control mycontrol = new Control();
                    mycontrol = LoadControl("UserControls/AdminLeftMenu.ascx");
                    ((PlaceHolder)this.Page.Master.FindControl("plhLeftMenu")).Controls.Clear();
                    ((PlaceHolder)this.Page.Master.FindControl("plhLeftMenu")).Controls.Add(mycontrol);
                }
            }
        }
    }
}
