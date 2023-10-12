<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Remark_Form.aspx.cs" Inherits="RBS.Call_Remark_Form.Call_Remark_Form" %>


<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Call_Remark_Form</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		
		function validate()
		{
			if(trimAll(document.Form1.lstCO.value)=="")
			{
				alert("Controlling Officer can not Be left blank!!!");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.lstIE.value)=="")
			{
				alert("Inspection Engineer can not Be left blank!!!");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.Dropdownlist1.value)=="")
			{
				alert("Remarking to Inspection Engineer can not Be left blank!!!");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txt_Reason.value)=="")
			{
				alert("Remarking Reason can not be left blank!!!");
				event.returnValue=false;
				
			}
			else if(trimAll(document.Form1.txt_Reason.value)!="" && document.Form1.txt_Reason.value.length > 400)
			{
				alert("Enter The Reason of Remarking within 400 Characters Or Reason of Marking can not be left blank!!!");
				event.returnValue=false;
				
			}
		}

        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 50px" id="Table1"
				border="1" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TBODY>
					<TR align="center">
						<TD colSpan="2"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 46px" colSpan="2" align="center"><asp:label id="Label1" runat="server" Width="100%" BackColor="White" Font-Bold="True" Font-Size="10pt"
								Font-Names="Verdana" ForeColor="DarkBlue" Height="19px">IE WISE CALL REMARKED</asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 20%; HEIGHT: 25px"><FONT color="darkblue" size="2" face="Verdana"><asp:label id="lblIE" runat="server" Width="152px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
									ForeColor="DarkBlue">Controlling Officer </asp:label></FONT></TD>
						<TD style="WIDTH: 80%; HEIGHT: 25px"><FONT color="darkblue" size="2" face="Verdana"><asp:dropdownlist id="lstCO" tabIndex="1" runat="server" Width="40%" Font-Size="8pt" Font-Names="Verdana"
									ForeColor="DarkBlue" Height="25px" AutoPostBack="True" onselectedindexchanged="lstCO_SelectedIndexChanged"></asp:dropdownlist></FONT></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 20%; HEIGHT: 25px"><asp:label id="Label2" runat="server" Width="152px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">Inspection Engineer</asp:label></TD>
						<TD style="WIDTH: 80%; HEIGHT: 25px"><asp:dropdownlist id="lstIE" tabIndex="4" runat="server" Height="20px" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" Width="50%" AutoPostBack="True" onselectedindexchanged="lstIE_SelectedIndexChanged"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 20%; HEIGHT: 25px"><asp:label id="Label6" runat="server" Width="152px" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana"
								ForeColor="DarkBlue">No of Pending Calls From IE</asp:label></TD>
						<TD style="WIDTH: 80%; HEIGHT: 25px"><asp:label id="Label_FR_Pending" runat="server" Width="100px" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana" ForeColor="Crimson"></asp:label></TD>
					</TR>
					<asp:panel style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" id="Panel2" runat="server"
						Width="100%" Height="1px" Visible="False">
						<TR>
							<TD align="center" colSpan="2">
								<asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" Width="400px">List of No of Pending Calls From IE</asp:label></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">
								<DIV>
									<TITTLE:CUSTOMDATAGRID id="grdDWPlan" runat="server" Height="8px" Width="100%" Visible="False" HorizontalAlign="Left"
										PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
										BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="300px" GridWidth="90%" AutoGenerateColumns="False"
										BorderColor="DarkBlue">
										<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
										<EditItemStyle Height="10%"></EditItemStyle>
										<FooterStyle CssClass="GridHeader"></FooterStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Verdana" HorizontalAlign="Center" Height="20px" CssClass="GridNormal"></ItemStyle>
										<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" Height="15%"
											ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemTemplate>
													<asp:CheckBox id="chkDWplan" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
												<HeaderStyle Width="7%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CALL_RECV_DATE" HeaderText="Call Date">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CALL_SNO" HeaderText="Call SNo.">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CALL_STATUS" HeaderText="Call Status">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MFG" HeaderText="Manufacturer">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="MFG_CD" HeaderText="MFG_CD"></asp:BoundColumn>
											<asp:BoundColumn DataField="MFG_PLACE" HeaderText="Manufacturer Place">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MFG_CITY" HeaderText="Manufacturer City">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="MFG_CITY_CD" HeaderText="MFG_CITY_CD"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="CO_CD" HeaderText="CO_CD"></asp:BoundColumn>
											<asp:BoundColumn DataField="DESIRE_DT" HeaderText="Desire Dt"></asp:BoundColumn>
											<asp:BoundColumn DataField="CALL_REMARK_STATUS" HeaderText="CALL REMARK STATUS"></asp:BoundColumn>
										</Columns>
									</TITTLE:CUSTOMDATAGRID></DIV>
								<P>&nbsp;</P>
							</TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">
								<asp:label id="Label4" runat="server" ForeColor="Crimson" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" Width="378px" Visible="False">No Record Found</asp:label></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">
								<asp:label id="Label9" runat="server" ForeColor="Crimson" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" Width="600px">*** Proposed for remarking should be posted by 14:30 - hrs for same date. ***</asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 20%; HEIGHT: 25px">
								<asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" Width="152px">Remarking To Inspection Engineer</asp:label></TD>
							<TD style="WIDTH: 80%; HEIGHT: 25px">
								<asp:dropdownlist id="Dropdownlist1" tabIndex="4" runat="server" Height="20px" ForeColor="DarkBlue"
									Font-Names="Verdana" Font-Size="8pt" Width="60%" AutoPostBack="True" onselectedindexchanged="Dropdownlist1_SelectedIndexChanged"></asp:dropdownlist></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 20%; HEIGHT: 25px">
								<asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" Width="378px">No of Pending Calls To IE</asp:label></TD>
							<TD style="WIDTH: 80%; HEIGHT: 25px">
								<asp:label id="Label_To_Pending" runat="server" ForeColor="Crimson" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" Width="152px"></asp:label></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 20%; HEIGHT: 25px">
								<asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" Width="152px">REASON OF CALL MARKING</asp:label></TD>
							<TD style="WIDTH: 80%; HEIGHT: 25px">
								<asp:textbox id="txt_Reason" Height="50" Width="100%" Runat="server" TextMode="MultiLine" MaxLength="400"></asp:textbox></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">
								<asp:Button id="btnSubmit" tabIndex="7" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									BackColor="#C0C0FF" Text="Submit" onclick="btnSubmit_Click"></asp:Button></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">
								<DIV>
									<TITTLE:CUSTOMDATAGRID id="grid_Sub" runat="server" Height="8px" Width="100%" Visible="False" HorizontalAlign="Left"
										PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
										BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="300px" GridWidth="90%" AutoGenerateColumns="False"
										BorderColor="DarkBlue">
										<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
										<EditItemStyle Height="10%"></EditItemStyle>
										<FooterStyle CssClass="GridHeader"></FooterStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Verdana" HorizontalAlign="Center" Height="20px" CssClass="GridNormal"></ItemStyle>
										<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" Height="15%"
											ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="case_no" HeaderText="Case No.">
												<HeaderStyle Width="7%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CALL_RECV_DT" HeaderText="Call Date">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="call_sno" HeaderText="Call SNo.">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="remarking_status" HeaderText="Call Status">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ie_name_from" HeaderText="From IE">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ie_name_to" HeaderText="To IE">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="user_name" HeaderText="Initiated By">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="LOGIN_TIME" HeaderText="Initiated DateTime">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</TITTLE:CUSTOMDATAGRID></DIV>
								<P>&nbsp;</P>
							</TD>
						</TR>
					</asp:panel></TBODY></TABLE>
		</form>
	</body>
</HTML>
