using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class Unregistered_Calls : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		int icode;
		string Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (Convert.ToString(Request.Params["IE_CD"]) == null || Convert.ToString(Request.Params["IE_CD"]) == "")
			{
				icode = 0;
				Action = "A";
			}
			else
			{
				icode = Convert.ToInt32(Request.Params["IE_CD"].Trim());
				Action = "M";
			}
			if (!(IsPostBack))
			{
				string str = "select to_char(sysdate,'yyyy') from dual";
				OracleCommand cmd = new OracleCommand(str, conn1);
				conn1.Open();
				int yr = Convert.ToInt32(cmd.ExecuteScalar());
				conn1.Close();
				ListItem lst2 = new ListItem();
				for (int i = yr; i >= 2008; i--)
				{
					lst2 = new ListItem();
					lst2.Text = i.ToString();
					lst2.Value = i.ToString();
					Year.Items.Add(lst2);


				}


				DataSet dsP1 = new DataSet();
				string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				ListItem lst3;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
				{
					lst3 = new ListItem();
					lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString();
					lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString();
					lstIE.Items.Add(lst3);
				}
				conn1.Close();
				if (Action == "M")
				{
					show();
					btnDelConfirm.Visible = true;

				}
				else
				{
					btnDelConfirm.Visible = false;

				}
				fillgrid();
			}
		}

		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select U.IE_CD,I.IE_NAME,U.YR_MTH,U.UNREG_CALLS from T70_UNREGISTERED_CALLS U, T09_IE I where U.IE_CD=I.IE_CD(+) and U.IE_CD=" + icode;
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{
					lstIE.SelectedValue = dsP.Tables[0].Rows[0]["IE_CD"].ToString();
					lstIE.Enabled = false;
					txtUCalls.Text = dsP.Tables[0].Rows[0]["UNREG_CALLS"].ToString();
					Year.SelectedValue = Convert.ToString(dsP.Tables[0].Rows[0]["YR_MTH"]).Substring(0, 4);
					toMonth.SelectedValue = Convert.ToString(dsP.Tables[0].Rows[0]["YR_MTH"]).Substring(4, 2);
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
			}

		}
		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select U.IE_CD,I.IE_NAME,U.YR_MTH,U.UNREG_CALLS from T70_UNREGISTERED_CALLS U, T09_IE I where U.IE_CD=I.IE_CD(+) and REGION='" + Session["Region"].ToString() + "' order by IE_NAME";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdUCalls.Visible = false;
				}
				else
				{
					grdUCalls.Visible = true;
					grdUCalls.DataSource = dsP;
					grdUCalls.DataBind();
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
			}

		}




		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			OracleCommand myInsertCommand = new OracleCommand();
			if (Action == "A")
			{
				string myInsertQuery = "INSERT INTO T70_UNREGISTERED_CALLS values(" + lstIE.SelectedValue + ",'" + Year.SelectedValue + toMonth.SelectedValue + "','" + txtUCalls.Text + "','" + Session["Region"].ToString() + "')";
				myInsertCommand.CommandText = myInsertQuery;
				myInsertCommand.Connection = conn1;
				conn1.Open();
				myInsertCommand.ExecuteNonQuery();
				conn1.Close();
			}
			else
			{
				string myUpdateQuery = "update T70_UNREGISTERED_CALLS SET YR_MTH='" + Year.SelectedValue + toMonth.SelectedValue + "',UNREG_CALLS='" + txtUCalls.Text + "' where IE_CD=" + icode;
				myInsertCommand.CommandText = myUpdateQuery;
				myInsertCommand.Connection = conn1;
				conn1.Open();
				myInsertCommand.ExecuteNonQuery();
				conn1.Close();

			}
			Response.Redirect("Unregistered_Calls.aspx");
		}

		protected void btnDelConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{
				string myDeleteQuery = ("Delete T70_UNREGISTERED_CALLS where IE_CD=" + icode);
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
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
			Response.Redirect("Unregistered_Calls.aspx");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Unregistered_Calls.aspx");
		}
	}
}