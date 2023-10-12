<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Incoming_Dak_Form.aspx.cs" Inherits="RBS.Incoming_Dak_Form.Incoming_Dak_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Incoming_Dak_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 21px" align="center">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<tr>
					<td align="center"><asp:label id="Label1" runat="server" Width="253px" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt"
							Font-Names="Verdana" BackColor="White">INCOMING DAK MASTER FORM</asp:label></td>
				</tr>
				<TR>
					<TD align="center">
						<TABLE id="Table4" borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="90%" bgColor="#f0f8ff"
							border="1">
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Letter 
									ID</td>
								<td style="WIDTH: 70%; HEIGHT: 9px"><asp:label id="lblLetterID" runat="server" Width="90%" Font-Bold="True" ForeColor="OrangeRed"
										Font-Size="8pt" Font-Names="Verdana"></asp:label></td>
							</tr>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Receiving 
									Date&nbsp;</TD>
								<TD style="WIDTH: 70%"><asp:textbox id="txtRecDT" onblur="check_date(txtRecDT)" tabIndex="1" runat="server" Width="20%"
										Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Letter 
									No.</TD>
								<TD style="WIDTH: 70%"><asp:textbox id="txtLetterNo" onblur="check_date(txtRefReplyDt)" tabIndex="2" runat="server"
										Width="100%" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Receiving 
									Mode</TD>
								<TD style="WIDTH: 70%"><asp:dropdownlist id="lstRecMode" tabIndex="3" runat="server" Width="30%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="F">FAX</asp:ListItem>
										<asp:ListItem Value="C">Courier</asp:ListItem>
										<asp:ListItem Value="H">Hand Delivery</asp:ListItem>
										<asp:ListItem Value="E">E-Mail</asp:ListItem>
										<asp:ListItem Value="O">Others</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 30px">From 
									(Category/Sub-Category)</TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:dropdownlist id="lstCategory" tabIndex="4" runat="server" Width="40%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" AutoPostBack="True">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="1">RITES</asp:ListItem>
										<asp:ListItem Value="2">Railway</asp:ListItem>
										<asp:ListItem Value="3">Non  Railway</asp:ListItem>
										<asp:ListItem Value="4">Vendor</asp:ListItem>
										<asp:ListItem Value="5">Staff</asp:ListItem>
										<asp:ListItem Value="6">Vigilance</asp:ListItem>
										<asp:ListItem Value="7">Other</asp:ListItem>
									</asp:dropdownlist>&nbsp;&nbsp;
									<asp:dropdownlist id="lstSubCategory" tabIndex="5" runat="server" Width="40%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="Q">QA CO</asp:ListItem>
										<asp:ListItem Value="R">Other Regions</asp:ListItem>
										<asp:ListItem Value="P">P&amp;A</asp:ListItem>
										<asp:ListItem Value="F">Finance</asp:ListItem>
										<asp:ListItem Value="O">Other SBUs</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Subject</TD>
								<TD style="WIDTH: 70%"><asp:textbox id="txtSubject" tabIndex="6" runat="server" Width="100%" Font-Bold="True" ForeColor="Blue"
										Font-Size="8pt" Font-Names="Verdana" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Letter 
									Type Category</TD>
								<TD style="WIDTH: 70%"><asp:dropdownlist id="lstLetterType" tabIndex="7" runat="server" Width="98%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="DO">DO</asp:ListItem>
										<asp:ListItem Value="IN">Instruction</asp:ListItem>
										<asp:ListItem Value="PO">PO</asp:ListItem>
										<asp:ListItem Value="SP">Specification</asp:ListItem>
										<asp:ListItem Value="RA">Rejection Advise</asp:ListItem>
										<asp:ListItem Value="CP">Complaint</asp:ListItem>
										<asp:ListItem Value="CL">Claim</asp:ListItem>
										<asp:ListItem Value="AP">APAR</asp:ListItem>
										<asp:ListItem Value="RP">Representation</asp:ListItem>
										<asp:ListItem Value="RD">Reminder</asp:ListItem>
										<asp:ListItem Value="OT">Others</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 23px">Special 
									Category</TD>
								<TD style="WIDTH: 70%; HEIGHT: 23px"><asp:dropdownlist id="lstSpecialCategory" tabIndex="8" runat="server" Width="98%" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana">
										<asp:ListItem></asp:ListItem>
										<asp:ListItem Value="1">CMD</asp:ListItem>
										<asp:ListItem Value="2">Director</asp:ListItem>
										<asp:ListItem Value="3">ED</asp:ListItem>
										<asp:ListItem Value="4">GM</asp:ListItem>
										<asp:ListItem Value="5">CME</asp:ListItem>
										<asp:ListItem Value="6">COS</asp:ListItem>
										<asp:ListItem Value="7">Unit Head Letter</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 17px">Reciept 
									By CM</TD>
								<TD style="WIDTH: 70%; HEIGHT: 17px"><asp:dropdownlist id="lstRecCM" tabIndex="9" runat="server" Width="98%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Marked 
									To CM</TD>
								<TD style="WIDTH: 70%"><asp:dropdownlist id="lstMarCM" tabIndex="10" runat="server" Width="98%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 20px">Special 
									Remarks.</TD>
								<TD style="WIDTH: 70%; HEIGHT: 20px"><asp:textbox id="txtRemarks" tabIndex="11" runat="server" Width="100%" Font-Bold="True" ForeColor="Blue"
										Font-Size="8pt" Font-Names="Verdana" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"></TD>
								<TD style="WIDTH: 70%"><asp:button id="btnSave" tabIndex="12" runat="server" Width="67px" Font-Bold="True" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Text="Save"></asp:button><asp:button id="btnCancel" tabIndex="13" runat="server" Width="67px" Font-Bold="True" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Text="Cancel"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
