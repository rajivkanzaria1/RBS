﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Call_Register_Edit.ascx.cs" Inherits="RBS.Vendor.Call_Register_Edit" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl_Vend" Src="WebUserControl_Vend.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Call_Register_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="../date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtCaseNo.value)=="")
		{
		 alert("CASE NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtDtOfReciept.value)=="")
		 {
		 alert("CALL DATE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCSNO.value)=="")
		 {
		 alert("CALL SNO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(isNaN(parseInt(trimAll(document.Form1.txtCSNO.value))))
		{
		 alert("CALL SNO. CONTAINS INVALID CHARACTERS!!!");
		 event.returnValue=false;
		}
		else if(trimAll(document.Form1.txtCaseNo.value)!="" && trimAll(document.Form1.txtCaseNo.value).length < 9)
		 {
			alert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
			event.returnValue=false;
		 }
		else
		return;
		}
		
		function makeUppercase()
		 {
			document.Form1.txtCaseNo.value = document.Form1.txtCaseNo.value.toUpperCase();
			
		 }
		 
		function validate1()
		{
		
		if(trimAll(document.Form1.txtCaseNo.value)=="" && trimAll(document.Form1.txtDtOfReciept.value)=="" && trimAll(document.Form1.txtPONO.value).length < 3 && trimAll(document.Form1.txtPODT.value)=="" && trimAll(document.Form1.txtVendName.value).length<3 && trimAll(document.Form1.txtCallLetNo.value)=="")
		{
		 alert("Enter CASE NO. or CALL DATE or Atleast 3 Digits of PO No. OR PO DATE OR First Few Characters Of Vendor Name OR Call Letter No. to search the Records");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCaseNo.value).length < 9 && trimAll(document.Form1.txtCaseNo.value)!="")
		 {
		 alert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
		 event.returnValue=false;
		 }
		else 
		return;
		}
		
		function validate2()
		{
		if(trimAll(document.Form1.txtPONO.value).length < 3 && trimAll(document.Form1.txtPODT.value)=="")
		{
		 alert("Enter Atleast 3 Digits of PO No. OR PO DATE to search the Records ");
		 event.returnValue=false;
		 }
		 
		else 
		return;
			
		}
		
		function abc()
		 {
		 
		 document.Form1.txtCaseNo.focus();
		 }
		 
		 function validate3()
		{
		if(trimAll(document.Form1.txtCaseNo.value)=="")
		{
		 alert("CASE NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCaseNo.value)!="" && trimAll(document.Form1.txtCaseNo.value).length < 9)
		 {
			alert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtDtOfReciept.value)=="")
		 {
		 alert("DATE OF RECIEPT IN RITES CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else 
		return;
		}
        </script>
	</HEAD>
	<BODY bgColor="white" onload="abc();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol_vend id="WebUserControl_Vend1" runat="server"></uc1:webusercontrol_vend></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue" Width="80%">REGISTERED PENDING CALLS OFFERED QUANTITY ENHANCEMENT FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 50%" align="center">
						<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 70%" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD>
									<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 100%" borderColor="#b0c4de" cellSpacing="0"
										cellPadding="0" width="259" bgColor="aliceblue" border="1">
										<TR>
											<TD style="HEIGHT: 36px" align="right"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="61px">Case No.</asp:label></TD>
											<TD style="HEIGHT: 36px"><asp:textbox id="txtCaseNo" onblur="makeUppercase();" tabIndex="1" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="150px" Height="20px" MaxLength="9"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 36px" align="right"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="105px">Call Date</asp:label></TD>
											<TD style="HEIGHT: 36px"><asp:textbox id="txtDtOfReciept" onblur="check_date(txtDtOfReciept);" tabIndex="2" runat="server"
													Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="150px" Height="20px" MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 36px" align="right"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="105px">Call SNo.</asp:label></TD>
											<TD style="HEIGHT: 36px"><asp:textbox id="txtCSNO" onblur="check_date(txtDtOfReciept);" tabIndex="3" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="50px" Height="20px" MaxLength="5"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 50%">
									<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 100%" borderColor="#b0c4de" cellSpacing="0"
										cellPadding="0" width="340" bgColor="aliceblue" border="1">
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 36px" align="right"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="61px">PO No.</asp:label></TD>
											<TD style="WIDTH: 70%"><asp:textbox id="txtPONO" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%" Height="20px" MaxLength="45"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 36px" align="right"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="60px">PO Date</asp:label></TD>
											<TD style="WIDTH: 70%"><asp:textbox id="txtPODT" onblur="check_date(txtPODT);" tabIndex="5" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="40%" Height="20px" MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 36px" align="right"><asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%"> Vendor Name</asp:label></TD>
											<TD style="WIDTH: 70%"><asp:textbox id="txtVendName" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Width="100%" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 36px" align="right"><asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%"> Call Letter No./Dispatch Ref No.</asp:label></TD>
											<TD style="WIDTH: 70%"><asp:textbox id="txtCallLetNo" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Width="60%" Height="20px" MaxLength="30"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkMagenta" Width="100%">To Search a Case-> Enter Case No. or Call Date or Part or Full PO No. or PO DT or Vendor Name or Call Letter No./Dispatch Ref No. and Click on Search Button</asp:label><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkMagenta" Width="100%">To Edit Call --> Enter Case No, Call Date * Call SNo and then Click on Modify Button</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center"><asp:button id="btnMod" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="67px" Text="Modify"></asp:button><asp:button id="btnSearch" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Width="65px" Text="Search"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px">
						<P align="center"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed" Width="384px" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<DIV><TITTLE:CUSTOMDATAGRID id="grdCNO" runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="400px"
								AutoGenerateColumns="False" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" BorderColor="DarkBlue"
								AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" CellPadding="2" FreezeRows="0" PageSize="15">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
									CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Select">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"Call_Register_Edit.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;CALL_RECV_DT=" + DataBinder.Eval(Container.DataItem,"CALL_RECV_DT")+ "&amp;CALL_SNO=" + DataBinder.Eval(Container.DataItem,"CALL_SNO")%>'>Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
										<HeaderStyle Width="7%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PO_NO" HeaderText="PO No.">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PO_DT" HeaderText="PO Date">
										<HeaderStyle Width="7%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_RECV_DT" HeaderText="Call Date">
										<HeaderStyle Width="7%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_SNO" HeaderText="Call SNo.">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_INSTALL_NO" HeaderText="Call Install No.">
										<HeaderStyle Width="7%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IE_SNAME" HeaderText="IE SName">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VENDOR" HeaderText="Vendor">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_STATUS" HeaderText="Status">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_LETTER_NO" HeaderText="Call Letter No/Dispatch Ref No.">
										<HeaderStyle Width="7%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REMARKS" HeaderText="Remarks">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></TD></TR></TABLE></form>
	</BODY>
</HTML>

