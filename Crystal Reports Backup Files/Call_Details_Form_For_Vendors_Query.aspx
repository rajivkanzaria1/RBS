<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Details_Form_For_Vendors_Query.aspx.cs" Inherits="RBS.Call_Details_Form_For_Vendors_Query.Call_Details_Form_For_Vendors_Query" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Inspection_Details_Form_For_Vendors</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		 if(trimAll(document.Form1.lstClientType.value)=="")
		 {
		  alert("Select Client Type to search the Records ");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.lstBPO_Rly.value)=="")
		 {
		  alert("Select Client to search the Records ");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtPONO.value).length < 5)
		{
		 alert("Enter Last 5 Digits of PO No. ");
		 event.returnValue=false;
		 }
	     else if(trimAll(document.Form1.txtPODT.value)=="")
		 {
		  alert("Enter PO DATE to search the Records ");
		 event.returnValue=false;
		 }
		else 
		return;
			
		}
		
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Visible="False" Height="1px" Width="100%">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
					cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 22px" align="center" colSpan="5">
							<P>
								<asp:label id="Label1" runat="server" Width="80%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="10pt"
									Font-Names="Verdana" BackColor="White">CALL DETAILS</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 22px" align="center" colSpan="5"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 50%" align="center">
							<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 100%" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="0" width="340" bgColor="aliceblue" border="1">
								<TR>
									<TD style="WIDTH: 10.18%; HEIGHT: 36px" align="right">
										<asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Client Type</asp:label></TD>
									<TD style="WIDTH: 70%" colSpan="3">
										<asp:dropdownlist id="lstClientType" tabIndex="1" runat="server" Width="20%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 10.18%; HEIGHT: 36px" align="right">
										<asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Select Client</asp:label></TD>
									<TD style="WIDTH: 70%" colSpan="3">
										<asp:dropdownlist id="lstBPO_Rly" tabIndex="2" runat="server" Width="98%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 36px" align="right">
										<asp:label id="Label5" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Last Five Digits Of PO No.</asp:label></TD>
									<TD style="WIDTH: 30%">
										<asp:textbox id="txtPONO" tabIndex="3" runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" MaxLength="45" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 15%">
										<asp:label id="Label7" runat="server" Width="60px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">PO Date</asp:label></TD>
									<TD style="WIDTH: 30%">
										<asp:textbox id="txtPODT" onblur="check_date(txtPODT);" tabIndex="4" runat="server" Width="40%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Height="20px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:button id="Submit" tabIndex="5" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Text="Submit"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel>
		</form>
	</body>
</HTML>
