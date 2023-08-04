using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.UOM_Form
{
	public partial class UOM_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		private int code = new int();
		string Action;


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");

			if (Convert.ToString(Request.Params["UOM_CD"]) == null || Convert.ToString(Request.Params["UOM_CD"]) == "")
			{
				code = 0;
				Action = "";
			}
			else
			{
				code = Convert.ToInt32(Request.Params["UOM_CD"].Trim());
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
				if (Convert.ToString(Session["Role"]) != "Administrator")
				{
					btnSave.Enabled = false;
					btnDelConfirm.Enabled = false;
					grdUOM.Columns[0].Visible = false;
					grdUOM.Columns[1].Visible = false;
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
			this.grdUOM.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grdUOM_PageIndexChanged);

		}
		#endregion


		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select * from T04_UOM where UOM_CD=" + code;
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
					txtLDesc.Text = dsP.Tables[0].Rows[0]["UOM_L_DESC"].ToString();
					txtSDesc.Text = dsP.Tables[0].Rows[0]["UOM_S_DESC"].ToString();
					txtMULFactor.Text = dsP.Tables[0].Rows[0]["UOM_FACTOR"].ToString();
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



		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select * from T04_UOM order by UOM_S_DESC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdUOM.Visible = false;
				}
				else
				{
					grdUOM.Visible = true;
					grdUOM.DataSource = dsP;
					grdUOM.DataBind();
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
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			int CD;
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			try
			{
				if (code == 0)
				{
					string str1 = "select NVL(max(UOM_CD),0) from T04_UOM";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = str1;
					myInsertCommand.Connection = conn1;
					CD = Convert.ToInt32(myInsertCommand.ExecuteScalar());
					code = CD + 1;
					string myInsertQuery = "INSERT INTO T04_UOM values(" + code + ", '" + txtLDesc.Text + "', '" + txtSDesc.Text + "'," + txtMULFactor.Text + ", '" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'')";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();

				}
				else
				{
					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T04_UOM set UOM_L_DESC ='" + txtLDesc.Text + "', UOM_S_DESC = '" + txtSDesc.Text + "', UOM_FACTOR= " + txtMULFactor.Text + ", USER_ID='" + Session["Uname"].ToString() + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where UOM_CD=" + code;
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
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
			}
			Response.Redirect("UOM_Form.aspx");
		}


		protected void btnDelConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{
				string myDeleteQuery = "Delete T04_UOM where UOM_CD=" + code;
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
				if (str1.Substring(0, 9).Equals("ORA-02292"))
				{ DisplayAlert("Cannot Delete the Unit of Measurement. It is being used by the System."); }
				else
				{ Response.Redirect(("Error_Form.aspx?err=" + str1)); }
			}
			finally
			{
				conn1.Close();
			}
			Response.Redirect("UOM_Form.aspx");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("UOM_Form.aspx");
		}

		private void grdUOM_PreRender(object sender, System.EventArgs e)
		{
			fillgrid();
		}

		private void grdUOM_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{

			grdUOM.CurrentPageIndex = e.NewPageIndex;
			grdUOM.DataBind();
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			DataSet dsP1 = new DataSet();
			string str1 = "select UOM_CD,UOM_L_DESC,UOM_S_DESC,UOM_FACTOR from T04_UOM";

			if (txtSDesc.Text.Trim() != "" || txtLDesc.Text.Trim() != "")
			{
				if (txtSDesc.Text.Trim() != "" && txtLDesc.Text.Trim() == "")
				{
					str1 = str1 + " where upper(UOM_S_DESC) like upper('" + txtSDesc.Text.Trim() + "%')";
				}
				else if (txtLDesc.Text.Trim() != "" && txtSDesc.Text.Trim() == "")
				{
					str1 = str1 + " where upper(UOM_L_DESC) like upper('%" + txtLDesc.Text.Trim() + "%')";
				}
				else if (txtLDesc.Text.Trim() != "" && txtSDesc.Text.Trim() != "")
				{
					str1 = str1 + " where upper(UOM_S_DESC) like upper('" + txtSDesc.Text.Trim() + "%') and upper(UOM_L_DESC) like upper('%" + txtLDesc.Text.Trim() + "%')";
				}

			}

			str1 = str1 + " order by UOM_S_DESC";

			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			dsP1.Clear();
			da.Fill(dsP1, "Table");
			if (dsP1.Tables[0].Rows.Count == 0)
			{
				grdUOM.Visible = false;

			}
			else
			{
				grdUOM.DataSource = dsP1;
				grdUOM.DataBind();
				grdUOM.Visible = true;

			}
			conn1.Close();
		}


	}
}