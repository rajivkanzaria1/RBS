<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Session_Expired_Client.aspx.cs" Inherits="RBS.Session_Expired_Client.Session_Expired_Client" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PopUp</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bgColor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 312px; POSITION: absolute; TOP: 8px; HEIGHT: 88px"
				cellSpacing="1" cellPadding="1" width="312" border="0">
				<TR>
					<TD align="center" style="HEIGHT: 37px" bgColor="inactivecaptiontext" vAlign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:ImageButton id="ImageButton1" runat="server" Width="25px" ImageUrl="\RBS\images\warning.gif"></asp:ImageButton>&nbsp;&nbsp;
						<asp:Label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
							Width="239px" Font-Bold="True">Rites Inspection & Billing System</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Label id="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" BackColor="AliceBlue">Your Session has been Expired, So Please Login Again!!!</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Button id="btnOK" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Text="OK" Width="40px" Font-Bold="True" onclick="btnOK_Click"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

