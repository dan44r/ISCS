<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Shipment_View.aspx.cs" Inherits="ISCS.Admin.Shipment_View" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #tblTrack tbody tr td a
        {
            color: Blue !important;
            cursor: pointer;
        }
        .feedback label
        {
            display: block;
            float: left;
            height: 21px;
            line-height: 21px;
            margin: 0 0 5px;
            font-weight: normal;
            font-size: 11px;
        }
        #tblBillLinks tbody tr td a
        {
            color: White !important;
            cursor: pointer;
            text-decoration: underline;
        }
    </style>
    <div class="rht-cont">
        <center>
            <div class="inr-cont feedback">
                <center>
                    <h2 style="color: #FFFFFF;">
                        Shipment Tracking Bill</h2>
                </center>
                <div>
                    <asp:Panel ID="pnltrack" runat="server" Visible="false">
                        <table width="80%" border="1" style="border-collapse: collapse; border: solid 1px #FFFFFF"
                            cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%" id="tblTrack" style="background-color: #D1CDC6;">
                                        <tbody>
                                            <tr>
                                                <td style="width: 25%">
                                                    <label>
                                                        Tracking No:</label>
                                                </td>
                                                <td style="width: 30%">
                                                    <asp:Label ID="lbltrackingno" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <label>
                                                        Shipper Ref. No.:</label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:Label ID="lblshipperrefno" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Ship Date :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblshipdate" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                    <label>
                                                        Consignee Ref No.:</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblconsigneerefno" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #5F5F5F; color: #FFFFFF;">
                                                <td>
                                                    <label>
                                                        Status :</label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #5F5F5F; color: #FFFFFF;">
                                                <td>
                                                    <label>
                                                        Service Level :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbltransmode" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr style="background-color: #5F5F5F; color: #FFFFFF;">
                                                <td>
                                                    <label>
                                                        Date :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStatusDate" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                    <label>
                                                        Time :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStatusHr" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td colspan="3">
                                                    *an asterisk following status means please see notes for more information.
                                                </td>
                                            </tr>
                                            <tr style="height: 5px">
                                                <td>
                                                </td>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <label>
                                                        Ship From :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblshipper" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr style="height: 10px">
                                                <td>
                                                </td>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <label>
                                                        Ship To :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblconsignee" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #5F5F5F; color: #FFFFFF;">
                                                <td colspan="4">
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    Pieces :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblpieces" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    Actual Weight :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblactualweight" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <% if (transportationmode == 2 || transportationmode == 3)
                                                                   { %>
                                                                <td align="center">
                                                                    Dim Weight :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblDimWeight" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <% }
                                                                %>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height: 10px">
                                                <td>
                                                </td>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    Notes:
                                                </td>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="left">
                                                    <asp:Label ID="lblnotes" runat="server" Text="" Style="width: 150px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table cellspacing="0" cellpadding="0" border="0" width="100%" id="tblBillLinks">
                            <tbody>
                                <% if (transportationmode == 0)
                                   { %>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('BillOfLading_Vics.aspx?PickupRequestId=<% =PickupRequestID %>','mywindow');">
                                            View and Print Shipping Documents</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('PackingList.aspx?id=<% =PickupRequestID %>','mywindow');">View
                                            and Print Packing List</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('ShippingLabels.aspx?id=<% =PickupRequestID %>','mywindow');">
                                            View and Print Shipping Labels</a>
                                    </td>
                                </tr>
                                <% }
                                   else if (transportationmode == 1)
                                   { %>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('BillOfLading_Vics.aspx?PickupRequestId=<%= PickupRequestID %>','mywindow');">
                                            View and Print Shipping Documents</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('PackingList.aspx?id=<%= PickupRequestID %>','mywindow');">View
                                            and Print Packing List</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('ShippingLabels.aspx?id=<%= PickupRequestID %>','mywindow');">
                                            View and Print Shipping Labels</a>
                                    </td>
                                </tr>
                                <% }
                                   else if (transportationmode == 2)
                                   { %>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('AirWaybill.aspx?PickupRequestId=<%= PickupRequestID %>','mywindow');">
                                            View and Print Shipping Documents</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('PackingList.aspx?id=<%= PickupRequestID %>','mywindow');">View
                                            and Print Packing List</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('ShippingLabels.aspx?id=<%= PickupRequestID %>','mywindow');">
                                            View and Print Shipping Labels</a>
                                    </td>
                                </tr>
                                <% }
                                   else if (transportationmode == 3 || transportationmode == 4)
                                   { %>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('SED-SLI.aspx?PickupRequestId=<%= PickupRequestID %>','mywindow');">
                                            View and Print Shipping Documents</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('PackingList.aspx?id=<%= PickupRequestID %>','mywindow');">View
                                            and Print Packing List</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <a onclick="window.open('ShippingLabels.aspx?id=<%= PickupRequestID %>','mywindow');">
                                            View and Print Shipping Labels</a>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                        <br />
                        <asp:HiddenField ID="hdtrackingbillid" runat="server" />
                        <asp:HiddenField ID="hdairportid" runat="server" />
                        <asp:HiddenField ID="hdDimWeight" runat="server" />
                        <asp:HiddenField ID="hdshipfromcompany" runat="server" />
                        <asp:HiddenField ID="hdshiptocompany" runat="server" />
                        <asp:HiddenField ID="hdPickupRequestId" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pnlnorecord" runat="server" Visible="false">
                        <h4>
                            Sorry, no such record found.</h4>
                    </asp:Panel>
                </div>
            </div>
        </center>
    </div>
</asp:Content>
