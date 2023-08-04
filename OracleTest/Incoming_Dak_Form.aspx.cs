using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Incoming_Dak_Form
{
	public partial class Incoming_Dak_Form : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label lblLetterID;
		protected System.Web.UI.WebControls.TextBox txtRecDT;
		protected System.Web.UI.WebControls.DropDownList lstRecMode;
		protected System.Web.UI.WebControls.DropDownList lstCategory;
		protected System.Web.UI.WebControls.DropDownList lstLetterType;
		protected System.Web.UI.WebControls.DropDownList lstSpecialCategory;
		protected System.Web.UI.WebControls.DropDownList lstRecCM;
		protected System.Web.UI.WebControls.DropDownList lstMarCM;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.TextBox txtRemarks;
		protected System.Web.UI.WebControls.TextBox txtLetterNo;
		protected System.Web.UI.WebControls.DropDownList lstSubCategory;
		protected System.Web.UI.WebControls.Button btnCancel;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here


			if (!(IsPostBack))
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					DataSet dsP1 = new DataSet();
					string str1 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='" + Session["REGION"] + "' order by CO_NAME ";
					OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
					OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
					ListItem lst1;
					conn1.Open();
					da1.SelectCommand = myOracleCommand1;
					da1.Fill(dsP1, "Table");
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
					{
						lst1 = new ListItem();
						lst1.Text = dsP1.Tables[0].Rows[i]["CO_NAME"].ToString();
						lst1.Value = dsP1.Tables[0].Rows[i]["CO_CD"].ToString();
						lstRecCM.Items.Add(lst1);

					}
					conn1.Close();

					DataSet dsP2 = new DataSet();
					string str2 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='" + Session["REGION"] + "' order by CO_NAME ";
					OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
					OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
					ListItem lst2;
					conn1.Open();
					da2.SelectCommand = myOracleCommand2;
					da2.Fill(dsP2, "Table");
					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
					{
						lst2 = new ListItem();
						lst2.Text = dsP2.Tables[0].Rows[i]["CO_NAME"].ToString();
						lst2.Value = dsP2.Tables[0].Rows[i]["CO_CD"].ToString();
						lstMarCM.Items.Add(lst2);
					}
					conn1.Close();


					conn1.Open();
					OracleCommand cmd = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
					txtRecDT.Text = Convert.ToString(cmd.ExecuteScalar());
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

				lstSubCategory.Visible = false;

				if (Convert.ToString(Request.Params["Letter_ID"]) == null)
				{

					lblLetterID.Visible = false;


				}
				else if (Convert.ToString(Request.Params["Letter_ID"]) != null)
				{

					lblLetterID.Text = Convert.ToString(Request.Params["Letter_ID"].Trim());
					lblLetterID.Visible = true;
					show();
					btnSave.Text = "Update";
				}
			}
		}

		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string MySql = "Select to_char(LETTER_RECV_DT,'dd/mm/yyyy')REC_DATE,LETTER_NO,RECEIVING_MODE, FRM_CATEGORY, FRM_SUBCATEGORY,SUBJECT,LETTER_TYPE_CATEGORY,SPECIAL_CATEGORY,RECEIPT_CM,MARKED_TO_CM,SPECIAL_REMARKS from T55_DAK_INCOMING_MASTER " +
				"Where LETTER_ID='" + lblLetterID.Text.Trim() + "'";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				OracleCommand cmd = new OracleCommand(MySql, conn1);
				conn1.Open();
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					txtRecDT.Text = MyReader["REC_DATE"].ToString();
					txtRecDT.Enabled = false;
					txtLetterNo.Text = MyReader["LETTER_NO"].ToString();
					lstRecMode.SelectedValue = MyReader["RECEIVING_MODE"].ToString();
					lstCategory.SelectedValue = MyReader["FRM_CATEGORY"].ToString();
					if (lstCategory.SelectedValue == "1")
					{
						lstSubCategory.SelectedValue = MyReader["FRM_SUBCATEGORY"].ToString();
						lstSubCategory.Visible = true;
					}
					else
					{
						lstSubCategory.Visible = false;
					}
					txtSubject.Text = MyReader["SUBJECT"].ToString();
					lstLetterType.SelectedValue = MyReader["LETTER_TYPE_CATEGORY"].ToString();
					lstSpecialCategory.SelectedValue = MyReader["SPECIAL_CATEGORY"].ToString();
					lstRecCM.SelectedValue = MyReader["RECEIPT_CM"].ToString();
					lstMarCM.SelectedValue = MyReader["MARKED_TO_CM"].ToString();
					txtRemarks.Text = MyReader["SPECIAL_REMARKS"].ToString();
					//					Label6.Visible=false;
					//					txtCaseNo.Visible=false;
					//					btnSubmitCaseNO.Visible=false;
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
			this.lstCategory.SelectedIndexChanged += new System.EventHandler(this.lstCategory_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstCategory.SelectedValue == "1")
			{
				lstSubCategory.Visible = true;
			}
			else
			{
				lstSubCategory.Visible = false;
			}
		}
		private string generate_Letter_ID()
		{
			string wLetter_ID = "";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

				OracleCommand cmd = new OracleCommand("GENERATE_LETTER_ID", conn1);
				cmd.CommandType = CommandType.StoredProcedure;
				conn1.Open();

				OracleParameter prm1 = new OracleParameter("IN_REGION_CD", System.Data.OracleClient.OracleType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = Session["Region"].ToString();
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_LETTER_DT", System.Data.OracleClient.OracleType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = txtRecDT.Text.Trim();
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("OUT_LETTER_ID", OracleDbType.Varchar2, 9);
				prm3.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32, 1);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				cmd.ExecuteNonQuery();

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					wLetter_ID = "-1";
				}
				else
				{
					wLetter_ID = Convert.ToString(cmd.Parameters["OUT_LETTER_ID"].Value);
				}
				conn1.Close();
				return (wLetter_ID);
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			if (lblLetterID.Text.Trim() == "")
			{
				string LETTER_ID = generate_Letter_ID();
				if (LETTER_ID == "-1")
				{
					DisplayAlert("Registration Details not available");
				}
				else
				{




					try
					{
						conn1.Open();
						string myInsertQuery = "INSERT INTO T55_DAK_INCOMING_MASTER(LETTER_ID,LETTER_RECV_DT,LETTER_NO,RECEIVING_MODE,FRM_CATEGORY,FRM_SUBCATEGORY,SUBJECT,LETTER_TYPE_CATEGORY, SPECIAL_CATEGORY, RECEIPT_CM, MARKED_TO_CM, SPECIAL_REMARKS, REGION_CODE, USER_ID, DATETIME) values('" + LETTER_ID + "',to_date('" + txtRecDT.Text.Trim() + "','dd/mm/yyyy'),'" + txtLetterNo.Text.Trim() + "','" + lstRecMode.SelectedValue + "' ," + lstCategory.SelectedValue + ",'" + lstSubCategory.SelectedValue + "','" + txtSubject.Text.Trim() + "','" + lstLetterType.SelectedValue + "'," + lstSpecialCategory.SelectedValue + "," + lstRecCM.SelectedValue + "," + lstMarCM.SelectedValue + ",'" + txtRemarks.Text + "','" + Session["Region"] + "','" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Connection = conn1;
						myInsertCommand.ExecuteNonQuery();
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
			else
			{
				try
				{
					conn1.Open();
					string myUpdateQuery = "update T55_DAK_INCOMING_MASTER set LETTER_NO='" + txtLetterNo.Text.Trim() + "',RECEIVING_MODE='" + lstRecMode.SelectedValue + "',FRM_CATEGORY=" + lstCategory.SelectedValue + ",FRM_SUBCATEGORY='" + lstSubCategory.SelectedValue + "',SUBJECT='" + txtSubject.Text.Trim() + "',LETTER_TYPE_CATEGORY='" + lstLetterType.SelectedValue + "', SPECIAL_CATEGORY=" + lstSpecialCategory.SelectedValue + ", RECEIPT_CM=" + lstRecCM.SelectedValue + ", MARKED_TO_CM=" + lstMarCM.SelectedValue + ", SPECIAL_REMARKS='" + txtRemarks.Text + "', USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where LETTER_ID='" + lblLetterID.Text.Trim() + "'";
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn1;
					myUpdateCommand.ExecuteNonQuery();
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

		private void btnCancel_Click(object sender, System.EventArgs e)
		{

		}
	}
}