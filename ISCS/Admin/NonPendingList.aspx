<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="NonPendingList.aspx.cs" Inherits="ISCS.Admin.NonPendingList" Theme="Admin" %>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                <%=strHeading %></h2>
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
                        <tr>
                            <td class="fieldSpaceTop" colspan="2">
                                <div id="aa">
                                    <table cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="drpSearchCol" runat="server" Visible="false">
                                                        <asp:ListItem Text="Select Search Type" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="FirstName" Value="FirstName"></asp:ListItem>
                                                        <asp:ListItem Text="LastName" Value="LastName"></asp:ListItem>
                                                        <asp:ListItem Text="Company" Value="CompanyName"></asp:ListItem>
                                                        <asp:ListItem Text="Level" Value="UserType"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:TextBox ID="txtSearchKey" onfocus="javascript:searchkeytextblank(this)" onblur="javascript:searchkeytextfill(this)"
                                                        Width="190px" Text="Keywords" Visible="false" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:Button ID="btnSearch" CssClass="adminButton" runat="server" Text="Search" OnClick="btnSearch_Click"
                                                        Visible="false" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 5px;">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="padding-top: 10px;"></span>
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div>
                                    <asp:GridView ID="gridNonPending" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                        Width="100%" AllowPaging="True" PageSize="10" AllowSorting="true" OnRowDataBound="gridNonPending_RowDataBound"
                                        OnPageIndexChanging="gridNonPending_PageIndexChanging" OnRowCommand="gridNonPending_RowCommand"
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
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Pieces">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPackageQuantity" Text='<%# Eval("PackageQuantity")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Weight">
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
                                                    <asp:Label ID="lblWarehouseTypeFlag" Text='<%#Eval("PickupRequestTypeWarehouse") %>'
                                                        Visible="false" runat="server"></asp:Label>
                                                    <asp:Label ID="lblWarehouseType" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href="AirWaybill.aspx?PickupRequestId=<%# Eval("PickupRequestId")%>" title="View">
                                                        <img src="../images/view_icon.gif" /></a>
                                                    <asp:ImageButton ID="btnEditUser" runat="server" PostBackUrl="~/Admin/AddPickupRequest.aspx?mode=update"
                                                        CommandArgument='<%#Eval("PickupRequestId") %>' ImageUrl="../Images/edit.gif"
                                                        OnClick="btnEditUser_Click" ToolTip="Edit" Width="16px" />&nbsp;
                                                    <asp:ImageButton ID="btnDeleteUser" runat="server" OnClientClick="return confirm('Are you sure you want to delete ?')"
                                                        CommandArgument='<%# Eval("PickupRequestId")%>' ImageUrl="../images/delete.gif"
                                                        OnClick="btnDeleteUser_Click" ToolTip="Delete" Width="16px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                    <asp:Label ID="lblUserid" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hidFUserid" runat="server" />
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
