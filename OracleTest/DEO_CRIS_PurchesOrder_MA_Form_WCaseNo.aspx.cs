using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.DEO_CRIS_PurchesOrder_MA_Form_WCaseNo
{
	public partial class DEO_CRIS_PurchesOrder_MA_Form_WCaseNo : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected System.Web.UI.WebControls.TextBox txtHQuater;
		protected System.Web.UI.WebControls.TextBox txtRailProUnit;
		protected System.Web.UI.HtmlControls.HtmlGenericControl repdiv;
		string RLY;
		int MAKEY, SLNO;
		OracleDataAdapter da1 = new OracleDataAdapter();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!(IsPostBack))
			{




				if (Convert.ToString(Request.Params["RLY"]) == null)
				{
					fillgrid();
					Panel2.Visible = false;
					Panel1.Visible = true;

				}
				else
				{
					RLY = Convert.ToString(Request.Params["RLY"].Trim());
					MAKEY = Convert.ToInt32(Request.Params["MAKEY"].Trim());
					SLNO = Convert.ToInt32(Request.Params["SLNO"].Trim());
					show();
					Panel2.Visible = true;
					Panel1.Visible = false;
				}
				//				if(Session["Role_CD"].ToString()=="4")
				//				{
				//					
				//					DgPO1.Columns[0].Visible=false;
				//					
				//				}

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
			this.DgPO1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DgPO1_ItemDataBound);

		}
		#endregion

		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				string str1 = "select H.RITES_CASE_NO CASE_NO,H.IMMS_POKEY,H.PO_NO,to_char(H.PO_DT,'dd/mm/yyyy')PO_DT,to_char(H.PO_DT,'yyyy') PO_YR,to_char(H.RECV_DATE,'dd/mm/yyyy')RECV_DT, H.IMMS_RLY_CD, H.IMMS_RLY_SHORTNAME, NVL2(R.RLY_CD,R.RLY_CD,H.IMMS_RLY_SHORTNAME) RLY_CD,H.IMMS_VENDOR_NAME||','||H.IMMS_VENDOR_DETAIL VEND_NAME,H.REMARKS,'Vendor/PO/'||H.PO_NO||'.pdf' PO_DOC, M.MA_NO, TO_CHAR(M.MA_DATE,'DD/MM/YYYY')MA_DT, M.SUBJECT,D.MA_FLD_DESCR,D.NEW_VALUE,D.RLY,D.MAKEY,D.SLNO from IMMS_RITES_PO_HDR H, T91_RAILWAYS R,MMP_POMA_HDR M, MMP_POMA_DTL D where H.IMMS_POKEY=M.POKEY AND H.IMMS_RLY_CD=M.RLY AND M.MAKEY=D.MAKEY AND M.RLY=D.RLY AND H.IMMS_RLY_CD=R.IMMS_RLY_CD(+) and REGION_CODE IS NULL and M.MA_DATE>'31-MAR-2020' and RITES_CASE_NO is NULL AND MA_STATUS IS NULL ORDER BY M.MA_DATE DESC, H.IMMS_VENDOR_NAME||','||H.IMMS_VENDOR_DETAIL,H.RITES_CASE_NO ";


				//string str2=str1 + " ORDER BY IMMS_RLY_CD, IMMS_POKEY";

				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				//OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1); 
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgPO1.Visible = false;
					//repdiv.Visible=false;
					//Label6.Visible =true;
					//						throw new System.Exception("No PurchaseOrder found. !!! ");
					lblError.Visible = true;
					DgPO1.Visible = false;

				}
				else
				{
					DgPO1.DataSource = dsP1;
					DgPO1.DataBind();
					DgPO1.Visible = true;
					lblError.Visible = false;
					//repdiv.Visible=true;
					//Label6.Visible =false;
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



		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				string str3 = "select H.RITES_CASE_NO CASE_NO,H.IMMS_POKEY,H.PO_NO,to_char(H.PO_DT,'dd/mm/yyyy')PO_DT,to_char(H.PO_DT,'yyyy') PO_YR,to_char(H.RECV_DATE,'dd/mm/yyyy')RECV_DT, H.IMMS_RLY_CD, H.IMMS_RLY_SHORTNAME, NVL2(R.RLY_CD,R.RLY_CD,H.IMMS_RLY_SHORTNAME) RLY_CD,H.IMMS_VENDOR_NAME||','||H.IMMS_VENDOR_DETAIL VEND_NAME,H.REMARKS,'Vendor/PO/'||H.PO_NO||'.pdf' PO_DOC, M.MA_NO, TO_CHAR(M.MA_DATE,'DD/MM/YYYY')MA_DT, M.SUBJECT,D.MA_FLD_DESCR,D.NEW_VALUE,D.OLD_VALUE from IMMS_RITES_PO_HDR H, T91_RAILWAYS R,MMP_POMA_HDR M, MMP_POMA_DTL D where H.IMMS_POKEY=M.POKEY AND H.IMMS_RLY_CD=M.RLY AND M.MAKEY=D.MAKEY AND M.RLY=D.RLY AND H.IMMS_RLY_CD=R.IMMS_RLY_CD(+) and D.RLY='" + RLY + "' and D.MAKEY=" + MAKEY + " AND D.SLNO=" + SLNO;

				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader = myOracleCommand3.ExecuteReader();
				while (reader.Read())
				{
					//txtCaseNo.Text=reader["CASE_NO"].ToString();
					lblPONO.Text = reader["PO_NO"].ToString();
					lblPODT.Text = reader["PO_DT"].ToString();
					lblVend.Text = reader["VEND_NAME"].ToString();
					lblMANo.Text = reader["MA_NO"].ToString();
					lblMADT.Text = reader["MA_DT"].ToString();
					lblMASubject.Text = reader["SUBJECT"].ToString();
					lblMAField.Text = reader["MA_FLD_DESCR"].ToString();
					lblMANewVal.Text = reader["NEW_VALUE"].ToString();
					lblMAOldVal.Text = reader["OLD_VALUE"].ToString();
					HyperLink1.NavigateUrl = "https://www.ireps.gov.in/ireps/etender/pdfdocs/MMIS/PO/" + reader["PO_YR"].ToString() + "/" + reader["IMMS_RLY_CD"].ToString() + "/" + reader["PO_NO"].ToString() + "_" + reader["MA_NO"].ToString() + ".pdf";
				}
				reader.Close();
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

		private void DgPO1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			//			string fpath=Server.MapPath("/RBS/");
			//			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			//			{
			//					fpath=fpath+Convert.ToString(e.Item.Cells[11].Text);
			//				if (File.Exists(fpath)==false) 
			//				{
			//					e.Item.Cells[11].Text="<Font Face=Verdana Color=RED>No PO</Font>";
			//				}
			//				else
			//				{
			//					e.Item.Cells[11].Text="<a href="+Convert.ToString(e.Item.Cells[11].Text)+">Download PO</a>";
			//				}
			//			}			

		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			RLY = Convert.ToString(Request.Params["RLY"].Trim());
			MAKEY = Convert.ToInt32(Request.Params["MAKEY"].Trim());
			SLNO = Convert.ToInt32(Request.Params["SLNO"].Trim());
		OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{

				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				cmd2.Transaction = myTrans;
				string ss = Convert.ToString(cmd2.ExecuteScalar());

				string updateQuery = "Update MMP_POMA_DTL set MA_STATUS='" + lstStatus.SelectedValue + "',APPROVED_BY='" + Session["UName"] + "', APPROVED_DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where RLY='" + RLY + "' and MAKEY=" + MAKEY + " and SLNO=" + SLNO;
				OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn1);
				myUpdateCommand.Transaction = myTrans;

				myUpdateCommand.ExecuteNonQuery();

				myTrans.Commit();
				conn1.Close();


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				myTrans.Rollback();
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
			Panel1.Visible = true;
			Panel2.Visible = false;
			fillgrid();
		}






	}
}