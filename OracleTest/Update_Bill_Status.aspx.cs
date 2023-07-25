using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class Update_Bill_Status : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");

			if (!(IsPostBack))
			{
				if (Session["Role_CD"].ToString() == "4")
				{
					btnSave.Visible = false;

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

			try
			{
				OracleCommand myUpdateCommand = new OracleCommand();
				string myUpdateQuery = "Update T22_BILL set BILL_STATUS = 'U' where substr(BILL_NO,1,1)='" + Session["Region"].ToString() + "'  and ";

				string bnos = "";
				if (txtBNO1.Text.Trim() != "")
				{
					bnos = bnos + "'" + txtBNO1.Text.Trim() + "'";
				}
				if (txtBNO2.Text.Trim() != "")
				{
					bnos = bnos + ",'" + txtBNO2.Text.Trim() + "'";
				}
				if (txtBNO3.Text.Trim() != "")
				{
					bnos = bnos + ",'" + txtBNO3.Text.Trim() + "'";
				}
				if (txtBNO4.Text.Trim() != "")
				{
					bnos = bnos + ",'" + txtBNO4.Text.Trim() + "'";
				}
				if (txtBNO5.Text.Trim() != "")
				{
					bnos = bnos + ",'" + txtBNO5.Text.Trim() + "'";
				}
				myUpdateQuery = myUpdateQuery + "BILL_NO IN(" + bnos + ")";
				myUpdateCommand.CommandText = myUpdateQuery;
				myUpdateCommand.Connection = conn1;
				conn1.Open();
				myUpdateCommand.ExecuteNonQuery();
				txtBNO1.Text = "";
				txtBNO2.Text = "";
				txtBNO3.Text = "";
				txtBNO4.Text = "";
				txtBNO5.Text = "";

				DisplayAlert("Your record has been updated!!!");
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




		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}
	}
}

