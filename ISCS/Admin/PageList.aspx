<%@ Page Title="ISCS - User Pages" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="PageList.aspx.cs" Inherits="ISCS.Admin.PageList"
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
                Content Page List
            </h2>
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
                                                        <asp:ListItem Text="PageTitle" Value="PageTitle"></asp:ListItem>
                                                        <asp:ListItem Text="PageName" Value="PageName"></asp:ListItem>
                                                        <asp:ListItem Text="MetaKey" Value="MetaKey"></asp:ListItem>
                                                        <asp:ListItem Text="MetaDescription" Value="MetaDescription"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:TextBox ID="txtKeyWords" onfocus="javascript:searchkeytextblank(this)" onblur="javascript:searchkeytextfill(this)"
                                                        Width="190px" Text="Keywords" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;<asp:Button ID="btnSearch" CssClass="adminButton" runat="server" Text="Search"
                                                        OnClick="btnSearch_Click" />
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
                            <td colspan="10">
                                <span style="padding-top: 10px;"><a href="PageList.aspx">View All Pages </a></span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div>
                                    <asp:GridView ID="gridPages" runat="server" AutoGenerateColumns="false" OnRowCommand="gridPages_RowCommand"
                                        GridLines="None" AllowPaging="true" Width="100%" PageSize="25" CssClass="mGrid dataList"
                                        OnPageIndexChanging="gridPages_PageIndexChanging" OnRowDataBound="gridPages_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkPageTitle" CommandName="sortPageTitle" Text="Page Title" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPageTitle" Text='<%# Eval("PageTitle") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkPageName" CommandName="sortPageName" Text="Page Name" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPageName" Text='<%# Eval("PageName") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkMetaKey" CommandName="sortMetaKey" Text="Meta Key" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMetaKey" Text='<%# Eval("MetaKey") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkMetaDescription" CommandName="sortMetaDescription" Text="Meta Description"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMetaDescription" Text='<%# Eval("MetaDescription") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgBtnEdit" Width="16px" CommandArgument='<%# Eval("PageId") %>'
                                                        CommandName="edit" ImageUrl="~/Images/edit.gif" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
