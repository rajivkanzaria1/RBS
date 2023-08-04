<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchaser_Form.aspx.cs" Inherits="RBS.Purchaser_Form.Purchaser_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CALL DETAILS FORM</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{
		//if(document.Form1.txtCAdd1.value=="")
		//{
		// alert("ADDRESS LINE 1ST CANNOT BE LEFT BLANK");
		// event.returnValue=false;
		//}
		//else
		//return;
		}
		function del()
		{
		var d=confirm("Click OK to Confirm Delete!!!");
		if(d==true)
		event.returnValue=true;
		else
		event.returnValue=false;
		}
		
		function del2()
		 {
		  if(document.Form1.txtCCode.value=="")
		 {
		 alert("PLZ ENTER PURCHASER CODE FIRST THEN CLICK ON MODIFY OR DELETE");
		 event.returnValue=false;
		 }
		 }
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<BLOCKQUOTE>
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
					cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 25px" align="center" colSpan="5"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 296px" align="center" colSpan="5">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" BackColor="White"
									Font-Bold="True" ForeColor="DarkBlue">PURCHASER MASTER</asp:label></P>
							<P align="center">
								<TABLE id="Table2" style="WIDTH: 504px; HEIGHT: 250px" cellSpacing="0" cellPadding="0"
									width="504" bgColor="aliceblue" border="0">
									<TR>
										<td style="WIDTH: 181px; HEIGHT: 29px" colSpan="2"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue">Purchaser Code </asp:label></td>
										<td style="WIDTH: 305px; HEIGHT: 29px" colSpan="3"><asp:textbox id="txtCCode" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												MaxLength="8" Width="150px" Height="25px"></asp:textbox><asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="OrangeRed" Width="150px" BorderStyle="Inset">Purchaser Code </asp:label></td>
									</TR>
									<TR>
										<TD style="WIDTH: 181px; HEIGHT: 28px" colSpan="2"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue">Purchaser Type</asp:label></TD>
										<TD style="WIDTH: 305px; HEIGHT: 28px" colSpan="3"><asp:dropdownlist id="lstCType" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="260px" Height="25px" AutoPostBack="True" onload="lstCType_SelectedIndexChanged" ondatabinding="lstCType_SelectedIndexChanged" onselectedindexchanged="lstCType_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 181px; HEIGHT: 50px" colSpan="2"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="221px"> Purchaser Designation</asp:label></TD>
										<TD style="WIDTH: 305px; HEIGHT: 50px" colSpan="3"><asp:textbox id="txtCSName" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" MaxLength="15" Width="260px" Height="25px"></asp:textbox><asp:dropdownlist id="lstCAName" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="259px" Height="25px"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 181px; HEIGHT: 28px" colSpan="2"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="164px"> Railway/Organisation</asp:label></TD>
										<TD style="WIDTH: 305px; HEIGHT: 28px" colSpan="3"><asp:dropdownlist id="lstRailwayCD" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="260px" Height="25px"></asp:dropdownlist><asp:textbox id="txtPFirm" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												MaxLength="40" Width="260px" Height="25px"></asp:textbox></TD>
									</TR>
									<TR>
										<td style="WIDTH: 181px; HEIGHT: 19px" colSpan="2"><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="125px">Purchaser Address</asp:label></td>
										<td style="WIDTH: 305px; HEIGHT: 19px" colSpan="3"><asp:textbox id="txtCAdd1" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												MaxLength="100" Width="260px" Height="25px"></asp:textbox></td>
									</TR>
									<TR>
										<td style="WIDTH: 181px; HEIGHT: 26px" colSpan="2"></td>
										<td style="WIDTH: 305px; HEIGHT: 26px" colSpan="3"><asp:textbox id="txtCAdd2" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												MaxLength="100" Width="260px" Height="25px"></asp:textbox></td>
									</TR>
									<TR>
										<TD style="WIDTH: 181px; HEIGHT: 5px" colSpan="2" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
											&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="11px"> City</asp:label></TD>
										<TD style="WIDTH: 305px; HEIGHT: 5px" colSpan="3"><asp:dropdownlist id="lstCCity" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="260px" Height="25px"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
								<asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
									ForeColor="DarkMagenta" Width="346px">* To Add New Record Fill Values and Click on Save</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 19px" align="center" colSpan="5">
							<P><asp:button id="btnSave" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
									ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnCancel" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Cancel" onclick="btnCancel_Click"></asp:button></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="5"><asp:datagrid id="grdPDetails" runat="server" BackColor="White" Font-Size="8pt" Font-Names="Verdana"
								Height="100px" Width="100%" BorderStyle="Groove" AutoGenerateColumns="False" BorderColor="Navy" CellPadding="0" PageSize="1">
								<FooterStyle Wrap="False"></FooterStyle>
								<EditItemStyle Wrap="False"></EditItemStyle>
								<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center" ForeColor="DarkBlue"
									VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:HyperLinkColumn Text="Select" DataNavigateUrlField="CONSIGNEE_CD" DataNavigateUrlFormatString="Purchaser_Form.aspx?CONSIGNEE_CD={0}"
										HeaderText="Modify/Delete" NavigateUrl="Purchaser_Form.aspx">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:HyperLinkColumn>
									<asp:BoundColumn DataField="CONSIGNEE_CD" HeaderText="Consignee Code">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONSIGNEE_TYPE" HeaderText="Consignee Type">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONSIGNEE_RLY" HeaderText="RailWay CD">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONSIGNEE_S_NAME" HeaderText="Consignee SName">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONSIGNEE_L_NAME" HeaderText="Consignee  LName">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONSIGNEE_ADD1" HeaderText="Consignee Add">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONSIGNEE_ADD2" HeaderText="Consignee Add">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONSIGNEE_CITY" HeaderText="Consignee City">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</BLOCKQUOTE>
		</form>
	</body>
</HTML>
