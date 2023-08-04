<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hologram_Form.aspx.cs" Inherits="RBS.Hologram_Form.Hologram_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>HOLOGRAM FORM</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		
			 if (document.Form1.txtCertFrom.value=="" || document.Form1.txtCertFrom.value==0)
			{
				alert("HOLOGRAM NO. FROM CANNOT BE LEFT BLANK AND SHOULD BE > 0");
				event.returnValue=false;
			}
		 	else if(document.Form1.txtCertTo.value=="")
			{
				alert("HOLOGRAM NO. TO CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.lstIE.value=="")
			{
				alert("IE TO WHOM ISSUED CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.txtDOI.value=="")
			{
				alert("DATE OF ISSUE TO IE CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
		 	else if(trimAll(document.Form1.txtCertFrom.value)!="" && IsNumeric(document.Form1.txtCertFrom.value) == false)
			{
				alert("HOLOGRAM NO FROM. CONTAINS INVALID CHARACTERS!!!");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtCertTo.value)!="" && IsNumeric(document.Form1.txtCertTo.value) == false)
			{
				alert("HOLOGRAM NO To. CONTAINS INVALID CHARACTERS!!!");
				event.returnValue=false;
			}
			else
			{
				document.Form1.btnSave.style.visibility = 'hidden';
			}
			return;		 
		}
		
		function del()
		{
			var d=confirm("Click OK to Confirm Delete!!!");
			if(d==true)
				event.returnValue=true;
			else
				event.returnValue=false;
		}
		function check()
		{
			if(document.Form1.txtCertFrom.value!="" && document.Form1.txtCertTo.value!="")
			{
			var setfr=(document.Form1.txtCertFrom.value);
			var setto=(document.Form1.txtCertTo.value);
			if(setto<setfr)
			{
				alert("HOLOGRAM No. To Must Greater Than HOLOGRAM No. From");
				document.Form1.txtCertFrom.focus();
			}
			return false;
			}
		}
			
		
		 
		function change()
		{
			var d=document.Form1.txtCertFrom.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="000000" + d;
				document.Form1.txtCertFrom.value=d
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="00000" + d;
				document.Form1.txtCertFrom.value=d
				event.returnValue=false;
			}
			else if(dlength==3)
			{
				d="0000" + d;
				document.Form1.txtCertFrom.value=d
				event.returnValue=false;
			}
			else if(dlength==4)
			{
				d="000" + d;
				document.Form1.txtCertFrom.value=d
				event.returnValue=false;
			}
			else if(dlength==5)
			{
				d="00" + d;
				document.Form1.txtCertFrom.value=d
				event.returnValue=false;
			}
			else if(dlength==6)
			{
				d="0" + d;
				document.Form1.txtCertFrom.value=d
				event.returnValue=false;
			}
			else
			return false;	
		}
		
		function change1()
		{
			var d=document.Form1.txtCertTo.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="000000" + d;
				document.Form1.txtCertTo.value=d
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="00000" + d;
				document.Form1.txtCertTo.value=d
				event.returnValue=false;
			}
			else if(dlength==3)
			{
				d="0000" + d;
				document.Form1.txtCertTo.value=d
				event.returnValue=false;
			}
			else if(dlength==4)
			{
				d="000" + d;
				document.Form1.txtCertTo.value=d
				event.returnValue=false;
			}
			else if(dlength==5)
			{
				d="00" + d;
				document.Form1.txtCertTo.value=d
				event.returnValue=false;
			}
			else if(dlength==6)
			{
				d="0" + d;
				document.Form1.txtCertTo.value=d
				event.returnValue=false;
			}
			else
			return false;	
		}
		
        </script>
	</HEAD>
	<body bgColor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 26px">
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="282px" Font-Bold="True"> HOLOGRAM FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" style="WIDTH: 707px; HEIGHT: 16px" borderColor="#bfcbe3" cellSpacing="1"
							cellPadding="1" width="707" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 35%" align="center"><STRONG><FONT face="Verdana" color="#000099" size="2">Hologram&nbsp;No.&nbsp;&nbsp;(From-To)</FONT></STRONG></TD>
								<TD style="WIDTH: 35%" align="center"><FONT face="Verdana" color="#000099" size="2"><STRONG>IE 
											To Whom Issued</STRONG></FONT></TD>
								<TD style="WIDTH: 35%" align="center"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="100%" Font-Bold="True">Date of Issue To IE</asp:label><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="7pt" ForeColor="DarkBlue"
										Font-Bold="True">(DD/MM/YYYY)</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 35%" align="center"><asp:label id="lblReg1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="Red"
										Width="5%" Font-Bold="True"></asp:label>&nbsp;<asp:textbox id="txtCertFrom" onblur="change();check();" tabIndex="1" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="35%" MaxLength="7" Height="20px"></asp:textbox>&nbsp;<FONT face="Verdana" size="2"><STRONG><FONT color="#000099">to
												<asp:label id="lblReg2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="Red"
													Width="5%" Font-Bold="True"></asp:label></FONT></STRONG></FONT><asp:textbox id="txtCertTo" onblur="change1();check();" tabIndex="2" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="35%" MaxLength="7" Height="20px"></asp:textbox></TD>
								<TD style="WIDTH: 35%" align="center"><asp:dropdownlist id="lstIE" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="294px" Height="25%"></asp:dropdownlist></TD>
								<TD style="WIDTH: 35%" align="center"><asp:textbox id="txtDOI" onblur="check_date(txtDOI);" tabIndex="4" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="85px" MaxLength="10" Height="20px"></asp:textbox></TD>
							</TR>
						</TABLE>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<TR align="center">
					<TD style="HEIGHT: 23px" align="center"><asp:button id="btnSave" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnAddNew" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True" Text="Add New" onclick="btnAddNew_Click"></asp:button><asp:button id="btnCancel" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:label id="lblF" runat="server" Visible="False"></asp:label><asp:label id="lblT" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>

