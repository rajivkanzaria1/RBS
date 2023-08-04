using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Reciepts_Edit_Form
{
	public partial class Reciepts_Edit_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		//string BNO;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnAdd.Attributes.Add("OnClick", "JavaScript:validate();");
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate1();");
			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["BILL_NO"]) != "")
				{
					string BNO = Convert.ToString(Request.Params["BILL_NO"]);
					txtBillNo.Text = BNO;

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

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{

			string code = txtBillNo.Text;
			string str = "select BILL_NO from T22_BILL where BILL_NO= '" + code + "'";
			OracleCommand myCommand1 = new OracleCommand();
			myCommand1.CommandText = str;
			myCommand1.Connection = conn1;
			conn1.Open();
			string CD = Convert.ToString(myCommand1.ExecuteScalar());
			if (CD != "")
			{
				string str4 = "select BILL_NO from T24_RECEIPTS  where BILL_NO= '" + code + "'";
				OracleCommand myCommand = new OracleCommand();
				myCommand.CommandText = str4;
				myCommand.Connection = conn1;
				string CD1 = Convert.ToString(myCommand.ExecuteScalar());
				conn1.Close();
				if (CD1 == "")
				{
					Response.Redirect("Reciepts_Form.aspx?Action=A&BILL_NO=" + code);
				}
				else
				{
					DisplayAlert("Reciepts Already Exists For the Given Bill No. Use Modify to update it.");
				}
			}
			else
			{
				DisplayAlert("Invalid Bill No.");
			}
		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			string code = txtBillNo.Text;

			string str4 = "select BILL_NO from T24_RECEIPTS  where BILL_NO= '" + code + "'";
			OracleCommand myCommand = new OracleCommand();
			myCommand.CommandText = str4;
			myCommand.Connection = conn1;
			conn1.Open();
			string CD = Convert.ToString(myCommand.ExecuteScalar());
			conn1.Close();
			if (CD == "")
			{
				DisplayAlert("Reciepts Not Found For the Given Bill No.");
			}
			else
			{
				Response.Redirect("Reciepts_Form.aspx?Action=M&BILL_NO=" + code);
			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			string code = txtBillNo.Text;
			string str4 = "select BILL_NO from T24_RECEIPTS  where BILL_NO= '" + code + "'";
			OracleCommand myCommand = new OracleCommand();
			myCommand.CommandText = str4;
			myCommand.Connection = conn1;
			conn1.Open();
			string CD = Convert.ToString(myCommand.ExecuteScalar());
			conn1.Close();
			if (CD == "")
			{
				DisplayAlert("Reciepts Not Found For the Given Bill No.");
			}
			else
			{
				Response.Redirect("Reciepts_Form.aspx?Action=D&BILL_NO=" + code);
			}
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				//string str1 = "select IC_NO, CASE_NO, TO_CHAR(CALL_RECV_DT,'dd/mm/yy') CALL_RECV_DT from T20_IC where CASE_NO='"+txtCaseNo.Text.Trim()+"' and CALL_RECV_DT=to_date('"+txtRdt.Text.Trim()+"','dd/mm/yyyy')"; 
				//str1=str1 + " UNION select ('null')IC_NO, CASE_NO, TO_CHAR(CALL_RECV_DT,'dd/mm/yy') CALL_RECV_DT from T17_CALL_REGISTER where CASE_NO not in (select CASE_NO From T20_IC where CASE_NO='"+txtCaseNo.Text.Trim()+"' and CALL_RECV_DT=to_date('"+txtRdt.Text.Trim()+"','dd/mm/yyyy'))";
				string str1 = "select B.BILL_NO,NVL(B.AMOUNT_RECEIVED,0)AMOUNT_RECEIVED,B.CASE_NO,R.SRNO,Decode(R.INSTRUMENT_TYPE,'C','Cheque','D','Draft','J','JV')INSTRUMENT_TYPE, to_char(R.INSTRUMENT_DATE,'dd/mm/yyyy')INSTRUMENT_DATE,R.INSTRUMENT_AMT from T22_BILL B,T24_RECEIPTS R where B.BILL_NO=R.BILL_NO";

				if (txtBillNo.Text.Trim() != "")
				{
					str1 = str1 + " and R.BILL_NO='" + txtBillNo.Text.Trim() + "'";

				}

				if (txtCsNo.Text.Trim() != "")
				{
					str1 = str1 + " and B.CASE_NO='" + txtCsNo.Text.Trim() + "'";
				}

				str1 = str1 + " order by R.BILL_NO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdR.Visible = false;
					DisplayAlert("Reciepts Not Found!!!");
					//Label4.Visible=true;
				}
				else
				{
					grdR.Visible = true;
					grdR.DataSource = dsP;
					grdR.DataBind();
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









	}
}