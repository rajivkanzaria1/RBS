using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.BPO_WISE_BILL_CHECK
{
	public class BPO_WISE_BILL_ : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected System.Web.UI.WebControls.Button btnFC_List;
		protected System.Web.UI.WebControls.DropDownList lstBPO;
		protected System.Web.UI.WebControls.TextBox txtBPO;
		protected System.Web.UI.WebControls.Button btnview;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.TextBox txtPONO;
		protected System.Web.UI.WebControls.DropDownList toMonth;
		protected System.Web.UI.WebControls.RadioButton RadioButton3;
		protected System.Web.UI.WebControls.RadioButton RadioButton4;
		protected System.Web.UI.WebControls.RadioButton RadioButton5;
		protected System.Web.UI.WebControls.DropDownList Year;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		int ecode = 0;
		//string period;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnview.Attributes.Add("OnClick", "JavaScript:validate();");

			txtBPO.Visible = false;
			btnFC_List.Visible = false;
			lstBPO.Visible = false;
			txtPONO.Visible = false;
			RadioButton3.Visible = false;
			RadioButton4.Visible = false;
			RadioButton5.Visible = false;
			Label2.Visible = false;
			Label3.Visible = false;
			toMonth.Visible = false;
			Year.Visible = false;
			frmDt.Visible = false;
			toDt.Visible = false;

			if (!(IsPostBack))
			{
				ListItem lst1 = new ListItem();
				lst1 = new ListItem();
				lst1.Text = "January";
				lst1.Value = "1";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "February";
				lst1.Value = "2";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "March";
				lst1.Value = "3";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "April";
				lst1.Value = "4";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "May";
				lst1.Value = "5";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "June";
				lst1.Value = "6";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "July";
				lst1.Value = "7";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "August";
				lst1.Value = "8";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "September";
				lst1.Value = "9";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "October";
				lst1.Value = "10";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "November";
				lst1.Value = "11";
				toMonth.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "December";
				lst1.Value = "12";
				toMonth.Items.Add(lst1);

				string str = "select to_char(sysdate,'yyyy') from dual";
				OracleCommand cmd = new OracleCommand(str, conn1);
				conn1.Open();
				int yr = Convert.ToInt32(cmd.ExecuteScalar());
				conn1.Close();
				ListItem lst2 = new ListItem();
				for (int i = yr; i >= yr - 5; i--)
				{
					lst2 = new ListItem();
					lst2.Text = i.ToString();
					lst2.Value = i.ToString();
					Year.Items.Add(lst2);

				}

				string str1 = "select to_char(sysdate,'mm') from dual";
				OracleCommand cmd1 = new OracleCommand(str1, conn1);
				conn1.Open();
				int mm = Convert.ToInt32(cmd1.ExecuteScalar());
				conn1.Close();
				toMonth.SelectedValue = mm.ToString();
				Year.SelectedValue = yr.ToString();

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
			this.RadioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
			this.RadioButton1.Load += new System.EventHandler(this.RadioButton1_CheckedChanged);
			this.btnFC_List.Click += new System.EventHandler(this.btnFC_List_Click);
			this.lstBPO.SelectedIndexChanged += new System.EventHandler(this.lstBPO_SelectedIndexChanged);
			this.RadioButton3.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
			this.RadioButton3.Load += new System.EventHandler(this.RadioButton3_CheckedChanged);
			this.RadioButton4.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
			this.RadioButton4.Load += new System.EventHandler(this.RadioButton3_CheckedChanged);
			this.RadioButton5.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
			this.RadioButton5.Load += new System.EventHandler(this.RadioButton3_CheckedChanged);
			this.RadioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
			this.RadioButton2.Load += new System.EventHandler(this.RadioButton2_CheckedChanged);
			this.btnview.Click += new System.EventHandler(this.btnview_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		int fill_BPO(string bpo)
		{
			lstBPO.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "";

			str1 = "select BPO_CD,(BPO_NAME||'/'||BPO_ADD||'/'||BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER where (trim(upper(BPO_CD))=upper('" + txtBPO.Text.Trim() + "') or trim(upper(BPO_NAME)) LIKE upper('" + txtBPO.Text.Trim() + "%')) ORDER BY BPO_NAME";

			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				ecode = 1;
				return (ecode);
				//DisplayAlert("Invalid Search Data");
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["BPO_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
					lstBPO.Items.Add(lst);
				}
				lstBPO.Visible = true;
				lstBPO.SelectedIndex = 0;
				txtBPO.Text = lstBPO.SelectedValue;
				ecode = 2;
				return (ecode);

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


				lstBPO.Visible = true;
				int a = fill_BPO(txtBPO.Text);
				if (a == 1)
				{
					lstBPO.Visible = false;
					DisplayAlert("No BPO Found!!!");
					rbs.SetFocus(txtBPO);
				}
				else
				{
					rbs.SetFocus(lstBPO);
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

		private void lstBPO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtBPO.Text = lstBPO.SelectedValue;
			//rbs.SetFocus(txtNarrat);
		}

		private void btnview_Click(object sender, System.EventArgs e)
		{
			if (RadioButton1.Checked == true)
			{
				if (RadioButton3.Checked == true)
				{
					Response.Redirect("Report_BPO_WISE_BILL_CHECK.aspx?BPO=" + txtBPO.Text + "&Period=C&MMYYYY=" + toMonth.SelectedValue.ToString() + Year.SelectedValue.ToString() + "&Month=" + toMonth.SelectedItem.Text);
				}
				else if (RadioButton4.Checked == true)
				{
					Response.Redirect("Report_BPO_WISE_BILL_CHECK.aspx?BPO=" + txtBPO.Text + "&Period=G&From=" + frmDt.Text.Trim() + "&To=" + toDt.Text.Trim());
				}
				else
				{
					Response.Redirect("Report_BPO_WISE_BILL_CHECK.aspx?BPO=" + txtBPO.Text + "&Period=A");
				}
			}
			else if (RadioButton2.Checked == true)
			{
				Response.Redirect("Report_BPO_WISE_BILL_CHECK.aspx?PO=" + txtPONO.Text);
			}
		}

		private void RadioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RadioButton1.Checked == true)
			{
				txtBPO.Visible = true;
				btnFC_List.Visible = true;
				lstBPO.Visible = true;
				RadioButton3.Visible = true;
				RadioButton4.Visible = true;
				RadioButton5.Visible = true;

			}
			else if (RadioButton2.Checked == true)
			{
				txtPONO.Visible = true;
				RadioButton3.Visible = false;
				RadioButton4.Visible = false;
				RadioButton5.Visible = false;
			}
		}

		private void RadioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RadioButton1.Checked == true)
			{
				txtBPO.Visible = true;
				btnFC_List.Visible = true;
				lstBPO.Visible = true;
				RadioButton3.Visible = true;
				RadioButton4.Visible = true;
				RadioButton5.Visible = true;
			}
			else if (RadioButton2.Checked == true)
			{
				txtPONO.Visible = true;
				RadioButton3.Visible = false;
				RadioButton4.Visible = false;
				RadioButton5.Visible = false;
			}
		}

		private void RadioButton3_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RadioButton3.Checked == true)
			{



				Label2.Visible = true;
				Label3.Visible = true;
				Label2.Text = "Month";
				Label3.Text = "Year";
				toMonth.Visible = true;
				Year.Visible = true;
				frmDt.Visible = false;
				toDt.Visible = false;
				//period="C"; //For Given Month & Year

			}
			else if (RadioButton4.Checked == true)
			{
				Label2.Visible = true;
				Label3.Visible = true;
				Label2.Text = "From";
				Label3.Text = "To";
				toMonth.Visible = false;
				Year.Visible = false;
				frmDt.Visible = true;
				toDt.Visible = true;
				//period="G"; //For Given To and From Date
			}
			else
			{
				Label2.Visible = false;
				Label3.Visible = false;
				toMonth.Visible = false;
				Year.Visible = false;
				frmDt.Visible = false;
				toDt.Visible = false;
				//period="A"; //For All Records
			}
		}
	}
}