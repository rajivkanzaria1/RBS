using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Lab_Register_Edit
{
	public partial class Lab_Register_Edit : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnAdd.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate3();");
			string RNO = "";
			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["REG_NO"]) == "" && Convert.ToString(Request.Params["CASE_NO"]) == "")
				{
					RNO = "";

				}
				else if (Convert.ToString(Request.Params["REG_NO"]) != "")
				{
					RNO = Convert.ToString(Request.Params["REG_NO"]);
					txtLabRegNo.Text = RNO;


				}
				else if (Convert.ToString(Request.Params["REG_NO"]) == "")
				{
					txtCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"]);
					txtRdt.Text = Convert.ToString(Request.Params["CALL_RECV_DT"]);
					txtCSNO.Text = Convert.ToString(Request.Params["CALL_SNO"]);
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

		}
		#endregion
		public string match()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			OracleCommand cmd = new OracleCommand("select REGION_CODE from T17_CALL_REGISTER where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtRdt.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + txtCSNO.Text.Trim(), conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			conn1.Dispose();
			if (test == "\0" || test == "")
			{
				test = "0";
				DisplayAlert("No Record Present for the Given Case No, Call Date and Call SNo in Call Master!!!");
			}
			else if (test == Session["Region"].ToString())
			{
				test = "2";

			}
			else
			{
				test = "1";
				DisplayAlert("You are not Authorised to Add IC Data For Other Regions.!!! ");
			}

			return test;


		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			string check = match();
			if (check == "2")
			{
				string code = txtCaseNo.Text.Trim();
				string dt = txtRdt.Text.Trim();
				string csno = txtCSNO.Text.Trim();
				Response.Redirect("Lab_Register_Form.aspx?CASE_NO=" + code + "&CALL_RECV_DT=" + dt + "&CALL_SNO=" + csno);
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = " Select T50.SAMPLE_REG_NO,T17.CASE_NO, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DATE,T17.CALL_SNO CALL_SNO,decode(S.CALL_STATUS_CD,'C',S.CALL_STATUS_DESC||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)'||'@'||T17.CALL_CANCEL_CHARGES||'+ S.T.',''),S.CALL_STATUS_DESC)CALL_STATUS, T09.IE_SNAME IE_SNAME, T50.SAMPLE_REG_NO " +
					"From T09_IE T09,T17_CALL_REGISTER T17,T50_LAB_REGISTER T50,T21_CALL_STATUS_CODES S " +
					"Where T17.CALL_STATUS=S.CALL_STATUS_CD and T17.IE_CD=T09.IE_CD and T17.CASE_NO=T50.CASE_NO(+) and T17.CALL_RECV_DT=T50.CALL_RECV_DT(+) and T17.CALL_SNO=T50.CALL_SNO(+) ";


				if (txtCaseNo.Text.Trim() != "")
				{

					str1 = str1 + " and upper(T17.CASE_NO)=upper('" + txtCaseNo.Text.Trim() + "')";
				}

				if (txtRdt.Text.Trim() != "")
				{
					str1 = str1 + " and T17.CALL_RECV_DT=to_Date('" + txtRdt.Text.Trim() + "','dd/mm/yyyy')";
				}

				if (txtLabRegNo.Text.Trim() != "")
				{
					str1 = str1 + " and T50.SAMPLE_REG_NO='" + txtLabRegNo.Text.Trim() + "'";
				}
				str1 = str1 + " and T17.REGION_CODE='N' Group By T17.CASE_NO,T17.CALL_RECV_DT,T17.CALL_SNO,decode(S.CALL_STATUS_CD,'C',S.CALL_STATUS_DESC||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)'||'@'||T17.CALL_CANCEL_CHARGES||'+ S.T.',''),S.CALL_STATUS_DESC),T09.IE_SNAME,T50.SAMPLE_REG_NO order by T17.CALL_RECV_DT, T17.CASE_NO, T50.SAMPLE_REG_NO";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdLAB.Visible = false;
					DisplayAlert("No Bill Pending!!!");
					//Label4.Visible=true;
				}
				else
				{
					grdLAB.Visible = true;
					grdLAB.DataSource = dsP;
					grdLAB.DataBind();
					Label8.Visible = true;
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

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Lab_Register_Form.aspx?SAMPLE_REG_NO=" + txtLabRegNo.Text);
		}
	}
}