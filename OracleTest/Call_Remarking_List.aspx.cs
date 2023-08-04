using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Call_Remarking_List
{
	public partial class Call_Remarking_List : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select call_remarking from t02_users where user_id='" + Session["Uname"].ToString() + "' ", conn1);
			string remarking_off = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			if (remarking_off == "Y")
			{
				if (!(IsPostBack))
				{
					fillgrid();
					//				if(Session["Role_CD"].ToString()=="4")
					//				{
					//					
					//					DgPO1.Columns[0].Visible=false;
					//					
					//				}

				}
			}
			else
			{
				//string str2="You Are Not Autorized User To Access This form!!!";
				//Response.Redirect(("Error_Form.aspx?err=" + str2));
				DgPO1.Columns[0].Visible = false;
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select USER_TYPE from t02_users where user_id='" + Session["Uname"].ToString() + "' ", conn1);
			string remarking_off_auth = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			string str1 = "";
			if (remarking_off_auth == "S")
			{
				str1 = "select T108.case_no case_no,to_char(T108.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT, T108.call_sno call_sno,decode(T108.remarking_status,'P','Pending') remarking_status," +
					"T108.remark_reason remark_reason, t09.ie_name ie_name_from, t10.ie_name ie_name_to," +
					"t108.fr_ie_pending_calls fr_ie_pending_calls,t108.to_ie_pending_calls to_ie_pending_calls," +
					"t02.user_name user_name,to_char(T108.rem_init_datetime,'DD/MM/YYYY-HH24:MI:SS') LOGIN_TIME,to_char(T108.CALL_RECV_DT,'ddmmyyyy')CS_DTC " +
					"from T108_REMARKED_CALLS T108,T09_IE T09,T09_IE T10,T02_Users T02, t17_call_register t17 " +
					"where T108.FR_IE_CD=T09.IE_CD and T108.TO_IE_CD=T10.IE_CD and T108.REM_INIT_BY=T02.USER_ID and " +
					"T108.case_no=t17.case_no and T108.call_recv_dt=t17.call_recv_dt and T108.call_sno=t17.call_sno and " +
					"t108.remarking_status='P' and substr(t108.case_no,1,1)='" + Session["Region"] + "'";

			}
			else
			{
				str1 = "select T108.case_no case_no,to_char(T108.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT, T108.call_sno call_sno,decode(T108.remarking_status,'P','Pending') remarking_status," +
					"T108.remark_reason remark_reason, t09.ie_name ie_name_from, t10.ie_name ie_name_to," +
					"t108.fr_ie_pending_calls fr_ie_pending_calls,t108.to_ie_pending_calls to_ie_pending_calls," +
					"t02.user_name user_name,to_char(T108.rem_init_datetime,'DD/MM/YYYY-HH24:MI:SS') LOGIN_TIME,to_char(T108.CALL_RECV_DT,'ddmmyyyy')CS_DTC " +
					"from T108_REMARKED_CALLS T108,T09_IE T09,T09_IE T10,T02_Users T02, t17_call_register t17 " +
					"where T108.FR_IE_CD=T09.IE_CD and T108.TO_IE_CD=T10.IE_CD and T108.REM_INIT_BY=T02.USER_ID and " +
					"T108.case_no=t17.case_no and T108.call_recv_dt=t17.call_recv_dt and T108.call_sno=t17.call_sno and " +
					"t108.remarking_status='P' and substr(t108.case_no,1,1)='" + Session["Region"] + "' and nvl(t17.call_remark_status,'0')='0'";

			}

			try
			{

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
					//repdiv.Visible=false;
					//Label6.Visible =true;
					//						throw new System.Exception("No PurchaseOrder found. !!! ");
					lblError.Visible = true;
					DgPO1.Visible = false;

				}
				else
				{
					DgPO1.DataSource = dsP1;
					DgPO1.DataBind();
					DgPO1.Visible = true;
					lblError.Visible = false;
					//repdiv.Visible=true;
					//Label6.Visible =false;
				}
				conn1.Close();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

	}
}