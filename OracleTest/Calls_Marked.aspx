<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calls_Marked.aspx.cs" Inherits="RBS.Calls_Marked.Calls_Marked" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Calls_Marked</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<script src="date.js"></script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD align="center" style="HEIGHT: 69px"><uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD align="center" style="HEIGHT: 86px">
							<P><B><FONT face="Verdana" color="darkblue"><FONT size="2">View Calls Marked between the period </FONT>
										<asp:TextBox id="txtDtFr" runat="server" Width="85px" onblur="check_date(txtDtFr);" MaxLength="10"
											tabIndex="1"></asp:TextBox>&nbsp;<FONT size="2">to </FONT>&nbsp;
										<asp:TextBox id="txtDtTo" runat="server" Width="85px" onblur="check_date(txtDtTo);" MaxLength="10"
											tabIndex="2"></asp:TextBox></FONT></B></P>
						</TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 79px" align="center"><FONT face="Verdana" color="darkblue" size="2"><B> Report 
									to&nbsp;be Sorted&nbsp;on
									<asp:RadioButton id="radioVendor" runat="server" Width="112px" Text="Vendor" Checked="True" GroupName="grpSortOrder"></asp:RadioButton>
									<asp:RadioButton id="radioCallDt" runat="server" Width="108px" Text="Call Date" GroupName="grpSortOrder"></asp:RadioButton></FONT></B></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<td align="center">
							<asp:Button id="btnShow" runat="server" Text="Show" Font-Bold="True" BackColor="#C0C0FF" ForeColor="DarkBlue"
								tabIndex="3" onclick="btnShow_Click"></asp:Button>
						</td>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</B>
		<P></P>
		</TD></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
