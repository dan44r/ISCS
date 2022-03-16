<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ManageShipmentTracking.aspx.cs" Inherits="ISCS.Admin.ManageShipmentTracking"
    Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Manage Shipment Tracking</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Choose A Single Tracking Bill</h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Edit Tracking Bill #:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpBills" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="editdrp" runat="server" Text="Edit" CssClass="adminButton" PostBackUrl="~/Admin/Shipment-Input.aspx"
                                    OnClick="editdrp_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ship-track" colspan="3">
                                or type a tracking number below
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Edit Tracking Bill #:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBillnumber" runat="server" ValidationGroup="grptxtbill"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="edittrackno" runat="server" Text="Edit" CssClass="adminButton" PostBackUrl="~/Admin/Shipment-Input.aspx"
                                    ValidationGroup="grptxtbill" OnClick="edittrackno_Click" />
                                <asp:RequiredFieldValidator ID="reqbillnumber" runat="server" Display="Dynamic" ControlToValidate="txtBillnumber"
                                    ErrorMessage="Please enter Bill Number" ValidationGroup="grptxtbill"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ship-track" colspan="3">
                                OR
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Find Tracking Bills Where...</h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Agent equals:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpAgents" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;"
                                width="20%">
                                <label>
                                    and Shipper equals:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpShipper" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;"
                                width="20%">
                                <label>
                                    and Consignee equals:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpConsignee" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;"
                                width="20%">
                                <label>
                                    and Shipped within:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpShippedDates" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnReset" runat="server" CausesValidation="false" Text="Reset" CssClass="adminButton"
                                    OnClick="btnReset_Click" />
                                <asp:Button ID="btnAdd" runat="server" Text="List Bills" CssClass="adminButton" OnClick="btnAdd_Click"
                                    PostBackUrl="~/Admin/shipmentlist.aspx" />
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
        <asp:HiddenField ID="hdnTrackingBillId" runat="server" />
        <asp:HiddenField ID="hdnTrackingNumber" runat="server" />
        <asp:HiddenField ID="hdnAgentId" runat="server" />
        <asp:HiddenField ID="hdnShipFromCompany" runat="server" />
        <asp:HiddenField ID="hdnShipToCompany" runat="server" />
        <asp:HiddenField ID="hdnShippedDates" runat="server" />
    </div>
</asp:Content>
