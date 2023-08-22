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
	public partial class rptIC_STATUS : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Panel Panel_2;
		protected System.Web.UI.WebControls.RadioButton rdbAll;
		protected System.Web.UI.WebControls.RadioButton rdbGIE;
		protected System.Web.UI.WebControls.Label lblIE;
		protected System.Web.UI.WebControls.DropDownList lstIE;
		protected System.Web.UI.WebControls.Label lblSIE;
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string wFrmDt, wToDt, wRegion;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			if (!(IsPostBack))
			{
				DataSet dsP1 = new DataSet();
				string str3 = "select IE_CD, IE_NAME from T09_IE where IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn);
				ListItem lst3;
				conn.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
				{
					lst3 = new ListItem();
					lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString();
					lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString();
					lstIE.Items.Add(lst3);
				}
				conn.Close();
				conn.Dispose();

				lstIE.Visible = false;
				lblIE.Visible = false;
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
			this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
			this.rdbGIE.CheckedChanged += new System.EventHandler(this.rdbGIE_CheckedChanged);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		void IC_STATUS()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			Panel_2.Visible = false;
			Panel_1.Visible = true;
			wToDt = toDt.Text.Trim();
			wFrmDt = frmDt.Text.Trim();
			wRegion = "";
			if (Session["Region"].ToString() == "N")
			{
				wRegion = "Northern Region";
			}
			else if (Session["Region"].ToString() == "S")
			{
				wRegion = "Southern Region";
			}
			else if (Session["Region"].ToString() == "E")
			{
				wRegion = "Eastern Region";
			}
			else if (Session["Region"].ToString() == "W")
			{
				wRegion = "Western Region";
			}
			else if (Session["Region"].ToString() == "C")
			{
				wRegion = "Central Region";
			}

			string sql = "select to_char(T30.IC_SUBMIT_DT,'dd/mm/yyyy') IC_SUBMIT_DATE,T09.IE_NAME,T30.BK_NO,T30.SET_NO,NVL(T30.BILL_NO,'Un-Billed IC') BILL_NO from T30_IC_RECEIVED T30, T09_IE T09 where T30.IE_CD=T09.IE_CD and (T30.IC_SUBMIT_DT between to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and REGION='" + Session["Region"] + "' ";
			if (rdbGIE.Checked == true)
			{
				sql = sql + " and T30.IE_CD=" + lstIE.SelectedValue;
			}
			sql = sql + " order by T30.IC_SUBMIT_DT,T09.IE_CD,T30.BK_NO,T30.SET_NO";


			int wSno = 0;

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='90%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='6'>");
				Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
				if (rdbGIE.Checked == true)
				{
					Response.Write("<H5 align='center'><font face='Verdana'>IC's Status Report For the IE: " + lstIE.SelectedItem + " , For the Period: " + frmDt.Text + " To " + toDt.Text + "</font><br></p>");
				}
				else
				{
					Response.Write("<H5 align='center'><font face='Verdana'>IC's Status Report For the Period: " + frmDt.Text + " To " + toDt.Text + "</font><br></p>");
				}
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>IC Submit Date</font></th>");
				Response.Write("<th width='30%' valign='top'><font size='2' face='Verdana'>IE</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>BK NO.</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>SET No.</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>BILL No.</font></th>");
				Response.Write("</tr>");

				while (reader.Read())
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["IC_SUBMIT_DATE"]); Response.Write("</td>");
					Response.Write("<td width='30%' valign='top' align='Left'> <font size='2' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
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
				conn.Dispose();
			}
		}
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			IC_STATUS();
			btnPrint.Visible = false;
			btnBack.Visible = false;
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/MainForm.aspx");
		}
		void radiochange()
		{
			if (rdbAll.Checked == true)
			{
				lstIE.Visible = false;
				lblIE.Visible = false;
			}
			else
			{
				lstIE.Visible = true;
				lblIE.Visible = true;
			}
		}
		private void rdbAll_CheckedChanged(object sender, System.EventArgs e)
		{
			radiochange();
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{

			IC_STATUS();
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/MainForm.aspx");
		}

		private void rdbGIE_CheckedChanged(object sender, System.EventArgs e)
		{
			radiochange();
		}
	}
}