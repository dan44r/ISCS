<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="PostToQB.aspx.cs" Inherits="ISCS.Admin.PostToQB" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Post To Quickbooks</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Post To Quickbooks</h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                Click the "Add To QB" button to post today's data To Quickbooks
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3" style="height: 50px;">
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnRetuen" runat="server" CausesValidation="false" Text="Return"
                                    CssClass="adminButton" OnClick="btnRetuen_Click" />
                                <asp:Button ID="btnAdd" runat="server" Text="Add To QB" CssClass="adminButton" OnClick="btnAdd_Click" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
