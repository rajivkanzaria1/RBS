<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab_Payment_Approve_Form.aspx.cs" Inherits="RBS.Lab_Payment_Approve_Form.Lab_Payment_Approve_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Lab_Payment_Approve_Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		function validate()
		 {		 
		   if(trimAll(document.Form1.Txt_RE.value)=="")
		   {
		     alert("REMARKS CAN NOT LEFT BLANK");
		     event.returnValue=false;
		   }
		   else if(trimAll(document.Form1.DL_status.value)=="")
		   {
		     alert("STATUS CAN NOT LEFT BLANK");
		     event.returnValue=false;
		   }
		  else 
		 return;	
		}
		
		function validate1()
		 {		 
		   if(trimAll(document.Form1.DL_status.value)=="")
		   {
		     alert("STATUS CAN NOT LEFT BLANK");
		     event.returnValue=false;
		   }
		  else 
		 return;	
		}
        </script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 25.8%"
				id="Table1" border="0" cellSpacing="1" borderColor="#b0c4de" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 17px">
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 13px" align="center">
							<P><asp:label id="Label1" runat="server" Font-Bold="True" BackColor="White" Font-Names="Verdana"
									Font-Size="10pt" ForeColor="DarkBlue" Width="264px" Height="19px">LAB SAMPLE PAYMENT RECIEPT APPROVE FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 13px" width="100%" align="center">
							<TABLE style="HEIGHT: 175px" id="Table2" border="1" cellSpacing="1" borderColor="#b0c4de"
								cellPadding="1" width="100%" bgColor="#f0f8ff" align="center">
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblCaseNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Case No.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblCasNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="90%"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblPoNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%"> Call Sno.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblPNo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="90%"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="lblPoDt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Call Recv Dt.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="lblPDt" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="90%"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 20px" width="223"><asp:label id="Label7" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%">Gross Testing Charges Submitted by LAB Official.</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 20px" colSpan="2">
										<P><asp:label id="Lbl_lab" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="90%"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px"><asp:label id="Label6" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue">Net Testing Charges Paid by Vendor.<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="2">
										<P><asp:label id="Lbl_vend" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
												ForeColor="OrangeRed" Width="90%"></asp:label></P>
									</TD>
								</TR>
        <TR>
          <TD style="WIDTH: 20%; HEIGHT: 28px">
<asp:label id=Label2 runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True">TDS Deducted by Vendor. (If Any)<font color="red" size="1">*</font> </asp:label></TD>
          <TD style="WIDTH: 80%; HEIGHT: 20px" colSpan=2>
<asp:label id=lblTDS runat="server" Width="344px" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"></asp:label></TD></TR>
        <TR>
          <TD style="WIDTH: 20%; HEIGHT: 28px">
<asp:label id=Label5 runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True">Gross Testing Charges Submitted by Vendor<font color="red" size="1">*</font> </asp:label></TD>
          <TD style="WIDTH: 80%; HEIGHT: 20px" colSpan=2>
<asp:label id=lblTotCharges runat="server" Width="344px" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"></asp:label></TD></TR>
        <TR>
          <TD style="WIDTH: 20%; HEIGHT: 28px">
<asp:label id=Label3 runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True">UTR No.<font color="red" size="1">*</font> </asp:label></TD>
          <TD style="WIDTH: 80%; HEIGHT: 20px" colSpan=2>
<asp:label id=lblUTRNo runat="server" Width="344px" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"></asp:label></TD></TR>
        <TR>
          <TD style="WIDTH: 20%; HEIGHT: 28px">
<asp:label id=Label4 runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True">UTR Date<font color="red" size="1">*</font> </asp:label></TD>
          <TD style="WIDTH: 80%; HEIGHT: 20px" colSpan=2>
<asp:label id=lblUTRDt runat="server" Width="344px" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana" Font-Bold="True"></asp:label></TD></TR>
								<TR>
									<TD style="WIDTH: 20%" align="left"><asp:label id="Label13" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True">LAB Sample Payment Reciept</asp:label></TD>
									<TD style="WIDTH: 80%" align="left"><asp:hyperlink id="HyperLink1" runat="server" Visible="False" Target="_blank">HyperLink</asp:hyperlink></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 28px"><asp:label id="Label9" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue">Status<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="WIDTH: 80%"><asp:dropdownlist id="DL_status" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="288px" AutoPostBack="True" onselectedindexchanged="DL_status_SelectedIndexChanged">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="R">Rejected With Remarks</asp:ListItem>
											<asp:ListItem Value="A">Approved</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%; HEIGHT: 31px" width="223"><asp:label id="Label_RE" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
											Font-Bold="True" Visible="False">REMARKS</asp:label></TD>
									<TD style="WIDTH: 80%; HEIGHT: 31px" colSpan="3"><asp:textbox id="Txt_RE" tabIndex="13" runat="server" Height="40px" Width="90%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="500" TextMode="MultiLine" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 20%" bgColor="white" width="233" colSpan="4" align="center"><asp:button id="btnSave" tabIndex="21" runat="server" Width="100px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True" Text="Save" Visible="False" onclick="btnSave_Click"></asp:button>
										<asp:button id="AP_BT" tabIndex="21" runat="server" Width="100px" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" Font-Bold="True" Text="Save" Visible="False" onclick="AP_BT_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
