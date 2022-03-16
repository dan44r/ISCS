<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarriersPop.aspx.cs" Inherits="ISCS.Admin.CarriersPop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" language="javascript">
        function SelectCarrier(imgId) {

            var arrImgId;
            arrImgId = imgId.split("_");

            var hidvalue = document.getElementById('hidType');
            if (document.getElementById('hidType').value == 1) {

                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtPickupCarrier.value = document.getElementById("gridCarriers_" + arrImgId[1] + "_lblCompanyName").childNodes[0].nodeValue;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_hdCarrierID.value = document.getElementById("gridCarriers_" + arrImgId[1] + "_hidCarrierID").value;
                parent.parent.GB_hide();
            }
            else if (document.getElementById('hidType').value == 2) {

                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtIntermediateCarrier.value = document.getElementById("gridCarriers_" + arrImgId[1] + "_lblCompanyName").childNodes[0].nodeValue;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_hdIntermediateCarrierID.value = document.getElementById("gridCarriers_" + arrImgId[1] + "_hidCarrierID").value;
                parent.parent.GB_hide();
            }
            else if (document.getElementById('hidType').value == 3) {

                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtDeliveryCarrier.value = document.getElementById("gridCarriers_" + arrImgId[1] + "_lblCompanyName").childNodes[0].nodeValue;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_hdDeliveryCarrierID.value = document.getElementById("gridCarriers_" + arrImgId[1] + "_hidCarrierID").value;
                parent.parent.GB_hide();

            }
            else if (document.getElementById('hidType').value == 4) {

                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_txtOtherCarrier.value = document.getElementById("gridCarriers_" + arrImgId[1] + "_lblCompanyName").childNodes[0].nodeValue;
                window.parent.parent.document.aspnetForm.ctl00_ContentPlaceHolder1_hdOtherCarrierID.value = document.getElementById("gridCarriers_" + arrImgId[1] + "_hidCarrierID").value;
                parent.parent.GB_hide();
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridCarriers" runat="server" ShowHeader="false" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td valign="top">
                                    <img src="images/Select.jpeg" alt="Select" onclick="javascript:SelectCarrier(this.id)"
                                        id="imgSelect" runat="server" />
                                    <br />
                                    <br />
                                    <asp:ImageButton ID="imgBtnDelLocation" ImageUrl="~/Images/delete.gif" OnClientClick="return confirm('Are you sure you want to delete ?')"
                                        OnClick="imgBtnDelLocation_Click" CommandArgument='<%# Eval("Id") %>' ToolTip="Delete"
                                        Width="16px" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CarrierName") %>'></asp:Label><br />
                                    <asp:HiddenField ID="hidCarrierID" runat="server" Value='<%# Eval("Id") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hidType" runat="server" />
    </div>
    </form>
</body>
</html>
