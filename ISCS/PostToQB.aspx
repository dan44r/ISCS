<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostToQB.aspx.cs" Inherits="ISCS.PostToQB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnRetuen" runat="server" CausesValidation="false" Text="Return"
            CssClass="adminButton" OnClick="btnRetuen_Click" />
        <asp:Button ID="btnAdd" runat="server" Text="Add To QB" CssClass="adminButton" OnClick="btnAdd_Click" />
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
