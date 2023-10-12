<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print_Lab_Payment_Voucher.aspx.cs" Inherits="RBS.Print_Lab_Payment_Voucher.Print_Lab_Payment_Voucher" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>pfrmLab_Payment_Voucher</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="False">
<asp:Button id=btnPrint runat="server" Text="Print" Font-Names="Verdana" Font-Bold="True" Font-Size="8pt" ForeColor="DarkBlue" onclick="btnPrint_Click"></asp:Button>
<asp:button id=btnCancel runat="server" Text="Cancel" Font-Names="Verdana" Font-Bold="True" Font-Size="8pt" ForeColor="DarkBlue" onclick="btnCancel_Click"></asp:button>
			</asp:panel>
		</form>
	</body>
</HTML>
