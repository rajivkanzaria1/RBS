<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckSheets_Form.aspx.cs" Inherits="RBS.CheckSheets_Form.CheckSheets_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CheckSheets_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD>
							<P align="center">
								<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 30px" align="center">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
									BackColor="White" Width="174px" Font-Bold="True"> CHECKSHEETS</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD>
							<P align="center">
								<TABLE id="Table2" style="WIDTH: 199px; HEIGHT: 56px" borderColor="#b0c4de" cellSpacing="0"
									cellPadding="1" width="199" bgColor="#f0f8ff" border="1">
									<TR align="center">
										<TD style="WIDTH: 30.97%; HEIGHT: 28px" vAlign="middle" align="center">
											<P><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%" Font-Bold="True" Font-Underline="True" Height="20px">SELECT DISCIPLINE</asp:label></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 30.97%" align="left">
											<asp:dropdownlist id="lstDescipline" tabIndex="13" runat="server" Width="100%" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Height="25px">
												<asp:ListItem Selected="True"></asp:ListItem>
												<asp:ListItem Value="M">Mechanical</asp:ListItem>
												<asp:ListItem Value="E">Electrical</asp:ListItem>
												<asp:ListItem Value="C">Civil</asp:ListItem>
												<asp:ListItem Value="M">Mettalurgy</asp:ListItem>
												<asp:ListItem Value="T">Textiles</asp:ListItem>
												<asp:ListItem Value="P">Power Engineering</asp:ListItem>
												<asp:ListItem Value="O">Others</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
								</TABLE>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label5" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">* To Search Checksheets, Select the Discipline from the list and then click on Search Button.</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:button id="btnSearch" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Width="65px" Font-Bold="True" Text="Search"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center">
							<TITTLE:CUSTOMDATAGRID id="DgCK1" runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="500px"
								FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
								CellPadding="2" FreezeRows="0" BorderColor="DarkBlue" PageSize="15" AutoGenerateColumns="False">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
									CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CHK_SHEET_ID" HeaderText="CheckSheet ID">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CHK_SHEET_NAME" HeaderText="CheckSheet Name">
										<HeaderStyle Width="20%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOCUMENT_NO" HeaderText="Document No.">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CK_DOC">
										<HeaderStyle Width="15%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
