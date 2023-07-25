<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendor_Call_Register_Form.aspx.cs" Inherits="RBS.Vendor.Vendor_Call_Register_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl_Vend" Src="WebUserControl_Vend.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Call Register Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="../date.js"></script>
		<script language="javascript">
		
		function cool(url)
		{
		alert(url);
		document.Form1.action=url;
		} 


		
		function validate()
		{
		//if(document.Form1.txtCaseNo.value=="")
		//{
		// alert("CASE NO. CANNOT BE LEFT BLANK");
		// event.returnValue=false;
		//}
		//else if(document.Form1.txtDtOfReciept.value=="")
		//{
		// alert("DATE OF RECIEPT IN RITES CANNOT BE LEFT BLANK");
		// event.returnValue=false;
		//}
		//else if(document.Form1.CALL_LETTER_DT.value=="")
		//{
		// alert("CALL LETTER DATE CANNOT BE LEFT BLANK");
		// event.returnValue=false;
		//}
		//else if(document.Form1.CALL_MARK_DT.value=="")
		//{
		// alert("CALL MARK DATE CANNOT BE LEFT BLANK");
		// event.returnValue=false;
		//}
		//else if(document.Form1.DT_INSP_DESIRE.value=="")
		//{
		 //alert("EXPECTED DATE OF INSPECTION CANNOT BE LEFT BLANK");
		// event.returnValue=false;
		//}
		//else
	//	{
	//	alert("YOUR RECORD IS SAVED")
		//}
		// return;
		//if(trimAll(document.Form1.txtGSTINNo.value)=="")
		//{
		// alert("RECIPIENT GSTIN NO. CANNOT BE LEFT BLANK!!!");
		// event.returnValue=false;
		//}
		if(trimAll(document.Form1.txtGSTINNo.value)!="" && document.Form1.txtGSTINNo.value.length != 15)
		 {
		 alert("PLZ ENTER 15 CHARACTERS LONG GSTIN NO. ONLY!!!");
		 event.returnValue=false;
		 }
		else if(document.Form1.txtCInstallNo.value!="" && IsNumeric(document.Form1.txtCInstallNo.value) == false)
		{
		 alert("CALL INSTALL NO. CONTAINS INVALID CHARACTERS!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtExpOfIns.value)=="")
		 {
		 document.Form1.txtExpOfIns.value=document.Form1.txtDtOfReciept.value;
		 alert("Expected Date Of Inspection/Material Readiness Date Cannot Be Left Blank, so it is Replaced By Call Date!!!");
		 event.returnValue=true;
		 }
		 else
		 {
		 
		 //document.Form1.btnSave.disabled=true;
		 //document.getElementById("btnSave").disabled = true;
		 document.Form1.btnSave.style.visibility = 'hidden';
		 return;
		 
		 }
		}
		 function validate1()
		{
		 if(trimAll(document.Form1.txtMName.value)=="")
		{
		 alert("ENTER MANUFACTURER CODE OR 1ST FEW CHARACTERS OF MANUFACTURER NAME AND THEN CLICK ON SELECT VENDOR BUTTON");
		 event.returnValue=false;
		 }
		  else
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
		
		function abc()
		{
		document.Form1.txtDtOfCan.value=document.Form1.txtDtMark.value;	
		document.Form1.txtDtOfCan.select();
				
		}
		
		function sFocus()
		 {
		 
		 document.Form1.txtCInstallNo.focus();
		 
		}
		function insp_date()
		{

		if(compareDates(document.Form1.txtDtOfReciept,document.Form1.txtExpOfIns,'Expected Date Of Inspection Cannot Be Earlier Than CALL Date, So it is Replaced By Call Date!!!')==false)
		{
			document.Form1.txtExpOfIns.value=document.Form1.txtDtOfReciept.value;
		}
		
		}
		
		function call_mark_dt()
		{
			document.Form1.txtDtMark.value=document.Form1.txtExpOfIns.value;
		}
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload=" sFocus();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 356px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 24px">
						<P align="center"><uc1:webusercontrol_vend id="WebUserControl_Vend1" runat="server"></uc1:webusercontrol_vend></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px">
						<P align="center"><asp:label id="Label1" runat="server" ForeColor="DarkBlue" Font-Bold="True" BackColor="White"
								Font-Size="10pt" Font-Names="Verdana" Width="252px">VENDOR CALL REGISTRATION</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 203px" align="center">
						<TABLE id="Table2" style="HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="1" cellPadding="1"
							width="100%" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 35px" width="181"><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%"> Case No.</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 35px" width="173"><asp:textbox id="txtCaseNo" tabIndex="41" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="150px" MaxLength="9" Height="25px"></asp:textbox><asp:label id="Label27" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="192px"></asp:label></TD>
								<TD style="HEIGHT: 35px" align="left" width="20%"><asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%"> Call Date</asp:label></TD>
								<TD style="HEIGHT: 35px" align="left" width="30%"><asp:label id="Label28" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="64px" Height="16px"></asp:label><asp:textbox id="txtDtOfReciept" tabIndex="20" runat="server" ForeColor="AliceBlue" BackColor="AliceBlue"
										Font-Size="8pt" Font-Names="Verdana" Width="1px" MaxLength="10" BorderStyle="None"></asp:textbox><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="64px">Call SNo.</asp:label><asp:label id="Label29" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="32px">sno</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 23px" width="181"><asp:label id="Label14" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Purchaser</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 23px" width="173"><asp:label id="Label19" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="192px"></asp:label></TD>
								<TD style="HEIGHT: 23px" align="left" width="20%"><asp:label id="Label16" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Vendor</asp:label></TD>
								<TD style="HEIGHT: 23px" align="left" width="30%"><asp:label id="Label21" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="184px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 20px" width="181"><asp:label id="Label15" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Purchase Order Date</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 20px" width="173"><asp:label id="Label22" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="184px"></asp:label></TD>
								<TD style="HEIGHT: 20px" align="left" width="20%"><asp:label id="Label17" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Purchase Order No.</asp:label></TD>
								<TD style="HEIGHT: 20px" align="left" width="30%"><asp:label id="Label25" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="184px"></asp:label><asp:label id="lblL5noPo" runat="server" Visible="False"></asp:label><asp:label id="lblRly" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 22px" width="181"><asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="88px">Call Status</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 22px" width="173"><asp:label id="txtCallStatus" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="90%"></asp:label></TD>
								<TD style="HEIGHT: 22px" align="left" width="20%"><asp:label id="Label13" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Region</asp:label></TD>
								<TD style="HEIGHT: 22px" align="left" width="30%"><asp:label id="Label31" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="69px"></asp:label><asp:label id="lblRLY_NONRly" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 20px" width="181"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%"> Date of Mark of call to IE</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 20px" width="173"><asp:textbox id="txtDtMark" onblur="check_date(txtDtMark);compareDates(txtDtOfReciept,txtDtMark,'Call Mark Date Cannot Be Less then Call Date');abc();"
										tabIndex="43" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="80px" MaxLength="10" Height="20px"></asp:textbox></TD>
								<TD style="HEIGHT: 20px" align="left" width="20%"><asp:label id="Label23" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%"> Call Status date</asp:label></TD>
								<TD style="HEIGHT: 20px" align="left" width="30%"><asp:textbox id="txtDtOfCan" onblur="check_date(txtDtOfCan);compareDates(txtDtOfReciept,txtDtOfCan,'Call Status Date Cannot Be Less then Call Date');"
										tabIndex="42" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="80px" MaxLength="10" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 35px" width="181"><asp:label id="Label12" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="104px">Call Install No.</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 35px" width="173"><asp:textbox id="txtCInstallNo" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="30%" MaxLength="4" Height="25px"></asp:textbox></TD>
								<TD id="TD1" style="HEIGHT: 35px" align="left" width="20%" runat="server"><asp:label id="Label9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%"> Expected Date of Inspection/Material Readiness Date.</asp:label></TD>
								<TD style="HEIGHT: 35px" align="left" width="30%"><asp:textbox id="txtExpOfIns" onblur="check_date(txtExpOfIns);insp_date();" tabIndex="2" runat="server"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="80px" MaxLength="10" Height="20px" onchange=""></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label18" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Call Letter Number\ Dispatch Reference No.</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 24px" width="173"><asp:textbox id="txtCallNO" tabIndex="3" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="100%" MaxLength="30" Height="20px"></asp:textbox><asp:label id="Label37" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="90%">(30 Chars Maximum)</asp:label></TD>
								<TD style="HEIGHT: 24px" align="left" width="20%"><asp:label id="Label4" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Call Letter Date (DD/MM/YYYY)</asp:label></TD>
								<TD style="HEIGHT: 24px" align="left" width="30%"><asp:textbox id="txtCallDt" onblur="check_date(txtCallDt);compareDates(txtCallDt,txtDtOfReciept,'Call Letter Date Cannot Be Greater then Date Of Reciept In Rites');"
										tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="80px" MaxLength="10" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 21px" width="181"><asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%" Visible="False">Inspecting Engineer to whom Call is marked</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 21px" width="173"><asp:dropdownlist id="lstIE" tabIndex="6" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Width="150px" Height="25px" Visible="False"></asp:dropdownlist><asp:label id="lblIE" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%" Visible="False"></asp:label></TD>
								<TD style="HEIGHT: 21px" align="left" width="20%"><asp:label id="Label30" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%" Visible="False">Call Re-Mark Status(If Call has been Re-marked)</asp:label></TD>
								<TD style="HEIGHT: 21px" align="left" width="30%"><asp:dropdownlist id="lstCallRStatus" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="150px" Height="25px" Visible="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label32" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="64px">Remarks</asp:label><asp:label id="Label49" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana">(250 Chars Maxm)</asp:label></TD>
								<TD style="HEIGHT: 24px" width="30%" colSpan="3"><asp:textbox id="txtRemarks" tabIndex="7" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="90%" MaxLength="250" Height="20px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<tr>
								<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label50" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%" Height="14px">Item to be inspected viz. Mechanical, Electrical, Civil etc</asp:label></TD>
								<TD style="HEIGHT: 24px" width="30%" colSpan="3"><asp:dropdownlist id="Dropdownlist1" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="150px" Height="25px"></asp:dropdownlist>&nbsp;&nbsp;Item<asp:label id="lblClusterIE_CD" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="OrangeRed" Visible="False"></asp:label></TD>
							</tr>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label51" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">State whether the Call is for Final Or Stage Inspection</asp:label></TD>
								<TD style="HEIGHT: 24px" width="30%" colSpan="3"><asp:radiobutton id="rdbFinal" tabIndex="10" runat="server" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Width="80px" Text="Final" GroupName="g4" Checked="True" AutoPostBack="True" Enabled="False"></asp:radiobutton><asp:radiobutton id="rdbStage" tabIndex="11" runat="server" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Width="56px" Text="Stage" GroupName="g4" AutoPostBack="True" Enabled="False"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="Label52" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="336px">* Select Stage in case of Stage Inspection Call.</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label39" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">State whether the items is on RDSO Vendor Directory</asp:label></TD>
								<TD style="HEIGHT: 24px" width="30%" colSpan="3"><asp:radiobutton id="rdbIYes" tabIndex="10" runat="server" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Width="80px" Text="Yes" GroupName="g1" Checked="True" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="rdbINo" tabIndex="11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="56px" Text="No" GroupName="g1" AutoPostBack="True"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label40" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">If Yes, whether the vendor is RDSO Aprroved. Indicate validity of approval</asp:label></TD>
								<TD style="HEIGHT: 24px" width="30%" colSpan="3"><asp:radiobutton id="rdbVYes" tabIndex="10" runat="server" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Width="80px" Text="Yes" GroupName="g2" Checked="True" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="rdbVNo" tabIndex="11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="56px" Text="No" GroupName="g2" AutoPostBack="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="Label42" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="56px"> From</asp:label><asp:textbox id="txtVendAppFrom" onblur="check_date(txtVendAppFrom);" tabIndex="9" runat="server"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="120px" MaxLength="10" Height="20px"></asp:textbox><asp:label id="Label41" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="58px"> To</asp:label><asp:textbox id="txtVendAppTo" onblur="check_date(txtVendAppTo);compareDates(txtVendAppFrom,txtVendAppTo,'Vendor Approval To Date Cannot Be Less Vendor Approval From Date');"
										tabIndex="10" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="120px" MaxLength="10" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 22px" width="181"><asp:label id="Label43" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Does PO specified staggered DP</asp:label></TD>
								<TD style="HEIGHT: 22px" width="30%" colSpan="3"><asp:radiobutton id="rdbSYes" tabIndex="10" runat="server" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Width="80px" Text="Yes" GroupName="g3" Checked="True" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="rdbSNo" tabIndex="11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="56px" Text="No" GroupName="g3" AutoPostBack="True"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 22px" width="181"><asp:label id="Label44" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">If yes, details of lot size and staggered DP</asp:label></TD>
								<TD style="HEIGHT: 22px" width="30%" colSpan="3">
									<P><asp:label id="Label45" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="104px">1. Lot Size & DP</asp:label><asp:textbox id="txtLotDP1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="243px" MaxLength="50" Height="20px"></asp:textbox></P>
									<P><asp:label id="Label46" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="104px">2. Lot Size & DP</asp:label><asp:textbox id="txtLotDP2" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="243px" MaxLength="50" Height="20px"></asp:textbox></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label26" runat="server" ForeColor="RoyalBlue" Font-Bold="True" Font-Size="10pt"
										Font-Names="Verdana" Width="200px" Font-Underline="True">Manufacturer's Information</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 24px" width="173"><asp:checkbox id="chkManuf" tabIndex="8" runat="server" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Same As Vendor" AutoPostBack="True"></asp:checkbox></TD>
								<TD style="HEIGHT: 24px" align="left" width="20%"></TD>
								<TD style="HEIGHT: 24px" align="right" width="30%"><asp:label id="lblCUpdateStatus" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="184px" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 45px" width="181"><asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Name of Manufacturer/Name Of Firm (In case place of inspection is other than place of manufacturer)</asp:label></TD>
								<TD style="HEIGHT: 45px" width="30%" colSpan="3"><asp:textbox id="txtMName" tabIndex="12" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="20%" MaxLength="50" Height="20px"></asp:textbox><asp:button id="btnFCList" tabIndex="13" runat="server" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Width="30%" Height="19px" Text="Select Manufacturer" ToolTip="Enter the Manufacturer Code or 1st few letters of Manufacturer Name then click on select Vendor Button"></asp:button><asp:label id="Label47" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">* To Search Enter First Few Characters Of Name and Click on Select Manufacturer Button, then select the from the list given below.</asp:label><asp:dropdownlist onkeypress="return keySort(ddlManufac);" id="ddlManufac" tabIndex="14" runat="server"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="90%" Height="25px" Visible="False" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 41px" width="181"><asp:label id="Label24" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="144px">Place of Inspection</asp:label></TD>
								<TD style="HEIGHT: 41px" width="30%" colSpan="3"><asp:textbox id="txtMPOI" tabIndex="15" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Width="90%" MaxLength="30" Height="40px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px; HEIGHT: 25px" width="181"><asp:label id="Label11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="152px">Contact  Person's Name</asp:label></TD>
								<TD style="WIDTH: 173px; HEIGHT: 25px" width="173"><asp:textbox id="txtMConPer" tabIndex="16" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="100%" MaxLength="30" Height="20px"></asp:textbox></TD>
								<TD style="HEIGHT: 25px" width="20%"><asp:label id="Label33" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Manufacturer Email</asp:label></TD>
								<TD style="HEIGHT: 25px" align="left" width="30%"><asp:textbox id="txtMEmail" tabIndex="17" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="100%" MaxLength="50" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 181px" width="181"><asp:label id="label20" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="72px">Phone No.</asp:label></TD>
								<TD style="WIDTH: 173px" width="173"><asp:textbox id="txtMPNo" tabIndex="18" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Width="100%" MaxLength="30" Height="20px"></asp:textbox></TD>
								<TD width="30%" colSpan="2"><asp:button id="btnUManuf" tabIndex="22" runat="server" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Width="100%" Height="22px" Text="Update Manufacturer's Contact Details." ToolTip="If you want to Change Manufacturer's Contact Person and Tel No. then Change The Values and Click on button"></asp:button></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblIRFC" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">     <font color="red"> In case of IRFC Funded Project, Select 'Yes'</font.</asp:label></TD>
								<TD colSpan="3"><asp:dropdownlist id="ddlIRFC" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Width="56px" Height="25px">
										<asp:ListItem Selected="True"></asp:ListItem>
										<asp:ListItem Value="Y">Yes</asp:ListItem>
										<asp:ListItem Value="N">No</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label35" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Bill Paying Officer & Address <font color="red"> (Mention the Name of the party in whose favour invoice is to be raised and it's Address.)</font.</asp:label></TD>
								<TD colSpan="3"><asp:textbox id="txtBPO" tabIndex="23" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Width="95%" MaxLength="300"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label53" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">GSTIN No. <font color="red">(Mention the GST NO. 
											of the party in whose favour invoice is to be raised.)</font></asp:label></TD>
								<TD colSpan="3"><asp:textbox id="txtGSTINNo" tabIndex="24" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="30%" MaxLength="15" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4"><asp:checkbox id="chkNewVendor" tabIndex="25" runat="server" ForeColor="Crimson" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Kindly Check this option, If You are a New Vendor!!!"></asp:checkbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
				</TR>
				<TR>
					<TD style="HEIGHT: 203px" align="center">
						<DIV><TITTLE:CUSTOMDATAGRID id="grdCDetails_1" tabIndex="20" runat="server" BackColor="White" Font-Size="8pt"
								Font-Names="Verdana" Width="100%" BorderStyle="Groove" PageSize="1" CellPadding="2" BorderColor="Navy"
								AutoGenerateColumns="False" FreezeRows="0" GridHeight="200px" FreezeHeader="True" BorderWidth="1px"
								AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" FreezeColumns="0">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="7pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Font-Size="8pt"></EditItemStyle>
								<FooterStyle Wrap="False" CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="7pt" Font-Names="Verdana" HorizontalAlign="Center" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
									ForeColor="DarkBlue" CssClass="GridHeader" VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="ITEM_SRNO_PO" ReadOnly="True" HeaderText="Item SNo."></asp:BoundColumn>
									<asp:BoundColumn DataField="ITEM_DESC_PO" ReadOnly="True" HeaderText="Item Desc">
										<HeaderStyle Width="40%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONSIGNEE" ReadOnly="True" HeaderText="Consignee"></asp:BoundColumn>
									<asp:BoundColumn DataField="QTY_ORDERED" ReadOnly="True" HeaderText="Qty. Ord">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUM_QTY_PREV_OFFERED" ReadOnly="True" HeaderText="Cumm Qty off Prev">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUM_QTY_PREV_PASSED" ReadOnly="True" HeaderText="Qty Prev Passed">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Qty Offered Now">
										<ItemTemplate>
											<asp:TextBox id="txtQTYOFFNOW_1" runat="server" BackColor="#FFC080" ForeColor="#0000C0" Width="75px" MaxLength="12" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_TO_INSP") %>' BorderStyle="Inset">
											</asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="QTY_PASSED" ReadOnly="True" HeaderText="Qty Passed">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QTY_REJECTED" ReadOnly="True" HeaderText="Qty Rejected">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QTY_DUE" ReadOnly="True" HeaderText="Qty Due">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DELV_DATE" HeaderText="Delivery Date"></asp:BoundColumn>
									<asp:BoundColumn DataField="BPO" HeaderText="Bill Paying Officer"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
						<DIV><TITTLE:CUSTOMDATAGRID id="grdCDetails" tabIndex="20" runat="server" BackColor="White" Font-Size="8pt"
								Font-Names="Verdana" Width="100%" BorderStyle="Groove" PageSize="1" CellPadding="2" BorderColor="Navy"
								AutoGenerateColumns="False" FreezeRows="0" GridHeight="200px" FreezeHeader="True" BorderWidth="1px"
								AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" FreezeColumns="0" OnEditCommand="grdCDetails_Edit"
								OnUpdateCommand="grdCDetails_Update" OnCancelCommand="grdCDetails_Cancel">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="7pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Font-Size="8pt"></EditItemStyle>
								<FooterStyle Wrap="False" CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="7pt" Font-Names="Verdana" HorizontalAlign="Center" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
									ForeColor="DarkBlue" CssClass="GridHeader" VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="UnMark" CommandName="Delete"></asp:ButtonColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:EditCommandColumn>
									<asp:BoundColumn DataField="ITEM_SRNO_PO" ReadOnly="True" HeaderText="Item SNo."></asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS" ReadOnly="True" HeaderText="Status">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ITEM_DESC_PO" ReadOnly="True" HeaderText="Item Desc">
										<HeaderStyle Width="40%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONSIGNEE" ReadOnly="True" HeaderText="Consignee"></asp:BoundColumn>
									<asp:BoundColumn DataField="QTY_ORDERED" ReadOnly="True" HeaderText="Qty. Ord">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUM_QTY_PREV_OFFERED" ReadOnly="True" HeaderText="Cumm Qty off Prev">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUM_QTY_PREV_PASSED" ReadOnly="True" HeaderText="Qty Prev Passed">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Qty Offered Now">
										<ItemTemplate>
											<asp:Label id=Label34 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_TO_INSP") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=txtQTYOFFNOW runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QTY_TO_INSP") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="QTY_PASSED" ReadOnly="True" HeaderText="Qty Passed">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QTY_REJECTED" ReadOnly="True" HeaderText="Qty Rejected">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QTY_DUE" ReadOnly="True" HeaderText="Qty Due">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DELV_DATE" HeaderText="Delivery Date"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%" align="center"><asp:label id="Label36" runat="server" ForeColor="Red" Font-Size="8pt" Font-Names="Verdana"
							Width="100%">* Click on Register Call Button Once only</asp:label><asp:label id="Label38" runat="server" ForeColor="Red" Font-Size="8pt" Font-Names="Verdana"
							Width="100%">* Enter the Quantity Offered Now of All the Items Which You want to be Inspected in this call.</asp:label></TD>
					<TD align="center"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%" align="center"><asp:checkbox id="CheckBox1" tabIndex="25" runat="server" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text='I hereby accept all the <a href="\RBS\TermsandConditions.aspx"> Terms and Conditions</a>.'></asp:checkbox>
						<br>
					</TD>
					<TD align="center"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 20px" align="center">&nbsp;&nbsp;
						<asp:button id="btnSave" tabIndex="26" runat="server" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Width="163px" Text="Register Call" DESIGNTIMEDRAGDROP="976"></asp:button>&nbsp;&nbsp;<asp:button id="btnDelete" tabIndex="20" runat="server" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Width="67px" Text="Delete" Enabled="False"></asp:button>&nbsp;&nbsp;
						<asp:button id="btnPrint" tabIndex="27" runat="server" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Width="127px" Visible="False" Text="Print Call Letter"></asp:button>&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 20px" align="center"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 106px" align="center"><asp:label id="Label48" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="100%" Visible="False"> Note: Scanned copy of order given by prime contractor to vendor (In case of Contract/LOA Calls)/ Other relevant Document (If any in "PDF" Format only). Scanned copy should be in Black & White and Low DPI.</asp:label>
						<P></P>
						<INPUT id="File1" style="FONT-SIZE: 8pt; WIDTH: 424px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 22px; Visible: false"
							tabIndex="28" type="file" size="51" name="File1" runat="server">
						<asp:Label id="lblCluster_Cd" runat="server" Visible="False">Label</asp:Label>
						<P><asp:button id="btnUpload" tabIndex="29" runat="server" ForeColor="DarkBlue" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Width="142px" Visible="False" Text="Upload Documents"></asp:button><asp:button id="btnCancel" tabIndex="30" runat="server" ForeColor="DarkBlue" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Width="67px" Text="Cancel"></asp:button></P>
					</TD>
					<TD style="HEIGHT: 106px" align="center"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%" align="left"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
