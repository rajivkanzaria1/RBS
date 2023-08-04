using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IC_DETAILS
{
	public partial class IC_DETAILS : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string CNO, DT, CSNO;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Convert.ToString(Request.Params["CASE_NO"]) == null || Convert.ToString(Request.Params["CALL_DT"]) == null || Convert.ToString(Request.Params["CALL_SNO"]) == null)
			{
				CNO = "";
				DT = "";
				CSNO = "";
			}
			else
			{
				CNO = Convert.ToString(Request.Params["CASE_NO"].Trim());
				DT = Convert.ToString(Request.Params["CALL_DT"].Trim());
				CSNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
				ic_details();
			}

		}


		void ic_details()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn.Close();
			//string mySql="select T13.CASE_NO,T13.RLY_CD, T09.IE_SNAME, T17.CALL_INSTALL_NO,  V05.VENDOR,M05.VENDOR,B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY) BPO, T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DATE, V06.CONSIGNEE PURCHASER from T13_PO_MASTER T13,T17_CALL_REGISTER T17, V05_VENDOR V05,V05_VENDOR M05, T12_BILL_PAYING_OFFICER B, T03_CITY C, T09_IE T09, V06_CONSIGNEE V06, T14_PO_BPO T14 WHERE T13.CASE_NO=T17.CASE_NO AND T13.VEND_CD=V05.VEND_CD AND T17.MFG_CD=M05.VEND_CD AND T13.CASE_NO=T14.CASE_NO AND T17.IE_CD=T09.IE_CD AND T13.CASE_NO=T14.CASE_NO AND T14.BPO_CD=B.BPO_CD  AND T13.PURCHASER_CD=V06.CONSIGNEE_CD AND B.BPO_CITY_CD=C.CITY_CD AND T13.CASE_NO='N17051097' AND TO_CHAR(T17.CALL_RECV_DT,'DD/MM/YYYY')='21/06/2017' AND T17.CALL_SNO=130 and T13.REGION_CODE='N'";
			string mySql = "select T13.CASE_NO,T13.RLY_CD, T09.IE_SNAME, T17.CALL_INSTALL_NO,  V05.VENDOR,M05.VENDOR MANUFACTURER,B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY) BPO, T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DATE, V06.CONSIGNEE PURCHASER, C06.CONSIGNEE CONSIGNEE from T13_PO_MASTER T13,T17_CALL_REGISTER T17, V05_VENDOR V05,V05_VENDOR M05, T12_BILL_PAYING_OFFICER B, T03_CITY C, T09_IE T09, V06_CONSIGNEE V06, T14_PO_BPO T14,  V06_CONSIGNEE C06  " +
				"WHERE T13.CASE_NO=T17.CASE_NO AND T13.VEND_CD=V05.VEND_CD AND T17.MFG_CD=M05.VEND_CD AND T17.IE_CD=T09.IE_CD AND T13.CASE_NO=T14.CASE_NO AND T14.BPO_CD=B.BPO_CD AND T14.CONSIGNEE_CD=C06.CONSIGNEE_CD AND T13.PURCHASER_CD=V06.CONSIGNEE_CD AND B.BPO_CITY_CD=C.CITY_CD  " +
				"AND T13.CASE_NO='" + CNO + "' AND TO_CHAR(T17.CALL_RECV_DT,'DD/MM/YYYY')='" + DT + "' AND T17.CALL_SNO=" + CSNO + " and T13.REGION_CODE='" + Session["Region"].ToString() + "'";
			try
			{

				OracleCommand cmd = new OracleCommand(mySql, conn);
				conn.Open();
				OracleDataReader reader11 = cmd.ExecuteReader();

				while (reader11.Read())
				{
					Response.Write("<br><table border='1' style='border-collapse: collapse;' bordercolor='#111111' width='100%' height='100%'>");
					Response.Write("<tr height='5%'><td align='center'>");
					Response.Write("<font face='Verdana'><U>INSPECTION CERTIFICATE</U></font><br>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr height='10%'>");
					Response.Write("<td>");
					Response.Write("<table border='1' width='100%' height='100%'>");
					Response.Write("<tr>");
					Response.Write("<td valign='top'><font size='1' face='Verdana'>Book No    Set No.</font>");
					Response.Write("<td valign='top'><font size='1' face='Verdana'>Certificate No. <b>" + Session["Region"].ToString() + '/' + reader11["RLY_CD"].ToString() + '/' + reader11["CASE_NO"].ToString() + '/' + reader11["IE_SNAME"].ToString() + "</b></font>");
					Response.Write("<td valign='top'><font size='1' face='Verdana'>Date <b>" + ss + "</font>");
					Response.Write("<td valign='top'><font size='1' face='Verdana'>Offered Installment No.: <b> " + reader11["CALL_INSTALL_NO"].ToString() + "</b></font>");
					Response.Write("</td></tr>");
					Response.Write("<tr>");
					Response.Write("<td valign='top' colspan=2><font size='1' face='Verdana'>Contractor. <b>" + reader11["VENDOR"].ToString() + "</b></font>");
					Response.Write("<td valign='top'><font size='1' face='Verdana'>Manufacturer <b>" + reader11["MANUFACTURER"].ToString() + "</b></font>");
					Response.Write("<td valign='top'><font size='1' face='Verdana'>Place of Inspection:  <b>" + reader11["MANUFACTURER"].ToString() + "</b></font>");
					Response.Write("</td></tr>");
					Response.Write("<tr>");
					Response.Write("<td valign='top' colspan=2><font size='1' face='Verdana'>Contract Reference <b>" + reader11["PO_NO"].ToString() + ", Date : " + reader11["PO_DATE"].ToString() + "</b></font>");
					Response.Write("<td valign='top' colspan=2><font size='1' face='Verdana' >Bill Paying Officer  <b>" + reader11["BPO"].ToString() + "</b></font>");
					Response.Write("</td></tr>");
					Response.Write("<tr>");
					Response.Write("<td valign='top' colspan=2><font size='1' face='Verdana'>Consignee <b>" + reader11["CONSIGNEE"].ToString() + "</b></font>");
					Response.Write("<td valign='top' colspan=2><font size='1' face='Verdana'>Purchasing Authority <b>" + reader11["PURCHASER"].ToString() + "</b></font>");
					Response.Write("</td></tr></table></td></tr>");


					string mySql11 = "Select T18.CASE_NO,ITEM_SRNO,ITEM_DESC,QTY_ORDERED,CUM_QTY_PREV_OFFERED, CUM_QTY_PREV_PASSED, QTY_TO_INSP, t04.UOM_S_DESC From T15_PO_DETAIL t15, T18_CALL_DETAILS t18, T04_UOM t04 Where t15.CASE_NO=t18.CASE_NO AND t15.UOM_CD=t04.UOM_CD and t15.ITEM_SRNO=t18.ITEM_SRNO_PO AND t18.CASE_NO='" + CNO + "' AND TO_CHAR(t18.CALL_RECV_DT,'DD/MM/YYYY')='" + DT + "' AND t18.CALL_SNO=" + CSNO + " and substr(T15.CASE_NO,1,1)='" + Session["Region"].ToString() + "' order by t15.CASE_NO,t15.ITEM_SRNO";
					OracleCommand cmd11 = new OracleCommand(mySql11, conn);
					//conn.Open();
					OracleDataReader reader = cmd11.ExecuteReader();

					Response.Write("<tr height='50%'><td><table border='1' width='100%' height='100%'>");
					Response.Write("<tr><td width='5%' valign='top'><font size='1' face='Verdana'>Item No</font></td>");
					Response.Write("<td width='35%' valign='top'><font size='1' face='Verdana'>Description of Stores</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Qty On Order</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Cumulative Qty offered previously</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Quantity previously passed</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Qty now offered</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Qty now Passed</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Qty now Rejected</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Qty still Due</font></td>");
					Response.Write("</tr></font>");
					int i = 0;
					while (reader.Read())
					{
						i = i + 1;

						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(i); Response.Write("</td>");
						Response.Write("<td width='35%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_ORDERED"].ToString() + " " + reader["UOM_S_DESC"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["CUM_QTY_PREV_OFFERED"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["CUM_QTY_PREV_PASSED"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(reader["QTY_TO_INSP"].ToString() + " " + reader["UOM_S_DESC"].ToString()); Response.Write("</b></td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write("<br><br><br><br><br><br><br><br><br><br><br><br><br><br>"); Response.Write("</td>");
						Response.Write("</tr>");
						//							ctr=ctr+1;

					}
					//conn.Close();
					Response.Write("</table></td></tr>");
					string mySql1 = "select to_char(VISIT_DT,'dd/mm/yyyy') VISIT_DATE FROM T47_IE_WORK_PLAN WHERE CASE_NO='" + CNO + "' AND TO_CHAR(CALL_RECV_DT,'DD/MM/YYYY')='" + DT + "' AND CALL_SNO='" + CSNO + "'";

					OracleCommand cmd1 = new OracleCommand(mySql1, conn);
					//conn.Open();
					OracleDataReader reader1 = cmd1.ExecuteReader();
					int wSno = 0;
					string insp_dt = "";

					Response.Write("<tr height='30%'><td><table border='1' width='100%' height='100%'>");
					Response.Write("<tr><td width='5%' valign='top'><font size='1' face='Verdana'>No. of items checked</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Date of call</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>No. of visits</font></td>");
					Response.Write("<td width='5%' valign='top'><font size='1' face='Verdana'>Date(s) of Inspection</font></td>");
					Response.Write("</tr></font>");
					//						while (reader1.Read() && wSno<=10)

					while (reader1.Read())
					{
						if (wSno == 0)
						{
							insp_dt = reader1["VISIT_DATE"].ToString();
						}
						else
						{
							insp_dt = insp_dt + ", " + reader1["VISIT_DATE"].ToString();
						}


						wSno = wSno + 1;
					}
					//conn.Close();
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(i); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(DT); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wSno); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(insp_dt); Response.Write("</td>");
					Response.Write("</tr>");
					//Response.Write("</table></td></tr>");


					//Response.Write("<tr><td>");
					Response.Write("<tr>");
					Response.Write("<td width='10%' height='20%' valign='top'><font size='1' face='Verdana' colspan=2>Pattern of Sealing/stamping and location of seal/stamp/sticker</font></td>");
					Response.Write("<td width='10%' height='20%' valign='top'><font size='1' face='Verdana'>Fascimile of Seal/Sticker</font></td>");
					Response.Write("<td width='5%'  height='20%' valign='top'><font size='1' face='Verdana'>Inspection Engineer<br><br><br><br></font></td>");
					Response.Write("</tr></table></td></tr></font>");
					//						while (reader1.Read() && wSno<=10)
					Response.Write("<tr height='5%'><td width='20%' valign='top'><font size='1' face='Verdana'>Reason for Rejection</font></td></tr>");

					Response.Write("</table>");
				}


				conn.Close();

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("/RBS/Reports/Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn.Close();
				conn.Dispose();
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