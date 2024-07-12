<%@ Page language="c#" Codebehind="pfrmOngoing_Contracts.aspx.cs" AutoEventWireup="false" Inherits="RBS.Reports.pfrmOngoing_Contracts" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>pfrmOngoing_Contracts</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		
		function validate1()
		{
		if(trimAll(document.Form1.lstBPORegion.value)=="")
		{
		 alert("Kindly select Region");
		 event.returnValue=false;
		}
		return;
		}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 0px" runat="server"
				Width="100%" Height="1px" Visible="False">
				<asp:Button id="btnBack" runat="server" Text="Go Back"></asp:Button>
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 0px" runat="server"
				Width="100%" Height="1px">
				<TABLE style="Z-INDEX: 102; POSITION: absolute; HEIGHT: 152px; TOP: 8px; LEFT: 8px" id="Table1"
					border="0" cellSpacing="0" cellPadding="0" width="100%">
					<TR>
						<TD style="HEIGHT: 45px" colSpan="5" align="center">
							<asp:label id="Label1" runat="server" Width="100%" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="10pt" Font-Bold="True">ONGOING CONTRACTS</asp:label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 50px" colSpan="5" align="center">
							<TABLE style="WIDTH: 90%; HEIGHT: 32px" id="Table_Sample_Registration" border="1" cellSpacing="1"
								borderColor="#b0c4de" cellPadding="1" bgColor="#f0f8ff" runat="server">
								<TR>
									<TD>
										<P>
											<asp:radiobutton id="rdb_New" runat="server" Text="For Region Wise" ForeColor="DarkBlue" Font-Names="Verdana"
												Font-Size="10pt" Font-Bold="True" AutoPostBack="True" GroupName="g2"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:radiobutton id="rdb_Exist" runat="server" Text="For All Region" ForeColor="DarkBlue" Font-Names="Verdana"
												Font-Size="10pt" Font-Bold="True" AutoPostBack="True" GroupName="g2"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										</P>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 50px" colSpan="5" align="center">
							<TABLE style="WIDTH: 90%; HEIGHT: 32px" id="Table_Region" border="1" cellSpacing="1" borderColor="#b0c4de"
								cellPadding="1" bgColor="#f0f8ff" runat="server" visible="false">
								<TR>
									<TD style="WIDTH: 40%; HEIGHT: 61px" align="right">
										<asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Names="Verdana"
											Font-Size="10pt" Font-Bold="True">Region</asp:label></TD>
									<TD style="WIDTH: 60%; HEIGHT: 61px" colSpan="4" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:dropdownlist id="lstBPORegion" tabIndex="3" runat="server" Height="25px" Width="60%" ForeColor="DarkBlue"
											Font-Names="Verdana" Font-Size="8pt"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 50px" colSpan="5" align="center">
							<TABLE style="WIDTH: 90%; HEIGHT: 32px" id="Table_Status" border="1" cellSpacing="1" borderColor="#b0c4de"
								cellPadding="1" bgColor="#f0f8ff" runat="server">
								<TR>
									<TD style="WIDTH: 40%; HEIGHT: 25px" align="center">
										<asp:label id="Label21" runat="server" Width="159px" ForeColor="DarkBlue" Font-Names="Verdana"
											Font-Size="8pt" Font-Bold="True">Status Of Offer</asp:label></TD>
									<TD style="WIDTH: 60%; HEIGHT: 25px" align="left">
										<asp:dropdownlist id="ddlOfferStatus" runat="server" Width="200px" ForeColor="DarkBlue" Font-Names="Verdana"
											Font-Size="8pt">
											<asp:ListItem Value="E" Selected="True">Ongoing Contract</asp:ListItem>
											<asp:ListItem Value="B">BID Lost</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD colSpan="5" align="center">
							<asp:button id="btnSubmit" runat="server" Text="Search" ForeColor="DarkBlue" Font-Bold="True"
								BackColor="#C0C0FF"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel>
		</form>
	</body>
</HTML>
