using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Clients_Contact
{
	public partial class Clients_Contact : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string Type;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnEdit.Attributes.Add("OnClick", "JavaScript:validate();");

			if (Convert.ToString(Request.Params["ACTION"].Trim()) == "C")
			{
				Label1.Text = "Clients Contact";
				Label8.Text = "HIGHLIGHTS OF DISCUSSION, if any";
				Label_AMT.Visible = false;
				Textamt.Visible = false;
				Type = "C";
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "B")
			{
				Label1.Text = "BD Efforts";
				Label8.Text = "FEEDBACK FROM CLIENT";
				Label_AMT.Visible = false;
				Textamt.Visible = false;
				Type = "B";
			}
			else
			{
				Label1.Text = "DFO Visit";
				Label8.Text = "FEEDBACK FROM CLIENT";
				Label_AMT.Visible = true;
				Textamt.Visible = true;
				Type = "D";

			}

			if (!(IsPostBack))
			{

				ListItem lst = new ListItem();
				lst.Text = "";
				lst.Value = "";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Railways";
				lst.Value = "R";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Private";
				lst.Value = "P";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "PSU";
				lst.Value = "U";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "State Govt.";
				lst.Value = "S";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Foreign Railways";
				lst.Value = "F";
				lstClientType.Items.Add(lst);
				string str2 = "";
				if (Type == "D")
				{
					str2 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='" + Session["REGION"] + "' and CO_TYPE='D' order by CO_NAME ";
				}
				else
				{
					str2 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='" + Session["REGION"] + "' order by CO_NAME ";
				}
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				ListItem lst1;
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				DataSet dsP1 = new DataSet();
				da1.Fill(dsP1, "Table");
				lst1 = new ListItem();
				for (int j = 0; j <= dsP1.Tables[0].Rows.Count - 1; j++)
				{
					lst1 = new ListItem();
					lst1.Text = dsP1.Tables[0].Rows[j]["CO_NAME"].ToString();
					lst1.Value = dsP1.Tables[0].Rows[j]["CO_CD"].ToString();
					lstCOCD.Items.Add(lst1);
				}
				lstCOCD.Items.Insert(0, "");
				conn1.Close();
			}
		}

		protected void lstClientType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_Rly();
		}

		public void fill_Rly()
		{
			lstBPO_Rly.Items.Clear();
			DataSet dsP = new DataSet();
			string str = "";
			if (lstClientType.SelectedValue == "R")
			{
				str = "Select RLY_CD,RAILWAY ORGN from T91_RAILWAYS where RLY_CD<>'CORE' Order by RLY_CD";
			}
			else
			{
				str = "Select distinct(upper(trim(BPO_RLY))) RLY_CD, BPO_ORGN ORGN from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='" + lstClientType.SelectedValue + "' Order by BPO_ORGN";
			}
			try
			{
				OracleDataAdapter da = new OracleDataAdapter(str, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str, conn1);
				ListItem lst;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				conn1.Close();
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["ORGN"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
					lstBPO_Rly.Items.Add(lst);
				}
				lstBPO_Rly.Items.Insert(0, "");
				lstBPO_Rly.Items.Insert(1, "Others");
			}
			catch (Exception ex)
			{
				string str1;
				str1 = ex.Message;
				string str2 = str1.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str2));
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
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

		void Reset()
		{
			try
			{
				toDt.Text = "";
				lstClientType.SelectedIndex = 0;
				lstBPO_Rly.Items.Clear();
				lstBPO_Rly.SelectedIndex = -1;
				txtName.Text = "";
				txtdesig.Text = "";
				Textoutcome.Text = "";
				lstCOCD.SelectedIndex = 0;
				Texthigh.Text = "";
				Textbox_OC.Text = "";
				Textamt.Text = "";
			}
			catch (Exception ex)
			{
				string str1;
				str1 = ex.Message;
				string str2 = str1.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str2));
			}

		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				string Oc_clients = "";
				Int64 Amt_o;
				string Clientcheckquery = "Select count(*) from T58_CLIENT_CONTACT where to_char(VISIT_DT, 'dd/mm/yyyy')= '" + toDt.Text + "' and REGION_CD='" + Session["Region"].ToString() + "' and RITES_OFFICER_CD='" + lstCOCD.SelectedValue + "' and CLIENT='" + lstBPO_Rly.SelectedItem.Text.ToString() + "' and TYPE_CB='" + Type + "'";
				OracleCommand ClientcheckCommand = new OracleCommand(Clientcheckquery, conn1);
				conn1.Open();
				System.Data.DataSet ds = new DataSet();
				OracleDataAdapter adapter = new OracleDataAdapter(ClientcheckCommand);
				adapter.Fill(ds);
				conn1.Close();
				if (lstBPO_Rly.SelectedItem.Text.ToString() == "Others")
				{
					if (Textbox_OC.Text == "")
					{
						DisplayAlert("Other Client Name can not be left blank in Other Clients!!!");
						return;
					}
					else
					{
						Oc_clients = Textbox_OC.Text.Trim();
					}
				}
				else
				{
					Oc_clients = lstBPO_Rly.SelectedItem.Text.ToString();
				}
				if (Convert.ToInt64(ds.Tables[0].Rows[0][0]) > 0)
				{
					DisplayAlert("Selected CM,IE,DATE for this region already Exist!!!");
					return;
				}
				if (Type == "D")
				{
					if (Textamt.Text == "")
					{
						DisplayAlert("Outstanding Amount can not be left blank!!!");
						return;
					}
					else
					{
						Amt_o = Convert.ToInt64(Textamt.Text.Trim());
					}
				}
				else
				{
					Amt_o = 0;

				}

				string Clientquery = "INSERT INTO T58_CLIENT_CONTACT(VISIT_DT,CLIENT,RITES_OFFICER_CD,CLIENT_OFFICER_NAME,DESIGNATION,CLIENT_TYPE,HIGHLIGHTS,OVERALL_OUTCOME,REGION_CD,USER_ID,DATETIME,TYPE_CB,OUT_AMT) " +
					"VALUES(to_date('" + toDt.Text + "','dd/mm/yyyy'),'" + Oc_clients + "','" + lstCOCD.SelectedValue + "','" + txtName.Text + "','" + txtdesig.Text + "','" + lstClientType.SelectedValue + "','" + Texthigh.Text + "','" + Textoutcome.Text + "','" + Session["Region"].ToString() + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + Type + "'," + Amt_o + ")";
				OracleCommand ClientCommand = new OracleCommand();
				ClientCommand.CommandText = Clientquery;
				ClientCommand.Connection = conn1;
				conn1.Open();
				ClientCommand.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Your Record is Saved!!!");
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

		private void btnEdit_Click(object sender, System.EventArgs e)
		{

		}


		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		protected void lstBPO_Rly_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstBPO_Rly.SelectedItem.Text.ToString() == "Others")
			{
				Label4_OC.Visible = true;
				Textbox_OC.Visible = true;
			}
			else
			{
				Label4_OC.Visible = false;
				Textbox_OC.Visible = false;
			}

		}


	}
}