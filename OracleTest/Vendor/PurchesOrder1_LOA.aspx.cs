using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Vendor
{
    public partial class PurchesOrder1_LOA : System.Web.UI.Page
    {
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtCsNo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtPONo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtPODate;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtVendName;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button btnModifyPO;
		protected System.Web.UI.WebControls.Button btnSearchPO;
		protected Tittle.Controls.CustomDataGrid DgPO1;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string CNO;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Convert.ToString(Request.Params["CASE_NO"]) == null)
			{
				CNO = "";


			}
			else
			{
				CNO = Convert.ToString(Request.Params["CASE_NO"].Trim());

				txtCsNo.Text = CNO;

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
			this.btnModifyPO.Click += new System.EventHandler(this.btnModifyPO_Click);
			this.btnSearchPO.Click += new System.EventHandler(this.btnSearchPO_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public string match()
		{
			OracleCommand cmd = new OracleCommand("select PO_OR_LETTER from T13_PO_MASTER where CASE_NO='" + txtCsNo.Text.Trim() + "'", conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			if (test == "P")
			{
				test = "0";
				DisplayAlert("ENTERED CASE NUMBER IS NOT A LOA CASE!!!");
			}
			else if (test == "L")
			{
				test = "2";
			}
			else
			{
				test = "1";
				DisplayAlert("You Are Not Authorised to Update/Delete Purchase Order of Other Regions!!!!!!");
			}
			conn1.Close();
			return test;
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void btnModifyPO_Click(object sender, System.EventArgs e)
		{
			string i = match();
			if (i == "2")
			{
				OracleCommand cmd = new OracleCommand("select TO_CHAR(PO_DT,'DD/MM/YYYY') PO_DATE from T13_PO_MASTER where CASE_NO='" + txtCsNo.Text.Trim() + "'", conn1);
				string po_dt = "";
				conn1.Open();
				po_dt = Convert.ToString(cmd.ExecuteScalar());
				conn1.Close();
				Response.Redirect("PurchesOrderDetails_LOA.aspx?CASE_NO=" + txtCsNo.Text.Trim() + "&type=L&PODT=" + po_dt);
			}
		}

		private void btnSearchPO_Click(object sender, System.EventArgs e)
		{
			try
			{
				string str1 = "select m.CASE_NO,m.PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,(decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU')||'('||m.RLY_CD||')')RLY_CD,(v.VEND_NAME||'('||NVL2(t.LOCATION,t.LOCATION||' : '||t.CITY,t.CITY)||')')VEND_NAME,(nvl2(trim(c.CONSIGNEE_DESIG),trim(c.CONSIGNEE_DESIG)||'/','')||nvl2(trim(c.CONSIGNEE_DEPT),trim(c.CONSIGNEE_DEPT)||'/','')||trim(c.CONSIGNEE_FIRM)) CONSIGNEE_S_NAME,decode(m.INSPECTING_AGENCY,'C','Consignee','X','PO Cancelled','RITES')INSPECTING_AGENCY,PO_SOURCE,TO_CHAR(PO_DT,'YYYY') PO_YR, 'CASE_NO/'||m.CASE_NO||'.TIF' PO_DOC,'CASE_NO/'||m.CASE_NO||'.PDF' PO_DOC1 from T13_PO_MASTER m,T05_VENDOR v,T06_CONSIGNEE c, T03_CITY t where m.VEND_CD=v.VEND_CD and v.VEND_CITY_CD=t.CITY_CD And m.PURCHASER_CD=c.CONSIGNEE_CD(+) AND PO_OR_LETTER='L' ";

				if (txtCsNo.Text.Trim() != "")
				{
					str1 = str1 + " and trim(CASE_NO)='" + txtCsNo.Text.Trim() + "'";
				}
				if (txtPONo.Text.Trim() != "")
				{
					str1 = str1 + " and upper(trim(PO_NO)) LIKE upper(trim('%" + txtPONo.Text.Trim() + "%'))";
				}
				if (txtPODate.Text != "")
				{
					str1 = str1 + " and TO_CHAR(PO_DT,'dd/mm/yyyy')='" + txtPODate.Text.Trim() + "'";
				}
				if (txtVendName.Text != "")
				{
					str1 = str1 + " and UPPER(TRIM(v.VEND_NAME)) like UPPER('" + txtVendName.Text.Trim() + "%')";
				}
				string str2 = str1 + " ORDER BY CASE_NO ASC";

				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				//OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1); 
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DgPO1.Visible = false;
					//repdiv.Visible=false;
					//Label6.Visible =true;
					DisplayAlert("PO Not Registered!!!");

				}
				else
				{
					DgPO1.DataSource = dsP1;
					DgPO1.DataBind();
					DgPO1.Visible = true;
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
			}
		}
	}
}
