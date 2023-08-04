using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Region_Selection_Form
{
	public partial class Region_Selection_Form : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
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

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if (rdbNR.Checked == true)
			{
				Session["Region"] = "N";
			}
			else if (rdbER.Checked == true)
			{
				Session["Region"] = "E";
			}
			else if (rdbWR.Checked == true)
			{
				Session["Region"] = "W";
			}
			else if (rdbSR.Checked == true)
			{
				Session["Region"] = "S";
			}
			else if (rdbCR.Checked == true)
			{
				Session["Region"] = "C";
			}
			else if (rdbQA.Checked == true)
			{
				Session["Region"] = "Q";
			}

			//						Response.Redirect("MainForm1.aspx"); 

			Response.Write("<script language=JavaScript>var oWin= window.open('MainForm.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
			Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
			Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
		}
	}
}