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

namespace RBS.Lab_Sample_Info_Details
{
	public partial class Lab_Sample_Info_Details : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string L_cno = "", L_csno = "", L_dt = "", L_dtc = "", Action = "";
		protected System.Web.UI.WebControls.Label Label_file;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Convert.ToString(Request.QueryString["CaseNo"]) == null || Convert.ToString(Request.QueryString["CaseNo"]) == "" || Convert.ToString(Request.QueryString["SNo"]) == null || Convert.ToString(Request.QueryString["SNo"]) == "" || Convert.ToString(Request.QueryString["CR_Dt"]) == null || Convert.ToString(Request.QueryString["CR_Dt"]) == "")
				{
					DisplayAlert("ENTERED DETAILS NOT Found!!!");
				}
				else
				{
					L_cno = Request.QueryString["CaseNo"].ToString();
					lblCaseNo.Text = L_cno;
					L_csno = Request.QueryString["SNo"].ToString();
					lblCSNO.Text = L_csno;
					L_dt = Request.QueryString["CR_Dt"].ToString();
					L_dtc = dateconcate1(L_dt);
					lblCallDT.Text = L_dtc;
					Action = Request.QueryString["Action"].ToString();

					if (Action == "N")
					{
						search();
						Btnupd.Visible = false;
						btnSave.Visible = true;
					}
					if (Action == "E")
					{
						search_exist();
						Btnupd.Visible = true;
						btnSave.Visible = false;
						Show_File();
					}

					payment_details();
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


		string dateconcate1(string dt)
		{
			string myYear, myMonth, myDay;

			myYear = dt.Substring(0, 4);
			myMonth = dt.Substring(4, 2);
			myDay = dt.Substring(6, 2);
			string dt2 = myDay + '/' + myMonth + '/' + myYear;
			return (dt2);
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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (lstStatus.SelectedValue == "U" && File2.Value == "")
				{
					DisplayAlert("Reciept Can not be left blank!!!");
				}
				else
				{
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					OracleTransaction myTrans = conn1.BeginTransaction();

					string Clientquery = "INSERT INTO t109_lab_sample_info(CASE_NO,CALL_RECV_DT,CALL_SNO,IE_CD,STATUS,SAMPLE_RECV_DT,TESTING_CHARGES,LIKELY_DT_REPORT,REMARKS,USER_ID,DATETIME) " +
						"VALUES('" + lblCaseNo.Text.Trim() + "',to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy'),'" + lblCSNO.Text.Trim() + "','" + lblIECD.Text.Trim() + "','" + lstStatus.SelectedValue + "',to_date('" + txtSampleReceiptDT.Text + "','dd/mm/yyyy')," + txtTestingFee.Text.Trim() + ",to_date('" + txtLikelyTRDt.Text + "','dd/mm/yyyy'),'" + txtRemarks.Text.Trim() + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand = new OracleCommand(Clientquery);
					myInsertCommand.Transaction = myTrans;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					myTrans.Commit();
					conn1.Close();
					DisplayAlert("Your Record is Saved!!!");
					upload_SAMPLE();
					//					fillgrid();
					btnSave.Visible = false;
					Btnupd.Visible = false;
				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
			}
		}

		public void search()
		{
			try
			{
				DataSet reader = new DataSet();
				string str1 = "select t09.ie_name ie_name, v05.vendor vendor, t13.vend_cd vend_cd,t09.ie_cd ie_cd  from t17_call_register t17, t13_po_master t13,v05_vendor v05, t09_IE t09 where t17.case_no= t13.case_no and t13.vend_cd= v05.vend_cd and t17.ie_cd= t09.ie_cd " +
							" and t17.case_no='" + lblCaseNo.Text.Trim() + "' and to_char(t17.call_recv_dt,'dd/mm/yyyy')='" + lblCallDT.Text.Trim() + "' and t17.call_sno='" + lblCSNO.Text.Trim() + "' and substr(t17.case_no,1,1)='" + Session["Region"] + "'";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand cmd = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = cmd;
				da.Fill(reader, "Table");
				conn1.Close();

				lblVend.Text = Convert.ToString(reader.Tables[0].Rows[0]["vendor"]);
				lblIE.Text = Convert.ToString(reader.Tables[0].Rows[0]["ie_name"]);
				lblIECD.Text = Convert.ToString(reader.Tables[0].Rows[0]["ie_cd"]);

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "There is no row at position 0.";
				if (str.Equals(str1))
				{
					str1 = "Their is no record present for the given Case No.";
				}
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
			}
		}

		public void search_exist()
		{
			try
			{
				DataSet reader_e = new DataSet();
				string str1_e = "select t09.ie_name ie_name, v05.vendor vendor, t109.ie_cd ie_cd, t109.status status,to_char(t109.sample_recv_dt,'dd/mm/yyyy') sample_recv_dt, NVL(t109.testing_charges,'0') testing_charges," +
					"to_char(t109.likely_dt_report,'dd/mm/yyyy') likely_dt_report, t109.remarks remarks, t109.deposit_slip_uploaded deposit_slip_uploaded, t109.fee_deposit_confirm fee_deposit_confirm,to_char(t109.lab_rep_uploaded_dt ,'dd/mm/yyyy') lab_rep_uploaded_dt " +
					"from t17_call_register t17, t13_po_master t13,v05_vendor v05, t09_IE t09, t109_lab_sample_info t109 where t17.case_no= t13.case_no and t13.vend_cd= v05.vend_cd and t17.ie_cd= t09.ie_cd " +
					"and t17.case_no= t109.case_no and t17.call_recv_dt= t109.call_recv_dt and t17.call_sno= t109.call_sno " +
					"and t17.case_no='" + lblCaseNo.Text.Trim() + "' and to_char(t17.call_recv_dt,'dd/mm/yyyy')='" + lblCallDT.Text.Trim() + "' and t17.call_sno=" + lblCSNO.Text.Trim() + " and substr(t17.case_no,1,1)='" + Session["Region"] + "'";
				OracleDataAdapter da_e = new OracleDataAdapter(str1_e, conn1);
				OracleCommand cmd_e = new OracleCommand(str1_e, conn1);
				conn1.Open();
				da_e.SelectCommand = cmd_e;
				da_e.Fill(reader_e, "Table");
				conn1.Close();

				lblVend.Text = Convert.ToString(reader_e.Tables[0].Rows[0]["vendor"]);
				lblIE.Text = Convert.ToString(reader_e.Tables[0].Rows[0]["ie_name"]);
				lblIECD.Text = Convert.ToString(reader_e.Tables[0].Rows[0]["ie_cd"]);
				txtSampleReceiptDT.Text = Convert.ToString(reader_e.Tables[0].Rows[0]["sample_recv_dt"]);
				txtTestingFee.Text = Convert.ToString(reader_e.Tables[0].Rows[0]["testing_charges"]);
				txtLikelyTRDt.Text = Convert.ToString(reader_e.Tables[0].Rows[0]["likely_dt_report"]);
				lstStatus.SelectedValue = Convert.ToString(reader_e.Tables[0].Rows[0]["status"]);
				txtRemarks.Text = Convert.ToString(reader_e.Tables[0].Rows[0]["remarks"]);
				if (lstStatus.SelectedValue == "U")
				{
					Label2.Visible = true;
					File2.Visible = true;
				}
				else
				{
					Label2.Visible = false;
					File2.Visible = false;
				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "There is no row at position 0.";
				if (str.Equals(str1))
				{
					str1 = "Their is no record present for the given Case No.";
				}
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
			}
		}

		void Show_File2()
		{
			string MyFile_ex;
			string mdt_ex = dateconcate(lblCallDT.Text.Trim());
			MyFile_ex = lblCaseNo.Text.Trim() + '_' + lblCSNO.Text.Trim() + '_' + mdt_ex;
			string fpath = Server.MapPath("/RBS/LAB/PReciept/" + MyFile_ex + ".PDF");
			if (File.Exists(fpath) == false)
			{
				//File2.Visible=true;
				Hyperlink2.Visible = false;
			}
			else
			{
				Hyperlink2.Visible = true;
				Hyperlink2.Text = MyFile_ex;
				Hyperlink2.NavigateUrl = "/RBS/LAB/PReciept/" + MyFile_ex + ".PDF";

			}

		}
		public void payment_details()
		{
			try
			{
				OracleCommand cmd1 = new OracleCommand("SELECT DECODE(DOC_STATUS_VEND,'Y','UPLOADED','NOT UPLOADED') FROM T110_LAB_DOC WHERE  case_no='" + lblCaseNo.Text.Trim() + "' and to_char(call_recv_dt,'dd/mm/yyyy')='" + lblCallDT.Text.Trim() + "' and call_sno=" + lblCSNO.Text.Trim() + "", conn1);
				conn1.Open();
				lblVendPaymentSlip.Text = Convert.ToString(cmd1.ExecuteScalar());

				if (lblVendPaymentSlip.Text != "")
				{
					Show_File2();

					OracleCommand cmd2 = new OracleCommand("SELECT DECODE(DOC_STATUS_FIN,'A','APPROVED'||' On: '||to_char(DOC_APP_DATETIME,'dd/mm/yyyy-HH24:MI:SS'),'R','REJECTED'||' On: '||to_char(DOC_APP_DATETIME,'dd/mm/yyyy-HH24:MI:SS')||DOC_REJ_REMARK,'PENDING') FROM T110_LAB_DOC WHERE  case_no='" + lblCaseNo.Text.Trim() + "' and to_char(call_recv_dt,'dd/mm/yyyy')='" + lblCallDT.Text.Trim() + "' and call_sno=" + lblCSNO.Text.Trim() + "", conn1);
					lblPaymentApp.Text = Convert.ToString(cmd2.ExecuteScalar());
				}
				else
				{
					lblVendPaymentSlip.Text = "Not Uploaded";
					lblPaymentApp.Text = "Not Approved";
				}
				conn1.Close();


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "There is no row at position 0.";
				if (str.Equals(str1))
				{
					str1 = "Their is no record present for the given Case No.";
				}
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
			}
		}

		protected void Btnupd_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (lstStatus.SelectedValue == "U" && File2.Value == "")
				{
					DisplayAlert("Reciept Can not be left blank!!!");
				}
				else
				{
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					OracleTransaction myTrans = conn1.BeginTransaction();

					string Clientquery = "update t109_lab_sample_info set STATUS='" + lstStatus.SelectedValue + "',SAMPLE_RECV_DT=to_date('" + txtSampleReceiptDT.Text + "','dd/mm/yyyy'),TESTING_CHARGES=" + txtTestingFee.Text.Trim() + ",LIKELY_DT_REPORT=to_date('" + txtLikelyTRDt.Text + "','dd/mm/yyyy'),REMARKS='" + txtRemarks.Text.Trim() + "',USER_ID='" + Session["Uname"].ToString() + "',DATETIME =to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') WHERE CASE_NO='" + lblCaseNo.Text + "' AND CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text;
					OracleCommand myInsertCommand = new OracleCommand(Clientquery);
					myInsertCommand.Transaction = myTrans;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					myTrans.Commit();
					conn1.Close();
					upload_SAMPLE();
					DisplayAlert("Your Record is Saved!!!");
					//					fillgrid();
					btnSave.Visible = false;
					Btnupd.Visible = false;
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
			}

		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		void upload_SAMPLE()
		{

			if (File2.PostedFile != null && File2.PostedFile.ContentLength > 0)
			{
				string fn = "", MyFile = "", fx = "", fl = "";
				string mdt = dateconcate(lblCallDT.Text.Trim());
				MyFile = lblCaseNo.Text.Trim() + '_' + lblCSNO.Text.Trim() + '_' + mdt;
				fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File2.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				if (fx == "PDF")
				{
					SaveLocation = Server.MapPath("LAB/" + MyFile + ".PDF");

				}
				else
				{
					DisplayAlert("Kindly Upload PDF File only");
				}

				try
				{
					File2.PostedFile.SaveAs(SaveLocation);
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					string LabRepUplquery = "update t109_lab_sample_info set LAB_REP_UPLOADED_DT=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),USER_ID='" + Session["Uname"].ToString() + "',DATETIME =to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') WHERE CASE_NO='" + lblCaseNo.Text + "' AND CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text;
					OracleCommand myUpdateCommand = new OracleCommand(LabRepUplquery, conn1);
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();

				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str1);
				}
				finally
				{
					conn1.Close();
				}
				DisplayAlert("SAMPLE REPORT UPLOADED!!!");
			}

		}

		protected void lstStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//			string Lab_Payment_Status="";
			//			conn1.Open();
			//			OracleCommand cmd2_1 =new OracleCommand("SELECT DOC_STATUS_FIN FROM T110_LAB_DOC WHERE  case_no='"+lblCaseNo.Text.Trim()+"' and to_char(call_recv_dt,'dd/mm/yyyy')='"+lblCallDT.Text.Trim()+"' and call_sno="+ lblCSNO.Text.Trim()+"",conn1);
			//			Lab_Payment_Status=Convert.ToString(cmd2_1.ExecuteScalar());
			//			conn1.Close();

			if (lstStatus.SelectedValue == "U")
			{
				Label2.Visible = true;
				File2.Visible = true;
			}
			else
			{
				Label2.Visible = false;
				File2.Visible = false;
			}
		}

		void Show_File()
		{
			//			string Lab_Payment_Status_F="";
			//			conn1.Open();
			//			OracleCommand cmd2_2 =new OracleCommand("SELECT DOC_STATUS_FIN FROM T110_LAB_DOC WHERE  case_no='"+lblCaseNo.Text.Trim()+"' and to_char(call_recv_dt,'dd/mm/yyyy')='"+lblCallDT.Text.Trim()+"' and call_sno="+ lblCSNO.Text.Trim()+"",conn1);
			//			Lab_Payment_Status_F=Convert.ToString(cmd2_2.ExecuteScalar());
			//			conn1.Close();

			if (lstStatus.SelectedValue == "U")
			{
				string MyFile_ex;
				string mdt_ex = dateconcate(lblCallDT.Text.Trim());
				MyFile_ex = lblCaseNo.Text.Trim() + '_' + lblCSNO.Text.Trim() + '_' + mdt_ex;
				string fpath = Server.MapPath("/RBS/LAB/" + MyFile_ex + ".PDF");
				if (File.Exists(fpath) == false)
				{
					File2.Visible = true;
					HyperLink1.Visible = false;
				}
				else
				{
					HyperLink1.Visible = true;
					HyperLink1.Text = MyFile_ex;
					HyperLink1.NavigateUrl = "/RBS/LAB/" + MyFile_ex + ".PDF";
					File2.Visible = false;
				}
			}
			else
			{
				Label2.Visible = false;
				File2.Visible = false;
			}

		}


	}
}