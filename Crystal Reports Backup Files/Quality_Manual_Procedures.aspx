<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quality_Manual_Procedures.aspx.cs" Inherits="RBS.Quality_Manual_Procedures.Quality_Manual_Procedures" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Quality_Manual_Procedures</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 100%; TOP: 8px; LEFT: 8px"
				borderColor="black" cellSpacing="0" cellPadding="0" border="0">
				<TBODY>
					<TR>
						<TD vAlign="middle" align="center">
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></TD>
					</TR>
					<TR height="100%" align="center">
						<td align="center" vAlign="middle">
							<TABLE id="Table2" style="Z-INDEX: 101; WIDTH: 50%; HEIGHT: 30%; LEFT: 8px" borderColor="royalblue"
								cellPadding="0" bgColor="#dcebf9" border="1">
								<TR height="10%">
									<TD align="center" colSpan="2" style="HEIGHT: 40px">
										<P style="FONT-FAMILY: Verdana; COLOR: navy; FONT-SIZE: 10pt; FONT-WEIGHT: bold; TEXT-DECORATION: underline">QUALITY 
											MANUAL &amp; PROCEDURES</P>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 40px" colSpan="2">&nbsp;&nbsp;&nbsp; <IMG id="BArrow1" src="\RBS\images\BArrow.gif">&nbsp;
										<asp:hyperlink id="HyperLinkNR" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
											ForeColor="RoyalBlue" NavigateUrl="http://ritesltd.com/upload/misc/ISO/QA_ISO_Manual.pdf" Height="20px">Quality Manual</asp:hyperlink>&nbsp;&nbsp;</TD>
								<TR>
									<TD colSpan="2" style="HEIGHT: 40px">&nbsp;&nbsp;&nbsp; <IMG id="Img1" src="\RBS\images\BArrow.gif">&nbsp;
										<asp:hyperlink id="Hyperlink1" runat="server" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"
											ForeColor="RoyalBlue" NavigateUrl="http://ritesltd.com/upload/misc/QA_Q.Procedure/1.List%20of%20Procedures.docx"
											Height="20px">Quality Procedures</asp:hyperlink>&nbsp;&nbsp;
										<asp:Label id="Label2" runat="server" Font-Size="7pt" Font-Names="Verdana" ForeColor="DarkBlue"
											Height="20px">(PWD: qa_proc@)</asp:Label></TD>
								</TR>
							</TABLE>
						</td>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>

