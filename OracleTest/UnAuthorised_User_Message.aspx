<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnAuthorised_User_Message.aspx.cs" Inherits="RBS.UnAuthorised_User_Message.UnAuthorised_User_Message" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Error Page</title>
		<meta name="vs_showGrid" content="True">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		function del()
		{
		
		 alert("UR RECORD IS DELETED");
		 
		}
		
        </script>
</HEAD>
	<body bgColor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<P>
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 49px" align=center>
						<P align="center">
							<asp:Label id="Label1" runat="server" BackColor="White" Font-Names="Verdana" Font-Size="Large"
								ForeColor="Crimson" Font-Bold="True">WARNING...</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P>&nbsp;</P>
						<P>&nbsp;</P>
						<P>
							<asp:Label id="Label2" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="AliceBlue" Font-Bold="True">You are not Authorised to Modify this Record !!!</asp:Label></P>
      <P>&nbsp;</P>
						<P>
							<asp:button id="btnBack" tabIndex="7" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Text="Go Back" onclick="btnBack_Click"></asp:button></P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
