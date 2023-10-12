<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inspection_Fee_Bill.aspx.cs" Inherits="RBS.Inspection_Fee_Bill.Inspection_Fee_Bill" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Inspection Fee Bill</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(document.Form1.txtCaseNo.value=="")
		{
		 alert("CASE NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else if(document.Form1.txtDtOfReciept.value=="")
		{
		 alert("DATE OF RECIEPT IN RITES CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else if(document.Form1.CALL_LETTER_DT.value=="")
		{
		 alert("CALL LETTER DATE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else if(document.Form1.CALL_MARK_DT.value=="")
		{
		 alert("CALL MARK DATE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else if(document.Form1.DT_INSP_DESIRE.value=="")
		{
		 alert("EXPECTED DATE OF INSPECTION CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else
		{
		alert("YOUR RECORD IS SAVED")
		}
		 return;
	 
		}
		function del()
		{
		var d=confirm("Click OK to Confirm Delete!!!");
		if(d==true)
		event.returnValue=true;
		else
		event.returnValue=false;
		}
		
        </script>
	</HEAD>
	<body bgColor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				borderColor="#b0c4de" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD style="HEIGHT: 34px" colSpan="10">
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" colSpan="10">
						<P align="center"><asp:label id="Label1" runat="server" ForeColor="DarkBlue" Font-Bold="True" BackColor="White"
								Font-Size="10pt" Font-Names="Verdana" Width="274px">INSPECTION FEE BILL</asp:label></P>
					</TD>
				</TR>
				<tr bgColor="#ccccff">
					<TD style="WIDTH: 10%; HEIGHT: 23px"><asp:label id="Label14" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%">Bill No.</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 23px"><asp:label id="txtBillNo" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%">Bill No.</asp:label></TD>
					<TD style="WIDTH: 8%; HEIGHT: 23px"><asp:label id="Label15" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="64px">Bill Date (dd/mm/yyyy)</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 23px"><asp:label id="txtBillDt" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%">Bill DT</asp:label></TD>
					<TD style="WIDTH: 7%; HEIGHT: 23px" align="right"><asp:label id="Label12" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="68px">Case No.</asp:label>&nbsp;&nbsp;</TD>
					<TD style="WIDTH: 35%; HEIGHT: 23px"><asp:label id="txtCaseNo" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%">Case No </asp:label></TD>
				</tr>
				<TR>
					<TD style="WIDTH: 10%; HEIGHT: 35px"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="72px">Max Fee Allowed</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 35px" align="left" colSpan="2"><asp:textbox id="txtMaxFeeAll" style="TEXT-ALIGN: right" tabIndex="1" runat="server" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="50%" MaxLength="13" Height="20px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
					<TD style="HEIGHT: 35px"></TD>
					<TD style="WIDTH: 7%; HEIGHT: 36px"><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="72px">Min Fee Payable</asp:label></TD>
					<TD style="WIDTH: 35%; HEIGHT: 36px"><asp:textbox id="txtMinFee" style="TEXT-ALIGN: right" tabIndex="2" runat="server" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="60%" MaxLength="13" Height="20px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 10%; HEIGHT: 35px"><asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%"> Fee Rate</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 35px"><asp:textbox id="txtFRate" style="TEXT-ALIGN: right" tabIndex="3" runat="server" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="40%" MaxLength="9" Height="20px"></asp:textbox></TD>
					<TD style="WIDTH: 8%; HEIGHT: 35px"><asp:label id="Label4" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%">Fee Type</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 35px"><asp:dropdownlist id="lstBPOFeeType" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Width="100%" Height="25px"></asp:dropdownlist></TD>
					<TD style="WIDTH: 7%; HEIGHT: 36px"><asp:label id="Label9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%">Tax Type</asp:label></TD>
					<TD style="WIDTH: 35%; HEIGHT: 36px"><asp:dropdownlist id="lstBPOTaxType" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Size="7pt"
							Font-Names="Verdana" Width="100%" Height="25px" colspan="1"></asp:dropdownlist>
						<asp:dropdownlist id="lstBPOTaxType_GST" tabIndex="33" runat="server" Width="90%" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Height="25px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 10%; HEIGHT: 32px" align="left" colSpan="1" rowSpan="1"><asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%">Total Value</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 32px" align="left"><asp:textbox id="txtBAmt" style="TEXT-ALIGN: right" tabIndex="6" runat="server" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="60%" MaxLength="15" Height="20px"></asp:textbox></TD>
					<TD style="WIDTH: 8%; HEIGHT: 32px"><asp:label id="Label18" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%">Insp. Fee</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 32px" align="left"><asp:textbox id="txtInsFee" style="TEXT-ALIGN: right" tabIndex="7" runat="server" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="60%" MaxLength="13" Height="20px"></asp:textbox></TD>
					<TD style="WIDTH: 7%; HEIGHT: 32px"><asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%"> Serv. Tax</asp:label></TD>
					<TD style="WIDTH: 35%; HEIGHT: 32px"><asp:textbox id="txtServTax" style="TEXT-ALIGN: right" tabIndex="8" runat="server" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="50%" MaxLength="11" Height="20px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 10%; HEIGHT: 32px" align="left"><asp:label id="Label24" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%"> Edu. Cess</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 32px" align="left"><asp:textbox id="txtEduCess" style="TEXT-ALIGN: right" tabIndex="9" runat="server" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="60%" MaxLength="10" Height="20px"></asp:textbox></TD>
					<TD style="WIDTH: 8%; HEIGHT: 32px"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%">S.Higher Edu Cess</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 32px" align="left"><asp:textbox id="txtSEduCess" style="TEXT-ALIGN: right" tabIndex="10" runat="server" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="60%" MaxLength="13" Height="20px"></asp:textbox></TD>
					<TD style="WIDTH: 7%; HEIGHT: 32px">
						<asp:label id="Label26" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Swachh Bharat Cess</asp:label></TD>
					<TD style="WIDTH: 35%; HEIGHT: 32px">
						<asp:textbox id="txtSBCess" style="TEXT-ALIGN: right" tabIndex="10" runat="server" Width="60%"
							Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="13"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 10%; HEIGHT: 32px" align="left">
						<asp:label id="Label27" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Krishi Kalyan Cess</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 32px" align="left">
						<asp:textbox id="txtKKCess" style="TEXT-ALIGN: right" tabIndex="10" runat="server" Width="60%"
							Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="13"></asp:textbox></TD>
					<TD style="WIDTH: 8%; HEIGHT: 32px">
						<asp:label id="Label28" runat="server" Width="80px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">CGST</asp:label></TD>
					<TD style="WIDTH: 7%; HEIGHT: 32px">
						<asp:textbox id="txtCGST" style="TEXT-ALIGN: right" tabIndex="10" runat="server" Width="60%"
							Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="13"></asp:textbox></TD>
					<TD style="WIDTH: 7%; HEIGHT: 32px">
						<asp:label id="Label29" runat="server" Width="80px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">SGST</asp:label></TD>
					<TD style="WIDTH: 35%; HEIGHT: 32px">
						<asp:textbox id="txtSGST" style="TEXT-ALIGN: right" tabIndex="10" runat="server" Width="60%"
							Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="13"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 10%; HEIGHT: 32px" align="left">
						<asp:label id="Label30" runat="server" Width="80px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">IGST</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 32px" align="left">
						<asp:textbox id="txtIGST" style="TEXT-ALIGN: right" tabIndex="10" runat="server" Width="60%"
							Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="13"></asp:textbox></TD>
					<TD style="WIDTH: 8%; HEIGHT: 32px" colSpan="2"></TD>
					<TD style="WIDTH: 7%; HEIGHT: 32px"><asp:label id="Label17" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%">T. Fee</asp:label></TD>
					<TD style="WIDTH: 35%; HEIGHT: 32px"><asp:textbox id="txtTFee" style="TEXT-ALIGN: right" tabIndex="11" runat="server" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="50%" MaxLength="13" Height="20px" ontextchanged="txtTFee_TextChanged"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><asp:button id="btnSave" tabIndex="12" runat="server" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Width="67px" Text="Save" Visible="False" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="13" runat="server" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Width="67px" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnBItems" tabIndex="14" runat="server" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Width="122px" Text="Items In The Bill" Visible="False" onclick="btnBItems_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6">
						<DIV><TITTLE:CUSTOMDATAGRID id="grdBDetails" runat="server" BackColor="White" Font-Size="8pt" Font-Names="Verdana"
								Width="100%" GridHeight="200px" FreezeColumns="0" FreezeHeader="True" BorderStyle="Groove" AutoGenerateColumns="False"
								BorderColor="Navy" CellPadding="0" PageSize="1">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="7pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Wrap="False"></EditItemStyle>
								<FooterStyle Wrap="False" CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="7pt" Font-Names="Verdana" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
									ForeColor="DarkBlue" CssClass="GridHeader" VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn Visible="False">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"Items_In_Bill.aspx?BILL_No=" + DataBinder.Eval(Container.DataItem,"BILL_NO") + "&amp;ITEM_SRNO=" + DataBinder.Eval(Container.DataItem,"ITEM_SRNO")%>' runat="server">Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="BILL_NO" HeaderText="Bill No.">
										<HeaderStyle Width="1%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ITEM_SRNO" HeaderText="Item S No.">
										<HeaderStyle Width="1%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ITEM_DESC" HeaderText="Item Description">
										<HeaderStyle Width="20%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Font-Size="6pt" Font-Names="Arial"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QTY" HeaderText="Quantity">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RATE" HeaderText="Rate">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UOM_CD" HeaderText="UOM">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BASIC_VALUE" HeaderText="Basic Value">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SALES_TAX_PER" HeaderText="Sales Tax %">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SALES_TAX" HeaderText="Sales Tax">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="EXCISE_PER" HeaderText="Excise %">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="EXCISE" HeaderText="Excise">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DISCOUNT_PER" HeaderText="Discount %">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DISCOUNT" HeaderText="Discount Value">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OTHER_CHARGES" HeaderText="Other Charges">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VALUE" HeaderText="Total Value">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="6"><asp:button id="btnCancel" tabIndex="15" runat="server" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Width="67px" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><asp:panel id="Panel1" runat="server" Height="180px">
							<P>
								<asp:label id="Label8" runat="server" Width="50%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
									ForeColor="OrangeRed">Receipt Details</asp:label></P>
							<TABLE id="Table5" style="WIDTH: 98%; HEIGHT: 82px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" bgColor="#fff7d6" border="1">
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label23" runat="server" Width="77px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue">Bill No.</asp:label></P>
									</TD>
									<TD style="WIDTH: 15%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label21" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue">Bill Amount</asp:label></P>
									</TD>
									<TD style="WIDTH: 20%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label20" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue">Amount Recieved Thru Cheque/DD</asp:label></P>
									</TD>
									<TD style="WIDTH: 15%; HEIGHT: 20px" align="center">
										<asp:label id="Label16" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue">TDS</asp:label></TD>
									<TD style="WIDTH: 15%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label22" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue">Retention Money</asp:label></P>
									</TD>
									<TD style="WIDTH: 20%; HEIGHT: 20px" align="center">
										<asp:label id="Label25" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue">Write off Amt/Amt Adjusted</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 28px" align="center">
										<asp:label id="lblBNO" runat="server" Width="95%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed"></asp:label></TD>
									<TD style="WIDTH: 15%; HEIGHT: 28px" align="center">
										<asp:label id="lblBAmt" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed"></asp:label></TD>
									<TD style="WIDTH: 20%; HEIGHT: 28px" align="center">
										<asp:label id="lblBAmtRec" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
											Font-Bold="True" ForeColor="DarkGreen"></asp:label></TD>
									<TD style="WIDTH: 15%; HEIGHT: 28px" align="center">
										<P>
											<asp:label id="lblTds" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed"></asp:label></P>
									</TD>
									<TD style="WIDTH: 15%; HEIGHT: 28px" align="center">
										<asp:label id="lblRetMoney" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
											Font-Bold="True" ForeColor="OrangeRed"></asp:label></TD>
									<TD style="WIDTH: 20%; HEIGHT: 28px" align="center">
										<P>
											<asp:label id="lblWriteOffAmt" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
												Font-Bold="True" ForeColor="OrangeRed"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 28px" align="center">
										<asp:label id="Label31" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue">CNote Amount</asp:label></TD>
									<TD style="WIDTH: 15%; HEIGHT: 28px" align="center">
										<P>
											<asp:label id="lblCNoteAmt" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
												Font-Bold="True" ForeColor="OrangeRed"></asp:label></P>
									</TD>
									<TD style="WIDTH: 20%; HEIGHT: 28px" align="center">
										<P>
											<asp:label id="Label19" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue">Total Amount Recieved</asp:label></P>
									</TD>
									<TD style="WIDTH: 15%; HEIGHT: 28px" align="center">
										<asp:label id="lblTamtRec" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
											Font-Bold="True" ForeColor="OrangeRed"></asp:label></TD>
									<TD style="WIDTH: 15%; HEIGHT: 28px" align="center">
										<P>
											<asp:label id="Label13" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue">Amount To Recover</asp:label></P>
									</TD>
									<TD style="WIDTH: 20%; HEIGHT: 28px" align="center">
										<P>
											<asp:label id="lblAmtToRec" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
												Font-Bold="True" ForeColor="OrangeRed"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 28px" align="center" colSpan="6">
										<asp:label id="Label11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkGreen">Cheque Wise Breakup Of Amount Recieved</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 28px" align="center" colSpan="6">
										<P>
											<TITTLE:CUSTOMDATAGRID id="grdCHQDetails" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
												BackColor="White" PageSize="1" CellPadding="0" BorderColor="Navy" AutoGenerateColumns="False" BorderStyle="Groove"
												FreezeHeader="True" FreezeColumns="0" GridHeight="100px" CssClass="Grid" BorderWidth="1px" FreezeRows="0"
												AddEmptyHeaders="0" UseAccessibleHeader="True">
												<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
												<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
												<EditItemStyle Wrap="False"></EditItemStyle>
												<FooterStyle Wrap="False" CssClass="GridHeader"></FooterStyle>
												<ItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridNormal"></ItemStyle>
												<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
													ForeColor="DarkBlue" CssClass="GridHeader" VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="BANK_NAME" HeaderText="Bank">
														<HeaderStyle Width="25%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CHQ_NO" HeaderText="Cheque No.">
														<ItemStyle HorizontalAlign="center"></ItemStyle>
														<HeaderStyle Width="30%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CHQ_DT" HeaderText="Cheque Dt">
														<HeaderStyle Width="15%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="AMOUNT" HeaderText="Cheque Amount">
														<HeaderStyle Width="15%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="AMOUNT_CLEARED" HeaderText="Amount Cleared">
														<HeaderStyle Width="15%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
											</TITTLE:CUSTOMDATAGRID></P>
									</TD>
								</TR>
							</TABLE>
						</asp:panel></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
