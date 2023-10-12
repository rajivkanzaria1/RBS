<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Laboratory_Search_Form.aspx.cs" Inherits="RBS.Laboratory_Search_Form.Laboratory_Search_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Laboratory_Search_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtLabID.value)=="")
		{
		 alert("Lab ID cannot be left blank");
		 event.returnValue=false;
		 }
		else 
		return;
		}
		
		function validate1()
		{
		if(trimAll(document.Form1.txtLabID.value)=="" && IsNumeric(trimAll(document.Form1.txtLabID.value)) == false && trimAll(document.Form1.txtLabName.value).length < 3 && trimAll(document.Form1.txtLabAdd.value).length < 4 && trimAll(document.Form1.txtLabCity.value)=="")
		{
		 alert("Enter Lab ID /First 3 Characters of Lab Name to search the Laboratory/ 4 Characters of Lab Address / First Few Characters Of Lab City");
		 event.returnValue=false;
		 }
		else if(trimAll(document.Form1.txtLabID.value)!="" && IsNumeric(trimAll(document.Form1.txtLabID.value)) == false)
		{
		  alert("Lab ID cannot contains Characters!!!");
		  event.returnValue=false;
		}
		else
		return;
		}
		
		 
		 
		
        </script>
	</HEAD>
	<body>
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
						<P><asp:label id="Label1" runat="server" ForeColor="DarkBlue" BackColor="White" Font-Bold="True"
								Font-Size="10pt" Font-Names="Verdana">LABORATORY SEARCH</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px">
						<TABLE id="Table2" style="HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="0" cellPadding="1"
							width="85%" align="center" bgColor="#f0f8ff" border="1">
							<TR align="center">
								<TD style="WIDTH: 149px; HEIGHT: 26px"><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="87px">Lab ID</asp:label></TD>
								<TD style="HEIGHT: 26px"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="87px">Lab Name</asp:label></TD>
								<TD style="HEIGHT: 26px"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="103px">Lab Address</asp:label></TD>
								<TD style="HEIGHT: 26px"><asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="103px">Lab City</asp:label></TD>
							</TR>
							<TR align="center">
								<TD style="WIDTH: 149px"><asp:textbox id="txtLabID" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Width="103px" Height="20px" MaxLength="6"></asp:textbox></TD>
								<TD><asp:textbox id="txtLabName" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="90%" Height="20px" MaxLength="50"></asp:textbox></TD>
								<TD><asp:textbox id="txtLabAdd" tabIndex="3" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="90%" Height="20px" MaxLength="50"></asp:textbox></TD>
								<TD><asp:textbox id="txtLabCity" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="90%" Height="20px" MaxLength="50"></asp:textbox></TD>
							</TR>
						</TABLE>
						<p align="center"><asp:label id="Label3" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">
								To Search a Lab --> Enter Lab ID or Part/Full  Lab  Name and click on "Search Lab" button</asp:label><br>
							<asp:label id="Label8" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">
								To Edit a Lab --> Enter Lab Code & Click on "Modify" button</asp:label></p>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center">&nbsp;<asp:button id="btnAdd" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="67px" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="67px" Text="Modify" onclick="btnMod_Click"></asp:button><asp:button id="btnShow" tabIndex="8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="102px" Text="Search Lab" onclick="btnShow_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center">
									<P><asp:label id="Label4" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="384px">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></P>
								</TD>
							</TR>
						</TABLE>
						<DIV><TITTLE:CUSTOMDATAGRID id="grdLab" runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="350px"
								AutoGenerateColumns="False" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" BorderColor="DarkBlue"
								AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" CellPadding="2" FreezeRows="0" PageSize="15"
								HorizontalAlign="Left">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%"
									ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="Hyperlink2" NavigateUrl='<%#"Laboratory_Master_Form.aspx?LAB_ID=" + DataBinder.Eval(Container.DataItem,"LAB_ID") + "&amp;Action=M"%>' Runat="server">Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="LAB_ID" HeaderText="Lab ID">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LAB_NAME" HeaderText="Lab Name">
										<HeaderStyle Width="35%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LAB_ADDRESS" HeaderText="Lab Address">
										<HeaderStyle Width="35%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CITY" HeaderText="Lab City">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
