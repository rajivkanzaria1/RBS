using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Railways_Form
{
	public partial class Railways_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string code, Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");

			if (Convert.ToString(Request.Params["RLY_CD"]) == null || Convert.ToString(Request.Params["RLY_CD"]) == "")
			{
				code = "";
				Action = "";
			}
			else
			{
				code = Convert.ToString(Request.Params["RLY_CD"].Trim());
				Action = Convert.ToString(Request.Params["ACTION"].Trim());
			}

			if (!(IsPostBack))
			{
				if (Action == "D")
				{
					show();
					btnSave.Visible = false;
					btnDelConfirm.Visible = true;
				}
				else if (Action == "E")
				{
					show();
					btnSave.Enabled = true;
				}
				else
				{
					txtRlyCD.Enabled = true;
				}
				fillgrid();

				if (Convert.ToString(Session["Role"]) != "Administrator")
				{
					btnSave.Enabled = false;
					btnDelConfirm.Enabled = false;
					grdRailways.Columns[0].Visible = false;
					grdRailways.Columns[1].Visible = false;
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

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			fillgrid();
		}
		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select * from T91_RAILWAYS order by RLY_CD";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdRailways.Visible = false;
				}
				else
				{
					grdRailways.Visible = true;
					grdRailways.DataSource = dsP;
					grdRailways.DataBind();
				}
				conn1.Close();
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
		}


		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			try
			{


				if (code == "")
				{
					OracleCommand myInsertCommand = new OracleCommand();
					string myInsertQuery = "INSERT INTO T91_RAILWAYS values('" + txtRlyCD.Text.Trim() + "', '" + txtRailProUnit.Text + "', '" + txtHQuater.Text + "', '" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'')";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
				}
				else
				{

					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T91_RAILWAYS set RAILWAY ='" + txtRailProUnit.Text + "', HEAD_QUARTER = '" + txtHQuater.Text + "', USER_ID='" + Session["Uname"].ToString() + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where RLY_CD='" + code + "'";
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					myUpdateCommand.ExecuteNonQuery();
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
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
			}
			Response.Redirect("Railways_Form.aspx");
		}
		void show()
		{

			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select * from T91_RAILWAYS where RLY_CD='" + code + "'";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code.");
				}
				else
				{
					txtRlyCD.Text = dsP.Tables[0].Rows[0]["RLY_CD"].ToString();
					txtRlyCD.Enabled = false;
					txtRailProUnit.Text = dsP.Tables[0].Rows[0]["RAILWAY"].ToString();
					txtHQuater.Text = dsP.Tables[0].Rows[0]["HEAD_QUARTER"].ToString();
				}
				conn1.Close();

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
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnDelConfirm_Click(object sender, System.EventArgs e)
		{


			OracleCommand cmd1 = new OracleCommand("select count(*) from T06_CONSIGNEE where CONSIGNEE_FIRM='" + txtRlyCD.Text + "' and CONSIGNEE_TYPE='R'", conn1);
			conn1.Open();
			int count = Convert.ToInt32(cmd1.ExecuteScalar());
			conn1.Close();
			if (count == 0)
			{

				OracleCommand cmd2 = new OracleCommand("select count(*) from T12_BILL_PAYING_OFFICER where BPO_RLY='" + txtRlyCD.Text + "' and BPO_TYPE='R'", conn1);
				conn1.Open();
				count = Convert.ToInt32(cmd2.ExecuteScalar());
				conn1.Close();
				if (count == 0)
				{
					try
					{
						string myDeleteQuery = "Delete T91_RAILWAYS where RLY_CD='" + code + "'";
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
					Response.Redirect("Railways_Form.aspx");

				}
				else
				{
					DisplayAlert("You Cannot Delete this Raliway Code, because their is a record present for this Railway Code in BPO Master!!!");
				}

			}
			else
			{
				DisplayAlert("You Cannot Delete this Raliway Code, because their is a record present for this Railway Code in Consignee Master!!!");
			}

		}

		private void grdRailways_PreRender(object sender, System.EventArgs e)
		{
			fillgrid();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Railways_Form.aspx");
		}

		private void grdRailways_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grdRailways.CurrentPageIndex = e.NewPageIndex;
			grdRailways.DataBind();
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			DataSet dsP1 = new DataSet();
			string str1 = "select RLY_CD,RAILWAY,HEAD_QUARTER from T91_RAILWAYS";

			if (txtRlyCD.Text.Trim() != "" || txtRailProUnit.Text.Trim() != "")
			{
				if (txtRlyCD.Text.Trim() != "" && txtRailProUnit.Text.Trim() == "")
				{
					str1 = str1 + " where upper(RLY_CD) like upper('" + txtRlyCD.Text.Trim() + "%')";
				}
				else if (txtRailProUnit.Text.Trim() != "" && txtRlyCD.Text.Trim() == "")
				{
					str1 = str1 + " where upper(RAILWAY) like upper('%" + txtRailProUnit.Text.Trim() + "%')";
				}
				else if (txtRlyCD.Text.Trim() != "" && txtRailProUnit.Text.Trim() != "")
				{
					str1 = str1 + " where upper(RLY_CD) like upper('" + txtRlyCD.Text.Trim() + "%') and upper(RAILWAY) like upper('%" + txtRailProUnit.Text.Trim() + "%')";
				}

			}

			str1 = str1 + " order by RLY_CD";

			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			dsP1.Clear();
			da.Fill(dsP1, "Table");
			if (dsP1.Tables[0].Rows.Count == 0)
			{
				grdRailways.Visible = false;

			}
			else
			{
				grdRailways.DataSource = dsP1;
				grdRailways.DataBind();
				grdRailways.Visible = true;

			}
			conn1.Close();
		}



	}
}