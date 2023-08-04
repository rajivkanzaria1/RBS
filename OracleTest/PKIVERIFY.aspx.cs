using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.PKIVERIFY
{
	public partial class PKIVERIFY : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				if (Request.Form["file"] != null)
				{
					string xmlResp = Request.Form["file"];
					// Response.Write(xmlResp);

					//string filename=  "12345678"; 
					string filename = Request.Form["filename"];

					using (StreamWriter writetext = new StreamWriter(Server.MapPath("IC_VERIFY/" + filename + ".xml")))
					{
						writetext.WriteLine(xmlResp);
					}


					//DateTime.Now.ToFileTime().ToString();

					//XmlDocument XmlDoc=new XmlDocument();
					//XmlDoc.LoadXml(xmlResp);
					//XmlDoc.Save(Server.MapPath("pkiresponse.xml"));
					Response.Write(filename);
				}

				//Response.Write("&saving the file");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form_PKI.aspx?err=" + str1));
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