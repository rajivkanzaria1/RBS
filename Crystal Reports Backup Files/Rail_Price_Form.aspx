<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rail_Price_Form.aspx.cs" Inherits="RBS.Rail_Price_Form.Rail_Price_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>RAIL ITEMS FORM</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		
		 
		function del()
		{
		var d=confirm("Click OK to Confirm Delete!!!");
		if(d==true)
		event.returnValue=true;
		else
		event.returnValue=false;
		}
		
		

        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.lstRailDesc.focus();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="134px" Font-Bold="True">RAIL PRICE FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="center">
						<TABLE id="Table3" style="WIDTH: 50%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1"
							cellPadding="1" width="707" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 39.6%"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="100%" Font-Bold="True">Rail Description</asp:label></TD>
								<TD style="WIDTH: 50%" colSpan="3"><asp:dropdownlist id="lstRailDesc" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="7pt"
										ForeColor="DarkBlue" Width="100%" Height="25px" AutoPostBack="True"></asp:dropdownlist><asp:textbox id="txtRailDesc" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="100%" Height="25px" TextMode="MultiLine" MaxLength="30"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 39.6%"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="100%" Font-Bold="True">Rail Length (In Metres)</asp:label></TD>
								<TD style="WIDTH: 50%" colSpan="3"><asp:textbox id="txtRailLength" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="30%" MaxLength="3"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 39.6%" align="center" colSpan="4"><asp:button id="btnAddRail_desc" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Font-Bold="True" Text="Add New Rail Desc"></asp:button><asp:button id="btnSave" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True" Text="Save"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkMagenta"
								Width="536px" Font-Bold="True">* To Add New Rail Description Click on Add New Rail Desc Button!!!</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 3px" align="center"><asp:panel id="Panel_1" runat="server" Width="100%" Height="1px" Visible="False">
							<TABLE id="Table2" style="WIDTH: 707px; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" width="707" bgColor="#f0f8ff" border="1">
								<TR>
									<TD align="center" colSpan="5">
										<asp:button id="btnSave2" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Font-Bold="True" Text="Save"></asp:button>
										<asp:button id="btnDelete" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Font-Bold="True" Text="Delete!!!" Visible="False"></asp:button>
										<asp:button id="btnCancel" tabIndex="12" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="75px" Font-Bold="True" Text="Cancel"></asp:button></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 10%" align="center">
										<asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">ID SRNo.</asp:label></TD>
									<TD style="WIDTH: 20%" align="center">
										<asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="165px" Font-Bold="True">Rail Price Per Metre (Rs.)</asp:label></TD>
									<TD style="WIDTH: 20%" align="center">
										<asp:label id="lblFBankCD" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="115px" Font-Bold="True">Packing Charge (Rs.)</asp:label></TD>
									<TD style="WIDTH: 25%" align="center">
										<asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="173px" Font-Bold="True">Price Effective From Date</asp:label></TD>
									<TD style="WIDTH: 25%" align="center">
										<asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="158px" Font-Bold="True">Price Effective To Date</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 10%" align="center">
										<asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
											Font-Bold="True"></asp:label></TD>
									<TD style="WIDTH: 20%" align="center">
										<asp:textbox id="txtRail_Price" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="70%" MaxLength="10"></asp:textbox></TD>
									<TD style="WIDTH: 20%" align="center">
										<asp:textbox id="txtPacking_Charge" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="70%" MaxLength="10"></asp:textbox></TD>
									<TD style="WIDTH: 25%" align="center">
										<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
											tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="50%"
											MaxLength="11"></asp:textbox></TD>
									<TD style="WIDTH: 25%" align="center">
										<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
											tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="50%"
											MaxLength="11"></asp:textbox></TD>
								</TR>
								<TR>
									<TD colSpan="5">
										<DIV>
											<TITTLE:CUSTOMDATAGRID id="grdRail_Price_Details" runat="server" Width="100%" Height="8px" Visible="False"
												AutoGenerateColumns="False" PageSize="15" BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True"
												CssClass="Grid" AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="360px"
												GridWidth="100%">
												<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
												<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
												<EditItemStyle Height="10%"></EditItemStyle>
												<FooterStyle CssClass="GridHeader"></FooterStyle>
												<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
												<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="AliceBlue"
													CssClass="GridHeader" BackColor="AliceBlue"></HeaderStyle>
												<Columns>
													<asp:TemplateColumn FooterText="Edit">
														<HeaderStyle Width="8%"></HeaderStyle>
														<ItemTemplate>
															<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"Rail_Price_Form.aspx?RAIL_ID=" + DataBinder.Eval(Container.DataItem,"RAIL_ID")+ "&amp;ID_SRNO=" + DataBinder.Eval(Container.DataItem,"ID_SRNO") + "&amp;ACTION=M"%>' runat="server" Text=' <%# DataBinder.Eval(Container.DataItem,"ID_SRNO")%>'>
															</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="RAIL_PRICE_PER_MT" HeaderText="Rail Price Per Metre">
														<HeaderStyle Width="23%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="PACKING_CHARGE" HeaderText="Packing Charge">
														<HeaderStyle Width="20%"></HeaderStyle>
														<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="PRICE_DATE_FR" HeaderText="Price Effective Dt From.">
														<HeaderStyle Width="24%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="PRICE_DATE_TO" HeaderText="Price Effective Dt To.">
														<HeaderStyle Width="23%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="RAIL_ID" HeaderText="Rail  ID"></asp:BoundColumn>
												</Columns>
											</TITTLE:CUSTOMDATAGRID></DIV>
									</TD>
								</TR>
							</TABLE>
						</asp:panel></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

