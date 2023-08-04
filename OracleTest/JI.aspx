<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JI.aspx.cs" Inherits="RBS.JI.JI" %>


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
			if(trimAll(document.Form1.txtComplaintDt.value)=="")
				{
					alert("Complaint Date Not Entered!!!");
					event.returnValue=false;
					document.Form1.txtComplaintDt.focus();
				}
			else if(trimAll(document.Form1.txtItemDesc.value)=="")
				{
					alert("Item Description Missing!!!");
					event.returnValue=false;
					document.Form1.txtItemDesc.focus();
				}
			else if(trimAll(document.Form1.txtQtyOffer.value)=="")
				{
					alert("Quantity Offered Not Entered!!!");
					event.returnValue=false;
					document.Form1.txtQtyOffer.focus();
				}
			else if(trimAll(document.Form1.txtQtyRej.value)=="")
				{
					alert("Quantity Rejected Not Entered!!!");
					event.returnValue=false;
					document.Form1.txtQtyRej.focus();
				}
			else if(trimAll(document.Form1.txtValueRej.value)=="")
				{
					alert("Value of Rejected Quantity Is Missing!!!");
					event.returnValue=false;
					document.Form1.txtValueRej.focus();
				}
			else if(trimAll(document.Form1.txtRejReason.value)=="")
				{
					alert("Reasons For Rejection Is Missing!!!");
					event.returnValue=false;
					document.Form1.txtRejReason.focus();
				}
			else if(trimAll(document.Form1.txtDt1stRef.value)=="")
				{
					alert("Date of First Reference Is Missing!!!");
					event.returnValue=false;
					document.Form1.txtDt1stRef.focus();
				}
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
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label1" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Complaint Id</asp:label></TD>
					<TD style="WIDTH: 83%; HEIGHT: 22px" colSpan="5"><asp:label id="lblComplaintId" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt"> -x-</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Region Where Complaint is Received</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="lblRegion" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">-x-</asp:label></TD>
					<TD style="WIDTH: 17%"><asp:label id="Label22" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Date of First reference</asp:label></TD>
					<TD style="WIDTH: 177px"><asp:textbox id="txtDt1stRef" onblur="check_date(txtDt1stRef)" runat="server" ForeColor="Blue"
							Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"></asp:textbox></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Date of receipt of Complaint</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="3"><asp:textbox onblur="check_date(txtComplaintDt)" id="txtComplaintDt" runat="server" ForeColor="Blue"
							Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label4" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Case No.</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="lblCaseNo" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">-x-</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Book No.</asp:label></TD>
					<TD style="WIDTH: 16%; HEIGHT: 22px"><asp:label id="lblBkNo" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">-x-</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Set No.</asp:label></TD>
					<TD style="WIDTH: 16%; HEIGHT: 22px"><asp:label id="lblSetNo" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">-x-</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Inspection By</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="lblIE" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">-x-</asp:label><asp:label id="lblIECd" runat="server" Visible="False"></asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">PO No. & PO Date</asp:label></TD>
					<TD style="WIDTH: 16%; HEIGHT: 22px"><asp:label id="lblPoNo" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">-x-</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Railway</asp:label></TD>
					<TD style="WIDTH: 16%; HEIGHT: 22px"><asp:label id="lblRly" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">-x-</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 28px"><asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Consignee</asp:label></TD>
					<TD style="WIDTH: 83%" colSpan="5"><asp:label id="lblConsignee" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" Width="100%">-x-</asp:label><asp:label id="lblConsigneeCd" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 28px"><asp:label id="Label20" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Vendor</asp:label></TD>
					<TD style="WIDTH: 83%" colSpan="5"><asp:label id="lblVendor" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" Width="100%">-x-</asp:label><asp:label id="lblVendorCd" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%"><asp:label id="Label11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Rejection Memo No.</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px">
						<asp:label id="txtMemoNo" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="90%">-x-</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label12" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Rejection Memo Date</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="3">
						<asp:label id="txtMemoDt" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="88px">-x-</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%"><asp:label id="Label13" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Item Description</asp:label></TD>
					<TD colSpan="5">
						<asp:label id="txtItemDesc" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="90%">-x-</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label14" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Qty. Passed</asp:label></TD>
					<TD style="WIDTH: 177px; HEIGHT: 22px">
						<asp:label id="txtQtyPassed" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="90%">-x-</asp:label></TD>
					<TD style="WIDTH: 145px; HEIGHT: 22px"><asp:label id="Label15" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Qty. Rejected</asp:label></TD>
					<TD style="WIDTH: 319px; HEIGHT: 22px">
						<asp:label id="txtQtyRej" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="88px">-x-</asp:label></TD>
					<TD style="WIDTH: 13.06%; HEIGHT: 22px"><asp:label id="Label16" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Value of Qty. Rejected</asp:label></TD>
					<TD style="HEIGHT: 22px">
						<asp:label id="txtValueRej" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="96px">-x-</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%"><asp:label id="Label17" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Reasons of Rejection</asp:label></TD>
					<TD colSpan="5">
						<asp:label id="txtRejReason" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="90%">-x-</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 16px"><asp:label id="Label18" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Status</asp:label></TD>
					<TD style="HEIGHT: 16px" colSpan="5">
						<asp:label id="txtStatus" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="90%">-x-</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6">
						<asp:button id="btnCancel" tabIndex="21" runat="server" ForeColor="DarkBlue" Font-Bold="True"
							Font-Names="Verdana" Font-Size="8pt" Width="67px" Text="Cancel"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="6" style="HEIGHT: 42px">
						<TABLE id="Table2" border="1" cellSpacing="1" cellPadding="1" width="100%">
							<tr>
								<td style="WIDTH: 15%">
									<asp:label id="Label19" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
										ForeColor="DarkBlue">JI No.</asp:label>
								</td>
								<td style="WIDTH: 35%">
									<asp:textbox id="txtJINO" onblur="check_date(txtMemoDt)" runat="server" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True" ForeColor="Blue"></asp:textbox>
								</td>
								<td style="WIDTH: 15%">
									<asp:label id="Label21" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
										ForeColor="DarkBlue">JI Date</asp:label>
								</td>
								<td style="WIDTH: 35%">
									<asp:textbox id="txtJIDT" onblur="check_date(txtMemoDt)" runat="server" Font-Size="8pt" Font-Names="Verdana"
										Font-Bold="True" ForeColor="Blue"></asp:textbox>
								</td>
							</tr>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>