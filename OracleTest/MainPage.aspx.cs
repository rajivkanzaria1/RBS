using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.MainPage
{
	public partial class MainPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected Tittle.Controls.CustomDataGrid grdMessage;
		protected System.Web.UI.WebControls.Label lblDashboard;

		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				//				OracleCommand cmd=new OracleCommand("Select to_char(add_months(sysdate,-1),'dd/mm/yyyy')DtFr,to_char(sysdate,'dd/mm/yyyy')DtTo from dual",conn);
				//				OracleCommand cmd=new OracleCommand("Select to_char(sysdate-30,'dd/mm/yyyy')DtFr,to_char(sysdate,'dd/mm/yyyy')DtTo from dual",conn);
				//				conn.Open();
				//				OracleDataReader reader = cmd.ExecuteReader();
				//				if (!(IsPostBack))
				//				{
				//					while(reader.Read())
				//					{
				//						HyperLinkNR.NavigateUrl="/RBS/Calls_Marked_Report.aspx?pDtFR="+Convert.ToString(reader["DtFr"])+"&pDtTo="+Convert.ToString(reader["DtTo"])+"&pRegion=N&pSortKey=V";
				//						HyperLinkER.NavigateUrl="/RBS/Calls_Marked_Report.aspx?pDtFR="+Convert.ToString(reader["DtFr"])+"&pDtTo="+Convert.ToString(reader["DtTo"])+"&pRegion=E&pSortKey=V";
				//						HyperLinkSR.NavigateUrl="/RBS/Calls_Marked_Report.aspx?pDtFR="+Convert.ToString(reader["DtFr"])+"&pDtTo="+Convert.ToString(reader["DtTo"])+"&pRegion=S&pSortKey=V";
				//						HyperLinkWR.NavigateUrl="/RBS/Calls_Marked_Report.aspx?pDtFR="+Convert.ToString(reader["DtFr"])+"&pDtTo="+Convert.ToString(reader["DtTo"])+"&pRegion=W&pSortKey=V";
				//					}
				//					reader.Close();
				//				}
				//				conn.Close();


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				DisplayAlert("ORACLE NOT AVAILABLE!!!");
				//DisplayAlert("Database Not Found!!!");
			}
			finally
			{
				conn.Close();
			}

			//			fillgrid();
		}

		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				conn.Open();
				OracleCommand cmd4 = new OracleCommand("select to_char(sysdate-1, 'dd/mm/yyyy') from dual", conn);
				string slycm = Convert.ToString(cmd4.ExecuteScalar());
				string scfy = "";
				if (Convert.ToInt16(slycm.Substring(3, 2)) >= 4)
				{
					scfy = slycm.Substring(6, 4);
				}
				else
				{
					scfy = Convert.ToString(Convert.ToInt16(slycm.Substring(6, 4)) - 1);
				}

				string slfy = Convert.ToString(Convert.ToInt16(scfy) - 1);
				string str1 = "SELECT REGION, SUM(NO_OF_INSP_YEST) NO_OF_INSP_YEST,SUM(NO_OF_INSP_COMM) NO_OF_INSP_COMM FROM " +
					"(" +
					"select DECODE(REGION_CODE,'N','NR','S','SR','E','ER','W','WR','C','CR','QA') REGION,count(*) NO_OF_INSP_YEST, 0 NO_OF_INSP_COMM from T17_CALL_REGISTER WHERE (CALL_STATUS_DT = to_date('" + slycm + "','dd/mm/yyyy')) AND CALL_STATUS!='M' group by DECODE(REGION_CODE,'N','NR','S','SR','E','ER','W','WR','C','CR','QA') " +
					"Union All " +
					"select DECODE(REGION_CODE,'N','NR','S','SR','E','ER','W','WR','C','CR','QA') REGION,0 NO_OF_INSP_YEST,count(*) NO_OF_INSP_COMM from T17_CALL_REGISTER WHERE (CALL_STATUS_DT BETWEEN to_date('01/04/" + scfy + "','dd/mm/yyyy') AND to_date('" + slycm + "','dd/mm/yyyy')) AND CALL_STATUS!='M' group by DECODE(REGION_CODE,'N','NR','S','SR','E','ER','W','WR','C','CR','QA') " +
					") GROUP BY REGION ORDER BY REGION";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn);
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdMessage.Visible = false;
				}
				else
				{
					grdMessage.Visible = true;
					grdMessage.DataSource = dsP;
					grdMessage.DataBind();
				}
				conn.Close();
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
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