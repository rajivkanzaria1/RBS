using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Reports
{
    public partial class pfrmCOIEWiseCalls : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrintP;
		protected System.Web.UI.WebControls.Button btnBack;		
		OracleConnection conn1 = null;
		static string wCO_CD, wCONAME;
		static string wDtFr;
		static string wDtTo;
		private string wColour;		
		string wVendor;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!(IsPostBack))
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					DataSet dsP1 = new DataSet();
					string str3 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='" + Session["REGION"] + "' order by CO_NAME ";
					OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
					ListItem lst3;
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP1, "Table");
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
					{
						lst3 = new ListItem();
						lst3.Text = dsP1.Tables[0].Rows[i]["CO_NAME"].ToString();
						lst3.Value = dsP1.Tables[0].Rows[i]["CO_CD"].ToString();
						lstCO.Items.Add(lst3);
					}
					conn1.Close();

					DataSet ds = new DataSet();
					string str = "select CALL_STATUS_CD,CALL_STATUS_DESC from T21_CALL_STATUS_CODES order by CALL_STATUS_DESC";
					OracleDataAdapter dad = new OracleDataAdapter(str, conn1);
					OracleCommand myOracleCmd = new OracleCommand(str, conn1);
					conn1.Open();
					dad.SelectCommand = myOracleCmd;
					conn1.Close();
					dad.Fill(ds, "Table");
					lstCallStatus.DataValueField = "CALL_STATUS_CD";
					lstCallStatus.DataTextField = "CALL_STATUS_DESC";
					lstCallStatus.DataSource = ds;
					lstCallStatus.DataBind();
					lstCallStatus.Items.Insert(0, "All");
					lstCallStatus.SelectedValue = "All";

				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str1);
				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}
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
			this.lstCO.SelectedIndexChanged += new System.EventHandler(this.lstCO_SelectedIndexChanged);
			this.rdbAllIE.CheckedChanged += new System.EventHandler(this.rdbAllIE_CheckedChanged);
			this.rdbPIE.CheckedChanged += new System.EventHandler(this.rdbPIE_CheckedChanged);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		void disAll()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			wCO_CD = lstCO.SelectedValue;
			wCONAME = lstCO.SelectedItem.Text;
			string wSortKey = "";
			if (rdbVendor.Checked == true)
			{
				wSortKey = "V";
			}
			else
			{
				wSortKey = "C";
			}
			//-- 
			OracleCommand cmd = new OracleCommand("Select to_char(add_months(sysdate,-1),'dd/mm/yyyy')DtFr,to_char(sysdate,'dd/mm/yyyy')DtTo from dual", conn1);
			conn1.Open();
			OracleDataReader readerA = cmd.ExecuteReader();
			readerA.Read();
			//wDtFr=Convert.ToString(readerA["DtFr"]); 
			wDtFr = Convert.ToString(readerA["DtFr"]);
			wDtTo = Convert.ToString(readerA["DtTo"]);
			conn1.Close();
			//--

			Response.Write("<TABLE id='Table3' cellSpacing='0' cellPadding='1' width='145%' bgColor='inactivecaptiontext'border='1' borderColor='lightsteelblue'>");
			Response.Write("<TR>");
			Response.Write("<TD width='20%' style='HEIGHT: 20px'></TD>");

			Response.Write("<TD align='center' width='60%' style='HEIGHT: 20px'>");
			Response.Write("<P><FONT style='FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: DarkBlue; LINE-HEIGHT: 8pt; FONT-FAMILY: Verdana; TEXT-ALIGN: center'>RITES INSPECTION & BILLING SYSTEM</FONT></P></TD>");
			Response.Write("<TD align='right' width='20%' style='HEIGHT: 20px'></TD></TR>");


			Response.Write("<TR>");
			//			Response.Write("<TD width='20%' style='HEIGHT: 20px'>");
			//			Response.Write("<P style='LINE-HEIGHT: 8pt'><FONT style='FONT-WEIGHT: normal; FONT-SIZE: 8pt; COLOR: red; LINE-HEIGHT: 8pt; FONT-FAMILY: Verdana; TEXT-ALIGN: center' color='darkblue' size='2'>Welcome: "); 
			//			Response.Write("</FONT><FONT style='FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: red; LINE-HEIGHT: 8pt; FONT-FAMILY: Verdana; TEXT-ALIGN: center' color='darkblue' size='2'>"+wCONAME+"</FONT></P></TD>");

			Response.Write("<TD align='center' width='60%' style='HEIGHT: 20px' colspan='2'>");
			string wSortHdr = "";
			if (wSortKey == "V")
			{
				wSortHdr = "Report Sorted on IE & Vendor Name";
			}
			else if (wSortKey == "C")
			{
				wSortHdr = "Report Sorted on IE & Call Date";
			}
			Response.Write("<p align='center'><font face='Verdana' color='#3333FF'><b>");
			Response.Write("<font size='2'>CALLS  STATUS FOR THE PERIOD " + wDtFr + " TO " + wDtTo + " AND ALL PENDING CALLS</b></font><br>");
			Response.Write("<font size='1'>(STATUS AS ON DATE)- " + wSortHdr + "</font></p>");


			Response.Write("</TD>");
			Response.Write("<TD align='right' width='20%' style='HEIGHT: 20px' align='right'>");
			Response.Write("<font face='Verdana' size=2><b><a href='LogOut.aspx'>Logout</a></b></Font></TD></TR></TABLE>");

			string sql = "";
			if (rdbAllIE.Checked == true)
			{

				//				sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD,(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE,"+
				//					"T18.ITEM_DESC_PO,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') EXT_DELV_DT ,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy')INSP_DESIRE_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,"+
				//					"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,T17.USER_ID, to_char(T17.DATETIME,'dd/mm/yyyy') DATETIME, T17.REMARKS, "+
				//					"trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'C',' on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)'||'/'||'Document Not Received','C',' (Chargeable)'||'/'||'Document Not Received','') CALL_STATUS,T21.CALL_STATUS_COLOR COLOUR,"+
				//					"T052.VEND_CONTACT_PER_1 MFG_PERS,T052.VEND_CONTACT_TEL_1 MFG_PHONE,T17.CALL_SNO,"+ 
				//					"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT "+						
				//					"From T05_VENDOR T051,T03_CITY T03,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052,T03_CITY T032,T21_CALL_STATUS_CODES T21, T19_CALL_CANCEL T19,T15_PO_DETAIL T15  "+ 
				//					"Where  T051.VEND_CD=T13.VEND_CD and T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and T13.CASE_NO=T15.CASE_NO and T15.CASE_NO=T18.CASE_NO and T15.ITEM_SRNO=T18.ITEM_SRNO_PO and T15.CASE_NO=T17.CASE_NO and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and "+
				//					"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.CASE_NO=T19.CASE_NO(+) and T17.CALL_RECV_DT=T19.CALL_RECV_DT(+) and T17.CALL_SNO=T19.CALL_SNO(+) and T17.MFG_CD=T052.VEND_CD(+) and T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and"+
				//					"((T17.CALL_MARK_DT between to_date('"+wDtFr+"','dd/mm/yyyy') and to_date('"+wDtTo+"','dd/mm/yyyy') and T17.CALL_STATUS NOT IN('B','C')or (T17.CALL_STATUS='C' and T17.CALL_RECV_DT>'27-FEB-12' and NVL(T19.DOCS_SUBMITTED,'X')='X')) OR (T17.CALL_STATUS IN ('M','U','S','W'))) and T09.IE_CO_CD='"+wCO_CD+"' and "+ 
				//					"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) ";
				sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD,(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE," +
					"T18.ITEM_DESC_PO,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') EXT_DELV_DT ,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy')INSP_DESIRE_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT," +
					"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,to_char(T13.PO_DT,'yyyy')PO_YR,T13.PO_SOURCE,DECODE(PO_SOURCE,'V','VENDOR','M','MANUAL','C','IREPS','OTHER') SOURCE,T13.RLY_CD,T17.CASE_NO,T17.USER_ID, to_char(T17.DATETIME,'dd/mm/yyyy') DATETIME, T17.REMARKS, NVL(T17.NEW_VENDOR,'X') NEW_VENDOR,T17.CALL_STATUS,  " +
					"trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'C',' on '||to_char(T19.CANCEL_DATE,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)'||'/'||'Document Not Received','C',' (Chargeable)'||'/'||'Document Not Received','') CALL_STATUS_FULL,T21.CALL_STATUS_COLOR COLOUR," +
					"T052.VEND_CONTACT_PER_1 MFG_PERS,T052.VEND_CONTACT_TEL_1 MFG_PHONE,T17.CALL_SNO,T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO IC_PHOTO, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A1' IC_PHOTO_A1, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A2' IC_PHOTO_A2, " +
					"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT " +
					"From T05_VENDOR T051,T03_CITY T03,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052,T03_CITY T032,T21_CALL_STATUS_CODES T21, T19_CALL_CANCEL T19,T15_PO_DETAIL T15  " +
					"Where  T051.VEND_CD=T13.VEND_CD and T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and T13.CASE_NO=T15.CASE_NO and T15.CASE_NO=T18.CASE_NO and T15.ITEM_SRNO=T18.ITEM_SRNO_PO and T15.CASE_NO=T17.CASE_NO and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and " +
					"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.CASE_NO=T19.CASE_NO(+) and T17.CALL_RECV_DT=T19.CALL_RECV_DT(+) and T17.CALL_SNO=T19.CALL_SNO(+) and T17.MFG_CD=T052.VEND_CD(+) and T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and" +
					"((T17.CALL_MARK_DT between to_date('" + wDtFr + "','dd/mm/yyyy') and to_date('" + wDtTo + "','dd/mm/yyyy') and T17.CALL_STATUS NOT IN('B','C') or (T17.CALL_STATUS='C' and T17.CALL_RECV_DT>'27-FEB-12' and NVL(T19.DOCS_SUBMITTED,'X')='X')) OR (T17.CALL_STATUS IN ('M','U','S','W'))) and T09.IE_CO_CD='" + wCO_CD + "' and T09.IE_STATUS IS NULL and " +
					"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) ";
			}
			else if (rdbPIE.Checked == true)
			{

				//				sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD,(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE,"+
				//					"T18.ITEM_DESC_PO,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') EXT_DELV_DT ,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy')INSP_DESIRE_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,"+
				//					"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,T17.USER_ID, to_char(T17.DATETIME,'dd/mm/yyyy') DATETIME, T17.REMARKS, "+
				//					"trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'C',' on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)'||'/'||'Document Not Received','C',' (Chargeable)'||'/'||'Document Not Received','') CALL_STATUS,T21.CALL_STATUS_COLOR COLOUR,"+
				//					"T052.VEND_CONTACT_PER_1 MFG_PERS,T052.VEND_CONTACT_TEL_1 MFG_PHONE,T17.CALL_SNO,"+ 
				//					"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT "+						
				//					"From T05_VENDOR T051,T03_CITY T03,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052,T03_CITY T032,T21_CALL_STATUS_CODES T21, T19_CALL_CANCEL T19,T15_PO_DETAIL T15  "+ 
				//					"Where  T051.VEND_CD=T13.VEND_CD and T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and T13.CASE_NO=T15.CASE_NO and T15.CASE_NO=T18.CASE_NO and T15.ITEM_SRNO=T18.ITEM_SRNO_PO and T15.CASE_NO=T17.CASE_NO and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and "+
				//					"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.CASE_NO=T19.CASE_NO(+) and T17.CALL_RECV_DT=T19.CALL_RECV_DT(+) and T17.CALL_SNO=T19.CALL_SNO(+) and T17.MFG_CD=T052.VEND_CD(+) and T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and"+
				//					"((T17.CALL_MARK_DT between to_date('"+wDtFr+"','dd/mm/yyyy') and to_date('"+wDtTo+"','dd/mm/yyyy') and T17.CALL_STATUS NOT IN('B','C')or (T17.CALL_STATUS='C' and T17.CALL_RECV_DT>'27-FEB-12' and NVL(T19.DOCS_SUBMITTED,'X')='X')) OR (T17.CALL_STATUS IN ('M','U','S','W'))) and T17.IE_CD="+lstIE.SelectedValue+" and T09.IE_CO_CD='"+wCO_CD+"' and "+ 
				//					"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) ";

				sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD,(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE," +
					"T18.ITEM_DESC_PO,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') EXT_DELV_DT ,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy')INSP_DESIRE_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT," +
					"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,to_char(T13.PO_DT,'yyyy')PO_YR,T13.PO_SOURCE,DECODE(PO_SOURCE,'V','VENDOR','M','MANUAL','C','IREPS','OTHER') SOURCE,T13.RLY_CD,T17.CASE_NO,T17.USER_ID, to_char(T17.DATETIME,'dd/mm/yyyy') DATETIME, T17.REMARKS, NVL(T17.NEW_VENDOR,'X') NEW_VENDOR,T17.CALL_STATUS, " +
					"trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'C',' on '||to_char(T19.CANCEL_DATE,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)'||'/'||'Document Not Received','C',' (Chargeable)'||'/'||'Document Not Received','') CALL_STATUS_FULL,T21.CALL_STATUS_COLOR COLOUR," +
					"T052.VEND_CONTACT_PER_1 MFG_PERS,T052.VEND_CONTACT_TEL_1 MFG_PHONE,T17.CALL_SNO, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO IC_PHOTO, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A1' IC_PHOTO_A1, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A2' IC_PHOTO_A2, " +
					"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT " +
					"From T05_VENDOR T051,T03_CITY T03,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052,T03_CITY T032,T21_CALL_STATUS_CODES T21, T19_CALL_CANCEL T19,T15_PO_DETAIL T15  " +
					"Where  T051.VEND_CD=T13.VEND_CD and T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and T13.CASE_NO=T15.CASE_NO and T15.CASE_NO=T18.CASE_NO and T15.ITEM_SRNO=T18.ITEM_SRNO_PO and T15.CASE_NO=T17.CASE_NO and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and " +
					"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.CASE_NO=T19.CASE_NO(+) and T17.CALL_RECV_DT=T19.CALL_RECV_DT(+) and T17.CALL_SNO=T19.CALL_SNO(+) and T17.MFG_CD=T052.VEND_CD(+) and T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and" +
					"((T17.CALL_MARK_DT between to_date('" + wDtFr + "','dd/mm/yyyy') and to_date('" + wDtTo + "','dd/mm/yyyy') and T17.CALL_STATUS NOT IN('B','C') or (T17.CALL_STATUS='C' and T17.CALL_RECV_DT>'27-FEB-12' and NVL(T19.DOCS_SUBMITTED,'X')='X')) OR (T17.CALL_STATUS IN ('M','U','S','W'))) and T17.IE_CD=" + lstIE.SelectedValue + " and T09.IE_CO_CD='" + wCO_CD + "' and " +
					"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) ";


			}
			if (lstCallStatus.SelectedValue == "All")
			{
				sql = sql + " and ( (T17.CALL_STATUS NOT IN('B','C')) or (T17.CALL_STATUS='C' and T17.CALL_RECV_DT>'27-FEB-12' and NVL(T19.DOCS_SUBMITTED,'X')='X') OR (T17.CALL_STATUS IN ('M','U','S','W')))";
			}
			else
			{
				sql = sql + " and T17.CALL_STATUS ='" + lstCallStatus.SelectedValue + "' ";
			}
			if (wSortKey == "V")
			{
				sql = sql + "Order by T09.IE_NAME,T051.VEND_NAME,T17.CALL_MARK_DT, T17.CALL_SNO";
			}
			else if (wSortKey == "C")
			{
				sql = sql + "Order by T09.IE_NAME,T17.CALL_MARK_DT, T17.CALL_SNO,T051.VEND_NAME";
			}
			try
			{
				cmd.CommandText = sql;
				cmd.Connection = conn1;
				conn1.Open();
				OracleDataReader readerB = cmd.ExecuteReader();
				Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse' bordercolor='#111111' width='137%'>");
				Response.Write("<tr bgcolor='#FFCCCC'>");
				//				Response.Write("<th width='7%' valign='top'><font size='1' face='Verdana'></font></th>");
				Response.Write("<th width='7%' valign='top'><font size='1' face='Verdana'></font></th>");
				//				Response.Write("<th width='7%' valign='top'><font size='1' face='Verdana'></font></th>");
				Response.Write("<th width='7%' valign='top'><font size='1' face='Verdana'>IE NAME</font></th>");
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
				if (lstCallStatus.SelectedValue == "M")
				{
					Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>TAKEN IN TODAY'S WORKPLAN</font></th>");
				}
				Response.Write("<th width='5%' valign='top'><font size='1' face='Verdana'>PO SOURCE</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='1' face='Verdana'>STATUS</font></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>VIEW IC</font></b></th>");
				Response.Write("<th width='5%' valign='top'><font size='1' face='Verdana'>REMARKS</font></th>");
				//				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>ENGINEER DEPUTED</font></th>");
				//				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>ENGINEER CONTACT NO.</font></th>");
				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>PONO</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='1' face='Verdana'>PO DATE</font></th>");
				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>CONTACT PERSON</font></th>");
				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>CONTACT PERSON PHONE NO.</font></th>");
				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>USER</font></th>");
				Response.Write("<th width='8%' valign='top'><font size='1' face='Verdana'>LAST UPDATION DATE</font></th>");

				Response.Write("</tr></font>");
				while (readerB.Read())
				{
					wVendor = "";
					Response.Write("<tr>");
					//					Response.Write("<td width='7%' valign='top'><a href='Call_Status_Edit_Form.aspx?CASE_NO="+readerB["CASE_NO"].ToString()+"&CALL_RECV_DT="+readerB["CALL_RECV_DT"].ToString()+"&CALL_SNO="+readerB["CALL_SNO"].ToString()+"&IE_CD="+wIECD+"&ACTION="+Request.Params ["ACTION"].Trim()+"' Font-Names='Verdana' Font-Size='8pt'>Select</a>");Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'><a href='javascript: void(0)' onclick=javascript:window.open('/Print_Call_letter.aspx?CASE_NO=" + readerB["CASE_NO"].ToString() + "&CALL_DT=" + readerB["CALL_RECV_DT"].ToString() + "&CALL_SNO=" + readerB["CALL_SNO"].ToString() + "','CustomPopUp','fullscreen=no,scrollbars=yes','width=700,height=800,menubar=no,resizable=no,alwaysRaised=true');return false; Font-Names='Verdana' Font-Size='8pt'>Print</a>"); Response.Write("</td>");
					//					if(Convert.ToInt16(readerB["COUNT"]) > 1) 
					//					{
					//						Response.Write("<td width='7%' valign='top' align='center'><a href='javascript: void(0)' onclick=javascript:window.open('/RBS/Print_Call_Items.aspx?CASE_NO="+readerB["CASE_NO"].ToString()+"&CALL_DT="+readerB["CALL_RECV_DT"].ToString()+"&CALL_SNO="+readerB["CALL_SNO"].ToString()+"','CustomPopUp','fullscreen=no,scrollbars=yes','width=700,height=800,menubar=no,resizable=no,alwaysRaised=true');return false; Font-Names='Verdana' Font-Size='8pt'>Print Items Details</a>");Response.Write("</td>");
					//					}
					//					else
					//					{		
					//						Response.Write("<td width='7%' valign='top' align='center'> </td>");
					//					}

					if (Convert.ToInt32(readerB["VEND_CD"]) == Convert.ToInt64(readerB["MFG_CD"]))
					{ wVendor = Convert.ToString(readerB["VENDOR"]); }
					else
					{ wVendor = Convert.ToString(readerB["VENDOR"]) + " <font color='#FF00CC'>At<font color='#3333FF'> " + Convert.ToString(readerB["MANUFACTURER"]); }
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["IE_NAME"]); Response.Write("</td>");
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
						OracleCommand cmd2 = new OracleCommand("Select IMMS_RLY_CD from T91_RAILWAYS WHERE RLY_CD='" + Convert.ToString(readerB["RLY_CD"]) + "'", conn1);
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


					if (lstCallStatus.SelectedValue == "M")
					{
						OracleCommand cmd1 = new OracleCommand("Select decode(nvl(count(*),0),0,'No','Yes') VISIT from T47_IE_WORK_PLAN where CASE_NO='" + readerB["CASE_NO"].ToString() + "' and CALL_RECV_DT=to_date('" + readerB["CALL_RECV_DT"].ToString() + "','dd/mm/yyyy') and CALL_SNO=" + readerB["CALL_SNO"].ToString() + " AND VISIT_DT=to_date('" + wDtTo + "','dd/mm/yyyy')", conn1);
						string VISIT = Convert.ToString(cmd1.ExecuteScalar());
						Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(VISIT); Response.Write("</td>");
					}
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["SOURCE"]); Response.Write("</td>");
					wColour = "'" + Convert.ToString(readerB["COLOUR"]) + "'";
					Response.Write("<td width='5%' valign='top'> <font size='1' face='Verdana' color=" + wColour + ">"); Response.Write(readerB["CALL_STATUS_FULL"]); Response.Write("</font>");
					if (readerB["CALL_STATUS"].ToString() == "U")
					{
						//conn1.Open();
						OracleCommand cmd11 = new OracleCommand("SELECT DECODE(STATUS,'S','SAMPLE RECEIVED ON: '||TO_CHAR(SAMPLE_RECV_DT,'DD/MM/YYYY')||', TOTAL TESTING CHARGES ARE: Rs.'||DECODE(TESTING_CHARGES,0,'_',TESTING_CHARGES)||', LIKELY TEST REPORT RELEASE DATE IS: '||NVL(TO_CHAR(LIKELY_DT_REPORT,'DD/MM/YYYY'),'_'),'C','Lab Report under Compilation','U','Lab Report Uploaded on: '||to_char(LAB_REP_UPLOADED_DT,'dd/mm/yyyy-HH24:MI:SS'),'O','Others- '||REMARKS) FROM T109_LAB_SAMPLE_INFO where CASE_NO='" + readerB["CASE_NO"].ToString() + "' and CALL_RECV_DT=to_date('" + readerB["CALL_RECV_DT"].ToString() + "','dd/mm/yyyy') and CALL_SNO=" + readerB["CALL_SNO"].ToString(), conn1);
						string lab_status = Convert.ToString(cmd11.ExecuteScalar());
						if (lab_status != "")
						{
							Response.Write("<br><p><font size='1' face='Verdana'>" + lab_status + "</font></p>");
						}
						else
						{
							Response.Write("<br><p><font size='1' face='Verdana'>Sample Not Recieved in Lab.</font></p>");
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
					string fpath_jpg = Server.MapPath("/RBS/BILL_IC/" + readerB["IC_PHOTO"].ToString() + ".JPG");
					string fpath_pdf = Server.MapPath("/RBS/BILL_IC/" + readerB["IC_PHOTO"].ToString() + ".PDF");
					if (File.Exists(fpath_jpg) == false && File.Exists(fpath_pdf) == false)
					{
						Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					}
					else
					{
						if (File.Exists(fpath_jpg) == true)
						{
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + readerB["IC_PHOTO"].ToString() + ".JPG' Font-Names='Verdana' Font-Size='8pt'>IC</a>");
						}
						else if (File.Exists(fpath_pdf) == true)
						{
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + readerB["IC_PHOTO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='8pt'>IC</a>");
						}

						string fpath3_jpg = Server.MapPath("/RBS/TESTPLAN/" + readerB["IC_PHOTO"].ToString() + ".JPG");
						string fpath3_pdf = Server.MapPath("/RBS/TESTPLAN/" + readerB["IC_PHOTO"].ToString() + ".PDF");

						if (File.Exists(fpath3_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/TESTPLAN/" + readerB["IC_PHOTO"].ToString() + ".JPG'>Testplan/Lab Test Reports</a>");
						}
						else if (File.Exists(fpath3_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/TESTPLAN/" + readerB["IC_PHOTO"].ToString() + ".PDF'>Testplan/Lab Test Reports</a>");
						}

						string fpath1_jpg = Server.MapPath("/RBS/BILL_IC/" + readerB["IC_PHOTO_A1"].ToString() + ".JPG");
						string fpath1_pdf = Server.MapPath("/RBS/BILL_IC/" + readerB["IC_PHOTO_A1"].ToString() + ".PDF");
						string fpath2_jpg = Server.MapPath("/RBS/BILL_IC/" + readerB["IC_PHOTO_A2"].ToString() + ".JPG");
						string fpath2_pdf = Server.MapPath("/RBS/BILL_IC/" + readerB["IC_PHOTO_A2"].ToString() + ".PDF");
						if (File.Exists(fpath1_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + readerB["IC_PHOTO_A1"].ToString() + ".JPG'>IC Annex 1</a>");
						}
						else if (File.Exists(fpath1_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + readerB["IC_PHOTO_A1"].ToString() + ".PDF'>IC Annex 1</a>");
						}

						if (File.Exists(fpath2_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + readerB["IC_PHOTO_A2"].ToString() + ".JPG'>IC Annex 2</a>");
						}
						else if (File.Exists(fpath2_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + readerB["IC_PHOTO_A2"].ToString() + ".PDF'>IC Annex 2</a>");
						}


						Response.Write("</td>");
					}

					Response.Write("<td width='5%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["REMARKS"]); Response.Write("</font></td>");
					//					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>");Response.Write(readerB["IE_NAME"]);Response.Write("</td>");
					//					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>");Response.Write(readerB["IE_PHONE_NO"]);Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["PO_NO"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["PO_DATE"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["MFG_PERS"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["MFG_PHONE"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["USER_ID"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(readerB["DATETIME"]); Response.Write("</td>");

					Response.Write("</tr>");
				};
				Response.Write("</table>");
				//				Response.Write("<p align='center'><font face='Verdana'><a href='IE_Menu.aspx'>Go Back </a><font></p>");
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
				conn1.Close();
			}

		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Panel2.Visible = true;
			Panel1.Visible = false;
			disAll();
		}

		private void rdbPIE_CheckedChanged(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				lstIE.Items.Clear();
				DataSet dsP2 = new DataSet();
				string str2 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' AND IE_CO_CD=" + lstCO.SelectedValue + " order by IE_NAME ";
				OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
				ListItem lst2;
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
				{
					lst2 = new ListItem();
					lst2.Text = dsP2.Tables[0].Rows[i]["IE_NAME"].ToString();
					lst2.Value = dsP2.Tables[0].Rows[i]["IE_CD"].ToString();
					lstIE.Items.Add(lst2);
				}
				lstIE.Items.Insert(0, "");
				conn1.Close();
				lstIE.Visible = true;
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

		private void lstCO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			rdbAllIE.Checked = true;
			lstIE.Visible = false;
		}

		private void rdbAllIE_CheckedChanged(object sender, System.EventArgs e)
		{
			lstIE.Visible = false;
		}
	}
}
