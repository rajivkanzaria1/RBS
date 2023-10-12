<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update_Bill_Status.aspx.cs" Inherits="RBS.Update_Bill_Status" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UPDATE BILL STATUS</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
			if(trimAll(document.Form1.txtBNO1.value)=="" && trimAll(document.Form1.txtBNO2.value)=="" && trimAll(document.Form1.txtBNO3.value)=="" && trimAll(document.Form1.txtBNO4.value)=="" && trimAll(document.Form1.txtBNO5.value)=="")
			{
				alert("Plz Enter Atleast One Bill No. To Update!!!");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtBNO1.value)=="")
			{
				alert("Entry At Serial No. 1 Cannot be Left Blank!!!");
				event.returnValue=false;
			}
			
		}
		function checkBNO(field)
		 {
			if(trimAll(field.value)!="" && field.value.length < 10)
			{
			alert("PLZ ENTER 10 DIGIT BILL NO.!!!");
			field.focus();
			event.returnValue=false;
			}
			else if (field.value.length == 10)
			{
			field.value = field.value.toUpperCase();
			}		
		 }
		
		
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtBNO1.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 192px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center">
						<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="436px" BackColor="White" ForeColor="DarkBlue"
								Font-Size="10pt" Font-Names="Verdana"> UPDATE BILL STATUS TO 'U' FOR RE-PRINTING THE BILL</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 212px">
						<P align="center">
							<TABLE id="Table2" borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="60%" align="center"
								bgColor="#f0f8ff" border="1">
								<TR align="center">
									<TD style="WIDTH: 170px" align="center" colSpan="1" rowSpan="1"><asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">(1) Bill No.</asp:label></TD>
									<TD align="left"><asp:textbox id="txtBNO1" onblur="checkBNO(txtBNO1);" tabIndex="1" runat="server" Width="60%"
											MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 170px" align="center"><asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">(2) Bill No.</asp:label></TD>
									<TD><asp:textbox id="txtBNO2" onblur="checkBNO(txtBNO2);" tabIndex="2" runat="server" Width="60%"
											MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 170px" align="center"><asp:label id="Label6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">(3) Bill No.</asp:label></TD>
									<TD><asp:textbox id="txtBNO3" onblur="checkBNO(txtBNO3);" tabIndex="3" runat="server" Width="60%"
											MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 170px" align="center"><asp:label id="Label7" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">(4) Bill No.</asp:label></TD>
									<TD><asp:textbox id="txtBNO4" onblur="checkBNO(txtBNO4);" tabIndex="4" runat="server" Width="60%"
											MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 170px" align="center"><asp:label id="Label8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">(5) Bill No.</asp:label></TD>
									<TD><asp:textbox id="txtBNO5" onblur="checkBNO(txtBNO5);" tabIndex="5" runat="server" Width="60%"
											MaxLength="10"></asp:textbox></TD>
								</TR>
							</TABLE>
							<br>
							<asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* User Can Update status of 5 Bills in one-step. Start Entry from serial no. 1 onwards.</asp:label><br>
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" tabIndex="6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Update" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="7" runat="server" Font-Bold="True" Width="72px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

