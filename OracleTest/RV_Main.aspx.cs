using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.RV_Main
{
	public partial class RV_Main : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		//string BNO;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//btnAdd.Attributes.Add("OnClick", "JavaScript:validate();"); 
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");


			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["BILL_NO"]) != "")
				{
					string VNO = Convert.ToString(Request.Params["VCHR_NO"]);
					txtVNo.Text = VNO;

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

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			string code = txtVNo.Text;
			Response.Redirect("RV_Entry.aspx?Action=A&VOUCHER_NO=" + code);

		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			string code = txtVNo.Text;

			string str4 = "select VCHR_NO from T24_RV  where VCHR_NO= '" + code + "'";
			OracleCommand myCommand = new OracleCommand();
			myCommand.CommandText = str4;
			myCommand.Connection = conn1;
			conn1.Open();
			string CD = Convert.ToString(myCommand.ExecuteScalar());
			conn1.Close();
			if (CD == "")
			{
				DisplayAlert("Voucher Not Found For the Given Bill No.");
			}
			else
			{
				Response.Redirect("RV_Entry.aspx?Action=M&VOUCHER_NO=" + code);
			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}


		private void grdR_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		protected void txtVNo_TextChanged(object sender, System.EventArgs e)
		{

		}









	}
}