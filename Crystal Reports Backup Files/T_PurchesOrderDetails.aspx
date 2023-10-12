<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T_PurchesOrderDetails.aspx.cs" Inherits="RBS.T_PurchesOrderDetails.T_PurchesOrderDetails" %>

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
				document.Form1.txtExtDelvDate.value=document.Form1.txtDelvDate.value;
			}
		}
		
		function basevalue()
		{
			var qty;
			var rate;
			if(document.Form1.txtQty.value=="")
			{
				qty=0;
			}
			else
			{
				qty=parseFloat(document.Form1.txtQty.value);
			}
			if(document.Form1.txtRate.value=="")
			{
			rate=0;
			}
			else
			{
				 rate=parseFloat(document.Form1.txtRate.value);
			}
			var uom=parseFloat(document.Form1.txtUOMFactor.value);
			var basevlue=(qty*rate*uom);
			document.Form1.txtBaseValue.value=Math.round(basevlue*100)/100;
		}
		function saletax()
		{
			if(document.Form1.txtSaleTaxPre.value!="")
			{
			if(document.Form1.txtDiscountAmt.value!="")
			{
			var discountypeper=parseFloat(document.Form1.txtDiscountAmt.value);
			}
			else
			{
			var discountypeper=0;
			}
			
			if(document.Form1.txtExciseAmt.value!="")
			{
			var excise=parseFloat(document.Form1.txtExciseAmt.value);
			}
			else
			{
			var excise=0;
			}
			var stper=parseFloat(document.Form1.txtSaleTaxPre.value);
			var basevalue=parseFloat(document.Form1.txtBaseValue.value);
			var stamount=((basevalue-discountypeper)+ (excise))* stper/100;
			document.Form1.txtSaleTaxAmt.value=Math.round(stamount*100)/100; 
			}
		}
		function excise()
		{
			if(document.Form1.txtExcise.value!="")
			{
			if(document.Form1.txtDiscountAmt.value!="")
			{
			var discountypeper=parseFloat(document.Form1.txtDiscountAmt.value);
			}
			else
			{
			var discountypeper=0;
			}
			var exciseper=parseFloat(document.Form1.txtExcise.value);
			var basevalue=parseFloat(document.Form1.txtBaseValue.value);
			var exciseamount=((basevalue-discountypeper)*(exciseper))/100;
			document.Form1.txtExciseAmt.value=Math.round(exciseamount*100)/100; 
			}
		}
		function discountype()
		{
			if(document.Form1.txtDiscountPer.value!="")
			{
			var discountypeper=parseFloat(document.Form1.txtDiscountPer.value);
			var basevalue=parseFloat(document.Form1.txtBaseValue.value);
			var discountamount=((basevalue)*(discountypeper))/100;
			document.Form1.txtDiscountAmt.value=Math.round(discountamount*100)/100; 
			}
		}
		function total()
		{
			var basevalue=parseFloat(document.Form1.txtBaseValue.value);
			var saletaxamt;
			var exciseamt;
			var discountamt;
			var othercharges;
			if(document.Form1.txtSaleTaxAmt.value=="")
			{
			saletaxamt=0;
			}
			else
			{
			saletaxamt=parseFloat(document.Form1.txtSaleTaxAmt.value);
			}
			if(document.Form1.txtExciseAmt.value=="")
			{
			exciseamt=0;
			}
			else
			{
			 exciseamt=parseFloat(document.Form1.txtExciseAmt.value);
		    }
			 if(document.Form1.txtDiscountAmt.value=="")
			 {
			 discountamt=0;
			 }
			 else
			 {
			  discountamt=parseFloat(document.Form1.txtDiscountAmt.value);
			  }
			  if(document.Form1.txtOtherCharges.value=="")
			  {
			  othercharges=0;
			  }
			  else
			  {
			   othercharges=parseFloat(document.Form1.txtOtherCharges.value);
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
		if(document.Form1.txtValue.value=="")
		{
		total();
		}
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
								Font-Size="10pt" ForeColor="DarkBlue" Width="204px">PURCHASE ORDER DETAILS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 296px" align="center">
						<P>
							<TABLE id="Table2" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" width="100%" align="center"
								bgColor="#f0f8ff" border="0">
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 27px" vAlign="baseline" align="left"><asp:label id="lblCasNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Case Number</asp:label></TD>
									<TD style="WIDTH: 32.75%; HEIGHT: 27px"><asp:label id="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="112px"></asp:label></TD>
									<TD style="WIDTH: 6.1%"></TD>
									<TD style="WIDTH: 13.96%"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%" vAlign="baseline" align="left"></TD>
									<TD style="WIDTH: 10.31%; HEIGHT: 27px"></TD>
									<TD style="WIDTH: 15%; HEIGHT: 30px"><asp:label id="lblConsigneeCD" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%"> Consignee</asp:label></TD>
									<TD style="WIDTH: 100%; HEIGHT: 19px"><asp:dropdownlist id="ddlConsigneeCD" tabIndex="2" runat="server" Width="80%" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%" vAlign="baseline" align="center" colSpan="4">
										<asp:button id="btnCReg" tabIndex="20" runat="server" Font-Bold="True" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="104px" Text="Register Call" onclick="btnCReg_Click"></asp:button></TD>
								</TR>
							</TABLE>
							<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 276px" cellSpacing="1" cellPadding="1" width="100%"
								align="center" bgColor="#f0f8ff" border="0">
								<TR>
									<TD style="WIDTH: 10%; HEIGHT: 49px"><asp:label id="lblItemSLNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Item Serial No.</asp:label></TD>
									<TD style="WIDTH: 0%; HEIGHT: 49px"><asp:textbox id="txtItemSLNo" runat="server" ForeColor="Black" Width="48px" Visible="False" Height="20px"></asp:textbox><asp:label id="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="OrangeRed" Width="112px"></asp:label></TD>
									<TD style="WIDTH: 6%; HEIGHT: 49px"><asp:label id="lblUMOCode" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">UOM</asp:label></TD>
									<TD style="WIDTH: 5.94%; HEIGHT: 49px"><asp:dropdownlist id="ddlUOMCode" tabIndex="4" runat="server" Width="100%" Height="25px" AutoPostBack="True" onselectedindexchanged="ddlUOMCode_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="txtUOMFactor" tabIndex="25" runat="server" BackColor="AliceBlue" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="AliceBlue" Width="1px" MaxLength="10" BorderStyle="None"></asp:textbox></TD>
									<TD style="WIDTH: 6%; HEIGHT: 49px"><asp:label id="lblItemDescpt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Item Description</asp:label></TD>
									<TD style="HEIGHT: 18.12%" colSpan="3"><asp:textbox id="txtItemDescpt" tabIndex="1" runat="server" Width="100%" Height="50px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 19px"><asp:label id="lblQty" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Quantity</asp:label></TD>
									<TD style="WIDTH: 0%; HEIGHT: 19px"><asp:label id="lblRate" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Rate</asp:label></TD>
									<TD style="WIDTH: 14.33%; HEIGHT: 19px"><asp:label id="lblBsValue" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Base Value</asp:label></TD>
									<TD style="WIDTH: 13.96%; HEIGHT: 19px"><asp:label id="lblExcisePr" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Excise(%)</asp:label></TD>
									<TD style="WIDTH: 14.04%; HEIGHT: 19px"><asp:label id="lblExciseAmt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Excise(Amount)</asp:label></TD>
									<TD style="WIDTH: 14.87%; HEIGHT: 19px">
										<P><asp:label id="lblSaleTaxPr" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="100%">Sale Tax(%)</asp:label></P>
									</TD>
									<TD style="WIDTH: 15%">
										<P><asp:label id="lblSaleTaxAmt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="100%">Sale Tax (Amount)</asp:label></P>
									</TD>
									<TD style="WIDTH: 15%">
										<P><asp:label id="lblValue" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="100%">Total Value</asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 25px"><asp:textbox id="txtQty" style="TEXT-ALIGN: right" tabIndex="3" runat="server" Width="50%" Height="20px"
											MaxLength="11"></asp:textbox></TD>
									<TD style="WIDTH: 0%; HEIGHT: 25px"><asp:textbox id="txtRate" onblur="basevalue();" style="TEXT-ALIGN: right" tabIndex="5" runat="server"
											Width="100%" Height="20px" MaxLength="12"></asp:textbox></TD>
									<TD style="WIDTH: 6.1%; HEIGHT: 25px">
										<P><asp:textbox id="txtBaseValue" style="TEXT-ALIGN: right" tabIndex="6" runat="server" Width="100%"
												Height="20px" MaxLength="14"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 13.96%; HEIGHT: 25px">
										<P><asp:textbox id="txtExcise" onblur="excise();" style="TEXT-ALIGN: right" tabIndex="9" runat="server"
												Width="50%" Height="20px" MaxLength="5"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 5.95%">
										<P><asp:textbox id="txtExciseAmt" style="TEXT-ALIGN: right" tabIndex="10" runat="server" Width="100%"
												Height="20px" MaxLength="11"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 14.87%">
										<P><asp:textbox id="txtSaleTaxPre" onblur="saletax();" style="TEXT-ALIGN: right" tabIndex="11" runat="server"
												Width="50%" Height="20px" MaxLength="5"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 15%">
										<P><asp:textbox id="txtSaleTaxAmt" style="TEXT-ALIGN: right" tabIndex="12" runat="server" Width="100%"
												Height="20px" MaxLength="11"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 15%">
										<P><asp:textbox id="txtValue" style="TEXT-ALIGN: right" onfocus="total();" tabIndex="14" runat="server"
												Width="100%" Height="20px" MaxLength="16"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">
										<P><asp:label id="Label5" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="100%">Qty Ordered</asp:label></P>
									</TD>
									<TD style="WIDTH: 0%">
										<P><asp:label id="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="100%">Cumm. Qty off Prev</asp:label></P>
									</TD>
									<TD style="WIDTH: 6.1%"><asp:label id="Label11" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Qty Prev Passed</asp:label></TD>
									<TD style="WIDTH: 13.96%">
										<P><asp:label id="Label9" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="100%">Qty to be Inspected</asp:label></P>
									</TD>
									<TD style="WIDTH: 5.95%"><asp:label id="Label6" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Qty Passed</asp:label></TD>
									<TD style="WIDTH: 14.87%">
										<P><asp:label id="Label8" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="100%">Qty Rejected</asp:label></P>
									</TD>
									<TD style="WIDTH: 15%"><asp:label id="Label12" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Qty Due</asp:label></TD>
									<TD style="WIDTH: 15%"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 31px">
										<P>
											<asp:textbox id="txtQOrd" style="TEXT-ALIGN: right" tabIndex="2" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 0%; HEIGHT: 31px">
										<P>
											<asp:textbox id="txtCQty" style="TEXT-ALIGN: right" tabIndex="3" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 6.1%; HEIGHT: 31px"><asp:textbox id="txtQPrePassed" style="TEXT-ALIGN: right" tabIndex="4" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></TD>
									<TD style="WIDTH: 13.96%; HEIGHT: 31px">
										<P><asp:textbox id="txtQuanInsp" style="TEXT-ALIGN: right" tabIndex="5" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 5.95%; HEIGHT: 31px"><asp:textbox id="txtQPass" style="TEXT-ALIGN: right" tabIndex="4" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></TD>
									<TD style="WIDTH: 14.87%; HEIGHT: 31px">
										<P><asp:textbox id="txtQRej" style="TEXT-ALIGN: right" tabIndex="4" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></P>
									</TD>
									<TD style="WIDTH: 15%; HEIGHT: 31px"><asp:textbox id="txtQDue" style="TEXT-ALIGN: right" tabIndex="4" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></TD>
									<TD style="WIDTH: 15%; HEIGHT: 31px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"></TD>
									<TD style="WIDTH: 0%"></TD>
									<TD style="WIDTH: 6.1%"></TD>
									<TD style="WIDTH: 13.96%"></TD>
									<TD style="WIDTH: 15%"></TD>
									<TD style="WIDTH: 6.34%"></TD>
									<TD style="WIDTH: 15%">
										<P>&nbsp;</P>
									</TD>
									<TD style="WIDTH: 15%"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"></TD>
									<TD style="WIDTH: 0%">
										<P>&nbsp;</P>
									</TD>
									<TD style="WIDTH: 6.1%"></TD>
									<TD style="WIDTH: 13.96%">
										<P>&nbsp;</P>
									</TD>
									<TD style="WIDTH: 5.95%"></TD>
									<TD style="WIDTH: 14.87%">
										<P>&nbsp;</P>
									</TD>
									<TD style="WIDTH: 15%">
										<P>&nbsp;</P>
									</TD>
									<TD style="WIDTH: 15%"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"></TD>
									<TD style="WIDTH: 0%">
										<P>&nbsp;</P>
									</TD>
									<TD style="WIDTH: 6.1%"></TD>
									<TD style="WIDTH: 13.96%">
										<P>&nbsp;</P>
									</TD>
									<TD style="WIDTH: 15%"></TD>
									<TD style="WIDTH: 6.34%"></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center">
						<asp:button id="btnAdd" tabIndex="19" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Width="58px" Visible="False" Text="Add" onclick="btnAdd_Click"></asp:button>
						<asp:button id="btnSave" tabIndex="20" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="61px" Text="Save" onclick="btnSave_Click"></asp:button>
						<asp:button id="btnDelete" tabIndex="21" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="58px" Visible="False" Text="Delete" onclick="btnDelete_Click"></asp:button>
						<asp:button id="btnCancel" tabIndex="22" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="58px" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
					</TD></TR>
				<TR>
					<TD align="center">
						<asp:datagrid id="DgPO" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" Height="96px"
							BorderStyle="Groove" PageSize="5" BorderColor="DarkBlue" AutoGenerateColumns="False">
							<AlternatingItemStyle HorizontalAlign="Center" BackColor="#CCCCFF"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
								BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Item Sl. No.">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink2" NavigateUrl='<%#"T_PurchesOrderDetails.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;ITEM_SRNO=" + DataBinder.Eval(Container.DataItem,"ITEM_SRNO") +"&amp;type="+ptype %>' Runat="server" Text=' <%# DataBinder.Eval(Container.DataItem,"ITEM_SRNO")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="CASE_NO" HeaderText="Case Number">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ITEM_SRNO" HeaderText="Item Sl. No.">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ITEM_DESC" HeaderText="Item description">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CONSIGNEE_NAME" HeaderText="Consignee">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="QTY" HeaderText="Quantity">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BASIC_VALUE" HeaderText="Base Value">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="VALUE" HeaderText="Total Value">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
