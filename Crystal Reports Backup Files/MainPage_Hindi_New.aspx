<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage_Hindi_New.aspx.cs" Inherits="RBS.MainPage_Hindi_New.MainPage_Hindi_New" %>


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
	var FontSize=10;				// Font size menu items
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
	var DissapearDelay=1000;			// delay before menu folds in
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
  Menu1=new Array("हमारे बारे में","","",4,20,100);
	 Menu1_1=new Array("क्यूए डिवीजन प्रोफाइल","About_us_Hindi.aspx","",0,20,250);
     Menu1_2=new Array("सेवा स्पेक्ट्रम","Service_Spectrum_Hindi.aspx","",0,20,250);
     Menu1_3=new Array("संसाधन","Our_Resources_Hindi.aspx","",0,20,250);
     Menu1_4=new Array("हमारे क्लाइंट","Our_Clients_Hindi.aspx","",0,20,300);
		    
		
//     Menu1_2=new Array("Messages Form","Mobile.aspx","",0,20,250);
     
  Menu2=new Array("विक्रेता इंटरफ़ेस","","",12,20,130);	
	 Menu2_1=new Array("कॉल रजिस्टर प्रक्रिया","GenInfoVend.pdf","",0,20,250);
     Menu2_2=new Array("नई विक्रेता लॉगिन आईडी प्रक्रिया","/rbs/Vendor/ONLINE CALL BOOKING METHOD HINDI.pdf","",0,20,250);
     Menu2_3=new Array("सामान्य दिशानिर्देश","/rbs/Vendor/Guidelines for Vendors Hindi.pdf","",0,20,250);
     Menu2_4=new Array("लॉग इन करें","","",6,20,250);
		Menu2_4_1=new Array("पीओ/कॉल पंजीकरण","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
		Menu2_4_2=new Array("मात्रा वृद्धि","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
		Menu2_4_3=new Array("पहले से पंजीकृत LOA में नई वस्तुएं","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
		Menu2_4_4=new Array("दस्तावेज़ अपलोड","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
		Menu2_4_5=new Array("विशिष्ट पीओ/कॉल स्थिति","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
		Menu2_4_6=new Array("निरीक्षण चालान डाउनलोड करें","Vendor/Vendor_Login_Form.aspx","",0,20,310);    
     Menu2_5=new Array("गेटवे के माध्यम से ऑनलाइन भुगतान","/rbs/Online_Payment_Form.aspx","",0,20,250);
     Menu2_6=new Array("रद्दीकरण शुल्क","CRCharges.pdf","",0,20,250);
     Menu2_7=new Array("अस्वीकृति शुल्क","CRCharges.pdf","",0,20,250);
     Menu2_8=new Array("प्रयोगशाला शुल्क","","",4,20,250);
		Menu2_8_1=new Array("उत्तरी क्षेत्र","Average Lab Testing Time NR.pdf","",0,20,310);    
		Menu2_8_2=new Array("पश्चिमी क्षेत्र","Average Lab Testing Time WR.pdf","",0,20,310);    
		Menu2_8_3=new Array("दक्षिणी क्षेत्र","Average Lab Testing Time SR.pdf","",0,20,310);    
		Menu2_8_4=new Array("पूर्वी क्षेत्र","Average Lab Testing Time ER.pdf","",0,20,310);    
	 Menu2_9=new Array("विक्रेता प्रतिक्रिया","Vendor_Feedback_Form.aspx","",0,20,250);
     Menu2_10=new Array("सभी क्षेत्रों के बैंक विवरण","BANK DETAILS.PDF","",0,20,250);
     Menu2_11=new Array("मैनुअल निरीक्षण कॉल प्रारूप","Format_For_Inspection_Call.pdf","",0,20,250);
     Menu2_12=new Array("राइट्स का ऑनलाइन निरीक्षण चालान","Online Inspection Invoice of RITES.pdf","",0,20,250);
 Menu3=new Array("ग्राहक इंटरफ़ेस","","",5,20,130);	
	Menu3_1=new Array("लॉग इन करें","Client_Login_Form.aspx","",0,20,250);
	Menu3_2=new Array("विक्रेता प्रदर्शन","Client_Login_Form.aspx","",0,20,250);
	Menu3_3=new Array("आईसी/परीक्षण योजना की डाउनलोडिंग सुविधा के साथ विशिष्ट पीओ/कॉल स्थिति","Client_Login_Form.aspx","",0,40,300);
	Menu3_4=new Array("ग्राहक प्रतिक्रिया","Client_Feedback_Form.aspx","",0,20,250);
	Menu3_5=new Array("ऑनलाइन अस्वीकृति सलाह दर्ज करने की सुविधा","Onliine_Complaints_Form.aspx","",0,30,300);
Menu4=new Array("संपर्क करें","","",6,30,100);
		Menu4_1=new Array("उत्तरी क्षेत्र","NR_ADDRESS.htm","",0,20,200);    
		Menu4_2=new Array("पश्चिमी क्षेत्र","WR_ADDRESS.htm","",0,20,200);    
		Menu4_3=new Array("दक्षिणी क्षेत्र","SR_ADDRESS.htm","",0,20,200);    
		Menu4_4=new Array("पूर्वी क्षेत्र","ER_ADDRESS.htm","",0,20,200);    
		Menu4_5=new Array("केन्द्रीय क्षेत्र","CR_ADDRESS.htm","",0,20,200);   
		Menu4_6=new Array("विदेश निरीक्षण","FR_ADDRESS.htm","",0,20,200);   
Menu5=new Array("त्वरित सम्पक","","",9,30,120);
		Menu5_1=new Array("आईवीआरएस","/rbs/IVRS.pdf","",0,20,250);
		Menu5_2=new Array("ग्राहक लॉगिन","/rbs/Client_Login_Form.aspx","",0,20,250);
		Menu5_3=new Array("विक्रेता लॉगिन","/rbs/Vendor/Vendor_Login_Form.aspx","",0,20,250);
		Menu5_4=new Array("निरीक्षण अभियंता लॉगिन","/rbs/IE_Login_Form.aspx","",0,20,250);
		Menu5_5=new Array("उपयोगकर्ता लॉगिन","/rbs/Login_Form.aspx","",0,20,250);
		Menu5_6=new Array("संपर्क अधिकारी लॉगिन","/rbs/LO_Login_Form.aspx","",0,20,250);
		Menu5_7=new Array("गेटवे के माध्यम से ऑनलाइन भुगतान","/rbs/Online_Payment_Form.aspx","",0,20,250);
		Menu5_8=new Array("प्रतिक्रिया और सुझाव","Email.aspx","",0,20,250);
		Menu5_9=new Array("राइट्स आधिकारिक वेबसाइट","https://rites.com","",0,20,250);

Menu6=new Array("विविध","","",3,20,130);	
			Menu6_1=new Array("सूचना और निर्देश","Instruction_Page_Hindi.aspx","",0,20,250);
			Menu6_2=new Array("फोटो गैलरी","Photo_Gallery_Hindi.aspx","",0,20,250);
			Menu6_3=new Array("क्यूए चैनल (यूट्यूब)","https://youtube.com/channel/UCDhuMds0jhn5t7iX0VMn2zw","",0,20,250);


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

		</script>
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
						<div id="logo_hindi"><a>गुणवत्ता आश्वासन डिवीजन<br>
								<b>(भारत सरकार का एक उपक्रम)
									<br>
									आईएसओ 9001 कंपनी/आईएसओ/आईईसी 17020 के लिए मान्यता<br>
									<FONT size="4PT" color="darkblue">दुनिया भर में व्यापार में एक विश्वसनीय भागीदार</FONT></a>
							<marquee behavior="alternate" style="WIDTH: 658px; HEIGHT: 20px"><b><FONT color="#ff6600">राष्ट्रीय 
										मदद लाइन नंबर :1800 425 7000 (टोल फ्री)</FONT><IMG id="imgad" src="\RBS\images\New_Blinking.gif" border="0"></b></marquee>
						</div>
						<p align="left"><A href="/rbs/MainPage.aspx"><font style="FONT-WEIGHT: bold; FONT-SIZE: 100%; COLOR: green; FONT-FAMILY: Verdana"><U>English 
										Version</U></font></A></p>
						<div id="main"><br>
							<marquee width="100%"><asp:label id="lblLatestMess" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
									Font-Names="Verdana">नोट: कृपया सुनिश्चित करें कि डिलीवरी अवधि समाप्त होने से पहले निरीक्षण कॉल कम से कम सात (7) कार्य दिन पहले जमा कर दी जानी चाहिए, अन्यथा कॉल स्वीकार नहीं किया जाएगी। किसी अपूर्ण निरीक्षण कॉल पर विचार नहीं किया जाएगा.  इसके अलावा विक्रेताओं के परिसर के बाहर प्रयोगशाला परीक्षण की आवश्यकता वाले मामलों में, परीक्षण के लिए आवश्यक अतिरिक्त समय भी प्रदान किया जाना चाहिए।  <Font Color="blue">
										राइट्स लिमिटेड से तुरंत प्रतिक्रिया के लिए, कृपया कॉल प्रारूप में ईमेल-आईडी और 
										संपर्क व्यक्ति का मोबाइल नंबर का उल्लेख करें।</Font><Font Color="Green"> कुछ 
										विक्रेता सीधे भुगतान विवरण और केस विवरणों को सूचित किए बिना राइट्स खाते में 
										डीडी / एनईएफटी के माध्यम से भुगतान जमा कर रहे हैं। सभी विक्रेताओं से अनुरोध है 
										कि वे ई-मेल के माध्यम से हमेशा संबंधित क्षेत्रीय कार्यालय को सूचित करें, ऐसे 
										भुगतान विवरण जो केस नं. के माध्यम से उनके खाते मे जमा किया जाएगा। फीडबैक कॉलम 
										"ritesinsp.com" में पेश किया गया है। सभी उपयोगकर्ताओं से सुविधा का उपयोग करने 
										का अनुरोध किया जाता है।</Font></asp:label></marquee>
							<div id="right">
								<ul style="FONT-SIZE: 10pt; COLOR: darkblue; FONT-FAMILY: trebuchet ms,geneva; LIST-STYLE-TYPE: none">
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									सबसे बड़ी, सबसे पुरानी, बहु-विषयक सरकारी तृतीय पक्ष निरीक्षण (टीपीआई) एजेंसी 
									में &nbsp;&nbsp;&nbsp;&nbsp;से एक
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									47 वर्षों में बहुत समृद्ध अनुभव
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									मैकेनिकल/सिविल/इलेक्ट्रिकल/इलेक्ट्रॉनिक्स आइटम/कंपोनेंट्स असेंबलियों, मशीन 
									&nbsp;&nbsp;&nbsp;&nbsp;प्लांट्स (एम एंड पी), ब्रिज गर्डर्स, ट्रैक आइटम्स आदि 
									सहित सभी इंजीनियरिंग मदों के &nbsp;&nbsp;&nbsp;&nbsp;लिए टीपीआई।
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									विक्रेताओं की क्षमता और क्षमता का आकलन
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									विदेशों में निरीक्षण का समृद्ध अनुभव
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									एनएबीएल द्वारा आईएसओ/आईईसी 17025 से मान्यता प्राप्त प्रयोगशालाओं में सामग्री 
									&nbsp;&nbsp;&nbsp;&nbsp;परीक्षण
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									पांच क्षेत्रीय निरीक्षण कार्यालयों के माध्यम से अखिल भारतीय उपस्थिति
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									देश भर में स्थित 300 से अधिक उच्च योग्य निरीक्षण पेशेवर
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									इन-हाउस सॉफ्टवेयर (आईबीएस) के माध्यम से पारदर्शी टीपीआई निगरानी संचालन
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									समर्पित क्लाइंट लॉगिन के माध्यम से क्लाइंट इंटरफ़ेस
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
									गुणवत्ता पुरस्कार विजेता
									<li>
										<IMG style="WIDTH: 15px; HEIGHT: 10px" border="0" src="\RBS\images\bulletp.png">
										बड़े विविध ग्राहकों के साथ सौदे-सरकारी, सार्वजनिक उपक्रम, राज्य सरकार, स्वायत्त
										<br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;निकाय, निजी क्षेत्र</li></ul>
								<ul>
									<table>
										<tr>
											<td><div id="left"><h3>पुरस्कार</h3>
												</div>
											</td>
											<td><div id="left"><h3>निरीक्षण तस्वीरें</h3>
												</div>
											</td>
										</tr>
										<tr>
											<td width="206" height="165" id="slideShow"><div>
													<img class="mySlides" src="\RBS\images\A12.jpg" width="250" height="250"><img class="mySlides" src="\RBS\images\A13.jpg" width="250" height="250">
													<img class="mySlides" src="\RBS\images\A11.jpg" width="250" height="250"><img class="mySlides" src="\RBS\images\A1.jpg" width="250" height="250">
													<img class="mySlides" src="\RBS\images\A2.jpg" width="250" height="250"><img class="mySlides" src="\RBS\images\A3.jpg" width="250" height="250">
													<img class="mySlides" src="\RBS\images\A4.jpg" width="250" height="250"><img class="mySlides" src="\RBS\images\A5.jpg" width="250" height="250">
													<img class="mySlides" src="\RBS\images\A6.jpg" width="250" height="250"><img class="mySlides" src="\RBS\images\A7.jpg" width="250" height="250">
													<img class="mySlides" src="\RBS\images\A8.jpg" width="250" height="250"><img class="mySlides" src="\RBS\images\A9.jpg" width="250" height="250">
													<img class="mySlides" src="\RBS\images\A10.gif" width="250" height="250"><img class="mySlides" src="\RBS\images\A11.jpg" width="250" height="250">
													<script type="text/javascript">
        var myIndex = 0;
        mySlideShow();
        function mySlideShow() 
        {
            var i;
            var x = document.getElementsByClassName("mySlides");
            for (i = 0; i < x.length; i++) {
               x[i].style.display = "none";  
            }
            myIndex++;
            if (myIndex > x.length) {myIndex = 1}    
            x[myIndex-1].style.display = "block";  
            setTimeout(mySlideShow, 3000); // Change image every 2 seconds
        }
													</script>
												</div>
											</td>
											<td width="206" height="165" id="slideShow1"><div>
													<img class="mySlides1" src="\RBS\images\insp11.jpeg" width="250" height="250"> <img class="mySlides1" src="\RBS\images\insp13.jpg" width="250" height="250">
													<img class="mySlides1" src="\RBS\images\insp4.jpg" width="250" height="250"> <img class="mySlides1" src="\RBS\images\insp5.jpg" width="250" height="250">
													<img class="mySlides1" src="\RBS\images\insp6.jpeg" width="250" height="250"> <img class="mySlides1" src="\RBS\images\insp7.jpeg" width="250" height="250">
													<img class="mySlides1" src="\RBS\images\insp8.jpeg" width="250" height="250"> <img class="mySlides1" src="\RBS\images\insp9.jpeg" width="250" height="250">
													<img class="mySlides1" src="\RBS\images\insp10.jpeg" width="250" height="250"> <img class="mySlides1" src="\RBS\images\insp18.jpg" width="250" height="250">
													<img class="mySlides1" src="\RBS\images\insp19.jpg" width="250" height="250"> <img class="mySlides1" src="\RBS\images\insp18.jpg" width="250" height="250">
													<img class="mySlides1" src="\RBS\images\insp15.jpg" width="250" height="250"> <img class="mySlides1" src="\RBS\images\insp16.jpg" width="250" height="250">
													<script type="text/javascript">
        var myIndex1 = 0;
        mySlideShow1();
        function mySlideShow1() 
        {
            var i;
            var x = document.getElementsByClassName("mySlides1");
            for (i = 0; i < x.length; i++) {
               x[i].style.display = "none";  
            }
            myIndex1++;
            if (myIndex1 > x.length) {myIndex1 = 1}    
            x[myIndex1-1].style.display = "block";  
            setTimeout(mySlideShow1, 3000); // Change image every 2 seconds
        }
                                                    </script>
												</div>
											</td>
										</tr>
									</table>
								</ul>
								<UL>
								</UL>
							</div>
						</div>
						<div id="left">
							<h3>प्रमाणपत्र</h3>
							<table>
								<tr>
									<td align="center" width="200" height="165"><a href="\RBS\images\ISO 9001.jpg" target="_blank" style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BACKGROUND-COLOR: transparent"><IMG src="\RBS\images\ISO 9001.jpg" style="WIDTH: 180px; POSITION: static; HEIGHT: 140px"></a><br>
										<font style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: black; FONT-FAMILY: Verdana">
											<b>आईएसओ 9001:2015 प्रमाणन</b></font><br>
										<a href="\RBS\images\IEC 17020 2012.jpg" target="_blank" style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BACKGROUND-COLOR: transparent">
											<IMG src="\RBS\images\IEC 17020 2012.jpg" style="WIDTH: 180px; POSITION: static; HEIGHT: 140px"></a><br>
										<font style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: magenta; FONT-FAMILY: Verdana">
											<b>आईएसओ/आईईसी 17020:2012 प्रत्यायन </b></font>
										<br>
										<IMG src="\RBS\images\IEC 17025 2005.jpg" style="WIDTH: 180px; POSITION: static; HEIGHT: 140px"><br>
										<font style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: darkblue; FONT-FAMILY: Verdana">
											<b>आईएसओ/आईईसी 17025 मान्यता प्राप्त लैब्स </b></font>
									</td>
								</tr>
							</table>
						</div>
						<div style="CLEAR: both"></div>
						<!--content ends -->
						<!--footer begins --></div>
					<div id="footer">
						<p>राइट्स आईटी डिवीजन, उत्तरी क्षेत्र द्वारा डिजाइन और विकसित
						</p>
					</div>
				</div>
			</div>
			<DIV></DIV>
			<!-- footer ends--></form>
		<DIV></DIV>
		</FONT></B>
	</body>
</HTML>
