<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendor_Search_Form.aspx.cs" Inherits="RBS.Vendor_Search_Form.Vendor_Search_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Vendor Search Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtVendCD.value)=="")
		{
		 alert("Vendor Code cannot be left blank");
		 event.returnValue=false;
		 }
		else if(trimAll(document.Form1.txtVendCD.value)!="" && IsNumeric(trimAll(document.Form1.txtVendCD.value)) == false)
		{
		  alert("Vendor Code cannot contains Characters!!!");
		  event.returnValue=false;
		}
		return;
		}
		
		function validate1()
		{
		if(trimAll(document.Form1.txtVendCD.value)=="" && IsNumeric(trimAll(document.Form1.txtVendCD.value)) == false && trimAll(document.Form1.txtVendName.value).length < 3 && trimAll(document.Form1.txtVendAdd.value).length < 4 && trimAll(document.Form1.txtVendCity.value)=="")
		{
		 alert("Enter Vendor Code /First 3 Characters of Vendor Name to search the Vendor/ 4 Characters of Vendor Address / First Few Characters Of Vendor City");
		 event.returnValue=false;
		 }
		else if(trimAll(document.Form1.txtVendCD.value)!="" && IsNumeric(trimAll(document.Form1.txtVendCD.value)) == false)
		{
		  alert("Vendor Code cannot contains Characters!!!");
		  event.returnValue=false;
		}
		else
		return;
		}
		function sFocus()
		 {
		 
		 document.Form1.txtVendCD.focus();
		 }
		 
		 
		
        </script>
</HEAD>
	<body onload="sFocus();">
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
								BackColor="White" ForeColor="DarkBlue">VENDOR/MANUFACTURER SEARCH</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px">
						<TABLE id="Table2" style="HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="0" cellPadding="1"
							width="85%" align="center" bgColor="#f0f8ff" border="1">
							<TR align="center">
								<TD style="WIDTH: 149px; HEIGHT: 26px"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="87px">Vendor Code</asp:label></TD>
								<TD style="HEIGHT: 26px"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="87px">Vendor Name</asp:label></TD>
								<TD style="HEIGHT: 26px"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="103px">Vendor Address</asp:label></TD>
								<TD style="HEIGHT: 26px">
									<asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="103px">Vendor City</asp:label></TD>
							</TR>
							<TR align="center">
								<TD style="WIDTH: 149px"><asp:textbox id="txtVendCD" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="103px" MaxLength="6" Height="20px"></asp:textbox></TD>
								<TD><asp:textbox id="txtVendName" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="90%" MaxLength="50" Height="20px"></asp:textbox></TD>
								<TD><asp:textbox id="txtVendAdd" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Width="90%" MaxLength="50" Height="20px"></asp:textbox></TD>
								<TD>
									<asp:textbox id="txtVendCity" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="90%" Height="20px" MaxLength="50"></asp:textbox></TD>
							</TR>
						</TABLE>
						<p align="center"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkMagenta">
								To Search a Vendor --> Enter Vendor Code or Part/Full  Vendor  Name and click on "Search Vendor" button</asp:label><br>
							<asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkMagenta">
								To Edit/Delete a Vendor --> Enter Vendor Code & Click on "Modify"/"Delete" button</asp:label></p>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center">&nbsp;<asp:button id="btnAdd" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="67px" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="67px" Text="Modify" onclick="btnMod_Click"></asp:button><asp:button id="btnDelete" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Width="67px" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnShow" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="102px" Text="Search Vendor" onclick="btnShow_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center">
									<P><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="384px">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></P>
								</TD>
							</TR>
						</TABLE>
						<DIV><TITTLE:CUSTOMDATAGRID id="grdVend" runat="server" Width="100%" Height="8px" HorizontalAlign="Left" PageSize="15"
								FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
								BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="350px"
								GridWidth="100%" onselectedindexchanged="grdVend_SelectedIndexChanged">
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

<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%" ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText">
</HeaderStyle>

<Columns>
<asp:TemplateColumn>
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemTemplate>
											<asp:HyperLink id="Hyperlink2" NavigateUrl='<%#"Vendor_Form.aspx?VEND_CD=" + DataBinder.Eval(Container.DataItem,"VEND_CD") + "&amp;Action=M"%>' Runat="server">Select</asp:HyperLink>
										
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="VEND_CD" HeaderText="Vendor Code">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="VEND_NAME" HeaderText="Vendor Name">
<HeaderStyle Width="25%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="VEND_ADD" HeaderText="Vendor Address">
<HeaderStyle Width="25%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="VEND_CITY_CD" HeaderText="Vendor City">
<HeaderStyle Width="15%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="VEND_CONT_NO" HeaderText="Vendor Tel No.">
<HeaderStyle Width="15%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="VEND_EMAIL" HeaderText="Email">
<HeaderStyle Width="10%">
</HeaderStyle>
</asp:BoundColumn>
</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
			</TABLE>
			<DIV>&nbsp;</DIV>
		</form>
	</body>
</HTML>
