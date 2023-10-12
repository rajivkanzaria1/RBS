<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Pwd_Form.aspx.cs" Inherits="RBS.Change_Pwd_Form.Change_Pwd_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Change Password Page</title>
		<meta name="vs_snapToGrid" content="False">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		
		function validate()
		{		
		if(document.Form1.txtUID.value=="")
		{
		 alert("USER ID CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else if(document.Form1.txtOPwd.value=="")		
		{
		alert("OLD PASSWORD CANNOT BE BLANK");
		event.returnValue=false;
		}
		else if(document.Form1.txtNPwd.value=="")		
		{
		alert("NEW PASSWORD CANNOT BE BLANK");
		event.returnValue=false;
		}
		else if(document.Form1.txtCNPwd.value=="")		
		{
		alert("CONFIRM NEW PASSWORD CANNOT BE BLANK");
		event.returnValue=false;
		}
		else if(document.Form1.txtNPwd.value!=document.Form1.txtCNPwd.value)
		{
		alert("YOUR NEW PASSWORD AND CONFIRM NEW PASSWORD ARE NOT SAME");
		event.returnValue=false;
		}
		else
		{
		var d=confirm("Are You Sure You Want to Change Your Password!!!");
		if(d==true)
		event.returnValue=true;
		else
		event.returnValue=false;
		}
		}
		
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtUID.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<P>
							<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="100%" bgColor="inactivecaptiontext"
								border="1" borderColor="lightsteelblue">
								<TR>
									<TD width="20%" style="HEIGHT: 20px">
									</TD>
									<TD align="center" width="60%" style="HEIGHT: 20px">
										<asp:label id="Label3" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana"
											runat="server" BackColor="Transparent" BorderColor="White">RITES INSPECTION & BILLING SYSTEM</asp:label></TD>
									<TD align="right" width="20%" style="HEIGHT: 20px">
									</TD>
								</TR>
								<TR>
									<TD width="20%" noWrap align="right" colSpan="3" rowSpan="1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<asp:Label id="Label1" runat="server" BackColor="White" Font-Names="Verdana" Font-Size="10pt"
								ForeColor="DarkBlue" Font-Bold="True">CHANGE PASSWORD FORM</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P align="left">
							<asp:HyperLink id="hypLogin" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								NavigateUrl="Login_Form.aspx">Login Here</asp:HyperLink></P>
						<P>
							<TABLE id="Table2" style="WIDTH: 363px; HEIGHT: 216px" cellSpacing="1" cellPadding="1"
								width="363" border="0" bgColor="#f0f8ff">
								<TR>
									<TD style="WIDTH: 168px">
										<P>
											<asp:Label id="Label2" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Font-Bold="True">UserID</asp:Label></P>
									</TD>
									<TD>
										<asp:TextBox id="txtUID" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="150px" MaxLength="8" Height="20px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 168px">
										<asp:Label id="Label4" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Old Password</asp:Label></TD>
									<TD>
										<asp:TextBox id="txtOPwd" tabIndex="3" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="150px" MaxLength="8" TextMode="Password" Height="20px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 168px">
										<asp:Label id="Label5" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">New Password<FONT face="Verdana" color="orangered" size="1">* </FONT></asp:Label></TD>
									<TD>
										<asp:TextBox id="txtNPwd" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="150px" MaxLength="8" TextMode="Password" Height="20px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 168px">
										<asp:Label id="Label6" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="160px" Font-Bold="True">Confirm New Password<FONT face="Verdana" color="orangered" size="1">
												* </FONT></asp:Label></TD>
									<TD>
										<asp:TextBox id="txtCNPwd" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="150px" MaxLength="8" TextMode="Password" Height="20px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD colspan="2" align="center">
										<asp:Button id="btnSubmit" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Text="Submit" Font-Bold="True" onclick="btnSubmit_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
								<TR>
									<TD colspan="2" align="center"><P><B><FONT face="Verdana" color="orangered" size="1">* New Password 
													must be maximum of 8 characters.</FONT></B>
										</P>
									</TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
