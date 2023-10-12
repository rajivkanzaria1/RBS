<%@ Control Language="c#" AutoEventWireup="false" Codebehind="WebUserControl_Vend.ascx.cs" Inherits="RBS.Vendor.WebUserControl_Vend" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" bgColor="inactivecaptiontext"
	border="1" borderColor="lightsteelblue">
	<TR>
		<TD width="163" style="WIDTH: 25%; HEIGHT: 20px">
			<asp:label id="lblVend_CD" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
				Font-Bold="True" Width="90%"></asp:label></TD>
		<TD align="center" style="WIDTH: 50%; HEIGHT: 20px">
			<asp:label id="Label2" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana"
				runat="server" BackColor="Transparent" BorderColor="White"> RITES INSPECTION SYSTEM</asp:label></TD>
		<TD align="right" style="WIDTH: 25%; HEIGHT: 20px">
			<asp:hyperlink id="HyperLink1" Font-Bold="True" ForeColor="Purple" Font-Size="8pt" Font-Names="Verdana"
				runat="server" NavigateUrl="Vendor_Menu.aspx">MainMenu</asp:hyperlink>&nbsp;&nbsp;&nbsp;
			<asp:hyperlink id="HyperLink2" Font-Bold="True" ForeColor="Purple" Font-Size="8pt" Font-Names="Verdana"
				runat="server" NavigateUrl="..\LogOut.aspx">LogOut</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 100%; HEIGHT: 20px" colSpan="3">
			<asp:label id="lblUID" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
				runat="server" Width="95%">Vendor : </asp:label>&nbsp;</TD>
	</TR>
</TABLE>
