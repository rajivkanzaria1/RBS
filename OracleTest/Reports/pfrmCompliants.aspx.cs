using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Reports
{
    public partial class pfrmCompliants : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Panel Panel_1;
		OracleConnection conn = null;
		string wFrmDt, wToDt, wRegion;
		protected System.Web.UI.WebControls.Panel Panel_2;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.RadioButton rdbAll3;
		protected System.Web.UI.WebControls.RadioButton rdbYes;
		protected System.Web.UI.WebControls.RadioButton rdbNo;
		protected System.Web.UI.WebControls.RadioButton rdbCancelled;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.RadioButton rdbAll;
		protected System.Web.UI.WebControls.RadioButton rdbNR;
		protected System.Web.UI.WebControls.RadioButton rdbSR;
		protected System.Web.UI.WebControls.RadioButton rdbER;
		protected System.Web.UI.WebControls.RadioButton rdbWR;
		protected System.Web.UI.WebControls.RadioButton rdbAll1;
		protected System.Web.UI.WebControls.RadioButton rdbNR1;
		protected System.Web.UI.WebControls.RadioButton rdbSR1;
		protected System.Web.UI.WebControls.RadioButton rdbER1;
		protected System.Web.UI.WebControls.RadioButton rdbAllDefectCD;
		protected System.Web.UI.WebControls.RadioButton rdbAllJIStatus;
		protected System.Web.UI.WebControls.RadioButton rdbPDefectCD;
		protected System.Web.UI.WebControls.RadioButton rdbPJIStatus;
		protected System.Web.UI.WebControls.DropDownList lstDefectCd;
		protected System.Web.UI.WebControls.DropDownList lstClassification;
		protected System.Web.UI.WebControls.RadioButton rdbAllAction;
		protected System.Web.UI.WebControls.RadioButton rdbPAction;
		protected System.Web.UI.WebControls.DropDownList lstAction;
		protected System.Web.UI.WebControls.RadioButton rdbUndConsideration;
		protected System.Web.UI.WebControls.RadioButton rdbWR1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
			// Put user code to initialize the page here
			if (!(IsPostBack))
			{
				fill_lstDefectCd();
				fill_lstClassification();
				lstClassification.Visible = false;
				lstDefectCd.Visible = false;
				lstAction.Visible = false;
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
			this.rdbAllDefectCD.CheckedChanged += new System.EventHandler(this.rdbAllDefectCD_CheckedChanged);
			this.rdbPDefectCD.CheckedChanged += new System.EventHandler(this.rdbAllDefectCD_CheckedChanged);
			this.rdbAllJIStatus.CheckedChanged += new System.EventHandler(this.rdbAllJIStatus_CheckedChanged);
			this.rdbPJIStatus.CheckedChanged += new System.EventHandler(this.rdbAllJIStatus_CheckedChanged);
			this.rdbAllAction.CheckedChanged += new System.EventHandler(this.rdbPAction_CheckedChanged);
			this.rdbPAction.CheckedChanged += new System.EventHandler(this.rdbPAction_CheckedChanged);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void fill_lstDefectCd()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstDefectCd.Items.Clear();
			DataSet ds = new DataSet();
			OracleCommand cmd = new OracleCommand("Select DEFECT_CD,DEFECT_DESC From T38_DEFECT_CODES", conn);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			ListItem lst;
			//
			lst = new ListItem();
			lst.Value = null;
			lst.Text = null;
			lstDefectCd.Items.Add(lst);
			//
			da.SelectCommand = cmd;
			da.Fill(ds, "Table");
			for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Value = ds.Tables[0].Rows[i]["DEFECT_CD"].ToString();
				lst.Text = ds.Tables[0].Rows[i]["DEFECT_DESC"].ToString();
				lstDefectCd.Items.Add(lst);
			}
			conn.Close();
			conn.Dispose();

		}

		private void fill_lstClassification()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstClassification.Items.Clear();
			DataSet ds = new DataSet();
			OracleCommand cmd = new OracleCommand("Select JI_STATUS_CD,JI_STATUS_DESC From T39_JI_STATUS_CODES", conn);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			ListItem lst;
			//
			lst = new ListItem();
			lst.Value = null;
			lst.Text = null;
			lstClassification.Items.Add(lst);
			//
			da.SelectCommand = cmd;
			da.Fill(ds, "Table");
			for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Value = ds.Tables[0].Rows[i]["JI_STATUS_CD"].ToString();
				lst.Text = ds.Tables[0].Rows[i]["JI_STATUS_DESC"].ToString();
				lstClassification.Items.Add(lst);
			}
			conn.Close();
			conn.Dispose();

		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Panel_2.Visible = false;
			Panel_1.Visible = true;
			wToDt = toDt.Text.Trim();
			wFrmDt = frmDt.Text.Trim();
			wRegion = "";

			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }
			compliants_statement();
		}

		void compliants_statement()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string sql = "select DECODE(INSP_REGION,'N','NORTHERN','S','SOUTHERN','E','EASTERN','W','WESTERN','CENTRAL') IN_REGION,COMPLAINT_ID,to_char(COMPLAINT_DT,'dd/mm/yyyy')COMPLAINT_DATE,REJ_MEMO_NO||' Dt. '||to_char(REJ_MEMO_DT,'dd/mm/yyyy') REJ_MEMO, CASE_NO,BK_NO||' & '||SET_NO BK_SET,T40.IE_NAME, IE_CO_NAME,decode(COMP_RECV_REGION,'N','Northern','S','Southern','W','Western','E','Eastern','C','Central') COMP_RECV_REGION, CONSIGNEE_NAME||', '||CONSIGNEE_CITY CONSIGNEE, VENDOR, ITEM_DESC, QTY_OFFERED||' '||UOM_S_DESC QTY_OFF,QTY_REJECTED||' '||UOM_S_DESC QTY_REJECTED,REJECTION_VALUE, REJECTION_REASON, STATUS, DECODE(JI_REQUIRED,'Y','Yes','N','NO','Cancelled')JI_REQUIRED, JI_SNO, to_char(JI_FIX_DT,'dd/mm/yyyy')JI_DATE, T38.DEFECT_DESC, T39.JI_STATUS_DESC, ACTION, L5NO_PO PO_NO, to_char(PO_DT,'dd/mm/yyyy')PO_DATE, to_char(IC_DT,'dd/mm/yyyy')IC_DATE,T09.IE_NAME JI_IE_NAME,Decode(ACTION_PROPOSED,'W','Warning Letter','I','Minor Penalty','J','Major Penalty','O','Others') ACTION_PROPOSED, to_char(ACTION_PROPOSED_DT,'dd/mm/yyyy') ACTION_PROPOSED_DATE, CO_NAME, T40.CASE_NO, T40.BK_NO, T40.SET_NO, REMARKS, TO_CHAR(T40.CONCLUSION_DT,'DD/MM/YYYY')CONCLUSION_DATE, DECODE(NO_JI_REASON,'A','DP Expired','B','Validity of IC Expired','C','Received in Damaged/Broken Condition','D','Rejection <5%','E','Rejection issued after 90 Days of reciept of material','F','Guarantee Claim','G','Wrong Dispatch','H','Material not stamped (partial/full)','I','Material received in excess of ordered quantity','J','Material lifted/rectified/replaced (Partially/Fully) before issue of Rejection Advice','K','Reason(s) of rejection, beyond scope of inspection'||'-'||T40.ANY_OTHER) NO_JI_RES,decode(T09.IE_DEPARTMENT,'C','Civil','E','Electrical','M','Mechanical','L','Metallergy','Others') DEPT,ROOT_CAUSE_ANALYSIS,TECH_REF,DECODE(CHKSHEET_STATUS,'A','APPROVED','R','REVISION','P','PREPRATION')CHK_STATUS,ANY_OTHER,CAPA_STATUS,DANDAR_STATUS " +
						" from V40_CONSIGNEE_COMPLAINTS T40,T38_DEFECT_CODES T38,T39_JI_STATUS_CODES T39,T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T40.DEFECT_CD=T38.DEFECT_CD(+) and T40.JI_STATUS_CD =T39.JI_STATUS_CD(+) and T40.JI_IE_CD=T09.IE_CD(+) and T40.IE_CO_CD=T08.CO_CD(+) and (COMPLAINT_DT between to_date('" + frmDt.Text.Trim() + "','dd/mm/yyyy') and to_date('" + toDt.Text.Trim() + "','dd/mm/yyyy')) ";
			int ctr = 60;
			int wSno = 0;
			//			string first_page="Y";    
			string comp_recv_region = "";
			string insp_region = "";
			string JI_REQ = "";



            if (rdbNR.Checked == true)
            {
                sql = sql + " and INSP_REGION='N' ";
                comp_recv_region = "Northern Region";
            }
            else if (rdbSR.Checked == true)
            {
                sql = sql + " and INSP_REGION='S' ";
                comp_recv_region = "Southern Region";
            }
            else if (rdbER.Checked == true)
            {
                sql = sql + " and INSP_REGION='E' ";
                comp_recv_region = "Eastern Region";
            }
            else if (rdbWR.Checked == true)
            {
                sql = sql + " and INSP_REGION='W' ";
                comp_recv_region = "Western Region";
            }
            else
            {
                comp_recv_region = "All Regions";
            }




            if (rdbNR1.Checked == true)
			{
				sql = sql + " and JI_REGION='N' ";
				insp_region = "Northern Region";
			}
			else if (rdbSR1.Checked == true)
			{
				sql = sql + " and JI_REGION='S' ";
				insp_region = "Southern Region";
			}
			else if (rdbER1.Checked == true)
			{
				sql = sql + " and JI_REGION='E' ";
				insp_region = "Eastern Region";
			}
			else if (rdbWR1.Checked == true)
			{
				sql = sql + " and JI_REGION='W' ";
				insp_region = "Western Region";
			}
			else
			{
				insp_region = "All Regions";
			}

			if (rdbYes.Checked == true)
			{
				sql = sql + " and JI_REQUIRED='Y' ";
				JI_REQ = "JI Required";

			}
			else if (rdbNo.Checked == true)
			{
				sql = sql + " and JI_REQUIRED='N' ";
				JI_REQ = "JI Not Required";
			}
			else if (rdbCancelled.Checked == true)
			{
				sql = sql + " and JI_REQUIRED='C' ";
				JI_REQ = "JI Cancelled";
			}
			else if (rdbUndConsideration.Checked == true)
			{
				sql = sql + " and JI_REQUIRED IS NULL ";
				JI_REQ = "JI Under Consideration";
			}

			if (rdbPDefectCD.Checked == true)
			{
				sql = sql + " and T40.DEFECT_CD='" + lstDefectCd.SelectedValue + "'";
			}
			if (rdbPJIStatus.Checked == true)
			{
				sql = sql + " and T40.JI_STATUS_CD=" + lstClassification.SelectedValue;
			}

			if (rdbPAction.Checked == true)
			{
				sql = sql + " and T40.ACTION_PROPOSED='" + lstAction.SelectedValue + "'";
			}

			if (Convert.ToString(Session["Uname"]) != "")
			{
				sql = sql + " order by T40.JI_SNO,T40.COMP_RECV_REGION,T40.COMPLAINT_DT";
			}
			else if (Convert.ToString(Session["IE_CD"]) != "")
			{
				sql = sql + " and T40.IE_CD='" + Convert.ToString (Session["IE_CD"]) + "'";
				sql = sql + " order by T40.JI_SNO,T40.COMP_RECV_REGION,T40.COMPLAINT_DT";
			}





			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='29'>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='29'>");
				//Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
				if (Convert.ToString(Session["Uname"]) != "")
				{
					if (rdbAll3.Checked == true)
					{
						Response.Write("<H5 align='center'><font face='Verdana'>Compliant Recieved  During the Period: " + wFrmDt + " to " + wToDt + " (" + comp_recv_region + ") </font><br></p>");
					}
					else
					{
						Response.Write("<H5 align='center'><font face='Verdana'>Compliant Recieved  During the Period: " + wFrmDt + " to " + wToDt + " (" + comp_recv_region + ") & " + JI_REQ + "</font><br></p>");
					}
				}
				else if (Convert.ToString(Session["IE_CD"]) != "")
				{

					Response.Write("<H5 align='center'><font face='Verdana'>Compliant Recieved  During the Period: " + wFrmDt + " to " + wToDt + " </font><br></p>");

				}

				Response.Write("</td>");
				Response.Write("<td width='100%' colspan='7'>");

				Response.Write("<H5 align='center'><font face='Verdana'>Corrective & Preventive Action Identified</font><br></p>");

				Response.Write("</td>");

				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='3%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Region</font></b></th>");
				if (Convert.ToString(Request.Params["ACTION"].Trim()) != "CORP")
				{
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Complaint ID</font></b></th>");
				}
				if (rdbNo.Checked == false)
				{
					Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Unique SNO.</font></b></th>");
				}
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Firm</font></b></th>");
				Response.Write("<th width='3%' valign='top'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Date</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>BK NO & Set NO</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Date of IC</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Item</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Consignee</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='3%' valign='top'><b><font size='1' face='Verdana'>Qty Offered</font></b></th>");
				Response.Write("<th width='3%' valign='top'><b><font size='1' face='Verdana'>Qty Rejected</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Value of Rejected Stores</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Discipline</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Date of 1st Reference</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>REJ MEMO</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Reason of Rejection</font></b></th>");
				//				if(rdbNo.Checked==true)
				//				{
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Reason of No JI</font></b></th>");
				//				}
				//				if(rdbNo.Checked==false)
				//				{
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Date of JI</font></b></th>");
				//				}

				//Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Remarks</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Inspection Document</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Status (Decision taken by JI Committe)</font></b></th>");
				Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>JI REPORT</font></b></th>");
				//				if(rdbNo.Checked==false)
				//				{
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Defect Code</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Classfication</font></b></th>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Conclusion Dt</font></b></th>");
				//				}
				//				if(Convert.ToString(Request.Params ["ACTION"].Trim())!="CORP")
				//				{
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>CM</font></b></th>");
				//				}
				//				if(rdbNo.Checked==false)
				//				{
				//					if(Convert.ToString(Request.Params ["ACTION"].Trim())!="CORP")
				//					{
				//						Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>JI Engineer</font></b></th>");
				//						Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>D&AR Proposed</font></b></th>");
				//						Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>D&AR Proposed DT</font></b></th>");
				//					}
				//					Response.Write("<th width='9%' valign='top'><b><font size='1' face='Verdana'>Final Remarks/Action</font></b></th>");
				//				}
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>JI Engineer</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Root Cause Analysis</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Checksheet Status</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Tech Ref</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>D&AR Proposed</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Any Other</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Status of CAPA</font></b></th>");
				Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>D&AR Status (if Any)</font></b></th>");
				Response.Write("</tr></font>");
				string wC_Region = "";
				while (reader.Read())
				{
					wSno = wSno + 1;
					if (wC_Region == reader["COMP_RECV_REGION"].ToString())
					{
						Response.Write("<tr>");

						Response.Write("<td width='3%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IN_REGION"]); Response.Write("</td>");
						if (Convert.ToString(Request.Params["ACTION"].Trim()) != "CORP")
						{
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["COMPLAINT_ID"]); Response.Write("</td>");
						}
						if (rdbNo.Checked == false)
						{
							Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["JI_SNO"]); Response.Write("</td>");
						}
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
						Response.Write("<td width='3%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_SET"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IC_DATE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='3%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
						Response.Write("<td width='3%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["REJECTION_VALUE"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["DEPT"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["COMPLAINT_DATE"]); Response.Write("</td>");
						string fpath3 = Server.MapPath("/RBS/REJECTION_MEMO/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF");
						string fpath33 = Server.MapPath("/RBS/REJECTION_MEMO/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF");
						if (File.Exists(fpath3) == false && File.Exists(fpath33) == false)
						{
							Response.Write("<td width='100%' align='center' valign='center'></td>");
						}
						else if (File.Exists(fpath3) == false && File.Exists(fpath33) == true)
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/REJECTION_MEMO/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW REJ MEMO</font></a></td>");
						}
						else
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/REJECTION_MEMO/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW REJ MEMO</font></a></td>");


						}
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["REJECTION_REASON"]); Response.Write("</td>");
						//						if(rdbNo.Checked==true)
						//						{
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["NO_JI_RES"]); Response.Write("</td>");
						//						}
						//						if(rdbNo.Checked==false)
						//						{
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["JI_DATE"]); Response.Write("</td>");
						//						}
						//Response.Write("<td width='4%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["REMARKS"]);Response.Write("</td>");
						string fpath1 = Server.MapPath("/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF");
						string fpath11 = Server.MapPath("/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF");
						if (File.Exists(fpath1) == false && File.Exists(fpath11) == false)
						{
							Response.Write("<td width='100%' align='center' valign='center'></td>");
						}
						else if (File.Exists(fpath1) == false && File.Exists(fpath11) == true)
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI CASE</font></a></td>");
						}
						else
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI CASE</font></a></td>");


						}
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["STATUS"]); Response.Write("</td>");
						string fpath2 = Server.MapPath("/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF");
						string fpath22 = Server.MapPath("/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF");
						if (File.Exists(fpath2) == false && File.Exists(fpath22) == false)
						{
							Response.Write("<td width='100%' align='center' valign='center'> </td>");
						}
						else if (File.Exists(fpath2) == false && File.Exists(fpath22) == true)
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI REPORT</font></a></td>");
						}
						else
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI REPORT</font></a></td>");

						}


						//						if(rdbNo.Checked==false)
						//						{
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DEFECT_DESC"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["JI_STATUS_DESC"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CONCLUSION_DATE"]); Response.Write("</td>");
						//						}
						//						if(Convert.ToString(Request.Params ["ACTION"].Trim())!="CORP")
						//						{
						Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
						//						}
						//						if(rdbNo.Checked==false)
						//						{
						//							if(Convert.ToString(Request.Params ["ACTION"].Trim())!="CORP")
						//							{
						//								Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["JI_IE_NAME"]);Response.Write("</td>");
						//								Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["ACTION_PROPOSED"]);Response.Write("</td>");
						//								Response.Write("<td width='9%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["ACTION_PROPOSED_DATE"]);Response.Write("</td>");
						//							}
						//							Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["ACTION"]);Response.Write("</td>");
						//						}
						Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["JI_IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ROOT_CAUSE_ANALYSIS"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHK_STATUS"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["TECH_REF"]); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ACTION_PROPOSED"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ANY_OTHER"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CAPA_STATUS"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DANDAR_STATUS"]); Response.Write("</td>");



						Response.Write("</tr>");
					}
					else
					{
						//						Response.Write("<tr><td colspan=26><H5 align='left'><font face='Verdana'>Complaints Recieved in "+reader["COMP_RECV_REGION"].ToString()+ " Region"+"</Font></td></tr>");
						Response.Write("<tr>");
						Response.Write("<td width='3%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IN_REGION"]); Response.Write("</td>");
						if (Convert.ToString(Request.Params["ACTION"].Trim()) != "CORP")
						{
							Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["COMPLAINT_ID"]); Response.Write("</td>");
						}
						if (rdbNo.Checked == false)
						{
							Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["JI_SNO"]); Response.Write("</td>");
						}
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
						Response.Write("<td width='3%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_SET"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IC_DATE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='3%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_OFF"]); Response.Write("</td>");
						Response.Write("<td width='3%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY_REJECTED"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["REJECTION_VALUE"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["DEPT"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["COMPLAINT_DATE"]); Response.Write("</td>");
						string fpath3 = Server.MapPath("/RBS/REJECTION_MEMO/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF");
						string fpath33 = Server.MapPath("/RBS/REJECTION_MEMO/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF");
						if (File.Exists(fpath3) == false && File.Exists(fpath33) == false)
						{
							Response.Write("<td width='100%' align='center' valign='center'></td>");
						}
						else if (File.Exists(fpath3) == false && File.Exists(fpath33) == true)
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/REJECTION_MEMO/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW REJ MEMO</font></a></td>");
						}
						else
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/REJECTION_MEMO/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW REJ MEMO</font></a></td>");


						}
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["REJECTION_REASON"]); Response.Write("</td>");
						//						if(rdbNo.Checked==true)
						//						{
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["NO_JI_RES"]); Response.Write("</td>");
						//						}
						//						if(rdbNo.Checked==false)
						//						{
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["JI_DATE"]); Response.Write("</td>");
						//						}
						//Response.Write("<td width='4%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["REMARKS"]);Response.Write("</td>");
						string fpath1 = Server.MapPath("/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF");
						string fpath11 = Server.MapPath("/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF");
						if (File.Exists(fpath1) == false && File.Exists(fpath11) == false)
						{
							Response.Write("<td width='100%' align='center' valign='center'></td>");
						}
						else if (File.Exists(fpath1) == false && File.Exists(fpath11) == true)
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI CASE</font></a></td>");
						}
						else
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_CASES/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI CASE</font></a></td>");


						}
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["STATUS"]); Response.Write("</td>");
						string fpath2 = Server.MapPath("/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF");
						string fpath22 = Server.MapPath("/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF");
						if (File.Exists(fpath2) == false && File.Exists(fpath22) == false)
						{
							Response.Write("<td width='100%' align='center' valign='center'></td>");
						}
						else if (File.Exists(fpath2) == false && File.Exists(fpath22) == true)
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI REPORT</font></a></td>");
						}
						else
						{
							Response.Write("<td width='100%' align='center' valign='center'><a href='/RBS/COMPLAINTS_REPORT/" + reader["CASE_NO"].ToString() + "-" + reader["BK_NO"].ToString() + "-" + reader["SET_NO"].ToString() + ".TIF' Font-Names='Verdana' Font-Size='1'><H5 align='center'><font face='Verdana'>VIEW JI REPORT</font></a></td>");


						}


						//						if(rdbNo.Checked==false)
						//						{
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DEFECT_DESC"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["JI_STATUS_DESC"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CONCLUSION_DATE"]); Response.Write("</td>");
						//						}
						//						if(Convert.ToString(Request.Params ["ACTION"].Trim())!="CORP")
						//						{
						Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
						//						}
						//						if(rdbNo.Checked==false)
						//						{
						//							if(Convert.ToString(Request.Params ["ACTION"].Trim())!="CORP")
						//							{
						//								Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["JI_IE_NAME"]);Response.Write("</td>");
						//								Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["ACTION_PROPOSED"]);Response.Write("</td>");
						//								Response.Write("<td width='9%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["ACTION_PROPOSED_DATE"]);Response.Write("</td>");
						//							}
						//							Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["ACTION"]);Response.Write("</td>");
						//						}

						Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["JI_IE_NAME"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ROOT_CAUSE_ANALYSIS"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CHK_STATUS"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["TECH_REF"]); Response.Write("</td>");
						Response.Write("<td width='9%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ACTION_PROPOSED"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["ANY_OTHER"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CAPA_STATUS"]); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DANDAR_STATUS"]); Response.Write("</td>");



						Response.Write("</tr>");
						wC_Region = reader["COMP_RECV_REGION"].ToString();
					}

					ctr = ctr + 1;



				};
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

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel_2.Visible = false;
			Panel_1.Visible = false;
			wToDt = toDt.Text.Trim();
			wFrmDt = frmDt.Text.Trim();
			wRegion = "";

			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }
			compliants_statement();
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		private void rdbAllDefectCD_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbAllDefectCD.Checked == true)
			{
				lstDefectCd.Visible = false;
			}
			else
			{
				lstDefectCd.Visible = true;
			}
		}

		private void rdbAllJIStatus_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbAllJIStatus.Checked == true)
			{
				lstClassification.Visible = false;
			}
			else
			{
				lstClassification.Visible = true;
			}
		}

		private void rdbPAction_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbAllAction.Checked == true)
			{
				lstAction.Visible = false;
			}
			else
			{
				lstAction.Visible = true;
			}
		}

	}
}
