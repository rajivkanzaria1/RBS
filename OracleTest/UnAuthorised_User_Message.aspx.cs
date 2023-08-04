using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.UnAuthorised_User_Message
{
	public partial class UnAuthorised_User_Message : System.Web.UI.Page
	{


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!(IsPostBack))
			{
				//				if(Convert.ToString(Request.QueryString["err"])=="")
				//					Label2.Text="Their is an error in your previous page";
				//				else
				//                    Label2.Text = Request.QueryString["err"].ToString(); 
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

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("User_Administration.aspx");
		}
	}
}