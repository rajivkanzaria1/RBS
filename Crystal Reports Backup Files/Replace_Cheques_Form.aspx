<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Replace_Cheques_Form.aspx.cs" Inherits="RBS.Replace_Cheques_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Search Payments</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate1()
		{
			if(trimAll(document.Form1.lstBank.value)=="" && trimAll(document.Form1.txtEFTNO.value)=="" && trimAll(document.Form1.txtEFTDT.value)=="" && trimAll(document.Form1.txtAmt.value)=="")
			{
			
				alert("Plz Select Bank Or Enter EFT No. Or EFT Date or Amount or Some Characters of Narration/Vendor Name or CASE No. To Search Records!!!");
				event.returnValue=false;
			}
		 return;
		}
		
		function validate()
		{
			if(trimAll(document.Form1.lstBank1.value)=="" || trimAll(document.Form1.txtNCNO.value)=="" || trimAll(document.Form1.txtNCDT.value)=="" || trimAll(document.Form1.txtNCHQAMT.value)=="")
			{
			
				alert("Plz Select Bank and Enter New CHQ No. and EFT Date and Amount To proceed for replacement od cheque!!!");
				event.returnValue=false;
			}
		 return;
		}
		
		function makeUppercase()
		 {
			document.Form1.txtCsNo.value = document.Form1.txtCsNo.value.toUpperCase();
		 }
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 48px; TOP: 8px; LEFT: 8px"
				cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 17px" align="center" height="17">
							<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 28px" align="center">
							<P><asp:label id="Label1" runat="server" Width="276px" ForeColor="DarkBlue" BackColor="White"
									Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">REPLACE CHEQUE</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 131px" align="center"><asp:panel id="Panel1" runat="server" Width="100%" Visible="False" Height="254px">
								<TABLE style="WIDTH: 100%; HEIGHT: 64px" id="Table2" border="1" cellSpacing="1" borderColor="#b0c4de"
									cellPadding="1" bgColor="#f0f8ff">
									<TR>
										<TD style="WIDTH: 10%" vAlign="top">
											<P>
												<asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="40px">Bank</asp:label></P>
										</TD>
										<TD style="WIDTH: 28.01%" vAlign="top">
											<P>
												<asp:dropdownlist id="lstBank" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="98%"></asp:dropdownlist></P>
										</TD>
										<TD style="WIDTH: 9.75%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">CHQ No</asp:label></P>
										</TD>
										<TD style="WIDTH: 18.82%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:textbox style="TEXT-ALIGN: center" id="txtEFTNO" tabIndex="2" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="95%" Height="20px" MaxLength="12"></asp:textbox></P>
										</TD>
										<TD style="WIDTH: 13.24%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">CHQ Date</asp:label></P>
										</TD>
										<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:textbox onblur="check_date(txtEFTDT);" style="TEXT-ALIGN: center" id="txtEFTDT" tabIndex="3"
													runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px"
													MaxLength="10"></asp:textbox></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 10%" vAlign="top">
											<P>&nbsp;</P>
										</TD>
										<TD style="WIDTH: 11.34%" vAlign="top">
											<P>&nbsp;</P>
										</TD>
										<TD style="WIDTH: 14.57%" vAlign="top">
											<P>
												<asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">CHQ Amount</asp:label></P>
										</TD>
										<TD style="WIDTH: 18.82%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:textbox style="TEXT-ALIGN: center" id="txtAmt" tabIndex="4" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></P>
										</TD>
										<TD style="WIDTH: 13.24%; HEIGHT: 9px" vAlign="top">
											<P>&nbsp;</P>
										</TD>
										<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
											<P>&nbsp;</P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" colSpan="6" align="center">
											<asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkMagenta" Width="100%">To Search a Cheque --> Enter Bank or Part/Full CHQ NO.  or CHQ Date or Amount and click on "Search" button</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" colSpan="6">
											<P align="center">
												<asp:button id="btnSearch" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="DarkBlue" Width="83px" Text="Search" onclick="btnSearch_Click"></asp:button></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" colSpan="6">
											<TITTLE:CUSTOMDATAGRID id="grdEFT" runat="server" Width="100%" Height="100px" GridWidth="100%" GridHeight="150px"
												FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
												CellPadding="2" FreezeRows="0" PageSize="15" AutoGenerateColumns="False" BorderColor="DarkBlue">
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
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:HyperLink id=HyperLink1 runat="server" Text='Select' NavigateUrl='<%#"Replace_Cheques_Form.aspx?CHQ_NO=" + DataBinder.Eval(Container.DataItem,"CHQ_NO") + "&amp;CHQ_DT=" + DataBinder.Eval(Container.DataItem,"CHQ_DT") + "&amp;BANK_CD=" + DataBinder.Eval(Container.DataItem,"BANK_CD")%>'>Select</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="VCHR_NO" HeaderText="Voucher No.">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="VCHR_DT" HeaderText="Voucher Date">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BANK_NAME" HeaderText="Bank">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CHQ_NO" HeaderText="Instrument No">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CHQ_DT" HeaderText="Instrument Date">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="AMOUNT" HeaderText="Instrument Amount ">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="AMOUNT_ADJUSTED" HeaderText="Amt Adjusted">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="SUSPENSE_AMT" HeaderText="Suspense Amt">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BPO" HeaderText="BPO">
														<HeaderStyle Width="20%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
											</TITTLE:CUSTOMDATAGRID></TD>
									</TR>
								</TABLE>
							</asp:panel></TD>
					<TR>
						<TD align="center"><asp:panel id="Panel2" runat="server" Visible="False">
								<TABLE style="WIDTH: 100%; HEIGHT: 36px" id="Table3" border="1" cellSpacing="1" borderColor="#b0c4de"
									cellPadding="1" bgColor="#f0f8ff">
									<TR>
										<TD style="WIDTH: 9.22%" vAlign="top">
											<asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="80px">Voucher No.</asp:label></TD>
										<TD style="WIDTH: 7.55%" vAlign="top">
											<asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="40px">SNo.</asp:label></TD>
										<TD style="WIDTH: 30.96%" vAlign="top">
											<P>
												<asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="40px">Bank</asp:label></P>
										</TD>
										<TD style="WIDTH: 22.81%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">CHQ No</asp:label></P>
										</TD>
										<TD style="WIDTH: 15.64%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">CHQ Date</asp:label></P>
										</TD>
										<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">CHQ Amount</asp:label></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 9.22%" vAlign="top">
											<asp:label id="lblVCHRNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="88px"></asp:label></TD>
										<TD style="WIDTH: 7.55%" vAlign="top">
											<asp:label id="lblSNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="56px"></asp:label></TD>
										<TD style="WIDTH: 30.96%" vAlign="top">
											<asp:label id="lblBank" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="100%"></asp:label></TD>
										<TD style="WIDTH: 22.81%; HEIGHT: 9px" vAlign="top">
											<asp:label id="lblCNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="100%"></asp:label></TD>
										<TD style="WIDTH: 15.64%; HEIGHT: 9px" vAlign="top">
											<asp:label id="lblCDT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="100%"></asp:label></TD>
										<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
											<asp:label id="lblCAMT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="100%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 13.82%; HEIGHT: 169px" vAlign="top" colSpan="6" align="center">
											<P>
												<asp:label id="lbl1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="OrangeRed"
													Width="341px">Bill Details Cleared Against Given Cheque</asp:label></P>
											<P>
												<TITTLE:CUSTOMDATAGRID id="grdVDt" runat="server" Width="100%" Height="150px" Visible="False" GridWidth="100%"
													GridHeight="150px" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid"
													UseAccessibleHeader="True" CellPadding="2" FreezeRows="0" PageSize="15" AutoGenerateColumns="False"
													BorderColor="DarkBlue">
													<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
													<EditItemStyle Height="10%"></EditItemStyle>
													<FooterStyle CssClass="GridHeader"></FooterStyle>
													<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
													<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
														CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="BILL_NO" HeaderText="Bill No."></asp:BoundColumn>
														<asp:BoundColumn DataField="BPO_NAME" HeaderText="BPO ">
															<HeaderStyle Width="40%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="BILL_AMOUNT" HeaderText="Bill Amount">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="BILL_AMT_CLEARED" HeaderText="Bill Amount Cleared">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="AMOUNT_CLEARED" HeaderText="Amount Cleared by the Above Cheque">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="POSTING_DT" HeaderText="Posting Date">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="CHQ_NO" HeaderText="Cheque No"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="CHQ_DT" HeaderText="Cheque Date"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="BANK_CD" HeaderText="BANK"></asp:BoundColumn>
													</Columns>
												</TITTLE:CUSTOMDATAGRID></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 13.73%" vAlign="top" colSpan="3">
											<asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="136px">New Bank</asp:label></TD>
										<TD style="WIDTH: 22.81%; HEIGHT: 9px" vAlign="top">
											<asp:label id="Label14" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">New CHQ No</asp:label></TD>
										<TD style="WIDTH: 15.64%; HEIGHT: 9px" vAlign="top">
											<asp:label id="Label15" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">New CHQ Date</asp:label></TD>
										<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
											<asp:label id="Label16" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">New CHQ Amount</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 13.73%" vAlign="top" colSpan="3">
											<asp:dropdownlist id="lstBank1" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="98%"></asp:dropdownlist></TD>
										<TD style="WIDTH: 22.81%; HEIGHT: 9px" vAlign="top">
											<asp:textbox style="TEXT-ALIGN: center" id="txtNCNO" tabIndex="2" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="95%" Height="20px" MaxLength="12"></asp:textbox></TD>
										<TD style="WIDTH: 15.64%; HEIGHT: 9px" vAlign="top">
											<asp:textbox onblur="check_date(txtNCDT);" style="TEXT-ALIGN: center" id="txtNCDT" tabIndex="3"
												runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px"
												MaxLength="10"></asp:textbox></TD>
										<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
											<asp:textbox style="TEXT-ALIGN: center" id="txtNCHQAMT" tabIndex="4" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 13.73%" vAlign="top" colSpan="6" align="center">
											<asp:button id="btnUpdate" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
												Font-Bold="True" ForeColor="DarkBlue" Width="161px" Text="Update Cheque Details" onclick="btnUpdate_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</asp:panel></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 26px" align="center"></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
