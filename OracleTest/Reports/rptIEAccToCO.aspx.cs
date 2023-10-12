using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Reports
{
    public partial class rptIEAccToCO : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Panel Panel_2;
		protected System.Web.UI.WebControls.Panel Panel_1;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!(IsPostBack))
			{

				Panel_2.Visible = false;
				Panel_1.Visible = true;
				disall();
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		void disall()
		{
			string wRegion = "";

			//			conn.Open();
			//			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn);
			//			string ss=Convert.ToString(cmd2.ExecuteScalar());
			//			conn.Close();
			DataSet dsP = new DataSet();
			string sql = "select T08.CO_CD, (T08.CO_NAME||' / '||T07.R_DESIGNATION) CO_NAME from T08_IE_CONTROLL_OFFICER T08, T07_RITES_DESIG T07 where T08.CO_DESIG=T07.R_DESIG_CD and T08.CO_STATUS IS NULL and T08.CO_REGION='" + Session["Region"].ToString() + "'";
			OracleDataAdapter da = new OracleDataAdapter(sql, conn1);
			OracleCommand myOracleCommand = new OracleCommand(sql, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			conn1.Close();
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region, RITES Ltd."; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region, RITES Ltd."; }

			int ctr = 60;
			string first_page = "Y";

			try
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					if (ctr > 50)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='4'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='4'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>Controlling Officer's Wise Inspection Engineers  </font></p>");
						//Response.Write("<P align='center'><font face='Verdana' size=2><B>Calls marked during "+wHdr_YrMth+"</B</font><br></p>");
						Response.Write("");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='25%' valign='top' align='center'><b><font size='1' face='Verdana'>Controlling Officer</font></b></th>");
						Response.Write("<th width='25%' valign='top' align='center'><b><font size='1' face='Verdana'>Cluster Name (IE Name)</font></b></th>");
						Response.Write("<th width='25%' valign='top' align='center'><b><font size='1' face='Verdana'>Local IE</font></b></th>");
						Response.Write("<th width='25%' valign='top' align='center'><b><font size='1' face='Verdana'>OutStation IE</font></b></th>");
						Response.Write("</tr></font>");

						ctr = 5;
					};


					Response.Write("<tr>");
					Response.Write("<td width='25%' valign='top' align='Left'><b><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["CO_NAME"].ToString() + "</font></b></td>");
					string str3 = "select (t99.cluster_name||' ('||T09.ie_name||')') cluster_name from T08_IE_CONTROLL_OFFICER T08,t99_cluster_master t99,t101_ie_Cluster t101,t09_ie t09 where t99.cluster_code= t101.cluster_code" +
						" and t101.ie_code= t09.ie_cd and t09.ie_co_cd= T08.co_cd and T08.CO_STATUS IS NULL and T08.CO_REGION='N' and t09.ie_status is null  and t08.co_cd=" + dsP.Tables[0].Rows[i]["CO_CD"].ToString() + " order by T09.ie_name,t99.cluster_name";
					OracleCommand cmd3 = new OracleCommand(str3, conn1);
					conn1.Open();
					OracleDataReader reader3 = cmd3.ExecuteReader();
					Response.Write("<td width='25%' valign='top' align='Left'>");
					while (reader3.Read())
					{
						Response.Write("<font size='1' face='Verdana'>" + reader3["cluster_name"].ToString() + "</font><br>");
					}
					Response.Write("</td>");
					conn1.Close();
					string str1 = "Select (T09.IE_NAME||' ('||T03.CITY||')')IE_NAME from T09_IE T09, T03_CITY T03 where T09.IE_CITY_CD=T03.CITY_CD and (IE_TYPE='LC' OR IE_TYPE is NULL) and IE_STATUS is null and IE_CO_CD=" + dsP.Tables[0].Rows[i]["CO_CD"].ToString();
					OracleCommand cmd1 = new OracleCommand(str1, conn1);
					conn1.Open();
					OracleDataReader reader1 = cmd1.ExecuteReader();
					Response.Write("<td width='25%' valign='top' align='Left'>");
					while (reader1.Read())
					{
						Response.Write("<font size='1' face='Verdana'>" + reader1["IE_NAME"].ToString() + "</font><br>");
					}
					Response.Write("</td>");
					conn1.Close();
					string str2 = "Select (T09.IE_NAME||' ('||T03.CITY||')')IE_NAME from T09_IE T09, T03_CITY T03 where T09.IE_CITY_CD=T03.CITY_CD and IE_TYPE='OU' and IE_STATUS is null and IE_CO_CD=" + dsP.Tables[0].Rows[i]["CO_CD"].ToString();
					OracleCommand cmd2 = new OracleCommand(str2, conn1);
					conn1.Open();
					OracleDataReader reader2 = cmd2.ExecuteReader();
					Response.Write("<td width='25%' valign='top' align='Left'>");
					while (reader2.Read())
					{
						Response.Write("<font size='1' face='Verdana'>" + reader2["IE_NAME"].ToString() + "</font><br>");
					}
					Response.Write("</td>");
					conn1.Close();
					Response.Write("</tr></font>");
					ctr = ctr + 1;


				};

				Response.Write("</table></html>");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("/RBS/Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
			}
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Panel_2.Visible = false;
			Panel_1.Visible = true;
			disall();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = false;
			Panel_2.Visible = false;
			disall();
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/MainForm.aspx");
		}
	}
}
