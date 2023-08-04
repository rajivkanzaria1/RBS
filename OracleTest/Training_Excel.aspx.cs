using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Training_Excel
{
	public partial class Training_Excel : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (Session["Region"].ToString() == "N")
			{
				HyperLinkTraining.NavigateUrl = "/RBS/NR Training Matrix September 2017.xlsx";
			}
			else if (Session["Region"].ToString() == "W")
			{
				HyperLinkTraining.NavigateUrl = "/RBS/WR Training Matrix September 2017.xlsx";
			}
			else if (Session["Region"].ToString() == "S")
			{
				HyperLinkTraining.NavigateUrl = "/RBS/SR Training Matrix September 2017.xlsx";
			}
			else if (Session["Region"].ToString() == "E")
			{
				HyperLinkTraining.NavigateUrl = "/RBS/ER Training Matrix September 2017.xlsx";
			}
			else if (Session["Region"].ToString() == "C")
			{
				HyperLinkTraining.NavigateUrl = "/RBS/CR Training Matrix September 2017.xlsx";
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