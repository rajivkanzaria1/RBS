using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Print_Lab_Payment_Voucher
{
	public partial class Print_Lab_Payment_Voucher : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string VNO = "";
			if (Request.Params["VOUCHER_NO"] != null || Request.Params["VOUCHER_NO"] != "")
			{
				VNO = Convert.ToString(Request.Params["VOUCHER_NO"].Trim());
				voucher(VNO);
			}
			Panel_1.Visible = true;



		}
		void voucher(string VNO)
		{
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
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				string mySql = "Select T56.PAYMENT_ID, to_char(PAYMENT_DT,'dd/mm/yyyy') PAYMENT_DATE,CHQ_NO, to_char(CHQ_DT,'dd/mm/yyyy') CHQ_DATE,T94.BANK_NAME,AMOUNT,T56.LAB_ID,LAB_NAME||','||T03.CITY LAB_NAME from T56_LAB_PAYMENTS T56, T94_BANK T94, T65_LABORATORY_MASTER T65, T03_CITY T03 where T56.BANK_CD=T94.BANK_CD AND T56.LAB_ID=T65.LAB_ID AND T65.LAB_CITY=T03.CITY_CD AND " +
					" T56.PAYMENT_ID='" + VNO + "' and substr(PAYMENT_ID,1,1)='" + Session["Region"].ToString() + "'";

				OracleCommand cmd = new OracleCommand(mySql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows == true)
				{
					while (reader.Read())
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");

						Response.Write("<tr><td width='100%' align='center'>");
						Response.Write("<font face='Verdana'><U>LAB PAYMENT VOUCHER (" + Region + ") </U></font><br>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td>");
						Response.Write("<table border='1' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td valign='top'><font size='1' face='Verdana' ><b>Voucher No. " + reader["PAYMENT_ID"].ToString() + " Dated : " + reader["PAYMENT_DATE"].ToString() + " </b> </font>");
						Response.Write("<td valign='top'><font size='1' face='Verdana' ><b>Bank:  " + reader["BANK_NAME"].ToString() + "</b></font>");
						Response.Write("</td></tr>");
						Response.Write("<tr>");
						Response.Write("<td valign='top'><font size='1' face='Verdana' ><b>CHQ No. " + reader["CHQ_NO"].ToString() + ", Dated : " + reader["CHQ_DATE"].ToString() + "</b></font>");
						Response.Write("<td valign='top'><font size='1' face='Verdana' ><b>Amount: " + reader["AMOUNT"].ToString() + "</b></font>");
						Response.Write("</td></tr>");
						Response.Write("<tr>");
						Response.Write("<td valign='top' colspan=2><font size='1' face='Verdana'><b>Laboratory: " + reader["LAB_NAME"].ToString() + " </b> </font>");

						Response.Write("</td></tr></table>");
					}

				}
				conn.Close();

				string mySql11 = "Select SAMPLE_REG_NO, NVL(TESTING_FEE,0)+NVL(SERVICE_TAX,0) AMT From T51_LAB_REGISTER_DETAIL T51 Where T51.PAYMENT_ID='" + VNO + "' and substr(T51.SAMPLE_REG_NO,1,1)='" + Session["Region"].ToString() + "' order by SAMPLE_REG_NO";
				OracleCommand cmd11 = new OracleCommand(mySql11, conn);
				conn.Open();
				OracleDataReader reader1 = cmd11.ExecuteReader();
				if (reader1.HasRows == true)
				{
					Response.Write("<table border='1' width='100%'>");
					Response.Write("<tr><td width='5%' valign='top'><font size='1' face='Verdana'>Account Code</font></td>");
					Response.Write("<td width='35%' valign='top'><font size='1' face='Verdana'>Sub Code</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>SBU Code</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Project Code</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Sample Reg No</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Amount</font></td>");
					Response.Write("</tr></font>");
				}

				while (reader1.Read())
				{
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("642"); Response.Write("</td>");
					Response.Write("<td width='35%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write("20"); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader1["SAMPLE_REG_NO"].ToString()); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader1["AMT"].ToString()); Response.Write("</td>");
					Response.Write("</tr>");
				}
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

		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = false;
			//			string VNO=Convert.ToString(Request.Params ["VOUCHER_NO"].Trim());
			//			voucher(VNO);
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Lab_Payments_Edit_Form.aspx");
		}
	}
}