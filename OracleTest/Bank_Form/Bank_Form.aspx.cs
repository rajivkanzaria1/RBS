using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Bank_Form
{
    public partial class Bank_Form : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		private DataSet dsP = new DataSet();
		public string Action;
		int code = 0;


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");


			if (Convert.ToString(Request.Params["BANK_CD"]) == null || Convert.ToString(Request.Params["BANK_CD"]) == "")
			{
				code = 0;
				Action = "";
			}
			else
			{
				code = Convert.ToInt32(Request.Params["BANK_CD"].Trim());
				Action = Convert.ToString(Request.Params["ACTION"].Trim());

			}

			if (!IsPostBack)
			{
				if (Action == "E")
				{
					show();
					btnDelConfirm.Visible = false;
					btnSave.Visible = true;
				}
				else if (Action == "D")
				{
					show();
					btnDelConfirm.Visible = true;
					btnSave.Visible = false;

				}
				if (Convert.ToString(Session["Role"]) != "Administrator")
				{
					btnSave.Enabled = false;
					btnDelConfirm.Enabled = false;
					grdBank.Columns[0].Visible = false;
					grdBank.Columns[1].Visible = false;
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


		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{

			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			try
			{
				if ((code == 0))
				{
					string str3 = "select NVL(max(BANK_CD),0)+1 from T94_BANK where BANK_CD < 990";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = str3;
					myInsertCommand.Connection = conn1;

					int bcode = Convert.ToInt32(myInsertCommand.ExecuteScalar());

					string myInsertQuery = "INSERT INTO T94_Bank values(" + bcode + ",'" + txtBankName.Text.TrimEnd().TrimStart() + "','" + txtFMISBCD.Text.TrimEnd().TrimStart() + "', '" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
				}
				else
				{

					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T94_BANK set BANK_NAME ='" + txtBankName.Text.TrimEnd().TrimStart() + "',FMIS_BANK_CD='" + txtFMISBCD.Text + "', USER_ID='" + Session["Uname"].ToString() + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where BANK_CD=" + code + "";
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					int count = myUpdateCommand.ExecuteNonQuery();
					if ((count == 0))
					{
						throw new System.Exception("No Record Found!!! Any Other User had Deleted Your Record While you were Modifying");
					}
					conn1.Close();
				}
				Response.Redirect("Bank_Form.aspx");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				DisplayAlert(str1);
			}
			finally
			{
				conn1.Close();
			}


		}
		void show()
		{
			try
			{
				//code = Convert.ToInt32(txtBankCD.Text);
				string str1 = "select * from T94_Bank where BANK_CD=" + code + "";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand1;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{
					txtBankName.Text = dsP.Tables[0].Rows[0]["BANK_NAME"].ToString();
					txtFMISBCD.Text = dsP.Tables[0].Rows[0]["FMIS_BANK_CD"].ToString();
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

				string myDeleteQuery = "Delete T94_Bank where BANK_CD=" + code + "";
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
			Response.Redirect("Bank_Form.aspx");

		}


		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			DataSet dsP1 = new DataSet();
			string str1 = "select BANK_CD,BANK_NAME,FMIS_BANK_CD from T94_BANK";

			if (txtBankName.Text.Trim() != "" && txtFMISBCD.Text.Trim() != "")
			{
				str1 = str1 + " where upper(BANK_NAME) Like upper('" + txtBankName.Text.Trim() + "%') and FMIS_BANK_CD='" + txtFMISBCD.Text.Trim() + "'";
			}
			else if (txtBankName.Text.Trim() != "")
			{
				str1 = str1 + " where upper(BANK_NAME) Like upper('" + txtBankName.Text.Trim() + "%')";

			}
			else if (txtFMISBCD.Text.Trim() != "")
			{
				str1 = str1 + " where FMIS_BANK_CD='" + txtFMISBCD.Text.Trim() + "'";

			}

			str1 = str1 + " order by BANK_NAME";

			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			dsP1.Clear();
			da.Fill(dsP1, "Table");
			if (dsP1.Tables[0].Rows.Count == 0)
			{
				grdBank.Visible = false;

			}
			else
			{

				try
				{
					//int aa=grdCity.CurrentPageIndex;
					grdBank.DataSource = dsP1;
					grdBank.DataBind();
					grdBank.Visible = true;
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str2 = str.Replace("\n", "");

				}
				finally
				{
					conn1.Close();
				}
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Bank_Form.aspx");
		}
	}
}
