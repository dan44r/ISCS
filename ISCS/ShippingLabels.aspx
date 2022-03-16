<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShippingLabels.aspx.cs"
    Inherits="ISCS.ShippingLabels" %>

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
                    <table border="0" width="70%" cellpadding="2" id="ShipmentItems" style="border-collapse: collapse">
                        <tr>
                            <td valign="top">
                                <span><b>ISCS Tracking Number: </b></span>
                                <asp:Label ID="lblGlsTrackingNumber" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnldoc" runat="server">
                                    <asp:GridView ID="gridUsers" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                        Width="100%" AllowPaging="false" PageSize="2" AllowSorting="true" GridLines="None"
                                        OnRowDataBound="gridUsers_RowDataBound">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                                                ItemStyle-VerticalAlign="Top">
                                                <ItemTemplate>
                                                    <table border="1" width="75%" cellpadding="2" id="ShipmentItems" style="border-collapse: collapse">
                                                        <tr>
                                                            <td width="100%" valign="top">
                                                                <table border="0" width="100%" cellpadding="2" id="ShipmentItems" style="border-collapse: collapse">
                                                                    <tr>
                                                                        <td class="large" align="center" valign="top">
                                                                            <h5>
                                                                                <span>ID Number:</span>&nbsp;<asp:Label ID="lblintSkidId_SI" runat="server" Text=""></asp:Label>&nbsp;&nbsp;-&nbsp;&nbsp;<asp:Label
                                                                                    ID="lblstrGlsTrackingNumber" runat="server" Text='<%# Eval("GLSTrackingNumber") %>'></asp:Label>&nbsp;&nbsp;(<asp:Label
                                                                                        ID="lblintSkidCounter" runat="server" Text=""></asp:Label>
                                                                                of
                                                                                <asp:Label ID="lblintSkidCount" runat="server" Text=""></asp:Label>)</h5>
                                                                            <p>
                                                                                &nbsp;</p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="large" valign="top">
                                                                            <span><b>SHIP TO</b></span><br>
                                                                            <asp:Label ID="lblstrShiptoCompany" runat="server" Text='<%# Eval("ShipToCompany") %>'></asp:Label><br>
                                                                            <asp:Label ID="lblstrShiptoAddress" runat="server" Text='<%# Eval("ShipToAddress") %>'></asp:Label><br>
                                                                            <asp:Label ID="lblstrShiptoCity" runat="server" Text='<%# Eval("ShipToCity") %>'></asp:Label>,
                                                                            <asp:Label ID="lblstrShiptoState" runat="server" Text='<%# Eval("ShipToState") %>'></asp:Label>&nbsp;<asp:Label
                                                                                ID="lblstrShiptoPostalCode" runat="server" Text='<%# Eval("ShipToPostalCode") %>'></asp:Label><br>
                                                                            <br>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="large" valign="top">
                                                                            <span><b>Contact:</b></span><br>
                                                                            <asp:Label ID="lblstrShipToContact" runat="server" Text='<%# Eval("ShipToContact") %>'></asp:Label><br>
                                                                            <span><b>Tel:</b></span>&nbsp;
                                                                            <asp:Label ID="lblstrShipToPhone" runat="server" Text='<%# Eval("ShipToPhone") %>'></asp:Label>&nbsp;<span><b>Fax:</b></span>&nbsp;
                                                                            <asp:Label ID="lblstrShipToFax" runat="server" Text='<%# Eval("ShipToFax") %>'></asp:Label><br>
                                                                            <span><b>Also Notify:</b></span>&nbsp;
                                                                            <asp:Label ID="lblstrShipToNotifyName" runat="server" Text='<%# Eval("ShipToNotifyName") %>'></asp:Label>&nbsp;<span><b>Tel:</b></span>&nbsp;
                                                                            <asp:Label ID="lblstrShipToNotifyPhone" runat="server" Text='<%# Eval("ShipToNotifyPhone") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table border="0" width="100%" cellpadding="2" id="Table1" style="border-collapse: collapse">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="gridContents" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                                                                Width="100%" AllowPaging="false" PageSize="2" AllowSorting="true" GridLines="None"
                                                                                OnRowDataBound="gridContents_RowDataBound">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Qty" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                                        ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblintPackageQuantity_SI" runat="server" Text='<%# Eval("PackageQuantity_SI") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Part No." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                                        ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblstrPartNumber_SI" runat="server" Text='<%# Eval("PartNumber_SI") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Center"
                                                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblstrDescription_SI" runat="server" Text='<%# Eval("Description_SI") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Weight" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                                        ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblintWeight_SI" runat="server" Text='<%# Eval("Weight_SI") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="PO Number" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                                        ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblstrPurchaseOrderNumber_SI" runat="server" Text='<%# Eval("PurchaseOrderNumber_SI") %>'></asp:Label>
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
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Panel ID="pnlnorecord" runat="server">
                                    <span><b>Sorry, No documents available now.</b></span>
                                </asp:Panel>
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
