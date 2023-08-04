using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Download_CheckSheet
{
	public partial class Download_CheckSheet : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList lstDescipline;
		protected System.Web.UI.WebControls.Label lbl;
		protected System.Web.UI.WebControls.TextBox txtCheckSheet;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected Tittle.Controls.CustomDataGrid DgCK;
		protected System.Web.UI.WebControls.Label Label2;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Convert.ToString(Request.Params["allowDL"]) == "Y")
			{
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn.Open();
				OracleCommand cmd = new OracleCommand("Select nvl(ALLOW_DN_CHKSHT,'N') From T02_USERS Where USER_ID='" + Session["Uname"] + "'", conn);
				string wAns = Convert.ToString(cmd.ExecuteScalar());
				conn.Close();
				conn.Dispose();
				if (wAns != "Y")
				{
					Response.Redirect("Error_Form.aspx?err=You Are Not Allowed To Perform This Action.");
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.DgCK.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DgCK_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			string str1 = "", str2 = "";
			if (lstDescipline.SelectedValue != "")
			{ str1 = "DISCIPLINE='" + lstDescipline.SelectedValue + "'"; }
			if (txtCheckSheet.Text.Trim() != "")
			{ str2 = "upper(CHK_SHEET_NAME) like upper('%" + txtCheckSheet.Text + "%')"; }
			if (str1 == "" & str2 == "")
			{ DisplayAlert("Nothing to Search!!"); }
			else
			{
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				OracleDataAdapter da = null;
				try
				{
					string str = "select (CHK_SHEET_ID||'.'||FILE_EXT) FILE_NAME,CHK_SHEET_NAME,DISCIPLINE,DOCUMENT_NO,to_char(ISSUE_DT,'dd/mm/yyyy')ISSUE_DT,('Documents/Checksheets/'||CHK_SHEET_ID||'.'||FILE_EXT) CK_DOC from T74_CHECKSHEET_CATALOG where ";
					if ((str1 != "") & (str2 != ""))
					{ str = str + str1 + " and " + str2; }
					else
					{ str = str + str1 + str2; }
					str = str + " order by CHK_SHEET_NAME";
					da = new OracleDataAdapter(str, conn);
					DataSet dsP = new DataSet();
					OracleCommand myOracleCommand = new OracleCommand(str, conn);
					conn.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP, "Table");
					if (dsP.Tables[0].Rows.Count == 0)
					{
						DgCK.Visible = false;
						DgCK.Visible = false;
						DisplayAlert("No Data Found !!");
					}
					else
					{
						DgCK.DataSource = dsP;
						DgCK.DataBind();
						DgCK.Visible = true;
					}
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					str = str.Replace("\n", "");
					Response.Redirect(("Error_Form.aspx?err=" + str));
				}
				finally
				{
					conn.Close();
					conn.Dispose();
				}
			}
		}

		private void DgCK_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string fpath = Server.MapPath("/RBS/");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				fpath = fpath + Convert.ToString(e.Item.Cells[4].Text);
				if (File.Exists(fpath) == false)
				{
					e.Item.Cells[4].Text = "<Font Face=Verdana Color=RED>No CheckSheet Available!!!</Font>";
				}
				else
				{
					e.Item.Cells[4].Text = "<a href=" + Convert.ToString(e.Item.Cells[4].Text) + ">Download CheckSheet</a>";
				}
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
	}
}