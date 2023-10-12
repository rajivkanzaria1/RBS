<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMIEWiseCancellationAcceptance_Form.aspx.cs" Inherits="RBS.CMIEWiseCancellationAcceptance_Form.CMIEWiseCancellationAcceptance_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CMIEWiseCancellationAcceptance_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="False">
				<INPUT id="Button1" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
			</asp:panel><asp:panel id="Panel1" runat="server" Height="200px">
				<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
					cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TBODY>
						<TR align="center">
							<TD colSpan="2">
								<UC1:WEBUSERCONTROL1 id="WebUserControl11" runat="server"></UC1:WEBUSERCONTROL1></TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 46px" align="center" colSpan="2">
								<asp:label id="Label1" runat="server" Height="19px" Width="100%" BackColor="White" Font-Bold="True"
									Font-Size="10pt" Font-Names="Verdana" ForeColor="DarkBlue">CONTROLLING WISE CALLS CANCELLATION APPROVAL FORM</asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 20%; HEIGHT: 25px"><FONT face="Verdana" color="darkblue" size="2">
									<asp:label id="lblIE" runat="server" Width="152px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
										ForeColor="DarkBlue">Controlling Officer </asp:label></FONT></TD>
							<TD style="WIDTH: 80%; HEIGHT: 25px"><FONT face="Verdana" color="darkblue" size="2">
									<asp:dropdownlist id="lstCO" tabIndex="1" runat="server" Height="25px" Width="40%" Font-Size="8pt"
										Font-Names="Verdana" ForeColor="DarkBlue" AutoPostBack="True"></asp:dropdownlist></FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 20%; HEIGHT: 25px">
								<asp:label id="Label2" runat="server" Width="152px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
									ForeColor="DarkBlue">Inspection Engineer</asp:label></TD>
							<TD style="WIDTH: 80%; HEIGHT: 25px">
								<asp:RadioButton id="rdbAllIE" tabIndex="2" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
									ForeColor="DarkBlue" AutoPostBack="True" GroupName="g2" Checked="True" Text="All IE" oncheckedchanged="rdbAllIE_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:RadioButton id="rdbPIE" tabIndex="3" runat="server" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
									ForeColor="DarkBlue" AutoPostBack="True" GroupName="g2" Text="Particular IE" oncheckedchanged="rdbAllIE_CheckedChanged"></asp:RadioButton>
								<asp:dropdownlist id="lstIE" tabIndex="4" runat="server" Visible="False" Height="20px" Width="60%"
									Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"></asp:dropdownlist></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">
								<asp:Button id="btnSubmit" tabIndex="7" runat="server" BackColor="#C0C0FF" Font-Bold="True"
									ForeColor="DarkBlue" Text="Submit" onclick="btnSubmit_Click"></asp:Button></TD>
						</TR>
			</asp:panel><asp:panel id="Panel3" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="TRUE">
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="2">
						<asp:label id="Label3" runat="server" Width="100%" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
							ForeColor="Crimson">Select Calls To Approve Call Cancellation</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<P>
							<TITTLE:CUSTOMDATAGRID id="grdCallcancelApp" runat="server" Visible="False" Height="8px" Width="100%" BorderColor="DarkBlue"
								AutoGenerateColumns="False" GridWidth="90%" GridHeight="300px" FreezeHeader="True" FreezeColumns="0"
								BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" CellPadding="2" FreezeRows="0"
								PageSize="15" HorizontalAlign="Left">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" HorizontalAlign="Center" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" Height="15%"
									ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox id="chkDWplan" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="Hyperlink3" Target=_blank Text='View Call Letter' Runat="server" NavigateUrl='<%#"Print_Call_letter.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;CALL_DT=" + DataBinder.Eval(Container.DataItem,"CALL_RECV_DATE") +"&amp;CALL_SNO=" + DataBinder.Eval(Container.DataItem,"CALL_SNO")%>'>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="Hyperlink2" Target=_blank Text='View Call Cacellation Form' Runat="server" NavigateUrl='<%#"Call_Cancellation_Form.aspx?Action=M&amp;Case_No=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;DT_RECIEPT=" + DataBinder.Eval(Container.DataItem,"CALL_RECV_DATE") +"&amp;CALL_SNO=" + DataBinder.Eval(Container.DataItem,"CALL_SNO")%>'>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="Hyperlink1" Target=_blank Text='View Call Cencel Doc' Runat="server" NavigateUrl='<%# "CALL_CANCELLATION_DOCUMENTS/" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "-" + DataBinder.Eval(Container.DataItem,"CALL_DT_CONCAT") +"-" + DataBinder.Eval(Container.DataItem,"CALL_SNO")+".PDF"%>'>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
										<HeaderStyle Width="7%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_RECV_DATE" HeaderText="Call Date">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_SNO" HeaderText="Call SNo.">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CALL_DT_CONCAT" HeaderText="Call Status">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MFG" HeaderText="Manufacturer">
										<HeaderStyle Width="25%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="MFG_CD" HeaderText="MFG_CD"></asp:BoundColumn>
									<asp:BoundColumn DataField="MFG_PLACE" HeaderText="Manufacturer Place">
										<HeaderStyle Width="25%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CO_CD" HeaderText="CO_CD"></asp:BoundColumn>
									<asp:BoundColumn DataField="DESIRE_DT" HeaderText="Desire Dt"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<asp:Button id="btbApprove" tabIndex="7" runat="server" BackColor="#C0C0FF" Font-Bold="True"
							ForeColor="DarkBlue" Text="Approve" onclick="btbApprove_Click"></asp:Button></TD>
				</TR>
			</asp:panel></TBODY></TABLE></form>
	</body>
</HTML>

