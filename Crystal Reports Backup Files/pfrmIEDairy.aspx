<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pfrmIEDairy.aspx.cs" Inherits="RBS.Reports.pfrmIEDairy" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>pfrmIEDairy</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="../date.js"></script>
		<script language="javascript">
		function txtCopy()
		{
			
			if(check_date(document.Form1.frmDt)==true && trimAll(document.Form1.toDt.value)=="")
			{
				document.Form1.toDt.value=document.Form1.frmDt.value;
			}
			
		}
		

        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="False">
				<asp:Button id="btnPrintP" tabIndex="10" runat="server" Text="Print"></asp:Button>
				<INPUT id="Button1" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
			</asp:panel><asp:panel id="Panel1" runat="server" Height="200px">
				<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
					cellSpacing="0" cellPadding="0" width="710" align="center" border="0">
					<TR align="center">
						<TD colSpan="2">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 25px" align="center" colSpan="2">
							<P>
								<asp:label id="Label1" runat="server" Width="248px" BackColor="White" ForeColor="DarkBlue"
									Font-Bold="True" Font-Names="Verdana" Font-Size="10pt">IE DAIRY REPORT</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="Table2" borderColor="#b0c4de" cellSpacing="0" cellPadding="0" width="70%" align="center"
								bgColor="#f0f8ff" border="1">
								<% if (Request.Params ["ACTION"]=="E") {%>
								<TR>
									<TD style="WIDTH: 13.17%; HEIGHT: 31px" align="center">
										<asp:radiobutton id="rdbIEWise" tabIndex="1" runat="server" Text="IE Wise" ForeColor="DarkBlue" Font-Bold="True"
											Font-Names="Verdana" Font-Size="10pt" GroupName="g2" AutoPostBack="True" Checked="True"></asp:radiobutton></TD>
									<TD style="WIDTH: 10%; HEIGHT: 31px" align="left">
										<asp:radiobutton id="rdbAll" tabIndex="3" runat="server" Text="ALL IE's" ForeColor="DarkBlue" Font-Names="Verdana"
											Font-Size="10pt" GroupName="g1" AutoPostBack="True" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="rdbPart" tabIndex="4" runat="server" Text="For Particular IE" ForeColor="DarkBlue"
											Font-Names="Verdana" Font-Size="10pt" GroupName="g1" AutoPostBack="True"></asp:radiobutton></TD>
								</TR>
								<TR bgColor="#f0f8ff">
									<TD style="WIDTH: 13.17%; HEIGHT: 21px" align="center"><FONT face="Verdana" color="darkblue" size="2">
											<asp:label id="lblIECO" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
												Font-Size="8pt">IE </asp:label></FONT></TD>
									<TD style="HEIGHT: 21px">
										<asp:dropdownlist id="lstIE" tabIndex="5" runat="server" Height="25px" Width="60%" ForeColor="DarkBlue"
											Font-Names="Verdana" Font-Size="8pt"></asp:dropdownlist></FONT></TD>
								</TR>
								<%}%>
								<TR bgColor="#f0f8ff">
									<TD style="WIDTH: 21.27%">
										<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:label id="Label2" runat="server" Width="120px" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
												Font-Size="8pt">For The Period</asp:label></P>
									</TD>
									<TD style="WIDTH: 30%">
										<P>
											<asp:label id="Label3" runat="server" Width="42px" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
												Font-Size="8pt">From</asp:label>
											<asp:textbox id="frmDt" onblur="check_date(frmDt);txtCopy();" style="TEXT-ALIGN: center" tabIndex="3"
												runat="server" Height="20px" Width="30%" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
												MaxLength="10"></asp:textbox>
											<asp:label id="Label4" runat="server" Width="42px" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
												Font-Size="8pt">To</asp:label>
											<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
												style="TEXT-ALIGN: center" tabIndex="4" runat="server" Height="20px" Width="30%" ForeColor="DarkBlue"
												Font-Names="Verdana" Font-Size="8pt" MaxLength="10"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 21.27%" align="center">
										<asp:label id="Label5" runat="server" Width="120px" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
											Font-Size="8pt">Sorted On</asp:label></TD>
									<TD style="WIDTH: 30%">
										<asp:radiobutton id="rdbIESort" tabIndex="3" runat="server" Text="CALL RECV DT" ForeColor="DarkBlue"
											Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" GroupName="g3" AutoPostBack="True" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="rdbVisitDTSort" tabIndex="3" runat="server" Text="VISIT DATE" ForeColor="DarkBlue"
											Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" GroupName="g3" AutoPostBack="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<P>
								<asp:button id="btnGenerate" tabIndex="9" runat="server" Text="Generate Report" BackColor="#C0C0FF"
									ForeColor="DarkBlue" Font-Bold="True"></asp:button></P>
							</B></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
