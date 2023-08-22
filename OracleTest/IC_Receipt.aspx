<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IC_Receipt.aspx.cs" Inherits="RBS.IC_Receipt.IC_Receipt" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>IC RECIEPT FORM</title>
		<style type="text/css">.MyDataGridCaption { FONT-WEIGHT: bold; COLOR: red; etc: }
	</style>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">		 
		function search()
		{
		 if(trimAll(document.Form1.txtBKNo.value)=="" && trimAll(document.Form1.txtSetNo.value)=="" && document.Form1.ddlIE.value==""  && document.Form1.txtICDT.value=="")
		 {
			alert("Enter either of BOOK NO./SET NO./IE TO WHOM ISSUED/IC SUBMISSION DATE to search the data!!!");
			event.returnValue=false;
		 }
		 	
		 return;			 
		}
		function validate()
		{
		
		 if(trimAll(document.Form1.txtBKNo.value)=="")
		 {
			
			alert("Book No. Missing !!!");
			event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtSetNo.value)=="")
		 {
			
			alert("Set No. Missing!!!");
			event.returnValue=false;
		 }
		 else if(document.Form1.ddlIE.value=="")
		 {
			alert("IE Name Missing !!!");
			event.returnValue=false;
		 }
		 else if(document.Form1.txtICDT.value=="")
		 {
			alert("IC Submission Date Missing !!!");
			event.returnValue=false;
		 }
		 return;			 
		}
		
		function rep_validate()
		{
			if(trimAll(document.Form1.txtRDT.value)=="")
			{
				alert("Enter Period upto which the [Un-Billed IC] report is desired!!!");
				event.returnValue=false;
			}
		 }
		function makeUppercase()
		 {
			document.Form1.txtBKNo.value = document.Form1.txtBKNo.value.toUpperCase();
		 }
		function change()
		{
			var d=document.Form1.txtSetNo.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="00" + d;
				document.Form1.txtSetNo.value=d;
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="0" + d;
				document.Form1.txtSetNo.value=d;
				event.returnValue=false;
			}
			else
			return false;	
		}
        </script>
</HEAD>
	<body onload="javascript:document.Form1.txtBKNo.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
					</TR>
					<TR align="center">
						<TD><FONT color="#3300cc"><FONT face="Arial" color="#000099" size="2"><STRONG>RECEIPT OF BOOK 
										SET IN INSPECTION OFFICE</STRONG></FONT></FONT></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 108px">
							<P align="center">
								<TABLE id="Table2" style="HEIGHT: 52px" borderColor="#bfcbe3" cellSpacing="1" cellPadding="1"
									width="70%" bgColor="#f0f8ff" border="1">
									<TBODY>
										<TR align="center">
											<TD style="WIDTH: 9.77%; HEIGHT: 17px"><FONT face="Verdana" color="#000099" size="2"><STRONG>Book 
														No.</STRONG></FONT></TD>
											<TD style="WIDTH: 6.39%; HEIGHT: 17px"><FONT face="Verdana" color="#000099" size="2"><STRONG>Set 
														No.</STRONG></FONT></TD>
											<TD style="HEIGHT: 55%"><STRONG><FONT face="Verdana" color="#000099" size="2">IE To Whom 
														Issued</FONT></STRONG></TD>
											<TD style="HEIGHT: 25%"><STRONG><FONT face="Verdana" color="#000099" size="2">IC Submission 
														Date in RITES</FONT></STRONG></TD>
										</TR>
										<TR align="center">
											<TD style="WIDTH: 9.77%" align="center"><asp:textbox id="txtBKNo" onblur="makeUppercase();" style="TEXT-ALIGN: center" tabIndex="1" runat="server"
													Font-Size="8pt" ForeColor="DarkBlue" Width="73px"></asp:textbox></TD>
											<TD style="WIDTH: 6.39%" align="center"><asp:textbox id="txtSetNo" onblur="change();" style="TEXT-ALIGN: center" tabIndex="2" runat="server"
													Font-Size="8pt" ForeColor="DarkBlue" Width="65px"></asp:textbox></TD>
											<TD style="WIDTH: 55%" align="center"><asp:dropdownlist id="ddlIE" tabIndex="3" runat="server" Font-Size="8pt" ForeColor="DarkBlue" Font-Names="Verdana"
													Height="35px" Width="100%"></asp:dropdownlist></TD>
											<TD style="WIDTH: 25%" align="center"><asp:textbox id="txtICDT" onblur="check_date(txtICDT);" style="TEXT-ALIGN: center" tabIndex="4"
													runat="server" Font-Size="8pt" ForeColor="DarkBlue" Font-Names="Verdana" Height="20px" MaxLength="10" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 9.77%" align="center" colSpan="3"><STRONG><FONT face="Verdana" color="#000099" size="2">Remarks</FONT></STRONG></TD>
											<TD style="WIDTH: 25%" align="center"><STRONG><FONT face="Verdana" color="#000099" size="2">Remarks 
														date</FONT></STRONG></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 9.77%" align="center" colSpan="3">
												<asp:textbox id="txtRemarks" tabIndex="5" runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt"
													Height="20px" Font-Names="Verdana" MaxLength="50"></asp:textbox></TD>
											<TD style="WIDTH: 25%" align="center">
												<asp:textbox id="txtRemarksDT" onblur="check_date(txtRemarksDT);" tabIndex="6" runat="server"
													Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Height="20px" Font-Names="Verdana" MaxLength="50"></asp:textbox></TD>
										</TR>
									</TBODY>
								</TABLE>
								<asp:label id="Label1" runat="server" Font-Size="7.8pt" ForeColor="DarkMagenta" Font-Names="Verdana"
									Width="607px" Font-Bold="True"> To Search/Modify/Delete Book Set -> Enter Book No. & Set No /Inspection Engineer and click on [Search] button and then select the desired item.</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 24px" align="center"><FONT face="Verdana" color="#0033ff" size="2"><STRONG>
									IC's Received but not Billed As on :&nbsp;
									<asp:textbox id="txtRDT" onblur="check_date(txtRDT);" style="TEXT-ALIGN: center" tabIndex="13"
										runat="server" ForeColor="DarkBlue" Font-Size="8pt" Height="20px" Font-Names="Verdana" MaxLength="10"
										Width="104px"></asp:textbox></STRONG></FONT></TD>
					</TR>
					<TR align="center">
						<TD style="HEIGHT: 33px"><asp:button id="btnSave" tabIndex="7" runat="server" Font-Size="8pt" ForeColor="DarkBlue" Font-Names="Verdana"
								Width="57px" Font-Bold="True" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="8" runat="server" Font-Size="8pt" ForeColor="DarkBlue"
								Font-Names="Verdana" Width="57px" Font-Bold="True" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnSearch" tabIndex="9" runat="server" Font-Size="8pt" ForeColor="DarkBlue"
								Font-Names="Verdana" Width="66px" Font-Bold="True" Text="Search" onclick="btnSearch_Click"></asp:button><asp:button id="btnCancel" tabIndex="10" runat="server" Font-Size="8pt" ForeColor="DarkBlue"
								Font-Names="Verdana" Width="62px" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button>
							<asp:button id="btnReport" tabIndex="11" runat="server" Width="179px" ForeColor="#0033FF" Font-Size="8pt"
								Font-Names="Verdana" Font-Bold="True" Text="Statement of Unbilled IC's" onclick="btnReport_Click"></asp:button>
							<asp:button id="btnIssuedNRec" tabIndex="12" runat="server" Width="300px" ForeColor="#0033FF"
								Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Text="Statement of IC's Issued but not Received" onclick="btnIssuedNRec_Click"></asp:button>
							<asp:button id="btnStatus_IC" tabIndex="13" runat="server" Width="106px" ForeColor="#0033FF"
								Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Text="Status of IC's" onclick="btnStatus_IC_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center"><asp:datagrid id="grdBook" runat="server" Font-Size="8pt" Font-Names="Verdana" Height="96px" Width="100%"
								Caption="UN-BILLED  INSPECTION CERTIFICATES" AutoGenerateColumns="False" BorderStyle="Groove" BorderColor="DarkBlue">
								<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
									VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:HyperLink id="Hyperlink2" NavigateUrl="<%#"IC_Receipt.aspx?BK_NO=" + DataBinder.Eval(Container.DataItem,"BK_NO") + "&amp;SET_NO=" + DataBinder.Eval(Container.DataItem,"SET_NO")%>" Runat="server">Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="BK_NO" HeaderText="Book No."></asp:BoundColumn>
									<asp:BoundColumn DataField="SET_NO" HeaderText="Set No. "></asp:BoundColumn>
									<asp:BoundColumn DataField="IE_NAME" HeaderText="IE to Whom Issued"></asp:BoundColumn>
									<asp:BoundColumn DataField="IC_SUBMIT_DT" HeaderText="IC Submision Date"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form></TD></TR></TBODY>
		<P></P></TR></TBODY></TABLE></FORM>
		<P></P></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
