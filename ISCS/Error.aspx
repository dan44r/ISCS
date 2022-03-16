<%@ Page Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Error.aspx.cs" Inherits="ISCS.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="inr-cont feedback">
            <h2>
                Error</h2>
            <div class="inner_form_cont">
                <table style="background-color: Transparent!important;">
                    <tr>
                        <td style="width: 15px;">
                            <img src="Images/error-icon.gif" />
                        </td>
                        <td align="left" style="font-size: 16px;">
                            Error
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Sorry, please try again.
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <a style="color: #14AA14; font-size: 13px;" href="Default.aspx">Back to Home</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
