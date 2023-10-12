<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopUp.aspx.cs" Inherits="RBS.PopUp.PopUp" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PopUp</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body onblur="window.focus()" bgColor="#ffffff" onload="window.focus()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 312px; POSITION: absolute; TOP: 8px; HEIGHT: 88px"
				cellSpacing="1" cellPadding="1" width="312" border="0">
				<TR>
					<TD style="HEIGHT: 37px" vAlign="top" align="center" bgColor="inactivecaptiontext">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:imagebutton id="ImageButton1" runat="server" ImageUrl="\RBS\images\warning.gif" Width="25px"></asp:imagebutton>&nbsp;&nbsp;
						<asp:label id="Label1" runat="server" Width="239px" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt"
							Font-Names="Verdana">Rites Inspection & Billing System</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" BackColor="AliceBlue">You Had Successfully Changed the PassWord!!!</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnOK" runat="server" Width="40px" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="OK" onclick="btnOK_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

