<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="RBS.Email.Email" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>FEEDBACK</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="JavaScript">
			
		function validate()
		{
			if(document.Form1.txtSubject.value=="")
			{
				alert("SUBJECT CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.txtBody.value=="")
			{
				alert("DESCRIPTION CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.txtNameofComp.value=="")
			{
				alert("NAME OF COMPLAINANT CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.txtMobofComp.value=="")
			{
				alert("MOBILE NO OF COMPLAINANT CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.txtFrom.value)!="")
			{
				if (echeck(document.Form1.txtFrom.value)==false)
				{
					document.Form1.txtFrom.focus();
					event.returnValue=false;
				}
				else
				return;
			}
			else
			{
				//document.Form1.btnSubmit.style.visibility = 'hidden';
				alert("FROM CANNOT BE LEFT BLANK");
				event.returnValue=false;
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
		if (str.indexOf(at)==-1)
		{
		   alert("Invalid From E-mail ID");
		   return false;
		}

		if (str.indexOf(at)==-1 || str.indexOf(at)==0 || str.indexOf(at)==lstr)
		{
		   alert("Invalid From E-mail ID");
		   return false;
		}

		if (str.indexOf(dot)==-1 || str.indexOf(dot)==0 || str.indexOf(dot)==lstr)
		{
		    alert("Invalid From E-mail ID");
		    return false;
		}

		 if (str.indexOf(at,(lat+1))!=-1)
		 {
		    alert("Invalid From E-mail ID");
		    return false;
		 }

		 if (str.substring(lat-1,lat)==dot || str.substring(lat+1,lat+2)==dot)
		 {
		    alert("Invalid From E-mail ID");
		    return false;
		 }

		 if (str.indexOf(dot,(lat+2))==-1)
		 {
		    alert("Invalid From E-mail ID");
		    return false;
		 }
		
		 if (str.indexOf(" ")!=-1)
		 {
		    alert("Invalid From E-mail ID");
		    return false;
		 }

 		 return true;					
	}

        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<br>
			<div><br>
				<table style="WIDTH: 90%; HEIGHT: 80%" borderColor="#0099ff" cellSpacing="1" cellPadding="5"
					width="842" align="center" bgColor="#cccccc" border="1">
					<TR>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 10%"
							align="center" colSpan="2"><asp:label id="Label1" runat="server" Height="27px" Width="415px" BackColor="White" Font-Bold="True"
								Font-Names="Verdana" Font-Size="14pt" ForeColor="DarkBlue"> FEEDBACK & SUGGESTION CORNER</asp:label></TD>
					</TR>
					<tr>
						<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 228px; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 10%"
							align="right" bgColor="#eeeeee">&nbsp;To Region</td>
						<td bgColor="#ffffff"><asp:dropdownlist id="lstRegionCd" tabIndex="4" runat="server" Width="152px" Font-Bold="True" Font-Names="Verdana"
								Font-Size="8pt" ForeColor="DarkBlue" AutoPostBack="True">
								<asp:ListItem></asp:ListItem>
								<asp:ListItem Value="N">NORTHERN REGION</asp:ListItem>
								<asp:ListItem Value="E">EASTERN REGION</asp:ListItem>
								<asp:ListItem Value="W">WESTERN REGION</asp:ListItem>
								<asp:ListItem Value="S">SOUTHERN REGION</asp:ListItem>
								<asp:ListItem Value="C">CENTRAL REGION</asp:ListItem>
								<asp:ListItem Value="Q">CO QA DIVISION</asp:ListItem>
							</asp:dropdownlist></td>
					</tr>
					<tr>
						<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 228px; COLOR: darkblue; FONT-FAMILY: Verdana"
							align="right" bgColor="#eeeeee">&nbsp;From Email
							<asp:label id="Label4" runat="server" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
								Font-Bold="True" Height="13px"> *</asp:label></td>
						<td bgColor="#ffffff"><asp:textbox id="txtFrom" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								Columns="50"></asp:textbox></td>
					</tr>
					<tr>
						<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 228px; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 10%"
							align="right" bgColor="#eeeeee">&nbsp;Subject</td>
						<td style="HEIGHT: 19px" bgColor="#ffffff"><asp:textbox id="txtSubject" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								Columns="50"></asp:textbox></td>
					</tr>
					<tr>
						<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 228px; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 50%"
							vAlign="middle" align="right" bgColor="#eeeeee">&nbsp;Description
							<asp:label id="Label32" runat="server" Height="13px" Font-Bold="True" Font-Names="Verdana"
								Font-Size="8pt" ForeColor="OrangeRed"> *(Max 500 Chars)</asp:label></td>
						<td bgColor="#ffffff"><asp:textbox id="txtBody" runat="server" Height="90%" Width="100%" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Columns="40" MaxLength="500" TextMode="MultiLine"></asp:textbox></td>
					</tr>
					<TR>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 228px; COLOR: darkblue; FONT-FAMILY: Verdana"
							align="right" bgColor="#eeeeee">Name
							<asp:label id="Label2" runat="server" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
								Font-Bold="True" Height="13px"> *</asp:label></TD>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue" align="left" bgColor="#eeeeee"><asp:textbox id="txtNameofComp" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								Columns="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 228px; COLOR: darkblue; FONT-FAMILY: Verdana"
							align="right" bgColor="#eeeeee">Mobile No.
							<asp:label id="Label3" runat="server" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana"
								Font-Bold="True" Height="13px"> *</asp:label></TD>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue" align="left" bgColor="#eeeeee"><asp:textbox id="txtMobofComp" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								Columns="50"></asp:textbox></TD>
					</TR>
					<tr>
						<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana"
							align="center" bgColor="#eeeeee" colSpan="2"><asp:button id="btnSubmit" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Text="Submit" onclick="btnSubmit_Click"></asp:button></td>
					</tr>
					<tr>
						<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: crimson; FONT-FAMILY: Verdana"
							align="center" bgColor="#eeeeee" colSpan="2"><asp:literal id="litStatus" runat="server"></asp:literal></td>
					</tr>
				</table>
				<br>
				<br>
				<br>
				<br>
			</div>
		</form>
	</body>
</HTML>

