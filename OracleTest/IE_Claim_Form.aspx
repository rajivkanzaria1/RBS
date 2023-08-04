<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_Claim_Form.aspx.cs" Inherits="RBS.IE_Claim_Form.IE_Claim_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>IE_Claim_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
			{
					if(document.Form1.txtCLRECDT=="[object]" && trimAll(document.Form1.txtCLRECDT.value)=="")
					{
							alert("Claim Recieve Date Should not be left blank!!!");
							event.returnValue=false;
					}
					else if(document.Form1.lstClaim_Head.value=="")
					{
						alert("Claim Head Cannot be Left Blank!!!");
						event.returnValue=false;
					}
					else if(document.Form1.lstYear.disabled=false && document.Form1.lstYear.value==document.Form1.lstYear1.value)
					{
						if(document.Form1.lstMonths.value>document.Form1.lstMonths1.value)
						{
							alert("From Month Should not be more than To Month");
							event.returnValue=false;	
						}
					}
					else if(document.Form1.lstYear.disabled=false && document.Form1.lstYear.value>document.Form1.lstYear1.value)
					{
							alert("From Year Should not be more than To Year");
							event.returnValue=false;	
					}
					else if(trimAll(document.Form1.txtAMTClaimed.value)=="")
					{
					alert("Amount Claimed cannot be left Blank!!!");
					event.returnValue=false;
					}
					else if(trimAll(document.Form1.txtAMTAdmitted.value)=="")
					{
					alert("Amount Admitted cannot be left Blank!!!");
					event.returnValue=false;
					}
					else if(trimAll(document.Form1.txtAMTClaimed.value)!="" && isNaN(parseInt(trimAll(document.Form1.txtAMTClaimed.value))))
					{
					alert("Amount Claimed Contains Invalid Characters!!!");
					event.returnValue=false;
					}
					else if(trimAll(document.Form1.txtAMTAdmitted.value)!="" && isNaN(parseInt(trimAll(document.Form1.txtAMTAdmitted.value))))
					{
					alert("Amount Admitted Contains Invalid Characters!!!");
					event.returnValue=false;
					}
					else if (document.Form1.txtNarrat.value.length > 250)
					{
						alert("Plz Enter The Remarks within 250 Characters Only!!!");
						event.returnValue=false;
					
					}

					
			}
			
			
		function amt_disallowed()
			{
				var amtadmitted=0;
				var amtclaimed=0;
				amtclaimed=parseFloat(trimAll(document.Form1.txtAMTClaimed.value));
				amtadmitted=parseFloat(trimAll(document.Form1.txtAMTAdmitted.value));
				document.Form1.txtAMTDisallowed.value=amtclaimed-amtadmitted;
			}
        </script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center" colSpan="5">
						<P><asp:label id="Label1" runat="server" Width="196px" ForeColor="DarkBlue" BackColor="White"
								Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">IE CLAIM FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="left">
						<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="1"
							cellPadding="1" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 15%; HEIGHT: 19px" vAlign="top"></TD>
								<TD style="WIDTH: 17.68%; HEIGHT: 19px" vAlign="top"></TD>
								<TD style="WIDTH: 15%; HEIGHT: 19px" vAlign="top" align="left"><asp:label id="Label2" runat="server" Width="64px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> Claim No.</asp:label></TD>
								<TD style="WIDTH: 15.88%; HEIGHT: 19px" vAlign="top"><asp:label id="lblCNo" runat="server" Width="60%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label></TD>
								<TD style="WIDTH: 5.76%; HEIGHT: 19px" vAlign="top"></TD>
								<TD style="WIDTH: 40%; HEIGHT: 19px" vAlign="top"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 15%; HEIGHT: 25px" vAlign="top"><asp:label id="Label6" runat="server" Width="80px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Claim Date.</asp:label></TD>
								<TD style="WIDTH: 17.68%; HEIGHT: 25px" vAlign="top"><asp:label id="lblCDT" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"></asp:label></TD>
								<TD style="WIDTH: 15%; HEIGHT: 25px" vAlign="top" align="left"><asp:label id="Label8" runat="server" Width="96px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Claim Recieve Date.</asp:label></TD>
								<TD style="WIDTH: 15.88%; HEIGHT: 25px" vAlign="top">
									<P><asp:textbox id="txtCLRECDT" onblur="check_date(txtCLRECDT);" tabIndex="1" runat="server" Width="90%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="11"></asp:textbox><asp:label id="lblRDT" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana"></asp:label></P>
								</TD>
								<TD style="WIDTH: 5.76%; HEIGHT: 25px" vAlign="top"><asp:label id="Label10" runat="server" Width="32px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana"> IE</asp:label></TD>
								<TD style="WIDTH: 40%; HEIGHT: 25px" vAlign="top"><P><asp:dropdownlist id="lstIE" tabIndex="3" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"></asp:dropdownlist><asp:label id="lblIE" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 15%" vAlign="top"><asp:label id="Label15" runat="server" Width="32px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">From</asp:label></TD>
								<TD style="WIDTH: 17.68%" vAlign="top"><asp:label id="Label17" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Month</asp:label><asp:dropdownlist id="lstMonths" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										tabIndex="4">
										<asp:ListItem Value="01" Selected="True">January</asp:ListItem>
										<asp:ListItem Value="02">February</asp:ListItem>
										<asp:ListItem Value="03">March</asp:ListItem>
										<asp:ListItem Value="04">April</asp:ListItem>
										<asp:ListItem Value="05">May</asp:ListItem>
										<asp:ListItem Value="06">June</asp:ListItem>
										<asp:ListItem Value="07">July</asp:ListItem>
										<asp:ListItem Value="08">August</asp:ListItem>
										<asp:ListItem Value="09">September</asp:ListItem>
										<asp:ListItem Value="10">October</asp:ListItem>
										<asp:ListItem Value="11">November</asp:ListItem>
										<asp:ListItem Value="12">December</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="WIDTH: 15%; HEIGHT: 9px" vAlign="top" align="left"><asp:label id="Label18" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Year</asp:label><asp:dropdownlist id="lstYear" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										tabIndex="5"></asp:dropdownlist></TD>
								<TD style="WIDTH: 15.88%; HEIGHT: 9px" vAlign="top"><asp:label id="Label16" runat="server" Width="16px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">To</asp:label></TD>
								<TD style="WIDTH: 5.76%; HEIGHT: 9px" vAlign="top"><asp:label id="Label22" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Month</asp:label><asp:dropdownlist id="lstMonths1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										tabIndex="6">
										<asp:ListItem Value="01" Selected="True">January</asp:ListItem>
										<asp:ListItem Value="02">February</asp:ListItem>
										<asp:ListItem Value="03">March</asp:ListItem>
										<asp:ListItem Value="04">April</asp:ListItem>
										<asp:ListItem Value="05">May</asp:ListItem>
										<asp:ListItem Value="06">June</asp:ListItem>
										<asp:ListItem Value="07">July</asp:ListItem>
										<asp:ListItem Value="08">August</asp:ListItem>
										<asp:ListItem Value="09">September</asp:ListItem>
										<asp:ListItem Value="10">October</asp:ListItem>
										<asp:ListItem Value="11">November</asp:ListItem>
										<asp:ListItem Value="12">December</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="WIDTH: 40%; HEIGHT: 9px" vAlign="top"><asp:label id="Label21" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
										Font-Names="Verdana">Year</asp:label><asp:dropdownlist id="lstYear1" runat="server" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"
										tabIndex="7"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align=center>
							<TABLE id="Table5" style="WIDTH: 711px; POSITION: relative; TOP: 0px; HEIGHT: 122px" borderColor="#b0c4de"
								cellSpacing="1" cellPadding="1" width="711" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 19.48%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">Claim Head</asp:label></P>
									</TD>
									<TD style="WIDTH: 20.28%; HEIGHT: 20px" align="center">
										<asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">Amount Claimed</asp:label></TD>
									<TD style="WIDTH: 18.97%; HEIGHT: 20px" align="center">
										<asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">Amount Admitted</asp:label></TD>
									<TD style="WIDTH: 17.21%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="100%">Amount Disallowed</asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 19.48%; HEIGHT: 24px" align="center">
										<asp:dropdownlist id="lstClaim_Head" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="100%"></asp:dropdownlist></TD>
									<TD style="WIDTH: 20.28%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtAMTClaimed" style="TEXT-ALIGN: center" tabIndex="9" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="95%" MaxLength="13" Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 18.97%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtAMTAdmitted" onblur="amt_disallowed();" style="TEXT-ALIGN: center" tabIndex="10"
											runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="95%" MaxLength="13"
											Height="20px"></asp:textbox></TD>
									<TD style="WIDTH: 17.21%; HEIGHT: 24px" align="center">
										<asp:textbox id="txtAMTDisallowed" style="TEXT-ALIGN: center" tabIndex="11" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="95%" MaxLength="13" Height="20px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 28.38%; HEIGHT: 20px" align="right">
										<asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="72px">Remarks</asp:label></TD>
									<TD style="WIDTH: 39.93%; HEIGHT: 38px" vAlign="top" align="center" colSpan="3">
										<asp:textbox id="txtNarrat" style="TEXT-ALIGN: center" tabIndex="12" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="100%" MaxLength="50" Height="30px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 594px" align="center" colSpan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="btnSave" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="66px" Text="Save" onclick="btnSave_Click"></asp:button>
										<asp:button id="btnCancel" tabIndex="15" runat="server" Font-Names="Verdana" Font-Size="8pt"
											Font-Bold="True" ForeColor="DarkBlue" Width="67px" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
								</TR>
							</TABLE>
							<P>&nbsp;</P>
						
						<DIV><TITTLE:CUSTOMDATAGRID id="grdVDt" runat="server" Width="100%" Height="8px" BorderColor="DarkBlue" AutoGenerateColumns="False"
								PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid" AddEmptyHeaders="0"
								BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="150px" GridWidth="100%">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
									CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn Visible="False" HeaderText="Claim Head">
										<HeaderStyle Width="4%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id=HyperLink1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CLAIM_HEAD")%>' NavigateUrl='<%#"IE_Claim_Form.aspx?CLAIM_NO=" + DataBinder.Eval(Container.DataItem,"CLAIM_NO") + "&amp;ACTION=M" + "&amp;CLAIM_HEAD=" + DataBinder.Eval(Container.DataItem,"CLAIM_HEAD")%>'>HyperLink</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="CLAIM_HEAD" HeaderText="Claim Head">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMT_CLAIMED" HeaderText="Amount Claimed">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMT_ADMITTED" HeaderText="Amount Admitted">
										<HeaderStyle Width="14%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMT_DISALLOWED" HeaderText="Amount Disallowed">
										<HeaderStyle Width="18%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REMARKS" HeaderText="Remarks">
										<HeaderStyle Width="13%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CLAIM_NO" HeaderText="Claim No"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
				<TR>
					<TD><asp:panel id="Panel1" runat="server" Height="134px" HorizontalAlign="Center">
      <TABLE id=Table6 style="WIDTH: 100%; HEIGHT: 32px" borderColor=#b0c4de 
      cellSpacing=1 cellPadding=1 bgColor=#f0f8ff border=1>
        <TR>
          <TD style="WIDTH: 23%; HEIGHT: 19px" vAlign=top>
<asp:label id=Label9 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="100%">Payment Voucher No.</asp:label></TD>
          <TD style="WIDTH: 15%; HEIGHT: 19px" vAlign=top>
<asp:textbox id=txtPVCHRNO onblur=amt_disallowed(); style="TEXT-ALIGN: center" tabIndex=16 runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="80%" MaxLength="4" Height="20px"></asp:textbox></TD>
          <TD style="WIDTH: 23%; HEIGHT: 19px" vAlign=top>
<asp:label id=Label12 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="100%">Payment Voucher Date.</asp:label></TD>
          <TD style="WIDTH: 15%; HEIGHT: 19px" vAlign=top>
<asp:textbox id=txtPVCHRDT onblur=check_date(txtPVCHRDT); tabIndex=17 runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="90%" MaxLength="11" Height="20px"></asp:textbox></TD>
          <TD style="WIDTH: 24%; HEIGHT: 19px" vAlign=top>
<asp:button id=btnSPDetails tabIndex=18 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="100%" Text="Save Payment Details" onclick="btnSPDetails_Click"></asp:button></TD></TR></TABLE></asp:panel>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
