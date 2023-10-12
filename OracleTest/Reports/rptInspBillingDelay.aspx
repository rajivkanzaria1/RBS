<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptInspBillingDelay.aspx.cs" Inherits="RBS.Reports.rptInspBillingDelay" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<%--<%@ Page language="c#" Codebehind="rptInspBillingDelay.aspx.cs" AutoEventWireup="false" Inherits="RBS.rptInspBillingDelay" %>--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>rptInspBilling</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="../date.js"></script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="False">
<asp:Button id=btnPrint runat="server" Text="Print"></asp:Button><INPUT id=Button1 onclick=history.go(-1) type=button value="Go Back" name=Button1>
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="48px">
<TABLE id=Table1 
style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px" 
cellSpacing=0 cellPadding=0 border=0>
  <TR>
    <TD style="HEIGHT: 14px" align=center colSpan=3>
<uc1:WebUserControl1 id=WebUserControl11 runat="server"></uc1:WebUserControl1></TD></TR>
  <TR>
    <TD style="WIDTH: 13.17%; HEIGHT: 21px" align=center colSpan=3>
<asp:label id=Label5 runat="server" Width="100%" Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" Font-Size="10pt">STATEMENT OF INSPECTION BILLING  & DELAY'S</asp:label></TD></TR>
  <TR bgColor=#f0f8ff>
    <TD style="WIDTH: 40%; HEIGHT: 56px" align=center></TD>
    <TD style="WIDTH: 10%; HEIGHT: 56px">
<asp:label id=lblFrom runat="server" Width="40%" Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt">From</asp:label></TD>
    <TD style="WIDTH: 30%; HEIGHT: 56px">
<asp:label id=lblTo runat="server" Width="40%" Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt">To</asp:label></TD></TR>
  <TR bgColor=#f0f8ff>
    <TD style="WIDTH: 40%; HEIGHT: 56px" align=left><B><FONT face=Verdana 
      color=darkblue size=2>
<asp:RadioButton id=rdbMon tabIndex=1 runat="server" Text="Inspection Billing For The Month -->" AutoPostBack="True" GroupName="g1"></asp:RadioButton></FONT></B></TD>
    <TD style="WIDTH: 10%; HEIGHT: 56px">
<asp:dropdownlist id=lstMonths tabIndex=3 runat="server" Font-Names="Verdana" ForeColor="DarkBlue" Font-Size="8pt">
								<asp:ListItem Value="01" Selected="True">January</asp:ListItem>
								<asp:ListItem Value="02">February</asp:ListItem>
								<asp:ListItem Value="03">March</asp:ListItem>
								<asp:ListItem Value="04">April</asp:ListItem>
								<asp:ListItem Value="05">May</asp:ListItem>
								<asp:ListItem Value="06">June</asp:ListItem>
								<asp:ListItem Value="07">July</asp:ListItem>
								<asp:ListItem Value="08">August</asp:ListItem>
								<asp:ListItem Value="09">September</asp:ListItem>
								<asp:ListItem Value="10">October</asp:ListItem>
								<asp:ListItem Value="11">November</asp:ListItem>
								<asp:ListItem Value="12">December</asp:ListItem>
							</asp:dropdownlist></TD>
    <TD style="WIDTH: 30%; HEIGHT: 56px">
<asp:dropdownlist id=lstYear tabIndex=4 runat="server" Font-Names="Verdana" ForeColor="DarkBlue" Font-Size="8pt"></asp:dropdownlist></TD></TR>
  <TR bgColor=#f0f8ff>
    <TD style="WIDTH: 33.09%; HEIGHT: 52px" align=left><B><FONT face=Verdana 
      color=darkblue size=2>
<asp:RadioButton id=rdbPer tabIndex=2 runat="server" Text="Inspection Billing For The Period (DD/MM/YYYY) -->" AutoPostBack="True" GroupName="g1"></asp:RadioButton></FONT></B></TD>
    <TD style="WIDTH: 13.97%; HEIGHT: 52px">
<asp:textbox id=frmDt onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');" style="TEXT-ALIGN: center" tabIndex=5 runat="server" Height="20px" Width="100px" Font-Names="Verdana" ForeColor="DarkBlue" Font-Size="8pt" MaxLength="10"></asp:textbox></TD>
    <TD style="WIDTH: 30%; HEIGHT: 52px">
<asp:textbox id=toDt onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();" style="TEXT-ALIGN: center" tabIndex=6 runat="server" Height="20px" Width="100px" Font-Names="Verdana" ForeColor="DarkBlue" Font-Size="8pt" MaxLength="10"></asp:textbox></TD></TR><% if (Request.Params ["ACTION"]=="U") {%>
  <TR bgColor=#f0f8ff>
    <TD style="WIDTH: 33.09%; HEIGHT: 52px" align=center colSpan=2>
<asp:RadioButton id=rdbPARIE tabIndex=7 runat="server" Width="258px" Text="For Particular IE" Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt" AutoPostBack="True" GroupName="g2"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:dropdownlist id=lstIE tabIndex=9 runat="server" Height="25px" Width="50%" Font-Names="Verdana" ForeColor="DarkBlue" Font-Size="8pt"></asp:dropdownlist></TD>
    <TD style="WIDTH: 33.09%; HEIGHT: 52px" align=center>
<asp:RadioButton id=rdbALLIE tabIndex=8 runat="server" Width="142px" Text="For All IE's" Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt" AutoPostBack="True" GroupName="g2"></asp:RadioButton></TD><%}%>
  <TR bgColor=#f0f8ff>
    <TD style="HEIGHT: 47px" align=center colSpan=3><FONT face=Verdana 
      color=darkblue size=2><B>Report to be sorted on&nbsp; 
<asp:RadioButton id=rdbBillDt tabIndex=10 runat="server" Text="Bill Date" GroupName="grpSort" Checked="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp; 
<% if (Request.Params ["ACTION"]=="U") {%>
<asp:RadioButton id=rdbIE tabIndex=11 runat="server" Text="IE Name" GroupName="grpSort"></asp:RadioButton>&nbsp;<%}%> 
<asp:RadioButton id=rdbICDT tabIndex=11 runat="server" Text="IC Date" GroupName="grpSort"></asp:RadioButton>&nbsp;&nbsp; 
<asp:RadioButton id=rdbFINSPDT tabIndex=11 runat="server" Text="First Insp Date" GroupName="grpSort"></asp:RadioButton>&nbsp; 
<asp:RadioButton id=rdbLINSPDT tabIndex=11 runat="server" Text="Last Insp Date" GroupName="grpSort"></asp:RadioButton></B></FONT></TD></TR>
  <TR bgColor=#f0f8ff>
    <TD align=center colSpan=3>
<asp:button id=btnSubmit tabIndex=12 runat="server" Text="Submit" ForeColor="DarkBlue" Font-Bold="True" BackColor="#C0C0FF"></asp:button></TD></TR></TABLE>
			</asp:panel></form>
	</body>
</HTML>

