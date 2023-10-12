<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reciepts_Form.aspx.cs" Inherits="RBS.Reciepts_Form.Reciepts_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Reciepts Form</title>
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
		if(parseInt(document.Form1.txtIAmt.value)<parseInt(document.Form1.txtAmtRel.value))
		 {
		 alert("AMOUNT REALISED CANNOT BE GREATER THEN INSTRUMENT AMOUNT");
		 event.returnValue=false;
		 }
		
		else 
		return;
		}
		function del()
		{
		var d=confirm("Click OK to Confirm Delete!!!");
		if(d==true)
		event.returnValue=true;
		else
		event.returnValue=false;
		}
		
        </script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue" Width="196px">RECIEPT FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" style="WIDTH: 40%; HEIGHT: 32px" cellSpacing="1" cellPadding="1" bgColor="#f0f8ff"
							border="0">
							<TR>
								<TD style="WIDTH: 50%"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%"> Total Amt Received</asp:label></TD>
								<TD style="WIDTH: 50%"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="16px">Rs.</asp:label><asp:label id="txtAmtRec" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="80%"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table4" style="WIDTH: 50%; HEIGHT: 30px" cellSpacing="0" cellPadding="0" width="445"
							bgColor="aliceblue" border="0">
							<TR>
								<TD style="WIDTH: 15%; HEIGHT: 9px" align="left" colSpan="1" rowSpan="1"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Bill No.</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 9px">
									<P><asp:label id="txtBillNo" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="100%">Bill No </asp:label></P>
								</TD>
								<TD style="WIDTH: 25%; HEIGHT: 9px"><asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%"> Bill Amount</asp:label></TD>
								<TD style="WIDTH: 30%; HEIGHT: 9px">
									<P>
										<asp:label id="Label11" runat="server" Width="16px" ForeColor="OrangeRed" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana">Rs.</asp:label><asp:label id="txtBillAmt" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="80%"></asp:label></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:panel id="Panel" runat="server" Visible="False" Height="140px">
							<P align="center">
								<asp:label id="Label15" runat="server" Width="196px" ForeColor="DarkBlue" BackColor="White"
									Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">RECIEPT DETAILS</asp:label></P>
							<P align="center">
								<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="300" bgColor="#f0f8ff" border="0">
									<TR>
										<TD style="HEIGHT: 23px">
											<asp:label id="Label14" runat="server" Width="120px" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana">Instrument Type</asp:label></TD>
										<TD style="HEIGHT: 23px">
											<asp:dropdownlist id="lstIType" tabIndex="8" runat="server" Width="143px" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD>
											<asp:label id="Label3" runat="server" Width="120px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Instrument Date</asp:label></TD>
										<TD>
											<asp:textbox id="txtIDT" onblur="check_date(txtIDT);" tabIndex="2" runat="server" Width="139px"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>
											<asp:label id="Label4" runat="server" Width="120px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Instrument No.</asp:label></TD>
										<TD>
											<asp:textbox id="txtINO" tabIndex="2" runat="server" Width="139px" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="20px" MaxLength="6"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>
											<asp:label id="Label5" runat="server" Width="120px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Bank</asp:label></TD>
										<TD>
											<asp:textbox id="txtBank" tabIndex="2" runat="server" Width="139px" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="20px" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>
											<asp:label id="Label7" runat="server" Width="135px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Instrument Amount</asp:label></TD>
										<TD>
											<asp:textbox id="txtIAmt" tabIndex="2" runat="server" Width="139px" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="20px" MaxLength="14"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>
											<asp:label id="Label8" runat="server" Width="120px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Amount Released</asp:label></TD>
										<TD>
											<asp:textbox id="txtAmtRel" onblur="validate();" tabIndex="2" runat="server" Width="139px" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="14"></asp:textbox></TD>
									</TR>
									<TR>
										<TD align="right">
											<asp:button id="btnSave1" tabIndex="10" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave1_Click"></asp:button></TD>
										<TD>
											<asp:button id="btnDel2" tabIndex="11" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Text="Delete" onclick="btnDel2_Click"></asp:button>
											<asp:button id="btnAdd" tabIndex="10" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Text="Add New" onclick="btnAdd_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</P>
							<P align="center">&nbsp;</P>
							<P align="center">
								<asp:datagrid id="grdInsDt" runat="server" Width="80%" Font-Size="8pt" Font-Names="Verdana" Height="56px"
									Visible="False" BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False">
									<AlternatingItemStyle Width="500px" BackColor="#CCCCFF"></AlternatingItemStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
										BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn HeaderText="Bill No.">
											<HeaderStyle Width="15%"></HeaderStyle>
											<ItemTemplate>
												<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl='<%#"Reciepts_Form.aspx?BILL_NO=" + DataBinder.Eval(Container.DataItem,"BILL_NO") + "&amp;ACTION="+Action+ "&amp;SRNO=" + DataBinder.Eval(Container.DataItem,"SRNO")%>' Text='<%# DataBinder.Eval(Container.DataItem,"BILL_NO")%>'>HyperLink</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="INSTRUMENT_TYPE" HeaderText="Instrument Type">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="INSTRUMENT_DATE" HeaderText="Instrument Date" DataFormatString="{0:dd/MM/yyyy}">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="INSTRUMENT_NO" HeaderText="Instrument No.">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BANK" HeaderText="Bank">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="INSTRUMENT_AMT" HeaderText="Instrument Amount">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AMT_REALISED" HeaderText="Amount Released">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
								</asp:datagrid></P>
							<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							</P>
						</asp:panel></TD>
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
