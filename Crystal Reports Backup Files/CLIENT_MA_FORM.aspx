<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CLIENT_MA_FORM.aspx.cs" Inherits="RBS.CLIENT_MA_FORM.CLIENT_MA_FORM" %>


<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl2" Src="WebUserControl2.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CLIENT_MA_FORM</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
	     function validate()
		{		 
		if(trimAll(document.Form1.lstClientType.value)=="")
		 {
		  alert("Select BPO Type");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtMAN.value)=="")
		 {
		  alert("MA No CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtMAdate.value=="")
		 {
		 alert("MA Date CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.Txt_MAF.value=="")
		 {
		 alert("MA Field CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.txtMAD.value=="")
		 {
		 alert("MA Description CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.txtMAOV.value=="")
		 {
		 alert("OLD MA Value CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.txtMANV.value=="")
		 {
		 alert("NEW MA Value CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.File2.value=="")
		 {
		 alert("FILE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else 
		return;
			
		}
		
		function validate1()
		{		 
		if(trimAll(document.Form1.lstClientType.value)=="")
		 {
		  alert("Select BPO Type");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtMAN.value)=="")
		 {
		  alert("MA No CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtMAdate.value=="")
		 {
		 alert("MA Date CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(document.Form1.Txt_MAF.value=="")
		 {
		 alert("MA Field CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.txtMAD.value=="")
		 {
		 alert("MA Description CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.txtMAOV.value=="")
		 {
		 alert("OLD MA Value CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.txtMANV.value=="")
		 {
		 alert("NEW MA Value CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else 
		return;
			
		}
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 25.8%"
				id="Table1" border="0" cellSpacing="1" borderColor="#b0c4de" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 17px">
							<uc1:WebUserControl2 id="WebUserControl21" runat="server"></uc1:WebUserControl2>
							<P></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 13px" align="center">
							<P><asp:label id="Label1" runat="server" Height="19px" Width="264px" ForeColor="DarkBlue" Font-Size="10pt"
									Font-Names="Verdana" BackColor="White" Font-Bold="True">CLIENT MA FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 13px" width="100%" align="center">
							<TABLE style="HEIGHT: 175px" id="Table2" border="1" cellSpacing="1" borderColor="#b0c4de"
								cellPadding="1" width="100%" bgColor="#f0f8ff" align="center">
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblCaseNo" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True">Case No.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblCasNo" runat="server" Width="90%" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
												Font-Bold="True"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblPoNo" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Po No.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblPNo" runat="server" Width="90%" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
												Font-Bold="True"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblPoDt" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Po Date.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblPDt" runat="server" Width="90%" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
												Font-Bold="True"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblR_CD" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">RLY Code.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblR_Code" runat="server" Width="90%" ForeColor="OrangeRed" Font-Size="8pt"
												Font-Names="Verdana" Font-Bold="True"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="Label7" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">SNo.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="Label_Sno" runat="server" Width="90%" ForeColor="OrangeRed" Font-Size="8pt"
												Font-Names="Verdana" Font-Bold="True"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 28px"><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">BPO Type<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="WIDTH: 80%"><asp:dropdownlist id="lstClientType" tabIndex="1" runat="server" Width="45%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 28px"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">PO/Offer Letter No.<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="WIDTH: 80%"><asp:dropdownlist id="DL_PO" tabIndex="1" runat="server" Width="45%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" AutoPostBack="True" Enabled="False">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="P">Purchase Order</asp:ListItem>
											<asp:ListItem Value="L">Letter of Offer</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: red; FONT-FAMILY: Verdana; HEIGHT: 18px"
										width="223"><asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">MA No.</asp:label>*</TD>
									<TD style="WIDTH: 80%; HEIGHT: 18px"><asp:textbox id="txtMAN" tabIndex="6" runat="server" Height="20px" Width="45%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="10"></asp:textbox></TD>
								</TR>
								<tr>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: red; FONT-FAMILY: Verdana; HEIGHT: 18px"
										width="179"><asp:label id="Label3" runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True"> MA Date (DD/MM/YYYY)</asp:label>*</TD>
									<TD style="WIDTH: 80%; HEIGHT: 18px"><asp:textbox onblur="check_date(txtMAdate);" id="txtMAdate" tabIndex="7" runat="server" Height="20px"
											Width="45%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
								</tr>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label8" runat="server" Width="144px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Field</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="Txt_MAF" tabIndex="15" runat="server" Height="18px" Width="90%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label24" runat="server" Width="144px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">MA Description</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="txtMAD" tabIndex="15" runat="server" Height="40px" Width="90%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="100" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label17" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Original PO Entry</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="txtMAOV" tabIndex="13" runat="server" Height="40px" Width="90%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="500" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Amended PO Entry</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="txtMANV" tabIndex="13" runat="server" Height="40px" Width="90%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="500" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%" align="left"><asp:label id="Label13" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">MA Document</asp:label></TD>
									<TD style="WIDTH: 80%" align="left"><INPUT style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											id="File2" tabIndex="0" size="51" type="file" name="File1" runat="server"><asp:hyperlink id="HyperLink1" runat="server" Visible="False" Target="_blank">HyperLink</asp:hyperlink></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%" bgColor="white" width="233" colSpan="4" align="center"><asp:button id="btnSave" tabIndex="21" runat="server" Width="100px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True" Text="Save MA" onclick="btnSave_Click"></asp:button><asp:button id="BtnExist" tabIndex="21" runat="server" Width="200px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True" Visible="False" Text="Save in Existing MA" onclick="BtnExist_Click"></asp:button><asp:button id="btnUpdate" tabIndex="21" runat="server" Width="150px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True" Visible="False" Text="Update MA" onclick="btnUpdate_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label_RE" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True" Visible="False">REMARKS</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="Txt_RE" tabIndex="13" runat="server" Height="40px" Width="90%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="500" TextMode="MultiLine" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD width="100%" align="left" colspan="2">
										<DIV><TITTLE:CUSTOMDATAGRID id="DgPO1" runat="server" Height="8px" Width="100%" GridWidth="100%" GridHeight="350px"
												FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
												CellPadding="2" FreezeRows="0" BorderColor="DarkBlue" PageSize="15" AutoGenerateColumns="False">
												<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
												<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
												<EditItemStyle Height="10%"></EditItemStyle>
												<FooterStyle CssClass="GridHeader"></FooterStyle>
												<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
												<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
													CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="CASE_NO" HeaderText="Case Number">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="PO_NO" HeaderText="Purchase Order Number">
														<HeaderStyle Width="20%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="PO_DT" HeaderText="Purchase Order Date">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="MA_NO" HeaderText="MA No">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="MA_DT" HeaderText="MA Date">
														<HeaderStyle Width="15%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="RLY_CD" HeaderText="Agency">
														<ItemStyle ForeColor="Blue"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="PO_OR_LETTER" HeaderText="PO OR Letter">
														<ItemStyle ForeColor="Blue"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="MA_SNO" HeaderText="MA Sno">
														<ItemStyle ForeColor="Blue"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="MA_FIELD" HeaderText="MA Field">
														<ItemStyle ForeColor="Blue"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="MA_STATUS" HeaderText="MA Status">
														<ItemStyle ForeColor="Blue"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
											</TITTLE:CUSTOMDATAGRID></DIV>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
