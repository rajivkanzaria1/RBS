using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Calls_Upload
{
	public partial class Calls_Upload : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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



		protected void Submit1_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
				{
					String fn = "";
					fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("Calls/" + fn);
					//SaveLocation = "//172.16.7.76/madan/"+fn;
					File1.PostedFile.SaveAs(SaveLocation);
					Response.Write("The file has been uploaded.");
				}
				else
				{
					Response.Write("Please select a file to upload.");
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
				Response.Write(ex);
			}
		}
	}
}