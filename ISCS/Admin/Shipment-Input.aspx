<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Shipment-Input.aspx.cs" Inherits="ISCS.Admin.ShipmentInput" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #tblTrack tbody tr td a
        {
            color: Blue !important;
            cursor: pointer;
        }
    </style>
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Edit Shipment Tracking</h2>
            <div class="whiteBox">
                <asp:Panel ID="pnltrack" runat="server" Visible="false">
                    <table cellspacing="0" cellpadding="0" border="0" id="tblTrack" width="100%">
                        <tbody>
                            <tr>
                                <td>
                                    <label>
                                        Tracking No:</label>
                                </td>
                                <td>
                                    <asp:Label ID="lbltrackingno" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hidTrackingNo" runat="server" />
                                </td>
                                <td>
                                    <label>
                                        Shipper Ref. No.:</label>
                                </td>
                                <td>
                                    <asp:Label ID="lblshipperrefno" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>
                                        &nbsp;</label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <label>
                                        Consignee Ref No.:</label>
                                </td>
                                <td>
                                    <asp:Label ID="lblconsigneerefno" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>
                                        Ship Date :</label>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="lblshipdate" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>
                                        Status :</label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="drpstatus" runat="server" CssClass="track">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>
                                        Service Level :</label>
                                </td>
                                <td>
                                    <label>
                                        Carrier :</label>
                                </td>
                                <td colspan="2">
                                    <label>
                                        Pro Number :</label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>
                                        <asp:Label ID="lbltransmode" runat="server" Text=""></asp:Label></label>
                                </td>
                                <td>
                                    <label>
                                        <span>Pickup :&nbsp;</span><asp:Label ID="lblglscarriername" runat="server" Text=""></asp:Label></label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtpronumber" runat="server" CssClass="track"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>
                                        &nbsp;</label>
                                </td>
                                <td>
                                    <label>
                                        <span>Intermediate :&nbsp;</span><asp:Label ID="lblglscarriernameinterm" runat="server"
                                            Text=""></asp:Label></label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtpronumberinterm" runat="server" CssClass="track"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>
                                        &nbsp;</label>
                                </td>
                                <td>
                                    <label>
                                        <span>Delivery :&nbsp;</span><asp:Label ID="lblglscarriernamedelivery" runat="server"
                                            Text=""></asp:Label></label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtpronumberdelivery" runat="server" CssClass="track"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>
                                        &nbsp;</label>
                                </td>
                                <td>
                                    <label>
                                        <span>Other :&nbsp;</span><asp:Label ID="lblglscarriernameother" runat="server" Text=""></asp:Label></label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtpronumberother" runat="server" CssClass="track"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <label>
                                        Status Date
                                    </label>
                                </td>
                                <td>
                                    <label>
                                        Time
                                    </label>
                                </td>
                                <td>
                                    Agent
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:DropDownList ID="drpstatusmonth" runat="server" CssClass="track">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpstatusday" runat="server" CssClass="track">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpstatusyear" runat="server" CssClass="track">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drptimehr" runat="server" CssClass="track">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drptimemin" runat="server" CssClass="track">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpagentsid" runat="server" CssClass="track">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <label>
                                        Notes :</label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtnotes" runat="server" TextMode="MultiLine" Columns="5" Rows="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <label>
                                        Shipper :</label>
                                </td>
                                <td>
                                    <label>
                                        <asp:Label ID="lblshipper" runat="server"></asp:Label>
                                    </label>
                                </td>
                                <td valign="top">
                                    <label>
                                        Consignee :</label>
                                </td>
                                <td>
                                    <label>
                                        <asp:Label ID="lblconsignee" runat="server"></asp:Label>
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>
                                        Pieces :</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpieces" runat="server" CssClass="track" MaxLength="6" onkeypress="return onlyDigits(event,'NOdec')"></asp:TextBox>
                                </td>
                                <td>
                                    <label>
                                        Actual Weight :</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtactualweight" runat="server" CssClass="track" MaxLength="10"
                                        onkeypress="return onlyDigits(event,'decOK')"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnAdd" runat="server" CausesValidation="false" Text="Save" CssClass="adminButton"
                                        OnClick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="return"
                                            runat="server" CausesValidation="false" Text="Return" CssClass="adminButton"
                                            OnClick="return_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="delete"
                                                runat="server" CausesValidation="false" Text="Delete" CssClass="adminButton"
                                                OnClick="delete_Click" OnClientClick="return confirm('This will permanently delete the bill..Are you sure.')" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <% if (transportationmode == 0)
                               { %>
                            <tr>
                                <td colspan="4">
                                    <%--<asp:LinkButton ID="lnkshipdoc" Text="View and Print Shipping Documents" runat="server"
                                        PostBackUrl="~/Admin/BillOfLading_Vics.aspx" ></asp:LinkButton>--%>
                                    <a onclick="window.open('BillOfLading_Vics.aspx?PickupRequestId=<% =PickupRequestID %>','mywindow');">
                                        View and Print Shipping Documents</a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <%--<asp:LinkButton ID="lnkpac" Text="View and Print Packing List" runat="server"
                                        PostBackUrl="~/Admin/PackingList.aspx" ></asp:LinkButton>--%>
                                    <a onclick="window.open('PackingList.aspx?id=<% =PickupRequestID %>','mywindow');">View
                                        and Print Packing List</a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <a onclick="window.open('ShippingLabels.aspx?id=<% =PickupRequestID %>','mywindow');">
                                        View and Print Shipping Labels</a>
                                </td>
                            </tr>
                            <% }
                               else if (transportationmode == 1)
                               { %>
                            <tr>
                                <td colspan="4">
                                    <a onclick="window.open('BillOfLading_Vics.aspx?PickupRequestId=<%= PickupRequestID %>','mywindow');">
                                        View and Print Shipping Documents</a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <a onclick="window.open('PackingList.aspx?id=<%= PickupRequestID %>','mywindow');">View
                                        and Print Packing List</a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <a onclick="window.open('ShippingLabels.aspx?id=<%= PickupRequestID %>','mywindow');">
                                        View and Print Shipping Labels</a>
                                </td>
                            </tr>
                            <% }
                               else if (transportationmode == 2)
                               { %>
                            <tr>
                                <td colspan="4">
                                    <a onclick="window.open('AirWaybill.aspx?PickupRequestId=<%= PickupRequestID %>','mywindow');">
                                        View and Print Shipping Documents</a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <a onclick="window.open('PackingList.aspx?id=<%= PickupRequestID %>','mywindow');">View
                                        and Print Packing List</a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <a onclick="window.open('ShippingLabels.aspx?id=<%= PickupRequestID %>','mywindow');">
                                        View and Print Shipping Labels</a>
                                </td>
                            </tr>
                            <% }
                               else if (transportationmode == 3 || transportationmode == 4)
                               { %>
                            <tr>
                                <td colspan="4">
                                    <a onclick="window.open('SED-SLI.aspx?PickupRequestId=<%= PickupRequestID %>','mywindow');">
                                        View and Print Shipping Documents</a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <a onclick="window.open('PackingList.aspx?id=<%= PickupRequestID %>','mywindow');">View
                                        and Print Packing List</a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <a onclick="window.open('ShippingLabels.aspx?id=<%= PickupRequestID %>','mywindow');">
                                        View and Print Shipping Labels</a>
                                </td>
                            </tr>
                            <% } %>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
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
    </div>
</asp:Content>
