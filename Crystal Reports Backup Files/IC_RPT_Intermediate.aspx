<%@ Page Language="c#" CodeBehind="IC_RPT_Intermediate.aspx.cs" AutoEventWireup="false" Inherits="RBS.IC_RPT_Intermediate" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Call_Status_Edit_Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
		<script src="Scripts/jquery-1.10.2.min.js"></script>
		<script src="Scripts/jquery.easing-1.3.min.js"></script>
		<script src="Scripts/jquery.globalize.min.js"></script>
		<script src="Scripts/ej/ej.web.all.min.js"></script>
		<script src="Scripts/ej/ej.webform.min.js"></script>
		<script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
		<script src="date.js"></script>
		<script src="SessionManager.js"></script>
		<script type="text/javascript">
			var submit = 0;
			function CheckDoubleCLK() {
				if (++submit > 1) {
					alert('This sometimes takes a few min. - please be patient.');
					//document.getElementById("btnViewIC").style.display="none";
					document.getElementById("btnViewIC").disabled = true
					return false;
				}
			}
		</script>
		<script language="javascript">
        //
        function removespecialchar(sender) {
            var objSplChr = sender;
            var srtString = objSplChr.value;
            //var desired = srtString.replace(/'/g, '');
            
			// //var desired = srtString.replace(/'/g, '');
            
            //var desired = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,}$/;
            
            //var strquotes = "/("+"'"+")/g";
            
			// //var desired =  srtString.replace(/[ ](?=[ ])|[^-_A-Za-z0-9 ]+/g, '') ;
			
			var desired =  srtString.replace(/[ ](?=[ ])|[^-~`!@#$%^&*()=+:/\\;<,>.?_A-Za-z0-9 ]+/g, ' ') ;
			
            
            //var desired = srtString.replace("'", "",'g');
            //var desired = srtString.replace(/[^\w\s]/gi, '');

            objSplChr.value = desired;

        }
        //



        function checkTextAreaMaxLength(textBox, e, length) {

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }



        function ValidateDate(sender) {
            var sno = sender;
            var dateString = sno.value;
            //var dateString = document.getElementById(sender.controltovalidate).value;
            var regex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;
            if (regex.test(dateString)) {
                var parts = dateString.split("/");
                var dt = new Date(parts[1] + "/" + parts[0] + "/" + parts[2]);
                return (dt.getDate() == parts[0] && dt.getMonth() + 1 == parts[1] && dt.getFullYear() == parts[2])
            } else {
                //args.IsValid = false;
                //alert('Please enter date in valid format (DD/MM/YYYY)!');
                //sno.focus();
                return false;
            }
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
		<script>

		function abc(xmldata, xmlfilename)
		{
		//alert(xmldata);
		//var xml=encodeURI(xmldata);
		var xml=(xmldata);
		//alert(xml);
		$.post("http://127.0.0.1:1620", { "response": xml }, function (exeResponse) {

									//alert("IN function");
									var status = $(exeResponse).find("status").text();
									
									if (status == "failed") {
									// logic in case failed response
										//alert("Fail");
										//document.Form1.TextBox1.value = "Fail";
									}
									else {
				// logic in success response

				// sending signed data to aspx page
				//alert("Pass");
				//document.Form1.TextBox1.value = exeResponse;
				$.post("/RBS/PKIDATA.aspx",{ "file": exeResponse,"filename": xmlfilename }, function (res) {
				

		                                   window.location= "/RBS/IC_RPT_Intermediate.aspx?filename="+ res;
		                                   
										});
		                              
									}


								}).fail(function (xhr, textStatus, errorThrown) {
								// logic if signing solution exe is not running
								//alert("DSC is not running on the system!!!");
								//document.Form1.TextBox1.value = "Not Running";
								window.location= "/RBS/IC_RPT_Intermediate.aspx?filename="+ xmlfilename;
								});
		


		}
        </script>
	</HEAD>
	<body ms_positioning="GridLayout">
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
							Font-Size="10pt" ForeColor="DarkBlue" Font-Bold="True">IC REPORT EDIT FORM</asp:label></td>
				</tr>
				<tr>
					<td align="center">
						<table id="Table4" borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="97%" bgColor="#f0f8ff"
							border="1">
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Case 
									No.
								</td>
								<td style="WIDTH: 70%"><asp:label id="lblCSNO" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">Call 
									Serial No</td>
								<td style="WIDTH: 70%"><asp:label id="lblSNO" runat="server" Width="128px" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
										Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px">Call 
									Date</td>
								<td style="FONT-SIZE: 8pt; WIDTH: 70%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 16px"><asp:label id="lblCallDT" runat="server" Width="120px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="OrangeRed" Font-Bold="True"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b></b></td>
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
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">PO 
									AMENDMENTS</td>
								<td style="WIDTH: 30%; HEIGHT: 100%">
									<table id="TableAMND" style="HEIGHT: 50px" cellSpacing="0" cellPadding="0" width="80%"
										bgColor="aliceblue">
										<tr>
											<td><asp:label id="Label2" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
													Font-Bold="True">Amendments</asp:label></td>
											<td><asp:label id="Label3" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
													Font-Bold="True">Date (DD/MM/YYYY)</asp:label></td>
											<td><asp:label id="Label7" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
													Font-Bold="True">Action</asp:label></td>
										</tr>
										<tr>
											<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 50%; COLOR: darkblue; FONT-FAMILY: Verdana"><asp:textbox id="TxtAmnds" tabIndex="3" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt"
													ForeColor="DarkBlue" MaxLength="50" Height="30px"></asp:textbox></td>
											<td width="100"><asp:textbox id="TxtAmndsdt" onblur="check_date(TxtAmndsdt)" tabIndex="3" runat="server" Width="100%"
													Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="100" Height="30px"></asp:textbox></td>
											<td><asp:button id="BtnSaveAmnd" tabIndex="23" runat="server" Width="144px" Font-Names="Verdana"
													Font-Size="8pt" ForeColor="DarkBlue" Font-Bold="True" Text="Save Ammendments"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"
									colSpan="2">
									<table id="TableAMNDSaved" borderColor="#b0c4de" cellSpacing="0" cellPadding="0" width="100%"
										bgColor="aliceblue" border="1">
										<tr>
											<td colSpan="3"><asp:panel id="PanelAmned" runat="server" Width="100%" Height="100%"></asp:panel></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
							</tr>
							<TR>
								<td colSpan="2">
							<tr>
								<td align="center" colSpan="4">
									<table id="Table3" style="HEIGHT: 50px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
										width="80%" bgColor="aliceblue" border="1">
										<tbody>
											<tr>
												<td style="WIDTH: 47.53%; HEIGHT: 31px" align="center" colSpan="2">
													<table id="Table5" style="HEIGHT: 50px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
														width="50%" bgColor="aliceblue" border="1">
														<tbody>
															<tr>
																<td style="WIDTH: 10%"><asp:label id="LblConsignee" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
																		ForeColor="DarkBlue" Font-Bold="True">Consignee</asp:label></td>
												</td>
												<td style="WIDTH: 40%" colSpan="3"><asp:dropdownlist id="ddlCondignee" tabIndex="1" runat="server" Width="100%" Font-Names="Verdana"
														Font-Size="8pt" ForeColor="DarkBlue" align="center" AutoPostBack="True"></asp:dropdownlist></td>
											<tr>
												<td style="WIDTH: 10%"><asp:label id="LblItems" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
														ForeColor="DarkBlue" Font-Bold="True">Items</asp:label></td>
								</td>
								<td style="WIDTH: 40%"><asp:dropdownlist id="ddlItems" tabIndex="1" runat="server" Width="230px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" align="center" AutoPostBack="True"></asp:dropdownlist>
								<td style="HEIGHT: 10%"></td>
								<td style="HEIGHT: 40%"></td>
							</tr>
							<tr>
								<td style="WIDTH: 25%"><asp:label id="lblBKNO" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Font-Bold="True">BK No.</asp:label></td>
								<td style="WIDTH: 25%"><asp:textbox id="txtBKNO1" onblur="makeUppercase(txtBKNO1);" tabIndex="3" runat="server" Width="48px"
										Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="4" Height="20px" Enabled="False"></asp:textbox></td>
								<td style="HEIGHT: 25%"><asp:label id="lblSetNo" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Font-Bold="True">Set No.</asp:label></td>
								<td style="HEIGHT: 25%"><asp:textbox id="txtSetNo1" onblur="change(txtSetNo1);" tabIndex="4" runat="server" Width="48px"
										Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="3" Height="20px" Enabled="False"></asp:textbox></td>
							</tr>
						</table>
					</td>
				<tr>
					<td align="center" colSpan="2">
						<table id="TableEditables" style="HEIGHT: 50px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
							width="100%" bgColor="aliceblue" border="1">
							<tr id="Man_type" runat="server" visible="false">
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Consignee 
									Manufacture Type</td>
								<td style="WIDTH: 50%; HEIGHT: 30px"><asp:dropdownlist id="lstmantype" runat="server" Font-Names="Verdana" ForeColor="DarkBlue" AutoPostBack="True">
										<asp:ListItem Value="B" Selected="True">BHILAI STEEL PLANT</asp:ListItem>
										<asp:ListItem Value="J">JINDAL STEEL & POWER LTD</asp:ListItem>
										<asp:ListItem Value="O">Others</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="DES" runat="server">
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Consignee 
									DESCRIPTION</td>
								<td style="WIDTH: 50%; HEIGHT: 30px"><p><asp:textbox id="TxtCondigneedtl" onkeydown="checkTextAreaMaxLength(this,event,'200');" tabIndex="3"
											runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="4" Height="30px" Enabled="False"
											ToolTip="Check it to edit!" TextMode="MultiLine"></asp:textbox></p>
									<asp:checkbox id="ChkConsdtl" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Text="Check it to edit!" AutoPostBack="true" ToolTip="Check it to edit!"></asp:checkbox></td>
							</tr>
							<tr id="BPO_DES" runat="server">
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Bill 
									Paying Officer DESCRIPTION</td>
								<td style="WIDTH: 50%; HEIGHT: 30px"><p><asp:textbox id="TxtBPO" onkeydown="checkTextAreaMaxLength(this,event,'200');" tabIndex="4" runat="server"
											Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="4" Height="30px" Enabled="False" ToolTip="Check it to edit!"
											TextMode="MultiLine"></asp:textbox></p>
									<asp:checkbox id="ChkBPOdtl" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Text="Check it to edit!" AutoPostBack="true" ToolTip="Check it to edit!"></asp:checkbox></td>
							</tr>
							<tr id="GBPO_DES" runat="server">
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Governing 
									Bill Paying Authority</td>
								<td style="WIDTH: 50%; HEIGHT: 30px"><p><asp:textbox id="TextGBPO" onkeydown="checkTextAreaMaxLength(this,event,'200');" tabIndex="5"
											runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="4" Height="30px" Enabled="False"
											ToolTip="Check it to edit!" TextMode="MultiLine"></asp:textbox></p>
									<asp:checkbox id="ChecGBPOdt1" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Text="Check it to edit!" AutoPostBack="true" ToolTip="Check it to edit!"></asp:checkbox></td>
							</tr>
							<tr id="MAN_DSE" runat="server">
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Manufacturer 
									DESCRIPTION</td>
								<td style="WIDTH: 50%; HEIGHT: 30px"><p><asp:textbox id="TxtManufacturer" onkeydown="checkTextAreaMaxLength(this,event,'200');" tabIndex="6"
											runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="4" Height="30px" Enabled="False"
											ToolTip="Check it to edit!" TextMode="MultiLine"></asp:textbox></p>
									<asp:checkbox id="ChkManufacturerdtl" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
										Text="Check it to edit!" AutoPostBack="true" ToolTip="Check it to edit!"></asp:checkbox></td>
							</tr>
							<tr id="PA_DSE" runat="server">
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Purchasing 
									Authority DESCRIPTION</td>
								<td style="WIDTH: 50%; HEIGHT: 30px"><p><asp:textbox id="TxtPurchasingAuthority" onkeydown="checkTextAreaMaxLength(this,event,'200');"
											tabIndex="7" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="7" Height="30px"
											Enabled="False" ToolTip="Check it to edit!" TextMode="MultiLine"></asp:textbox></p>
									<asp:checkbox id="ChkPurchasingAuthoritydtl" runat="server" Font-Names="Verdana" Font-Size="8pt"
										ForeColor="DarkBlue" Text="Check it to edit!" AutoPostBack="true" ToolTip="Check it to edit!"></asp:checkbox></td>
							</tr>
							<tr id="OFF_INST_NO" runat="server">
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Offered 
									Inst. No.
								</td>
								<td style="WIDTH: 50%; HEIGHT: 30px"><p><asp:textbox id="TxtOFIN" tabIndex="8" runat="server" Width="30%" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" MaxLength="4" Height="50px" Enabled="False" ToolTip="Check it to edit!"></asp:textbox><asp:checkbox id="ChkOFINtlhk" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Text="Check it to edit!" AutoPostBack="true" ToolTip="Check it to edit!"></asp:checkbox></p>
								</td>
							</tr>
							<tr id="I_UOM" runat="server" visible="false">
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">ITEM 
									UNIT (UOM)</td>
								<td style="WIDTH: 50%; HEIGHT: 30px"><p><asp:textbox id="TxtUnit" tabIndex="9" runat="server" Width="30%" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" MaxLength="10" Height="50px" Enabled="False" ToolTip="Check it to edit!"></asp:textbox><asp:checkbox id="ChkUnitdtl" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Text="Check it to edit!" AutoPostBack="true" ToolTip="Check it to edit!"></asp:checkbox></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="I_DSE" runat="server">
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">ITEM 
						DESCRIPTION</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><asp:textbox id="TxtItemDesc" onkeydown="checkTextAreaMaxLength(this,event,'750');" onblur="removespecialchar(TxtItemDesc);"
								tabIndex="3" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								MaxLength="4" Height="50px" TextMode="MultiLine"></asp:textbox></p>
					</td>
				</tr>
				<tr id="I_REM" runat="server">
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">ITEM 
						REMARK</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><asp:textbox id="TxtItemRemarkeh" onkeydown="checkTextAreaMaxLength(this,event,'250');" onblur="removespecialchar(TxtItemRemarkeh);"
								tabIndex="3" runat="server" Width="70%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
								MaxLength="250" Height="50px" TextMode="MultiLine" Rows="2"></asp:textbox></p>
					</td>
				</tr>
				<tr id="QTY_ORD" runat="server">
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">
						<asp:label id="Labelqtyod" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True">Qty Ordered</asp:label></td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><asp:label id="TxtQTYORDERED" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True"></asp:label></p>
					</td>
				</tr>
				<tr id="CUM_PRE_OF" runat="server">
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">
						<asp:label id="Labelcumqtyoffer" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True">CUM QTY PREV OFFERED</asp:label></td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><asp:textbox id="TxtCUM_QTY_PREV_OFFERED" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" MaxLength="13"></asp:textbox><asp:label id="Label11" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
								Font-Bold="True">Only numeric is allowed!</asp:label></p>
					</td>
				</tr>
				<tr id="CUM_PRE_PA" runat="server">
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">CUM 
						QTY PREV PASSED</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><asp:textbox id="TxtCUM_QTY_PREV_PASSED" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True" MaxLength="13"></asp:textbox><asp:label id="Label12" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
								Font-Bold="True">Only numeric is allowed!</asp:label></p>
					</td>
				</tr>
				<tr id="QTY_INSP" runat="server">
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">QTY 
						TO INSP</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><asp:label id="TxtQTY_TO_INSP" runat="server" Width="100px" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" Font-Bold="True"></asp:label></p>
					</td>
				</tr>
				<tr id="QTY_PASS" runat="server">
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">
						<asp:label id="Labelqtypass" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
							ForeColor="DarkBlue" Font-Bold="True">QTY PASSED</asp:label></td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><asp:textbox id="TxtQTY_PASSED" tabIndex="3" runat="server" Width="30%" Font-Names="Verdana"
								Font-Size="8pt" ForeColor="DarkBlue" MaxLength="13" Height="20px"></asp:textbox><asp:label id="Label13" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
								Font-Bold="True">Only numeric is allowed!</asp:label></p>
					</td>
				</tr>
				<tr id="QTY_REJ" runat="server">
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">QTY 
						REJECTED</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><asp:textbox id="TxtQTY_REJECTED" tabIndex="3" runat="server" Width="30%" Font-Names="Verdana"
								Font-Size="8pt" ForeColor="DarkBlue" MaxLength="13" Height="20px"></asp:textbox><asp:label id="Label15" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
								Font-Bold="True">Only numeric is allowed!</asp:label></p>
					</td>
				</tr>
				<tr id="QTY_DUE" runat="server">
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">QTY 
						DUE</td>
					<td style="WIDTH: 50%; HEIGHT: 35px">
						<p><asp:textbox id="TxtQTY_DUE" tabIndex="3" runat="server" Width="30%" Font-Names="Verdana" Font-Size="8pt"
								ForeColor="DarkBlue" MaxLength="13" Height="20px"></asp:textbox><asp:label id="Label16" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
								Font-Bold="True">Only numeric is allowed!</asp:label></p>
					</td>
				</tr>
			</table>
			<tr id="REM_REJ" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label32" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True" Visible="False">Remarks<Font Color="red">* (Max 400 Chars)</Font></asp:label></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtRemarks" onkeydown="checkTextAreaMaxLength(this,event,'400');" onblur="removespecialchar(txtRemarks);"
						tabIndex="11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="400" Height="50px"
						TextMode="MultiLine" Visible="False" Rows="6"></asp:textbox><asp:label id="Label4" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
						Font-Bold="True" Visible="False">* Add Rejection Remarks.</asp:label><asp:label id="lblRemarks" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="OrangeRed" Font-Bold="True" Visible="False"></asp:label></td>
			</tr>
			<tr id="HOLO" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label5" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">Holograms <Font Color="red">* (Max 250 Chars)</Font></asp:label></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtHologram" onkeydown="checkTextAreaMaxLength(this,event,'250');" onblur="removespecialchar(txtHologram);"
						tabIndex="11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="250" Height="25px"
						TextMode="MultiLine" Rows="4"></asp:textbox><asp:label id="Label6" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
						Font-Bold="True">* Enter series of Holograms Used on material and if Holograms not used then kindly mention type of seal & it's No..</asp:label></td>
			</tr>
			<tr id="CASE_STAT_DT" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Case 
					Status Date&nbsp;</td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtSTDT" onblur="check_date(txtSTDT);" tabIndex="5" runat="server" Width="88px"
						Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="10" Height="20px" Enabled="False"></asp:textbox><font face="Verdana" color="activecaption" size="1"><strong>&nbsp;(Current&nbsp;Date 
							Will be the&nbsp;Case Status Date&nbsp;i.e Date of 
							Cancellation/Acceptance..etc)</strong></font> </STYLE></td>
			</tr>
			<tr id="LAB_RE" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Case 
					Lab report receipt Date (DD/MM/YYYY)&nbsp;</td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtLabtstrptdt" onblur="check_date(txtLabtstrptdt);" tabIndex="5" runat="server"
						Width="88px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="10" Height="20px"></asp:textbox></td>
			</tr>
			<tr id="PASS_INST" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">
					<asp:label id="Labelinst" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">Passed Instt. Note</asp:label></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="txtPassed_Inst_NO" tabIndex="11" runat="server" Width="30%" Font-Names="Verdana"
						Font-Size="8pt" ForeColor="DarkBlue" MaxLength="50" Height="25px"></asp:textbox></td>
			</tr>
			<tr id="VISIT_DT" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">
					<asp:label id="LabelVT" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">Visits Dates&nbsp;</asp:label></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="TXTVISITS_DATES" tabIndex="11" runat="server" Width="100%" Font-Names="Verdana"
						Font-Size="8pt" ForeColor="DarkBlue" MaxLength="300" Height="25px"></asp:textbox></td>
			</tr>
			<tr id="DIS_PAC_NO" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">
					<asp:label id="Label_dis_pac" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True">Dispatch Advice No.</asp:label><FONT color="red">* 
						(Max 500 Chars)</FONT></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="Textdispac" onkeydown="checkTextAreaMaxLength(this,event,'500');" onblur="removespecialchar(Textdispac);"
						tabIndex="21" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="500" Height="50px"
						TextMode="MultiLine" Rows="6"></asp:textbox></td>
			</tr>
			<tr id="INVOICE_NO" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label_inv_no" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True">Invoice No.</asp:label><FONT color="red">* 
						(Max 300 Chars)</FONT></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="Textinvoice" onkeydown="checkTextAreaMaxLength(this,event,'300');" onblur="removespecialchar(Textinvoice);"
						tabIndex="11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="300" Height="50px"
						TextMode="MultiLine" Rows="6"></asp:textbox></td>
			</tr>
			<tr id="NAME_INS_ENG" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label_Name_IE" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True">Name of Inspecting Engineer</asp:label><FONT color="red">* 
						(Max 500 Chars)</FONT></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="Textnameie" onkeydown="checkTextAreaMaxLength(this,event,'500');" onblur="removespecialchar(Textnameie);"
						tabIndex="11" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="500" Height="50px"
						TextMode="MultiLine" Rows="6"></asp:textbox></td>
			</tr>
			<tr id="CONS_DESG" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Labelcond" runat="server" Width="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">Consignee Destination</asp:label></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:textbox id="Textconsdesc" onkeydown="checkTextAreaMaxLength(this,event,'50');" onblur="removespecialchar(Textconsdesc);"
						tabIndex="11" runat="server" Width="80%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" MaxLength="50" Height="20px"></asp:textbox></td>
			</tr>
			<tr id="IE_STAMP" runat="server">
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px"><asp:label id="Label9" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">IE Stamp</asp:label></td>
				<td style="WIDTH: 100%; HEIGHT: 12px"><asp:dropdownlist id="ddlIELST" tabIndex="1" runat="server" Width="230px" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue"></asp:dropdownlist><asp:dropdownlist id="ddlIELST2" tabIndex="1" runat="server" Width="230px" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue"></asp:dropdownlist></td>
			</tr>
			<tr>
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"
					colSpan="2">
					<table id="TableVisitSaved" borderColor="#b0c4de" cellSpacing="0" cellPadding="0" width="100%"
						bgColor="aliceblue" border="1">
						<tr>
							<td colSpan="3"><asp:panel id="PanelVists" runat="server" Width="100%" Height="100%"></asp:panel></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"></td>
				<td style="WIDTH: 70%"><asp:button id="btnSaveICData" tabIndex="23" runat="server" Width="75px" Font-Names="Verdana"
						Font-Size="8pt" ForeColor="DarkBlue" Font-Bold="True" Text="Save"></asp:button><asp:button id="btnRefresh" tabIndex="23" runat="server" Width="75px" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True" Text="Refresh"></asp:button><asp:button id="btnCancel" tabIndex="7" runat="server" Width="67px" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True" Text="Cancel"></asp:button><asp:button id="btnViewIC" tabIndex="6" runat="server" Width="20%" Font-Names="Verdana" Font-Size="8pt"
						ForeColor="DarkBlue" Font-Bold="True" Text="Show Report!"></asp:button></td>
			</tr>
			<tr>
				<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana"
					align="center" colSpan="2"><asp:label id="Label8" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
						Font-Bold="True">Refresh<Font Color="red">* It will refresh the current records!</Font></asp:label>
					<%--<asp:Button ID="btnViewIC" TabIndex="6" runat="server" Width="20%" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="DarkBlue" Font-Bold="True" Text="View/Print IC"></asp:Button></TD>--%>
				</td>
			</tr>
		</form>
		</TBODY></TABLE></TD></TR></TBODY></TABLE>
		<%--<CR:CRYSTALREPORTVIEWER id="cristalview" runat="server" Width="350px" Height="50px" AutoDataBind="true"
			ToolPanelView="None" PrintMode="ActiveX"></CR:CRYSTALREPORTVIEWER>--%>
	</body>
</HTML>
