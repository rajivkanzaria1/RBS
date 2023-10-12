<%@ Page Language="c#" CodeBehind="IC_Intermediate.aspx.cs" AutoEventWireup="false" Inherits="RBS.IC_Intermediate" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Call_Status_Edit_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript">
        function validate() {
            if (document.Form1.lstCallStatus.value == "C" && document.Form1.lstCallCancelStatus == "[object]" && trimAll(document.Form1.lstCallCancelStatus.value) == "") {
                alert("IN CASE OF CALL CANCELLATION, SELECT WHETHER IT IS CHARGEABLE OR NON-CHARGEABLE!!!");
                event.returnValue = false;
            }
            else if (document.Form1.lstCallStatus.value == "C" && document.Form1.lstCallCancelStatus == "[object]" && document.Form1.lstCallCancelStatus.value == "C" && document.Form1.lstCallCancelCharges == "[object]" && trimAll(document.Form1.lstCallCancelCharges.SelectedValue.value) == "") {
                alert("IN CASE OF CALL IS CHARGEABLE, SELECT CANCELLATION AMOUNT!!!");
                event.returnValue = false;
            }
            else if (document.Form1.lstCallStatus.value == "A" && (document.Form1.txtSetNo.value == "" || document.Form1.txtBKNO.value == "")) {
                alert("ENTER BOTH THE FIELDS BK NO. & SET NO. !!!");
                event.returnValue = false;
            }
            else if (document.Form1.lstCallStatus.value == "R" && (document.Form1.txtSetNo.value == "" || document.Form1.txtBKNO.value == "" || trimAll(document.Form1.txtRemarks.value) == "")) {
                alert("REMARKS, BK NO. & SET NO. CANNOT BE LEFT BLANK!!!");
                event.returnValue = false;
            }
            else if (document.Form1.txtRemarks == "[object]" && document.Form1.txtRemarks.value.length > 400) {
                alert("REMARKS SHOULD BE MAXIMUM OF 400 CHARACTERS INCLUDING SPACES!!!");
                event.returnValue = false;
            }
            else

                return;
        }
        function validate1() {
            if ((document.Form1.chk1.checked == false && document.Form1.chk2.checked == false) && (document.Form1.chk3.checked == false && document.Form1.chk4.checked == false) && (document.Form1.chk5.checked == false && document.Form1.chk6.checked == false) && (document.Form1.chk7.checked == false && document.Form1.chk8.checked == false) && (document.Form1.chk9.checked == false && document.Form1.chk10.checked == false) && (document.Form1.chk11.checked == false && document.Form1.chk12.checked == false)) {
                alert("SELECT ATLEAST ONE REASON FOR CALL CANCELLATION!!!");
                event.returnValue = false;
            }
            else if (document.Form1.chk12.checked == true && trimAll(document.Form1.txtCdesc.value) == "") {
                alert("CANCELLATION DESCRIPTION IS MANDATORY IN CASE OF OTHERS!!!");
                event.returnValue = false;
            }
            else if (document.Form1.txtCdesc == "[object]" && document.Form1.txtCdesc.value.length > 250) {
                alert("CANCELLATION DESCRIPTION SHOULD BE MAXIMUM 250 CHARACTERS INCLUDING SPACES!!!");
                event.returnValue = false;
            }
        }
        function call_cancel_status() {

            //if (document.Form1.lstCallStatus.value == "C") {
            //    document.Form1.lstCallCancelStatus.style.visibility = 'visible';
            //    document.Form1.lstCallCancelCharges.style.visibility = 'visible';
            //    document.Form1.lstCallCancelStatus.focus();
            //    document.Form1.lstCallCancelStatus.SelectedValue = "C";
            //    document.Form1.lstCallCancelCharges.SelectedValue = "";
            //    document.Form1.txtBKNO.style.visibility = 'hidden';
            //    document.Form1.txtSetNo.style.visibility = 'hidden';
            //    document.Form1.txtbksetno.style.visibility = 'hidden';
            //    document.Form1.btnSave.style.visibility = 'hidden';


            //}
            //else if (document.Form1.lstCallStatus.value == "A" || document.Form1.lstCallStatus.value == "R") {
                //document.Form1.txtBKNO.style.visibility = 'visible';
                //document.Form1.txtSetNo.style.visibility = 'visible';
                //document.Form1.txtbksetno.style.visibility = 'visible';
                //document.Form1.btnSave.style.visibility = 'visible';
                //document.Form1.lstCallCancelStatus.SelectedValue = "";
                //document.Form1.lstCallCancelStatus.style.visibility = 'hidden';
                //document.Form1.lstCallCancelStatus.SelectedValue = "";
                //document.Form1.lstCallCancelCharges.style.visibility = 'hidden';



            //}
            //	else if(document.Form1.lstCallStatus.value=="B")
            //	{
            //		document.Form1.lstCallCancelStatusSelectedValue="";
            //		document.Form1.lstCallCancelStatus.style.visibility = 'hidden';
            //		document.Form1.txtBKNO.style.visibility = 'hidden';
            //		document.Form1.txtSetNo.style.visibility = 'hidden';
            //		document.Form1.txtbksetno.style.visibility = 'hidden';
            //		document.Form1.btnSave.style.visibility = 'hidden';



            //	}
            //else {
            //    document.Form1.lstCallCancelStatusSelectedValue = "";
            //    document.Form1.lstCallCancelStatus.style.visibility = 'hidden';
            //    document.Form1.txtBKNO.style.visibility = 'hidden';
            //    document.Form1.txtSetNo.style.visibility = 'hidden';
            //    document.Form1.txtbksetno.style.visibility = 'hidden';
            //    document.Form1.btnSave.style.visibility = 'visible';
            //    document.Form1.lstCallCancelCharges.style.visibility = 'hidden';


            //}
        }
        function makeUppercase() {
            document.Form1.txtBKNO.value = document.Form1.txtBKNO.value.toUpperCase();
        }
        function change() {
            var d = document.Form1.txtSetNo.value;
            var dlength = d.length;
            if (dlength == 1) {
                d = "00" + d;
                document.Form1.txtSetNo.value = d;
                event.returnValue = false;
            }
            else if (dlength == 2) {
                d = "0" + d;
                document.Form1.txtSetNo.value = d;
                event.returnValue = false;
            }
            return false;
        }
        function validateFiles() {
            if (document.Form1.txtSetNo1.value == "" || document.Form1.txtBKNO1.value == "") {
                alert("Enter Both the Fields Bk No & Set No!!!");
                event.returnValue = false;
            }
            else if ((document.Form1.File4.value == "" && !document.Form1.CkBFile4.checked) || (document.Form1.File5.value == "" && !document.Form1.CkBFile5.checked) || (document.Form1.File6.value == "" && !document.Form1.CkBFile6.checked) || (document.Form1.File7.value == "" && !document.Form1.CkBFile7.checked) || (document.Form1.File8.value == "" && !document.Form1.CkBFile8.checked)) {
                alert("Select Atleast 5 Images!!!");
                event.returnValue = false;
            }
            else

                return;
        }
        function makeUppercase(value1) {
            var bkno = value1;
            var d = bkno.value.toUpperCase();
            bkno.value = d;

        }
        function change(value1) {
            var sno = value1;
            var d = sno.value;
            var dlength = d.length;
            if (dlength == 1) {
                d = "00" + d;
                sno.value = d;
                event.returnValue = false;
            }
            else if (dlength == 2) {
                d = "0" + d;
                sno.value = d;
                event.returnValue = false;
            }
            return false;
        }

        //function SetFileVal(ctrl, value) {
        //    alert(value);
        //    document.GetElementByID(ctrl).SetValue("value", value);
        //}



        </script>
	</HEAD>
	<body onload="call_cancel_status();" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<tr>
					<td style="HEIGHT: 45px" align="center">
						<p><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></p>
					</td>
				</tr>
				<tr>
					<td align="center"><asp:label id="Label1" runat="server" Width="177px" BackColor="White" Font-Names="Verdana"
							Font-Size="10pt" ForeColor="DarkBlue" Font-Bold="True">CALL STATUS EDIT FORM</asp:label></td>
				</tr>
				<tr>
					<td align="center">
						<table id="Table4" borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="97%" bgColor="#f0f8ff"
							border="1">
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Vendor</td>
								<td style="WIDTH: 70%; HEIGHT: 9px"><asp:label id="lblVend" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Purchaser</td>
								<td style="WIDTH: 70%"><asp:label id="lblPurc" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Item</td>
								<td style="WIDTH: 70%"><asp:label id="lblItem" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px">Call 
									Date</td>
								<td style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px"><asp:label id="lblCallDT" runat="server" Width="120px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b></b></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px"><b>Inpection 
										Desire Date</b></td>
								<td style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px"><asp:label id="lblInpDesireDT" runat="server" Width="120px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Engineer 
									Name</td>
								<td style="WIDTH: 70%"><asp:label id="lblIEName1" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Engineer 
									Contact No.</td>
								<td style="WIDTH: 70%"><asp:label id="lblIECON" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">PO 
									No.</td>
								<td style="WIDTH: 70%"><asp:label id="lblPONO" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">PO 
									Date</td>
								<td style="WIDTH: 70%"><asp:label id="lblPODT" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Case 
									No.</td>
								<td style="WIDTH: 70%"><asp:label id="lblCSNO" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Call 
									Letter Date</td>
								<td style="WIDTH: 70%"><asp:label id="lblCLettDT" runat="server" Width="112px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Call 
									Letter No.</td>
								<td style="WIDTH: 70%"><asp:label id="lblCLettNo" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 23px">Contact 
									Person</td>
								<td style="WIDTH: 70%; HEIGHT: 23px"><asp:label id="lblCONPER" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Contact 
									Person Tel No.</td>
								<td style="WIDTH: 70%"><asp:label id="lblCONPERTEL" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Call 
									Serial No</td>
								<td style="WIDTH: 70%"><asp:label id="lblSNO" runat="server" Width="128px" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="2">
							<tr>
								<td align="center" colSpan="4">
									<table id="Table3" style="HEIGHT: 50px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
										width="80%" bgColor="aliceblue" border="1">
										<tr>
											<td style="WIDTH: 47.53%; HEIGHT: 31px" align="center" colSpan="2">
												<table id="Table4" style="HEIGHT: 50px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
													width="90%" bgColor="aliceblue" border="1">
													<tbody>
														<tr>
															<td style="WIDTH: 3.52%"><asp:label id="LblConsignee" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
																	ForeColor="DarkBlue" Font-Bold="True">Consignee</asp:label></td>
											</td>
											<td style="WIDTH: 40%" colSpan="3"><asp:dropdownlist id="ddlCondignee" tabIndex="1" runat="server" Width="100%" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" AutoPostBack="True" align="center"></asp:dropdownlist></td>
										<tr>
											<td style="WIDTH: 8.88%"><asp:label id="lblBKNO" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
													Font-Bold="True">BK No.</asp:label></td>
											<td style="WIDTH: 25%"><asp:textbox id="txtBKNO1" onblur="makeUppercase(txtBKNO1);" tabIndex="3" runat="server" Width="48px"
													Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="4" Height="20px"></asp:textbox></td>
											<td style="HEIGHT: 25%"><asp:label id="lblSetNo" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" Font-Bold="True">Set No.</asp:label></td>
											<td style="HEIGHT: 25%"><asp:textbox id="txtSetNo1" onblur="change(txtSetNo1);" tabIndex="4" runat="server" Width="48px"
													Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="3" Height="20px"></asp:textbox></td>
										</tr>
										<%-- <tr>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lblBKNO1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
                                                                Font-Names="Verdana" Width="100px">BK No.</asp:Label></td>
                                                        <td style="width: 25%">
                                                            <asp:TextBox ID="txtBKNO1" onblur="makeUppercase(txtBKNO1);" TabIndex="5" runat="server" ForeColor="DarkBlue"
                                                                Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="4" Height="20px"></asp:TextBox></td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lblSetNo1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
                                                                Font-Names="Verdana" Width="100px">Set No.</asp:Label></td>
                                                        <td style="width: 25%">
                                                            <asp:TextBox ID="txtSetNo1" onblur="change(txtSetNo1);" TabIndex="6" runat="server" ForeColor="DarkBlue"
                                                                Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="3" Height="20px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lblBKNO2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
                                                                Font-Names="Verdana" Width="100px">BK No.</asp:Label></td>
                                                        <td style="width: 25%">
                                                            <asp:TextBox ID="txtBKNO2" onblur="makeUppercase(txtBKNO2);" TabIndex="7" runat="server" ForeColor="DarkBlue"
                                                                Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="4" Height="20px"></asp:TextBox></td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lblSetNo2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
                                                                Font-Names="Verdana" Width="100px">Set No.</asp:Label></td>
                                                        <td style="width: 25%">
                                                            <asp:TextBox ID="txtSetNo2" onblur="change(txtSetNo2);" TabIndex="8" runat="server" ForeColor="DarkBlue"
                                                                Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="3" Height="20px"></asp:TextBox></td>
                                                        <tr>
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lblBKNO3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
                                                                    Font-Names="Verdana" Width="100px">BK No.</asp:Label></td>
                                                            <td style="width: 25%">
                                                                <asp:TextBox ID="txtBKNO3" onblur="makeUppercase(txtBKNO3);" TabIndex="9" runat="server" ForeColor="DarkBlue"
                                                                    Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="4" Height="20px"></asp:TextBox></td>
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lblSetNo3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
                                                                    Font-Names="Verdana" Width="100px">Set No.</asp:Label></td>
                                                            <td style="width: 25%">
                                                                <asp:TextBox ID="txtSetNo3" onblur="change(txtSetNo3);" TabIndex="10" runat="server" ForeColor="DarkBlue"
                                                                    Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="3" Height="20px"></asp:TextBox></td>
                                                        </tr>
                                                    <tr>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lblBKNO4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
                                                                Font-Names="Verdana" Width="100px">BK No.</asp:Label></td>
                                                        <td style="width: 25%">
                                                            <asp:TextBox ID="txtBKNO4" onblur="makeUppercase(txtBKNO4);" TabIndex="11" runat="server" ForeColor="DarkBlue"
                                                                Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="4" Height="20px"></asp:TextBox></td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lblSetNo4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
                                                                Font-Names="Verdana" Width="100px">Set No.</asp:Label></td>
                                                        <td style="width: 25%">
                                                            <asp:TextBox ID="txtSetNo4" onblur="change(txtSetNo4);" TabIndex="12" runat="server" ForeColor="DarkBlue"
                                                                Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="3" Height="20px"></asp:TextBox></td>
                                                    </tr>--%>
									</table>
								</td>
							<tr>
								<td style="WIDTH: 50%; HEIGHT: 31px" align="center" colSpan="2">
									<p><asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Font-Bold="True">Browse the Images to Upload</asp:label><asp:label id="Label15" runat="server" Width="184px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Crimson"
											Font-Bold="True">(Select Atleast 5 Images)</asp:label></p>
								</td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image&nbsp;1&nbsp;</td>
								<td style="WIDTH: 50%; HEIGHT: 35px">
									<p><input id="File4" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File4" runat="server">
										<asp:label id="LblFile4" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Font-Bold="True" Visible="false"></asp:label><asp:checkbox id="CkBFile4" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="true" Visible="false"></asp:checkbox></p>
								</td>
								<P></P>
					</td>
				</tr>
				<tr>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
						2</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><input id="File5" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File5" runat="server">
							<asp:label id="LblFile5" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Visible="false"></asp:label><asp:checkbox id="CkBFile5" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="true" Visible="false"></asp:checkbox></p>
					</td>
				</tr>
				<tr>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image&nbsp;3&nbsp;</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><input id="File6" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File6" runat="server">
							<asp:label id="LblFile6" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Visible="false"></asp:label><asp:checkbox id="CkBFile6" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="true" Visible="false"></asp:checkbox></p>
					</td>
				</tr>
				<tr>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
						4</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><input id="File7" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File7" runat="server">
							<asp:label id="LblFile7" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Visible="false"></asp:label><asp:checkbox id="CkBFile7" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="true" Visible="false"></asp:checkbox></p>
					</td>
				</tr>
				<tr>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
						5</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><input id="File8" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File8" runat="server">
							<asp:label id="LblFile8" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Visible="false"></asp:label><asp:checkbox id="CkBFile8" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="true" Visible="false"></asp:checkbox></p>
					</td>
				</tr>
				<tr>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
						6</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><input id="File9" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File9" runat="server">
							<asp:label id="LblFile9" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Visible="false"></asp:label><asp:checkbox id="CkBFile9" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="true" Visible="false"></asp:checkbox></p>
					</td>
				</tr>
				<tr>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
						7</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><input id="File10" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File10" runat="server">
							<asp:label id="LblFile10" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Visible="false"></asp:label><asp:checkbox id="CkBFile10" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="true" Visible="false"></asp:checkbox></p>
					</td>
				</tr>
				<tr>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image&nbsp;8&nbsp;</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><input id="File11" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File11" runat="server">
							<asp:label id="LblFile11" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Visible="false"></asp:label><asp:checkbox id="CkBFile11" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="true" Visible="false"></asp:checkbox></p>
					</td>
				</tr>
				<tr>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image&nbsp;9&nbsp;</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><input id="File12" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File12" runat="server">
							<asp:label id="LblFile12" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Visible="false"></asp:label><asp:checkbox id="CkBFile12" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="true" Visible="false"></asp:checkbox></p>
					</td>
				</tr>
				<tr>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
						10&nbsp;</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><input id="File13" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File13" runat="server">
							<asp:label id="LblFile13" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" Visible="false"></asp:label><asp:checkbox id="CkBFile13" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" AutoPostBack="true" Visible="false"></asp:checkbox></p>
					</td>
				</tr>
			</table>
			</td></tr>
			<tr>
				<td align="center" colSpan="4"><asp:button id="btnSaveFiles" tabIndex="23" runat="server" Width="75px" Font-Names="Verdana"
						Font-Size="8pt" ForeColor="DarkBlue" Font-Bold="True" Text="Save Files"></asp:button><asp:button id="btnCancelFiles" tabIndex="24" runat="server" Width="67px" Font-Names="Verdana"
						Font-Size="8pt" ForeColor="DarkBlue" Font-Bold="True" Text="Cancel"></asp:button><asp:button id="btnViewIC" tabIndex="6" runat="server" Width="10%" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True" Text="View/Print IC"></asp:button></td>
				</TD></tr>
			<%--<tr>
                <td style="font-weight: bold; font-size: 8pt; width: 22.38%; color: darkblue; font-family: Verdana"
                    colspan="2" align="center">
                    <%--<asp:HyperLink ID="HyperLink1" runat="server">IC Photo Upload</asp:HyperLink><asp:Label ID="Label11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
                        Font-Bold="True">Upload the Photos first in case of Accepted or Rejection, before changing the Call Status.</asp:Label></td>
            </tr>--%>
			</TD></TR>
			<%--<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"
									colSpan="2" align="center"><asp:hyperlink id="HyperLink1" runat="server">IC Photo Upload</asp:hyperlink><asp:label id="Label3" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True">Upload the Photos first in case of Accepted or Rejection, before changing the Call Status.</asp:label></TD>
							</TR>--%>
			<%--<tr>
                <td style="font-weight: bold; font-size: 8pt; width: 22.38%; color: darkblue; font-family: Verdana">Case 
									Status</td>
                <td style="width: 70%">
                    <asp:DropDownList ID="lstCallStatus" TabIndex="1" runat="server" Width="30%" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="DarkBlue" AutoPostBack="True" OnChange="call_cancel_status();" OnSelectedIndexChanged="lstCallStatus_SelectedIndexChanged1">
                    </asp:DropDownList><asp:DropDownList ID="lstCallCancelStatus" TabIndex="2" runat="server" Width="30%" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="DarkBlue" AutoPostBack="True">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="C" Selected="True">Call Chargeable</asp:ListItem>
                        <asp:ListItem Value="N">Call Non-Chargeable</asp:ListItem>
                    </asp:DropDownList><asp:DropDownList ID="lstCallCancelCharges" TabIndex="2" runat="server" Width="88%" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="DarkBlue">
                        <asp:ListItem Selected="True"></asp:ListItem>
                        <asp:ListItem Value="3000">Before Visit of IE to Vendor's premises (Rs. 3000/- + S.T.)</asp:ListItem>
                        <asp:ListItem Value="10000">After Visit of IE to Vendor Premises - Local (Rs.10000/- + S.T.)</asp:ListItem>
                        <asp:ListItem Value="15000">After Visit of IE to Vendor Premises - Out Station (Rs. 15000/- + S.T.)</asp:ListItem>
                        <asp:ListItem Value="0">For Railway cases cancellation charges will be charged according to Railway Board Order No. 99/RS(G)/709/4 Dated: 12-02/2016</asp:ListItem>
                    </asp:DropDownList><asp:Label ID="lblCallStatus" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="OrangeRed" Font-Bold="True" Visible="False"></asp:Label><asp:TextBox ID="txtbksetno" runat="server" Width="14%" BackColor="AliceBlue" Font-Names="Verdana"
                            Font-Size="8pt" ForeColor="DarkBlue" Font-Bold="True" BorderStyle="None">BK &amp; Set No.</asp:TextBox><asp:TextBox onblur="makeUppercase();" ID="txtBKNO" TabIndex="3" runat="server" Width="48px"
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="4" Height="20px"></asp:TextBox><asp:TextBox onblur="change();" ID="txtSetNo" TabIndex="4" runat="server" Width="48px" Font-Names="Verdana"
                                    Font-Size="8pt" ForeColor="DarkBlue" MaxLength="3" Height="20px"></asp:TextBox></td>
            </tr>--%>
			<%--<tr>
                <td style="font-weight: bold; font-size: 8pt; width: 22.38%; color: darkblue; font-family: Verdana; height: 12px">
                    <asp:Label ID="Label32" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
                        Font-Bold="True">Remarks<Font Color="red">* (Max 400 Chars)</Font></asp:Label></td>
                <td style="width: 100%; height: 12px">
                    <asp:TextBox ID="txtRemarks" TabIndex="11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="DarkBlue" MaxLength="400" Height="50px" TextMode="MultiLine"></asp:TextBox><asp:Label ID="Label4" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
                            Font-Bold="True">* Add Rejection Remarks.</asp:Label><asp:Label ID="lblRemarks" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
                                ForeColor="OrangeRed" Font-Bold="True" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold; font-size: 8pt; width: 22.38%; color: darkblue; font-family: Verdana; height: 12px">
                    <asp:Label ID="Label5" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
                        Font-Bold="True">Holograms <Font Color="red">* (Max 250 Chars)</Font></asp:Label></td>
                <td style="width: 100%; height: 12px">
                    <asp:TextBox ID="txtHologram" TabIndex="11" runat="server" Width="100%" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="DarkBlue" MaxLength="300" Height="25px"></asp:TextBox><asp:Label ID="Label6" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
                            Font-Bold="True">* Enter series of Holograms Used on material and if Holograms not used then kindly mention type of seal & it's No..</asp:Label></td>
            </tr>--%>
			<tr>
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label9" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">IC Photo<Font Color="red">* IC (Digitally Signed PDF file Only)</Font></asp:label></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><input id="File1" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
						tabIndex="0" type="file" size="51" name="File1" runat="server"></td>
			</tr>
			<TR>
				<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label12" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">TESTPLAN/LAB TEST REPORTS (If Any)<Font Color="red">* TESTPLAN 
							(Digitally Signed PDF file Only)</Font></asp:label></TD>
				<TD style="WIDTH: 100%; HEIGHT: 12px"><INPUT id="File14" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
						tabIndex="0" type="file" size="51" name="File1" runat="server"></TD>
			</TR>
			<tr>
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label7" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">IC Annexue-I (If Any)<Font Color="red">* Annexure-I (Digitally 
							Signed PDF file Only)</Font></asp:label></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><input id="File2" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
						tabIndex="0" type="file" size="51" name="File1" runat="server"></td>
			</tr>
			<tr>
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label10" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">IC Annexue-II (If Any)<Font Color="red">* Annexure-II (Digitally 
							Signed PDF file Only)</Font></asp:label></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><input id="File3" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
						tabIndex="0" type="file" size="51" name="File1" runat="server"></td>
			</tr>
			<TR>
				<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label18" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True" Height="20px" Visible="False">Local or Outstation <Font Color="red">*</Font></asp:label></TD>
				<TD style="WIDTH: 100%; HEIGHT: 12px" align="left"><asp:dropdownlist id="lstRejectionType" runat="server" Width="50%" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" AutoPostBack="True" Visible="False"></asp:dropdownlist></TD>
			</TR>
			<TR>
				<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="lblMatValue" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True" Height="20px" Visible="False">Material Value</asp:label></TD>
				<TD style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtMatValue" style="TEXT-ALIGN: right" onfocus="total();" tabIndex="15" runat="server"
						Width="15%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="16" Height="20px" Enabled="False" Visible="False"></asp:textbox></TD>
			</TR>
			<TR>
				<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="lblRejCharges" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True" Visible="False">
						<Font Color="red">Rejection Charges * (Exclusive of Taxes)</Font></asp:label></TD>
				<TD style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtRejCharges" style="TEXT-ALIGN: right" onfocus="total();" runat="server" Width="15%"
						Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="11" Height="20px" Visible="False" Enabled="False"></asp:textbox></TD>
			</TR>
			<TR>
				<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 27px"><asp:label id="lblFIFO" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True" Height="20px" Visible="False">Reason For Voilating FIFO <Font Color="red">
							* (Max 400 Chars)</Font></asp:label></TD>
				<TD style="WIDTH: 100%; HEIGHT: 27px"><asp:textbox id="txtFIFO" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						MaxLength="400" Height="50px" Visible="False" TextMode="MultiLine"></asp:textbox></TD>
			</TR>
			<tr>
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Case 
					Status Date&nbsp;</td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtSTDT" onblur="check_date(txtSTDT);" runat="server" Width="88px" Font-Names="Verdana"
						Font-Size="8pt" ForeColor="DarkBlue" MaxLength="10" Height="20px"></asp:textbox><font face="Verdana" color="activecaption" size="1"><strong>&nbsp;(Current&nbsp;Date 
							Will be the&nbsp;Case Status Date&nbsp;i.e Date of 
							Cancellation/Acceptance..etc)</strong></font> </STYLE></td>
			</tr>
			<tr>
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"></td>
				<td style="WIDTH: 70%"><asp:button id="btnUploadFiles" tabIndex="26" runat="server" Width="100px" Font-Names="Verdana"
						Font-Size="8pt" ForeColor="DarkBlue" Font-Bold="True" Text="Upload Files"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnCancel" tabIndex="27" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True" Text="Cancel"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnSave" tabIndex="28" runat="server" Width="75px" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True" Text="Accepted!"></asp:button>
					<asp:label id="Label16" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">
						<Font Color="red">* Click on Accepted/Rejected Button after the Files are uploaded 
							for all the Consignee's</Font></asp:label></td>
			</tr>
			<TR>
				<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"
					align="center" colSpan="2"><asp:hyperlink id="HyperLinkIC" runat="server" Visible="False">View Inspection Certificate</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:hyperlink id="HyperLinkTestplan" runat="server" Visible="False">View Lab Test Reports/Testplan</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:hyperlink id="HyperLinkANN1" runat="server" Visible="False">View IC Annexure1</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:hyperlink id="HyperLinkANN2" runat="server" Visible="False">View IC Annexure2</asp:hyperlink></TD>
			</TR>
			<tr>
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"
					align="center" colSpan="2">
					<%--<asp:Button ID="btnViewIC" TabIndex="6" runat="server" Width="20%" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="DarkBlue" Font-Bold="True" Text="View/Print IC"></asp:Button></td>--%>
					<asp:button id="btnRefreshAll" tabIndex="23" runat="server" Width="90px" Font-Names="Verdana"
						Font-Size="8pt" ForeColor="DarkBlue" Font-Bold="True" Text="Refresh ALL"></asp:button><asp:label id="Label2" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">Refresh ALL<Font Color="red">* It will delete all the records 
							which are not accepted or rejected!)</Font></asp:label></td>
			</tr>
			</table></TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
