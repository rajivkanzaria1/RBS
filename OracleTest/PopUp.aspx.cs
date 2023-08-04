using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.PopUp
{
	public partial class PopUp : System.Web.UI.Page
	{
		string msg;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Convert.ToString(Request.QueryString["str"]) == "")
			{
				msg = "";
			}
			else
			{
				msg = Convert.ToString(Request.QueryString["str"]);
				Label3.Text = msg;

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

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			string popupScript = "<script language='javascript'>" + "window.close('PopUp.aspx')" + "</script>";

			Page.RegisterStartupScript("PopupScript", popupScript);
		}
	}
}