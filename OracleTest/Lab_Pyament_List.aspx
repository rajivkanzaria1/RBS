<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab_Pyament_List.aspx.cs" Inherits="RBS.Lab_Pyament_List.Lab_Pyament_List" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lab_Pyament_List</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 184px"
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
									BackColor="White" Width="100%" Font-Bold="True" Height="19px">LAB SAMPLE PAYMENT SUBMITTED BY VENDORS AWAITING FOR APPROVAL OF FINANCE</asp:label></P>
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
												<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"Lab_Payment_Approve_Form.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"case_no")+ "&amp;S_NO=" + DataBinder.Eval(Container.DataItem,"call_sno")+ "&amp;CALL_DTC="+ DataBinder.Eval(Container.DataItem,"C_LDT")%>'>Select</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="case_no" ReadOnly="True" HeaderText="Case Number">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="call_recv_dt" ReadOnly="True" HeaderText="Call Recv Date">
											<HeaderStyle Width="15%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="call_sno" ReadOnly="True" HeaderText="SNo">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="testing_charges_lab" ReadOnly="True" HeaderText="Gross Testing Charges(Submitted by LAB official)">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="GROSS_VENDOR" HeaderText="Gross Testing Charges(Submitted By Vendor)"></asp:BoundColumn>
										<asp:BoundColumn DataField="testing_charges_vend" ReadOnly="True" HeaderText="Net Testing Charges(Submitted by Vendor)">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TDS" HeaderText="TDS (If Any)"></asp:BoundColumn>
										<asp:BoundColumn DataField="RE_DOC" HeaderText="Payment Reciept(Uploaded by Vendor)"></asp:BoundColumn>
										<asp:BoundColumn DataField="doc_status_fin" ReadOnly="True" HeaderText="Status">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="C_LDT" ReadOnly="True" HeaderText="C_DTC">
											<HeaderStyle Width="20%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="VENDOR" HeaderText="Vendor/Contractor"></asp:BoundColumn>
										<asp:BoundColumn DataField="MFG" HeaderText="Manufacturer"></asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID><asp:label id="lblError" runat="server" Font-Names="Verdana" Font-Size="Large" ForeColor="Crimson"
									BackColor="White" Font-Bold="True" Visible="False">No found. !!!</asp:label></DIV>
						</TD>
					</TR>
					<TR>
						<TD align="center"><asp:button id="btnCancel" tabIndex="30" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Width="58px" Font-Bold="True" Text="Cancel"></asp:button></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
