<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Under_Maintainence_Form.aspx.cs" Inherits="RBS.Under_Maintainence_Form.Under_Maintainence_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Maintainence Form</title>
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
							<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="100%" bgColor="inactivecaptiontext"
								border="1" borderColor="lightsteelblue">
								<TR>
									<TD width="20%" style="HEIGHT: 20px">
									</TD>
									<TD align="center" width="60%" style="HEIGHT: 20px">
										<asp:label id="Label3" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana"
											runat="server" BackColor="Transparent" BorderColor="White">RITES INSPECTION & BILLING SYSTEM</asp:label></TD>
									<TD align="right" width="20%" style="HEIGHT: 20px">
									</TD>
								</TR>
								<TR>
									<TD width="20%" noWrap align="right" colSpan="3" rowSpan="1">
									</TD>
								</TR>
							</TABLE></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 44px">
						<P align="center">
							<asp:Label id="Label1" runat="server" BackColor="White" Font-Names="Verdana" Font-Size="Large"
								ForeColor="Crimson" Font-Bold="True">MESSAGE</asp:Label></P>
						<P align="center">&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P>
							<asp:Label id="Label2" runat="server" Font-Names="Verdana" Font-Size="12pt" ForeColor="MediumSeaGreen"
								BackColor="Transparent" Font-Bold="True" Width="100%">Form Taken Offline For Maintainence For 1 Hour !!!</asp:Label></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

