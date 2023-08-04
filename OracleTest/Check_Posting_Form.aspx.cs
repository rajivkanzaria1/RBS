using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Check_Posting_Form
{
	public partial class Check_Posting_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		public string BNO, CNO, CDT, BCD, PDT, Action;
		double AMTCLR;
		protected System.Web.UI.WebControls.TextBox txtDtOfReciept;
		protected System.Web.UI.WebControls.TextBox txtBKNO;


		protected void Page_Load(object sender, System.EventArgs e)
		{

			btnDel2.Attributes.Add("OnClick", "JavaScript:del();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate();");
			btnBDetails.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnSave1.Attributes.Add("OnClick", "JavaScript:validate2();");
			//			

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

				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'DD/MM/YYYY') from dual", conn1);
				txtPDT.Text = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();



				try
				{

					if (Action == "" && BNO == "" && CNO == "")
					{
						//btnDelete.Visible =false;
						//btnInsDt.Visible=false;
						Panel.Visible = false;
						Label5.Visible = true;
						lblCDate.Visible = false;
						txtCDT.Visible = true;
						Label2.Visible = false;
						lblVNo.Visible = false;
						Label6.Visible = false;
						lblVDT.Visible = false;
						Label3.Visible = false;
						lblAmt.Visible = false;
						Label8.Visible = false;
						lblAmtADJ.Visible = false;
						rbs.SetFocus(lstBank1);
						lblSAmt.Visible = false;
						Label15.Visible = false;
						Label26.Visible = false;
						btnSearch.Visible = true;

						Label20.Visible = false;
						lblCBPO.Visible = false;

					}
					else if (BNO != "" && CNO != "" && Action == "M")
					{
						Panel.Visible = true;
						Label5.Visible = true;
						lblCDate.Visible = true;
						txtCDT.Visible = false;
						Label2.Visible = true;
						lblVNo.Visible = true;
						Label6.Visible = true;
						lblVDT.Visible = true;
						Label3.Visible = true;
						lblAmt.Visible = true;
						btnSearch.Visible = false;
						Label9.Visible = true;
						lblBDT.Visible = true;
						Label7.Visible = true;
						lblBAmt.Visible = true;
						Label10.Visible = true;
						lblBAmtRec.Visible = true;
						Label13.Visible = true;
						Label16.Visible = true;
						lblTDS.Visible = true;
						//lblAmtToRec.Visible=true;
						Label14.Visible = true;
						txtAmtTOClear.Visible = true;
						lblSAmt.Visible = true;
						Label20.Visible = true;
						lblCBPO.Visible = true;
						Label15.Visible = true;
						Label18.Visible = true;
						Label19.Visible = true;
						txtRetention.Visible = true;
						txtWriteOffAmt.Visible = true;
						Label17.Visible = true;
						txtPDT.Visible = true;
						txtAmtToRec.Visible = true;
						Label21.Visible = true;
						lblTAmtCleared.Visible = true;
						btnBDetails.Visible = false;
						btnSave1.Visible = true;
						//						btnDel2.Visible=true; As Per Auditors Dated 19-Dec-2011
						Label22.Visible = true;
						Label23.Visible = true;
						Label24.Visible = true;
						Label25.Visible = true;

						lblCSNO.Visible = true;
						lblBKNO.Visible = true;
						lblSETNO.Visible = true;
						lblBPO.Visible = true;
						show();
						lblBNO.Text = txtBNO.Text;
						txtBNO.Visible = false;
						lblBNO.Visible = true;
						txtCNO.Text = CNO;
						lstBank1.SelectedValue = BCD;
						txtCDT.Text = CDT;
						show1();
						rbs.SetFocus(txtWriteOffAmt);
					}
					else if (BNO != "" && CNO != "" && Action == "")
					{
						Panel.Visible = true;
						Label5.Visible = true;
						lblCDate.Visible = true;
						txtCDT.Visible = false;
						Label2.Visible = true;
						lblVNo.Visible = true;
						Label6.Visible = true;
						lblVDT.Visible = true;
						Label3.Visible = true;
						lblAmt.Visible = true;
						btnSearch.Visible = false;
						Label9.Visible = true;
						lblBDT.Visible = true;
						Label7.Visible = true;
						lblBAmt.Visible = true;
						Label10.Visible = true;
						lblBAmtRec.Visible = true;
						Label13.Visible = true;
						Label16.Visible = true;
						lblTDS.Visible = true;
						//lblAmtToRec.Visible=true;
						Label14.Visible = true;
						txtAmtTOClear.Visible = true;
						lblSAmt.Visible = true;
						Label20.Visible = true;
						lblCBPO.Visible = true;
						Label15.Visible = true;
						Label18.Visible = true;
						Label19.Visible = true;
						txtRetention.Visible = true;
						txtWriteOffAmt.Visible = true;
						Label17.Visible = true;
						txtPDT.Visible = true;
						txtAmtToRec.Visible = true;
						Label21.Visible = true;
						lblTAmtCleared.Visible = true;
						btnBDetails.Visible = false;
						btnSave1.Visible = true;
						//						btnDel2.Visible=true; As Per Auditors Dated 19-Dec-2011
						Label22.Visible = true;
						Label23.Visible = true;
						Label24.Visible = true;
						Label25.Visible = true;

						lblCSNO.Visible = true;
						lblBKNO.Visible = true;
						lblSETNO.Visible = true;
						lblBPO.Visible = true;
						txtBNO.Text = BNO;
						lblBNO.Text = txtBNO.Text;
						txtBNO.Visible = false;
						lblBNO.Visible = true;
						txtCNO.Text = CNO;
						lstBank1.SelectedValue = BCD;
						txtCDT.Text = CDT;
						show1();
						new_bill_details();
						Action = "";
						rbs.SetFocus(txtWriteOffAmt);
					}
					else if (BNO == "" && CNO != "")
					{
						if (PDT != "")
						{
							txtPDT.Text = PDT;
						}
						txtCNO.Text = CNO;
						lstBank1.SelectedValue = BCD;
						txtCDT.Text = CDT;
						show1();

						Panel.Visible = true;

						txtBNO.Visible = true;
						btnBDetails.Visible = true;

						Label5.Visible = true;
						lblCDate.Visible = true;
						txtCDT.Visible = false;
						Label2.Visible = true;
						lblVNo.Visible = true;
						Label6.Visible = true;
						lblVDT.Visible = true;
						Label3.Visible = true;
						lblAmt.Visible = true;
						btnSearch.Visible = false;

						Label9.Visible = false;
						lblBDT.Visible = false;
						Label7.Visible = false;
						lblBAmt.Visible = false;
						Label10.Visible = false;
						lblBAmtRec.Visible = false;
						Label13.Visible = false;
						Label16.Visible = false;
						lblTDS.Visible = false;
						//lblAmtToRec.Visible=false;
						Label14.Visible = false;
						txtAmtTOClear.Visible = false;
						Label18.Visible = false;
						Label19.Visible = false;
						txtRetention.Visible = false;
						txtWriteOffAmt.Visible = false;
						Label17.Visible = false;
						txtPDT.Visible = false;
						txtAmtToRec.Visible = false;
						Label21.Visible = false;
						lblTAmtCleared.Visible = false;
						Label22.Visible = false;
						Label23.Visible = false;
						Label24.Visible = false;
						Label25.Visible = false;

						lblCSNO.Visible = false;
						lblBKNO.Visible = false;
						lblSETNO.Visible = false;
						lblBPO.Visible = false;

						lblSAmt.Visible = true;
						Label15.Visible = true;
						Label20.Visible = true;
						lblCBPO.Visible = true;
						btnSave1.Visible = true;
						btnDel2.Visible = false;


						lblBNO.Visible = false;

						rbs.SetFocus(txtBNO);

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

			if (Session["Role_CD"].ToString() == "4")
			{
				btnSave1.Visible = false;
				btnDel2.Visible = false;

			}
		}


		void show()
		{
			string str1 = "select BILL_NO,BILL_AMOUNT,AMOUNT_CLEARED,to_char(POSTING_DT,'dd/mm/yyyy')POSTING_DT from T26_CHEQUE_POSTING where BANK_CD=" + BCD + " AND CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy') AND BILL_NO='" + BNO + "'";
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			txtBNO.Text = dsP.Tables[0].Rows[0]["BILL_NO"].ToString();
			lblBAmt.Text = dsP.Tables[0].Rows[0]["BILL_AMOUNT"].ToString();
			txtBAmt.Text = lblBAmt.Text;
			txtAmtTOClear.Text = dsP.Tables[0].Rows[0]["AMOUNT_CLEARED"].ToString();
			txtPDT.Text = dsP.Tables[0].Rows[0]["POSTING_DT"].ToString();

			string str2 = "select to_char(BILL_DT,'dd/mm/yyyy')BILL_DT,CASE_NO,BK_NO,SET_NO,(BPO_CD||'-'||BPO_NAME||'/'||BPO_RLY||'/'||NVL2(BPO_ADD,BPO_ADD||'/','')||BPO_CITY) BPO_NAME,BPO_CD,AMOUNT_RECEIVED,NVL(BILL_AMT_CLEARED,0)BILL_AMT_CLEARED,NVL(TDS,0) + NVL(TDS_SGST,0) + NVL(TDS_CGST,0) + NVL(TDS_IGST,0) TDS, NVL(RETENTION_MONEY,0)RETENTION_MONEY, NVL(WRITE_OFF_AMT,0)WRITE_OFF_AMT, NVL(CNOTE_AMOUNT,0)CNOTE_AMT  from V22_BILL where BILL_NO='" + BNO + "'";
			OracleCommand cmd = new OracleCommand(str2, conn1);
			OracleDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				lblBDT.Text = reader["BILL_DT"].ToString();
				lblBAmtRec.Text = reader["AMOUNT_RECEIVED"].ToString();
				lblTAmtCleared.Text = reader["BILL_AMT_CLEARED"].ToString();
				txtBAmtRec.Text = lblBAmtRec.Text;
				lblTDS.Text = reader["TDS"].ToString();
				txtRetention.Text = reader["RETENTION_MONEY"].ToString();
				txtCNote_Amt.Text = reader["CNOTE_AMT"].ToString();
				txtWriteOffAmt.Text = reader["WRITE_OFF_AMT"].ToString();
				lblAmtToRec.Text = Convert.ToString(Convert.ToDouble(lblBAmt.Text) - (Convert.ToDouble(lblBAmtRec.Text) + Convert.ToDouble(lblTDS.Text) + Convert.ToDouble(txtRetention.Text) + Convert.ToDouble(txtWriteOffAmt.Text) + Convert.ToDouble(txtCNote_Amt.Text)));
				txtAmtToRec.Text = Convert.ToString(lblAmtToRec.Text);
				lblCSNO.Text = reader["CASE_NO"].ToString();
				lblBKNO.Text = reader["BK_NO"].ToString();
				lblSETNO.Text = reader["SET_NO"].ToString();
				txtBPOCD.Text = reader["BPO_CD"].ToString();
				lblBPO.Text = reader["BPO_NAME"].ToString();

			}
			conn1.Close();

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
				//string str1 = "select R.VCHR_NO,R.SNO,A.ACC_DESC,R.AMOUNT,(B.BPO_NAME||'/'||B.BPO_ADD||'/'||B.BPO_RLY)BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.SAMPLE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND VCHR_NO= '" + VNO + "'";
				string str1 = "select T26.BANK_CD,T26.CHQ_NO,to_char(T26.CHQ_DT,'dd/mm/yyyy')CHQ_DT,T26.BILL_NO,T22.BILL_AMOUNT,T26.AMOUNT_CLEARED,to_char(T26.POSTING_DT,'dd/mm/yyyy')POSTING_DT,NVL(T22.BILL_AMT_CLEARED,0)BILL_AMT_CLEARED,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME from T26_CHEQUE_POSTING T26, V22_BILL T22, T12_BILL_PAYING_OFFICER B, T03_CITY C where T26.BILL_NO=T22.BILL_NO and T22.BPO_CD=B.BPO_CD and B.BPO_CITY_CD=C.CITY_CD and BANK_CD=" + lstBank1.SelectedValue + " AND CHQ_NO='" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy') order by T26.DATETIME";
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
		protected void btnSave1_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleCommand cmdDT = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string dt = Convert.ToString(cmdDT.ExecuteScalar());
			conn1.Close();

			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();

			try
			{
				if (Action == "" || Action == null)
				{
					if ((Convert.ToDouble(lblAmt.Text) - (Convert.ToDouble(lblAmtADJ.Text) + Convert.ToDouble(lblTransAmt.Text))) > 0 && (Convert.ToDouble(lblAmt.Text) - (Convert.ToDouble(lblAmtADJ.Text) + Convert.ToDouble(lblTransAmt.Text))) >= (Convert.ToDouble(txtAmtTOClear.Text)) && Convert.ToDouble(txtAmtTOClear.Text) <= Convert.ToDouble(txtAmtToRec.Text))
					{
						string myInsertQueryM = "INSERT INTO T26_CHEQUE_POSTING(BANK_CD,CHQ_NO,CHQ_DT,BILL_NO,BILL_AMOUNT,AMOUNT_CLEARED,POSTING_DT,BPO_CD,USER_ID,DATETIME) values('" + lstBank1.SelectedValue + "', '" + lblCNO.Text + "',to_date('" + lblCDate.Text + "','dd/mm/yyyy'),'" + txtBNO.Text + "'," + lblBAmt.Text + "," + txtAmtTOClear.Text + ",to_date('" + txtPDT.Text + "','dd/mm/yyyy'),'" + txtBPOCD.Text + "','" + Session["Uname"].ToString() + "',to_date('" + dt + "','dd/mm/yyyy-HH24:MI:SS'))";
						OracleCommand myInsertCommandM = new OracleCommand(myInsertQueryM);
						myInsertCommandM.Transaction = myTrans;
						myInsertCommandM.Connection = conn1;
						myInsertCommandM.ExecuteNonQuery();


						//						string str1 = "select nvl(AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED, NVL(AMT_TRANSFERRED,0)AMT_TRANSFERRED from T25_RV_DETAILS where BANK_CD="+lstBank1.SelectedValue+" and CHQ_NO='"+lblCNO.Text+"' and CHQ_DT=to_date('"+lblCDate.Text+"','dd/mm/yyyy')"; 
						//						OracleCommand cmd = new OracleCommand(str1,conn1);
						//						cmd.Transaction=myTrans;
						//						OracleDataReader reader=cmd.ExecuteReader();
						//						double amtadj=0,amttrans=0;
						//						while(reader.Read())
						//						{
						//							amtadj=Convert.ToDouble(reader["AMOUNT_ADJUSTED"].ToString());
						//							amttrans=Convert.ToDouble(reader["AMT_TRANSFERRED"].ToString());
						//						}

						//double amtadj=Convert.ToDouble(cmd.ExecuteScalar());
						double amtadj = Convert.ToDouble(lblAmtADJ.Text);
						amtadj = amtadj + Convert.ToDouble(txtAmtTOClear.Text);
						lblBAmtRec.Text = Convert.ToString(Convert.ToDouble(lblBAmtRec.Text) + Convert.ToDouble(txtAmtTOClear.Text));
						txtBAmtRec.Text = lblBAmtRec.Text;
						lblAmtToRec.Text = Convert.ToString(Convert.ToDouble(lblAmtToRec.Text) - (Convert.ToDouble(txtAmtTOClear.Text) + Convert.ToDouble(lblTDS.Text) + Convert.ToDouble(txtRetention.Text) + Convert.ToDouble(txtWriteOffAmt.Text) + Convert.ToDouble(txtCNote_Amt.Text)));
						txtAmtToRec.Text = Convert.ToString(lblAmtToRec.Text);
						//lblSAmt.Text=Convert.ToString(Convert.ToDouble(lblAmt.Text)-amtadj);
						lblSAmt.Text = Convert.ToString(Convert.ToDouble(lblSAmt.Text) - Convert.ToDouble(txtAmtTOClear.Text));
						txtSAmt.Text = lblSAmt.Text;
						string str2 = "update T25_RV_DETAILS set AMOUNT_ADJUSTED=" + amtadj + ", SUSPENSE_AMT=" + lblSAmt.Text + " where BANK_CD=" + lstBank1.SelectedValue + " and CHQ_NO='" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy')";
						OracleCommand cmd2 = new OracleCommand(str2, conn1);
						cmd2.Transaction = myTrans;
						cmd2.ExecuteNonQuery();

						lblAmtADJ.Text = amtadj.ToString();

						string str3 = "update T22_BILL set AMOUNT_RECEIVED=" + lblBAmtRec.Text + ",WRITE_OFF_AMT=" + txtWriteOffAmt.Text + ", BILL_AMT_CLEARED=" + Convert.ToString(Convert.ToDouble(lblBAmtRec.Text) + Convert.ToDouble(lblTDS.Text) + Convert.ToDouble(txtRetention.Text) + Convert.ToDouble(txtWriteOffAmt.Text) + Convert.ToDouble(txtCNote_Amt.Text)) + " where BILL_NO='" + txtBNO.Text + "'";
						OracleCommand cmd3 = new OracleCommand(str3, conn1);
						cmd3.Transaction = myTrans;
						cmd3.ExecuteNonQuery();
						myTrans.Commit();
						conn1.Close();
						Response.Redirect("Check_Posting_Form.aspx?CHQ_NO=" + lblCNO.Text + "&CHQ_DT=" + lblCDate.Text + "&BANK_CD=" + lstBank1.SelectedValue + "&POSTING_DT=" + txtPDT.Text);
						//						fillgrid();
						//						txtBNO.Text="";
						//						btnBDetails.Visible=true;
						//						Label9.Visible=false;
						//						lblBDT.Visible=false;
						//						Label7.Visible=false;
						//						lblBAmt.Visible=false;
						//						Label10.Visible=false;
						//						lblBAmtRec.Visible=false;
						//						Label13.Visible=false;
						//						lblAmtToRec.Visible=false;
						//						Label14.Visible=false;
						//						txtAmtTOClear.Visible=false;
					}
					else
					{
						DisplayAlert("Suspense Amount of Cheque is Zero or Amount To be Cleared is greater then the (Check Amount - (Amount Adjusted + Amount Transferred)) OR Amount To be Cleared is Greater then the Bill Amount To Recover!!!");

					}
				}
				else if (Action == "M")
				{
					//if((Convert.ToDouble(lblAmt.Text)-Convert.ToDouble(lblAmtADJ.Text)+AMTCLR)>=(Convert.ToDouble(txtAmtTOClear.Text)) && Convert.ToDouble(txtAmtTOClear.Text)<=(Convert.ToDouble(lblAmtToRec.Text)+AMTCLR))
					if ((Convert.ToDouble(lblAmt.Text) - (Convert.ToDouble(lblAmtADJ.Text) + Convert.ToDouble(lblTransAmt.Text)) + AMTCLR) >= (Convert.ToDouble(txtAmtTOClear.Text)))
					{
						string myUpdateQueryM = "UPDATE T26_CHEQUE_POSTING set AMOUNT_CLEARED=" + txtAmtTOClear.Text + ", POSTING_DT=to_date('" + txtPDT.Text + "','dd/mm/yyyy'),USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + dt + "','dd/mm/yyyy-HH24:MI:SS') where BANK_CD=" + BCD + " AND CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy') AND BILL_NO='" + BNO + "'";
						OracleCommand myUpdateCommandM = new OracleCommand(myUpdateQueryM);
						myUpdateCommandM.Transaction = myTrans;
						myUpdateCommandM.Connection = conn1;
						myUpdateCommandM.ExecuteNonQuery();


						//						string str1 = "select nvl(AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED,NVL(AMT_TRANSFERRED,0) AMT_TRANSFERRED from T25_RV_DETAILS where BANK_CD="+lstBank1.SelectedValue+" and CHQ_NO='"+lblCNO.Text+"' and CHQ_DT=to_date('"+lblCDate.Text+"','dd/mm/yyyy')"; 
						//						OracleCommand cmd = new OracleCommand(str1,conn1);
						//						cmd.Transaction=myTrans;
						//						OracleDataReader reader=cmd.ExecuteReader();
						double amtadj = Convert.ToDouble(lblAmtADJ.Text);
						//						while(reader.Read())
						//						{
						//							amtadj=Convert.ToDouble(reader["AMOUNT_ADJUSTED"].ToString());
						//							amttrans=Convert.ToDouble(reader["AMT_TRANSFERRED"].ToString());
						//						}
						amtadj = amtadj - AMTCLR;
						amtadj = amtadj + Convert.ToDouble(txtAmtTOClear.Text);

						lblBAmtRec.Text = Convert.ToString(Convert.ToDouble(lblBAmtRec.Text) - AMTCLR);
						lblBAmtRec.Text = Convert.ToString(Convert.ToDouble(lblBAmtRec.Text) + Convert.ToDouble(txtAmtTOClear.Text));
						txtBAmtRec.Text = lblBAmtRec.Text;
						lblAmtToRec.Text = Convert.ToString(Convert.ToDouble(lblBAmt.Text) - (Convert.ToDouble(lblBAmtRec.Text) + Convert.ToDouble(lblTDS.Text) + Convert.ToDouble(txtRetention.Text) + Convert.ToDouble(txtWriteOffAmt.Text) + Convert.ToDouble(txtCNote_Amt.Text)));
						txtAmtToRec.Text = Convert.ToString(lblAmtToRec.Text);
						lblSAmt.Text = Convert.ToString((Convert.ToDouble(lblSAmt.Text) + AMTCLR) - Convert.ToDouble(txtAmtTOClear.Text));
						//lblSAmt.Text=Convert.ToString(Convert.ToDouble(lblAmt.Text)-amtadj);
						txtSAmt.Text = lblSAmt.Text;
						string str2 = "update T25_RV_DETAILS set AMOUNT_ADJUSTED=" + amtadj + ",SUSPENSE_AMT=" + lblSAmt.Text + " where BANK_CD=" + lstBank1.SelectedValue + " and CHQ_NO='" + lblCNO.Text + "' and CHQ_DT=to_date('" + lblCDate.Text + "','dd/mm/yyyy')";
						OracleCommand cmd2 = new OracleCommand(str2, conn1);
						cmd2.Transaction = myTrans;
						cmd2.ExecuteNonQuery();

						lblAmtADJ.Text = amtadj.ToString();

						string str3 = "update T22_BILL set AMOUNT_RECEIVED=" + lblBAmtRec.Text + ",WRITE_OFF_AMT=" + txtWriteOffAmt.Text + ", BILL_AMT_CLEARED=" + Convert.ToString(Convert.ToDouble(lblBAmtRec.Text) + Convert.ToDouble(lblTDS.Text) + Convert.ToDouble(txtRetention.Text) + Convert.ToDouble(txtWriteOffAmt.Text) + Convert.ToDouble(txtCNote_Amt.Text)) + " where BILL_NO='" + txtBNO.Text + "'";
						OracleCommand cmd3 = new OracleCommand(str3, conn1);
						cmd3.Transaction = myTrans;
						cmd3.ExecuteNonQuery();
						myTrans.Commit();
						conn1.Close();
						Response.Redirect("Check_Posting_Form.aspx?CHQ_NO=" + lblCNO.Text + "&CHQ_DT=" + lblCDate.Text + "&BANK_CD=" + lstBank1.SelectedValue + "&POSTING_DT=" + txtPDT.Text);
						//fillgrid();
						//						txtBNO.Text="";
						//						btnBDetails.Visible=true;
						//						Label9.Visible=false;
						//						lblBDT.Visible=false;
						//						Label7.Visible=false;
						//						lblBAmt.Visible=false;
						//						Label10.Visible=false;
						//						lblBAmtRec.Visible=false;
						//						Label13.Visible=false;
						//						lblAmtToRec.Visible=false;
						//						Label14.Visible=false;
						//						txtAmtTOClear.Visible=false;

					}
					else
					{
						DisplayAlert("Amount To be Cleared is greater then the (Check Amount - (Amount Adjusted + Amount Transferred)) OR Amount To be Cleared is Greater then the Bill Amount To Recover!!!");
					}
				}

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
			}
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			show1();
			Label9.Visible = false;
			lblBDT.Visible = false;
			Label7.Visible = false;
			lblBAmt.Visible = false;
			btnDel2.Visible = false;
			Label10.Visible = false;
			lblBAmtRec.Visible = false;
			Label13.Visible = false;
			//lblAmtToRec.Visible=false;
			Label14.Visible = false;
			txtAmtTOClear.Visible = false;
			if (Session["Role_CD"].ToString() == "4")
			{
				btnSave1.Visible = false;
				btnDel2.Visible = false;

			}
			else
			{
				btnSave1.Visible = true;
			}
			lblBNO.Visible = false;
			Label16.Visible = false;
			lblTDS.Visible = false;
			txtBNO.Visible = true;
			Label18.Visible = false;
			Label19.Visible = false;
			txtRetention.Visible = false;
			txtWriteOffAmt.Visible = false;
			Label17.Visible = false;
			txtPDT.Visible = false;
			txtAmtToRec.Visible = false;
			Label21.Visible = false;
			lblTAmtCleared.Visible = false;
			Label22.Visible = false;
			Label23.Visible = false;
			Label24.Visible = false;
			Label25.Visible = false;

			lblCSNO.Visible = false;
			lblBKNO.Visible = false;
			lblSETNO.Visible = false;
			lblBPO.Visible = false;

		}

		//fillgrid();



		void show1()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str3 = "select T24.VCHR_NO,to_char(T24.VCHR_DT,'dd/mm/yyyy') VCHR_DT,T25.CHQ_NO,to_char(T25.CHQ_DT,'dd/mm/yyyy')CHQ_DT,T25.BANK_CD,NVL2(T25.BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),T25.NARRATION) BPO,NVL(T25.AMOUNT,0) AMOUNT,NVL(T25.AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED,NVL(AMT_TRANSFERRED,0)AMT_TRANSFERRED,NVL(T25.SUSPENSE_AMT,0)SUSPENSE_AMT,T25.ACC_CD from T24_RV T24,T25_RV_DETAILS T25, T12_BILL_PAYING_OFFICER B,T03_CITY C where T24.VCHR_NO= T25.VCHR_NO AND T25.BPO_CD=B.BPO_CD(+) AND B.BPO_CITY_CD=C.CITY_CD(+) AND T25.CHQ_NO='" + txtCNO.Text + "' AND CHQ_DT=to_date('" + txtCDT.Text + "','dd/mm/yyyy') AND T25.BANK_CD=" + lstBank1.SelectedValue + " and substr(T24.VCHR_NO,1,1)='" + Session["Region"] + "'";
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
					Panel.Visible = true;
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
		protected void btnDel2_Click(object sender, System.EventArgs e)
		{

			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{
				string myDeleteQuery = "Delete T26_CHEQUE_POSTING  where BANK_CD=" + BCD + " AND CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy') AND BILL_NO='" + BNO + "'";
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Transaction = myTrans;
				myOracleCommand.Connection = conn1;
				myOracleCommand.ExecuteNonQuery();

				//				OracleCommand cmd = new OracleCommand("Select NVL(AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED,NVL(AMT_TRANSFERRED,0) AMT_TRANSFERRED from T25_RV_DETAILS where BANK_CD="+BCD+" AND CHQ_NO='"+CNO+"' and CHQ_DT=to_date('"+CDT+"','dd/mm/yyyy')",conn1); 
				//				cmd.Transaction=myTrans;
				//				OracleDataReader reader=cmd.ExecuteReader();
				//				double m=0,t=0;
				//				while(reader.Read())
				//				{
				//					m=Convert.ToDouble(reader["AMOUNT_ADJUSTED"].ToString());
				//					t=Convert.ToDouble(reader["AMT_TRANSFERRED"].ToString());
				//				}
				double m = Convert.ToDouble(lblAmtADJ.Text);
				m = m - Convert.ToDouble(txtAmtTOClear.Text);
				lblBAmtRec.Text = Convert.ToString(Convert.ToDouble(lblBAmtRec.Text) - Convert.ToDouble(txtAmtTOClear.Text));
				lblAmtToRec.Text = Convert.ToString(Convert.ToDouble(lblAmtToRec.Text) + Convert.ToDouble(txtAmtTOClear.Text));
				txtAmtToRec.Text = Convert.ToString(lblAmtToRec.Text);
				lblSAmt.Text = Convert.ToString(Convert.ToDouble(lblSAmt.Text) + Convert.ToDouble(txtAmtTOClear.Text));
				txtSAmt.Text = lblSAmt.Text;
				string myDeleteQuery1 = "Update T25_RV_DETAILS set AMOUNT_ADJUSTED=" + m + ",SUSPENSE_AMT=" + lblSAmt.Text + " where  BANK_CD=" + BCD + " AND CHQ_NO='" + CNO + "' and CHQ_DT=to_date('" + CDT + "','dd/mm/yyyy')";
				OracleCommand myOracleCommand1 = new OracleCommand(myDeleteQuery1);
				myOracleCommand1.Transaction = myTrans;
				myOracleCommand1.Connection = conn1;
				myOracleCommand1.ExecuteNonQuery();

				lblAmtADJ.Text = m.ToString();

				OracleCommand delCmd = new OracleCommand("Select count(*) from T26_CHEQUE_POSTING where BILL_NO='" + txtBNO.Text + "'", conn1);
				delCmd.Transaction = myTrans;
				int delCount = Convert.ToInt16(delCmd.ExecuteScalar());
				string str;
				if (delCount > 0)
				{
					str = "Update T22_BILL set AMOUNT_RECEIVED=" + lblBAmtRec.Text + ", BILL_AMT_CLEARED=(BILL_AMT_CLEARED-(" + Convert.ToDouble(txtAmtTOClear.Text) + ")) where BILL_NO='" + txtBNO.Text + "'";
				}
				else
				{
					str = "Update T22_BILL set AMOUNT_RECEIVED=0,BILL_AMT_CLEARED=0,TDS=0,RETENTION_MONEY=0,WRITE_OFF_AMT=0 where BILL_NO='" + txtBNO.Text + "'";
				}
				OracleCommand cmd1 = new OracleCommand(str, conn1);
				cmd1.Transaction = myTrans;
				cmd1.ExecuteNonQuery();
				myTrans.Commit();

				conn1.Close();

				Label9.Visible = false;
				lblBDT.Visible = false;
				Label7.Visible = false;
				lblBAmt.Visible = false;
				Label10.Visible = false;
				lblBAmtRec.Visible = false;
				Label13.Visible = false;
				//lblAmtToRec.Visible=false;
				Label14.Visible = false;
				txtAmtTOClear.Visible = false;

				txtBNO.Text = "";
				btnBDetails.Visible = true;
				btnDel2.Visible = false;
				btnSave1.Visible = true;
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
			}

			Response.Redirect("Check_Posting_Form.aspx?CHQ_NO=" + lblCNO.Text + "&CHQ_DT=" + lblCDate.Text + "&BANK_CD=" + lstBank1.SelectedValue);

		}
		void new_bill_details()
		{
			DataSet dsP = new DataSet();
			string str3 = "";
			if (rdbBNO.Checked == true)
			{
				str3 = "select BILL_NO,INVOICE_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DT,CASE_NO,BK_NO,SET_NO,(BPO_CD||'-'||BPO_NAME||'/'||BPO_RLY||'/'||NVL2(BPO_ADD,BPO_ADD||'/','')||BPO_CITY) BPO_NAME,NVL(BILL_AMOUNT,0) BILL_AMOUNT,NVL(AMOUNT_RECEIVED,0) AMOUNT_RECEIVED,NVL(BILL_AMT_CLEARED,0) BILL_AMT_CLEARED,NVL(TDS,0) + NVL(TDS_SGST,0) + NVL(TDS_CGST,0) + NVL(TDS_IGST,0) TDS,NVL(RETENTION_MONEY,0)RETENTION_MONEY, NVL(WRITE_OFF_AMT,0)WRITE_OFF_AMT,NVL(CNOTE_AMOUNT,0)CNOTE_AMT,BPO_CD from V22_BILL where BILL_NO='" + txtBNO.Text + "' and REGION_CODE='" + Session["Region"].ToString() + "'";
			}
			else if (rdbINO.Checked == true)
			{
				str3 = "select BILL_NO,INVOICE_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DT,CASE_NO,BK_NO,SET_NO,(BPO_CD||'-'||BPO_NAME||'/'||BPO_RLY||'/'||NVL2(BPO_ADD,BPO_ADD||'/','')||BPO_CITY) BPO_NAME,NVL(BILL_AMOUNT,0) BILL_AMOUNT,NVL(AMOUNT_RECEIVED,0) AMOUNT_RECEIVED,NVL(BILL_AMT_CLEARED,0) BILL_AMT_CLEARED,NVL(TDS,0) + NVL(TDS_SGST,0) + NVL(TDS_CGST,0) + NVL(TDS_IGST,0) TDS,NVL(RETENTION_MONEY,0)RETENTION_MONEY, NVL(WRITE_OFF_AMT,0)WRITE_OFF_AMT,NVL(CNOTE_AMOUNT,0)CNOTE_AMT,BPO_CD from V22_BILL where INVOICE_NO='" + txtBNO.Text + "' and REGION_CODE='" + Session["Region"].ToString() + "'";
			}

			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("InValid Bill No.");
				rbs.SetFocus(txtBNO);
			}
			else
			{
				OracleCommand cmd = new OracleCommand("Select nvl(BPO_CD,'NULL') from T25_RV_DETAILS where CHQ_NO='" + txtCNO.Text + "' AND BANK_CD=" + lstBank1.SelectedValue, conn1);
				string bpo = Convert.ToString(cmd.ExecuteScalar());
				//				if(bpo.ToString()=="NULL" || bpo.ToString()==dsP.Tables[0].Rows[0]["BPO_CD"].ToString())
				//				{
				if (Convert.ToDouble(dsP.Tables[0].Rows[0]["BILL_AMOUNT"]) == (Convert.ToDouble(dsP.Tables[0].Rows[0]["AMOUNT_RECEIVED"]) + Convert.ToDouble(dsP.Tables[0].Rows[0]["TDS"]) + Convert.ToDouble(dsP.Tables[0].Rows[0]["WRITE_OFF_AMT"]) + Convert.ToDouble(dsP.Tables[0].Rows[0]["RETENTION_MONEY"]) + Convert.ToDouble(dsP.Tables[0].Rows[0]["CNOTE_AMT"])))
				{
					rbs.SetFocus(txtBNO);
					DisplayAlert("This Bill has already been cleared!!!");
				}
				//					else if(Convert.ToDouble(dsP.Tables[0].Rows[0]["AMOUNT_RECEIVED"])>0)
				//					{
				//						rbs.SetFocus(txtBNO);
				//						DisplayAlert("This Bill has partly cleared!!!");
				//					
				//					}
				else
				{

					lblBDT.Text = dsP.Tables[0].Rows[0]["BILL_DT"].ToString();
					lblBAmt.Text = dsP.Tables[0].Rows[0]["BILL_AMOUNT"].ToString();
					txtBAmt.Text = lblBAmt.Text;
					lblBAmtRec.Text = dsP.Tables[0].Rows[0]["AMOUNT_RECEIVED"].ToString();
					txtBAmtRec.Text = lblBAmtRec.Text;
					lblTAmtCleared.Text = dsP.Tables[0].Rows[0]["BILL_AMT_CLEARED"].ToString();
					lblTDS.Text = dsP.Tables[0].Rows[0]["TDS"].ToString();
					txtRetention.Text = dsP.Tables[0].Rows[0]["RETENTION_MONEY"].ToString();
					txtCNote_Amt.Text = dsP.Tables[0].Rows[0]["CNOTE_AMT"].ToString();
					txtWriteOffAmt.Text = dsP.Tables[0].Rows[0]["WRITE_OFF_AMT"].ToString();
					lblAmtToRec.Text = Convert.ToString(Convert.ToDouble(lblBAmt.Text) - (Convert.ToDouble(lblBAmtRec.Text) + Convert.ToDouble(txtRetention.Text) + Convert.ToDouble(txtCNote_Amt.Text) + Convert.ToDouble(txtWriteOffAmt.Text) + Convert.ToDouble(lblTDS.Text)));
					txtAmtToRec.Text = Convert.ToString(lblAmtToRec.Text);
					lblCSNO.Text = dsP.Tables[0].Rows[0]["CASE_NO"].ToString();
					lblBKNO.Text = dsP.Tables[0].Rows[0]["BK_NO"].ToString();
					lblSETNO.Text = dsP.Tables[0].Rows[0]["SET_NO"].ToString();
					lblBPO.Text = dsP.Tables[0].Rows[0]["BPO_NAME"].ToString();
					txtBPOCD.Text = dsP.Tables[0].Rows[0]["BPO_CD"].ToString();
					Label9.Visible = true;
					lblBDT.Visible = true;
					Label7.Visible = true;
					lblBAmt.Visible = true;
					Label10.Visible = true;
					lblBAmtRec.Visible = true;
					Label13.Visible = true;
					//lblAmtToRec.Visible=true;
					Label14.Visible = true;
					txtAmtTOClear.Visible = true;
					Label16.Visible = true;
					lblTDS.Visible = true;
					lblBNO.Text = txtBNO.Text;
					Label18.Visible = true;
					Label19.Visible = true;
					txtRetention.Visible = true;
					txtWriteOffAmt.Visible = true;
					Label17.Visible = true;
					txtPDT.Visible = true;
					txtAmtToRec.Visible = true;
					Label21.Visible = true;
					lblTAmtCleared.Visible = true;
					txtBNO.Visible = false;
					Label22.Visible = true;
					Label23.Visible = true;
					Label24.Visible = true;
					Label25.Visible = true;

					lblCSNO.Visible = true;
					lblBKNO.Visible = true;
					lblSETNO.Visible = true;
					lblBPO.Visible = true;
					lblBNO.Visible = true;
					btnTDS.Visible = true;
					btnBDetails.Visible = false;
					txtBNO.Text = dsP.Tables[0].Rows[0]["BILL_NO"].ToString();
					txtAmtTOClear.Text = "";
					rbs.SetFocus(txtWriteOffAmt);
					if (Convert.ToDouble(lblSAmt.Text) >= Convert.ToDouble(lblAmtToRec.Text))
					{
						txtAmtTOClear.Text = lblAmtToRec.Text;
					}
					else
					{
						txtAmtTOClear.Text = lblSAmt.Text;
					}
				}
				//				}
				//				else
				//				{
				//					rbs.SetFocus(txtBNO);
				//					DisplayAlert("This Bill Belongs To a Different BPO!!!");
				//				}
			}
			conn1.Close();
			if (Convert.ToString(Request.Params["POSTING_DT"]) == "" || Convert.ToString(Request.Params["POSTING_DT"]) == null)
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'DD/MM/YYYY') from dual", conn1);
				txtPDT.Text = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();

			}
			else
			{
				txtPDT.Text = Convert.ToString(Request.Params["POSTING_DT"]);
			}
		}
		protected void btnBDetails_Click(object sender, System.EventArgs e)
		{
			new_bill_details();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			//			if(Session["Role"].ToString() == "Administrator")
			//			{
			//				Response.Redirect("MainForm.aspx");
			//			}
			//			else
			//			{
			//				Response.Redirect("MainForm2.aspx");
			//			}

			Response.Redirect("Check_Posting_Form.aspx");
		}

		protected void btnTDS_Click(object sender, System.EventArgs e)
		{

			Response.Redirect("TDS.aspx?BILL_NO=" + txtBNO.Text + "&CHQ_NO=" + lblCNO.Text + "&CHQ_DT=" + lblCDate.Text + "&BANK_CD=" + lstBank1.SelectedValue + "&AMOUNT_CLEARED=" + AMTCLR);

		}




	}
}