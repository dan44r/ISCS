<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AirWaybill.aspx.cs" Inherits="ISCS.AirWaybill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Airway Bill</title>
    <style type="text/css">
        body
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11.0px;
        }
        .classPageBreak
        {
            page-break-after: always;
        }
        .SSE
        {
            font-size: 12px;
            color: #000000;
            font-family: Verdana, Tahoma, Arial, Helvetica;
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td valign="top" width="60%" align="left">
                    <!--Table No 1-->
                    <table width="100%" cellspacing="0" cellpadding="3" border="0">
                        <tr>
                            <td valign="top">
                                <img src="<%=strRelativePath%>images/logo.jpg" border="0">
                            </td>
                            <td valign="top" style="width: 160px">
                                VIA:
                                <%=strGLSCarrierName%><br />
                                <b>3PL Integration, LLC</b><br />
                                <b>900 Route 134, Ste 2-17
                                    <br />
                                    S. Dennis, MA 02660<br />
                                    Tel: 508.210.2164<br />
                                    <%--Tel Main: 508 444-0332<br />--%>
                                    Fax: 508.210.2158</b>
                            </td>
                            <td>
                                AIR WAYBILL NUMBER:
                                <asp:Label ID="lblAirwayBillNo1" runat="server"></asp:Label><br />
                                *Please record this number for future reference<br />
                                Shipment Date:
                                <asp:Label ID="lblShipFromDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <table width="100%" cellspacing="0" cellpadding="0" bordercolor="#808080" border="1"
                                    style="border-collapse: collapse">
                                    <tr>
                                        <td valign="top" align="center" colspan="2">
                                            <font size="3"><font size="3"><b>Air way bill used for Airfreight Services</b></font></font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="center">
                                            <b>From</b>
                                        </td>
                                        <td valign="top" align="center">
                                            <b>To</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <b>
                                                <asp:Label ID="lblKnownShipper" runat="server"></asp:Label></b><br />
                                            <b>Shipper:</b>
                                            <asp:Label ID="lblShipper" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblShipperAddress" runat="server"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <b>Consignee:</b><asp:Label ID="lblConsignee" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblConsigneeAddress" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="border-bottom: none">
                                        <td valign="top" style="border-bottom: none">
                                            <b>Contact:</b><asp:Label ID="lblFromContact" runat="server"></asp:Label><br />
                                        </td>
                                        <td valign="top" style="border-bottom: none">
                                            <b>Contact:</b><asp:Label ID="lblToContact" runat="server"></asp:Label><br />
                                        </td>
                                    </tr>
                                    <tr style="border-top: none">
                                        <td valign="top" align="right" style="border-top: none">
                                            <b>Tel:</b><asp:Label ID="lblFromTel" runat="server"></asp:Label><br />
                                            <b>Fax:</b><asp:Label ID="lblFromFax" runat="server"></asp:Label>
                                        </td>
                                        <td valign="top" align="right" style="border-top: none">
                                            <b>Tel:</b><asp:Label ID="lblToTel" runat="server"></asp:Label><br />
                                            <b>Fax:</b><asp:Label ID="lblToFax" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="padding-top: 3px; padding-bottom: 3px; border-bottom: none;">
                                            <u>Signed by Shipper</u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<u>Shipper Reference No.</u>
                                            <%=strShipFromRefNumber%>
                                        </td>
                                        <td valign="top" style="border-bottom: none;">
                                            Also Notify:
                                            <%=strShipToNotifyName%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="border-top: none;">
                                        </td>
                                        <td valign="top" align="center" style="border-top: none;">
                                            Tel:<%=strShipToNotifyPhone%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2" style="padding-top: 3px; padding-bottom: 3px; color: red;
                                            background-color: rgb(239, 255, 111);">
                                            <b>SERVICES:
                                                <asp:Label ID="lblSpecialInst" runat="server"></asp:Label>
                                            </b>
                                        </td>
                                        <td valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2" style="padding-top: 3px; padding-bottom: 3px; color: red;
                                            background-color: rgb(239, 255, 111);">
                                            <b>SPECIAL INSTRUCTIONS:
                                                <asp:Label ID="lblstrSpecialInstructions" runat="server" Text=""></asp:Label>
                                            </b>
                                        </td>
                                        <td valign="top">
                                        </td>
                                    </tr>
                                    <%
                                        //'Get all of the service strings based on the service codes from the
                                        //'Dayabase.  Call the GetSpecialServicesText subroutine passing in the
                                        //'appropriate service number.


                                        GetSpecialServicesText(1);
                                        GetSpecialServicesText(2);
                                        GetSpecialServicesText(3);
                                        GetSpecialServicesText(4);
                                        GetSpecialServicesText(5);
                                        GetSpecialServicesText(6);
                                    %>
                                    <tr>
                                        <td valign="top">
                                        </td>
                                        <td valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            <table width="100%">
                                                <tr>
                                                    <td class="HeaderVics" valign="top" align="center">
                                                        <b>CUSTOMER ORDER INFORMATION</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gridShipmentItems" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                                            CellPadding="0" CellSpacing="0" ShowFooter="true" Width="100%" AllowPaging="True"
                                                            PageSize="10" AllowSorting="true" BorderColor="#808080" BorderWidth="1px" Style="border-collapse: collapse"
                                                            OnRowDataBound="gridShipmentItems_RowDataBound" PagerStyle-CssClass="pgr">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="CUSTOMER ORDER NUMBER">
                                                                    <FooterStyle Font-Bold="true" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPurchaseOrderNumber_SI" Text='<%# Eval("PurchaseOrderNumber_SI")%>'
                                                                            runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        GRAND TOTAL</FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="# PKGS">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPackageQuantity_SI" Text='<%# Eval("PackageQuantity_SI")%>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblPackageQuantity_SITot" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="PALLET/SLIP">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitType" Text='<%# Eval("HandlingUnitType")%>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="ADDITIONAL SHIPPER INFO">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPartNumber_SI" Text='<%# Eval("PartNumber_SI")%>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td class="HeaderVics" valign="top" align="center">
                                                        <b>CARRIER INFORMATION</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gridSkidItems" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                                            CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="true" Width="100%"
                                                            AllowPaging="True" PageSize="10" AllowSorting="true" BorderColor="#808080" BorderWidth="1px"
                                                            Style="border-collapse: collapse" OnRowDataBound="gridSkidItems_RowDataBound"
                                                            PagerStyle-CssClass="pgr">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <RowStyle HorizontalAlign="Center" />
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QTY">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblQTY2" Text='<%# Eval("PackageQuantity")%>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblQTY2Tot" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="TYPE">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHandlingUnit" Text='<%# Eval("HandlingUnitType")%>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSkidWeight" Text='<%# Eval("SkidWeight")%>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblSkidWeightTot" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHazmatCode" Text="" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                                    <FooterStyle Font-Bold="true" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHazmatEmergencyPh" Text="" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        GRAND TOTAL</FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="NMFC #">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNMFCCode" Text='<%# Eval("NMFCCode")%>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="CLASS">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClass" Text='<%# Eval("Class")%>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        <ol>
                                                            <li>Length, Width, and Height are in inches Weight is in lbs.</li>
                                                            <li>It is mutually agreed that the goods herein described are accepted in apparent good
                                                                order except as noted for transportation as specified herein subject to governing
                                                                classifications and tariffs in effect as of the date hereof.</li>
                                                        </ol>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table border="1" bordercolor="#808080" cellspacing="0" cellpadding="0" style="border-collapse: collapse">
                                                <tr>
                                                    <td width="45%" style="border-right: none;">
                                                        Declared Value*:<asp:Label ID="lbldblTotalDeclaredValue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border-left: none;">
                                                        (3PL Integration, LLC. liability is limited to $50 USD or $.50 per pound unless
                                                        a higher value is entered.)
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="1" bordercolor="#808080" cellspacing="0" cellpadding="0"
                                                style="border-collapse: collapse">
                                                <tr>
                                                    <td width="60%">
                                                        Billing:<asp:Label ID="lblGLSPaymentMethod" runat="server"></asp:Label>
                                                    </td>
                                                    <td rowspan="3">
                                                        3PL Integration, LLC. 900 Route 134, Ste 2-17, S. Dennis, MA 02660 USA
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Shipper's COD:<asp:Label ID="lblGLSCodFee" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        (check type:)
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        Received in Good Order:
                                                    </td>
                                                    <td>
                                                        Date:
                                                    </td>
                                                    <td>
                                                        Time:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Terminal:
                                                    </td>
                                                    <td colspan="2">
                                                        Shipment Record Number:
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <%if (iOverflow == 1)
                                              {%>
                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td valign="top" colspan="2">
                                                        <br class="classPageBreak">
                                                        <!--Begin Outer Most Table  -->
                                                        <table align="center" border="0" cellpadding="0" cellspacing="0" bordercolor="#800000"
                                                            width="680">
                                                            <!-- Begin Header Row -->
                                                            <tr>
                                                                <td valign="top" width="60%" align="left">
                                                                    <img src="<%=strRelativePath%>images/LogoAirBill.gif" border="0" width="132" height="74">
                                                                </td>
                                                                <td width="40%" valign="top">
                                                                    3PL Integration, LLC
                                                                    <br>
                                                                    900 Route 134, Ste 2-17 &middot; S. Dennis, MA 02660 Tel: 508.210.2164&nbsp;Fax:
                                                                    508.210.2158<br>
                                                                    <a href="http://www.3plintegration.com/">www.3plintegration.com</a>
                                                                </td>
                                                            </tr>
                                                            <!-- End Header Row -->
                                                            <tr>
                                                                <td colspan="2" width="100%" align="center">
                                                                    <!--Begin Outer Table 1  -->
                                                                    <table align="center" border="0" bordercolor="#0000FF" cellpadding="1" cellspacing="0"
                                                                        width="100%">
                                                                        <tr>
                                                                            <td width="100%" height="15">
                                                                                <!--Begin Container Table 1 - Database Content -->
                                                                                <div align="center">
                                                                                    <center>
                                                                                        <table border="1" width="100%" bordercolor="#808080" cellspacing="0" cellpadding="0"
                                                                                            style="border-collapse: collapse">
                                                                                            <tr>
                                                                                                <td width="100%" valign="top" align="center" colspan="2">
                                                                                                    <table border="0" width="100%" cellspacing="0" cellpadding="0">
                                                                                                        <tr>
                                                                                                            <td width="30%">
                                                                                                                Date:
                                                                                                                <%=strShipFromDate%>
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <font size="3"><b>SUPPLEMENT TO THE BILL OF LADING</b></font>
                                                                                                            </td>
                                                                                                            <td widht="20%">
                                                                                                                <b>PAGE 2</b>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td width="100%" valign="top" align="right" colspan="2">
                                                                                                    <b>Bill of Lading Number:
                                                                                                        <%=strGLSTrackingNumber%></b>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td width="100%" valign="top">
                                                                                                    <table width="100%">
                                                                                                        <tr>
                                                                                                            <td class="HeaderVics" valign="top" align="center">
                                                                                                                <b>CUSTOMER ORDER INFORMATION</b>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:GridView ID="gridShipmentItems1" runat="server" AutoGenerateColumns="false"
                                                                                                                    CssClass="mGrid dataList" CellPadding="0" CellSpacing="0" ShowFooter="true" Width="100%"
                                                                                                                    AllowPaging="True" PageSize="10" AllowSorting="true" BorderColor="#808080" BorderWidth="1px"
                                                                                                                    Style="border-collapse: collapse" OnRowDataBound="gridShipmentItems1_RowDataBound"
                                                                                                                    PagerStyle-CssClass="pgr">
                                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                                    <Columns>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="CUSTOMER ORDER NUMBER">
                                                                                                                            <FooterStyle Font-Bold="true" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblPurchaseOrderNumber_SI" Text='<%# Eval("PurchaseOrderNumber_SI")%>'
                                                                                                                                    runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                            <FooterTemplate>
                                                                                                                                PAGE SUBTOTAL</FooterTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="# PKGS">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblPackageQuantity_SI" Text='<%# Eval("PackageQuantity_SI")%>' runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                            <FooterTemplate>
                                                                                                                                <asp:Label ID="lblPackageQuantity_SITot" runat="server"></asp:Label>
                                                                                                                            </FooterTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="PALLET/SLIP">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblUnitType" Text='<%# Eval("HandlingUnitType")%>' runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="ADDITIONAL SHIPPER INFO">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblPartNumber_SI" Text='<%# Eval("PartNumber_SI")%>' runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                    </Columns>
                                                                                                                </asp:GridView>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                    <table width="100%">
                                                                                                        <tr>
                                                                                                            <td class="HeaderVics" valign="top" align="center">
                                                                                                                <b>CARRIER INFORMATION</b>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:GridView ID="gridSkidItems1" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                                                                                                    CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="true" Width="100%"
                                                                                                                    AllowPaging="True" PageSize="10" AllowSorting="true" BorderColor="#808080" BorderWidth="1px"
                                                                                                                    Style="border-collapse: collapse" OnRowDataBound="gridSkidItems1_RowDataBound"
                                                                                                                    PagerStyle-CssClass="pgr">
                                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                                    <RowStyle HorizontalAlign="Center" />
                                                                                                                    <FooterStyle HorizontalAlign="Center" />
                                                                                                                    <Columns>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QTY">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblQTY2" Text='<%# Eval("PackageQuantity")%>' runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                            <FooterTemplate>
                                                                                                                                <asp:Label ID="lblQTY2Tot" runat="server"></asp:Label>
                                                                                                                            </FooterTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="TYPE">
                                                                                                                            <ItemTemplate>
                                                                                                                                <%--<asp:Label ID="lblType1" Text='<%# Eval("PackageType")%>' runat="server"></asp:Label>--%>
                                                                                                                                <asp:Label ID="lblHandlingUnit" Text='<%# Eval("HandlingUnitType")%>' runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblSkidWeight" Text='<%# Eval("SkidWeight")%>' runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                            <FooterTemplate>
                                                                                                                                <asp:Label ID="lblSkidWeightTot" runat="server"></asp:Label>
                                                                                                                            </FooterTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblHazmatCode" Text="" runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                                                                                            <FooterStyle Font-Bold="true" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblHazmatEmergencyPh" Text="" runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                            <FooterTemplate>
                                                                                                                                PAGE SUBTOTAL</FooterTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="NMFC #">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblNMFCCode" Text='<%# Eval("NMFCCode")%>' runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="CLASS">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblClass" Text='<%# Eval("Class")%>' runat="server"></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                    </Columns>
                                                                                                                </asp:GridView>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <!--End Container Table 1 -->
                                                                                    </center>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100%" height="15">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <!--End Outer Table 1  -->
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%}%>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <%if (intKnownShipper == 0)
                                              {%>
                                            <br class="classPageBreak">
                                            <!--Begin SSE Table  -->
                                            <table class="SSE" align="center" border="0" bordercolor="#0000FF" cellpadding="2"
                                                cellspacing="0" width="680">
                                                <tr>
                                                    <td class="SSE" valign="top" width="100%">
                                                        <p class="SSE">
                                                            3PL Integration, LLC<br>
                                                            900 Route 134, Ste 2-17<br>
                                                            S. Dennis MA 02660<br>
                                                            Tel: 508.210.2164 &nbsp; Fax: 508.210.2158</p>
                                                        <p class="SSE" align="center">
                                                            <b>REQUIRED SECURITY INFORMATION</b></p>
                                                        <p class="SSE" align="center">
                                                            Air Waybill Number: <b>
                                                                <%=strGLSTrackingNumber%></b>
                                                            <br>
                                                            <br>
                                                            <u><b>Shipper’s Security Endorsement (SSE)</b></u><br>
                                                            (To be completed by the shipper)</p>
                                                        <div align="center">
                                                            <table class="SSE" border="0" width="100%" id="table4" cellpadding="0" cellspacing="0"
                                                                style="border-collapse: collapse">
                                                                <tr>
                                                                    <td class="SSE">
                                                                        &quot;I certify that this cargo does not contain any unauthorized person and any
                                                                        unauthorized explosive, incendiary, and other destructive substance or item. I am
                                                                        aware that this endorsement and original signature and other shipping documents
                                                                        will be retained on file for a minimum of 30 calendar days&quot;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br>
                                                            <table border="1" cellspacing="1" cellpadding="4" width="596" id="table1" style="border-collapse: collapse">
                                                                <tr>
                                                                    <td class="SSE" width="298" valign="top">
                                                                        Shipper’s name:
                                                                    </td>
                                                                    <td width="298" align="center" valign="top">
                                                                        Date:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="298" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="SSE" width="298" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SSE" width="298" valign="top">
                                                                        Signature of shipper or authorized representative:
                                                                    </td>
                                                                    <td class="SSE" width="298" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SSE" width="298" valign="top">
                                                                        Print/type name of individual whose signature appears as shipper or authorized representative:
                                                                    </td>
                                                                    <td class="SSE" width="298" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <p class="SSE" align="center">
                                                            <b><u>Shipper ID Information<br>
                                                            </u></b>(To be completed by pickup carrier)</p>
                                                        <div align="center">
                                                            <table border="1" cellspacing="1" cellpadding="4" id="table2" style="border-collapse: collapse">
                                                                <tr>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        Type of ID reviewed:
                                                                    </td>
                                                                    <td class="SSE" width="295" colspan="2" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        Matching photo ID? Indicate:
                                                                    </td>
                                                                    <td class="SSE" align="center" width="148" valign="top">
                                                                        Yes
                                                                    </td>
                                                                    <td class="SSE" align="center" width="148" valign="top">
                                                                        No
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        Number appearing on ID:
                                                                    </td>
                                                                    <td class="SSE" align="center" width="295" colspan="2" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <p class="SSE" align="center">
                                                            <b><u>Screening Information<br>
                                                            </u></b>(To be completed by pickup carrier)</p>
                                                        <div align="center">
                                                            <table border="1" cellspacing="1" cellpadding="4" id="table3" style="border-collapse: collapse">
                                                                <tr>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        Number of pieces screened:
                                                                    </td>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        Type of screening method applied:
                                                                    </td>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        Name of screener:
                                                                    </td>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        Date of screening:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="SSE" width="295" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <br class="classPageBreak">
                                                        <div align="center">
                                                            <table border="0" width="596" id="table5" style="border-collapse: collapse">
                                                                <tr>
                                                                    <td class="SSE" width="100%">
                                                                        <p>
                                                                            &nbsp;</p>
                                                                        <p align="center">
                                                                            <b><u>This non-negotiable Air Waybill is subject to the following terms and conditions</u></b>
                                                                            <ol class="SSE">
                                                                        </p>
                                                                        <li>If the carriage hereunder involves an ultimate destination or stop in a foreign
                                                                            country the Warsaw Convention may be applicable, and this convention governs and
                                                                            in some cases limits the liability of the forwarder for loss and damage to cargo
                                                                            for the purposes of the Warsaw Convention. The agreed stopping places (other than
                                                                            the place of destination) are those places shown in airline time tables as scheduled
                                                                            stopping places for the route. Further, goods classified as hazardous materials
                                                                            are accepted subject to forwarders ability to arrange carriage on a direct carrier.
                                                                            Liability limited to .50 USD per pound unless otherwise stated.</li>
                                                                        <li>In tendering the shipment described herein for carriage, Shipper agrees to these
                                                                            conditions of contract, which no agent or employee of the parties may alter, and
                                                                            that the Air Waybill is NON-NEGOTIABLE and has been prepared by him or on his behalf
                                                                            by the carrier.</li>
                                                                        <li>It is mutually agreed that the shipment described herein is accepted on the date
                                                                            hereof in apparent good order (except as noted) for carriage as specified herein,
                                                                            and is subject to the governing rates, rules and classifications in effect as of
                                                                            the date this contract of carriage is entered into and which are stated in the terms
                                                                            and conditions on this Airbill. The Airbill and the rates, rules and classification
                                                                            shall inure to the benefit of and be binding upon the shipper and consignee and
                                                                            the carriers by whom transportation is undertaken between the origin and destination
                                                                            and also shall apply to, inure to the benefit of and be binding on any person, firm
                                                                            or corporation which performs pickup, delivery or other ground service in connection
                                                                            with the shipment.</li>
                                                                        <li>In tendering the shipment for carriage, The shipper warrants that the shipment is
                                                                            accurately described on the Airbill, is properly marked on each piece, is in good
                                                                            order (except as noted), is properly prepared and packed as to insure safe transportation
                                                                            with ordinary handling and is acceptable for transportation according to terms and
                                                                            conditions on this Airbill and rules and classifications and government laws and
                                                                            regulations.</li>
                                                                        <li>In tendering the shipment for carriage, Shipper understands and agrees that certain
                                                                            shipments, due to their inherent nature, size or special handling requirements,
                                                                            require advance arrangements with the air carrier.</li>
                                                                        <li>Shipper must enter the amount of any shipper's C.O.D. on the Air Waybill which shall
                                                                            be collected subject to the fee and rules of the delivering carrier.</li>
                                                                        <li>Delivery shall be made by the carrier to the Consignee at the destination point,
                                                                            if delivery service is available, at applicable charges unless Shipper otherwise
                                                                            instructs on the Air Waybill block labeled &quot;Special Instructions&quot;.</li>
                                                                        <li>Except otherwise agreed herein, shipper and consignee shall be liable, jointly or
                                                                            severally, to pay carrier for all unpaid charges related to their shipment and to
                                                                            indemnify carrier for all claims, fines, penalties, damages, costs and other sums
                                                                            which are incurred, suffered or disbursed by reason of violation of applicable rules
                                                                            or any default of shipper or other parties with respect to a shipment. Carrier shall
                                                                            have a lien on the shipment for all such sums due and in the event of nonpayment
                                                                            shall hold the shipment subject to storage charges and after due notice to Shipper
                                                                            and Consignee will dispose of the shipment at public or private sale paying itself
                                                                            for all charges out of the proceeds.</li>
                                                                        </ol>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SSE">
                                                                        <b><u>SHIPPER/PICKUP CARRIER </u>:</b>&nbsp; PLEASE FILL IN THE APPROPRIATE SECTIONS
                                                                        ABOVE, SIGN, AND FAX TO 3PLI AT 508.210.2158 AS ACKNOWLEDGEMENT AND FOR 3PLI RECORD
                                                                        RETENTION PER INDIRECT AIR CARRIER STANDARD SECURITY PROGRAM (IACSSP) REQUIREMENT.
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!--End SSE Table  -->
                                            <%}%>
                                            <%else
                                                {%>
                                            <br class="classPageBreak">
                                            <div align="center">
                                                <table border="0" width="596" id="table6" style="border-collapse: collapse">
                                                    <tr>
                                                        <td class="SSE" width="100%">
                                                            <p align="left" class="SSE">
                                                                3PL Integration, LLC<br>
                                                                900 Route 134, Ste 2-17<br>
                                                                S. Dennis MA 02660<br>
                                                                Tel: 508.210.2164 &nbsp; Fax: 508.210.2158</p>
                                                            <p class="SSE" align="center">
                                                                Air Waybill Number: <b>
                                                                    <%=strGLSTrackingNumber%></b></p>
                                                            <p align="center">
                                                                <b><u>This non-negotiable Air Waybill is subject to the following terms and conditions</u></b>
                                                                <ol class="SSE">
                                                            </p>
                                                            <li>If the carriage hereunder involves an ultimate destination or stop in a foreign
                                                                country the Warsaw Convention may be applicable, and this convention governs and
                                                                in some cases limits the liability of the forwarder for loss and damage to cargo
                                                                for the purposes of the Warsaw Convention. The agreed stopping places (other than
                                                                the place of destination) are those places shown in airline time tables as scheduled
                                                                stopping places for the route. Further, goods classified as hazardous materials
                                                                are accepted subject to forwarders ability to arrange carriage on a direct carrier.
                                                                Liability limited to .50 USD per pound unless otherwise stated.</li>
                                                            <li>In tendering the shipment described herein for carriage, Shipper agrees to these
                                                                conditions of contract, which no agent or employee of the parties may alter, and
                                                                that the Air Waybill is NON-NEGOTIABLE and has been prepared by him or on his behalf
                                                                by the carrier.</li>
                                                            <li>It is mutually agreed that the shipment described herein is accepted on the date
                                                                hereof in apparent good order (except as noted) for carriage as specified herein,
                                                                and is subject to the governing rates, rules and classifications in effect as of
                                                                the date this contract of carriage is entered into and which are stated in the terms
                                                                and conditions on this Airbill. The Airbill and the rates, rules and classification
                                                                shall inure to the benefit of and be binding upon the shipper and consignee and
                                                                the carriers by whom transportation is undertaken between the origin and destination
                                                                and also shall apply to, inure to the benefit of and be binding on any person, firm
                                                                or corporation which performs pickup, delivery or other ground service in connection
                                                                with the shipment.</li>
                                                            <li>In tendering the shipment for carriage, The shipper warrants that the shipment is
                                                                accurately described on the Airbill, is properly marked on each piece, is in good
                                                                order (except as noted), is properly prepared and packed as to insure safe transportation
                                                                with ordinary handling and is acceptable for transportation according to terms and
                                                                conditions on this Airbill and rules and classifications and government laws and
                                                                regulations.</li>
                                                            <li>In tendering the shipment for carriage, Shipper understands and agrees that certain
                                                                shipments, due to their inherent nature, size or special handling requirements,
                                                                require advance arrangements with the air carrier.</li>
                                                            <li>Shipper must enter the amount of any shipper's C.O.D. on the Air Waybill which shall
                                                                be collected subject to the fee and rules of the delivering carrier.</li>
                                                            <li>Delivery shall be made by the carrier to the Consignee at the destination point,
                                                                if delivery service is available, at applicable charges unless Shipper otherwise
                                                                instructs on the Air Waybill block labeled &quot;Special Instructions&quot;.</li>
                                                            <li>Except otherwise agreed herein, shipper and consignee shall be liable, jointly or
                                                                severally, to pay carrier for all unpaid charges related to their shipment and to
                                                                indemnify carrier for all claims, fines, penalties, damages, costs and other sums
                                                                which are incurred, suffered or disbursed by reason of violation of applicable rules
                                                                or any default of shipper or other parties with respect to a shipment. Carrier shall
                                                                have a lien on the shipment for all such sums due and in the event of nonpayment
                                                                shall hold the shipment subject to storage charges and after due notice to Shipper
                                                                and Consignee will dispose of the shipment at public or private sale paying itself
                                                                for all charges out of the proceeds.</li>
                                                            </ol>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%}%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
