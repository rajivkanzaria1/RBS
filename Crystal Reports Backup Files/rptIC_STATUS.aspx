<%@ Page language="c#" Codebehind="rptIC_STATUS.aspx.cs" AutoEventWireup="false" Inherits="RBS.Reports.rptIC_STATUS" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UnbilledIC</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="../date.js"></script>
		<script language="javascript">
		function txtCopy()
		{
			
			if(check_date(document.Form1.frmDt)==true && trimAll(document.Form1.toDt.value)=="")
			{
				document.Form1.toDt.value=document.Form1.frmDt.value;
			}
			
		}
		
		function validate()
		{
			if(document.Form1.frmDt=="[object]" && trimAll(document.Form1.frmDt.value)=="")
			{
				alert("You Cannot Leave From Date Blank!!!");
				event.returnValue=false;
			}
		}
		
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Visible="False" Height="1px" Width="100%">
				<asp:Button id="btnPrint" runat="server" Text="Print"></asp:Button>
				<INPUT id="Button1" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Height="1px" Width="100%">
				<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 152px"
					cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 26px" align="center" colSpan="5">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 28px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">IC 
									STATUS REPORT </FONT></B>
						</TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 13.17%; HEIGHT: 31px" align="center"><FONT face="Verdana" color="darkblue" size="2">
								<asp:label id="lblSIE" runat="server" Width="87px" ForeColor="DarkBlue" Font-Names="Verdana"
									Font-Size="8pt" Font-Bold="True">Status of IE </asp:label></FONT></TD>
						<TD colSpan="2">
							<asp:radiobutton id="rdbAll" tabIndex="1" runat="server" Text="ALL IE's" GroupName="g1" AutoPostBack="True"
								Checked="True" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="10pt"></asp:radiobutton></TD>
						<TD colSpan="2">
							<asp:radiobutton id="rdbGIE" tabIndex="2" runat="server" Text="For Particular IE" GroupName="g1"
								AutoPostBack="True" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="10pt"></asp:radiobutton></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 13.17%; HEIGHT: 33px" align="center" colSpan="1"><FONT face="Verdana" color="darkblue" size="2">
								<asp:label id="lblIE" runat="server" Width="42px" ForeColor="DarkBlue" Font-Names="Verdana"
									Font-Size="8pt" Font-Bold="True">IE </asp:label></FONT></TD>
						<TD style="HEIGHT: 33px" colSpan="4">
							<asp:dropdownlist id="lstIE" tabIndex="3" runat="server" Width="50%" Height="25px" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt"></asp:dropdownlist></FONT></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 33.09%; HEIGHT: 52px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">For 
									The Period --&gt;</FONT></B></TD>
						<TD style="WIDTH: 10.52%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">From</FONT></B></TD>
						<TD style="WIDTH: 13.97%; HEIGHT: 52px">
							<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
								style="TEXT-ALIGN: center" tabIndex="4" runat="server" Width="100px" Height="20px" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt" MaxLength="10"></asp:textbox></TD>
						<TD style="WIDTH: 6.76%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">To</FONT></B></TD>
						<TD style="WIDTH: 30%; HEIGHT: 52px">
							<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
								style="TEXT-ALIGN: center" tabIndex="5" runat="server" Width="100px" Height="20px" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD align="center" colSpan="5">
							<asp:button id="btnSubmit" tabIndex="6" runat="server" Text="Submit" ForeColor="DarkBlue" Font-Bold="True"
								BackColor="#C0C0FF"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
