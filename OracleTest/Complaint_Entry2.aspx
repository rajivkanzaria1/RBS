<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Complaint_Entry2.aspx.cs" Inherits="RBS.Complaint_Entry2.Complaint_Entry2" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Complaint_Entry2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" id="Table1" border="1"
				cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD colSpan="6" align="center">
						<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
				</TR>
				<TR>
					<TD colSpan="6" align="center"><FONT color="darkblue" size="2" face="Verdana"><STRONG>CONSIGNEE 
								COMPLAINT</STRONG></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label1" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Complaint Id</asp:label></TD>
					<TD style="WIDTH: 83%; HEIGHT: 22px" colSpan="5"><asp:label id="lblComplaintId" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Red"> -x-</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label2" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Region Where Complaint is Received</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="lblRegion" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue">-x-</asp:label><asp:label id="lblCompRecvRgn" runat="server" Visible="False">lblCompRecvRgn</asp:label></TD>
					<TD style="WIDTH: 17%"><asp:label id="Label22" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Date of First reference/ Complaint Date</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="3"><asp:textbox onblur="check_date(txtComplaintDt)" id="txtComplaintDt" runat="server" Font-Size="8pt"
							Font-Names="Verdana" Font-Bold="True" ForeColor="Blue"></asp:textbox>&nbsp;<FONT size="2" face="Verdana">
							<FONT color="#ff0000">(enter date in [dd/mm/yyyy] format)</FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label7" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Inspection By</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px" colspan=5>
<asp:dropdownlist id=lstIE tabIndex=8 runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt" Width="80%" Height="20px"></asp:dropdownlist><asp:label id="lblIECd" runat="server" Visible="False"></asp:label></TD>
					
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 28px"><asp:label id="Label10" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Consignee</asp:label></TD>
					<TD style="WIDTH: 83%" colSpan="5">
<asp:textbox id=txtSCon tabIndex=15 runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt" MaxLength="50" Width="72px" Height="20px"></asp:textbox>
<asp:button id=btnSCon tabIndex=16 runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" Width="120px" Text="Search Consignee"></asp:button>
<asp:label id=Label19 runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Names="Verdana" Font-Size="7pt" Width="424px">To Search a Consignee-> Enter First Few Charaters of "Firm/Desig/Dept" and Click on Select Consignee</asp:label>
<asp:dropdownlist id=lstConsignee tabIndex=17 runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt" Visible="False" Width="100%" AutoPostBack="True" Height="20px"></asp:dropdownlist><asp:label id="lblConsigneeCd" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 28px"><asp:label id="Label20" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Vendor</asp:label></TD>
					<TD style="WIDTH: 83%" colSpan="5">
<asp:textbox id=txtVend tabIndex=18 runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt" Width="79px" Height="20px"></asp:textbox>
<asp:button id=btnFCList tabIndex=19 runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" Width="99px" Text="Select Vendor" ToolTip="Enter the Vendor Code or 1st few letters of Vendor then click on select Vendor Button"></asp:button>
<asp:label id=Label18 runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Names="Verdana" Font-Size="7pt" Width="460px">To Search a Vendor-> Enter First Few Characters of Vendor Name and Click on Select Vendor</asp:label>
<asp:dropdownlist id=ddlVender tabIndex=20 runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt" Visible="False" Width="100%" AutoPostBack="True" Height="25px"></asp:dropdownlist><asp:label id="lblVendorCd" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%"><asp:label id="Label11" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Rejection Memo No.</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:textbox id="txtMemoNo" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="90%" MaxLength="25"></asp:textbox></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label12" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Rejection Memo Date</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="3"><asp:textbox onblur="check_date(txtMemoDt)" id="txtMemoDt" runat="server" Font-Size="8pt" Font-Names="Verdana"
							Font-Bold="True" ForeColor="Blue"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%"><asp:label id="Label13" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Item Description</asp:label></TD>
					<TD colSpan="5">
						<asp:textbox id="txtIDESC" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" MaxLength="100" Width="90%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%"><asp:label id="Label17" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Reasons of Rejection</asp:label></TD>
					<TD colSpan="5"><asp:textbox id="txtRejReason" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="100%"></asp:textbox></TD>
				</TR>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 17%; HEIGHT: 42px" align="left"><asp:label id="Label21" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Joint Inspection Required</asp:label></TD>
					<TD><asp:dropdownlist id="lstJIRequired" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue">
							<asp:ListItem Selected="True"></asp:ListItem>
							<asp:ListItem Value="Y">Yes</asp:ListItem>
							<asp:ListItem Value="N">No</asp:ListItem>
							<asp:ListItem Value="C">Cancelled</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 17%"><asp:label id="Label24" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Remarks</asp:label></TD>
					<TD colSpan="5"><asp:textbox id="txtRemarks" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="100%"></asp:textbox></TD>
				</TR>
  <TR>
    <TD style="WIDTH: 17%; HEIGHT: 26px" align=center colSpan=8>
<asp:button id=btnSave tabIndex=19 runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" Width="67px" Text="Save"></asp:button>
<asp:button id=btnCancel tabIndex=21 runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" Width="67px" Text="Cancel"></asp:button></TD></TR>
  <TR>
    <TD style="WIDTH: 17%; HEIGHT: 42px" align=left 
colSpan=8></TD></TR>
			</TABLE>
		</form>
	</body>
</HTML>

