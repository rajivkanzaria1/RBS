using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IC_Receipt
{
	public partial class IC_Receipt : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.Button btnSearchIC;
		string BKNO, SNO, Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:search();");
			btnReport.Attributes.Add("OnClick", "JavaScript:rep_validate();");

			if (Request.Params["BK_NO"] == null && Request.Params["SET_NO"] == null)
			{
				BKNO = "";
				SNO = "";
				Action = "A";

			}
			else
			{
				BKNO = Convert.ToString(Request.QueryString["BK_NO"]);
				SNO = Convert.ToString(Request.QueryString["SET_NO"]);
				Action = "M";
			}


			if (!IsPostBack)
			{
				fill_IEwhomeIssued();
				string ss = current_date();
				if (Action == "A")
				{
					txtICDT.Text = ss.Substring(0, 10);
					btnDelete.Visible = false;
				}
				else if (Action == "M")
				{
					show();
					btnDelete.Visible = true;
				}
				txtRDT.Text = ss.Substring(0, 10);

			}
			if (Session["Role_CD"].ToString() == "4")
			{
				btnSave.Visible = false;
				btnDelete.Visible = false;

			}
			//			txtICDT.Enabled=false;
		}
		string current_date()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			return (ss);
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
				string str1 = ("select Region,BK_NO,SET_NO,IE_CD,to_char(IC_SUBMIT_DT,'dd/mm/yyyy')SUBMIT_DT,REMARKS,to_char(REMARKS_DT,'dd/mm/yyyy')REMARKS_DATE from T30_IC_RECEIVED where UPPER(TRIM(BK_NO))=upper(TRIM('" + BKNO + "')) and UPPER(TRIM(SET_NO))=upper(TRIM('" + SNO + "')) and REGION='" + Session["Region"] + "' and BILL_NO is null");
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand1;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{
					txtBKNo.Text = dsP.Tables[0].Rows[0]["BK_NO"].ToString();
					txtSetNo.Text = dsP.Tables[0].Rows[0]["SET_NO"].ToString();
					ddlIE.SelectedValue = dsP.Tables[0].Rows[0]["IE_CD"].ToString();
					txtICDT.Text = dsP.Tables[0].Rows[0]["SUBMIT_DT"].ToString();
					txtRemarks.Text = dsP.Tables[0].Rows[0]["REMARKS"].ToString();
					txtRemarksDT.Text = dsP.Tables[0].Rows[0]["REMARKS_DATE"].ToString();

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


		public void fill_IEwhomeIssued()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				ddlIE.Items.Clear();
				OracleCommand cmd = new OracleCommand("select IE_CD,IE_NAME from T09_IE where IE_STATUS is null and IE_REGION ='" + Session["Region"].ToString() + "' ORDER BY IE_NAME", conn1);
				OracleDataReader dr;
				conn1.Open();
				dr = cmd.ExecuteReader();
				ListItem lst;
				while (dr.Read())
				{
					lst = new ListItem();
					lst.Text = Convert.ToString(dr["IE_NAME"]);
					lst.Value = Convert.ToString(dr["IE_CD"]);
					ddlIE.Items.Add(lst);
				}
				ddlIE.Items.Insert(0, "");
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

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str = "Select t30.BK_NO,t30.SET_NO,t09.IE_NAME,to_char(t30.IC_SUBMIT_DT,'dd/mm/yyyy') IC_SUBMIT_DT From T30_IC_RECEIVED t30,T09_IE t09 Where t30.IE_CD=t09.IE_CD ";

				if (txtBKNo.Text.Trim() != "")
				{
					str = str + " and upper(trim(t30.BK_NO)) LIKE upper('" + txtBKNo.Text.Trim() + "')";
				}

				if (txtSetNo.Text.Trim() != "")
				{
					str = str + " and trim(t30.SET_NO)='" + txtSetNo.Text.Trim() + "'";
				}
				if (ddlIE.SelectedItem.Text != "")
				{
					str = str + " and trim(t30.IE_CD)=trim(" + ddlIE.SelectedValue + ")";
				}
				//				if(txtICDT.Text.Trim()!="")
				//				{
				//					str = str + " and to_Char(t30.IC_SUBMIT_DT,'dd/mm/yyyy')='"+txtICDT.Text.Trim()+"'"; 	
				//				}

				str = str + " and BILL_NO is null and REGION='" + Session["Region"].ToString() + "' ORDER BY t30.BK_NO ,t30.SET_NO";

				OracleCommand myOracleCommand1 = new OracleCommand(str, conn1);
				conn1.Open();
				OracleDataReader dr;
				dr = myOracleCommand1.ExecuteReader(CommandBehavior.CloseConnection);
				grdBook.Caption = "<span class=MyDataGridCaption>UN-BILLED  INSPECTION CERTIFICATES</span>";

				if (dr.HasRows)
				{
					grdBook.DataSource = dr;
					grdBook.DataBind();
					grdBook.Visible = true;
				}
				else
				{
					grdBook.Visible = false;
					DisplayAlert("No Data Found!!!");
				}
				btnSave.Enabled = false;
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

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IC_Receipt.aspx");
		}

		int checkic()
		{
			//			conn1= new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
			conn1.Open();
			OracleCommand cmd1 = new OracleCommand("Select to_char(ISSUE_DT,'yyyymmdd') from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNo.Text + "') and (" + Convert.ToInt32(txtSetNo.Text) + " between (SET_NO_FR) and (SET_NO_TO)) and ISSUE_TO_IECD=" + ddlIE.SelectedValue, conn1);
			string bscheck = Convert.ToString(cmd1.ExecuteScalar());
			conn1.Close();
			string myYear = txtICDT.Text.Substring(6, 4);
			string myMonth = txtICDT.Text.Substring(3, 2);
			string myDay = txtICDT.Text.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;

			int i = bscheck.CompareTo(dt1);


			if (bscheck != "")
			{
				conn1.Open();
				if (i > 0)
				{
					return (3);
				}
				else
				{

					OracleCommand cmd = new OracleCommand("Select BILL_NO from T20_IC where TRIM(BK_NO)=upper('" + txtBKNo.Text.Trim() + "') and TRIM(SET_NO)=upper('" + txtSetNo.Text.Trim() + "') and substr(CASE_NO,1,1)='" + Session["Region"] + "'", conn1);
					string bscheck1 = Convert.ToString(cmd.ExecuteScalar());
					conn1.Close();

					if (bscheck1 == "" || bscheck1 == null)
					{
						return (1);
					}
					else
					{
						return (2);
					}
				}
			}
			else
			{
				return (0);
			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			string ss = current_date();
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			if (Action == "A")
			{
				int bscheck = checkic();
				if (bscheck == 1)
				{
					try
					{

						string myInsertQuery = "INSERT INTO T30_IC_RECEIVED(REGION,BK_NO,SET_NO,IE_CD,IC_SUBMIT_DT,BILL_NO,USER_ID,DATETIME,REMARKS,REMARKS_DT) values('" + Session["Region"].ToString() + "','" + txtBKNo.Text + "','" + txtSetNo.Text + "'," + ddlIE.SelectedValue + ",to_date('" + txtICDT.Text + "','dd/mm/yyyy'),null,'" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + txtRemarks.Text + "',to_date('" + txtRemarksDT.Text.Trim() + "','dd/mm/yyyy-HH24:MI:SS'))";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Connection = conn1;
						conn1.Open();
						myInsertCommand.ExecuteNonQuery();
						conn1.Close();
						DisplayAlert("Record Saved!!!");
						//						fillgrid();
					}
					catch (OracleException ex)
					{
						string str;
						str = ex.Message;
						if (ex.ErrorCode == 00001)
						{
							DisplayAlert("This IC is already Exists!!!");
						}
						else
						{
							string str1 = str.Replace("\n", "");
							Response.Redirect(("Error_Form.aspx?err=" + str1));
						}
					}
					finally
					{
						conn1.Close();
						conn1.Dispose();
					}


				}
				else if (bscheck == 0)
				{
					DisplayAlert("Book No. and Set No. specified is not issued to the Selected Inspection Engineer!!!");
				}
				else if (bscheck == 2)
				{
					DisplayAlert("Bill already generated for given Book and Set No.!!!");
				}
				else if (bscheck == 3)
				{
					DisplayAlert("IC Submit Date Cannot be Less then Issue Date!!!");
				}
			}
			else if (Action == "M")
			{
				int bscheck = checkic();
				if (bscheck == 1)
				{

					try
					{
						string myUpdateQuery = "UPDATE T30_IC_RECEIVED set BK_NO=trim('" + txtBKNo.Text + "'),SET_NO=trim('" + txtSetNo.Text + "'),IE_CD=" + ddlIE.SelectedValue + ",IC_SUBMIT_DT=to_date('" + txtICDT.Text + "','dd/mm/yyyy'),USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),REMARKS='" + txtRemarks.Text + "',REMARKS_DT=to_date('" + txtRemarksDT.Text.Trim() + "','dd/mm/yyyy') where UPPER(TRIM(BK_NO))=upper(TRIM('" + BKNO + "')) and UPPER(TRIM(SET_NO))=upper(TRIM('" + SNO + "')) and REGION='" + Session["Region"] + "'";
						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
						myUpdateCommand.Connection = conn1;
						conn1.Open();
						myUpdateCommand.ExecuteNonQuery();
						conn1.Close();



					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						string str2 = str.Replace("\n", "");
						Response.Redirect("Error_Form.aspx?err=" + str2);
					}
					finally
					{
						conn1.Close();
						conn1.Dispose();
					}
					Response.Redirect("IC_Receipt.aspx");
				}
				else if (bscheck == 0)
				{
					DisplayAlert("Book No. and Set No. specified is not issued to the Selected Inspection Engineer!!!");
				}
				else if (bscheck == 2)
				{
					DisplayAlert("Bill already generated for given Book and Set No.!!!");
				}
				else if (bscheck == 3)
				{
					DisplayAlert("IC Submit Date Cannot be Less then Issue Date  !!!");
				}
			}
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string myUpdateQuery = "delete T30_IC_RECEIVED where UPPER(TRIM(BK_NO))=upper(TRIM('" + BKNO + "')) and UPPER(TRIM(SET_NO))=upper(TRIM('" + SNO + "')) and REGION='" + Session["Region"] + "' and BILL_NO is null";
				OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
				myUpdateCommand.Connection = conn1;
				conn1.Open();
				myUpdateCommand.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Record Deleted!!!");
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

		protected void btnReport_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("Reports/UnbilledIC.aspx?DT="+txtRDT.Text.Trim());
			Response.Redirect("Reports/pfrmFromToDate.aspx?ACTION=UNBILLEDIC");
		}

		protected void btnStatus_IC_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Reports/rptIC_STATUS.aspx");
		}

		protected void btnIssuedNRec_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Reports/pfrmFromToDate.aspx?ACTION=ICISSUEDNSUB");
		}

		//		private void btnAdd_Click(object sender, System.EventArgs e)
		//		{
		//			Response.Redirect("IC_Receipt.aspx");
		//		}

	}
}