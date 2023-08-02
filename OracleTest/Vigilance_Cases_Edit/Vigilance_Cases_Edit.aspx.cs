using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Vigilance_Cases_Edit
{
	public partial class Vigilance_Cases_Edit : System.Web.UI.Page
	{
			OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnShow.Attributes.Add("OnClick", "JavaScript:validate();");
			btnMod.Attributes.Add("OnClick", "JavaScript:validate1();");
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

		protected void btnShow_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select T53.REF_REG_NO,to_char(REF_DT,'dd/mm/yyyy') REF_DATE,REF_DETAILS from T53_VIGILANCE_CASES_MASTER T53,T54_VIGILANCE_CASES_DETAILS T54 where T53.REF_REG_NO=T54.REF_REG_NO and substr(T53.REF_REG_NO,1,1)='" + Session["Region"] + "' ";

				if (txtRefRegNo.Text.Trim() != "")
				{
					str1 = str1 + " AND T53.REF_REG_NO = '" + txtRefRegNo.Text.Trim() + "'";
				}
				if (txtRefDT.Text.Trim() != "")
				{
					str1 = str1 + " AND REF_DT=to_date('" + txtRefDT.Text + "','dd/mm/yyyy')";
				}
				if (txtCaseNo.Text.Trim() != "")
				{
					str1 = str1 + " AND CASE_NO='" + txtCaseNo.Text + "' and BK_NO='" + txtBKNo.Text + "' and SET_NO='" + txtSNo.Text + "'";
				}

				str1 = str1 + " group by T53.REF_REG_NO,to_char(REF_DT,'dd/mm/yyyy'),REF_DETAILS ORDER BY T53.REF_REG_NO";
				DataSet dsP = new DataSet();
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");

				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdVigilance.Visible = false;
					Label4.Visible = true;

				}
				else
				{
					grdVigilance.DataSource = dsP;
					grdVigilance.DataBind();
					grdVigilance.Visible = true;


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
			}
		}
		public string match()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleCommand cmd = new OracleCommand("select REF_REG_NO from T53_VIGILANCE_CASES_MASTER where REF_REG_NO='" + txtRefRegNo.Text.Trim() + "' ", conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			conn1.Dispose();
			if (test == "\0" || test == "")
			{
				test = "0";
			}
			else
			{
				test = "1";
			}
			return test;
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Vigilance_Cases_Form.aspx?Action=A");
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			string chk = match();
			if (chk == "0")
			{

				DisplayAlert("No Record Present for the Given Ref Reg No.!!! ");
			}
			else
			{
				Response.Redirect("Vigilance_Cases_Form.aspx?REF_REG_NO=" + txtRefRegNo.Text.Trim()); ;
			}

		}
	}
}