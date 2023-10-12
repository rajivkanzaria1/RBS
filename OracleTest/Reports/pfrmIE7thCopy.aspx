<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pfrmIE7thCopy.aspx.cs" Inherits="RBS.Reports.pfrmIE7thCopy" %>--%>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<%@ Page language="c#" Codebehind="pfrmIE7thCopy.aspx.cs" AutoEventWireup="false" Inherits="RBS.Reports.pfrmIE7thCopy" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>pfrmIE7thCopy</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">		 
		function search()
		{
		 if(trimAll(document.Form1.txtBKNo.value)=="" && trimAll(document.Form1.txtSetNo.value)=="")
		 {
			alert("PLEASE ENTER BOOK NO. & SET NO.FROM/SELECT IE TO WHOM ISSUED!!");
			event.returnValue=false;
		 }
		 	
		 return;			 
		}
		function validate()
		{
		
		 if(trimAll(document.Form1.txtBKNo.value)=="")
		 {
			
			alert("YOU MUST ENTER BOTH BOOK NO. & SET NO.FROM!!");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtSetNo.value)=="")
		 {
			
			alert("YOU MUST ENTER BOTH BOOK NO. & SET NO.FROM!!");
			event.returnValue=false;
		 }
		 else
		 return;			 
		}
		function makeUppercase()
		 {
			document.Form1.txtBKNo.value = document.Form1.txtBKNo.value.toUpperCase();
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
			else
			return false;	
		}
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="False">
				<asp:Button id="btnPrint" runat="server" Text="Print"></asp:Button>
				<INPUT id="Button1" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px">
				<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
					cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 32px" align="center">
							<P>
								<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
						</TD>
					</TR>
					<TR align="center">
						<TD><FONT color="#3300cc"><FONT face="Arial" color="#000099" size="2"><STRONG><U>INSPECTION 
											CERTIFICATE BOOK SET 7TH COPY REPORT</U></STRONG></FONT></FONT></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 108px">
							<P align="center">
								<TABLE id="Table2" style="HEIGHT: 52px" borderColor="#bfcbe3" cellSpacing="1" cellPadding="1"
									width="30%" bgColor="#f0f8ff" border="1">
									<TR align="center">
										<TD style="WIDTH: 74px; HEIGHT: 17px" align="center" colSpan="1" rowSpan="1"><FONT face="Verdana" color="#000099" size="2"><STRONG>Book 
													No.</STRONG></FONT></TD>
										<TD style="WIDTH: 100px; HEIGHT: 17px"><FONT face="Verdana" color="#000099" size="2"><STRONG>Set 
													No. From</STRONG></FONT></TD>
									</TR>
									<TR align="center">
										<TD style="WIDTH: 74px" align="center">
											<asp:textbox id="txtBKNo" onblur="makeUppercase();" tabIndex="1" runat="server" Width="53px"
												Font-Size="8pt" ForeColor="DarkBlue" BackColor="LavenderBlush"></asp:textbox></TD>
										<TD style="WIDTH: 100px" align="center">
											<asp:textbox id="txtSetNo" onblur="change();" tabIndex="2" runat="server" Width="57px" Font-Size="8pt"
												ForeColor="DarkBlue" Enabled="False"></asp:textbox></TD>
									</TR>
								</TABLE>
								<asp:label id="Label1" runat="server" Font-Size="7.8pt" ForeColor="DarkMagenta" Font-Bold="True"
									Font-Names="Verdana"> To Search Book Set -> Enter Book No. and click on [Search] button and then select the desired item.</asp:label>
								<asp:label id="Label2" runat="server" Width="100%" Font-Size="7.8pt" ForeColor="DarkMagenta"
									Font-Bold="True" Font-Names="Verdana"> Click on [Submit] button for 7th Copy</asp:label></P>
						</TD>
					</TR>
					<TR align="center">
						<TD>
							<asp:button id="btnSubmit" tabIndex="4" runat="server" Width="57px" Text="Submit" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana"></asp:button>
							<asp:button id="btnSearchIC" tabIndex="7" runat="server" Text="Search" Font-Size="8pt" ForeColor="DarkBlue"
								Font-Bold="True" Font-Names="Verdana"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:datagrid id="grdBook" runat="server" Height="96px" Width="100%" Font-Size="8pt" Font-Names="Verdana"
								AutoGenerateColumns="False" BorderStyle="Groove" BorderColor="DarkBlue">
								<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
									VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"pfrmIE7thCopy.aspx?BK_NO="+DataBinder.Eval(Container.DataItem,"BK_NO")+"&amp;SET_NO_FR="+DataBinder.Eval(Container.DataItem,"SET_NO_FR") %>'>Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="BK_NO" HeaderText="Book No."></asp:BoundColumn>
									<asp:BoundColumn DataField="SET_NO_FR" HeaderText="Set No. From"></asp:BoundColumn>
									<asp:BoundColumn DataField="SET_NO_TO" HeaderText="Set No. To"></asp:BoundColumn>
									<asp:BoundColumn DataField="ISSUE_DT" HeaderText="Issue Date to IE"></asp:BoundColumn>
									<asp:BoundColumn DataField="ISSUE_TO_IECD" HeaderText="IE to Whom Issued"></asp:BoundColumn>
									<asp:BoundColumn DataField="BK_SUBMITTED" HeaderText="Book Submitted"></asp:BoundColumn>
									<asp:BoundColumn DataField="BK_SUBMIT_DT" HeaderText="Book Submit Date"></asp:BoundColumn>
									<asp:BoundColumn DataField="BK_ISSUED_TO_REGION" HeaderText="Book Issued To Region"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>

