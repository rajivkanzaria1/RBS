<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchaser_Search_Form.aspx.cs" Inherits="RBS.Purchaser_Search_Form.Purchaser_Search_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Consignee Search Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{
		if(document.Form1.txtConCD.value=="")
		{
		 alert("PURCHASER CODE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else 
		return;
		}
		
		function validate1()
		{
		if(document.Form1.txtConCD.value=="" && document.Form1.txtPDesig.value==""&& document.Form1.txtPFirm.value=="" )
		{
		 alert("PURCHASER CODE,DESIG AND FIRM CANNOT BE LEFT BLANK FOR SHOWING RECORDS");
		 event.returnValue=false;
		 }
		else 
		return;
		}
		
		
        </script>
	</HEAD>
	<body bgColor="#ffffff">
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
						<P><asp:label id="Label1" runat="server" ForeColor="DarkBlue" BackColor="White" Font-Bold="True"
								Font-Size="10pt" Font-Names="Verdana">PURCHASER MASTER</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 28px">
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 40px" cellSpacing="1" cellPadding="1" width="313"
								bgColor="#f0f8ff" border="0">
								<TR>
									<TD style="WIDTH: 10%" align="right">&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="37px">Purchaser Code</asp:label></TD>
									<TD style="WIDTH: 10%"><asp:textbox id="txtConCD" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="100%" Height="25px" MaxLength="8"></asp:textbox></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="100%">Purchaser Designation</asp:label></TD>
									<TD style="WIDTH: 20%"><asp:textbox id="txtPDesig" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Width="100%" Height="25px" MaxLength="50"></asp:textbox></TD>
									<TD style="WIDTH: 15%">
										<asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">Purchaser Firm</asp:label></TD>
									<TD style="WIDTH: 30%">
										<asp:textbox id="txtPFirm" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" MaxLength="50" Height="25px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="Label3" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana" Width="100%">To Search a Purchaser->Enter Purchaser  Code or Designation or Firm and Click  on Search Purchaser Button</asp:label><asp:label id="Label8" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana" Width="100%">
								To Edit/Delete a Purchaser --> Enter Purchaser Code & Click on "Modify"/"Delete" button</asp:label></P>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center"><asp:button id="btnAdd" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="67px" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="67px" Text="Modify" onclick="btnMod_Click"></asp:button><asp:button id="btnDelete" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Width="67px" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnShow" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="130px" Text="Search Purchaser" onclick="btnShow_Click"></asp:button></TD>
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
											<asp:HyperLinkColumn Text="Select" DataNavigateUrlField="PURCHASER_CD" DataNavigateUrlFormatString="Purchaser_Search_Form.aspx?PURCHASER_CD={0}"
												NavigateUrl="Purchaser_Search_Form.aspx">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:HyperLinkColumn>
											<asp:BoundColumn DataField="PURCHASER_DESIG" HeaderText="Purchaser Designation">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PURCHASER_FIRM" HeaderText="Purchaser Firm">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PURCHASER_CITY" HeaderText="Purchaser City">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
									<P><asp:label id="Label4" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="384px" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

