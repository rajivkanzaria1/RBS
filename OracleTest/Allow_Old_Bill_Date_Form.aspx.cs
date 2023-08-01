using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class Allow_Old_Bill_Date_Form : System.Web.UI.Page
    {
		

		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");

			if (!(IsPostBack))
			{
				ListItem lst1 = new ListItem();
				lst1 = new ListItem();
				lst1.Text = "Yes";
				lst1.Value = "Y";
				lstAllowOldBillDT.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "No";
				lst1.Value = "N";
				lstAllowOldBillDT.Items.Add(lst1);

				show();

				if (Convert.ToString(Session["Role"]) != "Administrator")
				{
					btnSave.Enabled = false;

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
			int grace_days = 0;

			if (lstAllowOldBillDT.SelectedValue == "Y" && txtNoOfGraceDays.Text.Trim() == "")
			{
				grace_days = 0;
			}
			else
			{
				grace_days = Convert.ToInt16(txtNoOfGraceDays.Text.Trim());
			}

			try
			{
				OracleCommand myUpdateCommand = new OracleCommand();
				string myUpdateQuery = "Update T97_CONTROL_FILE set ALLOW_OLD_BILL_DT = '" + lstAllowOldBillDT.SelectedValue + "',GRACE_DAYS=" + grace_days + " where REGION='" + Session["Region"].ToString() + "'";
				myUpdateCommand.CommandText = myUpdateQuery;
				myUpdateCommand.Connection = conn1;
				conn1.Open();
				myUpdateCommand.ExecuteNonQuery();
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
		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select ALLOW_OLD_BILL_DT,GRACE_DAYS from T97_CONTROL_FILE where REGION='" + Session["Region"].ToString() + "'";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Region");
				}
				else
				{
					lstAllowOldBillDT.SelectedValue = dsP.Tables[0].Rows[0]["ALLOW_OLD_BILL_DT"].ToString();
					txtNoOfGraceDays.Text = dsP.Tables[0].Rows[0]["GRACE_DAYS"].ToString();
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




		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}
	}
}
