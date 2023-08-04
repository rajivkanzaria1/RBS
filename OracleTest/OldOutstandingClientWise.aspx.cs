using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.OldOutstandingClientWise
{
	public partial class OldOutstandingClientWise : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string wBPO_TYPE, wBPO_RLY;
		int wOutstanding;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.Params["BPO_TYPE"]) == "" || Convert.ToString(Request.Params["BPO_TYPE"]) == null)
			{
				wBPO_TYPE = "";
				wBPO_RLY = "";
				wOutstanding = 0;
			}
			else if (Convert.ToString(Request.Params["BPO_TYPE"]) != "")
			{
				wBPO_TYPE = Request.Params["BPO_TYPE"].ToString();
				wBPO_RLY = Request.Params["BPO_RLY"].ToString();
				wOutstanding = Convert.ToInt32(Request.Params["OUTSTANDING"].ToString());
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
				if (wBPO_TYPE != "")
				{
					lstClientType.SelectedValue = Request.Params["BPO_TYPE"].ToString();
					fill_Rly();
					lstBPO_Rly.SelectedValue = Request.Params["BPO_RLY"].ToString();
					//					txtOutstanding.Text=Request.Params["OUTSTANDING"].ToString();
					lstClientType.Enabled = false;
					lstBPO_Rly.Enabled = false;
					btnDelete.Visible = true;
				}
				else
				{
					lstClientType.Enabled = true;
					lstBPO_Rly.Enabled = true;
					btnDelete.Visible = false;
				}
				fillgrid();
			}

		}
		public void fill_Rly()
		{
			lstBPO_Rly.Items.Clear();
			DataSet dsP = new DataSet();
			string str = "";
			if (lstClientType.SelectedValue == "R")
			{
				str = "Select RLY_CD, RAILWAY from T91_RAILWAYS Order by RAILWAY";
			}
			else
			{
				str = "Select distinct(upper(trim(BPO_RLY))) RLY_CD, BPO_ORGN RAILWAY from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='" + lstClientType.SelectedValue + "' Order by BPO_ORGN";
			}
			OracleDataAdapter da = new OracleDataAdapter(str, conn);
			OracleCommand myOracleCommand = new OracleCommand(str, conn);
			ListItem lst;
			conn.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			conn.Close();
			for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Text = dsP.Tables[0].Rows[i]["RAILWAY"].ToString();
				lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
				lstBPO_Rly.Items.Add(lst);
			}
			lstBPO_Rly.Items.Insert(0, "");
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

		protected void lstClientType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_Rly();

		}

		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select O.BPO_CD,B.BPO, NVL(O.OUTSTANDING_AMT,0)OUTSTANDING_AMT, O.OLD_SYSTEM_BPO from OLD_SYSTEM_OUTSTANDING O, V12_BILL_PAYING_OFFICER B where B.BPO_CD=O.BPO_CD order by BPO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn);
				conn.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdOutstanding.Visible = false;
				}
				else
				{
					grdOutstanding.Visible = true;
					grdOutstanding.DataSource = dsP;
					grdOutstanding.DataBind();
				}
				conn.Close();

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
				conn.Close();
			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{

				conn.Open();
				OracleCommand cmd1 = new OracleCommand("Select OUTSTANDING_AMT from OLD_SYSTEM_OUTSTANDING where BPO_CD='" + ddlBPOCode.SelectedValue + "'", conn);
				string check = Convert.ToString(cmd1.ExecuteScalar());
				conn.Close();

				if (check == "")
				{
					string myInsertQuery = "INSERT INTO OLD_SYSTEM_OUTSTANDING(OUTSTANDING_AMT,BPO_CD,OLD_SYSTEM_BPO) values(" + txtOutstanding.Text + ",'" + ddlBPOCode.SelectedValue + "','" + txtOLDBPOREF.Text.Trim() + "')";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					conn.Open();
					myInsertCommand.Connection = conn;
					myInsertCommand.ExecuteNonQuery();
					conn.Close();
					fillgrid();

				}
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
				conn.Close();
			}
			Response.Redirect("OldOutstandingClientWise.aspx");
		}

		public void grdOutstanding_Edit(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			grdOutstanding.EditItemIndex = e.Item.ItemIndex;
			fillgrid();

		}

		public void grdOutstanding_Cancel(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			grdOutstanding.EditItemIndex = -1;
			fillgrid();
		}
		public void grdOutstanding_Update(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			decimal outstanding = 0;
			string wbpo_cd = Convert.ToString(e.Item.Cells[1].Text), oldsystembpo = "";
			if ((e.Item.FindControl("txtODLSYSBPO") as TextBox).Text.Trim() != "")
			{
				oldsystembpo = Convert.ToString((e.Item.FindControl("txtODLSYSBPO") as TextBox).Text.Trim());
			}

			if ((e.Item.FindControl("txtOUTAMT") as TextBox).Text.Trim() != "")
			{
				outstanding = Convert.ToDecimal((e.Item.FindControl("txtOUTAMT") as TextBox).Text.Trim());
			}

			conn.Open();
			string myUpdateQuery = "Update OLD_SYSTEM_OUTSTANDING set OUTSTANDING_AMT=" + outstanding + ", OLD_SYSTEM_BPO='" + oldsystembpo + "' where BPO_CD='" + wbpo_cd + "'";
			OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
			myUpdateCommand.Connection = conn;
			myUpdateCommand.ExecuteNonQuery();
			conn.Close();
			grdOutstanding.EditItemIndex = -1;
			fillgrid();
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				string myDeleteQuery = "Delete OLD_SYSTEM_OUTSTANDING where BPO_TYPE='" + lstClientType.SelectedValue + "' and BPO_RLY='" + lstBPO_Rly.SelectedValue + "'";
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn;
				conn.Open();
				myOracleCommand.ExecuteNonQuery();
				conn.Close();

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
				conn.Close();
			}
			Response.Redirect("OldOutstandingClientWise.aspx");
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		void fill_bpo()
		{
			ddlBPOCode.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "select BPO_CD,(B.BPO_CD||'-'||B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO from T12_BILL_PAYING_OFFICER B, T03_CITY C where B.BPO_CITY_CD=C.CITY_CD and BPO_TYPE='" + lstClientType.SelectedValue + "' and BPO_RLY='" + lstBPO_Rly.SelectedValue + "' order by B.BPO_NAME";
			OracleDataAdapter da = new OracleDataAdapter(str1, conn);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("Invalid Search Data");
				//ddlBPOCode.Visible=false;
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["BPO"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
					ddlBPOCode.Items.Add(lst);
				}
				ddlBPOCode.Visible = true;
				ddlBPOCode.SelectedIndex = 0;
				//rbs.SetFocus(ddlVender);


			}
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		protected void lstBPO_Rly_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_bpo();
		}
	}
}