<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendor_Menu.aspx.cs" Inherits="RBS.Vendor.Vendor_Menu" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl_Vend" Src="~/Vendor/WebUserControl_Vend.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Menu Selection Screen</title>
		<script type="text/javascript">
	var NoOffFirstLineMenus=10;			// Number of first level items
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
	var StartTop=140;				// Menu offset x coordinate
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
  Menu1=new Array("Vendor Details","","",2,35,70);
  Menu1_1=new Array("Vendor Profile","Vendor_Vendor_Form.aspx?ACTION=M","",0,20,150);
  Menu1_2=new Array("Upload Documents","Vendor_Document_Form.aspx","",0,20,150);
  Menu2=new Array("PO/Contracts Registration","Vendor_PurchesOrder1_Form.aspx","",0,35,100);
  Menu3=new Array("Call For Inspection","Vendor_Call_Register_Edit.aspx","",0,35,100);
  Menu4=new Array("Add New Items in Already Registered LOA","PurchesOrder1_LOA.aspx","",0,35,150);
  Menu5=new Array("Registered Pending Calls Off Qty Enhancement Form","Call_Register_Edit.aspx","",0,35,200);
  Menu6=new Array("Inspection Fee Bill","Download_Inspection_Fee_Bill.aspx","",0,35,100);
  Menu7=new Array("Specific PO Call/IC Status","","",2,35,100);
  Menu7_1=new Array("Specific PO Call Status","Vendor_Calls_Marked_For_Specific_PO.aspx?ACTION=C","",0,20,150);
  Menu7_2=new Array("Specific PO IC Status","Vendor_Calls_Marked_For_Specific_PO.aspx?ACTION=I","",0,20,150);
  Menu8=new Array("Lab Invoice","LAB_Invoice_Download.aspx","",0,35,100);
  Menu9=new Array("Add MA","Vendor_PO_MA.aspx","",0,35,100);
  Menu10=new Array("Lab Sample Payment","Lab_Payment_Form.aspx","",0,35,100);
//*********************** Ending of Menu *******************************
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
	<body text="navy" MS_POSITIONING="GridLayout">
		<script type="text/javascript">
			function Go(){return}
        </script>
		<script src="../menu_com.js" type="text/javascript"></script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 100%"
				cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 4.28%" align="center">
						<P><uc1:webusercontrol_vend id="WebUserControl_Vend1" runat="server"></uc1:webusercontrol_vend></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 4.28%" align="center">
						<marquee width="100%"><asp:label id="lblLatestMess" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
								Font-Bold="True">Note: Now, the RITES Inspection Fees Invoice can be downloaded online from your Vendor Portal. </Font><Font Color="Green">(MainMenu=>Inspection 
									Fee Bill)</Font></asp:label></marquee>
					</TD>
				</TR>
				<TR>
					<td style="WIDTH: 100%; HEIGHT: 80%" vAlign="top" align="center">
						<P><FONT style="FONT-WEIGHT: bold; LINE-HEIGHT: 8pt; TEXT-ALIGN: center" face="Verdana" color="darkblue"
								size="3">MAIN MENU</FONT><br>
							<br>
						</P>
					</td>
				</TR>
				<TR>
					<td align="center" valign="top" style="WIDTH: 100%;HEIGHT: 10%">
						<P style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: red; FONT-FAMILY: Verdana; TEXT-ALIGN: left; TEXT-DECORATION: underline">Attention:</P>
						<P style="FONT-SIZE: 8pt; COLOR: red; FONT-FAMILY: Verdana; TEXT-ALIGN: justify">
							1.&nbsp;Please note that calls submitted on Saturdays (After&nbsp;3 P.M.), 
							Sundays and on Holidays shall be marked only on next working day.</P>
						<P style="FONT-SIZE: 8pt; COLOR: red; FONT-FAMILY: Verdana; TEXT-ALIGN: justify">
							2.&nbsp;Calls recieved upto 3 P.M. shall be marked on same day and calls 
							recieved after 3 P.M. shall be marked on next working day&nbsp;except Saturday. 
							<!--</MARQUEE>--></P>
						<!--<P style="FONT-SIZE: 8pt; COLOR: red; FONT-FAMILY: Verdana; TEXT-ALIGN: justify">
							3.&nbsp;Please note one additional FAX No. 011-22029122 is also made 
							operational to recieve Calls.</P>-->
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>