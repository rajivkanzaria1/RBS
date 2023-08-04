using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.User_Delete
{
	public partial class User_Delete : System.Web.UI.Page
	{
		string f_Ucode;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnYes.Attributes.Add("OnClick", "JavaScript:del();");
			if (!(IsPostBack))
			{
				Label2.Text = Label2.Text + " " + Request.QueryString["USER_ID"].ToString();
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

		protected void btnYes_Click(object sender, System.EventArgs e)
		{
			f_Ucode = Request.QueryString["USER_ID"].ToString();
			string w_myDeleteQuery = "Delete T02_USERS where USER_ID='" + f_Ucode + "'";
			OracleCommand w_myOracleCommand = new OracleCommand(w_myDeleteQuery);
			w_myOracleCommand.Connection = conn1;
			conn1.Open();
			w_myOracleCommand.ExecuteNonQuery();
			Response.Redirect("User_Administration.aspx");
			conn1.Close();
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("User_Administration.aspx");
		}
	}
}