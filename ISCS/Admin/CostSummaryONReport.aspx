<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="CostSummaryONReport.aspx.cs" Inherits="ISCS.Admin.CostSummaryONReport"
    Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" language="Javascript">
        function validateOrderNo() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_txtOrderNo').value == '') {
                alert('Please enter Order Number');
                return false;
            }
            openNewWin('CostSummaryReport.aspx?on=' + document.getElementById('ctl00_ContentPlaceHolder1_txtOrderNo').value)
            return false;
        }
        function openNewWin(url) {
            var x = window.open(url, 'mynewwin');
            x.focus();

        } 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox" style="width: 800px;">
            <h2>
                Cost Summary Report</h2>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <h3>
                                    Cost Summary Report</h3>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Order No :</label><asp:TextBox ID="txtOrderNo" MaxLength="30" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="3" style="height: 50px;">
                                <asp:Button ID="btnCostSummary" runat="server" Text="Cost Summary Report" CssClass="adminButton"
                                    OnClientClick="return validateOrderNo();" OnClick="btnCostSummary_Click" Style="width: 212px;" />
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
                            <asp:Literal ID="ltCostSum" Visible="false" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
