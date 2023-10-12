<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Allow_Old_Bill_Date_Form.aspx.cs" Inherits="RBS.Allow_Old_Bill_Date_Form" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Allow Old Bill Date Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		
		if(document.Form1.lstAllowOldBillDT.value=="N")
		{
			if(trimAll(document.Form1.txtNoOfGraceDays.value)=="")
			{
				alert("ENTER NO. OF GRACE DAYS!!!");
				event.returnValue=false;
			} 
			else if(trimAll(document.Form1.txtNoOfGraceDays.value)!="" && IsNumeric(document.Form1.txtNoOfGraceDays.value)==false)
			{
				alert("ENTER NO. OF GRACE DAYS IN NUMERIC ONLY!!!");
				event.returnValue=false;
			}
		}
		
		 return;
		}
				
		
		
        </script>
	</HEAD>
	<body bgColor="#ffffff" onload="javascript:document.Form1.txtSDesc.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 711px; POSITION: absolute; TOP: 8px; HEIGHT: 192px"
				cellSpacing="1" cellPadding="1" width="711" border="0">
				<TR>
					<TD>
						<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" style="HEIGHT: 26px">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="DarkBlue"
								BackColor="White" Width="260px" Font-Bold="True">ALLOW OLD BILL DATE FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<TABLE id="Table2" style="WIDTH: 367px; HEIGHT: 58px" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="1" width="367" align="center" bgColor="#f0f8ff" border="1">
								<TR align="center">
									<TD align="center" colSpan="1" rowSpan="1" style="WIDTH: 170px"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Font-Bold="True"> Allow Old Bill Date(Y/N)</asp:label></TD>
									<TD align="left">
										<asp:DropDownList id="lstAllowOldBillDT" runat="server" Width="40%" tabIndex="1"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 170px" align="center">
										<asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">No. Of Grace Days</asp:label></TD>
									<TD>
										<asp:TextBox id="txtNoOfGraceDays" tabIndex="2" runat="server" Width="50px" MaxLength="1"></asp:TextBox></TD>
								</TR>
							</TABLE>
							<asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkMagenta"
								Width="100%" Font-Bold="True">* To Modify Fill Values and Click on Save</asp:label>
							<asp:label id="Label5" runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta"
								Font-Size="8pt" Font-Names="Verdana">* In case of you don't Allow Old Bill Date, Enter The No. Of Grace Days.</asp:label>
						</P>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSave" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
							Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Width="72px" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

