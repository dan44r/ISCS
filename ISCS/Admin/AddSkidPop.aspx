<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSkidPop.aspx.cs" Inherits="ISCS.Admin.AddSkidPop"
    Theme="Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="rht-cont">
            <div class="serviceBox">
                <h2>
                    Handling Unit Information</h2>
                <div class="whiteBox">
                    <table>
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
                                    ControlToValidate="drpHandlingUnitType" InitialValue="0" ErrorMessage="Please select handling unit type"></asp:RequiredFieldValidator>
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
                                <asp:TextBox ID="txtLength" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqLangth" runat="server" Display="Dynamic" ControlToValidate="txtLength"
                                    ErrorMessage="Please enter length"></asp:RequiredFieldValidator>
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
                                <asp:TextBox ID="txtWidth" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqWidth" runat="server" Display="Dynamic" ControlToValidate="txtWidth"
                                    ErrorMessage="Please enter width"></asp:RequiredFieldValidator>
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
                                <asp:TextBox ID="txtHeight" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqHeight" runat="server" Display="Dynamic" ControlToValidate="txtHeight"
                                    ErrorMessage="Please enter height"></asp:RequiredFieldValidator>
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
                                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Class:
                            </td>
                            <td>
                                <asp:TextBox ID="txtClass" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                NMFC Code:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNMFCCode" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Commodity Description:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCommoDesc" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" CssClass="BtnCommon" Width="70px" Text="Submit"
                                    OnClick="btnSubmit_Click" />
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
