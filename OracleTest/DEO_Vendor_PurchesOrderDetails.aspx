<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DEO_Vendor_PurchesOrderDetails.aspx.cs" Inherits="RBS.DEO_Vendor_PurchesOrderDetails.DEO_Vendor_PurchesOrderDetails" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Vendor Purchase Order Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function conformation()
		{
			var d=confirm("Click OK to Confirm Delete!!!");
			if(d==true)
			event.returnValue=true;
			else
			event.returnValue=false;
		}
		function cpy()
		{
			if(check_date(document.Form1.txtDelvDate)==true)
			{
				
				if(compareDates(document.Form1.txtPODT,document.Form1.txtDelvDate,'Delivery Date Cannot Be Earlier Then PO Date')==true)
				{
					document.Form1.txtExtDelvDate.value=document.Form1.txtDelvDate.value;
				}
				
			}
		}
		
		function basevalue()
		{
			var qty;
			var rate;
			if(trimAll(document.Form1.txtQty.value)=="")
			{
				qty=0;
			}
			else
			{
				qty=parseFloat(trimAll(document.Form1.txtQty.value));
				//document.Form1.txtBaseValue.value=0;
			}
			if(trimAll(document.Form1.txtRate.value)=="")
			{
			rate=0;
			}
			else
			{
				 rate=parseFloat(trimAll(document.Form1.txtRate.value));
			}
			var uom=parseFloat(trimAll(document.Form1.txtUOMFactor.value));
			var basevlue=((qty*rate)/uom);
			document.Form1.txtBaseValue.value=Math.round(basevlue*100)/100;
		}
		function saletax()
		{
			if(trimAll(document.Form1.txtSaleTaxPre.value)!="")
			{
			if(trimAll(document.Form1.txtDiscountAmt.value)!="")
			{
			var discountypeper=parseFloat(trimAll(document.Form1.txtDiscountAmt.value));
			}
			else
			{
			var discountypeper=0;
			}
			
			if(trimAll(document.Form1.txtExciseAmt.value)!="")
			{
			var excise=parseFloat(trimAll(document.Form1.txtExciseAmt.value));
			}
			else
			{
			var excise=0;
			}
			var stper=parseFloat(trimAll(document.Form1.txtSaleTaxPre.value));
			var basevalue=parseFloat(trimAll(document.Form1.txtBaseValue.value));
			var stamount=((basevalue-discountypeper)+ (excise))* stper/100;
			document.Form1.txtSaleTaxAmt.value=Math.round(stamount*100)/100; 
			}
			else
			{
			document.Form1.txtSaleTaxAmt.value=0;
			}
		}
		function excise()
		{
			if(trimAll(document.Form1.ddlExciseType.value)=="P")
			{
				if(trimAll(document.Form1.txtDiscountAmt.value)!="")
				{
				var discountypeper=parseFloat(trimAll(document.Form1.txtDiscountAmt.value));
				}
				else
				{
				var discountypeper=0;
				}
				var exciseper=parseFloat(trimAll(document.Form1.txtExcise.value));
				var basevalue=parseFloat(trimAll(document.Form1.txtBaseValue.value));
				var exciseamount=((basevalue-discountypeper)*(exciseper))/100;
				document.Form1.txtExciseAmt.value=Math.round(exciseamount*100)/100; 
			}
			else if(trimAll(document.Form1.ddlExciseType.value)=="L")
			{
			document.Form1.txtExciseAmt.value=document.Form1.txtExcise.value;
			}
			else
			{
			document.Form1.txtExciseAmt.value=0;
			document.Form1.txtExcise.value=0;
			}
			
		}
		function discountype()
		{
			if(trimAll(document.Form1.ddlDiscountType.value)=="P")
			{
			var discountypeper=parseFloat(trimAll(document.Form1.txtDiscountPer.value));
			var basevalue=parseFloat(trimAll(document.Form1.txtBaseValue.value));
			var discountamount=((basevalue)*(discountypeper))/100;
			document.Form1.txtDiscountAmt.value=Math.round(discountamount*100)/100; 
			}
			else if(trimAll(document.Form1.ddlDiscountType.value)=="L")
			{
			document.Form1.txtDiscountAmt.value=document.Form1.txtDiscountPer.value; 
			}
			else if(trimAll(document.Form1.ddlDiscountType.value)=="N")
			{
			var discountperno=parseFloat(trimAll(document.Form1.txtDiscountPer.value));
			var qty=parseFloat(trimAll(document.Form1.txtQty.value));
			document.Form1.txtDiscountAmt.value=discountperno*qty; 
			}
			else 
			{
			document.Form1.txtDiscountAmt.value=0;
			document.Form1.txtDiscountPer.value=0;
			}
		}
		
		function othercharges()
		{
			if(trimAll(document.Form1.ddlOCType.value)=="P")
			{
			var otherper=parseFloat(trimAll(document.Form1.txtOtherCharges.value));
			var basevalue=parseFloat(trimAll(document.Form1.txtBaseValue.value));
			var otheramount=((basevalue)*(otherper))/100;
			document.Form1.txtOtherChargesAmt.value=Math.round(otheramount*100)/100; 
			}
			else if(trimAll(document.Form1.ddlOCType.value)=="L")
			{
			document.Form1.txtOtherChargesAmt.value=document.Form1.txtOtherCharges.value; 
			}
			else if(trimAll(document.Form1.ddlOCType.value)=="N")
			{
			var otherperno=parseFloat(trimAll(document.Form1.txtOtherCharges.value));
			var qty=parseFloat(trimAll(document.Form1.txtQty.value));
			document.Form1.txtOtherChargesAmt.value=otherperno*qty; 
			}
			else 
			{
			document.Form1.txtOtherChargesAmt.value=0;
			document.Form1.txtOtherCharges.value=0;
			}
		}
		
		
		function total()
		{
			var basevalue=parseFloat(trimAll(document.Form1.txtBaseValue.value));
			var saletaxamt;
			var exciseamt;
			var discountamt;
			var othercharges;
			if(trimAll(document.Form1.txtSaleTaxAmt.value)=="")
			{
			saletaxamt=0;
			}
			else
			{
			saletaxamt=parseFloat(trimAll(document.Form1.txtSaleTaxAmt.value));
			}
			if(trimAll(document.Form1.txtExciseAmt.value)=="")
			{
			exciseamt=0;
			}
			else
			{
			 exciseamt=parseFloat(trimAll(document.Form1.txtExciseAmt.value));
		    }
			 if(trimAll(document.Form1.txtDiscountAmt.value)=="")
			 {
			 discountamt=0;
			 }
			 else
			 {
			  discountamt=parseFloat(trimAll(document.Form1.txtDiscountAmt.value));
			  }
			  if(trimAll(document.Form1.txtOtherCharges.value)=="")
			  {
			  othercharges=0;
			  }
			  else
			  {
			   othercharges=parseFloat(trimAll(document.Form1.txtOtherChargesAmt.value));
			   }
			//var totalvalue1=basevalue + saletaxamt + exciseamt;
			//var totalvalue2=discountamt + othercharges;
			//var totalvalue=totalvalue1-totalvalue2;
			var totalvalue1=basevalue - discountamt;
			var totalvalue2=totalvalue1 + exciseamt;
			var totalvalue3=totalvalue2 + saletaxamt;
			var totalvalue= totalvalue3 + othercharges;
			document.Form1.txtValue.value=Math.round(totalvalue*100)/100;
		}
		
		function validate()
		{
		basevalue();
		discountype();
		excise();
		saletax();
		othercharges();
		total();
		//alert(document.Form1.txtValue.value);
		}
		
		
		
		function isnull1(field)
		{
		var aa=field.value;
		if(aa.length==0)
		{
		alert("CANNOT LEAVE THIS FEILD EMPTY");
		field.select();
		field.focus();
		}
		
		}
		
		function NVL(field)
		{
		var aa=trimAll(field).value;
		if(aa.length==0)
		{
		field.value=0;
		}
		
		}
		
		function sFocus()
		 {
		 if(trimAll(document.Form1.txtItemDescpt.value)=="")
		 {
		 document.Form1.txtItemDescpt.focus();
		 }
		 else
		 {
		 document.Form1.txtRate.focus();
		 }
		 }
		 
		 function ConcVisible()
		{
			if (document.Form1.ddlConsigneeCD.value=="0")
			{
				document.Form1.txtConsignee.style.visibility = 'visible';
			
			}
			else
			{
				document.Form1.txtConsignee.style.visibility ='hidden';
			}
		}
		
		 function BPOVisible()
		{
			if (document.Form1.ddlBPOCode.value=="0")
			{
				document.Form1.txtBPO.style.visibility = 'visible';
			
			}
			else
			{
				document.Form1.txtBPO.style.visibility ='hidden';
			}
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
		
		function validate1(field)
		{
		 var val1=trimAll(field.value);
		 if(val1.length<2)
		 {
		  alert("Please Enter Atleast 2 Charaters in Search Criteria!!!");
		  event.returnValue=false;
		 }
		}
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center">
						<P><asp:label id="Label1" runat="server" Font-Bold="True" BackColor="White" Font-Names="Verdana"
								Font-Size="10pt" ForeColor="DarkBlue" Width="397px">VENDOR PURCHASE ORDER DETAILS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 296px" align="center">
						<P>
							<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 276px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" width="100%" align="center" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 27px" vAlign="baseline" align="left"><asp:label id="lblCasNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%"> Ref No.</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 27px"><asp:label id="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="112px"></asp:label></TD>
									<TD style="WIDTH: 20%; HEIGHT: 27px" vAlign="middle" align="left"><asp:label id="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">PO Date</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 27px"><asp:label id="lblPODT" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="112px"></asp:label><asp:textbox id="txtPODT" style="TEXT-ALIGN: right" tabIndex="6" runat="server" BackColor="AliceBlue"
											Width="1px" BorderColor="AliceBlue" MaxLength="14" Height="1px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 40px"><asp:label id="lblItemSLNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Item Serial No.</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 40px"><asp:textbox id="txtItemSLNo" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="150px" Height="20px" Visible="False"></asp:textbox><asp:label id="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="112px"></asp:label></TD>
									<TD style="WIDTH: 20%; HEIGHT: 40px"><asp:label id="lblItemDescpt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Item Description</asp:label></TD>
									<TD style="HEIGHT: 30%"><asp:textbox id="txtItemDescpt" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%" Height="50px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 30px">
										<asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True" Visible="False">Master Item List</asp:label>
										<asp:label id="Label9" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">PL NO.</asp:label></TD>
									<TD style="WIDTH: 100%; HEIGHT: 19px" colSpan="3">
										<asp:dropdownlist id="ddlMasterItems" tabIndex="2" runat="server" Width="100%" ForeColor="DarkBlue"
											Font-Size="7pt" Font-Names="Verdana" Height="25px" onkeypress="return keySort(ddlMasterItems);"
											AutoPostBack="True" Visible="False"></asp:dropdownlist>
										<asp:textbox id="txtPLNO" tabIndex="2" runat="server" Width="150px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 30px"><asp:label id="lblBPOCode" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="48px">BPO</asp:label></TD>
									<TD style="WIDTH: 100%; HEIGHT: 19px" colSpan="3"><asp:textbox id="txtSBPO" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="30%" MaxLength="50" Height="20px"></asp:textbox><asp:button id="btnSBPO" tabIndex="3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="144px" Text="Search BPO" onclick="btnSBPO_Click"></asp:button><asp:label id="Label15" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkMagenta" Width="238px">* In Case Of other Client</asp:label><asp:dropdownlist id="ddlBPOCode" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="7pt"
											ForeColor="DarkBlue" Width="100%" Height="25px" onChange="BPOVisible();"></asp:dropdownlist><asp:textbox id="txtBPO" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="95%" MaxLength="300" tabIndex="5"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 30px"><asp:label id="lblConsigneeCD" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%"> Consignee</asp:label></TD>
									<TD style="WIDTH: 100%; HEIGHT: 19px" colSpan="3"><asp:textbox id="txtSCon" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="30%" MaxLength="50" Height="20px"></asp:textbox><asp:button id="btnSCon" tabIndex="7" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="144px" Text="Search Consignee" onclick="btnSCon_Click"></asp:button><asp:label id="Label7" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkMagenta" Width="238px">* In Case Of other Client</asp:label><asp:dropdownlist onkeypress="return keySort(ddlConsigneeCD);" id="ddlConsigneeCD" tabIndex="8" runat="server"
											Font-Names="Verdana" Font-Size="7pt" ForeColor="DarkBlue" Width="100%" Height="25px" onChange="ConcVisible();"></asp:dropdownlist><asp:textbox id="txtConsignee" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="95%" MaxLength="300" tabIndex="9"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 19px"><asp:label id="lblQty" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Quantity</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 19px"><asp:textbox id="txtQty" style="TEXT-ALIGN: right" tabIndex="10" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="50%" MaxLength="12" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 20%; HEIGHT: 19px"><asp:label id="lblUMOCode" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%"> Unit Of Measurment</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 19px"><asp:dropdownlist id="ddlUOMCode" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="240px" Height="25px" AutoPostBack="True" onselectedindexchanged="ddlUOMCode_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="txtUOMFactor" tabIndex="25" runat="server" BackColor="AliceBlue" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="AliceBlue" Width="1px" MaxLength="10" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 25px"><asp:label id="lblRate" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Rate</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px"><asp:textbox id="txtRate" onblur="basevalue();" style="TEXT-ALIGN: right" tabIndex="12" runat="server"
											Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="50%" MaxLength="12" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 20%; HEIGHT: 25px"><asp:label id="lblBsValue" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Base Value</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px">
										<P><asp:textbox id="txtBaseValue" onblur="basevalue();" style="TEXT-ALIGN: right" tabIndex="13"
												runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="50%" MaxLength="14"
												Height="20px"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 13px"><asp:label id="lblDiscountPercentage" runat="server" Font-Bold="True" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="100%"> Discount Type</asp:label></TD>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 30%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 13px"><asp:dropdownlist id="ddlDiscountType" tabIndex="14" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="42%" Height="25px">
											<asp:ListItem Selected="True"></asp:ListItem>
											<asp:ListItem Value="P">Percentage</asp:ListItem>
											<asp:ListItem Value="L">Lumpsum</asp:ListItem>
											<asp:ListItem Value="N">Per No.</asp:ListItem>
										</asp:dropdownlist>Value&nbsp;
										<asp:textbox id="txtDiscountPer" onblur="discountype();" style="TEXT-ALIGN: right" tabIndex="8"
											runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="35%" MaxLength="15"
											Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 20%; HEIGHT: 13px"><asp:label id="lblDiscountAmt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%"> Discount</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 13px"><asp:textbox id="txtDiscountAmt" onblur="discountype();" style="TEXT-ALIGN: right" tabIndex="9"
											runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="50%" MaxLength="16" Height="20px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%"><asp:label id="lblExcisePr" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%"> Excise Type</asp:label></TD>
									<TD style="WIDTH: 30%">
										<P style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana"><asp:dropdownlist id="ddlExciseType" tabIndex="17" runat="server" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="42%" Height="25px">
												<asp:ListItem Selected="True"></asp:ListItem>
												<asp:ListItem Value="P">Percentage</asp:ListItem>
												<asp:ListItem Value="L">Lumpsum</asp:ListItem>
											</asp:dropdownlist>Value&nbsp;
											<asp:textbox id="txtExcise" onblur="excise();" style="TEXT-ALIGN: right" tabIndex="18" runat="server"
												Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="35%" MaxLength="10" Height="20px"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 20%"><asp:label id="lblExciseAmt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Excise</asp:label></TD>
									<TD style="WIDTH: 30%">
										<P><asp:textbox id="txtExciseAmt" onblur="excise();" style="TEXT-ALIGN: right" tabIndex="19" runat="server"
												Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="50%" MaxLength="11" Height="20px"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 25px"><asp:label id="lblSaleTaxPr" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">GST/Sale Tax(%)</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px">
										<P><asp:textbox id="txtSaleTaxPre" onblur="saletax();" style="TEXT-ALIGN: right" tabIndex="20" runat="server"
												Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="50%" MaxLength="5" Height="20px"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 20%; HEIGHT: 25px"><asp:label id="lblSaleTaxAmt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%"> Sale Tax</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px">
										<P><asp:textbox id="txtSaleTaxAmt" onblur="saletax();" style="TEXT-ALIGN: right" tabIndex="21" runat="server"
												Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="50%" MaxLength="11" Height="20px"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 2px"><asp:label id="lblOtherCharges" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Other Charges Type</asp:label></TD>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana"><asp:dropdownlist id="ddlOCType" tabIndex="22" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="42%" Height="25px">
											<asp:ListItem Selected="True"></asp:ListItem>
											<asp:ListItem Value="P">Percentage</asp:ListItem>
											<asp:ListItem Value="L">Lumpsum</asp:ListItem>
											<asp:ListItem Value="N">Per No.</asp:ListItem>
										</asp:dropdownlist>Value&nbsp;
										<asp:textbox id="txtOtherCharges" onblur="othercharges();" style="TEXT-ALIGN: right" tabIndex="23"
											runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="35%" MaxLength="11"
											Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 20%; HEIGHT: 2px"><asp:label id="Label5" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Other Charges (AMT)</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 2px"><asp:textbox id="txtOtherChargesAmt" onblur="saletax();" style="TEXT-ALIGN: right" tabIndex="24"
											runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="50%" MaxLength="11" Height="20px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 2px"></TD>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana"
										align="right"></TD>
									<TD style="WIDTH: 20%; HEIGHT: 2px"><asp:label id="lblValue" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="80px">Total Value</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 2px"><asp:textbox id="txtValue" style="TEXT-ALIGN: right" onfocus="total();" tabIndex="25" runat="server"
											Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="50%" MaxLength="16" Height="20px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%"><asp:label id="lblDelvDate" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Delivery Date</asp:label></TD>
									<TD style="WIDTH: 30%">
										<P><asp:textbox id="txtDelvDate" onblur="cpy();" tabIndex="26" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="40%" MaxLength="10" Height="20px"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 20%"><asp:label id="tlblExtDelvDate" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Extended Delivery Date</asp:label></TD>
									<TD style="WIDTH: 30%">
										<P><asp:textbox id="txtExtDelvDate" onblur="check_date(txtExtDelvDate);compareDates(txtDelvDate,txtExtDelvDate,'Extended Delivery Date Cannot Be Less Then Delivery Date');"
												tabIndex="27" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="35%"
												MaxLength="10" Height="20px"></asp:textbox><asp:label id="lblOldConCD" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="12px" Visible="False"></asp:label></P>
									</TD>
								</TR>
							</TABLE>
							<asp:label id="Label6" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkMagenta" Width="100%">To Search a Item-> Select Consignee or Enter Some Search Criteria in Item Description & Click on Search Button, And To See All Items Again Click on Show All Button</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px" align="center"><asp:button id="btnAdd" tabIndex="28" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Width="58px" Visible="False" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnSave" tabIndex="29" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="61px" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="30" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="58px" Visible="False" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnCancel" tabIndex="31" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="58px" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:button id="btnSearch" tabIndex="32" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="58px" Text="Search" onclick="btnSearch_Click"></asp:button><asp:button id="btnShowAll" tabIndex="33" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="66px" Text="Show All" onclick="btnShowAll_Click"></asp:button></TD>
					</TD></TR>
				<TR>
					<TD align="center"><asp:datagrid id="DgPO" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" BorderColor="DarkBlue"
							Height="96px" BorderStyle="Groove" PageSize="5" AutoGenerateColumns="False">
							<AlternatingItemStyle HorizontalAlign="Center" BackColor="#CCCCFF"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
								BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Item Sl. No.">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" NavigateUrl='<%#"DEO_Vendor_PurchesOrderDetails.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;ITEM_SRNO=" + DataBinder.Eval(Container.DataItem,"ITEM_SRNO") +"&amp;type="+ptype+"&amp;PODT="+PODT+"&amp;PO_OR_LOA="+po_or_loa %>' Runat="server" Text=' <%# DataBinder.Eval(Container.DataItem,"ITEM_SRNO")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="CASE_NO" HeaderText="Case Number">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ITEM_SRNO" HeaderText="Item Sl. No.">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ITEM_DESC" HeaderText="Item description">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CONSIGNEE_NAME" HeaderText="Consignee">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="QTY" HeaderText="Quantity">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RATE" HeaderText="Rate">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="VALUE" HeaderText="Total Value(Inc. Taxes)">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
