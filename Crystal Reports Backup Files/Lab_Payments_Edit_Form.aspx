<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab_Payments_Edit_Form.aspx.cs" Inherits="RBS.Lab_Payments_Edit_Form.Lab_Payments_Edit_Form" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Lab_Payments_Edit_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		
		function validate()
		{
		 if(trimAll(document.Form1.txtPaymentID.value)=="" && trimAll(document.Form1.txtPaymentDT.value)=="" && trimAll(document.Form1.lstLab.value)=="")
		 {
		 alert("Enter Payment ID OR Payment Date OR Lab to Search!!!");
		 event.returnValue=false;
		 }
	    }
	    
	    function validate1()
		{
		 if(trimAll(document.Form1.txtPaymentID.value)=="")
		 {
		 alert("Enter Payment ID to Modify!!!");
		 event.returnValue=false;
		 }
	    }
			
        </script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 23px" align="center">
						<P>
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center">
						<P><asp:label id="Label1" runat="server" ForeColor="DarkBlue" BackColor="White" Font-Bold="True"
								Font-Size="10pt" Font-Names="Verdana">EXTERNAL LABORATORY PAYMENT SEARCH</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px">
						<TABLE id="Table2" style="HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="0" cellPadding="1"
							width="85%" align="center" bgColor="#f0f8ff" border="1">
							<TR align="center">
								<TD style="WIDTH: 149px; HEIGHT: 26px"><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="87px"> Payment ID.</asp:label></TD>
								<TD style="WIDTH: 155px; HEIGHT: 26px"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="149px">Payment Date</asp:label></TD>
								<TD style="HEIGHT: 26px"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="103px"> Lab</asp:label></TD>
							</TR>
							<TR align="center">
								<TD style="WIDTH: 149px"><asp:textbox id="txtPaymentID" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="103px" Height="20px" MaxLength="9"></asp:textbox></TD>
								<TD style="WIDTH: 155px"><asp:textbox id="txtPaymentDT" onblur="check_date(txtPaymentDT);" tabIndex="2" runat="server" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Width="90%" Height="20px" MaxLength="10"></asp:textbox></TD>
								<TD>
									<asp:dropdownlist id="lstLab" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="100%"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						<p align="center"><asp:label id="Label3" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">
								To Search a PAYMENT --> Enter Payment ID OR Payment Date  OR  Lab and click on "Search Payment" button</asp:label><br>
							<asp:label id="Label8" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">
								To Edit a PAYMENT --> Enter Payment ID & Click on "Modify" button</asp:label></p>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center" style="HEIGHT: 20px">&nbsp;<asp:button id="btnAdd" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="67px" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnMod" tabIndex="6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="67px" Text="Modify" onclick="btnMod_Click"></asp:button><asp:button id="btnShow" tabIndex="8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="115px" Text="Search Payment" onclick="btnShow_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center">
									<P><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="384px" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></P>
								</TD>
							</TR>
						</TABLE>
						<DIV>
							<TITTLE:CUSTOMDATAGRID id="grdLAB" runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="350px"
								AutoGenerateColumns="False" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" BorderColor="DarkBlue"
								AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" CellPadding="2" FreezeRows="0" PageSize="15"
								HorizontalAlign="Left">
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
											<asp:HyperLink id="Hyperlink2" NavigateUrl='<%#"Lab_Payments_Form.aspx?PAYMENT_ID=" + DataBinder.Eval(Container.DataItem,"PAYMENT_ID") + "&amp;Action=M"%>' Runat="server">Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="PAYMENT_ID" HeaderText="Payment ID">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PAYMENT_DATE" HeaderText="Payment Date">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LAB" HeaderText="Lab">
										<HeaderStyle Width="55%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMOUNT" HeaderText="Amount">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID><PAGERSTYLE ForeColor="Blue" HorizontalAlign="Center" Mode="NumericPages"></PAGERSTYLE><ALTERNATINGITEMSTYLE Font-Names="Verdana" Font-Size="8pt" BackColor="#CCCCFF" CssClass="GridAlternate"></ALTERNATINGITEMSTYLE><EDITITEMSTYLE Height="10%"></EDITITEMSTYLE><FOOTERSTYLE CssClass="GridHeader"></FOOTERSTYLE><ITEMSTYLE Font-Names="Verdana" Font-Size="8pt" Height="20px" CssClass="GridNormal"></ITEMSTYLE><HEADERSTYLE Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" BackColor="InactiveCaptionText"
								ForeColor="DarkBlue" Height="15%" CssClass="GridHeader" HorizontalAlign="Left"></HEADERSTYLE><COLUMNS>
								<ASP:TEMPLATECOLUMN>
									<HEADERSTYLE Width="5%"></HEADERSTYLE>
									<ITEMTEMPLATE></ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Letter ID" DataField="LETTER_ID">
									<HEADERSTYLE Width="10%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Receiving Date" DataField="REC_DATE">
									<HEADERSTYLE Width="35%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Letter No." DataField="LETTER_NO">
									<HEADERSTYLE Width="35%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
							</COLUMNS></DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
