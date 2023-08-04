using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Purchaser_Form
{
	public partial class Purchaser_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		string Action;
		int P_CD;


		void show()
		{
			try
			{
				DataSet dsP1 = new DataSet();
				string str2 = "select * from T92_PURCHASER where PURCHASER_CD= " + P_CD;
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code.");
				}
				else
				{
					txtCCode.Text = dsP1.Tables[0].Rows[0]["PURCHASER_CD"].ToString();
					lstCType.SelectedValue = dsP1.Tables[0].Rows[0]["PURCHASER_TYPE"].ToString();
					if (lstCType.SelectedValue == "R")
					{
						Label7.Visible = true;
						lstRailwayCD.Visible = true;
						lstRailwayCD.SelectedValue = dsP1.Tables[0].Rows[0]["PURCHASER_FIRM"].ToString();
						txtPFirm.Visible = false;
						lstCAName.Visible = true;
						txtCSName.Visible = false;
						lstCAName.SelectedValue = dsP1.Tables[0].Rows[0]["PURCHASER_DESIG"].ToString();
					}
					else
					{
						//Label7.Visible =false;
						lstRailwayCD.Visible = false;
						txtPFirm.Visible = true;
						txtPFirm.Text = dsP1.Tables[0].Rows[0]["PURCHASER_FIRM"].ToString();
						lstCAName.Visible = false;
						txtCSName.Visible = true;
						txtCSName.Text = dsP1.Tables[0].Rows[0]["PURCHASER_DESIG"].ToString();
					}


					//txtCLName.Text =dsP1.Tables[0].Rows[0]["CONSIGNEE_L_NAME"].ToString();
					txtCAdd1.Text = dsP1.Tables[0].Rows[0]["PURCHASER_ADD1"].ToString();
					txtCAdd2.Text = dsP1.Tables[0].Rows[0]["PURCHASER_ADD2"].ToString();
					lstCCity.SelectedValue = dsP1.Tables[0].Rows[0]["PURCHASER_CITY"].ToString();

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

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del2();");

			if (Convert.ToString(Request.QueryString["PURCHASER_CD"]) == "")
			{
				P_CD = 0;
			}
			else
			{
				P_CD = Convert.ToInt32(Request.QueryString["PURCHASER_CD"]);
				Action = Convert.ToString(Request.QueryString["Action"]);

			}
			if (!(IsPostBack))
			{
				string str1 = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				for (int i = 0; (i <= (dsP.Tables[0].Rows.Count - 1)); i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["CITY"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CITY_CD"].ToString();
					lstCCity.Items.Add(lst);
				}
				conn1.Close();

				DataSet dsP2 = new DataSet();
				string str3 = "select RLY_CD,RAILWAY from T91_RAILWAYS";
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
				string str4 = "select RLY_DESIG_CD from T90_RLY_DESIGNATION ";
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
				}
				else
				{
					txtCCode.Visible = false;
					Label2.Visible = false;
					txtCCode.Enabled = false;
					Label11.Visible = false;

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
				string rly, CName;
				if (lstCType.SelectedValue == "R")
				{
					rly = lstRailwayCD.SelectedValue;
					CName = lstCAName.SelectedValue;
				}
				else
				{
					rly = txtPFirm.Text;
					CName = txtCSName.Text;
				}
				if (P_CD == 0)
				{
					string str3 = "select NVL(max(PURCHASER_CD),0) from T92_PURCHASER";
					OracleCommand myCommand = new OracleCommand();
					myCommand.CommandText = str3;
					myCommand.Connection = conn1;
					conn1.Open();
					int CD = Convert.ToInt32(myCommand.ExecuteScalar());
					CD = CD + 1;

					string myInsertQuery = "INSERT INTO T92_PURCHASER values(" + CD + ", '" + lstCType.SelectedItem.Value + "','" + CName + "','" + rly + "','" + txtCAdd1.Text + "', '" + txtCAdd2.Text + "'," + lstCCity.SelectedItem.Value + ")";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
				}
				else
				{
					string myUpdateQuery = "Update T92_PURCHASER  set PURCHASER_TYPE='" + lstCType.SelectedItem.Value + "',PURCHASER_DESIG='" + CName + "',PURCHASER_FIRM='" + rly + "', PURCHASER_ADD1 ='" + txtCAdd1.Text + "',PURCHASER_ADD2='" + txtCAdd2.Text + "', PURCHASER_CITY=" + lstCCity.SelectedItem.Value + " where PURCHASER_CD= " + txtCCode.Text;
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn1;
					conn1.Open();
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();
				}
				DisplayAlert("Your Record Has Been Saved!!!");
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
				String myDeleteQuery = "Delete T92_PURCHASER  where PURCHASER_CD= " + txtCCode.Text;
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
			Response.Redirect("Purchaser_Search_Form.aspx");
		}


		protected void lstCType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstCType.SelectedValue == "R")
			{
				//Label7.Visible =true;
				lstRailwayCD.Visible = true;
				txtPFirm.Visible = false;
				lstCAName.Visible = true;
				txtCSName.Visible = false;
			}
			else
			{
				//Label7.Visible =false;
				lstRailwayCD.Visible = false;
				txtPFirm.Visible = true;
				lstCAName.Visible = false;
				txtCSName.Visible = true;
			}
		}





	}
}