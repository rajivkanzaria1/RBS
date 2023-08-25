<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qryUnInspectedQty.aspx.cs" Inherits="RBS.Query.qryUnInspectedQty" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="../WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>rptIEWiseCallDetails</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="../date.js"></script>
		<script language="javascript">
		function validate()
		{
		 if(document.Form1.txtCaseNo=="[object]" && trimAll(document.Form1.txtCaseNo.value)=="")
		 {
			alert("PLEASE ENTER CASE NUMBER!!");
			event.returnValue=false;
		 }
		 else if(document.Form1.txtCaseNo=="[object]" && trimAll(document.Form1.txtCaseNo.value)!="" && trimAll(document.Form1.txtCaseNo.value).length < 9)
		 {
			alert("PLEASE ENTER 9 CHARACTERS CASE NUMBER!!!");
			event.returnValue=false;
		 }
		 else
		 return;			 
		}
		//function txtCopy()<A HREF="http://localhost/RBS/Reports/pfrmBookSet.aspx">http://localhost/RBS/Reports/pfrmBookSet.aspx</A>
		//{
		//	if(trimAll(document.Form1.toDt.value)=="")
		//	{
		//	document.Form1.toDt.value=document.Form1.frmDt.value;
		//	}
		//}
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px" Visible="False">
				<asp:Button id="btnPrint" runat="server" Text="Print"></asp:Button>
				<INPUT id="Button1" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
			</asp:panel><asp:panel id="Panel_2" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="1px">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px"
					cellSpacing="0" cellPadding="0" border="0">
					<TR>
						<TD style="HEIGHT: 14px" align="center">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="WIDTH: 60%; HEIGHT: 149px" align="center"><B><FONT face="Verdana" color="darkblue" size="2">Case 
									Number--&gt;
									<asp:TextBox id="txtCaseNo" onblur="document.Form1.txtCaseNo.value = document.Form1.txtCaseNo.value.toUpperCase();"
										style="TEXT-ALIGN: center" tabIndex="1" runat="server" Width="108px" MaxLength="9"></asp:TextBox></FONT></B></TD>
					</TR>
					<TR bgColor="#f0f8ff">
						<TD style="HEIGHT: 23px" align="center">
							<asp:button id="btnSubmit" runat="server" Text="Submit" BackColor="#C0C0FF" ForeColor="DarkBlue"
								Font-Bold="True"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>

