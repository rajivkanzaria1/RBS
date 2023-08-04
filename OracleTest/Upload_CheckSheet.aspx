<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload_CheckSheet.aspx.cs" Inherits="RBS.Upload_CheckSheet.Upload_CheckSheet" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Upload_CheckSheet</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">				
			function validate()
			{
				if(trimAll(document.Form1.lstDiscipline.value)=="")
					{
						alert("Discipline Not Selected!!!");
						event.returnValue=false;
						document.Form1.lstDiscipline.focus();
					}
				else if(trimAll(document.Form1.txtChkShtName.value)=="")
					{
						alert("Name of Checksheet is Missing!!!");
						event.returnValue=false;
						document.Form1.txtChkShtName.focus();
					}
				else if(trimAll(document.Form1.txtDocNo.value)=="")
					{
						alert("Document No. Missing!!!");
						event.returnValue=false;
						document.Form1.txtDocNo.focus();
					}
				else if(trimAll(document.Form1.txtIssueDt.value)=="")
					{
						alert("Enter a valid Document Issue Date!!!");
						event.returnValue=false;
						document.Form1.txtIssueDt.focus();
					}
			}
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 216px; TOP: 8px; LEFT: 8px"
				id="Table1" border="1" cellSpacing="1" cellPadding="1" width="1069">
				<TR>
					<TD colSpan="4" align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR height="50">
					<TD colSpan="4" align="center"><FONT color="darkblue" face="Verdana"><STRONG>UPLOAD 
								INSPECTION CHECKSHEET</STRONG></FONT></TD>
				</TR>
				<TR height="40">
					<TD style="WIDTH: 10%"></TD>
					<TD style="WIDTH: 22.51%"><asp:label id="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue">Discipline</asp:label></TD>
					<TD><asp:dropdownlist id="lstDiscipline" runat="server" Font-Bold="True" ForeColor="Blue">
							<asp:ListItem Selected="True"></asp:ListItem>
							<asp:ListItem Value="M">Mechanical</asp:ListItem>
							<asp:ListItem Value="E">Electrical</asp:ListItem>
							<asp:ListItem Value="C">Civil</asp:ListItem>
							<asp:ListItem Value="M">Mettalurgy</asp:ListItem>
							<asp:ListItem Value="T">Textiles</asp:ListItem>
							<asp:ListItem Value="P">Power Engineering</asp:ListItem>
							<asp:ListItem Value="O">Others</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 10%"></TD>
				</TR>
				<TR height="40">
					<TD style="WIDTH: 10%"></TD>
					<TD style="WIDTH: 22.51%"><asp:label id="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue">Name of the Checksheet</asp:label></TD>
					<TD><asp:textbox id="txtChkShtName" runat="server" Font-Bold="True" ForeColor="Blue" Width="90%"></asp:textbox></TD>
					<TD style="WIDTH: 10%"></TD>
				</TR>
				<TR height="40">
					<TD style="WIDTH: 10%"></TD>
					<TD style="WIDTH: 22.51%"><asp:label id="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue">Document No.</asp:label></TD>
					<TD><asp:textbox id="txtDocNo" runat="server" Font-Bold="True" ForeColor="Blue"></asp:textbox></TD>
					<TD style="WIDTH: 10%"></TD>
				</TR>
				<TR height="40">
					<TD style="WIDTH: 10%"></TD>
					<TD style="WIDTH: 22.51%"><asp:label id="Label5" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue">Issue Date</asp:label></TD>
					<TD><asp:textbox onblur="check_date(txtIssueDt)" id="txtIssueDt" runat="server" Font-Bold="True"
							ForeColor="Blue"></asp:textbox><FONT color="#ff3366" size="1" face="Verdana"><STRONG>&nbsp;(enter 
								date in [dd/mm/yyyy] format)</STRONG></FONT></TD>
					<TD style="WIDTH: 10%"></TD>
				</TR>
				<TR height="40">
					<TD style="WIDTH: 10%"></TD>
					<TD style="WIDTH: 22.51%"><asp:label id="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue">Browse the Checksheet to Upload</asp:label></TD>
					<TD><INPUT style="WIDTH: 90%; FONT-FAMILY: Verdana; HEIGHT: 25px; COLOR: navy; FONT-SIZE: 8pt; FONT-WEIGHT: bold"
							id="File1" tabIndex="0" size="51" type="file" name="File1" runat="server"></TD>
					<TD style="WIDTH: 10%"></TD>
				</TR>
				<TR height="40" bgColor="lavender">
					<TD colSpan="4" align="center"><asp:button style="Z-INDEX: 0" id="btnUpload" runat="server" Font-Bold="True" ForeColor="#0000C0"
							Text="Upload Checksheet"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
