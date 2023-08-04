<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inspection_Certificate_Form.aspx.cs" Inherits="RBS.Inspection_Certificate_Form.Inspection_Certificate_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>INSPECTION CERTIFICATE FORM</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		
		function datevalidate()
		{
			var chkdt="";
			var msg="";
			if(document.Form1.txtCDate.value!="")
			{
			
			chkdt=document.Form1.txtCDate;
			msg='CallDate';
			
			}
			if(document.Form1.txtFIDT.value!="")
			{
				if(chkdt=="")
				{
				chkdt=document.Form1.txtFIDT;
				msg='First Inspection Date';
				}
				else if(compareDates(chkdt,document.Form1.txtFIDT,'First Inspection Date Cannot Be Earlier Than'+msg+''))
				{
				chkdt=document.Form1.txtFIDT;
				msg='First Inspection Date';
				}
				else
				{
				return;
				}
			}
			if(document.Form1.txtLIDT.value!="")
			{
				if(chkdt=="")
				{
				chkdt=document.Form1.txtLIDT;
				msg='Last Inspection Date';
				}
				else if(compareDates(chkdt,document.Form1.txtLIDT,'Last Inspection Date Cannot Be Earlier Than '+msg+''))
				{
				
				chkdt=document.Form1.txtLIDT;
				msg='Last Inspection Date';
				}
				else
				{
				return;
				}
			}
			
			if(document.Form1.txtCertDt.value!="")
			{
				
				if(chkdt=="")
				{
				chkdt=document.Form1.txtCertDt;
				msg='Certificate Date';
				}
				else if(compareDates(chkdt,document.Form1.txtCertDt,'Certificate Date Cannot Be Earlier Than '+msg+''))
				{
				chkdt=document.Form1.txtCertDt;
				msg='Certificate Date';
				}
				else
				{
				return;
				}
				
			}
			
			if(document.Form1.txtICSDT.value!="")
			{
				if(chkdt=="")
				{
				chkdt=document.Form1.txtICSDT;
				msg='IC Submit Date';
				}
				else if(compareDates(chkdt,document.Form1.txtICSDT,'IC Submit Date Cannot Be Earlier Than '+msg+''))
				{
				chkdt=document.Form1.txtICSDT;
				msg='IC Submit Date';
				}
				else
				{
				return;
				}
			}
		}
		function abc()
		{
		if(trimAll(document.Form1.lstICType.value)=="2")
		 {
				document.Form1.txtQPASS.value=0;
				
		 }
		}
		
		function validate()
		{
		 if(trimAll(document.Form1.txtBKNO.value)=="")
		 {
		 alert("BOOK NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtBKNO.focus();
		 }
		 else if(trimAll(document.Form1.lstICType.value)=="2")
		 {
			if(trimAll(document.Form1.txtReason.value)=="")
			{
				alert("REASON FOR REJECTION CANNOT BE LEFT BLANK IN CASE OF REJECTION IC");
				event.returnValue=false;
				 document.Form1.txtReason.focus();
			}
		 }
		 else if(trimAll(document.Form1.txtSetNo.value)=="")
		 {
		 alert("SET NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtSetNo.focus();
		 }
		 else if(trimAll(document.Form1.txtCertNo.value)=="")
		 {
		 alert("CERTIFICATE NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtCertNo.focus();
		 }
		 else if(trimAll(document.Form1.txtGSTINNo.value)=="")
		{
		 alert("CONSIGNEE GSTIN NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtGSTINNo.focus();
		}
		 else if(document.Form1.txtGSTINNo.value.length != 15)
		 {
		 alert("PLZ ENTER 15 CHARACTERS LONG GSTIN NO. ONLY!!!");
		 event.returnValue=false;
		 document.Form1.txtGSTINNo.focus();
		 }
		 else if(trimAll(document.Form1.txtCertDt.value)=="")
		 {
		 alert("CERTIFICATE DATE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtCertDt.focus();
		 }
		 else if(trimAll(document.Form1.txtNofIns.value)=="")
		 {
		 alert("NO. OF VISITS CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtNofIns.focus();
		 }
		 else if(trimAll(document.Form1.txtFIDT.value)=="")
		 {
		 alert("FIRST INSP DATE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtFIDT.focus();
		 }
		 else if(trimAll(document.Form1.txtLIDT.value)=="")
		 {
		 alert("LAST INSP DATE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtLIDT.focus();
		 }
		 else if(trimAll(document.Form1.txtICSDT.value)=="")
		 {
		 alert("IC SUBMIT DATE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtICSDT.focus();
		 }
		 else if(trimAll(document.Form1.lstStampPatternCD.value)=="")
		 {
		   alert("SEALING PATTERN CANNOT BE LEFT BLANK");
		   event.returnValue=false;
		 }
		 //else if(document.Form1.txtReason.value=="")
		// {
		// alert("REASON CANNOT BE LEFT BLANK");
		// event.returnValue=false;
		// }
		 else if(trimAll(document.Form1.txtCInstallNo.value)=="")
		 {
		 alert("CALL INSTALL NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtCInstallNo.focus();
		 }
		 else if(document.Form1.txtCInstallNo.value!="" && IsNumeric(document.Form1.txtCInstallNo.value)== false)
		 {
		 alert("INVALID CHARACTERS IN INSTALL NO., ONLY NUMERIC ENTRY IS ALLOWED");
		 event.returnValue=false;
		 document.Form1.txtCInstallNo.focus();
		 }
		else 
		{
		document.Form1.btnSave.style.visibility = 'hidden';
		return;
		
		}
		}
		function del()
		{
		var d=confirm("Click OK to Confirm Delete!!!");
		if(d==true)
		{event.returnValue=true};
		else
		{event.returnValue=false};
		}
		
		function sFocus()
		 {
		 if(document.Form1.lstConsignee=="[object]")
		 {
		  document.Form1.lstConsignee.focus();
		 }
		 else
		 {
		  document.Form1.lstICType.focus();
		 }
		 }
		function validate1()
		{
		if(trimAll(document.Form1.txtBDT.value)=="") 
		 {
		 alert("BILL DATE CANNOT BE BLANK.");
		 event.returnValue=false;		
		 }
		else if(trimAll(document.Form1.txtBPOFee.value)=="") 
		 {
		 alert("FEE RATE CANNOT BE BLANK.");
		 event.returnValue=false;		
		 }
		 else if(document.Form1.lstBPOFeeType.value=="") 
		 {
		 alert("ENTER A VALID FEE TYPE.");
		 event.returnValue=false;		
		 }
		 else if(document.Form1.lstBPOTaxType.value=="") 
		 {
		 alert("ENTER A VALID TAX TYPE.");
		 event.returnValue=false;		
		 }
		 else if(document.Form1.txtMaxFeeAllow.value!="" && IsNumeric(document.Form1.txtMaxFeeAllow.value) == false)
		 {
		 alert("INVALID CHARACTERS IN MAXM FEE ALLOWED");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtMinFeeAllow.value!="" && IsNumeric(document.Form1.txtMinFeeAllow.value) == false)
		 {
		 alert("INVALID CHARACTERS IN MINM FEE PAYBLE");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtGSTINNo.value)=="")
		{
		 alert("CONSIGNEE GSTIN NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtGSTINNo.focus();
		}
		else if(trimAll(document.Form1.txtLegalName.value)=="")
		{
		 alert("LEGAL NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtGSTINNo.focus();
		}
		 else if(document.Form1.txtMinFeeAllow.value!="" && document.Form1.txtMaxFeeAllow.value!="")
		 {
			var intmax = parseInt(document.Form1.txtMaxFeeAllow.value);
			var intmin = parseInt(document.Form1.txtMinFeeAllow.value);
			if(intmin > intmax)
			{
			alert("MINIMUM FEE PAYBLE CANNOT BE GREATER THEN MAXIMUM FEE");
			event.returnValue=false;
			}
		 } 
		 else if(document.Form1.lstBPO!="[object]")
		 {
			alert("SELECT THE BPO FIRST !!!");
			event.returnValue=false;
		 }
		 else
		{
			document.Form1.btnGBill.style.visibility = 'hidden';
			
		}

		}
		
		function makeUppercase()
		 {
			document.Form1.txtBKNO.value = document.Form1.txtBKNO.value.toUpperCase();
		 }
		 
		function change()
		{
			var d=document.Form1.txtSetNo.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="00" + d;
				document.Form1.txtSetNo.value=d;
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="0" + d;
				document.Form1.txtSetNo.value=d;
				event.returnValue=false;
			}
			return false;	
		}
		
		function minmaxfeeenableordisable()
		{
			if(document.Form1.lstBPOFeeType.value=="L") 
			{
				document.Form1.txtMaxFeeAllow.value="";
				document.Form1.txtMinFeeAllow.value="";
				document.Form1.txtMaxFeeAllow.disabled=true;
				document.Form1.txtMinFeeAllow.disabled=true;
			}
			else
			{
				document.Form1.txtMaxFeeAllow.disabled=false;
				document.Form1.txtMinFeeAllow.disabled=false;
			
			}
		
		
		}
		function cpy_firstinspdt()
		{
			if(trimAll(document.Form1.txtLIDT.value)=="")
			{
				if(check_date(document.Form1.txtFIDT.value))
				{
				document.Form1.txtLIDT.value=document.Form1.txtFIDT.value;
				}
			}
		
		}
		function validate2()
		{
		 if(trimAll(document.Form1.txtGSTINNo.value)=="")
		{
		 alert("CONSIGNEE GSTIN NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtGSTINNo.focus();
		}
		else if(trimAll(document.Form1.txtLegalName.value)=="")
		{
		 alert("LEGAL NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 document.Form1.txtGSTINNo.focus();
		}
		 else if(document.Form1.txtGSTINNo.value.length != 15)
		 {
		 alert("PLZ ENTER 15 CHARACTERS LONG GSTIN NO. ONLY!!!");
		 event.returnValue=false;
		 document.Form1.txtGSTINNo.focus();
		 }
		 
		else 
		{
		document.Form1.btnGSTNoUpdate.style.visibility = 'hidden';
		return;
		
		}
		}
        </script>
	</HEAD>
	<BODY bgColor="white" onload="sFocus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" colSpan="4" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="4">
						<P><asp:textbox id="txtSysDate" runat="server" Width="1px" Height="1px" BorderStyle="None"></asp:textbox><asp:label id="Label1" runat="server" Width="191px" ForeColor="DarkBlue" BackColor="White"
								Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">INSPECTION CERTIFICATE</asp:label></P>
					</TD>
				</TR>
				<tr bgColor="#ccccff">
					<TD style="WIDTH: 15%; HEIGHT: 23px"><asp:label id="Label12" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Case No</asp:label></TD>
					<TD style="WIDTH: 50.62%; HEIGHT: 23px"><asp:label id="txtCaseNo" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Case No </asp:label><asp:label id="lblSTS" runat="server" Visible="False">Label</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;
						<asp:label id="Label50" runat="server" Width="125px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">Stock/Non Stock</asp:label><asp:label id="lblStockNonStock" runat="server" Width="112px" ForeColor="OrangeRed" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
					<TD style="WIDTH: 14.16%; HEIGHT: 23px"><asp:label id="Label16" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"> Call Date - SNo. </asp:label></TD>
					<TD style="WIDTH: 12%; HEIGHT: 23px"><asp:label id="txtDtOfReciept" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">C Date </asp:label>&nbsp;-
						<asp:label id="lblCSNO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">C SNO</asp:label></TD>
				</tr>
				<tr bgColor="#ccccff">
					<TD style="WIDTH: 15%; HEIGHT: 29px"><asp:label id="Label13" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Contract No </asp:label></TD>
					<TD style="WIDTH: 50.62%; HEIGHT: 29px"><asp:label id="lblPONO" runat="server" Width="70%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"></asp:label>&nbsp;&nbsp;
						<asp:label id="lblSource" runat="server" Width="25%" ForeColor="OrangeRed" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label><asp:label id="lblBPO_TYPE" runat="server" Width="70%" ForeColor="OrangeRed" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:label></TD>
					<TD style="WIDTH: 10.16%; HEIGHT: 29px"><asp:label id="Label18" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Date</asp:label></TD>
					<TD style="WIDTH: 15%; HEIGHT: 29px"><asp:label id="lblPODT" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">PO Date </asp:label></TD>
				</tr>
				<tr bgColor="#ccccff">
					<TD style="WIDTH: 15%; HEIGHT: 26px"><asp:label id="Label17" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Vendor</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 26px"><asp:label id="lblVend" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Vendor </asp:label></TD>
					<TD style="WIDTH: 12.16%; HEIGHT: 26px"><asp:label id="Label23" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Inspecting Er.</asp:label></TD>
					<TD style="WIDTH: 19.24%; HEIGHT: 26px"><asp:label id="lblIE" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">IE</asp:label><asp:label id="lblIESName" runat="server" Width="70%" ForeColor="OrangeRed" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Visible="False">IE</asp:label><asp:label id="lblIECD" runat="server" Width="5%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Visible="False">IE</asp:label></TD>
				</tr>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 15%; HEIGHT: 26px"><asp:label id="Label45" runat="server" ForeColor="Crimson" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Name & Address of the party in whose favour invoice is to be raised.</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 26px"><asp:label id="lblBPOCall" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
					<TD style="WIDTH: 12.16%; HEIGHT: 26px"><asp:label id="Label46" runat="server" ForeColor="Crimson" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"> GSTIN No. of the party in whose favour invoice is to be raised.</asp:label></TD>
					<TD style="WIDTH: 19.24%; HEIGHT: 26px"><asp:label id="lblGSTINCall" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
				</TR>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 15%; HEIGHT: 24px"><asp:label id="lblIRFCBPO" runat="server" ForeColor="Crimson" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">IRFC BPO</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 24px"><asp:dropdownlist id="ddlIRFCBPO" tabIndex="1" runat="server" Width="99%" Height="20px" ForeColor="DarkBlue"
							Font-Bold="True" Font-Size="6pt" Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="ddlIRFCBPO_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD style="WIDTH: 12.16%; HEIGHT: 24px"><asp:label id="lblIRFCFunded" runat="server" ForeColor="Crimson" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">IRFC Funded</asp:label></TD>
					<TD style="WIDTH: 19.24%; HEIGHT: 26px"><asp:dropdownlist id="ddlIRFC" tabIndex="9" runat="server" Width="56px" Height="25px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="ddlIRFC_SelectedIndexChanged">
							<asp:ListItem Selected="True"></asp:ListItem>
							<asp:ListItem Value="Y">Yes</asp:ListItem>
							<asp:ListItem Value="N">No</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 15%; HEIGHT: 24px" align="left" colSpan="4"><asp:label id="Label24" runat="server" Width="46px" ForeColor="DarkCyan" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Bill No:</asp:label>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblBillNo" runat="server" Width="13%" ForeColor="DarkCyan" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label><asp:label id="Label32" runat="server" Width="104px" ForeColor="DarkCyan" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"> Material Value:</asp:label><asp:label id="lblTMValue" runat="server" Width="13%" ForeColor="DarkCyan" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label><asp:label id="Label34" runat="server" Width="64px" ForeColor="DarkCyan" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"> Insp Fee:</asp:label><asp:label id="lblTIFee" runat="server" Width="13%" ForeColor="DarkCyan" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"></asp:label><asp:label id="Label41" runat="server" Width="56px" ForeColor="DarkCyan" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"> Net Fee:</asp:label><asp:label id="lblNetFee" runat="server" Width="13%" ForeColor="DarkCyan" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label><asp:label id="Label43" runat="server" Width="80px" ForeColor="DarkCyan" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Invoice No.:</asp:label><asp:label id="lblInvoiceNo" runat="server" Width="13%" ForeColor="DarkCyan" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label><asp:label id="lblAdv_Bill" runat="server" Width="5%" ForeColor="OrangeRed" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Visible="False">Advance</asp:label>
						<TABLE id="Table4" borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="100%" bgColor="aliceblue"
							border="1">
							<TR align="center">
								<TD style="WIDTH: 23.33%; HEIGHT: 18px" colSpan="2"><asp:label id="Label21" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Consignee</asp:label></TD>
								<TD style="WIDTH: 38.47%; HEIGHT: 18px"><asp:label id="Label42" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Recipient GSTIN No.</asp:label></TD>
								<TD style="WIDTH: 15%; HEIGHT: 18px"><asp:label id="Label47" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">AU Code</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 18px" colSpan="2"><asp:label id="Label22" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Bill Paying Officer</asp:label></TD>
							</TR>
							<TR align="center">
								<TD style="WIDTH: 23.33%; HEIGHT: 119px" colSpan="2"><asp:dropdownlist id="lstConsignee" runat="server" Width="99%" Height="20px" ForeColor="DarkBlue"
										Font-Size="7pt" Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="lstConsignee_SelectedIndexChanged"></asp:dropdownlist><asp:label id="lblConsignee" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label></TD>
								<TD style="WIDTH: 38.47%; HEIGHT: 119px">
									<P><asp:radiobutton id="rdbConsignee" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" AutoPostBack="True" GroupName="g1" Text="Consignee GSTIN" oncheckedchanged="rdbConsignee_CheckedChanged"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="rdbBPO" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" AutoPostBack="True" GroupName="g1" Text="BPO GSTIN" oncheckedchanged="rdbConsignee_CheckedChanged"></asp:radiobutton><asp:textbox id="txtGSTINNo" tabIndex="2" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="15"></asp:textbox><asp:label id="Label49" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Legal Name</asp:label><asp:textbox id="txtLegalName" runat="server" Width="95%" Height="20px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="100"></asp:textbox><asp:button id="btnGSTNoUpdate" tabIndex="3" runat="server" Width="85%" ForeColor="DarkBlue"
											Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Text="Update GSTIN No. &amp; Legal Name" onclick="btnGSTNoUpdate_Click"></asp:button><br>
										<asp:label id="lblCity" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana"></asp:label><asp:label id="lblState" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana"></asp:label><asp:label id="lblPin" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana"></asp:label><asp:label id="lblStateCD" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Visible="False"></asp:label></P>
								</TD>
								<td style="WIDTH: 15%; HEIGHT: 119px"><asp:label id="lblAU" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label></td>
								<TD style="WIDTH: 25%; HEIGHT: 119px" colSpan="2"><asp:label id="lblBPO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:label id="lblBPOCD" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Visible="False"></asp:label><asp:label id="lblBPORail" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Visible="False"></asp:label>
									<asp:label id="lblBPOType" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Visible="False"></asp:label></TD>
							</TR>
							<TR align="center">
								<TD style="WIDTH: 20.89%; HEIGHT: 18px"><asp:label id="Label10" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">IC Type</asp:label></TD>
								<TD style="WIDTH: 13.09%; HEIGHT: 18px" colSpan="2"><asp:label id="Label2" runat="server" Width="40%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Book No.</asp:label><asp:label id="Label3" runat="server" Width="40%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Set No.</asp:label></TD>
								<TD style="WIDTH: 25.63%; HEIGHT: 18px">
									<P><asp:label id="Label5" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Cert No.</asp:label></P>
								</TD>
								<TD style="WIDTH: 7.5%; HEIGHT: 18px"><asp:label id="Label7" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Cert Date (DD/MM/YYYY)</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 18px"><asp:label id="Label11" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Install No</asp:label></TD>
							</TR>
							<TR align="center">
								<TD style="WIDTH: 20.89%; HEIGHT: 16px"><asp:dropdownlist id="lstICType" runat="server" Width="97%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="lstICType_SelectedIndexChanged"></asp:dropdownlist><asp:label id="lblCNote_BNO" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana">Bill No. for which Credit Note is biegn prepared</asp:label><asp:textbox id="txtBillNo" onblur="makeUppercase();" tabIndex="1" runat="server" Width="60%"
										Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10"></asp:textbox><asp:button id="btnVerify" tabIndex="21" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Verify" onclick="btnVerify_Click"></asp:button></TD>
								<TD style="WIDTH: 13.09%; HEIGHT: 16px" colSpan="2"><asp:textbox id="txtBKNO" onblur="makeUppercase();" runat="server" Width="40%" Height="20px"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="4"></asp:textbox><asp:textbox id="txtSetNo" onblur="change();" runat="server" Width="40%" Height="20px" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" MaxLength="3"></asp:textbox></TD>
								<TD style="WIDTH: 25.63%; HEIGHT: 16px"><asp:textbox id="txtCertNo" runat="server" Width="100%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" MaxLength="29"></asp:textbox><asp:label id="lblCertNo" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:label></TD>
								<TD style="WIDTH: 7.5%; HEIGHT: 16px"><asp:textbox id="txtCertDt" onblur="check_date(txtCertDt);compareDates(txtCertDt,txtSysDate,'Certification Date Cannot be Greater then Today Date!!!');datevalidate();"
										runat="server" Width="80%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10"></asp:textbox></TD>
								<TD style="WIDTH: 25%; HEIGHT: 16px"><asp:textbox id="txtCInstallNo" runat="server" Width="35%" Height="22px" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" MaxLength="4"></asp:textbox><asp:dropdownlist id="lstFPart" runat="server" Width="60%" Height="20px"></asp:dropdownlist></TD>
							</TR>
							<TR align="center">
								<TD style="WIDTH: 20.89%; HEIGHT: 1px"><asp:label id="Label19" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">No. of Visits</asp:label></TD>
								<TD style="WIDTH: 15.85%; HEIGHT: 1px"><asp:button id="btnMRDT" tabIndex="-1" runat="server" Width="130px" Height="32px" BorderStyle="None"
										ForeColor="Blue" BackColor="AliceBlue" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" ToolTip="Click here to refresh Call / Material Rediness Date from [Call Registration] Form" onclick="btnMRDT_Click"></asp:button></TD>
								<TD style="WIDTH: 16.26%; HEIGHT: 1px"><asp:label id="Label14" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">First Insp Date(dd/mm/yyyy)</asp:label></TD>
								<TD style="WIDTH: 25.63%; HEIGHT: 1px"><asp:label id="Label15" runat="server" Width="100%" Height="8px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana">Last Insp Date(dd/mm/yyyy)</asp:label></TD>
								<TD style="WIDTH: 10%; HEIGHT: 1px" colSpan="2"><asp:label id="Label20" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Other Insp Dates</asp:label></TD>
							</TR>
							<TR align="center">
								<TD style="WIDTH: 20.89%"><asp:textbox id="txtNofIns" runat="server" Width="40px" Height="20px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana"></asp:textbox></TD>
								<TD style="WIDTH: 15.97%"><asp:textbox id="txtCDate" onblur="check_date(txtCDate);datevalidate();" runat="server" Width="80%"
										Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Enabled="False"></asp:textbox></TD>
								<TD style="WIDTH: 16.26%"><asp:textbox id="txtFIDT" onblur="check_date(txtFIDT);compareDates(txtFIDT,txtSysDate,'First Inspection Date Cannot be Greater then Today Date!!!');datevalidate();"
										runat="server" Width="80%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10"></asp:textbox></TD>
								<TD style="WIDTH: 25.63%"><asp:textbox id="txtLIDT" onblur="check_date(txtLIDT);compareDates(txtLIDT,txtSysDate,'Last Inspection Date Cannot be Greater then Today Date!!!');datevalidate();cpy_firstinspdt();"
										runat="server" Width="78px" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10"></asp:textbox></TD>
								<TD style="WIDTH: 10%" colSpan="2"><asp:textbox id="txtOIDT" runat="server" Width="95%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" MaxLength="100"></asp:textbox></TD>
							</TR>
							<TR align="center">
								<TD style="WIDTH: 16.78%"><asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">IC Submit Date</asp:label></TD>
								<TD style="WIDTH: 54.52%" colSpan="2"><asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Sealing Pattern</asp:label></TD>
								<TD style="WIDTH: 30%" colSpan="2"><asp:label id="Label9" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Reasons for Rejection</asp:label></TD>
								<TD style="WIDTH: 9.24%"><asp:label id="Label6" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Photo Attached</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 16.78%" align="center"><asp:textbox id="txtICSDT" onblur="check_date(txtICSDT);compareDates(txtICSDT,txtSysDate,'IC Submit Date Cannot be Greater then Today Date!!!');datevalidate();"
										runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10"></asp:textbox></TD>
								<TD style="WIDTH: 54.52%" align="center" colSpan="2"><asp:dropdownlist id="lstStampPatternCD" runat="server" Width="99%" Height="20px" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="lstStampPatternCD_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="txtPattern" runat="server" Width="95%" Height="25px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" MaxLength="100" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="WIDTH: 30%" align="center" colSpan="2"><asp:textbox id="txtReason" runat="server" Width="95%" Height="25px" ForeColor="DarkBlue" BackColor="White"
										Font-Size="8pt" Font-Names="Verdana" MaxLength="100" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="WIDTH: 9.24%" align="center"><asp:dropdownlist id="lstPhoto" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana">
										<asp:ListItem Value="N" Selected="True">No</asp:ListItem>
										<asp:ListItem Value="Y">Yes</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%" align="center" colSpan="6"><asp:button id="btnSave" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnCancel" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:button id="btnShow" runat="server" Width="156px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Multi Item Update" ToolTip="Use This Option to Update Qty Passed for All Items in single Go !!!" onclick="btnShow_Click"></asp:button></TD>
							</TR>
							<TR>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="center" colSpan="4"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="center" colSpan="4"><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" ValidationExpression="\d{1,3}" ControlToValidate="txtNofIns" ErrorMessage="Invalid No. Of Visits !!!"></asp:regularexpressionvalidator>&nbsp;
						<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" ValidationExpression="\d{0,7}(.\d{1,5})?" ControlToValidate="txtBPOFee" ErrorMessage="Invalid Fee !!!"></asp:regularexpressionvalidator></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px" align="center" colSpan="4"></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#ffc080" colSpan="4">
						<DIV><TITTLE:CUSTOMDATAGRID id="grdCDetails" tabIndex="20" runat="server" Width="100%" BorderStyle="Groove"
								BackColor="White" Font-Size="8pt" Font-Names="Verdana" PageSize="1" CellPadding="2" OnEditCommand="grdCDetails_Edit"
								OnUpdateCommand="grdCDetails_Update" OnCancelCommand="grdCDetails_Cancel" BorderColor="Navy" AutoGenerateColumns="False"
								FreezeRows="0" GridHeight="200px" FreezeHeader="True" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid"
								UseAccessibleHeader="True" FreezeColumns="0">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="7pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Font-Size="8pt"></EditItemStyle>
								<FooterStyle Wrap="False" CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="7pt" Font-Names="Verdana" HorizontalAlign="Center" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
									ForeColor="DarkBlue" CssClass="GridHeader" VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:EditCommandColumn>
									<asp:BoundColumn DataField="ITEM_SRNO_PO" ReadOnly="True" HeaderText="Item SNo.">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Item Desc">
										<ItemTemplate>
											<asp:Label id=Label35 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ITEM_DESC_PO") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=txtItemDesc runat="server" Width="100%" ForeColor="#0000C0" BackColor="#FFC080" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container, "DataItem.ITEM_DESC_PO") %>' BorderStyle="Inset">
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="UOM_S_DESC" ReadOnly="True" HeaderText="UOM">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QTY_ORDERED" ReadOnly="True" HeaderText="Qty. Ord">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUM_QTY_PREV_OFFERED" ReadOnly="True" HeaderText="Cumm Qty off Prev">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUM_QTY_PREV_PASSED" ReadOnly="True" HeaderText="Qty Prev Passed">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Qty Off Now">
										<ItemTemplate>
											<asp:Label id=Label39 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_TO_INSP") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=txtQOFF runat="server" Width="75px" BorderStyle="Inset" ForeColor="#0000C0" BackColor="#FFC080" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_TO_INSP") %>' MaxLength="13">
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Qty Passed">
										<ItemTemplate>
											<asp:Label id=Label29 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_PASSED") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=txtQPASS runat="server" Width="75px" BorderStyle="Inset" ForeColor="#0000C0" BackColor="#FFC080" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_PASSED") %>' MaxLength="13">
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Qty Rejected">
										<ItemTemplate>
											<asp:Label id=Label30 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_REJECTED") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=txtQREJ runat="server" Width="75px" BorderStyle="Inset" ForeColor="#0000C0" BackColor="#FFC080" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_REJECTED") %>' MaxLength="13">
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Qty Due">
										<ItemTemplate>
											<asp:Label id=Label28 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_DUE") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=txtQDUE runat="server" Width="75px" BorderStyle="Inset" ForeColor="#0000C0" BackColor="#FFC080" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_DUE") %>' MaxLength="13">
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="RATE" ReadOnly="True" HeaderText="Rate"></asp:BoundColumn>
									<asp:BoundColumn DataField="SALES_TAX_PER" ReadOnly="True" HeaderText="Sales Tax(%)"></asp:BoundColumn>
									<asp:BoundColumn DataField="SALES_TAX" ReadOnly="True" HeaderText="Sales Tax"></asp:BoundColumn>
									<asp:BoundColumn DataField="EXCISE_PER" ReadOnly="True" HeaderText="Excise (%)"></asp:BoundColumn>
									<asp:BoundColumn DataField="EXCISE" ReadOnly="True" HeaderText="Excise"></asp:BoundColumn>
									<asp:BoundColumn DataField="DISCOUNT_PER" ReadOnly="True" HeaderText="Discount (%)"></asp:BoundColumn>
									<asp:BoundColumn DataField="DISCOUNT" ReadOnly="True" HeaderText="Discount"></asp:BoundColumn>
									<asp:BoundColumn DataField="OTHER_CHARGES" HeaderText="Other Charges"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
						<DIV><TITTLE:CUSTOMDATAGRID id="grdCDetails_1" tabIndex="20" runat="server" Width="100%" BorderStyle="Groove"
								BackColor="White" Font-Size="8pt" Font-Names="Verdana" Visible="False" PageSize="1" CellPadding="2"
								OnEditCommand="grdCDetails_Edit" OnUpdateCommand="grdCDetails_Update" OnCancelCommand="grdCDetails_Cancel"
								BorderColor="Navy" AutoGenerateColumns="False" FreezeRows="0" GridHeight="200px" FreezeHeader="True"
								BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" FreezeColumns="0">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="7pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Font-Size="8pt"></EditItemStyle>
								<FooterStyle Wrap="False" CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="7pt" Font-Names="Verdana" HorizontalAlign="Center" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
									ForeColor="DarkBlue" CssClass="GridHeader" VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="ITEM_SRNO_PO" ReadOnly="True" HeaderText="Item SNo.">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ITEM_DESC_PO" ReadOnly="True" HeaderText="Item Desc">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UOM_S_DESC" ReadOnly="True" HeaderText="UOM">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QTY_ORDERED" ReadOnly="True" HeaderText="Qty. Ord">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUM_QTY_PREV_OFFERED" ReadOnly="True" HeaderText="Cumm Qty off Prev">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUM_QTY_PREV_PASSED" ReadOnly="True" HeaderText="Qty Prev Passed">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QTY_TO_INSP" ReadOnly="True" HeaderText="Qty Off Now">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Qty Passed">
										<ItemTemplate>
											<asp:TextBox id=txtQTYPASS runat="server" Width="75px" BorderStyle="Inset" ForeColor="#0000C0" BackColor="#FFC080" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_PASSED") %>' MaxLength="13">
											</asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="QTY_REJECTED" ReadOnly="True" HeaderText="Qty Rejected">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QTY_DUE" ReadOnly="True" HeaderText="Qty Due">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RATE" ReadOnly="True" HeaderText="Rate"></asp:BoundColumn>
									<asp:BoundColumn DataField="SALES_TAX_PER" ReadOnly="True" HeaderText="Sales Tax(%)"></asp:BoundColumn>
									<asp:BoundColumn DataField="SALES_TAX" ReadOnly="True" HeaderText="Sales Tax"></asp:BoundColumn>
									<asp:BoundColumn DataField="EXCISE_PER" ReadOnly="True" HeaderText="Excise (%)"></asp:BoundColumn>
									<asp:BoundColumn DataField="EXCISE" ReadOnly="True" HeaderText="Excise"></asp:BoundColumn>
									<asp:BoundColumn DataField="DISCOUNT_PER" HeaderText="Discount (%)"></asp:BoundColumn>
									<asp:BoundColumn DataField="DISCOUNT" HeaderText="Discount"></asp:BoundColumn>
									<asp:BoundColumn DataField="OTHER_CHARGES" HeaderText="Other Charges"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
						<asp:button id="btnSave2" tabIndex="25" runat="server" Width="101px" Height="20px" ForeColor="DarkBlue"
							Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Visible="False" Text="Save Quantity" onclick="btnSave2_Click"></asp:button><asp:button id="btnCancel2" tabIndex="26" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel2_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">
						<TABLE id="Table3" borderColor="#b0c4de" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffcc"
							border="1">
							<TR>
								<TD style="HEIGHT: 29px" align="right" bgColor="white" colSpan="6"><asp:label id="Label37" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="10pt"
										Font-Names="Verdana"> BILL GENERATION &nbsp&nbsp<font color="#ff0066" size="1">(Don't 
											use this option for Mulitiple IC - One Bill generation)</font></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 21px" align="center"><asp:label id="Label36" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> Bill Date</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 21px" align="center" colSpan="2"><asp:label id="Label33" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> Min Fee Payble (if any)</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 21px" align="center" colSpan="3"><asp:label id="Label31" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> Max Fee Allowed (if any)</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 21px" align="center">
									<P><asp:textbox id="txtBDT" onblur="check_date(txtBDT);compareDates(txtCertDt,txtBDT,'Bill Date Date Cannot Be Earlier Than Certification Date')"
											style="TEXT-ALIGN: center" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="11"></asp:textbox><asp:button id="btnUBDT" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Text="Update Bill Date" onclick="btnUBDT_Click"></asp:button></P>
								</TD>
								<TD style="WIDTH: 20%; HEIGHT: 21px" align="center" colSpan="2"><asp:textbox id="txtMinFeeAllow" style="TEXT-ALIGN: right" runat="server" Width="50%" Height="20px"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="11"></asp:textbox></TD>
								<TD style="WIDTH: 20%; HEIGHT: 21px" align="center" colSpan="3"><asp:textbox id="txtMaxFeeAllow" style="TEXT-ALIGN: right" runat="server" Width="50%" Height="20px"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="11"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 15px" align="center"><asp:label id="Label27" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> FEE</asp:label></TD>
								<TD style="WIDTH: 15.77%; HEIGHT: 15px" align="center" colSpan="2"><asp:label id="Label26" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> FEE Type</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 15px" align="center" colSpan="3"><asp:label id="Label25" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> TAX Type</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 54px" align="center"><asp:textbox id="txtBPOFee" style="TEXT-ALIGN: right" runat="server" Width="40%" Height="20px"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="13"></asp:textbox>
									<asp:dropdownlist id="lstRlyBPOFee" runat="server" Height="25px" Width="90%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue"></asp:dropdownlist></TD>
								<TD style="WIDTH: 15.77%; HEIGHT: 54px" align="center" colSpan="2"><asp:dropdownlist id="lstBPOFeeType" runat="server" Width="80%" Height="25px" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" onchange="minmaxfeeenableordisable();" onload="lstBPOFeeType_SelectedIndexChanged" onselectedindexchanged="lstBPOFeeType_SelectedIndexChanged"></asp:dropdownlist></TD>
								<TD style="WIDTH: 20.1%; HEIGHT: 54px" align="center" colSpan="3">
									<P><asp:dropdownlist id="lstBPOTaxType" runat="server" Width="90%" Height="25px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana"></asp:dropdownlist></P>
									<P><asp:dropdownlist id="lstBPOTaxType_GST" runat="server" Width="90%" Height="25px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana"></asp:dropdownlist></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 59px" align="left" colSpan="5"><asp:label id="Label38" runat="server" Width="72px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">&nbspBPO.</asp:label><asp:textbox id="txtBPO" style="TEXT-ALIGN: center" runat="server" Width="72px" Height="20px"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="5"></asp:textbox><asp:button id="btnFC_List" runat="server" Width="96px" Height="20px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Select BPO" onclick="btnFC_List_Click"></asp:button><asp:label id="Label51" runat="server" Width="40%" ForeColor="DarkMagenta" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"> Only For Display in Invoice</asp:label><asp:dropdownlist id="lstBPO" runat="server" Width="100%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Visible="False" AutoPostBack="True" onselectedindexchanged="lstBPO_SelectedIndexChanged"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 59px" align="center"><asp:checkbox id="chkABill" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="Advance Bill"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: purple; FONT-FAMILY: Verdana; HEIGHT: 36px"
									align="center"><asp:label id="Label40" runat="server" Width="149px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana">Remarks (if any)</asp:label></TD>
								<TD style="HEIGHT: 36px" align="center" colSpan="4" height="36"><asp:textbox id="txtBRemarks" runat="server" Width="96%" Height="30px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" MaxLength="300" TextMode="MultiLine"></asp:textbox></TD>
								<td align="right"><asp:label id="Label44" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Cancellation OR Rejection Fee Bills</asp:label>&nbsp;&nbsp;
									<asp:dropdownlist id="ddlCanOrRejctionFee" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">
										<asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
										<asp:ListItem Value="Y">YES</asp:ListItem>
									</asp:dropdownlist></td>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: purple; FONT-FAMILY: Verdana"
									align="center" colSpan="4">* Enter Fee Details Before Generating Bill !!!
								</TD>
								<TD align="center" colSpan="2" height="30"><asp:button id="btnGBill" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="Generate Bill" ToolTip="Please Save the Inspection Certificate and Edit Items Qty Passed, Rejected and Due before Generating the Bill!!!" onclick="btnGBill_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: purple; FONT-FAMILY: Verdana"
									align="center" colSpan="6">
									<P><asp:label id="Label48" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Visible="False"> Upload a scanned copy of Invoice Supporting Documents in "PDF" format from here. Scanned copy should be in Black & White and Low DPI.
							</asp:label></P>
									<P><INPUT id="File1" style="FONT-SIZE: 8pt; WIDTH: 424px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 22px"
											tabIndex="23" type="file" size="51" name="File1" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="btnUpload" runat="server" Width="220px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Visible="False" Text="Upload Invoice Supporting Docs" onclick="btnUpload_Click"></asp:button></P>
									<P>&nbsp;</P>
								</TD>
							</TR>
						</TABLE>
						<asp:label id="lblBDT" runat="server" Width="1px" Height="1px" ForeColor="White" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" DESIGNTIMEDRAGDROP="719"> Bill Date</asp:label>
						<asp:label id="Label52" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"> * Enter Remarks (If Any) before clicking "Return Bills to Railways" button, these Remarks will be saved in IBS & sent to Railways in Returned Bill.</asp:label><asp:button id="btnReturnBill" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Text="Return Bills to Railways" ToolTip="Please Click on this Button in Case Bill is already Returned by Railways and it is corrected not and ready to be resent to Railways." onclick="btnReturnBill_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
