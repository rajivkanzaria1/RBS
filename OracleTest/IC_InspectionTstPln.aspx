<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IC_InspectionTstPln.aspx.cs" Inherits="RBS.IC_InspectionTstPln.IC_InspectionTstPln" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<%@ Register TagPrefix="uc2" TagName="UCWeldingcables" Src="ProductPage/UCWeldingcables.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Calls_Marked_To_IE</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">
        .ErrorControl { BORDER-RIGHT: red 1px solid; BORDER-TOP: red 1px solid; BORDER-LEFT: red 1px solid; COLOR: #fbe3e4; BORDER-BOTTOM: red 1px solid }
		</style>
	</HEAD>
	<body>
		<form id="form1" runat="server">
			<table id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px" cellspacing="1" cellpadding="1"
				width="100%" border="0">
				<tr>
					<td style="HEIGHT: 45px" align="center">
						<p>
							<uc1:WebUserControl1 ID="WebUserControl11" runat="server"></uc1:WebUserControl1>
						</p>
					</td>
				</tr>
				<tr>
					<td align="center">
						<table id="Table2" cellspacing="0" cellpadding="1" width="97%" border="0" bordercolor="lightsteelblue">
							<tr>
								<td width="20%" style="HEIGHT: 20px"></td>
								<td align="center" width="60%" style="HEIGHT: 20px">
									<asp:Label ID="Label1" runat="server" Width="277px" BackColor="White" Font-Names="Verdana"
										Font-Size="10pt" ForeColor="DarkBlue" Font-Bold="True">
										<u>INSPECTION & TEST PLAN</u>
										<br />
										<asp:Literal runat="server" ID="litData"></asp:Literal>
									</asp:Label>
								</td>
								<td align="right" width="20%" style="HEIGHT: 20px"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center">
					
						<asp:PlaceHolder runat="server" ID="phUserInfoBox"></asp:PlaceHolder>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
