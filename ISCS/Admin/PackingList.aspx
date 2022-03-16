<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PackingList.aspx.cs" Inherits="ISCS.Admin.PackingList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td width="100%">
                    <table border="1" width="70%" cellpadding="2" id="ShipmentItems" style="border-collapse: collapse">
                        <tr>
                            <td valign="top">
                                <span><b>3PLI Tracking Number: </b></span>
                                <asp:Label ID="lblGlsTrackingNumber" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gridUsers" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                    Width="100%" AllowPaging="false" PageSize="2" AllowSorting="true" GridLines="None">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Qty" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" Text='<%# Eval("PackageQuantity_SI")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pkg Type" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPkgType" Text='<%# Eval("PackageType_SI")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Part No." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblParto" Text='<%# Eval("PartNumber_SI")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Handling Unit ID" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHandlingUnitId" Text='<%# String.Format("{0} - {1}", Eval("SkidId_SI"), Eval("GlsTrackingNumber")) %>'
                                                    runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Lot No." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLotNo" Text='<%# Eval("LotNumber_SI")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PO No." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoNo" Text='<%# Eval("PurchaseOrderNumber_SI")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" height="15">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
