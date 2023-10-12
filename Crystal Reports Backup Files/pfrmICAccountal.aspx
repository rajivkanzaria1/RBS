<%@ Page language="c#" Codebehind="pfrmICAccountal.aspx.cs" AutoEventWireup="false" Inherits="RBS.Reports.pfrmICAccountal" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>rptICAccountal</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="../date.js"></script>
		<script language="javascript">
		function validate()
			{
				if(trimAll(document.Form1.txtDtFr.value)=="" || trimAll(document.Form1.txtDtTo.value)=="")
					{
						alert("From & To Dates must be entered.");
						event.returnValue=false;	
					}
			}
        </script>
</HEAD>
	<body onload="document.Form1.txtDtFr.focus()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Visible="False" Height="1px" Width="100%">
<asp:Button id=btnPrint runat="server" Text="Print"></asp:Button>
<asp:Button id=btnBack runat="server" Text="Go Back"></asp:Button>
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Height="1px" Width="100%">
<TABLE id=Table1 style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" 
cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR>
    <TD style="WIDTH: 100%" align=center colSpan=2>
<uc1:webusercontrol1 id=WebUserControl11 runat="server"></uc1:webusercontrol1></TD></TR>
  <TR>
    <TD style="WIDTH: 100%; HEIGHT: 27px" align=center colSpan=2><FONT 
      face=Verdana color=darkblue size=3><B>IC ACCOUNTAL 
  STATEMENT</B></FONT></TD></TR>
  <TR bgColor=#f0f8ff>
    <TD style="WIDTH: 12.07%; HEIGHT: 31px" align=center><FONT face=Verdana 
      color=darkblue size=2>
<asp:label id=lblSIE runat="server" Width="161px" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt">Status of IE </asp:label></FONT></TD>
    <TD style="WIDTH: 10%; HEIGHT: 31px" align=center>
      <TABLE id=Table2 height="100%" cellSpacing=1 cellPadding=1 width="100%" 
      border=0>
        <TR>
          <TD>
<asp:radiobutton id=rdbAll runat="server" Text="ALL IE's" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="10pt" GroupName="g1" AutoPostBack="True" Checked="True"></asp:radiobutton></TD>
          <TD>
<asp:radiobutton id=rdbGIE runat="server" Text="For Particular IE" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="10pt" GroupName="g1" AutoPostBack="True"></asp:radiobutton></TD></TR></TABLE></TD></TR>
  <TR bgColor=#f0f8ff>
    <TD style="WIDTH: 12.07%; HEIGHT: 30px" align=center><FONT face=Verdana 
      color=darkblue size=2>
<asp:label id=lblIE runat="server" Width="42px" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt">IE </asp:label></FONT></TD>
    <TD style="HEIGHT: 30px">
<asp:dropdownlist id=lstIE tabIndex=5 runat="server" Width="50%" Height="25px" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"></asp:dropdownlist></FONT></TD></TR>
  <TR bgColor=aliceblue>
    <TD style="WIDTH: 100%; HEIGHT: 100px" align=center colSpan=2>
      <P>
<asp:label id=Label1 runat="server" Width="459px">
									<Font face="Verdana" color="DarkBlue" size="2"><b>Report For The Books Issued In The 
											Period -------> From </b></Font>
								</asp:label>
<asp:textbox id=txtDtFr onblur="check_date(txtDtFr);compareDates(txtDtFr,txtDtTo,'[From Date] cannot Be greater than [To Date]')" runat="server" Width="87px">01/04/2008</asp:textbox>&nbsp;&nbsp; 
      <FONT face=Verdana color=darkblue size=2><B>To&nbsp;&nbsp;&nbsp; 
<asp:textbox id=txtDtTo onblur="check_date(txtDtTo);compareDates(txtDtFr,txtDtTo,'[From Date] cannot Be greater than [To Date]')" runat="server" Width="87px"></asp:textbox></B></FONT></P>
      <P><FONT face=Verdana color=darkmagenta size=2><B>(enter date 
      in&nbsp;&nbsp;&nbsp; DD/MM/YYYY&nbsp;&nbsp; format)</P></B></FONT></TD></TR><% if (txtRegion.Text=="N")
					{ %>
  <TR>
    <TD style="WIDTH: 100%; HEIGHT: 36px" noWrap align=center bgColor=aliceblue 
    colSpan=2><FONT face=Verdana color=mediumorchid size=1>Do you want to 
      print the message [7th copy received/not-received] in case&nbsp;where the 
      Books are completed but not submitted --&gt;&nbsp; 
<asp:dropdownlist id=lstYESNO tabIndex=6 runat="server" Width="49px" Height="25%" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt">
<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
<asp:ListItem Value="N">No</asp:ListItem>
</asp:dropdownlist>&nbsp;&nbsp;&nbsp;</FONT></TD></TR><%}
					else
					{ %>
  <TR>
    <TD style="WIDTH: 100%; HEIGHT: 36px" noWrap align=center bgColor=aliceblue 
    colSpan=2><FONT face=Verdana color=mediumorchid size=1><B>Cancelled / Lost 
      IC's to be included in the list&nbsp;where Completed Book Sets are not 
      Submitted&nbsp; --&gt;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
<asp:RadioButton id=rdbCancelYes runat="server" Text="Yes" GroupName="grpLostCancel"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:RadioButton id=rdbCancelNo runat="server" Text="No" GroupName="grpLostCancel"></asp:RadioButton></B></FONT></TD></TR><%}%>
  <TR>
    <TD style="WIDTH: 100%; HEIGHT: 36px" noWrap align=center bgColor=aliceblue 
    colSpan=2>
<asp:TextBox id=txtRegion runat="server" Width="2px" Visible="False"></asp:TextBox>
<asp:button id=btnSubmit runat="server" Text="Submit" ForeColor="DarkBlue" Font-Bold="True" BackColor="#C0C0FF"></asp:button></TD></TR></TABLE>
			</asp:panel>&gt;
		</form></SCRIPT>
	</body>
</HTML>

