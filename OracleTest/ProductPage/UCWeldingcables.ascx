<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCWeldingcables.ascx.cs" Inherits="RBS.ProductPage.UCWeldingcables" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  %>


<%--<%@ Control Language="c#" AutoEventWireup="false" CodeBehind="UCWeldingcables.ascx.cs" Inherits="RBS.UCWeldingcables" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>--%>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var vWidth = window.innerWidth - document.getElementById("Table4se").offsetWidth;
        document.getElementById('mydiv').setAttribute("style", "width:" + vWidth + "px; height:227px;overflow:scroll;border:solid 2px #b0c4de;overflow-y:hidden;overflow-x:scroll;");
        document.getElementById('divhead').setAttribute("style", "width:" + vWidth + "px; height:25px;font-size: 8pt;color: darkblue;border-right:solid 2px #b0c4de;border-left:solid 2px #b0c4de;border-top:solid 2px #b0c4de; font-family: Verdana;font-weight: bold; text-align:center;");




    });

</script>
<table id="Table4" bordercolor="#b0c4de" cellspacing="0" cellpadding="1" width="100%" bgcolor="#f0f8ff"
    border="0">
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
        <td colspan="2" align="center">
            <asp:Panel runat="server" ID="pnlI">
                <table bordercolor="#b0c4de" cellspacing="0" cellpadding="1" width="97%" bgcolor="#f0f8ff"
                    border="1">
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 15px">1. 
							&nbsp;&nbsp;&nbsp; P.O No. &amp; Date :
                        </td>
                        <td style="WIDTH: 70%">
                            <asp:TextBox ID="txtPoNo" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"></asp:TextBox><br>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 15px">2. 
							&nbsp;&nbsp;&nbsp; Specification/Drawing :
                        </td>
                        <td style="WIDTH: 70%">
                            <asp:Label ID="lblSpecification" Style="VERTICAL-ALIGN: top" Font-Bold="True" Font-Size="8pt"
                                Font-Names="Verdana" Width="30%" runat="server" ForeColor="OrangeRed">IS 9857:1990, Amndt. No.1 Jan 2007 
                            </asp:Label><br>
                            <asp:TextBox ID="txtSpecificationDrawing" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"
                                Visible="false"></asp:TextBox><br>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 15px">3. 
							&nbsp;&nbsp;&nbsp; Date of Inspection :
                        </td>
                        <td style="WIDTH: 70%">
                            <asp:TextBox ID="txtDateOfInspection" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"></asp:TextBox><br />
                            <span style="font-size: 12px; color: #6d6d6d;">dd/mm/yyyy</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">4. 
							&nbsp;&nbsp;&nbsp; Place of Inspection :
                        </td>
                        <td style="WIDTH: 70%">
                            <asp:TextBox ID="txtPlaceofInspection" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"
                                TextMode="MultiLine"></asp:TextBox><br>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">5. 
							&nbsp;&nbsp;&nbsp; Size of Lot:
                        </td>
                        <td style="WIDTH: 70%">
                            <asp:TextBox ID="txtSizeofLog" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"></asp:TextBox><br>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">6. 
							&nbsp;&nbsp;&nbsp; Size of sample:
                        </td>
                        <td style="WIDTH: 70%">
                            <asp:TextBox ID="txtOffered" Font-Size="8pt" Font-Names="Verdana" Width="30%" runat="server"></asp:TextBox> &nbsp; (Clause No.10.2.1, Annex B, Table 8)<br>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <table bordercolor="#b0c4de" cellspacing="0" cellpadding="1" width="97%" bgcolor="#f0f8ff"
                                border="1">
                                <tr>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">No. 
										of drums, coils or<br>
                                        reels in the lot</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">No. 
										of drums, coils or reels to be
										<br>
                                        taken as sample</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Permissible 
										No. of defectives</td>
                                </tr>
                                <tr>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Up 
										to 25</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">3</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">0</td>
                                </tr>
                                <tr>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">26- 
										50</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">5</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">0</td>
                                </tr>
                                <tr>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">51- 
										100</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">8</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">0</td>
                                </tr>
                                <tr>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">101 
										-300</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">13</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">1</td>
                                </tr>
                                <tr>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">301 
										and above</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">20</td>
                                    <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">1</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">7. 
							Document to be Verification
                        </td>
                        <td style="WIDTH: 70%">
                            <asp:CheckBox ID="chkDoc1" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
                                ForeColor="OrangeRed" Text="1) Internal / External test certificate for Raw Materials"></asp:CheckBox><br>
                            <asp:CheckBox ID="chkDoc2" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
                                ForeColor="OrangeRed" Text="2) Calibration record of gauges, measuring Instruments &amp; test equipment"></asp:CheckBox><br>
                            <asp:CheckBox ID="chkDoc3" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
                                ForeColor="OrangeRed" Text="3) Type Test Results. (Refer CI.No.10.1)"></asp:CheckBox><br>
                            <asp:CheckBox ID="chkDoc4" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
                                ForeColor="OrangeRed" Text="4) Internal/Routine Test Results (Refer Cl. No.10.3)"></asp:CheckBox><br>
                            <asp:CheckBox ID="chkDoc5" Font-Bold="True" Font-Size="8pt" Font-Names="Verdana" Width="90%" runat="server"
                                ForeColor="OrangeRed" Text="5) BIS Certificate and its Validity."></asp:CheckBox><br>
                            <%--<asp:HiddenField runat="server" ID="hidItemcode" />
                            <asp:HiddenField runat="server" ID="hidinspectcode" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px; TEXT-ALIGN: right"
                            colspan="2">
                            <asp:Button ID="btnNext1" OnClick="btnNext1_Click" Width="160" runat="server" Text="Next"></asp:Button></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlII" Visible="false">
                <table bordercolor="#b0c4de" cellspacing="0" cellpadding="1" width="97%" bgcolor="#f0f8ff"
                    border="1">
                    <tr>
                        <td colspan="5">
                            <p style="PADDING-LEFT: 10px; FLOAT: left; COLOR: darkblue; TEXT-ALIGN: left">
                                &nbsp; 
								8 Tests/Checks (to be Checked/Witnessed by IE)
								<br>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">S.No</td>
                        <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Parameter</td>
                        <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Value 
							Specified</td>
                        <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 32%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                            colspan="2">Observation</td>
                        <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Remarks</td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">1)</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Visual 
							Examination
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">i) 
							The colour of the covering shall be black.
							<br>
                            ii) Single Core flexible cable.
							<br>
                            iii) The Conductor shall be composed of plain or tinned annealed high 
							conductivity copper wires / aluminium wires.
							<br>
                            iv)The conductor shall be covered with a separator. Separator shall be dry 
							paper, polyester tape or any other suitable material.
							<br>
                            v) The covering/insulation shall be applied over the conductor and the 
							separator. Covering shall be SE1 type for general service normal duty 
							elastomeric compound or SE3 type for heat resistance, oil resistance and flame 
							retardant(HOFR) normal duty elastomeric compound.
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtObservA" runat="server" TextMode="MultiLine" Style="width: 100%; min-height: 140px;"></asp:TextBox></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:RadioButton ID="rdoPassA" runat="server" Text="Pass" GroupName="grpWitA" OnCheckedChanged="rdoPassA_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFailA" runat="server" Text="Fail" GroupName="grpWitA" OnCheckedChanged="rdoPassA_CheckedChanged" AutoPostBack="true"></asp:RadioButton></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Cl.No.9.5<br>
                            <br>
                            Cl. No.4<br>
                            <br>
                            CI.No.8.1 &amp; 5.1<br>
                            <br>
                            CI.No.9.1<br>
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">2)</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Dimensions/ 
							Construction<br>
                            i) No. of Strands<br>
                            ii) Dia of each strands<br>
                            iii) Construction
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">As 
							per P.0<br>
                            The conductor formation shall be as per following (or as per requirement of 
							P.0)<br>
                            i)Table 4 of IS 8130:1984 for copper conductor
							<br>
                            ii) Table 5 of IS 8130:1984 for aluminium conductor
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtObservB" runat="server" TextMode="MultiLine" Style="width: 100%; min-height: 140px;"></asp:TextBox></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:RadioButton ID="rdoPassB" runat="server" Text="Pass" AutoPostBack="true" GroupName="grpWitB" OnCheckedChanged="rdoPassB_CheckedChanged"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFailB" runat="server" Text="Fail" AutoPostBack="true" GroupName="grpWitB" OnCheckedChanged="rdoPassB_CheckedChanged"></asp:RadioButton></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">CI.No.7</td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">3)</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Annealing 
							Test
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">As 
							per IS <u>8130:1984</u>
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtObservC" runat="server" TextMode="MultiLine" Style="width: 100%; min-height: 140px;"></asp:TextBox></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:RadioButton ID="rdoPassC" runat="server" Text="Pass" AutoPostBack="true" GroupName="grpWitC" OnCheckedChanged="rdoPassC_CheckedChanged"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFailC" runat="server" Text="Fail" AutoPostBack="true" GroupName="grpWitC" OnCheckedChanged="rdoPassC_CheckedChanged"></asp:RadioButton></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">CI.No.10.2 
							&amp; IS 8130-1984 (After stranding Not Applicable). T/C Reviewed for before 
							stranding.</td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">4)</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                        Conductor Resistance Test</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
As per IS 8130:1984 and method of test as per IS : 10810(Part 5)-1984</br>
Drum length of cable or sample length of cable or conductor as indicated below shall constitute the test specimen: </br>
a)All solid circular conductor – Drum length or 1 m</br>
b) All stranded or sector shaped solid conductors up to and including 25 sqmm size- Drum length or 5 m</br>
c) All stranded or sector shaped solid conductors greater than 25 sqmm size- Drum length or 10 m</br>

                        
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtObservD" runat="server" TextMode="MultiLine" Style="width: 100%; min-height: 140px;"></asp:TextBox></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:RadioButton ID="rdoPassD" runat="server" Text="Pass" AutoPostBack="true" GroupName="grpWitD" OnCheckedChanged="rdoPassD_CheckedChanged"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFailD" runat="server" Text="Fail" AutoPostBack="true" GroupName="grpWitD" OnCheckedChanged="rdoPassD_CheckedChanged"></asp:RadioButton></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                        Cl.No.10.2 & Table 4 and Table 5 of IS 8130-1984 for copper and aluminum conductor respectively. Method of test as per IS: 10810(Part 5)-1984

                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">5)</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Test 
							for thickness of covering/insulation
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">i)The 
							average thickness of covering shall be not less than the nominal value(tc) 
							specified in Table-1<br>
                            ii)Minimum value of thickness shall not fall below the nominal value(tc) 
							specified in Table-1 by more than 0.1mm+0.15x tc
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtObservE" runat="server" TextMode="MultiLine" Style="width: 100%; min-height: 140px;"></asp:TextBox></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:RadioButton ID="rdoPassE" runat="server" Text="Pass" AutoPostBack="true" GroupName="grpWitE" OnCheckedChanged="rdoPassE_CheckedChanged"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFailE" runat="server" Text="Fail" AutoPostBack="true" GroupName="grpWitE" OnCheckedChanged="rdoPassE_CheckedChanged"></asp:RadioButton></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"></td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px; TEXT-ALIGN: right"
                            colspan="6">
                            <asp:Button ID="btnBack2" OnClick="tbn2Back_Click" Width="160" runat="server" Text="Back"></asp:Button>
                            <asp:Button ID="btnNext2" OnClick="btnNext2_Click" Width="160" runat="server" Text="Next"></asp:Button></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlIII" Visible="false">
                <table bordercolor="#b0c4de" cellspacing="0" cellpadding="1" width="97%" bgcolor="#f0f8ff"
                    border="1">
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">S.No</td>
                        <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Parameter</td>
                        <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Value 
							Specified</td>
                        <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 32%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                            colspan="2">Observation</td>
                        <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Remarks</td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">6</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">High 
							Voltage Test (Water Immersion test)</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">High 
							voltage shall be applied after the cable has been immersed in water for not 
							less than 12 hours. The test voltage shall be applied between the water in 
							which the cable is immersed which shall be earthed, and the conductor.The cable 
							should withstand Ac voltage of 1000V(rms) for 5 minutes at a frequency of 40 to 
							60 Hz without breakdown.</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtObservF" runat="server" TextMode="MultiLine" Style="width: 100%; min-height: 140px;"></asp:TextBox></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:RadioButton ID="rdoPassF" runat="server" Text="Pass" AutoPostBack="true" GroupName="grpWitF" OnCheckedChanged="rdoPassF_CheckedChanged"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFailF" runat="server" Text="Fail" AutoPostBack="true" GroupName="grpWitF" OnCheckedChanged="rdoPassF_CheckedChanged"></asp:RadioButton></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">CI.No.11.1</td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">7</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Length 
							Verification of Coil/Drum/Reel</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">As 
							per P.O/Packing List.</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtObservG" runat="server" TextMode="MultiLine" Style="width: 100%; min-height: 140px;"></asp:TextBox></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:RadioButton ID="rdoPassG" runat="server" Text="Pass" AutoPostBack="true" GroupName="grpWitG" OnCheckedChanged="rdoPassG_CheckedChanged"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFailG" runat="server" Text="Fail" AutoPostBack="true" GroupName="grpWitG" OnCheckedChanged="rdoPassG_CheckedChanged"></asp:RadioButton></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"></td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">8</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Marking 
							on cable</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">i) 
							Manufacture's identification mark should be printed or embossed or indented 
							throughout the length of the cable. The distance between any two consecutive 
							printings,indentations or embossing shall be not more than I m.
							<br>
                            ii) Cable Identification : Cables with HOFR compound shall be identified 
							throughout the length by legend `HR 90' by printing, indenting or embossing on 
							the cable.<br>
                            iii) Cable code shall be used as 'A' for aluminium, R for elastomeric covering 
							for designating the cable and no code is required for copper conductor.
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtObservH" runat="server" TextMode="MultiLine" Style="width: 100%; min-height: 140px;"></asp:TextBox></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:RadioButton ID="rdoPassH" runat="server" Text="Pass" AutoPostBack="true" GroupName="grpWitH" OnCheckedChanged="rdoPassH_CheckedChanged"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFailH" runat="server" Text="Fail" AutoPostBack="true" GroupName="grpWitH" OnCheckedChanged="rdoPassH_CheckedChanged"></asp:RadioButton></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">CI.No.12
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">9</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Packing 
							&amp; Marking on Reels/Drums/ Coils</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">The 
							cable shall be either wound on reels or drums or supplied in coils packed and 
							labeled.<br>
                            The label or the stenciling on the drum shall contain the following 
							information:<br>
                            IS Standard<br>
                            Manufacturer Name<br>
                            Type of Cable:<br>
                            Area of Conductor<br>
                            Cable Code<br>
                            Length of Cable on Coil/Drum/Reel<br>
                            No. of length on the Coil/Drum/Reel (if more than one)
							<br>
                            Direction of rotation of the drum Approx Gross weight<br>
                            Country of Manufacturing<br>
                            Year of Manufacturing
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtObservI" runat="server" TextMode="MultiLine" Style="width: 100%; min-height: 140px;"></asp:TextBox></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:RadioButton ID="rdoPassI" runat="server" Text="Pass" AutoPostBack="true" GroupName="grpWitI" OnCheckedChanged="rdoPassI_CheckedChanged"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFailI" runat="server" Text="Fail" AutoPostBack="true" GroupName="grpWitI" OnCheckedChanged="rdoPassI_CheckedChanged"></asp:RadioButton></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">CI.13</td>
                    </tr>
                    
                    
                    
                    
                    
                    
                    
                    
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 2%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">10</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"> 
							Cut minimum one sample for a randomly selected coil/drum, cut the sample cable preferably around Quarter(qtr)/middle/ 3/4th qtr length to ensure consistency in number of strands.</td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 23%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Verify number of strands on both ends and at the end of cut length, measure insulation thickness on both ends and at cut length and record.
                        </td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtObservJ" runat="server" TextMode="MultiLine" Style="width: 100%; min-height: 140px;"></asp:TextBox></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 10%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:RadioButton ID="rdoPassJ" runat="server" Text="Pass" AutoPostBack="true" GroupName="grpWitJ" OnCheckedChanged="rdoPassJ_CheckedChanged"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFailJ" runat="server" Text="Fail" AutoPostBack="true" GroupName="grpWitJ" OnCheckedChanged="rdoPassJ_CheckedChanged"></asp:RadioButton></td>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 20%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"></td>
                    </tr>
                    
                    
                    
                    
                    
                    
                    
                    <asp:Repeater ID="repaterTstChecks" runat="server">
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
                                <td style="font-size: 8pt; width: 23%; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
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
                    <tr>
                        <td style="PADDING-RIGHT: 2%; PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                            colspan="6">
                            <asp:LinkButton ID="lnkAdd" OnClick="lnkAdd_Click" Font-Bold="true" runat="server">+ Add</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td style="PADDING-RIGHT: 2%; PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                            colspan="6">
                            <p>
                                (i) Sampling shall be done according to 15:2500-2000 Pt I single sampling plan 
								(normal) unless mentioned otherwise.
                            </p>
                            <p>
                                (ii) In case a quality plan is mentioned in the Purchase Order, Inspecting 
								Engineer shall also take the same into consideration during inspection, and 
								mention the same in Inspection Records.
                            </p>
                            <p>
                                (iii) This Inspection &amp; Test plan along with dimension sheets is a guiding 
								document for IE. Any other requirement of PO /Spec. (i.e weight of conductor 
								per meter length, No. of strands in cable etc.) or dimension of PO / drawing 
								etc. necessary for the item will be complied by the IE.
                            </p>
                            <p>
                                (iv) In case purchase order mentions different drawing / specification, then 
								that will be applicable.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px; TEXT-ALIGN: right"
                            colspan="6">
                            <asp:Button ID="btnBack3" OnClick="btnBack3_Click" Width="160" runat="server" Text="Back"></asp:Button>
                            <asp:Button ID="btnNext3" OnClick="btnNext3_Click" Width="160" runat="server" Text="Next"></asp:Button></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlIV" Visible="false">
                <table bordercolor="#b0c4de" cellspacing="0" cellpadding="0" width="100%" bgcolor="#f0f8ff">
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                            colspan="2"><strong>DATA SHEET</strong>
                            <br>
                            <br>
                            <br>
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">&nbsp;&nbsp;&nbsp; 
							Total no of sample to be inspected :
                        </td>
                        <td style="WIDTH: 70%">
                            <asp:TextBox ID="txtNoOfPices" onkeyup="TotalItemInpect(this);" runat="server" Text="5"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
							<span style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Actual measurment done</span>
                            <asp:TextBox ID="txtManualEntry" onkeyup="ManualEntry(this);" runat="server" Text="5"></asp:TextBox>
                            <asp:Button ID="btnNoOfPices" OnClick="btnNoOfPices_Click" runat="server" Text="Show"></asp:Button><span style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Range</span>
                            <asp:TextBox ID="txtRange" Enabled="false" runat="server" ReadOnly="true"></asp:TextBox><br>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                            colspan="2">
                            <table cellspacing="0" cellpadding="0" width="97%" bgcolor="#f0f8ff" border="1">
                                <tr>
                                    <td style="VERTICAL-ALIGN: top; HEIGHT: 220px" width="260">
                                        <table id="Table4se2" bordercolor="#b0c4de" cellspacing="0" cellpadding="1" width="100%"
                                            bgcolor="#f0f8ff" border="1">
                                            <tr style="HEIGHT: 50px">
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">S.No
                                                </td>
                                                <td style="MIN-WIDTH: 160px; PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Parameter
                                                </td>
                                                <td style="MIN-WIDTH: 120px; PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Value 
													Specified
                                                </td>
                                            </tr>
                                            <tr style="HEIGHT: 42px">
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">1.
                                                </td>
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">i) 
													Size/ Dia of wire<br>
                                                    ii) No. of Strands
                                                </td>
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                                                As per Spec./P.O<br>
                                                No. of strands should be recorded.
                                                </td>
                                            </tr>
                                            <tr style="HEIGHT: 42px">
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">2.
                                                </td>
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                                                    colspan="2">Thickness of covering/Insulation Average(Min):
                                                </td>
                                            </tr>
                                            <tr style="HEIGHT: 42px">
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">3.
                                                </td>
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                                                    colspan="2">Thickness of covering /Insulation (Minimum):</td>
                                            </tr>
                                            <tr style="HEIGHT: 42px">
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">4.
                                                </td>
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                                                    colspan="2">Conductor Resistance( in 0/Km at 20 degree centigrade):
                                                </td>
                                            </tr>
                                            <tr style="HEIGHT: 42px">
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">5.
                                                </td>
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                                                    colspan="2">High Voltage Test: (1 KV for 5 Minutes)
                                                </td>
                                            </tr>
                                            <tr style="HEIGHT: 42px">
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">6.
                                                </td>
                                                <td style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 15%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px"
                                                    colspan="2">Length Verification of/Drum/Reel
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="VERTICAL-ALIGN: top; HEIGHT: 240px" width="60%">
                                        <div id="divhead" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 640px; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 26px; TEXT-ALIGN: center">
                                            <asp:Literal ID="litHeadDimension" runat="server"></asp:Literal>
                                        </div>
                                        <div id="mydiv" style="OVERFLOW-Y: hidden; OVERFLOW-X: auto; OVERFLOW: scroll">
                                            <table cellspacing="0" cellpadding="1" border="1">
                                                <tr style="HEIGHT: 25px">
                                                    <asp:Repeater ID="rpt0" runat="server">
                                                        <ItemTemplate>
                                                            <td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
                                                                <%# Container.ItemIndex + 1 %>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tr>
                                                <tr style="HEIGHT: 42px">
                                                    <asp:Repeater ID="rpt1" runat="server">
                                                        <ItemTemplate>
                                                            <td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
                                                                <asp:Label runat="server" ID="hidDimCD1" Text="DIMN0000381" Visible="false" />
                                                                <asp:Label runat="server" ID="hidParameter1" Text="As Per P.O" Visible="false" />
                                                                <asp:Label runat="server" ID="hidValue1" Text="" Visible="false" />
                                                                <asp:TextBox runat="server" ID="txtV11" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' Width="60" onkeyup="calculatevi(this);">
                                                                </asp:TextBox>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                                                        <asp:TextBox ID="txtRange1" onkeyup="calculatevi(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></td>
                                                </tr>
                                                <tr style="HEIGHT: 42px">
                                                    <asp:Repeater ID="rpt2" runat="server">
                                                        <ItemTemplate>
                                                            <td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
                                                                <asp:Label runat="server" ID="hidDimCD2" Text="DIMN0000382" Visible="false" />
                                                                <asp:Label runat="server" ID="hidParameter2" Text="Thickness of covering/Insulation Average(Min)"
                                                                    Visible="false" />
                                                                <asp:Label runat="server" ID="hidValue2" Text="" Visible="false" />
                                                                <asp:TextBox runat="server" ID="txtV12" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculateCompressed(this);">
                                                                </asp:TextBox>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                                                        <asp:TextBox ID="txtRange2" onkeyup="calculateCompressed(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></td>
                                                </tr>
                                                <tr style="HEIGHT: 42px">
                                                    <asp:Repeater ID="rpt3" runat="server">
                                                        <ItemTemplate>
                                                            <td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
                                                                <asp:Label runat="server" ID="hidDimCD3" Text="DIMN0000383" Visible="false" />
                                                                <asp:Label runat="server" ID="hidParameter3" Text="Thickness of  covering /Insulation  (Minimum)"
                                                                    Visible="false" />
                                                                <asp:Label runat="server" ID="hidValue3" Text="" Visible="false" />
                                                                <asp:TextBox runat="server" ID="txtV13" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculatedustcover(this);">
                                                                </asp:TextBox>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <td>
                                                        <asp:TextBox ID="txtRange3" onkeyup="calculatedustcover(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></td>
                                                </tr>
                                                <tr style="HEIGHT: 42px">
                                                    <asp:Repeater ID="rpt4" runat="server">
                                                        <ItemTemplate>
                                                            <td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
                                                                <asp:Label runat="server" ID="hidDimCD4" Text="DIMN0000384A" Visible="false" />
                                                                <asp:Label runat="server" ID="hidParameter4" Text="Conductor Resistance( in 0/Km at 20 degree centigrade)"
                                                                    Visible="false" />
                                                                <asp:Label runat="server" ID="hidValue4" Text="" Visible="false" />
                                                                <asp:TextBox runat="server" ID="txtV14" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculateBarDia(this);">
                                                                </asp:TextBox>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                                                        <asp:TextBox ID="txtRange4" onkeyup="calculateBarDia(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></td>
                                                </tr>
                                                <tr style="HEIGHT: 42px">
                                                    <asp:Repeater ID="rpt5" runat="server">
                                                        <ItemTemplate>
                                                            <td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
                                                                <asp:Label runat="server" ID="hidDimCD5" Text="DIMN0000384B" Visible="false" />
                                                                <asp:Label runat="server" ID="hidParameter5" Text="High Voltage Test: (1 KV for 5 Minutes)"
                                                                    Visible="false" />
                                                                <asp:Label runat="server" ID="hidValue5" Text="" Visible="false" />
                                                                <asp:TextBox runat="server" ID="txtV15" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculateBarCD(this);">
                                                                </asp:TextBox>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                                                        <asp:TextBox ID="txtRange5" onkeyup="calculateBarCD(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></td>
                                                </tr>
                                                <tr style="HEIGHT: 42px">
                                                    <asp:Repeater ID="rpt6" runat="server">
                                                        <ItemTemplate>
                                                            <td style="font-size: 8pt; color: darkblue; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top;">
                                                                <asp:Label runat="server" ID="hidDimCD6" Text="DIMN0000384C" Visible="false" />
                                                                <asp:Label runat="server" ID="hidParameter6" Text="Length Verification of/Drum/Reel" Visible="false" />
                                                                <asp:Label runat="server" ID="hidValue6" Text="" Visible="false" />
                                                                <asp:TextBox runat="server" ID="txtV16" Width="60" Text='<%# DataBinder.Eval(Container.DataItem, "ObserValue1") %>' onkeyup="calculateBarTotal(this);">
                                                                </asp:TextBox>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <td style="PADDING-LEFT: 10px; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                                                        <asp:TextBox ID="txtRange6" onkeyup="calculateBarTotal(this);" Width="60" runat="server" placeholder="Range"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td  style="PADDING-LEFT: 10px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 5%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px" width="260">Remarks</td>
                                    <td style="VERTICAL-ALIGN: top;" width="60%">
                                        <asp:TextBox runat="server" ID="txtDatasheetRemarks1" TextMode="MultiLine" Style="max-width: 360px; width: 100%; height: 140px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="VERTICAL-ALIGN: top;"></td>
                                    <td style="VERTICAL-ALIGN: top; text-align:right;" width="60%">
                                        <asp:Button ID="btnBack4" OnClick="btnBack4_Click" Width="160" runat="server" Text="Back"></asp:Button>
                                        <asp:Button ID="btnNext4" OnClick="btnNext4_Click" Width="160" runat="server" Text="Save"></asp:Button>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table bordercolor="#b0c4de" cellspacing="0" cellpadding="0" width="100%" bgcolor="#f0f8ff">
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                            Upload Lab Report 1</td>
                        <td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                            <input id="File1" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
                                tabindex="0" type="file" size="51" name="File1" runat="server">
                            <asp:Literal ID="litFileUpdate" runat="server"></asp:Literal>
                            <asp:ImageButton ID="fileDelete" OnClick="fileDelete_Click" runat="server" Visible="false" ImageUrl="~/icons/del.gif"></asp:ImageButton></td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                            Upload Lab Report 2
                        </td>
                        <td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                            <input id="File2" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
                                tabindex="0" type="file" size="51" name="File1" runat="server">
                            <asp:Literal ID="litFileUpdate2" runat="server"></asp:Literal>
                            <asp:ImageButton ID="fileDelete2" OnClick="fileDelete_Click" runat="server" Visible="false" ImageUrl="~/icons/del.gif"></asp:ImageButton></td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                            Upload Lab Report 3
                        </td>
                        <td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                            <input id="File3" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
                                tabindex="0" type="file" size="51" name="File1" runat="server">
                            <asp:Literal ID="litFileUpdate3" runat="server"></asp:Literal>
                            <asp:ImageButton ID="fileDelete3" OnClick="fileDelete_Click" runat="server" Visible="false" ImageUrl="~/icons/del.gif"></asp:ImageButton></td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                            Upload Lab Report 4
                        </td>
                        <td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                            <input id="File4" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
                                tabindex="0" type="file" size="51" name="File1" runat="server">
                            <asp:Literal ID="litFileUpdate4" runat="server"></asp:Literal>
                            <asp:ImageButton ID="fileDelete4" OnClick="fileDelete_Click" runat="server" Visible="false" ImageUrl="~/icons/del.gif"></asp:ImageButton></td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                            Upload Lab Report 5</td>
                        <td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                            <input id="File5" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
                                tabindex="0" type="file" size="51" name="File1" runat="server">
                            <asp:Literal ID="litFileUpdate5" runat="server"></asp:Literal>
                            <asp:ImageButton ID="fileDelete5" OnClick="fileDelete_Click" runat="server" Visible="false" ImageUrl="~/icons/del.gif"></asp:ImageButton></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <br>
                            <asp:Button ID="btnUpload" OnClick="btnUpload_Click" runat="server" Text="Upload All Files"></asp:Button><br>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">Enter 
							Your Final Remarks with Status
                        </td>
                        <td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 76.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:TextBox ID="txtFinalStatement" Width="400" runat="server" TextMode="MultiLine"></asp:TextBox><br>
                            <asp:RadioButton ID="rdoFinalStatementPass" runat="server" Text="Pass" AutoPostBack="true" GroupName="rdoFinalStatement"
                                OnCheckedChanged="rdoFinalStatementPass_CheckedChanged"></asp:RadioButton>
                            <asp:RadioButton ID="rdoFinalStatementFail" runat="server" Text="Fail" AutoPostBack="true" GroupName="rdoFinalStatement"
                                OnCheckedChanged="rdoFinalStatementPass_CheckedChanged"></asp:RadioButton><br>
                            <br>
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td style="PADDING-LEFT: 2%; FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <br>
                        </td>
                        <td style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; VERTICAL-ALIGN: top; WIDTH: 22.38%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 9px">
                            <asp:Button ID="btnfinalsubmit" OnClick="btnfinalsubmit_Click" runat="server" Text="Final Submit"></asp:Button><br>
                            <strong>Note:-</strong> After final submit check sheet will not change
							<br>
                            <br>
                            <br>
                            <%-- <asp:Literal runat="server" ID="litgotohome"></asp:Literal>--%>
                            <asp:HyperLink ID="hypgotomainPage" runat="server" Text="Go to main page"></asp:HyperLink>
                            <asp:HyperLink ID="hypDownloadReport" runat="server" Text="Download Report"></asp:HyperLink></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
