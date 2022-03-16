<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="GenerateReports.aspx.cs" Inherits="ISCS.Admin.GenerateReports" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" language="Javascript">
        function searchkeytextblank(txtbox) {
            if (txtbox.value == 'Keywords') {
                txtbox.value = '';
            }
        }
        function searchkeytextfill(txtbox) {
            if (txtbox.value == '') {
                txtbox.value = 'Keywords';
            }
        }
        function validateOrderNo() {

            openNewWin('ActiveShipmentReport.aspx')
            return false;
        }


        function openNewWin(url) {

            var x = window.open(url, 'mynewwin');

            x.focus();

        } 
    </script>

    <style type="text/css">
        .dataList td
        {
            padding: 5px 0 0 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox" style="width: 800px;">
            <h2>
                Active Shipment Report</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Active Shipment Report</h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                Click the "Get Active Shipment Report" button to generate the Active Shipment Report
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3" style="height: 50px;">
                                <asp:Button ID="btnActiveShipment" runat="server" Text="Get Active Shipment Report"
                                    CssClass="adminButton" OnClick="btnActiveShipment_Click" Style="width: 212px;"
                                    OnClientClick="return validateOrderNo();" />
                                <asp:Button ID="btnExport" runat="server" Text="Export" CssClass="adminButton" OnClick="btnExport_Click"
                                    Style="width: 152px;" />
                                <asp:Button ID="btnEmail" runat="server" Text="Email" CssClass="adminButton" OnClick="btnEmail_Click"
                                    Style="width: 152px;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server" Text=""></asp:Label>
                                <div>
                                    <asp:GridView ID="gridUsers" runat="server" AutoGenerateColumns="true" CssClass="mGrid dataList"
                                        Width="100%" GridLines="None" CellPadding="1" CellSpacing="1" PagerStyle-CssClass="pgr">
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#c0c0c0" />
                                        <RowStyle VerticalAlign="Top" BackColor="#E0DEDE" />
                                        <Columns>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3" style="height: 50px;">
                                <asp:Button ID="btnCostSummary" runat="server" Visible="false" Text="Cost Summary Report"
                                    CssClass="adminButton" OnClick="btnCostSummary_Click" Style="width: 212px;" />
                                <asp:Button ID="btnCostSummaryExp" runat="server" Text="Export and Send Mail" CssClass="adminButton"
                                    OnClick="btnCostSummaryExp_Click" Style="width: 152px;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr>
                        <td>
                            <asp:Literal ID="ltCostSum" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
