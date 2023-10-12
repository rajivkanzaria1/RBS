<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bill_Finalisation_Form.aspx.cs" Inherits="RBS.Bill_Finalisation_Form.Bill_Finalisation_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Bill_Finalisation_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="False">
				<asp:Button id="btnPrint" runat="server" Text="Print"></asp:Button>
				<INPUT id="Button1" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px">
				<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 152px"
					cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TBODY>
						<TR>
							<TD style="HEIGHT: 43px" align="center" colSpan="5">
								<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 100%; HEIGHT: 29px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">BILLS 
										FINALISATION FOR THE PERIOD </FONT></B>
							</TD>
						</TR>
						<TR bgColor="#f0f8ff">
							<TD style="WIDTH: 33.09%; HEIGHT: 52px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">For 
										The Period --&gt;</FONT></B></TD>
							<TD style="WIDTH: 10.52%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">From</FONT></B></TD>
							<TD style="WIDTH: 9.37%; HEIGHT: 52px">
								<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
									style="TEXT-ALIGN: center" tabIndex="3" runat="server" Height="20px" Width="100px" MaxLength="10"
									Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"></asp:textbox></TD>
							<TD style="WIDTH: 6.76%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">To</FONT></B></TD>
							<TD style="WIDTH: 30%; HEIGHT: 52px">
								<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
									style="TEXT-ALIGN: center" tabIndex="4" runat="server" Height="20px" Width="100px" MaxLength="10"
									Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"></asp:textbox></TD>
						</TR>
						<TR bgColor="#f0f8ff">
							<TD style="WIDTH: 33.09%; HEIGHT: 52px" align="right" colSpan="2"><B><FONT face="Verdana" color="darkblue" size="2">Sector 
										--&gt;</FONT></B></TD>
							<TD style="WIDTH: 10.52%; HEIGHT: 52px" align="left" colSpan="3">
								<asp:dropdownlist id="lstClientType1" tabIndex="18" runat="server" Width="20%" Font-Size="8pt" Font-Names="Verdana"
									ForeColor="DarkBlue"></asp:dropdownlist></TD>
						</TR>
						<TR bgColor="#f0f8ff">
							<TD align="center" colSpan="5">
								<asp:label id="Label5" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkMagenta"
									Font-Bold="True">* Enter Date in DD/MM/YYYY Format.</asp:label></TD>
						</TR>
						<TR bgColor="#f0f8ff">
							<TD align="center" colSpan="5">
								<asp:button id="btnSubmit" runat="server" Text="Submit" ForeColor="DarkBlue" Font-Bold="True"
									BackColor="#C0C0FF" onclick="btnSubmit_Click"></asp:button></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="5">
								<DIV>
									<TITTLE:CUSTOMDATAGRID id="grdCDetails_1" tabIndex="20" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana"
										BackColor="White" PageSize="1" CellPadding="2" BorderColor="Navy" AutoGenerateColumns="False" FreezeRows="0"
										GridHeight="600px" FreezeHeader="True" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
										FreezeColumns="0" BorderStyle="Groove">
										<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle Font-Size="7pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
										<EditItemStyle Font-Size="8pt"></EditItemStyle>
										<FooterStyle Wrap="False" CssClass="GridHeader"></FooterStyle>
										<ItemStyle Font-Size="7pt" Font-Names="Verdana" HorizontalAlign="Center" CssClass="GridNormal"></ItemStyle>
										<HeaderStyle Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
											ForeColor="DarkBlue" CssClass="GridHeader" VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="S_NO" HeaderText="S No.">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="BILL_NO" ReadOnly="True" HeaderText="Bill No.">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="BILL_DATE" ReadOnly="True" HeaderText="Bill Dt">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="INSP_FEE" ReadOnly="True" HeaderText="Insp Fee">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SGST" HeaderText="SGST">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CGST" HeaderText="CGST">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IGST" HeaderText="IGST">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="BILL_AMOUNT" ReadOnly="True" HeaderText="Bill Amount">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="BPO" ReadOnly="True" HeaderText="BPO">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CONSIGNEE" ReadOnly="True" HeaderText="CONSIGNEE">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RECIPIENT_GSTIN_NO" ReadOnly="True" HeaderText="GSTIN No.">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Finalisation">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemTemplate>
													<asp:CheckBox id="chkBFinal" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</TITTLE:CUSTOMDATAGRID></DIV>
							</TD>
						</TR>
						<TR>
							<TD align="center" colSpan="5">
								<asp:button id="btnUpdate" runat="server" Visible="False" Text="Update Bills Finalisation Status &amp; Date"
									ForeColor="DarkBlue" Font-Bold="True" BackColor="#C0C0FF" onclick="btnUpdate_Click"></asp:button></TD>
						</TR>
			</asp:panel></TBODY></TABLE>
		</form>
	</body>
</HTML>
