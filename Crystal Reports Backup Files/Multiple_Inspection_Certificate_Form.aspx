<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Multiple_Inspection_Certificate_Form.aspx.cs" Inherits="RBS.Multiple_Inspection_Certificate_Form.Multiple_Inspection_Certificate_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Multiple IC's Bill</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 30px" align="center" colSpan="6">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 6.73%; HEIGHT: 40px" align="center" colSpan="6"><asp:label id="Label1" runat="server" BackColor="White" Width="100%" Font-Names="Verdana" Font-Size="10pt"
							ForeColor="DarkBlue" Font-Bold="True">MULTIPLE INSPECTION CERTIFICATE BILL GENERATION FORM</asp:label></TD>
				</TR>
				<TR bgColor="#f0f8ff">
					<TD style="WIDTH: 5.26%; HEIGHT: 51px" align="right" colSpan="3"><FONT face="Verdana" color="darkblue" size="2"><asp:label id="Label22" runat="server" Width="117px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								Font-Bold="True">Bill Paying Officer</asp:label></FONT></TD>
					<TD style="WIDTH: 8%; HEIGHT: 51px" colSpan="3"><FONT face="Verdana" color="darkblue" size="2"><asp:textbox id="txtBPO" style="TEXT-ALIGN: center" tabIndex="11" runat="server" Width="72px"
								Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="5"></asp:textbox><asp:button id="btnFC_List" tabIndex="12" runat="server" Width="96px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Height="20px" Text="Select BPO" onclick="btnFC_List_Click"></asp:button><asp:dropdownlist id="lstBPO" tabIndex="13" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Height="20px" Visible="False" AutoPostBack="True" onselectedindexchanged="lstBPO_SelectedIndexChanged"></asp:dropdownlist></FONT></TD>
				</TR>
				<TR bgColor="#f0f8ff">
					<TD style="WIDTH: 10%; HEIGHT: 51px" align="right"><asp:label id="Label27" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True"> FEE</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 51px"><asp:textbox id="txtBPOFee" style="TEXT-ALIGN: right" tabIndex="20" runat="server" Width="50%"
							Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="10"></asp:textbox></TD>
					<TD style="WIDTH: 10%; HEIGHT: 51px" align="right"><asp:label id="Label26" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True"> FEE Type</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 51px"><asp:dropdownlist id="lstBPOFeeType" tabIndex="21" runat="server" Width="100%" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Height="25px" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD style="WIDTH: 10%; HEIGHT: 51px" align="right"><asp:label id="Label25" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True"> TAX Type</asp:label></TD>
					<TD style="WIDTH: 30%; HEIGHT: 51px"><asp:dropdownlist id="lstBPOTaxType" tabIndex="22" runat="server" Width="100%" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Height="25px"></asp:dropdownlist></TD>
				</TR>
				<TR bgColor="#f0f8ff">
					<TD style="WIDTH: 10%; HEIGHT: 51px" align="right"><asp:label id="Label36" runat="server" Width="55px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True"> Bill Date</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 51px"><asp:textbox id="txtBDT" onblur="check_date(txtBDT);compareDates(txtCertDt,txtBDT,'Bill Date Date Cannot Be Earlier Than Certification Date')"
							style="TEXT-ALIGN: right" tabIndex="17" runat="server" Width="50%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Height="20px" MaxLength="11"></asp:textbox></TD>
					<TD style="WIDTH: 10%; HEIGHT: 51px" align="right"><asp:label id="Label33" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True"> Min Fee Payble (if any)</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 51px"><asp:textbox id="txtMinFeeAllow" style="TEXT-ALIGN: right" tabIndex="18" runat="server" Width="50%"
							Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="11"></asp:textbox></TD>
					<TD style="WIDTH: 10%; HEIGHT: 51px" align="right"><asp:label id="Label31" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True"> Max Fee Allowed (if any)</asp:label></TD>
					<TD style="WIDTH: 30%; HEIGHT: 51px"><asp:textbox id="txtMaxFeeAllow" style="TEXT-ALIGN: right" tabIndex="19" runat="server" Width="50%"
							Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="11"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><asp:button id="btnView" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True" Text="View " onclick="btnView_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><TITTLE:CUSTOMDATAGRID id="grdCDetails" runat="server" Width="90%" Height="8px" PageSize="15" FreezeRows="0"
							CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue" BorderWidth="1px" FreezeColumns="0"
							FreezeHeader="True" AutoGenerateColumns="False" GridHeight="200px" GridWidth="100%">
							<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
							<EditItemStyle Height="10%"></EditItemStyle>
							<FooterStyle CssClass="GridHeader"></FooterStyle>
							<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
								CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Select">
									<ItemTemplate>
										<asp:CheckBox id="SelIC" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CALL_RECV_DT" HeaderText="Call Date">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CALL_SNO" HeaderText="Call SNo.">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ITEM_SRNO_PO" HeaderText="ITEM SRNO">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IC_NO" HeaderText="IC NO">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CONSIGNEE" HeaderText="Consignee"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CONSIGNEE_CD" HeaderText="Consignee"></asp:BoundColumn>
								<asp:BoundColumn DataField="BK_NO" HeaderText="Book No"></asp:BoundColumn>
								<asp:BoundColumn DataField="SET_NO" HeaderText="Set No"></asp:BoundColumn>
								<asp:BoundColumn DataField="NO_OF_INSP" HeaderText="No. Of Insp's"></asp:BoundColumn>
								<asp:BoundColumn DataField="QTY_PASSED" HeaderText="Qty Passed">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="QTY_REJECTED" HeaderText="Qty Rejected">
									<HeaderStyle Width="21%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="QTY_DUE" HeaderText="Qty Due">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6">
						<P><asp:label id="Label" runat="server" Width="354px" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana">Plz Wait For a moment, it will take some time !!!</asp:label></P>
						<P><asp:button id="btnGBill" tabIndex="26" runat="server" Width="250px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Text="Generate Bill" ToolTip="Please Save the Inspection Certificate and Edit Items Qty Passed, Rejected and Due before Generating the Bill!!!" onclick="btnGBill_Click"></asp:button></P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
