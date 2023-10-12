<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hologram_Search_Form.aspx.cs" Inherits="RBS.Hologram_Search_Form" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HOLOGRAM SEARCH FORM</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">		 
		function search()
		{
		 if(trimAll(document.Form1.txtSetNoFR.value)=="" && trimAll(document.Form1.txtSetNoTo.value)=="" && document.Form1.ddlIE.value=="")
		 {
			alert("PLEASE ENTER HOLOGRAM NO.FROM OR HOLOGRAM No. To OR SELECT IE TO WHOM ISSUED!!");
			event.returnValue=false;
		 }
		 	
		 return;			 
		}
		function validate()
		{
		 if(trimAll(document.Form1.txtSetNoFR.value)=="" || trimAll(document.Form1.txtSetNoTo.value)=="")
		 {
			
			alert("YOU MUST ENTER HOLOGRAM NO FROM. or HOLOGRAM NO.TO!!");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtSetNoFR.value)!="" && IsNumeric(document.Form1.txtSetNoFR.value) == false &&  document.Form1.txtCertFrom.value==0)
		 {
			alert("HOLOGRAM NO FROM. CONTAINS INVALID CHARACTERS AND IT SHLD BE GREATER THEN 0!!!");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtSetNoTo.value)!="" && IsNumeric(document.Form1.txtSetNoTo.value) == false)
		 {
			alert("HOLOGRAM NO To. CONTAINS INVALID CHARACTERS!!!");
			event.returnValue=false;
		 }
		 else
		 return;			 
		}
		
		function check()
		{
			if(document.Form1.txtSetNoFR.value!="" && document.Form1.txtSetNoTo.value!="")
			{
			var setfr=(document.Form1.txtSetNoFR.value);
			var setto=(document.Form1.txtSetNoTo.value);
			if(setto<setfr)
			{
				alert("HOLOGRAM No. To Must Greater Than HOLOGRAM No. From");
				document.Form1.txtSetNoFR.focus();
			}
			return false;
			}
		}
		
		function change()
		{
			var d=document.Form1.txtSetNoFR.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="000000" + d;
				document.Form1.txtSetNoFR.value=d
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="00000" + d;
				document.Form1.txtSetNoFR.value=d
				event.returnValue=false;
			}
			else if(dlength==3)
			{
				d="0000" + d;
				document.Form1.txtSetNoFR.value=d
				event.returnValue=false;
			}
			else if(dlength==4)
			{
				d="000" + d;
				document.Form1.txtSetNoFR.value=d
				event.returnValue=false;
			}
			else if(dlength==5)
			{
				d="00" + d;
				document.Form1.txtSetNoFR.value=d
				event.returnValue=false;
			}
			else if(dlength==6)
			{
				d="0" + d;
				document.Form1.txtSetNoFR.value=d
				event.returnValue=false;
			}
			else
			return false;	
		}
		
		function change1()
		{
			var d=document.Form1.txtSetNoTo.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="000000" + d;
				document.Form1.txtSetNoTo.value=d
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="00000" + d;
				document.Form1.txtSetNoTo.value=d
				event.returnValue=false;
			}
			else if(dlength==3)
			{
				d="0000" + d;
				document.Form1.txtSetNoTo.value=d
				event.returnValue=false;
			}
			else if(dlength==4)
			{
				d="000" + d;
				document.Form1.txtSetNoTo.value=d
				event.returnValue=false;
			}
			else if(dlength==5)
			{
				d="00" + d;
				document.Form1.txtSetNoTo.value=d
				event.returnValue=false;
			}
			else if(dlength==6)
			{
				d="0" + d;
				document.Form1.txtSetNoTo.value=d
				event.returnValue=false;
			}
			else
			return false;	
		}
        </script>
	</HEAD>
	<body onload="javascript:document.Form1.txtSetNoFR.focus();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR align="center">
					<TD><FONT color="#3300cc"><FONT face="Arial" color="#000099" size="2"><STRONG><U>HOLOGRAM SEARCH 
										FORM&nbsp;</U></STRONG></FONT></FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 108px">
						<P align="center">
							<TABLE id="Table2" style="HEIGHT: 52px" borderColor="#bfcbe3" cellSpacing="1" cellPadding="1"
								width="70%" bgColor="#f0f8ff" border="1">
								<TR align="center">
									<TD style="WIDTH: 41.5%" align="center" colSpan="2"><STRONG><FONT face="Verdana" color="#000099" size="2">Hologram&nbsp;No.&nbsp;&nbsp;(From-To)</FONT></STRONG></TD>
									<TD style="HEIGHT: 17px"><STRONG><FONT face="Verdana" color="#000099" size="2">IE To Whom 
												Issued</FONT></STRONG></TD>
								</TR>
								<TR align="center">
									<TD align="center" colSpan="2"><asp:label id="lblReg1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="Red" Width="5%"></asp:label><asp:textbox id="txtSetNoFR" onblur="change();check();" tabIndex="1" runat="server" Font-Size="8pt"
											ForeColor="DarkBlue" Width="35%" MaxLength="7" BackColor="White"></asp:textbox>&nbsp;<FONT face="Verdana" size="2"><STRONG><FONT color="#000099">to
											</STRONG></FONT>
										<asp:label id="lblReg2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="Red" Width="5%"></asp:label><asp:textbox id="txtSetNoTo" onblur="change1();check();" tabIndex="2" runat="server" Font-Size="8pt"
											ForeColor="DarkBlue" Width="35%" MaxLength="7"></asp:textbox></FONT></TD>
									<TD><asp:dropdownlist id="ddlIE" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Height="35px"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
							<asp:label id="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="7.8pt"
								ForeColor="DarkMagenta" Width="511px"> To Search/Modify/Delete Hologram count  -> Enter Hologram No From/To and/or Inspection Engineer and click on [Search] button and then select the desired record.</asp:label><asp:label id="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="7.8pt"
								ForeColor="DarkMagenta" Width="100%"> To Add Hologram count --> Click on [Add] button</asp:label></P>
					</TD>
				</TR>
				<TR align="center">
					<TD><asp:button id="btnAdd" tabIndex="4" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Width="46px" Text="Add"></asp:button><asp:button id="btnModifyIC" tabIndex="5" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Text="Modify"></asp:button><asp:button id="btnDeleteIC" tabIndex="6" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Text="Delete"></asp:button><asp:button id="btnSearchIC" tabIndex="7" runat="server" Font-Bold="True" Font-Names="Verdana"
							Font-Size="8pt" ForeColor="DarkBlue" Text="Search"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center"><asp:datagrid id="grdBook" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" Height="96px"
							BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False">
							<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
								VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"Hologram_Search_Form.aspx?HG_NO_FR="+DataBinder.Eval(Container.DataItem,"HG_NO_FR")+"&amp;HG_NO_TO="+DataBinder.Eval(Container.DataItem,"HG_NO_TO") %>'>Select</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="HG_NO_FR" HeaderText="Hologram No. From"></asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_TO" HeaderText="Hologram No. To"></asp:BoundColumn>
								<asp:BoundColumn DataField="ISSUE_DT" HeaderText="Issue Date to IE"></asp:BoundColumn>
								<asp:BoundColumn DataField="HG_IECD" HeaderText="IE to Whom Issued"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
