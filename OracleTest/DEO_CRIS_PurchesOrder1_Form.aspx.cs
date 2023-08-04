using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.DEO_CRIS_PurchesOrder1_Form
{
	public partial class DEO_CRIS_PurchesOrder1_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected System.Web.UI.WebControls.TextBox txtHQuater;
		protected System.Web.UI.WebControls.TextBox txtRailProUnit;
		protected System.Web.UI.HtmlControls.HtmlGenericControl repdiv;

		OracleDataAdapter da1 = new OracleDataAdapter();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!(IsPostBack))
			{
				fillgrid();
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
				string str1 = "select RITES_CASE_NO CASE_NO,IMMS_POKEY,PO_NO,to_char(PO_DT,'dd/mm/yyyy')PO_DT,to_char(RECV_DATE,'dd/mm/yyyy')RECV_DT, H.IMMS_RLY_CD, H.IMMS_RLY_SHORTNAME, NVL2(R.RLY_CD,R.RLY_CD,H.IMMS_RLY_SHORTNAME) RLY_CD, IMMS_VENDOR_NAME||','||IMMS_VENDOR_DETAIL VEND_NAME,REMARKS,'Vendor/PO/'||PO_NO||'.pdf' PO_DOC, IMMS_POI_NAME||'/'||IMMS_POI_DETAIL POI, DECODE(REGION_CODE,'N','NORTHERN','S','SOUTHERN','E','EASTERN','W','WESTERN','C','CENTRAL','NA') REGION, REGION_CODE from IMMS_RITES_PO_HDR H, T91_RAILWAYS R where H.IMMS_RLY_CD=R.IMMS_RLY_CD(+) and (REGION_CODE='" + Session["Region"].ToString() + "' OR REGION_CODE IS NULL) and PO_DT>'31-MAR-2021' and RITES_CASE_NO is null ORDER BY REGION_CODE DESC, H.PO_DT DESC";


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






	}
}