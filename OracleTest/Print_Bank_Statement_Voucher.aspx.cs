using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Print_Bank_Statement_Voucher
{
	public partial class Print_Bank_Statement_Voucher : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string VNO, VDT, BNAME, VTYPE;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Request.Params["VOUCHER_NO"] != null || Request.Params["VOUCHER_NO"] != "")
			{
				VNO = Convert.ToString(Request.Params["VOUCHER_NO"].Trim());
				VDT = Convert.ToString(Request.Params["VOUCHER_DT"].Trim());
				VTYPE = Convert.ToString(Request.Params["VOUCHER_TYPE"].Trim());
			}

			int pno;
			try
			{
				DataSet rptDS = new DataSet();
				double amount = 0;
				if (VTYPE == "")
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
					//Response.Write("   ");
					Response.Write("</Font></span></P>");
					//				Response.Write("<P align='Center'> <Font Face='Verdana'><span style='font-size: 12'><B><U>");
					//				Response.Write("BILL DETIALS AND PAYMENTS");
					//				Response.Write("</U></B></Font></span></P>");

					OracleDataAdapter rptDa = new OracleDataAdapter();
					OracleCommand cmd = new OracleCommand();
					//string month="";
					//				if (conn1.State == ConnectionState.Open) conn1.Close(); 
					//				conn1.Open();
					string str1 = "";

					string sql = "select B.BANK_NAME from T24_RV V, T94_BANK B where V.BANK_CD =B.BANK_CD AND VCHR_NO='" + VNO + "'";
					OracleCommand cmd1 = new OracleCommand(sql, conn1);
					conn1.Open();
					BNAME = Convert.ToString(cmd1.ExecuteScalar());
					conn1.Close();

					str1 = "select R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.AMOUNT,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND substr(VCHR_NO,1,1)='" + Session["Region"] + "' AND VCHR_NO= '" + VNO.Trim() + "' order by SNO";
					Response.Write("<Table width='95%' align='center'>");
					Response.Write("<tr>");
					Response.Write("<td colspan=3>");
					//Response.Write("====================================================================================");
					Response.Write("<HR size=4 noshade>");
					Response.Write("</td></tr>");
					//					Response.Write("<tr>");
					//					Response.Write("<td colspan=2>");
					//					Response.Write("<HR>");
					//					//Response.Write("___________________________________________________________________");
					//					Response.Write("</td></tr>");
					Response.Write("<TR><TD align='Left'><P align='Left'> <Font Face='Verdana'><span style='font-size: 12'>");

					if (Session["Region"].ToString() == "N")
					{
						Response.Write("AXIS BANK LTD.<br>Rites Bhawan, Gurgaon");

					}
					else if (Session["Region"].ToString() == "S")
					{
						Response.Write("AXIS BANK LTD.<br>Chennai");
					}
					else if (Session["Region"].ToString() == "E")
					{
						Response.Write("AXIS BANK LTD.<br>Rites Bhawan, Gurgaon");
					}
					else if (Session["Region"].ToString() == "W")
					{
						Response.Write("AXIS BANK.<br>Mumbai");
					}
					else if (Session["Region"].ToString() == "C")
					{
						Response.Write("AXIS BANK LTD.<br>Rites Bhawan, Gurgaon");
					}

					Response.Write("</Font></span></P></TD>");
					Response.Write("<TD align='center'> <Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write(VNO);
					Response.Write("</Font></span></TD>");
					Response.Write("<TD align='center'> <Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write(" Dated: " + VDT);
					Response.Write("</Font></span></TD></TR>");

					string sql2 = "select sum(AMOUNT) from T25_RV_DETAILS where VCHR_NO='" + VNO + "'";
					OracleCommand cmd2 = new OracleCommand(sql2, conn1);
					conn1.Open();
					amount = Convert.ToDouble(cmd2.ExecuteScalar());
					conn1.Close();
					//Response.Write("</U></Font></span></P>");
					Response.Write("<TR><TD align='Left' colspan=3> <Font Face='Verdana'><span style='font-size: 12'><U>");
					if (Session["Region"].ToString() == "N")
					{
						Response.Write("C. A/C. No. 131010200012272 OF RITES LTD. <B><U>CHEQUE/CASH Rs." + amount + "</U></B>");

					}
					else if (Session["Region"].ToString() == "S")
					{
						Response.Write("C. A/C. No. 006010200009843 OF RITES LTD. <B><U>CHEQUE/CASH Rs." + amount + "</U></B>");
					}
					else if (Session["Region"].ToString() == "E")
					{
						Response.Write("C. A/C. No. 131010200012272 OF RITES LTD. <B><U>CHEQUE/CASH Rs." + amount + "</U></B>");
					}
					else if (Session["Region"].ToString() == "W")
					{
						Response.Write("C. A/C. No. 004010200023773 OF RITES LTD. <B><U>CHEQUE/CASH Rs." + amount + "</U></B>");
					}
					else if (Session["Region"].ToString() == "C")
					{
						Response.Write("C. A/C. No. 131010200012272 OF RITES LTD. CHEQUE/CASH Rs." + amount);
					}
					//Response.Write(VNO+ " Dated: "+DT);
					Response.Write("</U></Font></span></TD></TR></Table>");
					rptDa = new OracleDataAdapter(str1, conn1);

					conn1.Open();
					rptDa.Fill(rptDS, str1);
					conn1.Close();

					Response.Write("<Table width='95%' align='center'>");
					Response.Write("<tr>");
					Response.Write("<td colspan=5>");
					//Response.Write("====================================================================================");
					Response.Write("<HR size=4 noshade>");
					Response.Write("</td></tr>");
					Response.Write("<tr>");
					Response.Write("<td colspan=5 align='Center'>");
					Response.Write("CASHIER");
					Response.Write("</td></tr>");

					pno = 1;
					print_cheque_details(rptDS, amount);
					Response.Write("<tr>");
					Response.Write("<td colspan =5 align='center'>");
					//Response.Write("====================================================================================");
					Response.Write("<HR size=4 noshade>");
					Response.Write("</td>");
					Response.Write("</tr>");

					Response.Write("<tr>");
					Response.Write("<td colspan =5 align='center'>");
					Response.Write("----------------------------------------------Tear At This Place------------------------------------------------");
					//Response.Write("<HR Width='35%'>Tear At This Place<HR Width='35%'>");
					Response.Write("</td>");
					Response.Write("</tr>");

					Response.Write("<tr>");
					Response.Write("<td colspan =5 align='center'>");
					//Response.Write("====================================================================================");
					Response.Write("<HR size=4 noshade>");
					Response.Write("</td>");
					Response.Write("</tr>");

					Response.Write("</Table>");


					Response.Write("<Table  width='95%' align='center'>");
					//				Response.Write("<tr>");
					//				Response.Write("<td colspan=3>");
					//				Response.Write("==================================================================================");
					//				Response.Write("</td></tr>");
					//					Response.Write("<tr>");
					//					Response.Write("<td colspan=2>");
					//					Response.Write("<HR>");
					//					//Response.Write("___________________________________________________________________");
					//					Response.Write("</td></tr>");
					Response.Write("<TR><TD align='Left' width='30%'><P align='Left'> <Font Face='Verdana'><span style='font-size: 12'>");
					if (Session["Region"].ToString() == "N")
					{
						Response.Write("AXIS BANK LTD.<br>Rites Bhawan, Gurgaon");

					}
					else if (Session["Region"].ToString() == "S")
					{
						Response.Write("AXIS BANK LTD.<br>Chennai");
					}
					else if (Session["Region"].ToString() == "E")
					{
						Response.Write("AXIS BANK LTD.<br>Rites Bhawan, Gurgaon");
					}
					else if (Session["Region"].ToString() == "W")
					{
						Response.Write("AXIS BANK.<br>Mumbai");
					}
					else if (Session["Region"].ToString() == "C")
					{
						Response.Write("AXIS BANK LTD.<br>Rites Bhawan, Gurgaon");
					}
					Response.Write("</Font></span></P></TD>");
					Response.Write("<TD align='center' width='25%'> <Font Face='Verdana'><span style='font-size: 12'><U>");
					Response.Write("CREDIT VOUCHER   </U>" + VNO + "</Font></span>");
					Response.Write("</TD>");
					Response.Write("<TD align='center' width='25%'> <Font Face='Verdana'><span style='font-size: 12'><U>");
					Response.Write("L.F.");
					Response.Write("</U></Font></span></TD>");
					Response.Write("<TD align='center' width='20%'> <Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write("Dated: " + VDT);
					Response.Write("</Font></span></TD></TR>");

					//				string sql2="select sum(AMOUNT) from T25_RV_DETAILS where VCHR_NO='"+VNO+"'"; 
					//				OracleCommand cmd2=new OracleCommand(sql2,conn1);
					//				conn1.Open();
					//				double amount=Convert.ToDouble(cmd2.ExecuteScalar());
					//				conn1.Close();
					//Response.Write("</U></Font></span></P>");
					Response.Write("<TR><TD align='left' colspan=4> <Font Face='Verdana'><span style='font-size: 12'><U>");
					if (Session["Region"].ToString() == "N")
					{
						Response.Write("C. A/C. No. 131010200012272 OF RITES LTD. <B><U>CHEQUE/CASH Rs." + amount + "</U></B>");

					}
					else if (Session["Region"].ToString() == "S")
					{
						Response.Write("C. A/C. No. 006010200009843 OF RITES LTD. <B><U>CHEQUE/CASH Rs." + amount + "</U></B>");
					}
					else if (Session["Region"].ToString() == "E")
					{
						Response.Write("C. A/C. No. 131010200012272 OF RITES LTD. <B><U>CHEQUE/CASH Rs." + amount + "</U></B>");
					}
					else if (Session["Region"].ToString() == "W")
					{
						Response.Write("C. A/C. No. 004010200023773 OF RITES LTD. <B><U>CHEQUE/CASH Rs." + amount + "</U></B>");
					}
					else if (Session["Region"].ToString() == "C")
					{
						Response.Write("C. A/C. No. 131010200012272 OF RITES LTD. <B><U>CHEQUE/CASH Rs." + amount + "</U></B>");
					}
					//Response.Write(VNO+ " Dated: "+DT);
					Response.Write("</U></Font></span></TD></TR>");
					Response.Write("<TR><TD align='left' colspan=4> <Font Face='Verdana'><span style='font-size: 12'><U>");
					Response.Write("                        ");
					Response.Write("</U></Font></span></TD></TR>");
					Response.Write("<TR><TD align='Left' colspan=2> <Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write("ACCOUNTANT</TD>");
					Response.Write("<TD align='Left' colspan=2> <Font Face='Verdana'><span style='font-size: 12'>");
					Response.Write("DEPOSITED BY</TD></TR></Table>");
					//				rptDa = new OracleDataAdapter(str1,conn1);
					//				DataSet rptDS = new DataSet();
					//				conn1.Open();
					//				rptDa.Fill(rptDS,str1);
					//				conn1.Close();

					Response.Write("<Table width='95%' align='center'>");
					Response.Write("<tr>");
					Response.Write("<td colspan=5>");
					//Response.Write("====================================================================================");
					Response.Write("<HR size=4 noshade>");
					Response.Write("</td></tr>");
					Response.Write("<tr>");
					Response.Write("<td colspan=5 align='Center'>");
					Response.Write("PARTICULARS OF CHEQUES");
					Response.Write("</td></tr>");
					print_cheque_details(rptDS, amount);
					Response.Write("<Table width='100%'>");
					Response.Write("<tr><td>");
					Response.Write("<p style = page-break-before:always>");
					Response.Write("</p>");
					Response.Write("</td></tr></table>");
				}




				//				Response.Write("<P align='Center' valign=bottom> <Font Face='Verdana'><span style='font-size: 10'>");
				//				Response.Write(pno);
				//				Response.Write("</Font></span></P>");


				print_voucher();
				Response.Write("</body>");
				Response.Write("</HTML>");
				//						Response.Write("</p>");
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
		void print_cheque_details(DataSet rptDS, double amount)
		{
			Response.Write("<tr>");
			Response.Write("<td colspan=5>");
			//Response.Write("----------------------------------------------------------------------------------------------------------------------------------------------");
			Response.Write("<HR>");
			Response.Write("</td></tr>");
			Response.Write("<tr>");
			Response.Write("<td width='10%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
			Response.Write("S No.");
			Response.Write("</B></Font></span></td>");
			Response.Write("<td width='30%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
			Response.Write("Drawee Bank");
			Response.Write("</B></Font></span></td>");
			Response.Write("<td width='25%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
			Response.Write("Cheque No");
			Response.Write("</B></Font></span></td>");
			Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
			Response.Write("Date");
			Response.Write("</B></Font></span></td>");
			Response.Write("<td width='15%' align='Right'><Font Face='Verdana'><span style='font-size: 12'><B>");
			Response.Write("Amount (Rs.)");
			Response.Write("</B></Font></span></td></tr>");
			Response.Write("<tr>");
			Response.Write("<td colspan=5>");
			//Response.Write("----------------------------------------------------------------------------------------------------------------------------------------------");
			Response.Write("<HR>");
			Response.Write("</td></tr>");
			for (int i = 0; i < rptDS.Tables[0].Rows.Count; i++)
			{


				//					if((i+1)%21==0)
				//					{
				//						
				//						Response.Write("<tr>");
				//						Response.Write("<td colspan=6>");
				//						Response.Write("<p style = page-break-before:always>");
				//						Response.Write("</p>");
				//						Response.Write("<P align='Center'> <Font Face='Verdana'><span style='font-size: 12'><B><U>");
				//						Response.Write("CHEQUE RECIEVED REPORT");
				//						Response.Write("</U></B></Font></span></P>");
				//						Response.Write("______________________________________________________________________________________________");
				//						Response.Write("</td></tr>");
				//						Response.Write("<tr>");
				//						Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
				//						Response.Write("BILL No.");
				//						Response.Write("</B></Font></span></td>");
				//						Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
				//						Response.Write("BILL DATE");
				//						Response.Write("</B></Font></span></td>");
				//						Response.Write("<td width='15%' align='Center'><Font Face='Verdana'><span style='font-size: 12'><B>");
				//						Response.Write("BILL AMOUNT.");
				//						Response.Write("</B></Font></span></td>");
				//						Response.Write("<td width='20%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
				//						Response.Write("CHEQUE NO.");
				//						Response.Write("</B></Font></span></td>");
				//						Response.Write("<td width='20%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
				//						Response.Write("CHEQUE DATE");
				//						Response.Write("</B></Font></span></td>");
				//						Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'><B>");
				//						Response.Write("AMOUNT RECIEVED");
				//						Response.Write("</B></Font></span></td></tr>");
				//						Response.Write("<tr>");
				//						Response.Write("<td colspan=6>");
				//						Response.Write("______________________________________________________________________________________________");
				//						Response.Write("</td></tr>");
				//						pno=pno+1;
				//					}
				Response.Write("<tr>");
				Response.Write("<td width='10%' align='Left'><Font Face='Verdana'><span style='font-size: 12'>");
				Response.Write(i + 1);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='30%' align='Left'><Font Face='Verdana'><span style='font-size: 12'>");
				Response.Write(rptDS.Tables[0].Rows[i]["BANK_NAME"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='25%' align='Left'><Font Face='Verdana'><span style='font-size: 12'>");
				Response.Write(rptDS.Tables[0].Rows[i]["CHQ_NO"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='15%' align='Left'><Font Face='Verdana'><span style='font-size: 12'>");
				Response.Write(rptDS.Tables[0].Rows[i]["CHQ_DT"]);
				Response.Write("</Font></span></td>");
				Response.Write("<td width='15%' align='Right'><Font Face='Verdana'><span style='font-size: 12'>");
				Response.Write(rptDS.Tables[0].Rows[i]["AMOUNT"]);
				Response.Write("</Font></span></td>");
				Response.Write("</tr>");
			}
			Response.Write("<tr>");
			Response.Write("<td></td>");
			Response.Write("<td></td>");
			Response.Write("<td></td>");
			Response.Write("<td></td>");
			Response.Write("<td align='Right'>");
			Response.Write("--------------");
			Response.Write("</td>");
			Response.Write("</tr>");
			Response.Write("<tr>");
			Response.Write("<td></td>");
			Response.Write("<td></td>");
			Response.Write("<td></td>");
			Response.Write("<td></td>");
			Response.Write("<td align='right'>");
			Response.Write(amount);
			Response.Write("</td>");
			Response.Write("</tr>");
			Response.Write("<tr>");
			Response.Write("<td></td>");
			Response.Write("<td></td>");
			Response.Write("<td></td>");
			Response.Write("<td></td>");
			Response.Write("<td align='right'>");
			Response.Write("--------------");

			Response.Write("</td>");
			Response.Write("</tr>");
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
		void print_voucher()
		{
			string wRegion = "";
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

			Response.Write("<P align='center'> <Font Face='Verdana'><span style='font-size: 12'>");
			Response.Write("<B>RITES LTD</B><BR>BANK VOUCHER<BR>ACCOUNTING UNIT - " + wRegion);

			Response.Write("</Font></span></P>");

			OracleDataAdapter rptDa = new OracleDataAdapter();
			OracleCommand cmd = new OracleCommand();

			string str1 = "";

			string sql = "select V.BANK_CD, B.BANK_NAME from T24_RV V, T94_BANK B where V.BANK_CD =B.BANK_CD AND VCHR_NO='" + VNO + "'";
			OracleCommand cmd1 = new OracleCommand(sql, conn1);
			conn1.Open();
			OracleDataReader reader1 = cmd1.ExecuteReader();



			Response.Write("<Table Width=100% border=0>");

			//					Response.Write("<tr>");
			//					Response.Write("<td colspan=2>");
			//					Response.Write("<HR>");
			//					//Response.Write("___________________________________________________________________");
			//					Response.Write("</td></tr>");
			Response.Write("<TR><TD align='Left' colspan=1><P align='Left'> <Font Face='Verdana'><span style='font-size: 12'>");
			Response.Write("Date: " + VDT);
			Response.Write("</Font></span></TD>");
			Response.Write("<TD align='Left' colspan=2><P align='Left'> <Font Face='Verdana'><span style='font-size: 12'>");

			while (reader1.Read())
			{
				if (Session["Region"].ToString() == "N")
				{
					Response.Write("Bank : " + reader1["BANK_CD"].ToString() + " - " + reader1["BANK_NAME"].ToString() + " - NR");

				}
				else if (Session["Region"].ToString() == "S")
				{
					Response.Write("Bank : " + reader1["BANK_CD"].ToString() + " - " + reader1["BANK_NAME"].ToString() + " - SR");
				}
				else if (Session["Region"].ToString() == "E")
				{
					Response.Write("Bank : " + reader1["BANK_CD"].ToString() + " - " + reader1["BANK_NAME"].ToString() + " - ER");
				}
				else if (Session["Region"].ToString() == "W")
				{
					Response.Write("Bank : " + reader1["BANK_CD"].ToString() + " - " + reader1["BANK_NAME"].ToString() + " - WR");
				}
				else if (Session["Region"].ToString() == "C")
				{
					Response.Write("Bank : " + reader1["BANK_CD"].ToString() + " - " + reader1["BANK_NAME"].ToString() + " - CR");
				}

			}

			Response.Write("</Font></span></TD></TR>");
			Response.Write("<TR><TD align='Left' colspan=1><P align='Left'> <Font Face='Verdana'><span style='font-size: 12'>");
			Response.Write("Number: " + VNO);
			Response.Write("</Font></span></P></TD>");
			Response.Write("<TD align='Left' colspan=2> <Font Face='Verdana'><span style='font-size: 12'>");
			Response.Write(" Currency : RUPEES");
			Response.Write("</Font></span></TD></TR></Table>");
			conn1.Close();
			//					
			//					string sql2="select sum(AMOUNT) from T25_RV_DETAILS where VCHR_NO='"+VNO+"'"; 
			//					OracleCommand cmd2=new OracleCommand(sql2,conn1);
			//					conn1.Open();
			//					double amount=Convert.ToDouble(cmd2.ExecuteScalar());
			//					conn1.Close();
			//Response.Write("</U></Font></span></P>");
			str1 = "select R.CHQ_NO,TO_CHAR(R.CHQ_DT,'DD/MM/YYYY') CHQ_DATE,R.AMOUNT,D.BANK_NAME,R.ACC_CD,NVL2(R.BPO_CD,B.BPO_CD||'-'||(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),R.NARRATION) NARRATION from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D, T03_CITY C where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD and B.BPO_CITY_CD=C.CITY_CD(+) AND substr(VCHR_NO,1,1)='" + Session["Region"] + "' AND VCHR_NO= '" + VNO.Trim() + "' order by SNO";
			OracleCommand cmd11 = new OracleCommand(str1, conn1);
			conn1.Open();
			OracleDataReader reader = cmd11.ExecuteReader();



			int ctr = 60;

			string first_page = "Y";
			double wtotamt = 0;

			try
			{

				while (reader.Read())
				{
					if (ctr > 50)
					{
						Response.Write("<table border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='10'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>"); Response.Write("<td width='100%' colspan='10'>"); Response.Write("<HR>"); Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='5%' valign='top' align='Left'><b><font size='1' face='Verdana'>TC</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='left'><b><font size='1' face='Verdana'>Account Code.</font></b></th>");
						Response.Write("<th width='5%' valign='top' align='Left'><b><font size='1' face='Verdana'>Sub Code</font></b></th>");
						Response.Write("<th width='5%' valign='top' align='Left'><b><font size='1' face='Verdana'>Ref No</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='Left'><b><font size='1' face='Verdana'>SBU Code</font></b></th>");
						Response.Write("<th width='8%' valign='top' align='Left'><b><font size='1' face='Verdana'>Project Code</font></b></th>");
						Response.Write("<th width='25%' valign='top' align='Left'><b><font size='1' face='Verdana'>BPO/Narration</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='Left'><b><font size='1' face='Verdana'>Amount</font></b></th>");
						Response.Write("<th width='12%' valign='top' align='Left'><b><font size='1' face='Verdana'>Cheque No.</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='Left'><b><font size='1' face='Verdana'>Cheque Dt.</font></b></th>");
						Response.Write("</tr></font>");
						Response.Write("<tr>"); Response.Write("<td width='100%' colspan='10'>"); Response.Write("<HR>"); Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>"); Response.Write("<td width='100%' colspan='10' align='Left'>"); Response.Write("<U>Credit</U>"); Response.Write("</td>"); Response.Write("</tr>");
						ctr = 9;
					};

					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>2</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ACC_CD"]); Response.Write("</td>");
					Response.Write("<td width='5%'>&nbsp</td>");
					Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>");

					if (Session["Region"].ToString() == "N")
					{
						Response.Write("20");
					}
					else if (Session["Region"].ToString() == "S")
					{
						Response.Write("19");
					}
					else if (Session["Region"].ToString() == "E")
					{
						Response.Write("18");
					}
					else if (Session["Region"].ToString() == "W")
					{
						Response.Write("17");
					}
					else if (Session["Region"].ToString() == "C")
					{
						Response.Write("23");
					}
					Response.Write("</td>");
					Response.Write("<td width='8%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write("</td>");
					Response.Write("<td width='25%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["NARRATION"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["AMOUNT"]);
					wtotamt = wtotamt + Convert.ToDouble(reader["AMOUNT"]);
					Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHQ_DATE"]); Response.Write("</td>");
					Response.Write("</tr>");
					ctr = ctr + 1;
				};
				Response.Write("</tr>");
				Response.Write("<tr>"); Response.Write("<td colspan='10'>"); Response.Write("<HR>"); Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<tr>");
				Response.Write("<td width='5%'>"); Response.Write("</td>");
				Response.Write("<td width='10%'>"); Response.Write("</td>");
				Response.Write("<td width='5%'>"); Response.Write("</td>");
				Response.Write("<td width='5%'>"); Response.Write("</td>");
				Response.Write("<td width='10%'>"); Response.Write("</td>");
				Response.Write("<td width='8%'>"); Response.Write("</td>");
				Response.Write("<td width='25%'>"); Response.Write("</td>");
				Response.Write("<td align='Right'><font size='1' face='Verdana'>"); Response.Write(wtotamt); Response.Write("</font></td>");
				Response.Write("<td width='10%'>"); Response.Write("</td>");
				Response.Write("<td width='10%'>"); Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>"); Response.Write("<td colspan='10'>"); Response.Write("<HR>"); Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='4' align='left'><font size='1' face='Verdana'><b>"); Response.Write("Prepared By: "); Response.Write("</B></font></td>");
				Response.Write("<td width='100%' colspan='5' align='left'><font size='1' face='Verdana'><b>"); Response.Write("Checked By:</B> "); Response.Write("</font></td>");
				Response.Write("</tr>");
				Response.Write("</tr>");
				Response.Write("<tr>"); Response.Write("<td colspan='10'>"); Response.Write("&nbsp"); Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("</tr>");
				Response.Write("<tr>"); Response.Write("<td colspan='10'>"); Response.Write("&nbsp"); Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("</tr>");
				Response.Write("<tr>"); Response.Write("<td colspan='10'>"); Response.Write("&nbsp"); Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("</tr>");
				Response.Write("<tr>"); Response.Write("<td colspan='10'>"); Response.Write("&nbsp"); Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<tr>"); Response.Write("<td width='100%' colspan='10' align='left'><font size='1' face='Verdana'><b>"); Response.Write("Received By:"); Response.Write("</font></td>"); Response.Write("</tr>");

				Response.Write("</table>");

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str11 = str.Replace("\n", "");
				Response.Redirect(("/RBS/Error_Form.aspx?err=" + str11));
			}
			finally
			{
				conn1.Close();
			}





		}
		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			btnPrint.Visible = false;
			btnCancel.Visible = false;
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}
	}
}