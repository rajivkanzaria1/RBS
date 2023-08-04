using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Upload_CheckSheet
{
	public class Upload_CheckSheet1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList lstDiscipline;
		protected System.Web.UI.WebControls.TextBox txtChkShtName;
		protected System.Web.UI.WebControls.TextBox txtDocNo;
		protected System.Web.UI.WebControls.TextBox txtIssueDt;
		protected System.Web.UI.WebControls.Button btnUpload;
		OracleConnection Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		private void Page_Load(object sender, System.EventArgs e)
		{
			Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			Conn.Open();
			OracleCommand cmd = new OracleCommand("Select nvl(ALLOW_UP_CHKSHT,'N') From T02_USERS Where USER_ID='" + Session["Uname"] + "'", Conn);
			string wAns = Convert.ToString(cmd.ExecuteScalar());
			Conn.Close();
			Conn.Dispose();
			if (wAns == "Y")
			{ btnUpload.Attributes.Add("OnClick", "JavaScript:validate();"); }
			else
			{
				Response.Redirect("Error_Form.aspx?err=You Are Not Allowed To Perform This Action.");
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
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					string MySql = "Select lpad(nvl(max(to_number(nvl(trim(substr(CHK_SHEET_ID,2,4)),'0'))),0)+1,4,'0') " +
								 "From T74_CHECKSHEET_CATALOG where DISCIPLINE='" + lstDiscipline.SelectedValue + "'";
					Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					Conn.Open();
					OracleCommand cmd1 = new OracleCommand(MySql, Conn);
					MyFile = Convert.ToString(cmd1.ExecuteScalar());
					MyFile = lstDiscipline.SelectedValue + MyFile;
					//
					OracleCommand cmd2 = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", Conn);
					string wDate = Convert.ToString(cmd2.ExecuteScalar());
					//
					fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("Documents/Checksheets/" + MyFile + "." + fx);
					File1.PostedFile.SaveAs(SaveLocation);
					//
					MySql = "Insert into T74_CHECKSHEET_CATALOG(CHK_SHEET_ID,FILE_EXT,CHK_SHEET_NAME,DISCIPLINE,DOCUMENT_NO,ISSUE_DT,USER_ID,DATETIME) " +
						"values " +
						"('" + MyFile + "','" + fx + "','" + txtChkShtName.Text + "','" + lstDiscipline.SelectedValue + "','" + txtDocNo.Text + "',to_date('" + txtIssueDt.Text + "','dd/mm/yyyy')" +
						",'" + Session["Uname"] + "',to_date('" + wDate + "','dd/mm/yyyy'))";
					OracleCommand cmd3 = new OracleCommand(MySql, Conn);
					cmd3.ExecuteNonQuery();
					//
					DisplayAlert("The file [" + fn + "] has been uploaded.");
				}
				else
				{
					DisplayAlert("Please select a file to upload.");
				}
			}
			catch (FileNotFoundException fe)
			{ Response.Write("File not found" + fe); }
			catch (System.IO.DirectoryNotFoundException de)
			{ Response.Write("Directry not found" + de); }
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				Conn.Close();
				Conn.Dispose();
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

	}
}