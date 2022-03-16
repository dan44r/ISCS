<%@ Page Title="Register" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="ISCS.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="inr-cont feedback">
            <h2>
                Register</h2>
            <div class="inner_form_cont">
                <h3>
                    **3PLISecure is available to all 3PLI Shippers and Consignees.**</h3>
                <h3>
                    There are 2 ways to register for 3PLISecure.</h3>
                <h3>
                    If you are a shipper or consignee with 3PLI, you can track your shipments very easily.
                    Simply call us at the number below.
                </h3>
                <h3>
                    An account manager will issue you your online tracking password. 888-884-0577
                </h3>
                <fieldset>
                    <legend>You may also email us, and we will send qualified applicants a password. All
                        fields are required.</legend>
                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                    <table cellpadding="10" cellspacing="0" align="left" border="0" width="740">
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Name</label>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter name"
                                    ControlToValidate="txtName" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator><br
                                        class="spacer" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Client Ref.Number</label><label style="color: Red; width: 10px">
                                        *
                                    </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtClientRefNum" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter client ref number"
                                    ControlToValidate="txtClientRefNum" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator><br
                                        class="spacer" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Phone</label>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter phone number"
                                    ControlToValidate="txtPhone" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator><br
                                        class="spacer" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Email Address</label><label style="color: Red; width: 10px">
                                        *
                                    </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter email"
                                    ControlToValidate="txtEmail" Display="Dynamic" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter proper email"
                                        ControlToValidate="txtEmail" Display="Dynamic" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="reg"></asp:RegularExpressionValidator><br class="spacer" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Enter the Security Code</label>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCaptcha" runat="server" CssClass="registercaptcha"></asp:TextBox>&nbsp;&nbsp;<img
                                    alt="" src="Captcha.aspx" height="23px" width="80px" />
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter the below text"
                                    ControlToValidate="txtCaptcha" SetFocusOnError="True" ValidationGroup="reg"></asp:RequiredFieldValidator><br
                                        class="spacer" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnRegister" runat="server" Width="90px" Text="Register" OnClick="btnRegister_Click"
                                    ValidationGroup="reg" class="userBtn" />
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
