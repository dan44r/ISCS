<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="AddEditWarehouseLocation.aspx.cs" Inherits="ISCS.Admin.AddEditWarehouseLocation"
    Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Add Warehouse location</h2>
            <div class="whiteBox">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="4">
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
                            <td class="body_text_12" style="padding: 0pt 10px 0pt 0pt;" valign="middle" align="right">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Company Name :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyName" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqCompanyName" ControlToValidate="txtCompanyName"
                                    runat="server" ErrorMessage="Please enter company name"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" style="padding: 0pt 10px 0pt 0pt;" valign="middle" align="right">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Address :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqAddress" ControlToValidate="txtAddress" runat="server"
                                    ErrorMessage="Please enter Address"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" style="padding: 0pt 10px 0pt 0pt;" valign="middle" align="right">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    City :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqCity" ControlToValidate="txtCity" runat="server"
                                    ErrorMessage="Please enter city"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 0pt 10px 0pt 0pt;" class="body_text_12" valign="middle" width="165"
                                align="right">
                                <label>
                                    State :</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpState" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqState" ControlToValidate="drpState" runat="server"
                                    ErrorMessage="Please enter state"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" style="padding: 0pt 10px 0pt 0pt;" valign="middle" align="right">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Postal Code :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPostalCode" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPostalCode" ControlToValidate="txtPostalCode"
                                    runat="server" ErrorMessage="Please enter PostalCode"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 0pt 10px 0pt 0pt;" class="body_text_12" valign="middle" width="165"
                                align="right">
                                <label>
                                    Country :</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpCountry" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqCountry" ControlToValidate="drpCountry" runat="server"
                                    ErrorMessage="Please enter country"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" style="padding: 0pt 10px 0pt 0pt;" valign="middle" align="right">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Contact Name :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactName" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqContactName" ControlToValidate="txtContactName"
                                    runat="server" ErrorMessage="Please enter contact name"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" style="padding: 0pt 10px 0pt 0pt;" valign="middle" align="right">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Contact Phone :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactPhone" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqContactPhone" ControlToValidate="txtContactPhone"
                                    runat="server" ErrorMessage="Please enter contact phone"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" style="padding: 0pt 10px 0pt 0pt;" valign="middle" align="right">
                                <label>
                                    Contact Fax :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactFax" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" style="padding: 0pt 10px 0pt 0pt;" valign="middle" align="right">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Contact Email :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactEmail" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqContactEmail" ControlToValidate="txtContactEmail"
                                    Display="Dynamic" runat="server" ErrorMessage="Please enter contact email"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regexContactEmail" runat="server" ControlToValidate="txtContactEmail"
                                    Display="Dynamic" ErrorMessage="Please enter proper email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                                <asp:Button ID="btnCancel" CausesValidation="false" CssClass="adminButton" runat="server"
                                    Text="Cancel" OnClick="btnCancel_Click" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="2">
                                <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
</asp:Content>
