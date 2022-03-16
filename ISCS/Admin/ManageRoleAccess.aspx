<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ManageRoleAccess.aspx.cs" Inherits="ISCS.Admin.ManageRoleAccess"
    Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Manage Role Access</h2>
            <div class="whiteBox">
                <asp:DropDownList ID="ddlUserTypes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserTypes_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <asp:DataList ID="dlRoleAccess" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table"
                    RepeatColumns="3" OnItemDataBound="dlRoleAccess_ItemDataBound" Width="100%">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSection" runat="server" Text='<%# Eval("Section") %>' />
                        <asp:HiddenField ID="hdnSectionId" runat="server" Value='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:DataList>
                <br />
                <br />
                <asp:Button ID="btnRoleAccess" runat="server" Text="Save" OnClick="btnRoleAccess_Click"
                    CssClass="adminButton" />
                <br />
                <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server"></asp:Label>
                <br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
