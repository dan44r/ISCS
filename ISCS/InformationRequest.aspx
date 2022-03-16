<%@ Page Title="InformationRequest" Language="C#" MasterPageFile="~/UserMaster.Master"
    AutoEventWireup="true" CodeBehind="InformationRequest.aspx.cs" Inherits="ISCS.InformationRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="inr-cont feedback">
            <h2>
                Information Request</h2>
            <div class="inner_form_cont">
                <fieldset>
                    <legend>Select the items that apply, and then let us know how to contact you.</legend>
                    <asp:CheckBoxList CssClass="radioList" Width="740" ID="chkServiceType" runat="server">
                        <asp:ListItem Text="Send Services Literature." Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Send company literature." Value="2"></asp:ListItem>
                        <asp:ListItem Text="Have a salesperson contact me." Value="3"></asp:ListItem>
                    </asp:CheckBoxList>
                </fieldset>
                <h3>
                    Please fill out the form and we will get back to you as soon as we can.</h3>
                <fieldset>
                    <legend>Name and E-mail address are required fields.</legend>
                    <table cellpadding="10" cellspacing="0" align="left" width="740" border="0">
                        <tr>
                            <td style="height: 28px; width: 150px;">
                                <label>
                                    Name</label><label style="color: Red; width: 10px">
                                        *
                                    </label>
                            </td>
                            <td style="width: 270px;">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="Please enter name"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Address</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    City</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    State</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Zip/Postal Code</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Phone</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    E-Mail Address</label>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="Please enter email."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="Enter proper email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                                <asp:TextBox ID="txtCaptchaText" CssClass="registercaptcha" runat="server"></asp:TextBox>&nbsp;<img
                                    alt="" src="Captcha.aspx" height="23px" width="80px" />
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="reqCaptchaText" runat="server" Display="Dynamic"
                                    ControlToValidate="txtCaptchaText" ErrorMessage="Please enter security code"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblCpatchaMsg" ForeColor="Red" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px" colspan="3">
                                <asp:Button ID="btnSubmit" runat="server" Width="110px" CssClass="userBtn" Text="Submit Comments"
                                    OnClick="btnSubmit_Click" PostBackUrl="~/ThankYou.aspx" />
                                <asp:Button ID="btnReset" runat="server" CausesValidation="false" CssClass="userBtn2"
                                    Width="60px" Text="Cancel" OnClick="btnReset_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblMsg" ForeColor="Red" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdMsg" runat="server" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
