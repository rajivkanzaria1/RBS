<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="complaint_Entry1.aspx.cs" Inherits="RBS.complaint_Entry1.complaint_Entry1" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>complaint_Entry</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		
		}
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" id="Table1" border="1"
				cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD colSpan="6" align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD colSpan="6" align="center"><FONT color="darkblue" size="2" face="Verdana"><STRONG>COMPLAINTS 
								REGISTER</STRONG></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 178px; HEIGHT: 19px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Complaint 
								Id</STRONG></FONT></TD>
					<TD style="WIDTH: 320px; HEIGHT: 19px" colSpan="5"><asp:label id="lblComplaintId" runat="server" ForeColor="#C00000" Font-Bold="True">Complaint Id</asp:label><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px" colSpan="2"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Region 
								Where Complaint is Received</STRONG></FONT></TD>
					<TD style="WIDTH: 320px; HEIGHT: 19px"><asp:label id="lblRegion" runat="server" ForeColor="DarkBlue">Label</asp:label><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
					<TD style="WIDTH: 222px; HEIGHT: 19px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Date 
								of Receipt of Complaint</STRONG></FONT></TD>
					<TD style="WIDTH: 273px; HEIGHT: 19px" colSpan="2"><asp:textbox id="txtComplaintDt" onblur="check_date(txtComplaintDt)" runat="server"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 178px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Case No.</STRONG></FONT></TD>
					<TD style="WIDTH: 177px"><asp:textbox id="txtCaseNo" runat="server"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
					<TD style="WIDTH: 142px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Book No.</STRONG></FONT></TD>
					<TD style="WIDTH: 222px"><asp:textbox id="txtBkNo" runat="server"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
					<TD style="WIDTH: 103px; HEIGHT: 19px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Set 
								No.</STRONG></FONT></TD>
					<TD style="HEIGHT: 19px"><asp:textbox id="txtSetNo" runat="server" Width="75px"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 178px; HEIGHT: 10px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Inspection 
								By</STRONG></FONT></TD>
					<TD style="WIDTH: 177px; HEIGHT: 10px"><asp:label id="lblIE" runat="server" ForeColor="DarkBlue">Label</asp:label><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
					<TD style="WIDTH: 142px; HEIGHT: 10px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>PO 
								No. &amp; PO Date</STRONG></FONT></TD>
					<TD style="WIDTH: 222px; HEIGHT: 10px"><asp:label id="lblPoNo" runat="server" ForeColor="DarkBlue">Label</asp:label><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
					<TD style="WIDTH: 103px; HEIGHT: 10px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Railway</STRONG></FONT></TD>
					<TD style="HEIGHT: 10px"><asp:label id="lblRly" runat="server" ForeColor="DarkBlue">Label</asp:label><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 178px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Consignee</STRONG></FONT></TD>
					<TD colSpan="5"><asp:dropdownlist id="lstConsignee" runat="server" Width="736px" ForeColor="DarkBlue"></asp:dropdownlist><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 178px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Item 
								Description</STRONG></FONT></TD>
					<TD colSpan="5"><asp:textbox id="txtItemDesc" runat="server" Width="738px"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 178px; HEIGHT: 28px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Qty 
								Offered</STRONG></FONT></TD>
					<TD style="WIDTH: 177px; HEIGHT: 28px"><asp:textbox id="txtQtyOffer" runat="server"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
					<TD style="WIDTH: 142px; HEIGHT: 28px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Qty 
								Rejected</STRONG></FONT></TD>
					<TD style="WIDTH: 222px; HEIGHT: 28px"><asp:textbox id="txtQtyRej" runat="server"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
					<TD style="WIDTH: 11.41%; HEIGHT: 28px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Value 
								of Qty Rejected</STRONG></FONT></TD>
					<TD style="HEIGHT: 28px"><asp:textbox id="txtValueRej" runat="server"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 178px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Reasons of 
								Rejection</STRONG></FONT></TD>
					<TD colSpan="5"><asp:textbox id="txtRejReason" runat="server" Width="738px"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 178px; HEIGHT: 16px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Status</STRONG></FONT></TD>
					<TD style="HEIGHT: 16px" colSpan="5"><asp:textbox id="txtStatus" runat="server" Width="738px"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 178px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Date 
								of&nbsp; First Reference</STRONG></FONT></TD>
					<TD style="WIDTH: 177px"><asp:textbox id="txtDt1stRef" onblur="check_date(txtDt1stRef)" runat="server"></asp:textbox><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
					<TD style="WIDTH: 142px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Defect Code</STRONG></FONT></TD>
					<TD style="WIDTH: 222px"><asp:dropdownlist id="lstDefectCd" runat="server" ForeColor="DarkBlue"></asp:dropdownlist><FONT color="darkblue" size="2" face="Verdana"></FONT></TD>
					<TD style="WIDTH: 142px"><FONT color="darkblue" size="2" face="Verdana"><STRONG>Classification</STRONG></FONT></TD>
					<TD style="WIDTH: 222px"><asp:dropdownlist id="lstClassification" runat="server" ForeColor="DarkBlue"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colspan="6" align="center">
						<asp:button id="btnSave" tabIndex="19" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Width="67px" Text="Save" Font-Size="8pt" Font-Names="Verdana"></asp:button>
						<asp:button id="btnCancel" tabIndex="21" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Width="67px" Text="Cancel" Font-Size="8pt" Font-Names="Verdana"></asp:button>
						<asp:button id="btnDelete" tabIndex="20" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Width="67px" Text="Delete" Font-Size="8pt" Font-Names="Verdana"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
