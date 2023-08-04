using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.InterUnit_Reciept
{
	public partial class InterUnit_Reciept : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		public string VNO, Action;
		int SNO;
		protected System.Web.UI.WebControls.TextBox txtDtOfReciept;
		protected System.Web.UI.WebControls.TextBox txtBKNO;
		int ecode = 0;
		string wBank, wAcc;

		void show()
		{
			DataSet dsP = new DataSet();
			string str3 = "select V.VCHR_NO,to_char(V.VCHR_DT,'dd/mm/yyyy') VCHR_DT from T24_RV V where VCHR_NO='" + VNO + "' and VCHR_TYPE='I' ";
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			lblVDT.Visible = true;
			txtVDT.Visible = false;
			if (dsP.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("Invalid Voucher No. Or It is Not an Inter Unit Reciept!!!");
			}
			else
			{
				lblVNo.Text = dsP.Tables[0].Rows[0]["VCHR_NO"].ToString();
				lblVDT.Text = dsP.Tables[0].Rows[0]["VCHR_DT"].ToString();
			}

			conn1.Close();
			//							if(lblBank.Text.Trim().ToUpper()=="CASH")
			//							{
			//								lstBank1.SelectedValue="0";
			//								lstBank1.Visible=false;
			//								if(SNO==0)
			//								{
			//									lblCDT.Text=lblVDT.Text.Trim();
			//									txtCDT.Text=lblVDT.Text.Trim();
			//									txtCNO.Visible=false;
			//									txtCDT.Visible=false;
			//									conn1.Open();
			//									//OracleCommand cmd2 =new OracleCommand("Select to_char('"+txtVDT.Text+"','YYMMDD') from dual",conn1);
			//									
			//									string dtMid=dateconcate(lblVDT.Text);
			//									OracleCommand cmd3 =new OracleCommand("Select NVL(max(to_number(substr(CHQ_NO,9,4))),0)+1 from T25_RV_DETAILS where to_char(CHQ_DT,'DD/mm/yyyy')='"+lblVDT.Text.Trim()+"' and BANK_CD=0 and substr(VCHR_NO,1,1)='"+Session["Region"].ToString()+"'",conn1);
			//									string sn=Convert.ToString(cmd3.ExecuteScalar());
			//									conn1.Close();
			//									lblCNO.Text=Session["Region"].ToString()+dtMid+"-"+sn;
			//									txtCNO.Text=lblCNO.Text.Trim();
			//									
			//								}
			//								
			//							}
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
			//			if(lstACD.SelectedValue=="2201")
			//			{
			//				lblType.Text="R";
			//			}
			//			else if(lstACD.SelectedValue=="2202")
			//			{
			//				lblType.Text="F";
			//			}
			//			else if(lstACD.SelectedValue=="2203")
			//			{
			//				lblType.Text="U";
			//			}
			//			else if(lstACD.SelectedValue=="2204")
			//			{
			//				lblType.Text="P";
			//			}
			//			else if(lstACD.SelectedValue=="2205")
			//			{
			//				lblType.Text="S";
			//			}
			//			else
			//			{
			//			lblType.Text="";
			//			}

			txtNarrat.Text = dsP.Tables[0].Rows[0]["NARRATION"].ToString();
			txtCNO.Text = dsP.Tables[0].Rows[0]["CHQ_NO"].ToString();
			txtCDT.Text = dsP.Tables[0].Rows[0]["CHQ_DT"].ToString();
			txtAmt.Text = dsP.Tables[0].Rows[0]["AMOUNT"].ToString();
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
				string stra = "select ACC_CD,(ACC_DESC||':'||ACC_CD)ACC_DESC from T95_ACCOUNT_CODES where ACC_CD > 3000 Order by ACC_DESC ";
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

				DataSet dsP2 = new DataSet();
				string stra2 = "select BANK_CD,BANK_NAME from T94_BANK where BANK_CD > 990 order by BANK_NAME";
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

				if (Session["Region"].ToString() == "N") { wAcc = "3007"; wBank = "993"; }
				else if (Session["Region"].ToString() == "E") { wAcc = "3008"; wBank = "992"; }
				else if (Session["Region"].ToString() == "S") { wAcc = "3009"; wBank = "994"; }
				else if (Session["Region"].ToString() == "W") { wAcc = "3006"; wBank = "995"; }
				else if (Session["Region"].ToString() == "C") { wAcc = "3066"; wBank = "991"; }
				lstACD.SelectedValue = wAcc.ToString();
				lstACD.Items.Remove(lstACD.SelectedItem);
				lstBank1.SelectedValue = wBank.ToString();
				lstBank1.Items.Remove(lstBank1.SelectedItem);

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
						txtVNO.Visible = false;
						btnSearch.Visible = false;
						btnDel2.Visible = false;
						btnPrint.Visible = true;

						txtCNO.Visible = true;
						txtCDT.Visible = true;


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

						txtVNO.Visible = false;
						btnSearch.Visible = false;
						btnDel2.Visible = true;
						btnPrint.Visible = true;


						txtCNO.Visible = true;
						txtCDT.Visible = true;

						//SetFocus(txtCNO);
					}
					else if (Action == "D")
					{
						show();
						Panel.Visible = true;
						txtVNO.Visible = false;

						txtCNO.Visible = true;
						txtCDT.Visible = true;

						//btnSave.Visible =false;
					}
					else
					{
						txtVNO.Visible = true;
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

				fillgrid(VNO);
			}
			if (Session["Role_CD"].ToString() == "4")
			{
				btnAdd.Visible = false;
				btnSave1.Visible = false;
				btnDel2.Visible = false;
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
					string str1 = "select R.VCHR_NO,R.SNO,(R.ACC_CD||'-'||A.ACC_DESC)ACC_DESC,R.AMOUNT,NVL2(R.BPO_CD,B.BPO_CD||'-'||(B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY),'')BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.CASE_NO,D.BANK_NAME from T24_RV T24,T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D,T03_CITY C where T24.VCHR_NO=R.VCHR_NO and R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND B.BPO_CITY_CD=C.CITY_CD(+) and substr(T24.VCHR_NO,1,1)='" + Session["Region"] + "' AND T24.VCHR_NO= '" + vchr.Trim() + "' and T24.VCHR_TYPE='I' Order by R.SNO";
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
							string myInsertQueryM = "INSERT INTO T24_RV values('" + lblVNo.Text + "', to_date('" + txtVDT.Text + "','dd/mm/yyyy'),null,'I')";
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

						string myInsertQuery = "INSERT INTO T25_RV_DETAILS(VCHR_NO,SNO,ACC_CD,BANK_CD,CHQ_NO,CHQ_DT,NARRATION,SAMPLE_NO,AMOUNT,SUSPENSE_AMT,BPO_CD,POST_DT,STATUS,CASE_NO,BPO_TYPE,AMOUNT_ADJUSTED)values('" + lblVNo.Text + "'," + sno + ",'" + lstACD.SelectedValue + "'," + lstBank1.SelectedValue + ",'" + txtCNO.Text.Trim() + "',to_date('" + txtCDT.Text + "','dd/mm/yyyy'),'" + txtNarrat.Text + "',''," + txtAmt.Text + "," + txtAmt.Text + ",'" + lstBPO.SelectedValue + "','','','" + txtCSNO.Text + "','" + lblType.Text + "',0)";
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
					Response.Redirect("InterUnit_Reciept.aspx?Action=A&VOUCHER_NO=" + lblVNo.Text);
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

						string myInsertQuery = "INSERT INTO T25_RV_DETAILS(VCHR_NO,SNO,ACC_CD,BANK_CD,CHQ_NO,CHQ_DT,NARRATION,SAMPLE_NO,AMOUNT,SUSPENSE_AMT,BPO_CD,POST_DT,STATUS,CASE_NO,BPO_TYPE,AMOUNT_ADJUSTED)values('" + lblVNo.Text + "'," + sno + ",'" + lstACD.SelectedValue + "'," + lstBank1.SelectedValue + ",'" + txtCNO.Text.Trim() + "',to_date('" + txtCDT.Text + "','dd/mm/yyyy'),'" + txtNarrat.Text + "',''," + txtAmt.Text + "," + txtAmt.Text + ",'" + lstBPO.SelectedValue + "','','','" + txtCSNO.Text + "','" + lblType.Text + "',0)";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Connection = conn1;
						myInsertCommand.ExecuteNonQuery();

						conn1.Close();
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
					Response.Redirect("InterUnit_Reciept.aspx?Action=A&VOUCHER_NO=" + lblVNo.Text);
				}

			}
			else
			{
				string str11 = "Select NVL(AMOUNT_ADJUSTED,0) from T25_RV_DETAILS where VCHR_NO= '" + VNO + "' AND SNO=" + SNO;
				OracleCommand myUpdateCommand11 = new OracleCommand(str11);
				myUpdateCommand11.Connection = conn1;
				conn1.Open();
				double amtadj = Convert.ToDouble(myUpdateCommand11.ExecuteScalar());
				conn1.Close();

				if (amtadj <= Convert.ToDouble(txtAmt.Text))
				{
					string str = "Update T25_RV_DETAILS set ACC_CD='" + lstACD.SelectedValue + "',BANK_CD=" + lstBank1.SelectedValue + ",CHQ_NO='" + txtCNO.Text.Trim() + "',CHQ_DT=to_date('" + txtCDT.Text + "','dd/mm/yyyy'),NARRATION='" + txtNarrat.Text + "',AMOUNT=" + txtAmt.Text + ",SUSPENSE_AMT=" + Convert.ToString(Convert.ToDouble(txtAmt.Text) - amtadj) + ",BPO_CD='" + lstBPO.SelectedValue + "',CASE_NO='" + txtCSNO.Text + "',BPO_TYPE='" + lblType.Text + "' where VCHR_NO= '" + VNO + "' AND SNO=" + SNO;
					OracleCommand myUpdateCommand = new OracleCommand(str);
					myUpdateCommand.Connection = conn1;
					conn1.Open();
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();
					Response.Redirect("InterUnit_Reciept.aspx?Action=A&VOUCHER_NO=" + lblVNo.Text);
				}
				else
				{
					DisplayAlert("This Check Has Already Posted, and the Amount Adjusted is greater the New Cheque Amount. So, You Cannot modify the cheque amount!!!");
				}

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
					//					while(reader.Read())
					//					{
					//				
					//						txtNarrat.Text=reader["VEND_NAME"].ToString();
					//					}
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
			conn1.Close();
			if (chqpoststatus == 0)
			{

				string myDeleteQuery = "Delete T25_RV_DETAILS  where VCHR_NO= '" + VNO + "' AND SNO=" + SNO;
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
				conn1.Close();

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
					Response.Redirect("InterUnit_Reciept.aspx?Action=A&VOUCHER_NO=" + lblVNo.Text);
				}
				else
				{
					Response.Redirect("InterUnit_Reciept.aspx?Action=A");
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
				Response.Redirect("InterUnit_Reciept.aspx?Action=A&VOUCHER_NO=" + VNO);
			}
			else
			{
				Response.Redirect("InterUnit_Reciept.aspx?Action=A&VOUCHER_NO=" + txtVNO.Text.Trim());
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
				if (Session["Role_CD"].ToString() == "1")
				{
					Response.Redirect("MainForm.aspx");
				}
				else
				{
					Response.Redirect("MainForm1.aspx");
				}
			}
			else
			{
				Response.Redirect("InterUnit_Reciept.aspx?Action=M");
			}
		}



		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			fillgrid(txtVNO.Text.Trim());
			if (grdVDt.Visible == false)
			{
				DisplayAlert("Invalid IU Advice Voucher!!! ");
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
				Response.Redirect("InterUnit_Reciept.aspx?Action=A&VOUCHER_NO=" + txtVNO.Text);

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
			Response.Redirect("Print_Bank_Statement_Voucher.aspx?VOUCHER_NO=" + lblVNo.Text + "&VOUCHER_DT=" + lblVDT.Text + "&VOUCHER_TYPE=E");
		}





	}
}