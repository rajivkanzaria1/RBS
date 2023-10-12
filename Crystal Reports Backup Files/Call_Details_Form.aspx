<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Call_Details_Form.aspx.cs" Inherits="RBS.Call_Details_Form.Call_Details_Form" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CALL DETAILS FORM</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		document.Form1.btnSave1.style.visibility = 'hidden';
		if(document.Form1.txtQuanInsp.value=="")
		{
			alert("QUANTITY TO INSPECTED CANNOT LEFT BLANK");
			event.returnValue=false;
		}
		else if(document.Form1.txtQOrd.value!="" && isNaN(parseInt(document.Form1.txtQOrd.value)))
		 {
		 alert("INVALID CHARACTERS IN QTY ORDERED., ONLY NUMERIC ENTRY IS ALLOWED");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtCQty.value!="" && isNaN(parseInt(document.Form1.txtCQty.value)))
		 {
		 alert("INVALID CHARACTERS IN CUMM QTY OFFERED PREVIOUSLY, ONLY NUMERIC ENTRY IS ALLOWED");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtQPrePassed.value!="" && isNaN(parseInt(document.Form1.txtQPrePassed.value)))
		 {
		 alert("INVALID CHARACTERS IN QTY PREV PASSED, ONLY NUMERIC ENTRY IS ALLOWED");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtQuanInsp.value!="" && isNaN(parseInt(document.Form1.txtQuanInsp.value)))
		 {
		 alert("INVALID CHARACTERS IN QTY TO BE INSPECTED, ONLY NUMERIC ENTRY IS ALLOWED");
		 event.returnValue=false;
		 }
		 if((document.Form1.txtQOrd.value!="" && document.Form1.txtQPrePassed.value!="") && document.Form1.txtQuanInsp.value!="")
		 {
			var qord=document.Form1.txtQOrd.value;
			var ppass=document.Form1.txtQPrePassed.value;
			var qoff=document.Form1.txtQuanInsp.value;
			if((parseInt(qord) - parseInt(ppass)) < parseInt(qoff))
			{
			 alert("QUANTITY OFFERED SHOULD NOT BE GREATER THEN (QUANTITY ORDERED - QUANTITY PREVIOUSLY PASSED)");
			 event.returnValue=false;
			}
		 }
				
		if(document.Form1.txtQOrd.value!="" && document.Form1.txtQuanInsp.value!="")
		 {
			if(parseInt(document.Form1.txtQOrd.value) < parseInt(document.Form1.txtQuanInsp.value))
			{
			 alert("QUANTITY OFFERED SHOULD NOT BE GREATER THEN QUANTITY OREDERED");
			 event.returnValue=false;
			}
		 }
		
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
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center" colSpan="4"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True"
								ForeColor="DarkBlue" BackColor="White">CALL DETAILS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 15%; HEIGHT: 16px" bgColor="#ffffcc"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Case No: </asp:label></TD>
					<TD style="WIDTH: 40%; HEIGHT: 16px" bgColor="#ffffcc"><asp:label id="txtCaseNo" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">Case No </asp:label></TD>
					<TD style="WIDTH: 25%; HEIGHT: 16px" align="right" bgColor="#ffffcc"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">Call Date - SNo: </asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 16px" bgColor="#ffffcc"><asp:label id="txtDtOfReciept" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">C Date </asp:label>-
						<asp:label id="lblCSNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="OrangeRed">Sno</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 15%; HEIGHT: 16px" bgColor="#ffffcc"><asp:label id="Label15" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="DarkBlue">PO No & Date: </asp:label></TD>
					<TD style="WIDTH: 40%; HEIGHT: 16px" bgColor="#ffffcc" colSpan="2">
						<asp:label id="lblPONO" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">PO No </asp:label>
						<asp:label id="Label16" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">&</asp:label>&nbsp;&nbsp;
						<asp:label id="lblPODT" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">PO Date </asp:label></TD>
					<TD style="WIDTH: 20%; HEIGHT: 16px" bgColor="#ffffcc">
						<asp:label id="Label3" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana">IE:</asp:label>&nbsp;
						<asp:label id="lblIE" runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="56px">PO No </asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 50%" align="center" colSpan="4">
						<TABLE id="Table2" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" width="448" bgColor="aliceblue"
							border="1" borderColor="#b0c4de" align="center">
							<tr>
								<td style="WIDTH: 35%" vAlign="top">
									<TABLE id="Table3" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" bgColor="aliceblue"
										border="0">
										<tr>
											<td style="WIDTH: 60%"><asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%">Item SNo.</asp:label></td>
											<td style="WIDTH: 40%"><asp:textbox id="txtSerialNo" style="TEXT-ALIGN: right" runat="server" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="3" Enabled="False"></asp:textbox></td>
										</tr>
										<tr>
											<TD style="WIDTH: 60%; HEIGHT: 23px"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%">Qty Ordered</asp:label></TD>
											<TD style="WIDTH: 40%; HEIGHT: 23px"><asp:textbox id="txtQOrd" style="TEXT-ALIGN: right" tabIndex="2" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13" Enabled="False"></asp:textbox></TD>
										</tr>
										<tr>
											<TD style="WIDTH: 60%; HEIGHT: 23px"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%">Cumm. Qty off Prev</asp:label></TD>
											<TD style="WIDTH: 40%; HEIGHT: 23px"><asp:textbox id="txtCQty" style="TEXT-ALIGN: right" tabIndex="1" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></TD>
										</tr>
										<tr>
											<TD style="WIDTH: 60%; HEIGHT: 23px"><asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%">Qty Prev Passed</asp:label></TD>
											<TD style="WIDTH: 40%; HEIGHT: 23px"><asp:textbox id="txtQPrePassed" style="TEXT-ALIGN: right" tabIndex="2" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></TD>
										</tr>
										<tr>
											<td style="WIDTH: 60%"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%"> Qty Offered Now</asp:label></td>
											<td style="WIDTH: 40%"><asp:textbox id="txtQuanInsp" style="TEXT-ALIGN: right" tabIndex="3" runat="server" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Width="90%" Height="20px" MaxLength="13"></asp:textbox></td>
										</tr>
									</TABLE>
								</td>
								<td style="WIDTH: 65%; HEIGHT: 100%" vAlign="top"><TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 112px" cellSpacing="0" cellPadding="0" bgColor="aliceblue"
										border="0">
										<tr>
											<td style="WIDTH: 20%; HEIGHT: 100%"><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="100%">Item Desc</asp:label></td>
											<td style="WIDTH: 80%; HEIGHT: 100%"><asp:textbox id="txtIDesc" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Width="95%" Height="95%" MaxLength="3" TextMode="MultiLine"></asp:textbox></td>
										</tr>
									</TABLE>
								</td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center" colSpan="4">
						<P><asp:button id="btnSave1" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Text="Save" onclick="btnSave1_Click"></asp:button><asp:button id="btnSave" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnDelete" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="DarkBlue" Text="Delete" onclick="btnDelete_Click"></asp:button><asp:button id="btnCancel" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="8pt"
								Font-Bold="True" ForeColor="DarkBlue" Text="Cancel" onclick="btnCancel_Click"></asp:button></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"><asp:label id="Label24" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
							ForeColor="Crimson" Width="100%" Font-Underline="True">ITEMS MARKED/AVAILABLE FOR INSPECTION</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"><asp:datagrid id="grdCDetails" runat="server" Font-Names="Verdana" Font-Size="8pt" BackColor="White"
							Width="100%" Height="100px" PageSize="1" CellPadding="0" BorderColor="Navy" BorderStyle="Groove" AutoGenerateColumns="False">
							<FooterStyle Wrap="False"></FooterStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center" ForeColor="DarkBlue"
								VerticalAlign="Top" BackColor="InactiveCaptionText"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Item SNo.">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink id="Hyperlink1" Text="<%# DataBinder.Eval(Container.DataItem,"ITEM_SRNO_PO")%>" Runat="server" NavigateUrl="<%#"Call_Details_Form.aspx?Case_No=" + CNO + "&amp;DT_RECIEPT=" + DT +"&amp;CALL_SNO=" + CSNO +"&amp;cstatus="+ cstatus + "&amp;Serial_No=" + DataBinder.Eval(Container.DataItem,"ITEM_SRNO_PO") + "&amp;status="+DataBinder.Eval(Container.DataItem,"STATUS")%>">
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn Text="Status" DataTextField="Status" HeaderText="Status">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ITEM_DESC_PO" HeaderText="Item Desc">
									<HeaderStyle Width="40%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CONSIGNEE" HeaderText="Consignee"></asp:BoundColumn>
								<asp:BoundColumn DataField="QTY_ORDERED" HeaderText="Qty. Ord">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CUM_QTY_PREV_OFFERED" HeaderText="Cumm Qty off Prev">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CUM_QTY_PREV_PASSED" HeaderText="Qty Prev Passed">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="QTY_TO_INSP" HeaderText="Qty Offered Now">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="QTY_PASSED" HeaderText="Qty Passed">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="QTY_REJECTED" HeaderText="Qty Rejected">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="QTY_DUE" HeaderText="Qty Due">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
