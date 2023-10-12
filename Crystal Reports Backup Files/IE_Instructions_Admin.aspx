<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_Instructions_Admin.aspx.cs" Inherits="RBS.IE_Instructions_Admin.IE_Instructions_Admin" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Messages Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		
		if(trimAll(document.Form1.txtMessage.value)=="")
		 {
		 alert("MESSAGE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtLNO.value).length>50)
		 {
		 alert("LETTER NO SHOULD NOT BE MORE THEN 50 CHARACTERS");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtMessage.value).length>800)
		 {
		 alert("MESSAGE SHOULD NOT BE MORE THEN 800 CHARACTERS");
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
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtSDesc.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="260px" Font-Bold="True">INSTRUCTIONS FOR IE</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 70%" borderColor="#b0c4de" cellSpacing="0" cellPadding="1"
								width="454" align="center" bgColor="#f0f8ff" border="1">
								<TR>
									<TD align="left">
										<asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Letter No.</asp:label></TD>
									<TD>
										<asp:textbox id="txtLNO" tabIndex="1" runat="server" Width="361px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" TextMode="MultiLine" MaxLength="50" Height="24px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="left">
										<asp:label id="Label5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Letter Date</asp:label></TD>
									<TD>
										<asp:textbox onblur="check_date(txtLDT);" id="txtLDT" tabIndex="2" runat="server" Width="88px"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Height="20px"></asp:textbox></TD>
								</TR>
								<TR align="center">
									<TD align="left"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Font-Bold="True"> Instruction</asp:label></TD>
									<TD align="left"><asp:textbox id="txtMessage" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="361px" Height="64px" MaxLength="500" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkMagenta"
								Width="346px" Font-Bold="True">* To Add New Record Fill Values and Click on Save</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelConfirm" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Width="72px" Font-Bold="True" Text="Delete!!!" Visible="False" onclick="btnDelConfirm_Click"></asp:button><asp:button id="btnCancel" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Width="72px" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<DIV><TITTLE:CUSTOMDATAGRID id="grdMessage" runat="server" BorderColor="DarkBlue" Width="100%" AutoGenerateColumns="False"
								Height="8px" GridWidth="90%" GridHeight="250px" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px"
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
									<asp:TemplateColumn FooterText="Delete">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"IE_Instructions_Admin.aspx?MESSAGE_ID=" + DataBinder.Eval(Container.DataItem,"MESSAGE_ID") +"&amp;ACTION=D"%>' runat="server">Delete</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn FooterText="Edit">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"IE_Instructions_Admin.aspx?MESSAGE_ID=" + DataBinder.Eval(Container.DataItem,"MESSAGE_ID") +"&amp;ACTION=M"%>' runat="server">Edit</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="LETTER_NO" HeaderText="Letter No.">
										<HeaderStyle Width="25%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LETTER_DT" HeaderText="Letter Dt.">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MESSAGE" HeaderText="Message">
										<HeaderStyle Width="60%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="MESSAGE_ID" HeaderText="MESSAGE_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DATETIME" HeaderText="DATETIME"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
