<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="RequestMsg.aspx.cs" Inherits="ISCS.Admin.RequestMsg" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="request-msg">
                                Your pick up request has been sent to 3PL Integration, LLC
                            </td>
                        </tr>
                        <tr>
                            <td class="request-msg">
                                You will receive an email from 3PL Integration, LLC shortly confirming acceptance
                                of this request for pickup.
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
