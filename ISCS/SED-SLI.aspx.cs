using BusinessLogicLayer;
using CF.Web.Security;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS
{
    public partial class SED_SLI : System.Web.UI.Page
    {
        protected string strShipFromCompany = "";
        protected string strGLSBillAddress = "";
        protected string strGLSBillCity = "";
        protected string strGLSBillCompany = "";
        protected string strGLSBillPostalCode = "";
        protected string strGLSBillState = "";
        protected string strGLSCarrierName = "";
        protected string strShipFromAddress = "";
        protected string strShipFromCity = "";
        protected string strShipFromContact = "";
        protected string strShipFromDate = "";
        protected string strShipFromFax = "";
        protected string strShipFromPhone = "";
        protected string strShipFromPostalCode = "";
        protected string strShipFromRefNumber = "";
        protected string strShipFromState = "";

        protected string strShipFromCountry = "";
        protected string strExportEIN = "";
        protected string strExportPartyTrans = "";
        protected string strShiptoAddress = "";

        protected string strShiptoCity = "";
        protected string strShiptoCountry = "";
        protected string strShiptoCompany = "";
        protected string strShipToContact = "";

        protected string strShipToPhone = "";
        protected string strShiptoPostalCode = "";
        protected string strShiptoState = "";
        protected string strExportIntermediateConsignee = "";

        protected string strExportIntermediateContact = "";
        protected string strExportIntermediatePhone = "";
        protected string strTransModeName = "";
        protected string strExportLoadingPort = "";

        protected string strDisplayHazMat = "";
        protected string strExportContanerized = "";
        protected string strExportLicence = "";
        protected string strExportECCN = "";

        protected string strGLSTrackingNumber = "";
        protected string strShipToConsigneeRefNumber = "";
        protected string strShipToFax = "";
        protected string strShipToNotifyName = "";
        protected string strSpecialInstructions = "";

        protected string strDisplayGLSCodFee = "";
        protected string strShipToNotifyPhone = "";
        protected string strTransModeService1 = "";

        protected string strInsuranceRequired = "";
        protected string strDisplayInsuredValue = "";
        protected string strTransModeService2 = "";
        protected string strShippersInstructions = "";
        protected string strDocumentsEnclosed = "";
        protected int intKnownShipper = 0;
        protected int intTransMode = 0;

        protected int intOverflow = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int pickupreqid = 0;
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
                HiddenField hfPickUpRequestid = (HiddenField)contentPh.FindControl("hdPickupRequestId");
                if (PreviousPage != null)
                {
                    pickupreqid = Convert.ToInt32(hfPickUpRequestid.Value);
                    ViewState["pickupreqid"] = pickupreqid;
                }
                else
                {
                    pickupreqid = Convert.ToInt32(ViewState["pickupreqid"]);
                }
            }
            if (Request.QueryString["PickupRequestId"] != null)
            {
                string strReqIDDecode = SecurityUtils.UrlDecode(Convert.ToString(Request.QueryString["PickupRequestId"]));
                pickupreqid = Convert.ToInt32(strReqIDDecode);
            }
            BindValues(pickupreqid);
        }

        protected void BindValues(int pickupreqid)
        {
            DataTable dtBOL = PickupRequestBL.FetchSED_SLI(pickupreqid);
            if (dtBOL != null && dtBOL.Rows.Count > 0)
            {

                strShipFromCompany = dtBOL.Rows[0]["ShipFromCompany"].ToString();
                strDisplayGLSCodFee = dtBOL.Rows[0]["GLSCodFee"].ToString();
                strGLSBillAddress = dtBOL.Rows[0]["GLSBillAddress"].ToString();
                strGLSBillCity = dtBOL.Rows[0]["GLSBillCity"].ToString();
                strGLSBillCompany = dtBOL.Rows[0]["GLSBillCompany"].ToString();
                strGLSBillPostalCode = dtBOL.Rows[0]["GLSBillPostalCode"].ToString();
                strGLSBillState = dtBOL.Rows[0]["GLSBillState"].ToString();
                strGLSCarrierName = dtBOL.Rows[0]["GLSCarrierName"].ToString();
                strGLSTrackingNumber = dtBOL.Rows[0]["GLSTrackingNumber"].ToString();
                strShipFromAddress = dtBOL.Rows[0]["ShipFromAddress"].ToString();
                strShipFromCity = dtBOL.Rows[0]["ShipFromCity"].ToString();
                strShipFromContact = dtBOL.Rows[0]["ShipFromContact"].ToString();
                if (dtBOL.Rows[0]["ShipFromDate"] != DBNull.Value)
                {
                    strShipFromDate = Convert.ToDateTime(dtBOL.Rows[0]["ShipFromDate"]).ToString("MM/dd/yyyy");
                }
                strShipFromFax = dtBOL.Rows[0]["ShipFromFax"].ToString();
                strShipFromPhone = dtBOL.Rows[0]["ShipFromPhone"].ToString();
                strShipFromPostalCode = dtBOL.Rows[0]["ShipFromPostalCode"].ToString();
                strShipFromRefNumber = dtBOL.Rows[0]["ShipFromRefNumber"].ToString();
                strShipFromState = dtBOL.Rows[0]["ShipFromState"].ToString();
                strShipFromCountry = dtBOL.Rows[0]["ShipFromCountry"].ToString();
                strExportEIN = dtBOL.Rows[0]["ExportEIN"].ToString();
                strExportPartyTrans = dtBOL.Rows[0]["ExportPartyTrans"].ToString();
                strShiptoAddress = dtBOL.Rows[0]["ShipToAddress"].ToString();
                strShiptoCity = dtBOL.Rows[0]["ShipToCity"].ToString();
                strShiptoCountry = dtBOL.Rows[0]["ShipToCountry"].ToString();
                strShiptoCompany = dtBOL.Rows[0]["ShipToCompany"].ToString();
                strShipToConsigneeRefNumber = dtBOL.Rows[0]["ShipToConsigneeRefNumber"].ToString();
                strShipToContact = dtBOL.Rows[0]["ShipToContact"].ToString();
                strShipToFax = dtBOL.Rows[0]["ShipToFax"].ToString();
                strShipToNotifyName = dtBOL.Rows[0]["ShipToNotifyName"].ToString();
                strShipToNotifyPhone = dtBOL.Rows[0]["ShipToNotifyPhone"].ToString();
                strShipToPhone = dtBOL.Rows[0]["ShipToPhone"].ToString();
                strShiptoPostalCode = dtBOL.Rows[0]["ShipToPostalCode"].ToString();
                strShiptoState = dtBOL.Rows[0]["ShipToState"].ToString();
                strExportIntermediateConsignee = dtBOL.Rows[0]["ExportIntermediateConsignee"].ToString();
                strExportIntermediateContact = dtBOL.Rows[0]["ExportIntermediateContact"].ToString();
                strExportIntermediatePhone = dtBOL.Rows[0]["ExportIntermediatePhone"].ToString();
                strSpecialInstructions = dtBOL.Rows[0]["SpecialInstructions"].ToString().ToUpper();
                strTransModeName = dtBOL.Rows[0]["TransModeName"].ToString().ToUpper();
                strTransModeService1 = dtBOL.Rows[0]["TransModeService1"].ToString().ToUpper();
                strExportLoadingPort = dtBOL.Rows[0]["ExportLoadingPort"].ToString().ToUpper();
                strDisplayHazMat = dtBOL.Rows[0]["HazmatStringValue"].ToString().ToUpper();
                strExportContanerized = dtBOL.Rows[0]["ExportContanerized"].ToString().ToUpper();
                strExportLicence = dtBOL.Rows[0]["ExportLicence"].ToString().ToUpper();
                strExportECCN = dtBOL.Rows[0]["ExportECCN"].ToString().ToUpper();
                strInsuranceRequired = dtBOL.Rows[0]["InsuranceRequired"].ToString().ToUpper();
                strDisplayInsuredValue = dtBOL.Rows[0]["InsuredValue"].ToString().ToUpper();
                strTransModeService2 = dtBOL.Rows[0]["TransModeService2"].ToString().ToUpper();
                strShippersInstructions = dtBOL.Rows[0]["ShippersInstructions"].ToString().ToUpper();
                strDocumentsEnclosed = dtBOL.Rows[0]["DocumentsEnclosed"].ToString().ToUpper();
                if (dtBOL.Rows[0]["GLSKnownShipper"] != DBNull.Value)
                {
                    intKnownShipper = Convert.ToInt32(dtBOL.Rows[0]["GLSKnownShipper"].ToString());
                }
                if (dtBOL.Rows[0]["TransMode"] != DBNull.Value)
                {
                    intTransMode = Convert.ToInt32(dtBOL.Rows[0]["TransMode"].ToString());
                }
            }
            DisplayShipmentItems(pickupreqid);
        }
        protected string DisplayShipmentItems(int pickupreqid)
        {
            string strShipHtml = "";
            DataTable dtUser;
            dtUser = PickupRequestBL.FetchShipmentItems(pickupreqid);
            gridShipmentItems.DataSource = dtUser;
            gridShipmentItems.DataBind();
            gridShipmentItems1.DataSource = dtUser;
            gridShipmentItems1.DataBind();
            if (dtUser != null && dtUser.Rows.Count > 3)
            {
                intOverflow = 1;
                gridShipmentItems2.DataSource = dtUser;
                gridShipmentItems2.DataBind();
            }
            return strShipHtml;
        }

        protected string DisplaySkidItems(int pickupreqid)
        {
            string strShipHtml = "";
            DataTable dtUser;
            dtUser = PickupRequestBL.FetchSkidItems(pickupreqid);
            return strShipHtml;
        }

        string[] arr1 = { "20. SCHEDULE B DESCRIPTION OF COMMODITIES", "25. VIN/PRODUCT NUMBER/VEHICLE TITLE NUMBER", "<b>26. VALUE</b> (USD, omit cents) (selling price or cost if not sold)", "H.M(X)", "<b>COMMODITY DESCRIPTION</b> <br /> Commodities requiring special or additional care or attention in handling or stowing must be so marked and packaged as to ensure safe transportation with ordinary care. <b>See Section 2(e) of NMFC Item 36O</b>", "LTL ONLY" };
        string[] arr2 = { "21. D/F", "22. SCHEDULE B NUMBER", "23. QUANTITY SCHEDULE B UNIT(S)", "<b>24. SHIPPING WEIGHT </b>&nbsp;(Kilos)", "NMFC #", "CLASS" };
        int TotQty1 = 0;
        int TotQty2 = 0;
        decimal TotdSkidWeight = 0;
        protected void gridShipmentItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
                for (int i = 0; i < 3; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Font.Bold = true;
                    if (i == 0)
                    {
                        cell.ColumnSpan = 4;
                    }
                    else if (i == 1 || i == 2)
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
                gridShipmentItems.Controls[0].Controls.AddAt(0, row);
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
                gridShipmentItems.Controls[0].Controls.AddAt(1, row1);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strPackQtyType_SI = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PackageQuantity_SI")) + "&nbsp;" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PackageType_SI"));
                ((Label)e.Row.FindControl("lblPackQtyType_SI")).Text = strPackQtyType_SI;
                string strWeight_SI = Convert.ToString(Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Weight_SI")) * 0.4536);
                ((Label)e.Row.FindControl("lblWeight_SI")).Text = strWeight_SI;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
            }
        }

        string[] arr3 = { "14. Schedule B description of Commodities,", "<p align=center><i>(use&nbsp;columns&nbsp;17-19)</i></p>", "<p align=center><b>Shipper's Ref. No.</b>", "<p align=center><b>Ship Date</b><br>", "<b>COMMODITY DESCRIPTION</b> <br /> Commodities requiring special or additional care or attention in handling or stowing must be so marked and packaged as to ensure safe transportation with ordinary care. <b>See Section 2(e) of NMFC Item 36O</b>", "LTL ONLY" };
        string[] arr4 = { "<b>15. Marks, Nos., and kinds of packages.</b><br>", "23. QUANTITY SCHEDULE B UNIT(S)", "<b>24. SHIPPING WEIGHT </b>&nbsp;(Kilos)", "NMFC #", "CLASS" };
        string[] arr5 = { "<p align=center><b>16. D/F</b></p>", "<p align=center><b>17. Schedule B Number</b></p>", "<p align=center><b>Check Digit</b></p>", "<p align=center><b>18. Units</b></p>", "<p align=center><b>19. Wt (Kilos )</b></p>", "<p align=center><b>20. Value (USD, omit cents) (selling price or cost if not sold)</b></p>" };
        int TotPackageQuantity_SI = 0;
        protected double dblTotalDeclaredValue = 0.00;
        protected void gridShipmentItems1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
                for (int i = 0; i < 4; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Font.Bold = true;
                    if (i == 0)
                    {
                        cell.ColumnSpan = 3;
                    }
                    else if (i == 1 || i == 2 || i == 3)
                    {
                        cell.RowSpan = 2;
                    }
                    else
                    {
                        cell.ColumnSpan = 1;
                    }
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Top;
                    if (i == 2)
                    {
                        cell.Text = arr3[i].ToString() + strShipFromRefNumber + "</p>";
                    }
                    else if (i == 3)
                    {
                        cell.Text = arr3[i].ToString() + strShipFromDate + "</p>";
                    }
                    else
                    {
                        cell.Text = arr3[i].ToString();
                    }
                    row.Cells.Add(cell);
                }
                gridShipmentItems1.Controls[0].Controls.AddAt(0, row);
                GridViewRow row1 = new GridViewRow(1, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
                for (int i = 0; i < 1; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Font.Bold = true;
                    if (i == 0)
                    {
                        cell.ColumnSpan = 3;
                    }
                    else
                    {
                        cell.ColumnSpan = 1;
                    }
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Top;
                    cell.Text = arr4[i].ToString();
                    row1.Cells.Add(cell);
                }
                gridShipmentItems1.Controls[0].Controls.AddAt(1, row1);

                GridViewRow row2 = new GridViewRow(2, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
                for (int i = 0; i < 6; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Font.Bold = true;
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Top;
                    cell.Text = arr5[i].ToString();
                    row2.Cells.Add(cell);
                }
                gridShipmentItems1.Controls[0].Controls.AddAt(2, row2);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double dblDeclaredValue_SI = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DeclaredValue_SI"));
                dblTotalDeclaredValue = dblTotalDeclaredValue + dblDeclaredValue_SI;

                string strExportScheduleB_SI = "";
                strExportScheduleB_SI = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ExportScheduleB_SI"));
                if (strExportScheduleB_SI != "")
                    ((Label)e.Row.FindControl("lblExportScheduleB_SI_X")).Text = "X&nbsp;";
                string strPackQtyType_SI = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PackageQuantity_SI")) + "&nbsp;" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PackageType_SI"));
                ((Label)e.Row.FindControl("lblPackQtyType_SI")).Text = strPackQtyType_SI;
                string strWeight_SI = Convert.ToString(Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Weight_SI")) * 0.4536);
                ((Label)e.Row.FindControl("lblWeight_SI")).Text = strWeight_SI;

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
            }
        }
    }
}
