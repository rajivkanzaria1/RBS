<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendor_Calls_Marked_Form.aspx.cs" Inherits="RBS.Vendor_Calls_Marked_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Call_Register_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(document.Form1.lstIE=="[object]" && trimAll(document.Form1.lstIE.value)=="")
		{
		 alert("IE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else
		return;
		}
		function validate1()
		{
		if(document.Form1.txtRejReason=="[object]" && trimAll(document.Form1.txtRejReason.value)=="")
		{
		 alert("REJECTION REASON CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else
		return;
		}
		function makeUppercase()
		 {
			document.Form1.txtCaseNo.value = document.Form1.txtCaseNo.value.toUpperCase();
			
		 }
		 
		function abc()
		 {
		 if(document.Form1.lstIE=="[object]")
		 {
			document.Form1.lstIE.focus();
		 }
		 else if(document.Form1.RadioButton1=="[object]")
		 {
			document.Form1.RadioButton1.focus();
		 }
		 }
		 
		
        </script>
	    <style type="text/css">
            .auto-style1 {
                height: 173px;
            }
            .auto-style2 {
                width: 11.85%;
                height: 48px;
            }
        </style>
	</HEAD>
	<BODY bgColor="white" onload="abc();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center" class="auto-style1">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue" Width="80%">ONLINE CALL MARKING FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 50%" align="center">
						<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 70%" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD><asp:panel id="Panel1" runat="server" Width="100%" Height="1px" Visible="True">
										<TABLE id="Table5" style="WIDTH: 100%; HEIGHT: 31.74%" borderColor="#b0c4de" cellSpacing="0"
											cellPadding="0" bgColor="aliceblue" border="1">
											<TR>
												<TD width="35%">
													<P>
														<asp:RadioButton id="Radiobutton1" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Bold="True"
															Font-Size="8pt" Font-Names="Verdana" GroupName="a" Text="Show All Online Calls Marked on  "></asp:RadioButton><BR>
														<BR>
														<asp:RadioButton id="Radiobutton3" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Bold="True"
															Font-Size="8pt" Font-Names="Verdana" GroupName="a" Text="Show Only Un-Marked Online Calls for   "></asp:RadioButton></P>
												</TD>
												<TD width="65%">
													<asp:TextBox id="txtRunDt" onblur="check_date(txtRunDt);" tabIndex="3" runat="server" style="height: 22px"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 43px" colSpan="2">
													<P>
														<asp:RadioButton id="Radiobutton2" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Bold="True"
															Font-Size="8pt" Font-Names="Verdana" GroupName="a" Text="Show All Un-Marked Online Calls As on Date"
															Checked="True"></asp:RadioButton></P>
												</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 11.85%; HEIGHT: 26px" align="center" colSpan="2">
													<asp:button id="Submit" tabIndex="5" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana" Text="Submit"></asp:button></TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 50%" align="center">
						<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 70%" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD><asp:panel id="Panel2" runat="server" Width="100%" Height="1px" Visible="False">
										<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 31.74%" borderColor="#b0c4de" cellSpacing="0"
											cellPadding="0" bgColor="aliceblue" border="1">
											<tr bgColor="#ccccff">
												<TD style="WIDTH: 10.85%; HEIGHT: 23px"><asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Case No</asp:label></TD>
												<TD style="WIDTH: 50.62%; HEIGHT: 23px"><asp:label id="txtCaseNo" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed">Case No </asp:label></TD>
												<TD style="WIDTH: 14.16%; HEIGHT: 23px"><asp:label id="Label16" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue"> Call Date - SNo. </asp:label></TD>
												<TD style="WIDTH: 12%; HEIGHT: 23px"><asp:label id="txtDtOfReciept" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed">C Date </asp:label>&nbsp;<asp:label id="lblREG_TIME" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed">C Date </asp:label>&nbsp; -
													<asp:label id="lblCSNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed">C SNO</asp:label></TD>
											</tr>
											<tr bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 39px"><asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Contract No </asp:label></TD>
												<TD style="WIDTH: 50.62%; HEIGHT: 39px"><asp:label id="lblPONO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="80%"></asp:label><asp:label id="lblL5noPo" runat="server" Visible="True"></asp:label><asp:label id="lblRly" runat="server" Visible="True"></asp:label></TD> <%--false--%>
												<TD style="WIDTH: 10.16%; HEIGHT: 39px"><asp:label id="Label18" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Date</asp:label></TD>
												<TD style="WIDTH: 15%; HEIGHT: 39px"><asp:label id="lblPODT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed">PO Date </asp:label></TD>
											</tr>
											<tr bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label17" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Vendor</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3"><asp:label id="lblVend" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="90%">Vendor </asp:label><asp:textbox id="txtCALLLETTERDT" runat="server" Visible="True"></asp:textbox></TD> <%--False--%>
											</tr>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Manufacturer/Place of Inspection</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3"><asp:label id="lblMfg" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="90%">Mfg</asp:label><asp:label id="lblManuf" runat="server" Visible="True"></asp:label></TD> <%--False--%>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Remarks</asp:label><asp:label id="Label34" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="Red">(250 Chars Maxm)</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3"><asp:textbox id="txtRemarks" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt"
														ForeColor="DarkBlue" Width="95%" Height="39px" MaxLength="100" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 2px"><asp:label id="Label23" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Inspecting Er.</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 2px" colSpan="3"><asp:dropdownlist id="lstIE" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
														ForeColor="DarkBlue" Width="50%" Height="25px"></asp:dropdownlist>
													<asp:label id="lblIE_CD" runat="server" Width="256px" ForeColor="OrangeRed" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana" Visible="True" Height="14px"></asp:label></TD> <%--False--%>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Item </asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3"><asp:label id="lblITEM" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="90%"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Staggered DP</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3"><asp:label id="lblStagDP" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="80px"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:label id="Label15" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">1. Lot Size & DP</asp:label>&nbsp;
													<asp:label id="lblLot_DP_1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="25%"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
													&nbsp;
													<asp:label id="Label20" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">2. Lot Size & DP</asp:label>&nbsp;
													<asp:label id="lblLot_DP_2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="25%"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 28px"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Quantity Ordered</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 28px"><asp:label id="lblQTYORD" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="90%"></asp:label></TD>
												<TD style="WIDTH: 12.16%; HEIGHT: 28px"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Quantity Offered</asp:label></TD>
												<TD style="WIDTH: 19.24%; HEIGHT: 28px"><asp:label id="lblQTYOFF" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="90%"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 28px"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Call Material Value</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 28px"><asp:label id="lblCallMatValue" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="256px" Height="14px"></asp:label></TD>
												<TD style="WIDTH: 12.16%; HEIGHT: 28px"><asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Desire Date</asp:label></TD>
												<TD style="WIDTH: 19.24%; HEIGHT: 28px"><asp:label id="lblDesireDt" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="90%"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 28px"><asp:label id="Label14" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue">Item to be inspected viz. Mechanical, Electrical, Civil etc</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 28px" align="left">
													<asp:dropdownlist id="ddlDept" tabIndex="9" runat="server" Width="150px" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Height="25px" AutoPostBack="True"></asp:dropdownlist>
													<asp:label id="lblDept_CD" runat="server" Width="256px" ForeColor="OrangeRed" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana" Visible="True" Height="14px"></asp:label> <%--False--%>
													<asp:label id="lblDepartment" runat="server" Width="256px" ForeColor="OrangeRed" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana" Height="14px"></asp:label></TD>
												<TD style="WIDTH: 12.16%; HEIGHT: 28px"><asp:label id="Label51" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue" Width="100%">Final Or Stage Inspection</asp:label></TD>
												<TD style="WIDTH: 12.16%; HEIGHT: 28px"><asp:label id="lblFinalORStage" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="256px" Height="14px"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 11.85%; HEIGHT: 28px" align="center" colSpan="4"><asp:hyperlink id="HyperLink1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True">Call Documents</asp:hyperlink></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 11.85%; HEIGHT: 22px" align="center" colSpan="4"><asp:label id="lblHeadPCallsMarked" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
														ForeColor="#FF0066" Font-Underline="True">PREVIOUS CALL DETAILS</asp:label></TD>
											</TR>
											<TR>
												<TD align="left" colSpan="4" class="auto-style2"><asp:label id="lblCall1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="100%"></asp:label><asp:label id="lblCall2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="OrangeRed" Width="90%"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 11.85%; HEIGHT: 26px" align="center" colSpan="4"><asp:button id="btnSave" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
														ForeColor="DarkBlue" Width="61px" Text="Save"></asp:button>&nbsp;<asp:button id="btnCancel1" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt"
														Font-Bold="True" ForeColor="DarkBlue" Width="67px" Text="Cancel"></asp:button>&nbsp;<asp:button id="btnCaseHistory" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt"
														Font-Bold="True" ForeColor="DarkBlue" Width="94px" Text="Case History"></asp:button>&nbsp;
													<asp:button id="btnReject" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt"
														Font-Bold="True" ForeColor="DarkBlue" Width="94px" Text="Reject Call"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:button id="btnSendMail" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt"
														Font-Bold="True" ForeColor="DarkBlue" Width="245px" Text="Send Email For Incomplete Calls."></asp:button></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 26px" vAlign="middle" align="left" width="70%" colSpan="4"><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
														ForeColor="#FF0066" Width="25%" Font-Underline="True">Reason of Rejection</asp:label>&nbsp;
													<asp:textbox id="txtRejReason" tabIndex="12" runat="server" Font-Names="Verdana" Font-Size="8pt"
														Font-Bold="True" ForeColor="Blue" Width="70%" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 26px" align="center" width="70%" colSpan="4"><asp:button id="btnSaveReject" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt"
														Font-Bold="True" ForeColor="DarkBlue" Width="214px" Text="Send Email For Rejected Calls."></asp:button></TD>
											</TR>
										</TABLE></TD>
							</TR>
						</TABLE>
						</asp:panel></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center"><asp:panel id="Panel3" runat="server" Width="100%" Height="1px" Visible="False">
							<DIV>
								<TITTLE:CUSTOMDATAGRID id="grdCNO" runat="server" Width="100%" Visible="False" Height="8px" PageSize="15"
									FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
									BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="550px"
									GridWidth="100%">
									<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
									<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
									<EditItemStyle Height="10%"></EditItemStyle>
									<FooterStyle CssClass="GridHeader"></FooterStyle>
									<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
									<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
										CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn HeaderText="Mark">
											<HeaderStyle Width="5%"></HeaderStyle>
											<ItemTemplate>
												<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl="<%#"Vendor_Calls_Marked_Form.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;CALL_RECV_DT=" + DataBinder.Eval(Container.DataItem,"CALL_RECV_DT")+ "&amp;CALL_SNO=" + DataBinder.Eval(Container.DataItem,"CALL_SNO")+ "&amp;CHECK_SELECTED=" + wchk_val +"&amp;RUN_DT=" + wrun_dt%>">Mark</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PO_NO" HeaderText="PO No.">
											<HeaderStyle Width="14%"></HeaderStyle>
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
										<asp:BoundColumn DataField="IE_NAME" HeaderText="IE">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="VENDOR" HeaderText="Vendor">
											<HeaderStyle Width="15%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CALL_STATUS" HeaderText="Status">
											<HeaderStyle Width="8%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CALL_LETTER_NO" HeaderText="Call Letter No/Dispatch Ref No.">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REMARKS" HeaderText="Remarks">
											<HeaderStyle Width="8%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DATE_TIME" HeaderText="DateTime">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></DIV>
							<P align="center">
								<asp:label id="Label4" runat="server" Width="384px" ForeColor="OrangeRed" Font-Bold="True"
									Font-Size="10pt" Font-Names="Verdana" Visible="False">NO CALL FOUND !!!</asp:label></P>
							<asp:button id="btnCancel3" tabIndex="9" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Text="Cancel"></asp:button>
						</asp:panel>
						<P align="center">&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
			<DIV>&nbsp;</DIV>
			</TD></TR></TABLE></TD></TR></TABLE></form>
	</BODY>
</HTML>

