<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Complaint_Case_Detail_Search.aspx.cs" Inherits="RBS.Complaint_Case_Detail_Search.Complaint_Case_Detail_Search" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Complaint_Case_Detail_Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">		 
		function search()
		{
		 if(trimAll(document.Form1.txtPONo.value)=="" || (trimAll(document.Form1.txtPODate.value)=="" || document.Form1.lstClientType.value=="" || document.Form1.lstBPO_Rly.value==""))
		 {
			alert("PLEASE ENTER PO NO. AND PO DATE TO SEARCH");
			event.returnValue=false;
		 }
		 else
		 
		 return;			 
		}
		
		function makeUppercase()
		 {
			document.Form1.txtCaseNo.value = document.Form1.txtCaseNo.value.toUpperCase();
			
		 }
		 
		 function makeUppercasebk()
		 {
			document.Form1.txtBkNo.value = document.Form1.txtBkNo.value.toUpperCase();
			
		 }
		
		function change()
		{
			var d=document.Form1.txtSetNo.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="00" + d;
				document.Form1.txtSetNo.value=d;
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="0" + d;
				document.Form1.txtSetNo.value=d;
				event.returnValue=false;
			}
			return false;	
		}
		
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 184px"
				cellSpacing="1" cellPadding="1" border="0">
				<TBODY>
					<TR>
						<TD colSpan="3">
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
									Width="197px" Font-Bold="True" Height="19px" BackColor="White"> CONSIGNEE COMPLAINTS</asp:label></P>
						</TD>
					</TR>
					<TR>
						<td style="WIDTH: 100%" colSpan="3">
							<P align="center"><asp:panel id="Panel_1" runat="server" Width="100%" Height="1px" Visible="true">
									<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1"
										cellPadding="1" width="935" border="1">
										<TR>
											<TD style="WIDTH: 12.28%; HEIGHT: 32px" align="center" bgColor="#ccccff" colSpan="4"><asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
													Width="80px" Font-Bold="True">SEARCH</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 20.5%; HEIGHT: 32px" bgColor="#ffcccc"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%" Font-Bold="True"> PO/Offer Letter No.</asp:label></TD>
											<TD style="WIDTH: 44.03%; HEIGHT: 32px" align="left"><asp:textbox id="txtPONo" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="80%" Height="20px" BackColor="White"></asp:textbox></TD>
											<TD style="WIDTH: 11.05%; HEIGHT: 32px" bgColor="#ffcccc"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="54px" Font-Bold="True">PO Date</asp:label></TD>
											<TD style="WIDTH: 15%; HEIGHT: 32px"><asp:textbox id="txtPODate" onblur="check_date(txtPODate);" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="60%" Height="20px" BackColor="White" MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 100%" align="center" colSpan="4"><asp:button id="btnSearchPO" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="83px" Font-Bold="True" Text="Search" onclick="btnSearchPO_Click"></asp:button>&nbsp;&nbsp;
												<asp:button id="btnCancel" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="83px" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:label id="lblSearchStatus" runat="server" ForeColor="White">Label</asp:label></TD>
										</TR>
									</TABLE></P>
							</asp:panel></td>
					</TR>
					<asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 50px" runat="server"
						Width="100%" Height="1px" Visible="False">
						<TR>
							<TD style="WIDTH: 100%" align="center" width="45%">
								<TABLE id="Table2" borderColor="#b0c4de" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD style="HEIGHT: 51px" align="center" bgColor="#ccccff" colSpan="3">
											<asp:label id="Label2" runat="server" Font-Bold="True" Width="318px" ForeColor="DarkBlue" Font-Size="10pt"
												Font-Names="Verdana">REGISTER NEW Complaint</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40%; HEIGHT: 35px" align="center" bgColor="#ffcccc">
											<asp:label id="Label5" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Case No.</asp:label></TD>
										<TD style="WIDTH: 30%; HEIGHT: 35px" align="center" bgColor="#ffcccc">
											<asp:label id="Label6" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Book No.</asp:label></TD>
										<TD style="WIDTH: 30%; HEIGHT: 35px" align="center" bgColor="#ffcccc">
											<asp:label id="Label7" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Set No.</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40%; HEIGHT: 6px" align="center">
											<asp:textbox id="txtCaseNo" onblur="makeUppercase();" runat="server" Width="60%" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" MaxLength="9"></asp:textbox><FONT face="Verdana" color="darkblue" size="2"></FONT></TD>
										<TD style="WIDTH: 30%; HEIGHT: 6px" align="center">
											<asp:textbox id="txtBkNo" onblur="makeUppercasebk();" runat="server" Width="60%" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" MaxLength="4"></asp:textbox><FONT face="Verdana" color="darkblue" size="2"></FONT></TD>
										<TD style="WIDTH: 30%; HEIGHT: 6px" align="center">
											<asp:textbox id="txtSetNo" onblur="change();" runat="server" Width="50px" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" MaxLength="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 6px" align="center" colSpan="3">
											<asp:button id="btnProceed1" runat="server" Font-Bold="True" Width="78px" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Text="Proceed ->" onclick="btnProceed1_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 6px" align="center" colSpan="3">
											<asp:label id="Label11" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
												Font-Size="8pt" Font-Names="Verdana">In Case the above information is not available </asp:label>
											<asp:button id="btnS1" runat="server" Font-Bold="True" Width="83px" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Text="Click Here" onclick="btnS1_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</TD>
							<TD width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							</TD>
							<TD style="WIDTH: 100%" align="center" width="45%">
								<TABLE id="Table3" borderColor="#b0c4de" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD style="HEIGHT: 51px" align="center" bgColor="#ccccff" colSpan="3">
											<asp:label id="Label8" runat="server" Font-Bold="True" Width="318px" ForeColor="DarkBlue" Font-Size="10pt"
												Font-Names="Verdana"> MODIFY EXISTING Complaint</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 7.74%; HEIGHT: 35px" align="center" bgColor="#ffcccc" colSpan="3">
											<asp:label id="Label9" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Complaint ID.</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40%; HEIGHT: 6px" align="center" colSpan="3">
											<asp:textbox id="txtCompID" onblur="makeUppercase();" style="TEXT-ALIGN: center" runat="server"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="12"></asp:textbox><FONT face="Verdana" color="darkblue" size="2"></FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40%; HEIGHT: 6px" align="center" colSpan="3">
											<asp:button id="btnProceed2" runat="server" Font-Bold="True" Width="78px" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Text="Proceed ->" onclick="btnProceed2_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 40%; HEIGHT: 6px" align="center" colSpan="3">
											<asp:label id="Label12" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
												Font-Size="8pt" Font-Names="Verdana">In Case the above information is not available -</asp:label>
											<asp:button id="btnS2" runat="server" Font-Bold="True" Width="83px" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Text="Click Here" onclick="btnS2_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</asp:panel>
					<TR>
						<TD style="WIDTH: 100%" colSpan="3"></TD>
					</TR>
					<asp:panel id="Panel_3" runat="server" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 275px"
						Width="100%" Height="1px" Visible="False">
						<TR>
							<TD style="WIDTH: 100%" colSpan="4">
								<DIV>
									<asp:label id="lblICDetails" style="TEXT-ALIGN: center" runat="server" Font-Bold="True" Width="100%"
										ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana">IC Details against Given PO No. & Po Date <font color="red" size="1px">
											( Click on Select to register new Complaint against the given IC )</font></asp:label>
									<TITTLE:CUSTOMDATAGRID id="DgCompCaseSearch" runat="server" Height="8px" Width="100%" Visible="False" GridHeight="250px"
										FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
										CellPadding="1" FreezeRows="0" BorderColor="DarkBlue" PageSize="15" AutoGenerateColumns="False">
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
													<asp:HyperLink id="Hyperlink1" Runat="server" NavigateUrl='<%#"complaint_Entry.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;BK_NO=" + DataBinder.Eval(Container.DataItem,"BK_NO")+"&amp;SET_NO=" + DataBinder.Eval(Container.DataItem,"SET_NO")%>'>Select</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="CASE_NO" HeaderText="Case Number">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="BK_NO" HeaderText="Bk No.">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SET_NO" HeaderText="Set No.">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PO_NO" HeaderText="Purchase Order Number">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PO_DT" HeaderText="Purchase Order Date">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RLY_CD" HeaderText="Agency">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="VEND_NAME" HeaderText="Vendor">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CONSIGNEE" HeaderText="Consignee">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IC_NO" HeaderText="IC No.">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IC_DATE" HeaderText="IC Date">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</TITTLE:CUSTOMDATAGRID>
									<asp:label id="lblCompDetails" style="TEXT-ALIGN: center" runat="server" Font-Bold="True" Width="100%"
										ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana">Complaint Details against Given PO No. & Po Date <font color="red" size="1px">
											( Click on Complaint ID to modify the existing complaint against the given IC )</font></asp:label></DIV>
								<DIV>
									<TITTLE:CUSTOMDATAGRID id="DGCompMod" runat="server" Height="8px" Width="100%" Visible="False" GridHeight="250px"
										FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
										CellPadding="1" FreezeRows="0" BorderColor="DarkBlue" PageSize="15" AutoGenerateColumns="False">
										<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
										<EditItemStyle Height="10%"></EditItemStyle>
										<FooterStyle CssClass="GridHeader"></FooterStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
										<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
											CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="Complaint ID">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemTemplate>
													<asp:HyperLink id="Hyperlink2" Runat="server" Text=' <%# DataBinder.Eval(Container.DataItem,"COMPLAINT_ID")%>' NavigateUrl='<%#"complaint_Entry.aspx?COMPLAINT_ID=" + DataBinder.Eval(Container.DataItem,"COMPLAINT_ID")%>'>
													</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="JI_SNO" HeaderText="JI Unique Sno"></asp:BoundColumn>
											<asp:BoundColumn DataField="CASE_NO" HeaderText="Case Number">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="BK_NO" HeaderText="Bk No.">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SET_NO" HeaderText="Set No.">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PO_NO" HeaderText="Po No.">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PO_DT" HeaderText="Po Date">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IC_NO" HeaderText="IC No.">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IC_DATE" HeaderText="IC Date">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="REJ_MEMO_NO" HeaderText="Rejection Memo No.">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="REJ_MEMO_DATE" HeaderText="Rejection Memo Date">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</TITTLE:CUSTOMDATAGRID></DIV>
							</TD>
						</TR>
					</asp:panel></TBODY></TABLE>
		</form>
	</body>
</HTML>