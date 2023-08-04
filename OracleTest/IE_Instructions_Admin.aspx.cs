using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_Instructions_Admin
{
	public partial class IE_Instructions_Admin : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string Action;
		private int code = new int();
		//		string date;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");

			if (Convert.ToString(Request.Params["MESSAGE_ID"]) == null || Convert.ToString(Request.Params["MESSAGE_ID"]) == "")
			{
				code = 0;
				//				date="";
				Action = "";
			}
			else
			{
				code = Convert.ToInt32(Request.Params["MESSAGE_ID"].Trim());
				Action = Convert.ToString(Request.Params["ACTION"].Trim());
			}

			if (!(IsPostBack))
			{
				if (Action == "D")
				{
					show();
					btnSave.Visible = false;
					btnDelConfirm.Visible = true;
				}
				else if (Action == "M")
				{
					show();
					btnSave.Enabled = true;

				}
				else
				{
					fillgrid();

				}
				if (Convert.ToString(Session["Role_CD"]) != "1")
				{
					btnSave.Enabled = false;
					btnDelConfirm.Enabled = false;
					grdMessage.Columns[0].Visible = false;
					grdMessage.Columns[1].Visible = false;
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


		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				conn1.Open();
				//				OracleCommand cmd11 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
				//				string sdate=Convert.ToString(cmd11.ExecuteScalar());
				string str1 = "select MESSAGE_ID,LETTER_NO,TO_CHAR(LETTER_DT,'dd/mm/yyyy')LETTER_DT,MESSAGE,to_char(DATETIME,'dd/mm/yyyy')DATETIME from T72_IE_MESSAGES T72 where REGION_CODE='" + Session["Region"].ToString() + "' order by T72.DATETIME DESC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdMessage.Visible = false;
				}
				else
				{
					grdMessage.Visible = true;
					grdMessage.DataSource = dsP;
					grdMessage.DataBind();
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
			int cd;
			conn1.Open();
			try
			{

				OracleCommand cmd11 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string sdate = Convert.ToString(cmd11.ExecuteScalar());

				if ((code == 0))
				{
					//string str3 = "select NVL(max(MESSAGE_CD),0) from T96_MESSAGES where DATETIME=to_date('"+sdate+"','dd/mm/yyyy')"; 
					string str3 = "select to_number(NVL(max(MESSAGE_ID),0)+1) from T72_IE_MESSAGES WHERE REGION_CODE='" + Session["Region"] + "'";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = str3;
					myInsertCommand.Connection = conn1;
					cd = Convert.ToInt32(myInsertCommand.ExecuteScalar());
					//code = cd + 1; 

					string myInsertQuery = "INSERT INTO T72_IE_MESSAGES(MESSAGE_ID,LETTER_NO,LETTER_DT,MESSAGE,USER_ID,DATETIME,REGION_CODE,MESSAGE_DT) values(" + cd + ",'" + txtLNO.Text.Trim() + "',to_date('" + txtLDT.Text + "','dd/mm/yyyy'), '" + txtMessage.Text.TrimEnd().TrimStart() + "','" + Session["Uname"] + "',to_date('" + sdate + "','dd/mm/yyyy-HH24:MI:SS'),'" + Session["Region"].ToString() + "',to_date('" + sdate + "','dd/mm/yyyy-HH24:MI:SS'))";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
				}
				else
				{

					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T72_IE_MESSAGES set MESSAGE = '" + txtMessage.Text.TrimEnd().TrimStart() + "', LETTER_NO='" + txtLNO.Text.Trim() + "', LETTER_DT=to_date('" + txtLDT.Text + "','dd/mm/yyyy'),USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + sdate + "','dd/mm/yyyy-HH24:MI:SS') where MESSAGE_ID=" + code + " and REGION_CODE='" + Session["Region"] + "' ";
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					myUpdateCommand.ExecuteNonQuery();
					int count = myUpdateCommand.ExecuteNonQuery();
					if ((count == 0))
					{
						throw new System.Exception("No Record Found!!! Any Other User had Deleted Your Record While you were Modifying");
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
			}
			Response.Redirect("IE_Instructions_Admin.aspx");



		}
		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select MESSAGE_ID,LETTER_NO,TO_CHAR(LETTER_DT,'dd/mm/yyyy')LETTER_DT,MESSAGE from T72_IE_MESSAGES where MESSAGE_ID=" + code + " and REGION_CODE='" + Session["Region"] + "' ";
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
					txtMessage.Text = dsP.Tables[0].Rows[0]["MESSAGE"].ToString();
					txtLNO.Text = dsP.Tables[0].Rows[0]["LETTER_NO"].ToString();
					txtLDT.Text = dsP.Tables[0].Rows[0]["LETTER_DT"].ToString();
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


		protected void btnDelConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{

				string myDeleteQuery = "Delete T72_IE_MESSAGES where MESSAGE_ID=" + code + " and REGION_CODE='" + Session["Region"] + "' ";
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
			Response.Redirect("IE_Instructions_Admin.aspx");
		}

		private void grdDesig_PreRender(object sender, System.EventArgs e)
		{
			fillgrid();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IE_Instructions_Admin.aspx");
		}
	}
}