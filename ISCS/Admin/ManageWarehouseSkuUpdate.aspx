<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ManageWarehouseSkuUpdate.aspx.cs" Inherits="ISCS.Admin.ManageWarehouseSkuUpdate"
    Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" language="javascript">
        function NumericCheck(event) {
            var code = window.event ? event.keyCode : event.which;
            if ((code >= 48 && code <= 57) || (code == 8 || code == 37 || code == 39 || code == 46 || code == 9)) {
                return true;
            }
            else {
                return false;
            }
        }    
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Edit Warehouse Item</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Item Details</h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Part Number:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpartnumber" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqpartnumber" runat="server" Display="Dynamic" ControlToValidate="txtpartnumber"
                                    ErrorMessage="Please enter Part Number"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Lot Number:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtlotnumber" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqlotnumber" runat="server" Display="Dynamic" ControlToValidate="txtlotnumber"
                                    ErrorMessage="Please enter Lot Number"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Description:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" Rows="3" Columns="10"
                                    MaxLength="255"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqdescription" runat="server" Display="Dynamic"
                                    ControlToValidate="txtdescription" ErrorMessage="Please enter Description"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;"
                                width="20%">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Package Type:</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpPackageType" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqpackagetype" runat="server" Display="Dynamic"
                                    InitialValue="0" ControlToValidate="drpPackageType" ErrorMessage="Please enter Package Type"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Quantities</h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    On Hand:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtonhand" runat="server" onkeydown="return NumericCheck(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqonhand" runat="server" Display="Dynamic" ControlToValidate="txtonhand"
                                    ErrorMessage="Please enter On Hand Qty"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Pending:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpending" runat="server" onkeydown="return NumericCheck(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqpending" runat="server" Display="Dynamic" ControlToValidate="txtpending"
                                    ErrorMessage="Please enter Pending Qty"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Available:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblAvailableQty" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnRetuen" runat="server" CausesValidation="false" Text="Return"
                                    CssClass="adminButton" OnClick="btnRetuen_Click" />
                                <asp:Button ID="btnAdd" runat="server" Text="Update" CssClass="adminButton" OnClick="btnAdd_Click" />
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
