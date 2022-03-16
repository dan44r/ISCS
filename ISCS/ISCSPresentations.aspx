<%@ Page Title="3PLI Presentations & PDFs" Language="C#" MasterPageFile="~/UserMaster.Master"
    AutoEventWireup="true" CodeBehind="ISCSPresentations.aspx.cs" Inherits="ISCS.ISCSPresentations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="inr-cont feedback">
            <h2>
                3PLI Presentation and Downloads</h2>
            <div class="inner_form_cont">
                <h3>
                    Click on the link below to print detailed information on 3PLI products and services.</h3>
                <ul type="disc">
                    <li style="padding: 5px 5px 5px 5px"><a style="color: #daa929; font-size: 13px; cursor: pointer"
                        onclick="window.open('pdfs/Air Freight Solutions.pdf','_blank');">Air Freight Solutions</a></li>
                    <li style="padding: 5px 5px 5px 5px"><a style="color: #daa929; font-size: 13px; cursor: pointer"
                        onclick="window.open('pdfs/Ground Solutions.pdf','_blank');">Ground Solutions</a></li>
                    <li style="padding: 5px 5px 5px 5px"><a style="color: #daa929; font-size: 13px; cursor: pointer"
                        onclick="window.open('pdfs/International Ocean Freight Services.pdf','_blank');">
                        International Ocean Freight Services</a></li>
                    <li style="padding: 5px 5px 5px 5px"><a style="color: #daa929; font-size: 13px; cursor: pointer"
                        onclick="window.open('pdfs/Temperature Control Solutions.pdf','_blank');">Temperature
                        Control Solutions</a></li>
                    <li style="padding: 5px 5px 5px 5px"><a style="color: #daa929; font-size: 13px; cursor: pointer"
                        onclick="window.open('pdfs/Supply Chain Solutions.pdf','_blank');">Supply Chain
                        Solutions</a></li>
                    <li style="padding: 5px 5px 5px 5px"><a style="color: #daa929; font-size: 13px; cursor: pointer"
                        onclick="window.open('pdfs/Reverse Logistics.pdf','_blank');">Reverse Logistics</a></li>
                    <li style="padding: 5px 5px 5px 5px"><a style="color: #daa929; font-size: 13px; cursor: pointer"
                        onclick="window.open('pdfs/Merge-In-Transit Service.pdf','_blank');">Merge-in-Transit
                        Service</a></li>
                    <li style="padding: 5px 5px 5px 5px"><a style="color: #daa929; font-size: 13px; cursor: pointer"
                        onclick="window.open('pdfs/White Glove Solutions.pdf','_blank');">White Glove Solutions</a></li>
                    <li style="padding: 5px 5px 5px 5px"><a style="color: #daa929; font-size: 13px; cursor: pointer"
                        onclick="window.open('pdfs/Warehousing Solutions.pdf','_blank');">Warehousing Solutions</a></li>
                    <li style="padding: 5px 5px 5px 5px"><a style="color: #daa929; font-size: 13px; cursor: pointer"
                        onclick="window.open('pdfs/Trade Show Solutions.pdf','_blank');">Trade Show Solutions</a></li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
