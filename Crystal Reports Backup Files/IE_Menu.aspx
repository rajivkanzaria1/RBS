<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_Menu.aspx.cs" Inherits="RBS.IE_Menu.IE_Menu" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Menu Selection Screen</title>
		<script type='text/javascript'>
	var NoOffFirstLineMenus=4;			// Number of first level items
	var LowBgColor='#dce4f6';			// Background color when mouse is not over
	var LowSubBgColor='#dce4f6';			// Background color when mouse is not over on subs
	var HighBgColor='#87cefa';			// Background color when mouse is over
	var HighSubBgColor='#87cefa';			// Background color when mouse is over on subs
	var FontLowColor='#00008b';			// Font color when mouse is not over
	var FontSubLowColor='#00008b';			// Font color subs when mouse is not over
	var FontHighColor='#00008b';			// Font color when mouse is over
	var FontSubHighColor='#00008b';			// Font color subs when mouse is over
	var BorderColor='#00008b';			// Border color
	var BorderSubColor='#63639C';			// Border color for subs
	var BorderWidth=2;				// Border width
	var BorderBtwnElmnts=1;			// Border between elements 1 or 0
	var FontFamily="verdana"	// Font family menu items
	var FontSize=8;				// Font size menu items
	var FontBold=0;				// Bold menu items 1 or 0
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
 Menu1=new Array("Calls Status","","",2,20,150);
	 Menu1_1=new Array("Sorted on Call Date","Calls_Marked_To_IE.aspx?ACTION=C","",0,20,150);
     Menu1_2=new Array("Sorted On Vendor","Calls_Marked_To_IE.aspx?ACTION=V","",0,20,150);
  Menu2=new Array("Transactions","","",11,20,150);
  	Menu2_1=new Array("Daily Work Plan","IE_Daily_Work_Plan.aspx","",0,20,200);
  	Menu2_2=new Array("Pending JI Complaints for IE Remarks","IE_JI_Remarks_Pending_Form.aspx","",0,35,200);
  	Menu2_3=new Array("Edit NCR","IE_NC_Edit_Form.aspx?Action=M","",0,20,200);  
	Menu2_4=new Array("Download/View Photo Enclosed","IE_IC_Photo_Enclosed.aspx","",0,20,200); 
  	Menu2_5=new Array("Download Documents","Download_Documents.aspx?allowDL=Y","",0,20,150);
  	Menu2_6=new Array("Download Corporate Instructions","Download_Documents.aspx?allowDL=Y&Action=CI","",0,20,250);
  	Menu2_7=new Array("Master Items List","Master_Items_Form.aspx","",0,20,150);
  	Menu2_8=new Array("QA Video General","","",18,20,150);
  	 Menu2_8_1=new Array("Instructional video on Calibration","QA_VEDIO.aspx?ACTION=V7","",0,20,200);
  	 Menu2_8_2=new Array("Inspection of HDPE PIPE","QA_VEDIO.aspx?ACTION=V13","",0,20,200);
  	 Menu2_8_3=new Array("MICROMETER","QA_VEDIO.aspx?ACTION=V29","",0,20,200);
  	 Menu2_8_4=new Array("MIGRATION TO STANDARD CHECK SHEETS IN RAILWAY & NON INSPECTIONS","QA_VEDIO.aspx?ACTION=V30","",0,40,200);
  	 Menu2_8_5=new Array("NDT","QA_VEDIO.aspx?ACTION=V31","",0,20,200);
  	 Menu2_8_6=new Array("pie tape instructional video","QA_VEDIO.aspx?ACTION=V32","",0,20,200);
  	 Menu2_8_7=new Array("Sampling ,  Inspection & Testing procedures","QA_VEDIO.aspx?ACTION=V34","",0,20,200);
  	 Menu2_8_8=new Array("special  test plans","QA_VEDIO.aspx?ACTION=V38","",0,20,200);
  	 Menu2_8_9=new Array("Teaser for launch of E Book on Painting process","QA_VEDIO.aspx?ACTION=V41","",0,30,200);
  	 Menu2_8_10=new Array("ICF Innovations Continue Forever","QA_VEDIO.aspx?ACTION=V47","",0,20,200);
  	 Menu2_8_11=new Array("VENDOR Assesment carried out By RITES for NSIC","QA_VEDIO.aspx?ACTION=V62","",0,30,200);
  	 Menu2_8_12=new Array("hardness Test","QA_VEDIO.aspx?ACTION=V66","",0,20,200);
  	 Menu2_8_13=new Array("HDPE pipe Mfg process","QA_VEDIO.aspx?ACTION=V67","",0,20,200);
  	 Menu2_8_14=new Array("Highlights","QA_VEDIO.aspx?ACTION=V70","",0,20,200);
  	 Menu2_8_15=new Array("HPCR","QA_VEDIO.aspx?ACTION=V72","",0,20,200);
  	 Menu2_8_16=new Array("drg altn revn0","QA_VEDIO.aspx?ACTION=V80","",0,20,200);
  	 Menu2_8_17=new Array("ED-QA New Year message","QA_VEDIO.aspx?ACTION=V81","",0,20,200);
  	 Menu2_8_18=new Array("FAD OF COMPRESSORS","QA_VEDIO.aspx?ACTION=V83","",0,20,200);
  	Menu2_9=new Array("QA Video Mechanical","","",36,20,150);
  	   Menu2_9_1=new Array("Fire Retardant Toxicity","QA_VEDIO.aspx?ACTION=V1","",0,20,300);
  	   Menu2_9_2=new Array("Inspection of fire Retardant Properties limiting of Oxygen","QA_VEDIO.aspx?ACTION=V2","",0,30,300);
  	   Menu2_9_3=new Array("Inspection of Axle For The Wheel Disc of Rail Coach & Wagon","QA_VEDIO.aspx?ACTION=V3","",0,30,300);
  	   Menu2_9_4=new Array("Inspection of Wheel disc for Railway rolling stock","QA_VEDIO.aspx?ACTION=V5","",0,30,300);
  	   Menu2_9_5=new Array("Inspection of Wheel Set (Two wheel and one Axle) for Railway rolling stock","QA_VEDIO.aspx?ACTION=V6","",0,30,300);
  	   Menu2_9_6=new Array("About welding symbols","QA_VEDIO.aspx?ACTION=V11","",0,20,300);
  	   Menu2_9_7=new Array("INSPECTION on COMPRESSOR","QA_VEDIO.aspx?ACTION=V17","",0,20,300);
  	   Menu2_9_8=new Array("Instructional Video on Limits , Tolerances , Fits and Deviation","QA_VEDIO.aspx?ACTION=V19","",0,30,300);
  	   Menu2_9_9=new Array("Instructional video on working of BIO-TOILETs on Passenger coaches of Indian Railways","QA_VEDIO.aspx?ACTION=V20","",0,30,300);
  	   Menu2_9_10=new Array("LHB spring manufacturing","QA_VEDIO.aspx?ACTION=V23","",0,20,200);
  	   Menu2_9_11=new Array("Manufacturing and inspection of Graphite mould block","QA_VEDIO.aspx?ACTION=V26","",0,30,300);
  	   Menu2_9_12=new Array("Manufacturing Process and testing-Inspection of Spheroidal Graphite Cast Iron Inserts (SGCI) Inserts","QA_VEDIO.aspx?ACTION=V27","",0,30,300);
  	   Menu2_9_13=new Array("Manufcature ,Testing and Inspection of Base for Point machine","QA_VEDIO.aspx?ACTION=V28","",0,30,300);
  	   Menu2_9_14=new Array("sidewall undulation","QA_VEDIO.aspx?ACTION=V35","",0,20,300);
  	   Menu2_9_15=new Array("Solid Railway Gear Wheel Blank Gear  Pinion Blank Forgings  Proof Machined Gear","QA_VEDIO.aspx?ACTION=V36","",0,30,300);
  	   Menu2_9_16=new Array("Special  Process- Laser seam welding of Rail Coach Side wall sheets and its validation","QA_VEDIO.aspx?ACTION=V37","",0,30,300);
  	   Menu2_9_17=new Array("special process","QA_VEDIO.aspx?ACTION=V39","",0,20,300);
  	   Menu2_9_18=new Array("surface finish","QA_VEDIO.aspx?ACTION=V40","",0,20,300);
  	   Menu2_9_19=new Array("Testing and Inspection Methods of the Ready Mixed Paint (Red Oxide Primer)","QA_VEDIO.aspx?ACTION=V42","",0,30,300);
  	   Menu2_9_20=new Array("Thick Web Switch","QA_VEDIO.aspx?ACTION=V45","",0,20,300);
  	   Menu2_9_21=new Array("HRR","QA_VEDIO.aspx?ACTION=V46","",0,20,300);
  	   Menu2_9_22=new Array("INSPECTION  SPUR GEAR","QA_VEDIO.aspx?ACTION=V49","",0,20,300);
  	   Menu2_9_23=new Array("Inspection and testing of Coil Spring for Fiat bogies of LHB  Coaches","QA_VEDIO.aspx?ACTION=V50","",0,30,300);
  	   Menu2_9_24=new Array("Inspection of Fire retardant Properties   Spread of Flame","QA_VEDIO.aspx?ACTION=V54","",0,30,300);
  	   Menu2_9_25=new Array("Inspection of girder during welding _ fabrication","QA_VEDIO.aspx?ACTION=V55","",0,30,300);
  	   Menu2_9_26=new Array("INSPECTION OF GIRDERS- Inspection Before Welding_ Fabrication","QA_VEDIO.aspx?ACTION=V56","",0,30,300);
  	   Menu2_9_27=new Array("Girder inspection after welding _ fabrication","QA_VEDIO.aspx?ACTION=V59","",0,20,300);
  	   Menu2_9_28=new Array("Good Manufacturing Practices in Rail coach Body Building","QA_VEDIO.aspx?ACTION=V60","",0,20,300);
  	   Menu2_9_29=new Array("Welding Procedure Specificaion WPS","QA_VEDIO.aspx?ACTION=V64","",0,20,300);
  	   Menu2_9_30=new Array("heat treatment","QA_VEDIO.aspx?ACTION=V69","",0,20,300);
  	   Menu2_9_31=new Array("Honing and testing","QA_VEDIO.aspx?ACTION=V71","",0,20,300);
  	   Menu2_9_32=new Array("Chemical testing","QA_VEDIO.aspx?ACTION=V76","",0,20,300);
  	   Menu2_9_33=new Array("Coating Failures & Defects","QA_VEDIO.aspx?ACTION=V77","",0,20,300);
  	   Menu2_9_34=new Array("Deterioration of  Visibility due to smoke","QA_VEDIO.aspx?ACTION=V78","",0,20,300);
  	   Menu2_9_35=new Array("do&dont's of IEs'","QA_VEDIO.aspx?ACTION=V79","",0,20,300);
  	   Menu2_9_36=new Array("ABOUT STEEL BRIDGE GIRDERS","QA_VEDIO.aspx?ACTION=V8","",0,20,300);
  	Menu2_10=new Array("QA Video Electrical","","",17,20,150);
  	   Menu2_10_1=new Array("Inspection of High Drawn Grooved Copper Contact wire 107sq.mm","QA_VEDIO.aspx?ACTION=V4","",0,30,200);
  	   Menu2_10_2=new Array("About the working principle and construction features of Distribution Transformers.","QA_VEDIO.aspx?ACTION=V10","",0,40,200);
  	   Menu2_10_3=new Array("Acceptance testing process of Brushless DC Railway carriage (sensor less)","QA_VEDIO.aspx?ACTION=V12","",0,30,200);
  	   Menu2_10_4=new Array("LED LIGHT FITTING TYPE-B1 (9W) - NON AC Rail Coaches of Conventional  and LHB Types","QA_VEDIO.aspx?ACTION=V22","",0,40,200);
  	   Menu2_10_5=new Array("Manufacturing and Inspection of Armature Shaft(Traction Motor )","QA_VEDIO.aspx?ACTION=V24","",0,30,200);
  	   Menu2_10_6=new Array("Railway Electrical Traction catenary Wire testing","QA_VEDIO.aspx?ACTION=V33","",0,30,200);
  	   Menu2_10_7=new Array("Testing procedure of XLPE Cables -NR","QA_VEDIO.aspx?ACTION=V43","",0,30,200);
  	   Menu2_10_8=new Array("Inspection - Railway Traction Insulator","QA_VEDIO.aspx?ACTION=V48","",0,30,200);
  	   Menu2_10_9=new Array("INSPECTION ELECTRICAL ITEMS","QA_VEDIO.aspx?ACTION=V51","",0,30,200);
  	   Menu2_10_10=new Array("Transformer Oil cooler inspection","QA_VEDIO.aspx?ACTION=V57","",0,30,200);
  	   Menu2_10_11=new Array("VACUUM CIRCUIT BREAKER AND INTERRUPTER","QA_VEDIO.aspx?ACTION=V61","",0,30,200);
  	   Menu2_10_12=new Array("VRLA battery Testing & Inspection","QA_VEDIO.aspx?ACTION=V63","",0,30,200);
  	   Menu2_10_13=new Array("Constructional Features, Testing and Inspection of EBeam Cable","QA_VEDIO.aspx?ACTION=V73","",0,40,200);
  	   Menu2_10_14=new Array("BEE DOMESTIC Appliances Energy rating","QA_VEDIO.aspx?ACTION=V74","",0,30,200);
  	   Menu2_10_15=new Array("BEE ENERGY RATING industrial appliances","QA_VEDIO.aspx?ACTION=V75","",0,30,200);
  	   Menu2_10_16=new Array("Electrical Cable Construction, Inspection  and testing methods","QA_VEDIO.aspx?ACTION=V82","",0,30,200);
  	   Menu2_10_17=new Array("About the construction features of VRLA Batteries used in PASSENGER COACHES OF INDIAN RAILWAYS","QA_VEDIO.aspx?ACTION=V9","",0,40,200);  	
  	Menu2_11=new Array("QA Video Civil","","",3,20,150);
  	  Menu2_11_1=new Array("Instructional Video-1 on Points and Crossings","QA_VEDIO.aspx?ACTION=V21","",0,30,200);
  	  Menu2_11_2=new Array("Manufacturing and inspection of Glass filled NYLON-66 Insulating Liners","QA_VEDIO.aspx?ACTION=V25","",0,40,200);
  	  Menu2_11_3=new Array("Glued Insulated Rail Joint","QA_VEDIO.aspx?ACTION=V65","",0,30,200);
  Menu3=new Array("Reports","","",10,20,150);
	Menu3_1=new Array("IE Performance","Reports/pfrmFromToDate.aspx?action=IE_X","",0,20,250);
	Menu3_2=new Array("Inspection Billing & Delays","Reports/rptInspBillingDelay.aspx?ACTION=I","",0,20,250);
	Menu3_3=new Array("IE Claim Report","Reports/pfrmIEClaimReport.aspx","",0,20,250);
	Menu3_4=new Array("IE WorkPlan Report","Reports/pfrmIEWorkPlan.aspx?ACTION=I","",0,20,250);
	Menu3_5=new Array("Consignee Complaints Report","Reports/pfrmCompliants.aspx?ACTION=I","",0,20,250);
	Menu3_6=new Array("Pending JI Cases","Reports/pfrmFromToDate.aspx?action=PJI","",0,20,250);
	Menu3_7=new Array("IC Issued but Not Received in Office","Reports/pfrmFromToDate.aspx?ACTION=ICISSUEDNSUB","",0,20,250);
	Menu3_8=new Array("Contracts","contracts.pdf","",0,20,250);
	Menu3_9=new Array("IE Dairy","Reports/pfrmIEDairy.aspx","",0,20,250);
	Menu3_10=new Array("IC Book Set 7th Copy Report","Reports/pfrmIE7thCopy.aspx","",0,20,250);
  Menu4=new Array("QA MANUAL & PROCEDURES","Quality_Manual_Procedures.aspx","",0,20,170);	   
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
	</HEAD>
	<body text="navy">
		<script type='text/javascript'>

//HV Menu- by Ger Versluis (http://www.burmees.nl/)
//Submitted to Dynamic Drive (http://www.dynamicdrive.com)
//Visit http://www.dynamicdrive.com for this script and more

function Go(){return}

        </script>
		<script type='text/javascript' src='menu_com.js'></script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 100%"
				cellSpacing="1" cellPadding="1" width="100%" border="0" align="center">
				<TR>
					<TD align="center" style="WIDTH: 100%;HEIGHT: 10%">
						<P>
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1>
						</P>
					</TD>
				</TR>
				<TR>
					<td align="center" valign="top" style="WIDTH: 100%;HEIGHT: 80%">
						<P><FONT style="FONT-WEIGHT: bold; LINE-HEIGHT: 8pt; TEXT-ALIGN: center" color="darkblue"
								size="3">MAIN MENU</FONT></P>
						<P>&nbsp;</P>
					</td>
				</TR>
				<TR>
					<td align="center"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
							ForeColor="OrangeRed" Width="480px" Visible="False">CALLS WITH LESS THEN OR EQUAL TO 7 DAYS IN DP TO EXPIRE!!!</asp:label>
						<DIV><TITTLE:CUSTOMDATAGRID id="grdDPCalls" runat="server" Width="80%" Height="8px" HorizontalAlign="Center"
								PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
								BorderColor="DarkBlue" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False"
								GridHeight="220px" GridWidth="100%">
								<PagerStyle NextPageText="Next" PrevPageText="Prev" HorizontalAlign="Center" ForeColor="Blue"
									Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%"
									ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="CASE_NO" HeaderText="CASE NO">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_DT" HeaderText="CALL DT">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_SNO" HeaderText="SNO">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VENDOR" HeaderText="VENDOR">
										<HeaderStyle Width="60%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</td>
				</TR>
				<TR>
					<td align="center" valign="top" style="WIDTH: 100%;HEIGHT: 10%">
						<P>
							<MARQUEE id="m1" dataFormatAs="html" style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; FONT-FAMILY: Verdana; HEIGHT: 100%; TEXT-ALIGN: center"
								scrollDelay="125" width="90%">
								<P>
									<asp:label id="lblMessage" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">We at RITES, extend our heartiest greetings on this special day. May God bless you with happiness and prosperity all through the coming year. <B>
											Many Happy returns of the day. HAPPY BIRTHDAY !!! (QA Division)</B> </Font></asp:label></P>
							</MARQUEE>
						</P>
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
