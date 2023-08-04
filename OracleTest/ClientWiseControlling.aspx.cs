using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.ClientWiseControlling
{
	public partial class ClientWiseControlling : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.Label lblHeader;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList lstClientType;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList lstBPO_Rly;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList lstCO;
		protected System.Web.UI.WebControls.Panel Panel_2;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnSave;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.HyperLink Hyperlink3;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected Tittle.Controls.CustomDataGrid grdCC;
		string ACTION;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ACTION = "A";
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
				lstClientType.Items.Insert(0, "");

				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					DataSet dsP1 = new DataSet();
					string str3 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_REGION='" + Session["REGION"] + "' order by CO_NAME ";
					OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
					ListItem lst3;
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP1, "Table");
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
					{
						lst3 = new ListItem();
						lst3.Text = dsP1.Tables[0].Rows[i]["CO_NAME"].ToString();
						lst3.Value = dsP1.Tables[0].Rows[i]["CO_CD"].ToString();
						lstCO.Items.Add(lst3);
					}
					conn1.Close();
					lstCO.Items.Insert(0, "");
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
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
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
			this.lstClientType.SelectedIndexChanged += new System.EventHandler(this.lstClientType_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string CO_CD = "";
			string fr_dt = "";
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand cmd1 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd1.ExecuteScalar());
				conn1.Close();

				if (ACTION == "A")
				{
					conn1.Open();

					string sql = "select CO_CD,to_char(DATE_FR,'dd/mm/yyyy') FROM_DATE from T44_CLIENT_CONTROLLING where RLY_NONRLY='" + lstClientType.SelectedValue + "' and RLY_CD='" + lstBPO_Rly.SelectedValue + "' and NVL(to_char(DATE_TO,'dd/mm/yyyy'),'X')='X'";
					OracleCommand cmd = new OracleCommand(sql, conn1);
					OracleDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						CO_CD = Convert.ToString(reader["CO_CD"]);
						fr_dt = Convert.ToString(reader["FROM_DATE"]);
					}
					conn1.Close();
					if (dtcomp(fr_dt, frmDt.Text.Trim()) <= 0)
					{
						DisplayAlert("NEW CM [FROM DATE] SHOULD BE GREATER THEN THE [FROM DATE] OF THE CM TO BE REPLACED!!!");
					}
					else if (CO_CD == lstCO.SelectedValue)
					{
						DisplayAlert("CM ALREADY EXIST FOR THIS CLIENT!!!");
					}
					else
					{
						conn1.Open();
						OracleTransaction myTrans = null;
						try
						{
							myTrans = conn1.BeginTransaction();
							string myUpdateQuery = "Update T44_CLIENT_CONTROLLING set DATE_TO=to_date('" + frmDt.Text + "','dd/mm/yyyy')-1, USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS') where CO_CD=" + CO_CD + " and RLY_NONRLY='" + lstClientType.SelectedValue + "' AND RLY_CD='" + lstBPO_Rly.SelectedValue + "' and DATE_FR=to_date('" + fr_dt + "','dd/mm/yyyy')";

							OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
							myUpdateCommand.Connection = conn1;
							myUpdateCommand.Transaction = myTrans;
							myUpdateCommand.ExecuteNonQuery();

							string myInsertQuery = "INSERT INTO T44_CLIENT_CONTROLLING(CO_CD, RLY_NONRLY,RLY_CD,BPO_ORGN, DATE_FR, DATE_TO, REGION_CODE, USER_ID, DATETIME) values(" + lstCO.SelectedValue + ", '" + lstClientType.SelectedValue + "','" + lstBPO_Rly.SelectedValue + "' ,'" + lstBPO_Rly.SelectedItem.Text + "',to_date('" + frmDt.Text.Trim() + "','dd/mm/yyyy'),null,'" + Session["Region"] + "','" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS'))";
							OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
							myInsertCommand.Connection = conn1;
							myInsertCommand.Transaction = myTrans;
							myInsertCommand.ExecuteNonQuery();
							myTrans.Commit();
							conn1.Close();
							DisplayAlert("Your Record Has Been Saved!!!");
						}
						catch (Exception ex)
						{
							string str;
							str = ex.Message;
							myTrans.Rollback();
						}
						finally
						{
							conn1.Close();
							conn1.Dispose();
						}
					}

					conn1.Close();
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
				conn1.Close();
				conn1.Dispose();
			}
			//			fillgrid();
		}
		int dtcomp(string dt1, string dt2)
		{
			string myYear, myMonth, myDay;
			myYear = dt1.Substring(6, 4);
			myMonth = dt1.Substring(3, 2);
			myDay = dt1.Substring(0, 2);
			string dt3 = myYear + myMonth + myDay;

			string myYear1, myMonth1, myDay1;
			myYear1 = dt2.Substring(6, 4);
			myMonth1 = dt2.Substring(3, 2);
			myDay1 = dt2.Substring(0, 2);
			string dt4 = myYear1 + myMonth1 + myDay1;
			int i = dt4.CompareTo(dt3);
			return (i);
		}
		public void fill_Rly()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstBPO_Rly.Items.Clear();
			DataSet dsP = new DataSet();
			string str = "";
			if (lstClientType.SelectedValue == "R")
			{
				str = "Select RLY_CD,RAILWAY BPO_ORGN from T91_RAILWAYS Order by RLY_CD";
			}
			else
			{
				str = "Select distinct(upper(trim(BPO_RLY))) RLY_CD, BPO_ORGN  from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='" + lstClientType.SelectedValue + "' Order by RLY_CD";
			}
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
				lst.Text = dsP.Tables[0].Rows[i]["BPO_ORGN"].ToString();
				lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
				lstBPO_Rly.Items.Add(lst);
			}
			lstBPO_Rly.Items.Insert(0, "");

		}

		private void lstClientType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_Rly();
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{



				string str1 = "Select T08.CO_NAME,decode(RLY_NONRLY,'R','Railway','S','State Government','F','Foreign Railways','U','PSU')CLIENT_TYPE, RLY_CD,to_char(DATE_FR,'dd/mm/yyyy')FR_DT,to_char(DATE_TO,'dd/mm/yyyy')TO_DT from T08_IE_CONTROLL_OFFICER T08,T44_CLIENT_CONTROLLING T44 where T08.CO_CD=T44.CO_CD";
				DataSet dsP = new DataSet();

				if (lstCO.SelectedValue != "")
				{

					str1 = str1 + " and upper(T44.CO_CD)=" + lstCO.SelectedValue;
				}

				if (lstClientType.SelectedValue != "")
				{

					str1 = str1 + " and RLY_NONRLY='" + lstClientType.SelectedValue + "'";
				}

				if (lstBPO_Rly.SelectedValue != "")
				{
					str1 = str1 + " and RLY_CD='" + lstBPO_Rly.SelectedValue + "'";
				}
				str1 = str1 + " order by T44.CO_CD,RLY_NONRLY,RLY_CD";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{

					grdCC.Visible = false;
					DisplayAlert("No Record Present!!!");
					//Label4.Visible=true;
				}
				else
				{
					grdCC.Visible = true;
					grdCC.DataSource = dsP;
					grdCC.DataBind();


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
	}
}