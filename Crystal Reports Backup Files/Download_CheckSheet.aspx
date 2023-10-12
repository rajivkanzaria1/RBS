<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Download_CheckSheet.aspx.cs" Inherits="RBS.Download_CheckSheet.Download_CheckSheet" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Download_CheckSheet</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 123px; TOP: 8px; LEFT: 8px" id="Table1"
				border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD>
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 30px" align="center">
							<P><asp:label id="Label1" runat="server" Font-Bold="True" BackColor="White" ForeColor="DarkBlue"
									Font-Size="10pt" Font-Names="Verdana"> DOWNLOAD CHECKSHEET</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD>
							<P align="center">
								<TABLE style="WIDTH: 100%; HEIGHT: 56px" id="Table2" border="1" cellSpacing="0" borderColor="#b0c4de"
									cellPadding="1" width="199" bgColor="#f0f8ff">
									<TBODY>
										<TR>
											<TD width="35%"><asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
													Font-Names="Verdana">Discipline &nbsp</asp:label><asp:dropdownlist id="lstDescipline" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
													Height="25px">
													<asp:ListItem Selected="True"></asp:ListItem>
													<asp:ListItem Value="M">Mechanical</asp:ListItem>
													<asp:ListItem Value="E">Electrical</asp:ListItem>
													<asp:ListItem Value="C">Civil</asp:ListItem>
													<asp:ListItem Value="M">Mettalurgy</asp:ListItem>
													<asp:ListItem Value="T">Textiles</asp:ListItem>
													<asp:ListItem Value="P">Power Engineering</asp:ListItem>
													<asp:ListItem Value="O">Others</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD width="65%"><asp:label id="lbl" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Check Sheet Name &nbsp</asp:label><asp:textbox id="txtCheckSheet" runat="server" Width="80%"></asp:textbox></TD>
						</TD>
					</TR>
					<TR>
						<TD align="center" colspan="2"><FONT color="#ff0099" size="1" face="Verdana"><STRONG> Select 
									Discipline / Part or Full Check sheet name and Click on [Search] button 
									to&nbsp;search for &nbsp;desired checksheet----&gt;&nbsp;
									<asp:button id="btnSearch" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="65px" Text="Search" style="Z-INDEX: 0"></asp:button></STRONG></FONT></TD>
					</TR>
				</TBODY>
			</TABLE>
			</P>
			<TR>
				<TD align="center">
					<TITTLE:CUSTOMDATAGRID id="DgCK" runat="server" Width="100%" Height="8px" AutoGenerateColumns="False" PageSize="15"
						BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
						BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="500px" GridWidth="100%">
						<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
						<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
						<EditItemStyle Height="10%"></EditItemStyle>
						<FooterStyle CssClass="GridHeader"></FooterStyle>
						<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
						<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
							CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="FILE_NAME" HeaderText="CheckSheet ID">
								<HeaderStyle Width="10%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="CHK_SHEET_NAME" HeaderText="CheckSheet Name">
								<HeaderStyle Width="20%"></HeaderStyle>
								<ItemStyle HorizontalAlign="Left"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="DOCUMENT_NO" HeaderText="Document No.">
								<HeaderStyle Width="15%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="ISSUE_DT" HeaderText="Issue Date">
								<HeaderStyle Width="10%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="CK_DOC">
								<HeaderStyle Width="15%"></HeaderStyle>
								<ItemStyle HorizontalAlign="Left"></ItemStyle>
							</asp:BoundColumn>
						</Columns>
					</TITTLE:CUSTOMDATAGRID></TD>
			</TR>
			</TBODY></TABLE>
		</form>
		</TR></TBODY>
		<P></P>
		</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
