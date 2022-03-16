<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillOfLading_Vics.aspx.cs"
    Inherits="ISCS.Admin.BillOfLading_Vics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bill Of Lading</title>
    <style type="text/css">
    body{font-family:Verdana, Arial, Helvetica, sans-serif; font-size:10px;}
    .classPageBreak	{
		PAGE-BREAK-AFTER: always
	}
    </style>
</head>
<body>
   <form id="form1" runat="server">
    <div>
        <table width="700" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td width="100%">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <!-- Begin Header Row -->
                        <%--<tr>
                            <td valign="top" width="60%" align="left">
                                <b>Impact Supply Chain Solutions - Online Shipment Tracking</b>
                            </td>
                            <td width="40%" valign="top" align="right">
                               
                            </td>
                        </tr>--%>
                        <tr>
                            <td valign="top" width="60%" align="left">
                               <%-- <img src="images/logo.jpg" border="0" width="202" height="74">--%>
                                <img src="images/logo.jpg" border="0" width="265" height="73px" >
                            </td>
                            <td width="40%" valign="top">
                                3PL Integration, LLC<br>
                                900 Route 134, Ste 2-17 <br> 
                                S. Dennis, MA 02660 <br>
                                <%--Toll Free: 888.884.0577&nbsp;<br>--%>Tel: 508.210.2164<br>Fax: 508.210.2158<br>
                                <a href="http://www.3plintegration.com">www.3plintegration.com</a><br>
                            </td>
                        </tr>
                        <!-- End Header Row -->
                        <tr>
                            <td colspan="2" width="100%" align="center">
                                <!--Begin Outer Table 1  -->
                                <table align="center" border="0" bordercolor="#0000FF" cellpadding="0" cellspacing="0"
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
                                                                        <td align="left">
                                                                            <span>Date:</span>
                                                                            <asp:Label ID="lblstrShipFromDate" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <font size="3"><font size="3"><b>Domestic Bill of  Lading used for Ground Service</b></font></font>
                                                                        </td>
                                                                        <td widht="20%" align="right">
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="50%" valign="top">
                                                                <!--Begin Inner Table 1 -->
                                                                <div align="center">
                                                                    <center>
                                                                        <table border="0" width="100%" cellspacing="0" cellpadding="1">
                                                                            <tr>
                                                                                <td class="HeaderVics" valign="top" align="center">
                                                                                    <b>SHIP FROM</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" align="left">
                                                                                    <span><b>Name:</b></span><asp:Label ID="lblstrShipFromCompany" runat="server" Text=""></asp:Label><br>
                                                                                    <span><b>Address:</b></span>&nbsp;<asp:Label ID="lblstrShipFromAddress" runat="server" Text=""></asp:Label><br>
                                                                                    <span><b>City/State/Zip:</b></span>&nbsp;<asp:Label ID="lblstrShipFromCity" runat="server" Text=""></asp:Label>,
                                                                                    <asp:Label ID="lblstrShipFromState" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="lblstrShipFromPostalCode" runat="server" Text=""></asp:Label><br>
                                                                                    <span><b>SID#:</b></span>&nbsp;<asp:Label ID="lblstrShipFromRefNumber" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" align="left">
                                                                                    <span><b>Contact:</b></span>&nbsp;<asp:Label ID="lblstrShipFromContact" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="50%" valign="top" align="left">
                                                                                    <span><b>Tel:</b></span>&nbsp;<asp:Label ID="lblstrShipFromPhone" runat="server" Text=""></asp:Label>&nbsp;<span><b>Fax:</b></span>&nbsp;<asp:Label ID="lblstrShipFromFax" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </center>
                                                                </div>
                                                                <!--End Inner Table 1 -->
                                                            </td>
                                                            <td width="50%" valign="top" rowspan="3">
                                                                <!--Begin Inner Table 2 -->
                                                                <table border="0" width="100%" cellspacing="0" cellpadding="2">
                                                                    <tr>
                                                                        <td class="BorderB" align="left">
                                                                            <b><span>Bill of Lading Number:</span></b> <b>
                                                                                <asp:Label ID="lblstrGLSTrackingNumber" runat="server" Text=""></asp:Label></b><br>
                                                                            <p align="center">
                                                                                <font color="#C0C0C0" size="3">Bar Code Space</font></p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="BorderB" align="left">
                                                                            <span><b>CARRIER NAME:</b></span>&nbsp;<asp:Label ID="lblstrGLSCarrierName" runat="server" Text=""></asp:Label><br>
                                                                            Trailer number:<br>
                                                                            Seal number(s):
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="BorderB" align="left">
                                                                            <b>SCAC:</b><br>
                                                                            <b>Pro number:</b><br>
                                                                            <p align="center">
                                                                                <font color="#C0C0C0" size="3">Bar Code Space</font></p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="BorderB">
                                                                            <!--Begin Inner Table 2a -->
                                                                            <table border="0" width="100%" id="freightcharge" cellspacing="0" cellpadding="2">
                                                                                <tr>
                                                                                    <td class="BorderR" valign="top" align="left">
                                                                                        <span><b>Freight Charge Terms:</b></span><br>
                                                                                        <asp:Label ID="lblstrGLSPaymentMethod" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <!--End Inner Table 2a -->
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <!--Begin Inner Table 2b -->
                                                                            <table border="0" width="100%" cellspacing="0" cellpadding="2">
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <input type="checkbox" name="C1" value="ON"><br>
                                                                                        Check Box
                                                                                    </td>
                                                                                    <td>
                                                                                        Master Bill of Lading: with attached underlying Bills of Lading
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <!--End Inner Table 2b -->
                                                                            <p>
                                                                                &nbsp;</p>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <!--End Inner Table 2 -->
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="60%" valign="top">
                                                                <!--Begin Inner Table 3 -->
                                                                <table border="0" width="100%" cellspacing="0" cellpadding="2" id="table1">
                                                                    <tr>
                                                                        <td class="HeaderVics" valign="top" align="center">
                                                                            <b>SHIP TO</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="left">
                                                                            <span><b>Name:</b></span>&nbsp;<asp:Label ID="lblstrShiptoCompany" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;Location#:<br>
                                                                            <span><b>Address:</b></span>&nbsp;<asp:Label ID="lblstrShiptoAddress" runat="server" Text=""></asp:Label><br>
                                                                            <span><b>City/State/Zip:</b></span>&nbsp;<asp:Label ID="lblstrShiptoCity" runat="server" Text=""></asp:Label>,<asp:Label ID="lblstrShiptoState" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="lblstrShiptoPostalCode" runat="server" Text=""></asp:Label><br>
                                                                            <span><b>CID#:</b></span>&nbsp;<asp:Label ID="lblstrShipToConsigneeRefNumber" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="left">
                                                                            <span><b>Contact:</b></span>&nbsp;<asp:Label ID="lblstrShipToContact" runat="server" Text=""></asp:Label>&nbsp; <span><b>Tel:</b></span>&nbsp;<asp:Label ID="lblstrShipToPhone" runat="server" Text=""></asp:Label>&nbsp;<span><b>Fax:</b></span>&nbsp;<asp:Label ID="lblstrShipToFax" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="50%" valign="top" align="left">
                                                                            <span><b>Also Notify:</b></span>&nbsp;<asp:Label ID="lblstrShipToNotifyName" runat="server" Text=""></asp:Label>&nbsp;<span><b>Tel:</b></span>&nbsp;<asp:Label ID="lblstrShipToNotifyPhone" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <!--End Inner Table 3 -->
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="60%" valign="top">
                                                                <!--Begin Inner Table 4 -->
                                                                <table border="0" width="100%" cellspacing="0" cellpadding="2">
                                                                    <tr>
                                                                        <td class="HeaderVics" valign="top" align="center">
                                                                            <b>THIRD PARTY FREIGHT CHARGES BILL TO:</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="left">
                                                                        <div id="divthirdpartyfreight" runat="server" style="display:block;">
                                                                            <span><b>Name:</b></span>
                                                                            <asp:Label ID="lblstrGLSBillCompany" runat="server" Text=""></asp:Label><br>
                                                                            <span><b>Address:</b></span>
                                                                            <asp:Label ID="lblstrGLSBillAddress" runat="server" Text=""></asp:Label><br>
                                                                            <span><b>City/State/Zip:</b></span>
                                                                            <asp:Label ID="lblstrGLSBillCity" runat="server" Text=""></asp:Label>,
                                                                            <asp:Label ID="lblstrGLSBillState" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="lblstrGLSBillPostalCode" runat="server" Text=""></asp:Label>
                                                                        </div>
                                                                          <div id="divCollectNumber" runat="server" style="display:none;">
                                                                          <b>COLLECT TO CONSIGNEE’S ACCOUNT NUMBER</b>
                                                                         </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <!--End Inner Table 4 -->
                                                            </td>
                                                        </tr>
                                    </tr>
                                    <td colspan="2" valign="top" align="left" style="padding-top:5px; padding-bottom:5px; color: red; background-color: rgb(239, 255, 111);" >
                                        <b>SPECIAL INSTRUCTIONS:
                                         <asp:Label ID="lblstrTransModeName" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;<asp:Label ID="lblstrTransModeService1" runat="server" Text=""></asp:Label></b>
                                        <br>
                                        
                                        <b><asp:Label ID="lblstrSpecialInstructions" runat="server" Text=""></asp:Label></b>
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
						    <td valign="top" colspan="2">
							    <table width="100%">
							        <tr>
							            <td class="HeaderVics" valign="top" align="center">
							                <b>CUSTOMER ORDER INFORMATION</b>
							            </td>
							        </tr>
							        <tr>
							            <td>
							               
							                <asp:GridView ID="gridShipmentItems" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList" CellPadding="0" CellSpacing="0"
                                            Width="100%" AllowPaging="True" PageSize="10" AllowSorting="true" BorderColor="#808080" BorderWidth="1px" style="border-collapse: collapse" onrowdatabound="gridShipmentItems_RowDataBound"                                                                                       ShowFooter="true"
                                             PagerStyle-CssClass="pgr">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="CUSTOMER ORDER NUMBER">                                                    <FooterStyle Font-Bold="true" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPurchaseOrderNumber_SI" Text='<%# Eval("PurchaseOrderNumber_SI")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>GRAND TOTAL</FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="# PKGS">                                                    
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPackageQuantity_SI" Text='<%# Eval("PackageQuantity_SI")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    <asp:Label ID="lblPackageQuantity_SITot" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="WEIGHT">                                                    
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWeight_SI" Text='<%# Eval("Weight_SI")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    <asp:Label ID="lblWeight_SITot" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>--%>
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
							                
							                <asp:GridView ID="gridSkidItems" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList" CellPadding="0" CellSpacing="0" ShowHeader="false" ShowFooter="true"
                                            Width="100%" AllowPaging="True" PageSize="10" AllowSorting="true" BorderColor="#808080" BorderWidth="1px" style="border-collapse: collapse"
                                            onrowdatabound="gridSkidItems_RowDataBound" 
                                            PagerStyle-CssClass="pgr">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <RowStyle HorizontalAlign="Center" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <Columns>
                                                <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QTY">                                                                                              <ItemTemplate>
                                                        <asp:Label ID="lblQTY1" Text="1" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    <asp:Label ID="lblQTY1Tot" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="TYPE">                                                    
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHandlingUnit" Text='<%# Eval("HandlingUnitType")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
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
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="">                                                    <FooterStyle Font-Bold="true" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHazmatEmergencyPh" Text="" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>GRAND TOTAL</FooterTemplate>
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
                        <tr>
                            <td width="50%" align="left">
                                Where the rate is dependent on value, shippers are required to state specifically
                                in writing the agreed or declared value of the property as follows:&nbsp;"The agreed
                                or declared value of the property is specifically stated by the shipper to be not
                                exceeding</b>&nbsp;<asp:Label ID="lbldblTotalDeclaredValue" runat="server" Text=""></asp:Label><%--<%=FormatCurrency(,2)%>--%>
                                per _________________"
                            </td>
                            <td width="50%" valign="top">
                                <!--Begin Inner Table 5 -->
                                <table border="0" width="100%" cellspacing="1" cellpadding="0">
                                    <tr>
                                        <td align="left">
                                            <span><b>COD Amount:</b></span>
                                            <asp:Label ID="lblstrDisplayGLSCodFee" runat="server" Text=""></asp:Label>
                                            <span>USD</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <b>Fee Terms: Collect:</b>
                                            <input type="checkbox" name="C2" value="ON">
                                            <b>Prepaid: </b>
                                            <input type="checkbox" name="C3" value="ON"><br>
                                            <b>Customer check acceptable:</b>
                                            <input type="checkbox" name="C4" value="ON">
                                        </td>
                                    </tr>
                                </table>
                                <!--End Inner Table 5 -->
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" colspan="2" align="left">
                                <b>NOTE Liability Limitation for loss or damage in this shipment may be applicable.
                                    See 49 U.S.C. ? 14706(c)(1)(A) and (B).</b>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" colspan="2">
                                <!--Begin Inner Table 6 -->
                                <center>
                                    <table border="1" width="100%" cellpadding="2" style="border-collapse: collapse">
                                        <tr>
                                            <td valign="top" align="left">
                                                RECEIVED, subject to individually determined rates or contracts that have been agreed
                                                upon in writing between the carrier and shipper, if applicable, otherwise to the
                                                rates, classifications and rules that have been established by the carrier and are
                                                available to the shipper, on request, and to all applicable state and federal regulations.
                                            </td>
                                            <td valign="top" align="left">
                                                The carrier shall not make delivery of this shipment without payment of freight
                                                and all other lawful charges._____________________________ <b>Shipper Signature</b>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <!--End Inner Table 6 -->
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" colspan="2">
                                <!--Begin Inner Table 7 -->
                                <div align="center">
                                    <center>
                                        <table border="1" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse">
                                            <tr>
                                                <td width="207" valign="top" align="left">
                                                    <b>SHIPPER SIGNATURE / DATE</b><br>
                                                    This is to certify that the above named materials are properly classified, described,
                                                    packaged, marked and labeled, and are in proper condition for transportation according
                                                    to the applicable regulations of the DOT._____________________________
                                                </td>
                                                <td width="98" valign="top" align="left">
                                                    <u><b>Trailer Loaded:</b></u><br>
                                                    <input type="checkbox" name="C1" value="ON">
                                                    By Shipper<br>
                                                    <input type="checkbox" name="C2" value="ON">
                                                    By Driver
                                                </td>
                                                <td width="171" valign="top" align="left">
                                                    <u><b>Freight Counted:</b></u><br>
                                                    <input type="checkbox" name="C3" value="ON">
                                                    By Shipper<br>
                                                    <input type="checkbox" name="C4" value="ON">
                                                    By Driver/pallets said to contain<br>
                                                    <input type="checkbox" name="C5" value="ON">
                                                    By Driver/Pieces
                                                </td>
                                                <td width="256" valign="top" align="left">
                                                    <b>CARRIER SIGNATURE / PICKUP DATE</b><br>
                                                    Carrier acknowledges receipt of packages and required placards.&nbsp; Carrier certifies
                                                    emergency response information was made available and/or carrier has the DOT emergency
                                                    response guidebook or equivalent documentation in the vehicle._____________________________<br>
                                                    <u><i>Property described above is received in good order, except as noted.</i></u>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                <!--End Inner Table 7 -->
                            </td>
                        </tr>
                        
                    </table>
                    <!--End Container Table 1 -->
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
                                                        3PL Integration, LLC<br>
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
                                                        <asp:GridView ID="gridShipmentItems1" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                                            CellPadding="0" CellSpacing="0" ShowFooter="true" Width="100%" AllowPaging="false"
                                                             AllowSorting="true" BorderColor="#808080" BorderWidth="1px" Style="border-collapse: collapse"
                                                            OnRowDataBound="gridShipmentItems1_RowDataBound" PagerStyle-CssClass="pgr">
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
                                                                <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="WEIGHT">                                                    
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWeight_SI" Text='<%# Eval("Weight_SI")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    <asp:Label ID="lblWeight_SITot" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>--%>
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
                                                            AllowPaging="false"  AllowSorting="true" BorderColor="#808080" BorderWidth="1px"
                                                            Style="border-collapse: collapse" OnRowDataBound="gridSkidItems1_RowDataBound"
                                                            PagerStyle-CssClass="pgr">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <RowStyle HorizontalAlign="Center" />
                                                            <FooterStyle HorizontalAlign="Center" />
                                                            <Columns>
                                                                <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QTY">                                                                                              <ItemTemplate>
                                                        <asp:Label ID="lblQTY1" Text="1" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    <asp:Label ID="lblQTY1Tot" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="TYPE">                                                    
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHandlingUnit" Text='<%# Eval("HandlingUnitType")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
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
        </center>
    </div>
    </td> </tr>
    <tr>
        <td width="100%" height="15">
        </td>
    </tr>
    </table>
    <!--End Outer Table 1  -->
    </td> </tr> </table> </td> </tr> </table> </div>
    </form>
</body>
</html>
