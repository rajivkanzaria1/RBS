<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_Claim_Search.aspx.cs" Inherits="RBS.IE_Claim_Search.IE_Claim_Search" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IE_Claim_Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
			{
				if(trimAll(document.Form1.txtCNO.value)=="")
					{
							alert("Claim No. Should not be left blank!!!");
							event.returnValue=false;
					}
			}
			
		function validate1()
			{
				if(trimAll(document.Form1.txtCNO.value)=="" && trimAll(document.Form1.txtCDT.value)=="" && trimAll(document.Form1.lstIE.value)=="")
					{
							alert("Enter Either Claim No. OR Claim Date OR IE To Seacrh!!!");
							event.returnValue=false;
					}
			}
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Width="196px" ForeColor="DarkBlue" BackColor="White"
								Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">IE CLAIM SEARCH FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="left">
						<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="1"
							cellPadding="1" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 15%; HEIGHT: 25px" vAlign="top"><asp:label id="Label2" runat="server" Width="64px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> Claim No.</asp:label></TD>
								<TD style="WIDTH: 17.68%; HEIGHT: 25px" vAlign="top"><asp:textbox id="txtCNO" onblur="check_date(txtCDT);" tabIndex="1" runat="server" Width="90%"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="11" Height="20px"></asp:textbox></TD>
								<TD style="WIDTH: 15%; HEIGHT: 25px" vAlign="top" align="left"><asp:label id="Label6" runat="server" Width="80px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Claim Date.</asp:label></TD>
								<TD style="WIDTH: 15.88%; HEIGHT: 25px" vAlign="top">
									<P><asp:textbox id="txtCDT" onblur="check_date(txtCDT);" tabIndex="2" runat="server" Width="90%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="11" Height="20px"></asp:textbox></P>
								</TD>
								<TD style="WIDTH: 5.76%; HEIGHT: 25px" vAlign="top"><asp:label id="Label10" runat="server" Width="32px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> IE</asp:label></TD>
								<TD style="WIDTH: 40%; HEIGHT: 25px" vAlign="top"><P><asp:dropdownlist id="lstIE" tabIndex="3" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"></asp:dropdownlist></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 15%" vAlign="top" align="center" colSpan="6"><asp:button id="btnSearch" tabIndex="4" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button><asp:button id="btnSubmit" tabIndex="5" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Submit" onclick="btnSubmit_Click"></asp:button><asp:button id="btnAdd" tabIndex="6" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Text="Add New" onclick="btnAdd_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="left"><TITTLE:CUSTOMDATAGRID id="grdVDt" runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="250px"
							FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" CellPadding="2"
							FreezeRows="0" PageSize="15" AutoGenerateColumns="False" BorderColor="DarkBlue">
							<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
							<EditItemStyle Height="10%"></EditItemStyle>
							<FooterStyle CssClass="GridHeader"></FooterStyle>
							<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
								CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Claim No.">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink id=HyperLink1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CLAIM_NO")%>' NavigateUrl='<%#"IE_Claim_Form.aspx?CLAIM_NO=" + DataBinder.Eval(Container.DataItem,"CLAIM_NO") + "&amp;ACTION=M" %>'>HyperLink</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="CLAIM_NO" HeaderText="Claim No.">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CLAIM_DT" HeaderText="Claim Date">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RECV_DT" HeaderText="Claim Receive Date">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IE_NAME" HeaderText="IE">
									<HeaderStyle Width="35%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
