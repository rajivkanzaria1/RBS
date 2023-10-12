<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab_Sample_Info.aspx.cs" Inherits="RBS.Lab_Sample_Info.Lab_Sample_Info" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lab_Sample_Info</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; TOP: 8px; LEFT: 8px" id="Table1"
				border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="HEIGHT: 35px" height="35" colSpan="6" align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 51px" bgColor="#ccccff" colSpan="3" align="center"><asp:label id="Label2" runat="server" Width="318px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="10pt"
							Font-Names="Verdana">SAMPLE TESTING INFORMATION</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 8.7%; HEIGHT: 32px" bgColor="#f0f8ff" align="center"><asp:label id="Label6" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Case No.</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 32px" bgColor="#f0f8ff" align="center"><asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Call Recieve Date</asp:label></TD>
					<TD style="WIDTH: 10%; HEIGHT: 32px" bgColor="#f0f8ff" align="center"><asp:label id="Label7" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Call SNO.</asp:label></TD>
				</TR>
				<tr>
					<TD style="WIDTH: 17.46%; HEIGHT: 37px" bgColor="#f0f8ff" align="center"><asp:textbox onblur="makeUppercase();" id="txtCaseNo" tabIndex="6" runat="server" Width="104px"
							ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="9" Height="20px"></asp:textbox></TD>
					<TD style="WIDTH: 20%; HEIGHT: 37px" bgColor="#f0f8ff" align="center"><asp:textbox onblur="check_date(txtRdt);" id="txtRdt" tabIndex="7" runat="server" Width="104px"
							ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Height="20px"></asp:textbox></TD>
					<TD style="WIDTH: 10%; HEIGHT: 37px" bgColor="#f0f8ff" align="center"><asp:textbox id="txtCSNO" tabIndex="8" runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" MaxLength="5" Height="20px"></asp:textbox></TD>
				</tr>
				<tr>
					<TD style="WIDTH: 100%; HEIGHT: 5px" bgColor="#f0f8ff" align="center" colspan="3"><asp:label id="Label_exist" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:label></TD>
				</tr>
				<tr>
					<td style="HEIGHT: 36px" bgColor="#f0f8ff" colSpan="3" align="center"><asp:button id="btnAdd" tabIndex="9" runat="server" Width="112px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Add New" Visible="False" onclick="btnAdd_Click"></asp:button><asp:button id="btnUpd" tabIndex="9" runat="server" Width="112px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Modify" Visible="False" onclick="btnUpd_Click"></asp:button><asp:button id="btnSearch" tabIndex="10" runat="server" Width="112px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 21px" colSpan="3" align="center"><asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">Search Result is Sorted on [Call Date]</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" colSpan="5" align="center"><asp:label id="Label32" runat="server" Width="256px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="10pt" Font-Names="Verdana" BackColor="White" Visible="False">LAB SAMPLE TESTING DETAILS</asp:label><TITTLE:CUSTOMDATAGRID id="DgPO1" runat="server" Width="100%" Height="8px" AutoGenerateColumns="False"
							PageSize="15" BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="150px" GridWidth="100%">
							<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
							<EditItemStyle Height="10%"></EditItemStyle>
							<FooterStyle CssClass="GridHeader"></FooterStyle>
							<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
								CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="SNo.">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink id=Hyperlink1 Text='Select' Runat="server" NavigateUrl='<%#"Lab_Sample_Info.aspx?case_no=" + DataBinder.Eval(Container.DataItem,"case_no") + "&amp;call_recv_dt="+DataBinder.Eval(Container.DataItem,"call_recv_dt")+"&amp;call_sno="+DataBinder.Eval(Container.DataItem,"call_sno")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="case_no" HeaderText="Case No">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="call_recv_dt" HeaderText="Call Recv date">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="call_sno" HeaderText="S No">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ie_name" HeaderText="IE Name">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
				<TR>
					<TD colSpan="3" align="center"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
