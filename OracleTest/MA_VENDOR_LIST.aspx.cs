using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.MA_VENDOR_LIST
{
	public partial class MA_VENDOR_LIST : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
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
			this.DgPO1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DgPO1_ItemDataBound_1);

		}
		#endregion

		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				string str1 = "select m.CASE_NO CASE_NO,m.PO_NO PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,m.MA_NO MA_NO,to_char(m.MA_DT,'dd/mm/yyyy')MA_DT,m.RLY_NONRLY RLY_NONRLY,(decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU')||'('||m.RLY_CD||')')RLY_CD,(decode(m.PO_OR_LETTER,'P','PO','L','Letter')) PO_OR_LETTER,d.MA_SNO MA_SNO,d.MA_FIELD MA_FIELD,d.MA_DESC MA_DESC,d.OLD_PO_VALUE OLD_PO_VALUE,d.NEW_PO_VALUE NEW_PO_VALUE,(decode(d.MA_STATUS,'P','Pending','A','Approved','R','Return')) MA_STATUS,to_char(m.MA_DT,'ddmmyyyy')MA_DTC,'VENDOR/MA/'||m.CASE_NO||'_'||m.MA_NO||'_'||to_char(m.MA_DT,'yyyymmdd')||'.PDF' MA_DOC,(decode(m.PO_SRC,'V','Vendor','C','Client')) PO_SRC from VEND_PO_MA_MASTER m,VEND_PO_MA_DETAIL d where m.Case_no=d.Case_no and m.ma_no= d.ma_no and m.ma_dt=d.ma_dt and d.ma_status='P' and substr(m.case_no,1,1)='" + Session["Region"] + "'";


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

		private void DgPO1_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string fpath = Server.MapPath("/RBS/");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				fpath = fpath + Convert.ToString(e.Item.Cells[10].Text);
				if (File.Exists(fpath) == false)
				{
					e.Item.Cells[10].Text = "<Font Face=Verdana Color=RED>No DOC</Font>";
					//DgPO1.Columns[10].Visible=false;
				}
				else
				{
					e.Item.Cells[10].Text = "<a href=" + Convert.ToString(e.Item.Cells[10].Text) + ">Download MA</a>";
					//DgPO1.Columns[10].Visible=true;
				}

			}

		}
	}
}