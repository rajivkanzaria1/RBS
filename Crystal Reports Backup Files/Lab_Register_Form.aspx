
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab_Register_Form.aspx.cs" Inherits="RBS.Lab_Register_Form.Lab_Register_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lab_Register_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		
		function validate()
		{
		 if(trimAll(document.Form1.lstLab.value)=="")
		 {
		 alert("Select The Lab");
		 event.returnValue=false;
		 document.Form1.lstLab.focus();
		 }
	     else if(trimAll(document.Form1.txtCodeNo.value)=="")
		 {
		 alert("Enter The Code No.");
		 event.returnValue=false;
		 document.Form1.txtCodeNo.focus();
		 }
		 else if(trimAll(document.Form1.txtCodeDt.value)=="")
		 {
		 alert("Enter The Code Date.");
		 event.returnValue=false;
		 document.Form1.txtCodeNo.focus();
		 }
	    }
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Width="196px" ForeColor="DarkBlue" BackColor="White"
								Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">LAB REGISTER</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 264px" align="center" colSpan="5">
						<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="1"
							cellPadding="1" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Sample Registration No.</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="lblRNo" runat="server" Width="60%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Sample Registration Date.</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:textbox id="txtRegDt" onblur="check_date(txtRegDt);" tabIndex="1" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="90%" MaxLength="11" Height="20px"></asp:textbox><asp:label id="lblRegDt" runat="server" Width="60%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 21px" vAlign="top"><asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> Case No. </asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 21px" vAlign="top"><asp:label id="lblCaseNo" runat="server" Width="60%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 21px" vAlign="top"><asp:label id="Label9" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Call Date & Sno.</asp:label></TD>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 25%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 21px"
									vAlign="top"><asp:label id="lblCallDT" runat="server" Width="80px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label>&nbsp;&amp;
									<asp:label id="lblCSNO" runat="server" Width="32px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label10" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Vendor </asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top" colSpan="3"><asp:label id="lblVend" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label><asp:label id="lblVENDCD" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label7" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">IE</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="lblIE" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:label id="lblIECD" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label6" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Date of Dispatch of Sample </asp:label></TD>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 25%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 19px"
									vAlign="top"><asp:textbox id="txtSampleDispatchDT" onblur="check_date(txtSampleDispatchDT);" tabIndex="2"
										runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox><asp:label id="lblSampleDispatchDT" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Date of Drawal of Sample </asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtSampleDrawalDT" onblur="check_date(txtSampleDrawalDT);" tabIndex="3" runat="server"
										Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox><asp:label id="lblSampleDrawalDT" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label5" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Date of Receipt of Sample</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtSampleReceiptDT" onblur="check_date(txtSampleReceiptDT);" tabIndex="4" runat="server"
										Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox><asp:label id="lblSampleReceiptDT" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 25px" vAlign="top"><asp:label id="Label23" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Testing Type</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 25px" vAlign="top" colSpan="3"><asp:radiobutton id="rdbNormal" runat="server" Width="40px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Checked="True" GroupName="g3" Text="Normal " tabIndex="5"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rdbReTesting" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" GroupName="g3" Text="Re-Testing" tabIndex="6"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:label id="Label26" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Total Testing Fee</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:label id="lblTotalTestingFee" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana">0</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:label id="Label27" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Total Handling Charges</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:label id="lblTotalHandlingCharges" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana">0</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:label id="Label28" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Total Service Tax</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:label id="lblTotalServiceTax" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana">0</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label25" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Total Lab Charges</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="lblTotalLabCharges" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana">0</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:label id="Label31" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Total TDS</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:label id="lblTDS" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="80%">0</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:label id="Label29" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Amount Recieved</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top">
									<asp:label id="lblAmtRecieved" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="80%">0</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top"></TD>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top">
									<asp:label id="Label34" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Total Amount Cleared</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top">
									<asp:label id="lblTAmtCleared" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="80%">0</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top">
									<asp:label id="Label36" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Code No</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top">
									<asp:textbox id="txtCodeNo" style="TEXT-ALIGN: center" tabIndex="7" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="15"></asp:textbox></TD>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top">
									<asp:label id="Label37" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Code Date</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top">
									<asp:textbox id="txtCodeDt" onblur="check_date(txtCodeDt);" tabIndex="8" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="11"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top" align="right" bgColor="#ffffff">
									<asp:label id="Label33" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkCyan" Width="72px">Invoice No</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top" bgColor="#ffffff">
									<asp:label id="lblInvoiceNo" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkCyan" Width="80%"></asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top" align="right" bgColor="#ffffff">
									<asp:label id="Label35" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkCyan" Width="72px">Invoice Dt</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top" bgColor="#ffffff">
									<asp:label id="lblInvoiceDt" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkCyan" Width="80%"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center" colSpan="5">
						<TABLE id="Table2" style="WIDTH: 90%; HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="1"
							cellPadding="1" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 65px" vAlign="top"><asp:label id="Label13" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Item</asp:label><asp:label id="lblSNO" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Visible="False"></asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 65px" vAlign="top"><P><asp:dropdownlist id="lstItem" tabIndex="9" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="lstItem_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="txtItem" style="TEXT-ALIGN: center" tabIndex="10" runat="server" Width="100%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="48px" MaxLength="50" TextMode="MultiLine"></asp:textbox></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label14" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">No. Of Samples</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtSample" style="TEXT-ALIGN: center" tabIndex="11" runat="server" Width="25%"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="13"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label15" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Test Category</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:dropdownlist id="lstCategory" tabIndex="12" runat="server" Width="60%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 34px" vAlign="top"><asp:label id="Label17" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Test to be Conducted</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 34px" vAlign="top"><asp:textbox id="txtTest" style="TEXT-ALIGN: center" tabIndex="13" runat="server" Width="100%"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="30px" MaxLength="50" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label20" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Lab</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:dropdownlist id="lstLab" tabIndex="14" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label24" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Date of Sample Dispatched to Lab</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtSampleDispatchTOLabDT" onblur="check_date(txtSampleDispatchTOLabDT);" tabIndex="15"
										runat="server" Width="20%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label11" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Date of Test Report Required</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtTestRepReqDT" onblur="check_date(txtTestRepReqDT);" tabIndex="16" runat="server"
										Width="20%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label12" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Date of Receipt of Test Report</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtTestRepRecDT" onblur="check_date(txtTestRepRecDT);" tabIndex="17" runat="server"
										Width="20%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label18" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Testing Fee</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtTestingFee" style="TEXT-ALIGN: center" tabIndex="18" runat="server" Width="25%"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="13"></asp:textbox>
									<asp:label id="lblTestingFee" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Visible="False">0</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label21" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Service Tax</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtSTax" style="TEXT-ALIGN: center" tabIndex="19" runat="server" Width="25%"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="13"></asp:textbox>
									<asp:label id="lblServiceTax" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Visible="False">0</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label22" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Handling Charges</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtHCharge" style="TEXT-ALIGN: center" tabIndex="20" runat="server" Width="25%"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="13"></asp:textbox>
									<asp:label id="lblHandlingCharges" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Visible="False">0</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label16" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Testing Result</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:dropdownlist id="lstTStatus" tabIndex="21" runat="server" Width="20%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" AutoPostBack="True">
										<asp:ListItem Selected="True"></asp:ListItem>
										<asp:ListItem Value="C">Confirm</asp:ListItem>
										<asp:ListItem Value="N">Not Confirm</asp:ListItem>
										<asp:ListItem Value="X">No Comments</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 7.88%; HEIGHT: 19px" vAlign="top"><asp:label id="Label19" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Remarks</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtRemark" style="TEXT-ALIGN: center" tabIndex="22" runat="server" Width="100%"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="30px" MaxLength="50" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center" colSpan="5"><asp:button id="btnSave" tabIndex="24" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnUpdate" tabIndex="25" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnUpdate_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center" colSpan="5">
						<asp:label id="Label32" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
							BackColor="White" ForeColor="DarkBlue" Width="256px" Visible="False">LAB REGISTER DETAILS</asp:label>
						<TITTLE:CUSTOMDATAGRID id="grdLabDt" runat="server" Width="100%" Height="8px" BorderColor="DarkBlue" AutoGenerateColumns="False"
							PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
							BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="150px" GridWidth="100%">
							<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
							<EditItemStyle Height="10%"></EditItemStyle>
							<FooterStyle CssClass="GridHeader"></FooterStyle>
							<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
								CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="SNo.">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink id=Hyperlink1 Text='<%# DataBinder.Eval(Container.DataItem,"SNO")%>' Runat="server" NavigateUrl='<%#"Lab_register_Form.aspx?SAMPLE_REG_NO=" + DataBinder.Eval(Container.DataItem,"SAMPLE_REG_NO") + "&amp;SNO="+DataBinder.Eval(Container.DataItem,"SNO")+"&amp;Action=M"%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="ITEM_DESC" HeaderText="Item">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="QTY" HeaderText="No. Of Samples">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TEST" HeaderText="Test ">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LAB_NAME" HeaderText="Lab">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TESTING_FEE" HeaderText="Testing Fee">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="REMARKS" HeaderText="Remarks">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SAMPLE_REG_NO" HeaderText="SAMPLE REG NO"></asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 168px" align="center" colSpan="5">
						<asp:label id="Label30" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
							BackColor="White" ForeColor="DarkBlue" Width="506px" Visible="False">LAB PAYMENT RECIEVED AGAINST ABOVE CASE NO. OR VENDOR</asp:label>
						<TITTLE:CUSTOMDATAGRID id="grdPaymentDetails" runat="server" Width="100%" Height="8px" BorderColor="DarkBlue"
							AutoGenerateColumns="False" PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True"
							CssClass="Grid" AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="150px"
							GridWidth="100%" onselectedindexchanged="grdPaymentDetails_SelectedIndexChanged">
							<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
							<EditItemStyle Height="10%"></EditItemStyle>
							<FooterStyle CssClass="GridHeader"></FooterStyle>
							<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
								CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:RadioButton id="rdbCheque" runat="server" GroupName="g1"></asp:RadioButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="CHQ_NO" HeaderText="Chq No.">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CHQ_DATE" HeaderText="Chq Date">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BANK_NAME" HeaderText="Bank">
									<HeaderStyle Width="30%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AMOUNT" HeaderText="Amount">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="BANK_CD" HeaderText="BANK_CD"></asp:BoundColumn>
								<asp:BoundColumn DataField="SUSPENSE_AMT" HeaderText="Suspense Amt">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NARRATION" HeaderText="Remarks">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center" colSpan="5"><asp:button id="btnCancel" tabIndex="26" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button>&nbsp;
						<asp:button id="btnPosting" tabIndex="27" runat="server" Width="97px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Post Amount" Visible="False" onclick="btnPosting_Click"></asp:button>&nbsp;
						<asp:button id="btnPrintInvoice" tabIndex="28" runat="server" Width="150px" ForeColor="DarkBlue"
							Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Text="Print Invoice" onclick="btnPrintInvoice_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
