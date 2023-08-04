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

namespace RBS.Lab_Register_Form
{
	public partial class Lab_Register_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string Action = "";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnUpdate.Attributes.Add("OnClick", "JavaScript:validate();");


			if (!(IsPostBack))
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					DataSet dsP1 = new DataSet();
					string str = "select TEST_CATEGORY_CD, TEST_CATEGORY_DESC from T64_TEST_CATEGORY ";
					OracleDataAdapter da = new OracleDataAdapter(str, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str, conn1);
					ListItem lst;
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP1, "Table");
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP1.Tables[0].Rows[i]["TEST_CATEGORY_DESC"].ToString();
						lst.Value = dsP1.Tables[0].Rows[i]["TEST_CATEGORY_CD"].ToString();
						lstCategory.Items.Add(lst);
					}
					conn1.Close();
					lstCategory.Items.Insert(0, "");

					lstLab.Items.Clear();
					DataSet dsP2 = new DataSet();
					string str2 = "select LAB_ID,LAB_NAME||','||T03.CITY LAB_NAME from T65_LABORATORY_MASTER T65,T03_CITY T03 where T65.LAB_CITY=T03.CITY_CD order by LAB_NAME";
					OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
					OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
					ListItem lst2;
					conn1.Open();
					da2.SelectCommand = myOracleCommand2;
					da2.Fill(dsP2, "Table");
					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
					{
						lst2 = new ListItem();
						lst2.Text = dsP2.Tables[0].Rows[i]["LAB_NAME"].ToString();
						lst2.Value = dsP2.Tables[0].Rows[i]["LAB_ID"].ToString();
						lstLab.Items.Add(lst2);
					}
					conn1.Close();
					lstLab.Items.Insert(0, "");
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
					lblRegDt.Text = Convert.ToString(cmd2.ExecuteScalar());
					txtRegDt.Text = Convert.ToString(cmd2.ExecuteScalar());
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
				if (Convert.ToString(Request.Params["CASE_NO"]) == null && Convert.ToString(Request.Params["SAMPLE_REG_NO"]) == null)
				{
					lblCaseNo.Text = "";
					lblCallDT.Text = "";
					btnSave.Visible = true;
					btnUpdate.Visible = false;
					Action = "";
					lblInvoiceNo.Visible = false;
					lblInvoiceDt.Visible = false;
					Label33.Visible = false;
					Label35.Visible = false;
					btnPrintInvoice.Visible = false;
				}
				else if (Convert.ToString(Request.Params["SAMPLE_REG_NO"]) != null)
				{
					lblRNo.Text = Convert.ToString(Request.Params["SAMPLE_REG_NO"].Trim());

					if (Convert.ToString(Request.Params["SNO"]) != null)
					{
						lblSNO.Text = Convert.ToString(Request.Params["SNO"].Trim());
						Action = Convert.ToString(Request.Params["Action"].Trim());
						show1();
						show2();
						//txtRegDt.Visible=false;
					}
					else
					{
						show1();
						show();
					}
					btnSave.Visible = false;
					btnUpdate.Visible = true;
					if (Convert.ToInt32(lblAmtRecieved.Text) < Convert.ToInt32(lblTotalLabCharges.Text))
					{
						fillgrid1();
						lblInvoiceNo.Visible = false;
						lblInvoiceDt.Visible = false;
						Label33.Visible = false;
						Label35.Visible = false;
						btnPrintInvoice.Visible = false;

					}
					else if (Convert.ToInt32(lblAmtRecieved.Text) == Convert.ToInt32(lblTotalLabCharges.Text))
					{
						int i = get_invoice();
						if (i == 1)
						{
							lblInvoiceNo.Visible = true;
							lblInvoiceDt.Visible = true;
							Label33.Visible = true;
							Label35.Visible = true;
							btnPrintInvoice.Text = "Print Invoice";
						}
						else if (i == 0)
						{
							lblInvoiceNo.Visible = false;
							lblInvoiceDt.Visible = false;
							Label33.Visible = false;
							Label35.Visible = false;
							btnPrintInvoice.Text = "Generate Invoice";


						}
						btnPrintInvoice.Visible = true;
					}
				}
				else
				{
					lblCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"].Trim());
					lblCallDT.Text = Convert.ToString(Request.Params["CALL_RECV_DT"].Trim());
					lblCSNO.Text = Convert.ToString(Request.Params["CALL_SNO"]);
					show();
					btnSave.Visible = true;
					btnUpdate.Visible = false;
					lblInvoiceNo.Visible = false;
					lblInvoiceDt.Visible = false;
					Label33.Visible = false;
					Label35.Visible = false;
					btnPrintInvoice.Visible = false;
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
		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string MySql = "Select T09.IE_CD, T09.IE_NAME,V05.VENDOR,V05.VEND_CD From T09_IE T09,T13_PO_MASTER T13,T17_CALL_REGISTER T17,V05_VENDOR V05 " +
				"Where T17.CASE_NO='" + lblCaseNo.Text + "' and T17.CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') and T17.CALL_SNO='" + lblCSNO.Text + "' " +
				"and T17.IE_CD=T09.IE_CD and T13.CASE_NO=T17.CASE_NO and T13.VEND_CD=V05.VEND_CD";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				OracleCommand cmd = new OracleCommand(MySql, conn1);
				conn1.Open();
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					lblIE.Text = MyReader["IE_NAME"].ToString();
					lblIECD.Text = MyReader["IE_CD"].ToString();
					lblVend.Text = MyReader["VENDOR"].ToString();
					lblVENDCD.Text = MyReader["VEND_CD"].ToString();
				}
				if (MyReader.HasRows)
				{
					fill_CallItems();
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
				conn1.Dispose();
			}
			//			fillgrid1();
		}


		int get_invoice()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string MySql = "Select INVOICE_NO, TO_CHAR(INVOICE_DT,'DD/MM/YYYY') INVOICE_DATE FROM T55_LAB_INVOICE" +
				" Where  SAMPLE_REG_NO='" + lblRNo.Text.Trim() + "' ";
			int ret_cd = 0;
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				OracleCommand cmd = new OracleCommand(MySql, conn1);
				conn1.Open();
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					lblInvoiceNo.Text = MyReader["INVOICE_NO"].ToString();
					lblInvoiceDt.Text = MyReader["INVOICE_DATE"].ToString();
					ret_cd = 1;
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
				conn1.Dispose();
			}

			return (ret_cd);
		}

		void show1()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string MySql = "Select SAMPLE_REG_NO,to_char(SAMPLE_REG_DT,'dd/mm/yyyy')SAMPLE_REG_DATE,to_char(SAMPLE_DRAWL_DT,'dd/mm/yyyy')SAMPLE_DRAWL_DATE,to_char(SAMPLE_RECIEPT_DT,'dd/mm/yyyy')SAMPLE_RECIEPT_DATE,to_char(SAMPLE_DISPATCH_DT,'dd/mm/yyyy')SAMPLE_DISPATCH_DATE,T09.IE_CD, T09.IE_NAME,V05.VENDOR,V05.VEND_CD,CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy')CALL_DT,CALL_SNO,NVL(TESTING_TYPE,'X') TESTING_TYPE, TOTAL_LAB_CHARGES,TOTAL_TESTING_FEE,TOTAL_SERVICE_TAX,TOTAL_HANDLING_CHARGES,NVL(TDS,0)TDS,NVL(AMOUNT_RECIEVED,0) AMOUNT_RECIEVED, CODE_NO,to_char(CODE_DT,'dd/mm/yyyy')CODE_DATE From T50_LAB_REGISTER T50, V05_VENDOR V05, T09_IE T09 " +
				"Where T50.SAMPLE_REG_NO='" + lblRNo.Text.Trim() + "' and T50.IE_CD=T09.IE_CD and T50.VEND_CD=V05.VEND_CD";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				OracleCommand cmd = new OracleCommand(MySql, conn1);
				conn1.Open();
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					lblIE.Text = MyReader["IE_NAME"].ToString();
					lblIECD.Text = MyReader["IE_CD"].ToString();
					lblVend.Text = MyReader["VENDOR"].ToString();
					lblVENDCD.Text = MyReader["VEND_CD"].ToString();
					lblRegDt.Text = MyReader["SAMPLE_REG_DATE"].ToString();
					lblSampleDispatchDT.Text = MyReader["SAMPLE_DISPATCH_DATE"].ToString();
					lblSampleDrawalDT.Text = MyReader["SAMPLE_DRAWL_DATE"].ToString();
					lblSampleReceiptDT.Text = MyReader["SAMPLE_RECIEPT_DATE"].ToString();
					lblCaseNo.Text = MyReader["CASE_NO"].ToString();
					lblCallDT.Text = MyReader["CALL_DT"].ToString();
					lblCSNO.Text = MyReader["CALL_SNO"].ToString();
					txtSampleDispatchDT.Visible = false;
					txtSampleDrawalDT.Visible = false;
					txtSampleReceiptDT.Visible = false;
					lblTotalTestingFee.Text = MyReader["TOTAL_TESTING_FEE"].ToString();
					lblTotalHandlingCharges.Text = MyReader["TOTAL_HANDLING_CHARGES"].ToString();
					lblTotalServiceTax.Text = MyReader["TOTAL_SERVICE_TAX"].ToString();
					lblTotalLabCharges.Text = MyReader["TOTAL_LAB_CHARGES"].ToString();
					lblAmtRecieved.Text = MyReader["AMOUNT_RECIEVED"].ToString();
					lblTDS.Text = MyReader["TDS"].ToString();
					lblTAmtCleared.Text = Convert.ToString(Convert.ToInt32(lblAmtRecieved.Text) + Convert.ToInt32(lblTDS.Text));

					if (MyReader["TESTING_TYPE"].ToString() == "X")
					{
						rdbNormal.Checked = true;
					}
					else if (MyReader["TESTING_TYPE"].ToString() == "R")
					{
						rdbReTesting.Checked = true;
					}
					txtCodeNo.Text = MyReader["CODE_NO"].ToString();
					txtCodeDt.Text = MyReader["CODE_DATE"].ToString();
					rdbNormal.Enabled = false;
					rdbReTesting.Enabled = false;
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
				conn1.Dispose();
			}
			fillgrid();
		}

		void show2()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string MySql = "Select SAMPLE_REG_NO,SNO,ITEM_DESC,QTY, TEST_CATEGORY_CD,TEST,LAB_ID,TESTING_FEE, SERVICE_TAX, HANDLING_CHARGES,to_char(TEST_REPORT_REQ_DT,'dd/mm/yyyy')TEST_REPORT_REQ_DATE,to_char(TEST_REPORT_REC_DT,'dd/mm/yyyy')TEST_REPORT_REC_DATE,TEST_STATUS,REMARKS,to_char(SAMPLE_DISPATCHED_TO_LAB_DT,'dd/mm/yyyy') SAMPLE_DISPATCH_LAB_DT From T51_LAB_REGISTER_DETAIL Where SAMPLE_REG_NO='" + lblRNo.Text.Trim() + "' and SNO=" + lblSNO.Text;
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				OracleCommand cmd = new OracleCommand(MySql, conn1);
				conn1.Open();
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					lblSNO.Text = MyReader["SNO"].ToString();
					txtItem.Text = MyReader["ITEM_DESC"].ToString();
					txtSample.Text = MyReader["QTY"].ToString();
					lstCategory.SelectedValue = MyReader["TEST_CATEGORY_CD"].ToString();
					txtTest.Text = MyReader["TEST"].ToString();
					lstLab.SelectedValue = MyReader["LAB_ID"].ToString();
					txtTestingFee.Text = MyReader["TESTING_FEE"].ToString();
					lblTestingFee.Text = MyReader["TESTING_FEE"].ToString();
					txtSTax.Text = MyReader["SERVICE_TAX"].ToString();
					lblServiceTax.Text = MyReader["SERVICE_TAX"].ToString();
					txtHCharge.Text = MyReader["HANDLING_CHARGES"].ToString();
					lblHandlingCharges.Text = MyReader["HANDLING_CHARGES"].ToString();
					txtTestRepReqDT.Text = MyReader["TEST_REPORT_REQ_DATE"].ToString();
					txtTestRepRecDT.Text = MyReader["TEST_REPORT_REC_DATE"].ToString();
					lstTStatus.SelectedValue = MyReader["TEST_STATUS"].ToString();
					txtRemark.Text = MyReader["REMARKS"].ToString();
					txtSampleDispatchTOLabDT.Text = MyReader["SAMPLE_DISPATCH_LAB_DT"].ToString();

					if (Convert.ToInt32(lblAmtRecieved.Text) > 0)
					{
						txtTestingFee.Enabled = false;
						txtSTax.Enabled = false;
						txtHCharge.Enabled = false;

					}

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
				conn1.Dispose();
			}
			fillgrid();
		}
		private void fill_CallItems()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstItem.Items.Clear();
			DataSet ds = new DataSet();
			string MySql = "Select t18.ITEM_SRNO_PO,t18.ITEM_DESC_PO From T18_CALL_DETAILS t18 " +
				"Where t18.CASE_NO='" + lblCaseNo.Text + "' and t18.CALL_RECV_DT=TO_DATE('" + lblCallDT.Text + "','DD/MM/YYYY') and t18.CALL_SNO='" + lblCSNO.Text + "'";
			OracleCommand cmd = new OracleCommand(MySql, conn1);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			ListItem lst;
			//
			lst = new ListItem();
			lst.Value = null;
			lst.Text = null;
			lstItem.Items.Add(lst);
			//
			da.SelectCommand = cmd;
			da.Fill(ds, "Table");
			for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Value = ds.Tables[0].Rows[i]["ITEM_SRNO_PO"].ToString();
				lst.Text = ds.Tables[0].Rows[i]["ITEM_DESC_PO"].ToString();
				lstItem.Items.Add(lst);
			}
			conn1.Close();
			conn1.Dispose();

		}
		private string generate_Sample_Reg_NO()
		{
			string wREG_NO = "";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

				OracleCommand cmd = new OracleCommand("GENERATE_SAMPLE_REG_NO", conn1);
				cmd.CommandType = CommandType.StoredProcedure;
				conn1.Open();

				OracleParameter prm1 = new OracleParameter("IN_REGION_CD", OracleDbType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = Session["Region"].ToString();
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_SAMPLE_REG_DT", OracleDbType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = Convert.ToString(lblRegDt.Text.Replace("/", ""));
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("OUT_SAMPLE_REG_NO", OracleDbType.Char, 9);
				prm3.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32, 1);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				cmd.ExecuteNonQuery();

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					wREG_NO = "-1";
				}
				else
				{
					wREG_NO = Convert.ToString(cmd.Parameters["OUT_SAMPLE_REG_NO"].Value);
				}
				conn1.Close();
				return (wREG_NO);
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
				return ("-1");
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

		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "SELECT SAMPLE_REG_NO,SNO,ITEM_DESC,QTY,TEST,LAB_NAME,TESTING_FEE,REMARKS from T51_LAB_REGISTER_DETAIL T51, T65_LABORATORY_MASTER T65 where T51.LAB_ID = T65.LAB_ID and SAMPLE_REG_NO='" + lblRNo.Text.Trim() + "' order by SNO ASC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdLabDt.Visible = false;
					Label32.Visible = false;

				}
				else
				{
					grdLabDt.Visible = false;
					grdLabDt.Visible = true;
					Label32.Visible = true;
					grdLabDt.DataSource = dsP;
					grdLabDt.DataBind();
					conn1.Close();


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
				conn1.Close();
			}


		}

		void fillgrid1()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select VEND_CD from T13_PO_MASTER where CASE_NO='" + lblCaseNo.Text.Trim() + "'", conn1);
				string vend_cd = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				DataSet dsP = new DataSet();
				string str1 = "SELECT T25.CHQ_NO, to_char(T25.CHQ_DT,'dd/mm/yyyy') CHQ_DATE,T25.AMOUNT,T25.SUSPENSE_AMT, T94.BANK_NAME,T25.BANK_CD,T25.CASE_NO,T25.NARRATION from T25_RV_DETAILS T25, T94_BANK T94, T13_PO_MASTER T13 where T25.BANK_CD=T94.BANK_CD and T25.CASE_NO=T13.CASE_NO and ACC_CD IN (2210,2212) and NVL(SUSPENSE_AMT,0)>0 and (T25.CASE_NO='" + lblCaseNo.Text.Trim() + "' OR T13.VEND_CD=" + vend_cd + ") and T25.CHQ_DT>='01-APR-13' order by T25.CHQ_DT DESC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdPaymentDetails.Visible = false;
					btnPosting.Visible = false;
					Label30.Visible = false;
				}
				else
				{
					btnPosting.Visible = true;
					grdPaymentDetails.Visible = true;
					grdPaymentDetails.DataSource = dsP;
					grdPaymentDetails.DataBind();
					btnPosting.Visible = true;
					conn1.Close();
					Label30.Visible = true;


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
				conn1.Close();
			}


		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			if (lblRNo.Text.Trim() == "" && txtCodeNo.Text.Trim() != "" && txtCodeDt.Text.Trim() != "")
			{
				lblRegDt.Text = txtRegDt.Text.Trim();
				string REG_NO = generate_Sample_Reg_NO();
				if (REG_NO == "-1")
				{
					DisplayAlert("Registration Details not available");
				}
				else
				{
					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					conn1.Open();
					OracleCommand cmd = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd.ExecuteScalar());
					conn1.Close();
					conn1.Open();
					OracleTransaction myTrans = conn1.BeginTransaction();
					try
					{
						string wTest_Type = "";

						if (rdbReTesting.Checked == true)
						{
							wTest_Type = "R";
						}
						string myInsertQuery = "INSERT INTO T50_LAB_REGISTER(SAMPLE_REG_NO,SAMPLE_REG_DT,SAMPLE_DRAWL_DT,SAMPLE_RECIEPT_DT,SAMPLE_DISPATCH_DT,IE_CD,CASE_NO,CALL_RECV_DT,CALL_SNO,VEND_CD, USER_ID, DATETIME,TESTING_TYPE,CODE_NO,CODE_DT) values('" + REG_NO + "',to_date('" + lblRegDt.Text.Trim() + "','dd/mm/yyyy'),to_date('" + txtSampleDrawalDT.Text.Trim() + "','dd/mm/yyyy'),to_date('" + txtSampleReceiptDT.Text.Trim() + "','dd/mm/yyyy'),to_date('" + txtSampleDispatchDT.Text.Trim() + "','dd/mm/yyyy')," + lblIECD.Text.Trim() + ",'" + lblCaseNo.Text.Trim() + "', to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy')," + lblCSNO.Text + "," + lblVENDCD.Text.Trim() + ",'" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + wTest_Type + "','" + txtCodeNo.Text.Trim() + "',to_date('" + txtCodeDt.Text.Trim() + "','dd/mm/yyyy'))";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Transaction = myTrans;
						myInsertCommand.Connection = conn1;
						myInsertCommand.ExecuteNonQuery();

						string str3 = "Select NVL(max(SNO),0)+1 from T51_LAB_REGISTER_DETAIL where SAMPLE_REG_NO='" + REG_NO + "'";
						OracleCommand myCommand = new OracleCommand();
						myCommand.CommandText = str3;
						myCommand.Transaction = myTrans;
						myCommand.Connection = conn1;
						int sno = Convert.ToInt32(myCommand.ExecuteScalar());

						string myInsertQuery1 = "INSERT INTO T51_LAB_REGISTER_DETAIL(SAMPLE_REG_NO,SNO,ITEM_DESC,QTY,TEST_CATEGORY_CD,TEST,LAB_ID,TESTING_FEE,SERVICE_TAX,HANDLING_CHARGES,TEST_REPORT_REQ_DT,TEST_REPORT_REC_DT,TEST_STATUS,REMARKS,SAMPLE_DISPATCHED_TO_LAB_DT ,USER_ID, DATETIME) values('" + REG_NO + "'," + sno + ",'" + txtItem.Text.Trim() + "'," + txtSample.Text + ",'" + lstCategory.SelectedValue + "','" + txtTest.Text + "'," + lstLab.SelectedValue + "," + txtTestingFee.Text + "," + txtSTax.Text + "," + txtHCharge.Text + ",to_date('" + txtTestRepReqDT.Text + "','dd/mm/yyyy'),to_date('" + txtTestRepRecDT.Text + "','dd/mm/yyyy'),'" + lstTStatus.SelectedValue + "','" + txtRemark.Text + "',to_date('" + txtSampleDispatchTOLabDT.Text + "','dd/mm/yyyy'),'" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
						OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
						myInsertCommand1.Transaction = myTrans;
						myInsertCommand1.Connection = conn1;
						myInsertCommand1.ExecuteNonQuery();

						lblTotalLabCharges.Text = Convert.ToString(Convert.ToInt32(lblTotalLabCharges.Text) + Convert.ToInt32(txtTestingFee.Text) + Convert.ToInt32(txtSTax.Text) + Convert.ToInt32(txtHCharge.Text));
						lblTotalTestingFee.Text = Convert.ToString(Convert.ToInt32(lblTotalTestingFee.Text) + Convert.ToInt32(txtTestingFee.Text));
						lblTotalHandlingCharges.Text = Convert.ToString(Convert.ToInt32(lblTotalHandlingCharges.Text) + Convert.ToInt32(txtHCharge.Text));
						lblTotalServiceTax.Text = Convert.ToString(Convert.ToInt32(lblTotalServiceTax.Text) + Convert.ToInt32(txtSTax.Text));

						string myUpdateQuery1 = "update T50_LAB_REGISTER set TOTAL_TESTING_FEE=" + lblTotalTestingFee.Text + ",TOTAL_SERVICE_TAX=" + lblTotalServiceTax.Text + ",TOTAL_HANDLING_CHARGES=" + lblTotalHandlingCharges.Text + ",TOTAL_LAB_CHARGES=" + lblTotalLabCharges.Text + ",AMOUNT_RECIEVED=0, USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where SAMPLE_REG_NO='" + REG_NO + "' ";
						OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
						myUpdateCommand1.Transaction = myTrans;
						myUpdateCommand1.Connection = conn1;
						myUpdateCommand1.ExecuteNonQuery();
						myTrans.Commit();
						conn1.Close();
						lblRNo.Text = REG_NO;
						lblSampleDispatchDT.Text = txtSampleDispatchDT.Text;
						lblSampleDrawalDT.Text = txtSampleDrawalDT.Text;
						lblSampleReceiptDT.Text = txtSampleReceiptDT.Text;
						txtSampleDispatchDT.Visible = false;
						txtSampleDrawalDT.Visible = false;
						txtSampleReceiptDT.Visible = false;
						btnSave.Visible = false;
						btnUpdate.Visible = true;
					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						myTrans.Rollback();
						string str1 = str.Replace("\n", "");
						Response.Redirect(("Error_Form.aspx?err=" + str1));
					}
					finally
					{
						conn1.Close();
						conn1.Dispose();
					}
					Response.Redirect("Lab_Register_Form.aspx?SAMPLE_REG_NO=" + lblRNo.Text);
				}
			}
			else
			{
				DisplayAlert("Code No. & Date cannot be left blank.");
			}
		}

		protected void lstItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtItem.Text = lstItem.SelectedItem.Text;
		}

		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			if (Convert.ToString(Request.Params["Action"]) == "M")
			{
				conn1.Open();
				OracleTransaction myTrans = conn1.BeginTransaction();
				try
				{
					string myUpdateQuery1 = "update T51_LAB_REGISTER_DETAIL set ITEM_DESC='" + txtItem.Text.Trim() + "',QTY=" + txtSample.Text + ",TEST_CATEGORY_CD='" + lstCategory.SelectedValue + "',TEST='" + txtTest.Text + "',LAB_ID=" + lstLab.SelectedValue + ",TESTING_FEE=" + txtTestingFee.Text + ",SERVICE_TAX=" + txtSTax.Text + ",HANDLING_CHARGES=" + txtHCharge.Text + ",TEST_REPORT_REQ_DT=to_date('" + txtTestRepReqDT.Text + "','dd/mm/yyyy'),TEST_REPORT_REC_DT=to_date('" + txtTestRepRecDT.Text + "','dd/mm/yyyy'),TEST_STATUS='" + lstTStatus.SelectedValue + "',REMARKS='" + txtRemark.Text + "',SAMPLE_DISPATCHED_TO_LAB_DT=to_date('" + txtSampleDispatchTOLabDT.Text + "','dd/mm/yyyy'), USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where SAMPLE_REG_NO='" + lblRNo.Text + "' and SNO=" + lblSNO.Text;
					OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
					myUpdateCommand1.Transaction = myTrans;
					myUpdateCommand1.Connection = conn1;
					myUpdateCommand1.ExecuteNonQuery();


					lblTotalLabCharges.Text = Convert.ToString((Convert.ToInt32(lblTotalLabCharges.Text) + Convert.ToInt32(txtTestingFee.Text) + Convert.ToInt32(txtSTax.Text) + Convert.ToInt32(txtHCharge.Text)) - (Convert.ToInt32(lblTestingFee.Text) + Convert.ToInt32(lblHandlingCharges.Text) + Convert.ToInt32(lblServiceTax.Text)));
					lblTotalTestingFee.Text = Convert.ToString((Convert.ToInt32(lblTotalTestingFee.Text) + Convert.ToInt32(txtTestingFee.Text)) - Convert.ToInt32(lblTestingFee.Text));
					lblTotalHandlingCharges.Text = Convert.ToString((Convert.ToInt32(lblTotalHandlingCharges.Text) + Convert.ToInt32(txtHCharge.Text)) - Convert.ToInt32(lblHandlingCharges.Text));
					lblTotalServiceTax.Text = Convert.ToString((Convert.ToInt32(lblTotalServiceTax.Text) + Convert.ToInt32(txtSTax.Text)) - Convert.ToInt32(lblServiceTax.Text));

					string myUpdateQuery2 = "update T50_LAB_REGISTER set TOTAL_TESTING_FEE=" + lblTotalTestingFee.Text + ",TOTAL_SERVICE_TAX=" + lblTotalServiceTax.Text + ",TOTAL_HANDLING_CHARGES=" + lblTotalHandlingCharges.Text + ",TOTAL_LAB_CHARGES=" + lblTotalLabCharges.Text + ", USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where SAMPLE_REG_NO='" + lblRNo.Text + "' ";
					OracleCommand myUpdateCommand2 = new OracleCommand(myUpdateQuery2);
					myUpdateCommand2.Transaction = myTrans;
					myUpdateCommand2.Connection = conn1;
					myUpdateCommand2.ExecuteNonQuery();
					myTrans.Commit();
					conn1.Close();

				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					myTrans.Rollback();
					string str1 = str.Replace("\n", "");
					Response.Redirect(("Error_Form.aspx?err=" + str1));
				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}
				Response.Redirect("Lab_Register_Form.aspx?SAMPLE_REG_NO=" + lblRNo.Text);

			}
			else
			{

				conn1.Open();
				OracleTransaction myTrans = conn1.BeginTransaction();
				try
				{
					string str3 = "Select NVL(max(SNO),0)+1 from T51_LAB_REGISTER_DETAIL where SAMPLE_REG_NO='" + lblRNo.Text + "'";
					OracleCommand myCommand = new OracleCommand();
					myCommand.CommandText = str3;
					myCommand.Transaction = myTrans;
					myCommand.Connection = conn1;
					int sno = Convert.ToInt32(myCommand.ExecuteScalar());

					string myInsertQuery1 = "INSERT INTO T51_LAB_REGISTER_DETAIL(SAMPLE_REG_NO,SNO,ITEM_DESC,QTY,TEST_CATEGORY_CD,TEST,LAB_ID,TESTING_FEE,SERVICE_TAX,HANDLING_CHARGES,TEST_REPORT_REQ_DT,TEST_REPORT_REC_DT,TEST_STATUS,REMARKS, SAMPLE_DISPATCHED_TO_LAB_DT, USER_ID, DATETIME) values('" + lblRNo.Text + "'," + sno + ",'" + txtItem.Text.Trim() + "'," + txtSample.Text + ",'" + lstCategory.SelectedValue + "','" + txtTest.Text + "'," + lstLab.SelectedValue + "," + txtTestingFee.Text + "," + txtSTax.Text + "," + txtHCharge.Text + ",to_date('" + txtTestRepReqDT.Text + "','dd/mm/yyyy'),to_date('" + txtTestRepRecDT.Text + "','dd/mm/yyyy'),'" + lstTStatus.SelectedValue + "','" + txtRemark.Text + "',to_date('" + txtSampleDispatchTOLabDT.Text + "','dd/mm/yyyy'),'" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
					myInsertCommand1.Transaction = myTrans;
					myInsertCommand1.Connection = conn1;
					myInsertCommand1.ExecuteNonQuery();
					lblTotalLabCharges.Text = Convert.ToString(Convert.ToInt32(lblTotalLabCharges.Text) + Convert.ToInt32(txtTestingFee.Text) + Convert.ToInt32(txtSTax.Text) + Convert.ToInt32(txtHCharge.Text));
					lblTotalTestingFee.Text = Convert.ToString(Convert.ToInt32(lblTotalTestingFee.Text) + Convert.ToInt32(txtTestingFee.Text));
					lblTotalHandlingCharges.Text = Convert.ToString(Convert.ToInt32(lblTotalHandlingCharges.Text) + Convert.ToInt32(txtHCharge.Text));
					lblTotalServiceTax.Text = Convert.ToString(Convert.ToInt32(lblTotalServiceTax.Text) + Convert.ToInt32(txtSTax.Text));

					string myUpdateQuery1 = "update T50_LAB_REGISTER set TOTAL_TESTING_FEE=" + lblTotalTestingFee.Text + ",TOTAL_SERVICE_TAX=" + lblTotalServiceTax.Text + ",TOTAL_HANDLING_CHARGES=" + lblTotalHandlingCharges.Text + ",TOTAL_LAB_CHARGES=" + lblTotalLabCharges.Text + ", USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where SAMPLE_REG_NO='" + lblRNo.Text + "' ";
					OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
					myUpdateCommand1.Transaction = myTrans;
					myUpdateCommand1.Connection = conn1;
					myUpdateCommand1.ExecuteNonQuery();
					myTrans.Commit();
					conn1.Close();

				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					myTrans.Rollback();
					string str1 = str.Replace("\n", "");
					Response.Redirect(("Error_Form.aspx?err=" + str1));
				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}
				Response.Redirect("Lab_Register_Form.aspx?SAMPLE_REG_NO=" + lblRNo.Text);
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Lab_Register_Edit.aspx");
		}

		protected void btnPrintInvoice_Click(object sender, System.EventArgs e)
		{
			//			string popupScript = "<script language='javascript'>" + "window.open('Lab_Invoice.aspx?SAMPLE_REG_NO="+lblRNo.Text+"','CustomPopUp','fullscreen=no, scrollbars=yes' ," + "'width=700, height=800, menubar=no, resizable=no,alwaysRaised=true')" + "</script>";
			//			Page.RegisterStartupScript("PopupScript", popupScript);



			if (lblInvoiceNo.Text.Trim() == "" && lblInvoiceNo.Visible == false)
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn1.Open();
				OracleCommand cmd = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
				string ss = Convert.ToString(cmd.ExecuteScalar());
				conn1.Close();
				int yy = 0;
				if (Convert.ToInt16(ss.Substring(3, 2)) > 3)
				{
					yy = Convert.ToInt16(ss.Substring(8, 2));
				}
				else
				{
					yy = Convert.ToInt16(ss.Substring(8, 2)) - 1;
				}

				string wRegion_yy = Session["Region"].ToString() + "/" + Convert.ToString(yy);

				conn1.Open();
				OracleCommand cmd1 = new OracleCommand("SELECT NVL(MAX(TO_NUMBER(nvl(TRIM(SUBSTR(INVOICE_NO,6,5)),'0'))),10000)+1 FROM T55_LAB_INVOICE WHERE SUBSTR(INVOICE_NO,1,4)='" + wRegion_yy + "'", conn1);
				string w_inv_no = wRegion_yy + "/" + Convert.ToString(cmd1.ExecuteScalar());
				conn1.Close();
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss1 = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				conn1.Open();
				//				System.Data.OracleClient.OracleTransaction myTrans = conn1.BeginTransaction();
				try
				{

					string myInsertQuery = "INSERT INTO T55_LAB_INVOICE(INVOICE_NO,INVOICE_DT,SAMPLE_REG_NO,USER_ID, DATETIME) values('" + w_inv_no + "',to_date('" + ss + "','dd/mm/yyyy'),'" + lblRNo.Text.Trim() + "','" + Session["Uname"] + "', to_date('" + ss1 + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					//						myInsertCommand.Transaction=myTrans;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();

					lblInvoiceNo.Text = w_inv_no;
					lblInvoiceDt.Text = ss;



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
				Response.Redirect("Lab_Register_Form.aspx?SAMPLE_REG_NO=" + lblRNo.Text);
			}
			else
			{

			 

				Response.Clear();
				Response.Buffer = true;
				Response.ContentType = "application/pdf";
				try
				{
					MemoryStream oStream = new MemoryStream();
					Response.BinaryWrite(oStream.ToArray());
					Response.End();
				}
				catch (Exception err)
				{
					Response.Write("< BR >");
					Response.Write(err.Message.ToString());
				}

				lblInvoiceNo.Visible = true;
				lblInvoiceDt.Visible = true;
				Label33.Visible = true;
				Label35.Visible = true;
			}
		}

		protected void btnPosting_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{
				foreach (DataGridItem di in grdPaymentDetails.Items)
				{
					if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
					{
						if (Convert.ToBoolean(((RadioButton)di.FindControl("rdbCheque")).Checked) == true)
						{
							int wposting_amt = 0;
							if (Convert.ToInt32(di.Cells[6].Text) >= (Convert.ToInt32(lblTotalLabCharges.Text) - (Convert.ToInt32(lblAmtRecieved.Text) + Convert.ToInt32(lblTDS.Text))))
							{
								wposting_amt = Convert.ToInt32(lblTotalLabCharges.Text) - (Convert.ToInt32(lblAmtRecieved.Text) + Convert.ToInt32(lblTDS.Text));
							}
							else
							{
								wposting_amt = Convert.ToInt32(di.Cells[6].Text);
							}

							string myInsertQuery1 = "INSERT INTO T52_LAB_POSTING values('" + lblRNo.Text + "'," + Convert.ToInt16(di.Cells[5].Text) + ",'" + Convert.ToString(di.Cells[1].Text) + "', to_date('" + di.Cells[2].Text + "','dd/mm/yyyy')," + wposting_amt + ", " + lblTotalLabCharges.Text + ",'" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
							OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
							myInsertCommand1.Transaction = myTrans;
							myInsertCommand1.Connection = conn1;
							myInsertCommand1.ExecuteNonQuery();

							string myUpdateQuery1 = "update T50_LAB_REGISTER set AMOUNT_RECIEVED=(NVL(AMOUNT_RECIEVED,0)+" + wposting_amt + ") where SAMPLE_REG_NO='" + lblRNo.Text + "'";
							OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
							myUpdateCommand1.Transaction = myTrans;
							myUpdateCommand1.Connection = conn1;
							myUpdateCommand1.ExecuteNonQuery();

							string myUpdateQuery2 = "update T25_RV_DETAILS set AMOUNT_ADJUSTED=NVL(AMOUNT_ADJUSTED,0)+" + wposting_amt + ", SUSPENSE_AMT=NVL(SUSPENSE_AMT,0)-" + wposting_amt + " where CHQ_NO='" + Convert.ToString(di.Cells[1].Text) + "' and CHQ_DT=to_date('" + di.Cells[2].Text + "','dd/mm/yyyy') and  BANK_CD=" + Convert.ToInt16(di.Cells[5].Text);
							OracleCommand myUpdateCommand2 = new OracleCommand(myUpdateQuery2);
							myUpdateCommand2.Transaction = myTrans;
							myUpdateCommand2.Connection = conn1;
							myUpdateCommand2.ExecuteNonQuery();


						}

					}
				}
				myTrans.Commit();
				conn1.Close();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				myTrans.Rollback();
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
			Response.Redirect("Lab_Register_Form.aspx?SAMPLE_REG_NO=" + lblRNo.Text);
		}

		protected void grdPaymentDetails_SelectedIndexChanged(object sender, System.EventArgs e)
		{


		}




	}
}