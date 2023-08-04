using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Lab_Payments_Form
{
	public partial class Lab_Payments_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave1.Attributes.Add("OnClick", "JavaScript:validate();");
			if (!(IsPostBack))
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
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

					DataSet dsP1 = new DataSet();
					string stra1 = "select BANK_CD,(lpad(to_char(FMIS_BANK_CD),4,'0')||'-'||BANK_NAME) BANK_NAME from T94_BANK WHERE FMIS_BANK_CD is not NULL order by BANK_NAME";
					OracleDataAdapter da1 = new OracleDataAdapter(stra1, conn1);
					OracleCommand myOracleCommand1 = new OracleCommand(stra1, conn1);
					//ListItem lst; 
					conn1.Open();
					da1.SelectCommand = myOracleCommand1;
					da1.Fill(dsP1, "Table");
					lstBank.DataValueField = "BANK_CD";
					lstBank.DataTextField = "BANK_NAME";
					lstBank.DataSource = dsP1;
					lstBank.DataBind();
					conn1.Close();
					if (Convert.ToString(Request.Params["PAYMENT_ID"]) == null || Convert.ToString(Request.Params["PAYMENT_ID"]) == "")
					{
						if (Session["Region"].ToString() == "N")
						{
							lstBank.SelectedValue = "53";
						}
						else if (Session["Region"].ToString() == "W")
						{
							lstBank.SelectedValue = "88";
						}
						else if (Session["Region"].ToString() == "E")
						{
							lstBank.SelectedValue = "85";
						}
						else if (Session["Region"].ToString() == "S")
						{
							lstBank.SelectedValue = "87";
						}

						Panel_1.Visible = false;
						btnCalculateAmt.Visible = false;
						btnSave1.Visible = true;
						btnSave.Visible = false;
						btnPrint.Visible = false;
					}
					else
					{
						lblPaymentNO.Text = Convert.ToString(Request.Params["PAYMENT_ID"]);
						show();
						fillgrid();
						Panel_1.Visible = true;
						btnSubmit.Visible = false;
						btnCalculateAmt.Visible = false;
						btnSave1.Visible = false;
						btnSave.Visible = true;
						lstBank.Enabled = false;
						txtAmt.Enabled = false;
						btnPrint.Visible = true;

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
			}
		}
		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string MySql = "Select PAYMENT_ID,to_char(PAYMENT_DT,'dd/mm/yyyy') PAYMENY_DATE, BANK_CD,CHQ_NO,to_char(CHQ_DT,'dd/mm/yyyy') CHQ_DATE, AMOUNT, LAB_ID, REMARKS from T56_LAB_PAYMENTS where PAYMENT_ID='" + lblPaymentNO.Text.Trim() + "'";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				OracleCommand cmd = new OracleCommand(MySql, conn1);
				conn1.Open();
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					txtCNO.Text = MyReader["CHQ_NO"].ToString();
					txtCDT.Text = MyReader["CHQ_DATE"].ToString();
					lstBank.SelectedValue = MyReader["BANK_CD"].ToString();
					txtAmt.Text = MyReader["AMOUNT"].ToString();
					txtNarrat.Text = MyReader["REMARKS"].ToString();
					lstLab.SelectedValue = MyReader["LAB_ID"].ToString();
					lstLab.Enabled = false;
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
		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "SELECT T52.CHQ_NO, to_char(T52.CHQ_DT,'dd/mm/yyyy') CHQ_DT,T50.SAMPLE_REG_NO, T50.CASE_NO,T51.SNO,NVL(T50.TOTAL_TESTING_FEE,0) + NVL(T50.TOTAL_SERVICE_TAX,0) + NVL(T50.TOTAL_HANDLING_CHARGES,0)  TOT_CHARGES, NVL(T51.TESTING_FEE,0) + NVL(T51.SERVICE_TAX,0)  TESTING_FEE,T52.AMT_CLEARED,T25.AMOUNT from T52_LAB_POSTING T52, T50_LAB_REGISTER T50, T51_LAB_REGISTER_DETAIL T51,T25_RV_DETAILS T25 where T50.SAMPLE_REG_NO=T52.SAMPLE_REG_NO and T50.SAMPLE_REG_NO=T51.SAMPLE_REG_NO and T52.CHQ_NO=T25.CHQ_NO and T52.CHQ_DT=T25.CHQ_DT and T52.BANK_CD=T25.BANK_CD and NVL(T50.TOTAL_LAB_CHARGES,0)=NVL(T50.AMOUNT_RECIEVED,0) and T51.PAYMENT_ID='" + lblPaymentNO.Text + "' order by T50.SAMPLE_REG_NO ";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdLabDt.Visible = false;

				}
				else
				{

					grdLabDt.Visible = true;
					grdLabDt.DataSource = dsP;
					grdLabDt.DataBind();
					grdLabDt.Columns[0].Visible = false;

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
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "SELECT T52.CHQ_NO, to_char(T52.CHQ_DT,'dd/mm/yyyy') CHQ_DT,T50.SAMPLE_REG_NO, T50.CASE_NO,T51.SNO,NVL(T50.TOTAL_TESTING_FEE,0) + NVL(T50.TOTAL_SERVICE_TAX,0) + NVL(T50.TOTAL_HANDLING_CHARGES,0)  TOT_CHARGES,NVL(TDS,0) TDS_AMT ,NVL(T51.TESTING_FEE,0) + NVL(T51.SERVICE_TAX,0)  TESTING_FEE,T52.AMT_CLEARED,T25.AMOUNT from T52_LAB_POSTING T52, T50_LAB_REGISTER T50, T51_LAB_REGISTER_DETAIL T51,T25_RV_DETAILS T25 where T50.SAMPLE_REG_NO=T52.SAMPLE_REG_NO and T50.SAMPLE_REG_NO=T51.SAMPLE_REG_NO and T52.CHQ_NO=T25.CHQ_NO and T52.CHQ_DT=T25.CHQ_DT and T52.BANK_CD=T25.BANK_CD and NVL(T50.TOTAL_LAB_CHARGES,0)=NVL(T50.AMOUNT_RECIEVED,0)+NVL(T50.TDS,0) AND NVL(PAYMENT_ID,'X')='X' and T51.LAB_ID=" + lstLab.SelectedValue + " AND  (NVL(T51.TESTING_FEE,0) + NVL(T51.SERVICE_TAX,0)) >0 and T50.SAMPLE_REG_DT>='01-APR-13' order by T50.SAMPLE_REG_NO ";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdLabDt.Visible = false;

				}
				else
				{

					grdLabDt.Visible = true;
					grdLabDt.DataSource = dsP;
					grdLabDt.DataBind();
					btnCalculateAmt.Visible = true;
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

		protected void btnCalculateAmt_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();

			try
			{
				//				int testing_amt=0;
				//				foreach (DataGridItem di in grdLabDt.Items)
				//				{
				//					if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
				//					{
				//						if(Convert.ToBoolean(((CheckBox)di.FindControl("chkBox")).Checked)==true)
				//						{
				//							
				//							testing_amt=testing_amt+Convert.ToInt32(di.Cells[4].Text);
				//							
				//							
				//
				//							
				//						}
				//					
				//					}
				//				}
				txtNarrat.Text = lstLab.SelectedItem.Text;
				//				txtAmt.Text=Convert.ToString(testing_amt);
				lstLab.Enabled = false;
				Panel_1.Visible = true;
				lblPaymentNO.Visible = false;
				lblPaymentDT.Text = ss;

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

		public void generate()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				//				conn1.Open();
				//				OracleCommand cmd2 =new OracleCommand("Select to_char('"+txtVDT.Text+"','YYMM') from dual",conn1);
				//				string ss=Convert.ToString(cmd2.ExecuteScalar());
				string ss = Session["Region"] + lblPaymentDT.Text.Substring(8, 2) + lblPaymentDT.Text.Substring(3, 2);
				//				conn1.Close();

				string str3 = "Select lpad(nvl(max(to_number(nvl(substr(PAYMENT_ID,6,8),0))),0)+1,3,'0') from T56_LAB_PAYMENTS where substr(PAYMENT_ID,1,5)='" + ss + "'";
				OracleCommand myInsertCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				str3 = Convert.ToString(myInsertCommand.ExecuteScalar());
				conn1.Close();
				lblPaymentNO.Text = ss + str3;
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

		protected void btnSave1_Click(object sender, System.EventArgs e)
		{


			if (lblPaymentNO.Visible == false)
			{
				generate();
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn1.Open();
				OracleCommand cmdDT = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string dt = Convert.ToString(cmdDT.ExecuteScalar());
				conn1.Close();
				conn1.Open();
				OracleTransaction myTrans = conn1.BeginTransaction();
				//				conn1.Open();
				//				OracleCommand cmd = new OracleCommand("Select Count(*) from T56_LAB_PAYMENTS where PAYMENT_ID='"+lblPaymentNO.Text+"'",conn1); 
				//				int m=Convert.ToInt16(cmd.ExecuteScalar());
				//				conn1.Close();
				try
				{

					string myInsertQuery = "INSERT INTO T56_LAB_PAYMENTS(PAYMENT_ID,PAYMENT_DT,BANK_CD,CHQ_NO,CHQ_DT,AMOUNT,LAB_ID,REMARKS,USER_ID,DATETIME)values('" + lblPaymentNO.Text + "',to_date('" + lblPaymentDT.Text + "','dd/mm/yyyy')," + lstBank.SelectedValue + ",'" + txtCNO.Text.Trim() + "',to_date('" + txtCDT.Text + "','dd/mm/yyyy')," + txtAmt.Text + "," + lstLab.SelectedValue + ",'" + txtNarrat.Text + "','" + Session["Uname"].ToString() + "',to_date('" + dt + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Transaction = myTrans;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					int count = 0;
					foreach (DataGridItem di in grdLabDt.Items)
					{
						if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
						{
							if (Convert.ToBoolean(((CheckBox)di.FindControl("chkBox")).Checked) == true)
							{
								count = count + 1;
								string myInsertQuery1 = "update T51_LAB_REGISTER_DETAIL set PAYMENT_ID='" + lblPaymentNO.Text + "' where SAMPLE_REG_NO='" + Convert.ToString(di.Cells[1].Text) + "' and LAB_ID=" + lstLab.SelectedValue + " and SNO=" + Convert.ToInt32(di.Cells[10].Text);
								OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
								myInsertCommand1.Transaction = myTrans;
								myInsertCommand1.Connection = conn1;
								myInsertCommand1.ExecuteNonQuery();
							}

						}
					}
					if (count == 0)
					{
						DisplayAlert("Select atleast One Sample Registration No. to process the Lab Payment.");
						myTrans.Rollback();
					}
					else
					{
						myTrans.Commit();
						lblPaymentNO.Visible = true;
						btnSave1.Visible = false;
						btnPrint.Visible = true;
					}
					conn1.Close();

				}
				catch (OracleException ex)
				{
					string str;
					str = ex.Message;
					myTrans.Rollback();
					string str1;
					if (ex.ErrorCode == 1)
					{
						str1 = "The Cheque with the given Cheque No, Cheque Date and Bank Already Exist!!!";
					}
					else
					{
						str1 = str.Replace("\n", "");
					}
					Response.Redirect(("Error_Form.aspx?err=" + str1));
				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Print_Lab_Payment_Voucher.aspx?VOUCHER_NO=" + lblPaymentNO.Text);
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			conn1.Open();
			OracleCommand cmd = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();


			try
			{
				string myUpdateQuery1 = "update T56_LAB_PAYMENTS set CHQ_NO='" + txtCNO.Text.Trim() + "',CHQ_DT=to_date('" + txtCDT.Text + "','dd/mm/yyyy'),REMARKS='" + txtNarrat.Text + "', USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where PAYMENT_ID='" + lblPaymentNO.Text + "'";
				OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
				conn1.Open();
				myUpdateCommand1.Connection = conn1;
				myUpdateCommand1.ExecuteNonQuery();
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

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Lab_Payments_Edit_Form.aspx");
		}
	}
}