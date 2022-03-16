using System;

namespace ISCS
{
    public partial class TrackShipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTrack_Click(object sender, EventArgs e)
        {
            if (txtTrackingNo.Text.ToString().Trim() == "" && txtPONo.Text.ToString().Trim() == "")
            { lblError.Text = "Please enter either Tracking number or PO number"; return; }
            if (txtTrackingNo.Text.ToString().Trim() != "" && txtPONo.Text.ToString().Trim() != "")
            { lblError.Text = "Please enter either Tracking number or PO number"; return; }
            if (txtTrackingNo.Text.ToString().Trim() != "")
            {
                Response.Redirect("Shipment_viewNS.aspx?tno=" + txtTrackingNo.Text.ToString().Trim());

            }
            if (txtPONo.Text.ToString().Trim() != "")
            {
                Response.Redirect("Shipment_viewNS.aspx?tno=" + txtPONo.Text.ToString().Trim());

            }
        }
    }
}
