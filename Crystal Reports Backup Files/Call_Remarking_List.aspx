<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Remarking_List.aspx.cs" Inherits="RBS.Call_Remarking_List.Call_Remarking_List" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Call_Remarking_List</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 184px; TOP: 8px; LEFT: 8px"
				cellSpacing="1" cellPadding="1" border="0">
				<TBODY>
					<TR>
						<TD>
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
									BackColor="White" Width="100%" Font-Bold="True" Height="19px">CALL REMARK SUBMITTED BY CONTROLLING MANAGER'S AWAITING FOR APPROVAL</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<DIV><TITTLE:CUSTOMDATAGRID id="DgPO1" runat="server" Width="100%" Height="8px" AutoGenerateColumns="False"
									PageSize="15" BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid"
									AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="500px" GridWidth="100%">
									<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
									<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
									<FooterStyle CssClass="GridHeader"></FooterStyle>
									<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
									<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
										CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn HeaderText="Select">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemTemplate>
												<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"CALL_REMARK_APPROVE_Form.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"case_no")+ "&amp;CALL_DTC="+ DataBinder.Eval(Container.DataItem,"CS_DTC")+ "&amp;CALL_SNO="+ DataBinder.Eval(Container.DataItem,"call_sno")%>'>Select</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="case_no" HeaderText="Case No.">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CALL_RECV_DT" HeaderText="Call Date">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="call_sno" HeaderText="Call SNo.">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="remarking_status" HeaderText="Call Status">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ie_name_from" HeaderText="From IE">
											<HeaderStyle Width="25%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ie_name_to" HeaderText="To IE">
											<HeaderStyle Width="25%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="fr_ie_pending_calls" HeaderText="From IE Pending Calls">
											<HeaderStyle Width="25%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="to_ie_pending_calls" HeaderText="To IE Pending Calls">
											<HeaderStyle Width="25%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="user_name" HeaderText="Initiated By">
											<HeaderStyle Width="25%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LOGIN_TIME" HeaderText="Initiated DateTime">
											<HeaderStyle Width="25%"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID><asp:label id="lblError" runat="server" Font-Names="Verdana" Font-Size="Large" ForeColor="Crimson"
									BackColor="White" Font-Bold="True" Visible="False">No Call Remark found. !!!</asp:label></DIV>
						</TD>
					</TR>
					<TR>
						<TD align="center"><asp:button id="btnCancel" tabIndex="30" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Width="58px" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
