<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Laboratory_Master_Form.aspx.cs" Inherits="RBS.Laboratory_Master_Form.Laboratory_Master_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Laboratory_Master_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
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

		function fill_city_cd()
		 {
		 document.Form1.txtCity.value=document.Form1.lstCity.value;
		 
		 }
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px" id="Table1"
				border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD>
						<P align="center">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" style="HEIGHT: 27px">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="100%" Font-Bold="True">LABORATORY MASTER</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 319px">
						<P align="center">
							<TABLE style="WIDTH: 95%; HEIGHT: 100%" id="Table2" border="1" cellSpacing="1" cellPadding="1"
								width="707" bgColor="#f0f8ff" borderColor="#b0c4de">
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 12px" align="center" colSpan="4">
										<asp:label id="Label2" runat="server" Font-Bold="True" Width="74px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Lab ID</asp:label>
										<asp:label id="lblLabCD" runat="server" Font-Bold="True" Width="77px" ForeColor="OrangeRed"
											Font-Size="10pt" Font-Names="Verdana" BorderStyle="Inset" BorderColor="White">Lab Code</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">
										<asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Lab Name</asp:label></TD>
									<TD style="WIDTH: 30%" colSpan="3">
										<asp:textbox id="txtLabName" tabIndex="1" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 28px"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Lab Address</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 28px" colSpan="3">
										<asp:textbox id="txtAdd1" tabIndex="2" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="50px" MaxLength="100" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 35px"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True"> City</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 35px" colSpan="3"><asp:textbox onblur="check_date(txtVendAppFrom);" id="txtCity" tabIndex="3" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="10%" Height="20px" MaxLength="4"></asp:textbox><asp:button id="btnFCList" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="15%" Font-Bold="True" ToolTip="Enter the City Code or 1st 4 letters of CITY then click on select city Button" Text="Select City" onclick="btnFCList_Click"></asp:button>&nbsp;&nbsp;&nbsp;
										<asp:dropdownlist id="lstCity" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="62%" Height="25px" onChange="fill_city_cd();"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 28px"><asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Lab Approval</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 28px"><asp:dropdownlist id="lstLabApp" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="50%" Height="25px">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="N">NABL</asp:ListItem>
											<asp:ListItem Value="R">RITES</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label27" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Approval Period (DD/MM/YYYY)</asp:label></TD>
									<TD style="WIDTH: 35%">
										<asp:label id="Label13" runat="server" Font-Bold="True" Width="30px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"> From</asp:label><asp:textbox onblur="check_date(txtAppFrom);" id="txtAppFrom" tabIndex="7" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="35%" Height="20px" MaxLength="10"></asp:textbox>
										<asp:label id="Label14" runat="server" Font-Bold="True" Width="3px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"> To</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox onblur="check_date(txtAppTo);compareDates(txtAppFrom,txtAppTo,'Approval To Date Cannot Be Less Approval From Date');"
											id="txtAppTo" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="35%" Height="20px" MaxLength="10"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 22px"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Contact Person1</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 22px"><asp:textbox id="txtConPer1" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="70%" Height="20px" MaxLength="50"></asp:textbox></TD>
									<TD style="WIDTH: 15%; HEIGHT: 22px"><asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Tel No.</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 22px"><asp:textbox id="txtTel1" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="90%" Height="20px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"><asp:label id="Label19" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Email</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox id="txtEmail" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="247px" Height="20px" MaxLength="50"></asp:textbox></TD>
									<TD style="WIDTH: 15%"></TD>
									<TD style="WIDTH: 35%"></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center"><asp:button id="btnAdd" tabIndex="21" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Add New" onclick="btnAdd_Click"></asp:button><asp:button id="btnSave" tabIndex="22" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="24" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
