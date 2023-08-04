using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.LogOut
{
	public partial class LogOut : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Session.Abandon();
			Session.RemoveAll();

			//Response.Write("<script language='Javascript'>top.location='Login_Form.aspx';</script>");
			Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
			//Response.Redirect("Login_Form.aspx");

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