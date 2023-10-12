<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pfrmCompliants.aspx.cs" Inherits="RBS.Reports.pfrmCompliants" %>

<%--<%@ Page language="c#" Codebehind="pfrmCompliants.aspx.cs" AutoEventWireup="false" Inherits="RBS.Reports.pfrmCompliants" %>--%>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>pfrmCompliants</title>
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
		
		function validate()
		{
			if(document.Form1.frmDt=="[object]" && trimAll(document.Form1.frmDt.value)=="")
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
				Width="100%" Height="1px" Visible="False">
				<asp:Button id="btnPrint" runat="server" Text="Print"></asp:Button>
				<INPUT id="Button1" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px">
				<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 152px"
					cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 42px" align="center" colSpan="5">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 31px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CONSIGNEE 
									COMPLAINTS</FONT></B></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center">
							<TABLE id="Table2" borderColor="#b0c4de" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f0f8ff"
								border="1">
								<TR>
									<TD width="30%"><B><FONT face="Verdana" color="darkblue" size="2">Complaints Recieved 
												in&nbsp;The Period --&gt;</FONT></B></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">From</FONT></B></TD>
									<TD style="WIDTH: 13.97%; HEIGHT: 52px">
										<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
											style="TEXT-ALIGN: center" tabIndex="3" runat="server" Height="20px" Width="100px" MaxLength="10"
											Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"></asp:textbox></TD>
									<TD style="WIDTH: 6.76%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">To</FONT></B></TD>
									<TD style="WIDTH: 30%; HEIGHT: 52px">
										<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
											style="TEXT-ALIGN: center" tabIndex="4" runat="server" Height="20px" Width="100px" MaxLength="10"
											Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="5">
										<asp:label id="Label5" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkMagenta"
											Font-Bold="True">* Enter Date in DD/MM/YYYY Format.</asp:label></TD>
								</TR>
								<% if (Request.Params ["ACTION"]=="U" || Request.Params ["ACTION"]=="CORP") {%>
								<TR>
									<TD style="WIDTH: 287px; HEIGHT: 29px" align="left"><B><FONT face="Verdana" color="darkblue" size="2">Inspection 
												Region&nbsp;--&gt;</FONT></B></TD>
									<TD style="HEIGHT: 29px" align="left" colSpan="5">
										<asp:RadioButton id="rdbAll" runat="server" Text="All Regions" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Font-Bold="True" Checked="True" GroupName="g1"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:RadioButton id="rdbNR" runat="server" Text="Northern" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" GroupName="g1"></asp:RadioButton>
										<asp:RadioButton id="rdbSR" runat="server" Text="Southern" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" GroupName="g1"></asp:RadioButton>
										<asp:RadioButton id="rdbER" runat="server" Text="Eastern" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" GroupName="g1"></asp:RadioButton>
										<asp:RadioButton id="rdbWR" runat="server" Text="Western" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" GroupName="g1"></asp:RadioButton></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 287px; HEIGHT: 29px" align="left"><B><FONT face="Verdana" color="darkblue" size="2">Joint 
												Inspection&nbsp;Region&nbsp;--&gt;</FONT></B></TD>
									<TD style="HEIGHT: 29px" align="left" colSpan="5">
										<asp:RadioButton id="rdbAll1" runat="server" Text="All Regions" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Font-Bold="True" Checked="True" GroupName="g2"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:RadioButton id="rdbNR1" runat="server" Text="Northern" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Font-Bold="True" GroupName="g2"></asp:RadioButton>
										<asp:RadioButton id="rdbSR1" runat="server" Text="Southern" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Font-Bold="True" GroupName="g2"></asp:RadioButton>
										<asp:RadioButton id="rdbER1" runat="server" Text="Eastern" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" GroupName="g2"></asp:RadioButton>
										<asp:RadioButton id="rdbWR1" runat="server" Text="Western" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" GroupName="g2"></asp:RadioButton></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 287px; HEIGHT: 29px" align="left"><B><FONT face="Verdana" color="darkblue" size="2">Include 
												Complaints&nbsp;Where JI Required&nbsp;?--&gt;</FONT></B></TD>
									<TD style="HEIGHT: 29px" align="left" colSpan="5">
										<asp:RadioButton id="rdbAll3" runat="server" Width="40px" Text="All" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Font-Bold="True" Checked="True" GroupName="g3"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
										<asp:RadioButton id="rdbYes" runat="server" Text="Yes" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" GroupName="g3"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:RadioButton id="rdbNo" runat="server" Text="No" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" GroupName="g3"></asp:RadioButton>&nbsp;&nbsp; 
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
										<asp:RadioButton id="rdbCancelled" runat="server" Text="Cancelled" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Font-Bold="True" GroupName="g3"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										&nbsp;
										<asp:RadioButton id="rdbUndConsideration" runat="server" Text="Under Consideration" Font-Size="8pt"
											Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" GroupName="g3"></asp:RadioButton></TD>
								</TR>
								<%}%>
								<% if (Request.Params ["ACTION"]=="CORP") {%>
								<TR>
									<TD style="WIDTH: 287px; HEIGHT: 29px" align="left"><B><FONT face="Verdana" color="darkblue" size="2">Defect 
												Code&nbsp;--&gt;</FONT></B></TD>
									<TD style="HEIGHT: 29px" align="left" colSpan="5">
										<asp:RadioButton id="rdbAllDefectCD" runat="server" Width="40px" Text="All" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Font-Bold="True" Checked="True" GroupName="g4" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:RadioButton id="rdbPDefectCD" runat="server" Width="176px" Text="Particular Defect Code" Font-Size="8pt"
											Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" GroupName="g4" AutoPostBack="True"></asp:RadioButton>
										<asp:dropdownlist id="lstDefectCd" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 287px; HEIGHT: 29px" align="left"><B><FONT face="Verdana" color="darkblue" size="2">JI 
												Status Code/Classification&nbsp;--&gt;</FONT></B></TD>
									<TD style="HEIGHT: 29px" align="left" colSpan="5">
										<asp:RadioButton id="rdbAllJIStatus" runat="server" Width="40px" Text="All" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Font-Bold="True" Checked="True" GroupName="g5" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										&nbsp;
										<asp:RadioButton id="rdbPJIStatus" runat="server" Width="192px" Text="Particular JI Status Code"
											Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" GroupName="g5" AutoPostBack="True"></asp:RadioButton>
										<asp:dropdownlist id="lstClassification" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True"></asp:dropdownlist></TD>
								</TR>
								<%}%>
								<% if (Request.Params ["ACTION"]=="U" || Request.Params ["ACTION"]=="CORP") {%>
								<TR>
									<TD style="WIDTH: 287px; HEIGHT: 29px" align="left"><B><FONT face="Verdana" color="darkblue" size="2">Action 
												Proposed--&gt;</FONT></B></TD>
									<TD style="HEIGHT: 29px" align="left" colSpan="5">
										<asp:RadioButton id="rdbAllAction" runat="server" Width="40px" Text="All" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Font-Bold="True" Checked="True" GroupName="g6" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:RadioButton id="rdbPAction" runat="server" Width="192px" Text="Particular Action" Font-Size="8pt"
											Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" GroupName="g6" AutoPostBack="True"></asp:RadioButton>&nbsp;
										<asp:dropdownlist id="lstAction" runat="server" Width="262px" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="Blue" Font-Bold="True" AutoPostBack="True">
											<asp:ListItem Selected="True"></asp:ListItem>
											<asp:ListItem Value="N">No Action Required</asp:ListItem>
											<asp:ListItem Value="W">Warning Letter</asp:ListItem>
											<asp:ListItem Value="I">Minor Penalty</asp:ListItem>
											<asp:ListItem Value="J">Major Penalty</asp:ListItem>
											<asp:ListItem Value="O">Others</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<%}%>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:button id="btnSubmit" runat="server" Text="Submit" ForeColor="DarkBlue" Font-Bold="True"
								BackColor="#C0C0FF"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></FORM></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
