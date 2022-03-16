<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="World_Events.aspx.cs" Inherits="ISCS.WorldEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:XmlDataSource ID="XmlDataSourceFeedOne" runat="server" DataFile="http://rss.cnn.com/rss/cnn_topstories.rss"
        XPath="rss/channel/item"></asp:XmlDataSource>
    <asp:XmlDataSource ID="XmlDataSourceFeedTwo" runat="server" DataFile="http://rss.cnn.com/rss/edition_business.rss"
        XPath="rss/channel/item"></asp:XmlDataSource>
    <asp:XmlDataSource ID="XmlDataSourceFeedThree" runat="server" DataFile="http://rss.cnn.com/rss/edition_connecttheworld.rss"
        XPath="rss/channel/item"></asp:XmlDataSource>
    <div id="content">
        <div class="inr-cont feedback">
            <table cellpadding="0" cellspacing="0" border="0" align="center" width="100%">
                <tr>
                    <td valign="top" style="padding: 0px 20px 0px 0px; width: 45%">
                        <h2>
                            Industry Trends</h2>
                        <asp:DataList ID="dlFeedOne" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow"
                            RepeatColumns="8">
                            <ItemTemplate>
                                <%# XPath("title") %><br />
                                <br />
                                <%# XPath("description") %><br />
                                <br />
                                <a href='<%# XPath("link") %>' target="_blank">[...]</a><br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td valign="top" style="padding: 0px 20px 0px 0px; width: 10%">
                    </td>
                    <td valign="top" style="width: 45%">
                        <h2>
                            Media Coverage</h2>
                        <asp:DataList ID="dlFeedThree" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow"
                            RepeatColumns="8">
                            <ItemTemplate>
                                <%# XPath("title") %><br />
                                <br />
                                <%# XPath("description").ToString().Replace("<![CDATA[","").Replace("]]>","") %><br />
                                <br />
                                <a href='<%# XPath("link") %>' target="_blank">[...]</a><br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
