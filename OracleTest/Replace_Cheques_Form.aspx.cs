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
	public partial class Replace_Cheques_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string CNO, CDT, BCD;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnUpdate.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.Params["CHQ_NO"]) == "" || (Convert.ToString(Request.Params["CHQ_NO"]) == null))
			{
				Panel1.Visible = true;
				Panel2.Visible = false;
			}
			else if (Convert.ToString(Request.Params["CHQ_NO"]) != "" && (Convert.ToString(Request.Params["CHQ_DT"]) != "" || Convert.ToString(Request.Params["BANK_CD"]) != ""))
			{
				CNO = Convert.ToString(Request.Params["CHQ_NO"]);
				CDT = Convert.ToString(Request.Params["CHQ_DT"]);
				BCD = Convert.ToString(Request.Params["BANK_CD"]);
				Panel1.Visible = false;
				Panel2.Visible = true;
			}
			if (Session["Role_CD"].ToString() == "4")
			{
				btnUpdate.Visible = false;

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
				lstBank1.DataValueField = "BANK_CD";
				lstBank1.DataTextField = "BANK_NAME";
				lstBank1.DataSource = dsP2;
				lstBank1.DataBind();
				conn1.Close();
				lstBank.Items.Insert(0, "");
				lstBank1.Items.Insert(0, "");
				if (Convert.ToString(Request.Params["CHQ_NO"]) == "" || (Convert.ToString(Request.Params["CHQ_NO"]) == null))
				{

				}
				else if (Convert.ToString(Request.Params["CHQ_NO"]) != "" && (Convert.ToString(Request.Params["CHQ_DT"]) == "" || Convert.ToString(Request.Params["BANK_CD"]) != ""))
				{
					show1();
					fillgrid();
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
		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				//string str1 = "select R.VCHR_NO,R.SNO,A.ACC_DESC,R.AMOUNT,(B.BPO_NAME||'/'||B.BPO_ADD||'/'||B.BPO_RLY)BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.SAMPLE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND VCHR_NO= '" + VNO + "'";
				string str1 = "select T26.BANK_CD,T26.CHQ_NO,to_char(T26.CHQ_DT,'dd/mm/yyyy')CHQ_DT,T26.BILL_NO,T22.BILL_AMOUNT,T26.AMOUNT_CLEARED,to_char(T26.POSTING_DT,'dd/mm/yyyy')POSTING_DT,NVL(T22.BILL_AMT_CLEARED,0)BILL_AMT_CLEARED,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME from T26_CHEQUE_POSTING T26, V22_BILL T22, T12_BILL_PAYING_OFFICER B, T03_CITY C where T26.BILL_NO=T22.BILL_NO and T22.BPO_CD=B.BPO_CD and B.BPO_CITY_CD=C.CITY_CD and BANK_CD=" + BCD + " AND CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy') order by T26.ROWID";
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

		void show1()
		{
			DataSet dsP = new DataSet();
			string str3 = "select R.VCHR_NO,R.SNO,R.AMOUNT,B.BANK_NAME,R.CHQ_NO,to_char(CHQ_DT,'dd/mm/yyyy')CHQ_DT from T25_RV_DETAILS R, T94_BANK B where R.BANK_CD=B.BANK_CD and R.BANK_CD=" + BCD + " AND R.CHQ_NO='" + CNO + "' and R.CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy')";
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			lblVCHRNO.Text = dsP.Tables[0].Rows[0]["VCHR_NO"].ToString();
			lblSNO.Text = dsP.Tables[0].Rows[0]["SNO"].ToString();
			lblCNO.Text = dsP.Tables[0].Rows[0]["CHQ_NO"].ToString();
			lblCDT.Text = dsP.Tables[0].Rows[0]["CHQ_DT"].ToString();
			lblCAMT.Text = dsP.Tables[0].Rows[0]["AMOUNT"].ToString();
			lblBank.Text = dsP.Tables[0].Rows[0]["BANK_NAME"].ToString();
			conn1.Close();


		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataSet dsP = new DataSet();
				string str3 = "select T25.VCHR_NO,to_char(T24.VCHR_DT,'dd/mm/yyyy')VCHR_DT,SNO,T25.BANK_CD,T94.BANK_NAME,T25.CHQ_NO,to_char(T25.CHQ_DT,'dd/mm/yyyy')CHQ_DT,NVL(T25.AMOUNT,0) AMOUNT,NVL(T25.AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED,NVL(T25.SUSPENSE_AMT,0)SUSPENSE_AMT,NVL2(T25.BPO_CD,(B.BPO_NAME||'/'||B.BPO_ADD||'/'||B.BPO_RLY),'')BPO,CASE_NO from T25_RV_DETAILS T25, T24_RV T24,T94_BANK T94,T12_BILL_PAYING_OFFICER B where T24.VCHR_NO=T25.VCHR_NO and T25.BANK_CD=T94.BANK_CD and T25.BPO_CD=B.BPO_CD(+) and substr(T25.VCHR_NO,1,1)='" + Session["Region"].ToString() + "'";
				if (lstBank.SelectedIndex != 0)
				{
					str3 = str3 + " and T25.BANK_CD=" + lstBank.SelectedValue;
				}
				if (txtEFTNO.Text.Trim() != "")
				{
					str3 = str3 + " and trim(UPPER(CHQ_NO)) like trim(upper('" + txtEFTNO.Text + "%'))";
				}
				if (txtEFTDT.Text.Trim() != "")
				{
					str3 = str3 + " and CHQ_DT=to_date('" + txtEFTDT.Text.Trim() + "','dd/mm/yyyy')";
				}
				if (txtAmt.Text.Trim() != "")
				{
					str3 = str3 + " and AMOUNT='" + txtAmt.Text + "'";
				}


				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("No Record Found!!!");
					grdEFT.Visible = false;
				}
				else
				{
					grdEFT.Visible = true;
					grdEFT.DataSource = dsP;
					grdEFT.DataBind();


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

		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{

			conn1.Open();

			DataSet dsPN = new DataSet();
			string str1 = "select AMOUNT,NVL(AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED from T25_RV_DETAILS where CHQ_NO='" + txtNCNO.Text.Trim() + "' AND CHQ_DT=to_date('" + txtNCDT.Text + "','dd/mm/yyyy') AND BANK_CD=" + lstBank1.SelectedValue;
			OracleDataAdapter daN = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommandN = new OracleCommand(str1, conn1);
			daN.SelectCommand = myOracleCommandN;
			daN.Fill(dsPN, "Table");

			DataSet dsPO = new DataSet();
			string str3 = "select AMOUNT,AMOUNT_ADJUSTED from T25_RV_DETAILS where BANK_CD=" + BCD + " AND CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy')";
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			da.SelectCommand = myOracleCommand;
			da.Fill(dsPO, "Table");

			conn1.Close();

			if (dsPN.Tables[0].Rows.Count != 0)
			{
				if (Convert.ToDouble(dsPN.Tables[0].Rows[0]["AMOUNT_ADJUSTED"].ToString()) == 0)
				{

					if (Convert.ToDouble(dsPN.Tables[0].Rows[0]["AMOUNT"].ToString()) == Convert.ToDouble(txtNCHQAMT.Text) && Convert.ToDouble(txtNCHQAMT.Text) >= Convert.ToDouble(dsPO.Tables[0].Rows[0]["AMOUNT"].ToString()))
					{
						conn1.Open();
						OracleTransaction myTrans = conn1.BeginTransaction();
						try
						{

							string myUpdateQuery = "Update T26_CHEQUE_POSTING SET CHQ_NO='" + txtNCNO.Text.Trim() + "',CHQ_DT=to_date('" + txtNCDT.Text + "','dd/mm/yyyy'),BANK_CD=" + lstBank1.SelectedValue + " where BANK_CD=" + BCD + " AND CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy')";
							OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
							myUpdateCommand.Connection = conn1;
							myUpdateCommand.Transaction = myTrans;
							myUpdateCommand.ExecuteNonQuery();

							string myDeleteQuery = "Delete T25_RV_DETAILS where BANK_CD=" + BCD + " AND CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy')";
							OracleCommand myDeleteCommand = new OracleCommand(myDeleteQuery);
							myDeleteCommand.Connection = conn1;
							myDeleteCommand.Transaction = myTrans;
							myDeleteCommand.ExecuteNonQuery();

							string myUpdateQuery2 = "Update T25_RV_DETAILS SET SUSPENSE_AMT=" + (Convert.ToDouble(dsPN.Tables[0].Rows[0]["AMOUNT"].ToString()) - Convert.ToDouble(dsPO.Tables[0].Rows[0]["AMOUNT_ADJUSTED"].ToString())) + ",AMOUNT_ADJUSTED=" + Convert.ToDouble(dsPO.Tables[0].Rows[0]["AMOUNT_ADJUSTED"].ToString()) + " where CHQ_NO='" + txtNCNO.Text.Trim() + "' AND CHQ_DT=to_date('" + txtNCDT.Text + "','dd/mm/yyyy') AND BANK_CD=" + lstBank1.SelectedValue;
							OracleCommand myUpdateCommand2 = new OracleCommand(myUpdateQuery2);
							myUpdateCommand2.Connection = conn1;
							myUpdateCommand2.Transaction = myTrans;
							myUpdateCommand2.ExecuteNonQuery();
							myTrans.Commit();
							conn1.Close();
							DisplayAlert("Your Record has been updated!!!");
						}
						catch (Exception ex)
						{
							string str;
							str = ex.Message;
							myTrans.Rollback();
							string str2 = str.Replace("\n", "");
							Response.Redirect("Error_Form.aspx?err=" + str2);

						}
						finally
						{
							conn1.Close();
						}
					}
					else
					{
						DisplayAlert("The New CHQ Amount cannot be less then Old CHQ Amount!!! ");
					}
				}
				else
				{
					DisplayAlert("This Check is already adjusted !!! ");

				}
			}
			else
			{
				DisplayAlert("Their is no Check Present With the Given Details !!! ");
			}
		}


	}
}