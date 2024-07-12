<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<%@ Page language="c#" Codebehind="pfrmAdvanceOutstanding.aspx.cs" AutoEventWireup="false" Inherits="RBS.Reports.pfrmAdvanceOutstanding" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Advance Outstanding</title>
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
			<asp:panel id="Panel2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Visible="False" Height="1px" Width="100%">
				<asp:Button id="btnPrintP" runat="server" Text="Print"></asp:Button>
				<asp:Button id="btnBack" runat="server" Text="Go Back"></asp:Button>
			</asp:panel><asp:panel id="Panel1" runat="server" Height="200px">
				<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
					cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR align="center">
						<TD colSpan="2">
							<uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 25px" align="center" colSpan="2">
							<P>
								<asp:label id="Label1" runat="server" Width="80%" BackColor="White" ForeColor="DarkBlue" Font-Bold="True"
									Font-Names="Verdana" Font-Size="10pt">ENGINEER WISE ADVANCE OUTSTANDING</asp:label></P>
						</TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 13.17%; HEIGHT: 33px" align="center"><FONT face="Verdana" color="darkblue" size="2">
								<asp:radiobutton id="rdbSummary" tabIndex="1" runat="server" Text="SUMMARY" ForeColor="DarkBlue"
									Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" GroupName="g3" AutoPostBack="True" Checked="True"></asp:radiobutton></FONT></TD>
						<TD style="HEIGHT: 33px" align="center"></FONT>
							<asp:radiobutton id="rdbDetail" tabIndex="2" runat="server" Text="DETAILS" ForeColor="DarkBlue" Font-Bold="True"
								Font-Names="Verdana" Font-Size="10pt" GroupName="g3" AutoPostBack="True"></asp:radiobutton></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 13.17%; HEIGHT: 31px" align="center"><FONT face="Verdana" color="darkblue" size="2">
								<asp:label id="lblSIE" runat="server" Width="161px" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
									Font-Size="8pt">Status of IE </asp:label></FONT></TD>
						<TD style="WIDTH: 10%; HEIGHT: 31px" align="center">
							<TABLE id="Table2" height="100%" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD>
										<asp:radiobutton id="rdbAll" tabIndex="3" runat="server" Text="ALL IE's" ForeColor="DarkBlue" Font-Names="Verdana"
											Font-Size="10pt" GroupName="g1" AutoPostBack="True" Checked="True"></asp:radiobutton></TD>
									<TD>
										<asp:radiobutton id="rdbGIE" tabIndex="4" runat="server" Text="For Particular IE" ForeColor="DarkBlue"
											Font-Names="Verdana" Font-Size="10pt" GroupName="g1" AutoPostBack="True"></asp:radiobutton></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 21.27%" align="center">
							<asp:label id="lblIE" runat="server" Width="42px" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
								Font-Size="8pt">IE </asp:label></TD>
						<TD style="WIDTH: 30%">
							<asp:dropdownlist id="lstIE" tabIndex="5" runat="server" Height="25px" Width="50%" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt"></asp:dropdownlist></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 21.27%">
							<P>
								<asp:radiobutton id="rdbForMonth" tabIndex="6" runat="server" Width="100%" Text="For the Month" ForeColor="DarkBlue"
									Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" GroupName="g2" AutoPostBack="True" Checked="True"></asp:radiobutton>
								<asp:radiobutton id="ForGPer" tabIndex="9" runat="server" Width="100%" Text="For Given Period" ForeColor="DarkBlue"
									Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" GroupName="g2" AutoPostBack="True"></asp:radiobutton></P>
						</TD>
						<TD style="WIDTH: 30%">
							<P>
								<asp:label id="Label2" runat="server" Width="30%" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
									Font-Size="8pt">Label</asp:label>
								<asp:label id="Label3" runat="server" Width="30%" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
									Font-Size="8pt">Label</asp:label></P>
							<P>
								<asp:dropdownlist id="toMonth" tabIndex="7" runat="server" Height="20px" Width="30%" ForeColor="DarkBlue"
									Font-Names="Verdana" Font-Size="8pt">
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
								</asp:dropdownlist>
								<asp:dropdownlist id="Year" tabIndex="8" runat="server" Height="20px" Width="30%" ForeColor="DarkBlue"
									Font-Names="Verdana" Font-Size="8pt"></asp:dropdownlist></P>
							<P>
								<asp:textbox id="frmDt" onblur="txtCopy();" style="TEXT-ALIGN: center" tabIndex="10" runat="server"
									Height="20px" Width="30%" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt" MaxLength="10"></asp:textbox>
								<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
									style="TEXT-ALIGN: center" tabIndex="11" runat="server" Height="20px" Width="30%" ForeColor="DarkBlue"
									Font-Names="Verdana" Font-Size="8pt" MaxLength="10"></asp:textbox></P>
						</TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD align="center" colSpan="2">
							<P><B><FONT face="Verdana" color="darkblue" size="2"></FONT></B>&nbsp;</P>
							<P>
								<asp:Button id="btnSubmit" tabIndex="12" runat="server" Text="Generate Report" BackColor="#C0C0FF"
									ForeColor="DarkBlue" Font-Bold="True"></asp:Button></P>
							</B></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
