using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.LO_Registration
{
	public partial class LO_Registration : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnAddRly.Attributes.Add("OnClick", "JavaScript:validate2();");
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
				//lst = new ListItem(); 
				//lst.Text = "Private"; 
				//lst.Value = "P"; 
				//lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "PSU";
				lst.Value = "U";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "State Govt.";
				lst.Value = "S";
				lstClientType.Items.Add(lst);
				//lst = new ListItem(); 
				//lst.Text = "Foreign Railways"; 
				//lst.Value = "F"; 
				//lstClientType.Items.Add(lst);
			}
		}

		protected void lstClientType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_Rly();
		}

		public void fill_Rly()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstBPO_Rly.Items.Clear();
			DataSet dsP = new DataSet();
			string str = "";
			if (lstClientType.SelectedValue == "R")
			{
				str = "Select RLY_CD,RAILWAY ORGN from T91_RAILWAYS where RLY_CD<>'CORE' Order by RLY_CD";
			}
			else
			{
				str = "Select distinct(upper(trim(BPO_RLY))) RLY_CD, BPO_ORGN ORGN from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='" + lstClientType.SelectedValue + "' Order by RLY_CD";
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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				string Clientcheckquery = "Select count(*) from T105_LO_LOGIN where MOBILE= '" + M_NO.Text + "'";
				OracleCommand ClientcheckCommand = new OracleCommand(Clientcheckquery, conn1);
				conn1.Open();
				System.Data.DataSet ds = new DataSet();
				OracleDataAdapter adapter = new OracleDataAdapter(ClientcheckCommand);
				adapter.Fill(ds);
				conn1.Close();
				if (Convert.ToInt64(ds.Tables[0].Rows[0][0]) > 0)
				{
					DisplayAlert("Selected Mobile already Exist!!!");
					return;
				}

				string Clientquery = "INSERT INTO T105_LO_LOGIN(MOBILE,LO_NAME,DESIGNATION,EMAIL,PWD,LO_PER_FR,LO_PER_TO) " +
					"VALUES('" + M_NO.Text + "',upper('" + txtName.Text + "'),upper('" + txtdesig.Text + "'),'" + Txtemail.Text + "','" + M_NO.Text + "',TO_DATE('" + frmDt.Text + "','DD/MM/YYYY'),TO_DATE('" + toDt.Text + "','DD/MM/YYYY'))";
				OracleCommand ClientCommand = new OracleCommand();
				ClientCommand.CommandText = Clientquery;
				ClientCommand.Connection = conn1;
				conn1.Open();
				ClientCommand.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Your Record is Saved!!!");
				//Reset();

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
				conn1.Dispose();
			}

		}

		void Reset()
		{
			try
			{
				M_NO.Text = "";
				lstClientType.SelectedIndex = 0;
				lstBPO_Rly.Items.Clear();
				lstBPO_Rly.SelectedIndex = -1;
				txtName.Text = "";
				txtdesig.Text = "";
				Txtemail.Text = "";
				frmDt.Text = "";
				toDt.Text = "";

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

		protected void btnAddRly_Click(object sender, System.EventArgs e)
		{


			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				string Clientquery = "INSERT INTO T106_LO_ORGN(MOBILE,ORGN_TYPE,ORGN_CHASED) " +
					"VALUES('" + M_NO.Text + "','" + lstClientType.SelectedValue + "','" + lstBPO_Rly.SelectedValue + "')";
				OracleCommand ClientCommand = new OracleCommand();
				ClientCommand.CommandText = Clientquery;
				ClientCommand.Connection = conn1;
				conn1.Open();
				ClientCommand.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Your Record is Saved!!!");



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
				conn1.Dispose();
			}
			fillgrid();
		}

		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select MOBILE, DECODE(ORGN_TYPE,'R','RAILWAYS','U','PSU','S','STATE GOVT','P','PRIVATE') ORG_TYPE, ORGN_CHASED from T106_LO_ORGN where MOBILE='" + M_NO.Text.Trim() + "' order by ORGN_TYPE, ORGN_CHASED";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCity.Visible = false;
				}
				else
				{
					grdCity.Visible = true;
					grdCity.DataSource = dsP;
					grdCity.DataBind();
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
				conn1.Dispose();
			}
		}
		protected void btnNewLO_Click(object sender, System.EventArgs e)
		{
			Reset();
		}
	}
}