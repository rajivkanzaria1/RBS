<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_Form.aspx.cs" Inherits="RBS.IE_Form.IE_Form" %>

<%@ Reference Page="~/Email.aspx" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Inspection Engineer's Form</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(document.Form1.txtIEName.value=="")
		{
		 alert("IE NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else if(document.Form1.txtIESName.value=="")
		{
		 alert("IE SHORT NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCity.value)=="")
		{
		 alert("IE CITY CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else if(document.Form1.txtIEPno.value=="")
		{
		 alert("IE PHONE No. CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		 else if(isNaN(parseInt(document.Form1.txtIEPno.value))) 
		 {
		 alert("The phone number contains illegal characters.");
		 event.returnValue=false;		
		}
		else if(document.Form1.lstType.value=="")
		{
		 alert("IE POSTING PLACE CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		
		
		
		else if(trimAll(document.Form1.txtIEEmail.value)!="")
		{
			
			if (echeck(document.Form1.txtIEEmail.value)==false)
			{
				document.Form1.txtIEEmail.focus();
				event.returnValue=false;
			}
			else
			return;
			

		}
		else 
		{
		document.Form1.btnSave.style.visibility = 'hidden';
		}
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

		
		
		function del2()
		 {
		  if(document.Form1.txtIECD.value=="")
		 {
		 alert("PLZ ENTER INSPECTION ENGINEER'S CODE FIRST THEN CLICK ON MODIFY OR DELETE");
		 event.returnValue=false;
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
		
		function fill_city_cd()
		 {
		 document.Form1.txtCity.value=document.Form1.lstIECity.value;
		 
		 }
		 function validate1()
		{
		 if(trimAll(document.Form1.txtCity.value)=="")
		{
			alert("ENTER CITY CODE OR 1ST 4 CHARACTERS OF CITY NAME AND THEN CLICK ON SELECT CITY BUTTON");
		    event.returnValue=false;
		 }
		 else
		 {
			if(document.Form1.lstIECity=="[object]")
			{
			document.Form1.lstIECity.focus();
			}
		  	event.returnValue=true;
		  		 
		 }

		}
		

        </script>
</HEAD>
	<body onload="javascript:document.Form1.txtIEName.focus();" bgColor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px" id="Table1"
				border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<P><asp:label id="Label1" runat="server" Font-Bold="True" Width="204px" BackColor="White" ForeColor="DarkBlue"
								Font-Size="10pt" Font-Names="Verdana"> INSPECTION ENGINEERS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE style="WIDTH: 100%" id="Table3" border="0" cellSpacing="1" cellPadding="1" width="700"
								bgColor="#f0f8ff">
								<TR>
									<TD style="WIDTH: 15%"></TD>
									<TD style="WIDTH: 35%" align="right"><asp:label id="Label2" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Code</asp:label></TD>
									<TD style="WIDTH: 15%">&nbsp;&nbsp;
										<asp:label id="Label16" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="9pt"
											Font-Names="Verdana" BorderStyle="Inset">IE Code</asp:label></TD>
									<TD style="WIDTH: 35%"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"><asp:label id="Label4" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Name</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox id="txtIEName" tabIndex="2" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="30"></asp:textbox></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label3" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Short Name</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox id="txtIESName" tabIndex="3" runat="server" Width="20%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 38px"><asp:label id="Label10" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE City</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 38px"><asp:textbox id="txtCity" tabIndex="4" runat="server" Width="25%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="4"></asp:textbox><asp:button id="btnFCList" tabIndex="5" runat="server" Font-Bold="True" Width="50%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Text="Select City" ToolTip="Enter the City Code or 1st 4 letters of CITY then click on select city Button" onclick="btnFCList_Click"></asp:button><asp:dropdownlist id="lstIECity" tabIndex="6" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px" onChange="fill_city_cd();" onselectedindexchanged="lstIECity_SelectedIndexChanged"></asp:dropdownlist></TD>
									<TD style="WIDTH: 15%; HEIGHT: 38px"><asp:label id="Label11" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Region</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 38px"><asp:dropdownlist id="lstRegion" tabIndex="7" runat="server" Width="50%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"><asp:label id="Label6" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Phone No.</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox id="txtIEPno" tabIndex="8" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="30"></asp:textbox></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label7" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Controlling Officer.</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:dropdownlist id="lstCOCD" tabIndex="9" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"><asp:label id="Label18" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Email.</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox id="txtIEEmail" tabIndex="10" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="40"></asp:textbox></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label19" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">DOB</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox onblur="check_date1(txtIE_DOB);" id="txtIE_DOB" tabIndex="11" runat="server" Width="30%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 23px"><asp:label id="Label14" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Employee No.</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 23px"><asp:textbox id="txtEmpNo" tabIndex="12" runat="server" Width="20%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="6"></asp:textbox></TD>
									<TD style="WIDTH: 15%; HEIGHT: 23px"><asp:label id="Label13" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Seal No.</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox id="txtSealNo" tabIndex="13" runat="server" Width="20%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="20px" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 32px"><asp:label id="Label5" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Department</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 32px"><asp:dropdownlist id="lstDept" tabIndex="14" runat="server" Width="80%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 15%; HEIGHT: 32px"><asp:label id="Label12" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Designation</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:dropdownlist id="lstDesig" tabIndex="15" runat="server" Width="50%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 18px"><asp:label id="Label8" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Joining Date (DD/MM/YYYY)</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 18px"><asp:textbox onblur="check_date(txtJoinDT);" id="txtJoinDT" tabIndex="16" runat="server" Width="30%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
									<TD style="WIDTH: 15%; HEIGHT: 18px"><asp:label id="Label9" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Posting</asp:label></TD>
									<TD style="WIDTH: 35%; HEIGHT: 18px"><asp:dropdownlist id="lstType" tabIndex="17" runat="server" Width="50%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"><asp:label id="Label17" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Status</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:dropdownlist id="lstStatus" tabIndex="18" runat="server" Width="50%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label15" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Status Date (DD/MM/YYYY)</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox onblur="check_date(txtStatusDT);" id="txtStatusDT" tabIndex="19" runat="server"
											Width="30%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"><asp:label id="Label22" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE CALL MARKING</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:radiobutton id="rdbIYes" tabIndex="10" runat="server" Font-Bold="True" Width="80px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Text="Yes" GroupName="g1" Checked="True" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="rdbINo" tabIndex="11" runat="server" Font-Bold="True" Width="56px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Text="No" GroupName="g1" AutoPostBack="True"></asp:radiobutton></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label26" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Call Marking Stopping Date</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:textbox onblur="check_date(txtCallStopDt);" id="txtCallStopDt" tabIndex="12" runat="server"
											Width="30%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<td>
										<asp:label id="Label27" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">IE TYPE</asp:label></td>
									<td>
										<asp:dropdownlist id="lstIEJobType" tabIndex="18" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="50%" Height="25px">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="R">Regular</asp:ListItem>
											<asp:ListItem Value="D">Deputation</asp:ListItem>
											<asp:ListItem Value="C">Contract</asp:ListItem>
										</asp:dropdownlist></td>
									<TD style="WIDTH: 15%"><asp:label id="Label24" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Alternate IE ONE</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:dropdownlist id="Dropdownlist2" tabIndex="13" runat="server" Width="50%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"><asp:label id="Label23" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Alternate IE TWO</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:dropdownlist id="Dropdownlist1" tabIndex="14" runat="server" Width="50%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="25px" onselectedindexchanged="Dropdownlist1_SelectedIndexChanged"></asp:dropdownlist></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label25" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Alternate IE THREE</asp:label></TD>
									<TD style="WIDTH: 35%"><asp:dropdownlist id="Dropdownlist3" tabIndex="15" runat="server" Width="50%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="25px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">
										<asp:label id="Label28" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="100%" Font-Bold="True">Contract Alternate IE</asp:label></TD>
									<TD style="WIDTH: 35%">
										<asp:dropdownlist id="lstCont_Alt_IE" tabIndex="14" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="50%" Height="25px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 15%"></TD>
									<TD style="WIDTH: 35%"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%"><asp:label id="Label20" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Full Signature (JPG Format Only)</asp:label></TD>
									<TD style="WIDTH: 35%"><INPUT style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											id="File1" tabIndex="0" size="51" type="file" name="File1" runat="server">
										<asp:image id="Image1" runat="server" Width="300px" Height="100px"></asp:image></TD>
									<TD style="WIDTH: 15%"><asp:label id="Label21" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">IE Initials  (JPG Format Only)</asp:label></TD>
									<TD style="WIDTH: 35%"><INPUT style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											id="File2" tabIndex="0" size="51" type="file" name="File1" runat="server">
										<asp:image id="Image2" runat="server" Width="300px" Height="100px"></asp:image></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" tabIndex="20" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button>
						<asp:button id="btnUpload" tabIndex="20" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True" Text="Upload Signature" onclick="btnUpload_Click"></asp:button><asp:button id="btnDelConfirm" tabIndex="21" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Width="81px" Font-Bold="True" Text="Delete!!!" Visible="False" onclick="btnDelConfirm_Click"></asp:button><asp:button id="btnCancel" tabIndex="22" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<P>&nbsp;</P>
						<P align="center">&nbsp;</P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
