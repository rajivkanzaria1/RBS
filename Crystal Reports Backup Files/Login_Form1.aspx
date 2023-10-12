<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Form1.aspx.cs" Inherits="RBS.Login_Form1" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inspection Monitoring & Billing System</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" type="text/javascript">
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
		//function changeStyle(){
       // var element = document.getElementById("popup");
       // element.style.display = "none";
       // }
        </script>
		<!--<style type="text/css">
        #overlay
        {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #000;
            filter: alpha(opacity=70);
            -moz-opacity: 0.7;
            -khtml-opacity: 0.7;
            opacity: 0.7;
            z-index: 2000;
            display: none;
        }
        .img a
        {
            text-decoration: none;
        }
        .popup
        {
            width: 70%;
            margin: 0 auto;
            display: none;
            position: fixed;
            z-index: 2001;
        }
        .img
        {
            min-width: 600px;
            width: 600px;
            min-height: 250px;
            height:auto;
            margin: 0px auto;
            background: #f3f3f3;
            position: relative;
            z-index: 2003;
            padding: 1px;
            border-radius: 5px;
            box-shadow: 0 2px 5px #000;
           top:150px;
        }
        .img p
        {
            clear: both;
            color: #555555;
            text-align: justify;
        }
        .img p a
        {
            color: #d91900;
            font-weight: bold;
        }
        .img .x
        {
            float: right;
            height: 30px;
            left: 22px;
            position: relative;
            top: -25px;
            width: 34px;
        }
        .img .x:hover
        {
            cursor: pointer;
        }
    </style>-->

</head>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtUname.focus();">
		<form id="Form1" method="post" runat="server">
		<!--<div class="popup" style="display: block;" id="popup">
                                       <div class="img">
                                       <img src="images/cross.png" alt="quit" class="x" id="x" onclick="changeStyle();">   
                                      <a href="https://harghartiranga.com/" target="_blank"><img src="images/HarGharTiranga.jpg" style="width:100%;"></a> 
          
                                    </div>
                               </div>-->
			<TABLE id="Table1" style="WIDTH: 100%; TOP: 2px; HEIGHT: 100%" borderColor="black" cellSpacing="0"
				cellPadding="0" border="0">
				<TBODY>
					<TR vAlign="middle" height="10%">
						<TD align="center" bgColor="navy"><FONT face="verdana" color="#ffffff"><b>RITES LTD<BR>
									AN ISO 9001 COMPANY</b></FONT>
						</TD>
						<TD style="HEIGHT: 40px"><asp:image id="Image3" runat="server" Width="100%" BackColor="Black" ImageUrl="\RBS\images\logo_rites.jpg"
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
									<TD style="WIDTH: 30%; HEIGHT: 90%" align="center" bgColor="#dcebf9"><font face="verdana" color="background"><strong>
												<P style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: steelblue; FONT-FAMILY: Verdana">RITES 
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
										<TD style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; WIDTH: 100%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 35px"
											align="center" bgColor="#dcebf9" colSpan="2">
											<P>INSPECTION&nbsp; MONITORING&nbsp; &amp; BILLING SYSTEM
											</P>
										</TD>
									</TR>
									<TR>
					             <TD align="center" colSpan="2">
						            <marquee behavior="alternate"><b><A href="https://ritesinsp.com/RBS/Mainpage.aspx"><font style="FONT-WEIGHT: bold; FONT-SIZE: 100%; COLOR: green; FONT-FAMILY: Verdana"><U>Click Here to open ritesinsp.com</U></font></A> </b>
						         </marquee>
					           </TD>
				              </TR>
									<TR height="8%">
										<TD style="FONT-WEIGHT: bold; FONT-SIZE: 11pt; COLOR: steelblue; FONT-FAMILY: Verdana"
											vAlign="middle" align="left"><U>User Login</U></TD>
										<TD style="HEIGHT: 40px" vAlign="middle" align="left"><IMG id="BArrow6" src="\RBS\images\BArrow.gif"><asp:hyperlink id="HyperLink1" runat="server" Height="24px" ForeColor="RoyalBlue" Font-Bold="True"
												Font-Names="Verdana" Font-Size="11pt" NavigateUrl="\IE_Login_Form.aspx">I E Login</asp:hyperlink></TD>
									</TR>
									<TR height="30%">
										<TD style="WIDTH: 50%" vAlign="top" align="left" height="134">
											<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 100%" borderColor="royalblue" cellPadding="0"
												bgColor="#dcebf9" border="1">
												<TBODY>
													<TR height="35%">
														<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; WIDTH: 70px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 35px">User 
															Id:</TD>
														<TD style="HEIGHT: 35px"><asp:textbox id="txtUname" tabIndex="1" runat="server" Width="75%" Height="25px" ForeColor="DarkBlue" Text ="adminnr"
																Font-Names="Verdana" Font-Size="8pt"></asp:textbox></TD>
													</TR>
													<TR height="35%">
														<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; WIDTH: 71px; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 39px">Password:</TD>
														<TD style="HEIGHT: 39px"><asp:textbox id="txtPwd" tabIndex="2" runat="server" Width="75%" Height="25px" ForeColor="DarkBlue" Text="Rites123"
																Font-Names="Verdana" Font-Size="8pt" TextMode="Password"></asp:textbox></TD>
													</TR>
													<TR height="30%">
														<TD align="center"><asp:button id="btnSubmit" tabIndex="3" runat="server" ForeColor="Navy" Font-Bold="True" Font-Names="Tahoma"
																Font-Size="8pt" Text="Submit" onclick="btnSubmit_Click"></asp:button></TD>
														<td align="center"><asp:button id="btnChangePwd" tabIndex="4" runat="server" Width="122px" ForeColor="Navy" Font-Bold="True"
																Font-Names="Tahoma" Font-Size="8pt" Text="Change Password" onclick="btnChangePwd_Click"></asp:button></td>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
										<TD vAlign="top" align="left" width="50%">
											<TABLE id="Table41" style="WIDTH: 99.65%; HEIGHT: 100%" borderColor="royalblue" cellPadding="0"
												bgColor="#dcebf9" border="1">
												<TBODY>
													<tr>
														<td colSpan="2"><IMG id="BArrow5" src="\RBS\images\BArrow.gif"> <A href="/rbs/Acrobat/AdbeRdr80_en_US.zip" target="NewWindow">
																<IMG id="imgad" alt="Get Acrobat Reader" src="\RBS\images\acrobat.gif" border="0"></A><br>
															<FONT style="FONT-WEIGHT: bold; FONT-SIZE: 7pt; LINE-HEIGHT: 6pt; FONT-FAMILY: Verdana; TEXT-ALIGN: center; FONT-FACE: VERDANA"
																color="steelblue" size="4">(Click Here to Download Acrobat Reader) </FONT>
														</td>
													</tr>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
									<TR height="35%" width="70%">
										<TD style="FONT-WEIGHT: bold; FONT-SIZE: 6pt; COLOR: #4169e1; FONT-FAMILY: Verdana; HEIGHT: 100%"
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
										<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: steelblue; FONT-FAMILY: Verdana; TEXT-DECORATION: underline"
											vAlign="top" align="center">
											<hr>
											Bulletin Board
											<hr>
											<br>
											<DIV><TITTLE:CUSTOMDATAGRID id="grdMessage" runat="server" Width="100%" Height="8px" ShowHeader="False" AutoGenerateColumns="False"
													PageSize="15" BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid"
													AddEmptyHeaders="0" BorderWidth="2px" FreezeColumns="0" FreezeHeader="True" GridHeight="120px" GridWidth="100%">
													<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" CssClass="GridAlternate"
														BackColor="#CCCCFF"></AlternatingItemStyle>
													<FooterStyle CssClass="GridHeader"></FooterStyle>
													<ItemStyle Font-Size="8pt" Font-Names="Verdana" ForeColor="DarkBlue" CssClass="GridNormal"></ItemStyle>
													<HeaderStyle CssClass="GridHeader"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="MESSAGE"></asp:BoundColumn>
													</Columns>
												</TITTLE:CUSTOMDATAGRID></DIV>
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
</html>
