<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="StateCodeLookUp.aspx.cs" Inherits="ISCS.Admin.StateCodeLookUp" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                State Code List</h2>
            <div class="whiteBox userListPan">
                <table width="100%">
                    <tbody>
                        <tr>
                            <td class="fieldSpaceTop">
                            </td>
                            <td align="right">
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div>
                                    <asp:GridView ID="gridUTypeCode" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                        Width="100%" GridLines="None" AllowPaging="true" PageSize="25" AllowSorting="true"
                                        OnPageIndexChanging="gridFeedback_PageIndexChanging" OnRowCommand="gridUTypeCode_RowCommand"
                                        PagerStyle-CssClass="pgr">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkCode" CommandName="sortCode" Text="Code" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCode" Text='<%# Eval("Code")%>' ToolTip='<%# Eval("Code")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="30%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkAbbreviation" CommandName="sortAbbreviation" Text="Abbr" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAbbreviation" Text='<%# Eval("Abbreviation")%>' ToolTip='<%# Eval("Abbreviation") %>'
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="30%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="lnkName" CommandName="sortName" Text="State Name" runat="server"></asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" Text='<%# Eval("Name")%>' ToolTip='<%# Eval("Name") %>' runat="server"></asp:Label>
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
                                <asp:Label ID="lblMsg" CssClass="submitMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
