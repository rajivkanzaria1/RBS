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
    public partial class pfrmFromToDate : System.Web.UI.Page
    {
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Panel Panel_2;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.Button btnBack;
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		
		string wFrmDt, wToDt, wRegion;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.RadioButton rdbBillDt;
		protected System.Web.UI.WebControls.RadioButton rdbICDT;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList lstCallStatus;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.RadioButton rdbAllCM;
		protected System.Web.UI.WebControls.RadioButton rdbPCM;
		protected System.Web.UI.WebControls.DropDownList lstCO;
		protected System.Web.UI.WebControls.RadioButton rdbAllSector;
		protected System.Web.UI.WebControls.RadioButton rdbPSector;
		protected System.Web.UI.WebControls.DropDownList ddlItemScope;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.RadioButton RdbIE;
		protected System.Web.UI.WebControls.RadioButton RdbCM;
		protected System.Web.UI.WebControls.DropDownList DDL_STATUS;
		protected System.Web.UI.WebControls.RadioButton Rdb_INI;
		protected System.Web.UI.WebControls.Label Label_CS;
		protected System.Web.UI.WebControls.RadioButton Radio_all_cm;
		protected System.Web.UI.WebControls.RadioButton Radio_cm;
		protected System.Web.UI.WebControls.DropDownList lst_co_h;
		protected System.Web.UI.WebControls.RadioButton rdbValue;
		protected System.Web.UI.WebControls.RadioButton rdbDP;
		protected System.Web.UI.WebControls.RadioButton rdbDesireDt;
		protected System.Web.UI.WebControls.RadioButton rdbPendingSince;
		protected System.Web.UI.WebControls.RadioButton Rdb_APP;

		private void Page_Load(object sender, System.EventArgs e)
		{
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
			if (!(IsPostBack))
			{
				DataSet ds = new DataSet();
				string str = "select CALL_STATUS_CD,CALL_STATUS_DESC from T21_CALL_STATUS_CODES order by CALL_STATUS_DESC";
				OracleDataAdapter dad = new OracleDataAdapter(str, conn);
				OracleCommand myOracleCmd = new OracleCommand(str, conn);
				conn.Open();
				dad.SelectCommand = myOracleCmd;
				conn.Close();
				dad.Fill(ds, "Table");
				lstCallStatus.DataValueField = "CALL_STATUS_CD";
				lstCallStatus.DataTextField = "CALL_STATUS_DESC";
				lstCallStatus.DataSource = ds;
				lstCallStatus.DataBind();
				//lstCallStatus.Items.Insert(0, "All");
				//lstCallStatus.SelectedValue = "All";

				DataSet dsP2 = new DataSet();
				string str2 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_REGION='" + Session["REGION"] + "' and CO_STATUS is null order by CO_NAME ";
				OracleDataAdapter da2 = new OracleDataAdapter(str2, conn);
				OracleCommand myOracleCommand2 = new OracleCommand(str2, conn);
				ListItem lst1;
				conn.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
				{
					lst1 = new ListItem();
					lst1.Text = dsP2.Tables[0].Rows[i]["CO_NAME"].ToString();
					lst1.Value = dsP2.Tables[0].Rows[i]["CO_CD"].ToString();
					lstCO.Items.Add(lst1);
					lst_co_h.Items.Add(lst1);
				}
				conn.Close();
				ListItem lst = new ListItem();
				lst = new ListItem();
				lst.Text = "ALL";
				lst.Value = "1";
				DDL_STATUS.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Pending";
				lst.Value = "2";
				DDL_STATUS.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Approved";
				lst.Value = "3";
				DDL_STATUS.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Rejected";
				lst.Value = "4";
				DDL_STATUS.Items.Add(lst);

			}
			//			if(Request.Params ["ACTION"].Trim().ToString()=="MOZPOS")
			//			 {
			//				Label4.Visible=false;
			//				lstCallStatus.Visible=false;
			//			 }

			if (Request.Params["ACTION"].Trim().ToString() == "ICISSUEDNSUB")
			{
				if (Convert.ToString(Session["Uname"]) != "")
				{
					RdbIE.Visible = true;
					RdbCM.Visible = true;

				}
				else if (Convert.ToString(Session["IE_CD"]) != "")
				{
					RdbIE.Visible = false;
					RdbCM.Visible = false;
					RdbIE.Checked = true;
					RdbCM.Checked = false;

				}
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.rdbAllCM.CheckedChanged += new System.EventHandler(this.rdbPCM_CheckedChanged);
			this.rdbPCM.CheckedChanged += new System.EventHandler(this.rdbPCM_CheckedChanged);
			this.rdbAllSector.CheckedChanged += new System.EventHandler(this.rdbAllSector_CheckedChanged);
			this.rdbPSector.CheckedChanged += new System.EventHandler(this.rdbAllSector_CheckedChanged);
			this.Radio_all_cm.CheckedChanged += new System.EventHandler(this.Radio_all_cm_CheckedChanged);
			this.Radio_cm.CheckedChanged += new System.EventHandler(this.Radio_all_cm_CheckedChanged);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		string dateconcat(string dt)
		{
			string myYear, myMonth, myDay;
			myYear = dt.Substring(6, 4);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt_out = myYear + myMonth + myDay;
			return (dt_out);
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Panel_2.Visible = false;
			Panel_1.Visible = true;
			wToDt = toDt.Text.Trim();
			wFrmDt = frmDt.Text.Trim();
			wRegion = "";

			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

			if (Convert.ToString(Request.Params["ACTION"].Trim()) == "Rejection")
			{
				RejectionIC();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "Reinspection")
			{
				ReInspectionIC_BPOwise();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "IE_X")
			{
				ie_performance_expanded();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CLUSTER_X")
			{
				cluster_performance_expanded();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "BA")
			{
				billing_analysis();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "UPCL")
			{
				upcl_expend_report();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "BATOS")
			{
				bills_adjusted_of_old_system();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "MA")
			{
				misc_adjustments();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ATTR")
			{
				amt_transferred_to_regions();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ARFR")
			{
				amt_received_from_regions();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "EFT")
			{
				EFT();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "TDS")
			{
				TDS();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "STAX")
			{
				SERVICE_TAX();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "NSTAX")
			{
				NEW_SERVICE_TAX();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "WOF")
			{
				write_off_amt_statement();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "RET")
			{
				retention_amt_statement();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CIE")
			{
				IEWiseCallStatus();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CIEU")
			{
				IEWiseCallStatus_update();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "DWB")
			{
				discipline_wise_billing();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CR")
			{
				contract_review();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "SUMCALLX")
			{
				summary_calls_cancelled();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ICSUBMIT")
			{
				summary_ic_submitted();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CALLSWITHOUTIC")
			{
				AorRcallswithoutIC();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CWPOANDVALUE")
			{
				client_wisepoandvalue();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "REMCALLS")
			{
				remarked_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "VOUCHERDETAILS")
			{
				Vouchers_Chq_Amt();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "DCWACOMPS")
			{
				Defectcodewise_Compliants();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "BSS")
			{
				details_of_bills_notscanned();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "STAMP")
			{
				IEWiseSealingStatus();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CLRETURN")
			{
				call_return_report();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ICISSUEDNSUB")
			{
				ic_issued_notsubmitted();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "NOOFCALLS")
			{
				no_calls_online_manual();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "PJI")
			{
				pending_ji_cases();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "FIRERETVENDCALL")
			{
				fire_retardant_vendors_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "IECITYCALLS")
			{
				IECityWiseCallStatus();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "TEXTILEITEMS")
			{
				textile_items_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "OHEITEMS")
			{
				OHE_items_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "IE_DAIRY")
			{
				ie_dairy();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "SUPSUR")
			{
				super_surprise();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CALLSATTENDED2DAYS")
			{
				ie_calls_attended_2days();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "AFTEREXPDT")
			{
				calls_attended_afterexpected_date();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ONLINENRPAYMENTS")
			{
				online_nr_payments();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "PLEXCEPT")
			{
				po_unlinked_mchksheet();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "PLLINKED")
			{
				po_linked_mchksheet();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CALLEXCEPT")
			{
				call_unlinked_mchksheet();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "PLLINKEDCHK")
			{
				pl_linked();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "SUMMARYAFTEREXPDT")
			{
				summary_calls_attended_afterexpected_date();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ICFBILLDET")
			{
				icf_billing_details();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CCAPP")
			{
				call_cancel_approval();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "LABR")
			{
				LAB_INVOICE_RPT();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CHECK")
			{
				CHECK_SHEET();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "MOZCALLS")
			{
				MOZ_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "PHED")
			{
				PHED_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "MOZPOS")
			{
				MOZ_POS();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "RETBILLSBPOCHANGE")
			{
				RETURNED_BILLS_CHANGE_BPO();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "UNBILLEDIC")
			{
				unbilled_ic();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CREDITNOTE")
			{
				credit_note_invoices();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "SUPSURPSUMM")
			{
				super_surprise_summary();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "TECH")
			{
				TECH_REF();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CMWISEICNI")
			{
				cm_issued_notsubmitted();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "COUNTIC")
			{
				Cum_ICissuednotsubmitted();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "REMARKING")
			{
				Remarking_rpt();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "HIGHVALUE")
			{
				High_Valuecalls();
			}

		}

		void super_surprise_summary()
		{

			 conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//conn = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
			//			if(Request.Params["DT"]!= null || Request.Params["DT"]!= "")
			//			{
			//				wToDt=Convert.ToString(Request.Params ["DT"].Trim());
			//				
			//			}
			string wHdr_YrMth;
			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;

			string wRegion = "";
			if (Session["Region"].ToString() == "N")
			{
				wRegion = "Northern Region";
			}
			else if (Session["Region"].ToString() == "S")
			{
				wRegion = "Southern Region";
			}
			else if (Session["Region"].ToString() == "E")
			{
				wRegion = "Eastern Region";
			}
			else if (Session["Region"].ToString() == "W")
			{
				wRegion = "Western Region";
			}
			else if (Session["Region"].ToString() == "C")
			{
				wRegion = "Central Region";
			}

			conn.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn.Close();

			string sql = "Select T44.CO_CD,T08.CO_NAME,T44.IE_CD,T09.IE_NAME, COUNT(*) SUP_SUR_NO from T44_SUPER_SURPRISE T44,T09_IE T09,T08_IE_CONTROLL_OFFICER T08 " +
				"Where T44.IE_CD=T09.IE_CD and T44.CO_CD=T08.CO_CD AND (T44.SUPER_SURPRISE_DT between to_date('" + frmDt.Text + "','dd/mm/yyyy') and to_date('" + toDt.Text + "','dd/mm/yyyy')) AND SUBSTR(CASE_NO,1,1)='" + Session["Region"].ToString() + "' ";
			sql = sql + " GROUP BY T44.CO_CD,T08.CO_NAME,T44.IE_CD,T09.IE_NAME order by T08.CO_NAME,T09.IE_NAME";

			string wCO_CD = "";
			int ctr = 60;
			int wSno = 0;
			int cm_wise_tot = 0;
			int wSup_grand_total = 0;
			//			int wNC_Codes_Sno=0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='4'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='4'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='right'><font face='Verdana'>Run Date: " + ss + "</font></p>");
				Response.Write("<H6 align='center'><font face='Verdana'>CO Wise Super Surprise Registered during " + wHdr_YrMth + "</font><br></p>");
				Response.Write("</td>");

				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>CO Name</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>No. of Super Surprise</font></b></th>");
				Response.Write("</tr></font>");
				while (reader.Read())
				{
					if (wCO_CD == reader["CO_CD"].ToString())
					{
						//						wNC_Codes_Sno=wNC_Codes_Sno+1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='left' colspan='2'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["SUP_SUR_NO"]); Response.Write("</td>");
						cm_wise_tot = cm_wise_tot + Convert.ToInt32(reader["SUP_SUR_NO"]);
						Response.Write("</tr>");

					}
					else
					{
						if (wSno != 0)
						{
							Response.Write("<tr>");
							Response.Write("<td width='5%' valign='top' align='right' colspan='3'> <font size='1' face='Verdana'><b>"); Response.Write("Total"); Response.Write("</b></td>");
							Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(cm_wise_tot); Response.Write("</b></td>");
							Response.Write("</tr>");
							cm_wise_tot = 0;
						}
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'><b>"); Response.Write(reader["CO_NAME"]); Response.Write("</b></td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["SUP_SUR_NO"]); Response.Write("</td>");
						cm_wise_tot = Convert.ToInt32(reader["SUP_SUR_NO"]);
						Response.Write("</tr>");
						wCO_CD = reader["CO_CD"].ToString();



					}
					wSup_grand_total = wSup_grand_total + Convert.ToInt32(reader["SUP_SUR_NO"]);
					ctr = ctr + 1;
				};
				Response.Write("<tr>");
				Response.Write("<td width='5%' valign='top' align='right' colspan='3'> <font size='1' face='Verdana'><b>"); Response.Write("Total"); Response.Write("</b></td>");
				Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(cm_wise_tot); Response.Write("</b></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='5%' valign='top' align='right' colspan='3'> <font size='1' face='Verdana'><b>"); Response.Write("Grand Total"); Response.Write("</b></td>");
				Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wSup_grand_total); Response.Write("</b></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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


		void credit_note_invoices()
		{
			 conn= new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//conn = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
			//			if(Request.Params["DT"]!= null || Request.Params["DT"]!= "")
			//			{
			//				wToDt=Convert.ToString(Request.Params ["DT"].Trim());
			//				
			//			}
			string wHdr_YrMth;
			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;

			string wRegion = "";
			if (Session["Region"].ToString() == "N")
			{
				wRegion = "Northern Region";
			}
			else if (Session["Region"].ToString() == "S")
			{
				wRegion = "Southern Region";
			}
			else if (Session["Region"].ToString() == "E")
			{
				wRegion = "Eastern Region";
			}
			else if (Session["Region"].ToString() == "W")
			{
				wRegion = "Western Region";
			}
			else if (Session["Region"].ToString() == "C")
			{
				wRegion = "Central Region";
			}

			//			string sql="select to_char(T30.IC_SUBMIT_DT,'dd/mm/yyyy') IC_SUBMIT_DATE,T09.IE_NAME,T30.BK_NO,T30.SET_NO from T30_IC_RECEIVED T30, T09_IE T09 where T30.IE_CD=T09.IE_CD and (T30.IC_SUBMIT_DT between to_date('01/08/2010','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and REGION='"+Session["Region"]+"' and BILL_NO is null"+
			//				" order by T30.IC_SUBMIT_DT,T09.IE_CD,T30.BK_NO,T30.SET_NO"; 

			string sql = "SELECT A.CASE_NO, A.BILL_NO,TO_CHAR(A.BILL_DT,'DD/MM/YYYY') BILL_DATE, A.BILL_AMOUNT, A.BILL_AMT_CLEARED,A.CNOTE_AMOUNT, B.BILL_NO CR_BILL_NO,TO_CHAR(B.BILL_DT,'DD/MM/YYYY')CR_BILL_DATE ,B.BILL_AMOUNT CR_BILL_AMOUNT, B.BILL_AMT_CLEARED CR_BILL_AMT_CLEARED FROM T22_BILL A, T22_BILL B" +
				" WHERE A.BILL_NO=B.CNOTE_BILL_NO AND ABS(NVL(B.BILL_AMOUNT,0))>0 and SUBSTR(B.BILL_NO,1,1) IN ('O','X','T','F','D') AND SUBSTR(A.BILL_NO,1,1)='" + Session["Region"].ToString() + "' AND (B.BILL_DT between to_date('" + frmDt.Text + "','dd/mm/yyyy') and to_date('" + toDt.Text + "','dd/mm/yyyy'))";

			int wSno = 0;

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='80%'>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='11'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Credit Note For : " + wHdr_YrMth + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>CASE NO.</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>CREDIT NOTE BILL NO</font></th>");
				Response.Write("<th width='20%' valign='top'><font size='2' face='Verdana'>CREDIT NOTE BILL DT</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>CREDIT NOTE BILL AMT</font></th>");
				//				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>CREDIT NOTE BK_NO</font></th>");
				//				Response.Write("<th width='25%' valign='top'><font size='2' face='Verdana'>CREDIT NOTE SET_NO</font></th>");
				Response.Write("<th width='25%' valign='top'><font size='2' face='Verdana'>CREDIT NOTE AMT CLEARED</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>BILL NO</font></th>");
				Response.Write("<th width='20%' valign='top'><font size='2' face='Verdana'>BILL DT</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>BILL AMT</font></th>");
				//				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>BK_NO</font></th>");
				//				Response.Write("<th width='25%' valign='top'><font size='2' face='Verdana'>SET_NO</font></th>");
				Response.Write("<th width='25%' valign='top'><font size='2' face='Verdana'>AMT CLEARED</font></th>");
				Response.Write("<th width='25%' valign='top'><font size='2' face='Verdana'>CNOTE AMT</font></th>");
				Response.Write("</tr>");

				while (reader.Read())
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CR_BILL_NO"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["CR_BILL_DATE"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CR_BILL_AMOUNT"]); Response.Write("</td>");
					//					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>");Response.Write(reader["CR_BK_NO"]);Response.Write("</td>");
					//					Response.Write("<td width='25%' valign='top' align='left'> <font size='2' face='Verdana'>");Response.Write(reader["CR_SET_NO"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CR_BILL_AMT_CLEARED"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["BILL_DATE"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
					//					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>");Response.Write(reader["BK_NO"]);Response.Write("</td>");
					//					Response.Write("<td width='25%' valign='top' align='left'> <font size='2' face='Verdana'>");Response.Write(reader["SET_NO"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BILL_AMT_CLEARED"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CNOTE_AMOUNT"]); Response.Write("</td>");
					Response.Write("</tr>");

				};

				Response.Write("</table>");
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
		void unbilled_ic()
		{
			conn= new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//conn = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
			//			if(Request.Params["DT"]!= null || Request.Params["DT"]!= "")
			//			{
			//				wToDt=Convert.ToString(Request.Params ["DT"].Trim());
			//				
			//			}
			string wHdr_YrMth;
			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;

			string wRegion = "";
			if (Session["Region"].ToString() == "N")
			{
				wRegion = "Northern Region";
			}
			else if (Session["Region"].ToString() == "S")
			{
				wRegion = "Southern Region";
			}
			else if (Session["Region"].ToString() == "E")
			{
				wRegion = "Eastern Region";
			}
			else if (Session["Region"].ToString() == "W")
			{
				wRegion = "Western Region";
			}
			else if (Session["Region"].ToString() == "C")
			{
				wRegion = "Central Region";
			}

			//			string sql="select to_char(T30.IC_SUBMIT_DT,'dd/mm/yyyy') IC_SUBMIT_DATE,T09.IE_NAME,T30.BK_NO,T30.SET_NO from T30_IC_RECEIVED T30, T09_IE T09 where T30.IE_CD=T09.IE_CD and (T30.IC_SUBMIT_DT between to_date('01/08/2010','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and REGION='"+Session["Region"]+"' and BILL_NO is null"+
			//				" order by T30.IC_SUBMIT_DT,T09.IE_CD,T30.BK_NO,T30.SET_NO"; 

			//string sql ="select to_char(T30.IC_SUBMIT_DT,'dd/mm/yyyy') IC_SUBMIT_DATE,T09.IE_NAME,T30.BK_NO,T30.SET_NO,T30.REMARKS, to_char(T30.REMARKS_DT,'dd/mm/yyyy')REMARKS_DATE from T30_IC_RECEIVED T30 left join T16_IC_CANCEL T16 on (T30.BK_NO=T16.BK_NO and T30.SET_NO=T16.SET_NO and T30.REGION= T16.REGION) , T09_IE T09 where (T16.BK_NO IS NULL and T16.SET_NO IS NULL and T16.REGION IS NULL) and T30.IE_CD=T09.IE_CD and  (T30.IC_SUBMIT_DT between to_date('"+frmDt.Text+"','dd/mm/yyyy') and to_date('"+toDt.Text+"','dd/mm/yyyy')) and T30.REGION='"+Session["Region"]+"'  and BILL_NO is null" +
			//	" order by T30.IC_SUBMIT_DT,T09.IE_CD,T30.BK_NO,T30.SET_NO";
			string sql = "SELECT TO_CHAR(IC_SUBMIT_DATE,'DD/MM/YYYY') SUBMIT_DATE, IC_SUBMIT_DATE, IE_NAME, BK_NO, SET_NO, CLIENT_TYPE, REMARKS, REMARKS_DATE, IC_DATE FROM (" +
				" select T30.IC_SUBMIT_DT IC_SUBMIT_DATE,T09.IE_NAME,T30.BK_NO,T30.SET_NO,DECODE(T12.BPO_TYPE,'R','RAILWAY','NON RAILWAY') CLIENT_TYPE,T30.REMARKS, to_char(T30.REMARKS_DT,'dd/mm/yyyy')REMARKS_DATE, TO_CHAR(IC.DATETIME,'DD/MM/YYYY') IC_DATE from T30_IC_RECEIVED T30 left join T16_IC_CANCEL T16 on (T30.BK_NO=T16.BK_NO and T30.SET_NO=T16.SET_NO and T30.REGION= T16.REGION) , T09_IE T09, IC_INTERMEDIATE IC, T14_PO_BPO T14, T12_BILL_PAYING_OFFICER T12 where (T16.BK_NO IS NULL and T16.SET_NO IS NULL and T16.REGION IS NULL) and T30.IE_CD=T09.IE_CD AND IC.BK_NO=T30.BK_NO AND IC.SET_NO=T30.SET_NO AND IC.CASE_NO=T14.CASE_NO AND IC.CONSIGNEE_CD=T14.CONSIGNEE_CD AND T14.BPO_CD=T12.BPO_CD and (T30.IC_SUBMIT_DT between to_date('" + frmDt.Text + "','dd/mm/yyyy') and to_date('" + toDt.Text + "','dd/mm/yyyy')) and T30.REGION='" + Session["Region"] + "' AND SUBSTR(IC.CASE_NO,1,1)='" + Session["Region"] + "' and BILL_NO is null" +
				" UNION ALL select T30.IC_SUBMIT_DT IC_SUBMIT_DATE,T09.IE_NAME,T30.BK_NO,T30.SET_NO,DECODE(T13.RLY_NONRLY,'R','RAILWAY','NON RAILWAY') CLIENT_TYPE,T30.REMARKS, to_char(T30.REMARKS_DT,'dd/mm/yyyy')REMARKS_DATE, TO_CHAR(T17.CALL_STATUS_DT,'DD/MM/YYYY') IC_DATE from T30_IC_RECEIVED T30 left join T16_IC_CANCEL T16 on (T30.BK_NO=T16.BK_NO and T30.SET_NO=T16.SET_NO and T30.REGION= T16.REGION) , T09_IE T09, T17_CALL_REGISTER T17, T13_PO_MASTER T13 where (T16.BK_NO IS NULL and T16.SET_NO IS NULL and T16.REGION IS NULL) and T30.IE_CD=T09.IE_CD AND T17.BK_NO=T30.BK_NO AND T17.SET_NO=T30.SET_NO AND T17.CASE_NO=T13.CASE_NO and (T30.IC_SUBMIT_DT between to_date('" + frmDt.Text + "','dd/mm/yyyy') and to_date('" + toDt.Text + "','dd/mm/yyyy')) and T30.REGION='" + Session["Region"] + "' AND NOT REGEXP_LIKE(SUBSTR(T30.BK_NO,1,1), '[0-9]+') AND BILL_NO is null  " +
					") GROUP BY TO_CHAR(IC_SUBMIT_DATE,'DD/MM/YYYY'), IC_SUBMIT_DATE, IE_NAME,BK_NO, SET_NO, CLIENT_TYPE, REMARKS, REMARKS_DATE, IC_DATE" +
			" ORDER BY IC_SUBMIT_DATE,IE_NAME,BK_NO,SET_NO";
			int wSno = 0;

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='80%'>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='9'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>IC's Received but not Billed  For : " + wHdr_YrMth + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>IC Submit Date</font></th>");
				Response.Write("<th width='20%' valign='top'><font size='2' face='Verdana'>IE</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>BK NO.</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>SET No.</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>Client Type</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>IC Date</font></th>");
				Response.Write("<th width='25%' valign='top'><font size='2' face='Verdana'>Remarks</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>Remarks Date</font></th>");

				Response.Write("</tr>");

				while (reader.Read())
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SUBMIT_DATE"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CLIENT_TYPE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["IC_DATE"]); Response.Write("</td>");
					Response.Write("<td width='25%' valign='top' align='left'> <font size='2' face='Verdana'>"); Response.Write(reader["REMARKS"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["REMARKS_DATE"]); Response.Write("</td>");

					Response.Write("</tr>");

				};

				Response.Write("</table>");
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
		void RETURNED_BILLS_CHANGE_BPO()
		{

			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wItem_No = "";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT B.BILL_NO,TO_CHAR(B.BILL_DT,'DD/MM/YYYY') BILL_DATE,B.BILL_AMOUNT,OLD_BPO_CD,B1.SAP_CUST_CD_BPO OLD_SAP_CD, NEW_BPO_CD,B2.SAP_CUST_CD_BPO NEW_SAP_CD, R.USER_ID, TO_CHAR(R.DATETIME,'dd/mm/yyyy-HH24:MI:SS') UPD_DT, R.OLD_ACC_GROUP, R.NEW_ACC_GROUP, R.OLD_IRFC_BPO_CD, R.NEW_IRFC_BPO_CD, R.OLD_RECIPIENT_GSTIN_NO, R.NEW_RECIPIENT_GSTIN_NO FROM RETURNED_BILLS_BPO_CHANGE R, T12_BILL_PAYING_OFFICER B1, T12_BILL_PAYING_OFFICER B2,T22_BILL B WHERE R.BILL_NO=B.BILL_NO AND R.OLD_BPO_CD=B1.BPO_CD AND R.NEW_BPO_CD=B2.BPO_CD AND ((to_char(R.DATETIME,'yyyyMMdd')>='" + wDtFr + "' And to_char(R.DATETIME,'yyyyMMdd')<='" + wDtTo + "')) AND substr(R.BILL_NO,1,1)='" + Session["Region"] + "' ORDER BY R.DATETIME";


			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='16'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='16'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Returned Bills BPO Change Report For : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BILL_NO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BILL_DT</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BILL_AMOUNT</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>OLD BPO IBS CD</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>OLD BPO SAP CD</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>NEW BPO IBS CD</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>NEW BPO SAP CD</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>OLD ACC GROUP</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>NEW ACC GROUP</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>OLD IRFC BPO CD</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>NEW IRFC BPO CD</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>OLD RECIPIENT GSTIN NO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>NEW RECIPIENT GSTIN NO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>USER</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>DATETIME</font></b></th>");

				Response.Write("</tr></font>");

				while (reader.Read())
				{


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["OLD_BPO_CD"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["OLD_SAP_CD"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["NEW_BPO_CD"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["NEW_SAP_CD"]); Response.Write("</td>");

					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["OLD_ACC_GROUP"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["NEW_ACC_GROUP"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["OLD_IRFC_BPO_CD"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["NEW_IRFC_BPO_CD"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["OLD_RECIPIENT_GSTIN_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["NEW_RECIPIENT_GSTIN_NO"]); Response.Write("</td>");

					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["USER_ID"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["UPD_DT"]); Response.Write("</td>");
					Response.Write("</tr>");


				};

				Response.Write("</table>");
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

		void call_cancel_approval()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";



			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT T17.CASE_NO,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE, to_char(T17.CALL_RECV_DT,'yyyymmdd')CALL_DT_CONCAT, T17.CALL_SNO,T17.MFG_CD,T17.MFG_PLACE,NVL(T17.CO_CD,0) CO_CD,T05.VEND_NAME MFG,TO_CHAR(DT_INSP_DESIRE,'dd/mm/yyyy')DESIRE_DT,T19.USER_ID,TO_CHAR(T19.DATETIME,'DD/MM/YYYY') APPROVAL_DATE,'CALL_CANCELLATION_DOCUMENTS/'||T17.CASE_NO||'-'||to_char(T17.CALL_RECV_DT,'yyyymmdd')||'-'||T17.CALL_SNO||'.PDF' CANC_DOC FROM T17_CALL_REGISTER T17, T19_CALL_CANCEL T19, T05_VENDOR T05 WHERE T17.MFG_CD=T05.VEND_CD AND T17.CASE_NO=T19.CASE_NO AND T17.CALL_RECV_DT=T19.CALL_RECV_DT AND T17.CALL_SNO=T19.CALL_SNO and ((to_char(T19.DATETIME,'yyyyMMdd')>='" + wDtFr + "' And to_char(T19.DATETIME,'yyyyMMdd')<='" + wDtTo + "')) AND substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' AND T17.CALL_STATUS='C' AND T19.DOCS_SUBMITTED='Y'  order by T19.CANCEL_DATE";


			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='9'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='9'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Details of Calls Cancelled Approval by CM's For : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CASE_NO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CALL DT</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CALL SNO</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>MFG</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>DESIRE DT</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>USER_ID</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>APPROVAL DATE</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CANCELLATION DOC</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_RECV_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DESIRE_DT"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["USER_ID"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["APPROVAL_DATE"]); Response.Write("</td>");

					string fpath1 = Server.MapPath("/RBS/" + reader["CANC_DOC"]);

					if (File.Exists(fpath1) == false)
					{
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
					}
					else
					{
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write("<a href='/RBS/" + reader["CANC_DOC"].ToString() + "' Font-Names='Verdana' Font-Size='8pt'><H5 align='center'><font face='Verdana'>VIEW DOC</font></a></td>");
					}


					Response.Write("</tr>");


				};

				Response.Write("</table>");
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

		void icf_billing_details()
		{

			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wItem_No = "";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT  V22.BILL_NO, to_char(V22.BILL_DT,'DD/MM/YYYY') BILL_DATE, INVOICE_NO,BILL_AMOUNT, PO_NO, TO_CHAR(PO_DT,'DD/MM/YYYY') PO_DATE,BPO_NAME,IC_NO, TO_CHAR(IC_DT,'DD/MM/YYYY') IC_DATE, BK_NO||'/'||SET_NO BKSET,SUM(QTY) QTY_PASS FROM V22_BILL V22, V23_BILL_ITEMS V23 WHERE V22.BILL_NO=V23.BILL_NO AND BPO_TYPE='R' AND BPO_RLY='ICF' AND ((to_char(BILL_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(BILL_DT,'yyyyMMdd')<='" + wDtTo + "')) AND SUBSTR(CASE_NO,1,1)='" + Session["Region"] + "' GROUP BY V22.BILL_NO, to_char(V22.BILL_DT,'DD/MM/YYYY'), INVOICE_NO,BILL_AMOUNT, PO_NO, TO_CHAR(PO_DT,'DD/MM/YYYY'),BPO_NAME, IC_NO, TO_CHAR(IC_DT,'DD/MM/YYYY'), BK_NO||'/'||SET_NO ";


			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='11'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='12'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Details of ICF Bills For : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BILL_NO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>RITES_INV_NO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>RITES_INV_DT</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>RITES_INV_AMT</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>PO_NO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>PO_DT</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>BPO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>INSCERTNO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>INSCERTDT</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BOOK/SET</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>QTY</font></b></th>");

				Response.Write("</tr></font>");

				while (reader.Read())
				{


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["INVOICE_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DATE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IC_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IC_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BKSET"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");

					Response.Write("</tr>");


				};

				Response.Write("</table>");
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

		void summary_calls_attended_afterexpected_date()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT DECODE(REGION,'N','NORTHERN','S','SOUTHERN','W','WESTERN','E','EASTERN','C','CENTRAL') REGION, SUM(TOTAL_CALLS) TOTAL_CALLS, SUM(NO_OF_CALLS) NO_OF_CALLS FROM (select substr(CASE_NO,1,1) REGION, COUNT(*) TOTAL_CALLS, 0 NO_OF_CALLS from T17_CALL_REGISTER T17 WHERE (to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "') GROUP BY SUBSTR(CASE_NO,1,1) UNION ALL SELECT substr(CASE_NO,1,1) REGION, 0 TOTAL_CALLS, COUNT(*) NO_OF_CALLS FROM (SELECT DISTINCT T47.CASE_NO, T47.CALL_RECV_DT, T47.CALL_SNO FROM T17_CALL_REGISTER T17, T47_IE_WORK_PLAN T47, T09_IE T09 WHERE T17.CASE_NO=T47.CASE_NO AND T17.CALL_RECV_DT=T47.CALL_RECV_DT AND T17.CALL_SNO=T47.CALL_SNO AND T17.IE_CD=T09.IE_CD AND EXP_INSP_DT IS NOT NULL AND (EXP_INSP_DT < (SELECT MIN(VISIT_DT) FROM T47_IE_WORK_PLAN A WHERE A.CASE_NO=T17.CASE_NO AND A.CALL_RECV_DT=T17.CALL_RECV_DT AND A.CALL_SNO=T17.CALL_SNO)) AND (to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "')) group by substr(CASE_NO,1,1)) where REGION!='C' GROUP BY DECODE(REGION,'N','NORTHERN','S','SOUTHERN','W','WESTERN','E','EASTERN','C','CENTRAL')";

			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='14'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='8'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Summary of Cases where First Visit Date after Likely Inspection Date : " + wFrmDt + " TO " + wToDt + " (Region Wise)</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>REGION</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>TOTAL NO. OF CALLS</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CALLS ATTENDED AFTER LIKELY DT OF INSP</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>PERCENTAGE(%) </font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["REGION"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["TOTAL_CALLS"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["NO_OF_CALLS"]); Response.Write("</td>");
					//decimal w_per=Convert.ToDecimal(Convert.ToInt16(reader["NO_OF_CALLS"])/Convert.ToInt16(reader["TOTAL_CALLS"]) * 100);
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(Decimal.Round(Convert.ToDecimal((Convert.ToDecimal(reader["NO_OF_CALLS"]) / Convert.ToDecimal(reader["TOTAL_CALLS"])) * 100), 2)); Response.Write("</td>");

					Response.Write("</tr>");


				};

				Response.Write("</table>");
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

		void pl_linked()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wItem_No = "";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT T61.ITEM_CD, T61.ITEM_DESC,T62.PL_NO FROM T61_ITEM_MASTER T61, T62_MASTER_ITEM_PLNO T62 WHERE T61.ITEM_CD=T62.ITEM_CD AND  (to_char(T62.DATETIME,'yyyyMMdd')>='" + wDtFr + "' And to_char(T62.DATETIME,'yyyyMMdd')<='" + wDtTo + "') ORDER BY T61.ITEM_CD, T62.PL_NO";

			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='11'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='11'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Details of PL's Linked with Master Checksheets For : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>ITEM CD</font></b></th>");
				Response.Write("<th width='60%' valign='top'><b><font size='1' face='Verdana'>ITEM</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>PL_NO</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{

					if (wItem_No == reader["ITEM_CD"].ToString())
					{
						Response.Write("<tr>");
						Response.Write("<td valign='top' align='center' colspan='3'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PL_NO"]); Response.Write("</td>");
						Response.Write("</tr>");
					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_CD"]); Response.Write("</td>");
						Response.Write("<td width='60%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PL_NO"]); Response.Write("</td>");
						Response.Write("</tr>");
						wItem_No = reader["ITEM_CD"].ToString();
					}

				};

				Response.Write("</table>");
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
		void call_unlinked_mchksheet()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wCase_No = "";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT T13.CASE_NO,PO_NO, TO_CHAR(PO_DT,'DD/MM/YYYY') PO_DATE,DECODE(T13.PO_SOURCE,'C','CRIS','V','VENDOR','MANUAL') SOURCE, T18.CASE_NO, TO_CHAR(T18.CALL_RECV_DT,'DD/MM/YYYY') CALL_DT, T18.CALL_SNO, T18.ITEM_SRNO_PO, T18.ITEM_DESC_PO, T15.PL_NO FROM T13_PO_MASTER T13, T18_CALL_DETAILS T18, T15_PO_DETAIL T15 WHERE T13.CASE_NO=T15.CASE_NO AND T13.CASE_NO=T18.CASE_NO AND T18.CASE_NO=T15.CASE_NO AND T18.ITEM_SRNO_PO=T15.ITEM_SRNO AND T13.RLY_NONRLY='R' AND (to_char(T18.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T18.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "') AND T15.ITEM_CD IS NULL and substr(T18.CASE_NO,1,1)='" + Session["Region"] + "' order by T18.CALL_RECV_DT,T18.CALL_SNO,ITEM_SRNO_PO";

			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='11'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='11'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>DETAILS OF ITEMS IN RAILWAY CALLS WHERE MASTER CHECKSHEET ARE NOT LINKED FOR CALL DATE : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CASE No.</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PO DT</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PO SOURCE</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CASE No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CALL RECV DT</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CALL SNo.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>ITEM SNo.</font></b></th>");
				Response.Write("<th width='25%' valign='top'><b><font size='1' face='Verdana'>ITEM DESC</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>PL_NO</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{

					if (wCase_No == reader["CASE_NO"].ToString())
					{
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='center' colspan='8'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_SRNO_PO"]); Response.Write("</td>");
						Response.Write("<td width='25%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PL_NO"]); Response.Write("</td>");
						Response.Write("</tr>");
					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SOURCE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_DT"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_SRNO_PO"]); Response.Write("</td>");
						Response.Write("<td width='25%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PL_NO"]); Response.Write("</td>");
						Response.Write("</tr>");
						wCase_No = reader["CASE_NO"].ToString();
					}

				};

				Response.Write("</table>");
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

		void po_unlinked_mchksheet()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wCase_No = "";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT T13.CASE_NO,PO_NO, TO_CHAR(PO_DT,'DD/MM/YYYY') PO_DATE,DECODE(T13.PO_SOURCE,'C','CRIS','V','VENDOR','MANUAL') SOURCE,ITEM_SRNO,ITEM_DESC,PL_NO FROM T13_PO_MASTER T13, T15_PO_DETAIL T15 WHERE T13.CASE_NO=T15.CASE_NO AND T13.RLY_NONRLY='R' AND (PL_NO IS NOT NULL AND NVL(ITEM_CD,'X')='X') AND  (to_char(T15.DATETIME,'yyyyMMdd')>='" + wDtFr + "' And to_char(T15.DATETIME,'yyyyMMdd')<='" + wDtTo + "') AND SUBSTR(T13.CASE_NO,1,1)='" + Session["Region"] + "' ORDER BY T13.CASE_NO, ITEM_SRNO";


			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='8'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='8'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>DETAILS OF CASES WHERE ITEM IS NOT LINKED WITH MASTER CHECKSHEET FOR DATE : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CASE No.</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PO DT</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PO SOURCE</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>ITEM SNo.</font></b></th>");
				Response.Write("<th width='25%' valign='top'><b><font size='1' face='Verdana'>ITEM DESC</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>PL_NO</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{

					if (wCase_No == reader["CASE_NO"].ToString())
					{
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='center' colspan='5'> <font size='1' face='Verdana'>"); Response.Write(" "); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_SRNO"]); Response.Write("</td>");
						Response.Write("<td width='25%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PL_NO"]); Response.Write("</td>");
						Response.Write("</tr>");

					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SOURCE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_SRNO"]); Response.Write("</td>");
						Response.Write("<td width='25%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PL_NO"]); Response.Write("</td>");
						Response.Write("</tr>");
						wCase_No = reader["CASE_NO"].ToString();
					}

				};

				Response.Write("</table>");
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

		void po_linked_mchksheet()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wCase_No = "";

			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT T13.CASE_NO,PO_NO, TO_CHAR(PO_DT,'DD/MM/YYYY') PO_DATE,DECODE(T13.PO_SOURCE,'C','CRIS','V','VENDOR','MANUAL') SOURCE, ITEM_SRNO,T15.ITEM_DESC,T15.PL_NO, T61.ITEM_CD||'-'||T61.ITEM_DESC MASTER_ITEM FROM T13_PO_MASTER T13, T15_PO_DETAIL T15, T61_ITEM_MASTER T61 WHERE T13.CASE_NO=T15.CASE_NO AND T15.ITEM_CD=T61.ITEM_CD AND T13.RLY_NONRLY='R' AND (T15.PL_NO IS NOT NULL AND NVL(T15.ITEM_CD,'X')!='X') AND  (to_char(T15.DATETIME,'yyyyMMdd')>='" + wDtFr + "' And to_char(T15.DATETIME,'yyyyMMdd')<='" + wDtTo + "') AND SUBSTR(T13.CASE_NO,1,1)='" + Session["Region"] + "' ORDER BY T13.CASE_NO, ITEM_SRNO";


			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='9'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='9'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>DETAILS OF CASES WHERE ITEM IS LINKED WITH MASTER CHECKSHEET FOR DATE: " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CASE No.</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PO DT</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PO SOURCE</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>ITEM SNo.</font></b></th>");
				Response.Write("<th width='25%' valign='top'><b><font size='1' face='Verdana'>ITEM DESC</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>PL_NO</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>MASTER CHECKSHEET</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{
					if (wCase_No == reader["CASE_NO"].ToString())
					{
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='center' colspan='5'> <font size='1' face='Verdana'>"); Response.Write(" "); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_SRNO"]); Response.Write("</td>");
						Response.Write("<td width='25%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PL_NO"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["MASTER_ITEM"]); Response.Write("</td>");
						Response.Write("</tr>");
					}
					else
					{

						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SOURCE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_SRNO"]); Response.Write("</td>");
						Response.Write("<td width='25%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PL_NO"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["MASTER_ITEM"]); Response.Write("</td>");
						Response.Write("</tr>");
						wCase_No = reader["CASE_NO"].ToString();
					}

				};

				Response.Write("</table>");
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
		void calls_attended_afterexpected_date()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wCaseNo = "";
			string wCallDT = "";
			int wCallSno = 0;


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT T17.CASE_NO, TO_CHAR(T17.CALL_RECV_DT,'DD/MM/YYYY') CALL_DT,T17.CALL_SNO, T09.IE_NAME,TO_CHAR(DT_INSP_DESIRE,'DD/MM/YYYY')DESIRE_DT, TO_CHAR(EXP_INSP_DT,'DD/MM/YYYY') EXP_INSP_DATE, TO_CHAR(VISIT_DT,'DD/MM/YYYY') VISIT_DATE FROM T17_CALL_REGISTER T17, T47_IE_WORK_PLAN T47, T09_IE T09 WHERE T17.CASE_NO=T47.CASE_NO AND T17.CALL_RECV_DT=T47.CALL_RECV_DT AND T17.CALL_SNO=T47.CALL_SNO AND T17.IE_CD=T09.IE_CD AND EXP_INSP_DT IS NOT NULL AND (EXP_INSP_DT < (SELECT MIN(VISIT_DT) FROM T47_IE_WORK_PLAN A WHERE A.CASE_NO=T17.CASE_NO AND A.CALL_RECV_DT=T17.CALL_RECV_DT AND A.CALL_SNO=T17.CALL_SNO)) AND SUBSTR(T17.CASE_NO,1,1)='" + Session["Region"] + "' AND (to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "') ORDER BY T17.DT_INSP_DESIRE, T17.CASE_NO,T17.CALL_RECV_DT, T17.CALL_SNO, T47.VISIT_DT";

			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='14'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='8'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Case where First Visit Date after Likely Inspection Date : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Call Dt</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Call Sno</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Desire Dt</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Likely Insp Dt</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Visit Dt</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{

					if (wCaseNo == Convert.ToString(reader["CASE_NO"]) && wCallDT == Convert.ToString(reader["CALL_DT"]) && wCallSno == Convert.ToInt16(reader["CALL_SNO"]))
					{
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center' colspan='7'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VISIT_DATE"]); Response.Write("</td>");
						Response.Write("</tr>");

					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_DT"]); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DESIRE_DT"]); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["EXP_INSP_DATE"]); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VISIT_DATE"]); Response.Write("</td>");
						Response.Write("</tr>");
						wCaseNo = Convert.ToString(reader["CASE_NO"]);
						wCallDT = Convert.ToString(reader["CALL_DT"]);
						wCallSno = Convert.ToInt16(reader["CALL_SNO"]);
					}


				};

				Response.Write("</table>");
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
		void online_nr_payments()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT MER_TXN_REF, ORDER_INFO, TRANSACTION_NO, RRN_NO, AUTH_CD, CASE_NO, TO_CHAR(CALL_RECV_DT,'DD/MM/YYYY') CALL_DT, CALL_SNO,V.VENDOR, AMOUNT, DECODE(CHARGES_TYPE,'A','Customer Advance','C','Call Cancellation Charges','R','Rejection Charges','L','Lab Charges','V','Revalidation Of IC','D','Duplicate IC') TYPE, STATUS, TO_CHAR(DATETIME,'dd/mm/yyyy-HH24:MI:SS') DATETIME FROM ONLINE_PAYMENT O, V05_VENDOR V WHERE O.VEND_CD=V.VEND_CD and (to_char(O.DATETIME,'yyyyMMdd')>='" + wDtFr + "' And to_char(O.DATETIME,'yyyyMMdd')<='" + wDtTo + "') AND SUBSTR(CASE_NO,1,1)='" + Session["Region"] + "' ORDER BY O.DATETIME DESC, MER_TXN_REF ";
			//string sql="SELECT SUPER_SURPRISE_NO, TO_CHAR(SUPER_SURPRISE_DT,'DD/MM/YYYY') SUP_SUR_DATE, T08.CO_NAME, T09.IE_NAME, V05.VENDOR, T44.ITEM_DESC, T44.PRE_INT_REJ, T44.DISCREPANCY, T44.OUTCOME  FROM T44_SUPER_SURPRISE T44, T13_PO_MASTER T13, V05_VENDOR V05, T08_IE_CONTROLL_OFFICER T08, T09_IE T09 WHERE T44.CASE_NO=T13.CASE_NO AND T13.VEND_CD=V05.VEND_CD AND T44.CO_CD=T08.CO_CD AND T44.IE_CD=T09.IE_CD AND (to_char(T44.SUPER_SURPRISE_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T44.SUPER_SURPRISE_DT,'yyyyMMdd')<='"+wDtTo+"') and substr(T44.SUPER_SURPRISE_NO,1,1)='"+Session["Region"]+"' ORDER BY T44.SUPER_SURPRISE_DT, T44.SUPER_SURPRISE_NO";
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='14'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='14'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Online Payment Gateway Details : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Merchant TXN Ref</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Order Info</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Transaction No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>RRN NO.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Auth CD</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Call Dt</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Call Sno</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Vendor</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Amount</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Charges Type</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Status</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>DateTime</font></b></th>");


				Response.Write("</tr></font>");

				while (reader.Read())
				{


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["MER_TXN_REF"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ORDER_INFO"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["TRANSACTION_NO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["RRN_NO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["AUTH_CD"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_DT"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["AMOUNT"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["TYPE"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["STATUS"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DATETIME"]); Response.Write("</td>");
					Response.Write("</tr>");


				};

				Response.Write("</table>");
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
		void super_surprise()
		{

			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT SUPER_SURPRISE_NO, TO_CHAR(SUPER_SURPRISE_DT,'DD/MM/YYYY') SUP_SUR_DATE, T08.CO_NAME, T09.IE_NAME, V05.VENDOR, T44.ITEM_DESC,decode(NAME_SCOPE_ITEM,'A','(IAF 12) Chemical/Paints ','B','(IAF 14b) Plastics Pipes & Fittings ','C','(IAF 16) Cement Pipes, AC Pressue Pipes & PCC Poles','D','(IAF 17b)  Rails, CI/DI Pipes, Steel Tubes and Fittings, Seamless Blocl/Galvanised, Valves','E','S(IAF 19a) Conductor, Cables, Power Transformers, CT/PT Fans, Relay, Panel, DG set, Alternator, Energy Meter','F','(IAF 22) Railway Rolling Stock','G','(IAF 28) Water Supply','H','(IAF 28) Construction','I','(IAF 07) Paper for Printing','J','(IAF 09) Printed Tickes & Ruled Papers','Others') SCOPE, T44.PRE_INT_REJ, T44.DISCREPANCY, T44.OUTCOME, T44.SBU_HEAD_REMARKS  FROM T44_SUPER_SURPRISE T44, T13_PO_MASTER T13, V05_VENDOR V05, T08_IE_CONTROLL_OFFICER T08, T09_IE T09 WHERE T44.CASE_NO=T13.CASE_NO AND T13.VEND_CD=V05.VEND_CD AND T44.CO_CD=T08.CO_CD AND T44.IE_CD=T09.IE_CD ";

			if (rdbPCM.Checked == true)
			{
				sql = sql + " and T44.CO_CD=" + lstCO.SelectedValue;
			}

			if (rdbPSector.Checked == true)
			{
				sql = sql + " and T44.NAME_SCOPE_ITEM='" + ddlItemScope.SelectedValue + "'";
			}

			sql = sql + " AND (to_char(T44.SUPER_SURPRISE_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T44.SUPER_SURPRISE_DT,'yyyyMMdd')<='" + wDtTo + "') and substr(T44.SUPER_SURPRISE_NO,1,1)='" + Session["Region"] + "' ORDER BY T08.CO_NAME, T44.SUPER_SURPRISE_DT, T44.SUPER_SURPRISE_NO";
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='11'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='12'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Super Surprise Details : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Note: For details of Super/Surprise inspection please refer Super/Surprise report format - F/8.2/2/4</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Super Surprise No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Super Surprise Dt</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CM</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Vendor</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Item</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Scope of Sector Where Item is Covered</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Previous Internal/Consignee Rejections</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Discrepancy if any</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Overall outcome of the visit</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>SBU HEAD REMARKS/RECOMMENDATION</font></b></th>");
				//Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Report Format</font></b></th>");

				Response.Write("</tr></font>");

				while (reader.Read())
				{


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SUPER_SURPRISE_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SUP_SUR_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SCOPE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PRE_INT_REJ"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DISCREPANCY"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["OUTCOME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SBU_HEAD_REMARKS"]); Response.Write("</td>");
					//string fpath=Server.MapPath("/RBS/SUPER_SURPRISE/"+reader["SUPER_SURPRISE_NO"].ToString()+".PDF");
					//if (File.Exists(fpath)==true) 
					//{
					//Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/SUPER_SURPRISE/"+reader["SUPER_SURPRISE_NO"].ToString()+".PDF'>FILE</a></td>");
					//}

					Response.Write("</tr>");


				};

				Response.Write("</table>");
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


		void fire_retardant_vendors_calls()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wCase_No = ""; string wCall_Date = "";
			string wBK_NO = "";
			string wSET_NO = "";
			int wCall_Sno = 0;
			string sql = "select T13.CASE_NO,T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DATE, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_DATE,T17.CALL_SNO,T17.CALL_LETTER_NO,VCALL.VENDOR MANU,VPO.VENDOR VENDOR,T09.IE_NAME,T18.ITEM_DESC_PO, NVL(T18.QTY_TO_INSP,0) QTY_OFF,T18.QTY_PASSED QTY_PASS,T18.QTY_REJECTED QTY_REJECTED,T20.BK_NO,T20.SET_NO,T20.BILL_NO,to_char(T20.FIRST_INSP_DT,'dd/mm/yyyy') FIRST_INSP_DT,to_char(T20.LAST_INSP_DT,'dd/mm/yyyy') LAST_INSP_DT,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy') DT_INSP_DESIRE, T21.CALL_STATUS_DESC  " +
				"from T13_PO_MASTER T13, T17_CALL_REGISTER T17, T18_CALL_DETAILS T18, T20_IC T20, T09_IE T09, V05_VENDOR VPO, V05_VENDOR VCALL, T21_CALL_STATUS_CODES T21 " +
				"where T13.CASE_NO=T17.CASE_NO and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO and T17.CASE_NO=T20.CASE_NO(+) and T17.CALL_RECV_DT=T20.CALL_RECV_DT(+) and T17.CALL_SNO=T20.CALL_SNO(+) and T17.IE_CD=T09.IE_CD and T17.MFG_CD=VCALL.VEND_CD and T13.VEND_CD=VPO.VEND_CD AND T17.CALL_STATUS=T21.CALL_STATUS_CD";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			if (CheckBox1.Checked == false)
			{
				sql = sql + " and (T13.VEND_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR T17.MFG_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "' and T17.REGION_CODE='" + Session["Region"] + "'";

			}
			else if (CheckBox1.Checked == true)
			{
				sql = sql + " and (T13.VEND_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR T17.MFG_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "' ";
			}
			//			sql=sql+" and (T13.VEND_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR T17.MFG_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"' and T17.REGION_CODE='"+Session["Region"]+"'";
			//			sql=sql+" and (T13.VEND_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR T17.MFG_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"'";
			if (lstCallStatus.SelectedValue != "All")
			{
				sql = sql + " and T17.CALL_STATUS='" + lstCallStatus.SelectedValue + "'";
			}
			sql = sql + " order By VPO.VENDOR,T17.CALL_RECV_DT";
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region, RITES Ltd."; }

			int ctr = 60;
			int wSno = 0;



			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='20'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='center'><font face='Verdana'>Calls marked during " + wHdr_YrMth + " (Report Sorted on Call Date)</font><br></p>");
				//Response.Write("<H5 align='center'><font face='Verdana'>Client : "+lstBPO_Rly.SelectedValue+"</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>SNo.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>PO Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Date</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Sno.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Letter/Ref No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Status</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Vendor/Manufacturer</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>BK No.</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>SET No.</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>BILL No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Inspection Desire Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>First Insp Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Last Insp Date</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Item Desc</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Off</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Pass</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Rej</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{
					if (wCase_No == reader["CASE_NO"].ToString() && wCall_Date == reader["CALL_DATE"].ToString() && wCall_Sno == Convert.ToInt16(reader["CALL_SNO"]))
					{
						if (wBK_NO == reader["BK_NO"].ToString() && wSET_NO == reader["SET_NO"].ToString())
						{
							Response.Write("<tr>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=16> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
							Response.Write("</tr>");
						}
						else
						{
							Response.Write("<tr>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=10> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
							Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DT_INSP_DESIRE"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["LAST_INSP_DT"]); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
							Response.Write("</tr>");
							wBK_NO = reader["BK_NO"].ToString();
							wSET_NO = reader["SET_NO"].ToString();
						}
					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(wSno); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_DATE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_LETTER_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_STATUS_DESC"]); Response.Write("</td>");
						if (reader["VENDOR"].ToString() == reader["MANU"].ToString())
						{
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
						}
						else
						{
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"] + " at " + reader["MANU"]); Response.Write("</td>");
						}

						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DT_INSP_DESIRE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["LAST_INSP_DT"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
						Response.Write("</tr>");
						ctr = ctr + 1;
						wCase_No = Convert.ToString(reader["CASE_NO"]);
						wCall_Date = Convert.ToString(reader["CALL_DATE"]);
						wCall_Sno = Convert.ToInt16(reader["CALL_SNO"]);
					}
				};
				Response.Write("</table>");
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

		void textile_items_calls()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wCase_No = ""; string wCall_Date = "";
			string wBK_NO = "";
			string wSET_NO = "";
			int wCall_Sno = 0;
			string sql = "select T13.CASE_NO,T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DATE, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_DATE,T17.CALL_SNO,T17.CALL_LETTER_NO,VCALL.VENDOR MANU,VPO.VENDOR VENDOR,T09.IE_NAME,T18.ITEM_DESC_PO, NVL(T18.QTY_TO_INSP,0) QTY_OFF,T18.QTY_PASSED QTY_PASS,T18.QTY_REJECTED QTY_REJECTED,T20.BK_NO,T20.SET_NO,T20.BILL_NO,to_char(T20.FIRST_INSP_DT,'dd/mm/yyyy') FIRST_INSP_DT,to_char(T20.LAST_INSP_DT,'dd/mm/yyyy') LAST_INSP_DT,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy') DT_INSP_DESIRE, T21.CALL_STATUS_DESC  " +
				"from T13_PO_MASTER T13, T17_CALL_REGISTER T17, T18_CALL_DETAILS T18, T20_IC T20, T09_IE T09, V05_VENDOR VPO, V05_VENDOR VCALL, T21_CALL_STATUS_CODES T21 " +
				"where T13.CASE_NO=T17.CASE_NO and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO and T17.CASE_NO=T20.CASE_NO(+) and T17.CALL_RECV_DT=T20.CALL_RECV_DT(+) and T17.CALL_SNO=T20.CALL_SNO(+) and T17.IE_CD=T09.IE_CD and T17.MFG_CD=VCALL.VEND_CD and T13.VEND_CD=VPO.VEND_CD AND T17.CALL_STATUS=T21.CALL_STATUS_CD";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			if (CheckBox1.Checked == false)
			{
				sql = sql + " and (instr(upper(T18.ITEM_DESC_PO),upper('BED SHEET'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('PILLOW COVER'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('TOWEL TURKISH'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('SERGE'))>0 or instr(upper(T18.ITEM_DESC_PO),upper('WOOLEN BLANKET'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('WOOLLEN BLANKET'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('ANGOLA SHIRTING'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('POLYESTER BLEND SHIRTING'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('GREAT COAT CLOTH'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('MOSQUITO NET'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('PC BLENDED SARIS'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('COTTON DRILLS'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('LONG CLOTH KHADI'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('COTTON CELLULAR SHIRTING'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('SHIRTING FOR UNIFORM'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('WOVEN SUITING'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('WOVEN SHIRTING'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('JERSEY WOOLEN'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('JERSEY WOOLLEN'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('JERSEY'))>0) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "' and T17.REGION_CODE='" + Session["Region"] + "'";

			}
			else if (CheckBox1.Checked == true)
			{
				sql = sql + " and (instr(upper(T18.ITEM_DESC_PO),upper('BED SHEET'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('PILLOW COVER'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('TOWEL TURKISH'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('SERGE'))>0 or instr(upper(T18.ITEM_DESC_PO),upper('WOOLEN BLANKET'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('WOOLLEN BLANKET'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('ANGOLA SHIRTING'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('POLYESTER BLEND SHIRTING'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('GREAT COAT CLOTH'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('MOSQUITO NET'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('PC BLENDED SARIS'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('COTTON DRILLS'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('LONG CLOTH KHADI'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('COTTON CELLULAR SHIRTING'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('SHIRTING FOR UNIFORM'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('WOVEN SUITING'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('WOVEN SHIRTING'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('JERSEY WOOLEN'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('JERSEY WOOLLEN'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('JERSEY'))>0) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "' ";
			}
			//			sql=sql+" and (T13.VEND_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR T17.MFG_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"' and T17.REGION_CODE='"+Session["Region"]+"'";
			//			sql=sql+" and (T13.VEND_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR T17.MFG_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"'";
			if (lstCallStatus.SelectedValue != "All")
			{
				sql = sql + " and T17.CALL_STATUS='" + lstCallStatus.SelectedValue + "'";
			}
			sql = sql + " order By VPO.VENDOR,T17.CALL_RECV_DT";
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region, RITES Ltd."; }

			int ctr = 60;
			int wSno = 0;



			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='20'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='center'><font face='Verdana'>Calls marked during " + wHdr_YrMth + " (Report Sorted on Call Date)</font><br></p>");
				//Response.Write("<H5 align='center'><font face='Verdana'>Client : "+lstBPO_Rly.SelectedValue+"</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>SNo.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>PO Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Date</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Sno.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Letter/Ref No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Status</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Vendor/Manufacturer</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>BK No.</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>SET No.</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>BILL No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Inspection Desire Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>First Insp Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Last Insp Date</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Item Desc</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Off</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Pass</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Rej</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{
					if (wCase_No == reader["CASE_NO"].ToString() && wCall_Date == reader["CALL_DATE"].ToString() && wCall_Sno == Convert.ToInt16(reader["CALL_SNO"]))
					{
						if (wBK_NO == reader["BK_NO"].ToString() && wSET_NO == reader["SET_NO"].ToString())
						{
							Response.Write("<tr>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=16> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
							Response.Write("</tr>");
						}
						else
						{
							Response.Write("<tr>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=10> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
							Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DT_INSP_DESIRE"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["LAST_INSP_DT"]); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
							Response.Write("</tr>");
							wBK_NO = reader["BK_NO"].ToString();
							wSET_NO = reader["SET_NO"].ToString();
						}
					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(wSno); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_DATE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_LETTER_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_STATUS_DESC"]); Response.Write("</td>");
						if (reader["VENDOR"].ToString() == reader["MANU"].ToString())
						{
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
						}
						else
						{
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"] + " at " + reader["MANU"]); Response.Write("</td>");
						}

						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DT_INSP_DESIRE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["LAST_INSP_DT"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
						Response.Write("</tr>");
						ctr = ctr + 1;
						wCase_No = Convert.ToString(reader["CASE_NO"]);
						wCall_Date = Convert.ToString(reader["CALL_DATE"]);
						wCall_Sno = Convert.ToInt16(reader["CALL_SNO"]);
					}
				};
				Response.Write("</table>");
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

		void OHE_items_calls()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wCase_No = ""; string wCall_Date = "";
			string wBK_NO = "";
			string wSET_NO = "";
			int wCall_Sno = 0;
			string sql = "select T13.CASE_NO,T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DATE, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_DATE,T17.CALL_SNO,T17.CALL_LETTER_NO,VCALL.VENDOR MANU,VPO.VENDOR VENDOR,T09.IE_NAME,T18.ITEM_DESC_PO, NVL(T18.QTY_TO_INSP,0) QTY_OFF,T18.QTY_PASSED QTY_PASS,T18.QTY_REJECTED QTY_REJECTED,T20.BK_NO,T20.SET_NO,T20.BILL_NO,to_char(T20.FIRST_INSP_DT,'dd/mm/yyyy') FIRST_INSP_DT,to_char(T20.LAST_INSP_DT,'dd/mm/yyyy') LAST_INSP_DT,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy') DT_INSP_DESIRE, T21.CALL_STATUS_DESC  " +
				"from T13_PO_MASTER T13, T17_CALL_REGISTER T17, T18_CALL_DETAILS T18, T20_IC T20, T09_IE T09, V05_VENDOR VPO, V05_VENDOR VCALL, T21_CALL_STATUS_CODES T21 " +
				"where T13.CASE_NO=T17.CASE_NO and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO and T17.CASE_NO=T20.CASE_NO(+) and T17.CALL_RECV_DT=T20.CALL_RECV_DT(+) and T17.CALL_SNO=T20.CALL_SNO(+) and T17.IE_CD=T09.IE_CD and T17.MFG_CD=VCALL.VEND_CD and T13.VEND_CD=VPO.VEND_CD AND T17.CALL_STATUS=T21.CALL_STATUS_CD";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			if (CheckBox1.Checked == false)
			{
				sql = sql + " and (instr(upper(T18.ITEM_DESC_PO),upper('STEEL STRUCTURE'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('COPPER WIRE'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('CONTACT WIRE'))>0) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "' and T17.REGION_CODE='" + Session["Region"] + "'";

			}
			else if (CheckBox1.Checked == true)
			{
				sql = sql + " and (instr(upper(T18.ITEM_DESC_PO),upper('STEEL STRUCTURE'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('COPPER WIRE'))>0 OR instr(upper(T18.ITEM_DESC_PO),upper('CONTACT WIRE'))>0) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "' ";
			}
			//			sql=sql+" and (T13.VEND_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR T17.MFG_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"' and T17.REGION_CODE='"+Session["Region"]+"'";
			//			sql=sql+" and (T13.VEND_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR T17.MFG_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"'";
			if (lstCallStatus.SelectedValue != "All")
			{
				sql = sql + " and T17.CALL_STATUS='" + lstCallStatus.SelectedValue + "'";
			}
			sql = sql + " order By VPO.VENDOR,T17.CALL_RECV_DT";
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region, RITES Ltd."; }

			int ctr = 60;
			int wSno = 0;



			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='20'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='center'><font face='Verdana'>Calls marked during " + wHdr_YrMth + " (Report Sorted on Call Date)</font><br></p>");
				//Response.Write("<H5 align='center'><font face='Verdana'>Client : "+lstBPO_Rly.SelectedValue+"</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>SNo.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>PO Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Date</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Sno.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Letter/Ref No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Status</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Vendor/Manufacturer</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>BK No.</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>SET No.</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>BILL No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Inspection Desire Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>First Insp Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Last Insp Date</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Item Desc</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Off</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Pass</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Rej</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{
					if (wCase_No == reader["CASE_NO"].ToString() && wCall_Date == reader["CALL_DATE"].ToString() && wCall_Sno == Convert.ToInt16(reader["CALL_SNO"]))
					{
						if (wBK_NO == reader["BK_NO"].ToString() && wSET_NO == reader["SET_NO"].ToString())
						{
							Response.Write("<tr>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=16> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
							Response.Write("</tr>");
						}
						else
						{
							Response.Write("<tr>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=10> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
							Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DT_INSP_DESIRE"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["LAST_INSP_DT"]); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
							Response.Write("</tr>");
							wBK_NO = reader["BK_NO"].ToString();
							wSET_NO = reader["SET_NO"].ToString();
						}
					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(wSno); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_DATE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_LETTER_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_STATUS_DESC"]); Response.Write("</td>");
						if (reader["VENDOR"].ToString() == reader["MANU"].ToString())
						{
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
						}
						else
						{
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"] + " at " + reader["MANU"]); Response.Write("</td>");
						}

						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DT_INSP_DESIRE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["LAST_INSP_DT"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
						Response.Write("</tr>");
						ctr = ctr + 1;
						wCase_No = Convert.ToString(reader["CASE_NO"]);
						wCall_Date = Convert.ToString(reader["CALL_DATE"]);
						wCall_Sno = Convert.ToInt16(reader["CALL_SNO"]);
					}
				};
				Response.Write("</table>");
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
		void PHED_calls()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wCase_No = ""; string wCall_Date = "";
			string wBK_NO = "";
			string wSET_NO = "";
			int wCall_Sno = 0;
			string sql = "select T13.CASE_NO,T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DATE, T13.RLY_CD, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_DATE,T17.CALL_SNO,T17.CALL_LETTER_NO,VCALL.VENDOR MANU,VPO.VENDOR VENDOR,T09.IE_NAME,T18.ITEM_DESC_PO, NVL(T18.QTY_TO_INSP,0) QTY_OFF,T18.QTY_PASSED QTY_PASS,T18.QTY_REJECTED QTY_REJECTED,T20.BK_NO,T20.SET_NO,T20.BILL_NO,to_char(T20.FIRST_INSP_DT,'dd/mm/yyyy') FIRST_INSP_DT,to_char(T20.LAST_INSP_DT,'dd/mm/yyyy') LAST_INSP_DT,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy') DT_INSP_DESIRE, T21.CALL_STATUS_DESC, V12.BPO_CD||'-'||V12.BPO BPO, V06.CONSIGNEE_CD||'-'||trim(V06.CONSIGNEE_DESIG)||'/'||trim(V06.CONSIGNEE_DEPT)||'/'||trim(V06.CONSIGNEE_FIRM)||'/'||T03.CITY CONSIGNEE " +
				"from T13_PO_MASTER T13, T17_CALL_REGISTER T17, T18_CALL_DETAILS T18, T20_IC T20, T09_IE T09, V05_VENDOR VPO, V05_VENDOR VCALL, T21_CALL_STATUS_CODES T21, T14_PO_BPO T14, V12_BILL_PAYING_OFFICER V12, T06_CONSIGNEE V06, T03_CITY T03 " +
				"where T13.CASE_NO=T17.CASE_NO and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO and T17.CASE_NO=T20.CASE_NO(+) and T17.CALL_RECV_DT=T20.CALL_RECV_DT(+) and T17.CALL_SNO=T20.CALL_SNO(+) and T17.IE_CD=T09.IE_CD and T17.MFG_CD=VCALL.VEND_CD and T13.VEND_CD=VPO.VEND_CD AND T17.CALL_STATUS=T21.CALL_STATUS_CD AND T18.CONSIGNEE_CD=T14.CONSIGNEE_CD AND T13.CASE_NO=T14.CASE_NO AND T14.BPO_CD=V12.BPO_CD AND T14.CONSIGNEE_CD=V06.CONSIGNEE_CD AND V06.CONSIGNEE_CITY=T03.CITY_CD  and T13.RLY_NONRLY<>'R' AND V06.CONSIGNEE_TYPE<>'P' AND (T13.VEND_CD IN (36339, 38139, 29913, 10348, 64890, 33043, 24755, 80942, 36349, 65578, 40400)) ";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			if (CheckBox1.Checked == false)
			{
				sql = sql + " And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "' and T17.REGION_CODE='" + Session["Region"] + "'";

			}
			else if (CheckBox1.Checked == true)
			{
				sql = sql + " And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "' ";
			}
			//			sql=sql+" and (T13.VEND_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR T17.MFG_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"' and T17.REGION_CODE='"+Session["Region"]+"'";
			//			sql=sql+" and (T13.VEND_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR T17.MFG_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"'";
			if (lstCallStatus.SelectedValue != "All")
			{
				sql = sql + " and T17.CALL_STATUS='" + lstCallStatus.SelectedValue + "'";
			}

			if (CheckBox1.Checked == true)
			{
				sql = sql + " order By T17.REGION_CODE,VPO.VENDOR,T17.CALL_RECV_DT";
			}
			else
			{
				sql = sql + " order By VPO.VENDOR,T17.CALL_RECV_DT";
			}
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region, RITES Ltd."; }

			int ctr = 60;
			int wSno = 0;



			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='23'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='center'><font face='Verdana'>Jal Shakti Kashmir Calls Status during " + wHdr_YrMth + " (Report Sorted on Call Date)</font><br></p>");
				//Response.Write("<H5 align='center'><font face='Verdana'>Client : "+lstBPO_Rly.SelectedValue+"</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>SNo.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>PO Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>BPO</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Date</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Sno.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Letter/Ref No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Status</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Client</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Vendor/Manufacturer</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Consignee</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>BK No.</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>SET No.</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>BILL No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Inspection Desire Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>First Insp Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Last Insp Date</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Item Desc</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Off</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Pass</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Rej</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{
					if (wCase_No == reader["CASE_NO"].ToString() && wCall_Date == reader["CALL_DATE"].ToString() && wCall_Sno == Convert.ToInt16(reader["CALL_SNO"]))
					{
						if (wBK_NO == reader["BK_NO"].ToString() && wSET_NO == reader["SET_NO"].ToString())
						{
							Response.Write("<tr>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=12> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=6> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
							Response.Write("</tr>");
						}
						else
						{
							Response.Write("<tr>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=12> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
							Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DT_INSP_DESIRE"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["LAST_INSP_DT"]); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
							Response.Write("</tr>");
							wBK_NO = reader["BK_NO"].ToString();
							wSET_NO = reader["SET_NO"].ToString();
						}
					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(wSno); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_DATE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_LETTER_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_STATUS_DESC"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["RLY_CD"]); Response.Write("</td>");
						if (reader["VENDOR"].ToString() == reader["MANU"].ToString())
						{
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
						}
						else
						{
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"] + " at " + reader["MANU"]); Response.Write("</td>");
						}

						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DT_INSP_DESIRE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["LAST_INSP_DT"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
						Response.Write("</tr>");
						ctr = ctr + 1;
						wCase_No = Convert.ToString(reader["CASE_NO"]);
						wCall_Date = Convert.ToString(reader["CALL_DATE"]);
						wCall_Sno = Convert.ToInt16(reader["CALL_SNO"]);
					}
				};
				Response.Write("</table>");
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
		void MOZ_POS()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string sql = "select T13.CASE_NO,T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DATE,T13.REMARKS, VPO.VENDOR VENDOR,DECODE(T13.PO_OR_LETTER,'L','LOA','PO') PO_OR_LETTER " +
				"from T13_PO_MASTER T13, V05_VENDOR VPO " +
				"where T13.VEND_CD=VPO.VEND_CD and (instr(upper(T13.PO_NO),upper('MOZ'))>0 OR instr(upper(T13.REMARKS),upper('MOZ'))>0) ";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			if (CheckBox1.Checked == false)
				//			{
				//				sql=sql+" And to_char(T13.RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T13.RECV_DT,'yyyyMMdd')<='"+wDtTo+"' and T17.REGION_CODE='"+Session["Region"]+"'";
				//
				//			}
				//			else if(CheckBox1.Checked==true)
				//			{
				sql = sql + " And to_char(T13.RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T13.RECV_DT,'yyyyMMdd')<='" + wDtTo + "' ";
			//			}
			//			sql=sql+" and (T13.VEND_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR T17.MFG_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"' and T17.REGION_CODE='"+Session["Region"]+"'";
			//			sql=sql+" and (T13.VEND_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR T17.MFG_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"'";

			sql = sql + " order By VPO.VENDOR,T13.CASE_NO";
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region, RITES Ltd."; }

			int ctr = 60;
			int wSno = 0;



			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='20'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='center'><font face='Verdana'>Cape Gauge Coaches MOZ Bought Out Items Purchase Orders Status Registered During " + wHdr_YrMth + " (Report Sorted on Call Date)</font><br></p>");
				//Response.Write("<H5 align='center'><font face='Verdana'>Client : "+lstBPO_Rly.SelectedValue+"</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>SNo.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>PO Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>PO OR LETTER</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>REMARKS</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Vendor</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{

					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(wSno); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_OR_LETTER"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["REMARKS"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
					Response.Write("</tr>");
					ctr = ctr + 1;


				};
				Response.Write("</table>");
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
		void MOZ_calls()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			string wCase_No = ""; string wCall_Date = "";
			string wBK_NO = "";
			string wSET_NO = "";
			int wCall_Sno = 0;
			string sql = "select T13.CASE_NO,T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DATE, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_DATE,T17.CALL_SNO,T17.CALL_LETTER_NO,VCALL.VENDOR MANU,VPO.VENDOR VENDOR,T09.IE_NAME,T18.ITEM_DESC_PO, NVL(T18.QTY_TO_INSP,0) QTY_OFF,T18.QTY_PASSED QTY_PASS,T18.QTY_REJECTED QTY_REJECTED,T20.BK_NO,T20.SET_NO,T20.BILL_NO,to_char(T20.FIRST_INSP_DT,'dd/mm/yyyy') FIRST_INSP_DT,to_char(T20.LAST_INSP_DT,'dd/mm/yyyy') LAST_INSP_DT,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy') DT_INSP_DESIRE, T21.CALL_STATUS_DESC, V12.BPO_CD||'-'||V12.BPO BPO " +
				"from T13_PO_MASTER T13, T17_CALL_REGISTER T17, T18_CALL_DETAILS T18, T20_IC T20, T09_IE T09, V05_VENDOR VPO, V05_VENDOR VCALL, T21_CALL_STATUS_CODES T21, T14_PO_BPO T14, V12_BILL_PAYING_OFFICER V12 " +
				"where T13.CASE_NO=T17.CASE_NO and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO and T17.CASE_NO=T20.CASE_NO(+) and T17.CALL_RECV_DT=T20.CALL_RECV_DT(+) and T17.CALL_SNO=T20.CALL_SNO(+) and T17.IE_CD=T09.IE_CD and T17.MFG_CD=VCALL.VEND_CD and T13.VEND_CD=VPO.VEND_CD AND T17.CALL_STATUS=T21.CALL_STATUS_CD AND T18.CONSIGNEE_CD=T14.CONSIGNEE_CD AND T13.CASE_NO=T14.CASE_NO AND T14.BPO_CD=V12.BPO_CD and (instr(upper(T13.PO_NO),upper('MOZ'))>0 OR instr(upper(T13.REMARKS),upper('MOZ'))>0) ";


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			if (CheckBox1.Checked == false)
			{
				sql = sql + " And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "' and T17.REGION_CODE='" + Session["Region"] + "'";

			}
			else if (CheckBox1.Checked == true)
			{
				sql = sql + " And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "' ";
			}
			//			sql=sql+" and (T13.VEND_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR T17.MFG_CD IN (25394,25756,17415,25801,28779,25400,41695,41693,28742,28741,16777,16778,16522,16521,16523,25525,18153,17203,17202,32972,25901,26023,38998,6799,6800,6798,25668,6801,25367,28616,16522,16521,16523,25525,18153,17415,25801,28779,25400,40965,38668,44328,22193,15147,32477,43060,15148,46602,22552,31292,22553,16987,16988,30941, 28802, 30107,36787,42355,42336,13624,14327,14328,40658,18054,18055, 18056,11382, 11383,5779, 5778, 5780,27970, 30140,27915,27919,101,481,482,2758,4475,4477,6488,7376,14131,14132,16022,16024,16909,17901,21848,21849,21868,22350,22976,24017,24937,25105,25106,25367,25394,29676,30801,32369,32820,35273,36450,39005,39113,41725,46633) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"' and T17.REGION_CODE='"+Session["Region"]+"'";
			//			sql=sql+" and (T13.VEND_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR T17.MFG_CD IN (4475, 4477, 14131, 14132, 14327, 14328, 15147, 15148, 46602, 22552, 22976, 46633, 481, 482, 27970, 30140, 25394, 25801, 41695, 28741, 28742, 30107, 16777, 16909, 16988,  17901, 21868, 35273, 39113, 24017, 25105, 25106, 42336, 40658, 36450, 101, 29676,  32820, 6488, 7376, 13624, 22350, 16521, 17202, 17203, 18055, 25525, 25901, 26023, 32972, 25367, 38998, 32369,  30801, 38668, 11382, 11383, 16022, 16024, 21848,  21849, 2758, 5779, 5778, 5780, 39005, 41725, 24937, 44328) OR ((T13.VEND_CD IN ('6366','6365','25655') OR T17.MFG_CD IN ('6366','6365','25655')) AND instr(upper(T18.ITEM_DESC_PO),upper('VESTIBULE'))>0)) And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"'";
			if (lstCallStatus.SelectedValue != "All")
			{
				sql = sql + " and T17.CALL_STATUS='" + lstCallStatus.SelectedValue + "'";
			}

			if (CheckBox1.Checked == true)
			{
				sql = sql + " order By T17.REGION_CODE,VPO.VENDOR,T17.CALL_RECV_DT";
			}
			else
			{
				sql = sql + " order By VPO.VENDOR,T17.CALL_RECV_DT";
			}
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region, RITES Ltd."; }

			int ctr = 60;
			int wSno = 0;



			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='21'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='center'><font face='Verdana'>Cape Gauge Coaches MOZ Bought Out Items Status during " + wHdr_YrMth + " (Report Sorted on Call Date)</font><br></p>");
				//Response.Write("<H5 align='center'><font face='Verdana'>Client : "+lstBPO_Rly.SelectedValue+"</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>SNo.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>PO Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>BPO</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Date</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Sno.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Letter/Ref No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Status</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Vendor/Manufacturer</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>BK No.</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>SET No.</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>BILL No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Inspection Desire Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>First Insp Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Last Insp Date</font></b></th>");
				Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Item Desc</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Off</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Pass</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty Rej</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{
					if (wCase_No == reader["CASE_NO"].ToString() && wCall_Date == reader["CALL_DATE"].ToString() && wCall_Sno == Convert.ToInt16(reader["CALL_SNO"]))
					{
						if (wBK_NO == reader["BK_NO"].ToString() && wSET_NO == reader["SET_NO"].ToString())
						{
							Response.Write("<tr>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=17> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
							Response.Write("</tr>");
						}
						else
						{
							Response.Write("<tr>");
							Response.Write("<td width='10%' valign='top' align='Left' colspan=11> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
							Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DT_INSP_DESIRE"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["LAST_INSP_DT"]); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
							Response.Write("</tr>");
							wBK_NO = reader["BK_NO"].ToString();
							wSET_NO = reader["SET_NO"].ToString();
						}
					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(wSno); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_DATE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_LETTER_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_STATUS_DESC"]); Response.Write("</td>");
						if (reader["VENDOR"].ToString() == reader["MANU"].ToString())
						{
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
						}
						else
						{
							Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"] + " at " + reader["MANU"]); Response.Write("</td>");
						}

						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DT_INSP_DESIRE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["LAST_INSP_DT"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_PASS"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
						Response.Write("</tr>");
						ctr = ctr + 1;
						wCase_No = Convert.ToString(reader["CASE_NO"]);
						wCall_Date = Convert.ToString(reader["CALL_DATE"]);
						wCall_Sno = Convert.ToInt16(reader["CALL_SNO"]);
					}
				};
				Response.Write("</table>");
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
		void pending_ji_cases()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string wDtFr;
			string wDtTo;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "select COMPLAINT_ID,to_char(COMPLAINT_DT,'dd/mm/yyyy')COMPLAINT_DATE,REJ_MEMO_NO||' Dt. '||to_char(REJ_MEMO_DT,'dd/mm/yyyy') REJ_MEMO, CASE_NO,BK_NO,SET_NO,T40.IE_NAME, IE_CO_NAME,decode(COMP_RECV_REGION,'N','Northern','S','Southern','W','Western','E','Eastern','C','Central') COMP_RECV_REGION, CONSIGNEE_NAME||', '||CONSIGNEE_CITY CONSIGNEE, VENDOR, ITEM_DESC, QTY_OFFERED||' '||UOM_S_DESC QTY_OFF,QTY_REJECTED||' '||UOM_S_DESC QTY_REJECTED,REJECTION_VALUE, REJECTION_REASON, STATUS, DECODE(JI_REQUIRED,'Y','Yes','N','NO','Cancelled')JI_REQUIRED, JI_SNO, to_char(JI_FIX_DT,'dd/mm/yyyy')JI_DATE, T38.DEFECT_DESC, T39.JI_STATUS_DESC, ACTION, L5NO_PO PO_NO, to_char(PO_DT,'dd/mm/yyyy')PO_DATE, to_char(IC_DT,'dd/mm/yyyy')IC_DATE,T09.IE_NAME JI_IE_NAME,Decode(ACTION_PROPOSED,'W','Warning Letter','I','Minor Penalty','J','Major Penalty','O','Others') ACTION_PROPOSED, to_char(ACTION_PROPOSED_DT,'dd/mm/yyyy') ACTION_PROPOSED_DATE, CO_NAME, T40.CASE_NO, T40.BK_NO, T40.SET_NO  from V40_CONSIGNEE_COMPLAINTS T40,T38_DEFECT_CODES T38,T39_JI_STATUS_CODES T39,T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T40.DEFECT_CD=T38.DEFECT_CD(+) and T40.JI_STATUS_CD =T39.JI_STATUS_CD(+) and T40.JI_IE_CD=T09.IE_CD(+) and T40.IE_CO_CD=T08.CO_CD(+) and (COMPLAINT_DT>'01-APR-13') and JI_REQUIRED='Y' and (JI_FIX_DT>=sysdate OR to_char(JI_FIX_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(JI_FIX_DT,'yyyyMMdd')<='" + wDtTo + "') and NVL(T40.JI_STATUS_CD,0)=0 and T40.JI_IE_CD='" + Convert.ToString(Session["IE_CD"]) + "' ";
			int ctr = 60;
			int wSno = 0;


			sql = sql + " order by T40.JI_SNO,T40.COMP_RECV_REGION,T40.COMPLAINT_DT";





			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='30'>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='30'>");
				Response.Write("<H5 align='center'><font face='Verdana'>Pending JI Cases </font><br></p>");



				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				//				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'></font></b></th>");
				Response.Write("<th width='3%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Complaint ID</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Firm</font></b></th>");
				Response.Write("<th width='3%' valign='top'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Date</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Item</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Consignee</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='3%' valign='top'><b><font size='1' face='Verdana'>Qty Offered</font></b></th>");
				Response.Write("<th width='3%' valign='top'><b><font size='1' face='Verdana'>Qty Rejected</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Value of Rejected Stores</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Date of 1st Reference</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Reason of Rejection</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Status (Decision taken by JI Committe)</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Date of JI</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Date of IC</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>JI CASE</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>JI REPORT</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{
					wSno = wSno + 1;

					Response.Write("<tr>");
					//					Response.Write("<td width='7%' valign='top'><a href='IE_JI_Remarks_Entry_Form.aspx?COMPLAINT_ID="+reader["COMPLAINT_ID"].ToString()+"' Font-Names='Verdana' Font-Size='8pt'>Select</a>");Response.Write("</td>");

					Response.Write("<td width='3%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");

					Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["COMPLAINT_ID"]); Response.Write("</td>");



					Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
					Response.Write("<td width='3%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
					Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='3%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
					Response.Write("<td width='3%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
					Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["REJECTION_VALUE"]); Response.Write("</td>");
					Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["COMPLAINT_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["REJECTION_REASON"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["STATUS"]); Response.Write("</td>");
					Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["JI_DATE"]); Response.Write("</td>");
					Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IC_DATE"]); Response.Write("</td>");



					string fpath11 = Server.MapPath("/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF");
					string fpath1 = Server.MapPath("/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF");
					//					if (File.Exists(fpath1)==false) 
					//					{
					//						Response.Write(" ");
					//					}
					//					else
					//					{
					//						Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_CASES/"+reader["CASE_NO"].ToString()+"-"+reader["BK_NO"].ToString()+"-"+reader["SET_NO"].ToString()+".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI CASE</font></a></td>");
					//						
					//
					//					}
					if (File.Exists(fpath1) == false && File.Exists(fpath11) == false)
					{
						Response.Write("<td width='100%' align='center' valign='center'></td>");
					}
					else if (File.Exists(fpath1) == false && File.Exists(fpath11) == true)
					{
						Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI CASE</font></a></td>");
					}
					else
					{
						Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI CASE</font></a></td>");


					}
					//					string fpath2=Server.MapPath("/RBS/COMPLAINTS_REPORT/"+reader["CASE_NO"].ToString()+"-"+reader["BK_NO"].ToString()+"-"+reader["SET_NO"].ToString()+".TIF");
					//					if (File.Exists(fpath2)==false) 
					//					{
					//						Response.Write(" ");
					//					}
					//					else
					//					{
					//						Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_REPORT/"+reader["CASE_NO"].ToString()+"-"+reader["BK_NO"].ToString()+"-"+reader["SET_NO"].ToString()+".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI REPORT</font></a></td>");
					//						
					//
					//					}

					string fpath2 = Server.MapPath("/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF");
					string fpath22 = Server.MapPath("/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF");
					if (File.Exists(fpath2) == false && File.Exists(fpath22) == false)
					{
						Response.Write("<td width='100%' align='center' valign='center'></td>");
					}
					else if (File.Exists(fpath2) == false && File.Exists(fpath22) == true)
					{
						Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI REPORT</font></a></td>");
					}
					else
					{
						Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI REPORT</font></a></td>");


					}
					Response.Write("</tr>");



					ctr = ctr + 1;

				}


				Response.Write("</table>");
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
		void no_calls_online_manual()
		{
			string sql = "select sum(MANUAL_CALLS) MANUAL_CALLS,SUM(ONLINE_CALLS) ONLINE_CALLS, sum(TOTAL_CALLS) TOTAL_CALLS, SUM(AUTO_CALL) AUTO_CALLS from ( " +
					   " select count(*) MANUAL_CALLS,0 ONLINE_CALLS,0 TOTAL_CALLS,0 AUTO_CALL from T17_CALL_REGISTER where substr(CASE_NO,1,1)='" + Session["Region"] + "' and (CALL_RECV_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and NVL(ONLINE_CALL,'X')='X' " +
					   " UNION ALL select 0 MANUAL_CALLS,count(*) ONLINE_CALLS,0 TOTAL_CALLS,0 AUTO_CALL from T17_CALL_REGISTER where substr(CASE_NO,1,1)='" + Session["Region"] + "' and (CALL_RECV_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and NVL(ONLINE_CALL,'X')='Y' " +
					   " UNION ALL select 0 MANUAL_CALLS,0 ONLINE_CALLS,count(*) TOTAL_CALLS,0 AUTO_CALL from T17_CALL_REGISTER where substr(CASE_NO,1,1)='" + Session["Region"] + "' and (CALL_RECV_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy'))  " +
					   " UNION ALL select 0 MANUAL_CALLS,0 ONLINE_CALLS,0 TOTAL_CALLS,count(*) AUTO_CALL from T17_CALL_REGISTER where substr(CASE_NO,1,1)='" + Session["Region"] + "' and (CALL_RECV_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and NVL(AUTOMATIC_CALL,'X')='Y') ";



			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='3'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='8'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>No. of Online & Manual Calls, for the Period : " + wFrmDt + " TO " + wToDt + " (W.E.F 29-JUN-2013)</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Manual Calls</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Online Calls</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total Calls</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Manual Calls (%)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Online Calls (%)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Automatic Calls Marked</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Automatic Calls as (%)age of Online Calls Marked</font></b></th>");

				Response.Write("</tr></font>");

				while (reader.Read())
				{


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["MANUAL_CALLS"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ONLINE_CALLS"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["TOTAL_CALLS"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(Decimal.Round(Convert.ToDecimal((Convert.ToDecimal(reader["MANUAL_CALLS"]) / Convert.ToDecimal(reader["TOTAL_CALLS"])) * 100), 2)); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(Decimal.Round(Convert.ToDecimal((Convert.ToDecimal(reader["ONLINE_CALLS"]) / Convert.ToDecimal(reader["TOTAL_CALLS"])) * 100), 2)); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["AUTO_CALLS"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(Decimal.Round(Convert.ToDecimal((Convert.ToDecimal(reader["AUTO_CALLS"]) / Convert.ToDecimal(reader["ONLINE_CALLS"])) * 100), 2)); Response.Write("</td>");
					Response.Write("</tr>");


				};

				Response.Write("</table>");
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
		void call_return_report()
		{
			string sql = "select to_char(T43.RETURN_DT,'dd/mm/yyyy') RETURN_DATE,T43.CALL_LETTER_NO,to_char(T43.CALL_LETTER_DT,'dd/mm/yyyy') LETTER_DATE ,to_char(T43.DT_OF_RECIEPT,'dd/mm/yyyy') RECIEPT_DATE,V05.VENDOR, T43.VEND_EMAIL, " +
				"decode(T43.RETURN_REASON_1,1,'P.O. not attached with call also P.O. not received from purchaser.',2,'P.O. is not readable/Incomplete/not signed.',3,'P.O. value is less than one Lakh (Railway Board order).',4,' Delivery Period expired.',5,'Bill Paying Officer not mentioned in P.O.',6,'Inspection clause indicating RITES inspection not mentioned in P.O.',7,'Inspection by RDSO/Consignee/Other RITES regional offices.',8,'Adequate time not given to initiate the inspection with in D.P.',9,'OThers:'||RETURN_REMARKS)||'*'|| " +
				"decode(T43.RETURN_REASON_2,1,'P.O. not attached with call also P.O. not received from purchaser.',2,'P.O. is not readable/Incomplete/not signed.',3,'P.O. value is less than one Lakh (Railway Board order).',4,' Delivery Period expired.',5,'Bill Paying Officer not mentioned in P.O.',6,'Inspection clause indicating RITES inspection not mentioned in P.O.',7,'Inspection by RDSO/Consignee/Other RITES regional offices.',8,'Adequate time not given to initiate the inspection with in D.P.',9,'OThers:'||RETURN_REMARKS)||'*'|| " +
				"decode(T43.RETURN_REASON_3,1,'P.O. not attached with call also P.O. not received from purchaser.',2,'P.O. is not readable/Incomplete/not signed.',3,'P.O. value is less than one Lakh (Railway Board order).',4,' Delivery Period expired.',5,'Bill Paying Officer not mentioned in P.O.',6,'Inspection clause indicating RITES inspection not mentioned in P.O.',7,'Inspection by RDSO/Consignee/Other RITES regional offices.',8,'Adequate time not given to initiate the inspection with in D.P.',9,'OThers:'||RETURN_REMARKS)||'*'|| " +
				"decode(T43.RETURN_REASON_4,1,'P.O. not attached with call also P.O. not received from purchaser.',2,'P.O. is not readable/Incomplete/not signed.',3,'P.O. value is less than one Lakh (Railway Board order).',4,' Delivery Period expired.',5,'Bill Paying Officer not mentioned in P.O.',6,'Inspection clause indicating RITES inspection not mentioned in P.O.',7,'Inspection by RDSO/Consignee/Other RITES regional offices.',8,'Adequate time not given to initiate the inspection with in D.P.',9,'OThers:'||RETURN_REMARKS) REASON" +
				" from T43_CALL_RETURN T43,V05_VENDOR V05 where T43.VEND_CD=V05.VEND_CD and (T43.RETURN_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and substr(RETURN_NO,1,1)='" + Session["Region"] + "'" +
				"GROUP BY to_char(T43.RETURN_DT,'dd/mm/yyyy'),T43.CALL_LETTER_NO,to_char(T43.CALL_LETTER_DT,'dd/mm/yyyy'), to_char(T43.DT_OF_RECIEPT,'dd/mm/yyyy'), V05.VENDOR, T43.VEND_EMAIL,	" +
				"decode(T43.RETURN_REASON_1,1,'P.O. not attached with call also P.O. not received from purchaser.',2,'P.O. is not readable/Incomplete/not signed.',3,'P.O. value is less than one Lakh (Railway Board order).',4,' Delivery Period expired.',5,'Bill Paying Officer not mentioned in P.O.',6,'Inspection clause indicating RITES inspection not mentioned in P.O.',7,'Inspection by RDSO/Consignee/Other RITES regional offices.',8,'Adequate time not given to initiate the inspection with in D.P.',9,'OThers:'||RETURN_REMARKS)||'*'|| " +
				"decode(T43.RETURN_REASON_2,1,'P.O. not attached with call also P.O. not received from purchaser.',2,'P.O. is not readable/Incomplete/not signed.',3,'P.O. value is less than one Lakh (Railway Board order).',4,' Delivery Period expired.',5,'Bill Paying Officer not mentioned in P.O.',6,'Inspection clause indicating RITES inspection not mentioned in P.O.',7,'Inspection by RDSO/Consignee/Other RITES regional offices.',8,'Adequate time not given to initiate the inspection with in D.P.',9,'OThers:'||RETURN_REMARKS)||'*'|| " +
				"decode(T43.RETURN_REASON_3,1,'P.O. not attached with call also P.O. not received from purchaser.',2,'P.O. is not readable/Incomplete/not signed.',3,'P.O. value is less than one Lakh (Railway Board order).',4,' Delivery Period expired.',5,'Bill Paying Officer not mentioned in P.O.',6,'Inspection clause indicating RITES inspection not mentioned in P.O.',7,'Inspection by RDSO/Consignee/Other RITES regional offices.',8,'Adequate time not given to initiate the inspection with in D.P.',9,'OThers:'||RETURN_REMARKS)||'*'|| " +
				"decode(T43.RETURN_REASON_4,1,'P.O. not attached with call also P.O. not received from purchaser.',2,'P.O. is not readable/Incomplete/not signed.',3,'P.O. value is less than one Lakh (Railway Board order).',4,' Delivery Period expired.',5,'Bill Paying Officer not mentioned in P.O.',6,'Inspection clause indicating RITES inspection not mentioned in P.O.',7,'Inspection by RDSO/Consignee/Other RITES regional offices.',8,'Adequate time not given to initiate the inspection with in D.P.',9,'OThers:'||RETURN_REMARKS) order by 1";

			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='8'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='8'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Details of Calls Returned for the Period : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Return Date</font></b></th>");
				Response.Write("<th width='30%' valign='top'><b><font size='1' face='Verdana'>Vendor</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Vend Email</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Call Letter No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Call Letter Date</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Date of Reciept in Rites</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Reason For Return</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["RETURN_DATE"]); Response.Write("</td>");
					Response.Write("<td width='30%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VEND_EMAIL"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_LETTER_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["LETTER_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["RECIEPT_DATE"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["REASON"]); Response.Write("</td>");
					Response.Write("</tr>");


				};

				Response.Write("</table>");
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


		void details_of_bills_notscanned()
		{
			//			string sql="select T22.BILL_NO,to_char(T22.BILL_DT,'dd/mm/yyyy') BILL_DATE,T22.BILL_AMOUNT, V22.BK_NO,V22.SET_NO,decode(V22.BPO_TYPE,'R','Railway','P','Private','U','PSU','S','State Govt','F','Foreign Railway') BPO_TYPE,V22.BPO_RLY||'/'||BPO_NAME||'/'||BPO_CITY BPO,VEND_NAME||'/'||VENDOR_CITY VENDOR, CONSIGNEE||'/'||CONSIGNEE_CITY CONSIGNEE,T09.IE_NAME from T22_BILL T22, V22_BILL V22,T09_IE T09 where T22.BILL_NO(+)=V22.BILL_NO and V22.IE_CD=T09.IE_CD and NVL(T22.SCANNED_STATUS,'X')='X' and V22.REGION_CODE='"+Session["Region"]+"' and (T22.BILL_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) order by T22.BILL_DT,T22.BILL_NO " ;
			string sql = "select T22.BILL_NO,to_char(T22.BILL_DT,'dd/mm/yyyy') BILL_DATE,T22.BILL_AMOUNT, T20.BK_NO,T20.SET_NO,decode(T13.RLY_NONRLY,'R','Railway','P','Private','U','PSU','S','State Govt','F','Foreign Railway') BPO_TYPE, V12.BPO,V05.VENDOR, V06.CONSIGNEE,T09.IE_NAME from T22_BILL T22, T13_PO_MASTER T13,T20_IC T20,T09_IE T09,V12_BILL_PAYING_OFFICER V12,V05_VENDOR V05, V06_CONSIGNEE V06 where T22.CASE_NO(+)=T13.CASE_NO and T22.BILL_NO=T20.BILL_NO and T20.BPO_CD=V12.BPO_CD and T20.CONSIGNEE_CD=V06.CONSIGNEE_CD and T13.VEND_CD=V05.VEND_CD and T20.IE_CD=T09.IE_CD and NVL(T22.SCANNED_STATUS,'X')='X' and T13.REGION_CODE='" + Session["Region"] + "' and (T22.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) order by T22.BILL_AMOUNT ";

			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='10'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='10'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Details of Bills Not Scanned for the Period : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BILL NO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BILL DATE</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>BILL AMOUNT</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>BK NO</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>SET NO</font></b></th>");
				Response.Write("<th width='14%' valign='top'><b><font size='1' face='Verdana'>BPO</font></b></th>");
				Response.Write("<th width='14%' valign='top'><b><font size='1' face='Verdana'>VENDOR</font></b></th>");
				Response.Write("<th width='14%' valign='top'><b><font size='1' face='Verdana'>CONSIGNEE</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");

				Response.Write("</tr></font>");

				while (reader.Read())
				{


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DATE"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
					Response.Write("<td width='14%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO"]); Response.Write("</td>");
					Response.Write("<td width='14%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
					Response.Write("<td width='14%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("</tr>");


				};

				Response.Write("</table>");
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
		void Defectcodewise_Compliants()
		{
			string sql = "select DEFECT_CD,DEFECT_DESC,SUM(UPHELD) UPHELD,SUM(SORTING) SORTING,SUM(RECTIFICATION) RECTIFICATION,SUM(PRICE_REDUCTION) PRICE_REDUCTION from " +
						"(select T38.DEFECT_CD,T38.DEFECT_DESC,count(*) UPHELD,0 SORTING,0 RECTIFICATION,0 PRICE_REDUCTION from T40_CONSIGNEE_COMPLAINTS T40,T38_DEFECT_CODES T38 where T40.DEFECT_CD=T38.DEFECT_CD and JI_STATUS_CD=2 and JI_REQUIRED='Y' and substr(T40.COMPLAINT_ID,1,1)='" + Session["Region"] + "' and (T40.COMPLAINT_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) group by T38.DEFECT_CD,T38.DEFECT_DESC " +
						"UNION ALL select T38.DEFECT_CD,T38.DEFECT_DESC,0 UPHELD,count(*) SORTING,0 RECTIFICATION,0 PRICE_REDUCTION from T40_CONSIGNEE_COMPLAINTS T40,T38_DEFECT_CODES T38 where T40.DEFECT_CD=T38.DEFECT_CD and JI_STATUS_CD=3 and JI_REQUIRED='Y' and substr(T40.COMPLAINT_ID,1,1)='" + Session["Region"] + "' and (T40.COMPLAINT_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) group by T38.DEFECT_CD,T38.DEFECT_DESC " +
						"UNION ALL select T38.DEFECT_CD,T38.DEFECT_DESC,0 UPHELD,0 SORTING,count(*) RECTIFICATION,0 PRICE_REDUCTION from T40_CONSIGNEE_COMPLAINTS T40,T38_DEFECT_CODES T38 where T40.DEFECT_CD=T38.DEFECT_CD and JI_STATUS_CD=4 and JI_REQUIRED='Y' and substr(T40.COMPLAINT_ID,1,1)='" + Session["Region"] + "' and (T40.COMPLAINT_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) group by T38.DEFECT_CD,T38.DEFECT_DESC " +
						"UNION ALL select T38.DEFECT_CD,T38.DEFECT_DESC,0 UPHELD,0 SORTING,0 RECTIFICATION,count(*) PRICE_REDUCTION from T40_CONSIGNEE_COMPLAINTS T40,T38_DEFECT_CODES T38 where T40.DEFECT_CD=T38.DEFECT_CD and JI_STATUS_CD=5 and JI_REQUIRED='Y' and substr(T40.COMPLAINT_ID,1,1)='" + Session["Region"] + "' and (T40.COMPLAINT_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) group by T38.DEFECT_CD,T38.DEFECT_DESC " +
						") group by DEFECT_CD,DEFECT_DESC order by DEFECT_CD";
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='16'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='16'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Defect Code Wise Analysis of Complaints for the Period : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='40%' valign='top'><b><font size='1' face='Verdana'>Code</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Upheld</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Sorting</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Rectification</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Price Reduction</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Total</font></b></th>");
				Response.Write("</tr></font>");

				int wTotal = 0;
				int wTotal_Upheld = 0;
				int wTotal_Sorting = 0;
				int wTotal_Rectification = 0;
				int wTotal_Price_Reduction = 0;

				while (reader.Read())
				{

					wTotal = 0;
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='40%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["DEFECT_DESC"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["UPHELD"]); Response.Write("</td>");
					wTotal = wTotal + Convert.ToInt32(reader["UPHELD"]);
					wTotal_Upheld = wTotal_Upheld + Convert.ToInt32(reader["UPHELD"]);
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SORTING"]); Response.Write("</td>");
					wTotal = wTotal + Convert.ToInt32(reader["SORTING"]);
					wTotal_Sorting = wTotal_Sorting + Convert.ToInt32(reader["SORTING"]);
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["RECTIFICATION"]); Response.Write("</td>");
					wTotal = wTotal + Convert.ToInt32(reader["RECTIFICATION"]);
					wTotal_Rectification = wTotal_Rectification + Convert.ToInt32(reader["RECTIFICATION"]);
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PRICE_REDUCTION"]); Response.Write("</td>");
					wTotal = wTotal + Convert.ToInt32(reader["PRICE_REDUCTION"]);
					wTotal_Price_Reduction = wTotal_Price_Reduction + Convert.ToInt32(reader["PRICE_REDUCTION"]);

					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wTotal); Response.Write("</td>");
					Response.Write("</tr>");


				};
				Response.Write("<tr>");
				Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'> </td>");
				Response.Write("<td width='40%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write("<b>Total</b>"); Response.Write("</td>");
				Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wTotal_Upheld); Response.Write("</td>");
				Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wTotal_Sorting); Response.Write("</td>");
				Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wTotal_Rectification); Response.Write("</td>");
				Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wTotal_Price_Reduction); Response.Write("</td>");
				Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wTotal_Upheld + wTotal_Sorting + wTotal_Rectification + wTotal_Price_Reduction); Response.Write("</td>");
				Response.Write("</tr>");

				Response.Write("</table>");
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

		void client_wisepoandvalue()
		{

			int ctr = 60;
			string first_page = "Y";


			string str6 = "Select decode(RLY_NONRLY,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,substr(decode(RLY_NONRLY,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted'),2) BPO_TYPE2,RLY_CD BPO_RLY,count(*) NO_OF_PO,sum(T15.Value) VALUE From T13_PO_MASTER T13, T15_PO_DETAIL T15 where T13.CASE_NO=T15.CASE_NO and substr(T13.CASE_NO,1,1)='" + Session["Region"].ToString() + "' and (RECV_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) group by RLY_NONRLY,RLY_CD order by BPO_TYPE,BPO_RLY";

			OracleCommand cmd6 = new OracleCommand(str6, conn);
			conn.Open();
			OracleDataAdapter da = new OracleDataAdapter(str6, conn);
			DataSet dsP = new DataSet();
			da.SelectCommand = cmd6;
			da.Fill(dsP, "Table");

			int t1 = 0, t11 = 0;
			double t2 = 0, t22 = 0;
			double t3 = 0, t33 = 0;
			for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
			{

				if (ctr > 50)
				{
					Response.Write("<table border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr>");
					Response.Write("<td width='100%' colspan='3'>");
					if (first_page == "N")
					{ Response.Write("<p style = page-break-before:always></p>"); }
					else
					{ first_page = "N"; }
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("</table>");
					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr>");
					Response.Write("<td width='100%' colspan='5'>");
					Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
					Response.Write("<H5 align='center'><font face='Verdana'>Client Wise No. Of Po and their Total Value For the Period " + frmDt.Text + " to " + toDt.Text + "</font></p>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<th width='45%' valign='top' align='center'><b><font size='2' face='Verdana'>Railway/Client</font></b></th>");
					Response.Write("<th width='15%' valign='top' align='center'><b><font size='2' face='Verdana'>No Of PO's</font></b></th>");
					Response.Write("<th width='15%' valign='top' align='center'><b><font size='2' face='Verdana'>Total Value</font></b></th>");
					Response.Write("<th width='15%' valign='top' align='center'><b><font size='2' face='Verdana'>Inspection Fee(0.9%)</font></b></th>");
					Response.Write("</tr></font>");
					ctr = 5;

				};
				if ((i >= 1))
				{
					if ((dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString().Equals(dsP.Tables[0].Rows[i - 1]["BPO_TYPE"].ToString()) == false))
					{
						Response.Write("<tr>");
						Response.Write("<td width='13%' valign='top' align='center' colspan=5 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"); Response.Write(dsP.Tables[0].Rows[i]["BPO_TYPE2"].ToString()); Response.Write("</b></td>");
						Response.Write("</tr>");
					}
				}
				else
				{
					Response.Write("<tr>");
					Response.Write("<td width='13%' valign='top' align='center' colspan=5 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"); Response.Write(dsP.Tables[0].Rows[i]["BPO_TYPE2"].ToString()); Response.Write("</b></td>");
					Response.Write("</tr>");
				}
				Response.Write("<tr>");
				Response.Write("<td width='45%' valign='top' align='Left'><b><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["BPO_RLY"].ToString() + "</font></b></td>");
				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["NO_OF_PO"].ToString() + "</font></b></td>");
				t1 = t1 + Convert.ToInt32(dsP.Tables[0].Rows[i]["NO_OF_PO"].ToString());
				t11 = t11 + Convert.ToInt32(dsP.Tables[0].Rows[i]["NO_OF_PO"].ToString());
				t2 = t2 + Convert.ToDouble(dsP.Tables[0].Rows[i]["VALUE"].ToString());
				t22 = t22 + Convert.ToDouble(dsP.Tables[0].Rows[i]["VALUE"].ToString());
				t3 = t3 + Convert.ToDouble(dsP.Tables[0].Rows[i]["VALUE"].ToString()) * .9 / 100;
				t33 = t33 + Convert.ToDouble(dsP.Tables[0].Rows[i]["VALUE"].ToString()) * .9 / 10;
				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["VALUE"].ToString() + "</font></b></td>");
				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + Convert.ToString(Math.Round(Convert.ToDouble(dsP.Tables[0].Rows[i]["VALUE"].ToString()) * .9 / 100, 2)) + "</font></b></td>");
				Response.Write("</tr>");
				ctr = ctr + 1;
				if ((i < dsP.Tables[0].Rows.Count - 1))
				{
					if ((dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString().Equals(dsP.Tables[0].Rows[i + 1]["BPO_TYPE"].ToString()) == false))
					{
						Response.Write("<tr bgColor='#d4d0c8'>");
						Response.Write("<td width='45%' valign='top' align='center'><b><font size='1' face='Verdana'>Total For " + dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString() + ": </font></b></td>");
						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t1 + "</font></b></td>");
						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t2 + "</font></b></td>");
						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + Math.Round(t3, 2) + "</font></b></td>");
						Response.Write("</tr>");
						t1 = 0; t2 = 0; t3 = 0;
					}
				}
				else
				{
					Response.Write("<tr bgColor='#d4d0c8'>");
					Response.Write("<td width='45%' valign='top' align='center'><b><font size='1' face='Verdana'>Total For " + dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString() + " : </font></b></td>");
					Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t1 + "</font></b></td>");
					Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t2 + "</font></b></td>");
					Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + Math.Round(t3, 2) + "</font></b></td>");
					Response.Write("</tr>");
					t2 = 0; t1 = 0; t3 = 0;

				}
			}
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='45%' valign='top' align='center'><b><font size='1' face='Verdana'>Grand Total:</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t11 + "</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t22 + "</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>" + Math.Round(t33, 2) + "</font></b></td>");
			Response.Write("</tr>");

			conn.Close();
			Response.Write("</table><br>");
		}

		void ie_performance_expanded()
		{
			//			int ctr =60;
			//			string first_page="Y";      
			Response.Write("<html><body>");
			Response.Write("<br><br><p align=center><font size='3' face='Verdana'><b><u>IE Performance For The Period: " + wFrmDt + " To " + wToDt + "  (" + wRegion + ")</u></b></font></p><br>");
			//string str="SELECT ('Rejections Issued by I.E During The Month --> '||COUNT(*)) REJECTION FROM t20_ic WHERE ic_type_id=2 AND SUBSTR(case_no,1,1)='"+Session["Region"].ToString()+"' AND bill_no in (Select bill_no from t22_bill where TO_CHAR(bill_dt,'yyyymm')='"+wYrMth+"' AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			string str = "";
			if (Convert.ToString(Session["Uname"]) != "")
			{
				str = "SELECT ('Rejections Issued by I.E During The Period --> '||COUNT(*)) REJECTION FROM t20_ic WHERE ic_type_id=2 AND SUBSTR(case_no,1,1)='" + Session["Region"].ToString() + "' AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')";
			}
			else if (Convert.ToString(Session["IE_CD"]) != "")
			{
				str = "SELECT ('Rejections Issued by I.E During The Period --> '||COUNT(*)) REJECTION FROM t20_ic WHERE ic_type_id=2 AND IE_CD='" + Convert.ToString(Session["IE_CD"]) + "' AND SUBSTR(case_no,1,1)='" + Session["Region"].ToString() + "' AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')";
			}
			OracleCommand cmd = new OracleCommand(str, conn);
			conn.Open();
			string reader = Convert.ToString(cmd.ExecuteScalar());

			if (reader.Length > 0)
			{
				Response.Write("<font size='2' face='Verdana'>" + reader + "</font><br>");
			}

			conn.Close();

			//string str1="SELECT COUNT(*) FROM t20_ic WHERE bill_no in (Select bill_no from t22_bill where TO_CHAR(bill_dt,'yyyymm')='"+wYrMth+"' AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			string str1 = "";
			if (Convert.ToString(Session["Uname"]) != "")
			{
				str1 = "SELECT COUNT(*) FROM t20_ic WHERE bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')";
			}
			else if (Convert.ToString(Session["IE_CD"]) != "")
			{
				str1 = "SELECT COUNT(*) FROM t20_ic WHERE IE_CD='" + Convert.ToString(Session["IE_CD"]) + "' and bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')";
			}

			OracleCommand cmd1 = new OracleCommand(str1, conn);
			conn.Open();
			string reader1 = Convert.ToString(cmd1.ExecuteScalar());

			if (reader1.Length > 0)
			{
				Response.Write("<font size='2' face='Verdana'>No. Of IC's: -->" + reader1 + "</font><br>");
			}

			conn.Close();

			//string str2="SELECT ('Calls Attended within 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (first_insp_dt - call_dt <= 7 ) AND bill_no in (Select bill_no from t22_bill where TO_CHAR(bill_dt,'yyyymm')='"+wYrMth+"' AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			string str2 = "";
			if (Convert.ToString(Session["Uname"]) != "")
			{
				str2 = "SELECT ('Calls Attended within 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) <= 7 AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')";
			}
			else if (Convert.ToString(Session["IE_CD"]) != "")
			{
				str2 = "SELECT ('Calls Attended within 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) <= 7 and IE_CD='" + Convert.ToString(Session["IE_CD"]) + "' AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')";
			}


			OracleCommand cmd2 = new OracleCommand(str2, conn);
			conn.Open();
			string reader2 = Convert.ToString(cmd2.ExecuteScalar());

			if (reader2.Length > 0)
			{
				Response.Write("<font size='2' face='Verdana'>" + reader2 + "</font><br>");
			}

			conn.Close();

			//string str3="SELECT ('Calls Attended Beyond 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (first_insp_dt - call_dt > 7 ) AND bill_no in (Select bill_no from t22_bill where TO_CHAR(bill_dt,'yyyymm')='"+wYrMth+"' AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			string str3 = "";
			if (Convert.ToString(Session["Uname"]) != "")
			{
				str3 = "SELECT ('Calls Attended Beyond 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (first_insp_dt - call_dt > 7 ) AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')";
			}
			else if (Convert.ToString(Session["IE_CD"]) != "")
			{
				str3 = "SELECT ('Calls Attended Beyond 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (first_insp_dt - call_dt > 7 ) and IE_CD='" + Convert.ToString(Session["IE_CD"]) + "' AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')";
			}

			OracleCommand cmd3 = new OracleCommand(str3, conn);
			conn.Open();
			string reader3 = Convert.ToString(cmd3.ExecuteScalar());

			if (reader3.Length > 0)
			{
				Response.Write("<font size='2' face='Verdana'>" + reader3 + "</font><br>");
			}
			conn.Close();
			Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
			Response.Write("<tr>");
			Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Dept</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>Total Calls</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Calls Cancelled</font></b></th>");
			Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>No. of IC</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Calls Attended Within 7 Days.</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Calls Attended Beyond 7 Days.</font></b></th>");
			Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>Rejections</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Insp. Fee</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Material Value</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Average Fee</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>No. Of IC Issued after 1 days of Last Inspection date.</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>IC's Submitted beyond 7 Days after Issue of IC.</font></b></th>");
			Response.Write("</tr></font>");
			string str31 = "";
			if (Convert.ToString(Session["Uname"]) != "")
			{
				str31 = "Select IE_NAME,DEPT,sum(C3)C3,sum(C7)C7,sum(CM7)CM7,sum(C10)C10,sum(C0)C0,sum(INSP_FEE)INSP_FEE,sum(MATERIAL_VALUE)MATERIAL_VALUE,round(decode(sum(C0),0,0,sum(INSP_FEE)/sum(C0)),2)AVERAGE_FEE,sum(CALLS) CALLS,sum(CALL_CANCEL) CALL_CANCEL,sum(REJECTIONS) REJECTIONS from  (" +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,(COUNT(*))C3, 0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C WHERE A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND (nvl(IC_DT,'31-Dec-9999')-nvl(LAST_INSP_DT,'01-Jan-2005'))>1  AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"Select IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,(count(*)) C7,0 CM7,0 C10,0 C0,0 INSP_FEE, 0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  where A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO and (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) <= 7  and substr(A.case_no,1,1)='" + Session["Region"].ToString() + "'  group by IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"Select IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,(count(*)) CM7,0 C10,0 C0,0 INSP_FEE, 0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  where A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO and (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) > 7  and substr(A.case_no,1,1)='" + Session["Region"].ToString() + "'  group by IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,(COUNT(*))C10,0 C0, 0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  WHERE A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND (nvl(IC_SUBMIT_DT,'31-Dec-9999') - nvl(IC_DT,'01-Jan-2005'))>7  AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,(COUNT(*)) C0,sum(nvl(C.INSP_FEE,0)) INSP_FEE,sum(nvl(C.MATERIAL_VALUE,0)) MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  WHERE A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,COUNT(*) CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T17_CALL_REGISTER A, T09_IE B WHERE A.IE_CD=B.IE_CD AND (A.CALL_MARK_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND A.REGION_CODE='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(C.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,COUNT(*)  CALL_CANCEL,0 REJECTIONS FROM T19_CALL_CANCEL A, T17_CALL_REGISTER B, T09_IE C WHERE A.CASE_NO=B.CASE_NO and A.CALL_RECV_DT=B.CALL_RECV_DT and A.CALL_SNO=B.CALL_SNO and B.IE_CD=C.IE_CD AND (A.CANCEL_DATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(C.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,COUNT(*) REJECTIONS FROM T20_IC A, T09_IE B WHERE A.IE_CD=B.IE_CD AND A.ic_type_id=2 AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' AND A.bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')  GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others')) group by IE_NAME,DEPT order by IE_NAME";
			}
			else if (Convert.ToString(Session["IE_CD"]) != "")
			{
				str31 = "Select IE_NAME,DEPT,sum(C3)C3,sum(C7)C7,sum(CM7)CM7,sum(C10)C10,sum(C0)C0,sum(INSP_FEE)INSP_FEE,sum(MATERIAL_VALUE)MATERIAL_VALUE,round(decode(sum(C0),0,0,sum(INSP_FEE)/sum(C0)),2)AVERAGE_FEE,sum(CALLS) CALLS,sum(CALL_CANCEL) CALL_CANCEL,sum(REJECTIONS) REJECTIONS from  (" +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,(COUNT(*))C3, 0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C WHERE A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND (nvl(IC_DT,'31-Dec-9999')-nvl(LAST_INSP_DT,'01-Jan-2005'))>1 and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"Select IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,(count(*)) C7,0 CM7,0 C10,0 C0,0 INSP_FEE, 0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  where A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO and (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) <= 7 and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  and substr(A.case_no,1,1)='" + Session["Region"].ToString() + "'  group by IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"Select IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,(count(*)) CM7,0 C10,0 C0,0 INSP_FEE, 0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  where A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO and (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) > 7 and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  and substr(A.case_no,1,1)='" + Session["Region"].ToString() + "'  group by IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,(COUNT(*))C10,0 C0, 0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  WHERE A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND (nvl(IC_SUBMIT_DT,'31-Dec-9999') - nvl(IC_DT,'01-Jan-2005'))>7 and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,(COUNT(*)) C0,sum(nvl(C.INSP_FEE,0)) INSP_FEE,sum(nvl(C.MATERIAL_VALUE,0)) MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  WHERE A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,COUNT(*) CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T17_CALL_REGISTER A, T09_IE B WHERE A.IE_CD=B.IE_CD AND (A.CALL_MARK_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  and A.REGION_CODE='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(C.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,COUNT(*)  CALL_CANCEL,0 REJECTIONS FROM T19_CALL_CANCEL A, T17_CALL_REGISTER B, T09_IE C WHERE A.CASE_NO=B.CASE_NO and A.CALL_RECV_DT=B.CALL_RECV_DT and A.CALL_SNO=B.CALL_SNO and B.IE_CD=C.IE_CD AND (A.CANCEL_DATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and B.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "' AND  SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(C.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,COUNT(*) REJECTIONS FROM T20_IC A, T09_IE B WHERE A.IE_CD=B.IE_CD AND A.ic_type_id=2 and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' AND A.bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')  GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others')) group by IE_NAME,DEPT order by IE_NAME";
			}
			OracleCommand cmd31 = new OracleCommand(str31, conn);
			conn.Open();
			OracleDataReader reader31 = cmd31.ExecuteReader();
			int t_C0 = 0, t_C3 = 0, t_C7 = 0, t_CM7 = 0, t_C10 = 0, t_CALLS = 0, t_CALL_CANCEL = 0, t_REJECTIONS = 0;
			double t_INSP_FEE = 0, t_MATERIAL_VALUE = 0;
			while (reader31.Read())
			{
				Response.Write("<tr>");
				Response.Write("<td width='15%' valign='top' align='Left'><font size='1' face='Verdana'>" + reader31["IE_NAME"].ToString() + "</font></td>");
				Response.Write("<td width='15%' valign='top' align='center'><font size='1' face='Verdana'>" + reader31["DEPT"].ToString() + "</font></td>");
				Response.Write("<td width='7%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["CALLS"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["CALL_CANCEL"].ToString() + "</font></td>");
				Response.Write("<td width='6%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C0"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C7"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["CM7"].ToString() + "</font></td>");
				Response.Write("<td width='6%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["REJECTIONS"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["INSP_FEE"].ToString() + "</font></td>");
				Response.Write("<td width='10%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["MATERIAL_VALUE"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["AVERAGE_FEE"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C3"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C10"].ToString() + "</font></td>");
				Response.Write("</tr>");
				t_C0 = t_C0 + Convert.ToInt16(reader31["C0"]);
				t_C3 = t_C3 + Convert.ToInt16(reader31["C3"]);
				t_C7 = t_C7 + Convert.ToInt16(reader31["C7"]);
				t_CM7 = t_CM7 + Convert.ToInt16(reader31["CM7"]);
				t_C10 = t_C10 + Convert.ToInt16(reader31["C10"]);
				t_INSP_FEE = t_INSP_FEE + Convert.ToDouble(reader31["INSP_FEE"]);
				t_MATERIAL_VALUE = t_MATERIAL_VALUE + Convert.ToDouble(reader31["MATERIAL_VALUE"]);
				t_CALLS = t_CALLS + Convert.ToInt16(reader31["CALLS"]);
				t_CALL_CANCEL = t_CALL_CANCEL + Convert.ToInt16(reader31["CALL_CANCEL"]);
				t_REJECTIONS = t_REJECTIONS + Convert.ToInt16(reader31["REJECTIONS"]);
			}
			Response.Write("<tr>");
			Response.Write("<td width='15%' valign='top' align='Left' colspan='2'><font size='1' face='Verdana'><b>Totals</b></font></td>");
			Response.Write("<td width='7%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_CALLS + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_CALL_CANCEL + "</b></font></td>");
			Response.Write("<td width='6%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C0 + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C7 + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_CM7 + "</b></font></td>");
			Response.Write("<td width='6%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_REJECTIONS + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_INSP_FEE + "</b></font></td>");
			Response.Write("<td width='10%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_MATERIAL_VALUE + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>&nbsp</font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C3 + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C10 + "</b></font></td>");
			Response.Write("</tr>");
			conn.Close();
			Response.Write("</table><br>");
			Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='60%'>");
			Response.Write("<tr>");
			Response.Write("<th width='100%' valign='top' align='Center' colspan='3'><font size='2' face='Verdana'>Performance Summary</font></th>");
			Response.Write("</tr>");
			Response.Write("<tr>");
			Response.Write("<th width='45%' valign='top' align='center'><b><font size='1' face='Verdana'>&nbsp</font></b></th>");
			Response.Write("<th width='20%' valign='top' align='right'><b><font size='1' face='Verdana'>No. of IC&nbsp</font></b></th>");
			Response.Write("<th width='35%' valign='top' align='right'><b><font size='1' face='Verdana'>Material Value&nbsp</font></b></th>");
			Response.Write("</tr>");
			if (Convert.ToString(Session["Uname"]) != "")
			{
				str31 = "SELECT decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') RLY_NONRLY,COUNT(*) IC_COUNT ,sum(nvl(C.MATERIAL_VALUE,0)) MATERIAL_VALUE FROM T20_IC A, T13_PO_MASTER B, T22_BILL C WHERE A.CASE_NO=B.CASE_NO AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') ORDER BY decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') Desc";
			}
			else if (Convert.ToString(Session["IE_CD"]) != "")
			{
				str31 = "SELECT decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') RLY_NONRLY,COUNT(*) IC_COUNT ,sum(nvl(C.MATERIAL_VALUE,0)) MATERIAL_VALUE FROM T20_IC A, T13_PO_MASTER B, T22_BILL C WHERE A.CASE_NO=B.CASE_NO AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "' AND  SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') ORDER BY decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') Desc";
			}
			cmd31.CommandText = str31;
			cmd31.Connection = conn;
			conn.Open();
			reader31 = cmd31.ExecuteReader();
			while (reader31.Read())
			{
				Response.Write("<tr>");
				Response.Write("<td width='45%' valign='top' align='Left'><font size='1' face='Verdana'>" + reader31["RLY_NONRLY"].ToString() + "</font></td>");
				Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["IC_COUNT"].ToString() + "&nbsp</font></td>");
				Response.Write("<td width='35%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["MATERIAL_VALUE"].ToString() + "&nbsp</font></td>");
				Response.Write("</tr>");
			}
			conn.Close();
			Response.Write("</table><br>");
			Response.Write("</body></html>");
		}


		//		void RejectionIC()
		//		{
		//			string sql="select T22.BILL_NO, to_char(T22.BILL_DT,'dd/mm/yyyy')BILL_DT,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DT,T20.BK_NO,T20.SET_NO,T09.IE_SNAME,to_char(T20.IC_DT,'dd/mm/yyyy')IC_DT,T22.BILL_AMOUNT from T13_PO_MASTER T13, T22_BILL T22,T20_IC T20, T09_IE T09 where T20.BILL_NO=T22.BILL_NO and T13.CASE_NO=T20.CASE_NO and T20.IE_CD=T09.IE_CD and T20.IC_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy') and T20.IC_TYPE_ID=2 and substr(T13.CASE_NO,1,1)='"+Session["Region"]+"' order by T20.IC_DT,T20.BK_NO,T20.SET_NO";
		//			int ctr =60;
		//			int wSno=0;
		//			string first_page="Y";      
		//			
		//			try
		//			{
		//				OracleCommand cmd=new OracleCommand(sql,conn);
		//				conn.Open();
		//				OracleDataReader reader = cmd.ExecuteReader();
		//				while (reader.Read())
		//				{
		//					if (ctr >59) 
		//					{
		//						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
		//						Response.Write("<tr>");
		//						Response.Write("<td width='100%' colspan='10'>");
		//						if (first_page=="N") 
		//						{Response.Write("<p style = page-break-before:always></p>");}				
		//						else
		//						{first_page="N";}
		//						Response.Write("</td>");Response.Write("</tr>");		
		//						Response.Write("<tr>");
		//						Response.Write("<td width='100%' colspan='10'>");
		//						Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
		//						Response.Write("<H5 align='center'><font face='Verdana'>Rejection IC's for the Period of: "+wFrmDt+" TO "+wToDt+"</font><br></p>");
		//						Response.Write("</td>");
		//						Response.Write("</tr>");
		//						Response.Write("<tr>");
		//						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
		//						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Book No.</font></b></th>");
		//						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Set No.</font></b></th>");
		//						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IC Date</font></b></th>");
		//						Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
		//						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
		//						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill Date</font></b></th>");
		//						Response.Write("<th width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>Bill Amount&nbsp&nbsp</font></b></th>");
		//						Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>PO NO.</font></b></th>");
		//						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>PO Date</font></b></th>");
		//						Response.Write("</tr></font>");
		//						ctr =6;
		//					};
		//					wSno = wSno+1;
		//					Response.Write("<tr>");
		//					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"+wSno+"</td>");
		//					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["BK_NO"]);Response.Write("</td>");
		//					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["SET_NO"]);Response.Write("</td>");
		//					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["IC_DT"]);Response.Write("</td>");
		//					Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["IE_SNAME"]);Response.Write("</td>");
		//					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["BILL_NO"]);Response.Write("</td>");
		//					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["BILL_DT"]);Response.Write("</td>");
		//					Response.Write("<td width='12%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["BILL_AMOUNT"]);Response.Write("&nbsp&nbsp</td>");
		//					Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["PO_NO"]);Response.Write("</td>");
		//					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["PO_DT"]);Response.Write("</td>");
		//					Response.Write("</tr>");
		//					ctr=ctr+1;
		//					
		//				};
		//
		//				Response.Write("</table>");
		//			}
		//			catch(Exception ex)
		//			{
		//				string str;
		//				str = ex.Message;
		//				string str1=str.Replace("\n","");
		//				Response.Redirect(("Error_Form.aspx?err=" + str1));
		//			}
		//			finally
		//			{
		//				conn.Close();
		//			}
		//		
		//		}

		void cluster_performance_expanded()
		{
			//			int ctr =60;
			//			string first_page="Y";      
			Response.Write("<html><body>");
			Response.Write("<br><br><p align=center><font size='3' face='Verdana'><b><u>Cluster Performance For The Period: " + wFrmDt + " To " + wToDt + "  (" + wRegion + ")</u></b></font></p><br>");
			//string str="SELECT ('Rejections Issued by I.E During The Month --> '||COUNT(*)) REJECTION FROM t20_ic WHERE ic_type_id=2 AND SUBSTR(case_no,1,1)='"+Session["Region"].ToString()+"' AND bill_no in (Select bill_no from t22_bill where TO_CHAR(bill_dt,'yyyymm')='"+wYrMth+"' AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			string str="";
			//			if(Convert.ToString(Session["Uname"])!="")
			//			{
			//				str="SELECT ('Rejections Issued by I.E During The Period --> '||COUNT(*)) REJECTION FROM t20_ic WHERE ic_type_id=2 AND SUBSTR(case_no,1,1)='"+Session["Region"].ToString()+"' AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) and SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			}
			//			else if(Convert.ToString(Session["IE_CD"])!="")
			//			{
			//				str="SELECT ('Rejections Issued by I.E During The Period --> '||COUNT(*)) REJECTION FROM t20_ic WHERE ic_type_id=2 AND IE_CD='"+Convert.ToString(Session["IE_CD"])+"' AND SUBSTR(case_no,1,1)='"+Session["Region"].ToString()+"' AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) and SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			}
			//			OracleCommand cmd = new OracleCommand(str, conn);
			//			conn.Open();
			//			string reader=Convert.ToString(cmd.ExecuteScalar());
			//			
			//			if(reader.Length>0)
			//			{
			//				Response.Write("<font size='2' face='Verdana'>"+reader+"</font><br>");
			//			}
			//			
			//			conn.Close();
			//			
			//			//string str1="SELECT COUNT(*) FROM t20_ic WHERE bill_no in (Select bill_no from t22_bill where TO_CHAR(bill_dt,'yyyymm')='"+wYrMth+"' AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			string str1="";
			//			if(Convert.ToString(Session["Uname"])!="")
			//			{
			//				str1="SELECT COUNT(*) FROM t20_ic WHERE bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			}
			//			else if(Convert.ToString(Session["IE_CD"])!="")
			//			{
			//				str1="SELECT COUNT(*) FROM t20_ic WHERE IE_CD='"+Convert.ToString(Session["IE_CD"])+"' and bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			}
			//			
			//			OracleCommand cmd1 = new OracleCommand(str1, conn);
			//			conn.Open();
			//			string reader1=Convert.ToString(cmd1.ExecuteScalar());
			//			
			//			if(reader1.Length>0)
			//			{
			//				Response.Write("<font size='2' face='Verdana'>No. Of IC's: -->" +reader1+"</font><br>");
			//			}
			//			
			//			conn.Close();
			//
			//			//string str2="SELECT ('Calls Attended within 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (first_insp_dt - call_dt <= 7 ) AND bill_no in (Select bill_no from t22_bill where TO_CHAR(bill_dt,'yyyymm')='"+wYrMth+"' AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			string str2="";
			//			if(Convert.ToString(Session["Uname"])!="")
			//			{
			//				str2="SELECT ('Calls Attended within 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) <= 7 AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			}
			//			else if(Convert.ToString(Session["IE_CD"])!="")
			//			{
			//				str2="SELECT ('Calls Attended within 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) <= 7 and IE_CD='"+Convert.ToString(Session["IE_CD"])+"' AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			}
			//			
			//						
			//			OracleCommand cmd2 = new OracleCommand(str2, conn);
			//			conn.Open();
			//			string reader2=Convert.ToString(cmd2.ExecuteScalar());

			//			if(reader2.Length>0)
			//			{
			//				Response.Write("<font size='2' face='Verdana'>"+reader2+"</font><br>");
			//			}
			//			
			//			conn.Close();

			//string str3="SELECT ('Calls Attended Beyond 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (first_insp_dt - call_dt > 7 ) AND bill_no in (Select bill_no from t22_bill where TO_CHAR(bill_dt,'yyyymm')='"+wYrMth+"' AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			string str3="";
			//			if(Convert.ToString(Session["Uname"])!="")
			//			{
			//				str3="SELECT ('Calls Attended Beyond 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (first_insp_dt - call_dt > 7 ) AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			}
			//			else if(Convert.ToString(Session["IE_CD"])!="")
			//			{
			//				str3="SELECT ('Calls Attended Beyond 7 Days -->'||COUNT(*))CALLS_WITHIN_7 FROM t20_ic WHERE (first_insp_dt - call_dt > 7 ) and IE_CD='"+Convert.ToString(Session["IE_CD"])+"' AND bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND SUBSTR(bill_no,1,1)='"+Session["Region"].ToString()+"')";
			//			}
			//			
			//			OracleCommand cmd3 = new OracleCommand(str3, conn);
			//			conn.Open();
			//			string reader3=Convert.ToString(cmd3.ExecuteScalar());
			//			
			//			if(reader3.Length>0)
			//			{
			//				Response.Write("<font size='2' face='Verdana'>"+reader3+"</font><br>");
			//			}
			//			conn.Close();
			Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
			Response.Write("<tr>");
			Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Dept</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>Total Calls</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Calls Cancelled</font></b></th>");
			Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>No. of IC</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Calls Attended Within 7 Days.</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Calls Attended Beyond 7 Days.</font></b></th>");
			Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>Rejections</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Insp. Fee</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Material Value</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Average Fee</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>No. Of IC Issued after 1 days of Last Inspection date.</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>IC's Submitted beyond 7 Days after Issue of IC.</font></b></th>");
			Response.Write("</tr></font>");
			string str31 = "";
			if (Convert.ToString(Session["Uname"]) != "")
			{
				str31 = "Select CLUSTER_NAME,DEPT,sum(C3)C3,sum(C7)C7,sum(CM7)CM7,sum(C10)C10,sum(C0)C0,sum(INSP_FEE)INSP_FEE,sum(MATERIAL_VALUE)MATERIAL_VALUE,round(decode(sum(C0),0,0,sum(INSP_FEE)/sum(C0)),2)AVERAGE_FEE,sum(CALLS) CALLS,sum(CALL_CANCEL) CALL_CANCEL,sum(REJECTIONS) REJECTIONS from  (" +
					"SELECT CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,(COUNT(*))C3, 0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T17_CALL_REGISTER D, T20_IC A, T99_CLUSTER_MASTER B, T22_BILL C WHERE D.CASE_NO=A.CASE_NO AND D.CALL_RECV_DT=A.CALL_RECV_DT AND D.CALL_SNO =A.CALL_SNO AND D.CLUSTER_CODE=B.CLUSTER_CODE AND C.BILL_NO=A.BILL_NO AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND (nvl(IC_DT,'31-Dec-9999')-nvl(LAST_INSP_DT,'01-Jan-2005'))>1  AND B.region_code='" + Session["Region"].ToString() + "' GROUP BY CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"Select CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,(count(*)) C7,0 CM7,0 C10,0 C0,0 INSP_FEE, 0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T17_CALL_REGISTER D,T20_IC A, T99_CLUSTER_MASTER B, T22_BILL C  where D.CASE_NO=A.CASE_NO AND D.CALL_RECV_DT=A.CALL_RECV_DT AND D.CALL_SNO =A.CALL_SNO AND D.CLUSTER_CODE=B.CLUSTER_CODE AND C.BILL_NO=A.BILL_NO and (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) <= 7  and B.region_code='" + Session["Region"].ToString() + "'  group by CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"Select CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,(count(*)) CM7,0 C10,0 C0,0 INSP_FEE, 0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T17_CALL_REGISTER D,T20_IC A, T99_CLUSTER_MASTER B, T22_BILL C  where D.CASE_NO=A.CASE_NO AND D.CALL_RECV_DT=A.CALL_RECV_DT AND D.CALL_SNO= A.CALL_SNO AND D.CLUSTER_CODE=B.CLUSTER_CODE AND C.BILL_NO=A.BILL_NO and (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) > 7  and B.region_code='" + Session["Region"].ToString() + "'  group by CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,(COUNT(*))C10,0 C0, 0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T17_CALL_REGISTER D,T20_IC A, T99_CLUSTER_MASTER B, T22_BILL C  WHERE D.CASE_NO=A.CASE_NO AND D.CALL_RECV_DT=A.CALL_RECV_DT AND D.CALL_SNO= A.CALL_SNO AND D.CLUSTER_CODE=B.CLUSTER_CODE AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND (nvl(IC_SUBMIT_DT,'31-Dec-9999') - nvl(IC_DT,'01-Jan-2005'))>7  AND B.region_code='" + Session["Region"].ToString() + "' GROUP BY CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,(COUNT(*)) C0,sum(nvl(C.INSP_FEE,0)) INSP_FEE,sum(nvl(C.MATERIAL_VALUE,0)) MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T17_CALL_REGISTER D,T20_IC A, T99_CLUSTER_MASTER B, T22_BILL C  WHERE D.CASE_NO=A.CASE_NO AND D.CALL_RECV_DT=A.CALL_RECV_DT AND D.CALL_SNO= A.CALL_SNO AND D.CLUSTER_CODE=B.CLUSTER_CODE AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND B.region_code='" + Session["Region"].ToString() + "' GROUP BY CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,COUNT(*) CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T17_CALL_REGISTER A, T99_CLUSTER_MASTER B WHERE A.CLUSTER_CODE=B.CLUSTER_CODE AND (A.CALL_MARK_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND B.region_code='" + Session["Region"].ToString() + "' GROUP BY CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT CLUSTER_NAME,decode(C.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,COUNT(*)  CALL_CANCEL,0 REJECTIONS FROM T19_CALL_CANCEL A, T17_CALL_REGISTER B, T99_CLUSTER_MASTER C WHERE A.CASE_NO=B.CASE_NO and A.CALL_RECV_DT=B.CALL_RECV_DT and A.CALL_SNO=B.CALL_SNO and B.CLUSTER_CODE=C.CLUSTER_CODE AND (A.CANCEL_DATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND C.region_code='" + Session["Region"].ToString() + "' GROUP BY CLUSTER_NAME,decode(C.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,COUNT(*) REJECTIONS FROM T17_CALL_REGISTER D,T20_IC A, T99_CLUSTER_MASTER B WHERE D.CASE_NO=A.CASE_NO and D.CALL_RECV_DT=A.CALL_RECV_DT and D.CALL_SNO=A.CALL_SNO AND D.CLUSTER_CODE=B.CLUSTER_CODE AND A.ic_type_id=2 AND  B.region_code='" + Session["Region"].ToString() + "' AND A.bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')  GROUP BY CLUSTER_NAME,decode(B.DEPARTMENT_NAME,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others')) group by CLUSTER_NAME,DEPT order by DEPT,CLUSTER_NAME";
			}
			else if (Convert.ToString(Session["IE_CD"]) != "")
			{
				str31 = "Select IE_NAME,DEPT,sum(C3)C3,sum(C7)C7,sum(CM7)CM7,sum(C10)C10,sum(C0)C0,sum(INSP_FEE)INSP_FEE,sum(MATERIAL_VALUE)MATERIAL_VALUE,round(decode(sum(C0),0,0,sum(INSP_FEE)/sum(C0)),2)AVERAGE_FEE,sum(CALLS) CALLS,sum(CALL_CANCEL) CALL_CANCEL,sum(REJECTIONS) REJECTIONS from  (" +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,(COUNT(*))C3, 0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C WHERE A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND (nvl(IC_DT,'31-Dec-9999')-nvl(LAST_INSP_DT,'01-Jan-2005'))>1 and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"Select IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,(count(*)) C7,0 CM7,0 C10,0 C0,0 INSP_FEE, 0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  where A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO and (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) <= 7 and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  and substr(A.case_no,1,1)='" + Session["Region"].ToString() + "'  group by IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"Select IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,(count(*)) CM7,0 C10,0 C0,0 INSP_FEE, 0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  where A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO and (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) > 7 and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  and substr(A.case_no,1,1)='" + Session["Region"].ToString() + "'  group by IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,(COUNT(*))C10,0 C0, 0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  WHERE A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND (nvl(IC_SUBMIT_DT,'31-Dec-9999') - nvl(IC_DT,'01-Jan-2005'))>7 and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,(COUNT(*)) C0,sum(nvl(C.INSP_FEE,0)) INSP_FEE,sum(nvl(C.MATERIAL_VALUE,0)) MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T20_IC A, T09_IE B, T22_BILL C  WHERE A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,COUNT(*) CALLS,0 CALL_CANCEL,0 REJECTIONS FROM T17_CALL_REGISTER A, T09_IE B WHERE A.IE_CD=B.IE_CD AND (A.CALL_MARK_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  and A.REGION_CODE='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(C.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,COUNT(*)  CALL_CANCEL,0 REJECTIONS FROM T19_CALL_CANCEL A, T17_CALL_REGISTER B, T09_IE C WHERE A.CASE_NO=B.CASE_NO and A.CALL_RECV_DT=B.CALL_RECV_DT and A.CALL_SNO=B.CALL_SNO and B.IE_CD=C.IE_CD AND (A.CANCEL_DATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and B.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "' AND  SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,decode(C.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') union all " +
					"SELECT IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,0 C3,0 C7,0 CM7,0 C10,0 C0,0 INSP_FEE,0 MATERIAL_VALUE,0 CALLS,0 CALL_CANCEL,COUNT(*) REJECTIONS FROM T20_IC A, T09_IE B WHERE A.IE_CD=B.IE_CD AND A.ic_type_id=2 and A.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "'  AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' AND A.bill_no in (Select bill_no from t22_bill where (bill_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and SUBSTR(bill_no,1,1)='" + Session["Region"].ToString() + "')  GROUP BY IE_NAME,decode(B.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others')) group by IE_NAME,DEPT order by IE_NAME";
			}
			OracleCommand cmd31 = new OracleCommand(str31, conn);
			conn.Open();
			OracleDataReader reader31 = cmd31.ExecuteReader();
			int t_C0 = 0, t_C3 = 0, t_C7 = 0, t_CM7 = 0, t_C10 = 0, t_CALLS = 0, t_CALL_CANCEL = 0, t_REJECTIONS = 0;
			double t_INSP_FEE = 0, t_MATERIAL_VALUE = 0;
			while (reader31.Read())
			{
				Response.Write("<tr>");
				Response.Write("<td width='15%' valign='top' align='Left'><font size='1' face='Verdana'>" + reader31["CLUSTER_NAME"].ToString() + "</font></td>");
				Response.Write("<td width='15%' valign='top' align='center'><font size='1' face='Verdana'>" + reader31["DEPT"].ToString() + "</font></td>");
				Response.Write("<td width='7%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["CALLS"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["CALL_CANCEL"].ToString() + "</font></td>");
				Response.Write("<td width='6%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C0"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C7"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["CM7"].ToString() + "</font></td>");
				Response.Write("<td width='6%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["REJECTIONS"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["INSP_FEE"].ToString() + "</font></td>");
				Response.Write("<td width='10%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["MATERIAL_VALUE"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["AVERAGE_FEE"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C3"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C10"].ToString() + "</font></td>");
				Response.Write("</tr>");
				t_C0 = t_C0 + Convert.ToInt16(reader31["C0"]);
				t_C3 = t_C3 + Convert.ToInt16(reader31["C3"]);
				t_C7 = t_C7 + Convert.ToInt16(reader31["C7"]);
				t_CM7 = t_CM7 + Convert.ToInt16(reader31["CM7"]);
				t_C10 = t_C10 + Convert.ToInt16(reader31["C10"]);
				t_INSP_FEE = t_INSP_FEE + Convert.ToDouble(reader31["INSP_FEE"]);
				t_MATERIAL_VALUE = t_MATERIAL_VALUE + Convert.ToDouble(reader31["MATERIAL_VALUE"]);
				t_CALLS = t_CALLS + Convert.ToInt16(reader31["CALLS"]);
				t_CALL_CANCEL = t_CALL_CANCEL + Convert.ToInt16(reader31["CALL_CANCEL"]);
				t_REJECTIONS = t_REJECTIONS + Convert.ToInt16(reader31["REJECTIONS"]);
			}
			Response.Write("<tr>");
			Response.Write("<td width='15%' valign='top' align='Left' colspan='2'><font size='1' face='Verdana'><b>Totals</b></font></td>");
			Response.Write("<td width='7%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_CALLS + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_CALL_CANCEL + "</b></font></td>");
			Response.Write("<td width='6%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C0 + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C7 + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_CM7 + "</b></font></td>");
			Response.Write("<td width='6%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_REJECTIONS + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_INSP_FEE + "</b></font></td>");
			Response.Write("<td width='10%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_MATERIAL_VALUE + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>&nbsp</font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C3 + "</b></font></td>");
			Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C10 + "</b></font></td>");
			Response.Write("</tr>");
			conn.Close();
			Response.Write("</table><br>");
			//			Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='60%'>");
			//			Response.Write("<tr>");
			//			Response.Write("<th width='100%' valign='top' align='Center' colspan='3'><font size='2' face='Verdana'>Performance Summary</font></th>");
			//			Response.Write("</tr>");
			//			Response.Write("<tr>");
			//			Response.Write("<th width='45%' valign='top' align='center'><b><font size='1' face='Verdana'>&nbsp</font></b></th>");
			//			Response.Write("<th width='20%' valign='top' align='right'><b><font size='1' face='Verdana'>No. of IC&nbsp</font></b></th>");
			//			Response.Write("<th width='35%' valign='top' align='right'><b><font size='1' face='Verdana'>Material Value&nbsp</font></b></th>");
			//			Response.Write("</tr>");
			//			if(Convert.ToString(Session["Uname"])!="")
			//			{
			//				str31="SELECT decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') RLY_NONRLY,COUNT(*) IC_COUNT ,sum(nvl(C.MATERIAL_VALUE,0)) MATERIAL_VALUE FROM T20_IC A, T13_PO_MASTER B, T22_BILL C WHERE A.CASE_NO=B.CASE_NO AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND SUBSTR(A.case_no,1,1)='"+Session["Region"].ToString()+"' GROUP BY decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') ORDER BY decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') Desc";
			//			}
			//			else if(Convert.ToString(Session["IE_CD"])!="")
			//			{
			//				str31="SELECT decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') RLY_NONRLY,COUNT(*) IC_COUNT ,sum(nvl(C.MATERIAL_VALUE,0)) MATERIAL_VALUE FROM T20_IC A, T13_PO_MASTER B, T22_BILL C WHERE A.CASE_NO=B.CASE_NO AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND A.IE_CD='"+Convert.ToString(Session["IE_CD"])+"' AND  SUBSTR(A.case_no,1,1)='"+Session["Region"].ToString()+"' GROUP BY decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') ORDER BY decode(B.RLY_NONRLY,'R','Railway Inspections','Non-Railway Inspections') Desc";
			//			}
			//			cmd31.CommandText=str31;
			//			cmd31.Connection=conn;
			//			conn.Open();
			//			reader31=cmd31.ExecuteReader();
			//			while(reader31.Read())
			//			{
			//				Response.Write("<tr>");
			//				Response.Write("<td width='45%' valign='top' align='Left'><font size='1' face='Verdana'>"+reader31["RLY_NONRLY"].ToString()+"</font></td>");
			//				Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'>"+reader31["IC_COUNT"].ToString()+"&nbsp</font></td>");
			//				Response.Write("<td width='35%' valign='top' align='right'><font size='1' face='Verdana'>"+reader31["MATERIAL_VALUE"].ToString()+"&nbsp</font></td>");
			//				Response.Write("</tr>");
			//			}
			//			conn.Close();
			//			Response.Write("</table><br>");
			Response.Write("</body></html>");
		}

		void ie_calls_attended_2days()
		{
			Response.Write("<html><body>");
			Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='60%'>");
			Response.Write("<tr>");
			Response.Write("<td width='100%' colspan='5'>");
			Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
			Response.Write("<H5 align='center'><font face='Verdana'>SUMMARY OF IE WISE CALL ATTENDED WITHIN 2 & 5 DAYS, From " + wFrmDt + " To " + wToDt + "</font></p>");
			Response.Write("</td>");
			Response.Write("</tr>");
			Response.Write("<tr>");
			Response.Write("<th width='40%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
			Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Total Calls</font></b></th>");
			Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Calls Attended Within 2 Days.</font></b></th>");
			Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Calls Attended Within 5 Days.</font></b></th>");
			Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>No. of IC</font></b></th>");
			Response.Write("</tr></font>");
			string str31 = "";

			str31 = "Select IE_NAME,sum(C2)C2,sum(C5)C5,SUM(C0) C0, sum(CALLS) CALLS from  (" +
				"Select IE_NAME,(count(*)) C2,0 C5,0 C0,0 CALLS FROM T20_IC A, T09_IE B, T22_BILL C  where A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO and (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) <= 2  and substr(A.case_no,1,1)='" + Session["Region"].ToString() + "'  group by IE_NAME union all " +
				"Select IE_NAME,0 C2,(count(*)) C5,0 C0,0 CALLS FROM T20_IC A, T09_IE B, T22_BILL C  where A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO and (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) <= 5  and substr(A.case_no,1,1)='" + Session["Region"].ToString() + "'  group by IE_NAME union all " +
				"SELECT IE_NAME,0 C2,0 C5,(COUNT(*)) C0,0 CALLS FROM T20_IC A, T09_IE B, T22_BILL C  WHERE A.IE_CD=B.IE_CD AND C.BILL_NO=A.BILL_NO  AND (C.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND SUBSTR(A.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME union all " +
				"SELECT IE_NAME,0 C2,0 C5,0 C0,COUNT(*) CALLS FROM T17_CALL_REGISTER A, T09_IE B WHERE A.IE_CD=B.IE_CD AND (A.CALL_MARK_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND A.REGION_CODE='" + Session["Region"].ToString() + "' GROUP BY IE_NAME) group by IE_NAME order by IE_NAME";

			OracleCommand cmd31 = new OracleCommand(str31, conn);
			conn.Open();
			OracleDataReader reader31 = cmd31.ExecuteReader();
			int t_C2 = 0, t_CALLS = 0, t_C0 = 0, t_C5 = 0;

			while (reader31.Read())
			{
				Response.Write("<tr>");
				Response.Write("<td width='40%' valign='top' align='Left'><font size='1' face='Verdana'>" + reader31["IE_NAME"].ToString() + "</font></td>");
				Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["CALLS"].ToString() + "</font></td>");
				Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C2"].ToString() + "</font></td>");
				Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C5"].ToString() + "</font></td>");
				Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader31["C0"].ToString() + "</font></td>");
				Response.Write("</tr>");
				t_C2 = t_C2 + Convert.ToInt16(reader31["C2"]);
				t_C5 = t_C5 + Convert.ToInt16(reader31["C5"]);
				t_C0 = t_C0 + Convert.ToInt16(reader31["C0"]);
				t_CALLS = t_CALLS + Convert.ToInt16(reader31["CALLS"]);

			}
			Response.Write("<tr>");
			Response.Write("<td width='40%' valign='top' align='right'><font size='1' face='Verdana'><b>Totals</b></font></td>");
			Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_CALLS + "</b></font></td>");
			Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C2 + "</b></font></td>");
			Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C5 + "</b></font></td>");
			Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'><b>" + t_C0 + "</b></font></td>");
			Response.Write("</tr>");
			conn.Close();
			Response.Write("</table><br>");

			Response.Write("</body></html>");
		}

		void RejectionIC()
		{
			string sql = "select T22.BILL_NO, to_char(T22.BILL_DT,'dd/mm/yyyy')BILL_DT,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DT,T13.RLY_CD,T20.BK_NO,T20.SET_NO,T20.REASON_REJECT,T09.IE_SNAME,V05.Vendor,to_char(T20.IC_DT,'dd/mm/yyyy')IC_DT,T22.BILL_AMOUNT, T23.ITEM_DESC, T18.QTY_TO_INSP, T18.QTY_REJECTED from T13_PO_MASTER T13, T22_BILL T22,T20_IC T20, T09_IE T09,V05_VENDOR V05,T23_BILL_ITEMS T23, T18_CALL_DETAILS T18 where T20.BILL_NO=T22.BILL_NO and T13.CASE_NO=T20.CASE_NO and T13.VEND_CD=V05.VEND_CD and T20.IE_CD=T09.IE_CD and T22.BILL_NO=T23.BILL_NO and T20.CASE_NO=T18.CASE_NO and T20.CALL_RECV_DT=T18.CALL_RECV_DT and T20.CALL_SNO=T18.CALL_SNO and T23.ITEM_SRNO=T18.ITEM_SRNO_PO  and T20.IC_TYPE_ID=2 and substr(T13.CASE_NO,1,1)='" + Session["Region"] + "' ";
			int wSno = 0;
			string first_page = "Y";
			if (rdbBillDt.Checked == true)
			{
				sql = sql + " and T22.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') order by V05.Vendor,T22.BILL_DT";
			}
			else if (rdbICDT.Checked == true)
			{
				sql = sql + " and T20.IC_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') order by V05.Vendor,T20.IC_DT";
			}


			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='13'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='13'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Rejection IC's for the Period : " + wFrmDt + " TO " + wToDt + "&nbsp&nbsp(Report Sorted on Vendor)</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Book No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Set No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IC Date</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Vendor</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Railway</font></b></th>");
				//Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				//Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Bill Date</font></b></th>");
				//Response.Write("<th width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>Bill Amount</font></b></th>");
				Response.Write("<th width='11%' valign='top'><b><font size='1' face='Verdana'>PO NO.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>PO Date</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Reason For Rejection</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Qty Offered</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Qty Rejected</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Item</font></b></th>");

				Response.Write("</tr></font>");

				string wBILL_NO = "";
				while (reader.Read())
				{
					if (wBILL_NO == reader["BILL_NO"].ToString())
					{
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='center' colspan=10> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_TO_INSP"]); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
						Response.Write("</tr>");
					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IC_DT"]); Response.Write("</td>");
						Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_SNAME"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["RLY_CD"]); Response.Write("</td>");
						//Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["BILL_NO"]);Response.Write("</td>");
						//Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["BILL_DT"]);Response.Write("</td>");
						//Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["BILL_AMOUNT"]);Response.Write("&nbsp&nbsp</td>");
						Response.Write("<td width='11%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DT"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["REASON_REJECT"]); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_TO_INSP"]); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
						Response.Write("</tr>");
						wBILL_NO = reader["BILL_NO"].ToString();
					}
				};

				Response.Write("</table>");
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

		void ReInspectionIC_Clientwise()
		{
			string sql = "select T22.BILL_NO, to_char(T22.BILL_DT,'dd/mm/yyyy')BILL_DT,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DT,T13.CASE_NO,T13.RLY_CD,T20.BK_NO,T20.SET_NO,T09.IE_SNAME,V05.Vendor,T20.IC_NO,to_char(T20.IC_DT,'dd/mm/yyyy')IC_DT,T22.BILL_AMOUNT,T22.INSP_FEE, T22.SERVICE_TAX from T13_PO_MASTER T13, T22_BILL T22,T20_IC T20, T09_IE T09,V05_VENDOR V05 where T20.BILL_NO=T22.BILL_NO and T13.CASE_NO=T20.CASE_NO and T13.VEND_CD=V05.VEND_CD and T20.IE_CD=T09.IE_CD and T20.IC_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and T20.IC_TYPE_ID=4 and substr(T13.CASE_NO,1,1)='" + Session["Region"] + "' order by T13.RLY_CD,V05.Vendor,T20.IC_DT";
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataAdapter da = new OracleDataAdapter(sql, conn);
				DataSet dsP = new DataSet();
				da.SelectCommand = cmd;
				da.Fill(dsP, "Table");

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='14'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='14'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Re-Inspection IC's for the Period : " + wFrmDt + " TO " + wToDt + "&nbsp&nbsp(Report Sorted on Vendor)</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Book No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Set No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IC No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IC Date</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Vendor</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Client</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Bill Date</font></b></th>");
				Response.Write("<th width='11%' valign='top'><b><font size='1' face='Verdana'>Insp Fee</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Serv Tax</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill Amount</font></b></th>");

				Response.Write("</tr></font>");

				string wRLY_CD = "";
				int wSubINSP_FEE = 0, wSubSERV_TAX = 0, wSubBILL_AMT = 0;
				int wTINSP_FEE = 0, wTSERV_TAX = 0, wTBILL_AMT = 0;
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BK_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["SET_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["CASE_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["IC_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["IC_DT"].ToString()); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["IE_SNAME"].ToString()); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["VENDOR"].ToString()); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RLY_CD"].ToString()); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BILL_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BILL_DT"].ToString()); Response.Write("</td>");
					Response.Write("<td width='11%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["INSP_FEE"].ToString()); Response.Write("</td>");
					wSubINSP_FEE = wSubINSP_FEE + Convert.ToInt32(dsP.Tables[0].Rows[i]["INSP_FEE"].ToString());
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["SERVICE_TAX"]); Response.Write("</td>");
					wSubSERV_TAX = wSubSERV_TAX + Convert.ToInt32(dsP.Tables[0].Rows[i]["SERVICE_TAX"].ToString());
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BILL_AMOUNT"]); Response.Write("</td>");
					wSubBILL_AMT = wSubBILL_AMT + Convert.ToInt32(dsP.Tables[0].Rows[i]["BILL_AMOUNT"].ToString());
					Response.Write("</tr>");
					wRLY_CD = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
					if (i <= dsP.Tables[0].Rows.Count - 2 && wRLY_CD != dsP.Tables[0].Rows[i + 1]["RLY_CD"].ToString())
					{
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='center' colspan=11><B> <font size='1' face='Verdana'>"); Response.Write("Total of: " + dsP.Tables[0].Rows[i]["RLY_CD"].ToString()); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wSubINSP_FEE); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'><B> <font size='1' face='Verdana'>"); Response.Write(wSubSERV_TAX); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wSubBILL_AMT); Response.Write("</td>");
						Response.Write("</tr>");
						wTINSP_FEE = wTINSP_FEE + wSubINSP_FEE;
						wTSERV_TAX = wTSERV_TAX + wSubSERV_TAX;
						wTBILL_AMT = wTBILL_AMT + wSubBILL_AMT;


						wSubINSP_FEE = 0; wSubSERV_TAX = 0; wSubBILL_AMT = 0;

					}
					else if (i == dsP.Tables[0].Rows.Count - 1)
					{
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='center' colspan=11><B> <font size='1' face='Verdana'>"); Response.Write("Total of: " + dsP.Tables[0].Rows[i]["RLY_CD"].ToString()); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wSubINSP_FEE); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'><B> <font size='1' face='Verdana'>"); Response.Write(wSubSERV_TAX); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wSubBILL_AMT); Response.Write("</td>");
						Response.Write("</tr>");
						wTINSP_FEE = wTINSP_FEE + wSubINSP_FEE;
						wTSERV_TAX = wTSERV_TAX + wSubSERV_TAX;
						wTBILL_AMT = wTBILL_AMT + wSubBILL_AMT;
						wSubINSP_FEE = 0; wSubSERV_TAX = 0; wSubBILL_AMT = 0;
					}

				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='center' colspan=11><B> <font size='1' face='Verdana'>"); Response.Write("Grand Total"); Response.Write("</td>");
				Response.Write("<td width='7%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wTINSP_FEE); Response.Write("</td>");
				Response.Write("<td width='7%' valign='top' align='right'><B> <font size='1' face='Verdana'>"); Response.Write(wTSERV_TAX); Response.Write("</td>");
				Response.Write("<td width='15%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wTBILL_AMT); Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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

		void ReInspectionIC_BPOwise()
		{
			string sql = "select  T22.BPO_CD||'-'||T22.BPO_NAME||','||T22.BPO_ADD||','||T22.BPO_CITY BPO,T22.BPO_CD,T22.BILL_NO, to_char(T22.BILL_DT,'dd/mm/yyyy')BILL_DT,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DT,T13.CASE_NO,T13.RLY_CD,T20.BK_NO,T20.SET_NO,T09.IE_SNAME,V05.Vendor,T20.IC_NO,to_char(T20.IC_DT,'dd/mm/yyyy')IC_DT,T22.BILL_AMOUNT,T22.INSP_FEE, T22.SERVICE_TAX, T22.SERVICE_TAX+T22.EDU_CESS+T22.SHE_CESS+T22.SWACHH_BHARAT_CESS+T22.KRISHI_KALYAN_CESS TAX from T13_PO_MASTER T13, V22_BILL T22,T20_IC T20, T09_IE T09,V05_VENDOR V05 where T20.BILL_NO=T22.BILL_NO and T13.CASE_NO=T20.CASE_NO and T13.VEND_CD=V05.VEND_CD and T20.IE_CD=T09.IE_CD and T20.IC_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and T20.IC_TYPE_ID=4 and substr(T13.CASE_NO,1,1)='" + Session["Region"] + "' order by T22.BPO_CD,T20.IC_DT";
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataAdapter da = new OracleDataAdapter(sql, conn);
				DataSet dsP = new DataSet();
				da.SelectCommand = cmd;
				da.Fill(dsP, "Table");

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='15'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='15'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Re-Inspection IC's for the Period : " + wFrmDt + " TO " + wToDt + "&nbsp&nbsp(Report Sorted on Vendor)</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Book No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Set No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IC No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IC Date</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Vendor</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Client</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BPO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Bill Date</font></b></th>");
				Response.Write("<th width='11%' valign='top'><b><font size='1' face='Verdana'>Insp Fee</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Tax</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill Amount</font></b></th>");

				Response.Write("</tr></font>");

				string wBPO_CD = "";
				int wSubINSP_FEE = 0, wSubSERV_TAX = 0, wSubBILL_AMT = 0;
				int wTINSP_FEE = 0, wTSERV_TAX = 0, wTBILL_AMT = 0;
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BK_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["SET_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["CASE_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["IC_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["IC_DT"].ToString()); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["IE_SNAME"].ToString()); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["VENDOR"].ToString()); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RLY_CD"].ToString()); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BPO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BILL_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BILL_DT"].ToString()); Response.Write("</td>");
					Response.Write("<td width='11%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["INSP_FEE"].ToString()); Response.Write("</td>");
					wSubINSP_FEE = wSubINSP_FEE + Convert.ToInt32(dsP.Tables[0].Rows[i]["INSP_FEE"].ToString());
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["SERVICE_TAX"]); Response.Write("</td>");
					wSubSERV_TAX = wSubSERV_TAX + Convert.ToInt32(dsP.Tables[0].Rows[i]["TAX"].ToString());
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BILL_AMOUNT"]); Response.Write("</td>");
					wSubBILL_AMT = wSubBILL_AMT + Convert.ToInt32(dsP.Tables[0].Rows[i]["BILL_AMOUNT"].ToString());
					Response.Write("</tr>");
					wBPO_CD = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
					if (i <= dsP.Tables[0].Rows.Count - 2 && Convert.ToInt32(wBPO_CD) != Convert.ToInt32(dsP.Tables[0].Rows[i + 1]["BPO_CD"].ToString()))
					{
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='center' colspan=12><B> <font size='1' face='Verdana'>"); Response.Write("Total of: " + dsP.Tables[0].Rows[i]["BPO"].ToString()); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wSubINSP_FEE); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'><B> <font size='1' face='Verdana'>"); Response.Write(wSubSERV_TAX); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wSubBILL_AMT); Response.Write("</td>");
						Response.Write("</tr>");
						wTINSP_FEE = wTINSP_FEE + wSubINSP_FEE;
						wTSERV_TAX = wTSERV_TAX + wSubSERV_TAX;
						wTBILL_AMT = wTBILL_AMT + wSubBILL_AMT;
						wSubINSP_FEE = 0; wSubSERV_TAX = 0; wSubBILL_AMT = 0;
						wBPO_CD = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();

					}
					else if (i == dsP.Tables[0].Rows.Count - 1)
					{
						Response.Write("<tr>");
						Response.Write("<td width='10%' valign='top' align='center' colspan=12><B> <font size='1' face='Verdana'>"); Response.Write("Total of: " + dsP.Tables[0].Rows[i]["BPO"].ToString()); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wSubINSP_FEE); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'><B> <font size='1' face='Verdana'>"); Response.Write(wSubSERV_TAX); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wSubBILL_AMT); Response.Write("</td>");
						Response.Write("</tr>");
						wTINSP_FEE = wTINSP_FEE + wSubINSP_FEE;
						wTSERV_TAX = wTSERV_TAX + wSubSERV_TAX;
						wTBILL_AMT = wTBILL_AMT + wSubBILL_AMT;
						wSubINSP_FEE = 0; wSubSERV_TAX = 0; wSubBILL_AMT = 0;
						wBPO_CD = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
					}

				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='center' colspan=12><B> <font size='1' face='Verdana'>"); Response.Write("Grand Total"); Response.Write("</td>");
				Response.Write("<td width='7%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wTINSP_FEE); Response.Write("</td>");
				Response.Write("<td width='7%' valign='top' align='right'><B> <font size='1' face='Verdana'>"); Response.Write(wTSERV_TAX); Response.Write("</td>");
				Response.Write("<td width='15%' valign='top' align='right'> <B><font size='1' face='Verdana'>"); Response.Write(wTBILL_AMT); Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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
		void write_off_amt_statement()
		{
			string sql = "select T22.BILL_NO,to_char(BILL_DT,'dd/mm/yyyy') BILL_DATE,T22.BPO_TYPE,T22.BPO_ORGN, NVL(T22.BILL_AMOUNT,0) BILL_AMOUNT, NVL(T22.WRITE_OFF_AMT,0) WRITE_OFF_AMT from V22_BILL T22, T26_CHEQUE_POSTING T26 where T22.BILL_NO=T26.BILL_NO and NVL(WRITE_OFF_AMT,0)<>0 and T26.POSTING_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and substr(T22.BILL_NO,1,1)='" + Session["Region"].ToString() + "' group by T22.BILL_NO,to_char(BILL_DT,'dd/mm/yyyy') ,T22.BPO_TYPE,T22.BPO_ORGN, NVL(T22.BILL_AMOUNT,0) , NVL(T22.WRITE_OFF_AMT,0) order by BPO_TYPE,BPO_ORGN,NVL(WRITE_OFF_AMT,0) DESC";
			double w_total_write_off = 0;
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='6'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='6'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>Write Off Amount For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='50%' valign='top'><b><font size='1' face='Verdana'>BPO Organisation</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill Date</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Bill Amount</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Write Off Amount</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO_ORGN"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DATE"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'  bgColor='Lavender'> <font size='1' face='Verdana'>"); Response.Write(reader["WRITE_OFF_AMT"]); Response.Write("</td>");
					w_total_write_off = w_total_write_off + Convert.ToDouble(reader["WRITE_OFF_AMT"]);
					Response.Write("</tr>");
					ctr = ctr + 1;

				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='right' colspan=5> <font size='1' face='Verdana'><B>"); Response.Write("Total: "); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_write_off); Response.Write("</B></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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

		void retention_amt_statement()
		{
			string sql = "select T22.BILL_NO,to_char(BILL_DT,'dd/mm/yyyy') BILL_DATE,T22.BPO_TYPE,T22.BPO_ORGN,NVL(T22.BILL_AMOUNT,0) BILL_AMOUNT, NVL(T22.RETENTION_MONEY,0) RETENTION_MONEY, T26.CHQ_NO, to_char(T26.CHQ_DT,'dd/mm/yyyy') CHQ_DATE from V22_BILL T22, T26_CHEQUE_POSTING T26 where T22.BILL_NO=T26.BILL_NO and NVL(RETENTION_MONEY,0)<>0 and T26.POSTING_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and substr(T22.BILL_NO,1,1)='" + Session["Region"].ToString() + "' group by T22.BILL_NO,to_char(BILL_DT,'dd/mm/yyyy') ,T22.BPO_TYPE,T22.BPO_ORGN, NVL(T22.BILL_AMOUNT,0) , NVL(T22.RETENTION_MONEY,0), T26.CHQ_NO, to_char(T26.CHQ_DT,'dd/mm/yyyy') order by BPO_TYPE,BPO_ORGN,BILL_NO, NVL(RETENTION_MONEY,0) DESC";
			double w_total_retention = 0;
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				string wBILL_NO = "";
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='8'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='8'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>Retention Money For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='30%' valign='top'><b><font size='1' face='Verdana'>BPO Organisation</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill Date</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Bill Amount</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Retention Money</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Chq No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Chq Dt.</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};

					if (wBILL_NO == reader["BILL_NO"].ToString())
					{
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'></td>");
						Response.Write("<td width='30%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'  bgColor='Lavender'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_DATE"]); Response.Write("</td>");
						Response.Write("</tr>");

					}
					else
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='30%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO_ORGN"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DATE"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'  bgColor='Lavender'> <font size='1' face='Verdana'>"); Response.Write(reader["RETENTION_MONEY"]); Response.Write("</td>");
						w_total_retention = w_total_retention + Convert.ToDouble(reader["RETENTION_MONEY"]);
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_DATE"]); Response.Write("</td>");
						Response.Write("</tr>");
						ctr = ctr + 1;
						wBILL_NO = reader["BILL_NO"].ToString();
					}
				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='right' colspan=5> <font size='1' face='Verdana'><B>"); Response.Write("Total: "); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_retention); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right' colspan=2> <font size='1' face='Verdana'><B>"); Response.Write(""); Response.Write("</B></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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

		void billing_analysis()
		{
			double T_Bill_Amt = 0;
			int T_Bill_Count = 0;
			Response.Write("<html><body>");
			Response.Write("<br><br><p align=center><font size='3' face='Verdana'><b><u>Billing Analysis For The Period: " + wFrmDt + " To " + wToDt + "  (" + wRegion + ")</u></b></font></p><br>");
			string str = "Select nvl(sum(BILL_AMOUNT),0)VALUE From T22_BILL Where substr(BILL_NO,1,1)='" + Session["Region"].ToString() + "' and (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy'))";
			OracleCommand cmd = new OracleCommand(str, conn);
			conn.Open();
			double totBillAmt = Convert.ToDouble(cmd.ExecuteScalar());
			conn.Close();
			if (totBillAmt > 0)
			{
				str = "Select '< 100' DESCR,nvl(SUM(BILL_AMOUNT),0)VALUE,COUNT(*)NOS,nvl(round(SUM(BILL_AMOUNT)*100/" + totBillAmt + ",2),0)PER_VALUE From T22_BILL,T20_IC Where BILL_AMOUNT < 100 and substr(T22_BILL.BILL_NO,1,1)='" + Session["Region"].ToString() + "' and (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and T22_BILL.BILL_NO=T20_IC.BILL_NO union all " +
					"Select '100-500' DESCR,nvl(SUM(BILL_AMOUNT),0)VALUE,COUNT(*)NOS,nvl(round(SUM(BILL_AMOUNT)*100/" + totBillAmt + ",2),0)PER_VALUE From T22_BILL,T20_IC Where (BILL_AMOUNT Between 100 and 500) and substr(T22_BILL.BILL_NO,1,1)='" + Session["Region"].ToString() + "' and (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and T22_BILL.BILL_NO=T20_IC.BILL_NO union all " +
					"Select '501-1000' DESCR,nvl(SUM(BILL_AMOUNT),0)VALUE,COUNT(*)NOS,nvl(round(SUM(BILL_AMOUNT)*100/" + totBillAmt + ",2),0)PER_VALUE From T22_BILL,T20_IC Where (BILL_AMOUNT Between 501 and 1000) and substr(T22_BILL.BILL_NO,1,1)='" + Session["Region"].ToString() + "' and (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and T22_BILL.BILL_NO=T20_IC.BILL_NO union all " +
					"Select '1001-5000' DESCR,nvl(SUM(BILL_AMOUNT),0)VALUE,COUNT(*)NOS,nvl(round(SUM(BILL_AMOUNT)*100/" + totBillAmt + ",2),0)PER_VALUE From T22_BILL,T20_IC Where (BILL_AMOUNT Between 1001 and 5000) and substr(T22_BILL.BILL_NO,1,1)='" + Session["Region"].ToString() + "' and (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and T22_BILL.BILL_NO=T20_IC.BILL_NO union all " +
					"Select '5001-10000' DESCR,nvl(SUM(BILL_AMOUNT),0)VALUE,COUNT(*)NOS,nvl(round(SUM(BILL_AMOUNT)*100/" + totBillAmt + ",2),0)PER_VALUE From T22_BILL,T20_IC Where (BILL_AMOUNT Between 5001 and 10000) and substr(T22_BILL.BILL_NO,1,1)='" + Session["Region"].ToString() + "' and (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and T22_BILL.BILL_NO=T20_IC.BILL_NO union all " +
					"Select '10001-25000' DESCR,nvl(SUM(BILL_AMOUNT),0)VALUE,COUNT(*)NOS,nvl(round(SUM(BILL_AMOUNT)*100/" + totBillAmt + ",2),0)PER_VALUE From T22_BILL,T20_IC Where (BILL_AMOUNT Between 10001 and 25000) and substr(T22_BILL.BILL_NO,1,1)='" + Session["Region"].ToString() + "' and (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and T22_BILL.BILL_NO=T20_IC.BILL_NO union all " +
					"Select '25001-50000' DESCR,nvl(SUM(BILL_AMOUNT),0)VALUE,COUNT(*)NOS,nvl(round(SUM(BILL_AMOUNT)*100/" + totBillAmt + ",2),0)PER_VALUE From T22_BILL,T20_IC Where (BILL_AMOUNT Between 25001 and 50000) and substr(T22_BILL.BILL_NO,1,1)='" + Session["Region"].ToString() + "' and (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and T22_BILL.BILL_NO=T20_IC.BILL_NO union all " +
					"Select '50001-100000' DESCR,nvl(SUM(BILL_AMOUNT),0)VALUE,COUNT(*)NOS,nvl(round(SUM(BILL_AMOUNT)*100/" + totBillAmt + ",2),0)PER_VALUE From T22_BILL,T20_IC Where (BILL_AMOUNT Between 50001 and 100000) and substr(T22_BILL.BILL_NO,1,1)='" + Session["Region"].ToString() + "' and (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and T22_BILL.BILL_NO=T20_IC.BILL_NO union all " +
					"Select '>100000' DESCR,nvl(SUM(BILL_AMOUNT),0)VALUE,COUNT(*)NOS,nvl(round(SUM(BILL_AMOUNT)*100/" + totBillAmt + ",2),0)PER_VALUE From T22_BILL,T20_IC Where BILL_AMOUNT > 100000 and substr(T22_BILL.BILL_NO,1,1)='" + Session["Region"].ToString() + "' and (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and T22_BILL.BILL_NO=T20_IC.BILL_NO";
				cmd.CommandText = str;
				cmd.Connection = conn;
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' align='center' style='border-collapse: collapse;' bordercolor='#111111' width='70%'>");
				Response.Write("<tr bgcolor=#ccccff>");
				Response.Write("<th width='25%' valign='top' align='center'><font size='2' face='Verdana'>Value Range</font></th>");
				Response.Write("<th width='25%' valign='top' align='center'><font size='2' face='Verdana'>Value</font></th>");
				Response.Write("<th width='25%' valign='top' align='center'><font size='2' face='Verdana'>No. of Bills</font></th>");
				Response.Write("<th width='25%' valign='top' align='center'><font size='2' face='Verdana'>% of Total</font></th>");
				Response.Write("</tr>");
				while (reader.Read())
				{
					Response.Write("<tr>");
					Response.Write("<td width='25%' valign='top' align='center'><font size='2' face='Verdana'>" + reader["DESCR"].ToString() + "</font></td>");
					Response.Write("<td width='25%' valign='top' align='right'><font size='2' face='Verdana'>" + reader["VALUE"].ToString() + "</font></td>");
					Response.Write("<td width='25%' valign='top' align='right'><font size='2' face='Verdana'>" + reader["NOS"].ToString() + "</font></td>");
					Response.Write("<td width='25%' valign='top' align='right'><font size='2' face='Verdana'>" + reader["PER_VALUE"].ToString() + "</font></td>");
					Response.Write("</tr>");
					T_Bill_Amt = T_Bill_Amt + Convert.ToDouble(reader["VALUE"]);
					T_Bill_Count = T_Bill_Count + Convert.ToInt16(reader["NOS"]);
				}
				Response.Write("<tr bgcolor=#ccccff>");
				Response.Write("<td width='25%' valign='top' align='center'><font size='2' face='Verdana'>Total</font></td>");
				Response.Write("<td width='25%' valign='top' align='right'><font size='2' face='Verdana'>" + T_Bill_Amt + "</font></td>");
				Response.Write("<td width='25%' valign='top' align='right'><font size='2' face='Verdana'>" + T_Bill_Count + "</font></td>");
				Response.Write("<td width='25%' valign='top' align='right'><font size='2' face='Verdana'>100</font></td>");
				Response.Write("</tr>");
				conn.Close();
				Response.Write("</table>");
			}
			else
			{
				Response.Write("<br><br><p align=center><font size='3' face='Verdana' color='red'><b>Total Billing For The Desired Period Is 0.</b></font></p><br>");
			}
			Response.Write("</body></html>");
		}

		void upcl_expend_report()
		{
			string sql = "Select Trim(T05V.VEND_NAME)Vendor, Trim(T05.VEND_NAME)||'/'||NVL2(T03.LOCATION,T03.LOCATION||' / '||T03.CITY,T03.CITY) Manu, T23.ITEM_DESC,T17.CALL_LETTER_NO, to_char(T17.CALL_LETTER_DT,'DD/MM/YYYY') CALL_LETTER_DT,T20.BILL_NO,to_char(T20.FIRST_INSP_DT,'DD/MM/YYYY') FIRST_INSP_DT,to_char(T20.LAST_INSP_DT,'DD/MM/YYYY') LAST_INSP_DT, T20.NO_OF_INSP, T22.BILL_AMOUNT,T09.IE_NAME From T20_IC T20,T09_IE T09,T05_VENDOR T05,T05_VENDOR T05V,T03_CITY T03,T13_PO_MASTER T13,T17_CALL_REGISTER T17,T22_BILL T22, T23_BILL_ITEMS T23, T12_BILL_PAYING_OFFICER T12 Where T20.CASE_NO=T13.CASE_NO AND T13.VEND_CD=T05V.VEND_CD AND T13.cASE_NO=T17.CASE_NO and T13.cASE_NO=T20.CASE_NO and T13.cASE_NO=T22.CASE_NO and T17.CASE_NO=T20.CASE_NO and T17.CALL_RECV_DT=T20.CALL_RECV_DT and T17.CALL_SNO=T20.CALL_SNO and T20.BPO_CD=T12.BPO_CD and T20.IE_CD =T09.IE_CD and T20.BILL_NO =T22.BILL_NO and T22.BILL_NO=T23.BILL_NO and T17.MFG_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD(+) AND T13.REGION_CODE='" + Session["Region"] + "' and T12.BPO_RLY='UPCL' AND (T20.IC_DT Between to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) Order By T20.IC_DT";
			double w_total_exp = 0, w_total_insp = 0;
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='10'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='10'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>UPCL Expenditure for the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Contractor</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Name Of Maunfacturer</font></b></th>");
						Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>Item</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Letter No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Leter Date</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Inspection Date</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Man Days</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>Total Expend.</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>Visiting Officer</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["Vendor"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["Manu"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_LETTER_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_LETTER_DT"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DT"] + " To " + reader["LAST_INSP_DT"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["NO_OF_INSP"]); Response.Write("</td>");
					w_total_insp = w_total_insp + Convert.ToDouble(reader["NO_OF_INSP"]);
					Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
					w_total_exp = w_total_exp + Convert.ToDouble(reader["BILL_AMOUNT"]);
					Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("</tr>");
					ctr = ctr + 1;

				};
				Response.Write("<tr>");
				Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'></td>");
				Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
				Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
				Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
				Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
				Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
				Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'><B>"); Response.Write("Total:"); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_insp); Response.Write("</B></td>");
				Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_exp); Response.Write("</B></td>");
				Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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
		void bills_adjusted_of_old_system()
		{
			string sql = "Select T27.VCHR_NO, to_char(T27.VCHR_DT,'DD/MM/YYYY') VCHR_DT,T27.CHQ_NO,to_char(T27.CHQ_DT,'DD/MM/YYYY') CHQ_DT, T94.BANK_NAME, T29.AMOUNT,T29.NARRATION From T27_JV T27,T29_JV_DETAILS T29,T94_BANK T94 where T27.VCHR_NO=T29.VCHR_NO AND T27.BANK_CD=T94.BANK_CD AND substr(T27.VCHR_NO,1,1)='" + Session["Region"] + "' AND (T27.VCHR_DT Between to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and ACC_CD=9999 Order By T27.VCHR_DT";
			double w_total_amt_trans = 0;
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='8'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='8'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>Amount Adjustments of old System For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>JV No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>JV Date</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Cheque No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Cheque Date</font></b></th>");
						Response.Write("<th width='28%' valign='top'><b><font size='1' face='Verdana'>Bank</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Narration</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>Amount Adjusted</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["VCHR_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["VCHR_DT"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_DT"]); Response.Write("</td>");
					Response.Write("<td width='28%' valign='top' align='left'> <font size='1' face='Verdana'>&nbsp"); Response.Write(reader["BANK_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["NARRATION"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'  bgColor='Lavender'> <font size='1' face='Verdana'>"); Response.Write(reader["AMOUNT"]); Response.Write("</td>");
					w_total_amt_trans = w_total_amt_trans + Convert.ToDouble(reader["AMOUNT"]);
					Response.Write("</tr>");
					ctr = ctr + 1;

				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='right' colspan=7> <font size='1' face='Verdana'><B>"); Response.Write("Total: "); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_amt_trans); Response.Write("</B></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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

		void misc_adjustments()
		{
			string sql = "Select T27.VCHR_NO, to_char(T27.VCHR_DT,'DD/MM/YYYY') VCHR_DT,T27.CHQ_NO,to_char(T27.CHQ_DT,'DD/MM/YYYY') CHQ_DT, T94.BANK_NAME, T29.AMOUNT,T29.NARRATION From T27_JV T27,T29_JV_DETAILS T29,T94_BANK T94 where T27.VCHR_NO=T29.VCHR_NO AND T27.BANK_CD=T94.BANK_CD AND substr(T27.VCHR_NO,1,1)='" + Session["Region"] + "' AND (T27.VCHR_DT Between to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and ACC_CD=9998 Order By T27.VCHR_DT";
			double w_total_amt_trans = 0;
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='8'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='8'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>Miscllenous Adjustments For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>JV No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>JV Date</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Cheque No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Cheque Date</font></b></th>");
						Response.Write("<th width='28%' valign='top'><b><font size='1' face='Verdana'>Bank</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Narration</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>Amount Adjusted</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["VCHR_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["VCHR_DT"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_DT"]); Response.Write("</td>");
					Response.Write("<td width='28%' valign='top' align='left'> <font size='1' face='Verdana'>&nbsp"); Response.Write(reader["BANK_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["NARRATION"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right' bgColor='Lavender'> <font size='1' face='Verdana'>"); Response.Write(reader["AMOUNT"]); Response.Write("</td>");
					w_total_amt_trans = w_total_amt_trans + Convert.ToDouble(reader["AMOUNT"]);
					Response.Write("</tr>");
					ctr = ctr + 1;

				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='right' colspan=7> <font size='1' face='Verdana'><B>"); Response.Write("Total: "); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_amt_trans); Response.Write("</B></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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
		void amt_transferred_to_regions()
		{
			string sql = "Select T27.VCHR_NO, to_char(T27.VCHR_DT,'DD/MM/YYYY') VCHR_DT,T27.CHQ_NO,to_char(T27.CHQ_DT,'DD/MM/YYYY') CHQ_DT, T94.BANK_NAME, T29.AMOUNT,T29.NARRATION,DECODE(T29.ACC_CD,'3007','Northern','3008','Eastern','3009','Southern','3006','Western','3066','Central','9999','Bill Adjustment of Old System','9998','Miscellenous Adjustments') ACC_DESC From T27_JV T27,T29_JV_DETAILS T29,T94_BANK T94 where T27.VCHR_NO=T29.VCHR_NO AND T27.BANK_CD=T94.BANK_CD AND substr(T27.VCHR_NO,1,1)='" + Session["Region"] + "' AND (T27.VCHR_DT Between to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and ACC_CD NOT IN (9998,9999) Order By T27.VCHR_DT";
			double w_total_amt_trans = 0;
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='9'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='9'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>Amount Transferred To Other Regions During The Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>JV No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>JV Date</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Cheque No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Cheque Date</font></b></th>");
						Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>Bank</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Transferred To Region</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Narration</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>Amount Transfered</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["VCHR_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["VCHR_DT"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_DT"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>&nbsp"); Response.Write(reader["BANK_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>&nbsp&nbsp"); Response.Write(reader["ACC_DESC"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["NARRATION"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right' bgColor='Lavender'> <font size='1' face='Verdana'>"); Response.Write(reader["AMOUNT"]); Response.Write("</td>");
					w_total_amt_trans = w_total_amt_trans + Convert.ToDouble(reader["AMOUNT"]);
					Response.Write("</tr>");
					ctr = ctr + 1;

				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='right' colspan=8> <font size='1' face='Verdana'><B>"); Response.Write("Total: "); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_amt_trans); Response.Write("</B></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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

		void amt_received_from_regions()
		{
			string sql = "Select T24.VCHR_NO, to_char(T24.VCHR_DT,'DD/MM/YYYY') VCHR_DT,T25.CHQ_NO,to_char(T25.CHQ_DT,'DD/MM/YYYY') CHQ_DT, T94.BANK_NAME, T25.AMOUNT,T25.NARRATION,DECODE(T25.ACC_CD,'3007','Northern','3008','Eastern','3009','Southern','3006','Western','3066','Central') ACC_DESC From T24_RV T24,T25_RV_DETAILS T25,T94_BANK T94 where T24.VCHR_NO=T25.VCHR_NO AND T25.BANK_CD=T94.BANK_CD AND substr(T24.VCHR_NO,1,1)='" + Session["Region"] + "' AND (T24.VCHR_DT Between to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and T25.ACC_CD IN (3006,3007,3008,3009,3066) Order By T24.VCHR_DT";
			double w_total_amt_trans = 0;
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='9'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='9'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>Amount Recieved From Other Regions During The Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>VCHR No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>VCHR Date</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Cheque No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Cheque Date</font></b></th>");
						Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>Bank</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Recieved From Region</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Narration</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>Amount Received</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["VCHR_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["VCHR_DT"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_DT"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>&nbsp"); Response.Write(reader["BANK_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>&nbsp&nbsp"); Response.Write(reader["ACC_DESC"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["NARRATION"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right' bgColor='Lavender'> <font size='1' face='Verdana'>"); Response.Write(reader["AMOUNT"]); Response.Write("</td>");
					w_total_amt_trans = w_total_amt_trans + Convert.ToDouble(reader["AMOUNT"]);
					Response.Write("</tr>");
					ctr = ctr + 1;
				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='right' colspan=8> <font size='1' face='Verdana'><B>"); Response.Write("Total: "); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_amt_trans); Response.Write("</B></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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

		void EFT()
		{
			string sql = "select BANK_NAME, CHQ_NO, to_char(CHQ_DT,'dd/mm/yyyy')CHQ_DT, AMOUNT, ACC_DESC,NVL(AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED,V12.BPO from T24_RV T24, T25_RV_DETAILS T25, T94_BANK T94, T95_ACCOUNT_CODES T95,V12_BILL_PAYING_OFFICER V12 where T24.VCHR_NO=T25.VCHR_NO and T25.BANK_CD=T94.BANK_CD and T25.ACC_CD=T95.ACC_CD and T25.BPO_CD=V12.BPO_CD(+) and ((T24.VCHR_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) or (T24.VCHR_DT is null and T25.CHQ_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy'))) and T24.VCHR_TYPE='E' and substr(T24.VCHR_NO,1,1)='" + Session["Region"].ToString() + "' order by CHQ_DT";
			double w_total_eft_amt = 0, w_total_eft_amt_adj = 0;
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='8'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='8'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>EFT For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>Bank</font></b></th>");
						Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>Account</font></b></th>");
						Response.Write("<th width='21%' valign='top'><b><font size='1' face='Verdana'>BPO</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>EFT No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>EFT Date</font></b></th>");
						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Amount</font></b></th>");
						Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Amount Adjusted</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["BANK_NAME"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ACC_DESC"]); Response.Write("</td>");
					Response.Write("<td width='21%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_DT"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["AMOUNT"]); Response.Write("</td>");
					w_total_eft_amt = w_total_eft_amt + Convert.ToDouble(reader["AMOUNT"]);
					Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["AMOUNT_ADJUSTED"]); Response.Write("</td>");
					w_total_eft_amt_adj = w_total_eft_amt_adj + Convert.ToDouble(reader["AMOUNT_ADJUSTED"]);
					Response.Write("</tr>");
					ctr = ctr + 1;

				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='right' colspan=6> <font size='1' face='Verdana'><B>"); Response.Write("Total: "); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_eft_amt); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_eft_amt_adj); Response.Write("</B></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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
		void Vouchers_Chq_Amt()
		{
			string sql = "select T24.VCHR_NO, to_char(VCHR_DT,'dd/mm/yyyy')VCHR_DATE,BANK_NAME,decode(VCHR_TYPE,'E','EFT','I','Inter-Unit','Voucher')VOUCHER_TYPE,count(*)NO_OF_CHQ,sum(AMOUNT)VOUCHER_AMT from T24_RV T24, T25_RV_DETAILS T25, T94_BANK T94 where T24.VCHR_NO=T25.VCHR_NO and T24.BANK_CD=T94.BANK_CD and ((T24.VCHR_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) or (T24.VCHR_DT is null and T25.CHQ_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy'))) and substr(T24.VCHR_NO,1,1)='" + Session["Region"].ToString() + "' group by T24.VCHR_NO, to_char(VCHR_DT,'dd/mm/yyyy'),BANK_NAME,decode(VCHR_TYPE,'E','EFT','I','Inter-Unit','Voucher') order by VOUCHER_TYPE,VCHR_DATE,VCHR_NO";
			double w_total_vchr_amt = 0, w_total_chq = 0; ;
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='6'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='7'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>Voucher Wise No. of Cheques & Their Value For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Voucher No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Voucher Date</font></b></th>");
						Response.Write("<th width='25%' valign='top'><b><font size='1' face='Verdana'>Bank</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Voucher Type</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>No. Of Cheques</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Amount</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VCHR_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VCHR_DATE"]); Response.Write("</td>");
					Response.Write("<td width='25%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BANK_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VOUCHER_TYPE"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["NO_OF_CHQ"]); Response.Write("</td>");
					w_total_chq = w_total_chq + Convert.ToDouble(reader["NO_OF_CHQ"]);
					Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["VOUCHER_AMT"]); Response.Write("</td>");
					w_total_vchr_amt = w_total_vchr_amt + Convert.ToDouble(reader["VOUCHER_AMT"]);
					Response.Write("</tr>");
					ctr = ctr + 1;

				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='right' colspan=5> <font size='1' face='Verdana'><B>"); Response.Write("Total: "); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_chq); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_vchr_amt); Response.Write("</B></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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
		void TDS()
		{
			string sql = "select v22.BILL_NO, to_char(v22.BILL_DT,'dd/mm/yyyy')BILL_DATE, v22.BPO_ORGN,v22.BILL_AMOUNT,v22.BILL_AMT_CLEARED,nvl(v22.TDS,0) TDS,nvl(v22.TDS_SGST,0) TDS_SGST,nvl(v22.TDS_CGST,0) TDS_CGST,nvl(v22.TDS_IGST,0) TDS_IGST,to_char(v22.TDS_DT,'dd/mm/yyyy')TDS_DATE, v22.BPO_RLY||'/'||v22.BPO_NAME||'/'||v22.BPO_CITY BPO, to_char(T26.POSTING_DT,'dd/mm/yyyy')POSTING_DATE,T26.CHQ_NO,to_char(T26.CHQ_DT,'dd/mm/yyyy')CHQ_DATE,T94.BANK_NAME,T26.AMOUNT_CLEARED, T25.ACC_CD, T25.NARRATION from V22_BILL V22, T26_CHEQUE_POSTING T26, T94_BANK T94, T25_RV_DETAILS T25 where V22.BILL_NO=T26.BILL_NO(+)  AND T94.BANK_CD=T26.BANK_CD AND T25.CHQ_NO=T26.CHQ_NO AND T25.CHQ_DT=T26.CHQ_DT AND T25.BANK_CD=T26.BANK_CD AND V22.REGION_CODE='" + Session["Region"].ToString() + "' and ((V22.TDS_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) or (V22.TDS_DT is null and T26.POSTING_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy'))) and (NVL(TDS,0)>0 OR NVL(TDS_IGST,0)>0 OR NVL(TDS_CGST,0)>0 OR NVL(TDS_SGST,0)>0) order by V22.BILL_NO,v22.TDS_DT,T26.POSTING_DT";
			double w_tot_bamt = 0, w_tot_tds = 0, w_tot_tds_sgst = 0, w_tot_tds_cgst = 0, w_tot_tds_igst = 0, w_chq_amt = 0, w_tot_bamt_cleared = 0;
			int ctr = 60;
			int wSno = 0;
			//			string first_page="Y";      

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr><td width='100%' colspan='18'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>TDS deducted by the Client against the Bills During The Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%'  valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>BILL No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BILL DATE</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>CLIENT</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>BPO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BILL AMOUNT</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BILL AMOUNT CLEARED</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>TDS</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>TDS SGST</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>TDS CGST</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>TDS IGST</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>POSTING DATE</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>ACCOUNT CD</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CHQ No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CHQ DATE</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>BANK</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>NARRATION</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>AMOUNT CLEARED THRU CHQ</font></b></th>");
				Response.Write("</tr></font>");
				string wBILL_NO = "";
				while (reader.Read())
				{

					if (wBILL_NO == reader["BILL_NO"].ToString())
					{
						//						wSno = wSno+1;
						Response.Write("<tr>");
						//						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"+wSno+"</td>");
						Response.Write("<td width='15%' valign='top' align='center' colspan=11> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						if (reader["TDS_DATE"].ToString() != "")
						{
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["TDS_DATE"]); Response.Write("</td>");
						}
						else
						{
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["POSTING_DATE"]); Response.Write("</td>");
						}
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ACC_CD"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_DATE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["BANK_NAME"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["NARRATION"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["AMOUNT_CLEARED"]); Response.Write("</td>");
						w_chq_amt = w_chq_amt + Convert.ToDouble(reader["AMOUNT_CLEARED"]);
						Response.Write("</tr>");
						ctr = ctr + 1;
					}
					else
					{
						//						if (wSno > 0 & wCtr >1)
						//						{
						//						
						//						}
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DATE"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO_ORGN"]); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
						w_tot_bamt = w_tot_bamt + Convert.ToDouble(reader["BILL_AMOUNT"]);
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMT_CLEARED"]); Response.Write("</td>");
						w_tot_bamt_cleared = w_tot_bamt_cleared + Convert.ToDouble(reader["BILL_AMT_CLEARED"]);
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["TDS"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["TDS_SGST"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["TDS_CGST"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["TDS_IGST"]); Response.Write("</td>");
						w_tot_tds = w_tot_tds + Convert.ToDouble(reader["TDS"]);
						w_tot_tds_cgst = w_tot_tds_cgst + Convert.ToDouble(reader["TDS_CGST"]);
						w_tot_tds_sgst = w_tot_tds_sgst + Convert.ToDouble(reader["TDS_SGST"]);
						w_tot_tds_igst = w_tot_tds_igst + Convert.ToDouble(reader["TDS_IGST"]);
						if (reader["TDS_DATE"].ToString() != "")
						{
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["TDS_DATE"]); Response.Write("</td>");
						}
						else
						{
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["POSTING_DATE"]); Response.Write("</td>");
						}
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ACC_CD"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_DATE"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["BANK_NAME"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["NARRATION"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["AMOUNT_CLEARED"]); Response.Write("</td>");
						w_chq_amt = w_chq_amt + Convert.ToDouble(reader["AMOUNT_CLEARED"]);
						wBILL_NO = reader["BILL_NO"].ToString();
						Response.Write("</tr>");
						ctr = ctr + 1;
					}
				};
				Response.Write("<tr>");
				Response.Write("<td width='75%' valign='top' align='right' colspan=5> <font size='1' face='Verdana'><B>"); Response.Write("Total: "); Response.Write("</B></td>");
				Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_tot_bamt); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_tot_bamt_cleared); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_tot_tds); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_tot_tds_sgst); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_tot_tds_cgst); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_tot_tds_igst); Response.Write("</B></td>");
				Response.Write("<td width='75%' valign='top' align='right' colspan=5> <font size='1' face='Verdana'><B>"); Response.Write(""); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_chq_amt); Response.Write("</B></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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

		void SERVICE_TAX()
		{
			OracleCommand cmd = new OracleCommand("Select NET_STAX_RATE from T98_SERVICETAX Where SYSDATE between DT_FROM and DT_TO", conn);
			conn.Open();
			decimal wCurrStaxRate = Convert.ToDecimal(cmd.ExecuteScalar());
			conn.Close();
			string mySql = "Select t25.VCHR_NO,t25.BANK_CD,t25.CHQ_NO,to_char(t25.CHQ_DT,'dd/mm/yyyy')CHQ_DT,t25.ACC_CD,nvl(t25.AMOUNT,0)AMOUNT,t22.BILL_NO,to_char(t22.BILL_DT,'dd/mm/yyyy') BILL_DATE,nvl(t26.AMOUNT_CLEARED,0)AMOUNT_CLEARED,decode(nvl(t22.SERV_TAX_RATE,10.30),10,10.30,12,12.36,t22.SERV_TAX_RATE)STAX_RATE " +
				"From T25_RV_DETAILS t25,T24_RV t24,T26_CHEQUE_POSTING t26,T22_BILL t22 " +
				"Where (t24.VCHR_NO=t25.VCHR_NO) and (t25.ACC_CD < 3000) and substr(t24.VCHR_NO,1,1)='" + Session["Region"].ToString() + "' " +
				"and ((nvl(t24.VCHR_DT,'31-DEc-9999') between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) or ((t24.VCHR_DT is null) and (nvl(t25.CHQ_DT,'31-Dec-9999') between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')))) " +
				"and(t25.BANK_CD=t26.BANK_CD(+) and t25.CHQ_NO=t26.CHQ_NO(+) and t25.CHQ_DT=t26.CHQ_DT(+)) and t26.BILL_NO=t22.BILL_NO(+) and (nvl(t22.TAX_TYPE,'X')<> 'N') " +
				"order by t22.SERV_TAX_RATE,t25.VCHR_NO,t25.BANK_CD,t25.CHQ_NO,t25.CHQ_DT,t22.BILL_NO";
			String wpBANK_CD = "", wpCHQ_NO = "", wpCHQ_DT = "", wpSno = "";
			String wBANK_CD = "", wCHQ_NO = "", wCHQ_DT = "", wACC_CD = "", wBILL_NO = "", wBILL_DT = "", wAMOUNT = "", wSTAX_RATE = "";
			decimal wAMOUNT_CLEARED = 0;
			decimal wChqAmt = 0, wPostedAmt = 0, wUnPostedAmt = 0, wPostedStax = 0, wUnPostedStax = 0, wStax = 0;
			decimal wtChqAmt = 0, wtPostedAmt = 0, wtUnPostedAmt = 0, wtPostedStax = 0, wtUnPostedStax = 0;
			int ctr = 60, multi_rec = 0;
			int wSno = 0;
			try
			{
				cmd.CommandText = mySql;
				cmd.Connection = conn;
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr><td width='100%' colspan='14'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Service Tax Computation Sheet For Realisations During the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Chq./EFT No.</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Chq./EFT DATE</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Chq./EFT Amount</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Acc Code</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Bill Date.</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Amount Posted</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Service Tax Rate</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Service Tax</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Un-Posted Amount</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Service Tax rate</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Service Tax</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Total Service Tax</font></b></th>");
				Response.Write("</tr></font>");
				while (reader.Read())
				{
					if (wpBANK_CD == reader["BANK_CD"].ToString() & wpCHQ_NO == reader["CHQ_NO"].ToString() & wpCHQ_DT == reader["CHQ_DT"].ToString())
					{
						Response.Write("<tr>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wpSno + "</td>");
						Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wCHQ_NO); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wCHQ_DT); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wAMOUNT); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wACC_CD); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wBILL_NO); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wBILL_DT); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wAMOUNT_CLEARED); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wSTAX_RATE); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wStax); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); ; Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("</td>");
						Response.Write("</tr>");
						ctr = ctr + 1;
						wpSno = "";
						wBANK_CD = "";
						wCHQ_NO = "";
						wCHQ_DT = "";
						wACC_CD = "";
						wAMOUNT = "";
						wBILL_NO = reader["BILL_NO"].ToString();
						wBILL_DT = reader["BILL_DATE"].ToString();
						wAMOUNT_CLEARED = Convert.ToDecimal(reader["AMOUNT_CLEARED"]);
						wSTAX_RATE = Convert.ToString(reader["STAX_RATE"]);
						if (Convert.ToDouble(reader["AMOUNT_CLEARED"]) == 0)
						{ wStax = 0; }
						else
						{ wStax = Math.Round(Convert.ToDecimal(reader["AMOUNT_CLEARED"]) * Convert.ToDecimal(reader["STAX_RATE"]) / Convert.ToDecimal(100 + Convert.ToDecimal(reader["STAX_RATE"])), 2); }
						//						{wStax=Math.Round(Convert.ToDecimal(reader["AMOUNT_CLEARED"])*Convert.ToDecimal(reader["STAX_RATE"])/100,2);}
						wPostedAmt = wPostedAmt + wAMOUNT_CLEARED;
						wPostedStax = wPostedStax + wStax;
						multi_rec = 1;
					}
					else
					{
						wpBANK_CD = reader["BANK_CD"].ToString();
						wpCHQ_NO = reader["CHQ_NO"].ToString();
						wpCHQ_DT = reader["CHQ_DT"].ToString();
						if (wSno != 0)
						{
							wUnPostedAmt = wChqAmt - wPostedAmt;
							wUnPostedStax = Math.Round(wUnPostedAmt * wCurrStaxRate / Convert.ToDecimal(100 + wCurrStaxRate), 2);
							//							wUnPostedStax=Math.Round(wUnPostedAmt*Convert.ToDecimal(wCurrStaxRate/100),2);
							if (multi_rec == 1)
							{
								Response.Write("<tr>");
								Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wpSno + "</td>");
								Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wCHQ_NO); Response.Write("</td>");
								Response.Write("<td width='9%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wCHQ_DT); Response.Write("</td>");
								Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wAMOUNT); Response.Write("</td>");
								Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wACC_CD); Response.Write("</td>");
								Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wBILL_NO); Response.Write("</td>");
								Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wBILL_DT); Response.Write("</td>");
								Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wAMOUNT_CLEARED); Response.Write("</td>");
								Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wSTAX_RATE); Response.Write("</td>");
								Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wStax); Response.Write("</td>");
								Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); ; Response.Write("</td>");
								Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("</td>");
								Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("</td>");
								Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("</td>");
								Response.Write("</tr>");
								multi_rec = 0;
								wBILL_NO = "";
								wBILL_DT = "";
								wSTAX_RATE = "";
							}
							Response.Write("<tr>");
							Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wpSno + "</td>");
							Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wCHQ_NO); Response.Write("</td>");
							Response.Write("<td width='9%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wCHQ_DT); Response.Write("</td>");
							Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wAMOUNT); Response.Write("</td>");
							Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wACC_CD); Response.Write("</td>");
							Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wBILL_NO); Response.Write("</td>");
							Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wBILL_DT); Response.Write("</td>");
							Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wPostedAmt); Response.Write("</b></td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wSTAX_RATE); Response.Write("</b></td>");
							Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wPostedStax); Response.Write("</b></td>");
							Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wUnPostedAmt); Response.Write("</b></td>");
							Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wCurrStaxRate); Response.Write("</b></td>");
							Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wUnPostedStax); Response.Write("</b></td>");
							Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wPostedStax + wUnPostedStax); Response.Write("</b></td>");
							Response.Write("</tr>");
							Response.Write("<tr><td colspan=14><font size='1' face='Verdana'>&nbsp</td></tr>");
							wtChqAmt = wtChqAmt + wChqAmt;
							wtPostedAmt = wtPostedAmt + wPostedAmt;
							wtUnPostedAmt = wtUnPostedAmt + wUnPostedAmt;
							wtPostedStax = wtPostedStax + wPostedStax;
							wtUnPostedStax = wtUnPostedStax + wUnPostedStax;
						}
						wSno = wSno + 1;
						wpSno = Convert.ToString(wSno);
						wBANK_CD = wpBANK_CD;
						wCHQ_NO = wpCHQ_NO;
						wCHQ_DT = wpCHQ_DT;
						wACC_CD = reader["ACC_CD"].ToString();
						wAMOUNT = Convert.ToString(reader["AMOUNT"]);
						wBILL_NO = reader["BILL_NO"].ToString();
						wBILL_DT = reader["BILL_DATE"].ToString();
						wAMOUNT_CLEARED = Convert.ToDecimal(reader["AMOUNT_CLEARED"]);
						wSTAX_RATE = Convert.ToString(reader["STAX_RATE"]);
						if (Convert.ToDouble(reader["AMOUNT_CLEARED"]) == 0)
						{ wStax = 0; }
						else
						{ wStax = Math.Round(Convert.ToDecimal(reader["AMOUNT_CLEARED"]) * Convert.ToDecimal(reader["STAX_RATE"]) / Convert.ToDecimal(100 + Convert.ToDecimal(reader["STAX_RATE"])), 2); }
						//						{wStax=Math.Round(Convert.ToDecimal(reader["AMOUNT_CLEARED"])*Convert.ToDecimal(reader["STAX_RATE"])/100,2);}
						wChqAmt = Convert.ToDecimal(reader["AMOUNT"]); ;
						wPostedAmt = wAMOUNT_CLEARED;
						wPostedStax = wStax;
					}
				};
				wUnPostedAmt = wChqAmt - wPostedAmt;
				wUnPostedStax = Math.Round(wUnPostedAmt * wCurrStaxRate / Convert.ToDecimal(100 + wCurrStaxRate), 2);
				//				wUnPostedStax=Math.Round(wUnPostedAmt*Convert.ToDecimal(wCurrStaxRate/100),2);
				if (multi_rec == 1)
				{
					Response.Write("<tr>");
					Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wpSno + "</td>");
					Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wCHQ_NO); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wCHQ_DT); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wAMOUNT); Response.Write("</td>");
					Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wACC_CD); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wBILL_NO); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wBILL_DT); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wAMOUNT_CLEARED); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wSTAX_RATE); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wStax); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); ; Response.Write("</td>");
					Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("</td>");
					Response.Write("</tr>");
					wBILL_NO = "";
					wBILL_DT = "";
					wSTAX_RATE = "";
				}
				Response.Write("<tr>");
				Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wpSno + "</td>");
				Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wCHQ_NO); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wCHQ_DT); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wAMOUNT); Response.Write("</td>");
				Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wACC_CD); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wBILL_NO); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wBILL_DT); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wPostedAmt); Response.Write("</b></td>");
				Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wSTAX_RATE); Response.Write("</b></td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wPostedStax); Response.Write("</b></td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wUnPostedAmt); Response.Write("</b></td>");
				Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wCurrStaxRate); Response.Write("</b></td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wUnPostedStax); Response.Write("</b></td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wPostedStax + wUnPostedStax); Response.Write("</b></td>");
				Response.Write("</tr>");
				wtChqAmt = wtChqAmt + wChqAmt;
				wtPostedAmt = wtPostedAmt + wPostedAmt;
				wtUnPostedAmt = wtUnPostedAmt + wUnPostedAmt;
				wtPostedStax = wtPostedStax + wPostedStax;
				wtUnPostedStax = wtUnPostedStax + wUnPostedStax;
				Response.Write("<tr bgcolor=#ccccff>");
				Response.Write("<td width='22%' valign='top' align='right' colspan=3> <font size='1' face='Verdana'><b>"); Response.Write("Totals -->"); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtChqAmt); Response.Write("</td>");
				Response.Write("<td width='13%' valign='top' align='center' colspan=3> <font size='1' face='Verdana'><b>"); Response.Write(""); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtPostedAmt); Response.Write("</td>");
				Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(""); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtPostedStax); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtUnPostedAmt); Response.Write("</td>");
				Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(""); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtUnPostedStax); Response.Write("</td>");
				Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtPostedStax + wtUnPostedStax); Response.Write("</b></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = false;
			Panel_2.Visible = false;
			wToDt = toDt.Text.Trim();
			wFrmDt = frmDt.Text.Trim();
			wRegion = "";

			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

			if (Convert.ToString(Request.Params["ACTION"].Trim()) == "Rejection")
			{
				RejectionIC();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "Reinspection")
			{
				ReInspectionIC_BPOwise();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "IE_X")
			{
				ie_performance_expanded();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CLUSTER_X")
			{
				cluster_performance_expanded();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "BA")
			{
				billing_analysis();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "UPCL")
			{
				upcl_expend_report();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "BATOS")
			{
				bills_adjusted_of_old_system();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "MA")
			{
				misc_adjustments();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ATTR")
			{
				amt_transferred_to_regions();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ARFR")
			{
				amt_received_from_regions();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "EFT")
			{
				EFT();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "TDS")
			{
				TDS();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "STAX")
			{
				SERVICE_TAX();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "WOF")
			{
				write_off_amt_statement();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "RET")
			{
				retention_amt_statement();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CIE")
			{
				IEWiseCallStatus();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CIEU")
			{
				IEWiseCallStatus_update();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CIEU")
			{
				IEWiseCallStatus_update();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "DWB")
			{
				discipline_wise_billing();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CR")
			{
				contract_review();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "SUMCALLX")
			{
				summary_calls_cancelled();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ICSUBMIT")
			{
				summary_ic_submitted();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CALLSWITHOUTIC")
			{
				AorRcallswithoutIC();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CWPOANDVALUE")
			{
				client_wisepoandvalue();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "REMCALLS")
			{
				remarked_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "VOUCHERDETAILS")
			{
				Vouchers_Chq_Amt();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "DCWACOMPS")
			{
				Defectcodewise_Compliants();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "BSS")
			{
				details_of_bills_notscanned();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "STAMP")
			{
				IEWiseSealingStatus();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CLRETURN")
			{
				call_return_report();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ICISSUEDNSUB")
			{
				ic_issued_notsubmitted();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "NOOFCALLS")
			{
				no_calls_online_manual();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "PJI")
			{
				pending_ji_cases();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "FIRERETVENDCALL")
			{
				fire_retardant_vendors_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "IECITYCALLS")
			{
				IECityWiseCallStatus();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "TEXTILEITEMS")
			{
				textile_items_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "OHEITEMS")
			{
				OHE_items_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "IE_DAIRY")
			{
				ie_dairy();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "SUPSUR")
			{
				super_surprise();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CALLSATTENDED2DAYS")
			{
				ie_calls_attended_2days();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ONLINENRPAYMENTS")
			{
				online_nr_payments();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "AFTEREXPDT")
			{
				calls_attended_afterexpected_date();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "PLEXCEPT")
			{
				po_unlinked_mchksheet();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "PLLINKED")
			{
				po_linked_mchksheet();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CALLEXCEPT")
			{
				call_unlinked_mchksheet();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "PLLINKEDCHK")
			{
				pl_linked();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "SUMMARYAFTEREXPDT")
			{
				summary_calls_attended_afterexpected_date();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ICFBILLDET")
			{
				icf_billing_details();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CCAPP")
			{
				call_cancel_approval();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "LABR")
			{
				LAB_INVOICE_RPT();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CHECK")
			{
				CHECK_SHEET();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "MOZCALLS")
			{
				MOZ_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "PHED")
			{
				PHED_calls();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "MOZPOS")
			{
				MOZ_POS();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "RETBILLSBPOCHANGE")
			{
				RETURNED_BILLS_CHANGE_BPO();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "UNBILLEDIC")
			{
				unbilled_ic();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CREDITNOTE")
			{
				credit_note_invoices();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "SUPSURPSUMM")
			{
				super_surprise_summary();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "TECH")
			{
				TECH_REF();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CMWISEICNI")
			{
				cm_issued_notsubmitted();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "COUNTIC")
			{
				Cum_ICissuednotsubmitted();
			}

			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		void ie_dairy()
		{

			Response.Write("<html><body>");
			Response.Write("<br><br><p align=center><font size='3' face='Verdana'><b><u>IE Register For The Period: " + wFrmDt + " To " + wToDt + "  (" + wRegion + ")</u></b></font></p><br>");

			Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
			Response.Write("<tr>");
			Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>PO No. & Date Rly/Non Rly</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>RITES Case No.</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Call No. & Date</font></b></th>");
			Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>Name of the Vendor/Mfgr</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Date of Visit</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Brief Disc of Stores</font></b></th>");
			Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty. Insp</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Installment No.</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Book No./Set No.</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>A. IC Issued, B. Rejection C.Cancellation issue Date</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Consignee and Rly/Non Rly</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Value of Stores</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Date of submission of papers for Billing</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Inspection Fee</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Remarks, Date of Test Report recd.</font></b></th>");
			Response.Write("</tr></font>");
			string str1 = "";
			if (Convert.ToString(Session["IE_CD"]) != "")
			{
				str1 = "select T13.PO_NO||' DT. '||to_char(T13.PO_DT,'dd/mm/yyyy')||'-'||RLY_CD PO,T17.CASE_NO, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')||'-'||T17.CALL_SNO CALL,T05.VEND_NAME||','||T03.CITY VEND, to_char(T47.VISIT_DT,'dd/mm/yyyy') DT_OF_VISIT,T18.ITEM_DESC_PO,T18.QTY_TO_INSP, NVL2(T20.CALL_INSTALL_NO,T20.CALL_INSTALL_NO||' & '||decode(FULL_PART,'F','Final','P','Part'),'')CALL_INSTALL_NO, T20.BK_NO, T20.SET_NO,TO_CHAR(T20.IC_DT,'DD/MM/YYYY') IC_ISSUE_DT, TO_CHAR(T20.IC_SUBMIT_DT,'DD/MM/YYYY') SUBMIT_DT ,V06.CONSIGNEE,T22.MATERIAL_VALUE, T22.INSP_FEE,(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT from T17_CALL_REGISTER T17,T18_CALL_DETAILS T18, T20_IC T20, T22_BILL T22, T13_PO_MASTER T13, T05_VENDOR T05, T03_CITY T03,T47_IE_WORK_PLAN T47,T21_CALL_STATUS_CODES T21, V06_CONSIGNEE V06 where T17.CASE_NO=T13.CASE_NO and T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO and T18.CONSIGNEE_CD=V06.CONSIGNEE_CD and T17.CASE_NO=T47.CASE_NO and T17.CALL_RECV_DT=T47.CALL_RECV_DT and T17.CALL_SNO=T47.CALL_SNO and T17.CALL_STATUS=T21.CALL_STATUS_CD and T17.CASE_NO=T20.CASE_NO(+) and T17.CALL_RECV_DT=T20.CALL_RECV_DT(+) and T17.CALL_SNO=T20.CALL_SNO(+) and T20.BILL_NO=T22.BILL_NO(+) and T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) and T17.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "' and (T47.VISIT_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) order by T47.VISIT_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')||'-'||T17.CALL_SNO,T17.CASE_NO,T18.ITEM_DESC_PO";
			}
			OracleCommand cmd1 = new OracleCommand(str1, conn);
			conn.Open();
			OracleDataReader reader1 = cmd1.ExecuteReader();

			while (reader1.Read())
			{
				Response.Write("<tr>");
				Response.Write("<td width='15%' valign='top' align='Left'><font size='1' face='Verdana'>" + reader1["PO"].ToString() + "</font></td>");
				Response.Write("<td width='7%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["CASE_NO"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["CALL"].ToString() + "</font></td>");
				Response.Write("<td width='6%' valign='top' align='Left'><font size='1' face='Verdana'>" + reader1["VEND"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["DT_OF_VISIT"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='left'><font size='1' face='Verdana'>" + reader1["ITEM_DESC_PO"].ToString() + "</font></td>");
				Response.Write("<td width='6%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["QTY_TO_INSP"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["CALL_INSTALL_NO"].ToString() + "</font></td>");
				Response.Write("<td width='10%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["BK_NO"].ToString() + "/" + reader1["SET_NO"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["IC_ISSUE_DT"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='left'><font size='1' face='Verdana'>" + reader1["CONSIGNEE"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["MATERIAL_VALUE"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["SUBMIT_DT"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["INSP_FEE"].ToString() + "</font></td>");
				Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'></font></td>");
				Response.Write("</tr>");

			}

			conn.Close();
			Response.Write("</table>");
			Response.Write("</body></html>");
		}
		void remarked_calls()
		{
			string sql = "select CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy') CALL_DATE,CALL_SNO,to_char(DT_INSP_DESIRE,'dd/mm/yyyy') DESIRE_DATE, T09.IE_NAME, decode(CALL_REMARK_STATUS,'1','1st','2','2nd','3','3rd','4','4th','5','5th','6','6th','7','7th','8','8th','9','9th')CALL_REMARK_STATUS from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD= T09.IE_CD and CALL_REMARK_STATUS is not NULL and T17.CALL_RECV_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' order by CALL_RECV_DT,T09.IE_SNAME";
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='7'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='7'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Re-Marked Calls for the Period : " + wFrmDt + " TO " + wToDt + "&nbsp&nbsp(Report Sorted on Call Date & IE)</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Call Date</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Call Sno.</font></b></th>");
				Response.Write("<th width='40%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Remark/Desire Date</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Remark Status</font></b></th>");
				Response.Write("</tr></font>");

				//				string wBILL_NO="";
				while (reader.Read())
				{

					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
					Response.Write("<td width='40%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DESIRE_DATE"]); Response.Write("</td>");
					Response.Write("<td width='110%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_REMARK_STATUS"]); Response.Write("</td>");
					Response.Write("</tr>");


				}

				Response.Write("</table>");
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
		void IEWiseCallStatus()
		{

			conn.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn.Close();
			//			string sql="Select  IE,SEAL_NO,sum(PENDING) PENDING,sum(PENDING7) PENDING7,sum(ACCEPTED) ACCEPTED,sum(REJECTION) REJECTION,sum(CANCELLED) CANCELLED,sum(LAB_TESTING) UNDER_LAB_TESTING,sum(UNDER_INSPECTION) STILL_UNDER_INSPECTION,sum(STAGE_INSPECTION) STAGE_INSPECTION,sum(WITHHELD) WITHHELD,sum(C3)C3,sum(CM7)CM7,sum(C10)C10 From " +
			//				" ( Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,count(*)  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,count(*)  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between   to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and (to_date('"+ss+"','dd.mm/yyyy') - T17.DT_INSP_DESIRE >7 ) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,count(*) ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='A' and (T17.CALL_MARK_DT between   to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,count(*)  REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='R' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,count(*)  CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='C' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,count(*)  LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='U' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,count(*)  UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='S' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,count(*)  STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='G' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,count(*)  WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='W' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all SELECT T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0  WITHHELD,(COUNT(*))C3, 0 CM7,0 C10 FROM T20_IC T20, T09_IE T09, T22_BILL T22 WHERE T20.IE_CD=T09.IE_CD AND T22.BILL_NO=T20.BILL_NO AND (T22.BILL_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND (nvl(IC_DT,'31-Dec-9999')-nvl(LAST_INSP_DT,'01-Jan-2005'))>3  AND SUBSTR(T20.case_no,1,1)='"+Session["Region"].ToString()+"' GROUP BY IE_NAME,IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0  WITHHELD,0 C3,(count(*)) CM7,0 C10 frOM T20_IC T20, T09_IE T09, T22_BILL T22  where T20.IE_CD=T09.IE_CD AND T22.BILL_NO=T20.BILL_NO and (T22.BILL_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) > 7  and substr(T20.case_no,1,1)='"+Session["Region"].ToString()+"'  group by IE_NAME,IE_SEAL_NO "+
			//				" union all SELECT T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0  WITHHELD,0 C3,0 CM7,(COUNT(*))C10 FROM T20_IC T20, T09_IE T09, T22_BILL T22  WHERE T20.IE_CD=T09.IE_CD AND T22.BILL_NO=T20.BILL_NO  AND (T22.BILL_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND (nvl(IC_SUBMIT_DT,'31-Dec-9999') - nvl(IC_DT,'01-Jan-2005'))>10  AND SUBSTR(T20.case_no,1,1)='"+Session["Region"].ToString()+"' GROUP BY IE_NAME,IE_SEAL_NO "+
			//				" ) group by IE,SEAL_NO order by IE,SEAL_NO";
			string sql = "Select  IE,SEAL_NO,sum(PENDING) PENDING,sum(PENDING7) PENDING7,sum(ACCEPTED) ACCEPTED,sum(BILLED) BILLED,sum(REJECTION) REJECTION,sum(CANCELLED) CANCELLED,sum(LAB_TESTING) UNDER_LAB_TESTING,sum(UNDER_INSPECTION) STILL_UNDER_INSPECTION,sum(STAGE_INSPECTION) STAGE_INSPECTION,sum(STAGE_REJECTION) STAGE_REJECTION,sum(WITHHELD) WITHHELD,sum(C3)C3,sum(CM7)CM7,sum(C10)C10 From " +
				" ( Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,count(*)  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,count(*)  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and (to_date('" + ss + "','dd.mm/yyyy') - T17.DT_INSP_DESIRE >7 ) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,count(*) ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='A' and (T17.CALL_MARK_DT between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,count(*) BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='B' and (T17.CALL_MARK_DT between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,count(*) REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='R' and (T17.CALL_MARK_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,count(*)  CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='C' and (T17.CALL_MARK_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,count(*)  LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='U' and (T17.CALL_MARK_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,count(*)  UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='S' and (T17.CALL_MARK_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,count(*)  STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='G' and (T17.CALL_MARK_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION, count(*) STAGE_REJECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='T' and (T17.CALL_MARK_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,count(*)  WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='W' and (T17.CALL_MARK_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all SELECT T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0  WITHHELD,(COUNT(*))C3, 0 CM7,0 C10 FROM T20_IC T20, T09_IE T09, T22_BILL T22 WHERE T20.IE_CD=T09.IE_CD AND T22.BILL_NO=T20.BILL_NO AND (T22.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND (nvl(IC_DT,'31-Dec-9999')-nvl(LAST_INSP_DT,'01-Jan-2005'))>1  AND SUBSTR(T20.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,IE_SEAL_NO" +
				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0  WITHHELD,0 C3,(count(*)) CM7,0 C10 frOM T20_IC T20, T09_IE T09, T22_BILL T22  where T20.IE_CD=T09.IE_CD AND T22.BILL_NO=T20.BILL_NO and (T22.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) > 7  and substr(T20.case_no,1,1)='" + Session["Region"].ToString() + "'  group by IE_NAME,IE_SEAL_NO " +
				" union all SELECT T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0  WITHHELD,0 C3,0 CM7,(COUNT(*))C10 FROM T20_IC T20, T09_IE T09, T22_BILL T22  WHERE T20.IE_CD=T09.IE_CD AND T22.BILL_NO=T20.BILL_NO  AND (T22.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND (nvl(IC_SUBMIT_DT,'31-Dec-9999') - nvl(IC_DT,'01-Jan-2005'))>7  AND SUBSTR(T20.case_no,1,1)='" + Session["Region"].ToString() + "' GROUP BY IE_NAME,IE_SEAL_NO " +
				" ) group by IE,SEAL_NO order by IE,SEAL_NO";

			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='18'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='18'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>SUMMARY OF IE WISE CALL STATUS FROM " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='14%' valign='top'><b><font size='1' face='Verdana'>IE NAME.</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>IE SEAL No.</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>PENDING</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>PENDING > 7 Days</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>ACCEPTED</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>ACCEPTED & BILLED</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>REJECTION</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CANCELLED</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>UNDER LAB TESTING</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>STILL UNDER INSPECTION</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>STAGE INSPECTION</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>STAGE REJECTION</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>WITHHELD</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>TOTAL CALLS</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Calls Attended Beyond 7 Days.</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>No. Of IC Issued after 1 days of Last Inspection date.</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>IC's Submitted beyond 7 Days after Issue of IC.</font></b></th>");
				Response.Write("</tr></font>");

				int w_total_calls = 0;
				int i = 0;
				while (reader.Read())
				{
					w_total_calls = 0;
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='14%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["SEAL_NO"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["PENDING"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["PENDING"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["PENDING7"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["ACCEPTED"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["ACCEPTED"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BILLED"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["BILLED"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["REJECTION"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["REJECTION"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["CANCELLED"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["CANCELLED"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["UNDER_LAB_TESTING"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["UNDER_LAB_TESTING"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["STILL_UNDER_INSPECTION"]); Response.Write("&nbsp&nbsp</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["STILL_UNDER_INSPECTION"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["STAGE_INSPECTION"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["STAGE_INSPECTION"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["STAGE_REJECTION"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["STAGE_REJECTION"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["WITHHELD"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["WITHHELD"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(w_total_calls); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'><font size='1' face='Verdana'>"); Response.Write(reader["CM7"]); Response.Write("</font></td>");
					Response.Write("<td width='5%' valign='top' align='right'><font size='1' face='Verdana'>"); Response.Write(reader["C3"]); Response.Write("</font></td>");
					Response.Write("<td width='5%' valign='top' align='right'><font size='1' face='Verdana'>"); Response.Write(reader["C10"]); Response.Write("</font></td>");
					Response.Write("</tr>");
					i++;
				};

				Response.Write("</table>");
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

		void IEWiseCallStatus_update()
		{

			conn.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn.Close();
			//			string sql="Select  IE,SEAL_NO,sum(PENDING) PENDING,sum(PENDING7) PENDING7,sum(ACCEPTED) ACCEPTED,sum(REJECTION) REJECTION,sum(CANCELLED) CANCELLED,sum(LAB_TESTING) UNDER_LAB_TESTING,sum(UNDER_INSPECTION) STILL_UNDER_INSPECTION,sum(STAGE_INSPECTION) STAGE_INSPECTION,sum(WITHHELD) WITHHELD,sum(C3)C3,sum(CM7)CM7,sum(C10)C10 From " +
			//				" ( Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,count(*)  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,count(*)  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between   to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and (to_date('"+ss+"','dd.mm/yyyy') - T17.DT_INSP_DESIRE >7 ) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,count(*) ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='A' and (T17.CALL_MARK_DT between   to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,count(*)  REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='R' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,count(*)  CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='C' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,count(*)  LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='U' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,count(*)  UNDER_INSPECTION,0 STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='S' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,count(*)  STAGE_INSPECTION,0 WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='G' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,count(*)  WITHHELD,0 C3,0 CM7,0 C10 from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='W' and (T17.CALL_MARK_DT between  to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME,T09.IE_SEAL_NO"+
			//				" union all SELECT T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0  WITHHELD,(COUNT(*))C3, 0 CM7,0 C10 FROM T20_IC T20, T09_IE T09, T22_BILL T22 WHERE T20.IE_CD=T09.IE_CD AND T22.BILL_NO=T20.BILL_NO AND (T22.BILL_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND (nvl(IC_DT,'31-Dec-9999')-nvl(LAST_INSP_DT,'01-Jan-2005'))>3  AND SUBSTR(T20.case_no,1,1)='"+Session["Region"].ToString()+"' GROUP BY IE_NAME,IE_SEAL_NO"+
			//				" union all Select T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0  WITHHELD,0 C3,(count(*)) CM7,0 C10 frOM T20_IC T20, T09_IE T09, T22_BILL T22  where T20.IE_CD=T09.IE_CD AND T22.BILL_NO=T20.BILL_NO and (T22.BILL_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) and (nvl(first_insp_dt,'31-Dec-9999') - nvl(call_dt,'01-Jan-2005')) > 7  and substr(T20.case_no,1,1)='"+Session["Region"].ToString()+"'  group by IE_NAME,IE_SEAL_NO "+
			//				" union all SELECT T09.IE_NAME, T09.IE_SEAL_NO SEAL_NO,0  PENDING,0  PENDING7,0 ACCEPTED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0  WITHHELD,0 C3,0 CM7,(COUNT(*))C10 FROM T20_IC T20, T09_IE T09, T22_BILL T22  WHERE T20.IE_CD=T09.IE_CD AND T22.BILL_NO=T20.BILL_NO  AND (T22.BILL_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) AND (nvl(IC_SUBMIT_DT,'31-Dec-9999') - nvl(IC_DT,'01-Jan-2005'))>10  AND SUBSTR(T20.case_no,1,1)='"+Session["Region"].ToString()+"' GROUP BY IE_NAME,IE_SEAL_NO "+
			//				" ) group by IE,SEAL_NO order by IE,SEAL_NO";
			string sql = "Select  IE,SEAL_NO,sum(ACCEPTED) ACCEPTED,sum(BILLED) BILLED,sum(REJECTION) REJECTION,sum(CANCELLED) CANCELLED,sum(LAB_TESTING) UNDER_LAB_TESTING,sum(UNDER_INSPECTION) STILL_UNDER_INSPECTION,sum(STAGE_INSPECTION) STAGE_INSPECTION,sum(STAGE_REJECTION) STAGE_REJECTION,sum(WITHHELD) WITHHELD From " +
				" ( Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,count(*) ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='A' and (T17.CALL_STATUS_DT between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0 ACCEPTED,count(*) BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='B' and (T17.CALL_STATUS_DT between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0 ACCEPTED,0 BILLED,count(*) REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='R' and (T17.CALL_STATUS_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0 ACCEPTED,0 BILLED,0 REJECTION,count(*)  CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='C' and (T17.CALL_STATUS_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,count(*)  LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='U' and (T17.CALL_STATUS_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,count(*)  UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='S' and (T17.CALL_STATUS_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,count(*)  STAGE_INSPECTION,0 STAGE_REJECTION,0 WITHHELD from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='G' and (T17.CALL_STATUS_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION, count(*) STAGE_REJECTION,0 WITHHELD from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='T' and (T17.CALL_STATUS_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0 ACCEPTED,0 BILLED,0 REJECTION,0 CANCELLED,0 LAB_TESTING,0 UNDER_INSPECTION,0 STAGE_INSPECTION,0 STAGE_REJECTION,count(*)  WITHHELD from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD and T17.CALL_STATUS='W' and (T17.CALL_STATUS_DT between  to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" ) group by IE,SEAL_NO order by IE,SEAL_NO";

			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='18'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='18'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>SUMMARY OF IE WISE CALL STATUS UPDATED FROM " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='14%' valign='top'><b><font size='1' face='Verdana'>IE NAME.</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>IE SEAL No.</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>ACCEPTED</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>ACCEPTED & BILLED</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>REJECTION</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CANCELLED</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>UNDER LAB TESTING</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>STILL UNDER INSPECTION</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>STAGE INSPECTION</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>STAGE REJECTION</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>WITHHELD</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>TOTAL CALLS</font></b></th>");
				Response.Write("</tr></font>");

				int w_total_calls = 0;
				int i = 0;
				while (reader.Read())
				{
					w_total_calls = 0;
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='14%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["SEAL_NO"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["ACCEPTED"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["ACCEPTED"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BILLED"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["BILLED"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["REJECTION"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["REJECTION"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["CANCELLED"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["CANCELLED"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["UNDER_LAB_TESTING"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["UNDER_LAB_TESTING"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["STILL_UNDER_INSPECTION"]); Response.Write("&nbsp&nbsp</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["STILL_UNDER_INSPECTION"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["STAGE_INSPECTION"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["STAGE_INSPECTION"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["STAGE_REJECTION"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["STAGE_REJECTION"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["WITHHELD"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["WITHHELD"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(w_total_calls); Response.Write("</td>");
					Response.Write("</tr>");
					i++;
				};

				Response.Write("</table>");
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
		void IECityWiseCallStatus()
		{

			conn.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			OracleCommand cmd3 = new OracleCommand("Select to_char(sysdate-1,'dd/mm/yyyy') from dual", conn);
			string ss1 = Convert.ToString(cmd3.ExecuteScalar());
			OracleCommand cmd4 = new OracleCommand("Select to_char(sysdate-90,'dd/mm/yyyy') from dual", conn);
			string ss2 = Convert.ToString(cmd4.ExecuteScalar());
			conn.Close();

			//			string sql="Select  IE, CITY,sum(PENDING) PENDING,sum(TOTAL) TOTAL From " +
			//				" ( Select T09.IE_NAME IE, T03.CITY,count(*)  PENDING,0  TOTAL from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"'  group by T09.IE_NAME, T03.CITY,T09.IE_SEAL_NO" +
			//				"	union all Select T09.IE_NAME, T03.CITY,0  PENDING,count(*)  TOTAL from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD and (T17.CALL_MARK_DT between   to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_NAME, T03.CITY,T09.IE_SEAL_NO"+
			//				" ) group by IE,CITY order by CITY,IE";

			string sql1 = "Select  IE,CM,DEPT,CITY,sum(PENDING) PENDING,SUM(STILL_UNDER_INSP) STILL_UNDER_INSP,SUM(UNDER_LAB_TESTING) UNDER_LAB_TESTING,sum(TOTAL) TOTAL, SUM(COMM_CALLS) COMM_CALLS, SUM(CALL_TODAY) CALL_TODAY,SUM(PENDING_5) PENDING_5 From " +
				" ( Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,count(*)  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING, 0  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY, 0 PENDING_5  from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' and T09.IE_STATUS IS NULL group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO  " +
				"   union all Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, COUNT(*) STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY, 0 PENDING_5  from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and T17.CALL_STATUS='S' and (T17.CALL_MARK_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' and T09.IE_STATUS IS NULL group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO  " +
				"   union all Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,COUNT(*) UNDER_LAB_TESTING,0  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY, 0 PENDING_5  from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and T17.CALL_STATUS='U' and (T17.CALL_MARK_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' and T09.IE_STATUS IS NULL group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO  " +
				"	union all Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,count(*)  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY, 0 PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.CALL_MARK_DT between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' and T09.IE_STATUS IS NULL group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
				"	union all Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, COUNT(*) COMM_CALLS, 0 CALL_TODAY, 0 PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.CALL_STATUS_DT between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) AND CALL_STATUS<>'M' and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' and T09.IE_STATUS IS NULL group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
				"	union all Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 COMM_CALLS, COUNT(*) CALL_TODAY, 0 PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.CALL_STATUS_DT =to_date('" + ss1 + "','dd/mm/yyyy')) AND CALL_STATUS<>'M' and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' and T09.IE_STATUS IS NULL group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
				"   union all Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY, count(*) PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.DT_INSP_DESIRE between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' AND (sysdate-DT_INSP_DESIRE>5) and CALL_STATUS='M' group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
				" ) group by IE,CM,DEPT,CITY HAVING (SUM(PENDING)<=5 or SUM(PENDING)>=10) order by DEPT,CITY,PENDING,IE ";
			int wSno1 = 0;
			string first_page1 = "Y";

			try
			{
				OracleCommand cmd1 = new OracleCommand(sql1, conn);
				conn.Open();
				OracleDataReader reader1 = cmd1.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='12'>");
				if (first_page1 == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page1 = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='80%' colspan='12'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>SUMMARY OF IE CITY/HEADQUATER WISE CALL STATUS FROM " + wFrmDt + " TO " + wToDt + " (Pending Calls Less than Equal to 5 or Greater than Equal to 10)</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE NAME.</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CM NAME.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PENDING</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>STILL UNDER INSP</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>UNDER LAB TESTING</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>TOTAL CALLS</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PENDING >5 DAYS</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE CITY</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE DEPT</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CALLS UPDATED YESTERDAY</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>COMM CALLS UPDATED</font></b></th>");

				Response.Write("</tr></font>");

				int t11 = 0, t22 = 0, t33 = 0, t44 = 0, t55 = 0, t66 = 0, t77 = 0;
				int i1 = 0;
				while (reader1.Read())
				{

					wSno1 = wSno1 + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno1 + "</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["IE"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["CM"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader1["PENDING"]); Response.Write("</td>");
					t11 = t11 + Convert.ToInt32(reader1["PENDING"]);
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader1["STILL_UNDER_INSP"]); Response.Write("</td>");
					t66 = t66 + Convert.ToInt32(reader1["STILL_UNDER_INSP"]);
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader1["UNDER_LAB_TESTING"]); Response.Write("</td>");
					t77 = t77 + Convert.ToInt32(reader1["UNDER_LAB_TESTING"]);
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader1["TOTAL"]); Response.Write("</td>");
					t22 = t22 + Convert.ToInt32(reader1["TOTAL"]);
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader1["PENDING_5"]); Response.Write("</td>");
					t33 = t33 + Convert.ToInt32(reader1["PENDING_5"]);
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["CITY"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["DEPT"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader1["CALL_TODAY"]); Response.Write("</td>");
					t44 = t44 + Convert.ToInt32(reader1["CALL_TODAY"]);
					Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader1["COMM_CALLS"]); Response.Write("</td>");
					t55 = t55 + Convert.ToInt32(reader1["COMM_CALLS"]);
					Response.Write("</tr>");
					i1++;
				};
				Response.Write("<tr>");
				Response.Write("<td width='5%' valign='top' align='Right' colspan=3> <font size='1' face='Verdana'>Total:</td>");
				Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t11); Response.Write("</td>");
				Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t66); Response.Write("</td>");
				Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t77); Response.Write("</td>");
				Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t22); Response.Write("</td>");
				Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t33); Response.Write("</td>");
				Response.Write("<td width='5%' valign='top' align='Right' colspan=2> <font size='1' face='Verdana'></td>");
				Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t44); Response.Write("</td>");
				Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t55); Response.Write("</td>");
				Response.Write("</tr>");


				Response.Write("</table>");

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
			if (Session["Region"].ToString() == "N")
			{
				string sql = "Select  IE_CODE1,IE,CM,DEPT,CITY,(SELECT UNIQUE HQ_AREA FROM T99_CLUSTER_MASTER T99, T101_IE_CLUSTER T101 WHERE T99.CLUSTER_CODE=T101.CLUSTER_CODE AND T101.IE_CODE=IE_CODE1 GROUP BY HQ_AREA) AREA,sum(PENDING) PENDING,SUM(STILL_UNDER_INSP) STILL_UNDER_INSP,SUM(UNDER_LAB_TESTING) UNDER_LAB_TESTING,sum(TOTAL) TOTAL, SUM(AVG_CALLS) AVG_CALLS, SUM(CALL_TODAY) CALL_TODAY, SUM(CALL_YESTERDAY) CALL_YESTERDAY,SUM(PENDING_5) PENDING_5 From " +
					" ( Select T09.IE_CD IE_CODE1,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,count(*)  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 AVG_CALLS, 0 CALL_TODAY,0 CALL_YESTERDAY,0 PENDING_5  from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					"   union all Select T09.IE_CD IE_CODE1,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, COUNT(*) STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 AVG_CALLS, 0 CALL_TODAY,0 CALL_YESTERDAY, 0 PENDING_5  from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and T17.CALL_STATUS='S' and (T17.CALL_MARK_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' and T09.IE_STATUS IS NULL group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO  " +
					"   union all Select T09.IE_CD IE_CODE1,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,COUNT(*) UNDER_LAB_TESTING,0  TOTAL, 0 AVG_CALLS, 0 CALL_TODAY,0 CALL_YESTERDAY, 0 PENDING_5  from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and T17.CALL_STATUS='U' and (T17.CALL_MARK_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' and T09.IE_STATUS IS NULL group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO  " +
					"	union all Select T09.IE_CD IE_CODE1,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,count(*)  TOTAL, 0 AVG_CALLS, 0 CALL_TODAY,0 CALL_YESTERDAY,0 PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.CALL_MARK_DT between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					"	union all Select T09.IE_CD IE_CODE1,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, ROUND(COUNT(DISTINCT CASE_NO||CALL_RECV_DT||CALL_SNO)/3) AVG_CALLS, 0 CALL_TODAY,0 CALL_YESTERDAY,0 PENDING_5 from T47_IE_WORK_PLAN T47, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T47.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T47.VISIT_DT  BETWEEN to_date('" + ss2 + "','dd/mm/yyyy') AND to_date('" + ss + "','dd/mm/yyyy')) And substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					"	union all Select T09.IE_CD IE_CODE1,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 AVG_CALLS, COUNT(*) CALL_TODAY,0 CALL_YESTERDAY,0 PENDING_5 from T47_IE_WORK_PLAN T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.VISIT_DT =to_date('" + ss + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					"	union all Select T09.IE_CD IE_CODE1,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 AVG_CALLS, 0 CALL_TODAY,COUNT(*) CALL_YESTERDAY,0 PENDING_5 from T47_IE_WORK_PLAN T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.VISIT_DT =to_date('" + ss1 + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					"   union all Select T09.IE_CD IE_CODE1,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 AVG_CALLS, 0 CALL_TODAY,0 CALL_YESTERDAY, count(*) PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.DT_INSP_DESIRE between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) AND (sysdate-DT_INSP_DESIRE>5) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' and CALL_STATUS='M' group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					" ) group by IE_CODE1,IE,CM,DEPT,CITY order by DEPT,AREA,CITY,PENDING,IE ";
				//			string sql="Select  IE_CD,IE,CM,DEPT,CITY,HQ_AREA,CLUSTER_NAME,sum(PENDING) PENDING,SUM(STILL_UNDER_INSP) STILL_UNDER_INSP,SUM(UNDER_LAB_TESTING) UNDER_LAB_TESTING,sum(TOTAL) TOTAL, SUM(COMM_CALLS) COMM_CALLS, SUM(CALL_TODAY) CALL_TODAY,SUM(PENDING_5) PENDING_5 From " +
				//				" ( Select T09.IE_CD,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,T99.HQ_AREA,T99.CLUSTER_NAME,count(*)  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY,0 PENDING_5  from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08, T99_CLUSTER_MASTER T99 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD AND T17.CLUSTER_CODE=T99.CLUSTER_CODE AND T17.DEPARTMENT_CODE=T99.DEPARTMENT_NAME and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"'  group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T99.HQ_AREA, T99.CLUSTER_NAME" +
				//				"   union all Select T09.IE_CD,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,T99.HQ_AREA,T99.CLUSTER_NAME,0  PENDING, COUNT(*) STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY, 0 PENDING_5  from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08, T99_CLUSTER_MASTER T99  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD AND T17.CLUSTER_CODE=T99.CLUSTER_CODE AND T17.DEPARTMENT_CODE=T99.DEPARTMENT_NAME and T17.CALL_STATUS='S' and (T17.CALL_MARK_DT between to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' and T09.IE_STATUS IS NULL group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T99.HQ_AREA, T99.CLUSTER_NAME  " +
				//				"   union all Select T09.IE_CD,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,T99.HQ_AREA,T99.CLUSTER_NAME,0  PENDING, 0 STILL_UNDER_INSP,COUNT(*) UNDER_LAB_TESTING,0  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY, 0 PENDING_5  from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08, T99_CLUSTER_MASTER T99  where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD AND T17.CLUSTER_CODE=T99.CLUSTER_CODE AND T17.DEPARTMENT_CODE=T99.DEPARTMENT_NAME and T17.CALL_STATUS='U' and (T17.CALL_MARK_DT between to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' and T09.IE_STATUS IS NULL group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T99.HQ_AREA, T99.CLUSTER_NAME  " +
				//				"	union all Select T09.IE_CD,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,T99.HQ_AREA,T99.CLUSTER_NAME,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,count(*)  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY,0 PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08, T99_CLUSTER_MASTER T99 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD AND T17.CLUSTER_CODE=T99.CLUSTER_CODE AND T17.DEPARTMENT_CODE=T99.DEPARTMENT_NAME and (T17.CALL_MARK_DT between   to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T99.HQ_AREA, T99.CLUSTER_NAME"+
				//				"	union all Select T09.IE_CD,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,T99.HQ_AREA,T99.CLUSTER_NAME,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, COUNT(*) COMM_CALLS, 0 CALL_TODAY,0 PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08, T99_CLUSTER_MASTER T99 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD AND T17.CLUSTER_CODE=T99.CLUSTER_CODE AND T17.DEPARTMENT_CODE=T99.DEPARTMENT_NAME and (T17.CALL_STATUS_DT =to_date('"+ss1+"','dd/mm/yyyy')) AND CALL_STATUS IN ('A','R','G','T') and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T99.HQ_AREA, T99.CLUSTER_NAME"+	
				//				"	union all Select T09.IE_CD,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,T99.HQ_AREA,T99.CLUSTER_NAME,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 COMM_CALLS, COUNT(*) CALL_TODAY,0 PENDING_5 from T47_IE_WORK_PLAN T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08, T99_CLUSTER_MASTER T99 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD AND T17.CLUSTER_CODE=T99.CLUSTER_CODE AND T17.DEPARTMENT_CODE=T99.DEPARTMENT_NAME and (T17.VISIT_DT =to_date('"+ss1+"','dd/mm/yyyy')) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T99.HQ_AREA, T99.CLUSTER_NAME"+	
				//				"   union all Select T09.IE_CD,T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,T99.HQ_AREA,T99.CLUSTER_NAME,0  PENDING, 0 STILL_UNDER_INSP,0 UNDER_LAB_TESTING,0  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY, count(*) PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08, T99_CLUSTER_MASTER T99 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD AND T17.CLUSTER_CODE=T99.CLUSTER_CODE AND T17.DEPARTMENT_CODE=T99.DEPARTMENT_NAME and (T17.DT_INSP_DESIRE between   to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) AND (sysdate-DT_INSP_DESIRE>5) and substr(CASE_NO,1,1)='"+Session["Region"].ToString()+"' and CALL_STATUS='M' group by T09.IE_CD,T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T99.HQ_AREA, T99.CLUSTER_NAME"+
				//				" ) group by IE_CD,IE,CM,DEPT,CITY order by DEPT,HQ_AREA,CLUSTER_NAME,CITY,PENDING,IE ";


				int wSno = 0;
				string first_page = "Y";

				try
				{
					OracleCommand cmd = new OracleCommand(sql, conn);
					conn.Open();
					OracleDataReader reader = cmd.ExecuteReader();

					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr>");
					Response.Write("<td width='100%' colspan='14'>");
					if (first_page == "N")
					{ Response.Write("<p style = page-break-before:always></p>"); }
					else
					{ first_page = "N"; }
					Response.Write("</td>"); Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<td width='80%' colspan='14'>");
					Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
					Response.Write("<H5 align='center'><font face='Verdana'>SUMMARY OF IE CITY/HEADQUATER WISE CALL STATUS FROM " + wFrmDt + " TO " + wToDt + "</font><br></p>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE NAME.</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CM NAME.</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>HQ AREA</font></b></th>");
					//				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CLUSTER NAME</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PENDING</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>STILL UNDER INSP</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>UNDER LAB TESTING</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>TOTAL CALLS</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PENDING >5 DAYS</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE CITY</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE DEPT</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>TOTAL CALLS ATTENDED AS PER TODAYS WORKPLAN</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>TOTAL CALLS ATTENDED AS PER YESTERDAY WORKPLAN</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>AVERAGE CALLS</font></b></th>");

					Response.Write("</tr></font>");


					int i = 0;
					int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0;
					string HQ_AREA = "";
					while (reader.Read())
					{

						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CM"]); Response.Write("</td>");

						//					OracleCommand cmd5 =new OracleCommand("Select HQ_AREA FROM T09_IE T09, T99_CLUSTER_MASTER T99, T101_IE_CLUSTER T101 WHERE T09.IE_CD=T101.IE_CODE AND T101.CLUSTER_CODE=T99.CLUSTER_CODE and T101.DEPARTMENT_CODE=T99.DEPARTMENT_NAME AND T99.HQ_AREA IS NOT NULL AND IE_CD="+reader["IE_CD"],conn);
						//					HQ_AREA=Convert.ToString(cmd5.ExecuteScalar());
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["AREA"]); Response.Write("</td>");
						//					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["CLUSTER_NAME"]);Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["PENDING"]); Response.Write("</td>");
						t1 = t1 + Convert.ToInt32(reader["PENDING"]);
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["STILL_UNDER_INSP"]); Response.Write("</td>");
						t6 = t6 + Convert.ToInt32(reader["STILL_UNDER_INSP"]);
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["UNDER_LAB_TESTING"]); Response.Write("</td>");
						t7 = t7 + Convert.ToInt32(reader["UNDER_LAB_TESTING"]);
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["TOTAL"]); Response.Write("</td>");
						t2 = t2 + Convert.ToInt32(reader["TOTAL"]);
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["PENDING_5"]); Response.Write("</td>");
						t3 = t3 + Convert.ToInt32(reader["PENDING_5"]);
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CITY"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["DEPT"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_TODAY"]); Response.Write("</td>");
						t4 = t4 + Convert.ToInt32(reader["CALL_TODAY"]);
						Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_YESTERDAY"]); Response.Write("</td>");
						t8 = t8 + Convert.ToInt32(reader["CALL_YESTERDAY"]);
						Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["AVG_CALLS"]); Response.Write("</td>");
						t5 = t5 + Convert.ToInt32(reader["AVG_CALLS"]);
						Response.Write("</tr>");
						i++;
					};

					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='Right' colspan=4> <font size='1' face='Verdana'>Total:</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t1); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t6); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t7); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t2); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t3); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='Right' colspan=2> <font size='1' face='Verdana'></td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t4); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t8); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t5); Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("</table>");


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
			else
			{
				string sql = "Select  IE,CM,DEPT,CITY,sum(PENDING) PENDING,sum(TOTAL) TOTAL, SUM(COMM_CALLS) COMM_CALLS, SUM(CALL_TODAY) CALL_TODAY,SUM(PENDING_5) PENDING_5 From " +
					" ( Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,count(*)  PENDING,0  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY,0 PENDING_5  from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and T17.CALL_STATUS='M' and (T17.CALL_MARK_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					"	union all Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING,count(*)  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY,0 PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.CALL_MARK_DT between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					"	union all Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING,0  TOTAL, COUNT(*) COMM_CALLS, 0 CALL_TODAY,0 PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.CALL_STATUS_DT between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) AND CALL_STATUS<>'M' and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					"	union all Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING,0  TOTAL, 0 COMM_CALLS, COUNT(*) CALL_TODAY,0 PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.CALL_STATUS_DT =to_date('" + ss1 + "','dd/mm/yyyy')) AND CALL_STATUS<>'M' and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					"   union all Select T09.IE_NAME IE,T08.CO_NAME CM,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT, T03.CITY,0  PENDING,0  TOTAL, 0 COMM_CALLS, 0 CALL_TODAY, count(*) PENDING_5 from T17_CALL_REGISTER T17, T09_IE T09, T03_CITY T03,T08_IE_CONTROLL_OFFICER T08 where T17.IE_CD=T09.IE_CD and T09.IE_CITY_CD=T03.CITY_CD AND T09.IE_CO_CD=T08.CO_CD and (T17.DT_INSP_DESIRE between   to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) AND (sysdate-DT_INSP_DESIRE>5) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' and CALL_STATUS='M' group by T09.IE_NAME,T08.CO_NAME,T09.IE_DEPARTMENT, T03.CITY,T09.IE_SEAL_NO" +
					" ) group by IE,CM,DEPT,CITY order by DEPT,CITY,IE";
				int wSno = 0;
				string first_page = "Y";

				try
				{
					OracleCommand cmd = new OracleCommand(sql, conn);
					conn.Open();
					OracleDataReader reader = cmd.ExecuteReader();

					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr>");
					Response.Write("<td width='100%' colspan='10'>");
					if (first_page == "N")
					{ Response.Write("<p style = page-break-before:always></p>"); }
					else
					{ first_page = "N"; }
					Response.Write("</td>"); Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<td width='80%' colspan='10'>");
					Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
					Response.Write("<H5 align='center'><font face='Verdana'>SUMMARY OF IE CITY/HEADQUATER WISE CALL STATUS FROM " + wFrmDt + " TO " + wToDt + "</font><br></p>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE NAME.</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CO NAME.</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PENDING</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>TOTAL CALLS</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PENDING >5 DAYS</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE CITY</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE DEPT</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CALLS UPDATED YESTERDAY</font></b></th>");
					Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>COMM CALLS UPDATED</font></b></th>");

					Response.Write("</tr></font>");


					int i = 0;
					int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0;
					while (reader.Read())
					{

						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CM"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["PENDING"]); Response.Write("</td>");
						t1 = t1 + Convert.ToInt32(reader["PENDING"]);
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["TOTAL"]); Response.Write("</td>");
						t2 = t2 + Convert.ToInt32(reader["TOTAL"]);
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["PENDING_5"]); Response.Write("</td>");
						t3 = t3 + Convert.ToInt32(reader["PENDING_5"]);
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CITY"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["DEPT"]); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_TODAY"]); Response.Write("</td>");
						t4 = t4 + Convert.ToInt32(reader["CALL_TODAY"]);
						Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["COMM_CALLS"]); Response.Write("</td>");
						t5 = t5 + Convert.ToInt32(reader["COMM_CALLS"]);
						Response.Write("</tr>");
						i++;
					};

					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='Right' colspan=3> <font size='1' face='Verdana'>Total:</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t1); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t2); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t3); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='Right' colspan=2> <font size='1' face='Verdana'></td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t4); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(t5); Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("</table>");


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
		}
		void IEWiseSealingStatus()
		{

			conn.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn.Close();
			string sql = "Select  IE,SEAL_NO,sum(HOLOGRAM) HOLOGRAM,sum(POLYCARBONATE) POLYCARBONATE,sum(STEEL_PUNCH) STEEL_PUNCH,sum(LEAD_SEAL) LEAD_SEAL,sum(RUBBER_STAMP) RUBBER_STAMP,sum(STENCIL) STENCIL,sum(OTHERS) OTHERS,sum(NOT_REQUIRED) NOT_REQUIRED,sum(TOTAL_NO_OF_IC) TOTAL_NO_OF_IC From " +
				" ( Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,count(*)  HOLOGRAM,0  POLYCARBONATE,0 STEEL_PUNCH,0 LEAD_SEAL,0 RUBBER_STAMP,0 STENCIL,0 OTHERS,0 NOT_REQUIRED,0 TOTAL_NO_OF_IC from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and T20.STAMP_PATTERN_CD='H' and (T20.IC_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0  HOLOGRAM,count(*)  POLYCARBONATE,0 STEEL_PUNCH,0 LEAD_SEAL,0 RUBBER_STAMP,0 STENCIL,0 OTHERS,0 NOT_REQUIRED,0 TOTAL_NO_OF_IC from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and T20.STAMP_PATTERN_CD='P' and (T20.IC_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0  HOLOGRAM,0  POLYCARBONATE,count(*) STEEL_PUNCH,0 LEAD_SEAL,0 RUBBER_STAMP,0 STENCIL,0 OTHERS,0 NOT_REQUIRED,0 TOTAL_NO_OF_IC from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and T20.STAMP_PATTERN_CD='S' and (T20.IC_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0  HOLOGRAM,0  POLYCARBONATE,0 STEEL_PUNCH,count(*) LEAD_SEAL,0 RUBBER_STAMP,0 STENCIL,0 OTHERS,0 NOT_REQUIRED,0 TOTAL_NO_OF_IC from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and T20.STAMP_PATTERN_CD='L' and (T20.IC_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0  HOLOGRAM,0  POLYCARBONATE,0 STEEL_PUNCH,0 LEAD_SEAL,count(*) RUBBER_STAMP,0 STENCIL,0 OTHERS,0 NOT_REQUIRED,0 TOTAL_NO_OF_IC from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and T20.STAMP_PATTERN_CD='R' and (T20.IC_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0  HOLOGRAM,0  POLYCARBONATE,0 STEEL_PUNCH,0 LEAD_SEAL,0 RUBBER_STAMP,count(*) STENCIL,0 OTHERS,0 NOT_REQUIRED,0 TOTAL_NO_OF_IC from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and T20.STAMP_PATTERN_CD='T' and (T20.IC_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0  HOLOGRAM,0  POLYCARBONATE,0 STEEL_PUNCH,0 LEAD_SEAL,0 RUBBER_STAMP,0 STENCIL,count(*) OTHERS,0 NOT_REQUIRED,0 TOTAL_NO_OF_IC from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and T20.STAMP_PATTERN_CD='O' and (T20.IC_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0  HOLOGRAM,0  POLYCARBONATE,0 STEEL_PUNCH,0 LEAD_SEAL,0 RUBBER_STAMP,0 STENCIL,0 OTHERS,count(*) NOT_REQUIRED,0 TOTAL_NO_OF_IC from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and T20.STAMP_PATTERN_CD='X' and (T20.IC_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" union all Select T09.IE_NAME IE, T09.IE_SEAL_NO SEAL_NO,0  HOLOGRAM,0  POLYCARBONATE,0 STEEL_PUNCH,0 LEAD_SEAL,0 RUBBER_STAMP,0 STENCIL,0 OTHERS,0 NOT_REQUIRED,count(*) TOTAL_NO_OF_IC from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and (T20.IC_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'  group by T09.IE_NAME,T09.IE_SEAL_NO" +
				" ) group by IE,SEAL_NO order by IE,SEAL_NO";

			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='12'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='12'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>SUMMARY OF IE WISE SEALING PATTERN STATUS FROM " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='14%' valign='top'><b><font size='1' face='Verdana'>IE NAME.</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>IE SEAL No.</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>HOLOGRAM</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>POLYCARBONATE SEAL</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>STEEL PUNCH</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>LEAD SEAL</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>RUBBER STAMP</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>STENCIL</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>OTHERS</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>NOT REQUIRED</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>TOTAL</font></b></th>");
				//				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>TOTAL IC</font></b></th>");
				Response.Write("</tr></font>");

				int w_total_calls = 0;
				int i = 0;
				while (reader.Read())
				{
					w_total_calls = 0;
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='14%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["SEAL_NO"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["HOLOGRAM"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["HOLOGRAM"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["POLYCARBONATE"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["POLYCARBONATE"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["STEEL_PUNCH"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["STEEL_PUNCH"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["LEAD_SEAL"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["LEAD_SEAL"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["RUBBER_STAMP"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["RUBBER_STAMP"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["STENCIL"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["STENCIL"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["OTHERS"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["OTHERS"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["NOT_REQUIRED"]); Response.Write("</td>");
					w_total_calls = w_total_calls + Convert.ToInt32(reader["NOT_REQUIRED"]);
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(w_total_calls); Response.Write("&nbsp&nbsp</td>");
					//					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["TOTAL_NO_OF_IC"]);Response.Write("&nbsp&nbsp</td>");
					Response.Write("</tr>");
					i++;
				};

				Response.Write("</table>");
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

		void discipline_wise_billing()
		{
			//			string sql="Select v22.REGION_CODE,sum(nvl(v22.MATERIAL_VALUE,0)) Material_Value,sum(nvl(v22.INSP_FEE,0)) Fee ,decode(v22.BPO_TYPE,'R','Railways','Non-Railways') Rly_NonRly, decode(t09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') Discipline, count(*) NO_OF_IC from v22_bill v22,T09_IE t09 where (v22.bill_dt between to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy')) and t09.IE_CD=v22.ie_cd and v22.REGION_CODE='"+Session["Region"]+"' group by REGION_CODE,decode(v22.BPO_TYPE,'R','Railways','Non-Railways'),decode(t09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') order by REGION_CODE,decode(v22.BPO_TYPE,'R','Railways','Non-Railways'),decode(t09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others')";
			string sql = "Select REGION_CODE,Discipline,sum(Rly_Material_Value) Rly_Material_Value,sum(Rly_Fee) Rly_Fee,sum(Rly_No_of_IC) Rly_No_of_IC,sum(NRly_Material_Value) NRly_Material_Value,sum(NRly_Fee) NRly_Fee,sum(NRly_No_of_IC) NRly_No_of_IC,(sum(Rly_Material_Value)+sum(NRly_Material_Value))Tot_Material_Value,(sum(Rly_Fee)+sum(NRly_Fee))Tot_Fee,(sum(Rly_No_of_IC) +sum(NRly_No_of_IC))Tot_IC From " +
						"(Select v22.REGION_CODE,decode(nvl(v22.BPO_TYPE,'X'),'R','Railways','Non-Railways') Rly_NonRly, decode(t09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') Discipline, sum(nvl(v22.MATERIAL_VALUE,0)) Rly_Material_Value,sum(nvl(v22.INSP_FEE,0)) Rly_Fee ,count(*) Rly_No_of_IC,0 NRly_Material_Value,0 NRly_Fee ,0 NRly_No_of_IC from v22_bill v22,T09_IE t09 where nvl(v22.BPO_TYPE,'X')='R' and (v22.bill_dt between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and t09.IE_CD=v22.ie_cd and v22.REGION_CODE='" + Session["Region"] + "' group by REGION_CODE,decode(nvl(v22.BPO_TYPE,'X'),'R','Railways','Non-Railways'),decode(t09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') " +
						"Union All " +
						"Select v22.REGION_CODE,decode(nvl(v22.BPO_TYPE,'X'),'R','Railways','Non-Railways') Rly_NonRly, decode(t09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') Discipline, 0 Rly_Material_Value,0 Rly_Fee ,0 Rly_No_of_IC , sum(nvl(v22.MATERIAL_VALUE,0)) NRly_Material_Value,sum(nvl(v22.INSP_FEE,0)) NRly_Fee ,count(*) NRly_No_of_IC from v22_bill v22,T09_IE t09 where nvl(v22.BPO_TYPE,'X')<>'R' and (v22.bill_dt between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and t09.IE_CD=v22.ie_cd and v22.REGION_CODE='" + Session["Region"] + "' group by REGION_CODE,decode(nvl(v22.BPO_TYPE,'X'),'R','Railways','Non-Railways'),decode(t09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others')) " +
						"group by REGION_CODE,Discipline order by REGION_CODE,Discipline";

			double w_Rly_Material_Value = 0, w_Rly_Fee = 0, w_Rly_IC = 0;
			double w_NRly_Material_Value = 0, w_NRly_Fee = 0, w_NRly_IC = 0;
			double w_Tot_Material_Value = 0, w_Tot_Fee = 0, w_Tot_IC = 0;
			//			int ctr =60;
			int wSno = 0;
			//			string first_page="Y";      

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='11'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Discipline Wise Inspection Fee For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");
				Response.Write("<th width='11%' valign='top'><font size='2' face='Verdana'>Department</font></th>");
				Response.Write("<th width='28%' valign='top' colspan='3'><font size='2' face='Verdana'>Railway</font></th>");
				Response.Write("<th width='28%' valign='top' colspan='3'><font size='2' face='Verdana'>Non-Railway</font></th>");
				Response.Write("<th width='28%' valign='top' colspan='3'><font size='2' face='Verdana'>Totals (Railway + Non-Railway)</font></th>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='5%'></th>");
				Response.Write("<th width='11%'></th>");
				Response.Write("<th width='11%' valign='top'><font size='2' face='Verdana'>Material Value</font></th>");
				Response.Write("<th width='11%' valign='top'><font size='2' face='Verdana'>Insp Fee</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='2' face='Verdana'>No of IC's</font></th>");
				Response.Write("<th width='11%' valign='top'><font size='2' face='Verdana'>Material Value</font></th>");
				Response.Write("<th width='11%' valign='top'><font size='2' face='Verdana'>Insp Fee</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='2' face='Verdana'>No of IC's</font></th>");
				Response.Write("<th width='11%' valign='top'><font size='2' face='Verdana'>Material Value</font></th>");
				Response.Write("<th width='11%' valign='top'><font size='2' face='Verdana'>Insp Fee</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='2' face='Verdana'>No of IC's</font></th>");
				Response.Write("</tr>");
				while (reader.Read())
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='11%' valign='top' align='left'> <font size='2' face='Verdana'>"); Response.Write(reader["Discipline"]); Response.Write("</td>");
					Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(reader["Rly_Material_Value"]); Response.Write("</td>");
					Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(reader["Rly_Fee"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(reader["Rly_No_of_IC"]); Response.Write("</td>");
					Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(reader["NRly_Material_Value"]); Response.Write("</td>");
					Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(reader["NRly_Fee"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(reader["NRly_No_of_IC"]); Response.Write("</td>");
					Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(Convert.ToDouble(reader["Rly_Material_Value"]) + Convert.ToDouble(reader["NRly_Material_Value"])); Response.Write("</td>");
					Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(Convert.ToDouble(reader["Rly_Fee"]) + Convert.ToDouble(reader["NRly_Fee"])); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(Convert.ToDouble(reader["Rly_No_of_IC"]) + Convert.ToDouble(reader["NRly_No_of_IC"])); Response.Write("</td>");
					Response.Write("</tr>");
					w_Rly_Material_Value = w_Rly_Material_Value + Convert.ToDouble(reader["Rly_Material_Value"]);
					w_Rly_Fee = w_Rly_Fee + Convert.ToDouble(reader["Rly_Fee"]);
					w_Rly_IC = w_Rly_IC + Convert.ToDouble(reader["Rly_No_of_IC"]);
					w_NRly_Material_Value = w_NRly_Material_Value + Convert.ToDouble(reader["NRly_Material_Value"]);
					w_NRly_Fee = w_NRly_Fee + Convert.ToDouble(reader["NRly_Fee"]);
					w_NRly_IC = w_NRly_IC + Convert.ToDouble(reader["NRly_No_of_IC"]);
					w_Tot_Material_Value = w_Tot_Material_Value + Convert.ToDouble(reader["Rly_Material_Value"]) + Convert.ToDouble(reader["NRly_Material_Value"]);
					w_Tot_Fee = w_Tot_Fee + Convert.ToDouble(reader["Rly_Fee"]) + Convert.ToDouble(reader["NRly_Fee"]);
					w_Tot_IC = w_Tot_IC + Convert.ToDouble(reader["Rly_No_of_IC"]) + Convert.ToDouble(reader["NRly_No_of_IC"]);
				};
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<td width='16%' valign='top' align='right' colspan='2'> <font size='2' face='Verdana'><b>Totals ->&nbsp</td>");
				Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'><b>"); Response.Write(w_Rly_Material_Value); Response.Write("</td>");
				Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'><b>"); Response.Write(w_Rly_Fee); Response.Write("</td>");
				Response.Write("<td width='6%' valign='top' align='right'> <font size='2' face='Verdana'><b>"); Response.Write(w_Rly_IC); Response.Write("</td>");
				Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'><b>"); Response.Write(w_NRly_Material_Value); Response.Write("</td>");
				Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'><b>"); Response.Write(w_NRly_Fee); Response.Write("</td>");
				Response.Write("<td width='6%' valign='top' align='right'> <font size='2' face='Verdana'><b>"); Response.Write(w_NRly_IC); Response.Write("</td>");
				Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'><b>"); Response.Write(w_Tot_Material_Value); Response.Write("</td>");
				Response.Write("<td width='11%' valign='top' align='right'> <font size='2' face='Verdana'><b>"); Response.Write(w_Tot_Fee); Response.Write("</td>");
				Response.Write("<td width='6%' valign='top' align='right'> <font size='2' face='Verdana'><b>"); Response.Write(w_Tot_IC); Response.Write("</td>");
				Response.Write("</b></tr>");
				Response.Write("</table>");
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
		void summary_ic_submitted()
		{
			string sql = "select to_char(IC_SUBMIT_DT,'dd/mm/yyyy') IC_SUBMIT_DATE,T09.IE_NAME,T20.BK_NO,T20.SET_NO from T20_IC T20, T09_IE T09 where T20.IE_CD=T09.IE_CD and (T20.IC_SUBMIT_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and substr(T20.CASE_NO,1,1)='" + Session["Region"] + "'" +
				" order by T20.IC_SUBMIT_DT,T09.IE_CD,T20.BK_NO,T20.SET_NO";


			int wSno = 0;

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='60%'>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='5'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>IC Submission Report For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>IC Submit Date</font></th>");
				Response.Write("<th width='45%' valign='top'><font size='2' face='Verdana'>IE</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>BK NO.</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>SET No.</font></th>");
				Response.Write("</tr>");

				while (reader.Read())
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["IC_SUBMIT_DATE"]); Response.Write("</td>");
					Response.Write("<td width='45%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
					Response.Write("</tr>");

				};

				Response.Write("</table>");
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

		void ic_issued_notsubmitted()
		{
			//			string sql="Select to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy') IC_ISSUED_DT,T17.BK_NO,T17.SET_NO,T09.IE_NAME from T17_CALL_REGISTER T17 left join T30_IC_RECEIVED T30 on (T17.BK_NO = T30.BK_NO and T17.SET_NO=T30.SET_NO and T17.REGION_CODE=T30.REGION), T09_IE T09 where (T30.BK_NO is null and T30.SET_NO is null and T30.REGION is null) and T17.IE_CD=T09.IE_CD and substr(T17.CASE_NO,1,1)='"+Session["Region"]+"' and T17.CALL_STATUS in ('A','R') and (T17.CALL_STATUS_DT between to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy') ) Order by T17.CALL_STATUS_DT,T09.IE_NAME,T17.BK_NO,T17.SET_NO " ;
			string sql = "";
			if (Convert.ToString(Session["Uname"]) != "")
			{
				sql = "Select to_char(CALL_STATUS_DT,'dd/mm/yyyy') IC_ISSUED_DT,a.BK_NO,a.SET_NO,a.IE_NAME,a.CO_NAME,a.CASE_NO,a.PO_SOURCE,a.PO_YR,a.PO_NO, a.IMMS_RLY_CD, a.RLY_NONRLY from ( Select T17.CASE_NO,T17.CALL_STATUS_DT,'dd/mm/yyyy',T17.BK_NO,T17.SET_NO,T09.IE_NAME,T08.CO_NAME,PO_SOURCE,TO_CHAR(PO_DT,'YYYY') PO_YR, PO_NO, NVL((SELECT IMMS_RLY_CD FROM T91_RAILWAYS T91 WHERE T13.RLY_CD=T91.RLY_CD),'') IMMS_RLY_CD, RLY_NONRLY from T17_CALL_REGISTER T17 left join T30_IC_RECEIVED T30 on (T17.BK_NO = T30.BK_NO and T17.SET_NO=T30.SET_NO and T17.REGION_CODE=T30.REGION), T09_IE T09, T08_IE_CONTROLL_OFFICER T08, T13_PO_MASTER T13 where (T30.BK_NO is null and T30.SET_NO is null and T30.REGION is null) and T17.IE_CD=T09.IE_CD and T09.IE_CO_CD=T08.CO_CD AND T17.CASE_NO=T13.CASE_NO AND substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' and T17.CALL_STATUS in ('A','R','G','T') and (T17.CALL_STATUS_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy') ) ) a left join T20_IC T20 on (a.BK_NO=T20.BK_NO and a.SET_NO=T20.SET_NO and a.CASE_NO=T20.CASE_NO) where (T20.BK_NO is null and T20.SET_NO is null and T20.CASE_NO is null) Order by a.CO_NAME,a.CALL_STATUS_DT,a.BK_NO,a.SET_NO ";
			}
			else if (Convert.ToString(Session["IE_CD"]) != "")
			{
				sql = "Select to_char(CALL_STATUS_DT,'dd/mm/yyyy') IC_ISSUED_DT,a.BK_NO,a.SET_NO,a.IE_NAME,a.CO_NAME,a.CASE_NO,a.PO_SOURCE,a.PO_YR,a.PO_NO, a.IMMS_RLY_CD, a.RLY_NONRLY from ( Select T17.CASE_NO,T17.CALL_STATUS_DT,'dd/mm/yyyy',T17.BK_NO,T17.SET_NO,T09.IE_NAME,T08.CO_NAME,PO_SOURCE,TO_CHAR(PO_DT,'YYYY') PO_YR, PO_NO, NVL((SELECT IMMS_RLY_CD FROM T91_RAILWAYS T91 WHERE T13.RLY_CD=T91.RLY_CD),'') IMMS_RLY_CD, RLY_NONRLY from T17_CALL_REGISTER T17 left join T30_IC_RECEIVED T30 on (T17.BK_NO = T30.BK_NO and T17.SET_NO=T30.SET_NO and T17.REGION_CODE=T30.REGION), T09_IE T09, T08_IE_CONTROLL_OFFICER T08, T13_PO_MASTER T13 where (T30.BK_NO is null and T30.SET_NO is null and T30.REGION is null) and T17.IE_CD=T09.IE_CD and T09.IE_CO_CD=T08.CO_CD AND T17.CASE_NO=T13.CASE_NO and substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' and T17.IE_CD='" + Convert.ToString(Session["IE_CD"]) + "' and T17.CALL_STATUS in ('A','R','G','T') and (T17.CALL_STATUS_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy') ) ) a left join T20_IC T20 on (a.BK_NO=T20.BK_NO and a.SET_NO=T20.SET_NO and a.CASE_NO=T20.CASE_NO) where (T20.BK_NO is null and T20.SET_NO is null and T20.CASE_NO is null) Order by a.IE_NAME,a.CALL_STATUS_DT,a.BK_NO,a.SET_NO ";
			}

			int wSno = 0;
			int wSno_1 = 0;

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='80%'>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='9'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>IC Issued but not Received in Office For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");

				if (RdbCM.Checked == true)
				{
					Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>CM S.No.</font></th>");
					Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>IC Issue Date</font></th>");
					Response.Write("<th width='30%' valign='top'><font size='2' face='Verdana'>CM</font></th>");
					Response.Write("<th width='30%' valign='top'><font size='2' face='Verdana'>IE</font></th>");

				}
				else
				{
					Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>IE S.No.</font></th>");
					Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>IC Issue Date</font></th>");
					Response.Write("<th width='30%' valign='top'><font size='2' face='Verdana'>IE</font></th>");
					Response.Write("<th width='30%' valign='top'><font size='2' face='Verdana'>CM</font></th>");


				}
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>BK NO.</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>SET No.</font></th>");
				Response.Write("<th width='30%' valign='top'><font size='2' face='Verdana'>Digital IC</font></th>");
				Response.Write("<th width='30%' valign='top'><font size='2' face='Verdana'>PO</font></th>");
				Response.Write("</tr>");
				string wIE = "";



				while (reader.Read())
				{
					wSno_1 = wSno_1 + 1;
					if (RdbIE.Checked == true)
					{
						if (wIE == reader["IE_NAME"].ToString())
						{
							wSno = wSno + 1;
							Response.Write("<tr>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno_1 + "</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["IC_ISSUED_DT"]); Response.Write("</td>");
							Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
							Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader["CASE_NO"] + "-" + reader["BK_NO"] + "-" + reader["SET_NO"] + ".PDF' Font-Names='Verdana' Font-Size='8pt'>IC</a></td>");


							if (reader["RLY_NONRLY"].ToString() == "R" && reader["PO_SOURCE"].ToString() == "C")
							{
								//""+Convert.ToString(readerB["PO_YR"])+"/"++"/"++".pdf";

								Response.Write("<td width='10%' valign='top' align='center'><a href='https://www.ireps.gov.in/ireps/etender/pdfdocs/MMIS/PO/" + Convert.ToString(reader["PO_YR"]) + "/" + Convert.ToString(reader["IMMS_RLY_CD"]) + "/" + Convert.ToString(reader["PO_NO"]) + ".pdf' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
							}
							else
							{
								string fpath = Server.MapPath("/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".TIF");
								string fpath1 = Server.MapPath("/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".PDF");
								if (File.Exists(fpath) == true)
								{
									Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
								}
								else if (File.Exists(fpath1) == true)
								{
									Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
								}
								else
								{

									Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
								}
							}


							Response.Write("</tr>");
						}
						else
						{
							wSno = 0;
							wIE = reader["IE_NAME"].ToString();
							wSno = wSno + 1;
							Response.Write("<tr>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno_1 + "</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["IC_ISSUED_DT"]); Response.Write("</td>");
							Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
							Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader["CASE_NO"] + "-" + reader["BK_NO"] + "-" + reader["SET_NO"] + ".PDF' Font-Names='Verdana' Font-Size='8pt'>IC</a></td>");
							if (reader["RLY_NONRLY"].ToString() == "R" && reader["PO_SOURCE"].ToString() == "C")
							{
								//""+Convert.ToString(readerB["PO_YR"])+"/"++"/"++".pdf";

								Response.Write("<td width='10%' valign='top' align='center'><a href='https://www.ireps.gov.in/ireps/etender/pdfdocs/MMIS/PO/" + Convert.ToString(reader["PO_YR"]) + "/" + Convert.ToString(reader["IMMS_RLY_CD"]) + "/" + Convert.ToString(reader["PO_NO"]) + ".pdf' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
							}
							else
							{
								string fpath = Server.MapPath("/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".TIF");
								string fpath1 = Server.MapPath("/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".PDF");
								if (File.Exists(fpath) == true)
								{
									Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
								}
								else if (File.Exists(fpath1) == true)
								{
									Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
								}
								else
								{

									Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
								}
							}



							Response.Write("</tr>");
						}
					}
					else
					{
						if (wIE == reader["CO_NAME"].ToString())
						{
							wSno = wSno + 1;
							Response.Write("<tr>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno_1 + "</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["IC_ISSUED_DT"]); Response.Write("</td>");
							Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
							Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader["CASE_NO"] + "-" + reader["BK_NO"] + "-" + reader["SET_NO"] + ".PDF' Font-Names='Verdana' Font-Size='8pt'>IC</a></td>");
							if (reader["RLY_NONRLY"].ToString() == "R" && reader["PO_SOURCE"].ToString() == "C")
							{
								//""+Convert.ToString(readerB["PO_YR"])+"/"++"/"++".pdf";

								Response.Write("<td width='10%' valign='top' align='center'><a href='https://www.ireps.gov.in/ireps/etender/pdfdocs/MMIS/PO/" + Convert.ToString(reader["PO_YR"]) + "/" + Convert.ToString(reader["IMMS_RLY_CD"]) + "/" + Convert.ToString(reader["PO_NO"]) + ".pdf' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
							}
							else
							{
								string fpath = Server.MapPath("/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".TIF");
								string fpath1 = Server.MapPath("/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".PDF");
								if (File.Exists(fpath) == true)
								{
									Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
								}
								else if (File.Exists(fpath1) == true)
								{
									Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
								}
								else
								{

									Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
								}
							}

							Response.Write("</tr>");
						}
						else
						{
							wSno = 0;
							wIE = reader["CO_NAME"].ToString();
							wSno = wSno + 1;
							Response.Write("<tr>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno_1 + "</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["IC_ISSUED_DT"]); Response.Write("</td>");
							Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
							Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader["CASE_NO"] + "-" + reader["BK_NO"] + "-" + reader["SET_NO"] + ".PDF' Font-Names='Verdana' Font-Size='8pt'>IC</a></td>");
							if (reader["RLY_NONRLY"].ToString() == "R" && reader["PO_SOURCE"].ToString() == "C")
							{
								//""+Convert.ToString(readerB["PO_YR"])+"/"++"/"++".pdf";

								Response.Write("<td width='10%' valign='top' align='center'><a href='https://www.ireps.gov.in/ireps/etender/pdfdocs/MMIS/PO/" + Convert.ToString(reader["PO_YR"]) + "/" + Convert.ToString(reader["IMMS_RLY_CD"]) + "/" + Convert.ToString(reader["PO_NO"]) + ".pdf' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
							}
							else
							{
								string fpath = Server.MapPath("/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".TIF");
								string fpath1 = Server.MapPath("/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".PDF");
								if (File.Exists(fpath) == true)
								{
									Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
								}
								else if (File.Exists(fpath1) == true)
								{
									Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/" + reader["CASE_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CASE_NO"].ToString() + "</font></a>"); Response.Write("</td>");
								}
								else
								{

									Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
								}
							}

							Response.Write("</tr>");
						}

					}
				};

				Response.Write("</table>");
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

		void AorRcallswithoutIC()
		{
			string sql = "Select T17.CASE_NO,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_DT,T17.CALL_SNO,decode(T17.CALL_STATUS,'A','Accepted','R','Rejected','M','Pending','B','Accepted and Billed')STATUS,T09.IE_NAME, decode(T09.IE_STATUS,'R','Retired','T','Transferred','L','Left/Repatriated','Working') IE_STATUS from T17_CALL_REGISTER T17 left join T20_IC T20 on (T17.CASE_NO = T20.CASE_NO and T17.CALL_RECV_DT=T20.CALL_RECV_DT and T17.CALL_SNO=T20.CALL_SNO), T09_IE T09 where (T20.CASE_NO is null and T20.CALL_SNO is null and T20.CALL_RECV_DT is null) and T17.IE_CD=T09.IE_CD and substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' and T17.CALL_STATUS in ('A','R','M') and (T17.CALL_RECV_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy') )" +
				"Order by T09.IE_NAME,T17.CALL_STATUS, T17.CALL_RECV_DT,T17.CASE_NO ";


			int wSno = 0;

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='90%'>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='7'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Pending IC against calls where material has been Accepted or Rejected and Pending, For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>CASE NO.</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>CALL DATE</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>CALL SNO</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>CALL STATUS</font></th>");
				Response.Write("<th width='35%' valign='top'><font size='2' face='Verdana'>IE</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>IE STATUS</font></th>");
				Response.Write("</tr>");

				while (reader.Read())
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CALL_DT"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["STATUS"]); Response.Write("</td>");
					Response.Write("<td width='35%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_STATUS"]); Response.Write("</td>");
					Response.Write("</tr>");

				};

				Response.Write("</table>");
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

		void contract_review()
		{
			string mySql = "Select decode(RLY_NONRLY,'R','1Railways','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government')BPO_TYPE,RLY_CD,sum(CALLS) CALLS,sum(CALL_ATTENDED) CALLS_ATTENDED,sum(CALL_CANCEL) CALLS_CANCELLED,sum(REJECTIONS) CALLS_REJECTED,sum(DELAYED) CALLS_DELAYED From " +
				"(SELECT A.RLY_NONRLY RLY_NONRLY,A.RLY_CD RLY_CD,COUNT(*) CALLS,0 CALL_ATTENDED,0 CALL_CANCEL,0 REJECTIONS,0 DELAYED FROM T13_PO_MASTER A,T17_CALL_REGISTER B " +
				"WHERE A.CASE_NO=B.CASE_NO AND (B.CALL_MARK_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND A.REGION_CODE='" + Session["Region"].ToString() + "' GROUP BY A.RLY_NONRLY,A.RLY_CD " +
				"union all " +
				"SELECT A.RLY_NONRLY RLY_NONRLY,A.RLY_CD RLY_CD,0 CALLS,COUNT(*) CALL_ATTENDED,0 CALL_CANCEL,0 REJECTIONS,0 DELAYED FROM T13_PO_MASTER A,T17_CALL_REGISTER B " +
				"WHERE A.CASE_NO=B.CASE_NO AND (B.CALL_MARK_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND A.REGION_CODE='" + Session["Region"].ToString() + "' and (NVL(B.CALL_STATUS,'X') not in ('M','W')) GROUP BY A.RLY_NONRLY,A.RLY_CD " +
				"union all " +
				"SELECT A.RLY_NONRLY RLY_NONRLY,A.RLY_CD RLY_CD,0 CALLS,0 CALL_ATTENDED,COUNT(*) CALL_CANCEL,0 REJECTIONS,0 DELAYED FROM T13_PO_MASTER A,T19_CALL_CANCEL B " +
				"WHERE A.CASE_NO=B.CASE_NO and (B.CALL_RECV_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND A.REGION_CODE='" + Session["Region"].ToString() + "' GROUP BY A.RLY_NONRLY,A.RLY_CD " +
				"union all " +
				"SELECT A.RLY_NONRLY RLY_NONRLY,A.RLY_CD RLY_CD,0 CALLS,0 CALL_ATTENDED,0 CALL_CANCEL,COUNT(*) REJECTIONS,0 DELAYED FROM T13_PO_MASTER A,T17_CALL_REGISTER B " +
				"WHERE A.CASE_NO=B.CASE_NO AND (B.CALL_MARK_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND A.REGION_CODE='" + Session["Region"].ToString() + "' and NVL(B.CALL_STATUS,'X')='R' GROUP BY A.RLY_NONRLY,A.RLY_CD " +
				"union all " +
				"SELECT A.RLY_NONRLY RLY_NONRLY,A.RLY_CD RLY_CD,0 CALLS,0 CALL_ATTENDED,0 CALL_CANCEL,0 REJECTIONS,COUNT(*) DELAYED FROM T13_PO_MASTER A,T17_CALL_REGISTER B " +
				"WHERE A.CASE_NO=B.CASE_NO AND (B.CALL_MARK_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND A.REGION_CODE='" + Session["Region"].ToString() + "' and (NVL(B.CALL_STATUS,'X') not in ('M','W')) and (nvl(B.CALL_STATUS_DT,B.CALL_MARK_DT)-B.CALL_MARK_DT >7) GROUP BY A.RLY_NONRLY,A.RLY_CD) " +
				"Group By decode(RLY_NONRLY,'R','1Railways','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government'),RLY_CD " +
				"Order By decode(RLY_NONRLY,'R','1Railways','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government'),RLY_CD";
			try
			{
				OracleCommand cmd = new OracleCommand(mySql, conn);
				conn.Open();
				OracleDataAdapter da = new OracleDataAdapter(mySql, conn);
				DataSet dsP = new DataSet();
				da.SelectCommand = cmd;
				da.Fill(dsP, "Table");
				int t1 = 0, t11 = 0, t2 = 0, t22 = 0, t4 = 0, t44 = 0, t5 = 0, t55 = 0, t6 = 0, t66 = 0;
				int ctr = 70;
				string first_page = "Y";
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					if (ctr > 60)
					{
						Response.Write("<table border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='6'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("</table>");
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='6'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>Client Wise Contract Review Statement For the Period : " + wFrmDt + " to " + wToDt + "</font></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='40%' valign='top' align='center'><b><font size='2' face='Verdana'>Railway/Client</font></b></th>");
						Response.Write("<th width='12%' valign='top' align='center'><b><font size='2' face='Verdana'>Calls Received</font></b></th>");
						Response.Write("<th width='12%' valign='top' align='center'><b><font size='2' face='Verdana'>Calls Attended</font></b></th>");
						Response.Write("<th width='12%' valign='top' align='center'><b><font size='2' face='Verdana'>Calls Cancelled</font></b></th>");
						Response.Write("<th width='12%' valign='top' align='center'><b><font size='2' face='Verdana'>Calls Rejected</font></b></th>");
						Response.Write("<th width='12%' valign='top' align='center'><b><font size='2' face='Verdana'>Calls Delayed</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 5;
					};
					if ((i >= 1))
					{
						if ((dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString().Equals(dsP.Tables[0].Rows[i - 1]["BPO_TYPE"].ToString()) == false))
						{
							Response.Write("<tr>");
							Response.Write("<td width='13%' valign='top' align='center' colspan=6 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"); Response.Write(dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString().Substring(1)); Response.Write("</b></td>");
							Response.Write("</tr>");
						}
					}
					else
					{
						Response.Write("<tr>");
						Response.Write("<td width='13%' valign='top' align='center' colspan=6 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"); Response.Write(dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString().Substring(1)); Response.Write("</b></td>");
						Response.Write("</tr>");
					}
					Response.Write("<tr>");
					Response.Write("<td width='40%' valign='top' align='Left'><b><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["RLY_CD"].ToString() + "</font></b></td>");
					Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["CALLS"].ToString() + "</font></b></td>");
					t1 = t1 + Convert.ToInt32(dsP.Tables[0].Rows[i]["CALLS"]);
					t11 = t11 + Convert.ToInt32(dsP.Tables[0].Rows[i]["CALLS"]);
					Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["CALLS_ATTENDED"].ToString() + "</font></b></td>");
					t2 = t2 + Convert.ToInt32(dsP.Tables[0].Rows[i]["CALLS_ATTENDED"]);
					t22 = t22 + Convert.ToInt32(dsP.Tables[0].Rows[i]["CALLS_ATTENDED"]);
					Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["CALLS_CANCELLED"].ToString() + "</font></b></td>");
					t4 = t4 + Convert.ToInt32(dsP.Tables[0].Rows[i]["CALLS_CANCELLED"]);
					t44 = t44 + Convert.ToInt32(dsP.Tables[0].Rows[i]["CALLS_CANCELLED"]);
					Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["CALLS_REJECTED"].ToString() + "</font></b></td>");
					t5 = t5 + Convert.ToInt32(dsP.Tables[0].Rows[i]["CALLS_REJECTED"]);
					t55 = t55 + Convert.ToInt32(dsP.Tables[0].Rows[i]["CALLS_REJECTED"]);
					Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["CALLS_DELAYED"].ToString() + "</font></b></td>");
					t6 = t6 + Convert.ToInt32(dsP.Tables[0].Rows[i]["CALLS_DELAYED"]);
					t66 = t66 + Convert.ToInt32(dsP.Tables[0].Rows[i]["CALLS_DELAYED"]);
					Response.Write("</tr>");
					ctr = ctr + 1;
					if ((i < dsP.Tables[0].Rows.Count - 1))
					{
						if ((dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString().Equals(dsP.Tables[0].Rows[i + 1]["BPO_TYPE"].ToString()) == false))
						{
							Response.Write("<tr bgColor='#d4d0c8'>");
							Response.Write("<td width='40%' valign='top' align='center'><b><font size='1' face='Verdana'>Total For " + dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString().Substring(1) + ": </font></b></td>");
							Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t11 + "</font></b></td>");
							Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t22 + "</font></b></td>");
							Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t44 + "</font></b></td>");
							Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t55 + "</font></b></td>");
							Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t66 + "</font></b></td>");
							Response.Write("</tr>");
							t11 = 0; t22 = 0; t44 = 0; t55 = 0; t66 = 0;
						}
					}
					else
					{
						Response.Write("<tr bgColor='#d4d0c8'>");
						Response.Write("<td width='40%' valign='top' align='center'><b><font size='1' face='Verdana'>Total For " + dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString().Substring(1) + " : </font></b></td>");
						Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t11 + "</font></b></td>");
						Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t22 + "</font></b></td>");
						Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t44 + "</font></b></td>");
						Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t55 + "</font></b></td>");
						Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t66 + "</font></b></td>");
						Response.Write("</tr>");
						t11 = 0; t22 = 0; t44 = 0; t55 = 0; t66 = 0;
					}
				}
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<td width='40%' valign='top' align='center'><b><font size='1' face='Verdana'>Grand Total:</font></b></td>");
				Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t1 + "</font></b></td>");
				Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t2 + "</font></b></td>");
				Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t4 + "</font></b></td>");
				Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t5 + "</font></b></td>");
				Response.Write("<td width='12%' valign='top' align='right'><b><font size='1' face='Verdana'>" + t6 + "</font></b></td>");
				Response.Write("</tr>");
				conn.Close();
				Response.Write("</table><br>");
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

		void summary_calls_cancelled()
		{
			string sql = "Select T13.RLY_CD, T09.IE_NAME,V05.VENDOR,T19.CASE_NO,TO_CHAR(T19.CALL_RECV_DT,'DD/MM/YYYY')CALL_RECV_DT,TO_CHAR(T19.CANCEL_DATE,'DD/MM/YYYY')CANCEL_DT,Decode(T17.CALL_CANCEL_STATUS,'C','Chargeable','N','Non-Chargeable') CALL_CANCEL_STATUS,T17.CALL_CANCEL_CHARGES," +
				" trim(decode(T19.CANCEL_CD_1,0,' ',12,' ',' (1) '||T11_01.CANCEL_DESC)||" +
				" decode(T19.CANCEL_CD_2,0,' ',12,' ',' (2) '||T11_02.CANCEL_DESC)||decode(T19.CANCEL_CD_3,0,' ',12,' ',' (3) '||T11_03.CANCEL_DESC)||" +
				" decode(T19.CANCEL_CD_4,0,' ',12,' ',' (4) '||T11_04.CANCEL_DESC)||decode(T19.CANCEL_CD_5,0,' ',12,' ',' (5) '||T11_05.CANCEL_DESC)||" +
				" decode(T19.CANCEL_CD_6,0,' ',12,' ',' (6) '||T11_06.CANCEL_DESC)||decode(T19.CANCEL_CD_7,0,' ',12,' ',' (7) '||T11_07.CANCEL_DESC)||" +
				" decode(T19.CANCEL_CD_8,0,' ',12,' ',' (8) '||T11_08.CANCEL_DESC)||decode(T19.CANCEL_CD_9,0,' ',12,' ',' (9) '||T11_09.CANCEL_DESC)||" +
				" decode(T19.CANCEL_CD_10,0,' ',12,' ',' (10) '||T11_10.CANCEL_DESC)||decode(T19.CANCEL_CD_11,0,' ',12,' ',' (11) '||T11_11.CANCEL_DESC)||" +
				" decode(T19.CANCEL_DESC,'',' ',' --> '||T19.CANCEL_DESC))||' ' CANCEL_REASON From T17_CALL_REGISTER T17,T13_PO_MASTER T13,T19_CALL_CANCEL T19,T09_IE T09,V05_VENDOR V05," +
				" T11_CALL_CANCEL_CODES T11_01,T11_CALL_CANCEL_CODES T11_02,T11_CALL_CANCEL_CODES T11_03,T11_CALL_CANCEL_CODES T11_04,T11_CALL_CANCEL_CODES T11_05,T11_CALL_CANCEL_CODES T11_06,T11_CALL_CANCEL_CODES T11_07,T11_CALL_CANCEL_CODES T11_08,T11_CALL_CANCEL_CODES T11_09,T11_CALL_CANCEL_CODES T11_10,T11_CALL_CANCEL_CODES T11_11" +
				" Where T17.CASE_NO=T19.CASE_NO  And T17.CALL_RECV_DT=T19.CALL_RECV_DT And T17.CALL_SNO=T19.CALL_SNO and T19.CASE_NO=T13.CASE_NO And T19.CANCEL_CD_1=T11_01.CANCEL_CD(+) And T19.CANCEL_CD_2=T11_02.CANCEL_CD(+) And T19.CANCEL_CD_3=T11_03.CANCEL_CD(+) And T19.CANCEL_CD_4=T11_04.CANCEL_CD(+) And T19.CANCEL_CD_5=T11_05.CANCEL_CD(+) And T19.CANCEL_CD_6=T11_06.CANCEL_CD(+) And T19.CANCEL_CD_7=T11_07.CANCEL_CD(+) And T19.CANCEL_CD_8=T11_08.CANCEL_CD(+) And T19.CANCEL_CD_9=T11_09.CANCEL_CD(+) And T19.CANCEL_CD_10=T11_10.CANCEL_CD(+) And T19.CANCEL_CD_11=T11_11.CANCEL_CD(+) And T17.IE_CD=T09.IE_CD And T13.VEND_CD=V05.VEND_CD And substr(T19.CASE_NO,1,1)='" + Session["Region"].ToString() + "'" +
				" and (T19.CANCEL_DATE between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) Order By T17.CALL_CANCEL_STATUS,T09.IE_NAME,V05.VENDOR,T19.CANCEL_DATE";

			int wSno = 0;
			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='11'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Statement of IE & Vendor Wise Calls Cancelled during the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IE_NAME</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>VENDOR</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CLIENT</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CASE NO.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CALL DATE</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CANCEL DATE</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>CANCEL REASONS</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CANCEL STATUS</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CANCEL CHARGES</font></b></th>");
				Response.Write("</tr></font>");
				//				string wIE_NAME="";
				//				string wVENDOR="";
				while (reader.Read())
				{
					//					if (wIE_NAME==reader["IE_NAME"].ToString())
					//					{
					//						if(wVENDOR==reader["VENDOR"].ToString())
					//						{
					//							wSno = wSno+1;
					//							Response.Write("<tr>");
					//							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"+wSno+"</td>");
					//							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(" ");Response.Write("</td>");
					//							Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write("-do-");Response.Write("</td>");
					//							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CASE_NO"]);Response.Write("</td>");
					//							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CALL_RECV_DT"]);Response.Write("</td>");
					//							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CANCEL_DT"]);Response.Write("</td>");
					//							Response.Write("<td width='25%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["CANCEL_REASON"]);Response.Write("</td>");
					//							Response.Write("<td width='30%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["CALL_CANCEL_STATUS"]);Response.Write("</td>");
					//							Response.Write("<td width='30%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["CALL_CANCEL_CHARGES"]);Response.Write("</td>");
					//							Response.Write("</tr>");
					//						}
					//						else
					//						{
					//							wSno = wSno+1;
					//							Response.Write("<tr>");
					//							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"+wSno+"</td>");
					//							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(" ");Response.Write("</td>");
					//							Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["VENDOR"]);Response.Write("</td>");
					//							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CASE_NO"]);Response.Write("</td>");
					//							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CALL_RECV_DT"]);Response.Write("</td>");
					//							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CANCEL_DT"]);Response.Write("</td>");
					//							Response.Write("<td width='25%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["CANCEL_REASON"]);Response.Write("</td>");
					//							Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["CALL_CANCEL_STATUS"]);Response.Write("</td>");
					//							Response.Write("<td width='30%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["CALL_CANCEL_CHARGES"]);Response.Write("</td>");
					//							Response.Write("</tr>");
					//							wVENDOR=reader["VENDOR"].ToString();
					//						}
					//					}
					//					else
					//					{
					wSno = wSno + 1;
					//						if (wSno != 1)
					//						{
					//							Response.Write("<tr bgColor='#d4d0c8'>");
					//							Response.Write("<td width='100%' colspan='8' height='5'></td>");
					//							Response.Write("</tr>");
					//						}
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["RLY_CD"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_RECV_DT"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CANCEL_DT"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CANCEL_REASON"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_CANCEL_STATUS"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_CANCEL_CHARGES"]); Response.Write("</td>");
					Response.Write("</tr>");
					//						wIE_NAME=reader["IE_NAME"].ToString();
					//					}
				};

				Response.Write("</table>");
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

		void NEW_SERVICE_TAX()
		{
			OracleCommand cmd = new OracleCommand();
			string mySql = "Select IC_DATE,BILL_NO,BILL_DATE,BILL_AMOUNT,SERV_TAX_RATE,SERVICE_TAX,BILLING_TIME,DELAY,round(SERVICE_TAX * .18 * Delay / 365,2) PENALTY From " +
				"(Select to_char(IC_DT,'dd/mm/yyyy')IC_DATE,BILL_NO,to_char(BILL_DT,'dd/mm/yyyy')BILL_DATE,BILL_AMOUNT,SERV_TAX_RATE,SERVICE_TAX,(BILL_DT-IC_DT) BILLING_TIME, (Case When BILL_DT-IC_DT > 14 Then (BILL_DT-IC_DT-14) Else 0 End) DELAY " +
				"From V22_BILL " +
				"Where (BILL_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and (nvl(TAX_TYPE,'X')<> 'N')" +
				") order by BILL_NO";
			decimal wtStaxDue = 0;
			int wSno = 0;
			try
			{
				cmd.CommandText = mySql;
				cmd.Connection = conn;
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr><td width='100%' colspan='11'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Service Tax Computation Sheet For The Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Bill Date.</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>IC Date</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Billing Time<br>(in Days)</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Delay Beyond 14 Days</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Bill Amount (Rs.)</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Service Tax Rate (%)</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Service Tax (Rs.)<br>(as per bill)</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Int On Service Tax @ 18% p.a for Delay (Rs.)</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Service Tax Due (Rs.)</font></b></th>");
				Response.Write("</tr></font>");
				while (reader.Read())
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='9%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DATE"]); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IC_DATE"]); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BILLING_TIME"]); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["DELAY"]); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["SERV_TAX_RATE"]); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["SERVICE_TAX"]); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["PENALTY"]); Response.Write("</td>");
					wtStaxDue = Convert.ToDecimal(reader["SERVICE_TAX"]) + Convert.ToDecimal(reader["PENALTY"]);
					Response.Write("<td width='9%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wtStaxDue); Response.Write("</td>");
					Response.Write("</tr>");
				}
				Response.Write("</table>");
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

		private void rdbPCM_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbPCM.Checked == true)
			{
				lstCO.Visible = true;
			}
			else
			{
				lstCO.Visible = false;
			}
		}

		private void rdbAllSector_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbPSector.Checked == true)
			{
				ddlItemScope.Visible = true;
			}
			else
			{
				ddlItemScope.Visible = false;

			}
		}

		void LAB_INVOICE_RPT()
		{
			Response.Write("<html><body>");
			Response.Write("<p align='center'>&nbsp</font></p>");
			Response.Write("<p align='center'><H5 align='center'><font face='Verdana'>RITES LTD.</font></p>");
			//Response.Write("<p align='center'><font size='2' face='Verdana'>NORTHERN REGION(INSPECTION) 12th FLOOR, CORE -II, SCOPE MINAR, LAXMI NAGAR</font></p>");
			Response.Write("<p><H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
			//Response.Write("<p align='center'><font size='2' face='Verdana'>GSTIN : 07AAACR0830Q1Z8</font></p>");
			Response.Write("<p align='center'><H5 align='center'><font face='Verdana'>LAB INVOICE DETAILS FOR THE PERIOD : " + wFrmDt + " to " + wToDt + "</font><br></p>");
			Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='90%'>");
			Response.Write("</tr></font>");
			Response.Write("<tr>");
			Response.Write("<th width='3%' valign='top' align='center'><b><font size='2' face='Verdana'>S. NO.</font></b></th>");
			Response.Write("<th width='20%' valign='top' align='center'><b><font size='2' face='Verdana'>Name of Party</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>GSTIN</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>State CD</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>Invoice No.</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>Invoice Date</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='2' face='Verdana'>Type (L/C)</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='2' face='Verdana'>HSN Code</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>Invoice Type(N/C)</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>Invoice Value</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>Amount(Without Tax)</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>SGST</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>CGST</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>IGST</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>Total GST</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>Bill Finalised</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>Sent to Sap</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>IRN_NO</font></b></th>");
			Response.Write("</tr></font>");
			//Response.Write("<tr>");

			string strdata = "select (B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO_NAME," +
				"t55.recipient_gstin_no recipient_gstin_no,SUBSTR(t55.recipient_gstin_no,0,2) St_cd, t55.invoice_no invoice_no,to_char(t55.invoice_dt, 'dd/mm/yyyy') invoice_dt,Round(to_number(t55.bill_amount + t55.total_cgst + t55.total_igst + t55.total_sgst)) Total_AMT," +
				"Case when (t92.state_cd=7 AND t55.region_code='N') then 'Local' when (t92.state_cd=27 AND t55.region_code='W') then 'Local' when (t92.state_cd=33 AND t55.region_code='S') then 'Local' else 'Central' end as INV_TYPE, '998346' as HSN_CD, t55.bill_amount INV_amount, t55.total_sgst INV_sgst, t55.total_cgst INV_cgst, t55.total_igst INV_igst, DECODE(t55.INC_TYPE,'N','Regular','C','Credit Note') INVOICE_TYPE, t55.INC_TYPE, " +
				"to_number(t55.total_cgst + t55.total_igst + t55.total_sgst) Total_GST, IRN_NO,DECODE(t55.BILL_FINALISED,'Y','YES','NO') BILL_FINALIZE,DECODE(t55.SENT_TO_SAP,'X','YES','NO') BILL_SENT from t55_Lab_Invoice t55, t12_bill_paying_officer B,T03_CITY C, t92_state t92 " +
				"where t55.bpo_cd= b.bpo_cd and B.BPO_CITY_CD= C.CITY_CD and C.state_cd=t92.state_cd and (t55.invoice_dt between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and t55.region_code='" + Session["Region"].ToString() + "' order by t55.invoice_no ";
			OracleCommand cmddata = new OracleCommand(strdata, conn);
			conn.Open();
			OracleDataReader drdata = cmddata.ExecuteReader();
			int sno = 0;
			Decimal t_AMOUNT = 0, t_INVAMT = 0, t_SGST = 0, t_CGST = 0, t_IGST = 0, t_GST = 0;
			while (drdata.Read())
			{
				sno = sno + 1;
				Response.Write("<tr>");
				Response.Write("<td width='3%' valign='top' align='center'><b><font size='1.5' face='Verdana'>" + sno + "</font></b></td>");
				Response.Write("<td width='20%' valign='top' align='left'><b><font size='1' face='Verdana'>" + drdata["BPO_NAME"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["recipient_gstin_no"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["St_cd"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["invoice_no"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["invoice_dt"] + "</font></b></td>");
				Response.Write("<td width='5%' valign='top' align='center'><b><font size='1.5' face='Verdana'>" + drdata["INV_TYPE"] + "</font></b></td>");
				Response.Write("<td width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["HSN_CD"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["INVOICE_TYPE"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["Total_AMT"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["INV_amount"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["INV_sgst"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["INV_cgst"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["INV_igst"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["Total_GST"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["BILL_FINALIZE"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["BILL_SENT"] + "</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>" + drdata["IRN_NO"] + "</font></b></td>");
				Response.Write("</tr></font>");
				//Response.Write("<tr>");
				if (drdata["INC_TYPE"].ToString() == "N")
				{
					t_AMOUNT = t_AMOUNT + Convert.ToDecimal(drdata["Total_AMT"]);
					t_INVAMT = t_INVAMT + Convert.ToDecimal(drdata["INV_amount"]);
					t_SGST = t_SGST + Convert.ToDecimal(drdata["INV_sgst"]);
					t_CGST = t_CGST + Convert.ToDecimal(drdata["INV_cgst"]);
					t_IGST = t_IGST + Convert.ToDecimal(drdata["INV_igst"]);
					t_GST = t_GST + Convert.ToDecimal(drdata["Total_GST"]);
				}
				else if (drdata["INC_TYPE"].ToString() == "C")
				{
					t_AMOUNT = t_AMOUNT - Convert.ToDecimal(drdata["Total_AMT"]);
					t_INVAMT = t_INVAMT - Convert.ToDecimal(drdata["INV_amount"]);
					t_SGST = t_SGST - Convert.ToDecimal(drdata["INV_sgst"]);
					t_CGST = t_CGST - Convert.ToDecimal(drdata["INV_cgst"]);
					t_IGST = t_IGST - Convert.ToDecimal(drdata["INV_igst"]);
					t_GST = t_GST - Convert.ToDecimal(drdata["Total_GST"]);

				}

			}
			Response.Write("<tr>");
			//			Response.Write("<th width='3%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></th>");
			//			Response.Write("<th width='20%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></th>");
			//			Response.Write("<th width='8%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></th>");
			//			Response.Write("<th width='8%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></th>");
			Response.Write("<th width='7%' valign='top' align='right' colspan=9><b><font size='2' face='Verdana'></font>Total(Normal Invoice-Credit Note Invoice)</b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>" + t_AMOUNT + "</font></b></th>");
			//Response.Write("<th width='5%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></th>");
			//Response.Write("<th width='5%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>" + t_INVAMT + "</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>" + t_SGST + "</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>" + t_CGST + "</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>" + t_IGST + "</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>" + t_GST + "</font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></th>");
			Response.Write("<th width='7%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></th>");
			Response.Write("</tr></font>");
			Response.Write("<tr>");

			conn.Close();
			Response.Write("</table>");
			Response.Write("</td>");
			Response.Write("</body></html>");

		}

		void CHECK_SHEET()
		{
			//Northern Region//
			Response.Write("<html><body>");
			Response.Write("<br><br><p align=Center><font size='2' face='Verdana'><b><u>Progress of Check sheets for the period : " + wFrmDt + " to " + wToDt + "</u></b></font></p></br><br>");
			Response.Write("<br><br><p align=Center><font size='2' face='Verdana'><b><u>" + wRegion + "</u></b></font></p></br><br>");
			//Response.Write("<p align=Left><font size='2' face='Verdana'><b><u>3. Check sheets reviewed by GGMI/GMI</u></b></font></p>");
			//Response.Write("<p align=Left><font size='2' face='Verdana'><b><u>3. (i)Northern Region</u></b></font></p>");
			Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
			Response.Write("<tr>");
			Response.Write("<th width='2%' valign='top' align='center'><b><font size='2' face='Verdana'>S.No.</font></b></th>");
			Response.Write("<th width='58%' valign='top' align='center'><b><font size='2' face='Verdana'>Item</font></b></th>");
			Response.Write("<th width='20%' valign='top' align='center'><b><font size='2' face='Verdana'>Name of IE's/Shri</font></b></th>");
			Response.Write("<th width='20%' valign='top' align='center'><b><font size='2' face='Verdana'>Name of CM's/Shri</font></b></th>");
			Response.Write("</tr></font>");

			string strN = "select row_number() over (order by im.item_cd) as rn,im.ITEM_DESC ITEM_DESC, ie.ie_name ie,co.co_name co_name, im.creation_rev_dt from t61_item_master im inner join t08_ie_controll_officer co " +
				"on im.cm=co.co_cd inner join T09_IE ie on im.ie= ie.ie_cd where substr(im.item_cd,1,1)='" + Session["Region"].ToString() + "' and (im.creation_rev_dt BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy'))";

			OracleCommand cmdN = new OracleCommand(strN, conn);
			conn.Open();
			OracleDataReader drN = cmdN.ExecuteReader();

			while (drN.Read())
			{
				Response.Write("<tr>");
				Response.Write("<td width='2%' valign='top' align='center'><b><font size='2' face='Verdana'>" + drN["rn"] + "</font></b></td>");
				Response.Write("<td width='58%' valign='top' align='Left'><b><font size='1' face='Verdana'>" + drN["ITEM_DESC"] + "</font></b></td>");
				Response.Write("<td width='20%' valign='top' align='Left'><b><font size='1.5' face='Verdana'>" + drN["ie"] + "</font></b></td>");
				Response.Write("<td width='20%' valign='top' align='Left'><b><font size='1.5' face='Verdana'>" + drN["co_name"] + "</font></b></td>");
				Response.Write("</tr></font>");

			}

			conn.Close();
			Response.Write("</table>");
			Response.Write("</td>");
			Response.Write("</body></html>");

		}

		void TECH_REF()
		{
			Response.Write("<html><body>");
			Response.Write("<br><br><p align=Center><font size='2' face='Verdana'><b><u>Technical References for the period : " + wFrmDt + " to " + wToDt + "</u></b></font></p></br><br>");
			Response.Write("<br><br><p align=Center><font size='2' face='Verdana'><b><u>" + wRegion + "</u></b></font></p></br><br>");
			//Response.Write("<p align=Left><font size='2' face='Verdana'><b><u>10. Technical References</u></b></font></p>");
			//Response.Write("<p align=Left><font size='2' face='Verdana'><b><u>(i)Northern Region</u></b></font></p>");
			Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
			Response.Write("<tr>");
			Response.Write("<th width='2%' valign='top' align='center'><b><font size='2' face='Verdana'>S.No.</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='2' face='Verdana'>Name of CM/Sh.</font></b></th>");
			Response.Write("<th width='8%' valign='top' align='center'><b><font size='2' face='Verdana'>Name of IE/Sh.</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='2' face='Verdana'>Item</font></b></th>");
			Response.Write("<th width='12%' valign='top' align='center'><b><font size='2' face='Verdana'>Spec & Drg</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='2' face='Verdana'>RITES Letter No.</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='2' face='Verdana'>Date</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center'><b><font size='2' face='Verdana'>Reference made to</font></b></th>");
			Response.Write("<th width='25%' valign='top' align='center'><b><font size='2' face='Verdana'>Content of technical reference in brief</font></b></th>");
			Response.Write("</tr></font>");

			String TNR = "Select  row_number() over (order by to_char(tr.tech_date, 'dd.mm.yyyy')) as sn,co.co_name cm_name,ie.ie_name ie_name,tr.tech_item_des item_des,tr.tech_spec_drg spec_drg,tr.tech_letter_no letter_no,to_char(tr.tech_date, 'dd.mm.yyyy') tech_date,tr.tech_ref_made ref_made,tr.tech_content tech_content " +
				"from t66_tech_ref tr, t08_ie_controll_officer co, t09_ie ie where tr.tech_cm_cd= co.co_cd and tr.tech_ie_cd= ie.ie_cd " +
				"and (tr.tech_date BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and tr.region_cd='" + Session["Region"].ToString() + "'";


			OracleCommand cmdTNR = new OracleCommand(TNR, conn);
			conn.Open();
			OracleDataReader drTNR = cmdTNR.ExecuteReader();

			while (drTNR.Read())
			{
				Response.Write("<tr>");
				Response.Write("<th width='2%' valign='top' align='left'><b><font size='2' face='Verdana'>" + drTNR["sn"] + "</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='left'><b><font size='1' face='Verdana'>" + drTNR["cm_name"] + "</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='left'><b><font size='1' face='Verdana'>" + drTNR["ie_name"] + "</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='left'><b><font size=1' face='Verdana'>" + drTNR["item_des"] + "</font></b></th>");
				Response.Write("<th width='12%' valign='top' align='left'><b><font size='1' face='Verdana'>" + drTNR["spec_drg"] + "</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='left'><b><font size='1' face='Verdana'>" + drTNR["letter_no"] + "</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='left'><b><font size='1' face='Verdana'>" + drTNR["tech_date"] + "</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='left'><b><font size='1' face='Verdana'>" + drTNR["ref_made"] + "</font></b></th>");
				Response.Write("<th width='25%' valign='top' align='left'><b><font size='1' face='Verdana'>" + drTNR["tech_content"] + "</font></b></th>");
				Response.Write("</tr></font>");

			}
			conn.Close();
			Response.Write("</table>");
			Response.Write("</td>");
			Response.Write("</body></html>");

		}


		void cm_issued_notsubmitted()
		{
			//			string sql="Select to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy') IC_ISSUED_DT,T17.BK_NO,T17.SET_NO,T09.IE_NAME from T17_CALL_REGISTER T17 left join T30_IC_RECEIVED T30 on (T17.BK_NO = T30.BK_NO and T17.SET_NO=T30.SET_NO and T17.REGION_CODE=T30.REGION), T09_IE T09 where (T30.BK_NO is null and T30.SET_NO is null and T30.REGION is null) and T17.IE_CD=T09.IE_CD and substr(T17.CASE_NO,1,1)='"+Session["Region"]+"' and T17.CALL_STATUS in ('A','R') and (T17.CALL_STATUS_DT between to_date('"+wFrmDt+"','dd/mm/yyyy') and to_date('"+wToDt+"','dd/mm/yyyy') ) Order by T17.CALL_STATUS_DT,T09.IE_NAME,T17.BK_NO,T17.SET_NO " ;
			string sql = "";

			sql = "Select to_char(CALL_STATUS_DT,'dd/mm/yyyy') IC_ISSUED_DT,a.BK_NO,a.SET_NO,a.IE_NAME,a.CO_NAME from ( Select T17.CASE_NO,T17.CALL_STATUS_DT,'dd/mm/yyyy',T17.BK_NO,T17.SET_NO,T09.IE_NAME,T08.CO_NAME from T17_CALL_REGISTER T17 left join T30_IC_RECEIVED T30 on (T17.BK_NO = T30.BK_NO and T17.SET_NO=T30.SET_NO and T17.REGION_CODE=T30.REGION), T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where (T30.BK_NO is null and T30.SET_NO is null and T30.REGION is null) and T17.IE_CD=T09.IE_CD and T09.IE_CO_CD=T08.CO_CD and substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' and T17.CALL_STATUS in ('A','R') and (T17.CALL_STATUS_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy') ) ) a left join T20_IC T20 on (a.BK_NO=T20.BK_NO and a.SET_NO=T20.SET_NO and a.CASE_NO=T20.CASE_NO) where (T20.BK_NO is null and T20.SET_NO is null and T20.CASE_NO is null) Order by a.CO_NAME,a.CALL_STATUS_DT,a.BK_NO,a.SET_NO ";

			int wSno = 0;
			int wSno_1 = 0;

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='80%'>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='7'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>IC Issued but not Received in Office For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>IE S.No.</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>IC Issue Date</font></th>");
				Response.Write("<th width='30%' valign='top'><font size='2' face='Verdana'>CM</font></th>");
				Response.Write("<th width='30%' valign='top'><font size='2' face='Verdana'>IE</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>BK NO.</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>SET No.</font></th>");
				Response.Write("</tr>");
				string wIE = "";



				while (reader.Read())
				{
					wSno_1 = wSno_1 + 1;

					if (wIE == reader["CO_NAME"].ToString())
					{
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno_1 + "</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["IC_ISSUED_DT"]); Response.Write("</td>");
						Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
						Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
						Response.Write("</tr>");
					}
					else
					{
						wSno = 0;
						wIE = reader["CO_NAME"].ToString();
						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno_1 + "</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["IC_ISSUED_DT"]); Response.Write("</td>");
						Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
						Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
						Response.Write("</tr>");
					}
				};

				Response.Write("</table>");
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


		void Cum_ICissuednotsubmitted()
		{
			conn.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy - HH:MI AM') from dual", conn);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn.Close();
			int ctr = 100;
			string first_page = "Y";
			string str6 = "select CO_NAME,IE_NAME, count(*) no_ic from(Select to_char(CALL_STATUS_DT,'dd/mm/yyyy') IC_ISSUED_DT,a.BK_NO,a.SET_NO,a.IE_NAME," +
				"a.CO_NAME from ( Select T17.CASE_NO,T17.CALL_STATUS_DT,'dd/mm/yyyy',T17.BK_NO," +
				"T17.SET_NO,T09.IE_NAME,T08.CO_NAME from T17_CALL_REGISTER T17 " +
				"left join T30_IC_RECEIVED T30 on (T17.BK_NO = T30.BK_NO " +
				"and T17.SET_NO=T30.SET_NO and T17.REGION_CODE=T30.REGION)," +
				"T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where (T30.BK_NO is null " +
				"and T30.SET_NO is null and T30.REGION is null) and T17.IE_CD=T09.IE_CD " +
				"and T09.IE_CO_CD=T08.CO_CD and substr(T17.CASE_NO,1,1)='" + Session["Region"].ToString() + "' " +
				"and T17.CALL_STATUS in ('A','R') and (T17.CALL_STATUS_DT " +
				"between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy') ) ) a " +
				"left join T20_IC T20 on (a.BK_NO=T20.BK_NO and a.SET_NO=T20.SET_NO and a.CASE_NO=T20.CASE_NO) " +
				"where (T20.BK_NO is null and T20.SET_NO is null and T20.CASE_NO is null) " +
				"Order by a.IE_NAME,a.CALL_STATUS_DT,a.BK_NO,a.SET_NO) group by CO_NAME,IE_NAME order by CO_NAME,IE_NAME ";
			try
			{
				OracleCommand cmd6 = new OracleCommand(str6, conn);
				conn.Open();
				OracleDataReader reader6 = cmd6.ExecuteReader();
				//int sno=0;
				Int64 t1 = 0, gt1 = 0;
				string wCO_Type = "";
				while (reader6.Read())
				{
					if (ctr > 90)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='90%'>");
						Response.Write("<tr>");
						Response.Write("<td width='90%' colspan='3'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>IC Issued but not Received in Office For the Period : " + wFrmDt + " to " + wToDt + " &nbsp&nbsp----&nbsp&nbspStatus as on : " + ss + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='35%' valign='top' align='center'><b><font size='1' face='Verdana'>CM Name</font></b></th>");
						Response.Write("<th width='35%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
						Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>No of IC</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 5;
					};
					if (reader6["CO_NAME"].ToString() != wCO_Type)
					{
						if (wCO_Type.ToString() != "")
						{
							Response.Write("<tr bgColor='#d4d0c8'>");
							Response.Write("<td width='70%' height='20px valign='top' align='right' colspan=2><b><font size='1' face='Verdana'>Total For " + wCO_Type.ToString() + " :</font></b></td>");
							Response.Write("<td width='20%' height='20px valign='top' align='center'><b><font size='1' face='Verdana'>" + t1 + "</font></b></td>");
							Response.Write("</tr>");
							gt1 = gt1 + t1;
							t1 = 0;
							ctr = ctr + 1;
						}
						wCO_Type = reader6["CO_NAME"].ToString();
						Response.Write("<tr>");
						Response.Write("<td width='35%' valign='top' align='center'><b><font size='1' face='Verdana'>" + reader6["CO_NAME"].ToString() + "</font></b></td>");
						ctr = ctr + 1;
					}
					else if (ctr == 5)
					{
						Response.Write("<td width='35%' valign='top' align='center'><b><font size='1' face='Verdana'>" + reader6["CO_NAME"].ToString() + "</font></b></td>");
					}
					else
					{
						Response.Write("<td width='35%' valign='top' align='center'><b><font size='1' face='Verdana'></font></b></td>");
					}
					Response.Write("<td width='35%' valign='top' align='center'><b><font size='1' face='Verdana'>" + reader6["IE_NAME"] + "</font></b></td>");
					Response.Write("<td width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>" + reader6["no_ic"] + "</font></b></td>");
					t1 = t1 + Convert.ToInt64(reader6["no_ic"]);
					Response.Write("</tr>");
					ctr = ctr + 1;
				};
				Response.Write("<tr bgColor='#d4d0c8'>");
				Response.Write("<td width='70%' valign='center' height='20px' align='right' colspan=2><b><font size='1' face='Verdana'>Total For " + wCO_Type.ToString() + " :</font></b></td>");
				Response.Write("<td width='20%' valign='center' height='20px' align='center'><b><font size='1' face='Verdana'>" + t1 + "</font></b></td>");
				Response.Write("</tr>");
				gt1 = gt1 + t1;
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<td width='70%' height='30px valign='baseline' align='right' colspan=2><b><font size='1' face='Verdana'>Grand Total :</font></b></td>");
				Response.Write("<td width='20%' height='30px valign='baseline' align='center'><b><font size='1' face='Verdana'>" + gt1 + "</font></b></td>");
				Response.Write("</tr>");
				conn.Close();
				Response.Write("</table>");
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

		void Remarking_rpt()
		{
			string sql = "";
			int wSno_R = 0;

			sql = "select T108.case_no case_no,to_char(T108.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT, T108.call_sno call_sno,decode(T108.remarking_status,'P','Pending','R','Rejected','A','Approved') remarking_status," +
				"T108.remark_reason remark_reason, t09.ie_name ie_name_from, t10.ie_name ie_name_to," +
				"t108.fr_ie_pending_calls fr_ie_pending_calls,t108.to_ie_pending_calls to_ie_pending_calls," +
				"t02.user_name user_name,to_char(T108.rem_init_datetime,'DD/MM/YYYY-HH24:MI:SS') Initiated_TIME," +
				"t12.user_name user_name_app,to_char(T108.rem_app_datetime,'DD/MM/YYYY-HH24:MI:SS') Approved_TIME, NVL(T17.CALL_REMARK_STATUS,'0') CALL_REMARK_STATUS " +
				"from T108_REMARKED_CALLS T108,T09_IE T09,T09_IE T10,T02_Users T02, t17_call_register t17,T02_Users T12 " +
				"where T108.FR_IE_CD=T09.IE_CD and T108.TO_IE_CD=T10.IE_CD and T108.REM_INIT_BY=T02.USER_ID and " +
				"T108.case_no=t17.case_no and T108.call_recv_dt=t17.call_recv_dt and T108.call_sno=t17.call_sno " +
				"and t108.rem_app_by= t12.user_id (+) and substr(t108.case_no,1,1)='" + Session["Region"] + "'";

			if (DDL_STATUS.SelectedValue == "2")
			{
				sql = sql + " and T108.remarking_status='P'";
			}
			else if (DDL_STATUS.SelectedValue == "3")
			{
				sql = sql + " and T108.remarking_status='A'";
			}
			else if (DDL_STATUS.SelectedValue == "4")
			{
				sql = sql + " and T108.remarking_status='R'";
			}

			if (Rdb_INI.Checked == true)
			{
				sql = sql + " and (T108.rem_init_datetime between TO_DATE('" + wFrmDt + "-00:00:00','DD/MM/YYYY-HH24:MI:SS') and TO_DATE('" + wToDt + "-23:59:59','DD/MM/YYYY-HH24:MI:SS')) order by T108.rem_init_datetime desc ";
			}
			else
			{
				sql = sql + " and (T108.rem_app_datetime between TO_DATE('" + wFrmDt + "-00:00:00','DD/MM/YYYY-HH24:MI:SS') and TO_DATE('" + wToDt + "-23:59:59','DD/MM/YYYY-HH24:MI:SS')) order by T108.rem_app_datetime desc ";
			}

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='15'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Call Remarking For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='4%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='2' face='Verdana'>Case no</font></th>");
				Response.Write("<th width='6%' valign='top'><font size='2' face='Verdana'>Call recv dt</font></th>");
				Response.Write("<th width='4%' valign='top'><font size='2' face='Verdana'>Call sno</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>Remarking status</font></th>");
				Response.Write("<th width='24%' valign='top'><font size='2' face='Verdana'>Remark reason</font></th>");
				Response.Write("<th width='7%' valign='top'><font size='2' face='Verdana'>Ie name from</font></th>");
				Response.Write("<th width='7%' valign='top'><font size='2' face='Verdana'>Ie name to</font></th>");
				Response.Write("<th width='3%' valign='top'><font size='2' face='Verdana'>From IE pending calls</font></th>");
				Response.Write("<th width='3%' valign='top'><font size='2' face='Verdana'>To IE pending calls</font></th>");
				Response.Write("<th width='7%' valign='top'><font size='2' face='Verdana'>Initiated By</font></th>");
				Response.Write("<th width='7%' valign='top'><font size='2' face='Verdana'>Initiated Date</font></th>");
				Response.Write("<th width='7%' valign='top'><font size='2' face='Verdana'>Approved By</font></th>");
				Response.Write("<th width='7%' valign='top'><font size='2' face='Verdana'>Approved Date</font></th>");
				Response.Write("<th width='3%' valign='top'><font size='2' face='Verdana'>Call Remark</font></th>");
				Response.Write("</tr>");


				while (reader.Read())
				{
					wSno_R = wSno_R + 1;
					Response.Write("<tr>");
					Response.Write("<td width='4%' valign='top' align='Left'> <font size='2' face='Verdana'>" + wSno_R + "</td>");
					Response.Write("<td width='6%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["case_no"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["CALL_RECV_DT"]); Response.Write("</td>");
					Response.Write("<td width='4%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["call_sno"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["remarking_status"]); Response.Write("</td>");
					Response.Write("<td width='24%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["remark_reason"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["ie_name_from"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["ie_name_to"]); Response.Write("</td>");
					Response.Write("<td width='3%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["fr_ie_pending_calls"]); Response.Write("</td>");
					Response.Write("<td width='3%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["to_ie_pending_calls"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["user_name"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["Initiated_TIME"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["user_name_app"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["Approved_TIME"]); Response.Write("</td>");
					Response.Write("<td width='3%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["CALL_REMARK_STATUS"]); Response.Write("</td>");
					Response.Write("</tr>");

				};

				Response.Write("</table>");
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

		void High_Valuecalls()
		{

			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			string wRegion = "";
			if (Session["Region"].ToString() == "N")
			{
				wRegion = "Northern Region";
			}
			else if (Session["Region"].ToString() == "S")
			{
				wRegion = "Southern Region";
			}
			else if (Session["Region"].ToString() == "E")
			{
				wRegion = "Eastern Region";
			}
			else if (Session["Region"].ToString() == "W")
			{
				wRegion = "Western Region";
			}
			else if (Session["Region"].ToString() == "C")
			{
				wRegion = "Central Region";
			}


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			string sql = "SELECT case_no, call_sno, call_recv_dt, ie_name, co_name, client_RLY,  RLY,round(pending_since) pending_since,to_char(insp_desire_dt,'dd/mm/yyyy') insp_desire_date,to_char(min(ext_delv_dt),'dd/mm/yyyy') ext_delv_date, sum(MAT_VALUE) MAT_VALUE, SUM(INSP_FEE) INSP_FEE from " +
				"(select t17.case_no case_no, t17.call_sno call_sno, to_char(t17.call_recv_dt,'DD/MM/YYYY')  call_recv_dt, t09.ie_name ie_name, t08.co_name, t13.rly_cd client_RLY,  DECODE(t13.rly_nonrly,'R','Railway','Non Railway') RLY,(sysdate-t17.call_recv_dt) pending_since,dt_insp_desire insp_desire_dt, t15.ext_delv_dt ext_delv_dt, round((t15.value/t15.qty),2) rate, QTY_TO_INSP, ROUND((round((t15.value/t15.qty),2)*QTY_TO_INSP),2) MAT_VALUE, DECODE(rly_nonrly,'R',round(((round((t15.value/t15.qty),2)*QTY_TO_INSP)*(.167/100)),2),round(((round((t15.value/t15.qty),2)*QTY_TO_INSP)*(.7/100)),2)) Insp_Fee " +
				"from t13_po_master t13, t17_call_register t17, t18_call_details t18, t15_po_detail t15,t09_ie t09, t08_ie_controll_officer t08 " +
				"where " +
				"t17.case_no= t13.case_no and t17.case_no= t18.case_no and t17.call_sno= t18.call_sno and t17.call_recv_dt= t18.call_recv_dt and " +
				"t17.case_no=t15.case_no and t17.ie_cd= t09.ie_cd and t17.co_cd= t08.co_cd and t15.ITEM_SRNO=T18.ITEM_SRNO_PO AND T15.CONSIGNEE_CD=T18.CONSIGNEE_CD and t17.call_status='M' and " +
				"t17.region_code='" + Session["Region"].ToString() + "' and to_char(t17.call_recv_dt,'YYYYMMDD') between '" + wDtFr + "' and '" + wDtTo + "' and (t13.PO_DT>'26-NOV-2022') ";

			if (Radio_cm.Checked == true)
			{
				sql = sql + " and t08.CO_CD=" + lst_co_h.SelectedValue + " ";

			}
			sql = sql + " UNION ALL select t17.case_no case_no, t17.call_sno call_sno, to_char(t17.call_recv_dt,'DD/MM/YYYY')  call_recv_dt, t09.ie_name ie_name, t08.co_name, t13.rly_cd client_RLY,  DECODE(t13.rly_nonrly,'R','Railway','Non Railway') RLY,(sysdate-t17.call_recv_dt) pending_since,dt_insp_desire insp_desire_dt, t15.ext_delv_dt ext_delv_dt, round((t15.value/t15.qty),2) rate, QTY_TO_INSP, ROUND((round((t15.value/t15.qty),2)*QTY_TO_INSP),2) MAT_VALUE, DECODE(rly_nonrly,'R',round(((round((t15.value/t15.qty),2)*QTY_TO_INSP)*(.9/100)),2),round(((round((t15.value/t15.qty),2)*QTY_TO_INSP)*(.7/100)),2)) Insp_Fee " +
				"from t13_po_master t13, t17_call_register t17, t18_call_details t18, t15_po_detail t15,t09_ie t09, t08_ie_controll_officer t08 " +
				"where " +
				"t17.case_no= t13.case_no and t17.case_no= t18.case_no and t17.call_sno= t18.call_sno and t17.call_recv_dt= t18.call_recv_dt and " +
				"t17.case_no=t15.case_no and t17.ie_cd= t09.ie_cd and t17.co_cd= t08.co_cd and t15.ITEM_SRNO=T18.ITEM_SRNO_PO AND T15.CONSIGNEE_CD=T18.CONSIGNEE_CD and t17.call_status='M' and " +
				"t17.region_code='" + Session["Region"].ToString() + "' and to_char(t17.call_recv_dt,'YYYYMMDD') between '" + wDtFr + "' and '" + wDtTo + "'  and (t13.PO_DT<='26-NOV-2022') ";
			if (Radio_cm.Checked == true)
			{
				sql = sql + " and t08.CO_CD=" + lst_co_h.SelectedValue + " ";

			}
			sql = sql + " )group by case_no, call_sno, call_recv_dt, ie_name, co_name, client_RLY, RLY,pending_since,insp_desire_dt,ext_delv_dt ";
			if (rdbValue.Checked == true)
			{
				sql = sql + " order by INSP_FEE desc";
			}
			if (rdbDP.Checked == true)
			{
				sql = sql + " order by ext_delv_dt asc";
			}
			if (rdbDesireDt.Checked == true)
			{
				sql = sql + " order by insp_desire_dt asc";
			}
			if (rdbPendingSince.Checked == true)
			{
				sql = sql + " order by pending_since desc";
			}

			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='13'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='14'>");
				//Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Tentative Inspection Fee Wise Pending Call : " + wFrmDt + " TO " + wToDt + " (" + wRegion + ")</font><br></p>");
				//Response.Write("<H5 align='center'><font face='Verdana'>Note: For details of Super/Surprise inspection please refer Super/Surprise report format - F/8.2/2/4</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Case No</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>SNo</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Call Recieve Date</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CM</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Client</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Client Type</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Pending Since(Current Date- Call_recv_Date)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Inspection Desire Date</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Delivery Period</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Material Value</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Tentative Inspection Fee(For railway (@.167% after PO Dated 26/11/2022 or @.9% upto PO Dated 26/11/2022)  and Non Railway .7%)</font></b></th>");
				//Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Report Format</font></b></th>");

				Response.Write("</tr></font>");

				while (reader.Read())
				{


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["case_no"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["call_sno"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["call_recv_dt"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ie_name"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["co_name"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["client_RLY"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["RLY"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["pending_since"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["insp_desire_date"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ext_delv_date"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["MAT_VALUE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["INSP_FEE"]); Response.Write("</td>");
					//string fpath=Server.MapPath("/RBS/SUPER_SURPRISE/"+reader["SUPER_SURPRISE_NO"].ToString()+".PDF");
					//if (File.Exists(fpath)==true) 
					//{
					//Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/SUPER_SURPRISE/"+reader["SUPER_SURPRISE_NO"].ToString()+".PDF'>FILE</a></td>");
					//}

					Response.Write("</tr>");


				};

				Response.Write("</table>");
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



		private void Radio_all_cm_CheckedChanged(object sender, System.EventArgs e)
		{
			if (Radio_cm.Checked == true)
			{
				lst_co_h.Visible = true;
			}
			else
			{
				lst_co_h.Visible = false;
			}


		}
	}
}
