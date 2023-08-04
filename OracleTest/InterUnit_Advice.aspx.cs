using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.InterUnit_Advice
{
	public partial class InterUnit_Advice : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList lstACD;
		protected System.Web.UI.WebControls.TextBox txtAdviceDT;
		protected Tittle.Controls.CustomDataGrid grdAdvDetails;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label txtAdvNO;
		string wAcc, ACTION;
		protected System.Web.UI.WebControls.Label lblAdvNo;
		protected System.Web.UI.WebControls.Label lblAdvAmt;
		protected System.Web.UI.WebControls.Label txtAdvAMT;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnView.Attributes.Add("OnClick", "JavaScript:validate();");
			if ((Convert.ToString(Request.Params["ACTION"]) == "" || Convert.ToString(Request.Params["ACTION"]) == null))
			{
				ACTION = "";
			}
			else
			{
				ACTION = Request.Params["ACTION"].ToString();
			}


			if (!IsPostBack)
			{
				if (Session["Region"].ToString() == "N") { wAcc = "3007"; }
				else if (Session["Region"].ToString() == "E") { wAcc = "3008"; }
				else if (Session["Region"].ToString() == "S") { wAcc = "3009"; }
				else if (Session["Region"].ToString() == "W") { wAcc = "3006"; }
				else if (Session["Region"].ToString() == "C") { wAcc = "3066"; }
				lstACD.SelectedValue = wAcc.ToString();
				lstACD.Items.Remove(lstACD.SelectedItem);
				if (ACTION == "")
				{
					lblAdvAmt.Visible = false;
					lblAdvNo.Visible = false;
					txtAdvNO.Visible = false;
					txtAdvAMT.Visible = false;
					btnSave.Visible = false;
				}
				else
				{
					lblAdvAmt.Visible = true;
					lblAdvNo.Visible = true;
					txtAdvNO.Visible = true;
					txtAdvAMT.Visible = true;
					btnSave.Visible = true;
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
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		void fillgrid()
		{
			try
			{

				DataSet dsP = new DataSet();
				string str1 = "select T27.VCHR_NO,T27.CHQ_NO, to_char(T27.CHQ_DT,'dd/mm/yyyy')CHQ_DT,T94.BANK_NAME BANK,T29.AMOUNT, Decode(T29.ACC_CD,'3007','Northern Region','3008','Eastern Region','3009','Southern Region','3006','Western Region','3066','Central Region') REGION FROM T27_JV T27,T94_BANK T94,T29_JV_DETAILS T29 WHERE T27.BANK_CD=T94.BANK_CD AND T27.VCHR_NO=T29.VCHR_NO AND T29.ACC_CD='" + lstACD.SelectedValue + "' and IU_ADV_NO IS NULL and IU_ADV_DT IS NULL ORDER BY T27.CHQ_DT,T27.CHQ_NO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdAdvDetails.Visible = false;
					btnSave.Visible = false;
					lstACD.Enabled = true;
					txtAdviceDT.Enabled = true;
					DisplayAlert("Their is no Transfer Amount Present!!! ");

				}
				else
				{
					grdAdvDetails.DataSource = dsP;
					grdAdvDetails.DataBind();
					grdAdvDetails.Visible = true;
					btnSave.Visible = true;
					lstACD.Enabled = false;
					txtAdviceDT.Enabled = false;

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






		private void btnView_Click(object sender, System.EventArgs e)
		{
			fillgrid();

		}
		public void generate()
		{
			try
			{
				string TRegion = "";
				if (lstACD.SelectedValue == "3006")
				{
					TRegion = "W";
				}
				else if (lstACD.SelectedValue == "3007")
				{
					TRegion = "N";
				}
				else if (lstACD.SelectedValue == "3008")
				{
					TRegion = "E";
				}
				else if (lstACD.SelectedValue == "3009")
				{
					TRegion = "S";
				}
				else if (lstACD.SelectedValue == "3066")
				{
					TRegion = "C";
				}
				string ss = Session["Region"] + TRegion + txtAdviceDT.Text.Substring(8, 2) + txtAdviceDT.Text.Substring(3, 2);
				//				conn1.Close();

				string str3 = "Select lpad(nvl(max(to_number(nvl(substr(IU_ADV_NO,7,9),0))),0)+1,3,'0') from T28_IU_ADVICE where substr(IU_ADV_NO,1,6)='" + ss + "'";
				OracleCommand myInsertCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				str3 = Convert.ToString(myInsertCommand.ExecuteScalar());
				conn1.Close();
				txtAdvNO.Text = ss + str3;
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			double TADVAMT = 0;
			generate();
			foreach (DataGridItem DGridItem in grdAdvDetails.Items)
			{
				CheckBox myCheckbox = (CheckBox)DGridItem.FindControl("SelCH");
				if (myCheckbox.Checked == true)
				{
					TADVAMT = TADVAMT + Convert.ToDouble(DGridItem.Cells[4].Text);
				}

			}
			txtAdvAMT.Text = TADVAMT.ToString();
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();

			try
			{
				OracleCommand cmd2 = new OracleCommand("INSERT INTO T28_IU_ADVICE VALUES('" + txtAdvNO.Text + "',to_date('" + txtAdviceDT.Text + "','dd/mm/yyyy')," + TADVAMT + ")");
				cmd2.Transaction = myTrans;
				cmd2.Connection = conn1;
				cmd2.ExecuteNonQuery();

				foreach (DataGridItem DGridItem in grdAdvDetails.Items)
				{
					CheckBox myCheckbox = (CheckBox)DGridItem.FindControl("SelCH");

					if (myCheckbox.Checked == true)
					{
						string myUpdateQueryM = "UPDATE T29_JV_DETAILS SET IU_ADV_NO='" + txtAdvNO.Text + "', IU_ADV_DT=to_date('" + txtAdviceDT.Text + "','dd/mm/yyyy') where VCHR_NO='" + DGridItem.Cells[0].Text + "' and ACC_CD='" + lstACD.SelectedValue + "'";
						OracleCommand myUpdateCommandM = new OracleCommand(myUpdateQueryM);
						myUpdateCommandM.Transaction = myTrans;
						myUpdateCommandM.Connection = conn1;
						myUpdateCommandM.ExecuteNonQuery();

					}

				}
				myTrans.Commit();
				conn1.Close();
				lblAdvAmt.Visible = true;
				lblAdvNo.Visible = true;
				txtAdvNO.Visible = true;
				txtAdvAMT.Visible = true;

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
			}
		}

	}
}