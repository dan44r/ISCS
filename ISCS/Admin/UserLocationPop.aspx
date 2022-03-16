<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLocationPop.aspx.cs"
    Theme="Admin" Inherits="ISCS.Admin.UserLocationPop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" language="javascript">
        function SelectLocation(imgId) {

            var arrImgId;
            arrImgId = imgId.split("_");

            var hidvalue = document.getElementById('hidType');
            if (document.getElementById('hidType').value == 1) {
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtShipFromCompany.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblCompanyName").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtFromAddress.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblAddress").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtFromCity.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblCity").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtFromPostalCode.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblPostalCode").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtFromContact.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblContactName").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtFromPhone.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblContactPhone").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtFromFax.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblFax").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtFromEmail.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblEmail").innerHTML;
                var input = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblStateId").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_drpFromState.value = input;
                var input2 = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblCountryId").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_drpFromCountry.value = input2;

                parent.parent.GB_hide();
            }
            else {
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtShipToCompany.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblCompanyName").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtToAddress.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblAddress").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtToCity.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblCity").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtToPostalCode.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblPostalCode").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtToContact.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblContactName").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtToPhone.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblContactPhone").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtToFax.value = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblFax").innerHTML;
                window.parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_lblWAreHoseLocationId').innerHTML = "0";
                window.parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_HidWarehouseid').value = "0";
                var input = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblStateId").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_drpToState.value = input;
                var input2 = document.getElementById("gridUserLocations_" + arrImgId[1] + "_lblCountryId").innerHTML;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_drpToCountry.value = input2;
                parent.parent.GB_hide();
            }
        }
    </script>

    <style type="text/css">
        .adminButton
        {
            background-color: #14aa14;
            border: medium none;
            color: #FFFFFF;
            cursor: pointer;
            font-family: tahoma,Helvetica,sans-serif;
            font-size: 11px;
            font-size-adjust: none;
            font-stretch: normal;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            height: 25px;
            vertical-align: middle;
            width: 67px;
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <script type="text/javascript" src="../Include/autocomplete/jquery.js"></script>

        <script type='text/javascript' src='../Include/autocomplete/jquery.autocomplete.js'></script>

        <link rel="stylesheet" type="text/css" href="../Include/autocomplete/jquery.autocomplete.css" />

        <script type="text/javascript">
function findValue(li) {
	if( li == null ) return alert("No match!");

	// if coming from an AJAX call, let's use the CityId as the value
	if( !!li.extra ) var sValue = li.extra[0];

	// otherwise, let's just display the value in the text box
	else var sValue = li.selectValue;

//	alert("The value you selected was: " + sValue);

document.getElementById('btnSearch').click();
}

function selectItem(li) {
	findValue(li);
}

function formatItem(row) {
	return row[0] + " (id: " + row[1] + ")";
}



function lookupLocal(){
    var oSuggest = $("#txtCompany")[0].autocompleter;
	oSuggest.findValue();

	return false;
}
$(document).ready(function() {


$("#txtCompany").autocompleteArray(
		[
		    <%=Session["CompanyArr"] %>
		    ],
		{
		    delay: 10,
		    minChars: 1,
		    matchSubset: 1,
		    onItemSelect: selectItem,
		    onFindValue: findValue,
		    autoFill: false,
		    maxItemsToShow: 10
		}
	);
});

        </script>

        <br />
        &nbsp;&nbsp;Search by Company Name&nbsp;&nbsp;<asp:TextBox ID="txtCompany" runat="server"
            Style="border: solid 1px black; width: 120px"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="adminButton" OnClick="btnSearch_Click" />&nbsp;&nbsp;
        <asp:Button ID="btnListAll" runat="server" Text="List All" CssClass="adminButton"
            OnClick="btnListAll_Click" />
        <asp:GridView CssClass="mGrid dataList" ID="gridUserLocations" runat="server" ShowHeader="false"
            AutoGenerateColumns="false" OnRowDataBound="gridUserLocations_RowDataBound">
            <AlternatingRowStyle BackColor="#EFEFEF" />
            <Columns>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td valign="top">
                                    <img src="images/Select.jpeg" alt="Select" onclick="javascript:SelectLocation(this.id)"
                                        id="imgSelect" runat="server" />
                                    <br />
                                    <br />
                                    <asp:ImageButton ID="imgBtnDelLocation" ImageUrl="~/Images/delete.gif" OnClientClick="return confirm('Are you sure you want to delete ?')"
                                        OnClick="imgBtnDelLocation_Click" CommandArgument='<%# Eval("LocationId") %>'
                                        ToolTip="Delete" Width="16px" runat="server" />
                                </td>
                                <td>
                                    <asp:Label Style="font-weight: bold; cursor: pointer" ID="lblCompanyName" ToolTip="Click to select location"
                                        runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label><br />
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label><br />
                                    <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblStateName" runat="server" Text='<%# Eval("StateName") %>'></asp:Label>
                                    <asp:Label ID="lblPostalCode" runat="server" Text='<%# Eval("PostalCode") %>'></asp:Label><br />
                                    <asp:Label ID="lblCountryName" runat="server" Text='<%# Eval("CountryName") %>'></asp:Label>
                                    <asp:Label Style="display: none;" ID="lblStateId" runat="server" Text='<%# Eval("StateId") %>'></asp:Label>
                                    <asp:Label ID="lblCountryId" Style="display: none;" runat="server" Text='<%# Eval("CountryId") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblContactHeadText" Style="font-weight: bold" runat="server" Text="Contact :"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("ContactName") %>'></asp:Label><br />
                                    <asp:Label ID="lblContactPhone" runat="server" Text='<%# Eval("ContactPhone") %>'></asp:Label><br />
                                    <asp:Label ID="lblFax" runat="server" Text='<%# Eval("ContactFax") %>'></asp:Label><br />
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("ContactEmail") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblHeadTextAlso" Style="font-weight: bold" runat="server" Text="Also Notify :"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblAlsoNotifyName" runat="server" Text='<%# "Name: " + Eval("AlsoNotifyName") %>'></asp:Label>
                                    <asp:Label ID="lblAlsoNotifyPhone" runat="server" Text='<%# "Phone: " + Eval("AlsoNotifyPhone") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMsg" ForeColor="Red" runat="server"></asp:Label>
        <asp:HiddenField ID="hidType" runat="server" />
    </div>
    </form>
</body>
</html>
