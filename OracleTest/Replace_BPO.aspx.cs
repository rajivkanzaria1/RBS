using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Replace_BPO
{
	public class Replace_BPO1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList lstBPO;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnFC_List;
		protected System.Web.UI.WebControls.TextBox txtBPO;
		protected System.Web.UI.WebControls.Button btnview;
		protected System.Web.UI.WebControls.DropDownList lstBPO1;
		protected System.Web.UI.WebControls.Button btnFC_List1;
		protected System.Web.UI.WebControls.TextBox txtBPO1;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnFC_List.Attributes.Add("OnClick", "JavaScript:validate();");
			btnFC_List1.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnview.Attributes.Add("OnClick", "JavaScript:mess();");
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
			this.btnview.Click += new System.EventHandler(this.btnview_Click);
			this.btnFC_List.Click += new System.EventHandler(this.btnFC_List_Click);
			this.btnFC_List1.Click += new System.EventHandler(this.btnFC_List1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		void fill_bpo(string str1)
		{
			try
			{
				lstBPO.Items.Clear();
				DataSet dsP = new DataSet();
				//string str1 = "Select BPO_CD, BPO from V12_BILL_PAYING_OFFICER where upper(trim(BPO)) like trim(upper('"+txtBPO.Text.Trim()+"%')) order by BPO"; 
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("Invalid Search Data");
				}
				else
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["BPO_CD"].ToString() + "-" + dsP.Tables[0].Rows[i]["BPO"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
						lstBPO.Items.Add(lst);
					}
					lstBPO.Visible = true;
					lstBPO.SelectedIndex = 0;
				}
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
			}
		}

		void fill_bpo1(string str1)
		{
			try
			{
				lstBPO1.Items.Clear();
				DataSet dsP = new DataSet();
				//string str1 = "Select BPO_CD, BPO from V12_BILL_PAYING_OFFICER where upper(trim(BPO)) like trim(upper('"+txtBPO.Text.Trim()+"%')) order by BPO"; 
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("Invalid Search Data");
				}
				else
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["BPO_CD"].ToString() + "-" + dsP.Tables[0].Rows[i]["BPO"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
						lstBPO1.Items.Add(lst);
					}
					lstBPO1.Visible = true;
					lstBPO1.SelectedIndex = 0;
				}
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
			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		private void btnFC_List_Click(object sender, System.EventArgs e)
		{
			try
			{
				string str1 = "";
				if (txtBPO.Text.Trim().Length == 5 && (Convert.ToInt32(txtBPO.Text.Trim()) >= 1 || Convert.ToInt32(txtBPO.Text.Trim()) <= 99999))
				{
					str1 = "Select BPO_CD, BPO from V12_BILL_PAYING_OFFICER where upper(trim(BPO_CD)) = trim(upper('" + txtBPO.Text.Trim() + "')) order by BPO";
				}
				else
				{
					str1 = "Select BPO_CD, BPO from V12_BILL_PAYING_OFFICER where upper(trim(BPO)) like trim(upper('" + txtBPO.Text.Trim() + "%')) order by BPO";
				}

				fill_bpo(str1);
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				if (str2.Equals("Input string was not in a correct format."))
				{
					fill_bpo("Select BPO_CD, BPO from V12_BILL_PAYING_OFFICER where upper(trim(BPO)) like trim(upper('" + txtBPO.Text.Trim() + "%')) order by BPO");
				}
				else
				{
					Response.Redirect("Error_Form.aspx?err=" + str2);
				}

			}
			finally
			{
				conn1.Close();
			}
		}

		private void btnFC_List1_Click(object sender, System.EventArgs e)
		{
			try
			{
				string str1 = "";
				if (txtBPO1.Text.Trim().Length == 5 && (Convert.ToInt32(txtBPO1.Text.Trim()) >= 1 || Convert.ToInt32(txtBPO1.Text.Trim()) <= 99999))
				{
					str1 = "Select BPO_CD, BPO from V12_BILL_PAYING_OFFICER where upper(trim(BPO_CD)) = trim(upper('" + txtBPO1.Text.Trim() + "')) order by BPO";
				}
				else
				{
					str1 = "Select BPO_CD, BPO from V12_BILL_PAYING_OFFICER where upper(trim(BPO)) like trim(upper('" + txtBPO1.Text.Trim() + "%')) order by BPO";
				}

				fill_bpo1(str1);
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				if (str2.Equals("Input string was not in a correct format."))
				{
					fill_bpo1("Select BPO_CD, BPO from V12_BILL_PAYING_OFFICER where upper(trim(BPO)) like trim(upper('" + txtBPO1.Text.Trim() + "%')) order by BPO");
				}
				else
				{
					Response.Redirect("Error_Form.aspx?err=" + str2);
				}

			}
			finally
			{
				conn1.Close();
			}
		}

		private void btnview_Click(object sender, System.EventArgs e)
		{
			if (lstBPO.Visible == true && lstBPO1.Visible == true)
			{
				OracleCommand cmd = null;
				conn1.Open();
				try
				{

					cmd = new OracleCommand("REPLACE_BPO", conn1);
					cmd.CommandType = CommandType.StoredProcedure;

					OracleParameter prm1 = new OracleParameter("OLD_BPO_CD", OracleDbType.Varchar2, 5);
					prm1.Direction = ParameterDirection.Input;
					prm1.Value = lstBPO.SelectedValue;
					cmd.Parameters.Add(prm1);

					OracleParameter prm2 = new OracleParameter("NEW_BPO_CD", OracleDbType.Varchar2, 5);
					prm2.Direction = ParameterDirection.Input;
					prm2.Value = lstBPO1.SelectedValue;
					cmd.Parameters.Add(prm2);

					OracleParameter prm3 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32);
					prm3.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(prm3);

					cmd.ExecuteNonQuery();
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

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					DisplayAlert("Unable To Replace BPO, So Plz Try Again.");
				}
				else
				{
					DisplayAlert("Old BPO is Replced by New BPO Sucessfully.");
				}
			}
			else
			{
				DisplayAlert("Plz Select Old BPO  and New BPO First!!!");
			}
		}
	}
}