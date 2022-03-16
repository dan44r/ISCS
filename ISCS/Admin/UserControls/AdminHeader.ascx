<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminHeader.ascx.cs"
    Inherits="ISCS.Admin.UserControls.AdminHeader" %>
<!-- header -->
<div id="header">
    <div class="header">
        <div class="logoarea">
            <h1 class="logo">
                <a href="https://3plintegration.net">
                    <img src="images/logo.jpg" alt="Logo" title="Logo" /></a></h1>
            <h2 class="admin-panel">
                Admin Panel&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button UseSubmitBehavior="false" ID="btnLogout" runat="server" Text="Log Out"
                    OnClick="btnLogout_Click" CausesValidation="false" CssClass="logoutButton" /></h2>
        </div>
    </div>
</div>
<!-- /header -->
