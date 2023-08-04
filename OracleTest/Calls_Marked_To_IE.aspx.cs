using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Calls_Marked_To_IE
{
	public partial class Calls_Marked_To_IE : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		static string wIECD, wIENAME;
		static string wDtFr;
		static string wDtTo;
		private string wColour;
		string wVendor;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//			wIECD=Request.Params["pIECD"].ToString(); 
			//			wIENAME=Request.Params["pIENAME"].ToString();

			wIECD = Session["IE_CD"].ToString();
			wIENAME = Session["IE_NAME"].ToString();
			string wSortKey = Request.Params["ACTION"].Trim();
			//-- 
			OracleCommand cmd = new OracleCommand("Select to_char(add_months(sysdate,-1),'dd/mm/yyyy')DtFr,to_char(sysdate,'dd/mm/yyyy')DtTo from dual", conn);
			conn.Open();
			OracleDataReader readerA = cmd.ExecuteReader();
			readerA.Read();
			//wDtFr=Convert.ToString(readerA["DtFr"]); 
			wDtFr = Convert.ToString(readerA["DtFr"]);
			wDtTo = Convert.ToString(readerA["DtTo"]);
			conn.Close();
			//--

			Response.Write("<TABLE id='Table3' cellSpacing='0' cellPadding='1' width='145%' bgColor='inactivecaptiontext'border='1' borderColor='lightsteelblue'>");
			Response.Write("<TR>");
			Response.Write("<TD width='20%' style='HEIGHT: 20px'></TD>");

			Response.Write("<TD align='center' width='60%' style='HEIGHT: 20px'>");
			Response.Write("<P><FONT style='FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: DarkBlue; LINE-HEIGHT: 8pt; FONT-FAMILY: Verdana; TEXT-ALIGN: center'>RITES INSPECTION & BILLING SYSTEM</FONT></P></TD>");
			Response.Write("<TD align='right' width='20%' style='HEIGHT: 20px'></TD></TR>");


			Response.Write("<TR>");
			Response.Write("<TD width='20%' style='HEIGHT: 20px'>");
			Response.Write("<P style='LINE-HEIGHT: 8pt'><FONT style='FONT-WEIGHT: normal; FONT-SIZE: 8pt; COLOR: red; LINE-HEIGHT: 8pt; FONT-FAMILY: Verdana; TEXT-ALIGN: center' color='darkblue' size='2'>Welcome: ");
			Response.Write("</FONT><FONT style='FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: red; LINE-HEIGHT: 8pt; FONT-FAMILY: Verdana; TEXT-ALIGN: center' color='darkblue' size='2'>" + wIENAME + "</FONt></P></TD>");

			Response.Write("<TD align='center' width='60%' style='HEIGHT: 20px'>");
			string wSortHdr = "";
			if (wSortKey == "V")
			{
				wSortHdr = "Report Sorted on Vendor Name";
			}
			else if (wSortKey == "C")
			{
				wSortHdr = "Report Sorted on Call Date";
			}
			Response.Write("<p align='center'><font face='Verdana' color='#3333FF'><b>");
			Response.Write("<font size='2'>CALLS  STATUS FOR THE PERIOD " + wDtFr + " TO " + wDtTo + " AND ALL PENDING CALLS</b></font><br>");
			Response.Write("<font size='1'>(STATUS AS ON DATE)- " + wSortHdr + "</font></p>");


			Response.Write("</TD>");
			Response.Write("<TD align='right' width='20%' style='HEIGHT: 20px' align='right'>");
			Response.Write("<font face='Verdana' size=2><b><a href='LogOut.aspx'>Logout</a></b></Font></TD></TR></TABLE>");


			//			  string sql = "Select T051.VEND_NAME,(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE,"+
			//				"T18.ITEM_DESC_PO,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,"+
			//				"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,"+
			//				"decode(T17.CALL_STATUS,'M','Pending','A','Accepted'||nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'R','Rejection'||nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'C','Cancelled on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection','W','Withheld')||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,"+
			//				"decode(T17.CALL_STATUS,'M','#FF0033','A','#006600','R','#3333FF','C','#00FF00','U','#FF00CC','S','#FF9966','G','#FF9966','W','#0000FF','#000000')COLOUR,"+
			//				"T052.VEND_CONTACT_PER_1 MFG_PERS,T052.VEND_CONTACT_TEL_1 MFG_PHONE,T17.CALL_SNO,"+ 
			//				"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT "+						
			//				"From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052 "+ 
			//				"Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO and "+
			//				"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and "+
			//				"(T17.CALL_MARK_DT between to_date('"+wDtFr+"','dd/mm/yyyy') and to_date('"+wDtTo+"','dd/mm/yyyy')) and T17.IE_CD='"+wIECD+"' and "+ 
			//				"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) "+
			//				"Order by T051.VEND_NAME,CALL_MARK_DT";
			string sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD,(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE," +
				"T18.ITEM_DESC_PO,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') EXT_DELV_DT ,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy')INSP_DESIRE_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT, NVL(T17.NEW_VENDOR,'X') NEW_VENDOR, " +
				"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,to_char(T13.PO_DT,'yyyy')PO_YR,T13.PO_SOURCE,DECODE(PO_SOURCE,'V','VENDOR','M','MANUAL','C','IREPS','OTHER') SOURCE,T13.RLY_CD,T17.CASE_NO,T17.USER_ID, to_char(T17.DATETIME,'dd/mm/yyyy') DATETIME, T17.REMARKS, T17.CALL_STATUS, " +
				"trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'C',' on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)'||'/'||'Document Not Received','C',' (Chargeable)'||'/'||'Document Not Received','') CALL_STATUS_FULL,T21.CALL_STATUS_COLOR COLOUR," +
				"T052.VEND_CONTACT_PER_1 MFG_PERS,T052.VEND_CONTACT_TEL_1 MFG_PHONE,T17.CALL_SNO," +
				"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT " +
				"From T05_VENDOR T051,T03_CITY T03,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052,T03_CITY T032,T21_CALL_STATUS_CODES T21, T19_CALL_CANCEL T19,T15_PO_DETAIL T15 " +
				"Where  T051.VEND_CD=T13.VEND_CD and T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and T13.CASE_NO=T15.CASE_NO and T15.CASE_NO=T18.CASE_NO and T15.ITEM_SRNO=T18.ITEM_SRNO_PO and T15.CASE_NO=T17.CASE_NO and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and " +
				"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.CASE_NO=T19.CASE_NO(+) and T17.CALL_RECV_DT=T19.CALL_RECV_DT(+) and T17.CALL_SNO=T19.CALL_SNO(+) and T17.MFG_CD=T052.VEND_CD(+) and T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and" +
				"((T17.CALL_MARK_DT between to_date('" + wDtFr + "','dd/mm/yyyy') and to_date('" + wDtTo + "','dd/mm/yyyy') and T17.CALL_STATUS NOT IN('B','C') or (T17.CALL_STATUS='C' and T17.CALL_RECV_DT>'27-FEB-12' and NVL(T19.DOCS_SUBMITTED,'X')='X')) OR (T17.CALL_STATUS IN ('M','U','S','W'))) and T17.IE_CD='" + wIECD + "' and " +
				"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) ";

			if (wSortKey == "V")
			{
				sql = sql + "Order by T051.VEND_NAME,T17.CALL_MARK_DT, T17.CALL_SNO";
			}
			else if (wSortKey == "C")
			{
				sql = sql + "Order by T17.CALL_MARK_DT,T17.CALL_SNO,T051.VEND_NAME";
			}
			try
			{
				cmd.CommandText = sql;
				cmd.Connection = conn;
				conn.Open();
				OracleDataReader readerB = cmd.ExecuteReader();
				Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse' bordercolor='#111111' width='137%'>");
				Response.Write("<tr bgcolor='#FFCCCC'>");
				Response.Write("<th width='7%' valign='top'><font size='1' face='Verdana'></font></th>");
				Response.Write("<th width='7%' valign='top'><font size='1' face='Verdana'></font></th>");
				Response.Write("<th width='7%' valign='top'><font size='1' face='Verdana'></font></th>");
				Response.Write("<th width='7%' valign='top'><font size='1' face='Verdana'>VENDOR NAME</font></th>");
				Response.Write("<th width='7%' valign='top'><font size='1' face='Verdana'>NEW VENDOR</font></th>");
				Response.Write("<th width='7%' valign='top'><font size='1' face='Verdana'>PURCHASER</font></th>");
				Response.Write("<th width='13%'valign='top'><font size='1' face='Verdana'>ITEM</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='1' face='Verdana'>DELV DATE</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='1' face='Verdana'>INSP DESIRE DATE</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='1' face='Verdana'>CALL DATE</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='1' face='Verdana'>CALL SERIAL NO.</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='1' face='Verdana'>CALL DOCUMENT(IF ANY).</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='1' face='Verdana'>CASE NO/VIEW PO</font><IMG id='imga1' src='/RBS/images/New_Blinking.gif' border='0'></th>");
				Response.Write("<th width='5%' valign='top'><font size='1' face='Verdana'>PO SOURCE</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='1' face='Verdana'>STATUS</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='1' face='Verdana'>REMARKS</font></th>");
				//				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>ENGINEER DEPUTED</font></th>");
				//				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>ENGINEER CONTACT NO.</font></th>");
				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>PONO</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='1' face='Verdana'>PO DATE</font></th>");
				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>CONTACT PERSON</font></th>");
				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>CONTACT PERSON PHONE NO.</font></th>");
				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>USER(Other Then IE)</font></th>");
				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>LAST UPDATION DATE</font></th>");
				Response.Write("</tr></font>");
				while (readerB.Read())
				{
					wVendor = "";
					Response.Write("<tr>");
					Response.Write("<td width='7%' valign='top'><a href='Call_Status_Edit_Form.aspx?CASE_NO=" + readerB["CASE_NO"].ToString() + "&CALL_RECV_DT=" + readerB["CALL_RECV_DT"].ToString() + "&CALL_SNO=" + readerB["CALL_SNO"].ToString() + "&IE_CD=" + wIECD + "&ACTION=" + Request.Params["ACTION"].Trim() + "' Font-Names='Verdana' Font-Size='8pt'>Select</a>"); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'><a href='javascript: void(0)' onclick=javascript:window.open('Print_Call_letter.aspx?CASE_NO=" + readerB["CASE_NO"].ToString() + "&CALL_DT=" + readerB["CALL_RECV_DT"].ToString() + "&CALL_SNO=" + readerB["CALL_SNO"].ToString() + "','CustomPopUp','fullscreen=no,scrollbars=yes','width=700,height=800,menubar=no,resizable=no,alwaysRaised=true');return false; Font-Names='Verdana' Font-Size='8pt'>Print</a>"); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'><a href='Query/qryUnInspectedQty.aspx?CASE_NO=" + readerB["CASE_NO"].ToString() + "&ACTION=CHI' Font-Names='Verdana' Font-Size='8pt'>Case History</a>"); Response.Write("</td>");
					//Response.Write("<td width='7%' valign='top'><a href='IC_DETAILS.aspx?CASE_NO="+readerB["CASE_NO"].ToString()+"&CALL_DT="+readerB["CALL_RECV_DT"].ToString()+"&CALL_SNO="+readerB["CALL_SNO"].ToString()+"' Font-Names='Verdana' Font-Size='8pt'>IC Details</a>");Response.Write("</td>");
					//					if(Convert.ToInt16(readerB["COUNT"]) > 1) 
					//					{
					//						Response.Write("<td width='7%' valign='top' align='center'><a href='javascript: void(0)' onclick=javascript:window.open('Print_Call_Items.aspx?CASE_NO="+readerB["CASE_NO"].ToString()+"&CALL_DT="+readerB["CALL_RECV_DT"].ToString()+"&CALL_SNO="+readerB["CALL_SNO"].ToString()+"','CustomPopUp','fullscreen=no,scrollbars=yes','width=700,height=800,menubar=no,resizable=no,alwaysRaised=true');return false; Font-Names='Verdana' Font-Size='8pt'>Print Items Details</a>");Response.Write("</td>");
					//					}
					//					else
					//					{		
					//							Response.Write("<td width='7%' valign='top' align='center'> </td>");
					//					}

					if (Convert.ToInt32(readerB["VEND_CD"]) == Convert.ToInt64(readerB["MFG_CD"]))
					{ wVendor = Convert.ToString(readerB["VENDOR"]); }
					else
					{ wVendor = Convert.ToString(readerB["VENDOR"]) + " <font color='#FF00CC'>At<font color='#3333FF'> " + Convert.ToString(readerB["MANUFACTURER"]); }
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>" + wVendor); Response.Write("</td>");

					if (readerB["NEW_VENDOR"].ToString() == "Y")
					{
						Response.Write("<td width='7%' valign='top'> <font size='1' color=crimson face='Verdana'><b>"); Response.Write("Yes"); Response.Write("</b></font></td>");
					}
					else
					{
						Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
					}

					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["CONSIGNEE"]); Response.Write("</td>");
					if (Convert.ToInt16(readerB["COUNT"]) > 1)
					{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["ITEM_DESC_PO"] + "<font color='#FF00CC'> and more items as per call"); Response.Write("</td>"); }
					else
					{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["ITEM_DESC_PO"]); Response.Write("</td>"); }
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["EXT_DELV_DT"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["INSP_DESIRE_DT"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["CALL_MARK_DT"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerB["CALL_SNO"]); Response.Write("</td>");
					//					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>");Response.Write(readerB["CASE_NO"]);Response.Write("</td>");
					string fpathC = Server.MapPath("/RBS/Vendor/CALLS_DOCUMENTS/" + readerB["CASE_NO"].ToString() + "-" + readerB["CALL_RECV_DT"].ToString().Substring(6, 4) + readerB["CALL_RECV_DT"].ToString().Substring(3, 2) + readerB["CALL_RECV_DT"].ToString().Substring(0, 2) + "-" + readerB["CALL_SNO"].ToString() + ".pdf");
					//SaveLocation = Server.MapPath("CALLS_DOCUMENTS/" + Label27.Text+"-"+txtDtOfReciept.Text.Substring(6,4)+txtDtOfReciept.Text.Substring(3,2)+txtDtOfReciept.Text.Substring(0,2)+"-"+lblCSNO.Text.Trim()+".pdf");
					if (File.Exists(fpathC) == true)
					{
						Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/Vendor/CALLS_DOCUMENTS/" + readerB["CASE_NO"].ToString() + "-" + readerB["CALL_RECV_DT"].ToString().Substring(6, 4) + readerB["CALL_RECV_DT"].ToString().Substring(3, 2) + readerB["CALL_RECV_DT"].ToString().Substring(0, 2) + "-" + readerB["CALL_SNO"].ToString() + ".pdf' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>Call Documents</font></a>"); Response.Write("</td>");
						//HyperLink1.NavigateUrl="/RBS/Vendor/CALLS_DOCUMENTS/" + readerB["CASE_NO"].ToString()+"-"+readerB["CALL_RECV_DT"].ToString().Substring(6,4)+readerB["CALL_RECV_DT"].ToString().Substring(3,2)+readerB["CALL_RECV_DT"].ToString().Substring(0,2)+"-"+readerB["CALL_SNO"].ToString()+".pdf";
					}
					else
					{
						Response.Write("<td width='5%' valign='top'> <font size='1' face='Verdana'></font></td>");
					}
					if (readerB["PO_SOURCE"].ToString() == "C")
					{
						//""+Convert.ToString(readerB["PO_YR"])+"/"++"/"++".pdf";
						OracleCommand cmd2 = new OracleCommand("Select IMMS_RLY_CD from T91_RAILWAYS WHERE RLY_CD='" + Convert.ToString(readerB["RLY_CD"]) + "'", conn);
						string ss = Convert.ToString(cmd2.ExecuteScalar());
						Response.Write("<td width='10%' valign='top' align='center'><a href='https://www.ireps.gov.in/ireps/etender/pdfdocs/MMIS/PO/" + Convert.ToString(readerB["PO_YR"]) + "/" + ss + "/" + Convert.ToString(readerB["PO_NO"]) + ".pdf' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + readerB["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
					}
					else
					{
						string fpath = Server.MapPath("/RBS/CASE_NO/" + readerB["CASE_NO"].ToString() + ".TIF");
						string fpath1 = Server.MapPath("/RBS/CASE_NO/" + readerB["CASE_NO"].ToString() + ".PDF");
						if (File.Exists(fpath) == true)
						{
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/" + readerB["CASE_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + readerB["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
						}
						else if (File.Exists(fpath1) == true)
						{
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/" + readerB["CASE_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + readerB["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
						}
						else
						{

							Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["CASE_NO"]); Response.Write("</td>");
						}
					}
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["SOURCE"]); Response.Write("</td>");
					wColour = "'" + Convert.ToString(readerB["COLOUR"]) + "'";
					Response.Write("<td width='5%' valign='top'> <font size='1' face='Verdana' color=" + wColour + ">"); Response.Write(readerB["CALL_STATUS_FULL"]);
					Response.Write("</font>");
					if (readerB["CALL_STATUS"].ToString() == "U")
					{
						//conn1.Open();
						OracleCommand cmd11 = new OracleCommand("SELECT DECODE(STATUS,'S','SAMPLE RECEIVED ON: '||TO_CHAR(SAMPLE_RECV_DT,'DD/MM/YYYY')||', TOTAL TESTING CHARGES ARE: Rs.'||DECODE(TESTING_CHARGES,0,'_',TESTING_CHARGES)||', LIKELY TEST REPORT RELEASE DATE IS: '||NVL(TO_CHAR(LIKELY_DT_REPORT,'DD/MM/YYYY'),'_'),'C','Lab Report under Compilation','U','Lab Report Uploaded on: '||to_char(LAB_REP_UPLOADED_DT,'dd/mm/yyyy-HH24:MI:SS'),'O','Others- '||REMARKS) FROM T109_LAB_SAMPLE_INFO where CASE_NO='" + readerB["CASE_NO"].ToString() + "' and CALL_RECV_DT=to_date('" + readerB["CALL_RECV_DT"].ToString() + "','dd/mm/yyyy') and CALL_SNO=" + readerB["CALL_SNO"].ToString(), conn);
						string lab_status = Convert.ToString(cmd11.ExecuteScalar());

						//Response.Write("<br><p><font size='1' face='Verdana'>"+lab_status+"</font></p>");

						OracleCommand cmd111 = new OracleCommand("SELECT count(*) FROM T110_LAB_DOC where CASE_NO='" + readerB["CASE_NO"].ToString() + "' and CALL_RECV_DT=to_date('" + readerB["CALL_RECV_DT"].ToString() + "','dd/mm/yyyy') and CALL_SNO=" + readerB["CALL_SNO"].ToString(), conn);
						int payment_reciept = Convert.ToInt32(cmd111.ExecuteScalar());

						if (lab_status != "")
						{
							Response.Write("<br><p><font size='1' face='Verdana'>" + lab_status + "</font></p>");

						}
						else
						{
							Response.Write("<br><p><font size='1' face='Verdana'>Sample Not Recieved in Lab.</font></p>");
						}
						if (payment_reciept != 0)
						{
							Response.Write("<br><p><font size='1' face='Verdana'>Payment Reciept Uploaded By Vendor.</font></p>");
						}
						else
						{
							Response.Write("<br><p><font size='1' face='Verdana'>Payment Reciept Not Uploaded By Vendor.</font></p>");
						}
						string MyFile_ex;
						string mdt_ex = dateconcate(readerB["CALL_RECV_DT"].ToString());
						MyFile_ex = readerB["CASE_NO"].ToString().Trim() + '_' + readerB["CALL_SNO"].ToString().Trim() + '_' + mdt_ex;
						string fpath = Server.MapPath("/RBS/LAB/" + MyFile_ex + ".PDF");
						if (File.Exists(fpath) == true)
						{

							Response.Write("<a href='/RBS/LAB/" + MyFile_ex + ".PDF' Font-Names='Verdana' Font-Size='8pt'>Lab Report</a>");
							//							HyperLink1.Visible=true;
							//							HyperLink1.Text=MyFile_ex;
							//							HyperLink1.NavigateUrl="/RBS/LAB/"+MyFile_ex +".PDF";

						}
						//conn1.Close();
					}
					Response.Write("</td>");
					Response.Write("<td width='5%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["REMARKS"]); Response.Write("</font></td>");
					//					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>");Response.Write(readerB["IE_NAME"]);Response.Write("</td>");
					//					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>");Response.Write(readerB["IE_PHONE_NO"]);Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["PO_NO"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["PO_DATE"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["MFG_PERS"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["MFG_PHONE"]); Response.Write("</td>");
					if (readerB["USER_ID"].ToString().Trim() == Session["IE_EMP_NO"].ToString().Trim())
					{
						Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
					}
					else
					{
						Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["USER_ID"]); Response.Write("</td>");
					}
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["DATETIME"]); Response.Write("</td>");
					Response.Write("</tr>");
				};
				Response.Write("</table>");
				Response.Write("<p align='center'><font face='Verdana'><a href='IE_Menu.aspx'>Go Back </a><font></p>");
				readerB.Dispose();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}
		string dateconcate(string dt)
		{
			string myYear, myMonth, myDay;

			myYear = dt.Substring(6, 4);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;
			return (dt1);
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
	}
}