<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientWiseControlling.aspx.cs" Inherits="RBS.ClientWiseControlling.ClientWiseControlling" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ClientWiseControlling</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function txtCopy()
		{
			
			if(check_date(document.Form1.frmDt)==true && trimAll(document.Form1.toDt.value)=="")
			{
				document.Form1.toDt.value=document.Form1.frmDt.value;
			}
			
		}
		
		function validate()
		{
			if(document.Form1.lstClientType.value=="")
			{
				alert("You Cannot Leave Client Type Blank!!!");
				event.returnValue=false;
			}
			else if(document.Form1.frmDt=="[object]" && trimAll(document.Form1.frmDt.value)=="")
			{
				alert("You Cannot Leave From Date Blank!!!");
				event.returnValue=false;
			}
			
		}
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Height="1px" Visible="False" Width="100%">
				<asp:Button id="btnPrint" runat="server" Text="Print"></asp:Button>
				<asp:Button id="btnBack" runat="server" Text="Go Back"></asp:Button>
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Height="1px" Width="100%">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
					cellSpacing="0" cellPadding="0" width="100%" bgColor="#f0f8ff" border="1">
					<TR>
						<TD align="center" colSpan="3">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 32px" align="center" colSpan="3"><FONT face="Verdana" color="darkblue" size="4"><STRONG>
									<asp:label id="lblHeader" runat="server" Width="90%" Font-Size="10pt" Font-Names="Verdana">CLIENT WISE CONTROLLING</asp:label></STRONG></FONT></TD>
					</TR>
					<TR bgColor="lightsteelblue">
						<TD style="WIDTH: 20%">
							<asp:label id="Label2" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
								Font-Bold="True">Controlling Manager</asp:label></TD>
						<TD style="WIDTH: 80%" colSpan="2">
							<asp:dropdownlist id="lstCO" tabIndex="1" runat="server" Width="40%" Height="25px" Font-Size="8pt"
								Font-Names="Verdana" ForeColor="DarkBlue"></asp:dropdownlist></TD>
					</TR>
					<TR bgColor="lightsteelblue">
						<TD style="WIDTH: 20%"><STRONG><FONT face="Verdana" size="2">
									<asp:label id="Label6" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
										Font-Bold="True">Client Type</asp:label></FONT></STRONG></TD>
						<TD style="WIDTH: 80%" colSpan="2"><FONT face="Verdana" size="2">
								<asp:dropdownlist id="lstClientType" runat="server" Width="20%" Font-Size="8pt" Font-Names="Verdana"
									ForeColor="DarkBlue" AutoPostBack="True"></asp:dropdownlist></FONT></TD>
					</TR>
					<TR bgColor="lightsteelblue">
						<TD style="WIDTH: 20%; HEIGHT: 24px">
							<asp:label id="Label1" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
								Font-Bold="True">Select Client</asp:label></TD>
						<TD style="WIDTH: 80%; HEIGHT: 24px" colSpan="2">
							<asp:dropdownlist id="lstBPO_Rly" runat="server" Width="98%" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue"></asp:dropdownlist></TD>
					</TR>
					<TR bgColor="lightsteelblue">
						<TD style="WIDTH: 20%; HEIGHT: 24px">
							<asp:label id="Label4" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
								Font-Bold="True">From Date</asp:label></TD>
						<TD style="WIDTH: 80%; HEIGHT: 24px" colSpan="2">
							<asp:textbox id="frmDt" onblur="check_date(frmDt);" style="TEXT-ALIGN: center" tabIndex="3" runat="server"
								Width="100px" Height="20px" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 20%; HEIGHT: 24px" align="center" colSpan="3">
							<asp:button id="btnSave" tabIndex="8" runat="server" Width="67px" Text="Save" Font-Size="8pt"
								Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True"></asp:button>
							<asp:button id="btnCancel" tabIndex="9" runat="server" Width="67px" Text="Cancel" Font-Size="8pt"
								Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True"></asp:button>
							<asp:button id="btnSearch" tabIndex="9" runat="server" Width="67px" Text="Search" Font-Size="8pt"
								Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True"></asp:button></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 20%; HEIGHT: 24px" align="center" colSpan="3">
							<TITTLE:CUSTOMDATAGRID id="grdCC" runat="server" Width="90%" Height="8px" PageSize="15" FreezeRows="0"
								CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
								BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="200px"
								GridWidth="100%">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
									CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="CO_NAME" HeaderText="Controlling Manager">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CLIENT_TYPE" HeaderText="Client Type">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RLY_CD" HeaderText="Client">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FR_DT" HeaderText="FROM Date">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TO_DT" HeaderText="TO Date"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></TD>
					</TR>
				</TABLE>
			</asp:panel>
		</form>
	</body>
</HTML>
