<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prmOLD_Contract.aspx.cs" Inherits="RBS.prmOLD_Contract.prmOLD_Contract" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>prmOLD_Contract</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="../date.js"></script>
		<script language="javascript">
		function txtCopy()
		{
			
			if(check_date(document.Form1.txtFdate)==true && trimAll(document.Form1.txtTdate.value)=="")
			{
				document.Form1.txtTdate.value=document.Form1.txtFdate.value;
			}
			
		}
		
		function validate()
		{
			if(document.Form1.txtFdate=="[object]" && trimAll(document.Form1.txtFdate.value)=="")
			{
				alert("You Cannot Leave From Date Blank!!!");
				event.returnValue=false;
			}
		}
		function validate1()
		{
		if(trimAll(document.Form1.txtFdate.value)=="" && trimAll(document.Form1.txtTdate.value)=="" && trimAll(document.Form1.txtClient.value)=="" && trimAll(document.Form1.lstBPORegion.value)=="")
		{
		 alert("Kindly select atleast one Period, Region and Client");
		 event.returnValue=false;
		}
		return;
		}
		
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="False">
				<asp:Button id="btnBack" runat="server" Text="Go Back" onclick="btnBack_Click"></asp:Button>
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px">
				<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 152px"
					cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD align="center" colSpan="5">
							<uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 45px" align="center" colSpan="5">
							<asp:label id="Label1" runat="server" Width="100%" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="10pt" Font-Bold="True">CONTRACTS</asp:label></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">For 
									The Period --&gt;</FONT></B></TD>
						<TD style="WIDTH: 10%; HEIGHT: 61px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">From 
									date</FONT></B></TD>
						<TD style="WIDTH: 10%; HEIGHT: 61px">
							<asp:textbox id="txtFdate" onblur="txtCopy();" style="TEXT-ALIGN: center"
								tabIndex="1" runat="server" Height="20px" Width="103px" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" MaxLength="10"></asp:textbox></TD>
						<TD style="WIDTH: 10%; HEIGHT: 61px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">To 
									date</FONT></B></TD>
						<TD style="WIDTH: 30%; HEIGHT: 61px">
							<asp:textbox id="txtTdate" style="TEXT-ALIGN: center" onblur="check_date(txtTdate);compareDates(txtFdate,txtTdate,'From Date Cannot Be Greater Then To Date');txtCopy();"
								tabIndex="1" runat="server" Height="20px" Width="103px" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" MaxLength="10"></asp:textbox></TD>
						</TD></TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right">
							<asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="10pt" Font-Bold="True">Region</asp:label></TD>
						<TD style="WIDTH: 10%; HEIGHT: 61px" align="left" colSpan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:dropdownlist id="lstBPORegion" tabIndex="3" runat="server" Height="25px" Width="60%" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt"></asp:dropdownlist></TD>
						</TD></TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 40.14%; HEIGHT: 61px" align="right">
							<asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="10pt" Font-Bold="True">Client Wise</asp:label></TD>
						<TD style="WIDTH: 10%; HEIGHT: 61px" align="left" colSpan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:textbox id="txtClient" tabIndex="4" runat="server" Height="20px" Width="300px" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt" MaxLength="20"></asp:textbox></TD>
						</TD></TR>
					<TR bgColor="#f0f8ff">
						<TD align="center" colSpan="5">
							<asp:button id="btnSubmit" runat="server" Text="Search" ForeColor="DarkBlue" Font-Bold="True"
								BackColor="#C0C0FF" onclick="btnSubmit_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel>
		</form>
	</body>
</HTML>
