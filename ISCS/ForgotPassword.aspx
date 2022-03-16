<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/UserMaster.Master"
    AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="ISCS.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="inr-cont feedback">
            <h2>
                Forgot Password</h2>
            <div class="inner_form_cont">
                <fieldset>
                    <legend>Please enter your e-mail address and we will immediately send your Member Password
                        to you.</legend>
                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                    <table cellpadding="10" cellspacing="0" align="left" border="0" width="740">
                        <tr>
                            <td style="height: 28px; width: 120px;">
                                <label>
                                    Name</label><label style="color: Red; width: 10px">
                                        *
                                    </label>
                            </td>
                            <td style="width: 140px;">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter name"
                                    ControlToValidate="txtName" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator><br
                                        class="spacer" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Email Address</label>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter email"
                                    ControlToValidate="txtEmail" Display="Dynamic" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator1" runat="server" ErrorMessage="Proper E-mail Required"
                                        ControlToValidate="txtEmail" Display="Dynamic" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="reg"></asp:RegularExpressionValidator><br class="spacer" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnSendPass" runat="server" Width="120px" Text="Send Password" OnClick="btnSendPass_Click"
                                    ValidationGroup="reg" class="userBtn" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <h6>
                    (You may also call for your password: 565-6556-56565)</h6>
            </div>
        </div>
    </div>
</asp:Content>
