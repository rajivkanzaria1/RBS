<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab_Payments_Form.aspx.cs" Inherits="RBS.Lab_Payments_Form.Lab_Payments_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lab_Payments_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
			
		function validate()
		{
			if(trimAll(document.Form1.txtCNO.value)=="")
			{
				alert("ENTER CHQ NO.!!!");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtCDT.value)=="")
			{
				alert("ENTER CHQ DATE!!!");
				event.returnValue=false;
			}
			else if (document.Form1.lstBank.value=="")
			{
				alert("SELECT THE BANK!!!");
				event.returnValue=false;
			
			}
			else if (document.Form1.txtAmt.value=="")
			{
				alert("ENTER THE AMOUNT!!!");
				event.returnValue=false;
			
			}
			else
			{
				return;
				document.Form1.btnSave1.style.visibility = 'hidden';
			}
		}
		
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 21px" align="center">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<tr>
					<td style="HEIGHT: 17px" align="center"><asp:label id="Label1" runat="server" BackColor="White" Font-Names="Verdana" Font-Size="10pt"
							ForeColor="DarkBlue" Font-Bold="True" Width="311px"> EXTERNAL LABORATORY PAYMENT FORM</asp:label></td>
				</tr>
				<TR>
					<TD align="center">
						<TABLE id="Table4" borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="90%" bgColor="#f0f8ff"
							border="1">
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">LAB</td>
								<td style="WIDTH: 70%; HEIGHT: 9px"><asp:dropdownlist id="lstLab" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="100%"></asp:dropdownlist></td>
							</tr>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
									align="center" colSpan="2"><asp:button id="btnSubmit" tabIndex="18" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Font-Bold="True" Width="66px" Text="Submit" onclick="btnSubmit_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><TITTLE:CUSTOMDATAGRID id="grdLabDt" runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="150px"
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
								<asp:TemplateColumn HeaderText="SNo.">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkBox" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="SAMPLE_REG_NO" HeaderText="Sample Reg No"></asp:BoundColumn>
								<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No"></asp:BoundColumn>
								<asp:BoundColumn DataField="TOT_CHARGES" HeaderText="Total Lab Charges"></asp:BoundColumn>
								<asp:BoundColumn DataField="TDS_AMT" HeaderText="TDS AMT"></asp:BoundColumn>
								<asp:BoundColumn DataField="TESTING_FEE" HeaderText="Fees+S.T.">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AMT_CLEARED" HeaderText="Amount Cleared"></asp:BoundColumn>
								<asp:BoundColumn DataField="CHQ_NO" HeaderText="Instrument No"></asp:BoundColumn>
								<asp:BoundColumn DataField="CHQ_DT" HeaderText="Instrument Dt"></asp:BoundColumn>
								<asp:BoundColumn DataField="AMOUNT" HeaderText="Instrument Amt"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SNO" HeaderText="SNO"></asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
				<TR>
					<TD align="center" style="HEIGHT: 76px"><asp:button id="btnCalculateAmt" tabIndex="18" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True" Width="161px" Text="Proceed For Payment" onclick="btnCalculateAmt_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center"><asp:panel id="Panel_1" runat="server" Width="100%" Height="1px" Visible="False">
							<TABLE id="Table5" style="WIDTH: 100%; HEIGHT: 96px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center">
										<asp:label id="Label6" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Payment No.</asp:label></TD>
									<TD style="WIDTH: 16.24%; HEIGHT: 20px" align="center">
										<asp:label id="lblPaymentNO" runat="server" Width="60%" Font-Bold="True" ForeColor="OrangeRed"
											Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
									<TD style="WIDTH: 31.11%; HEIGHT: 20px" align="center"></TD>
									<TD style="WIDTH: 17.21%; HEIGHT: 20px" align="center">
										<asp:label id="Label2" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Payment Date </asp:label></TD>
									<TD style="WIDTH: 20%; HEIGHT: 20px" align="center">
										<asp:label id="lblPaymentDT" runat="server" Width="60%" Font-Bold="True" ForeColor="OrangeRed"
											Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label4" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Instrument No</asp:label></P>
									</TD>
									<TD style="WIDTH: 16.24%; HEIGHT: 20px" align="center">
										<asp:label id="Label5" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Instrument Date</asp:label></TD>
									<TD style="WIDTH: 31.11%; HEIGHT: 20px" align="center">
										<asp:label id="Label11" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Bank</asp:label></TD>
									<TD style="WIDTH: 17.21%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label7" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Amount</asp:label></P>
									</TD>
									<TD style="WIDTH: 20%; HEIGHT: 20px" align="center">
										<asp:label id="Label3" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Remarks</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtCNO" style="TEXT-ALIGN: center" tabIndex="4" runat="server" Width="95%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
									<TD style="WIDTH: 16.24%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtCDT" onblur="check_date(txtCDT);" style="TEXT-ALIGN: center" tabIndex="5"
											runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px"
											MaxLength="11"></asp:textbox></TD>
									<TD style="WIDTH: 31.11%; HEIGHT: 24px" align="center">
										<asp:dropdownlist id="lstBank" tabIndex="6" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"></asp:dropdownlist></TD>
									<TD style="WIDTH: 17.21%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtAmt" style="TEXT-ALIGN: center" tabIndex="7" runat="server" Width="95%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="13"></asp:textbox></TD>
									<TD style="WIDTH: 20%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtNarrat" style="TEXT-ALIGN: center" tabIndex="14" runat="server" Width="95%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="30px" MaxLength="50" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="5">
										<asp:button id="btnSave" tabIndex="15" runat="server" Width="66px" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button>
										<asp:button id="btnSave1" tabIndex="15" runat="server" Width="66px" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave1_Click"></asp:button>
										<asp:button id="btnPrint" tabIndex="19" runat="server" Width="65px" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Text="Print" onclick="btnPrint_Click"></asp:button>
										<asp:button id="btnCancel" tabIndex="20" runat="server" Width="67px" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</asp:panel></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
