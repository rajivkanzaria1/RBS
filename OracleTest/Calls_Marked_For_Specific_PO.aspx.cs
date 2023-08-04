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

namespace RBS.Calls_Marked_For_Specific_PO
{
	public  partial class Calls_Marked_For_Specific_PO : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string wVendor;
		string wSortHdr;
		int wCallCtr;
		private string wColour;
		protected System.Web.UI.WebControls.HyperLink HyperLink2;
		string PNO, PDT, RLYCD, CLT;
		string wFrmDt, wToDt;
		public static string Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			btnSearch.Attributes.Add("OnClick", "JavaScript:validate2();");
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate3();");

			Action = Convert.ToString(Request.Params["ACTION"].Trim());
			if (Convert.ToString(Request.Params["PO_NO"]) == null || Convert.ToString(Request.Params["PO_DT"]) == null)
			{
				PNO = "";
				PDT = "";
				Panel_1.Visible = true;

			}
			else
			{
				PNO = Convert.ToString(Request.Params["PO_NO"].Trim());
				PDT = Convert.ToString(Request.Params["PO_DT"].Trim());
				RLYCD = Convert.ToString(Request.Params["RLY_CD"].Trim());
				CLT = Convert.ToString(Request.Params["RLY_NONRLY"].Trim());
				//				wToDt=Convert.ToString(Request.Params ["TO"].Trim());
				//				wFrmDt=Convert.ToString(Request.Params ["FROM"].Trim());


			}
			if (!(IsPostBack))
			{

				ListItem lst = new ListItem();
				lst.Text = "";
				lst.Value = "";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Railways";
				lst.Value = "R";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Private";
				lst.Value = "P";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "PSU";
				lst.Value = "U";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "State Govt.";
				lst.Value = "S";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Foreign Railways";
				lst.Value = "F";
				lstClientType.Items.Add(lst);
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					DataSet ds = new DataSet();
					string sql = "select CALL_STATUS_CD,CALL_STATUS_DESC from T21_CALL_STATUS_CODES order by CALL_STATUS_DESC";
					OracleDataAdapter dad = new OracleDataAdapter(sql, conn1);
					OracleCommand myOracleCmd = new OracleCommand(sql, conn1);
					conn1.Open();
					dad.SelectCommand = myOracleCmd;
					conn1.Close();
					dad.Fill(ds, "Table");
					lstCallStatus.DataValueField = "CALL_STATUS_CD";
					lstCallStatus.DataTextField = "CALL_STATUS_DESC";
					lstCallStatus.DataSource = ds;
					lstCallStatus.DataBind();
					lstCallStatus.Items.Insert(0, "All");
					lstCallStatus.SelectedValue = "All";
				}
				catch (Exception ex)
				{
					string str1;
					str1 = ex.Message;
					string str2 = str1.Replace("\n", "");
					Response.Redirect(("Error_Form.aspx?err=" + str2));
				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}
				if (Action == "C")
				{
					Label1.Text = "CALL DETAILS FOR SPECIFIC PO";
					Label4.Text = "* For Call Details of Specific PO, Select Client Type, Client & Enter PO Date and then Click on Search PO's. Button, then click on Select Hyperlink of the desired PO No.";
					Label3.Visible = false;
					btnSearch.Visible = true;
					btnSubmit.Visible = false;

				}
				else if (Action == "X")
				{
					Label1.Text = "CLIENT WISE CALL STATUS";
					Label4.Text = "* For Call Details of Specific Client, Select Client Type, Client & Enter From & To Date & Select Call Status and then Click on Submit Button.";
					Label3.Visible = false;
					btnSearch.Visible = false;
					btnSubmit.Visible = true;

				}
				else
				{
					Label1.Text = "IC DETAILS FOR SPECIFIC PO";
					Label4.Text = "* For IC Details of Specific PO, Select Client Type, Client & Enter PO Date and then Click on Search PO's. Button, then click on Select Hyperlink of the desired PO No.";
					Label3.Visible = true;
					btnSearch.Visible = true;
					btnSubmit.Visible = false;
				}
				if (Convert.ToString(Request.Params["PO_NO"]) == null || Convert.ToString(Request.Params["PO_DT"]) == null)
				{
					PNO = "";
					PDT = "";
					Panel_1.Visible = true;

				}
				else
				{
					txtPODT.Text = PDT;
					lstClientType.SelectedValue = Convert.ToString(Request.Params["RLY_NONRLY"].Trim());
					fill_Rly();
					lstBPO_Rly.SelectedValue = RLYCD;
					Panel_1.Visible = false;
					if (Session["Uname"].ToString() != "")
					{
						if (Action == "C")
						{
							call_details();
						}
						else
						{
							inspection_details();

						}
					}
					else
					{
						DisplayAlert("Kindly Login into the IBS to view this report.");
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

		protected void lstClientType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_Rly();
		}

		public void fill_Rly()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstBPO_Rly.Items.Clear();
			DataSet dsP = new DataSet();
			string str = "";
			if (lstClientType.SelectedValue == "R")
			{
				str = "Select RLY_CD,RAILWAY ORGN from T91_RAILWAYS where RLY_CD<>'CORE' Order by RLY_CD";
			}
			else
			{
				str = "Select distinct(upper(trim(BPO_RLY))) RLY_CD, BPO_ORGN ORGN from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='" + lstClientType.SelectedValue + "' Order by RLY_CD";
			}
			try
			{
				OracleDataAdapter da = new OracleDataAdapter(str, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str, conn1);
				ListItem lst;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				conn1.Close();
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["ORGN"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
					lstBPO_Rly.Items.Add(lst);
				}

			}
			catch (Exception ex)
			{
				string str1;
				str1 = ex.Message;
				string str2 = str1.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str2));
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

		private void Submit_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = false;
			call_details();
		}
		void call_details()
		{
			wCallCtr = 0;
			if (PNO == "")
			{
				PNO = PNO;
				PDT = txtPODT.Text;
				CLT = lstClientType.SelectedValue;
				RLYCD = lstBPO_Rly.SelectedValue;

			}

			string sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD," +
				"(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE,T18.ITEM_DESC_PO,T18.QTY_TO_INSP,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT," +
				"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,T17.REMARKS REMARK, " +
				"trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')','')||' Dt: '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'B',' (Accepted on Dt:'||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy')||')','R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'G',' Dt: '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'C',' on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,T21.CALL_STATUS_COLOR COLOUR," +
				"T052.VEND_CONTACT_PER_1 MFG_PERS,(T052.VEND_CONTACT_TEL_1) MFG_PHONE,T17.CALL_SNO,T17.HOLOGRAM,T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO IC_PHOTO, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A1' IC_PHOTO_A1, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A2' IC_PHOTO_A2," +
				"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT, nvl2(T08.CO_PHONE_NO,trim(T08.CO_NAME)||' (Mob: '||CO_PHONE_NO||')',T08.CO_NAME)CO_NAME " +
				"From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052, T03_CITY T03, T03_CITY T032, T08_IE_CONTROLL_OFFICER T08,T21_CALL_STATUS_CODES T21 " +
				"Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and " +
				"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and " +
				"(trim(upper(T13.L5NO_PO))='" + PNO.Trim().ToUpper() + "' and TO_CHAR(T13.PO_DT,'dd/mm/yyyy')='" + PDT + "' and T13.RLY_NONRLY='" + CLT + "' and T13.RLY_CD='" + RLYCD + "') and " +
				"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) and  " +
				"T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and T08.CO_CD(+)=T09.IE_CO_CD ";
			sql = sql + "Order by T17.CALL_MARK_DT DESC,T051.VEND_NAME";
			wSortHdr = "Report Sorted on Call Date (Descending)";


			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse' bordercolor='#111111' width='130%'>");
				Response.Write("<tr>"); Response.Write("<td width='100%' bgcolor='#FFFFCC' colspan='199'>");
				Response.Write("<p align='center'><font face='Verdana' color='#3333FF'><b>");
				//Response.Write("<font size='4'>CALLS  DETAILS FOR SPECIFIC PO FOR THE PERIOD "+wFrmDt+" TO "+wToDt+"  </b></font><br>");
				Response.Write("<font size='4'>CALLS DETAILS FOR SPECIFIC PO </b></font><br>");
				Response.Write("<font size='2'>" + wSortHdr + "</font></p>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr bgcolor='#FFCCCC'>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>SNO</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>VENDOR NAME</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>PURCHASER</font></b></th>");
				Response.Write("<th width='13%' valign='top'><b><font size='1' face='Verdana'>ITEM</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CALL DATE</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>ENGINEER DEPUTED</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>ENGINEER CONTACT NO.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>PONO</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>PO DATE</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CASE NO</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>STATUS</font></b></th>");
				Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>HOLOGRAM OR OTHER</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>VIEW IC <font color=red>*</font></font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CONTACT PERSON</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CONTACT PERSON PHONE NO.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CALL SERIAL NO.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CONTROLLING MANAGER</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>REMARKS</font></b></th></tr>");
				Response.Write("</tr></font>");
				while (reader.Read())
				{
					wCallCtr = wCallCtr + 1;
					wVendor = "";
					Response.Write("<tr>");
					Response.Write("<td width='4%' valign='top'> <font size='1' face='Verdana'>" + wCallCtr); Response.Write("</td>");
					if (Convert.ToInt32(reader["VEND_CD"]) == Convert.ToInt64(reader["MFG_CD"]))
					{ wVendor = Convert.ToString(reader["VENDOR"]); }
					else
					{ wVendor = Convert.ToString(reader["VENDOR"]) + " <font color='#FF00CC'>At<font color='#3333FF'> " + Convert.ToString(reader["MANUFACTURER"]); }
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>" + wVendor); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
					if (Convert.ToInt16(reader["COUNT"]) > 1)
					{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"] + "<font color='#FF00CC'> Qty. </font><font color='#3333FF'>" + reader["QTY_TO_INSP"] + "</font><font color='#FF00CC'> and more items as per call"); Response.Write("</td>"); }
					else
					{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"] + "<font color='#FF00CC'> Qty. </font><font color='#3333FF'>" + reader["QTY_TO_INSP"] + "</font>"); Response.Write("</td>"); }
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_MARK_DT"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_PHONE_NO"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					wColour = "'" + Convert.ToString(reader["COLOUR"]) + "'";
					Response.Write("<td width='5%' valign='top'> <font size='1' face='Verdana' color=" + wColour + ">"); Response.Write(reader["CALL_STATUS"]); Response.Write("</font></td>");

					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["HOLOGRAM"]); Response.Write("</td>");
					string fpath_jpg = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString() + ".JPG");
					string fpath_pdf = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString() + ".PDF");
					if (File.Exists(fpath_jpg) == false && File.Exists(fpath_pdf) == false)
					{
						Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					}
					else
					{
						if (File.Exists(fpath_jpg) == true)
						{
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString() + ".JPG' Font-Names='Verdana' Font-Size='8pt'>IC</a>");
						}
						else if (File.Exists(fpath_pdf) == true)
						{
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='8pt'>IC</a>");
						}

						string fpath3_jpg = Server.MapPath("/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString() + ".JPG");
						string fpath3_pdf = Server.MapPath("/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString() + ".PDF");

						if (File.Exists(fpath3_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString() + ".JPG'>Testplan/Lab Test Reports</a>");
						}
						else if (File.Exists(fpath3_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString() + ".PDF'>Testplan/Lab Test Reports</a>");
						}

						string fpath1_jpg = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString() + ".JPG");
						string fpath1_pdf = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString() + ".PDF");
						string fpath2_jpg = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString() + ".JPG");
						string fpath2_pdf = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString() + ".PDF");
						if (File.Exists(fpath1_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString() + ".JPG'>IC Annex 1</a>");
						}
						else if (File.Exists(fpath1_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString() + ".PDF'>IC Annex 1</a>");
						}

						if (File.Exists(fpath2_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString() + ".JPG'>IC Annex 2</a>");
						}
						else if (File.Exists(fpath2_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString() + ".PDF'>IC Annex 2</a>");
						}


						Response.Write("</td>");
					}

					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_PERS"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_PHONE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["REMARK"]); Response.Write("</td>");
					Response.Write("</tr>");
				};
				Response.Write("</table>");
				Response.Write("<p align='center'><font face='Verdana'><a href='javascript:history.go(-1);'>Go Back </a><font></p>");
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		void inspection_details()
		{

			string wBillNo = "";
			int recCount = 0;
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			string str = "";
			str = "select T06.CONSIGNEE_FIRM||'/'||T06.CONSIGNEE_DESIG||'/'||T06.CONSIGNEE_DEPT PURCHASER,T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DT,T20.IC_NO, to_char(T20.IC_DT,'dd/mm/yyyy')IC_DATE, T20.BK_NO, T20.SET_NO,T20.BILL_NO,T09.IE_NAME, T05.VEND_NAME VENDOR,T18.ITEM_DESC_PO, T18.QTY_TO_INSP, T18.QTY_PASSED,T18.QTY_REJECTED, T17.HOLOGRAM, T49.IC_PHOTO, T49.IC_PHOTO_A1, T49.IC_PHOTO_A2 from T13_PO_MASTER T13, T06_CONSIGNEE T06, T20_IC T20, T18_CALL_DETAILS T18,T09_IE T09, T05_VENDOR T05, T17_CALL_REGISTER T17, T49_IC_PHOTO_ENCLOSED T49 where T13.PURCHASER_CD=T06.CONSIGNEE_CD and T13.VEND_CD=T05.VEND_CD and T13.CASE_NO=T20.CASE_NO and T20.CASE_NO=T18.CASE_NO and T20.CALL_RECV_DT=T18.CALL_RECV_DT AND T20.CALL_SNO=T18.CALL_SNO and T20.CONSIGNEE_CD=T18.CONSIGNEE_CD and T18.CASE_NO=T17.CASE_NO AND T18.CALL_RECV_DT=T17.CALL_RECV_DT AND T18.CALL_SNO=T17.CALL_SNO AND T17.CASE_NO=T49.CASE_NO(+) AND T17.CALL_RECV_DT=T49.CALL_RECV_DT(+) AND T17.CALL_SNO=T49.CALL_SNO(+) and T20.IE_CD=T09.IE_CD ";
			str = str + " and (trim(upper(T13.L5NO_PO))='" + PNO.Trim().ToUpper() + "' and TO_CHAR(T13.PO_DT,'dd/mm/yyyy')='" + PDT + "' and T13.RLY_NONRLY='" + CLT + "' and T13.RLY_CD='" + RLYCD + "') ";
			str = str + " order by T20.IC_DT,T18.ITEM_SRNO_PO";
			OracleCommand cmd6 = new OracleCommand(str, conn1);
			conn1.Open();
			OracleDataReader reader = cmd6.ExecuteReader();



			Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
			Response.Write("<tr>");
			Response.Write("<tr>"); Response.Write("<td width='100%' bgcolor='#FFFFCC' colspan='15'>");
			Response.Write("<p align='center'><font face='Verdana' color='#3333FF'><b>");
			Response.Write("<font size='4'>IC DETAILS FOR SPECIFIC PO </b></font><br>");
			Response.Write("<font size='2' color=red>(* IC Issued after 1st March 2013 by Northern Region can also be viewed by Clicking VIEW IC hyperlink in last column)</font>");
			Response.Write("</td>");
			Response.Write("</tr>");
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>S.NO.</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>VENDOR</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>PURCHASER</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>PO NO.</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>PO DT.</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IC NO.</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>IC DT.</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>BK NO.</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>SET NO.</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>IE</font></b></th>");
			Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>ITEM DESCRITION</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>QTY OFF</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>QTY PASS/REJ</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>HOLOGRAM OR OTHER</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>VIEW IC <font color=red>*</font></font></b></th>");


			Response.Write("</tr></font>");
			while (reader.Read())
			{



				if (wBillNo == reader["BILL_NO"].ToString())
				{
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='Center'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("<td width='20%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["ITEM_DESC_PO"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='right'><b><font size='1' face='Verdana'>" + reader["QTY_TO_INSP"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='right'><b><font size='1' face='Verdana'>" + reader["QTY_PASSED"].ToString() + "/" + reader["QTY_REJECTED"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='right'><b><font size='1' face='Verdana'>" + reader["HOLOGRAM"].ToString() + "</font></b></td>");
					string fpath = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString());
					if (File.Exists(fpath) == false)
					{
						Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					}
					else
					{
						Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString() + "' Font-Names='Verdana' Font-Size='8pt'>IC</a>");
						string fpath1 = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString());
						string fpath2 = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString());
						string fpath3 = Server.MapPath("/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString());
						if (File.Exists(fpath3) == true)
						{
							Response.Write("<br><a href='/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString() + "'>Testplan/Lab Test Reports</a>");
						}
						if (File.Exists(fpath1) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString() + "'>IC Annex 1</a>");
						}

						if (File.Exists(fpath2) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString() + "'>IC Annex 2</a>");
						}


						Response.Write("</td>");

					}
					//Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					Response.Write("</tr>");
				}
				else
				{
					recCount = recCount + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='Center'><b><font size='1' face='Verdana'>" + recCount + "</font></b></td>");
					Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["VENDOR"].ToString() + "</font></b></td>");
					Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["PURCHASER"].ToString() + " </font></b></td>");
					Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["PO_NO"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["PO_DT"].ToString() + "</font></b></td>");
					Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["IC_NO"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["IC_DATE"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["BK_NO"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["SET_NO"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["IE_NAME"].ToString() + "</font></b></td>");
					Response.Write("<td width='20%' valign='top' align='left'><b><font size='1' face='Verdana'>" + reader["ITEM_DESC_PO"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='right'><b><font size='1' face='Verdana'>" + reader["QTY_TO_INSP"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='right'><b><font size='1' face='Verdana'>" + reader["QTY_PASSED"].ToString() + "/" + reader["QTY_REJECTED"].ToString() + "</font></b></td>");
					Response.Write("<td width='5%' valign='top' align='right'><b><font size='1' face='Verdana'>" + reader["HOLOGRAM"].ToString() + "</font></b></td>");
					string fpath = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString());
					if (File.Exists(fpath) == false)
					{
						Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					}
					else
					{
						Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString() + "' Font-Names='Verdana' Font-Size='8pt'>IC</a>");
						string fpath1 = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString());
						string fpath2 = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString());
						string fpath3 = Server.MapPath("/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString());

						if (File.Exists(fpath3) == true)
						{
							Response.Write("<br><a href='/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString() + "'>Testplan/Lab Test Reports</a>");
						}
						if (File.Exists(fpath1) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString() + "'>IC Annex 1</a>");
						}

						if (File.Exists(fpath2) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString() + "'>IC Annex 2</a>");
						}


						Response.Write("</td>");
					}

					Response.Write("</tr>");
					wBillNo = reader["BILL_NO"].ToString();
				}

			};

			Response.Write("</table>");
			conn1.Close();

			wCallCtr = 0;
			if (PNO == "")
			{
				PNO = PNO;
				PDT = txtPODT.Text;
				CLT = lstClientType.SelectedValue;
				RLYCD = lstBPO_Rly.SelectedValue;

			}

			string sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD," +
				"(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE,T18.ITEM_DESC_PO,T18.QTY_TO_INSP,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT," +
				"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,T17.REMARKS REMARK, " +
				"trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')','')||' Dt: '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'B',' (Accepted on Dt:'||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy')||')','R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'G',' Dt: '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'C',' on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,T21.CALL_STATUS_COLOR COLOUR," +
				"T052.VEND_CONTACT_PER_1 MFG_PERS,(T052.VEND_CONTACT_TEL_1) MFG_PHONE,T17.CALL_SNO,T17.HOLOGRAM,T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO IC_PHOTO, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A1' IC_PHOTO_A1, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A2' IC_PHOTO_A2, " +
				"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT, nvl2(T08.CO_PHONE_NO,trim(T08.CO_NAME)||' (Mob: '||CO_PHONE_NO||')',T08.CO_NAME)CO_NAME " +
				"From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052, T03_CITY T03, T03_CITY T032, T08_IE_CONTROLL_OFFICER T08,T21_CALL_STATUS_CODES T21 " +
				"Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and " +
				"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and " +
				"(trim(upper(T13.L5NO_PO))='" + PNO.Trim().ToUpper() + "' and TO_CHAR(T13.PO_DT,'dd/mm/yyyy')='" + PDT + "' and T13.RLY_NONRLY='" + CLT + "' and T13.RLY_CD='" + RLYCD + "') and T17.CALL_STATUS NOT IN ('M','B') and (sysdate-T17.CALL_RECV_DT)<90 and " +
				"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) and  " +
				"T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and T08.CO_CD(+)=T09.IE_CO_CD ";
			sql = sql + "Order by T17.CALL_MARK_DT DESC,T051.VEND_NAME";
			wSortHdr = "Report Sorted on Call Date (Descending)";



			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn1);
				conn1.Open();
				OracleDataReader reader1 = cmd.ExecuteReader();
				Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse' bordercolor='#111111' width='130%'>");
				Response.Write("<tr>"); Response.Write("<td width='100%' bgcolor='#FFFFCC' colspan='19'>");
				Response.Write("<p align='center'><font face='Verdana' color='#3333FF'><b>");
				//Response.Write("<font size='4'>CALLS  DETAILS FOR SPECIFIC PO FOR THE PERIOD "+wFrmDt+" TO "+wToDt+"  </b></font><br>");
				Response.Write("<font size='4'>CALLS DETAILS FOR SPECIFIC PO WHERE IC IS NOT ENTERED INTO THE SYSTEM </b></font><br>");
				Response.Write("<font size='2'>" + wSortHdr + "</font></p>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr bgcolor='#FFCCCC'>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>SNO</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>VENDOR NAME</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>PURCHASER</font></b></th>");
				Response.Write("<th width='13%' valign='top'><b><font size='1' face='Verdana'>ITEM</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CALL DATE</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>ENGINEER DEPUTED</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>ENGINEER CONTACT NO.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>PONO</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>PO DATE</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CASE NO</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>STATUS</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>HOLOGRAM OR OTHER</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>VIEW IC</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CONTACT PERSON</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CONTACT PERSON PHONE NO.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CALL SERIAL NO.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CONTROLLING MANAGER</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>REMARKS</font></b></th></tr>");
				Response.Write("</tr></font>");
				while (reader1.Read())
				{
					wCallCtr = wCallCtr + 1;
					wVendor = "";
					Response.Write("<tr>");
					Response.Write("<td width='4%' valign='top'> <font size='1' face='Verdana'>" + wCallCtr); Response.Write("</td>");
					if (Convert.ToInt32(reader1["VEND_CD"]) == Convert.ToInt64(reader1["MFG_CD"]))
					{ wVendor = Convert.ToString(reader1["VENDOR"]); }
					else
					{ wVendor = Convert.ToString(reader1["VENDOR"]) + " <font color='#FF00CC'>At<font color='#3333FF'> " + Convert.ToString(reader1["MANUFACTURER"]); }
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>" + wVendor); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["CONSIGNEE"]); Response.Write("</td>");
					if (Convert.ToInt16(reader1["COUNT"]) > 1)
					{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["ITEM_DESC_PO"] + "<font color='#FF00CC'> Qty. </font><font color='#3333FF'>" + reader1["QTY_TO_INSP"] + "</font><font color='#FF00CC'> and more items as per call"); Response.Write("</td>"); }
					else
					{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["ITEM_DESC_PO"] + "<font color='#FF00CC'> Qty. </font><font color='#3333FF'>" + reader1["QTY_TO_INSP"] + "</font>"); Response.Write("</td>"); }
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["CALL_MARK_DT"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["IE_PHONE_NO"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["PO_NO"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["PO_DATE"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["CASE_NO"]); Response.Write("</td>");
					wColour = "'" + Convert.ToString(reader1["COLOUR"]) + "'";
					Response.Write("<td width='5%' valign='top'> <font size='1' face='Verdana' color=" + wColour + ">"); Response.Write(reader1["CALL_STATUS"]); Response.Write("</font></td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["HOLOGRAM"]); Response.Write("</td>");
					string fpath_jpg = Server.MapPath("/RBS/BILL_IC/" + reader1["IC_PHOTO"].ToString() + ".JPG");
					string fpath_pdf = Server.MapPath("/RBS/BILL_IC/" + reader1["IC_PHOTO"].ToString() + ".PDF");
					if (File.Exists(fpath_jpg) == false && File.Exists(fpath_pdf) == false)
					{
						Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					}
					else
					{
						if (File.Exists(fpath_jpg) == true)
						{
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader1["IC_PHOTO"].ToString() + ".JPG' Font-Names='Verdana' Font-Size='8pt'>IC</a>");
						}
						else if (File.Exists(fpath_pdf) == true)
						{
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader1["IC_PHOTO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='8pt'>IC</a>");
						}
						string fpath3_jpg = Server.MapPath("/RBS/TESTPLAN/" + reader1["IC_PHOTO"].ToString() + ".JPG");
						string fpath3_pdf = Server.MapPath("/RBS/TESTPLAN/" + reader1["IC_PHOTO"].ToString() + ".PDF");

						if (File.Exists(fpath3_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/TESTPLAN/" + reader1["IC_PHOTO"].ToString() + ".JPG'>Testplan/Lab Test Reports</a>");
						}
						else if (File.Exists(fpath3_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/TESTPLAN/" + reader1["IC_PHOTO"].ToString() + ".PDF'>Testplan/Lab Test Reports</a>");
						}

						string fpath1_jpg = Server.MapPath("/RBS/BILL_IC/" + reader1["IC_PHOTO_A1"].ToString() + ".JPG");
						string fpath1_pdf = Server.MapPath("/RBS/BILL_IC/" + reader1["IC_PHOTO_A1"].ToString() + ".PDF");
						string fpath2_jpg = Server.MapPath("/RBS/BILL_IC/" + reader1["IC_PHOTO_A2"].ToString() + ".JPG");
						string fpath2_pdf = Server.MapPath("/RBS/BILL_IC/" + reader1["IC_PHOTO_A2"].ToString() + ".PDF");
						if (File.Exists(fpath1_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader1["IC_PHOTO_A1"].ToString() + ".JPG'>IC Annex 1</a>");
						}
						else if (File.Exists(fpath1_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader1["IC_PHOTO_A1"].ToString() + ".PDF'>IC Annex 1</a>");
						}

						if (File.Exists(fpath2_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader1["IC_PHOTO_A2"].ToString() + ".JPG'>IC Annex 2</a>");
						}
						else if (File.Exists(fpath2_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader1["IC_PHOTO_A2"].ToString() + ".PDF'>IC Annex 2</a>");
						}


						Response.Write("</td>");
					}


					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["MFG_PERS"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader1["MFG_PHONE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader1["CALL_SNO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["CO_NAME"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader1["REMARK"]); Response.Write("</td>");
					Response.Write("</tr>");
				};
				Response.Write("</table>");

			}
			catch (Exception ex)
			{
				string str2;
				str2 = ex.Message;
				string str1 = str2.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
			Response.Write("<p align='center'><font face='Verdana'><a href='javascript:history.go(-1);'>Go Back </a><font></p>");
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				//				wToDt=txtDtTo.Text.Trim();
				//				wFrmDt=txtDtFr.Text.Trim();
				string str1 = "select L5NO_PO,PO_NO,to_char(PO_DT,'dd/mm/yyyy')PO_DT,RLY_NONRLY,RLY_CD from T13_PO_MASTER T13, T17_CALL_REGISTER T17 where T13.CASE_NO=T17.CASE_NO and RLY_NONRLY='" + lstClientType.SelectedValue + "' and RLY_CD='" + lstBPO_Rly.SelectedValue + "' and TO_CHAR(PO_DT,'dd/mm/yyyy')='" + txtPODT.Text.Trim() + "'";

				//				if(txtPONO.Text.Trim()!="")
				//				{
				//					str1= str1 + " and trim(upper(L5NO_PO))='"+txtPONO.Text.Trim().ToUpper()+"' ";
				//				}
				str1 = str1 + " group by L5NO_PO,PO_NO,PO_DT,RLY_NONRLY,RLY_CD ORDER BY PO_DT";

				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				//OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1); 
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgPONO.Visible = false;
					DisplayAlert("No Record Found!!!");

				}
				else
				{
					DgPONO.DataSource = dsP1;
					DgPONO.DataBind();
					DgPONO.Visible = true;
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
		void call_details_client_wise()
		{
			Panel_1.Visible = false;
			wToDt = toDt.Text.Trim();
			wFrmDt = frmDt.Text.Trim();
			CLT = lstClientType.SelectedValue;
			RLYCD = lstBPO_Rly.SelectedValue;
			string sql = "";
			if (lstCallStatus.SelectedValue == "All")
			{
				sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD," +
					"(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE,T18.ITEM_DESC_PO,T18.QTY_TO_INSP,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT," +
					"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,T17.REMARKS REMARK, " +
					"trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')','')||' Dt: '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'B',' (Accepted on Dt:'||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy')||')','R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'G',' Dt: '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'C',' on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,T21.CALL_STATUS_COLOR COLOUR," +
					"T052.VEND_CONTACT_PER_1 MFG_PERS,(T052.VEND_CONTACT_TEL_1) MFG_PHONE,T17.CALL_SNO,T17.HOLOGRAM,T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO IC_PHOTO, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A1' IC_PHOTO_A1, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A2' IC_PHOTO_A2," +
					"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT, nvl2(T08.CO_PHONE_NO,trim(T08.CO_NAME)||' (Mob: '||CO_PHONE_NO||')',T08.CO_NAME)CO_NAME " +
					"From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052, T03_CITY T03, T03_CITY T032, T08_IE_CONTROLL_OFFICER T08,T21_CALL_STATUS_CODES T21 " +
					"Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and " +
					"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and " +
					"(T17.CALL_RECV_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy'))  and T13.RLY_NONRLY='" + CLT + "' and T13.RLY_CD='" + RLYCD + "' and " +
					"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) and  " +
					"T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and T08.CO_CD(+)=T09.IE_CO_CD ";


			}
			else
			{

				sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD," +
				  "(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE,T18.ITEM_DESC_PO,T18.QTY_TO_INSP,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT," +
				  "T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,T17.REMARKS REMARK, " +
				  "trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')','')||' Dt: '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'B',' (Accepted on Dt:'||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy')||')','R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'G',' Dt: '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'),'C',' on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,T21.CALL_STATUS_COLOR COLOUR," +
				  "T052.VEND_CONTACT_PER_1 MFG_PERS,(T052.VEND_CONTACT_TEL_1) MFG_PHONE,T17.CALL_SNO,T17.HOLOGRAM,T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO IC_PHOTO, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A1' IC_PHOTO_A1, T17.CASE_NO||'-'||T17.BK_NO||'-'||T17.SET_NO||'-A2' IC_PHOTO_A2," +
				  "(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT, nvl2(T08.CO_PHONE_NO,trim(T08.CO_NAME)||' (Mob: '||CO_PHONE_NO||')',T08.CO_NAME)CO_NAME " +
				  "From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052, T03_CITY T03, T03_CITY T032, T08_IE_CONTROLL_OFFICER T08,T21_CALL_STATUS_CODES T21 " +
				  "Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and " +
				  "T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and " +
				  "(T17.CALL_RECV_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and T17.CALL_STATUS='" + lstCallStatus.SelectedValue + "' and T13.RLY_NONRLY='" + CLT + "' and T13.RLY_CD='" + RLYCD + "' and " +
				  "T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) and  " +
				  "T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and T08.CO_CD(+)=T09.IE_CO_CD ";
			}
			sql = sql + "Order by T051.VEND_NAME,T17.CALL_MARK_DT DESC";
			wSortHdr = "Report Sorted on Vendor Name, Call Date (Descending)";


			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse' bordercolor='#111111' width='130%'>");
				Response.Write("<tr>"); Response.Write("<td width='100%' bgcolor='#FFFFCC' colspan='19'>");
				Response.Write("<p align='center'><font face='Verdana' color='#3333FF'><b>");
				//Response.Write("<font size='4'>CALLS  DETAILS FOR SPECIFIC PO FOR THE PERIOD "+wFrmDt+" TO "+wToDt+"  </b></font><br>");
				Response.Write("<font size='4'>CALLS DETAILS FOR SPECIFIC CLIENT FOR THE PERIOD " + wFrmDt + " TO " + wToDt + " </b></font><br>");
				Response.Write("<font size='2'>" + wSortHdr + "</font></p>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr bgcolor='#FFCCCC'>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>SNO</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>VENDOR NAME</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>PURCHASER</font></b></th>");
				Response.Write("<th width='13%' valign='top'><b><font size='1' face='Verdana'>ITEM</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CALL DATE</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>ENGINEER DEPUTED</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>ENGINEER CONTACT NO.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>PONO</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>PO DATE</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CASE NO</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>STATUS</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>HOLOGRAM OR OTHER</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>VIEW IC</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CONTACT PERSON</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CONTACT PERSON PHONE NO.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CALL SERIAL NO.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CONTROLLING MANAGER</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>REMARKS</font></b></th></tr>");
				Response.Write("</tr></font>");
				while (reader.Read())
				{
					wCallCtr = wCallCtr + 1;
					wVendor = "";
					Response.Write("<tr>");
					Response.Write("<td width='4%' valign='top'> <font size='1' face='Verdana'>" + wCallCtr); Response.Write("</td>");
					if (Convert.ToInt32(reader["VEND_CD"]) == Convert.ToInt64(reader["MFG_CD"]))
					{ wVendor = Convert.ToString(reader["VENDOR"]); }
					else
					{ wVendor = Convert.ToString(reader["VENDOR"]) + " <font color='#FF00CC'>At<font color='#3333FF'> " + Convert.ToString(reader["MANUFACTURER"]); }
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>" + wVendor); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
					if (Convert.ToInt16(reader["COUNT"]) > 1)
					{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"] + "<font color='#FF00CC'> Qty. </font><font color='#3333FF'>" + reader["QTY_TO_INSP"] + "</font><font color='#FF00CC'> and more items as per call"); Response.Write("</td>"); }
					else
					{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"] + "<font color='#FF00CC'> Qty. </font><font color='#3333FF'>" + reader["QTY_TO_INSP"] + "</font>"); Response.Write("</td>"); }
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_MARK_DT"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_PHONE_NO"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					wColour = "'" + Convert.ToString(reader["COLOUR"]) + "'";
					Response.Write("<td width='5%' valign='top'> <font size='1' face='Verdana' color=" + wColour + ">"); Response.Write(reader["CALL_STATUS"]); Response.Write("</font></td>");

					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["HOLOGRAM"]); Response.Write("</td>");
					string fpath_jpg = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString() + ".JPG");
					string fpath_pdf = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString() + ".PDF");
					if (File.Exists(fpath_jpg) == false && File.Exists(fpath_pdf) == false)
					{
						Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'> </font></b></td>");
					}
					else
					{
						if (File.Exists(fpath_jpg) == true)
						{
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString() + ".JPG' Font-Names='Verdana' Font-Size='8pt'>IC</a>");
						}
						else if (File.Exists(fpath_pdf) == true)
						{
							Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/BILL_IC/" + reader["IC_PHOTO"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='8pt'>IC</a>");
						}

						string fpath3_jpg = Server.MapPath("/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString() + ".JPG");
						string fpath3_pdf = Server.MapPath("/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString() + ".PDF");

						if (File.Exists(fpath3_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString() + ".JPG'>Testplan/Lab Test Reports</a>");
						}
						else if (File.Exists(fpath3_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/TESTPLAN/" + reader["IC_PHOTO"].ToString() + ".PDF'>Testplan/Lab Test Reports</a>");
						}

						string fpath1_jpg = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString() + ".JPG");
						string fpath1_pdf = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString() + ".PDF");
						string fpath2_jpg = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString() + ".JPG");
						string fpath2_pdf = Server.MapPath("/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString() + ".PDF");
						if (File.Exists(fpath1_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString() + ".JPG'>IC Annex 1</a>");
						}
						else if (File.Exists(fpath1_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A1"].ToString() + ".PDF'>IC Annex 1</a>");
						}

						if (File.Exists(fpath2_jpg) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString() + ".JPG'>IC Annex 2</a>");
						}
						else if (File.Exists(fpath2_pdf) == true)
						{
							Response.Write("<br><a href='/RBS/BILL_IC/" + reader["IC_PHOTO_A2"].ToString() + ".PDF'>IC Annex 2</a>");
						}


						Response.Write("</td>");
					}

					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_PERS"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_PHONE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["REMARK"]); Response.Write("</td>");
					Response.Write("</tr>");
				};
				Response.Write("</table>");
				Response.Write("<p align='center'><font face='Verdana'><a href='javascript:history.go(-1);'>Go Back </a><font></p>");
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
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			//call_details_client_wise();
		}


	}
}