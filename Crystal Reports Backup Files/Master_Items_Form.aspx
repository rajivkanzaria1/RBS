<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Master_Items_Form.aspx.cs" Inherits="RBS.Master_Items_Form.Master_Items_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Master_Items_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<script src="date.js"></script>
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
									Font-Size="10pt" Font-Names="Verdana">MASTER ITEMS LIST</asp:label></P>
							<P align="center"><asp:panel id="Panel_1" runat="server" Width="100%" Height="1px">
									<TABLE id="Table2" style="WIDTH: 60%; HEIGHT: 160px" cellSpacing="0" cellPadding="0" width="429"
										bgColor="aliceblue" border="0">
										<TR>
											<TD style="WIDTH: 247px; HEIGHT: 26px" colSpan="2"><asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Item Serial No.</asp:label></TD>
											<TD style="HEIGHT: 26px" colSpan="3"><asp:textbox id="txtSerialNo" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
													Font-Names="Verdana" Width="150px" Height="25px" MaxLength="3"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 247px; HEIGHT: 28px" colSpan="2"><asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Item Description</asp:label></TD>
											<TD style="HEIGHT: 28px" colSpan="3"><asp:textbox id="txtIDesc" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
													Width="80%" Height="50px" MaxLength="100" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 247px; HEIGHT: 26px" colSpan="2"><asp:label id="Label11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Descipline</asp:label></TD>
											<TD style="HEIGHT: 26px" colSpan="3"><asp:dropdownlist id="lstDept" tabIndex="8" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
													Width="80%" Height="25px"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 247px; HEIGHT: 26px" colSpan="2"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana" Width="201px">Prep By Inspection Engineer</asp:label></TD>
											<TD style="HEIGHT: 26px" colSpan="3"><asp:dropdownlist id="lstIE" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
													Width="50%" Height="20px"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 247px; HEIGHT: 26px" colSpan="2"><asp:label id="lblIE" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana" Width="186px">App By Controlling Officer </asp:label></TD>
											<TD style="HEIGHT: 26px" colSpan="3"><asp:dropdownlist id="lstCO" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
													Width="50%" Height="25px" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 247px; HEIGHT: 26px" colSpan="2"><asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana" Width="216px">Creation Or Revision Date</asp:label></TD>
											<TD style="HEIGHT: 26px" colSpan="3"><asp:textbox id="txtDt" onblur="check_date(txtDt);" style="TEXT-ALIGN: center" tabIndex="3" runat="server"
													ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="100px" Height="20px" MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 247px; HEIGHT: 20px" colSpan="2"><asp:label id="Label9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana"> No of Days For IC</asp:label></TD>
											<TD style="HEIGHT: 20px" colSpan="3">
												<asp:textbox id="txtTimeforInsp" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" MaxLength="13" Width="150px" Height="25px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 247px" colSpan="2">
												<asp:label id="Label14" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue"> Checksheet <FONT COLOR="OrangeRed">(RAR ONLY)</FONT></asp:label></TD>
											<TD colSpan="3"><INPUT id="File1" style="FONT-SIZE: 8pt; WIDTH: 424px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 22px"
													tabIndex="23" type="file" size="51" name="File1" runat="server"></TD>
										</TR>
									</TABLE></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 19px" align="center" colSpan="5">
							<P>
								<asp:button id="btnSaveU" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
									ForeColor="DarkBlue" Text="Save" onclick="btnSaveU_Click"></asp:button>
								<asp:button id="btnSave" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
									ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button>
								<asp:button id="btnAdd" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
									ForeColor="DarkBlue" Text="AddNew" onclick="btnAdd_Click"></asp:button>
								<asp:button id="btnCancel" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Cancel" onclick="btnCancel_Click"></asp:button></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="5"></TD>
					</TR>
					</asp:panel>
					<asp:panel id="Panel_2" runat="server" Height="1px" Width="100%" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 100px">
						<TR>
							<TD align="center" colSpan="5">
								<asp:datagrid id="grdBDetails" runat="server" Font-Names="Verdana" Font-Size="8pt" BackColor="White"
									Height="100px" Width="100%" AutoGenerateColumns="False" BorderStyle="Groove" BorderColor="Navy"
									CellPadding="0" PageSize="1">
									<FooterStyle Wrap="False"></FooterStyle>
									<EditItemStyle Wrap="False"></EditItemStyle>
									<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
									<HeaderStyle Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center" ForeColor="DarkBlue"
										VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn>
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemTemplate>
												<asp:HyperLink id="HyperLink1" Text=' <%# DataBinder.Eval(Container.DataItem,"ITEM_CD")%>' NavigateUrl='<%#"Master_Items_Form.aspx?ITEM_CD=" + DataBinder.Eval(Container.DataItem,"ITEM_CD")%>' runat="server">Select</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn Visible="False" DataField="ITEM_CD" HeaderText="ITEM_CD">
											<HeaderStyle Width="1%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ITEM_DESC" HeaderText="Item Description">
											<HeaderStyle Width="40%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DEPT" HeaderText="Descipline">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TIME_FOR_INSP" HeaderText="No of Days For IC">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CHKSHT" HeaderText="Checksheet">
											<HeaderStyle Width="25%"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</asp:datagrid></TD>
						</TR>
					</asp:panel></TBODY></TABLE>
		</form>
	</body>
</HTML>
