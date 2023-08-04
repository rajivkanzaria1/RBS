using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_Claim_Form
{
	public partial class IE_Claim_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		public string CNO, Action, CHead;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.Params["CLAIM_NO"]) == "" || Convert.ToString(Request.Params["CLAIM_NO"]) == null)
			{
				CNO = "";
				Action = Convert.ToString(Request.Params["Action"]);
			}
			else if (Convert.ToString(Request.Params["CLAIM_NO"]) != "" && Convert.ToString(Request.Params["Action"]) != "")
			{
				CNO = Convert.ToString(Request.Params["CLAIM_NO"]);
				Action = Convert.ToString(Request.Params["Action"]);
				lblCNo.Text = CNO;
				//				if(Request.Params["CLAIM_HEAD"]=="" ||Request.Params["CLAIM_HEAD"] == null)
				//				{
				//					CHead=0;
				//				}
				//				else
				//				{
				//					CHead=Convert.ToInt32(Request.Params["CLAIM_HEAD"]);
				//					
				//						
				//				}

			}
			if (!(IsPostBack))
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				ListItem lst1 = new ListItem();
				lst1.Text = "308-Conveyance/Fare Charges";
				lst1.Value = "308";
				lstClaim_Head.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "309-Traveling Allowance";
				lst1.Value = "309";
				lstClaim_Head.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "310-Hotel Charges";
				lst1.Value = "310";
				lstClaim_Head.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "608-Telephone/Mobile/Internet Charges";
				lst1.Value = "608";
				lstClaim_Head.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "629-Others";
				lst1.Value = "629";
				lstClaim_Head.Items.Add(lst1);
				lstClaim_Head.Items.Insert(0, "");

				OracleCommand cmd11 = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
				conn1.Open();
				lblCDT.Text = Convert.ToString(cmd11.ExecuteScalar());

				conn1.Close();

				OracleCommand cmd = new OracleCommand("select to_char(sysdate,'yyyy') from dual", conn1);
				conn1.Open();
				int yr = Convert.ToInt32(cmd.ExecuteScalar());
				conn1.Close();
				ListItem lst = new ListItem();
				for (int i = yr; i >= 2008; i--)
				{
					lst = new ListItem();
					lst.Text = i.ToString();
					lst.Value = i.ToString();
					lstYear.Items.Add(lst);
					lstYear1.Items.Add(lst);
				}

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
					lstIE.Items.Add(lst3);
				}
				conn1.Close();
				conn1.Dispose();
				if (Convert.ToString(Request.Params["CLAIM_NO"]) != "" && Convert.ToString(Request.Params["Action"]) == "M")
				{
					if (Convert.ToString(Request.Params["CLAIM_HEAD"]) == "" || Convert.ToString(Request.Params["CLAIM_HEAD"]) == null)
					{
						show();
					}
					//					else if(Convert.ToString(Request.Params["CLAIM_HEAD"])!="")
					//					{
					//						show();
					//						show1();
					//					}
					Panel1.Visible = true;
				}
				else if (Convert.ToString(Request.Params["Action"]) == "A")
				{
					Panel1.Visible = false;
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
		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str3 = "select CLAIM_NO,to_char(CLAIM_DT,'dd/mm/yyyy')CLAIM_DT,to_char(RECEIVE_DT,'dd/mm/yyyy')RECV_DT,IE_CD,PERIOD_FROM,PERIOD_TO,PAYMENT_VCHR_NO,to_char(PAYMENT_VCHR_DT,'dd/mm/yyyy')PAYMENT_VCHR_DATE from T45_CLAIM_MASTER where CLAIM_NO='" + lblCNo.Text + "' ";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				lblCNo.Text = dsP.Tables[0].Rows[0]["CLAIM_NO"].ToString();
				lblCDT.Text = dsP.Tables[0].Rows[0]["CLAIM_DT"].ToString();
				lblRDT.Text = dsP.Tables[0].Rows[0]["RECV_DT"].ToString();
				lstYear.SelectedValue = dsP.Tables[0].Rows[0]["PERIOD_FROM"].ToString().Substring(0, 4);
				lstMonths.SelectedValue = dsP.Tables[0].Rows[0]["PERIOD_FROM"].ToString().Substring(4, 2);
				lstYear1.SelectedValue = dsP.Tables[0].Rows[0]["PERIOD_TO"].ToString().Substring(0, 4);
				lstMonths1.SelectedValue = dsP.Tables[0].Rows[0]["PERIOD_TO"].ToString().Substring(4, 2);
				lstIE.SelectedValue = dsP.Tables[0].Rows[0]["IE_CD"].ToString();
				lblIE.Text = lstIE.SelectedItem.Text;
				txtPVCHRNO.Text = dsP.Tables[0].Rows[0]["PAYMENT_VCHR_NO"].ToString();
				txtPVCHRDT.Text = dsP.Tables[0].Rows[0]["PAYMENT_VCHR_DATE"].ToString();

				txtCLRECDT.Visible = false;
				lstIE.Visible = false;
				lstYear.Enabled = false;
				lstMonths.Enabled = false;
				lstYear1.Enabled = false;
				lstMonths1.Enabled = false;
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
			fillgrid(lblCNo.Text);
		}

		void show1()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str3 = "select CLAIM_NO,CLAIM_HEAD,AMT_CLAIMED,AMT_ADMITTED,AMT_DISALLOWED,REMARKS from T46_CLAIM_DETAIL where CLAIM_NO='" + lblCNo.Text + "' ";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				txtAMTAdmitted.Text = dsP.Tables[0].Rows[0]["AMT_ADMITTED"].ToString();
				txtAMTClaimed.Text = dsP.Tables[0].Rows[0]["AMT_CLAIMED"].ToString();
				txtAMTDisallowed.Text = dsP.Tables[0].Rows[0]["AMT_DISALLOWED"].ToString();
				lstClaim_Head.SelectedValue = dsP.Tables[0].Rows[0]["CLAIM_HEAD"].ToString();
				txtNarrat.Text = dsP.Tables[0].Rows[0]["REMARKS"].ToString();
				txtAMTAdmitted.Enabled = false;
				txtAMTClaimed.Enabled = false;
				txtAMTDisallowed.Enabled = false;
				lstClaim_Head.Enabled = false;
				txtNarrat.Enabled = false;
				conn1.Close();
				btnSave.Visible = false;
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
		private string generate_Claim_NO()
		{
			string wC_NO = "";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				//				string wctr=Session["Region"].ToString()+txtNCR_DT.Text.Substring(8,2);
				//				OracleCommand cmd2 =new OracleCommand("Select lpad(nvl(max(to_number(nvl(substr(NC_NO,5,4),0))),0)+1,4,'0') w_sno From T41_NC_MASTER where substr(NC_NO,1,3)='"+wctr+"'",conn1);
				//				conn1.Open();
				//				string nc_ser=Convert.ToString(cmd2.ExecuteScalar());
				//				wNC_NO=wctr+'-'+nc_ser;
				//				conn1.Close();
				//
				OracleCommand cmd = new OracleCommand("GENERATE_CLAIM_NO", conn1);
				cmd.CommandType = CommandType.StoredProcedure;
				conn1.Open();

				OracleParameter prm1 = new OracleParameter("IN_REGION_CD", OracleDbType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = Session["Region"].ToString();
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_CLAIM_DT", OracleDbType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = Convert.ToString(lblCDT.Text.Trim());
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("OUT_CLAIM_NO", OracleDbType.Char, 11);
				prm3.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32, 1);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				cmd.ExecuteNonQuery();

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					wC_NO = "-1";
				}
				else
				{
					wC_NO = Convert.ToString(cmd.Parameters["OUT_CLAIM_NO"].Value);
				}
				conn1.Close();
				return (wC_NO);
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
				return ("-1");
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

		void fillgrid(string vchr)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			try
			{
				//string str1 = "select R.VCHR_NO,R.SNO,A.ACC_DESC,R.AMOUNT,(B.BPO_NAME||'/'||B.BPO_ADD||'/'||B.BPO_RLY)BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.SAMPLE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND VCHR_NO= '" + VNO + "'";
				if (vchr != "" || vchr != null)
				{
					string str1 = "select CLAIM_NO, DECODE(CLAIM_HEAD,308,'308-Conveyance/Fare Charges',309,'309-Traveling Allowance',310,'310-Hotel Charges',608,'608-Telephone/Mobile/Internet Charges',629,'629-Others') CLAIM_HEAD, AMT_CLAIMED, AMT_ADMITTED, AMT_DISALLOWED,REMARKS from T46_CLAIM_DETAIL T46 where  CLAIM_NO= '" + vchr.Trim() + "'";
					OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP, "Table");
					if (dsP.Tables[0].Rows.Count == 0)
					{
						grdVDt.Visible = false;
					}
					else
					{
						grdVDt.Visible = true;
						grdVDt.DataSource = dsP;
						grdVDt.DataBind();
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		void emptytextbox()
		{

			lstClaim_Head.SelectedIndex = 0;
			txtAMTClaimed.Text = "";
			txtAMTAdmitted.Text = "";
			txtAMTDisallowed.Text = "";
			txtNarrat.Text = "";
		}
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			if (Convert.ToString(Request.Params["Action"]) == "A")
			{
				string C_NO = generate_Claim_NO();
				if (C_NO == "-1")
				{
					DisplayAlert("Claim Details not available");
				}
				else if (lblCNo.Text.Trim() == "")
				{
					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					conn1.Open();

					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					//					OracleCommand cmdCO =new OracleCommand("Select IE_CO_CD from T09_IE where IE_CD="+lblIECD.Text.Trim(),conn1);
					//					int CO=Convert.ToInt32(cmdCO.ExecuteScalar());
					conn1.Close();

					conn1.Open();
					OracleTransaction myTrans = conn1.BeginTransaction();
					try
					{
						string myInsertQuery = "INSERT INTO T45_CLAIM_MASTER(CLAIM_NO,CLAIM_DT,RECEIVE_DT,IE_CD,PERIOD_FROM,PERIOD_TO, REGION_CODE, USER_ID, DATETIME) values('" + C_NO + "',to_date('" + lblCDT.Text.Trim() + "','dd/mm/yyyy'), to_date('" + txtCLRECDT.Text.Trim() + "','dd/mm/yyyy')," + lstIE.SelectedValue + "," + lstYear.SelectedValue + lstMonths.SelectedValue + "," + lstYear1.SelectedValue + lstMonths1.SelectedValue + ",'" + Session["Region"] + "','" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Transaction = myTrans;
						myInsertCommand.Connection = conn1;
						myInsertCommand.ExecuteNonQuery();

						string myInsertQuery1 = "INSERT INTO T46_CLAIM_DETAIL(CLAIM_NO,CLAIM_HEAD,AMT_CLAIMED,AMT_ADMITTED,AMT_DISALLOWED,REMARKS,USER_ID,DATETIME) values('" + C_NO + "','" + lstClaim_Head.SelectedValue + "'," + txtAMTClaimed.Text + "," + txtAMTAdmitted.Text + "," + txtAMTDisallowed.Text + ",'" + txtNarrat.Text.Trim() + "','" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
						OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
						myInsertCommand1.Transaction = myTrans;
						myInsertCommand1.Connection = conn1;
						myInsertCommand1.ExecuteNonQuery();
						myTrans.Commit();
						conn1.Close();
						lblCNo.Text = C_NO;
						emptytextbox();
					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						myTrans.Rollback();
						string str1 = str.Replace("\n", "");
						Response.Redirect(("Error_Form.aspx?err=" + str1));
					}
					finally
					{
						conn1.Close();
						conn1.Dispose();
					}
					Response.Redirect("IE_Claim_Form.aspx?CLAIM_NO=" + lblCNo.Text + "&Action=M");
					//					btnSave.Visible=false;
					//					Response.Redirect("IE_NC_Form.aspx?Action=M&NC_NO="+lblNC_NO.Text);
				}

			}
			else if (Convert.ToString(Request.Params["Action"]) == "M")
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn1.Open();

				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				//					OracleCommand cmdCO =new OracleCommand("Select IE_CO_CD from T09_IE where IE_CD="+lblIECD.Text.Trim(),conn1);
				//					int CO=Convert.ToInt32(cmdCO.ExecuteScalar());
				conn1.Close();

				conn1.Open();

				try
				{
					string myInsertQuery1 = "INSERT INTO T46_CLAIM_DETAIL(CLAIM_NO,CLAIM_HEAD,AMT_CLAIMED,AMT_ADMITTED,AMT_DISALLOWED,REMARKS,USER_ID,DATETIME) values('" + lblCNo.Text + "','" + lstClaim_Head.SelectedValue + "'," + txtAMTClaimed.Text + "," + txtAMTAdmitted.Text + "," + txtAMTDisallowed.Text + ",'" + txtNarrat.Text.Trim() + "','" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
					myInsertCommand1.Connection = conn1;
					myInsertCommand1.ExecuteNonQuery();
					conn1.Close();
					emptytextbox();
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
				fillgrid(lblCNo.Text);

			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IE_Claim_Form.aspx?CLAIM_NO=" + lblCNo.Text + "&Action=M");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IE_Claim_Search.aspx");
		}

		protected void btnSPDetails_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				string myUpdateQuery1 = "update T45_CLAIM_MASTER set PAYMENT_VCHR_NO='" + txtPVCHRNO.Text.Trim() + "', PAYMENT_VCHR_DT=to_date('" + txtPVCHRDT.Text.Trim() + "','dd/mm/yyyy') where CLAIM_NO='" + lblCNo.Text.Trim() + "'";
				OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
				myUpdateCommand1.Connection = conn1;
				myUpdateCommand1.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Payment Details Saved!!!");
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