<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="R_Login_Form.aspx.cs" Inherits="RBS.R_Login_Form.R_Login_Form" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Inspection Monitoring & Billing System</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{		
			if(document.Form1.txtUname.value=="")
			{
				alert("USER NAME CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.txtPwd.value=="")		
			{
				alert("PASSWORD CANNOT BE BLANK");
				event.returnValue=false;
			}
			return;
		}
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtUname.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 100%; TOP: 8px; HEIGHT: 100%" borderColor="black" cellSpacing="0"
				cellPadding="0" border="0">
				<TBODY>
					<TR vAlign="middle" height="10%">
						<TD align="center" bgColor="navy"><FONT face="verdana" color="#ffffff"><b>RITES LTD<BR>
									AN ISO 9001 COMPANY</b></FONT>
						</TD>
						<TD style="HEIGHT: 40px"><asp:image id="Image3" runat="server" Width="100%" BackColor="Black" ImageUrl="\RBS\images\logo_rites1.GIF"
								ImageAlign="AbsMiddle" Height="100%"></asp:image></TD>
					</TR>
					<TR height="80%">
						<TD style="WIDTH: 18%; HEIGHT: 72%">
							<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
								border="0">
								<TR>
									<TD style="WIDTH: 30%; HEIGHT: 90%"><IMG id="Image1" style="WIDTH: 220px; HEIGHT: 100.27%" height="328" alt="" src="\RBS\images\MVC-006S.JPG"
											width="216" align="top" border="0">
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 30%; HEIGHT: 90%" align="center" bgColor="#dcebf9">
										<P align="center"><FONT style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: steelblue; FONT-FAMILY: Monospace"
												face="Verdana" color="white">RITES Regd. Office </FONT>
											<br>
											<FONT style="FONT-WEIGHT: bold; FONT-SIZE: 9pt; COLOR: steelblue; FONT-FAMILY: Monospace"
												face="Verdana" color="white">SCOPE Minar, Laxmi Nagar<br>
												Delhi - 110 092 (INDIA)</FONT>
										</P>
										</FONT></TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 71.54%" width="70%">
							<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 50%" borderColor="navy" cellSpacing="0"
								cellPadding="0" width="490" border="1">
								<TBODY>
									<TR>
										<TD style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; WIDTH: 100%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 35px"
											align="center" bgColor="#dcebf9" colSpan="2">
											<P>INSPECTION&nbsp; MONITORING&nbsp; &amp; BILLING SYSTEM
											</P>
										</TD>
									</TR>
									<TR>
										<TD style="FONT-WEIGHT: bold; FONT-SIZE: 11pt; COLOR: steelblue; FONT-FAMILY: Verdana; HEIGHT: 40px"
											vAlign="middle" align="left"><U>User Login</U></TD>
										<TD style="HEIGHT: 40px" vAlign="middle" align="left"><IMG id="BArrow6" src="\RBS\images\BArrow.gif"><asp:hyperlink id="HyperLink1" runat="server" Height="26px" ForeColor="RoyalBlue" Font-Bold="True"
												Font-Names="Verdana" Font-Size="11pt" NavigateUrl="\RBS\IE_Login_Form.aspx">I E Login</asp:hyperlink></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 52.54%" vAlign="top" align="left" colSpan="1" rowSpan="1">
											<TABLE id="Table4" style="WIDTH: 99.65%; HEIGHT: 100%" borderColor="royalblue" cellPadding="0"
												bgColor="#dcebf9" border="1">
												<TBODY>
													<TR height="35%">
														<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; WIDTH: 70px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 29px">User 
															Id:</TD>
														<TD style="HEIGHT: 29px"><asp:textbox id="txtUname" tabIndex="1" runat="server" Width="75%" Height="25px" ForeColor="DarkBlue"
																Font-Names="Verdana" Font-Size="8pt"></asp:textbox></TD>
													</TR>
													<TR height="35%">
														<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; WIDTH: 71px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 39px">Password:</TD>
														<TD style="HEIGHT: 39px"><asp:textbox id="txtPwd" tabIndex="2" runat="server" Width="75%" Height="25px" ForeColor="DarkBlue"
																Font-Names="Verdana" Font-Size="8pt" TextMode="Password"></asp:textbox></TD>
													</TR>
													<TR height="30%">
														<TD vAlign="top" align="center"><asp:button id="btnSubmit" tabIndex="3" runat="server" ForeColor="Navy" Font-Bold="True" Font-Names="Tahoma"
																Font-Size="8pt" Text="Submit"></asp:button></TD>
														<TD vAlign="top" align="center"><asp:button id="btnChangePwd" tabIndex="4" runat="server" Width="122px" ForeColor="Navy" Font-Bold="True"
																Font-Names="Tahoma" Font-Size="8pt" Text="Change Password"></asp:button></TD>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
										<TD vAlign="top" align="left">
											<TABLE id="Table41" style="WIDTH: 99.65%; HEIGHT: 100%" borderColor="royalblue" cellPadding="0"
												bgColor="#dcebf9" border="1">
												<TBODY>
													<TR height="10%">
														<td colSpan="2">
															<p style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: steelblue; FONT-FAMILY: Verdana; TEXT-DECORATION: underline">Inspection 
																Details</p>
														</td>
													</TR>
													<TR height="10%">
														<td><IMG id="BArrow1" src="\RBS\images\BArrow.gif">
															<asp:hyperlink id="HyperLink3" runat="server" Height="20px" ForeColor="RoyalBlue" Font-Bold="True"
																Font-Names="Verdana" Font-Size="7pt" NavigateUrl="\RBS\IE_Login_Form.aspx">Northern Region</asp:hyperlink>&nbsp;&nbsp;
														</td>
														<td><IMG id="BArrow2" src="\RBS\images\BArrow.gif"><asp:hyperlink id="HyperLink4" runat="server" Height="20px" ForeColor="RoyalBlue" Font-Bold="True"
																Font-Names="Verdana" Font-Size="7pt" NavigateUrl="\RBS\IE_Login_Form.aspx">Southern Region</asp:hyperlink></td>
													<TR>
														<TD><IMG id="BArrow3" src="\RBS\images\BArrow.gif">
															<asp:hyperlink id="HyperLink5" runat="server" Height="20px" ForeColor="RoyalBlue" Font-Bold="True"
																Font-Names="Verdana" Font-Size="7pt" NavigateUrl="\RBS\IE_Login_Form.aspx">Eastern Region</asp:hyperlink></TD>
														<TD><IMG id="BArrow4" src="\RBS\images\BArrow.gif"><asp:hyperlink id="HyperLink6" runat="server" Height="20px" ForeColor="RoyalBlue" Font-Bold="True"
																Font-Names="Verdana" Font-Size="7pt" NavigateUrl="\RBS\IE_Login_Form.aspx">Western Region</asp:hyperlink></TD>
													</TR>
													<tr>
														<td colSpan="2"><IMG id="BArrow5" style="WIDTH: 20px; HEIGHT: 20px" height="20" src="\RBS\images\BArrow.gif"
																width="20"> <a href="http://www.adobe.co.uk/products/acrobat/readstep2.html" target="NewWindow">
																<IMG id="imgad" alt="Get Acrobat Reader" src="\RBS\images\acrobat.gif" border="0"></a><br>
															<FONT style="FONT-WEIGHT: bold; FONT-SIZE: 7pt; LINE-HEIGHT: 6pt; FONT-FAMILY: Verdana; TEXT-ALIGN: center; FONT-FACE: VERDANA"
																color="steelblue" size="4">(Click Here to Download Acrobat Reader)</FONT></td>
													</tr>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<MARQUEE dataFormatAs="html" style="FONT-SIZE: 10pt; WIDTH: 100%; FONT-FAMILY: a, Arial; HEIGHT: 100%"
								scrollDelay="125" behavior="alternate" width="100%">
								<IMG height="50%" alt="" src="\RBS\images\insp1.JPG" width="33%"><IMG height="50%" alt="" src="\RBS\images\insp4.JPG" width="33%">
								<IMG height="50%" alt="" src="\RBS\images\insp2.GIF" width="33%"> <IMG height="50%" alt="" src="\RBS\images\insp5.JPG" width="33%">
								<IMG height="50%" alt="" src="\RBS\images\insp3.JPG" width="33%"> <IMG height="50%" alt="" src="\RBS\images\insp6.JPEG" width="33%">
							</MARQUEE>
						</TD>
					</TR>
					<TR vAlign="middle" height="10%">
						<TD width="100%" bgColor="steelblue" colSpan="2">
							<P align="center"><FONT style="FONT-WEIGHT: bold; BACKGROUND-COLOR: steelblue" face="snapix" color="white"
									size="5"><STRONG>Designed &amp;Developed by : IT Division RITES LTD. GURGAON</STRONG></FONT></P>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
