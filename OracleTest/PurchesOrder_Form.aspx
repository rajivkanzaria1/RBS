<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchesOrder_Form.aspx.cs" Inherits="RBS.PurchesOrder_Form11" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
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
			{
				document.Form1.txtInspAgency.value="Inspection By Consignee";
				document.Form1.txtInspAgency.style.visibility = 'visible';
			}
			else if(document.Form1.ddlInspAgency.value=="X")
			{
				document.Form1.txtInspAgency.value="PO Cancelled!!!";
				document.Form1.txtInspAgency.style.visibility = 'visible';
			}
			else
			{
				document.Form1.txtInspAgency.style.visibility ='hidden';
			}
			
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
						<P><asp:label id="Label1" runat="server" Height="19px" Width="187px" ForeColor="DarkBlue" Font-Size="10pt"
								Font-Names="Verdana" BackColor="White" Font-Bold="True">PURCHASE ORDER FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 13px" align="center" width="100%">
						<TABLE id="Table2" style="HEIGHT: 175px" borderColor="#b0c4de" cellSpacing="1" cellPadding="1"
							width="100%" align="center" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblCaseNo" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Visible="False">Case Number</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 20px" colSpan="2">
									<P><asp:label id="lblCasNo" runat="server" Width="90%" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True" Visible="False"></asp:label></P>
								</TD>
								<TD style="WIDTH: 30%; HEIGHT: 20px" align="right"><P><asp:label id="Label9" runat="server" Width="90%" ForeColor="DarkViolet" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True">Agency</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 20px" colSpan="3">
									<P><asp:label id="Label8" runat="server" Width="20%" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True" Visible="False"></asp:label><asp:label id="lblRailway" runat="server" Width="50%" ForeColor="OrangeRed" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True"></asp:label><asp:label id="lblRailwayCode" runat="server" Width="10%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True" Visible="False"></asp:label><asp:label id="lblRCD" runat="server" Width="10%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True" Visible="False"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: red; FONT-FAMILY: Verdana; HEIGHT: 53px"
									width="223"><asp:label id="Label6" runat="server" Width="48px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True"> Vendor</asp:label>*</TD>
								<TD style="WIDTH: 85%; HEIGHT: 0.08%" colSpan="3"><asp:textbox id="txtVend" tabIndex="1" runat="server" Height="20px" Width="15%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana"></asp:textbox><asp:button id="btnFCList" tabIndex="2" runat="server" Width="20%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Text="Select Vendor" ToolTip="Enter the Vendor Code or 1st few letters of Vendor then click on select Vendor Button" onclick="btnFCList_Click"></asp:button><asp:dropdownlist onkeypress="return keySort(ddlVender);" id="ddlVender" tabIndex="3" runat="server"
										Height="25px" Width="99%" ForeColor="DarkBlue" Font-Size="7pt" Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="ddlVender_SelectedIndexChanged_1"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 29px" width="223"><asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True"> PO/Offer Letter No.</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 29px"><asp:dropdownlist id="ddlPOLetter" tabIndex="4" runat="server" Height="25px" Width="100%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="P">Purchase Order</asp:ListItem>
										<asp:ListItem Value="L">Letter of Offer</asp:ListItem>
									</asp:dropdownlist>
									<asp:label id="Label20" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Width="100%">* Select Purchase Order in case of normal Stores Purchase order and Letter of offer in case of LOA/Contract Agree ment/Works Order/Other Contracts Order.</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 31px" width="179"><asp:label id="Label7" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True">Stock / Non-Stock</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 31px"><asp:dropdownlist id="ddlSNS" tabIndex="5" runat="server" Height="25px" Width="50%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="S">Stock</asp:ListItem>
										<asp:ListItem Value="N">Non-Stock</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 18px" width="223"><asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True">Purchase Order No.</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 18px"><asp:textbox id="txtPON" onblur="abc(txtPON);" tabIndex="6" runat="server" Height="20px" Width="100%"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="75"></asp:textbox></TD>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: red; FONT-FAMILY: Verdana; HEIGHT: 18px"
									width="179"><asp:label id="Label5" runat="server" Width="52px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True"> PO Date</asp:label>*</TD>
								<TD style="WIDTH: 30%; HEIGHT: 18px"><asp:textbox id="txtPOdate" onblur="check_date(txtPOdate);compareDates(txtPOdate,txtDatePOrites,'Date Of Reciept In Rites Cannot Be Less Then PO Date');"
										tabIndex="7" runat="server" Height="20px" Width="75%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="lblPurchCode" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True">Purchaser </asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 31px" colSpan="3">
									<P><asp:textbox id="txtSPur" tabIndex="8" runat="server" Height="20px" Width="30%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="50"></asp:textbox><asp:button id="btnSPur" tabIndex="9" runat="server" Width="144px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True" Text="Search Purchaser" onclick="btnSPur_Click"></asp:button><asp:label id="Label14" runat="server" Width="238px" ForeColor="DarkMagenta" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">* In Case Of other Client</asp:label><asp:dropdownlist onkeypress="return keySort(ddlPurcherCode);" id="ddlPurcherCode" tabIndex="10" runat="server"
											Height="25px" Width="99%" ForeColor="DarkBlue" Font-Size="7pt" Font-Names="Verdana"></asp:dropdownlist></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%" width="223"><asp:label id="Label12" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True"> Date of Reciept of PO in RITES</asp:label></TD>
								<TD style="WIDTH: 30%"><asp:textbox id="txtDatePOrites" onblur="check_date(txtDatePOrites);compareDates(txtPOdate,txtDatePOrites,'Date Of Reciept In Rites Cannot Be Less Then PO Date');"
										tabIndex="11" runat="server" Height="20px" Width="75%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
								<TD style="WIDTH: 20%" width="179"><asp:label id="Label13" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True">Last 5 digit of PO</asp:label></TD>
								<TD style="WIDTH: 30%"><asp:textbox id="txtPOLst5" tabIndex="12" runat="server" Height="20px" Width="75%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" MaxLength="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 29px" width="223"><asp:label id="Label18" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True">Inspection Agency/PO Cancelled</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 29px" colSpan="3"><asp:dropdownlist id="ddlInspAgency" tabIndex="13" runat="server" Height="25px" Width="20%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" onchange="selectInspAgency();">
										<asp:ListItem Value="R" Selected="True">RITES</asp:ListItem>
										<asp:ListItem Value="C">Consignee</asp:ListItem>
										<asp:ListItem Value="X">PO Cancelled</asp:ListItem>
										<asp:ListItem Value="S">PO Suspended For Inspection</asp:ListItem>
									</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtInspAgency" runat="server" Width="216px" ForeColor="Blue" Font-Size="8pt"
										Font-Names="Verdana" BackColor="#f0f8ff" Font-Bold="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label17" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True">Remarks</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 31px" colSpan="3"><asp:textbox id="txtPORemarks" onblur="abc(txtPON);" tabIndex="13" runat="server" Height="40px"
										Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="500" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 19px"><asp:label id="lblContNo" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Visible="False">Contract No.</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 19px"><asp:textbox id="txtCNO" tabIndex="14" runat="server" Height="20px" Width="100%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Visible="False" MaxLength="50"></asp:textbox></TD>
								<TD style="WIDTH: 20%; HEIGHT: 19px"><asp:label id="lblContDate" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Visible="False">Contract Date</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 19px"><asp:textbox id="txtConDate" onblur="check_date(txtConDate);" tabIndex="15" runat="server" Height="20px"
										Width="75%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 14px"><asp:label id="lblSvrToBeIncluded" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Visible="False">Service Tax to be Included ?</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 14px"><asp:dropdownlist id="ddlSrvTax" tabIndex="16" runat="server" Height="25px" Width="100%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Visible="False">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="Y">Service Tax to be Charged on Fee</asp:ListItem>
										<asp:ListItem Value="N">Fee is Inclusive of Service Tax</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="WIDTH: 20%; HEIGHT: 14px"><asp:label id="lblProjectRef" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Visible="False">Project  Reference</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 14px"><asp:textbox id="txtProjRef" tabIndex="17" runat="server" Height="20px" Width="100%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Visible="False" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%" width="109"><asp:label id="lblMinFee" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Visible="False">Min Fee</asp:label></TD>
								<TD style="WIDTH: 30%"><asp:textbox id="txtMinFee" tabIndex="18" runat="server" Height="20px" Width="75%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Visible="False" MaxLength="11"></asp:textbox></TD>
								<TD style="WIDTH: 20%"><asp:label id="lblMaxFee" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Visible="False">Max Fee</asp:label></TD>
								<TD style="WIDTH: 30%"><asp:textbox id="txtMaxFee" tabIndex="19" runat="server" Height="20px" Width="75%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Visible="False" MaxLength="11"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%" colSpan="4">
									<TABLE id="Table5" borderColor="#b0c4de" cellSpacing="1" cellPadding="1" width="100%" border="2">
										<TBODY>
											<TR>
												<TD style="WIDTH: 238px; HEIGHT: 31px"><asp:label id="Label26" runat="server" Width="200px" ForeColor="RoyalBlue" Font-Size="10pt"
														Font-Names="Verdana" Font-Bold="True" Font-Underline="True">Manufacturer's Information</asp:label></TD>
												<TD style="WIDTH: 30%; HEIGHT: 31px" colSpan="3"><asp:checkbox id="chkManuf" tabIndex="20" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Font-Bold="True" Text="Same As Vendor" AutoPostBack="True" oncheckedchanged="chkManuf_CheckedChanged"></asp:checkbox></TD>
											</TR>
											<tr>
												<TD style="WIDTH: 30%; HEIGHT: 53px"><asp:label id="Label19" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
														Font-Bold="True">Name of Manufacturer/Name Of Firm (In case place of inspection is other than place of manufacturer)</asp:label></TD>
												<TD style="WIDTH: 70%; HEIGHT: 53px"><asp:textbox id="txtMName" tabIndex="21" runat="server" Height="20px" Width="20%" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" MaxLength="50"></asp:textbox><asp:button id="btnPOI" tabIndex="22" runat="server" Height="19px" Width="30%" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Text="Select Manufacturer" ToolTip="Enter the Manufacturer Code or 1st few letters of Manufacturer Name then click on select Vendor Button" onclick="btnPOI_Click"></asp:button><asp:label id="Label47" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Size="8pt"
														Font-Names="Verdana" Font-Bold="True">* To Search Enter First Few Characters Of Name and Click on Select Manufacturer Button, then select the from list given below.</asp:label><asp:dropdownlist onkeypress="return keySort(ddlManufac);" id="ddlManufac" tabIndex="23" runat="server"
														Height="25px" Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Visible="False" AutoPostBack="True" onselectedindexchanged="ddlManufac_SelectedIndexChanged"></asp:dropdownlist></TD>
											</tr>
											<TR>
												<TD style="WIDTH: 30%; HEIGHT: 31px"><asp:label id="Label24" runat="server" Width="144px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
														Font-Bold="True">Place of Inspection</asp:label></TD>
												<TD style="WIDTH: 70%; HEIGHT: 31px"><asp:textbox id="txtMPOI" tabIndex="24" runat="server" Height="40px" Width="90%" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" MaxLength="30" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
										</TBODY>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 20%" align="center" width="233" bgColor="white" colSpan="4"><asp:button id="btnSave" tabIndex="25" runat="server" Width="61px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Text="Save PO" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="26" runat="server" Width="72px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Font-Bold="True" Text="Delete PO" onclick="btnDelete_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:panel id="Panel1" runat="server" Height="160px">
							<TABLE id="Table4" borderColor="#b0c4de" cellSpacing="1" cellPadding="1" width="100%" bgColor="#f0f8ff"
								border="1">
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 19px" align="center" width="177" colSpan="4">
										<asp:label id="Label10" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="100%" Visible="False">CONSIGNEE/BPO DETAILS</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 60%">
										<TITTLE:CUSTOMDATAGRID id="grdCB" runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="80px"
											FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
											CellPadding="2" FreezeRows="0" BorderColor="DarkBlue" PageSize="15" AutoGenerateColumns="False">
											<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
											<AlternatingItemStyle  Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
											<EditItemStyle Height="10%"></EditItemStyle>
											<FooterStyle CssClass="GridHeader"></FooterStyle>
											<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
											<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemTemplate>
														<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"PurchesOrder_Form.aspx?Case_No=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;CONSIGNEE_CD=" + DataBinder.Eval(Container.DataItem,"CONSIGNEE_CD") +"&amp;BPO_CD="+ DataBinder.Eval(Container.DataItem,"BPO_CD")  %>' runat="server">Select</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="CASE_NO" HeaderText="CASE NO."></asp:BoundColumn>
												<asp:BoundColumn DataField="CONSIGNEE_NAME" HeaderText="Consignee">
													<HeaderStyle Width="40%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="BPO_NAME" HeaderText="BPO">
													<HeaderStyle Width="40%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CONSIGNEE_CD" HeaderText="Consignee CD"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="BPO_CD" HeaderText="BPO_CD"></asp:BoundColumn>
											</Columns>
										</TITTLE:CUSTOMDATAGRID></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 100%">
										<TABLE id="Table5" borderColor="#b0c4de" cellSpacing="1" cellPadding="1" width="100%" border="2">
											<TR>
												<TD style="WIDTH: 10%">
													<asp:label id="Label11" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
														ForeColor="DarkBlue" Width="40px">Firm</asp:label></TD>
												<TD style="WIDTH: 90%">
													<asp:label id="lblFirm" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
														ForeColor="OrangeRed" Width="80%"></asp:label>
													<asp:label id="lblFirmCD" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
														ForeColor="OrangeRed" Width="10%" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 10%">
													<asp:label id="lblConsigneeCD" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
														ForeColor="DarkBlue" Width="72px"> Consignee</asp:label></TD>
												<TD style="WIDTH: 90%; HEIGHT: 24px" width="177">
													<P>
														<asp:textbox id="txtSCon" tabIndex="27" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
															Width="30%" Height="20px" MaxLength="50"></asp:textbox>
														<asp:button id="btnSCon" tabIndex="28" runat="server" Font-Bold="True" Font-Names="Verdana"
															Font-Size="8pt" ForeColor="DarkBlue" Width="144px" Text="Search Consignee" onclick="btnSCon_Click"></asp:button>
														<asp:label id="Label15" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
															ForeColor="DarkMagenta" Width="238px">* In Case Of other Client</asp:label></P>
												</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 90%; HEIGHT: 24px" width="177" colSpan="2">
													<asp:dropdownlist onkeypress="return keySort(ddlConsigneeCD);" id="ddlConsigneeCD" tabIndex="29" runat="server"
														Font-Names="Verdana" Font-Size="7pt" ForeColor="DarkBlue" Width="100%" Height="25px"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 10%">
													<asp:label id="lblBPOCode" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
														ForeColor="DarkBlue" Width="48px">BPO</asp:label></TD>
												<TD style="WIDTH: 90%; HEIGHT: 24px" width="177">
													<P>
														<asp:textbox id="txtSBPO" tabIndex="30" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
															Width="30%" Height="20px" MaxLength="50"></asp:textbox>
														<asp:button id="btnSBPO" tabIndex="31" runat="server" Font-Bold="True" Font-Names="Verdana"
															Font-Size="8pt" ForeColor="DarkBlue" Width="144px" Text="Search BPO" onclick="btnSBPO_Click"></asp:button>
														<asp:label id="Label16" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
															ForeColor="DarkMagenta" Width="238px">* In Case Of other Client</asp:label></P>
												</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 90%; HEIGHT: 24px" width="177" colSpan="2">
													<asp:dropdownlist id="ddlBPOCode" tabIndex="32" runat="server" Font-Names="Verdana" Font-Size="7pt"
														ForeColor="DarkBlue" Width="100%" Height="25px"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 20%; HEIGHT: 22px" align="center" width="177" bgColor="#ffffff" colSpan="2">
													<asp:button id="btnSaveCB" tabIndex="33" runat="server" Font-Bold="True" Font-Names="Verdana"
														Font-Size="8pt" ForeColor="DarkBlue" Width="137px" Text="Add Consignee:BPO" onclick="btnSaveCB_Click"></asp:button>
													<asp:button id="btnDelCB" tabIndex="34" runat="server" Font-Bold="True" Font-Names="Verdana"
														Font-Size="8pt" ForeColor="DarkBlue" Width="148px" Text="Delete Consignee:BPO" onclick="btnDelCB_Click"></asp:button></TD>
											</TR>
											<asp:panel id="Panel2" runat="server">
												<TR>
													<TD align="center" bgColor="#ccccff" colSpan="2">
														<P>
															<asp:label id="Label21" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
																ForeColor="DarkMagenta" Width="100%"> Upload a scanned copy of Purchase Order in "PDF" format from here. Scanned copy should be in Black & White and Low DPI.
							</asp:label></P>
														<P><INPUT id="File1" style="FONT-SIZE: 8pt; WIDTH: 424px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 22px"
																tabIndex="23" type="file" size="51" name="File1" runat="server"></P>
														<P>
															<asp:button id="btnUpload" tabIndex="24" runat="server" Font-Bold="True" Font-Names="Verdana"
																Font-Size="8pt" ForeColor="DarkBlue" Width="83px" Text="Upload PO" onclick="btnUpload_Click"></asp:button></P>
													</TD>
												</TR>
											</asp:panel></TABLE>
									</TD>
								</TR>
							</TABLE>
						</asp:panel></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="center"><asp:button id="btnCancel" tabIndex="35" runat="server" Width="58px" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:button id="btnPODetails" tabIndex="36" runat="server" Width="108px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Text="PO Details>>" onclick="btnPODetails_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" align="center"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
