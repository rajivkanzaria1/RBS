<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Designation_Form.aspx.cs" Inherits="RBS.Designation_Form.Designation_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Designation Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{
		
		if(document.Form1.txtSDesc.value=="")
		{
		 alert("DESIGNATION CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else
		 {
		 document.Form1.btnSave.style.visibility = 'hidden';
		 alert("YOUR RECORD IS SAVED")
		 }
		 return;
		}
				
		function del2()
		 {
		  if(document.Form1.txtDesigCD.value=="")
		 {
		 alert("PLZ ENTER DESIGNATION CODE FIRST THEN CLICK ON MODIFY OR DELETE");
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
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtSDesc.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="260px" BackColor="White" ForeColor="DarkBlue"
								Font-Size="10pt" Font-Names="Verdana">RITES DESIGNATION DIRECTORY</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 309px; HEIGHT: 40px" cellSpacing="0" cellPadding="1" width="309"
								bgColor="#f0f8ff" border="1" align="center" borderColor="#b0c4de">
								<TR align="center">
									<TD align="center" colSpan="1" rowSpan="1"><asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"> Designation</asp:label></TD>
									<TD><asp:textbox id="txtSDesc" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											MaxLength="10" Height="20px" tabIndex="1" Width="211px"></asp:textbox></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkMagenta"
								Width="346px" Font-Bold="True">* To Add New Record Fill Values and Click on Save</asp:label>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Save" tabIndex="2" onclick="btnSave_Click"></asp:button><asp:button id="btnDelConfirm" runat="server" Font-Bold="True" Width="72px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Delete!!!" Visible="False" tabIndex="3" onclick="btnDelConfirm_Click"></asp:button>
						<asp:button id="btnCancel" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Width="72px" Font-Bold="True" Text="Cancel" tabIndex="4" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<P>&nbsp;</P>
						<P align="center"><asp:datagrid id="grdDesig" runat="server" Width="80%" Font-Size="8pt" Font-Names="Verdana" Height="96px"
								BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False" onprerender="grdDesig_PreRender">
								<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
									BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn FooterText="Delete">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"Designation_Form.aspx?R_DESIG_CD=" + DataBinder.Eval(Container.DataItem,"R_DESIG_CD") + "&amp;ACTION=D"%>' runat="server">Delete</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn FooterText="Edit">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"Designation_Form.aspx?R_DESIG_CD=" + DataBinder.Eval(Container.DataItem,"R_DESIG_CD") + "&amp;ACTION=E"%>' runat="server">Edit</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="R_DESIG_CD" HeaderText="Designation Code">
										<HeaderStyle Width="30%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="R_DESIGNATION" HeaderText="Designation">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<HeaderStyle Width="50%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
