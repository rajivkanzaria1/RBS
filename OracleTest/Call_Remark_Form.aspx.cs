using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Call_Remark_Form
{
	public partial class Call_Remark_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select count(*) auth_access from t02_users where user_id='" + Session["Uname"].ToString() + "' and auth_levl in (1,4)", conn1);
			Int16 remark_off = Convert.ToInt16(cmd2.ExecuteScalar());
			conn1.Close();
			if (remark_off >= 0)
			{
				btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
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
				}
			}
			else
			{
				string str2 = "You Are Not Autorized User For Access This form!!!";
				Response.Redirect(("Error_Form.aspx?err=" + str2));
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

		protected void btnSubmit_Click(object sender, System.EventArgs e)
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

				foreach (DataGridItem di in grdDWPlan.Items)
				{
					if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
					{
						w_reason = Convert.ToBoolean(((CheckBox)di.FindControl("chkDWplan")).Checked);

						if (w_reason == true)
						{
							string myInsertQuery1 = "";
							myInsertQuery1 = "insert into T108_REMARKED_CALLS (CASE_NO,CALL_RECV_DT,CALL_SNO,REMARK_REASON,FR_IE_CD,TO_IE_CD,REM_INIT_BY,REM_INIT_DATETIME,REMARKING_STATUS,FR_IE_PENDING_CALLs,TO_IE_PENDING_CALLS) values ('" + Convert.ToString(di.Cells[1].Text.Trim()) + "',to_date('" + Convert.ToString(di.Cells[2].Text.Trim()) + "','dd/mm/yyyy')," + Convert.ToInt32(di.Cells[3].Text.Trim()) + ",'" + txt_Reason.Text.Trim() + "'," + lstIE.SelectedValue + "," + Dropdownlist1.SelectedValue + ",'" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'P'," + Convert.ToInt32(Label_FR_Pending.Text.ToString()) + "," + Convert.ToInt32(Label_To_Pending.Text.ToString()) + ")";
							OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
							myInsertCommand1.Transaction = myTrans;
							myInsertCommand1.Connection = conn1;
							myInsertCommand1.ExecuteNonQuery();
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

				}
				fillgrid();
				fillgrid_Pending();
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

		protected void lstCO_SelectedIndexChanged(object sender, System.EventArgs e)
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
				fillgrid();
				FR_Pending();
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
		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			try
			{
				if (lstIE.SelectedItem.Text == "")
				{
					grdDWPlan.Visible = false;
					Label4.Visible = false;
					Panel2.Visible = false;
				}
				else
				{
					string str1 = "SELECT T17.CASE_NO,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE, T17.CALL_SNO,decode(T17.CALL_STATUS,'M','Pending') CALL_STATUS,T17.MFG_CD,T17.MFG_PLACE,NVL(T17.CO_CD,0) CO_CD,T05.VEND_NAME MFG,T03.CITY_CD MFG_CITY_CD, T03.CITY MFG_CITY, TO_CHAR(DT_INSP_DESIRE,'dd/mm/yyyy')DESIRE_DT,NVL(T17.CALL_REMARK_STATUS,'0') CALL_REMARK_STATUS FROM T17_CALL_REGISTER T17 LEFT JOIN t108_REMARKED_CALLS T47 ON (T17.CASE_NO = T47.CASE_NO and T17.CALL_RECV_DT=T47.CALL_RECV_DT and T17.CALL_SNO=T47.CALL_SNO AND T47.REMARKING_STATUS='P'), T05_VENDOR T05, T03_CITY T03 WHERE T47.CASE_NO IS NULL and T47.CALL_RECV_DT is null and T47.CALL_SNO is null AND T17.MFG_CD=T05.VEND_CD and T05.VEND_CITY_CD= T03.CITY_CD and substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' and T17.IE_CD=" + lstIE.SelectedValue + " and T17.CALL_STATUS IN ('M') ";
					str1 = str1 + " Order by T03.CITY, T05.VEND_NAME, T17.CALL_RECV_DT, T17.CALL_SNO";
					OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP, "Table");
					if (dsP.Tables[0].Rows.Count == 0)
					{
						grdDWPlan.Visible = false;
						Label4.Visible = true;
						Panel2.Visible = false;
					}
					else
					{
						grdDWPlan.Visible = true;
						Label4.Visible = false;
						Panel2.Visible = true;
						grdDWPlan.DataSource = dsP;
						grdDWPlan.DataBind();
						IE_Marking();
					}
					conn1.Close();
				}


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

		void IE_Marking()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP1 = new DataSet();
				string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				ListItem lst3;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
				{
					lst3 = new ListItem();
					lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString();
					lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString();
					Dropdownlist1.Items.Add(lst3);
				}
				Dropdownlist1.Items.Insert(0, "");
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
		}

		void FR_Pending()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				if (lstIE.SelectedItem.Text == "")
				{
					Label_FR_Pending.Text = "";
				}
				else
				{
					DataSet dsP1 = new DataSet();
					string str3 = "SELECT Count(*) FROM T17_CALL_REGISTER T17 WHERE substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' and T17.IE_CD=" + lstIE.SelectedValue + " and T17.CALL_STATUS IN ('M') ";
					OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP1, "Table");
					Label_FR_Pending.Text = "" + dsP1.Tables[0].Rows[0][0].ToString() + "";
					conn1.Close();
					fillgrid_Pending();
				}


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

		protected void lstIE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FR_Pending();
			fillgrid();
		}

		void TO_Pending()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				if (Dropdownlist1.SelectedItem.Text == "")
				{
					Label_To_Pending.Text = "";
				}
				else
				{

					DataSet dsP1 = new DataSet();
					string str3 = "SELECT Count(*) FROM T17_CALL_REGISTER T17 WHERE substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' and T17.IE_CD=" + Dropdownlist1.SelectedValue + " and T17.CALL_STATUS IN ('M') ";
					OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP1, "Table");
					Label_To_Pending.Text = "" + dsP1.Tables[0].Rows[0][0].ToString() + "";
					conn1.Close();
				}

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

		protected void Dropdownlist1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TO_Pending();
		}

		void fillgrid_Pending()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			try
			{
				string str1 = "select T108.case_no case_no,to_char(T108.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT, T108.call_sno call_sno,decode(T108.remarking_status,'P','Pending') remarking_status," +
					"T108.remark_reason remark_reason, t09.ie_name ie_name_from, t10.ie_name ie_name_to," +
					"t108.fr_ie_pending_calls fr_ie_pending_calls,t108.to_ie_pending_calls to_ie_pending_calls," +
					"t02.user_name user_name,to_char(T108.rem_init_datetime,'DD/MM/YYYY-HH24:MI:SS') LOGIN_TIME " +
					"from T108_REMARKED_CALLS T108,T09_IE T09,T09_IE T10,T02_Users T02 " +
					"where T108.FR_IE_CD=T09.IE_CD and T108.TO_IE_CD=T10.IE_CD and T108.REM_INIT_BY=T02.USER_ID and " +
					"t108.remarking_status='P' and substr(t108.case_no,1,1)='" + Session["Region"] + "' and t108.fr_ie_cd=" + lstIE.SelectedValue + "";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grid_Sub.Visible = false;
				}
				else
				{
					grid_Sub.Visible = true;
					grid_Sub.DataSource = dsP;
					grid_Sub.DataBind();
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
	}
}