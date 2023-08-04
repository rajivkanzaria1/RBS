<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendor_Feedback_Form.aspx.cs" Inherits="RBS.Vendor_Feedback_Form.Vendor_Feedback_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Vendor_Feedback_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="../date.js"></script>
		<script language="javascript">
		
		
		function validate()
		{
		 if(document.Form1.rdbBA1.checked==false && document.Form1.rdbG1.checked==false && document.Form1.rdbVG1.checked==false && document.Form1.rdbEX1.checked==false)
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
		 else if(document.Form1.txtSuggestions.value.length > 250)
		 {
		 alert("PLZ ENTER YOUR EXPERIENCE AND SUGGESTIONS WITHIN 250 CHARACTERS ONLY!!!");
		 event.returnValue=false;
		 }
		 else if(document.Form1.lstRegionCd.value=="")
		 {
		 alert("REGION CANNOT BE BLANK!!!");
		 event.returnValue=false;
		 }
		 else
		 return;
		}
		
		function vend_validate()
		{
			 
		 if(document.Form1.txtVendCd.value=="")
		 {
		 alert("VENDOR CODE CANNOT BE BLANK!!!");
		 event.returnValue=false;
		 }
		
		 else
		 return;
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
						<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="80%" BackColor="White" ForeColor="DarkBlue"
								Font-Size="10pt" Font-Names="Verdana">RITES QA DIVISION (GURUGRAM) VENDOR/SUPPLIER FEEDBACK FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 1.29%"><asp:label id="Label12" runat="server" Font-Bold="True" Width="208px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana">Vendor Code Alloted by RITES:</asp:label><asp:textbox id="txtVendCd" tabIndex="1" runat="server" Width="119px" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" MaxLength="30" Height="20px"></asp:textbox><asp:button id="btnVendDetails" tabIndex="2" runat="server" Font-Bold="True" BackColor="#C0C0FF"
							ForeColor="DarkBlue" Text="Submit" onclick="btnVendDetails_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 29px"><asp:label id="Label13" runat="server" Font-Bold="True" Width="168px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana">Vendor Name & Address:</asp:label><asp:label id="lblVendDetails" runat="server" Font-Bold="True" Width="80%" ForeColor="OrangeRed"
							Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 2.2%; HEIGHT: 17px"><asp:label id="Label5" runat="server" Font-Bold="True" Width="296px" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana">Region for which Feedbak to be submitted</asp:label><asp:dropdownlist id="lstRegionCd" tabIndex="3" runat="server" Font-Bold="True" Width="152px" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" AutoPostBack="True">
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
					<TD>
						<P align="center">
							<TABLE id="Table2" borderColor="#b0c4de" height="100%" cellSpacing="1" cellPadding="1"
								width="90%" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana"><asp:label id="Label15" runat="server" Font-Bold="True" Width="100%" ForeColor="OrangeRed"
											Font-Size="8pt" Font-Names="Verdana">Sr No.</asp:label></TD>
									<TD style="WIDTH: 45%" align="center"><asp:label id="Label16" runat="server" Font-Bold="True" Width="30%" ForeColor="OrangeRed" Font-Size="8pt"
											Font-Names="Verdana">Description</asp:label></TD>
									<TD style="WIDTH: 50%" align="center"><asp:label id="Label17" runat="server" Font-Bold="True" Width="30%" ForeColor="OrangeRed" Font-Size="8pt"
											Font-Names="Verdana">Rating</asp:label></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">1.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Promptness of RITES Regional Office in attending to P.O. & Call Registration.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Below Average" GroupName="G1" Width="25%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Good" GroupName="G1" Width="16%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Very Good" GroupName="G1" Width="20%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Excellent" GroupName="G1" Width="20%"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">2.</td>
									<TD style="WIDTH: 45%"><asp:label id="lblFBankCD" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana">Response of Call Desk in attending to Telephonic enquiries.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Below Average" GroupName="G2" Width="25%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Good" GroupName="G2" Width="16%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Very Good" GroupName="G2" Width="20%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Excellent" GroupName="G2" Width="20%"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">3.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Response of Inspecting Engineer for conducting inspection, timely attention and provision of advance intimation.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Below Average" GroupName="G3" Width="25%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Good" GroupName="G3" Width="16%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Very Good" GroupName="G3" Width="20%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Excellent" GroupName="G3" Width="20%"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">4.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label6" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Behaviour of Inspecting Engineer with firm's representative during inspection and promptness in issue of inspection certificate.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Below Average" GroupName="G4" Width="25%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Good" GroupName="G4" Width="16%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Very Good" GroupName="G4" Width="20%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Excellent" GroupName="G4" Width="20%"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">5.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label7" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Response of Controlling Managers to Firm's queries.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Below Average" GroupName="G5" Width="25%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Good" GroupName="G5" Width="16%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Very Good" GroupName="G5" Width="20%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Excellent" GroupName="G5" Width="20%"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">6.</td>
									<TD style="WIDTH: 45%; HEIGHT: 20px"><asp:label id="Label8" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">RITES Lab response time.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Below Average" GroupName="G6" Width="25%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Good" GroupName="G6" Width="16%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Very Good" GroupName="G6" Width="20%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Excellent" GroupName="G6" Width="20%"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">7.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label10" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Quality of Information available on RITES QA Division website ritesinsp.com.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA7" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Below Average" GroupName="G7" Width="25%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG7" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Good" GroupName="G7" Width="16%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG7" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Very Good" GroupName="G7" Width="20%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX7" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Excellent" GroupName="G7" Width="20%"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">8.</td>
									<TD style="WIDTH: 45%"><asp:label id="Label14" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Promptness of RITES Finance Department in correction with Invoices/Bills/Receipts etc.</asp:label></TD>
									<TD style="WIDTH: 50%"><asp:radiobutton id="rdbBA8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Below Average" GroupName="G8" Width="25%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbG8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Good" GroupName="G8" Width="16%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbVG8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Very Good" GroupName="G8" Width="20%"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="rdbEX8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="Excellent" GroupName="G8" Width="20%"></asp:radiobutton></TD>
								</TR>
								<TR>
									<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">9.</td>
									<TD style="WIDTH: 95%" colSpan="2"><asp:label id="Label11" runat="server" Font-Bold="True" Width="668px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana">Your overall experience with RITES QA Division, will you recommend others for RITES inspection.</asp:label><asp:label id="Label49" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="8pt" Font-Names="Verdana">(250 Chars Maxm)</asp:label><asp:textbox id="txtOverExp" runat="server" Width="95%" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana">10.</TD>
									<TD style="WIDTH: 95%" colSpan="2">
										<asp:label id="Label2" runat="server" Font-Bold="True" Width="313px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"> Suggestions for improvement in service.</asp:label>
										<asp:label id="Label19" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="Red"
											Font-Bold="True">(250 Chars Maxm)</asp:label>
										<asp:textbox id="txtSuggestion" runat="server" Width="95%" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 0.12%; COLOR: darkblue; FONT-FAMILY: Verdana"
										align="center" colSpan="3">
										<asp:label id="Label18" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkMagenta"
											Width="100%" Font-Bold="True">* Kindly Enter your Vendor Code issued by RITES LTD and Click on  Submit Button, then Select the Region for which you are submitting the Rating/Feedback, then enter Rating/Feedback and Click on Save Button.</asp:label></TD>
								</TR>
							</TABLE>
							<asp:label id="lblVend_Email" runat="server" Font-Bold="True" Width="168px" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Visible="False">Vendor Name & Address: </asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" tabIndex="3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:HyperLink id="HyperLink1" runat="server" DESIGNTIMEDRAGDROP="135" NavigateUrl="/rbs/Vendor/Vendor_Login_Form.aspx">If you want to Skip or Already Entered then Click Here for Vendor Login Form!!!</asp:HyperLink></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>