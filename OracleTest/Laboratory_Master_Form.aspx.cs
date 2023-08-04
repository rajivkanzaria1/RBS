using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Laboratory_Master_Form
{
	public partial class Laboratory_Master_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string Action = "";


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["LAB_ID"]) == null)
				{

					Action = "";
					Label2.Visible = false;
					lblLabCD.Visible = false;
				}
				else if (Convert.ToString(Request.Params["LAB_ID"]) != null)
				{
					lblLabCD.Text = Convert.ToString(Request.Params["LAB_ID"].Trim());
					Label2.Visible = true;
					lblLabCD.Visible = true;
					show();

				}

			}
		}
		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				int code = Convert.ToInt32(lblLabCD.Text);
				DataSet dsP1 = new DataSet();

				string str1 = "select LAB_ID,LAB_NAME,LAB_ADDRESS LAB_ADD,LAB_CITY,LAB_CONTACT_PER, LAB_CONTACT_TEL,NVL(LAB_APPROVAL,'') LAB_APPROVAL, to_char(LAB_APPROVAL_FR,'dd/mm/yyyy') LAB_APPROVAL_FR" +
					", to_char(LAB_APPROVAL_TO,'dd/mm/yyyy') LAB_APPROVAL_TO, LAB_EMAIL from T65_LABORATORY_MASTER where LAB_ID='" + code + "'";
				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				conn1.Close();
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code.");
				}
				else
				{

					txtLabName.Text = dsP1.Tables[0].Rows[0]["LAB_NAME"].ToString();
					txtAdd1.Text = dsP1.Tables[0].Rows[0]["LAB_ADD"].ToString();
					string str = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY where CITY_CD=" + dsP1.Tables[0].Rows[0]["LAB_CITY"].ToString();
					fillCity(str);
					txtCity.Text = lstCity.SelectedValue;
					lstCity.SelectedValue = dsP1.Tables[0].Rows[0]["LAB_CITY"].ToString();
					txtConPer1.Text = dsP1.Tables[0].Rows[0]["LAB_CONTACT_PER"].ToString();
					txtTel1.Text = dsP1.Tables[0].Rows[0]["LAB_CONTACT_TEL"].ToString();
					lstLabApp.SelectedValue = dsP1.Tables[0].Rows[0]["LAB_APPROVAL"].ToString();
					txtAppFrom.Text = dsP1.Tables[0].Rows[0]["LAB_APPROVAL_FR"].ToString();
					txtAppTo.Text = dsP1.Tables[0].Rows[0]["LAB_APPROVAL_TO"].ToString();
					txtEmail.Text = dsP1.Tables[0].Rows[0]["LAB_EMAIL"].ToString();

				}


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "No Record Found!!! For The Given Code.";
				if (str.Equals(str1))
				{
					str1 = "Their is no record present for the given Vendor Code";
					Response.Redirect("Error_Form.aspx?err=" + str1);
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
		int fillCity(string str1)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//string str1=str;
			try
			{
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

					return (1);
					//DisplayAlert("Invalid Search Data");
				}
				else
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["CITY"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["CITY_CD"].ToString();
						lstCity.Items.Add(lst);
					}
					lstCity.SelectedIndex = 0;
					lstCity.Visible = true;
					//rbs.SetFocus(lstVendCity);
					return (2);
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				return (1);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnFCList_Click(object sender, System.EventArgs e)
		{
			lstCity.Items.Clear();
			lstCity.Visible = true;

			try
			{

				if ((Convert.ToInt64(txtCity.Text) >= 1) && (Convert.ToInt64(txtCity.Text) <= 9999))
				{
					string str1 = "select CITY_CD,NVL2(LOCATION,LOCATION||' : '||CITY,CITY) CITY from T03_CITY where CITY_CD= " + txtCity.Text + " Order by CITY ";
					int a = fillCity(str1);
					if (a == 1)
					{
						lstCity.Visible = false;
						DisplayAlert("Invalid Search Data");
						rbs.SetFocus(txtCity);
					}
					else
					{
						rbs.SetFocus(lstCity);
					}


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
						lstCity.Visible = false;
						DisplayAlert("No City Found!!!");
						rbs.SetFocus(txtCity);
					}
					else if (a == 2)
					{

						txtCity.Text = lstCity.SelectedValue;
						rbs.SetFocus(lstCity);
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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				Action = Convert.ToString(Request.QueryString["Action"]);
				//code = txtVendCD.Text.Trim(); 


				if (Action == "" || Action == null)
				{
					string str3 = "select NVL(max(LAB_ID),0)+1 from T65_LABORATORY_MASTER";
					OracleCommand myOracleCommand = new OracleCommand();
					myOracleCommand.CommandText = str3;
					myOracleCommand.Connection = conn1;
					conn1.Open();
					int st = Convert.ToInt32(myOracleCommand.ExecuteScalar());
					if (lstCity.Visible == false)
					{
						DisplayAlert("Plz Press the select City button first and then save it");
					}
					else
					{

						string myUpdateQuery = "INSERT INTO T65_LABORATORY_MASTER(LAB_ID,LAB_NAME,LAB_ADDRESS,LAB_CITY,LAB_CONTACT_PER,LAB_CONTACT_TEL,LAB_EMAIL,LAB_APPROVAL,LAB_APPROVAL_FR,LAB_APPROVAL_TO,USER_ID,DATETIME) values(" + st + ", '" + txtLabName.Text + "','" + txtAdd1.Text + "'," + lstCity.SelectedItem.Value + ", '" + txtConPer1.Text + "', '" + txtTel1.Text + "','" + txtEmail.Text + "' ,'" + lstLabApp.SelectedItem.Value + "', to_date('" + txtAppFrom.Text + "','dd/mm/yyyy'),to_date('" + txtAppTo.Text + "','dd/mm/yyyy'),'" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
						OracleCommand myUpdateCommand = new OracleCommand();
						myUpdateCommand.CommandText = myUpdateQuery;
						myUpdateCommand.Connection = conn1;
						myUpdateCommand.ExecuteNonQuery();
						conn1.Close();
						Label2.Visible = true;
						lblLabCD.Text = Convert.ToString(st);
						Label2.Visible = true;
						lblLabCD.Visible = true;
						btnSave.Enabled = false;
						DisplayAlert("Your Record is Saved!!!");
					}

				}
				else if (Action == "M")
				{
					int code = Convert.ToInt32(lblLabCD.Text.Trim());
					string myUpdateQuery = "Update T65_LABORATORY_MASTER set LAB_NAME ='" + (txtLabName.Text) + "', LAB_ADDRESS= '" + txtAdd1.Text + "',LAB_CITY=" + lstCity.SelectedItem.Value + ",LAB_CONTACT_PER= '" + txtConPer1.Text + "',LAB_CONTACT_TEL= '" + txtTel1.Text + "',LAB_EMAIL='" + txtEmail.Text + "', LAB_APPROVAL= '" + lstLabApp.SelectedItem.Value + "', LAB_APPROVAL_FR= to_date('" + txtAppFrom.Text + "','dd/mm/yyyy'),LAB_APPROVAL_TO= to_date('" + txtAppTo.Text + "','dd/mm/yyyy'),USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where LAB_ID=" + code;
					OracleCommand myUpdateCommand = new OracleCommand();
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					conn1.Open();
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();
					btnSave.Visible = true;
					DisplayAlert("Your Record is Updated!!!");
				}
				btnAdd.Visible = true;
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
				conn1.Dispose();
			}

		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(("Laboratory_Master_Form.aspx"));
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Laboratory_Search_Form.aspx");
		}
	}
}