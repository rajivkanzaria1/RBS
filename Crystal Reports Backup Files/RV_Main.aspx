<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RV_Main.aspx.cs" Inherits="RBS.RV_Main.RV_Main" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Voucher Edit Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<BODY bgColor="white">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtVNo.value)=="")
		{
		 alert("Voucher NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 
		else 
		return;
		}
		
		function validate1()
		{
		if(trimAll(document.Form1.txtVNo.value)=="" && trimAll(document.Form1.txtCsNo.value)=="")
		{
		 alert("ENTER BILL NO. OR CASE NO. TO SEARCH RECIEPTS.");
		 event.returnValue=false;
		 }
		 
		else 
		return;
		}
		function makeUppercase(field)
		 {
		 var ss=field.value;
	    	field.value=ss.toUpperCase();
		 }
        </script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Width="196px" ForeColor="DarkBlue" BackColor="White"
								Font-Bold="True" Font-Size="10pt" Font-Names="Verdana"> VOUCHERS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" style="WIDTH: 40%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="0"
							cellPadding="0" width="230" bgColor="aliceblue" border="1">
							<TR>
								<TD style="WIDTH: 20%; HEIGHT: 36px"><asp:label id="Label6" runat="server" Width="80px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Voucher No.</asp:label></TD>
								<TD style="WIDTH: 40%; HEIGHT: 36px"><asp:textbox id="txtVNo" tabIndex="1" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Height="20px" MaxLength="10" ontextchanged="txtVNo_TextChanged"></asp:textbox></TD>
							</TR>
						</TABLE>
						<asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">
								To Edit/Delete a R V --> Enter Voucher No. & Click on "Modify" Button</asp:label>
						<asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkMagenta" Width="100%">
								For New R V --> Click on "New Voucher" Button</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnAdd" tabIndex="3" runat="server" Width="99px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="New Voucher" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="4" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Modify" onclick="btnMod_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center">
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
				</TR>
				<TR>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>

