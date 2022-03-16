<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ManagePackageTypes.aspx.cs" Inherits="ISCS.Admin.ManagePackageTypes"
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Manage Package Types</h2>
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
                                                    <asp:DropDownList ID="drpSearchCol" runat="server">
                                                        <asp:ListItem Text="Select Search Type" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="PackageType" Value="PackageType"></asp:ListItem>
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
                                <span style="padding-top: 10px;"><a href="ManagePackageTypes.aspx">View All</a></span>
                            </td>
                            <td align="right">
                                <a href="AddEditPackageType.aspx">Add New Package Type</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div>
                                    <asp:GridView ID="gridPackageType" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                        Width="100%" GridLines="None" AllowPaging="true" PageSize="25" OnPageIndexChanging="gridPackageType_PageIndexChanging"
                                        OnRowCommand="gridPackageType_RowCommand" PagerStyle-CssClass="pgr">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkPType" CommandName="sortPackageType" Text="Package Type" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPType" Text='<%# TruncateValue((string)Eval("PackageType"),40)%>'
                                                        ToolTip='<%#Eval("PackageType") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="110px" HeaderText="Manage" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditPackageType" runat="server" PostBackUrl="~/Admin/AddEditPackageType.aspx"
                                                        CommandArgument='<%# Eval("PackageTypeId")%>' ImageUrl="../Images/edit.gif" OnClick="btnEditPackageType_Click"
                                                        ToolTip="Edit" Width="16px" />
                                                    <asp:ImageButton ID="btnDeletePType" runat="server" Width="16px" OnClientClick="return confirm('Are you sure you want to delete ?')"
                                                        CommandArgument='<%# Eval("PackageTypeId")%>' ImageUrl="../images/delete.gif"
                                                        OnClick="btnDeletePType_Click" ToolTip="Delete" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <asp:HiddenField ID="hidPType" runat="server" />
                                <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
