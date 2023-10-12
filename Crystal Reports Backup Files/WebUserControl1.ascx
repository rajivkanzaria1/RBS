<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="RBS.WebUserControl2" %>
<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" bgColor="inactivecaptiontext"
	border="1" borderColor="lightsteelblue">
	<TR>
		<TD width="20%" style="HEIGHT: 20px">
			<asp:label id="lblUID" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
				runat="server">User : </asp:label></TD>
		<TD align="center" width="60%" style="HEIGHT: 20px">
			<asp:label id="Label2" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana"
				runat="server" BackColor="Transparent" BorderColor="White">RITES INSPECTION & BILLING SYSTEM</asp:label></TD>
		<TD align="right" width="20%" style="HEIGHT: 20px">
			<asp:label id="lblRole" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
				runat="server" Width="136px">Role : </asp:label></TD>
	</TR>
	<TR>
		<td>
			<asp:label id="lblRegion" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
				Font-Bold="True">Region : </asp:label></td>
		<td></td>
		<TD width="20%" noWrap align="right" colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:hyperlink id="HyperLink1" Font-Bold="True" ForeColor="Purple" Font-Size="8pt" Font-Names="Verdana"
				runat="server" NavigateUrl="MainForm.aspx">MainMenu</asp:hyperlink>&nbsp;&nbsp;
			<asp:hyperlink id="HyperLink2" Font-Bold="True" ForeColor="Purple" Font-Size="8pt" Font-Names="Verdana"
				runat="server" NavigateUrl="LogOut.aspx">LogOut</asp:hyperlink></TD>
	</TR>
</TABLE>