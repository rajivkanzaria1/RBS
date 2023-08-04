using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_Login_Form
{
	public partial class IE_Login_Form : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
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

		}
		#endregion

		protected void btnLogin_Click(object sender, System.EventArgs e)
		{
			try
			{
				string mySql = "Select IE_CD,IE_NAME,IE_EMP_NO,IE_PWD,IE_REGION from T09_IE Where IE_EMP_NO=" + txtUserId.Text + " and IE_PWD='" + txtPwd.Text + "' and IE_STATUS is null";
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
					string wIECD = Convert.ToString(reader["IE_CD"]);
					string wIENAME = Convert.ToString(reader["IE_NAME"]);
					Session["IE_NAME"] = Convert.ToString(reader["IE_NAME"]);
					Session["Region"] = Convert.ToString(reader["IE_REGION"]);
					Session["IE_CD"] = Convert.ToString(reader["IE_CD"]);
					Session["IE_EMP_NO"] = Convert.ToString(reader["IE_EMP_NO"]);
					conn.Close();
					Response.Write("<script language=JavaScript>var oWin= window.open('IE_Instructions.aspx?pIECD=" + wIECD + "&pIENAME=" + wIENAME + "','', 'fullscreen=yes, scrollbars=yes');");
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

		protected void btnCPWD_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Change_IE_Pwd_Form.aspx");
		}
	}
}