<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    Theme="Admin" CodeBehind="Home.aspx.cs" Inherits="ISCS.Admin.DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        /* rotator in-page placement */div.rotator
        {
            position: relative;
            height: 345px;
            margin-left: 0px;
            display: none;
        }
        /* rotator css */div.rotator ul li
        {
            float: left;
            position: absolute;
            list-style: none;
        }
        /* rotator image style */div.rotator ul li img
        {
            border: 1px solid #ccc;
            padding: 0px;
            background: #FFF;
        }
        div.rotator ul li.show
        {
            z-index: 500;
        }
    </style>

    <script type="text/javascript" src="../Include/JS/jquery-1.3.2.min.js"></script>

    <script type="text/javascript">

function theRotator() {
	//Set the opacity of all images to 0
	$('div.rotator ul li').css({opacity: 0.0});
	
	//Get the first image and display it (gets set to full opacity)
	$('div.rotator ul li:first').css({opacity: 1.0});
		
	//Call the rotator function to run the slideshow, 6000 = change to next image after 6 seconds
	
	setInterval('rotate()',6000);
	
}

function rotate() {	
	//Get the first image
	var current = ($('div.rotator ul li.show')?  $('div.rotator ul li.show') : $('div.rotator ul li:first'));

    if ( current.length == 0 ) current = $('div.rotator ul li:first');

	//Get next image, when it reaches the end, rotate it back to the first image
	var next = ((current.next().length) ? ((current.next().hasClass('show')) ? $('div.rotator ul li:first') :current.next()) : $('div.rotator ul li:first'));
	
	//Un-comment the 3 lines below to get the images in random order
	
	//var sibs = current.siblings();
    //var rndNum = Math.floor(Math.random() * sibs.length );
    //var next = $( sibs[ rndNum ] );
			

	//Set the fade in effect for the next image, the show class has higher z-index
	next.css({opacity: 0.0})
	.addClass('show')
	.animate({opacity: 1.0}, 1000);

	//Hide the current image
	current.animate({opacity: 0.0}, 1000)
	.removeClass('show');
	
};



$(document).ready(function() {		
	//Load the slideshow
	theRotator();
	$('div.rotator').fadeIn(1000);
    $('div.rotator ul li').fadeIn(1000); // tweek for IE
});
    </script>

    <div class="rht-contHome">
        <div class="serviceBox" style="width: 607px;">
            <h2>
                Welcome to 3PL Integration, LLC Administration</h2>
        </div>
        <div class="rotator1" style="width: 613px;">
            <ul>
                <li>
                    <img src="../images/iStock_000007298729XSmall.jpg" width="613" height="313" alt="pic2"
                        style="border: 1px solid #ccc;" /></li>
            </ul>
        </div>
    </div>
</asp:Content>
