<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bill_Report.aspx.cs" Inherits="RBS.Bill_Report" %>

<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%--<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>--%>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Bill_Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
					
				if(document.Form1.rdbBNO.checked==false && document.Form1.rdbPER.checked==false)			
				{
					alert("Select one of The Option from Print Bill Nos or Print Bill For The Given Period");
					event.returnValue=false;	
				}
				else if(document.Form1.rdbBNO.checked==true)
				{	
						
						if(trimAll(document.Form1.txtBillFr.value)=="" && trimAll(document.Form1.txtBillTo.value)=="")
						{
						alert("BILL NO. FROM AND TO CANNOT BE LEFT BLANK.");
						event.returnValue=false;	
						}
						
				}
				else if(document.Form1.rdbPER.checked==true)
				{
						if(trimAll(document.Form1.frmDt.value)=="" && trimAll(document.Form1.toDt.value)=="")
						{
						alert("FROM DATE AND TO DATE CANNOT BE LEFT BLANK.");
						event.returnValue=false;	
						}
				}
				else if(document.Form1.rdbBPO.checked==true)
				{
						if(trimAll(document.Form1.txtBPO.value)=="")
						{
						alert("BPO NO. CANNOT BE LEFT BLANK.");
						event.returnValue=false;	
						}
						
				}
				else if(document.Form1.rdbLetter.checked==true)
				{
						if(trimAll(document.Form1.frmDt1.value)=="" && trimAll(document.Form1.toDt1.value)=="")
						{
						alert("FROM DATE AND TO DATE CANNOT BE LEFT BLANK.");
						event.returnValue=false;	
						}
				}
			
			
		}
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
	<%--		<CR:CRYSTALREPORTVIEWER id="CrystalReportViewer1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px"
				runat="server" Visible="False" SeparatePages="False" DisplayGroupTree="False" DisplayToolbar="False"
				Height="50px" Width="350px" EnableDrillDown="False"></CR:CRYSTALREPORTVIEWER>--%>
		
			<cr:crystalreportviewer runat="server" autodatabind="true"></cr:crystalreportviewer>
			
			<asp:panel id="MyPannel" style="Z-INDEX: 103; LEFT: 0px; POSITION: absolute; TOP: 0px" runat="server"
				width="100%">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 56px"
					cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR align="center">
						<TD style="HEIGHT: 39px">
							<uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 126px">
							<P>&nbsp;</P>
						</TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD align="center">
							<P>
								<TABLE id="Table2" style="WIDTH: 95%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1"
									cellPadding="1" bgColor="#f0f8ff" border="1">
									<TR>
										<TD style="WIDTH: 22.89%; HEIGHT: 38px"></TD>
										<TD style="WIDTH: 24.41%; HEIGHT: 38px">
											<P>
												<asp:label id="lblFrom" runat="server" Width="48%" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
													Font-Bold="True">From</asp:label></P>
										</TD>
										<TD style="WIDTH: 21.27%; HEIGHT: 38px">
											<P>
												<asp:label id="lblTo" runat="server" Width="48%" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
													Font-Bold="True">To</asp:label></P>
										</TD>
										<TD style="WIDTH: 30%; HEIGHT: 38px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 22.89%; HEIGHT: 38px">
											<asp:radiobutton id="rdbBNO" tabIndex="1" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
												Font-Bold="True" AutoPostBack="True" GroupName="g1" Text="Print Bill Nos." oncheckedchanged="rdbBNO_CheckedChanged"></asp:radiobutton></TD>
										<TD style="WIDTH: 24.41%; HEIGHT: 38px">
											<asp:TextBox id="txtBillFr" tabIndex="4" runat="server" Width="85px" MaxLength="10"></asp:TextBox></TD>
										<TD style="WIDTH: 21.27%; HEIGHT: 38px">
											<asp:TextBox id="txtBillTo" tabIndex="5" runat="server" Width="85px" MaxLength="10"></asp:TextBox></TD>
										<TD style="WIDTH: 30%; HEIGHT: 38px">
											<asp:label id="lblBtype" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
												Font-Bold="True">All Bills or Unprinted Bills</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 22.89%; HEIGHT: 38px">
											<asp:radiobutton id="rdbPER" tabIndex="2" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="True" GroupName="g1" Text="Print Bills For Given Period" oncheckedchanged="rdbPER_CheckedChanged"></asp:radiobutton></TD>
										<TD style="WIDTH: 24.41%; HEIGHT: 38px">
											<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
												style="TEXT-ALIGN: center" tabIndex="6" runat="server" Width="49%" Height="20px" Font-Size="8pt"
												Font-Names="Verdana" ForeColor="DarkBlue" MaxLength="10"></asp:textbox></TD>
										<TD style="WIDTH: 21.27%; HEIGHT: 38px">
											<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
												style="TEXT-ALIGN: center" tabIndex="7" runat="server" Width="49%" Height="20px" Font-Size="8pt"
												Font-Names="Verdana" ForeColor="DarkBlue" MaxLength="10"></asp:textbox></TD>
										<TD style="WIDTH: 30%; HEIGHT: 38px">
											<asp:dropdownlist id="lstBillType" tabIndex="8" runat="server" Width="100%" Height="25px" Font-Size="8pt"
												Font-Names="Verdana" ForeColor="DarkBlue"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 22.89%; HEIGHT: 55px" colSpan="4">
											<asp:radiobutton id="rdbPClient" tabIndex="2" runat="server" Width="100%" Visible="False" Font-Size="8pt"
												Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="True" GroupName="S1"
												Text="Print Bills For Given Client" oncheckedchanged="rdbPClient_CheckedChanged"></asp:radiobutton>
											<asp:dropdownlist id="lstClientType" tabIndex="6" runat="server" Width="120px" Visible="False" Font-Size="8pt"
												Font-Names="Verdana" ForeColor="DarkBlue" AutoPostBack="True"></asp:dropdownlist>
											<asp:dropdownlist id="lstBPO1" tabIndex="7" runat="server" Width="100%" Height="20px" Visible="False"
												Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" onchange="fill_bpo_cd();"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 22.89%; HEIGHT: 38px" align="center" colSpan="4">
											<asp:RadioButton id="rdbAllUser" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
												Font-Bold="True" AutoPostBack="True" GroupName="g4" Text="All USERS" Checked="True" oncheckedchanged="rdbPar_User_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;
											<asp:RadioButton id="rdbPar_User" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
												Font-Bold="True" AutoPostBack="True" GroupName="g4" Text="Particular User" oncheckedchanged="rdbPar_User_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;&nbsp;
											<asp:dropdownlist id="lstUID" tabIndex="7" runat="server" Width="312px" Height="20px" Visible="False"
												Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" onchange="fill_bpo_cd();"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 22.89%; HEIGHT: 38px" align="center" colSpan="4">
											<asp:RadioButton id="rdbAll" runat="server" Visible="False" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkBlue" Font-Bold="True" GroupName="g5" Text="All Bills For the Period" Checked="True"></asp:RadioButton>&nbsp;&nbsp;
											<asp:RadioButton id="rdbRLY" runat="server" Visible="False" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkBlue" Font-Bold="True" GroupName="g5" Text="Rly Bills Other then Digital Invoice Sent to CRIS"></asp:RadioButton>&nbsp;&nbsp;&nbsp;
											<asp:RadioButton id="rdbNonRly" runat="server" Visible="False" Font-Size="8pt" Font-Names="Verdana"
												ForeColor="DarkBlue" Font-Bold="True" GroupName="g5" Text="Non Rly Bills"></asp:RadioButton>
											<asp:label id="Label6" runat="server" Width="37px" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
												Font-Bold="True">And</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 22.89%; HEIGHT: 37px">
											<asp:label id="Label19" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
												Font-Bold="True">Bill Invoice Before GST Or After GST</asp:label></TD>
										<TD style="WIDTH: 24.41%; HEIGHT: 37px">
											<asp:RadioButton id="rdbBefore" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
												Font-Bold="True" GroupName="g3" Text="Before GST "></asp:RadioButton></TD>
										<TD style="WIDTH: 21.27%; HEIGHT: 37px">
											<asp:RadioButton id="rdbAfterGST" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
												Font-Bold="True" GroupName="g3" Text="After GST " Checked="True"></asp:RadioButton></TD>
										<TD style="WIDTH: 30%; HEIGHT: 37px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 22.89%">
											<asp:radiobutton id="rdbBPO" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
												Font-Bold="True" AutoPostBack="True" GroupName="g2" Text="BPO Wise-PO Wise Bills" oncheckedchanged="rdbBPO_CheckedChanged"></asp:radiobutton></TD>
										<TD style="WIDTH: 30%" colSpan="3">
											<asp:textbox id="txtBPO" style="TEXT-ALIGN: center" tabIndex="8" runat="server" Width="72px"
												Height="20px" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" MaxLength="5"></asp:textbox>
											<asp:button id="btnFC_List" tabIndex="9" runat="server" Width="96px" Height="20px" Font-Size="8pt"
												Font-Names="Verdana" ForeColor="DarkBlue" Font-Bold="True" Text="Select BPO"></asp:button>
											<asp:dropdownlist id="lstBPO" tabIndex="10" runat="server" Width="100%" Height="20px" Visible="False"
												Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" AutoPostBack="True" onselectedindexchanged="lstBPO_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 64px" colSpan="4"></TD>
									</TR>
								</TABLE>
								<asp:Button id="btnPrintBill_No_UID" tabIndex="10" runat="server" Width="229px" ForeColor="DarkBlue"
									Font-Bold="True" Text="Print List of Bill No's with USER ID" BackColor="#C0C0FF" DESIGNTIMEDRAGDROP="141" onclick="btnPrintBill_No_UID_Click"></asp:Button>
								<asp:Button id="btnPrintBill_No" tabIndex="10" runat="server" Width="164px" ForeColor="DarkBlue"
									Font-Bold="True" Text="Print List of Bill No's" BackColor="#C0C0FF" DESIGNTIMEDRAGDROP="141" onclick="btnPrintBill_No_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
								<asp:Button id="btnView" tabIndex="11" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Text="View" BackColor="#C0C0FF" DESIGNTIMEDRAGDROP="141" onclick="btnView_Click"></asp:Button>
								<asp:Button id="btnPrint" tabIndex="12" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Text="Print" BackColor="#C0C0FF" onclick="btnPrint_Click"></asp:Button>&nbsp;</P>
						</TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>