using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.RV_Entry
{
	public partial class RV_Entry : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		public string VNO, Action, VTYPE;
		int SNO;
		protected System.Web.UI.WebControls.TextBox txtDtOfReciept;
		protected System.Web.UI.WebControls.TextBox txtBKNO;
		int ecode = 0;
		void show()
		{
			DataSet dsP = new DataSet();
			string str3 = "select V.VCHR_NO,to_char(V.VCHR_DT,'dd/mm/yyyy') VCHR_DT,VCHR_TYPE,(lpad(to_char(B.FMIS_BANK_CD),4,'0')||'-'||B.BANK_NAME) BANK_NAME from T24_RV V, T94_BANK B where V.BANK_CD=B.BANK_CD(+) and VCHR_NO='" + VNO + "' ";
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			lblVDT.Visible = true;
			lblBank.Visible = true;
			txtVDT.Visible = false;
			lstBank.Visible = false;
			lblVNo.Text = dsP.Tables[0].Rows[0]["VCHR_NO"].ToString();
			lblVDT.Text = dsP.Tables[0].Rows[0]["VCHR_DT"].ToString();

			lblBank.Text = dsP.Tables[0].Rows[0]["BANK_NAME"].ToString();
			if (dsP.Tables[0].Rows[0]["VCHR_TYPE"].ToString() == "E")
			{
				//				btnPrint.Visible=false;
				Label1.Text = "RECIEPT VOUCHER-EFT";
				VTYPE = "E";

			}
			//lblBCD.Text=dsP.Tables[0].Rows[0]["BANK_CD"].ToString();
			conn1.Close();
			if (lblBank.Text.Trim().ToUpper() == "CASH")
			{
				lstBank1.SelectedValue = "0";
				lstBank1.Visible = false;
				if (SNO == 0)
				{
					lblCDT.Text = lblVDT.Text.Trim();
					txtCDT.Text = lblVDT.Text.Trim();
					txtCNO.Visible = false;
					txtCDT.Visible = false;
					conn1.Open();
					//OracleCommand cmd2 =new OracleCommand("Select to_char('"+txtVDT.Text+"','YYMMDD') from dual",conn1);

					string dtMid = dateconcate(lblVDT.Text);
					OracleCommand cmd3 = new OracleCommand("Select NVL(max(to_number(substr(CHQ_NO,9,4))),0)+1 from T25_RV_DETAILS where to_char(CHQ_DT,'DD/mm/yyyy')='" + lblVDT.Text.Trim() + "' and BANK_CD=0 and substr(VCHR_NO,1,1)='" + Session["Region"].ToString() + "'", conn1);
					string sn = Convert.ToString(cmd3.ExecuteScalar());
					conn1.Close();
					lblCNO.Text = Session["Region"].ToString() + dtMid + "-" + sn;
					txtCNO.Text = lblCNO.Text.Trim();

				}

			}
			//							rbs aa=new rbs();
			//							aa.setfocus();


		}
		void show1()
		{
			DataSet dsP = new DataSet();
			string str3 = "select SNO,ACC_CD,AMOUNT,NVL(AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED,BPO_CD,BANK_CD,CHQ_NO,to_char(CHQ_DT,'dd/mm/yyyy')CHQ_DT,NARRATION,SAMPLE_NO,CASE_NO from T25_RV_DETAILS where VCHR_NO='" + lblVNo.Text + "' AND SNO=" + SNO;
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			lstACD.SelectedValue = dsP.Tables[0].Rows[0]["ACC_CD"].ToString();
			if (lstACD.SelectedValue == "2201")
			{
				lblType.Text = "R";
			}
			else if (lstACD.SelectedValue == "2202")
			{
				lblType.Text = "F";
			}
			else if (lstACD.SelectedValue == "2203")
			{
				lblType.Text = "U";
			}
			else if (lstACD.SelectedValue == "2204")
			{
				lblType.Text = "P";
			}
			else if (lstACD.SelectedValue == "2205")
			{
				lblType.Text = "S";
			}
			else
			{
				lblType.Text = "";
			}

			txtNarrat.Text = dsP.Tables[0].Rows[0]["NARRATION"].ToString();
			txtCNO.Text = dsP.Tables[0].Rows[0]["CHQ_NO"].ToString();
			lblCNO.Text = txtCNO.Text;
			txtCDT.Text = dsP.Tables[0].Rows[0]["CHQ_DT"].ToString();
			lblCDT.Text = txtCDT.Text.Trim();
			txtAmt.Text = dsP.Tables[0].Rows[0]["AMOUNT"].ToString();
			txtSNo.Text = dsP.Tables[0].Rows[0]["SAMPLE_NO"].ToString();
			lstBank1.SelectedValue = dsP.Tables[0].Rows[0]["BANK_CD"].ToString();
			txtCSNO.Text = dsP.Tables[0].Rows[0]["CASE_NO"].ToString();
			if (dsP.Tables[0].Rows[0]["BPO_CD"].ToString() != "")
			{
				fill_BPO(dsP.Tables[0].Rows[0]["BPO_CD"].ToString());
			}
			if (Convert.ToDouble(dsP.Tables[0].Rows[0]["AMOUNT_ADJUSTED"].ToString()) > 0)
			{
				txtCNO.Enabled = false;
				lstBank1.Enabled = false;
				lstACD.Enabled = false;
				txtCSNO.Enabled = false;
				txtBPO.Enabled = false;
			}
			else
			{
				txtCNO.Enabled = true;
				lstBank1.Enabled = true;
				lstACD.Enabled = true;
				txtCSNO.Enabled = true;
				txtBPO.Enabled = true;
			}
			conn1.Close();


		}
		protected void Page_Load(object sender, System.EventArgs e)
		{

			btnFC_List.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnSave1.Attributes.Add("OnClick", "JavaScript:validate();");

			if (Convert.ToString(Request.Params["VOUCHER_TYPE"]) == "" || Convert.ToString(Request.Params["VOUCHER_TYPE"]) == null)
			{
				VTYPE = "";
			}
			else
			{
				VTYPE = "E";
			}
			if (Convert.ToString(Request.Params["VOUCHER_NO"]) == "" || Convert.ToString(Request.Params["VOUCHER_NO"]) == null)
			{
				VNO = "";
				Action = Convert.ToString(Request.Params["Action"]); ;
			}
			else if (Convert.ToString(Request.Params["VOUCHER_NO"]) != "" && Convert.ToString(Request.Params["Action"]) != "")
			{
				VNO = Convert.ToString(Request.Params["VOUCHER_NO"]);
				Action = Convert.ToString(Request.Params["Action"]);
				lblVNo.Text = VNO;
				if (Request.Params["SRNO"] == "" || Request.Params["SNO"] == null)
				{
					SNO = 0;
				}
				else
				{
					SNO = Convert.ToInt32(Request.Params["SNO"]);


				}



			}

			if (!(IsPostBack))
			{
				DataSet dsP = new DataSet();
				string stra = "";
				if (Session["Role_CD"].ToString() == "5")
				{
					stra = "select ACC_CD,(ACC_DESC||':'||ACC_CD)ACC_DESC from T95_ACCOUNT_CODES where ACC_CD IN (2210,2212) Order by ACC_DESC ";
				}
				else
				{
					stra = "select ACC_CD,(ACC_DESC||':'||ACC_CD)ACC_DESC from T95_ACCOUNT_CODES where ACC_CD < 3000 Order by ACC_DESC ";
				}
				OracleDataAdapter da = new OracleDataAdapter(stra, conn1);
				OracleCommand myOracleCommand = new OracleCommand(stra, conn1);
				//ListItem lst; 
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				lstACD.DataValueField = "ACC_CD";
				lstACD.DataTextField = "ACC_DESC";
				lstACD.DataSource = dsP;
				lstACD.DataBind();
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



				DataSet dsP2 = new DataSet();
				string stra2 = "select BANK_CD,BANK_NAME from T94_BANK where BANK_CD < 990 order by BANK_NAME";
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

				if (Convert.ToString(Request.Params["VOUCHER_NO"]) != "" && Convert.ToString(Request.Params["Action"]) != "")
				{
					if (Request.Params["SNO"] == "" || Request.Params["SNO"] == null)
					{
						SNO = 0;
						btnAdd.Visible = false;
					}
					else
					{
						SNO = Convert.ToInt32(Request.Params["SNO"]);
						show1();
						btnAdd.Visible = true;
					}


				}
				try
				{
					if (Action == "A" && VNO == "")
					{
						//btnDelete.Visible =false;
						//btnInsDt.Visible=false;
						Panel.Visible = true;
						lblVDT.Visible = false;
						lblBank.Visible = false;
						btnAdd.Visible = false;
						txtVNO.Visible = false;
						lblVNo.Visible = false;
						btnPrint.Visible = false;
						btnSearch.Visible = false;
						//generate();
						conn1.Open();
						OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'DD/MM/YYYY') from dual", conn1);
						string ss = Convert.ToString(cmd2.ExecuteScalar());
						conn1.Close();
						txtVDT.Text = ss;
						btnDel2.Visible = false;
						lblCNO.Visible = false;
						lblCDT.Visible = false;
						lblCash.Visible = false;
						//							string popupScript = "<script language='javascript'>" + "document.Form1.txtVDT.focus();" + "</script>";
						//							Page.RegisterStartupScript("PopupScript", popupScript);
						//SetFocus(txtVDT);

					}
					else if (Action == "A" && VNO != "" && SNO == 0)
					{
						show();
						Panel.Visible = true;
						Label6.Visible = true;
						txtVDT.Visible = false;
						lblVDT.Visible = true;
						Label10.Visible = true;
						lblBank.Visible = true;
						lstBank.Visible = false;
						txtVNO.Visible = false;
						btnSearch.Visible = false;
						btnDel2.Visible = false;
						btnPrint.Visible = true;
						if (lblBank.Text.Trim().ToUpper() == "CASH")
						{
							lblCNO.Visible = true;
							lblCDT.Visible = true;
							txtCNO.Visible = false;
							txtCDT.Visible = false;
							lblCash.Visible = true;
						}
						else
						{
							lblCNO.Visible = false;
							lblCDT.Visible = false;
							txtCNO.Visible = true;
							txtCDT.Visible = true;
							lblCash.Visible = false;
						}
						//							string popupScript = "<script language='javascript'>" + "document.Form1.txtCNO.focus();" + "</script>";
						//							Page.RegisterStartupScript("PopupScript", popupScript);
						//SetFocus(txtCNO);


					}
					else if (Action == "M" && SNO == 0)
					{
						//show();
						Panel.Visible = false;
						Label6.Visible = false;
						txtVDT.Visible = false;
						lblVDT.Visible = false;
						Label10.Visible = false;
						lblBank.Visible = false;
						lstBank.Visible = false;
						txtVNO.Visible = true;

						//SetFocus(txtVNO);

						//btnDelete.Visible =false;

					}
					else if (Action == "M" && SNO != 0)
					{
						show();
						Panel.Visible = true;
						Label6.Visible = true;
						txtVDT.Visible = false;
						lblVDT.Visible = true;
						Label10.Visible = true;
						lblBank.Visible = true;
						lstBank.Visible = false;
						txtVNO.Visible = false;
						btnSearch.Visible = false;
						//						btnDel2.Visible=true;   As Per Auditors Dated 19-Dec-2011
						btnPrint.Visible = true;
						if (lblBank.Text.Trim().ToUpper() == "CASH")
						{
							lblCNO.Visible = true;
							lblCDT.Visible = true;
							txtCNO.Visible = false;
							txtCDT.Visible = false;
							lblCash.Visible = true;
						}
						else
						{
							lblCNO.Visible = false;
							lblCDT.Visible = false;
							txtCNO.Visible = true;
							txtCDT.Visible = true;
							lblCash.Visible = false;
						}
						//SetFocus(txtCNO);
					}
					else if (Action == "D")
					{
						show();
						Panel.Visible = true;
						txtVNO.Visible = false;

						if (lblBank.Text.Trim().ToUpper() == "CASH")
						{
							lblCNO.Visible = true;
							lblCDT.Visible = true;
							txtCNO.Visible = false;
							txtCDT.Visible = false;
							lblCash.Visible = true;
						}
						else
						{
							lblCNO.Visible = false;
							lblCDT.Visible = false;
							txtCNO.Visible = true;
							txtCDT.Visible = true;
							lblCash.Visible = false;
						}
						//btnSave.Visible =false;
					}
					else
					{
						txtVNO.Visible = true;
					}
					conn1.Close();
					if (VTYPE == "E")
					{
						Label4.Text = "EFT NO.";
						Label5.Text = "EFT Date";
						//						btnPrint.Visible=false;
					}
					if (Session["Role_CD"].ToString() == "4")
					{
						btnSave1.Visible = false;
						btnAdd.Visible = false;
						btnDel2.Visible = false;

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

				fillgrid(VNO);
			}


		}

		string dateconcate(string dt)
		{
			string myYear, myMonth, myDay;

			myYear = dt.Substring(8, 2);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;
			return (dt1);
		}

		public void generate()
		{
			try
			{

				//				conn1.Open();
				//				OracleCommand cmd2 =new OracleCommand("Select to_char('"+txtVDT.Text+"','YYMM') from dual",conn1);
				//				string ss=Convert.ToString(cmd2.ExecuteScalar());
				string ss = Session["Region"] + txtVDT.Text.Substring(8, 2) + txtVDT.Text.Substring(3, 2);
				//				conn1.Close();

				string str3 = "Select lpad(nvl(max(to_number(nvl(substr(VCHR_NO,6,8),0))),0)+1,3,'0') from T24_RV where substr(VCHR_NO,1,5)='" + ss + "'";
				OracleCommand myInsertCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				str3 = Convert.ToString(myInsertCommand.ExecuteScalar());
				conn1.Close();
				lblVNo.Text = ss + str3;
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
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


		void fillgrid(string vchr)
		{
			try
			{
				//string str1 = "select R.VCHR_NO,R.SNO,A.ACC_DESC,R.AMOUNT,(B.BPO_NAME||'/'||B.BPO_ADD||'/'||B.BPO_RLY)BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.SAMPLE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND VCHR_NO= '" + VNO + "'";
				if (vchr != "" || vchr != null)
				{
					string str1 = "select R.VCHR_NO,R.SNO,(R.ACC_CD||'-'||A.ACC_DESC)ACC_DESC,R.AMOUNT,NVL2(R.BPO_CD,B.BPO_CD||'-'||(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),'')BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.CASE_NO,D.BANK_NAME from T24_RV T24,T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D,T03_CITY C where T24.VCHR_NO=R.VCHR_NO and R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND B.BPO_CITY_CD=C.CITY_CD(+) and substr(T24.VCHR_NO,1,1)='" + Session["Region"] + "' AND T24.VCHR_NO= '" + vchr.Trim() + "' and (nvl(T24.VCHR_TYPE,'X')<>'I') Order by R.SNO";
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
			int chkBpoCno = 0;
			if (lstACD.SelectedValue == "2709" || lstACD.SelectedValue == "2210")
			{
				if (txtCSNO.Text.Trim() == "")
				{
					chkBpoCno = 0;
				}
				else
				{
					conn1.Open();
					OracleCommand cmdchkCNO = new OracleCommand("Select CASE_NO from T13_PO_MASTER where CASE_NO='" + txtCSNO.Text.Trim() + "' ", conn1);
					string CNO = Convert.ToString(cmdchkCNO.ExecuteScalar());
					conn1.Close();
					if (CNO == "")
					{
						chkBpoCno = 0;
					}
					else
					{
						chkBpoCno = 1;
					}
				}
			}
			else if (lstACD.SelectedValue == "2212")
			{
				chkBpoCno = 1;
			}
			else
			{
				if (lstBPO.SelectedValue == "")
				{
					chkBpoCno = 0;
				}
				else
				{
					chkBpoCno = 1;
				}
			}
			if (chkBpoCno == 1)
			{
				conn1.Open();
				OracleCommand cmdDT = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string dt = Convert.ToString(cmdDT.ExecuteScalar());
				conn1.Close();

				if (SNO == 0)
				{
					OracleTransaction myTrans = null;
					if (lblVNo.Visible == false)
					{
						generate();
						conn1.Open();
						OracleCommand cmd = new OracleCommand("Select Count(*) from T24_RV where VCHR_NO='" + lblVNo.Text + "'", conn1);
						int m = Convert.ToInt16(cmd.ExecuteScalar());
						conn1.Close();
						try
						{

							if (m == 0)
							{
								conn1.Open();
								myTrans = conn1.BeginTransaction();
								string myInsertQueryM = "INSERT INTO T24_RV values('" + lblVNo.Text + "', to_date('" + txtVDT.Text + "','dd/mm/yyyy')," + lstBank.SelectedValue + ",'" + VTYPE + "')";
								OracleCommand myInsertCommandM = new OracleCommand(myInsertQueryM);
								myInsertCommandM.Transaction = myTrans;
								myInsertCommandM.Connection = conn1;
								myInsertCommandM.ExecuteNonQuery();

							}

							string str3 = "select NVL(max(SNO),0) from T25_RV_DETAILS where VCHR_NO= '" + VNO + "'";
							OracleCommand cmd1 = new OracleCommand(str3, conn1);
							cmd1.Transaction = myTrans;
							int sno = Convert.ToInt32(cmd1.ExecuteScalar());
							sno = sno + 1;

							string myInsertQuery = "INSERT INTO T25_RV_DETAILS(VCHR_NO,SNO,ACC_CD,BANK_CD,CHQ_NO,CHQ_DT,NARRATION,SAMPLE_NO,AMOUNT,SUSPENSE_AMT,BPO_CD,POST_DT,STATUS,CASE_NO,BPO_TYPE,AMOUNT_ADJUSTED,AMT_TRANSFERRED,USER_ID,DATETIME)values('" + lblVNo.Text + "'," + sno + ",'" + lstACD.SelectedValue + "'," + lstBank1.SelectedValue + ",'" + txtCNO.Text.Trim() + "',to_date('" + txtCDT.Text + "','dd/mm/yyyy'),'" + txtNarrat.Text + "','" + txtSNo.Text + "'," + txtAmt.Text + "," + txtAmt.Text + ",'" + lstBPO.SelectedValue + "','','','" + txtCSNO.Text + "','" + lblType.Text + "',0,0,'" + Session["Uname"].ToString() + "',to_date('" + dt + "','dd/mm/yyyy-HH24:MI:SS'))";
							OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
							myInsertCommand.Connection = conn1;
							myInsertCommand.Transaction = myTrans;
							myInsertCommand.ExecuteNonQuery();
							myTrans.Commit();
							conn1.Close();
							GL_Entry(lblVNo.Text, sno, txtVDT.Text, "I");
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
						}
						Response.Redirect("RV_Entry.aspx?Action=A&VOUCHER_NO=" + lblVNo.Text + "&VOUCHER_TYPE=" + VTYPE);
					}
					else if (lblVNo.Visible == true)
					{
						try
						{
							string str3 = "select NVL(max(SNO),0) from T25_RV_DETAILS where VCHR_NO= '" + VNO + "'";
							OracleCommand cmd1 = new OracleCommand(str3, conn1);
							conn1.Open();
							int sno = Convert.ToInt32(cmd1.ExecuteScalar());
							sno = sno + 1;

							string myInsertQuery = "INSERT INTO T25_RV_DETAILS(VCHR_NO,SNO,ACC_CD,BANK_CD,CHQ_NO,CHQ_DT,NARRATION,SAMPLE_NO,AMOUNT,SUSPENSE_AMT,BPO_CD,POST_DT,STATUS,CASE_NO,BPO_TYPE,AMOUNT_ADJUSTED,AMT_TRANSFERRED,USER_ID,DATETIME)values('" + lblVNo.Text + "'," + sno + ",'" + lstACD.SelectedValue + "'," + lstBank1.SelectedValue + ",'" + txtCNO.Text.Trim() + "',to_date('" + txtCDT.Text + "','dd/mm/yyyy'),'" + txtNarrat.Text + "','" + txtSNo.Text + "'," + txtAmt.Text + "," + txtAmt.Text + ",'" + lstBPO.SelectedValue + "','','','" + txtCSNO.Text + "','" + lblType.Text + "',0,0,'" + Session["Uname"].ToString() + "',to_date('" + dt + "','dd/mm/yyyy-HH24:MI:SS'))";
							OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
							myInsertCommand.Connection = conn1;
							myInsertCommand.ExecuteNonQuery();
							conn1.Close();
							GL_Entry(lblVNo.Text, sno, lblVDT.Text, "I");
						}
						catch (OracleException ex)
						{
							string str;
							str = ex.Message;
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
						}
						Response.Redirect("RV_Entry.aspx?Action=A&VOUCHER_NO=" + lblVNo.Text + "&VOUCHER_TYPE=" + VTYPE);
					}

				}
				else
				{
					string str11 = "Select NVL(AMOUNT_ADJUSTED,0)+NVL(AMT_TRANSFERRED,0) from T25_RV_DETAILS where VCHR_NO= '" + VNO + "' AND SNO=" + SNO;
					OracleCommand myUpdateCommand11 = new OracleCommand(str11);
					myUpdateCommand11.Connection = conn1;
					conn1.Open();
					double amtadj = Convert.ToDouble(myUpdateCommand11.ExecuteScalar());
					conn1.Close();

					if (amtadj <= Convert.ToDouble(txtAmt.Text))
					{
						string str = "Update T25_RV_DETAILS set ACC_CD='" + lstACD.SelectedValue + "',BANK_CD=" + lstBank1.SelectedValue + ",CHQ_NO='" + txtCNO.Text.Trim() + "',CHQ_DT=to_date('" + txtCDT.Text + "','dd/mm/yyyy'),SAMPLE_NO='" + txtSNo.Text + "',NARRATION='" + txtNarrat.Text + "',AMOUNT=" + txtAmt.Text + ",SUSPENSE_AMT=" + Convert.ToString(Convert.ToDouble(txtAmt.Text) - amtadj) + ",BPO_CD='" + lstBPO.SelectedValue + "',CASE_NO='" + txtCSNO.Text + "',BPO_TYPE='" + lblType.Text + "',USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + dt + "','dd/mm/yyyy-HH24:MI:SS') where VCHR_NO= '" + VNO + "' AND SNO=" + SNO;
						OracleCommand myUpdateCommand = new OracleCommand(str);
						myUpdateCommand.Connection = conn1;
						conn1.Open();
						myUpdateCommand.ExecuteNonQuery();
						conn1.Close();
						GL_Entry(lblVNo.Text, SNO, "", "U");
						Response.Redirect("RV_Entry.aspx?Action=A&VOUCHER_NO=" + lblVNo.Text + "&VOUCHER_TYPE=" + VTYPE);
					}
					else
					{
						DisplayAlert("The Amount already adjusted(sum of amount posted & transferred to other units) through this Cheque/Draft/EFT is greater than the New Cheque Amount. So, You Cannot modify the cheque amount!!!");
					}

				}
			}
			else
			{
				DisplayAlert("Case No./ BPO is must. (By Order)");
			}

		}
		int ChkCSNO()
		{
			if (txtCSNO.Visible == true)
			{
				//string str = "select count(*) from T14_PO_BPO WHERE CASE_NO='"+txtCSNO.Text+"' AND BPO='"+lstBPO.SelectedValue+"'"; 
				string str = "select P.CASE_NO, B.BPO_CD,V.VEND_NAME from T13_PO_MASTER P,T14_PO_BPO B, T05_VENDOR V WHERE P.CASE_NO=B.CASE_NO(+) and P.VEND_CD=V.VEND_CD and P.CASE_NO='" + txtCSNO.Text + "' group by P.CASE_NO,B.BPO_CD,V.VEND_NAME";
				OracleCommand cmd = new OracleCommand(str, conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				if (reader.HasRows == false)
				{
					DisplayAlert("Invalid Case No.!!!");
					conn1.Close();
					return (0);

				}
				else
				{
					while (reader.Read())
					{

						txtNarrat.Text = reader["VEND_NAME"].ToString();
					}
					//fill_BPO(reader["BPO_CD"].ToString());

					lstBPO.Items.Clear();
					DataSet dsP = new DataSet();
					string str1 = "select Distinct(P.BPO_CD) BPO_CD,(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER B,T14_PO_BPO P, T03_CITY C where P.BPO_CD=B.BPO_CD AND B.BPO_CITY_CD=C.CITY_CD AND P.CASE_NO=upper('" + txtCSNO.Text + "') ORDER BY BPO_NAME";
					OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
					ListItem lst;
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP, "Table");
					if (dsP.Tables[0].Rows.Count == 0)
					{
						lstBPO.Visible = false;
						txtBPO.Text = "";
						DisplayAlert("Their is No BPO Present For the given Case No,To enter BPO goto PO Update.");
					}
					else
					{
						for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
						{
							lst = new ListItem();
							lst.Text = dsP.Tables[0].Rows[i]["BPO_NAME"].ToString();
							lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
							lstBPO.Items.Add(lst);
						}
						lstBPO.Visible = true;
						lstBPO.SelectedIndex = 0;
						txtBPO.Text = lstBPO.SelectedValue;
						txtBPO.Visible = false;
						rbs.SetFocus(lstBPO);
					}
					conn1.Close();
					return (1);

					//Label13.Text=Label13.Text + i;
				}
			}
			else
				return (2);
		}
		protected void btnDel2_Click(object sender, System.EventArgs e)
		{
			int m = 0;
			//string myDeleteQuery = "Delete T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and BK_NO='"+BK+"'"; 

			conn1.Open();
			OracleCommand cmd1 = new OracleCommand("Select Count(*) from T26_CHEQUE_POSTING where CHQ_NO='" + txtCNO.Text + "' and CHQ_DT=to_date('" + txtCDT.Text + "','dd/mm/yyyy') and BANK_CD=" + lstBank1.SelectedValue, conn1);
			int chqpoststatus = Convert.ToInt16(cmd1.ExecuteScalar());
			if (chqpoststatus == 0)
			{
				cmd1.CommandText = "Select Count(*) from T27_JV where CHQ_NO='" + txtCNO.Text + "' and CHQ_DT=to_date('" + txtCDT.Text + "','dd/mm/yyyy') and BANK_CD=" + lstBank1.SelectedValue + " and substr(VCHR_NO,1,1)='" + Session["Region"].ToString() + "'";
				cmd1.Connection = conn1;
				chqpoststatus = Convert.ToInt16(cmd1.ExecuteScalar());
			}
			conn1.Close();
			if (chqpoststatus == 0)
			{
				string myDeleteQuery = "Delete T25_RV_DETAILS  where VCHR_NO= '" + VNO + "' AND SNO=" + SNO;
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
				conn1.Close();
				GL_Entry(VNO, SNO, "", "D");

				conn1.Open();
				OracleCommand cmd = new OracleCommand("Select Count(*) from T25_RV_DETAILS where VCHR_NO='" + lblVNo.Text + "'", conn1);
				m = Convert.ToInt16(cmd.ExecuteScalar());
				conn1.Close();
				if (m == 0)
				{
					string myDeleteQuery1 = "Delete T24_RV  where VCHR_NO= '" + VNO + "'";
					OracleCommand myOracleCommand1 = new OracleCommand(myDeleteQuery1);
					myOracleCommand1.Connection = conn1;
					conn1.Open();
					myOracleCommand1.ExecuteNonQuery();
					conn1.Close();


				}
				if (m != 0)
				{
					//Response.Redirect("RV_Entry.aspx?Action="+Action+"&VOUCHER_NO="+VNO);
					Response.Redirect("RV_Entry.aspx?Action=A&VOUCHER_NO=" + lblVNo.Text + "&VOUCHER_TYPE=" + VTYPE);
				}
				else
				{
					Response.Redirect("RV_Entry.aspx?Action=A&VOUCHER_TYPE=" + VTYPE);
				}
			}
			else
			{
				DisplayAlert("Posting has been done against this Cheque. Delete the Posted Cheques before deleting the voucher!!!");
			}

		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			if (txtVNO.Visible != true)
			{
				Response.Redirect("RV_Entry.aspx?Action=A&VOUCHER_NO=" + VNO + "&VOUCHER_TYPE=" + VTYPE);
			}
			else
			{
				Response.Redirect("RV_Entry.aspx?Action=A&VOUCHER_NO=" + txtVNO.Text.Trim() + "&VOUCHER_TYPE=" + VTYPE);
			}
		}

		int fill_BPO(string bpo)
		{
			lstBPO.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "";
			if (lstACD.SelectedValue == "2201" || lstACD.SelectedValue == "2202" || lstACD.SelectedValue == "2203" || lstACD.SelectedValue == "2204" || lstACD.SelectedValue == "2205")
			{
				str1 = "select B.BPO_CD,(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD = C.CITY_CD and (trim(upper(B.BPO_CD))=upper('" + bpo.Trim() + "') or trim(upper(B.BPO_RLY)) LIKE upper('" + bpo.Trim() + "%')) and B.BPO_TYPE='" + lblType.Text + "' ORDER BY BPO_NAME";
			}
			else
			{
				str1 = "select B.BPO_CD,(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER B,T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and (trim(upper(B.BPO_CD))=upper('" + bpo.Trim() + "') or trim(upper(B.BPO_RLY)) LIKE upper('" + bpo.Trim() + "%')) ORDER BY BPO_NAME";
			}
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				ecode = 1;
				return (ecode);
				//DisplayAlert("Invalid Search Data");
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["BPO_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
					lstBPO.Items.Add(lst);
				}
				lstBPO.Visible = true;
				lstBPO.SelectedIndex = 0;
				txtBPO.Text = lstBPO.SelectedValue;
				ecode = 2;
				return (ecode);

			}

		}


		protected void btnFC_List_Click(object sender, System.EventArgs e)
		{

			try
			{

				if (lstACD.SelectedValue == "2709" || lstACD.SelectedValue == "2210" || lstACD.SelectedValue == "2212")
				{
					ChkCSNO();
				}
				else
				{
					lstBPO.Visible = true;
					int a = fill_BPO(txtBPO.Text);
					if (a == 1)
					{
						lstBPO.Visible = false;
						DisplayAlert("No BPO Found!!!");
						rbs.SetFocus(txtBPO);
					}
					else
					{
						rbs.SetFocus(lstBPO);
					}
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str2);

			}
			finally
			{
				conn1.Close();
			}

		}

		protected void lstBPO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtBPO.Text = lstBPO.SelectedValue;
			rbs.SetFocus(txtNarrat);
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{

			if (Action == "A" && VNO == "" && SNO == 0)
			{
				if (Session["Role_CD"].ToString() == "2")
				{
					Response.Redirect("MainForm2.aspx");
				}
				else if (Session["Role_CD"].ToString() == "5")
				{
					Response.Redirect("Lab_Menu.aspx");
				}
				else
				{
					Response.Redirect("MainForm.aspx");
				}
			}
			else
			{
				Response.Redirect("RV_Entry.aspx?Action=M&VOUCHER_TYPE=" + VTYPE);
			}
		}



		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			fillgrid(txtVNO.Text.Trim());
			if (grdVDt.Visible == false)
			{
				DisplayAlert("Either the Voucher No. Or It may be an IU Advice Voucher!!! ");
			}
			else
			{
				////Panel.Visible=true;
				//lblVNo.Text=txtVNO.Text;
				//lblVNo.Visible=true;
				////show();
				////btnDel2.Visible=false;
				////btnSave1.Visible=false;
				////btnAdd.Visible=true;
				Response.Redirect("RV_Entry.aspx?Action=A&VOUCHER_NO=" + txtVNO.Text + "&VOUCHER_TYPE=" + VTYPE);

			}
		}


		protected void lstACD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtBPO.Text = "";
			lstBPO.Items.Clear();
			if (lstACD.SelectedValue == "2709" || lstACD.SelectedValue == "2210" || lstACD.SelectedValue == "2212")
			{
				Label12.Visible = true;
				txtCSNO.Visible = true;
				rbs.SetFocus(txtCSNO);
				Label9.Visible = true;
				txtBPO.Visible = false;
				lstBPO.Visible = false;
				btnFC_List.Visible = true;
				lblType.Text = "";
			}
			else
			{
				Label12.Visible = false;
				txtCSNO.Visible = false;
				txtCSNO.Text = "";
				Label9.Visible = true;
				txtBPO.Visible = true;
				lstBPO.Visible = false;
				btnFC_List.Visible = true;
				if (lstACD.SelectedValue == "2201")
				{
					lblType.Text = "R";
				}
				else if (lstACD.SelectedValue == "2202")
				{
					lblType.Text = "F";
				}
				else if (lstACD.SelectedValue == "2203")
				{
					lblType.Text = "U";
				}
				else if (lstACD.SelectedValue == "2204")
				{
					lblType.Text = "P";
				}
				else if (lstACD.SelectedValue == "2205")
				{
					lblType.Text = "S";
				}
				rbs.SetFocus(txtBPO);
			}
			//			else 
			//			{
			//				Label12.Visible=false;
			//				txtCSNO.Visible=false;
			//				txtCSNO.Text="";
			//				Label9.Visible=false;
			//				//txtBPO.Text="";
			//				txtBPO.Visible=false;
			//				//lstBPO.Items.Clear();
			//				lstBPO.Visible=false;
			//				btnFC_List.Visible=false;
			//				rbs.SetFocus(txtNarrat);
			//				lblType.Text="";
			//			
			//			}


		}

		protected void lstACD_PreRender(object sender, System.EventArgs e)
		{
			if (lstACD.SelectedValue == "2709" || lstACD.SelectedValue == "2210" || lstACD.SelectedValue == "2212")
			{
				Label12.Visible = true;
				txtCSNO.Visible = true;
				txtBPO.Visible = false;
			}
			else
			{
				Label12.Visible = false;
				txtCSNO.Visible = false;
				txtCSNO.Text = "";
			}
		}

		protected void txtCSNO_PreRender(object sender, System.EventArgs e)
		{
			ChkCSNO();
		}

		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Print_Bank_Statement_Voucher.aspx?VOUCHER_NO=" + lblVNo.Text + "&VOUCHER_DT=" + lblVDT.Text + "&VOUCHER_TYPE=" + VTYPE);
		}

		protected void lstBank_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstBank.SelectedValue == "0")
			{
				lstBank1.SelectedValue = "0";
				lstBank1.Visible = false;
				if (lblVNo.Visible == true)
				{
					txtCNO.Visible = false;
					txtCDT.Visible = false;

				}
				else
				{
					txtCNO.Visible = false;
					txtCDT.Visible = false;
					txtCDT.Text = txtVDT.Text.Trim();
					lblCDT.Text = txtCDT.Text.Trim();
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select NVL(max(to_number(substr(CHQ_NO,9,4))),0)+1 from T25_RV_DETAILS where to_char(CHQ_DT,'DD/mm/yyyy')='" + txtCDT.Text.Trim() + "' and BANK_CD=0 and substr(VCHR_NO,1,1)='" + Session["Region"].ToString() + "'", conn1);
					string sn = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();
					string dtMid = dateconcate(txtVDT.Text.Trim());
					lblCNO.Text = Session["Region"].ToString() + dtMid + "-" + sn;
					txtCNO.Text = lblCNO.Text;
					lblCNO.Visible = true;
					lblCDT.Visible = true;
					lblCash.Visible = true;
				}

			}
			else
			{
				txtCNO.Visible = true;
				txtCNO.Text = "";
				txtCDT.Visible = true;
				txtCDT.Text = "";
				lblCDT.Visible = false;
				lstBank1.Visible = true;
				lblCNO.Visible = false;
				lblCash.Visible = false;
			}

		}

		void GL_Entry(string pVocherNo, int pSno, string pVoucherDt, string pTransId)
		{
			try
			{
				int wUnit_Cd = 0, wSBU_Cd = 0;
				string wAcc_Cd = "", wProject_Cd = "", wSub_Cd = "", myQuery = "";
				if (pTransId == "I" || pTransId == "U")
				{
					if (Session["Region"].ToString() == "N") { wUnit_Cd = 8; wSBU_Cd = 20; }
					else if (Session["Region"].ToString() == "W") { wUnit_Cd = 5; wSBU_Cd = 17; }
					else if (Session["Region"].ToString() == "E") { wUnit_Cd = 6; wSBU_Cd = 18; }
					else if (Session["Region"].ToString() == "S") { wUnit_Cd = 7; wSBU_Cd = 19; }
					else if (Session["Region"].ToString() == "C") { wUnit_Cd = 10; wSBU_Cd = 23; }
					else { wUnit_Cd = 0; wSBU_Cd = 0; }

					if (lstACD.SelectedValue == "2709") { wAcc_Cd = "2709"; wProject_Cd = "2203"; wSub_Cd = "1"; }
					else if (Convert.ToInt16(lstACD.SelectedValue) > 2000 & Convert.ToInt16(lstACD.SelectedValue) < 2300) { wAcc_Cd = "2203"; wProject_Cd = lstACD.SelectedValue; wSub_Cd = "0"; }
					else if (Convert.ToInt16(lstACD.SelectedValue) > 3000 & Convert.ToInt16(lstACD.SelectedValue) < 3100) { wAcc_Cd = lstACD.SelectedValue; wProject_Cd = "2204"; wSub_Cd = "1"; }
					else if (lstACD.SelectedValue == "2210") { wAcc_Cd = "2093"; wProject_Cd = "2203"; wSub_Cd = "0"; }
					else if (lstACD.SelectedValue == "2212") { wAcc_Cd = "2094"; wProject_Cd = "2203"; wSub_Cd = "0"; }
					else { wAcc_Cd = "0000"; wProject_Cd = "0000"; wSub_Cd = ""; }
				}

				if (pTransId == "I")
				{
					myQuery = "Insert into GENERAL_FILE(UNIT_CODE,CURRY_CODE,VCHR_NUMB,VCHR_DATE,TC,ACC_CODE,SUB_CODE,REF_NO,PROJECT_CODE,SBU_CODE,NARRATION,AMOUNT,CHEQUE_NO,BANK_CODE,PARTY_NAME,REGION,VCHR_NO_T25,SNO_T25) " +
						"Values(" + wUnit_Cd + ",0,to_number(substr('" + pVocherNo + "',6,3)),to_date('" + pVoucherDt + "','dd/mm/yyyy'),2," + wAcc_Cd + ",trim('" + wSub_Cd + "'),1," + wProject_Cd + "," + wSBU_Cd + ",substr('" + txtNarrat.Text + "',1,30)," + txtAmt.Text + ",substr('" + txtCNO.Text.Trim() + "',1,6),substr('" + lstBank.SelectedItem.Text + "',1,4),rpad('" + lstBank1.SelectedItem.Text + "',35,' ')||'" + txtCDT.Text + "','" + Session["Region"].ToString() + "','" + pVocherNo + "'," + pSno + ")";
				}
				else if (pTransId == "U")
				{
					myQuery = "Update GENERAL_FILE Set ACC_CODE=" + wAcc_Cd + ",PARTY_NAME=rpad('" + lstBank1.SelectedItem.Text + "',35,' ')||'" + txtCDT.Text + "',CHEQUE_NO=substr('" + txtCNO.Text.Trim() + "',1,6),NARRATION=substr('" + txtNarrat.Text + "',1,30),AMOUNT=" + txtAmt.Text + " Where VCHR_NO_T25= '" + pVocherNo + "' and SNO_T25=" + pSno + " and POSTING_STATUS is null";
				}
				else if (pTransId == "D")
				{
					myQuery = "Delete from GENERAL_FILE Where VCHR_NO_T25= '" + pVocherNo + "' and SNO_T25=" + pSno + " and POSTING_STATUS is null";
				}
				else
				{
					myQuery = "";
				}
				OracleCommand myCommand = new OracleCommand(myQuery);
				myCommand.Connection = conn1;
				conn1.Open();
				myCommand.ExecuteNonQuery();
				conn1.Close();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str2);
			}
			finally
			{
				conn1.Close();
			}

		}
	}
}