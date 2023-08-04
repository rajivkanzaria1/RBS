using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Lab_Sample_Info
{
	public partial class Lab_Sample_Info : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string CNo = "", C_DT = "", C_SNO = "";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!(IsPostBack))
			{

				if (Convert.ToString(Request.Params["case_no"]) == null || Convert.ToString(Request.Params["call_recv_dt"]) == null || Convert.ToString(Request.Params["call_sno"]) == null)
				{
					CNo = "";
					C_DT = "";
					C_SNO = "";
				}
				else
				{
					CNo = Convert.ToString(Request.Params["case_no"].Trim());
					txtCaseNo.Text = Convert.ToString(Request.Params["case_no"].Trim());
					C_SNO = Convert.ToString(Request.Params["call_sno"].Trim());
					txtCSNO.Text = Convert.ToString(Request.Params["call_sno"].Trim());
					C_DT = Convert.ToString(Request.Params["call_recv_dt"].Trim());
					txtRdt.Text = Convert.ToString(Request.Params["call_recv_dt"].Trim());
					//E_DT=dateconcate(txtRdt.Text);
					sample_exist();
					if (Label_exist.Text == "N")
					{
						btnAdd.Visible = true;
						btnUpd.Visible = false;

					}
					else
					{
						btnAdd.Visible = false;
						btnUpd.Visible = true;

					}

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

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select t17.case_no case_no,to_char(t17.call_recv_dt,'dd/mm/yyyy') call_recv_dt,t17.call_sno call_sno, t09.ie_name ie_name from t17_call_register t17, t09_ie t09 where t17.call_status='U' and t17.ie_cd= t09.ie_cd and substr(t17.case_no,1,1)='" + Session["Region"] + "' ";

				if (txtCaseNo.Text.Trim() != "")
				{
					str1 = str1 + " and trim(t17.CASE_NO)='" + txtCaseNo.Text.Trim() + "'";
				}
				if (txtCSNO.Text.Trim() != "")
				{
					str1 = str1 + " and t17.call_sno=" + txtCSNO.Text.Trim() + " ";
				}
				if (txtRdt.Text != "")
				{
					str1 = str1 + " and TO_CHAR(t17.call_recv_dt,'dd/mm/yyyy')='" + txtRdt.Text.Trim() + "'";
				}

				str1 = str1 + " ORDER BY t17.call_recv_dt ASC";
				//string str2=str1 + " ORDER BY IMMS_RLY_CD, IMMS_POKEY";

				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				//OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1); 
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgPO1.Visible = false;
					DisplayAlert("No Call registered in this this Case No!!!");

				}
				else
				{
					DgPO1.DataSource = dsP1;
					DgPO1.DataBind();
					DgPO1.Visible = true;
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
		void sample_exist()
		{
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				DataSet dsP = new DataSet();
				string str2 = "select count(*) from T109_LAB_SAMPLE_INFO T109 " +
					"where to_char(T109.CALL_RECV_DT, 'dd/mm/yyyy')='" + txtRdt.Text.Trim() + "' " +
					"and T109.case_no='" + txtCaseNo.Text.Trim() + "' and T109.call_sno='" + txtCSNO.Text.Trim() + "' and " +
					"substr(t109.case_no,1,1)='" + Session["Region"] + "'";
				OracleDataAdapter da = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str2, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (Convert.ToInt64(dsP.Tables[0].Rows[0][0]) > 0)
				{
					Label_exist.Text = "M";
				}
				else
				{
					Label_exist.Text = "N";
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		string dateconcate(string dt)
		{
			string myYear, myMonth, myDay;

			myYear = dt.Substring(6, 4);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;
			return (dt1);
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			string E_DT = dateconcate(txtRdt.Text);
			Response.Redirect("Lab_Sample_Info_Details.aspx?Action=N&CaseNo=" + txtCaseNo.Text.Trim() + "&SNo=" + txtCSNO.Text.Trim() + "&CR_Dt=" + E_DT);
		}

		protected void btnUpd_Click(object sender, System.EventArgs e)
		{
			string E_DT = dateconcate(txtRdt.Text);
			Response.Redirect("Lab_Sample_Info_Details.aspx?Action=E&CaseNo=" + txtCaseNo.Text.Trim() + "&SNo=" + txtCSNO.Text.Trim() + "&CR_Dt=" + E_DT);
		}
	}
}