<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Replace_BPO.aspx.cs" Inherits="RBS.Replace_BPO.Replace_BPO" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Replace_BPO</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
			
			if(trimAll(document.Form1.lstBPO.value)=="" && trimAll(document.Form1.lstBPO.value).length < 2)
			{
				alert("The Search Criteria to Select the BPO Shld be Atleast of 2 Charcters");
				event.returnValue=false;	
			}
			else
			return;
		}
		
		function validate1()
		{
			
			if(trimAll(document.Form1.lstBPO1.value)=="" && trimAll(document.Form1.lstBPO1.value).length < 2)
			{
				alert("The Search Criteria to Select the BPO Shld be Atleast of 2 Charcters");
				event.returnValue=false;	
			}
			else
			return;
		}
		
		function mess()
		{
		var d=confirm("Click OK to Continue Replacing BPO, else Click Cancel!!!");
		if(d==true)
		event.returnValue=true;
		else
		event.returnValue=false;
		}
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 23px" align="center">
						<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 28px">
						<P align="center"></P>
						<P align="center"><asp:panel id="Panel1" runat="server" HorizontalAlign="Center" Height="175px">
								<P>
									<asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
										BackColor="White" ForeColor="DarkBlue">REPLACE BPO</asp:label></P>
								<P align="center">
									<TABLE id="Table2" style="WIDTH: 95%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1"
										cellPadding="1" bgColor="#f0f8ff" border="1">
										<TR>
											<TD style="WIDTH: 5.52%; HEIGHT: 28px">
												<asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="62px">Old BPO.</asp:label></TD>
											<TD style="WIDTH: 30%; HEIGHT: 28px" colSpan="3">
												<asp:textbox id="txtBPO" style="TEXT-ALIGN: center" tabIndex="2" runat="server" Height="20px"
													Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="72px" MaxLength="5"></asp:textbox>
												<asp:button id="btnFC_List" tabIndex="3" runat="server" Height="20px" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="DarkBlue" Width="96px" Text="Select BPO"></asp:button></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5.52%"></TD>
											<TD style="WIDTH: 30%" colSpan="3">
												<asp:dropdownlist id="lstBPO" tabIndex="4" runat="server" Height="20px" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Width="100%" Visible="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5.52%">
												<asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="61px">New BPO.</asp:label></TD>
											<TD style="WIDTH: 30%" align="center" colSpan="3">
												<P align="left">
													<asp:textbox id="txtBPO1" style="TEXT-ALIGN: center" tabIndex="2" runat="server" Height="20px"
														Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="72px" MaxLength="5"></asp:textbox>
													<asp:button id="btnFC_List1" tabIndex="3" runat="server" Height="20px" Font-Names="Verdana"
														Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="96px" Text="Select BPO"></asp:button></P>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5.52%"></TD>
											<TD style="WIDTH: 30%" align="center" colSpan="3">
												<asp:dropdownlist id="lstBPO1" tabIndex="4" runat="server" Height="20px" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Width="100%" Visible="False"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
							</asp:panel></P>
						<P align="center">&nbsp;</P>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center"><asp:button id="btnview" tabIndex="13" runat="server" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Proceed To Replace BPO" Width="200px"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
