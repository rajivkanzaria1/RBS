<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_NC_Edit_Form.aspx.cs" Inherits="RBS.IE_NC_Edit_Form.IE_NC_Edit_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>NCR FORM</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtNCR_NO.value)=="" && trimAll(document.Form1.txtCaseNo1.value)=="")
		{
		 alert("NCR NO. AND CASE NO.CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else
		return;
	 
		}
		function makeUppercase()
		 {
			document.Form1.txtCaseNo.value = document.Form1.txtCaseNo.value.toUpperCase();
			
		 }
		 
		 function makeUppercasencr()
		 {
			document.Form1.txtNCR_NO.value = document.Form1.txtNCR_NO.value.toUpperCase();
			
		 }
		function validate1()
		{
			if(trimAll(document.Form1.frmDt.value)=="" || trimAll(document.Form1.toDt.value)=="" || document.Form1.lstIE.value=="") 
			{
				alert("YOU CANNOT LEAVE FROM, TO DATE OR IE BLANK!!!");
				event.returnValue=false;
			}
		else
		return;
		}
		function validate2()
		{
		if(trimAll(document.Form1.txtCaseNo.value)=="" || trimAll(document.Form1.txtBKNo.value)=="" || trimAll(document.Form1.txtSetNo.value)=="")
		{
		 alert("CASE NO., BOOK NO. AND SET NO. CANNOT BE LEFT BLANK IN CASE OF NEW NCR");
		 event.returnValue=false;
		}
		else
		return;
		}
		function validate3()
		{
		if(trimAll(document.Form1.txtNCR_NO.value)=="")
		{
		 alert("ENTER NCR NO. TO MODIFY RECORDS");
		 event.returnValue=false;
		}
		
		else
		return;
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
	<BODY bgColor="white">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD align="center" height="35">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<tr>
					<td align="center">
						<% if (Request.Params ["ACTION"]=="M") {%>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" borderColor="#b0c4de" align="center"
							bgColor="#f0f8ff" border="1" width="60%">
							<TR>
								<TD style="HEIGHT: 51px" align="center" bgColor="#ccccff" colSpan="2"><asp:label id="Label1" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="10pt"
										Font-Names="Verdana">UPDATE NCR</asp:label></TD>
							</TR>
							<tr>
								<TD style="HEIGHT: 35px" align="center" bgColor="#ffcccc" width="50%"><asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="10pt"
										Font-Names="Verdana">NCR No.</asp:label></TD>
								<TD style="HEIGHT: 35px" align="center" bgColor="#ffcccc" width="50%"><asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="10pt"
										Font-Names="Verdana">Case No.</asp:label></TD>
							</tr>
							<tr>
								<TD style="HEIGHT: 37px" align="center" bgColor="#ffcccc" width="50%"><asp:textbox id="txtNCR_NO" onblur="makeUppercasencr();" tabIndex="1" runat="server" Width="104px"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="8"></asp:textbox></TD>
								<TD style="HEIGHT: 37px" align="center" bgColor="#ffcccc" width="50%"><asp:textbox id="txtCaseNo1" onblur="makeUppercase();" tabIndex="3" runat="server" Width="104px"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="9"></asp:textbox></TD>
							</tr>
							<TR>
								<TD style="WIDTH: 83.82%; HEIGHT: 37px" align="center" bgColor="#ffcccc" colSpan="2">
									<asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkMagenta" Width="100%">*To Modify -> Enter NCR No. and Press Modify NCR Button</asp:label>
									<asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkMagenta" Width="100%">*To Search -> Enter Case No. and Press Search Button to Search.</asp:label></TD>
							</TR>
							<tr>
								<td style="HEIGHT: 36px" align="center" bgColor="#ffcccc" colSpan="2"><asp:button id="btnMod" tabIndex="2" runat="server" Width="97px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Modify NCR" onclick="btnMod_Click"></asp:button><asp:button id="btnSearch" tabIndex="4" runat="server" Width="112px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button></td>
							</tr>
						</TABLE>
						<%}else if (Request.Params ["ACTION"]=="A") {%>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" borderColor="#b0c4de" align="center"
							bgColor="#f0f8ff" border="1" width="60%">
							<tr>
								<TD style="HEIGHT: 51px" align="center" bgColor="#ccccff" colSpan="3"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="10pt"
										Font-Names="Verdana">NEW NCR</asp:label></TD>
							</tr>
							<TR>
								<TD style="HEIGHT: 51px" align="center" bgColor="#ccccff" colSpan="3">
									<asp:radiobutton id="rdbCSNO" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
										ForeColor="DarkBlue" Text="By Case No." Checked="True" AutoPostBack="True" GroupName="g1" tabIndex="5" oncheckedchanged="rdbCSNO_CheckedChanged"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="rdbIE" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
										ForeColor="DarkBlue" Text="By IE" AutoPostBack="True" GroupName="g1" tabIndex="6" oncheckedchanged="rdbCSNO_CheckedChanged"></asp:radiobutton>
									<asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="100%">*To Add New NCR, Enter Cases, Which are marked After 1st Week Of June 2012.</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 8.7%; HEIGHT: 35px" align="center" bgColor="#f0f8ff"><asp:label id="Label6" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Case No.</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 35px" align="center" bgColor="#f0f8ff"><asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Book No.</asp:label></TD>
								<TD style="WIDTH: 10%; HEIGHT: 35px" align="center" bgColor="#f0f8ff"><asp:label id="Label5" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Set No.</asp:label></TD>
							</TR>
							<tr>
								<TD style="WIDTH: 17.46%; HEIGHT: 37px" align="center" bgColor="#f0f8ff"><asp:textbox id="txtCaseNo" onblur="makeUppercase();" tabIndex="7" runat="server" Width="104px"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="9"></asp:textbox></TD>
								<TD style="WIDTH: 20%; HEIGHT: 37px" align="center" bgColor="#f0f8ff"><asp:textbox id="txtBKNo" onblur="makeUppercasebk();" tabIndex="8" runat="server" Width="50px"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="4"></asp:textbox></TD>
								<TD style="WIDTH: 10%; HEIGHT: 37px" align="center" bgColor="#f0f8ff"><asp:textbox id="txtSetNo" onblur="change();" tabIndex="9" runat="server" Width="50px" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="5"></asp:textbox></TD>
							</tr>
							<TR>
								<TD style="WIDTH: 17.46%; HEIGHT: 37px" align="center" bgColor="#f0f8ff" colSpan="3"><asp:button id="btnAdd" tabIndex="10" runat="server" Width="112px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="New NCR" onclick="btnAdd_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 17.46%; HEIGHT: 37px" align="left" bgColor="#f0f8ff">
									<asp:label id="lblIE" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="10%">IE </asp:label></FONT>
									<asp:dropdownlist id="lstIE" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Height="25px" Width="90%"></asp:dropdownlist></TD>
								<TD style="WIDTH: 20%; HEIGHT: 37px" align="left" bgColor="#f0f8ff" colSpan="2">
									<asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="72px">Date From </asp:label>
									<asp:textbox id="frmDt" onblur="check_date(frmDt);" style="TEXT-ALIGN: center" tabIndex="12"
										runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="10" Height="20px"
										Width="30%"></asp:textbox>&nbsp;
									<asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="24px">To</asp:label>
									<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
										style="TEXT-ALIGN: center" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" MaxLength="10" Height="20px" Width="30%"></asp:textbox></TD>
							</TR>
							<tr>
								<td style="HEIGHT: 36px" align="center" bgColor="#f0f8ff" colSpan="3">
									<asp:button id="btnSubmit" tabIndex="14" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Width="112px" Text="Submit" onclick="btnSubmit_Click"></asp:button></td>
							</tr>
						</TABLE>
						<%}%>
					</td>
				</tr>
				<TR>
					<TD style="HEIGHT: 21px" align="center">
						<asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkMagenta" Width="100%">Search Result is Sorted on [Call Date]</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TITTLE:CUSTOMDATAGRID id="grdIC" runat="server" Height="8px" Width="90%" GridWidth="100%" GridHeight="200px"
							AutoGenerateColumns="False" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" BorderColor="DarkBlue"
							AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" CellPadding="2" FreezeRows="0" PageSize="15">
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
										<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"IE_NC_Form.aspx?Action=M&NC_NO=" + DataBinder.Eval(Container.DataItem,"NC_NO")%>'>Modify</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Select">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink3" Runat="server" NavigateUrl='<%#"IE_NC_Form.aspx?Action=A&Case_No=" + DataBinder.Eval(Container.DataItem,"CASE_NO")+ "&BK_NO=" + DataBinder.Eval(Container.DataItem,"BK_NO")+ "&SET_NO=" + DataBinder.Eval(Container.DataItem,"SET_NO")%>'>Add NCR</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NC_NO" HeaderText="NC Status">
									<HeaderStyle Width="21%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CALL_RECV_DATE" HeaderText="Call Date">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CALL_SNO" HeaderText="Call SNo.">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IE_SNAME" HeaderText="IE">
									<HeaderStyle Width="7%"></HeaderStyle>
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
					<TD align="center"></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
