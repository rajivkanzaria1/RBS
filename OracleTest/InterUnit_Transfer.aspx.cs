using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class InterUnit_Transfer : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		string ACTION, ACCD, wRegion;


		void show_jv_details()
		{

			try
			{
				DataSet dsP = new DataSet();
				string str3 = "select VCHR_NO,ACC_CD,AMOUNT,NARRATION,IU_ADV_NO,to_char(IU_ADV_DT,'dd/mm/yyyy')IU_ADV_DT From T29_JV_DETAILS T29 where T29.VCHR_NO='" + lblJVNO.Text + "' AND T29.ACC_CD=" + ACCD + " and substr(T29.VCHR_NO,1,1)='" + Session["Region"] + "'";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				conn1.Close();
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("InValid Cheque No. Or Bank");
				}
				else
				{
					lstACD.SelectedValue = dsP.Tables[0].Rows[0]["ACC_CD"].ToString();
					txtAmt.Text = dsP.Tables[0].Rows[0]["AMOUNT"].ToString();
					txtNarrat.Text = dsP.Tables[0].Rows[0]["NARRATION"].ToString();
					txtRNo.Text = dsP.Tables[0].Rows[0]["IU_ADV_NO"].ToString();
					txtRDT.Text = dsP.Tables[0].Rows[0]["IU_ADV_DT"].ToString();
					lstACD.Enabled = false;

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
		void show_chq_details()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str3 = "select T24.VCHR_NO,to_char(T24.VCHR_DT,'dd/mm/yyyy') VCHR_DT,T25.SNO,T25.CHQ_NO,to_char(T25.CHQ_DT,'dd/mm/yyyy')CHQ_DT,T25.BANK_CD,NVL2(T25.BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),T25.NARRATION) BPO,NVL(T25.AMOUNT,0) AMOUNT,NVL(T25.AMT_TRANSFERRED,0)AMT_TRANSFERRED,NVL(T25.SUSPENSE_AMT,0)SUSPENSE_AMT from T24_RV T24,T25_RV_DETAILS T25, T12_BILL_PAYING_OFFICER B,T03_CITY C where T24.VCHR_NO= T25.VCHR_NO AND T25.BPO_CD=B.BPO_CD(+) AND B.BPO_CITY_CD=C.CITY_CD(+) AND T25.CHQ_NO='" + txtCNO.Text + "' AND T25.BANK_CD=" + lstBank.SelectedValue + " and T25.CHQ_DT=to_date('" + txtCDT.Text + "','dd/mm/yyyy') and substr(T24.VCHR_NO,1,1)='" + Session["Region"] + "'";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				conn1.Close();
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("InValid Cheque No.,Cheque Date Or Bank");
					Panel1.Visible = false;
					cvisiblefalse();
				}
				else
				{
					lblVNo.Text = dsP.Tables[0].Rows[0]["VCHR_NO"].ToString();
					lblVDT.Text = dsP.Tables[0].Rows[0]["VCHR_DT"].ToString();
					lblSNO.Text = dsP.Tables[0].Rows[0]["SNO"].ToString();
					lblCNO.Text = dsP.Tables[0].Rows[0]["CHQ_NO"].ToString();
					lstBank.SelectedValue = dsP.Tables[0].Rows[0]["BANK_CD"].ToString();
					lblBank.Text = lstBank.SelectedItem.Text;
					lblCDate.Text = dsP.Tables[0].Rows[0]["CHQ_DT"].ToString();
					txtCDT.Visible = false;
					lblAmt.Text = dsP.Tables[0].Rows[0]["AMOUNT"].ToString();
					lblAmtADJ.Text = dsP.Tables[0].Rows[0]["AMT_TRANSFERRED"].ToString();
					lblSAmt.Text = dsP.Tables[0].Rows[0]["SUSPENSE_AMT"].ToString();
					txtSAmt.Text = lblSAmt.Text;
					lblCBPO.Text = dsP.Tables[0].Rows[0]["BPO"].ToString();
					lstBank.Visible = false;
					txtCNO.Visible = false;
					btnSearch.Visible = false;
					Panel1.Visible = true;
					cvisibletrue();
					string str = "select VCHR_NO,to_char(VCHR_DT,'dd/mm/yyyy')VCHR_DT from T27_JV where CHQ_NO='" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy') and BANK_CD=" + lstBank.SelectedValue;
					conn1.Open();
					OracleCommand myOracleCommand1 = new OracleCommand(str, conn1);
					OracleDataReader reader = myOracleCommand1.ExecuteReader();
					if (reader.HasRows == false)
					{
						txtVDT.Visible = true;
						lblJVDT.Text = txtVDT.Text;
						lblJVDT.Visible = false;
						lblJVNO.Visible = false;
						lblJVNO.Visible = false;
						OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'DD/MM/YYYY') from dual", conn1);
						txtVDT.Text = Convert.ToString(cmd2.ExecuteScalar());
					}
					else
					{
						while (reader.Read())
						{
							lblJVNO.Text = reader["VCHR_NO"].ToString();
							lblJVDT.Text = reader["VCHR_DT"].ToString();
							txtVDT.Visible = false;
							txtVDT.Visible = false;

						}

						conn1.Close();
						fillgrid();
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
			}

		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select T27.CHQ_NO,to_char(T27.CHQ_DT,'dd/mm/yyyy')CHQ_DT,T27.BANK_CD,T29.VCHR_NO,T29.ACC_CD,DECODE(T29.ACC_CD,'3007','Northern','3008','Eastern','3009','Southern','3006','Western','3066','Central','9999','Bill Adjustment of Old System','9998','Miscelleanous Adjustments') ACC_DESC,T29.AMOUNT,T29.NARRATION,T29.IU_ADV_NO,to_char(T29.IU_ADV_DT,'dd/mm/yyyy')IU_ADV_DT from T27_JV T27,T29_JV_DETAILS T29 where T27.VCHR_NO=T29.VCHR_NO and T27.VCHR_NO='" + lblJVNO.Text + "'";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdVDt.Visible = false;

				}
				else
				{
					grdVDt.Visible = true;
					grdVDt.DataSource = dsP;
					grdVDt.DataBind();
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

		void cvisiblefalse()
		{
			lbldisplay.Visible = false;
			lblCDate.Visible = false;
			Label2.Visible = false;
			lblVNo.Visible = false;
			lblVDT.Visible = false;
			lblJVNO.Visible = false;
			txtVDT.Visible = false;
			lblJVDT.Visible = false;
			Label3.Visible = false;
			lblAmt.Visible = false;
			lblAND.Visible = false;
			Label8.Visible = false;
			lblAmtADJ.Visible = false;
			lblSAmt.Visible = false;
			Label15.Visible = false;
			btnSearch.Visible = true;
			Label7.Visible = false;
			Label9.Visible = false;

			Label20.Visible = false;
			lblCBPO.Visible = false;
		}

		void cvisibletrue()
		{
			lbldisplay.Visible = true;
			Label5.Visible = true;
			lblCDate.Visible = true;
			Label2.Visible = true;
			lblVNo.Visible = true;
			lblVDT.Visible = true;
			Label3.Visible = true;
			lblAmt.Visible = true;
			lblAND.Visible = true;
			Label8.Visible = true;
			lblAmtADJ.Visible = true;
			lblSAmt.Visible = true;
			Label15.Visible = true;
			btnSearch.Visible = false;
			Label7.Visible = true;
			Label9.Visible = true;
			lblJVNO.Visible = true;
			//txtVDT.Visible=true;
			lblJVDT.Visible = true;
			Label20.Visible = true;
			lblCBPO.Visible = true;
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSave1.Attributes.Add("OnClick", "JavaScript:validate2();");
			if ((Convert.ToString(Request.Params["ACTION"]) == "" || Convert.ToString(Request.Params["ACTION"]) == null))
			{
				ACTION = "";
			}
			else
			{
				ACTION = Request.Params["ACTION"].ToString();
			}

			if (!(IsPostBack))
			{
				DataSet dsP2 = new DataSet();
				string stra2 = "select BANK_CD,BANK_NAME from T94_BANK order by BANK_NAME";
				OracleDataAdapter da2 = new OracleDataAdapter(stra2, conn1);
				OracleCommand myOracleCommand2 = new OracleCommand(stra2, conn1);
				//ListItem lst; 
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				lstBank.DataValueField = "BANK_CD";
				lstBank.DataTextField = "BANK_NAME";
				lstBank.DataSource = dsP2;
				lstBank.DataBind();
				conn1.Close();

				if (Session["Region"].ToString() == "N") { wRegion = "3007"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "3008"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "3009"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "3006"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "3066"; }
				lstACD.SelectedValue = wRegion.ToString();
				lstACD.Items.Remove(lstACD.SelectedItem);

				if (ACTION == "M")
				{
					lstBank.SelectedValue = Request.Params["BANK_CD"].ToString();
					txtCNO.Text = Request.Params["CHQ_NO"].ToString();
					txtCDT.Text = Request.Params["CHQ_DT"].ToString();
					ACCD = Request.Params["ACC_CD"].ToString();
					show_chq_details();
					show_jv_details();
					lblIUAMT.Text = txtAmt.Text;
					btnDelete.Visible = true;
					btnAdd.Visible = true;
					Panel1.Visible = true;
					txtRNo.Visible = true;
					txtRDT.Visible = true;
					Label17.Visible = true;
					Label12.Visible = true;
				}
				else
				{
					if ((Convert.ToString(Request.Params["CHQ_NO"]) == "" || Convert.ToString(Request.Params["CHQ_NO"]) == null))
					{
						Panel1.Visible = false;
						cvisiblefalse();
					}
					else
					{
						lstBank.SelectedValue = Request.Params["BANK_CD"].ToString();
						txtCNO.Text = Request.Params["CHQ_NO"].ToString();
						txtCDT.Text = Request.Params["CHQ_DT"].ToString();
						show_chq_details();
						Panel1.Visible = true;
					}
					btnDelete.Visible = false;
					btnAdd.Visible = false;
					txtRNo.Visible = false;
					txtRDT.Visible = false;
					Label17.Visible = false;
					Label12.Visible = false;
					Label5.Visible = true;
				}


			}
			if (Session["Role_CD"].ToString() == "4")
			{
				btnAdd.Visible = false;
				btnSave1.Visible = false;
				btnDelete.Visible = false;
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

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			show_chq_details();

		}

		public void generate()
		{
			try
			{
				string ss = Session["Region"] + txtVDT.Text.Substring(8, 2) + txtVDT.Text.Substring(3, 2);
				string str3 = "Select lpad(nvl(max(to_number(nvl(substr(VCHR_NO,6,8),0))),0)+1,3,'0') from T27_JV where substr(VCHR_NO,1,5)='" + ss + "'";
				OracleCommand myInsertCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				str3 = Convert.ToString(myInsertCommand.ExecuteScalar());
				conn1.Close();
				lblJVNO.Text = ss + str3;

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
		}
		void modify()
		{
			OracleTransaction myTrans = null;
			try
			{

				double camt = 0, amtadj = 0, susamt = 0;
				string str = "select AMOUNT,NVL(AMT_TRANSFERRED,0)AMT_TRANSFERRED,SUSPENSE_AMT from T25_RV_DETAILS where CHQ_NO='" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy') and BANK_CD=" + lstBank.SelectedValue;
				conn1.Open();
				OracleCommand myOracleCommand1 = new OracleCommand(str, conn1);
				OracleDataReader reader = myOracleCommand1.ExecuteReader();
				while (reader.Read())
				{
					camt = Convert.ToDouble(reader["AMOUNT"].ToString());
					amtadj = Convert.ToDouble(reader["AMT_TRANSFERRED"].ToString());
					susamt = Convert.ToDouble(reader["SUSPENSE_AMT"].ToString());
				}
				conn1.Close();
				conn1.Open();

				myTrans = conn1.BeginTransaction();
				if (ACTION == "")
				{
					string str3 = "update T25_RV_DETAILS SET AMT_TRANSFERRED=" + (amtadj + Convert.ToDouble(txtAmt.Text)) + ", SUSPENSE_AMT=" + (susamt - Convert.ToDouble(txtAmt.Text)) + " where CHQ_NO= '" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy') and BANK_CD=" + lstBank.SelectedValue + "";
					OracleCommand cmd1 = new OracleCommand(str3, conn1);
					cmd1.Transaction = myTrans;
					int sno = Convert.ToInt32(cmd1.ExecuteScalar());
					sno = sno + 1;

					string myInsertQuery = "INSERT INTO T29_JV_DETAILS(VCHR_NO,ACC_CD,AMOUNT,NARRATION,IU_ADV_NO,IU_ADV_DT)values('" + lblJVNO.Text + "','" + lstACD.SelectedValue + "'," + txtAmt.Text + ",'" + txtNarrat.Text + "','" + txtRNo.Text + "',to_date('" + txtRDT.Text + "','dd/mm/yyyy'))";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					myInsertCommand.Transaction = myTrans;
					myInsertCommand.ExecuteNonQuery();
					myTrans.Commit();
					conn1.Close();
				}
				else if (ACTION == "M")
				{

					string str3 = "update T25_RV_DETAILS SET AMT_TRANSFERRED=" + (amtadj - Convert.ToDouble(lblIUAMT.Text) + Convert.ToDouble(txtAmt.Text)) + ", SUSPENSE_AMT=" + (susamt + Convert.ToDouble(lblIUAMT.Text) - Convert.ToDouble(txtAmt.Text)) + " where CHQ_NO= '" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy') and BANK_CD=" + lstBank.SelectedValue;
					OracleCommand cmd1 = new OracleCommand(str3, conn1);
					cmd1.Transaction = myTrans;
					int sno = Convert.ToInt32(cmd1.ExecuteScalar());
					sno = sno + 1;

					string myInsertQuery = "update T29_JV_DETAILS set ACC_CD='" + lstACD.SelectedValue + "',AMOUNT=" + txtAmt.Text + ",NARRATION='" + txtNarrat.Text + "',IU_ADV_NO='" + txtRNo.Text + "',IU_ADV_DT=to_date('" + txtRDT.Text + "','dd/mm/yyyy') where VCHR_NO='" + lblJVNO.Text + "' and ACC_CD=" + lstACD.SelectedValue;
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					myInsertCommand.Transaction = myTrans;
					myInsertCommand.ExecuteNonQuery();
					myTrans.Commit();
					conn1.Close();

				}
			}
			catch (OracleException ex)
			{
				string str;
				str = ex.Message;
				myTrans.Rollback();
				string str1;
				if (ex.ErrorCode == 1)
				{
					str1 = "This Account Code Already Exist For the Given Cheque!!!";
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
			}
		}
		void save()
		{
			OracleTransaction myTrans = null;
			try
			{
				generate();

				double camt = 0, amtadj = 0, susamt = 0;
				string str = "select AMOUNT,NVL(AMT_TRANSFERRED,0)AMT_TRANSFERRED,SUSPENSE_AMT from T25_RV_DETAILS where CHQ_NO='" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy') and BANK_CD=" + lstBank.SelectedValue;
				conn1.Open();
				OracleCommand myOracleCommand1 = new OracleCommand(str, conn1);
				OracleDataReader reader = myOracleCommand1.ExecuteReader();
				while (reader.Read())
				{
					camt = Convert.ToDouble(reader["AMOUNT"].ToString());
					amtadj = Convert.ToDouble(reader["AMT_TRANSFERRED"].ToString());
					susamt = Convert.ToDouble(reader["SUSPENSE_AMT"].ToString());
				}
				conn1.Close();
				conn1.Open();
				myTrans = conn1.BeginTransaction();
				string myInsertQueryM = "INSERT INTO T27_JV values('" + lblJVNO.Text + "', to_date('" + lblJVDT.Text + "','dd/mm/yyyy'),'" + lblVNo.Text + "', " + lblSNO.Text + "," + lstBank.SelectedValue + ",'" + lblCNO.Text.Trim() + "',to_date('" + lblCDate.Text + "','dd/mm/yyyy'))";
				OracleCommand myInsertCommandM = new OracleCommand(myInsertQueryM);
				myInsertCommandM.Transaction = myTrans;
				myInsertCommandM.Connection = conn1;
				myInsertCommandM.ExecuteNonQuery();
				lblJVDT.Text = txtVDT.Text;
				txtVDT.Visible = false;

				string str3 = "update T25_RV_DETAILS SET AMT_TRANSFERRED=" + (amtadj + Convert.ToDouble(txtAmt.Text)) + ", SUSPENSE_AMT=" + (susamt - Convert.ToDouble(txtAmt.Text)) + " where CHQ_NO= '" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy') and BANK_CD=" + lstBank.SelectedValue + "";
				OracleCommand cmd1 = new OracleCommand(str3, conn1);
				cmd1.Transaction = myTrans;
				int sno = Convert.ToInt32(cmd1.ExecuteScalar());
				sno = sno + 1;

				string myInsertQuery = "INSERT INTO T29_JV_DETAILS(VCHR_NO,ACC_CD,AMOUNT,NARRATION,IU_ADV_NO,IU_ADV_DT)values('" + lblJVNO.Text + "','" + lstACD.SelectedValue + "'," + txtAmt.Text + ",'" + txtNarrat.Text + "','" + txtRNo.Text + "',to_date('" + txtRDT.Text + "','dd/mm/yyyy'))";
				OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
				myInsertCommand.Connection = conn1;
				myInsertCommand.Transaction = myTrans;
				myInsertCommand.ExecuteNonQuery();
				myTrans.Commit();
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
					str1 = "This Account Code Already Exist For the Given Cheque!!!";
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
			}
		}
		protected void btnSave1_Click(object sender, System.EventArgs e)
		{
			if (lblJVNO.Visible == false)
			{
				lblJVDT.Text = txtVDT.Text;
				save();
			}
			else
			{
				modify();
			}
			Response.Redirect("InterUnit_Transfer.aspx?CHQ_NO=" + lblCNO.Text + "&BANK_CD=" + lstBank.SelectedValue + "&CHQ_DT=" + lblCDate.Text);
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			OracleTransaction myTrans = null;
			
			try
			{
				double camt = 0, amtadj = 0, susamt = 0;
				string str = "select AMOUNT,NVL(AMT_TRANSFERRED,0)AMT_TRANSFERRED,SUSPENSE_AMT from T25_RV_DETAILS where CHQ_NO='" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy') and BANK_CD=" + lstBank.SelectedValue;
				conn1.Open();
				OracleCommand myOracleCommand1 = new OracleCommand(str, conn1);
				OracleDataReader reader = myOracleCommand1.ExecuteReader();
				while (reader.Read())
				{
					camt = Convert.ToDouble(reader["AMOUNT"].ToString());
					amtadj = Convert.ToDouble(reader["AMT_TRANSFERRED"].ToString());
					susamt = Convert.ToDouble(reader["SUSPENSE_AMT"].ToString());
				}
				conn1.Close();
				conn1.Open();
				myTrans = conn1.BeginTransaction();

				string str3 = "update T25_RV_DETAILS SET AMT_TRANSFERRED=" + (amtadj - Convert.ToDouble(txtAmt.Text)) + ", SUSPENSE_AMT=" + (susamt + Convert.ToDouble(txtAmt.Text)) + " where CHQ_NO= '" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy') and BANK_CD=" + lstBank.SelectedValue + "";
				OracleCommand cmd1 = new OracleCommand(str3, conn1);
				cmd1.Transaction = myTrans;
				int sno = Convert.ToInt32(cmd1.ExecuteScalar());
				sno = sno + 1;

				string myInsertQuery = "delete T29_JV_DETAILS where VCHR_NO='" + lblJVNO.Text + "' and ACC_CD=" + lstACD.SelectedValue;
				OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
				myInsertCommand.Connection = conn1;
				myInsertCommand.Transaction = myTrans;
				myInsertCommand.ExecuteNonQuery();
				myTrans.Commit();
				conn1.Close();

			}
			catch (OracleException ex)
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
			}
			Response.Redirect("InterUnit_Transfer.aspx?CHQ_NO=" + lblCNO.Text + "&BANK_CD=" + lstBank.SelectedValue + "&CHQ_DT=" + lblCDate.Text);
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("InterUnit_Transfer.aspx");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("InterUnit_Transfer.aspx?CHQ_NO=" + lblCNO.Text + "&BANK_CD=" + lstBank.SelectedValue + "&CHQ_DT=" + lblCDate.Text);
		}
	}
}
