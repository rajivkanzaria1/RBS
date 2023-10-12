<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_PO_Date.aspx.cs" Inherits="RBS.Edit_PO_Date.Edit_PO_Date" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Edit PO Date</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">		 
		function validate()
		{
			if(trimAll(document.Form1.txtPODay.value)=="")
			{
				alert("Plz Enter New Day of PO Date");
				event.returnValue=false;
			}
			else
			{
				
				var DateValue = trimAll(document.Form1.txtPODT.value);
				var day;
				var month;
				var year;
				var seperator = "/";
				year = DateValue.substr(6,4);
				month = DateValue.substr(3,2);
				day=document.Form1.txtPODay.value;
				document.Form1.txtNewPODT.value=day + seperator + month + seperator + year;
				
				if(check_date(document.Form1.txtNewPODT)!=true)
				{
					
					event.returnValue=false;
					
				}		
				else
				return ;
				
			}
		}
		
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 184px"
				cellSpacing="1" cellPadding="1" border="0">
				<TBODY>
					<TR>
						<TD>
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
									BackColor="White" Width="277px" Font-Bold="True" Height="19px">EDIT PURCHASE ORDER DATE FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<td style="WIDTH: 100%">
							<P align="center">
								<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 40px" borderColor="#b0c4de" cellSpacing="1"
									cellPadding="1" width="935" bgColor="#f0f8ff" border="1">
									<TR>
										<TD style="WIDTH: 10%"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Font-Bold="True">Case Number</asp:label></TD>
										<TD style="WIDTH: 17.57%" align="left"><asp:label id="lblCasNo" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Width="90%" Font-Bold="True"></asp:label></TD>
										<TD style="WIDTH: 11.92%"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Font-Bold="True">PO Date</asp:label></TD>
										<TD style="WIDTH: 0.95%"><asp:label id="lblPODate" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
												Width="184px" Font-Bold="True"></asp:label></TD>
										<TD style="WIDTH: 10%"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Font-Bold="True">New Day of PO Date</asp:label></TD>
										<TD style="WIDTH: 15%"><asp:textbox id="txtPODay" onblur="check_date(txtPODate);" tabIndex="1" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" BackColor="White" Width="20%" Height="20px" MaxLength="2"></asp:textbox></TD>
									</TR>
								</TABLE>
								<asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkMagenta"
									Width="100%" Font-Bold="True">
								To Edit PO Date --> Enter New Day Of PO Date & Click on "Update" button</asp:label></P>
							<P align="center"><asp:textbox id="txtNewPODT" onblur="check_date(txtPODate);" tabIndex="1" runat="server" Font-Names="Verdana"
									Font-Size="8pt" ForeColor="White" BackColor="White" Width="1px" Height="1px" MaxLength="2"></asp:textbox>
								<asp:textbox id="txtPODT" onblur="check_date(txtPODate);" tabIndex="1" runat="server" Font-Names="Verdana"
									Font-Size="8pt" ForeColor="White" BackColor="White" Width="1px" Height="1px" MaxLength="2"></asp:textbox></P>
						</td>
					</TR>
					<TR>
						<TD style="HEIGHT: 9px" align="center" width="100%"><asp:button id="btnSave" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								Width="92px" Font-Bold="True" Text="Update" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Width="83px" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</FORM>
	</body>
</HTML>
