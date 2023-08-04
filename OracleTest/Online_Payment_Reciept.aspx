<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Online_Payment_Reciept.aspx.cs" Inherits="RBS.Online_Payment_Reciept.Online_Payment_Reciept" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Online_Payment_Reciept</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css">H1 {
	FONT-FAMILY: Arial,sans-serif; MARGIN-BOTTOM: 0.1em; COLOR: #08185a; FONT-SIZE: 20pt; FONT-WEIGHT: 600
}
H2 {
	MARGIN-TOP: 0.1em; FONT-FAMILY: Arial,sans-serif; COLOR: #08185a; FONT-SIZE: 14pt; FONT-WEIGHT: 100
}
H2.co {
	MARGIN-TOP: 0.1em; FONT-FAMILY: Arial,sans-serif; MARGIN-BOTTOM: 0.1em; COLOR: #08185a; FONT-SIZE: 24pt; FONT-WEIGHT: 100
}
H3 {
	MARGIN-TOP: 0.1em; FONT-FAMILY: Arial,sans-serif; MARGIN-BOTTOM: 0.1em; COLOR: #08185a; FONT-SIZE: 16pt; FONT-WEIGHT: 100
}
H3.co {
	MARGIN-TOP: 0.1em; FONT-FAMILY: Arial,sans-serif; MARGIN-BOTTOM: 0.1em; COLOR: #ffffff; FONT-SIZE: 16pt; FONT-WEIGHT: 100
}
BODY {
	BACKGROUND-COLOR: #ffffff; FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #08185a; FONT-SIZE: 10pt
}
TH {
	PADDING-BOTTOM: 0.5em; BACKGROUND-COLOR: #ced7ef; FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #08185a; FONT-SIZE: 8pt; FONT-WEIGHT: bold; PADDING-TOP: 0.5em
}
TR {
	HEIGHT: 25px
}
.shade {
	BACKGROUND-COLOR: #ced7ef; HEIGHT: 25px
}
.title {
	BACKGROUND-COLOR: #0074c4; HEIGHT: 25px
}
TD {
	FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #08185a; FONT-SIZE: 8pt
}
TD.red {
	FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #ff0066; FONT-SIZE: 8pt
}
TD.green {
	FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #008800; FONT-SIZE: 8pt
}
P {
	FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #ffffff; FONT-SIZE: 10pt
}
P.blue {
	FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #08185a; FONT-SIZE: 7pt
}
P.red {
	FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #ff0066; FONT-SIZE: 7pt
}
P.green {
	FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #008800; FONT-SIZE: 7pt
}
DIV.bl {
	FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #0074c4; FONT-SIZE: 7pt
}
DIV.red {
	FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #ff0066; FONT-SIZE: 7pt
}
LI {
	FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #ff0066; FONT-SIZE: 8pt
}
INPUT {
	BACKGROUND-COLOR: #ced7ef; FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #08185a; FONT-SIZE: 8pt; FONT-WEIGHT: bold
}
SELECT {
	BACKGROUND-COLOR: #ced7ef; FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #08185a; FONT-SIZE: 8pt; FONT-WEIGHT: bold
}
TEXTAREA {
	SCROLLBAR-ARROW-COLOR: #08185a; BACKGROUND-COLOR: #ced7ef; SCROLLBAR-BASE-COLOR: #ced7ef; FONT-FAMILY: Verdana,Arial,sans-serif; COLOR: #08185a; FONT-SIZE: 8pt; FONT-WEIGHT: normal
}
		</style>
	</HEAD>
	<body>
		<div align="center">
			<table style="BACKGROUND-COLOR: #0074c4; WIDTH: 719px; MARGIN-LEFT: auto; MARGIN-RIGHT: auto">
				<tbody>
					<tr>
						<td>
							<h2 class="co">INTERNET BANKING</h2>
							<br>
							<h3>3-Party Transaction</h3>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
		<!-- end branding table -->
		<div style="TEXT-ALIGN: center">
			<h1>Virtual Payment Response</h1>
		</div>
		<div align="center"><asp:panel id="pnlResponse" runat="server" width="719px">
				<TABLE style="PADDING-BOTTOM: 5px; BORDER-RIGHT-WIDTH: 0px; PADDING-LEFT: 5px; WIDTH: 719px; PADDING-RIGHT: 5px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; MARGIN-LEFT: auto; BORDER-LEFT-WIDTH: 0px; MARGIN-RIGHT: auto; PADDING-TOP: 5px">
					<TR class="title">
						<TD colSpan="2">
							<P><STRONG>&nbsp;Transaction Receipt Fields</STRONG></P>
						</TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>MMP TRANSACTION: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_MMP_TRANSACTION" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>MERCHANT TRANSACTION ID: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_MERCHANT_TRANSACTION_ID" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>TRANSACTION AMOUNT: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_TRANSACTION_AMOUNT" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>PRODUCT: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_PRODUCT" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>TRANSACTION DATE: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_TRANSACTION_DATE" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>BANK TRANSACTION ID: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_BANK_TRANSACTION_ID" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>PAYMENT STATUS: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_PAYMENT_STATUS" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>BANK NAME: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_BANK_NAME" runat="server"></asp:Label></TD>
					</TR> <!--<TR>
						<TD colSpan="2">
							<DIV class="bl">Fields above are the primary request values.
								<HR>
								Fields below are receipt data fields.</DIV>
						</TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>Transaction Response Code: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_TxnResponseCode" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD><STRONG><EM>Transaction Response Code Description: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_TxnResponseCodeDesc" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>Payment Server Message: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_Message" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD><STRONG><EM>Acquirer Response Code: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_AcqResponseCode" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>Shopping Transaction Number: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_TransactionNo" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD><STRONG><EM>Receipt Number: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_ReceiptNo" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>Authorization ID: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_AuthorizeId" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD><STRONG><EM>Batch Number for this transaction: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_BatchNo" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>Card Type: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_Card" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<DIV class="bl">Fields above are for a Standard Transaction
								<HR>
								Fields below are additional fields for extra functionality.</DIV>
						</TD>
					</TR>
					<TR class="title">
						<TD colSpan="2">
							<P><STRONG>CSC Data Fields</STRONG></P>
						</TD>
					</TR>
					<TR>
						<TD><STRONG><EM>CSC Result Code: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_cscResultCode" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>CSC Result Description: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_cscResultCodeDesc" runat="server"></asp:Label></TD>
					</TR>
					<TR class="title">
						<TD colSpan="2">
							<P><STRONG>3DS Response Fields</STRONG></P>
						</TD>
					</TR>
					<TR>
						<TD><STRONG><EM>3DS ECI:</EM></STRONG></TD>
						<TD>
							<asp:Label id="Label_vpc_3DSECI" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>3DS XID:</EM></STRONG></TD>
						<TD>
							<asp:Label id="Label_vpc_3DSXID" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD><STRONG><EM>3DS Enrolled:</EM></STRONG></TD>
						<TD>
							<asp:Label id="Label_vpc_3DSenrolled" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>3DS Status:</EM></STRONG></TD>
						<TD>
							<asp:Label id="Label_vpc_3DSstatus" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD><STRONG><EM>3DS VerToken:</EM></STRONG></TD>
						<TD>
							<asp:Label id="Label_vpc_VerToken" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>3DS VerType:</EM></STRONG></TD>
						<TD>
							<asp:Label id="Label_vpc_VerType" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD><STRONG><EM>3DS VerSecurityLevel:</EM></STRONG></TD>
						<TD>
							<asp:Label id="Label_vpc_VerSecurityLevel" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>3DS VerStatus:</EM></STRONG></TD>
						<TD>
							<asp:Label id="Label_vpc_VerStatus" runat="server"></asp:Label></TD>
					</TR>
					<TR class="title">
						<TD colSpan="2">
							<P><STRONG>Risk Assessment Result Fields</STRONG></P>
						</TD>
					</TR>
					<TR>
						<TD><STRONG><EM>Risk Overall Result: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_RiskOverallResult" runat="server"></asp:Label></TD>
					</TR>
					<TR class="shade">
						<TD><STRONG><EM>Transaction Reversal Result: </EM></STRONG>
						</TD>
						<TD>
							<asp:Label id="Label_vpc_TxnReversalResult" runat="server"></asp:Label></TD>
					</TR>-->
					<TR>
						<TD height="21">
						<TD height="21"></TD>
					<TR>
						<TD height="21">
						<TD height="21"></TD>
					</TR>
				</TABLE>
			</asp:panel><asp:panel id="pnlReceiptError" runat="server" width="719px">
				<TABLE style="PADDING-BOTTOM: 5px; BORDER-RIGHT-WIDTH: 0px; PADDING-LEFT: 5px; WIDTH: 719px; PADDING-RIGHT: 5px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; MARGIN-LEFT: auto; BORDER-LEFT-WIDTH: 0px; MARGIN-RIGHT: auto; PADDING-TOP: 5px">
					<TR class="title">
						<TD colSpan="2">
							<P><STRONG>&nbsp;Error Information</STRONG></P>
						</TD>
					</TR>
					<TR>
						<TD width="149"><STRONG><EM>Error Message: </EM></STRONG>
						</TD>
						<TD width="650">
							<asp:Label id="lblReceiptErrorMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD height="21">
						<TD height="21"></TD>
					</TR>
				</TABLE>
			</asp:panel></div>
		<!--<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 22px" align="center" colSpan="6">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue" Width="80%">ONLINE PAYMENT FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 50%; HEIGHT: 162px" align="center">
						<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 70%" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD align="center">
									<asp:Label id="Label2" runat="server" ForeColor="Crimson" BackColor="White" Font-Bold="True"
										Font-Size="Large" Font-Names="Verdana">Your payment is ..</asp:Label>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center"><asp:button id="btnAdd" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue" Width="67px" Text="Home"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px">
						<P align="center">&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></TD></TR></TABLE>
		</form>-->
	</body>
</HTML>

