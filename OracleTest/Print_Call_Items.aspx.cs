using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Print_Call_Items
{
	public partial class Print_Call_Items : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string CNO, CDT;
		int CSNO;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Request.Params["CASE_NO"] != null || Request.Params["CASE_NO"] != "")
			{
				CNO = Convert.ToString(Request.Params["CASE_NO"].Trim());
				CDT = Convert.ToString(Request.Params["CALL_DT"].Trim());
				CSNO = Convert.ToInt16(Request.Params["CALL_SNO"].Trim());
			}


			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				string str3 = "select (T18.CONSIGNEE_CD||'-'||V06.CONSIGNEE)CONSIGNEE,T17.CASE_NO, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE, T17.CALL_SNO, T18.ITEM_DESC_PO,T18.QTY_ORDERED,T18.QTY_TO_INSP,NVL(T18.CUM_QTY_PREV_OFFERED,'0')CUM_QTY_PREV_OFFERED,NVL(T18.CUM_QTY_PREV_PASSED,'0')CUM_QTY_PREV_PASSED,V12.BPO,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') DELV_DT from T13_PO_MASTER T13,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18, V06_CONSIGNEE V06, V12_BILL_PAYING_OFFICER V12, T14_PO_BPO T14, T15_PO_DETAIL T15,T09_IE T09  where T13.CASE_NO=T17.CASE_NO and T18.CONSIGNEE_CD=V06.CONSIGNEE_CD and T13.CASE_NO=T14.CASE_NO and T14.BPO_CD=V12.BPO_CD and T14.CONSIGNEE_CD=T18.CONSIGNEE_CD and T13.CASE_NO=T15.CASE_NO and T15.CASE_NO=T18.CASE_NO and T15.ITEM_SRNO=T18.ITEM_SRNO_PO and T15.CONSIGNEE_CD=T18.CONSIGNEE_CD and T14.CONSIGNEE_CD=T15.CONSIGNEE_CD and T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.IE_CD=T09.IE_CD and T17.CASE_NO= '" + CNO + "' and T17.CALL_RECV_DT=to_date('" + CDT + "','dd/mm/yyyy') and T17.CALL_SNO=" + CSNO;
				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader = myOracleCommand3.ExecuteReader();
				int wsno = 0;
				Response.Write("<HTML>");
				Response.Write("<body>");
				Response.Write("<Table width='100%' align='center' style='Z-INDEX: 101; LEFT: 8px; WIDTH: 100%; POSITION: absolute; TOP: 8px;' height='100' style='border-collapse: collapse;' border='1' bordercolor='#111111'>");
				Response.Write("<tr>");
				Response.Write("<td colspan=8 align='center'><Font Face='Verdana' size='2'><span style='font-size: 14'><B>INSPECTION CALL ITEM DETAILS</B></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td colspan=8 align='center'><Font Face='Verdana' size='1'><span style='font-size: 14'><B>Case No. " + CNO + " Call Dated. " + CDT + " Sno. " + CSNO + "</B></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Sno.</Font></th>");
				Response.Write("<th width='20%' valign='top' align='center'><font size='1' face='Verdana'>Consignee</Font></th>");
				Response.Write("<th width='15%' valign='top' align='center'><font size='1' face='Verdana'>BPO</Font></th>");
				Response.Write("<th width='25%' valign='top' align='center'><font size='1' face='Verdana'>Item</Font></th>");
				Response.Write("<th width='5%' valign='top' align='center'><font size='1' face='Verdana'>Qty Ordered</Font></th>");
				Response.Write("<th width='5%' valign='top' align='center'><font size='1' face='Verdana'>Qty Offered</Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Quantity already inspected and passed</Font></th>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Delivery Date</Font></th>");
				Response.Write("</tr>");
				while (reader.Read())
				{
					wsno = wsno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='Center'><b><font size='1' face='Verdana'>" + wsno + "</font></b></td>");
					Response.Write("<td width='20%' valign='top' align='Left'><b><font size='1' face='Verdana'>" + reader["CONSIGNEE"].ToString() + "</font></b></td>");
					Response.Write("<td width='15%' valign='top' align='Left'><b><font size='1' face='Verdana'>" + reader["BPO"].ToString() + "</font></b></td>");
					Response.Write("<td width='25%' valign='top' align='Left'><b><font size='1' face='Verdana'>" + reader["ITEM_DESC_PO"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='Left'><b><font size='1' face='Verdana'>" + reader["QTY_ORDERED"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["QTY_TO_INSP"].ToString() + "</font></b></td>");
					Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["CUM_QTY_PREV_OFFERED"].ToString() + " & " + reader["CUM_QTY_PREV_PASSED"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["DELV_DT"].ToString() + "</font></b></td>");
					Response.Write("</tr>");



				}
				Response.Write("</Table>");
				Response.Write("</body>");
				Response.Write("</HTML>");
				reader.Close();
				conn1.Close();
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

		}
		#endregion

		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			btnPrint.Visible = false;

			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}
	}
}