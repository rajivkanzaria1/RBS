<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBullGearforWag9.ascx.cs" Inherits="RBS.ProductPage.UCBullGearforWag9" %>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var vWidth = window.innerWidth -10- document.getElementById("Table4se").offsetWidth;
        document.getElementById('mydiv').setAttribute("style", "width:" + vWidth + "px; height:auto;overflow:scroll;border:solid 2px #b0c4de;overflow-y:hidden;overflow-x:scroll;");
        document.getElementById('divhead').setAttribute("style", "width:" + vWidth + "px; height:25px;font-size: 8pt;color: darkblue;border-right:solid 2px #b0c4de;border-left:solid 2px #b0c4de;border-top:solid 2px #b0c4de; font-family: Verdana;font-weight: bold; text-align:center;");

    });
    function calculatevi(e) {
        var vtxt = e;
        if (vtxt.value == 107) {
            document.getElementById(vtxt.id).style.borderColor = "black";
            document.getElementById(vtxt.id).style.color = "black";
        }
        else {
            document.getElementById(vtxt.id).style.borderColor = "red";
            document.getElementById(vtxt.id).style.color = "red";
        };
    };
    function calculateCompressed(e) {
        var vtxt = e;
        if (vtxt.value >= 785.8 && vtxt.value <= 786.8) {
            document.getElementById(vtxt.id).style.borderColor = "black";
            document.getElementById(vtxt.id).style.color = "black";
        }
        else {
            document.getElementById(vtxt.id).style.borderColor = "red";
            document.getElementById(vtxt.id).style.color = "red";
        };
    };
    function calculatedustcover(e) {
        var vtxt = e;
        if (vtxt.value >= 125 && vtxt.value <= 125.6) {
            document.getElementById(vtxt.id).style.borderColor = "black";
            document.getElementById(vtxt.id).style.color = "black";
        }
        else {
            document.getElementById(vtxt.id).style.borderColor = "red";
            document.getElementById(vtxt.id).style.color = "red";
        };
    };
    function TotalLength(e) {
        var vtxt = e;
        if (vtxt.value >= 189.5 && vtxt.value <= 180.5) {
            document.getElementById(vtxt.id).style.borderColor = "black";
            document.getElementById(vtxt.id).style.color = "black";
        }
        else {
            document.getElementById(vtxt.id).style.borderColor = "red";
            document.getElementById(vtxt.id).style.color = "red";
        };
    };
    function calculateTubediameter(e) {
        var vtxt = e;
        if (vtxt.value >= 317.09 && vtxt.value <= 317.17) {
            document.getElementById(vtxt.id).style.borderColor = "black";
            document.getElementById(vtxt.id).style.color = "black";
        }
        else {
            document.getElementById(vtxt.id).style.borderColor = "red";
            document.getElementById(vtxt.id).style.color = "red";
        };
    };
    function calculateBarDia(e) {
        var vtxt = e;
        if (vtxt.value >= 219 && vtxt.value <= 2019.029) {
            document.getElementById(vtxt.id).style.borderColor = "black";
            document.getElementById(vtxt.id).style.color = "black";
        }
        else {
            document.getElementById(vtxt.id).style.borderColor = "red";
            document.getElementById(vtxt.id).style.color = "red";
        };
    };
    function calculateBarCD(e) {
        var vtxt = e;
        if (vtxt.value >= 320.062 && vtxt.value <= 320.098) {
            document.getElementById(vtxt.id).style.borderColor = "black";
            document.getElementById(vtxt.id).style.color = "black";
        }
        else {
            document.getElementById(vtxt.id).style.borderColor = "red";
            document.getElementById(vtxt.id).style.color = "red";
        };
    };
    function calculateBarTotal(e) {
        var vtxt = e;
        if (vtxt.value >= 314 && vtxt.value <= 314.032) {
            document.getElementById(vtxt.id).style.borderColor = "black";
            document.getElementById(vtxt.id).style.color = "black";
        }
        else {
            document.getElementById(vtxt.id).style.borderColor = "red";
            document.getElementById(vtxt.id).style.color = "red";
        };
    };
    function calculateBarTotal1(e) {
        var vtxt = e;
        if (vtxt.value >= 320 && vtxt.value <= 320.14) {
            document.getElementById(vtxt.id).style.borderColor = "black";
            document.getElementById(vtxt.id).style.color = "black";
        }
        else {
            document.getElementById(vtxt.id).style.borderColor = "red";
            document.getElementById(vtxt.id).style.color = "red";
        };
    };
    function calculatehardnessthis(e) {
        var vtxt = e;
        if (vtxt.value == 78) {
            document.getElementById(vtxt.id).style.borderColor = "black";
            document.getElementById(vtxt.id).style.color = "black";
        }
        else {
            document.getElementById(vtxt.id).style.borderColor = "red";
            document.getElementById(vtxt.id).style.color = "red";
        };
    };
    function TotalItemInpect(e) {
        var vtxt1 = e;

        var Manual = parseInt(document.getElementById('<%= txtManualEntry.ClientID %>').value);
        var vtxt = parseInt(vtxt1.value);

        document.getElementById(txtManualEntry.id).style.borderColor = "black";
        document.getElementById(txtManualEntry.id).style.color = "black";
        if (vtxt1.value == "" || document.getElementById('<%= txtManualEntry.ClientID %>').value == "") {
            document.getElementById('<%=txtRange.ClientID%>').value = "";
            document.getElementById(txtManualEntry.id).style.borderColor = "red";
            document.getElementById(txtManualEntry.id).style.color = "red";
            document.getElementById('<%=txtRange.ClientID%>').value = "";
        }
        else {
            if (vtxt == Manual) {
                document.getElementById('<%=txtRange.ClientID%>').value = "";
            }
            else if (vtxt <= Manual) {
                document.getElementById('<%=txtRange.ClientID%>').value = "";
                document.getElementById(txtManualEntry.id).style.borderColor = "red";
                document.getElementById(txtManualEntry.id).style.color = "red";
            }
            else {
                var Tot = Manual + 1;
                document.getElementById('<%=txtRange.ClientID%>').value = Tot + " to " + vtxt;
            }
    }
};
function ManualEntry(e) {
    var vtxt1 = e;
    var Manual = parseInt(vtxt1.value);
    var vtxt = parseInt(document.getElementById('<%= txtNoOfPices.ClientID%>').value);

    document.getElementById(txtManualEntry.id).style.borderColor = "black";
    document.getElementById(txtManualEntry.id).style.color = "black";
    if (vtxt1.value == "" || document.getElementById('<%= txtNoOfPices.ClientID%>').value == "") {
        document.getElementById('<%=txtRange.ClientID%>').value = "";
        document.getElementById(txtManualEntry.id).style.borderColor = "red";
        document.getElementById(txtManualEntry.id).style.color = "red";
        document.getElementById('<%=txtRange.ClientID%>').value = "";
    }
    else {
        if (vtxt == Manual) {
            document.getElementById('<%=txtRange.ClientID%>').value = "";
        }
        else if (vtxt <= Manual) {
            document.getElementById('<%=txtRange.ClientID%>').value = "";
            document.getElementById(txtManualEntry.id).style.borderColor = "red";
            document.getElementById(txtManualEntry.id).style.color = "red";
        }
        else {
            var Tot = Manual + 1;
            document.getElementById('<%=txtRange.ClientID%>').value = Tot + " to " + vtxt;
        }
}
};
</script>
<table id="Table11" bordercolor="#b0c4de" cellspacing="0" cellpadding="1" width="100%"
	bgcolor="#f0f8ff" border="0">
	<tr>
		<td colspan="2" align="center">
			<table id="Table4" bordercolor="#b0c4de" cellspacing="0" cellpadding="1" width="97%" bgcolor="#f0f8ff"
				border="1">
				<tr>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 12.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">PL 
						NO</td>
					<td style="WIDTH: 13%; HEIGHT: 9px">
						<asp:TextBox ID="TXTPLNO" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Enabled="false"
							Font-Bold="True"></asp:TextBox></td>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 12.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">CASE 
						NO</td>
					<td style="WIDTH: 13%; HEIGHT: 9px">
						<asp:TextBox ID="txtCaseNo" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Enabled="false"
							Font-Bold="True"></asp:TextBox></td>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 12.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">BOOK 
						NO</td>
					<td style="WIDTH: 13%; HEIGHT: 9px">
						<asp:TextBox ID="txtBookNo" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"></asp:TextBox></td>
					<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 12.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">SET 
						NO</td>
					<td style="WIDTH: 13%; HEIGHT: 9px">
						<asp:TextBox ID="txtSetNo" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"></asp:TextBox></td>
				</tr>
			</table>
			<br>
		</td>
	</tr>
	<tr>
		<td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
			colspan="2" align="center">
			<asp:Panel runat="server" ID="pnlI">
				<TABLE borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="97%" bgColor="#f0f8ff"
					border="1">
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 15px">1. 
							&nbsp;&nbsp;&nbsp; P.O No. &amp; Date :
						</TD>
						<TD style="WIDTH: 70%">
							<asp:TextBox id="txtPoNo" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"></asp:TextBox><BR>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 15px">2. 
							&nbsp;&nbsp;&nbsp; Specification/Drawing :
						</TD>
						<TD style="WIDTH: 70%">
							<asp:Label id="lblSpecification" style="VERTICAL-ALIGN: top" Font-Bold="True" Font-Size="8pt"
								Font-Names="Verdana" Width="30%" runat="server" ForeColor="OrangeRed">SKDP-3848 ALT-NIL / MP.0.2800.19 REV.00 (OCT-2005)
                            </asp:Label><BR>
							<asp:TextBox id="txtSpecificationDrawing" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"
								Visible="false"></asp:TextBox><BR>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 15px">3. 
							&nbsp;&nbsp;&nbsp; Date of Inspection :
						</TD>
						<TD style="WIDTH: 70%">
							<asp:TextBox id="txtDateOfInspection" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"></asp:TextBox><BR>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">4. 
							&nbsp;&nbsp;&nbsp; Place of Inspection :
						</TD>
						<TD style="WIDTH: 70%">
							<asp:TextBox id="txtPlaceofInspection" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"
								TextMode="MultiLine"></asp:TextBox><BR>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">5. 
							&nbsp;&nbsp;&nbsp; Size of lot :
						</TD>
						<TD style="WIDTH: 70%">
							<asp:TextBox id="txtSizeofLog" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"></asp:TextBox><BR>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">6. 
							&nbsp;&nbsp;&nbsp; Size of Sample :
						</TD>
						<TD style="FONT-SIZE: 8pt; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana">
							<asp:TextBox id="txtOffered" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"></asp:TextBox><BR>
							(30% of the offered lot as per MP.0.2800.19 REV.00 (OCT-2005))
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">7. 
							&nbsp;&nbsp;&nbsp; Document Verification :
						</TD>
						<TD style="WIDTH: 70%">
							<asp:CheckBox id="chkDoc1" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
								ForeColor="OrangeRed" Text=" a) Internal/External test certificate for Row material"></asp:CheckBox><%--<asp:Label ID="Label2" runat="server">
                               </asp:Label>--%><BR>
							<asp:CheckBox id="chkDoc2" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
								ForeColor="OrangeRed" Text=" b) Internal test and dimensional check report"></asp:CheckBox><%-- <asp:Label ID="Label3" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
                                    Font-Bold="True"> </asp:Label>--%><BR>
							<asp:CheckBox id="chkDoc3" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
								ForeColor="OrangeRed" Text=" c) Heat treatment, case depth, hardness, macro &amp; micro examination and shot peening reports"></asp:CheckBox><%--<asp:Label ID="Label4" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
                                    Font-Bold="True"></asp:Label>--%><BR>
							<asp:CheckBox id="chkDoc4" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
								ForeColor="OrangeRed" Text=" d) MPI &amp; UT reports"></asp:CheckBox><%--<asp:Label ID="Label5" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" ForeColor="OrangeRed"
                                    Font-Bold="True"> </asp:Label>--%><BR>
							<asp:CheckBox id="chkDoc5" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
								ForeColor="OrangeRed" Text=" e) Manufacturer certificate for minimum reduction ratio of 4:1"></asp:CheckBox><BR>
							<asp:CheckBox id="chkDoc6" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
								ForeColor="OrangeRed" Text=" f) Calibration record of gauges, measuring instruments &amp; test equipment."></asp:CheckBox><BR>
							<asp:CheckBox id="chkDoc7" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
								ForeColor="OrangeRed" Text=" g) Raw material shall be as per clause 2.1 of MP.0.2800.19 REV.00 (oct-2005)"></asp:CheckBox><BR>
							<asp:CheckBox id="chkDoc8" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
								ForeColor="OrangeRed" Text=" h)&#9;Guarantee Certificate for a period of min. 72 months (six years) of reliable service or as agreed between supplier and purchaser."></asp:CheckBox><BR>
						</TD>
					</TR>
					<TR id="trTrstCheck" runat="server">
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 82.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="2">8. &nbsp;&nbsp;&nbsp; Test/Checks(to be witnessed by inspector)
						</TD>
					</TR>
				</TABLE>
				<TABLE borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="97%" bgColor="#f0f8ff"
					border="1">
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">S.No</TD>
						<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Parameter</TD>
						<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Value 
							Specified</TD>
						<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 32%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="2">Observation</TD>
						<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Remarks</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">1.</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Visual
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 33%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<P>1. The surface texture of the fitting surface (bore of the gear) shall not be 
								coarser than the values specified in the relevant drawing.</P>
							<P>2. No discontinuity/ step formation from the ground tooth flank and the machined 
								root fillet shall be permitted.
							</P>
							<P>3. The gear/pinion should be free from sharp edges.
							</P>
							<P>4. The working face of the teeth shall be free from defects such as 
								heterogeneity in metal and forging/cutting/grinding imperfections. Any repair 
								of these surface defects shall be prohibited.
							</P>
							<P>5. The end faces of the teeth shall also not show defects similar S. No. 2 above 
								particularly near root circle. No welding shall be permitted.
							</P>
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservA" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassA" runat="server" Text="Pass" OnCheckedChanged="rdoPassA_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitA"></asp:RadioButton>
							<asp:RadioButton id="rdoFailA" runat="server" Text="Fail" OnCheckedChanged="rdoPassA_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitA"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Clause 9.3,9.4,9.7,9.8 & 9.9 of RDSO Specn.No. MP.0.2800.19 REV.00(OCT-2005)</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px; TEXT-ALIGN: right"
							colSpan="6">
							<asp:Button id="btnShowtbl2" onclick="btnShowtbl2_Click" Width="160" runat="server" Text="Next "></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel runat="server" ID="pnlII" Visible="false">
				<TABLE borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="97%" bgColor="#f0f8ff"
					border="1">
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">S.No</TD>
						<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Parameter</TD>
						<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="4">Value Specified</TD>
						<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 32%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="2">Observation</TD>
						<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Remarks</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">2.</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 96%; COLOR: darkblue; FONT-FAMILY: Verdana"
							colSpan="8">Materail Testing
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="10">2a</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="10">Chemical Composition (one sample per cast)</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 3%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="2">Sr.No</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="2">Element</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="2">I7CrNiMo6 TO DIN 17210
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="10">
							<asp:TextBox id="txtObservB" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="10">
							<asp:RadioButton id="rdoPassB" runat="server" Text="Pass" OnCheckedChanged="rdoPassB_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitB"></asp:RadioButton>
							<asp:RadioButton id="rdoFailB" runat="server" Text="Fail" OnCheckedChanged="rdoPassB_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitB"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="10">As per Table 1 of <U>MP.0.2800.19</U><U>REV.00 (OCT-2005)</U></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Minimum
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Maximum
						</TD>
					</TR>
					<asp:Repeater id="repeaterChemical" runat="server">
						<ItemTemplate>
							<tr>
								<td style="font-size: 8pt; width: 2%; color: darkblue; font-family: Verdana; padding-left: 10px; vertical-align: top;">
									<asp:Label runat="server" ID="lblSNo" Text='<%# DataBinder.Eval(Container.DataItem, "SNo") %>'>
									</asp:Label>
								</td>
								<td style="font-size: 8pt; width: 7%; color: darkblue; font-family: Verdana; padding-left: 10px; vertical-align: top;">
									<asp:Label runat="server" ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Element") %>'>
									</asp:Label>
								</td>
								<td style="font-size: 8pt; width: 7%; color: darkblue; width: 50px; font-family: Verdana; padding-left: 10px; vertical-align: top;">
									<asp:Label runat="server" ID="Label2" Text='<%# DataBinder.Eval(Container.DataItem, "FromRange") %>'>
									</asp:Label>
								</td>
								<td style="font-size: 8pt; width: 7%; color: darkblue; width: 50px; font-family: Verdana; padding-left: 10px; vertical-align: top;">
									<asp:Label runat="server" ID="Label3" Text='<%# DataBinder.Eval(Container.DataItem, "ToRange") %>'>
									</asp:Label>
								</td>
							</tr>
						</ItemTemplate>
					</asp:Repeater>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="6">2b</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="6">Mechanical properties (one sample I per cast)</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 3%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">S.No</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Element</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="2"></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="6">
							<asp:TextBox id="txtObservC" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="6">
							<asp:RadioButton id="rdoPassC" runat="server" Text="Pass" OnCheckedChanged="rdoPassC_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitC"></asp:RadioButton>
							<asp:RadioButton id="rdoFailC" runat="server" Text="Fail" OnCheckedChanged="rdoPassC_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitC"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							rowSpan="6">As per Table 2 of <U>MP.0.2800.19 REV.00 (OCT-2005)</U>
						</TD>
					</TR>
					<asp:Repeater id="repeaterMachanical" runat="server">
						<ItemTemplate>
							<tr>
								<td style="font-size: 8pt; width: 2%; color: darkblue; font-family: Verdana; padding-left: 10px; vertical-align: top;">
									<asp:Label runat="server" ID="lblMacSNo" Text='<%# DataBinder.Eval(Container.DataItem, "SNo") %>'>
									</asp:Label>
								</td>
								<td style="font-size: 8pt; width: 7%; color: darkblue; font-family: Verdana; padding-left: 10px; vertical-align: top;"
									colspan="2">
									<asp:Label runat="server" ID="lblMacEle" Text='<%# DataBinder.Eval(Container.DataItem, "Element") %>'>
									</asp:Label>
								</td>
								<td style="font-size: 8pt; width: 7%; color: darkblue; width: 50px; font-family: Verdana; padding-left: 10px; vertical-align: top;">
									<asp:Label runat="server" ID="lblMacFromRang" Text='<%# DataBinder.Eval(Container.DataItem, "FromRange") %>'>
									</asp:Label>
								</td>
							</tr>
						</ItemTemplate>
					</asp:Repeater>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">2c.</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Inclusion 
							rating
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="4">The inclusion rating of the steel shall not exceed A,=2.5-1.5, 
							B=2-1, C-0.5-0.5 &amp; D=1-1 for both thin &amp; thick series.
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservD" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassD" runat="server" Text="Pass" OnCheckedChanged="rdoPassD_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitD"></asp:RadioButton>
							<asp:RadioButton id="rdoFailD" runat="server" Text="Fail" OnCheckedChanged="rdoPassD_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitD"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">As 
							per DIN 3990 part 5 or IS: 41 63
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px; TEXT-ALIGN: right"
							colSpan="9">
							<asp:Button id="tbn2Back" onclick="tbn2Back_Click" Width="160" runat="server" Text="Back"></asp:Button>
							<asp:Button id="tbn3Next" onclick="tbn3Next_Click" Width="160" runat="server" Text="Next "></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel runat="server" ID="pnlIII" Visible="false">
				<TABLE borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="97%" bgColor="#f0f8ff"
					border="1">
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">3.</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 96%; COLOR: darkblue; FONT-FAMILY: Verdana"
							colSpan="5">Tests on Rough Forged Gear Blanks<BR>
							Note: (1) To be witnessed in case of stage inspection. (ii) To be reviewed in 
							case of final inspection.
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">3a</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Macro 
							etch test
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">It 
							shall reveal satisfactory flow line pattern right up to the centre of the 
							forged blank. Note: This test will be done at the work of the forging supplier 
							by the manufacturer.
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservE" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassE" runat="server" Text="Pass" OnCheckedChanged="rdoPassE_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitE"></asp:RadioButton>
							<asp:RadioButton id="rdoFailE" runat="server" Text="Fail" OnCheckedChanged="rdoPassE_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitE"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Test 
							method as per DIN 3990 Part 5 or ASTM E381
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">3b</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Microstruct- 
							ure and Grain Size</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Range 
							6 or finer grained structure
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservF" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassF" runat="server" Text="Pass" OnCheckedChanged="rdoPassF_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitF"></asp:RadioButton>
							<asp:RadioButton id="rdoFailF" runat="server" Text="Fail" OnCheckedChanged="rdoPassF_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitF"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Test 
							method as per DIN 3990 Part 5
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">3c</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Ultrasonic 
							Test</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">All 
							forged blanks shall be ultrasonically tested before and after machining for 
							ensuring freedom from casting and forging defects.
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservG" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassG" runat="server" Text="Pass" OnCheckedChanged="rdoPassG_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitG"></asp:RadioButton>
							<asp:RadioButton id="rdoFailG" runat="server" Text="Fail" OnCheckedChanged="rdoPassG_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitG"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Test 
							method as per DIN 3990 Part S or Appendix A of MP.0.2800.19 REV.00 (OCT-2005)</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">3d</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Hardness 
							Test</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">170-220 HB
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservH" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassH" runat="server" Text="Pass" OnCheckedChanged="rdoPassH_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitH"></asp:RadioButton>
							<asp:RadioButton id="rdoFailH" runat="server" Text="Fail" OnCheckedChanged="rdoPassH_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitH"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Test 
							method as per DIN 3990 Part 5 or IS:1500
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">4.</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 96%; COLOR: darkblue; FONT-FAMILY: Verdana"
							colSpan="5">Tests after Pre machining Heat Treatment of forged Blanks Note: (i) 
							To be witnessed in case of stage inspection. <B>(ii) To be reviewed to case of 
								final inspection.</B>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">4a</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Case 
							Depth</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">1.8 
							mm to 2.2 mm (At which a hardness of 500 HV 30 (5ORC] is obtained)
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservI" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassI" runat="server" Text="Pass" OnCheckedChanged="rdoPassI_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitI"></asp:RadioButton>
							<asp:RadioButton id="rdoFailI" runat="server" Text="Fail" OnCheckedChanged="rdoPassI_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitI"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">As 
							per Clause 8.2. I of RDSO Specification No.MP.0.2800.19 REV.00 (OCT-2005)
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">4b</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Micro 
							Examination (One test piece per batch
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Cementite 
							network or free cementite should not exist. Retained austenite content of 15-30 
							% may be permitted.
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservJ" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassJ" runat="server" Text="Pass" OnCheckedChanged="rdoPassJ_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitJ"></asp:RadioButton>
							<asp:RadioButton id="rdoFailJ" runat="server" Text="Fail" OnCheckedChanged="rdoPassJ_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitJ"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">As 
							per DIN 3990 Part 5 or IS:4432 —-1988
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-RIGHT: 2%; PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px; TEXT-ALIGN: right"
							colSpan="6">
							<asp:Button id="tbn3Back" onclick="tbn3Back_Click" Width="160" runat="server" Text="Back"></asp:Button>
							<asp:Button id="btn3Next" onclick="btn3Next_Click" Width="160" runat="server" Text="Next "></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel runat="server" ID="pnlIV" Visible="false">
				<TABLE borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="97%" bgColor="#f0f8ff"
					border="1">
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">5</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Shot 
							Peening
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="4">Shot peen teeth & root section of teeth before grinding tooth profile 
							using S330 hard shots to obtain 200% Min . coverage in root area. Peening 
							intensity should be between 0.007 to 0.0100C
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservK" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassK" runat="server" Text="Pass" OnCheckedChanged="rdoPassK_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitK"></asp:RadioButton>
							<asp:RadioButton id="rdoFailK" runat="server" Text="Fail" OnCheckedChanged="rdoPassK_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitK"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Clause 
							No 10 of RDSQ Specn. No. MP.0.2800.19 REV.00 (OCT- 2005)
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">6.</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 96%; COLOR: darkblue; FONT-FAMILY: Verdana"
							colSpan="8">Acceptaance tests<BR>
							Note : To be witnessed as part of final inspection
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">6a</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Dimensional</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="4">As per SKDP-3848 ALT-NIL. Dimension sheet attached
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservL" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassL" runat="server" Text="Pass" OnCheckedChanged="rdoPassL_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitL"></asp:RadioButton>
							<asp:RadioButton id="rdoFailL" runat="server" Text="Fail" OnCheckedChanged="rdoPassL_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitL"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">6b</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Surface 
							Hardness</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="4">60 — 62 RC
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservM" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassM" runat="server" Text="Pass" OnCheckedChanged="rdoPassM_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitM"></asp:RadioButton>
							<asp:RadioButton id="rdoFailM" runat="server" Text="Fail" OnCheckedChanged="rdoPassM_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitM"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">As 
							per Note 2 of Drg No.SKDP-3848 ALT-NIL
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">6c</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Crack 
							Detection</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="4">All the finished gears should be subjected to crack detection by 
							magnaflux inspection as per IS:3703.
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservN" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassN" runat="server" Text="Pass" OnCheckedChanged="rdoPassN_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitN"></asp:RadioButton>
							<asp:RadioButton id="rdoFailN" runat="server" Text="Fail" OnCheckedChanged="rdoPassN_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitN"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">As 
							per note 11 of drawing No. SKDP-3848 ALT- NIL and as per clause 11.2(a) iii of 
							RDSO Specification No.MP.0.2800.19 REV.00(OCT-2005)
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">6d</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Tooth 
							Error/ Deviation</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="4">Double Flank Total Composite Error: 0.056 Base Pitch Error: 0.016 
							Tooth to Tooth Pitch Error: 0.02 Profile Error: 0.02 Radial Run Out: 0.05 Flank 
							Angle Error: 0.016
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservO" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassO" runat="server" Text="Pass" OnCheckedChanged="rdoPassO_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitO"></asp:RadioButton>
							<asp:RadioButton id="rdoFailO" runat="server" Text="Fail" OnCheckedChanged="rdoPassO_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitO"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">As 
							per Drg No SKDP-3848 ALT NIL
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">7</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Marking</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="4">
							<P>All gears shall bear the following I markings on both end faces (By punching I 
								or by electrical etching) which should be , indelible and clearly legible.
							</P>
							<P>a) Name of Supplier/manufacturer</P>
							<P>b) Number of month and last two digits of the year of manufacture e.g. 5/96 
								&amp; Gear ratio</P>
							<P>c) Material and specification of steel</P>
							<P>d) Drawing number of the part</P>
							<P>e) Manufacture/Consecutive number of-the part</P>
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservP" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassP" runat="server" Text="Pass" OnCheckedChanged="rdoPassP_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitP"></asp:RadioButton>
							<asp:RadioButton id="rdoFailP" runat="server" Text="Fail" OnCheckedChanged="rdoPassP_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitP"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Note- 
							4 of Drg No-SKDP-3848 ALT-NIL
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">8</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Protection 
							&amp; Packing</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="4">The gears shall be suitably protected against oxidation and 
							corrosion by three coats of ready mixed paint brushing Bituminous to IS 158 or 
							with any other approved anti-rust compound capable of being removed easily by 
							white spirit or kerosene oil, allowing sufficient drying time between each 
							coat. After the last coat has dried, the gear shall be covered with waterproof 
							paper. The gears shall then suitably be placed to prevent any damage during 
							transport and handling.
						</TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtObservQ" style="HEIGHT: 100%; width:100%;MIN-HEIGHT: 140pxMIN-HEIGHT: 140px" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:RadioButton id="rdoPassQ" runat="server" Text="Pass" OnCheckedChanged="rdoPassQ_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitQ"></asp:RadioButton>
							<asp:RadioButton id="rdoFailQ" runat="server" Text="Fail" OnCheckedChanged="rdoPassQ_CheckedChanged"
								AutoPostBack="true" GroupName="grpWitQ"></asp:RadioButton></TD>
						<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Clause 
							No- 15of RDSO Specification No-MP.0.2800.19 REV.00 (OCT-2005)
						</TD>
					</TR>
					<asp:Repeater id="repaterTstChecks" runat="server">
						<ItemTemplate>
							<tr>
								<td style="font-size: 8pt; width: 2%; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
									<asp:Label runat="server" ID="lblSNo" Text='<%# DataBinder.Eval(Container.DataItem, "S_No") %>'>
									</asp:Label>)
								</td>
								<td style="font-size: 8pt; width: 20%; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
									<asp:TextBox runat="server" ID="txtParameter1" Text='<%# DataBinder.Eval(Container.DataItem, "Parameter") %>' Style="width: 100%" TextMode="MultiLine">
									</asp:TextBox>
								</td>
								<td style="font-size: 8pt; width: 23%; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;"
									colspan="4">
									<asp:TextBox runat="server" ID="txtValueSpecified" Style="width: 100%" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "ValueSpeci") %>'>
									</asp:TextBox>
								</td>
								<td style="font-size: 8pt; width: 22%; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
									<asp:TextBox runat="server" ID="txtObservation" TextMode="MultiLine" Style="width: 100%" Text='<%# DataBinder.Eval(Container.DataItem, "Observation") %>'>
									</asp:TextBox>
								</td>
								<td style="font-size: 8pt; width: 10%; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
									<asp:RadioButton runat="server" ID="rdoTestExtra1" Text="Pass" Checked='<%# DataBinder.Eval(Container.DataItem, "StatusPass") %>' GroupName="TestExtra" />
									<asp:RadioButton runat="server" ID="rdoTestExtra2" Text="Fail" GroupName="TestExtra" />
								</td>
								<td style="font-size: 8pt; width: 20%; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
									<asp:TextBox runat="server" ID="txtRemarks" Text='<%# DataBinder.Eval(Container.DataItem, "Remarks") %>' Style="width: 100%" TextMode="MultiLine">
									</asp:TextBox>
								</td>
							</tr>
						</ItemTemplate>
					</asp:Repeater>
					<TR>
						<TD style="PADDING-RIGHT: 2%; PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							colSpan="9">
							<asp:LinkButton id="lnkAdd" onclick="lnkAdd_Click" Font-Bold="true" runat="server">+ Add</asp:LinkButton></TD>
					</TR>
					<TR>
						<TD style="PADDING-RIGHT: 2%; PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px; TEXT-ALIGN: right"
							colSpan="9">
							<asp:Button id="tbn4Back" onclick="tbn4Back_Click" Width="160" runat="server" Text="Back"></asp:Button>
							<asp:Button id="btn4next" onclick="btn4next_Click" Width="160" runat="server" Text="Next "></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel runat="server" ID="pnlV" Visible="false">
				<TABLE borderColor="#b0c4de" cellSpacing="0" cellPadding="1" width="97%" bgColor="#f0f8ff"
					border="1">
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px; TEXT-ALIGN: left"
							colSpan="2">
							<P>Note: i) Sampling shall be done according to IS; 2500 - 2000 Pt I single 
								sampling plan (normal) unless mentioned otherwise io In case a quality plan is 
								mentioned in the Purchase Order, Inspecting Engineer shall also take the same 
								into consideration during inspection, and mention the same in htspection 
								Records. iii) In case purchase order mentions different drawing/specification, 
								then that will be applicable.</P>
							<P><SPTRONG>Important</SPTRONG>
							</P>
							<P style="PADDING-LEFT: 30px">1. Cross check original PO.<BR>
								2. In case place of inspection is mentioned in PO, do not undertake inspection 
								elsewhere.<BR>
								3. Do not undertake inspection if quantity offered is less than quantity 
								mentioned in call letter. Do not inspect part quantity unless provided in PO or 
								authorized by client.
								<BR>
								4. Remember to stamp/seal complete material after drawing samples for lab 
								testing and before leaving site.
								<BR>
								5. Use check sheet for recording observations.
							</P>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px; TEXT-ALIGN: center"
							colSpan="2">DIMENSIONS as per Dig No.SKEW-3848 ALT-NIL
						</TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							align="center" colSpan="2"><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">1. 
							&nbsp;&nbsp;&nbsp; Total no of sample to be inspected :
						</TD>
						<TD style="WIDTH: 70%">
							<asp:TextBox id="txtNoOfPices" onkeyup="TotalItemInpect(this);" runat="server" Text="5"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
							<SPAN style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
								Manual Entry</SPAN>
							<asp:TextBox id="txtManualEntry" onkeyup="ManualEntry(this);" runat="server" Text="5"></asp:TextBox>
							<asp:Button id="btnNoOfPices" onclick="btnNoOfPices_Click" runat="server" Text="Show"></asp:Button><SPAN style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Range</SPAN>
							<asp:TextBox id="txtRange" Enabled="false" runat="server" ReadOnly="true"></asp:TextBox><BR>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"></TD>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: orangered; FONT-FAMILY: Verdana; HEIGHT: 9px">Example 
							:- Total Item 100, manual entry 50 ,range 51 to 100
							<BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
							align="center" colSpan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="97%">
								<TR>
									<TD style="VERTICAL-ALIGN: top; HEIGHT: 220px" width="40%">
										<TABLE id="Table4se" borderColor="#b0c4de" cellSpacing="0" cellPadding="1" bgColor="#f0f8ff"
											border="1">
											<TR style="HEIGHT: 27px">
												<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">S.No
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Parameter
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Specified(mm)
												</TD>
											</TR>
											<TR style="HEIGHT: 26px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">1.
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">No 
													of Teeth
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">107
												</TD>
											</TR>
											<TR style="HEIGHT: 26px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">2.
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Teeth 
													OD
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">786.3(±0.5)
												</TD>
											</TR>
											<TR style="HEIGHT: 35px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">3.
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Teeth 
													Length
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">125(+0,-0.60)
												</TD>
											</TR>
											<TR style="HEIGHT: 35px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">4.
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Total 
													Length
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">180(±0.5)
												</TD>
											</TR>
											<TR style="HEIGHT: 52px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">5.
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Base 
													tangent length over 15 Teeth
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">317.09 
													Min./ 317.17 Max.
												</TD>
											</TR>
											<TR style="HEIGHT: 26px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">6.
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Bore
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">219 
													(+0.00,+0.029)
												</TD>
											</TR>
											<TR style="HEIGHT: 26px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">7.
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">OD 
													1
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">320(+0.062,+0.098)
												</TD>
											</TR>
											<TR style="HEIGHT: 26px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">8.
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">OD 
													2
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">314 
													(-0.000,-0.032)
												</TD>
											</TR>
											<TR style="HEIGHT: 26px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">9.
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">OD 
													3
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">320(-0.00,-0.14)											</TD>
											</TR>
											<TR style="HEIGHT: 26px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">10.
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Hardness
												</TD>
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">60 
													— 62 HRC
												</TD>
											</TR>
											<TR style="HEIGHT: 20px">
												<TD style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
													colSpan="3"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD style="VERTICAL-ALIGN: top; HEIGHT: auto" width="60%">
										<DIV id="divhead">
											<asp:Literal id="litHeadDimension" runat="server"></asp:Literal></DIV>
										<DIV id="mydiv" style="BORDER-RIGHT: orange 2px solid; BORDER-TOP: orange 2px solid; OVERFLOW-Y: hidden; OVERFLOW-X: scroll; OVERFLOW: scroll; BORDER-LEFT: orange 2px solid; BORDER-BOTTOM: orange 2px solid">
											<TABLE cellSpacing="0" cellPadding="1" border="1">
												<TR style="HEIGHT: 25px">
													<asp:Repeater id="rpt1" runat="server">
														<ItemTemplate>
															<td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
																<asp:Label runat="server" ID="hidDimCD1" Text="DIMW0000541" Visible="false" />
																<asp:Label runat="server" ID="hidParameter1" Text="No of Teeth" Visible="false" />
																<asp:Label runat="server" ID="hidValue1" Text="107" Visible="false" />
																<asp:TextBox runat="server" ID="txtV1" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' Width="60" onkeyup="calculatevi(this);">
																</asp:TextBox>
															</td>
														</ItemTemplate>
													</asp:Repeater>
													<TD>
														<asp:TextBox id="txtRange1" onkeyup="calculatevi(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></TD>
												</TR>
												<TR style="HEIGHT: 25px">
													<asp:Repeater id="rpt2" runat="server">
														<ItemTemplate>
															<td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
																<asp:Label runat="server" ID="hidDimCD2" Text="DIMW0000542" Visible="false" />
																<asp:Label runat="server" ID="hidParameter2" Text="Teeth OD" Visible="false" />
																<asp:Label runat="server" ID="hidValue2" Text="786.3 (+0.5)" Visible="false" />
																<asp:TextBox runat="server" ID="txtV2" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculateCompressed(this);">
																</asp:TextBox>
															</td>
														</ItemTemplate>
													</asp:Repeater>
													<TD>
														<asp:TextBox id="txtRange2" onkeyup="calculateCompressed(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></TD>
												</TR>
												<TR style="HEIGHT: 35px">
													<asp:Repeater id="rpt3" runat="server">
														<ItemTemplate>
															<td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
																<asp:Label runat="server" ID="hidDimCD3" Text="DIMW0000543" Visible="false" />
																<asp:Label runat="server" ID="hidParameter3" Text="Teeth Length" Visible="false" />
																<asp:Label runat="server" ID="hidValue3" Text="125(+0,-0.60)" Visible="false" />
																<asp:TextBox runat="server" ID="txtV3" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculatedustcover(this);">
																</asp:TextBox>
															</td>
														</ItemTemplate>
													</asp:Repeater>
													<TD>
														<asp:TextBox id="txtRange3" onkeyup="calculatedustcover(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></TD>
												</TR>
												<TR style="HEIGHT: 35px">
													<asp:Repeater id="rpt4" runat="server">
														<ItemTemplate>
															<td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
																<asp:Label runat="server" ID="hidDimCD4" Text="DIMW0000544" Visible="false" />
																<asp:Label runat="server" ID="hidParameter4" Text="Total Length" Visible="false" />
																<asp:Label runat="server" ID="hidValue4" Text="180 (+0.5)" Visible="false" />
																<asp:TextBox runat="server" ID="txtV4" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="TotalLength(this);">
																</asp:TextBox>
															</td>
														</ItemTemplate>
													</asp:Repeater>
													<TD>
														<asp:TextBox id="txtRange4" onkeyup="calculateTubediameter(this);" Width="60" runat="server"
															placeholder="Range"></asp:TextBox></TD>
												</TR>
												<TR style="HEIGHT: 54px">
													<asp:Repeater id="rpt5" runat="server">
														<ItemTemplate>
															<td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
																<asp:Label runat="server" ID="hidDimCD5" Text="DIMW0000545" Visible="false" />
																<asp:Label runat="server" ID="hidParameter5" Text="Base tangent length over 15 Teeth" Visible="false" />
																<asp:Label runat="server" ID="hidValue5" Text="317.09 Min./ 317.17 Max." Visible="false" />
																<asp:TextBox runat="server" ID="txtV5" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculateTubediameter(this);">
																</asp:TextBox>
															</td>
														</ItemTemplate>
													</asp:Repeater>
													<TD>
														<asp:TextBox id="txtRange5" onkeyup="calculateTubediameter(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></TD>
												</TR>
												<TR style="HEIGHT: 25px">
													<asp:Repeater id="rpt6" runat="server">
														<ItemTemplate>
															<td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
																<asp:Label runat="server" ID="hidDimCD6" Text="DIMW0000546" Visible="false" />
																<asp:Label runat="server" ID="hidParameter6" Text="Bore" Visible="false" />
																<asp:Label runat="server" ID="hidValue6" Text="219 (+0.00,+0.029)" Visible="false" />
																<asp:TextBox runat="server" ID="txtV6" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculateBarDia(this);">
																</asp:TextBox>
															</td>
														</ItemTemplate>
													</asp:Repeater>
													<TD>
														<asp:TextBox id="txtRange6" onkeyup="calculateBarDia(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></TD>
												</TR>
												<TR style="HEIGHT: 25px">
													<asp:Repeater id="rpt7" runat="server">
														<ItemTemplate>
															<td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
																<asp:Label runat="server" ID="hidDimCD7" Text="DIMW0000547" Visible="false" />
																<asp:Label runat="server" ID="hidParameter7" Text="OD 1" Visible="false" />
																<asp:Label runat="server" ID="hidValue7" Text="320 (+0.062, +0.0.098)" Visible="false" />
																<asp:TextBox runat="server" ID="txtV7" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculateBarCD(this);">
																</asp:TextBox>
															</td>
														</ItemTemplate>
													</asp:Repeater>
													<TD>
														<asp:TextBox id="txtRange7" onkeyup="calculateBarCD(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></TD>
												</TR>
												<TR style="HEIGHT: 25px">
													<asp:Repeater id="rpt8" runat="server">
														<ItemTemplate>
															<td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
																<asp:Label runat="server" ID="hidDimCD8" Text="DIMW0000548" Visible="false" />
																<asp:Label runat="server" ID="hidParameter8" Text="OD 2" Visible="false" />
																<asp:Label runat="server" ID="hidValue8" Text="314 (-0.000,-0.032)" Visible="false" />
																<asp:TextBox runat="server" ID="txtV8" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculateBarTotal(this);">
																</asp:TextBox>
															</td>
														</ItemTemplate>
													</asp:Repeater>
													<TD>
														<asp:TextBox id="txtRange8" onkeyup="calculateBarTotal(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></TD>
												</TR>
												<TR style="HEIGHT: 25px">
													<asp:Repeater id="rpt9" runat="server">
														<ItemTemplate>
															<td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
																<asp:Label runat="server" ID="hidDimCD9" Text="DIMW0000549" Visible="false" />
																<asp:Label runat="server" ID="hidParameter9" Text="OD 3" Visible="false" />
																<asp:Label runat="server" ID="hidValue9" Text="320 (-0.00,-0.14T" Visible="false" />
																<asp:TextBox runat="server" ID="txtV9" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculateBarTotal1(this);">
																</asp:TextBox>
															</td>
														</ItemTemplate>
													</asp:Repeater>
													<TD>
														<asp:TextBox id="txtRange9" onkeyup="calculateEyering(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></TD>
												</TR>
												<TR style="HEIGHT: 25px">
													<asp:Repeater id="rpt10" runat="server">
														<ItemTemplate>
															<td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
																<asp:Label runat="server" ID="hidDimCD10" Text="DIMW00005410" Visible="false" />
																<asp:Label runat="server" ID="hidParameter10" Text="Hardness" Visible="false" />
																<asp:Label runat="server" ID="hidValue10" Text="60 — 62 HRC" Visible="false" />
																<asp:TextBox runat="server" ID="txtV10" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>'>
																</asp:TextBox>
															</td>
														</ItemTemplate>
													</asp:Repeater>
													<TD>
														<asp:TextBox id="txtRange10"  Width="60" runat="server" placeholder="Range"></asp:TextBox></TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
								<TR>
									<TD style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
										width="260">Remarks</TD>
									<TD style="VERTICAL-ALIGN: top" width="60%">
										<asp:TextBox id="txtDatasheetRemarks1" style="MAX-WIDTH: 360px" runat="server" TextMode="MultiLine"
											Height="140"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="PADDING-RIGHT: 2%; PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px; TEXT-ALIGN: right"
										colSpan="2">
										<asp:Button id="btnBackSecond" onclick="btnBackSecond_Click" Width="160" runat="server" Text="Back"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="btnSubmit" onclick="btnSubmit_Click" Width="160" runat="server" Text="Save"></asp:Button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<TABLE borderColor="#b0c4de" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f0f8ff">
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
							Upload Lab Report 1</TD>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
							<INPUT id="File1" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File1" runat="server">
							<asp:Literal id="litFileUpdate" runat="server"></asp:Literal>
							<asp:ImageButton id="fileDelete" onclick="fileDelete_Click" runat="server" Visible="false" ImageUrl="~/RBS/icons/del.gif"></asp:ImageButton></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
							Upload Lab Report 2
						</TD>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
							<INPUT id="File2" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File1" runat="server">
							<asp:Literal id="litFileUpdate2" runat="server"></asp:Literal>
							<asp:ImageButton id="fileDelete2" onclick="fileDelete_Click" runat="server" Visible="false" ImageUrl="~/RBS/icons/del.gif"></asp:ImageButton></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
							Upload Lab Report 3
						</TD>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
							<INPUT id="File3" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File1" runat="server">
							<asp:Literal id="litFileUpdate3" runat="server"></asp:Literal>
							<asp:ImageButton id="fileDelete3" onclick="fileDelete_Click" runat="server" Visible="false" ImageUrl="~/RBS/icons/del.gif"></asp:ImageButton></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
							Upload Lab Report 4
						</TD>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
							<INPUT id="File4" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File1" runat="server">
							<asp:Literal id="litFileUpdate4" runat="server"></asp:Literal>
							<asp:ImageButton id="fileDelete4" onclick="fileDelete_Click" runat="server" Visible="false" ImageUrl="~/RBS/icons/del.gif"></asp:ImageButton></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
							Upload Lab Report 5</TD>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
							<INPUT id="File5" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
								tabIndex="0" type="file" size="51" name="File1" runat="server">
							<asp:Literal id="litFileUpdate5" runat="server"></asp:Literal>
							<asp:ImageButton id="fileDelete5" onclick="fileDelete_Click" runat="server" Visible="false" ImageUrl="~/RBS/icons/del.gif"></asp:ImageButton></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD><BR>
							<asp:Button id="btnUpload" onclick="btnUpload_Click" runat="server" Text="Upload All Files"></asp:Button><BR>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Enter 
							Your Final Remarks with Status
						</TD>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 76.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:TextBox id="txtFinalStatement" Width="400" runat="server" TextMode="MultiLine"></asp:TextBox><BR>
							<asp:RadioButton id="rdoFinalStatementPass" runat="server" Text="Pass" OnCheckedChanged="rdoFinalStatementPass_CheckedChanged"
								AutoPostBack="true" GroupName="rdoFinalStatement"></asp:RadioButton>
							<asp:RadioButton id="rdoFinalStatementFail" runat="server" Text="Fail" OnCheckedChanged="rdoFinalStatementPass_CheckedChanged"
								AutoPostBack="true" GroupName="rdoFinalStatement"></asp:RadioButton><BR>
							<BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"><BR>
						</TD>
						<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
							<asp:Button id="btnfinalsubmit" onclick="btnfinalsubmit_Click" runat="server" Text="Final Submit"></asp:Button><BR>
							<STRONG>Note:-</STRONG> After final submit check sheet will not change
							<BR>
							<BR>
							<%-- <asp:Literal runat="server" ID="litgotohome"></asp:Literal>--%>
							<asp:HyperLink id="hypgotomainPage" runat="server" Text="Go to main page"></asp:HyperLink>
							<asp:HyperLink id="hypDownloadReport" runat="server" Text="Download Report"></asp:HyperLink></TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</td>
	</tr>
</table>