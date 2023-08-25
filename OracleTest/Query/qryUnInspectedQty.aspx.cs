using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Query
{
    public partial class qryUnInspectedQty : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtCaseNo;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.Panel Panel_2;
		OracleConnection conn = null;
		string wRegion;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CHI")
			{
				Panel_2.Visible = false;
				Panel_1.Visible = true;
				wRegion = "";
				if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }
				txtCaseNo.Text = Request.Params["CASE_NO"].ToString().Trim();
				case_history(Convert.ToString(Request.Params["CASE_NO"].Trim()));
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Panel_2.Visible = false;
			Panel_1.Visible = true;
			wRegion = "";
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }
			if (Convert.ToString(Request.Params["ACTION"].Trim()) == "UIQ")
			{
				UnInspectedQty();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CH")
			{
				case_history(txtCaseNo.Text);
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CWS")
			{
				bill_details_case_wise();
			}

		}

		void case_history(string CSNO)
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string mySql = "select T13.CASE_NO,T05.VEND_CD, T05.VEND_NAME||','||T03.CITY VENDOR,T05.VEND_REMARKS, T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DATE,T13.PO_SOURCE,to_char(T13.PO_DT,'yyyy') PO_YR, T91.IMMS_RLY_CD, T13.RLY_CD,T13.REMARKS from T13_PO_MASTER T13, T05_VENDOR T05, T03_CITY T03, T91_RAILWAYS T91 " +
				"WHERE T13.VEND_CD=T05.VEND_CD AND T05.VEND_CITY_CD= T03.CITY_CD AND T13.RLY_CD=T91.RLY_CD(+) " +
				"AND T13.CASE_NO='" + CSNO + "' and REGION_CODE='" + Session["Region"].ToString() + "'";
			try
			{
				string vend_remarks = "", po_remarks = "", po_no = "", rly_cd = "", po_yr = "", po_source = "", po_dt = "";
				int vend_cd = 0;
				OracleCommand cmd = new OracleCommand(mySql, conn);
				conn.Open();
				OracleDataReader reader11 = cmd.ExecuteReader();
				if (reader11.HasRows == true)
				{
					while (reader11.Read())
					{
						Response.Write("<br><table border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr><td width='100%'>");
						Response.Write("<H5 align='center'><font face='Verdana'>History for Case No. - " + txtCaseNo.Text + " (" + wRegion + ")</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr><td width='100%' align='center'>");
						Response.Write("<font face='Verdana'><U>PO DETAILS</U></font><br>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td>");
						Response.Write("<table border='1' width='100%' bgcolor='#D9C9FF'>");
						Response.Write("<tr>");
						Response.Write("<td valign='top'><font size='1' face='Verdana' color='dark blue'>Case No. " + reader11["CASE_NO"].ToString() + "</font>");
						Response.Write("<td valign='top'><font size='1' face='Verdana' color='dark blue'>Vendor:  " + reader11["VENDOR"].ToString() + "</font>");
						Response.Write("</td></tr>");
						Response.Write("<tr>");
						Response.Write("<td valign='top'><font size='1' face='Verdana' color='dark blue'>PO No. " + reader11["PO_NO"].ToString() + ", Dated : " + reader11["PO_DATE"].ToString() + "</font>");
						Response.Write("<td valign='top'><font size='1' face='Verdana' color='dark blue'>Client:  " + reader11["RLY_CD"].ToString() + "</font>");
						vend_remarks = reader11["VEND_REMARKS"].ToString();
						po_remarks = reader11["REMARKS"].ToString();
						vend_cd = Convert.ToInt32(reader11["VEND_CD"].ToString());
						Response.Write("</td></tr></table>");
						po_no = reader11["PO_NO"].ToString();
						po_dt = reader11["PO_DATE"].ToString();
						po_yr = reader11["PO_YR"].ToString();
						rly_cd = reader11["IMMS_RLY_CD"].ToString();
						po_source = reader11["PO_SOURCE"].ToString();

					}

				}
				conn.Close();

				string mySql11 = "Select t15.CASE_NO,t15.ITEM_SRNO,t15.ITEM_DESC,t15.QTY,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') DELV_DATE,sum(nvl(t18.QTY_PASSED,0)) passed,sum(nvl(t18.QTY_REJECTED,0)) rejected From T15_PO_DETAIL t15,T18_CALL_DETAILS t18 Where t15.CASE_NO=t18.CASE_NO(+) and t15.ITEM_SRNO=t18.ITEM_SRNO_PO(+) and t15.case_no='" + CSNO + "' and substr(T15.CASE_NO,1,1)='" + Session["Region"].ToString() + "' group by t15.CASE_NO,t15.ITEM_SRNO,t15.ITEM_DESC,t15.qty,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') order by t15.CASE_NO,t15.ITEM_SRNO";
				OracleCommand cmd11 = new OracleCommand(mySql11, conn);
				conn.Open();
				OracleDataReader reader = cmd11.ExecuteReader();
				if (reader.HasRows == true)
				{
					Response.Write("<table border='1' width='100%'>");
					Response.Write("<tr bgColor='aliceblue'><td width='5%' valign='top'><font size='1' face='Verdana'>Item Srno</font></td>");
					Response.Write("<td width='35%' valign='top'><font size='1' face='Verdana'>Item Description</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Qty Ordered</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Qty Passed</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Qty Rejected</font></td>");
					//					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Qty Due</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'><B>BALANCE QTY </B>(Qty Ordered - Qty Passed)</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Delv Period</font></td>");
					Response.Write("</tr></font>");
					double avail = 0;
					while (reader.Read())
					{
						//						i=i+1;
						//						if(i==1)
						//						{
						//							
						//							
						//						}
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_SRNO"].ToString()); Response.Write("</td>");
						Response.Write("<td width='35%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["passed"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["rejected"].ToString()); Response.Write("</td>");
						//						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["QTY_DUE"].ToString());Response.Write("</td>");
						double bal = Convert.ToDouble(reader["QTY"].ToString()) - Convert.ToDouble(reader["passed"].ToString());
						if (bal > 0)
						{
							avail = 1;
						}
						Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(bal); Response.Write("</b></td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["DELV_DATE"].ToString()); Response.Write("</td>");
						Response.Write("</tr>");
						//							ctr=ctr+1;

					}
					if (avail == 0)
					{
						Response.Write("<tr><td width='35%' valign='top' align='Center' colspan=7> <font size='2' face='Verdana'><b>"); Response.Write("Order quantity completed hence no more inspection shall be taken !!!"); Response.Write("</b></td></tr>");
					}
					Response.Write("</table></td></tr>");
					conn.Close();



					Response.Write("<tr><td width='100%' colspan=2 align='center' valign='center'>");
					if (po_source == "C")
					{
						Response.Write("<a href='https://www.ireps.gov.in/ireps/etender/pdfdocs/MMIS/PO/" + po_yr + "/" + rly_cd + "/" + po_no + ".pdf' Font-Names='Verdana' Font-Size='8pt'><H5 align='center'><font face='Verdana'>VIEW PO</font></a>");

						//string mySqlMA="select C.MAKEY,C.SLNO, TO_CHAR(B.MAKEY_DATE,'DD/MM/YYYY')MAKEY_DT,MA_FLD_DESCR,OLD_VALUE, NEW_VALUE, RITES_CASE_NO,A.IMMS_RLY_CD, A.IMMS_POKEY,B.MA_NO, TO_CHAR(B.MA_DATE,'DD/MM/YYYY') MA_DT, DECODE(MA_STATUS,'A','Approved','N','Approved With No Change in IBS','Pending') MA_STATUS FROM IMMS_RITES_PO_HDR A, MMP_POMA_HDR B, MMP_POMA_DTL C WHERE A.IMMS_RLY_CD=B.RLY AND A.IMMS_POKEY=B.POKEY AND B.RLY=C.RLY AND B.MAKEY=C.MAKEY and RITES_CASE_NO='"+CSNO+"' ORDER BY C.SLNO";

					}
					else
					{
						string fpath = Server.MapPath("/RBS/CASE_NO/" + txtCaseNo.Text.Trim() + ".TIF");
						string fpath1 = Server.MapPath("/RBS/CASE_NO/" + txtCaseNo.Text.Trim() + ".PDF");
						if (File.Exists(fpath) == true)
						{
							//Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/"+txtCaseNo.Text.Trim()+".TIF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'><H5 align='center'><font face='Verdana'>VIEW PO</font></font></a>");Response.Write("</td>");
							Response.Write("<a href='/RBS/CASE_NO/" + txtCaseNo.Text.Trim() + ".TIF' Font-Names='Verdana' Font-Size='8pt'><H5 align='center'><font face='Verdana'>VIEW PO</font></a>");
						}
						else if (File.Exists(fpath1) == true)
						{
							//Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/"+txtCaseNo.Text.Trim()+".PDF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'><H5 align='center'><font face='Verdana'>VIEW PO</font></font></a>");Response.Write("</td>");
							Response.Write("<a href='/RBS/CASE_NO/" + txtCaseNo.Text.Trim() + ".PDF' Font-Names='Verdana' Font-Size='8pt'><H5 align='center'><font face='Verdana'>VIEW PO</font></a>");
						}
						else
						{

							Response.Write(" ");
						}

					}

					string mySqlMA = "select C.MAKEY,C.SLNO, TO_CHAR(B.MAKEY_DATE,'DD/MM/YYYY')MAKEY_DT,MA_FLD_DESCR,OLD_VALUE, NEW_VALUE, RITES_CASE_NO,A.IMMS_RLY_CD, A.IMMS_POKEY,B.MA_NO, TO_CHAR(B.MA_DATE,'DD/MM/YYYY') MA_DT, DECODE(MA_STATUS,'A','Approved','N','Approved With No Change in IBS','Pending') MA_STATUS FROM IMMS_RITES_PO_HDR A, MMP_POMA_HDR B, MMP_POMA_DTL C WHERE A.IMMS_RLY_CD=B.RLY AND A.IMMS_POKEY=B.POKEY AND B.RLY=C.RLY AND B.MAKEY=C.MAKEY and A.PO_NO=UPPER('" + po_no.Trim() + "') AND TO_CHAR(A.PO_DT,'DD/MM/YYYY')='" + po_dt + "' ORDER BY C.SLNO";

					OracleCommand cmdMA = new OracleCommand(mySqlMA, conn);
					conn.Open();
					OracleDataReader readerMA = cmdMA.ExecuteReader();

					if (readerMA.HasRows == true)
					{
						Response.Write("<tr><td width='100%' align='center'>");
						Response.Write("<font face='Verdana'><br><U>PO AMMENDMENTS IREPS</U></font><br>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr><td><table border='1' width='100%'>");
						Response.Write("<tr bgColor='aliceblue'><td width='5%' valign='top'><font size='1' face='Verdana'>Sno</font></td>");
						Response.Write("<td width='20%' valign='top'><font size='1' face='Verdana'>MA No.</font></td>");
						Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>MA Date</font></td>");
						Response.Write("<td width='20%' valign='top'><font size='1' face='Verdana'>MA Field</font></td>");
						Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>OLD Value</font></td>");
						Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>New Value</font></td>");
						Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Status</font></td>");
						Response.Write("<td width='30%' valign='top'><font size='1' face='Verdana'>PDF</font></td>");


						Response.Write("</tr></font>");

						while (readerMA.Read())
						{
							Response.Write("<tr>");
							Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(readerMA["SLNO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerMA["MA_NO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerMA["MA_DT"].ToString()); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(readerMA["MA_FLD_DESCR"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerMA["OLD_VALUE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerMA["NEW_VALUE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerMA["MA_STATUS"].ToString()); Response.Write("</td>");
							Response.Write("<td width='30%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write("<a href='https://www.ireps.gov.in/ireps/etender/pdfdocs/MMIS/PO/" + po_yr + "/" + rly_cd + "/" + po_no + "_" + readerMA["MA_NO"].ToString() + ".pdf' Font-Names='Verdana' Font-Size='8pt'><H5 align='center'><font face='Verdana'>VIEW</font></a></td>");
							Response.Write("</tr>");

						}

						Response.Write("</table></td></tr>");

					}
					conn.Close();

					string mySqlMA_Vend = "select M.CASE_NO, M.MA_NO, TO_CHAR(M.MA_DT,'DD/MM/YYYY')MA_DT,MA_SNO,MA_FIELD,MA_DESC,OLD_PO_VALUE, NEW_PO_VALUE, DECODE(MA_STATUS,'A','Approved','N','Approved With No Change in IBS','Pending') MA_STATUS FROM VEND_PO_MA_MASTER M, VEND_PO_MA_DETAIL D WHERE M.CASE_NO=D.CASE_NO AND M.MA_NO=D.MA_NO AND M.MA_DT=D.MA_DT AND M.CASE_NO='" + CSNO + "' and MA_STATUS IN ('A','N') ORDER BY D.MA_SNO";

					OracleCommand cmdMA_Vend = new OracleCommand(mySqlMA_Vend, conn);
					conn.Open();
					OracleDataReader readerMA_Vend = cmdMA_Vend.ExecuteReader();

					if (readerMA_Vend.HasRows == true)
					{
						Response.Write("<tr><td width='100%' align='center'>");
						Response.Write("<font face='Verdana'><br><U>PO AMMENDMENTS VENDOR</U></font><br>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr><td><table border='1' width='100%'>");
						Response.Write("<tr bgColor='aliceblue'><td width='5%' valign='top'><font size='1' face='Verdana'>Sno</font></td>");
						Response.Write("<td width='20%' valign='top'><font size='1' face='Verdana'>MA No.</font></td>");
						Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>MA Date</font></td>");
						Response.Write("<td width='20%' valign='top'><font size='1' face='Verdana'>MA Field</font></td>");
						Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>OLD Value</font></td>");
						Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>New Value</font></td>");
						Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Status</font></td>");
						Response.Write("<td width='30%' valign='top'><font size='1' face='Verdana'>PDF</font></td>");


						Response.Write("</tr></font>");

						while (readerMA_Vend.Read())
						{
							string mdt_ma = dateconcate(readerMA_Vend["MA_DT"].ToString());


							Response.Write("<tr>");
							Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(readerMA_Vend["MA_SNO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerMA_Vend["MA_NO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerMA_Vend["MA_DT"].ToString()); Response.Write("</td>");
							Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(readerMA_Vend["MA_DESC"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerMA_Vend["OLD_PO_VALUE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerMA_Vend["NEW_PO_VALUE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(readerMA_Vend["MA_STATUS"].ToString()); Response.Write("</td>");
							Response.Write("<td width='30%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write("<a href='/RBS/Vendor/MA/" + readerMA_Vend["CASE_NO"].ToString() + "_" + readerMA_Vend["MA_NO"].ToString() + "_" + mdt_ma + ".pdf' Font-Names='Verdana' Font-Size='8pt'><H5 align='center'><font face='Verdana'>VIEW MA</font></a></td>");
							Response.Write("</tr>");

						}

						Response.Write("</table></td></tr>");

					}
					conn.Close();


					//					string fpath=Server.MapPath("/RBS/CASE_NO/"+txtCaseNo.Text.Trim()+".TIF");
					//					if (File.Exists(fpath)==false) 
					//					{
					//						Response.Write(" ");
					//					}
					//					else
					//					{
					//						Response.Write("<a href='/RBS/CASE_NO/"+txtCaseNo.Text.Trim()+".TIF' Font-Names='Verdana' Font-Size='8pt'><H5 align='center'><font face='Verdana'>VIEW PO</font></a>");
					//					}
					Response.Write("</td>");
					Response.Write("</tr>");
					string mySql1 = "select to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_DATE,to_char(T17.CALL_LETTER_DT,'dd/mm/yyyy') LETTER_DATE ,T17.CALL_SNO, T17.CALL_INSTALL_NO, T09.IE_NAME,trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'C',' on '||to_char(T19.CANCEL_DATE,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,T20.REASON_REJECT, " +
						"decode(T19.CANCEL_CD_1,1,'Material Not Found',2,'Call letter recieved after expiry of delivery period',3,'your call letter was not in prescribed format',4,'Your refusal to undertake test on samples in approved independent test houses or RITES Lab at your cost (Whichever applicable)',5,'Material offered at premises where adequate room or lighting etc. not available for proper sampling or inspection.',6,'Internal inspection and test records incomplete / not as per contractual requirement.',7,'Packing list showing quantities offered item wise and consignee wise not read (Whichever applicable) ',8,'Lot mixed not segregated. Please re-offer after proper segregation.',9,'You could not arrange for inspection in spite of personal contact / phone with your Shri. ',10,'You could not produce following documents drg, / spec. / P.O.: at the time of inspection in absence of which inspection could not be done.',11,'Call Withdrawn By Vendor',12,'OThers:'||CANCEL_DESC)||'*'|| " +
						"decode(T19.CANCEL_CD_2,1,'Material Not Found',2,'Call letter recieved after expiry of delivery period',3,'your call letter was not in prescribed format',4,'Your refusal to undertake test on samples in approved independent test houses or RITES Lab at your cost (Whichever applicable)',5,'Material offered at premises where adequate room or lighting etc. not available for proper sampling or inspection.',6,'Internal inspection and test records incomplete / not as per contractual requirement.',7,'Packing list showing quantities offered item wise and consignee wise not read (Whichever applicable) ',8,'Lot mixed not segregated. Please re-offer after proper segregation.',9,'You could not arrange for inspection in spite of personal contact / phone with your Shri. ',10,'You could not produce following documents drg, / spec. / P.O.: at the time of inspection in absence of which inspection could not be done.',11,'Call Withdrawn By Vendor',12,'OThers:'||CANCEL_DESC)||'*'|| " +
						"decode(T19.CANCEL_CD_3,1,'Material Not Found',2,'Call letter recieved after expiry of delivery period',3,'your call letter was not in prescribed format',4,'Your refusal to undertake test on samples in approved independent test houses or RITES Lab at your cost (Whichever applicable)',5,'Material offered at premises where adequate room or lighting etc. not available for proper sampling or inspection.',6,'Internal inspection and test records incomplete / not as per contractual requirement.',7,'Packing list showing quantities offered item wise and consignee wise not read (Whichever applicable) ',8,'Lot mixed not segregated. Please re-offer after proper segregation.',9,'You could not arrange for inspection in spite of personal contact / phone with your Shri. ',10,'You could not produce following documents drg, / spec. / P.O.: at the time of inspection in absence of which inspection could not be done.',11,'Call Withdrawn By Vendor',12,'OThers:'||CANCEL_DESC) REASON" +
						" from T17_CALL_REGISTER T17,T09_IE T09, T21_CALL_STATUS_CODES T21, T19_CALL_CANCEL T19, T20_IC T20 where T17.CASE_NO=T19.CASE_NO(+) and T17.CALL_RECV_DT=T19.CALL_RECV_DT(+) and T17.CALL_SNO=T19.CALL_SNO(+) and T17.CASE_NO=T20.CASE_NO(+) and T17.CALL_RECV_DT=T20.CALL_RECV_DT(+) and T17.CALL_SNO=T20.CALL_SNO(+) and T17.IE_CD=T09.IE_CD and T17.CALL_STATUS=T21.CALL_STATUS_CD and T17.CASE_NO='" + CSNO + "' " +
						"GROUP BY to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') ,to_char(T17.CALL_LETTER_DT,'dd/mm/yyyy') ,T17.CALL_SNO, T17.CALL_INSTALL_NO, T09.IE_NAME,trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'C',' on '||to_char(T19.CANCEL_DATE,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)',''),T20.REASON_REJECT, " +
						"decode(T19.CANCEL_CD_1,1,'Material Not Found',2,'Call letter recieved after expiry of delivery period',3,'your call letter was not in prescribed format',4,'Your refusal to undertake test on samples in approved independent test houses or RITES Lab at your cost (Whichever applicable)',5,'Material offered at premises where adequate room or lighting etc. not available for proper sampling or inspection.',6,'Internal inspection and test records incomplete / not as per contractual requirement.',7,'Packing list showing quantities offered item wise and consignee wise not read (Whichever applicable) ',8,'Lot mixed not segregated. Please re-offer after proper segregation.',9,'You could not arrange for inspection in spite of personal contact / phone with your Shri. ',10,'You could not produce following documents drg, / spec. / P.O.: at the time of inspection in absence of which inspection could not be done.',11,'Call Withdrawn By Vendor',12,'OThers:'||CANCEL_DESC)||'*'|| " +
						"decode(T19.CANCEL_CD_2,1,'Material Not Found',2,'Call letter recieved after expiry of delivery period',3,'your call letter was not in prescribed format',4,'Your refusal to undertake test on samples in approved independent test houses or RITES Lab at your cost (Whichever applicable)',5,'Material offered at premises where adequate room or lighting etc. not available for proper sampling or inspection.',6,'Internal inspection and test records incomplete / not as per contractual requirement.',7,'Packing list showing quantities offered item wise and consignee wise not read (Whichever applicable) ',8,'Lot mixed not segregated. Please re-offer after proper segregation.',9,'You could not arrange for inspection in spite of personal contact / phone with your Shri. ',10,'You could not produce following documents drg, / spec. / P.O.: at the time of inspection in absence of which inspection could not be done.',11,'Call Withdrawn By Vendor',12,'OThers:'||CANCEL_DESC)||'*'|| " +
						"decode(T19.CANCEL_CD_3,1,'Material Not Found',2,'Call letter recieved after expiry of delivery period',3,'your call letter was not in prescribed format',4,'Your refusal to undertake test on samples in approved independent test houses or RITES Lab at your cost (Whichever applicable)',5,'Material offered at premises where adequate room or lighting etc. not available for proper sampling or inspection.',6,'Internal inspection and test records incomplete / not as per contractual requirement.',7,'Packing list showing quantities offered item wise and consignee wise not read (Whichever applicable) ',8,'Lot mixed not segregated. Please re-offer after proper segregation.',9,'You could not arrange for inspection in spite of personal contact / phone with your Shri. ',10,'You could not produce following documents drg, / spec. / P.O.: at the time of inspection in absence of which inspection could not be done.',11,'Call Withdrawn By Vendor',12,'OThers:'||CANCEL_DESC) order by to_date(CALL_DATE,'dd/mm/yyyy') DESC ";
					OracleCommand cmd1 = new OracleCommand(mySql1, conn);
					conn.Open();
					OracleDataReader reader1 = cmd1.ExecuteReader();
					int wSno = 1;
					if (reader1.HasRows == true)
					{
						Response.Write("<tr><td width='100%' align='center'>");
						Response.Write("<font face='Verdana'><br><U>PREVIOUS CALL DETAILS</U></font><br>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr><td><table border='1' width='100%'>");
						Response.Write("<tr bgColor='aliceblue'><td width='5%' valign='top'><font size='1' face='Verdana'>Sno</font></td>");
						Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Call Letter Date</font></td>");
						Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Call Recieving Date</font></td>");
						Response.Write("<td width='5%' valign='top'><font size='1' face='Verdana'>Call Sno</font></td>");
						Response.Write("<td width='5%' valign='top'><font size='1' face='Verdana'>Call Install No.</font></td>");
						Response.Write("<td width='15%' valign='top'><font size='1' face='Verdana'>IE</font></td>");
						Response.Write("<td width='15%' valign='top'><font size='1' face='Verdana'>Status</font></td>");
						Response.Write("<td width='25%' valign='top'><font size='1' face='Verdana'>Cancel Reason</font></td>");
						Response.Write("<td width='20%' valign='top'><font size='1' face='Verdana'>Rejection Reason</font></td>");
						Response.Write("</tr></font>");
						//						while (reader1.Read() && wSno<=10)
						while (reader1.Read())
						{
							Response.Write("<tr>");
							Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wSno); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader1["LETTER_DATE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader1["CALL_DATE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader1["CALL_SNO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader1["CALL_INSTALL_NO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["IE_NAME"].ToString()); Response.Write("</td>");
							Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["CALL_STATUS"].ToString()); Response.Write("</td>");
							if (reader1["REASON"].ToString() != "**")
							{
								Response.Write("<td width='25%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["REASON"].ToString()); Response.Write("</td>");
							}
							else
							{
								Response.Write("<td width='25%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write("-"); Response.Write("</td>");
							}
							if (reader1["REASON_REJECT"].ToString() == "")
							{
								Response.Write("<td width='25%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write("-"); Response.Write("</td>");
							}
							else
							{
								Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["REASON_REJECT"].ToString()); Response.Write("</td>");
							}
							Response.Write("</tr>");
							wSno = wSno + 1;
						}
						Response.Write("</table></td></tr>");


					}


				}
				conn.Close();
				Response.Write("<tr><td width='100%'>");
				Response.Write("<H5 align='left'><font face='Verdana'><br><U>Special Remarks:</U></font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				if (po_remarks != "")
				{
					Response.Write("<tr><td width='100%'>");
					Response.Write("<font size='1' face='Verdana'><br>1) <U>PO:</U>  " + po_remarks + "</font><br>");
					Response.Write("</td>");
					Response.Write("</tr>");
				}
				else
				{
					Response.Write("<tr><td width='100%'>");
					Response.Write("<font size='1' face='Verdana'><br>1) <U>PO:</U>  Nil</font><br>");
					Response.Write("</td>");
					Response.Write("</tr>");
				}

				if (vend_remarks != "")
				{
					Response.Write("<tr><td width='100%'>");
					Response.Write("<font size='1' face='Verdana'><br>2) <U>Vendor/Firm:</U>  " + vend_remarks + "</font><br>");
					Response.Write("</td>");
					Response.Write("</tr>");
				}
				else
				{
					Response.Write("<tr><td width='100%'>");
					Response.Write("<font size='1'face='Verdana'><br>2) <U>Vendor/Firm:</U>  Nil</font><br>");
					Response.Write("</td>");
					Response.Write("</tr>");
				}

				string mySql2 = "select ITEM_DESC, to_char(REJ_MEMO_DT,'dd/mm/yyyy') REJ_MEMO_DATE,REJECTION_REASON,BK_NO,SET_NO,CONSIGNEE_NAME||'/'||CONSIGNEE_ADDR||'/'||CONSIGNEE_CITY CONSIGNEE, T39.JI_STATUS_DESC FROM V40_CONSIGNEE_COMPLAINTS V40,T39_JI_STATUS_CODES T39 WHERE V40.JI_STATUS_CD=T39.JI_STATUS_CD(+) AND VEND_CD=" + vend_cd + " and NVL(JI_REQUIRED,'X')='Y' Order by REJ_MEMO_DT";

				OracleCommand cmd2 = new OracleCommand(mySql2, conn);
				conn.Open();
				OracleDataReader reader2 = cmd2.ExecuteReader();
				int wSnoc = 1;
				if (reader2.HasRows == true)
				{
					Response.Write("<tr><td width='100%' align='center'>");
					Response.Write("<font face='Verdana'><br><U>CONSIGNEE COMPLAINTS</U></font><br>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr><td><table border='1' width='100%'>");
					Response.Write("<tr bgColor='aliceblue'><td width='5%' valign='top'><font size='1' face='Verdana'>Sno</font></td>");
					Response.Write("<td width='30%' valign='top'><font size='1' face='Verdana'>Item</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>Rej Memo Date</font></td>");
					Response.Write("<td width='20%' valign='top'><font size='1' face='Verdana'>Rejection Reason</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>BK No & Set No.</font></td>");
					Response.Write("<td width='20%' valign='top'><font size='1' face='Verdana'>Consignee</font></td>");
					Response.Write("<td width='5%' valign='top'><font size='1' face='Verdana'>JI Outcome</font></td>");

					Response.Write("</tr></font>");
					//						while (reader1.Read() && wSno<=10)
					while (reader2.Read())
					{
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wSnoc); Response.Write("</td>");
						Response.Write("<td width='30%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader2["ITEM_DESC"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader2["REJ_MEMO_DATE"].ToString()); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader2["REJECTION_REASON"].ToString()); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader2["BK_NO"].ToString() + " & " + reader2["SET_NO"].ToString()); Response.Write("</td>");
						Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader2["CONSIGNEE"].ToString()); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader2["JI_STATUS_DESC"].ToString()); Response.Write("</td>");

						Response.Write("</tr>");
						wSnoc = wSnoc + 1;
					}

					Response.Write("</table></td></tr>");

				}
				conn.Close();
				string mySql3 = "select T20.BILL_NO, to_char(T20.IC_DT,'dd/mm/yyyy') IC_DATE,T20.BK_NO,T20.SET_NO,T20.REASON_REJECT,T09.IE_NAME,V05.Vendor,T18.ITEM_DESC_PO from T13_PO_MASTER T13, T20_IC T20, T09_IE T09,V05_VENDOR V05, T18_CALL_DETAILS T18 where T13.CASE_NO=T20.CASE_NO and T13.VEND_CD=V05.VEND_CD and T20.IE_CD=T09.IE_CD and T20.CASE_NO=T18.CASE_NO and T20.CALL_RECV_DT=T18.CALL_RECV_DT and T20.CALL_SNO=T18.CALL_SNO and T20.CONSIGNEE_CD=T18.CONSIGNEE_CD  and T20.IC_TYPE_ID=2 and substr(T13.CASE_NO,1,1)='" + Session["Region"] + "'  and T13.VEND_CD=" + vend_cd + " and T13.CASE_NO<>'" + txtCaseNo.Text.Trim() + "' order by T20.IC_DT,T20.BILL_NO";

				OracleCommand cmd3 = new OracleCommand(mySql3, conn);
				conn.Open();
				OracleDataReader reader3 = cmd3.ExecuteReader();
				int wSnor = 1;
				if (reader3.HasRows == true)
				{
					Response.Write("<tr><td width='100%' align='center'>");
					Response.Write("<font face='Verdana'><br><U>REJECTIONS AT VENDOR PLACE</U></font><br>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr><td><table border='1' width='100%'>");
					Response.Write("<tr bgColor='aliceblue'><td width='5%' valign='top'><font size='1' face='Verdana'>Sno</font></td>");
					Response.Write("<td width='40%' valign='top'><font size='1' face='Verdana'>Item</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>IC Date</font></td>");
					Response.Write("<td width='20%' valign='top'><font size='1' face='Verdana'>Rejection Reason</font></td>");
					Response.Write("<td width='10%' valign='top'><font size='1' face='Verdana'>BK No & Set No.</font></td>");
					Response.Write("<td width='15%' valign='top'><font size='1' face='Verdana'>IE</font></td>");
					Response.Write("</tr></font>");
					//						while (reader1.Read() && wSno<=10)
					string wBill_No = "";
					while (reader3.Read())
					{
						if (wBill_No == reader3["BILL_NO"].ToString())
						{
							Response.Write("<tr>");
							Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'> </td>");
							Response.Write("<td width='40%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader3["ITEM_DESC_PO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'> </td>");
							Response.Write("<td width='20%' valign='top' align='left'> <font size='1' face='Verdana'> </td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'> </td>");
							Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'> </td>");
							Response.Write("</tr>");
							wSnor = wSnor + 1;
							wBill_No = reader3["BILL_NO"].ToString();
						}
						else
						{
							Response.Write("<tr>");
							Response.Write("<td width='5%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wSnor); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader3["ITEM_DESC_PO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader3["IC_DATE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader3["REASON_REJECT"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader3["BK_NO"].ToString() + " & " + reader3["SET_NO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader3["IE_NAME"].ToString()); Response.Write("</td>");
							Response.Write("</tr>");
							wSnor = wSnor + 1;
							wBill_No = reader3["BILL_NO"].ToString();
						}
					}

					Response.Write("</table></td></tr>");
					conn.Close();
				}
				Response.Write("</table>");
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
		string dateconcate(string dt)
		{
			string myYear, myMonth, myDay;

			myYear = dt.Substring(6, 4);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;
			return (dt1);
		}
		void UnInspectedQty()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string mySql = "Select T15.CASE_NO,T18.CONSIGNEE_CD,V06.CONSIGNEE,T15.ITEM_SRNO,T15.ITEM_DESC,T15.QTY,T04.UOM_S_DESC,nvl(T18.QTY_PASSED,0)QTY_PASSED ,nvl(T18.QTY_REJECTED,0) QTY_REJECTED,T20.BK_NO,T20.SET_NO,to_char(T20.IC_DT,'dd/mm/yyyy') IC_DT,T09.IE_SNAME, T23.RATE " +
						 "From T15_PO_DETAIL T15,T18_CALL_DETAILS T18,T20_IC T20,T09_IE T09,T04_UOM T04,V06_CONSIGNEE V06,T22_BILL T22, T23_BILL_ITEMS T23 " +
						 "Where T15.UOM_CD=T04.UOM_CD and T15.CASE_NO=T18.CASE_NO and T15.ITEM_SRNO=T18.ITEM_SRNO_PO and T18.CONSIGNEE_CD=V06.CONSIGNEE_CD AND T20.BILL_NO=T22.BILL_NO AND T22.BILL_NO=T23.BILL_NO" +
						 "   and T20.CASE_NO=T18.CASE_NO and T20.CALL_RECV_DT=T18.CALL_RECV_DT and T20.CALL_SNO=T18.CALL_SNO and T20.CONSIGNEE_CD=T18.CONSIGNEE_CD and T20.IE_CD=T09.IE_CD " +
						 "   and T20.CASE_NO='" + txtCaseNo.Text + "' and substr(T15.CASE_NO,1,1)='" + Session["Region"].ToString() + "' " +
						 "Order by T15.CASE_NO,T18.CONSIGNEE_CD,T15.ITEM_SRNO";

			string wItemDesc = "", wConsignee = "", wUOM = "", wBook = "", wSet = "", wIc_Dt = "", wIE = "", wpSno = "", wpQty = "";
			decimal wQty = 0, wQty_Passed = 0, wQty_Rejected = 0;
			decimal wtQty = 0, wtQty_Passed = 0, wtQty_Rejected = 0, wRate = 0;
			int wpConsignee_Cd = 0, wpItem_Srno = 0;
			int wConsignee_Cd = 0, wItem_Srno = 0;
			int ctr = 60, multi_rec = 0;
			int wSno = 0;
			try
			{
				OracleCommand cmd = new OracleCommand(mySql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows == true)
				{
					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr><td width='100%' colspan='13'>");
					Response.Write("<H5 align='center'><font face='Verdana'>PO Status for Case No. - " + txtCaseNo.Text + " (" + wRegion + ")</font><br></p>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
					Response.Write("<th width='16%' valign='top'><b><font size='1' face='Verdana'>Consignee</font></b></th>");
					Response.Write("<th width='21%' valign='top'><b><font size='1' face='Verdana'>Item Description</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Qty Ordered</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>UOM</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Qty Passed</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Qty Rejected</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Rate</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Balance Qty (Qty Ordered - Qty Passed)</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Book No.</font></b></th>");
					Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Set No.</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>IC Date</font></b></th>");
					Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
					Response.Write("</tr></font>");
					while (reader.Read())
					{
						if (wpConsignee_Cd == Convert.ToInt32(reader["CONSIGNEE_CD"]) & wpItem_Srno == Convert.ToInt32(reader["ITEM_SRNO"]))
						{
							Response.Write("<tr>");
							Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wpSno + "</td>");
							Response.Write("<td width='16%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wConsignee); Response.Write("</td>");
							Response.Write("<td width='21%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wItemDesc); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wpQty); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wUOM); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wQty_Passed); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wQty_Rejected); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wRate); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wBook); Response.Write("</td>");
							Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wSet); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wIc_Dt); Response.Write("</td>");
							Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wIE); Response.Write("</td>");
							Response.Write("</tr>");
							ctr = ctr + 1;
							wpSno = "";
							wConsignee = "";
							wItemDesc = "";
							wpQty = "";
							wUOM = "";
							wQty_Passed = Convert.ToDecimal(reader["QTY_PASSED"]);
							wQty_Rejected = Convert.ToDecimal(reader["QTY_REJECTED"]);
							wRate = Convert.ToDecimal(reader["RATE"]);
							wBook = reader["BK_NO"].ToString();
							wSet = reader["SET_NO"].ToString();
							wIc_Dt = reader["IC_DT"].ToString();
							wIE = reader["IE_SNAME"].ToString();
							wtQty_Passed = wtQty_Passed + wQty_Passed;
							wtQty_Rejected = wtQty_Rejected + wQty_Rejected;
							multi_rec = 1;
						}
						else
						{
							wpConsignee_Cd = Convert.ToInt32(reader["CONSIGNEE_CD"]);
							wpItem_Srno = Convert.ToInt32(reader["ITEM_SRNO"]);
							if (wSno != 0)
							{
								if (multi_rec == 1)
								{
									Response.Write("<tr>");
									Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wpSno + "</td>");
									Response.Write("<td width='16%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wConsignee); Response.Write("</td>");
									Response.Write("<td width='21%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wItemDesc); Response.Write("</td>");
									Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wpQty); Response.Write("</td>");
									Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wUOM); Response.Write("</td>");
									Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wQty_Passed); Response.Write("</td>");
									Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wQty_Rejected); Response.Write("</td>");
									Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wRate); Response.Write("</td>");
									Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
									Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wBook); Response.Write("</td>");
									Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wSet); Response.Write("</td>");
									Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wIc_Dt); Response.Write("</td>");
									Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wIE); Response.Write("</td>");
									Response.Write("</tr>");
									wBook = "";
									wSet = "";
									wIc_Dt = "";
									wIE = "";
									multi_rec = 0;
								}
								Response.Write("<tr>");
								Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wpSno + "</td>");
								Response.Write("<td width='16%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wConsignee); Response.Write("</td>");
								Response.Write("<td width='21%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wItemDesc); Response.Write("</td>");
								Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtQty); Response.Write("</b></td>");
								Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wUOM); Response.Write("</td>");
								Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtQty_Passed); Response.Write("</b></td>");
								Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtQty_Rejected); Response.Write("</b></td>");
								Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wRate); Response.Write("</b></td>");
								Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtQty - wtQty_Passed); Response.Write("</b></td>");
								Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wBook); Response.Write("</td>");
								Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wSet); Response.Write("</td>");
								Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wIc_Dt); Response.Write("</td>");
								Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wIE); Response.Write("</td>");
								Response.Write("</tr>");
								Response.Write("<tr><td colspan=12><font size='1' face='Verdana'>&nbsp</td></tr>");
							}
							wSno = wSno + 1;
							wpSno = Convert.ToString(wSno);
							wConsignee_Cd = wpConsignee_Cd;
							wItem_Srno = wpItem_Srno;
							wConsignee = reader["CONSIGNEE"].ToString();
							wItemDesc = reader["ITEM_DESC"].ToString();
							wQty = Convert.ToDecimal(reader["QTY"]);
							wpQty = Convert.ToString(wQty);
							wUOM = reader["UOM_S_DESC"].ToString();
							wQty_Passed = Convert.ToDecimal(reader["QTY_PASSED"]);
							wQty_Rejected = Convert.ToDecimal(reader["QTY_REJECTED"]);
							wRate = Convert.ToDecimal(reader["RATE"]);
							wBook = reader["BK_NO"].ToString();
							wSet = reader["SET_NO"].ToString();
							wIc_Dt = reader["IC_DT"].ToString();
							wIE = reader["IE_SNAME"].ToString();
							wtQty = wQty;
							wtQty_Passed = wQty_Passed;
							wtQty_Rejected = wQty_Rejected;
						}
					};
					if (multi_rec == 1)
					{
						Response.Write("<tr>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wpSno + "</td>");
						Response.Write("<td width='16%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wConsignee); Response.Write("</td>");
						Response.Write("<td width='21%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wItemDesc); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wpQty); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wUOM); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wQty_Passed); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wQty_Rejected); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(wRate); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wBook); Response.Write("</td>");
						Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wSet); Response.Write("</td>");
						Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wIc_Dt); Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wIE); Response.Write("</td>");
						Response.Write("</tr>");
						wBook = "";
						wSet = "";
						wIc_Dt = "";
						wIE = "";
					}
					Response.Write("<tr>");
					Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wpSno + "</td>");
					Response.Write("<td width='16%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wConsignee); Response.Write("</td>");
					Response.Write("<td width='21%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(wItemDesc); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtQty); Response.Write("</b></td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wUOM); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtQty_Passed); Response.Write("</b></td>");
					Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtQty_Rejected); Response.Write("</b></td>");
					Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wRate); Response.Write("</b></td>");
					Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(wtQty - wtQty_Passed); Response.Write("</b></td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wBook); Response.Write("</td>");
					Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wSet); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wIc_Dt); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(wIE); Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("</table>");
				}
				else
				{
					Response.Write("<br><br><br><H3 align='center'><font face='Verdana' color='red'>Case Not Registered</font>");
				}
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
		void bill_details_case_wise()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string mySql = "Select T13.CASE_NO,V23.ITEM_SRNO,REPLACE(REPLACE(V23.ITEM_DESC, chr(10),''), chr(13), '') ITEM,V23.QTY,T04.UOM_S_DESC,T20.BILL_NO,T20.BK_NO,T20.SET_NO,T20.IC_NO,to_char(T20.IC_DT,'dd/mm/yyyy') IC_DATE,T09.IE_SNAME,T13.PO_NO, TO_CHAR(T13.PO_DT, 'DD/MM/YYYY')PO_DATE,  V23.RATE, V23.BASIC_VALUE, V23.SALES_TAX_PER,V23.SALES_TAX, V23.VALUE, V22.INSP_FEE, NVL(V22.CGST,0)+NVL(V22.SGST,0)+NVL(V22.IGST,0) GST, V22.BILL_AMOUNT, REPLACE(REPLACE(V05.VENDOR, chr(10),''), chr(13), '') VENDOR, REPLACE(REPLACE(M05.VENDOR, chr(10),''), chr(13), '') MANUF " +
				"From T20_IC T20,T09_IE T09,T22_BILL V22, T23_BILL_ITEMS V23, T17_CALL_REGISTER T17, V05_VENDOR V05,V05_VENDOR M05, T13_PO_MASTER T13, T04_UOM T04 " +
				"Where T20.BILL_NO=V22.BILL_NO AND V22.BILL_NO=V23.BILL_NO AND T20.CASE_NO=T17.CASE_NO AND T20.CALL_RECV_DT=T17.CALL_RECV_DT AND T20.CALL_SNO=T17.CALL_SNO AND T17.MFG_CD=M05.VEND_CD and T20.IE_CD=T09.IE_CD AND V22.CASE_NO=T13.CASE_NO AND T13.CASE_NO=T17.CASE_NO AND T13.VEND_CD=V05.VEND_CD AND V23.UOM_CD=T04.UOM_CD" +
				//"   and T20.CASE_NO=T18.CASE_NO and T20.CALL_RECV_DT=T18.CALL_RECV_DT and T20.CALL_SNO=T18.CALL_SNO and T20.CONSIGNEE_CD=T18.CONSIGNEE_CD and T20.IE_CD=T09.IE_CD "+
				"   and T20.CASE_NO='" + txtCaseNo.Text + "' and substr(T20.CASE_NO,1,1)='" + Session["Region"].ToString() + "' " +
				"Order by V22.CASE_NO,V22.BILL_NO,V23.ITEM_SRNO";

			string wpSno = "", wpBNO = "";
			//decimal wQty=0,wQty_Passed=0,wQty_Rejected=0;
			//decimal wtQty=0,wtQty_Passed=0,wtQty_Rejected=0,wRate=0;
			//int wpConsignee_Cd=0,wpItem_Srno=0;
			//int wConsignee_Cd=0,wItem_Srno=0;
			int ctr = 60;
			int wSno = 1;
			try
			{
				OracleCommand cmd = new OracleCommand(mySql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows == true)
				{
					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr><td width='100%' colspan='23'>");
					Response.Write("<H5 align='center'><font face='Verdana'>Billing for Case No. - " + txtCaseNo.Text + " (" + wRegion + ")</font><br></p>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
					Response.Write("<th width='16%' valign='top'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>PO No.</font></b></th>");
					Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>PO Date</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>IC No.</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>IC Date</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Book No.</font></b></th>");
					Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Set No.</font></b></th>");
					Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
					Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill Amount</font></b></th>");
					Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Vendor</font></b></th>");
					Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>Manufacturer</font></b></th>");
					Response.Write("<th width='16%' valign='top'><b><font size='1' face='Verdana'>Item Srno</font></b></th>");
					Response.Write("<th width='21%' valign='top'><b><font size='1' face='Verdana'>Item Description</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Qty</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>UOM</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Unit Cost</font></b></th>");
					Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Basic Value</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Taxes</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Material Value</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>Insp Fee</font></b></th>");
					Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>GST</font></b></th>");

					Response.Write("</tr></font>");
					while (reader.Read())
					{
						if (wpBNO == reader["BILL_NO"].ToString())
						{
							Response.Write("<tr>");
							Response.Write("<td width='4%' valign='top' align='center' colspan=13> <font size='1' face='Verdana'></td>");
							Response.Write("<td width='16%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_SRNO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='21%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY"].ToString()); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["UOM_S_DESC"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["RATE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BASIC_VALUE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["SALES_TAX"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["VALUE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["INSP_FEE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["GST"].ToString()); Response.Write("</td>");
							Response.Write("</tr>");
							ctr = ctr + 1;




						}
						else
						{


							Response.Write("<tr>");
							Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
							Response.Write("<td width='16%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='21%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(reader["PO_DATE"].ToString()); Response.Write("</b></td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IC_NO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(reader["IC_DATE"].ToString()); Response.Write("</b></td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(reader["IE_SNAME"].ToString()); Response.Write("</b></td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(reader["BK_NO"].ToString()); Response.Write("</b></td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(reader["SET_NO"].ToString()); Response.Write("</b></td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(reader["BILL_NO"].ToString()); Response.Write("</b></td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'><b>"); Response.Write(reader["BILL_AMOUNT"].ToString()); Response.Write("</b></td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"].ToString()); Response.Write("</td>");
							Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["MANUF"].ToString()); Response.Write("</td>");
							Response.Write("<td width='16%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_SRNO"].ToString()); Response.Write("</td>");
							Response.Write("<td width='21%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["QTY"].ToString()); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["UOM_S_DESC"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["RATE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BASIC_VALUE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["SALES_TAX"].ToString()); Response.Write("</td>");
							Response.Write("<td width='7%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["VALUE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["INSP_FEE"].ToString()); Response.Write("</td>");
							Response.Write("<td width='4%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["GST"].ToString()); Response.Write("</td>");
							Response.Write("</tr>");
							wpBNO = reader["BILL_NO"].ToString();
							wSno = wSno + 1;

						}
					};

					Response.Write("</table>");
				}
				else
				{
					Response.Write("<br><br><br><H3 align='center'><font face='Verdana' color='red'>Case Not Registered</font>");
				}
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

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = false;
			Panel_2.Visible = false;
			wRegion = "";
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }
			if (Convert.ToString(Request.Params["ACTION"].Trim()) == "UIQ")
			{
				UnInspectedQty();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CH")
			{
				case_history(txtCaseNo.Text.Trim());
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "CWS")
			{
				bill_details_case_wise();
			}
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

	}
}