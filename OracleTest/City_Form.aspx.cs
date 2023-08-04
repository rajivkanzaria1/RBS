using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.City_Form
{
	public partial class City_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		private int code = new int();
		string Action;
		DataSet dsP = new DataSet();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");


			if (Convert.ToString(Request.Params["CITY_CD"]) == null || Convert.ToString(Request.Params["CITY_CD"]) == "")
			{
				code = 0;
				Action = "";
			}
			else
			{
				code = Convert.ToInt32(Request.Params["CITY_CD"].Trim());
				Action = Convert.ToString(Request.Params["ACTION"].Trim());
			}

			if (!(IsPostBack))
			{

				string str1 = "select STATE_CD,STATE_NAME from T92_STATE order by STATE_NAME";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				for (int i = 0; (i <= (dsP.Tables[0].Rows.Count - 1)); i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["STATE_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["STATE_CD"].ToString();
					lstState.Items.Add(lst);
				}
				lstState.Items.Insert(0, "");
				conn1.Close();


				if (Action == "D")
				{
					show();
					search();
					btnSave.Visible = false;
					btnDelConfirm.Visible = true;
				}
				else if (Action == "E")
				{
					show();
					search();
					btnSave.Enabled = true;
				}

				//				fillgrid();
				if (Convert.ToString(Session["Role"]) != "Administrator" || Convert.ToString(Session["Region"]) != "N")
				{
					btnSave.Enabled = false;
					btnDelConfirm.Enabled = false;
					grdCity.Columns[0].Visible = false;
					grdCity.Columns[1].Visible = false;
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
			int CD;
			conn1.Open();
			try
			{
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());

				if (code == 0)
				{
					string str3 = "select NVL(max(CITY_CD),0) from T03_CITY";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = str3;
					myInsertCommand.Connection = conn1;
					CD = Convert.ToInt32(myInsertCommand.ExecuteScalar());
					code = (CD + 1);
					string myInsertQuery = "INSERT INTO T03_CITY values(" + code + ",'" + txtLocation.Text + "','" + txtCity.Text + "','" + lstState.SelectedValue + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + txtPIN.Text + "')";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
				}
				else
				{
					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T03_CITY set LOCATION ='" + txtLocation.Text.TrimEnd().TrimStart() + "', CITY = '" + txtCity.Text.TrimEnd().TrimStart() + "',STATE_CD='" + lstState.SelectedValue + "',USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), PIN_CODE='" + txtPIN.Text + "' where CITY_CD=" + code;
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					int count = myUpdateCommand.ExecuteNonQuery();
					if ((count == 0))
					{
						throw new System.Exception("No Record Found!!! Any Other User had Deleted Your Record While you were Modifying");
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
			Response.Redirect("City_Form.aspx");

		}

		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = ("select * from T03_CITY where CITY_CD=" + code);
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{
					txtLocation.Text = dsP.Tables[0].Rows[0]["LOCATION"].ToString();
					txtCity.Text = dsP.Tables[0].Rows[0]["CITY"].ToString();
					txtPIN.Text = dsP.Tables[0].Rows[0]["PIN_CODE"].ToString();
					lstState.SelectedValue = Convert.ToString(dsP.Tables[0].Rows[0]["STATE_CD"]);
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






		protected void btnDelConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{
				string myDeleteQuery = ("Delete T03_CITY where CITY_CD=" + code);
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
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
			Response.Redirect("City_Form.aspx");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("City_Form.aspx");
		}

		private void grdCity_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grdCity.CurrentPageIndex = e.NewPageIndex;
			grdCity.DataBind();

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
				string str1 = "select C.CITY_CD,C.LOCATION,C.CITY,S.STATE_NAME from T03_CITY C, T92_STATE S where C.STATE_CD=S.STATE_CD(+) order by C.CITY";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCity.Visible = false;
				}
				else
				{
					grdCity.Visible = true;
					grdCity.DataSource = dsP;
					grdCity.DataBind();
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
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			search();
		}
		void search()
		{
			DataSet dsP1 = new DataSet();
			string str1 = "select C.CITY_CD,C.LOCATION,C.CITY,S.STATE_NAME,PIN_CODE from T03_CITY C, T92_STATE S where C.STATE_CD=S.STATE_CD(+)";
			if (txtLocation.Text.Trim() != "")
			{
				str1 = str1 + " and upper(LOCATION) Like upper('" + txtLocation.Text.Trim() + "%')";
				//grdCity.CurrentPageIndex=0;
			}
			if (txtCity.Text.Trim() != "")
			{
				str1 = str1 + " and upper(CITY) LIKE upper('" + txtCity.Text.Trim() + "%')";
				//grdCity.CurrentPageIndex=0;
			}


			str1 = str1 + " order by C.CITY";

			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			dsP1.Clear();
			da.Fill(dsP1, "Table");
			if (dsP1.Tables[0].Rows.Count == 0)
			{
				grdCity.Visible = false;

			}
			else
			{

				try
				{
					//int aa=grdCity.CurrentPageIndex;
					grdCity.DataSource = dsP1;
					if (grdCity.CurrentPageIndex > (dsP1.Tables[0].Rows.Count / 15))
					{
						grdCity.CurrentPageIndex = 0;
					}
					grdCity.DataBind();
					grdCity.Visible = true;
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str2 = str.Replace("\n", "");
					//DisplayAlert("Sorry, their is some error in search. so, plz try again!!!");
					Response.Redirect("City_form.aspx");
				}
				finally
				{
					conn1.Close();
				}

			}
			conn1.Close();

		}
	}
}