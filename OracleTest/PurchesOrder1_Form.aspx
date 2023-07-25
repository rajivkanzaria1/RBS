<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchesOrder1_Form.aspx.cs" Inherits="RBS.PurchesOrder1_Form1" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE html>

<HTML>
	<HEAD>
		<title>Purchase Order Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
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
		 if(trimAll(document.Form1.txtCsNo.value)=="" && trimAll(document.Form1.txtPONo.value).length < 3 && trimAll(document.Form1.txtPODate.value)=="" && trimAll(document.Form1.txtVendName.value).length<3)
		 {
			alert("PLEASE ENTER EITHER CASE NUMBER/ATLEAST 3 DIGITS OF PO NUMBER/PO DATE/ATLEAST FIRST 3 CHARACTERS OF VENDOR NAME");
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
		
		function validate1()
		{
		if(document.Form1.rdbRailway.checked==false && document.Form1.rdbPrivate.checked==false && document.Form1.rdbPSU.checked==false && document.Form1.rdbFRailway.checked==false && document.Form1.rdbSGovt.checked==false)
		 {
			alert("PLEASE SELECT EITHER IT IS A RAILWAY OR NON RAILWAY CASE");
			event.returnValue=false;
		 }
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
		rightMargin="8">
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
										<TD style="WIDTH: 10%"><asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Case Number</asp:label></TD>
										<TD style="WIDTH: 15%" align="left"><asp:textbox id="txtCsNo" onblur="makeUppercase();" tabIndex="1" runat="server" Height="20px"
												Width="100%" BackColor="LavenderBlush" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="9"></asp:textbox></TD>
										<TD style="WIDTH: 15%"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana"> PO/Offer Letter No.</asp:label></TD>
										<TD style="WIDTH: 35%"><asp:textbox id="txtPONo" tabIndex="2" runat="server" Height="20px" Width="100%" BackColor="White"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
										<TD style="WIDTH: 10%"><asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">PO Date</asp:label></TD>
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
								To Edit/Delete a PO --> Enter Case No. & Click on "Modify PO"/"Delete PO" button</asp:label><asp:label id="Label7" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">
								To Search a PO --> Enter Case 
								No. or PO/Offer Letter No or PO Date Or First Few Characters of Vendor Name and click on "Search PO" button</asp:label></P>
							<P align="center">
								<TABLE id="Table2" style="WIDTH: 80%; HEIGHT: 40px" cellSpacing="1" cellPadding="1" width="199"
									bgColor="#f0f8ff" border="1" borderColor="#b0c4de">
									<TR>
										<TD align="center" colSpan="5"><asp:label id="Label5" runat="server" Font-Bold="True" Width="123px" ForeColor="DarkMagenta"
												Font-Size="8pt" Font-Names="Verdana">In Case Of New PO</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 22%"><asp:radiobutton id="rdbRailway" tabIndex="5" runat="server" Font-Bold="True" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Text="Railway" GroupName="rnr" AutoPostBack="True" oncheckedchanged="rdbRailway_CheckedChanged"></asp:radiobutton></TD>
										<TD style="WIDTH: 15%">
											<P><asp:radiobutton id="rdbPrivate" tabIndex="6" runat="server" Font-Bold="True" ForeColor="DarkBlue"
													Font-Size="8pt" Font-Names="Verdana" Text="Private" GroupName="rnr" AutoPostBack="True" oncheckedchanged="rdbRailway_CheckedChanged"></asp:radiobutton></P>
										</TD>
										<TD style="WIDTH: 25%">
											<P><asp:radiobutton id="rdbFRailway" tabIndex="7" runat="server" Font-Bold="True" ForeColor="DarkBlue"
													Font-Size="8pt" Font-Names="Verdana" Text="Foreign Railway" GroupName="rnr" AutoPostBack="True" oncheckedchanged="rdbRailway_CheckedChanged"></asp:radiobutton></P>
										</TD>
										<TD style="WIDTH: 10%">
											<P><asp:radiobutton id="rdbPSU" tabIndex="8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
													Font-Names="Verdana" Text="PSU" GroupName="rnr" AutoPostBack="True" oncheckedchanged="rdbRailway_CheckedChanged"></asp:radiobutton></P>
										</TD>
										<TD style="WIDTH: 28%">
											<P><asp:radiobutton id="rdbSGovt" tabIndex="9" runat="server" Font-Bold="True" ForeColor="DarkBlue"
													Font-Size="8pt" Font-Names="Verdana" Text="State Government" GroupName="rnr" AutoPostBack="True" oncheckedchanged="rdbRailway_CheckedChanged"></asp:radiobutton></P>
										</TD>
									</TR>
									<tr>
										<td style="WIDTH: 22%" colSpan="5">
											<asp:dropdownlist id="ddlRCode" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="100%" Height="25px" Visible="False"></asp:dropdownlist></td>
									</tr>
								</TABLE>
							</P>
						</td>
					</TR>
					<TR>
						<TD style="HEIGHT: 9px" align="center" width="100%"><asp:button id="btnNewPO" tabIndex="11" runat="server" Font-Bold="True" Width="83px" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="New PO" onclick="btnNewPO_Click"></asp:button>
							<asp:button id="btnModifyPO" tabIndex="12" runat="server" Font-Bold="True" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Modify PO" onclick="btnModifyPO_Click"></asp:button><asp:button id="btnDeletePO" tabIndex="13" runat="server" Font-Bold="True" Width="92px" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Delete PO" onclick="btnDeletePO_Click"></asp:button><asp:button id="btnSearchPO" tabIndex="14" runat="server" Font-Bold="True" Width="83px" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Search PO" onclick="btnSearchPO_Click"></asp:button>
							<asp:button id="btnEditPODT" tabIndex="15" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Width="99px" Font-Bold="True" Text="Edit PO Date" onclick="btnEditPODT_Click"></asp:button></TD>
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
										<asp:HyperLinkColumn Text="Select" DataNavigateUrlField="CASE_NO" DataNavigateUrlFormatString="PurchesOrder_Form.aspx?CASE_NO={0}"
											NavigateUrl="PurchesOrder_Form.aspx">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:BoundColumn DataField="CASE_NO" HeaderText="Case Number">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PO_NO" HeaderText="Purchase Order Number">
											<HeaderStyle Width="20%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PO_DT" HeaderText="Purchase Order Date">
											<HeaderStyle Width="15%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RLY_CD" HeaderText="Agency">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Source" HeaderText="PO SOURCE"></asp:BoundColumn>
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
										<asp:BoundColumn DataField="PO_DOC" HeaderText="View PO"></asp:BoundColumn>
										<asp:BoundColumn DataField="PO_DOC1" HeaderText="View PO"></asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></DIV>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
