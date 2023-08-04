<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_Daily_Work_Plan.aspx.cs" Inherits="RBS.IE_Daily_Work_Plan.IE_Daily_Work_Plan" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IE_Daily_Work_Plan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function txtCopy()
		{
			
			if(check_date(document.Form1.frmDt)==true && trimAll(document.Form1.toDt.value)=="")
			{
				document.Form1.toDt.value=document.Form1.frmDt.value;
			}
			
		}
		
		function validate()
		{
			if(trimAll(document.Form1.lstNIWork_CD.value)=="")
			{
				alert("Non Inspection Work Plan Cannot be Left Blank!!!");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.lstNIWork_CD.value)=="X" && trimAll(document.Form1.txtOtherDesc.value)=="")
			{
				alert("Plz Enter The Description in case of Others!!!");
				event.returnValue=false;
				
			}
			else if(trimAll(document.Form1.toDt.value)=="")
			{
				alert("You Cannot Leave TO Date Blank!!!");
				event.returnValue=false;
			}
		
		}
		
		function validate1()
		{
			if(trimAll(document.Form1.txtReason.value)=="")
			{
				alert("Reason of Not Entering Work Plan Cannot be Left Blank!!!");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtReason.value)!="" && document.Form1.txtReason.value.length > 250)
			{
				alert("Enter The Reason of Not Entering Work Plan within 250 Characters!!!");
				event.returnValue=false;
				
			}
		}

        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 32px" align="center">
							<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 35px" align="center"><asp:label id="Label1" runat="server" Width="177px" BackColor="White" Font-Names="Verdana"
								Font-Size="10pt" ForeColor="DarkBlue" Font-Bold="True"> IE DAILY WORK PLAN</asp:label></td>
					</tr>
					<TR>
						<TD style="HEIGHT: 26px" vAlign="middle" align="left"><asp:label id="Label12" runat="server" Width="168px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								Font-Bold="True">Reason for Not Entering WorkPlan of Date:</asp:label><asp:label id="lblNWPDate" runat="server" Width="72px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="Crimson" Font-Bold="True"></asp:label><asp:textbox id="txtReason" runat="server" Width="344px" TextMode="MultiLine"></asp:textbox>&nbsp;&nbsp;&nbsp;
							<asp:button id="btnSaveReason" runat="server" Width="66px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Text="Save" onclick="btnSaveReason_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 26px" align="center"><asp:label id="Label2" runat="server" Width="114px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								Font-Bold="True">Work Plan Dated:</asp:label><asp:radiobutton id="rdbCurrDt" runat="server" Width="153px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="darkblue" Font-Bold="True" Checked="True" GroupName="G1" AutoPostBack="True" oncheckedchanged="rdbCurrDt_CheckedChanged"></asp:radiobutton>&nbsp;
							<asp:radiobutton id="rdbTomDt" runat="server" Width="153px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="darkblue" Font-Bold="True" GroupName="G1" AutoPostBack="True" oncheckedchanged="rdbCurrDt_CheckedChanged"></asp:radiobutton><asp:label id="txtWPDate" runat="server" Width="102px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="Crimson" Font-Bold="True" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 21px" align="center">
							<P><asp:radiobutton id="rdbInspWork" runat="server" Width="153px" Font-Names="Verdana" Font-Size="X-Small"
									ForeColor="darkblue" Font-Bold="True" Text="Inspection Work  " GroupName="grpRegion" AutoPostBack="True" oncheckedchanged="rdbInspWork_CheckedChanged"></asp:radiobutton></P>
							<P><asp:radiobutton id="rdbNonInspWork" runat="server" Font-Names="Verdana" Font-Size="X-Small" ForeColor="darkblue"
									Font-Bold="True" Text="Non Inspection Work" GroupName="grpRegion" AutoPostBack="True" oncheckedchanged="rdbInspWork_CheckedChanged"></asp:radiobutton></P>
							<P><asp:label id="Label11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="Crimson"
									Font-Bold="True">Enter the Daily Work Plan (DWP) for Calls a day in advance  latest by 1500 HRS.</asp:label></P>
						</TD>
					</TR>
					<asp:panel id="Panel1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
						Width="100%" Visible="False" Height="1px">
						<TR>
							<TD style="HEIGHT: 21px" align="center">
								<asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="Crimson" Font-Size="8pt"
									Font-Names="Verdana" Width="100%">Select Calls to Visit from the following list For the Day. (Select Maximum of 3 different Vendors / 5 Calls of Same Vendor)</asp:label></TD>
						</TR>
						<TR>
							<TD align="center">
								<DIV>
									<TITTLE:CUSTOMDATAGRID id="grdDWPlan" runat="server" Width="100%" Visible="False" Height="8px" HorizontalAlign="Left"
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
											<asp:TemplateColumn>
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemTemplate>
													<asp:HyperLink id=Hyperlink1 Target=_blank Text='View Call' Runat="server" NavigateUrl='<%#"Print_Call_letter.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;CALL_DT=" + DataBinder.Eval(Container.DataItem,"CALL_RECV_DATE") +"&amp;CALL_SNO=" + DataBinder.Eval(Container.DataItem,"CALL_SNO")%>'>
													</asp:HyperLink>
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
										</Columns>
									</TITTLE:CUSTOMDATAGRID></DIV>
								<P>&nbsp;</P>
							</TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 36px" align="center">
								<P>
									<asp:label id="Label13" runat="server" Font-Bold="True" ForeColor="DarkMagenta" Font-Size="8pt"
										Font-Names="Verdana" Width="100%">Plz Check all the Calls Carefully Before Proceeding !!!</asp:label>
									<asp:button id="btnSave" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="66px" Text="Save" onclick="btnSave_Click"></asp:button></P>
							</TD>
						</TR>
						<TR>
							<TD align="center">
								<asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="Crimson" Font-Size="8pt"
									Font-Names="Verdana" Width="378px">Calls Already Added in Daily Work Plan For the Day.</asp:label></TD>
						</TR>
						<TR>
							<TD align="center">
								<TITTLE:CUSTOMDATAGRID id="grdDWPlan1" runat="server" Width="100%" Height="8px" HorizontalAlign="Left"
									PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
									BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="200px" GridWidth="90%" AutoGenerateColumns="False"
									BorderColor="DarkBlue">
									<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
									<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
									<EditItemStyle Height="10%"></EditItemStyle>
									<FooterStyle CssClass="GridHeader"></FooterStyle>
									<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
									<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%"
										ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn>
											<HeaderStyle Width="5%"></HeaderStyle>
											<ItemTemplate>
												<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="VISIT_DATE" HeaderText="Visit Date"></asp:BoundColumn>
										<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
											<HeaderStyle Width="10%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CALL_RECV_DATE" HeaderText="Call Date">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CALL_SNO" HeaderText="Call SNo.">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="MFG" HeaderText="Manufacturer">
											<HeaderStyle Width="25%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="MFG_PLACE" HeaderText="Manufacturer Place">
											<HeaderStyle Width="30%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="MFG_CITY" HeaderText="Manufacturer City">
											<HeaderStyle Width="20%"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></TD>
						</TR>
						<TR>
							<TD align="center">
								<asp:button id="btnDelete" tabIndex="4" runat="server" Font-Bold="True" ForeColor="DarkBlue"
									Font-Size="8pt" Font-Names="Verdana" Width="66px" Text="Delete" onclick="btnDelete_Click"></asp:button></TD>
						</TR>
					</asp:panel><asp:panel id="Panel2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
						Width="100%" Visible="False" Height="1px">
						<TR>
							<TD>
								<TABLE id="Table2" borderColor="#b0c4de" cellSpacing="1" cellPadding="1" width="100%" bgColor="#f0f8ff"
									border="1">
									<TR>
										<TD style="WIDTH: 20%; HEIGHT: 34px">
											<asp:label id="Label5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Width="114px">Non Inspection Work Plan</asp:label></TD>
										<TD style="WIDTH: 30%; HEIGHT: 34px">
											<asp:dropdownlist id="lstNIWork_CD" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Width="90%" AutoPostBack="True" Height="25px" onselectedindexchanged="lstNIWork_CD_SelectedIndexChanged"></asp:dropdownlist></TD>
										<TD style="WIDTH: 20%; HEIGHT: 34px">
											<asp:label id="Label9" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Width="114px">NI Work Plan Others Desc</asp:label></TD>
										<TD style="WIDTH: 30%; HEIGHT: 34px">
											<asp:TextBox id=txtOtherDesc runat="server" ForeColor="#0000C0" BackColor="White" Width="100%" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container, "DataItem.IE_ACTION") %>' BorderStyle="Inset">
											</asp:TextBox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 20%; HEIGHT: 34px">
											<asp:label id="Label6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Width="120px">For The Period</asp:label></TD>
										<TD style="HEIGHT: 34px" colSpan="3">
											<asp:label id="Label8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Width="42px">From</asp:label>
											<asp:textbox id="frmDt" onblur="check_date(frmDt);txtCopy();" style="TEXT-ALIGN: center" runat="server"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="20%" Height="20px" MaxLength="10"></asp:textbox>
											<asp:label id="Label7" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Width="42px">To</asp:label>
											<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
												style="TEXT-ALIGN: center" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Width="20%" Height="20px" MaxLength="10"></asp:textbox>
											<asp:label id="Label10" runat="server" Font-Bold="True" ForeColor="DarkMagenta" Font-Size="8pt"
												Font-Names="Verdana" Width="100%">* Enter Date in (DD/MM/YYYY) Format.</asp:label></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 24px" align="center" colSpan="4">
											<asp:button id="btnSaveNI" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Text="Save" onclick="btnSaveNI_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="4">
											<TITTLE:CUSTOMDATAGRID id="grdDWPlan2" runat="server" Width="100%" Visible="False" Height="8px" HorizontalAlign="Left"
												PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
												BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="200px" GridWidth="90%" AutoGenerateColumns="False"
												BorderColor="DarkBlue">
												<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
												<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
												<EditItemStyle Height="10%"></EditItemStyle>
												<FooterStyle CssClass="GridHeader"></FooterStyle>
												<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
												<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%"
													ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="NI_WORK_PLAN_CD" HeaderText="NI Work Plan"></asp:BoundColumn>
													<asp:BoundColumn DataField="FROM_DATE" HeaderText="NI Work Date"></asp:BoundColumn>
												</Columns>
											</TITTLE:CUSTOMDATAGRID></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</asp:panel></TBODY></TABLE>
		</form>
		</FORM>
	</body>
</HTML>
