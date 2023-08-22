using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.CSharp;
using System.IO;
using RBS.Reports;
using System.Text;

namespace RBS.Reports
{
    public partial class pfrmIEWorkPlan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrintP;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RadioButton rdbAll;
		protected System.Web.UI.WebControls.DropDownList lstIE;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.Button btnGenerate;
		protected System.Web.UI.WebControls.RadioButton rdbPart;
		protected System.Web.UI.WebControls.RadioButton rdbIEWise;
		protected System.Web.UI.WebControls.RadioButton rdbCOWise;
		protected System.Web.UI.WebControls.Label lblIECO;
		protected System.Web.UI.WebControls.DropDownList lstCO;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.RadioButton rdbIESort;
		protected System.Web.UI.WebControls.RadioButton rdbVisitDTSort;
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

					DataSet dsP2 = new DataSet();
					string str2 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='" + Session["REGION"] + "' order by CO_NAME ";
					OracleDataAdapter da2 = new OracleDataAdapter(str2, conn);
					OracleCommand myOracleCommand2 = new OracleCommand(str2, conn);
					ListItem lst1;
					conn.Open();
					da2.SelectCommand = myOracleCommand2;
					da2.Fill(dsP2, "Table");
					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
					{
						lst1 = new ListItem();
						lst1.Text = dsP2.Tables[0].Rows[i]["CO_NAME"].ToString();
						lst1.Value = dsP2.Tables[0].Rows[i]["CO_CD"].ToString();
						lstCO.Items.Add(lst1);
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
				lstCO.Visible = false;
				rdbIEWise.Checked = true;
				lblIECO.Visible = false;
				lstIE.Visible = false;
				lstCO.Visible = false;
				if (Convert.ToString(Request.Params["ACTION"].Trim()) == "E")
				{
					Label1.Text = "IE DAILY WORK PLAN EXCEPTION REPORT";
				}
				else
				{
					Label1.Text = "IE DAILY WORK PLAN REPORT";
				}

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
			this.rdbIEWise.CheckedChanged += new System.EventHandler(this.rdbIEWise_CheckedChanged);
			this.rdbCOWise.CheckedChanged += new System.EventHandler(this.rdbIEWise_CheckedChanged);
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
					lstCO.Visible = false;
				}
				else if (rdbPart.Checked == true)
				{
					lstIE.Visible = true;
					lstCO.Visible = false;
				}
			}
			else if (rdbCOWise.Checked == true)
			{
				rdbAll.Text = "All CM's";
				rdbPart.Text = "For Particular CM";
				lblIECO.Text = "Controlling Manager";

				if (rdbAll.Checked == true)
				{
					lstIE.Visible = false;
					lstCO.Visible = false;
				}
				else if (rdbPart.Checked == true)
				{
					lstIE.Visible = false;
					lstCO.Visible = true;
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
			lstCO.Visible = false;
		}

		private void rdbPart_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbIEWise.Checked == true)
			{
				lstIE.Visible = true;
				lstCO.Visible = false;
				lblIECO.Text = "IE";
			}
			else if (rdbCOWise.Checked == true)
			{
				lstIE.Visible = false;
				lstCO.Visible = true;
				lblIECO.Text = "Controlling Manager";
			}
			lblIECO.Visible = true;
		}
		void repDisplay()
		{
			if (Convert.ToString(Session["Uname"])== "")
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
				sql = "SELECT a.CO_NAME, a.IE_NAME, to_char(a.VISIT_DT,'dd/mm/yyyy') VISIT_DATE, to_char(a.DATETIME,'DD/MM/YYYY-HH24:MI:SS') LOGIN_TIME, a.CASE_NO,to_char(a.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DATE,a.CALL_SNO, a.MFG_NAME, a.MFG_PLACE, a.MFG_CITY, a.CALL_STATUS,TO_CHAR(a.DT_INSP_DESIRE,'dd/mm/yyyy') DESIRE_DT, a.ITEM_DESC_PO, NVL(b.VALUE,0) VALUE,decode((select COUNT(ITEM_CD) FROM T15_PO_DETAIL T15, T18_CALL_DETAILS T18 WHERE T15.CASE_NO=T18.CASE_NO AND T15.ITEM_SRNO=T18.ITEM_SRNO_PO AND T18.CASE_NO=a.CASE_NO AND CALL_RECV_DT=a.CALL_RECV_DT AND CALL_SNO=a.CALL_SNO),0,'No','Yes') CHK_COUNT FROM (" +
					"select T08.CO_NAME,T09.IE_NAME, VISIT_DT, T47.DATETIME, T47.CASE_NO,T47.CALL_RECV_DT, T47.CALL_SNO, T05.VEND_NAME MFG_NAME, T47.MFG_PLACE, T03.CITY MFG_CITY, decode(T21.CALL_STATUS_CD,'C',T21.CALL_STATUS_DESC||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)'||'@'||T17.CALL_CANCEL_CHARGES||'+ S.T.',''),'B','Accepted',T21.CALL_STATUS_DESC)||' on '||to_char(T17.CALL_STATUS_DT ,'dd/mm/yyyy') CALL_STATUS,T17.DT_INSP_DESIRE, T18.ITEM_DESC_PO from T47_IE_WORK_PLAN T47,T08_IE_CONTROLL_OFFICER T08, T05_VENDOR T05, T09_IE T09, T03_CITY T03,T17_CALL_REGISTER T17, T21_CALL_STATUS_CODES T21, T18_CALL_DETAILS T18 where T47.CO_CD=T08.CO_CD and T47.IE_CD=T09.IE_CD and T47.MFG_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and T17.CALL_STATUS=T21.CALL_STATUS_CD and T47.CASE_NO=T17.CASE_NO and T47.CALL_RECV_DT=T17.CALL_RECV_DT and T47.CALL_SNO=T17.CALL_SNO and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO ";
				sql = sql + " and (to_char(T47.VISIT_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T47.VISIT_DT,'yyyyMMdd')<='" + wDtTo + "') and T47.REGION_CODE='" + Session["Region"] + "' and (T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO))";
				if (rdbPart.Checked == true)
				{
					sql = sql + " and T47.IE_CD=" + lstIE.SelectedValue;
				}
				sql = sql + " ) a,";
				sql = sql + "(SELECT CASE_NO,CALL_RECV_DT,CALL_SNO,round(SUM(VALUE),2) VALUE FROM ( SELECT T47.CASE_NO,T47.CALL_RECV_DT, T47.CALL_SNO,(T15.VALUE/DECODE(T15.QTY,0,1,T15.QTY))*T18.QTY_TO_INSP VALUE FROM T18_CALL_DETAILS T18, T15_PO_DETAIL T15, T47_IE_WORK_PLAN T47 WHERE T15.CASE_NO=T18.CASE_NO AND T15.ITEM_SRNO=T18.ITEM_SRNO_PO AND T18.CASE_NO=T47.CASE_NO AND T18.CALL_RECV_DT=T47.CALL_RECV_DT AND T18.CALL_SNO=T47.CALL_SNO ";
				sql = sql + " AND (to_char(T47.VISIT_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T47.VISIT_DT,'yyyyMMdd')<='" + wDtTo + "') and T47.REGION_CODE='" + Session["Region"] + "'";
				if (rdbPart.Checked == true)
				{
					sql = sql + " and T47.IE_CD=" + lstIE.SelectedValue;
				}
				sql = sql + ") GROUP BY CASE_NO,CALL_RECV_DT,CALL_SNO) b where a.CASE_NO=b.CASE_NO and a.CALL_RECV_DT=b.CALL_RECV_DT and a.CALL_SNO=b.CALL_SNO order by a.VISIT_DT,a.DATETIME,IE_NAME,MFG_CITY,MFG_NAME, a.CALL_RECV_DT, CALL_SNO";
			}
			else if (rdbCOWise.Checked == true)
			{
				//				sql="select T08.CO_NAME,T09.IE_NAME, to_char(VISIT_DT,'dd/mm/yyyy') VISIT_DATE,to_char(T47.DATETIME,'HH24:MI:SS') LOGIN_TIME, T47.CASE_NO,to_char(T47.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE, T47.CALL_SNO, T05.VEND_NAME MFG_NAME, T47.MFG_PLACE, T03.CITY MFG_CITY, decode(T21.CALL_STATUS_CD,'C',T21.CALL_STATUS_DESC||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)'||'@'||T17.CALL_CANCEL_CHARGES||'+ S.T.',''),'B','Accepted',T21.CALL_STATUS_DESC)||' on '||to_char(T17.CALL_STATUS_DT ,'dd/mm/yyyy') CALL_STATUS, T18.ITEM_DESC_PO  from T47_IE_WORK_PLAN T47, T08_IE_CONTROLL_OFFICER T08,T05_VENDOR T05, T09_IE T09, T03_CITY T03,T17_CALL_REGISTER T17, T21_CALL_STATUS_CODES T21, T18_CALL_DETAILS T18 where T47.CO_CD=T08.CO_CD and T47.IE_CD=T09.IE_CD and T47.MFG_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and T17.CALL_STATUS=T21.CALL_STATUS_CD and T47.CASE_NO=T17.CASE_NO and T47.CALL_RECV_DT=T17.CALL_RECV_DT and T47.CALL_SNO=T17.CALL_SNO and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO ";
				//				sql=sql+ " and (to_char(T47.VISIT_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T47.VISIT_DT,'yyyyMMdd')<='"+wDtTo+"') and  T47.REGION_CODE='"+Session["Region"]+"' and (T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO))";
				//				if(rdbPart.Checked==true)
				//				{
				//					sql=sql + " and T47.CO_CD="+lstCO.SelectedValue; 
				//				}
				//				sql=sql+ " order by T47.VISIT_DT,T47.DATETIME,T08.CO_NAME,T09.IE_NAME,T03.CITY,T47.MFG_CD, T47.CALL_RECV_DT, T47.CALL_SNO";

				sql = "SELECT a.CO_NAME, a.IE_NAME, to_char(a.VISIT_DT,'dd/mm/yyyy') VISIT_DATE, to_char(a.DATETIME,'DD/MM/YYYY-HH24:MI:SS') LOGIN_TIME, a.CASE_NO,to_char(a.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DATE,a.CALL_SNO, a.MFG_NAME, a.MFG_PLACE, a.MFG_CITY, a.CALL_STATUS,TO_CHAR(a.DT_INSP_DESIRE,'dd/mm/yyyy') DESIRE_DT, a.ITEM_DESC_PO, b.VALUE, decode((select COUNT(ITEM_CD) FROM T15_PO_DETAIL T15, T18_CALL_DETAILS T18 WHERE T15.CASE_NO=T18.CASE_NO AND T15.ITEM_SRNO=T18.ITEM_SRNO_PO AND T18.CASE_NO=a.CASE_NO AND CALL_RECV_DT=a.CALL_RECV_DT AND CALL_SNO=a.CALL_SNO),0,'No','Yes') CHK_COUNT FROM (" +
					"select T08.CO_NAME,T09.IE_NAME, VISIT_DT, T47.DATETIME, T47.CASE_NO,T47.CALL_RECV_DT, T47.CALL_SNO, T05.VEND_NAME MFG_NAME, T47.MFG_PLACE, T03.CITY MFG_CITY, decode(T21.CALL_STATUS_CD,'C',T21.CALL_STATUS_DESC||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)'||'@'||T17.CALL_CANCEL_CHARGES||'+ S.T.',''),'B','Accepted',T21.CALL_STATUS_DESC)||' on '||to_char(T17.CALL_STATUS_DT ,'dd/mm/yyyy') CALL_STATUS,T17.DT_INSP_DESIRE, T18.ITEM_DESC_PO from T47_IE_WORK_PLAN T47,T08_IE_CONTROLL_OFFICER T08, T05_VENDOR T05, T09_IE T09, T03_CITY T03,T17_CALL_REGISTER T17, T21_CALL_STATUS_CODES T21, T18_CALL_DETAILS T18 where T47.CO_CD=T08.CO_CD and T47.IE_CD=T09.IE_CD and T47.MFG_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and T17.CALL_STATUS=T21.CALL_STATUS_CD and T47.CASE_NO=T17.CASE_NO and T47.CALL_RECV_DT=T17.CALL_RECV_DT and T47.CALL_SNO=T17.CALL_SNO and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO ";
				sql = sql + " and (to_char(T47.VISIT_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T47.VISIT_DT,'yyyyMMdd')<='" + wDtTo + "') and T47.REGION_CODE='" + Session["Region"] + "' and (T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO))";
				if (rdbPart.Checked == true)
				{
					sql = sql + " and T47.CO_CD=" + lstCO.SelectedValue;
				}
				sql = sql + " ) a,";
				sql = sql + "(SELECT CASE_NO,CALL_RECV_DT,CALL_SNO,round(SUM(VALUE),2) VALUE FROM ( SELECT T47.CASE_NO,T47.CALL_RECV_DT, T47.CALL_SNO,(T15.VALUE/DECODE(T15.QTY,0,1,T15.QTY))*T18.QTY_TO_INSP VALUE FROM T18_CALL_DETAILS T18, T15_PO_DETAIL T15, T47_IE_WORK_PLAN T47 WHERE T15.CASE_NO=T18.CASE_NO AND T15.ITEM_SRNO=T18.ITEM_SRNO_PO AND T18.CASE_NO=T47.CASE_NO AND T18.CALL_RECV_DT=T47.CALL_RECV_DT AND T18.CALL_SNO=T47.CALL_SNO ";
				sql = sql + " AND (to_char(T47.VISIT_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T47.VISIT_DT,'yyyyMMdd')<='" + wDtTo + "') and T47.REGION_CODE='" + Session["Region"] + "'";
				if (rdbPart.Checked == true)
				{
					sql = sql + " and T47.CO_CD=" + lstCO.SelectedValue;
				}
				sql = sql + ") GROUP BY CASE_NO,CALL_RECV_DT,CALL_SNO) b where a.CASE_NO=b.CASE_NO and a.CALL_RECV_DT=b.CALL_RECV_DT and a.CALL_SNO=b.CALL_SNO order by a.VISIT_DT,a.DATETIME,CO_NAME,IE_NAME,MFG_CITY,MFG_NAME, a.CALL_RECV_DT, CALL_SNO";
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
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='16'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='right'><font face='Verdana'>Run Date: " + ss + "</font></p>");
				if (rdbIEWise.Checked == true)
				{
					Response.Write("<H6 align='center'><font face='Verdana'>IE Inspection Daily Work Plan Report " + wHdr_YrMth + " (IE Wise)</font><br></p>");
				}
				else if (rdbCOWise.Checked == true)
				{
					Response.Write("<H6 align='center'><font face='Verdana'>IE Inspection Daily Work Plan Report " + wHdr_YrMth + "(CO Wise)</font><br></p>");
				}
				Response.Write("</td></tr>");

				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>CM Name</font></b></th>");
				Response.Write("<th width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>Scheduled Visit Date</font></b></th>");
				Response.Write("<th width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>Date & Time of Entry</font></b></th>");
				Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Date</font></b></th>");
				Response.Write("<th width='6%' valign='top' align='center'><b><font size='1' face='Verdana'>Desire Date</font></b></th>");
				Response.Write("<th width='4%' valign='top' align='center'><b><font size='1' face='Verdana'>Call SNo.</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Master Checksheet Linked(Yes/No)</font></b></th>");
				Response.Write("<th width='9' valign='top' align='center'><b><font size='1' face='Verdana'>Manufacturer</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Place Of Inspection</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Manufacturer City</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Item</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Value</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Call Status</font></b></th>");

				Response.Write("</tr></font>");
				while (reader.Read())
				{

					wSno = wSno + 1;

					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='8%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VISIT_DATE"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["LOGIN_TIME"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_RECV_DATE"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DESIRE_DT"]); Response.Write("</td>");
					Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHK_COUNT"]); Response.Write("</td>");
					Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_PLACE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_CITY"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(Convert.ToDecimal(reader["VALUE"])); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_STATUS"]); Response.Write("</td>");
					Response.Write("</tr>");

				};

				Response.Write("</table>");
				conn.Close();

				string sql1 = "";
				if (rdbIEWise.Checked == true)
				{
					sql1 = "select T08.CO_NAME,T09.IE_NAME, to_char(NI_WORK_DT,'dd/mm/yyyy') WORK_DATE,to_char(T48.DATETIME,'HH24:MI:SS') LOGIN_TIME,decode(NI_WORK_CD,'T','Training','L','Leave','O','Office','J','JI','F','Firm Visit','X','Others'||'-'||NI_OTHER_DESC)NI_WORK_PLAN_CD from T48_NI_IE_WORK_PLAN T48,T08_IE_CONTROLL_OFFICER T08, T09_IE T09 where T48.CO_CD=T08.CO_CD and T48.IE_CD=T09.IE_CD ";
					sql1 = sql1 + " and (to_char(T48.NI_WORK_DT,'yyyyMMdd') between '" + wDtFr + "' And '" + wDtTo + "') and T48.REGION_CODE='" + Session["Region"] + "'";
					if (rdbPart.Checked == true)
					{
						sql1 = sql1 + " and T48.IE_CD=" + lstIE.SelectedValue;
					}
					sql1 = sql1 + " order by T48.NI_WORK_DT,T48.DATETIME,T09.IE_NAME";
				}
				else if (rdbCOWise.Checked == true)
				{
					sql1 = "select T08.CO_NAME,T09.IE_NAME, to_char(NI_WORK_DT,'dd/mm/yyyy') WORK_DATE,to_char(T48.DATETIME,'HH24:MI:SS') LOGIN_TIME,decode(NI_WORK_CD,'T','Training','L','Leave','O','Office','J','JI','F','Firm Visit','X','Others'||'-'||NI_OTHER_DESC)NI_WORK_PLAN_CD from T48_NI_IE_WORK_PLAN T48,T08_IE_CONTROLL_OFFICER T08, T09_IE T09 where T48.CO_CD=T08.CO_CD and T48.IE_CD=T09.IE_CD ";
					sql1 = sql1 + " and (to_char(T48.NI_WORK_DT,'yyyyMMdd') between '" + wDtFr + "' And '" + wDtTo + "')  and T48.REGION_CODE='" + Session["Region"] + "'";
					if (rdbPart.Checked == true)
					{
						sql1 = sql1 + " and T48.CO_CD=" + lstCO.SelectedValue;
					}
					sql1 = sql1 + " order by T48.NI_WORK_DT,T48.DATETIME,T08.CO_NAME,T09.IE_NAME";
				}
				OracleCommand cmd1 = new OracleCommand(sql1, conn);
				conn.Open();
				OracleDataReader reader1 = cmd1.ExecuteReader();
				wSno = 0;

				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");

				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='6'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='right'><font face='Verdana'>Run Date: " + ss + "</font></p>");
				if (rdbIEWise.Checked == true)
				{
					Response.Write("<H6 align='center'><font face='Verdana'>IE Non Inspection Daily Work Plan Report " + wHdr_YrMth + " (IE Wise)</font><br></p>");
				}
				else if (rdbCOWise.Checked == true)
				{
					Response.Write("<H6 align='center'><font face='Verdana'>IE Non Inspection Daily Work Plan Report " + wHdr_YrMth + "(CO Wise)</font><br></p>");
				}
				Response.Write("</td></tr>");

				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>CM Name</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Work Plan</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Work Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Time</font></b></th>");
				Response.Write("</tr></font>");
				while (reader1.Read())
				{

					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["CO_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["NI_WORK_PLAN_CD"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader1["WORK_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader1["LOGIN_TIME"]); Response.Write("</td>");
					Response.Write("</tr>");


				}
				Response.Write("</table>");
				conn.Close();


				DataSet dsP2 = new DataSet();
				string str2 = "select to_char(to_date('" + frmDt.Text + "','dd/mm/yyyy') + rownum -1,'dd/mm/yyyy') WK_DT from all_objects where rownum <=to_date('" + toDt.Text + "','dd/mm/yyyy')-to_date('" + frmDt.Text + "','dd/mm/yyyy')+1";
				OracleDataAdapter da2 = new OracleDataAdapter(str2, conn);
				OracleCommand myOracleCommand2 = new OracleCommand(str2, conn);
				conn.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				conn.Close();
				string sql2 = "";
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='5'>");
				Response.Write("<H6 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H6 align='right'><font face='Verdana'>Run Date: " + ss + "</font></p>");
				if (rdbIEWise.Checked == true)
				{
					Response.Write("<H6 align='center'><font face='Verdana'>IE Who Had Not Entered Daily Work Plan " + wHdr_YrMth + " (IE Wise)</font><br></p>");
				}
				else if (rdbCOWise.Checked == true)
				{
					Response.Write("<H6 align='center'><font face='Verdana'>IE Who Had Not Entered Daily Work Plan " + wHdr_YrMth + "(CO Wise)</font><br></p>");
				}
				Response.Write("</td></tr>");

				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>CM Name</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Date</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Reason</font></b></th>");
				Response.Write("</tr></font>");
				for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
				{


					if (rdbIEWise.Checked == true)
					{
						if (rdbAll.Checked == true)
						{
							sql2 = "select IE_CD,IE_NAME,CO_NAME from T09_IE T09,T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_REGION='" + Session["Region"] + "' and IE_STATUS is null and IE_CD NOT in (select IE_CD from T47_IE_WORK_PLAN where (VISIT_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy')) and REGION_CODE='" + Session["Region"] + "' UNION select IE_CD from T48_NI_IE_WORK_PLAN where (NI_WORK_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy')) and REGION_CODE='" + Session["Region"] + "')";
						}
						else if (rdbPart.Checked == true)
						{
							sql2 = "select IE_CD,IE_NAME,CO_NAME from T09_IE T09,T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_REGION='" + Session["Region"] + "' and IE_STATUS is null and IE_CD=" + lstIE.SelectedValue + " and IE_CD NOT in (select IE_CD from T47_IE_WORK_PLAN where (VISIT_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy')) and REGION_CODE='" + Session["Region"] + "' UNION select IE_CD from T48_NI_IE_WORK_PLAN where (NI_WORK_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy')) and REGION_CODE='" + Session["Region"] + "')";
						}
						sql2 = sql2 + " Order by IE_NAME";
					}
					else if (rdbCOWise.Checked == true)
					{
						if (rdbAll.Checked == true)
						{
							sql2 = "select IE_CD,IE_NAME,CO_NAME from T09_IE T09,T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_REGION='" + Session["Region"] + "' and IE_STATUS is null and IE_CD NOT in (select IE_CD from T47_IE_WORK_PLAN where (VISIT_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy')) and REGION_CODE='" + Session["Region"] + "' UNION select IE_CD from T48_NI_IE_WORK_PLAN where (NI_WORK_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy')) and REGION_CODE='" + Session["Region"] + "')";
						}
						else if (rdbPart.Checked == true)
						{
							sql2 = "select IE_CD,IE_NAME,CO_NAME from T09_IE T09,T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_REGION='" + Session["Region"] + "' and IE_STATUS is null and CO_CD=" + lstCO.SelectedValue + " and IE_CD NOT in (select IE_CD from T47_IE_WORK_PLAN where (VISIT_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy')) and REGION_CODE='" + Session["Region"] + "' UNION select IE_CD from T48_NI_IE_WORK_PLAN where (NI_WORK_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy')) and REGION_CODE='" + Session["Region"] + "')";
						}
						sql2 = sql2 + " Order by CO_NAME,IE_NAME";
					}
					OracleCommand cmd2 = new OracleCommand(sql2, conn);
					conn.Open();
					OracleDataReader reader2 = cmd2.ExecuteReader();
					wSno = 0;


					while (reader2.Read())
					{

						wSno = wSno + 1;

						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader2["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader2["CO_NAME"]); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP2.Tables[0].Rows[i]["WK_DT"].ToString()); Response.Write("</td>");
						OracleCommand cmd3 = new OracleCommand("Select REASON from NO_IE_WORK_PLAN where IE_CD=" + reader2["IE_CD"].ToString() + " and NWP_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy')", conn);
						string Reason = Convert.ToString(cmd3.ExecuteScalar());
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(Reason); Response.Write("</td>");
						Response.Write("</tr>");


					}

					conn.Close();
				}
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


		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible = false;
			Panel2.Visible = true;
			if (Convert.ToString(Request.Params["ACTION"].Trim()) == "E")
			{
				repExpReport();
			}
			else
			{
				repDisplay();
			}


		}



		void repExpReport()
		{
			string wHdr_YrMth = "";
			string wDtFr = "";
			string wDtTo = "";
			string wRegion = "";
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			conn.Open();
			OracleCommand cmd22 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			string ss = Convert.ToString(cmd22.ExecuteScalar());
			conn.Close();


			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			//				dt_cond=" And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' and T41.REGION_CODE='"+Session["Region"]+"'";
			string sql = "select T17.CASE_NO,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DATE,T17.CALL_SNO,T17.BK_NO,T17.SET_NO,T17.NO_OF_INSP, to_char(T17.IC_DT,'dd/mm/yyyy') IC_DATE, to_char(T17.FIRST_INSP_DT,'dd/mm/yyyy') FIRST_INSP_DATE , to_char(T17.LAST_INSP_DT,'dd/mm/yyyy') LAST_INSP_DATE,to_char(T47.VISIT_DT,'dd/mm/yyyy') VISIT_DATE ,T09.IE_NAME from T20_IC T17,T47_IE_WORK_PLAN T47, T09_IE T09 where T17.CASE_NO=T47.CASE_NO AND T17.CALL_RECV_DT=T47.CALL_RECV_DT AND T17.CALL_SNO=T47.CALL_SNO AND T17.IE_CD=T47.IE_CD AND T17.IE_CD=T09.IE_CD AND T47.IE_CD=T09.IE_CD AND (T47.VISIT_DT not between FIRST_INSP_DT AND LAST_INSP_DT) AND SUBSTR(T17.CASE_NO,1,1)='" + Session["Region"] + "' and (to_char(T47.VISIT_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(T47.VISIT_DT,'yyyyMMdd')<='" + wDtTo + "')";
			if (rdbIEWise.Checked == true)
			{
				if (rdbPart.Checked == true)
				{
					sql = sql + " and T47.IE_CD=" + lstIE.SelectedValue;
				}
			}
			else if (rdbCOWise.Checked == true)
			{
				if (rdbPart.Checked == true)
				{
					sql = sql + " and T47.CO_CD=" + lstCO.SelectedValue;
				}
			}
			sql = sql + " group by T17.CASE_NO,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy'),T17.CALL_SNO,T17.BK_NO,T17.SET_NO,T17.NO_OF_INSP, to_char(T17.IC_DT,'dd/mm/yyyy'), to_char(T17.FIRST_INSP_DT,'dd/mm/yyyy'), to_char(T17.LAST_INSP_DT,'dd/mm/yyyy'),to_char(T47.VISIT_DT,'dd/mm/yyyy') ,T09.IE_NAME ";
			if (rdbIESort.Checked == true)
			{
				sql = sql + " Order by IE_NAME";
			}
			else
			{
				sql = sql + " Order by VISIT_DATE";
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
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='12'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>Daily Work Plan Exception Report For the Period : " + wHdr_YrMth + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>CASE NO.</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>CALL RECV DT</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>CALL SNO.</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>IE</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>BK NO.</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>SET No.</font></th>");
				Response.Write("<th width='5%' valign='top'><font size='2' face='Verdana'>NO. OF INSP's</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>IC DT</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>IC FIRST INSP DT</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>IC LAST INSP DT</font></th>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>WORKPLAN VISIT DT</font></th>");
				Response.Write("</tr>");

				while (reader.Read())
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CALL_RECV_DATE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='right'> <font size='2' face='Verdana'>"); Response.Write(reader["NO_OF_INSP"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["IC_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["FIRST_INSP_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["LAST_INSP_DATE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["VISIT_DATE"]); Response.Write("</td>");
					Response.Write("</tr>");

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

		private void btnPrintP_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible = false;
			Panel2.Visible = false;
			if (Convert.ToString(Request.Params["ACTION"].Trim()) == "E")
			{
				repExpReport();
			}
			else
			{
				repDisplay();
			}
			Response.Write("<script language=JavaScript>window.print();</script>");
		}
	}
}