﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DEO_CRIS_PurchesOrder_MA_Form.aspx.cs" Inherits="RBS.DEO_CRIS_PurchesOrder_MA_Form.DEO_CRIS_PurchesOrder_MA_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Purchase Order MA Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bottomMargin="7" bgColor="#ffffff" leftMargin="8" topMargin="7" rightMargin="8">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 184px"
				cellSpacing="1" cellPadding="1" border="0">
				<TBODY>
					<TR>
						<TD>
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
									BackColor="White" Width="100%" Font-Bold="True" Height="19px">MA ISSUED BY CRIS AGAINST CRIS PURCHASE ORDERS REGISTERED IN RITES</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" width="100%"><asp:panel id="Panel1" runat="server" Width="100%" Height="1px" Visible="False">
								<DIV>
									<TITTLE:CUSTOMDATAGRID id="DgPO1" runat="server" Width="100%" Height="8px" Visible="False" GridWidth="100%"
										GridHeight="500px" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid"
										UseAccessibleHeader="True" CellPadding="2" FreezeRows="0" BorderColor="DarkBlue" PageSize="15" AutoGenerateColumns="False">
										<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
										<FooterStyle CssClass="GridHeader"></FooterStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
										<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
											CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="Select">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemTemplate>
													<asp:HyperLink id="Hyperlink3" Runat="server" NavigateUrl='<%#"DEO_CRIS_PurchesOrder_MA_Form.aspx?RLY=" + DataBinder.Eval(Container.DataItem,"RLY") + "&amp;MAKEY=" + DataBinder.Eval(Container.DataItem,"MAKEY")+ "&amp;SLNO=" + DataBinder.Eval(Container.DataItem,"SLNO")%>'>Select</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="CASE_NO" HeaderText="RITES CASE NO.">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IMMS_POKEY" ReadOnly="True" HeaderText="Ref No.">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PO_NO" ReadOnly="True" HeaderText="Purchase Order Number">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PO_DT" ReadOnly="True" HeaderText="Purchase Order Date">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IMMS_RLY_CD" ReadOnly="True" HeaderText="Client">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RECV_DT" ReadOnly="True" HeaderText="Recv Date">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IMMS_RLY_SHORTNAME" HeaderText="Agency">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="VEND_NAME" ReadOnly="True" HeaderText="Vendor">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MA_NO" HeaderText="MA NO.">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MA_DT" HeaderText="MA DT">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SUBJECT" ReadOnly="True" HeaderText="SUBJECT">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MA_FLD_DESCR" HeaderText="MA FIELD">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NEW_VALUE" HeaderText="NEW VALUE">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="RLY" HeaderText="RLY"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="MAKEY" HeaderText="MAKEY"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="SLNO" HeaderText="SLNO"></asp:BoundColumn>
										</Columns>
									</TITTLE:CUSTOMDATAGRID>
									<asp:label id="lblError" runat="server" Font-Names="Verdana" Font-Size="Large" ForeColor="Crimson"
										BackColor="White" Font-Bold="True" Visible="False">No MA's found. !!!</asp:label></DIV>
							</asp:panel></TD>
					</TR>
					<tr>
						<td><asp:panel id="Panel2" runat="server" Width="100%" Height="1px" Visible="False">
								<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 31.74%" borderColor="#b0c4de" cellSpacing="0"
									cellPadding="0" bgColor="aliceblue" border="1">
									<TR bgColor="#ccccff">
										<TD style="WIDTH: 10.85%; HEIGHT: 23px">
											<asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">Case No</asp:label></TD>
										<TD style="WIDTH: 50.62%; HEIGHT: 23px" colSpan="3">
											<asp:label id="txtCaseNo" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Font-Bold="True">Case No </asp:label></TD>
									</TR>
									<TR bgColor="#ccccff">
										<TD style="WIDTH: 11.85%; HEIGHT: 39px">
											<asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">PO No </asp:label></TD>
										<TD style="WIDTH: 50.62%; HEIGHT: 39px">
											<asp:label id="lblPONO" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Width="80%" Font-Bold="True"></asp:label></TD>
										<TD style="WIDTH: 10.16%; HEIGHT: 39px">
											<asp:label id="Label18" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">PO Date</asp:label></TD>
										<TD style="WIDTH: 15%; HEIGHT: 39px">
											<asp:label id="lblPODT" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Font-Bold="True"></asp:label></TD>
									</TR>
									<TR bgColor="#ccccff">
										<TD style="WIDTH: 11.85%; HEIGHT: 39px">
											<asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">MA No </asp:label></TD>
										<TD style="WIDTH: 50.62%; HEIGHT: 39px">
											<asp:label id="lblMANo" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Width="80%" Font-Bold="True"></asp:label></TD>
										<TD style="WIDTH: 10.16%; HEIGHT: 39px">
											<asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">MA Date</asp:label></TD>
										<TD style="WIDTH: 15%; HEIGHT: 39px">
											<asp:label id="lblMADT" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Font-Bold="True">MA Date </asp:label></TD>
									</TR>
									<TR bgColor="#ccccff">
										<TD style="WIDTH: 11.85%; HEIGHT: 26px">
											<asp:label id="Label17" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">Vendor</asp:label></TD>
										<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
											<asp:label id="lblVend" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Width="90%" Font-Bold="True">Vendor </asp:label></TD>
									</TR>
									<TR bgColor="#ccccff">
										<TD style="WIDTH: 11.85%; HEIGHT: 26px">
											<asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">MA Subject</asp:label></TD>
										<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
											<asp:label id="lblMASubject" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Width="90%" Font-Bold="True"></asp:label></TD>
									</TR>
									<TR bgColor="#ccccff">
										<TD style="WIDTH: 11.85%; HEIGHT: 26px">
											<asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">MA Field</asp:label></TD>
										<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
											<asp:label id="lblMAField" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Width="90%" Font-Bold="True"></asp:label></TD>
									</TR>
									<TR bgColor="#ccccff">
										<TD style="WIDTH: 11.85%; HEIGHT: 28px">
											<asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">New Value</asp:label></TD>
										<TD style="WIDTH: 30.43%; HEIGHT: 28px">
											<asp:label id="lblMANewVal" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Width="90%" Font-Bold="True"></asp:label></TD>
										<TD style="WIDTH: 12.16%; HEIGHT: 28px">
											<asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">Old Value</asp:label></TD>
										<TD style="WIDTH: 19.24%; HEIGHT: 28px">
											<asp:label id="lblMAOldVal" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Width="90%" Font-Bold="True"></asp:label></TD>
									</TR>
									<TR bgColor="#ccccff">
										<TD style="WIDTH: 11.85%; HEIGHT: 28px" align="center" colSpan="4">
											<asp:hyperlink id="HyperLink1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True">View MA</asp:hyperlink></TD>
									</TR>
									<TR bgColor="#ccccff">
										<TD style="WIDTH: 11.85%; HEIGHT: 26px">
											<asp:label id="Label23" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True">MA Status</asp:label></TD>
										<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
											<asp:dropdownlist id="lstStatus" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="10pt"
												ForeColor="DarkBlue" Width="50%" Font-Bold="True" Height="25px">
												<asp:ListItem Value="A">Approved</asp:ListItem>
												<asp:ListItem Value="N">Approved With No Changes in IBS</asp:ListItem>
												<asp:ListItem Selected="True"></asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR bgColor="#ccccff">
										<TD style="WIDTH: 30.43%; HEIGHT: 26px" align="center" colSpan="4">
											<asp:button id="btnSave" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="61px" Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</asp:panel></td>
					</tr>
					</TD></TR>
					<TR>
						<TD align="center"><asp:button id="btnCancel" tabIndex="30" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Width="58px" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
