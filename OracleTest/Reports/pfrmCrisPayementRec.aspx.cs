using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Reports
{
    public partial class pfrmCrisPayementRec : System.Web.UI.Page
	{
		
		OracleConnection conn = null;
		string wFrmDt, wToDt, wRegion;		

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnDetailed.CheckedChanged += new System.EventHandler(this.btnDetailed_CheckedChanged);
			this.btnSummary.CheckedChanged += new System.EventHandler(this.btnDetailed_CheckedChanged);
			this.rdbAllRly.CheckedChanged += new System.EventHandler(this.rdbAllRly_CheckedChanged);
			this.rdbPRly.CheckedChanged += new System.EventHandler(this.rdbAllRly_CheckedChanged);
			this.lstClientType.SelectedIndexChanged += new System.EventHandler(this.lstClientType_SelectedIndexChanged);
			this.rdbAllAU.CheckedChanged += new System.EventHandler(this.rdbAllAU_CheckedChanged);
			this.rdbPAU.CheckedChanged += new System.EventHandler(this.rdbAllAU_CheckedChanged);
			this.ddlStatus.SelectedIndexChanged += new System.EventHandler(this.ddlStatus_SelectedIndexChanged);
			this.ddlStatus2.SelectedIndexChanged += new System.EventHandler(this.ddlStatus2_SelectedIndexChanged);
			this.lblMessage.DataBinding += new System.EventHandler(this.lblMessage_DataBinding);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
			if (Convert.ToString(Request.Params["ACTION"].Trim()) == "NSC")
			{
				bills_not_submitted_cris();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "RBNRS")
			{
				returned_bill_tobe_resent();
			}
			else
			{
				if (btnDetailed.Checked == true)
				{

					cris_paymnents();

				}
				else if (btnSummary.Checked == true)
				{
					if (rdbRlyWise.Checked == true)
					{
						cris_payment_summary();
					}
					else if (rdbAUWise.Checked == true)
					{
						cris_payment_summary_au();
					}

				}
			}
		}
		void bills_not_submitted_cris()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//string sql="select \"bill_no\",\"invoiceno\",\"ic_no\", \"ic_dt\",\"co6_no\",\"co6_date\",\"passed_amt\",\"deducted_amt\",\"net_amt\",\"bookdate\",\"return_reason\",\"return_date\", \"co7_no\", \"co7_date\", \"payment_dt\" from CRIS_PYMT_DTLS where SUBSTR(\"bill_no\",1,1)='"+Session["Region"]+"' ";
			//string sql="select \"bill_no\",\"invoiceno\",\"ic_no\", \"ic_dt\",\"co6_no\",\"co6_date\",\"passed_amt\",\"deducted_amt\",\"net_amt\",\"bookdate\",\"return_reason\",\"return_date\", \"co7_no\", \"co7_date\", \"payment_dt\" from CRIS_PYMT_DTLS ";
			string sql = "Select V22.BILL_NO,to_char(V22.BILL_DT,'dd/mm/yyyy') BILL_DATE,V22.BPO_RLY,V22.BILL_AMOUNT,NVL(V22.BILL_AMT_CLEARED,0) AMT_CLEARED,NVL(V22.AMOUNT_RECEIVED,0) AMT_RECEIVED,V22.AU,TO_CHAR(V22.DIG_BILL_GEN_DT,'DD/MM/YYYY') BILL_GEN_DATE, V22.INVOICE_NO, V22.PO_OR_LETTER, V22.IRN_NO from V22_BILL V22 left join RITES_BILL_DTLS R on (V22.BILL_NO=R.BILL_NO) where (R.BILL_NO is null) and V22.BPO_TYPE='R' AND NVL(V22.AMOUNT_RECEIVED,0)=0 AND(V22.BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) ";
			int wSno = 0;
			string first_page = "Y";
			if (rdbPRly.Checked == true)
			{
				sql = sql + " AND V22.BPO_RLY='" + lstClientType.SelectedValue + "'";
			}
			if (rdbPAU.Checked == true)
			{
				sql = sql + " AND V22.AU='" + lstAU.SelectedValue + "'";
			}
			if (chkAllRegions.Checked == false)
			{
				sql = sql + " AND V22.REGION_CODE='" + Session["Region"].ToString() + "'";
			}
			sql = sql + " Order by V22.BPO_RLY,V22.BILL_DT,V22.BILL_NO";
			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='21'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan=21'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>CRIS PAYMENT DETAILS FOR THE PERIOD : " + wFrmDt + " TO " + wToDt + "&nbsp&nbsp(Report Sorted on Vendor)</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>RLY</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PO OR LOA</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>AU</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Bill Dt.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Invoice No.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Bill Amount</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Amount Recieved</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Bill Amt Cleared</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill Gen Dt</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IRN NO.</font></b></th>");

				Response.Write("</tr></font>");
				//double totBillAmt=0,totDedAmt=0,totPassAmt=0,totNetAmt=0;
				//string wBILL_NO="";
				long w_billamt = 0, w_amtrec = 0, w_amtcleared = 0;
				while (reader.Read())
				{

					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO_RLY"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_OR_LETTER"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["AU"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["bill_no"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DATE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["INVOICE_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
					w_billamt = w_billamt + Convert.ToInt64(Convert.ToInt64(reader["BILL_AMOUNT"]));
					Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["AMT_RECEIVED"]); Response.Write("</td>");
					w_amtrec = w_amtrec + Convert.ToInt64(Convert.ToInt64(reader["AMT_RECEIVED"]));
					Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["AMT_CLEARED"].ToString().Trim()); Response.Write("</td>");
					w_amtcleared = w_amtcleared + Convert.ToInt64(Convert.ToInt64(reader["AMT_CLEARED"]));
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_GEN_DATE"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IRN_NO"]); Response.Write("</td>");

					Response.Write("</tr>");
					//wBILL_NO=reader["BILL_NO"].ToString();

				};
				Response.Write("<tr>");
				Response.Write("<td width='5%' valign='top' align='right' colspan=7> <font size='1' face='Verdana'><b>Total:</b></td>");
				Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(w_billamt); Response.Write("</td>");
				Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(w_amtrec); Response.Write("</td>");
				Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(w_amtcleared); Response.Write("</td>");
				Response.Write("<td width='5%' valign='top' align='right' colspan='2'> <font size='1' face='Verdana'></td></tr>");
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
		void cris_paymnents()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//string sql="select \"bill_no\",\"invoiceno\",\"ic_no\", \"ic_dt\",\"co6_no\",\"co6_date\",\"passed_amt\",\"deducted_amt\",\"net_amt\",\"bookdate\",\"return_reason\",\"return_date\", \"co7_no\", \"co7_date\", \"payment_dt\" from CRIS_PYMT_DTLS where SUBSTR(\"bill_no\",1,1)='"+Session["Region"]+"' ";
			//string sql="select \"bill_no\",\"invoiceno\",\"ic_no\", \"ic_dt\",\"co6_no\",\"co6_date\",\"passed_amt\",\"deducted_amt\",\"net_amt\",\"bookdate\",\"return_reason\",\"return_date\", \"co7_no\", \"co7_date\", \"payment_dt\" from CRIS_PYMT_DTLS ";
			string sql = "select BILL_NO,BPO_RLY,INVOICENO,TO_CHAR(INVOICEDATE,'DD/MM/YYYY') INVOICEDATE,TO_CHAR(RECV_DATE,'DD/MM/YYYY')RECV_DATE,IC_NO,TO_CHAR(IC_DT,'DD/MM/YYYY')IC_DT,CO6_NO,TO_CHAR(CO6_DATE,'DD/MM/YYYY') CO6_DATE,NVL(AMOUNT,0)AMOUNT,NVL(PASSED_AMT,0)PASSED_AMT,NVL(DEDUCTED_AMT,0)DEDUCTED_AMT,NVL(NET_AMT,0)NET_AMT,TO_CHAR(BOOKDATE,'DD/MM/YYYY')BOOKDATE,RETURN_REASON,TO_CHAR(RETURN_DATE,'DD/MM/YYYY') RETURN_DATE, CO7_NO, TO_CHAR(CO7_DATE,'DD/MM/YYYY') CO7_DATE, TO_CHAR(PAYMENT_DT,'DD/MM/YYYY')PAYMENT_DT, A.AU||'-'||AUDESC||'/'||ADDRESS AU_DESC, (SELECT NVL(BILL_AMT_CLEARED,0) FROM T22_BILL WHERE BILL_NO=B.BILL_NO) IBS_AMT_CLEARED from RITES_BILL_DTLS B, AU_CRIS A WHERE B.AU=A.AU  ";
			int wSno = 0;
			string first_page = "Y";
			if (rdbPRly.Checked == true)
			{
				sql = sql + " AND BPO_RLY='" + lstClientType.SelectedValue + "'";
			}
			if (rdbPAU.Checked == true)
			{
				sql = sql + " AND B.AU='" + lstAU.SelectedValue + "'";
			}
			if (chkAllRegions.Checked == false)
			{
				sql = sql + " AND B.REGION_CODE='" + Session["Region"].ToString() + "'";
			}
			if (ddlStatus.SelectedValue == "A")
			{
				sql = sql + " AND INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') ";
				sql = sql + " order by BPO_RLY,INVOICEDATE";
			}
			else if (ddlStatus.SelectedValue == "P")
			{
				sql = sql + " AND CO6_STATUS='A' and PAYMENT_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') ";
				sql = sql + " order by BPO_RLY,PAYMENT_DT,BILL_NO";
			}
			else if (ddlStatus.SelectedValue == "R")
			{
				sql = sql + " AND RETURN_DATE IS NOT NULL and RETURN_DATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') ";
				sql = sql + " order by BPO_RLY,RETURN_DATE";
			}
			else if (ddlStatus.SelectedValue == "X")
			{
				sql = sql + " AND INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and RETURN_DATE IS NULL and PAYMENT_DT IS NULL ";
				sql = sql + " order by BPO_RLY,INVOICEDATE";
			}
			else if (ddlStatus.SelectedValue == "S")
			{
				sql = sql + " AND RECV_DATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and BILL_RESENT_COUNT>0 ";
				sql = sql + " order by BPO_RLY,INVOICEDATE";
			}
			//			else if(ddlStatus.SelectedValue=="X")
			//			{
			//				sql=sql+" and (TO_date(substr(\"bookdate\",1,10),'dd/mm/yyyy') BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy') OR TO_date(substr(\"return_date\",1,10),'dd/mm/yyyy') BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy'))";
			//			}
			//sql=sql+" order by BPO_RLY,PAYMENT_DT";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				//OracleDataReader reader = cmd.ExecuteReader();
				OracleDataAdapter da = new OracleDataAdapter(sql, conn);
				DataSet dsP = new DataSet();
				da.SelectCommand = cmd;
				da.Fill(dsP, "Table");

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='22'>");
				if (first_page == "N")
				{ Response.Write("<p style = page-break-before:always></p>"); }
				else
				{ first_page = "N"; }
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan=22'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>CRIS PAYMENT DETAILS FOR THE PERIOD : " + wFrmDt + " TO " + wToDt + "&nbsp&nbsp(Report Sorted on Vendor)</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>RLY</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>AU DESC</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Bill Dt.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Recv Dt.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Invoice No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IC No.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>IC Date</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Bill Amount</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CO6_No.</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CO6_Date</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Passed Amt</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Deducted Amt</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>Net Amount</font></b></th>");
				Response.Write("<th width='11%' valign='top'><b><font size='1' face='Verdana'>Book Dt</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Return Dt</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Return Reason</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CO7 No.</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CO7 Dt</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Payment Dt</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IBS Cleared Amt</font></b></th>");

				Response.Write("</tr></font>");
				double totBillAmt = 0, totDedAmt = 0, totPassAmt = 0, totNetAmt = 0, totIBSClearedAmt = 0;
				string wBILL_NO = "";
				if (dsP.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{

						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BPO_RLY"].ToString()); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["AU_DESC"].ToString()); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["bill_no"].ToString()); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["INVOICEDATE"].ToString()); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RECV_DATE"].ToString()); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["invoiceno"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["ic_no"].ToString()); Response.Write("</td>");
						Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["ic_dt"].ToString()); Response.Write("</td>");
						Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["AMOUNT"].ToString().Trim()); Response.Write("</td>");
						totBillAmt = totBillAmt + Convert.ToDouble(dsP.Tables[0].Rows[i]["AMOUNT"].ToString().Trim());
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["co6_no"].ToString()); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["co6_date"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["passed_amt"].ToString()); Response.Write("</td>");
						totPassAmt = totPassAmt + Convert.ToDouble(dsP.Tables[0].Rows[i]["passed_amt"].ToString());
						Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["deducted_amt"].ToString()); Response.Write("</td>");
						totDedAmt = totDedAmt + Convert.ToDouble(dsP.Tables[0].Rows[i]["deducted_amt"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["net_amt"].ToString()); Response.Write("</td>");
						totNetAmt = totNetAmt + Convert.ToDouble(dsP.Tables[0].Rows[i]["net_amt"].ToString());
						Response.Write("<td width='11%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["bookdate"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["return_date"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["return_reason"].ToString()); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["co7_no"].ToString()); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["co7_date"].ToString()); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["payment_dt"].ToString()); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["IBS_AMT_CLEARED"].ToString()); Response.Write("</td>");
						totIBSClearedAmt = totIBSClearedAmt + Convert.ToDouble(dsP.Tables[0].Rows[i]["IBS_AMT_CLEARED"].ToString());
						Response.Write("</tr>");
						//wBILL_NO=reader["BILL_NO"].ToString();

					}
				};
				Response.Write("<tr>");
				Response.Write("<td width='5%' valign='top' align='Right' colspan=9> <font size='1' face='Verdana'><b>Total:</b></td>");
				Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'><b>"); Response.Write(totBillAmt); Response.Write("</b></td>");
				Response.Write("<td width='5%' valign='top' align='Right' colspan=2> <font size='1' face='Verdana'></td>");
				Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'><b>"); Response.Write(totPassAmt); Response.Write("</b></td>");
				Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'><b>"); Response.Write(totDedAmt); Response.Write("</b></td>");
				Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'><b>"); Response.Write(totNetAmt); Response.Write("</b></td>");
				Response.Write("<td width='5%' valign='top' align='Right' colspan=6> <font size='1' face='Verdana'></td>");
				Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'><b>"); Response.Write(totIBSClearedAmt); Response.Write("</b></td>");
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
				conn.Dispose();
			}
		}

		void returned_bill_tobe_resent()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//string sql="select \"bill_no\",\"invoiceno\",\"ic_no\", \"ic_dt\",\"co6_no\",\"co6_date\",\"passed_amt\",\"deducted_amt\",\"net_amt\",\"bookdate\",\"return_reason\",\"return_date\", \"co7_no\", \"co7_date\", \"payment_dt\" from CRIS_PYMT_DTLS where SUBSTR(\"bill_no\",1,1)='"+Session["Region"]+"' ";
			//string sql="select \"bill_no\",\"invoiceno\",\"ic_no\", \"ic_dt\",\"co6_no\",\"co6_date\",\"passed_amt\",\"deducted_amt\",\"net_amt\",\"bookdate\",\"return_reason\",\"return_date\", \"co7_no\", \"co7_date\", \"payment_dt\" from CRIS_PYMT_DTLS ";
			//string sql="select V.BILL_NO,TO_CHAR(BILL_DT,'DD/MM/YYYY') BILL_DT, V.BPO_RLY, V.BILL_AMOUNT,V.REGION_CODE,V.BK_NO,V.SET_NO,R.RETURN_REASON,TO_CHAR(R.RETURN_DATE,'DD/MM/YYYY')RETURN_DT FROM RITES_BILL_DTLS R, V22_BILL V WHERE R.BILL_NO=V.BILL_NO AND NVL(V.AMOUNT_RECEIVED,0)=0 AND R.CO6_STATUS='R' AND R.BILL_RESENT_COUNT=0 AND V.BILL_NO NOT IN (SELECT BILL_NO FROM RITES_BILL_DTLS WHERE BILL_RESENT_COUNT>0) ";
			string sql = "SELECT R.BILL_NO, TO_CHAR(r.invoicedate,'DD/MM/YYYY')BILL_DT, r.bpo_rly,R.bk_no,R.AMOUNT BILL_AMOUNT,R.set_no, R.BILL_RESENT_COUNT, R.CO6_STATUS, TO_CHAR(R.RETURN_DATE,'DD/MM/YYYY') RETURN_DT, R.RETURN_REASON,R.AU FROM RITES_BILL_DTLS R,(SELECT MAX(BILL_RESENT_COUNT) AS MAXCOUNT, BILL_NO FROM RITES_BILL_DTLS GROUP BY BILL_NO) MAXRESULTS WHERE R.BILL_NO=MAXRESULTS.BILL_NO AND R.BILL_RESENT_COUNT=MAXRESULTS.MAXCOUNT AND CO6_STATUS='R' ";
			int wSno = 0;
			string first_page = "Y";
			if (rdbPRly.Checked == true)
			{
				sql = sql + " AND R.BPO_RLY='" + lstClientType.SelectedValue + "'";
			}
			if (rdbPAU.Checked == true)
			{
				sql = sql + " AND R.AU='" + lstAU.SelectedValue + "'";
			}
			if (chkAllRegions.Checked == false)
			{
				sql = sql + " AND R.REGION_CODE='" + Session["Region"].ToString() + "'";
			}
			if (rdbPRly.Checked == true && chkAllRegions.Checked == false)
			{
				sql = sql + " AND R.BILL_NO NOT IN (SELECT BILL_NO FROM V22_BILL WHERE (NVL(AMOUNT_RECEIVED,0)>0 OR NVL(CNOTE_AMOUNT,0)>0) AND BPO_RLY='" + lstClientType.SelectedValue + "' AND REGION_CODE='" + Session["Region"].ToString() + "')";
			}
			else if (rdbPRly.Checked == true && chkAllRegions.Checked == true)
			{
				sql = sql + " AND R.BILL_NO NOT IN (SELECT BILL_NO FROM V22_BILL WHERE (NVL(AMOUNT_RECEIVED,0)>0 OR NVL(CNOTE_AMOUNT,0)>0) AND BPO_RLY='" + lstClientType.SelectedValue + "')";
			}
			else if (rdbPRly.Checked == false && chkAllRegions.Checked == true)
			{
				sql = sql + " AND R.BILL_NO NOT IN (SELECT BILL_NO FROM V22_BILL WHERE (NVL(AMOUNT_RECEIVED,0)>0 OR NVL(CNOTE_AMOUNT,0)>0))";
			}
			else if (rdbAllRly.Checked == true && chkAllRegions.Checked == false)
			{
				sql = sql + " AND R.BILL_NO NOT IN (SELECT BILL_NO FROM V22_BILL WHERE (NVL(AMOUNT_RECEIVED,0)>0 OR NVL(CNOTE_AMOUNT,0)>0) and REGION_CODE='" + Session["Region"].ToString() + "')";
			}
			else
			{
				sql = sql + " AND R.BILL_NO NOT IN (SELECT BILL_NO FROM V22_BILL WHERE (NVL(AMOUNT_RECEIVED,0)>0 OR NVL(CNOTE_AMOUNT,0)>0))";
			}
			//sql=sql+"R.BILL_NO NOT IN (SELECT BILL_NO FROM V22_BILL WHERE NVL(AMOUNT_RECEIVED,0)>0)";
			sql = sql + " ORDER BY R.BPO_RLY,R.REGION_CODE,BILL_DT,R.BILL_NO ";

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
				Response.Write("<td width='100%' colspan=10'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Returned Bills yet to be Resent (Not Posted in IBS)</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Client</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Bill Dt.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Bill Amount</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>BK No.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>SET No.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Return Reason</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Return Date</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>AU CODE</font></b></th>");
				Response.Write("</tr></font>");
				double totBillAmt = 0;
				string wBILL_NO = "";
				while (reader.Read())
				{

					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO_RLY"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["bill_no"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DT"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"].ToString().Trim()); Response.Write("</td>");
					totBillAmt = totBillAmt + Convert.ToDouble(reader["BILL_AMOUNT"]);
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["RETURN_REASON"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["RETURN_DT"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["AU"]); Response.Write("</td>");
					Response.Write("</tr>");
					//wBILL_NO=reader["BILL_NO"].ToString();

				};
				Response.Write("<tr>");
				Response.Write("<td width='5%' valign='top' align='Right' colspan=4> <font size='1' face='Verdana'><b>Total:</b></td>");
				Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'><b>"); Response.Write(totBillAmt); Response.Write("</b></td>");
				Response.Write("<td width='5%' valign='top' align='center' colspan=4></td>");
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
				conn.Dispose();
			}
		}


		void cris_payment_summary()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//string sql="select \"bill_no\",\"invoiceno\",\"ic_no\", \"ic_dt\",\"co6_no\",\"co6_date\",\"passed_amt\",\"deducted_amt\",\"net_amt\",\"bookdate\",\"return_reason\",\"return_date\", \"co7_no\", \"co7_date\", \"payment_dt\" from CRIS_PYMT_DTLS where SUBSTR(\"bill_no\",1,1)='"+Session["Region"]+"' ";
			//string sql="select \"bill_no\",\"invoiceno\",\"ic_no\", \"ic_dt\",\"co6_no\",\"co6_date\",\"passed_amt\",\"deducted_amt\",\"net_amt\",\"bookdate\",\"return_reason\",\"return_date\", \"co7_no\", \"co7_date\", \"payment_dt\" from CRIS_PYMT_DTLS ";

			int wSno = 0;
			string first_page = "Y";
			string sql = "";


			try
			{
				if (ddlStatus2.SelectedValue == "A")
				{
					sql = "select BPO_RLY, SUM(TOTAL_BILLS) TOTAL_BILLS, SUM(TOTAL_AMT) TOTAL_AMT, SUM(TOTAL_AMT_PASSED) TOTAL_AMT_PASSED, SUM(PASS_BILLS) NO_BILLS_PASSED, SUM(RETURN_BILLS) RETURN_BILLS,SUM(RETURN_AMOUNT) RETURN_AMOUNT,SUM(RESENT_BILLS) RESENT_BILLS,SUM(RESENT_AMOUNT) RESENT_AMOUNT,SUM(RET_BILL_CLEARED) RET_BILL_CLEARED,SUM(RET_BILL_CLEARED_AMT) RET_BILL_CLEARED_AMT, SUM(PEND_BILL_CLEARED) PEND_BILL_CLEARED, SUM(PEND_BILL_CLEARED_AMT) PEND_BILL_CLEARED_AMT, SUM(SHORT_PAYMENT) SHORT_PAYMENT  FROM (" +
						" select BPO_RLY, COUNT(*) TOTAL_BILLS, SUM(AMOUNT) TOTAL_AMT,0 TOTAL_AMT_PASSED,0 PASS_BILLS,0 RETURN_BILLS,0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT,0 RET_BILL_CLEARED,0 RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT  from RITES_BILL_DTLS where INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and BILL_RESENT_COUNT=0 group by BPO_RLY" +
						" Union All " +
						" select BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, SUM(PASSED_AMT) TOTAL_AMT_PASSED, COUNT(*) PASS_BILLS, 0 RETURN_BILLS,0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT,0 RET_BILL_CLEARED,0 RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT   from RITES_BILL_DTLS where INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and CO6_STATUS='A' AND PASSED_AMT>0 group by BPO_RLY" +
						" Union All " +
						" select BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, COUNT(*) RETURN_BILLS, SUM(AMOUNT) RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT,0 RET_BILL_CLEARED,0 RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT    from RITES_BILL_DTLS where INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and CO6_STATUS='R' group by BPO_RLY" +
						" Union All " +
						" select BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS,0 RETURN_BILLS,0 RETURN_AMOUNT,COUNT(*) RESENT_BILLS,SUM(AMOUNT) RESENT_AMOUNT,0 RET_BILL_CLEARED,0 RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT  from RITES_BILL_DTLS where INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and BILL_RESENT_COUNT>0 group by BPO_RLY" +
						" Union All " +
						//" select V.BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, 0 RETURN_BILLS, 0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT, COUNT(*) RET_BILL_CLEARED, SUM(V.AMOUNT_RECEIVED) RET_BILL_CLEARED_AMT  from RITES_BILL_DTLS R, V22_BILL V where V.BILL_NO=R.BILL_NO AND (BILL_DT BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) and R.CO6_STATUS='R' AND NVL(V.AMOUNT_RECEIVED,0)>0 AND V.DIG_BILL_GEN_DT IS NOT NULL AND R.BILL_RESENT_COUNT=0 group by V.BPO_RLY"+
						" select BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, 0 RETURN_BILLS, 0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT, COUNT(*) RET_BILL_CLEARED, SUM(BILL_AMOUNT) RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT  from (SELECT R.BILL_NO, TO_CHAR(r.invoicedate,'DD/MM/YYYY')BILL_DT, r.bpo_rly,R.AMOUNT BILL_AMOUNT FROM RITES_BILL_DTLS R,(SELECT MAX(BILL_RESENT_COUNT) AS MAXCOUNT, BILL_NO FROM RITES_BILL_DTLS GROUP BY BILL_NO) MAXRESULTS WHERE R.BILL_NO=MAXRESULTS.BILL_NO AND R.BILL_RESENT_COUNT=MAXRESULTS.MAXCOUNT AND CO6_STATUS='R' AND R.BILL_NO IN (SELECT BILL_NO FROM V22_BILL WHERE NVL(AMOUNT_RECEIVED,0)>0) ORDER BY R.BPO_RLY,R.REGION_CODE,BILL_DT,R.BILL_NO) GROUP BY BPO_RLY" +
						" Union All " +
						" select BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, 0 RETURN_BILLS, 0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT, 0 RET_BILL_CLEARED, 0 RET_BILL_CLEARED_AMT, COUNT(*) PEND_BILL_CLEARED, SUM(BILL_AMT_CLEARED) PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT  from V22_BILL WHERE BILL_NO IN (SELECT BILL_NO FROM RITES_BILL_DTLS WHERE INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and RETURN_DATE IS NULL and PAYMENT_DT IS NULL) AND NVL(AMOUNT_RECEIVED,0)>0 GROUP BY BPO_RLY" +
						" Union All " +
						" select BPO_RLY, 0 TOTAL_BILLS, 0 TOTAL_AMT,0 TOTAL_AMT_PASSED,0 PASS_BILLS,0 RETURN_BILLS,0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT,0 RET_BILL_CLEARED,0 RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, SUM(AMOUNT-PASSED_AMT) SHORT_PAYMENT  from RITES_BILL_DTLS where INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and AMOUNT>PASSED_AMT AND CO6_STATUS='A' group by BPO_RLY" +
						") Group By BPO_RLY ORDER BY BPO_RLY";
				}
				else if (ddlStatus2.SelectedValue == "P")
				{
					sql = "select BPO_RLY, SUM(TOTAL_BILLS) TOTAL_BILLS, SUM(TOTAL_AMT) TOTAL_AMT, SUM(TOTAL_AMT_PASSED) TOTAL_AMT_PASSED, SUM(PASS_BILLS) NO_BILLS_PASSED, SUM(RETURN_BILLS) RETURN_BILLS,SUM(RETURN_AMOUNT) RETURN_AMOUNT,SUM(RESENT_BILLS) RESENT_BILLS,SUM(RESENT_AMOUNT) RESENT_AMOUNT,SUM(RET_BILL_CLEARED) RET_BILL_CLEARED,SUM(RET_BILL_CLEARED_AMT) RET_BILL_CLEARED_AMT, SUM(PEND_BILL_CLEARED) PEND_BILL_CLEARED, SUM(PEND_BILL_CLEARED_AMT) PEND_BILL_CLEARED_AMT, SUM(SHORT_PAYMENT) SHORT_PAYMENT  FROM (" +
						" select BPO_RLY, COUNT(*) TOTAL_BILLS, SUM(AMOUNT) TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, 0 RETURN_BILLS,0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT,0 RET_BILL_CLEARED,0 RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT from RITES_BILL_DTLS where BILL_RESENT_COUNT=0 group by BPO_RLY" +
						" Union All " +
						" select BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, SUM(PASSED_AMT) TOTAL_AMT_PASSED, COUNT(*) PASS_BILLS, 0 RETURN_BILLS,0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT,0 RET_BILL_CLEARED,0 RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT  from RITES_BILL_DTLS where PAYMENT_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and CO6_STATUS='A' AND PASSED_AMT>0 group by BPO_RLY" +
						" Union All " +
						" select BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, COUNT(*) RETURN_BILLS, SUM(AMOUNT) RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT,0 RET_BILL_CLEARED,0 RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT   from RITES_BILL_DTLS where RETURN_DATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and CO6_STATUS='R' group by BPO_RLY" +
						" Union All " +
						" select BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS,0 RETURN_BILLS,0 RETURN_AMOUNT,COUNT(*) RESENT_BILLS,SUM(AMOUNT) RESENT_AMOUNT,0 RET_BILL_CLEARED,0 RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT  from RITES_BILL_DTLS where RECV_DATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and BILL_RESENT_COUNT>0 group by BPO_RLY" +
						" Union All " +
						//" select V.BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, 0 RETURN_BILLS, 0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT, COUNT(*) RET_BILL_CLEARED, SUM(V.AMOUNT_RECEIVED) RET_BILL_CLEARED_AMT  from RITES_BILL_DTLS R, V22_BILL V where V.BILL_NO=R.BILL_NO AND (RETURN_DATE BETWEEN to_date('"+wFrmDt+"','dd/mm/yyyy') AND to_date('"+wToDt+"','dd/mm/yyyy')) and R.CO6_STATUS='R' AND NVL(V.AMOUNT_RECEIVED,0)>0 AND V.DIG_BILL_GEN_DT IS NOT NULL AND R.BILL_RESENT_COUNT=0 group by V.BPO_RLY"+
						" select BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, 0 RETURN_BILLS, 0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT, COUNT(*) RET_BILL_CLEARED, SUM(BILL_AMOUNT) RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT  from (SELECT R.BILL_NO, TO_CHAR(r.invoicedate,'DD/MM/YYYY')BILL_DT, r.bpo_rly,R.AMOUNT BILL_AMOUNT FROM RITES_BILL_DTLS R,(SELECT MAX(BILL_RESENT_COUNT) AS MAXCOUNT, BILL_NO FROM RITES_BILL_DTLS GROUP BY BILL_NO) MAXRESULTS WHERE R.BILL_NO=MAXRESULTS.BILL_NO AND R.BILL_RESENT_COUNT=MAXRESULTS.MAXCOUNT AND CO6_STATUS='R' AND R.BILL_NO IN (SELECT BILL_NO FROM V22_BILL WHERE NVL(AMOUNT_RECEIVED,0)>0) ORDER BY R.BPO_RLY,R.REGION_CODE,BILL_DT,R.BILL_NO) GROUP BY BPO_RLY" +
						" Union All " +
						" select BPO_RLY,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, 0 RETURN_BILLS, 0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT, 0 RET_BILL_CLEARED, 0 RET_BILL_CLEARED_AMT, COUNT(*) PEND_BILL_CLEARED, SUM(BILL_AMT_CLEARED) PEND_BILL_CLEARED_AMT, 0 SHORT_PAYMENT  from V22_BILL WHERE BILL_NO IN (SELECT BILL_NO FROM RITES_BILL_DTLS WHERE INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and RETURN_DATE IS NULL and PAYMENT_DT IS NULL) AND NVL(AMOUNT_RECEIVED,0)>0 GROUP BY BPO_RLY" +
						" Union All " +
						" select BPO_RLY, 0 TOTAL_BILLS, SUM(AMOUNT) TOTAL_AMT,0 TOTAL_AMT_PASSED,0 PASS_BILLS,0 RETURN_BILLS,0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT,0 RET_BILL_CLEARED,0 RET_BILL_CLEARED_AMT, 0 PEND_BILL_CLEARED, 0 PEND_BILL_CLEARED_AMT, SUM(AMOUNT-PASSED_AMT) SHORT_PAYMENT  from RITES_BILL_DTLS where PAYMENT_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and AMOUNT>PASSED_AMT AND CO6_STATUS='A' group by BPO_RLY" +
						") Group By BPO_RLY ORDER BY BPO_RLY";
				}
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				//OracleDataReader reader = cmd.ExecuteReader();
				OracleDataAdapter da = new OracleDataAdapter(sql, conn);
				DataSet dsP = new DataSet();
				da.SelectCommand = cmd;
				da.Fill(dsP, "Table");

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
				Response.Write("<H5 align='center'><font face='Verdana'>CRIS BILLS SUMMARY FOR THE PERIOD : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				if (ddlStatus2.SelectedValue == "A")
				{
					Response.Write("<H5 align='center'><font face='Verdana'>(All Columns Based on Invoice Date)</font><br></p>");
				}
				else if (ddlStatus2.SelectedValue == "P")
				{
					Response.Write("<H5 align='center'><font face='Verdana'>(No. of Bills Passed & Total Amount Passed Based on Payment Date & Return Bills based on Return Date & Resent Bills Based on Resent Date & Total Bills Sent to CRIS)</font><br></p>");
				}

				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>RLY</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>No. of Bills (A)</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Bill Amount(AA)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>No. of Bills Passed(B)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total Passed Amount(BB)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total No. of Bills Returned to RITES(C)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total Bill Amount of Bills Returned to RITES(CC)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total No. of Bills Yet to Resent(E) Already Posted in IBS</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total Amount Posted of Bills Yet to Resent(EE) Already Posted in IBS</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total No. of Bills Resent to RAILWAYS(D)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total Bill Amount of Bills Resent to RAILWAYS(DD)</font></b></th>");
				if (ddlStatus2.SelectedValue == "A")
				{
					Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Pending Bills with Railways(P=A-C+D-B)</font></b></th>");
					Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Total Outstanding With Railways(OUTS=AA-CC+DD-BB)</font></b></th>");
					Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Short Payment By Railways</font></b></th>");
					Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Pending Bills with Railways Already Posted in IBS</font></b></th>");
					Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Total Bill Amount Outstanding With Railways Already Posted in IBS</font></b></th>");
				}

				Response.Write("</tr></font>");
				double w_tot_bills = 0, w_tot_bill_amt = 0, w_no_bills_passed = 0, w_pass_amt = 0, w_outstanding = 0, outstanding = 0, w_no_bills_return = 0, w_return_amt = 0, w_no_bills_resent = 0, w_resent_amt = 0, w_pending_bill = 0, pending_bill = 0, w_ret_bills_cleared = 0, w_ret_bills_cleared_amt = 0, w_pend_bill_cleared_ibs = 0, w_pend_bill_amt_cleared_ibs = 0, w_short_payment = 0;
				string wBILL_NO = "";
				if (dsP.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{

						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BPO_RLY"].ToString()); Response.Write("</td>");
						Response.Write("<td width='8%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["TOTAL_BILLS"].ToString()); Response.Write("</td>");
						w_tot_bills = w_tot_bills + Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_BILLS"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["TOTAL_AMT"].ToString()); Response.Write("</td>");
						w_tot_bill_amt = w_tot_bill_amt + Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_AMT"].ToString());
						Response.Write("<td width='11%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["NO_BILLS_PASSED"].ToString()); Response.Write("</td>");
						w_no_bills_passed = w_no_bills_passed + Convert.ToDouble(dsP.Tables[0].Rows[i]["NO_BILLS_PASSED"].ToString());
						Response.Write("<td width='8%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(Math.Round(Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_AMT_PASSED"].ToString()), 0)); Response.Write("</td>");
						w_pass_amt = w_pass_amt + Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_AMT_PASSED"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RETURN_BILLS"].ToString()); Response.Write("</td>");
						w_no_bills_return = w_no_bills_return + Convert.ToDouble(dsP.Tables[0].Rows[i]["RETURN_BILLS"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RETURN_AMOUNT"].ToString()); Response.Write("</td>");
						w_return_amt = w_return_amt + Convert.ToDouble(dsP.Tables[0].Rows[i]["RETURN_AMOUNT"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RET_BILL_CLEARED"].ToString()); Response.Write("</td>");
						w_ret_bills_cleared = w_ret_bills_cleared + Convert.ToDouble(dsP.Tables[0].Rows[i]["RET_BILL_CLEARED"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RET_BILL_CLEARED_AMT"].ToString()); Response.Write("</td>");
						w_ret_bills_cleared_amt = w_ret_bills_cleared_amt + Convert.ToDouble(dsP.Tables[0].Rows[i]["RET_BILL_CLEARED_AMT"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RESENT_BILLS"].ToString()); Response.Write("</td>");
						w_no_bills_resent = w_no_bills_resent + Convert.ToDouble(dsP.Tables[0].Rows[i]["RESENT_BILLS"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RESENT_AMOUNT"].ToString()); Response.Write("</td>");
						w_resent_amt = w_resent_amt + Convert.ToDouble(dsP.Tables[0].Rows[i]["RESENT_AMOUNT"].ToString());

						if (ddlStatus2.SelectedValue == "A")
						{
							pending_bill = (Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_BILLS"].ToString()) - Convert.ToDouble(dsP.Tables[0].Rows[i]["RETURN_BILLS"].ToString()) + Convert.ToDouble(dsP.Tables[0].Rows[i]["RESENT_BILLS"].ToString()) - Convert.ToDouble(dsP.Tables[0].Rows[i]["NO_BILLS_PASSED"].ToString()));
							Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(Math.Round(pending_bill, 0)); Response.Write("</td>");
							w_pending_bill = w_pending_bill + pending_bill;
							outstanding = (Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_AMT"].ToString()) - Convert.ToDouble(dsP.Tables[0].Rows[i]["RETURN_AMOUNT"].ToString()) + Convert.ToDouble(dsP.Tables[0].Rows[i]["RESENT_AMOUNT"].ToString()) - Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_AMT_PASSED"].ToString()));
							Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(Math.Round(outstanding, 0)); Response.Write("</td>");
							w_outstanding = w_outstanding + outstanding;

							Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(Math.Round(Convert.ToDouble(dsP.Tables[0].Rows[i]["SHORT_PAYMENT"].ToString()), 0)); Response.Write("</td>");
							w_short_payment = w_short_payment + Math.Round(Convert.ToDouble(dsP.Tables[0].Rows[i]["SHORT_PAYMENT"].ToString()), 0);


							Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(Convert.ToDouble(dsP.Tables[0].Rows[i]["PEND_BILL_CLEARED"].ToString())); Response.Write("</td>");
							w_pend_bill_cleared_ibs = w_pend_bill_cleared_ibs + Convert.ToDouble(dsP.Tables[0].Rows[i]["PEND_BILL_CLEARED"].ToString());
							Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(Convert.ToDouble(dsP.Tables[0].Rows[i]["PEND_BILL_CLEARED_AMT"].ToString())); Response.Write("</td>");
							w_pend_bill_amt_cleared_ibs = w_pend_bill_amt_cleared_ibs + Convert.ToDouble(dsP.Tables[0].Rows[i]["PEND_BILL_CLEARED_AMT"].ToString());



						}
						//w_outstanding=w_outstanding+Convert.ToDouble(reader["OUTSTANDING"]);
						Response.Write("</tr>");
						//wBILL_NO=reader["BILL_NO"].ToString();

					}
				};
				Response.Write("<tr>");
				Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'></td>");
				Response.Write("<td width='5%' valign='top' align='center'><b> <font size='1' face='Verdana'>"); Response.Write("Total"); Response.Write("</td>");
				Response.Write("<td width='8%' valign='top' align='right'> <b><font size='1' face='Verdana'>"); Response.Write(w_tot_bills); Response.Write("</b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_tot_bill_amt); Response.Write("</b></td>");
				Response.Write("<td width='11%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_no_bills_passed); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(Math.Round(w_pass_amt, 0)); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_no_bills_return); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_return_amt); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_ret_bills_cleared); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_ret_bills_cleared_amt); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_no_bills_resent); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_resent_amt); Response.Write("</b></td>");
				if (ddlStatus2.SelectedValue == "A")
				{
					Response.Write("<td width='10%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_pending_bill); Response.Write("</b></td>");
					Response.Write("<td width='10%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(Math.Round(w_outstanding, 0)); Response.Write("</b></td>");
					Response.Write("<td width='10%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(Math.Round(w_short_payment, 0)); Response.Write("</b></td>");
					Response.Write("<td width='10%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_pend_bill_cleared_ibs); Response.Write("</b></td>");
					Response.Write("<td width='10%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(Math.Round(w_pend_bill_amt_cleared_ibs, 0)); Response.Write("</b></td>");
				}
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
				conn.Dispose();
			}
		}

		void cris_payment_summary_au()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//string sql="select \"bill_no\",\"invoiceno\",\"ic_no\", \"ic_dt\",\"co6_no\",\"co6_date\",\"passed_amt\",\"deducted_amt\",\"net_amt\",\"bookdate\",\"return_reason\",\"return_date\", \"co7_no\", \"co7_date\", \"payment_dt\" from CRIS_PYMT_DTLS where SUBSTR(\"bill_no\",1,1)='"+Session["Region"]+"' ";
			//string sql="select \"bill_no\",\"invoiceno\",\"ic_no\", \"ic_dt\",\"co6_no\",\"co6_date\",\"passed_amt\",\"deducted_amt\",\"net_amt\",\"bookdate\",\"return_reason\",\"return_date\", \"co7_no\", \"co7_date\", \"payment_dt\" from CRIS_PYMT_DTLS ";

			int wSno = 0;
			string first_page = "Y";
			string sql = "";


			try
			{
				if (ddlStatus2.SelectedValue == "A")
				{
					sql = "select AU_DESC, SUM(TOTAL_BILLS) TOTAL_BILLS, SUM(TOTAL_AMT) TOTAL_AMT, SUM(TOTAL_AMT_PASSED) TOTAL_AMT_PASSED, SUM(PASS_BILLS) NO_BILLS_PASSED, SUM(RETURN_BILLS) RETURN_BILLS,SUM(RETURN_AMOUNT) RETURN_AMOUNT,SUM(RESENT_BILLS) RESENT_BILLS,SUM(RESENT_AMOUNT) RESENT_AMOUNT FROM ( " +
						" select RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS AU_DESC, COUNT(*) TOTAL_BILLS, SUM(AMOUNT) TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, 0 RETURN_BILLS,0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT from RITES_BILL_DTLS B, AU_CRIS A where B.AU=A.AU AND INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and BILL_RESENT_COUNT=0 group by RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS " +
						" Union All " +
						" select RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS AU_DESC,0 TOTAL_BILLS, 0 TOTAL_AMT, SUM(PASSED_AMT) TOTAL_AMT_PASSED, COUNT(*) PASS_BILLS, 0 RETURN_BILLS,0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT  from RITES_BILL_DTLS B, AU_CRIS A where B.AU=A.AU AND INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and CO6_STATUS='A' AND PASSED_AMT>0 group by RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS " +
						" Union All " +
						" select RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS AU_DESC,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, COUNT(*) RETURN_BILLS, SUM(AMOUNT) RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT   from RITES_BILL_DTLS B, AU_CRIS A where B.AU=A.AU AND INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and CO6_STATUS='R' group by RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS " +
						" Union All " +
						" select RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS AU_DESC,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS,0 RETURN_BILLS,0 RETURN_AMOUNT,COUNT(*) RESENT_BILLS,SUM(AMOUNT) RESENT_AMOUNT  from RITES_BILL_DTLS B, AU_CRIS A where B.AU=A.AU AND INVOICEDATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and BILL_RESENT_COUNT>0 group by RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS " +
						") Group By AU_DESC ORDER BY AU_DESC";
				}
				else if (ddlStatus2.SelectedValue == "P")
				{
					sql = "select AU_DESC, SUM(TOTAL_BILLS) TOTAL_BILLS, SUM(TOTAL_AMT) TOTAL_AMT, SUM(TOTAL_AMT_PASSED) TOTAL_AMT_PASSED, SUM(PASS_BILLS) NO_BILLS_PASSED, SUM(RETURN_BILLS) RETURN_BILLS,SUM(RETURN_AMOUNT) RETURN_AMOUNT,SUM(RESENT_BILLS) RESENT_BILLS,SUM(RESENT_AMOUNT) RESENT_AMOUNT FROM (" +
						" select RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS AU_DESC, COUNT(*) TOTAL_BILLS, SUM(AMOUNT) TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, 0 RETURN_BILLS,0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT from RITES_BILL_DTLS B, AU_CRIS A where B.AU=A.AU and BILL_RESENT_COUNT=0 group by RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS " +
						" Union All " +
						" select RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS AU_DESC,0 TOTAL_BILLS, 0 TOTAL_AMT, SUM(PASSED_AMT) TOTAL_AMT_PASSED, COUNT(*) PASS_BILLS, 0 RETURN_BILLS,0 RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT  from RITES_BILL_DTLS B, AU_CRIS A where B.AU=A.AU AND PAYMENT_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and CO6_STATUS='A' AND PASSED_AMT>0 group by RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS " +
						" Union All " +
						" select RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS AU_DESC,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS, COUNT(*) RETURN_BILLS, SUM(AMOUNT) RETURN_AMOUNT,0 RESENT_BILLS,0 RESENT_AMOUNT   from RITES_BILL_DTLS B, AU_CRIS A where B.AU=A.AU AND RETURN_DATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and CO6_STATUS='R' group by RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS " +
						" Union All " +
						" select RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS AU_DESC,0 TOTAL_BILLS, 0 TOTAL_AMT, 0 TOTAL_AMT_PASSED, 0 PASS_BILLS,0 RETURN_BILLS,0 RETURN_AMOUNT,COUNT(*) RESENT_BILLS,SUM(AMOUNT) RESENT_AMOUNT  from RITES_BILL_DTLS B, AU_CRIS A where B.AU=A.AU AND RECV_DATE BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy') and BILL_RESENT_COUNT>0 group by RLY_CD||'-'||A.AU||'/'||AUDESC||'/'||ADDRESS " +
						") Group By AU_DESC ORDER BY AU_DESC";
				}
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				//OracleDataReader reader = cmd.ExecuteReader();
				OracleDataAdapter da = new OracleDataAdapter(sql, conn);
				DataSet dsP = new DataSet();
				da.SelectCommand = cmd;
				da.Fill(dsP, "Table");
				conn.Close();

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
				Response.Write("<H5 align='center'><font face='Verdana'>CRIS BILLS SUMMARY FOR THE PERIOD : " + wFrmDt + " TO " + wToDt + "</font><br></p>");
				if (ddlStatus2.SelectedValue == "A")
				{
					Response.Write("<H5 align='center'><font face='Verdana'>(All Columns Based on Invoice Date)</font><br></p>");
				}
				else if (ddlStatus2.SelectedValue == "P")
				{
					Response.Write("<H5 align='center'><font face='Verdana'>(No. of Bills Passed & Total Amount Passed Based on Payment Date & Return Bills based on Return Date & Resent Bills Based on Resent Date & Total Bills Sent to CRIS)</font><br></p>");
				}
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>AU</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>No. of Bills (A)</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Bill Amount(AA)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>No. of Bills Passed(B)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total Passed Amount(BB)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total No. of Bills Returned to RITES(C)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total Bill Amount of Bills Returned to RITES(CC)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total No. of Bills Resent to RAILWAYS(D)</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Total Bill Amount of Bills Resent to RAILWAYS(DD)</font></b></th>");
				if (ddlStatus2.SelectedValue == "A")
				{
					Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Pending Bills with Railways(P=A-C+D-B)</font></b></th>");
					Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>Total Outstanding With Railways(OUTS=AA-CC+DD-BB)</font></b></th>");
				}


				Response.Write("</tr></font>");
				double w_tot_bills = 0, w_tot_bill_amt = 0, w_no_bills_passed = 0, w_pass_amt = 0, w_outstanding = 0, outstanding = 0, w_no_bills_return = 0, w_return_amt = 0, w_no_bills_resent = 0, w_resent_amt = 0, w_pending_bill = 0, pending_bill = 0;
				string wBILL_NO = "";
				if (dsP.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{

						wSno = wSno + 1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["AU_DESC"].ToString()); Response.Write("</td>");
						Response.Write("<td width='8%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["TOTAL_BILLS"].ToString()); Response.Write("</td>");
						w_tot_bills = w_tot_bills + Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_BILLS"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["TOTAL_AMT"].ToString()); Response.Write("</td>");
						w_tot_bill_amt = w_tot_bill_amt + Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_AMT"].ToString());
						Response.Write("<td width='11%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["NO_BILLS_PASSED"].ToString()); Response.Write("</td>");
						w_no_bills_passed = w_no_bills_passed + Convert.ToDouble(dsP.Tables[0].Rows[i]["NO_BILLS_PASSED"].ToString());
						Response.Write("<td width='8%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(Math.Round(Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_AMT_PASSED"].ToString()), 0)); Response.Write("</td>");
						w_pass_amt = w_pass_amt + Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_AMT_PASSED"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RETURN_BILLS"].ToString()); Response.Write("</td>");
						w_no_bills_return = w_no_bills_return + Convert.ToDouble(dsP.Tables[0].Rows[i]["RETURN_BILLS"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RETURN_AMOUNT"].ToString()); Response.Write("</td>");
						w_return_amt = w_return_amt + Convert.ToDouble(dsP.Tables[0].Rows[i]["RETURN_AMOUNT"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RESENT_BILLS"].ToString()); Response.Write("</td>");
						w_no_bills_resent = w_no_bills_resent + Convert.ToDouble(dsP.Tables[0].Rows[i]["RESENT_BILLS"].ToString());
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["RESENT_AMOUNT"].ToString()); Response.Write("</td>");
						w_resent_amt = w_resent_amt + Convert.ToDouble(dsP.Tables[0].Rows[i]["RESENT_AMOUNT"].ToString());
						if (ddlStatus2.SelectedValue == "A")
						{
							pending_bill = (Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_BILLS"].ToString()) - Convert.ToDouble(dsP.Tables[0].Rows[i]["RETURN_BILLS"].ToString()) + Convert.ToDouble(dsP.Tables[0].Rows[i]["RESENT_BILLS"].ToString()) - Convert.ToDouble(dsP.Tables[0].Rows[i]["NO_BILLS_PASSED"].ToString()));
							Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(Math.Round(pending_bill, 0)); Response.Write("</td>");
							w_pending_bill = w_pending_bill + pending_bill;
							outstanding = (Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_AMT"].ToString()) - Convert.ToDouble(dsP.Tables[0].Rows[i]["RETURN_AMOUNT"].ToString()) + Convert.ToDouble(dsP.Tables[0].Rows[i]["RESENT_AMOUNT"].ToString()) - Convert.ToDouble(dsP.Tables[0].Rows[i]["TOTAL_AMT_PASSED"].ToString()));
							Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(Math.Round(outstanding, 0)); Response.Write("</td>");
							w_outstanding = w_outstanding + outstanding;
						}
						//w_outstanding=w_outstanding+Convert.ToDouble(reader["OUTSTANDING"]);
						Response.Write("</tr>");
						//wBILL_NO=reader["BILL_NO"].ToString();

					}
				};
				Response.Write("<tr>");
				Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'></td>");
				Response.Write("<td width='5%' valign='top' align='center'><b> <font size='1' face='Verdana'>"); Response.Write("Total"); Response.Write("</td>");
				Response.Write("<td width='8%' valign='top' align='right'> <b><font size='1' face='Verdana'>"); Response.Write(w_tot_bills); Response.Write("</b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_tot_bill_amt); Response.Write("</b></td>");
				Response.Write("<td width='11%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_no_bills_passed); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(Math.Round(w_pass_amt, 0)); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_no_bills_return); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_return_amt); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_no_bills_resent); Response.Write("</b></td>");
				Response.Write("<td width='8%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_resent_amt); Response.Write("</b></td>");
				if (ddlStatus2.SelectedValue == "A")
				{
					Response.Write("<td width='10%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(w_pending_bill); Response.Write("</b></td>");
					Response.Write("<td width='10%' valign='top' align='right'><b> <font size='1' face='Verdana'>"); Response.Write(Math.Round(w_outstanding, 0)); Response.Write("</b></td>");
				}
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
				conn.Dispose();
			}
		}
		void fill_bpo_rly()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				lstClientType.Items.Clear();
				DataSet dsP = new DataSet();
				string str1 = "Select RLY_CD, RAILWAY from T91_RAILWAYS order by RLY_CD";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("Invalid Search Data");
				}
				else
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["RAILWAY"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
						lstClientType.Items.Add(lst);
					}
					lstClientType.Visible = true;
					lstClientType.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str2);

			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		void fill_rly_au()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				lstAU.Items.Clear();
				DataSet dsP4 = new DataSet();
				string str4 = "select AU,AU||'-'||AUDESC||'/'||ADDRESS AU_DESC from AU_CRIS WHERE RLY_CD='" + lstClientType.SelectedValue + "'";
				OracleDataAdapter da4 = new OracleDataAdapter(str4, conn);
				OracleCommand myOracleCommand4 = new OracleCommand(str4, conn);
				ListItem lst8;
				conn.Open();
				da4.SelectCommand = myOracleCommand4;
				da4.Fill(dsP4, "Table");
				for (int i = 0; (i <= (dsP4.Tables[0].Rows.Count - 1)); i++)
				{
					lst8 = new ListItem();
					lst8.Text = dsP4.Tables[0].Rows[i]["AU_DESC"].ToString();
					lst8.Value = dsP4.Tables[0].Rows[i]["AU"].ToString();
					lstAU.Items.Add(lst8);
				}
				lstAU.Items.Insert(0, "");
				conn.Close();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str2);

			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
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

			if (btnDetailed.Checked == true)
			{

				cris_paymnents();
			}
			else if (btnSummary.Checked == true)
			{
				if (rdbRlyWise.Checked == true)
				{
					cris_payment_summary();
				}
				else if (rdbAUWise.Checked == true)
				{
					cris_payment_summary_au();
				}
			}
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		private void btnDetailed_CheckedChanged(object sender, System.EventArgs e)
		{
			if (btnDetailed.Checked == true)
			{
				lblStatus.Visible = true;
				ddlStatus.Visible = true;
				rdbAUWise.Visible = false;
				rdbRlyWise.Visible = false;
				rdbAllRly.Visible = true;
				rdbPRly.Visible = true;
				ddlStatus2.Visible = false;
				chkAllRegions.Checked = true;
				chkAllRegions.Enabled = true;

				//				lblMessage.Visible=true;
				//				lblMessage.Text="Report Based on Payment Date!!!";
			}
			else
			{
				ddlStatus2.Visible = true;
				lblStatus.Visible = true;
				ddlStatus.Visible = false;
				rdbAUWise.Visible = true;
				rdbRlyWise.Visible = true;
				rdbAllRly.Visible = false;
				rdbPRly.Visible = false;
				lstClientType.Visible = false;
				lblMessage.Text = "Report Based on Bill Date!!!";
				chkAllRegions.Checked = true;
				chkAllRegions.Enabled = false;
			}
		}

		private void lblMessage_DataBinding(object sender, System.EventArgs e)
		{


		}

		private void ddlStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ddlStatus.SelectedValue == "A" || ddlStatus.SelectedValue == "X")
			{
				lblMessage.Text = "Report Based on Bill Date!!!";
			}
			else if (ddlStatus.SelectedValue == "P")
			{
				lblMessage.Text = "Report Based on Payment Date!!!";
			}
			else if (ddlStatus.SelectedValue == "R")
			{
				lblMessage.Text = "Report Based on Return Date!!!";
			}
			else if (ddlStatus.SelectedValue == "S")
			{
				lblMessage.Text = "Report Based on Resubmit Date!!!";
			}
		}

		private void rdbAllRly_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbAllRly.Checked == true)
			{
				lstClientType.Visible = false;
				rdbAllAU.Visible = false;
				rdbPAU.Visible = false;
				lstAU.Visible = false;
			}
			else if (rdbPRly.Checked == true)
			{
				lstClientType.Visible = true;
				fill_bpo_rly();
				rdbAllAU.Visible = true;
				rdbPAU.Visible = true;

			}

		}

		private void ddlStatus2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ddlStatus.SelectedValue == "A")
			{
				lblMessage.Text = "Report Based on Bill Date!!!";
			}
			else if (ddlStatus.SelectedValue == "P")
			{
				lblMessage.Text = "Report Based on Payment Date!!!";
			}

		}

		private void rdbAllAU_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbAllAU.Checked == true)
			{
				lstAU.Visible = false;
			}
			else if (rdbPAU.Checked == true)
			{
				lstAU.Visible = true;
				fill_rly_au();
			}
		}

		private void lstClientType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (rdbPAU.Checked == true)
			{
				fill_rly_au();
			}
		}
	}
}
