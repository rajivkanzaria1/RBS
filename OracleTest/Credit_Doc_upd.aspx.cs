using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Credit_Doc_upd
{
	public partial class Credit_Doc_upd : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		string reg_cd = "";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate1();");

			if (Session["REGION"].ToString() == "N")
			{
				reg_cd = "O";
			}
			else if (Session["REGION"].ToString() == "S")
			{
				reg_cd = "T";
			}
			else if (Session["REGION"].ToString() == "W")
			{
				reg_cd = "X";
			}
			else if (Session["REGION"].ToString() == "E")
			{
				reg_cd = "F";
			}
			else if (Session["REGION"].ToString() == "C")
			{
				reg_cd = "D";
			}
			else if (Session["REGION"].ToString() == "Q")
			{
				reg_cd = "R";
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

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select Bill_no, to_char(bill_dt,'dd/mm/yyyy') bill_dt, case_no,invoice_no,bill_amount from t22_bill" +
							  " where bill_dt>='01-OCT-2020' " +
							  "and Invoice_no='" + txtInvoiceno.Text + "' and substr(bill_no,'1','1')='" + reg_cd + "' and substr(invoice_no,'6','1')='C' and irn_no is null ";

				OracleCommand cmd = new OracleCommand(str1, conn1);
				conn1.Open();
				OracleDataReader MyReader = cmd.ExecuteReader();
				if (MyReader.HasRows)
				{
					while (MyReader.Read())
					{
						Label6.Text = MyReader["Bill_no"].ToString();
						Label_in.Text = MyReader["bill_dt"].ToString();
						Label_id.Text = MyReader["case_no"].ToString();
						Label8.Text = MyReader["invoice_no"].ToString();
						Label_im.Text = MyReader["bill_amount"].ToString();
						Table_doc.Visible = true;
						Table_Details_Credit.Visible = true;
						Btn_upd.Visible = true;

					}
				}
				else
				{
					Table_doc.Visible = false;
					Table_Details_Credit.Visible = false;
					Btn_upd.Visible = false;
					DisplayAlert("Invoice no is not available!!!");
				}

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

		}

		protected void Btn_upd_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand myUpdateCommand = new OracleCommand();
				string myUpdateQuery1_N = "Update t22_bill set CREDIT_DOC_ID='" + Text_doc.Text.Trim() + "', BILL_DT=TO_DATE('" + txtInvoiceDt.Text + "','dd/mm/yyyy') where INVOICE_NO='" + Label8.Text.Trim() + "' and substr(bill_no,'1','1')='" + reg_cd + "' and substr(invoice_no,'6','1')='C' and irn_no is null";
				myUpdateCommand.CommandText = myUpdateQuery1_N;
				myUpdateCommand.Connection = conn1;
				myUpdateCommand.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Document No is Updated!!!");
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

	}
}