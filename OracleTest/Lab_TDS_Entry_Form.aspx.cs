using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Lab_TDS_Entry_Form
{
	public partial class Lab_TDS_Entry_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string BNO = "", CNO, CDT, BCD;
		double AMTCLR;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			// Put user code to initialize the page here
			//			if(Convert.ToString(Request.Params["BILL_NO"])=="" || Convert.ToString(Request.Params["BILL_NO"])==null)
			//			{
			//				BNO="";
			//			}
			//			else if(Convert.ToString(Request.Params["BILL_NO"])!="")
			//			{
			//				BNO=Convert.ToString(Request.Params["BILL_NO"]);
			//				CNO=Convert.ToString(Request.Params["CHQ_NO"]);
			//				CDT=Convert.ToString(Request.Params["CHQ_DT"]);
			//				BCD=Convert.ToString(Request.Params["BANK_CD"]);
			//				AMTCLR=Convert.ToDouble(Request.Params ["AMOUNT_CLEARED"]);
			//			}
			//			else if(Convert.ToString(Request.Params["BILL_NO"])!="" && Convert.ToString(Request.Params["CHQ_NO"])!="")
			//			{
			//			
			//			}
			//
			//			if (!(IsPostBack))
			//			{
			//				if(BNO=="")
			//				{
			//					Label4.Visible=false;
			//					Label5.Visible=false;
			//					lblCNo.Visible=false;
			//					txtTDS.Visible=false;
			//					txtTDSDT.Visible=false;
			//					Label8.Visible=false;
			//					btnCHQPOSTING.Visible=false;
			//				}
			//				else
			//				{
			//					txtBNO.Text=BNO;
			//					btnCHQPOSTING.Visible=true;
			//					searchBill();
			//				}
			//			}
			//			if(Session["Role_CD"].ToString()=="4")
			//			{
			//				btnSave.Visible=false;
			//												
			//			}
			//			else
			//			{
			//				btnSave.Visible=true;
			//			}
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
			string str3 = "select SAMPLE_REG_NO, CASE_NO, NVL(TDS,0)TDS, NVL(TOTAL_LAB_CHARGES,0)TOTAL_CHARGES, NVL(AMOUNT_RECIEVED,0)AMT_REC, to_char(TDS_DT,'dd/mm/yyyy')TDS_DT from T50_LAB_REGISTER where SAMPLE_REG_NO= '" + txtBNO.Text + "' AND substr(CASE_NO,1,1)='" + Session["Region"].ToString() + "' AND NVL(AMOUNT_RECIEVED,0)<NVL(TOTAL_LAB_CHARGES,0)";
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("InValid Sample Registration No.");
				btnSave.Visible = false;
				txtTDSDT.Visible = false;
				txtTDS.Visible = false;
			}
			else
			{
				lblCNo.Visible = true;
				lblTotLabCharges.Visible = true;
				lblAmtRec.Visible = true;
				txtTDS.Visible = true;
				txtTDSDT.Visible = true;
				lblCNo.Text = dsP.Tables[0].Rows[0]["CASE_NO"].ToString();
				txtTDS.Text = dsP.Tables[0].Rows[0]["TDS"].ToString();
				lblAmtRec.Text = dsP.Tables[0].Rows[0]["AMT_REC"].ToString();
				lblTotLabCharges.Text = dsP.Tables[0].Rows[0]["TOTAL_CHARGES"].ToString();
				txtTDSDT.Text = dsP.Tables[0].Rows[0]["TDS_DT"].ToString();

				if (Session["Role_CD"].ToString() != "5")
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
			string str3 = "update T50_LAB_REGISTER set TDS=" + txtTDS.Text + ",TDS_DT=to_date('" + txtTDSDT.Text + "','dd/mm/yyyy') where SAMPLE_REG_NO='" + txtBNO.Text + "'";
			OracleCommand cmd3 = new OracleCommand(str3, conn1);
			conn1.Open();
			cmd3.ExecuteNonQuery();
			conn1.Close();
			DisplayAlert("YOUR RECORD IS SAVED");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Lab_Menu.aspx");
		}

		//		private void btnCHQPOSTING_Click(object sender, System.EventArgs e)
		//		{
		//			Response.Redirect("Check_Posting_Form.aspx?BILL_NO="+BNO+"&CHQ_NO="+CNO+"&CHQ_DT="+CDT+"&BANK_CD="+BCD+"&AMOUNT_CLEARED="+AMTCLR);
		//		}
	}
}