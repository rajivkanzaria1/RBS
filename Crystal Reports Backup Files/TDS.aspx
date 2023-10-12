<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TDS.aspx.cs" Inherits="RBS.TDS.TDS" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TDS</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
            function validate() {

                if (document.Form1.txtBNO.value == "") {
                    alert("BILL NO. CANNOT BE LEFT BLANK");
                    event.returnValue = false;
                }
                else if (trimAll(document.Form1.txtTDS.value) > 0 && document.Form1.txtTDSDT.value == "") {
                    alert("TDS DATE CANNOT BE LEFT BLANK");
                    event.returnValue = false;
                }
                else
                    return;
            }



        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="260px" Font-Bold="True">TDS FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 90%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="1" width="625" align="center" bgColor="#f0f8ff" border="1">
								<TR align="center">
									<TD align="center" width="10%"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Font-Bold="True"> BILL No.</asp:label></TD>
									<TD align="center" width="15%">
										<asp:textbox id="txtBNO" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											MaxLength="10" Height="22px"></asp:textbox>
										<asp:button id="btnSearch" tabIndex="2" runat="server" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button></TD>
									<TD align="center" width="10%">
										<asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"> Case No.</asp:label></TD>
									<TD align="center" width="10%">
										<asp:label id="lblCNo" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
											Font-Names="Verdana"></asp:label></TD>
									<TD align="center" width="10%">
										<asp:label id="Label12" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"> Bill Amount</asp:label></TD>
									<TD align="center" width="10%">
										<asp:label id="lblBillAmt" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
											Font-Names="Verdana"></asp:label></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:label id="Label5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">TDS</asp:label></TD>
									<TD align="center">
										<asp:label id="Label9" runat="server" Font-Bold="True" Width="64px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">TDS CGST</asp:label></TD>
									<TD align="center">
										<asp:label id="Label10" runat="server" Font-Bold="True" Width="64px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">TDS SGST</asp:label></TD>
									<TD align="center">
										<asp:label id="Label11" runat="server" Font-Bold="True" Width="64px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">TDS IGST</asp:label></TD>
									<TD align="center">
										<asp:label id="Label6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Retention Money</asp:label></TD>
									<TD align="center">
										<asp:label id="Label7" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Write off Amt/Amt Adjusted</asp:label></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:textbox id="txtTDS" tabIndex="3" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											MaxLength="10" Height="22px"></asp:textbox></TD>
									<TD align="center">
										<asp:textbox id="txtTDS_CGST" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="22px" MaxLength="10"></asp:textbox></TD>
									<TD align="center">
										<asp:textbox id="txtTDS_SGST" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="22px" MaxLength="10"></asp:textbox></TD>
									<TD align="center">
										<asp:textbox id="txtTDS_IGST" tabIndex="6" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="22px" MaxLength="10"></asp:textbox></TD>
									<TD align="center">
										<asp:textbox id="txtRetention" tabIndex="7" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" MaxLength="10" Height="22px"></asp:textbox></TD>
									<TD align="center">
										<asp:textbox id="txtWriteOffAmt" tabIndex="8" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="22px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="right" colSpan="3">
										<asp:label id="Label8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">TDS Posting Date</asp:label></TD>
									<TD align="left" colSpan="3">
										<asp:textbox id="txtTDSDT" onblur="check_date(txtTDSDT);" tabIndex="9" runat="server" Width="50%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkMagenta"
								Font-Bold="True">* To Add New Record Fill Values and Click on Save</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label id="lblTDS" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Visible="False"></asp:label>
						<asp:label id="lblRMoney" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Visible="False"></asp:label><asp:button id="btnSave" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Width="72px" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button>
						<asp:button id="btnCHQPOSTING" tabIndex="12" runat="server" Font-Bold="True" Width="141px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Return To Posting" onclick="btnCHQPOSTING_Click"></asp:button>
						<asp:label id="lblWOffAmt" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Visible="False"></asp:label>
						<asp:label id="lblTDS_CGST" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Visible="False"></asp:label>
						<asp:label id="lblTDS_SGST" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Visible="False"></asp:label>
						<asp:label id="lblTDS_IGST" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

