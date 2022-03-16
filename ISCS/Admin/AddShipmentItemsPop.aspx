<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddShipmentItemsPop.aspx.cs"
    Inherits="ISCS.Admin.AddShipmentItemsPop" Theme="Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" language="javascript">
        function loadparent() {
            window.parent.parent.document.aspnetForm.submit();
        }
    </script>

</head>
<body onunload="parent.reload();">
    <form id="form1" runat="server">
    <div>
        <div class="rht-cont">
            <div class="serviceBox">
                <h2>
                    Shipment Items Information</h2>
                <div class="whiteBox">
                    <table>
                        <tr>
                            <td>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                Package Quantity:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPackageQuantity" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPackageQuantity" ControlToValidate="txtPackageQuantity"
                                    runat="server" Display="Dynamic" ErrorMessage="Please enter package quantity"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                Package Type:
                            </td>
                            <td>
                                <asp:DropDownList ID="drpPackageType" Width="147px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPackageType" runat="server" Display="Dynamic"
                                    ControlToValidate="drpPackageType" InitialValue="0" ErrorMessage="Please select package type"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                Weight:
                            </td>
                            <td>
                                <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqWeight" runat="server" Display="Dynamic" ControlToValidate="txtWeight"
                                    ErrorMessage="Please enter Weight"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                Product Description:
                            </td>
                            <td>
                                <textarea id="txtareaProdDescription" cols="20" rows="2" runat="server"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqProdDescription" runat="server" Display="Dynamic"
                                    ControlToValidate="txtareaProdDescription" ErrorMessage="Please enter product description"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                Part Number:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPartNumber" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPartNumber" runat="server" Display="Dynamic" ControlToValidate="txtPartNumber"
                                    ErrorMessage="Please enter part number"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Purchase Order Number:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPONumber" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Lot Number:
                            </td>
                            <td>
                                <asp:TextBox ID="txtLotNumber" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Declared Value:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDeclaredValue" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" CssClass="BtnCommon" Width="70px" Text="Add"
                                    OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblMsg" ForeColor="Red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
