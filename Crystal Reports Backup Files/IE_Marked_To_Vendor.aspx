<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_Marked_To_Vendor.aspx.cs" Inherits="RBS.IE_Marked_To_Vendor.IE_Marked_To_Vendor" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IE_Marked_To_Vendor</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate1()
		{
		 
		 
		 if(trimAll(document.Form1.txtVend.value)=="")
		{
		 alert("ENTER VENDOR CODE OR 1ST Few CHARACTERS OF VENDOR NAME AND THEN CLICK ON SELECT VENDOR BUTTON");
		 event.returnValue=false;
		 }
		  else
		 return;

		}
		
		
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD>
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 30px" align="center">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
									BackColor="White" Width="204px" Font-Bold="True">IE MARKED TO VENDOR</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 56px" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="1" width="361" bgColor="#f0f8ff" border="1">
								<TR align="center">
									<TD style="WIDTH: 3.7%; HEIGHT: 28px" vAlign="middle" align="center"><asp:label id="Label16" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Vendor</asp:label></TD>
									<TD style="WIDTH: 30.97%; HEIGHT: 28px" vAlign="middle" align="left"><asp:textbox id="txtVend" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="15%" Height="20px"></asp:textbox><asp:button id="btnFCList" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="20%" Font-Bold="True" ToolTip="Enter the Vendor Code or 1st few letters of Vendor then click on select Vendor Button"
											Text="Select Vendor"></asp:button><asp:dropdownlist onkeypress="return keySort(ddlVender);" id="ddlVender" tabIndex="3" runat="server"
											Font-Names="Verdana" Font-Size="7pt" ForeColor="DarkBlue" Width="99%" Height="25px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center"><asp:button id="btnSearch" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Width="67px" Font-Bold="True" Text="Search"></asp:button><asp:button id="btnAdd" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								Width="94px" Font-Bold="True" Text="Add New IE"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center"><TITTLE:CUSTOMDATAGRID id="DgIEV1" runat="server" Width="100%" Height="8px" AutoGenerateColumns="False"
								PageSize="15" BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
								BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="200px" GridWidth="100%">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
									CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="IE_NAME" HeaderText="IE">
										<HeaderStyle Width="50%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IE_DEPT" HeaderText="Descipline"></asp:BoundColumn>
									<asp:BoundColumn DataField="DATE_FR" HeaderText="From">
										<HeaderStyle Width="25%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATE_TO" HeaderText="To.">
										<HeaderStyle Width="25%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SNO" HeaderText="SNO">
										<HeaderStyle Width="15%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"IE_Marked_To_Vendor.aspx?VEND_CD=" + DataBinder.Eval(Container.DataItem,"VEND_CD")+ "&amp;SNO=" + DataBinder.Eval(Container.DataItem,"SNO")+ "&amp;IE_DEPT=" + DataBinder.Eval(Container.DataItem,"IE_DEPARTMENT")+ "&amp;IE_CD=" + DataBinder.Eval(Container.DataItem,"IE_CD")+ "&amp;IE_NAME=" + DataBinder.Eval(Container.DataItem,"IE_NAME")+ "&amp;DT_FR=" + DataBinder.Eval(Container.DataItem,"DATE_FR")%>'>Replace</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="VEND_CD" HeaderText="Vendor"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IE_CD" HeaderText="IE_CD"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IE_DEPARTMENT" HeaderText="Descipline"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID>
							<asp:label id="lblNoRecFound" runat="server" Font-Bold="True" Width="184px" ForeColor="OrangeRed"
								Font-Size="8pt" Font-Names="Verdana" Visible="False">No Record Found!!!</asp:label></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:label id="lblHeading" runat="server" Font-Bold="True" Width="184px" ForeColor="OrangeRed"
								Font-Size="8pt" Font-Names="Verdana" Visible="False" Font-Underline="True">Replace/Add IE</asp:label></TD>
					</TR>
					<asp:panel id="Panel_2" runat="server" Width="100%" Height="1px" Visible="False">
						<TR>
							<TD align="left">
								<asp:label id="lblREPIE" runat="server" Font-Bold="True" Width="65%" ForeColor="OrangeRed"
									Font-Size="8pt" Font-Names="Verdana"></asp:label>
								<asp:label id="lblREBDTFR" runat="server" Font-Bold="True" Width="30%" ForeColor="OrangeRed"
									Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
						</TR>
					</asp:panel>
					<TR>
						<TD align="center"><asp:panel id="Panel_1" runat="server" Width="100%" Height="1px" Visible="False">
								<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 56px" borderColor="#b0c4de" cellSpacing="0"
									cellPadding="1" width="361" bgColor="#f0f8ff" border="1">
									<TR>
										<TD style="WIDTH: 3.7%; HEIGHT: 28px" vAlign="middle" align="center">
											<asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">IE</asp:label></TD>
										<TD style="WIDTH: 19.71%; HEIGHT: 28px" vAlign="middle" align="left">
											<asp:dropdownlist id="lstIE" tabIndex="6" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
										<TD style="WIDTH: 3.7%; HEIGHT: 28px" vAlign="middle" align="center">
											<asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Period</asp:label></TD>
										<TD style="FONT-SIZE: 8pt; WIDTH: 30%; COLOR: darkblue; FONT-FAMILY: Verdana">From
											<asp:textbox id="txtDtFr" onblur="check_date(txtDtFr);" tabIndex="7" runat="server" Width="88px"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox>&nbsp;&nbsp;&nbsp;(Enter 
											Date in [dd/mm/yyyy] Format)</TD>
									</TR>
									<TR>
										<TD align="center" colSpan="4">
											<asp:button id="btnSave" tabIndex="8" runat="server" Font-Bold="True" Width="67px" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Text="Save"></asp:button>
											<asp:button id="btnCancel" tabIndex="9" runat="server" Font-Bold="True" Width="67px" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Text="Cancel"></asp:button></TD>
									</TR>
								</TABLE>
							</asp:panel></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
