<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<%@ Page language="c#" Codebehind="pfrmCOIEWiseCalls.aspx.cs" AutoEventWireup="false" Inherits="RBS.Reports.pfrmCOIEWiseCalls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>pfrmCOIEWiseCalls</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Visible="False" Height="1px" Width="100%">
				<INPUT id="Button1" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
			</asp:panel><asp:panel id="Panel1" runat="server" Height="200px">
				<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
					cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR align="center">
						<TD colSpan="2">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 46px" align="center" colSpan="2">
							<asp:label id="Label1" runat="server" Width="100%" Height="19px" BackColor="White" Font-Bold="True"
								Font-Size="10pt" Font-Names="Verdana" ForeColor="DarkBlue">CONTROLLING WISE CALLS MARKED</asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 20%; HEIGHT: 25px"><FONT face="Verdana" color="darkblue" size="2">
								<asp:label id="lblIE" runat="server" Width="152px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
									ForeColor="DarkBlue">Controlling Officer </asp:label></FONT></TD>
						<TD style="WIDTH: 80%; HEIGHT: 25px"><FONT face="Verdana" color="darkblue" size="2">
								<asp:dropdownlist id="lstCO" tabIndex="1" runat="server" Width="40%" Height="25px" Font-Size="8pt"
									Font-Names="Verdana" ForeColor="DarkBlue" AutoPostBack="True"></asp:dropdownlist></FONT></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 20%; HEIGHT: 25px">
							<asp:label id="Label2" runat="server" Width="152px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">Inspection Engineer</asp:label></TD>
						<TD style="WIDTH: 80%; HEIGHT: 25px">
							<asp:RadioButton id="rdbAllIE" tabIndex="2" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" AutoPostBack="True" GroupName="g2" Checked="True" Text="All IE"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:RadioButton id="rdbPIE" tabIndex="3" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" AutoPostBack="True" GroupName="g2" Text="Particular IE"></asp:RadioButton>
							<asp:dropdownlist id="lstIE" tabIndex="4" runat="server" Width="60%" Height="20px" Visible="False"
								Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 20%; HEIGHT: 25px">
							<asp:label id="Label4" runat="server" Width="112px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">Status of Calls</asp:label></TD>
						<TD style="WIDTH: 80%; HEIGHT: 25px">
							<asp:dropdownlist id="lstCallStatus" tabIndex="1" runat="server" Width="40%" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" OnChange="call_cancel_status();"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 20%; HEIGHT: 20px">
							<asp:label id="Label5" runat="server" Width="112px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">Report Sorted On</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
						<TD style="WIDTH: 80%; HEIGHT: 20px"><FONT face="Verdana" color="darkblue" size="2">
								<asp:RadioButton id="rdbCallDT" tabIndex="5" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
									ForeColor="DarkBlue" GroupName="g3" Checked="True" Text="Call Date"></asp:RadioButton>
								<asp:RadioButton id="rdbVendor" tabIndex="6" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
									ForeColor="DarkBlue" GroupName="g3" Text="Vendor"></asp:RadioButton></FONT></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<asp:Button id="btnSubmit" tabIndex="7" runat="server" BackColor="#C0C0FF" Font-Bold="True"
								ForeColor="DarkBlue" Text="Submit"></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
