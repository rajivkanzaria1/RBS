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
    public partial class pfrmIE7thCopy : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtBKNo;
		protected System.Web.UI.WebControls.TextBox txtSetNo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnSearchIC;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.DataGrid grdBook;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.Panel Panel_2;
		OracleConnection conn1 = null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearchIC.Attributes.Add("OnClick", "JavaScript:search();");

			if (!IsPostBack)
			{
				if (Convert.ToString(Request.QueryString["BK_NO"]) == "" && Convert.ToString(Request.QueryString["SET_NO_FR"]) == "")
				{
					txtBKNo.Text = "";
					txtSetNo.Text = "";
				}
				else
				{
					txtBKNo.Text = Convert.ToString(Request.QueryString["BK_NO"]);
					txtSetNo.Text = Convert.ToString(Request.QueryString["SET_NO_FR"]);
				}

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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnSearchIC.Click += new System.EventHandler(this.btnSearchIC_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		private void btnSearchIC_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select b.BK_NO,b.SET_NO_FR,b.SET_NO_TO,to_char(ISSUE_DT,'dd/mm/yyyy') ISSUE_DT,i.IE_NAME ISSUE_TO_IECD,decode(i.IE_REGION,'N','Northern','W','Western','E','Eastern','S','South','C','Central')BK_ISSUED_TO_REGION,b.BK_SUBMITTED,to_char(BK_SUBMIT_DT,'dd/mm/yyyy') BK_SUBMIT_DT from T10_IC_BOOKSET b,T09_IE i where b.ISSUE_TO_IECD=i.IE_CD ";

				if (txtBKNo.Text.Trim() != "")
				{
					str1 = str1 + " and upper(trim(BK_NO)) LIKE upper('" + txtBKNo.Text.Trim() + "')";
				}

				if (txtSetNo.Text.Trim() != "")
				{
					str1 = str1 + " and (trim(SET_NO_FR))=(" + txtSetNo.Text.Trim() + ")";
				}

				str1 = str1 + "and IE_CD='" + Session["IE_CD"].ToString() + "' ORDER BY BK_NO ,SET_NO_FR";

				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				OracleDataReader dr;
				dr = myOracleCommand1.ExecuteReader(CommandBehavior.CloseConnection);

				if (dr.HasRows)
				{
					grdBook.DataSource = dr;
					grdBook.DataBind();
					grdBook.Visible = true;
					//grdBook.Columns[1].Visible=false;
				}
				else
				{
					grdBook.Visible = false;
					DisplayAlert("Book No. Not Registered!!!");
				}
				conn1.Close();
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
				conn1.Close();
				conn1.Dispose();

			}
		}
		void seventhcopy_report()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			int wSno = 0;
			try
			{
				string sql = "SELECT CASE_NO, T.BK_NO, T.SET_NO FROM IC_INTERMEDIATE T,T10_IC_BOOKSET I WHERE T.BK_NO=I.BK_NO AND T.IE_CD=I.ISSUE_TO_IECD AND I.BK_NO='" + txtBKNo.Text.Trim() + "' AND I.SET_NO_FR='" + txtSetNo.Text.Trim() + "' AND (SET_NO BETWEEN '" + txtSetNo.Text.Trim() + "' AND I.SET_NO_TO)AND ISSUE_TO_IECD=" + Session["IE_CD"] + " AND SUBSTR(CASE_NO,1,1)='" + Session["Region"] + "' GROUP BY CASE_NO, T.BK_NO, T.SET_NO ORDER BY SET_NO";
				OracleCommand cmd = new OracleCommand(sql, conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='50%'>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='2'>");
				Response.Write("<H5 align='left'><font face='Verdana'>IE NAME: " + Session["IE_NAME"].ToString() + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("<td width='100%' colspan='2'>");
				Response.Write("<H5 align='right'><font face='Verdana'>EMP NO: " + Session["IE_EMP_NO"].ToString() + "</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#faebd7'>");
				Response.Write("<td width='100%' colspan='4'>");
				Response.Write("<H5 align='center'><font face='Verdana'>INSPECTION CERTIFICATE BOOK SET 7TH COPY REPORT </font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<th width='10%' valign='top'><font size='2' face='Verdana'>S.No.</font></th>");
				Response.Write("<th width='60%' valign='top'><font size='2' face='Verdana'>CASE NO.</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>BK NO.</font></th>");
				Response.Write("<th width='15%' valign='top'><font size='2' face='Verdana'>SET NO.</font></th>");
				Response.Write("</tr>");

				while (reader.Read())
				{
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='2' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='60%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='2' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
					Response.Write("</tr>");

				};
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
				conn1.Close();
				conn1.Dispose();
			}
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Panel_2.Visible = false;
			Panel_1.Visible = true;
			seventhcopy_report();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel_2.Visible = false;
			Panel_1.Visible = false;
			seventhcopy_report();
			Response.Write("<script language=JavaScript>window.print();</script>");
		}
	}
}
