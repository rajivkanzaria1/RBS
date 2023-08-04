using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.ERP_Problems_Form
{
	public partial class ERP_Problems_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		private int code = new int();
		string Action;


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.Params["ERP_PROB_ID"]) == null || Convert.ToString(Request.Params["ERP_PROB_ID"]) == "")
			{
				code = 0;
				Action = "";
				Label6.Visible = false;
				txtResolution.Visible = false;

			}
			else
			{
				code = Convert.ToInt32(Request.Params["ERP_PROB_ID"].Trim());
				Action = Convert.ToString(Request.Params["ACTION"].Trim());
				Label6.Visible = true;
				txtResolution.Visible = true;
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
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			int CD;
			try
			{
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				if (code == 0)
				{
					string str3 = "select NVL(max(ERP_PROB_ID),0) from ERP_PROBLEMS";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = str3;
					myInsertCommand.Connection = conn1;
					CD = Convert.ToInt32(myInsertCommand.ExecuteScalar());
					CD = (CD + 1);
					string myInsertQuery = "INSERT INTO ERP_PROBLEMS (ERP_PROB_ID,NAME,PROB_DESC,DATETIME) values(" + CD + ",'" + txtName.Text + "','" + txtDesc.Text + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					txtName.Text = "";
					txtDesc.Text = "";
					DisplayAlert("Your Record is Saved!!!");
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
	}
}