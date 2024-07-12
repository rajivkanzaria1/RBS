<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<%@ Page language="c#" Codebehind="pfrmTrainingDetails.aspx.cs" AutoEventWireup="false" Inherits="RBS.Reports.pfrmTrainingDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>pfrmTrainingDetails</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel2" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 0px" runat="server"
				Visible="False" Height="1px" Width="100%">
				<asp:Button id="btnPrint" runat="server" Text="Print"></asp:Button>
				<INPUT id="Button1" onclick="history.go(-1)" value="Go Back" type="button" name="Button1">
			</asp:panel><asp:panel id="Panel1" runat="server" Height="208px">
				<TABLE style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; TOP: 8px; LEFT: 8px" id="Table1"
					border="0" cellSpacing="0" cellPadding="0" width="100%">
					<TR>
						<TD style="HEIGHT: 52px" colSpan="2" align="center">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 13.17%; HEIGHT: 21px" colSpan="2" align="center">
							<asp:label id="Label5" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt"
								Font-Names="Verdana">IE TRAINING DETAILS</asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 13.17%; HEIGHT: 22px" colSpan="2" align="center">
							<TABLE id="Table2" border="1" cellSpacing="1" borderColor="#b0c4de" cellPadding="1" width="80%"
								bgColor="#f0f8ff">
								<TR>
									<TD style="WIDTH: 114px">
										<asp:label id="Label1" runat="server" Width="40%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Discipline</asp:label></TD>
									<TD colSpan="2">
										<asp:radiobutton id="rdbAll" runat="server" Width="19%" Text="All" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" GroupName="g1" Checked="True"></asp:radiobutton>
										<asp:radiobutton id="rdbMech" runat="server" Width="19%" Text="Mechanical" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" GroupName="g1"></asp:radiobutton>
										<asp:radiobutton id="rdbElec" runat="server" Width="19%" Text="Electrical" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" GroupName="g1"></asp:radiobutton>
										<asp:radiobutton id="rdbCiv" runat="server" Width="19%" Text="Civil" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" GroupName="g1"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 114px; HEIGHT: 22px">
										<asp:label id="Label2" runat="server" Width="88px" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Category</asp:label></TD>
									<TD style="WIDTH: 597px; HEIGHT: 22px" colSpan="2">
										<asp:radiobutton id="rdbAllCat" runat="server" Width="25%" Text="All " Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" GroupName="g3" Checked="True"></asp:radiobutton>
										<asp:radiobutton id="rdbRegular" runat="server" Width="176px" Text="Regular" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" GroupName="g3"></asp:radiobutton>
										<asp:radiobutton id="rdbDepu" runat="server" Width="176px" Text="Deputaion" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" GroupName="g3"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 114px; HEIGHT: 32px">
										<asp:label id="lblFrom" runat="server" Width="40%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE</asp:label></TD>
									<TD style="WIDTH: 597px; HEIGHT: 32px" colSpan="2">
										<asp:radiobutton id="rdbAllIE" runat="server" Width="25%" Text="All IE" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" GroupName="g2" Checked="True" AutoPostBack="True"></asp:radiobutton>
										<asp:radiobutton id="rdbPIE" runat="server" Width="176px" Text="Particular IE" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" GroupName="g2" AutoPostBack="True"></asp:radiobutton>
										<asp:dropdownlist id="lstIE" runat="server" Width="50%" Height="25px" Visible="False" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 114px">
										<asp:label id="lblTo" runat="server" Width="96px" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Training Area</asp:label></TD>
									<TD style="WIDTH: 597px" colSpan="2">
										<asp:radiobutton id="rdbAllTArea" runat="server" Width="25%" Text="All " Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" GroupName="g4" Checked="True" AutoPostBack="True"></asp:radiobutton>
										<asp:radiobutton id="rdbPArea" runat="server" Width="176px" Text="Particular Area" Font-Bold="True"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" GroupName="g4" AutoPostBack="True"></asp:radiobutton>
										<asp:dropdownlist id="lstField" runat="server" Width="40%" Visible="False" Font-Bold="True" ForeColor="Blue"
											Font-Size="8pt" Font-Names="Verdana" AutoPostBack="True">
											<asp:ListItem Value="W">Welding</asp:ListItem>
											<asp:ListItem Value="N">NDT</asp:ListItem>
											<asp:ListItem Value="M">Metrology</asp:ListItem>
											<asp:ListItem Value="P">Plastic</asp:ListItem>
											<asp:ListItem Value="T">Textile</asp:ListItem>
											<asp:ListItem Value="A">Paint</asp:ListItem>
											<asp:ListItem Value="R">Transformer</asp:ListItem>
											<asp:ListItem Value="C">Cable </asp:ListItem>
											<asp:ListItem Value="E">Energy Audit</asp:ListItem>
											<asp:ListItem Value="V">Pressure Vessal</asp:ListItem>
											<asp:ListItem Value="I">Pipeline</asp:ListItem>
											<asp:ListItem Value="B">Rubber</asp:ListItem>
											<asp:ListItem Value="X">M&amp;P</asp:ListItem>
											<asp:ListItem Value="O">ISO</asp:ListItem>
											<asp:ListItem Value="D">DRG Reading</asp:ListItem>
											<asp:ListItem Value="Y">Other</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2" align="center">
							<asp:button id="btnView" runat="server" Text="View" Font-Bold="True" ForeColor="DarkBlue" Font-Names="Verdana"
								DESIGNTIMEDRAGDROP="10"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
