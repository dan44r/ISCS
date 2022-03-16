<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ManageShipFromWarehouse.aspx.cs" Inherits="ISCS.Admin.ManageShipFromWarehouse"
    Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Manage Warehouse SKU List</h2>
            <div class="whiteBox userListPan">
                <table width="100%">
                    <tbody>
                        <tr>
                            <td class="fieldSpaceTop">
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldSpaceTop" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldSpaceTop" colspan="2">
                                <div id="aa">
                                    <table cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="drpSearchCol" runat="server">
                                                        <asp:ListItem Text="Select Search Type" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Warehouse Name" Value="CompanyName"></asp:ListItem>
                                                        <asp:ListItem Text="Skid Identifier" Value="GLSTrackingNumber_WI"></asp:ListItem>
                                                        <asp:ListItem Text="Part Number" Value="PartNumber_WI"></asp:ListItem>
                                                        <asp:ListItem Text="Lot Number" Value="LotNumber_WI"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:TextBox ID="txtSearchKey" onfocus="javascript:searchkeytextblank(this)" onblur="javascript:searchkeytextfill(this)"
                                                        Width="190px" Text="Keywords" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:Button ID="btnSearch" CssClass="adminButton" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 5px;">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="padding-top: 10px;"><a href="ManageShipFromWarehouse.aspx">View All</a></span>
                            </td>
                            <td align="right">
                                <a href="#">&nbsp;</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div>
                                    <asp:GridView ID="gridUsers" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                        Width="100%" AllowPaging="True" PageSize="10" AllowSorting="true" OnPageIndexChanging="gridUsers_PageIndexChanging"
                                        OnRowCommand="gridUsers_RowCommand" GridLines="None">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkWarehouseName" CommandName="sortWarehouseName" Text="Warehouse Name"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWarehouseName" Text='<%# Eval("WareHouseName")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkmaskedskid" CommandName="sortmaskedskid" Text="Skid Identifier"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkmaskedskidClick" Text='<%# Eval("maskedskid")%>' runat="server"
                                                        CommandArgument='<%# Eval("SkidId_WI")%>' OnClick="lnkmaskedskidClick_Click"
                                                        PostBackUrl="~/Admin/ManageShipFromWarehouseSku.aspx"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkPartNumber" CommandName="sortPartNumber" Text="Part Number"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
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
                                            <asp:TemplateField HeaderText="Available Qty" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblavailableqty" Text='<%# Eval("AvailableQuantity")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Receipt Date" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblreceiptdate" Text='<%# Eval("DateAdded_WI")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                    <asp:HiddenField ID="hidFSkuid" runat="server" />
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
