<%@ Page Title="Secure Login" Language="C#" MasterPageFile="~/UserMaster.Master"
    AutoEventWireup="true" CodeBehind="SecureLogin.aspx.cs" Inherits="ISCS.SecureLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="inr-cont feedback">
            <h2>
                Secure Login</h2>
            <div class="inner_form_cont">
                <fieldset>
                    <legend>Please enter email id and password</legend>
                    <table cellpadding="10" cellspacing="0" align="left" border="0" width="740">
                        <tr>
                            <td style="height: 0px; width: 120px;">
                                <label>
                                    E mail</label>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                            </td>
                            <td style="width: 270px;">
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" runat="server"
                                    Display="Dynamic" ErrorMessage="Please enter email"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="Please enter proper email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 0px; width: 120px; padding-top: 0px;">
                                <label>
                                    Password</label><label style="color: Red; width: 10px">*
                                    </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword"
                                    ErrorMessage="Please enter password"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button runat="server" Width="60px" ID="btnAuthenticate" Text="Login" OnClick="btnAuthenticate_Click"
                                    class="userBtn" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
