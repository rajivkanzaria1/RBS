<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UOM_Form.aspx.cs" Inherits="RBS.UOM_Form.UOM_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UOM Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{
		if(document.Form1.txtSDesc.value=="")
		 {
		 alert("SHORT DESCRIPTION CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 
		else if(document.Form1.txtLDesc.value=="")
		 {
		 alert("LONG DESCRIPTION CANNOT BE LEFT BLANK");
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
		  if(document.Form1.txtUOMCD.value=="")
		 {
		 alert("PLZ ENTER UNIT OF MEASUREMENT CODE FIRST THEN CLICK ON MODIFY OR DELETE");
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
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="181px" Font-Bold="True">UNIT OF MEASUREMENTS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 647px; HEIGHT: 72px" cellSpacing="0" cellPadding="1" width="647"
								border="1" bgColor="#f0f8ff" borderColor="#b0c4de">
								<TR align="center">
									<TD>
										<asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">UOM Short Description</asp:label></TD>
									<TD>
										<asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">UOM Long Description</asp:label></TD>
									<TD>
										<asp:label id="Label5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Division Factor</asp:label></TD>
								</TR>
								<TR align="center">
									<TD>
										<asp:textbox id="txtSDesc" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											MaxLength="10" Height="20px" Width="113px"></asp:textbox></TD>
									<TD>
										<asp:textbox id="txtLDesc" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Height="20px" MaxLength="25" Width="269px"></asp:textbox></TD>
									<TD>
										<asp:textbox id="txtMULFactor" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Height="20px" tabIndex="3" Width="52px">1</asp:textbox></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="Label6" runat="server" Font-Bold="True" Width="346px" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* To Add New Record Fill Values and Click on Save</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD align="center" style="HEIGHT: 21px">
						<asp:button id="btnSave" tabIndex="4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button>
						<asp:button id="btnSearch" tabIndex="4" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button>
						<asp:button id="btnDelConfirm" tabIndex="5" runat="server" Font-Bold="True" Width="85px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Delete!!!" Visible="False" onclick="btnDelConfirm_Click"></asp:button>
						<asp:button id="btnCancel" tabIndex="6" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" height="20">
					</TD>
				</TR>
				<TR>
					<TD align="center" height="20"></TD>
				</TR>
			</TABLE>
			<DIV id="repdiv" style="Z-INDEX: 101; LEFT: 18px; OVERFLOW: scroll; WIDTH: 100%; POSITION: absolute; TOP: 228px; HEIGHT: 385px"
				runat="server" align="center"><asp:datagrid id="grdUOM" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" BorderColor="DarkBlue"
					BorderStyle="Groove" AutoGenerateColumns="False" PageSize="15" onprerender="btnSearch_Click">
					<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
						VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn FooterText="Delete">
							<HeaderStyle Width="10%"></HeaderStyle>
							<ItemTemplate>
								<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"UOM_Form.aspx?UOM_CD=" + DataBinder.Eval(Container.DataItem,"UOM_CD") + "&amp;ACTION=D"%>' runat="server">Delete</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn FooterText="Edit">
							<HeaderStyle Width="10%"></HeaderStyle>
							<ItemTemplate>
								<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"UOM_Form.aspx?UOM_CD=" + DataBinder.Eval(Container.DataItem,"UOM_CD") + "&amp;ACTION=E"%>' runat="server">Edit</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="UOM_CD" HeaderText="UOM Code"></asp:BoundColumn>
						<asp:BoundColumn DataField="UOM_S_DESC" HeaderText="UOM Short Desciption">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="UOM_L_DESC" HeaderText="UOM Long Description">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="UOM_FACTOR" HeaderText="Division Factor"></asp:BoundColumn>
					</Columns>
					<PagerStyle Mode="NumericPages"></PagerStyle>
				</asp:datagrid></DIV>
		</form>
	</body>
</HTML>
