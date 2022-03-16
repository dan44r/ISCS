<%@ Page Title="Page Content" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="PageContent.aspx.cs" Inherits="ISCS.Admin.PageContent"
    Theme="Admin" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Page Content</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="4">
                                <h3>
                                    <span>Page Details :</span><asp:Label ID="lblPages" runat="server" Text=""></asp:Label></h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Page Title :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPageTitle" MaxLength="64" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Meta Keywords :</label>
                            </td>
                            <td>
                                <textarea id="txtareaMetaKeywords" class="NoEditor" cols="20" rows="2" runat="server"></textarea>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Meta Decription :</label>
                            </td>
                            <td>
                                <textarea id="txtareaMetaDescription" class="NoEditor" cols="20" rows="2" runat="server"></textarea>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="4">
                                <h3>
                                    Page Content</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <FCKeditorV2:FCKeditor ID="FCKeditor1" Width="678px" Height="480px" runat="server"
                                    BasePath="/Include/fckeditor/">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:RequiredFieldValidator ID="reqContent" ControlToValidate="FCKeditor1" runat="server"
                                    ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" Text="Update" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnBack" runat="server" CausesValidation="false" CssClass="adminButton"
                                    Text="Back" OnClick="btnBack_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
