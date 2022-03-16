<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SED-SLI.aspx.cs" Inherits="ISCS.Admin.SED_SLI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SED-SLI</title>
    <style type="text/css">
        body
        {
            font-size: 11.0px;
            color: #000000;
            font-family: Verdana, Tahoma, Arial, Helvetica;
        }
        table tr td
        {
            text-align: left;
            vertical-align: top;
            font-family: Verdana,Tahoma,Arial,Helvetica;
            font-size: 11px;
            padding: none;
            margin: none;
        }
        P
        {
            margin: 0px;
        }
        P.small
        {
            font-size: 9.0px;
            color: #000000;
            font-family: Verdana, Tahoma, Arial, Helvetica;
        }
        b.small
        {
            font-size: 9.0px;
            color: #000000;
            font-family: Verdana, Tahoma, Arial, Helvetica;
        }
        b.medium
        {
            font-size: 10.0px;
            color: #000000;
            font-family: Verdana, Tahoma, Arial, Helvetica;
        }
        TD.medium
        {
            font-size: 10.0px;
            color: #000000;
            font-family: Verdana, Tahoma, Arial, Helvetica;
        }
        P.medium
        {
            font-size: 10.0px;
            color: #000000;
            font-family: Verdana, Tahoma, Arial, Helvetica;
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
<body bgcolor="#ffffff" marginwidth="0" marginheight="0" bottommargin="0" rightmargin="0"
    leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <div align="center">
        <center>
            <table border="0" cellspacing="0" cellpadding="2" width="690" bordercolor="#111111"
                style="border-collapse: collapse">
                <tr>
                    <td colspan="4" align="center" valign="top">
                        <p class="small">
                            <b class="small">U.S. DEPARTMENT OF COMMERCE </b>- U.S. CENSUS BUREAU - Economics
                            and Administration - BUREAU OF EXPORT ADMINISTRATION
                        </p>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" valign="top">
                        <p class="small">
                            FORM <b class="small">7525-V </b>(7-25-2000)&nbsp;<b class="small"> SHIPPER'S EXPORT
                                DECLARATION&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>&nbsp;OMB
                            No. 0607-0152
                        </p>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <div align="center">
        <center>
            <table border="1" cellspacing="0" cellpadding="2" width="690" bordercolor="#111111"
                style="border-collapse: collapse">
                <tr>
                    <td width="50%" colspan="2" valign="top">
                        <p class="medium">
                            <b>1a. U.S. PRINCIPLE PARTY IN INTEREST (USPPI</b>)<br>
                            <%=strShipFromCompany%><br>
                            <%=strShipFromAddress%><br>
                            <%=strShipFromCity%>,
                            <%=strShipFromState%>&nbsp;<%=strShipFromPostalCode%>&nbsp;<%=strShipFromCountry%><br>
                            <b>Contact:</b>&nbsp;<%=strShipFromContact%><br>
                            <b>Tel:</b>&nbsp;<%=strShipFromPhone%>
                        </p>
                    </td>
                    <td width="50%" colspan="2" valign="top">
                        <p align="center">
                            &nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td width="50%" colspan="2" valign="top">
                        <p class="medium">
                            Pickup Location Contact, Phone number</p>
                    </td>
                    <td valign="top">
                        <p class="medium">
                            <b>2. DATE OF EXPORT<br>
                            </b>
                            <%=strShipFromDate%></p>
                    </td>
                    <td valign="top">
                        <p class="medium">
                            <b>3. TRANSPORT REF NO.</b></p>
                    </td>
                </tr>
                <tr>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>b. USPPI EIN OR ID NO.<br>
                            </b>
                            <%=strExportEIN%></p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>c. PARTY TO&nbsp;TRANSACTION<br>
                            </b>
                            <%=strExportPartyTrans%></p>
                    </td>
                    <td colspan="2" rowspan="2" valign="top">
                        <p class="medium">
                            &nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td width="50%" colspan="2" valign="top">
                        <p class="medium">
                            <b>4a. ULTIMATE CONSIGNEE</b><br>
                            <%=strShiptoCompany%><br>
                            <%=strShiptoAddress%><br>
                            <%=strShiptoCity%>,
                            <%=strShiptoState%>&nbsp;<%=strShiptoPostalCode%>&nbsp;<%=strShiptoCountry%><br>
                            <b>Contact:</b>&nbsp;<%=strShipToContact%><br>
                            <b>Tel:</b>&nbsp;<%=strShipToPhone%>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td width="50%" colspan="3" valign="top">
                        <p class="medium">
                            <b>4b. INTERMEDIATE CONSIGNEE<br>
                            </b>
                            <%=strExportIntermediateConsignee%>&nbsp;&nbsp;<b>Contact: </b>
                            <%=strExportIntermediateContact%>&nbsp;&nbsp;<b>Tel: </b>
                            <%=strExportIntermediatePhone%>
                        </p>
                    </td>
                    <td valign="top">
                        <p class="medium">
                            &nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td width="50%" colspan="2" valign="top">
                        <p class="medium">
                            <b>5. FORWARDING AGENT<br>
                            </b>3PL Integration, LLC<br>
                            900 Route 134, Ste 2-17,<br>
                            S. Dennis, MA 02660&nbsp;USA<br>
                            <%--Toll Free 888.884.0577&nbsp;&nbsp;--%>
                            Tel: 508.210.2164 &nbsp;&nbsp;FAX: 508.210.2158</p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>6. POINT OF ORIGIN OR FTZ NO<br>
                            </b>
                            <%=strShipFromCity%>,
                            <%=strShipFromCountry%></p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>7. ULTIMATE DESTINATION<br>
                            </b>
                            <%=strShiptoCountry%></p>
                    </td>
                </tr>
                <tr>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>8. LOADING PIER<br>
                            </b>???????</p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>9. METHOD OF TRANSPORTATION<br>
                            </b>
                            <%=strTransModeName%></p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>14. CARRIER ID CODE<br>
                                &nbsp;</b></p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>15. SHIPMENT REF NO.<br>
                            </b>
                            <%=strShipFromRefNumber%></p>
                    </td>
                </tr>
                <tr>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>10. EXPORTING CARRIER<br>
                            </b>
                            <%=strGLSCarrierName%></p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>11. PORT OF EXPORT<br>
                            </b>
                            <%=strExportLoadingPort%></p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>16. ENTRY NUMBER<br>
                                &nbsp;</b></p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>17. HAZARDOUS MATERIALS<br>
                            </b>
                            <%=strDisplayHazMat%></p>
                    </td>
                </tr>
                <tr>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>12. PORT OF UNLOADING<br>
                            </b>???????</p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>13. CONTAINERIZED<br>
                            </b>
                            <%=strExportContanerized%></p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>18. IN BOND CODE<br>
                                &nbsp;</b></p>
                    </td>
                    <td width="25%" valign="top">
                        <p class="medium">
                            <b>19. ROUTED EXPORT TRANSACTION<br>
                                &nbsp;</b></p>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <div align="center">
        <center>
            <asp:GridView ID="gridShipmentItems" runat="server" AutoGenerateColumns="false" CellPadding="0"
                CellSpacing="0" Width="690px" AllowPaging="True" PageSize="10" AllowSorting="true"
                BorderColor="#808080" BorderWidth="1px" Style="border-collapse: collapse" OnRowDataBound="gridShipmentItems_RowDataBound"
                ShowHeader="false">
                <HeaderStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="CUSTOMER ORDER NUMBER">
                        <ItemTemplate>
                            <asp:Label ID="lblExport_MFG_SI" Text='<%# Eval("Export_MFG_SI")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="# PKGS">
                        <ItemTemplate>
                            <asp:Label ID="lblExportScheduleB_SI" Text='<%# Eval("ExportScheduleB_SI")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="WEIGHT">
                        <ItemTemplate>
                            <asp:Label ID="lblPackQtyType_SI" Text='<%# Eval("Weight_SI")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="PALLET/SLIP">
                        <ItemTemplate>
                            <asp:Label ID="lblWeight_SI" Text='<%# Eval("Weight_SI")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="ADDITIONAL SHIPPER INFO">
                        <ItemTemplate>
                            <asp:Label ID="lblPartNumber_SI" Text='<%# Eval("PartNumber_SI")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="ADDITIONAL SHIPPER INFO">
                        <ItemTemplate>
                            <asp:Label ID="lblDeclaredValue_SI" Text='<%# Eval("DeclaredValue_SI")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table border="1" cellspacing="0" cellpadding="2" width="690" bordercolor="#111111"
                style="border-collapse: collapse">
                <tr>
                    <td width="36%" colspan="3" valign="top">
                        <p class="medium">
                            <b>27. Validated license No./General License Symbol<br>
                            </b>
                            <%=strExportLicence%></p>
                    </td>
                    <td width="32%" colspan="2" valign="top">
                        <p class="medium">
                            <b>28.ECCN</b> <i>(when required)<br>
                            </i>
                            <%=strExportECCN%></p>
                    </td>
                    <td colspan="2" rowspan="7">
                        <p align="center">
                            &nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td width="36%" colspan="3" valign="top">
                        <p class="small">
                            <b>29. Duly authorized officer or employee<br>
                            </b>
                            <%=strShipFromContact%></p>
                    </td>
                    <td width="32%" colspan="2" valign="top">
                        <p class="small">
                            The USPPI authorizes the forwarder named above to act as forwarding agent for export
                            control and customs purposes.</p>
                    </td>
                </tr>
                <tr>
                    <td width="68%" colspan="5" valign="top">
                        <p class="small">
                            <b>30.</b> I certify that all statements made and all information contained herein
                            are true and correct and that I have read and understand the instructions for preparation
                            of this document, set forth in the <b>&quot;Correct Way to Fill Out the Shipper's Export
                                Declaration&quot;</b>. I understand that civil and criminal penalties, including
                            forfeiture and sale, may be imposed for making false or fraudulent statements herein,
                            failing to provide the requested information or for violation of U.S. laws on exportation
                            (13 U.S.C. Sec. 305; 22 U.S.C. Sec. 401; 18 U.S.C. Sec. 1001; 50 U.S.C. App. 2410).
                        </p>
                    </td>
                </tr>
                <tr>
                    <td width="32%" colspan="2" valign="top">
                        <p class="medium">
                            <b>Signature</b></p>
                    </td>
                    <td width="36%" colspan="3" valign="top">
                        <p class="small">
                            <b>Confidential</b> - For use solely for official purposes authorized by the Secretary
                            of Commerce (13 U.S.C. 301 (g).</p>
                    </td>
                </tr>
                <tr>
                    <td width="32%" colspan="2" valign="top">
                        <p class="medium">
                            <b>Title </b>
                        </p>
                    </td>
                    <td width="36%" colspan="3" valign="top">
                        <p class="medium">
                            <i>Export shipments are subject to inspection by U.S. Customs Service and/or Office
                                of Export Enforcement.</i></p>
                    </td>
                </tr>
                <tr>
                    <td width="32%" colspan="2" valign="top">
                        <p class="medium">
                            <b>Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                        </p>
                    </td>
                    <td width="36%" colspan="3" valign="top">
                        <p class="medium">
                            <b>31. Authentication</b> <i>&nbsp;(when&nbsp;required)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </i>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td width="32%" colspan="2" valign="top">
                        <p class="medium">
                            <b>Telephone No. </b>
                        </p>
                    </td>
                    <td width="36%" colspan="3" valign="top">
                        <p class="medium">
                            <b>E-mail address </b>
                        </p>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <br>
    <div align="center">
        <center>
            <table border="0" cellspacing="0" cellpadding="0" width="690" style="border-collapse: collapse"
                bordercolor="#111111">
                <tr>
                    <td width="100%">
                        <p class="small">
                            This form may be printed by private parties provided it conforms to the official
                            form. For sale by Superintendent of Documents, Government Printing Office, Washington,
                            DC 20402, and local Customs District Directors. The <b>&quot;Correct Way to Fill Out
                                the Shipper's Export Declaration&quot; </b>is available from the U.S. Census
                            Bureau, Washington, DC20233.</p>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <p class="classPageBreak" />
    <table align="center" border="0" cellpadding="5" cellspacing="0" bordercolor="#111111"
        width="690">
        <tr>
            <td width="100%" valign="top">
                <div>
                    <p align="center">
                        <b>SHIPPER'S LETTER OF INSTRUCTION</b></p>
                    <!-- Table 1 -->
                    <table border="1" style="border-collapse: collapse" width="100%" bordercolor="#111111"
                        cellspacing="0" cellpadding="1">
                        <tr>
                            <!-- Total Colspan is 6 -->
                            <td width="55%">
                                <!--Begin Inner Table 1 -->
                                <div align="center">
                                    <center>
                                        <table border="0" width="100%" cellspacing="0" cellpadding="2">
                                            <tr>
                                                <td valign="top" width="25%">
                                                    <b>1a. Exporter:</b>
                                                </td>
                                                <td valign="top" width="75%">
                                                    <%=strShipFromCompany%><br>
                                                    <%=strShipFromAddress%><br>
                                                    <%=strShipFromCity%>,
                                                    <%=strShipFromState%>&nbsp;<%=strShipFromPostalCode%><br>
                                                    <%=strShipFromCountry%><br>
                                                    <b>Contact:</b>&nbsp;<%=strShipFromContact%><br>
                                                    <b>Tel:</b>&nbsp;<%=strShipFromPhone%>
                                                    <br>
                                                    <b>Fax:</b>&nbsp;<%=strShipFromFax%>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                <!--End Inner Table 1 -->
                            </td>
                            <td align="center" width="45%" colspan="2">
                                <b>HAWB No:</b>&nbsp;<%=strGLSTrackingNumber%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>1b. Exporter's EIN (IRS) No.:</b>&nbsp;
                                <%=strExportEIN%>
                            </td>
                            <td colspan="2" rowspan="3">
                                <span align="center">
                                    <center>
                                        <img src="../images/logo.jpg" border="0"></center>
                                </span>
                                <br>
                                <b>Bill To:</b><br>
                                <%=strGLSBillCompany%><br>
                                <%=strGLSBillAddress%><br>
                                <%=strGLSBillCity%>,
                                <%=strGLSBillState%>&nbsp;<%=strGLSBillPostalCode%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>1c. Parties to Transaction:</b>&nbsp;
                                <%=strExportPartyTrans%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <!--Begin Inner Table 2 -->
                                <div align="center">
                                    <center>
                                        <table border="0" width="100%" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="25%" valign="top">
                                                    <b>4a. Ultimate Consignee:</b>
                                                </td>
                                                <td width="75%" valign="top">
                                                    <%=strShiptoCompany%><br>
                                                    <%=strShiptoAddress%><br>
                                                    <%=strShiptoCity%>,
                                                    <%=strShiptoState%>&nbsp;<%=strShiptoPostalCode%><br>
                                                    <%=strShiptoCountry%><br>
                                                    <b>Contact:</b>&nbsp;<%=strShipToContact%><br>
                                                    <b>Tel:</b>&nbsp;<%=strShipToPhone%>
                                                    <br>
                                                    <b>Fax:</b>&nbsp;<%=strShipToFax%>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                <!--End Inner Table 2 -->
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <b>4b. Intermediate Consignee:<br>
                                </b>&nbsp;<%=strExportIntermediateConsignee%>&nbsp;&nbsp;<b>Contact: </b>
                                <%=strExportIntermediateContact%>&nbsp;&nbsp;<b>Tel: </b>
                                <%=strExportIntermediatePhone%>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <b>5. Forwarding Agent:</b><br>
                                3PL Integration, LLC<br>
                                900 Route 134, Ste 2-17, S. Dennis, MA 02660
                            </td>
                            <td valign="top" width="19%">
                                <b>6. Point of Origin</b><br>
                                <%=strShipFromCity%>,
                                <%=strShipFromState%><br>
                                <%=strShipFromCountry%>
                            </td>
                            <td valign="top" width="24%">
                                <b>7. Ultimate Destination</b><br>
                                <%=strShiptoCountry%>
                            </td>
                        </tr>
                        <tr>
                            <td width="44%" colspan="3">
                                <b>Billing:<br>
                                    COD:</b>
                                <% if (strDisplayGLSCodFee != "")
                                   { %>
                                <%=strDisplayGLSCodFee + "&nbsp;<b>USD</b>"%><% }%>
                            </td>
                        </tr>
                        <tr>
                            <td width="55%" valign="top" rowspan="2">
                                <!-- Inner Table 3 -->
                                <table border="1" style="border-collapse: collapse" cellpadding="2" cellspacing="0"
                                    bordercolor="#111111" width="100%">
                                    <tr>
                                        <td width="50%" valign="top">
                                            <b>8. Loading Pier:</b>
                                        </td>
                                        <td width="50%" valign="top">
                                            <b>9. Mode of Transport:</b><br>
                                            <%=strTransModeName%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" valign="top">
                                            <b>10. Exporting Carrier:</b><br>
                                            <%=strGLSCarrierName%>
                                        </td>
                                        <td width="50%" valign="top">
                                            <b>11. Port of Export:</b><br>
                                            <%=strExportLoadingPort%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" valign="top">
                                            12. Port of Unloading:&nbsp; Port of unloading
                                        </td>
                                        <td width="50%" valign="top">
                                            <b>13. Containerized:</b>
                                            <%=strExportContanerized%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" valign="top">
                                            <b>Shipper Requests Insurance:</b><br>
                                            <%=strInsuranceRequired%>
                                        </td>
                                        <td width="50%" valign="top">
                                            <b>Insured Amount:</b><br>
                                            <%=strDisplayInsuredValue%>
                                        </td>
                                    </tr>
                                </table>
                                <!--End Inner Table 3 -->
                            </td>
                            <td width="45%" colspan="2" valign="top">
                                <b>Service:</b><br>
                                <%=strTransModeService1%>&nbsp;-&nbsp;<%=strTransModeService2%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <b>Shipper's instructions in case of inability to deliver consignment as assigned:</b><br>
                                <%=strShippersInstructions%>
                            </td>
                        </tr>
                    </table>
                    <!--End  Table 1 -->
                    <asp:GridView ID="gridShipmentItems1" runat="server" AutoGenerateColumns="false"
                        CellPadding="0" CellSpacing="0" Width="690px" AllowPaging="True" PageSize="10"
                        AllowSorting="true" BorderColor="#808080" BorderWidth="1px" Style="border-collapse: collapse"
                        OnRowDataBound="gridShipmentItems1_RowDataBound" ShowHeader="false">
                        <HeaderStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="CUSTOMER ORDER NUMBER">
                                <ItemTemplate>
                                    <asp:Label ID="lblExport_MFG_SI" Text='<%# Eval("Export_MFG_SI")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="# PKGS">
                                <ItemTemplate>
                                    <asp:Label ID="lblExportScheduleB_SI" Text='<%# Eval("ExportScheduleB_SI")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="WEIGHT">
                                <ItemTemplate>
                                    <asp:Label ID="lblExportScheduleB_SI_X" Text='<%# Eval("Weight_SI")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="PALLET/SLIP">
                                <ItemTemplate>
                                    <asp:Label ID="lblPackQtyType_SI" Text='<%# Eval("HandlingUnitType")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="ADDITIONAL SHIPPER INFO">
                                <ItemTemplate>
                                    <asp:Label ID="lblWeight_SI" Text='<%# Eval("Weight_SI")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="ADDITIONAL SHIPPER INFO">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeclaredValue_SI" Text='<%# Eval("DeclaredValue_SI")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <table border="1" style="border-collapse: collapse" width="100%" bordercolor="#111111"
                        cellspacing="0" cellpadding="1">
                        <tr>
                            <td valign="top" width="70%" colspan="5">
                                <p class="medium">
                                    These commodities, technology or software, were exported from the United States
                                    in accordance with the Export Administration Regulations. Diversion contrary to
                                    U.S. law prohibited.</p>
                            </td>
                            <td width="30%" valign="top">
                                <b>Declared Value for Carriage:</b><br>
                                <%=dblTotalDeclaredValue%>
                            </td>
                        </tr>
                    </table>
                    <!-- Table 2 -->
                    <!--Table 3 -->
                    <table border="1" style="border-collapse: collapse" width="100%" bordercolor="#111111"
                        cellspacing="0" cellpadding="1">
                        <tr>
                            <td valign="top" width="50%" colspan="5">
                                <b>21. Validated license No./General License Symbol:</b><br>
                                <%=strExportLicence%>
                            </td>
                            <td valign="top" width="50%" colspan="5">
                                <b>22. ECCN: NLR</b><br>
                                <%=strExportECCN%>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="50%" colspan="5" valign="top">
                                <b>23. Duly authorized officer or employee:&nbsp; Pickup Location Contact</b><br>
                                <%=strShipFromContact%>
                            </td>
                            <td valign="top" width="50%" colspan="5">
                                <p class="medium">
                                    The exporter authorizes the forwarder named above to act as forwarding agent for
                                    export control and customs purposes.</p>
                            </td>
                        </tr>
                        <tr>
                            <td width="63%" colspan="7" valign="top">
                                <p class="medium">
                                    <b>24.</b> I certify that all statements made and all information contained herein
                                    are true and correct and that I have read and understand the instructions for preparation
                                    of this document, set forth in the <b>&quot;Correct Way to Fill Out the Shipper's Export
                                        Declaration&quot;</b>. I understand that cilil and criminal penalties, including
                                    forfeiture and sale, may be imposed for making false or fraudulent statements herein,
                                    failing to provide the requested information or for violation of U.S. laws on exportation
                                    (13 U.S.C. Sec. 305; 22 U.S.C. Sec. 401; 18 U.S.C. Sec. 1001; 50 U.S.C. App. 2410).
                                </p>
                            </td>
                            <td width="36%" colspan="3" valign="top">
                                <b>Documents Enclosed: Documents enclosed</b><br>
                                <%=strDocumentsEnclosed%>
                            </td>
                        </tr>
                        <tr>
                            <td width="38%" colspan="2" valign="top">
                                <p class="medium">
                                    Signature:</p>
                            </td>
                            <td width="25%" colspan="5" valign="top">
                                <p class="medium">
                                    <b>Confidential </b>- For use solely for official purposes authorized by the Secretary
                                    of Commerce (13 U.S.C. 301 (g).</p>
                            </td>
                            <td colspan="3" rowspan="3" valign="top">
                                <b>Special Instructions:</b><br>
                                <%=strSpecialInstructions%>
                            </td>
                        </tr>
                        <tr>
                            <td width="38%" colspan="2" valign="top">
                                <p class="medium">
                                    Title:
                                </p>
                            </td>
                            <td width="25%" colspan="5" valign="top">
                                <p class="medium">
                                    Export shipments are subject to inspection by U.S. Customs Service and/or Office
                                    of Export Enforcement.</p>
                            </td>
                        </tr>
                        <tr>
                            <td width="38%" colspan="2" valign="top">
                                <p class="medium">
                                    Date:
                                </p>
                            </td>
                            <td width="25%" colspan="5" valign="top">
                                <p class="medium">
                                    <b>25.</b> Authentication: <i>&nbsp; </i>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="63%" colspan="10" valign="top">
                                NOTE: The shipper or his Authorized Agent hereby authorizes the above named Company,
                                in his name and on his behalf, to prepare any export documents, to sign and accept
                                any documents relating to said shipment and forward this shipment in accordance
                                with the conditions of carriage and the tariffs of the carriers employed. The shipper
                                guarantees payment of all collect charges in the event the consignee refuses payment.
                                Hereunder the sole responsibility of the Company is to use reasonable care in the
                                selection of carriers, forwarders, agents and others to whom it may entrust the
                                shipment.
                            </td>
                        </tr>
                    </table>
                    <!--End Table 3 -->
                    <!-- Start Overflow Table -->
                    <%
                        if (intOverflow != 0)
                        {
                    %>
                    <!--Begin Outer Most Table  -->
                    <p class="classPageBreak" />
                    <table align="center" border="0" cellpadding="0" cellspacing="0" bordercolor="#800000"
                        width="690">
                        <!-- Begin Header Row -->
                        <tr>
                            <td valign="top" width="60%" align="left">
                                <img src="../images/logo.jpg" border="0">
                            </td>
                            <td width="40%" valign="top">
                                3PL Integration, LLC<br>
                                900 Route 134, Ste 2-17 &middot; S. Dennis, MA 02660
                                <%--Toll Free: 888.884.0577&nbsp;--%>Tel: 508.210.2164&nbsp;Fax: 508.210.2158<br>
                                <a href="http://www.3plintegration.com">www.3plintegration.com</a>
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
                                                            <td width="50%" valign="top">
                                                                <%
                                                                    //Call DisplayShipmentItems(2,1)
                                                                    //'Call DisplaySkids(2)
                                                                %>
                                                                <asp:GridView ID="gridShipmentItems2" runat="server" AutoGenerateColumns="false"
                                                                    CellPadding="0" CellSpacing="0" Width="690px" AllowPaging="True" PageSize="10"
                                                                    AllowSorting="true" BorderColor="#808080" BorderWidth="1px" Style="border-collapse: collapse"
                                                                    OnRowDataBound="gridShipmentItems_RowDataBound" ShowHeader="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="CUSTOMER ORDER NUMBER">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExport_MFG_SI" Text='<%# Eval("Export_MFG_SI")%>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="# PKGS">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExportScheduleB_SI" Text='<%# Eval("ExportScheduleB_SI")%>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="WEIGHT">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPackQtyType_SI" Text='<%# Eval("Weight_SI")%>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="PALLET/SLIP">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblWeight_SI" Text='<%# Eval("Weight_SI")%>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="ADDITIONAL SHIPPER INFO">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPartNumber_SI" Text='<%# Eval("PartNumber_SI")%>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="ADDITIONAL SHIPPER INFO">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDeclaredValue_SI" Text='<%# Eval("DeclaredValue_SI")%>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
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
                    <!--End Outer Most Table  -->
                    <%
                        }

                        if (intKnownShipper == 0)
                        {%>
                    <p class="classPageBreak" />
                    <!--Begin SSE Table  -->
                    <table align="center" border="0" bordercolor="#0000FF" cellpadding="2" cellspacing="0"
                        width="690">
                        <tr>
                            <td class="SSE" width="100%">
                                <p class="SSE">
                                    3PL Integration, LLC<br>
                                    900 Route 134, Ste 2-17<br>
                                    S. Dennis MA 02660<br>
                                    <%--Toll Free: 888.884.0577&nbsp;--%>
                                    Tel: 508.210.2164 &nbsp; Fax: 508.210.2158</p>
                                <p class="SSE" align="center">
                                    <b>REQUIRED SECURITY INFORMATION</b></p>
                                <%
                                    if (intTransMode < 4)
                                    {
                                %>
                                <p class="SSE" align="center">
                                    Air Waybill Number: <b>
                                        <%=strGLSTrackingNumber%></b>
                                    <%
                                        }
                                    else
                                    {
                                    %>
                                    <p class="SSE" align="center">
                                        HAWB No.: <b>
                                            <%=strGLSTrackingNumber%></b>
                                        <%
                                            }
                                        %>
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
                                    <br>
                                    <div align="center">
                                        <table border="0" width="596" id="table5" style="border-collapse: collapse">
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
                    <%	}
                    %>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
