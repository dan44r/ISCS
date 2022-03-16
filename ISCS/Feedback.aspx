<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Feedback.aspx.cs" Inherits="ISCS.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="inr-cont feedback">
            <h2>
                Feedback</h2>
            <div class="inner_form_cont">
                <h3>
                    Tell us what you think about our web site, our services, our organization, or anything
                    else that comes to mind.<br />
                    We welcome all of your comments and suggestions.</h3>
                <fieldset>
                    <legend>What kind of comment would you like to send?</legend>
                    <asp:RadioButtonList ID="radioList" Width="740px" RepeatDirection="Horizontal" runat="server"
                        CssClass="radioList">
                        <asp:ListItem Text="Complaint" Value="Complaint"></asp:ListItem>
                        <asp:ListItem Text="Problem" Value="Problem"></asp:ListItem>
                        <asp:ListItem Text="Suggestion" Value="Suggestion" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Praise" Value="Praise"></asp:ListItem>
                    </asp:RadioButtonList>
                </fieldset>
                <fieldset>
                    <legend>What about us do you want to comment on?</legend>
                    <table class="radioList" border="0" width="740">
                        <tr>
                            <td>
                                <asp:DropDownList ID="drpAbout" CssClass="radioList" runat="server">
                                    <asp:ListItem Text="Web Site" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Company" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Solutions" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Employee" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="(Other)" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                                <label class="redio">
                                    Other :</label>
                                <asp:TextBox ID="txtAboutOther" CssClass="txtbx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend>Enter your comments in the space provided below:</legend>
                    <table id="Table1" class="radioList" border="0" width="740">
                        <tr>
                            <td>
                                <textarea id="txtareaComments" rows="5" cols="55" runat="server"></textarea>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend>Tell us how to get in touch with you:</legend>
                    <table cellpadding="10" cellspacing="0" align="left" border="0" width="740">
                        <tr>
                            <td style="height: 28px" width="167">
                                <label>
                                    Name</label><label style="color: Red; width: 10px">
                                        *
                                    </label>
                            </td>
                            <td width="140">
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
                                    Company</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    E-mail</label><label style="color: Red; width: 10px">
                                        *
                                    </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="Please enter email"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="Please enter proper email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Tel</label><label style="color: Red; width: 10px">
                                        *
                                    </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="reqPhone" runat="server" ControlToValidate="txtTelephone"
                                    Display="Dynamic" ErrorMessage="Please enter phone number"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    FAX</label><label style="color: Red; width: 10px">
                                        *
                                    </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="reqFax" runat="server" ControlToValidate="txtFax"
                                    Display="Dynamic" ErrorMessage="Please enter fax number"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px" colspan="3">
                                <asp:CheckBox ID="chkArgent" runat="server" CssClass="checkbox" Text="Please contact me as soon as possible regarding this matter." />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px">
                                <label>
                                    Enter the Security Code</label><label style="color: Red; width: 10px">
                                        *
                                    </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCaptchaText" CssClass="registercaptcha" runat="server"></asp:TextBox>&nbsp;<img
                                    alt="" src="Captcha.aspx" height="23px" width="80px" />
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqCaptchaText" runat="server" Display="Dynamic"
                                    ControlToValidate="txtCaptchaText" ErrorMessage="Please enter security code"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblCpatchaMsg" ForeColor="Red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <div style="float: left; padding-top: 10px;">
                    <p>
                        <asp:Button ID="btnSubmit" runat="server" CssClass="userBtn" Width="130px" Text="Submit Comments"
                            OnClick="btnSubmit_Click" PostBackUrl="~/ThankYou.aspx" />
                        <br />
                    </p>
                    <p>
                        <asp:Label ID="lblMsg" ForeColor="Red" runat="server"></asp:Label><br />
                        <asp:HiddenField ID="hdMsg" runat="server" />
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
