<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Onliine_Complaints_Form.aspx.cs" Inherits="RBS.Onliine_Complaints_Form.Onliine_Complaints_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Onliine_Complaints_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">		 
		
		
			function validate()
		{
			if(trimAll(document.Form1.txtBkNo.value)=="")
				{
					alert("BOOK No. Missing!!!");
					event.returnValue=false;
					document.Form1.lstPoItems.focus();
				}
			else if(trimAll(document.Form1.txtSetNo.value)=="")
				{
					alert("SET No. Missing!!!");
					event.returnValue=false;
					document.Form1.lstPoItems.focus();
				}
			else if(trimAll(document.Form1.lstINSPRegion.value)=="")
				{
					alert("Inspection Region Missing!!!");
					event.returnValue=false;
					document.Form1.lstPoItems.focus();
				}
			else if(trimAll(document.Form1.lstPoItems.value)=="")
				{
					alert("Item Description Missing!!!");
					event.returnValue=false;
					document.Form1.lstPoItems.focus();
				}
			else if(trimAll(document.Form1.txtQtyOffered.value)=="")
				{
					alert("Offered Quantity Not Entered!!!");
					event.returnValue=false;
					document.Form1.txtQtyOffered.focus();
				}
			else if(trimAll(document.Form1.txtQtyRej.value)=="")
				{
					alert("Quantity Rejected Not Entered!!!");
					event.returnValue=false;
					document.Form1.txtQtyRej.focus();
				}
			else if(trimAll(document.Form1.txtMemoNo.value)=="")
				{
					alert("Rej Memo No. Not Entered!!!");
					event.returnValue=false;
					document.Form1.txtQtyRej.focus();
				}
			else if(trimAll(document.Form1.txtMemoDt.value)=="")
				{
					alert("Rej Memo Dt Not Entered!!!");
					event.returnValue=false;
					document.Form1.txtQtyRej.focus();
				}
			else if(trimAll(document.Form1.txtRejReason.value)=="")
				{
					alert("Reasons For Rejection Is Missing!!!");
					event.returnValue=false;
					document.Form1.txtRejReason.focus();
				}
			else if(document.Form1.txtRejReason.value.length > 250)
				{
					 alert("PLZ ENTER REASON FOR REJECTION WITHIN 250 CHARACTERS ONLY!!!");
					 event.returnValue=false;
				}
			else if(document.Form1.txtQtyOffered.value < document.Form1.txtQtyRej.value)
				{
					 alert("Rejected Quantity cannot be greated then Qty Passed!!!");
					 event.returnValue=false;
				}
			else if(trimAll(document.Form1.txtCON_Name.value)=="")
				{
					alert("Consignee Name Is Missing!!!");
					event.returnValue=false;
					document.Form1.txtRejReason.focus();
				}
			else if(trimAll(document.Form1.txtDesig.value)=="")
				{
					alert("Consignee Designation Is Missing!!!");
					event.returnValue=false;
					document.Form1.txtRejReason.focus();
				}
			else if(trimAll(document.Form1.txtCON_Email.value)=="")
				{
					alert("Consignee Email Is Missing!!!");
					event.returnValue=false;
					document.Form1.txtRejReason.focus();
				}
			else if(trimAll(document.Form1.txtCON_Contact_NO.value)=="")
				{
					alert("Consignee Mobile No. Is Missing!!!");
					event.returnValue=false;
					document.Form1.txtRejReason.focus();
				}
			else 
			return;
		}
		 
		 function makeUppercasebk()
		 {
			document.Form1.txtBkNo.value = document.Form1.txtBkNo.value.toUpperCase();
			
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
			return false;	
		}
		
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 18px" align="center" colSpan="4">
						<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" BackColor="White"
								Font-Bold="True" ForeColor="DarkBlue">ONLINE REJECTION ADVICE REGISTERATION FORM</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">
						<TABLE id="Table2" style="HEIGHT: 104px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
							width="85%" bgColor="aliceblue" border="1">
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label_Return_DT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="128px"> Registration Date:</asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:label id="lblCom_DT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="80px"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.22%; HEIGHT: 27px" align="left" colSpan="2"><asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Crimson" Width="184px" Font-Underline="True">Consignee Details</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 27px" align="left"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="64px"> Name <font color="red">*</font></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
								<TD style="WIDTH: 70%; HEIGHT: 27px"><asp:textbox id="txtCON_Name" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Width="35%" MaxLength="100" Height="20px"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 27px" align="left"><asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="48px">Designation<font color="red">*</font></asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 27px"><asp:textbox id="txtDesig" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Width="35%" MaxLength="50" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 28px"><asp:label id="Label9" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="96px"> Email:<font color="red">*</font></asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 28px"><asp:textbox id="txtCON_Email" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Width="60%" MaxLength="50" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 23px"><asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="128px"> Mobile No:<font color="red">*</font></asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:textbox id="txtCON_Contact_NO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Width="60%" MaxLength="45" Height="20px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 23px" colSpan="2"><asp:label id="Label18" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Crimson" Width="184px" Font-Underline="True">Rejection Details</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 23px"><STRONG><FONT face="Verdana" size="2"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
												ForeColor="DarkBlue" Width="136px" Height="27px">Book No. & Set No. <font color="red">*</font></asp:label></FONT></STRONG></TD>
								<TD style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 30px"></FONT><asp:textbox id="txtBkNo" onblur="makeUppercasebk();" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="Blue" Width="56px" MaxLength="4"></asp:textbox>&nbsp;&amp;
									<asp:textbox id="txtSetNo" onblur="change();" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="Blue" Width="50px" MaxLength="3"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 29px"><asp:label id="Label15" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Inspection Region <font color="red">*</font></asp:label></TD>
								<TD style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 29px"><asp:dropdownlist id="lstINSPRegion" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" AutoPostBack="True" onselectedindexchanged="lstINSPRegion_SelectedIndexChanged">
										<asp:ListItem Selected="True"></asp:ListItem>
										<asp:ListItem Value="N">Northern Region</asp:ListItem>
										<asp:ListItem Value="E">Eastern Region</asp:ListItem>
										<asp:ListItem Value="W">Western Region</asp:ListItem>
										<asp:ListItem Value="S">Southern Region</asp:ListItem>
									</asp:dropdownlist>&nbsp;
									<asp:label id="Label19" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Crimson" Width="480px">Enter Book No., Set No. & Select Inspection Region before selecting the Item</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 39px"><asp:label id="Label14" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="128px">Item <font color="red">*</font> </asp:label></TD>
								<TD style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 39px"><asp:label id="lblItemSrnoPo" runat="server" Width="40px" Visible="False"></asp:label><asp:label id="lblItemDesc" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Width="100%"><----- Select Item Description From The List Below to continue-----></asp:label><asp:dropdownlist id="lstPoItems" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="Crimson"
										Width="100%" AutoPostBack="True" onselectedindexchanged="lstPoItems_SelectedIndexChanged"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 29px"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Qty. as per IC <font color="red">*</font></asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 29px" align="left"><asp:textbox id="txtQtyOffered" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 28px"><asp:label id="Label26" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Qty. Rejected  <font color="red">*</font></asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 28px" align="left"><asp:textbox id="txtQtyRej" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" AutoPostBack="True" Enabled="False" ontextchanged="txtQtyRej_TextChanged"></asp:textbox><asp:label id="lblUOMDesc" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Visible="False"></asp:label><asp:label id="lblUOM" runat="server" Visible="False"></asp:label><asp:label id="lblRate" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Visible="False"></asp:label><asp:label id="lblUomRate" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Visible="False"></asp:label><asp:textbox id="txtValueRej" tabIndex="13" runat="server" Font-Names="Verdana" Font-Size="8pt"
										Font-Bold="True" ForeColor="Blue" Visible="False" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 30px"><asp:label id="Label17" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Reasons of Rejection <font color="red">*</font></asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:textbox id="txtRejReason" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Width="100%" Enabled="False" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 30px"><asp:label id="Label16" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Remarks <font color="red">(If Any)</font></asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px"><asp:textbox id="txtRemarks" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" Width="100%" MaxLength="250" Height="34px" Enabled="False" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 23px"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Rejection Memo No. <font color="red">*</font></asp:label></TD>
								<TD style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 30px"><asp:textbox id="txtMemoNo" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="Blue" MaxLength="25"></asp:textbox><asp:label id="lblCaseNO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="80px" Visible="False"></asp:label><asp:label id="lblVendor" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="80px" Visible="False"></asp:label><asp:label id="lblConsignee" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="80px" Visible="False"></asp:label><asp:label id="lblIE" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="80px" Visible="False"></asp:label><asp:label id="lblCO" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="OrangeRed" Width="80px" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 28px"><asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Rejection Memo Date <font color="red">* (DD/MM/YYYY)</font></asp:label></TD>
								<TD style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 28px"><asp:textbox id="txtMemoDt" onblur="check_date(txtMemoDt)" runat="server" Font-Names="Verdana"
										Font-Size="8pt" Font-Bold="True" ForeColor="Blue"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 25.45%; HEIGHT: 30px"><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue">Rejection Memo Scanned File ( IN PDF ONLY)  <font color="red">* 
											(Not more then 1MB)</font></asp:label></TD>
								<TD style="WIDTH: 70%; HEIGHT: 30px"><INPUT id="File1" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 424px; COLOR: blue; FONT-FAMILY: Verdana; HEIGHT: 22px"
										tabIndex="16" type="file" size="51" name="File1" runat="server"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 100%" colSpan="2"></TD>
							</TR>
						</TABLE>
						<asp:label id="Label2" runat="server" ForeColor="Crimson" Font-Bold="True" Font-Size="8pt"
							Font-Names="Verdana" Width="90%">Enter all the fields marked as * and then click on submit button to register your online Rejections.</asp:label>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px" align="center" colSpan="4">
						<P><asp:button id="btnSave" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Enabled="False" Text="Submit" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="DarkBlue" Text="Cancel"></asp:button></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

