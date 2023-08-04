using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.R_Login_Form
{
	public class R_Login_Form1 : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.TextBox txtRole;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink HyperLink3;
		protected System.Web.UI.WebControls.HyperLink HyperLink5;
		protected System.Web.UI.WebControls.HyperLink HyperLink6;
		protected System.Web.UI.WebControls.Image Image3;
		protected System.Web.UI.WebControls.TextBox txtUname;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Button btnChangePwd;
		protected System.Web.UI.WebControls.HyperLink HyperLink4;
		protected System.Web.UI.WebControls.TextBox txtPwd;
		string reg;


		[System.Diagnostics.DebuggerStepThrough()]

		private void Page_Init(object sender, System.EventArgs e)
		{
			InitializeComponent();
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
			this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				string str2 = "";
				OracleDataReader or1;
				string str1 = "select AUTH_LEVL,REGION from T02_USERS where USER_ID='" + txtUname.Text + "' and PASSWORD= '" + txtPwd.Text + "' and STATUS is null";
				OracleCommand myOracleCommand = new OracleCommand(str1, conn);
				conn.Open();
				or1 = myOracleCommand.ExecuteReader();
				if (!or1.HasRows)
				{
					conn.Close();
					DisplayAlert("Invalid User Id / Password");
				}
				else
				{
					while (or1.Read())
					{
						str2 = or1.GetInt64(0).ToString();
						reg = or1.GetString(1);
					}
					conn.Close();
					Session["Uname"] = txtUname.Text;
					Session["Region"] = reg;


					if (str2 == "1")
					{
						Session["Role"] = "Administrator";
						//						Response.Redirect("MainForm.aspx?Role=1"); 

						Response.Write("<script language=JavaScript>var oWin= window.open('MainForm.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
						Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
						Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
					}
					else if (str2 == "2")
					{
						Session["Role"] = "D E Operator";
						//Response.Redirect("MainForm2.aspx?Role=2"); 

						Response.Write("<script language=JavaScript>var oWin= window.open('MainForm2.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
						Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
						Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
					}
					else if (str2 == "3")
					{
						Session["Role"] = "Insp. Engineer";
						//Response.Redirect("MainForm2.aspx?Role=3"); 

						Response.Write("<script language=JavaScript>var oWin= window.open('MainForm2.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
						Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
						Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
					}
					else if (str2 == "4")
					{
						Session["Role"] = "General User ";
						Response.Redirect("MainForm2.aspx?Role=4");

						Response.Write("<script language=JavaScript>var oWin= window.open('MainForm2.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
						Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
						Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
					}
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
			finally
			{
				conn.Close();
			}
		}

		private void btnChangePwd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Change_Pwd_Form.aspx");
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
	}
}