<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="old_Login_Form.aspx.cs" Inherits="RBS.old_Login_Form.old_Login_Form" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Inspection Monitoring & Billing System</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{		
			if(document.Form1.txtUname.value=="")
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
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtUname.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 100%" borderColor="black"
				height="100%" cellSpacing="0" cellPadding="0" border="0">
				<TR vAlign="middle">
					<TD style="WIDTH: 30%; HEIGHT: 10%"><asp:image id="Image2" runat="server" ImageAlign="AbsMiddle" ImageUrl="\RBS\images\logo_rites1.GIF"
							BackColor="Black" Width="300px" Height="100%"></asp:image></TD>
					<TD style="WIDTH: 70%; HEIGHT: 10%" vAlign="middle" align="center" bgColor="inactivecaptiontext">
						<P style="LINE-HEIGHT: 8pt"><FONT style="FONT-WEIGHT: bold; LINE-HEIGHT: 8pt; TEXT-ALIGN: center" color="darkblue"
								size="4"> INSPECTION MONITORING</FONT></P>
						<P style="LINE-HEIGHT: 8pt"><FONT style="FONT-WEIGHT: bold; LINE-HEIGHT: 8pt; TEXT-ALIGN: center" color="darkblue"
								size="4">&amp; </FONT>
						</P>
						<P style="LINE-HEIGHT: 8pt"><FONT style="FONT-WEIGHT: bold; CLIP: rect(2px auto 2px auto); LINE-HEIGHT: 8pt; TEXT-ALIGN: center"
								color="darkblue" size="4">BILLING SYSTEM</FONT></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 30%; HEIGHT: 60%"><asp:image id="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="\RBS\images\MVC-006S.jpg"
							BackColor="Black" Width="300px" Height="100%"></asp:image></TD>
					<TD style="WIDTH: 70%; HEIGHT: 60%" vAlign="middle" align="center">
						<TABLE id="Table3" style="WIDTH: 100%" height="100%" cellSpacing="0" cellPadding="0" border="0">
							<TR bgColor="#a7d7ff">
								<TD style="WIDTH: 100%;HEIGHT: 69px">
									<P align="left">&nbsp;&nbsp;<asp:imagebutton id="ImageButton1" runat="server" ImageUrl="\RBS\images\connected_data_big.jpg" Width="20%"
											Height="100%"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label4" runat="server" Width="50%" Height="69px" Font-Names="Verdana" Font-Bold="True"
											Font-Size="Larger" ForeColor="DarkBlue">LOGIN FORM</asp:label></P>
								</TD>
							</TR>
							<TR bgColor="#f0f8ff">
								<TD style="WIDTH: 100%; HEIGHT: 50%">
									<P>&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label2" runat="server" Width="72px" Font-Names="Verdana" Font-Bold="True" Font-Size="10pt"
											ForeColor="DarkBlue">&nbsp&nbspUSERNAME:</asp:label></P>
									<P>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:textbox id="txtUname" tabIndex="1" runat="server" Width="180px" Height="25px" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue"></asp:textbox></P>
									<P>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:label id="Label3" runat="server" Width="216px" Font-Names="Verdana" Font-Bold="True" Font-Size="10pt"
											ForeColor="DarkBlue">&nbsp&nbspPASSWORD:</asp:label></P>
									<P>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:textbox id="txtPwd" tabIndex="2" runat="server" Width="180px" Height="25px" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" TextMode="Password"></asp:textbox></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 20%" bgColor="#f0f8ff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="btnSubmit" tabIndex="3" runat="server" Font-Names="Verdana" Font-Bold="True"
										Font-Size="8pt" ForeColor="DarkBlue" Text="Submit"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnChangePwd" tabIndex="4" runat="server" Width="122px" Font-Names="Verdana"
										Font-Bold="True" Font-Size="8pt" ForeColor="DarkBlue" Text="Change Password"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="IE_Login_Form.aspx" ForeColor="DarkGreen"
										Font-Bold="True" Font-Names="Verdana">IE Login</asp:HyperLink>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td width="100%" bgColor="#339999" colSpan="2" height="5%"><P align="center"><FONT face="Verdana" style="BACKGROUND-COLOR: #009999" color="#ffffff" size="4"><STRONG>Designed 
									&amp; Developed by IT Division , RITES</STRONG></FONT></P>
					</td>
				</tr>
			</TABLE></TD></TR></TABLE></form>
	</body>
</HTML>

