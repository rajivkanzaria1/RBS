<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inspection_Fee_Bill_Edit.aspx.cs" Inherits="RBS.Inspection_Fee_Bill_Edit" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>INSPECTION FEE BILL</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtBillNo.value)=="")
		 {
		 alert("BILL NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else 
		return;
		}
		function validate1()
		{
		if(document.Form1.txtBillNo.value=="" && document.Form1.txtCRDt.value=="" && document.Form1.txtCNO.value=="")
		{
		 alert("ENTER BILL NO. OR CALL RECEIVE DT OR CASE NO. TO SEARCH RECORDS");
		 event.returnValue=false;
		 }
		 
		else 
		return;
		}
		function makeUppercase()
		 {
			document.Form1.txtBillNo.value = document.Form1.txtBillNo.value.toUpperCase();
		 }
        </script>
	</HEAD>
	<BODY bgColor="white" onload="javascript:document.Form1.txtBillNo.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px" align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue" Width="196px">INSPECTION FEE BILL</asp:label></P>
					</TD>
				</TR>
				<TR>
					<td align="center">
						<TABLE id="Table4" style="WIDTH: 262px; HEIGHT: 38px" borderColor="#b0c4de" cellSpacing="0"
							cellPadding="1" width="30%" bgColor="aliceblue" border="1">
							<TR>
								<TD style="WIDTH: 30%; HEIGHT: 36px" align="right" colSpan="1" rowSpan="1"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										BackColor="AliceBlue" ForeColor="DarkBlue" Width="104px" Height="20px">Bill No.</asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 36px"><asp:textbox id="txtBillNo" onblur="makeUppercase();" tabIndex="1" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="60%" Height="20px" MaxLength="10"></asp:textbox></TD>
							</TR>
						</TABLE>
					</td>
				</TR>
				<tr>
				</tr>
				<TR>
					<TD align="center"><asp:button id="btnAdd" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="64px" Text="New Bill" Visible="False" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="67px" Text="View Bill" onclick="btnMod_Click"></asp:button><asp:button id="btnDelete" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Width="67px" Text="Delete" Visible="False" onclick="btnDelete_Click"></asp:button><asp:button id="btnShow" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="94px" Text="Search Bill" Visible="False" onclick="btnShow_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center"><asp:datagrid id="grdBill" runat="server" Font-Names="Verdana" Font-Size="8pt" BackColor="White"
							Width="853px" Height="100px" AutoGenerateColumns="False" BorderStyle="Groove" BorderColor="DarkBlue" CellPadding="0">
							<SelectedItemStyle Font-Names="Verdana"></SelectedItemStyle>
							<EditItemStyle Font-Names="Verdana" Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Font-Names="Verdana" BackColor="#CCCCFF"></AlternatingItemStyle>
							<ItemStyle Font-Names="Verdana" HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
								VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:HyperLinkColumn Text="Select" DataNavigateUrlField="BILL_NO" DataNavigateUrlFormatString="Inspection_Fee_Bill_Edit.aspx?BILL_NO={0}"
									NavigateUrl="Inspection_Fee_Bill_Edit.aspx">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="BILL_NO" HeaderText="Bill No.">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BILL_DT" HeaderText="Bill Date">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CALL_RECV_DT" HeaderText="Call Recieve Date In Rites">
									<HeaderStyle Width="30%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="VEND_CD" HeaderText="Vendor">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed" Width="384px" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>

