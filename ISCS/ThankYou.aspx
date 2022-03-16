<%@ Page Title="ISCS" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="ThankYou.aspx.cs" Inherits="ISCS.ThankYou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="inr-cont feedback">
            <h2>
                Thank you</h2>
            <div class="inner_form_cont">
                <h3>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </h3>
            </div>
        </div>
    </div>
</asp:Content>
