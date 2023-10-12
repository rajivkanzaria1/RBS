<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Register_Form.aspx.cs" Inherits="RBS.Call_Register_Form.Call_Register_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Call Register Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
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
		if(document.Form1.txtCInstallNo.value!="" && IsNumeric(document.Form1.txtCInstallNo.value) == false)
		{
		 alert("CALL INSTALL NO. CONTAINS INVALID CHARACTERS!!!");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtRemarks.value.length > 250)
		 {
		 alert("PLZ ENTER REMARKS WITHIN 250 CHARACTERS ONLY!!!");
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
		 return;
		 document.Form1.btnSave.style.visibility = 'hidden';
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
		 if(document.Form1.txtBPOCD=="[object]")
		 {
		 document.Form1.txtBPOCD.focus();
		 }
		 {
		 document.Form1.txtDtMark.focus();
		 }
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
	<body bgColor="#ffffff" onload=" sFocus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 356px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px">
						<P align="center"><asp:label id="Label1" runat="server" Width="204px" Font-Names="Verdana" Font-Size="10pt" BackColor="White"
								Font-Bold="True" ForeColor="DarkBlue">CALL REGISTRATION</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%" align="left">
						<TABLE id="Table3" style="HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="100%" bgColor="#ffffff"
							border="0">
							<TR>
								<TD style="HEIGHT: 203px" align="center">
									<TABLE id="Table2" style="HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="1" cellPadding="1"
										width="100%" bgColor="#f0f8ff" border="1">
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 35px" width="181"><asp:label id="Label6" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Case No</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 35px" width="173"><asp:textbox id="txtCaseNo" tabIndex="21" runat="server" Width="150px" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="25px" MaxLength="9"></asp:textbox><asp:label id="Label27" runat="server" Width="192px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed"></asp:label></TD>
											<TD style="HEIGHT: 35px" align="left" width="20%"><asp:label id="Label3" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue"> Call Date</asp:label></TD>
											<TD style="HEIGHT: 35px" align="left" width="30%"><asp:label id="Label28" runat="server" Width="64px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Height="16px"></asp:label><asp:textbox id="txtDtOfReciept" tabIndex="20" runat="server" Width="1px" Font-Names="Verdana"
													Font-Size="8pt" BackColor="AliceBlue" ForeColor="AliceBlue" MaxLength="10" BorderStyle="None"></asp:textbox><asp:label id="Label5" runat="server" Width="64px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Call SNo.</asp:label><asp:label id="Label29" runat="server" Width="32px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed">sno</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 23px" width="181"><asp:label id="Label14" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Purchaser</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 23px" width="173"><asp:label id="Label19" runat="server" Width="192px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed"></asp:label></TD>
											<TD style="HEIGHT: 23px" align="left" width="20%"><asp:label id="Label16" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Vendor</asp:label></TD>
											<TD style="HEIGHT: 23px" align="left" width="30%"><asp:label id="Label21" runat="server" Width="184px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 20px" width="181"><asp:label id="Label15" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Purchase Order Date</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 20px" width="173"><asp:label id="Label22" runat="server" Width="184px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed"></asp:label></TD>
											<TD style="HEIGHT: 20px" align="left" width="20%"><asp:label id="Label17" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Purchase Order No.</asp:label></TD>
											<TD style="HEIGHT: 20px" align="left" width="30%"><asp:label id="Label25" runat="server" Width="184px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed"></asp:label><asp:label id="lblL5noPo" runat="server" Visible="False"></asp:label><asp:label id="lblRly" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 22px" width="181"><asp:label id="Label8" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Call Status</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 22px" width="173"><asp:label id="txtCallStatus" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="OrangeRed"></asp:label></TD>
											<TD style="HEIGHT: 22px" align="left" width="20%"><asp:label id="Label13" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Region</asp:label></TD>
											<TD style="HEIGHT: 22px" align="left" width="30%"><asp:label id="Label31" runat="server" Width="69px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed"></asp:label><asp:label id="lblRLYNONRLY" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 20px" width="181"><asp:label id="Label2" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue"> Date of Mark of call to IE</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 20px" width="173"><asp:textbox id="txtDtMark" onblur="check_date(txtDtMark);compareDates(txtDtOfReciept,txtDtMark,'Call Mark Date Cannot Be Less then Call Date');abc();"
													tabIndex="3" runat="server" Width="80px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="10"></asp:textbox></TD>
											<TD style="HEIGHT: 20px" align="left" width="20%"><asp:label id="Label23" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue"> Call Status date</asp:label></TD>
											<TD style="HEIGHT: 20px" align="left" width="30%"><asp:textbox id="txtDtOfCan" onblur="check_date(txtDtOfCan);compareDates(txtDtOfReciept,txtDtOfCan,'Call Status Date Cannot Be Less then Call Date');"
													tabIndex="4" runat="server" Width="80px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 35px" width="181"><asp:label id="Label7" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Inspecting Engineer to whom Call is marked</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 35px" width="173"><asp:dropdownlist id="lstIE" tabIndex="5" runat="server" Width="250px" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="25px"></asp:dropdownlist><asp:label id="lblEIE" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Visible="False"></asp:label><asp:label id="lblIE" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Visible="False"></asp:label>
												<asp:label id="lblIE_CD" runat="server" Width="256px" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="OrangeRed" Height="14px" Visible="False"></asp:label></TD>
											<TD id="TD1" style="HEIGHT: 35px" align="left" width="20%" runat="server"><asp:label id="Label9" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue"> Expected Date of Inspection/Material Readiness Date.</asp:label></TD>
											<TD style="HEIGHT: 35px" align="left" width="30%"><asp:textbox id="txtExpOfIns" onblur="check_date(txtExpOfIns);insp_date();" tabIndex="6" runat="server"
													Width="80px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="10" onchange=""></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label18" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Call Letter Number\ Dispatch Reference No.</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 24px" width="173"><asp:textbox id="txtCallNO" tabIndex="7" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="30"></asp:textbox><asp:label id="Label37" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed">(30 Chars Maximum)</asp:label></TD>
											<TD style="HEIGHT: 24px" align="left" width="20%"><asp:label id="Label4" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Call Letter Date (DD/MM/YYYY)</asp:label></TD>
											<TD style="HEIGHT: 24px" align="left" width="30%"><asp:textbox id="txtCallDt" onblur="check_date(txtCallDt);compareDates(txtCallDt,txtDtOfReciept,'Call Letter Date Cannot Be Greater then Date Of Reciept In Rites');"
													tabIndex="8" runat="server" Width="80px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 21px" width="181"><asp:label id="Label30" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Call Re-Mark Status(If Call has been Re-marked)</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 21px" width="173"><asp:dropdownlist id="lstCallRStatus" tabIndex="9" runat="server" Width="150px" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Height="25px"></asp:dropdownlist></TD>
											<TD style="HEIGHT: 21px" align="left" width="20%"><asp:label id="Label12" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Call Install No.</asp:label></TD>
											<TD style="HEIGHT: 21px" align="left" width="30%"><asp:textbox id="txtCInstallNo" tabIndex="10" runat="server" Width="30%" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Height="25px" MaxLength="4"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label50" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Height="30px">Item to be inspected viz. Mechanical, Electrical, Civil etc</asp:label></TD>
											<TD style="HEIGHT: 24px" width="30%" colSpan="3"><asp:dropdownlist id="ddlDept" tabIndex="9" runat="server" Width="25%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="25px"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label51" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">State whether the Call is for Final Or Stage Inspection</asp:label></TD>
											<TD style="HEIGHT: 24px" width="30%" colSpan="3"><asp:radiobutton id="rdbFinal" tabIndex="10" runat="server" Width="80px" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="OrangeRed" AutoPostBack="True" Checked="True" GroupName="g4" Text="Final"></asp:radiobutton><asp:radiobutton id="rdbStage" tabIndex="11" runat="server" Width="56px" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="OrangeRed" AutoPostBack="True" GroupName="g4" Text="Stage"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="Label52" runat="server" Width="336px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkMagenta">* Select Stage in case of Stage Inspection Call.</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="lblIRFC" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue"><font color="red"> In case of IRFC Funded Project, Select 'Yes'</font.</asp:label></TD>
											<TD style="HEIGHT: 24px" width="30%" colSpan="3"><asp:dropdownlist id="ddlIRFC" tabIndex="9" runat="server" Width="56px" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="25px">
													<asp:ListItem Selected="True"></asp:ListItem>
													<asp:ListItem Value="Y">Yes</asp:ListItem>
													<asp:ListItem Value="N">No</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label32" runat="server" Width="56px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Height="14px">Remarks</asp:label><asp:label id="Label36" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="Red">(250 Chars Maxm)</asp:label></TD>
											<TD style="HEIGHT: 24px" width="30%" colSpan="3"><asp:textbox id="txtRemarks" tabIndex="11" runat="server" Width="95%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="250" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 24px" width="181"><asp:label id="Label26" runat="server" Width="200px" Font-Names="Verdana" Font-Size="10pt"
													Font-Bold="True" ForeColor="RoyalBlue" Font-Underline="True">Manufacturer's Information</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 24px" width="173"><asp:checkbox id="chkManuf" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" AutoPostBack="True" Text="Same As Vendor" oncheckedchanged="chkManuf_CheckedChanged"></asp:checkbox></TD>
											<TD style="HEIGHT: 24px" align="left" width="20%"></TD>
											<TD style="HEIGHT: 24px" align="right" width="30%"><asp:label id="lblCUpdateStatus" runat="server" Width="184px" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="OrangeRed" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 36px" width="181"><asp:label id="Label10" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Name of Manufacturer</asp:label></TD>
											<TD style="HEIGHT: 36px" width="30%" colSpan="3"><asp:textbox id="txtMName" tabIndex="12" runat="server" Width="20%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="50"></asp:textbox><asp:button id="btnFCList" tabIndex="13" runat="server" Width="30%" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="DarkBlue" Height="19px" Text="Select Manufacturer" ToolTip="Enter the Manufacturer Code or 1st few letters of Manufacturer Name then click on select Vendor Button" onclick="btnFCList_Click"></asp:button>
												<asp:label id="lblMFG_CD" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana" Width="256px" Height="14px" Visible="False"></asp:label><asp:dropdownlist onkeypress="return keySort(ddlManufac);" id="ddlManufac" tabIndex="14" runat="server"
													Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="25px" Visible="False" AutoPostBack="True" onselectedindexchanged="ddlManufac_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 41px" width="181"><asp:label id="Label24" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Place of Inspection</asp:label></TD>
											<TD style="HEIGHT: 41px" width="30%" colSpan="3"><asp:textbox id="txtMPOI" tabIndex="15" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="40px" MaxLength="30" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 26px" width="181"><asp:label id="Label11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Contact  Person's Name</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 26px" width="173"><asp:textbox id="txtMConPer" tabIndex="16" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="30"></asp:textbox></TD>
											<TD style="HEIGHT: 26px" width="20%"><asp:label id="Label33" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Manufacturer Email</asp:label></TD>
											<TD style="HEIGHT: 26px" align="left" width="30%"><asp:textbox id="txtMEmail" tabIndex="17" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px" width="181"><asp:label id="label20" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Phone No.</asp:label></TD>
											<TD style="WIDTH: 173px" width="173"><asp:textbox id="txtMPNo" tabIndex="18" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="30"></asp:textbox></TD>
											<TD width="30%" colSpan="2"><asp:button id="btnUManuf" tabIndex="23" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="DarkBlue" Height="22px" Text="Update Manufacturer's Contact Details." ToolTip="If you want to Change Manufacturer's Contact Person and Tel No. then Change The Values and Click on button" onclick="btnUManuf_Click"></asp:button></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="4"><asp:checkbox id="chkNewVendor" tabIndex="25" runat="server" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="Crimson" Text="Kindly Check this option for New Vendor!!!"></asp:checkbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"><asp:checkbox id="CHKRejCan" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Red" Text="Call for Billing of Cancellation/Rejection Charges!!!" ToolTip="Check this box, if you are registering the Call for Billing of Cancellation/Rejection charges."></asp:checkbox></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="Label_des_dt" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center"><asp:button id="btnSave" tabIndex="19" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="20" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnCancel" tabIndex="21" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:button id="btnCDetails" tabIndex="22" runat="server" Width="81px" Font-Names="Verdana"
										Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Visible="False" Text="Call Details" onclick="btnCDetails_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 106px" align="center"><asp:label id="Label48" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%"> Note: Scanned copy of order given by prime contractor to vendor (In case of Contract/LOA Calls)/ Other relevant Document (If any in "PDF" Format only). Scanned copy should be in Black & White and Low DPI.</asp:label>
									<P></P>
									<INPUT id="File1" style="FONT-SIZE: 8pt; WIDTH: 424px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 22px; Visible: false"
										tabIndex="28" type="file" size="51" name="File1" runat="server">
									<asp:Label id="lblCluster_Cd" runat="server" Visible="False">Label</asp:Label>
									<P><asp:button id="btnUpload" tabIndex="29" runat="server" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Width="142px" Text="Upload Documents" onclick="btnUpload_Click"></asp:button><asp:button id="Button1" tabIndex="30" runat="server" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Width="67px" Text="Cancel"></asp:button></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
