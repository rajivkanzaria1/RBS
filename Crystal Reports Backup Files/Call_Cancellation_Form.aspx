<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Cancellation_Form.aspx.cs" Inherits="RBS.Call_Cancellation_Form.Call_Cancellation_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CALL CANCELLATION FORM</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
			if(trimAll(document.Form1.txtCCancelDT.value)=="")
			{
			alert("CALL CANCELLATION DATE CANNOT BE LEFT BLANK!!!");
			event.returnValue=false;
			}
			else if(document.Form1.lstCallCancelStatus.value=="")
			{
			alert("SELECT WHETHER IT IS CHARGEABLE OR NON-CHARGEABLE!!!");
			event.returnValue=false;
			}
			else if((document.Form1.chk1.checked==false && document.Form1.chk2.checked==false) && (document.Form1.chk3.checked==false && document.Form1.chk4.checked==false) && (document.Form1.chk5.checked==false && document.Form1.chk6.checked==false) && (document.Form1.chk7.checked==false && document.Form1.chk8.checked==false) && (document.Form1.chk9.checked==false && document.Form1.chk10.checked==false) && (document.Form1.chk11.checked==false && document.Form1.chk12.checked==false))
			{
			alert("SELECT ATLEAST ONE REASON FOR CALL CANCELLATION!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtCdesc.value.length > 250)
			{
			alert("CANCELLATION DESCRIPTION SHOULD BE MAXIMUM 250 CHARACTERS INCLUDING SPACES !!!");
			event.returnValue=false;
			}
			else
			
			return;
		}
		
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV align="justify">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
					cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD align="center" width="100%" colSpan="4"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="4">
							<P><asp:label id="Label1" runat="server" ForeColor="DarkBlue" Font-Bold="True" BackColor="White"
									Font-Size="10pt" Font-Names="Verdana">CALL CANCELLATION</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 12.63%; HEIGHT: 25px" bgColor="#ffffcc"><asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">Case No : </asp:label></TD>
						<TD style="WIDTH: 35%; HEIGHT: 25px" bgColor="#ffffcc"><asp:label id="txtCaseNo" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">Case No </asp:label></TD>
						<TD style="WIDTH: 35%; HEIGHT: 25px" align="right" bgColor="#ffffcc"><asp:label id="Label4" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">Call Date - Call SNo. </asp:label></TD>
						<TD style="WIDTH: 15%; HEIGHT: 25px" align="left" bgColor="#ffffcc"><asp:label id="txtDtOfReciept" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana"> Date </asp:label>-
							<asp:label id="lblCSNO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">S No.</asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 12.63%; HEIGHT: 25px" bgColor="#ffffcc"><asp:label id="lblPONo" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana" Width="128px">Purchase Order  No.</asp:label></TD>
						<TD style="WIDTH: 35%; HEIGHT: 25px" bgColor="#ffffcc"><asp:label id="lblPONo1" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana"></asp:label></TD>
						<TD style="WIDTH: 35%; HEIGHT: 25px" align="right" bgColor="#ffffcc"><asp:label id="lblPODate" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">Purchase Order Date :</asp:label></TD>
						<TD style="WIDTH: 15%; HEIGHT: 25px" align="left" bgColor="#ffffcc"><asp:label id="lblPODate1" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 12.63%; HEIGHT: 25px" bgColor="#ffffcc"><asp:label id="lblVendor" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana"> Vendor : </asp:label></TD>
						<TD style="WIDTH: 35%; HEIGHT: 25px" bgColor="#ffffcc"><asp:label id="lblVendor1" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana"></asp:label></TD>
						<TD style="WIDTH: 35%; HEIGHT: 25px" align="right" bgColor="#ffffcc"><asp:label id="lblIEng" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">Inspection Engineer :</asp:label></TD>
						<TD style="WIDTH: 15%; HEIGHT: 25px" align="left" bgColor="#ffffcc"><asp:label id="lblIEng1" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana"></asp:label></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="4">
							<TABLE id="Table2" style="HEIGHT: 104px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
								width="85%" bgColor="aliceblue" border="1">
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 35px"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Cancellation Date:</asp:label>&nbsp;
										<asp:textbox id="txtCCancelDT" onblur="check_date(txtCCancelDT);" tabIndex="1" runat="server"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="13%" MaxLength="10" Height="20px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:label id="lblCCancelDT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed"></asp:label>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue">Call is :</asp:label>&nbsp;
										<asp:DropDownList id="lstCallCancelStatus" runat="server" Width="25%" tabIndex="2" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="C">Call Chargeable</asp:ListItem>
											<asp:ListItem Value="N" Selected="True">Call Non-Chargeable</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 35px"><asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Reasons For Cancellation:-</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk1" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="01 - Material Not Found"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk2" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="02 - Call letter recieved after expiry of delivery period"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk3" tabIndex="6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="03 - your call letter was not in prescribed format"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk4" tabIndex="7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="04 - Your refusal to undertake test on samples in approved independent test houses or RITES Lab at your cost (Whichever applicable)"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk5" tabIndex="8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="05 - Material offered at premises where adequate room or lighting etc. not available for proper sampling or inspection."></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk6" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="06 - Internal inspection and test records incomplete / not as per contractual requirement."></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk7" tabIndex="10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="07 - Packing list showing quantities offered item wise and consignee wise not read (Whichever applicable) "></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk8" tabIndex="11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="08 - Lot mixed not segregated. Please re-offer after proper segregation."></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk9" tabIndex="12" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="09 - You could not arrange for inspection in spite of personal contact / phone with your Shri. "></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk10" tabIndex="13" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="10 - You could not produce following documents drg, / spec. / P.O.: at the time of inspection in absence of which inspection could not be done."></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk11" tabIndex="14" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="11 - Call Withdrawn By Vendor"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:checkbox id="chk12" tabIndex="15" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana" Text="12 - Others (Specify)"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:label id="Label7" tabIndex="16" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue">Call Cancellation Document Received or Not (Y/N)</asp:label>&nbsp;
										<asp:DropDownList id="lstDocRec" tabIndex="16" runat="server" Width="80px"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Cancellation Description:-</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%"><asp:textbox id="txtCdesc" tabIndex="17" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Width="90%" TextMode="MultiLine" MaxLength="250" Height="50px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="4">
							<P><asp:button id="btnSave" tabIndex="18" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="19" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Delete" Visible="False" onclick="btnDelete_Click"></asp:button><asp:button id="btnCancel" tabIndex="20" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="4"></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="4"></TD>
					</TR>
				</TABLE>
			</DIV>
		</form>
	</body>
</HTML>
