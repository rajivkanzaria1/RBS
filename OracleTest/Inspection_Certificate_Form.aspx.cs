using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Inspection_Certificate_Form
{
	public partial class Inspection_Certificate_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		public string CNO, DT, Action, BKNO, SNO, ss, BDT;
		//string iesname="";
		int CSNO, ecode = 0;

		void fill_ic_details()
		{
			try
			{

				DataSet dsP_IC = new DataSet();
				string str_IC = "select CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,CALL_SNO,CONSIGNEE_CD,BK_NO,SET_NO,TO_CHAR(LAB_TST_RECT_DT,'DD/MM/YYYY') LAB_REP_DET, NUM_VISITS, TO_CHAR(DATETIME,'DD/MM/YYYY') IC_DT from IC_INTERMEDIATE where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + CSNO + " AND CONSIGNEE_CD=" + lstConsignee.SelectedValue;
				OracleDataAdapter da_IC = new OracleDataAdapter(str_IC, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str_IC, conn1);
				conn1.Open();
				da_IC.SelectCommand = myOracleCommand1;
				conn1.Close();
				da_IC.Fill(dsP_IC, "Table");
				if (dsP_IC.Tables[0].Rows.Count != 0)
				{
					txtBKNO.Text = dsP_IC.Tables[0].Rows[0]["BK_NO"].ToString();
					txtSetNo.Text = dsP_IC.Tables[0].Rows[0]["SET_NO"].ToString();
					txtCertDt.Text = dsP_IC.Tables[0].Rows[0]["IC_DT"].ToString();
					txtNofIns.Text = dsP_IC.Tables[0].Rows[0]["NUM_VISITS"].ToString();
					string lab_dt = dsP_IC.Tables[0].Rows[0]["LAB_REP_DET"].ToString();
					string str2 = "select TO_CHAR(MIN(VISIT_DT),'DD/MM/YYYY') FIRST_INSP_DT, TO_CHAR(MAX(VISIT_DT),'DD/MM/YYYY') LAST_INSP_DT from T47_IE_WORK_PLAN where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text;
					OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
					conn1.Open();
					OracleDataReader reader = myOracleCommand2.ExecuteReader();
					while (reader.Read())
					{
						if (reader["FIRST_INSP_DT"].ToString() != "")
						{
							txtFIDT.Text = reader["FIRST_INSP_DT"].ToString();
							txtLIDT.Text = reader["LAST_INSP_DT"].ToString();
							if (lab_dt != "" && txtLIDT.Text != "")
							{
								string myYear, myMonth, myDay;
								myYear = lab_dt.Substring(6, 4);
								myMonth = lab_dt.Substring(3, 2);
								myDay = lab_dt.Substring(0, 2);
								string dt = myYear + myMonth + myDay;

								string myYear1, myMonth1, myDay1;
								myYear1 = txtLIDT.Text.Substring(6, 4);
								myMonth1 = txtLIDT.Text.Substring(3, 2);
								myDay1 = txtLIDT.Text.Substring(0, 2);
								string dt1 = myYear1 + myMonth1 + myDay1;
								int i = dt.CompareTo(dt1);
								if (i > 0)
								{
									txtLIDT.Text = lab_dt;
								}
							}
						}
					}

					OracleCommand cmd_SUB = new OracleCommand("Select NVL2(to_char(IC_SUBMIT_DT,'DD/MM/YYYY'),to_char(IC_SUBMIT_DT,'DD/MM/YYYY'),to_char(sysdate,'DD/MM/YYYY')) SUBMIT_DT FROM T30_IC_RECEIVED WHERE TRIM(BK_NO)=upper('" + txtBKNO.Text + "') and TRIM(SET_NO)=upper('" + txtSetNo.Text + "') and REGION='" + Session["Region"].ToString() + "'", conn1);
					txtICSDT.Text = Convert.ToString(cmd_SUB.ExecuteScalar());

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
		void show()
		{
			try
			{
				if (Session["Role_CD"].ToString() == "1")
				{
					txtCertNo.Visible = true;
					lblCertNo.Visible = false;
				}
				else
				{
					txtCertNo.Visible = false;
					lblCertNo.Visible = true;
				}
				DataSet dsP1 = new DataSet();
				string str1 = "select C.CASE_NO,to_char(C.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,C.CALL_SNO,C.IC_TYPE_ID,C.CONSIGNEE_CD,C.BPO_CD,C.BK_NO,C.SET_NO,I.IE_NAME IE_NAME,C.IE_CD,C.IC_NO,to_char(C.IC_DT,'dd/mm/yyyy') IC_DT,to_char(C.CALL_DT,'dd/mm/yyyy') CALL_DT,C.CALL_INSTALL_NO,C.FULL_PART,C.NO_OF_INSP,to_char(C.FIRST_INSP_DT,'dd/mm/yyyy')FIRST_INSP_DT,to_char(C.LAST_INSP_DT,'dd/mm/yyyy')LAST_INSP_DT,C.OTHER_INSP_DT,C.STAMP_PATTERN,C.REASON_REJECT,C.BILL_NO,TO_CHAR(C.IC_SUBMIT_DT,'dd/mm/yyyy')IC_SUBMIT_DT,C.PHOTO, C.STAMP_PATTERN_CD, C.RECIPIENT_GSTIN_NO, NVL(C.ACC_GROUP,'XXXX')ACCOUNT_GROUP, C.IRFC_FUNDED,C.IRFC_BPO_CD from T20_IC C,T09_IE I where C.IE_CD = I.IE_CD and C.BK_NO= '" + BKNO + "' and C.SET_NO='" + SNO + "' and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'";
				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				conn1.Close();
				da1.Fill(dsP1, "Table");
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("Record not found for the given Book No. and Set No. !!! ");
				}
				else
				{
					txtCaseNo.Text = dsP1.Tables[0].Rows[0]["CASE_NO"].ToString();
					CNO = txtCaseNo.Text;
					txtDtOfReciept.Text = dsP1.Tables[0].Rows[0]["CALL_RECV_DT"].ToString();
					lblCSNO.Text = dsP1.Tables[0].Rows[0]["CALL_SNO"].ToString();
					lstICType.SelectedValue = dsP1.Tables[0].Rows[0]["IC_TYPE_ID"].ToString();
					txtBKNO.Text = dsP1.Tables[0].Rows[0]["BK_NO"].ToString();
					fill_ConsigneeCd();
					lstConsignee.SelectedValue = dsP1.Tables[0].Rows[0]["CONSIGNEE_CD"].ToString();

					// getconsignee_gstno();
					//lblCon.Visible=true;
					lblConsignee.Text = lstConsignee.SelectedItem.Text;
					lstConsignee.Enabled = false;
					lstConsignee.Visible = false;
					txtSetNo.Text = dsP1.Tables[0].Rows[0]["SET_NO"].ToString();
					txtGSTINNo.Text = dsP1.Tables[0].Rows[0]["RECIPIENT_GSTIN_NO"].ToString();
					//lstIE.SelectedValue =dsP1.Tables[0].Rows[0]["IE_CD"].ToString (); 
					lblIE.Text = dsP1.Tables[0].Rows[0]["IE_NAME"].ToString();
					lblIECD.Text = dsP1.Tables[0].Rows[0]["IE_CD"].ToString();
					txtCertNo.Text = dsP1.Tables[0].Rows[0]["IC_NO"].ToString();
					lblCertNo.Text = dsP1.Tables[0].Rows[0]["IC_NO"].ToString();
					txtCertDt.Text = dsP1.Tables[0].Rows[0]["IC_DT"].ToString();
					txtCDate.Text = dsP1.Tables[0].Rows[0]["CALL_DT"].ToString();
					txtCInstallNo.Text = dsP1.Tables[0].Rows[0]["CALL_INSTALL_NO"].ToString();
					lstFPart.SelectedValue = dsP1.Tables[0].Rows[0]["FULL_PART"].ToString();
					txtPattern.Text = dsP1.Tables[0].Rows[0]["STAMP_PATTERN"].ToString();
					txtReason.Text = dsP1.Tables[0].Rows[0]["REASON_REJECT"].ToString();
					txtNofIns.Text = dsP1.Tables[0].Rows[0]["NO_OF_INSP"].ToString();
					txtFIDT.Text = dsP1.Tables[0].Rows[0]["FIRST_INSP_DT"].ToString();
					txtLIDT.Text = dsP1.Tables[0].Rows[0]["LAST_INSP_DT"].ToString();
					txtOIDT.Text = dsP1.Tables[0].Rows[0]["OTHER_INSP_DT"].ToString();
					txtICSDT.Text = dsP1.Tables[0].Rows[0]["IC_SUBMIT_DT"].ToString();
					lstPhoto.SelectedValue = dsP1.Tables[0].Rows[0]["PHOTO"].ToString();
					lstStampPatternCD.SelectedValue = dsP1.Tables[0].Rows[0]["STAMP_PATTERN_CD"].ToString();


					if (lstStampPatternCD.SelectedValue == "O")
					{
						txtPattern.Visible = true;
					}
					else
					{
						txtPattern.Visible = false;
					}
					string myYear1 = "", myMonth1 = "", myDay1 = "";
					if (txtCertDt.Text.Trim() != "")
					{
						myYear1 = txtCertDt.Text.Substring(6, 4);
						myMonth1 = txtCertDt.Text.Substring(3, 2);
						myDay1 = txtCertDt.Text.Substring(0, 2);
					}
					string certdt = myYear1 + myMonth1 + myDay1;

					if (certdt != "")
					{
						if (Convert.ToInt32(certdt) >= 20170701)
						{
							lstBPOTaxType.Visible = false;
							lstBPOTaxType_GST.Visible = true;
							if (dsP1.Tables[0].Rows[0]["RECIPIENT_GSTIN_NO"].ToString() != "")
							{
								if (Session["Region"].ToString() == "N" && dsP1.Tables[0].Rows[0]["RECIPIENT_GSTIN_NO"].ToString().Substring(0, 2) == "07")
								{
									lstBPOTaxType_GST.SelectedValue = "C";
								}
								else if (Session["Region"].ToString() == "S" && dsP1.Tables[0].Rows[0]["RECIPIENT_GSTIN_NO"].ToString().Substring(0, 2) == "33")
								{
									lstBPOTaxType_GST.SelectedValue = "C";
								}
								else if (Session["Region"].ToString() == "E" && dsP1.Tables[0].Rows[0]["RECIPIENT_GSTIN_NO"].ToString().Substring(0, 2) == "19")
								{
									lstBPOTaxType_GST.SelectedValue = "C";
								}
								else if (Session["Region"].ToString() == "W" && dsP1.Tables[0].Rows[0]["RECIPIENT_GSTIN_NO"].ToString().Substring(0, 2) == "27")
								{
									lstBPOTaxType_GST.SelectedValue = "C";
								}
								else if (Session["Region"].ToString() == "C" && dsP1.Tables[0].Rows[0]["RECIPIENT_GSTIN_NO"].ToString().Substring(0, 2) == "22")
								{
									lstBPOTaxType_GST.SelectedValue = "C";
								}
								else if (Session["Region"].ToString() == "Q" && dsP1.Tables[0].Rows[0]["RECIPIENT_GSTIN_NO"].ToString().Substring(0, 2) == "06")
								{
									lstBPOTaxType_GST.SelectedValue = "C";
								}
								else
								{
									lstBPOTaxType_GST.SelectedValue = "I";
								}
							}
						}
						else
						{
							lstBPOTaxType.Visible = true;
							lstBPOTaxType_GST.Visible = false;

						}
					}
					if (dsP1.Tables[0].Rows[0]["IRFC_FUNDED"].ToString() == "Y")
					{
						ddlIRFC.SelectedValue = "Y";
						lblIRFCBPO.Visible = true;
						ddlIRFCBPO.Visible = true;
						rdbConsignee.Enabled = false;
						rdbBPO.Enabled = false;
						btnGSTNoUpdate.Enabled = false;
						fill_IRFC_BPO();
						ddlIRFCBPO.SelectedValue = dsP1.Tables[0].Rows[0]["IRFC_BPO_CD"].ToString();


					}
					else
					{
						ddlIRFC.SelectedValue = "N";
						lblIRFCBPO.Visible = false;
						ddlIRFCBPO.Visible = false;
						rdbConsignee.Enabled = true;
						rdbBPO.Enabled = true;
						btnGSTNoUpdate.Enabled = true;
					}

					if (dsP1.Tables[0].Rows[0]["ACCOUNT_GROUP"].ToString() == "Z006")
					{
						rdbBPO.Checked = true;
						get_legalname(dsP1.Tables[0].Rows[0]["BPO_CD"].ToString(), "B");
						getconsignee_gstno();
					}
					else if (dsP1.Tables[0].Rows[0]["ACCOUNT_GROUP"].ToString() == "Z007")
					{
						rdbConsignee.Checked = true;
						get_legalname(dsP1.Tables[0].Rows[0]["CONSIGNEE_CD"].ToString(), "C");
						getconsignee_gstno();
					}
					else
					{
						get_legalname(dsP1.Tables[0].Rows[0]["IRFC_BPO_CD"].ToString(), "B");
						get_irfc_bpo_gst_detail();
					}




					if (dsP1.Tables[0].Rows[0]["BILL_NO"].ToString() != "")
					{
						//						btnSave.Visible=false;
						//						btnDelete.Visible=false;
						//						btnGBill.Visible=false;
						//						grdCDetails.Columns[0].Visible=false;
						lblBillNo.Text = dsP1.Tables[0].Rows[0]["BILL_NO"].ToString();

						string str2 = "select P.BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME,B.BPO_RLY,B.AU from T20_IC P, T12_BILL_PAYING_OFFICER B,T03_CITY C where (P.BPO_CD=B.BPO_CD) and B.BPO_CITY_CD=C.CITY_CD  and P.CASE_NO= '" + txtCaseNo.Text + "' and P.CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + " and P.CONSIGNEE_CD=" + lstConsignee.SelectedValue;
						OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
						conn1.Open();
						OracleDataReader reader = myOracleCommand2.ExecuteReader();
						while (reader.Read())
						{
							lblBPO.Text = reader["BPO_NAME"].ToString();
							lblBPOCD.Text = reader["BPO_CD"].ToString();
							lblBPORail.Text = reader["BPO_RLY"].ToString();
							lblAU.Text = reader["AU"].ToString();
						}
						conn1.Close();
						fill_BPO(lblBPOCD.Text);


						string str3 = "select to_char(B.BILL_DT,'dd/mm/yyyy')BILL_DT,NVL(B.FEE_RATE,0)FEE_RATE,B.FEE_TYPE,NVL(B.TAX_TYPE,'X')TAX_TYPE,NVL(B.MATERIAL_VALUE,0)MATERIAL_VALUE,B.INSP_FEE,B.MIN_FEE,B.MAX_FEE,B.BILL_AMOUNT,B.REMARKS,NVL(B.ADV_BILL,'X') ADV_BILL, INVOICE_NO,CNOTE_BILL_NO,SENT_TO_SAP,BILL_FINALISED from T22_BILL B where BILL_NO='" + lblBillNo.Text + "'";
						OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
						conn1.Open();
						OracleDataReader reader1 = myOracleCommand3.ExecuteReader();
						while (reader1.Read())
						{
							txtBPOFee.Text = Convert.ToDouble(reader1["FEE_RATE"]).ToString();
							lstBPOFeeType.SelectedValue = reader1["FEE_TYPE"].ToString();
							lstRlyBPOFee.Visible = false;

							if (Convert.ToInt32(certdt) >= 20170701)
							{
								lstBPOTaxType_GST.SelectedValue = reader1["TAX_TYPE"].ToString();
							}
							else
							{
								lstBPOTaxType.SelectedValue = reader1["TAX_TYPE"].ToString();
							}


							lblTMValue.Text = reader1["MATERIAL_VALUE"].ToString();
							lblTIFee.Text = reader1["INSP_FEE"].ToString();
							lblNetFee.Text = reader1["BILL_AMOUNT"].ToString();
							txtMaxFeeAllow.Text = reader1["MAX_FEE"].ToString();
							txtMinFeeAllow.Text = reader1["MIN_FEE"].ToString();
							txtBDT.Text = reader1["BILL_DT"].ToString();
							lblBDT.Text = reader1["BILL_DT"].ToString();
							txtBRemarks.Text = reader1["REMARKS"].ToString();
							lblInvoiceNo.Text = reader1["INVOICE_NO"].ToString();
							if (reader1["ADV_BILL"].ToString() == "A")
							{
								lblAdv_Bill.Visible = true;
								chkABill.Checked = true;
							}
							else
							{
								lblAdv_Bill.Visible = false;
							}

							if (lstICType.SelectedValue == "9")
							{
								txtBillNo.Text = reader1["CNOTE_BILL_NO"].ToString();
								txtBillNo.Visible = true;
								txtBillNo.Enabled = false;
								btnVerify.Visible = false;
								lstICType.Enabled = false;
							}
							//txtBDT.Enabled=false;
							if (reader1["SENT_TO_SAP"].ToString() == "X" || reader1["BILL_FINALISED"].ToString() == "Y")
							{
								lblSTS.Text = "X";
							}

						}
						conn1.Close();
						if (lblSTS.Text == "X")
						{
							btnGBill.Visible = false;
							btnSave.Visible = false;
							btnDelete.Enabled = false;
						}
						else
						{
							btnGBill.Text = "Update Bill";
						}
						//btnGBill.Visible=true;
						Label24.Visible = true;
						lblBillNo.Visible = true;
						Label32.Visible = true;
						Label34.Visible = true;
						Label41.Visible = true;
						Label43.Visible = true;

						lblTMValue.Visible = true;
						lblTIFee.Visible = true;
						lblNetFee.Visible = true;
						if (lblInvoiceNo.Text.Trim() != "")
						{
							lblInvoiceNo.Visible = true;
							Label43.Visible = true;
						}
						else
						{
							lblInvoiceNo.Visible = false;
							Label43.Visible = false;
						}
						if (Session["Role_CD"].ToString() == "4")
						{
							btnUBDT.Visible = false;
						}
						else
						{
							btnUBDT.Visible = true;
						}
						Label48.Visible = true;
						File1.Visible = true;
						btnUpload.Visible = true;

						DisplayAlert("The bill has been generated for this IC Vide Bill No:" + dsP1.Tables[0].Rows[0]["BILL_NO"].ToString());

					}
					else
					{
						showBPO();
						Label24.Visible = false;
						lblBillNo.Visible = false;
						Label32.Visible = false;
						Label34.Visible = false;
						Label41.Visible = false;
						Label43.Visible = true;
						lblTMValue.Visible = false;
						lblTIFee.Visible = false;
						lblNetFee.Visible = false;
						showmaxamt();
						//txtBDT.Text=ss;
						btnUBDT.Visible = false;
						//btnGBill.Visible=true;
						//						grdCDetails.Columns[0].Visible=true;
						//						grdCDetails.Columns[0].Visible=true;

						Label48.Visible = false;
						File1.Visible = false;
						btnUpload.Visible = false;

					}
					string str4 = "select upper(C.BPO) BPO, C.RECIPIENT_GSTIN_NO from T17_CALL_REGISTER C where CASE_NO= '" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text.Trim();
					OracleCommand myOracleCommand4 = new OracleCommand(str4, conn1);
					conn1.Open();
					OracleDataReader reader4 = myOracleCommand4.ExecuteReader();
					while (reader4.Read())
					{
						//txtCDate.Text=DT;
						lblBPOCall.Text = Convert.ToString(reader4["BPO"]);
						lblGSTINCall.Text = Convert.ToString(reader4["RECIPIENT_GSTIN_NO"]);
						//						if(reader4["IRFC_FUNDED"].ToString()=="Y")
						//						{
						//							ddlIRFC.SelectedValue="Y";
						//							lblIRFCBPO.Visible=true;
						//							ddlIRFCBPO.Visible=true;
						//							rdbConsignee.Enabled=false;
						//							rdbBPO.Enabled=false;
						//							btnGSTNoUpdate.Enabled=false;
						//								
						//						}
						//						else
						//						{
						//							ddlIRFC.SelectedValue="N";
						//							lblIRFCBPO.Visible=false;
						//							ddlIRFCBPO.Visible=false;
						//							rdbConsignee.Enabled=true;
						//							rdbBPO.Enabled=true;
						//							btnGSTNoUpdate.Enabled=true;
						//						}
					}
					conn1.Close();
					show3();
					fillgrid1();



					//grdCDetails.Columns[0].Visible=false;

				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				int ind = str.IndexOf("\r");
				if (ind > 0)
				{
					string str11 = str.Substring(0, str.IndexOf("\r"));
					if (str11 == "Specified argument was out of the range of valid values.")
					{
						str11 = "Your Consignee in IC does not Match with the Consignee In Calls, soo plz use Update Consignee option to Modify the Consignee in IC.";
						Response.Redirect(("Error_Form.aspx?err=" + str11));
					}
					else
					{
						Response.Redirect(("Error_Form.aspx?err=" + str11));
					}
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

		void show1()
		{



			try
			{
				string str1 = "select I.IE_NAME,I.IE_SNAME,C.IE_CD,to_char(DT_INSP_DESIRE,'dd/mm/yyyy')DT_INSP_DESIRE, C.REJ_CAN_CALL, upper(C.BPO) BPO, C.RECIPIENT_GSTIN_NO,C.IRFC_FUNDED from T17_CALL_REGISTER C,T09_IE I where C.IE_CD=I.IE_CD and CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + CSNO;
				OracleCommand myCommand1 = new OracleCommand();
				myCommand1.CommandText = str1;
				myCommand1.Connection = conn1;
				conn1.Open();
				//string CD1 = Convert.ToString(myCommand1.ExecuteScalar());
				OracleDataReader reader = myCommand1.ExecuteReader();

				if (reader.HasRows == true)
				{
					//					string str4 = "select CASE_NO from T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy')"; 
					//					OracleCommand myCommand = new OracleCommand();
					//					myCommand.CommandText = str4;
					//					myCommand.Connection = conn1;
					//					string CD = Convert.ToString(myCommand.ExecuteScalar());
					//					//conn1.Close();
					//					
					//					if(CD=="")
					//					{	

					while (reader.Read())
					{
						//txtCDate.Text=DT;
						lblBPOCall.Text = Convert.ToString(reader["BPO"]);
						lblGSTINCall.Text = Convert.ToString(reader["RECIPIENT_GSTIN_NO"]);
						if (reader["IRFC_FUNDED"].ToString() == "Y")
						{
							ddlIRFC.SelectedValue = "Y";
							lblIRFCBPO.Visible = true;
							ddlIRFCBPO.Visible = true;
							rdbConsignee.Enabled = false;
							rdbBPO.Enabled = false;
							btnGSTNoUpdate.Enabled = false;
							fill_IRFC_BPO();

						}
						else
						{
							ddlIRFC.SelectedValue = "N";
							lblIRFCBPO.Visible = false;
							ddlIRFCBPO.Visible = false;
							rdbConsignee.Enabled = true;
							rdbBPO.Enabled = true;
							btnGSTNoUpdate.Enabled = true;
						}
						txtCDate.Text = Convert.ToString(reader["DT_INSP_DESIRE"]);
						lblIE.Text = Convert.ToString(reader["IE_NAME"]);
						lblIECD.Text = Convert.ToString(reader["IE_CD"]);
						lblIESName.Text = Convert.ToString(reader["IE_SNAME"]);
						if (Convert.ToString(reader["REJ_CAN_CALL"]) == "Y")
						{
							ddlCanOrRejctionFee.SelectedValue = "Y";
						}
					}
					conn1.Close();
					showBPO();
					txtCertNo.Text = Session["Region"] + "/" + lblBPORail.Text + "/" + CNO + "/" + lblIESName.Text;
					show3();

					//					}
					//					else
					//					{
					//						throw new System.Exception("Record Already exist for the given Case No. and Call Recieve Date. ");
					//						
					//					}

				}
				else
				{
					throw new System.Exception("Record not found for the given Case No.,Call Recieve Date and Call Sno. in Call Master Table !!!");
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
		void showmaxamt()
		{
			string str = "select MIN_FEE,MAX_FEE from T14A_PO_NONRLY where CASE_NO='" + CNO + "'";
			OracleCommand myOracleCommand = new OracleCommand(str, conn1);
			conn1.Open();
			OracleDataReader reader = myOracleCommand.ExecuteReader();
			while (reader.Read())
			{
				txtMaxFeeAllow.Text = reader["MAX_FEE"].ToString();
				txtMinFeeAllow.Text = reader["MIN_FEE"].ToString();
			}
			conn1.Close();
		}

		void showBPO()
		{
			string str3 = "select P.BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME,B.BPO_RLY,B.BPO_FEE,B.BPO_FEE_TYPE,NVL(B.BPO_TAX_TYPE,'X')BPO_TAX_TYPE,B.AU, B.BPO_TYPE from T14_PO_BPO P, T12_BILL_PAYING_OFFICER B, T03_CITY C where (P.BPO_CD=B.BPO_CD) and B.BPO_CITY_CD=C.CITY_CD and CASE_NO= '" + txtCaseNo.Text + "' and CONSIGNEE_CD=" + lstConsignee.SelectedValue;
			OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
			conn1.Open();
			OracleDataReader reader1 = myOracleCommand3.ExecuteReader();
			while (reader1.Read())
			{
				lblBPO.Text = reader1["BPO_NAME"].ToString();
				lblBPOCD.Text = reader1["BPO_CD"].ToString();
				lblBPORail.Text = reader1["BPO_RLY"].ToString();
				lblBPO_TYPE.Text = reader1["BPO_TYPE"].ToString();
				if (reader1["BPO_TYPE"].ToString() == "R" && reader1["BPO_FEE_TYPE"].ToString() == "P" && lstICType.SelectedValue == "1")
				{
					lstRlyBPOFee.Visible = true;
					txtBPOFee.Visible = false;
				}
				else
				{
					lstRlyBPOFee.Visible = false;
					txtBPOFee.Visible = true;
					txtBPOFee.Text = reader1["BPO_FEE"].ToString();
				}

				lstBPOFeeType.SelectedValue = reader1["BPO_FEE_TYPE"].ToString();
				lstBPOTaxType.SelectedValue = reader1["BPO_TAX_TYPE"].ToString();
				lblAU.Text = reader1["AU"].ToString();
			}
			conn1.Close();
			fill_BPO(lblBPOCD.Text);
		}
		void show3()
		{
			string str3 = "select P.PO_NO,to_char(P.PO_DT,'dd/mm/yyyy') PO_DT, (trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME, DECODE(PO_SOURCE,'C','CRIS','V','VENDOR','MANUAL') PO_SOURCE, P.RLY_NONRLY, DECODE(P.STOCK_NONSTOCK,'S','Stock','N','Non-Stock') STOCK_NONSTOCK from T05_VENDOR V, T03_CITY C,T13_PO_MASTER P where (P.VEND_CD=V.VEND_CD and V.VEND_CITY_CD=C.CITY_CD) and CASE_NO= '" + CNO + "'";
			OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
			conn1.Open();
			OracleDataReader reader = myOracleCommand3.ExecuteReader();
			while (reader.Read())
			{
				lblPONO.Text = reader["PO_NO"].ToString();
				lblPODT.Text = reader["PO_DT"].ToString();
				lblVend.Text = reader["VEND_NAME"].ToString();
				lblStockNonStock.Text = reader["STOCK_NONSTOCK"].ToString();
				lblSource.Text = "PO Source: (" + reader["PO_SOURCE"].ToString() + ")";

			}
			reader.Close();
			conn1.Close();

		}
		public void fill_ConsigneeCd()
		{
			try
			{
				lstConsignee.Items.Clear();
				DataSet dsP = new DataSet();
				string str1;
				//str1 = "select P.CONSIGNEE_CD,(trim(C.CONSIGNEE_DESIG)||'/'||trim(C.CONSIGNEE_DEPT)||'/'||trim(C.CONSIGNEE_FIRM)) CONSIGNEE_NAME from T06_CONSIGNEE C,T18_CALL_DETAILS P WHERE P.CONSIGNEE_CD=C.CONSIGNEE_CD and CASE_NO='"+ txtCaseNo.Text +"' and CALL_RECV_DT=TO_DATE('"+txtDtOfReciept.Text+"','dd/mm/yyyy')ORDER BY CONSIGNEE_DESIG"; 
				str1 = "Select C.CONSIGNEE_CD,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME from t06_consignee C,T03_CITY D where C.CONSIGNEE_CITY=D.CITY_CD AND CONSIGNEE_CD in (select distinct CONSIGNEE_CD from T18_CALL_DETAILS WHERE CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=TO_DATE('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text.Trim() + ")";
				//str1="Select C.CONSIGNEE_CD,trim(C.CONSIGNEE_DESIG)||'/'||trim(C.CONSIGNEE_DEPT)||'/'||trim(C.CONSIGNEE_FIRM||'/'||D.CITY) CONSIGNEE_NAME from t06_consignee C,T03_CITY D where C.CONSIGNEE_CITY=D.CITY_CD AND CONSIGNEE_CD in (select distinct CONSIGNEE_CD from T18_CALL_DETAILS WHERE CASE_NO='"+ txtCaseNo.Text +"')";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new Exception("Their is no details Present for this Case No and Call Recieve Date in CALL DETAILS TABLE !!!");
				}
				else
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
						lstConsignee.Items.Add(lst);
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
		}

		void getconsignee_gstno()
		{
			//string gst_no="";
			try
			{
				conn1.Open();
				OracleCommand cmd2 = null;
				if (rdbConsignee.Checked == true)
				{
					cmd2 = new OracleCommand("select NVL(GSTIN_NO,'X') GSTIN_NO,LEGAL_NAME,T06.PIN_CODE,T03.CITY,lpad(T92.STATE_CD,2,'0')||'-'||T92.STATE_NAME STATE from T06_CONSIGNEE T06,T03_CITY T03,T92_STATE T92 WHERE T06.CONSIGNEE_CITY=T03.CITY_CD AND T03.STATE_CD=T92.STATE_CD AND T06.CONSIGNEE_CD=" + lstConsignee.SelectedValue, conn1);
				}
				else if (rdbBPO.Checked == true)
				{
					cmd2 = new OracleCommand("select NVL(GSTIN_NO,'X') GSTIN_NO,LEGAL_NAME,T12.PIN_CODE,T03.CITY,lpad(T92.STATE_CD,2,'0')||'-'||T92.STATE_NAME STATE from T12_BILL_PAYING_OFFICER T12,T03_CITY T03,T92_STATE T92 WHERE T12.BPO_CITY_CD=T03.CITY_CD AND T03.STATE_CD=T92.STATE_CD AND BPO_CD='" + lblBPOCD.Text + "'", conn1);
				}
				OracleDataReader reader = cmd2.ExecuteReader();
				while (reader.Read())
				{


					if (reader["GSTIN_NO"].ToString() == "X")
					{
						txtGSTINNo.Enabled = true;
						btnGSTNoUpdate.Visible = true;
						txtGSTINNo.Text = "";

					}
					else
					{
						if (reader["LEGAL_NAME"].ToString() == "")
						{
							txtLegalName.Text = "";
							txtLegalName.Visible = true;


						}
						else
						{
							txtLegalName.Text = reader["LEGAL_NAME"].ToString();
							txtLegalName.Visible = true;
						}
						txtGSTINNo.Text = reader["GSTIN_NO"].ToString();
						lblCity.Text = "City: " + reader["CITY"].ToString();
						lblState.Text = "State: " + reader["STATE"].ToString();
						lblStateCD.Text = reader["STATE"].ToString();
						lblPin.Text = "PIN: " + reader["PIN_CODE"].ToString();
						txtGSTINNo.Enabled = false;
						btnGSTNoUpdate.Visible = true;
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
		}

		void get_legalname(string code, string type)
		{
			try
			{
				conn1.Open();
				OracleCommand cmd2 = null;
				if (type == "C")
				{
					cmd2 = new OracleCommand("select LEGAL_NAME,T06.PIN_CODE,T03.CITY,lpad(T92.STATE_CD,2,'0')||'-'||T92.STATE_NAME STATE from T06_CONSIGNEE T06,T03_CITY T03,T92_STATE T92 WHERE T06.CONSIGNEE_CITY=T03.CITY_CD AND T03.STATE_CD=T92.STATE_CD(+) AND T06.CONSIGNEE_CD='" + code + "'", conn1);
				}
				else if (type == "B")
				{
					cmd2 = new OracleCommand("select LEGAL_NAME,T12.PIN_CODE,T03.CITY,lpad(T92.STATE_CD,2,'0')||'-'||T92.STATE_NAME STATE from T12_BILL_PAYING_OFFICER T12,T03_CITY T03,T92_STATE T92 WHERE T12.BPO_CITY_CD=T03.CITY_CD AND T03.STATE_CD=T92.STATE_CD(+) AND T12.BPO_CD='" + code + "'", conn1);
				}
				OracleDataReader reader = cmd2.ExecuteReader();
				while (reader.Read())
				{
					txtLegalName.Text = Convert.ToString(cmd2.ExecuteScalar());
					lblCity.Text = "City: " + reader["CITY"].ToString();
					lblState.Text = "State: " + reader["STATE"].ToString();
					lblStateCD.Text = reader["STATE"].ToString();
					lblPin.Text = "PIN: " + reader["PIN_CODE"].ToString();
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
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//btnAdd.Attributes.Add("OnClick", "JavaScript:validate();"); 
			//btnMod.Attributes.Add("OnClick", "JavaScript:validate();"); 
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");
			btnGBill.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnGSTNoUpdate.Attributes.Add("OnClick", "JavaScript:validate2();");

			try
			{

				if (Convert.ToString(Request.Params["Action"]) == "A")
				{

					Action = Request.Params["Action"].ToString();
					CNO = Request.Params["CASE_NO"].ToString();
					DT = Request.Params["CALL_RECV_DT"].ToString();
					CSNO = Convert.ToInt32(Request.Params["CALL_SNO"].ToString());


				}
				else
				{
					Action = Request.Params["Action"].ToString();
					BKNO = Request.Params["BK_NO"].ToString();
					SNO = Request.Params["SET_NO"].ToString();
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
			if (!(IsPostBack))
			{

				btnMRDT.Text = String.Format("{0} \n {1}", "Call/Material", " Readiness Date");
				File1.Visible = false;
				DataSet dsP1 = new DataSet();
				string str2 = "select IC_TYPE_ID,IC_TYPE from T93_IC_TYPES order by IC_TYPE ";
				OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				conn1.Close();
				da2.Fill(dsP1, "Table");
				lstICType.DataValueField = "IC_TYPE_ID";
				lstICType.DataTextField = "IC_TYPE";
				lstICType.DataSource = dsP1;
				lstICType.DataBind();
				lstICType.SelectedValue = "1";

				ListItem lst4 = new ListItem();
				lst4.Text = "Final";
				lst4.Value = "F";
				lstFPart.Items.Add(lst4);
				lst4 = new ListItem();
				lst4.Text = "Part";
				lst4.Value = "P";
				lstFPart.Items.Add(lst4);

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
				lst2.Text = "Fee Inclusive of Service Tax";
				lst2.Value = "I";
				lstBPOTaxType.Items.Add(lst2);
				lst2 = new ListItem();
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
				lstBPOTaxType_GST.Items.Insert(0, "");

				ListItem lst5 = new ListItem();
				lst5.Text = "0.522% (For PO Value between 5 Lakhs to 1 Crore)";
				lst5.Value = ".522";
				lstRlyBPOFee.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "0.116% (For PO Value between 1 Crore to 25 Crores)";
				lst5.Value = ".116";
				lstRlyBPOFee.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "0.053% (For PO Value between 25 Crores to 100 Crores)";
				lst5.Value = ".053";
				lstRlyBPOFee.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "0.035% (For PO Value between more then 100 Crores)";
				lst5.Value = ".035";
				lstRlyBPOFee.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "0.9% (For PO Date on or before 26-Nov-2022)";
				lst5.Value = ".9";
				lstRlyBPOFee.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "0.55% (For CR Billing)";
				lst5.Value = ".55";
				lstRlyBPOFee.Items.Add(lst5);

				//				ListItem lst3 = new ListItem(); 
				//				lst3.Text = "Hologram"; 
				//				lst3.Value = "H"; 
				//				lstStampPatternCD.Items.Add(lst3); 
				//				lst3 = new ListItem(); 
				//				lst3.Text = "Polycarbonate Seal"; 
				//				lst3.Value = "P"; 
				//				lstStampPatternCD.Items.Add(lst3); 
				//				lst3 = new ListItem(); 
				//				lst3.Text = "Steel Punch"; 
				//				lst3.Value = "S"; 
				//				lstStampPatternCD.Items.Add(lst3); 
				//				lst3 = new ListItem(); 
				//				lst3.Text = "Lead Seal"; 
				//				lst3.Value = "L"; 
				//				lstStampPatternCD.Items.Add(lst3);
				//				lst3 = new ListItem(); 
				//				lst3.Text = "Rubber Stamp"; 
				//				lst3.Value = "R"; 
				//				lstStampPatternCD.Items.Add(lst3); 
				//				lst3 = new ListItem(); 
				//				lst3.Text = "Others"; 
				//				lst3.Value = "O"; 
				//				lstStampPatternCD.Items.Add(lst3); 
				DataSet dsP3 = new DataSet();
				string str3 = "select SEALING_PATTERN_CD,SEALING_PATTERN_DESC from T68_SEALING_PATTERN_CODES";
				OracleDataAdapter da3 = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				da3.SelectCommand = myOracleCommand3;
				conn1.Close();
				da3.Fill(dsP3, "Table");
				lstStampPatternCD.DataValueField = "SEALING_PATTERN_CD";
				lstStampPatternCD.DataTextField = "SEALING_PATTERN_DESC";
				lstStampPatternCD.DataSource = dsP3;
				lstStampPatternCD.DataBind();
				lstStampPatternCD.Items.Insert(0, "");
				lstStampPatternCD.SelectedValue = "";
				txtPattern.Visible = false;

				txtCaseNo.Text = CNO;
				txtDtOfReciept.Text = DT;
				lblCSNO.Text = CSNO.ToString();
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
				ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				txtSysDate.Text = ss;
				if (Action == "A")
				{
					fill_ConsigneeCd();
					//getconsignee_gstno();
					show1();
					if (Session["Role_CD"].ToString() == "1" || Session["Role_CD"].ToString() == "2")
					{
						btnDelete.Visible = false;
						btnSave.Visible = true;
					}
					else if (Session["Role_CD"].ToString() == "4")
					{
						btnDelete.Visible = false;
						btnSave.Visible = false;
						grdCDetails.Columns[0].Visible = false;

					}

					//					btnDelete.Visible =false;
					//					btnSave.Visible=true;
					txtCertDt.Text = ss;


					//lblCon.Visible=false;
					lstConsignee.Enabled = true;
					lstConsignee.Visible = true;
					Label24.Visible = false;
					lblBillNo.Visible = false;
					btnGBill.Visible = false;
					Label32.Visible = false;
					Label34.Visible = false;
					Label41.Visible = false;
					Label43.Visible = false;
					lblTMValue.Visible = false;
					lblTIFee.Visible = false;
					lblNetFee.Visible = false;
					showmaxamt();
					//txtBDT.Text=ss;
					btnUBDT.Visible = false;

					grdCDetails.Visible = false;
					btnShow.Visible = false;
					grdCDetails_1.Visible = false;
					btnSave2.Visible = false;
					btnCancel2.Visible = false;
					fill_ic_details();
					if (txtICSDT.Text == "")
					{
						txtICSDT.Text = ss;
					}

				}
				else
				{

					if (Action == "M")
					{
						//							btnSave.Visible=true;
						//							btnDelete.Visible =false;
						//							btnGBill.Visible=true;
						if (Session["Role_CD"].ToString() == "1" || Session["Role_CD"].ToString() == "2")
						{
							btnSave.Visible = true;
							btnDelete.Visible = false;
							btnGBill.Visible = true;
						}
						else if (Session["Role_CD"].ToString() == "4")
						{
							btnDelete.Visible = false;
							btnSave.Visible = false;
							grdCDetails.Columns[0].Visible = false;

						}
						show();
						if (Session["Role_CD"].ToString() == "1")
						{
							txtBKNO.Enabled = true;
							txtSetNo.Enabled = true;
						}
						else
						{
							txtBKNO.Enabled = false;
							txtSetNo.Enabled = false;
						}

					}
					else if (Action == "D")
					{
						//							btnDelete.Visible=true;
						//							btnSave.Visible =false;
						//							btnGBill.Visible=false;
						if (Session["Role_CD"].ToString() == "1" || Session["Role_CD"].ToString() == "2")
						{
							btnDelete.Visible = true;
							btnSave.Visible = false;
							btnGBill.Visible = false;
						}
						else if (Session["Role_CD"].ToString() == "4")
						{
							btnDelete.Visible = false;
							btnSave.Visible = false;
							grdCDetails.Columns[0].Visible = false;

						}
						show();


					}

					conn1.Close();


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


		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			string myBillQuery = "Select NVL(BILL_NO,'') from T20_IC WHERE CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO='" + lblCSNO.Text + "' and CONSIGNEE_CD=" + lstConsignee.SelectedValue;
			OracleCommand myBillCommand = new OracleCommand(myBillQuery);
			myBillCommand.Connection = conn1;
			conn1.Open();
			string bill_status = Convert.ToString(myBillCommand.ExecuteScalar());
			conn1.Close();

			if (bill_status != "")
			{
				DisplayAlert("You are not allowed to delete this IC as the Bill has been Generated for it!!!");
			}
			else
			{
				conn1.Open();
				OracleTransaction myTrans = conn1.BeginTransaction();
				try
				{
					string myDeleteQuery = "Delete T20_IC where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO='" + lblCSNO.Text + "' and CONSIGNEE_CD=" + lstConsignee.SelectedValue;
					OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
					myOracleCommand.Transaction = myTrans;
					myOracleCommand.Connection = conn1;
					myOracleCommand.ExecuteNonQuery();


					string myUpdateQuery = "Update T18_CALL_DETAILS set QTY_PASSED=null, QTY_REJECTED=null,QTY_DUE=null where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO='" + lblCSNO.Text + "' and CONSIGNEE_CD=" + lstConsignee.SelectedValue;
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn1;
					myUpdateCommand.Transaction = myTrans;
					myUpdateCommand.ExecuteNonQuery();


					string myUpdateQuery1 = "Update T17_CALL_REGISTER set CALL_STATUS='M' where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO='" + lblCSNO.Text + "'";
					OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
					myUpdateCommand1.Connection = conn1;
					myUpdateCommand1.Transaction = myTrans;
					myUpdateCommand1.ExecuteNonQuery();
					myTrans.Commit();
					conn1.Close();
					DisplayAlert("Your Record Has Been Deleted !!!");
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
					myTrans.Dispose();
				}
			}
		}

		int checkdatediff(string dt1, string dt2, int diff)
		{
			System.DateTime w_dt1 = new System.DateTime(Convert.ToInt32(dt1.Substring(6, 4)), Convert.ToInt32(dt1.Substring(3, 2)), Convert.ToInt32(dt1.Substring(0, 2)));
			System.DateTime w_dt2 = new System.DateTime(Convert.ToInt32(dt2.Substring(6, 4)), Convert.ToInt32(dt2.Substring(3, 2)), Convert.ToInt32(dt2.Substring(0, 2)));
			TimeSpan ts = w_dt1 - w_dt2;
			int differenceInDays = ts.Days;
			if (differenceInDays > diff)
			{
				return (1);
			}
			else
			{
				return (0);
			}

		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{

			if (Session["Region"].ToString() == "N")
			{
				int FinspCdtdiff = checkdatediff(txtFIDT.Text, txtCDate.Text, 7);
				int ICdtLinspdiff = checkdatediff(txtCertDt.Text, txtLIDT.Text, 3);
				string mess = "";
				if (FinspCdtdiff == 1)
				{
					mess = "First Inspection Date - Call Date is greater then 7 Days!!!";
				}
				if (ICdtLinspdiff == 1)
				{
					if (mess == "")
					{
						mess = "IC Date - Last Inspection Date is greater then 3 Days!!!";
					}
					else
					{
						mess = mess + " & IC Date - Last Inspection Date is greater then 3 Days!!!";
					}
				}

				if (mess != "")
				{
					DisplayAlert(mess);
				}
			}


			conn1.Open();
			OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO.Text + "') and " + Convert.ToInt32(txtSetNo.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + lblIECD.Text, conn1);
			string bscheck = Convert.ToString(cmd.ExecuteScalar());

			OracleCommand cmd11 = new OracleCommand("Select ISSUE_TO_IECD from T16_IC_CANCEL where TRIM(BK_NO)=upper('" + txtBKNO.Text + "') and TRIM(SET_NO)='" + txtSetNo.Text + "' and REGION='" + Session["Region"] + "'", conn1);
			string bscheck1 = Convert.ToString(cmd11.ExecuteScalar());
			conn1.Close();

			string bscheck2 = "";
			if (txtGSTINNo.Text.Substring(0, 2) != lblStateCD.Text.Substring(0, 2))
			{
				bscheck2 = "N";
			}
			int bscheck3 = 0;
			if ((rdbConsignee.Checked == false && rdbBPO.Checked == false && ddlIRFC.SelectedValue == "N") || (rdbConsignee.Checked == false && rdbBPO.Checked == false && ddlIRFC.SelectedValue == "Y" && ddlIRFCBPO.SelectedValue == ""))
			{
				bscheck3 = 1;
			}
			if (bscheck != "" && bscheck1 == "" && bscheck2 == "" && bscheck3 == 0)
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				if (txtCInstallNo.Text == "")
				{
					txtCInstallNo.Text = "null";
				}
				if (txtNofIns.Text == "")
				{
					txtNofIns.Text = "null";
				}
				string acc_group = "";
				if (rdbConsignee.Checked == true)
				{
					acc_group = "Z007";
				}
				else if (rdbBPO.Checked == true)
				{
					acc_group = "Z006";
				}



				conn1.Open();
				OracleCommand cmd1 = new OracleCommand("Select BK_NO from T20_IC where BK_NO=upper('" + txtBKNO.Text + "') and SET_NO= '" + txtSetNo.Text + "' and substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'", conn1);
				string check1 = Convert.ToString(cmd1.ExecuteScalar());
				conn1.Close();
				conn1.Open();
				OracleTransaction myTrans = conn1.BeginTransaction();
				try
				{
					string Cstatus = "";
					string upQuery = "";
					string w_irfc_funded = "";
					string w_irfc_bpo = "";
					if (Action == "A")
					{
						if (check1 == "")
						{
							//								OracleCommand cmdCO =new OracleCommand("Select IE_CO_CD from T09_IE where IE_CD="+lblIECD.Text,conn1);
							//								int CO=Convert.ToInt32(cmdCO.ExecuteScalar());
							if (ddlIRFC.SelectedValue == "Y")
							{
								w_irfc_funded = ddlIRFC.SelectedValue.ToString();
								w_irfc_bpo = ddlIRFCBPO.SelectedValue;
								acc_group = "";
							}
							else
							{
								w_irfc_funded = "N";
							}



							string str3 = "Select CO_CD from T17_CALL_REGISTER where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + " AND IE_CD=" + lblIECD.Text;
							OracleCommand myCommand = new OracleCommand();
							myCommand.CommandText = str3;
							myCommand.Transaction = myTrans;
							myCommand.Connection = conn1;
							int CO = Convert.ToInt32(myCommand.ExecuteScalar());

							string myInsertQuery = "INSERT INTO T20_IC(CASE_NO, CALL_RECV_DT,CALL_SNO,IC_TYPE_ID, CONSIGNEE_CD, BPO_CD, BK_NO, SET_NO, IE_CD,IC_NO, IC_DT, CALL_DT, CALL_INSTALL_NO, FULL_PART, STAMP_PATTERN, REASON_REJECT, NO_OF_INSP,FIRST_INSP_DT, LAST_INSP_DT, OTHER_INSP_DT, IC_SUBMIT_DT, BILL_NO, USER_ID, DATETIME,PHOTO,CO_CD,STAMP_PATTERN_CD,RECIPIENT_GSTIN_NO,ACC_GROUP,IRFC_FUNDED,IRFC_BPO_CD) values('" + txtCaseNo.Text.Trim() + "', to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')," + lblCSNO.Text + "," + lstICType.SelectedValue + "," + lstConsignee.SelectedValue + ",'" + lblBPOCD.Text.Trim() + "','" + txtBKNO.Text.Trim() + "','" + txtSetNo.Text.Trim() + "', " + lblIECD.Text + ",'" + txtCertNo.Text.Trim() + "',to_date('" + txtCertDt.Text.Trim() + "','dd/mm/yyyy'),to_date('" + txtCDate.Text.Trim() + "','dd/mm/yyyy')," + txtCInstallNo.Text.Trim() + ",'" + lstFPart.SelectedValue + "',upper('" + txtPattern.Text + "'),'" + txtReason.Text + "'," + txtNofIns.Text + ",to_date('" + txtFIDT.Text + "','dd/mm/yyyy'),to_date('" + txtLIDT.Text + "','dd/mm/yyyy'),'" + txtOIDT.Text + "',to_date('" + txtICSDT.Text + "','dd/mm/yyyy'),'','" + Session["Uname"] + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + lstPhoto.SelectedValue + "'," + CO + ",'" + lstStampPatternCD.SelectedValue + "','" + txtGSTINNo.Text.Trim() + "','" + acc_group + "','" + w_irfc_funded + "','" + w_irfc_bpo + "')";
							OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
							myInsertCommand.Connection = conn1;
							myInsertCommand.Transaction = myTrans;
							myInsertCommand.ExecuteNonQuery();
							Cstatus = setCallStatus();
							string updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + Cstatus + "' where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + "";
							OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn1);
							myUpdateCommand.Transaction = myTrans;
							myUpdateCommand.ExecuteNonQuery();
							myTrans.Commit();
							conn1.Close();
							if (lblSTS.Text == "X")
							{
								btnGBill.Visible = false;
								btnSave.Visible = false;
								btnDelete.Enabled = false;
							}
							else
							{
								btnGBill.Visible = true;
							}
							fillgrid1();
							lblConsignee.Text = lstConsignee.SelectedItem.Text;
							lstConsignee.Visible = false;

						}
						else
						{
							DisplayAlert("Inspection Certificate Already Present For the Given Book No. and Set No. !!!");
						}
					}
					else if (Action == "M")
					{
						//						if(check1=="")
						//						{

						if (ddlIRFC.SelectedValue == "Y")
						{
							w_irfc_funded = ddlIRFC.SelectedValue.ToString();
							w_irfc_bpo = ddlIRFCBPO.SelectedValue;
							acc_group = "";
						}
						else
						{
							w_irfc_funded = "N";
						}

						string myUpdateQuery = "Update T20_IC set IC_TYPE_ID=" + lstICType.SelectedValue + ",BK_NO=upper('" + txtBKNO.Text.Trim() + "'),SET_NO= '" + txtSetNo.Text.Trim() + "',IC_NO='" + txtCertNo.Text.Trim() + "',IC_DT=to_date('" + txtCertDt.Text.Trim() + "','dd/mm/yyyy'),CALL_DT=to_date('" + txtCDate.Text.Trim() + "','dd/mm/yyyy'),CALL_INSTALL_NO=" + txtCInstallNo.Text + ",FULL_PART='" + lstFPart.SelectedValue + "',STAMP_PATTERN=upper('" + txtPattern.Text + "'),REASON_REJECT='" + txtReason.Text + "',NO_OF_INSP=" + txtNofIns.Text + ",FIRST_INSP_DT=to_date('" + txtFIDT.Text + "','dd/mm/yyyy'),LAST_INSP_DT=to_date('" + txtLIDT.Text + "','dd/mm/yyyy'),OTHER_INSP_DT='" + txtOIDT.Text + "',IC_SUBMIT_DT=to_date('" + txtICSDT.Text + "','dd/mm/yyyy'),USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),PHOTO='" + lstPhoto.SelectedValue + "',STAMP_PATTERN_CD='" + lstStampPatternCD.SelectedValue + "', RECIPIENT_GSTIN_NO='" + txtGSTINNo.Text.Trim() + "',ACC_GROUP='" + acc_group + "', IRFC_FUNDED='" + w_irfc_funded + "', IRFC_BPO_CD='" + w_irfc_bpo + "' where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + " and CONSIGNEE_CD=" + lstConsignee.SelectedValue;
						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
						myUpdateCommand.Connection = conn1;
						myUpdateCommand.Transaction = myTrans;
						myUpdateCommand.ExecuteNonQuery();
						Cstatus = setCallStatus();
						upQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + Cstatus + "', UPDATE_ALLOWED='N' where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + "";
						OracleCommand myUpdateCommand1 = new OracleCommand(upQuery, conn1);
						myUpdateCommand1.Transaction = myTrans;
						myUpdateCommand1.ExecuteNonQuery();
						myTrans.Commit();
						conn1.Close();
						btnSave.Visible = true;
						btnGBill.Text = "Update Bill";
						btnGBill.Visible = true;



						fillgrid1();
						//						}
						//						else
						//						{
						//							DisplayAlert("Inspection Certificate Already Present For the Given Book No. and Set No. !!!");
						//						}

					}

					//lblCon.Visible=true;
				}
				catch (OracleException ex)
				{
					string str;
					myTrans.Rollback();
					if (ex.ErrorCode == 00001)
					{
						OracleCommand cmd_err = new OracleCommand("Select BK_NO,SET_NO from T20_IC where CASE_NO='" + txtCaseNo.Text.Trim() + "' and  CALL_RECV_DT= to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + " and CONSIGNEE_CD=" + lstConsignee.SelectedValue, conn1);
						OracleDataReader reader = cmd_err.ExecuteReader();
						while (reader.Read())
						{
							DisplayAlert("Inspection Certificate vide Book No. " + reader["BK_NO"].ToString() + " and Set No." + reader["SET_NO"].ToString() + " Exists for the Given CASE NO. and CALL DATE and CONSIGNEE!!!, So use modify to update that Inspection Certificate");
						}
						//Response.Redirect(("Error_Form.aspx?err=" + ""));
					}
					else
					{
						str = ex.Message;
						string str1 = str.Replace("\n", "");
						Response.Redirect(("Error_Form.aspx?err=" + str1));
					}
				}
				finally
				{
					conn1.Close();
				}
				checkManDay();

			}
			else if (bscheck == "")
			{
				DisplayAlert("Book No. and Set No. specified is not issued to the Selected Inspection Engineer!!!");
			}
			else if (bscheck1 != "")
			{
				DisplayAlert("Book No. and Set No. specified is being Cancelled or Missed!!!");
			}
			else if (bscheck2 != "")
			{
				DisplayAlert("Recipient GST No. State Code Does not match with the State Code of the Recipient!!!");
			}
			else if (bscheck3 == 1)
			{
				DisplayAlert("Select the one of the Options for GST Recipient, i.e. Consignee, BPO or IRFC BPO!!!");
			}

			string myYear1, myMonth1, myDay1;

			myYear1 = txtCertDt.Text.Substring(6, 4);
			myMonth1 = txtCertDt.Text.Substring(3, 2);
			myDay1 = txtCertDt.Text.Substring(0, 2);
			string certdt = myYear1 + myMonth1 + myDay1;
			if (Convert.ToInt32(certdt) >= 20170701)
			{
				lstBPOTaxType.Visible = false;
				lstBPOTaxType_GST.Visible = true;
				if (Session["Region"].ToString() == "N" && txtGSTINNo.Text.Substring(0, 2) == "07")
				{
					lstBPOTaxType_GST.SelectedValue = "C";
				}
				else if (Session["Region"].ToString() == "S" && txtGSTINNo.Text.Substring(0, 2) == "33")
				{
					lstBPOTaxType_GST.SelectedValue = "C";
				}
				else if (Session["Region"].ToString() == "E" && txtGSTINNo.Text.Substring(0, 2) == "19")
				{
					lstBPOTaxType_GST.SelectedValue = "C";
				}
				else if (Session["Region"].ToString() == "W" && txtGSTINNo.Text.Substring(0, 2) == "27")
				{
					lstBPOTaxType_GST.SelectedValue = "C";
				}
				else if (Session["Region"].ToString() == "C" && txtGSTINNo.Text.Substring(0, 2) == "22")
				{
					lstBPOTaxType_GST.SelectedValue = "C";
				}
				else if (Session["Region"].ToString() == "Q" && txtGSTINNo.Text.Substring(0, 2) == "06")
				{
					lstBPOTaxType_GST.SelectedValue = "C";
				}
				else
				{
					lstBPOTaxType_GST.SelectedValue = "I";
				}
			}
			else
			{
				lstBPOTaxType.Visible = true;
				lstBPOTaxType_GST.Visible = false;
			}

		}

		void checkManDay()
		{
			//This is the Function to Check whether their is another IC Present for the same IE, same Purchaser wid Same Inspection Date, soo, it will show all other cases with this condition equal to true.
			//string str="select I.BILL_NO,I.BK_NO,i.SET_NO from t13_po_master m,T20_IC i where IE_CD="+lblIECD.Text+" and PURCHASER_CD=(select PURCHASER_CD from t13_po_master where CASE_NO ='"+txtCaseNo.Text+"') and ((Select nvl(FEE_TYPE,'X') FROM T22_BILL Where BILL_NO=I.BILL_NO) in ('P','D')) and ((to_date('"+txtFIDT.Text+"','dd/mm/yyyy') between FIRST_INSP_DT and nvl(LAST_INSP_DT,FIRST_INSP_DT)) or(to_date('"+txtLIDT.Text+"','dd/mm/yyyy') between FIRST_INSP_DT and nvl(LAST_INSP_DT,FIRST_INSP_DT))) GROUP BY I.BILL_NO,I.BK_NO,i.SET_NO";
			string str = "select I.BILL_NO,I.BK_NO,i.SET_NO from t13_po_master m,T20_IC i where IE_CD=" + lblIECD.Text + " and PURCHASER_CD=(select PURCHASER_CD from t13_po_master where CASE_NO ='" + txtCaseNo.Text + "')and (RLY_NONRLY!= 'R') and((to_date('" + txtFIDT.Text + "','dd/mm/yyyy') between FIRST_INSP_DT and nvl(LAST_INSP_DT,FIRST_INSP_DT)) or(to_date('" + txtLIDT.Text + "','dd/mm/yyyy') between FIRST_INSP_DT and nvl(LAST_INSP_DT,FIRST_INSP_DT))) GROUP BY I.BILL_NO,I.BK_NO,i.SET_NO";
			DataSet dsP = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(str, conn1);
			OracleCommand cmd = new OracleCommand(str, conn1);
			conn1.Open();
			da.SelectCommand = cmd;
			da.Fill(dsP, "Table");
			string msg = "";
			if (dsP.Tables[0].Rows.Count > 1)
			{
				msg = "IC With the given inspection date, IE and Purchaser Already Exists: \\n";
				int j = 1;
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					if (dsP.Tables[0].Rows[i]["BK_NO"].ToString() + dsP.Tables[0].Rows[i]["SET_NO"].ToString() != txtBKNO.Text.ToString() + txtSetNo.Text.ToString())
					{
						msg = msg + (j) + ") Bill No: " + dsP.Tables[0].Rows[i]["BILL_NO"].ToString() + " vide Book NO=" + dsP.Tables[0].Rows[i]["BK_NO"].ToString() + " & Set No.=" + dsP.Tables[0].Rows[i]["SET_NO"].ToString() + ". \\n";
						j = j + 1;

					}
				}
				msg = msg + " So Plz Check These Cases,Before Proceeding !!!";
				DisplayAlert(msg);
			}

			conn1.Close();


		}

		private void DisplayAlert1(string msg)
		{
			msg = msg + " Do You Want to Continue wid same values?";
			Response.Write("<script language=JavaScript> var d=confirm('" + msg + "'); if(d==false) location.href='Inspection_Certificate_Form.aspx?Action=M&BK_NO=" + txtBKNO.Text + "&SET_NO=" + txtSetNo.Text + "'</script>");

		}
		string setCallStatus()
		{
			if (lstICType.SelectedValue == "2")
			{
				return ("R");
			}
			else if (lstICType.SelectedValue == "6")
			{
				return ("C");
			}
			else
			{
				//			return("A");
				return ("B");
			}

		}
		private void Textbox2_TextChanged(object sender, System.EventArgs e)
		{

		}
		void fillgrid1()
		{
			try
			{
				string str1 = "SELECT C.ITEM_SRNO_PO,C.ITEM_DESC_PO,U.UOM_S_DESC,C.QTY_ORDERED,C.CUM_QTY_PREV_OFFERED,C.CUM_QTY_PREV_PASSED,C.QTY_TO_INSP,C.QTY_PASSED,C.QTY_REJECTED,C.QTY_DUE,P.RATE,P.SALES_TAX_PER,P.SALES_TAX,P.EXCISE_PER,P.EXCISE,P.DISCOUNT_PER,P.DISCOUNT,P.OTHER_CHARGES FROM T18_CALL_DETAILS C, T15_PO_DETAIL P,T04_UOM U where C.CASE_NO=P.CASE_NO AND P.ITEM_SRNO=C.ITEM_SRNO_PO AND P.UOM_CD=U.UOM_CD and C.CASE_NO='" + txtCaseNo.Text.Trim() + "' AND C.CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') AND C.CALL_SNO=" + lblCSNO.Text + " AND C.CONSIGNEE_CD=" + lstConsignee.SelectedValue;
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCDetails.Visible = false;
					btnGBill.Visible = false;
					grdCDetails_1.Visible = false;
					btnSave2.Visible = false;
					btnCancel2.Visible = false;
					DisplayAlert("Their are no Items present for given Case No., Call Date, Call SNo. And Consignee!!! ");

				}
				else
				{
					grdCDetails.DataSource = dsP;
					grdCDetails.DataBind();
					grdCDetails_1.DataSource = dsP;
					grdCDetails_1.DataBind();
					grdCDetails.Visible = true;
					grdCDetails_1.Visible = false;
					btnSave2.Visible = false;
					btnCancel2.Visible = false;
					btnShow.Visible = true;
					int count = 0;
					if (lstICType.SelectedItem.Value != "2")
					{
						for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
						{
							if (dsP.Tables[0].Rows[i]["QTY_PASSED"].ToString() == "" || dsP.Tables[0].Rows[i]["QTY_PASSED"].ToString() == "0")
							{
								count = count + 1;
							}
						}
						if (count == dsP.Tables[0].Rows.Count)
						{
							btnGBill.Visible = false;
						}
						else
						{
							if (Session["Role_CD"].ToString() == "1" || Session["Role_CD"].ToString() == "2")
							{
								if (lblSTS.Text == "X")
								{
									btnGBill.Visible = false;
									btnSave.Visible = false;
									btnDelete.Enabled = false;
								}
								else
								{
									btnGBill.Visible = true;
								}
							}
							else
							{
								btnGBill.Visible = false;
							}
						}
					}

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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void btnSItem_Click(object sender, System.EventArgs e)
		{

		}

		public void grdCDetails_Edit(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			btnCancel.Visible = false;
			btnSave.Visible = false;
			btnGBill.Visible = false;
			grdCDetails.EditItemIndex = e.Item.ItemIndex;
			//int i=e.Item.ItemIndex;
			//string aa=Convert.ToString(((TextBox)e.Item.Cells[8].Controls[0]).ForeColor);
			fillgrid1();
			//			if(lstICType.SelectedItem.Value=="2")
			//			{
			//				
			//				e.Item.Cells[8].Text="hello";
			//				e.Item.Cells[8].Enabled=false;
			//				
			//				//e.Item.Cells[8].Text=="0";
			//				//(e.Item.FindControl("txtQPASS")  as TextBox).Text="0";
			//				//(e.Item.FindControl("txtQPASS")  as TextBox).Enabled=false;
			//				//txtQPASS.Enabled=false;
			//			}

			//grdCDetails.EditItemStyle.ForeColor=System.Drawing.Color.LightSeaGreen;

			//settext(e);


		}

		public void grdCDetails_Cancel(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			btnCancel.Visible = true;
			btnSave.Visible = true;
			btnGBill.Visible = true;
			grdCDetails.EditItemIndex = -1;
			fillgrid1();
		}

		public void grdCDetails_Update(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//	string aa=Convert.ToString(((TextBox)e.Item.Cells[8].Controls[0]).Width);
				decimal pqty = 0, rqty = 0, dqty = 0, qoff = 0, qord = 0;
				decimal isrno = Convert.ToDecimal(e.Item.Cells[1].Text);
				string idesc = "";
				if (e.Item.Cells[4].Text != "")
				{
					qord = Convert.ToDecimal(e.Item.Cells[4].Text);
				}
				//				if(e.Item.Cells[7].Text!="")
				//				{
				//				qoff=Convert.ToDecimal(e.Item.Cells[7].Text);
				//				}
				if ((e.Item.FindControl("txtQOFF") as TextBox).Text.Trim() != "")
				{
					qoff = Convert.ToDecimal((e.Item.FindControl("txtQOFF") as TextBox).Text.Trim());
				}

				if ((e.Item.FindControl("txtQPASS") as TextBox).Text.Trim() != "")
				{
					pqty = Convert.ToDecimal((e.Item.FindControl("txtQPASS") as TextBox).Text.Trim());
				}

				if ((e.Item.FindControl("txtQREJ") as TextBox).Text.Trim() != "")
				{
					rqty = Convert.ToDecimal((e.Item.FindControl("txtQREJ") as TextBox).Text.Trim());
				}

				if ((e.Item.FindControl("txtQDUE") as TextBox).Text.Trim() != "")
				{
					dqty = Convert.ToDecimal((e.Item.FindControl("txtQDUE") as TextBox).Text.Trim());
				}

				if ((e.Item.FindControl("txtItemDesc") as TextBox).Text != "")
				{
					idesc = Convert.ToString((e.Item.FindControl("txtItemDesc") as TextBox).Text);
				}
				//OracleCommand cmd = new OracleCommand("Select NVL(SUM(NVL(QTY_PASSED,0)),0) from T18_CALL_DETAILS where CASE_NO= '" + txtCaseNo.Text + "' AND CALL_RECV_DT!= to_date('"+ txtDtOfReciept.Text +"','dd/mm/yyyy') AND ITEM_SRNO_PO=" + isrno,conn1); 
				OracleCommand cmd = new OracleCommand("Select NVL(sum(NVL(D.QTY_PASSED,0)),0) from T17_CALL_REGISTER R,T18_CALL_DETAILS D where R.CASE_NO=D.CASE_NO and R.CALL_RECV_DT=D.CALL_RECV_DT and R.CALL_SNO=D.CALL_SNO and R.CASE_NO= '" + txtCaseNo.Text + "' AND D.ITEM_SRNO_PO=" + isrno + " and R.CALL_STATUS not in('R','C') AND (D.ROWID!=(Select ROWID from T18_CALL_DETAILS g where g.CASE_NO='" + txtCaseNo.Text + "' and g.CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and g.CALL_SNO=" + lblCSNO.Text + " AND g.ITEM_SRNO_PO=" + isrno + "))", conn1);
				conn1.Open();
				decimal tpqty = Convert.ToDecimal(cmd.ExecuteScalar());
				conn1.Close();
				tpqty = tpqty + pqty;
				int error = 0;
				if (pqty > qoff)
				{
					DisplayAlert("QTY PASSED SHOULD NOT BE GREATER THEN QTY OFF NOW!!!");

				}

				if (error == 0)
				{

					conn1.Open();

					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss1 = Convert.ToString(cmd2.ExecuteScalar());

					string myUpdateQuery = "Update T18_CALL_DETAILS set ITEM_DESC_PO=upper('" + idesc + "'),QTY_TO_INSP=" + qoff + ",QTY_PASSED=" + pqty + ", QTY_REJECTED=" + rqty + ",QTY_DUE=" + dqty + ",USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss1 + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text.Trim() + " and ITEM_SRNO_PO=" + isrno;
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn1;
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();

					grdCDetails.EditItemIndex = -1;


					btnCancel.Visible = true;
					btnSave.Visible = true;
					btnGBill.Visible = true;
					fillgrid1();
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

		protected void lstConsignee_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string str3 = "select P.BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME,B.BPO_TYPE,B.BPO_RLY,B.BPO_FEE,B.BPO_FEE_TYPE,NVL(B.BPO_TAX_TYPE,'X')BPO_TAX_TYPE from T14_PO_BPO P, T12_BILL_PAYING_OFFICER B,T03_CITY C where (P.BPO_CD=B.BPO_CD) and B.BPO_CITY_CD=C.CITY_CD and CASE_NO= '" + txtCaseNo.Text + "' and CONSIGNEE_CD=" + lstConsignee.SelectedValue;
			OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
			conn1.Open();
			OracleDataReader reader1 = myOracleCommand3.ExecuteReader();
			while (reader1.Read())
			{
				lblBPO.Text = reader1["BPO_NAME"].ToString();
				lblBPOCD.Text = reader1["BPO_CD"].ToString();
				lblBPO_TYPE.Text = reader1["BPO_TYPE"].ToString();
				lblBPORail.Text = reader1["BPO_RLY"].ToString();
				txtBPOFee.Text = reader1["BPO_FEE"].ToString();
				lstBPOFeeType.SelectedValue = reader1["BPO_FEE_TYPE"].ToString();
				lstBPOTaxType.SelectedValue = reader1["BPO_TAX_TYPE"].ToString();
			}
			conn1.Close();
			txtCertNo.Text = Session["Region"] + "/" + lblBPORail.Text + "/" + CNO + "/" + lblIESName.Text;
			//grdCDetails.Columns[0].Visible=false;
			fill_BPO(lblBPOCD.Text);
			//fillgrid1();
			if (rdbConsignee.Checked == true || rdbBPO.Checked == true)
			{
				getconsignee_gstno();
			}

			fill_ic_details();
		}

		private void lstConsignee_Load(object sender, System.EventArgs e)
		{

		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Inspection_Certificate_Edit_Form.aspx");
		}
		int chk_bill_dt()
		{
			if (Session["Region"].ToString() != "Q")
			{
				conn1.Open();
				OracleCommand cmd = new OracleCommand("Select ALLOW_OLD_BILL_DT from T97_CONTROL_FILE where REGION='" + Session["Region"].ToString() + "'", conn1);
				string allowstatus = Convert.ToString(cmd.ExecuteScalar());
				OracleCommand cmd2 = new OracleCommand("Select to_char(MIN_BILL_DT,'yyyymmdd') from T87_BILL_CONTROL", conn1);
				string min_bill_dt = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();

				string myYear, myMonth, myDay;
				myYear = txtBDT.Text.Substring(6, 4);
				myMonth = txtBDT.Text.Substring(3, 2);
				myDay = txtBDT.Text.Substring(0, 2);
				string dt1 = myYear + myMonth + myDay;

				if (allowstatus == "N")
				{
					conn1.Open();
					OracleCommand cmd1 = new OracleCommand("Select to_char(sysdate-Grace_days,'yyyymmdd') from T97_CONTROL_FILE where REGION='" + Session["Region"].ToString() + "'", conn1);
					string grace_days = Convert.ToString(cmd1.ExecuteScalar());
					conn1.Close();
					if (grace_days != "")
					{

						if (dt1.CompareTo(grace_days) > 0 || dt1.CompareTo(grace_days) == 0)
						{
							if (dt1.CompareTo(min_bill_dt) > 0)
							{
								return (1);
							}
							else
							{
								return (0);
							}
						}
						else
						{

							return (0);
						}
					}
					else
					{
						return (0);
					}

				}
				else
				{
					if (dt1.CompareTo(min_bill_dt) > 0)
					{
						return (1);
					}
					else
					{
						return (0);
					}
				}
			}
			else
			{
				return (1);
			}
		}
		protected void btnGBill_Click(object sender, System.EventArgs e)
		{
			try
			{

				conn1.Open();
				OracleCommand cmd11 = new OracleCommand("Select to_char(sysdate,'yyyymmdd') from dual", conn1);
				string sdate = Convert.ToString(cmd11.ExecuteScalar());
				conn1.Close();

				string myYear, myMonth, myDay;

				myYear = txtBDT.Text.Substring(6, 4);
				myMonth = txtBDT.Text.Substring(3, 2);
				myDay = txtBDT.Text.Substring(0, 2);
				string dt1 = myYear + myMonth + myDay;
				int i = dt1.CompareTo(sdate);
				int f = financial_year_check();
				if (f == 1)
				{
					DisplayAlert("Bill must be generated within the same financial year in which IC was Issued!!!" + ". \\n(ie. Certificate Date & Bill Date shoud be in same financial year)");
				}
				else if (i > 0)
				{
					DisplayAlert("Bill Date Cannot be greater then Current Date!!!");
				}
				else if (lblBPO_TYPE.Text == "R" && lblAU.Text == "" && !(lblBPORail.Text == "RCF" || lblBPORail.Text == "ICF" || lblBPORail.Text == "RWF"))
				{
					DisplayAlert("AU Cannot be Blank For Railways Bills, Kindly Update the AU for the BPO and then Generate the Bill!!!");
				}
				else
				{
					if (lblBillNo.Visible == false)
					{
						if (chk_bill_dt() == 1)
						{
							if (lstICType.SelectedValue == "9")
							{
								gen_credit_note();
							}
							else
							{
								gen_bill();
							}
							if (ddlCanOrRejctionFee.SelectedValue == "Y" && lblBillNo.Visible == true)
							{
								conn1.Open();
								string myUpdateQuery = "Update T13_PO_MASTER set PENDING_CHARGES=PENDING_CHARGES-1 where CASE_NO= '" + txtCaseNo.Text + "' and NVL(PENDING_CHARGES,0)>0";
								OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
								myUpdateCommand.Connection = conn1;
								myUpdateCommand.ExecuteNonQuery();
								conn1.Close();
								send_Vend_sms();
							}
						}
						else
						{
							DisplayAlert("Old Bill Date is not allowed!!!");

						}
					}
					else if (lblBillNo.Visible == true)
					{
						if (lstICType.SelectedValue == "9")
						{
							gen_credit_note();
						}
						else
						{
							gen_bill();
						}
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
			//Console.WriteLine("Division is: " + cmd.Parameters["dv"].Value);


		}

		void send_Vend_sms()
		{
			string sender = "";
			string wVendor = "", wVendMobile = "";
			OracleCommand cmd = new OracleCommand();
			if (Session["Region"].ToString() == "N") { sender = "RITES/NR"; }
			else if (Session["Region"].ToString() == "W") { sender = "RITES/WR"; }
			else if (Session["Region"].ToString() == "E") { sender = "RITES/ER"; }
			else if (Session["Region"].ToString() == "S") { sender = "RITES/SR"; }
			else { sender = "RITES"; }
			//
			conn1.Open();

			cmd.CommandText = "select replace(substr(V.VEND_NAME,1,30),'&','AND')||','||substr(C.CITY,1,12) VEND_NAME,trim(substr(VEND_CONTACT_TEL_1,1,10)) VEND_TEL from T05_VENDOR V, T03_CITY C, T13_PO_MASTER T13 where V.VEND_CITY_CD=C.CITY_CD AND T13.VEND_CD=V.VEND_CD AND  CASE_NO='" + txtCaseNo.Text + "' ";
			cmd.Connection = conn1;
			OracleDataReader reader2 = cmd.ExecuteReader();
			while (reader2.Read())
			{
				wVendor = reader2["VEND_NAME"].ToString();
				wVendMobile = reader2["VEND_TEL"].ToString();
			}
			cmd.Dispose();

			string message = "FIRM NAME-" + wVendor + ". The Billing has generated for the Case No." + txtCaseNo.Text + ", against Call Cancellation/Rejection Charges Submitted by you. Kindly try to register new call now." + " - RITES LTD" + sender;
			if (wVendMobile != "")
			{
				WebClient client = new WebClient();
				//string baseurl = "http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=1ritesltd&password=R1te3@lxt&sender=RITESQ&to="+wVendMobile+"&message="+message+"&reqid=1&format={json|text}&route_id=23";
				//string baseurl = "http://103.247.98.91/API/SendMsg.aspx?uname=20181896&pass=9eBWwFz9&send=RITESQ&dest="+wVendMobile+"&msg="+message+"&priority=1";
				//string baseurl = "http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=2ritesltd&password=Ag@14rtd&sender=RITESQ&to="+wVendMobile+"&message="+message+"&reqid=1&format={json|text}&route_id=23";


				//string baseurl = "http://nimbusit.co.in/api/swsendSingle.asp?username=t1RitesLtd&password=104848267&sender=RITESI&sendto="+wVendMobile+"&entityID=1501628520000011823&templateID=1707161648485350941&message="+message+"&entityID=1501484780000011007";				

				string baseurl = "http://apin.onex-aura.com/api/sms?key=QtPr681q&to=" + wVendMobile + "&from=RITESI&body=" + message + "&entityid=1501628520000011823&templateid=1707161648485350941";
				Stream data = client.OpenRead(baseurl);
				StreamReader smsreader = new StreamReader(data);
				string s = smsreader.ReadToEnd();
				data.Close();
				smsreader.Close();
			}
		}



		int financial_year_check()
		{

			conn1.Open();
			OracleCommand cmd11 = new OracleCommand("Select to_char(IC_DT,'yyyymm') from T20_IC where TRIM(BK_NO)=upper('" + txtBKNO.Text + "') and TRIM(SET_NO)='" + txtSetNo.Text + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "'", conn1);
			string sdate = Convert.ToString(cmd11.ExecuteScalar());
			conn1.Close();
			string myYear, myMonth;
			int fin_year_IC = 0;

			myYear = sdate.Substring(0, 4);
			myMonth = sdate.Substring(4, 2);
			if (Convert.ToInt16(myMonth) >= 4 && Convert.ToInt16(myMonth) <= 12)
			{
				fin_year_IC = Convert.ToInt16(myYear);
			}
			else
			{
				fin_year_IC = Convert.ToInt16(myYear) - 1;
			}

			string myYear1, myMonth1;
			int fin_year_BILL = 0;
			myYear1 = txtBDT.Text.Substring(6, 4);
			myMonth1 = txtBDT.Text.Substring(3, 2);
			if (Convert.ToInt16(myMonth1) >= 4 && Convert.ToInt16(myMonth1) <= 12)
			{
				fin_year_BILL = Convert.ToInt16(myYear1);
			}
			else
			{
				fin_year_BILL = Convert.ToInt16(myYear1) - 1;
			}

			if (fin_year_BILL == fin_year_IC)
			{
				return (0);
			}
			else
			{
				return (1);
			}

		}

		void gen_credit_note()
		{
			if (lblBPOCD.Text.Trim() != lstBPO.SelectedValue.Trim())
			{
				try
				{
					conn1.Open();
					string myUpdateQuery = "Update T20_IC set BPO_CD='" + lstBPO.SelectedValue + "' where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + " and CONSIGNEE_CD=" + lstConsignee.SelectedValue;
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn1;
					myUpdateCommand.ExecuteNonQuery();
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

			string c_note_bno = "";
			if (txtBillNo.Enabled == false && btnVerify.Visible == false && txtBillNo.Text.Length == 10)
			{
				c_note_bno = txtBillNo.Text;
			}


			if (c_note_bno != "")
			{
				string myYear1, myMonth1, myDay1;

				myYear1 = txtCertDt.Text.Substring(6, 4);
				myMonth1 = txtCertDt.Text.Substring(3, 2);
				myDay1 = txtCertDt.Text.Substring(0, 2);
				string certdt = myYear1 + myMonth1 + myDay1;
				OracleCommand cmd = null;
				//			if(Convert.ToInt32(certdt)>=20170701)
				//			{
				//				cmd = new OracleCommand("GENERATE_BILL_GST",conn1);
				//			}
				//			else
				//			{
				cmd = new OracleCommand("GENERATE_CREDIT_NOTE", conn1);
				//			}

				cmd.CommandType = CommandType.StoredProcedure;
				conn1.Open();
				OracleParameter prm1 = new OracleParameter("IN_REGION_CD", System.Data.OracleClient.OracleType.Char);
				prm1.Direction = ParameterDirection.Input;
				string reg_cd = "";
				if (Session["REGION"].ToString() == "N")
				{
					reg_cd = "O";
				}
				else if (Session["REGION"].ToString() == "S")
				{
					reg_cd = "T";
				}
				else if (Session["REGION"].ToString() == "W")
				{
					reg_cd = "X";
				}
				else if (Session["REGION"].ToString() == "E")
				{
					reg_cd = "F";
				}
				else if (Session["REGION"].ToString() == "C")
				{
					reg_cd = "D";
				}
				else if (Session["REGION"].ToString() == "Q")
				{
					reg_cd = "R";
				}
				prm1.Value = reg_cd;
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_CASE_NO", System.Data.OracleClient.OracleType.VarChar);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = txtCaseNo.Text;
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("IN_CALL_RECV_DT", System.Data.OracleClient.OracleType.Char);
				prm3.Direction = ParameterDirection.Input;
				prm3.Value = Convert.ToString(txtDtOfReciept.Text);
				cmd.Parameters.Add(prm3);

				OracleParameter prm31 = new OracleParameter("IN_CALL_SNO", System.Data.OracleClient.OracleType.Number);
				prm31.Direction = ParameterDirection.Input;
				prm31.Value = Convert.ToInt32(lblCSNO.Text);
				cmd.Parameters.Add(prm31);

				OracleParameter prm4 = new OracleParameter("IN_CONSIGNEE_CD", System.Data.OracleClient.OracleType.Number);
				prm4.Direction = ParameterDirection.Input;
				prm4.Value = lstConsignee.SelectedValue;
				cmd.Parameters.Add(prm4);

				OracleParameter prm5 = new OracleParameter("IN_BILL", System.Data.OracleClient.OracleType.VarChar);
				prm5.Direction = ParameterDirection.Input;
				if (lblBillNo.Visible == true)
				{
					prm5.Value = lblBillNo.Text;

				}
				else
				{
					prm5.Value = "Z";
				}
				cmd.Parameters.Add(prm5);


				OracleParameter prm6 = new OracleParameter("IN_FEE_TYPE", System.Data.OracleClient.OracleType.Char);
				prm6.Direction = ParameterDirection.Input;
				prm6.Value = lstBPOFeeType.SelectedValue;
				cmd.Parameters.Add(prm6);

				OracleParameter prm7 = new OracleParameter("IN_FEE", System.Data.OracleClient.OracleType.Number);
				prm7.Direction = ParameterDirection.Input;
				prm7.Value = txtBPOFee.Text;
				cmd.Parameters.Add(prm7);

				if (Convert.ToInt32(certdt) >= 20170701)
				{
					OracleParameter prm8 = new OracleParameter("IN_TAX_TYPE", System.Data.OracleClient.OracleType.Char);
					prm8.Direction = ParameterDirection.Input;
					prm8.Value = lstBPOTaxType_GST.SelectedValue;
					cmd.Parameters.Add(prm8);
				}
				else
				{
					OracleParameter prm8 = new OracleParameter("IN_TAX_TYPE", System.Data.OracleClient.OracleType.Char);
					prm8.Direction = ParameterDirection.Input;
					prm8.Value = lstBPOTaxType.SelectedValue;
					cmd.Parameters.Add(prm8);
				}

				OracleParameter prm9 = new OracleParameter("IN_NO_OF_INSP", System.Data.OracleClient.OracleType.Number);
				prm9.Direction = ParameterDirection.Input;
				if (txtNofIns.Text == "")
				{
					prm9.Value = 1;
				}
				else
				{
					prm9.Value = txtNofIns.Text;
				}
				cmd.Parameters.Add(prm9);

				OracleParameter prm91 = new OracleParameter("IN_MAX_FEE", System.Data.OracleClient.OracleType.Number);
				prm91.Direction = ParameterDirection.Input;
				if (txtMaxFeeAllow.Text.Trim() == "")
				{
					prm91.Value = -1; //In Case OF MAXM FEE is NULL
				}
				else
				{
					prm91.Value = Convert.ToInt32(txtMaxFeeAllow.Text);
				}
				cmd.Parameters.Add(prm91);

				OracleParameter prm92 = new OracleParameter("IN_MIN_FEE", System.Data.OracleClient.OracleType.Number);
				prm92.Direction = ParameterDirection.Input;
				if (txtMinFeeAllow.Text.Trim() == "")
				{
					prm92.Value = 0;
				}
				else
				{
					prm92.Value = Convert.ToInt32(txtMinFeeAllow.Text);
				}
				cmd.Parameters.Add(prm92);

				OracleParameter prm93 = new OracleParameter("IN_BILL_DT", OracleDbType.Varchar2, 8);
				prm93.Direction = ParameterDirection.Input;
				prm93.Value = Convert.ToString(txtBDT.Text.Replace("/", ""));
				cmd.Parameters.Add(prm93);


				OracleParameter prm94 = new OracleParameter("IN_ADV_BILL", OracleDbType.Char, 1);
				prm94.Direction = ParameterDirection.Input;
				if (chkABill.Checked == true)
				{
					prm94.Value = "A";
				}
				else
				{
					prm94.Value = "X";
				}
				cmd.Parameters.Add(prm94);
				if (Convert.ToInt32(certdt) >= 20170701)
				{
					OracleParameter prm95 = new OracleParameter("IN_INVOICE", System.Data.OracleClient.OracleType.VarChar);
					prm95.Direction = ParameterDirection.Input;
					if (lblInvoiceNo.Text.Trim() == "" || lblInvoiceNo.Text.Trim().Length < 13)
					{
						if (Session["REGION"].ToString() == "N")
						{
							prm95.Value = "0708";
						}
						else if (Session["REGION"].ToString() == "W")
						{
							prm95.Value = "2705";
						}
						else if (Session["REGION"].ToString() == "E")
						{
							prm95.Value = "1906";
						}
						else if (Session["REGION"].ToString() == "S")
						{
							prm95.Value = "3307";
						}
						else if (Session["REGION"].ToString() == "C")
						{
							prm95.Value = "2210";
						}
						else if (Session["REGION"].ToString() == "Q")
						{
							//prm95.Value = "0601";
							prm95.Value = "0708";
						}

					}
					else
					{
						prm95.Value = lblInvoiceNo.Text.Trim();
					}
					cmd.Parameters.Add(prm95);
				}

				OracleParameter prm10 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32, 1);
				prm10.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm10);

				OracleParameter prm11 = new OracleParameter("OUT_BILL", OracleDbType.Varchar2, 20);
				prm11.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm11);

				OracleParameter prm12 = new OracleParameter("OUT_FEE", OracleDbType.Int32, 15);
				prm12.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm12);

				cmd.ExecuteNonQuery();
				conn1.Close();


				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					DisplayAlert("Fee Details not available.");
				}
				else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -2)
				{
					DisplayAlert("MINIMUM FEE PAYBLE IS GREATER THEN MAXIMUM FEE");
				}
				else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -3)
				{
					DisplayAlert("Unable to access Bill Master.");
				}
				else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -4)
				{
					DisplayAlert("Unable to Insert New Bill No. in Bill Master.");
				}
				else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -5)
				{
					DisplayAlert("Invalid Bill No. Passed as Parameter.");
				}
				else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -6)
				{
					DisplayAlert("Unable to Insert Bill Details.");
				}
				else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -7)
				{
					DisplayAlert("Error occured during updating Fee Details in Bill Master.");
				}
				else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -8)
				{
					if (Convert.ToInt32(certdt) >= 20170701)
					{
						DisplayAlert("Unable to Select GST Tax Rates");
					}
					else
					{
						DisplayAlert("Unable to Select Service Tax Rates");

					}
				}
				else
				{
					Label24.Visible = true;
					lblBillNo.Visible = true;
					lblBillNo.Text = Convert.ToString(cmd.Parameters["OUT_BILL"].Value);

					string str3 = "select B.MATERIAL_VALUE,B.INSP_FEE, B.BILL_AMOUNT,INVOICE_NO from T22_BILL B where BILL_NO='" + lblBillNo.Text + "'";
					OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
					conn1.Open();
					OracleDataReader reader1 = myOracleCommand3.ExecuteReader();
					int inspfee = 0;
					while (reader1.Read())
					{
						lblTMValue.Text = reader1["MATERIAL_VALUE"].ToString();
						lblTIFee.Text = reader1["INSP_FEE"].ToString();
						lblNetFee.Text = reader1["BILL_AMOUNT"].ToString();
						lblInvoiceNo.Text = reader1["INVOICE_NO"].ToString();
						inspfee = Convert.ToInt32(lblTIFee.Text);
					}
					conn1.Close();
					Label32.Visible = true;
					Label34.Visible = true;
					Label41.Visible = true;
					Label43.Visible = true;
					lblTMValue.Visible = true;
					lblTIFee.Visible = true;
					lblNetFee.Visible = true;
					lblInvoiceNo.Visible = true;
					btnGBill.Text = "Update Bill";
					if (inspfee < 1)
					{
						DisplayAlert("Negative Value BILL!!!");
					}
					conn1.Open();
					string Cnote_bill_dtls = "select NVL(BILL_AMOUNT,0) BILL_AMT,NVL(TDS,0) TDS_AMT,NVL(AMOUNT_RECEIVED,0)AMT_RECEIVED,NVL(RETENTION_MONEY,0) RET_MONEY, NVL(WRITE_OFF_AMT,0) WRITEOFF_AMT from T22_BILL B where BILL_NO='" + txtBillNo.Text + "'";
					OracleCommand cmdCnote_bill_dtls = new OracleCommand(Cnote_bill_dtls, conn1);
					OracleDataReader readerCnote_bill_dtls = cmdCnote_bill_dtls.ExecuteReader();
					double w_bill_amt = 0, w_tds_amt = 0, w_amt_rec = 0, w_ret_amt = 0, w_writeoff_amt = 0;
					while (readerCnote_bill_dtls.Read())
					{
						w_bill_amt = Convert.ToDouble(readerCnote_bill_dtls["BILL_AMT"].ToString());
						w_tds_amt = Convert.ToDouble(readerCnote_bill_dtls["TDS_AMT"].ToString());
						w_amt_rec = Convert.ToDouble(readerCnote_bill_dtls["AMT_RECEIVED"].ToString());
						w_ret_amt = Convert.ToDouble(readerCnote_bill_dtls["RET_MONEY"].ToString());
						w_writeoff_amt = Convert.ToDouble(readerCnote_bill_dtls["WRITEOFF_AMT"].ToString());

					}

					OracleCommand cmdCNoteAmt = new OracleCommand("Select NVL(ABS(sum(NVL(BILL_AMOUNT,0))),0) from T22_BILL WHERE BILL_NO='" + Convert.ToString(cmd.Parameters["OUT_BILL"].Value) + "'", conn1);
					int w_cnote_amt = Convert.ToInt32(cmdCNoteAmt.ExecuteScalar());
					conn1.Close();

					conn1.Open();
					OracleTransaction myTrans = conn1.BeginTransaction();
					try
					{


						OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
						cmd2.Transaction = myTrans;
						string dd = Convert.ToString(cmd2.ExecuteScalar());

						string str_cnote_bill = "Update T22_BILL SET CNOTE_AMOUNT=" + w_cnote_amt + ", BILL_AMT_CLEARED=(" + w_amt_rec + "+" + w_tds_amt + "+" + w_ret_amt + "+" + w_writeoff_amt + "+" + w_cnote_amt + ") where BILL_NO='" + txtBillNo.Text + "'";
						OracleCommand cmd_cnote_bill = new OracleCommand(str_cnote_bill, conn1);
						cmd_cnote_bill.Transaction = myTrans;
						cmd_cnote_bill.ExecuteScalar();

						string str = "Update T22_BILL SET REMARKS='" + txtBRemarks.Text + "',USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + dd + "','dd/mm/yyyy-HH24:MI:SS'), CNOTE_BILL_NO='" + txtBillNo.Text + "' where BILL_NO='" + Convert.ToString(cmd.Parameters["OUT_BILL"].Value) + "'";
						OracleCommand cmd1 = new OracleCommand(str, conn1);
						cmd1.Transaction = myTrans;
						cmd1.ExecuteScalar();

						string strUpdateCnoteAmt = "Update T22_BILL SET AMOUNT_RECEIVED=BILL_AMOUNT, BILL_AMT_CLEARED=BILL_AMOUNT where CNOTE_BILL_NO='" + txtBillNo.Text + "'";
						OracleCommand cmdUpdateCnoteAmt = new OracleCommand(strUpdateCnoteAmt, conn1);
						cmdUpdateCnoteAmt.Transaction = myTrans;
						cmdUpdateCnoteAmt.ExecuteScalar();

						//						string str_ic="Update T30_IC_RECEIVED SET BILL_NO='"+Convert.ToString(cmd.Parameters["OUT_BILL"].Value)+"' where BK_NO='"+txtBKNO.Text+"' and SET_NO='"+txtSetNo.Text+"' and IE_CD="+lblIECD.Text+" and REGION='"+Session["Region"].ToString()+"'";
						//						OracleCommand cmd_ic =new OracleCommand(str_ic,conn1);
						//						cmd_ic.Transaction=myTrans;
						//						cmd_ic.ExecuteScalar();
						myTrans.Commit();
						conn1.Close();
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
						myTrans.Dispose();
					}

					Label48.Visible = true;
					File1.Visible = true;
					btnUpload.Visible = true;
					string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=BILL No:- " + Convert.ToString(cmd.Parameters["OUT_BILL"].Value) + ", Total Material Value:- " + lblTMValue.Text + ", Inspection Fee:- " + String.Format("{0:f2}", Convert.ToDecimal(cmd.Parameters["OUT_FEE"].Value)) + "', 'CustomPopUp', " + "'width=350, height=125, menubar=no, resizable=no,alwaysRaised=true')" + "</script>";
					Page.RegisterStartupScript("PopupScript", popupScript);
					lblBDT.Text = txtBDT.Text.Trim();
					btnUBDT.Visible = true;
					//txtBDT.Enabled=false;

				}
			}
			else
			{
				DisplayAlert("Kindly Enter the Bill No. for which you are creating the Credit Note and click on Verify Button.");
			}


		}

		void gen_bill()
		{
			if (lblBPOCD.Text.Trim() != lstBPO.SelectedValue.Trim())
			{
				try
				{
					conn1.Open();
					string myUpdateQuery = "Update T20_IC set BPO_CD='" + lstBPO.SelectedValue + "' where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + " and CONSIGNEE_CD=" + lstConsignee.SelectedValue;
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn1;
					myUpdateCommand.ExecuteNonQuery();
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


			string myYear1, myMonth1, myDay1;

			myYear1 = txtCertDt.Text.Substring(6, 4);
			myMonth1 = txtCertDt.Text.Substring(3, 2);
			myDay1 = txtCertDt.Text.Substring(0, 2);
			string certdt = myYear1 + myMonth1 + myDay1;
			OracleCommand cmd = null;
			if (Convert.ToInt32(certdt) >= 20170701)
			{
				cmd = new OracleCommand("GENERATE_BILL_GST", conn1);
			}
			else
			{
				cmd = new OracleCommand("GENERATE_BILL", conn1);
			}

			cmd.CommandType = CommandType.StoredProcedure;
			conn1.Open();
			OracleParameter prm1 = new OracleParameter("IN_REGION_CD", System.Data.OracleClient.OracleType.Char);
			prm1.Direction = ParameterDirection.Input;
			prm1.Value = Session["REGION"];
			cmd.Parameters.Add(prm1);

			OracleParameter prm2 = new OracleParameter("IN_CASE_NO", System.Data.OracleClient.OracleType.VarChar);
			prm2.Direction = ParameterDirection.Input;
			prm2.Value = txtCaseNo.Text;
			cmd.Parameters.Add(prm2);

			OracleParameter prm3 = new OracleParameter("IN_CALL_RECV_DT", System.Data.OracleClient.OracleType.Char);
			prm3.Direction = ParameterDirection.Input;
			prm3.Value = Convert.ToString(txtDtOfReciept.Text);
			cmd.Parameters.Add(prm3);

			OracleParameter prm31 = new OracleParameter("IN_CALL_SNO", System.Data.OracleClient.OracleType.Number);
			prm31.Direction = ParameterDirection.Input;
			prm31.Value = Convert.ToInt32(lblCSNO.Text);
			cmd.Parameters.Add(prm31);

			OracleParameter prm4 = new OracleParameter("IN_CONSIGNEE_CD", System.Data.OracleClient.OracleType.Number);
			prm4.Direction = ParameterDirection.Input;
			prm4.Value = lstConsignee.SelectedValue;
			cmd.Parameters.Add(prm4);

			OracleParameter prm5 = new OracleParameter("IN_BILL", System.Data.OracleClient.OracleType.VarChar);
			prm5.Direction = ParameterDirection.Input;
			if (lblBillNo.Visible == true)
			{
				prm5.Value = lblBillNo.Text;

			}
			else
			{
				prm5.Value = "X";
			}
			cmd.Parameters.Add(prm5);


			OracleParameter prm6 = new OracleParameter("IN_FEE_TYPE", System.Data.OracleClient.OracleType.Char);
			prm6.Direction = ParameterDirection.Input;
			prm6.Value = lstBPOFeeType.SelectedValue;
			cmd.Parameters.Add(prm6);

			OracleParameter prm7 = new OracleParameter("IN_FEE", System.Data.OracleClient.OracleType.Number);
			prm7.Direction = ParameterDirection.Input;
			if (lblBPO_TYPE.Text == "R" && lstICType.SelectedValue == "1" && lstRlyBPOFee.Visible == true)
			{
				prm7.Value = lstRlyBPOFee.SelectedValue;
			}
			else
			{
				prm7.Value = txtBPOFee.Text;
			}
			cmd.Parameters.Add(prm7);
			if (Convert.ToInt32(certdt) >= 20170701)
			{
				OracleParameter prm8 = new OracleParameter("IN_TAX_TYPE", System.Data.OracleClient.OracleType.Char);
				prm8.Direction = ParameterDirection.Input;
				prm8.Value = lstBPOTaxType_GST.SelectedValue;
				cmd.Parameters.Add(prm8);
			}
			else
			{
				OracleParameter prm8 = new OracleParameter("IN_TAX_TYPE", System.Data.OracleClient.OracleType.Char);
				prm8.Direction = ParameterDirection.Input;
				prm8.Value = lstBPOTaxType.SelectedValue;
				cmd.Parameters.Add(prm8);
			}

			OracleParameter prm9 = new OracleParameter("IN_NO_OF_INSP", System.Data.OracleClient.OracleType.Number);
			prm9.Direction = ParameterDirection.Input;
			if (txtNofIns.Text == "")
			{
				prm9.Value = 1;
			}
			else
			{
				prm9.Value = txtNofIns.Text;
			}
			cmd.Parameters.Add(prm9);

			OracleParameter prm91 = new OracleParameter("IN_MAX_FEE", System.Data.OracleClient.OracleType.Number);
			prm91.Direction = ParameterDirection.Input;
			if (txtMaxFeeAllow.Text.Trim() == "")
			{
				prm91.Value = -1; //In Case OF MAXM FEE is NULL
			}
			else
			{
				prm91.Value = Convert.ToInt32(txtMaxFeeAllow.Text);
			}
			cmd.Parameters.Add(prm91);

			OracleParameter prm92 = new OracleParameter("IN_MIN_FEE", System.Data.OracleClient.OracleType.Number);
			prm92.Direction = ParameterDirection.Input;
			if (txtMinFeeAllow.Text.Trim() == "")
			{
				prm92.Value = 0;
			}
			else
			{
				prm92.Value = Convert.ToInt32(txtMinFeeAllow.Text);
			}
			cmd.Parameters.Add(prm92);

			OracleParameter prm93 = new OracleParameter("IN_BILL_DT", OracleDbType.Varchar2, 8);
			prm93.Direction = ParameterDirection.Input;
			prm93.Value = Convert.ToString(txtBDT.Text.Replace("/", ""));
			cmd.Parameters.Add(prm93);


			OracleParameter prm94 = new OracleParameter("IN_ADV_BILL", OracleDbType.Char, 1);
			prm94.Direction = ParameterDirection.Input;
			if (chkABill.Checked == true)
			{
				prm94.Value = "A";
			}
			else
			{
				prm94.Value = "X";
			}
			cmd.Parameters.Add(prm94);
			if (Convert.ToInt32(certdt) >= 20170701)
			{
				OracleParameter prm95 = new OracleParameter("IN_INVOICE", System.Data.OracleClient.OracleType.VarChar);
				prm95.Direction = ParameterDirection.Input;
				if (lblInvoiceNo.Text.Trim() == "" || lblInvoiceNo.Text.Trim().Length < 13)
				{
					if (Session["REGION"].ToString() == "N")
					{
						prm95.Value = "0708";
					}
					else if (Session["REGION"].ToString() == "W")
					{
						prm95.Value = "2705";
					}
					else if (Session["REGION"].ToString() == "E")
					{
						prm95.Value = "1906";
					}
					else if (Session["REGION"].ToString() == "S")
					{
						prm95.Value = "3307";
					}
					else if (Session["REGION"].ToString() == "C")
					{
						prm95.Value = "2210";
					}
					else if (Session["REGION"].ToString() == "Q")
					{
						//prm95.Value = "0601";
						prm95.Value = "0708";
					}

				}
				else
				{
					prm95.Value = lblInvoiceNo.Text.Trim();
				}
				cmd.Parameters.Add(prm95);
			}

			OracleParameter prm10 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32, 1);
			prm10.Direction = ParameterDirection.Output;
			cmd.Parameters.Add(prm10);

			OracleParameter prm11 = new OracleParameter("OUT_BILL", OracleDbType.Varchar2, 20);
			prm11.Direction = ParameterDirection.Output;
			cmd.Parameters.Add(prm11);

			OracleParameter prm12 = new OracleParameter("OUT_FEE", OracleDbType.Int32, 15);
			prm12.Direction = ParameterDirection.Output;
			cmd.Parameters.Add(prm12);

			cmd.ExecuteNonQuery();
			conn1.Close();


			if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
			{
				DisplayAlert("Fee Details not available.");
			}
			else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -2)
			{
				DisplayAlert("MINIMUM FEE PAYBLE IS GREATER THEN MAXIMUM FEE");
			}
			else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -3)
			{
				DisplayAlert("Unable to access Bill Master.");
			}
			else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -4)
			{
				DisplayAlert("Unable to Insert New Bill No. in Bill Master.");
			}
			else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -5)
			{
				DisplayAlert("Invalid Bill No. Passed as Parameter.");
			}
			else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -6)
			{
				DisplayAlert("Unable to Insert Bill Details.");
			}
			else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -7)
			{
				DisplayAlert("Error occured during updating Fee Details in Bill Master.");
			}
			else if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -8)
			{
				if (Convert.ToInt32(certdt) >= 20170701)
				{
					DisplayAlert("Unable to Select GST Tax Rates");
				}
				else
				{
					DisplayAlert("Unable to Select Service Tax Rates");

				}
			}
			else
			{
				Label24.Visible = true;
				lblBillNo.Visible = true;
				lblBillNo.Text = Convert.ToString(cmd.Parameters["OUT_BILL"].Value);

				string str3 = "select B.MATERIAL_VALUE,B.INSP_FEE, B.BILL_AMOUNT,INVOICE_NO from T22_BILL B where BILL_NO='" + lblBillNo.Text + "'";
				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader1 = myOracleCommand3.ExecuteReader();
				int inspfee = 0;
				while (reader1.Read())
				{
					lblTMValue.Text = reader1["MATERIAL_VALUE"].ToString();
					lblTIFee.Text = reader1["INSP_FEE"].ToString();
					lblNetFee.Text = reader1["BILL_AMOUNT"].ToString();
					lblInvoiceNo.Text = reader1["INVOICE_NO"].ToString();
					inspfee = Convert.ToInt32(lblTIFee.Text);
				}
				conn1.Close();
				Label32.Visible = true;
				Label34.Visible = true;
				Label41.Visible = true;
				Label43.Visible = true;
				lblTMValue.Visible = true;
				lblTIFee.Visible = true;
				lblNetFee.Visible = true;
				lblInvoiceNo.Visible = true;
				btnGBill.Text = "Update Bill";
				if (inspfee < 1)
				{
					DisplayAlert("Zero Value BILL!!!");
				}
				conn1.Open();
				OracleTransaction myTrans = conn1.BeginTransaction();
				try
				{
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					cmd2.Transaction = myTrans;
					string dd = Convert.ToString(cmd2.ExecuteScalar());


					string str = "Update T22_BILL SET REMARKS='" + txtBRemarks.Text + "',USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + dd + "','dd/mm/yyyy-HH24:MI:SS') where BILL_NO='" + Convert.ToString(cmd.Parameters["OUT_BILL"].Value) + "'";
					OracleCommand cmd1 = new OracleCommand(str, conn1);
					cmd1.Transaction = myTrans;
					cmd1.ExecuteScalar();

					string str_ic = "Update T30_IC_RECEIVED SET BILL_NO='" + Convert.ToString(cmd.Parameters["OUT_BILL"].Value) + "' where BK_NO='" + txtBKNO.Text + "' and SET_NO='" + txtSetNo.Text + "' and IE_CD=" + lblIECD.Text + " and REGION='" + Session["Region"].ToString() + "'";
					OracleCommand cmd_ic = new OracleCommand(str_ic, conn1);
					cmd_ic.Transaction = myTrans;
					cmd_ic.ExecuteScalar();
					myTrans.Commit();
					conn1.Close();
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
					myTrans.Dispose();
				}
				Label48.Visible = true;
				File1.Visible = true;
				btnUpload.Visible = true;

				string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=BILL No:- " + Convert.ToString(cmd.Parameters["OUT_BILL"].Value) + ", Total Material Value:- " + lblTMValue.Text + ", Inspection Fee:- " + String.Format("{0:f2}", Convert.ToDecimal(cmd.Parameters["OUT_FEE"].Value)) + "', 'CustomPopUp', " + "'width=350, height=125, menubar=no, resizable=no,alwaysRaised=true')" + "</script>";
				Page.RegisterStartupScript("PopupScript", popupScript);
				lblBDT.Text = txtBDT.Text.Trim();
				btnUBDT.Visible = true;
				//txtBDT.Enabled=false;

			}

		}
		protected void lstBPOFeeType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//			if(lstBPOFeeType.SelectedValue=="L")
			//			{
			//				txtMaxFeeAllow.Text="";
			//				txtMaxFeeAllow.Enabled=false;
			//				txtMinFeeAllow.Text="";
			//				txtMinFeeAllow.Enabled=false;
			//			}
			//			else
			//			{
			//				txtMaxFeeAllow.Enabled=true;
			//				txtMinFeeAllow.Enabled=true;
			//			}
		}
		int fill_BPO(string bpo)
		{
			lstBPO.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "";

			str1 = "select B.BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME, B.BPO_TYPE, B.AU from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD= C.CITY_CD and (trim(upper(BPO_CD))=upper('" + bpo + "') or trim(upper(BPO_NAME)) LIKE upper('" + bpo + "%')) ORDER BY (B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY)";

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
					lblBPO_TYPE.Text = dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString();
					lblAU.Text = dsP.Tables[0].Rows[i]["AU"].ToString();
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

		protected void lstBPO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtBPO.Text = lstBPO.SelectedValue;
			rbs.SetFocus(btnGBill);
		}

		protected void btnUBDT_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleCommand cmd11 = new OracleCommand("Select to_char(sysdate,'yyyymmdd') from dual", conn1);
			string sdate = Convert.ToString(cmd11.ExecuteScalar());
			conn1.Close();

			string myYear, myMonth, myDay;

			myYear = txtBDT.Text.Substring(6, 4);
			myMonth = txtBDT.Text.Substring(3, 2);
			myDay = txtBDT.Text.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;
			int i = dt1.CompareTo(sdate);
			if (i > 0)
			{
				DisplayAlert("Bill Date Cannot be greater then Current Date!!!");
			}
			else
			{
				int oldMonth = Convert.ToInt32(lblBDT.Text.Substring(3, 2));
				string frm = "", to = "";
				if (oldMonth >= 4)
				{
					frm = lblBDT.Text.Substring(6, 4) + "04";
					to = Convert.ToString(Convert.ToInt32(lblBDT.Text.Substring(6, 4)) + 1) + "03";
				}
				else
				{
					frm = Convert.ToString(Convert.ToInt32(lblBDT.Text.Substring(6, 4)) - 1) + "04";
					to = lblBDT.Text.Substring(6, 4) + "03";

				}

				string newdt = txtBDT.Text.Substring(6, 4) + txtBDT.Text.Substring(3, 2);
				if (chk_bill_dt() == 1)
				{
					if (Convert.ToInt32(newdt) >= Convert.ToInt32(frm) && Convert.ToInt32(newdt) <= Convert.ToInt32(to))
					{
						try
						{
							string str = "Update T22_BILL SET BILL_DT=to_date('" + txtBDT.Text + "','dd/mm/yyyy') where BILL_NO='" + lblBillNo.Text.Trim() + "'";
							OracleCommand cmd1 = new OracleCommand(str, conn1);
							conn1.Open();
							cmd1.ExecuteScalar();
							conn1.Close();
							lblBDT.Text = txtBDT.Text.Trim();
							DisplayAlert("Bill Date Has Modified!!!");
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
					else
					{
						//txtBDT.Text=lblBDT.Text;
						DisplayAlert("The Date You are Modifing should lie in the same financial year!!!");
					}
				}
				else
				{
					DisplayAlert("Old Bill Date is not allowed!!!");
				}
			}
		}
		public void fill_IRFC_BPO()
		{

			try
			{
				//conn1.Open();
				ddlIRFCBPO.Items.Clear();
				DataSet dsP = new DataSet();
				string str1;
				str1 = "select BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO_NAME from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and BPO_TYPE='R' and upper(trim(BPO_RLY))=upper(trim('IRFC')) ORDER BY B.BPO_NAME";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["BPO_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
					ddlIRFCBPO.Items.Add(lst);
				}
				ddlIRFCBPO.Items.Insert(0, "");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			//			finally
			//			{
			//				conn1.Close(); 
			//			}
		}
		protected void btnSave2_Click(object sender, System.EventArgs e)
		{
			string err_srno = "";
			int i = 0;
			foreach (DataGridItem di in grdCDetails_1.Items)
			{
				// Make sure this is an item and not the header or footer.

				decimal qty_pass = 0;
				int err = 0;
				int srno = 0;
				if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
				{
					// Get the current row for update or delete operations later.
					//					DataRow dr = _dsContacts.Tables["Contact"].Rows.Find(grdCDetails_1.DataKeys[di.ItemIndex]);

					// See if this one needs to be deleted.

					// Update the row instead.
					qty_pass = Convert.ToDecimal(((TextBox)di.FindControl("txtQTYPASS")).Text);
					decimal qoff = Convert.ToDecimal(di.Cells[6].Text);
					srno = Convert.ToInt16(di.Cells[0].Text);
					//					OracleCommand cmd =new OracleCommand("Select NVL(sum(NVL(D.QTY_PASSED,0)),0) from T17_CALL_REGISTER R,T18_CALL_DETAILS D where R.CASE_NO=D.CASE_NO and R.CALL_RECV_DT=D.CALL_RECV_DT and R.CALL_SNO=D.CALL_SNO and R.CASE_NO= '" + txtCaseNo.Text + "' AND D.ITEM_SRNO_PO=" + srno + " and R.CALL_STATUS not in('R','C') AND (D.ROWID!=(Select ROWID from T18_CALL_DETAILS g where g.CASE_NO='"+txtCaseNo.Text+"' and g.CALL_RECV_DT=to_date('"+txtDtOfReciept.Text+"','dd/mm/yyyy') and g.CALL_SNO="+lblCSNO.Text+" AND g.ITEM_SRNO_PO="+srno+"))",conn1);
					//					conn1.Open();
					//					decimal tpqty= Convert.ToDecimal(cmd.ExecuteScalar());
					//					conn1.Close();
					//					tpqty=tpqty+qty_pass;
					err = 0;
					if (qty_pass > qoff)
					{
						err = 1;
						if (i == 0)
						{
							err_srno = srno.ToString();
						}
						else
						{
							err_srno = err_srno + ", " + srno.ToString();
						}
						i = i + 1;
					}

					if (err == 0)
					{
						conn1.Open();
						OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
						string ss1 = Convert.ToString(cmd2.ExecuteScalar());
						string myUpdateQuery = "Update T18_CALL_DETAILS set QTY_PASSED=" + qty_pass + ",USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss1 + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text.Trim() + " and ITEM_SRNO_PO=" + srno;
						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
						myUpdateCommand.Connection = conn1;
						myUpdateCommand.ExecuteNonQuery();
						conn1.Close();
					}

				}
			}
			btnCancel.Visible = true;
			btnSave.Visible = true;
			if (lblSTS.Text == "X")
			{
				btnGBill.Visible = false;
				btnSave.Visible = false;
				btnDelete.Enabled = false;
			}
			else
			{
				btnGBill.Visible = true;
			}
			grdCDetails_1.Visible = false;
			btnSave2.Visible = false;
			btnCancel2.Visible = false;
			btnShow.Visible = true;
			fillgrid1();
			if (i > 0)
			{
				DisplayAlert("QTY PASSED SHOULD NOT BE GREATER THEN QTY OFF NOW For ITEM_SRNO:- " + err_srno);
			}
		}

		protected void btnShow_Click(object sender, System.EventArgs e)
		{
			grdCDetails.Visible = false;
			btnShow.Visible = false;
			grdCDetails_1.Visible = true;
			btnSave2.Visible = true;
			btnCancel2.Visible = true;
		}

		protected void btnCancel2_Click(object sender, System.EventArgs e)
		{
			fillgrid1();
		}

		protected void btnMRDT_Click(object sender, System.EventArgs e)
		{
			if (Convert.ToString(Request.Params["Action"]) == "M")
			{
				conn1.Open();
				OracleCommand cmd11 = new OracleCommand("Select to_char(DT_INSP_DESIRE,'dd/mm/yyyy') from T17_CALL_REGISTER where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text, conn1);
				string mat_read_dt = Convert.ToString(cmd11.ExecuteScalar());
				conn1.Close();
				if (mat_read_dt == "")
				{
					DisplayAlert("Material Readiness Date in the Call is Missing, Kindly Update it in the Call before using this option!!!");
				}
				else
				{
					string myYear, myMonth, myDay;
					myYear = txtFIDT.Text.Substring(6, 4);
					myMonth = txtFIDT.Text.Substring(3, 2);
					myDay = txtFIDT.Text.Substring(0, 2);
					string dt = myYear + myMonth + myDay;

					string myYear1, myMonth1, myDay1;
					myYear1 = mat_read_dt.Substring(6, 4);
					myMonth1 = mat_read_dt.Substring(3, 2);
					myDay1 = mat_read_dt.Substring(0, 2);
					string dt1 = myYear1 + myMonth1 + myDay1;
					int i = dt1.CompareTo(dt);
					if (i > 0)
					{
						DisplayAlert("Call/Material Readiness Date Cannot be greater then First Inspection Date!!!");
					}
					else
					{
						txtCDate.Text = mat_read_dt;
					}
				}
			}

		}

		protected void lstStampPatternCD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstStampPatternCD.SelectedValue == "O")
			{
				txtPattern.Visible = true;
			}
			else
			{
				txtPattern.Visible = false;
			}
		}

		protected void btnGSTNoUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				string myUpdateQuery = "";

				if (rdbConsignee.Checked == true)
				{
					myUpdateQuery = "Update T06_CONSIGNEE set GSTIN_NO=upper('" + txtGSTINNo.Text.Trim() + "'),LEGAL_NAME=upper('" + txtLegalName.Text.Trim() + "'),USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CONSIGNEE_CD= " + lstConsignee.SelectedValue;
				}
				else if (rdbBPO.Checked == true)
				{
					myUpdateQuery = "Update T12_BILL_PAYING_OFFICER set GSTIN_NO=upper('" + txtGSTINNo.Text.Trim() + "'),LEGAL_NAME=upper('" + txtLegalName.Text.Trim() + "'),USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where BPO_CD= '" + lblBPOCD.Text + "'";
				}
				OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
				myUpdateCommand.Connection = conn1;
				conn1.Open();
				myUpdateCommand.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("GSTIN NO. & LEGAL NAME HAS BEEN UPDATED!!!");
				txtGSTINNo.Enabled = false;
				btnGSTNoUpdate.Visible = false;
				txtGSTINNo.Text = txtGSTINNo.Text.ToUpper();

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

		protected void rdbConsignee_CheckedChanged(object sender, System.EventArgs e)
		{
			getconsignee_gstno();
		}

		protected void btnVerify_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleCommand cmd11 = new OracleCommand("Select CASE_NO from T22_BILL where BILL_NO= '" + txtBillNo.Text + "'", conn1);
			string cs_no = Convert.ToString(cmd11.ExecuteScalar());
			conn1.Close();

			if (cs_no == txtCaseNo.Text)
			{
				btnVerify.Visible = false;
				txtBillNo.Enabled = false;
			}
			else
			{
				DisplayAlert("Invalid Bill No. This Bill No. does not belong to this PO");
			}
		}

		protected void lstICType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstICType.SelectedValue == "9")
			{
				txtBillNo.Visible = true;
				btnVerify.Visible = true;
				lblCNote_BNO.Visible = true;

			}
			else
			{
				txtBillNo.Visible = false;
				btnVerify.Visible = false;
				lblCNote_BNO.Visible = false;
			}

			if (lstICType.SelectedValue != "1")
			{
				lstRlyBPOFee.Visible = false;
				txtBPOFee.Visible = true;
			}
			else
			{
				txtBPOFee.Visible = true;
				lstRlyBPOFee.Visible = false;
			}
		}

		protected void ddlIRFCBPO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			get_irfc_bpo_gst_detail();
		}
		void get_irfc_bpo_gst_detail()
		{
			try
			{

				conn1.Open();
				//OracleCommand cmd1 =new OracleCommand("select GSTIN_NO,LEGAL_NAME from T12_BILL_PAYING_OFFICER where BPO_CD='"+ddlIRFCBPO.SelectedValue+"'",conn1);
				OracleCommand cmd1 = new OracleCommand("select NVL(GSTIN_NO,'X') GSTIN_NO,LEGAL_NAME,T12.PIN_CODE,T03.CITY,lpad(T92.STATE_CD,2,'0')||'-'||T92.STATE_NAME STATE from T12_BILL_PAYING_OFFICER T12,T03_CITY T03,T92_STATE T92 WHERE T12.BPO_CITY_CD=T03.CITY_CD AND T03.STATE_CD=T92.STATE_CD(+) AND BPO_CD='" + ddlIRFCBPO.SelectedValue + "'", conn1);
				OracleDataReader reader1 = cmd1.ExecuteReader();
				while (reader1.Read())
				{
					//					txtGSTINNo.Text=reader1["GSTIN_NO"].ToString();
					//					txtLegalName.Text=reader1["LEGAL_NAME"].ToString();



					if (reader1["GSTIN_NO"].ToString() == "X")
					{
						txtGSTINNo.Enabled = true;
						btnGSTNoUpdate.Visible = true;
						txtGSTINNo.Text = "";

					}
					else
					{
						if (reader1["LEGAL_NAME"].ToString() == "")
						{
							txtLegalName.Text = "";
							txtLegalName.Visible = true;


						}
						else
						{
							txtLegalName.Text = reader1["LEGAL_NAME"].ToString();
							txtLegalName.Visible = true;
						}
						txtGSTINNo.Text = reader1["GSTIN_NO"].ToString();
						lblCity.Text = "City: " + reader1["CITY"].ToString();
						lblState.Text = "State: " + reader1["STATE"].ToString();
						lblStateCD.Text = reader1["STATE"].ToString();
						lblPin.Text = "PIN: " + reader1["PIN_CODE"].ToString();
						txtGSTINNo.Enabled = false;
						btnGSTNoUpdate.Visible = true;
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
		}
		protected void ddlIRFC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ddlIRFC.SelectedValue == "Y")
			{
				ddlIRFC.SelectedValue = "Y";
				lblIRFCBPO.Visible = true;
				ddlIRFCBPO.Visible = true;
				rdbConsignee.Enabled = false;
				rdbBPO.Enabled = false;
				btnGSTNoUpdate.Enabled = false;
				fill_IRFC_BPO();
				rdbConsignee.Checked = false;
				rdbBPO.Checked = false;

			}
			else if (ddlIRFC.SelectedValue == "N")
			{
				ddlIRFC.SelectedValue = "N";
				lblIRFCBPO.Visible = false;
				ddlIRFCBPO.Visible = false;
				rdbConsignee.Enabled = true;
				rdbBPO.Enabled = true;
				btnGSTNoUpdate.Enabled = true;
				ddlIRFCBPO.Items.Clear();
			}
		}

		protected void btnReturnBill_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleCommand cmd3 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string dd = Convert.ToString(cmd3.ExecuteScalar());
			string return_bill = "";
			OracleCommand cmd1 = new OracleCommand("select BILL_NO from RITES_BILL_DTLS where BILL_NO='" + lblBillNo.Text + "' and RETURN_DATE IS NOT NULL and CO6_STATUS='R'", conn1);
			return_bill = Convert.ToString(cmd1.ExecuteScalar());
			OracleCommand cmd11 = new OracleCommand("select max(BILL_RESENT_COUNT) from RITES_BILL_DTLS where BILL_NO='" + lblBillNo.Text + "' and RETURN_DATE IS NOT NULL and CO6_STATUS='R'", conn1);
			int return_bill_resent_cris = Convert.ToInt32(cmd11.ExecuteScalar());
			OracleCommand cmd111 = new OracleCommand("select NVL(BILL_RESENT_COUNT,0) from V22_BILL where BILL_NO='" + lblBillNo.Text + "'", conn1);
			int return_bill_resent_ibs = Convert.ToInt32(cmd111.ExecuteScalar());
			if (return_bill != "" && return_bill_resent_cris == return_bill_resent_ibs)
			{
				string str = "Update T22_BILL SET BILL_RESENT_STATUS='R',REMARKS='" + txtBRemarks.Text.Trim() + "',USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + dd + "','dd/mm/yyyy-HH24:MI:SS') where BILL_NO='" + lblBillNo.Text + "'";
				OracleCommand cmd2 = new OracleCommand(str, conn1);
				cmd2.ExecuteScalar();
				DisplayAlert("Your Record is updated");
			}
			else
			{
				DisplayAlert("This bill is not returned from railways");
			}
			conn1.Close();
		}

		protected void btnUpload_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
				{
					String fn = "", fx = "";
					fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper();
					if (fx == ".PDF")
					{
						String SaveLocation = null;
						SaveLocation = Server.MapPath("INVOICE_SUPP_DOCS/" + lblBillNo.Text + ".pdf");
						//SaveLocation = Server.MapPath("PO/" + fn);
						//SaveLocation = "//172.16.7.76/madan/"+fn;
						File1.PostedFile.SaveAs(SaveLocation);
						DisplayAlert("The file has been uploaded.");
						conn1.Open();
						string str = "Update T22_BILL SET INVOICE_SUPP_DOCS='Y' where BILL_NO='" + lblBillNo.Text + "'";
						OracleCommand cmd2 = new OracleCommand(str, conn1);
						cmd2.ExecuteScalar();
						conn1.Close();
					}
					else
					{ DisplayAlert("Only pdf files are accepted."); }
				}
				else
				{
					DisplayAlert("Please select a file to upload.");
				}
			}
			catch (FileNotFoundException fe)
			{ Response.Write("File not found" + fe); }
			catch (System.IO.DirectoryNotFoundException de)
			{ Response.Write("Directry not found" + de); }
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				Response.Write(ex);
			}
		}






	}
}