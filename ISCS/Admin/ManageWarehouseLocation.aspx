<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ManageWarehouseLocation.aspx.cs" Inherits="ISCS.ManageWarehouseLocation"
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
        .style1
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Manage Warehouse Location</h2>
            <div class="whiteBox userListPan">
                <table width="100%">
                    <tbody>
                        <tr>
                            <td class="style1">
                            </td>
                            <td align="right" class="style1">
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
                                                    <asp:DropDownList ID="drpSearchCol" runat="server">
                                                        <asp:ListItem Text="Select Search Type" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Company Name" Value="CompanyName"></asp:ListItem>
                                                        <asp:ListItem Text="City" Value="City"></asp:ListItem>
                                                        <asp:ListItem Text="State Name" Value="StateName"></asp:ListItem>
                                                        <asp:ListItem Text="Contact Name" Value="ContactName"></asp:ListItem>
                                                        <asp:ListItem Text="Contact Phone" Value="ContactPhone"></asp:ListItem>
                                                        <asp:ListItem Text="Contact Email" Value="ContactEmail"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:TextBox ID="txtSearchKey" onfocus="javascript:searchkeytextblank(this)" onblur="javascript:searchkeytextfill(this)"
                                                        Width="190px" Text="Keywords" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:Button ID="btnSearch" CssClass="adminButton" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;
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
                                <span style="padding-top: 10px;"><a href="ManageWarehouseLocation.aspx">View All</a></span>
                            </td>
                            <td align="right">
                                <a href="AddEditWarehouseLocation.aspx">Add New Location</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div>
                                    <asp:GridView ID="gridWHLocation" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                        Width="100%" GridLines="None" AllowPaging="true" PageSize="25" AllowSorting="true"
                                        OnRowDataBound="gridWHLocation_RowDataBound" OnPageIndexChanging="gridWHLocation_PageIndexChanging"
                                        OnRowCommand="gridWHLocation_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkCompanyName" CommandName="sortCompanyName" Text="Company Name"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyName" Text='<%# TruncateValue((string)Eval("CompanyName"),14)%>'
                                                        ToolTip='<%# Eval("CompanyName")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkCity" CommandName="sortCity" Text="City" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCity" Text='<%# TruncateValue((string)Eval("City"),10)%>' ToolTip='<%# Eval("City") %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkStateName" CommandName="sortStateName" Text="State Name" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStateName" Text='<%# TruncateValue((string)Eval("StateName"),10)%>'
                                                        ToolTip='<%# Eval("StateName")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkContactName" CommandName="sortContactName" Text="Contact Name"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactName" Text='<%# TruncateValue((string)Eval("ContactName"),14)%>'
                                                        ToolTip='<%# Eval("ContactName")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkContactPhone" CommandName="sortContactPhone" Text="Contact Phone"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactPhone" Text='<%# TruncateValue((string)Eval("ContactPhone"),12)%>'
                                                        ToolTip='<%# Eval("ContactPhone")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkContactEmail" CommandName="sortContactEmail" Text="Contact Email"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactEmail" Text='<%# TruncateValue((string)Eval("ContactEmail"),15)%>'
                                                        ToolTip='<%# Eval("ContactEmail")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditWHLocation" runat="server" PostBackUrl="~/Admin/AddEditWarehouseLocation.aspx"
                                                        CommandArgument='<%# Eval("Id")%>' ImageUrl="../Images/edit.gif" OnClick="btnEditWHLocation_Click"
                                                        ToolTip="Edit" Width="16px" />
                                                    <asp:ImageButton ID="btnDeleteWHLocation" runat="server" Width="16px" OnClientClick="return confirm('Are you sure you want to delete ?')"
                                                        CommandArgument='<%# Eval("Id")%>' ImageUrl="../images/delete.gif" OnClick="btnDeleteWHLocations_Click"
                                                        ToolTip="Delete" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:HiddenField ID="hidWHLocationId" runat="server" />
                                <asp:Label ID="lblMsg" ForeColor="Red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
