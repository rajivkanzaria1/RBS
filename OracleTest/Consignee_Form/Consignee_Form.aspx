<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consignee_Form.aspx.cs" Inherits="RBS.Consignee_Form.Consignee_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>CONSIGNEE FORM</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		//if(document.Form1.txtCLName.value=="")
		//{
		// alert("CONSIGNEE/PURCHASER NAME CANNOT BE LEFT BLANK");
		// event.returnValue=false;
		// }
		//else if(document.Form1.txtCAdd1.value=="")
		//{
		// alert("ADDRESS LINE 1ST CANNOT BE LEFT BLANK");
		// event.returnValue=false;
		//}
		 if(trimAll(document.Form1.txtCity.value)=="")
		 {
		 alert("CITY CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtGSTINNo.value)=="")
		{
		 alert("CONSIGNEE GSTIN NO. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else if(document.Form1.txtGSTINNo.value.length != 15)
		 {
		 alert("PLZ ENTER 15 CHARACTERS LONG GSTIN NO. ONLY!!!");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtPIN.value.length != 6)
		 {
		 alert("PLZ ENTER 6 CHARACTERS LONG PIN NO. ONLY!!!");
		 event.returnValue=false;
		 }
		else
		{
		document.Form1.btnSave.style.visibility = 'hidden';
		return;
		}
		}
		function del()
		{
		var d=confirm("Click OK to Confirm Delete!!!");
		if(d==true)
		event.returnValue=true;
		else
		event.returnValue=false;
		}
		
		function del2()
		 {
		  if(document.Form1.txtCCode.value=="")
		 {
		 alert("PLZ ENTER CONSIGNEE/PURCHASER CODE FIRST THEN CLICK ON MODIFY OR DELETE");
		 event.returnValue=false;
		 }
		 }
		 
		 function abc()
		 {
		 
		 document.Form1.lstCType.focus();
		 
		 
		 }
		 
		
		 
		 function con_rail()
		 {
		
		 if(document.Form1.lstCType.value=="R")
		 {
			document.Form1.txtFName.style.visibility = 'hidden';
			document.Form1.txtCSName.style.visibility = 'hidden';
			document.Form1.lstRailwayCD.style.visibility = 'visible';
			document.Form1.lstCAName.style.visibility = 'visible';
			document.Form1.lstRailwayCD.focus();
						
		 }
		 else
		 {
			document.Form1.txtFName.style.visibility = 'visible';
			document.Form1.txtCSName.style.visibility = 'visible';
			document.Form1.lstCAName.style.visibility = 'hidden';
			document.Form1.lstRailwayCD.style.visibility = 'hidden';
			document.Form1.txtFName.focus();
			
		 }
		 }
		 function fill_city_cd()
		 {
		 document.Form1.txtCity.value=document.Form1.lstCCity.value;
		 
		 }
		 function con_rail_1()
		 {
		
		 if(document.Form1.lstCType.value=="R")
		 {
			document.Form1.txtFName.style.visibility = 'hidden';
			document.Form1.txtCSName.style.visibility = 'hidden';
			document.Form1.lstRailwayCD.style.visibility = 'visible';
			document.Form1.lstCAName.style.visibility = 'visible';
			
						
		 }
		 else
		 {
			document.Form1.txtFName.style.visibility = 'visible';
			document.Form1.txtCSName.style.visibility = 'visible';
			document.Form1.lstCAName.style.visibility = 'hidden';
			document.Form1.lstRailwayCD.style.visibility = 'hidden';
			
			
		 }
		 }
		 
		 function validate1()
		{
		 if(trimAll(document.Form1.txtCity.value)=="")
		{
		 alert("ENTER CITY CODE OR 1ST 4 CHARACTERS OF CITY NAME AND THEN CLICK ON SELECT CITY BUTTON");
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
	<body onblur="con_rail_1();" onload="con_rail();abc();">
		<form id="Form1" method="post" runat="server">
			<BLOCKQUOTE>
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
					cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 25px" align="center" colSpan="5"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 296px" align="center" colSpan="5">
							<P><asp:label id="Label1" runat="server" ForeColor="DarkBlue" Font-Bold="True" BackColor="White"
									Font-Size="10pt" Font-Names="Verdana">CONSIGNEE/PURCHASER MASTER</asp:label></P>
							<P align="center">
								<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 250px" borderColor="#b0c4de" cellSpacing="0"
									cellPadding="0" width="504" bgColor="aliceblue" border="1">
									<TR>
										<td style="HEIGHT: 29px" width="15%" colSpan="2"></td>
										<td style="HEIGHT: 29px" align="right" width="35%"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Width="129px">Consignee Code </asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
										<TD style="HEIGHT: 29px" width="15%"><asp:textbox id="txtCCode" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Width="100%" MaxLength="8" Height="25px"></asp:textbox><asp:label id="Label11" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Width="100%" BorderStyle="Inset">Consignee Code </asp:label></TD>
										<TD style="HEIGHT: 29px" width="35%">
<asp:label id=lblSapCustCD runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="OrangeRed" Width="100%"></asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%; HEIGHT: 21px" colSpan="2"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Width="100%">Consignee Type</asp:label></TD>
										<TD style="WIDTH: 35%; HEIGHT: 21px"><asp:dropdownlist id="lstCType" OnChange="con_rail();" tabIndex="1" runat="server" ForeColor="DarkBlue"
												Font-Size="8pt" Font-Names="Verdana" Width="50%" Height="25px"></asp:dropdownlist></TD>
										<td style="WIDTH: 15%; HEIGHT: 26px" align="left"><asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Width="100%"> Railway/Purchaser</asp:label></td>
										<td style="WIDTH: 35%; HEIGHT: 26px"><asp:dropdownlist id="lstRailwayCD" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Width="95%" Height="25px"></asp:dropdownlist><asp:textbox id="txtFName" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Width="95%" MaxLength="75" Height="20px"></asp:textbox></td>
									</TR>
									<TR>
										<TD style="WIDTH: 15%; HEIGHT: 31px" colSpan="2"><asp:label id="Label9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Width="100%"> Consignee Designation</asp:label></TD>
										<TD style="WIDTH: 35%; HEIGHT: 31px"><asp:textbox id="txtCSName" tabIndex="3" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Width="95%" MaxLength="40" Height="20px"></asp:textbox><asp:dropdownlist onkeypress="return keySort(lstCAName);" id="lstCAName" tabIndex="3" runat="server"
												ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Width="50%" Height="25px"></asp:dropdownlist></TD>
										<TD style="WIDTH: 15%; HEIGHT: 31px" align="left"><asp:label id="Label4" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Width="100%">Department</asp:label></TD>
										<TD style="WIDTH: 35%; HEIGHT: 31px"><asp:textbox id="txtCDept" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Width="50%" MaxLength="15" Height="20px"></asp:textbox></TD>
									</TR>
									<TR>
										<td style="WIDTH: 15%; HEIGHT: 19px" colSpan="2"><asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Width="100%"> Address</asp:label></td>
										<td style="WIDTH: 35%; HEIGHT: 19px"><asp:textbox id="txtCAdd1" tabIndex="5" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Width="95%" MaxLength="100" Height="50px" TextMode="MultiLine"></asp:textbox></td>
										<TD style="WIDTH: 15%; HEIGHT: 19px" align="left"><asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana" Width="100%"> City</asp:label></TD>
										<TD style="WIDTH: 35%; HEIGHT: 19px"><asp:textbox id="txtCity" tabIndex="7" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Width="25%" MaxLength="4" Height="20px"></asp:textbox><asp:button id="btnFCList" tabIndex="8" runat="server" ForeColor="DarkBlue" Font-Bold="True"
												Font-Size="8pt" Font-Names="Verdana" Width="50%" ToolTip="Enter the City Code or 1st 4 letters of CITY then click on select city Button" Text="Select City" onclick="btnFCList_Click"></asp:button><asp:dropdownlist id="lstCCity" tabIndex="9" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Width="95%" Height="25px" AutoPostBack="True" onselectedindexchanged="lstCCity_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<td style="WIDTH: 15%; HEIGHT: 26px" colSpan="2"></td>
										<td style="WIDTH: 35%; HEIGHT: 26px"><asp:textbox id="txtCAdd2" tabIndex="6" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
												Width="95%" MaxLength="100" Height="50px" TextMode="MultiLine"></asp:textbox></td>
										<TD style="WIDTH: 15%; HEIGHT: 26px">
											<asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="91px">GSTIN No. <font color="red">*</font></asp:label></TD>
										<TD style="WIDTH: 35%; HEIGHT: 26px">
											<asp:textbox id="txtGSTINNo" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="DarkBlue" Width="50%" Height="20px" MaxLength="15"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%; HEIGHT: 5px" colSpan="2">
											<asp:label id="Label29" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="184px">PIN Code <font color="red">*</font></asp:label></TD>
										<TD style="WIDTH: 35%; HEIGHT: 5px">
											<asp:textbox id="txtPin" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="50%" Height="20px" MaxLength="6"></asp:textbox></TD>
										<TD style="WIDTH: 15%; HEIGHT: 5px">
											<asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%"> State <font color="red">*</font></asp:label></TD>
										<TD style="WIDTH: 35%; HEIGHT: 5px">
											<P>
												<asp:label id="lblConState" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="OrangeRed" Width="100%"></asp:label></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%; HEIGHT: 26px" align="right" colSpan="3"></TD>
										<TD style="WIDTH: 15%; HEIGHT: 26px" colSpan="2"></TD>
									</TR>
								</TABLE>
								<asp:label id="Label10" runat="server" ForeColor="DarkMagenta" Font-Bold="True" Font-Size="8pt"
									Font-Names="Verdana" Width="346px">* To Add New Record Fill Values and Click on Save</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 19px" align="center" colSpan="5">
							<P><asp:button id="btnAdd" tabIndex="11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
									Font-Names="Verdana" Width="70px" Text="Add New" onclick="Button1_Click"></asp:button><asp:button id="btnSave" tabIndex="12" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="13" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnCancel" tabIndex="14" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="5"></TD>
					</TR>
				</TABLE>
			</BLOCKQUOTE>
		</form>
	</body>
</HTML>

