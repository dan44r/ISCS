<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ViewInformationRequest.aspx.cs" Inherits="ISCS.Admin.ViewInformationRequest"
    Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                View Information Request</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Information Request Details</h3>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Service Type:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblServiceType" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Name:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Address:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    City:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    State:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblState" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Zip:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblZip" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Phone:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Email:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Replied:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblReplied" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 10px">
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnRetuen" runat="server" CausesValidation="false" Text="Return"
                                    CssClass="adminButton" OnClick="btnRetuen_Click" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
