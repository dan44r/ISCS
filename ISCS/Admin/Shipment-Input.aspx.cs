using BusinessLogicLayer;
using CF.Web.Security;
using EntityLayer;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISCS.Admin
{
    public partial class ShipmentInput : System.Web.UI.Page
    {
        public int transportationmode = 0;
        public string PickupRequestID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = true;
            if (!IsPostBack)
            {
                BindDrpStatus();
                BindDrpMonth();
                BindDrpDay();
                BindDrpYear();
                BindDrpHour();
                BindDrpMin();
                BindDrpAgents();
            }
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack && PreviousPage.IsPostBack)
            {
                BindValues();
            }
        }
        protected void BindValues()
        {
            DataTable dtSI = null;
            int strtrackingbillid = 0;
            string strtrackingbillno = null;
            ContentPlaceHolder contentPh = (ContentPlaceHolder)Page.PreviousPage.Form.FindControl("ContentPlaceHolder1");
            HiddenField hftrackingbillid = (HiddenField)contentPh.FindControl("hdnTrackingBillId");
            HiddenField hftrackingbillno = (HiddenField)contentPh.FindControl("hdnTrackingNumber");
            if (hftrackingbillid != null)
            {
                if (hftrackingbillid.Value != null && hftrackingbillid.Value != "")
                {
                    strtrackingbillid = Convert.ToInt32(hftrackingbillid.Value);
                }
            }
            if (hftrackingbillno != null)
            {
                if (hftrackingbillno.Value != null && hftrackingbillno.Value != "")
                {
                    strtrackingbillno = hftrackingbillno.Value;
                }
            }
            if (strtrackingbillid > 0)
            {
                dtSI = TBillsBL.FetchByTrackingBillId(strtrackingbillid).Tables[0];
            }
            else
            {
                dtSI = TBillsBL.FetchByTrackingBillNo(strtrackingbillno).Tables[0];
            }

            if (dtSI.Rows.Count > 0)
            {
                pnltrack.Visible = true;
                pnlnorecord.Visible = false;
                hdtrackingbillid.Value = dtSI.Rows[0]["TrackingBillId"].ToString();
                hdairportid.Value = dtSI.Rows[0]["Airport_Id"].ToString();
                hdDimWeight.Value = dtSI.Rows[0]["dim_weight"].ToString();
                hdshipfromcompany.Value = dtSI.Rows[0]["ShipFromCompany"].ToString();
                hdshiptocompany.Value = dtSI.Rows[0]["ShipToCompany"].ToString();
                lbltrackingno.Text = dtSI.Rows[0]["tracking_no"].ToString();
                hidTrackingNo.Value = dtSI.Rows[0]["tracking_no"].ToString();
                lblshipdate.Text = dtSI.Rows[0]["Ship_Date"].ToString();
                drpstatus.SelectedValue = dtSI.Rows[0]["Status_Id"].ToString();
                DateTime dtime = Convert.ToDateTime(dtSI.Rows[0]["Status_Date"]);
                string month = string.Format("{0:d}", dtime).Split('/')[0];
                string day = string.Format("{0:d}", dtime).Split('/')[1];
                string year = string.Format("{0:d}", dtime).Split('/')[2];
                string hour = string.Format("{0:h hh H HH}", dtime).Split(' ')[0];
                string min = string.Format("{0:m mm}", dtime).Split(' ')[0];
                drpstatusmonth.SelectedValue = month.ToString();
                drpstatusday.SelectedValue = day.ToString();
                drpstatusyear.SelectedValue = year.ToString();
                drptimehr.SelectedValue = hour.ToString();
                drptimemin.SelectedValue = min.ToString();
                drpagentsid.SelectedValue = dtSI.Rows[0]["Agent_Id"].ToString();
                txtpieces.Text = dtSI.Rows[0]["Pieces"].ToString();
                txtactualweight.Text = dtSI.Rows[0]["Actual_Weight"].ToString();
                txtnotes.Text = dtSI.Rows[0]["Notes"].ToString();
                lblglscarriername.Text = dtSI.Rows[0]["GLSCarrierName"].ToString();
                StringBuilder sbshipper = new StringBuilder();
                sbshipper.Append(dtSI.Rows[0]["ShipFromCompany"] + ",<br />");
                sbshipper.Append(dtSI.Rows[0]["ShipFromAddress"] + ",<br />");
                sbshipper.Append(dtSI.Rows[0]["ShipFromCity"]);
                sbshipper.Append((dtSI.Rows[0]["ShipFromState"].ToString() != "") ? " ," + dtSI.Rows[0]["ShipFromState"] : "");
                sbshipper.Append("<br />");
                sbshipper.Append((dtSI.Rows[0]["ShipFromPostalCode"].ToString() != "") ? " " + dtSI.Rows[0]["ShipFromPostalCode"] : "");

                lblshipper.Text = sbshipper.ToString();

                StringBuilder sbconsignee = new StringBuilder();
                sbconsignee.Append(dtSI.Rows[0]["ShipToCompany"] + ",<br />");
                sbconsignee.Append(dtSI.Rows[0]["ShipToAddress"] + ",<br />");
                sbconsignee.Append(dtSI.Rows[0]["ShipToCity"]);
                sbconsignee.Append((dtSI.Rows[0]["ShipToState"].ToString() != "") ? " ," + dtSI.Rows[0]["ShipToState"] : "");
                sbconsignee.Append("<br />");
                sbconsignee.Append((dtSI.Rows[0]["ShipToPostalCode"].ToString() != "") ? " " + dtSI.Rows[0]["ShipToPostalCode"] : "");


                lblconsignee.Text = sbconsignee.ToString();

                lbltransmode.Text = dtSI.Rows[0]["TransMode"].ToString();
                transportationmode = Convert.ToInt32(dtSI.Rows[0]["TransMode"]);
                txtpronumber.Text = dtSI.Rows[0]["ProNumber"].ToString();
                txtpronumberinterm.Text = dtSI.Rows[0]["ProNumberInterm"].ToString();
                txtpronumberdelivery.Text = dtSI.Rows[0]["ProNumberDelivery"].ToString();
                txtpronumberother.Text = dtSI.Rows[0]["ProNumberOther"].ToString();

                lblglscarriernameinterm.Text = dtSI.Rows[0]["GLSCarrierNameInterm"].ToString();
                lblglscarriernamedelivery.Text = dtSI.Rows[0]["GLSCarrierNameDelivery"].ToString();
                lblglscarriernameother.Text = dtSI.Rows[0]["GLSCarrierNameOther"].ToString();
                lblshipperrefno.Text = dtSI.Rows[0]["ShipFromRefNumber"].ToString();
                lblconsigneerefno.Text = dtSI.Rows[0]["ShipToConsigneeRefNumber"].ToString();
                hdPickupRequestId.Value = dtSI.Rows[0]["PickupRequestId"].ToString();
                string strReqIDEncode = SecurityUtils.UrlEncode(Convert.ToString(dtSI.Rows[0]["PickupRequestId"].ToString()));
                PickupRequestID = strReqIDEncode;
            }
            else
            {
                pnltrack.Visible = false;
                pnlnorecord.Visible = true;
            }
        }

        protected void BindDrpStatus()
        {
            DataSet dtStatus = StatusBL.FetchAllStatus();
            drpstatus.DataSource = dtStatus.Tables[0];
            drpstatus.DataValueField = "id";
            drpstatus.DataTextField = "description";
            drpstatus.DataBind();
        }

        protected void BindDrpMonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                ListItem lstItem = new ListItem(new DateTime(1900, i, 1).ToString("MMM"), i.ToString());
                drpstatusmonth.Items.Add(lstItem);
            }
        }

        protected void BindDrpDay()
        {
            for (int i = 1; i <= 31; i++)
            {
                ListItem lstItem = new ListItem(i.ToString(), i.ToString());
                drpstatusday.Items.Add(lstItem);
            }
        }

        protected void BindDrpYear()
        {
            for (int i = DateTime.Now.AddYears(-10).Year; i <= DateTime.Now.Year + 1; i++)
            {
                ListItem lstItem = new ListItem(i.ToString(), i.ToString());
                drpstatusyear.Items.Add(lstItem);
            }
        }

        protected void BindDrpHour()
        {
            for (int i = 0; i <= 23; i++)
            {
                ListItem lstItem = new ListItem(i < 10 ? "0" + i.ToString() : i.ToString(), i.ToString());
                drptimehr.Items.Add(lstItem);
            }
        }

        protected void BindDrpMin()
        {
            for (int i = 0; i <= 55; i = i + 5)
            {
                ListItem lstItem = new ListItem(i < 10 ? "0" + i.ToString() : i.ToString(), i.ToString());
                drptimemin.Items.Add(lstItem);
            }
        }

        protected void BindDrpAgents()
        {
            //Get Agents
            DataTable dtAgent = UserBL.GetByUserTypeId(7);
            drpagentsid.DataSource = dtAgent;
            drpagentsid.DataValueField = "UserId";
            drpagentsid.DataTextField = "FirstName";
            drpagentsid.DataBind();
        }

        protected void btnRetuen_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageWarehouse.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean res = false;

                TBills objTBills = new TBills();
                objTBills.TrackingBillId = Convert.ToInt32(hdtrackingbillid.Value);//
                objTBills.tracking_no = lbltrackingno.Text;//

                DateTime shpDate = Convert.ToDateTime(lblshipdate.Text);

                objTBills.status_id = Convert.ToInt32(drpstatus.SelectedItem.Value);//            

                string statMonth = drpstatusmonth.SelectedItem.Value;
                string statDay = drpstatusday.SelectedItem.Value;
                string statYear = drpstatusyear.SelectedItem.Value;

                string stathour = drptimehr.SelectedItem.Value;
                string statMin = drptimemin.SelectedItem.Value;

                DateTime statdt = Convert.ToDateTime(statMonth + "/" + statDay + "/" + statYear + " " + stathour + ":" + statMin);//

                objTBills.status_date = statdt;

                objTBills.airport_id = Convert.ToInt32(hdairportid.Value);//

                if (drpagentsid.Items.Count > 0)
                {
                    if (drpagentsid.SelectedItem.Value != null && drpagentsid.SelectedItem.Value != "")
                    {
                        objTBills.agent_id = Convert.ToInt32(drpagentsid.SelectedItem.Value);//
                    }
                }

                int ipieces = 0;
                try
                {
                    ipieces = Convert.ToInt32(txtpieces.Text.ToString().Trim());
                }
                catch
                {
                    ipieces = 0;
                    txtpieces.Text = "0";
                }
                objTBills.pieces = ipieces;

                decimal iactual_weight = 0;
                try
                {
                    iactual_weight = Convert.ToDecimal(txtactualweight.Text.ToString().Trim());
                }
                catch
                {
                    iactual_weight = 0;
                    txtactualweight.Text = "0.00";
                }
                objTBills.actual_weight = iactual_weight;


                objTBills.dim_weight = Convert.ToDecimal(hdDimWeight.Value);//
                objTBills.notes = txtnotes.Text;//
                string strShipFromCom = hdshipfromcompany.Value;
                string strShiptoCom = hdshiptocompany.Value;
                objTBills.ProNumber = txtpronumber.Text;//
                objTBills.ProNumberInterm = txtpronumberinterm.Text;//
                objTBills.ProNumberDelivery = txtpronumberdelivery.Text;//
                objTBills.ProNumberOther = txtpronumberother.Text;//

                if (shpDate > statdt)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "The Status date" + " " + statdt + " cannot be earlier than the ship date" + " " + shpDate;
                }
                else
                {
                    res = TBillsBL.UpdateTbills(objTBills);
                    if (res)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Status update has been successfully done.";

                        if (txtpronumber.Text != "")
                        {
                            if (hidTrackingNo.Value != "")
                            {
                                VendorBillAmtXmlUpdation(hidTrackingNo.Value, txtpronumber.Text);
                            }
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Sorry, please try again later.";
                    }
                }
            }
            catch (Exception ex)
            {
                string Value = "========";
                Value += "Date : " + DateTime.Now.ToString();
                Value += "  Error : " + ex;
                string filename = ConfigurationManager.AppSettings["QBFilesPath"] + "/Shipment_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Second.ToString() + ".doc";
                string Path = (Server.MapPath(filename));
                using (FileStream fs = File.Create(Path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(Value);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

            }
        }

        public void VendorBillAmtXmlUpdation(string TrackingNo, string ProNumber)
        {
            string UnProcessedWithoutPronumber = ConfigurationManager.AppSettings["UnProcessedWithoutPronumber"].ToString();
            string UnProcessedPath = ConfigurationManager.AppSettings["UnProcessedPath"].ToString();
            string Desc = "TrackingNo : " + TrackingNo + " and ProNumber : " + ProNumber;
            string BillNo = ProNumber;
            DataTable dt = QBXmlFileBL.QBXMLFileDetailsByTrackingNo(TrackingNo);
            if (dt != null && dt.Rows.Count > 0)
            {
                string FileName = Convert.ToString(dt.Rows[0]["QBVendorAmtAddXmlFile"]);
                string AllFileData = "";
                string s = UnProcessedWithoutPronumber + FileName;

                FileInfo f = new FileInfo(s);
                if (f.Exists)
                {

                    StreamReader sr = new StreamReader(s);
                    AllFileData = sr.ReadToEnd();
                    sr.Close();
                    var body = AllFileData;

                    body = body.Replace("<Description></Description>", "<Description>" + Desc + "</Description>");
                    body = body.Replace("<DocNumber></DocNumber>", "<DocNumber>" + BillNo + "</DocNumber>");
                    File.WriteAllText(s, body.ToString());


                    if (!File.Exists(UnProcessedPath + f.Name))
                    {
                        f.MoveTo(UnProcessedPath + f.Name);
                    }
                    else if (File.Exists(UnProcessedPath + f.Name))
                    {
                        string param = DateTime.Now.ToString("hhmmss") + "-" + f.Name;
                        QBXmlFileBL.UpdateQBXMLFile(TrackingNo, param);
                        f.MoveTo(UnProcessedPath + param);

                    }
                }

            }

        }

        protected void delete_Click(object sender, EventArgs e)
        {
            Boolean res = false;

            int trackBill = Convert.ToInt32(hdtrackingbillid.Value);

            res = TBillsBL.DeleteTbills(trackBill);
            if (res)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Bill deletion has been successfully done.";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Sorry, please try again later.";
            }
        }

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageShipmentTracking.aspx");
        }
    }
}
