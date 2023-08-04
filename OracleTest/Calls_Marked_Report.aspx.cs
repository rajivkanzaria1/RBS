using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Calls_Marked_Report
{
	public partial class Calls_Marked_Report : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox date_fr;
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		static string wDtFr;
		static string wDtTo;
		static string wRegion;
		static string wRgn_Name;
		string wVendor;
		string wSortKey;
		string wSortHdr;
		int wCallCtr;

		private string wColour;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			wCallCtr = 0;
			wDtFr = Request.Params["pDtFr"].ToString();
			wDtTo = Request.Params["pDtTo"].ToString();
			wRegion = Request.Params["pRegion"].ToString();
			wSortKey = Request.Params["pSortKey"].ToString();

			if (wRegion == "N")
			{ wRgn_Name = "NORTHERN REGION"; }
			else if (wRegion == "W")
			{ wRgn_Name = "WESTERN REGION"; }
			else if (wRegion == "E")
			{ wRgn_Name = "EASTERN REGION"; }
			else if (wRegion == "S")
			{ wRgn_Name = "SOUTHERN REGION"; }
			else if (wRegion == "C")
			{ wRgn_Name = "CENTRAL REGION"; }
			else
			{ wRgn_Name = "--x--"; }

			//			string sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD,"+
			//				"(T06.CONSIGNEE_FIRM||' '||T06.CONSIGNEE_DESIG) CONSIGNEE,T18.ITEM_DESC_PO,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,"+
			//				"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,"+
			//				"decode(T17.CALL_STATUS,'M','Pending','A','Accepted'||nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'R','Rejection'||nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'C','Cancelled on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection','W','Withheld')||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,"+
			//				"decode(T17.CALL_STATUS,'M','#FF0033','A','#006600','R','#3333FF','C','#6600CC','U','#FF00CC','S','#FF9966','G','#FF9966','W','#0000FF','#000000')COLOUR,"+
			//				"T052.VEND_CONTACT_PER_1 MFG_PERS,(T052.VEND_CONTACT_TEL_1) MFG_PHONE,T17.CALL_SNO,"+ 
			//				"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT, nvl2(T08.CO_PHONE_NO,trim(T08.CO_NAME)||' (Mob: '||CO_PHONE_NO||')',T08.CO_NAME)CO_NAME "+
			//				"From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052, T03_CITY T03, T03_CITY T032, T08_IE_CONTROLL_OFFICER T08 "+ 
			//				"Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO and "+
			//				"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and "+
			//				"(T17.CALL_MARK_DT between to_date('"+wDtFr+"','dd/mm/yyyy') and to_date('"+wDtTo+"','dd/mm/yyyy')) and "+ 
			//				"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) and  "+
			//				"T17.REGION_CODE='"+wRegion+"' and T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and T08.CO_CD(+)=T09.IE_CO_CD ";
			string sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD," +
				"(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE,T18.ITEM_DESC_PO,T18.QTY_TO_INSP,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') EXT_DELV_DT, to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT," +
				"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,T17.REMARKS REMARK, " +
				"trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')','')||' Dt: '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'B',' (Accepted on Dt:'||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy')||')','R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'G',' Dt: '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'C',' on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,T21.CALL_STATUS_COLOR COLOUR," +
				"T052.VEND_CONTACT_PER_1 MFG_PERS,(T052.VEND_CONTACT_TEL_1) MFG_PHONE,T17.CALL_SNO," +
				"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT, nvl2(T08.CO_PHONE_NO,trim(T08.CO_NAME)||' (Mob: '||CO_PHONE_NO||')',T08.CO_NAME)CO_NAME " +
				"From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052, T03_CITY T03, T03_CITY T032, T08_IE_CONTROLL_OFFICER T08,T21_CALL_STATUS_CODES T21,T15_PO_DETAIL T15  " +
				"Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and T13.CASE_NO=T15.CASE_NO and T15.CASE_NO=T18.CASE_NO and T15.ITEM_SRNO=T18.ITEM_SRNO_PO and T15.CASE_NO=T17.CASE_NO and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and " +
				"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and " +
				"(T17.CALL_MARK_DT between to_date('" + wDtFr + "','dd/mm/yyyy') and to_date('" + wDtTo + "','dd/mm/yyyy')) and " +
				"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) and  " +
				"T17.REGION_CODE='" + wRegion + "' and T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and T08.CO_CD(+)=T09.IE_CO_CD ";



			if (wSortKey == "V")
			{
				sql = sql + "Order by T051.VEND_NAME,T17.CALL_MARK_DT, T17.CALL_SNO ";
				wSortHdr = "Report Sorted on Vendor Name";
			}
			else
			{
				sql = sql + "Order by T17.CALL_MARK_DT, T17.CALL_SNO, T051.VEND_NAME";
				wSortHdr = "Report Sorted on Call Date";
			}

			try
			{
				if (Session["Uname"].ToString() != "")
				{
					OracleCommand cmd = new OracleCommand(sql, conn);
					conn.Open();
					OracleDataReader reader = cmd.ExecuteReader();
					Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse' bordercolor='#111111' width='130%'>");
					Response.Write("<tr>"); Response.Write("<td width='100%' bgcolor='#FFFFCC' colspan='16'>");
					Response.Write("<p align='center'><font face='Verdana' color='#3333FF'><b>");
					Response.Write("<font size='4'>CALLS  STATUS FOR THE PERIOD " + wDtFr + " TO " + wDtTo + " </b></font><br>");
					Response.Write("<font size='2'>(STATUS OF <b>" + wRgn_Name + "</b> AS ON DATE) - " + wSortHdr + "</font></p>");
					Response.Write("</td>"); Response.Write("</tr>");
					Response.Write("<tr bgcolor='#FFCCCC'>");
					Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>SNO</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>VENDOR NAME</font></b></th>");
					if (Session["Uname"].ToString() != "")
					{
						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>PURCHASER</font></b></th>");
						Response.Write("<th width='13%' valign='top'><b><font size='1' face='Verdana'>ITEM</font></b></th>");
					}
					Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>QTY OFF</font></b></th>");
					Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>DELV DATE</font></b></th>");
					Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CALL DATE</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>ENGINEER DEPUTED</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>ENGINEER CONTACT NO.</font></b></th>");
					Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>PONO</font></b></th>");
					Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>PO DATE</font></b></th>");
					Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CASE NO</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>STATUS</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CONTACT PERSON</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CONTACT PERSON PHONE NO.</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CALL SERIAL NO.</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CONTROLLING MANAGER</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>REMARKS</font></b></th></tr>");
					Response.Write("</tr></font>");
					string wmar_msg = "Note: Please ensure Inspection Call is submitted at least five(5) working days before the expiry of the delivery period , otherwise Call shall not be accepted. Inspection call format is now revised from 5th March 2013. Henceforth all requests for inspection should be submitted in the new format only with all entries filled up. Any incomplete inspection call not be considered and summarily rejected. <Font Color='blue'>For quick response from RITES LTD, Kindly mention Email-ID and Contact Person's Mobile No. in the Call Format.</Font><Font Color='OrangeRed'>As per latest Railway Board order, the offered material value should be of minimum 1.5 Lakh for RITES Inspection.</font><Font Color='green'> Some Vendors are directly depositing payments throught DD/NEFT ro RITES Account without informing payment details & Case particulars. All Vendors are kindly requested to always inform concerned regional office immidiately through E-Mail, Such payments details indicating Case No. for proper accountal of their credits.  </font>";
					if (Session["Uname"].ToString() == "")
					{
						//						if(wRegion=="N")
						//						{
						//							wmar_msg=wmar_msg+" Please note one additional FAX No. 011-22029122 is also made operational to recieve Calls.";
						//						}

						Response.Write("<tr><td width='100%'colspan='16' align='center' bgcolor='#FFFFCC'><b><font size='1' face='Verdana' color='red'><marquee behavior=scroll>" + wmar_msg + "</marquee></font></b></td></tr>");

					}
					while (reader.Read())
					{
						wCallCtr = wCallCtr + 1;
						wVendor = "";
						Response.Write("<tr>");
						Response.Write("<td width='4%' valign='top'> <font size='1' face='Verdana'>" + wCallCtr); Response.Write("</td>");
						if (Convert.ToInt32(reader["VEND_CD"]) == Convert.ToInt64(reader["MFG_CD"]))
						{ wVendor = Convert.ToString(reader["VENDOR"]); }
						else
						{ wVendor = Convert.ToString(reader["VENDOR"]) + " <font color='#FF00CC'>At<font color='#3333FF'> " + Convert.ToString(reader["MANUFACTURER"]); }
						Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>" + wVendor); Response.Write("</td>");
						if (Session["Uname"].ToString() != "")
						{
							Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
							if (Convert.ToInt16(reader["COUNT"]) > 1)
							{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"] + "<font color='#FF00CC'> and more items as per call"); Response.Write("</td>"); }
							else
							{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>"); }
						}
						Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_TO_INSP"]); Response.Write("</td>");
						Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["EXT_DELV_DT"]); Response.Write("</td>");
						Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_MARK_DT"]); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_PHONE_NO"]); Response.Write("</td>");
						Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						wColour = "'" + Convert.ToString(reader["COLOUR"]) + "'";
						Response.Write("<td width='5%' valign='top'> <font size='1' face='Verdana' color=" + wColour + ">"); Response.Write(reader["CALL_STATUS"]); Response.Write("</font></td>");
						Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_PERS"]); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_PHONE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
						if (Session["Uname"].ToString() == "")
						{
							Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						}
						else
						{
							Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["REMARK"]); Response.Write("</td>");
						}
						Response.Write("</tr>");
					};
					Response.Write("</table>");
					Response.Write("<p align='center'><font face='Verdana'><a href='javascript:history.go(-1);'>Go Back </a><font></p>");
				}
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
			}
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