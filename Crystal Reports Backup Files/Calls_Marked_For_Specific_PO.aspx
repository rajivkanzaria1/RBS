<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calls_Marked_For_Specific_PO.aspx.cs" Inherits="RBS.Calls_Marked_For_Specific_PO.Calls_Marked_For_Specific_PO" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Inspection_Details_Form_For_Vendors</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
		function validate()
		{
		 if(trimAll(document.Form1.lstClientType.value)=="")
		 {
		  alert("Select Client Type to search the Records ");
		 event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.lstBPO_Rly.value)=="")
		 {
		  alert("Select Client to search the Records ");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtPONO.value.length < 5)
		{
		 alert("Enter Last 5 Digits of PO No. ");
		 event.returnValue=false;
		 }
	     else if(trimAll(document.Form1.txtPODT.value)=="")
		 {
		  alert("Enter PO DATE to search the Records ");
		 event.returnValue=false;
		 }
		else 
		return;
			
		}
		
		function validate2()
		{
		 if(trimAll(document.Form1.lstClientType.value)=="")
		 {
		  alert("Select Client Type to search the Records ");
		  event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.lstBPO_Rly.value)=="")
		 {
		  alert("Select Client to search the Records ");
		  event.returnValue=false;
		 }
		 else if(trimAll(document.Form1.txtPODT.value)=="")
		 {
		  alert("Enter PO DATE to search the Records ");
		  event.returnValue=false;
		 }
		else 
		return;
			
		}
		function txtCopy()
		{
			
			if(check_date(document.Form1.frmDt)==true && trimAll(document.Form1.toDt.value)=="")
			{
				document.Form1.toDt.value=document.Form1.frmDt.value;
			}
			
		}
		
		function validate3()
		{
			if(trimAll(document.Form1.lstClientType.value)=="")
			{
				alert("Select Client Type to search the Records ");
				event.returnValue=false;
			}
			else if(trimAll(document.Form1.lstBPO_Rly.value)=="")
			{
				alert("Select Client to search the Records ");
				event.returnValue=false;
			}
			else if(document.Form1.frmDt=="[object]" && trimAll(document.Form1.frmDt.value)=="")
			{
				alert("You Cannot Leave From Date Blank!!!");
				event.returnValue=false;
			}
		}
		function preventCopyPaste() 
		{
			var key = String.fromCharCode(event.keyCode).toLowerCase();
			if ((event.ctrlKey && (key == "c" || key == "v")) ||(event.shiftKey && event.keyCode==45)) 
				{
				event.returnValue = false;
				}
		}
		function preventRightClick()
		{
			var rightClick=false;
			if(event.which) rightClick=(event.which==3);
			if(event.button) rightClick=(event.button==2);
			if(rightClick) alert("Right click restricted");
		}
		
		document.onkeydown = function()
		{
			var x = event.keyCode;
			if (((x == 70)||(x == 78)||(x == 79)||(x == 80)) && (event.ctrlKey) || (x > 111 && x<124))
			{
			//alert ("No new window")
			event.cancelBubble = true;
			event.returnValue = false;
			event.keyCode = false;
			return false;
			}
		}
        </script>
	</HEAD>
	<body ondragstart="return false" onselectstart="return false"
		oncontextmenu="return false">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel_1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
				Visible="False" Height="1px" Width="100%">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
					cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 22px" align="center">
							<P>
								<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 22px" align="center">
							<P>
								<asp:label id="Label1" runat="server" Width="80%" ForeColor="DarkBlue" Font-Bold="True" Font-Size="10pt"
									Font-Names="Verdana" BackColor="White">CALL DETAILS FOR SPECIFIC PO</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 22px" align="center">
							<asp:label id="Label4" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana">* For Call Details of Specific PO,, Select Client Type, Client & Enter PO Date and then Click on Search PO's. Button, then click on Select Hyperlink of the desired PO No.</asp:label>
							<asp:label id="Label3" runat="server" Width="100%" ForeColor="DarkMagenta" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana">*  IC Issued after 1st March 2013 by Northern Region can also be viewed by Clicking VIEW IC hyperlink in the Report.</asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 50%" align="center">
							<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 100%" borderColor="#b0c4de" cellSpacing="0"
								cellPadding="0" bgColor="aliceblue" border="1">
								<TR>
									<TD style="WIDTH: 30%; HEIGHT: 22px">
										<asp:label id="Label6" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Client Type<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 23px" colSpan="3">
										<asp:dropdownlist id="lstClientType" tabIndex="1" runat="server" Width="20%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" AutoPostBack="True" onselectedindexchanged="lstClientType_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 30%; HEIGHT: 34px">
										<asp:label id="Label2" runat="server" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Select Client<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 34px" colSpan="3">
										<asp:dropdownlist id="lstBPO_Rly" tabIndex="2" runat="server" Width="98%" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana"></asp:dropdownlist></TD>
								</TR>
								<% if (Request.Params ["ACTION"]=="X") {%>
								<TR bgColor="#f0f8ff">
									<TD style="WIDTH: 30%; HEIGHT: 52px" align="left"><B><FONT face="Verdana" color="darkblue" size="2">
												<asp:label id="Label5" runat="server" Width="138px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
													Font-Names="Verdana">Calls For the Period<font color="red" size="1">*</font> </asp:label></FONT></B></TD>
									<TD style="WIDTH: 70%; HEIGHT: 52px" align="left"><B><FONT face="Verdana" color="darkblue" size="2">From</FONT></B>
										<asp:textbox id="frmDt" onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');"
											style="TEXT-ALIGN: center" tabIndex="3" runat="server" Width="100px" Height="20px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="10"></asp:textbox><B><FONT face="Verdana" color="darkblue" size="2">To</FONT></B>
										<asp:textbox id="toDt" onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();"
											style="TEXT-ALIGN: center" tabIndex="4" runat="server" Width="100px" Height="20px" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" MaxLength="10"></asp:textbox>&nbsp;
										<asp:label id="Label9" runat="server" Width="289px" ForeColor="DarkMagenta" Font-Bold="True"
											Font-Size="8pt" Font-Names="Verdana">* Enter Date in DD/MM/YYYY Format.</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 30%; HEIGHT: 28px">
										<asp:label id="Label8" runat="server" Width="138px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">Call Status<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana" colSpan="3">
										<asp:dropdownlist id="lstCallStatus" tabIndex="1" runat="server" Width="40%" ForeColor="DarkBlue"
											Font-Size="8pt" Font-Names="Verdana" OnChange="call_cancel_status();"></asp:dropdownlist></TD>
								</TR>
								<%}else {%>
								<TR>
									<TD style="WIDTH: 30%; HEIGHT: 28px">
										<asp:label id="Label7" runat="server" Width="60px" ForeColor="DarkBlue" Font-Bold="True" Font-Size="8pt"
											Font-Names="Verdana">PO Date<font color="red" size="1">*</font> </asp:label></TD>
									<TD style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana" colSpan="3">
										<asp:textbox id="txtPODT" onblur="check_date(txtPODT);" tabIndex="3" runat="server" Width="15%"
											Height="20px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" MaxLength="10"></asp:textbox>(Enter 
										Date in [dd/mm/yyyy] Format) &nbsp;
									</TD>
								</TR>
								<%}%>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 21px" align="center"></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:button id="btnSearch" tabIndex="8" runat="server" Width="105px" ForeColor="DarkBlue" Font-Bold="True"
								Font-Size="8pt" Font-Names="Verdana" Text="Search PO No." onclick="btnSearch_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnSubmit" runat="server" ForeColor="DarkBlue" Font-Bold="True" Text="Submit" onclick="btnSubmit_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center">
							<TITTLE:CUSTOMDATAGRID id="DgPONO" runat="server" Width="100%" Height="8px" Visible="False" AutoGenerateColumns="False"
								PageSize="15" BorderColor="DarkBlue" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True" CssClass="Grid"
								AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="500px" GridWidth="100%">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%"
									ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Select">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink1 NavigateUrl='<%#"Calls_Marked_For_Specific_PO.aspx?PO_NO=" + DataBinder.Eval(Container.DataItem,"L5NO_PO") + "&amp;PO_DT=" + DataBinder.Eval(Container.DataItem,"PO_DT")+"&amp;RLY_NONRLY=" + DataBinder.Eval(Container.DataItem,"RLY_NONRLY")+"&amp;RLY_CD=" + DataBinder.Eval(Container.DataItem,"RLY_CD")+"&amp;ACTION="+Action%>' Runat="server">Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="PO_NO" HeaderText="PO No.">
										<HeaderStyle Width="90%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PO_DT" HeaderText="PO_DT">
										<HeaderStyle Width="20%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="RLY_CD" HeaderText="RLY_CD">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="RLY_NONRLY" HeaderText="RLY_NONRLY"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="L5NO_PO" HeaderText="L5NO_PO"></asp:BoundColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
