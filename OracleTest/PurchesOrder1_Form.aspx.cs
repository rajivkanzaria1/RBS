using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

namespace RBS
{
    public partial class PurchesOrder1_Form1 : System.Web.UI.Page
    {
		//OracleConnection conn1 = new OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnModifyPO.Attributes.Add("OnClick", "JavaScript:validate();");
			btnEditPODT.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDeletePO.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearchPO.Attributes.Add("OnClick", "JavaScript:search();");
			btnNewPO.Attributes.Add("OnClick", "JavaScript:validate1();");
			//repdiv.Visible=false;
			if (!(IsPostBack))
			{
				if (Session["Role_CD"].ToString() == "1")
				{
					btnEditPODT.Visible = true;
				}
				else if (Session["Role_CD"].ToString() == "4")
				{
					btnNewPO.Visible = false;
					btnDeletePO.Visible = false;
					btnModifyPO.Text = "View PO";
					btnEditPODT.Visible = false;
				}
				else
				{
					if (Session["Authorise"].ToString() == "N") { btnNewPO.Visible = false; }
					btnEditPODT.Visible = false;
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
			this.DgPO1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DgPO1_ItemDataBound);

		}
		#endregion

		public string match()
		{
			OracleCommand cmd = new OracleCommand("select REGION_CODE from T13_PO_MASTER where CASE_NO='" + txtCsNo.Text.Trim() + "'", conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			if (test == "\0")
			{
				test = "0";
				DisplayAlert("ENTERED CASE NUMBER DOES NOT MATCH!!!");
			}
			else if (test == Session["Region"].ToString())
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
		protected void btnNewPO_Click(object sender, System.EventArgs e)
		{
			string ptype = "";
			if (rdbRailway.Checked == true)
			{
				ptype = "R";
				string rtype = ddlRCode.SelectedValue;
				Response.Redirect("PurchesOrder_Form.aspx?PO_TYPE=" + ptype + "&RLY_CD=" + rtype);
			}
			else if (rdbPrivate.Checked == true)
			{
				ptype = "P";
				string rtype = ddlRCode.SelectedValue;
				Response.Redirect("PurchesOrder_Form.aspx?PO_TYPE=" + ptype + "&RLY_CD=" + rtype);

			}
			else if (rdbFRailway.Checked == true)
			{
				ptype = "F";
				string rtype = ddlRCode.SelectedValue;
				Response.Redirect("PurchesOrder_Form.aspx?PO_TYPE=" + ptype + "&RLY_CD=" + rtype);

			}
			else if (rdbPSU.Checked == true)
			{
				ptype = "U";
				string rtype = ddlRCode.SelectedValue;
				Response.Redirect("PurchesOrder_Form.aspx?PO_TYPE=" + ptype + "&RLY_CD=" + rtype);

			}
			else if (rdbSGovt.Checked == true)
			{
				ptype = "S";
				string rtype = ddlRCode.SelectedValue;
				Response.Redirect("PurchesOrder_Form.aspx?PO_TYPE=" + ptype + "&RLY_CD=" + rtype);

			}


		}
		protected void btnModifyPO_Click(object sender, System.EventArgs e)
		{
			string i = match();
			if (i == "2")
			{
				Response.Redirect("PurchesOrder_Form.aspx?Action=M&case_no=" + txtCsNo.Text.Trim());
			}
			//			else 
			//			{
			//				DisplayAlert("ENTERED CASE NUMBER DOES NOT MATCH!!!");
			//				//Response.Redirect(("Error_Form.aspx?err=" + er));			
			//			}
		}
		protected void btnDeletePO_Click(object sender, System.EventArgs e)
		{
			string i = match();
			if (i == "2")
			{
				Response.Redirect("PurchesOrder_Form.aspx?Action=D&case_no=" + txtCsNo.Text.Trim());
			}
			//			else 
			//			{
			//				DisplayAlert("ENTERED CASE NUMBER DOES NOT MATCH!!");
			//				//Response.Redirect(("Error_Form.aspx?err=" + er));			
			//			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		public void fill_Rly()
		{
			ddlRCode.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "";
			if (rdbRailway.Checked == true)
			{
				str1 = "select RLY_CD from T91_RAILWAYS where RLY_CD<>'CORE' Order by RLY_CD";
			}
			else if (rdbPrivate.Checked == true)
			{
				str1 = "select distinct(upper(trim(BPO_RLY))) RLY_CD from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='P' Order by RLY_CD";
			}
			else if (rdbFRailway.Checked == true)
			{
				str1 = "select distinct(upper(trim(BPO_RLY))) RLY_CD from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='F' Order by RLY_CD";
			}
			else if (rdbPSU.Checked == true)
			{
				str1 = "select distinct(upper(trim(BPO_RLY))) RLY_CD from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='U' Order by RLY_CD";
			}
			else if (rdbSGovt.Checked == true)
			{
				str1 = "select distinct(upper(trim(BPO_RLY))) RLY_CD from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='S' Order by RLY_CD";
			}
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Text = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
				lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
				ddlRCode.Items.Add(lst);
			}
		}
		protected void btnSearchPO_Click(object sender, System.EventArgs e)
		{
			try
			{
				string str1 = "select m.CASE_NO,m.PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,(decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU')||'('||m.RLY_CD||')')RLY_CD,(v.VEND_NAME||'('||NVL2(t.LOCATION,t.LOCATION||' : '||t.CITY,t.CITY)||')')VEND_NAME,(nvl2(trim(c.CONSIGNEE_DESIG),trim(c.CONSIGNEE_DESIG)||'/','')||nvl2(trim(c.CONSIGNEE_DEPT),trim(c.CONSIGNEE_DEPT)||'/','')||trim(c.CONSIGNEE_FIRM)) CONSIGNEE_S_NAME,decode(m.INSPECTING_AGENCY,'C','Consignee','X','PO Cancelled','RITES')INSPECTING_AGENCY,DECODE(PO_SOURCE,'V','VENDOR','M','MANUAL','C','IREPS','OTHER') SOURCE,TO_CHAR(PO_DT,'YYYY') PO_YR, 'CASE_NO/'||m.CASE_NO||'.TIF' PO_DOC,'CASE_NO/'||m.CASE_NO||'.PDF' PO_DOC1 from T13_PO_MASTER m,T05_VENDOR v,T06_CONSIGNEE c, T03_CITY t where m.VEND_CD=v.VEND_CD and v.VEND_CITY_CD=t.CITY_CD And m.PURCHASER_CD=c.CONSIGNEE_CD(+) and m.REGION_CODE='" + Session["Region"].ToString() + "'";

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

			//			if(Session["Region"].ToString()=="N" || Session["Region"].ToString()=="W")
			//			{
			//					
			//				DgPO1.Columns[8].Visible=true;
			//					
			//			}
			//			else
			//			{
			//				DgPO1.Columns[8].Visible=false;
			//			}
		}

		protected void rdbRailway_CheckedChanged(object sender, System.EventArgs e)
		{
			ddlRCode.Visible = true;
			fill_Rly();
			//rbs.SetFocus(ddlRCode);

		}

		protected void btnEditPODT_Click(object sender, System.EventArgs e)
		{
			string i = match();
			if (i == "2")
			{
				Response.Redirect("Edit_PO_Date.aspx?CASE_NO=" + txtCsNo.Text);
			}

		}

		private void DgPO1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string fpath = Server.MapPath("/RBS/");
			string fpath1 = Server.MapPath("/RBS/");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				fpath = fpath + Convert.ToString(e.Item.Cells[9].Text);
				fpath1 = fpath1 + Convert.ToString(e.Item.Cells[10].Text);
				if (File.Exists(fpath) == false && File.Exists(fpath1) == false)
				{
					e.Item.Cells[9].Text = "<Font Face=Verdana Color=RED>No DOC</Font>";
					DgPO1.Columns[10].Visible = false;
				}
				else if (File.Exists(fpath) == true)
				{
					e.Item.Cells[9].Text = "<a href=" + Convert.ToString(e.Item.Cells[9].Text) + ">Download PO</a>";
					DgPO1.Columns[10].Visible = false;
				}
				else if (File.Exists(fpath1) == true)
				{
					e.Item.Cells[10].Text = "<a href=" + Convert.ToString(e.Item.Cells[10].Text) + ">Download PO</a>";
					DgPO1.Columns[9].Visible = false;
				}
			}
		}
	}
}