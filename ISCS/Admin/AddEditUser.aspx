<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="AddEditUser.aspx.cs" Inherits="ISCS.Admin.AddEditUser" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Add / Edit User</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    User Details</h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    First Name:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqFirstName" runat="server" Display="Dynamic" ControlToValidate="txtFirstName"
                                    ErrorMessage="Please enter first name"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Last Name:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqLastName" runat="server" Display="Dynamic" ControlToValidate="txtLastName"
                                    ErrorMessage="Please enter last name"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    User Type:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpUserType" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqUserType" runat="server" Display="Dynamic" InitialValue="0"
                                    ControlToValidate="drpUserType" ErrorMessage="Please select user type"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;"
                                width="20%">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Account Code:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpAccountCode" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqAccountCode" runat="server" Display="Dynamic"
                                    InitialValue="0" ControlToValidate="drpAccountCode" ErrorMessage="Please select account code"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Phone:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPhone" runat="server" Display="Dynamic" ControlToValidate="txtPhone"
                                    ErrorMessage="Please enter phone number"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Fax:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFax" runat="server" MaxLength="20"></asp:TextBox>
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
                                    Email:</label>
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
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Password:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPassword" runat="server" Display="Dynamic" ControlToValidate="txtPassword"
                                    ErrorMessage="Please enter password"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Active:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpActive" runat="server">
                                    <asp:ListItem Text="Active" Value="active"></asp:ListItem>
                                    <asp:ListItem Text="Deactivate" Value="deactive"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Company:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Address1:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Address2:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    City:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
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
                                    State:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpState" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqState" runat="server" Display="Dynamic" InitialValue="0"
                                    ControlToValidate="drpState" ErrorMessage="Please select state"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Postal Code:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPostalCode" runat="server" MaxLength="7"></asp:TextBox>
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
                                    Country:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpCountry" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqCountry" runat="server" Display="Dynamic" InitialValue="0"
                                    ControlToValidate="drpCountry" ErrorMessage="Please select country"></asp:RequiredFieldValidator>
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
