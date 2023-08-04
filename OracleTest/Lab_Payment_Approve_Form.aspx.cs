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

namespace RBS.Lab_Payment_Approve_Form
{
	public partial class Lab_Payment_Approve_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string case_no_ap, s_no, s_dtc, s_dt_change;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			AP_BT.Attributes.Add("OnClick", "JavaScript:validate1();");
			if (!IsPostBack)
			{

				if (Convert.ToString(Request.QueryString["CASE_NO"]) == null || Convert.ToString(Request.QueryString["CASE_NO"]) == "" || Convert.ToString(Request.QueryString["S_NO"]) == null || Convert.ToString(Request.QueryString["CALL_DTC"]) == null)
				{
					//DisplayAlert("ENTERED CASE NUMBER NOT Found!!!");
					case_no_ap = "";
					s_no = "";
					s_dtc = "";
					s_dt_change = "";

				}
				else
				{
					case_no_ap = Request.QueryString["CASE_NO"].ToString();
					lblCasNo.Text = case_no_ap;
					s_no = Request.QueryString["S_NO"].ToString();
					lblPNo.Text = s_no;
					s_dtc = Request.QueryString["CALL_DTC"].ToString();
					s_dt_change = dateconcate1(s_dtc);
					lblPDt.Text = s_dt_change;
					show();
					Show_File();
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		string dateconcate1(string dt)
		{
			string myYear, myMonth, myDay;

			myDay = dt.Substring(0, 2);
			myMonth = dt.Substring(2, 2);
			myYear = dt.Substring(4, 4);
			string dt2 = myDay + '/' + myMonth + '/' + myYear;
			return (dt2);
		}
		void Show_File()
		{
			string MyFile_ma;
			string mdt_ma = dateconcate(lblPDt.Text.Trim());
			MyFile_ma = lblCasNo.Text.Trim() + '_' + lblPNo.Text.Trim() + '_' + mdt_ma;

			string fpath = Server.MapPath("/RBS/LAB/PReciept/" + MyFile_ma + ".PDF");
			if (File.Exists(fpath) == false)
			{
				HyperLink1.Visible = false;
			}
			else
			{
				HyperLink1.Visible = true;
				HyperLink1.Text = MyFile_ma;
				HyperLink1.NavigateUrl = "/RBS/LAB/PReciept/" + MyFile_ma + ".PDF";
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

		void show()
		{
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				DataSet dsP = new DataSet();
				string str2 = "select NVL(t109.testing_charges,'') testing_charges_lab, t110.testing_charges testing_charges_vend,(t110.testing_charges+t110.TDS) TOTAL_CHARGES,t110.TDS,t110.UTR_NO, to_char(t110.UTR_DT,'DD/MM/YYYY') UTR_DATE," +
							"(decode(t110.doc_status_fin,'P','Pending')) doc_status_fin " +
							"from t110_lab_doc t110, t109_lab_sample_info t109 where t110.case_no= t109.case_no(+) and t110.call_recv_dt= t109.call_recv_dt(+) and t110.call_sno= t109.call_sno(+) and t110.doc_status_fin='P' and substr(t110.case_no,1,1)='" + Session["Region"] + "' and " +
							"t110.case_no='" + lblCasNo.Text + "' and to_char(t110.call_recv_dt,'dd/mm/yyyy')='" + lblPDt.Text + "' and t110.call_sno='" + lblPNo.Text + "'";
				OracleDataAdapter da = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str2, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{

					Lbl_lab.Text = dsP.Tables[0].Rows[0]["testing_charges_lab"].ToString();
					Lbl_vend.Text = Convert.ToString(dsP.Tables[0].Rows[0]["testing_charges_vend"]);
					lblTDS.Text = Convert.ToString(dsP.Tables[0].Rows[0]["TDS"]);
					lblUTRNo.Text = dsP.Tables[0].Rows[0]["UTR_NO"].ToString();
					lblUTRDt.Text = dsP.Tables[0].Rows[0]["UTR_DATE"].ToString();
					lblTotCharges.Text = Convert.ToString(dsP.Tables[0].Rows[0]["TOTAL_CHARGES"]);
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
			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (Txt_RE.Text == "")
				{
					DisplayAlert("Remarks Can not Left Blank!!!");
				}
				else if (DL_status.SelectedValue == "")
				{
					DisplayAlert("Status Can not Left Blank!!!");
				}
				else
				{
					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					conn1.Open();
					OracleCommand cmd21 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss1 = Convert.ToString(cmd21.ExecuteScalar());
					conn1.Close();
					OracleCommand cmd41 = new OracleCommand("update t110_lab_doc set DOC_STATUS_FIN='" + DL_status.SelectedValue + "',DOC_REJ_REMARK='" + Txt_RE.Text.Trim() + "',DOC_APP_BY ='" + Session["Uname"].ToString() + "',DOC_APP_DATETIME=to_date('" + ss1 + "','dd/mm/yyyy-HH24:MI:SS') where  CASE_NO='" + lblCasNo.Text + "' and CALL_SNO='" + lblPNo.Text + "' and to_char(CALL_RECV_DT,'dd/mm/yyyy')='" + lblPDt.Text.Trim() + "'", conn1);
					conn1.Open();
					cmd41.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("LAB Sample Payment has been rejected!!!");
					AP_BT.Visible = false;
					btnSave.Visible = false;
				}

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
			}

		}

		protected void AP_BT_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (DL_status.SelectedValue == "")
				{
					DisplayAlert("Status Can not Left Blank!!!");
				}
				else
				{
					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();
					OracleCommand cmd4 = new OracleCommand("update t110_lab_doc set DOC_STATUS_FIN='" + DL_status.SelectedValue + "',DOC_APP_BY ='" + Session["Uname"].ToString() + "',DOC_APP_DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where  CASE_NO='" + lblCasNo.Text + "' and CALL_SNO='" + lblPNo.Text + "' and to_char(CALL_RECV_DT,'dd/mm/yyyy')='" + lblPDt.Text.Trim() + "'", conn1);
					conn1.Open();
					cmd4.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("Lab Sample Reciept Has Been Approved!!!");
					AP_BT.Visible = false;
					btnSave.Visible = false;
				}

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
			}

		}

		protected void DL_status_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DL_status.SelectedValue == "R")
			{
				AP_BT.Visible = false;
				btnSave.Visible = true;
				Label_RE.Visible = true;
				Txt_RE.Visible = true;
			}
			else
			{
				AP_BT.Visible = true;
				btnSave.Visible = false;
				Label_RE.Visible = true;
				Txt_RE.Visible = true;

			}
		}
	}
}