<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Download_Documents.aspx.cs" Inherits="RBS.Download_Documents.Download_Documents" %>

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
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" id="Table1" border="1"
				cellSpacing="1" cellPadding="1" width="100%">
				<TR align="center">
					<TD>
						<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
				</TR>
				<TR align="center">
					<TD align="center" style="HEIGHT: 33px"><FONT color="darkblue" face="Verdana"><STRONG>DOWNLOAD 
								DOCUMENTS</STRONG></FONT></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" border="1" cellSpacing="1" cellPadding="1" width="100%" bgColor="lavender">
							<TR>
								<TD style="HEIGHT: 22px">
									<asp:Label id="D" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True">Document Type</asp:Label></TD>
								<TD style="HEIGHT: 22px">
									<asp:DropDownList id="lstDocType" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue"
										Font-Bold="True" AutoPostBack="True" onselectedindexchanged="lstDocType_SelectedIndexChanged"></asp:DropDownList></TD>
								<TD style="HEIGHT: 22px">
									<asp:Label id="txtDocSubType" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True"></asp:Label></TD>
								<TD style="HEIGHT: 22px">
									<asp:DropDownList id="lstDocSubType" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue"
										Font-Bold="True" Visible="False"></asp:DropDownList>
									<asp:Label id="lblDocSubType" runat="server" Visible="False"></asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblRegion" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Visible="False">Region</asp:Label></TD>
								<TD><asp:dropdownlist id="lstRegionCd" tabIndex="4" runat="server" Width="152px" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Visible="False">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="N">NORTHERN REGION</asp:ListItem>
										<asp:ListItem Value="E">EASTERN REGION</asp:ListItem>
										<asp:ListItem Value="W">WESTERN REGION</asp:ListItem>
										<asp:ListItem Value="S">SOUTHERN REGION</asp:ListItem>
										<asp:ListItem Value="C">CENTRAL REGION</asp:ListItem>
										<asp:ListItem Value="Q">CO QA DIVISION</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True">Name of the Document</asp:Label></TD>
								<TD colspan="3">
									<asp:TextBox id="txtDocName" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue"
										Font-Bold="True" Width="100%"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD align="center" colspan="4"><FONT color="#ff0099" size="1" face="Verdana"><STRONG> Select 
											Document Type &amp; Its Sub-Type (if applicable) / Part or Full&nbsp;Document 
											Name and Click on [Search] button to&nbsp;search for &nbsp;desired 
											document----&gt;&nbsp;
											<asp:button id="btnSearch" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Width="65px" Text="Search" onclick="btnSearch_Click"></asp:button></STRONG></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR align="center">
					<TD style="HEIGHT: 22px">
						<asp:Label id="lblGridHeader" runat="server" Font-Bold="True" ForeColor="MediumVioletRed" Font-Size="9pt"
							Font-Names="Verdana"></asp:Label></TD>
				</TR>
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
								<asp:BoundColumn DataField="FILE_NAME" HeaderText="Document ID">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOCUMENT_NAME" HeaderText="Document Name">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOCUMENT_NO" HeaderText="Document No.">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ISSUE_DATE" HeaderText="Issue Date">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FILE_LOCATION">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
