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

namespace RBS.CheckSheets_Form
{
	public partial class CheckSheets_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Label Label3;
		protected Tittle.Controls.CustomDataGrid DgCK1;
		protected System.Web.UI.WebControls.DropDownList lstDescipline;
		protected System.Web.UI.WebControls.Label Label5;

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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.DgCK1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DgCK1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleDataAdapter da1 = null;
			try
			{
				string str1 = "select CHK_SHEET_ID,CHK_SHEET_NAME,DOCUMENT_NO,'Documents/Checksheets/'||CHK_SHEET_ID||'.pdf' CK_DOC from T74_CHECKSHEET_CATALOG where DISCIPLINE='" + lstDescipline.SelectedValue + "'";


				string str2 = str1 + " ORDER BY CHK_SHEET_ID";

				da1 = new OracleDataAdapter(str2, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				//OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1); 
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgCK1.Visible = false;
					//repdiv.Visible=false;
					//Label6.Visible =true;
					//						throw new System.Exception("No PurchaseOrder found. !!! ");
					//					lblError.Visible=true;
					DgCK1.Visible = false;

				}
				else
				{
					DgCK1.DataSource = dsP1;
					DgCK1.DataBind();
					DgCK1.Visible = true;
					//					lblError.Visible=false;
					//repdiv.Visible=true;
					//Label6.Visible =false;
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

		private void DgCK1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string fpath = Server.MapPath("/RBS/");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				fpath = fpath + Convert.ToString(e.Item.Cells[3].Text);
				if (File.Exists(fpath) == false)
				{
					e.Item.Cells[3].Text = "<Font Face=Verdana Color=RED>No CheckSheet Available!!!</Font>";
				}
				else
				{
					e.Item.Cells[3].Text = "<a href=" + Convert.ToString(e.Item.Cells[3].Text) + ">Download CheckSheet</a>";
				}
			}
		}
	}
}