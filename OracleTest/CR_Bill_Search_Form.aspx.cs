using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.CR_Bill_Search_Form
{
	public partial class CR_Bill_Search_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string wBILLNO, wBILLDATE;
		string wFrmDt, wToDt, wRegion;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//			btnModifyIC.Attributes.Add("OnClick", "JavaScript:validate();"); 
			//			btnDeleteIC.Attributes.Add("OnClick", "JavaScript:validate();"); 
			btnSearchIC.Attributes.Add("OnClick", "JavaScript:search();");
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate1();");

			if (!IsPostBack)
			{
				if (Convert.ToString(Request.Params["BILL_NO"]) != "" && Convert.ToString(Request.Params["BILL_DT"]) != null)
				{
					txtBillNo.Text = Convert.ToString(Request.Params["BILL_NO"]);
					txtBillDate.Text = Convert.ToString(Request.Params["BILL_DT"]);
				}

				if (Session["Role_CD"].ToString() == "4")
				{
					btnAdd.Enabled = false;
					//					btnModifyIC.Enabled=false;
					//					btnDeleteIC.Enabled=false;
					grdBook.Columns[0].Visible = false;
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
		public string match()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string count = "";
			wBILLNO = Convert.ToString(txtBillNo.Text.Trim());
			wBILLDATE = Convert.ToString(txtBillDate.Text.Trim());
			try
			{
				string str1 = "Select REGION FROM T36_BILL WHERE REGION='" + Session["Region"] + "'";
				if (txtBillNo.Text.Trim() != "")
				{
					str1 = str1 + " and TRIM(BILL_NO)='" + wBILLNO + "'";
				}
				if (txtBillDate.Text.Trim() != "")
				{
					str1 = str1 + " and to_char(BILL_DT,'dd/mm/yyyy')= '" + wBILLDATE + "'";
				}
				OracleCommand cmd = new OracleCommand(str1, conn1);
				conn1.Open();
				count = Convert.ToString(cmd.ExecuteScalar());
				if (count == "\0")
				{
					count = "0";
				}
				if (count == Session["Region"].ToString())
				{
					count = "2";
				}
				else
				{
					count = "1";
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
				conn1.Dispose();
			}
			return count;
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CR_Bill_Form.aspx");
		}

		private void btnModifyIC_Click(object sender, System.EventArgs e)
		{
			//			string i=match();
			//			if(i=="2")
			//			{
			//				Response.Redirect("CR_Bill_Form.aspx?Action=M&BILL_NO="+txtBillNo.Text+"");
			//			}
			//			else if(i=="0")
			//			{
			//				DisplayAlert("No Record Found of Entered Bill Data!!!");	
			//			}
			//			else
			//			{
			//				DisplayAlert("You Are Not Authorised to Update/Delete Bill Data of other Regions!!!");
			//			}
		}

		private void btnDeleteIC_Click(object sender, System.EventArgs e)
		{
			//			string i=match();
			//			if(i=="2")
			//			{
			//				Response.Redirect("CR_Bill_Form.aspx?Action=D&BILL_NO="+txtBillNo.Text+"");
			//			}
			//			else if(i=="0")
			//			{
			//				DisplayAlert("No Record Found of Entered Bill Data!!!");	
			//			}
			//			else
			//			{
			//				DisplayAlert("You Are Not Authorised to Update/Delete Bill Data of other Regions!!!");
			//			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSearchIC_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			wBILLNO = Convert.ToString(txtBillNo.Text.Trim());
			wBILLDATE = Convert.ToString(txtBillDate.Text.Trim());
			try
			{
				string str1 = "Select BILL_NO,to_char(BILL_DT,'dd/mm/yyyy') BILL_DT,IC_NO,to_char(IC_DT,'dd/mm/yyyy') IC_DT,BILL_AMOUNT FROM T36_BILL WHERE REGION='" + Session["Region"] + "'";
				if (txtBillNo.Text.Trim() != "")
				{
					str1 = str1 + " and TRIM(BILL_NO)='" + wBILLNO + "'";
				}
				if (txtBillDate.Text.Trim() != "")
				{
					str1 = str1 + " and to_char(BILL_DT,'dd/mm/yyyy')= '" + wBILLDATE + "'";
				}
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				OracleDataReader dr;
				dr = myOracleCommand1.ExecuteReader(CommandBehavior.CloseConnection);
				if (dr.HasRows)
				{
					grdBook.DataSource = dr;
					grdBook.DataBind();
					grdBook.Visible = true;
				}
				else
				{
					grdBook.Visible = false;
					DisplayAlert("No Data Found!!!");
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
				conn1.Dispose();
			}
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{


			Panel_2.Visible = false;
			Panel_1.Visible = true;
			wToDt = toDt.Text.Trim();
			wFrmDt = frmDt.Text.Trim();
			wRegion = "";
			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }
			bill_details();
		}

		void bill_details()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string sql = "select BILL_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DATE,BPO,INSP_FEE, NVL(SERVICE_TAX,0)+NVL(EDU_CESS,0)+NVL(SHE_CESS,0) TAX,BILL_AMOUNT from T36_BILL where (BILL_DT BETWEEN to_date('" + wFrmDt + "','dd/mm/yyyy') and to_date('" + wToDt + "','dd/mm/yyyy')) and REGION='C' order by BILL_DT,BILL_NO";
			double w_total_insp_amt = 0, w_total_tax_amt = 0, w_total_bill_amt = 0;
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='7'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='7'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>Bill Details For the Period : " + wFrmDt + " to " + wToDt + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill DT</font></b></th>");
						Response.Write("<th width='45%' valign='top'><b><font size='1' face='Verdana'>BPO</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Insp Fee</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Tax (Inclusive of EDU + SHE Cess)</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Bill Amount</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_DATE"]); Response.Write("</td>");
					Response.Write("<td width='45%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["BPO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["INSP_FEE"]); Response.Write("</td>");
					w_total_insp_amt = w_total_insp_amt + Convert.ToDouble(reader["INSP_FEE"]);
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["TAX"]); Response.Write("</td>");
					w_total_tax_amt = w_total_tax_amt + Convert.ToDouble(reader["TAX"]);
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["BILL_AMOUNT"]); Response.Write("</td>");
					w_total_bill_amt = w_total_bill_amt + Convert.ToDouble(reader["BILL_AMOUNT"]);
					Response.Write("</tr>");
					ctr = ctr + 1;

				};
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='right' colspan=4> <font size='1' face='Verdana'><B>"); Response.Write("Total: "); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_insp_amt); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_tax_amt); Response.Write("</B></td>");
				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>"); Response.Write(w_total_bill_amt); Response.Write("</B></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
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

		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = false;
			Panel_2.Visible = false;
			wToDt = toDt.Text.Trim();
			wFrmDt = frmDt.Text.Trim();
			wRegion = "";

			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }
			bill_details();
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/CR_Bill_Search_Form.aspx");
		}
	}
}