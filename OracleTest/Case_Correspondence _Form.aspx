<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Case_Correspondence _Form.aspx.cs" Inherits="RBS.Case_Correspondence__Form.Case_Correspondence__Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Case_Correspondence _Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 184px"
				cellSpacing="1" cellPadding="1" border="0">
				<TBODY>
					<TR>
						<TD>
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 33px" align="center">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
									BackColor="White" Width="307px" Font-Bold="True" Height="19px">CASE CORRESPONDENCE FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<td style="WIDTH: 100%" align="center">
							<P align="center">
								<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1"
									cellPadding="1" width="935" bgColor="#f0f8ff" border="1">
									<TR>
										<TD style="WIDTH: 3.9%"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Font-Bold="True">Case Number</asp:label></TD>
										<TD style="WIDTH: 15%" align="left"><asp:textbox id="txtCsNo" onblur="makeUppercase();" tabIndex="1" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" BackColor="LavenderBlush" Width="20%" Height="20px" MaxLength="9"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 3.9%"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Font-Bold="True">Correspondence Date</asp:label></TD>
										<TD style="WIDTH: 15%" align="left"><asp:textbox id="txtCDate" onblur="check_date(txtCDate);" tabIndex="3" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" BackColor="White" Width="20%" Height="20px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 3.9%"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Font-Bold="True">Remarks</asp:label></TD>
										<TD style="WIDTH: 15%" align="left"><asp:textbox id="txtRemarks" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue"
												Width="100%" Font-Bold="True" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 3.9%"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Font-Bold="True">Select the Correpondence Scanned file here</asp:label></TD>
										<TD style="WIDTH: 15%" align="left"><INPUT id="File1" style="FONT-SIZE: 8pt; WIDTH: 424px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 22px"
												tabIndex="23" type="file" size="51" name="File1" runat="server"></TD>
									</TR>
								</TABLE>
							</P>
							<asp:button id="btnSubmit" tabIndex="28" runat="server" ForeColor="DarkBlue" BackColor="#C0C0FF"
								Font-Bold="True" Text="Submit"></asp:button></td>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>

