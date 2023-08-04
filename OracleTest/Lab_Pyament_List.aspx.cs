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

namespace RBS.Lab_Pyament_List
{
	public partial class Lab_Pyament_List : System.Web.UI.Page
	{

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
			this.DgPO1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DgPO1_ItemCommand);
			this.DgPO1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DgPO1_ItemDataBound);

		}
		#endregion
		void fillgrid()
		{
			OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				string str1 = "select t110.case_no case_no, to_char(t110.call_recv_dt,'dd/mm/yyyy') call_recv_dt,t110.call_sno call_sno, NVL(t109.testing_charges,'') testing_charges_lab, t110.testing_charges testing_charges_vend,t110.TDS,(NVL(t110.testing_charges,0)+NVL(t110.TDS,0)) GROSS_VENDOR, V.VENDOR VENDOR, M.VENDOR MFG," +
							"to_char(t110.call_recv_dt,'ddmmyyyy') C_LDT,(decode(t110.doc_status_fin,'P','Pending')) doc_status_fin,'LAB/PReciept/'||t110.CASE_NO||'_'||t110.CALL_SNO||'_'||to_char(t110.call_recv_dt,'yyyymmdd')||'.PDF' RE_DOC " +
							"from t110_lab_doc t110, t109_lab_sample_info t109, t13_po_master t13, t17_call_register t17, V05_VENDOR V, V05_VENDOR M where t110.CASE_NO=t13.CASE_NO and t110.case_no= t17.case_no and t110.call_recv_dt= t17.call_recv_dt and t110.call_sno= t17.call_sno and t13.VEND_CD=V.VEND_CD and t17.MFG_CD=M.VEND_CD and t110.case_no= t109.case_no(+) and t110.call_recv_dt= t109.call_recv_dt(+) and t110.call_sno= t109.call_sno(+) and t110.doc_status_fin='P' and substr(t110.case_no,1,1)='" + Session["Region"] + "'";


				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgPO1.Visible = false;
					lblError.Visible = true;
					DgPO1.Visible = false;

				}
				else
				{
					DgPO1.DataSource = dsP1;
					DgPO1.DataBind();
					DgPO1.Visible = true;
					lblError.Visible = false;
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

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		private void DgPO1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

		}

		private void DgPO1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string fpath = Server.MapPath("/RBS/");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				fpath = fpath + Convert.ToString(e.Item.Cells[8].Text);
				if (File.Exists(fpath) == false)
				{
					e.Item.Cells[8].Text = "<Font Face=Verdana Color=RED>No Reciept</Font>";
				}
				else
				{
					e.Item.Cells[8].Text = "<a href=" + Convert.ToString(e.Item.Cells[8].Text) + ">Download Reciept</a>";
				}

			}
		}
	}
}