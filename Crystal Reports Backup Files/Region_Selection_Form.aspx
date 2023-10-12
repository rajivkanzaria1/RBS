<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Region_Selection_Form.aspx.cs" Inherits="RBS.Region_Selection_Form.Region_Selection_Form" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Region_Selection_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		function validate()
		{		
			if(document.Form1.rdbNR.checked==false && document.Form1.rdbER.checked==false && document.Form1.rdbWR.checked==false && document.Form1.rdbSR.checked==false && document.Form1.rdbCR.checked==false && document.Form1.rdbQA.checked==false)
			{
				alert("SELECT ONE OF THE GIVEN REGIONS");
				event.returnValue=false;
			}
			else 
			return;
		}
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 100%"
				borderColor="black" cellSpacing="0" cellPadding="0" border="0">
				<TBODY>
					<TR height="100%" align="center">
						<td align="center" vAlign="middle">
							<TABLE id="Table41" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 50%; HEIGHT: 50%" borderColor="royalblue"
								cellPadding="0" bgColor="#dcebf9" border="1">
								<TR>
									<TD style="HEIGHT: 21.25%" align="center" colSpan="2">
										<asp:Label id="Label1" runat="server" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True"
											ForeColor="Red">DASHBOARD</asp:Label><A href="/rbs/Reports/pfrmDashboard.aspx"> <font color="darkblue">
												<u>(Click Here)</u></font></A></TD>
								</TR>
								<TR height="10%">
									<TD align="center" colSpan="2" style="HEIGHT: 23%">
										<P style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: navy; FONT-FAMILY: Verdana; TEXT-DECORATION: underline">SELECT 
											THE REGION IN WHICH YOU WANT TO LOGIN</P>
									</TD>
								</TR>
								<TR>
									<TD>&nbsp;
										<asp:RadioButton id="rdbNR" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
											ForeColor="RoyalBlue" Text="Northern Region" GroupName="g1"></asp:RadioButton></TD>
									<TD>&nbsp;
										<asp:RadioButton id="rdbSR" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
											ForeColor="RoyalBlue" Text="Southern Region" GroupName="g1"></asp:RadioButton></TD>
								<TR>
									<TD>&nbsp;
										<asp:RadioButton id="rdbER" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
											ForeColor="RoyalBlue" Text="Eastern Region" GroupName="g1"></asp:RadioButton></TD>
									<TD>&nbsp;
										<asp:RadioButton id="rdbWR" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
											ForeColor="RoyalBlue" Text="Western Region" GroupName="g1"></asp:RadioButton></TD>
								</TR>
								<TR>
									<TD>&nbsp;
										<asp:RadioButton id="rdbCR" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
											ForeColor="RoyalBlue" Text="Central Region" GroupName="g1"></asp:RadioButton></TD>
									<TD>&nbsp;
										<asp:RadioButton id="rdbQA" runat="server" GroupName="g1" Text="CO QA Division" ForeColor="RoyalBlue"
											Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"></asp:RadioButton></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:Button id="btnSubmit" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Submit" onclick="btnSubmit_Click"></asp:Button></TD>
								</TR>
							</TABLE>
							&nbsp;
						</td>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
