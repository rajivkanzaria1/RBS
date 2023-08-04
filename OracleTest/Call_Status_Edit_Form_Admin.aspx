<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Status_Edit_Form_Admin.aspx.cs" Inherits="RBS.Call_Status_Edit_Form_Admin.Call_Status_Edit_Form_Admin" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Call_Status_Edit_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center" style="HEIGHT: 45px">
						<P>
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1>
						</P>
					</TD>
				</TR>
				<tr>
					<td align="center">
						<asp:label id="Label1" runat="server" BackColor="White" Font-Names="Verdana" Font-Size="10pt"
							ForeColor="DarkBlue" Font-Bold="True" Width="253px">CALL STATUS UPDATE FORM</asp:label>
					</td>
				</tr>
				<TR>
					<TD align="center">
						<TABLE id="Table4" cellSpacing="0" cellPadding="1" width="90%" bgColor="#f0f8ff" border="1"
							borderColor="#b0c4de">
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Vendor</td>
								<td style="WIDTH: 70%; HEIGHT: 9px">
									<asp:label id="lblVend" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="90%"></asp:label></td>
							</tr>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Purchaser</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblPurc" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Item</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblItem" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="95%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Call 
									Date</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblCallDT" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="128px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Engineer 
									Name</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblIEName1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Engineer 
									Contact No.</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblIECON" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">PO 
									No.</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblPONO" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">PO 
									Date</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblPODT" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="128px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Case 
									No.</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblCSNO" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="128px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Contact 
									Person</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblCONPER" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Contact 
									Person Tel No.</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblCONPERTEL" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="90%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Call 
									Serial No</TD>
								<TD style="WIDTH: 70%">
									<asp:label id="lblSNO" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Width="128px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Call 
									Status</TD>
								<TD style="WIDTH: 70%; HEIGHT: 12px">
									<asp:label id="lblCallStatus" runat="server" Width="128px" Font-Bold="True" ForeColor="OrangeRed"
										Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:label>
									<asp:DropDownList id="lstCallStatus" runat="server" Width="40%"></asp:DropDownList></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 18px">Allow&nbsp;Updation 
									of Call(Y/N)</TD>
								<TD style="WIDTH: 70%; HEIGHT: 18px">
									<asp:DropDownList id="lstCStatusUAllow" runat="server" Width="40%"></asp:DropDownList></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"></TD>
								<TD style="WIDTH: 70%">
									<asp:button id="btnSave" tabIndex="17" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True" Width="67px" Text="Save" onclick="btnSave_Click"></asp:button>
									<asp:button id="btnCancel" tabIndex="19" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Font-Bold="True" Width="67px" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
