<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeT20_Consignee.aspx.cs" Inherits="RBS.ChangeT20_Consignee.ChangeT20_Consignee" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangeT20_Consignee</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		
		function conformation()
		{
			var d=confirm("Are You Sure you want to Update Consignee in IC !!!");
			if(d==true)
			event.returnValue=true;
			else
			event.returnValue=false;
		}
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 48px"
				cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 17px" align="center" height="17">
							<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 28px" align="center">
							<P><asp:label id="Label1" runat="server" Width="276px" ForeColor="DarkBlue" BackColor="White"
									Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">CHANGE CONSIGNEE IN IC</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 150px" align="center">
							<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 64px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" bgColor="#f0f8ff" border="1">
								<TBODY>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" align="left" colSpan="2">
											<P align="left"><asp:label id="Label4" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">CASE No.</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="lblCaseNo" runat="server" Width="112px" ForeColor="OrangeRed" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana">Case No </asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												&nbsp;
												<asp:label id="Label5" runat="server" Width="56px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">BK No.</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="lblBKNO" runat="server" Width="88px" ForeColor="OrangeRed" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="Label7" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">SET No.</asp:label><asp:label id="lblSetNo" runat="server" Width="88px" ForeColor="OrangeRed" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana"></asp:label></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 6.73%; HEIGHT: 9px" vAlign="top"><asp:label id="Label3" runat="server" Width="88px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Existing BPO In IC</asp:label></TD>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top"><asp:label id="lblBPO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana"></asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 1.88%" vAlign="top">
											<P><asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Exisiting Consignee In IC</asp:label></P>
										</TD>
										<TD style="WIDTH: 28.43%" vAlign="top"><asp:label id="lblConsignee" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana"></asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 1.88%" vAlign="top">
											<P><asp:label id="Label11" runat="server" Width="88px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Replace with Consignee</asp:label></P>
										</TD>
										<TD style="WIDTH: 28.43%" vAlign="top">
											<P><asp:dropdownlist id="lstConsignee" tabIndex="1" runat="server" Width="98%" ForeColor="DarkBlue" Font-Size="8pt"
													Font-Names="Verdana"></asp:dropdownlist></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 2.81%" vAlign="top">
											<P>&nbsp;</P>
										</TD>
										<TD style="WIDTH: 18.82%; HEIGHT: 9px" vAlign="top">
											<P>&nbsp;</P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" align="center" colSpan="2"><asp:label id="Label6" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana">Plz Make Sure that you have choosen the correct Consignee Before Proceeding!!!</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" colSpan="2">
											<P align="center"><asp:button id="btnSave" tabIndex="2" runat="server" Width="205px" ForeColor="DarkBlue" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana" Text="Update Consignee in IC" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="3" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></P>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<BR>
						</TD>
					<TR>
						<TD style="HEIGHT: 26px" align="center"></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
