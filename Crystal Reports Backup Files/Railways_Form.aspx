<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Railways_Form.aspx.cs" Inherits="RBS.Railways_Form.Railways_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Railways Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{
		if(document.Form1.txtRlyCD.disabled==false && document.Form1.txtRlyCD.value=="")
		{
		 alert("RAILWAY CODE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else if(document.Form1.txtRailProUnit.value=="")
		{
		 alert("RAILWAYS/PRODUCTION UNIT CANNOT BE LEFT BLANK");
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
		  if(document.Form1.txtRlyCD.value=="")
		 {
		 alert("PLZ ENTER RAILWAYS CODE FIRST THEN CLICK ON MODIFY OR DELETE");
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
		
		function sFocus()
		 {
		 if(document.Form1.txtRlyCD.disabled==false)
		 {
		  document.Form1.txtRlyCD.focus();
		 }
		 else
		 {
		  document.Form1.txtRailProUnit.focus();
		 }
		 }
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="sFocus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 123px; TOP: 8px; LEFT: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="175px" BackColor="White" ForeColor="DarkBlue"
								Font-Size="10pt" Font-Names="Verdana">RAILWAYS DIRECTORY</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 88px" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="1" width="811" bgColor="#f0f8ff" border="1">
								<TR align="center">
									<TD style="WIDTH: 8.63%; HEIGHT: 40px"><asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Railway Code</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 40px"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Railways / Production Unit</asp:label></TD>
									<TD style="WIDTH: 15%; HEIGHT: 40px"><asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Head Quarter</asp:label></TD>
								</TR>
								<TR align="center">
									<TD style="WIDTH: 140px"><asp:textbox id="txtRlyCD" style="TEXT-ALIGN: center" tabIndex="1" runat="server" Width="111px"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="4" Height="20px"></asp:textbox></TD>
									<TD><asp:textbox id="txtRailProUnit" style="TEXT-ALIGN: center" tabIndex="2" runat="server" Width="95%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="30" Height="20px"></asp:textbox></TD>
									<TD><asp:textbox id="txtHQuater" style="TEXT-ALIGN: center" tabIndex="3" runat="server" Width="95%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="30" Height="20px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="Label5" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* To Add New Record Fill Values and Click on Save</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" tabIndex="4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnSearch" tabIndex="4" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button><asp:button id="btnDelConfirm" tabIndex="5" runat="server" Font-Bold="True" Width="85px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Delete!!!" Visible="False" onclick="btnDelConfirm_Click"></asp:button><asp:button id="btnCancel" tabIndex="6" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<P>&nbsp;</P>
						<P align="center"></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
			<DIV id="repdiv" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 320px; OVERFLOW: scroll; TOP: 250px; LEFT: 8px"
				align="center" runat="server">
				<asp:datagrid id="grdRailways" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana"
					BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False" PageSize="15" onprerender="btnSearch_Click">
					<AlternatingItemStyle Font-Names="Verdana" BackColor="#CCCCFF"></AlternatingItemStyle>
					<ItemStyle HorizontalAlign="Left"></ItemStyle>
					<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" ForeColor="DarkBlue"
						VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn FooterText="Delete">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"Railways_Form.aspx?RLY_CD=" + DataBinder.Eval(Container.DataItem,"RLY_CD") + "&amp;ACTION=D"%>' runat="server">Delete</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn FooterText="Edit">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"Railways_Form.aspx?RLY_CD=" + DataBinder.Eval(Container.DataItem,"RLY_CD") + "&amp;ACTION=E"%>' runat="server">Edit</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="RLY_CD" HeaderText="Railways Code">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="RAILWAY" HeaderText="Railways / Production Unit"></asp:BoundColumn>
						<asp:BoundColumn DataField="HEAD_QUARTER" HeaderText="Head Quarter"></asp:BoundColumn>
					</Columns>
					<PagerStyle Mode="NumericPages"></PagerStyle>
				</asp:datagrid></DIV>
		</form>
	</body>
</HTML>
