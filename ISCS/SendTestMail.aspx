<%@ Page Language="C#" Title="Test Mail" AutoEventWireup="true" CodeBehind="SendTestMail.aspx.cs" Inherits="ISCS.SendTestMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div id="">
        <table>
            <tr>
                <td>
                    Mail To
                </td>
                <td>
                    <asp:TextBox ID="txtMailTo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Mail Subject
                </td>
                <td>
                    <asp:TextBox ID="txtMailSub" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Mail Body
                </td>
                <td>
                    <asp:TextBox ID="txtMailBody" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
               
                <td>
                     <asp:Button ID="btnSendMail" runat="server" Text="Send Mail" 
                         onclick="btnSendMail_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </td>               
               
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
