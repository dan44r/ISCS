using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using CF.Web.Security;

namespace ISCS
{
    public partial class AirWaybill : System.Web.UI.Page
    {
        protected string strGLSCarrierName = "";
        protected string strGLSTrackingNumber = "";
        protected string strRelativePath = "";
        protected string strShipFromDate = "";
        protected int intKnownShipper = 0;
        protected string strShipFromCompany = "";
        protected string strShipFromAddress = "";
        protected string strShipFromCity = "";
        protected string strShipFromState = "";
        protected string strShipFromPostalCode = "";
        protected string strShipFromCountry = "";
        protected string strShipFromRefNumber = "";

        protected string strShiptoCompany = "";
        protected string strShiptoAddress = "";
        protected string strShiptoCity = "";
        protected string strShiptoState = "";
        protected string strShiptoPostalCode = "";
        protected string strShiptoCountry = "";
        protected string strShipToConsigneeRefNumber = "";

        protected string strShipFromContact = "";
        protected string strShipFromPhone = "";
        protected string strShipFromFax = "";

        protected string strShipToContact = "";
        protected string strShipToPhone = "";
        protected string strShipToFax = "";

        protected string strShipToNotifyName = "";
        protected string strShipToNotifyPhone = "";

        protected string strTransModeName = "";
        protected string strTransModeService1 = "";
        protected string strTransModeService2 = "";

        protected string strServiceText = "";
        protected string strSpecialServiceCodes = "";
        public decimal TotDeclaredValue_SI = 0;
        public int iOverflow = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int pickupreqid = 0;
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
                HiddenField hfPickUpRequestid = (HiddenField)contentPh.FindControl("hdPickupRequestId");
                if (PreviousPage != null)
                {
                    pickupreqid = IsInteger(hfPickUpRequestid.Value);
                    ViewState["pickupreqid"] = pickupreqid;
                }
                else
                {
                    pickupreqid = IsInteger(Convert.ToString(ViewState["pickupreqid"]));
                }
            }
            if (Request.QueryString["PickupRequestId"] != null)
            {
                string strReqIDDecode = SecurityUtils.UrlDecode(Convert.ToString(Request.QueryString["PickupRequestId"]));
                pickupreqid = IsInteger(strReqIDDecode);
            }
            BindData(pickupreqid);
        }
        protected void BindData(int pickupreqid)
        {
            DataTable dtUser;
            dtUser = PickupRequestBL.FetchAirwayBill(pickupreqid);
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                strRelativePath = ConfigurationSettings.AppSettings["cpath"].Trim();
                strGLSCarrierName = dtUser.Rows[0]["GLSCarrierName"].ToString().Trim();
                strGLSTrackingNumber = dtUser.Rows[0]["GLSTrackingNumber"].ToString().Trim();
                lblAirwayBillNo1.Text = strGLSTrackingNumber;
                strShipFromDate = Convert.ToDateTime(dtUser.Rows[0]["ShipFromDate"]).ToString("MM/dd/yyyy");
                lblShipFromDate.Text = strShipFromDate;
                if (dtUser.Rows[0]["GLSKnownShipper"] != DBNull.Value)
                { intKnownShipper = IsInteger(Convert.ToString(dtUser.Rows[0]["GLSKnownShipper"])); }
                if (intKnownShipper == 1)
                {
                    lblKnownShipper.Text = "Known Shipper";
                }
                else
                {
                    lblKnownShipper.Text = "Unknown Shipper";
                }
                lblShipper.Text = dtUser.Rows[0]["ShipFromCompany"].ToString();
                strShipFromAddress = dtUser.Rows[0]["ShipFromAddress"].ToString();
                strShipFromCity = dtUser.Rows[0]["ShipFromCity"].ToString();
                strShipFromState = dtUser.Rows[0]["ShipFromState"].ToString();
                strShipFromPostalCode = dtUser.Rows[0]["ShipFromPostalCode"].ToString();
                strShipFromCountry = dtUser.Rows[0]["ShipFromCountry"].ToString();
                strShipFromRefNumber = dtUser.Rows[0]["ShipFromRefNumber"].ToString();

                lblShipperAddress.Text = strShipFromAddress + "<br/>" + strShipFromCity + "," + strShipFromState + " " + strShipFromPostalCode + "<br/>" + strShipFromCountry + "<br/>" + "<b>SID#:</b>&nbsp;" + strShipFromRefNumber + "&nbsp;";

                strShiptoCompany = dtUser.Rows[0]["ShipToCompany"].ToString();
                strShiptoAddress = dtUser.Rows[0]["ShipToAddress"].ToString();
                strShiptoCity = dtUser.Rows[0]["ShipToCity"].ToString();
                strShiptoState = dtUser.Rows[0]["ShipToState"].ToString();
                strShiptoPostalCode = dtUser.Rows[0]["ShipToPostalCode"].ToString();
                strShiptoCountry = dtUser.Rows[0]["ShipToCountry"].ToString();
                strShipToConsigneeRefNumber = dtUser.Rows[0]["ShipToConsigneeRefNumber"].ToString();

                strShipFromContact = dtUser.Rows[0]["ShipFromContact"].ToString();
                strShipFromPhone = dtUser.Rows[0]["ShipFromPhone"].ToString();
                strShipFromFax = dtUser.Rows[0]["ShipFromFax"].ToString();

                strShipToContact = dtUser.Rows[0]["ShipToContact"].ToString();
                strShipToPhone = dtUser.Rows[0]["ShipToPhone"].ToString();
                strShipToFax = dtUser.Rows[0]["ShipToFax"].ToString();

                strShipToNotifyName = dtUser.Rows[0]["ShipToNotifyName"].ToString();
                strShipToNotifyPhone = dtUser.Rows[0]["ShipToNotifyPhone"].ToString();

                lblConsignee.Text = strShiptoCompany;
                lblConsigneeAddress.Text = strShiptoAddress + "<br/>" + strShiptoCity + "," + strShiptoState + " " + strShiptoPostalCode + "<br/>" + strShiptoCountry + "<br/>" + "<b>CID#:</b>&nbsp;" + strShipToConsigneeRefNumber + "&nbsp;";

                lblFromContact.Text = strShipFromContact;
                lblFromTel.Text = strShipFromPhone;
                lblFromFax.Text = strShipFromFax;

                lblToContact.Text = strShipToContact;
                lblToTel.Text = strShipToPhone;
                lblToFax.Text = strShipToFax;

                strTransModeName = dtUser.Rows[0]["TransModeName"].ToString();

                strTransModeService1 = dtUser.Rows[0]["TransModeService1"].ToString();
                strTransModeService2 = dtUser.Rows[0]["TransModeService2"].ToString();

                lblstrSpecialInstructions.Text = dtUser.Rows[0]["SpecialInstructions"].ToString().ToUpper();

                if (strTransModeService1.ToUpper() != "N/A")
                {
                    lblSpecialInst.Text = "Air Waybill for " + strTransModeService1.ToUpper() + " service";
                }
                else if (strTransModeService2.ToUpper() != "N/A")
                {
                    lblSpecialInst.Text = "Air Waybill for " + strTransModeService2.ToUpper() + " service";
                }
                strSpecialServiceCodes = dtUser.Rows[0]["SpecialServiceCodes"].ToString();
                lblGLSPaymentMethod.Text = dtUser.Rows[0]["GLSPaymentMethod"].ToString();
                lblGLSCodFee.Text = dtUser.Rows[0]["GLSCodFee"].ToString();
            }
            DisplayShipmentItems(pickupreqid);
            DisplaySkidItems(pickupreqid);
            lbldblTotalDeclaredValue.Text = Convert.ToString(TotDeclaredValue_SI);
        }

        protected void GetSpecialServicesText(int SServiceNumber)
        {
            switch (SServiceNumber)
            {
                case 1:    //1 LiftGateService
                    strServiceText = "";
                    if (strSpecialServiceCodes.IndexOf("101") != -1 && strSpecialServiceCodes.IndexOf("102") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>LIFT GATE REQUIRED:&nbsp;Origin and Destination</b></td></tr>";
                        Response.Write(strServiceText);
                        //If both are true then write out the text string and exit the sub.
                        return;
                    }

                    if (strSpecialServiceCodes.IndexOf("101") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>LIFT GATE REQUIRED:&nbsp;Origin</b></td></tr>";
                    }

                    if (strSpecialServiceCodes.IndexOf("102") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>LIFT GATE REQUIRED:&nbsp;Destination</b></td></tr>";
                    }

                    Response.Write(strServiceText);
                    break;
                case 2: //2 PalletJackService
                    strServiceText = "";
                    if (strSpecialServiceCodes.IndexOf("201") != -1 && strSpecialServiceCodes.IndexOf("202") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>PALLET JACK REQUIRED:&nbsp;Origin and Destination</b></td></tr>";
                        Response.Write(strServiceText);
                        //If both are true then write out the text string and exit the sub.
                        return;
                    }
                    if (strSpecialServiceCodes.IndexOf("201") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>PALLET JACK REQUIRED:&nbsp;Origin</b></td></tr>";
                    }
                    if (strSpecialServiceCodes.IndexOf("202") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>PALLET JACK REQUIRED:&nbsp;Destination</b></td></tr>";
                    }
                    Response.Write(strServiceText);
                    break;
                case 3: //3 InsideDeliveryService
                    strServiceText = "";
                    if (strSpecialServiceCodes.IndexOf("301") != -1 && strSpecialServiceCodes.IndexOf("302") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>INSIDE DELIVERY:&nbsp;Origin and Destination</b></td></tr>";
                        Response.Write(strServiceText);
                        //If both are true then write out the text string and exit the sub.
                        return;
                    }
                    if (strSpecialServiceCodes.IndexOf("301") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>INSIDE DELIVERY:&nbsp;Origin</b></td></tr>";
                    }
                    if (strSpecialServiceCodes.IndexOf("302") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>INSIDE DELIVERY:&nbsp;Destination</b></td></tr>";
                    }
                    Response.Write(strServiceText);
                    break;
                case 4: //4 SaturdayService
                    strServiceText = "";
                    if (strSpecialServiceCodes.IndexOf("401") != -1 && strSpecialServiceCodes.IndexOf("402") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>SATURDAY SERVICE:&nbsp;Pickup and Delivery</b></td></tr>";
                        Response.Write(strServiceText);
                        //If both are true then write out the text string and exit the sub.
                        return;
                    }
                    if (strSpecialServiceCodes.IndexOf("401") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>SATURDAY SERVICE:&nbsp;Pickup</b></td></tr>";
                    }
                    if (strSpecialServiceCodes.IndexOf("402") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>SATURDAY SERVICE:&nbsp;Delivery</b></td></tr>";
                    }
                    Response.Write(strServiceText);
                    break;
                case 5: //5 TradeShowLocationService
                    strServiceText = "";
                    if (strSpecialServiceCodes.IndexOf("501") != -1 && strSpecialServiceCodes.IndexOf("502") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>CONVENTION/TRADE SHOW LOCATION:&nbsp;Pickup and Delivery</b></td></tr>";
                        Response.Write(strServiceText);
                        //If both are true then write out the text string and exit the sub.
                        return;
                    }
                    if (strSpecialServiceCodes.IndexOf("501") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>CONVENTION/TRADE SHOW LOCATION:&nbsp;Pickup</b></td></tr>";
                    }
                    if (strSpecialServiceCodes.IndexOf("502") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>CONVENTION/TRADE SHOW LOCATION:&nbsp;Delivery</b></td></tr>";
                    }
                    Response.Write(strServiceText);
                    break;
                case 6: //6 ResidentialLocatonService
                    strServiceText = "";
                    if (strSpecialServiceCodes.IndexOf("601") != -1 && strSpecialServiceCodes.IndexOf("602") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>RESIDENTIAL LOCATION:&nbsp;Pickup and Delivery</b></td></tr>";
                        Response.Write(strServiceText);
                        //If both are true then write out the text string and exit the sub.
                        return;
                    }
                    if (strSpecialServiceCodes.IndexOf("601") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>RESIDENTIAL LOCATION:&nbsp;Pickup</b></td></tr>";
                    }
                    if (strSpecialServiceCodes.IndexOf("602") != -1)
                    {
                        strServiceText = "<tr><td colspan='2' valign='top' align='left' style='padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);'><b>RESIDENTIAL LOCATION:&nbsp;Delivery</b></td></tr>";
                    }
                    Response.Write(strServiceText);
                    break;
                default: //No Matches
                    strServiceText = "";
                    Response.Write(strServiceText);
                    break;
            }
        }
        int iShipmentTotalQty = 0;
        protected string DisplayShipmentItems(int pickupreqid)
        {
            string strShipHtml = "";
            DataTable dtUser;
            dtUser = PickupRequestBL.FetchShipmentItems(IsInteger(Convert.ToString(pickupreqid)));
            if (dtUser != null)
            {
                if (dtUser.Rows.Count > 0)
                {
                    for (int k = 0; k < dtUser.Rows.Count; k++)
                    {
                        if (dtUser.Rows[k]["PackageQuantity_SI"] != DBNull.Value)
                        {
                            iShipmentTotalQty += IsInteger(Convert.ToString(dtUser.Rows[k]["PackageQuantity_SI"]));

                        }
                    }
                    ViewState["ShipmentTotalQty"] = iShipmentTotalQty;
                    if (dtUser.Rows.Count > 4)
                    {
                        iOverflow = 1;
                        DataTable dtUser1 = null;
                        DataTable dtUser2 = null;
                        dtUser1 = dtUser.Copy();
                        dtUser2 = dtUser.Copy();
                        dtUser1.Clear();
                        dtUser2.Clear();
                        for (int i = 0; i < 4; i++)
                        {
                            
                            dtUser1.ImportRow(dtUser.Rows[i]);
                        }
                        
                        for (int j = 4; j < dtUser.Rows.Count; j++)
                        {
                            
                            dtUser2.ImportRow(dtUser.Rows[j]);
                        }
                        gridShipmentItems.DataSource = dtUser1;
                        gridShipmentItems1.DataSource = dtUser2;
                        gridShipmentItems1.DataBind();
                    }
                    else
                    {
                        gridShipmentItems.DataSource = dtUser;
                    }
                    gridShipmentItems.DataBind();
                }
            }
            return strShipHtml;
        }
        int iSkidTotalQty = 0;
        decimal iSkidTotalWt = 0;
        protected string DisplaySkidItems(int pickupreqid)
        {
            string strShipHtml = "";
            DataTable dtUser;
            dtUser = PickupRequestBL.FetchSkidItems(IsInteger(Convert.ToString(pickupreqid)));
            if (dtUser != null)
            {
                if (dtUser.Rows.Count > 0)
                {
                    for (int k = 0; k < dtUser.Rows.Count; k++)
                    {
                        if (dtUser.Rows[k]["PackageQuantity"] != DBNull.Value)
                        {
                            iSkidTotalQty += IsInteger(Convert.ToString(dtUser.Rows[k]["PackageQuantity"]));

                        }
                        if (dtUser.Rows[k]["SkidWeight"] != DBNull.Value)
                        {
                            iSkidTotalWt += IsDecimal(Convert.ToString(dtUser.Rows[k]["SkidWeight"]));

                        }
                    }
                    ViewState["SkidTotalQty"] = iSkidTotalQty;
                    ViewState["SkidTotalWt"] = iSkidTotalWt;
                    if (dtUser.Rows.Count > 4)
                    {
                        iOverflow = 1;
                        DataTable dtUser1 = null;
                        DataTable dtUser2 = null;
                        dtUser1 = dtUser.Copy();
                        dtUser2 = dtUser.Copy();
                        dtUser1.Clear();
                        dtUser2.Clear();
                        for (int i = 0; i < 4; i++)
                        {
                            
                            dtUser1.ImportRow(dtUser.Rows[i]);
                        }
                        
                        for (int j = 4; j < dtUser.Rows.Count; j++)
                        {
                            
                            dtUser2.ImportRow(dtUser.Rows[j]);
                        }
                        gridSkidItems.DataSource = dtUser1;
                        gridSkidItems1.DataSource = dtUser2;
                        gridSkidItems1.DataBind();
                    }
                    else
                    {
                        gridSkidItems.DataSource = dtUser;
                    }

                    gridSkidItems.DataBind();
                }
            }
            return strShipHtml;
        }
        int TotPackageQuantity_SI = 0;
        decimal TotWeight_SI = 0;

        protected void gridShipmentItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int iPackageQuantity_SITot = IsInteger(((Label)e.Row.FindControl("lblPackageQuantity_SI")).Text);
                TotPackageQuantity_SI = TotPackageQuantity_SI + iPackageQuantity_SITot;

                string strDeclaredValue_SI = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DeclaredValue_SI"));

                if (strDeclaredValue_SI != "")
                {
                    TotDeclaredValue_SI = TotDeclaredValue_SI + Convert.ToDecimal(strDeclaredValue_SI);
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                
                ((Label)e.Row.FindControl("lblPackageQuantity_SITot")).Text = ViewState["ShipmentTotalQty"].ToString();
            }
        }
        string[] arr1 = { "PACKAGE", "HANDLING UNIT", "WEIGHT", "H.M(X)", "<b>COMMODITY DESCRIPTION</b> <br /> Commodities requiring special or additional care or attention in handling or stowing must be so marked and packaged as to ensure safe transportation with ordinary care. <b>See Section 2(e) of NMFC Item 36O</b>", "LTL ONLY" };
        string[] arr2 = { "QTY", "TYPE", "NMFC #", "CLASS" };
        int TotQty1 = 0;
        int TotQty2 = 0;
        decimal TotdSkidWeight = 0;
        protected void gridSkidItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
                for (int i = 0; i < 6; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Font.Bold = true;
                    if (i == 5)
                    {
                        cell.ColumnSpan = 2;
                    }
                    else if (i == 2 || i == 3 || i == 4)
                    {
                        cell.RowSpan = 2;
                        if (i == 4)
                        {
                            cell.Font.Bold = false;
                        }
                    }
                    else
                    {
                        cell.ColumnSpan = 1;
                    }
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Top;
                    cell.Text = arr1[i].ToString();
                    row.Cells.Add(cell);
                }
                gridSkidItems.Controls[0].Controls.AddAt(0, row);
                GridViewRow row1 = new GridViewRow(1, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
                for (int i = 0; i < 4; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Font.Bold = true;
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Top;
                    cell.Text = arr2[i].ToString();
                    row1.Cells.Add(cell);
                }
                gridSkidItems.Controls[0].Controls.AddAt(1, row1);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int iQTY2 = IsInteger(((Label)e.Row.FindControl("lblQTY2")).Text);
                TotQty2 = TotQty2 + iQTY2;

                decimal dSkidWeight = IsInteger(((Label)e.Row.FindControl("lblSkidWeight")).Text);
                TotdSkidWeight = TotdSkidWeight + dSkidWeight;

                string strHazMat = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "HazMat"));
                string strHazMatPhn = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "HazMatEmergencyPhone"));
                string strCommodityDescription = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CommodityDescription"));
                string intLength = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Length"));
                string intWidth = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Width"));
                string intHeight = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Height"));
                string strCommDesc = "";

                if (strHazMat == "1")
                    ((Label)e.Row.FindControl("lblHazmatCode")).Text = "<b>X</b>";

                if (strHazMatPhn.Trim() != "")
                    strCommDesc += "HAZMAT PH: " + strHazMatPhn.Trim() + "<br />";

                strCommDesc += strCommodityDescription + " " + "(" + intLength + " X " + intWidth + " X " + intHeight + ")";
                ((Label)e.Row.FindControl("lblHazmatEmergencyPh")).Text = strCommDesc;

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                
                ((Label)e.Row.FindControl("lblQTY2Tot")).Text = ViewState["SkidTotalQty"].ToString();
                
                ((Label)e.Row.FindControl("lblSkidWeightTot")).Text = ViewState["SkidTotalWt"].ToString();
            }
        }

        int TotPackageQuantity_SI1 = 0;
        decimal TotWeight_SI1 = 0;
        decimal TotDeclaredValue_SI1 = 0;

        protected void gridShipmentItems1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int iPackageQuantity_SITot = IsInteger(((Label)e.Row.FindControl("lblPackageQuantity_SI")).Text);
                TotPackageQuantity_SI1 = TotPackageQuantity_SI1 + iPackageQuantity_SITot;

                string strDeclaredValue_SI = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DeclaredValue_SI"));

                if (strDeclaredValue_SI != "")
                {
                    TotDeclaredValue_SI1 = TotDeclaredValue_SI1 + Convert.ToDecimal(strDeclaredValue_SI);
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((Label)e.Row.FindControl("lblPackageQuantity_SITot")).Text = TotPackageQuantity_SI1.ToString();
            }
        }
        string[] arr11 = { "PACKAGE", "HANDLING UNIT", "WEIGHT", "H.M(X)", "<b>COMMODITY DESCRIPTION</b> <br /> Commodities requiring special or additional care or attention in handling or stowing must be so marked and packaged as to ensure safe transportation with ordinary care. <b>See Section 2(e) of NMFC Item 36O</b>", "LTL ONLY" };
        string[] arr21 = { "QTY", "TYPE", "NMFC #", "CLASS" };
        int TotQty11 = 0;
        int TotQty21 = 0;
        decimal TotdSkidWeight1 = 0;
        protected void gridSkidItems1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
                for (int i = 0; i < 6; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Font.Bold = true;
                    if (i == 5)
                    {
                        cell.ColumnSpan = 2;
                    }
                    else if (i == 2 || i == 3 || i == 4)
                    {
                        cell.RowSpan = 2;
                        if (i == 4)
                        {
                            cell.Font.Bold = false;
                        }
                    }
                    else
                    {
                        cell.ColumnSpan = 1;
                    }
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Top;
                    cell.Text = arr11[i].ToString();
                    row.Cells.Add(cell);
                }
                gridSkidItems1.Controls[0].Controls.AddAt(0, row);
                GridViewRow row1 = new GridViewRow(1, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
                for (int i = 0; i < 4; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Font.Bold = true;
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Top;
                    cell.Text = arr21[i].ToString();
                    row1.Cells.Add(cell);
                }
                gridSkidItems1.Controls[0].Controls.AddAt(1, row1);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int iQTY2 = IsInteger(((Label)e.Row.FindControl("lblQTY2")).Text);
                TotQty21 = TotQty21 + iQTY2;

                decimal dSkidWeight = IsInteger(((Label)e.Row.FindControl("lblSkidWeight")).Text);
                TotdSkidWeight1 = TotdSkidWeight1 + dSkidWeight;

                string strHazMat = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "HazMat"));
                string strHazMatPhn = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "HazMatEmergencyPhone"));
                string strCommodityDescription = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CommodityDescription"));
                string intLength = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Length"));
                string intWidth = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Width"));
                string intHeight = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Height"));
                string strCommDesc = "";

                if (strHazMat == "1")
                    ((Label)e.Row.FindControl("lblHazmatCode")).Text = "<b>X</b>";

                if (strHazMatPhn.Trim() != "")
                    strCommDesc += "HAZMAT PH: " + strHazMatPhn.Trim() + "<br />";

                strCommDesc += strCommodityDescription + " " + "(" + intLength + " X " + intWidth + " X " + intHeight + ")";
                ((Label)e.Row.FindControl("lblHazmatEmergencyPh")).Text = strCommDesc;

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((Label)e.Row.FindControl("lblQTY2Tot")).Text = TotQty21.ToString();
                ((Label)e.Row.FindControl("lblSkidWeightTot")).Text = TotdSkidWeight1.ToString();
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
