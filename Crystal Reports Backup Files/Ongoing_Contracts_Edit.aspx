<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ongoing_Contracts_Edit.aspx.cs" Inherits="RBS.Ongoing_Contracts_Edit.Ongoing_Contracts_Edit" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ongoing_Contracts_Edit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101;LEFT: 8px;WIDTH: 100%;POSITION: absolute;TOP: 8px;HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 23px" align="center">
						<P>
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center">
						<P><asp:label id="Label1" runat="server" ForeColor="DarkBlue" BackColor="White" Font-Bold="True"
								Font-Size="10pt" Font-Names="Verdana">ONGOING NON RAILWAY CONTRACTS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%;HEIGHT: 28px">
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 90%; HEIGHT: 56px" cellSpacing="1" cellPadding="1" bgColor="#f0f8ff"
								border="1" borderColor="#b0c4de">
								<TR>
									<TD align="left" style="WIDTH: 17.18%"><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="100%">Contract Code</asp:label></TD>
									<TD style="WIDTH: 19.94%"><asp:textbox id="txtContractCD" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Width="80%" MaxLength="5" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 11.68%"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="100%">Client Name</asp:label></TD>
									<TD style="WIDTH: 30%"><asp:textbox id="txtBPOName" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Width="80%" MaxLength="50" Height="20px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="Label8" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana" Width="100%">
								To Edit/Delete a BPO --> Enter BPO Code & Click on "Modify"/"Delete" button</asp:label><asp:label id="Label3" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana" Width="100%">
								To Search a BPO --> Enter BPO Code or BPO Name or  BPO Railways or City and click on "Search BPO" button</asp:label></P>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center"><asp:button id="btnAdd" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="67px" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="67px" Text="Modify" onclick="btnMod_Click"></asp:button><asp:button id="btnShow" tabIndex="8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="85px" Text="Search" onclick="btnShow_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
							</TR>
							<TR>
								<TD align="center">
									<DIV id="repdiv" style="Z-INDEX: 101; LEFT: 8px; OVERFLOW: scroll; WIDTH: 100%; POSITION: absolute; TOP: 250px; HEIGHT: 320px"
										runat="server" align="center">
										<asp:datagrid id="grdBPO" runat="server" BackColor="White" Font-Size="8pt" Font-Names="Verdana"
											Width="100%" Height="100px" CellPadding="0" BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False"
											HorizontalAlign="Center">
											<AlternatingItemStyle Font-Names="Verdana" BackColor="#CCCCFF"></AlternatingItemStyle>
											<ItemStyle Font-Names="Verdana" HorizontalAlign="Center"></ItemStyle>
											<HeaderStyle Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" Height="30px" ForeColor="DarkBlue"
												VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="Contract Code">
													<HeaderStyle Width="5%"></HeaderStyle>
													<ItemTemplate>
														<asp:HyperLink id=Hyperlink2 Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CONTRACT_CD")%>' NavigateUrl='<%#"Ongoing_Contracts_Edit.aspx?CONTRACT_CD=" + DataBinder.Eval(Container.DataItem,"CONTRACT_CD")%>'>Select</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="CONTRACT_CD" HeaderText="Contract Code">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CLIENT_TYPE" HeaderText="Client Type"></asp:BoundColumn>
												<asp:BoundColumn DataField="CLIENT_NAME" HeaderText="Client Name">
													<HeaderStyle Width="35%"></HeaderStyle>
													<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid></DIV>
									<asp:label id="Label4" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="384px" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
