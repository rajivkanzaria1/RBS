using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.LO_Bill_Remarks
{
	public partial class LO_Bill_Remarks : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str = "SELECT LO_REMARKS,BPO_TYPE,BPO_RLY,BILL_AMOUNT,AU FROM V22_BILL WHERE BILL_NO='" + txtBillNo.Text + "'";
				OracleCommand cmd = new OracleCommand(str, conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					if ((Session["LO_ORGN_TYPE"].ToString() == reader["BPO_TYPE"].ToString()) && (Session["LO_ORGN"].ToString() == reader["BPO_RLY"].ToString()))
					{
						txtRemarks.Text = reader["LO_REMARKS"].ToString();
						lblBillAmt.Text = reader["BILL_AMOUNT"].ToString();
						lblAU.Text = reader["AU"].ToString();
						lblClient.Text = reader["BPO_RLY"].ToString();
						btnSave.Enabled = true;
						Label5.Visible = false;
					}
					else
					{
						Label5.Visible = true;
						DisplayAlert("You are not Authorised to Add/Modify LO Remarks for this Bill No.");
						btnSave.Enabled = false;
					}
				}

				conn1.Close();

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str2);

			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			if (txtRemarks.Text.Trim() != "")
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{

					string MySql = "Update T22_BILL SET LO_REMARKS='" + txtRemarks.Text.Trim() + "' WHERE BILL_NO='" + txtBillNo.Text.Trim() + "'";
					OracleCommand cmd = new OracleCommand(MySql, conn1);
					conn1.Open();
					cmd.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("LO Remarks Saved!!!");
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str2 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str2);

				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}
			}
			else
			{
				DisplayAlert("Kindly Enter Some Remarks Before Saving!!!");
			}
		}

		protected void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("LO_Bill_Remarks.aspx");
		}
	}
}