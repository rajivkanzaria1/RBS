using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Rly_Designation_Form
{
	public partial class Rly_Designation_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		private string code, Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");

			if (Convert.ToString(Request.Params["RLY_DESIG_CD"]) == null || Convert.ToString(Request.Params["RLY_DESIG_CD"]) == "")
			{
				code = "";
				Action = "";
			}
			else
			{
				code = Convert.ToString(Request.Params["RLY_DESIG_CD"].Trim());
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
				fillgrid();
				if (Convert.ToString(Session["Role"]) != "Administrator")
				{
					btnSave.Enabled = false;
					btnDelConfirm.Enabled = false;
					grdDesig.Columns[0].Visible = false;
					grdDesig.Columns[1].Visible = false;
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


		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select * from T90_RLY_DESIGNATION order by RLY_DESIG_CD";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdDesig.Visible = false;
				}
				else
				{
					grdDesig.Visible = true;
					grdDesig.DataSource = dsP;
					grdDesig.DataBind();
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


			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			try
			{
				if ((code == ""))
				{
					string myInsertQuery = "INSERT INTO T90_RLY_DESIGNATION values('" + txtDesigCD.Text.Trim() + "', '" + txtSDesc.Text.TrimEnd().TrimStart() + "', '" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
				}
				else
				{

					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T90_RLY_DESIGNATION set RLY_DESIG_DESC = '" + txtSDesc.Text.TrimEnd().TrimStart() + "', USER_ID='" + Session["Uname"].ToString() + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where RLY_DESIG_CD='" + code + "'";
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
			Response.Redirect("Rly_Designation_Form.aspx");
		}
		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select * from T90_RLY_DESIGNATION where RLY_DESIG_CD='" + code + "'";
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
					txtDesigCD.Text = dsP.Tables[0].Rows[0]["RLY_DESIG_CD"].ToString();
					txtSDesc.Text = dsP.Tables[0].Rows[0]["RLY_DESIG_DESC"].ToString();
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
			OracleCommand cmd2 = new OracleCommand("select count(*) from T06_CONSIGNEE where CONSIGNEE_DESIG='" + txtDesigCD.Text + "' and CONSIGNEE_TYPE='R'", conn1);
			conn1.Open();
			int count = Convert.ToInt32(cmd2.ExecuteScalar());
			conn1.Close();
			if (count == 0)
			{

				try
				{
					string myDeleteQuery = "Delete T90_RLY_DESIGNATION where RLY_DESIG_CD='" + code + "'";
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
				}
				finally
				{
					conn1.Close();
				}
				Response.Redirect("Rly_Designation_Form.aspx");
			}
			else
			{
				DisplayAlert("You Cannot Delete this Raliway Designation Code, because their is a record present for this Designation Code in Consignee Master!!!");
			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Rly_Designation_Form.aspx");
		}

		private void grdDesig_PreRender(object sender, System.EventArgs e)
		{
			fillgrid();

		}

		private void grdDesig_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grdDesig.CurrentPageIndex = e.NewPageIndex;
			grdDesig.DataBind();
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			DataSet dsP = new DataSet();
			string str1 = "select * from T90_RLY_DESIGNATION";

			if (txtSDesc.Text.Trim() != "" && txtDesigCD.Text.Trim() != "")
			{
				str1 = str1 + " where upper(RLY_DESIG_DESC) Like upper('" + txtSDesc.Text.Trim() + "%') and upper(RLY_DESIG_CD) LIKE upper('" + txtDesigCD.Text.Trim() + "%')";
			}
			else if (txtSDesc.Text.Trim() != "")
			{
				str1 = str1 + " where upper(RLY_DESIG_DESC) Like upper('" + txtSDesc.Text.Trim() + "%')";
			}
			else if (txtDesigCD.Text.Trim() != "")
			{
				str1 = str1 + " where upper(RLY_DESIG_CD) LIKE upper('" + txtDesigCD.Text.Trim() + "%')";
			}

			str1 = str1 + " order by RLY_DESIG_CD";

			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				grdDesig.Visible = false;

			}
			else
			{
				grdDesig.DataSource = dsP;
				if (grdDesig.CurrentPageIndex > (dsP.Tables[0].Rows.Count / 15))
				{
					grdDesig.CurrentPageIndex = 0;
				}
				grdDesig.DataBind();
				grdDesig.Visible = true;

			}
			conn1.Close();
		}
	}
}