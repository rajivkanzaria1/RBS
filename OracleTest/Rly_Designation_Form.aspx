<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rly_Designation_Form.aspx.cs" Inherits="RBS.Rly_Designation_Form.Rly_Designation_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Railway Designation Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{
		if(document.Form1.txtSDesc.value=="")
		{
		 alert("DESCRIPTION CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else
		 {
		 document.Form1.btnSave.style.visibility = 'hidden';
		 alert("YOUR RECORD IS SAVED");
		 }
		 return;
		}
				
		function del2()
		 {
		  if(document.Form1.txtDesigCD.value=="")
		 {
		 alert("PLZ ENTER RAILWAY DESIGNATION CODE FIRST THEN CLICK ON MODIFY OR DELETE");
		 event.returnValue=false;
		 }
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
</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtDesigCD.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 123px; TOP: 8px; LEFT: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" align="center">
						<P align="center">
							<asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="277px" Font-Bold="True">RAILWAYS DESIGNATION DIRECTORY</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; HEIGHT: 40px; BORDER-LEFT-STYLE: none"
								cellSpacing="0" cellPadding="1" width="70%" bgColor="#f0f8ff" border="1" borderColor="lightsteelblue">
								<TR align="center">
									<TD style="WIDTH: 158px; HEIGHT: 27px"><asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Designation Code</asp:label></TD>
									<TD style="HEIGHT: 27px"><asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"> Designation</asp:label></TD>
								</TR>
								<TR align="center">
									<TD style="WIDTH: 158px">
										<asp:textbox id="txtDesigCD" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
									<TD>
										<asp:textbox id="txtSDesc" tabIndex="2" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="40"></asp:textbox></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* To Add New Record Fill Values and Click on Save</asp:label>
							<asp:label id="Label5" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* To Search a RLY Designation Enter First Few Characters Of Code or Designation and Click on Search.</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Save" tabIndex="3" onclick="btnSave_Click"></asp:button><asp:button id="btnDelConfirm" runat="server" Font-Bold="True" Width="72px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Delete!!!" Visible="False" tabIndex="4" onclick="btnDelConfirm_Click"></asp:button>
						<asp:button id="btnSearch" tabIndex="5" runat="server" Font-Bold="True" Width="65px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button>
						<asp:button id="btnCancel" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Cancel" tabIndex="6" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center">
						<P>&nbsp;</P>
						<P align="center"><DIV><TITTLE:CUSTOMDATAGRID id="grdDesig" runat="server" Width="100%" Height="8px" HorizontalAlign="Left" PageSize="15"
									FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
									BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="220px" GridWidth="100%"
									 onprerender="btnSearch_Click">
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
<asp:TemplateColumn FooterText="Delete">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemTemplate>
												<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"Rly_Designation_Form.aspx?RLY_DESIG_CD=" + DataBinder.Eval(Container.DataItem,"RLY_DESIG_CD") + "&amp;ACTION=D"%>' runat="server">Delete</asp:HyperLink>
											
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn FooterText="Edit">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemTemplate>
												<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"Rly_Designation_Form.aspx?RLY_DESIG_CD=" + DataBinder.Eval(Container.DataItem,"RLY_DESIG_CD") + "&amp;ACTION=E"%>' runat="server">Edit</asp:HyperLink>
											
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="RLY_DESIG_CD" HeaderText="Designation Code">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="RLY_DESIG_DESC" HeaderText="Designation">
<HeaderStyle Width="60%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
</Columns>
								</TITTLE:CUSTOMDATAGRID></DIV>
						<P></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

