<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_Login_Form.aspx.cs" Inherits="RBS.New_Login_Form.New_Login_Form" %>


<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
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
			<TABLE id="Table1" style="WIDTH: 100%; HEIGHT: 100%; TOP: 2px" borderColor="black" cellSpacing="0"
				cellPadding="0" border="0">
				<TBODY>
					<TR vAlign="middle" height="10%">
						<TD align="center" bgColor="navy"><FONT face="verdana" color="#ffffff"><b>RITES LTD<BR>
									AN ISO 9001 COMPANY</b></FONT>
						</TD>
						<TD style="HEIGHT: 40px"><asp:image id="Image3" runat="server" Height="100%" ImageAlign="AbsMiddle" ImageUrl="\RBS\images\logo_rites.jpg"
								BackColor="Black" Width="100%"></asp:image></TD>
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
									<TD style="WIDTH: 30%; HEIGHT: 90%" align="center" bgColor="#dcebf9"><font face="verdana" color="background"><strong>
												<P style="FONT-FAMILY: Verdana; COLOR: steelblue; FONT-SIZE: 10pt; FONT-WEIGHT: bold">RITES 
													Regd. Office :
													<br>
													SCOPE Minar, Laxmi Nagar<br>
													Delhi - 110 092 (INDIA)
												</P>
											</strong></font>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 100%" width="70%">
							<TABLE id="Table3" style="WIDTH: 100%" borderColor="navy" height="100%" cellSpacing="0"
								cellPadding="0" border="1">
								<TBODY>
									<TR height="10%">
										<TD style="WIDTH: 100%; FONT-FAMILY: Verdana; HEIGHT: 35px; COLOR: navy; FONT-SIZE: 12pt; FONT-WEIGHT: bold"
											align="center" bgColor="#dcebf9" colSpan="2">
											<P>INSPECTION&nbsp; MONITORING&nbsp; &amp; BILLING SYSTEM
											</P>
										</TD>
									</TR>
									<TR height="8%">
										<TD style="FONT-FAMILY: Verdana; COLOR: steelblue; FONT-SIZE: 11pt; FONT-WEIGHT: bold"
											vAlign="middle" align="left"><U>User Login</U></TD>
										<TD style="HEIGHT: 40px" vAlign="middle" align="left"><IMG id="BArrow6" src="\RBS\images\BArrow.gif"><asp:hyperlink id="HyperLink1" runat="server" Height="24px" NavigateUrl="\RBS\IE_Login_Form.aspx"
												Font-Size="11pt" Font-Names="Verdana" Font-Bold="True" ForeColor="RoyalBlue">I E Login</asp:hyperlink></TD>
									</TR>
									<TR height="30%">
										<TD style="WIDTH: 50%" vAlign="top" align="left" height="134">
											<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 100%" borderColor="royalblue" cellPadding="0"
												bgColor="#dcebf9" border="1">
												<TBODY>
													<TR height="35%">
														<TD style="WIDTH: 70px; FONT-FAMILY: Verdana; HEIGHT: 35px; COLOR: navy; FONT-SIZE: 10pt; FONT-WEIGHT: bold">User 
															Id:</TD>
														<TD style="HEIGHT: 35px"><asp:textbox id="txtUname" tabIndex="1" runat="server" Height="25px" Width="75%" Font-Size="8pt"
																Font-Names="Verdana" ForeColor="DarkBlue"></asp:textbox></TD>
													</TR>
													<TR height="35%">
														<TD style="WIDTH: 71px; FONT-FAMILY: Verdana; HEIGHT: 39px; COLOR: navy; FONT-SIZE: 10pt; FONT-WEIGHT: bold">Password:</TD>
														<TD style="HEIGHT: 39px"><asp:textbox id="txtPwd" tabIndex="2" runat="server" Height="25px" Width="75%" Font-Size="8pt"
																Font-Names="Verdana" ForeColor="DarkBlue" TextMode="Password"></asp:textbox></TD>
													</TR>
													<TR height="30%">
														<TD align="center"><asp:button id="btnSubmit" tabIndex="3" runat="server" Font-Size="8pt" Font-Names="Tahoma" Font-Bold="True"
																ForeColor="Navy" Text="Submit"></asp:button></TD>
														<td align="center"><asp:button id="btnChangePwd" tabIndex="4" runat="server" Width="122px" Font-Size="8pt" Font-Names="Tahoma"
																Font-Bold="True" ForeColor="Navy" Text="Change Password"></asp:button></td>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
										<TD vAlign="top" align="left" width="50%">
											<TABLE id="Table41" style="WIDTH: 99.65%; HEIGHT: 100%" borderColor="royalblue" cellPadding="0"
												bgColor="#dcebf9" border="1">
												<TBODY>
													<TR height="10%">
														<td colSpan="2">
															<p style="FONT-FAMILY: Verdana; COLOR: navy; FONT-SIZE: 10pt; FONT-WEIGHT: bold; TEXT-DECORATION: underline">Inspection 
																Status</p>
														</td>
													</TR>
													<TR>
														<td><IMG id="BArrow1" src="\RBS\images\BArrow.gif">
															<asp:hyperlink id="HyperLinkNR" runat="server" Height="20px" Font-Size="7pt" Font-Names="Verdana"
																Font-Bold="True" ForeColor="RoyalBlue" NavigateUrl="http://www.rites.com/web/images/stories/ic.xls">Northern Region</asp:hyperlink>&nbsp;&nbsp;
														</td>
														<td><IMG id="BArrow2" src="\RBS\images\BArrow.gif">
															<asp:hyperlink id="HyperLinkSR" runat="server" Height="20px" NavigateUrl="\RBS\Calls_Marked.aspx"
																Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" ForeColor="RoyalBlue">Southern Region</asp:hyperlink></td>
													<TR>
														<TD><IMG id="BArrow3" src="\RBS\images\BArrow.gif">
															<asp:hyperlink id="HyperLinkER" runat="server" Height="20px" NavigateUrl="\RBS\Calls_Marked.aspx"
																Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" ForeColor="RoyalBlue">Eastern Region</asp:hyperlink></TD>
														<TD><IMG id="BArrow4" src="\RBS\images\BArrow.gif">
															<asp:hyperlink id="HyperLinkWR" runat="server" Height="20px" NavigateUrl="\RBS\Calls_Marked.aspx"
																Font-Size="7pt" Font-Names="Verdana" Font-Bold="True" ForeColor="RoyalBlue">Western Region</asp:hyperlink></TD>
													</TR>
													<tr>
														<td colSpan="2"><IMG id="BArrow5" src="\RBS\images\BArrow.gif"> <a href="/rbs/Acrobat/AdbeRdr80_en_US.zip" target="NewWindow">
																<IMG id="imgad" alt="Get Acrobat Reader" src="\RBS\images\acrobat.gif" border="0"></a><br>
															<FONT style="TEXT-ALIGN: center; LINE-HEIGHT: 6pt; FONT-FAMILY: Verdana; FONT-SIZE: 7pt; FONT-WEIGHT: bold; FONT-FACE: VERDANA"
																color="steelblue" size="4">(Click Here to Download Acrobat Reader) </FONT>
														</td>
													</tr>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
									<TR height="35%" width="70%">
										<TD style="FONT-FAMILY: Verdana; HEIGHT: 100%; COLOR: #4169e1; FONT-SIZE: 6pt; FONT-WEIGHT: bold"
											vAlign="top" align="left">
											<P align="justify"><b>QA Division is engaged in Quality surveillance and third Party 
													Inspection of various types of equipment and materials since 1975. Since then, 
													QA Division has registered steady growth and now provides single window 
													integrated solutions and services in the field of inspection and Management 
													Systems. A team of over 200 dedicated engineers spread over a network of 30 
													regional and sub-regional offices render prompt and satisfactory service to 
													clients. In-house laboratories with state-of-the-art facilities provide vital 
													technical support. </b>
											</P>
										</TD>
										<TD style="FONT-FAMILY: Verdana; COLOR: steelblue; FONT-SIZE: 8pt; FONT-WEIGHT: bold; TEXT-DECORATION: underline"
											vAlign="top" align="center"><hr>
											Bulletin Board<hr>
											<br>
											<DIV><TITTLE:CUSTOMDATAGRID id="grdMessage" runat="server" Width="100%" GridWidth="100%" GridHeight="120px"
													FreezeHeader="True" FreezeColumns="0" BorderWidth="2px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
													CellPadding="2" FreezeRows="0" BorderColor="DarkBlue" PageSize="15" AutoGenerateColumns="False" ShowHeader="False"
													Height="8px">
													<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" CssClass="GridAlternate"
														BackColor="#CCCCFF"></AlternatingItemStyle>
													<FooterStyle CssClass="GridHeader"></FooterStyle>
													<ItemStyle Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" CssClass="GridNormal"></ItemStyle>
													<HeaderStyle CssClass="GridHeader"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="MESSAGE"></asp:BoundColumn>
													</Columns>
												</TITTLE:CUSTOMDATAGRID>
											</DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					<TR vAlign="middle" height="10%">
						<TD width="100%" bgColor="steelblue" colSpan="2">
							<P align="center"><FONT style="BACKGROUND-COLOR: steelblue" face="Tahoma" color="white" size="2"><STRONG>Designed 
										&amp; Developed by: IT Division, RITES LTD., RITES BHAWAN, PLOT NO.1, 
										SECTOR-29, GURGAON-122001</STRONG></FONT></P>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
