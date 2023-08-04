using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Reciepts_Form
{
	public partial class Reciepts_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		public string BNO, Action;
		int SRNO;
		protected System.Web.UI.WebControls.TextBox txtDtOfReciept;
		protected System.Web.UI.WebControls.TextBox txtBKNO;

		void show()
		{
			DataSet dsP = new DataSet();
			string str3 = "select BILL_NO,BILL_AMOUNT,AMOUNT_RECEIVED from T22_BILL where BILL_NO='" + BNO + "' ";
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			Label2.Visible = true;
			txtAmtRec.Visible = true;
			txtBillNo.Text = dsP.Tables[0].Rows[0]["BILL_NO"].ToString();
			txtBillAmt.Text = dsP.Tables[0].Rows[0]["BILL_AMOUNT"].ToString();
			txtAmtRec.Text = dsP.Tables[0].Rows[0]["AMOUNT_RECEIVED"].ToString();

			conn1.Close();
		}
		void show1()
		{
			DataSet dsP = new DataSet();
			string str3 = "select BILL_NO,INSTRUMENT_TYPE,TO_CHAR(INSTRUMENT_DATE,'dd/mm/yyyy')INSTRUMENT_DATE,INSTRUMENT_NO,BANK,INSTRUMENT_AMT,AMT_REALISED from T24_RECEIPTS where BILL_NO='" + BNO + "' AND SRNO=" + SRNO;
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			lstIType.SelectedValue = dsP.Tables[0].Rows[0]["INSTRUMENT_TYPE"].ToString();
			txtIDT.Text = dsP.Tables[0].Rows[0]["INSTRUMENT_DATE"].ToString();
			txtINO.Text = dsP.Tables[0].Rows[0]["INSTRUMENT_NO"].ToString();
			txtBank.Text = dsP.Tables[0].Rows[0]["BANK"].ToString();
			txtIAmt.Text = dsP.Tables[0].Rows[0]["INSTRUMENT_AMT"].ToString();
			txtAmtRel.Text = dsP.Tables[0].Rows[0]["AMT_REALISED"].ToString();


			conn1.Close();
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//btnAdd.Attributes.Add("OnClick", "JavaScript:validate();"); 
			//btnMod.Attributes.Add("OnClick", "JavaScript:validate();"); 
			//btnSave1.Attributes.Add("OnClick", "JavaScript:validate();"); 
			//btnDelete.Attributes.Add("OnClick", "JavaScript:del();"); 


			if (Convert.ToString(Request.Params["BILL_NO"]) == "")
			{
				BNO = "";
				Action = "";
			}
			else if (Convert.ToString(Request.Params["BILL_NO"]) != "" && Convert.ToString(Request.Params["Action"]) != "")
			{
				BNO = Convert.ToString(Request.Params["BILL_NO"]);
				Action = Convert.ToString(Request.Params["Action"]);
				txtBillNo.Text = BNO;
				if (Request.Params["SRNO"] == "" || Request.Params["SRNO"] == null)
				{
					SRNO = 0;
				}
				else
				{
					SRNO = Convert.ToInt32(Request.Params["SRNO"]);

				}

			}

			if (!(IsPostBack))
			{
				ListItem lst1 = new ListItem();
				lst1.Text = "Cheque";
				lst1.Value = "C";
				lstIType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Draft";
				lst1.Value = "D";
				lstIType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "JV";
				lst1.Value = "J";
				lstIType.Items.Add(lst1);
				lstIType.Items.Insert(0, "");
				if (Convert.ToString(Request.Params["BILL_NO"]) != "" && Convert.ToString(Request.Params["Action"]) != "")
				{
					if (Request.Params["SRNO"] == "" || Request.Params["SRNO"] == null)
					{
						SRNO = 0;
					}
					else
					{
						SRNO = Convert.ToInt32(Request.Params["SRNO"]);
						show1();
					}
				}

				if (Action == "A")
				{
					//btnDelete.Visible =false;
					//btnInsDt.Visible=false;

					try
					{

						OracleCommand cmd = new OracleCommand("select BILL_AMOUNT from T22_BILL where BILL_NO='" + BNO + "'", conn1);
						conn1.Open();
						long bamt = Convert.ToInt64(cmd.ExecuteScalar());
						txtBillAmt.Text = bamt.ToString();
						Label2.Visible = false;
						txtAmtRec.Visible = false;
						Label9.Visible = false;
						Panel.Visible = true;
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
				else
				{

					try
					{

						if (Action == "M")
						{
							show();
							Panel.Visible = true;
							fillgrid();
							//btnDelete.Visible =false;

						}
						else if (Action == "D")
						{
							show();
							Panel.Visible = true;
							fillgrid();
							//btnSave.Visible =false;
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


		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{

				string myDeleteQuery1 = "Delete T24_RECEIPTS  where BILL_NO= '" + BNO + "'";
				OracleCommand myOracleCommand1 = new OracleCommand(myDeleteQuery1);
				myOracleCommand1.Transaction = myTrans;
				myOracleCommand1.Connection = conn1;
				myOracleCommand1.ExecuteNonQuery();

				//string myDeleteQuery = "Delete T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and BK_NO='"+BK+"'"; 
				//				string myDeleteQuery = "Delete T24_RECEIPTS where BILL_NO= '" + BNO + "'"; 
				//				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery); 
				//				myOracleCommand.Transaction=myTrans;
				//				myOracleCommand.Connection = conn1; 
				//				myOracleCommand.ExecuteNonQuery(); 

				myTrans.Commit();
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

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{

				if (txtBillAmt.Text == "")
				{
					txtBillAmt.Text = "null";
				}
				if (txtAmtRec.Text == "")
				{
					txtAmtRec.Text = "null";
				}

				if (Action == "A")
				{
					string myInsertQuery = "INSERT INTO T24_RECEIPTS values('" + txtBillNo.Text + "', " + txtBillAmt.Text + ",0)";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					conn1.Open();
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();

				}
				else if (Action == "M")
				{
					//string myUpdateQuery = "Update T20_IC set CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy'),BK_NO='" + txtBK_NO.Text + "',SET_NO= '" + txtSetNo.Text + "',IE_CD=" + lstIE.SelectedItem.Value + ",IC_NO='" + txtCertNo.Text + "',IC_DT=to_date('" + txtCertDt.Text + "','dd/mm/yyyy'),STAMP_PATTERN='" + txtPattern.Text + "',REASON_REJECT='" + txtReason.Text + "' where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy')and BK_NO='"+ BK +"'"; 
					string myUpdateQuery = "Update T24_RECEIPTS set BILL_AMOUNT=" + txtBillAmt.Text + ",AMOUNT_RECEIVED=" + txtAmtRec.Text + " where BILL_NO= '" + BNO + "'";
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn1;
					conn1.Open();
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();
				}
				//btnInsDt.Visible=true;

			}
			catch (OracleException ex)
			{
				string str;
				str = ex.Message;

				if (ex.ErrorCode == 00001)
				{
					DisplayAlert("Record Already Present For the Given Bill No.So use Modify to Update it.");
				}
				else
				{
					string str1 = str.Replace("\n", "");
					Response.Redirect(("Error_Form.aspx?err=" + str1));
				}
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
		private void btnInsDt_Click(object sender, System.EventArgs e)
		{
			Panel.Visible = true;
			fillgrid();
		}

		void fillgrid()
		{
			try
			{
				string str1 = "select SRNO,BILL_NO,DECODE(INSTRUMENT_TYPE,'C','Cheque','D','Draft','J','JV')INSTRUMENT_TYPE,to_char(INSTRUMENT_DATE,'dd/mm/yyyy')INSTRUMENT_DATE,INSTRUMENT_NO,BANK,INSTRUMENT_AMT,AMT_REALISED from T24_RECEIPTS where BILL_NO= '" + BNO + "'";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdInsDt.Visible = false;
				}
				else
				{
					grdInsDt.Visible = true;
					grdInsDt.DataSource = dsP;
					grdInsDt.DataBind();
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

			//			OracleCommand cmd11=new OracleCommand("Select BILL_NO from T22_BILL where BILL_NO='"+BNO+"'",conn1);
			//			conn1.Open();
			//			string status=Convert.ToString(cmd11.ExecuteScalar());
			//			if(status==""||status==null)
			//			{
			//				string myInsertQuery = "UPDATE T22_BILL set (AMOUNT_RECEIVED) values("+txtIAmt.Text+")"; 
			//				OracleCommand myInsertCommand = new OracleCommand(myInsertQuery); 
			//				myInsertCommand.Connection = conn1; 
			//				myInsertCommand.ExecuteNonQuery(); 
			//			
			//			}
			OracleCommand cmd = new OracleCommand("Select NVL(AMOUNT_RECEIVED,0) from T22_BILL where BILL_NO='" + BNO + "'", conn1);
			conn1.Open();
			double bamt = Convert.ToDouble(cmd.ExecuteScalar());
			if (SRNO == 0)
			{
				string str3 = "select NVL(max(SRNO),0) from T24_RECEIPTS where BILL_NO= '" + BNO + "'";
				OracleCommand cmd1 = new OracleCommand(str3, conn1);
				int sno = Convert.ToInt32(cmd1.ExecuteScalar());
				sno = sno + 1;
				//			if(Act=="")
				//			{
				string myInsertQuery = "INSERT INTO T24_RECEIPTS(BILL_NO,SRNO,INSTRUMENT_TYPE,INSTRUMENT_DATE,INSTRUMENT_NO,BANK,INSTRUMENT_AMT,AMT_REALISED)values('" + txtBillNo.Text + "', " + sno + ",'" + lstIType.SelectedValue + "',to_date('" + txtIDT.Text + "','dd/mm/yyyy'),'" + txtINO.Text + "','" + txtBank.Text + "'," + txtIAmt.Text + "," + txtAmtRel.Text + ")";
				OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
				myInsertCommand.Connection = conn1;
				myInsertCommand.ExecuteNonQuery();
				bamt = bamt + Convert.ToDouble(txtIAmt.Text);

				OracleCommand cmd2 = new OracleCommand("Update T22_BILL SET AMOUNT_RECEIVED=" + bamt + " where BILL_NO='" + BNO + "'", conn1);
				cmd2.ExecuteNonQuery();
				conn1.Close();



			}
			else
			{
				//				//string myUpdateQuery = "Update T20_IC set CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy'),BK_NO='" + txtBK_NO.Text + "',SET_NO= '" + txtSetNo.Text + "',IE_CD=" + lstIE.SelectedItem.Value + ",IC_NO='" + txtCertNo.Text + "',IC_DT=to_date('" + txtCertDt.Text + "','dd/mm/yyyy'),STAMP_PATTERN='" + txtPattern.Text + "',REASON_REJECT='" + txtReason.Text + "' where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy')and BK_NO='"+ BK +"'"; 

				OracleCommand cmd3 = new OracleCommand("Select INSTRUMENT_AMT from T24_RECEIPTS where BILL_NO='" + BNO + "' AND SRNO=" + SRNO, conn1);
				double amtr = Convert.ToDouble(cmd3.ExecuteScalar());
				bamt = (bamt - amtr) + Convert.ToDouble(txtIAmt.Text);

				string str = "Update T24_RECEIPTS set INSTRUMENT_TYPE='" + lstIType.SelectedValue + "',INSTRUMENT_DATE=to_date('" + txtIDT.Text + "','dd/mm/yyyy'),INSTRUMENT_NO='" + txtINO.Text + "',BANK='" + txtBank.Text + "',INSTRUMENT_AMT=" + txtIAmt.Text + ",AMT_REALISED=" + txtAmtRel.Text + " where BILL_NO= '" + BNO + "' AND SRNO=" + SRNO;
				OracleCommand myUpdateCommand = new OracleCommand(str);
				myUpdateCommand.Connection = conn1;
				myUpdateCommand.ExecuteNonQuery();


				OracleCommand cmd2 = new OracleCommand("Update T22_BILL SET AMOUNT_RECEIVED=" + bamt + " where BILL_NO='" + BNO + "'", conn1);
				cmd2.ExecuteNonQuery();
				conn1.Close();
			}

			fillgrid();
			Label2.Visible = true;
			txtAmtRec.Visible = true;
			Label9.Visible = false;
			txtAmtRec.Text = bamt.ToString();
		}

		protected void btnDel2_Click(object sender, System.EventArgs e)
		{
			try
			{
				//string myDeleteQuery = "Delete T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and BK_NO='"+BK+"'"; 
				SRNO = Convert.ToInt32(Request.Params["SRNO"]);
				OracleCommand cmd = new OracleCommand("Select NVL(AMOUNT_RECEIVED,0) from T22_BILL where BILL_NO='" + BNO + "'", conn1);
				conn1.Open();
				double bamt = Convert.ToDouble(cmd.ExecuteScalar());

				string myDeleteQuery = "Delete T24_RECEIPTS  where BILL_NO= '" + BNO + "' AND SRNO=" + SRNO;
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				myOracleCommand.ExecuteNonQuery();



				bamt = bamt - Convert.ToDouble(txtIAmt.Text);
				OracleCommand cmd2 = new OracleCommand("Update T22_BILL SET AMOUNT_RECEIVED=" + bamt + " where BILL_NO='" + BNO + "'", conn1);
				cmd2.ExecuteNonQuery();
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

			Response.Redirect("Reciepts_Form.aspx?Action=" + Action + "&BILL_NO=" + BNO);
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Reciepts_Form.aspx?Action=M&BILL_NO=" + BNO);
		}


	}
}