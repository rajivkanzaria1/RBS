<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Return_Form.aspx.cs" Inherits="RBS.Call_Return_Form.Call_Return_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Call Return Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		
		function validate1()
		{
		 
		 
		 if(trimAll(document.Form1.txtVend.value)=="")
		{
		 alert("ENTER VENDOR CODE OR 1ST Few CHARACTERS OF VENDOR NAME AND THEN CLICK ON SELECT VENDOR BUTTON");
		 event.returnValue=false;
		 }
		  else
		 return;

		}
		
		function validate()
		{
			if(document.Form1.lstClientType.value=="")
			{
			alert("SELECT PO CLIENT TYPE!!!");
			event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtDatePOrites.value)=="")
			{
			alert("DATE OF RECIEPT OF CALL IN RITES CANNOT BE LEFT BLANK!!!");
			event.returnValue=false;
			}
			
			else if((document.Form1.chk1.checked==false && document.Form1.chk2.checked==false) && (document.Form1.chk3.checked==false && document.Form1.chk4.checked==false) && (document.Form1.chk5.checked==false && document.Form1.chk6.checked==false) && (document.Form1.chk7.checked==false && document.Form1.chk8.checked==false) && (document.Form1.chk9.checked==false))
			{
			alert("SELECT ATLEAST ONE REASON FOR CALL CANCELLATION!!!");
			event.returnValue=false;
			}
			else if (document.Form1.chk9.checked==true && trimAll(document.Form1.txtRRemarks.value)=="")
			{
				alert("ENTER REMARKS IN CASE OF OTHERS!!!");
				event.returnValue=false;
			}
			else if(document.Form1.txtRRemarks.value.length > 250)
			{
			alert("REMARKS SHOULD BE MAXIMUM 250 CHARACTERS INCLUDING SPACES !!!");
			event.returnValue=false;
			}
			else
			
			return;
		}
		
		function keySort(dropdownlist,caseSensitive)
		{
			// check the keypressBuffer attribute is defined on the dropdownlist 
			var undefined; 
			if (dropdownlist.keypressBuffer == undefined)
			{ 
				dropdownlist.keypressBuffer = ''; 
			} 
			// get the key that was pressed 
			var key = String.fromCharCode(window.event.keyCode); 
			dropdownlist.keypressBuffer += key;
			if (!caseSensitive) 
			{
				// convert buffer to lowercase
				dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
			}
			// find if it is the start of any of the options 
			var optionsLength = dropdownlist.options.length; 
			for (var n=0; n < optionsLength; n++) 
			{ 
				var optionText = dropdownlist.options[n].text; 
				if (!caseSensitive)
				{
				optionText = optionText.toLowerCase();
				}
				if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0)
				{ 
				dropdownlist.selectedIndex = n; 
				return false; // cancel the default behavior since 
								// we have selected our own value 
				} 
			} 
			// reset initial key to be inline with default behavior 
			dropdownlist.keypressBuffer = key; 
			return true; // give default behavior 
		} 
        </script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center" width="100%" colSpan="4"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="center" colSpan="4">
						<P><asp:label id="Label1" runat="server" ForeColor="DarkBlue" Font-Bold="True" BackColor="White"
								Font-Size="10pt" Font-Names="Verdana">CALL RETURN FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">
						<TABLE id="Table2" style="HEIGHT: 104px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
							width="85%" bgColor="aliceblue" border="1">
							<TR>
								<TD style="WIDTH: 25.22%; HEIGHT: 26px" vAlign="top" colSpan="1" rowSpan="1"><asp:label id="Label_Return_DT" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="112px">Call Return Date:</asp:label><asp:label id="lblReturn_DT" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="80px"></asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 26px" align="right"><asp:label id="Label_Return_No" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="96px">Call Return No.</asp:label><asp:label id="lblReturn_No" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="101px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.22%; HEIGHT: 27px" align="left"><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="48px"> Vendor</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
								<TD style="WIDTH: 70%; HEIGHT: 27px"><asp:textbox id="txtVend" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										Width="35%" Height="20px"></asp:textbox><asp:button id="btnFCList" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Bold="True"
										Font-Size="8pt" Font-Names="Verdana" Width="25%" Text="Select Vendor" ToolTip="Enter the Vendor Code or 1st few letters of Vendor then click on select Vendor Button" onclick="btnFCList_Click"></asp:button>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.22%; HEIGHT: 41px" align="left" colSpan="2"><asp:dropdownlist onkeypress="return keySort(ddlVender);" id="ddlVender" tabIndex="3" runat="server"
										ForeColor="DarkBlue" Font-Size="7pt" Font-Names="Verdana" Width="99%" Height="25px" AutoPostBack="True" onselectedindexchanged="ddlVender_SelectedIndexChanged"></asp:dropdownlist><asp:label id="lblVendor" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="100%"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.22%; HEIGHT: 23px"><asp:label id="Label9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="96px">Vendor Email:</asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:textbox id="txtVend_Email" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="60%" Height="20px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.22%; HEIGHT: 23px"><asp:label id="Label10" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="128px">Vendor Mobile No:</asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:textbox id="txtVend_Contact_NO" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="60%" Height="20px" MaxLength="25"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.22%; HEIGHT: 23px"><STRONG><FONT face="Verdana" size="2"><asp:label id="Label4" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Width="120px">PO Client Type</asp:label>&nbsp; </FONT></STRONG>
								</TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:dropdownlist id="lstClientType" tabIndex="6" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="50%" AutoPostBack="True" onselectedindexchanged="lstClientType1_SelectedIndexChanged"></asp:dropdownlist></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.22%; HEIGHT: 23px"><asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="120px">Select PO Client</asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:dropdownlist id="lstBPO_Rly" tabIndex="7" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.22%; HEIGHT: 30px"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="112px">Call Letter Date:</asp:label><asp:textbox id="txtCall_Lett_DT" onblur="check_date(txtCall_Lett_DT);" tabIndex="8" runat="server"
										ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="80px" Height="20px" MaxLength="10"></asp:textbox></TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px" align="right" colSpan="1" rowSpan="1"><asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="104px">Call Letter No.</asp:label><asp:textbox id="txtCallNO" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="60%" Height="20px" MaxLength="30"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.22%; HEIGHT: 30px"><asp:label id="Label12" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Width="208px"> Date of Reciept of Call in RITES</asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:textbox id="txtDatePOrites" onblur="check_date(txtDatePOrites);compareDates(txtPOdate,txtDatePOrites,'Date Of Reciept In Rites Cannot Be Less Then PO Date');"
										tabIndex="10" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="25%" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Reasons For Return:-</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:checkbox id="chk1" tabIndex="11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="01 - P.O. not attached with call also P.O. not received from purchaser."></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:checkbox id="chk2" tabIndex="12" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="02 - P.O. is not readable/Incomplete/not signed."></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:checkbox id="chk3" tabIndex="13" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="03 - P.O. value is less than 1.5 Lakh (Railway Board Order No. 2000/RS(G)/379/2 Dated 10-09-2013)."></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:checkbox id="chk4" tabIndex="14" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="04 - Delivery Period expired."></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:checkbox id="chk5" tabIndex="15" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="05 - Bill Paying Officer not mentioned in P.O."></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:checkbox id="chk6" tabIndex="16" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="06 - Inspection clause indicating RITES inspection not mentioned in P.O."></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:checkbox id="chk7" tabIndex="17" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="07 - Inspection by RDSO/Consignee/Other RITES regional offices."></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:checkbox id="chk8" tabIndex="18" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="08 - Adequate time not given to initiate the inspection with in D.P."></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:checkbox id="chk9" tabIndex="19" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana" Text="09 - Others. (Specify)"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2">&nbsp;<asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Remarks (In Case of Others)</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%; HEIGHT: 30px" colSpan="2"><asp:textbox id="txtRRemarks" tabIndex="20" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
										Font-Names="Verdana" Width="90%" Height="50px" MaxLength="250" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%" colSpan="2"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">
						<P><asp:button id="btnSave" tabIndex="21" runat="server" ForeColor="DarkBlue" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Text="Submit" onclick="btnSave_Click"></asp:button><asp:button id="Button1" tabIndex="22" runat="server" ForeColor="DarkBlue" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Text="Add New " onclick="Button1_Click"></asp:button><asp:button id="btnCancel" tabIndex="23" runat="server" ForeColor="DarkBlue" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Text="Cancel"></asp:button></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
