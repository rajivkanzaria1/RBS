<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BPO_WISE_BILL_CHECK.aspx.cs" Inherits="RBS.BPO_WISE_BILL_CHECK.BPO_WISE_BILL_CHECK" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>BPO_WISE_BILL_</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
			if(document.Form1.RadioButton1.checked==true)
			{
					if(trimAll(document.Form1.txtBPO.value)=="")
					{
					alert("BPO CODE CANNOT BE LEFT BLANK.");
					event.returnValue=false;	
					}
					else if(document.Form1.RadioButton4.checked==true) 
					{
						if(trimAll(document.Form1.frmDt.value)=="" && trimAll(document.Form1.toDt.value)=="")
						{
						alert("FROM DATE AND TO DATE CANNOT BE BLANK.");
						event.returnValue=false;	
						}
					
					}
			}
			else if(document.Form1.RadioButton2.checked==true)
			{
					if(trimAll(document.Form1.txtPONO.value)=="")
					{
					alert("PO No. CANNOT BE LEFT BLANK.");
					event.returnValue=false;	
					}
			}
			
		}
        </script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 23px" align="center">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue">Report</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 28px">
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 90%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 16.75%"><asp:radiobutton id="RadioButton1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" GroupName="g1" AutoPostBack="True" Text="BPO WISE"></asp:radiobutton></TD>
									<TD style="WIDTH: 30%"><asp:textbox id="txtBPO" style="TEXT-ALIGN: center" tabIndex="11" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="5" Width="72px"></asp:textbox><asp:button id="btnFC_List" tabIndex="12" runat="server" Font-Names="Verdana" Font-Size="8pt"
											Font-Bold="True" ForeColor="DarkBlue" Text="Select BPO" Height="20px" Width="96px"></asp:button><asp:dropdownlist id="lstBPO" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											AutoPostBack="True" Height="20px" Width="100%" Visible="False"></asp:dropdownlist></TD>
									<TD style="WIDTH: 21.27%">
										<P><asp:radiobutton id="RadioButton3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" GroupName="g2" AutoPostBack="True" Text="For the Month" Width="100%"></asp:radiobutton><asp:radiobutton id="RadioButton4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" GroupName="g2" AutoPostBack="True" Text="For Given Period" Width="100%"></asp:radiobutton><asp:radiobutton id="RadioButton5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" GroupName="g2" AutoPostBack="True" Text="All" Width="100%" Checked="True"></asp:radiobutton></P>
									</TD>
									<TD style="WIDTH: 30%">
										<P><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="48%">Label</asp:label><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="48%">Label</asp:label></P>
										<P><asp:dropdownlist id="toMonth" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Height="20px" Width="49%"></asp:dropdownlist><asp:dropdownlist id="Year" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Height="20px" Width="49%"></asp:dropdownlist><asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
												style="TEXT-ALIGN: center" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="10"
												Width="49%"></asp:textbox><asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
												style="TEXT-ALIGN: center" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px"
												MaxLength="10" Width="49%"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 16.75%"><asp:radiobutton id="RadioButton2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" GroupName="g1" AutoPostBack="True" Text="PO WISE"></asp:radiobutton></TD>
									<TD style="WIDTH: 30%"><asp:textbox id="txtPONO" style="TEXT-ALIGN: center" tabIndex="11" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="55" Width="100%"></asp:textbox></TD>
									<TD style="WIDTH: 21.27%"></TD>
									<TD style="WIDTH: 30%"></TD>
								</TR>
							</TABLE>
						</P>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center"><asp:button id="btnview" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Text="View" Width="85px"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
