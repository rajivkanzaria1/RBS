using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_ALTIE_REPORT
{
	public partial class IE_ALTIE_REPORT : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
		protected void radiochanged(object sender, System.EventArgs e)

		{

			xyz.Visible = false;


			//string sql="select ROW_NUMBER()  OVER (ORDER BY  ie_name) As SrNo, ie_name as IE_NAME, (select IE_NAME FROM T09_IE WHERE IE_CD=a.ALT_IE)ALTIE_NAME  from t09_ie a where ie_region='N' and ie_status is null and alt_ie is not null and alt_ie<>0 order by a.ie_name";
			string sql = "select ROW_NUMBER()  OVER (ORDER BY  ie_name) As SrNo, ie_name as IE_NAME, (select IE_NAME FROM T09_IE WHERE IE_CD=a.ALT_IE)ALTIE_NAME,(select IE_NAME FROM T09_IE WHERE IE_CD=a.ALT_IE_two)ALTIE_two_NAME,(select IE_NAME FROM T09_IE WHERE IE_CD=a.ALT_IE_three)ALTIE_three_NAME  from t09_ie a where ie_region='" + Session["Region"].ToString() + "' and ie_status is null and alt_ie is not null  and alt_ie<>0 order by a.ie_name";
			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='3'>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='6'>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='1%' align='center'><b><font size='1' face='Verdana'>SR.NO</font></b></th>");
				Response.Write("<th width='15%' align='center'><b><font size='1' face='Verdana'>IE NAME</font></b></th>");
				Response.Write("<th width='15%' align='center'><b><font size='1' face='Verdana'>Alternate IE I</font></b></th>");
				Response.Write("<th width='15%' align='center'><b><font size='1' face='Verdana'>Alternate IE II</font></b></th>");
				Response.Write("<th width='15%' align='center'><b><font size='1' face='Verdana'>Alternate IE III</font></b></th>");
				Response.Write("</tr></font>");
				while (reader.Read())
				{
					Response.Write("<tr>");
					Response.Write("<td width='1%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["SrNo"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ALTIE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ALTIE_two_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["ALTIE_three_NAME"]); Response.Write("</td>");
					Response.Write("</tr>");
				};

				Response.Write("</table>");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn.Close();
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