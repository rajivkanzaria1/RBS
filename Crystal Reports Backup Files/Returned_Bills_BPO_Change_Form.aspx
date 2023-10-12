<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Returned_Bills_BPO_Change_Form.aspx.cs" Inherits="RBS.Returned_Bills_BPO_Change_Form.Returned_Bills_BPO_Change_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Change BPO For Retuned Bills</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		
		function conformation()
		{
			var d=confirm("Are You Sure you want to Update BPO in the Bill!!!");
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
									Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">RETURNED BILLS CHANGE BPO IN BILL</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 150px" align="center">
							<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 64px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" bgColor="#f0f8ff" border="1">
								<TBODY>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" align="left" colSpan="2">
											<P align="left"><asp:label id="Label9" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Bill No.</asp:label><asp:label id="lblBillNo" runat="server" Width="112px" ForeColor="OrangeRed" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana"></asp:label>&nbsp; &nbsp;<asp:label id="Label4" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">CASE No.</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="lblCaseNo" runat="server" Width="112px" ForeColor="OrangeRed" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana">Case No </asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												&nbsp;&nbsp; &nbsp;
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
												Font-Names="Verdana"></asp:label><asp:label id="lblOldBPO_CD" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Visible="False"></asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 6.73%; HEIGHT: 9px" vAlign="top"><asp:label id="Label6" runat="server" Width="88px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Existing AU</asp:label></TD>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top"><asp:label id="lblOldAU" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
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
										<TD style="WIDTH: 1.88%; HEIGHT: 15px" vAlign="top"><asp:label id="Label12" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">IRFC FUNDED</asp:label></TD>
										<TD style="WIDTH: 28.43%; HEIGHT: 15px" vAlign="top"><asp:dropdownlist id="lstIRFC" tabIndex="20" runat="server" Width="64px" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="20px" AutoPostBack="True" onselectedindexchanged="lstIRFC_SelectedIndexChanged">
												<asp:ListItem Value="N" Selected="True">No</asp:ListItem>
												<asp:ListItem Value="Y">Yes</asp:ListItem>
											</asp:dropdownlist><asp:label id="lblIRFC" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Visible="False"></asp:label><asp:label id="lblOldAccGroup" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Visible="False"></asp:label><asp:label id="lblOldIRFCBPOCd" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Visible="False"></asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 1.88%" vAlign="top"><asp:label id="Label42" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Recipient GSTIN No.</asp:label></TD>
										<TD style="WIDTH: 28.43%" vAlign="top">
											<P><asp:radiobutton id="rdbConsignee" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana" AutoPostBack="True" Text="Consignee GSTIN" GroupName="g1" Enabled="False"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:radiobutton id="rdbBPO" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana" AutoPostBack="True" Text="BPO GSTIN" GroupName="g1" Enabled="False"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:radiobutton id="rdbIRFC" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana" AutoPostBack="True" Text="IRFC GSTIN" GroupName="g1" Enabled="False"></asp:radiobutton></P>
											<P><asp:label id="lblOldRecGSTIN_NO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana"></asp:label></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 1.88%; HEIGHT: 25px" vAlign="top"><asp:label id="lblIRFC_BPO" runat="server" Width="88px" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Visible="False">IRFC BPO</asp:label></TD>
										<TD style="WIDTH: 28.43%; HEIGHT: 25px" vAlign="top"><asp:dropdownlist id="ddlIRFCBPO" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Visible="False" Height="20px" AutoPostBack="True" onselectedindexchanged="ddlIRFCBPO_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 1.88%; HEIGHT: 34px" vAlign="top">
											<P><asp:label id="Label11" runat="server" Width="88px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Replace with BPO</asp:label></P>
										</TD>
										<TD style="WIDTH: 28.43%; HEIGHT: 34px" vAlign="top">
											<P><asp:textbox id="txtBPO" style="TEXT-ALIGN: center" runat="server" Width="72px" ForeColor="DarkBlue"
													Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="5"></asp:textbox><asp:button id="btnFC_List" runat="server" Width="96px" ForeColor="DarkBlue" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana" Height="20px" Text="Select BPO" onclick="btnFC_List_Click"></asp:button><asp:dropdownlist id="lstBPO" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
													Visible="False" Height="20px" AutoPostBack="True" onselectedindexchanged="lstBPO_SelectedIndexChanged"></asp:dropdownlist></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 2.81%" vAlign="top">
											<P><asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">NEW AU</asp:label></P>
										</TD>
										<TD style="WIDTH: 18.82%; HEIGHT: 9px" vAlign="top">
											<P><asp:label id="lblAU" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana"></asp:label></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 2.81%" vAlign="top"><asp:label id="Label13" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">INVOICE RECIPIENT GSTIN NO</asp:label></TD>
										<TD style="WIDTH: 18.82%; HEIGHT: 9px" vAlign="top"><asp:label id="lblGST_NO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana"></asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" align="center" colSpan="2"><asp:label id="Label10" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana">Plz Make Sure that you have choosen the correct BPO Before Proceeding!!!</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" align="center" colSpan="2"><asp:label id="lblMessage" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Visible="False">This Bill is not returned by Railways, so you cannot change BPO from this Form.</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" colSpan="2">
											<P align="center"><asp:button id="btnSave" tabIndex="2" runat="server" Width="150px" ForeColor="DarkBlue" Font-Bold="True"
													Font-Size="8pt" Font-Names="Verdana" Text="Update BPO" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="3" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
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
