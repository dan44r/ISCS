<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Shipment_ListingUser.aspx.cs" Inherits="ISCS.Admin.Shipment_ListingUser"
    Theme="Admin" %>

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
    </script>

    <style type="text/css">
        .dataList td
        {
            padding: 5px 0 0 0px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox" style="width: 800px;">
            <h2>
                Shipment Listing</h2>
            <div class="whiteBox userListPan">
                <table width="100%">
                    <tbody>
                        <tr>
                            <td class="fieldSpaceTop">
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldSpaceTop" colspan="2">
                            </td>
                        </tr>
                        <tr style="height: 5px;">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="width: 790px; overflow-x: scroll; overflow-y: hidden;">
                                    <asp:GridView ID="gridUsers" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                        Width="100%" AllowPaging="True" PageSize="10" AllowSorting="true" OnPageIndexChanging="gridUsers_PageIndexChanging"
                                        OnRowCommand="gridUsers_RowCommand" GridLines="None" CellPadding="1" CellSpacing="1"
                                        PagerStyle-CssClass="pgr" OnRowDataBound="gridUsers_RowDataBound">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <RowStyle VerticalAlign="Top" BackColor="#E0DEDE" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                ItemStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkShipDate" CommandName="sortShipDate" Text="Ship Date" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShipDate" Text='<%# Eval("ship_date")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnktrack" CommandName="sorttrack" Text="Tracking No." runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnktrackclick" Text='<%# Eval("tracking_no")%>' runat="server"
                                                        CommandArgument='<%# Eval("tracking_no")%>' OnClick="lnktrackclick_Click" PostBackUrl="~/Admin/Shipment_View.aspx"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkPTno" CommandName="sortPTno" Text="PT#" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPTno" Text='<%# Eval("ShipToConsigneeRefNumber")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Shipping" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <font style="font-weight: bold;">From:&nbsp;</font><asp:Label ID="lblshipping" Text='<%# Eval("ShipFromCompany")%>'
                                                        runat="server"></asp:Label>
                                                    <font style="font-weight: bold;">To: &nbsp;</font><asp:Label ID="lblshipping1" Text='<%# Eval("ShipToCompany")%>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkStatus" CommandName="sortStatus" Text="Status" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" Text='<%# Eval("StatusName") %>' runat="server"></asp:Label>
                                                    <asp:Label ID="lblstatus1" Text='<%# Eval("status_date")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pc" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpc" Text='<%# Eval("pieces")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Weight" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblweight" Text='<%# Eval("actual_weight")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkcarrier" CommandName="sortcarrier" Text="Carrier" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcarrier" Text='<%# Eval("GLSCarrierName")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkPOno" CommandName="sortPOno" Text="P0#" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPOno" Text='<%# Eval("ShipFromRefNumber")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkProNo" CommandName="sortProNo" Text="Pro No." runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblprono" Text='<%# GetProSmall(Eval("ProNumber").ToString())%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkLastUpdated" CommandName="sortLastUpdated" Text="Last Updated"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbllastupdated" Text='<%# Eval("DateLastUpdated")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                    <asp:Label ID="lblCarrierid" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnTrackingNumber" runat="server" />
                                    <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
