<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Delete.aspx.cs" Inherits="RBS.User_Delete.User_Delete" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>User Delete</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		function del()
		 {
		  alert("YOUR RECORD IS DELETED!!!");
		  return;
		 }
        </script>
	</HEAD>
	<body bgColor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 109px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<P>
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<asp:Label id="Label1" runat="server" BackColor="White" Font-Names="Verdana" Font-Size="10pt"
								ForeColor="DarkBlue" Font-Bold="True">User Administration</asp:Label></P>
						<P align="center">&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P>
							<asp:Label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								Font-Bold="True" BackColor="AliceBlue"> Are You Sure, You Want to Delete the User With UserID:</asp:Label></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Button id="btnYes" runat="server" Text="Yes" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Width="62px" Font-Bold="True" tabIndex="1" onclick="btnYes_Click"></asp:Button>&nbsp;&nbsp;
						<asp:Button id="Button1" tabIndex="2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Width="62px" Text="No" onclick="Button1_Click"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
