<%@ Page Title="Manage Feedback" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master"
    Theme="Admin" AutoEventWireup="true" CodeBehind="ManageFeedback.aspx.cs" Inherits="ISCS.Admin.ManageFeedback" %>

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
                Manage Feedback</h2>
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
                                                        <asp:ListItem Text="Name" Value="Name"></asp:ListItem>
                                                        <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                                                        <asp:ListItem Text="CommentType" Value="CommentType"></asp:ListItem>
                                                        <asp:ListItem Text="CommentOn" Value="CommentOn"></asp:ListItem>
                                                        <asp:ListItem Text="Comment" Value="Comment"></asp:ListItem>
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
                            <td colspan="10">
                                <span style="padding-top: 10px;"><a href="ManageFeedback.aspx">View All</a></span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div>
                                    <asp:GridView ID="gridFeedback" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                        Width="100%" GridLines="None" AllowPaging="true" PageSize="25" AllowSorting="true"
                                        OnRowDataBound="gridFeedback_RowDataBound" OnPageIndexChanging="gridFeedback_PageIndexChanging"
                                        OnRowCommand="gridFeedback_RowCommand" PagerStyle-CssClass="pgr">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkName" CommandName="sortName" Text="Name" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" Text='<%# TruncateValue((string)Eval("Name"),10)%>' ToolTip='<%# Eval("Name")%>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkEmail" CommandName="sortEmail" Text="Email" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" Text='<%# TruncateValue((string)Eval("Email"),10)%>' ToolTip='<%# Eval("Email") %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkCommentType" CommandName="sortCommentType" Text="Comment Type"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCommentType" Text='<%# Eval("CommentType")%>' ToolTip='<%# Eval("CommentType")%>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkCommentOn" CommandName="sortCommentOn" Text="Comment On" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCommentOn" Text='<%# TruncateValue((string)Eval("CommentOn"),10)%>'
                                                        ToolTip='<%# Eval("CommentOn")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkComment" CommandName="sortComment" Text="Comment" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComment" Text='<%# TruncateValue((string)Eval("Comment"),18)%>'
                                                        ToolTip='<%# Eval("Comment")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Priority" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPriority" runat="server"></asp:Label>
                                                    <asp:Label ID="lblIsPriority" Text='<%#Eval("IsPriority") %>' Visible="false" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Active" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="drpActive" AutoPostBack="true" OnSelectedIndexChanged="drpIsActive_SelectedIndexChanged"
                                                        runat="server">
                                                        <asp:ListItem Text="Active" Value="True"></asp:ListItem>
                                                        <asp:ListItem Text="DeActive" Value="False"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblActive" runat="server" Text='<%# Eval("IsActive") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditUser" runat="server" PostBackUrl="~/Admin/ViewFeedback.aspx?mode=update"
                                                        CommandArgument='<%# Eval("Id")%>' ImageUrl="../Images/view_icon.gif" OnClick="btnEditUser_Click"
                                                        ToolTip="Edit" Width="16px" />
                                                    <asp:ImageButton ID="btnDeleteFeedback" runat="server" Width="16px" OnClientClick="return confirm('Are you sure you want to delete ?')"
                                                        CommandArgument='<%# Eval("Id")%>' ImageUrl="../images/delete.gif" OnClick="btnDeleteFeedback_Click"
                                                        ToolTip="Delete" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                    <asp:HiddenField ID="hidFFeedbackid" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
