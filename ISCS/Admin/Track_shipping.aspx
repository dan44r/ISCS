<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Track_shipping.aspx.cs" Inherits="ISCS.Admin.Track_shipping" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" language="Javascript">
    function ValidateTrackNo() {
        if (document.getElementById('ctl00_ContentPlaceHolder1_txtTrackingNo').value == '') {
            alert('Please enter Tracking Number');
            return false;
        }
        return true;
    }
    function ValidateTrackNo1() {
        if (document.getElementById('ctl00_ContentPlaceHolder1_txtPONo').value == '') {
            alert('Please enter PO Number');
            return false;
        }
        return true;
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                To begin package tracking, please select a search method and click "Search":</h2>
            <div class="whiteBox" style="height: 250px">
                <table width="100%">
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td align="center" valign="top" style="border-collapse: collapse; border: solid 1px black;
                            width: 30%">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center">
                                        <h3 style="background-color: #D1CDC6; color: #000000;">
                                            Method 1.</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        Input Tracking Number
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:TextBox ID="txtTrackingNo" runat="server" Style="width: 80px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnSearch1" runat="server" Text="Search" CssClass="adminButton" OnClick="btnSearch1_Click"
                                            OnClientClick="return ValidateTrackNo();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 10%">
                        </td>
                        <td align="center" valign="top" style="border-collapse: collapse; border: solid 1px black;
                            width: 30%">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center">
                                        <h3 style="background-color: #585858; color: #FFFFFF;">
                                            Method 2.</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        Search all Shipments<br />
                                        sent in last
                                        <asp:DropDownList ID="dpTimeframe" runat="server" Style="width: 80px !important">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnSearch2" runat="server" Text="Search" CssClass="adminButton" OnClick="btnSearch2_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                        </td>
                        <td align="center" valign="top" style="border-collapse: collapse; border: solid 1px black;
                            width: 30%">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center">
                                        <h3 style="background-color: #D1CDC6; color: #000000;">
                                            Method 3.</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        Input PO Number
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:TextBox ID="txtPONo" runat="server" Style="width: 80px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnSearchPO" runat="server" Text="Search" CssClass="adminButton"
                                            OnClick="btnSearchPO_Click" OnClientClick="return ValidateTrackNo1();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 10%">
                        </td>
                        <td align="center" valign="top" style="border-collapse: collapse; border: solid 1px black;
                            width: 30%">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center">
                                        <h3 style="background-color: #585858; color: #FFFFFF;">
                                            Method 4.</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        Search all Shipment by PO<br />
                                        sent in last
                                        <asp:DropDownList ID="dpTimeframe1" runat="server" Style="width: 80px !important">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnSearchAllByPO" runat="server" Text="Search" CssClass="adminButton"
                                            OnClick="btnSearchAllByPO_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnTrackingBillId" runat="server" />
    <asp:HiddenField ID="hdnTrackingNumber" runat="server" />
    <asp:HiddenField ID="hdnAccountCodeId" runat="server" />
    <asp:HiddenField ID="hdnShippedDates" runat="server" />
</asp:Content>
