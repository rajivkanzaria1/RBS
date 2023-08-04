using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Master_Items_PL_Form
{
	public partial class Master_Items_PL_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!IsPostBack)
			{
				fill_Item_Master();
				lblItemDesc.Text = ddlMasterItems.SelectedItem.Text;

				if (Convert.ToString(Request.Params["ITEM_CD"]) != null)
				{

					ddlMasterItems.SelectedValue = Request.Params["ITEM_CD"].ToString();
					ddlMasterItems.Enabled = false;
					txtPLNO1.Text = Request.Params["PL_NO"].ToString();
					lblPL_NO.Text = Request.Params["PL_NO"].ToString();
					btnSave.Visible = false;
					btnSaveU.Visible = true;

					//cas_no1=Request.Params["Cs_No1"].ToString();	

				}
				else
				{
					btnSave.Visible = true;
					btnSaveU.Visible = false;
					fillgrid();

				}
			}

		}
		public void fill_Item_Master()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				ddlMasterItems.Items.Clear();
				DataSet dsP = new DataSet();
				string str1 = "select ITEM_CD,ITEM_DESC from T61_ITEM_MASTER ORDER BY ITEM_DESC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["ITEM_DESC"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["ITEM_CD"].ToString();
					ddlMasterItems.Items.Add(lst);
				}
				ddlMasterItems.Items.Insert(0, "");
				//ddlMasterItems.SelectedValue=0;
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("../Error_Form.aspx?err=" + str1));
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

		protected void ddlMasterItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblItemDesc.Text = ddlMasterItems.SelectedValue + "-" + ddlMasterItems.SelectedItem.Text;
			fillgrid();
		}

		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select T61.ITEM_CD, ITEM_DESC, PL_NO from T61_ITEM_MASTER T61, T62_MASTER_ITEM_PLNO T62 WHERE T61.ITEM_CD=T62.ITEM_CD AND T62.ITEM_CD='" + ddlMasterItems.SelectedItem.Value + "'";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				DataSet dsP = new DataSet();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdBDetails.Visible = false;
				}
				else
				{
					grdBDetails.Visible = true;
					grdBDetails.DataSource = dsP;
					grdBDetails.DataBind();
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


		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();

				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());

				string myInsertQuery = "INSERT INTO T62_MASTER_ITEM_PLNO(ITEM_CD, PL_NO, USER_ID, DATETIME) values('" + ddlMasterItems.SelectedItem.Value + "',upper('" + txtPLNO1.Text.Trim() + "'),'" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
				OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
				myInsertCommand.Connection = conn1;
				myInsertCommand.ExecuteNonQuery();
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
			txtPLNO1.Text = "";
			fillgrid();

		}

		protected void btnSaveU_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				conn1.Open();
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				string myUpdateQuery = "Update T62_MASTER_ITEM_PLNO  set PL_NO=" + txtPLNO1.Text.Trim() + ", USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where ITEM_CD='" + ddlMasterItems.SelectedItem.Value + "' AND PL_NO='" + lblPL_NO.Text.Trim() + "'";
				OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
				myUpdateCommand.Connection = conn1;
				myUpdateCommand.ExecuteNonQuery();
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
			Response.Redirect("Master_Items_PL_Form.aspx");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Master_Items_PL_Form.aspx");
		}
	}
}