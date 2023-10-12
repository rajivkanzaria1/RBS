<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error_Form.aspx.cs" Inherits="RBS.Error_Form.Error_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl_Vend" Src="WebUserControl_Vend.ascx" %>
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
	<body MS_POSITIONING="GridLayout" bgColor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<P>
							<uc1:WebUserControl_Vend id="WebUserControl_Vend1" runat="server"></uc1:WebUserControl_Vend></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<asp:Label id="Label1" runat="server" BackColor="White" Font-Names="Verdana" Font-Size="Large"
								ForeColor="Crimson" Font-Bold="True">WARNING...</asp:Label></P>
						<P align="center">&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P>
							<asp:Label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								BackColor="AliceBlue" Font-Bold="True">Error!!!</asp:Label></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
