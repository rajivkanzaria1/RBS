<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Online_complaints_Approval_Form.aspx.cs" Inherits="RBS.Online_complaints_Approval_Form.Online_complaints_Approval_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Online_complaints_Approval_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">		 
		
		
			function validate()
		{
			if(trimAll(document.Form1.lstJIRequired.value)=="")
				{
					alert("JI Required Missing!!!");
					event.returnValue=false;
					document.Form1.lstPoItems.focus();
				}
			else if(trimAll(document.Form1.lstJiRegion.value)=="")
				{
					alert("Region Doing Joint Inspection Missing!!!");
					event.returnValue=false;
					document.Form1.lstPoItems.focus();
				}
			else 
			return;
		}
		 
		
		
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue" Width="80%">ONLINE REJECTIONS APPROVAL FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center"><asp:panel id="Panel3" runat="server" Width="100%" Height="1px" Visible="true">
							<DIV>
								<TITTLE:CUSTOMDATAGRID id="grdCNO" runat="server" Width="100%" Visible="False" Height="8px" PageSize="15"
									FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
									BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="550px"
									GridWidth="100%">
									<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
									<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
									<EditItemStyle Height="10%"></EditItemStyle>
									<FooterStyle CssClass="GridHeader"></FooterStyle>
									<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
									<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
										CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn HeaderText="Select">
											<HeaderStyle Width="5%"></HeaderStyle>
											<ItemTemplate>
												<asp:HyperLink id=Hyperlink2 NavigateUrl='<%#"Online_complaints_Approval_Form.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;BK_NO=" + DataBinder.Eval(Container.DataItem,"BK_NO")+"&amp;SET_NO=" + DataBinder.Eval(Container.DataItem,"SET_NO")+"&amp;TEMP_COMPLAINT_ID=" + DataBinder.Eval(Container.DataItem,"TEMP_COMPLAINT_ID")%>' Runat="server">Select</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="TEMP_COMPLAINT_ID" HeaderText="Registration No."></asp:BoundColumn>
										<asp:BoundColumn DataField="COMPLAINT_DATE" HeaderText="Registration Date"></asp:BoundColumn>
										<asp:BoundColumn DataField="CONSIGNEE_NAME" HeaderText="Consignee Name"></asp:BoundColumn>
										<asp:BoundColumn DataField="CONSIGNEE_DESIG" HeaderText="Designation"></asp:BoundColumn>
										<asp:BoundColumn DataField="CONSIGNEE_EMAIL" HeaderText="Email"></asp:BoundColumn>
										<asp:BoundColumn DataField="CONSIGNEE_MOBILE" HeaderText="Mobile"></asp:BoundColumn>
										<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No."></asp:BoundColumn>
										<asp:BoundColumn DataField="BK_NO" HeaderText="BK No.">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="SET_NO" HeaderText="SET No.">
											<HeaderStyle Width="14%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="INSP_REGION" HeaderText="Inspecting Region"></asp:BoundColumn>
										<asp:BoundColumn DataField="REJ_MEMO_NO" HeaderText="Rej Momo No."></asp:BoundColumn>
										<asp:BoundColumn DataField="REJ_MEMO_DATE" HeaderText="Rej Memo Date"></asp:BoundColumn>
										<asp:BoundColumn DataField="REJECTION_VALUE" HeaderText="Value of Qty Rejected"></asp:BoundColumn>
										<asp:BoundColumn DataField="REJECTION_REASON" HeaderText="Reason for Rejection"></asp:BoundColumn>
										<asp:BoundColumn DataField="REMARKS" HeaderText="Remarks">
											<HeaderStyle Width="8%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:HyperLinkColumn DataNavigateUrlField="COMP_DOC" DataTextField="TEMP_COMPLAINT_ID" NavigateUrl="COMP_DOC"></asp:HyperLinkColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></DIV>
							<P align="center">
								<asp:label id="lblError" runat="server" Width="384px" ForeColor="OrangeRed" Font-Bold="True"
									Font-Size="10pt" Font-Names="Verdana" Visible="False">NO ONLINE REJECTIONS FOUND !!!</asp:label></P>
							<asp:button id="btnCancel3" tabIndex="9" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel3_Click"></asp:button>
						</asp:panel>
						<P align="center">&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 50%" align="center">
						<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 70%" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD><asp:panel id="Panel2" runat="server" Width="100%" Height="1px" Visible="true">
										<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 31.74%" borderColor="#b0c4de" cellSpacing="0"
											cellPadding="0" bgColor="aliceblue" border="1">
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.2%; HEIGHT: 23px">
													<asp:label id="Label22" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Temp Rejection ID</asp:label></TD>
												<TD style="WIDTH: 0.03%; HEIGHT: 23px">
													<asp:label id="lblTempCompID" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana"></asp:label>&nbsp;
												</TD>
												<TD style="WIDTH: 14.16%; HEIGHT: 23px">
													<asp:label id="Label27" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Temp Rejection Date</asp:label></TD>
												<TD style="WIDTH: 12%; HEIGHT: 23px">
													<asp:label id="lblTempCompDt" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana"></asp:label>&nbsp;&nbsp;</TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.2%; HEIGHT: 23px">
													<asp:label id="Label12" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Book No</asp:label></TD>
												<TD style="WIDTH: 0.03%; HEIGHT: 23px">
													<asp:label id="txtBKNo" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">BK NO </asp:label>&nbsp;
													<asp:label id="lblCaseNo" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False">case no</asp:label></TD>
												<TD style="WIDTH: 14.16%; HEIGHT: 23px">
													<asp:label id="Label16" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana"> SET NO. </asp:label></TD>
												<TD style="WIDTH: 12%; HEIGHT: 23px">
													<asp:label id="txtSetNo" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Set No </asp:label>&nbsp;&nbsp;</TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.98%; HEIGHT: 29px">
													<asp:label id="Label13" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Contract No </asp:label></TD>
												<TD style="WIDTH: 0.03%; HEIGHT: 29px">
													<asp:label id="lblPONO" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana"></asp:label></TD>
												<TD style="WIDTH: 10.16%; HEIGHT: 29px">
													<asp:label id="Label18" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Date</asp:label></TD>
												<TD style="WIDTH: 15%; HEIGHT: 29px">
													<asp:label id="lblPODT" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">PO Date </asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.98%; HEIGHT: 29px">
													<asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">IC No.</asp:label></TD>
												<TD style="WIDTH: 0.03%; HEIGHT: 29px">
													<asp:label id="lblICNO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">IC No.</asp:label></TD>
												<TD style="WIDTH: 10.16%; HEIGHT: 29px">
													<asp:label id="Label11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">IC Date</asp:label></TD>
												<TD style="WIDTH: 15%; HEIGHT: 29px">
													<asp:label id="lblICDT" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">IC Date </asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.98%; HEIGHT: 29px">
													<asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Consignee</asp:label></TD>
												<TD style="WIDTH: 50.62%; HEIGHT: 29px" colSpan="3">
													<asp:label id="lblConsignee" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.98%; HEIGHT: 26px">
													<asp:label id="Label17" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Vendor</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
													<asp:label id="lblVend" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Vendor </asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.98%; HEIGHT: 26px">
													<asp:label id="Label23" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Inspecting Er.</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 26px" colSpan="3">
													<asp:label id="lblIE" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.98%; HEIGHT: 27px">
													<asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Item </asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 27px" colSpan="3">
													<asp:label id="lblITEM" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.98%; HEIGHT: 28px">
													<asp:label id="Label4" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Quantity as per IC</asp:label></TD>
												<TD style="WIDTH: 0.03%; HEIGHT: 28px">
													<asp:label id="lblQTYOFF" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
												<TD style="WIDTH: 12.16%; HEIGHT: 28px">
													<asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Quantity Rejected</asp:label></TD>
												<TD style="WIDTH: 19.24%; HEIGHT: 28px">
													<asp:label id="lblQTYREJ" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.98%; HEIGHT: 28px">
													<asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana"> Rejection Value</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 28px" colSpan="3">
													<asp:label id="lblREJValue" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.98%; HEIGHT: 28px">
													<asp:label id="Label15" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana"> Rejection Reason</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 28px" colSpan="3">
													<asp:label id="lblRejReason" runat="server" Width="90%" ForeColor="OrangeRed" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
											</TR>
											<TR bgColor="#ccccff">
												<TD style="WIDTH: 9.98%; HEIGHT: 28px">
													<asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana">Rejection Memo Document</asp:label></TD>
												<TD style="WIDTH: 30.43%; HEIGHT: 28px" colSpan="3">
													<asp:hyperlink id="HyperLink1" runat="server" NavigateUrl="\RBS\Calls_Marked.aspx">Download</asp:hyperlink></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 11.85%; HEIGHT: 26px" align="center" colSpan="4">
													<asp:button id="btnSave" tabIndex="7" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana" Text="Accept" onclick="btnSave_Click"></asp:button>&nbsp;&nbsp;&nbsp;
													<asp:button id="btnReject" tabIndex="10" runat="server" Width="76px" ForeColor="DarkBlue" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana" Text="Reject" onclick="btnReject_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:button id="btnCancel1" tabIndex="8" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel1_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 26px" vAlign="middle" align="left" width="70%" colSpan="4">
													<asp:label id="Label8" runat="server" ForeColor="#FF0066" Font-Bold="True" Font-Size="10pt"
														Font-Names="Verdana" Visible="False" Height="20%" Font-Underline="True">Reason for not accepting Rejection <BR>(250 CHARS ONLY)</asp:label>&nbsp;
													<asp:textbox id="txtRejReason" tabIndex="12" runat="server" Width="75%" ForeColor="Blue" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana" Visible="False" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 27px" vAlign="middle" align="center" width="70%" colSpan="4">
													<asp:button id="btnSaveReject" tabIndex="13" runat="server" Width="255px" ForeColor="DarkBlue"
														Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Visible="False" Text="Send Email For Rejected Complaints" onclick="btnSaveReject_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 697px; HEIGHT: 26px" vAlign="middle" align="left" width="697" bgColor="#ccccff"
													colSpan="2">
													<asp:label id="Label19" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False">Rejection Memo Id</asp:label>&nbsp;
													<asp:label id="lblComplaintId" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False"> -x-</asp:label></TD>
												<TD style="HEIGHT: 26px" vAlign="middle" align="left" width="70%" bgColor="#ccccff"
													colSpan="2">
													<asp:label id="Label20" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False">Rejection Memo Date</asp:label>&nbsp;&nbsp;
													<asp:label id="lblComplaintDt" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False"> -x-</asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 40px" vAlign="middle" align="left" width="70%" bgColor="#ccccff"
													colSpan="4">
													<asp:label id="Label21" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False">Joint Inspection Required</asp:label>&nbsp;&nbsp;&nbsp;
													<asp:dropdownlist id="lstJIRequired" runat="server" ForeColor="Blue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False" AutoPostBack="True" onselectedindexchanged="lstJIRequired_SelectedIndexChanged">
														<asp:ListItem Selected="True"></asp:ListItem>
														<asp:ListItem Value="Y">Yes</asp:ListItem>
														<asp:ListItem Value="N">No</asp:ListItem>
													</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:label id="Label14" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False">Region Doing Joint Inspection</asp:label>
													<asp:dropdownlist id="lstJiRegion" runat="server" ForeColor="Blue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False" AutoPostBack="True" onselectedindexchanged="lstJiRegion_SelectedIndexChanged">
														<asp:ListItem Selected="True"></asp:ListItem>
														<asp:ListItem Value="N">Northern Region</asp:ListItem>
														<asp:ListItem Value="E">Eastern Region</asp:ListItem>
														<asp:ListItem Value="W">Western Region</asp:ListItem>
														<asp:ListItem Value="S">Southern Region</asp:ListItem>
													</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
													&nbsp;&nbsp;&nbsp;
													<asp:label id="lblJiSrNo" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False">Joint Inspection Serial No. ->&nbsp</asp:label>
													<asp:label id="lblJiSno" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
														Visible="False"></asp:label>
													<asp:label id="lblJIDt" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
														Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 14.38%; HEIGHT: 18px" align="left" bgColor="#ccccff">
													<asp:label id="Label32" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False">Joint Inspection Engineer</asp:label></TD>
												<TD style="WIDTH: 538px; HEIGHT: 18px" bgColor="#ccccff">
													<asp:dropdownlist id="lstJIIE" runat="server" Width="90%" ForeColor="Blue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False"></asp:dropdownlist></TD>
												<TD style="HEIGHT: 18px" bgColor="#ccccff">
													<asp:label id="Label29" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
														Font-Names="Verdana" Visible="False">JI Date (Date on Which IE Will Attend JI)</asp:label></TD>
												<TD style="HEIGHT: 18px" bgColor="#ccccff">
													<asp:textbox id="txtJIFixDT" onblur="check_date(txtJIFixDT)" runat="server" ForeColor="Blue"
														Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 13px" vAlign="middle" align="left" width="70%" colSpan="4">
													<asp:label id="Label9" runat="server" Width="120px" ForeColor="#FF0066" Font-Bold="True" Font-Size="10pt"
														Font-Names="Verdana" Visible="False" Font-Underline="True">Reason for NO JI</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:dropdownlist id="lslNOJIReasons" tabIndex="6" runat="server" Width="30%" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Visible="False" Height="25px" AutoPostBack="True" onselectedindexchanged="lslNOJIReasons_SelectedIndexChanged">
														<asp:ListItem Value="A">DP Expired</asp:ListItem>
														<asp:ListItem Value="B">Validity of IC Expired</asp:ListItem>
														<asp:ListItem Value="C">Recieved in Damaged/Broken Condition</asp:ListItem>
														<asp:ListItem Value="D">Rejection &lt;5%</asp:ListItem>
														<asp:ListItem Value="E">Rejection issued after 90 Days of reciept of material</asp:ListItem>
														<asp:ListItem Value="F">Guarantee Claim</asp:ListItem>
														<asp:ListItem Value="G">Wrong Dispatch</asp:ListItem>
														<asp:ListItem Value="H">Material not stamped (partial/full)</asp:ListItem>
														<asp:ListItem Value="I">Material received in excess of ordered quantity</asp:ListItem>
														<asp:ListItem Value="J">Material lifted/rectified/replaced (Partially/Fully) before issue of Rejection Advice</asp:ListItem>
														<asp:ListItem Value="K">Reason(s) of rejection, beyond scope of inspection</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 19px" vAlign="middle" align="left" width="70%" colSpan="4">
													<asp:label id="Label24" runat="server" Width="176px" ForeColor="#FF0066" Font-Bold="True" Font-Size="10pt"
														Font-Names="Verdana" Visible="False" Font-Underline="True">Reason for NO JI Others</asp:label>
													<asp:textbox id="txtNoJIOthers" runat="server" Width="40%" ForeColor="Blue" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana" Visible="False" Height="20px" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 697px; HEIGHT: 23px" vAlign="middle" align="left" width="697" colSpan="4">&nbsp;&nbsp;
												</TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 26px" align="center" width="70%" colSpan="4">
													<asp:button id="btnSubmit" tabIndex="7" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True"
														Font-Size="8pt" Font-Names="Verdana" Text="Submit" onclick="btnSubmit_Click"></asp:button>&nbsp;
													<asp:button id="btnTempComp" tabIndex="7" runat="server" Width="371px" ForeColor="DarkBlue"
														Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Text="Proceed to View for Other Temporary Online Complaint" onclick="btnTempComp_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
			<DIV>&nbsp;</DIV>
			</TD></TR></TABLE></TD></TR></TABLE></form>
	</body>
</HTML>
