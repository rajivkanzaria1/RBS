<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Training_Excel.aspx.cs" Inherits="RBS.Training_Excel.Training_Excel" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Training_Excel</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 123px; TOP: 8px; LEFT: 8px" id="Table1"
				border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD style="HEIGHT: 22px" align="center">
						<P>
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px" align="center">
						<asp:label style="Z-INDEX: 0" id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt"
							Font-Bold="True" ForeColor="DarkBlue" BackColor="White" Width="191px">TRAINING DATA</asp:label></TD>
				</TR>
				<tr>
					<td align="center">
						<TABLE id="Table2" style="Z-INDEX: 101; WIDTH: 50%; HEIGHT: 30%; LEFT: 8px" borderColor="royalblue"
							cellPadding="0" bgColor="#dcebf9" border="1">
							<TR>
								<TD style="HEIGHT: 40px" colSpan="2" align="center">&nbsp;&nbsp;&nbsp; <IMG id="BArrow1" src="\RBS\images\BArrow.gif">&nbsp;
									<asp:hyperlink id="HyperLinkTraining" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
										ForeColor="RoyalBlue" Height="20px">Click Here to View Training Data in Excel</asp:hyperlink>&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD style="HEIGHT: 22px" align="right"></TD>
				</TR>
			</TABLE>
			</ASP:PANEL>&lt;
		</form>
	</body>
</HTML>
