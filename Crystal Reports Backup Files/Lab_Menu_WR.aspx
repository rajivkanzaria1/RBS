<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab_Menu_WR.aspx.cs" Inherits="RBS.Lab_Menu_WR.Lab_Menu_WR" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lab_Menu</title>
		<script type='text/javascript'>
	var NoOffFirstLineMenus=5;			// Number of first level items
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
  Menu1=new Array("Generate Lab Invoice","LAB_INVOICE_WR.aspx","",0,20,150);  
  Menu2=new Array("Lab Invoice Report","Reports/pfrmFromToDate.aspx?action=LABR","",0,20,200);	
  Menu3=new Array("Lab Invoice Finalisation","LAB_Bill_Finalisation_Form.aspx","",0,20,150);
  Menu4=new Array("Lab Sample Payment Aprrove Form","Lab_Sample_Info.aspx","",0,20,150);
  Menu5=new Array("Lab Sample Payment Approval Report","Reports/Rpt_lab_sample_info.aspx","",0,20,250);  
  //Menu2=new Array("Download Lab Invoice Report","Reports/pfrmFromToDate.aspx?action=LABR","",0,20,200);
  
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
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
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
					<td valign="top" align="center" style="WIDTH: 100%;HEIGHT: 80%">
						<P><FONT style="FONT-WEIGHT: bold; LINE-HEIGHT: 8pt; TEXT-ALIGN: center" color="darkblue"
								size="3">MAIN MENU</FONT></P>
						<P>&nbsp;</P>
					</td>
				</TR>
				<TR>
					<td align="center" valign="top" style="WIDTH: 100%;HEIGHT: 10%">
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
