<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client_MA_LIST.aspx.cs" Inherits="RBS.Client_MA_LIST.Client_MA_LIST" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl2" Src="WebUserControl2.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Client_MA_LIST</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">		 
		function validate()
		{
		 if(trimAll(document.Form1.txtCsNo.value)=="")
		 {
			alert("PLEASE ENTER CASE NUMBER!!");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCsNo.value)!="" && trimAll(document.Form1.txtCsNo.value).length < 9)
		 {
			alert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
			event.returnValue=false;
		 }
		 else
		 return;			 
		}
		
		function validate1()
		{
		 if(trimAll(document.Form1.txtCsNo.value)=="")
		 {
			alert("PLEASE ENTER CASE NUMBER!!");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCsNo.value)!="" && trimAll(document.Form1.txtCsNo.value).length < 9)
		 {
			alert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.Text_MAN.value)=="")
		 {  
		    alert("PLEASE ENTER MA NO!!");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.Text_MADT.value)=="")
		 {  
		    alert("PLEASE ENTER MA DATE!!");
			event.returnValue=false;
		 }
		 else
		 return;			 
		}
		
		function makeUppercase()
		 {
			document.Form1.txtCsNo.value = document.Form1.txtCsNo.value.toUpperCase();
		 }
		function sFocus()
		 {
		 
		 document.Form1.txtCsNo.focus();
		 }
		 function search()
		{
		 if(trimAll(document.Form1.txtCsNo.value)=="")
		 {
			alert("CASE NUMBER IS MANDATORY");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCsNo.value)!="" && trimAll(document.Form1.txtCsNo.value).length < 9)
		 {
			alert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
			event.returnValue=false;
		 }
		 else
		 
		 return;			 
		}
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="true">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 184px"
					cellSpacing="1" cellPadding="1" border="0">
					<TR>
						<TD>
							<uc1:WebUserControl2 id="WebUserControl21" runat="server"></uc1:WebUserControl2>
							<P></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P>
								<asp:label id="Label1" runat="server" Height="19px" Width="174px" Font-Bold="True" BackColor="White"
									ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana">AMMENDMENT FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%">
							<P align="center">
								<TABLE id="TablePO" style="WIDTH: 100%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1"
									cellPadding="1" width="935" bgColor="#f0f8ff" border="1" runat="server">
									<TR>
										<TD style="WIDTH: 10%">
											<asp:label id="Label2" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Case Number</asp:label></TD>
										<TD style="WIDTH: 15%" align="left">
											<asp:textbox id="txtCsNo" onblur="makeUppercase();" tabIndex="1" runat="server" Height="20px"
												Width="100%" BackColor="LavenderBlush" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												MaxLength="9"></asp:textbox></TD>
										<TD style="WIDTH: 15%">
											<asp:label id="Label4" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana"> PO/Offer Letter No.</asp:label></TD>
										<TD style="WIDTH: 35%">
											<asp:textbox id="txtPONo" tabIndex="2" runat="server" Height="20px" Width="100%" BackColor="White"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
										<TD style="WIDTH: 10%">
											<asp:label id="Label3" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">PO Date</asp:label></TD>
										<TD style="WIDTH: 15%">
											<asp:textbox id="txtPODate" onblur="check_date(txtPODate);" tabIndex="3" runat="server" Height="20px"
												Width="100%" BackColor="White" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
									</TR>
								</TABLE>
								<TABLE id="TableMA" style="WIDTH: 100%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1"
									cellPadding="1" width="935" bgColor="#f0f8ff" border="1" runat="server">
									<TR>
										<TD style="WIDTH: 10%">
											<asp:label id="Label_MA_CS" runat="server" Visible="False" Width="100%" Font-Bold="True" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana">Case No.</asp:label></TD>
										<TD style="WIDTH: 15%" align="left">
											<asp:textbox id="Text_MA" onblur="makeUppercase();" tabIndex="1" runat="server" Visible="False"
												Height="20px" Width="100%" BackColor="LavenderBlush" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" MaxLength="9"></asp:textbox></TD>
										<TD style="WIDTH: 15%">
											<asp:label id="Label_MA_No" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana"> MA No.</asp:label></TD>
										<TD style="WIDTH: 35%">
											<asp:textbox id="Text_MAN" tabIndex="2" runat="server" Height="20px" Width="100%" BackColor="White"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
										<TD style="WIDTH: 10%">
											<asp:label id="Label_MA_Date" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana">MA Date</asp:label></TD>
										<TD style="WIDTH: 15%">
											<asp:textbox id="Text_MADT" onblur="check_date(Text_MADT);" tabIndex="3" runat="server" Height="20px"
												Width="100%" BackColor="White" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD>
									</TR>
								</TABLE>
								<asp:label id="Label5" runat="server" Width="100%" Font-Bold="True" ForeColor="Red" Font-Size="8pt"
									Font-Names="Verdana">***Ammendments can be only added between Monday to Thursday***</asp:label>
								<asp:label id="Label_Stu" runat="server" Visible="False" Width="100%" Font-Bold="True" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana"></asp:label>
								<asp:label id="Label_Sno" runat="server" Visible="False" Width="100%" Font-Bold="True" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana"></asp:label>
								<asp:label id="Label8" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">
								To Add New Ammendment in PO --> Enter Case No. & Click on "ADD New MA" button</asp:label>
								<asp:label id="Label7" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">
								To Search Existing Ammendment in a PO --> Enter Case 
								No. or PO/Offer Letter No or PO Date or MA No or MA Date and click on "Existing MA" button</asp:label>
								<asp:label id="Label9" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">
									To Modifiy Returned MA --> Enter Case 
								No. or PO/Offer Letter No or PO Date or MA No or MA Date and click on "Moify MA" button</asp:label>
								<asp:label id="Label10" runat="server" Width="100%" Font-Bold="True" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">
								To View Case History --> Enter Case No. & Click on "Case History" button</asp:label>
							<P align="center"></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 9px" align="center" width="100%">
							<asp:button id="btnNewMA" tabIndex="11" runat="server" Visible="True" Width="133px" Font-Bold="True"
								ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Text="Add New MA" onclick="btnNewMA_Click_1"></asp:button>
							<asp:button id="btnModifyPO" tabIndex="12" runat="server" Visible="False" Width="215px" Font-Bold="True"
								ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Text="Add in Existing MA" onclick="btnModifyPO_Click"></asp:button>
							<asp:button id="btnDeletePO" tabIndex="13" runat="server" Visible="False" Width="178px" Font-Bold="True"
								ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Text="Modify for Return MA" onclick="btnDeletePO_Click"></asp:button>
							<asp:button id="Btn_sema" tabIndex="14" runat="server" Width="132px" Font-Bold="True" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Search MA" onclick="Btn_sema_Click"></asp:button>
							<asp:button id="btnCaseHistory" tabIndex="14" runat="server" Width="132px" Font-Bold="True"
								ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Text="Case History" onclick="btnCaseHistory_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD align="left" width="100%">
							<DIV>
								<TITTLE:CUSTOMDATAGRID id="DgPO1" runat="server" Height="8px" Width="100%" GridWidth="100%" GridHeight="350px"
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
										<asp:TemplateColumn HeaderText="Select">
											<HeaderStyle Width="5%"></HeaderStyle>
											<ItemTemplate>
												<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"Client_MA_LIST.aspx?case_no=" + DataBinder.Eval(Container.DataItem,"CASE_NO") + "&amp;MA_NO=" + DataBinder.Eval(Container.DataItem,"MA_NO")+ "&amp;MA_DT=" + DataBinder.Eval(Container.DataItem,"MA_DT")+ "&amp;MA_STATUS=" + DataBinder.Eval(Container.DataItem,"MA_STATUS")+ "&amp;MA_SNO=" + DataBinder.Eval(Container.DataItem,"MA_SNO")+ "" %>'>Select</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
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
										<asp:BoundColumn DataField="S_RCE" HeaderText="MA Source">
											<ItemStyle ForeColor="Blue"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></DIV>
						</TD>
					</TR>
				</TABLE>
			</asp:panel></form>
		<P></P>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
