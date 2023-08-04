using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.FIRST_PAGE1
{
	public partial class FIRST_PAGE1 : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);



		private int code = new int();
		string Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Convert.ToString(Request.Params["C_NO"]) == null || Convert.ToString(Request.Params["C_NO"]) == "")
			{
				code = 0;
				Action = "";
			}
			else
			{
				code = Convert.ToInt32(Request.Params["C_NO"].Trim());
				Action = Convert.ToString(Request.Params["ACTION"].Trim());
			}

			try
			{

				DropDownList1.Items.Clear();
				DataSet dsP = new DataSet();
				//string str = "";

				string str = "Select * FROM CONTROLLER order by C_NO";

				OracleDataAdapter da = new OracleDataAdapter(str, conn);
				OracleCommand myOracleCommand = new OracleCommand(str, conn);
				ListItem lst1;
				conn.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				conn.Close();
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst1 = new ListItem();
					lst1.Text = dsP.Tables[0].Rows[i]["C_NAME"].ToString();
					lst1.Value = dsP.Tables[0].Rows[i]["C_NO"].ToString();
					DropDownList1.Items.Add(lst1);
				}

			}

			catch { }


			if (!(IsPostBack))
			{
				ListItem lst = new ListItem();
				lst.Text = "";
				lst.Value = "";
				DropDownList2.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Railways";
				lst.Value = "R";
				DropDownList2.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Private";
				lst.Value = "P";
				DropDownList2.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "PSU";
				lst.Value = "U";
				DropDownList2.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "State Govt.";
				lst.Value = "S";
				DropDownList2.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Foreign Railways";
				lst.Value = "F";
				DropDownList2.Items.Add(lst);


				if (Action == "E")
				{
					show();
					//search();	
					Button1.Enabled = true;
				}



			}
		}
		public void fill_Rly()
		{
			DropDownList3.Items.Clear();
			DataSet dsP = new DataSet();
			string str = "";
			if (DropDownList2.SelectedValue == "R")
			{
				str = "Select RLY_CODE from RAILWAYS Order by RLY_CODE";
			}
			else
			{
				str = "Select distinct(upper(trim(BPO_RLY))) RLY_CODE from BILL_PAYING_OFFICER WHERE BPO_TYPE='S' Order by RLY_CODE";
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
				lst.Text = dsP.Tables[0].Rows[i]["RLY_CODE"].ToString();
				lst.Value = dsP.Tables[0].Rows[i]["RLY_CODE"].ToString();
				DropDownList3.Items.Add(lst);
			}
		}

		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = ("select * from CLIENT_CONTROLLING where C_NO=" + code);
				OracleDataAdapter da = new OracleDataAdapter(str1, conn);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn);
				conn.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{
					DropDownList1.SelectedValue = dsP.Tables[0].Rows[0]["C_NO"].ToString();
					DropDownList2.SelectedValue = dsP.Tables[0].Rows[0]["BPO_RLY"].ToString();
					DropDownList3.SelectedValue = Convert.ToString(dsP.Tables[0].Rows[0]["BPO_TYPE"]);
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{

			string str = "";

			try
			{
				if (code == 0)
				{
					// str = "INSERT INTO CLIENT_CONTROLLING(CO_CD, BPO_TYPE, BPO_RLY) VALUES( " + DropDownList1.SelectedValue + ",'" + DropDownList2.SelectedValue + "'," + DropDownList3.SelectedValue + ")";
					str = "INSERT INTO CLIENT_CONTROLLING(C_NO, BPO_TYPE, BPO_RLY,FROM_DT,TO_DT) VALUES( " + DropDownList1.SelectedValue + ",'" + DropDownList2.SelectedValue + "','" + DropDownList3.SelectedValue + "', FROM_DT('" + TextBox1.Text + "','dd/mm/yyyy'),TO_DATE('" + TextBox2.Text + "','dd/mm/yyyy'))";
					OracleCommand myOracleCommand = new OracleCommand(str, conn);
					conn.Open();
					myOracleCommand.ExecuteNonQuery();
				}

				else
				{
					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update CLIENT_CONTROLLING set C_NO ='" + DropDownList1.SelectedValue.TrimEnd().TrimStart() + "',BPO_TYPE= '" + DropDownList2.SelectedValue.TrimEnd().TrimStart() + "',BPO_RLY='" + DropDownList3.SelectedValue + "'FROM_DT='" + TextBox1.Text + "'dd/mm/yyyy'" + "'TO_DATE='" + TextBox2.Text + "'dd/mm/yyyy')";
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn;
					int count = myUpdateCommand.ExecuteNonQuery();
					if ((count == 0))
					{
						throw new System.Exception("No Record Found!!! Any Other User had Deleted Your Record While you were Modifying");
					}

					conn.Close();
				}

			}

			catch { }

			finally
			{
				conn.Close();
			}
		}
		void fillgrid()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				DataSet dsP = new DataSet();
				string str1 = "SELECT C_NO,C_NAME,C_EMAIL,BPO_RLY,BPO_TYPE FROM T44_CLIENT_CLIENT_CONTROLLING CC, CONTROLLER CO WHERE  CC.C_NO=CO.C_NO ";
				if (DropDownList1.SelectedValue != "")
				{
					str1 = str1 + " and C_NO=" + DropDownList1.SelectedValue;

				}
				if (DropDownList2.SelectedValue != "")
				{
					str1 = str1 + " and BPO_TYPE=" + DropDownList2.SelectedValue;

				}
				if (DropDownList3.SelectedValue != "")
				{
					str1 = str1 + " and BPO_RLY=" + DropDownList3.SelectedValue;

				}
				OracleDataAdapter da = new OracleDataAdapter(str1, conn);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn);
				conn.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					GD1.Visible = false;

				}
				else
				{

					GD1.Visible = true;
					GD1.DataSource = dsP;
					GD1.DataBind();
					conn.Close();


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

		}

		protected void Button3_Click(object sender, System.EventArgs e)
		{
			fillgrid();
		}

		protected void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_Rly();
		}
	}
}