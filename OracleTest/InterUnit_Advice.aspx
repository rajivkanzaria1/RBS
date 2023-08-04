<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterUnit_Advice.aspx.cs" Inherits="RBS.InterUnit_Advice.InterUnit_Advice" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Inter Unit Advice</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript" type="text/javascript">
		
		function validate()
		{
		if(trimAll(document.Form1.txtAdviceDT.value)=="")
		{
		 alert("Advice Date Cannot Be Left Blank");
		 event.returnValue=false;
		}
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
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center" colSpan="4">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"><asp:label id="Label1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt"
							Font-Names="Verdana" Width="100%" BackColor="White"> INTER UNIT ADVICE</asp:label></TD>
				</TR>
				<TR bgColor="#f0f8ff">
					<TD style="WIDTH: 15%" align="left" colSpan="1" rowSpan="1"><FONT face="Verdana" color="darkblue" size="2"><asp:label id="Label27" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Width="104px"> Advice For Region</asp:label></FONT></TD>
					<TD style="WIDTH: 35%"><FONT face="Verdana" color="darkblue" size="2"><asp:dropdownlist id="lstACD" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
								Width="60%">
								<asp:ListItem Value="3007">Northern Region</asp:ListItem>
								<asp:ListItem Value="3008">Eastern Region</asp:ListItem>
								<asp:ListItem Value="3009">Southern Region</asp:ListItem>
								<asp:ListItem Value="3006">Western Region</asp:ListItem>
								<asp:ListItem Value="3066">Central Region</asp:ListItem>
							</asp:dropdownlist></FONT></TD>
					<TD style="WIDTH: 15%" align="left"><FONT face="Verdana" color="darkblue" size="2"><asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Width="100%"> Advice Date</asp:label></FONT></TD>
					<TD style="WIDTH: 35%"><FONT face="Verdana" color="darkblue" size="2"><asp:textbox id="txtAdviceDT" onblur="check_date(txtAdviceDT);" tabIndex="3" runat="server" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Width="30%" MaxLength="10" Height="20px"></asp:textbox></FONT></TD>
				</TR>
				<TR bgColor="#f0f8ff">
					<TD style="WIDTH: 15%" align="left"><FONT face="Verdana" color="darkblue" size="2"><asp:label id="lblAdvNo" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Width="104px"> Advice No.</asp:label></FONT></TD>
					<TD style="WIDTH: 35%"><FONT face="Verdana" color="darkblue" size="2"><asp:label id="txtAdvNO" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
								Font-Names="Verdana" Width="100%" Height="16px"></asp:label></FONT></TD>
					<TD style="WIDTH: 15%" align="left"><FONT face="Verdana" color="darkblue" size="2"><asp:label id="lblAdvAmt" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Width="112px"> Total Advice Amount</asp:label></FONT></TD>
					<TD style="WIDTH: 35%"><FONT face="Verdana" color="darkblue" size="2"><asp:label id="txtAdvAMT" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
								Font-Names="Verdana" Width="100%" Height="16px"></asp:label></FONT></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"><asp:button id="btnView" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="View Transaction"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"><TITTLE:CUSTOMDATAGRID id="grdAdvDetails" runat="server" Width="90%" Height="8px" GridWidth="100%" GridHeight="200px"
							AutoGenerateColumns="False" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" BorderColor="DarkBlue" AddEmptyHeaders="0"
							CssClass="Grid" UseAccessibleHeader="True" CellPadding="2" FreezeRows="0" PageSize="15">
							<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
							<EditItemStyle Height="10%"></EditItemStyle>
							<FooterStyle CssClass="GridHeader"></FooterStyle>
							<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
								CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="VCHR_NO" HeaderText="JV Reference No."></asp:BoundColumn>
								<asp:BoundColumn DataField="CHQ_NO" HeaderText="Cheque No.">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CHQ_DT" HeaderText="Cheque Date">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BANK" HeaderText="Bank">
									<HeaderStyle Width="30%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AMOUNT" HeaderText="Transferred Amount">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="REGION" HeaderText="Region To Which Transferred">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Select">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox id="SelCH" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">
						<P><asp:button id="btnSave" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Text="Save"></asp:button></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
