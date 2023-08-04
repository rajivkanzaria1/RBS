using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.BE_Target_Form
{
	public partial class BE_Target_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string wYrMth;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			if (!(IsPostBack))
			{
				OracleCommand cmd = new OracleCommand("select to_char(sysdate,'yyyy') from dual", conn1);
				conn1.Open();
				int yr = Convert.ToInt32(cmd.ExecuteScalar());
				conn1.Close();
				ListItem lst = new ListItem();
				for (int i = yr; i >= 2008; i--)
				{
					lst = new ListItem();
					lst.Text = i.ToString();
					lst.Value = i.ToString();
					lstYear.Items.Add(lst);
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
				wYrMth = lstYear.SelectedValue;
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();

				string BEcheckquery = "Select count(*) from T83_BE_TARGET where BE_PER= '" + wYrMth + "' and region_code='" + Session["Region"].ToString() + "'";
				OracleCommand BEcheckCommand = new OracleCommand(BEcheckquery, conn1);
				conn1.Open();
				System.Data.DataSet ds = new DataSet();
				OracleDataAdapter adapter = new OracleDataAdapter(BEcheckCommand);
				adapter.Fill(ds);
				conn1.Close();
				if (Convert.ToInt64(ds.Tables[0].Rows[0][0]) > 0)
				{
					DisplayAlert("Selected Period Already Exist!!!");
					return;
				}
				else
				{
					string BEquery = "insert into T83_BE_TARGET(BE_PER, B_TARGET, E_TARGET, REGION_CODE, USER_ID, DATETIME, EX_TARGET) " +
						"VALUES('" + wYrMth + "','" + Convert.ToDecimal(Textbillamt.Text) + "','" + Convert.ToDecimal(Textexpamt.Text) + "','" + Session["Region"].ToString() + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + Convert.ToDecimal(Textex.Text) + "')";
					OracleCommand ClientCommand = new OracleCommand();
					ClientCommand.CommandText = BEquery;
					ClientCommand.Connection = conn1;
					conn1.Open();
					ClientCommand.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("Your Record is Saved!!!");
				}
				Reset();

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

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{

		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}
		void Reset()
		{
			try
			{
				//lstMonths.Items.Clear();
				//lstYear.Items.Clear();
				Textbillamt.Text = "";
				Textexpamt.Text = "";
			}
			catch (Exception ex)
			{
				string str1;
				str1 = ex.Message;
				string str2 = str1.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str2));
			}

		}
	}
}