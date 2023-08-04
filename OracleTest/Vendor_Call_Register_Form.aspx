<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendor_Call_Register_Form.aspx.cs" Inherits="RBS.Vendor_Call_Register_Form.Vendor_Call_Register_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl_Vend" Src="WebUserControl_Vend.ascx" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
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
		if(document.Form1.txtCInstallNo.value!="" && IsNumeric(document.Form1.txtCInstallNo.value) == false)
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
					<TD>
						<P align="center"><uc1:webusercontrol_vend id="WebUserControl_Vend1" runat="server"></uc1:webusercontrol_vend></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px">
						<P align="center"><asp:label id="Label1" runat="server" Width="252px" Font-Names="Verdana" Font-Size="10pt" BackColor="White"
								Font-Bold="True" ForeColor="DarkBlue">VENDOR CALL REGISTRATION</asp:label></P>
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
													ForeColor="DarkBlue"> Case No.</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 35px" width="173"><asp:textbox id="txtCaseNo" tabIndex="41" runat="server" Width="150px" Font-Names="Verdana" Font-Size="8pt"
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
													ForeColor="OrangeRed"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 22px" width="181"><asp:label id="Label8" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Call Status</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 22px" width="173"><asp:label id="txtCallStatus" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="OrangeRed"></asp:label></TD>
											<TD style="HEIGHT: 22px" align="left" width="20%"><asp:label id="Label13" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Region</asp:label></TD>
											<TD style="HEIGHT: 22px" align="left" width="30%"><asp:label id="Label31" runat="server" Width="69px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 20px" width="181"><asp:label id="Label2" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue"> Date of Mark of call to IE</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 20px" width="173"><asp:textbox id="txtDtMark" onblur="check_date(txtDtMark);compareDates(txtDtOfReciept,txtDtMark,'Call Mark Date Cannot Be Less then Call Date');abc();"
													tabIndex="43" runat="server" Width="80px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="10"></asp:textbox></TD>
											<TD style="HEIGHT: 20px" align="left" width="20%"><asp:label id="Label23" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue"> Call Status date</asp:label></TD>
											<TD style="HEIGHT: 20px" align="left" width="30%"><asp:textbox id="txtDtOfCan" onblur="check_date(txtDtOfCan);compareDates(txtDtOfReciept,txtDtOfCan,'Call Status Date Cannot Be Less then Call Date');"
													tabIndex="42" runat="server" Width="80px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 35px" width="181">
												<asp:label id="Label12" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Call Install No.</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 35px" width="173">
												<asp:textbox id="txtCInstallNo" tabIndex="1" runat="server" Width="30%" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Height="25px" MaxLength="4"></asp:textbox></TD>
											<TD id="TD1" style="HEIGHT: 35px" align="left" width="20%" runat="server">
												<asp:label id="Label9" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue"> Expected Date of Inspection/Material Readiness Date.</asp:label></TD>
											<TD style="HEIGHT: 35px" align="left" width="30%">
												<asp:textbox id="txtExpOfIns" onblur="check_date(txtExpOfIns);insp_date();" tabIndex="2" runat="server"
													Width="80px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="10"
													onchange=""></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 24px" width="181">
												<asp:label id="Label18" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Call Letter Number\ Dispatch Reference No.</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 24px" width="173">
												<asp:textbox id="txtCallNO" tabIndex="3" runat="server" Width="80%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="25"></asp:textbox></TD>
											<TD style="HEIGHT: 24px" align="left" width="20%">
												<asp:label id="Label4" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Call Letter Date (DD/MM/YYYY)</asp:label></TD>
											<TD style="HEIGHT: 24px" align="left" width="30%">
												<asp:textbox id="txtCallDt" onblur="check_date(txtCallDt);compareDates(txtCallDt,txtDtOfReciept,'Call Letter Date Cannot Be Greater then Date Of Reciept In Rites');"
													tabIndex="4" runat="server" Width="80px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Height="20px" MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 21px" width="181"><asp:label id="Label7" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Visible="False">Inspecting Engineer to whom Call is marked</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 21px" width="173">
												<asp:dropdownlist id="lstIE" tabIndex="6" runat="server" Width="150px" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="25px" Visible="False"></asp:dropdownlist>
												<asp:label id="lblIE" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Visible="False"></asp:label></TD>
											<TD style="HEIGHT: 21px" align="left" width="20%">
												<asp:label id="Label30" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Visible="False">Call Re-Mark Status(If Call has been Re-marked)</asp:label></TD>
											<TD style="HEIGHT: 21px" align="left" width="30%">
												<asp:dropdownlist id="lstCallRStatus" tabIndex="5" runat="server" Width="150px" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Height="25px" Visible="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 24px" width="181">
												<asp:label id="Label32" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Remarks</asp:label></TD>
											<TD style="HEIGHT: 24px" width="30%" colSpan="3">
												<asp:textbox id="txtRemarks" tabIndex="7" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 24px" width="181">
												<asp:label id="Label26" runat="server" Width="200px" Font-Names="Verdana" Font-Size="10pt"
													Font-Bold="True" ForeColor="RoyalBlue" Font-Underline="True">Manufacturer's Information</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 24px" width="173">
												<asp:checkbox id="chkManuf" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" AutoPostBack="True" Text="Same As Vendor"></asp:checkbox></TD>
											<TD style="HEIGHT: 24px" align="left" width="20%"></TD>
											<TD style="HEIGHT: 24px" align="right" width="30%">
												<asp:label id="lblCUpdateStatus" runat="server" Width="184px" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="OrangeRed" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 45px" width="181">
												<asp:label id="Label10" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Name of Manufacturer</asp:label></TD>
											<TD style="HEIGHT: 45px" width="30%" colSpan="3">
												<asp:textbox id="txtMName" tabIndex="12" runat="server" Width="20%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="50"></asp:textbox>
												<asp:button id="btnFCList" tabIndex="13" runat="server" Width="30%" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="DarkBlue" Height="19px" Text="Select Manufacturer" ToolTip="Enter the Manufacturer Code or 1st few letters of Manufacturer Name then click on select Vendor Button"></asp:button>
												<asp:dropdownlist onkeypress="return keySort(ddlManufac);" id="ddlManufac" tabIndex="14" runat="server"
													Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="25px" Visible="False"
													AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 41px" width="181">
												<asp:label id="Label24" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Place of Inspection</asp:label></TD>
											<TD style="HEIGHT: 41px" width="30%" colSpan="3">
												<asp:textbox id="txtMPOI" tabIndex="15" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="40px" MaxLength="30" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px; HEIGHT: 25px" width="181">
												<asp:label id="Label11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Contact  Person's Name</asp:label></TD>
											<TD style="WIDTH: 173px; HEIGHT: 25px" width="173">
												<asp:textbox id="txtMConPer" tabIndex="16" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="30"></asp:textbox></TD>
											<TD style="HEIGHT: 25px" width="20%">
												<asp:label id="Label33" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Manufacturer Email</asp:label></TD>
											<TD style="HEIGHT: 25px" align="left" width="30%">
												<asp:textbox id="txtMEmail" tabIndex="17" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 181px" width="181">
												<asp:label id="label20" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue">Phone No.</asp:label></TD>
											<TD style="WIDTH: 173px" width="173">
												<asp:textbox id="txtMPNo" tabIndex="18" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Height="20px" MaxLength="30"></asp:textbox></TD>
											<TD width="30%" colSpan="2">
												<asp:button id="btnUManuf" tabIndex="22" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="DarkBlue" Height="22px" Text="Update Manufacturer's Contact Details."
													ToolTip="If you want to Change Manufacturer's Contact Person and Tel No. then Change The Values and Click on button"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:button id="btnSave" tabIndex="19" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Text="Save"></asp:button>
									<asp:button id="btnDelete" tabIndex="20" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Text="Delete"></asp:button>
									<asp:button id="btnCancel" tabIndex="21" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Text="Cancel"></asp:button></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 203px" align="center">
									<DIV>
										<TITTLE:CUSTOMDATAGRID id="grdCDetails" tabIndex="20" runat="server" Width="100%" Font-Names="Verdana"
											Font-Size="8pt" BackColor="White" BorderStyle="Groove" FreezeColumns="0" UseAccessibleHeader="True"
											CssClass="Grid" AddEmptyHeaders="0" BorderWidth="1px" FreezeHeader="True" GridHeight="200px" FreezeRows="0"
											AutoGenerateColumns="False" BorderColor="Navy" OnCancelCommand="grdCDetails_Cancel" OnUpdateCommand="grdCDetails_Update"
											OnEditCommand="grdCDetails_Edit" CellPadding="2" PageSize="1">
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
											</Columns>
										</TITTLE:CUSTOMDATAGRID></DIV>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
