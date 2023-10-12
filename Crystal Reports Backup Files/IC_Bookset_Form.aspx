
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IC_Bookset_Form.aspx.cs" Inherits="RBS.IC_Bookset_Form.IC_Bookset_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Inspection Certificates Book Set Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		
			if(document.Form1.txtBKNo.value=="")
			{
				alert("BOOK NO. CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if (document.Form1.txtCertFrom.value=="" || document.Form1.txtCertFrom.value < "001")
			{
				alert("CERTIFIACTE NO. FROM CANNOT BE LEFT BLANK AND SHOULD BE > 0");
				event.returnValue=false;
			}
		 	else if(document.Form1.txtCertTo.value=="")
			{
				alert("CERTIFIACTE NO. TO CANNOT BE LEFT BLANK");
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
				alert("Set No. To Must Greater Than Set No. From");
				document.Form1.txtCertFrom.focus();
			}
			return false;
			}
		}
		function focus()
		{
			if(document.Form1.txtBKNo.disabled==false)
			{
			document.Form1.txtBKNo.focus();
			}
			else
			{
			document.Form1.txtCertFrom.focus();
			}
			return false;
		}
		
		function makeUppercase()
		 {
			document.Form1.txtBKNo.value = document.Form1.txtBKNo.value.toUpperCase();
		 } 
		 
		function change()
		{
			var d=document.Form1.txtCertFrom.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="00" + d;
				document.Form1.txtCertFrom.value=d;
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="0" + d;
				document.Form1.txtCertFrom.value=d;
				event.returnValue=false;
			}
			return false;	
		}
		
		function change1()
		{
			var d1=document.Form1.txtCertTo.value;
			var dlength1=d1.length;
			if(dlength1 == 1)
			{
				d1="00" + d1;
				document.Form1.txtCertTo.value=d1;
				event.returnValue=false;
			}
			else if(dlength1==2)
			{
				d1="0" + d1;
				document.Form1.txtCertTo.value=d1;
				event.returnValue=false;
			}
			return;	
		}
		function check_cutOffSet()
		{
			var d1=document.Form1.txtCutOffSetNo.value;
			var dlength1=d1.length;
			if(dlength1 == 1)
			{
				d1="00" + d1;
				document.Form1.txtCutOffSetNo.value=d1;
				event.returnValue=false;
			}
			else if(dlength1==2)
			{
				d1="0" + d1;
				document.Form1.txtCutOffSetNo.value=d1;
				event.returnValue=false;
			}
			else if(dlength1==3)
			{
				if(document.Form1.txtCertFrom.value!="" && document.Form1.txtCertTo.value!="")
				{
				var setfr=(document.Form1.txtCertFrom.value);
				var setto=(document.Form1.txtCertTo.value);
				var cutOffSet=(document.Form1.txtCutOffSetNo.value)
					if(((cutOffSet>=setfr) && (cutOffSet<=setto))==false)
					{
						alert("Cut Off Set No. Should Be Between Set No. From & Set No. To.");
						document.Form1.txtCertFrom.focus();
					}
				}
				
			}
			return false;
			
		}
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="focus();">
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
								BackColor="White" Width="282px" Font-Bold="True">INSPECTION CERTIFICATES BOOK SET</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" style="HEIGHT: 128px" borderColor="#bfcbe3" cellSpacing="1" cellPadding="1"
								width="100%" bgColor="#f0f8ff" border="1">
								<TR align="center">
									<TD style="WIDTH: 80px; HEIGHT: 36px"><FONT color="#000099"><STRONG><FONT face="Verdana"><FONT size="2">
														Book&nbsp;No<FONT color="#000099">.</FONT></FONT></FONT></STRONG></FONT></TD>
									<TD style="WIDTH: 377px; HEIGHT: 36px" align="center"><FONT face="Verdana" color="#000099" size="2"><STRONG>Set 
												No. (From-To)</STRONG></FONT></TD>
									<TD style="WIDTH: 360px; HEIGHT: 36px"><FONT face="Verdana" color="#000099" size="2"><STRONG>IE 
												To Whom Issued</STRONG></FONT></TD>
									<TD style="HEIGHT: 36px" align="center">
										<P><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Font-Bold="True">Date of Issue To IE</asp:label><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="7pt" ForeColor="DarkBlue"
												Font-Bold="True">(DD/MM/YYYY)</asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 80px; HEIGHT: 31px" align="center"><asp:textbox id="txtBKNo" onblur="makeUppercase();" tabIndex="1" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" BackColor="LavenderBlush" Width="47px" MaxLength="4" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 377px; HEIGHT: 31px" align="center">&nbsp;<asp:textbox id="txtCertFrom" onblur="change();check();" tabIndex="2" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="44px" MaxLength="3" Height="20px"></asp:textbox>&nbsp;<FONT face="Verdana" size="2"><STRONG><FONT color="#000099">to
												</FONT></STRONG></FONT>
										<asp:textbox id="txtCertTo" onblur="change1();check();" tabIndex="3" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="43px" MaxLength="3" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 360px; HEIGHT: 31px" align="center"><asp:dropdownlist id="lstIE" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="294px" Height="25%"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 31px" align="center"><asp:textbox id="txtDOI" onblur="check_date(txtDOI);" tabIndex="5" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="85px" MaxLength="10" Height="20px"></asp:textbox></TD>
								</TR>
								<TR align="center">
									<TD style="WIDTH: 80px"><FONT face="Verdana" color="#000099" size="2"><STRONG>Book 
												Submitted</STRONG></FONT></TD>
									<TD style="WIDTH: 377px" align="center"><asp:dropdownlist id="lstBKSubmit" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%" Height="25%"></asp:dropdownlist></TD>
									<TD style="WIDTH: 360px">
										<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:label id="Label8" runat="server" Font-Bold="True" Width="305px" ForeColor="DarkBlue" Font-Size="9pt"
												Font-Names="Verdana">Book Submit Date (DD/MM/YYYY)</asp:label></P>
									</TD>
									<TD align="center"><asp:textbox id="txtBKSubmitDt" onblur="check_date(txtBKSubmitDt); compareDates(txtDOI,txtBKSubmitDt,'Book Submit Date Cannot Be Less Then Date Of Issue TO IE');"
											tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="82px" MaxLength="10"
											Height="20px"></asp:textbox></TD>
								</TR>
								<TR bgcolor="#ffcc99">
									<TD colSpan="4" align="center" style="HEIGHT: 31px">
										<asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="DarkMagenta" Font-Size="8pt"
											Font-Names="Verdana" Width="100%">Last Set No. Issued/Cancelled By The IE in Current Financial Year (Not a Mendatory Field)</asp:label></TD>
								</TR>
								<TR bgcolor="#ffcc99">
									<TD style="WIDTH: 80px"><FONT color="#000099"><STRONG><FONT face="Verdana"><FONT size="2">Cut Off 
														Date<FONT color="#000099">.</FONT></FONT></FONT></STRONG></FONT></TD>
									<TD style="WIDTH: 377px" align="left">
										<asp:textbox onblur="check_date(txtCutOffSetDt); compareDates(txtDOI,txtCutOffSetDt,'Cut Off Date Cannot Be Less Then Date Of Issue TO IE');"
											id="txtCutOffSetDt" tabIndex="8" runat="server" Width="82px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
									<TD style="WIDTH: 360px" align="right"><FONT color="#000099"><STRONG><FONT face="Verdana"><FONT size="2">Last 
														Set No<FONT color="#000099">.&nbsp;&nbsp;</FONT></FONT></FONT></STRONG></FONT></TD>
									<TD align="left">
										<asp:textbox onblur="check_cutOffSet();" id="txtCutOffSetNo" tabIndex="9" runat="server" Width="44px"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="3"></asp:textbox></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="lblMsg" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkMagenta"
								Font-Bold="True" Visible="False">To Save / Modify Record enter detail and Click on [Save] button</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
					</TD>
				</TR>
				<TR align="center">
					<TD style="HEIGHT: 23px" align="center"><asp:button id="btnSave" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="12" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True" Text="Delete" onclick="btnDelete_Click"></asp:button>
						<asp:button id="btnAddNew" tabIndex="13" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Add New" onclick="btnAddNew_Click"></asp:button><asp:button id="btnCancel" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:label id="lblF" runat="server" Visible="False"></asp:label><asp:label id="lblT" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
