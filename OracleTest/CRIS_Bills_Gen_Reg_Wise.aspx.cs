using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.CRIS_Bills_Gen_Reg_Wise
{
	public partial class CRIS_Bills_Gen_Reg_Wise : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Session["Region"].ToString() == "N")
			{
				Response.Redirect("http://49.50.102.182/home?region=N");
			}
			else if (Session["Region"].ToString() == "S")
			{
				Response.Redirect("http://49.50.102.182/home?region=S");
			}
			else if (Session["Region"].ToString() == "E")
			{
				Response.Redirect("http://49.50.102.182/home?region=E");
			}
			else if (Session["Region"].ToString() == "W")
			{
				Response.Redirect("http://49.50.102.182/home?region=W");
			}
			else if (Session["Region"].ToString() == "C")
			{
				Response.Redirect("http://49.50.102.182/home?region=C");
			}
			else if (Session["Region"].ToString() == "Q")
			{
				Response.Redirect("http://49.50.102.182/home?region=Q");
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
	}
}