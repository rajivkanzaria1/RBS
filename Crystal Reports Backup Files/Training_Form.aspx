<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Training_Form.aspx.cs" Inherits="RBS.Training_Form.Training_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Training_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 152px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 31px" align="center" colSpan="5"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 31px" align="center" colSpan="5"><B><FONT face="Verdana" color="darkblue" size="2"><asp:label id="Label1" runat="server" Font-Size="10pt" Font-Names="Verdana" ForeColor="DarkBlue"
										Font-Bold="True" BackColor="White" Width="253px"> IE TRAINING DETAILS</asp:label>&nbsp;</FONT></B></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD vAlign="middle" align="center" bgColor="#f0f8ff" colSpan="5">
							<TABLE id="Table2" borderColor="#b0c4de" height="100%" cellSpacing="0" cellPadding="0"
								width="80%" bgColor="#f0f8ff" border="1">
								<TR bgColor="#f0f8ff">
									<TD style="WIDTH: 2.75%; HEIGHT: 20px" align="right"><asp:label id="Label2" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Width="40px">Name</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 20px" align="left" colSpan="4"><asp:dropdownlist id="lstIEORCM" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="40%" AutoPostBack="True" onselectedindexchanged="lstIEORCM_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%" align="right"><asp:label id="Label17" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Width="56px">Emp No.</asp:label></TD>
									<TD style="WIDTH: 10.52%" align="left" colSpan="4"><asp:textbox id="txtEmpNo" onblur="check_date(txtVendAppFrom);" runat="server" Font-Size="8pt"
											Font-Names="Verdana" ForeColor="DarkBlue" Width="35%" Height="20px" MaxLength="10" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%" align="right"><asp:label id="Label20" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Width="56px">Discipline</asp:label></TD>
									<TD style="WIDTH: 10.52%" align="left" colSpan="4"><asp:dropdownlist id="lstDept" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Width="80%" Height="25px" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%" align="right"><asp:label id="Label21" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Width="56px">DOB</asp:label></TD>
									<TD style="WIDTH: 10.52%" align="left" colSpan="4"><asp:textbox id="txtDOB" onblur="check_date(txtDOB);" runat="server" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Width="35%" Height="20px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%; HEIGHT: 24px" align="right"><asp:label id="Label22" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Width="56px">DOJ</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 24px" align="left" colSpan="4"><asp:textbox id="txtDOJ" onblur="check_date(txtDOJ);" runat="server" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Width="35%" Height="20px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%" align="right"><asp:label id="Label18" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Width="57px">Photo</asp:label></TD>
									<TD style="WIDTH: 10.52%" align="left" colSpan="4"><INPUT id="File1" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 100%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%" align="right"><B><FONT face="Verdana" color="darkblue" size="2"><asp:label id="Label14" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
													Font-Bold="True">Category</asp:label></FONT></B></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 33px" align="left" colSpan="4"><asp:dropdownlist id="lstCategory" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="40%" AutoPostBack="True" onselectedindexchanged="lstCategory_SelectedIndexChanged">
											<asp:ListItem Value="R">Regular</asp:ListItem>
											<asp:ListItem Value="D">Deputation</asp:ListItem>
											<asp:ListItem Value="O">Other</asp:ListItem>
										</asp:dropdownlist><asp:textbox id="txtCatOth" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="100%" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%" align="right"><B><FONT face="Verdana" color="darkblue" size="2"><asp:label id="Label3" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
													Font-Bold="True">Qualification</asp:label></FONT></B></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 36px" align="left" colSpan="4"><asp:dropdownlist id="lstQual" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="40%" AutoPostBack="True" onselectedindexchanged="lstQual_SelectedIndexChanged">
											<asp:ListItem Value="D">Degree</asp:ListItem>
											<asp:ListItem Value="P">Diploma</asp:ListItem>
											<asp:ListItem Value="O">Others</asp:ListItem>
										</asp:dropdownlist><asp:textbox id="txtQualOther" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="100%" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%" align="right"><asp:label id="Label19" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Width="72px">Institute</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 36px" align="left" colSpan="4"><asp:textbox id="txtInst" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%" align="center" colSpan="5"><asp:button id="btnSave" runat="server" ForeColor="DarkBlue" Font-Bold="True" BackColor="#C0C0FF"
											Text="Submit" onclick="btnSave_Click"></asp:button><asp:button id="btnAddNew" runat="server" ForeColor="DarkBlue" Font-Bold="True" BackColor="#C0C0FF"
											Text="Add New IE" onclick="btnAddNew_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%" align="center" colSpan="5"><asp:label id="Label4" runat="server" Font-Size="10pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" BackColor="White" Width="153px">TRAINING DETAILS</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%; HEIGHT: 31px" align="right"><asp:label id="Label5" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True">Training Type</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 31px" align="left" colSpan="4"><asp:dropdownlist id="lstTType" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="40%">
											<asp:ListItem Value="I">Induction</asp:ListItem>
											<asp:ListItem Value="O">Orientation</asp:ListItem>
											<asp:ListItem Value="R">Refresh</asp:ListItem>
											<asp:ListItem Value="T">Technical</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%; HEIGHT: 30px" align="right"><asp:label id="Label6" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True">Training Area</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 30px" align="left" colSpan="4"><asp:dropdownlist id="lstField" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="40%" AutoPostBack="True" onselectedindexchanged="lstField_SelectedIndexChanged">
<asp:ListItem Value="W">Welding</asp:ListItem>
<asp:ListItem Value="N">NDT</asp:ListItem>
<asp:ListItem Value="M">Metrology</asp:ListItem>
<asp:ListItem Value="P">Plastic</asp:ListItem>
<asp:ListItem Value="T">Textile</asp:ListItem>
<asp:ListItem Value="A">Paint</asp:ListItem>
<asp:ListItem Value="R">Transformer</asp:ListItem>
<asp:ListItem Value="C">Cable </asp:ListItem>
<asp:ListItem Value="E">Energy Audit</asp:ListItem>
<asp:ListItem Value="V">Pressure Vessal</asp:ListItem>
<asp:ListItem Value="I">Pipeline</asp:ListItem>
<asp:ListItem Value="B">Rubber</asp:ListItem>
<asp:ListItem Value="X">M&amp;P</asp:ListItem>
<asp:ListItem Value="O">ISO</asp:ListItem>
<asp:ListItem Value="D">DRG Reading</asp:ListItem>
<asp:ListItem Value="F">FR Item</asp:ListItem>
<asp:ListItem Value="H">OHE</asp:ListItem>
<asp:ListItem Value="Y">Other</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%; HEIGHT: 31px" align="right"><asp:label id="Label7" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True">Training Category</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 31px" align="left" colSpan="4"><asp:radiobutton id="rdbOut" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Text="Outside" GroupName="g1" Checked="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="rdbIn" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Text="In-House" GroupName="g1"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%; HEIGHT: 30px" align="right"><asp:label id="Label8" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True">Course Name</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 30px" align="left" colSpan="4"><asp:dropdownlist id="lstCourse" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="100%" AutoPostBack="True" onselectedindexchanged="lstCourse_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="txtCourse" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%; HEIGHT: 30px" align="right"><asp:label id="Label9" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True">Institue</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 30px" align="left" colSpan="4"><asp:textbox id="txtCInst" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%; HEIGHT: 30px" align="right"><asp:label id="Label10" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True">Duration (From - To)</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 30px" align="left" colSpan="4"><asp:label id="Label16" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Width="15%"> From</asp:label><asp:textbox id="txtFrom" onblur="check_date(txtFrom);" runat="server" Font-Size="8pt" Font-Names="Verdana"
											ForeColor="DarkBlue" Width="30%" Height="20px" MaxLength="10"></asp:textbox><asp:label id="Label15" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True" Width="15%"> To</asp:label><asp:textbox id="txtTo" onblur="check_date(txtTo);compareDates(txtFrom,txtTo,'To Date Cannot Be Less From Date');"
											runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" Width="30%" Height="20px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%; HEIGHT: 30px" align="right"><asp:label id="Label11" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True">Certificate</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 30px" align="left" colSpan="4"><asp:textbox id="txtCert" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%; HEIGHT: 30px" align="right"><asp:label id="Label12" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True">Fees</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 30px" align="left" colSpan="4"><asp:textbox id="txtFees" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="Blue"
											Font-Bold="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 2.75%; HEIGHT: 30px" align="right"><asp:label id="Label13" runat="server" Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Font-Bold="True">Validity</asp:label></TD>
									<TD style="WIDTH: 10.52%; HEIGHT: 30px" align="left" colSpan="4"><asp:textbox id="txtValidity" runat="server" Font-Bold="True" ForeColor="Blue" Font-Names="Verdana"
											Font-Size="8pt"></asp:textbox></TD>
								</TR>
								<TR bgColor="#f0f8ff">
									<TD align="center" colSpan="5"><asp:button id="btnSubmit" tabIndex="22" runat="server" BackColor="#C0C0FF" Font-Bold="True"
											ForeColor="DarkBlue" Text="Submit" onclick="btnSubmit_Click"></asp:button><asp:button id="btnAddNew1" tabIndex="22" runat="server" Width="136px" BackColor="#C0C0FF" Font-Bold="True"
											ForeColor="DarkBlue" Text="Add New Training" onclick="btnAddNew1_Click"></asp:button></TD>
								</TR>
							</TABLE>
		</form></TD></TR></TBODY></TABLE>
	</body>
</HTML>
