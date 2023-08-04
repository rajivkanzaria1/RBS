using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.User_Administration
{
	public partial class User_Administration : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		int code = new int();


		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Convert.ToString(Session["Role"]) == "Administrator")
			{
				try
				{
					string str1 = "select USER_ID,USER_NAME,decode(RITES_EMP,'Y','Yes','No')RITES_EMP,EMP_NO,R.REGION REGION," +
						"decode(AUTH_LEVL,1,'Administrator',2,'Data Entry Operator',3,'Inspection Engineer',4,'General User','') AUTH_LEVL," +
						"decode(STATUS,'','Active','Inactive') STATUS from T02_USERS U,T01_REGIONS R where R.REGION_CODE = U.REGION AND U.REGION='" + Session["Region"] + "' order by upper(USER_NAME)";
					OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP, "Table");
					grdUser.DataSource = dsP;
					grdUser.DataBind();
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
			else
			{
				Response.Redirect(("Error_Form.aspx?err=You are not authorised to perform the action selected by you."));
			}
		}

		protected void btnUserAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("User_Edit.aspx?USER_ID=");
		}

		private void grdUser_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grdUser.CurrentPageIndex = e.NewPageIndex;
			try
			{
				string str1 = "select USER_ID, USER_NAME,RITES_EMP,EMP_NO,REGION, AUTH_LEVL,NVL(STATUS,'NULL') STATUS from T02_USERS order by upper(USER_NAME)";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				grdUser.DataSource = dsP;
				grdUser.DataBind();
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
	}
}