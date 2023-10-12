<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BE_Target_Form.aspx.cs" Inherits="RBS.BE_Target_Form.BE_Target_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BE_Target_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		 if(document.Form1.Textbillamt.value=="")
		 {
		 alert("BILL TARGET AMOUNT CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.Textexpamt.value=="")
		 {
		 alert("OR TARGET AMOUNT CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.Textex.value=="")
		 {
		 alert("EXPENDITURE TARGET AMOUNT CANNOT BE LEFT BLANK");
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
				borderColor="#b0c4de" cellSpacing="0" cellPadding="0" bgColor="aliceblue" border="1"
				WIDTH="100%" HEIGHT="100%">
				<TBODY>
					<TR>
						<TD colSpan="5">
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="5">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
									BackColor="White" Width="274px" Font-Bold="True">Billing and Operating Ratio Target(Yearly)</asp:label></P>
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
										<TD style="WIDTH: 10%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">Year</FONT></B></TD>
										<TD style="WIDTH: 50%; HEIGHT: 61px"><asp:dropdownlist id="lstYear" runat="server" Font-Names="Verdana" ForeColor="DarkBlue"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">Billing 
													Target Amount (In lac of Rs.) --&gt;<font color="red" size="1">*</font></FONT></B></TD>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="left" colSpan="4"><B><FONT face="Verdana" color="darkblue" size="2"><asp:textbox id="Textbillamt" onkeyup="integersOnly(this)" MaxLength="13" Runat="server"></asp:textbox><font color="red" size="1">(Only 
														Numeric Value Allowed)</font></FONT></B></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">Operating 
													Ratio Target&nbsp; --&gt;<font color="red" size="1">*</font></FONT></B></TD>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="left" colSpan="4"><B><FONT face="Verdana" color="darkblue" size="2"><asp:textbox id="Textexpamt" onkeyup="integersOnly(this)" MaxLength="13" Runat="server"></asp:textbox><font color="red" size="1">(Only 
														Numeric Value Allowed)</font></FONT></B></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">
													Expenditure Target Amount (In lac of Rs.)&nbsp; --&gt;<font color="red" size="1">*</font></FONT></B></TD>
										<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="left" colSpan="4"><B><FONT face="Verdana" color="darkblue" size="2"><asp:textbox id="Textex" onkeyup="integersOnly(this)" MaxLength="13" Runat="server"></asp:textbox><font color="red" size="1">(Only 
														Numeric Value Allowed)</font></FONT></B></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 100%; HEIGHT: 30px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2"><font color="red" size="1">* 
														Kindly Enter Bill and OR Target for each year to calculate the Cummulative 
														Figures in PCDO Reports for the Last &amp; Current Year.</font></FONT></B></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 100%; HEIGHT: 21px" align="center" colSpan="5"><asp:button id="btnSave" tabIndex="23" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnEdit" tabIndex="24" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Font-Bold="True" Text="Edit" Visible="False" onclick="btnEdit_Click"></asp:button><asp:button id="btnCancel" tabIndex="26" runat="server" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
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

