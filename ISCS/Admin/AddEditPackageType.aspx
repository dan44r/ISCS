<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="AddEditPackageType.aspx.cs" Inherits="ISCS.Admin.AddEditPackageType"
    Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Add Package Type</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="1" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Quick Addition</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Package Type :</label>
                            </td>
                            <td style="width: 40%">
                                <asp:TextBox ID="txtPackageType" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPackageType" ControlToValidate="txtPackageType"
                                    runat="server" ErrorMessage="Please enter package type"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 30px;">
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" CssClass="adminButton" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" CssClass="adminButton" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                    CausesValidation="false" />
                            </td>
                            <td>
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
