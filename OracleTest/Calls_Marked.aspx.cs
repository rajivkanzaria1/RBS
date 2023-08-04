using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Calls_Marked
{
	public partial class Calls_Marked : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			OracleCommand cmd = new OracleCommand("Select to_char(add_months(sysdate,-1),'dd/mm/yyyy')DtFr,to_char(sysdate,'dd/mm/yyyy')DtTo from dual", conn);
			conn.Open();
			OracleDataReader reader = cmd.ExecuteReader();
			if (!(IsPostBack))
			{
				while (reader.Read())
				{
					txtDtFr.Text = Convert.ToString(reader["DtFr"]);
					txtDtTo.Text = Convert.ToString(reader["DtTo"]);
				}
				reader.Close();
				conn.Close();
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

		protected void btnShow_Click(object sender, System.EventArgs e)
		{
			string wSortKey = "";
			if (radioVendor.Checked == true) { wSortKey = "V"; }
			else { wSortKey = "D"; }
			Response.Redirect("Calls_Marked_Report.aspx?pDtFr=" + txtDtFr.Text + "&pDtTo=" + txtDtTo.Text + "&pRegion=" + Session["Region"].ToString() + "&pSortKey=" + wSortKey);
		}

	}
}