<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clients_Contact.aspx.cs" Inherits="RBS.Clients_Contact.Clients_Contact" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Clients_Contact</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.toDt.value)=="")
		 {
		  alert("Select Date of visit");
		 event.returnValue=false;
		 }
		 
		else if(trimAll(document.Form1.lstClientType.value)=="")
		 {
		  alert("Select Client Type");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.lstBPO_Rly.value)=="")
		 {
		  alert("Select Client ");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtName.value=="")
		 {
		 alert("OFFICER NAME CONTACTED CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.txtdesig.value=="")
		 {
		 alert("DESIGNATION CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.Textoutcome.value=="")
		 {
		 alert("OUTCOME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.lstCOCD.value=="")
		 {
		 alert("SELECT CONTROLLING OFFICER NAME");
		 event.returnValue=false;
		 }
		 else 
		return;
			
		}
		function integersOnly(obj) {
         obj.value = obj.value.replace(/[^0-9-.]/g,'');
         }
        </script>
	</HEAD>
	<body bgColor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 123px; TOP: 8px; LEFT: 8px" id="Table1"
				border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD>
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center"><asp:label id="Label1" runat="server" Width="100%" Font-Bold="True" Font-Size="10pt" Font-Names="Verdana"
								ForeColor="DarkBlue">PCDO</asp:label></TD>
					</TR>
					</TD></TR>
					<TR>
						<TD style="WIDTH: 50%" align="center">
							<TABLE style="WIDTH: 100%; HEIGHT: 100%" id="Table4" border="1" cellSpacing="0" borderColor="#b0c4de"
								cellPadding="0" bgColor="aliceblue">
								<TBODY>
									<TR bgColor="#f0f8ff">
										<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><B><FONT color="darkblue" size="2" face="Verdana"><asp:label id="Label5" runat="server" Width="138px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
														ForeColor="DarkBlue">Date of Visit<font color="red" size="1">*</font> </asp:label></FONT></B></TD>
										<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><B><FONT color="darkblue" size="2" face="Verdana"></FONT></B><asp:textbox onblur="check_date(toDt)" style="TEXT-ALIGN: center" id="toDt" tabIndex="4" runat="server"
												Width="100px" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" Height="20px" MaxLength="10"></asp:textbox>&nbsp;
											<asp:label id="Label9" runat="server" Width="289px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkMagenta">* Enter Date in DD/MM/YYYY Format.</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 30%; HEIGHT: 28px"><asp:label id="Label6" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkBlue">Client Type<font color="red" size="1">*</font> </asp:label></TD>
										<TD style="WIDTH: 70%" colSpan="3"><asp:dropdownlist id="lstClientType" tabIndex="1" runat="server" Width="20%" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkBlue" AutoPostBack="True" onselectedindexchanged="lstClientType_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 30%; HEIGHT: 34px"><asp:label id="Label2" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkBlue">Select Client<font color="red" size="1">*</font> </asp:label></TD>
										<TD style="WIDTH: 70%; HEIGHT: 34px" colSpan="3"><asp:dropdownlist id="lstBPO_Rly" tabIndex="2" runat="server" Width="98%" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkBlue" AutoPostBack="True" onselectedindexchanged="lstBPO_Rly_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 30%; HEIGHT: 34px"><asp:label id="Label4_OC" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkBlue" Visible="False">Other Client<font color="red" size="1">*</font> </asp:label></TD>
										<TD style="WIDTH: 70%; HEIGHT: 34px" colSpan="3"><asp:textbox id="Textbox_OC" tabIndex="2" runat="server" Width="90%" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkBlue" Height="20px" MaxLength="50" Visible="False"></asp:textbox></TD>
									</TR>
					</TR>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><asp:label id="Label4" runat="server" Width="100%" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">Officer Name contacted <font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="txtName" tabIndex="2" runat="server" Width="90%" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" Height="20px" MaxLength="100"></asp:textbox></TD>
					<TR>					
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><asp:label id="Label3" runat="server" Width="100%" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">Designation<font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="txtdesig" tabIndex="2" runat="server" Width="90%" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" Height="20px" MaxLength="50"></asp:textbox></TD>
					<TR>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 40px" align="left"><asp:label id="Label_AMT" runat="server" Width="100%" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">Outstanding Amount(In Rs.) <font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 40px" colSpan="4" align="left"><asp:textbox id="Textamt" onkeyup="integersOnly(this)" MaxLength="13" Runat="server"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><asp:label id="Label7" runat="server" Width="100%" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">RITES CONTROLLING OFFICER<font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:dropdownlist id="lstCOCD" tabIndex="9" runat="server" Width="60%" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" Height="25px"></asp:dropdownlist></TD>
					<TR>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><asp:label id="Label8" runat="server" Width="100%" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">HIGHLIGHTS OF DISCUSSION, if any</asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="Texthigh" tabIndex="2" runat="server" Width="90%" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" Height="50px" MaxLength="500"></asp:textbox></TD>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><asp:label id="Label10" runat="server" Width="100%" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">OVERALL OUTCOME OF THE VISIT<font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="Textoutcome" tabIndex="2" runat="server" Width="90%" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" Height="50px" MaxLength="500"></asp:textbox></TD>
					<TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 21px" colSpan="2" align="center"><asp:button id="btnSave" tabIndex="23" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnEdit" tabIndex="24" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" Visible="False" Text="Edit"></asp:button><asp:button id="btnCancel" tabIndex="26" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue" Text="Cancel"></asp:button></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
