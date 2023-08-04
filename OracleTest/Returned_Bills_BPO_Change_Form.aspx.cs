using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Returned_Bills_BPO_Change_Form
{
	public partial class Returned_Bills_BPO_Change_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string BKNO, SNO;
		int ecode = 0;

		void fill_ic_details()
		{
			try
			{
				string str3 = "select I.CASE_NO,(I.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME,(NVL2(I.BPO_CD,I.BPO_CD||'-'||(B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(E.LOCATION,E.CITY||'/'||E.LOCATION,E.CITY)),'')) BPO_NAME,I.BK_NO,I.SET_NO,I.BILL_NO,I.BPO_CD, A.RLY_CD||'-'||A.AU||'/'||A.AUDESC||'/'||A.ADDRESS AU_DESC, NVL(I.IRFC_FUNDED,'N') IRFC_FUNDED, NVL(I.ACC_GROUP,'X') ACC_GROUP, I.IRFC_BPO_CD, I.RECIPIENT_GSTIN_NO from T20_IC I,T06_CONSIGNEE C, T12_BILL_PAYING_OFFICER B,T03_CITY D ,T03_CITY E, AU_CRIS A where I.CONSIGNEE_CD=C.CONSIGNEE_CD AND I.BPO_CD=B.BPO_CD AND B.AU=A.AU AND C.CONSIGNEE_CITY=D.CITY_CD AND B.BPO_CITY_CD=E.CITY_CD and I.BK_NO= '" + BKNO + "' and I.SET_NO='" + SNO + "' and substr(I.CASE_NO,1,1)='" + Session["Region"] + "'";
				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader = myOracleCommand3.ExecuteReader();
				if (reader.HasRows == false)
				{
					throw new System.Exception("Record not found for the given Book No. and Set No. !!! ");
				}
				else
				{
					while (reader.Read())
					{
						lblCaseNo.Text = reader["CASE_NO"].ToString();
						lblBPO.Text = reader["BPO_NAME"].ToString();
						lblConsignee.Text = reader["CONSIGNEE_NAME"].ToString();
						lblBKNO.Text = reader["BK_NO"].ToString();
						lblSetNo.Text = reader["SET_NO"].ToString();
						lblBillNo.Text = reader["BILL_NO"].ToString();
						lblOldBPO_CD.Text = reader["BPO_CD"].ToString();
						lblOldAU.Text = reader["AU_DESC"].ToString();
						lstIRFC.SelectedValue = reader["IRFC_FUNDED"].ToString();
						lblIRFC.Text = reader["IRFC_FUNDED"].ToString();
						if (reader["IRFC_FUNDED"].ToString() == "N")
						{
							if (reader["ACC_GROUP"].ToString() == "Z007")
							{
								rdbConsignee.Checked = true;
							}
							else if (reader["ACC_GROUP"].ToString() == "Z006")
							{
								rdbBPO.Checked = true;
							}

						}
						else
						{
							rdbIRFC.Checked = true;
							fill_IRFC_BPO();
							ddlIRFCBPO.SelectedValue = reader["IRFC_BPO_CD"].ToString();
							lblOldIRFCBPOCd.Text = reader["IRFC_BPO_CD"].ToString();
							lblIRFC_BPO.Visible = true;
							rdbIRFC.Checked = true;
							fill_BPO(lblOldBPO_CD.Text);
							lstIRFC.SelectedValue = "Y";
						}
						lblOldAccGroup.Text = reader["ACC_GROUP"].ToString();
						lblOldRecGSTIN_NO.Text = reader["RECIPIENT_GSTIN_NO"].ToString();
						lblGST_NO.Text = reader["RECIPIENT_GSTIN_NO"].ToString();

					}
					reader.Close();
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
				ddlIRFCBPO.Visible = true;
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
		//		public void fill_ConsigneeCd_PO()
		//		{
		//			try
		//			{
		//				lstConsignee.Items.Clear();
		//				DataSet dsP = new DataSet();
		//				string str1;
		//				//str1 = "select P.CONSIGNEE_CD,(trim(C.CONSIGNEE_DESIG)||'/'||trim(C.CONSIGNEE_DEPT)||'/'||trim(C.CONSIGNEE_FIRM)) CONSIGNEE_NAME from T06_CONSIGNEE C,T18_CALL_DETAILS P WHERE P.CONSIGNEE_CD=C.CONSIGNEE_CD and CASE_NO='"+ txtCaseNo.Text +"' and CALL_RECV_DT=TO_DATE('"+txtDtOfReciept.Text+"','dd/mm/yyyy')ORDER BY CONSIGNEE_DESIG"; 
		//				str1="Select P.CONSIGNEE_CD,(C.CONSIGNEE_CD||'-'||nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||NVL2(trim(C.CONSIGNEE_ADD1),trim(C.CONSIGNEE_ADD1)||'/','')||NVL2(trim(D.LOCATION),trim(D.LOCATION)||' : '||trim(D.CITY),trim(D.CITY))) CONSIGNEE_NAME from T14_PO_BPO P,t06_consignee C,T03_CITY D where P.CONSIGNEE_CD=C.CONSIGNEE_CD and C.CONSIGNEE_CITY=D.CITY_CD AND P.CASE_NO='"+ lblCaseNo.Text +"'";
		//				//str1="Select C.CONSIGNEE_CD,trim(C.CONSIGNEE_DESIG)||'/'||trim(C.CONSIGNEE_DEPT)||'/'||trim(C.CONSIGNEE_FIRM||'/'||D.CITY) CONSIGNEE_NAME from t06_consignee C,T03_CITY D where C.CONSIGNEE_CITY=D.CITY_CD AND CONSIGNEE_CD in (select distinct CONSIGNEE_CD from T18_CALL_DETAILS WHERE CASE_NO='"+ txtCaseNo.Text +"')";
		//				OracleDataAdapter da = new OracleDataAdapter(str1, conn1); 
		//				OracleCommand myOracleCommand = new OracleCommand(str1, conn1); 
		//				ListItem lst; 
		//				conn1.Open();
		//				da.SelectCommand = myOracleCommand; 
		//				da.Fill(dsP, "Table"); 
		//				if(dsP.Tables[0].Rows.Count==0)
		//				{
		//					throw new Exception("Their is no details Present for this Case No and Call Recieve Date in CALL DETAILS TABLE !!!");
		//				}
		//				else
		//				{
		//					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++) 
		//					{ 
		//						lst = new ListItem(); 
		//						lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString(); 
		//						lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
		//						lstConsignee.Items.Add(lst); 
		//					}
		//				}
		//				conn1.Close();
		//			}
		//			catch(Exception ex)
		//			{
		//				string str;
		//				str = ex.Message;
		//				string str1=str.Replace("\n","");
		//				Response.Redirect(("Error_Form.aspx?err=" + str1));
		//			}
		//		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:conformation();");
			if (Convert.ToString(Request.Params["BK_NO"]) != "")
			{

				BKNO = Request.Params["BK_NO"].ToString();
				SNO = Request.Params["SET_NO"].ToString();

			}
			if (!(IsPostBack))
			{
				fill_ic_details();
				//				fill_ConsigneeCd_PO();
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select NVL(BILL_NO,'X') FROM RITES_BILL_DTLS WHERE BK_NO= '" + BKNO + "' and SET_NO='" + SNO + "' and REGION_CODE='" + Session["Region"] + "' AND CO6_STATUS='R'", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				if (ss == "")
				{
					btnSave.Visible = false;
					lblMessage.Visible = true;
				}
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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			string NewAU = "";
			if (rdbConsignee.Checked == true)
			{
				NewAU = "Z007";

			}
			else if (rdbBPO.Checked == true)
			{
				NewAU = "Z006";
			}
			else if (rdbIRFC.Checked == true)
			{
				NewAU = "";
			}
			string NewIRFCBpo = "";
			if (rdbIRFC.Checked == true)
			{
				NewIRFCBpo = ddlIRFCBPO.SelectedValue;
			}

			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{
				if (txtBPO.Text.Trim() != "" && lblOldRecGSTIN_NO.Text.Trim().ToUpper().Equals(lblGST_NO.Text.Trim().ToUpper()) == true)
				{
					string myInsertQuery = "INSERT INTO RETURNED_BILLS_BPO_CHANGE(BILL_NO,OLD_BPO_CD,NEW_BPO_CD,USER_ID,DATETIME,OLD_ACC_GROUP,NEW_ACC_GROUP,OLD_IRFC_BPO_CD,NEW_IRFC_BPO_CD,OLD_RECIPIENT_GSTIN_NO,NEW_RECIPIENT_GSTIN_NO) values('" + lblBillNo.Text.Trim() + "','" + lblOldBPO_CD.Text.Trim() + "' ,'" + txtBPO.Text.Trim() + "','" + Session["Uname"] + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + lblOldAccGroup.Text + "','" + NewAU + "','" + lblOldIRFCBPOCd.Text + "','" + NewIRFCBpo + "','" + lblOldRecGSTIN_NO.Text + "','" + lblGST_NO.Text + "')";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					myInsertCommand.Transaction = myTrans;
					myInsertCommand.ExecuteNonQuery();
					string updateQuery = "";
					if (lblOldAccGroup.Text == "Z007" && NewAU == "Z007")
					{
						updateQuery = "update T20_IC set BPO_CD='" + lstBPO.SelectedValue + "' where BK_NO= '" + BKNO + "' and SET_NO='" + SNO + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "' and BILL_NO='" + lblBillNo.Text.Trim() + "'";
					}
					else if (lblOldAccGroup.Text == "Z006" && NewAU == "Z006")
					{
						//updateQuery="update T20_IC set BPO_CD='"+lstBPO.SelectedValue+"',RECIPIENT_GSTIN_NO='"+lblGST_NO.Text.Trim()+"' where BK_NO= '" + BKNO + "' and SET_NO='"+SNO+"' and substr(CASE_NO,1,1)='"+Session["Region"]+"' and BILL_NO='"+lblBillNo.Text.Trim()+"'";
						updateQuery = "update T20_IC set BPO_CD='" + lstBPO.SelectedValue + "' where BK_NO= '" + BKNO + "' and SET_NO='" + SNO + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "' and BILL_NO='" + lblBillNo.Text.Trim() + "'";
					}
					else if ((lblOldAccGroup.Text == "Z006" && NewAU == "") || (lblOldAccGroup.Text == "Z007" && NewAU == ""))
					{
						//updateQuery="update T20_IC set BPO_CD='"+lstBPO.SelectedValue+"',RECIPIENT_GSTIN_NO='"+lblGST_NO.Text.Trim()+"', ACC_GROUP='"+NewAU+"', IRFC_BPO_CD='"+ddlIRFCBPO.SelectedValue+"', IRFC_FUNDED='Y' where BK_NO= '" + BKNO + "' and SET_NO='"+SNO+"' and substr(CASE_NO,1,1)='"+Session["Region"]+"' and BILL_NO='"+lblBillNo.Text.Trim()+"'";
						updateQuery = "update T20_IC set BPO_CD='" + lstBPO.SelectedValue + "', ACC_GROUP='" + NewAU + "', IRFC_BPO_CD='" + ddlIRFCBPO.SelectedValue + "', IRFC_FUNDED='Y' where BK_NO= '" + BKNO + "' and SET_NO='" + SNO + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "' and BILL_NO='" + lblBillNo.Text.Trim() + "'";
					}
					else if (lblOldAccGroup.Text == "X" && NewAU == "")
					{
						//updateQuery="update T20_IC set BPO_CD='"+lstBPO.SelectedValue+"',RECIPIENT_GSTIN_NO='"+lblGST_NO.Text.Trim()+"', IRFC_BPO_CD='"+ddlIRFCBPO.SelectedValue+"' where BK_NO= '" + BKNO + "' and SET_NO='"+SNO+"' and substr(CASE_NO,1,1)='"+Session["Region"]+"' and BILL_NO='"+lblBillNo.Text.Trim()+"'";
						updateQuery = "update T20_IC set BPO_CD='" + lstBPO.SelectedValue + "',IRFC_BPO_CD='" + ddlIRFCBPO.SelectedValue + "' where BK_NO= '" + BKNO + "' and SET_NO='" + SNO + "' and substr(CASE_NO,1,1)='" + Session["Region"] + "' and BILL_NO='" + lblBillNo.Text.Trim() + "'";
					}


					//					else if(lblOldAccGroup.Text=="Z006" && NewAU=="Z007")
					//					{
					//						if(lblOldBPO_CD.Text==txtBPO.Text)
					//						{
					//							updateQuery="update T20_IC set RECIPIENT_GSTIN_NO='"+lblGST_NO.Text.Trim()+"', ACC_GROUP='"+NewAU+"', IRFC_BPO_CD='"+ddlIRFCBPO.SelectedValue+"' where BK_NO= '" + BKNO + "' and SET_NO='"+SNO+"' and substr(CASE_NO,1,1)='"+Session["Region"]+"' and BILL_NO='"+lblBillNo.Text.Trim()+"'";
					//						}
					//						else if(lblOldBPO_CD.Text!=txtBPO.Text)
					//						{
					//							updateQuery="update T20_IC set BPO_CD='"+lstBPO.SelectedValue+"',RECIPIENT_GSTIN_NO='"+lblGST_NO.Text.Trim()+"', ACC_GROUP='"+NewAU+"', IRFC_BPO_CD='"+ddlIRFCBPO.SelectedValue+"' where BK_NO= '" + BKNO + "' and SET_NO='"+SNO+"' and substr(CASE_NO,1,1)='"+Session["Region"]+"' and BILL_NO='"+lblBillNo.Text.Trim()+"'";
					//						}
					//					}
					OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn1);
					myUpdateCommand.Transaction = myTrans;
					myUpdateCommand.ExecuteNonQuery();
					myTrans.Commit();
					conn1.Close();


					fill_ic_details();
					DisplayAlert("Your Record is Saved!!!");
				}
				else
				{
					DisplayAlert("Kindly Select the BPO OR old Recipient GST No. does not match with new GST No. !!!");
				}

			}
			catch (OracleException ex)
			{
				string str = ex.ErrorCode.ToString();
				myTrans.Rollback();
				Response.Redirect(("Error_Form.aspx?err=" + str));
			}

			finally
			{
				conn1.Close();
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Inspection_Certificate_Edit_Form.aspx");
		}
		int fill_BPO(string bpo)
		{
			lstBPO.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "";

			str1 = "select B.BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY) BPO_NAME, B.BPO_TYPE, A.RLY_CD||'-'||A.AU||'/'||A.AUDESC||'/'||A.ADDRESS AU_DESC, B.GSTIN_NO from T12_BILL_PAYING_OFFICER B, T03_CITY C, AU_CRIS A where B.BPO_CITY_CD= C.CITY_CD and B.AU=A.AU and (trim(upper(BPO_CD))=upper('" + bpo + "') or trim(upper(BPO_NAME)) LIKE upper('" + bpo + "%')) AND B.AU IS NOT NULL ORDER BY (B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)||'/'||B.BPO_RLY)";

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
					lblAU.Text = dsP.Tables[0].Rows[i]["AU_DESC"].ToString();
					if (rdbBPO.Checked == true)
					{
						lblGST_NO.Text = dsP.Tables[0].Rows[i]["GSTIN_NO"].ToString();
					}
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void lstBPO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtBPO.Text = lstBPO.SelectedValue;
			rbs.SetFocus(btnSave);
			conn1.Open();
			OracleCommand cmd3 = new OracleCommand("Select A.RLY_CD||'-'||A.AU||'/'||A.AUDESC||'/'||A.ADDRESS AU_DESC, B.GSTIN_NO FROM T12_BILL_PAYING_OFFICER B, AU_CRIS A WHERE B.AU=A.AU AND BPO_CD='" + lstBPO.SelectedValue + "'", conn1);
			OracleDataReader reader3 = cmd3.ExecuteReader();
			while (reader3.Read())
			{
				lblAU.Text = reader3["AU_DESC"].ToString();
				if (rdbBPO.Checked == true)
				{
					lblGST_NO.Text = reader3["GSTIN_NO"].ToString();
				}
			}
			conn1.Close();
		}

		protected void lstIRFC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//			if(lblIRFC.Text=="X" && lstBPO.SelectedValue=="Y")
			//			{
			if (lstIRFC.SelectedValue == "Y")
			{
				fill_IRFC_BPO();
				lblIRFC_BPO.Visible = true;
				rdbIRFC.Checked = true;
				rdbConsignee.Checked = false;
				rdbBPO.Checked = false;
				fill_BPO(lblOldBPO_CD.Text);
			}
			else
			{
				if (lblOldAccGroup.Text == "Z006")
				{
					rdbBPO.Checked = true;
					rdbConsignee.Checked = false;
					rdbIRFC.Checked = false;

				}
				else if (lblOldAccGroup.Text == "Z007")
				{
					rdbConsignee.Checked = true;
					rdbBPO.Checked = false;
					rdbIRFC.Checked = false;
				}
				else
				{
					rdbIRFC.Checked = true;
					rdbBPO.Checked = false;
					rdbConsignee.Checked = false;
				}
				//				ddlIRFCBPO.Visible=false;
				//				lblIRFC_BPO.Visible=false;
			}
			//			}
		}

		protected void ddlIRFCBPO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{

				conn1.Open();
				//OracleCommand cmd1 =new OracleCommand("select GSTIN_NO,LEGAL_NAME from T12_BILL_PAYING_OFFICER where BPO_CD='"+ddlIRFCBPO.SelectedValue+"'",conn1);
				OracleCommand cmd1 = new OracleCommand("select NVL(GSTIN_NO,'X') GSTIN_NO from T12_BILL_PAYING_OFFICER T12,T03_CITY T03,T92_STATE T92 WHERE T12.BPO_CITY_CD=T03.CITY_CD AND T03.STATE_CD=T92.STATE_CD(+) AND BPO_CD='" + ddlIRFCBPO.SelectedValue + "'", conn1);
				OracleDataReader reader1 = cmd1.ExecuteReader();
				while (reader1.Read())
				{

					lblGST_NO.Text = reader1["GSTIN_NO"].ToString();


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
	}
}