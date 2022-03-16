<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostSummaryReport.aspx.cs"
    Inherits="ISCS.Admin.CostSummaryReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cost Summary By Order Number Report</title>
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
                        <table width="100%">
                            <tr>
                                <td>
                                    <b>Order No :</b> &nbsp;
                                    <%=OrderNo%>
                                </td>
                                <td align="right">
                                    <strong>Total Cost : </strong>&nbsp;<%=strTotalCost%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>3PL Integration, LLC<br>
                                        508.210.2164</b>
                                </td>
                                <td align="right">
                                    <b>Run Date :</b> &nbsp;
                                    <%=CurrentDate%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="height: 10px;">
                                    <h2 style="color: #8A0808;">
                                        COST SUMMARY BY ORDER NUMBER REPORT</h2>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <h3>
                                        <%=CompanyName%></h3>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr style="height: 5px; background-color: Black;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
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
                        <asp:Button ID="btnCostSummaryExp" runat="server" Text="Export" CssClass="adminButton"
                            OnClick="btnCostSummaryExp_Click" Style="width: 152px;" />
                        <asp:Button ID="btnEmail" runat="server" Text="Email" CssClass="adminButton" OnClick="btnEmail_Click"
                            Style="width: 152px;" />
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
