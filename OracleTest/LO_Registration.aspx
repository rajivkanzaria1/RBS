<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LO_Registration.aspx.cs" Inherits="RBS.LO_Registration.LO_Registration" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Clients_Registration</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		if(trimAll(document.Form1.M_NO.value)=="")
		{
		  alert("Select Mobile");
		 event.returnValue=false;
		} 
		else if(document.Form1.txtName.value=="")
		{
		alert("USER NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else  if(document.Form1.txtdesig.value=="")
		{
		 alert("DESIGNATION CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else  if(document.Form1.Txtemail.value=="")
		{
		 alert("EMAIL CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		}
		else if(trimAll(document.Form1.Txtemail.value)!="")
		{
			
			if (echeck(document.Form1.Txtemail.value)==false)
			{
				document.Form1.Txtemail.focus();
				event.returnValue=false;
			}
			else
			return;			
		}
		 else 
		return;						
	}
	
	function validate2()
	{
		if(trimAll(document.Form1.lstClientType.value)=="")
		{
		  alert("Select Client Type");
		 event.returnValue=false;
		}
		else if(trimAll(document.Form1.lstBPO_Rly.value)=="")
		{
		  alert("Select Client ");
		  event.returnValue=false;
		}
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
	
        </script>
</HEAD>
	<body bgColor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD colSpan="2">
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="Label1" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="10pt"
								Font-Bold="True" Width="100%">LO REGISTRATION</asp:label></TD>
					</TR></TD></TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><asp:label id="Label4" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" Width="100%">User Name <font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="txtName" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" Width="30%" Height="20px" MaxLength="100"></asp:textbox></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" Width="100%">Designation<font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="txtdesig" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" Width="30%" Height="20px" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><asp:label id="Label7" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" Width="100%">Email<font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><asp:textbox id="Txtemail" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" Width="30%" Height="20px" MaxLength="40"></asp:textbox></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><B><FONT face="Verdana" color="darkblue" size="2"><asp:label id="Label5" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" Width="138px">Mobile<font color="red" size="1">*</font> </asp:label></FONT></B></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><B><FONT face="Verdana" color="darkblue" size="2"></FONT></B><asp:textbox id="M_NO" style="TEXT-ALIGN: center" tabIndex="4" runat="server" ForeColor="DarkBlue"
								Font-Names="Verdana" Font-Size="8pt" Width="30%" Height="20px" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><asp:label id="lblPeriod" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" Width="100%">Period (From-To) <font color="red" size="1">*</font></asp:label></TD>
						<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><B><FONT face="Verdana" color="darkblue" size="2">From</FONT></B>
							<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
								style="TEXT-ALIGN: center" tabIndex="3" runat="server" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" Width="100px" Height="20px" MaxLength="10"></asp:textbox><B><FONT face="Verdana" color="darkblue" size="2">To</FONT></B>
							<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
								style="TEXT-ALIGN: center" tabIndex="4" runat="server" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" Width="100px" Height="20px" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 21px" align="center" colSpan="2"><asp:button id="btnSave" tabIndex="23" runat="server" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 50%" align="center" colSpan="2">
							<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 100%" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="0" bgColor="aliceblue" border="1">
								<TBODY>
									<tr>
										<td><asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
												Font-Bold="True">Client Type<font color="red" size="1">*</font> </asp:label></td>
										<TD style="WIDTH: 70%" colSpan="3"><asp:dropdownlist id="lstClientType" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Names="Verdana"
												Font-Size="8pt" Width="20%" AutoPostBack="True" onselectedindexchanged="lstClientType_SelectedIndexChanged"></asp:dropdownlist></TD>
									</tr>
									<TR>
										<TD style="WIDTH: 30%; HEIGHT: 34px"><asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Names="Verdana" Font-Size="8pt"
												Font-Bold="True">Select Client<font color="red" size="1">*</font> </asp:label></TD>
										<TD style="WIDTH: 70%; HEIGHT: 34px" colSpan="3">
											<asp:dropdownlist id="lstBPO_Rly" tabIndex="2" runat="server" Width="98%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana"></asp:dropdownlist></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 21px" align="center" colSpan="2">
							<asp:button id="btnAddRly" tabIndex="23" runat="server" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" Font-Bold="True" Text="Add Client" onclick="btnAddRly_Click"></asp:button>&nbsp;
							<asp:button id="btnNewLO" tabIndex="23" runat="server" ForeColor="DarkBlue" Font-Names="Verdana"
								Font-Size="8pt" Font-Bold="True" Width="102px" Text="Add New LO" onclick="btnNewLO_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 100%; HEIGHT: 21px" align="center" colSpan="2">
							<TITTLE:CUSTOMDATAGRID id="grdCity" runat="server" Width="100%" Height="8px" HorizontalAlign="Left" PageSize="15"
								FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0" BorderColor="DarkBlue"
								BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" AutoGenerateColumns="False" GridHeight="220px"
								GridWidth="100%">
								<PagerStyle NextPageText="Next" PrevPageText="Prev" HorizontalAlign="Center" ForeColor="Blue"
									Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%"
									ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="MOBILE" HeaderText="Mobile No.">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ORG_TYPE" HeaderText="Client Type">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ORGN_CHASED" HeaderText="Client">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form></TD></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
