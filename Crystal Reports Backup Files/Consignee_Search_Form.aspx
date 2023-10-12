<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consignee_Search_Form.aspx.cs" Inherits="RBS.Consignee_Search_Form.Consignee_Search_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Consignee Search Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtConCD.value)=="")
		{
		 alert("CONSIGNEE CODE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(isNaN(parseInt(document.Form1.txtConCD.value)))
		 {
		 alert("CONSIGNEE CODE CANNOT CONTAIN ALBHABETS");
		 event.returnValue=false;
		 }
		else 
		return;
		}
		
		function validate1()
		{
		if(trimAll(document.Form1.txtConCD.value)=="" && trimAll(document.Form1.txtConName.value)=="" && trimAll(document.Form1.txtCFirm.value)=="" && trimAll(document.Form1.txtSAPCustCD.value)=="" && trimAll(document.Form1.txtGSTIN_NO.value)=="")
		{
		 alert("CONSIGNEE CODE,DESIGNATION, FIRM OR SAP CUSTOMER CD OR GSTIN NO. CANNOT BE LEFT BLANK FOR SHOWING RECORDS ");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtConCD.value)!="" && isNaN(parseInt(document.Form1.txtConCD.value)))
		 {
		 alert("CONSIGNEE CODE CANNOT CONTAIN ALBHABETS");
		 event.returnValue=false;
		 }
		else 
		return;
		}
		
		function abc()
		 {
		 
		 document.Form1.txtConCD.focus();
		 }
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="abc();">
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
								BackColor="White" ForeColor="DarkBlue">CONSIGNEE/PURCHASER MASTER</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 28px">
						<P align="center">
							<TABLE id="Table2" style="HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1" cellPadding="1"
								width="80%" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 11.5%"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">Consignee Code</asp:label></TD>
									<TD style="WIDTH: 13.31%" align="left"><asp:textbox id="txtConCD" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="80%" MaxLength="8" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 11.38%"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">Consignee Designation</asp:label></TD>
									<TD style="WIDTH: 17%" align="left" colSpan="1" rowSpan="1"><asp:textbox id="txtConName" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="80%" MaxLength="20" Height="20px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 11.5%"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%"> Railway/Purchaser</asp:label></TD>
									<TD style="WIDTH: 13.31%" align="left"><asp:textbox id="txtCFirm" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="80%" MaxLength="40" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 11.38%"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">City</asp:label></TD>
									<TD style="WIDTH: 17%" align="left"><asp:textbox id="txtCity" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="80%" MaxLength="40" Height="20px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 11.5%"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">Sap Customer Code</asp:label></TD>
									<TD style="WIDTH: 13.31%" align="left"><asp:textbox id="txtSAPCustCD" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="80%" MaxLength="10" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 11.38%">
										<asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="100%">GSTIN NO.</asp:label></TD>
									<TD style="WIDTH: 17%" align="left">
										<asp:textbox id="txtGSTIN_NO" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="80%" Height="20px" MaxLength="15"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkMagenta" Width="100%">
								To Edit/Delete a Consignee --> Enter Consignee Code & Click on "Modify"/"Delete" Button.</asp:label><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkMagenta" Width="100%">To Search a Consignee--> Enter Consignee Code  or Designation or Railway/Purchaser or City and Click on Search Consignee Button.</asp:label>
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD align="center"><asp:button id="btnAdd" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="67px" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="67px" Text="Modify" onclick="btnMod_Click"></asp:button><asp:button id="btnDelete" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
											Font-Bold="True" ForeColor="DarkBlue" Width="67px" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnShow" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="130px" Text="Search Consignee" onclick="btnShow_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center"></TD>
								</TR>
								<TR>
									<TD align="center"><asp:datagrid id="grdCON" runat="server" BackColor="White" Font-Size="8pt" Font-Names="Verdana"
											Width="100%" Height="100px" AutoGenerateColumns="False" BorderStyle="Groove" BorderColor="DarkBlue" CellPadding="0"
											PageSize="1">
											<SelectedItemStyle Font-Names="Verdana"></SelectedItemStyle>
											<EditItemStyle Font-Names="Verdana" Wrap="False"></EditItemStyle>
											<AlternatingItemStyle Font-Names="Verdana" BackColor="#CCCCFF"></AlternatingItemStyle>
											<ItemStyle Font-Names="Verdana" HorizontalAlign="Center"></ItemStyle>
											<HeaderStyle Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
												VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
											<Columns>
												<asp:HyperLinkColumn Text="Select" DataNavigateUrlField="CONSIGNEE_CD" DataNavigateUrlFormatString="Consignee_Search_Form.aspx?CONSIGNEE_CD={0}"
													NavigateUrl="Consignee_Search_Form.aspx">
													<HeaderStyle Width="5%"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:BoundColumn DataField="CONSIGNEE_CD" HeaderText="Consignee Code"></asp:BoundColumn>
												<asp:BoundColumn DataField="CONSIGNEE_NAME" HeaderText="Consignee Designation/Department">
													<HeaderStyle Width="15%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="DESIG_DESC" HeaderText="Description">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CONSIGNEE_FIRM" HeaderText="Consignee Firm">
													<HeaderStyle Width="20%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CONSIGNEE_CITY" HeaderText="Consignee City">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CONSIGNEE_ADD1" HeaderText="Consignee Address">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="GSTIN_NO" HeaderText="GSTIN No.">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid>
										<P><asp:label id="Label4" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Width="384px" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></P>
									</TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

