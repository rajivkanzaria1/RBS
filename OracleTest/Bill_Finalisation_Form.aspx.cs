using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Bill_Finalisation_Form
{
	public partial class Bill_Finalisation_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		//string wFrmDt,wToDt,wRegion;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!(IsPostBack))
			{

				ListItem lst = new ListItem();
				lst.Text = "All";
				lst.Value = "A";
				lstClientType1.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Railways";
				lst.Value = "R";
				lstClientType1.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Private";
				lst.Value = "P";
				lstClientType1.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "PSU";
				lst.Value = "U";
				lstClientType1.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "State Govt.";
				lst.Value = "S";
				lstClientType1.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Foreign Railways";
				lst.Value = "F";
				lstClientType1.Items.Add(lst);
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

		string dateconcat(string dt)
		{
			string myYear, myMonth, myDay;
			myYear = dt.Substring(6, 4);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt_out = myYear + myMonth + myDay;
			return (dt_out);
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			fillgrid();

		}
		public void fillgrid()
		{
			string wHdr_YrMth;
			string wDtFr;
			string wDtTo;
			//string wRegion="";
			wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
			wDtFr = dateconcat(frmDt.Text);
			wDtTo = dateconcat(toDt.Text);
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			try
			{
				wHdr_YrMth = frmDt.Text + " to " + toDt.Text;
				wDtFr = dateconcat(frmDt.Text);
				wDtTo = dateconcat(toDt.Text);

				string str1 = "SELECT ROW_NUMBER() OVER (ORDER BY BILL_NO) AS S_NO, BILL_NO, TO_CHAR(BILL_DT,'DD/MM/YYYY')BILL_DATE,INSP_FEE,CGST,SGST,IGST, BILL_AMOUNT,INVOICE_NO,BPO_NAME||'/'||BPO_RLY||'/'||BPO_CITY BPO,CONSIGNEE||'/'||CONSIGNEE_CITY CONSIGNEE,RECIPIENT_GSTIN_NO FROM V22_BILL V22 WHERE BILL_DT>='01-NOV-20' AND SENT_TO_SAP IS NULL AND BILL_FINALISED IS NULL AND REGION_CODE='" + Session["Region"] + "' AND ((to_char(BILL_DT,'yyyyMMdd')>='" + wDtFr + "' And to_char(BILL_DT,'yyyyMMdd')<='" + wDtTo + "')) ";

				if (lstClientType1.SelectedValue != "A")
				{
					str1 = str1 + " and V22.BPO_TYPE='" + lstClientType1.SelectedValue + "'";
				}
				str1 = str1 + " ORDER BY BILL_DT, BILL_NO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCDetails_1.Visible = false;

				}
				else
				{
					grdCDetails_1.Visible = true;
					grdCDetails_1.DataSource = dsP;
					grdCDetails_1.DataBind();
					conn1.Close();
					btnUpdate.Visible = true;


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
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			conn1.Open();
			OracleTransaction myTrans = null;
			try
			{

				myTrans = conn1.BeginTransaction();
				foreach (DataGridItem di in grdCDetails_1.Items)
				{
					// Make sure this is an item and not the header or footer.

					bool w_Bill_Final = false;
					//int err=0;
					string w_Bill_No = "";
					if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
					{

						w_Bill_Final = Convert.ToBoolean(((CheckBox)di.FindControl("chkBFinal")).Checked);


						if (w_Bill_Final == true)
						{
							w_Bill_No = Convert.ToString(di.Cells[1].Text);
							//err=1;

							string myUpdateQuery = "UPDATE T22_BILL SET BILL_DT=to_date('" + ss + "','dd/mm/yyyy'), BILL_FINALISED='Y' WHERE BILL_NO='" + w_Bill_No + "'";
							OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
							myUpdateCommand.Transaction = myTrans;
							myUpdateCommand.Connection = conn1;
							myUpdateCommand.ExecuteNonQuery();

						}

					}


				}
				myTrans.Commit();
				DisplayAlert("Your Records are Update!!!");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				myTrans.Rollback();
				DisplayAlert("Your Record Has Not Been Saved, So Try Again!!!");
			}
			finally
			{
				conn1.Close();
			}
			fillgrid();
		}
	}
}