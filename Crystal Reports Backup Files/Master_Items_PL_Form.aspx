<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Master_Items_PL_Form.aspx.cs" Inherits="RBS.Master_Items_PL_Form.Master_Items_PL_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Master_Items_PL_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 356px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD align="center" colSpan="2"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<P><asp:label id="Label1" runat="server" ForeColor="DarkBlue" Font-Bold="True" BackColor="White"
									Font-Size="10pt" Font-Names="Verdana">MASTER ITEMS PL FORM</asp:label></P>
							<P align="center"><asp:panel id="Panel_1" runat="server" Width="100%" Height="1px">
									<TABLE id="Table2" style="WIDTH: 90%" cellSpacing="0" cellPadding="0" width="429" bgColor="aliceblue"
										border="1" borderColor="#b0c4de">
										<TR>
											<TD style="WIDTH: 20%; HEIGHT: 26px"><asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana"> Select Item.</asp:label></TD>
											<TD style="WIDTH: 80%; HEIGHT: 26px"><asp:dropdownlist onkeypress="return keySort(ddlMasterItems);" id="ddlMasterItems" tabIndex="2" runat="server"
													ForeColor="DarkBlue" Font-Size="7pt" Font-Names="Verdana" Width="100%" Height="25px" AutoPostBack="True" onselectedindexchanged="ddlMasterItems_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 20%; HEIGHT: 40px"><asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Item CD - Item Description</asp:label></TD>
											<TD style="WIDTH: 80%; HEIGHT: 40px"><asp:label id="lblItemDesc" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana" Width="100%"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 20%; HEIGHT: 20px"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">PL No.</asp:label></TD>
											<TD style="WIDTH: 80%"><asp:textbox id="txtPLNO1" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
													Width="150px" Height="25px" MaxLength="10"></asp:textbox>
												<asp:label id="lblPL_NO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana" Width="100%" Visible="False"></asp:label></TD>
										</TR>
									</TABLE></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="5" style="HEIGHT: 20px">
							<P><asp:button id="btnSaveU" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSaveU_Click"></asp:button><asp:button id="btnSave" tabIndex="10" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="12" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="5"></TD>
					</TR></asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 100px" runat="server"
						Width="100%" Height="1px">
  <TR>
    <TD align=center colSpan=5>
<asp:datagrid id=grdBDetails runat="server" Font-Names="Verdana" Font-Size="8pt" BackColor="White" Height="100px" Width="100%" PageSize="1" CellPadding="0" BorderColor="Navy" BorderStyle="Groove" AutoGenerateColumns="False">
									<FooterStyle Wrap="False"></FooterStyle>
									<EditItemStyle Wrap="False"></EditItemStyle>
									<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
									<HeaderStyle Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center" ForeColor="DarkBlue"
										VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn>
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemTemplate>
												<asp:HyperLink id="HyperLink1" Text='Select' NavigateUrl='<%#"Master_Items_PL_Form.aspx?ITEM_CD=" + DataBinder.Eval(Container.DataItem,"ITEM_CD")+ "&amp;PL_NO=" + DataBinder.Eval(Container.DataItem,"PL_NO")%>' runat="server">Select</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn Visible="False" DataField="ITEM_CD" HeaderText="ITEM_CD">
											<HeaderStyle Width="1%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ITEM_DESC" HeaderText="Item Description">
											<HeaderStyle Width="40%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PL_NO" HeaderText="PL No.">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</asp:datagrid></TD></TR>
					</asp:panel></TBODY></TABLE>
		</form>
	</body>
</HTML>
