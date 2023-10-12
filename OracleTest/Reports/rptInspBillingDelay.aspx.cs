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
    public partial class rptInspBillingDelay : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.DropDownList lstMonths;
		protected System.Web.UI.WebControls.DropDownList lstYear;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Panel Panel_2;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.RadioButton rdbBillDt;
		protected System.Web.UI.WebControls.RadioButton rdbIE;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.RadioButton rdbPer;
		protected System.Web.UI.WebControls.DropDownList lstIE;
		protected System.Web.UI.WebControls.RadioButton rdbMon;
		protected System.Web.UI.WebControls.Label lblTo;
		protected System.Web.UI.WebControls.Label lblFrom;
		protected System.Web.UI.WebControls.RadioButton rdbPARIE;
		protected System.Web.UI.WebControls.RadioButton rdbALLIE;
		protected System.Web.UI.WebControls.RadioButton rdbICDT;
		protected System.Web.UI.WebControls.RadioButton rdbFINSPDT;
		protected System.Web.UI.WebControls.RadioButton rdbLINSPDT;
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!(IsPostBack))
			{
				OracleCommand cmd = new OracleCommand("select to_char(sysdate,'yyyy') from dual", conn);
				conn.Open();
				int yr = Convert.ToInt32(cmd.ExecuteScalar());
				conn.Close();
				ListItem lst = new ListItem();
				for (int i = yr; i >= 2008; i--)
				{
					lst = new ListItem();
					lst.Text = i.ToString();
					lst.Value = i.ToString();
					lstYear.Items.Add(lst);
				}


				lblFrom.Visible = false;
				lblTo.Visible = false;
				lstMonths.Visible = false;
				lstYear.Visible = false;
				frmDt.Visible = false;
				toDt.Visible = false;
				lstIE.Visible = false;
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
			this.rdbMon.CheckedChanged += new System.EventHandler(this.rdbMon_CheckedChanged);
			this.rdbPer.CheckedChanged += new System.EventHandler(this.rdbMon_CheckedChanged);
			this.rdbPARIE.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
			this.rdbALLIE.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = false;
			Panel_2.Visible = false;
			DisAll();
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/MainForm.aspx");
		}
		void DisAll()
		{
			string Region = "";
			string wHdr_YrMth;
			string wHdrSort = "";
			string wYrMth = "";
			string wToDt = "";
			string wFrmDt = "";
			if (rdbMon.Checked == true)
			{

				wHdr_YrMth = lstMonths.SelectedItem.Text + ", " + lstYear.SelectedValue;
				wYrMth = lstYear.SelectedValue + lstMonths.SelectedValue;
			}
			else
			{
				wToDt = toDt.Text.Trim();
				wFrmDt = frmDt.Text.Trim();
				wHdr_YrMth = frmDt.Text.Trim() + " - " + toDt.Text.Trim();
			}

			if (Session["Region"].ToString() == "N")
			{
				Region = "RITES LTD. (NORTHERN REGION)";
			}
			else if (Session["Region"].ToString() == "S")
			{
				Region = "RITES LTD. (SOUTHERN REGION)";
			}
			else if (Session["Region"].ToString() == "E")
			{
				Region = "RITES LTD. (EASTERN REGION)";
			}
			else if (Session["Region"].ToString() == "W")
			{
				Region = "RITES LTD. (WESTERN REGION)";
			}
			else if (Session["Region"].ToString() == "C")
			{
				Region = "RITES LTD. (CENTRAL REGION)";
			}
			string sql = "";
			if (rdbMon.Checked == true)
			{
				sql = "Select T20.IC_NO, to_char(T20.IC_DT,'dd/mm/yyyy')IC_DT,to_char(T20.IC_SUBMIT_DT,'dd/mm/yyyy')IC_SUBMIT_DATE,T20.BK_NO,T20.SET_NO,to_char(T20.CALL_DT,'dd/mm/yyyy') CALL_DT,to_char(T20.FIRST_INSP_DT,'dd/mm/yyyy') FIRST_INSP_DT,nvl2(to_char(T20.LAST_INSP_DT,'dd/mm/yyyy'),to_char(T20.LAST_INSP_DT,'dd/mm/yyyy'),to_char(T20.FIRST_INSP_DT,'dd/mm/yyyy')) LAST_INSP_DT,nvl((T20.FIRST_INSP_DT-T20.CALL_DT),0) DELAY_INSP,nvl((T20.IC_DT-T20.LAST_INSP_DT),0)  DELAY_IC,nvl((T20.IC_SUBMIT_DT-T20.IC_DT),0)DELAY_SUBM,nvl(floor((T22.BILL_DT-T20.IC_SUBMIT_DT)),0) DELAY_BILL,T22.BILL_NO,to_char(T22.BILL_DT,'dd/mm/yyyy') BILL_DT,T09.IE_NAME,nvl(T22.BILL_AMOUNT,0)BILL_AMOUNT,T05.VEND_CD||'-'||T05.VEND_NAME Vendor,T03.CITY VENDOR_CITY FROM T20_IC T20,T22_BILL T22, T09_IE T09,T05_VENDOR T05, T03_CITY T03, T13_PO_MASTER T13 WHERE T22.BILL_NO=T20.BILL_NO and T20.IE_CD=T09.IE_CD and T20.CASE_NO=T13.CASE_NO and T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and to_char(T22.BILL_DT,'YYYYMM')='" + wYrMth + "' and substr(T20.CASE_NO,1,1)='" + Session["Region"] + "' and (T20.CALL_DT > '01-Jan-2000') ";
			}
			else if (rdbPer.Checked == true)
			{
				sql = "Select T20.IC_NO,to_char(T20.IC_DT,'dd/mm/yyyy')IC_DT,to_char(T20.IC_SUBMIT_DT,'dd/mm/yyyy')IC_SUBMIT_DATE,T20.BK_NO,T20.SET_NO,to_char(T20.CALL_DT,'dd/mm/yyyy') CALL_DT,to_char(T20.FIRST_INSP_DT,'dd/mm/yyyy') FIRST_INSP_DT,nvl2(to_char(T20.LAST_INSP_DT,'dd/mm/yyyy'),to_char(T20.LAST_INSP_DT,'dd/mm/yyyy'),to_char(T20.FIRST_INSP_DT,'dd/mm/yyyy')) LAST_INSP_DT,nvl((T20.FIRST_INSP_DT-T20.CALL_DT),0) DELAY_INSP,nvl((T20.IC_DT-T20.LAST_INSP_DT),0)  DELAY_IC,nvl((T20.IC_SUBMIT_DT-T20.IC_DT),0)DELAY_SUBM,nvl(floor((T22.BILL_DT-T20.IC_SUBMIT_DT)),0) DELAY_BILL,T22.BILL_NO,to_char(T22.BILL_DT,'dd/mm/yyyy') BILL_DT,T09.IE_NAME,nvl(T22.BILL_AMOUNT,0)BILL_AMOUNT,T05.VEND_CD||'-'||T05.VEND_NAME Vendor,T03.CITY VENDOR_CITY FROM T20_IC T20,T22_BILL T22, T09_IE T09,T05_VENDOR T05, T03_CITY T03, T13_PO_MASTER T13 WHERE T22.BILL_NO=T20.BILL_NO and T20.IE_CD=T09.IE_CD and T20.CASE_NO=T13.CASE_NO and T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and (T22.BILL_DT Between to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and substr(T20.CASE_NO,1,1)='" + Session["Region"] + "' and (T20.CALL_DT > '01-Jan-2000') ";
			}
			if (Convert.ToString(Session["Uname"]) != "")
			{
				if (rdbPARIE.Checked == true)
				{
					sql = sql + " and T20.IE_CD='" + lstIE.SelectedValue + "'";
				}
				if (rdbIE.Checked == true)
				{
					sql = sql + " order by T09.IE_NAME";
					wHdrSort = "Report Sorted on IE Name";
				}
			}
			else if (Session["IE_CD"].ToString() != "")
			{
				sql = sql + " and T20.IE_CD='" + Session["IE_CD"].ToString() + "'";
			}

			if (rdbICDT.Checked == true)
			{
				sql = sql + " order by T20.IC_DT";
				wHdrSort = "Report Sorted on IC Date";
			}
			else if (rdbFINSPDT.Checked == true)
			{
				sql = sql + " order by T20.FIRST_INSP_DT";
				wHdrSort = "Report Sorted on First Inspection Date";
			}
			else if (rdbLINSPDT.Checked == true)
			{
				sql = sql + " order by T20.LAST_INSP_DT";
				wHdrSort = "Report Sorted on Last Inspection Date";
			}
			else
			{
				sql = sql + " order by T22.BILL_DT";
				wHdrSort = "Report Sorted on Bill Date";
			}
			int ctr = 60;
			string first_page = "Y";

			OracleCommand cmd = new OracleCommand(sql, conn);
			conn.Open();
			OracleDataReader reader = cmd.ExecuteReader();
			int i = 0;
			double w_DELAY_INSP = 0, w_DELAY_IC = 0, w_DELAY_SUBM = 0, w_DELAY_BILL = 0;
			long w_BILL_AMOUNT = 0;
			while (reader.Read())
			{
				if (ctr > 26)
				{
					Response.Write("<HTML>");
					Response.Write("<body>");
					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr>");
					Response.Write("<td width='100%' colspan='15'>");
					if (first_page == "N")
					{ Response.Write("<p style = page-break-before:always></p>"); }
					else
					{ first_page = "N"; }
					Response.Write("<H5 align='center'><font face='Verdana'>" + Region + "</font><br></p>");
					if (rdbMon.Checked == true)
					{
						Response.Write("<H5 align='center'><font face='Verdana'>STATEMENT OF INSPECTION BILLING GENERATED AS ON " + wHdr_YrMth + "  (" + wHdrSort + ")</font><br></p>");
					}
					else if (rdbPer.Checked == true)
					{
						Response.Write("<H5 align='center'><font face='Verdana'>STATEMENT OF INSPECTION BILLING GENERATED FOR THE PERIOD " + wHdr_YrMth + "  (" + wHdrSort + ")</font><br></p>");
					}
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<td width='10%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("IC NO.");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='8%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("IC DATE");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='8%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("IC SUBMIT DATE");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='6%' align='Center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("BK NO.");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='5%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("SET NO");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='8%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("CALL/MATERIAL READINESS DATE");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='8%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("FIRST INS. DATE");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='8%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("LAST INS. DATE");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='13%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("DELAY");
					Response.Write("<Table Width=100% border='1' style='border-collapse: collapse;' bordercolor='#111111'><tr>");
					Response.Write("<td width='15%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("INS.");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='15%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("IC");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='15%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("SUBM");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='15%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("BILL");
					Response.Write("</B></Font></span></td>");
					Response.Write("</tr></table>");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='8%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("BILL NO");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='8%' align='center'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("BILL DATE");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='10%' align='Left'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("IE NAME");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='10%' align='Left'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("VENDOR");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='10%' align='Left'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("VENDOR CITY");
					Response.Write("</B></Font></span></td>");
					Response.Write("<td width='10%' align='Left'><Font Face='Verdana'><span style='font-size: 10'><B>");
					Response.Write("AMOUNT");
					Response.Write("</B></Font></span></td>");
					Response.Write("</tr>");
					ctr = 6;
				};

				Response.Write("<tr>");
				Response.Write("<td width='10%' align='Left'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["IC_NO"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='8%' align='center'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["IC_DT"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='8%' align='center'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["IC_SUBMIT_DATE"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='6%' align='Center'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["BK_NO"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='5%' align='Center'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["SET_NO"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='8%' align='Center'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["CALL_DT"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='8%' align='Center'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["FIRST_INSP_DT"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='8%' align='Center'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["LAST_INSP_DT"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='13%' align='center'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write("<Table Width=100% border='1' style='border-collapse: collapse;' bordercolor='#111111'><tr>");
				Response.Write("<td width='15%' align='right'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["DELAY_INSP"]);
				w_DELAY_INSP = w_DELAY_INSP + Convert.ToInt32(reader["DELAY_INSP"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='15%' align='right'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["DELAY_IC"]);
				w_DELAY_IC = w_DELAY_IC + Convert.ToInt32(reader["DELAY_IC"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='15%' align='right'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["DELAY_SUBM"]);
				w_DELAY_SUBM = w_DELAY_SUBM + Convert.ToInt32(reader["DELAY_SUBM"]);
				Response.Write("</B></Font></span></td>");
				Response.Write("<td width='15%' align='right'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["DELAY_BILL"]);
				w_DELAY_BILL = w_DELAY_BILL + Convert.ToInt32(reader["DELAY_BILL"]);
				Response.Write("</B></Font></span></td>");
				Response.Write("</tr></table>");
				Response.Write("</Font></span></td>");
				Response.Write("<td width='8%' align='Center'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["BILL_NO"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='8%' align='Center'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["BILL_DT"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='10%' align='Left'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["IE_NAME"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='10%' align='Left'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["VENDOR"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='10%' align='Left'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["VENDOR_CITY"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='10%' align='right'><Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(reader["BILL_AMOUNT"]);
				w_BILL_AMOUNT = w_BILL_AMOUNT + Convert.ToInt64(reader["BILL_AMOUNT"]);
				Response.Write("</Font></span></td>");
				Response.Write("</tr>");
				ctr = ctr + 1;
				i = i + 1;
			};
			Response.Write("<tr>");
			Response.Write("<td align='center' colspan=7><Font Face='Verdana'><span style='font-size: 10'><B>");
			Response.Write("No. Of IC's: " + i);
			Response.Write("</B></Font></span></td>");
			Response.Write("<td align='right'><Font Face='Verdana'><span style='font-size: 10'><B>");
			Response.Write("Average Delay: ");
			Response.Write("</B></Font></span></td>");
			Response.Write("<td align='right'><Font Face='Verdana'><span style='font-size: 10'><B>");
			Response.Write("<Table Width=100% height=100% border='1' style='border-collapse: collapse;' bordercolor='#111111'><tr>");
			Response.Write("<td width='25%' align='right'><Font Face='Verdana'><span style='font-size: 10'><B>");
			Response.Write(Math.Round(Convert.ToDouble(w_DELAY_INSP / i), 2));
			Response.Write("</B></Font></span></td>");
			Response.Write("<td width='25%' align='right'><Font Face='Verdana'><span style='font-size: 10'><B>");
			Response.Write(Math.Round(Convert.ToDouble(w_DELAY_IC / i), 2));
			Response.Write("</B></Font></span></td>");
			Response.Write("<td width='25%' align='right'><Font Face='Verdana'><span style='font-size: 10'><B>");
			Response.Write(Math.Round(Convert.ToDouble(w_DELAY_SUBM / i), 2));
			Response.Write("</B></Font></span></td>");
			Response.Write("<td width='25%' align='right'><Font Face='Verdana'><span style='font-size: 10'><B>");
			Response.Write(Math.Round(Convert.ToDouble(w_DELAY_BILL / i), 2));
			Response.Write("</B></Font></span></td>");
			Response.Write("</tr></table>");
			Response.Write("</B></Font></span></td>");
			Response.Write("<td align='Right'colspan=6><Font Face='Verdana'><span style='font-size: 10'><B>");
			Response.Write("Total: " + w_BILL_AMOUNT);
			Response.Write("</B></Font></span></td></tr>");
			Response.Write("</Table>");
			Response.Write("</body>");
			Response.Write("</HTML>");
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Panel_2.Visible = false;
			Panel_1.Visible = true;
			DisAll();
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/MainForm.aspx");
		}

		private void rdbMon_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbMon.Checked == true)
			{
				lblFrom.Visible = true;
				lblFrom.Text = "Month";
				lblTo.Visible = true;
				lblTo.Text = "Year";
				lstMonths.Visible = true;
				lstYear.Visible = true;
				toDt.Visible = false;
				frmDt.Visible = false;


			}
			else if (rdbPer.Checked == true)
			{
				lblFrom.Visible = true;
				lblFrom.Text = "From";
				lblTo.Visible = true;
				lblTo.Text = "To";
				lstMonths.Visible = false;
				lstYear.Visible = false;
				toDt.Visible = true;
				frmDt.Visible = true;


			}
		}

		private void RadioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbPARIE.Checked == true)
			{
				DataSet dsP1 = new DataSet();
				string str3 = "select IE_CD, IE_NAME from T09_IE where IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn);
				ListItem lst3;
				conn.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
				{
					lst3 = new ListItem();
					lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString();
					lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString();
					lstIE.Items.Add(lst3);
				}
				conn.Close();
				lstIE.Visible = true;
			}
			else if (rdbALLIE.Checked == true)
			{
				lstIE.Visible = false;
			}
		}
	}
}
