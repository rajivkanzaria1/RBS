using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Bill_Paying_Officer_Form
{
	public partial class Bill_Paying_Officer_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		DataSet dsP = new DataSet();
		string BPOcode;
		string Action;
		int ecode = 0;
		void show()
		{
			try
			{
				DataSet dsP1 = new DataSet();
				string str1 = "select BPO_CD,BPO_REGION,BPO_TYPE,BPO_NAME,BPO_RLY,BPO_ADD,BPO_CITY_CD,BILL_PASS_OFFICER,BPO_FEE_TYPE,BPO_FEE,BPO_TAX_TYPE,BPO_FLG,BPO_ADV_FLG,BPO_LOC_CD,BPO_ORGN,BPO_ADD1,BPO_ADD2,BPO_STATE,BPO_PHONE,BPO_FAX,BPO_EMAIL,PAY_WINDOW_ID,GSTIN_NO,AU,PIN_CODE,SAP_CUST_CD_BPO from T12_BILL_PAYING_OFFICER where BPO_CD= '" + BPOcode + "'";
				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				conn1.Close();
				//txtBPOCD.Text = dsP1.Tables[0].Rows[0]["BPO_CD"].ToString(); 
				lstBPORegion.SelectedValue = dsP1.Tables[0].Rows[0]["BPO_REGION"].ToString();
				lstBPOType.SelectedValue = dsP1.Tables[0].Rows[0]["BPO_TYPE"].ToString();
				if (lstBPOType.SelectedValue == "R")
				{
					lstBPORailways.SelectedValue = dsP1.Tables[0].Rows[0]["BPO_RLY"].ToString();
					lstPayingWindow.SelectedValue = dsP1.Tables[0].Rows[0]["PAY_WINDOW_ID"].ToString();
				}
				else
				{
					txtBPORailways.Text = dsP1.Tables[0].Rows[0]["BPO_RLY"].ToString();
				}
				txtBPOName.Text = dsP1.Tables[0].Rows[0]["BPO_NAME"].ToString();
				txtBPOAdd.Text = dsP1.Tables[0].Rows[0]["BPO_ADD"].ToString();
				string str = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY where CITY_CD=" + dsP1.Tables[0].Rows[0]["BPO_CITY_CD"].ToString();
				fillCity(str);
				txtCity.Text = lstBPOCity.SelectedValue;
				lstBPOCity.SelectedValue = dsP1.Tables[0].Rows[0]["BPO_CITY_CD"].ToString();
				Bpo_State();
				txtBillPassOff.Text = dsP1.Tables[0].Rows[0]["BILL_PASS_OFFICER"].ToString();
				lstBPOFeeType.SelectedValue = dsP1.Tables[0].Rows[0]["BPO_FEE_TYPE"].ToString();
				txtBPOFee.Text = dsP1.Tables[0].Rows[0]["BPO_FEE"].ToString();
				//						txtBPOMinFee.Text=dsP1.Tables[0].Rows[0]["BPO_MIN_FEE"].ToString ();
				//						txtBPOMaxFee.Text=dsP1.Tables[0].Rows[0]["BPO_MAX_FEE"].ToString ();
				if (dsP1.Tables[0].Rows[0]["BPO_TAX_TYPE"].ToString() == "")
				{
					lstBPOTaxType.SelectedValue = "X";
				}
				else
				{
					lstBPOTaxType.SelectedValue = dsP1.Tables[0].Rows[0]["BPO_TAX_TYPE"].ToString();
				}
				lstBPOFlag.SelectedValue = dsP1.Tables[0].Rows[0]["BPO_FLG"].ToString();
				lstBPOAdvFlag.SelectedValue = dsP1.Tables[0].Rows[0]["BPO_ADV_FLG"].ToString();
				txtBPOLocCD.Text = dsP1.Tables[0].Rows[0]["BPO_LOC_CD"].ToString();
				txtBPOOrg.Text = dsP1.Tables[0].Rows[0]["BPO_ORGN"].ToString();
				txtBPOOrgAdd1.Text = dsP1.Tables[0].Rows[0]["BPO_ADD1"].ToString();
				txtBPOOrgAdd2.Text = dsP1.Tables[0].Rows[0]["BPO_ADD2"].ToString();
				txtBPOState.Text = dsP1.Tables[0].Rows[0]["BPO_STATE"].ToString();
				//txtBPOPin.Text=dsP1.Tables[0].Rows[0]["BPO_PIN"].ToString(); 
				txtBPOPhone.Text = dsP1.Tables[0].Rows[0]["BPO_PHONE"].ToString();
				txtBPOFax.Text = dsP1.Tables[0].Rows[0]["BPO_FAX"].ToString();
				txtBPOEmail.Text = dsP1.Tables[0].Rows[0]["BPO_EMAIL"].ToString();
				txtGSTINNo.Text = dsP1.Tables[0].Rows[0]["GSTIN_NO"].ToString();
				txtPin.Text = dsP1.Tables[0].Rows[0]["PIN_CODE"].ToString();
				fill_AU();
				lstAUCris.SelectedValue = dsP1.Tables[0].Rows[0]["AU"].ToString();
				lblSapCustCD.Text = "SAP CUST CD: " + dsP1.Tables[0].Rows[0]["SAP_CUST_CD_BPO"].ToString();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//string str1=str.Replace("\n","");
				string str1 = "There is no row at position 0.";
				if (str.Equals(str1))
				{
					str1 = "Their is no record present for the given BPO Code";
					Response.Redirect("Error_Form.aspx?err=" + str1);
				}
				else
				{
					string str2 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str2);
				}


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
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1();");



			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.QueryString["BPO_CD"]) == "")
				{
					BPOcode = "";
				}
				else
				{
					BPOcode = Convert.ToString(Request.QueryString["BPO_CD"]);
					Action = Convert.ToString(Request.QueryString["Action"]);

				}

				try
				{



					DataSet dsP2 = new DataSet();
					string str2 = "select * from T01_REGIONS";
					OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
					OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
					ListItem lst6;
					conn1.Open();
					da1.SelectCommand = myOracleCommand1;
					da1.Fill(dsP2, "Table");
					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
					{
						lst6 = new ListItem();
						lst6.Text = dsP2.Tables[0].Rows[i]["REGION"].ToString();
						lst6.Value = dsP2.Tables[0].Rows[i]["REGION_CODE"].ToString();
						lstBPORegion.Items.Add(lst6);
					}
					lstBPORegion.Items.Insert(0, "");
					conn1.Close();

					DataSet dsP3 = new DataSet();
					string str3 = "select RLY_CD,RAILWAY from T91_RAILWAYS";
					OracleDataAdapter da2 = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand2 = new OracleCommand(str3, conn1);
					ListItem lst7;
					conn1.Open();
					da2.SelectCommand = myOracleCommand2;
					da2.Fill(dsP3, "Table");
					for (int i = 0; (i <= (dsP3.Tables[0].Rows.Count - 1)); i++)
					{
						lst7 = new ListItem();
						lst7.Text = dsP3.Tables[0].Rows[i]["RAILWAY"].ToString();
						lst7.Value = dsP3.Tables[0].Rows[i]["RLY_CD"].ToString();
						lstBPORailways.Items.Add(lst7);
					}
					lstBPORailways.Items.Insert(0, "");
					conn1.Close();

					DataSet dsP1 = new DataSet();
					string str1 = "select PAY_WINDOW_ID,PAY_WINDOW_DESC from T73_PAYING_WINDOW order by PAY_WINDOW_ID ";
					OracleDataAdapter da11 = new OracleDataAdapter(str1, conn1);
					OracleCommand myOracleCommand11 = new OracleCommand(str1, conn1);
					conn1.Open();
					da11.SelectCommand = myOracleCommand11;
					conn1.Close();
					da11.Fill(dsP1, "Table");
					lstPayingWindow.DataValueField = "PAY_WINDOW_ID";
					lstPayingWindow.DataTextField = "PAY_WINDOW_DESC";
					lstPayingWindow.DataSource = dsP1;
					lstPayingWindow.DataBind();
					lstPayingWindow.Items.Insert(0, "");

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

					ListItem lst3 = new ListItem();
					lst3.Text = "FA & CAO";
					lst3.Value = "F";
					lstBPOFlag.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "AO�s";
					lst3.Value = "A";
					lstBPOFlag.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "DFM�s";
					lst3.Value = "D";
					lstBPOFlag.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "DEE/DCEE etc.";
					lst3.Value = "M";
					lstBPOFlag.Items.Add(lst3);
					lst3 = new ListItem();
					lst3.Text = "Workshop";
					lst3.Value = "W";
					lstBPOFlag.Items.Add(lst3);
					lstBPOFlag.Items.Insert(0, "");


					ListItem lst4 = new ListItem();
					lst4.Text = "Advance bill to be raised";
					lst4.Value = "A";
					lstBPOAdvFlag.Items.Add(lst4);
					lst4 = new ListItem();
					lst4.Text = "Otherwise";
					lst4.Value = "null";
					lstBPOAdvFlag.Items.Add(lst4);
					lstBPOAdvFlag.Items.Insert(0, "");

					ListItem lst5 = new ListItem();
					lst5 = new ListItem();
					lst5.Text = "Railway";
					lst5.Value = "R";
					lstBPOType.Items.Add(lst5);
					lst5 = new ListItem();
					lst5.Text = "Private";
					lst5.Value = "P";
					lstBPOType.Items.Add(lst5);
					lst5 = new ListItem();
					lst5.Text = "Foreign Railway";
					lst5.Value = "F";
					lstBPOType.Items.Add(lst5);
					lst5 = new ListItem();
					lst5.Text = "PSU";
					lst5.Value = "U";
					lstBPOType.Items.Add(lst5);
					lst5 = new ListItem();
					lst5.Text = "State Government";
					lst5.Value = "S";
					lstBPOType.Items.Add(lst5);
					//lstBPOType.Items.Insert(0,"");
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

				if (Action == "E")
				{
					show();
					btnDelete.Visible = true;
					btnSave.Visible = true;

					lblBPOCD.Text = BPOcode;
					lblBPOCD.Visible = true;
					conn1.Close();
				}
				else if (Action == "D")
				{
					show();
					btnSave.Visible = false;
					btnDelete.Visible = true;
					//txtBPOCD.Visible = false; 
					lblBPOCD.Text = BPOcode;
					lblBPOCD.Visible = true;
					conn1.Close();
				}
				else
				{
					btnDelete.Visible = false;
					//txtBPOCD.Visible = true; 
					Label6.Visible = false;
					lblBPOCD.Visible = false;
					lstBPOCity.Visible = false;
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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				string Ttype;
				Ttype = lstBPOTaxType.SelectedItem.Value;
				if ((Ttype == "X"))
				{
					Ttype = "";
				}

				string Aflag;
				Aflag = lstBPOAdvFlag.SelectedItem.Value;
				if ((Aflag == "null"))
				{
					Aflag = "";
				}
				string Brailway;
				if (lstBPOType.SelectedValue == "R")
				{
					Brailway = lstBPORailways.SelectedValue;
				}
				else
				{
					Brailway = txtBPORailways.Text;
				}
				string ccode;
				if ((lstBPOCity.SelectedValue == ""))
				{
					ccode = "null";
				}
				else
				{
					ccode = lstBPOCity.SelectedValue;
				}
				//					
				if (txtBPOFee.Text == "")
				{
					txtBPOFee.Text = "null";
				}
				string w_paywindow = "", w_AU = "";
				if (lstBPOType.SelectedValue == "R")
				{
					w_paywindow = lstPayingWindow.SelectedValue;
					w_AU = lstAUCris.SelectedValue;

				}
				else
				{
					w_paywindow = "";
					w_AU = "";
				}
				Action = Convert.ToString(Request.QueryString["Action"]);


				if (Action != "E")
				{
					//						

					string str3 = "select lpad(to_number(Nvl(max(nvl(BPO_CD,0)),0)+1),5,'0') from T12_BILL_PAYING_OFFICER";
					OracleCommand myOracleCommand = new OracleCommand();
					myOracleCommand.CommandText = str3;
					myOracleCommand.Connection = conn1;
					conn1.Open();
					string bcode = Convert.ToString(myOracleCommand.ExecuteScalar());
					conn1.Close();
					//						
					if (lstBPOCity.Visible != true)
					{
						DisplayAlert("Plz Press the select City button first and then save it");
					}
					else if (lblBPOState.Text == "" || txtPin.Text == "" || txtGSTINNo.Text == "")
					{
						DisplayAlert("GSTN NO, BPO State & PIN Code Cannot be left Blank, kindly fill the GSTN No,State & PIN Code");
					}
					else
					{
						string gststate = txtGSTINNo.Text.Substring(0, 2);
						string statecd = lblBPOState.Text.Substring(0, 2);
						if (gststate != statecd)
						{
							DisplayAlert("Kindly enter the GST No according to the State Entered!!!");
						}
						else
						{
							string w_Legal_Name = "";
							if (lstBPOType.SelectedItem.Value == "R")
							{
								w_Legal_Name = "MINISTRY OF RAILWAYS";
							}

							string myInsertQuery = "INSERT INTO T12_BILL_PAYING_OFFICER(BPO_CD, BPO_REGION, BPO_TYPE, BPO_NAME, BPO_RLY, BPO_ADD,BPO_CITY_CD, BILL_PASS_OFFICER, BPO_FEE_TYPE, BPO_FEE, BPO_TAX_TYPE, BPO_FLG, BPO_ADV_FLG,BPO_LOC_CD, BPO_ORGN, BPO_ADD1, BPO_ADD2, BPO_STATE, BPO_PHONE, BPO_FAX, BPO_EMAIL,PAY_WINDOW_ID,USER_ID,DATETIME,GSTIN_NO,AU,LEGAL_NAME,PIN_CODE) values('" + bcode + "', '" + lstBPORegion.SelectedItem.Value + "','" + lstBPOType.SelectedValue + "','" + txtBPOName.Text.Trim() + "','" + Brailway + "','" + txtBPOAdd.Text + "'," + ccode + ", '" + txtBillPassOff.Text + "','" + lstBPOFeeType.SelectedItem.Value + "'," + txtBPOFee.Text + ",'" + Ttype + "','" + lstBPOFlag.SelectedItem.Value + "','" + Aflag + "','" + txtBPOLocCD.Text + "','" + txtBPOOrg.Text + "','" + txtBPOOrgAdd1.Text + "','" + txtBPOOrgAdd2.Text + "','" + txtBPOState.Text + "','" + txtBPOPhone.Text + "','" + txtBPOFax.Text + "','" + txtBPOEmail.Text + "','" + w_paywindow + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),UPPER('" + txtGSTINNo.Text.Trim() + "'),'" + w_AU + "','" + w_Legal_Name + "','" + txtPin.Text.Trim() + "')";
							OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
							myInsertCommand.Connection = conn1;
							conn1.Open();
							myInsertCommand.ExecuteNonQuery();
							conn1.Close();
							Label6.Visible = true;
							lblBPOCD.Text = bcode.ToString();
							lblBPOCD.Visible = true;
							btnSave.Visible = true;
							btnSave.Enabled = false;
							DisplayAlert("Your Record Has Been Saved!!!");
						}
					}
					//						
				}
				else
				{
					if (lstBPOCity.Visible != true)
					{
						DisplayAlert("Plz Press the select City button first and then save it");
					}
					else if (lblBPOState.Text == "")
					{
						DisplayAlert("BPO State Cannot be left Blank, kindly fill the State for the given city first from City Master Directory");
					}
					else
					{
						string gststate = txtGSTINNo.Text.Substring(0, 2);
						string statecd = lblBPOState.Text.Substring(0, 2);
						if (gststate != statecd)
						{
							DisplayAlert("Kindly enter the GST No according to the State Entered!!!");
						}
						else
						{
							string Ucode = lblBPOCD.Text;
							string myUpdateQuery = "Update T12_BILL_PAYING_OFFICER set BPO_REGION ='" + lstBPORegion.SelectedItem.Value + "', BPO_TYPE= '" + lstBPOType.SelectedValue + "',BPO_NAME ='" + txtBPOName.Text + "',BPO_RLY='" + Brailway + "',BPO_ADD='" + txtBPOAdd.Text + "', BPO_CITY_CD =" + ccode + ", BILL_PASS_OFFICER ='" + txtBillPassOff.Text + "', BPO_FEE_TYPE= '" + lstBPOFeeType.SelectedItem.Value + "',BPO_FEE=" + txtBPOFee.Text + ", BPO_TAX_TYPE='" + Ttype + "', BPO_FLG='" + lstBPOFlag.SelectedItem.Value + "', BPO_ADV_FLG='" + Aflag + "', BPO_LOC_CD='" + txtBPOLocCD.Text + "',BPO_ORGN='" + txtBPOOrg.Text + "',BPO_ADD1='" + txtBPOOrgAdd1.Text + "',BPO_ADD2='" + txtBPOOrgAdd2.Text + "',BPO_STATE='" + txtBPOState.Text + "', BPO_PHONE= '" + txtBPOPhone.Text + "',BPO_FAX='" + txtBPOFax.Text + "',BPO_EMAIL='" + txtBPOEmail.Text + "',PAY_WINDOW_ID='" + w_paywindow + "',USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),GSTIN_NO=upper('" + txtGSTINNo.Text.Trim() + "'),AU='" + w_AU + "',PIN_CODE='" + txtPin.Text.Trim() + "' where BPO_CD='" + Ucode + "'";
							OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
							myUpdateCommand.Connection = conn1;
							conn1.Open();
							myUpdateCommand.ExecuteNonQuery();
							conn1.Close();
							DisplayAlert("Your Record Has Been Saved!!!");
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


		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{

			try
			{
				string Ucode = lblBPOCD.Text.Trim();
				string myDeleteQuery = "Delete T12_BILL_PAYING_OFFICER where BPO_CD='" + Ucode + "'";
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
				conn1.Close();

				DisplayAlert("Your Record has been Deleted!!!");

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
			finally
			{
				conn1.Close();
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("BPO_List.aspx");
		}

		private void lstBPOType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//			if(lstBPOType.SelectedValue =="R")
			//			{
			//				lstBPORailways.Visible =true;
			//				txtBPORailways.Visible=false;
			//				rbs.SetFocus(lstBPORailways);
			//			}
			//			else
			//			{
			//				lstBPORailways.Visible =false;
			//				txtBPORailways.Visible=true;
			//				rbs.SetFocus(txtBPORailways);
			//			}
		}

		int fillCity(string str1)
		{
			//string str1=str;
			DataSet dsP = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			conn1.Close();
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
					lst.Text = dsP.Tables[0].Rows[i]["CITY"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CITY_CD"].ToString();
					lstBPOCity.Items.Add(lst);
				}
				lstBPOCity.SelectedIndex = 0;
				lstBPOCity.Visible = true;
				ecode = 2;
				return (ecode);
			}


		}


		protected void btnFCList_Click(object sender, System.EventArgs e)
		{
			lstBPOCity.Items.Clear();
			lstBPOCity.Visible = true;

			try
			{
				if ((Convert.ToInt64(txtCity.Text) >= 1) && (Convert.ToInt64(txtCity.Text) <= 9999))
				{
					string str1 = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY where CITY_CD= " + txtCity.Text + " Order by CITY ";
					int a = fillCity(str1);
					if (a == 1)
					{

						lstBPOCity.Visible = false;
						DisplayAlert("No City Found!!!");
						rbs.SetFocus(txtCity);
					}
					else if (ecode == 2)
					{
						Bpo_State();
						rbs.SetFocus(lstBPOCity);
					}
				}
				else
				{
					DisplayAlert("Invalid City Code!!!");
					lstBPOCity.Items.Clear();
					lstBPOCity.Visible = false;
					rbs.SetFocus(txtCity);
				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "Input string was not in a correct format.";
				if (str.Equals(str1))
				{
					string str2 = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY where TRIM(UPPER(CITY)) LIKE TRIM(UPPER('" + txtCity.Text + "%')) Order by CITY ";
					int a = fillCity(str2);
					if (a == 1)
					{
						lstBPOCity.Visible = false;
						DisplayAlert("No City Found!!!");
						rbs.SetFocus(txtCity);
					}
					else if (a == 2)
					{
						txtCity.Text = lstBPOCity.SelectedValue;
						Bpo_State();
						rbs.SetFocus(lstBPOCity);
					}

					//lblCity.Text=lstVendCity.SelectedItem.Text;
				}
				else
				{
					string str2 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str2);
				}

			}
			finally
			{
				conn1.Close();
			}




		}

		private void lstBPOCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtCity.Text = lstBPOCity.SelectedValue;
			rbs.SetFocus(txtBillPassOff);
			//lblCity.Visible=true;

		}

		private void lstBPOType_PreRender(object sender, System.EventArgs e)
		{
			if (lstBPOType.SelectedValue == "R")
			{
				lstBPORailways.Visible = true;
				txtBPORailways.Visible = false;

			}
			else
			{
				lstBPORailways.Visible = false;
				txtBPORailways.Visible = true;

			}
		}
		void fill_AU()
		{
			lstAUCris.Items.Clear();
			DataSet dsP4 = new DataSet();
			string str4 = "select AU,AU||'-'||AUDESC||'/'||ADDRESS AU_DESC from AU_CRIS WHERE RLY_CD='" + lstBPORailways.SelectedValue + "'";
			OracleDataAdapter da4 = new OracleDataAdapter(str4, conn1);
			OracleCommand myOracleCommand4 = new OracleCommand(str4, conn1);
			ListItem lst8;
			conn1.Open();
			da4.SelectCommand = myOracleCommand4;
			da4.Fill(dsP4, "Table");
			for (int i = 0; (i <= (dsP4.Tables[0].Rows.Count - 1)); i++)
			{
				lst8 = new ListItem();
				lst8.Text = dsP4.Tables[0].Rows[i]["AU_DESC"].ToString();
				lst8.Value = dsP4.Tables[0].Rows[i]["AU"].ToString();
				lstAUCris.Items.Add(lst8);
			}
			lstAUCris.Items.Insert(0, "");
			conn1.Close();
		}

		void Bpo_State()
		{

			conn1.Open();
			//			OracleCommand cmd1 =new OracleCommand("Select PIN_CODE FROM T03_CITY WHERE CITY_CD='"+lstBPOCity.SelectedValue+"'",conn1);
			//			lblPin.Text=Convert.ToString(cmd1.ExecuteScalar());
			OracleCommand cmd2 = new OracleCommand("Select lpad(STATE_CD,2,'0')||'-'||STATE_NAME from T92_STATE WHERE STATE_CD=(SELECT STATE_CD FROM T03_CITY WHERE CITY_CD='" + lstBPOCity.SelectedValue + "')", conn1);
			lblBPOState.Text = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
		}

		protected void lstBPORailways_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_AU();
		}

		protected void lstBPOCity_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			txtCity.Text = lstBPOCity.SelectedItem.Text;
			Bpo_State();
		}





	}
}