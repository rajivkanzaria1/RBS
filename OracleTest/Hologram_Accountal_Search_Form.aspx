<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hologram_Accountal_Search_Form.aspx.cs" Inherits="RBS.Hologram_Accountal_Search_Form.Hologram_Accountal_Search_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Hologram_Accountal_Search_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
		
			function validate2()
			{
				if(trimAll(document.Form1.txtBKNo.value)=="" && trimAll(document.Form1.txtSetNo.value)=="")
				{
				alert("ENTER BOOK NO. OR SET NO. TO SEARCH");
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
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 35px" align="center" colSpan="2" height="35">
						<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1><A href="Web.config"></A>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 32px" align="center" colSpan="2"><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="310px">HOLOGRAM ACCOUNTAL</asp:label></TD>
				</TR>
				<tr>
					<td colspan="2" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="2" borderColor="#ccccff" align="center">
							<TR>
								<TD style="WIDTH: 7.74%; HEIGHT: 35px" align="center" bgColor="#ffcccc"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Book No.</asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 35px" align="center" bgColor="#ffcccc"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Set No.</asp:label></TD>
							</TR>
							<tr>
								<TD style="WIDTH: 16.15%; HEIGHT: 37px" align="center" bgColor="#ffcccc"><asp:textbox id="txtBKNo" onblur="makeUppercasebk();" tabIndex="1" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="50px" Height="20px" MaxLength="4"></asp:textbox></TD>
								<TD style="WIDTH: 20%; HEIGHT: 37px" align="center" bgColor="#ffcccc"><asp:textbox id="txtSetNo" onblur="change();" tabIndex="2" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Width="50px" Height="20px" MaxLength="3"></asp:textbox></TD>
							</tr>
						</TABLE>
						<asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">Enter Book No. & Set No. Against which the Holograms are to be linked.</asp:label>
					</td>
				</tr>
				<tr>
					<td style="HEIGHT: 36px" align="center" colSpan="2">
						<asp:button id="btnAdd" tabIndex="9" runat="server" Width="78px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Submit" onclick="btnAdd_Click"></asp:button><asp:button id="btnDelete" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Width="67px" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnSearch" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt"
							Font-Bold="True" ForeColor="DarkBlue" Width="112px" Text="Search" onclick="btnSearch_Click"></asp:button></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="3">
						<asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana">Search Result is Sorted on Book No. & Set No.</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TITTLE:CUSTOMDATAGRID id="grdIC" runat="server" Width="90%" Height="8px" GridWidth="100%" GridHeight="200px"
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
										<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"Hologram_Accountal_Search_Form.aspx?BK_NO=" + DataBinder.Eval(Container.DataItem,"BK_NO")+ "&amp;SET_NO=" + DataBinder.Eval(Container.DataItem,"SET_NO")%>'>Select</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="CASE_NO" HeaderText="Case No.">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BK_NO" HeaderText="Book No">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SET_NO" HeaderText="Set No.">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IE_SNAME" HeaderText="IE">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_MATERIAL" HeaderText="Holograms used on Material">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_SAMPLE" HeaderText="Holograms used on Samples">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_TEST" HeaderText="Holograms used on Test ">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_IC" HeaderText="Holograms used on IC ">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_IC_DOC" HeaderText="Hologram used on IC Doc">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_OT" HeaderText="Holograms used on Other Location">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
