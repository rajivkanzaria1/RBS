<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Register_Edit.aspx.cs" Inherits="RBS.Call_Register_Edit" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE html>

<html>

	<head>
		<title>Call_Register_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
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
	</head>
	<BODY bgColor="white" onload="abc();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Width="80%" ForeColor="DarkBlue" BackColor="White" Font-Bold="True"
								Font-Size="10pt" Font-Names="Verdana">CALL REGISTRATION/CANCELLATION</asp:label></P>
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
											<TD style="HEIGHT: 36px" align="right"><asp:label id="Label6" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Case No.</asp:label></TD>
											<TD style="HEIGHT: 36px"><asp:textbox id="txtCaseNo" onblur="makeUppercase();" tabIndex="1" runat="server" Width="150px"
													ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="9" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 36px" align="right"><asp:label id="Label2" runat="server" Width="105px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Call Date</asp:label></TD>
											<TD style="HEIGHT: 36px"><asp:textbox id="txtDtOfReciept" onblur="check_date(txtDtOfReciept);" tabIndex="2" runat="server"
													Width="150px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 36px" align="right"><asp:label id="Label9" runat="server" Width="105px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Call SNo.</asp:label></TD>
											<TD style="HEIGHT: 36px"><asp:textbox id="txtCSNO" onblur="check_date(txtDtOfReciept);" tabIndex="3" runat="server" Width="50px"
													ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="5" Height="20px"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="WIDTH: 50%">
									<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 100%" borderColor="#b0c4de" cellSpacing="0"
										cellPadding="0" width="340" bgColor="aliceblue" border="1">
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 36px" align="right"><asp:label id="Label5" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">PO No.</asp:label></TD>
											<TD style="WIDTH: 70%"><asp:textbox id="txtPONO" tabIndex="4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
													Font-Names="Verdana" MaxLength="45" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 36px" align="right"><asp:label id="Label7" runat="server" Width="60px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">PO Date</asp:label></TD>
											<TD style="WIDTH: 70%"><asp:textbox id="txtPODT" onblur="check_date(txtPODT);" tabIndex="5" runat="server" Width="40%"
													ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 36px" align="right">
												<asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%"> Vendor Name</asp:label></TD>
											<TD style="WIDTH: 70%">
												<asp:textbox id="txtVendName" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Width="100%" Height="20px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 30%; HEIGHT: 36px" align="right">
												<asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%"> Call Letter No./Dispatch Ref No.</asp:label></TD>
											<TD style="WIDTH: 70%">
												<asp:textbox id="txtCallLetNo" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Width="60%" Height="20px" MaxLength="30"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">To Search a Case-> Enter Case No. or Call Date or Part or Full PO No. or PO DT or Vendor Name or Call Letter No./Dispatch Ref No. and Click on Search Button</asp:label><asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">To Edit/Delete or To Register New Call --> Enter Case No & Call Date and then Click on desired Button</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center"><asp:button id="btnAdd" tabIndex="8" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="New Call" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="9" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Modify" onclick="btnMod_Click"></asp:button><asp:button id="btnDelete" tabIndex="10" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnCCancellation" tabIndex="11" runat="server" Width="119px" ForeColor="DarkBlue"
							Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Text="Call Cancellation" onclick="btnCCancellation_Click"></asp:button><asp:button id="btnCallStatus" tabIndex="12" runat="server" Width="119px" ForeColor="DarkBlue"
							Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Text="Edit Call Status" onclick="btnCallStatus_Click"></asp:button><asp:button id="btnSearch" tabIndex="13" runat="server" Width="65px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="txtSearch_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px">
						<P align="center"><asp:label id="Label4" runat="server" Width="384px" ForeColor="OrangeRed" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<DIV>
							<TITTLE:CUSTOMDATAGRID id="grdCNO" runat="server" Width="100%" Height="8px" PageSize="15" FreezeRows="0"
								CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
								BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="400px"
								GridWidth="100%">
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
											<asp:HyperLink id="Hyperlink2" NavigateUrl='<%#"Call_Register_Edit.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;CALL_RECV_DT=" + DataBinder.Eval(Container.DataItem,"CALL_RECV_DT") + "&amp;CALL_SNO=" + DataBinder.Eval(Container.DataItem, "CALL_SNO") + ""  %>' runat="server">Select</asp:HyperLink>
										    
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
