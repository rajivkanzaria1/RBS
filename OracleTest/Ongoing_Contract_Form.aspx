<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ongoing_Contract_Form.aspx.cs" Inherits="RBS.Ongoing_Contract_Form.Ongoing_Contract_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ongoing_Contract_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px" id="Table1"
				border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD>
						<P align="center">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" style="HEIGHT: 27px">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="100%" Font-Bold="True">ON GOIN NON-RAILWAY CONTRACTS FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 218px">
						<P align="center">
							<TABLE style="WIDTH: 95%; HEIGHT: 100%" id="Table2" border="1" cellSpacing="1" cellPadding="1"
								width="707" bgColor="#f0f8ff" borderColor="#b0c4de">
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 25px">
										<asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Contract Code</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px" colSpan="3">
										<asp:label id="lblContractCD" runat="server" Font-Bold="True" Width="60%" ForeColor="OrangeRed"
											Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 25px">
										<asp:label id="Label9" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Client Type</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px" colSpan="3">
										<asp:dropdownlist id="lstClientType" runat="server" Width="30%" AutoPostBack="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" onselectedindexchanged="lstClientType_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 25px">
										<asp:label id="Label11" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Client Name</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"></FONT>
										<asp:dropdownlist id="lstBPO_Rly" runat="server" Width="98%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 28px"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Contract No.</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 28px" colSpan="3">
										<asp:textbox id="txtContNo" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Height="25px" MaxLength="250"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 28px"><asp:label id="Label27" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Contract Period (DD/MM/YYYY)</asp:label></TD>
									<TD style="WIDTH: 35%" colspan="3">
										<asp:label id="Label13" runat="server" Font-Bold="True" Width="30px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"> From</asp:label><asp:textbox onblur="check_date(txtContFrom);" id="txtContFrom" tabIndex="7" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="15%" Height="20px"></asp:textbox>
										<asp:label id="Label14" runat="server" Font-Bold="True" Width="3px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"> To</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox onblur="check_date(txtContTo);compareDates(txtContFrom,txtContTo,'Contract To Date Cannot Be Less then Contract From Date');"
											id="txtContTo" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="15%" Height="20px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 29px"><asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="100%">Contract FEE Type</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 29px"><asp:dropdownlist id="lstCFeeType" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="60%" Height="25px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 15.11%; HEIGHT: 29px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Width="90%">Contract TAX Type</asp:label></TD>
									<TD style="WIDTH: 30%; HEIGHT: 29px" align="left"><asp:dropdownlist id="lstCTaxType" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Width="90%" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 24px">
										<asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Contract Fee</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 24px" colSpan="3">
										<asp:textbox id="txtCOFee" style="TEXT-ALIGN: right" runat="server" Width="10%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Height="20px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%" width="109"><asp:label id="lblMinFee" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Min Fee</asp:label></TD>
									<TD style="WIDTH: 30%"><asp:textbox id="txtMinFee" tabIndex="18" runat="server" Height="20px" Width="75%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="11">0</asp:textbox></TD>
									<TD style="WIDTH: 20%"><asp:label id="lblMaxFee" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Max Fee</asp:label></TD>
									<TD style="WIDTH: 30%"><asp:textbox id="txtMaxFee" tabIndex="19" runat="server" Height="20px" Width="75%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="11">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 22px">
										<asp:label id="Label6" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Region</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 22px" colSpan="3">
										<asp:dropdownlist id="lstRegionCd" runat="server" Width="152px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="lstRegionCd_SelectedIndexChanged">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="N">NORTHERN REGION</asp:ListItem>
											<asp:ListItem Value="E">EASTERN REGION</asp:ListItem>
											<asp:ListItem Value="W">WESTERN REGION</asp:ListItem>
											<asp:ListItem Value="S">SOUTHERN REGION</asp:ListItem>
											<asp:ListItem Value="C">CENTRAL REGION</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 16px">
										<asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Contract CM</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 16px" colSpan="3">
										<asp:dropdownlist id="lstCO" runat="server" Width="40%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Height="25px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 22px"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Special Conditions of Contract</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 22px" colspan="3"><asp:textbox id="txtSConds" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="80%" Height="20px" MaxLength="250" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"><asp:label id="Label19" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Penalty (If any)</asp:label></TD>
									<TD style="WIDTH: 35%" colSpan="3">
										<asp:textbox id="txtPenalty" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" MaxLength="250" Height="20px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">
										<asp:label id="Label12" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Contract File (If any)</asp:label></TD>
									<TD style="WIDTH: 35%" align="center" colSpan="3"><INPUT id="File1" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 100%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server">
										<asp:hyperlink id="HypContract" runat="server" Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">View Contract</asp:hyperlink></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px" align="center"><asp:button id="btnAdd" tabIndex="21" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Add New" onclick="btnAdd_Click"></asp:button><asp:button id="btnSave" tabIndex="22" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="24" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button>
						<asp:button id="Print" tabIndex="24" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Print" onclick="Print_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
