<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_Login_Form_Test.aspx.cs" Inherits="RBS.IE_Login_Form_Test.IE_Login_Form_Test" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IE_Login_Form</title>
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
	<body MS_POSITIONING="GridLayout" onload="javascript:document.Form1.txtUserId.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 240px; POSITION: absolute; TOP: 128px; HEIGHT: 160px"
				height="160" cellSpacing="0" cellPadding="1" width="50%" border="1" borderColor="#003399"
				align="center">
				<TR>
					<TD align="center" colspan="2" bgColor="#b0c4de" style="HEIGHT: 38px"><STRONG style="COLOR: darkblue; FONT-FAMILY: Verdana">Inspection 
							Engineer Login Form</STRONG></TD>
				</TR>
				<TR bgColor="#d0dce0" style="FONT-FAMILY: Verdana">
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 82px; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 42px"
						align="center" noWrap bgColor="#f0f8ff">USER ID</TD>
					<TD bgColor="#f0f8ff"><asp:TextBox id="txtUserId" runat="server" Width="96px" MaxLength="6"></asp:TextBox></TD>
				</TR>
				<TR style="FONT-FAMILY: Verdana" bgColor="#d0dce0">
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 82px; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 42px"
						align="center" noWrap bgColor="#f0f8ff">PASSWORD</TD>
					<TD bgColor="#f0f8ff"><asp:TextBox id="txtPwd" runat="server" Width="96px" TextMode="Password"></asp:TextBox></TD>
				<TR>
					<TD align="right" colspan="2"><asp:Button id="btnLogin" runat="server" Text="Login" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue"></asp:Button>
						<asp:Button id="btnCPWD" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Text="Change Password"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:hyperlink id="HyperLink2" onclick="javascript:window.opener='x';window.close();" style="Z-INDEX: 102; LEFT: 680px; POSITION: absolute; TOP: 8px"
				runat="server" ForeColor="Purple" Font-Bold="True" Font-Names="Verdana" NavigateUrl="  " Font-Size="8pt">Exit</asp:hyperlink>
		</form>
	</body>
</HTML>
