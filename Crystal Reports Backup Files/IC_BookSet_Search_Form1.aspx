<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IC_BookSet_Search_Form1.aspx.cs" Inherits="RBS.IC_BookSet_Search_Form1.IC_BookSet_Search_Form1" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IC_BookSet_Search_Form1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">		 
		function search()
		{
		 if(trimAll(document.Form1.txtBKNo.value)=="" && trimAll(document.Form1.txtSetNo.value)=="" && document.Form1.ddlIE.value=="")
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
	<body onload="javascript:document.Form1.txtBKNo.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR align="center">
					<TD><FONT color="#3300cc"><FONT face="Arial" color="#000099" size="2"><STRONG><U>INSPECTION 
										CERTIFICATE BOOK SET</U></STRONG></FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 108px">
						<P align="center">
							<TABLE id="Table2" style="HEIGHT: 52px" borderColor="#bfcbe3" cellSpacing="1" cellPadding="1"
								width="60%" bgColor="#f0f8ff" border="1">
								<TR align="center">
									<TD style="WIDTH: 74px; HEIGHT: 17px"><FONT face="Verdana" color="#000099" size="2"><STRONG>Book 
												No.</STRONG></FONT></TD>
									<TD style="WIDTH: 100px; HEIGHT: 17px"><FONT face="Verdana" color="#000099" size="2"><STRONG>Set 
												No. From</STRONG></FONT></TD>
									<TD style="HEIGHT: 17px"><STRONG><FONT face="Verdana" color="#000099" size="2">IE To Whom 
												Issued</FONT></STRONG></TD>
								</TR>
								<TR align="center">
									<TD style="WIDTH: 74px" align="center">
										<asp:textbox id="txtBKNo" onblur="makeUppercase();" tabIndex="1" runat="server" Font-Size="8pt"
											ForeColor="DarkBlue" Width="53px" BackColor="LavenderBlush"></asp:textbox></TD>
									<TD style="WIDTH: 100px" align="center">
										<asp:textbox id="txtSetNo" onblur="change();" tabIndex="2" runat="server" Font-Size="8pt" ForeColor="DarkBlue"
											Width="57px"></asp:textbox></TD>
									<TD><asp:dropdownlist id="ddlIE" tabIndex="3" runat="server" Font-Size="8pt" ForeColor="DarkBlue" Width="100%"
											Font-Names="Verdana" Height="35px"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
							<asp:label id="Label1" runat="server" Font-Size="7.8pt" ForeColor="DarkMagenta" Width="511px"
								Font-Names="Verdana" Font-Bold="True"> To Search/Modify/Delete Book Set -> Enter Book No. & Set No From/Inspection Engineer and click on [Search] button and then select the desired item.</asp:label><asp:label id="Label2" runat="server" Font-Size="7.8pt" ForeColor="DarkMagenta" Width="100%"
								Font-Names="Verdana" Font-Bold="True">Click on [Add] button for new Book Set</asp:label></P>
					</TD>
				</TR>
				<TR align="center">
					<TD>
						<asp:button id="btnAdd" tabIndex="4" runat="server" Font-Size="8pt" ForeColor="DarkBlue" Width="46px"
							Font-Names="Verdana" Font-Bold="True" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnModifyIC" tabIndex="5" runat="server" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Names="Verdana" Font-Bold="True" Text="Modify" onclick="btnModifyIC_Click"></asp:button><asp:button id="btnDeleteIC" tabIndex="6" runat="server" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Names="Verdana" Font-Bold="True" Text="Delete" onclick="btnDeleteIC_Click"></asp:button><asp:button id="btnSearchIC" tabIndex="7" runat="server" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Names="Verdana" Font-Bold="True" Text="Search" onclick="btnSearchIC_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center"><asp:datagrid id="grdBook" runat="server" Font-Size="8pt" Width="100%" Font-Names="Verdana" Height="96px"
							AutoGenerateColumns="False" BorderStyle="Groove" BorderColor="DarkBlue">
							<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
								VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"IC_BookSet_Search_Form1.aspx?BK_NO="+DataBinder.Eval(Container.DataItem,"BK_NO")+"&amp;SET_NO_FR="+DataBinder.Eval(Container.DataItem,"SET_NO_FR") %>'>Select</asp:HyperLink>
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
		</form>
	</body>
</HTML>

