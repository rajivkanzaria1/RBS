<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Administration.aspx.cs" Inherits="RBS.User_Administration.User_Administration" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>User Administration</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 184px"
					cellSpacing="1" cellPadding="1" border="0">
					<TR>
						<TD noWrap align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 21px" noWrap align="center">
							<P><asp:label id="Label1" runat="server" ForeColor="DarkBlue" BackColor="White" Font-Bold="True"
									Font-Size="10pt" Font-Names="Verdana">AUTHORISED USERS OF THE SYSTEM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 124px">
							<DIV><TITTLE:CUSTOMDATAGRID id="grdUser" runat="server" BackColor="White" Font-Size="8pt" Font-Names="Verdana"
									FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" PageSize="1" CellPadding="0" BorderColor="Navy"
									BorderStyle="Groove" AutoGenerateColumns="False" Height="100px" Width="100%" FreezeRows="0" GridHeight="400px"
									AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True">
									<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
									<AlternatingItemStyle CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
									<EditItemStyle Wrap="False"></EditItemStyle>
									<FooterStyle Wrap="False" CssClass="GridHeader"></FooterStyle>
									<ItemStyle Font-Size="8pt" Font-Names="Verdana" HorizontalAlign="Center" CssClass="GridNormal"></ItemStyle>
									<HeaderStyle Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center" Height="40px"
										ForeColor="DarkBlue" CssClass="GridHeader" VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:HyperLinkColumn Text="Delete" DataNavigateUrlField="USER_ID" DataNavigateUrlFormatString="User_Delete.aspx?USER_ID={0}"
											NavigateUrl="User_Delete.aspx">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:HyperLinkColumn Text="Edit" DataNavigateUrlField="USER_ID" DataNavigateUrlFormatString="User_Edit.aspx?USER_ID={0}"
											NavigateUrl="User_Edit.aspx">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:BoundColumn DataField="USER_ID" HeaderText="User Id">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="USER_NAME" HeaderText="Name">
											<HeaderStyle Width="20%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="EMP_NO" HeaderText="Emp No. (if RITES Emp)">
											<HeaderStyle Width="8%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REGION" HeaderText="Region">
											<HeaderStyle Width="14%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AUTH_LEVL" HeaderText="Role">
											<HeaderStyle Width="15%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="STATUS" HeaderText="Status">
											<HeaderStyle Width="8%"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></DIV>
						</TD>
					<TR>
						<TD align="center"></TD>
					</TR>
					<TR>
						<TD align="center"><asp:button id="btnUserAdd" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana" Width="100px" Text="Add New User" onclick="btnUserAdd_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</P>
		</form>
	</body>
</HTML>

