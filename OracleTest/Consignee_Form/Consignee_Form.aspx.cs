using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Consignee_Form
{
	public partial class Consignee_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		string Action;
		int P_CD, ecode = 0;


		void show()
		{
			try
			{
				DataSet dsP1 = new DataSet();
				string str2 = "select * from T06_CONSIGNEE where CONSIGNEE_CD= " + P_CD;
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				conn1.Close();
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Consignee Code.");
				}
				else
				{
					txtCCode.Text = dsP1.Tables[0].Rows[0]["CONSIGNEE_CD"].ToString();
					lstCType.SelectedValue = dsP1.Tables[0].Rows[0]["CONSIGNEE_TYPE"].ToString();
					if (lstCType.SelectedValue == "R")
					{
						//Label7.Visible =true;
						//lstRailwayCD.Visible =true;
						lstRailwayCD.SelectedValue = dsP1.Tables[0].Rows[0]["CONSIGNEE_FIRM"].ToString();
						//lstCAName.Visible=true;
						//txtCSName.Visible=false;
						lstCAName.SelectedValue = dsP1.Tables[0].Rows[0]["CONSIGNEE_DESIG"].ToString();
						//txtFName.Visible=false;
					}
					else
					{
						//	lstRailwayCD.Visible =false;
						//lstCAName.Visible=false;
						//txtCSName.Visible=true;
						txtCSName.Text = dsP1.Tables[0].Rows[0]["CONSIGNEE_DESIG"].ToString();
						//txtFName.Visible=true;
						txtFName.Text = dsP1.Tables[0].Rows[0]["CONSIGNEE_FIRM"].ToString();
					}


					txtCDept.Text = dsP1.Tables[0].Rows[0]["CONSIGNEE_DEPT"].ToString();
					txtCAdd1.Text = dsP1.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
					txtCAdd2.Text = dsP1.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
					string str = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY where CITY_CD=" + dsP1.Tables[0].Rows[0]["CONSIGNEE_CITY"].ToString();
					fillCity(str);
					txtCity.Text = lstCCity.SelectedValue;
					Con_State();
					lstCCity.SelectedValue = dsP1.Tables[0].Rows[0]["CONSIGNEE_CITY"].ToString();
					txtGSTINNo.Text = dsP1.Tables[0].Rows[0]["GSTIN_NO"].ToString();
					txtPin.Text = dsP1.Tables[0].Rows[0]["PIN_CODE"].ToString();
					lblSapCustCD.Text = "SAP CUST_CD: " + dsP1.Tables[0].Rows[0]["SAP_CUST_CD_CON"].ToString();

				}


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "There is no row at position 0.";
				if (str.Equals(str1))
				{
					str1 = "Their is no record present for the given Consignee Code";
				}
				else
				{
					string str2 = str.Replace("\n", "");
					Response.Redirect(("Error_Form.aspx?err=" + str2));
				}
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
			btnDelete.Attributes.Add("OnClick", "JavaScript:del2();");
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1();");


			if (Convert.ToString(Request.QueryString["CONSIGNEE_CD"]) == "")
			{
				P_CD = 0;
			}
			else
			{
				P_CD = Convert.ToInt32(Request.QueryString["CONSIGNEE_CD"]);
				Action = Convert.ToString(Request.QueryString["Action"]);
				btnAdd.Visible = false;

			}
			if (!(IsPostBack))
			{
				//				string str1 = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY order by CITY";
				//				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				//				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				//				ListItem lst;
				//				conn1.Open();
				//				da.SelectCommand = myOracleCommand;
				//				da.Fill(dsP, "Table");
				//				for (int i = 0; (i <= (dsP.Tables[0].Rows.Count - 1)); i++) 
				//				{
				//					lst = new ListItem();
				//					lst.Text = dsP.Tables[0].Rows[i]["CITY"].ToString();
				//					lst.Value = dsP.Tables[0].Rows[i]["CITY_CD"].ToString();
				//					lstCCity.Items.Add(lst);
				//				}
				//				conn1.Close(); 

				DataSet dsP2 = new DataSet();
				string str3 = "select RLY_CD,RAILWAY from T91_RAILWAYS order by RAILWAY";
				OracleDataAdapter da2 = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand2 = new OracleCommand(str3, conn1);
				ListItem lst1;
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				for (int i = 0; (i <= (dsP2.Tables[0].Rows.Count - 1)); i++)
				{
					lst1 = new ListItem();
					lst1.Text = dsP2.Tables[0].Rows[i]["RAILWAY"].ToString();
					lst1.Value = dsP2.Tables[0].Rows[i]["RLY_CD"].ToString();
					lstRailwayCD.Items.Add(lst1);
				}
				conn1.Close();

				DataSet dsP3 = new DataSet();
				string str4 = "select RLY_DESIG_CD from T90_RLY_DESIGNATION Order by RLY_DESIG_CD";
				OracleDataAdapter da3 = new OracleDataAdapter(str4, conn1);
				OracleCommand myOracleCommand3 = new OracleCommand(str4, conn1);
				ListItem lst3;
				conn1.Open();
				da3.SelectCommand = myOracleCommand3;
				da3.Fill(dsP3, "Table");
				for (int i = 0; (i <= (dsP3.Tables[0].Rows.Count - 1)); i++)
				{
					lst3 = new ListItem();
					lst3.Text = dsP3.Tables[0].Rows[i]["RLY_DESIG_CD"].ToString();
					lst3.Value = dsP3.Tables[0].Rows[i]["RLY_DESIG_CD"].ToString();
					lstCAName.Items.Add(lst3);
				}
				conn1.Close();



				ListItem lst5 = new ListItem();
				lst5 = new ListItem();
				lst5.Text = "Railway";
				lst5.Value = "R";
				lstCType.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Private";
				lst5.Value = "P";
				lstCType.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Foreign Railway";
				lst5.Value = "F";
				lstCType.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "PSU";
				lst5.Value = "U";
				lstCType.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "State Government";
				lst5.Value = "S";
				lstCType.Items.Add(lst5);

				if (Action == "D")
				{
					show();
					Label11.Visible = true;
					Label11.Text = P_CD.ToString();
					btnDelete.Visible = true;
					txtCCode.Visible = false;
					Label2.Visible = true;
					txtCCode.Enabled = false;
					btnSave.Visible = false;
					btnAdd.Visible = false;

				}
				else if (Action == "M")
				{
					show();
					Label11.Visible = true;
					Label11.Text = P_CD.ToString();
					txtCCode.Visible = false;
					Label2.Visible = true;
					txtCCode.Enabled = false;
					btnDelete.Visible = false;
					btnSave.Visible = true;
					btnSave.Text = "Save";
					btnAdd.Visible = false;
				}
				else
				{
					txtCCode.Visible = false;
					Label2.Visible = false;
					txtCCode.Enabled = false;
					btnDelete.Visible = false;
					Label11.Visible = false;
					btnAdd.Visible = false;
					lstCCity.Visible = false;

				}

			}
			//			else
			//			{
			//				if(lstCType.SelectedValue =="R")
			//				{
			//					Label7.Visible =true;
			//					lstRailwayCD.Visible =true;
			//					lstCAName.Visible=true;
			//					txtCSName.Visible=false;
			//					txtFName.Visible=false;
			//				}
			//				else
			//				{
			//					lstRailwayCD.Visible =false;
			//					lstCAName.Visible=false;
			//					txtCSName.Visible=true;
			//					txtFName.Visible=true;
			//				}
			//			
			//			}


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
				string rly, CName;
				if (lstCType.SelectedValue == "R")
				{
					rly = lstRailwayCD.SelectedValue;
					CName = lstCAName.SelectedValue;
				}
				else
				{
					rly = txtFName.Text;
					CName = txtCSName.Text;
				}

				if (P_CD == 0)
				{
					if (lstCCity.Visible == false)
					{
						DisplayAlert("Plz Press the select City button first and then save it");
					}
					else if (lblConState.Text == "" || txtPin.Text == "" || txtGSTINNo.Text == "")
					{
						DisplayAlert("Consignee GSTIN No, State & PIN Code Cannot be left Blank, kindly fill the GSTIN No,State & Pin Code.");
					}
					else
					{
						string gststate = txtGSTINNo.Text.Substring(0, 2);
						string statecd = lblConState.Text.Substring(0, 2);
						if (gststate != statecd)
						{
							DisplayAlert("Kindly enter the GST No according to the State Entered!!!");
						}
						else
						{
							string str3 = "select NVL(max(CONSIGNEE_CD),0) from T06_CONSIGNEE";
							OracleCommand myCommand = new OracleCommand();
							myCommand.CommandText = str3;
							myCommand.Connection = conn1;
							conn1.Open();
							int CD = Convert.ToInt32(myCommand.ExecuteScalar());
							CD = CD + 1;
							string w_Legal_Name = "";
							if (lstCType.SelectedItem.Value == "R")
							{
								w_Legal_Name = "MINISTRY OF RAILWAYS";
							}
							string myInsertQuery = "INSERT INTO T06_CONSIGNEE(CONSIGNEE_CD,CONSIGNEE_TYPE,CONSIGNEE_DESIG,CONSIGNEE_DEPT,CONSIGNEE_FIRM,CONSIGNEE_ADD1,CONSIGNEE_ADD2,CONSIGNEE_CITY,USER_ID,DATETIME,GSTIN_NO,LEGAL_NAME,PIN_CODE) values(" + CD + ", '" + lstCType.SelectedItem.Value + "',upper('" + CName + "'),upper('" + txtCDept.Text + "'),upper('" + rly + "'), upper('" + txtCAdd1.Text + "'), upper('" + txtCAdd2.Text + "')," + lstCCity.SelectedItem.Value + ",'" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),upper('" + txtGSTINNo.Text.Trim() + "'),'" + w_Legal_Name + "','" + txtPin.Text + "')";
							OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
							myInsertCommand.Connection = conn1;
							myInsertCommand.ExecuteNonQuery();
							conn1.Close();
							DisplayAlert("Your Record Has Been Saved!!!");
							Label2.Visible = true;
							Label11.Visible = true;
							Label11.Text = CD.ToString();
							btnSave.Visible = true;
							btnSave.Enabled = false;
						}
					}
				}
				else
				{
					if (lstCCity.Visible == false)
					{
						DisplayAlert("Plz Press the select City button first and then save it");
					}
					else if (lblConState.Text == "")
					{
						DisplayAlert("Consignee State Cannot be left Blank, kindly fill the State for the given city first from City Master Directory");
					}
					else
					{
						string gststate = txtGSTINNo.Text.Substring(0, 2);
						string statecd = lblConState.Text.Substring(0, 2);
						if (gststate != statecd)
						{
							DisplayAlert("Kindly enter the GST No according to the State CD!!!");
						}
						else
						{
							string myUpdateQuery = "Update T06_CONSIGNEE set CONSIGNEE_TYPE=upper('" + lstCType.SelectedItem.Value + "'),CONSIGNEE_DESIG=upper('" + CName + "'),CONSIGNEE_DEPT =upper('" + txtCDept.Text + "'),CONSIGNEE_FIRM=upper('" + rly + "'), CONSIGNEE_ADD1 =upper('" + txtCAdd1.Text + "'),CONSIGNEE_ADD2=upper('" + txtCAdd2.Text + "'), CONSIGNEE_CITY=" + lstCCity.SelectedItem.Value + ",GSTIN_NO=upper('" + txtGSTINNo.Text.Trim() + "'),USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),PIN_CODE='" + txtPin.Text.Trim() + "' where CONSIGNEE_CD= " + txtCCode.Text;
							OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
							myUpdateCommand.Connection = conn1;
							conn1.Open();
							myUpdateCommand.ExecuteNonQuery();
							conn1.Close();
							DisplayAlert("Your Record Has Been Saved!!!");
						}
					}
				}
				btnAdd.Visible = true;

				//				txtCCode.Text="";
				//				txtCLName.Text ="";
				//				txtCSName.Text ="";
				//				txtCAdd1.Text="";
				//				txtCAdd2.Text ="";
				//lstPCity.SelectedValue ="1";



				//				grdCDetails.DataSource=this.show();
				//				grdCDetails.DataBinding();
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

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{

			try
			{
				//string popupScript = "<script language='javascript'>" + "return confirm('Are you sure to delete  ?')" + "</script>";
				//Page.RegisterStartupScript("PopupScript", popupScript);
				//btnDelete.Attributes.Add("OnClick","return confirm('Are you sure to delete  ?')");
				//btnDelete.Attributes.Add("OnClick", "JavaScript:return confirm('Are you sure to delete  ?');"); 
				String myDeleteQuery = "Delete T06_CONSIGNEE where CONSIGNEE_CD= " + txtCCode.Text;
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
				conn1.Close();
				//				txtCCode.Text="";
				//				txtCLName.Text ="";
				//				txtCSName.Text ="";
				//				txtCAdd1.Text="";
				//				txtCAdd2.Text ="";

				btnSave.Text = "Save";
				//lstPCity.SelectedValue ="1";
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

			//string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Deleted!!!" + txtCCode.Text + "', 'CustomPopUp', " + "'width=330, height=120, menubar=no, resizable=no')" + "</script>";
			//Page.RegisterStartupScript("PopupScript", popupScript);
			DisplayAlert("Your Record Has Been Deleted!!!");
		}


		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Consignee_Search_Form.aspx");
		}


		private void lstCType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//			if(lstCType.SelectedValue =="R")
			//			{
			//				Label7.Visible =true;
			//				lstRailwayCD.Visible =true;
			//				lstCAName.Visible=true;
			//				txtCSName.Visible=false;
			//				txtFName.Visible=false;
			//			}
			//			else
			//			{
			//				lstRailwayCD.Visible =false;
			//				lstCAName.Visible=false;
			//				txtCSName.Visible=true;
			//				txtFName.Visible=true;
			//			}

		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Consignee_Form.aspx");
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
					lstCCity.Items.Add(lst);
				}
				lstCCity.SelectedIndex = 0;
				lstCCity.Visible = true;
				//rbs.SetFocus(lstCCity);
				ecode = 2;
				return (ecode);
			}


		}
		protected void btnFCList_Click(object sender, System.EventArgs e)
		{
			lstCCity.Items.Clear();
			lstCCity.Visible = true;

			try
			{
				if ((Convert.ToInt64(txtCity.Text) >= 1) && (Convert.ToInt64(txtCity.Text) <= 9999))
				{
					string str1 = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY where CITY_CD= " + txtCity.Text + " Order by CITY ";
					int a = fillCity(str1);
					if (a == 1)
					{
						lstCCity.Visible = false;
						DisplayAlert("Invalid Search Data");
						rbs.SetFocus(txtCity);
					}
					else
					{
						rbs.SetFocus(lstCCity);
						Con_State();
					}


				}
				else
				{
					DisplayAlert("Invalid City Code!!!");
					lstCCity.Items.Clear();
					lstCCity.Visible = false;
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
						lstCCity.Visible = false;
						DisplayAlert("No City Found!!!");
						rbs.SetFocus(txtCity);
					}
					else if (a == 2)
					{
						txtCity.Text = lstCCity.SelectedValue;
						rbs.SetFocus(lstCCity);
						Con_State();
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
		void Con_State()
		{

			conn1.Open();
			//			OracleCommand cmd1 =new OracleCommand("Select PIN_CODE FROM T03_CITY WHERE CITY_CD='"+lstCCity.SelectedValue+"'",conn1);
			//			lblPin.Text=Convert.ToString(cmd1.ExecuteScalar());
			OracleCommand cmd2 = new OracleCommand("Select lpad(STATE_CD,2,'0')||'-'||STATE_NAME from T92_STATE WHERE STATE_CD=(SELECT STATE_CD FROM  T03_CITY WHERE CITY_CD='" + lstCCity.SelectedValue + "')", conn1);
			lblConState.Text = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
		}

		protected void lstCCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtCity.Text = lstCCity.SelectedValue;
			rbs.SetFocus(btnSave);
			Con_State();
		}









	}
}