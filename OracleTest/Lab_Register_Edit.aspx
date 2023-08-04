<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab_Register_Edit.aspx.cs" Inherits="RBS.Lab_Register_Edit.Lab_Register_Edit" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lab_Register_Edit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtLabRegNo.value)=="")
		{
		 alert("LAB REGISTRATION NO.CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else
		return;
	 
		}
		function makeUppercase()
		 {
			document.Form1.txtCaseNo.value = document.Form1.txtCaseNo.value.toUpperCase();
			
		 }
		 
		function makeUppercaseLab()
		 {
			document.Form1.txtLabRegNo.value = document.Form1.txtLabRegNo.value.toUpperCase();
			
		 } 
		function validate1()
		{
		if(trimAll(document.Form1.txtCaseNo.value)=="" || trimAll(document.Form1.txtRdt.value)=="" || trimAll(document.Form1.txtCSNO.value)=="")
		{
		 alert("CASE NO. , CALL DATE AND CALL CANNOT BE LEFT BLANK IN CASE OF NEW IC");
		 event.returnValue=false;
		}
		else if(isNaN(parseInt(trimAll(document.Form1.txtCSNO.value))))
		{
		 alert("CALL SNO. CONTAINS INVALID CHARACTERS!!!");
		 event.returnValue=false;
		}
		else
		return;
		}
		
		function validate3()
		{
		if(trimAll(document.Form1.txtCaseNo.value)=="" && trimAll(document.Form1.txtRdt.value)=="" && trimAll(document.Form1.txtLabRegNo.value)=="")
		{
		 alert("ENTER CASE NO. OR CALL DATE OR LAB REGISTRATION NO. TO SEARCH RECORDS");
		 event.returnValue=false;
		}
		
		else
		return;
		}
		
		function sFocus()
		 {
		 
		 document.Form1.txtBKNo.focus();
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
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 35px" align="center" colSpan="6" height="35">
						<P>
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 51px" align="center" bgColor="#ccccff" colSpan="2"><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="310px">UPDATE LAB REGISTER</asp:label></TD>
					<TD style="WIDTH: 241px; HEIGHT: 35px" bgColor="#ffffff"></TD>
					<TD style="HEIGHT: 51px" align="center" bgColor="#ccccff" colSpan="3"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="318px">NEW LAB REGISTER ENTRY</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 7.74%; HEIGHT: 32px" align="center" bgColor="#ffcccc" colSpan="2">
						<asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Lab Registration No.</asp:label></TD>
					<TD style="WIDTH: 241px; HEIGHT: 32px" bgColor="#ffffff"></TD>
					<TD style="WIDTH: 8.7%; HEIGHT: 32px" align="center" bgColor="#f0f8ff"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Case No.</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 32px" align="center" bgColor="#f0f8ff"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Call Recieve Date</asp:label></TD>
					<TD style="WIDTH: 10%; HEIGHT: 32px" align="center" bgColor="#f0f8ff"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Call SNO.</asp:label></TD>
				</TR>
				<tr>
					<TD style="WIDTH: 16.15%; HEIGHT: 37px" align="center" bgColor="#ffcccc" colSpan="2">
						<asp:textbox id="txtLabRegNo" onblur="makeUppercaseLab();" tabIndex="8" runat="server" Width="70%"
							ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="9" Height="20px"></asp:textbox></TD>
					<TD style="WIDTH: 241px" bgColor="#ffffff"></TD>
					<TD style="WIDTH: 17.46%; HEIGHT: 37px" align="center" bgColor="#f0f8ff"><asp:textbox id="txtCaseNo" onblur="makeUppercase();" tabIndex="6" runat="server" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="104px" Height="20px" MaxLength="9"></asp:textbox></TD>
					<TD style="WIDTH: 20%; HEIGHT: 37px" align="center" bgColor="#f0f8ff"><asp:textbox id="txtRdt" onblur="check_date(txtRdt);" tabIndex="7" runat="server" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="104px" Height="20px" MaxLength="10"></asp:textbox></TD>
					<TD style="WIDTH: 10%; HEIGHT: 37px" align="center" bgColor="#f0f8ff"><asp:textbox id="txtCSNO" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Width="70%" Height="20px" MaxLength="5"></asp:textbox></TD>
				</tr>
				<tr>
					<td style="HEIGHT: 36px" align="center" bgColor="#ffcccc" colSpan="2"><asp:button id="btnMod" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="67px" Text="Modify" onclick="btnMod_Click"></asp:button></td>
					<TD style="WIDTH: 241px; HEIGHT: 36px" bgColor="#ffffff"></TD>
					<td style="HEIGHT: 36px" align="center" bgColor="#f0f8ff" colSpan="3"><asp:button id="btnAdd" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="112px" Text="Add New" onclick="btnAdd_Click"></asp:button></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 35px" align="center" bgColor="white" colSpan="2"></TD>
					<TD style="WIDTH: 241px; HEIGHT: 35px" align="center" bgColor="#ccccff"><asp:button id="btnSearch" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Width="112px" Text="Search" onclick="btnSearch_Click"></asp:button></TD>
					<TD style="HEIGHT: 35px" align="center" bgColor="white" colSpan="3"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="6">
						<asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">Search Result is Sorted on [Call Date]</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><PAGERSTYLE ForeColor="Blue" Mode="NumericPages" HorizontalAlign="Center">
							<TITTLE:CUSTOMDATAGRID id="grdLAB" runat="server" Width="90%" Height="8px" PageSize="15" FreezeRows="0"
								CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
								BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="200px"
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
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"Lab_Register_Edit.aspx?REG_NO=" + DataBinder.Eval(Container.DataItem,"SAMPLE_REG_NO")+ "&amp;CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO")+ "&amp;CALL_RECV_DT=" + DataBinder.Eval(Container.DataItem,"CALL_RECV_DATE")+ "&amp;CALL_SNO=" + DataBinder.Eval(Container.DataItem,"CALL_SNO")%>'>Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="SAMPLE_REG_NO" HeaderText="Sample Reg No.">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_RECV_DATE" HeaderText="Call Date">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_SNO" HeaderText="Call SNo.">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IE_SNAME" HeaderText="IE">
										<HeaderStyle Width="25%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CALL_STATUS" HeaderText="Status"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID>
						</PAGERSTYLE><ALTERNATINGITEMSTYLE Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></ALTERNATINGITEMSTYLE><EDITITEMSTYLE Height="10%"></EDITITEMSTYLE><FOOTERSTYLE CssClass="GridHeader"></FOOTERSTYLE><ITEMSTYLE Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ITEMSTYLE><HEADERSTYLE ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Height="15%"
							CssClass="GridHeader" BackColor="InactiveCaptionText"></HEADERSTYLE><COLUMNS>
							<ASP:TEMPLATECOLUMN HeaderText="Select">
								<HEADERSTYLE Width="10%"></HEADERSTYLE>
								<ITEMTEMPLATE></ITEMTEMPLATE>
							</ASP:TEMPLATECOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Bill Status" DataField="STATUS">
								<HEADERSTYLE Width="21%"></HEADERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Case No." DataField="CASE_NO">
								<HEADERSTYLE Width="15%"></HEADERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Call Date" DataField="CALL_RECV_DT">
								<HEADERSTYLE Width="10%"></HEADERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Call SNo." DataField="CALL_SNO">
								<HEADERSTYLE Width="7%"></HEADERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="IE" DataField="IE_SNAME">
								<HEADERSTYLE Width="7%"></HEADERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="IC NO" DataField="IC_NO">
								<HEADERSTYLE Width="15%"></HEADERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Book No" DataField="BK_NO">
								<HEADERSTYLE Width="8%"></HEADERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Set No." DataField="SET_NO">
								<HEADERSTYLE Width="7%"></HEADERSTYLE>
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Consignee" DataField="CONSIGNEE"></ASP:BOUNDCOLUMN>
						</COLUMNS></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

