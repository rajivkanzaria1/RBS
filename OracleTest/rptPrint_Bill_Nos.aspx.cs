using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.rptPrint_Bill_Nos
{
	public partial class rptPrint_Bill_Nos : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string wStatus, wFrmDt, wToDt, wRegion, wFrmBNO, wToBNO, wType, wCtype, wClient;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (Convert.ToString(Request.QueryString["Status"]).Equals("Null") == true)
			{
				wStatus = Convert.ToString(Request.QueryString["Status"]);
				wFrmBNO = Convert.ToString(Request.QueryString["FRM_BNO"]);
				wToBNO = Convert.ToString(Request.QueryString["TO_BNO"]);
				wRegion = Convert.ToString(Request.QueryString["REGION"]);
				wType = Convert.ToString(Request.QueryString["Type"]);
			}
			else
			{
				wStatus = Convert.ToString(Request.QueryString["Status"]);
				wFrmDt = Convert.ToString(Request.QueryString["FRM_DT"]);
				wToDt = Convert.ToString(Request.QueryString["TO_DT"]);
				wRegion = Convert.ToString(Request.QueryString["REGION"]);
				wType = Convert.ToString(Request.QueryString["Type"]);
				wCtype = Convert.ToString(Request.QueryString["CTYPE"]);
				wClient = Convert.ToString(Request.QueryString["CLIENT"]);
			}

			if (Convert.ToString(Request.QueryString["Type"]).Equals("Null") == true)
			{
				PrintBillNos();
			}
			else if (Convert.ToString(Request.QueryString["Type"]).Equals("U") == true)
			{
				PrintBillNos_UID();
			}
		}


		void PrintBillNos()
		{
			string sql = "";
			string wHead = "";
			if (Convert.ToString(Request.QueryString["Status"]).Equals("Null") == true)
			{
				sql = "select BILL_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DT from V22_BILL where (BILL_NO BETWEEN '" + wFrmBNO + "' AND '" + wToBNO + "') and REGION_CODE='" + wRegion + "' Order by BILL_NO";
				wHead = "All Bill No's From : " + wFrmBNO + " To " + wToBNO;
			}
			else
			{
				if (wCtype == "" || wCtype == null)
				{
					sql = "select BILL_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DT from V22_BILL where (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and REGION_CODE='" + wRegion + "'";
				}
				else
				{
					sql = "select BILL_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DT from V22_BILL where (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND BPO_TYPE='" + wCtype + "' AND BPO_RLY='" + wClient + "' and REGION_CODE='" + wRegion + "'";
				}
				wHead = "";
				if (wStatus == "N")
				{
					sql = sql + " and BILL_STATUS is NULL";
					wHead = "New Bill No's For The Period For : " + wFrmDt + " TO " + wToDt;
				}
				else if (wStatus == "U")
				{
					sql = sql + " and BILL_STATUS='U'";
					wHead = "Updated Bill No's For The Period For : " + wFrmDt + " TO " + wToDt;
				}
				else
				{
					wHead = "All Bill No's For The Period For : " + wFrmDt + " TO " + wToDt;
				}
				sql = sql + " Order by BILL_DT,BILL_NO";
			}
			int ctr = 60;
			int wSno = 0;
			//			string first_page="Y";      

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='50%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='3'>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='3'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wHead + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill Date</font></b></th>");
				Response.Write("</tr></font>");
				ctr = 6;
				while (reader.Read())
				{
					//					if (ctr >59) 
					//					{

					//					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DT"]); Response.Write("</td>");
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
		void PrintBillNos_UID()
		{
			string sql = "";
			string wHead = "";
			if (Convert.ToString(Request.QueryString["Status"]).Equals("Null") == true)
			{
				sql = "select USER_ID,BILL_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DT from V22_BILL where (BILL_NO BETWEEN '" + wFrmBNO + "' AND '" + wToBNO + "') and REGION_CODE='" + wRegion + "' Order by USER_ID,BILL_NO";
				wHead = "All Bill No's From : " + wFrmBNO + " To " + wToBNO;
			}
			else
			{
				if (wCtype == "" || wCtype == null)
				{
					sql = "select BILL_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DT,USER_ID from V22_BILL where (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) and REGION_CODE='" + wRegion + "'";
				}
				else
				{
					sql = "select BILL_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DT,USER_ID from V22_BILL where (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') AND to_date('" + wToDt + "','dd/mm/yyyy')) AND BPO_TYPE='" + wCtype + "' AND BPO_RLY='" + wClient + "' and REGION_CODE='" + wRegion + "'";
				}

				wHead = "";
				if (wStatus == "N")
				{
					sql = sql + " and BILL_STATUS is NULL";
					wHead = "New Bill No's For The Period For : " + wFrmDt + " TO " + wToDt;
				}
				else if (wStatus == "U")
				{
					sql = sql + " and BILL_STATUS='U'";
					wHead = "Updated Bill No's For The Period For : " + wFrmDt + " TO " + wToDt;
				}
				else
				{
					wHead = "All Bill No's For The Period For : " + wFrmDt + " TO " + wToDt;
				}
				sql = sql + " Order by USER_ID,BILL_NO";
			}
			int ctr = 60;
			int wSno = 0;
			//			string first_page="Y";      

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='50%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='4'>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='4'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wHead + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill Date</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>User ID</font></b></th>");
				Response.Write("</tr></font>");
				ctr = 6;
				while (reader.Read())
				{
					//					if (ctr >59) 
					//					{

					//					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DT"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["USER_ID"]); Response.Write("</td>");
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

		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.QueryString["Status"]).Equals("Null") == true)
				{
					wStatus = Convert.ToString(Request.QueryString["Status"]);
					wFrmBNO = Convert.ToString(Request.QueryString["FRM_BNO"]);
					wToBNO = Convert.ToString(Request.QueryString["TO_BNO"]);
					wRegion = Convert.ToString(Request.QueryString["REGION"]);
					wType = Convert.ToString(Request.QueryString["Type"]);
				}
				else
				{
					wStatus = Convert.ToString(Request.QueryString["Status"]);
					wFrmDt = Convert.ToString(Request.QueryString["FRM_DT"]);
					wToDt = Convert.ToString(Request.QueryString["TO_DT"]);
					wRegion = Convert.ToString(Request.QueryString["REGION"]);
					wType = Convert.ToString(Request.QueryString["Type"]);
				}
				if (Convert.ToString(Request.QueryString["Type"]).Equals("Null") == true)
				{
					PrintBillNos();
				}
				else if (Convert.ToString(Request.QueryString["Type"]).Equals("U") == true)
				{
					PrintBillNos_UID();
				}
			}
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		protected void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
		}
	}
}