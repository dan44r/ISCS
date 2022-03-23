using BusinessLogicLayer;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web.UI.HtmlControls;

namespace ISCS
{
    public partial class InformationRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlAnchor lnk = new HtmlAnchor();

            lnk = this.Master.FindControl("lnkContact") as HtmlAnchor;
            if (lnk != null)
                lnk.Attributes.Add("class", "active");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strCaptchaText = Session["strRandom"].ToString();
            if (txtCaptchaText.Text.ToString().Trim() == strCaptchaText)
            {
                lblCpatchaMsg.Text = "";
                Boolean stat = false;
                MailMessage objMail = new MailMessage();
                EntityLayer.InfoRequest objEl = new EntityLayer.InfoRequest();
                int countService = 0;
                for (int i = 0; i < chkServiceType.Items.Count; i++)
                {
                    if (chkServiceType.Items[i].Selected == true)
                    {
                        countService = countService + 1;
                        if (objEl.ServiceType == null)
                        {
                            objEl.ServiceType = Convert.ToString(countService) + ")" + chkServiceType.SelectedItem.Text;
                        }
                        else
                        {
                            objEl.ServiceType = objEl.ServiceType + " " + Convert.ToString(countService) + ")" + chkServiceType.SelectedItem.Text;
                        }
                    }
                }
                objEl.Name = txtName.Text.ToString().Trim();
                objEl.Address = txtAddress.Text.ToString().Trim();
                objEl.City = txtCity.Text.ToString().Trim();
                objEl.State = txtState.Text.ToString().Trim();
                objEl.Zip = txtZip.Text.ToString().Trim();
                objEl.Phone = txtPhone.Text.ToString().Trim();
                objEl.Email = txtEmail.Text.ToString().Trim();

                try
                {
                    stat = BusinessLogicLayer.InformationRequestBL.InsertInfoReqest(objEl);
                }
                catch (Exception ex)
                { }

                StringBuilder sbMailBody = new StringBuilder();
                sbMailBody.Append("<table><tr><td>Service Type : </td><td>");
                sbMailBody.Append(objEl.ServiceType);
                sbMailBody.Append("</td></tr><tr><td>Name : </td><td>");
                sbMailBody.Append(objEl.Name);
                sbMailBody.Append("</td></tr><tr><td>Address : </td><td>");
                sbMailBody.Append(objEl.Address);
                sbMailBody.Append("</td></tr><tr><td>City : </td><td>");
                sbMailBody.Append(objEl.City);
                sbMailBody.Append("</td></tr><tr><td>State : </td><td>");
                sbMailBody.Append(objEl.State);
                sbMailBody.Append("</td></tr><tr><td>Zip : </td><td>");
                sbMailBody.Append(objEl.Zip);
                sbMailBody.Append("</td></tr><tr><td>Phone : </td><td>");
                sbMailBody.Append(objEl.Phone);
                sbMailBody.Append("</td></tr><tr><td>Email : </td><td>");
                sbMailBody.Append(objEl.Email);

                sbMailBody.Append("</td></tr></table>");

                CommonBL.sendMailInHtmlFormat(objEl.Email, ConfigurationManager.AppSettings["AdminEmail"].Trim(), "ISCS Information Request", sbMailBody.ToString());

                if (stat == true)
                {
                    lblMsg.Text = "Your request has been sent succesfully.";
                    hdMsg.Value = "Thank you for submitting your request.";
                }
                else
                {
                    lblMsg.Text = "Sorry, please try again later.";
                }
            }
            else
            {
                lblCpatchaMsg.Text = "Please enter security code correctly";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("InformationRequest.aspx");
        }
    }
}
