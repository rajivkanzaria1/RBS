using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.CMIEWiseCancellationAcceptance_Form
{
	public partial class CMIEWiseCancellationAcceptance_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!(IsPostBack))
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					DataSet dsP1 = new DataSet();
					string str3 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='" + Session["REGION"] + "' order by CO_NAME ";
					OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
					ListItem lst3;
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP1, "Table");
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
					{
						lst3 = new ListItem();
						lst3.Text = dsP1.Tables[0].Rows[i]["CO_NAME"].ToString();
						lst3.Value = dsP1.Tables[0].Rows[i]["CO_CD"].ToString();
						lstCO.Items.Add(lst3);
					}
					conn1.Close();


				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str1);
				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}

				Panel1.Visible = true;
				Panel2.Visible = true;
				Panel3.Visible = false;

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

		protected void rdbAllIE_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbAllIE.Checked == true)
			{
				lstIE.Visible = false;
			}
			else
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					lstIE.Items.Clear();
					DataSet dsP2 = new DataSet();
					string str2 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' AND IE_CO_CD=" + lstCO.SelectedValue + " order by IE_NAME ";
					OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
					OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
					ListItem lst2;
					conn1.Open();
					da2.SelectCommand = myOracleCommand2;
					da2.Fill(dsP2, "Table");
					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
					{
						lst2 = new ListItem();
						lst2.Text = dsP2.Tables[0].Rows[i]["IE_NAME"].ToString();
						lst2.Value = dsP2.Tables[0].Rows[i]["IE_CD"].ToString();
						lstIE.Items.Add(lst2);
					}
					lstIE.Items.Insert(0, "");
					conn1.Close();
					lstIE.Visible = true;
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str1);
				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}
			}
		}

		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			try
			{

				//					string str1 = "select CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE,CALL_SNO,decode(T17.CALL_STATUS,'M','Pending','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection','W','Withheld') CALL_STATUS,T17.MFG_CD,T05.VEND_NAME MFG,T03.CITY_CD MFG_CITY_CD, T03.CITY MFG_CITY from T17_CALL_REGISTER T17, T05_VENDOR T05, T03_CITY T03 where T17.MFG_CD=T05.VEND_CD AND T05.VEND_CITY_CD=T03.CITY_CD and T17.CALL_STATUS IN ('M','U','S','G','W') and T17.IE_CD= " + Session["IE_CD"].ToString();

				//				conn1.Open();
				//				OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
				//				string ss=Convert.ToString(cmd2.ExecuteScalar());
				//				conn1.Close();

				string str1 = "";
				if (rdbPIE.Checked == true)
				{
					str1 = "SELECT T17.CASE_NO,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE, to_char(T17.CALL_RECV_DT,'yyyymmdd')CALL_DT_CONCAT, T17.CALL_SNO,T17.MFG_CD,T17.MFG_PLACE,NVL(T17.CO_CD,0) CO_CD,T05.VEND_NAME MFG,TO_CHAR(DT_INSP_DESIRE,'dd/mm/yyyy')DESIRE_DT,'CALL_CANCELLATION_DOCUMENTS/'||T17.CASE_NO||'-'||to_char(T17.CALL_RECV_DT,'yyyymmdd')||'-'||T17.CALL_SNO||'.PDF' CANC_DOC FROM T17_CALL_REGISTER T17, T19_CALL_CANCEL T19, T05_VENDOR T05 WHERE T17.MFG_CD=T05.VEND_CD AND T17.CASE_NO=T19.CASE_NO AND T17.CALL_RECV_DT=T19.CALL_RECV_DT AND T17.CALL_SNO=T19.CALL_SNO and substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' and T17.IE_CD=" + lstIE.SelectedValue + " AND T17.CALL_STATUS='C' AND T19.CANCEL_DATE>to_date('04/08/2019','dd/mm/yyyy') AND T19.DOCS_SUBMITTED IS NULL ";
				}
				else if (rdbAllIE.Checked == true)
				{
					str1 = "SELECT T17.CASE_NO,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE, to_char(T17.CALL_RECV_DT,'yyyymmdd')CALL_DT_CONCAT, T17.CALL_SNO,T17.MFG_CD,T17.MFG_PLACE,NVL(T17.CO_CD,0) CO_CD,T05.VEND_NAME MFG,TO_CHAR(DT_INSP_DESIRE,'dd/mm/yyyy')DESIRE_DT,'CALL_CANCELLATION_DOCUMENTS/'||T17.CASE_NO||'-'||to_char(T17.CALL_RECV_DT,'yyyymmdd')||'-'||T17.CALL_SNO||'.PDF' CANC_DOC FROM T17_CALL_REGISTER T17, T19_CALL_CANCEL T19, T05_VENDOR T05 WHERE T17.MFG_CD=T05.VEND_CD AND T17.CASE_NO=T19.CASE_NO AND T17.CALL_RECV_DT=T19.CALL_RECV_DT AND T17.CALL_SNO=T19.CALL_SNO and substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' and T17.CO_CD=" + lstCO.SelectedValue + " AND T17.CALL_STATUS='C' AND T19.CANCEL_DATE>to_date('04/08/2019','dd/mm/yyyy') AND T19.DOCS_SUBMITTED IS NULL ";
				}

				str1 = str1 + " Order by T17.CALL_RECV_DT, T05.VEND_NAME, T17.CALL_RECV_DT, T17.CALL_SNO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCallcancelApp.Visible = false;
					//					Label3.Visible=false;
					//					btnSave.Visible=false;
					//					Label13.Visible=false;
				}
				else
				{
					grdCallcancelApp.Visible = true;
					//					Label3.Visible=true;
					//					btnSave.Visible=true;
					//					Label13.Visible=true;
					grdCallcancelApp.DataSource = dsP;
					grdCallcancelApp.DataBind();
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

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			fillgrid();
			Panel3.Visible = true;

		}

		protected void btbApprove_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{
				int err = 0;
				bool w_reason = false;

				foreach (DataGridItem di in grdCallcancelApp.Items)
				{
					// Make sure this is an item and not the header or footer.
					int[] vend = new int[10];
					if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
					{

						w_reason = Convert.ToBoolean(((CheckBox)di.FindControl("chkDWplan")).Checked);


						if (w_reason == true)
						{
							string myUpdateQuery = "Update T19_CALL_CANCEL set DOCS_SUBMITTED='Y', USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + Convert.ToString(di.Cells[4].Text.Trim()) + "' and CALL_RECV_DT=to_date('" + Convert.ToString(di.Cells[5].Text.Trim()) + "','dd/mm/yyyy') and CALL_SNO=" + Convert.ToInt16(di.Cells[6].Text.Trim());
							OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
							myUpdateCommand.Transaction = myTrans;
							myUpdateCommand.Connection = conn1;
							myUpdateCommand.ExecuteNonQuery();
						}


					}


				}
				if (err == 0)
				{
					myTrans.Commit();

				}
				else if (err == 1)
				{
					myTrans.Rollback();
					//					DisplayAlert("All Actions Shld be entered!!!");
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
			fillgrid();


		}
	}
}