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
    public partial class pfrmIEDairy : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrintP;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RadioButton rdbIEWise;
		protected System.Web.UI.WebControls.RadioButton rdbAll;
		protected System.Web.UI.WebControls.RadioButton rdbPart;
		protected System.Web.UI.WebControls.Label lblIECO;
		protected System.Web.UI.WebControls.DropDownList lstIE;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.RadioButton rdbVisitDTSort;
		protected System.Web.UI.WebControls.Button btnGenerate;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.RadioButton rdbIESort;
		OracleConnection conn = null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!(IsPostBack))
			{
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					//				string str="select to_char(sysdate,'yyyy') from dual";
					//				OracleCommand cmd = new OracleCommand(str, conn); 
					//				conn.Open();
					//				int yr=Convert.ToInt32(cmd.ExecuteScalar());
					//				conn.Close();
					//				ListItem lst2 = new ListItem(); 
					//				for(int i=yr;i>=2008;i--)
					//				{
					//					lst2 = new ListItem(); 
					//					lst2.Text = i.ToString(); 
					//					lst2.Value = i.ToString(); 
					//					Year.Items.Add(lst2);
					//				}

					DataSet dsP1 = new DataSet();
					string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
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
				lstIE.Visible = false;

				rdbIEWise.Checked = true;
				lblIECO.Visible = false;
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
			this.btnPrintP.Click += new System.EventHandler(this.btnPrintP_Click);
			this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
			this.rdbPart.CheckedChanged += new System.EventHandler(this.rdbPart_CheckedChanged);
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void rdbIEWise_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbIEWise.Checked == true)
			{
				rdbAll.Text = "All IE's";
				rdbPart.Text = "For Particular IE";
				lblIECO.Text = "IE";
				if (rdbAll.Checked == true)
				{
					lstIE.Visible = false;

				}
				else if (rdbPart.Checked == true)
				{
					lstIE.Visible = true;

				}
			}




		}
		string dateconcat(string dt)
		{
			string myYear, myMonth, myDay;
			myYear = dt.Substring(6, 4);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt_out = myYear + myMonth + myDay;
			return (dt_out);
		}
		private void rdbAll_CheckedChanged(object sender, System.EventArgs e)
		{
			lstIE.Visible = false;
			lblIECO.Visible = false;

		}

		private void rdbPart_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbIEWise.Checked == true)
			{
				lstIE.Visible = true;
				lblIECO.Text = "IE";
			}

			lblIECO.Visible = true;
		}

		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible = false;
			Panel2.Visible = true;

			repDisplay();

		}

		void repDisplay()
		{
			if (Convert.ToString(Session["Uname"]) == "")
			{
				rdbIEWise.Checked = true;
				rdbPart.Checked = true;
				lstIE.SelectedValue = Convert.ToString(Session["IE_CD"]);
			}

			string wHdr_YrMth = "";
			string wDtFr = "";
			string wDtTo = "";
			string wRegion = "";
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			conn.Open();
			OracleCommand cmd22 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			string ss = Convert.ToString(cmd22.ExecuteScalar());
			conn.Close();
			string sql = "";
			//			string dt_cond="";

			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			//				dt_cond=" And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' and T41.REGION_CODE='"+Session["Region"]+"'";


			if (rdbIEWise.Checked == true)
			{
				sql = "select T13.PO_NO||' DT. '||to_char(T13.PO_DT,'dd/mm/yyyy')||'-'||RLY_CD PO,T17.CASE_NO, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')||'-'||T17.CALL_SNO CALL,T05.VEND_NAME||','||T03.CITY VEND,T09.IE_NAME, to_char(T47.VISIT_DT,'dd/mm/yyyy') DT_OF_VISIT,T18.ITEM_DESC_PO,T18.QTY_TO_INSP, NVL2(T20.CALL_INSTALL_NO,T20.CALL_INSTALL_NO||' & '||decode(FULL_PART,'F','Final','P','Part'),'')CALL_INSTALL_NO, T20.BK_NO, T20.SET_NO,nvl2(TO_CHAR(T20.IC_DT,'DD/MM/YYYY'),decode(T17.CALL_STATUS,'M','Pending','A','Accepted','R','Rejection','C','Cancelled','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection','W','Withheld','B', 'Accepted & Billed','T','Stage Rejection')||' DT. '||TO_CHAR(T20.IC_DT,'DD/MM/YYYY'),decode(T17.CALL_STATUS,'M','Pending','A','Accepted','R','Rejection','C','Cancelled','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection','W','Withheld','B', 'Accepted & Billed','T','Stage Rejection')||' DT. '||TO_CHAR(T17.CALL_STATUS_DT,'DD/MM/YYYY')) IC_ISSUE_DT, TO_CHAR(T20.IC_SUBMIT_DT,'DD/MM/YYYY') SUBMIT_DT ,V06.CONSIGNEE,T22.MATERIAL_VALUE, T22.INSP_FEE " +
					"from T17_CALL_REGISTER T17,T18_CALL_DETAILS T18, T20_IC T20, T22_BILL T22, T13_PO_MASTER T13, T05_VENDOR T05, T03_CITY T03,T47_IE_WORK_PLAN T47,T21_CALL_STATUS_CODES T21, V06_CONSIGNEE V06, T09_IE T09 " +
					"where T17.CASE_NO=T13.CASE_NO and T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO and T18.CONSIGNEE_CD=V06.CONSIGNEE_CD AND T17.IE_CD=T09.IE_CD and T17.CASE_NO=T47.CASE_NO(+) and T17.CALL_RECV_DT=T47.CALL_RECV_DT(+) and T17.CALL_SNO=T47.CALL_SNO(+) and T17.CALL_STATUS=T21.CALL_STATUS_CD and T18.CASE_NO=T20.CASE_NO(+) and T18.CALL_RECV_DT=T20.CALL_RECV_DT(+) and T18.CALL_SNO=T20.CALL_SNO(+) and T18.CONSIGNEE_CD=T20.CONSIGNEE_CD(+) and T20.BILL_NO=T22.BILL_NO(+)  and SUBSTR(T13.CASE_NO,1,1)='" + Session["Region"] + "' and (to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='" + wDtTo + "') ";


				if (rdbPart.Checked == true)
				{
					sql = sql + " and T17.IE_CD=" + lstIE.SelectedValue;
				}

				if (rdbVisitDTSort.Checked == true)
				{
					sql = sql + " order by T09.IE_NAME, T47.VISIT_DT,T17.CALL_RECV_DT,T17.CASE_NO,T18.ITEM_DESC_PO ";
				}
				else
				{
					sql = sql + " order by T09.IE_NAME, T17.CALL_RECV_DT,T47.VISIT_DT,T17.CASE_NO,T18.ITEM_DESC_PO ";

				}

			}


			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region, RITES Ltd."; }


			int wSno = 0;


			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader1 = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='16'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='right'><font face='Verdana'>Run Date: " + ss + "</font></p>");
				if (rdbIEWise.Checked == true)
				{
					Response.Write("<H6 align='center'><font face='Verdana'>IE Dairy Report " + wHdr_YrMth + " (IE Wise)</font><br></p>");
				}

				Response.Write("</td></tr>");

				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>PO No. & Date Rly/Non Rly</font></b></th>");
				Response.Write("<th width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>RITES Case No.</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Call No. & Date</font></b></th>");
				Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>Name of the Vendor/Mfgr</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Date of Visit</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Brief Disc of Stores</font></b></th>");
				Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>Qty. Insp</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Installment No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Book No./Set No.</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>A. IC Issued, B. Rejection C.Cancellation issue Date</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Consignee and Rly/Non Rly</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Value of Stores</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Date of submission of papers for Billing</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Inspection Fee</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Remarks, Date of Test Report recd.</font></b></th>");
				Response.Write("</tr></font>");
				while (reader1.Read())
				{

					wSno = wSno + 1;

					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='CENTER'><font size='1' face='Verdana'>" + reader1["IE_NAME"].ToString() + "</font></td>");
					Response.Write("<td width='15%' valign='top' align='Left'><font size='1' face='Verdana'>" + reader1["PO"].ToString() + "</font></td>");
					Response.Write("<td width='7%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["CASE_NO"].ToString() + "</font></td>");
					Response.Write("<td width='8%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["CALL"].ToString() + "</font></td>");
					Response.Write("<td width='6%' valign='top' align='Left'><font size='1' face='Verdana'>" + reader1["VEND"].ToString() + "</font></td>");
					Response.Write("<td width='8%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["DT_OF_VISIT"].ToString() + "</font></td>");
					Response.Write("<td width='8%' valign='top' align='left'><font size='1' face='Verdana'>" + reader1["ITEM_DESC_PO"].ToString() + "</font></td>");
					Response.Write("<td width='6%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["QTY_TO_INSP"].ToString() + "</font></td>");
					Response.Write("<td width='8%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["CALL_INSTALL_NO"].ToString() + "</font></td>");
					Response.Write("<td width='10%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["BK_NO"].ToString() + "/" + reader1["SET_NO"].ToString() + "</font></td>");
					Response.Write("<td width='8%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["IC_ISSUE_DT"].ToString() + "</font></td>");
					Response.Write("<td width='8%' valign='top' align='left'><font size='1' face='Verdana'>" + reader1["CONSIGNEE"].ToString() + "</font></td>");
					Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["MATERIAL_VALUE"].ToString() + "</font></td>");
					Response.Write("<td width='8%' valign='top' align='center'><font size='1' face='Verdana'>" + reader1["SUBMIT_DT"].ToString() + "</font></td>");
					Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'>" + reader1["INSP_FEE"].ToString() + "</font></td>");
					Response.Write("<td width='8%' valign='top' align='right'><font size='1' face='Verdana'></font></td>");
					Response.Write("</tr>");

				};

				Response.Write("</table>");
				conn.Close();



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

		private void btnPrintP_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible = false;
			Panel2.Visible = true;

			repDisplay();
			Response.Write("<script language=JavaScript>window.print();</script>");
		}
	}
}