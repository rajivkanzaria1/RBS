<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DEO_Vendor_PurchesOrder_Form.aspx.cs" Inherits="RBS.DEO_Vendor_PurchesOrder_Form.DEO_Vendor_PurchesOrder_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Purchase Order Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate3(field)
		{
		 var val1=trimAll(field.value);
		 if(val1.length==0)
		 {
		  alert("Please Enter Search Criteria!!!");
		  event.returnValue=false;
		 }
		}
		
		 function validate2()
		{
		 
		 
		 if(trimAll(document.Form1.ddlConsigneeCD.value)=="")
		{
		 alert("ENTER VALID CONSIGNEE!!!");
		 event.returnValue=false;
		 }
		 else  if(trimAll(document.Form1.ddlBPOCode.value)=="")
		{
		 alert("ENTER VALID BPO!!!");
		 event.returnValue=false;
		 }
		  else
		 return;

		}
		
		function validate1()
		{
		 
		 
		 if(trimAll(document.Form1.txtVend.value)=="")
		{
		 alert("ENTER VENDOR CODE OR 1ST Few CHARACTERS OF VENDOR NAME AND THEN CLICK ON SELECT VENDOR BUTTON");
		 event.returnValue=false;
		 }
		  else
		 return;

		}
		
		function abc(field)
		{
		var a=field.value;
		var l=a.length;
		document.Form1.txtPOLst5.value=a.substr(l-5,l);
		}
		
		function validate()
		{
		
		if(document.Form1.ddlPurcherCode.value=="-Select-")
		 {
			alert("PLEASE SELECT PURCHES CODE!!");
			event.returnValue=false;
		 }
		 else if(document.Form1.ddlSNS.value=="-Select-")
		 {
			alert("PLEASE SELECT STOCK TYPE");
			event.returnValue=false;
		 }
		 else if(document.Form1.txtPOdate.value=="")
		 {
			alert("PLEASE ENTER PURCHASE ORDER DATE");
			event.returnValue=false;
		 }
		 else if(document.Form1.ddlPOLetter.value=="")
		 {
			alert("PLEASE SELECT PO/OFFER LETTER NO.");
			event.returnValue=false;
		 }
		 else if(document.Form1.txtMaxFee=="[object]" && document.Form1.txtMaxFee.value!="" && IsNumeric(document.Form1.txtMaxFee.value) == false)
		 {
		 alert("INVALID CHARACTERS IN MAXM FEE ALLOWED");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtMinFee=="[object]" && document.Form1.txtMinFee.value!="" && IsNumeric(document.Form1.txtMinFee.value) == false)
		 {
		 alert("INVALID CHARACTERS IN MINM FEE PAYBLE");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtMaxFee=="[object]" && document.Form1.txtMinFee=="[object]" && document.Form1.txtMinFee.value!="" && document.Form1.txtMaxFee.value!="" && (document.Form1.txtMinFee.value > document.Form1.txtMaxFee.value))
		 {
		 alert("MINM FEE PAYBLE CANNOT BE GREATER THEN MAXMM FEE");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtPORemarks.value.length > 500)
		 {
		 alert("PLZ ENTER REMARKS WITHIN 500 CHARACTERS ONLY!!!");
		 event.returnValue=false;
		 }
		 else
		 {
		 document.Form1.btnSave.style.visibility = 'hidden';
		 return;	
		 }
		 // else if(document.Form1.txtPON.value=="")
		// {
		//	alert("PLEASE ENTER PURCHES ORDER NUMBER");
		//	event.returnValue=false;
		// }
		// else if(document.Form1.txtPOLst5.value=="")
		// {
		//	alert("PLEASE ENTER LAST 5 DIGIT OF PURCHES ORDER NUMBER");
		//	event.returnValue=false;
		// }
		 // else if(document.Form1.txtDatePOrites.value=="")
		// {
		//	alert("PLEASE ENTER DATE_OF_RECEIPT OF PURCHES ORDER IN RITES");
		//	event.returnValue=false;
		// }
		 // else if(document.Form1.ddlVender.value=="-Select-")
		// {
		//	alert("PLEASE SELECT VENDOR NAME");
		//	event.returnValue=false;
		// }
		 
		}
		
		function selectInspAgency()
		{
			if (document.Form1.ddlInspAgency.value=="C")
				{document.Form1.txtInspAgency.style.visibility = 'visible';}
			else if(document.Form1.ddlInspAgency.value=="X")
			{
				document.Form1.txtInspAgency.value="PO Cancelled!!!";
				document.Form1.txtInspAgency.style.visibility = 'visible';
			}
			else
				{document.Form1.txtInspAgency.style.visibility ='hidden';}
		}
		
		function conformation()
		{
			var d=confirm("Click OK to Confirm Delete!!!");
			if(d==true)
			event.returnValue=true;
			else
			event.returnValue=false;
		}
		
		 function keySort(dropdownlist,caseSensitive)
		{
			// check the keypressBuffer attribute is defined on the dropdownlist 
			var undefined; 
			if (dropdownlist.keypressBuffer == undefined)
			{ 
				dropdownlist.keypressBuffer = ''; 
			} 
			// get the key that was pressed 
			var key = String.fromCharCode(window.event.keyCode); 
			dropdownlist.keypressBuffer += key;
			if (!caseSensitive) 
			{
				// convert buffer to lowercase
				dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
			}
			// find if it is the start of any of the options 
			var optionsLength = dropdownlist.options.length; 
			for (var n=0; n < optionsLength; n++) 
			{ 
				var optionText = dropdownlist.options[n].text; 
				if (!caseSensitive)
				{
				optionText = optionText.toLowerCase();
				}
				if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0)
				{ 
				dropdownlist.selectedIndex = n; 
				return false; // cancel the default behavior since 
								// we have selected our own value 
				} 
			} 
			// reset initial key to be inline with default behavior 
			dropdownlist.keypressBuffer = key; 
			return true; // give default behavior 
		} 
		
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtVend.focus();selectInspAgency();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 25.8%"
				borderColor="#b0c4de" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px">
						<p align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></p>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 13px" align="center">
						<P><asp:label id="Label1" runat="server" Font-Bold="True" BackColor="White" Font-Names="Verdana"
								Font-Size="10pt" ForeColor="DarkBlue" Width="187px" Height="19px">PURCHASE ORDER FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 13px" align="center" width="100%">
						<TABLE id="Table2" style="HEIGHT: 175px" borderColor="#b0c4de" cellSpacing="1" cellPadding="1"
							width="100%" align="center" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblCaseNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%" Visible="False">Ref No.</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 20px" colSpan="2">
									<P><asp:label id="lblCasNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="136px" Visible="False"></asp:label>
										<asp:label id="lblRealCaseNO1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="232px" Visible="False"></asp:label><asp:label id="lblRealCaseNO" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="232px"></asp:label></P>
								</TD>
								<TD style="WIDTH: 30%; HEIGHT: 20px" align="right"><P><asp:label id="Label9" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkViolet" Width="90%"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%">Railway/Non-Railway</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 20px" colSpan="3">
									<P><asp:label id="Label8" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="20%" Visible="False"></asp:label><asp:label id="lblRailway" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="50%"></asp:label><asp:label id="lblRailwayCode" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="10%" Visible="False"></asp:label><asp:label id="lblRCD" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="10%" Visible="False"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="Label10" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%">Agency/Client</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 20px" colSpan="3"><asp:dropdownlist id="lstBPO_Rly" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="98%" AutoPostBack="True" onselectedindexchanged="lstBPO_Rly_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="txtBPO_RLY" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="95%" MaxLength="300"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: red; FONT-FAMILY: Verdana; HEIGHT: 53px"
									width="223"><asp:label id="Label6" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="48px"> Vendor</asp:label>*</TD>
								<TD style="WIDTH: 85%; HEIGHT: 0.08%" colSpan="3"><asp:textbox id="txtVend" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="15%" Height="20px"></asp:textbox><asp:button id="btnFCList" tabIndex="2" runat="server" Font-Bold="True" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="20%" ToolTip="Enter the Vendor Code or 1st few letters of Vendor then click on select Vendor Button"
										Text="Select Vendor"></asp:button><asp:dropdownlist onkeypress="return keySort(ddlVender);" id="ddlVender" tabIndex="3" runat="server"
										Font-Names="Verdana" Font-Size="7pt" ForeColor="DarkBlue" Width="99%" Height="25px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 29px" width="223"><asp:label id="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%"> PO/Offer Letter No.</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 29px"><asp:dropdownlist id="ddlPOLetter" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%" Height="25px">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="P">Purchase Order</asp:ListItem>
										<asp:ListItem Value="L">Letter of Offer</asp:ListItem>
									</asp:dropdownlist>
									<asp:label id="Label15" runat="server" Width="100%" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True">* Select Purchase Order in case of normal Stores Purchase order and Letter of offer in case of LOA/Contract Agree ment/Works Order/Other Contracts Order.</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 31px" width="179"><asp:label id="Label7" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%">Stock / Non-Stock</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 31px"><asp:dropdownlist id="ddlSNS" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="50%" Height="25px">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="S">Stock</asp:ListItem>
										<asp:ListItem Value="N">Non-Stock</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 18px" width="223"><asp:label id="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%">Purchase Order No.</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 18px"><asp:textbox id="txtPON" onblur="abc(txtPON);" tabIndex="6" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="100%" Height="20px" MaxLength="75"></asp:textbox></TD>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: red; FONT-FAMILY: Verdana; HEIGHT: 18px"
									width="179"><asp:label id="Label5" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="52px"> PO Date</asp:label>*</TD>
								<TD style="WIDTH: 30%; HEIGHT: 18px"><asp:textbox id="txtPOdate" onblur="check_date(txtPOdate);compareDates(txtPOdate,txtDatePOrites,'Date Of Reciept In Rites Cannot Be Less Then PO Date');"
										tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="75%" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="lblPurchCode" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%">Purchaser </asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 31px" colSpan="3">
									<P><asp:textbox id="txtSPur" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="30%" Height="20px" MaxLength="50"></asp:textbox><asp:button id="btnSPur" tabIndex="9" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="144px" Text="Search Purchaser" onclick="btnSPur_Click"></asp:button><asp:label id="Label14" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkMagenta" Width="238px">* In Case Of other Client</asp:label><asp:dropdownlist onkeypress="return keySort(ddlPurcherCode);" id="ddlPurcherCode" tabIndex="10" runat="server"
											Font-Names="Verdana" Font-Size="7pt" ForeColor="DarkBlue" Width="99%" Height="25px"></asp:dropdownlist><asp:textbox id="txtPurchaser" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="95%" MaxLength="300"></asp:textbox></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%" width="223"><asp:label id="Label12" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%"> Date of Reciept of PO in RITES</asp:label></TD>
								<TD style="WIDTH: 30%"><asp:textbox id="txtDatePOrites" onblur="check_date(txtDatePOrites);compareDates(txtPOdate,txtDatePOrites,'Date Of Reciept In Rites Cannot Be Less Then PO Date');"
										tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="75%" Height="20px"></asp:textbox></TD>
								<TD style="WIDTH: 20%" width="179"><asp:label id="Label13" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%">Last 5 digit of PO</asp:label></TD>
								<TD style="WIDTH: 30%"><asp:textbox id="txtPOLst5" tabIndex="12" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="75%" Height="20px" MaxLength="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 29px" width="223"><asp:label id="Label18" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%">Inspection Agency/PO Cancelled</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 29px" colSpan="3"><asp:dropdownlist id="ddlInspAgency" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="20%" Height="25px" onchange="selectInspAgency();">
										<asp:ListItem Value="R" Selected="True">RITES</asp:ListItem>
										<asp:ListItem Value="C">Consignee</asp:ListItem>
										<asp:ListItem Value="X">PO Cancelled</asp:ListItem>
									</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtInspAgency" runat="server" Font-Bold="True" BackColor="#f0f8ff" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="Blue" Width="216px" BorderStyle="None"> Inspection By Consignee</asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 31px" width="223">
									<asp:label id="Label26" runat="server" Width="200px" ForeColor="RoyalBlue" Font-Size="10pt"
										Font-Names="Verdana" Font-Bold="True" Font-Underline="True">Manufacturer's Information</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 31px" colSpan="3">
									<asp:checkbox id="chkManuf" tabIndex="14" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" AutoPostBack="True" Text="Same As Vendor" oncheckedchanged="chkManuf_CheckedChanged"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 31px" width="223">
									<asp:label id="Label11" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True">Name of Manufacturer/Name Of Firm (In case place of inspection is other than place of manufacturer)</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 31px" colSpan="3">
									<asp:textbox id="txtMName" tabIndex="15" runat="server" Height="20px" Width="20%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" MaxLength="50"></asp:textbox>
									<asp:button id="btnPOI" tabIndex="16" runat="server" Height="19px" Width="30%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Text="Select Manufacturer" ToolTip="Enter the Manufacturer Code or 1st few letters of Manufacturer Name then click on select Vendor Button" onclick="btnPOI_Click"></asp:button>
									<asp:label id="Label47" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True">* To Search Enter First Few Characters Of Name and Click on Select Manufacturer Button, then select the from the list given below.</asp:label>
									<asp:dropdownlist onkeypress="return keySort(ddlManufac);" id="ddlManufac" tabIndex="17" runat="server"
										Height="25px" Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Visible="False"
										AutoPostBack="True" ondatabinding="ddlManufac_DataBinding" onselectedindexchanged="ddlManufac_SelectedIndexChanged"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 31px" width="223">
									<asp:label id="Label24" runat="server" Width="144px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True">Place of Inspection</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 31px" colSpan="3">
									<asp:textbox id="txtMPOI" tabIndex="18" runat="server" Height="40px" Width="90%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" MaxLength="30" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label17" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%">Remarks</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 31px" colSpan="3"><asp:textbox id="txtPORemarks" onblur="abc(txtPON);" tabIndex="19" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="100%" Height="40px" MaxLength="500" TextMode="MultiLine"></asp:textbox>
									<asp:label id="lblPORemarks" runat="server" Width="50%" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%" align="center" width="233" bgColor="white" colSpan="4"><asp:button id="btnAcceptPO" tabIndex="20" runat="server" Font-Bold="True" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="81px" Text="Accept PO" onclick="btnAcceptPO_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="center"><asp:button id="btnSave" tabIndex="21" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="61px" Text="Save PO" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="22" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="58px" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:button id="btnPODetails" tabIndex="23" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="108px" Text="PO Details>>" onclick="btnPODetails_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" align="center"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
