<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendor_Call_Register_Edit.aspx.cs" Inherits="RBS.Vendor.Vendor_Call_Register_Edit" %>

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
		
		if(trimAll(document.Form1.txtCaseNo.value)=="" && trimAll(document.Form1.txtPONO.value).length < 3)
		{
		 alert("Enter CASE NO. or Atleast 3 Digits of PO No. to search the Records");
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
								BackColor="White" ForeColor="DarkBlue" Width="80%">VENDOR CALL REGISTRATION</asp:label></P>
					</TD>
				</TR>
				<TR>
					<td style="WIDTH: 100%; HEIGHT: 10%" vAlign="top" align="center">
						<P style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: red; FONT-FAMILY: Verdana; TEXT-ALIGN: left; TEXT-DECORATION: underline">Attention:</P>
						<P style="FONT-SIZE: 8pt; COLOR: red; FONT-FAMILY: Verdana; TEXT-ALIGN: justify">
							1.&nbsp;Please note that calls submitted on Sundays and 
							on&nbsp;National&nbsp;Holidays shall be&nbsp;Registered only on next working 
							day.</P>
						<P style="FONT-SIZE: 8pt; COLOR: red; FONT-FAMILY: Verdana; TEXT-ALIGN: justify">2.&nbsp;Calls 
							recieved upto 3 P.M. shall be marked on same day and calls recieved after 3 
							P.M. shall be marked on next working day except Saturday.</P>
					</td>
				</TR>
				<TR>
					<TD style="WIDTH: 50%; HEIGHT: 162px" align="center">
						<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 70%" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table3" style="WIDTH: 70%; HEIGHT: 100%" borderColor="#b0c4de" cellSpacing="0"
										cellPadding="0" bgColor="aliceblue" border="1">
										<TR>
											<TD style="WIDTH: 81px; HEIGHT: 46px" align="right"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="61px"> Case No.</asp:label></TD>
											<TD style="WIDTH: 141px; HEIGHT: 46px"><asp:textbox id="txtCaseNo" onblur="makeUppercase();" tabIndex="1" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="100px" Height="20px" MaxLength="9"></asp:textbox></TD>
											<TD style="WIDTH: 57px; HEIGHT: 46px"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="61px">PO No.</asp:label></TD>
											<TD style="HEIGHT: 46px"><asp:textbox id="txtPONO" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%" Height="20px" MaxLength="45"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 81px; HEIGHT: 36px" align="right"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="70px">Call Date</asp:label></TD>
											<TD style="WIDTH: 141px; HEIGHT: 36px"><asp:textbox id="txtDtOfReciept" onblur="check_date(txtDtOfReciept);" tabIndex="2" runat="server"
													Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="100px" Height="20px" MaxLength="10" Visible="False"></asp:textbox><asp:label id="lblDtOfReciept" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Width="98px"></asp:label></TD>
											<TD style="WIDTH: 57px; HEIGHT: 36px"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="58px" Visible="False">Call SNo.</asp:label></TD>
											<TD style="HEIGHT: 36px"><asp:textbox id="txtCSNO" onblur="check_date(txtDtOfReciept);" tabIndex="3" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="50px" Height="20px" MaxLength="5" Visible="False"></asp:textbox><asp:label id="lblCSNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Width="192px"></asp:label></TD>
										</TR>
              <TR>
                <TD style="WIDTH: 81px; HEIGHT: 36px" align=right>
<asp:label id=Label51 runat="server" Width="101px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana">State whether the Call is for Final Or Stage Inspection</asp:label></TD>
                <TD style="WIDTH: 141px; HEIGHT: 36px" colSpan=2>
<asp:radiobutton id=rdbFinal tabIndex=10 runat="server" Width="80px" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Text="Final" GroupName="g4" Checked="True" AutoPostBack="True"></asp:radiobutton></TD>
                <TD style="HEIGHT: 36px">
<asp:radiobutton id=rdbStage tabIndex=11 runat="server" Width="56px" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Text="Stage" GroupName="g4" AutoPostBack="True"></asp:radiobutton></TD></TR>
              
              <TR>
                <TD align="center" colSpan=4 ><asp:label id=Label52 runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana">* Select Stage in case of Stage Inspection/Raw Material Inspection.</asp:label></TD></TR>
										<TR>
											<TD align="left" colSpan="4"><asp:label id="lblCDateMess" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Width="100%"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkMagenta" Width="100%">To Search a Call-> Enter Case No. Or PO No. and Click on [Search] Button</asp:label><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkMagenta" Width="100%">To Register New Call --> Enter Case No then Click on [New Call] Button, Kindly Search Before Registering Your Call.</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center"><asp:button id="btnAdd" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="67px" Text="New Call"></asp:button><asp:button id="btnSearch" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
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
						<DIV><TITTLE:CUSTOMDATAGRID id="grdCNO" runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="200px"
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
											<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"Vendor_Call_Register_Form.aspx?Action=M&Case_No=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&DT_RECIEPT=" + DataBinder.Eval(Container.DataItem,"CALL_RECV_DT")+ "&CALL_SNO=" + DataBinder.Eval(Container.DataItem,"CALL_SNO")%>'>Select</asp:HyperLink>
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
			</TABLE></TD></TR></TABLE></TD></TR></TABLE></form>
	</BODY>
</HTML>