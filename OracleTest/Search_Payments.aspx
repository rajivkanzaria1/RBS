<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search_Payments.aspx.cs" Inherits="RBS.Search_Payments.Search_Payments" %>

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
			if(trimAll(document.Form1.lstBank.value)=="" && trimAll(document.Form1.txtEFTNO.value)=="" && trimAll(document.Form1.txtEFTDT.value)=="" && trimAll(document.Form1.txtAmt.value)=="" && trimAll(document.Form1.txtCSNO.value)=="" && trimAll(document.Form1.txtVend.value).length < 3)
			{
			
				alert("Plz Select Bank Or Enter EFT No. Or EFT Date or Amount or Some Characters of Narration/Vendor Name or CASE No. To Search Records!!!");
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
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 48px"
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
									Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">SEARCH PAYMENTS</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 150px" align="center">
							<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 64px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" bgColor="#f0f8ff" border="1">
								<TBODY>
									<TR>
										<TD style="WIDTH: 10%" vAlign="top">
											<P><asp:label id="Label11" runat="server" Width="40px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Bank</asp:label></P>
										</TD>
										<TD style="WIDTH: 28.43%" vAlign="top">
											<P><asp:dropdownlist id="lstBank" tabIndex="1" runat="server" Width="98%" ForeColor="DarkBlue" Font-Size="8pt"
													Font-Names="Verdana"></asp:dropdownlist></P>
										</TD>
										<TD style="WIDTH: 9.75%; HEIGHT: 9px" vAlign="top"><P><asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Instrument No</asp:label></P>
										</TD>
										<TD style="WIDTH: 18.82%; HEIGHT: 9px" vAlign="top">
											<P><asp:textbox id="txtEFTNO" style="TEXT-ALIGN: center" tabIndex="2" runat="server" Width="95%"
													ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="12"></asp:textbox></P>
										</TD>
										<TD style="WIDTH: 13.24%; HEIGHT: 9px" vAlign="top">
											<P><asp:label id="Label5" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Instrument Date</asp:label></P>
										</TD>
										<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
											<P><asp:textbox id="txtEFTDT" onblur="check_date(txtEFTDT);" style="TEXT-ALIGN: center" tabIndex="3"
													runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px"
													MaxLength="10"></asp:textbox></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 10%" vAlign="top">
											<P><asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Instrument Amount</asp:label></P>
										</TD>
										<TD style="WIDTH: 11.52%" vAlign="top">
											<P><asp:textbox id="txtAmt" style="TEXT-ALIGN: center" tabIndex="4" runat="server" Width="90%" ForeColor="DarkBlue"
													Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="13"></asp:textbox></P>
										</TD>
										<TD style="WIDTH: 14.57%" vAlign="top">
											<P>
												<asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">Case NO.</asp:label></P>
										</TD>
										<TD style="WIDTH: 18.82%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:textbox id="txtCSNO" onblur="makeUppercase();" style="TEXT-ALIGN: center" tabIndex="5" runat="server"
													Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="90%" MaxLength="9" Height="20px"></asp:textbox></P>
										</TD>
										<TD style="WIDTH: 13.24%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Narration/Vendor Name</asp:label></P>
										</TD>
										<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
											<P>
												<asp:textbox id="txtVend" onblur="check_date(txtEFTDT);" style="TEXT-ALIGN: center" tabIndex="6"
													runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px"
													MaxLength="10"></asp:textbox></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" align="center" colSpan="6"><asp:label id="Label6" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana">To Search a EFT --> Enter Bank or Part/Full EFT NO.  or EFT Date or Amount and click on "Search" button</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" colSpan="6">
											<P align="center"><asp:button id="btnSearch" tabIndex="7" runat="server" Width="83px" ForeColor="DarkBlue" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button></P>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<br>
						</TD>
					<TR>
						<TD style="HEIGHT: 26px" align="center"><TITTLE:CUSTOMDATAGRID id="grdEFT" runat="server" Width="100%" Height="100px" BorderColor="DarkBlue" AutoGenerateColumns="False"
								PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0"
								FreezeHeader="True" GridHeight="200px" GridWidth="100%" DESIGNTIMEDRAGDROP="304">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
									CssClass="GridHeader" VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Select">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id=HyperLink1 runat="server" Text='Select' NavigateUrl='<%#"Check_Posting_Form.aspx?CHQ_NO=" + DataBinder.Eval(Container.DataItem,"CHQ_NO") + "&amp;CHQ_DT=" + DataBinder.Eval(Container.DataItem,"CHQ_DT") + "&amp;BANK_CD=" + DataBinder.Eval(Container.DataItem,"BANK_CD")%>'>Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="VCHR_NO" HeaderText="Voucher No.">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VCHR_DT" HeaderText="Voucher Date">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BANK_NAME" HeaderText="Bank">
										<HeaderStyle Width="10%"></HeaderStyle>
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
									<asp:BoundColumn DataField="ACC_CD" HeaderText="Account CD"></asp:BoundColumn>
									<asp:BoundColumn DataField="AMOUNT_ADJUSTED" HeaderText="Amt Adjusted">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMT_TRANSFERRED" HeaderText="Amt Transferred">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SUSPENSE_AMT" HeaderText="Suspense/ Un-Adjusted Advance">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BPO" HeaderText="BPO">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NARRATION" HeaderText="Narration">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 26px" align="center"></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
