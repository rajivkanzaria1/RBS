<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JI_Request_Form.aspx.cs" Inherits="RBS.JI_Request_Form.JI_Request_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>JI_Request_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 184px"
				cellSpacing="1" cellPadding="1" border="0">
				<TBODY>
					<TR>
						<TD style="WIDTH: 20.5%; HEIGHT: 32px" align="center" colSpan="6">
							<asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								Width="191px" Font-Bold="True" BackColor="White">JI REQUEST FORM</asp:label></TD>
					</TR>
					<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
						Width="100%" Height="1px" Visible="False">
						<TR>
							<TD style="WIDTH: 20.5%; HEIGHT: 32px" bgColor="#ffcccc">
								<asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana"> PO/Offer Letter No.</asp:label></TD>
							<TD style="WIDTH: 44.03%; HEIGHT: 32px" align="left" colSpan="2">
								<asp:textbox id="txtPONo" runat="server" BackColor="White" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana" Height="20px"></asp:textbox></TD>
							<TD style="WIDTH: 11.05%; HEIGHT: 32px" bgColor="#ffcccc">
								<asp:label id="Label3" runat="server" Font-Bold="True" Width="54px" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">PO Date</asp:label></TD>
							<TD style="WIDTH: 15%; HEIGHT: 32px" colSpan="2">
								<asp:textbox id="txtPODate" onblur="check_date(txtPODate);" runat="server" BackColor="White"
									Width="35%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 100%" align="center" colSpan="6">
								<asp:button id="btnSearchPO" runat="server" Font-Bold="True" Width="83px" ForeColor="DarkBlue"
									Font-Size="8pt" Font-Names="Verdana" Text="Search"></asp:button>&nbsp;&nbsp;
								<asp:button id="btnCancel" runat="server" Font-Bold="True" Width="83px" ForeColor="DarkBlue"
									Font-Size="8pt" Font-Names="Verdana" Text="Cancel"></asp:button>
								<asp:Label id="lblSearchStatus" runat="server" ForeColor="White">Label</asp:Label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 100%" colSpan="6">
								<TITTLE:CUSTOMDATAGRID id="DgCompCaseSearch" runat="server" Width="100%" Visible="False" Height="8px" AutoGenerateColumns="False"
									PageSize="15" BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid"
									AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="200px" GridWidth="100%">
									<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
									<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
									<EditItemStyle Height="10%"></EditItemStyle>
									<FooterStyle CssClass="GridHeader"></FooterStyle>
									<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
									<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
										CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn HeaderText="Select">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemTemplate>
												<asp:HyperLink id="Hyperlink1" Runat="server" NavigateUrl='<%#"JI_Request_Form.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;BK_NO=" + DataBinder.Eval(Container.DataItem,"BK_NO")+"&amp;SET_NO=" + DataBinder.Eval(Container.DataItem,"SET_NO")%>'>Select</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="PO_NO" HeaderText="Purchase Order Number">
											<HeaderStyle Width="20%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RLY_CD" HeaderText="Agency">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="VEND_NAME" HeaderText="Vendor">
											<HeaderStyle Width="25%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CASE_NO" HeaderText="Rites Case Number">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BK_NO" HeaderText="Bk No."></asp:BoundColumn>
										<asp:BoundColumn DataField="SET_NO" HeaderText="Set No."></asp:BoundColumn>
										<asp:BoundColumn DataField="CONSIGNEE" HeaderText="Consignee">
											<HeaderStyle Width="15%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="IC_NO" HeaderText="IC No."></asp:BoundColumn>
										<asp:BoundColumn DataField="IC_DT" HeaderText="IC Date"></asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></TD>
						</TR>
					</asp:panel>
					<asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
						Width="100%" Height="1px" Visible="False">
						<TR>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Case No.</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:label id="lblCaseNo" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana">-x-</asp:label></TD>
							<TD style="WIDTH: 11.28%; HEIGHT: 22px">
								<asp:label id="Label5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Book No.</asp:label></TD>
							<TD style="WIDTH: 16%; HEIGHT: 22px">
								<asp:label id="lblBkNo" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana">-x-</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:label id="Label6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Set No.</asp:label></TD>
							<TD style="WIDTH: 16%; HEIGHT: 22px">
								<asp:label id="lblSetNo" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana">-x-</asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:label id="Label7" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Inspection By</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:label id="lblIE" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana">-x-</asp:label>
								<asp:label id="lblIECd" runat="server" Visible="False"></asp:label></TD>
							<TD style="WIDTH: 11.28%; HEIGHT: 22px">
								<asp:label id="Label8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">PO No. & PO Date</asp:label></TD>
							<TD style="WIDTH: 16%; HEIGHT: 22px">
								<asp:label id="lblPoNo" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana">-x-</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:label id="Label9" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Railway</asp:label></TD>
							<TD style="WIDTH: 16%; HEIGHT: 22px">
								<asp:label id="lblRly" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana">-x-</asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17%; HEIGHT: 28px">
								<asp:label id="Label10" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Consignee</asp:label></TD>
							<TD style="WIDTH: 83%" colSpan="5">
								<asp:label id="lblConsignee" runat="server" Font-Bold="True" Width="100%" ForeColor="Blue"
									Font-Size="8pt" Font-Names="Verdana">-x-</asp:label>
								<asp:label id="lblConsigneeCd" runat="server" Visible="False"></asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17%; HEIGHT: 28px">
								<asp:label id="Label20" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Vendor</asp:label></TD>
							<TD style="WIDTH: 83%" colSpan="5">
								<asp:label id="lblVendor" runat="server" Font-Bold="True" Width="100%" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana">-x-</asp:label>
								<asp:label id="lblVendorCd" runat="server" Visible="False"></asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:label id="Label19" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">IC Date</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="2">
								<asp:label id="lblIcDate" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana">-x-</asp:label></TD>
							<TD style="WIDTH: 11.28%; HEIGHT: 22px">
								<asp:label id="Label18" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">IC No.</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="2">
								<asp:label id="lblIcNo" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana">-x-</asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17%">
								<asp:label id="Label13" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Item Description</asp:label></TD>
							<TD colSpan="5">
								<asp:label id="lblItemDesc" runat="server" Font-Bold="True" Width="100%" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana"><----- Select Item Description From The List Below-----></asp:label>
								<asp:dropdownlist id="lstPoItems" runat="server" Width="100%" ForeColor="Crimson" Font-Size="8pt"
									Font-Names="Verdana" AutoPostBack="True"></asp:dropdownlist>
								<asp:label id="lblItemSrnoPo" runat="server" Width="40px" Visible="False"></asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 16%; HEIGHT: 22px">
								<asp:label id="Label14" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Qty. Offered</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:textbox id="txtQtyOffered" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana"></asp:textbox></TD>
							<TD style="WIDTH: 10.61%; HEIGHT: 22px">
								<asp:label id="Label26" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Qty. Rejected</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:textbox id="txtQtyRej" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana" AutoPostBack="True"></asp:textbox></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:label id="Label15" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Unit of Measurement</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:label id="lblUOMDesc" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana"></asp:label>
								<asp:label id="lblUOM" runat="server" Visible="False"></asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17%; HEIGHT: 22px">
								<asp:label id="Label27" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Rate</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="3">
								<asp:label id="lblRate" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana"></asp:label>
								<asp:label id="lblUomRate" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana"></asp:label>&nbsp;</TD>
							<TD style="WIDTH: 13.06%; HEIGHT: 22px">
								<asp:label id="Label16" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Value of Qty. Rejected</asp:label></TD>
							<TD style="HEIGHT: 22px">
								<asp:textbox id="txtValueRej" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana"></asp:textbox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17%">
								<asp:label id="Label11" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Rejection Memo No.</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="2">
								<asp:textbox id="txtMemoNo" runat="server" Font-Bold="True" Width="90%" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana" MaxLength="25"></asp:textbox></TD>
							<TD style="WIDTH: 11.28%; HEIGHT: 22px">
								<asp:label id="Label12" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Rejection Memo Date</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="2">
								<asp:textbox id="txtMemoDt" onblur="check_date(txtMemoDt)" runat="server" Font-Bold="True" ForeColor="Blue"
									Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17%">
								<asp:label id="Label17" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Reasons of Rejection</asp:label></TD>
							<TD colSpan="5">
								<asp:textbox id="txtRejReason" runat="server" Font-Bold="True" Width="100%" ForeColor="Blue"
									Font-Size="8pt" Font-Names="Verdana" TextMode="MultiLine"></asp:textbox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 16%; HEIGHT: 22px">
								<asp:label id="Label21" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Name</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="2">
								<asp:textbox id="txtName" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
							<TD style="WIDTH: 10.61%; HEIGHT: 22px">
								<asp:label id="Label22" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana"> Department</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="2">
								<asp:textbox id="txtDept" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana"
									AutoPostBack="True"></asp:textbox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 16%; HEIGHT: 22px">
								<asp:label id="Label23" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana"> Mobile No.</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="2">
								<asp:textbox id="txtMobile" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt"
									Font-Names="Verdana"></asp:textbox></TD>
							<TD style="WIDTH: 10.61%; HEIGHT: 22px">
								<asp:label id="Label28" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Email</asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="2">
								<asp:textbox id="txtEmail" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 16%; HEIGHT: 22px">
								<asp:label id="Label24" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
									Font-Names="Verdana">Upload JI Rejection Memo <Font Color="Red">(IN PDF Only)</Font></asp:label></TD>
							<TD style="WIDTH: 17%; HEIGHT: 22px" colSpan="5"><INPUT id="File1" style="FONT-SIZE: 8pt; WIDTH: 424px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 22px"
									tabIndex="23" type="file" size="51" name="File1" runat="server"></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="6">
								<asp:button id="btnSave" tabIndex="19" runat="server" Font-Bold="True" Width="67px" ForeColor="DarkBlue"
									Font-Size="8pt" Font-Names="Verdana" Text="Save"></asp:button>
								<asp:button id="Button1" tabIndex="21" runat="server" Font-Bold="True" Width="67px" ForeColor="DarkBlue"
									Font-Size="8pt" Font-Names="Verdana" Text="Cancel"></asp:button></TD>
						</TR>
					</asp:panel>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
