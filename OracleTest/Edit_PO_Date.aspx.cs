using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Edit_PO_Date
{
	public partial class Edit_PO_Date : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string csno, ss;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.QueryString["CASE_NO"]) != null || Convert.ToString(Request.QueryString["CASE_NO"]) != "")
			{
				csno = Request.QueryString["CASE_NO"];
			}
			if (!(IsPostBack))
			{
				OracleCommand cmd = new OracleCommand("select to_char(PO_DT,'dd/mm/yyyy') from T13_PO_MASTER where CASE_NO='" + csno + "'", conn1);
				string test = "";
				conn1.Open();
				test = Convert.ToString(cmd.ExecuteScalar());
				conn1.Close();
				lblCasNo.Text = csno;
				lblPODate.Text = test;
				txtPODT.Text = test;

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

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("PurchesOrder1_Form.aspx");
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				ss = Convert.ToString(cmd2.ExecuteScalar());


				OracleCommand cmd4 = new OracleCommand("update T13_PO_MASTER set PO_DT = to_date('" + txtNewPODT.Text + "','dd/mm/yyyy'),USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO = '" + lblCasNo.Text + "'", conn1);
				cmd4.ExecuteNonQuery();
				lblPODate.Text = txtNewPODT.Text;
				DisplayAlert("Your Record is Updated!!!");
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