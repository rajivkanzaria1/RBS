<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="City_Form.aspx.cs" Inherits="RBS.City_Form.City_Form" %>


<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>City Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{
		
		if(document.Form1.txtCity.value=="" || document.Form1.txtPIN.value=="" || document.Form1.lstState.value=="")
		 {
		 alert("CITY, PIN & STATE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else
		{
		document.Form1.btnSave.style.visibility = 'hidden';
		 alert("YOUR RECORD IS SAVED")
		}
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
		 
		 function del2()
		 {
		  if(document.Form1.txtCityCD.value=="")
		 {
		 alert("PLZ ENTER CITY CODE FIRST THEN CLICK ON MODIFY OR DELETE");
		 event.returnValue=false;
		 }
		 }
		
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtLocation.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD>
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="108px" BackColor="White" ForeColor="DarkBlue"
									Font-Size="10pt" Font-Names="Verdana">CITY DETAILS</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD>
							<P align="center">
								<TABLE id="Table2" style="HEIGHT: 72px" borderColor="#b0c4de" cellSpacing="0" cellPadding="1"
									width="70%" bgColor="#f0f8ff" border="1">
									<TR align="center">
										<TD style="WIDTH: 24.31%; HEIGHT: 25px"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">Location</asp:label></TD>
										<TD style="WIDTH: 30.97%; HEIGHT: 25px"><asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">City <font color="red">*</font></asp:label></TD>
										<TD style="WIDTH: 25%; HEIGHT: 25px">
											<asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Font-Bold="True">PIN CODE <font color="red">*</font></asp:label></TD>
										<TD style="WIDTH: 25%; HEIGHT: 25px"><asp:label id="lst" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana">State <font color="red">*</font></asp:label></TD>
									</TR>
									<TR align="center">
										<TD style="WIDTH: 24.31%"><asp:textbox id="txtLocation" tabIndex="1" runat="server" Width="95%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="20px" MaxLength="50"></asp:textbox></TD>
										<TD style="WIDTH: 30.97%"><asp:textbox id="txtCity" tabIndex="2" runat="server" Width="95%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="20px" MaxLength="50"></asp:textbox></TD>
										<TD style="WIDTH: 25%">
											<asp:textbox id="txtPIN" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="95%" MaxLength="6" Height="20px"></asp:textbox></TD>
										<TD style="WIDTH: 25%"><asp:dropdownlist id="lstState" tabIndex="3" runat="server" Width="176px" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="27px"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">* To Add New Record Fill Values and Click on Save</asp:label><asp:label id="Label5" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
									Font-Size="8pt" Font-Names="Verdana">* To Search a City Enter First Few Characters Of Location OR City and Click on Search.</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD align="center"><asp:button id="btnSave" tabIndex="6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelConfirm" tabIndex="9" runat="server" Font-Bold="True" Width="75px" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Delete!!!" Visible="False" onclick="btnDelConfirm_Click"></asp:button><asp:button id="btnSearch" tabIndex="9" runat="server" Font-Bold="True" Width="65px" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button><asp:button id="btnCancel" tabIndex="10" runat="server" Font-Bold="True" Width="75px" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD>
							<P>&nbsp;</P>
							<P align="center"><DIV><TITTLE:CUSTOMDATAGRID id="grdCity" runat="server" Width="100%" Height="8px" HorizontalAlign="Left" PageSize="15"
										FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
										BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="220px" GridWidth="100%">
										<PagerStyle NextPageText="Next" PrevPageText="Prev" HorizontalAlign="Center" ForeColor="Blue"
											Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
										<EditItemStyle Height="10%"></EditItemStyle>
										<FooterStyle CssClass="GridHeader"></FooterStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
										<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%"
											ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn FooterText="Delete">
												<ItemTemplate>
													<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"City_Form.aspx?CITY_CD=" + DataBinder.Eval(Container.DataItem,"CITY_CD") + "&amp;ACTION=D"%>' runat="server">Delete</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn FooterText="Edit">
												<ItemTemplate>
													<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"City_Form.aspx?CITY_CD=" + DataBinder.Eval(Container.DataItem,"CITY_CD") + "&amp;ACTION=E"%>' runat="server">Edit</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="CITY_CD" HeaderText="City Code"></asp:BoundColumn>
											<asp:BoundColumn DataField="LOCATION" HeaderText="Location">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CITY" HeaderText="City">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PIN_CODE" HeaderText="PIN"></asp:BoundColumn>
											<asp:BoundColumn DataField="STATE_NAME" HeaderText="State">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
									</TITTLE:CUSTOMDATAGRID></DIV>
							<P></P>
							<P>&nbsp;</P>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		<DIV></DIV>
		</TD></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
