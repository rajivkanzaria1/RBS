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

namespace RBS.Client_MA_LIST
{
	public partial class Client_MA_LIST : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string CNo, PoNo, PoDt;
		string MaNo, MaDt, MaStu, Ma_Cdt, MaSno;
		int ecode = 0;
		string CASE_NO_PO_MA;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnNewMA.Attributes.Add("OnClick", "JavaScript:validate();");
			Btn_sema.Attributes.Add("OnClick", "JavaScript:validate();");
			btnModifyPO.Attributes.Add("OnClick", "JavaScript:validate1();");

			if (!(IsPostBack))
			{

				if (Convert.ToString(Request.Params["case_no"]) == null)
				{
					CNo = "";
					MaNo = "";
					MaDt = "";
					MaStu = "";
				}
				else
				{
					CNo = Convert.ToString(Request.Params["case_no"].Trim());
					txtCsNo.Text = Convert.ToString(Request.Params["case_no"].Trim());
					MaNo = Convert.ToString(Request.Params["MA_NO"].Trim());
					Text_MAN.Text = Convert.ToString(Request.Params["MA_NO"].Trim());
					MaDt = Convert.ToString(Request.Params["MA_DT"].Trim());
					Text_MADT.Text = Convert.ToString(Request.Params["MA_DT"].Trim());
					Ma_Cdt = dateconcate(Text_MADT.Text);
					MaStu = Convert.ToString(Request.Params["MA_STATUS"].Trim());
					Label_Stu.Text = Convert.ToString(Request.Params["MA_STATUS"].Trim());
					MaSno = Convert.ToString(Request.Params["MA_SNO"].Trim());
					Label_Sno.Text = Convert.ToString(Request.Params["MA_SNO"].Trim());

					if (Label_Stu.Text == "Return")
					{
						btnNewMA.Visible = false;
						btnModifyPO.Visible = false;
						btnDeletePO.Visible = true;
					}
					else if (Label_Stu.Text == "Pending")
					{
						btnNewMA.Visible = false;
						btnModifyPO.Visible = true;
						btnDeletePO.Visible = false;
					}
					else
					{
						btnNewMA.Visible = true;
						btnModifyPO.Visible = false;
						btnDeletePO.Visible = false;
						DisplayAlert("Already Aprroved!!!");

					}

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

		}
		#endregion


		private void DgPO1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string fpath = Server.MapPath("/RBS/");
			string fpath1 = Server.MapPath("/RBS/");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				fpath = fpath + Convert.ToString(e.Item.Cells[8].Text);
				fpath1 = fpath1 + Convert.ToString(e.Item.Cells[9].Text);
				if (File.Exists(fpath) == false && File.Exists(fpath1) == false)
				{
					e.Item.Cells[8].Text = "<Font Face=Verdana Color=RED>No DOC</Font>";
					DgPO1.Columns[9].Visible = false;
				}
				else if (File.Exists(fpath) == true)
				{
					e.Item.Cells[8].Text = "<a href=" + Convert.ToString(e.Item.Cells[8].Text) + ">Download PO</a>";
					DgPO1.Columns[9].Visible = false;
				}
				else if (File.Exists(fpath1) == true)
				{
					e.Item.Cells[9].Text = "<a href=" + Convert.ToString(e.Item.Cells[9].Text) + ">Download PO</a>";
					DgPO1.Columns[8].Visible = false;
				}
			}
		}



		protected void btnDeletePO_Click(object sender, System.EventArgs e)
		{
			string madt1 = dateconcate(Text_MADT.Text);
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string check_vend = "Select PO_SRC from VEND_PO_MA_MASTER where case_no='" + txtCsNo.Text.Trim() + "' and MA_NO='" + Text_MAN.Text.Trim() + "' and to_char(MA_DT,'dd/mm/yyyy')='" + Text_MADT.Text.Trim() + "'";
			OracleDataAdapter da2 = new OracleDataAdapter(check_vend, conn1);
			DataSet dsP2 = new DataSet();
			OracleCommand myOracleCommand2 = new OracleCommand(check_vend, conn1);
			conn1.Open();
			da2.SelectCommand = myOracleCommand2;
			da2.Fill(dsP2, "Table");
			conn1.Close();

			if (dsP2.Tables[0].Rows[0][0].ToString() == "C")
			{
				string i = match();
				if (i == "2")
				{
					Response.Redirect("CLIENT_MA_FORM.aspx?Action=E&CaseNo=" + txtCsNo.Text.Trim() + "&MaNo=" + Text_MAN.Text.Trim() + "&MaDt=" + madt1 + "&MaStu=" + Label_Stu.Text.Trim() + "&MaSno=" + Label_Sno.Text.Trim());
				}
			}
			else
			{
				DisplayAlert("You Are Not Authorised to Add amendment for this case no!!!");
			}


		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		public string match()
		{
			OracleCommand cmd = new OracleCommand("select RLY_CD from T13_PO_MASTER where CASE_NO='" + txtCsNo.Text.Trim() + "' and RLY_NONRLY='" + Session["ORGN_TYPE"].ToString() + "' and RLY_CD='" + Session["ORGN"].ToString() + "'", conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			if (test == "\0")
			{
				test = "0";
				DisplayAlert("ENTERED CASE NUMBER DOES NOT MATCH!!!");
			}
			else if (test == Session["ORGN"].ToString())
			{
				test = "2";
			}
			else
			{
				test = "1";
				DisplayAlert("You Are Not Authorised to Update/Delete Purchase Order of Other Clients!!!");
			}
			conn1.Close();
			return test;
		}

		protected void Btn_sema_Click(object sender, System.EventArgs e)
		{

			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select m.CASE_NO CASE_NO,m.PO_NO PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,m.MA_NO MA_NO,to_char(m.MA_DT,'dd/mm/yyyy')MA_DT,m.RLY_NONRLY RLY_NONRLY,(decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU')||'('||m.RLY_CD||')')RLY_CD,(decode(m.PO_OR_LETTER,'P','PO','L','Letter')) PO_OR_LETTER,d.MA_SNO MA_SNO,d.MA_FIELD MA_FIELD,(decode(d.MA_STATUS,'P','Pending','A','Approved','R','Return','N','Approved With No Change')) MA_STATUS,PO_SRC S_RCE from VEND_PO_MA_MASTER m,VEND_PO_MA_DETAIL d,T13_PO_MASTER t13 where t13.rly_cd='" + Session["ORGN"].ToString() + "' and t13.case_no=m.Case_no and m.Case_no=d.Case_no and m.ma_no= d.ma_no and m.ma_dt=d.ma_dt";

				if (txtCsNo.Text.Trim() != "")
				{
					str1 = str1 + " and trim(m.CASE_NO)='" + txtCsNo.Text.Trim() + "'";
				}
				if (txtPONo.Text.Trim() != "")
				{
					str1 = str1 + " and upper(trim(m.PO_NO)) LIKE upper(trim('%" + txtPONo.Text.Trim() + "%'))";
				}
				if (txtPODate.Text != "")
				{
					str1 = str1 + " and TO_CHAR(m.PO_DT,'dd/mm/yyyy')='" + txtPODate.Text.Trim() + "'";
				}
				if (Text_MAN.Text.Trim() != "")
				{
					str1 = str1 + " and upper(trim(m.MA_NO)) LIKE upper(trim('%" + Text_MAN.Text.Trim() + "%'))";
				}
				if (Text_MADT.Text != "")
				{
					str1 = str1 + " and TO_CHAR(m.MA_DT,'dd/mm/yyyy')='" + Text_MADT.Text.Trim() + "'";
				}
				str1 = str1 + " ORDER BY MA_NO ASC";
				//string str2=str1 + " ORDER BY IMMS_RLY_CD, IMMS_POKEY";

				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				//OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1); 
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgPO1.Visible = false;
					//repdiv.Visible=false;
					//Label6.Visible =true;
					//						throw new System.Exception("No PurchaseOrder found. !!! ");
					//lblError.Visible=true;
					DgPO1.Visible = false;
					DisplayAlert("No Ammendment Added in this Case No!!!");
					btnNewMA.Visible = true;
					btnModifyPO.Visible = false;

				}
				else
				{
					DgPO1.DataSource = dsP1;
					DgPO1.DataBind();
					DgPO1.Visible = true;
					btnNewMA.Visible = false;
					btnModifyPO.Visible = true;
					//lblError.Visible=false;
					//repdiv.Visible=true;
					//Label6.Visible =false;
				}
				conn1.Close();
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
				conn1.Close();
				conn1.Dispose();
			}
		}




		protected void btnNewMA_Click_1(object sender, System.EventArgs e)
		{

			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'D') from dual", conn1);
			int ssd = Convert.ToInt16(cmd2.ExecuteScalar());
			conn1.Close();
			if (ssd == 1 || ssd == 6 || ssd == 7)
			{
				DisplayAlert("Ammendment Should be saved between Monday to Thursday!!!");
			}
			else
			{
				//				string check_vend="Select Vend_cd from t13_po_master where case_no='"+txtCsNo.Text.Trim()+"'";
				//				OracleDataAdapter da2 = new OracleDataAdapter(check_vend,conn1);
				//				DataSet dsP2 = new DataSet();
				//				OracleCommand myOracleCommand2 = new OracleCommand(check_vend,conn1); 
				//				conn1.Open(); 
				//				da2.SelectCommand = myOracleCommand2; 
				//				da2.Fill(dsP2, "Table"); 
				//				conn1.Close();
				//				if(dsP2.Tables[0].Rows[0][0].ToString() ==Session["VEND_CD"].ToString())
				//				{
				string i = match();
				if (i == "2")
				{
					Response.Redirect("CLIENT_MA_FORM.aspx?Action=N&CaseNo=" + txtCsNo.Text.Trim());
				}
				//				}
				//				else
				//				{
				//					DisplayAlert("You Are Not Authorised to Add amendment for this case no!!!");
				//				}
			}
		}
		protected void btnModifyPO_Click(object sender, System.EventArgs e)
		{

			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string check_vend1 = "Select PO_SRC from VEND_PO_MA_MASTER where case_no='" + txtCsNo.Text.Trim() + "' and MA_NO=" + Text_MAN.Text.Trim() + " and to_char(MA_DT,'dd/mm/yyyy')='" + Text_MADT.Text.Trim() + "'";
			OracleDataAdapter da21 = new OracleDataAdapter(check_vend1, conn1);
			DataSet dsP21 = new DataSet();
			OracleCommand myOracleCommand21 = new OracleCommand(check_vend1, conn1);
			conn1.Open();
			da21.SelectCommand = myOracleCommand21;
			da21.Fill(dsP21, "Table");
			conn1.Close();
			string madt = dateconcate(Text_MADT.Text);
			if (dsP21.Tables[0].Rows[0][0].ToString() == "C")
			{
				string i = match();
				if (i == "2")
				{
					Response.Redirect("CLIENT_MA_FORM.aspx?Action=E&CaseNo=" + txtCsNo.Text.Trim() + "&MaNo=" + Text_MAN.Text.Trim() + "&MaDt=" + madt + "&MaStu=" + Label_Stu.Text.Trim() + "&MaSno=" + Label_Sno.Text.Trim());
				}
			}
			else
			{
				DisplayAlert("You Are Not Authorised to Add amendment for this case no!!!");
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
		void case_history(string CSNO)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string mySql = "select T13.CASE_NO,T05.VEND_CD, T05.VEND_NAME||','||T03.CITY VENDOR,T05.VEND_REMARKS, T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DATE,T13.PO_SOURCE,to_char(T13.PO_DT,'yyyy') PO_YR, T91.IMMS_RLY_CD, T13.RLY_CD,T13.REMARKS from T13_PO_MASTER T13, T05_VENDOR T05, T03_CITY T03, T91_RAILWAYS T91 " +
				"WHERE T13.VEND_CD=T05.VEND_CD AND T05.VEND_CITY_CD= T03.CITY_CD AND T13.RLY_CD=T91.RLY_CD(+) " +
				"AND T13.CASE_NO='" + CSNO + "'";
			try
			{
				string vend_remarks = "", po_remarks = "", po_no = "", rly_cd = "", po_yr = "", po_source = "";
				int vend_cd = 0;
				OracleCommand cmd = new OracleCommand(mySql, conn1);
				conn1.Open();
				OracleDataReader reader11 = cmd.ExecuteReader();
				if (reader11.HasRows == true)
				{
					while (reader11.Read())
					{
						Response.Write("<br><table border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr><td width='100%'>");
						Response.Write("<H5 align='center'><font face='Verdana'>History for Case No. - " + txtCsNo.Text + " </font><br></p>");
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
						po_yr = reader11["PO_YR"].ToString();
						rly_cd = reader11["IMMS_RLY_CD"].ToString();
						po_source = reader11["PO_SOURCE"].ToString();

					}

				}
				conn1.Close();

				string mySql11 = "Select t15.CASE_NO,t15.ITEM_SRNO,t15.ITEM_DESC,t15.QTY,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') DELV_DATE,sum(nvl(t18.QTY_PASSED,0)) passed,sum(nvl(t18.QTY_REJECTED,0)) rejected From T15_PO_DETAIL t15,T18_CALL_DETAILS t18 Where t15.CASE_NO=t18.CASE_NO(+) and t15.ITEM_SRNO=t18.ITEM_SRNO_PO(+) and t15.case_no='" + CSNO + "' group by t15.CASE_NO,t15.ITEM_SRNO,t15.ITEM_DESC,t15.qty,to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') order by t15.CASE_NO,t15.ITEM_SRNO";
				OracleCommand cmd11 = new OracleCommand(mySql11, conn1);
				conn1.Open();
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
					conn1.Close();



					Response.Write("<tr><td width='100%' colspan=2 align='center' valign='center'>");
					if (po_source == "C")
					{
						Response.Write("<a href='https://www.ireps.gov.in/ireps/etender/pdfdocs/MMIS/PO/" + po_yr + "/" + rly_cd + "/" + po_no + ".pdf' Font-Names='Verdana' Font-Size='8pt'><H5 align='center'><font face='Verdana'>VIEW PO</font></a>");

						string mySqlMA = "select C.MAKEY,C.SLNO, TO_CHAR(B.MAKEY_DATE,'DD/MM/YYYY')MAKEY_DT,MA_FLD_DESCR,OLD_VALUE, NEW_VALUE, RITES_CASE_NO,A.IMMS_RLY_CD, A.IMMS_POKEY,B.MA_NO, TO_CHAR(B.MA_DATE,'DD/MM/YYYY') MA_DT, DECODE(MA_STATUS,'A','Approved','N','Approved With No Change in IBS','Pending') MA_STATUS FROM IMMS_RITES_PO_HDR A, MMP_POMA_HDR B, MMP_POMA_DTL C WHERE A.IMMS_RLY_CD=B.RLY AND A.IMMS_POKEY=B.POKEY AND B.RLY=C.RLY AND B.MAKEY=C.MAKEY and RITES_CASE_NO='" + CSNO + "' ORDER BY C.SLNO";

						OracleCommand cmdMA = new OracleCommand(mySqlMA, conn1);
						conn1.Open();
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
						conn1.Close();


					}
					else
					{
						string fpath = Server.MapPath("/RBS/CASE_NO/" + txtCsNo.Text.Trim() + ".TIF");
						string fpath1 = Server.MapPath("/RBS/CASE_NO/" + txtCsNo.Text.Trim() + ".PDF");
						if (File.Exists(fpath) == true)
						{
							//Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/"+txtCaseNo.Text.Trim()+".TIF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'><H5 align='center'><font face='Verdana'>VIEW PO</font></font></a>");Response.Write("</td>");
							Response.Write("<a href='/RBS/CASE_NO/" + txtCsNo.Text.Trim() + ".TIF' Font-Names='Verdana' Font-Size='8pt'><H5 align='center'><font face='Verdana'>VIEW PO</font></a>");
						}
						else if (File.Exists(fpath1) == true)
						{
							//Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CASE_NO/"+txtCaseNo.Text.Trim()+".PDF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'><H5 align='center'><font face='Verdana'>VIEW PO</font></font></a>");Response.Write("</td>");
							Response.Write("<a href='/RBS/CASE_NO/" + txtCsNo.Text.Trim() + ".PDF' Font-Names='Verdana' Font-Size='8pt'><H5 align='center'><font face='Verdana'>VIEW PO</font></a>");
						}
						else
						{

							Response.Write(" ");
						}

					}



					string mySqlMA_Vend = "select M.CASE_NO, M.MA_NO, TO_CHAR(M.MA_DT,'DD/MM/YYYY')MA_DT,MA_SNO,MA_FIELD,MA_DESC,OLD_PO_VALUE, NEW_PO_VALUE, DECODE(MA_STATUS,'A','Approved','N','Approved With No Change in IBS','Pending') MA_STATUS FROM VEND_PO_MA_MASTER M, VEND_PO_MA_DETAIL D WHERE M.CASE_NO=D.CASE_NO AND M.MA_NO=D.MA_NO AND M.MA_DT=D.MA_DT AND M.CASE_NO='" + CSNO + "' and MA_STATUS IN ('A','N') ORDER BY D.MA_SNO";

					OracleCommand cmdMA_Vend = new OracleCommand(mySqlMA_Vend, conn1);
					conn1.Open();
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
					conn1.Close();


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
					OracleCommand cmd1 = new OracleCommand(mySql1, conn1);
					conn1.Open();
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
				conn1.Close();
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

				OracleCommand cmd2 = new OracleCommand(mySql2, conn1);
				conn1.Open();
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
				conn1.Close();
				string mySql3 = "select T20.BILL_NO, to_char(T20.IC_DT,'dd/mm/yyyy') IC_DATE,T20.BK_NO,T20.SET_NO,T20.REASON_REJECT,T09.IE_NAME,V05.Vendor,T18.ITEM_DESC_PO from T13_PO_MASTER T13, T20_IC T20, T09_IE T09,V05_VENDOR V05, T18_CALL_DETAILS T18 where T13.CASE_NO=T20.CASE_NO and T13.VEND_CD=V05.VEND_CD and T20.IE_CD=T09.IE_CD and T20.CASE_NO=T18.CASE_NO and T20.CALL_RECV_DT=T18.CALL_RECV_DT and T20.CALL_SNO=T18.CALL_SNO and T20.CONSIGNEE_CD=T18.CONSIGNEE_CD  and T20.IC_TYPE_ID=2 and T13.VEND_CD=" + vend_cd + " and T13.CASE_NO<>'" + txtCsNo.Text.Trim() + "' order by T20.IC_DT,T20.BILL_NO";

				OracleCommand cmd3 = new OracleCommand(mySql3, conn1);
				conn1.Open();
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
					conn1.Close();
				}
				Response.Write("</table>");
				Response.Write("<p align='center'><font face='Verdana'><a href='javascript:history.go(-1);'>Go Back </a><font></p>");
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
				conn1.Close();
				conn1.Dispose();
			}


		}

		protected void btnCaseHistory_Click(object sender, System.EventArgs e)
		{
			string i = match();
			if (i == "2")
			{
				Panel_1.Visible = false;
				case_history(txtCsNo.Text);
			}


		}

	}
}