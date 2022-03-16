<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActiveShipmentReport.aspx.cs"
    Inherits="ISCS.Admin.ActiveShipmentReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Active Shipment Report</title>
    <style type="text/css">
        body
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 10px;
        }
        .classPageBreak
        {
            page-break-after: always;
        }
        .whiteBox input.adminButton
        {
            background-color: #daa929;
            border: medium none;
            color: #FFFFFF;
            cursor: pointer;
            font-family: tahoma,Helvetica,sans-serif;
            font-size: 11px;
            font-size-adjust: none;
            font-stretch: normal;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            height: 25px;
            vertical-align: middle;
            width: 75px;
            padding: 0;
        }
        .whiteBox input
        {
            width: 240px;
            height: 18px;
            padding: 3px 0 0 6px;
            border: 1px solid #c8c8c8;
            margin: 0 0 5px;
            font-size: 11px;
            letter-spacing: 0.9px;
            color: #000;
        }
        .submitMsg
        {
           
            background-position: center left;
            background-repeat: no-repeat;
            color: red;
            font-weight: bold;
            font-size: 13px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div class="whiteBox">
        <div style="font-size: 10px;">
            <table width="900px" cellspacing="0" cellpadding="0" border="0" align="center">
                <tr>
                    <td width="80%" valign="top" align="left">
                        <img border="0" src="images/logo.jpg">
                    </td>
                    <td width="20%" valign="top">
                        3PL Integration, LLC<br>
                        900 Route 134, Ste 2-17
                        <br>
                        S. Dennis, MA 02660
                        <br>
                        Tel: 508.210.2164&nbsp;Fax: 508.210.2158<br>
                        <a href="http://www.3plintegration.com">www.3plintegration.com</a><br>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <h2 style="color: #8A0808;">
                            ACTIVE SHIPMENT REPORT</h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                       
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gridActiveShipment" runat="server" AutoGenerateColumns="false"
                            CssClass="mGrid dataList" CellPadding="2" CellSpacing="2" Width="100%" BorderColor="#808080"
                            BorderWidth="1px" Style="border-collapse: collapse" OnPageIndexChanging="gridActiveShipment_PageIndexChanging"
                            PagerStyle-CssClass="pgr">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="PO#">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPO" Text='<%# Eval("PO#")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="ShipTo Consignee RefNumber">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShipToConsigneeRefNumber" Text='<%# Eval("ShipToConsigneeRefNumber")%>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Ship From Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShipFromDate" Text='<%# Eval("ShipFromDate")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Ship To Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShipToDate" Text='<%# Eval("ShipToDate")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Ship From City">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShipFromCity" Text='<%# Eval("ShipFromCity")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Ship From State">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShipFromState" Text='<%# Eval("ShipFromState")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Ship To City">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShipToCity" Text='<%# Eval("ShipToCity")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Ship To State">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShipToState" Text='<%# Eval("ShipToState")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Tracking No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTrackingNumber" Text='<%# Eval("TrackingNumber")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="70%" HeaderStyle-HorizontalAlign="Left" HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" Text='<%# Eval("Description")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Special Instructions">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSpecialInstructions" Text='<%# Eval("SpecialInstructions")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Description1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription1" Text='<%# Eval("Description1")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="CarrierName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCarrierName" Text='<%# Eval("CarrierName")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Cost">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCost" Text='<%# Eval("Cost")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left" HeaderText="Date Last Updated">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateLastUpdated" Text='<%# Eval("DateLastUpdated")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Repeater ID="rpt1" runat="server">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td valign="top" style="width: 30%;">
                                            <%# Eval("TrackingNumber")%>
                                            &nbsp;&nbsp;&nbsp;&nbsp; <b>Order No :</b>&nbsp;<%# Eval("ShipFromRefNumber")%>
                                            <br />
                                            <b>CID :</b>&nbsp;<%# Eval("ShipToConsigneeRefNumber")%>
                                        </td>
                                        <td style="width: 40%">
                                            <%# Eval("Description1")%>
                                        </td>
                                        <td align="left" valign="top" style="width: 30%; padding-left: 5%;">
                                            <b>Status : &nbsp;</b><%# Eval("Description2")%>
                                            <br />
                                            <%# Eval("Notes")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Ship Date :</b> &nbsp;<%#DateFormat(Eval("ShipFromDate").ToString())%>
                                            <br />
                                            <b>Transit Time To Date :</b>&nbsp;
                                            <%#DateFormat(Eval("ShipToDate").ToString())%>
                                            <br />
                                            <b>Carrier : </b>&nbsp;<%# Eval("CarrierName")%>
                                            <br />
                                            <b>Cost :</b>&nbsp;
                                            <%# Eval("GLSTotalSellRate")%>
                                        </td>
                                        <td>
                                            
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Last Updated :</b>&nbsp;
                                            <%# Eval("DateLastUpdated")%>
                                        </td>
                                        <td>
                                            <b>Service :</b> &nbsp;
                                            <%# Eval("Service1")%>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="body_text_12" colspan="2">
                        <asp:Button ID="btnExport" runat="server" Visible="false" Text="Export" CssClass="adminButton"
                            OnClick="btnExport_Click" Style="width: 152px;" />
                        <asp:Button ID="btnEmail" runat="server" Visible="false" Text="Email" CssClass="adminButton"
                            OnClick="btnEmail_Click" Style="width: 152px;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr>
                <td>
                    <asp:Literal ID="ltCostSum" Visible="false" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
