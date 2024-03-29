﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ISCS.Admin
{
    public partial class shipmentlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack)
            {
                ViewState["SortOrder"] = "tracking_no desc";
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds;
            int agentid = 0;
            string strshipfromcom = null;
            string strshiptocom = null;
            DateTime strshippeddt = Convert.ToDateTime("1/1/1753 12:00:00 AM");

            if (Page.PreviousPage != null)
            {
                ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
                HiddenField hfagentid = (HiddenField)contentPh.FindControl("hdnAgentId");

                HiddenField hfshipfromcom = (HiddenField)contentPh.FindControl("hdnShipFromCompany");

                HiddenField hfshiptocom = (HiddenField)contentPh.FindControl("hdnShipToCompany");

                HiddenField hfshippeddt = (HiddenField)contentPh.FindControl("hdnShippedDates");

                if (hfagentid.Value != null && hfagentid.Value != "")
                {
                    agentid = Convert.ToInt32(hfagentid.Value);
                    ViewState["agentid"] = agentid;
                }

                if (hfshipfromcom.Value != null && hfshipfromcom.Value != "")
                {
                    strshipfromcom = hfshipfromcom.Value;
                    ViewState["strshipfromcom"] = strshipfromcom;
                }

                if (hfshiptocom.Value != null && hfshiptocom.Value != "")
                {
                    strshiptocom = hfshiptocom.Value;
                    ViewState["strshiptocom"] = strshiptocom;
                }

                if (hfshippeddt.Value != null && hfshippeddt.Value != "")
                {
                    strshippeddt = Convert.ToDateTime(hfshippeddt.Value);
                    ViewState["strshippeddt"] = strshippeddt;
                }

            }
            else
            {
                if (ViewState["agentid"] != null)
                {
                    agentid = Convert.ToInt32(ViewState["agentid"]);
                }

                if (ViewState["strshipfromcom"] != null)
                {
                    strshipfromcom = Convert.ToString(ViewState["strshipfromcom"]);
                }

                if (ViewState["strshiptocom"] != null)
                {
                    strshiptocom = Convert.ToString(ViewState["strshiptocom"]);
                }

                if (ViewState["strshippeddt"] != null)
                {
                    strshippeddt = Convert.ToDateTime(ViewState["strshippeddt"]);
                }
            }
            ds = TBillsBL.FetchShipmentByParameter(agentid, strshipfromcom, strshiptocom, strshippeddt);

            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.Sort = ViewState["SortOrder"].ToString();
            gridUsers.DataSource = dv;
            gridUsers.DataBind();
        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sortShipDate")
            {
                if (ViewState["SortOrder"].ToString() == "ship_date desc")
                {
                    ViewState["SortOrder"] = "ship_date asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ship_date desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sorttrack")
            {
                if (ViewState["SortOrder"].ToString() == "tracking_no desc")
                {
                    ViewState["SortOrder"] = "tracking_no asc";
                }
                else
                {
                    ViewState["SortOrder"] = "tracking_no desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortStatus")
            {
                if (ViewState["SortOrder"].ToString() == "StatusName desc")
                {
                    ViewState["SortOrder"] = "StatusName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "StatusName desc";
                }
                BindGrid();
            }
            else if (e.CommandName == "sortcarrier")
            {

                if (ViewState["SortOrder"].ToString() == "GLSCarrierName desc")
                {
                    ViewState["SortOrder"] = "GLSCarrierName asc";
                }
                else
                {
                    ViewState["SortOrder"] = "GLSCarrierName desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortProNo")
            {

                if (ViewState["SortOrder"].ToString() == "ProNumber desc")
                {
                    ViewState["SortOrder"] = "ProNumber asc";
                }
                else
                {
                    ViewState["SortOrder"] = "ProNumber desc";
                }
                BindGrid();

            }
            else if (e.CommandName == "sortLastUpdated")
            {

                if (ViewState["SortOrder"].ToString() == "DateLastUpdated desc")
                {
                    ViewState["SortOrder"] = "DateLastUpdated asc";
                }
                else
                {
                    ViewState["SortOrder"] = "DateLastUpdated desc";
                }
                BindGrid();

            }

        }

        public string GetProSmall(string _pronumber)
        {
            string rpro = null;
            if (_pronumber.Length > 5)
            {
                rpro = _pronumber.Substring(0, 5);
            }
            else
            {
                rpro = _pronumber;
            }
            return rpro;
        }

        protected void lnktrackclick_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = (LinkButton)sender;
            hdnTrackingNumber.Value = lnkbtn.CommandArgument;
        }
    }
}
