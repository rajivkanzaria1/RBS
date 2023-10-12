<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IC_Cancel_Form.aspx.cs" Inherits="RBS.IC_Cancel_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IC_Cancel_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		
			if(trimAll(document.Form1.txtBKNo.value)=="")
			{
				alert("BOOK NO. CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtSetNO.value)=="")
			{
				alert("SET NO. CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.lstIE.value=="")
			{
				alert("IE TO WHOM ISSUED CANNOT BE LEFT BLANK");
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
		
			if(trimAll(document.Form1.txtBKNo.value)=="" && trimAll(document.Form1.txtSetNO.value)=="" && document.Form1.lstIE.value=="")
			{
				alert("BOOK NO. AND SET NO. AND IE TO WHOM ISSUED CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else
			
			return;		 
		}
		
		function validate1()
		{
		
			if(trimAll(document.Form1.txtBKNo.value)=="")
			{
				alert("BOOK NO. CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtSetNO.value)=="")
			{
				alert("SET NO. CANNOT BE LEFT BLANK");
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
		
		function focus()
		{
			if(document.Form1.txtBKNo.disabled==false)
			{
			document.Form1.txtBKNo.focus();
			}
			else
			{
			document.Form1.txtCertFrom.focus();
			}
			return false;
		}
		
		function makeUppercase()
		 {
			document.Form1.txtBKNo.value = document.Form1.txtBKNo.value.toUpperCase();
		 } 
		 
		function change()
		{
			var d=document.Form1.txtSetNO.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="00" + d;
				document.Form1.txtSetNO.value=d;
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="0" + d;
				document.Form1.txtSetNO.value=d;
				event.returnValue=false;
			}
			return false;	
		}
		
		function sFocus()
		 {
		 
		 document.Form1.txtBKNo.focus();
		 }
		
        </script>
	</HEAD>
	<body onload=" sFocus();">
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
								BackColor="White" Width="384px" Font-Bold="True"> IC CANCELLATION FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 707px; HEIGHT: 104px" borderColor="#bfcbe3" cellSpacing="1"
								cellPadding="1" width="707" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 99px; HEIGHT: 36px" align="center"><FONT face="Verdana" color="#000099" size="2"><STRONG>Book&nbsp;No.</STRONG></FONT></TD>
									<TD style="WIDTH: 156px; HEIGHT: 36px" align="center"><FONT face="Verdana" color="#000099" size="2"><STRONG>Set 
												No. </STRONG></FONT>
									</TD>
									<TD style="WIDTH: 276px; HEIGHT: 36px" align="center"><FONT face="Verdana" color="#000099" size="2"><STRONG>IE 
												To Whom Issued</STRONG></FONT></TD>
									<TD style="HEIGHT: 36px" align="center">
										<P><FONT face="Verdana" color="#000099" size="2"><STRONG>Status</STRONG></FONT></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 99px; HEIGHT: 31px" align="center">
										<asp:textbox id="txtBKNo" onblur="makeUppercase();" tabIndex="1" runat="server" Width="47px"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="4" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 156px; HEIGHT: 31px" align="center">&nbsp;
										<asp:textbox id="txtSetNO" onblur="change();" tabIndex="2" runat="server" Width="44px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="3" Height="20px"></asp:textbox>&nbsp;<FONT face="Verdana" size="2"><STRONG><FONT color="#000099">
												</FONT></STRONG></FONT>
									</TD>
									<TD style="WIDTH: 276px; HEIGHT: 31px">
										<asp:dropdownlist id="lstIE" tabIndex="3" runat="server" Width="294px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25%"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 31px" align="center">
										<asp:dropdownlist id="lstICStatus" tabIndex="4" runat="server" Width="110px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="25%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 99px" align="center"><FONT face="Verdana" color="#000099" size="2"><STRONG>
												<asp:label id="Label8" runat="server" Font-Bold="True" Width="100px" ForeColor="DarkBlue" Font-Size="9pt"
													Font-Names="Verdana">Status Date</asp:label>
												<asp:label id="Label3" runat="server" Font-Bold="True" Width="69px" ForeColor="DarkBlue" Font-Size="7pt"
													Font-Names="Verdana">(DD/MM/YYYY)</asp:label></STRONG></FONT></TD>
									<TD style="WIDTH: 437px" align="center" colSpan="2"><P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" color="#000099" size="2"><STRONG>Remarks</STRONG></FONT>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										</P>
									</TD>
									<TD align="center"><FONT face="Verdana" color="#000099" size="2"><STRONG>Cancelling Region</STRONG></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 99px" align="center">
										<asp:textbox id="txtStatusDt" onblur="check_date(txtStatusDt);" tabIndex="5" runat="server" Width="82px"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 437px" align="center" colSpan="2">
										<asp:textbox id="txtRemarks" onblur="change();" tabIndex="6" runat="server" Width="90%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="50"></asp:textbox></TD>
									<TD align="center">
										<asp:label id="lblReg" runat="server" Font-Bold="True" Width="53%" ForeColor="OrangeRed" Font-Size="8pt"
											Font-Names="Verdana"></asp:label></TD>
								</TR>
							</TABLE>
							<asp:label id="lblMsg" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana" Visible="False">To Save Record enter all the details and Click on Save button</asp:label>
							<asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana" Visible="False">To Modify Select the Record From the Grid, modify it and Click on Save button</asp:label>
							<asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana" Visible="False">ToSearch the Record enter Book or Set No. or IE and Click on Search button</asp:label>
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
										<asp:HyperLink id=HyperLink1 runat="server" NavigateUrl='<%#"IC_Cancel_Form.aspx?BK_NO=" + DataBinder.Eval(Container.DataItem,"BK_NO") + "&amp;SET_NO=" + DataBinder.Eval(Container.DataItem,"SET_NO")%>'>Select</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="BK_NO" HeaderText="Book No.">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SET_NO" HeaderText="Set No.">
									<HeaderStyle Width="8%"></HeaderStyle>
									<ItemStyle Font-Names="Verdana" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IE_NAME" HeaderText="IE">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IC_STATUS" HeaderText="Status">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="STATUS_DT" HeaderText="Status Date">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="REMARKS" HeaderText="Remarks">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="REGION" HeaderText="Region">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

