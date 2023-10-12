<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hologram_Cancel_Form.aspx.cs" Inherits="RBS.Hologram_Cancel_Form.Hologram_Cancel_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Hologram_Cancel_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		
			if(trimAll(document.Form1.txtHGFrom.value)=="")
			{
				alert("HOLOGRAM NO. FROM CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtHGTo.value)=="")
			{
				alert("HOLOGRAM NO. TO CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.lstIE.value=="")
			{
				alert("IE TO WHOM ISSUED CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.txtStatusDt.value=="")
			{
				alert("STATUS DATE CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtHGFrom.value)!="" && IsNumeric(document.Form1.txtHGFrom.value) == false &&  document.Form1.txtHGFrom.value==0)
			{
				alert("HOLOGRAM NO FROM. CONTAINS INVALID CHARACTERS AND IT SHLD BE GREATER THEN 0 !!!");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtHGTo.value)!="" && IsNumeric(document.Form1.txtHGTo.value) == false)
			{
				alert("HOLOGRAM NO To. CONTAINS INVALID CHARACTERS!!!");
				event.returnValue=false;
			}
		 	else
			{
				document.Form1.btnSave.style.visibility = 'hidden';
			}
			return;		 
		}
		
		function validate2()
		{
		
			if(trimAll(document.Form1.txtHGFrom.value)=="" && trimAll(document.Form1.txtHGTo.value)=="" && document.Form1.lstIE.value=="")
			{
				alert("HOLOGRAM NO. FROM AND HOLOGRAM NO. TO AND IE TO WHOM ISSUED CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else
			
			return;		 
		}
		
		function validate1()
		{
		
			if(trimAll(document.Form1.txtHGFrom.value)=="")
			{
				alert("HOLOGRAM NO. FROM CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtHGTo.value)=="")
			{
				alert("HOLOGRAM NO. TO CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else
			return;		 
		}
		
		function del()
		{
			var d=confirm("Click OK to Confirm Delete!!!");
			if(d==true)
				event.returnValue=true;
			else
				event.returnValue=false;
		}
		
		
		
		 function check()
		{
			if(document.Form1.txtHGFrom.value!="" && document.Form1.txtHGTo.value!="")
			{
			var setfr=(document.Form1.txtHGFrom.value);
			var setto=(document.Form1.txtHGTo.value);
			if(setto<setfr)
			{
				alert("HOLOGRAM No. To Must Greater Than HOLOGRAM No. From");
				document.Form1.txtHGFrom.focus();
			}
			return false;
			}
		}
		function change()
		{
			var d=document.Form1.txtHGFrom.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="000000" + d;
				document.Form1.txtHGFrom.value=d
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="00000" + d;
				document.Form1.txtHGFrom.value=d
				event.returnValue=false;
			}
			else if(dlength==3)
			{
				d="0000" + d;
				document.Form1.txtHGFrom.value=d
				event.returnValue=false;
			}
			else if(dlength==4)
			{
				d="000" + d;
				document.Form1.txtHGFrom.value=d
				event.returnValue=false;
			}
			else if(dlength==5)
			{
				d="00" + d;
				document.Form1.txtHGFrom.value=d
				event.returnValue=false;
			}
			else if(dlength==6)
			{
				d="0" + d;
				document.Form1.txtHGFrom.value=d
				event.returnValue=false;
			}
			else
			return false;	
		}
		
		function change1()
		{
			var d=document.Form1.txtHGTo.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="000000" + d;
				document.Form1.txtHGTo.value=d
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="00000" + d;
				document.Form1.txtHGTo.value=d
				event.returnValue=false;
			}
			else if(dlength==3)
			{
				d="0000" + d;
				document.Form1.txtHGTo.value=d
				event.returnValue=false;
			}
			else if(dlength==4)
			{
				d="000" + d;
				document.Form1.txtHGTo.value=d
				event.returnValue=false;
			}
			else if(dlength==5)
			{
				d="00" + d;
				document.Form1.txtHGTo.value=d
				event.returnValue=false;
			}
			else if(dlength==6)
			{
				d="0" + d;
				document.Form1.txtHGTo.value=d
				event.returnValue=false;
			}
			else
			return false;	
		}
		
		
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="384px" Font-Bold="True"> HOLOGRAM CANCELLATION FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 707px; HEIGHT: 104px" borderColor="#bfcbe3" cellSpacing="1"
								cellPadding="1" width="707" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 40%" align="center" colspan="2"><STRONG><FONT face="Verdana" color="#000099" size="2">Hologram&nbsp;No.&nbsp;&nbsp;(From-To)</FONT></STRONG></TD>
									<TD style="WIDTH: 276px; HEIGHT: 36px" align="center"><FONT face="Verdana" color="#000099" size="2"><STRONG>IE 
												To Whom Issued</STRONG></FONT></TD>
									<TD style="HEIGHT: 36px" align="center">
										<P><FONT face="Verdana" color="#000099" size="2"><STRONG>Status</STRONG></FONT></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 40%" align="center" colspan="2">
										<asp:Label id="lblReg1" runat="server" Font-Bold="True" Width="5%" ForeColor="Red" Font-Size="8pt"
											Font-Names="Verdana"></asp:Label>&nbsp;<asp:textbox id="txtHGFrom" onblur="change();check();" tabIndex="1" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="35%" MaxLength="7" Height="20px"></asp:textbox>&nbsp;<FONT face="Verdana" size="2"><STRONG><FONT color="#000099">to
													<asp:Label id="lblReg2" runat="server" Font-Bold="True" Width="5%" ForeColor="Red" Font-Size="8pt"
														Font-Names="Verdana"></asp:Label>
												</FONT></STRONG></FONT>
										<asp:textbox id="txtHGTo" onblur="change1();check();" tabIndex="2" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="35%" MaxLength="7" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 276px; HEIGHT: 31px">
										<asp:dropdownlist id="lstIE" tabIndex="3" runat="server" Width="294px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25%"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 31px" align="center">
										<asp:dropdownlist id="lstICStatus" tabIndex="4" runat="server" Width="110px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="25%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 40%" align="center">
										<FONT size="2" face="Verdana" color="#000099"><STRONG>
												<asp:label id="Label8" runat="server" Font-Bold="True" Width="100px" ForeColor="DarkBlue" Font-Size="9pt"
													Font-Names="Verdana">Status Date</asp:label>
												<asp:label id="Label3" runat="server" Font-Bold="True" Width="69px" ForeColor="DarkBlue" Font-Size="7pt"
													Font-Names="Verdana">(DD/MM/YYYY)</asp:label></STRONG></FONT></TD>
									<TD align="center" colspan="3"><FONT face="Verdana" color="#000099" size="2"><STRONG>Cancelling 
												Region</STRONG></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 40%" align="center">
										<asp:textbox runat="server" Width="82px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											MaxLength="10" Height="20px" id="txtStatusDt" onblur="check_date(txtStatusDt);" tabIndex="5"></asp:textbox></TD>
									<TD align="center" colspan="3">
										<asp:label id="lblReg" runat="server" Font-Bold="True" Width="53%" ForeColor="OrangeRed" Font-Size="8pt"
											Font-Names="Verdana"></asp:label></TD>
								</TR>
							</TABLE>
							<asp:label id="lblMsg" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana" Visible="False">To Save Record enter all the details and Click on Save button</asp:label>
							<asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana" Visible="False">To Modify Select the Record From the Grid, modify it and Click on Save button</asp:label>
							<asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana" Visible="False">To Search the Record enter Hologram No. From or Hologram No. To or IE and Click on Search button</asp:label>
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:button id="btnSave" tabIndex="6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button>
						<asp:button id="btnDelConfirm" tabIndex="7" runat="server" Font-Bold="True" Width="83px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Visible="False" Text="Delete!!!" onclick="btnDelConfirm_Click"></asp:button>
						<asp:button id="btnSearch" tabIndex="8" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button>
						<asp:button id="btnCancel" tabIndex="9" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<TITTLE:CUSTOMDATAGRID id="grdICCancel" runat="server" Width="100%" Height="8px" AutoGenerateColumns="False"
							PageSize="15" BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid"
							AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="350px" GridWidth="100%">
							<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
							<EditItemStyle Height="10%"></EditItemStyle>
							<FooterStyle CssClass="GridHeader"></FooterStyle>
							<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
								CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn FooterText="Delete">
									<HeaderStyle Width="7%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink id=HyperLink1 runat="server" NavigateUrl='<%#"Hologram_Cancel_Form.aspx?HG_NO_FR=" + DataBinder.Eval(Container.DataItem,"HG_NO_FR") + "&amp;HG_NO_TO=" + DataBinder.Eval(Container.DataItem,"HG_NO_TO")%>'>Select</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="HG_NO_FR" HeaderText="Hologram No From.">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_TO" HeaderText="Hologram No. To">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IE_NAME" HeaderText="IE">
									<HeaderStyle Width="35%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_STATUS" HeaderText="Status">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_STATUS_DT" HeaderText="Status Date">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_REGION" HeaderText="Region">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

