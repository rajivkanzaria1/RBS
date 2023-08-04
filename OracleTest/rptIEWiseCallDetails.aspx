<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptIEWiseCallDetails.aspx.cs" Inherits="RBS.rptIEWiseCallDetails.rptIEWiseCallDetails" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>rptIEWiseCallDetails</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="../date.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD style="HEIGHT: 14px" align="center" colSpan="5">
						<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 13.17%; HEIGHT: 21px" align="center" colSpan="5">
						<asp:label id="Label5" runat="server" Width="339px" Font-Names="Verdana" ForeColor="DarkBlue"
							Font-Bold="True" Font-Size="10pt">IE WISE CALL DETAILS DURING THE PERIOD </asp:label></TD>
				</TR>
				<TR bgColor="#f0f8ff">
					<TD style="WIDTH: 40%; HEIGHT: 41px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">
								&nbsp;For The Period --&gt;</FONT></B></TD>
					<TD style="WIDTH: 10%; HEIGHT: 41px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">From</FONT></B></TD>
					<TD style="WIDTH: 19.1%; HEIGHT: 41px">
						<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
							style="TEXT-ALIGN: center" tabIndex="11" runat="server" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Names="Verdana" Width="60%" MaxLength="10" Height="20px"></asp:textbox></TD>
					<TD style="WIDTH: 10%; HEIGHT: 41px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">To</FONT></B></TD>
					<TD style="WIDTH: 30%; HEIGHT: 41px">
						<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
							style="TEXT-ALIGN: center" tabIndex="11" runat="server" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Names="Verdana" Width="60%" MaxLength="10" Height="20px"></asp:textbox></TD>
				</TR>
				<TR bgColor="#f0f8ff">
					<TD align="center" colSpan="5">
						<asp:button id="btnSubmit" runat="server" Text="Submit" BackColor="#C0C0FF" ForeColor="DarkBlue"
							Font-Bold="True"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="5">
						<asp:datagrid id="grdIE" runat="server" Font-Size="8pt" Font-Names="Verdana" Width="60%" BackColor="White"
							Height="100px" PageSize="1" CellPadding="0" BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False">
							<SelectedItemStyle Font-Names="Verdana"></SelectedItemStyle>
							<EditItemStyle Font-Names="Verdana" Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Font-Names="Verdana" BackColor="#CCCCFF"></AlternatingItemStyle>
							<ItemStyle Font-Names="Verdana" HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center" ForeColor="DarkBlue"
								VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="IE_NAME" HeaderText="IE Full Name">
									<HeaderStyle Width="60%"></HeaderStyle>
									<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NO_OF_CALLS" HeaderText="NO. Of Calls">
									<HeaderStyle Width="40%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
