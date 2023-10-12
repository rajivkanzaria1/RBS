<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Correction_To_Inspection_Certificate_Edit_Form.aspx.cs" Inherits="RBS.Correction_To_Inspection_Certificate_Edit_Form.Correction_To_Inspection_Certificate_Edit_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>INSPECTION CERTIFICATE FORM</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtBKNo.value)=="" || trimAll(document.Form1.txtSetNo.value)=="")
		{
		 alert("BOOK NO. AND SET NO.CANNOT BE LEFT BLANK");
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
			document.Form1.txtBKNo.value = document.Form1.txtBKNo.value.toUpperCase();
			
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
		if(trimAll(document.Form1.txtCaseNo.value)=="" && trimAll(document.Form1.txtRdt.value)=="" && trimAll(document.Form1.txtBKNo.value)=="" && trimAll(document.Form1.txtSetNo.value)=="")
		{
		 alert("ENTER CASE NO. OR CALL DATE OR BK NO. OR SET NO. TO SEARCH RECORDS");
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
	<BODY bgColor="white" onload=" sFocus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 35px" align="center" colSpan="6" height="35">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 51px" align="center" bgColor="#ccccff" colSpan="2"><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="310px">IF INSPECTION CERTIFICATE IS BILLED</asp:label></TD>
					<TD style="WIDTH: 162px; HEIGHT: 35px" bgColor="#ffffff"></TD>
					<TD style="HEIGHT: 51px" align="center" bgColor="#ccccff" colSpan="3"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="318px">IF INSPECTION CERTIFICATE IS NOT BILLED</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 7.74%; HEIGHT: 35px" align="center" bgColor="#ffcccc"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Book No.</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 35px" align="center" bgColor="#ffcccc"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Set No.</asp:label></TD>
					<TD style="WIDTH: 162px; HEIGHT: 35px" bgColor="#ffffff"></TD>
					<TD style="WIDTH: 8.7%; HEIGHT: 35px" align="center" bgColor="#f0f8ff"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Case No.</asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 35px" align="center" bgColor="#f0f8ff"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Call Recieve Date</asp:label></TD>
					<TD style="WIDTH: 10%; HEIGHT: 35px" align="center" bgColor="#f0f8ff"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="100%">Call SNO.</asp:label></TD>
				</TR>
				<tr>
					<TD style="WIDTH: 16.15%; HEIGHT: 37px" align="center" bgColor="#ffcccc"><asp:textbox id="txtBKNo" onblur="makeUppercasebk();" tabIndex="1" runat="server" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="50px" Height="20px" MaxLength="4"></asp:textbox></TD>
					<TD style="WIDTH: 20%; HEIGHT: 37px" align="center" bgColor="#ffcccc"><asp:textbox id="txtSetNo" onblur="change();" tabIndex="2" runat="server" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="50px" Height="20px" MaxLength="3"></asp:textbox></TD>
					<TD style="WIDTH: 162px" bgColor="#ffffff"></TD>
					<TD style="WIDTH: 17.46%; HEIGHT: 37px" align="center" bgColor="#f0f8ff"><asp:textbox id="txtCaseNo" onblur="makeUppercase();" tabIndex="6" runat="server" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="104px" Height="20px" MaxLength="9"></asp:textbox></TD>
					<TD style="WIDTH: 20%; HEIGHT: 37px" align="center" bgColor="#f0f8ff"><asp:textbox id="txtRdt" onblur="check_date(txtRdt);" tabIndex="7" runat="server" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Width="104px" Height="20px" MaxLength="10"></asp:textbox></TD>
					<TD style="WIDTH: 10%; HEIGHT: 37px" align="center" bgColor="#f0f8ff"><asp:textbox id="txtCSNO" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Width="70%" Height="20px" MaxLength="5"></asp:textbox></TD>
				</tr>
				<TR>
					<TD style="HEIGHT: 35px" align="center" bgColor="white" colSpan="2"></TD>
					<TD style="WIDTH: 162px; HEIGHT: 35px" align="center" bgColor="#ccccff">
						<asp:button id="btnAdd" tabIndex="9" runat="server" Width="112px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="New Correction"></asp:button>
						<asp:button id="btnMod" tabIndex="3" runat="server" Width="112px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Modify"></asp:button><asp:button id="btnSearch" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Width="112px" Text="Search"></asp:button></TD>
					<TD style="HEIGHT: 35px" align="center" bgColor="white" colSpan="3"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="6">
						<asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">Search Result is Sorted on [Call Date]</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><TITTLE:CUSTOMDATAGRID id="grdIC" runat="server" Width="90%" Height="8px" GridWidth="100%" GridHeight="200px"
							AutoGenerateColumns="False" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" BorderColor="DarkBlue" AddEmptyHeaders="0"
							CssClass="Grid" UseAccessibleHeader="True" CellPadding="2" FreezeRows="0" PageSize="15">
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
										<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"Correction_To_Inspection_Certificate_Edit_Form.aspx?BK_NO=" + DataBinder.Eval(Container.DataItem,"BK_NO")+ "&amp;SET_NO=" + DataBinder.Eval(Container.DataItem,"SET_NO")+ "&amp;CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO")+ "&amp;CALL_RECV_DT=" + DataBinder.Eval(Container.DataItem,"CALL_RECV_DT")+ "&amp;CALL_SNO=" + DataBinder.Eval(Container.DataItem,"CALL_SNO")%>'>Select</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="STATUS" HeaderText="Status">
									<HeaderStyle Width="21%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CALL_RECV_DT" HeaderText="Call Date">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CALL_SNO" HeaderText="Call SNo.">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IE_SNAME" HeaderText="IE">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IC_NO" HeaderText="IC NO">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BK_NO" HeaderText="Book No">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SET_NO" HeaderText="Set No.">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CONSIGNEE" HeaderText="Consignee"></asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
