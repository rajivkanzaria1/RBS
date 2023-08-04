using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Inspection_Fee_Bill
{
	public partial class Inspection_Fee_Bill : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		string BNO, Action;


		void show()
		{
			try
			{
				DataSet dsP1 = new DataSet();
				string str1 = "select BILL_NO,to_char(BILL_DT,'dd/mm/yyyy')BILL_DT,CASE_NO,MATERIAL_VALUE,FEE_TYPE,FEE_RATE,TAX_TYPE,INSP_FEE,SERVICE_TAX,EDU_CESS,SHE_CESS,SWACHH_BHARAT_CESS,KRISHI_KALYAN_CESS,MAX_FEE,MIN_FEE,nvl(BILL_AMOUNT,0)BILL_AMOUNT,NVL(TDS,0)TDS,NVL(RETENTION_MONEY,0)RETENTION_MONEY, NVL(WRITE_OFF_AMT,0)WRITE_OFF_AMT,NVL(CGST,0)CGST, NVL(SGST,0)SGST, NVL(IGST,0)IGST, NVL(CNOTE_AMOUNT,0)CNOTE_AMT from T22_BILL where BILL_NO= '" + BNO + "'";
				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("Record not found for the given Bill No.!!! ");
				}
				else
				{
					txtBillNo.Text = dsP1.Tables[0].Rows[0]["BILL_NO"].ToString();
					lblBNO.Text = dsP1.Tables[0].Rows[0]["BILL_NO"].ToString();
					txtBillDt.Text = dsP1.Tables[0].Rows[0]["BILL_DT"].ToString();
					txtCaseNo.Text = dsP1.Tables[0].Rows[0]["CASE_NO"].ToString();
					txtBAmt.Text = dsP1.Tables[0].Rows[0]["MATERIAL_VALUE"].ToString();
					lblBAmt.Text = dsP1.Tables[0].Rows[0]["BILL_AMOUNT"].ToString();
					lblTds.Text = dsP1.Tables[0].Rows[0]["TDS"].ToString();
					lblRetMoney.Text = dsP1.Tables[0].Rows[0]["RETENTION_MONEY"].ToString();
					lblWriteOffAmt.Text = dsP1.Tables[0].Rows[0]["WRITE_OFF_AMT"].ToString();
					lblCNoteAmt.Text = dsP1.Tables[0].Rows[0]["CNOTE_AMT"].ToString();
					//								txtDtOfReciept.Text =dsP1.Tables[0].Rows[0]["CALL_RECV_DT"].ToString(); 
					//								lstBPO.SelectedValue=dsP1.Tables[0].Rows[0]["BPO_CD"].ToString(); 
					//								lstVend.SelectedValue=dsP1.Tables[0].Rows[0]["VEND_CD"].ToString(); 
					//								lstConsignee.SelectedValue=dsP1.Tables[0].Rows[0]["CONSIGNEE_CD"].ToString();
					//								txtCertNo.Text=dsP1.Tables[0].Rows[0]["IC_NO"].ToString(); 
					//								txtCertDt.Text=dsP1.Tables[0].Rows[0]["IC_DT"].ToString (); 
					//								txtCInstallNo.Text = dsP1.Tables[0].Rows[0]["CALL_INSTALL_NO"].ToString (); 
					//								txtBKNo.Text =dsP1.Tables[0].Rows[0]["BK_NO"].ToString (); 
					//								txtSetNo.Text=dsP1.Tables[0].Rows[0]["SET_NO"].ToString (); 
					//								txtBillAmt.Text=dsP1.Tables[0].Rows[0]["BILL_AMOUNT"].ToString ();
					lstBPOFeeType.SelectedValue = dsP1.Tables[0].Rows[0]["FEE_TYPE"].ToString();
					txtFRate.Text = dsP1.Tables[0].Rows[0]["FEE_RATE"].ToString();
					if (dsP1.Tables[0].Rows[0]["TAX_TYPE"].ToString() == "")
					{
						lstBPOTaxType.SelectedValue = "X";
					}
					else
					{
						string myYear1, myMonth1, myDay1;
						myYear1 = txtBillDt.Text.Substring(6, 4);
						myMonth1 = txtBillDt.Text.Substring(3, 2);
						myDay1 = txtBillDt.Text.Substring(0, 2);
						string billdt = myYear1 + myMonth1 + myDay1;


						if (Convert.ToInt32(billdt) >= 20170701)
						{
							lstBPOTaxType_GST.SelectedValue = dsP1.Tables[0].Rows[0]["TAX_TYPE"].ToString();
							lstBPOTaxType_GST.SelectedValue = dsP1.Tables[0].Rows[0]["TAX_TYPE"].ToString();
							lstBPOTaxType.Visible = false;
						}
						else
						{
							lstBPOTaxType.SelectedValue = dsP1.Tables[0].Rows[0]["TAX_TYPE"].ToString();
							lstBPOTaxType.SelectedValue = dsP1.Tables[0].Rows[0]["TAX_TYPE"].ToString();
							lstBPOTaxType_GST.Visible = false;
						}

					}
					txtInsFee.Text = dsP1.Tables[0].Rows[0]["INSP_FEE"].ToString();
					txtServTax.Text = dsP1.Tables[0].Rows[0]["SERVICE_TAX"].ToString();
					txtEduCess.Text = dsP1.Tables[0].Rows[0]["EDU_CESS"].ToString();
					txtSEduCess.Text = dsP1.Tables[0].Rows[0]["SHE_CESS"].ToString();
					txtSBCess.Text = dsP1.Tables[0].Rows[0]["SWACHH_BHARAT_CESS"].ToString();
					txtKKCess.Text = dsP1.Tables[0].Rows[0]["KRISHI_KALYAN_CESS"].ToString();
					txtTFee.Text = dsP1.Tables[0].Rows[0]["BILL_AMOUNT"].ToString();
					txtMaxFeeAll.Text = dsP1.Tables[0].Rows[0]["MAX_FEE"].ToString();
					txtMinFee.Text = dsP1.Tables[0].Rows[0]["MIN_FEE"].ToString();
					txtSGST.Text = dsP1.Tables[0].Rows[0]["SGST"].ToString();
					txtCGST.Text = dsP1.Tables[0].Rows[0]["CGST"].ToString();
					txtIGST.Text = dsP1.Tables[0].Rows[0]["IGST"].ToString();
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

		void fillgrid1()
		{

			try
			{
				string str1 = "select T94.BANK_NAME,T25.CHQ_NO, to_char(T25.CHQ_DT,'dd/mm/yyyy')CHQ_DT, T25.AMOUNT,T26.AMOUNT_CLEARED from T25_RV_DETAILS T25, T26_CHEQUE_POSTING T26,T94_BANK T94 where T25.CHQ_NO=T26.CHQ_NO and T25.CHQ_DT=T26.CHQ_DT and T25.BANK_CD=T26.BANK_CD and T25.BANK_CD=T94.BANK_CD and T26.BILL_NO='" + txtBillNo.Text + "'";
				DataSet dsP1 = new DataSet();
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					Panel1.Visible = false;
					//grdCHQDetails.Visible =false;
				}
				else
				{

					Panel1.Visible = true;
					//grdCHQDetails.Visible =true;
					grdCHQDetails.DataSource = dsP1;
					grdCHQDetails.DataBind();
					conn1.Close();
					double amtclear = 0;
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
					{
						amtclear = amtclear + Convert.ToDouble(dsP1.Tables[0].Rows[i]["AMOUNT_CLEARED"].ToString());

					}
					lblTamtRec.Text = Convert.ToString(amtclear + Convert.ToDouble(lblTds.Text) + Convert.ToDouble(lblRetMoney.Text) + Convert.ToDouble(lblWriteOffAmt.Text) + Convert.ToDouble(lblCNoteAmt.Text));
					double amttorec = Convert.ToDouble(lblBAmt.Text) - Convert.ToDouble(lblTamtRec.Text);
					lblBAmtRec.Text = Convert.ToString(amtclear);
					lblAmtToRec.Text = Convert.ToString(amttorec);

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


		void fillgrid()
		{

			try
			{
				string str1 = "select B.BILL_NO, B.ITEM_SRNO, B.ITEM_DESC, B.QTY, B.RATE,U.UOM_S_DESC UOM_CD,B.BASIC_VALUE, B.SALES_TAX_PER,B.SALES_TAX, B.EXCISE_PER, B.EXCISE, B.DISCOUNT_PER, B.DISCOUNT, B.OTHER_CHARGES, B.VALUE from T23_BILL_ITEMS B, T04_UOM U where B.UOM_CD= U.UOM_CD and BILL_NO='" + BNO + "'";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdBDetails.Visible = false;
				}
				else
				{
					grdBDetails.Visible = true;
					grdBDetails.DataSource = dsP;
					grdBDetails.DataBind();
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

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");




			if (Convert.ToString(Request.Params["BILL_NO"]) == null)
			{
				BNO = "";


			}
			else
			{
				BNO = Convert.ToString(Request.Params["BILL_NO"].Trim());
				Action = Convert.ToString(Request.Params["Action"]);

			}

			if (!(IsPostBack))
			{

				try
				{
					//					DataSet dsP = new DataSet(); 
					//					string str = "select BPO_CD, BPO_NAME from T12_BILL_PAYING_OFFICER"; 
					//					OracleDataAdapter da = new OracleDataAdapter(str, conn1); 
					//					OracleCommand myOracleCommand = new OracleCommand(str, conn1); 
					//					ListItem lst; 
					//					conn1.Open(); 
					//					da.SelectCommand = myOracleCommand; 
					//					da.Fill(dsP, "Table"); 
					//					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++) 
					//					{ 
					//						lst = new ListItem(); 
					//						lst.Text = dsP.Tables[0].Rows[i]["BPO_NAME"].ToString(); 
					//						lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString(); 
					//						lstBPO.Items.Add(lst); 
					//					} 
					//					lstBPO.Items.Insert(0,"");
					//					conn1.Close(); 
					//									
					//					DataSet dsP1 = new DataSet(); 
					//					string str1 = "select VEND_CD, VEND_NAME from T05_VENDOR"; 
					//					OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1); 
					//					OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1); 
					//					ListItem lst1; 
					//					conn1.Open(); 
					//					da1.SelectCommand = myOracleCommand1; 
					//					da1.Fill(dsP1, "Table"); 
					//					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++) 
					//					{ 
					//						lst1 = new ListItem(); 
					//						lst1.Text = dsP1.Tables[0].Rows[i]["VEND_NAME"].ToString(); 
					//						lst1.Value = dsP1.Tables[0].Rows[i]["VEND_CD"].ToString(); 
					//						lstVend.Items.Add(lst1); 
					//					} 
					//					lstVend.Items.Insert(0,"");
					//					conn1.Close(); 
					//
					//					DataSet dsP2 = new DataSet(); 
					//					string str2 = "select CONSIGNEE_CD, CONSIGNEE_S_NAME from T06_CONSIGNEE"; 
					//					OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1); 
					//					OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1); 
					//					ListItem lst2; 
					//					conn1.Open(); 
					//					da2.SelectCommand = myOracleCommand2; 
					//					da2.Fill(dsP2, "Table"); 
					//					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++) 
					//					{ 
					//						lst2 = new ListItem(); 
					//						lst2.Text = dsP2.Tables[0].Rows[i]["CONSIGNEE_S_NAME"].ToString(); 
					//						lst2.Value = dsP2.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString(); 
					//						lstConsignee.Items.Add(lst2); 
					//					} 
					//					lstConsignee.Items.Insert(0,"");
					//					conn1.Close(); 

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
					//lst2.Text = "Tax/VAT Charged separately"; 
					lst2.Text = "Service Tax Charged separately";
					lst2.Value = "X";
					lstBPOTaxType.Items.Add(lst2);
					lst2 = new ListItem();
					lst2.Text = "No Service Tax(RITES Billing)";
					lst2.Value = "N";
					lstBPOTaxType.Items.Add(lst2);
					lst2 = new ListItem();
					lst2.Text = "Fee Inclusive of Service Tax (Don't Print S.Tax in Bill)";
					lst2.Value = "D";
					lstBPOTaxType.Items.Add(lst2);
					lstBPOTaxType.Items.Insert(0, "");


					ListItem lst3 = new ListItem();
					lst3.Text = "IGST @ 18%";
					lst3.Value = "I";
					lstBPOTaxType_GST.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "CGST @ 9% & SGST @ 9%";
					lst3.Value = "C";
					lstBPOTaxType_GST.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "NO GST";
					lst3.Value = "X";
					lstBPOTaxType_GST.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "Fee Inclusive of IGST @ 18%";
					lst3.Value = "Y";
					lstBPOTaxType_GST.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "Fee Inclusive of CGST @ 9% & SGST @ 9%";
					lst3.Value = "Z";
					lstBPOTaxType_GST.Items.Add(lst3);
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str1);
				}
				finally
				{
					conn1.Close();
				}

				if (Action == "M")
				{
					show();
					//Label2.Visible=true;
					//txtBillNo.Visible=false;
					//Label2.Text=BNO;
					btnDelete.Visible = false;
					btnBItems.Visible = false;
					btnCancel.Visible = true;

					fillgrid();
					fillgrid1();
				}
				else if (Action == "D")
				{
					show();
					//Label2.Visible=true;
					txtBillNo.Visible = false;
					//Label2.Text=BNO;
					btnSave.Visible = false;
				}
				else
				{
					btnDelete.Visible = false;
					//Label2.Visible=false;
					txtBillNo.Visible = true;
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{

			try
			{
				//					if (txtCInstallNo.Text=="")
				//					{
				//						txtCInstallNo.Text= "null";
				//					}
				//					if (txtBillAmt.Text=="")
				//					{
				//						txtBillAmt.Text= "null";
				//					}
				//					if (txtInsFee.Text=="")
				//					{
				//						txtInsFee.Text= "null";
				//					}
				//					if (txtServTax.Text=="")
				//					{
				//						txtServTax.Text= "null";
				//					}
				//					if (txtEduCess.Text=="")
				//					{
				//						txtEduCess.Text= "null";
				//					}
				//					if(txtTotalFee.Text=="")
				//					{
				//						txtTotalFee.Text= "null";
				//					}


				if (BNO == "")
				{
					//						conn1.Open();
					//						string myInsertQuery = "INSERT INTO T22_BILL values('" + txtBillNo.Text + "', to_date('" + txtBillDt.Text + "','dd/mm/yyyy'),'" + txtCaseNo.Text + "', to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy'),'"+ lstBPO.SelectedValue +"','"+ lstVend.SelectedValue +"', " + lstConsignee.SelectedValue + ",'" + txtCertNo.Text + "',to_date('" + txtCertDt.Text + "','dd/mm/yyyy')," + txtCInstallNo.Text + ",'" + txtBKNo.Text + "','" + txtSetNo.Text + "'," + txtBillAmt.Text + "," + txtInsFee.Text + "," + txtServTax.Text + "," + txtEduCess.Text + "," + txtTotalFee.Text + ")"; 
					//						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery); 
					//						myInsertCommand.Connection = conn1; 
					//						myInsertCommand.ExecuteNonQuery(); 
					//						conn1.Close(); 
					//						string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Saved and Your Call Serial No is" + CD + "' , 'CustomPopUp', " + "'width=330, height=120, menubar=no, resizable=no')" + "</script>";
					//						Page.RegisterStartupScript("PopupScript", popupScript);

				}
				else
				{
					//						string myUpdateQuery = "Update T22_BILL set BILL_DT=to_date('" + txtBillDt.Text + "','dd/mm/yyyy'),CASE_NO= '" + txtCaseNo.Text + "', CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy'), BPO_CD=" + lstBPO.SelectedValue + ", VEND_CD= " + lstVend.SelectedValue + ",CONSIGNEE_CD=" + lstConsignee.SelectedValue + ",IC_NO='" + txtCertNo.Text + "',IC_DT=to_date('" + txtCertDt.Text + "','dd/mm/yyyy'),CALL_INSTALL_NO="+txtCInstallNo.Text+",BK_NO='" + txtBKNo.Text + "',SET_NO='" + txtSetNo.Text + "',BILL_AMOUNT=" + txtBillAmt.Text + ",INSP_FEE=" + txtInsFee.Text + ",SERVICE_TAX=" + txtServTax.Text + ", EDU_CESS="+txtEduCess.Text+",TOTAL_FEE="+txtTotalFee.Text+" where BILL_NO= '" + BNO + "'"; 
					//						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery); 
					//						myUpdateCommand.Connection = conn1; 
					//						conn1.Open(); 
					//						myUpdateCommand.ExecuteNonQuery(); 
					//						
					//						conn1.Close(); 

				}
				btnBItems.Visible = true;
				DisplayAlert("Your Has Been Saved!!!");


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
			//Response.Redirect("Call_Register_Edit.aspx");

		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{

			conn1.Open();
		OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{
				//				
				//				string myDeleteQuery3 = "Delete T25_RECEIPT_DETAILS  where BILL_NO= '" + BNO + "'"; 
				//				OracleCommand myOracleCommand3 = new OracleCommand(myDeleteQuery3); 
				//				myOracleCommand3.Transaction=myTrans;
				//				myOracleCommand3.Connection = conn1; 
				//				myOracleCommand3.ExecuteNonQuery(); 
				//								
				//				//string myDeleteQuery = "Delete T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and BK_NO='"+BK+"'"; 
				//				string myDeleteQuery2 = "Delete T24_RECEIPTS where BILL_NO= '" + BNO + "'"; 
				//				OracleCommand myOracleCommand2 = new OracleCommand(myDeleteQuery2); 
				//				myOracleCommand2.Transaction=myTrans;
				//				myOracleCommand2.Connection = conn1; 
				//				myOracleCommand2.ExecuteNonQuery(); 
				//					
				//				string myDeleteQuery1 = "Delete T23_BILL_ITEMS  where BILL_NO= '" + BNO + "'"; 
				//				OracleCommand myOracleCommand1 = new OracleCommand(myDeleteQuery1); 
				//				myOracleCommand1.Transaction=myTrans;
				//				myOracleCommand1.Connection = conn1; 
				//				myOracleCommand1.ExecuteNonQuery(); 
				//				
				//
				//				string myDeleteQuery = "Delete T22_BILL  where BILL_NO= '" + BNO + "'"; 
				//				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery); 
				//				myOracleCommand.Transaction=myTrans;
				//				myOracleCommand.Connection = conn1; 
				//				myOracleCommand.ExecuteNonQuery(); 
				//				myTrans.Commit();
				//				conn1.Close(); 
				//				//string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Deleted!!!', 'CustomPopUp', " + "'width=330, height=100, menubar=no, resizable=no')" + "</script>";
				//				//Page.RegisterStartupScript("PopupScript", popupScript);
				//				DisplayAlert("Your Record Has Been Deleted!!!");

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
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Inspection_Fee_Bill_Edit.aspx");
		}

		protected void btnBItems_Click(object sender, System.EventArgs e)
		{
			//string code=txtBillNo.Text;

			//Response.Redirect("Items_In_Bill.aspx?BILL_No=" + code);
			fillgrid();
		}

		protected void txtTFee_TextChanged(object sender, System.EventArgs e)
		{

		}














	}
}