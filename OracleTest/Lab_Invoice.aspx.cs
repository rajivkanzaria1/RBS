using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Lab_Invoice
{
	public partial class Lab_Invoice : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string SNO = "";
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Request.Params["SAMPLE_REG_NO"] != null || Request.Params["SAMPLE_REG_NO"] != "")
			{
				SNO = Convert.ToString(Request.Params["SAMPLE_REG_NO"].Trim());

			}


			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select V05.VENDOR, T50.SAMPLE_REG_NO, to_char(SAMPLE_REG_DT,'dd/mm/yyyy') SAMPLE_REG_DATE,T51.ITEM_DESC, sum(TESTING_FEE) TESTING_FEE, sum(SERVICE_TAX) SERVICE_TAX,SUM(HANDLING_CHARGES) HANDLING_CHARGES from T50_LAB_REGISTER T50, T51_LAB_REGISTER_DETAIL T51, V05_VENDOR V05 where T50.VEND_CD=V05.VEND_CD and T50.SAMPLE_REG_NO=T51.SAMPLE_REG_NO and T50.SAMPLE_REG_NO='" + SNO + "' group by V05.VENDOR, T50.SAMPLE_REG_NO, to_char(SAMPLE_REG_DT,'dd/mm/yyyy'), T51.ITEM_DESC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);

				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand1;
				da.Fill(dsP, "Table");
				Response.Write("<HTML>");
				Response.Write("<body>");
				Response.Write("<Table width='100%' align='center' style='Z-INDEX: 101; LEFT: 8px; WIDTH: 90%; POSITION: absolute; TOP: 8px;' height='100' border='0'>");
				Response.Write("<tr>");
				Response.Write("<td align='center'><Font Face='Verdana' size='2'><span style='font-size: 16'><B>RITES LTD</B></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align='center'><Font Face='Verdana' size='2'><span style='font-size: 14'><B>PERFORMA INVOICE FOR TESTING CHARGES</B></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align='left'><font size='1' face='Verdana'><B>Issued TO: " + dsP.Tables[0].Rows[0]["VENDOR"].ToString() + "</B></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align='left'><font size='1' face='Verdana'><B>Registration No. " + dsP.Tables[0].Rows[0]["SAMPLE_REG_NO"].ToString() + "</B></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr><td valign='top' align='center'>");
				Response.Write("<Table width='100%' align='center' height='100%' border='1' bordercolor='black'>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top' align='center'><font size='1' face='Verdana'>Sno.</Font></th>");
				Response.Write("<th width='40%' valign='top' align='center'><font size='1' face='Verdana'>Description of Material</Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Testing Fee</Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Service Tax</Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Handling Charges</Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Total</Font></th>");
				//				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Payment Details</Font></th>");
				Response.Write("</tr>");

				string str2 = "select T51.ITEM_DESC,T51.TESTING_FEE, T51.SERVICE_TAX, T51.HANDLING_CHARGES from T51_LAB_REGISTER_DETAIL T51 where T51.SAMPLE_REG_NO='" + SNO + "'";
				OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
				OracleDataReader reader = myOracleCommand2.ExecuteReader();
				int wsno = 0;
				int total_fee = 0;
				while (reader.Read())
				{

					wsno = wsno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='Center'><font size='1' face='Verdana'>" + wsno + "</font></b></td>");
					Response.Write("<td width='20%' valign='top' align='Left'><font size='1' face='Verdana'>" + reader["ITEM_DESC"] + "</font></td>");
					Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader["TESTING_FEE"] + "</font></td>");
					int w_total = 0;
					w_total = w_total + Convert.ToInt32(reader["TESTING_FEE"]);
					Response.Write("<td  width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader["SERVICE_TAX"] + "</font></td>");
					w_total = w_total + Convert.ToInt32(reader["SERVICE_TAX"]);
					Response.Write("<td  width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader["HANDLING_CHARGES"] + "</font></td>");
					w_total = w_total + Convert.ToInt32(reader["HANDLING_CHARGES"]);
					Response.Write("<td  width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + w_total + "</font></td>");
					//					Response.Write("<td  width='20%' valign='top' align='right'><font size='1' face='Verdana'></font></td>");
					Response.Write("</tr>");
					total_fee = total_fee + w_total;
				}
				conn1.Close();
				Response.Write("</table>");
				Response.Write("</td>");
				Response.Write("</tr>");

				Response.Write("<tr>");
				Response.Write("<td align='right'><font size='1' face='Verdana'><B>Total Amount " + total_fee + "</B></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<tr><td align='center'><Font Face='Verdana' size='2'><span style='font-size: 14'><B>PAYMENT DETAILS</B></Font></td></tr>");
				Response.Write("<tr><td valign='top' align='center'>");
				string str3 = "select T52.CHQ_NO, to_char(T52.CHQ_DT,'dd/mm/yyyy') CHQ_DT, T94.BANK_NAME, T25.AMOUNT, T25.SUSPENSE_AMT,T52.AMT_CLEARED from T52_LAB_POSTING T52, T25_RV_DETAILS T25, T94_BANK T94 where T52.CHQ_NO=T25.CHQ_NO and T52.CHQ_DT=T25.CHQ_DT and T52.BANK_CD=T25.BANK_CD and T52.BANK_CD=T94.BANK_CD and T52.SAMPLE_REG_NO='" + SNO + "'";
				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader1 = myOracleCommand3.ExecuteReader();

				Response.Write("<Table width='100%' align='center' height='100%' border='1' bordercolor='black'>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top' align='center'><font size='1' face='Verdana'>Sno.</Font></th>");
				Response.Write("<th width='40%' valign='top' align='center'><font size='1' face='Verdana'>Instrument No.</Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Instrument Dt</Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Bank</Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Instrument Amt</Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Amount Cleared against given Sample Reg No. </Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Suspense Amt</Font></th>");
				Response.Write("</tr>");
				int wsno1 = 0;

				while (reader1.Read())
				{

					wsno1 = wsno1 + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='Center'><font size='1' face='Verdana'>" + wsno + "</font></b></td>");
					Response.Write("<td width='20%' valign='top' align='Left'><font size='1' face='Verdana'>" + reader1["CHQ_NO"] + "</font></td>");
					Response.Write("<td width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["CHQ_DT"] + "</font></td>");
					Response.Write("<td  width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["BANK_NAME"] + "</font></td>");
					Response.Write("<td  width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["AMOUNT"] + "</font></td>");
					Response.Write("<td  width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["AMT_CLEARED"] + "</font></td>");
					Response.Write("<td  width='20%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["SUSPENSE_AMT"] + "</font></td>");

					Response.Write("</tr>");

				}
				Response.Write("</table>");
				Response.Write("</td>");
				Response.Write("</tr>");

				Response.Write("<td align='left'><font size='1' face='Verdana'><B><u>NOTE:</u></B> Testing charges are payble in advance by Demand Draft in favour of RITES LTD, Payble at New Delhi.</Font></td>");
				Response.Write("</tr></table>");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//string str1=str.Replace("\n","");
				Response.Write("Error!!" + str);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			btnPrint.Visible = false;

			Response.Write("<script language=JavaScript>window.print();</script>");
		}
	}
}