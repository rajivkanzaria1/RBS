using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class Inspection_Fee_Bill_Edit : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		string BNO;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnAdd.Attributes.Add("OnClick", "JavaScript:validate();");
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnShow.Attributes.Add("OnClick", "JavaScript:validate1();");

			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["BILL_NO"]) == "")
				{
					BNO = "";

				}
				else
				{
					BNO = Convert.ToString(Request.Params["BILL_NO"]);
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
			Response.Redirect("Inspection_Fee_Bill.aspx");
		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			string code = txtBillNo.Text.Trim();
			string str1 = "select BILL_NO from T22_BILL where BILL_NO= '" + code + "'";
			OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);

			conn1.Open();
			string st = Convert.ToString(myOracleCommand1.ExecuteScalar());

			if (st == "")
			{
				DisplayAlert("Invalid Bill No.!!! ");
			}
			else
			{
				Response.Redirect("Inspection_Fee_Bill.aspx?Action=M&BILL_NO=" + code);
			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			string code = txtBillNo.Text;

			Response.Redirect("Inspection_Fee_Bill.aspx?Action=D&BILL_NO=" + code);
		}

		protected void btnShow_Click(object sender, System.EventArgs e)
		{

			//			try 
			//			{ 
			////				string str1 = "select B.BILL_NO, TO_CHAR(B.BILL_DT,'dd/mm/yy') BILL_DT,B.CASE_NO, TO_CHAR(B.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,V.VEND_NAME VEND_CD from T22_BILL B,T05_VENDOR V where B.VEND_CD=V.VEND_CD "; 
			////				if(txtBillNo.Text!="")
			////				{
			////					str1=str1+" and BILL_NO='"+txtBillNo.Text+"'";
			////				}
			////				if(txtCRDt.Text!="")
			////				{
			////					str1=str1+" and CALL_RECV_DT=to_date('"+txtCRDt.Text+"','dd/mm/yyyy')";
			////				}
			////				if(txtCNO.Text!="")
			////				{
			////					str1=str1+" and CASE_NO='"+ txtCNO.Text +"'";
			////				}
			////					
			////				str1=str1+" order by CASE_NO,BILL_NO";
			////				OracleDataAdapter da = new OracleDataAdapter(str1, conn1); 
			////				OracleCommand myOracleCommand = new OracleCommand(str1, conn1); 
			////				conn1.Open(); 
			////				da.SelectCommand = myOracleCommand; 
			////				da.Fill(dsP, "Table"); 
			////				
			////				if(dsP.Tables[0].Rows.Count ==0)
			////				{
			////					grdBill.Visible =false;
			////					Label5.Visible =true;
			////
			////				}
			////				else
			////				{
			////					grdBill.DataSource = dsP; 
			////					grdBill.DataBind(); 
			////					grdBill.Visible =true;
			////					Label5.Visible =false;
			//				}
			//
			////			conn1.Close(); 
			//			} 
			//			catch (Exception ex) 
			//			{ 
			//				string str; 
			//				str = ex.Message; 
			//				string str1=str.Replace("\n","");
			//				Response.Redirect(("Error_Form.aspx?err=" + str1));
			//			}
			//			finally
			//			{
			//				conn1.Close(); 
			//			} 
		}







	}
}
