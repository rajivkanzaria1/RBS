<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_CO_Form.aspx.cs" Inherits="RBS.IE_CO_Form.IE_CO_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Inspection Engineer's Controlling Officer Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(document.Form1.txtCOName.value=="")
		 {
		 alert("CONTROLLING OFFICER NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCOEmail.value)!="")
		 {
			if (echeck(document.Form1.txtCOEmail.value)==false)
			{
				document.Form1.txtCOEmail.focus();
				event.returnValue=false;
			}
			else
			return;
			

		 }
		 else
		 {
			document.Form1.btnSave.style.visibility = 'hidden';
			alert("YOUR RECORD IS SAVED")
		 }
		 return;
	 
		}
		 function del2()
		 {
			if(document.Form1.txtCOCD.value=="")
			{
			alert("PLZ ENTER CONTOLLING OFFICER'S CODE FIRST THEN CLICK ON MODIFY OR DELETE");
			event.returnValue=false;
			}
		 }
		function del()
		{
		var d=confirm("Click OK to Confirm Delete!!!");
		if(d==true)
		event.returnValue=true;
		else
		event.returnValue=false;
		}
		function echeck(str) 
		{

		var at="@";
		var dot=".";
		var lat=str.indexOf(at);
		var lstr=str.length;
		var ldot=str.indexOf(dot);
		if (str.indexOf(at)==-1){
		   alert("Invalid E-mail ID");
		   return false;
		}

		if (str.indexOf(at)==-1 || str.indexOf(at)==0 || str.indexOf(at)==lstr)
		{
		   alert("Invalid E-mail ID");
		   return false;
		}

		if (str.indexOf(dot)==-1 || str.indexOf(dot)==0 || str.indexOf(dot)==lstr)
		{
		    alert("Invalid E-mail ID");
		    return false;
		}

		 if (str.indexOf(at,(lat+1))!=-1)
		 {
		    alert("Invalid E-mail ID");
		    return false;
		 }

		 if (str.substring(lat-1,lat)==dot || str.substring(lat+1,lat+2)==dot)
		 {
		    alert("Invalid E-mail ID");
		    return false;
		 }

		 if (str.indexOf(dot,(lat+2))==-1)
		 {
		    alert("Invalid E-mail ID");
		    return false;
		 }
		
		 if (str.indexOf(" ")!=-1)
		 {
		    alert("Invalid E-mail ID");
		    return false;
		 }

 		 return true;					
	}
		
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtCOName.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 123px; TOP: 8px; LEFT: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="384px" BackColor="White" ForeColor="DarkBlue"
								Font-Size="10pt" Font-Names="Verdana">CONTROLLING OFFICERS OF INSPECTION ENGINEERS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 90%; HEIGHT: 50px" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="1" bgColor="#f0f8ff" border="1">
								<TR align="center">
									<TD style="WIDTH: 20%"><asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Controlling Officer</asp:label></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Designation</asp:label></TD>
									<TD style="WIDTH: 25%"><asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Phone No.</asp:label></TD>
									<TD style="WIDTH: 20%" align="center"><asp:label id="Label6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Email</asp:label></TD>
									<TD style="WIDTH: 20%"><asp:label id="Label17" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Controlling Officer Status</asp:label></TD>
								</TR>
								<TR align="center">
									<TD style="WIDTH: 20%"><asp:textbox id="txtCOName" tabIndex="1" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" MaxLength="30" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 15%"><asp:dropdownlist id="lstDesig" tabIndex="2" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 25%"><asp:textbox id="txtCOPH_NO" tabIndex="3" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" MaxLength="21" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 20%"><asp:textbox id="txtCOEmail" tabIndex="4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" MaxLength="50" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 20%"><asp:dropdownlist id="lstStatus" tabIndex="17" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%"><asp:label id="Label_type" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana">CM Type</asp:label></TD>
									<TD style="WIDTH: 20%"><asp:dropdownlist id="DL_TYPE" tabIndex="17" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px">
											<asp:ListItem Value="C">CM</asp:ListItem>
											<asp:ListItem Value="D">DFO</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD style="WIDTH: 25%"><asp:label id="Label15" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Status Date (DD/MM/YYYY)</asp:label></TD>
									<TD style="WIDTH: 30%" colSpan="2"><asp:textbox id="txtStatusDT" onblur="check_date(txtStatusDT);" tabIndex="18" runat="server"
											Width="30%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10" Height="20px"></asp:textbox></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="Label2" runat="server" Font-Bold="True" Width="346px" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* To Add New Record Fill Values and Click on Save</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True" Text="Save" tabIndex="5" onclick="btnSave_Click"></asp:button><asp:button id="btnDelConfirm" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Width="83px" Font-Bold="True" Text="Delete!!!" Visible="False" tabIndex="6" onclick="btnDelConfirm_Click"></asp:button>
						<asp:button id="btnCancel" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Cancel" tabIndex="7" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<P>&nbsp;</P>
						<P align="center"><asp:datagrid id="grdIECO" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" Height="96px"
								AutoGenerateColumns="False" BorderStyle="Groove" BorderColor="DarkBlue" onprerender="grdIECO_PreRender">
								<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
									VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn FooterText="Delete">
										<HeaderStyle Width="8%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"IE_CO_Form.aspx?CO_CD=" + DataBinder.Eval(Container.DataItem,"CO_CD") + "&amp;ACTION=D"%>' runat="server">Delete</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn FooterText="Edit">
										<HeaderStyle Width="7%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"IE_CO_Form.aspx?CO_CD=" + DataBinder.Eval(Container.DataItem,"CO_CD") + "&amp;ACTION=E"%>' runat="server">Edit</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="CO_CD" HeaderText="Controlling Officer Code">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_NAME" HeaderText="Controlling Officer Name">
										<HeaderStyle Width="30%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_DESIG" HeaderText="Designation">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_PHONE_NO" HeaderText="Phone No.">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_EMAIL" HeaderText="Email">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_TYPE" HeaderText="Type">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
