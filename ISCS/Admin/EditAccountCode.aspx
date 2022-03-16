<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="EditAccountCode.aspx.cs" Inherits="ISCS.Admin.EditAccountCode" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Add / Edit Account Code</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Account Code Details</h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;
                                width: 250px;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Account Code:</label>
                            </td>
                            <td style="width: 250px;">
                                <asp:TextBox ID="txtAccountCode" MaxLength="3" onkeypress="return onlyCodeAZ09(event)"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqAccountCode" runat="server" Display="Dynamic"
                                    ControlToValidate="txtAccountCode" ErrorMessage="Please enter Account Code"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regAccountCode" runat="server" ErrorMessage="Account Code must be 3 character"
                                    ControlToValidate="txtAccountCode" ValidationExpression="[0-9a-zA-Z]{3,}" />
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Account Name:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAccountName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqAccountName" runat="server" Display="Dynamic"
                                    ControlToValidate="txtAccountName" ErrorMessage="Please enter Account name"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Margin:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMargin" MaxLength="6" onkeypress="return onlyDigits(event,'decOK')"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td>
                                %
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
