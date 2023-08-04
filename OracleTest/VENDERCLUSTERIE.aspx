<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VENDERCLUSTERIE.aspx.cs" Inherits="RBS.VENDERCLUSTERIE.VENDERCLUSTERIE" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VENDERCLUSTERIE</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<INPUT id="Button12" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
		<div runat="server" id="xyz">
			<form id="Form1" method="post" runat="server">
				<TABLE style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 123px; TOP: 8px; LEFT: 8px" id="Table1"
					border="0" cellSpacing="1" cellPadding="1" width="100%">
					<TR>
						<TD align="center" colspan="2">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 25px" align="center" colSpan="2">
							<P><asp:label id="Label1" runat="server" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True"
									ForeColor="DarkBlue" BackColor="White" Width="374px">VENDOR CLUSTER IE DEPARTMENT REPORT</asp:label></P>
						</TD>
					</TR>
					<tr>
						<TD></TD>
					</tr>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH:10%">
							<P><asp:radiobutton id="rdbForMonth" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
									ForeColor="DarkBlue" Width="100%" Text="Show Report for All" AutoPostBack="True" GroupName="g1"
									OnCheckedChanged="radiochanged"></asp:radiobutton>
							</P>
						</TD>
						<TD style="WIDTH: 30%">
							<asp:radiobutton id="Radiobutton1" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
								ForeColor="DarkBlue" Width="100%" Text="Show Report for departmentwise" AutoPostBack="True" GroupName="g1" OnCheckedChanged="radiochanged123"></asp:radiobutton>
							<asp:dropdownlist id="Year" tabIndex="1" OnSelectedIndexChanged="departmentchanged" runat="server"
								Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" Width="35%" Height="20px" style="Z-INDEX: 0"
								AutoPostBack="True"></asp:dropdownlist>
						</TD>
					</TR>
				</TABLE>
			</form>
		</div>
	</body>
</HTML>
