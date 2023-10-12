<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Incoming_Dak_Edit.aspx.cs" Inherits="RBS.Incoming_Dak_Edit.Incoming_Dak_Edit" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Vigilance_Cases_Edit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.txtRefRegNo.value)=="" && trimAll(document.Form1.txtRefDT.value)=="" && trimAll(document.Form1.txtCaseNo.value)=="" && trimAll(document.Form1.txtBKNo.value)=="" && trimAll(document.Form1.txtSNo.value)=="")
		{
		 alert("ENTER REF REG No. OR REF DATE OR CASE NO, BOOK NO & SET NO. TO SEARCH THE DATA");
		 event.returnValue=false;
		}
		else if(trimAll(document.Form1.txtCaseNo.value)!="" && (trimAll(document.Form1.txtBKNo.value)=="" || trimAll(document.Form1.txtSNo.value)==""))
		{
			alert("ENTER CASE NO, BOOK NO & SET NO. TO SEARCH THE DATA");
		 event.returnValue=false;
		}
		else
		return;
	 
		}
		
		function validate1()
		{
			if(trimAll(document.Form1.txtRefRegNo.value)=="")
			{
			alert("ENTER REF REG No. TO MODIFY");
			event.returnValue=false;
			}
		}
		function makeUppercase()
		 {
			document.Form1.txtCaseNo.value = document.Form1.txtCaseNo.value.toUpperCase();
			
		 }
		 
		
		
		function change()
		{
			var d=document.Form1.txtSNo.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="00" + d;
				document.Form1.txtSNo.value=d;
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="0" + d;
				document.Form1.txtSNo.value=d;
				event.returnValue=false;
			}
			return false;	
		}
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 23px" align="center">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center">
						<P><asp:label id="Label1" runat="server" ForeColor="DarkBlue" BackColor="White" Font-Bold="True"
								Font-Size="10pt" Font-Names="Verdana">INCOMING DAK SEARCH</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px">
						<TABLE id="Table2" style="HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="0" cellPadding="1"
							width="85%" align="center" bgColor="#f0f8ff" border="1">
							<TR align="center">
								<TD style="WIDTH: 149px; HEIGHT: 26px"><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="87px"> Letter ID.</asp:label></TD>
								<TD style="WIDTH: 155px; HEIGHT: 26px"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="149px">Letter Receiving Date</asp:label></TD>
								<TD style="HEIGHT: 26px"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="103px">Letter No</asp:label></TD>
							</TR>
							<TR align="center">
								<TD style="WIDTH: 149px"><asp:textbox id="txtLetterID" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="103px" Height="20px" MaxLength="9"></asp:textbox></TD>
								<TD style="WIDTH: 155px"><asp:textbox id="txtRecDT" onblur="check_date(txtRecDT);" tabIndex="2" runat="server" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Width="90%" Height="20px" MaxLength="10"></asp:textbox></TD>
								<TD><asp:textbox id="txtLetterNo" onblur="makeUppercase();" tabIndex="3" runat="server" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" Width="90%" Height="20px" MaxLength="9"></asp:textbox></TD>
							</TR>
						</TABLE>
						<p align="center"><asp:label id="Label3" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">
								To Search a DAK --> Enter Letter ID OR Letter Receiving Date OR  Letter  No and click on "Search Dak" button</asp:label><br>
							<asp:label id="Label8" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">
								To Edit a Dak --> Enter Letter ID & Click on "Modify" button</asp:label></p>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center" style="HEIGHT: 20px">&nbsp;<asp:button id="btnAdd" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="67px" Text="Add"></asp:button><asp:button id="btnMod" tabIndex="6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="67px" Text="Modify"></asp:button><asp:button id="btnShow" tabIndex="8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="102px" Text="Search Dak"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center">
									<P><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="384px" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></P>
								</TD>
							</TR>
						</TABLE>
						<DIV><TITTLE:CUSTOMDATAGRID id="grdDak" runat="server" Width="100%" Height="8px" HorizontalAlign="Left" PageSize="15"
								FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
								BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="350px"
								GridWidth="100%">
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
											<asp:HyperLink id="Hyperlink2" NavigateUrl='<%#"Incoming_Dak_Form.aspx?Letter_ID=" + DataBinder.Eval(Container.DataItem,"LETTER_ID") + "&amp;Action=M"%>' Runat="server">Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="LETTER_ID" HeaderText="Letter ID">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REC_DATE" HeaderText="Receiving Date">
										<HeaderStyle Width="35%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LETTER_NO" HeaderText="Letter No.">
										<HeaderStyle Width="35%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
