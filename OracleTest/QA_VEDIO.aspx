<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QA_VEDIO.aspx.cs" Inherits="RBS.QA_VEDIO.QA_VEDIO" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>QA_VEDIO</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		
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
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px; HEIGHT: 25.8%"
				borderColor="#b0c4de" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 17px">
							<P align="center"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 13px" align="center" width="100%">
							<TABLE id="Table2" style="HEIGHT: 175px" borderColor="#b0c4de" cellSpacing="1" cellPadding="1"
								width="100%" align="center" bgColor="#f0f8ff" border="1">
					<TR>
						<TD style="WIDTH: 675px; HEIGHT: 13px" align="center">
							<P><asp:label id="Label1" runat="server" Height="19px" Width="264px" ForeColor="DarkBlue" Font-Size="10pt"
									Font-Names="Verdana" BackColor="White" Font-Bold="True">QA vedios</asp:label></P>
						</TD>
					</TR>
					<tr>
					    <% if (Request.Params ["ACTION"]=="V1") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V1.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Fire Retardant Toxicity</td>
					<%}else if (Request.Params ["ACTION"]=="V2") {%>
						<td style="WIDTH: 675px">
							<VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V2.mp4" TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO>
						</td>
						<td>Inspection of fire Retardant Properties limiting of Oxygen</td>
						<%}if (Request.Params ["ACTION"]=="V3") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V3.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Inspection of Axle For The Wheel Disc of Rail Coach & Wagon</td>
					<%}if (Request.Params ["ACTION"]=="V4") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V4.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Inspection of High Drawn Grooved Copper Contact wire 107sq.mm</td>
					<%}if (Request.Params ["ACTION"]=="V5") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V5.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Inspection of Wheel disc for Railway rolling stock</td>
					<%}if (Request.Params ["ACTION"]=="V6") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V6.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Inspection of Wheel Set (Two wheel and one Axle) for Railway rolling stock</td>
					<%}if (Request.Params ["ACTION"]=="V7") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V7.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Instructional video on Calibration</td>
					<%}if (Request.Params ["ACTION"]=="V8") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V8.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>ABOUT STEEL BRIDGE GIRDERS</td>
					<%}if (Request.Params ["ACTION"]=="V9") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V9.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>About the construction features of VRLA Batteries used in PASSENGER COACHES OF INDIAN RAILWAYS</td>
					<%}if (Request.Params ["ACTION"]=="V10") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V10.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>About the working principle and construction features of Distribution Transformers</td>
						<%}if (Request.Params ["ACTION"]=="V11") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V11.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>About welding symbols</td>
						<%}if (Request.Params ["ACTION"]=="V12") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V12.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Acceptance testing process of Brushless DC Railway carriage (sensor less)</td>
						<%}if (Request.Params ["ACTION"]=="V13") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V13.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Inspection of HDPE PIPE</td>
						<%}if (Request.Params ["ACTION"]=="V17") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V17.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>INSPECTION on COMPRESSOR</td>
						<%}if (Request.Params ["ACTION"]=="V19") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V19.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Instructional Video on Limits , Tolerances , Fits and Deviation</td>
						<%}if (Request.Params ["ACTION"]=="V20") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V20.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Instructional video on working of BIO-TOILETs on Passenger coaches of Indian Railways</td>
						<%}if (Request.Params ["ACTION"]=="V21") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V21.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Instructional Video-1 on Points and Crossings</td>
						<%}if (Request.Params ["ACTION"]=="V22") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V22.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>LED LIGHT FITTING TYPE-B1 (9W) - NON AC Rail Coaches of Conventional  and LHB Types</td>
						<%}if (Request.Params ["ACTION"]=="V23") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V23.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>LHB spring manufacturing</td>
						<%}if (Request.Params ["ACTION"]=="V24") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V24.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Manufacturing and Inspection of Armature Shaft(Traction Motor )</td>
						<%}if (Request.Params ["ACTION"]=="V25") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V25.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Manufacturing and inspection of Glass filled NYLON-66 Insulating Liners</td>
						<%}if (Request.Params ["ACTION"]=="V26") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V26.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Manufacturing and inspection of Graphite mould block</td>
						<%}if (Request.Params ["ACTION"]=="V27") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V27.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Manufacturing Process and testing-Inspection of Spheroidal Graphite Cast Iron Inserts (SGCI) Inserts</td>
						<%}if (Request.Params ["ACTION"]=="V28") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V28.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Manufcature ,Testing and Inspection of Base for Point machine</td>
						<%}if (Request.Params ["ACTION"]=="V29") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V29.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>MICROMETER</td>
						<%}if (Request.Params ["ACTION"]=="V30") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V30.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>MIGRATION TO STANDARD CHECK SHEETS   IN RAILWAY & NON INSPECTIONS</td>
						<%}if (Request.Params ["ACTION"]=="V31") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V31.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>NDT</td>
						<%}if (Request.Params ["ACTION"]=="V32") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V32.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>pie tape instructional video</td>
						<%}if (Request.Params ["ACTION"]=="V33") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V33.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Railway Electrical Traction catenary Wire testing</td>
						<%}if (Request.Params ["ACTION"]=="V34") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V34.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Sampling ,  Inspection & Testing procedures</td>
						<%}if (Request.Params ["ACTION"]=="V35") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V35.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>sidewall undulation</td>
						<%}if (Request.Params ["ACTION"]=="V36") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V36.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Solid Railway Gear Wheel Blank Gear  Pinion Blank Forgings  Proof Machined Gear</td>
						<%}if (Request.Params ["ACTION"]=="V37") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V37.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Special  Process- Laser seam welding of Rail Coach Side wall sheets and its validation</td>
						<%}if (Request.Params ["ACTION"]=="V38") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V38.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>special  test plans</td>
						<%}if (Request.Params ["ACTION"]=="V39") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V39.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>special process</td>
						<%}if (Request.Params ["ACTION"]=="V40") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V40.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>surface finish</td>
						<%}if (Request.Params ["ACTION"]=="V41") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V41.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Teaser for launch of E Book on Painting process</td>
						<%}if (Request.Params ["ACTION"]=="V42") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V42.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Testing and Inspection Methods of the Ready Mixed Paint (Red Oxide Primer)</td>
						<%}if (Request.Params ["ACTION"]=="V43") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V43.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Testing procedure of XLPE Cables -NR</td>
						<%}if (Request.Params ["ACTION"]=="V45") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V45.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Instructional video on Calibration</td>
						<%}if (Request.Params ["ACTION"]=="V46") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V46.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>HRR</td>
						<%}if (Request.Params ["ACTION"]=="V47") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V47.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>ICF Innovations Continue Forever</td>
						<%}if (Request.Params ["ACTION"]=="V48") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V48.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Inspection - Railway Traction Insulator</td>
						<%}if (Request.Params ["ACTION"]=="V49") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V49.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>INSPECTION  SPUR GEAR</td>
						<%}if (Request.Params ["ACTION"]=="V50") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V50.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Inspection and testing of Coil Spring for Fiat bogies of LHB  Coaches</td>
						<%}if (Request.Params ["ACTION"]=="V51") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V51.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>INSPECTION ELECTRICAL ITEMS</td>
						<%}if (Request.Params ["ACTION"]=="V54") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V54.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Inspection of Fire retardant Properties   Spread of Flame</td>
						<%}if (Request.Params ["ACTION"]=="V55") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V19.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Inspection of girder during welding _ fabrication</td>
						<%}if (Request.Params ["ACTION"]=="V56") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V56.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>INSPECTION OF GIRDERS- Inspection Before Welding_ Fabrication</td>
						<%}if (Request.Params ["ACTION"]=="V57") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V57.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Transformer Oil cooler inspection</td>
						<%}if (Request.Params ["ACTION"]=="V59") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V59.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Girder inspection after welding _ fabrication</td>
						<%}if (Request.Params ["ACTION"]=="V60") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V60.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Good Manufacturing Practices in Rail coach Body Building</td>
						<%}if (Request.Params ["ACTION"]=="V61") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V61.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>VACUUM CIRCUIT BREAKER AND INTERRUPTER</td>
						<%}if (Request.Params ["ACTION"]=="V62") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V62.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>VENDOR Assesment carried out By RITES for NSIC</td>
						<%}if (Request.Params ["ACTION"]=="V63") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V63.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>VRLA battery Testing & Inspection</td>
						<%}if (Request.Params ["ACTION"]=="V64") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V64.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Welding Procedure Specificaion WPS</td>
						<%}if (Request.Params ["ACTION"]=="V65") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V65.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Glued Insulated Rail Joint</td>
						<%}if (Request.Params ["ACTION"]=="V66") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V66.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>hardness Test</td>
						<%}if (Request.Params ["ACTION"]=="V67") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V67.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>HDPE pipe Mfg process</td>
						<%}if (Request.Params ["ACTION"]=="V69") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V69.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>heat treatment</td>
						<%}if (Request.Params ["ACTION"]=="V70") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V70.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Highlights</td>
						<%}if (Request.Params ["ACTION"]=="V71") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V71.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Honing and testing</td>
						<%}if (Request.Params ["ACTION"]=="V72") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V72.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>HPCR</td>
						<%}if (Request.Params ["ACTION"]=="V73") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V73.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Constructional Features, Testing and Inspection of EBeam Cable</td>
						<%}if (Request.Params ["ACTION"]=="V74") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V74.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>BEE DOMESTIC Appliances Energy rating</td>
						<%}if (Request.Params ["ACTION"]=="V75") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V75.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>BEE ENERGY RATING industrial appliances</td>
						<%}if (Request.Params ["ACTION"]=="V76") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V76.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Chemical testing</td>
						<%}if (Request.Params ["ACTION"]=="V77") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V77.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Coating Failures & Defects</td>
						<%}if (Request.Params ["ACTION"]=="V78") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V78.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Deterioration of  Visibility due to smoke</td>
						<%}if (Request.Params ["ACTION"]=="V79") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V79.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>do&dont's of IEs'</td>
						<%}if (Request.Params ["ACTION"]=="V80") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V80.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>drg altn revn0</td>
						<%}if (Request.Params ["ACTION"]=="V81") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V81.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>ED-QA New Year message</td>
						<%}if (Request.Params ["ACTION"]=="V82") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V82.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>Electrical Cable Construction, Inspection  and testing methods</td>
						<%}if (Request.Params ["ACTION"]=="V83") {%>
						<td style="WIDTH: 675px"><VIDEO WIDTH="540" HEIGHT="310" CONTROLS controlsList="nodownload"/>
							<SOURCE SRC="/RBS/vedio/V83.mp4"
								TYPE="VIDEO/MP4"></SOURCE>
							</VIDEO></td>
						<td>FAD OF COMPRESSORS</td>
					<%}%>
					</tr></TABLE></TD></TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
