using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.rptIEWiseCallDetails
{
	public class rptIEWiseCallDetails1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.DataGrid grdIE;
		protected System.Web.UI.WebControls.Button btnSubmit;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{


			try
			{
				string str1 = "select T09.IE_NAME,T17.IE_CD, count(T17.CASE_NO)NO_OF_CALLS from T17_CALL_REGISTER T17, T09_IE T09 where T17.IE_CD=T09.IE_CD";
				DataSet dsP = new DataSet();
				str1 = str1 + " and T17.CALL_MARK_DT between to_date('" + frmDt.Text + "','dd/mm/yyyy') and to_date('" + toDt.Text + "','dd/mm/yyyy') group by T09.IE_NAME,T17.IE_CD ORDER BY IE_NAME";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdIE.Visible = false;

				}
				else
				{
					grdIE.DataSource = dsP;
					grdIE.DataBind();
					grdIE.Visible = true;
					//Label4.Visible =false;
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
	}
}