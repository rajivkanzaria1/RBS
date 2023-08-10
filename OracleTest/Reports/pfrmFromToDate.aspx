<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pfrmFromToDate.aspx.cs" Inherits="RBS.Reports.pfrmFromToDate" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
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
						<TD style="HEIGHT: 64px" align="center" colSpan="5">
							<uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<% if (Request.Params ["ACTION"]=="TDS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">TDS 
									DEDUCTED AGAINST THE BILLS RAISED </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="Rejection") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">REJECTION 
									IC's </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="Reinspection") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">RE-INSPECTION 
									IC's </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="IE_X") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">IE 
									PERFORMANCE REPORT </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="CLUSTER_X") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CLUSTER 
									WISE PERFORMANCE REPORT </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="BA") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">BILLING 
									ANALYSIS </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="UPCL") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">UPCL 
									REPORT </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="BATOS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">AMOUNT 
									ADJUSTMENTS OF OLD SYSTEM </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="MA") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">MISCELLENOUS 
									ADJUSTMENTS </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="ATTR") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">AMOUNT 
									TRANSFERRED TO OTHER REGIONS </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="ARFR") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">AMOUNT 
									RECEIVED FROM OTHER REGIONS </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="EFT") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">EFT 
									REPORT </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="TDS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">TDS 
									REPORT </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="STAX") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">SERVICE 
									TAX REPORT </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="CIE") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">SUMMARY 
									OF IE WISE CALL STATUS </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="DWB") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">DISCIPLINE 
									WISE INSPECTION FEE </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="SUMCALLX") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">STATEMENT 
									OF IE AND VENDOR WISE CALLS CANCELLED </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="ICSUBMIT") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">IC 
									SUBMISSION REPORT </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="CALLSWITHOUTIC") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">PENDING 
									IC'S AGAINST CALLS WHERE MATERIAL HAS BEEN ACCEPTED OR REJECTED</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="REMCALLS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">RE-MARKED 
									CALLS DURING THE PERIOD</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="CWPOANDVALUE") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CLIENT 
									WISE No. of PO's AND THEIR VALUES</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="WOF") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">WRITE 
									OFF DETAILS FOR THE PERIOD</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="RET") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">RETENTION 
									MONEY FOR THE PERIOD</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="VOUCHERDETAILS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">VOUCHER 
									WISE No. of CHQ's AND VALUE</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="DCWACOMPS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">DEFECT 
									CODE WISE ANALYSIS OF COMPLAINTS</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="BSS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">DETAILS 
									OF BILLS NOT SCANNED</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="STAMP") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">SUMMARY 
									OF IE WISE SEALING PATTERN STATUS</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="CLRETURN") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CALL 
									RETURN REPORT</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="UNBILLEDIC") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">IC 
									RECEIVED IN OFFICE BUT NOT BILLED</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="NOOFCALLS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">NO. 
									OF ONLINE &amp; MANUAL CALLS (W.E.F 29-JUN-2013)</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="FIRERETVENDCALL") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">FIRE 
									RETARDANT ITEM VENDORS CALL DETAILS</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="IECITYCALLS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">IE 
									CITY/HEADQUATER WISE CALLS</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="IE_DAIRY") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">IE 
									DAIRY</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="TEXTILEITEMS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">TEXTILE 
									ITEMS CALLS</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="OHEITEMS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">OHE 
									ITEMS CALLS</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="MOZCALLS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">MOZ 
									CALLS</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="PHED") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">JAL SHAKTI KASMIR CALLS</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="MOZPOS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">MOZ 
									PURCHASE ORDERS</FONT></B>&nbsp;</TD>
						<%}
						else if (Request.Params ["ACTION"]=="SUPSUR") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">SUPER 
									SURPRISE DETAILS</FONT></B>&nbsp;</TD>
						<%}
						else if (Request.Params ["ACTION"]=="SUPSURPSUMM") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CO 
									WISE SUPER SURPRISE SUMMARY</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="PJI") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">PENDING 
									JI CASES</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="CIEU") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">SUMMARY 
									OF IE WISE CALL STATUS (BASED ON STATUS UPDATE DATE)</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="CALLSATTENDED2DAYS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">SUMMARY 
									OF IE WISE CALL ATTENDED WITHIN 2 &amp; 5 DAYS</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="ONLINENRPAYMENTS") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">SUMMARY 
									OF ONLINE PAYMENT IN NR</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="PLEXCEPT") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">DETAILS 
									OF CASES WHERE ITEM IS NOT LINKED WITH MASTER CHECKSHEET</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="PLLINKED") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">DETAILS 
									OF CASES WHERE ITEM IS LINKED WITH MASTER CHECKSHEET</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="CALLEXCEPT") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">DETAILS 
									OF ITEMS IN RAILWAY CALLS WHERE MASTER CHECKSHEET ARE NOT LINKED</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="PLLINKEDCHK") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">DETAILS 
									OF PL's LINKED WITH MASTER CHECKSHEET</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="AFTEREXPDT") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CASES 
									OF FIRST VISIT DATE AFTER LIKELY INSPECTION DATE</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="SUMMARYAFTEREXPDT") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">SUMMARY 
									OF CASES WHERE FIRST VISIT DATE AFTER LIKELY INSPECTION DATE REGION WISE</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="ICFBILLDET") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">ICF 
									BILLING DETAILS FOR PAYMENT</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="CCAPP") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CALL 
									CANCELLATION APPROVAL REPORT</FONT></B>&nbsp;</TD>
						<%}else if (Request.Params ["ACTION"]=="CR") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CONTRACT 
									REVIEW STATEMENT </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="LABR") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">LAB 
									INVOICE REPORT </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="CREDITNOTE") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CREDIT 
									NOTE INVOICES</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="RETBILLSBPOCHANGE") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">RETURNED 
									BILLS BPO CHANGE REPORT </FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="CHECK") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">Progress 
									of Checksheet</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="TECH") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">Technical 
									References</FONT></B>
						</TD>
						<%}else if (Request.Params ["ACTION"]=="CMWISEICNI") {%>
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CMWISE 
									IC ISSUED BY IE BUT NOT RECEIVED IN OFFICE</FONT></B>
						</TD>
						<%}%>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 33.09%; HEIGHT: 52px" align="right"><B><FONT face="Verdana" color="darkblue" size="2">For 
									The Period --&gt;</FONT></B></TD>
						<TD style="WIDTH: 10.52%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">From</FONT></B></TD>
						<TD style="WIDTH: 13.97%; HEIGHT: 52px">
							<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
								style="TEXT-ALIGN: center" tabIndex="3" runat="server" Height="20px" Width="100px" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt" MaxLength="10"></asp:textbox></TD>
						<TD style="WIDTH: 6.76%; HEIGHT: 52px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">To</FONT></B></TD>
						<TD style="WIDTH: 30%; HEIGHT: 52px">
							<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
								style="TEXT-ALIGN: center" tabIndex="4" runat="server" Height="20px" Width="100px" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD align="center" colSpan="5">
							<asp:label id="Label5" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Names="Verdana"
								Font-Size="8pt" Font-Bold="True">* Enter Date in DD/MM/YYYY Format.</asp:label></TD>
					</TR>
					<%if (Request.Params ["ACTION"]=="Rejection") {%>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 47px" align="center" colSpan="5"><FONT face="Verdana" color="darkblue" size="2"><B>Report 
									to be based on&nbsp;
									<asp:RadioButton id="rdbBillDt" tabIndex="10" runat="server" Text="Bill Date" Checked="True" GroupName="grpSort"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;
									<% if (Request.Params ["ACTION"]=="U") {%>
									&nbsp;<%}%>
									<asp:RadioButton id="rdbICDT" tabIndex="11" runat="server" Text="IC Date" GroupName="grpSort"></asp:RadioButton>&nbsp;&nbsp;
								</B></FONT>
						</TD>
					</TR>
					<%}%>
					<%if (Request.Params ["ACTION"]=="FIRERETVENDCALL"  || Request.Params ["ACTION"]=="TEXTILEITEMS" || Request.Params ["ACTION"]=="OHEITEMS" || Request.Params ["ACTION"]=="MOZCALLS" || Request.Params ["ACTION"]=="PHED") {%>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 47px" align="center" colSpan="5"><FONT face="Verdana" color="darkblue" size="2"><B>
									<asp:label id="Label4" runat="server" Width="112px" ForeColor="DarkBlue" Font-Names="Verdana"
										Font-Size="8pt" Font-Bold="True">Status of Calls</asp:label>&nbsp;&nbsp;
									<asp:dropdownlist id="lstCallStatus" tabIndex="1" runat="server" Width="40%" ForeColor="DarkBlue"
										Font-Names="Verdana" Font-Size="8pt" OnChange="call_cancel_status();"></asp:dropdownlist><BR>
									<asp:CheckBox id="CheckBox1" runat="server" Text="All Regions"></asp:CheckBox></B></FONT></TD>
					</TR>
					<%}%>
					<% if (Request.Params ["ACTION"]=="ICISSUEDNSUB") {%>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">IC 
									ISSUED BY IE BUT NOT RECEIVED IN OFFICE</FONT></B><BR>
							<asp:RadioButton id="RdbIE" tabIndex="8" runat="server" Visible="False" Text="IE Wise" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" Checked="True" GroupName="g4" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:RadioButton id="RdbCM" tabIndex="9" runat="server" Visible="False" Text="CM Wise" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" GroupName="g4" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;
						</TD>
					</TR>
					<%}%>
					<% if (Request.Params ["ACTION"]=="REMARKING") {%>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 100%; HEIGHT: 52px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2">CALL 
									REMARKING DETAIL</FONT></B>
							<P>
								<asp:RadioButton id="Rdb_INI" tabIndex="8" runat="server" Text="BY REMARK INITIATED DATE" ForeColor="DarkBlue"
									Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" Checked="True" GroupName="g4" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:RadioButton id="Rdb_APP" tabIndex="9" runat="server" Text="BY REMARK APPROVED DATE" ForeColor="DarkBlue"
									Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" GroupName="g4" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;
							</P>
							<BR>
							<P>
								<asp:label id="Label_CS" runat="server" Width="112px" ForeColor="DarkBlue" Font-Names="Verdana"
									Font-Size="8pt" Font-Bold="True">Status of Calls</asp:label>&nbsp;&nbsp;
								<asp:dropdownlist id="DDL_STATUS" tabIndex="1" runat="server" Width="40%" ForeColor="DarkBlue" Font-Names="Verdana"
									Font-Size="8pt"></asp:dropdownlist></P>
						</TD>
					</TR>
					<%}%>
					<%if (Request.Params ["ACTION"]=="SUPSUR") {%>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 47px" align="center" colSpan="5"><FONT face="Verdana" color="darkblue" size="2"><B>
									<P>
										<asp:RadioButton id="rdbAllCM" tabIndex="8" runat="server" Text="All CM" ForeColor="DarkBlue" Font-Names="Verdana"
											Font-Size="8pt" Font-Bold="True" Checked="True" GroupName="g4" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:RadioButton id="rdbPCM" tabIndex="9" runat="server" Text="Particular CM" ForeColor="DarkBlue"
											Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" GroupName="g4" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;
									</P>
									<P>
										<asp:dropdownlist id="lstCO" tabIndex="10" runat="server" Visible="False" Height="20px" Width="60%"
											ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"></asp:dropdownlist><BR>
									</P>
								</B></FONT>
						</TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 47px" align="center" colSpan="5"><FONT face="Verdana" color="darkblue" size="2"><B>
									<P>
										<asp:RadioButton id="rdbAllSector" tabIndex="8" runat="server" Text="All scope of sector where Item is covered."
											ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" Checked="True" GroupName="g5"
											AutoPostBack="True"></asp:RadioButton>
										<asp:RadioButton id="rdbPSector" tabIndex="9" runat="server" Text="Particular scope of sector where Item is covered."
											ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" GroupName="g5" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;
									</P>
									<P>
										<asp:dropdownlist id="ddlItemScope" tabIndex="6" runat="server" Visible="False" Width="60%" ForeColor="Blue"
											Font-Names="Verdana" Font-Size="8pt" Font-Bold="True">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="A">(IAF 12) Chemical/Paints </asp:ListItem>
											<asp:ListItem Value="B">(IAF 14b) Plastics Pipes &amp; Fittings </asp:ListItem>
											<asp:ListItem Value="C">(IAF 16) Cement Pipes, AC Pressue Pipes &amp; PCC Poles</asp:ListItem>
											<asp:ListItem Value="D">(IAF 17b)  Rails, CI/DI Pipes, Steel Tubes and Fittings, Seamless Blocl/Galvanised, Valves</asp:ListItem>
											<asp:ListItem Value="E">S(IAF 19a) Conductor, Cables, Power Transformers, CT/PT Fans, Relay, Panel, DG set, Alternator, Energy Meter</asp:ListItem>
											<asp:ListItem Value="F">(IAF 22) Railway Rolling Stock</asp:ListItem>
											<asp:ListItem Value="G">(IAF 28) Water Supply</asp:ListItem>
											<asp:ListItem Value="H">(IAF 28) Construction</asp:ListItem>
											<asp:ListItem Value="I">(IAF 07) Paper for Printing</asp:ListItem>
											<asp:ListItem Value="J">(IAF 09) Printed Tickes &amp; Ruled Papers</asp:ListItem>
											<asp:ListItem Value="O">Others</asp:ListItem>
										</asp:dropdownlist></P>
								</B></FONT>
						</TD>
					</TR>
					<%}%>
					<%if (Request.Params ["ACTION"]=="HIGHVALUE") {%>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 47px" align="center" colSpan="5"><FONT face="Verdana" color="darkblue" size="2"><B>
									<P>
										<asp:RadioButton id="Radio_all_cm" tabIndex="8" runat="server" Text="All CM" ForeColor="DarkBlue"
											Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" Checked="True" GroupName="g14" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:RadioButton id="Radio_cm" tabIndex="9" runat="server" Text="Particular CM" ForeColor="DarkBlue"
											Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" GroupName="g14" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;
									</P>
									<P>
										<asp:dropdownlist id="lst_co_h" tabIndex="10" runat="server" Visible="False" Height="20px" Width="60%"
											ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"></asp:dropdownlist><BR>
									</P>
								</B></FONT>
						</TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 47px" align="center" colSpan="5"><FONT face="Verdana" color="darkblue" size="2"><B>Report 
									To be Sorted On
									<P>
										<asp:RadioButton id="rdbValue" tabIndex="8" runat="server" Text="Insp Fee" ForeColor="DarkBlue" Font-Names="Verdana"
											Font-Size="8pt" Font-Bold="True" Checked="True" GroupName="g15" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:RadioButton id="rdbDP" tabIndex="9" runat="server" Text="Delivery Period" ForeColor="DarkBlue"
											Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" GroupName="g15" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;
									</P>
									<P>
										<asp:RadioButton id="rdbDesireDt" tabIndex="9" runat="server" Text="Desire Date" ForeColor="DarkBlue"
											Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" GroupName="g15" AutoPostBack="True"></asp:RadioButton>
										<asp:RadioButton id="rdbPendingSince" tabIndex="9" runat="server" Text="Pending Since" ForeColor="DarkBlue"
											Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" GroupName="g15" AutoPostBack="True"></asp:RadioButton><BR>
									</P>
								</B></FONT>
						</TD>
					</TR>
					<%}%>
					<TR bgColor="#f0f8ff">
						<TD align="center" colSpan="5">
							<asp:button id="btnSubmit" runat="server" Text="Submit" ForeColor="DarkBlue" Font-Bold="True"
								BackColor="#C0C0FF"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
		</FONT>
	</body>
</HTML>

