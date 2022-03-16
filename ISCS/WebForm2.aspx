<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="WebForm2.aspx.cs" Inherits="ISCS.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="divContent" runat="server" class="inr-cont">
            <h2 class="CMS">
                Contact Info</h2>
            <p style="margin-left: 60px">
                <b>Telephone :</b><br />
                508 385-7624
            </p>
            <br class="clear" />
            <p style="margin-left: 60px">
                <b>FAX :</b><br />
                508 385-6836
            </p>
            <br class="clear" />
            <p style="margin-left: 60px">
                <b>Mailing Address :</b><br />
                900 Rte 134 Suite 2-17<br />
                South Dennis, MA 02660
            </p>
            <br class="clear" />
            <p style="margin-left: 60px">
                <b>Physical Address :</b><br />
                900 Rte 134 Suite 2-17<br />
                South Dennis, MA 02660
            </p>
            <br class="clear" />
            <p style="margin-left: 60px">
                <b>Electronic mail :</b><br />
                General information <a href="mailto:info@glshome.com">info@glshome.com</a><br />
                Sales <a href="mailto:sales@glshome.com">sales@glshome.com</a><br />
                Customer support <a href="mailto:support@glshome.com">support@glshome.com</a>
            </p>
        </div>
    </div>
</asp:Content>
