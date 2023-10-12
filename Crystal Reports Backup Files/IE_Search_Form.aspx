<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_Search_Form.aspx.cs" Inherits="RBS.IE_Search_Form.IE_Search_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>IE Search Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if (trimAll(document.Form1.txtIECD.value)=="")
		{
		 alert("IE CODE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(isNaN(parseInt(document.Form1.txtIECD.value)))
		 {
		 alert("IE CODE CANNOT CONTAIN ALBHABETS");
		 event.returnValue=false;
		 }
		else 
		return;
		}
		
		function validate1()
		{
		if(trimAll(document.Form1.txtIECD.value)=="" && trimAll(document.Form1.txtIELName.value)=="" && trimAll(document.Form1.txtIESName.value)=="" && trimAll(document.Form1.lstCOCD.value)=="")
		{
		 alert("ENTER IE CD OR IE FULL NAME OR SHORT NAME OR CONTROLLING OFFICER TO SEARCH RECORDS");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtIECD.value)!="" && isNaN(parseInt(document.Form1.txtIECD.value)))
		 {
		 alert("IE CODE CANNOT CONTAIN ALBHABETS");
		 event.returnValue=false;
		 }
		else 
		return;
		}
		
		
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtIECD.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 23px" align="center">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue">INSPECTION ENGINEER'S SEARCH</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px">
						<P align="center">
							<TABLE id="Table2" style="HEIGHT: 31px" cellSpacing="0" cellPadding="1" width="80%" bgColor="#f0f8ff"
								border="1" borderColor="#b0c4de">
								<TR align="center">
									<TD style="WIDTH: 15%"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="56px">IE Code</asp:label></TD>
									<TD style="WIDTH: 20%"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="105px">IE Short Name</asp:label></TD>
									<TD style="WIDTH: 25%"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="87px">IE Full Name</asp:label></TD>
									<TD style="WIDTH: 40%">
										<asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="143px">Controlling Officer</asp:label></TD>
								</TR>
								<TR align="center">
									<TD style="WIDTH: 15%"><asp:textbox id="txtIECD" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="75px" Height="20px" MaxLength="8" tabIndex="1"></asp:textbox></TD>
									<TD style="WIDTH: 20%"><asp:textbox id="txtIESName" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="93px" Height="20px" MaxLength="50" tabIndex="2"></asp:textbox></TD>
									<TD style="WIDTH: 25%"><asp:textbox id="txtIELName" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="200px" Height="20px" MaxLength="50" tabIndex="3"></asp:textbox></TD>
									<TD style="WIDTH: 40%">
										<asp:dropdownlist id="lstCOCD" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="100%" Height="25px"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
							<asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkMagenta" Width="761px">
								To Edit/Delete a IE --> Enter IE Code & Click on "Modify"/"Delete" button</asp:label><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkMagenta" Width="758px">
								To Search a IE --> Enter IE Code or IE Full/Short Name or Controlling Officer  Name and click on "Search IE" button</asp:label></P>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center"><asp:button id="btnAdd" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="67px" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="67px" Text="Modify" onclick="btnMod_Click"></asp:button><asp:button id="btnDelete" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Width="67px" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnShow" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="102px" Text="Search IE" onclick="btnShow_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
							</TR>
							<TR>
								<TD align="center"><asp:datagrid id="grdVend" runat="server" Font-Names="Verdana" Font-Size="8pt" BackColor="White"
										Width="100%" Height="100px" PageSize="1" CellPadding="0" BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False">
										<SelectedItemStyle Font-Names="Verdana"></SelectedItemStyle>
										<EditItemStyle Font-Names="Verdana" Wrap="False"></EditItemStyle>
										<AlternatingItemStyle Font-Names="Verdana" BackColor="#CCCCFF"></AlternatingItemStyle>
										<ItemStyle Font-Names="Verdana" HorizontalAlign="Center"></ItemStyle>
										<HeaderStyle Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center" ForeColor="DarkBlue"
											VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
										<Columns>
											<asp:HyperLinkColumn Text="Select" DataNavigateUrlField="IE_CD" DataNavigateUrlFormatString="IE_Search_Form.aspx?IE_CD={0}"
												NavigateUrl="IE_Search_Form.aspx">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:HyperLinkColumn>
											<asp:BoundColumn DataField="IE_CD" HeaderText="IE Code">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IE_NAME" HeaderText="IE Full Name">
												<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IE_SNAME" HeaderText="IE Short Name">
												<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IE_EMP_NO" HeaderText="Employee No">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IE_SEAL_NO" HeaderText="IE Seal No.">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IE_CITY_CD" HeaderText="IE City">
												<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IE_REGION" HeaderText="IE Region">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
									<P><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="384px">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
