<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client_Feedback_Form.aspx.cs" Inherits="RBS.Client_Feedback_Form.Client_Feedback_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Client_Feedback_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		
		
		function validate()
		{
		 if(trimAll(document.Form1.txtClient.value)=="")
		 {
		 alert("ORGANISATION NAME CANNOT BE LEFT BLANK!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtOffName.value)=="")
		 {
		 alert("OFFICIAL NAME CANNOT BE LEFT BLANK!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtOffName.value)=="")
		 {
		 alert("OFFICIAL NAME CANNOT BE LEFT BLANK!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtMobile.value)=="")
		 {
		 alert("MOBILE NO.CANNOT BE LEFT BLANK!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtMobile.value)!="" && document.Form1.txtMobile.value.length < 10)
		 {
		 alert("MOBILE NO. SHOULD BE OF 10 DIGITS!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtMobile.value)!="" && IsNumeric(document.Form1.txtMobile.value) == false)
		 {
		 alert("MOBILE NO. CONTAINS INVALID CHARACTERS!!!");
		 event.returnValue=false;
		 }
		 else if(document.Form1.lstRegionCd.value=="")
		 {
		 alert("REGION CANNOT BE BLANK!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtEmail.value)!="")
		 {
			if (echeck(document.Form1.txtEmail.value)==false)
			{
				document.Form1.txtEmail.focus();
				event.returnValue=false;
			}
			
		 }
		 else if(document.Form1.rdbBA1.checked==false && document.Form1.rdbG1.checked==false && document.Form1.rdbVG1.checked==false && document.Form1.rdbEX1.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 1!!!");
		  event.returnValue=false;
		 }
		 else if(document.Form1.rdbBA2.checked==false && document.Form1.rdbG2.checked==false && document.Form1.rdbVG2.checked==false && document.Form1.rdbEX2.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 2!!!");
		  event.returnValue=false;
		 }
		 else if(document.Form1.rdbBA3.checked==false && document.Form1.rdbG3.checked==false && document.Form1.rdbVG3.checked==false && document.Form1.rdbEX3.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 3!!!");
		  event.returnValue=false;
		 }
		 else if(document.Form1.rdbBA4.checked==false && document.Form1.rdbG4.checked==false && document.Form1.rdbVG4.checked==false && document.Form1.rdbEX4.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 4!!!");
		  event.returnValue=false;
		 }
		 else if(document.Form1.rdbBA5.checked==false && document.Form1.rdbG5.checked==false && document.Form1.rdbVG5.checked==false && document.Form1.rdbEX5.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 5!!!");
		  event.returnValue=false;
		 }
		 else if(document.Form1.rdbBA6.checked==false && document.Form1.rdbG6.checked==false && document.Form1.rdbVG6.checked==false && document.Form1.rdbEX6.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 6!!!");
		  event.returnValue=false;
		 }
		 else if(document.Form1.rdbBA7.checked==false && document.Form1.rdbG7.checked==false && document.Form1.rdbVG7.checked==false && document.Form1.rdbEX7.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 7!!!");
		  event.returnValue=false;
		 }
		 else if(document.Form1.rdbBA8.checked==false && document.Form1.rdbG8.checked==false && document.Form1.rdbVG8.checked==false && document.Form1.rdbEX8.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 8!!!");
		  event.returnValue=false;
		 }
		 else if(document.Form1.rdbBA9.checked==false && document.Form1.rdbG9.checked==false && document.Form1.rdbVG9.checked==false && document.Form1.rdbEX9.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 9!!!");
		  event.returnValue=false;
		 }
		 else if(document.Form1.rdbBA10.checked==false && document.Form1.rdbG10.checked==false && document.Form1.rdbVG10.checked==false && document.Form1.rdbEX10.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 10!!!");
		  event.returnValue=false;
		 }
		  else if(document.Form1.rdbBA11.checked==false && document.Form1.rdbG11.checked==false && document.Form1.rdbVG11.checked==false && document.Form1.rdbEX11.checked==false)
		 {
		  alert("KINDLY SELECT ONE OPTION FROM THE GIVEN FOUR OPTION IN SR NO. 11!!!");
		  event.returnValue=false;
		 }
		 else if(document.Form1.txtSuggestions.value.length > 250)
		 {
		 alert("PLZ ENTER YOUR EXPERIENCE AND SUGGESTIONS WITHIN 250 CHARACTERS ONLY!!!");
		 event.returnValue=false;
		 }
		 else
		 return;
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
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				borderColor="#b0c4de" cellSpacing="1" cellPadding="1" width="100%" bgColor="#f0f8ff"
				border="1">
				<TR>
					<TD style="HEIGHT: 34px" align="center">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="80%" Font-Bold="True">RITES QA DIVISION (GURUGRAM) CLIENT FEEDBACK FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" borderColor="#b0c4de" height="100%" cellSpacing="1" cellPadding="1"
								width="90%" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 13.57%"><asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Name Of Organisation</asp:label></TD>
									<td style="WIDTH: 35%"><asp:textbox id="txtClient" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="90%" Height="20px" MaxLength="100"></asp:textbox></td>
									<td style="WIDTH: 15%"><asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Name of the Official Filling the form</asp:label></td>
									<td style="WIDTH: 35%"><asp:textbox id="txtOffName" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="90%" Height="20px" MaxLength="50"></asp:textbox></td>
								</TR>
								<TR>
									<TD style="WIDTH: 13.57%"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Mobile No.</asp:label><asp:label id="Label21" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
											Width="100%" Font-Bold="True">(10 Digits Mobile No.)</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox id="txtMobile" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="90%" Height="20px" MaxLength="10"></asp:textbox></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label19" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Email</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox id="txtEmail" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="90%" Height="20px" MaxLength="50"></asp:textbox></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 2.2%; HEIGHT: 17px"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Width="296px" Font-Bold="True">Region for which Feedbak to be submitted</asp:label><asp:dropdownlist id="lstRegionCd" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Width="152px" Font-Bold="True" AutoPostBack="True">
							<asp:ListItem></asp:ListItem>
							<asp:ListItem Value="N">NORTHERN REGION</asp:ListItem>
							<asp:ListItem Value="E">EASTERN REGION</asp:ListItem>
							<asp:ListItem Value="W">WESTERN REGION</asp:ListItem>
							<asp:ListItem Value="S">SOUTHERN REGION</asp:ListItem>
							<asp:ListItem Value="C">CENTRAL REGION</asp:ListItem>
							<asp:ListItem Value="Q">CO QA DIVISION</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 553px">
						<P align="center">
							<TABLE id="Table2" borderColor="#b0c4de" height="100%" cellSpacing="1" cellPadding="1"
								width="90%" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana"><asp:label id="Label15" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
											Width="100%" Font-Bold="True">Sr No.</asp:label></TD>
									<TD style="WIDTH: 45%" align="center"><asp:label id="Label16" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
											Width="30%" Font-Bold="True">Description</asp:label></TD>
									<TD style="WIDTH: 50%" align="center"><asp:label id="Label17" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
											Width="30%" Font-Bold="True">Rating</asp:label></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">1.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Response of RITES office in attending to priorities given by the Railways.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G1"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G1"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G1"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G1"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">2.</td>
									<TD style="WIDTH: 45%"><asp:label id="lblFBankCD" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True"> Completion of inspections in time by RITES Inspecting Engineer.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G2"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G2"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G2"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G2"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">3.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Quality of Inspections and Rejection Advices on RITES website for JI Registration.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G3"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G3"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G3"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G3"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">4.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True"> Ease of Registering of Rejection Advices on RITES website for JI Registration.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G4"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G4"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G4"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G4"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">5.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Response of RITES in attending to Joint Inspection requests for Rejection Cases.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G5"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G5"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G5"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G5"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">6.</td>
									<TD style="WIDTH: 45%; HEIGHT: 20px"><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Nature of Technical references sent by RITES and suggestions on improvement of material quality.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G6"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G6"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G6"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX6" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G6"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">7.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True"> Liaison by RITES officials with your office and their responsiveness.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G7"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G7"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G7"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G7"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">8.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label14" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True"> Quality of RITES website and dissemination of information for the clients.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G8"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G8"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G8"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G8"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 38px">9.</td>
									<TD style="WIDTH: 45%; HEIGHT: 38px"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True"> Accessibility of IC issued by RITES on IREPS portal.</asp:label></TD>
									<TD style="WIDTH: 50%; HEIGHT: 38px"><asp:radiobutton id="rdbBA9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G9"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G9"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G9"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G9"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 38px">10.</td>
									<TD style="WIDTH: 45%; HEIGHT: 38px"><asp:label id="Label22" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True"> Responsiveness of the Inspection Engineer to queries raised by your office.</asp:label></TD>
									<TD style="WIDTH: 50%; HEIGHT: 38px"><asp:radiobutton id="rdbBA10" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G10"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG10" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G10"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG10" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G10"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX10" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G10"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">11.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label20" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True"> Overall experience with RITES QA divison.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="25%" Font-Bold="True" Text="Below Average" GroupName="G11"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="16%" Font-Bold="True" Text="Good" GroupName="G11"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Very Good" GroupName="G11"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Font-Bold="True" Text="Excellent" GroupName="G11"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">12.</td>
									<TD style="WIDTH: 95%" colSpan="2"><asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="626px" Font-Bold="True"> Any other Comments/Suggestiong regarding functioning RITES QA system.</asp:label><asp:label id="Label49" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="Red"
											Font-Bold="True">(250 Chars Maxm)</asp:label><asp:textbox id="txtSuggestions" runat="server" Width="95%" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana"
										align="center" colSpan="3"><asp:label id="Label18" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkMagenta"
											Width="100%" Font-Bold="True">* Kindly Enter Your Name Of Organisation , Your Name, Mobile No. and Email-ID  then Select the Region for which you are submitting the Rating/Feedback, then enter Rating/Feedback and Click on Save Button.</asp:label></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
