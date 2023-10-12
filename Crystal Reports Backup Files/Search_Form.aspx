<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search_Form.aspx.cs" Inherits="RBS.Search_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Search Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtCaseNo.value)=="" && trimAll(document.Form1.txtDtOfReciept.value)=="" && trimAll(document.Form1.txtCSNO.value)=="" && trimAll(document.Form1.txtPONO.value)=="" && trimAll(document.Form1.txtPODT.value)=="" && trimAll(document.Form1.txtBKNo.value)=="" && trimAll(document.Form1.txtBNO.value)=="" && trimAll(document.Form1.txtSetNo.value)=="" && trimAll(document.Form1.txtBDT.value)=="" && trimAll(document.Form1.lstIE.value)=="" && trimAll(document.Form1.txtVend.value)=="" && trimAll(document.Form1.txtBPO.value)=="" && trimAll(document.Form1.txtSCon.value)=="" && trimAll(document.Form1.txtBAMT.value)=="")
		{
			alert("Enter Some Search Criteria First!!!");
			event.returnValue=false;
		}
		else if(trimAll(document.Form1.txtCSNO.value)!="" && isNaN(parseInt(trimAll(document.Form1.txtCSNO.value))))
		{
			alert("CALL SNO. CONTAINS INVALID CHARACTERS!!!");
			event.returnValue=false;
		}
		else if(trimAll(document.Form1.txtCaseNo.value)!="" && trimAll(document.Form1.txtCaseNo.value).length < 9)
		{
			alert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
			event.returnValue=false;
		}
		else if(trimAll(document.Form1.txtBAMT.value)!="" && IsNumeric(trimAll(document.Form1.txtBAMT.value))==false)
		{
			alert("BILL AMOUNT CONTAINS INVALID CHARACTERS!!!");
			event.returnValue=false;
		}
		else
		return;
		}
		
		function makeUppercase(field)
		 {
			document.Form1.field.value = document.Form1.field.value.toUpperCase();
		
		 }
		 
		function validate1(field)
		{
		 var val1=trimAll(field.value);
		 if(val1.length<2)
		 {
		  alert("Please Enter Atleast 2 Charaters in Search Criteria!!!");
		  event.returnValue=false;
		 }
		}
		
		function validate2()
		{
		if(trimAll(document.Form1.txtPONO.value).length < 3 && trimAll(document.Form1.txtPODT.value)=="")
		{
		 alert("Enter Atleast 3 Digits of PO No. OR PO DATE to search the Records ");
		 event.returnValue=false;
		 }
		 
		else 
		return;
			
		}
		
		function abc()
		 {
		 
		 document.Form1.txtCaseNo.focus();
		 }
		 
		 function validate3()
		{
		if(trimAll(document.Form1.txtCaseNo.value)=="")
		{
		 alert("CASE NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtDtOfReciept.value)=="")
		 {
		 alert("DATE OF RECIEPT IN RITES CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else 
		return;
		}
        </script>
</HEAD>
	<BODY bgColor="white" onload="abc();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Width="177px" ForeColor="DarkBlue" BackColor="White"
								Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">SEARCH FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 50%" align="center">
						<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 100%" border="0">
							<TR>
								<TD>
									<TABLE id="Table3" style="WIDTH: 100%" borderColor="#b0c4de" bgColor="aliceblue" border="1"
										height="100%">
										<TR>
											<TD style="WIDTH: 95px" align="right" height="25"><asp:label id="Label6" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Case No.</asp:label></TD>
											<TD height="25"><asp:textbox id="txtCaseNo" onChange="javascript:this.value=this.value.toUpperCase();" tabIndex="1"
													runat="server" Width="150px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="9"
													Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 95px" align="right" height="25"><asp:label id="Label5" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">PO No.</asp:label></TD>
											<TD height="25"><asp:textbox id="txtPONO" tabIndex="2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
													Font-Names="Verdana" MaxLength="45" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 95px" align="right" height="25"><asp:label id="Label7" runat="server" Width="60px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">PO Date</asp:label></TD>
											<TD height="25"><asp:textbox id="txtPODT" onblur="check_date(txtPODT);" tabIndex="3" runat="server" Width="40%"
													ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 95px" align="right" height="25"><asp:label id="Label13" runat="server" Width="60px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Book No.</asp:label></TD>
											<TD height="25"><asp:textbox id="txtBKNo" onblur="makeUppercasebk();" tabIndex="4" runat="server" Width="50px"
													ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="4" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 95px" align="right" height="25"><asp:label id="Label14" runat="server" Width="60px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Set No.</asp:label></TD>
											<TD height="25"><asp:textbox id="txtSetNo" onblur="change();" tabIndex="5" runat="server" Width="50px" ForeColor="DarkBlue"
													Font-Size="8pt" Font-Names="Verdana" MaxLength="3" Height="20px"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 50%">
									<TABLE id="Table4" style="WIDTH: 100%" borderColor="#b0c4de" height="100%" bgColor="aliceblue"
										border="1">
										<TR>
											<TD style="WIDTH: 30%" align="right" height="25"><asp:label id="Label2" runat="server" Width="63px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Call Date</asp:label></TD>
											<TD style="WIDTH: 70%" height="25"><asp:textbox id="txtDtOfReciept" onblur="check_date(txtDtOfReciept);" tabIndex="6" runat="server"
													Width="150px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%" align="right" height="25"><asp:label id="Label9" runat="server" Width="62px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Call SNo.</asp:label></TD>
											<TD style="WIDTH: 70%; HEIGHT: 19px" height="25"><asp:textbox id="txtCSNO" onblur="check_date(txtDtOfReciept);" tabIndex="7" runat="server" Width="50px"
													ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="5" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%" align="right" height="25"><asp:label id="Label17" runat="server" Width="60px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">IE</asp:label></TD>
											<TD style="WIDTH: 70%; HEIGHT: 29px"><asp:dropdownlist id="lstIE" tabIndex="8" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
													Font-Names="Verdana" Height="20px"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 30px" align="right"><asp:label id="Label15" runat="server" Width="60px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Bill No.</asp:label></TD>
											<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:textbox id="txtBNO" onChange="javascript:this.value=this.value.toUpperCase();" style="TEXT-ALIGN: right"
													tabIndex="9" runat="server" Width="50%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="11" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 36px" align="right"><asp:label id="Label16" runat="server" Width="60px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Bill Date</asp:label></TD>
											<TD style="WIDTH: 70%"><asp:textbox id="txtBDT" onblur="check_date(txtBDT);" style="TEXT-ALIGN: right" tabIndex="10"
													runat="server" Width="50%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="11" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 36px" align="right">
												<asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="76px">Bill Amount</asp:label></TD>
											<TD style="WIDTH: 70%">
												<asp:textbox id="txtBAMT" onblur="check_date(txtPODT);" tabIndex="11" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="50%" Height="20px" MaxLength="13"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 50%" align="center">
						<TABLE id="Table5" style="WIDTH: 100%; HEIGHT: 102%" borderColor="#b0c4de" bgColor="aliceblue"
							border="1">
							<tr>
								<td style="WIDTH: 97px" align="right"><asp:label id="Label11" runat="server" Width="32px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">BPO</asp:label></td>
								<td><asp:textbox id="txtBPO" style="TEXT-ALIGN: center" tabIndex="12" runat="server" Width="72px"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="5" Height="20px"></asp:textbox><asp:button id="btnFC_List" tabIndex="13" runat="server" Width="96px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Height="20px" Text="Select BPO" onclick="btnFC_List_Click"></asp:button>
									<asp:label id="Label8" runat="server" Width="424px" ForeColor="DarkMagenta" Font-Bold="True"
										Font-Size="7pt" Font-Names="Verdana">To Search a BPO-> Enter First Few Characters of BPO Name and Click on Select BPO</asp:label><asp:dropdownlist id="lstBPO" tabIndex="14" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Height="20px" AutoPostBack="True" Visible="False" onselectedindexchanged="lstBPO_SelectedIndexChanged"></asp:dropdownlist></td>
							</tr>
							<TR>
								<TD style="WIDTH: 97px" align="right"><asp:label id="Label10" runat="server" Width="60px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Consignee</asp:label></TD>
								<TD>
									<asp:textbox id="txtSCon" tabIndex="15" runat="server" Width="72px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" MaxLength="50" Height="20px"></asp:textbox>
									<asp:button id="btnSCon" tabIndex="16" runat="server" Width="120px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Search Consignee" onclick="btnSCon_Click"></asp:button>
									<asp:label id="Label19" runat="server" Width="424px" ForeColor="DarkMagenta" Font-Bold="True"
										Font-Size="7pt" Font-Names="Verdana">To Search a Consignee-> Enter First Few Charaters of "Firm/Desig/Dept" and Click on Select Consignee</asp:label><asp:dropdownlist id="lstConsignee" tabIndex="17" runat="server" Width="100%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Height="20px" AutoPostBack="True" Visible="False" onselectedindexchanged="lstConsignee_SelectedIndexChanged"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 97px" align="right"><asp:label id="Label12" runat="server" Width="48px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Vendor</asp:label></TD>
								<TD><asp:textbox id="txtVend" tabIndex="18" runat="server" Width="79px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Height="20px"></asp:textbox><asp:button id="btnFCList" tabIndex="19" runat="server" Width="99px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Select Vendor" ToolTip="Enter the Vendor Code or 1st few letters of Vendor then click on select Vendor Button" onclick="btnFCList_Click"></asp:button>
									<asp:label id="Label18" runat="server" Width="460px" ForeColor="DarkMagenta" Font-Bold="True"
										Font-Size="7pt" Font-Names="Verdana">To Search a Vendor-> Enter First Few Characters of Vendor Name and Click on Select Vendor</asp:label><asp:dropdownlist id="ddlVender" tabIndex="20" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Height="25px" AutoPostBack="True" Visible="False" onselectedindexchanged="ddlVender_SelectedIndexChanged"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center">
						<P><asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana">To Search a Case-> Enter One or more parameters and Click on Search Button</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center"><asp:button id="btnSearch" tabIndex="21" runat="server" Width="65px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center">
						<DIV><TITTLE:CUSTOMDATAGRID id="grdCNO" runat="server" Width="100%" Height="8px" PageSize="15" FreezeRows="0"
								CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
								BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="150px"
								GridWidth="100%">
<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF">
</AlternatingItemStyle>

<EditItemStyle Height="10%">
</EditItemStyle>

<FooterStyle CssClass="GridHeader">
</FooterStyle>

<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal">
</ItemStyle>

<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
<HeaderStyle Width="10%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PO_NO" HeaderText="PO No.">
<HeaderStyle Width="15%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PO_DT" HeaderText="PO Date">
<HeaderStyle Width="10%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CALL_RECV_DT" HeaderText="Call Date">
<HeaderStyle Width="10%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CALL_SNO" HeaderText="Call SNo.">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="BK_NO" HeaderText="Book No.">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SET_NO" HeaderText="Set No.">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="IE_SNAME" HeaderText="IE">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CONSIGNEE" HeaderText="Consignee">
<HeaderStyle Width="10%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="BILL_NO" HeaderText="Bill No.">
<HeaderStyle Width="10%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="BILL_DT" HeaderText="Bill Dt">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="INSP_FEE" HeaderText="Insp Fee">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="BILL_AMOUNT" HeaderText="Bill Amount">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
			</TABLE></TD></TR></TABLE></TD></TR></TABLE></form>
	</BODY>
</HTML>

