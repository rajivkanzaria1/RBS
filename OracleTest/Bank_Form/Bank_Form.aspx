<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bank_Form.aspx.cs" Inherits="RBS.Bank_Form.Bank_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Bank_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		
		if(document.Form1.txtBankName.value=="")
		{
		 alert("BANK NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtFMISBCD.value!="" && IsNumeric(document.Form1.txtFMISBCD.value) == false)
		{
		 alert("FMIS BANK CODE CANTAINS INVALID CHARACTERS!!!");
		 event.returnValue=false;
		 }
		 else
		 {
		 document.Form1.btnSave.style.visibility = 'hidden';
		 }
		 return;
		 
		}
		
		function del2()
		 {
		  if(document.Form1.txtBankCD.value=="")
		 {
		 alert("PLZ ENTER BANK CODE FIRST THEN CLICK ON MODIFY OR DELETE");
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
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtBankName.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="134px" BackColor="White" ForeColor="DarkBlue"
								Font-Size="10pt" Font-Names="Verdana">BANKS DIRECTORY</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="707" bgColor="#f0f8ff" border="0"
								style="WIDTH: 707px; HEIGHT: 40px">
								<TR>
									<TD style="WIDTH: 15%"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Bank Name</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:textbox id="txtBankName" tabIndex="1" runat="server" Width="95%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" MaxLength="30" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 15%"><asp:label id="lblFBankCD" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana">FMIS Bank CD</asp:label></TD>
									<TD style="WIDTH: 20%"><asp:textbox id="txtFMISBCD" tabIndex="2" runat="server" Width="60%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" MaxLength="4" Height="20px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* To Add New Record Fill Values and Click on Save</asp:label><asp:label id="Label5" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* To Search a Bank Enter First Few Characters Of Bank Name  or FMIS Bank Code and Click on Search.</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" tabIndex="3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelConfirm" tabIndex="4" runat="server" Font-Bold="True" Width="95px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Delete!!!" Visible="False" onclick="btnDelConfirm_Click"></asp:button><asp:button id="btnSearch" tabIndex="5" runat="server" Font-Bold="True" Width="65px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button><asp:button id="btnCancel" tabIndex="6" runat="server" Font-Bold="True" Width="75px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<DIV><TITTLE:CUSTOMDATAGRID id="grdBank" runat="server" Height="8px" Width="100%" GridWidth="100%" GridHeight="360px"
								FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
								CellPadding="2" FreezeRows="0" BorderColor="DarkBlue" PageSize="15" AutoGenerateColumns="False" onprerender="btnSearch_Click">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
									CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn FooterText="Delete">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"Bank_Form.aspx?BANK_CD=" + DataBinder.Eval(Container.DataItem,"BANK_CD") + "&amp;ACTION=D"%>' runat="server">Delete</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn FooterText="Edit">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"Bank_Form.aspx?BANK_CD=" + DataBinder.Eval(Container.DataItem,"BANK_CD") + "&amp;ACTION=E"%>' runat="server">Edit</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="BANK_CD" HeaderText="Bank Code">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BANK_NAME" HeaderText="Bank Name">
										<HeaderStyle Width="50%"></HeaderStyle>
										<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FMIS_BANK_CD" HeaderText="FMIS Bank Code">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
