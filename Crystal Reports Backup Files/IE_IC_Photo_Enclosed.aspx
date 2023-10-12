<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_IC_Photo_Enclosed.aspx.cs" Inherits="RBS.IE_IC_Photo_Enclosed.IE_IC_Photo_Enclosed" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IE_IC_Photo_Enclosed</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if((trimAll(document.Form1.txtCaseNo.value)=="" || trimAll(document.Form1.txtRdt.value)=="" || trimAll(document.Form1.txtCSNO.value)=="") && (trimAll(document.Form1.txtBKNo.value)=="" || trimAll(document.Form1.txtSetNo.value)==""))
		{
		 alert("ENTER EITHER (CASE NO. AND CALL RECV DATE AND CALL SNO.) OR (BOOK NO. AND SET NO.) TO SEARCH");
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
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 184px"
				cellSpacing="1" cellPadding="1" border="0">
				<TBODY>
					<TR>
						<TD>
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
									BackColor="White" Width="100%" Font-Bold="True" Height="19px">PHOTOS SUBMITTED BY IE OF INSPECTIONS</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 100%" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="0" bgColor="aliceblue" border="1">
								<TR>
									<td style="WIDTH: 20%" vAlign="middle" align="center" colSpan="1" rowSpan="1"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="71px" Font-Bold="True">Case No.</asp:label></td>
									<td style="WIDTH: 20%" align="center"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="120px" Font-Bold="True">Call Recieve Date</asp:label></td>
									<td style="WIDTH: 20%" align="center"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="64px" Font-Bold="True">Call SNO.</asp:label></td>
									<td style="WIDTH: 20%" align="center"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="64px" Font-Bold="True">Book No.</asp:label></td>
									<td style="WIDTH: 20%" align="center"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="58px" Font-Bold="True">Set No.</asp:label></td>
								</TR>
								<TR>
									<TD align="center"><asp:textbox id="txtCaseNo" onblur="makeUppercase();" tabIndex="1" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="104px" Height="20px" MaxLength="9"></asp:textbox></TD>
									<TD align="center"><asp:textbox id="txtRdt" onblur="check_date(txtRdt);" tabIndex="2" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="104px" Height="20px" MaxLength="10"></asp:textbox></TD>
									<TD style="align: " align="center"><asp:textbox id="txtCSNO" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="49px" Height="20px" MaxLength="5"></asp:textbox></TD>
									<TD align="center"><asp:textbox id="txtBKNo" onblur="makeUppercasebk();" tabIndex="4" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="50px" Height="20px" MaxLength="4"></asp:textbox></TD>
									<TD align="center"><asp:textbox id="txtSetNo" onblur="change();" tabIndex="5" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="50px" Height="20px" MaxLength="3"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" width="100%"><asp:button id="btnSearch" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Width="112px" Font-Bold="True" Text="Search" onclick="btnSearch_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center" width="100%">
							<DIV><TITTLE:CUSTOMDATAGRID id="DgPhotos" runat="server" Width="100%" Height="8px" Visible="False" AutoGenerateColumns="False"
									PageSize="15" BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid"
									AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="200px" GridWidth="100%">
									<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
									<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
									<EditItemStyle Height="10%"></EditItemStyle>
									<FooterStyle CssClass="GridHeader"></FooterStyle>
									<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
									<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
										CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
									<Columns>
										<asp:BoundColumn DataField="CASE_NO" ReadOnly="True" HeaderText="Case No.">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CALL_DT" ReadOnly="True" HeaderText="Call Date">
											<HeaderStyle Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CALL_SNO" ReadOnly="True" HeaderText="Call Sno.">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BK_NO" HeaderText="Book No.">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="SET_NO" HeaderText="Set No.">
											<HeaderStyle Width="5%"></HeaderStyle>
										</asp:BoundColumn>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="FILE_1" DataTextField="FILE_1" HeaderText="Photo 1">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="FILE_2" DataTextField="FILE_2" HeaderText="Photo 2">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="FILE_3" DataTextField="FILE_3" HeaderText="Photo 3">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="FILE_4" DataTextField="FILE_4" HeaderText="Photo 4">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="FILE_5" DataTextField="FILE_5" HeaderText="Photo 5">
											<HeaderStyle Width="7%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="FILE_6" DataTextField="FILE_6" HeaderText="Photo 6">
											<HeaderStyle Width="6%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="FILE_7" DataTextField="FILE_7" HeaderText="Photo 7">
											<HeaderStyle Width="6%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="FILE_8" DataTextField="FILE_8" HeaderText="Photo 8">
											<HeaderStyle Width="6%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="FILE_9" DataTextField="FILE_9" HeaderText="Photo 9">
											<HeaderStyle Width="6%"></HeaderStyle>
										</asp:HyperLinkColumn>
										<asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="FILE_10" DataTextField="FILE_10" HeaderText="Photo 10">
											<HeaderStyle Width="6%"></HeaderStyle>
										</asp:HyperLinkColumn>
									</Columns>
								</TITTLE:CUSTOMDATAGRID></DIV>
						</TD>
					</TR>
					<TR>
						<TD align="center"><asp:button id="btnCancel" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Width="58px" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
