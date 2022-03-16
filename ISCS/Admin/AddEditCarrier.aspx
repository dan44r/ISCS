<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="AddEditCarrier.aspx.cs" Inherits="ISCS.Admin.AddEditCarrier" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Add / Edit Carrier</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Carrier Details</h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" width="280px" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Carrier Name:</label>
                            </td>
                            <td width="280px">
                                <asp:TextBox ID="txtCarrierName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqCarrierName" runat="server" Display="Dynamic"
                                    ControlToValidate="txtCarrierName" ErrorMessage="Please enter Carrier Name"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Address:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqAddress" runat="server" Display="Dynamic" ControlToValidate="txtAddress"
                                    ErrorMessage="Please enter Address"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    City:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqCity" runat="server" Display="Dynamic" ControlToValidate="txtCity"
                                    ErrorMessage="Please enter City"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;"
                                width="20%">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    State:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpState" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqState" runat="server" Display="Dynamic" InitialValue="0"
                                    ControlToValidate="drpState" ErrorMessage="Please enter State"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Postal Code:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPostalCode" runat="server" MaxLength="7"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPostalCode" runat="server" Display="Dynamic" ControlToValidate="txtPostalCode"
                                    ErrorMessage="Please enter Postal Code"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Contact Name:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqContactName" runat="server" Display="Dynamic"
                                    ControlToValidate="txtContactName" ErrorMessage="Please enter Contact Name"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Contact Phone:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactPhone" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqContactPhone" runat="server" Display="Dynamic"
                                    ControlToValidate="txtContactPhone" ErrorMessage="Please enter Contact Phone"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Contact Fax:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactFax" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Contact Email:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqEmail" runat="server" Display="Dynamic" ControlToValidate="txtEmail"
                                    ErrorMessage="Please enter email"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="Please enter proper email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                                <asp:Button ID="btnRetuen" runat="server" CausesValidation="false" Text="Return"
                                    CssClass="adminButton" OnClick="btnRetuen_Click" />
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="adminButton" OnClick="btnAdd_Click" />
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
