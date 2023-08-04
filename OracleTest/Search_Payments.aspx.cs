using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Search_Payments
{
	public partial class Search_Payments : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			btnSearch.Attributes.Add("OnClick", "JavaScript:validate1();");


			if (!(IsPostBack))
			{


				DataSet dsP2 = new DataSet();
				string stra2 = "select BANK_CD,BANK_NAME from T94_BANK order by BANK_NAME";
				OracleDataAdapter da2 = new OracleDataAdapter(stra2, conn1);
				OracleCommand myOracleCommand2 = new OracleCommand(stra2, conn1);
				//ListItem lst; 
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				lstBank.DataValueField = "BANK_CD";
				lstBank.DataTextField = "BANK_NAME";
				lstBank.DataSource = dsP2;
				lstBank.DataBind();
				conn1.Close();
				conn1.Dispose();
				lstBank.Items.Insert(0, "");


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
			try
			{
				OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString); DataSet dsP = new DataSet();
				string str3 = "select T25.VCHR_NO,to_char(T24.VCHR_DT,'dd/mm/yyyy')VCHR_DT,SNO,T25.BANK_CD,T94.BANK_NAME,T25.CHQ_NO,to_char(T25.CHQ_DT,'dd/mm/yyyy')CHQ_DT,NVL(T25.AMOUNT,0) AMOUNT,NVL(T25.AMOUNT_ADJUSTED,0)AMOUNT_ADJUSTED,NVL(T25.SUSPENSE_AMT,0)SUSPENSE_AMT,NVL(T25.AMT_TRANSFERRED,0)AMT_TRANSFERRED, NVL2(T25.BPO_CD,(B.BPO_NAME||'/'||B.BPO_ADD||'/'||B.BPO_RLY),'')BPO,CASE_NO,T25.NARRATION,T25.ACC_CD from T25_RV_DETAILS T25, T24_RV T24,T94_BANK T94,T12_BILL_PAYING_OFFICER B where T24.VCHR_NO=T25.VCHR_NO and T25.BANK_CD=T94.BANK_CD and T25.BPO_CD=B.BPO_CD(+)";
				if (lstBank.SelectedIndex != 0)
				{
					str3 = str3 + " and T25.BANK_CD=" + lstBank.SelectedValue;
				}
				if (txtEFTNO.Text.Trim() != "")
				{
					str3 = str3 + " and trim(UPPER(CHQ_NO)) like trim(upper('" + txtEFTNO.Text.Trim() + "%'))";
				}
				if (txtEFTDT.Text.Trim() != "")
				{
					str3 = str3 + " and CHQ_DT=to_date('" + txtEFTDT.Text.Trim() + "','dd/mm/yyyy')";
				}
				if (txtAmt.Text.Trim() != "")
				{
					str3 = str3 + " and AMOUNT='" + txtAmt.Text + "'";
				}
				if (txtVend.Text.Trim() != "")
				{
					str3 = str3 + " and trim(upper(NARRATION)) LIKE trim(upper('" + txtVend.Text.Trim() + "%'))";
				}
				if (txtCSNO.Text.Trim() != "")
				{
					str3 = str3 + " and CASE_NO='" + txtCSNO.Text.Trim() + "'";
				}
				if (Session["Role_CD"].ToString() == "5")
				{
					str3 = str3 + " and T25.ACC_CD IN ('2210','2212')";
				}
				str3 = str3 + " and substr(T25.VCHR_NO,1,1)='" + Session["Region"] + "' order by VCHR_DT,VCHR_NO";

				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("No Record Found!!!");
					grdEFT.Visible = false;
				}
				else
				{
					grdEFT.Visible = true;
					grdEFT.DataSource = dsP;
					grdEFT.DataBind();
					if (Session["Role_CD"].ToString() == "5")
					{
						grdEFT.Columns[0].Visible = false;
					}


				}
				conn1.Close();
				//
				//				if(Session["Role_CD"].ToString()=="4")
				//				{
				//					grdEFT.Columns[0].Visible=false;
				//					
				//				}

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