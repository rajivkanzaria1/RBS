using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_Daily_Work_Plan
{
	public partial class IE_Daily_Work_Plan : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSaveNI.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSaveReason.Attributes.Add("OnClick", "JavaScript:validate1();");
			if (!(IsPostBack))
			{
				ListItem lst1 = new ListItem();
				lst1.Text = "Training";
				lst1.Value = "T";
				lstNIWork_CD.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Leave";
				lst1.Value = "L";
				lstNIWork_CD.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Office";
				lst1.Value = "O";
				lstNIWork_CD.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Joint Inspection";
				lst1.Value = "J";
				lstNIWork_CD.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Firm Visit";
				lst1.Value = "F";
				lstNIWork_CD.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Others";
				lst1.Value = "X";
				lstNIWork_CD.Items.Add(lst1);
				lstNIWork_CD.Items.Insert(0, "");


				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
					rdbCurrDt.Text = Convert.ToString(cmd2.ExecuteScalar());
					OracleCommand cmd21 = new OracleCommand("Select to_char(sysdate+1,'dd/mm/yyyy') from dual", conn1);
					rdbTomDt.Text = Convert.ToString(cmd21.ExecuteScalar());
					txtWPDate.Text = rdbCurrDt.Text;
					frmDt.Text = txtWPDate.Text;
					toDt.Text = txtWPDate.Text;
					frmDt.Enabled = false;

					OracleCommand cmd3 = new OracleCommand("Select NVL(to_char(IE_JOIN_DT,'dd/mm/yyyy'),'28/01/2013') JOIN_DT from T09_IE where IE_CD='" + Session["IE_CD"] + "'", conn1);
					string IEWkDt = Convert.ToString(cmd3.ExecuteScalar());
					conn1.Close();

					string myYear, myMonth, myDay;
					myYear = IEWkDt.Substring(6, 4);
					myMonth = IEWkDt.Substring(3, 2);
					myDay = IEWkDt.Substring(0, 2);
					string dt1 = myYear + myMonth + myDay;
					int c = dt1.CompareTo("20130128");

					conn1.Open();
					DataSet dsP2 = new DataSet();
					string str2 = "";
					if (c < 0)
					{
						str2 = "select to_char(to_date('28/01/2013','dd/mm/yyyy') + rownum -1,'dd/mm/yyyy') WK_DT from all_objects where rownum <=(to_date('" + toDt.Text + "','dd/mm/yyyy')-1)-to_date('28/01/2013','dd/mm/yyyy')+1 order by to_date(to_date('27/07/2015','dd/mm/yyyy') + rownum -1,'dd/mm/yyyy') desc";
						//						str2 = "select to_char(to_date('28/01/2013','dd/mm/yyyy') + rownum -1,'dd/mm/yyyy') WK_DT from all_objects where rownum <=(to_date('"+toDt.Text+"','dd/mm/yyyy')-1)-to_date('28/01/2013','dd/mm/yyyy')+1"; 
					}
					else
					{
						str2 = "select to_char(to_date('" + IEWkDt + "','dd/mm/yyyy') + rownum -1,'dd/mm/yyyy') WK_DT from all_objects where rownum <=(to_date('" + toDt.Text + "','dd/mm/yyyy')-1)-to_date('" + IEWkDt + "','dd/mm/yyyy')+1 order by to_date(to_date('27/07/2015','dd/mm/yyyy') + rownum -1,'dd/mm/yyyy') desc";
						//						str2 = "select to_char(to_date('"+IEWkDt+"','dd/mm/yyyy') + rownum -1,'dd/mm/yyyy') WK_DT from all_objects where rownum <=(to_date('"+toDt.Text+"','dd/mm/yyyy')-1)-to_date('"+IEWkDt+"','dd/mm/yyyy')+1"; 
					}
					OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
					OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
					da2.SelectCommand = myOracleCommand2;
					da2.Fill(dsP2, "Table");
					conn1.Close();
					int err = 0;
					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
					{
						string sql2 = "select count(*) from (SELECT IE_CD from T47_IE_WORK_PLAN where VISIT_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy') and IE_CD=" + Session["IE_CD"].ToString() + " UNION ALL Select IE_CD from T48_NI_IE_WORK_PLAN where NI_WORK_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy') and IE_CD=" + Session["IE_CD"].ToString() + " UNION ALL Select IE_CD from NO_IE_WORK_PLAN where NWP_DT=to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy') and IE_CD=" + Session["IE_CD"].ToString() + ")";
						OracleCommand cmd = new OracleCommand(sql2, conn1);
						conn1.Open();
						int dwp = Convert.ToInt32(cmd.ExecuteScalar());
						conn1.Close();
						if (dwp == 0)
						{
							err = 1;
							lblNWPDate.Text = dsP2.Tables[0].Rows[i]["WK_DT"].ToString();
						}
						else if (dwp >= 1)
						{
							break;
						}
					}

					if (err == 1)
					{

						Label2.Visible = false;
						txtWPDate.Visible = false;
						rdbInspWork.Visible = false;
						rdbNonInspWork.Visible = false;
						Label11.Visible = false;
						Label12.Visible = true;
						lblNWPDate.Visible = true;
						txtReason.Visible = true;
						btnSaveReason.Visible = true;
					}
					else
					{
						Label12.Visible = false;
						lblNWPDate.Visible = false;
						txtReason.Visible = false;
						btnSaveReason.Visible = false;
						Label2.Visible = true;
						//						txtWPDate.Visible=true;
						rdbInspWork.Visible = true;
						rdbNonInspWork.Visible = true;
						Label11.Visible = true;

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
				Label3.Visible = false;
				Label4.Visible = false;
				btnSave.Visible = false;
				btnDelete.Visible = false;
				Label13.Visible = false;
				Panel1.Visible = false;
				Panel2.Visible = false;
				//				fillgrid1();
				//				fillgrid();
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
		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			try
			{
				string str1 = "select to_char(VISIT_DT,'dd/mm/yyyy') VISIT_DATE,CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE,CALL_SNO,T05.VEND_NAME MFG,T47.MFG_PLACE,T03.CITY MFG_CITY from T47_IE_WORK_PLAN T47, T05_VENDOR T05, T03_CITY T03 where T47.MFG_CD=T05.VEND_CD AND T05.VEND_CITY_CD=T03.CITY_CD and T47.IE_CD= " + Session["IE_CD"].ToString() + " and T47.VISIT_DT=to_date('" + txtWPDate.Text.Trim() + "','dd/mm/yyyy')";
				str1 = str1 + " Order by T03.CITY, T05.VEND_NAME, T47.CALL_RECV_DT, T47.CALL_SNO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdDWPlan1.Visible = false;
					Label4.Visible = false;
					btnDelete.Visible = false;
				}
				else
				{
					grdDWPlan1.Visible = true;
					Label4.Visible = true;
					btnDelete.Visible = true;
					grdDWPlan1.DataSource = dsP;
					grdDWPlan1.DataBind();
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
		void fillgrid2()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			try
			{
				string str1 = "select decode(NI_WORK_CD,'T','Training','L','Leave','O','Office','J','JI','F','Firm Visit','X','Others'||'-'||NI_OTHER_DESC)NI_WORK_PLAN_CD, to_char(NI_WORK_DT,'dd/mm/yyyy') FROM_DATE from T48_NI_IE_WORK_PLAN where IE_CD=" + Session["IE_CD"].ToString() + " and NI_WORK_DT=to_date('" + txtWPDate.Text.Trim() + "','dd/mm/yyyy')";
				str1 = str1 + " Order by NI_WORK_DT";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdDWPlan2.Visible = false;

				}
				else
				{
					grdDWPlan2.Visible = true;
					Label4.Visible = true;
					btnDelete.Visible = true;
					grdDWPlan2.DataSource = dsP;
					grdDWPlan2.DataBind();
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

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			//			string ss="";
			//			conn1=new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
			//			try
			//			{
			//				conn1.Open();
			//				OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
			//				ss=Convert.ToString(cmd2.ExecuteScalar());
			//				conn1.Close();
			//			}
			//			catch (Exception ex) 
			//			{
			//				string str;
			//				str = ex.Message;
			//				string str1=str.Replace("\n","");
			//				Response.Redirect(("Error_Form.aspx?err=" + str1));
			//			}
			//			finally
			//			{
			//				conn1.Close();
			//				conn1.Dispose();
			//			}
			//			if(ss==txtWPDate.Text.Trim())
			//			{
			//				fillgrid1();
			//				fillgrid();
			//				grdDWPlan1.Columns[0].Visible=true;
			//				btnDelete.Visible=true;
			//			}
			//			else
			//			{
			//				fillgrid();
			//				grdDWPlan1.Columns[0].Visible=false;
			//				btnDelete.Visible=false;
			//				grdDWPlan.Visible=false;
			//				Label3.Visible=false;
			//			}
		}
		void fillgrid1()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			try
			{

				//					string str1 = "select CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE,CALL_SNO,decode(T17.CALL_STATUS,'M','Pending','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection','W','Withheld') CALL_STATUS,T17.MFG_CD,T05.VEND_NAME MFG,T03.CITY_CD MFG_CITY_CD, T03.CITY MFG_CITY from T17_CALL_REGISTER T17, T05_VENDOR T05, T03_CITY T03 where T17.MFG_CD=T05.VEND_CD AND T05.VEND_CITY_CD=T03.CITY_CD and T17.CALL_STATUS IN ('M','U','S','G','W') and T17.IE_CD= " + Session["IE_CD"].ToString();
				string str1 = "SELECT T17.CASE_NO,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE, T17.CALL_SNO,decode(T17.CALL_STATUS,'M','Pending','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection','W','Withheld') CALL_STATUS,T17.MFG_CD,T17.MFG_PLACE,NVL(T17.CO_CD,0) CO_CD,T05.VEND_NAME MFG,T03.CITY_CD MFG_CITY_CD, T03.CITY MFG_CITY, TO_CHAR(DT_INSP_DESIRE,'dd/mm/yyyy')DESIRE_DT FROM T17_CALL_REGISTER T17 LEFT JOIN T47_IE_WORK_PLAN T47 ON (T17.CASE_NO = T47.CASE_NO and T17.CALL_RECV_DT=T47.CALL_RECV_DT and T17.CALL_SNO=T47.CALL_SNO and T47.VISIT_DT=to_date('" + txtWPDate.Text.Trim() + "','dd/mm/yyyy')), T05_VENDOR T05, T03_CITY T03 WHERE T47.CASE_NO IS NULL and T47.CALL_RECV_DT is null and T47.CALL_SNO is null and T17.MFG_CD=T05.VEND_CD and T05.VEND_CITY_CD= T03.CITY_CD and substr(T17.CASE_NO,1,1)='" + Session["Region"] + "' and T17.IE_CD=" + Session["IE_CD"].ToString() + " and T17.CALL_STATUS IN ('M','U','S','W') ";
				str1 = str1 + " Order by T03.CITY, T05.VEND_NAME, T17.CALL_RECV_DT, T17.CALL_SNO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdDWPlan.Visible = false;
					Label3.Visible = false;
					btnSave.Visible = false;
					Label13.Visible = false;
				}
				else
				{
					grdDWPlan.Visible = true;
					Label3.Visible = true;
					btnSave.Visible = true;
					Label13.Visible = true;
					grdDWPlan.DataSource = dsP;
					grdDWPlan.DataBind();
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
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
					// Make sure this is an item and not the header or footer.
					int[] vend = new int[10];
					if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
					{

						w_reason = Convert.ToBoolean(((CheckBox)di.FindControl("chkDWplan")).Checked);


						if (w_reason == true)
						{

							string myInsertQuery1 = "";
							myInsertQuery1 = "insert into T47_IE_WORK_PLAN (IE_CD,CO_CD,VISIT_DT,CASE_NO,CALL_RECV_DT,CALL_SNO,MFG_CD,MFG_PLACE,REGION_CODE,USER_ID,DATETIME) values (" + Session["IE_CD"] + ",'" + Convert.ToInt32(di.Cells[11].Text.Trim()) + "',to_date('" + txtWPDate.Text + "','dd/mm/yyyy'),'" + Convert.ToString(di.Cells[2].Text.Trim()) + "',to_date('" + Convert.ToString(di.Cells[3].Text.Trim()) + "','dd/mm/yyyy')," + Convert.ToInt16(di.Cells[4].Text.Trim()) + ",'" + Convert.ToInt32(di.Cells[7].Text.Trim()) + "','" + Convert.ToString(di.Cells[8].Text.Trim()) + "','" + Session["Region"].ToString() + "','" + Session["IE_EMP_NO"] + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
							OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
							myInsertCommand1.Transaction = myTrans;
							myInsertCommand1.Connection = conn1;
							myInsertCommand1.ExecuteNonQuery();
						}


					}


				}
				if (err == 0)
				{
					int vend_count = 0, count = 0;
					string sql = "select MFG_CD, count(*) COUNT from T47_IE_WORK_PLAN where IE_CD=" + Session["IE_CD"] + " and VISIT_DT=to_date('" + txtWPDate.Text + "','dd/mm/yyyy') group by MFG_CD";

					OracleCommand cmd = new OracleCommand(sql);
					cmd.Transaction = myTrans;
					cmd.Connection = conn1;
					OracleDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						vend_count = vend_count + 1;
						count = count + Convert.ToInt32(reader["COUNT"].ToString());

					}
					if (vend_count > 3 || count > 5)
					{
						myTrans.Rollback();
						DisplayAlert("Your Work Plan Cannot be Saved due to  one or both of the following \\n1. You have selected more then 3 different vendors. \\n2. You have Selected more then 6 calls of a particular vendor.");
					}
					else
					{
						myTrans.Commit();
					}

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
			fillgrid1();
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//			conn1.Open();
			//			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual",conn1);
			//			string ss=Convert.ToString(cmd2.ExecuteScalar());
			//			conn1.Close();
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{
				int err = 0;
				bool w_reason = false;

				foreach (DataGridItem di in grdDWPlan1.Items)
				{
					// Make sure this is an item and not the header or footer.
					if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
					{

						w_reason = Convert.ToBoolean(((CheckBox)di.FindControl("chkDWplan")).Checked);


						if (w_reason == true)
						{

							string myDeleteQuery1 = "";
							myDeleteQuery1 = "delete from T47_IE_WORK_PLAN where IE_CD= " + Session["IE_CD"] + " and VISIT_DT=to_date('" + Convert.ToString(di.Cells[1].Text.Trim()) + "','dd/mm/yyyy') and CASE_NO= '" + Convert.ToString(di.Cells[2].Text.Trim()) + "' and CALL_RECV_DT=to_date('" + Convert.ToString(di.Cells[3].Text.Trim()) + "','dd/mm/yyyy') and CALL_SNO=" + Convert.ToInt16(di.Cells[4].Text.Trim());
							OracleCommand myDeleteCommand1 = new OracleCommand(myDeleteQuery1);
							myDeleteCommand1.Transaction = myTrans;
							myDeleteCommand1.Connection = conn1;
							myDeleteCommand1.ExecuteNonQuery();
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
			fillgrid1();
		}

		protected void btnSaveNI_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select IE_CO_CD from T09_IE where IE_CD=" + Session["IE_CD"].ToString(), conn1);
				string co_cd = Convert.ToString(cmd2.ExecuteScalar());
				OracleCommand cmd3 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd3.ExecuteScalar());
				conn1.Close();

				DataSet dsP2 = new DataSet();
				string str2 = "select to_char(to_date('" + frmDt.Text + "','dd/mm/yyyy') + rownum -1,'dd/mm/yyyy') WK_DT from all_objects where rownum <=to_date('" + toDt.Text + "','dd/mm/yyyy')-to_date('" + frmDt.Text + "','dd/mm/yyyy')+1";
				OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				conn1.Close();
				string myInsertQuery1 = "";
				conn1.Open();
				OracleTransaction myTrans = conn1.BeginTransaction();
				try
				{
					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
					{
						myInsertQuery1 = "insert into T48_NI_IE_WORK_PLAN (IE_CD,CO_CD,NI_WORK_CD,NI_OTHER_DESC,NI_WORK_DT,REGION_CODE,USER_ID,DATETIME) values (" + Session["IE_CD"] + "," + co_cd + ",'" + lstNIWork_CD.SelectedValue + "','" + txtOtherDesc.Text.Trim() + "',to_date('" + dsP2.Tables[0].Rows[i]["WK_DT"].ToString() + "','dd/mm/yyyy'),'" + Session["Region"].ToString() + "','" + Session["IE_EMP_NO"] + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
						OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
						myInsertCommand1.Transaction = myTrans;
						myInsertCommand1.Connection = conn1;
						myInsertCommand1.ExecuteNonQuery();

					}
					myTrans.Commit();
					conn1.Close();
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					myTrans.Rollback();
					string str1 = str.Replace("\n", "");
					if (str1.Substring(0, 9).Equals("ORA-00001"))
					{ DisplayAlert("Entry Already Exist For the Given Dates!!!"); }
					else
					{ Response.Redirect(("Error_Form.aspx?err=" + str1)); }


				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
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
			fillgrid2();
		}

		protected void rdbInspWork_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbInspWork.Checked == true)
			{
				Panel1.Visible = true;
				Panel2.Visible = false;
				fillgrid1();
				fillgrid();
			}
			else if (rdbNonInspWork.Checked == true)
			{
				Panel1.Visible = false;
				Panel2.Visible = true;
				fillgrid2();
				Label9.Visible = false;
				txtOtherDesc.Visible = false;
			}

		}

		protected void lstNIWork_CD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstNIWork_CD.SelectedValue == "X")
			{
				txtOtherDesc.Visible = true;
				Label9.Visible = true;
			}
			else
			{
				txtOtherDesc.Visible = false;
				Label9.Visible = false;
			}
		}

		protected void btnSaveReason_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select IE_CO_CD from T09_IE where IE_CD=" + Session["IE_CD"].ToString(), conn1);
				string co_cd = Convert.ToString(cmd2.ExecuteScalar());
				OracleCommand cmd3 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd3.ExecuteScalar());
				conn1.Close();

				string myInsertQuery1 = "";
				conn1.Open();
				myInsertQuery1 = "insert into NO_IE_WORK_PLAN (IE_CD,CO_CD,REASON,NWP_DT,REGION_CODE,USER_ID,DATETIME) values (" + Session["IE_CD"] + "," + co_cd + ",'" + txtReason.Text.Trim() + "',to_date('" + lblNWPDate.Text + "','dd/mm/yyyy'),'" + Session["Region"].ToString() + "','" + Session["IE_EMP_NO"] + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
				OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
				myInsertCommand1.Connection = conn1;
				myInsertCommand1.ExecuteNonQuery();
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

			Response.Redirect("IE_Daily_Work_Plan.aspx");
		}

		protected void rdbCurrDt_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbCurrDt.Checked == true)
			{
				txtWPDate.Text = rdbCurrDt.Text;
				fillgrid();
				frmDt.Text = txtWPDate.Text;
				toDt.Text = txtWPDate.Text;
			}
			else if (rdbTomDt.Checked == true)
			{
				txtWPDate.Text = rdbTomDt.Text;
				fillgrid();
				frmDt.Text = txtWPDate.Text;
				toDt.Text = txtWPDate.Text;
			}
		}
	}
}