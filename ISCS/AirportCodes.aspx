<%@ Page Title="AirportCodes" Language="C#" MasterPageFile="~/UserMaster.Master"
    Theme="User" AutoEventWireup="true" CodeBehind="AirportCodes.aspx.cs" Inherits="ISCS.AirportCodes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="inr-cont">
            <h2>
                Airport Codes</h2>
            <table border="0" bordercolor="red" cellspacing="0" cellpadding="12" align="center"
                width="360">
                <tr>
                    <td colspan="2" align="left" valign="top" width="100%">
                        <img src="images/misc/spacer.gif" width="100" height="40">
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" width="50%">
                        <a href="DomesticCodes.aspx">Domestic Codes</a>
                    </td>
                    <td align="left" valign="top" width="50%">
                        <a href="InternationalCodes.aspx">International Codes</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
