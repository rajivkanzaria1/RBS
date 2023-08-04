using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Central_QOI_Form
{
	public partial class Central_QOI_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string wYrMth;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Session["Region"].ToString() == "C")
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
			else
			{
				//DisplayAlert("This Form Access allowed only Central Region!!!");
				string str2 = "This Form Access allowed only Central Region!!!";
				Response.Redirect(("Error_Form.aspx?err=" + str2));

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
			try
			{
				wYrMth = lstYear.SelectedValue + lstMonths.SelectedValue;
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();

				string Expcheckquery = "Select count(*) from T78_CENTRAL_QOI where QTY_DATE= '" + wYrMth + "' and region_code='" + Session["Region"].ToString() + "' and CLIENT='" + lstclient.SelectedValue + "'";
				OracleCommand ExpcheckCommand = new OracleCommand(Expcheckquery, conn1);
				conn1.Open();
				System.Data.DataSet ds = new DataSet();
				OracleDataAdapter adapter = new OracleDataAdapter(ExpcheckCommand);
				adapter.Fill(ds);
				conn1.Close();
				if (Convert.ToInt64(ds.Tables[0].Rows[0][0]) > 0)
				{
					DisplayAlert("Selected Period and Client Already Exist!!!");
					return;
				}
				else
				{
					string Expquery = "insert into T78_CENTRAL_QOI(TOTAL_QTY_DISPATCHED, NO_OF_IC_ISSUED, CLIENT, QTY_DATE, REGION_CODE, USER_ID, DATETIME) " +
						"VALUES('" + Convert.ToInt64(Textdispatched.Text) + "','" + Convert.ToInt64(Textic.Text) + "','" + lstclient.SelectedValue + "','" + wYrMth + "','" + Session["Region"].ToString() + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand ClientCommand = new OracleCommand();
					ClientCommand.CommandText = Expquery;
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
				Textdispatched.Text = "";
				Textic.Text = "";
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