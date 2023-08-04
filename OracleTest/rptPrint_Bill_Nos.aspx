<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptPrint_Bill_Nos.aspx.cs" Inherits="RBS.rptPrint_Bill_Nos.rptPrint_Bill_Nos" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>rptPrint_Bill_Nos</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="true">
				<asp:Button id="btnPrint" runat="server" Text="Print" onclick="btnPrint_Click"></asp:Button>
				<asp:Button id="btnClose" runat="server" Text="Close" onclick="btnClose_Click"></asp:Button>
			</asp:panel>
			<asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px"></asp:panel>
		</form>
	</body>
</HTML>
