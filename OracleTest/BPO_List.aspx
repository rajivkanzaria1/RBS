<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BPO_List.aspx.cs" Inherits="RBS.BPO_List.BPO_List" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BPO List Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtBPOCD.value)=="")
		{
		 alert("BPO CODE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else 
		return;
		}
		
		function validate1()
		{
		if(trimAll(document.Form1.txtBPOCD.value)=="" && trimAll(document.Form1.txtBPOName.value).length < 3 && trimAll(document.Form1.txtBPORailways.value)=="" && trimAll(document.Form1.txtCity.value)=="" && trimAll(document.Form1.txtSAPCustCD.value)=="" && trimAll(document.Form1.txtGSTIN_NO.value)=="")
		{
		 alert("ENTER BPO CD OR ATLEAST FIRST 3 CHARACTERS OF BPO NAME OR BPO RAILWAYS OR FIRST FEW CHARACTERS OF CITY OR SAP CUSTOMER CODE OR GSTIN NO. TO SEARCH RECORDS");
		 event.returnValue=false;
		 }
		 else
		 return;	
		}
		function sFocus()
		 {
		  document.Form1.txtBPOCD.focus();
		 }
		
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload=" sFocus();">
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
								BackColor="White" ForeColor="DarkBlue">BILL PAYING OFFICER</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 28px">
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 90%; HEIGHT: 56px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 17.18%" align="left"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">BPO Code</asp:label></TD>
									<TD style="WIDTH: 19.94%"><asp:textbox id="txtBPOCD" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="80%" Height="20px" MaxLength="5"></asp:textbox></TD>
									<TD style="WIDTH: 13.58%"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">BPO Name</asp:label></TD>
									<TD style="WIDTH: 30%"><asp:textbox id="txtBPOName" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="80%" Height="20px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 17.18%" align="left"><asp:label id="Label22" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">BPO Railways Code / Abbreviated Name Of BPO </asp:label></TD>
									<TD style="WIDTH: 19.94%"><asp:textbox id="txtBPORailways" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="80%" Height="20px" MaxLength="12"></asp:textbox></TD>
									<TD style="WIDTH: 13.58%"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">City</asp:label></TD>
									<TD style="WIDTH: 30%"><asp:textbox id="txtCity" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="80%" Height="20px" MaxLength="12"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 17.18%" align="left"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">Sap Customer Code</asp:label></TD>
									<TD style="WIDTH: 19.94%"><asp:textbox id="txtSAPCustCD" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="80%" Height="20px" MaxLength="10"></asp:textbox></TD>
									<TD style="WIDTH: 13.58%">
										<asp:label id="Label9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="100%">GSTIN NO.</asp:label></TD>
									<TD style="WIDTH: 30%">
										<asp:textbox id="txtGSTIN_NO" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="80%" MaxLength="15" Height="20px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkMagenta" Width="100%">
								To Edit/Delete a BPO --> Enter BPO Code & Click on "Modify"/"Delete" button</asp:label><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkMagenta" Width="100%">
								To Search a BPO --> Enter BPO Code or BPO Name or  BPO Railways or City and click on "Search BPO" button</asp:label></P>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center"><asp:button id="btnAdd" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="67px" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="67px" Text="Modify" onclick="btnMod_Click"></asp:button><asp:button id="btnDelete" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Width="67px" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnShow" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="85px" Text="Search BPO" onclick="btnShow_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
							</TR>
							<TR>
								<TD align="center">
									<DIV id="repdiv" style="Z-INDEX: 101; LEFT: 8px; OVERFLOW: scroll; WIDTH: 100%; POSITION: absolute; TOP: 250px; HEIGHT: 320px"
										runat="server" align="center">
										<asp:datagrid id="grdBPO" runat="server" BackColor="White" Font-Size="8pt" Font-Names="Verdana"
											Width="100%" Height="100px" CellPadding="0" BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False"
											HorizontalAlign="Center">
											<AlternatingItemStyle Font-Names="Verdana" BackColor="#CCCCFF"></AlternatingItemStyle>
											<ItemStyle Font-Names="Verdana" HorizontalAlign="Center"></ItemStyle>
											<HeaderStyle Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" Height="30px" ForeColor="DarkBlue"
												VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="BPO Code">
													<HeaderStyle Width="5%"></HeaderStyle>
													<ItemTemplate>
														<asp:HyperLink id=Hyperlink2 Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BPO_CD")%>' NavigateUrl='<%#"Bill_Paying_Officer_Form.aspx?BPO_CD=" + DataBinder.Eval(Container.DataItem,"BPO_CD") + "&amp;Action=E"%>'>Select</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="BPO_CD" HeaderText="BPO Code">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="BPO_NAME" HeaderText="BPO Name">
													<HeaderStyle Width="30%"></HeaderStyle>
													<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="BPO_RLY" HeaderText="BPO Rly. CD/Abb.Name Of BPO">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="BPO_ADD" HeaderText="BPO Address">
													<HeaderStyle Width="30%"></HeaderStyle>
													<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="GSTIN_NO" HeaderText="GSTIN NO.">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="AUDESC" HeaderText="AU">
													<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid></DIV>
									<asp:label id="Label4" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="384px" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
