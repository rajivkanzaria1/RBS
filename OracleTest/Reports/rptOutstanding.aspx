<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<%@ Page language="c#" Codebehind="rptOutstanding.aspx.cs" AutoEventWireup="false" Inherits="RBS.Reports.rptOutstanding" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>rptOutstanding</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="../date.js"></script>
		<script language="javascript">
		function validate()
			{
				if (trimAll(document.Form1.txtDate.value)=="")
				{
					alert("Enter a valid date upto which the outstanding statement is required!!!");
					event.returnValue=false;
				}		
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Visible="False" Height="1px" Width="100%">
				<asp:Button id="btnPrint" runat="server" Text="Print"></asp:Button>
				<asp:Button id="btnCancel" runat="server" Text="Go Back"></asp:Button>
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Height="1px" Width="100%">
				<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 152px"
					cellSpacing="0" cellPadding="0" width="100%" align="center" bgColor="aliceblue" border="0">
					<TR>
						<TD align="center" bgColor="#ffffff">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 58px" align="center" bgColor="#ffffff">
							<asp:label id="Label1" runat="server" Width="728px" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								ForeColor="DarkBlue">CLIENT WISE OUTSTANDING</asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 55px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">
									<asp:label id="lbl_01" runat="server">Client wise Outstanding Statement as on -----></asp:label>&nbsp;
									<asp:TextBox id="txtDate" onblur="check_date(txtDate)" runat="server" Width="87px"></asp:TextBox>&nbsp;(enter 
									date in <FONT color="#993366">dd/mm/yyyy</FONT> format)</FONT></B></TD>
					</TR>
					<% if (Request.Params["action"]=="FNR") {%>
					<TR align="center">
						<TD style="WIDTH: 33.09%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">Realization 
									For The Period --&gt;</FONT></B> <B><FONT face="Verdana" color="darkblue" size="2">
									From</FONT></B>
							<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
								style="TEXT-ALIGN: center" tabIndex="3" runat="server" Height="20px" Width="100px" Font-Names="Verdana"
								Font-Size="8pt" ForeColor="DarkBlue" MaxLength="10"></asp:textbox><B><FONT face="Verdana" color="darkblue" size="2">To</FONT></B>
							<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
								style="TEXT-ALIGN: center" tabIndex="4" runat="server" Height="20px" Width="100px" Font-Names="Verdana"
								Font-Size="8pt" ForeColor="DarkBlue" MaxLength="10"></asp:textbox></TD>
					</TR>
					<%}%>
					<% if (Request.Params["action"]=="S") {%>
					<TR>
						<TD style="HEIGHT: 3px" align="center">
							<asp:label id="lbl_02" runat="server" Font-Names="Verdana" Font-Size="10" Font-Bold="True"
								ForeColor="DarkBlue">Outstanding of Northern Region on Other Regions</asp:label>&nbsp;
							<asp:dropdownlist id="lstRegionCd" runat="server">
								<asp:ListItem Value="N">NORTHERN REGION</asp:ListItem>
								<asp:ListItem Value="E">EASTERN REGION</asp:ListItem>
								<asp:ListItem Value="W">WESTERN REGION</asp:ListItem>
								<asp:ListItem Value="S">SOUTHERN REGION</asp:ListItem>
								<asp:ListItem Value="C">CENTRAL REGION</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 32px" align="center">
							<asp:radiobutton id="btnClient" runat="server" Text="Client Wise" Font-Names="Verdana" Font-Size="Smaller"
								Font-Bold="True" ForeColor="DarkBlue" Checked="True" GroupName="grpClientBPO"></asp:radiobutton></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 32px" align="center">
							<asp:RadioButton id="btnBPO" runat="server" Text=" BPO Wise" Font-Names="Verdana" Font-Size="Smaller"
								Font-Bold="True" ForeColor="DarkBlue" GroupName="grpClientBPO"></asp:RadioButton></TD>
					</TR>
					<%}%>
					<% if (Request.Params["action"]=="P") {%>
					<TR>
						<TD style="HEIGHT: 32px" align="center">
							<P>
								<asp:CheckBox id="chkOutSum" runat="server" Text="Show Sector Wise Summary Only" Font-Names="Verdana"
									Font-Size="Smaller" Font-Bold="True" ForeColor="DarkBlue"></asp:CheckBox></P>
							<P>
								<asp:RadioButton id="rdbFourRegions" runat="server" Text="4 Regions (NR, SR, ER &amp; WR)" Font-Names="Verdana"
									Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" GroupName="g1"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:RadioButton id="rdbAllRegion" runat="server" Text="All Regions (NR, SR, ER, WR &amp; CR)" Font-Names="Verdana"
									Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" GroupName="g1"></asp:RadioButton></P>
						</TD>
					</TR>
					<%}%>
					<% if (Request.Params["action"]=="F") {%>
					<TR>
						<TD style="HEIGHT: 32px" align="center">
							<P>
								<asp:RadioButton id="RdbIE" tabIndex="8" runat="server" Text="Client Wise" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Checked="True" GroupName="g4" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:RadioButton id="RdbCM" tabIndex="9" runat="server" Text="Sorted on Outstading(Outstanding amount is greater then zero OR Total Suspense is greater then zero)"
									Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" GroupName="g4" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;
							</P>
						</TD>
					</TR>
					<%}%>
					<% if (Request.Params["action"]=="R") {%>
					<TR>
						<TD style="HEIGHT: 32px" align="center">
							<P>
								<asp:RadioButton id="Rdb_Cl" tabIndex="8" runat="server" Text="Client Wise" Font-Names="Verdana"
									Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Checked="True" GroupName="g5" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:RadioButton id="Rdb_SO" tabIndex="9" runat="server" Text="Sorted on Outstading(Outstanding amount is greater then zero OR Total Suspense is greater then zero)"
									Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" GroupName="g5" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;
							</P>
						</TD>
					</TR>
					<%}%>
					<TR>
						<TD style="HEIGHT: 32px" align="center">
							<asp:Button id="btnSubmit" runat="server" Text="Submit" Font-Bold="True" ForeColor="DarkBlue"
								BackColor="#C0C0FF"></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
