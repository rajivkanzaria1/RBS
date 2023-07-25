<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchesOrder1_LOA.aspx.cs" Inherits="RBS.Vendor.PurchesOrder1_LOA" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl_Vend" Src="~/Vendor/Vendor_Menu.aspx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PurchesOrder1_LOA</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="../date.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 184px"
				cellSpacing="1" cellPadding="1" border="0">
				<TBODY>
					<TR>
						<TD>
							<P align="center">
								<uc1:WebUserControl_Vend id="WebUserControl_Vend1" runat="server"></uc1:WebUserControl_Vend></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P><asp:label id="Label1" runat="server" Height="19px" Font-Bold="True" Width="311px" BackColor="White"
									ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana">REGISTERED LOA "ADD NEW ITEMS" FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<td style="WIDTH: 100%">
							<P align="center">
								<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 40px" cellSpacing="1" cellPadding="1" width="935"
									bgColor="#f0f8ff" border="1" borderColor="#b0c4de">
									<TR>
										<TD style="WIDTH: 10%"><asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Case Number</asp:label></TD>
										<TD style="WIDTH: 15%" align="left"><asp:textbox id="txtCsNo" onblur="makeUppercase();" tabIndex="1" runat="server" Height="20px"
												Width="100%" BackColor="LavenderBlush" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="9"></asp:textbox></TD>
										<TD style="WIDTH: 15%"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana"> Offer Letter No.</asp:label></TD>
										<TD style="WIDTH: 35%"><asp:textbox id="txtPONo" tabIndex="2" runat="server" Height="20px" Width="100%" BackColor="White"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
										<TD style="WIDTH: 10%"><asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">LOA Date</asp:label></TD>
										<TD style="WIDTH: 15%"><asp:textbox id="txtPODate" onblur="check_date(txtPODate);" tabIndex="3" runat="server" Height="20px"
												Width="100%" BackColor="White" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 10%"></TD>
										<TD style="WIDTH: 15%" align="left"></TD>
										<TD style="WIDTH: 15%">
											<asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Font-Bold="True"> Vendor Name</asp:label></TD>
										<TD style="WIDTH: 35%">
											<asp:textbox id="txtVendName" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" BackColor="White" Width="100%" Height="20px"></asp:textbox></TD>
										<TD style="WIDTH: 10%"></TD>
										<TD style="WIDTH: 15%"></TD>
									</TR>
								</TABLE>
								<asp:label id="Label8" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">
								To Edit a LOA --> Enter Case No. & Click on "Modify LOA" button</asp:label><asp:label id="Label7" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">
								To Search a LOA --> Enter Case 
								No. or Offer Letter No or LOA Date Or First Few Characters of Vendor Name and click on "Search LOA" button</asp:label></P>
							<P align="center">
							</P>
						</td>
					</TR>
					<TR>
						<TD style="HEIGHT: 9px" align="center" width="100%">
							<asp:button id="btnModifyPO" tabIndex="12" runat="server" Font-Bold="True" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Modify LOA"></asp:button><asp:button id="btnSearchPO" tabIndex="14" runat="server" Font-Bold="True" Width="83px" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Search LOA"></asp:button></TD>
					</TR>
					<TR>
						<TD align="left" width="100%">
							<DIV><TITTLE:CUSTOMDATAGRID id="DgPO1" runat="server" Height="8px" Width="100%" GridWidth="100%" GridHeight="350px"
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
										<asp:HyperLinkColumn Text="Select" DataNavigateUrlField="CASE_NO" DataNavigateUrlFormatString="PurchesOrder1_LOA.aspx?CASE_NO={0}"
											NavigateUrl="PurchesOrder1_LOA.aspx">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:BoundColumn DataField="CASE_NO" HeaderText="Case Number">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PO_NO" HeaderText="Offer Letter Number">
											<HeaderStyle Width="20%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PO_DT" HeaderText="LOA Date">
											<HeaderStyle Width="15%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RLY_CD" HeaderText="Agency">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="VEND_NAME" HeaderText="Vendor">
											<HeaderStyle Width="25%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CONSIGNEE_S_NAME" HeaderText="Purchaser Name">
											<HeaderStyle Width="15%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="INSPECTING_AGENCY" HeaderText="Inspection By/PO Cancelled">
											<ItemStyle ForeColor="Blue"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="PO_DOC" HeaderText="View PO"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="PO_DOC1" HeaderText="View PO"></asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></DIV>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>

