using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Vendor
{
    public partial class Vendor_Login_Form : System.Web.UI.Page
    {
		protected System.Web.UI.WebControls.Button btnLogin;
		protected System.Web.UI.WebControls.TextBox txtPwd;
		protected System.Web.UI.WebControls.TextBox txtUserId;
		protected System.Web.UI.WebControls.Button btnCPWD;
		protected System.Web.UI.WebControls.HyperLink HyperLink2;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		OracleConnection conn = null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			btnLogin.Attributes.Add("OnClick", "JavaScript:validate();");
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
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			this.btnCPWD.Click += new System.EventHandler(this.btnCPWD_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			 conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			
			try
			{
				string mySql = "Select VEND_CD,VEND_NAME,VEND_PWD from T05_VENDOR Where VEND_CD=" + txtUserId.Text + " and VEND_PWD='" + txtPwd.Text + "'";
				OracleCommand cmd = new OracleCommand(mySql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				if (!reader.HasRows)
				{
					conn.Close();
					Response.Write("<script language=JavaScript> alert('Invalid User Id / Password'); </script>");
				}
				else
				{
					reader.Read();
					Session["VEND_CD"] = Convert.ToString(reader["VEND_CD"]);
					conn.Close();
					Response.Write("<script language=JavaScript>var oWin= window.open('Vendor_Menu.aspx?pVendCD=" + Session["VEND_CD"].ToString() + "','', 'fullscreen=yes, scrollbars=yes');");
					Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
					Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
				}
			}
			catch (Exception ex)
			{
				string str = ex.Message.Replace("\n", "");
				if (str.Substring(1, 3) == "ORA")
				{ Response.Write("<script language=JavaScript> alert('Invalid User Id / Password'); </script>"); }
				else
				{ Response.Redirect(("Error_Form.aspx?err=" + str)); }

			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		private void btnCPWD_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Vendor_Change_Pwd_Form.aspx");
		}
	}
}
