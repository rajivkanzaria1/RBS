﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Billing_Adjustment_Form.aspx.cs" Inherits="RBS.Billing_Adjustment_Form.Billing_Adjustment_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Billing_Adjustment_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		 if(document.Form1.TextExpamt.value=="")
		 {
		 alert("EXPENDITURE AMOUNT CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.Texttaxamt.value=="")
		 {
		 alert("TAX AMOUNT CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		}
		
         function integersOnly(obj) {
         obj.value = obj.value.replace(/[^0-9-.]/g,'');
         }
        </script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				borderColor="#b0c4de" cellSpacing="0" cellPadding="0" bgColor="aliceblue" border="1">
				<TBODY>
					<TR>
						<TD colspan="5">
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colspan="5">
							<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="274px" BackColor="White" ForeColor="DarkBlue"
									Font-Size="10pt" Font-Names="Verdana">BILLING ADJUSTEMENT FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 50%" align="center">
							<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 100%" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="0" bgColor="aliceblue" border="1">
								<TBODY>
									<TR bgColor="#f0f8ff">
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">For 
													The Period --&gt;</FONT></B></TD>
										<TD style="WIDTH: 10%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">Month</FONT></B></TD>
										<TD style="WIDTH: 10%; HEIGHT: 61px">
											<asp:dropdownlist id="lstMonths" runat="server" Font-Names="Verdana" ForeColor="DarkBlue">
												<asp:ListItem Value="01" Selected="True">January</asp:ListItem>
												<asp:ListItem Value="02">February</asp:ListItem>
												<asp:ListItem Value="03">March</asp:ListItem>
												<asp:ListItem Value="04">April</asp:ListItem>
												<asp:ListItem Value="05">May</asp:ListItem>
												<asp:ListItem Value="06">June</asp:ListItem>
												<asp:ListItem Value="07">July</asp:ListItem>
												<asp:ListItem Value="08">August</asp:ListItem>
												<asp:ListItem Value="09">September</asp:ListItem>
												<asp:ListItem Value="10">October</asp:ListItem>
												<asp:ListItem Value="11">November</asp:ListItem>
												<asp:ListItem Value="12">December</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD style="WIDTH: 10%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">Year</FONT></B></TD>
										<TD style="WIDTH: 30%; HEIGHT: 61px">
											<asp:dropdownlist id="lstYear" runat="server" Font-Names="Verdana" ForeColor="DarkBlue"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">
													Adjustment&nbsp;Amount Fee(In Rs.) --&gt;<font color="red" size="1">*</font></FONT></B></TD>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="left" colspan="4"><B><FONT face="Verdana" color="darkblue" size="2">
													<asp:TextBox ID="TextExpamt" Runat="server" MaxLength="13" onkeyup="integersOnly(this)"></asp:TextBox><font color="red" size="1">(Only 
														Numeric Value Allowed)</font></FONT></B></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right">
											<P><B><FONT face="Verdana" color="darkblue" size="2">&nbsp;Remarks </FONT></B><B><FONT face="Verdana" color="darkblue" size="2">
														<FONT color="red" size="1">(500 Chars Only) --&gt;<FONT color="red" size="1">*</FONT></FONT>&nbsp;</FONT></B></P>
										</TD>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="left" colSpan="4">
											<asp:TextBox id="txtRemarks" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="696px" TextMode="MultiLine" Height="67px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 100%; HEIGHT: 30px" align="center" colspan="5"><B><FONT face="Verdana" color="darkblue" size="2">
													<font color="red" size="1">* Kindly Enter Billing Adjustment&nbsp;for each month to 
														calculate the Cummulative Figures in PCDO Reports for the Last &amp; Current 
														Year.</font></FONT></B></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 100%; HEIGHT: 21px" align="center" colspan="5"><asp:button id="btnSave" tabIndex="23" runat="server" Font-Bold="True" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnEdit" tabIndex="24" runat="server" Font-Bold="True" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Text="Edit" Visible="False" onclick="btnEdit_Click"></asp:button><asp:button id="btnCancel" tabIndex="26" runat="server" Font-Bold="True" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
