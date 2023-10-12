<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_JI_Remarks_Entry_Form.aspx.cs" Inherits="RBS.IE_JI_Remarks_Entry_Form.IE_JI_Remarks_Entry_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Call_Status_Edit_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
			if(trimAll(document.Form1.txtRemarks.value)=="")
			{
				alert("Remarks cannot be left blank!!!");
				event.returnValue=false;
			}
			else if(document.Form1.txtRemarks.value.length > 500)
			{
					alert("PLZ ENTER IE REMARKS WITHIN 500 CHARACTERS ONLY!!!");
					event.returnValue=false;
			}
			return;
		}
		
		
		
        </script>
	</HEAD>
	<body onload="call_cancel_status();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 45px" align="center">
						<P>
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1>
						</P>
					</TD>
				</TR>
				<tr>
					<td align="center"><asp:label id="Label1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt"
							Font-Names="Verdana" BackColor="White" Width="250px">IE JI REMARKS ENTRY FORM</asp:label></td>
				</tr>
				<TR>
					<TD align="center">
						<TABLE id="Table4" borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="97%" bgColor="#f0f8ff"
							border="1">
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Complaint 
									ID</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblComplID" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Width="90%"></asp:label></TD>
							</TR>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Vendor</td>
								<td style="WIDTH: 70%; HEIGHT: 9px"><asp:label id="lblVend" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Width="90%"></asp:label></td>
							</tr>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Item</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblItem" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">
									Consignee</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblConsignee" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">PO 
									No. &amp; Dt.</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblPONO" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Case 
									No.</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblCSNO" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px">Bk 
									No. &amp; Set No.</TD>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px">
									<asp:label id="lblBkNo" runat="server" Width="48px" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label>&nbsp;&amp;&nbsp;
									<asp:label id="lblSetNo" runat="server" Width="48px" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 15px">IC&nbsp;No. 
									&amp; Dt.</TD>
								<TD style="WIDTH: 70%; HEIGHT: 15px">
									<asp:label id="lblICNo" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Rej 
									Memo No. &amp; Dt.</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblRejMemoNo" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">QTY 
									Offered</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblQtyOff" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Width="112px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 23px">QTY 
									Rejected</TD>
								<TD style="WIDTH: 70%; HEIGHT: 23px"><asp:label id="lblQtyREJ" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Value 
									of Rejected Stores</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblValOfRej" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Reason 
									For Rejection</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblReasonOfRej" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
										Font-Names="Verdana" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">
									<asp:label id="Label32" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True">IE Remarks<Font Color="red">(Max 500 Chars)</Font></asp:label></TD>
								<TD style="WIDTH: 100%; HEIGHT: 12px">
									<asp:textbox id="txtRemarks" tabIndex="11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="500" Height="72px" TextMode="MultiLine"></asp:textbox>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">
									Remarks&nbsp;Date&nbsp;</TD>
								<TD style="WIDTH: 100%; HEIGHT: 12px">
									<asp:textbox id="txtSTDT" onblur="check_date(txtSTDT);" tabIndex="5" runat="server" Width="88px"
										Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="10" Height="20px" Enabled="False"></asp:textbox><FONT face="Verdana" color="activecaption" size="1"><STRONG>&nbsp;</STRONG></FONT>
									</STYLE></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"></TD>
								<TD style="WIDTH: 70%">
									<asp:button id="btnSave" tabIndex="6" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button>
									<asp:button id="btnCancel" tabIndex="7" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 200px" runat="server"
					Width="100%" Height="1px"></asp:panel></TABLE>
		</form>
	</body>
</HTML>
