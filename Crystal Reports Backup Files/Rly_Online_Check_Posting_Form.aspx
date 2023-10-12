<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rly_Online_Check_Posting_Form.aspx.cs" Inherits="RBS.Rly_Online_Check_Posting_Form.Rly_Online_Check_Posting_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Cheque Posting Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript" type="text/javascript">
		function txtCopy()
		{
			
			if(check_date(document.Form1.frmDt)==true && trimAll(document.Form1.toDt.value)=="")
			{
				document.Form1.toDt.value=document.Form1.frmDt.value;
			}
			
		}
		
		function validate2()
		{
			if(document.Form1.frmDt=="[object]" && trimAll(document.Form1.frmDt.value)=="")
			{
				alert("You Cannot Leave From Date Blank!!!");
				event.returnValue=false;
			}
		}
		function validate()
		{
		if(trimAll(document.Form1.txtCNO.value)=="" || trimAll(document.Form1.lstBank1.value)=="" || trimAll(document.Form1.txtCDT.value)=="")
		{
		 alert("Bank or Cheque No. or Cheque Date. Cannot Be Left Blank");
		 event.returnValue=false;
		}
		}
		
		
		
		
        </script>
</HEAD>
	<BODY bgColor="white">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 48px"
				cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue" Width="90%"> RAILWAYS ONLINE PAYMENT POSTING FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center">
						<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 240px" borderColor="#b0c4de" cellSpacing="1"
							cellPadding="1" bgColor="#f0f8ff" border="1">
							<TBODY>
								<TR>
									<TD style="WIDTH: 0%; HEIGHT: 30px" vAlign="top" align="left">
										<P><asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="40px">Bank</asp:label></P>
									</TD>
									<TD style="WIDTH: 34.13%; HEIGHT: 30px" vAlign="top"><asp:dropdownlist id="lstBank1" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="95%"></asp:dropdownlist><asp:label id="lblBank" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="100%"></asp:label></TD>
									<TD style="WIDTH: 4.02%; HEIGHT: 30px" vAlign="top">
										<P><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">Cheque No</asp:label></P>
									</TD>
					</TD>
					<TD style="WIDTH: 8.09%; HEIGHT: 30px" vAlign="top">
						<P><asp:textbox id="txtCNO" style="TEXT-ALIGN: center" tabIndex="2" runat="server" Font-Names="Verdana"
								Font-Size="8pt" ForeColor="DarkBlue" Width="90%" MaxLength="12" Height="20px"></asp:textbox><asp:label id="lblCNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed" Width="100%"></asp:label><asp:button id="btnSearch" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="DarkBlue" Width="111px" Text="Search" onclick="btnSearch_Click"></asp:button></P>
					</TD>
					<TD style="WIDTH: 3.93%; HEIGHT: 30px" vAlign="top">
						<P><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Width="100%">Cheque Date</asp:label></P>
					</TD>
					<TD style="WIDTH: 20%; HEIGHT: 30px" vAlign="top"><asp:textbox id="txtCDT" onblur="check_date(txtCDT);" style="TEXT-ALIGN: center" tabIndex="3"
							runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="100%" MaxLength="12" Height="20px"></asp:textbox><asp:label id="lblCDate" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed" Width="100%"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 8.29%" vAlign="top"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%"> Voucher No.</asp:label></TD>
					<TD style="WIDTH: 0%" vAlign="top"><asp:label id="lblVNo" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed" Width="35%"></asp:label><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="15%">Dated.</asp:label><asp:label id="lblVDT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed" Width="40%" Height="8px"></asp:label></TD>
					<TD style="WIDTH: 15.65%; HEIGHT: 9px" vAlign="top">
						<P><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Width="100%">Cheque Amount</asp:label></P>
					</TD>
					<TD style="WIDTH: 16.93%; HEIGHT: 9px" vAlign="top">
						<P><asp:label id="lblAmt" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed" Width="100%" Height="16px"></asp:label></P>
					</TD>
					<TD style="WIDTH: 12.08%; HEIGHT: 9px" vAlign="top">
						<P><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Width="100%">  Posted Amount</asp:label></P>
					</TD>
					<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
						<P><asp:label id="lblAmtADJ" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed" Width="100%" Height="16px"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.2%; HEIGHT: 9px" vAlign="top"><asp:label id="Label20" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Paying Authority</asp:label></TD>
					<TD style="WIDTH: 21.98%; HEIGHT: 9px" vAlign="top">
						<DIV><asp:label id="lblCBPO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed" Width="100%" Height="16px"></asp:label><asp:label id="lblBPORly" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed" Width="100%" Height="16px" Visible="False"></asp:label></DIV>
					<TD style="WIDTH: 11.68%" vAlign="top"><asp:label id="Label15" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Amount Transferred to Other Regions</asp:label></TD>
					<TD style="WIDTH: 0%" vAlign="top"><asp:label id="lblTransAmt" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed" Width="80%"></asp:label><asp:textbox id="Textbox1" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana" Font-Size="8pt"
							BackColor="AliceBlue" ForeColor="AliceBlue" Width="1px" MaxLength="10" Height="1px"></asp:textbox></TD>
					<TD style="WIDTH: 14.12%" vAlign="top"><asp:label id="Label26" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Suspense Amount</asp:label></TD>
					<TD style="WIDTH: 0%" vAlign="top"><asp:label id="lblSAmt" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed" Width="80%"></asp:label><asp:textbox id="txtSAmt" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana" Font-Size="8pt"
							BackColor="AliceBlue" ForeColor="AliceBlue" Width="1px" MaxLength="10" Height="1px"></asp:textbox></TD>
					</TD></TR>
				<TR>
					<TD style="WIDTH: 14.12%" vAlign="top" colSpan="6"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="264px">Online Bills Cleared for the Period:</asp:label><B><FONT face="Verdana" color="darkblue" size="2">From</FONT></B><asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
							style="TEXT-ALIGN: center" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="100px" MaxLength="10" Height="20px"></asp:textbox>&nbsp;<B><FONT face="Verdana" color="darkblue" size="2">To&nbsp;</FONT></B><asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
							style="TEXT-ALIGN: center" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="100px" MaxLength="10" Height="20px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnBillsCleared" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Width="176px" Text="Show Bills Cleared" onclick="btnBillsCleared_Click"></asp:button>
						<asp:label id="Label52" runat="server" Width="336px" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">* Based On Payment Date</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 14.12%" vAlign="top" colSpan="6">
						<DIV><TITTLE:CUSTOMDATAGRID id="grdVDt" runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="150px"
								FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
								CellPadding="2" FreezeRows="0" PageSize="15" AutoGenerateColumns="False" BorderColor="DarkBlue">
<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF">
</AlternatingItemStyle>

<EditItemStyle Height="10%">
</EditItemStyle>

<FooterStyle CssClass="GridHeader">
</FooterStyle>

<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal">
</ItemStyle>

<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="BILL_NO" HeaderText="Bill No."></asp:BoundColumn>
<asp:BoundColumn DataField="INVOICE_NO" HeaderText="Invoice No"></asp:BoundColumn>
<asp:BoundColumn DataField="BILL_AMOUNT" HeaderText="Bill Amount">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CO7_NO" HeaderText="CO7 No."></asp:BoundColumn>
<asp:BoundColumn DataField="CO7_DT" HeaderText="CO7 DT"></asp:BoundColumn>
<asp:BoundColumn DataField="PAYMENT_DT" HeaderText="Payment Dt"></asp:BoundColumn>
<asp:BoundColumn DataField="AMT_PASSED" HeaderText="Passed Amt"></asp:BoundColumn>
<asp:BoundColumn DataField="BILL_AMT_CLEARED" HeaderText="Bill Amt Cleared"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="BPO_CD" HeaderText="BPO_CD"></asp:BoundColumn>
<asp:TemplateColumn>
<ItemTemplate>
<asp:CheckBox id=chkBNO runat="server"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
				<tr>
					<td align="center" colSpan="6"><asp:button id="btnSubmit" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Width="176px" Text="Submit" onclick="btnSubmit_Click"></asp:button></td>
				</tr>
			</TABLE></TD></TR></TBODY></TABLE>&nbsp;</form>
	</BODY>
</HTML>

