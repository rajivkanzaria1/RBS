using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Rly_Online_Check_Posting_Form
{
	public partial class Rly_Online_Check_Posting_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		public string BNO, CNO, CDT, BCD, PDT, Action;
		double AMTCLR;
		protected System.Web.UI.WebControls.TextBox txtDtOfReciept;
		protected System.Web.UI.WebControls.TextBox txtBKNO;


		protected void Page_Load(object sender, System.EventArgs e)
		{


			btnSearch.Attributes.Add("OnClick", "JavaScript:validate();");
			btnBillsCleared.Attributes.Add("OnClick", "JavaScript:validate2();");


			if ((Convert.ToString(Request.Params["ACTION"]) == "" || Convert.ToString(Request.Params["ACTION"]) == null) && (Convert.ToString(Request.Params["CHQ_NO"]) == "" || Convert.ToString(Request.Params["CHQ_NO"]) == null) && (Convert.ToString(Request.Params["CHQ_NO"]) == "" || Convert.ToString(Request.Params["CHQ_NO"]) == null))
			{
				Action = "";
				BNO = "";
				CNO = "";
				PDT = "";
				AMTCLR = 0;

			}
			else if (Convert.ToString(Request.Params["CHQ_NO"]) != "" && (Convert.ToString(Request.Params["BILL_NO"]) == "" || Convert.ToString(Request.Params["BILL_NO"]) == null))
			{
				CNO = Convert.ToString(Request.Params["CHQ_NO"]);
				CDT = Convert.ToString(Request.Params["CHQ_DT"]);
				BCD = Convert.ToString(Request.Params["BANK_CD"]);
				PDT = Convert.ToString(Request.Params["POSTING_DT"]);
				BNO = "";
				AMTCLR = 0;
				Action = "";
			}
			else if (Convert.ToString(Request.Params["CHQ_NO"]) != "" && (Convert.ToString(Request.Params["BILL_NO"]) != "" || Convert.ToString(Request.Params["BILL_NO"]) != null))
			{
				BNO = Convert.ToString(Request.Params["BILL_NO"]);
				CNO = Convert.ToString(Request.Params["CHQ_NO"]);
				CDT = Convert.ToString(Request.Params["CHQ_DT"]);
				BCD = Convert.ToString(Request.Params["BANK_CD"]);
				AMTCLR = Convert.ToDouble(Request.Params["AMOUNT_CLEARED"]);

				conn1.Open();
				OracleCommand cmdBNO = new OracleCommand("select BILL_NO from T26_CHEQUE_POSTING where BANK_CD=" + BCD + " AND CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy') AND BILL_NO='" + BNO + "'", conn1);
				string chk_bno = Convert.ToString(cmdBNO.ExecuteScalar());
				conn1.Close();

				if (chk_bno == "")
				{
					Action = "";
				}
				else
				{
					Action = "M";
				}
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
				lstBank1.DataValueField = "BANK_CD";
				lstBank1.DataTextField = "BANK_NAME";
				lstBank1.DataSource = dsP2;
				lstBank1.DataBind();
				conn1.Close();







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


		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select T22.BILL_NO,T22.INVOICE_NO,R.BPO_RLY,T22.BILL_AMOUNT,NET_AMT AMT_PASSED, CO7_NO, to_char(CO7_DATE,'dd/mm/yyyy')CO7_DT,to_char(PAYMENT_DT,'dd/mm/yyyy')PAYMENT_DT,NVL(T22.BILL_AMT_CLEARED,0)BILL_AMT_CLEARED,T22.BPO_CD from V22_BILL T22, RITES_BILL_DTLS R where  T22.BILL_NO=R.BILL_NO  and R.BPO_TYPE='R'  and R.PAYMENT_DT BETWEEN to_date('" + frmDt.Text + "','dd/mm/yyyy') AND to_date('" + toDt.Text + "','dd/mm/yyyy') AND R.CO6_STATUS='A' AND R.BPO_RLY='" + lblBPORly.Text + "' AND NVL(R.PASSED_AMT,0)>0 AND NVL(T22.AMOUNT_RECEIVED,0)=0 AND R.REGION_CODE='" + Session["Region"].ToString() + "' order by PAYMENT_DT,BILL_NO";
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


		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			show1();


		}

		//fillgrid();



		void show1()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str3 = "select T24.VCHR_NO,to_char(T24.VCHR_DT,'dd/mm/yyyy') VCHR_DT,T25.CHQ_NO,to_char(T25.CHQ_DT,'dd/mm/yyyy')CHQ_DT,T25.BANK_CD,NVL2(T25.BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),T25.NARRATION) BPO,NVL(T25.AMOUNT,0) AMOUNT,NVL(T25.AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED,NVL(AMT_TRANSFERRED,0)AMT_TRANSFERRED,NVL(T25.SUSPENSE_AMT,0)SUSPENSE_AMT,T25.ACC_CD,B.BPO_RLY from T24_RV T24,T25_RV_DETAILS T25, T12_BILL_PAYING_OFFICER B,T03_CITY C where T24.VCHR_NO= T25.VCHR_NO AND T25.BPO_CD=B.BPO_CD(+) AND B.BPO_CITY_CD=C.CITY_CD(+) AND T25.CHQ_NO='" + txtCNO.Text + "' AND CHQ_DT=to_date('" + txtCDT.Text + "','dd/mm/yyyy') AND T25.BANK_CD=" + lstBank1.SelectedValue + " and substr(T24.VCHR_NO,1,1)='" + Session["Region"] + "'";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("InValid Cheque No. Or Bank");
				}
				else
				{
					lblVNo.Text = dsP.Tables[0].Rows[0]["VCHR_NO"].ToString();
					lblVDT.Text = dsP.Tables[0].Rows[0]["VCHR_DT"].ToString();
					lblCNO.Text = dsP.Tables[0].Rows[0]["CHQ_NO"].ToString();
					lstBank1.SelectedValue = dsP.Tables[0].Rows[0]["BANK_CD"].ToString();
					lblBank.Text = lstBank1.SelectedItem.Text;
					lblCDate.Text = dsP.Tables[0].Rows[0]["CHQ_DT"].ToString();
					lblAmt.Text = dsP.Tables[0].Rows[0]["AMOUNT"].ToString();
					lblAmtADJ.Text = dsP.Tables[0].Rows[0]["AMOUNT_ADJUSTED"].ToString();
					lblTransAmt.Text = dsP.Tables[0].Rows[0]["AMT_TRANSFERRED"].ToString();
					lblSAmt.Text = dsP.Tables[0].Rows[0]["SUSPENSE_AMT"].ToString();
					txtSAmt.Text = lblSAmt.Text;
					lblCBPO.Text = dsP.Tables[0].Rows[0]["BPO"].ToString();
					lblBPORly.Text = dsP.Tables[0].Rows[0]["BPO_RLY"].ToString();
					Label5.Visible = true;
					lblCDate.Visible = true;
					Label2.Visible = true;
					lblVNo.Visible = true;
					Label6.Visible = true;
					lblVDT.Visible = true;
					Label3.Visible = true;
					lblAmt.Visible = true;
					Label8.Visible = true;
					lblAmtADJ.Visible = true;
					lblTransAmt.Visible = true;
					Label26.Visible = true;
					lblSAmt.Visible = true;
					Label15.Visible = true;
					Label20.Visible = true;
					lblCBPO.Visible = true;
					txtCNO.Visible = false;
					lstBank1.Visible = false;
					btnSearch.Visible = false;
					txtCDT.Visible = false;

					if (dsP.Tables[0].Rows[0]["ACC_CD"].ToString() == "2709")
					{
						Label26.Text = "Un-Adjusted Advance";
					}
					else
					{
						Label26.Text = "Suspense Amount";
					}

					string str = "select NVL(count(*),0) from T26_CHEQUE_POSTING where CHQ_NO='" + lblCNO.Text + "' and BANK_CD=" + lstBank1.SelectedValue;
					OracleCommand myOracleCommand1 = new OracleCommand(str, conn1);
					int i = Convert.ToInt32(myOracleCommand1.ExecuteScalar());
					if (i > 0)
					{
						conn1.Close();
						fillgrid();
					}
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



		private void btnCancel_Click(object sender, System.EventArgs e)
		{


			Response.Redirect("Rly_Online_Check_Posting_Form.aspx");
		}



		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleTransaction myTrans = null;
			try
			{

				OracleCommand cmdDT = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmdDT.ExecuteScalar());
				conn1.Close();
				conn1.Open();

				myTrans = conn1.BeginTransaction();

				int bill_amt = 0;
				string bill_no = "", bpo = "";
				double pass_amt = 0, amtadj = 0;
				foreach (DataGridItem di in grdVDt.Items)
				{
					// Make sure this is an item and not the header or footer.

					bool w_chk_bno = false;
					if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
					{
						w_chk_bno = Convert.ToBoolean(((CheckBox)di.FindControl("chkBNO")).Checked);

						if (w_chk_bno == true)
						{
							bill_no = Convert.ToString(di.Cells[0].Text);
							bill_amt = Convert.ToInt32(di.Cells[2].Text);
							pass_amt = Convert.ToDouble(di.Cells[6].Text);
							bpo = Convert.ToString(di.Cells[8].Text);

							string myInsertQueryM = "INSERT INTO T26_CHEQUE_POSTING(BANK_CD,CHQ_NO,CHQ_DT,BILL_NO,BILL_AMOUNT,AMOUNT_CLEARED,POSTING_DT,BPO_CD,USER_ID,DATETIME) values('" + lstBank1.SelectedValue + "', '" + lblCNO.Text + "',to_date('" + lblCDate.Text + "','dd/mm/yyyy'),'" + bill_no + "'," + bill_amt + "," + pass_amt + ",to_date('" + ss.Substring(0, 10) + "','dd/mm/yyyy'),'" + bpo + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
							OracleCommand myInsertCommandM = new OracleCommand(myInsertQueryM);
							myInsertCommandM.Transaction = myTrans;
							myInsertCommandM.Connection = conn1;
							myInsertCommandM.ExecuteNonQuery();

							amtadj = amtadj + pass_amt;


							string str3 = "update T22_BILL set AMOUNT_RECEIVED=" + pass_amt + ", BILL_AMT_CLEARED=NVL(BILL_AMT_CLEARED,0)+" + pass_amt + " where BILL_NO='" + bill_no + "'";
							OracleCommand cmd3 = new OracleCommand(str3, conn1);
							cmd3.Transaction = myTrans;
							cmd3.ExecuteNonQuery();


						}


					}

				}
				if (amtadj <= Convert.ToDouble(lblSAmt.Text))
				{
					string str2 = "update T25_RV_DETAILS set AMOUNT_ADJUSTED=" + amtadj + ", SUSPENSE_AMT=NVL(SUSPENSE_AMT,0)-" + amtadj + " where BANK_CD=" + lstBank1.SelectedValue + " and CHQ_NO='" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy')";
					OracleCommand cmd2 = new OracleCommand(str2, conn1);
					cmd2.Transaction = myTrans;
					cmd2.ExecuteNonQuery();
					myTrans.Commit();
					conn1.Close();
					lblAmtADJ.Text = amtadj.ToString();
					lblSAmt.Text = Convert.ToString(Convert.ToDouble(lblSAmt.Text) - amtadj);
					DisplayAlert("Your Postings are Updated!!!");
				}
				else
				{
					myTrans.Rollback();
					conn1.Close();
					DisplayAlert("Sorry, Posting Cannot be Save as Posted Amount is greater then the Suspense Amount !!!");
				}

				//As desired by GGM/I/NR on 12-11-2018

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				myTrans.Rollback();
				DisplayAlert("Your Record Has Not Been Saved, So Try Again!!!");
			}
			finally
			{
				conn1.Close();
			}


		}

		protected void btnBillsCleared_Click(object sender, System.EventArgs e)
		{
			fillgrid();
		}




	}
}