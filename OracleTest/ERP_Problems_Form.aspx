<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERP_Problems_Form.aspx.cs" Inherits="RBS.ERP_Problems_Form.ERP_Problems_Form" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ERP_Problems_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		
		if(trimAll(document.Form1.txtName.value)=="")
		 {
		 alert("NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else if(trimAll(document.Form1.txtDesc.value)=="")
		 {
		 alert("PROBLEM DESCRIPTION CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else
		{
		document.Form1.btnSave.style.visibility = 'hidden';
		 alert("YOUR RECORD IS SAVED")
		}
		 return;
				 		 
		}
		
		
		 
		
		
        </script>
  </HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<P align="center">&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD align="center" style="HEIGHT: 56px">
						<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="243px" BackColor="White" ForeColor="DarkBlue"
								Font-Size="10pt" Font-Names="Verdana">PROBLEMS FACED IN ERP</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="707" bgColor="#f0f8ff" border="1"
								style="WIDTH: 707px; HEIGHT: 128px" borderColor=#b0c4de>
								<TR>
									<TD style="WIDTH: 13.32%"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"> Name</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:textbox id="txtName" tabIndex="1" runat="server" Width="40%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" MaxLength="30" Height="20px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 13.32%; HEIGHT: 36px">
										<asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Problem Description</asp:label></TD>
									<TD style="WIDTH: 50%; HEIGHT: 36px">
										<asp:textbox id="txtDesc" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="90%" Height="44px" MaxLength="300" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 13.32%">
										<asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Problem Resolution</asp:label></TD>
									<TD style="WIDTH: 50%">
										<asp:textbox id="txtResolution" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="90%" Height="42px" MaxLength="300" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* To Add New Record Fill Values and Click on Save</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" tabIndex="3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="6" runat="server" Font-Bold="True" Width="75px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
