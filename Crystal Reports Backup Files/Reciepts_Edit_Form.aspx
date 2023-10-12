<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reciepts_Edit_Form.aspx.cs" Inherits="RBS.Reciepts_Edit_Form.Reciepts_Edit_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>INSPECTION FEE BILL</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<BODY bgColor="white">
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
		if(trimAll(document.Form1.txtBillNo.value)=="" && trimAll(document.Form1.txtCsNo.value)=="")
		{
		 alert("ENTER BILL NO. OR CASE NO. TO SEARCH RECIEPTS.");
		 event.returnValue=false;
		 }
		 
		else 
		return;
		}
		function makeUppercase(field)
		 {
		 var ss=field.value;
	    	field.value=ss.toUpperCase();
		 }
        </script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Width="196px" ForeColor="DarkBlue" BackColor="White"
								Font-Bold="True" Font-Size="10pt" Font-Names="Verdana"> RECIEPTS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" style="WIDTH: 60%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="0"
							cellPadding="0" width="239" bgColor="aliceblue" border="1">
							<TR>
								<TD style="WIDTH: 10%; HEIGHT: 36px"><asp:label id="Label6" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Bill No.</asp:label></TD>
								<TD style="WIDTH: 40%; HEIGHT: 36px"><asp:textbox id="txtBillNo" onblur="makeUppercase(txtBillNo);" tabIndex="1" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
								<TD style="WIDTH: 10%; HEIGHT: 36px"><asp:label id="Label2" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Case No.</asp:label></TD>
								<TD style="WIDTH: 40%; HEIGHT: 36px"><asp:textbox id="txtCsNo" onblur="makeUppercase(txtCsNo);" tabIndex="2" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Height="20px" MaxLength="9"></asp:textbox></TD>
							</TR>
						</TABLE>
						<asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">
								To Edit/Delete a Reciept --> Enter Bill No. & Click on "Modify" Button</asp:label><asp:label id="Label7" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">
								To Search Reciepts --> Enter Case No. or Bill No and click on "Search Reciepts" Button</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnAdd" tabIndex="3" runat="server" Width="99px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="New Reciept" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="4" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Modify" onclick="btnMod_Click"></asp:button><asp:button id="btnDelete" tabIndex="5" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Delete" Visible="False" onclick="btnDelete_Click"></asp:button><asp:button id="btnSearch" tabIndex="6" runat="server" Width="117px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Search Reciepts" onclick="btnSearch_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center">
						<P><TITTLE:CUSTOMDATAGRID id="grdR" runat="server" Width="70%" Height="8px" GridWidth="100%" GridHeight="200px"
								AutoGenerateColumns="False" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" BorderColor="DarkBlue"
								AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" CellPadding="2" FreezeRows="0" PageSize="15">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
									CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Select">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"Reciepts_Form.aspx?BILL_NO=" + DataBinder.Eval(Container.DataItem,"BILL_NO")+ "&amp;Action=M"+"&amp;SRNO=" + DataBinder.Eval(Container.DataItem,"SRNO")%>'>Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="BILL_NO" HeaderText="Bill No">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSTRUMENT_TYPE" HeaderText="Instrument Type">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSTRUMENT_DATE" HeaderText="Instrument Date">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSTRUMENT_AMT" HeaderText="Amount">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMOUNT_RECEIVED" HeaderText="Total Amt Recieved"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SRNO" HeaderText="SRNO"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></P>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
				</TR>
				<TR>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>

