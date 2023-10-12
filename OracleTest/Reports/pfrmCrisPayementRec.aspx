<%@ Page language="c#" Codebehind="pfrmCrisPayementRec.aspx.cs" AutoEventWireup="false" Inherits="RBS.Reports.pfrmCrisPayementRec" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>pfrmCrisPayementRec</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
						<TD style="HEIGHT: 64px" align="center" colSpan="5">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<% if (Request.Params ["ACTION"]!="RBNRS") {%>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 33.09%; HEIGHT: 52px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">For 
									The Period --&gt;</FONT></B></TD>
						<TD style="WIDTH: 10.52%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">From</FONT></B></TD>
						<TD style="WIDTH: 13.97%; HEIGHT: 52px">
							<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
								style="TEXT-ALIGN: center" tabIndex="3" runat="server" Width="100px" Height="20px" MaxLength="10"
								Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"></asp:textbox></TD>
						<TD style="WIDTH: 6.76%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">To</FONT></B></TD>
						<TD style="WIDTH: 30%; HEIGHT: 52px">
							<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
								style="TEXT-ALIGN: center" tabIndex="4" runat="server" Width="100px" Height="20px" MaxLength="10"
								Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"></asp:textbox></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD align="center" colSpan="5">
							<asp:label id="Label5" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkMagenta"
								Font-Bold="True">* Enter Date in DD/MM/YYYY Format.</asp:label></TD>
					</TR>
					<%}%>
					<TR bgColor="#f0f8ff">
						<TD align="center" colSpan="5">
							<asp:CheckBox id="chkAllRegions" runat="server" Text="All Regions" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" Font-Bold="True" Checked="True"></asp:CheckBox></TD>
					</TR>
					<% if (Request.Params ["ACTION"]=="C") {%>
					<TR align="center" bgColor="#f0f8ff">
						<TD align="center" colSpan="5">
							<asp:radiobutton id="btnDetailed" runat="server" Text="Detailed" Font-Size="Smaller" Font-Names="Verdana"
								ForeColor="DarkBlue" Font-Bold="True" Checked="True" GroupName="g3" AutoPostBack="True"></asp:radiobutton>
							<asp:RadioButton id="btnSummary" runat="server" Text="Summary" Font-Size="Smaller" Font-Names="Verdana"
								ForeColor="DarkBlue" Font-Bold="True" GroupName="g3" AutoPostBack="True"></asp:RadioButton></TD>
					</TR>
					<%}%>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 29px" align="center" colSpan="5">&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:RadioButton id="rdbAllRly" runat="server" Text="All Railways" Font-Size="Smaller" Font-Names="Verdana"
								ForeColor="DarkBlue" Font-Bold="True" Checked="True" GroupName="2" AutoPostBack="True"></asp:RadioButton>
							<asp:RadioButton id="rdbPRly" runat="server" Text="Particular Railway" Font-Size="Smaller" Font-Names="Verdana"
								ForeColor="DarkBlue" Font-Bold="True" GroupName="2" AutoPostBack="True"></asp:RadioButton>
							<asp:dropdownlist id="lstClientType" tabIndex="6" runat="server" Width="300px" Visible="False" Font-Size="8pt"
								Font-Names="Verdana" ForeColor="DarkBlue" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 29px" align="center" colSpan="5">
							<asp:RadioButton id="rdbAllAU" runat="server" Visible="False" Text="All AU's" Font-Size="Smaller"
								Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" Checked="True" GroupName="3" AutoPostBack="True"></asp:RadioButton>
							<asp:RadioButton id="rdbPAU" runat="server" Visible="False" Text="Particular AU" Font-Size="Smaller"
								Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" GroupName="3" AutoPostBack="True"></asp:RadioButton>
							<asp:dropdownlist id="lstAU" tabIndex="6" runat="server" Width="300px" Visible="False" Font-Size="8pt"
								Font-Names="Verdana" ForeColor="DarkBlue" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
					<% if (Request.Params ["ACTION"]=="C")  {%>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 47px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">
									<asp:label id="lblStatus" runat="server">Status</asp:label>&nbsp;</FONT></B>
							<asp:dropdownlist id="ddlStatus" tabIndex="6" runat="server" Width="20%" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="Blue" Font-Bold="True" AutoPostBack="True">
								<asp:ListItem Value="P">Passed</asp:ListItem>
								<asp:ListItem Value="R">Returned</asp:ListItem>
								<asp:ListItem Value="X">Pending</asp:ListItem>
								<asp:ListItem Value="S">Returned Bills Resent</asp:ListItem>
								<asp:ListItem Value="A">ALL</asp:ListItem>
							</asp:dropdownlist>&nbsp;
							<asp:dropdownlist id="ddlStatus2" tabIndex="6" runat="server" Width="20%" Visible="False" Font-Size="8pt"
								Font-Names="Verdana" ForeColor="Blue" Font-Bold="True" AutoPostBack="True">
								<asp:ListItem Value="A" Selected="True">Invoice Date</asp:ListItem>
								<asp:ListItem Value="P">Payment Date</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 47px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">
									<asp:RadioButton id="rdbRlyWise" runat="server" Visible="False" Text="Railway Wise Summary" Font-Size="Smaller"
										Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" Checked="True" GroupName="2" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;
									<asp:RadioButton id="rdbAUWise" runat="server" Visible="False" Text="AU Wise Summary" Font-Size="Smaller"
										Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" GroupName="2" AutoPostBack="True"></asp:RadioButton>&nbsp;
									<asp:label id="lblMessage" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Red"
										Font-Bold="True">Report Based on Payment Date!!!</asp:label></B></FONT></TD>
					</TR>
					<%}%>
					<TR bgColor="#f0f8ff">
						<TD align="center" colSpan="5">
							<asp:button id="btnSubmit" runat="server" Text="Submit" ForeColor="DarkBlue" Font-Bold="True"
								BackColor="#C0C0FF"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
