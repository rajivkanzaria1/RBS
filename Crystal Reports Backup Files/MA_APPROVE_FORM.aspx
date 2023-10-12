<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MA_APPROVE_FORM.aspx.cs" Inherits="RBS.MA_APPROVE_FORM.MA_APPROVE_FORM" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MA_APPROVE_FORM</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		function validate()
		 {		 
		   if(trimAll(document.Form1.Txt_RE.value)=="")
		   {
		     alert("REMARKS CAN NOT LEFT BLANK");
		     event.returnValue=false;
		   }
		   else if(trimAll(document.Form1.DL_status.value)=="")
		   {
		     alert("STATUS CAN NOT LEFT BLANK");
		     event.returnValue=false;
		   }
		  else 
		 return;	
		}
		
		function validate1()
		 {		 
		   if(trimAll(document.Form1.DL_status.value)=="")
		   {
		     alert("STATUS CAN NOT LEFT BLANK");
		     event.returnValue=false;
		   }
		  else 
		 return;	
		}
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 25.8%; TOP: 8px; LEFT: 8px"
				id="Table1" border="0" cellSpacing="1" borderColor="#b0c4de" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 17px">
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 13px" align="center">
							<P><asp:label id="Label1" runat="server" Font-Bold="True" BackColor="White" Font-Names="Verdana"
									Font-Size="10pt" ForeColor="DarkBlue" Width="264px" Height="19px">MA APPROVE FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 13px" width="100%" align="center">
							<TABLE style="HEIGHT: 175px" id="Table2" border="1" cellSpacing="1" borderColor="#b0c4de"
								cellPadding="1" width="100%" bgColor="#f0f8ff" align="center">
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblCaseNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Case No.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblCasNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="90%"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblPoNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Po No.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblPNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="90%"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblPoDt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Po Date.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblPDt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="90%"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblR_CD" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">RLY Code.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblR_Code" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="90%"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="Label7" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">SNo.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="Label_Sno" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="90%"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 28px"><asp:label id="Label6" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue">BPO Type<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="WIDTH: 80%"><asp:dropdownlist id="lstClientType" tabIndex="1" runat="server" Font-Bold="True" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="45%" AutoPostBack="True" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 28px"><asp:label id="Label5" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue">PO/Offer Letter No.<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="WIDTH: 80%"><asp:dropdownlist id="DL_PO" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="45%" AutoPostBack="True" Enabled="False">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="P">Purchase Order</asp:ListItem>
											<asp:ListItem Value="L">Letter of Offer</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 18px" width="223"><asp:label id="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">MA No.</asp:label>*</TD>
									<TD style="WIDTH: 80%; HEIGHT: 18px"><asp:textbox id="txtMAN" tabIndex="6" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="45%" Height="20px" MaxLength="10" Enabled="False"></asp:textbox></TD>
								</TR>
								<tr>
									<TD style="WIDTH: 20%; FONT-FAMILY: Verdana; HEIGHT: 18px; COLOR: red; FONT-SIZE: 8pt; FONT-WEIGHT: bold"
										width="179"><asp:label id="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="70%"> MA Date (DD/MM/YYYY)</asp:label>*</TD>
									<TD style="WIDTH: 80%; HEIGHT: 18px"><asp:textbox onblur="check_date(txtMAdate);" id="txtMAdate" tabIndex="7" runat="server" Font-Bold="True"
											Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="45%" Height="20px" Enabled="False"></asp:textbox></TD>
								</tr>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label8" runat="server" Width="144px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">Field</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="Txt_MAF" tabIndex="15" runat="server" Height="18px" Width="90%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="15" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label24" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="144px">MA Description</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="txtMAD" tabIndex="15" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="90%" Height="40px" MaxLength="100" TextMode="MultiLine" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label17" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Original PO Entry</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="txtMAOV" tabIndex="13" runat="server" Font-Bold="True" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="40px" MaxLength="500" TextMode="MultiLine" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Amended PO Entry</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="txtMANV" tabIndex="13" runat="server" Height="40px" Width="90%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="500" TextMode="MultiLine" Font-Bold="True" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%" align="left"><asp:label id="Label13" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">MA Documents</asp:label></TD>
									<TD style="WIDTH: 80%" align="left"><asp:hyperlink id="HyperLink1" runat="server" Visible="False" Target="_blank">HyperLink</asp:hyperlink></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 28px"><asp:label id="Label9" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue">Status<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="WIDTH: 80%"><asp:dropdownlist id="DL_status" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="288px" AutoPostBack="True" onselectedindexchanged="DL_status_SelectedIndexChanged">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="N">Approved with No Change In IBS</asp:ListItem>
											<asp:ListItem Value="R">Return With Remarks</asp:ListItem>
											<asp:ListItem Value="A">Approved</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label_RE" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True" Visible="False">REMARKS</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="Txt_RE" tabIndex="13" runat="server" Height="40px" Width="90%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="500" TextMode="MultiLine" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%" bgColor="white" width="233" colSpan="4" align="center"><asp:button id="btnSave" tabIndex="21" runat="server" Width="100px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True" Text="Save MA" Visible="False" onclick="btnSave_Click"></asp:button>
										<asp:button id="AP_BT" tabIndex="21" runat="server" Width="100px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True" Text="Save MA" Visible="False" onclick="AP_BT_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
