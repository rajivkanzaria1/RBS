<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab_Sample_Info_Details.aspx.cs" Inherits="RBS.Lab_Sample_Info_Details.Lab_Sample_Info_Details" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lab_Sample_Info</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		
		function makeUppercase()
		 {
			document.Form1.txtCaseNo.value = document.Form1.txtCaseNo.value.toUpperCase();
			
		 }
		 
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 35px" align="center" colSpan="6" height="35"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 264px" align="center" colSpan="5">
						<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="1"
							cellPadding="1" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 21px" vAlign="top"><asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> Case No. </asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 21px" vAlign="top"><asp:label id="lblCaseNo" runat="server" Width="60%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 21px" vAlign="top"><asp:label id="Label9" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Call Date & Sno.</asp:label></TD>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 25%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 21px"
									vAlign="top"><asp:label id="lblCallDT" runat="server" Width="80px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label>&nbsp;&amp;
									<asp:label id="lblCSNO" runat="server" Width="32px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label10" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Vendor </asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top" colSpan="3"><asp:label id="lblVend" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label><asp:label id="lblVENDCD" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label7" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">IE</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="lblIE" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:label id="lblIECD" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label5" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Date of Receipt of Sample</asp:label></TD>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 25%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 19px"
									vAlign="top"><asp:textbox id="txtSampleReceiptDT" onblur="check_date(txtSampleReceiptDT);" tabIndex="4" runat="server"
										Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox><asp:label id="lblSampleReceiptDT" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label26" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Total Testing Fee (incl of Taxes)</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtTestingFee" style="TEXT-ALIGN: center" tabIndex="18" runat="server" Width="25%"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="13"></asp:textbox></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:label id="Label27" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Likely Date of Test Report</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 19px" vAlign="top"><asp:textbox id="txtLikelyTRDt" onblur="check_date(txtLikelyTRDt);" tabIndex="4" runat="server"
										Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 24px" vAlign="top"><asp:label id="Label1" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Status</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 24px" vAlign="top" colSpan="3"><asp:dropdownlist id="lstStatus" tabIndex="6" runat="server" Width="300px" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="lstStatus_SelectedIndexChanged">
										<asp:ListItem Value="S">Sample Recieved</asp:ListItem>
										<asp:ListItem Value="C">Lab Report under Compilation</asp:ListItem>
										<asp:ListItem Value="U">Lab Report Uploaded</asp:ListItem>
										<asp:ListItem Value="O">Others</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top"><asp:label id="Label36" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Remarks</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top" colSpan="3"><asp:textbox id="txtRemarks" tabIndex="11" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Height="50px" MaxLength="400" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top"><asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Payment Slip Uploaded By Vendor</asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top" colSpan="3"><asp:label id="lblVendPaymentSlip" runat="server" Width="152px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label><asp:hyperlink id="Hyperlink2" runat="server" Visible="False" Target="_blank">HyperLink</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top"><asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Payment Status By Finance (RITES) </asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top" colSpan="3"><asp:label id="lblPaymentApp" runat="server" Width="60%" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top"><asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Upload Lab Report <FONT COLOR="OrangeRed">(In PDF Only)</FONT></asp:label></TD>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top" colSpan="3"><INPUT id="File2" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
										tabIndex="0" type="file" size="51" name="File1" runat="server"><asp:hyperlink id="HyperLink1" runat="server" Visible="False" Target="_blank">HyperLink</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%; HEIGHT: 23px" vAlign="top" align="center" colSpan="4"><asp:button id="btnSave" tabIndex="6" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Visible="False" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="Btnupd" tabIndex="6" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Visible="False" Text="Update" onclick="Btnupd_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
