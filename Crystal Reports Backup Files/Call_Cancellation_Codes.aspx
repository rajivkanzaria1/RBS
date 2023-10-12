<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Cancellation_Codes.aspx.cs" Inherits="RBS.Call_Cancellation_Codes.Call_Cancellation_Codes" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CALL CANCELLATION CODES</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{
		if(document.Form1.txtCdesc.value=="")
		{
			alert("CALL DESCRIPTION CANNOT LEFT BLANK EMPLOYEE NO.");
			event.returnValue=false;
		}
		
		else
		return;
		}
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
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 375px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 100%" align="center" colSpan="5"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Font-Underline="True" Font-Names="Verdana" Font-Size="10pt"
								BackColor="White" Font-Bold="True" ForeColor="DarkBlue">CALL CANCELLATION CODES</asp:label></P>
						<P align="center">
							<TABLE id="Table2" style="HEIGHT: 64px" cellSpacing="0" cellPadding="0" width="50%" align="center"
								bgColor="aliceblue" border="0">
								<TR>
									<td style="WIDTH: 299px; HEIGHT: 23px" colSpan="2"><asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue">Cancellation Code.</asp:label></td>
									<td style="WIDTH: 264px; HEIGHT: 23px" colSpan="3"><asp:textbox id="txtCCode" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Height="20px" Enabled="False" MaxLength="2" Width="100px"></asp:textbox></td>
								</TR>
								<TR>
									<td style="WIDTH: 299px; HEIGHT: 96px" colSpan="2"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue">Cancel Description</asp:label></td>
									<td style="WIDTH: 264px; HEIGHT: 96px" colSpan="3"><asp:textbox id="txtCdesc" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Height="63px" MaxLength="100" Width="235px" TextMode="MultiLine" ontextchanged="txtCdesc_TextChanged"></asp:textbox></td>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%" align="center" colSpan="5">
						<P align="center"><asp:button id="btnAdd" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Text="AddNew" onclick="btnAdd_Click"></asp:button><asp:button id="btnSave" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="DarkBlue" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnCancel" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="DarkBlue" Text="Cancel" onclick="btnCancel_Click"></asp:button></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%" align="center" colSpan="5"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%" align="center" colSpan="5"><asp:datagrid id="grdCCDetails" runat="server" Font-Names="Verdana" Font-Size="8pt" BackColor="White"
							Height="100px" Width="50%" PageSize="1" CellPadding="0" BorderColor="Navy" BorderStyle="Groove" AutoGenerateColumns="False">
							<FooterStyle Wrap="False"></FooterStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center" ForeColor="DarkBlue"
								VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:HyperLinkColumn Text="Select" DataNavigateUrlField="CANCEL_CD" DataNavigateUrlFormatString="Call_Cancellation_Codes.aspx?CANCEL_CD={0}"
									NavigateUrl="Call_Cancellation_Codes.aspx">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="CANCEL_CD" HeaderText="Cancellation Code">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CANCEL_DESC" HeaderText="Cancellation Description">
									<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
									<HeaderStyle Width="60%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
