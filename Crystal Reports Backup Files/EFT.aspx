<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EFT.aspx.cs" Inherits="RBS.EFT.EFT" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EFT</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate1()
		{
			if(trimAll(document.Form1.lstBank.value)==0 && trimAll(document.Form1.txtEFTNO.value)=="" && trimAll(document.Form1.txtEFTDT.value)=="" && trimAll(document.Form1.txtAmt.value)=="" && trimAll(document.Form1.txtBPO.value)=="")
			{
			
				alert("Plz Select Bank Or Enter EFT No. Or EFT Date or Amount To Search Records!!!");
				event.returnValue=false;
			}
		 return;
		}
		function validate()
		{
		 if(trimAll(document.Form1.lstBank.value)==0)
		 {
		 alert("Plz Select Bank!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtEFTNO.value)=="")
		 {
		 alert("EFT No. Cannot be left blank!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtEFTDT.value)=="")
		 {
		 alert("EFT Date Cannot be left blank!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.lstACD.value)=="")
		 {
		 alert("Account Code Cannot be left blank!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtAmt.value)!="" && isNaN(parseFloat(document.Form1.txtAmt.value)))
		 {
		 alert("Amount Cannot Contains Characters!!!");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtAmt.value)=="" || trimAll(document.Form1.txtAmt.value)==0)
		 {
		 alert("Amount Cannot be Null or Zero!!!");
		 event.returnValue=false;
		 }
		 else
		 {
			document.Form1.btnSave.style.visibility = 'hidden';
			
		 }
		 return;
		}
		function validateBPO()
		{
		 if(trimAll(document.Form1.txtBPO.value)=="")
		 {
		 alert("ENTER BPO CODE OR 1ST Few CHARACTERS OF BPO NAME AND THEN CLICK ON SELECT BPO BUTTON");
		 event.returnValue=false;
		 }
		 else
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
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 48px; TOP: 8px; LEFT: 8px"
				cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 17px" align="center" height="17">
							<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 28px" align="center">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
									BackColor="White" ForeColor="DarkBlue" Width="90%">ELECTRONIC FUND TRANSFER (EFT)</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 146px" align="center">
							<TABLE id="Table3" style="WIDTH: 100%; HEIGHT: 64px" borderColor="#b0c4de" cellSpacing="1"
								cellPadding="1" bgColor="#f0f8ff" border="1">
								<TBODY>
									<TR>
										<TD style="WIDTH: 8.54%" vAlign="top">
											<P><asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="40px">Bank</asp:label></P>
										</TD>
										<TD style="WIDTH: 28.01%" vAlign="top">
											<P><asp:dropdownlist id="lstBank" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%"></asp:dropdownlist></P>
										</TD>
										<TD style="WIDTH: 11.48%; HEIGHT: 9px" vAlign="top">
											<P><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">EFT No.</asp:label></P>
										</TD>
										<TD style="WIDTH: 23.16%; HEIGHT: 9px" vAlign="top">
											<P><asp:textbox id="txtEFTNO" style="TEXT-ALIGN: center" tabIndex="2" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="95%" MaxLength="12" Height="20px"></asp:textbox></P>
										</TD>
										<TD style="WIDTH: 13.24%; HEIGHT: 9px" vAlign="top">
											<P><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">EFT Date</asp:label></P>
										</TD>
										<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top"><asp:textbox id="txtEFTDT" onblur="check_date(txtEFTDT);" style="TEXT-ALIGN: center" tabIndex="3"
												runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="90%" MaxLength="10" Height="20px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 8.54%" vAlign="top">
											<P><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">Account Code</asp:label></P>
										</TD>
										<TD style="WIDTH: 17.09%" vAlign="top" colSpan="2">
											<P><asp:dropdownlist id="lstACD" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%"></asp:dropdownlist></P>
										</TD>
										<TD style="WIDTH: 23.16%; HEIGHT: 9px" vAlign="top">
											<P>&nbsp;</P>
										</TD>
										<TD style="WIDTH: 13.24%; HEIGHT: 9px" vAlign="top">
											<P><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="100%">Amount</asp:label></P>
										</TD>
										<TD style="WIDTH: 30%; HEIGHT: 9px" vAlign="top">
											<P><asp:textbox id="txtAmt" style="TEXT-ALIGN: center" tabIndex="5" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="90%" MaxLength="13" Height="20px"></asp:textbox></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 8.54%" vAlign="top"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="24px">BPO.</asp:label></TD>
										<TD style="WIDTH: 17.09%" vAlign="top" colSpan="5"><asp:textbox id="txtBPO" style="TEXT-ALIGN: center" tabIndex="6" runat="server" Font-Names="Verdana"
												Font-Size="8pt" ForeColor="DarkBlue" Width="15%" MaxLength="5" Height="20px"></asp:textbox><asp:button id="btnFC_List" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt"
												Font-Bold="True" ForeColor="DarkBlue" Width="15%" Height="20px" Text="Select BPO" onclick="btnFC_List_Click"></asp:button>
											<asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="7pt" Font-Bold="True"
												ForeColor="DarkMagenta" Width="69%">To Search a BPO-> Enter First Few Characters of RLY CD or Full BPO CD and Click on Select BPO and then Choose one from the given list in case of more then one search results.</asp:label><asp:dropdownlist id="lstBPO" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
												Width="100%" Height="20px" AutoPostBack="True" Visible="False" onselectedindexchanged="lstBPO_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" align="center" colSpan="6"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkMagenta" Width="100%">To Add the EFT -->Enter All the Data and then Click on "Save" Button</asp:label><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkMagenta" Width="100%">To Search a EFT-> Enter Bank or Part/Full EFT NO.  or EFT Date or Amount or BPO and click on "Search" button</asp:label><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkMagenta" Width="100%">To Edit the EFT --> First Search The EFT and then Click on Sno of that EFT in the Grid</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 31.79%; HEIGHT: 9px" vAlign="top" colSpan="6">
											<P align="center"><asp:button id="btnSearch" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="DarkBlue" Width="83px" Text="Search" onclick="btnSearch_Click"></asp:button><asp:button id="btnSave" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="72px" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="8pt"
													Font-Bold="True" ForeColor="DarkBlue" Width="72px" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="BtnAdd" tabIndex="12" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
													ForeColor="DarkBlue" Width="137px" Text="Add New EFT Entry" onclick="BtnAdd_Click"></asp:button></P>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<br>
						</TD>
					<TR>
						<TD style="HEIGHT: 26px" align="center"><TITTLE:CUSTOMDATAGRID id="grdEFT" runat="server" Width="90%" Height="100px" DESIGNTIMEDRAGDROP="304" GridWidth="80%"
								GridHeight="200px" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True"
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
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id=HyperLink1 runat="server" NavigateUrl='<%#"EFT.aspx?CHQ_NO=" + DataBinder.Eval(Container.DataItem,"CHQ_NO") + "&amp;CHQ_DT=" + DataBinder.Eval(Container.DataItem,"CHQ_DT") + "&amp;BANK_CD=" + DataBinder.Eval(Container.DataItem,"BANK_CD")+ "&amp;Action=M" %>'>Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="BANK_NAME" HeaderText="BANK">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CHQ_NO" HeaderText="EFT No">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CHQ_DT" HeaderText="EFT Date">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMOUNT" HeaderText="EFT Amount">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BPO" HeaderText="BPO">
										<HeaderStyle Width="30%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 26px" align="center"></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
