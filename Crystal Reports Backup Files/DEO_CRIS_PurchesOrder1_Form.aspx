<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DEO_CRIS_PurchesOrder1_Form.aspx.cs" Inherits="RBS.DEO_CRIS_PurchesOrder1_Form.DEO_CRIS_PurchesOrder1_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
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
									PageSize="15" BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid"
									AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="500px" GridWidth="100%">
									<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
									<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
									<FooterStyle CssClass="GridHeader"></FooterStyle>
									<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
									<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
										CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn HeaderText="Select">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemTemplate>
												<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"DEO_CRIS_PurchesOrder_Form.aspx?IMMS_POKEY=" + DataBinder.Eval(Container.DataItem,"IMMS_POKEY")+ "&amp;IMMS_RLY_CD=" + DataBinder.Eval(Container.DataItem,"IMMS_RLY_CD")%>'>Select</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="IMMS_POKEY" ReadOnly="True" HeaderText="Ref No.">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PO_NO" ReadOnly="True" HeaderText="Purchase Order Number">
											<HeaderStyle Width="15%"></HeaderStyle>
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
										<asp:BoundColumn DataField="RLY_CD" HeaderText="Agency">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="VEND_NAME" ReadOnly="True" HeaderText="Vendor">
											<HeaderStyle Width="20%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="POI" HeaderText="Place of Inspection">
											<HeaderStyle Width="20%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REGION" ReadOnly="True" HeaderText="Region">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REMARKS" HeaderText="Remarks"></asp:BoundColumn>
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
