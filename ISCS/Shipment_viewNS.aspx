<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Shipment_viewNS.aspx.cs" Inherits="ISCS.Shipment_viewNS" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #tblTrack tbody tr td a
        {
            color: Blue !important;
            cursor: pointer;
        }
        #tblBillLinks tbody tr td a
        {
            cursor: pointer;
            text-decoration: underline;
        }
    </style>
    <div class="content">
        <div class="inr-cont feedback">
            <h2>
                Shipment Tracking Bill</h2>
            <br />
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
            <asp:Panel ID="pnlData" runat="server">
                <center>
                    <table width="60%" border="1" style="border-collapse: collapse; border: solid 1px black"
                        cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table width="100%" border="0" id="tblTrack" cellpadding="0" cellspacing="0" style="background-color: #D1CDC6;">
                                    <tr>
                                        <td>
                                            <label>
                                                Tracking No :</label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblTrackingNo" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <label>
                                                Shipper Ref. No :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblShipperRefNo" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Ship Date :</label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblShipDate" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <label>
                                                Consignee Ref No :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblConsigneeRef" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #5F5F5F; color: #FFFFFF;">
                                        <td>
                                            <label>
                                                Status :</label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #5F5F5F; color: #FFFFFF;">
                                        <td>
                                            <label>
                                                Service Level :</label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblServiceLevel" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #5F5F5F; color: #FFFFFF;">
                                        <td>
                                            <label>
                                                Date :</label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <label>
                                                Time :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTime" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Ship From :</label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <span id="spanShipFrom" runat="server"></span>
                                            <asp:Label ID="lblShipFrom" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px">
                                        <td>
                                        </td>
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Ship To :</label>
                                        </td>
                                        <td align="left" colspan="3">
                                            <span id="spanShipTo" runat="server"></span>
                                            <asp:Label ID="lblShipTo" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #5F5F5F; color: #FFFFFF;">
                                        <td colspan="4" style="padding-top: 2px; padding-bottom: 2px;">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="left">
                                                            Pieces :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPieces" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            Actual Weight :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblActualWeight" runat="server"></asp:Label>
                                                        </td>
                                                        <% if (transportationmode == 2 || transportationmode == 3)
                                                           { %>
                                                        <td align="center">
                                                            Dim Weight :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDimWeight" runat="server"></asp:Label>
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
                                        <td>
                                            Notes :
                                        </td>
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblNotes" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
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
                </center>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
