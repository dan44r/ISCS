<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="AddPickUpRequest.aspx.cs" Inherits="ISCS.Admin.AddPickUpRequest"
    MaintainScrollPositionOnPostback="false" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" language="javascript">
        function SelectPickup() {
            var WinAttr = "resizable=yes,scrollbars,menubar=no,toolbars=no,width=420,height=500 top=2";
            var win1 = window.open("UserLocationPop.aspx?dt=1", "GetLocation", WinAttr);
            win1.focus();
        }

        function SelectDelivery() {
            var WinAttr = "resizable=yes,scrollbars,menubar=no,toolbars=no,width=420,height=500 top=2";
            var win1 = window.open("UserLocationPop.aspx?dt=2", "GetLocation", WinAttr);
            win1.focus();


        }
        function SelectDeliveryWarehouse() {
            var WinAttr = "resizable=yes,scrollbars,menubar=no,toolbars=no,width=420,height=500 top=2";
            var win1 = window.open("UserLocationWarehousePop.aspx?dt=2", "GetLocationWarehouse", WinAttr);
            win1.focus();


        }
        function Openskidpop(reqid) {

            GB_show("Skids Details", "../../admin/SkidsDetails.aspx?pickuprequestid=" + reqid, 430, 780);

        }
        function Openskidpopwh(reqid, skid) {

            GB_show("Skids Details", "../../admin/SkidsDetails.aspx?pickuprequestid=" + reqid + "&skid=" + skid, 430, 780);

        }
        function OpenskidpopChooseWHlist(reqid, skid) {

            GB_show("Skids Details", "../../admin/SkidsDetails.aspx?pickuprequestid=" + reqid + "&skid=" + skid + "&ChooseWHlist=ChooseWHlist", 430, 780);

        }
        function OpenskidpopChooseWHlistwithoutSkid(reqid) {

            GB_show("Skids Details", "../../admin/SkidsDetails.aspx?pickuprequestid=" + reqid + "&ChooseWHlist=ChooseWHlist", 430, 780);

        }
        function OpenShippop(reqid, huid, shipid) {

            GB_show("Shipment Items", "../../admin/SkidsDetails.aspx?sec=ship&pickuprequestid=" + reqid + "&huid=" + huid + "&shipid=" + shipid, 430, 780);


        }

        function OpenHupop(huid) {

            GB_show("Handling Unit", "../../admin/SkidsDetails.aspx?sec=hu&huid=" + huid, 430, 780);


        }

        function OpenAddShippop(reqid, huid) {

            GB_show("Shipment Items", "../../admin/SkidsDetails.aspx?addship=addship&pickuprequestid=" + reqid + "&huid=" + huid, 430, 780);


        }

        function OpenChooseWHlistShipmentItems(reqid, huid) {
            GB_show("Add Shipment Items WHList", "../../admin/ManageShipFromWarehousePop.aspx?skidid=" + huid + "&pickuprequestid=" + reqid, 430, 780);
        }

        function FillRates() {

            var marginval = document.getElementById('ctl00_ContentPlaceHolder1_txtMargin').value;
            if (marginval == '') {
                marginval = 0;
            }
            var tran1 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtTransportCost1').value);
            var tran2 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtTransportCost2').value);
            var tran3 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtTransportCost3').value);
            var tran4 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtTransportCost4').value);
            var tran5 = 0;
            var tran5 = ((tran1 * 1) + (tran2 * 1) + (tran3 * 1) + (tran4 * 1)) * (1 + (marginval * 0.01))
            tran5 = tran5 * 100;
            tran5 = Math.round(tran5);
            tran5 = tran5 / 100;
            document.getElementById('ctl00_ContentPlaceHolder1_txtTransport').value = tran5;

            var assc1 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtAccessorialCost1').value);
            var assc2 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtAccessorialCost2').value);
            var assc3 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtAccessorialCost3').value);
            var assc4 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtAccessorialCost4').value);
            var assc5 = 0;
            var assc5 = ((assc1 * 1) + (assc2 * 1) + (assc3 * 1) + (assc4 * 1)) * (1 + (marginval * 0.01))
            assc5 = assc5 * 100;
            assc5 = Math.round(assc5);
            assc5 = assc5 / 100;
            document.getElementById('ctl00_ContentPlaceHolder1_txtAccessorial').value = assc5;


            var fuel1 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtFuelSurcharge1').value);
            var fuel2 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtFuelSurcharge2').value);
            var fuel3 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtFuelSurcharge3').value);
            var fuel4 = trim(document.getElementById('ctl00_ContentPlaceHolder1_txtFuelSurcharge4').value);
            var fuel5 = 0;
            var fuel5 = ((fuel1 * 1) + (fuel2 * 1) + (fuel3 * 1) + (fuel4 * 1)) * (1 + (marginval * 0.01))
            fuel5 = fuel5 * 100;
            fuel5 = Math.round(fuel5);
            fuel5 = fuel5 / 100;
            document.getElementById('ctl00_ContentPlaceHolder1_txtFuelSurcharge').value = fuel5;

            return false;
        }

        function trim(inputStringTrim) {
            fixedTrim = "";
            lastCh = " ";
            for (x = 0; x < inputStringTrim.length; x++) {
                ch = inputStringTrim.charAt(x);
                if ((ch != " ") || (lastCh != " ")) {
                    fixedTrim += ch;
                }
                lastCh = ch;
            }
            if (fixedTrim.charAt(fixedTrim.length - 1) == " ") {
                fixedTrim = fixedTrim.substring(0, fixedTrim.length - 1);
            }
            return fixedTrim;
        }
        function CallMe() {

            document.getElementById('<%=btnloadskids.ClientID %>').click();
        }

        function DecCheck(event) {
            var code = window.event ? event.keyCode : event.which;


            if ((code >= 48 && code <= 57) || (code == 8 || code == 37 || code == 39 || code == 46 || code == 190)) {

                return true;
            }
            else {

                return false;
            }


        }

        function CheckTime(sender, args) {

            if (document.getElementById('ctl00_ContentPlaceHolder1_drpReadyTime').selectedIndex > 0 && document.getElementById('ctl00_ContentPlaceHolder1_drpLatestPickup').selectedIndex > 0) {
                if (document.getElementById('ctl00_ContentPlaceHolder1_drpReadyTime').selectedIndex >= document.getElementById('ctl00_ContentPlaceHolder1_drpLatestPickup').selectedIndex) {
                    args.IsValid = false;
                    return;

                }
                else {

                    args.IsValid = true;

                }
            }
            else {
                args.IsValid = true;
            }

        }
        function changeaddress(objdrp) {

            if (objdrp.selectedIndex == 0) {
                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToAddress').value = '900 Rt. 134, Suite 2-17';
                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToCity').value = 'S. Dennis';
                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToState').value = 'Massachusetts';
                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToZip').value = '02660';
                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToCountry').value = 'United States';



            }
            else {
//                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToAddress').value = '1000 Remington Blvd., Ste 300';
//                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToCity').value = 'Bolingbrook';
//                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToState').value = 'Illinois';
//                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToZip').value = '60440';
//                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToCountry').value = 'United States';
                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToAddress').value = '1415 W.Diehl Rd, Ste 300S';
                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToCity').value = 'Naperville';
                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToState').value = 'Illinois';
                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToZip').value = '60563';
                document.getElementById('ctl00_ContentPlaceHolder1_txtBillToCountry').value = 'United States';

            }



        }


        function CheckLoc(sender, args) {
            if (document.getElementById('ctl00_ContentPlaceHolder1_txtFromAddress').value != "") {
                if (document.getElementById('ctl00_ContentPlaceHolder1_txtFromAddress').value == document.getElementById('ctl00_ContentPlaceHolder1_txtToAddress').value) {
                    args.IsValid = false;
                    return;
                }
                else {
                    args.IsValid = true;
                }
            }
        }

        function CheckEmailPlus(sender, args) {
            if (document.getElementById('ctl00_ContentPlaceHolder1_txtFromEmail').value != "") {
                if (document.getElementById('ctl00_ContentPlaceHolder1_txtFromEmail').value.indexOf("+") != -1) {
                    args.IsValid = false;
                    return;
                }
                else {
                    args.IsValid = true;
                }
            }
        }

        function CheckSkids(sender, args) {
            if (document.getElementById('ctl00_ContentPlaceHolder1_lblSkidCount').innerHTML != "") {
                if (document.getElementById('ctl00_ContentPlaceHolder1_lblSkidCount').innerHTML == "0") {
                    args.IsValid = false;
                    return;
                }
                else {
                    args.IsValid = true;
                }
            }
        }

        function EnableModeOfTransport(strRadioID) {
            document.getElementById('<%=drpDomesticGround.ClientID %>').disabled = true;
            document.getElementById('<%=drpDomesticAir.ClientID %>').disabled = true;

            if (strRadioID == 'rbDomeGround') {
                document.getElementById('<%=drpDomesticGround.ClientID %>').disabled = false;
            }
            if (strRadioID == 'rbDomeAir') {
                document.getElementById('<%=drpDomesticAir.ClientID %>').disabled = false;
            }
        }
        function FirtTimeModeOfTransport() {
            if (document.getElementById('<%=drpDomesticGround.ClientID %>') == null || document.getElementById('<%=drpDomesticAir.ClientID %>') == null) {
                return;
            }
            document.getElementById('<%=drpDomesticGround.ClientID %>').disabled = true;
            document.getElementById('<%=drpDomesticAir.ClientID %>').disabled = true;

            if (document.getElementById('<%=rbDomeGround.ClientID %>').checked == true) {
                document.getElementById('<%=drpDomesticGround.ClientID %>').disabled = false;
            }
            if (document.getElementById('<%=rbDomeAir.ClientID %>').checked == true) {
                document.getElementById('<%=drpDomesticAir.ClientID %>').disabled = false;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rht-cont">
        <div class="serviceBox">
            <h2>
                Pickup Request <span style="color: rgb(191, 191, 191); font-size: 20px;">Domestic</span></h2>
            <iframe width="174" height="189" name="gToday:normal:agenda.js" id="gToday:normal:agenda.js"
                src="../Include/Calendar/ipopeng.htm" scrolling="no" frameborder="0" style="visibility: visible;
                z-index: 999; position: absolute; top: -500px; left: -500px;"></iframe>
            <div class="whiteBox">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="5">
                                <h3>
                                    Quick Addition</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 8px">
                                <a href="UserLocationPop.aspx?dt=1" id="lnkPickLocation" runat="server" onclick="return GB_show('Location', this.href)">
                                    <b>Pickup Location</b></a>
                            </td>
                            <td colspan="3">
                                <asp:CheckBox ID="chkSaveShipFromInfo" runat="server" CssClass="checkListShip" />Save
                                this address
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Ship From Company :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtShipFromCompany" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Shipper's Reference No:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtShipperRefNo" MaxLength="20" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqShipFromCompany" SetFocusOnError="true" Display="Dynamic"
                                    runat="server" ValidationGroup="location" ControlToValidate="txtShipFromCompany"
                                    ErrorMessage="Please enter ship from company"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Address :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromAddress" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    City :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromCity" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqFromAddress" Display="Dynamic" runat="server"
                                    SetFocusOnError="true" ValidationGroup="location" ControlToValidate="txtFromAddress"
                                    ErrorMessage="Please enter from address"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqFromCity" Display="Dynamic" SetFocusOnError="true"
                                    runat="server" ValidationGroup="location" ControlToValidate="txtFromCity" ErrorMessage="Please enter  from city"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    State :
                                </label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpFromState" Width="155px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Zip :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromPostalCode" MaxLength="10" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqFromState" Display="Dynamic" runat="server" SetFocusOnError="true"
                                    ValidationGroup="location" ControlToValidate="drpFromState" InitialValue="0"
                                    ErrorMessage="Please select from state"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqFromPostalCode" Display="Dynamic" runat="server"
                                    SetFocusOnError="true" ValidationGroup="location" ControlToValidate="txtFromPostalCode"
                                    ErrorMessage="Please enter  from postal code"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Country :
                                </label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpFromCountry" Width="155px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Contact :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromContact" MaxLength="50" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqFromContact" Display="Dynamic" runat="server"
                                    SetFocusOnError="true" ValidationGroup="location" ControlToValidate="txtFromContact"
                                    ErrorMessage="Please enter  from contact"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Phone No. :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromPhone" MaxLength="20" runat="server"></asp:TextBox>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Fax :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromFax" MaxLength="20" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqFromPhone" Display="Dynamic" runat="server" SetFocusOnError="true"
                                    ValidationGroup="location" ControlToValidate="txtFromPhone" ErrorMessage="Please enter  from phone"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Email Address :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromEmail" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Pickup Date :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPickUpDate" MaxLength="128" onfocus="blur()" Width="210px" runat="server"></asp:TextBox>
                                <a href="javascript:void(0)" onclick="if(self.gfPop)gfPop.fPopCalendar(document.getElementById('<%= txtPickUpDate.ClientID %>'));return false;">
                                    <img src="images/DatePicker.gif" alt="" border="0" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqFromEmail" runat="server" SetFocusOnError="true"
                                    ControlToValidate="txtFromEmail" Display="Dynamic" ValidationGroup="location"
                                    ErrorMessage="Please enter email address"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvalidEmailPlus" runat="server" ControlToValidate="txtFromEmail"
                                    ClientValidationFunction="CheckEmailPlus" Display="Dynamic" SetFocusOnError="true"
                                    ErrorMessage="Please remove plus sign from email address" ValidationGroup="location"></asp:CustomValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPickUpDate" runat="server" ControlToValidate="txtPickUpDate"
                                    SetFocusOnError="true" ValidationGroup="location" Display="Dynamic" ErrorMessage="Please select date"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Ready Time :
                                </label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpReadyTime" Width="155px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Latest Pickup :
                                </label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpLatestPickup" Width="155px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqReadyTime" ControlToValidate="drpReadyTime" InitialValue="0"
                                    SetFocusOnError="true" Display="Dynamic" ValidationGroup="location" runat="server"
                                    ErrorMessage="Please select ready time"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvalidTime" runat="server" ValidationGroup="location" Display="Dynamic"
                                    ErrorMessage="The latest pickup time must be greater than ready time" ClientValidationFunction="CheckTime"></asp:CustomValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqLatestPickup" ControlToValidate="drpLatestPickup"
                                    InitialValue="0" SetFocusOnError="true" Display="Dynamic" ValidationGroup="location"
                                    runat="server" ErrorMessage="Please select latest pickup"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 30px;">
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="5">
                                <h3>
                                    Quick Addition</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 8px; width: 300px;">
                                <a href="UserLocationPop.aspx?dt=2" onclick="return GB_show('Location', this.href)">
                                    <b>Delivery Location</b></a>
                            </td>
                            <td colspan="2">
                                <asp:CheckBox ID="chkSaveShipToInfo" runat="server" CssClass="checkListShip" />Save
                                this address
                            </td>
                            <td>
                                <a id="lnkWarehouseDelivLoc" runat="server" href="UserLocationWarehousePop.aspx?dt=2"
                                    onclick="return GB_show('WarehouseLocation', this.href)"><b>Select a Warehouse Delivery
                                        Location</b></a>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Ship To Company :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtShipToCompany" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Consignee Reference No:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConsigneeRefNo" MaxLength="20" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqShipToComp" SetFocusOnError="true" ControlToValidate="txtShipToCompany"
                                    runat="server" Display="Dynamic" ValidationGroup="location" ErrorMessage="Please enter ship to company"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Address :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToAddress" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    City :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToCity" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqToAddress" ControlToValidate="txtToAddress" ValidationGroup="location"
                                    SetFocusOnError="true" runat="server" Display="Dynamic" ErrorMessage="Please enter  address"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqToCity" ControlToValidate="txtToCity" ValidationGroup="location"
                                    runat="server" SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter city"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    State :
                                </label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpToState" Width="155px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Zip :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToPostalCode" MaxLength="10" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqToState" runat="server" SetFocusOnError="true"
                                    ValidationGroup="location" ControlToValidate="drpToState" InitialValue="0" Display="Dynamic"
                                    ErrorMessage="Please select state"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqPostalCode" ValidationGroup="location" SetFocusOnError="true"
                                    ControlToValidate="txtToPostalCode" runat="server" Display="Dynamic" ErrorMessage="Please enter zip"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Country :
                                </label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpToCountry" Width="155px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Contact :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToContact" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqToContact" ControlToValidate="txtToContact" SetFocusOnError="true"
                                    ValidationGroup="location" runat="server" Display="Dynamic" ErrorMessage="Please enter contact"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Phone No :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToPhone" MaxLength="20" runat="server"></asp:TextBox>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Fax :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToFax" MaxLength="20" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqToPhone" ControlToValidate="txtToPhone" ValidationGroup="location"
                                    SetFocusOnError="true" runat="server" Display="Dynamic" ErrorMessage="Please enter phone no"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Also Notify :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAlsoNotify" MaxLength="50" runat="server"></asp:TextBox>
                            </td>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label>
                                    Telephone :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToTelephone" MaxLength="20" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="middle" style="padding: 0 10px 0 0;">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <label>
                                    Delivery Date:</label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtDeliveryDate" MaxLength="128" Width="210px" onfocus="blur()"
                                    runat="server"></asp:TextBox>
                                <a href="javascript:void(0)" onclick="if(self.gfPop)gfPop.fPopCalendar(document.getElementById('<%= txtDeliveryDate.ClientID %>'));return false;">
                                    <img src="images/DatePicker.gif" alt="" border="0" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqDeliveryDAte" ControlToValidate="txtDeliveryDate"
                                    SetFocusOnError="true" ValidationGroup="location" runat="server" Display="Dynamic"
                                    ErrorMessage="Please select date"></asp:RequiredFieldValidator>
                            </td>
                            <td> </td>
                                <td>
                                </td>
                        </tr>
                        <tr>
                            <td align="left" valign="middle" style="padding: 0 10px 0 0;" colspan="2">
                                <asp:Label ID="lblWAreHoseLocationIdText" runat="server" Text="Warehouse Location ID:"></asp:Label>
                                <asp:Label ID="lblWAreHoseLocationId" runat="server"></asp:Label>
                                <asp:HiddenField ID="HidWarehouseid" runat="server" />
                                <asp:HiddenField ID="hidFromLocationid" runat="server" />
                                <asp:HiddenField ID="hidPickupRequestTypeWarehouse" runat="server" />
                                <asp:Label ID="lblSkidCount" Style="display: none" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 30px;">
                            <td colspan="4">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tbody>
                        <tr>
                            <td colspan="4">
                                <span style="padding-left: 92px;">
                                    <asp:Button ID="btnSave" runat="server" ValidationGroup="location" CssClass="BtnCommon"
                                        Width="70px" Text="Continue" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnHUnit" CausesValidation="false" runat="server" CssClass="BtnCommon"
                                        Text="Add New Handling Unit" Width="155px" OnClick="btnHUnit_Click" />
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMsg" ForeColor="Red" CssClass="submitMsg" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:CustomValidator ID="cvalidSkids" runat="server" ClientValidationFunction="CheckSkids"
                                    Display="Dynamic" SetFocusOnError="true" ErrorMessage="Please add handling unit"
                                    ValidationGroup="location"></asp:CustomValidator>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblHandlingdetails" runat="server" cellspacing="0" cellpadding="0" border="0"
                    width="100%">
                    <tbody>
                        <tr>
                            <td>
                                <asp:GridView ID="gridHandlingUnits" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                    Width="100%" AllowPaging="True" PageSize="10" AllowSorting="true" OnPageIndexChanging="gridHandlingUnits_PageIndexChanging"
                                    OnRowCommand="gridHandlingUnits_RowCommand" GridLines="None" PagerStyle-CssClass="pgr"
                                    OnRowDataBound="gridHandlingUnits_RowDataBound">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="60px" HeaderText="Unit Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitId" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px" HeaderText="Handling Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHandlingUnit" Text='<%# Eval("HandlingUnitType")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="L">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLength" Text='<%# Eval("Length")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="W">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWidth" Text='<%# Eval("Width")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="H">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHeight" Text='<%# Eval("Height")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Wt">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWeight" Text='<%#Eval("SkidWeight") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Haz Mat phone">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActive" runat="server"></asp:Label>
                                                <asp:Label ID="lblHazMatphone" Text='<%#Eval("HazMatEmergencyPhone") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCommodityDesc" Text='<%# Eval("CommodityDescription")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Class">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClass" Text='<%# Eval("Class")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="65px" HeaderText="NMFC Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNMFCCode" Text='<%# Eval("NMFCCode")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPickReqidHU" runat="server" Visible="false" Text='<%# Eval("PickupRequestId")%>'></asp:Label>
                                                <asp:Label ID="lblTrackingNo" runat="server" Text='<%# Eval("GLSTrackingNumber")%>'></asp:Label>
                                                <asp:ImageButton ID="btnEditSkids" runat="server" CommandArgument='<%# Eval("SkidId")%>'
                                                    ImageUrl="../Images/edit.gif" CausesValidation="false" OnClick="btnEditHandlingUnit_Click"
                                                    ToolTip="Edit Unit Type" Width="16px" />&nbsp;
                                                <asp:ImageButton ID="btnAddShipmentItems" runat="server" CommandArgument='<%# Eval("SkidId")%>'
                                                    ImageUrl="../Images/plus-icon.jpg" CausesValidation="false" OnClick="btnAddShipmentItems_Click"
                                                    ToolTip="Add Items" Width="19px" Height="19px" />&nbsp;
                                                <asp:ImageButton ID="btnDeleteSkids" runat="server" OnClientClick="return confirm('Are you sure you want to delete ?')"
                                                    CommandArgument='<%# Eval("SkidId")%>' CausesValidation="false" OnClick="btnDeleteHandlingUnit_Click"
                                                    ImageUrl="../images/delete.gif" ToolTip="Delete Unit Type" Width="16px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblShipmentItems" runat="server" cellspacing="0" cellpadding="0" border="0"
                    width="100%">
                    <tbody>
                        <tr>
                            <td>
                                <asp:GridView ID="gridShipments" runat="server" AutoGenerateColumns="false" CssClass="mGrid dataList"
                                    Width="100%" AllowPaging="True" PageSize="10" AllowSorting="true" OnPageIndexChanging="gridShipments_PageIndexChanging"
                                    OnRowCommand="gridShipments_RowCommand" GridLines="None" PagerStyle-CssClass="pgr"
                                    OnRowDataBound="gridShipments_RowDataBound">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="60px" HeaderText="Unit Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipUnitId" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px" HeaderText="Package Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPackageQuantity" Text='<%# Eval("PackageQuantity_SI")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Part No:">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartNo" Text='<%# Eval("PartNumber_SI")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Description" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" Text='<%# Eval("Description_SI")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Package Type" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPackageType" Text='<%# Eval("PackageType_SI")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Declared Value">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeclaredValue" Text='<%# Eval("DeclaredValue_SI")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSTrackingNo" runat="server" Text='<%# Eval("GLSTrackingNumber") %>'></asp:Label>
                                                <asp:Label ID="lblShipSkidId" runat="server" Visible="false" Text='<%# Eval("SkidId_SI")%>'></asp:Label>
                                                <asp:Label ID="lblPickReqid" runat="server" Visible="false" Text='<%# Eval("PickupRequestId_SI")%>'></asp:Label>
                                                <asp:ImageButton ID="btnEditShipment" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ShipmentItemID")%>'
                                                    ImageUrl="../Images/edit.gif" OnClick="btnEditShipment_Click" ToolTip="Edit"
                                                    Width="16px" />&nbsp;
                                                <asp:ImageButton ID="btnDeleteShipment" runat="server" OnClientClick="return confirm('Are you sure you want to delete ?')"
                                                    CommandArgument='<%# Eval("ShipmentItemID")%>' ImageUrl="../images/delete.gif"
                                                    CausesValidation="false" ToolTip="Delete" OnClick="btnDeleteShipment_Click" Width="16px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblRequestedService" runat="server" cellspacing="0" cellpadding="0" border="0"
                    width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="2">
                                <h3>
                                    Requested Service</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 40px">
                                <label>
                                    <b>Mode of Transportation</b></label>
                            </td>
                            <td>
                                <label>
                                    <b>Type of Service</b></label>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="left" valign="middle" style="padding: 0 5px 0 40px;">
                                <asp:RadioButton ID="rbDomeGround" GroupName="reqservice" Text="Domestic Ground"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:DropDownList ID="drpDomesticGround" Width="155px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="left" valign="middle" style="padding: 0 5px 0 40px;">
                                <asp:RadioButton ID="rbDomeAir" GroupName="reqservice" Text="Domestic Air" runat="server" />
                            </td>
                            <td>
                                <asp:DropDownList ID="drpDomesticAir" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="left" valign="middle" style="padding: 0 5px 0 40px;">
                                <asp:RadioButton ID="rbISCSAdvantage" GroupName="reqservice" Checked="true" Text="3PL"
                                    runat="server" />
                            </td>
                            <td>
                                <label>
                                    3PL Preferred (most cost effective service)
                                </label>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblSpecialServices" runat="server" cellspacing="0" cellpadding="0" border="0"
                    width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="5">
                                <h3>
                                    Special Services</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="top" style="padding: 0 10px 0 0;">
                                <label>
                                    Lift gate required</label>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkLLiftGate" RepeatDirection="Vertical" CssClass="checkListShip"
                                    runat="server">
                                    <asp:ListItem Text="Origin" Value="101"></asp:ListItem>
                                    <asp:ListItem Text="Destination" Value="102"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td class="body_text_12" align="right" valign="top" style="padding: 0 10px 0 0;">
                                <label>
                                    Saturday service</label>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkLSaturdayService" RepeatDirection="Vertical" CssClass="checkListShip"
                                    runat="server">
                                    <asp:ListItem Text="Pickup" Value="401"></asp:ListItem>
                                    <asp:ListItem Text="Delivery" Value="402"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="top" style="padding: 0 10px 0 0;">
                                <label>
                                    Pallet jack required</label>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkLPalletJack" RepeatDirection="Vertical" CssClass="checkListShip"
                                    runat="server">
                                    <asp:ListItem Text="Origin" Value="201"></asp:ListItem>
                                    <asp:ListItem Text="Destination" Value="202"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td class="body_text_12" align="right" valign="top" style="padding: 0 10px 0 0;">
                                <label>
                                    Convention/Trade Show location</label>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkLConvention" RepeatDirection="Vertical" CssClass="checkListShip"
                                    runat="server">
                                    <asp:ListItem Text="Pickup" Value="501"></asp:ListItem>
                                    <asp:ListItem Text="Delivery" Value="502"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" align="right" valign="top" style="padding: 0 10px 0 0;">
                                <label>
                                    Located inside</label>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkLLocatedInside" RepeatDirection="Vertical" CssClass="checkListShip"
                                    runat="server">
                                    <asp:ListItem Text="Origin" Value="301"></asp:ListItem>
                                    <asp:ListItem Text="Destination" Value="302"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td class="body_text_12" align="right" valign="top" style="padding: 0 10px 0 0;">
                                <label>
                                    Residential location</label>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkLResidentialLocation" RepeatDirection="Vertical" CssClass="checkListShip"
                                    runat="server">
                                    <asp:ListItem Text="Pickup" Value="601"></asp:ListItem>
                                    <asp:ListItem Text="Delivery" Value="602"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="body_text_12" colspan="4">
                                <h3>
                                    Special Instructions</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <textarea id="txtareaSpecialInTructions" rows="5" class="textareawf" runat="server"></textarea>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblShipmentInfo" runat="server" cellspacing="0" cellpadding="0" border="0"
                    width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="2">
                                <h3>
                                    Shipment Information</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label>
                                    Account Code :
                                </label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpAccountCode" Width="155px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="reqAccountCode" Display="Dynamic" ValidationGroup="location"
                                    InitialValue="0" SetFocusOnError="true" ControlToValidate="drpAccountCode" runat="server"
                                    ErrorMessage="Please select account code"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkShipmentInfo" RepeatDirection="Vertical" CssClass="checkListLong"
                                    runat="server">
                                    <asp:ListItem Text="Uncheck if shipper is unknown." Selected="True" Value="0"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label>
                                    Shipped Weight :
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtShippedWeight" onfocus="blur()" onkeypress="return onlyDigits(event,'decOK')"
                                    MaxLength="14" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblShipmentCharges" runat="server" cellspacing="0" cellpadding="0" border="1"
                    width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="6">
                                <h3>
                                    Shipment Charges</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <label>
                                    <b>Buy Rate</b></label>
                            </td>
                            <td>
                                <label>
                                    <b>Costs</b>
                                </label>
                            </td>
                            <td>
                                <label>
                                    <b>Sell Rate</b>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Pick Up</b>
                            </td>
                            <td>
                                <b>Intermediate</b>
                            </td>
                            <td>
                                <b>Delivery</b>
                            </td>
                            <td>
                                <b>Other</b>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 8px">
                                <label style="color: Red; width: 10px">
                                    *
                                </label>
                                <a href="CarriersPop.aspx?dt=1" onclick="return GB_show('Location', this.href)">Pick
                                    Carrier</a>
                            </td>
                            <td>
                                <a href="CarriersPop.aspx?dt=2" onclick="return GB_show('Location', this.href)">Pick
                                    Carrier</a>
                            </td>
                            <td>
                                <a href="CarriersPop.aspx?dt=3" onclick="return GB_show('Location', this.href)">Pick
                                    Carrier</a>
                            </td>
                            <td>
                                <a href="CarriersPop.aspx?dt=4" onclick="return GB_show('Location', this.href)">Pick
                                    Carrier</a>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPickupCarrier" MaxLength="50" CssClass="tboxpickreq" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdCarrierID" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtIntermediateCarrier" MaxLength="50" CssClass="tboxpickreq" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdIntermediateCarrierID" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtDeliveryCarrier" MaxLength="50" CssClass="tboxpickreq" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdDeliveryCarrierID" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtOtherCarrier" MaxLength="50" CssClass="tboxpickreq" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdOtherCarrierID" runat="server" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:RequiredFieldValidator ID="reqPickupCarrier" ValidationGroup="location" runat="server"
                                    Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPickupCarrier"
                                    ErrorMessage="Please select carrier."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList8" CssClass="checkListShip" runat="server">
                                    <asp:ListItem Text="Save this carrier name for future use." Value="0"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList9" CssClass="checkListShip" runat="server">
                                    <asp:ListItem Text="Save this carrier name for future use." Value="0"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList10" CssClass="checkListShip" runat="server">
                                    <asp:ListItem Text="Save this carrier name for future use." Value="0"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList11" CssClass="checkListShip" runat="server">
                                    <asp:ListItem Text="Save this carrier name for future use." Value="0"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMargin" MaxLength="2" onkeydown="return DecCheck(event)" CssClass="tboxpickcommon"
                                    runat="server"></asp:TextBox>% Margin<br />
                                <asp:Button ID="btnApply" CssClass="BtnCommon" CausesValidation="false" runat="server"
                                    OnClientClick="return FillRates()" Width="40px" Text="Apply" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtTransportCost1" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTransportCost2" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTransportCost3" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTransportCost4" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <label>
                                    Transport
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTransport" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtAccessorialCost1" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAccessorialCost2" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAccessorialCost3" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAccessorialCost4" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <label>
                                    Accessorial
                                </label>
                                <br />
                                (Total Item Costs)
                            </td>
                            <td>
                                <asp:TextBox ID="txtAccessorial" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtFuelSurcharge1" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFuelSurcharge2" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFuelSurcharge3" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFuelSurcharge4" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <label>
                                    Fuel Surcharge</label><br />
                            </td>
                            <td>
                                <asp:TextBox ID="txtFuelSurcharge" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="center" colspan="2">
                                <span style="padding-top: 4px">Insured </span>
                                <asp:RadioButtonList ID="rblInsured" RepeatDirection="Horizontal" CssClass="radioship"
                                    runat="server">
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInsurance1" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                Insurance
                            </td>
                            <td>
                                <asp:TextBox ID="txtInsurance" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <b>Declared Value</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCodFee1" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                COD Fee
                            </td>
                            <td>
                                <asp:TextBox ID="txtCodFee" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotal1" onfocus="blur()" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                Total
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotal" onfocus="blur()" MaxLength="14" onkeypress="return onlyDigits(event,'decOK')"
                                    CssClass="tboxpickreq" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblBillingInfo" runat="server" cellspacing="0" cellpadding="0" border="0"
                    width="100%">
                    <tbody>
                        <tr>
                            <td class="body_text_12" colspan="2">
                                <h3>
                                    Billing Information</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label>
                                    Payment Method:
                                </label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpPaymentMethod" Width="155px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label>
                                    Certified Check:
                                </label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbCertifiedCheck" RepeatDirection="Horizontal" CssClass="radioship"
                                    runat="server">
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Selected="True" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label>
                                    Bill To Company:
                                </label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpBillToCompany" Width="155px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label>
                                    Bill To Address:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBillToAddress" onfocus="blur()" MaxLength="128" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label>
                                    Bill To City:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBillToCity" onfocus="blur()" MaxLength="100" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label>
                                    Bill To State:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBillToState" onfocus="blur()" MaxLength="100" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label>
                                    Bill To Zip:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBillToZip" onfocus="blur()" MaxLength="10" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label>
                                    Bill To Country:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBillToCountry" onfocus="blur()" MaxLength="100" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="body_text_12">
                                <h3>
                                    Notes</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <textarea id="txtareaNotes" rows="5" class="textareawf" runat="server"></textarea>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnContinue" runat="server" Width="100px" CssClass="BtnCommon" ValidationGroup="location"
                                Text="Save Changes" OnClick="btnContinue_Click" />&nbsp;
                            <asp:Button ID="btnAccept" runat="server" Width="140px" CssClass="BtnCommon" ValidationGroup="location"
                                Text="Accept Request" OnClick="btnAccept_Click" />
                            <span style="display: none;">
                                <asp:Button ID="btnloadskids" CausesValidation="false" runat="server" Text="Button"
                                    OnClick="btnloadskids_Click" /></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblSubMsg" ForeColor="Red" runat="server" CssClass="submitMsg"></asp:Label>
                            <asp:CustomValidator ID="cvalidLoc" runat="server" ClientValidationFunction="CheckLoc"
                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Please select different location"
                                ValidationGroup="location"></asp:CustomValidator>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <script language="javascript">
        FirtTimeModeOfTransport();
    </script>

</asp:Content>
