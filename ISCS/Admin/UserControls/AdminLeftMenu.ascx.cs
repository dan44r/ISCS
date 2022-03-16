using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BusinessLogicLayer;
using System.Data;
using System.Web.Security;
using System.Text;

namespace ISCS.Admin.UserControls
{
    public partial class AdminLeftMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder strMenu = new StringBuilder();
            int parent = 0;
            if (Session["cacheUserRole"] != null)
            {
                int userTypeId = Convert.ToInt32(Session["cacheUserRole"]);

                if (userTypeId != 0)
                {
                    int userId = 0;
                    int accountcodeId = 0;
                    string accountcode = "";
                    if (Session["cacheUserId"] != null)
                    {
                        userId = Convert.ToInt32(Session["cacheUserId"]);
                    }
                    DataTable dtUser = UserBL.GetUserByUserId(userId);
                    if (dtUser.Rows.Count > 0)
                    {
                        if (dtUser.Rows[0]["AccountCodeId"] != null && Convert.ToString(dtUser.Rows[0]["AccountCodeId"]).Trim() != "")
                        {
                            accountcodeId = Convert.ToInt32(dtUser.Rows[0]["AccountCodeId"]);
                            DataTable dtAcc = AccountCodesBL.GetAccountCodeByAccountId(accountcodeId);
                            if (dtAcc.Rows.Count > 0)
                            { accountcode = Convert.ToString(dtAcc.Rows[0]["AccountName"]); }
                        }

                    }
                    DataTable dtUserTypeSectionXref = UserTypeSectionsXrefBL.GetSectionIdByUserTypeId(userTypeId);
                    foreach (DataRow drUserTypeSectionXref in dtUserTypeSectionXref.Rows)
                    {
                       

                        DataTable dtSection = SectionsBL.GetSectionById(Convert.ToInt32(drUserTypeSectionXref["SectionId"]));

                        if (parent != Convert.ToInt32(dtSection.Rows[0]["ParentId"]))
                        {
                            DataTable dtParentSection = SectionsBL.GetSectionById(Convert.ToInt32(dtSection.Rows[0]["ParentId"]));
                            if (strMenu.ToString().Contains(dtParentSection.Rows[0]["Section"].ToString()) != true)
                            {
                                ////////
                                strMenu.Append("<div class=\"lft-decription\">");
                                strMenu.Append("<h2>");
                                strMenu.Append(dtParentSection.Rows[0]["Section"]);
                                strMenu.Append("</h2>");
                                strMenu.Append("<ul>");
                                DataTable dtChildSection = SectionsBL.GetSectionByParentId(Convert.ToInt32(dtParentSection.Rows[0]["Id"]));
                                foreach (DataRow drChildSection in dtChildSection.Rows)
                                {
                                    Boolean stat = UserTypeSectionsXrefBL.CheckSectionId(Convert.ToInt32(drChildSection["Id"]), userTypeId);
                                    if (stat)
                                    {
                                        if (Convert.ToString(drChildSection["Section"]) == "Cost Summary Report" && !accountcode.ToUpper().Contains("JEOL"))
                                        { }
                                        else
                                        { strMenu.Append("<li><a title=\"" + drChildSection["Section"] + "\" href=\"" + drChildSection["SectionUrl"] + "\">" + drChildSection["Section"] + "</a></li>"); }
                                    }
                                }
                                strMenu.Append("</ul>");
                                strMenu.Append("</div>");
                                parent = Convert.ToInt32(dtParentSection.Rows[0]["Id"]);
                                ////////////
                            }
                        }

                        
                    }
                    if (strMenu != null)
                    {
                        ltUserMaintenance.Text = strMenu.ToString();
                    }
                    else
                    {
                        ltUserMaintenance.Text = "";
                    }
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
    }
}