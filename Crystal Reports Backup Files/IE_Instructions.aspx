<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_Instructions.aspx.cs" Inherits="RBS.IE_Instructions.IE_Instructions" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IE_Instructions</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px" id="Table1"
				border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 52px" align="center">
							<P><asp:label id="Label1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt"
									Font-Names="Verdana" BackColor="White" Width="177px"> INSTRUCTIONS FOR IE's</asp:label>
							</P>
						</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 21px" align="center" width="100%">
							<marquee behavior="scroll" width="100%">
								<asp:label id="lblLatestMess" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
									Font-Bold="True"></asp:label></marquee>
						</td>
						</MARQUEE>
					</tr>
					<TR>
						<TD align="center">
							<DIV><TITTLE:CUSTOMDATAGRID id="grdInstructions" runat="server" BorderColor="DarkBlue" Width="100%" AutoGenerateColumns="False"
									Height="8px" GridWidth="90%" GridHeight="325px" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px"
									AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" CellPadding="2" FreezeRows="1" PageSize="15"
									HorizontalAlign="Left">
									<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
									<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
									<EditItemStyle Height="10%"></EditItemStyle>
									<FooterStyle CssClass="GridHeader"></FooterStyle>
									<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
									<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%"
										ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:BoundColumn DataField="MESSAGE_ID" HeaderText="Message ID">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="MESSAGE_DATE" HeaderText="Message Dt"></asp:BoundColumn>
										<asp:BoundColumn DataField="MESSAGE" HeaderText="Message">
											<HeaderStyle Width="60%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LETTER_NO" HeaderText="Letter No.">
											<HeaderStyle Width="15%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LETTER_DT" HeaderText="Letter Date">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></DIV>
							<P>&nbsp;</P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P><asp:label id="Label13" runat="server" Font-Bold="True" ForeColor="DarkMagenta" Font-Size="8pt"
									Font-Names="Verdana" Width="100%">Plz Read all the Instructions Carefully Before Proceeding !!!</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:label id="Label2" runat="server" Width="391px" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
								Font-Bold="True">Please Enter your DSC expiry Date (In DD/MM/YYYY) :</asp:label>
							<asp:TextBox id="txtDSCExpiryDT" onblur="check_date(txtDSCExpiryDT);" runat="server" Width="153px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:HyperLink id="HyperLink1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True">Steps to Check DSC Expiry Date</asp:HyperLink></TD>
					</TR>
					<TR>
						<TD align="center">
							<P><asp:button id="btnNext" tabIndex="10" runat="server" Font-Bold="True" ForeColor="DarkBlue"
									Font-Size="8pt" Font-Names="Verdana" Width="66px" Text="Proceed" onclick="btnNext_Click"></asp:button></P>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		<DIV>&nbsp;</DIV>
		</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
