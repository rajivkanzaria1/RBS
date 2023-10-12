<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DEO_Vendor_PurchesOrder1_Form.aspx.cs" Inherits="RBS.DEO_Vendor_PurchesOrder1_Form.DEO_Vendor_PurchesOrder1_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Purchase Order Form</title>
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
									BackColor="White" Width="100%" Font-Bold="True" Height="19px">PURCHASE ORDER SUBMITTED BY VENDORS AWAITING ALLOCATION OF CASE NUMBER</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<DIV><TITTLE:CUSTOMDATAGRID id="DgPO1" runat="server" Width="100%" Height="8px" AutoGenerateColumns="False"
									PageSize="15" OnEditCommand="DgPO1_Edit" OnUpdateCommand="DgPO1_Update" OnCancelCommand="DgPO1_Cancel"
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
										<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit Case No.">
											<HeaderStyle Width="5%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:EditCommandColumn>
										<asp:HyperLinkColumn Text="Select" DataNavigateUrlField="CASE_NO" DataNavigateUrlFormatString="DEO_Vendor_PurchesOrder_Form.aspx?CASE_NO={0}">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:BoundColumn DataField="CASE_NO" ReadOnly="True" HeaderText="Ref No.">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PO_NO" ReadOnly="True" HeaderText="Purchase Order Number">
											<HeaderStyle Width="15%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PO_DT" ReadOnly="True" HeaderText="Purchase Order Date">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="RLY_NONRLY" ReadOnly="True" HeaderText="Client">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RECV_DT" ReadOnly="True" HeaderText="Recv Date">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RLY_CD" ReadOnly="True" HeaderText="Agency">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="VEND_NAME" ReadOnly="True" HeaderText="Vendor">
											<HeaderStyle Width="15%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REMARKS" ReadOnly="True" HeaderText="Remarks">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Real Case No.">
											<HeaderStyle Width="5%"></HeaderStyle>
											<ItemTemplate>
												<asp:Label id=Label34 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REAL_CASE_NO") %>'>
												</asp:Label>
											</ItemTemplate>
											<EditItemTemplate>
												<asp:TextBox id=txtRealCSNO runat="server" Height="24px" Text='<%# DataBinder.Eval(Container, "DataItem.REAL_CASE_NO") %>' MaxLength="9">
												</asp:TextBox>
											</EditItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="PO_DOC" ReadOnly="True">
											<HeaderStyle Width="5%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID><asp:label id="lblError" runat="server" Font-Names="Verdana" Font-Size="Large" ForeColor="Crimson"
									BackColor="White" Font-Bold="True" Visible="False">No PurchaseOrder found. !!!</asp:label></DIV>
						</TD>
					</TR>
					<TR>
						<TD align="center"><asp:button id="btnCancel" tabIndex="30" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Width="58px" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
