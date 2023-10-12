<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Edit.aspx.cs" Inherits="RBS.User_Edit.User_Edit" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>User Edit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{
		if(document.Form1.txtUID.disabled==false && document.Form1.txtUID.value=="")
		{
		 alert("USER ID CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else if(document.Form1.txtUName.value=="")
		{
		 alert("NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else
		 {
		 document.Form1.btnSave.style.visibility = 'hidden';
		 }
		
		}
		
		function sFocus()
		 {
		 if(document.Form1.txtUID.disabled==false)
		 {
		  document.Form1.txtUID.focus();
		 }
		 else
		 {
		  document.Form1.txtUName.focus();
		 }
		 }
		
        </script>
	</HEAD>
	<body onload="sFocus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center" colSpan="5">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" BackColor="White"
								Font-Bold="True" ForeColor="DarkBlue">USER CREATION/UPDATION</asp:label></P>
						<P align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="71%" border="1" style="HEIGHT: 127px"
								bgColor="aliceblue" borderColor="#b0c4de">
								<TR>
									<td style="WIDTH: 299px; HEIGHT: 29px" colSpan="2"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Font-Bold="True">User ID </asp:label></td>
									<td colSpan="3" style="HEIGHT: 29px"><asp:textbox id="txtUID" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											MaxLength="8" Width="86px" Height="20px"></asp:textbox></td>
								</TR>
								<TR>
									<td style="WIDTH: 299px; HEIGHT: 29px" colSpan="2"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Font-Bold="True">User Name</asp:label></td>
									<td colSpan="3" style="HEIGHT: 29px"><asp:textbox id="txtUName" tabIndex="2" runat="server" Width="280px" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" MaxLength="50" Height="20px"></asp:textbox></td>
								</TR>
								<TR>
									<td style="WIDTH: 299px; HEIGHT: 27px" colSpan="2">
										<asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Employee No.&nbsp</asp:label></td>
									<td colSpan="3" style="HEIGHT: 27px">
										<asp:textbox id="txtEmpNo" tabIndex="3" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="88px" MaxLength="6" Rows="5" Height="20px"></asp:textbox></td>
								</TR>
								<TR>
									<TD style="WIDTH: 299px; HEIGHT: 26px" colSpan="2">
										<asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Region&nbsp</asp:label></TD>
									<TD style="HEIGHT: 26px" colSpan="3">
										<asp:dropdownlist id="lstRegion" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Width="150px" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<td style="WIDTH: 299px; HEIGHT: 20px" colSpan="2"><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Font-Bold="True">Role</asp:label></td>
									<td colSpan="3" style="HEIGHT: 20px"><asp:dropdownlist id="lstRole" runat="server" Width="150px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											tabIndex="5" Height="25px" AutoPostBack="True" onselectedindexchanged="lstRole_SelectedIndexChanged"></asp:dropdownlist></td>
								</TR>
								<TR>
									<td style="WIDTH: 299px" colSpan="2"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Font-Bold="True">Status</asp:label></td>
									<td colSpan="3"><asp:dropdownlist id="lstStatus" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="150px" Height="25px"></asp:dropdownlist></td>
								</TR>
								<TR>
									<TD style="WIDTH: 299px" colSpan="2">
										<asp:label id="lblPOEntry" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Allow PO Entry (Y/N)</asp:label></TD>
									<TD colSpan="3">
										<asp:dropdownlist id="ddlAllowPO" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px" Width="50px">
											<asp:ListItem Value="Y">Yes</asp:ListItem>
											<asp:ListItem Value="N">No</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<%if(lblDL.Text=="Y"){%>
								<TR>
									<TD style="WIDTH: 299px; HEIGHT: 26px" colSpan="2">
										<asp:label id="Label4" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Allow Download of Checksheets (Y/N)</asp:label></TD>
									<TD colSpan="3" style="HEIGHT: 26px">
										<asp:dropdownlist id="lstDL" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Height="25px" Width="50px">
											<asp:ListItem Value="Y">Yes</asp:ListItem>
											<asp:ListItem Value="N" Selected="True">No</asp:ListItem>
										</asp:dropdownlist>
										<asp:Label id="lblDL" runat="server" Visible="False"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 299px; HEIGHT: 22px" colSpan="2">
										<asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Call Marking CM (Y/N)</asp:label></TD>
									<TD colSpan="3" style="HEIGHT: 22px">
										<asp:dropdownlist id="ddlCallMarking_CM" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px" Width="50px">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="Y">Yes</asp:ListItem>
											<asp:ListItem Value="N" Selected="True">No</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 299px; HEIGHT: 23px" colSpan="2">
										<asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Call Re-Marking CM (Y/N)</asp:label></TD>
									<TD colSpan="3" style="HEIGHT: 23px">
										<asp:dropdownlist id="ddlCallRemarking_CM" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px" Width="50px">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="Y">Yes</asp:ListItem>
											<asp:ListItem Value="N">No</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 299px" colSpan="2">
										<asp:label id="Label11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">User Type</asp:label></TD>
									<TD colSpan="3">
										<asp:dropdownlist id="ddlUser_Type" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px" Width="20%">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="U">User</asp:ListItem>
											<asp:ListItem Value="C">CM</asp:ListItem>
											<asp:ListItem Value="G">GM</asp:ListItem>
											<asp:ListItem Value="S">SBU HEAD</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<%}%>
							</TABLE>
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="5">
						<P>&nbsp;</P>
						<P><asp:button id="btnSave" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button></P>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>

