<%@ Page Title="Manage Information Request" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="ManageInformationRequest.aspx.cs" Inherits="ISCS.Admin.ManageInformationRequest"
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
                Manage Information Request</h2>
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
                                                        <asp:ListItem Text="ServiceType" Value="ServiceType"></asp:ListItem>
                                                        <asp:ListItem Text="Name" Value="Name"></asp:ListItem>
                                                        <asp:ListItem Text="Address" Value="Address"></asp:ListItem>
                                                        <asp:ListItem Text="Phone" Value="Phone"></asp:ListItem>
                                                        <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
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
                                <span style="padding-top: 10px;"><a href="ManageInformationRequest.aspx">View All</a></span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div>
                                    <asp:GridView ID="gridInfoReq" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                        Width="100%" GridLines="None" AllowPaging="true" PageSize="25" OnRowDataBound="gridInfoReq_RowDataBound"
                                        OnPageIndexChanging="gridInfoReq_PageIndexChanging" OnRowCommand="gridInfoReq_RowCommand"
                                        PagerStyle-CssClass="pgr">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkName" CommandName="sortName" Text="Name" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" Text='<%# TruncateValue((string)Eval("Name"),20)%>' ToolTip='<%#Eval("Name") %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkAddress" CommandName="sortAddress" Text="Address" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" Text='<%# TruncateValue((string)Eval("Address"),20)%>'
                                                        ToolTip='<%# Eval("Address")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkPhone" CommandName="sortPhone" Text="Phone" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhone" Text='<%# TruncateValue((string)Eval("Phone"),20)%>' ToolTip='<%# Eval("Phone")%>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkEmail" CommandName="sortEmail" Text="Email" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" Text='<%# TruncateValue((string)Eval("Email"),20)%>' ToolTip='<%# Eval("Email")%>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkServiceType" CommandName="sortServiceType" Text="Service Type"
                                                        runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblServiceType" Text='<%# TruncateValue((string)Eval("ServiceType"),20)%>'
                                                        ToolTip='<%# Eval("ServiceType")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Replied" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReplyStat" runat="server"></asp:Label>
                                                    <asp:Label ID="lblReply" runat="server" Text='<%# Eval("Reply") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="110px" HeaderText="Manage" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnReply" CommandName="replymail" OnClick="btnReply_Click" CssClass="gridbutton"
                                                        runat="server" Text="Reply" />
                                                    <asp:ImageButton ID="btnEditUser" runat="server" PostBackUrl="~/Admin/ViewInformationRequest.aspx?mode=update"
                                                        CommandArgument='<%# Eval("Id")%>' ImageUrl="../Images/view_icon.gif" OnClick="btnEditUser_Click"
                                                        ToolTip="Edit" Width="16px" />
                                                    <asp:ImageButton ID="btnDeleteInfoReq" runat="server" Width="16px" OnClientClick="return confirm('Are you sure you want to delete ?')"
                                                        CommandArgument='<%# Eval("Id")%>' ImageUrl="../images/delete.gif" OnClick="btnDeleteInfoReq_Click"
                                                        ToolTip="Delete" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                    <asp:HiddenField ID="hidFInfoReqid" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div id="divReply" class="mGrid_Form" runat="server">
                                    <hr />
                                    <table>
                                        <tr>
                                            <td style="width: 150px;">
                                                To :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblToMailId" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Subject :</label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                                                &nbsp;<asp:RequiredFieldValidator ID="reqSubject" runat="server" ControlToValidate="txtSubject"
                                                    ValidationGroup="reply" ErrorMessage="Please enter subject"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Content :
                                            </td>
                                            <td align="left">
                                                <textarea id="txtareaMailBody" runat="server" cols="30" rows="4"></textarea>
                                                <asp:RequiredFieldValidator ID="reqMailBody" runat="server" ValidationGroup="reply"
                                                    ControlToValidate="txtareaMailBody" ErrorMessage="Please enter mail content"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSend" ValidationGroup="reply" CssClass="adminButton" runat="server"
                                                    Text="Send" OnClick="btnSend_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
