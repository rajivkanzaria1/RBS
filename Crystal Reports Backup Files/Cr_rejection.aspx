<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cr_rejection.aspx.cs" Inherits="RBS.Cr_rejection.Cr_rejection" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Cr_rejection</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		 if(document.Form1.Texcaseno.value=="")
		 {
		 alert("CASE NO CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.Textcon.value=="")
		 {
		 alert("CONSIGNEE/RAILWAY CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.Textdes.value=="")
		 {
		 alert("DESCRIPTION OF COMPLAINTS CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.Textaction.value=="")
		 {
		 alert("CONCLUSION/ACTION TAKEN CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		}
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				borderColor="#b0c4de" cellSpacing="0" cellPadding="0" bgColor="aliceblue" border="1"
				WIDTH="100%" HEIGHT="100%">
				<TBODY>
					<TR>
						<TD colspan="5">
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colspan="5">
							<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="274px" BackColor="White" ForeColor="DarkBlue"
									Font-Size="10pt" Font-Names="Verdana">Rejection Status</asp:label></P>
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
													Case No.--&gt;<font color="red" size="1">*</font></FONT></B></TD>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="left" colspan="4"><B><FONT face="Verdana" color="darkblue" size="2">
													<asp:TextBox ID="Texcaseno" Runat="server" MaxLength="20" Width="90%" Height="30"></asp:TextBox></FONT></B></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">
													Consignee/Railway--&gt;<font color="red" size="1">*</font></FONT></B></TD>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="left" colspan="4"><B><FONT face="Verdana" color="darkblue" size="2">
													<asp:TextBox ID="Textcon" Runat="server" MaxLength="100" Width="90%" Height="50" TextMode="MultiLine"></asp:TextBox></FONT></B></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">
													Description of Complaints--&gt;<font color="red" size="1">*</font></FONT></B></TD>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="left" colspan="4"><B><FONT face="Verdana" color="darkblue" size="2">
													<asp:TextBox ID="Textdes" Runat="server" MaxLength="200" Width="90%" Height="80" TextMode="MultiLine"></asp:TextBox></FONT></B></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">
													Conclusion/Action taken--&gt;<font color="red" size="1">*</font></FONT></B></TD>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="left" colspan="4"><B><FONT face="Verdana" color="darkblue" size="2">
													<asp:TextBox ID="Textaction" Runat="server" MaxLength="500" Width="90%" Height="150" TextMode="MultiLine"></asp:TextBox></FONT></B></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 100%; HEIGHT: 30px" align="center" colspan="5"><B><FONT face="Verdana" color="darkblue" size="2">
													<font color="red" size="1">* Kindly Enter Rejection status for each month.</font></FONT></B></TD>
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
