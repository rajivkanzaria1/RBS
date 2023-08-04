<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseNoBPOforAdvancedCheque.aspx.cs" Inherits="RBS.CaseNoBPOforAdvancedCheque.CaseNoBPOforAdvancedCheque" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CASE NO. & BPO Entry For Advanced Cheques Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		
		 function validate1()
		{
		 if(document.Form1.txtCSNO!="[object]" && trimAll(document.Form1.txtBPO.value)=="")
		{
		 alert("ENTER BPO CODE OR 1ST Few CHARACTERS OF BPO NAME AND THEN CLICK ON SELECT BPO BUTTON");
		 event.returnValue=false;
		 }
		  else
		 return;

		}
		
		function validate()
		{
		 
		if(document.Form1.txtCSNO=="[object]" && trimAll(document.Form1.txtCSNO.value)=="")
		{
			alert("Case No. Cannot be Blank!!!");
			event.returnValue=false;
		}
		else
		{
			document.Form1.btnSave.style.visibility = 'hidden';
		}
		 return;
		}
		
		function validate2()
		{
		 
		if(document.Form1.btnPChq.checked==true && trimAll(document.Form1.txtCHQ_NO_SEARCH.value)=="")
		{
			alert("Cheque No. Cannot be Blank!!!");
			event.returnValue=false;
		}
		if(document.Form1.btnAcc_CD.checked==true && trimAll(document.Form1.lstACC_CD_SEARCH.value)=="")
		{
			alert("Account Head Cannot be Blank!!!");
			event.returnValue=false;
		}
		else
		{
			document.Form1.btnSave.style.visibility = 'hidden';
		}
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
		function sFocus()
		 {
		 if(document.Form1.txtVNO=="[object]")
		 {
		 document.Form1.txtVNO.focus();
		 }
		 else if(document.Form1.txtVDT=="[object]")
		 {
		 document.Form1.txtVDT.focus();
		 }
		 else 
		 {
		 document.Form1.txtCNO.focus();
		 }
		 }
		function chq_search()
		{
			if(document.Form1.btnPChq=="[object]" && document.Form1.btnPChq.checked==true)
			{
				document.Form1.lstACC_CD_SEARCH.style.visibility = 'hidden';
				document.Form1.txtCHQ_NO_SEARCH.style.visibility = 'visible';
			}
			else if(document.Form1.btnAcc_CD=="[object]" && document.Form1.btnAcc_CD.checked==true)
			{
				document.Form1.lstACC_CD_SEARCH.style.visibility = 'visible';
				document.Form1.txtCHQ_NO_SEARCH.style.visibility = 'hidden';
			}
		
		}

		
        </script>
	</HEAD>
	<BODY bgColor="white" onload="chq_search();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue" Width="396px"> CASE NO/ BPO ENTRY IN CHEQUE/DD RECEIPTS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="left"></TD>
				</TR>
				<TR>
					<TD><asp:panel id="Panel1" runat="server" Height="198px" HorizontalAlign="Center">
							<TABLE id="Table2" style="WIDTH: 711px; POSITION: relative; TOP: 0px; HEIGHT: 168px" borderColor="#b0c4de"
								cellSpacing="1" cellPadding="1" width="711" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Cheque No</asp:label></P>
									</TD>
									<TD style="WIDTH: 16.24%; HEIGHT: 20px" align="center">
										<asp:label id="Label5" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Cheque Date</asp:label></TD>
									<TD style="WIDTH: 31.11%; HEIGHT: 20px" align="center">
										<asp:label id="Label11" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Bank/Cash</asp:label></TD>
									<TD style="WIDTH: 17.21%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label7" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Amount</asp:label></P>
									</TD>
									<TD style="WIDTH: 20%; HEIGHT: 20px" align="center">
										<asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Sample No.</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtCNO" style="TEXT-ALIGN: center" tabIndex="6" runat="server" Width="95%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox>
										<asp:label id="lblCNO" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana"></asp:label></TD>
									<TD style="WIDTH: 16.24%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtCDT" onblur="check_date(txtCDT);" style="TEXT-ALIGN: center" tabIndex="7"
											runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px"
											MaxLength="11"></asp:textbox>
										<asp:label id="lblCDT" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana"></asp:label></TD>
									<TD style="WIDTH: 31.11%; HEIGHT: 24px" align="center">
										<asp:dropdownlist id="lstBank1" tabIndex="8" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"></asp:dropdownlist></TD>
									<TD style="WIDTH: 17.21%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtAmt" style="TEXT-ALIGN: center" tabIndex="9" runat="server" Width="95%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="13"></asp:textbox></TD>
									<TD style="WIDTH: 20%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtSNo" style="TEXT-ALIGN: center" tabIndex="10" runat="server" Width="60%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36.54%; HEIGHT: 20px" align="center" colSpan="2">
										<asp:label id="Label14" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Account Code</asp:label></TD>
									<TD style="WIDTH: 31.16%; HEIGHT: 20px" align="left" colSpan="2">&nbsp;&nbsp; 
										&nbsp;
										<asp:label id="Label12" runat="server" Width="77px" ForeColor="DarkGreen" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana">Case No.</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:label id="Label9" runat="server" Width="160px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">BPO.</asp:label></TD>
									<TD style="WIDTH: 32%; HEIGHT: 20px" align="center">
										<asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Narration</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36.54%; HEIGHT: 38px" vAlign="top" align="center" colSpan="2">
										<asp:dropdownlist id="lstACD" tabIndex="11" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="lstACD_SelectedIndexChanged" onprerender="lstACD_PreRender"></asp:dropdownlist>
										<asp:label id="lblType" runat="server" Width="160px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:label></TD>
									<TD style="WIDTH: 31.16%; HEIGHT: 38px" vAlign="top" align="left" colSpan="2">
										<asp:textbox id="txtCSNO" style="TEXT-ALIGN: center" tabIndex="12" runat="server" Width="25%"
											ForeColor="DarkGreen" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="9" AutoPostBack="True" ondisposed="txtCSNO_PreRender"></asp:textbox>&nbsp;&nbsp; 
										&nbsp;&nbsp;
										<asp:textbox id="txtBPO" style="TEXT-ALIGN: center" tabIndex="13" runat="server" Width="72px"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="5"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="btnFC_List" tabIndex="14" runat="server" Width="104px" ForeColor="DarkBlue"
											Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Text="Select BPO" onclick="btnFC_List_Click"></asp:button></TD>
									<TD style="WIDTH: 32%; HEIGHT: 38px" vAlign="top" align="center">
										<asp:textbox id="txtNarrat" style="TEXT-ALIGN: center" tabIndex="16" runat="server" Width="95%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="30px" MaxLength="50" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 19px" align="center" colSpan="5">
										<P align="left">
											<asp:dropdownlist id="lstBPO" tabIndex="15" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="20px" AutoPostBack="True" Visible="False" onselectedindexchanged="lstBPO_SelectedIndexChanged"></asp:dropdownlist></P>
										<P align="left">
											<asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana">
								Click on Select BPO Button After entering the Case No. and Select the Desired BPO form the list.</asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 594px" align="center" colSpan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="btnSave1" tabIndex="17" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave1_Click"></asp:button>
										<asp:button id="btnCancel" tabIndex="18" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</asp:panel>
						<asp:panel id="Panel2" runat="server" Height="198px" HorizontalAlign="Center">
							<TABLE id="table2" style="WIDTH: 711px; POSITION: relative; TOP: 0px; HEIGHT: 168px" borderColor="#b0c4de"
								cellSpacing="1" cellPadding="1" width="711" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center" colSpan="2">
										<P><FONT face="Verdana"><STRONG style="COLOR: darkblue">Report To Be Generated For :</STRONG></FONT></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center">
										<asp:radiobutton id="btnPChq" onclick="chq_search();" tabIndex="1" runat="server" ForeColor="DarkBlue"
											Font-Bold="True" Font-Names="Verdana" Text="For Particular Cheque" Checked="True" GroupName="gr1"
											OnChange="chq_search();"></asp:radiobutton></TD>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center">
										<asp:radiobutton id="btnAcc_CD" onclick="chq_search();" tabIndex="2" runat="server" ForeColor="DarkBlue"
											Font-Bold="True" Font-Names="Verdana" Text="For Particular Account Head" GroupName="gr1" OnChange="chq_search();"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center">
										<asp:textbox id="txtCHQ_NO_SEARCH" style="TEXT-ALIGN: center" tabIndex="3" runat="server" Width="40%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center">
										<asp:dropdownlist id="lstACC_CD_SEARCH" tabIndex="4" runat="server" Width="40%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana">
											<asp:ListItem Value="2709">Advace</asp:ListItem>
											<asp:ListItem Value="O">Other Then Advance</asp:ListItem>
											<asp:ListItem Value="A">All</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center" colSpan="2">
										<asp:button id="btnSearch" tabIndex="5" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Text="Search" DESIGNTIMEDRAGDROP="596" onclick="btnSearch_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center" colSpan="2">
										<DIV>
											<TITTLE:CUSTOMDATAGRID id="grdVDt" runat="server" Width="100%" Height="8px" BorderColor="DarkBlue" AutoGenerateColumns="False"
												PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
												BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="230px" GridWidth="100%">
												<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
												<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
												<EditItemStyle Height="10%"></EditItemStyle>
												<FooterStyle CssClass="GridHeader"></FooterStyle>
												<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
												<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
													CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="Cheque No">
														<HeaderStyle Width="1%"></HeaderStyle>
														<ItemTemplate>
															<asp:HyperLink id=HyperLink1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CHQ_NO")%>' NavigateUrl='<%#"CaseNoBPOforAdvancedCheque.aspx?VOUCHER_NO=" + DataBinder.Eval(Container.DataItem,"VCHR_NO") + "&amp;ACTION=M" + "&amp;SNO=" + DataBinder.Eval(Container.DataItem,"SNO")%>'>HyperLink</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="CHQ_NO" HeaderText="Cheque No">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CHQ_DT" HeaderText="Cheque Date">
														<HeaderStyle Width="7%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="AMOUNT" HeaderText="Amount">
														<HeaderStyle Width="8%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BANK_NAME" HeaderText="Bank/Cash">
														<HeaderStyle Width="14%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="ACC_DESC" HeaderText="Account Code">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BPO_NAME" HeaderText="BPO">
														<HeaderStyle Width="18%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="VCHR_NO" HeaderText="Voucher No">
														<HeaderStyle Width="1%"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
											</TITTLE:CUSTOMDATAGRID></DIV>
									</TD>
								</TR>
							</TABLE>
						</asp:panel>
					</TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
