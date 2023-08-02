<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Complaint_Entry.aspx.cs" Inherits="RBS.Complaint_Entry.Complaint_Entry" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>complaint_Entry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">	
		function confirmAction()
		{
			var ans=confirm("Do You Really Want To Cancel Joint Inspection ?");
			if(ans==true)
				event.returnValue=true;
			else
				event.returnValue=false;
		}
				
		function validate()
		{
			if(trimAll(document.Form1.txtComplaintDt.value)=="")
				{
					alert("Complaint Date Not Entered!!!");
					event.returnValue=false;
					document.Form1.txtComplaintDt.focus();
				}
			else if(trimAll(document.Form1.lstPoItems.value)=="")
				{
					alert("Item Description Missing!!!");
					event.returnValue=false;
					document.Form1.lstPoItems.focus();
				}
			else if(trimAll(document.Form1.txtQtyOffered.value)=="")
				{
					alert("Offered Quantity Not Entered!!!");
					event.returnValue=false;
					document.Form1.txtQtyOffered.focus();
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
			else if(document.Form1.txtRejReason.value.length > 250)
				{
					 alert("PLZ ENTER REASON FOR REJECTION WITHIN 250 CHARACTERS ONLY!!!");
					 event.returnValue=false;
				}
			else 
			return;
		}
		function validate2()
		{
			if(trimAll(document.Form1.lstClassification.value)=="")
				{
					alert("Classification Cannot be Left Blank!!!");
					event.returnValue=false;
					document.Form1.txtComplaintDt.focus();
				}
			else 
			return;
		}
		function CheckJiRegion()
		{
			if(trimAll(document.Form1.lstJIRequired.value)=="Y" & trimAll(document.Form1.lstJiRegion.value)=="")
				{
					alert("Region Doing The Joint Inspection Is Missing!!!");
					event.returnValue=false;
					document.Form1.lstJiRegion.focus();
				}
		}
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="1">
				<TR>
					<TD align="center" colSpan="6"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><FONT face="Verdana" color="darkblue" size="2"><STRONG>CONSIGNEE 
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
					<TD style="WIDTH: 11.28%"><asp:label id="Label22" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Date of First reference/ Complaint Date</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="3"><asp:textbox id="txtComplaintDt" onblur="check_date(txtComplaintDt)" runat="server" Font-Size="8pt"
							Font-Names="Verdana" Font-Bold="True" ForeColor="Blue"></asp:textbox>&nbsp;<FONT face="Verdana" size="2">
							<FONT color="#ff0000">(enter date in [dd/mm/yyyy] format)</FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label4" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Case No.</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="lblCaseNo" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue">-x-</asp:label></TD>
					<TD style="WIDTH: 11.28%; HEIGHT: 22px"><asp:label id="Label5" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Book No.</asp:label></TD>
					<TD style="WIDTH: 16%; HEIGHT: 22px"><asp:label id="lblBkNo" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue">-x-</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label6" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Set No.</asp:label></TD>
					<TD style="WIDTH: 16%; HEIGHT: 22px"><asp:label id="lblSetNo" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue">-x-</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label7" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Inspection By</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="lblIE" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue">-x-</asp:label><asp:label id="lblIECd" runat="server" Visible="False"></asp:label></TD>
					<TD style="WIDTH: 11.28%; HEIGHT: 22px"><asp:label id="Label8" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">PO No. & PO Date</asp:label></TD>
					<TD style="WIDTH: 16%; HEIGHT: 22px"><asp:label id="lblPoNo" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue">-x-</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label9" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Railway</asp:label></TD>
					<TD style="WIDTH: 16%; HEIGHT: 22px"><asp:label id="lblRly" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue">-x-</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 28px"><asp:label id="Label10" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Consignee</asp:label></TD>
					<TD style="WIDTH: 83%" colSpan="5"><asp:label id="lblConsignee" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="100%">-x-</asp:label><asp:label id="lblConsigneeCd" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 28px"><asp:label id="Label20" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Vendor</asp:label></TD>
					<TD style="WIDTH: 83%" colSpan="5"><asp:label id="lblVendor" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="100%">-x-</asp:label><asp:label id="lblVendorCd" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%"><asp:label id="Label19" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">IC Date</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="lblIcDate" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue">-x-</asp:label></TD>
					<TD style="WIDTH: 11.28%; HEIGHT: 22px"><asp:label id="Label23" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue"> Controlling Manager</asp:label></TD>
					<TD style="WIDTH: 17%" colSpan="3"><asp:dropdownlist id="lstCO" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="200px"></asp:dropdownlist><asp:label id="lblCO" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%"><asp:label id="Label11" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Rejection Memo No.</asp:label><asp:label id="Label36" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Red">(25 Chars Maxm)</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:textbox id="txtMemoNo" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="90%" MaxLength="25"></asp:textbox></TD>
					<TD style="WIDTH: 11.28%; HEIGHT: 22px"><asp:label id="Label12" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Rejection Memo Date</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="3"><asp:textbox id="txtMemoDt" onblur="check_date(txtMemoDt)" runat="server" Font-Size="8pt" Font-Names="Verdana"
							Font-Bold="True" ForeColor="Blue"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 54px"><asp:label id="Label13" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Item Description</asp:label></TD>
					<TD style="HEIGHT: 54px" colSpan="5"><asp:label id="lblItemDesc" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="100%"><----- Select Item Description From The List Below-----></asp:label><asp:dropdownlist id="lstPoItems" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Crimson"
							Width="100%" AutoPostBack="True" onselectedindexchanged="lstPoItems_SelectedIndexChanged"></asp:dropdownlist><asp:label id="lblItemSrnoPo" runat="server" Visible="False" Width="40px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 16%; HEIGHT: 22px"><asp:label id="Label14" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Qty. Offered</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:textbox id="txtQtyOffered" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue"></asp:textbox></TD>
					<TD style="WIDTH: 10.61%; HEIGHT: 22px"><asp:label id="Label26" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Qty. Rejected</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:textbox id="txtQtyRej" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" AutoPostBack="True" ontextchanged="txtQtyRej_TextChanged"></asp:textbox></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label15" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Unit of Measurement</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="lblUOMDesc" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue"></asp:label><asp:label id="lblUOM" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 22px"><asp:label id="Label27" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Rate</asp:label></TD>
					<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="3"><asp:label id="lblRate" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue"></asp:label><asp:label id="lblUomRate" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue"></asp:label>&nbsp;</TD>
					<TD style="WIDTH: 13.06%; HEIGHT: 22px"><asp:label id="Label16" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Value of Qty. Rejected</asp:label></TD>
					<TD style="HEIGHT: 22px"><asp:textbox id="txtValueRej" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%"><asp:label id="Label17" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Reasons of Rejection</asp:label>&nbsp;
						<asp:label id="Label34" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Red">(250 Chars Maxm)</asp:label></TD>
					<TD colSpan="5"><asp:textbox id="txtRejReason" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><asp:button id="btnSave" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Width="67px" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Width="67px" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<%if(lblComplaintId.Text!=" -x-"){%>
				<TR>
					<TD style="HEIGHT: 26px" align="center" colSpan="6">&nbsp;
						<asp:label id="Label37" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Upload JI Case <Font color="red">(TIF or PDF Format Only)</Font></asp:label><INPUT id="File1" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 100%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
							tabIndex="0" type="file" size="51" name="File1" runat="server">
						<asp:hyperlink id="HypCase" runat="server" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True">View Case</asp:hyperlink><asp:button id="btnUploadCase" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Width="67px" Text="Upload" onclick="btnUploadCase_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center" colSpan="6"><asp:label id="Label40" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Upload REJECTION MEMO<Font color="red">(TIF or PDF Format 
								Only)</Font></asp:label><INPUT id="File3" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 100%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
							tabIndex="0" type="file" size="51" name="File1" runat="server">
						<asp:hyperlink id="HypRejMemo" runat="server" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True">View Rejection Memo</asp:hyperlink><asp:button id="btnRejMemo" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Width="67px" Text="Upload" onclick="btnRejMemo_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" colSpan="6"></TD>
				</TR>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 17%; HEIGHT: 42px" align="left"><asp:label id="Label21" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Joint Inspection Required</asp:label></TD>
					<TD><asp:dropdownlist id="lstJIRequired" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" AutoPostBack="True" onselectedindexchanged="lstJIRequired_SelectedIndexChanged">
							<asp:ListItem Selected="True"></asp:ListItem>
							<asp:ListItem Value="Y">Yes</asp:ListItem>
							<asp:ListItem Value="N">No</asp:ListItem>
							<asp:ListItem Value="C">Cancelled</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 11.28%; HEIGHT: 42px" align="left"><asp:label id="Label3" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Region Doing Joint Inspection</asp:label></TD>
					<TD><asp:dropdownlist id="lstJiRegion" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" AutoPostBack="True" onselectedindexchanged="lstJiRegion_SelectedIndexChanged">
							<asp:ListItem Selected="True"></asp:ListItem>
							<asp:ListItem Value="N">Northern Region</asp:ListItem>
							<asp:ListItem Value="E">Eastern Region</asp:ListItem>
							<asp:ListItem Value="W">Western Region</asp:ListItem>
							<asp:ListItem Value="S">Southern Region</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center" colSpan="2">&nbsp;<asp:label id="lblJiSrNo" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Visible="False">Joint Inspection Serial No. ->&nbsp</asp:label><asp:label id="lblJiSno" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Red"></asp:label></TD>
				</TR>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 17%; HEIGHT: 42px" align="left">
						<asp:label id="Label39" runat="server" ForeColor="#FF0066" Font-Bold="True" Font-Names="Verdana"
							Font-Size="10pt" Visible="False" Width="120px" Font-Underline="True">Reason for NO JI </asp:label></TD>
					<TD colSpan="2">
						<asp:dropdownlist id="lslNOJIReasons" tabIndex="6" runat="server" ForeColor="DarkBlue" Font-Names="Verdana"
							Font-Size="8pt" Visible="False" Width="100%" AutoPostBack="True" Height="25px" onselectedindexchanged="lslNOJIReasons_SelectedIndexChanged">
							<asp:ListItem Value="A">DP Expired</asp:ListItem>
							<asp:ListItem Value="B">Validity of IC Expired</asp:ListItem>
							<asp:ListItem Value="C">Recieved in Damaged/Broken Condition</asp:ListItem>
							<asp:ListItem Value="D">Rejection &lt;5%</asp:ListItem>
							<asp:ListItem Value="E">Rejection issued after 90 Days of reciept of material</asp:ListItem>
							<asp:ListItem Value="F">Guarantee Claim</asp:ListItem>
							<asp:ListItem Value="G">Wrong Dispatch</asp:ListItem>
							<asp:ListItem Value="H">Material not stamped (partial/full)</asp:ListItem>
							<asp:ListItem Value="I">Material received in excess of ordered quantity</asp:ListItem>
							<asp:ListItem Value="J">Material lifted/rectified/replaced (Partially/Fully) before issue of Rejection Advice</asp:ListItem>
							<asp:ListItem Value="K">Reason(s) of rejection, beyond scope of inspection</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD>
						<asp:label id="Label53" runat="server" ForeColor="#FF0066" Font-Bold="True" Font-Names="Verdana"
							Font-Size="10pt" Visible="False" Width="176px" Font-Underline="True">Reason for NO JI Others </asp:label></TD>
					<TD align="center" colSpan="2">
						<asp:textbox id="txtNoJIOthers" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" Visible="False" Width="100%" TextMode="MultiLine" Height="20px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 21px" align="left" bgColor="#ccccff"><asp:label id="Label32" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Joint Inspection Engineer</asp:label></TD>
					<TD style="HEIGHT: 21px" bgColor="#ccccff" colSpan="3"><asp:dropdownlist id="lstJIIE" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="60%"></asp:dropdownlist></TD>
					<td bgColor="#ccccff"><asp:label id="Label29" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">JI Date (Date on Which IE Will Attend JI)</asp:label></td>
					<td bgColor="#ccccff"><asp:textbox id="txtJIFixDT" onblur="check_date(txtJIFixDT)" runat="server" Font-Size="8pt" Font-Names="Verdana"
							Font-Bold="True" ForeColor="Blue"></asp:textbox></td>
				</TR>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 17%"><asp:label id="Label24" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Remarks</asp:label><asp:label id="Label33" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Red">(250 Chars Maxm)</asp:label></TD>
					<TD colSpan="5"><asp:textbox id="txtRemarks" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%"></TD>
					<TD colSpan="5"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><asp:button id="btnJIChoice" tabIndex="0" runat="server" Font-Size="8pt" Font-Names="Verdana"
							Font-Bold="True" ForeColor="DarkBlue" Text="Save Your Choice" onclick="btnJIChoice_Click"></asp:button><asp:button id="btnCancelJI" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Visible="False" Text="Cancel Joint Inspection" onclick="btnCancelJI_Click"></asp:button></TD>
				</TR>
				<%}%>
				<%if(lstJIRequired.SelectedValue=="Y"){%>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 29px" align="center" bgColor="#ffcccc" colSpan="6"><FONT face="Verdana" color="darkblue" size="2"><STRONG>OUTCOME 
								OF JI</STRONG></FONT></TD>
				</TR>
				<TR bgColor="#ffcccc">
					<TD align="center"><FONT face="Verdana" color="darkblue" size="2"><STRONG>JI Decided on</STRONG></FONT></TD>
					<TD vAlign="middle" align="center" colSpan="5"><asp:label id="Label18" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Width="279px">Status (Decision Taken by JI Committe)</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:textbox id="txtDtJi" onblur="check_date(txtDtJi)" runat="server" Font-Size="8pt" Font-Names="Verdana"
							Font-Bold="True" ForeColor="Blue"></asp:textbox></TD>
					<TD align="center" colSpan="5"><asp:textbox id="txtStatus" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#ffcccc" colSpan="3"><FONT face="Verdana" color="darkblue" size="2"><STRONG>Defect 
								Code</STRONG></FONT></TD>
					<TD align="center" bgColor="#ffcccc" colSpan="2"><FONT face="Verdana" color="darkblue" size="2"><STRONG>Classification</STRONG></FONT></TD>
					<TD align="center" bgColor="#ffcccc"><FONT face="Verdana" color="darkblue" size="2"><STRONG>Date 
								of JI Conclusion</STRONG></FONT></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"><asp:dropdownlist id="lstDefectCd" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue"></asp:dropdownlist><asp:label id="lblDefectCD" runat="server" Visible="False"></asp:label></TD>
					<TD align="center" colSpan="2"><asp:dropdownlist id="lstClassification" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue"></asp:dropdownlist><asp:label id="lblClassification" runat="server" Visible="False"></asp:label></TD>
					<TD align="center"><asp:textbox id="txtConclusionDt" onblur="check_date(txtConclusionDt)" runat="server" Font-Size="8pt"
							Font-Names="Verdana" Font-Bold="True" ForeColor="Blue"></asp:textbox></TD>
				</TR>
				<TR bgColor="#ffcccc">
					<TD style="WIDTH: 17%"><asp:label id="Label38" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Upload JI Report <Font color="red">(TIF or PDF Format Only)</Font></asp:label></TD>
					<TD align="center" colSpan="5"><INPUT id="File2" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 100%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
							tabIndex="0" type="file" size="51" name="File1" runat="server">
						<asp:hyperlink id="HypReport" runat="server" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True">View Report</asp:hyperlink><asp:label id="lblJi_Rep_Path" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><asp:button id="btnJIOutcome" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Text="Save Outcome of JI" BorderStyle="None" onclick="btnJIOutcome_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 29px" align="center" bgColor="#009966" colSpan="6"><FONT face="Verdana" color="white" size="2"><STRONG>FINAL 
								DISPOSAL</STRONG></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 16px">
						<asp:label id="Label41" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Root Cause Analysis</asp:label>
						<asp:label id="Label43" runat="server" ForeColor="Red" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">(500 Chars Maxm)</asp:label></TD>
					<TD style="HEIGHT: 16px" colSpan="5">
						<asp:textbox id="txtRootCAnalysis" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 24px">
						<asp:label id="Label44" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Technical Reference</asp:label>
						<asp:label id="Label45" runat="server" ForeColor="Red" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">(250 Chars Maxm)</asp:label></TD>
					<TD style="HEIGHT: 24px" colSpan="3">
						<asp:textbox id="txtTech_Ref" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
					<TD style="HEIGHT: 24px" colSpan="2">
						<asp:label id="Label42" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Checksheet (Approved/Revision/Prepration)</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:dropdownlist id="ddlChksheet" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
							Width="150px" Height="25px">
							<asp:ListItem></asp:ListItem>
							<asp:ListItem Value="A">Approved</asp:ListItem>
							<asp:ListItem Value="R">Revision</asp:ListItem>
							<asp:ListItem Value="P">Prepration</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 24px">
						<asp:label id="Label46" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Upload Tech Ref <Font color="red">(PDF Format Only)</Font></asp:label></TD>
					<TD style="HEIGHT: 24px" colSpan="5"><INPUT id="File4" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 100%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
							tabIndex="0" type="file" size="51" name="File1" runat="server"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 24px">
						<asp:label id="Label48" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Any Other</asp:label>
						<asp:label id="Label47" runat="server" ForeColor="Red" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">(250 Chars Maxm)</asp:label></TD>
					<TD style="HEIGHT: 24px" colSpan="5">
						<asp:textbox id="txtAnyOther" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 24px">
						<asp:label id="Label50" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">Status of CAPA</asp:label>
						<asp:label id="Label49" runat="server" ForeColor="Red" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">(250 Chars Maxm)</asp:label></TD>
					<TD style="HEIGHT: 24px" colSpan="3">
						<asp:textbox id="txtCAPA" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
					<TD style="HEIGHT: 24px" colSpan="2">
						<asp:label id="Label52" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">D&AR Status (If Any)</asp:label>
						<asp:label id="Label51" runat="server" ForeColor="Red" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt">(250 Chars Maxm)</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtDARStatus" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" Width="250px" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 21px"><asp:label id="Label28" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">D&AR Proposed</asp:label></TD>
					<TD style="HEIGHT: 21px" colSpan="3"><asp:dropdownlist id="lstAction" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="80%" AutoPostBack="True" onselectedindexchanged="lstAction_SelectedIndexChanged">
							<asp:ListItem Selected="True"></asp:ListItem>
							<asp:ListItem Value="N">No Action Required</asp:ListItem>
							<asp:ListItem Value="W">Warning Letter</asp:ListItem>
							<asp:ListItem Value="I">Minor Penalty</asp:ListItem>
							<asp:ListItem Value="J">Major Penalty</asp:ListItem>
							<asp:ListItem Value="C">Counselling</asp:ListItem>
							<asp:ListItem Value="O">Others</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD colSpan="2" style="HEIGHT: 21px"><asp:label id="lblActionDt" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Width="50%">Date of D&AR Issue</asp:label>&nbsp;&nbsp;&nbsp;<asp:textbox id="txtDtIssue" onblur="check_date(txtDtIssue)" runat="server" Font-Size="8pt" Font-Names="Verdana"
							Font-Bold="True" ForeColor="Blue" Width="40%"></asp:textbox>&nbsp;</TD>
				</TR>
				<%if((lstAction.SelectedValue=="I") || (lstAction.SelectedValue=="J")){%>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 16px"><asp:label id="Label31" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Type of Penalty</asp:label></TD>
					<TD colSpan="3"><asp:dropdownlist id="lstPenaltyType" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="100%"></asp:dropdownlist></TD>
					<TD style="HEIGHT: 16px" colSpan="2"><asp:label id="Label30" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Width="50%">Date of Imposing Penalty</asp:label>&nbsp;&nbsp;
						<asp:textbox id="txtPenaltyDt" onblur="check_date(txtPenaltyDt)" runat="server" Font-Size="8pt"
							Font-Names="Verdana" Font-Bold="True" ForeColor="Blue" Width="40%"></asp:textbox></TD>
				</TR>
				<%}%>
				<TR>
					<TD style="WIDTH: 17%; HEIGHT: 51px"><asp:label id="Label25" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue">Final Remarks/Action</asp:label><asp:label id="Label35" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Red">(250 Chars Maxm)</asp:label></TD>
					<TD style="HEIGHT: 51px" colSpan="5"><asp:textbox id="txtAction" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="Blue" Width="100%" TextMode="MultiLine"></asp:textbox>&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6">
						<asp:hyperlink id="HypTech_Ref" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt">View Technical Reference</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><asp:button id="btnFinalDisposal" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
							ForeColor="DarkBlue" Text="Save Final Disposal" BorderStyle="None" onclick="btnFinalDisposal_Click"></asp:button></TD>
				</TR>
				<%}%>
			</TABLE>
		</form>
	</body>
</HTML>

