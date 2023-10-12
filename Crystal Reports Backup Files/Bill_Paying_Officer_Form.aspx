<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bill_Paying_Officer_Form.aspx.cs" Inherits="RBS.Bill_Paying_Officer_Form.Bill_Paying_Officer_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Bill Paying Officer Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(document.Form1.txtBPOCD=="[object]" && document.Form1.txtBPOCD.value=="")
		 {
		 alert("BPO CODE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else if(document.Form1.txtBPOName.value=="")
		 { 
		 alert("BPO NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtBPORailways.style.visibility == 'visible' && document.Form1.txtBPORailways.value=="")
		 {
		 alert("BPO ABBREVIATED NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.lstBPORailways.style.visibility == 'visible' && trimAll(document.Form1.lstBPORailways.value)=="")
		 {
		 alert("BPO RLY CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		// else if(document.Form1.lstBPORailways.style.visibility == 'visible' && trimAll(document.Form1.lstPayingWindow.value)=="")
		// {
		//	alert("Select Paying Window Option!!!");
		//	event.returnValue=false;
		// 
		// }
	//	 else if(document.Form1.txtBPOAdd.value=="")
	//	 {
	//	 alert("BPO ADDRESS CANNOT BE LEFT BLANK");
	//	 event.returnValue=false;
	//	 }
		// else if(document.Form1.txtBPOFee.value=="")
		// {
		// alert("BPO FEE CANNOT BE LEFT BLANK");
		// event.returnValue=false;
		// }
		else if(trimAll(document.Form1.txtCity.value)=="")
		{
		 alert("CITY CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtBPOFee.value!="" && isNaN(parseInt(document.Form1.txtBPOFee.value))) 
		 {
		 alert("THE BPO FEE CONTAINS INVALID CHARACTERS.");
		 event.returnValue=false;		
		 }
		 else if(document.Form1.txtBPOOrg.value=="")
		 {
		 alert("BPO ORGANISATION NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtGSTINNo.value)!="" && document.Form1.txtGSTINNo.value.length != 15)
		{
		 alert("PLZ ENTER 15 CHARACTERS LONG GSTIN NO. ONLY!!!");
		 event.returnValue=false;
		}
		 else if(trimAll(document.Form1.txtPin.value)!="" && document.Form1.txtPin.value.length != 6)
		{
		 alert("PLZ ENTER 6 CHARACTERS LONG PIN NO. ONLY!!!");
		 event.returnValue=false;
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
		event.returnValue=true;
		else
		event.returnValue=false;
		}
		
		function sFocus()
		 {
		 if(document.Form1.txtBPOCD=="[object]")
		 {
		 document.Form1.txtBPOCD.focus();
		 }
		 else
		 {
		 document.Form1.txtBPOName.focus();
		 }
		 }
		 function fill_city_cd()
		 {
		 document.Form1.txtCity.value=document.Form1.lstBPOCity.value;
		 
		 }
		 function bpo_rail()
		 {
		 if(document.Form1.lstBPOType.value=="R")
		 {
			document.Form1.txtBPORailways.style.visibility = 'hidden';
			document.Form1.lstBPORailways.style.visibility = 'visible';
			document.Form1.lstAUCris.style.visibility = 'visible';
			document.Form1.txtAUCris.style.visibility = 'visible';
			document.Form1.lstBPORailways.focus();
			document.Form1.lstPayingWindow.disabled=false;
			
		 }
		 else
		 {
			document.Form1.txtBPORailways.style.visibility = 'visible';
			document.Form1.lstBPORailways.style.visibility = 'hidden';
			document.Form1.lstPayingWindow.disabled=true;
			document.Form1.lstAUCris.style.visibility = 'hidden';
			document.Form1.txtAUCris.style.visibility = 'hidden';
			document.Form1.txtBPORailways.focus();
			
		 }
		 }
		 function bpo_rail_1()
		 {
			if(document.Form1.lstBPOType.value=="R")
			{
				document.Form1.txtBPORailways.style.visibility = 'hidden';
				document.Form1.lstBPORailways.style.visibility = 'visible';
				document.Form1.lstAUCris.style.visibility = 'visible';
				document.Form1.txtAUCris.style.visibility = 'visible';
				document.Form1.lstPayingWindow.disabled=false;
										
			}
			else
			{
				document.Form1.txtBPORailways.style.visibility = 'visible';
				document.Form1.lstBPORailways.style.visibility = 'hidden';
				document.Form1.lstAUCris.style.visibility = 'hidden'; 
				document.Form1.txtAUCris.style.visibility = 'hidden';
				document.Form1.lstPayingWindow.disabled=true;

			}
		 }
		 function bpo_org()
		 {	if(document.Form1.lstBPOType.value=="R")
			{
				//alert(document.Form1.lstBPORailways.text);
				var statusList = document.getElementById("lstBPORailways");
				document.Form1.txtBPOOrg.value = statusList.options[statusList.selectedIndex].text;
			}
			else
			{
			document.Form1.txtBPOOrg.value=document.Form1.txtBPORailways.value
			}
		 
		 }
		 function validate1()
		{
		 if(trimAll(document.Form1.txtCity.value)=="")
		{
		 alert("ENTER CITY CODE OR 1ST 4 CHARACTERS OF CITY NAME AND THEN CLICK ON SELECT CITY BUTTON");
		 event.returnValue=false;
		 }
		  else
		 return;
		}
        </script>
</HEAD>
	<body onblur="bpo_rail_1();" bgColor="#ffffff" onload="bpo_rail();sFocus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px">
						<P align="center"><asp:label id="Label1" runat="server" Width="204px" Font-Names="Verdana" Font-Size="10pt" BackColor="White"
								Font-Bold="True" ForeColor="DarkBlue">BILL PAYING OFFICERS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="left">
						<TABLE id="Table2" style="HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="1" cellPadding="1"
							width="100%" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 20%"><asp:label id="Label6" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO Code</asp:label></TD>
								<TD style="WIDTH: 35%"><asp:label id="lblBPOCD" runat="server" Width="35%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" BorderStyle="Inset">BPO Code</asp:label>
<asp:label id=lblSapCustCD runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="100%"></asp:label></TD>
								<TD style="WIDTH: 15%" align="left" colSpan="1" rowSpan="1">&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label3" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO Name</asp:label></TD>
								<TD style="WIDTH: 30%" align="left"><asp:textbox id="txtBPOName" tabIndex="2" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="50" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 12px"><asp:label id="Label2" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Region Responsible For Chasing O/S</asp:label></TD>
								<TD style="WIDTH: 35%; HEIGHT: 12px"><asp:dropdownlist id="lstBPORegion" tabIndex="3" runat="server" Width="60%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Height="25px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 15%; HEIGHT: 12px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label23" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO Type</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 12px" align="left"><asp:dropdownlist id="lstBPOType" tabIndex="4" runat="server" Width="70%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Height="25px" onChange="bpo_rail();"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 40px"><asp:label id="Label22" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO RLY Code(In Case Of Railways) / Abbreviated Name Of BPO (Otherwise) </asp:label></TD>
								<TD style="WIDTH: 35%; HEIGHT: 40px" vAlign="top" align="left">
									<P><asp:textbox id="txtBPORailways" tabIndex="5" runat="server" Width="100%" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" MaxLength="50" Height="20px" onchange="bpo_org();"></asp:textbox></P>
									<P><asp:dropdownlist id="lstBPORailways" tabIndex="5" runat="server" Width="100%" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Height="25px" onchange="bpo_org();" AutoPostBack="True" onselectedindexchanged="lstBPORailways_SelectedIndexChanged"></asp:dropdownlist></P>
								</TD>
								<TD style="WIDTH: 15%; HEIGHT: 40px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label4" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Address</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 40px" align="left"><asp:textbox id="txtBPOAdd" tabIndex="6" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="100" Height="41px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 38px"><asp:textbox id="txtAUCris" runat="server" Font-Names="Verdana" Font-Size="8pt" BackColor="AliceBlue"
										Font-Bold="True" ForeColor="DarkBlue" BorderStyle="Dashed" ReadOnly="True" BorderColor="AliceBlue">Accounting Unit (AU)</asp:textbox></TD>
								<TD style="WIDTH: 35%; HEIGHT: 38px"><asp:dropdownlist id="lstAUCris" tabIndex="5" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Height="25px" onchange="bpo_org();"></asp:dropdownlist></TD>
								<TD style="WIDTH: 15%; HEIGHT: 38px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label5" runat="server" Width="56px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO City</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 38px" align="left"><asp:textbox id="txtCity" tabIndex="7" runat="server" Width="45%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="4" Height="20px"></asp:textbox><asp:button id="btnFCList" tabIndex="8" runat="server" Width="50%" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" ToolTip="Enter the City Code or 1st 4 letters of CITY then click on select city Button" Text="Select City" onclick="btnFCList_Click"></asp:button><asp:dropdownlist id="lstBPOCity" tabIndex="9" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Height="25px" onChange="fill_city_cd();" AutoPostBack="True" onselectedindexchanged="lstBPOCity_SelectedIndexChanged_1"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 38px"><asp:label id="Label29" runat="server" Width="184px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">PIN Code <font color="red">*</font></asp:label></TD>
								<TD style="WIDTH: 35%; HEIGHT: 38px">
									<P><asp:textbox id="txtPin" runat="server" Width="50%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											MaxLength="6" Height="20px"></asp:textbox></P>
								</TD>
								<TD style="WIDTH: 15%; HEIGHT: 38px" align="left">&nbsp;&nbsp;&nbsp;
									<asp:label id="Label28" runat="server" Width="184px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO State <font color="red">*</font></asp:label>&nbsp;</TD>
								<TD style="WIDTH: 30%; HEIGHT: 38px" align="left"><asp:label id="lblBPOState" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="OrangeRed"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 38px"><asp:label id="Label27" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">GSTIN No. <font color="red">*</font></asp:label></TD>
								<TD style="WIDTH: 35%; HEIGHT: 38px"><asp:textbox id="txtGSTINNo" tabIndex="11" runat="server" Width="50%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="15" Height="20px"></asp:textbox></TD>
								<TD style="WIDTH: 15%; HEIGHT: 38px" align="left"><asp:label id="Label7" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Bill Pass Officer</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 38px" align="left"><asp:textbox id="txtBillPassOff" tabIndex="10" runat="server" Width="100%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" MaxLength="50" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 12px" vAlign="bottom" align="left" colSpan="4"><asp:label id="Label26" runat="server" Width="100%" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
										ForeColor="RoyalBlue" Font-Underline="True">BPO FEE Details</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 24px"><asp:label id="Label9" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO FEE</asp:label></TD>
								<TD style="WIDTH: 35%; HEIGHT: 24px"><asp:textbox id="txtBPOFee" style="TEXT-ALIGN: right" tabIndex="12" runat="server" Width="40%"
										Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="10" Height="20px"></asp:textbox></TD>
								<TD style="WIDTH: 15%; HEIGHT: 24px"></TD>
								<TD style="WIDTH: 30%; HEIGHT: 24px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 29px"><asp:label id="Label8" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO FEE Type</asp:label></TD>
								<TD style="WIDTH: 35%; HEIGHT: 29px"><asp:dropdownlist id="lstBPOFeeType" tabIndex="12" runat="server" Width="60%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Height="25px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 15%; HEIGHT: 29px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label10" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO TAX Type</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 29px" align="left"><asp:dropdownlist id="lstBPOTaxType" tabIndex="13" runat="server" Width="90%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Height="25px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 16px"><asp:label id="Label11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO Flag</asp:label></TD>
								<TD style="WIDTH: 35%; HEIGHT: 16px"><asp:dropdownlist id="lstBPOFlag" tabIndex="14" runat="server" Width="60%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Height="25px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 15%; HEIGHT: 16px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label12" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO Advance Flag</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 16px" align="left"><asp:dropdownlist id="lstBPOAdvFlag" tabIndex="15" runat="server" Width="90%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Height="25px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%"><asp:label id="Label13" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO Location Code</asp:label></TD>
								<TD style="WIDTH: 35%"><asp:textbox id="txtBPOLocCD" tabIndex="16" runat="server" Width="25%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="4" Height="20px"></asp:textbox></TD>
								<TD style="WIDTH: 15%" align="left"></TD>
								<TD style="WIDTH: 30%" align="right"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 25px" vAlign="bottom" align="left" colSpan="4"><asp:label id="Label25" runat="server" Width="100%" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
										ForeColor="RoyalBlue" Font-Underline="True">BPO Organisation Details</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 20px"><asp:label id="Label14" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Organisation</asp:label></TD>
								<TD style="WIDTH: 27.73%; HEIGHT: 20px" colSpan="3"><asp:textbox id="txtBPOOrg" tabIndex="17" runat="server" Width="95%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="50" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%"><asp:label id="Label15" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Address</asp:label></TD>
								<TD style="WIDTH: 35%"><asp:textbox id="txtBPOOrgAdd1" tabIndex="18" runat="server" Width="100%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" MaxLength="100" Height="50px" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="WIDTH: 15%" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label16" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Height="18px">Address</asp:label></TD>
								<TD style="WIDTH: 30%" align="left"><asp:textbox id="txtBPOOrgAdd2" tabIndex="19" runat="server" Width="100%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" MaxLength="100" Height="50px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%"><asp:label id="Label17" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO State</asp:label></TD>
								<TD style="WIDTH: 35%"><asp:textbox id="txtBPOState" tabIndex="20" runat="server" Width="80%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="20" Height="20px"></asp:textbox></TD>
								<TD style="WIDTH: 15%" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label18" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Visible="False">BPO Pin</asp:label></TD>
								<TD style="WIDTH: 30%" align="left"><asp:textbox id="txtBPOPin" tabIndex="21" runat="server" Width="80%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="7" Height="20px" Visible="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 30px"><asp:label id="Label19" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO Phone</asp:label></TD>
								<TD style="WIDTH: 35%; HEIGHT: 30px"><asp:textbox id="txtBPOPhone" tabIndex="22" runat="server" Width="80%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="30" Height="20px"></asp:textbox></TD>
								<TD style="WIDTH: 15%; HEIGHT: 30px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label20" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO Fax</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 30px" align="left"><asp:textbox id="txtBPOFax" tabIndex="23" runat="server" Width="80%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="30" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%"><asp:label id="Label21" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">BPO Email</asp:label></TD>
								<TD style="WIDTH: 35%"><asp:textbox id="txtBPOEmail" tabIndex="24" runat="server" Width="80%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="40" Height="20px"></asp:textbox></TD>
								<TD style="WIDTH: 15%"></TD>
								<TD style="WIDTH: 30%"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%"><asp:label id="Label24" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Paying Window</asp:label></TD>
								<TD style="WIDTH: 35%" colSpan="3"><asp:dropdownlist id="lstPayingWindow" tabIndex="25" runat="server" Width="100%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Height="25px" onchange="bpo_org();"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"><asp:button id="btnSave" tabIndex="25" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="26" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnCancel" tabIndex="27" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR></TD></TR></TABLE>
		</form>
	</body>
</HTML>
