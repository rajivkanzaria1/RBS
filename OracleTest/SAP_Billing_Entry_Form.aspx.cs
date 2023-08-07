﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.SAP_Billing_Entry_Form
{
	public partial class SAP_Billing_Entry_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.HtmlControls.HtmlTableRow Period;
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
				wYrMth = lstYear.SelectedValue + lstMonths.SelectedValue;
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();

				string Labcheckquery = "Select count(*) from T88_SAP_BILLING where sap_bill_per= '" + wYrMth + "' and region_code='" + Session["Region"].ToString() + "'";
				OracleCommand CheckCommand = new OracleCommand(Labcheckquery, conn1);
				conn1.Open();
				System.Data.DataSet ds = new DataSet();
				OracleDataAdapter adapter = new OracleDataAdapter(CheckCommand);
				adapter.Fill(ds);
				conn1.Close();
				if (Convert.ToInt64(ds.Tables[0].Rows[0][0]) > 0)
				{
					DisplayAlert("Selected Bill Period Already Exist!!!");
					return;
				}
				else
				{
					string Labquery = "insert into T88_SAP_BILLING(sap_bill_per, region_code, insp_fee, cgst, sgst, igst, user_id, datetime) " +
						"VALUES('" + wYrMth + "','" + Session["Region"].ToString() + "','" + Convert.ToDecimal(Textamt.Text) + "','" + Convert.ToDecimal(txtCGST.Text) + "','" + Convert.ToDecimal(txtSGST.Text) + "','" + Convert.ToDecimal(txtIGST.Text) + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand ClientCommand = new OracleCommand();
					ClientCommand.CommandText = Labquery;
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

		void Reset()
		{
			try
			{
				//lstMonths.Items.Clear();
				//lstYear.Items.Clear();
				Textamt.Text = "";
				txtCGST.Text = "";
				txtSGST.Text = "";
				txtIGST.Text = "";
			}
			catch (Exception ex)
			{
				string str1;
				str1 = ex.Message;
				string str2 = str1.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str2));
			}

		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{

		}
	}
}