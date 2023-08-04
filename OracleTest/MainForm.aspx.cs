using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.MainForm
{
	public partial class MainForm : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn1.Open();
			//			OracleCommand cmd11 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
			//			string sdate=Convert.ToString(cmd11.ExecuteScalar());
			//			string str3 = "select MESSAGE from T96_MESSAGES where REGION_CODE='"+Session["Region"]+"' and DATETIME=to_date('"+sdate+"','dd/mm/yyyy') order by MESSAGE";
			//			OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1); 
			//			
			//			OracleDataReader reader1 = myOracleCommand3.ExecuteReader();
			//			int n=1;
			//			while(reader1.Read())
			//			{
			//			
			//				lblMessage.Text= lblMessage.Text + n + ") " +reader1["MESSAGE"].ToString() + "<br>";
			//				n=n+1;
			//				
			//			}
			//			if(reader1.HasRows==true)
			//			{
			//				lblMessage.Visible=true;
			//			}
			//			else
			//			{
			//				lblMessage.Visible=false;
			//			}
			//			conn1.Close();

			//Response.Write("<MARQUEE dataFormatAs='html' style='FONT-SIZE: 10pt; WIDTH: 100%; FONT-FAMILY: Verdana; HEIGHT: 100%' scrollDelay='125' behavior='alternate' width='100%'>" + lblMessage.Text+"</MARQUEE>");

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
	}
}