using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Report_BPO_WISE_BILL_CHECK
{
	public class Report_BPO_WISE_BILL_CHECK1 : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string BPO, PO, Period, BPONAME;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnCancel;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Request.Params["BPO"] == null && Request.Params["PO"] != "")
			{
				BPO = "";
				PO = Convert.ToString(Request.Params["PO"].Trim());
				Period = "";
			}
			else
			{
				BPO = Convert.ToString(Request.Params["BPO"].Trim());
				Period = Convert.ToString(Request.Params["Period"].Trim());
				PO = "";

			}
			int pno;
			try
			{
				string Region = "";
				if (Session["Region"].ToString() == "N")
				{
					Region = "Northern Region";
				}
				else if (Session["Region"].ToString() == "S")
				{
					Region = "Southern Region";
				}
				else if (Session["Region"].ToString() == "E")
				{
					Region = "Eastern Region";
				}
				else if (Session["Region"].ToString() == "W")
				{
					Region = "Western Region";
				}
				else if (Session["Region"].ToString() == "C")
				{
					Region = "Central Region";
				}

				Response.Write("<HTML>");
				Response.Write("<body>");
				Response.Write("<P align='right'> <Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write("Region: " + Region);
				Response.Write("</Font></span></P>");
				Response.Write("<P align='Center'> <Font Face='Verdana'><span style='font-size: 12'><B><U>");
				Response.Write("BILL DETIALS AND PAYMENTS");
				Response.Write("</U></B></Font></span></P>");

				OracleDataAdapter rptDa = new OracleDataAdapter();
				OracleCommand cmd = new OracleCommand();
				string month = "";
				//				if (conn1.State == ConnectionState.Open) conn1.Close(); 
				//				conn1.Open();
				string str1 = "";
				if (BPO != "")
				{
					string sql = "select (BPO_NAME||'/'||BPO_ADD||'/'||BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER where BPO_CD='" + BPO + "'";
					OracleCommand cmd1 = new OracleCommand(sql, conn1);
					conn1.Open();
					BPONAME = Convert.ToString(cmd1.ExecuteScalar());
					conn1.Close();
					if (Period == "C")
					{
						str1 = "SELECT QA.T22_BILL.BILL_NO,to_char(QA.T22_BILL.BILL_DT,'dd/mm/yyyy')BILL_DT, QA.T22_BILL.BILL_AMOUNT, QA.T26_CHEQUE_POSTING.CHQ_NO,to_char(QA.T26_CHEQUE_POSTING.CHQ_DT,'dd/mm/yyyy')CHQ_DT, QA.T26_CHEQUE_POSTING.AMOUNT_CLEARED FROM QA.T22_BILL, QA.T26_CHEQUE_POSTING WHERE (QA.T22_BILL.BILL_NO=QA.T26_CHEQUE_POSTING.BILL_NO) AND  T22_BILL.CASE_NO IN (SELECT UNIQUE CASE_NO FROM T14_PO_BPO WHERE BPO_CD='" + BPO + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "') and (to_char(T22_BILL.BILL_DT,'mmyyyy')='" + Convert.ToString(Request.Params["MMYYYY"].Trim()) + "') Order by T22_BILL.BILL_NO";
						month = Convert.ToString(Request.Params["Month"].Trim());
						string yr = Convert.ToString(Request.Params["MMYYYY"].Trim());
						yr = yr.Substring(2, 4);
						Response.Write("<P align='Center'> <Font Face='Verdana'><span style='font-size: 10'><U>");
						Response.Write("(For the Month of " + month + " and Year of " + yr + " With BPO " + BPONAME + " )");
						Response.Write("</U></Font></span></P>");

					}
					else if (Period == "G")
					{
						string from, to;

						if (Convert.ToString(Request.Params["From"].Trim()) == null || Convert.ToString(Request.Params["From"].Trim()) == "")
						{
							from = "01/01/1900";
							to = Convert.ToString(Request.Params["To"].Trim());
							//str1="SELECT QA.T22_BILL.BILL_NO,to_char(QA.T22_BILL.BILL_DT,'dd/mm/yyyy')BILL_DT, QA.T22_BILL.BILL_AMOUNT, QA.T26_CHEQUE_POSTING.CHQ_NO,to_char(QA.T26_CHEQUE_POSTING.CHQ_DT,'dd/mm/yyyy')CHQ_DT, QA.T26_CHEQUE_POSTING.AMOUNT_CLEARED FROM QA.T22_BILL, QA.T26_CHEQUE_POSTING WHERE (QA.T22_BILL.BILL_NO=QA.T26_CHEQUE_POSTING.BILL_NO) AND  T22_BILL.CASE_NO IN (SELECT UNIQUE CASE_NO FROM T14_PO_BPO WHERE BPO_CD='"+BPO+"')and (T22_BILL.BILL_DT between to_date('"+Convert.ToString(Request.Params ["From"].Trim())+"','dd/mm/yyyy') and to_date('"+Convert.ToString(Request.Params ["To"].Trim())+"','dd/mm/yyyy')) Order by T22_BILL.BILL_NO";
							Response.Write("<P align='Center'> <Font Face='Verdana'><span style='font-size: 10'><U>");
							Response.Write("(For All Records To " + to + "  With BPO " + BPONAME + " )");
							Response.Write("</U></Font></span></P>");
						}
						else if (Convert.ToString(Request.Params["To"].Trim()) == null || Convert.ToString(Request.Params["To"].Trim()) == "")
						{
							from = Convert.ToString(Request.Params["From"].Trim());
							to = "31/12/2100";
							Response.Write("<P align='Center'> <Font Face='Verdana'><span style='font-size: 10'><U>");
							Response.Write("(For All Records From " + from + "  With BPO " + BPONAME + " )");
							Response.Write("</U></Font></span></P>");
						}
						else
						{
							from = Convert.ToString(Request.Params["From"].Trim());
							to = Convert.ToString(Request.Params["To"].Trim());

							Response.Write("<P align='Center'> <Font Face='Verdana'><span style='font-size: 10'><U>");
							Response.Write("(For All Records Between( " + Convert.ToString(Request.Params["From"].Trim()) + " TO " + Convert.ToString(Request.Params["To"].Trim()) + " ) With BPO " + BPONAME + " )");
							Response.Write("</U></Font></span></P>");
						}
						str1 = "SELECT QA.T22_BILL.BILL_NO,to_char(QA.T22_BILL.BILL_DT,'dd/mm/yyyy')BILL_DT, QA.T22_BILL.BILL_AMOUNT, QA.T26_CHEQUE_POSTING.CHQ_NO,to_char(QA.T26_CHEQUE_POSTING.CHQ_DT,'dd/mm/yyyy')CHQ_DT, QA.T26_CHEQUE_POSTING.AMOUNT_CLEARED FROM QA.T22_BILL, QA.T26_CHEQUE_POSTING WHERE (QA.T22_BILL.BILL_NO=QA.T26_CHEQUE_POSTING.BILL_NO) AND  T22_BILL.CASE_NO IN (SELECT UNIQUE CASE_NO FROM T14_PO_BPO WHERE BPO_CD='" + BPO + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "') and (T22_BILL.BILL_DT between to_date('" + from + "','dd/mm/yyyy') and to_date('" + to + "','dd/mm/yyyy')) Order by T22_BILL.BILL_NO";
					}
					else if (Period == "A")
					{
						str1 = "SELECT QA.T22_BILL.BILL_NO,to_char(QA.T22_BILL.BILL_DT,'dd/mm/yyyy')BILL_DT, QA.T22_BILL.BILL_AMOUNT, QA.T26_CHEQUE_POSTING.CHQ_NO,to_char(QA.T26_CHEQUE_POSTING.CHQ_DT,'dd/mm/yyyy')CHQ_DT, QA.T26_CHEQUE_POSTING.AMOUNT_CLEARED FROM QA.T22_BILL, QA.T26_CHEQUE_POSTING WHERE (QA.T22_BILL.BILL_NO=QA.T26_CHEQUE_POSTING.BILL_NO) AND  T22_BILL.CASE_NO IN (SELECT UNIQUE CASE_NO FROM T14_PO_BPO WHERE BPO_CD='" + BPO + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "') Order by T22_BILL.BILL_NO";
						Response.Write("<P align='Center'> <Font Face='Verdana'><span style='font-size: 10'><U>");
						Response.Write("(For All Records With BPO " + BPONAME + " )");
						Response.Write("</U></Font></span></P>");
					}



				}
				else if (PO != "")
				{
					str1 = "SELECT QA.T22_BILL.BILL_NO,to_char(QA.T22_BILL.BILL_DT,'dd/mm/yyyy')BILL_DT, QA.T22_BILL.BILL_AMOUNT, QA.T26_CHEQUE_POSTING.CHQ_NO,to_char(QA.T26_CHEQUE_POSTING.CHQ_DT,'dd/mm/yyyy')CHQ_DT, QA.T26_CHEQUE_POSTING.AMOUNT_CLEARED FROM QA.T22_BILL, QA.T26_CHEQUE_POSTING WHERE (QA.T22_BILL.BILL_NO=QA.T26_CHEQUE_POSTING.BILL_NO) AND  T22_BILL.CASE_NO IN (SELECT CASE_NO FROM T13_PO_MASTER WHERE PO_NO='" + PO + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "') Order by T22_BILL.BILL_NO";
					Response.Write("<P align='Center'> <Font Face='Verdana'><span style='font-size: 10'><U>");
					Response.Write("(For All Records With PO NO. " + PO + " )");
					Response.Write("</U></Font></span></P>");
				}
				//				if(ddlVenderCity.SelectedIndex!=0)
				//				{
				//					str1 = str1 + " and upper(c.CITY) LIKE upper('%"+ddlVenderCity.SelectedItem.Text+"%')"; 
				//				}
				//string str2=str1 + " ORDER BY v.VEND_CD ASC";

				rptDa = new OracleDataAdapter(str1, conn1);
				DataSet rptDS = new DataSet();
				conn1.Open();
				rptDa.Fill(rptDS, str1);
				conn1.Close();

				Response.Write("<Table>");
				Response.Write("<tr>");
				Response.Write("<td colspan=6>");
				Response.Write("______________________________________________________________________________________________");
				Response.Write("</td></tr>");
				Response.Write("<tr>");
				Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
				Response.Write("BILL No.");
				Response.Write("</B></Font></span></td>");
				Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
				Response.Write("BILL DATE");
				Response.Write("</B></Font></span></td>");
				Response.Write("<td width='15%' align='Center'><Font Face='Verdana'><span style='font-size: 12'><B>");
				Response.Write("BILL AMOUNT.");
				Response.Write("</B></Font></span></td>");
				Response.Write("<td width='20%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
				Response.Write("CHEQUE NO.");
				Response.Write("</B></Font></span></td>");
				Response.Write("<td width='20%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
				Response.Write("CHEQUE DATE");
				Response.Write("</B></Font></span></td>");
				Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
				Response.Write("AMOUNT RECIEVED");
				Response.Write("</B></Font></span></td></tr>");
				Response.Write("<tr>");
				Response.Write("<td colspan=6>");
				Response.Write("______________________________________________________________________________________________");
				Response.Write("</td></tr>");
				pno = 1;
				for (int i = 0; i < rptDS.Tables[0].Rows.Count; i++)
				{


					if ((i + 1) % 21 == 0)
					{

						Response.Write("<tr>");
						Response.Write("<td colspan=6>");
						Response.Write("<p style = page-break-before:always>");
						Response.Write("</p>");
						Response.Write("<P align='Center'> <Font Face='Verdana'><span style='font-size: 12'><B><U>");
						Response.Write("CHEQUE RECIEVED REPORT");
						Response.Write("</U></B></Font></span></P>");
						Response.Write("______________________________________________________________________________________________");
						Response.Write("</td></tr>");
						Response.Write("<tr>");
						Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
						Response.Write("BILL No.");
						Response.Write("</B></Font></span></td>");
						Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
						Response.Write("BILL DATE");
						Response.Write("</B></Font></span></td>");
						Response.Write("<td width='15%' align='Center'><Font Face='Verdana'><span style='font-size: 12'><B>");
						Response.Write("BILL AMOUNT.");
						Response.Write("</B></Font></span></td>");
						Response.Write("<td width='20%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
						Response.Write("CHEQUE NO.");
						Response.Write("</B></Font></span></td>");
						Response.Write("<td width='20%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
						Response.Write("CHEQUE DATE");
						Response.Write("</B></Font></span></td>");
						Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
						Response.Write("AMOUNT RECIEVED");
						Response.Write("</B></Font></span></td></tr>");
						Response.Write("<tr>");
						Response.Write("<td colspan=6>");
						Response.Write("______________________________________________________________________________________________");
						Response.Write("</td></tr>");
						pno = pno + 1;
					}
					Response.Write("<tr>");
					Response.Write("<td align='Left'><Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write(rptDS.Tables[0].Rows[i]["BILL_NO"]);
					Response.Write("</Font></span></td>");
					Response.Write("<td align='Left'><Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write(rptDS.Tables[0].Rows[i]["BILL_DT"]);
					Response.Write("</Font></span></td>");
					Response.Write("<td align='Left'><Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write(rptDS.Tables[0].Rows[i]["BILL_AMOUNT"]);
					Response.Write("</Font></span></td>");
					Response.Write("<td align='Left'><Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write(rptDS.Tables[0].Rows[i]["CHQ_NO"]);
					Response.Write("</Font></span></td>");
					Response.Write("<td align='Left'><Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write(rptDS.Tables[0].Rows[i]["CHQ_DT"]);
					Response.Write("</Font></span></td>");
					Response.Write("<td align='Left'><Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write(rptDS.Tables[0].Rows[i]["AMOUNT_CLEARED"]);
					Response.Write("</Font></span></td>");
					Response.Write("</tr>");
				}

				Response.Write("<tr>");
				Response.Write("<td colspan =6 align='center'>");

				//Response.Write("______________________________________________________________________________________________");
				Response.Write("</td>");

				Response.Write("</tr>");

				Response.Write("<tr>");
				Response.Write("<td colspan =6 align='center'>");

				//Response.Write("<input type=button name=b1 value=Print onclick='window.print();document.Form1.b1.visibility=hidden;document.Form1.b2.visibility=hidden;'>");
				//Response.Write("<input type=button name=b2 value=Cancel onclick=location.href='MainForm.aspx';>");
				//Response.Write("______________________________________________________________________________________________");
				Response.Write("</td>");

				Response.Write("</tr>");
				Response.Write("</Table>");
				Response.Write("<P align='Center' valign=bottom> <Font Face='Verdana'><span style='font-size: 10'>");
				Response.Write(pno);
				Response.Write("</Font></span></P>");
				Response.Write("</body>");
				Response.Write("</HTML>");

				//rpt.SetDataSource(rptDS.Tables[0]);
				//rpt.SetDataSource(rptDS.Tables[0]);
				//rpt.SetDatabaseLogon("qa","qa");
				//crvVender.ReportSource = rpt;body
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//string str1=str.Replace("\n","");
				Response.Write("Error!!" + str);
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
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			btnPrint.Visible = false;
			btnCancel.Visible = false;
			Response.Write("<script language=JavaScript>window.print();</script>");


		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{

		}


	}
}