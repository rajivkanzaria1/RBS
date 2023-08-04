using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Designation_Form
{
	public partial class Designation_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string Action;
		private int code = new int();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");

			if (Convert.ToString(Request.Params["R_DESIG_CD"]) == null || Convert.ToString(Request.Params["R_DESIG_CD"]) == "")
			{
				code = 0;
				Action = "";
			}
			else
			{
				code = Convert.ToInt32(Request.Params["R_DESIG_CD"].Trim());
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
				string str1 = "select * from T07_RITES_DESIG order by R_DESIG_CD";
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
			int cd;

			conn1.Open();
			try
			{
				if ((code == 0))
				{
					string str3 = "select NVL(max(R_DESIG_CD),0) from T07_RITES_DESIG";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = str3;
					myInsertCommand.Connection = conn1;
					cd = Convert.ToInt32(myInsertCommand.ExecuteScalar());
					code = cd + 1;
					string myInsertQuery = "INSERT INTO T07_RITES_DESIG values(" + code + ", '" + txtSDesc.Text.TrimEnd().TrimStart() + "')";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
				}
				else
				{

					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T07_RITES_DESIG set R_DESIGNATION = '" + txtSDesc.Text.TrimEnd().TrimStart() + "' where R_DESIG_CD=" + code;
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
			Response.Redirect("Designation_Form.aspx");



		}
		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select * from T07_RITES_DESIG where R_DESIG_CD=" + code;
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
					txtSDesc.Text = dsP.Tables[0].Rows[0]["R_DESIGNATION"].ToString();
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

				string myDeleteQuery = "Delete T07_RITES_DESIG where R_DESIG_CD=" + code;
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
			Response.Redirect("Designation_Form.aspx");
		}

		protected void grdDesig_PreRender(object sender, System.EventArgs e)
		{
			fillgrid();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Designation_Form.aspx");
		}
	}
}