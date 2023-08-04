using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.LAB_Bill_Finalisation_Form
{
	public partial class LAB_Bill_Finalisation_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		//string wFrmDt,wToDt,wRegion;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			string wRegion = "";
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

				string str1 = "select (B.BPO_CD||'-'||B.BPO_NAME||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO_NAME," +
					"t55.recipient_gstin_no recipient_gstin_no, t55.invoice_no invoice_no,to_char(t55.invoice_dt, 'dd/mm/yyyy') invoice_dt,Round(to_number(t55.bill_amount + t55.total_cgst + t55.total_igst + t55.total_sgst)) Total_AMT," +
					"t55.bill_amount INV_amount, t55.total_sgst INV_sgst, t55.total_cgst INV_cgst, t55.total_igst INV_igst " +
					"from t55_Lab_Invoice t55, t12_bill_paying_officer B,T03_CITY C, t92_state t92 " +
					"where t55.bpo_cd= b.bpo_cd and B.BPO_CITY_CD= C.CITY_CD and C.state_cd=t92.state_cd and t55.invoice_dt>='01-NOV-20' AND SENT_TO_SAP IS NULL AND BILL_FINALISED IS NULL and t55.region_code='" + Session["Region"].ToString() + "' AND ((to_char(t55.invoice_dt,'yyyyMMdd')>='" + wDtFr + "' And to_char(t55.invoice_dt,'yyyyMMdd')<='" + wDtTo + "')) ORDER BY t55.invoice_dt, t55.invoice_no ";

				//				string str1="SELECT BILL_NO, TO_CHAR(BILL_DT,'DD/MM/YYYY')BILL_DATE,INSP_FEE,CGST,SGST,IGST, BILL_AMOUNT,INVOICE_NO,BPO_NAME||'/'||BPO_RLY||'/'||BPO_CITY BPO,CONSIGNEE||'/'||CONSIGNEE_CITY CONSIGNEE,RECIPIENT_GSTIN_NO FROM V22_BILL V22 WHERE BILL_DT>'01-OCT-20' AND SENT_TO_SAP IS NULL AND BILL_FINALISED IS NULL AND REGION_CODE='"+Session["Region"]+"' AND ((to_char(BILL_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(BILL_DT,'yyyyMMdd')<='"+wDtTo+"')) ORDER BY BILL_DT, BILL_NO";
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
							w_Bill_No = Convert.ToString(di.Cells[0].Text);
							//err=1;

							string myUpdateQuery = "UPDATE t55_Lab_Invoice SET invoice_dt=to_date('" + ss + "','dd/mm/yyyy'), BILL_FINALISED='Y' WHERE invoice_no='" + w_Bill_No + "'";
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