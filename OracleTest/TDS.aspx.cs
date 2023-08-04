using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.TDS
{
	public partial class TDS : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string BNO = "", CNO, CDT, BCD;
		double AMTCLR;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			// Put user code to initialize the page here
			if (Convert.ToString(Request.Params["BILL_NO"]) == "" || Convert.ToString(Request.Params["BILL_NO"]) == null)
			{
				BNO = "";
			}
			else if (Convert.ToString(Request.Params["BILL_NO"]) != "")
			{
				BNO = Convert.ToString(Request.Params["BILL_NO"]);
				CNO = Convert.ToString(Request.Params["CHQ_NO"]);
				CDT = Convert.ToString(Request.Params["CHQ_DT"]);
				BCD = Convert.ToString(Request.Params["BANK_CD"]);
				AMTCLR = Convert.ToDouble(Request.Params["AMOUNT_CLEARED"]);
			}
			//			else if(Convert.ToString(Request.Params["BILL_NO"])!="" && Convert.ToString(Request.Params["CHQ_NO"])!="")
			//			{
			//			
			//			}

			if (!(IsPostBack))
			{
				if (BNO == "")
				{
					Label4.Visible = false;
					Label5.Visible = false;
					lblCNo.Visible = false;
					txtTDS.Visible = false;
					Label6.Visible = false;
					Label7.Visible = false;
					txtRetention.Visible = false;
					txtWriteOffAmt.Visible = false;
					txtTDSDT.Visible = false;
					Label8.Visible = false;
					btnCHQPOSTING.Visible = false;
				}
				else
				{
					txtBNO.Text = BNO;
					btnCHQPOSTING.Visible = true;
					searchBill();
				}
			}
			if (Session["Role_CD"].ToString() == "4")
			{
				btnSave.Visible = false;

			}
			else
			{
				btnSave.Visible = true;
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

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			searchBill();
		}
		void searchBill()
		{
			DataSet dsP = new DataSet();
			string str3 = "select BILL_NO, CASE_NO, NVL(BILL_AMOUNT,0)BILL_AMT, NVL(TDS,0)TDS, NVL(TDS_CGST,0)TDS_CGST, NVL(TDS_SGST,0)TDS_SGST, NVL(TDS_IGST,0)TDS_IGST, NVL(RETENTION_MONEY,0)RETENTION_MONEY, NVL(WRITE_OFF_AMT,0)WRITE_OFF_AMT, to_char(TDS_DT,'dd/mm/yyyy')TDS_DT from T22_BILL where BILL_NO= '" + txtBNO.Text + "' AND substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "'";
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("InValid BILL No.");
				Label4.Visible = false;
				Label5.Visible = false;
				lblCNo.Visible = false;
				lblBillAmt.Visible = false;
				txtTDS_CGST.Visible = false;
				txtTDS_SGST.Visible = false;
				txtTDS_IGST.Visible = false;
				txtTDS.Visible = false;
				Label6.Visible = false;
				Label7.Visible = false;
				txtRetention.Visible = false;
				txtWriteOffAmt.Visible = false;
				btnSave.Visible = false;
				txtTDSDT.Visible = false;
				Label8.Visible = false;
				Label9.Visible = false;
				Label10.Visible = false;
				Label11.Visible = false;
				Label12.Visible = false;
			}
			else
			{
				Label4.Visible = true;
				Label5.Visible = true;
				lblCNo.Visible = true;
				lblBillAmt.Visible = true;
				Label9.Visible = true;
				Label10.Visible = true;
				Label11.Visible = true;
				Label12.Visible = true;
				txtTDS.Visible = true;
				txtTDS_CGST.Visible = true;
				txtTDS_SGST.Visible = true;
				txtTDS_IGST.Visible = true;
				Label6.Visible = true;
				Label7.Visible = true;
				txtRetention.Visible = true;
				txtWriteOffAmt.Visible = true;
				txtTDSDT.Visible = true;
				Label8.Visible = true;
				lblCNo.Text = dsP.Tables[0].Rows[0]["CASE_NO"].ToString();
				lblBillAmt.Text = dsP.Tables[0].Rows[0]["BILL_AMT"].ToString();
				txtTDS.Text = dsP.Tables[0].Rows[0]["TDS"].ToString();
				lblTDS.Text = dsP.Tables[0].Rows[0]["TDS"].ToString();
				txtTDS_CGST.Text = dsP.Tables[0].Rows[0]["TDS_CGST"].ToString();
				lblTDS_CGST.Text = dsP.Tables[0].Rows[0]["TDS_CGST"].ToString();
				txtTDS_SGST.Text = dsP.Tables[0].Rows[0]["TDS_SGST"].ToString();
				lblTDS_SGST.Text = dsP.Tables[0].Rows[0]["TDS_SGST"].ToString();
				txtTDS_IGST.Text = dsP.Tables[0].Rows[0]["TDS_IGST"].ToString();
				lblTDS_IGST.Text = dsP.Tables[0].Rows[0]["TDS_IGST"].ToString();
				txtRetention.Text = dsP.Tables[0].Rows[0]["RETENTION_MONEY"].ToString();
				lblRMoney.Text = dsP.Tables[0].Rows[0]["RETENTION_MONEY"].ToString();
				txtWriteOffAmt.Text = dsP.Tables[0].Rows[0]["WRITE_OFF_AMT"].ToString();
				lblWOffAmt.Text = dsP.Tables[0].Rows[0]["WRITE_OFF_AMT"].ToString();
				txtTDSDT.Text = dsP.Tables[0].Rows[0]["TDS_DT"].ToString();

				if (Session["Role_CD"].ToString() == "4")
				{
					btnSave.Visible = false;

				}
				else
				{
					btnSave.Visible = true;
				}
			}
			conn1.Close();

		}
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			double wtotOld = Convert.ToDouble(lblTDS.Text) + Convert.ToDouble(lblRMoney.Text) + Convert.ToDouble(lblWOffAmt.Text) + Convert.ToDouble(lblTDS_CGST.Text) + Convert.ToDouble(lblTDS_SGST.Text) + Convert.ToDouble(lblTDS_IGST.Text);
			double wtotNew = Convert.ToDouble(txtTDS.Text) + Convert.ToDouble(txtRetention.Text) + Convert.ToDouble(txtWriteOffAmt.Text) + Convert.ToDouble(txtTDS_CGST.Text) + Convert.ToDouble(txtTDS_SGST.Text) + Convert.ToDouble(txtTDS_IGST.Text);
			string str3 = "update T22_BILL set TDS=" + txtTDS.Text + ",TDS_CGST=" + txtTDS_CGST.Text + ",TDS_SGST=" + txtTDS_SGST.Text + ",TDS_IGST=" + txtTDS_IGST.Text + ",RETENTION_MONEY=" + txtRetention.Text + ",WRITE_OFF_AMT=" + txtWriteOffAmt.Text + ",BILL_AMT_CLEARED=((nvl(BILL_AMT_CLEARED,0)-" + wtotOld + ")+" + wtotNew + "),TDS_DT=to_date('" + txtTDSDT.Text + "','dd/mm/yyyy') where BILL_NO='" + txtBNO.Text + "'";
			OracleCommand cmd3 = new OracleCommand(str3, conn1);
			conn1.Open();
			cmd3.ExecuteNonQuery();
			conn1.Close();
			lblTDS.Text = txtTDS.Text;
			lblTDS_CGST.Text = txtTDS_CGST.Text;
			lblTDS_SGST.Text = txtTDS_SGST.Text;
			lblTDS_IGST.Text = txtTDS_IGST.Text;
			lblRMoney.Text = txtRetention.Text;
			lblWOffAmt.Text = txtWriteOffAmt.Text;
			DisplayAlert("YOUR RECORD IS SAVED");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		protected void btnCHQPOSTING_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Check_Posting_Form.aspx?BILL_NO=" + BNO + "&CHQ_NO=" + CNO + "&CHQ_DT=" + CDT + "&BANK_CD=" + BCD + "&AMOUNT_CLEARED=" + AMTCLR);
		}
	}
}