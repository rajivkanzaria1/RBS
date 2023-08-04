<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="RBS.MainPage.MainPage" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Home Page</title>
		<script type="text/javascript">
	var NoOffFirstLineMenus=6;			// Number of first level items
	var LowBgColor='#c6e2ff';			// Background color when mouse is not over
	var LowSubBgColor='#c6e2ff';			// Background color when mouse is not over on subs
	var HighBgColor='#87cefa';			// Background color when mouse is over
	var HighSubBgColor='#87cefa';			// Background color when mouse is over on subs
	var FontLowColor='#00008b';			// Font color when mouse is not over
	var FontSubLowColor='#00008b';			// Font color subs when mouse is not over
	var FontHighColor='#00008b';			// Font color when mouse is over
	var FontSubHighColor='#00008b';			// Font color subs when mouse is over
	var BorderColor='#c6e2ff';			// Border color
	var BorderSubColor='#c6e2ff';			// Border color for subs
	var BorderWidth=2;				// Border width
	var BorderBtwnElmnts=1;			// Border between elements 1 or 0
	var FontFamily="verdana"	// Font family menu items
	var FontSize=8;				// Font size menu items
	var FontBold=1;				// Bold menu items 1 or 0
	var FontItalic=0;				// Italic menu items 1 or 0
	var MenuTextCentered='left';			// Item text position 'left', 'center' or 'right'
	var MenuCentered='center';			// Menu horizontal position 'left', 'center' or 'right'
	var MenuVerticalCentered='top';		// Menu vertical position 'top', 'middle','bottom' or static
	var ChildOverlap=.2;				// horizontal overlap child/ parent
	var ChildVerticalOverlap=.8;			// vertical overlap child/ parent
	var StartTop=130;				// Menu offset x coordinate
	var StartLeft=1;				// Menu offset y coordinate
	var VerCorrect=0;				// Multiple frames y correction
	var HorCorrect=0;				// Multiple frames x correction
	var LeftPaddng=0;				// Left padding
	var TopPaddng=0;				// Top padding
	var FirstLineHorizontal=1;			// SET TO 1 FOR HORIZONTAL MENU, 0 FOR VERTICAL
	var MenuFramesVertical=1;			// Frames in cols or rows 1 or 0
	var DissapearDelay=100;			// delay before menu folds in
	var TakeOverBgColor=1;			// Menu frame takes over background color subitem frame
	var FirstLineFrame='navig';			// Frame where first level appears
	var SecLineFrame='space';			// Frame where sub levels appear
	var DocTargetFrame='space';			// Frame where target documents appear
	var TargetLoc='';				// span id for relative positioning
	var HideTop=0;				// Hide first level when loading new document 1 or 0
	var MenuWrap=1;				// enables/ disables menu wrap 1 or 0
	var RightToLeft=0;				// enables/ disables right to left unfold 1 or 0
	var UnfoldsOnClick=0;			// Level 1 unfolds onclick/ onmouseover
	var WebMasterCheck=0;			// menu tree checking on or off 1 or 0
	var ShowArrow=1;				// Uses arrow gifs when 1
	var KeepHilite=1;				// Keep selected path highligthed
	var Arrws=['tri.gif',5,10,'tridown.gif',10,5,'trileft.gif',5,10];	// Arrow source, width and height

function BeforeStart(){return}
function AfterBuild(){return}
function BeforeFirstOpen(){return}
function AfterCloseAll(){return}
//****************** Menu **********************************************
  Menu1=new Array("ABOUT US","","",5,20,100);
	 Menu1_1=new Array("QA DIVISION PROFILE","About_us.aspx","",0,20,250);
     Menu1_2=new Array("SERVICE SPECTRUM","Service_Spectrum.aspx","",0,20,250);
     Menu1_3=new Array("RESOURCES","Resources_Form.aspx","",0,20,250);
     Menu1_4=new Array("OUR CLIENTS","Our_Clients.aspx","",0,20,300);
     Menu1_5=new Array("OUR COMMITTMENT","Our_Committement.aspx","",0,20,300);
		    
		
//     Menu1_2=new Array("Messages Form","Mobile.aspx","",0,20,250);
     
  Menu2=new Array("VENDORS INTERFACE","","",11,20,150);	
	 Menu2_1=new Array("GUIDELINES FOR CALL REGISTRATION(FOR NEW, EXISTING VENDORS & UPLOADING OF LAB PAYMENT RECIEPT)","","",3,40,250);	
		Menu2_1_1=new Array("INTERACTIVE AUTOMATIC CALL DESK HELPLINE NO. 1800 425 7000 (TOLL FREE)","IVRS_NEW.pdf","",0,40,310); 
		Menu2_1_2=new Array("GENERAL GUIDELINES TO REGSITER INSPECTION CALL","General Guidelines.PDF","",0,40,310); 
		Menu2_1_3=new Array("INDICATIVE GUIDELINES TO SUPPLIERS FOR TPI","Indicative Guidelines.PDF","",0,40,310); 
	 Menu2_2=new Array("GUIDANCE FOR UPLOADING LAB CHARGES PAYMENT RECIEPT","Vendor Lab Reciept Upload Mannual.pdf","",0,40,310); 
     Menu2_3=new Array("LOGIN","","",6,20,250);
		Menu2_3_1=new Array("PO/CALL REGISTRATION","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
		Menu2_3_2=new Array("QTY ENHANCEMENT","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
		Menu2_3_3=new Array("NEW ITEMS IN ALREDAY REGISTERED LOA","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
		Menu2_3_4=new Array("DOCUMENTS UPLOAD","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
		Menu2_3_5=new Array("SPECIFIC PO/CALL STATUS","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
		Menu2_3_6=new Array("DOWNLOAD INSP INVOICE","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
     Menu2_4=new Array("ONLINE PAYMENT THROUGH GATEWAY","/rbs/Online_Payment_Form.aspx","",0,20,250);
     Menu2_5=new Array("CANCELLATION CHARGES","CRCharges.pdf","",0,20,250);
     Menu2_6=new Array("REJECTION CHARGES","CRCharges.pdf","",0,20,250);
     Menu2_7=new Array("LAB CHARGES","","",4,20,250);
		Menu2_7_1=new Array("NORTHERN REGION","Average Lab Testing Time NR.pdf","",0,20,310);    
		Menu2_7_2=new Array("WESTERN REGION","Average Lab Testing Time WR.pdf","",0,20,310);    
		Menu2_7_3=new Array("SOUTHERN REGION","Average Lab Testing Time SR.pdf","",0,20,310);    
		Menu2_7_4=new Array("EASTERN REGION","Average Lab Testing Time ER.pdf","",0,20,310);    
	 Menu2_8=new Array("VENDOR FEEDBACK","Vendor_Feedback_Form.aspx","",0,20,250);
     Menu2_9=new Array("BANK DETAILS OF ALL REGIONS","BANK DETAILS.PDF","",0,20,250);
     Menu2_10=new Array("MANUAL INSP CALL FORMAT","Format_For_Inspection_Call.pdf","",0,20,250);
     Menu2_11=new Array("ONLINE INSP INVOICE OF RITES","Online Inspection Invoice of RITES.pdf","",0,20,250);
 Menu3=new Array("CLIENT INTERFACE","","",5,20,140);	
	Menu3_1=new Array("LOGIN","Client_Login_Form.aspx","",0,20,250);
	Menu3_2=new Array("VENDOR PERFORMANCE","Client_Login_Form.aspx","",0,20,250);
	Menu3_3=new Array("SPECIFIC PO/CALL STATUS WITH DOWNLOADING FACILITY OF IC/TEST PLAN","Client_Login_Form.aspx","",0,40,300);
	Menu3_4=new Array("CLIENT FEEDBACK","Client_Feedback_Form.aspx","",0,20,250);
	Menu3_5=new Array("FACILITY TO REGISTER ONLINE REJECTION ADVICE","Onliine_Complaints_Form.aspx","",0,30,300);
Menu4=new Array("CONTACT US","","",6,30,100);
		Menu4_1=new Array("NORTHERN REGION","NR_ADDRESS.htm","",0,20,310);    
		Menu4_2=new Array("WESTERN REGION","WR_ADDRESS.htm","",0,20,310);    
		Menu4_3=new Array("SOUTHERN REGION","SR_ADDRESS.htm","",0,20,310);    
		Menu4_4=new Array("EASTERN REGION","ER_ADDRESS.htm","",0,20,310);    
		Menu4_5=new Array("CENTRAL REGION","CR_ADDRESS.htm","",0,20,310);   
		Menu4_6=new Array("FOREIGN INSPECTION","FR_ADDRESS.htm","",0,20,310);   
Menu5=new Array("QUICK LINKS","","",8,30,100);
		Menu5_1=new Array("CLIENT LOGIN","/rbs/Client_Login_Form.aspx","",0,20,250);
		Menu5_2=new Array("VENDOR LOGIN","/rbs/Vendor/Vendor_Login_Form.aspx","",0,20,250);
		Menu5_3=new Array("IE LOGIN","/rbs/IE_Login_Form.aspx","",0,20,250);
		Menu5_4=new Array("USER LOGIN","/rbs/Login_Form.aspx","",0,20,250);
		Menu5_5=new Array("LIAISONING OFFICER LOGIN","/rbs/LO_Login_Form.aspx","",0,20,250);
		Menu5_6=new Array("ONLINE PAYMENT THROUGH GATEWAY","/rbs/Online_Payment_Form.aspx","",0,20,250);
		Menu5_7=new Array("FEEDBACK & SUGGESTIONS","Email.aspx","",0,20,250);
		Menu5_8=new Array("RITES Official Website","https://rites.com","",0,20,250);

Menu6=new Array("MISCELLANEOUS","","",3,20,130);	
			Menu6_1=new Array("INFO & INSTRUCTIONS","Instruction_Page.aspx","",0,20,250);
			Menu6_2=new Array("PHOTO GALLERY","Photo_Gallery.aspx","",0,20,250);
			Menu6_3=new Array("QA CHANNEL (YOUTUBE)","https://youtube.com/channel/UCDhuMds0jhn5t7iX0VMn2zw","",0,20,250);


//*********************** Ending of Menu ********************************
		function IsPopupBlocker()
		 {
			var oWin = window.open("","testpopupblocker","width=100,height=50,top=5000,left=5000");
			if (oWin==null || typeof(oWin)=="undefined")
			{
				return true;
			} else
			{
				oWin.close();
				return false;
			}
		 }
	//	function changeStyle(){
    //    var element = document.getElementById("popup");
     //   element.style.display = "none";
     //   }
		</script>
    
		
 <!--   <style type="text/css">
        #overlay
        {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #000;
            filter: alpha(opacity=70);
            -moz-opacity: 0.7;
            -khtml-opacity: 0.7;
            opacity: 0.7;
            z-index: 2000;
            display: none;
        }
        .img a
        {
            text-decoration: none;
        }
        .popup
        {
            width: 70%;
            margin: 0 auto;
            display: none;
            position: fixed;
            z-index: 2001;
        }
        .img
        {
            min-width: 600px;
            width: 600px;
            min-height: 250px;
            height:auto;
            margin: 0px auto;
            background: #f3f3f3;
            position: relative;
            z-index: 2003;
            padding: 1px;
            border-radius: 5px;
            box-shadow: 0 2px 5px #000;
           top:150px;
        }
        .img p
        {
            clear: both;
            color: #555555;
            text-align: justify;
        }
        .img p a
        {
            color: #d91900;
            font-weight: bold;
        }
        .img .x
        {
            float: right;
            height: 30px;
            left: 22px;
            position: relative;
            top: -25px;
            width: 34px;
        }
        .img .x:hover
        {
            cursor: pointer;
        }
    </style>-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK media="screen" href="styles2.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body text="navy">
		<script type="text/javascript">

//HV Menu- by Ger Versluis (http://www.burmees.nl/)
//Submitted to Dynamic Drive (http://www.dynamicdrive.com)
//Visit http://www.dynamicdrive.com for this script and more

function Go(){return}

        </script>
		<script src="menu_com.js" type="text/javascript"></script>
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<div id="content" style="BACKGROUND-COLOR: white">
					<div id="back">
						<!-- header begins -->
						<!-- header ends -->
						<!-- content begins -->
						<div id="logo"><a>Quality Assurance Division&nbsp;</a><br>
							<b>(A Government of India Enterprise)&nbsp;<br>
								An ISO 9001 Company/Accreditation to ISO/IEC 17020&nbsp;</b><br>
							<br>
							<br>
							<marquee behavior="alternate"><b><FONT color="#ff6600">NATIONAL HELP LINE NUMBER : 1800 425 
										7000 (TOLL FREE)</FONT><IMG id="imgad" src="\RBS\images\New_Blinking.gif" border="0"></b></marquee>
										<br>
							<marquee behavior="alternate"><b><FONT color=#009933>ALL PAYMENTS BY PARTIES ARE TO BE MADE THROUGH PAYMENT GATEWAY ONLY</FONT><IMG id="imgad" src="\RBS\images\New_Blinking.gif" border="0"></b></marquee>
						</div>
						<p align="left"><A href="/rbs/MainPage_Hindi.aspx"><font style="FONT-WEIGHT: bold; FONT-SIZE: 100%; COLOR: green; FONT-FAMILY: Verdana"><U>Hindi 
										Version</U></font></A></p>
										
								<!--		<div class="popup" style="display: block;" id="popup">
                                       <div class="img">
                                       <img src="images/cross.png" alt="quit" class="x" id="x" onclick="changeStyle();">   
                                      <a href="https://harghartiranga.com/" target="_blank"><img src="images/HarGharTiranga.jpg" style="width:100%;"></a> 
          
                                    </div>
                               </div>-->
						<div id="main"><br>
							<marquee width="100%"><asp:label id="lblLatestMess" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
									Font-Names="Verdana">Note: Please ensure Inspection Call is submitted at least five(5) working days before the expiry of the delivery period , otherwise Call shall not be accepted. Any incomplete inspection call not be considered and summarily rejected. Further in cases requiring lab testing outside the vendor premises, additional time required for testing should also provided for.  <Font Color="blue">
										For quick response from RITES LTD, Kindly mention Email-ID and Contact Person's 
										Mobile No. in the Call Format.</Font><Font Color="Green"> Some Vendors are 
										directly depositing payments throught DD/NEFT to RITES Account without 
										informing payment details & Case particulars. All Vendors are kindly requested 
										to always inform concerned regional office immidiately through E-Mail, Such 
										payments details indicating Case No. for proper accountal of their credits. 
										Feedback column has been introduced in "ritesinsp.com". All users are requested 
										to make use of the facility.</Font></asp:label></marquee>
							<div id="right">
								<ul>
									<p align="justify"><span style="FONT-SIZE:12pt; COLOR:darkblue; FONT-FAMILY:Verdana; BACKGROUND-COLOR:white">
											We kindly request our esteemed partners (Vendors) to participate in CVC drive 
											for eradication of corruption by signing Organisation Integrity Pledge, as 
											available on the <b><a href="http://pledge.cvc.nic.in/"><font color="darkblue"><u>CVC Website</u></font></a></b>.<IMG id="imgad" src="\RBS\images\New_Blinking.gif" border="0">
											<br>
										</span>
									</p>
								</ul>
								<ul style="FONT-SIZE: 10pt; COLOR: darkblue; FONT-FAMILY: trebuchet ms,geneva; LIST-STYLE-TYPE: none">
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									One of the largest,oldest,multidisciplinary Govt.Third Party Inspection (TPI) 
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Agency
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									Very rich experience over 47 years
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									Transparent and Impartial TPI for all engineering items including 
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mechanical/Civil/Electrical/Electronics 
									items/components &amp; assemblies,Machine &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp; 
									Plants (M&amp;P),Bridge Girders,track items etc.
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									Vendors� Capability &amp; Capacity Assessment
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									Rich experience of Inspection in Foreign Countries
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									Material testing in laboratories accredited to ISO/IEC 17025 by NABL
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									PAN India presence through five Regional Inspection offices
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									More than 300 highly qualified inspection professionals located across the 
									country
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									Transparent TPI monitoring operations through In-house software (IBS)
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									Client Interface through dedicated Client Login
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									Quality Awards winner
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
										Deals with large diversified clientele�Govt.,PSUs,State Govt.,Autonomous
										<br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bodies, Private sectors</li></ul>
								<ul>
									<table>
										<tr>
											<td colspan=3><div id="left"><h3>AWARDS</h3>
												</div>
											</td>

										</tr>
										<tr>
											<td>
													<img class="mySlides" src="\RBS\images\A1.jpg" width="160" height="150"> </td>
													<td><img class="mySlides" src="\RBS\images\A2.jpg" width="160" height="150"></td>                                    
										
											<td>
													<img class="mySlides" src="\RBS\images\A5.jpg" width="160" height="150"> </td>
						
										</tr>
									</table>
								</ul>
								<UL>
								</UL>
							</div>
						</div>
						<div id="left">
							<h3>Certifications</h3>
							<table>
								<tr>
									<td align="center" width="200" height="165"><a href="\RBS\images\ISO 9001.jpg" target="_blank" style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BACKGROUND-COLOR: transparent"><IMG src="\RBS\images\ISO 9001.jpg" style="WIDTH: 180px; POSITION: static; HEIGHT: 140px"></a><br>
										<font style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: black; FONT-FAMILY: Verdana">
											<b>ISO 9001:2015 Certification</b></font><br>
										<a href="\RBS\images\IEC 17020 2012.jpg" target="_blank" style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BACKGROUND-COLOR: transparent">
											<IMG src="\RBS\images\IEC 17020 2012.jpg" style="WIDTH: 180px; POSITION: static; HEIGHT: 140px"></a><br>
										<font style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: magenta; FONT-FAMILY: Verdana">
											<b>ISO/IEC 17020:2012 Accreditation </b></font>
										<br>
										<IMG src="\RBS\images\IEC 17025 2005.jpg" style="WIDTH: 180px; POSITION: static; HEIGHT: 140px"><br>
										<font style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: darkblue; FONT-FAMILY: Verdana">
											<b>ISO/IEC 17025 Accredited Labs </b></font>
									</td>
								</tr>
							</table>
						</div>
						<div style="CLEAR: both"></div>
						<!--content ends -->
						<!--footer begins --></div>
					<div id="footer">
						<p>Design &amp; Developed by RITES IT Division, Northern Region
						</p>
					</div>
				</div>
			</div>
			<DIV></DIV>
			<!-- footer ends--></form>
		<DIV></DIV>
		</FONT>
	</body>
</HTML>
