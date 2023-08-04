using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Multiple_Inspection_Certificate_Form
{
	public partial class Multiple_Inspection_Certificate_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		int ecode = 0;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				btnGBill.Visible = false;
				Label.Visible = false;

				ListItem lst1 = new ListItem();
				lst1.Text = "Man days Basis";
				lst1.Value = "D";
				lstBPOFeeType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Hourly Basis";
				lst1.Value = "H";
				lstBPOFeeType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Lump sum";
				lst1.Value = "L";
				lstBPOFeeType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Percentage Basis";
				lst1.Value = "P";
				lstBPOFeeType.Items.Add(lst1);
				lstBPOFeeType.Items.Insert(0, "");

				ListItem lst2 = new ListItem();
				lst2.Text = "Fee Inclusive Service Tax";
				lst2.Value = "I";
				lstBPOTaxType.Items.Add(lst2);
				lst2 = new ListItem();
				lst2.Text = "Tax/VAT Charged separately";
				lst2.Value = "X";
				lstBPOTaxType.Items.Add(lst2);
				lstBPOTaxType.Items.Insert(0, "");
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

		protected void btnView_Click(object sender, System.EventArgs e)
		{
			fillgrid();
			btnGBill.Visible = true;
			Label.Visible = true;
			BPOFee();

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
				string str1 = "select T13.CASE_NO, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT, T17.CALL_SNO,T18.CONSIGNEE_CD,trim(T06.CONSIGNEE_DESIG)||'/'||trim(T06.CONSIGNEE_DEPT)||'/'||trim(T06.CONSIGNEE_FIRM) CONSIGNEE,T18.ITEM_SRNO_PO, T18.ITEM_DESC_PO,T18.QTY_DUE, T18.QTY_PASSED, T18.QTY_REJECTED, T20.IC_NO, T20.BK_NO, T20.SET_NO, T20.NO_OF_INSP FROM T13_PO_MASTER T13,T14_PO_BPO T14, T17_CALL_REGISTER T17, T18_CALL_DETAILS T18, T20_IC T20,T06_CONSIGNEE T06 WHERE T13.CASE_NO=T14.CASE_NO AND T13.CASE_NO=T17.CASE_NO AND T17.CASE_NO=T20.CASE_NO AND T14.CONSIGNEE_CD=T18.CONSIGNEE_CD and T18.CONSIGNEE_CD=T06.CONSIGNEE_CD and T17.CASE_NO=T18.CASE_NO AND T17.CALL_RECV_DT=T18.CALL_RECV_DT AND T17.CALL_SNO=T18.CALL_SNO AND T17.CASE_NO=T20.CASE_NO AND T17.CALL_RECV_DT=T20.CALL_RECV_DT AND T17.CALL_SNO=T20.CALL_SNO AND T18.CONSIGNEE_CD=T20.CONSIGNEE_CD AND T14.BPO_CD='" + lstBPO.SelectedValue + "' AND T20.BILL_NO IS NULL and T20.IC_TYPE_ID=1 ORDER BY CASE_NO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCDetails.Visible = false;
					DisplayAlert("Their are no IC present for given BPO!!! ");

				}
				else
				{
					grdCDetails.DataSource = dsP;
					grdCDetails.DataBind();
					grdCDetails.Visible = true;

					//grdCDetails.Columns[0].Visible=false;
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
		protected void btnFC_List_Click(object sender, System.EventArgs e)
		{
			try
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
		int fill_BPO(string bpo)
		{
			lstBPO.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "";

			str1 = "select BPO_CD,(BPO_NAME||'/'||BPO_ADD||'/'||BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER where (trim(upper(BPO_CD))=upper('" + txtBPO.Text.Trim() + "') or trim(upper(BPO_NAME)) LIKE upper('" + txtBPO.Text.Trim() + "%')) ORDER BY BPO_NAME";

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

		protected void lstBPO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtBPO.Text = lstBPO.SelectedValue;
		}

		private void grdCDetails_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}
		void BPOFee()
		{
			string str3 = "select B.BPO_CD,B.BPO_RLY,B.BPO_FEE,B.BPO_FEE_TYPE,NVL(B.BPO_TAX_TYPE,'X')BPO_TAX_TYPE from T12_BILL_PAYING_OFFICER B where BPO_CD='" + lstBPO.SelectedValue + "'";
			OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
			conn1.Open();
			OracleDataReader reader1 = myOracleCommand3.ExecuteReader();
			while (reader1.Read())
			{

				txtBPOFee.Text = reader1["BPO_FEE"].ToString();
				lstBPOFeeType.SelectedValue = reader1["BPO_FEE_TYPE"].ToString();
				lstBPOTaxType.SelectedValue = reader1["BPO_TAX_TYPE"].ToString();
			}
			conn1.Close();
		}
		protected void btnGBill_Click(object sender, System.EventArgs e)
		{
			StringBuilder sb = new StringBuilder();

			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("SELECT NVL(MAX(TO_NUMBER(NVL(SUBSTR(KEY,2,5),0))),0)+1 FROM TEMP20_MULTI_IC WHERE SUBSTR(KEY,1,1)='" + Session["Region"].ToString() + "'", conn1);
			int ss = Convert.ToInt32(cmd2.ExecuteScalar());
			conn1.Close();

			string k = Session["Region"].ToString() + ss;
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{
				foreach (DataGridItem DGridItem in grdCDetails.Items)
				{
					CheckBox myCheckbox = (CheckBox)DGridItem.FindControl("SelIC");

					if (myCheckbox.Checked == true)
					{


						string myInsertQueryM = "INSERT INTO TEMP20_MULTI_IC(KEY,CASE_NO,CALL_RECV_DT,CALL_SNO,CONSIGNEE_CD,NO_OF_INSP) values('" + k + "', '" + DGridItem.Cells[1].Text + "',to_date('" + DGridItem.Cells[2].Text + "','dd/mm/yyyy')," + DGridItem.Cells[3].Text + "," + DGridItem.Cells[7].Text + "," + DGridItem.Cells[10].Text + ")";
						OracleCommand myInsertCommandM = new OracleCommand(myInsertQueryM);
						myInsertCommandM.Transaction = myTrans;
						myInsertCommandM.Connection = conn1;
						myInsertCommandM.ExecuteNonQuery();


						//sb.Append(DGridItem.Cells[5].Text+" :: ");
					}

				}
				myTrans.Commit();
				conn1.Close();

				//				OracleCommand cmd = new OracleCommand("GENERATE_BILL",conn1);
				//				cmd.CommandType = CommandType.StoredProcedure;
				//				conn1.Open();
				//				OracleParameter prm1 = new OracleParameter("IN_REGION_CD",System.Data.OracleClient.OracleType.Char);
				//				prm1.Direction = ParameterDirection.Input;
				//				prm1.Value = Session["REGION"];
				//				cmd.Parameters.Add(prm1);
				//
				//				OracleParameter prm1 = new OracleParameter("IN_BILL",System.Data.OracleClient.OracleType.VarChar);
				//				prm1.Direction = ParameterDirection.Input;
				//				if(lblBillNo.Visible==true)
				//				{
				//					prm1.Value = lblBillNo.Text;
				//					
				//				}
				//				else
				//				{
				//					prm1.Value = "X";
				//				}
				//				cmd.Parameters.Add(prm1);
				//
				//
				//				OracleParameter prm2 = new OracleParameter("IN_FEE_TYPE",System.Data.OracleClient.OracleType.Char);
				//				prm2.Direction = ParameterDirection.Input;
				//				prm2.Value = lstBPOFeeType.SelectedValue;
				//				cmd.Parameters.Add(prm2);
				//
				//				OracleParameter prm3 = new OracleParameter("IN_FEE",System.Data.OracleClient.OracleType.Number);
				//				prm3.Direction = ParameterDirection.Input;
				//				prm3.Value = txtBPOFee.Text;
				//				cmd.Parameters.Add(prm3);
				//
				//				OracleParameter prm4 = new OracleParameter("IN_TAX_TYPE",System.Data.OracleClient.OracleType.Char);
				//				prm4.Direction = ParameterDirection.Input;
				//				prm4.Value = lstBPOTaxType.SelectedValue;
				//				cmd.Parameters.Add(prm4);
				//
				//				
				//
				//				OracleParameter prm5 = new OracleParameter("IN_MAX_FEE",System.Data.OracleClient.OracleType.Number);
				//				prm5.Direction = ParameterDirection.Input;
				//				if(txtMaxFeeAllow.Text.Trim()=="")
				//				{
				//					prm5.Value = -1; //In Case OF MAXM FEE is NULL
				//				}
				//				else
				//				{
				//					prm5.Value = Convert.ToInt32(txtMaxFeeAllow.Text);
				//				}
				//				cmd.Parameters.Add(prm5);
				//
				//				OracleParameter prm6 = new OracleParameter("IN_MIN_FEE",System.Data.OracleClient.OracleType.Number);
				//				prm6.Direction = ParameterDirection.Input;
				//				if(txtMinFeeAllow.Text.Trim()=="")
				//				{
				//					prm6.Value = 0;
				//				}
				//				else
				//				{
				//					prm6.Value = Convert.ToInt32(txtMinFeeAllow.Text);
				//				}
				//				cmd.Parameters.Add(prm6);
				//
				//				OracleParameter prm7 = new OracleParameter("IN_BILL_DT",System.Data.OracleClient.OracleType.VarChar,8);
				//				prm7.Direction = ParameterDirection.Input;
				//				prm7.Value = Convert.ToString(txtBDT.Text.Replace("/",""));
				//				cmd.Parameters.Add(prm7);
				//
				//				OracleParameter prm8 = new OracleParameter("OUT_ERR_CD",System.Data.OracleClient.OracleType.Number,1);
				//				prm8.Direction = ParameterDirection.Output;
				//				cmd.Parameters.Add(prm8);
				//
				//				OracleParameter prm9 = new OracleParameter("OUT_BILL",System.Data.OracleClient.OracleType.VarChar,20);
				//				prm9.Direction = ParameterDirection.Output;
				//				cmd.Parameters.Add(prm9);
				//
				//				OracleParameter prm10 = new OracleParameter("OUT_FEE",System.Data.OracleClient.OracleType.Number,15);
				//				prm10.Direction = ParameterDirection.Output;
				//				cmd.Parameters.Add(prm10);
				//
				//				cmd.ExecuteNonQuery();
				//				conn1.Close();




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


			//Label.Text = sb.ToString();
		}

	}
}