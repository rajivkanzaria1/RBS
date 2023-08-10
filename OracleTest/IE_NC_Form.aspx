<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_NC_Form.aspx.cs" Inherits="RBS.IE_NC_Form" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>IE_NC_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
			
		function validate()
		{
			if(document.Form1.lstNCR_Codes.value=="")
			{
				alert("Select the NCR Code!!!");
				event.returnValue=false;
			}
			else if(document.Form1.txtOtherDesc=="[object]" && trimAll(document.Form1.txtOtherDesc.value)=="")
			{
				alert("Plz Enter The Description in case of Others!!!");
				event.returnValue=false;
			}
			else if (document.Form1.txtOtherDesc=="[object]" && document.Form1.txtOtherDesc.value.length > 250)
			{
				alert("Plz Enter The Description within 250 Characters Only!!!");
				event.returnValue=false;
			
			}
		}
		
        </script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				borderColor="#b0c4de" cellSpacing="0" cellPadding="0" width="100%" border="1">
				<TR>
					<TD style="HEIGHT: 17px" align="center" colSpan="4" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="4">
						<P><asp:textbox id="txtSysDate" runat="server" BorderStyle="None" Height="1px" Width="1px"></asp:textbox><asp:label id="Label1" runat="server" Width="60%" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue">NON CONFORMITY FORM</asp:label></P>
					</TD>
				</TR>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 10.85%; HEIGHT: 23px"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">IC NO.</asp:label></TD>
					<TD style="WIDTH: 50.62%; HEIGHT: 23px"><asp:label id="lblIC_NO" runat="server" Width="56px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">IC No</asp:label></TD>
					<TD style="WIDTH: 14.16%; HEIGHT: 23px"><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">IC Date</asp:label></TD>
					<TD style="WIDTH: 12%; HEIGHT: 23px"><asp:label id="lblIC_DT" runat="server" Width="56px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">IC Dt</asp:label></TD>
				</TR>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 10.85%; HEIGHT: 23px"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">BK NO.</asp:label></TD>
					<TD style="WIDTH: 50.62%; HEIGHT: 23px"><asp:label id="lblBKNO" runat="server" Width="56px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">BK No</asp:label></TD>
					<TD style="WIDTH: 14.16%; HEIGHT: 23px"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Set No.</asp:label></TD>
					<TD style="WIDTH: 12%; HEIGHT: 23px"><asp:label id="lblSETNO" runat="server" Width="49px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">Set No.</asp:label></TD>
				</TR>
				<tr bgColor="#ccccff">
					<TD style="WIDTH: 10.85%; HEIGHT: 23px"><asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Case No</asp:label></TD>
					<TD style="WIDTH: 50.62%; HEIGHT: 23px"><asp:label id="txtCaseNo" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">Case No </asp:label></TD>
					<TD style="WIDTH: 14.16%; HEIGHT: 23px"><asp:label id="Label16" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue"> Call Date - SNo. </asp:label></TD>
					<TD style="WIDTH: 12%; HEIGHT: 23px"><asp:label id="txtDtOfReciept" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">C Date </asp:label>&nbsp;-
						<asp:label id="lblCSNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">C SNO</asp:label></TD>
				</tr>
				<tr bgColor="#ccccff">
					<TD style="WIDTH: 11.85%; HEIGHT: 29px"><asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Contract No </asp:label></TD>
					<TD style="WIDTH: 50.62%; HEIGHT: 29px"><asp:label id="lblPONO" runat="server" Width="80%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">PO NO.</asp:label></TD>
					<TD style="WIDTH: 10.16%; HEIGHT: 29px"><asp:label id="Label18" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Date</asp:label></TD>
					<TD style="WIDTH: 15%; HEIGHT: 29px"><asp:label id="lblPODT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">PO Date </asp:label></TD>
				</tr>
				<tr bgColor="#ccccff">
					<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label17" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Vendor</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 26px"><asp:label id="lblVend" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">Vendor </asp:label><asp:label id="lblVEND_CD" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="OrangeRed" Visible="False"></asp:label></TD>
					<TD style="WIDTH: 12.16%; HEIGHT: 26px"><asp:label id="Label23" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Inspecting Er.</asp:label></TD>
					<TD style="WIDTH: 19.24%; HEIGHT: 26px"><asp:label id="lblIE" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">IE</asp:label><asp:label id="lblIECD" runat="server" Width="5%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed" Visible="False">IE</asp:label></TD>
				</tr>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Consignee</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3"><asp:label id="lblConsignee" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="OrangeRed">Consignee</asp:label><asp:label id="lblCon_CD" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed" Visible="False"></asp:label></TD>
				</TR>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Item</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3"><asp:label id="lblItemDesc" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="Blue"><----- Select Item Description From The List Below-----></asp:label><asp:dropdownlist id="lstItems" runat="server" Width="100%" Font-Names="Verdana" Font-Size="7pt" ForeColor="DarkBlue"
							AutoPostBack="True" onselectedindexchanged="lstPoItems_SelectedIndexChanged"></asp:dropdownlist><asp:label id="lblItem" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed"></asp:label><asp:label id="lblItem_Srno" runat="server" Width="5%" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="OrangeRed" Visible="False"></asp:label></TD>
				</TR>
				<TR bgColor="#ccccff">
					<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Qty Passed</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3"><asp:label id="lblQtyPass" runat="server" Width="88px" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="OrangeRed">Qty</asp:label>&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">NCR No.</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 26px"><asp:label id="lblNC_NO" runat="server" Width="88px" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed"></asp:label>&nbsp;&nbsp;</TD>
					<TD style="WIDTH: 11.85%; HEIGHT: 26px"><asp:label id="Label15" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">NCR Date</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 26px"><asp:label id="txtNCR_DT" runat="server" Width="88px" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="OrangeRed"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 26px"></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
						<asp:RadioButton id="rdbNONCR" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" AutoPostBack="True" Text="No NC" GroupName="g1" tabIndex="1" oncheckedchanged="rdbAddNCR_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:RadioButton id="rdbAddNCR" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" AutoPostBack="True" Text="Add NC" GroupName="g1" Checked="True" tabIndex="2" oncheckedchanged="rdbAddNCR_CheckedChanged"></asp:RadioButton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 6px">
						<asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">NCR Class</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 6px" colSpan="3"><asp:dropdownlist id="lstNCRClass" runat="server" Width="120px" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="Crimson" AutoPostBack="True" tabIndex="3" onselectedindexchanged="lstNCRClass_SelectedIndexChanged"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 26px">
						<asp:label id="Label11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">NCR Codes</asp:label>
						<asp:label id="Label14" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">NCR Desc in Case of Others</asp:label></TD>
					<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
						<P><asp:dropdownlist id="lstNCR_Codes" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="Crimson" AutoPostBack="True" tabIndex="4" onselectedindexchanged="lstNCR_Codes_SelectedIndexChanged"></asp:dropdownlist>
							<asp:TextBox id=txtOtherDesc runat="server" Width="100%" BorderStyle="Inset" ForeColor="#0000C0" BackColor="White" Text='<%# DataBinder.Eval(Container, "DataItem.IE_ACTION") %>' TextMode="MultiLine" tabIndex=5>
							</asp:TextBox></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 26px" align="center" colSpan="4"><asp:button id="btnSave" tabIndex="6" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnAddMoreNC" tabIndex="7" runat="server" Width="114px" Font-Names="Verdana"
							Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Text="Save More NC's" onclick="btnAddMoreNC_Click"></asp:button><asp:button id="btnCancel" tabIndex="8" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 26px" align="center" colSpan="4"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 26px" colSpan="4"><TITTLE:CUSTOMDATAGRID id="grdNCDetails" tabIndex="20" runat="server" BorderStyle="Groove" Width="100%"
							Font-Names="Verdana" Font-Size="8pt" BackColor="White" FreezeColumns="0" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderWidth="1px"
							FreezeHeader="True" GridHeight="200px" FreezeRows="0" AutoGenerateColumns="False" BorderColor="Navy" CellPadding="2" PageSize="1">
							<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle Font-Size="7pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
							<EditItemStyle Font-Size="8pt"></EditItemStyle>
							<FooterStyle Wrap="False" CssClass="GridHeader"></FooterStyle>
							<ItemStyle Font-Size="7pt" Font-Names="Verdana" HorizontalAlign="Center" CssClass="GridNormal"></ItemStyle>
							<HeaderStyle Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
								ForeColor="DarkBlue" CssClass="GridHeader" VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="NC_CD_SNO" HeaderText="NC Code Sno.">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NC_CD" HeaderText="NC Code">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NC_DESC" ReadOnly="True" HeaderText="NC Description">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="IE Corrective &amp; Preventive Action1">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemTemplate>
										<asp:TextBox id=txtIE_Remarks1 runat="server" Width="100%" BorderStyle="Inset" ForeColor="#0000C0" BackColor="#FFC080" Text='<%# DataBinder.Eval(Container, "DataItem.IE_ACTION") %>' TextMode="MultiLine">
										</asp:TextBox>
										<asp:label id=lblIE_Remarks1 runat="server" Width="90%" ForeColor="#0000C0" Font-Size="8pt" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container, "DataItem.IE_ACTION") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Controlling Remarks1">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemTemplate>
										<asp:TextBox id=txtCO_Remarks1 runat="server" BorderStyle="Inset" Width="100%" BackColor="#FFC080" ForeColor="#0000C0" Text='<%# DataBinder.Eval(Container, "DataItem.CO_FINAL_REMARKS") %>' TextMode="MultiLine">
										</asp:TextBox>
										<asp:label id="lblCO_Remarks1" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Text='<%# DataBinder.Eval(Container, "DataItem.CO_FINAL_REMARKS") %>' ForeColor="#0000C0">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 26px" align="center" colSpan="4"><asp:button id="btnSaveIEAction" tabIndex="9" runat="server" Width="92px" Font-Names="Verdana"
							Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Text="Save Actions" onclick="btnSaveIEAction_Click"></asp:button><asp:button id="btnSaveCORemarks" tabIndex="10" runat="server" Width="102px" Font-Names="Verdana"
							Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Text="Save Remarks" onclick="btnSaveCORemarks_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 26px" align="center" colSpan="4">
						<asp:button id="btnSend" tabIndex="11" runat="server" Width="136px" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Text="Send To IE" onclick="btnSend_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
