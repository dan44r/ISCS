<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="TrackShipment.aspx.cs" Inherits="ISCS.TrackShipment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="inr-cont feedback">
            <h2>
                Track Shipment</h2>
            <div class="inner_form_cont">
                <fieldset>
                    <legend>Please enter your tracking number or PO number.</legend>
                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                    <table cellpadding="10" cellspacing="0" align="left" border="0" width="740">
                        <tr>
                            <td style="height: 28px; width: 120px; padding-top: 5px">
                                <label>
                                    Tracking Number</label>
                            </td>
                            <td style="width: 140px; padding-top: 5px">
                                <asp:TextBox ID="txtTrackingNo" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <br class="spacer" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px; width: 120px; padding-top: 5px">
                                <label>
                                    PO number</label>
                            </td>
                            <td style="width: 140px; padding-top: 5px">
                                <asp:TextBox ID="txtPONo" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <br class="spacer" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnTrack" runat="server" Width="120px" Text="Display" OnClick="btnTrack_Click"
                                    class="userBtn" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
