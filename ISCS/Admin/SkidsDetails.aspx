﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SkidsDetails.aspx.cs" Inherits="ISCS.Admin.SkidsDetails"
    Theme="Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        /* for gray box */
        var GB_ROOT_DIR = "../include/greybox/";
    </script>

    <script type="text/javascript" src="../Include/ddlevelsfiles/ddlevelsmenu.js">
    </script>

    <!-- script block for gray box -->

    <script type="text/javascript" src="../Include/greybox/AJS.js"></script>

    <script type="text/javascript" src="../Include/greybox/AJS_fx.js"></script>

    <script type="text/javascript" src="../Include/greybox/gb_scripts.js"></script>

    <script type="text/javascript" src="../Include/JS/calendar.js"></script>

    <script type="text/javascript" src="../Include/JS/common.js"></script>

    <link href="../Include/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />

    <script type="text/javascript" src="../Include/greybox/AJS.js">
        insertCode(
    'GB_showFullScreen(caption, url, callback_fn)'
    );
</script>

    <script type="text/javascript" language="javascript">
        function NumericCheck(event) {
            var code = window.event ? event.keyCode : event.which;

            
            if ((code >= 48 && code <= 57) || (code == 8 || code==37 || code==39 || code==46 || code==9)) {
                
                return true;
            }
            else {
                
                return false;
            }
           

        }    
    
    </script>

    <script type="text/javascript" src="../Include/JS/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="rht-cont">
            <div class="serviceBox">
                <h2>
                    Handling Unit & Shipment Items</h2>
                <div class="whiteBox">
                    <asp:Panel ID="Panel1" runat="server">
                        <table>
                            <tr>
                                <td colspan="2">
                                    <b>Handling Unit</b>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label style="color: Red; width: 10px">
                                        *
                                    </label>
                                    Handling Unit Type:
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpHandlingUnitType" Width="147px" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="reqHandUnitType" runat="server" Display="Dynamic"
                                        SetFocusOnError="true" ControlToValidate="drpHandlingUnitType" InitialValue="0"
                                        ErrorMessage="Please select handling unit type"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label style="color: Red; width: 10px">
                                        *
                                    </label>
                                    Length:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLength" onkeypress="return onlyDigits(event,'decno')" MaxLength="5"
                                        runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="reqLangth" runat="server" Display="Dynamic" SetFocusOnError="true"
                                        ControlToValidate="txtLength" ErrorMessage="Please enter length"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label style="color: Red; width: 10px">
                                        *
                                    </label>
                                    Width:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWidth" onkeypress="return onlyDigits(event,'decno')" MaxLength="5"
                                        runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="reqWidth" runat="server" Display="Dynamic" ControlToValidate="txtWidth"
                                        SetFocusOnError="true" ErrorMessage="Please enter width"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label style="color: Red; width: 10px">
                                        *
                                    </label>
                                    Height:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHeight" onkeypress="return onlyDigits(event,'decno')" MaxLength="5"
                                        runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="reqHeight" runat="server" Display="Dynamic" SetFocusOnError="true"
                                        ControlToValidate="txtHeight" ErrorMessage="Please enter height"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trWeight1" runat="server">
                                <td>
                                    <label style="color: Red; width: 10px">
                                        *
                                    </label>
                                    Weight:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWeight" onkeypress="return onlyDigits(event,'decno')" MaxLength="7"
                                        runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="trWeight2" runat="server">
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="reqWeight" runat="server" Display="Dynamic" SetFocusOnError="true"
                                        ControlToValidate="txtWeight" ErrorMessage="Please enter weight"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    HazMat:
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkHazmat" CssClass="checkListShip" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Emergency response phone number:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhone" MaxLength="20" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Class:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtClass" MaxLength="5" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    NMFC Code:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNMFCCode" MaxLength="20" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <label style="color: Red; width: 10px">
                                        *
                                    </label>
                                    Commodity Description:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCommoDesc" MaxLength="255" runat="server" TextMode="MultiLine"
                                        Width="400px" Height="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="reqCommoDesc" runat="server" Display="Dynamic" SetFocusOnError="true"
                                        ControlToValidate="txtCommoDesc" ErrorMessage="Please Commodity Description"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <table>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <b>Shipment Items</b>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr id="trPackQnty1" runat="server">
                                <td style="width: 213px">
                                    <label style="color: Red; width: 10px">
                                        *
                                    </label>
                                    Handling Unit Quantity:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPackageQuantity" MaxLength="5" onkeypress="return onlyDigits(event,'decno')"
                                        runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="trPackQnty2" runat="server">
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="reqPackageQuantity" ControlToValidate="txtPackageQuantity"
                                        SetFocusOnError="true" runat="server" Display="Dynamic" ErrorMessage="Please enter package quantity"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td>
                                    <label style="color: Red; width: 10px">
                                        *
                                    </label>
                                    Package Type:
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpPackageType" Width="147px" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td>
                                    <label style="color: Red; width: 10px">
                                        *
                                    </label>
                                    Product Description:
                                </td>
                                <td>
                                    <textarea id="txtareaProdDescription" cols="20" rows="2" maxlength="255" runat="server"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Part Number (s):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPartNumber" MaxLength="50" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Purchase Order Number:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPONumber" MaxLength="50" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Lot Number:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLotNumber" MaxLength="50" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Declared Value:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeclaredValue" MaxLength="12" onkeypress="return onlyDigits(event,'decOK')"
                                        runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <table>
                        <tr>
                            <td style="width: 213px">
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" CssClass="BtnCommon" Width="70px" Text="Done"
                                    OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnAddMore" runat="server" CssClass="BtnCommon" Width="70px" Text="Add More"
                                    OnClick="btnAddMore_Click" />
                                <asp:Button ID="btnUpdate" runat="server" CssClass="BtnCommon" Width="90px" Text="Update"
                                    OnClick="btnUpdate_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblMsg" ForeColor="Red" CssClass="submitMsg" runat="server"></asp:Label>
                                <asp:HiddenField ID="hidSkid" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
