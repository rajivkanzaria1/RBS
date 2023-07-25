namespace RBS.Vendor
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;
	
    using Oracle.ManagedDataAccess.Client;


    /// <summary>
    ///		Summary description for WebUserControl1.
    /// </summary>
    public class WebUserControl_Vend : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink HyperLink2;
		protected System.Web.UI.WebControls.Label lblVend_CD;
		protected System.Web.UI.WebControls.Label lblUID;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		OracleConnection conn = null;

		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				if(Convert.ToString(Session["VEND_CD"])=="")
				{
						Response.Write("<script language=JavaScript>var oWin=window.open('Vendor_Session_Expired.aspx', '', " + "'width=350, height=125, menubar=no, resizable=no,alwaysRaised=true');");
						Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
						Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
					
				}
				else
				{
					conn.Open();
					OracleCommand cmd =new OracleCommand("Select (trim(T05.VEND_NAME)||','||trim(T05.VEND_ADD1)||','||NVL2(T03.LOCATION,T03.LOCATION||','||T03.CITY,T03.CITY)) Vendor from T05_VENDOR T05, T03_CITY T03 where T05.VEND_CITY_CD=T03.CITY_CD and  VEND_CD='"+Session["VEND_CD"]+"'",conn);
					string vend_name =Convert.ToString(cmd.ExecuteScalar());
					conn.Close();
					lblVend_CD.Text="Vendor CD: <font color=OrangeRed size=1>" + Session["VEND_CD"].ToString()+"</Font>"; 
					lblUID.Text = "Vendor: <font color=OrangeRed size=1>" + vend_name+"</Font>"; 
								
					
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
