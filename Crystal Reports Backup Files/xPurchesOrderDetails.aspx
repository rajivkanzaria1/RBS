<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xPurchesOrderDetails.aspx.cs" Inherits="RBS.xPurchesOrderDetails.xPurchesOrderDetails" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Purchase Order Details</title>
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
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 123px; TOP: 8px; LEFT: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center">
						<P><asp:label id="Label1" runat="server" Width="204px" ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana"
								BackColor="White" Font-Bold="True">PURCHASE ORDER DETAILS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 296px" align="center">
						<P>
							<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 276px" cellSpacing="1" cellPadding="1" width="100%"
								align="center" bgColor="#f0f8ff" border="1" borderColor="#b0c4de">
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 27px" vAlign="baseline" align="left"><asp:label id="lblCasNo" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Case Number</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 27px"><asp:label id="Label2" runat="server" Width="112px" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True"></asp:label></TD>
									<TD style="WIDTH: 20%; HEIGHT: 27px" vAlign="middle" align="left"><asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">PO Date</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 27px"><asp:label id="lblPODT" runat="server" Width="112px" ForeColor="OrangeRed" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True"></asp:label><asp:textbox id="txtPODT" style="TEXT-ALIGN: right" tabIndex="6" runat="server" Width="1px" BackColor="AliceBlue"
											Height="1px" MaxLength="14" BorderColor="AliceBlue"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 40px"><asp:label id="lblItemSLNo" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Item Serial No.</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 40px"><asp:textbox id="txtItemSLNo" runat="server" Width="150px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" Visible="False"></asp:textbox><asp:label id="Label3" runat="server" Width="112px" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True"></asp:label></TD>
									<TD style="WIDTH: 20%; HEIGHT: 40px"><asp:label id="lblItemDescpt" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Item Description</asp:label></TD>
									<TD style="HEIGHT: 30%"><asp:textbox id="txtItemDescpt" tabIndex="1" runat="server" Width="100%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="50px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 30px"><asp:label id="lblConsigneeCD" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True"> Consignee</asp:label></TD>
									<TD style="WIDTH: 100%; HEIGHT: 19px" colSpan="3"><asp:dropdownlist id="ddlConsigneeCD" tabIndex="2" runat="server" Width="100%" ForeColor="DarkBlue"
											Font-Size="7pt" Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 19px"><asp:label id="lblQty" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Quantity</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 19px"><asp:textbox id="txtQty" style="TEXT-ALIGN: right" tabIndex="3" runat="server" Width="50%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="12"></asp:textbox></TD>
									<TD style="WIDTH: 20%; HEIGHT: 19px"><asp:label id="lblUMOCode" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True"> Unit Of Measurment</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 19px"><asp:dropdownlist id="ddlUOMCode" tabIndex="4" runat="server" Width="240px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px" AutoPostBack="True"></asp:dropdownlist><asp:textbox id="txtUOMFactor" tabIndex="25" runat="server" Width="1px" ForeColor="AliceBlue"
											Font-Size="8pt" Font-Names="Verdana" BackColor="AliceBlue" MaxLength="10" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 25px"><asp:label id="lblRate" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Rate</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px"><asp:textbox id="txtRate" onblur="basevalue();" style="TEXT-ALIGN: right" tabIndex="5" runat="server"
											Width="50%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="12"></asp:textbox></TD>
									<TD style="WIDTH: 20%; HEIGHT: 25px"><asp:label id="lblBsValue" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Base Value</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px">
										<P><asp:textbox id="txtBaseValue" onblur="basevalue();" style="TEXT-ALIGN: right" tabIndex="6" runat="server"
												Width="50%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="14"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 13px"><asp:label id="lblDiscountPercentage" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True"> Discount Type</asp:label></TD>
									<TD style="WIDTH: 30%; FONT-FAMILY: Verdana; HEIGHT: 13px; COLOR: darkblue; FONT-SIZE: 8pt; FONT-WEIGHT: bold"><asp:dropdownlist id="ddlDiscountType" tabIndex="7" runat="server" Width="42%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="25px">
											<asp:ListItem Selected="True"></asp:ListItem>
											<asp:ListItem Value="P">Percentage</asp:ListItem>
											<asp:ListItem Value="L">Lumpsum</asp:ListItem>
											<asp:ListItem Value="N">Per No.</asp:ListItem>
										</asp:dropdownlist>Value&nbsp;
										<asp:textbox id="txtDiscountPer" onblur="discountype();" style="TEXT-ALIGN: right" tabIndex="8"
											runat="server" Width="35%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px"
											MaxLength="10"></asp:textbox></TD>
									<TD style="WIDTH: 20%; HEIGHT: 13px"><asp:label id="lblDiscountAmt" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True"> Discount</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 13px"><asp:textbox id="txtDiscountAmt" onblur="discountype();" style="TEXT-ALIGN: right" tabIndex="9"
											runat="server" Width="50%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%"><asp:label id="lblExcisePr" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True"> Excise Type</asp:label></TD>
									<TD style="WIDTH: 30%">
										<P style="FONT-FAMILY: Verdana; COLOR: darkblue; FONT-SIZE: 8pt; FONT-WEIGHT: bold"><asp:dropdownlist id="ddlExciseType" tabIndex="10" runat="server" Width="42%" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Height="25px">
												<asp:ListItem Selected="True"></asp:ListItem>
												<asp:ListItem Value="P">Percentage</asp:ListItem>
												<asp:ListItem Value="L">Lumpsum</asp:ListItem>
											</asp:dropdownlist>Value&nbsp;
											<asp:textbox id="txtExcise" onblur="excise();" style="TEXT-ALIGN: right" tabIndex="11" runat="server"
												Width="35%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 20%"><asp:label id="lblExciseAmt" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Excise</asp:label></TD>
									<TD style="WIDTH: 30%">
										<P><asp:textbox id="txtExciseAmt" onblur="excise();" style="TEXT-ALIGN: right" tabIndex="12" runat="server"
												Width="50%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 25px"><asp:label id="lblSaleTaxPr" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Sale Tax(%)</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px">
										<P><asp:textbox id="txtSaleTaxPre" onblur="saletax();" style="TEXT-ALIGN: right" tabIndex="13" runat="server"
												Width="50%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="5"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 20%; HEIGHT: 25px"><asp:label id="lblSaleTaxAmt" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True"> Sale Tax</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px">
										<P><asp:textbox id="txtSaleTaxAmt" onblur="saletax();" style="TEXT-ALIGN: right" tabIndex="14" runat="server"
												Width="50%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 2px"><asp:label id="lblOtherCharges" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Other Charges Type</asp:label></TD>
									<TD style="FONT-FAMILY: Verdana; COLOR: darkblue; FONT-SIZE: 8pt; FONT-WEIGHT: bold"><asp:dropdownlist id="ddlOCType" tabIndex="15" runat="server" Width="42%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px">
											<asp:ListItem Selected="True"></asp:ListItem>
											<asp:ListItem Value="P">Percentage</asp:ListItem>
											<asp:ListItem Value="L">Lumpsum</asp:ListItem>
											<asp:ListItem Value="N">Per No.</asp:ListItem>
										</asp:dropdownlist>Value&nbsp;
										<asp:textbox id="txtOtherCharges" onblur="othercharges();" style="TEXT-ALIGN: right" tabIndex="16"
											runat="server" Width="35%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px"
											MaxLength="11"></asp:textbox></TD>
									<TD style="WIDTH: 20%; HEIGHT: 2px"><asp:label id="Label5" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Other Charges (AMT)</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 2px"><asp:textbox id="txtOtherChargesAmt" onblur="saletax();" style="TEXT-ALIGN: right" tabIndex="17"
											runat="server" Width="50%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 2px"></TD>
									<TD style="FONT-FAMILY: Verdana; COLOR: darkblue; FONT-SIZE: 8pt; FONT-WEIGHT: bold"
										align="right"></TD>
									<TD style="WIDTH: 20%; HEIGHT: 2px"><asp:label id="lblValue" runat="server" Width="80px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Total Value</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 2px"><asp:textbox id="txtValue" style="TEXT-ALIGN: right" onfocus="total();" tabIndex="18" runat="server"
											Width="50%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="16"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%"><asp:label id="lblDelvDate" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Delivery Date</asp:label></TD>
									<TD style="WIDTH: 30%">
										<P><asp:textbox id="txtDelvDate" onblur="cpy();" tabIndex="19" runat="server" Width="40%" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 20%"><asp:label id="tlblExtDelvDate" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Extended Delivery Date</asp:label></TD>
									<TD style="WIDTH: 30%">
										<P><asp:textbox id="txtExtDelvDate" onblur="check_date(txtExtDelvDate);compareDates(txtDelvDate,txtExtDelvDate,'Extended Delivery Date Cannot Be Less Then Delivery Date');"
												tabIndex="20" runat="server" Width="35%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Height="20px" MaxLength="10"></asp:textbox><asp:label id="lblOldConCD" runat="server" Width="12px" ForeColor="OrangeRed" Font-Size="8pt"
												Font-Names="Verdana" Font-Bold="True" Visible="False"></asp:label></P>
									</TD>
								</TR>
							</TABLE>
							<asp:label style="Z-INDEX: 0" id="Label6" runat="server" Font-Bold="True" Font-Names="Verdana"
								Font-Size="8pt" ForeColor="DarkMagenta" Width="100%">To Search a Item-> Select Consignee or Enter Some Search Criteria in Item Description & Click on Search Button, And To See All Items Again Click on Show All Button</asp:label>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px" align="center"><asp:button id="btnAdd" tabIndex="21" runat="server" Width="58px" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Font-Bold="True" Visible="False" Text="Add"></asp:button><asp:button id="btnSave" tabIndex="22" runat="server" Width="61px" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Font-Bold="True" Text="Save"></asp:button><asp:button id="btnDelete" tabIndex="23" runat="server" Width="58px" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Font-Bold="True" Visible="False" Text="Delete"></asp:button><asp:button id="btnCancel" tabIndex="24" runat="server" Width="58px" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Font-Bold="True" Text="Cancel" style="Z-INDEX: 0"></asp:button>
						<asp:button style="Z-INDEX: 0" id="btnSearch" tabIndex="25" runat="server" Font-Bold="True"
							Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="58px" Text="Search"></asp:button>
						<asp:button style="Z-INDEX: 0" id="btnShowAll" tabIndex="26" runat="server" Font-Bold="True"
							Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="66px" Text="Show All"></asp:button></TD>
					</TD></TR>
				<TR>
					<TD align="center"><asp:datagrid id="DgPO" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" Height="96px"
							BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False" PageSize="5">
							<AlternatingItemStyle HorizontalAlign="Center" BackColor="#CCCCFF"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
								BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Item Sl. No.">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" NavigateUrl='<%#"PurchesOrderDetails.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;ITEM_SRNO=" + DataBinder.Eval(Container.DataItem,"ITEM_SRNO") +"&amp;type="+ptype+"&amp;PODT="+PODT %>' Runat="server" Text=' <%# DataBinder.Eval(Container.DataItem,"ITEM_SRNO")%>'>
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
