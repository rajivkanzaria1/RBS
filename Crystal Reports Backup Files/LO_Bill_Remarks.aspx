<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LO_Bill_Remarks.aspx.cs" Inherits="RBS.LO_Bill_Remarks.LO_Bill_Remarks" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl3" Src="WebUserControl3.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LO_Bill_Remarks</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P>
							<uc1:WebUserControl3 id="WebUserControl31" runat="server"></uc1:WebUserControl3></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px" align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue" Width="196px">INSPECTION FEE BILL</asp:label></P>
					</TD>
				</TR>
				<TR>
					<td align="center">
						<TABLE id="Table2" style="WIDTH: 40%; HEIGHT: 38px" borderColor="#b0c4de" cellSpacing="0"
							cellPadding="1" width="30%" bgColor="aliceblue" border="1">
							<TR>
								<TD style="WIDTH: 16.59%; HEIGHT: 36px" align="right" colSpan="1" rowSpan="1"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										BackColor="AliceBlue" ForeColor="DarkBlue" Width="47px" Height="20px">Bill No.</asp:label></TD>
								<TD style="WIDTH: 38.49%; HEIGHT: 36px"><asp:textbox id="txtBillNo" onblur="makeUppercase();" tabIndex="1" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="10"></asp:textbox></TD>
								<TD style="WIDTH: 70%; HEIGHT: 36px">
									<asp:button id="btnAdd" tabIndex="3" runat="server" Width="160px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Add/Modify Remarks" onclick="btnAdd_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" style="WIDTH: 60%; HEIGHT: 38px" borderColor="#b0c4de" cellSpacing="0"
							cellPadding="1" bgColor="aliceblue" border="1">
							<TR>
								<TD style="WIDTH: 3.17%; HEIGHT: 23px"><asp:label id="Client" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Bill No.</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 23px"><asp:label id="lblClient" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%"></asp:label></TD>
								<TD style="WIDTH: 10%; HEIGHT: 23px"><asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Bill Amount</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 23px"><asp:label id="lblBillAmt" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%"></asp:label></TD>
								<TD style="WIDTH: 10%; HEIGHT: 23px"><asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">AU</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 23px"><asp:label id="lblAU" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 3.17%; HEIGHT: 23px">
									<asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">LO Remarks</asp:label>
									<asp:label id="Label4" runat="server" Width="84px" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Visible="False">(Max 400 Chars)</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 23px" colSpan="5">
									<asp:textbox id="txtRemarks" tabIndex="11" runat="server" Width="95%" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Height="80px" MaxLength="250" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:button id="btnSave" tabIndex="3" runat="server" Width="160px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Save Remarks" Enabled="False" onclick="btnSave_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnAddNew" tabIndex="3" runat="server" Width="235px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Add Remarks in Next Bill" onclick="btnAddNew_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed" Width="384px" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
