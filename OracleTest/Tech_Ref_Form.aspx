<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tech_Ref_Form.aspx.cs" Inherits="RBS.Tech_Ref_Form.Tech_Ref_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Tech_Ref_Form</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.toDt.value)=="")
		 {
		  alert("Select Letter Date");
		 event.returnValue=false;
		 }		 
		 else if(trimAll(document.Form1.Textletter.value)=="")
		 {
		  alert("RITES LETTER NO. CAN NOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.lstCOType.value)=="")
		 {
		  alert("SELECT CONTROLLING OFFICER");
		 event.returnValue=false;
		 }
		 else if(document.Form1.lstIEType.value=="")
		 {
		 alert("INSPECTION ENGINEER CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.txtItem.value=="")
		 {
		 alert("ITEM CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.txtSpec.value=="")
		 {
		 alert("SPEC & DRG CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else  if(document.Form1.TextRef.value=="")
		 {
		 alert("REFERENCE MADE TO CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
         else if(document.Form1.TextTR.value=="")
		 {
		 alert("CONTACT OF TECHNICAL REFERENCE IN BRIEF CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else 
		return;
			
		}
        </script>
	</HEAD>
	<body bgColor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 123px; TOP: 8px; LEFT: 8px" id="Table1"
				border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD>
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="274px" BackColor="White" ForeColor="DarkBlue"
									Font-Size="10pt" Font-Names="Verdana">Technical References</asp:label></P>
							<p><asp:label id="lblTCode" runat="server" Font-Bold="True" Width="103px" ForeColor="OrangeRed"
									Font-Size="8pt" Font-Names="Verdana">Technical Reference Code</asp:label></p>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 50%" align="center">
							<TABLE style="WIDTH: 100%; HEIGHT: 100%" id="Table4" border="1" cellSpacing="0" borderColor="#b0c4de"
								cellPadding="0" bgColor="aliceblue">
								<TBODY>
									<TR bgColor="#f0f8ff">
										<TD style="WIDTH: 30%; HEIGHT: 52px" align="right"><B><FONT color="darkblue" size="2" face="Verdana"><asp:label id="Label5" runat="server" Font-Bold="True" Width="138px" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana">Letter Date<font color="red" size="1">*</font> </asp:label></FONT></B></TD>
										<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><B><FONT color="darkblue" size="2" face="Verdana"></FONT></B><asp:textbox onblur="check_date(toDt)" style="TEXT-ALIGN: center" id="toDt" tabIndex="4" runat="server"
												Width="100px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox>&nbsp;
											<asp:label id="Label9" runat="server" Font-Bold="True" Width="289px" ForeColor="DarkMagenta"
												Font-Size="8pt" Font-Names="Verdana">* Enter Date in DD/MM/YYYY Format.</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 30%; HEIGHT: 52px" align="right"><asp:label id="Label11" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">RITES Letter No.<font color="red" size="1">*</font></asp:label></TD>
										<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="Textletter" tabIndex="2" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="20px" MaxLength="100"></asp:textbox></TD>
									<TR>
									<TR>
										<TD style="WIDTH: 30%; HEIGHT: 28px" align="right"><asp:label id="Label6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">CONTROLLING OFFICER<font color="red" size="1">*</font> </asp:label></TD>
										<TD style="WIDTH: 70%" colSpan="3"><asp:dropdownlist id="lstCOType" tabIndex="1" runat="server" Width="98%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 30%; HEIGHT: 34px" align="right"><asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">INSPECTION ENGINEER<font color="red" size="1">*</font> </asp:label></TD>
										<TD style="WIDTH: 70%; HEIGHT: 34px" colSpan="3"><asp:dropdownlist id="lstIEType" tabIndex="2" runat="server" Width="98%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana"></asp:dropdownlist></TD>
									</TR>
					</TR>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="right"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana">ITEM<font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="txtItem" tabIndex="2" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Height="40px" MaxLength="250" TextMode="MultiLine"></asp:textbox></TD>
					<TR>
					</TR>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="right"><asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana">SPEC & DRG<font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="txtSpec" tabIndex="2" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Height="40px" MaxLength="250" TextMode="MultiLine"></asp:textbox></TD>
					<TR>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="right"><asp:label id="Label8" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana">REFERENCE MADE TO<font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="TextRef" tabIndex="2" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Height="40px" MaxLength="250" TextMode="MultiLine"></asp:textbox></TD>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="right"><asp:label id="Label10" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana">CONTACT OF TECHNICAL REFERENCE IN BRIEF<font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="TextTR" tabIndex="2" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Height="60px" MaxLength="500" TextMode="MultiLine"></asp:textbox></TD>
					<TR>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 23px" vAlign="top"><asp:label id="Label7" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana">Upload Tech Ref <FONT COLOR="OrangeRed">(In PDF Only)</FONT></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 23px" vAlign="top"><INPUT style="WIDTH: 70%; FONT-FAMILY: Verdana; HEIGHT: 25px; COLOR: navy; FONT-SIZE: 8pt; FONT-WEIGHT: bold"
								id="File1" tabIndex="0" size="51" type="file" name="File1" runat="server"><asp:hyperlink id="HyperLink1" runat="server" Target="_blank" Visible="False">HyperLink</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 23px" vAlign="top"><asp:label id="Label12" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana">Upload Tech Ref Reply<FONT COLOR="OrangeRed">(In PDF Only)</FONT></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 23px" vAlign="top"><INPUT style="WIDTH: 70%; FONT-FAMILY: Verdana; HEIGHT: 25px; COLOR: navy; FONT-SIZE: 8pt; FONT-WEIGHT: bold"
								id="File2" tabIndex="0" size="51" type="file" name="File2" runat="server"><asp:hyperlink id="Hyperlink2" runat="server" Target="_blank" Visible="False">HyperLink1</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 30%; HEIGHT: 23px" vAlign="top"></TD>
						<TD style="WIDTH: 70%; HEIGHT: 23px" vAlign="top"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 21px" colSpan="2" align="center"><asp:button id="btnSave" tabIndex="23" runat="server" Font-Bold="True" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnEdit" tabIndex="24" runat="server" Font-Bold="True" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Visible="False" Text="Update" onclick="btnEdit_Click"></asp:button><asp:button id="btnCancel" tabIndex="26" runat="server" Font-Bold="True" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:button id="btnSearch" runat="server" Font-Bold="True" Width="65px" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 21px" colSpan="2" align="center"><asp:DataGrid id="grdTech" runat="server" Width="100%" Height="8px" HorizontalAlign="Left" PageSize="15"
								FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue" BorderWidth="1px" FreezeColumns="0"
								FreezeHeader="True" AutoGenerateColumns="False" GridHeight="220px" GridWidth="100%">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%"
									ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn FooterText="Edit">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"Tech_Ref_Form.aspx?TECH_ID=" + DataBinder.Eval(Container.DataItem,"TECH_ID") + "&amp;ACTION=E"%>' runat="server">Edit</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="TECH_ID" HeaderText="Technical Reference Code">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cm_name" HeaderText="CM">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ie_name" HeaderText="IE">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="item_des" HeaderText="Item Desc">
										<HeaderStyle Width="30%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="letter_no" HeaderText="Tech Letter No">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="tech_date" HeaderText="Tech Date">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:DataGrid></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TD></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
