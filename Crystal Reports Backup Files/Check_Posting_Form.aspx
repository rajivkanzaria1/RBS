<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Check_Posting_Form.aspx.cs" Inherits="RBS.Check_Posting_Form.Check_Posting_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cheque Posting Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript" type="text/javascript">
		
		function validate()
		{
		if(trimAll(document.Form1.txtCNO.value)=="" || trimAll(document.Form1.lstBank1.value)=="" || trimAll(document.Form1.txtCDT.value)=="")
		{
		 alert("Bank or Cheque No. or Cheque Date. Cannot Be Left Blank");
		 event.returnValue=false;
		}
		}
		
		function validate1()
		{
		if(trimAll(document.Form1.txtBNO.value)=="" || trimAll(document.Form1.txtBNO.value).length < 10)
		{
		 alert("Bill No. Cannot Be Left Blank and Shld be of 10 Characters");
		 event.returnValue=false;
		}
		
		}
		
		function validate2()
		{
		
		if (trimAll(document.Form1.txtAmtTOClear.value)=="" || IsNumeric(document.Form1.txtAmtTOClear.value) == false)
		{
		 alert("Amount To Be Cleared Cannot Be Left Blank and Shld contain numeric values only!!!");
		 event.returnValue=false;
		}
		else if(trimAll(document.Form1.txtPDT.value)=="")
		{
		 alert("Posting Date Cannot Be Left Blank!!!");
		 event.returnValue=false;
		}
		else
		{
		document.Form1.btnSave1.style.visibility = 'hidden';
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
		
		function calcrecamt()
		{
			
			var qrStr = window.location.search;
			var spQrStr = qrStr.substring(1);
			var�arrQrStr = new Array(); 
			// splits each of pair
			var arr = spQrStr.split('&');

			for (var i=0;i<arr.length;i++)
			{
			// splits each of field-value pair
			var index = arr[i].indexOf('=');
			var key = arr[i].substring(0,index);
			var val = arr[i].substring(index+1);

			// saves each of field-value pair in an array variable
			arrQrStr[key] = val;
			}
						
			document.Form1.txtAmtToRec.value=parseFloat(document.Form1.txtBAmt.value)-(parseFloat(document.Form1.txtBAmtRec.value)+parseFloat(document.Form1.lblTDS.value)+parseFloat(document.Form1.txtRetention.value)+parseFloat(document.Form1.txtWriteOffAmt.value));
			//alert(arr.length);	
			if(arr.length<=3)
			{
				
				if(parseFloat(document.Form1.txtSAmt.value)<parseFloat(document.Form1.txtAmtToRec.value))
				{
					document.Form1.txtAmtTOClear.value=document.Form1.txtSAmt.value;
						
				}
				else
				{
					document.Form1.txtAmtTOClear.value=document.Form1.txtAmtToRec.value;
				}
			
			}
			return;
		}
        </script>
	</HEAD>
	<BODY bgColor="white">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 48px"
				cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 17px" align="center" height="17">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center">
						<P><asp:label id="Label1" runat="server" Width="168px" ForeColor="DarkBlue" BackColor="White"
								Font-Bold="True" Font-Size="10pt" Font-Names="Verdana">CHEQUE POSTING</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center">
						<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 240px" borderColor="#b0c4de" cellSpacing="1"
							cellPadding="1" bgColor="#f0f8ff" border="1">
							<TBODY>
								<TR>
									<TD style="WIDTH: 0%; HEIGHT: 30px" vAlign="top" align="left">
										<P><asp:label id="Label11" runat="server" Width="40px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Bank</asp:label></P>
									</TD>
									<TD style="WIDTH: 34.13%; HEIGHT: 30px" vAlign="top"><asp:dropdownlist id="lstBank1" tabIndex="1" runat="server" Width="95%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"></asp:dropdownlist><asp:label id="lblBank" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
									<TD style="WIDTH: 4.02%; HEIGHT: 30px" vAlign="top">
										<P><asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
												Font-Names="Verdana">Cheque No</asp:label></P>
									</TD>
					</TD>
					<TD style="WIDTH: 8.09%; HEIGHT: 30px" vAlign="top">
						<P><asp:textbox id="txtCNO" style="TEXT-ALIGN: center" tabIndex="2" runat="server" Width="90%" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="12"></asp:textbox><asp:label id="lblCNO" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana"></asp:label><asp:button id="btnSearch" tabIndex="4" runat="server" Width="111px" ForeColor="DarkBlue" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button></P>
					</TD>
					<TD style="WIDTH: 3.93%; HEIGHT: 30px" vAlign="top">
						<P><asp:label id="Label5" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">Cheque Date</asp:label></P>
					</TD>
					<TD style="WIDTH: 20%; HEIGHT: 30px" vAlign="top"><asp:textbox id="txtCDT" onblur="check_date(txtCDT);" style="TEXT-ALIGN: center" tabIndex="3"
							runat="server" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="12"></asp:textbox><asp:label id="lblCDate" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 8.29%" vAlign="top"><asp:label id="Label2" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"> Voucher No.</asp:label></TD>
					<TD style="WIDTH: 0%" vAlign="top"><asp:label id="lblVNo" runat="server" Width="35%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"></asp:label><asp:label id="Label6" runat="server" Width="15%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Dated.</asp:label><asp:label id="lblVDT" runat="server" Width="40%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Height="8px"></asp:label></TD>
					<TD style="WIDTH: 15.65%; HEIGHT: 9px" vAlign="top">
						<P><asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">Cheque Amount</asp:label></P>
					</TD>
					<TD style="WIDTH: 16.93%; HEIGHT: 9px" vAlign="top">
						<P><asp:label id="lblAmt" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana" Height="16px"></asp:label></P>
					</TD>
					<TD style="WIDTH: 12.08%; HEIGHT: 9px" vAlign="top">
						<P><asp:label id="Label8" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana">  Posted Amount</asp:label></P>
					</TD>
					<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
						<P><asp:label id="lblAmtADJ" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Height="16px"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 11.2%; HEIGHT: 9px" vAlign="top"><asp:label id="Label20" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Paying Authority</asp:label></TD>
					<TD style="WIDTH: 21.98%; HEIGHT: 9px" vAlign="top">
						<DIV><asp:label id="lblCBPO" runat="server" Width="100%" ForeColor="OrangeRed" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Height="16px"></asp:label></DIV>
					<TD style="WIDTH: 11.68%" vAlign="top"><asp:label id="Label15" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Amount Transferred to Other Regions</asp:label></TD>
					<TD style="WIDTH: 0%" vAlign="top"><asp:label id="lblTransAmt" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True"
							Font-Size="8pt" Font-Names="Verdana"></asp:label><asp:textbox id="Textbox1" style="TEXT-ALIGN: center" runat="server" Width="1px" ForeColor="AliceBlue"
							BackColor="AliceBlue" Font-Size="8pt" Font-Names="Verdana" Height="1px" MaxLength="10"></asp:textbox></TD>
					<TD style="WIDTH: 14.12%" vAlign="top"><asp:label id="Label26" runat="server" Width="100%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">Suspense Amount</asp:label></TD>
					<TD style="WIDTH: 0%" vAlign="top"><asp:label id="lblSAmt" runat="server" Width="80%" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana"></asp:label><asp:textbox id="txtSAmt" style="TEXT-ALIGN: center" runat="server" Width="1px" ForeColor="AliceBlue"
							BackColor="AliceBlue" Font-Size="8pt" Font-Names="Verdana" Height="1px" MaxLength="10"></asp:textbox></TD>
					</TD></TR>
				<TR>
					<TD style="WIDTH: 14.12%" vAlign="top" colSpan="6">
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
									<asp:TemplateColumn HeaderText="Bill No.">
										<HeaderStyle Width="11%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id=HyperLink1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BILL_NO")%>' NavigateUrl='<%#"Check_Posting_Form.aspx?CHQ_NO=" + DataBinder.Eval(Container.DataItem,"CHQ_NO") + "&amp;CHQ_DT=" + DataBinder.Eval(Container.DataItem,"CHQ_DT") + "&amp;BANK_CD=" + DataBinder.Eval(Container.DataItem,"BANK_CD") + "&amp;BILL_NO=" + DataBinder.Eval(Container.DataItem,"BILL_NO")+ "&amp;AMOUNT_CLEARED=" + DataBinder.Eval(Container.DataItem,"AMOUNT_CLEARED")%>'>HyperLink</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="BPO_NAME" HeaderText="BPO ">
										<HeaderStyle Width="40%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BILL_AMOUNT" HeaderText="Bill Amount">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BILL_AMT_CLEARED" HeaderText="Bill Amount Cleared">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMOUNT_CLEARED" HeaderText="Amt Cleared by above Cheque">
										<HeaderStyle Width="14%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="POSTING_DT" HeaderText="Posting Date">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CHQ_NO" HeaderText="Cheque No"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CHQ_DT" HeaderText="Cheque Date"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="BANK_CD" HeaderText="BANK"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
			</TABLE>
			</TD></TR>
			<TR>
				<TD align="center"><asp:panel id="Panel" runat="server" Height="118px" HorizontalAlign="Center">
						<TABLE id="Table5" style="WIDTH: 98%; POSITION: relative; TOP: 0px; HEIGHT: 82px" borderColor="#b0c4de"
							cellSpacing="1" cellPadding="1" bgColor="#fff7d6" border="1">
							<TR>
								<TD style="WIDTH: 16.39%; HEIGHT: 30px" align="center">
									<P>
										<asp:RadioButton id="rdbBNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkGreen" Text="Bill No." Checked="True" GroupName="G1"></asp:RadioButton>
										<asp:RadioButton id="rdbINO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkGreen" Text="Invoice No." GroupName="G1"></asp:RadioButton></P>
								</TD>
								<TD style="WIDTH: 15.38%; HEIGHT: 30px" align="center">
									<P>
										<asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">Bill Date</asp:label></P>
								</TD>
								<TD style="WIDTH: 15.55%; HEIGHT: 30px" align="center">
									<P>
										<asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">Bill Amount <font color="Fuchsia" size="1">(A)</font></asp:label></P>
								</TD>
								<TD style="WIDTH: 18.15%; HEIGHT: 30px" align="center">
									<asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Amount Already Recieved Thru Cheque/EFT</asp:label></TD>
								<TD style="WIDTH: 20.21%; HEIGHT: 30px" align="center">
									<asp:label id="Label21" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Total Amount Cleared <font color="Fuchsia" size="1">
											(B)</font></asp:label></TD>
								<TD style="WIDTH: 20%; HEIGHT: 30px" align="center">
									<asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Amount To Recover <font color="Fuchsia" size="1">(A-B)</font></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 18.2%; HEIGHT: 27px" align="center">
									<asp:textbox id="txtBNO" style="TEXT-ALIGN: center" tabIndex="5" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkGreen" Width="95%" MaxLength="14" Height="20px"></asp:textbox>
									<asp:label id="lblBNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkGreen" Width="95%"></asp:label></TD>
								<TD style="WIDTH: 11.49%; HEIGHT: 27px" align="center">
									<asp:label id="lblBDT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="100%"></asp:label>
									<asp:button id="btnBDetails" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Width="90%" Text="Bill Details" onclick="btnBDetails_Click"></asp:button></TD>
								<TD style="WIDTH: 15.55%; HEIGHT: 27px" align="center">
									<asp:label id="lblBAmt" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="100%"></asp:label>
									<asp:textbox id="txtBAmt" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana" Font-Size="8pt"
										BackColor="#FFF7D6" ForeColor="#FFF7D6" Width="1px" MaxLength="10" Height="1px"></asp:textbox></TD>
								<TD style="WIDTH: 18.15%; HEIGHT: 27px" align="center">
									<asp:label id="lblBAmtRec" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="100%"></asp:label>
									<asp:textbox id="txtBAmtRec" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana" Font-Size="8pt"
										BackColor="#FFF7D6" ForeColor="#FFF7D6" Width="1px" MaxLength="10" Height="1px"></asp:textbox></TD>
								<TD style="WIDTH: 20.21%; HEIGHT: 27px" align="center">
									<P>
										<asp:label id="lblTAmtCleared" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="100%"></asp:label></P>
								</TD>
								<TD style="WIDTH: 20%; HEIGHT: 27px" align="center">
									<P>
										<asp:label id="lblAmtToRec" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="46px" Height="1px" Visible="False"></asp:label></P>
									<P>
										<asp:textbox id="txtAmtToRec" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana"
											Font-Size="8pt" Font-Bold="True" BackColor="#FFF7D6" ForeColor="OrangeRed" Width="95%" MaxLength="10"
											Height="20px" onchange="calcrecamt();" BorderStyle="None"></asp:textbox></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 11.49%; HEIGHT: 28px" align="center">
									<asp:label id="Label16" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkGreen" Width="100%">Total TDS</asp:label></TD>
								<TD style="WIDTH: 15.55%; HEIGHT: 28px" align="center">
									<asp:label id="Label18" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkGreen" Width="100%">Retention Money</asp:label></TD>
								<TD align="center">
									<asp:label id="lblCNote" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkGreen" Width="184px">Amount To Thru Credit Note</asp:label></TD>
								<TD style="WIDTH: 18.15%; HEIGHT: 28px" align="center">
									<asp:label id="Label19" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkGreen" Width="100%">Write off Amt / Amt Adjusted</asp:label></TD>
								<TD style="WIDTH: 18.2%; HEIGHT: 28px" align="center">
									<asp:label id="Label17" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkGreen" Width="100%">Posting Date</asp:label></TD>
								<TD style="WIDTH: 15%; HEIGHT: 28px" align="center">
									<asp:label id="Label14" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkGreen" Width="100%">Amount To be Cleared by this Cheque</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 11.49%; HEIGHT: 25px" align="center">
									<P>
										<asp:textbox id="lblTDS" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana" Font-Size="8pt"
											Font-Bold="True" BackColor="#FFF7D6" ForeColor="DarkGreen" Width="93px" MaxLength="10" Height="20px"
											onchange="calcrecamt();" BorderStyle="None" Enabled="False"></asp:textbox></P>
								</TD>
								<TD style="WIDTH: 15.55%; HEIGHT: 25px" align="center">
									<asp:textbox id="txtRetention" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana"
										Font-Size="8pt" Font-Bold="True" BackColor="#FFF7D6" ForeColor="DarkGreen" Width="97px" MaxLength="10"
										Height="22px" onchange="calcrecamt();" BorderStyle="None" Enabled="False"></asp:textbox></TD>
								<TD align="center">
									<asp:textbox id="txtCNote_Amt" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana"
										Font-Size="8pt" Font-Bold="True" BackColor="#FFF7D6" ForeColor="DarkGreen" Width="97px" MaxLength="10"
										Height="22px" onchange="calcrecamt();" BorderStyle="None" Enabled="False"></asp:textbox></TD>
								<TD style="WIDTH: 18.15%; HEIGHT: 25px" align="center">
									<asp:textbox id="txtWriteOffAmt" style="TEXT-ALIGN: center" tabIndex="8" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkGreen" Width="97px" MaxLength="10" Height="22px" onchange="calcrecamt();"></asp:textbox></TD>
								<TD style="WIDTH: 18.2%; HEIGHT: 25px" align="center">
									<asp:textbox id="txtPDT" onblur="check_date(txtPDT);" style="TEXT-ALIGN: center" tabIndex="9"
										runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkGreen" Width="90%" MaxLength="10"
										Height="20px"></asp:textbox></TD>
								<TD style="WIDTH: 15%; HEIGHT: 25px" align="center">
									<P>
										<asp:textbox id="txtAmtTOClear" style="TEXT-ALIGN: center" tabIndex="10" runat="server" Font-Names="Verdana"
											Font-Size="8pt" ForeColor="DarkGreen" Width="93px" MaxLength="10" Height="20px"></asp:textbox></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 18.2%; HEIGHT: 25px" align="center">
									<asp:label id="Label22" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">Case No</asp:label></TD>
								<TD style="WIDTH: 11.49%; HEIGHT: 25px" align="center">
									<asp:label id="Label23" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">BK NO</asp:label></TD>
								<TD style="WIDTH: 15.55%; HEIGHT: 25px" align="center">
									<asp:label id="Label24" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">SET NO</asp:label></TD>
								<TD style="WIDTH: 18.15%; HEIGHT: 25px" align="center" colSpan="3">
									<asp:label id="Label25" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%">BPO</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 18.2%; HEIGHT: 25px" align="center">
									<asp:label id="lblCSNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="100%"></asp:label></TD>
								<TD style="WIDTH: 11.49%; HEIGHT: 25px" align="center">
									<asp:label id="lblBKNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="100%"></asp:label></TD>
								<TD style="WIDTH: 15.55%; HEIGHT: 25px" align="center">
									<asp:label id="lblSETNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="100%"></asp:label></TD>
								<TD style="WIDTH: 18.15%; HEIGHT: 25px" align="center" colSpan="3">
									<asp:label id="lblBPO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="100%"></asp:label>
									<asp:textbox id="txtBPOCD" style="TEXT-ALIGN: center" tabIndex="11" runat="server" Font-Names="Verdana"
										Font-Size="8pt" ForeColor="DarkGreen" Width="93px" MaxLength="10" Height="20px" Visible="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 594px" align="center" colSpan="6">
									<asp:button id="btnSave1" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Width="66px" Text="Save" onclick="btnSave1_Click"></asp:button>
									<asp:button id="btnDel2" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="67px" Text="Delete" Visible="False" onclick="btnDel2_Click"></asp:button>
									<asp:button id="btnCancel" tabIndex="12" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="DarkBlue" Width="67px" Text="Cancel" onclick="btnCancel_Click"></asp:button>
									<asp:button id="btnTDS" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="76px" Text="TDS Entry" onclick="btnTDS_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</asp:panel></TD>
			</TR>
			</TBODY></TABLE>&nbsp;</form>
	</BODY>
</HTML>
