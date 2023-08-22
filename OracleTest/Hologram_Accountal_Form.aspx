<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hologram_Accountal_Form.aspx.cs" Inherits="RBS.Hologram_Accountal_Form.Hologram_Accountal_Form" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Hologram_Accountal_Form</title>
		<style type="text/css">.MyDataGridCaption { FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: darkblue; FONT-FAMILY: "Verdana"; etc: }
		</style>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		
		function validate()
		{
			if(trimAll(document.Form1.txtHGNOMatFR.value)=="" && trimAll(document.Form1.txtHGNOMatTO.value)=="" && trimAll(document.Form1.txtHGNOSampFR.value)=="" && trimAll(document.Form1.txtHGNOSampTO.value)=="" && trimAll(document.Form1.txtHGNOTestFR.value)=="" && trimAll(document.Form1.txtHGNOTestTo.value)=="" && trimAll(document.Form1.txtHGNOICFR.value)=="" && trimAll(document.Form1.txtHGNOICTO.value)=="" && trimAll(document.Form1.txtHGNOICDoc.value)=="" && trimAll(document.Form1.txtHGNOOTFR.value)=="" && trimAll(document.Form1.txtHGNOOTTO.value)=="")
			{
			alert("ENTER VALUES TO SAVE!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOMatFR.value!="" && IsNumeric(document.Form1.txtHGNOMatFR.value) == false)
			{
			alert("HOLOGRAM NO. FROM USED ON MATERIALS/STORES CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOMatTO.value!="" && IsNumeric(document.Form1.txtHGNOMatTO.value) == false)
			{
			alert("HOLOGRAM NO. TO USED ON MATERIALS/STORES CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOSampFR.value!="" && IsNumeric(document.Form1.txtHGNOSampFR.value) == false)
			{
			alert("HOLOGRAM NO. FROM USED ON SAMPLES CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOSampTO.value!="" && IsNumeric(document.Form1.txtHGNOSampTO.value) == false)
			{
			alert("HOLOGRAM NO. TO USED ON SAMPLES CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOTestFR.value!="" && IsNumeric(document.Form1.txtHGNOTestFR.value) == false)
			{
			alert("HOLOGRAM NO. FROM USED ON TESTS CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOTestTo.value!="" && IsNumeric(document.Form1.txtHGNOTestTo.value) == false)
			{
			alert("HOLOGRAM NO. TO USED ON TESTS CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOICFR.value!="" && IsNumeric(document.Form1.txtHGNOICFR.value) == false)
			{
			alert("HOLOGRAM NO. FROM USED ON IC CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOICTO.value!="" && IsNumeric(document.Form1.txtHGNOICTO.value) == false)
			{
			alert("HOLOGRAM NO. TO USED ON IC CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOOTFR.value!="" && IsNumeric(document.Form1.txtHGNOOTFR.value) == false)
			{
			alert("HOLOGRAM NO. FROM USED ON OTHER LOCATION CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOOTTO.value!="" && IsNumeric(document.Form1.txtHGNOOTTO.value) == false)
			{
			alert("HOLOGRAM NO. TO USED ON OTHER LOCATION CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else if(document.Form1.txtHGNOICDoc.value!="" && IsNumeric(document.Form1.txtHGNOICDoc.value) == false)
			{
			alert("HOLOGRAM NO. USED ON INSPECTION DOCUMENTS CONTAINS INVALID CHARATERS!!!");
			event.returnValue=false;
			}
			else 
			verify_holograms();
			return;
		}
		 	
		function verify_holograms()
		{
		 var msg="";
		 if (trimAll(document.Form1.txtHGNOMatFR.value)!="")
			{
			 if (
				((trimAll(document.Form1.txtHGNOMatFR.value) >= trimAll(document.Form1.txtHGNOSampFR.value)) && (trimAll(document.Form1.txtHGNOMatFR.value) <= trimAll(document.Form1.txtHGNOSampTO.value))) ||
				((trimAll(document.Form1.txtHGNOMatTO.value) >= trimAll(document.Form1.txtHGNOSampFR.value)) && (trimAll(document.Form1.txtHGNOMatTO.value) <= trimAll(document.Form1.txtHGNOSampTO.value))) || 
				((trimAll(document.Form1.txtHGNOMatFR.value) < trimAll(document.Form1.txtHGNOSampFR.value)) && (trimAll(document.Form1.txtHGNOMatTO.value) > trimAll(document.Form1.txtHGNOSampTO.value)))
				)			
				{msg="Hologram on Material and Sample are Repeating!!!";}
			if (
				((trimAll(document.Form1.txtHGNOMatFR.value) >= trimAll(document.Form1.txtHGNOTestFR.value)) && (trimAll(document.Form1.txtHGNOMatFR.value) <= trimAll(document.Form1.txtHGNOTestTo.value))) ||
				((trimAll(document.Form1.txtHGNOMatTO.value) >= trimAll(document.Form1.txtHGNOTestFR.value)) && (trimAll(document.Form1.txtHGNOMatTO.value) <= trimAll(document.Form1.txtHGNOTestTo.value))) || 
				((trimAll(document.Form1.txtHGNOMatFR.value) < trimAll(document.Form1.txtHGNOTestFR.value)) && (trimAll(document.Form1.txtHGNOMatTO.value) > trimAll(document.Form1.txtHGNOTestTo.value)))
				)			
				{msg=msg+"Hologram on Material and Test Request Slip are Repeating!!!";}	
			if (
				((trimAll(document.Form1.txtHGNOMatFR.value) >= trimAll(document.Form1.txtHGNOICFR.value)) && (trimAll(document.Form1.txtHGNOMatFR.value) <= trimAll(document.Form1.txtHGNOICTO.value))) ||
				((trimAll(document.Form1.txtHGNOMatTO.value) >= trimAll(document.Form1.txtHGNOICFR.value)) && (trimAll(document.Form1.txtHGNOMatTO.value) <= trimAll(document.Form1.txtHGNOICTO.value))) || 
				((trimAll(document.Form1.txtHGNOMatFR.value) < trimAll(document.Form1.txtHGNOICFR.value)) && (trimAll(document.Form1.txtHGNOMatTO.value) > trimAll(document.Form1.txtHGNOICTO.value)))
				)			
				{msg=msg+"Hologram on Material and IC are Repeating!!!";}	
			if ((trimAll(document.Form1.txtHGNOICDoc.value) >= trimAll(document.Form1.txtHGNOMatFR.value)   ) && (trimAll(document.Form1.txtHGNOICDoc.value) <= trimAll(document.Form1.txtHGNOMatTO.value)))		
				{msg=msg+"Hologram on Material and Inspection Documents are Repeating!!!";}
			if (
				((trimAll(document.Form1.txtHGNOMatFR.value) >= trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOMatFR.value) <= trimAll(document.Form1.txtHGNOOTTO.value))) ||
				((trimAll(document.Form1.txtHGNOMatTO.value) >= trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOMatTO.value) <= trimAll(document.Form1.txtHGNOOTTO.value))) || 
				((trimAll(document.Form1.txtHGNOMatFR.value) < trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOMatTO.value) > trimAll(document.Form1.txtHGNOOTTO.value)))
				)			
				{msg=msg+"Hologram on Material and Other Location are Repeating!!!";}	
			}
		 if (trimAll(document.Form1.txtHGNOSampFR.value)!="")
			{
			if (
				((trimAll(document.Form1.txtHGNOSampFR.value) >= trimAll(document.Form1.txtHGNOTestFR.value)) && (trimAll(document.Form1.txtHGNOSampFR.value) <= trimAll(document.Form1.txtHGNOTestTo.value))) ||
				((trimAll(document.Form1.txtHGNOSampTO.value) >= trimAll(document.Form1.txtHGNOTestFR.value)) && (trimAll(document.Form1.txtHGNOSampTO.value) <= trimAll(document.Form1.txtHGNOTestTo.value))) || 
				((trimAll(document.Form1.txtHGNOSampFR.value) < trimAll(document.Form1.txtHGNOTestFR.value)) && (trimAll(document.Form1.txtHGNOSampTO.value) > trimAll(document.Form1.txtHGNOTestTo.value)))
				)			
				{msg=msg+"Hologram on Sample and Test Request Slip are Repeating!!!";}	
			if (
				((trimAll(document.Form1.txtHGNOSampFR.value) >= trimAll(document.Form1.txtHGNOICFR.value)) && (trimAll(document.Form1.txtHGNOSampFR.value) <= trimAll(document.Form1.txtHGNOICTO.value))) ||
				((trimAll(document.Form1.txtHGNOSampTO.value) >= trimAll(document.Form1.txtHGNOICFR.value)) && (trimAll(document.Form1.txtHGNOSampTO.value) <= trimAll(document.Form1.txtHGNOICTO.value))) || 
				((trimAll(document.Form1.txtHGNOSampFR.value) < trimAll(document.Form1.txtHGNOICFR.value)) && (trimAll(document.Form1.txtHGNOSampTO.value) > trimAll(document.Form1.txtHGNOICTO.value)))
				)			
				{msg=msg+"Hologram on Sample and IC are Repeating!!!";}	
			if ((trimAll(document.Form1.txtHGNOICDoc.value) >= trimAll(document.Form1.txtHGNOSampFR.value)) && (trimAll(document.Form1.txtHGNOICDoc.value) <= trimAll(document.Form1.txtHGNOSampTO.value)))		
				{msg=msg+"Hologram on Sample and Inspection Documents are Repeating!!!";}
			if (
				((trimAll(document.Form1.txtHGNOSampFR.value) >= trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOSampFR.value) <= trimAll(document.Form1.txtHGNOOTTO.value))) ||
				((trimAll(document.Form1.txtHGNOSampTO.value) >= trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOSampTO.value) <= trimAll(document.Form1.txtHGNOOTTO.value))) || 
				((trimAll(document.Form1.txtHGNOSampFR.value) < trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOSampTO.value) > trimAll(document.Form1.txtHGNOOTTO.value)))
				)			
				{msg=msg+"Hologram on Sample and Other Location are Repeating!!!";}	
			}
		if (trimAll(document.Form1.txtHGNOTestFR.value)!="")
			{
			if (
				((trimAll(document.Form1.txtHGNOTestFR.value) >= trimAll(document.Form1.txtHGNOICFR.value)) && (trimAll(document.Form1.txtHGNOTestFR.value) <= trimAll(document.Form1.txtHGNOICTO.value))) ||
				((trimAll(document.Form1.txtHGNOTestTo.value) >= trimAll(document.Form1.txtHGNOICFR.value)) && (trimAll(document.Form1.txtHGNOTestTo.value) <= trimAll(document.Form1.txtHGNOICTO.value))) || 
				((trimAll(document.Form1.txtHGNOTestFR.value) < trimAll(document.Form1.txtHGNOICFR.value)) && (trimAll(document.Form1.txtHGNOTestTo.value) > trimAll(document.Form1.txtHGNOICTO.value)))
				)			
				{msg=msg+"Hologram on Test Request Slip and IC are Repeating!!!";}	
			if ((trimAll(document.Form1.txtHGNOICDoc.value) >= trimAll(document.Form1.txtHGNOTestFR.value)) && (trimAll(document.Form1.txtHGNOICDoc.value) <= trimAll(document.Form1.txtHGNOTestTo.value)))		
				{msg=msg+"Hologram on Test Request Slip and Inspection Documents are Repeating!!!";}
			if (
				((trimAll(document.Form1.txtHGNOTestFR.value) >= trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOTestFR.value) <= trimAll(document.Form1.txtHGNOOTTO.value))) ||
				((trimAll(document.Form1.txtHGNOTestTo.value) >= trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOTestTo.value) <= trimAll(document.Form1.txtHGNOOTTO.value))) || 
				((trimAll(document.Form1.txtHGNOTestFR.value) < trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOTestTo.value) > trimAll(document.Form1.txtHGNOOTTO.value)))
				)			
				{msg=msg+"Hologram on Test Request Slip and Other Location are Repeating!!!";}	
			}
		if (trimAll(document.Form1.txtHGNOICFR.value)!="")
			{
			if ((trimAll(document.Form1.txtHGNOICDoc.value) >= trimAll(document.Form1.txtHGNOICFR.value)) && (trimAll(document.Form1.txtHGNOICDoc.value) <= trimAll(document.Form1.txtHGNOICTO.value)))		
				{msg=msg+"Hologram on IC and Inspection Documents are Repeating!!!";}
			if (
				((trimAll(document.Form1.txtHGNOICFR.value) >= trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOICFR.value) <= trimAll(document.Form1.txtHGNOOTTO.value))) ||
				((trimAll(document.Form1.txtHGNOICTO.value) >= trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOICTO.value) <= trimAll(document.Form1.txtHGNOOTTO.value))) || 
				((trimAll(document.Form1.txtHGNOICFR.value) < trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOICTO.value) > trimAll(document.Form1.txtHGNOOTTO.value)))
				)			
				{msg=msg+"Hologram on IC and Other Location are Repeating!!!";}	
			}
		if (trimAll(document.Form1.txtHGNOICDoc.value)!="")
			{
			if ((trimAll(document.Form1.txtHGNOICDoc.value) >= trimAll(document.Form1.txtHGNOOTFR.value)) && (trimAll(document.Form1.txtHGNOICDoc.value) <= trimAll(document.Form1.txtHGNOOTTO.value)))		
				{msg=msg+"Hologram on Inspection Documents and Other Location are Repeating!!!";}
			}
		if (trimAll(msg)!="") 
		{alert(msg);
		event.returnValue=false;}
		}	
		
		function check(from, to)
		{
			if(from.value!="" && to.value!="")
			{
				var setfr=(from.value);
				var setto=(to.value);
				if(setto<setfr)
				{
					alert("[HOLOGRAM No. To] Must be Greater than [HOLOGRAM No. From]");
					from.focus();
				}
				return false;
			}
		}
		
		function txtCopy(frm, to)
		{
			if(trimAll(frm.value)!="" && trimAll(to.value)=="")
			{
				to.value=frm.value;
			}
		}

		function change(certno)
		{
			var d=certno.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="000000" + d;
				certno.value=d
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="00000" + d;
				certno.value=d
				event.returnValue=false;
			}
			else if(dlength==3)
			{
				d="0000" + d;
				certno.value=d
				event.returnValue=false;
			}
			else if(dlength==4)
			{
				d="000" + d;
				certno.value=d
				event.returnValue=false;
			}
			else if(dlength==5)
			{
				d="00" + d;
				certno.value=d
				event.returnValue=false;
			}
			else if(dlength==6)
			{
				d="0" + d;
				certno.value=d
				event.returnValue=false;
			}
			else
			return false;	
		}
		
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" colSpan="4" height="17"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="4">
						<P><asp:textbox id="txtSysDate" runat="server" Width="1px" Height="1px" BorderStyle="None"></asp:textbox><asp:label id="Label1" runat="server" Width="357px" ForeColor="DarkBlue" BackColor="White"
								Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">HOLOGRAM ACCOUNTAL FORM</asp:label></P>
					</TD>
				</TR>
				<tr bgColor="#ccccff">
					<TD style="WIDTH: 10%; HEIGHT: 30px"><asp:label id="Label12" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Case No.</asp:label></TD>
					<TD style="WIDTH: 50%; HEIGHT: 30px"><asp:label id="txtCaseNo" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Case No </asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 30px"><asp:label id="Label16" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"> Call Date - SNo. </asp:label></TD>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 30px"><asp:label id="txtDtOfReciept" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">C Date </asp:label>&nbsp;-
						<asp:label id="lblCSNO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">C SNO</asp:label></TD>
				</tr>
				<tr bgColor="#ccccff">
					<TD style="WIDTH: 10%; HEIGHT: 29px"><asp:label id="Label18" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">IE.</asp:label></TD>
					<TD style="WIDTH: 50%; HEIGHT: 29px"><asp:label id="lblIE" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"></asp:label><asp:label id="lblCCD" runat="server" Width="3%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Visible="False"></asp:label><asp:label id="lblIECD" runat="server" Width="2%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Visible="False"></asp:label></TD>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 29px"><asp:label id="Label13" runat="server" Width="64px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Book No. </asp:label>-
						<asp:label id="Label2" runat="server" Width="48px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Set No. </asp:label></TD>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 29px"><asp:label id="lblBKNO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"></asp:label>&nbsp;-
						<asp:label id="lblSetNO" runat="server" Width="61px" ForeColor="OrangeRed" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
				</tr>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 29px" align="center" colSpan="4"><asp:label id="Label3" runat="server" Width="299px" ForeColor="DarkBlue" BackColor="White"
							Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Font-Underline="True">SERIAL NUMBER(S) OF HOLOGRAM USED ON</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 29px" colSpan="4">
						<TABLE id="Table2" borderColor="#ccccff" cellSpacing="1" cellPadding="1" width="100%" border="2">
							<TR>
								<TD align="center" colSpan="2"><asp:label id="Label4" runat="server" Width="112px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="10pt" Font-Names="Verdana" Font-Underline="True">Material/Stores</asp:label></TD>
								<TD align="center" colSpan="2"><asp:label id="Label7" runat="server" Width="112px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="10pt" Font-Names="Verdana" Font-Underline="True">Samples</asp:label></TD>
								<TD align="center" colSpan="2"><asp:label id="Label10" runat="server" Width="164px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="10pt" Font-Names="Verdana" Font-Underline="True">Test Request Slip</asp:label></TD>
							</TR>
							<TR bgColor="#ffcccc">
								<TD style="WIDTH: 17%" align="center"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> From</asp:label></TD>
								<TD style="WIDTH: 16%" align="center"><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> To.</asp:label></TD>
								<TD style="WIDTH: 17%" align="center"><asp:label id="Label26" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> From</asp:label></TD>
								<TD style="WIDTH: 16%" align="center"><asp:label id="Label27" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> To.</asp:label></TD>
								<TD style="WIDTH: 17%" align="center"><asp:label id="Label8" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> From</asp:label></TD>
								<TD style="WIDTH: 16%" align="center"><asp:label id="Label9" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> To.</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 17%; HEIGHT: 25px" align="center"><asp:label id="lblReg1" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOMatFR" onblur="change(txtHGNOMatFR);check(txtHGNOMatFR,txtHGNOMatTO);"
										tabIndex="1" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
								<TD style="WIDTH: 16%; HEIGHT: 25px" align="center"><asp:label id="lblReg2" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOMatTO" onblur="change(txtHGNOMatTO);check(txtHGNOMatFR,txtHGNOMatTO);txtCopy(txtHGNOMatFR,txtHGNOMatTO);"
										tabIndex="2" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
								<TD style="WIDTH: 17%; HEIGHT: 25px" align="center"><asp:label id="lblReg3" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOSampFR" onblur="change(txtHGNOSampFR);check(txtHGNOSampFR,txtHGNOSampTO);"
										tabIndex="3" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
								<TD style="WIDTH: 16%; HEIGHT: 25px" align="center"><asp:label id="lblReg4" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOSampTO" onblur="change(txtHGNOSampTO);check(txtHGNOSampFR,txtHGNOSampTO);txtCopy(txtHGNOSampFR,txtHGNOSampTO);"
										tabIndex="4" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
								<TD style="WIDTH: 17%; HEIGHT: 25px" align="center"><asp:label id="lblReg5" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOTestFR" onblur="change(txtHGNOTestFR);check(txtHGNOTestFR,txtHGNOTestTo);"
										tabIndex="5" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
								<TD style="WIDTH: 16%; HEIGHT: 25px" align="center"><asp:label id="lblReg6" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOTestTo" onblur="change(txtHGNOTestTo);check(txtHGNOTestFR,txtHGNOTestTo);txtCopy(txtHGNOTestFR,txtHGNOTestTo);"
										tabIndex="6" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><asp:label id="Label15" runat="server" Width="112px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="10pt" Font-Names="Verdana" Font-Underline="True">IC</asp:label></TD>
								<TD align="center" colSpan="2"><asp:label id="Label20" runat="server" Width="195px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="10pt" Font-Names="Verdana" Font-Underline="True">Inspection Documents</asp:label></TD>
								<TD align="center" colSpan="2"><asp:label id="Label23" runat="server" Width="167px" ForeColor="OrangeRed" Font-Bold="True"
										Font-Size="10pt" Font-Names="Verdana" Font-Underline="True">Any Other Location</asp:label></TD>
							</TR>
							<TR bgColor="#ffcccc">
								<TD style="WIDTH: 17%" align="center"><asp:label id="Label11" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> From</asp:label></TD>
								<TD style="WIDTH: 16%" align="center"><asp:label id="Label14" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> To.</asp:label></TD>
								<TD style="WIDTH: 17%" align="center" colSpan="2"><asp:label id="Label21" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> Hologram No.</asp:label></TD>
								<TD style="WIDTH: 17%" align="center"><asp:label id="Label17" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> From</asp:label></TD>
								<TD style="WIDTH: 16%" align="center"><asp:label id="Label19" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> To.</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 17%; HEIGHT: 18px" align="center"><asp:label id="lblReg7" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOICFR" onblur="change(txtHGNOICFR);check(txtHGNOICFR,txtHGNOICTO);" tabIndex="7"
										runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
								<TD style="WIDTH: 16%; HEIGHT: 18px" align="center"><asp:label id="lblReg8" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOICTO" onblur="change(txtHGNOICTO);check(txtHGNOICFR,txtHGNOICTO);txtCopy(txtHGNOICFR,txtHGNOICTO);"
										tabIndex="8" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
								<TD style="WIDTH: 17%; HEIGHT: 18px" align="center" colSpan="2"><asp:label id="lblReg9" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOICDoc" onblur="change(txtHGNOICDoc);" tabIndex="9" runat="server" Width="25%"
										Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
								<TD style="WIDTH: 17%; HEIGHT: 18px" align="center"><asp:label id="lblReg10" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOOTFR" onblur="change(txtHGNOOTFR);check(txtHGNOOTFR,txtHGNOOTTO);" tabIndex="10"
										runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
								<TD style="WIDTH: 16%; HEIGHT: 18px" align="center"><asp:label id="lblReg11" runat="server" Width="5%" ForeColor="Red" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label><asp:textbox id="txtHGNOOTTO" onblur="change(txtHGNOOTTO);check(txtHGNOOTFR,txtHGNOOTTO);txtCopy(txtHGNOOTFR,txtHGNOOTTO);"
										tabIndex="11" runat="server" Width="50%" Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="7"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25%" align="right" bgColor="#ffcccc" colSpan="4"><asp:label id="Label22" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">If Any Other Location, Kindly Specify --></asp:label></TD>
								<TD style="WIDTH: 25%" colSpan="2"><asp:textbox id="txtOTDESC" tabIndex="12" runat="server" Width="100%" Height="20px" ForeColor="DarkBlue"
										Font-Size="8pt" Font-Names="Verdana" MaxLength="40"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.85%; HEIGHT: 29px" align="center" colSpan="4"><asp:button id="btnSave" tabIndex="22" runat="server" Width="61px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDel" tabIndex="24" runat="server" Width="58px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Delete" onclick="btnDel_Click"></asp:button><asp:button id="btnCancel" tabIndex="24" runat="server" Width="58px" ForeColor="DarkBlue" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 100%; HEIGHT: 29px" colSpan="4"><TITTLE:CUSTOMDATAGRID id="grdHG" runat="server" Width="100%" Height="8px" PageSize="15" FreezeRows="0"
							CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True"
							AutoGenerateColumns="False" GridHeight="200px" GridWidth="100%" Caption="HOLOGRAM USED ON">
							<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
							<EditItemStyle Height="10%"></EditItemStyle>
							<FooterStyle CssClass="GridHeader"></FooterStyle>
							<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
							<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
								CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink id=Hyperlink2 Text='<%# DataBinder.Eval(Container.DataItem,"REC_NO")%>' Runat="server" NavigateUrl="<%#"Hologram_Accountal_Form.aspx?CASE_NO=" + DataBinder.Eval(Container.DataItem,"CASE_NO")+ "&amp;CALL_RECV_DT=" + DataBinder.Eval(Container.DataItem,"CALL_RECV_DT")+ "&amp;CALL_SNO=" + DataBinder.Eval(Container.DataItem,"CALL_SNO")+ "&amp;CONSIGNEE_CD=" + DataBinder.Eval(Container.DataItem,"CONSIGNEE_CD")+ "&amp;REC_NO=" + DataBinder.Eval(Container.DataItem,"REC_NO")%>">
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="HG_NO_MATERIAL" HeaderText="Material">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_SAMPLE" HeaderText="Samples">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_TEST" HeaderText="Test ">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_IC" HeaderText="IC ">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_IC_DOC" HeaderText="IC Doc">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="HG_NO_OT" HeaderText="Other Location">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CASE_NO" HeaderText="Case No."></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CALL_RECV_DT" HeaderText="Call Date"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CONSIGNEE_CD" HeaderText="Consignee Cd"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CALL_SNO" HeaderText="Call Sno"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="REC_NO" HeaderText="Record No."></asp:BoundColumn>
							</Columns>
						</TITTLE:CUSTOMDATAGRID></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>TML>
