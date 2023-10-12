<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Super_Surpirse_Form.aspx.cs" Inherits="RBS.Super_Surpirse_Form.Super_Surpirse_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Super_Surpirse_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		
		function validate()
		{
		if(trimAll(document.Form1.txtSupSurDT.value)=="")
		 {
		 alert("ENTER SUPER SURPRISE DATE!!!");
		 event.returnValue=false;
		 document.Form1.lstLab.focus();
		 }
		 else if (trimAll(document.Form1.TextSBUremarks.value)=="")
		 {
		 alert("ENTER SBU HEAD REMARKS/RECOMMENDATION");
		 event.returnValue=false;
		 document.Form1.lstLab.focus();
		 }
		 else if(trimAll(document.Form1.lstCO.value)=="")
		 {
		 alert("SELECT SUPER SURPIRSE CM!!!");
		 event.returnValue=false;
		 document.Form1.lstLab.focus();
		 }
		 else if(trimAll(document.Form1.ddlItemScope.value)=="")
		 {
		 alert("SELECT NAME OF SCOPE OF SECTOR!!!");
		 event.returnValue=false;
		 document.Form1.lstLab.focus();
		 }
	    }
			
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center" colSpan="4" height="50"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="4">
						<P><asp:textbox id="txtSysDate" runat="server" Width="1px" Height="1px" BorderStyle="None"></asp:textbox><asp:label id="Label1" runat="server" Width="234px" ForeColor="DarkBlue" BackColor="White"
								Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">SUPER SURPRISE CHECK FORM</asp:label></P>
					</TD>
				</TR>
				<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
					Width="100%" Height="1px" Visible="False">
					<TR>
						<TD style="HEIGHT: 76px" align="center" colSpan="4">
							<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 100%" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="0" bgColor="aliceblue" border="1">
								<TR>
									<TD style="HEIGHT: 36px" align="right">
										<asp:label id="Label6" runat="server" Width="61px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue">Case No.</asp:label></TD>
									<TD style="HEIGHT: 36px">
										<asp:textbox id="txtCaseNo" onblur="makeUppercase();" tabIndex="1" runat="server" Height="20px"
											Width="150px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="9"></asp:textbox></TD>
									<TD style="HEIGHT: 36px" align="right">
										<asp:label id="Label2" runat="server" Width="105px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue">Call Date</asp:label></TD>
									<TD style="HEIGHT: 36px">
										<asp:textbox id="txtCallDT" onblur="check_date(txtCallDT);" tabIndex="2" runat="server" Height="20px"
											Width="150px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="10"></asp:textbox></TD>
									<TD style="HEIGHT: 36px" align="right">
										<asp:label id="Label9" runat="server" Width="105px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue">Call SNo.</asp:label></TD>
									<TD style="HEIGHT: 36px">
										<asp:textbox id="txtCSNO" onblur="check_date(txtDtOfReciept);" tabIndex="3" runat="server" Height="20px"
											Width="50px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="5"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 36px" align="center" colSpan="6">
										<asp:button id="btnAdd" tabIndex="8" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
											Font-Bold="True" ForeColor="DarkBlue" Text="Submit" onclick="btnAdd_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
					Width="100%" Height="1px">
					<TR>
						<TD style="WIDTH: 10.85%; HEIGHT: 23px" align="center" colSpan="4">
							<asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Visible="False">Super Surprise No.</asp:label>
							<asp:label id="lblSupSurNo" runat="server" Width="91px" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="OrangeRed" Visible="False"></asp:label></TD>
					</TR>
					<TR bgColor="#ccccff">
						<TD style="WIDTH: 10.85%; HEIGHT: 23px">
							<asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Case No</asp:label></TD>
						<TD style="WIDTH: 50.62%; HEIGHT: 23px">
							<asp:label id="lblCaseNo" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed">Case No </asp:label></TD>
						<TD style="WIDTH: 14.16%; HEIGHT: 23px">
							<asp:label id="Label16" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue"> Call Date - SNo. </asp:label></TD>
						<TD style="WIDTH: 12%; HEIGHT: 23px">
							<asp:label id="lblDtOfReciept" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed">C Date </asp:label>&nbsp;-
							<asp:label id="lblCSNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed">C SNO</asp:label></TD>
					</TR>
					<TR bgColor="#ccccff">
						<TD style="WIDTH: 11.85%; HEIGHT: 29px">
							<asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Contract No </asp:label></TD>
						<TD style="WIDTH: 50.62%; HEIGHT: 29px">
							<asp:label id="lblPONO" runat="server" Width="80%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed"></asp:label></TD>
						<TD style="WIDTH: 10.16%; HEIGHT: 29px">
							<asp:label id="Label18" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Date</asp:label></TD>
						<TD style="WIDTH: 15%; HEIGHT: 29px">
							<asp:label id="lblPODT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed">PO Date </asp:label></TD>
					</TR>
					<TR bgColor="#ccccff">
						<TD style="WIDTH: 11.85%; HEIGHT: 27px">
							<asp:label id="Label17" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Vendor</asp:label></TD>
						<TD style="WIDTH: 30.43%; HEIGHT: 27px">
							<asp:label id="lblVend" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed">Vendor </asp:label></TD>
						<TD style="WIDTH: 12.16%; HEIGHT: 27px">
							<asp:label id="Label23" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Inspecting Er.</asp:label></TD>
						<TD style="WIDTH: 19.24%; HEIGHT: 27px">
							<asp:label id="lblIE" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed">IE</asp:label>
							<asp:label id="lblIECD" runat="server" Width="5%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed" Visible="False">IE</asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 11.85%; HEIGHT: 26px">
							<asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Manufacturer</asp:label></TD>
						<TD style="WIDTH: 30.43%; HEIGHT: 26px">
							<asp:label id="lblMfg" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="OrangeRed">Vendor </asp:label></TD>
						<TD style="WIDTH: 12.16%; HEIGHT: 26px">
							<asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Super Surprise CM</asp:label></TD>
						<TD style="WIDTH: 19.24%; HEIGHT: 26px">
							<asp:dropdownlist id="lstCO" tabIndex="4" runat="server" Width="200px" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="Blue"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 11.85%; HEIGHT: 26px">
							<asp:label id="Label14" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Name of scope of sector where Item is covered.</asp:label></TD>
						<TD style="WIDTH: 30.43%; HEIGHT: 26px">
							<asp:dropdownlist id="ddlItemScope" tabIndex="6" runat="server" Width="100%" Font-Names="Verdana"
								Font-Size="8pt" Font-Bold="True" ForeColor="Blue">
								<asp:ListItem></asp:ListItem>
								<asp:ListItem Value="A">(IAF 12) Chemical/Paints </asp:ListItem>
								<asp:ListItem Value="B">(IAF 14b) Plastics Pipes &amp; Fittings </asp:ListItem>
								<asp:ListItem Value="C">(IAF 16) Cement Pipes, AC Pressue Pipes &amp; PCC Poles</asp:ListItem>
								<asp:ListItem Value="D">(IAF 17b)  Rails, CI/DI Pipes, Steel Tubes and Fittings, Seamless Blocl/Galvanised, Valves</asp:ListItem>
								<asp:ListItem Value="E">S(IAF 19a) Conductor, Cables, Power Transformers, CT/PT Fans, Relay, Panel, DG set, Alternator, Energy Meter</asp:ListItem>
								<asp:ListItem Value="F">(IAF 22) Railway Rolling Stock</asp:ListItem>
								<asp:ListItem Value="G">(IAF 28) Water Supply</asp:ListItem>
								<asp:ListItem Value="H">(IAF 28) Construction</asp:ListItem>
								<asp:ListItem Value="I">(IAF 07) Paper for Printing</asp:ListItem>
								<asp:ListItem Value="J">(IAF 09) Printed Tickes &amp; Ruled Papers</asp:ListItem>
								<asp:ListItem Value="O">Others</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD style="WIDTH: 12.16%; HEIGHT: 26px">
							<asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Super Surprise Date</asp:label></TD>
						<TD style="WIDTH: 19.24%; HEIGHT: 26px">
							<asp:textbox id="txtSupSurDT" onblur="check_date(txtSupSurDT);" tabIndex="5" runat="server" Height="20px"
								Width="150px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 11.85%; HEIGHT: 26px">
							<asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Item</asp:label></TD>
						<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
							<asp:label id="lblItemDesc" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="Blue"><----- Select Item Description From The List Below-----></asp:label>
							<asp:dropdownlist id="lstPoItems" tabIndex="7" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="Crimson"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 11.85%; HEIGHT: 45px">
							<asp:label id="Label15" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Previous Internal/Consignee Rejection</asp:label></TD>
						<TD style="WIDTH: 30.43%; HEIGHT: 45px" colSpan="3">
							<asp:textbox id="txtRemarks" tabIndex="10" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="Blue" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 11.85%; HEIGHT: 26px">
							<asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Discrepancy (If any)</asp:label></TD>
						<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
							<asp:textbox id="txtDiscrepancy" tabIndex="8" runat="server" Width="100%" Font-Names="Verdana"
								Font-Size="8pt" Font-Bold="True" ForeColor="Blue" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 11.85%; HEIGHT: 26px">
							<asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">Overall outcome of the visit</asp:label></TD>
						<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
							<asp:textbox id="txtOutcome" tabIndex="9" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="Blue" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 11.85%; HEIGHT: 26px">
							<asp:label id="Label20" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue">SBU HEAD REMARKS/RECOMMENDATION</asp:label></TD>
						<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
							<asp:textbox id="TextSBUremarks" tabIndex="9" runat="server" Width="100%" Font-Names="Verdana"
								Font-Size="8pt" Font-Bold="True" ForeColor="Blue" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 11.85%; HEIGHT: 26px" align="center" colSpan="4">
							<asp:button id="btnSave" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button>
							<asp:button id="btnCancel" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="DarkBlue" Text="Cancel"></asp:button></TD>
					</TR>
					<asp:panel id="Panel_3" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
						Height="1px" Width="100%" Visible="False">
						<TR>
							<TD style="WIDTH: 11.85%; HEIGHT: 26px" align="center" colSpan="4">
								<P>
									<asp:label id="Label19" runat="server" Width="317px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkMagenta"> Upload File (In PDF Only)</asp:label><INPUT id="File1" style="FONT-SIZE: 8pt; WIDTH: 595px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 22px"
										tabIndex="23" type="file" size="80" name="File1" runat="server"></P>
								<P>
									<asp:button id="btnUpload" tabIndex="24" runat="server" Width="83px" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Text="Upload PO" onclick="btnUpload_Click"></asp:button></P>
							</TD>
						</TR>
					</asp:panel>
				</asp:panel></TABLE>
		</form>
	</body>
</HTML>

