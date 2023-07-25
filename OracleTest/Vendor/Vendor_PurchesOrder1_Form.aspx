<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendor_PurchesOrder1_Form.aspx.cs" Inherits="RBS.Vendor.Vendor_PurchesOrder1_Form" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Vendor Purchase Order Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="..\date.js"></script>
		<script language="javascript">		 
		function validate()
		{
		 if(trimAll(document.Form1.txtCsNo.value)=="")
		 {
			alert("PLEASE ENTER CASE NUMBER!!");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCsNo.value)!="" && trimAll(document.Form1.txtCsNo.value).length < 9)
		 {
			alert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
			event.returnValue=false;
		 }
		 else
		 return;			 
		}
		function search()
		{
		 if(trimAll(document.Form1.txtCsNo.value)=="" && trimAll(document.Form1.txtPONo.value).length < 3 && trimAll(document.Form1.txtPODate.value)=="")
		 {
			alert("PLEASE ENTER EITHER REF NUMBER/ATLEAST 3 DIGITS OF PO NUMBER/PO DATE");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCsNo.value)!="" && trimAll(document.Form1.txtCsNo.value).length < 9)
		 {
			alert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
			event.returnValue=false;
		 }
		 else
		 
		 return;			 
		}
		
		
		function makeUppercase()
		 {
			document.Form1.txtCsNo.value = document.Form1.txtCsNo.value.toUpperCase();
		 }
		function sFocus()
		 {
		 
		 document.Form1.txtCsNo.focus();
		 }
        </script>
	</HEAD>
	<body bottomMargin="7" bgColor="#ffffff" leftMargin="8" topMargin="7" onload=" sFocus();"
		rightMargin="8" MS_POSITIONING="GridLayout">
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
							<P><asp:label id="Label1" runat="server" Height="19px" Font-Bold="True" Width="174px" BackColor="White"
									ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana">PURCHASE ORDER FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<td style="WIDTH: 100%">
							<P align="center">
								<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 40px" cellSpacing="1" cellPadding="1" width="935"
									bgColor="#f0f8ff" border="1" borderColor="#b0c4de">
									<TR>
										<TD colSpan="3" style="HEIGHT: 33px">
											<asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="9pt" ForeColor="DeepPink"
												Width="100%" Font-Bold="True">NEW PURCHASE ORDER</asp:label></TD>
										<TD colSpan="3" align="left" style="HEIGHT: 31px">
											<asp:button id="btnNewPO" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="288px" Font-Bold="True" Text="Click here for NEW PURCHASE ORDER"></asp:button></TD>
									</TR>
									<TR>
										<TD colSpan="6" style="HEIGHT: 33px">
											<asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="9pt" ForeColor="DeepPink"
												Width="100%" Font-Bold="True">UPDATE EXISTING PURCHASE ORDER DETAILS</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 10%"><asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana"> Ref No.</asp:label></TD>
										<TD style="WIDTH: 15%" align="left"><asp:textbox id="txtCsNo" tabIndex="1" runat="server" Height="20px" Width="100%" BackColor="LavenderBlush"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="9"></asp:textbox></TD>
										<TD style="WIDTH: 15%"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana"> PO/Offer Letter No.</asp:label></TD>
										<TD style="WIDTH: 35%"><asp:textbox id="txtPONo" tabIndex="2" runat="server" Height="20px" Width="100%" BackColor="White"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
										<TD style="WIDTH: 10%"><asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">PO Date (DD/MM/YYYY)</asp:label></TD>
										<TD style="WIDTH: 15%"><asp:textbox id="txtPODate" onblur="check_date(txtPODate);" tabIndex="3" runat="server" Height="20px"
												Width="100%" BackColor="White" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
									</TR>
								</TABLE>
								<asp:label id="Label8" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">
								To Edit/Delete a PO --> Enter Case No. & Click on "Modify PO"/"Delete PO" button</asp:label><asp:label id="Label7" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">
								To Search a PO --> Enter Ref No. or PO/Offer Letter No or PO Date and click on "Search PO" button</asp:label></P>
							<P align="center">
							</P>
						</td>
					</TR>
					<TR>
						<TD style="HEIGHT: 9px" align="center" width="100%">
							<asp:button id="btnModifyPO" tabIndex="5" runat="server" Font-Bold="True" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Modify PO"></asp:button>
							<asp:button id="btnDeletePO" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Text="Delete PO"></asp:button><asp:button id="btnSearchPO" tabIndex="7" runat="server" Font-Bold="True" Width="83px" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Search PO"></asp:button></TD>
					</TR>
					<TR>
						<TD align="left" width="100%">
							<DIV><TITTLE:CUSTOMDATAGRID id="DgPO1" runat="server" Height="8px" Width="100%" GridWidth="100%" GridHeight="300px"
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
										<asp:HyperLinkColumn Text="Select" DataNavigateUrlField="CASE_NO" DataNavigateUrlFormatString="Vendor_PurchesOrder_Form.aspx?CASE_NO={0}"
											NavigateUrl="PurchesOrder_Form.aspx">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:BoundColumn DataField="CASE_NO" HeaderText="Ref No.">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PO_NO" HeaderText="Purchase Order Number">
											<HeaderStyle Width="15%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PO_DT" HeaderText="Purchase Order Date">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RLY_CD" HeaderText="Agency">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="VEND_NAME" HeaderText="Vendor">
											<HeaderStyle Width="15%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CONSIGNEE_S_NAME" HeaderText="Purchaser Name">
											<HeaderStyle Width="15%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REMARKS" HeaderText="Remarks">
											<HeaderStyle Width="15%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REAL_CASE_NO" ReadOnly="True" HeaderText="Case No.">
											<HeaderStyle Width="5%"></HeaderStyle>
											<ItemStyle ForeColor="Red"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></DIV>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>