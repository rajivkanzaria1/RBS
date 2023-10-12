<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterUnit_Reciept.aspx.cs" Inherits="RBS.InterUnit_Reciept.InterUnit_Reciept" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Voucher Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		
		 function validate1()
		{
		 if(document.Form1.txtCSNO!="[object]" && trimAll(document.Form1.txtBPO.value)=="")
		{
		 alert("ENTER BPO CODE OR 1ST Few CHARACTERS OF BPO NAME AND THEN CLICK ON SELECT BPO BUTTON");
		 event.returnValue=false;
		 }
		  else
		 return;

		}
		
		function validate()
		{
		 if(trimAll(document.Form1.txtCNO.value)=="")
		 {
		 alert("Cheque No. Cannot Be Left Blank!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtCDT.value)=="")
		 {
		 alert("Cheque Date. Cannot Be Left Blank!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtAmt.value)=="")
		 {
		 alert("Amount Cannot Be Left Blank!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtAmt.value)!="" && isNaN(parseFloat(document.Form1.txtAmt.value)))
		 {
		 alert("Amount Cannot Contains Characters!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtNarrat.value)!="" && document.Form1.txtNarrat.value.length > 50)
		 {
		 alert("Plz Enter Narration Within 50 Characters Only!!!");
		 event.returnValue=false;
		 }
		// else if(document.Form1.txtCSNO=="[object]" && trimAll(document.Form1.txtCSNO.value)=="")
		// {
		// alert("Case No. Cannot be Blank!!!");
		// event.returnValue=false;
		// }
		else
		{
			document.Form1.btnSave.style.visibility = 'hidden';
		}
		 return;
		}
		function del()
		{
		var d=confirm("Click OK to Confirm Delete!!!");
		if(d==true)
		event.returnValue=true;
		else
		event.returnValue=false;
		}
		function sFocus()
		 {
		 if(document.Form1.txtVNO=="[object]")
		 {
		 document.Form1.txtVNO.focus();
		 }
		 else if(document.Form1.txtVDT=="[object]")
		 {
		 document.Form1.txtVDT.focus();
		 }
		 else 
		 {
		 document.Form1.txtCNO.focus();
		 }
		 }


		
        </script>
	</HEAD>
	<BODY bgColor="white" onload="sFocus();">
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
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								BackColor="White" ForeColor="DarkBlue" Width="196px">INTER UNIT RECIEPT</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="left">
						<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 32px" borderColor="#b0c4de" cellSpacing="1"
							cellPadding="1" bgColor="#f0f8ff" border="1">
							<TR>
								<TD style="WIDTH: 13.24%" vAlign="top" colSpan="1" rowSpan="1"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%"> Voucher No.</asp:label></TD>
								<TD style="WIDTH: 24.71%" vAlign="top"><asp:textbox id="txtVNO" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Width="60%" MaxLength="8" Height="20px"></asp:textbox><asp:label id="lblVNo" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="60%"></asp:label></TD>
								<TD style="WIDTH: 14.01%; HEIGHT: 9px" vAlign="top" align="left" colSpan="1" rowSpan="1"><asp:button id="btnSearch" tabIndex="14" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Width="111px" Text="Edit Voucher" onclick="btnSearch_Click"></asp:button></TD>
								<TD style="WIDTH: 17.72%; HEIGHT: 9px" vAlign="top">
									<P>
										<asp:label id="Label6" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Voucher Date.</asp:label></P>
								</TD>
								<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top" align="left">
									<P><asp:textbox id="txtVDT" onblur="check_date(txtVDT);" tabIndex="2" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkBlue" Width="45%" MaxLength="11" Height="20px"></asp:textbox>
										<asp:label id="lblVDT" runat="server" Width="45%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana"></asp:label></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:panel id="Panel" runat="server" Height="198px" HorizontalAlign="Center">
							<TABLE id="Table5" style="WIDTH: 711px; POSITION: relative; TOP: 0px; HEIGHT: 168px" borderColor="#b0c4de"
								cellSpacing="1" cellPadding="1" width="711" bgColor="#f0f8ff" border="1">
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 20px" align="center">
										<P>
											<asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">IU Advice No/Ref No.</asp:label></P>
									</TD>
									<TD style="WIDTH: 16.24%; HEIGHT: 20px" align="center">
										<asp:label id="Label5" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">IU Advice Date/Ref Date.</asp:label></TD>
									<TD style="WIDTH: 36.1%; HEIGHT: 20px" align="center">
										<asp:label id="Label11" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Region From Which  Recieved</asp:label></TD>
									<TD style="WIDTH: 17.21%; HEIGHT: 20px" align="center" colSpan="2">
										<P>
											<asp:label id="Label7" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Amount</asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 18.66%; HEIGHT: 32px" align="center">
										<asp:textbox id="txtCNO" style="TEXT-ALIGN: center" tabIndex="4" runat="server" Width="95%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD>
									<TD style="WIDTH: 16.24%; HEIGHT: 32px" align="center">
										<asp:textbox id="txtCDT" onblur="check_date(txtCDT);" style="TEXT-ALIGN: center" tabIndex="5"
											runat="server" Width="90%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px"
											MaxLength="11"></asp:textbox></TD>
									<TD style="WIDTH: 36.1%; HEIGHT: 32px" align="center">
										<asp:dropdownlist id="lstBank1" tabIndex="6" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"></asp:dropdownlist></TD>
									<TD style="WIDTH: 17.21%; HEIGHT: 32px" align="center" colSpan="2">
										<asp:textbox id="txtAmt" style="TEXT-ALIGN: center" tabIndex="7" runat="server" Width="50%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="13"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36.54%; HEIGHT: 21px" align="center" colSpan="2">
										<asp:label id="Label14" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Account Code</asp:label></TD>
									<TD style="WIDTH: 32.05%; HEIGHT: 21px" align="left" colSpan="2">&nbsp;
										<asp:label id="Label12" runat="server" Width="77px" ForeColor="DarkGreen" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana">Case No.</asp:label>
										<asp:label id="Label9" runat="server" Width="110px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">BPO.</asp:label></TD>
									<TD style="WIDTH: 32%; HEIGHT: 21px" align="center">
										<asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Narration</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 36.54%; HEIGHT: 38px" vAlign="top" align="center" colSpan="2">
										<asp:dropdownlist id="lstACD" tabIndex="9" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="lstACD_SelectedIndexChanged" onprerender="lstACD_PreRender"></asp:dropdownlist>
										<asp:label id="lblType" runat="server" Width="160px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Visible="False"></asp:label></TD>
									<TD style="WIDTH: 32.05%; HEIGHT: 38px" vAlign="top" align="left" colSpan="2">
										<asp:textbox id="txtCSNO" style="TEXT-ALIGN: center" tabIndex="10" runat="server" Width="25%"
											ForeColor="DarkGreen" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="9" AutoPostBack="True" ondisposed="txtCSNO_PreRender"></asp:textbox>&nbsp;&nbsp; 
										&nbsp;&nbsp;
										<asp:textbox id="txtBPO" style="TEXT-ALIGN: center" tabIndex="11" runat="server" Width="72px"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="5"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="btnFC_List" tabIndex="12" runat="server" Width="96px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Height="20px" Text="Select BPO" onclick="btnFC_List_Click"></asp:button></TD>
									<TD style="WIDTH: 32%; HEIGHT: 38px" vAlign="top" align="center">
										<asp:textbox id="txtNarrat" style="TEXT-ALIGN: center" tabIndex="14" runat="server" Width="95%"
											ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="30px" MaxLength="50" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="5">
										<P align="left">
											<asp:dropdownlist id="lstBPO" tabIndex="13" runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt"
												Font-Names="Verdana" Height="20px" AutoPostBack="True" Visible="False" onselectedindexchanged="lstBPO_SelectedIndexChanged"></asp:dropdownlist></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 594px" align="center" colSpan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="btnSave1" tabIndex="15" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave1_Click"></asp:button>
										<asp:button id="btnAdd" tabIndex="16" runat="server" Width="66px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Text="Add New" onclick="btnAdd_Click"></asp:button>
										<asp:button id="btnDel2" tabIndex="17" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Text="Delete" onclick="btnDel2_Click"></asp:button>
										<asp:button id="btnPrint" tabIndex="19" runat="server" Width="65px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Text="Print" onclick="btnPrint_Click"></asp:button>
										<asp:button id="btnCancel" tabIndex="20" runat="server" Width="67px" ForeColor="DarkBlue" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
								</TR>
							</TABLE>
							<P>
								<asp:label id="Label13" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana">User should verify that the entered voucher date is correct before proceeding further.</asp:label></P>
						</asp:panel>
						<DIV>
							<TITTLE:CUSTOMDATAGRID id="grdVDt" runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="250px"
								FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
								CellPadding="2" FreezeRows="0" PageSize="15" AutoGenerateColumns="False" BorderColor="DarkBlue">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
									CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="SNo.">
										<HeaderStyle Width="4%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id=HyperLink1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SNO")%>' NavigateUrl='<%#"InterUnit_Reciept.aspx?VOUCHER_NO=" + DataBinder.Eval(Container.DataItem,"VCHR_NO") + "&amp;ACTION=M" + "&amp;SNO=" + DataBinder.Eval(Container.DataItem,"SNO")%>'>HyperLink</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="CHQ_NO" HeaderText="IU Advice No./Ref No.">
										<HeaderStyle Width="12%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CHQ_DT" HeaderText="IU Advice Date./Ref Date.">
										<HeaderStyle Width="7%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMOUNT" HeaderText="Amount">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BANK_NAME" HeaderText="Region From Which Recieved">
										<HeaderStyle Width="14%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BPO_NAME" HeaderText="BPO">
										<HeaderStyle Width="18%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACC_DESC" HeaderText="Account">
										<HeaderStyle Width="17%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NARRATION" HeaderText="Narration">
										<HeaderStyle Width="13%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="VCHR_NO" HeaderText="Voucher No"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
