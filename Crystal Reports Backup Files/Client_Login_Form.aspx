<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client_Login_Form.aspx.cs" Inherits="RBS.Client_Login_Form.Client_Login_Form" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Client_Login_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{		
			if(document.Form1.txtUserId.value=="")
			{
				alert("USER NAME CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.txtPwd.value=="")		
			{
				alert("PASSWORD CANNOT BE BLANK");
				event.returnValue=false;
			}
			return;
		}
        </script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 200px; POSITION: absolute; TOP: 128px; HEIGHT: 160px"
				borderColor="#003399" height="160" cellSpacing="0" cellPadding="1" width="50%" align="center"
				border="1">
				<TR>
					<TD style="HEIGHT: 38px" align="center" bgColor="#b0c4de" colSpan="2"><STRONG style="COLOR: darkblue; FONT-FAMILY: Verdana">Client 
							Login Form</STRONG></TD>
				</TR>
				<TR style="FONT-FAMILY: Verdana" bgColor="#d0dce0">
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 117px; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 42px"
						noWrap align="center" bgColor="#f0f8ff">CLIENT&nbsp;ID</TD>
					<TD bgColor="#f0f8ff"><asp:textbox id="txtUserId" runat="server" Width="150px" MaxLength="10"></asp:textbox></TD>
				</TR>
				<TR style="FONT-FAMILY: Verdana" bgColor="#d0dce0">
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 117px; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 42px"
						noWrap align="center" bgColor="#f0f8ff">PASSWORD</TD>
					<TD bgColor="#f0f8ff"><asp:textbox id="txtPwd" runat="server" Width="150px" MaxLength="10" TextMode="Password"></asp:textbox><asp:label id="lblGen_Time" runat="server" Width="65px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Names="Verdana" Font-Size="8pt" Visible="False"></asp:label></TD>
				<TR style="FONT-FAMILY: Verdana">
					<TD align="center" colSpan="2"><asp:button id="btnLogin" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Text="Login" onclick="btnLogin_Click"></asp:button><asp:button id="btnCPWD" runat="server" Width="145px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Names="Verdana" Text="Change Password" onclick="btnCPWD_Click"></asp:button></TD>
				</TR>
				<TR style="FONT-FAMILY: Verdana">
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 42px"
						noWrap align="center" bgColor="#f0f8ff" colSpan="2"><asp:label id="lblOTP" runat="server" Width="65px" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" Visible="False">OTP: </asp:label><asp:textbox id="txtOTP" runat="server" Width="50px" MaxLength="4" TextMode="Password" Visible="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:button id="btnOTPProceed" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Visible="False" Text="Proceed" onclick="btnOTPProceed_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
					</TD>
				</TR>
			</TABLE>
			<asp:hyperlink id="HyperLink2" style="Z-INDEX: 102; LEFT: 680px; POSITION: absolute; TOP: 8px"
				onclick="javascript:window.opener='x';window.close();" runat="server" ForeColor="Purple" Font-Bold="True"
				Font-Names="Verdana" Font-Size="8pt" NavigateUrl="  ">Exit</asp:hyperlink></form>
	</body>
</HTML>
