<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unregistered_Calls.aspx.cs" Inherits="RBS.Unregistered_Calls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Unregistered_Calls</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center">
                            <asp:Button Text="text" ID="btnSub" runat="server" />
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="165px" BackColor="White" ForeColor="DarkBlue"
								Font-Size="10pt" Font-Names="Verdana">UNREGISTERED CALLS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" style="HEIGHT: 72px" borderColor="#b0c4de" cellSpacing="0" cellPadding="1"
								width="70%" bgColor="#f0f8ff" border="1">
								<TR align="center">
									<TD style="WIDTH: 24.44%; HEIGHT: 25px"><asp:label id="lblIE" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Name</asp:label></TD>
									<TD style="WIDTH: 42.16%; HEIGHT: 25px"><asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Year - Month</asp:label></TD>
									<TD style="WIDTH: 25%; HEIGHT: 25px"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">No. Of Unregistered Calls</asp:label></TD>
								</TR>
								<TR align="center">
									<TD style="WIDTH: 24.44%"><asp:dropdownlist id="lstIE" tabIndex="3" runat="server" Width="176px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="27px"></asp:dropdownlist></TD>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 42.16%; COLOR: darkblue; FONT-FAMILY: Verdana">
										<asp:dropdownlist id="Year" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="45%" Height="20px"></asp:dropdownlist>-
										<asp:dropdownlist id="toMonth" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="45%" Height="20px">
											<asp:ListItem Value="01" Selected="True">January</asp:ListItem>
											<asp:ListItem Value="02">February</asp:ListItem>
											<asp:ListItem Value="03">March</asp:ListItem>
											<asp:ListItem Value="04">April</asp:ListItem>
											<asp:ListItem Value="05">May</asp:ListItem>
											<asp:ListItem Value="06">June</asp:ListItem>
											<asp:ListItem Value="07">July</asp:ListItem>
											<asp:ListItem Value="08">August</asp:ListItem>
											<asp:ListItem Value="09">September</asp:ListItem>
											<asp:ListItem Value="10">October</asp:ListItem>
											<asp:ListItem Value="11">November</asp:ListItem>
											<asp:ListItem Value="12">December</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD style="WIDTH: 25%"><asp:textbox id="txtUCalls" tabIndex="1" runat="server" Width="95%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="4"></asp:textbox></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* To Add New Record Fill Values and Click on Save</asp:label><asp:label id="Label5" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* To Edit Record select that record from grid and then save it.</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" tabIndex="6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelConfirm" tabIndex="9" runat="server" Font-Bold="True" Width="75px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Delete!!!" OnClick="btnDelConfirm_Click"></asp:button><asp:button id="btnCancel" tabIndex="10" runat="server" Font-Bold="True" Width="75px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<P>&nbsp;</P>
						<P align="center"><asp:datagrid id="grdUCalls" runat="server" Width="80%" Font-Size="8pt" Font-Names="Verdana" Height="96px"
								BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False" CellPadding="0" PageSize="15">
								<SelectedItemStyle Font-Names="Verdana"></SelectedItemStyle>
								<EditItemStyle Font-Names="Verdana"></EditItemStyle>
								<AlternatingItemStyle Font-Names="Verdana" Width="500px" BackColor="#CCCCFF"></AlternatingItemStyle>
								<ItemStyle Font-Names="Verdana" HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
									BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn FooterText="Edit">
										<ItemTemplate>
											<asp:HyperLink id=HyperLink2 runat="server" NavigateUrl='<%#"Unregistered_Calls.aspx?IE_CD=" + DataBinder.Eval(Container.DataItem,"IE_CD")%>'>Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="IE_NAME" HeaderText="IE Name"></asp:BoundColumn>
									<asp:BoundColumn DataField="YR_MTH" HeaderText="Year &amp; Month">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UNREG_CALLS" HeaderText="No. of Unregistered Calls">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IE_CD" HeaderText="IE_CD"></asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="Next" PrevPageText="Prev" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</html>
