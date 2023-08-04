using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_JI_Remarks_Pending_Form
{
	public partial class IE_JI_Remarks_Pending_Form : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string sql = "select COMPLAINT_ID,to_char(COMPLAINT_DT,'dd/mm/yyyy')COMPLAINT_DATE,REJ_MEMO_NO||' Dt. '||to_char(REJ_MEMO_DT,'dd/mm/yyyy') REJ_MEMO, CASE_NO,BK_NO,SET_NO,T40.IE_NAME, IE_CO_NAME,decode(COMP_RECV_REGION,'N','Northern','S','Southern','W','Western','E','Eastern','C','Central') COMP_RECV_REGION, CONSIGNEE_NAME||', '||CONSIGNEE_CITY CONSIGNEE, VENDOR, ITEM_DESC, QTY_OFFERED||' '||UOM_S_DESC QTY_OFF,QTY_REJECTED||' '||UOM_S_DESC QTY_REJECTED,REJECTION_VALUE, REJECTION_REASON, STATUS, DECODE(JI_REQUIRED,'Y','Yes','N','NO','Cancelled')JI_REQUIRED, JI_SNO, to_char(JI_DT,'dd/mm/yyyy')JI_DATE, T38.DEFECT_DESC, T39.JI_STATUS_DESC, ACTION, L5NO_PO PO_NO, to_char(PO_DT,'dd/mm/yyyy')PO_DATE, to_char(IC_DT,'dd/mm/yyyy')IC_DATE,T09.IE_NAME JI_IE_NAME,Decode(ACTION_PROPOSED,'W','Warning Letter','I','Minor Penalty','J','Major Penalty','O','Others') ACTION_PROPOSED, to_char(ACTION_PROPOSED_DT,'dd/mm/yyyy') ACTION_PROPOSED_DATE, CO_NAME, T40.CASE_NO, T40.BK_NO, T40.SET_NO  from V40_CONSIGNEE_COMPLAINTS T40,T38_DEFECT_CODES T38,T39_JI_STATUS_CODES T39,T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T40.DEFECT_CD=T38.DEFECT_CD(+) and T40.JI_STATUS_CD =T39.JI_STATUS_CD(+) and T40.JI_IE_CD=T09.IE_CD(+) and T40.IE_CO_CD=T08.CO_CD(+) and (COMPLAINT_DT>'01-APR-13') and JI_REQUIRED='Y' and JI_FIX_DT>=sysdate and T40.IE_CD='" + Session["IE_CD"].ToString() + "' and NVL(IE_JI_REMARKS,'X')='X' ";
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
				//				Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Pending JI Complaints for IE Remarks </font><br></p>");



				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'></font></b></th>");
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
					Response.Write("<td width='7%' valign='top'><a href='IE_JI_Remarks_Entry_Form.aspx?COMPLAINT_ID=" + reader["COMPLAINT_ID"].ToString() + "' Font-Names='Verdana' Font-Size='8pt'>Select</a>"); Response.Write("</td>");

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



					string fpath1 = Server.MapPath("/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF");
					if (File.Exists(fpath1) == false)
					{
						Response.Write(" ");
					}
					else
					{
						Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI CASE</font></a></td>");


					}

					string fpath2 = Server.MapPath("/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF");
					if (File.Exists(fpath2) == false)
					{
						Response.Write(" ");
					}
					else
					{
						Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI REPORT</font></a></td>");


					}
					Response.Write("</tr>");



					ctr = ctr + 1;

				}


				//				Response.Write("<tr>");
				//				Response.Write("<td width='10%' valign='top' align='right' colspan=5> <font size='1' face='Verdana'><B>");Response.Write("Total: ");Response.Write("</B></td>");
				//				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>");Response.Write(w_total_write_off);Response.Write("</B></td>");
				//				Response.Write("</tr>");
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