<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageShipFromWarehouseSkuPop.aspx.cs"
    Inherits="ISCS.Admin.ManageShipFromWarehouseSkuPop" Theme="Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript" language="Javascript">
        function searchkeytextblank(txtbox) {
            if (txtbox.value == 'Keywords') {
                txtbox.value = '';
            }
        }
        function searchkeytextfill(txtbox) {
            if (txtbox.value == '') {
                txtbox.value = 'Keywords';
            }
        }
        function Validate() {
            var strchk1 = document.getElementById('gridUsers').getElementsByTagName('input');
            var iCheckedCount = 0;
            for (i = 0; i < strchk1.length; i++) {
                if (strchk1[i].type == 'checkbox' && strchk1[i].id.indexOf('chkselect') != -1) {
                    if (strchk1[i].checked) {
                        iCheckedCount++;
                    }
                }
            }
            if (iCheckedCount == 0) {
                alert('please select item(s)');
                return false;
            }
            if (!document.getElementById('chkdomestic').checked &&
        !document.getElementById('chkinternational').checked) {
                alert('please select either Domestic or International');
                return false;
            }
            if (document.getElementById('chkdomestic').checked &&
        document.getElementById('chkinternational').checked) {
                alert('please select either Domestic or International');
                return false;
            }

            return true;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="rht-cont">
            <div class="serviceBox">
                <h2>
                    Manage Warehouse Item List</h2>
                <div class="whiteBox userListPan">
                    <table width="100%">
                        <tbody>
                            <tr>
                                <td class="fieldSpaceTop">
                                </td>
                                <td align="right">
                                </td>
                                <td class="fieldSpaceTop">
                                </td>
                                <td align="right">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div>
                                        <asp:GridView ID="gridUsers" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                            Width="100%" AllowPaging="True" PageSize="10" AllowSorting="true" OnPageIndexChanging="gridUsers_PageIndexChanging"
                                            OnRowCommand="gridUsers_RowCommand" GridLines="None" OnRowDataBound="gridUsers_RowDataBound">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkselect" runat="server" />
                                                        <asp:HiddenField ID="hidFInventoryid" runat="server" Value='<%# Eval("InventoryId")%>' />
                                                        <asp:HiddenField ID="hidtrackingNo" runat="server" Value='<%# Eval("GLSTrackingNumber_WI")%>' />
                                                        <asp:HiddenField ID="hidContactEmail" runat="server" Value='<%# Eval("ContactEmail")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkmaskedskid" CommandName="sortmaskedskid" Text="Skid Identifier"
                                                            runat="server"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmaskedskid" Text='<%# Eval("maskedskid")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkPartNumber" CommandName="sortPartNumber" Text="Part Number"
                                                            runat="server"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPickupRequestid" runat="server" Text='<%# Eval("PickupRequestId_WI") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label ID="lblPartNumber" Text='<%# Eval("PartNumber_WI")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkLotNumber" CommandName="sortLotNumber" Text="Lot Number" runat="server"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLotNumber" Text='<%# Eval("LotNumber_WI")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemDescription" Text='<%# Eval("Description_WI")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Package Type" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemPackageType" Text='<%# Eval("PackageType_WI")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Available Qty" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblavailableqty" Text='<%# Eval("AvailableQuantity")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date Added" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblreceiptdate" Text='<%# Eval("DateAdded_WI")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pick Quantity" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="drpPickQ" runat="server">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    Please indicate if this is a Domestic or International Shipment
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnshipall" runat="server" CausesValidation="false" Text="Ship All Items"
                                        CssClass="adminButton" OnClick="btnshipall_Click" Width="105px" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkdomestic" runat="server" Text="Domestic" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkinternational" runat="server" Text="International" />
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnshipselected" runat="server" CausesValidation="false" Text="Ship Items"
                                        CssClass="adminButton" OnClick="btnshipselected_Click" OnClientClick="return Validate();" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
