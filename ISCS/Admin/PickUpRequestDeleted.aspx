<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="PickUpRequestDeleted.aspx.cs" Inherits="ISCS.Admin.PickUpRequestDeleted"
    Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Pick up request Deleted</h2>
            <div class="whiteBox userListPan">
                <table width="100%">
                    <tbody>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 120px">
                                Select Type :
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:DropDownList ID="drpStatus" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="adminButton" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="gridDeleted" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                    Width="100%" AllowPaging="True" PageSize="10" AllowSorting="true" OnRowDataBound="gridDeleted_RowDataBound"
                                    OnPageIndexChanging="gridDeleted_PageIndexChanging" OnRowCommand="gridDeleted_RowCommand"
                                    GridLines="None" PagerStyle-CssClass="pgr">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkShipFromDate" CommandName="sortShipFromDate" Text="Ship Date"
                                                    runat="server"></asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipFromDate" runat="server"></asp:Label>
                                                <asp:Label ID="lblShipDate" Visible="false" Text='<%# Eval("ShipFromDate")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkGLSTrackingNumber" CommandName="sortGLSTrackingNumber" Text="Tracking #"
                                                    runat="server"></asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGLSTrackingNumber" Text='<%# Eval("GLSTrackingNumber")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkFromContact" CommandName="sortFromContact" Text="From" runat="server"></asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblFromContact" Text='<%# Eval("FromContact")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkToContact" CommandName="sortToContact" Text="To" runat="server"></asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblToContact" Text='<%# Eval("ToContact")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Pcs">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPackageQuantity" Text='<%# Eval("PackageQuantity")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Wt">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSkidWeight" Text='<%# Eval("SkidWeight")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Carrier">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGLSCarrierName" Text='<%# Eval("GLSCarrierName")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Warehouse">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRequestType" runat="server" Visible="false" Text='<%# Eval("PickupRequestType") %>'></asp:Label>
                                                <asp:Label ID="lblWarehouseTypeFlag" Text='<%#Eval("PickupRequestTypeWarehouse") %>'
                                                    Visible="false" runat="server"></asp:Label>
                                                <asp:Label ID="lblWarehouseType" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
