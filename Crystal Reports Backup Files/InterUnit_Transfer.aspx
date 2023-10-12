<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterUnit_Transfer.aspx.cs" Inherits="RBS.InterUnit_Transfer" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Cheque Transfer Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript" type="text/javascript">
		
		function validate()
		{
		if(trimAll(document.Form1.txtCNO.value)=="" || trimAll(document.Form1.lstBank.value)=="" || trimAll(document.Form1.txtCDT.value)=="" )
		{
		 alert("Bank ,Cheque No. & Cheque Date Cannot Be Left Blank");
		 event.returnValue=false;
		}
		}
		
		
		
		function validate2()
		{
		
		if (trimAll(document.Form1.txtAmt.value)=="" || IsNumeric(document.Form1.txtAmt.value) == false)
		{
		 alert("Amount Cannot Be Left Blank and Shld contain numeric values only!!!");
		 event.returnValue=false;
		}
		else if(trimAll(document.Form1.txtNarrat.value)!="" && document.Form1.txtNarrat.value.length > 50)
		 {
		 alert("Enter Narration Within 50 Characters!!!");
		 event.returnValue=false;
		 }
		else
		{
		document.Form1.btnSave1.style.visibility = 'hidden';
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
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
									BackColor="White" ForeColor="DarkBlue" Width="276px">INTER UNIT TRANSFERS</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 26px" align="center">
							<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 172px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" bgColor="#f0f8ff" border="1">
								<TBODY>
									<TR>
										<TD style="WIDTH: 3.75%; HEIGHT: 30px" vAlign="top" align="left">
											<asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="40px">Bank</asp:label></TD>
										<TD style="WIDTH: 35%; HEIGHT: 30px" vAlign="top"><asp:dropdownlist id="lstBank" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%"></asp:dropdownlist><asp:label id="lblBank" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="100%"></asp:label></TD>
										<TD style="WIDTH: 5.01%; HEIGHT: 30px" vAlign="top">
											<asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">Cheque No</asp:label></TD>
										<TD style="WIDTH: 6.29%; HEIGHT: 30px" vAlign="top"><asp:textbox id="txtCNO" style="TEXT-ALIGN: center" tabIndex="2" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="90%" MaxLength="10" Height="20px"></asp:textbox><asp:label id="lblCNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="100%"></asp:label><asp:button id="btnSearch" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
												Font-Bold="True" ForeColor="DarkBlue" Width="111px" Text="Search" onclick="btnSearch_Click"></asp:button></TD>
										<TD style="WIDTH: 1.36%; HEIGHT: 30px" vAlign="top"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">Cheque Date</asp:label></TD>
										<TD style="WIDTH: 15%; HEIGHT: 30px" vAlign="top">
											<asp:textbox id="txtCDT" onblur="check_date(txtCDT);" tabIndex="3" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="95%" MaxLength="10" Height="20px"></asp:textbox>
											<asp:label id="lblCDate" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="100%"></asp:label>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 9.52%" vAlign="top">
											<asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%"> RV Voucher No. & Date</asp:label></TD>
										<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.01%; COLOR: orangered; FONT-FAMILY: Verdana"
											vAlign="top"><asp:label id="lblVNo" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="35%"></asp:label>&nbsp;<asp:label id="lblAND" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue">&</asp:label>&nbsp;<asp:label id="lblVDT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="40%" Height="8px"></asp:label><asp:label id="lblSNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="35%" Visible="False"></asp:label></TD>
										<TD style="WIDTH: 15.44%" vAlign="top"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">JV No.</asp:label></TD>
										<TD style="WIDTH: 0%" vAlign="top"><asp:label id="lblJVNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="60%"></asp:label></TD>
										<TD style="WIDTH: 6.24%; HEIGHT: 9px" vAlign="top"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">JV Date.</asp:label></TD>
										<TD style="WIDTH: 12.08%; HEIGHT: 9px" vAlign="top"><asp:textbox id="txtVDT" onblur="check_date(txtVDT);" tabIndex="5" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="95%" MaxLength="10" Height="20px"></asp:textbox><asp:label id="lblJVDT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="100%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 12.87%; HEIGHT: 44px" vAlign="top">
											<P><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">Cheque Amount</asp:label></P>
										</TD>
										<TD style="WIDTH: 20.81%; HEIGHT: 44px" vAlign="top">
											<P><asp:label id="lblAmt" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Width="100%" Height="16px"></asp:label></P>
										</TD>
										<TD style="WIDTH: 13.28%; HEIGHT: 44px" vAlign="top">
											<P><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">Amount Transferred To Other Units</asp:label></P>
										</TD>
										<TD style="WIDTH: 17.27%; HEIGHT: 44px" vAlign="top">
											<P><asp:label id="lblAmtADJ" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Width="100%" Height="16px"></asp:label></P>
										</TD>
										<TD style="WIDTH: 4.13%; HEIGHT: 44px" vAlign="top"><asp:label id="Label15" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">Available Amount</asp:label></TD>
										<TD style="WIDTH: 0%; HEIGHT: 44px" vAlign="top"><asp:label id="lblSAmt" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="80%"></asp:label><asp:textbox id="txtSAmt" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana" Font-Size="8pt"
												BackColor="AliceBlue" ForeColor="AliceBlue" Width="1px" MaxLength="10" Height="1px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 13.07%; HEIGHT: 38px" vAlign="top"><asp:label id="Label20" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%"> Paying Authority</asp:label></TD>
										<TD style="WIDTH: 18.94%; HEIGHT: 38px" vAlign="top" colSpan="5">
											<DIV><asp:label id="lblCBPO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Width="100%" Height="16px"></asp:label></DIV>
										</TD>
									</TR>
									<TR align="center">
										<TD style="HEIGHT: 20px" colSpan="6"><FONT face="Verdana" color="#003300" size="1"><STRONG><asp:label id="lbldisplay" runat="server" Font-Names="Verdana" Font-Size="7pt" Font-Bold="True"
														ForeColor="DarkGreen" Width="100%">BREAKUP OF AMOUNT TRANSFERRED TO OTHER UNITS</asp:label></STRONG></FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 100%" vAlign="top" colSpan="6">
											<DIV><TITTLE:CUSTOMDATAGRID id="grdVDt" runat="server" Width="100%" Height="8px" BorderColor="DarkBlue" AutoGenerateColumns="False"
													PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
													BorderWidth="1px" FreezeColumns="0" FreezeHeader="False" GridHeight="200px" GridWidth="100%">
													<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
													<EditItemStyle Height="10%"></EditItemStyle>
													<FooterStyle CssClass="GridHeader"></FooterStyle>
													<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
													<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
														CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="Region to which Transferred">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id=HyperLink1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ACC_DESC")%>' NavigateUrl='<%#"InterUnit_Transfer.aspx?VCHR_NO=" + DataBinder.Eval(Container.DataItem,"VCHR_NO") + "&amp;ACC_CD=" + DataBinder.Eval(Container.DataItem,"ACC_CD")+ "&amp;BANK_CD="+DataBinder.Eval(Container.DataItem,"BANK_CD") + "&amp;CHQ_NO=" + DataBinder.Eval(Container.DataItem,"CHQ_NO")+ "&amp;CHQ_DT=" + DataBinder.Eval(Container.DataItem,"CHQ_DT") + "&amp;ACTION=M"%>'>HyperLink</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="AMOUNT" HeaderText="Amount">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NARRATION" HeaderText="Narration">
															<HeaderStyle Width="30%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="IU_ADV_NO" HeaderText="Inter Unit Advice No.">
															<HeaderStyle Width="20%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="IU_ADV_DT" HeaderText="Inter Unit Advice Date">
															<HeaderStyle Width="15%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="CHQ_NO" HeaderText="CHQ_NO"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="BANK_CD" HeaderText="BANK_CD"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="VCHR_NO" HeaderText="VCHR_NO"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" HeaderImageUrl="CHQ_DT" DataField="CHQ_DT"></asp:BoundColumn>
													</Columns>
												</TITTLE:CUSTOMDATAGRID></DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<asp:panel id="Panel1" runat="server" Height="150px">
								<TABLE id="Table5" style="WIDTH: 98%; HEIGHT: 100px" borderColor="#b0c4de" cellSpacing="1"
									cellPadding="1" width="655" bgColor="#f0f8ff" border="1">
									<TR>
										<TD style="WIDTH: 25.21%; HEIGHT: 20px" align="center">
											<P>
												<asp:label id="Label14" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Region to which Transferred</asp:label></P>
										</TD>
										<TD style="WIDTH: 15%; HEIGHT: 20px" align="center">
											<P>
												<asp:label id="Label18" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Amount</asp:label></P>
										</TD>
										<TD style="WIDTH: 25%; HEIGHT: 20px" align="center">
											<asp:label id="Label10" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Narration</asp:label></TD>
										<TD style="WIDTH: 22.24%; HEIGHT: 20px" align="center">
											<P>
												<asp:label id="Label17" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Inter Unit Advice No.</asp:label></P>
										</TD>
										<TD style="WIDTH: 14.32%; HEIGHT: 20px" align="center">
											<P>
												<asp:label id="Label12" runat="server" Width="119px" ForeColor="DarkBlue" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana">Inter Unit Advice Date.</asp:label></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 25.21%; HEIGHT: 20px" align="center">
											<asp:dropdownlist id="lstACD" tabIndex="6" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">
												<asp:ListItem Value="3007">Northern Region</asp:ListItem>
												<asp:ListItem Value="3008">Eastern Region</asp:ListItem>
												<asp:ListItem Value="3009">Southern Region</asp:ListItem>
												<asp:ListItem Value="3006">Western Region</asp:ListItem>
												<asp:ListItem Value="3066">Central Region</asp:ListItem>
												<asp:ListItem Value="9999">Bill Adjustment of Old System</asp:ListItem>
												<asp:ListItem Value="9998">Miscelleanous Adjustments</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD style="WIDTH: 15%; HEIGHT: 20px" align="center">
											<asp:textbox id="txtAmt" style="TEXT-ALIGN: center" tabIndex="7" runat="server" Width="90%" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="13"></asp:textbox></TD>
										<TD style="WIDTH: 25%; HEIGHT: 20px" align="center">
											<asp:textbox id="txtNarrat" style="TEXT-ALIGN: center" tabIndex="8" runat="server" Width="95%"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="30px" MaxLength="50" TextMode="MultiLine"></asp:textbox></TD>
										<TD style="WIDTH: 22.24%; HEIGHT: 20px" align="center">
											<asp:label id="txtRNo" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Height="16px"></asp:label></TD>
										<TD style="WIDTH: 14.32%; HEIGHT: 20px" align="center">
											<asp:label id="txtRDT" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Height="16px"></asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 594px" align="center" colSpan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:button id="btnAdd" tabIndex="9" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Text="AddNew" onclick="btnAdd_Click"></asp:button>
											<asp:button id="btnSave1" tabIndex="10" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave1_Click"></asp:button>
											<asp:button id="btnDelete" tabIndex="11" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Text="Delete" onclick="btnDelete_Click"></asp:button>
											<asp:button id="btnCancel" tabIndex="12" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button>
											<asp:label id="lblIUAMT" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Visible="False">Amount</asp:label></TD>
									</TR>
								</TABLE>
							</asp:panel>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
