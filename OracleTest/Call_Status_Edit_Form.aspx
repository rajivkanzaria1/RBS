<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Status_Edit_Form.aspx.cs" Inherits="RBS.Call_Status_Edit_Form.Call_Status_Edit_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Call_Status_Edit_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
			if(document.Form1.lstCallStatus.value=="C" && document.Form1.lstCallCancelStatus=="[object]"  && trimAll(document.Form1.lstCallCancelStatus.value)=="")
			{
				alert("IN CASE OF CALL CANCELLATION, SELECT WHETHER IT IS CHARGEABLE OR NON-CHARGEABLE!!!");
				event.returnValue=false;
			}
			else if(document.Form1.lstCallStatus.value=="C" && document.Form1.lstCallCancelStatus=="[object]"  && document.Form1.lstCallCancelStatus.value=="C" && document.Form1.lstCallCancelCharges=="[object]" &&  trimAll(document.Form1.lstCallCancelCharges.SelectedValue.value)=="")
			{
				alert("IN CASE OF CALL IS CHARGEABLE, SELECT CANCELLATION AMOUNT!!!");
				event.returnValue=false;
			}
			else if(document.Form1.lstCallStatus.value=="A" && (document.Form1.txtSetNo.value=="" || document.Form1.txtBKNO.value==""))
			{
				alert("ENTER BOTH THE FIELDS BK NO. & SET NO. !!!");
				event.returnValue=false;
			}
			else if(document.Form1.lstCallStatus.value=="R" && (document.Form1.txtSetNo.value=="" || document.Form1.txtBKNO.value=="" || trimAll(document.Form1.txtRemarks.value)==""))
			{
				alert("REMARKS, BK NO. & SET NO. CANNOT BE LEFT BLANK!!!");
				event.returnValue=false;
			}
			else if(document.Form1.txtRemarks=="[object]" && document.Form1.txtRemarks.value.length > 400)
			{
				alert("REMARKS SHOULD BE MAXIMUM OF 400 CHARACTERS INCLUDING SPACES!!!");
				event.returnValue=false;
			}
			else
			
			return;
		}
		function validate1()
		{
		if((document.Form1.chk1.checked==false && document.Form1.chk2.checked==false) && (document.Form1.chk3.checked==false && document.Form1.chk4.checked==false) && (document.Form1.chk5.checked==false && document.Form1.chk6.checked==false) && (document.Form1.chk7.checked==false && document.Form1.chk8.checked==false) && (document.Form1.chk9.checked==false && document.Form1.chk10.checked==false) && (document.Form1.chk11.checked==false && document.Form1.chk12.checked==false))
			{
			alert("SELECT ATLEAST ONE REASON FOR CALL CANCELLATION!!!");
			event.returnValue=false;
			}
		else if(document.Form1.chk12.checked==true && trimAll(document.Form1.txtCdesc.value)=="")
			{
			alert("CANCELLATION DESCRIPTION IS MANDATORY IN CASE OF OTHERS!!!");
			event.returnValue=false;
			}
		else if(document.Form1.txtCdesc=="[object]" && document.Form1.txtCdesc.value.length > 250)
			{
			alert("CANCELLATION DESCRIPTION SHOULD BE MAXIMUM 250 CHARACTERS INCLUDING SPACES!!!");
			event.returnValue=false;
			}
		}
		function call_cancel_status()
		 {
		
			if(document.Form1.lstCallStatus.value=="C")
			{
				document.Form1.lstCallCancelStatus.style.visibility = 'visible';
				document.Form1.lstCallCancelCharges.style.visibility = 'visible';
				document.Form1.lstCallCancelStatus.focus();
				document.Form1.lstCallCancelStatus.SelectedValue="C";
				document.Form1.lstCallCancelCharges.SelectedValue="";
				document.Form1.txtBKNO.style.visibility = 'hidden';
				document.Form1.txtSetNo.style.visibility = 'hidden';
				document.Form1.txtbksetno.style.visibility = 'hidden';
				document.Form1.btnSave.style.visibility = 'hidden';
				
				
			}
			else if(document.Form1.lstCallStatus.value=="A" || document.Form1.lstCallStatus.value=="R")
			{
				//document.Form1.txtBKNO.style.visibility = 'visible';
				//document.Form1.txtSetNo.style.visibility = 'visible';
				document.Form1.txtBKNO.style.visibility = 'hidden';
				document.Form1.txtSetNo.style.visibility = 'hidden';
				document.Form1.txtbksetno.style.visibility = 'hidden';
				document.Form1.btnSave.style.visibility = 'visible';
				document.Form1.lstCallCancelStatus.SelectedValue="";
				document.Form1.lstCallCancelStatus.style.visibility = 'hidden';
				document.Form1.lstCallCancelStatus.SelectedValue="";
				document.Form1.lstCallCancelCharges.style.visibility = 'hidden';
				
				
				
			}
			else if(document.Form1.lstCallStatus.value=="G" || document.Form1.lstCallStatus.value=="T")
			{
				//document.Form1.txtBKNO.style.visibility = 'visible';
				//document.Form1.txtSetNo.style.visibility = 'visible';
				document.Form1.txtBKNO.style.visibility = 'visible';
				document.Form1.txtSetNo.style.visibility = 'visible';
				document.Form1.txtbksetno.style.visibility = 'visible';
				document.Form1.btnSave.style.visibility = 'visible';
				document.Form1.lstCallCancelStatus.SelectedValue="";
				document.Form1.lstCallCancelStatus.style.visibility = 'hidden';
				document.Form1.lstCallCancelStatus.SelectedValue="";
				document.Form1.lstCallCancelCharges.style.visibility = 'hidden';
			}
				
				
				
		//	else if(document.Form1.lstCallStatus.value=="B")
		//	{
		//		document.Form1.lstCallCancelStatusSelectedValue="";
		//		document.Form1.lstCallCancelStatus.style.visibility = 'hidden';
		//		document.Form1.txtBKNO.style.visibility = 'hidden';
		//		document.Form1.txtSetNo.style.visibility = 'hidden';
		//		document.Form1.txtbksetno.style.visibility = 'hidden';
		//		document.Form1.btnSave.style.visibility = 'hidden';
				
				
				
		//	}
			else
			{
				document.Form1.lstCallCancelStatusSelectedValue="";
				document.Form1.lstCallCancelStatus.style.visibility = 'hidden';
				document.Form1.txtBKNO.style.visibility = 'hidden';
				document.Form1.txtSetNo.style.visibility = 'hidden';
				document.Form1.txtbksetno.style.visibility = 'hidden';
				document.Form1.btnSave.style.visibility = 'visible';
				document.Form1.lstCallCancelCharges.style.visibility = 'hidden';
				
				
			}
		 }
		function makeUppercase()
		 {
			document.Form1.txtBKNO.value = document.Form1.txtBKNO.value.toUpperCase();
		 }
		 
		function change()
		{
			var d=document.Form1.txtSetNo.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="00" + d;
				document.Form1.txtSetNo.value=d;
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="0" + d;
				document.Form1.txtSetNo.value=d;
				event.returnValue=false;
			}
			return false;	
		}
        </script>
	</HEAD>
	<body onload="call_cancel_status();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 45px" align="center">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<tr>
					<td align="center"><asp:label id="Label1" runat="server" Width="177px" BackColor="White" Font-Names="Verdana"
							Font-Size="10pt" ForeColor="DarkBlue" Font-Bold="True">CALL STATUS EDIT FORM</asp:label></td>
				</tr>
				<TR>
					<TD align="center">
						<TABLE id="Table4" borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="97%" bgColor="#f0f8ff"
							border="1">
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Vendor</td>
								<td style="WIDTH: 70%; HEIGHT: 9px"><asp:label id="lblVend" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Purchaser</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblPurc" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Item</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblItem" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px">Call 
									Date</TD>
								<TD style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px"><asp:label id="lblCallDT" runat="server" Width="120px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b></b></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px"><B>Inpection 
										Desire Date</B></TD>
								<TD style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px"><asp:label id="lblInpDesireDT" runat="server" Width="120px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Engineer 
									Name</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblIEName1" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Engineer 
									Contact No.</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblIECON" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">PO 
									No.</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblPONO" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">PO 
									Date</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblPODT" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Case 
									No.</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblCSNO" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Call 
									Letter Date</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblCLettDT" runat="server" Width="112px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Call 
									Letter No.</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblCLettNo" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 23px">Contact 
									Person</TD>
								<TD style="WIDTH: 70%; HEIGHT: 23px"><asp:label id="lblCONPER" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Contact 
									Person Tel No.</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblCONPERTEL" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Call 
									Serial No</TD>
								<TD style="WIDTH: 70%"><asp:label id="lblSNO" runat="server" Width="128px" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"
									align="center" colSpan="2"><asp:hyperlink id="HyperLink1" runat="server">IC Photo Upload</asp:hyperlink><asp:hyperlink id="HyperLink2AR" runat="server">IC Photo Upload Only for Accepted and Rejected!</asp:hyperlink><asp:label id="Label3" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True">Upload the Photos first in case of Accepted or Rejection, before changing the Call Status.</asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Case 
									Status</TD>
								<TD style="WIDTH: 70%"><asp:dropdownlist id="lstCallStatus" tabIndex="1" runat="server" Width="30%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" AutoPostBack="True" onselectedindexchanged="lstCallStatus_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="lstCallCancelStatus" tabIndex="2" runat="server" Width="150px" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" AutoPostBack="True" Height="16px" onselectedindexchanged="lstCallCancelStatus_SelectedIndexChanged">
										<asp:ListItem Selected="True"></asp:ListItem>
										<asp:ListItem Value="C">Call Chargeable</asp:ListItem>
										<asp:ListItem Value="N">Call Non-Chargeable</asp:ListItem>
									</asp:dropdownlist><asp:dropdownlist id="lstCallCancelCharges" tabIndex="2" runat="server" Width="88%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" AutoPostBack="True" onselectedindexchanged="lstCallCancelCharges_SelectedIndexChanged">
										<asp:ListItem Selected="True"></asp:ListItem>
									</asp:dropdownlist><asp:label id="lblCallStatus" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True" Visible="False"></asp:label><asp:textbox id="txtbksetno" runat="server" Width="14%" BackColor="AliceBlue" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Font-Bold="True" BorderStyle="None">BK &amp; Set No.</asp:textbox><asp:textbox id="txtBKNO" onblur="makeUppercase();" tabIndex="3" runat="server" Width="48px"
										Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="4"></asp:textbox><asp:textbox id="txtSetNo" onblur="change();" tabIndex="4" runat="server" Width="48px" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="3"></asp:textbox></TD>
							</TR>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 27px"
									colSpan="2"><asp:hyperlink id="HprInspecttestPlan" runat="server">Inspection & Test Plan</asp:hyperlink></td>
							</tr>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 27px">
									<asp:label id="lblFIFO" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="100%" Height="20px" Visible="False">Reason For Voilating FIFO <Font Color="red">
											* (Max 400 Chars)</Font></asp:label></TD>
								<TD style="WIDTH: 100%; HEIGHT: 27px">
									<asp:textbox id="txtFIFO" tabIndex="11" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Width="100%" Height="50px" Visible="False" MaxLength="400" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 27px">
									<P><asp:label id="Label12" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Font-Bold="True" Height="20px">Material Value</asp:label></P>
									<P><asp:label id="Label11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Font-Bold="True" Height="20px">Cancellation Charges</asp:label></P>
								</TD>
								<TD style="WIDTH: 100%; HEIGHT: 27px">
									<P><asp:textbox id="txtMatValue" style="TEXT-ALIGN: right" onfocus="total();" tabIndex="15" runat="server"
											Width="15%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="16"
											Enabled="False"></asp:textbox>&nbsp;
									</P>
									<P><asp:textbox id="txtCanCharges" style="TEXT-ALIGN: right" onfocus="total();" tabIndex="15" runat="server"
											Width="15%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="16"
											Enabled="False"></asp:textbox></P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label32" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True">Remarks<Font Color="red">* (Max 400 Chars)</Font></asp:label></TD>
								<TD style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtRemarks" tabIndex="11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Height="50px" MaxLength="400" TextMode="MultiLine"></asp:textbox><asp:label id="Label4" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True">* Add Rejection Remarks.</asp:label><asp:label id="lblRemarks" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label5" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True" Visible="False">Holograms <Font Color="red">* (Max 250 Chars)</Font></asp:label></TD>
								<TD style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtHologram" tabIndex="11" runat="server" Width="100%" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkBlue" Height="25px" Visible="False" MaxLength="300"></asp:textbox><asp:label id="Label6" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True" Visible="False">* Enter series of Holograms Used on material and if Holograms not used then kindly mention type of seal & it's No..</asp:label></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label9" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True">IC Photo<Font Color="red">* IC (Digitally Signed PDF file Only)</Font></asp:label></TD>
								<TD style="WIDTH: 100%; HEIGHT: 12px"><INPUT id="File1" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
										tabIndex="0" type="file" size="51" name="File1" runat="server"></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label15" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True">TESTPLAN/LAB TEST REPORTS (If Any)<Font Color="red">* TESTPLAN 
											(Digitally Signed PDF file Only)</Font></asp:label></TD>
								<TD style="WIDTH: 100%; HEIGHT: 12px"><INPUT id="File14" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
										tabIndex="0" type="file" size="51" name="File1" runat="server"></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label7" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True">IC Annexue-I (If Any)<Font Color="red">* Annexure-I (Digitally Signed PDF file Only)</asp:label></TD>
								<TD style="WIDTH: 100%; HEIGHT: 12px"><INPUT id="File2" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
										tabIndex="0" type="file" size="51" name="File1" runat="server"></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label10" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True">IC Annexue-II (If Any)<Font Color="red">* Annexure-II (Digitally 
											Signed PDF file Only)</Font></asp:label></TD>
								<TD style="WIDTH: 100%; HEIGHT: 12px"><INPUT id="File3" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
										tabIndex="0" type="file" size="51" name="File1" runat="server"></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Case 
									Status Date&nbsp;</TD>
								<TD style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtSTDT" onblur="check_date(txtSTDT);" tabIndex="5" runat="server" Width="88px"
										Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Height="20px" MaxLength="10" Enabled="False"></asp:textbox><FONT face="Verdana" color="activecaption" size="1"><STRONG>&nbsp;(Current&nbsp;Date 
											Will be the&nbsp;Case Status Date&nbsp;i.e Date of 
											Cancellation/Acceptance..etc)</STRONG></FONT> </STYLE></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"></TD>
								<TD style="WIDTH: 70%"><asp:button id="btnSave" tabIndex="6" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="7" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"
									align="center" colSpan="2"><asp:button id="btnViewIC" tabIndex="6" runat="server" Width="20%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Font-Bold="True" Visible="False" Text="View/Print IC" onclick="btnViewIC_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 475px" runat="server"
						Width="100%" Height="1px">
						<TD align="center" colSpan="2">
							<TABLE id="Table2" style="HEIGHT: 104px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
								width="80%" bgColor="aliceblue" border="1">
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 35px">
										<asp:label id="Label14" runat="server" Font-Bold="True" ForeColor="ActiveCaption" Font-Size="8pt"
											Font-Names="Verdana" Width="100%"><font color="OrangeRed">Attention IE's -</font> Please Select the reasons for cancellation carefully. The reason of cancellation should be same to what is being entered on Call Cancellation Form. There should not be any difference in both the cases, If difference is found that will be viewed seriously.</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 35px">
										<asp:label id="Label8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Reasons For Cancellation:-</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk1" tabIndex="3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="01 - Material Not Found"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk2" tabIndex="4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="02 - Call letter recieved after expiry of delivery period"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk3" tabIndex="5" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="03 - your call letter was not in prescribed format"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk4" tabIndex="6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="04 - Your refusal to undertake test on samples in approved independent test houses or RITES Lab at your cost (Whichever applicable)"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk5" tabIndex="7" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="05 - Material offered at premises where adequate room or lighting etc. not available for proper sampling or inspection."></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk6" tabIndex="8" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="06 - Internal inspection and test records incomplete / not as per contractual requirement."></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk7" tabIndex="9" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="07 - Packing list showing quantities offered item wise and consignee wise not read (Whichever applicable) "></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk8" tabIndex="10" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="08 - Lot mixed not segregated. Please re-offer after proper segregation."></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk9" tabIndex="11" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="09 - You could not arrange for inspection in spite of personal contact / phone with your Shri. "></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk10" tabIndex="12" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="10 - You could not produce following documents drg, / spec. / P.O.: at the time of inspection in absence of which inspection could not be done."></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk11" tabIndex="13" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="11 - Call Withdrawn By Vendor"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:checkbox id="chk12" tabIndex="14" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Text="12 - Others (Specify)"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%; HEIGHT: 30px">
										<asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Cancellation Description:-</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%">
										<asp:textbox id="txtCdesc" tabIndex="15" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Width="90%" Height="50px" MaxLength="250" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%">
										<asp:label id="Label13" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Cancellation Document <Font color="red">(PDF Format Only)</Font>:-</asp:label>&nbsp;
										<INPUT id="File4" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 100%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 70%" align="center">
										<asp:button id="btnSaveCancellation" tabIndex="16" runat="server" Font-Bold="True" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSaveCancellation_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</asp:panel></TR>
			</TABLE>
		</form>
	</body>
</HTML>
