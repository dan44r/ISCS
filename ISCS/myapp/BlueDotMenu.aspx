<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlueDotMenu.aspx.cs" Inherits="ISCS.myapp.BlueDotMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://appcenter.intuit.com/Content/IA/intuit.ipp.anywhere.js"></script>
	<script>intuit.ipp.anywhere.setup({
	    menuProxy: 'http://example.com/myapp/BlueDotMenu',
	    grantUrl: 'http://example.com/myapp/RequestOAuthToken'
	});</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ipp:blueDot></ipp:blueDot> 
    </div>
    </form>
</body>
</html>
