using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.SAP_Realisation_Entry_Form
{
	public partial class SAP_Realisation_Entry_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.HtmlControls.HtmlTableRow Period;
		string wYrMth;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
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

				OracleCommand cmd = new OracleCommand("select to_char(sysdate,'yyyy') from dual", conn1);
				conn1.Open();
				int yr = Convert.ToInt32(cmd.ExecuteScalar());
				conn1.Close();
				ListItem lst2 = new ListItem();
				for (int i = yr; i >= 2008; i--)
				{
					lst2 = new ListItem();
					lst2.Text = i.ToString();
					lst2.Value = i.ToString();
					lstYear.Items.Add(lst2);
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

				string Labcheckquery = "Select count(*) from T28_SAP_REALISATION where realisation_per= '" + wYrMth + "' and region_code='" + Session["Region"].ToString() + "' and client_type='" + lstClientType.SelectedValue + "'";
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
					string Labquery = "insert into T28_SAP_REALISATION(realisation_per, region_code, client_type, amount, user_id, datetime) " +
						"VALUES('" + wYrMth + "','" + Session["Region"].ToString() + "','" + lstClientType.SelectedValue + "','" + Convert.ToDecimal(Textamt.Text) + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand ClientCommand = new OracleCommand();
					ClientCommand.CommandText = Labquery;
					ClientCommand.Connection = conn1;
					conn1.Open();
					ClientCommand.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("Your Record is Saved!!!");
					Reset();
				}


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

		//		public void fill_Rly()
		//		{
		//			lstBPO_Rly.Items.Clear();
		//			DataSet dsP = new DataSet();
		//			string str ="";
		//			if(lstClientType.SelectedValue=="R")
		//			{
		//				str = "Select RLY_CD,RAILWAY ORGN from T91_RAILWAYS where RLY_CD<>'CORE' Order by RLY_CD"; 
		//			}
		//			
		//			try
		//			{
		//				OracleDataAdapter da = new OracleDataAdapter(str, conn1); 
		//				OracleCommand myOracleCommand = new OracleCommand(str, conn1); 
		//				ListItem lst; 
		//				conn1.Open();
		//				da.SelectCommand = myOracleCommand; 
		//				da.Fill(dsP, "Table"); 
		//				conn1.Close();
		//				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++) 
		//				{ 
		//					lst = new ListItem(); 
		//					lst.Text = dsP.Tables[0].Rows[i]["ORGN"].ToString(); 
		//					lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
		//					lstBPO_Rly.Items.Add(lst); 
		//				} 
		//				lstBPO_Rly.Items.Insert(0,"");
		//				
		//			}
		//			catch (Exception ex) 
		//			{ 
		//				string str1; 
		//				str1 = ex.Message; 
		//				string str2=str1.Replace("\n","");
		//				Response.Redirect(("Error_Form.aspx?err=" + str2));
		//			}
		//			finally
		//			{
		//				conn1.Close(); 
		//				conn1.Dispose();
		//			} 
		//		}

		void Reset()
		{
			try
			{
				//lstMonths.Items.Clear();
				//lstYear.Items.Clear();
				Textamt.Text = "";

				lstClientType.SelectedValue = "";


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

		private void lstClientType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//			if(lstClientType.SelectedValue=="R")
			//			{
			//				fill_Rly();
			//				lstBPO_Rly.Visible=true;
			//				lblClient.Visible=true;
			//			}
			//			else
			//			{
			//				lstBPO_Rly.Visible=false;
			//				lblClient.Visible=false;
			//			}
		}
	}
}