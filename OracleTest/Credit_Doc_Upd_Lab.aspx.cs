using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Credit_Doc_Upd_Lab
{
	public partial class Credit_Doc_Upd_Lab : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


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

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select Invoice_no, to_char(invoice_dt, 'dd/mm/yyyy') invoice_dt, case_no," +
							  "(Bill_amount+total_cgst+total_igst+total_cgst) Total_amt from t55_lab_invoice " +
							  "where region_code='" + Session["REGION"].ToString() + "' and inc_type='C' and irn_no is null and Invoice_no='" + txtInvoiceno.Text + "'";

				OracleCommand cmd = new OracleCommand(str1, conn1);
				conn1.Open();
				OracleDataReader MyReader = cmd.ExecuteReader();
				if (MyReader.HasRows)
				{
					while (MyReader.Read())
					{
						Label_id.Text = MyReader["case_no"].ToString();
						Label8.Text = MyReader["Invoice_no"].ToString();
						Label_im.Text = MyReader["Total_amt"].ToString();
						Label_in.Text = MyReader["invoice_dt"].ToString();
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void Btn_upd_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand myUpdateCommand = new OracleCommand();
				string myUpdateQuery1_N = "Update t55_lab_invoice set CREDIT_ID='" + Text_doc.Text.Trim() + "', INVOICE_DT=to_date('" + txtInvoiceDt.Text + "','DD/MM/YYYY') where INVOICE_NO='" + Label8.Text.Trim() + "' and INC_TYPE='C' and region_code='" + Session["REGION"].ToString() + "' and irn_no is null";
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
	}
}