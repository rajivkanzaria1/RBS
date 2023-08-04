using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Complaint_Case_Detail_Search
{
	public partial class Complaint_Case_Detail_Search : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSearchPO.Attributes.Add("OnClick", "JavaScript:search();");
			Panel_2.Visible = false;
			Panel_3.Visible = false;
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSearchPO_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "SELECT CASE_NO,PO_NO,PO_DT, RLY_CD, VEND_NAME,CONSIGNEE, BK_NO, SET_NO,IC_NO, to_char(IC_DT,'dd/mm/yyyy') IC_DATE FROM (select m.CASE_NO,m.PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,(decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU')||'('||m.RLY_CD||')')RLY_CD,(v.VEND_NAME||'('||NVL2(t.LOCATION,t.LOCATION||' : '||t.CITY,t.CITY)||')')VEND_NAME,c.CONSIGNEE, i.BK_NO, i.SET_NO,i.IC_NO, i.IC_DT from T13_PO_MASTER m,T05_VENDOR v,V06_CONSIGNEE c, T03_CITY t, T20_IC i where m.VEND_CD=v.VEND_CD and v.VEND_CITY_CD=t.CITY_CD And i.CONSIGNEE_CD=c.CONSIGNEE_CD(+) and m.CASE_NO=i.CASE_NO and upper(trim(PO_NO)) LIKE upper(trim('%" + txtPONo.Text.Trim() + "%')) and TO_CHAR(PO_DT,'dd/mm/yyyy')='" + txtPODate.Text.Trim() + "'";
				str1 = str1 + " minus select m.CASE_NO,m.PO_NO,to_char(m.PO_DT,'dd/mm/yyyy')PO_DT,(decode(m.RLY_NONRLY,'R','Railway','P','Private','S','State Government','F','Foreign Railways','U','PSU')||'('||m.RLY_CD||')')RLY_CD,(v.VEND_NAME||'('||NVL2(t.LOCATION,t.LOCATION||' : '||t.CITY,t.CITY)||')')VEND_NAME,c.CONSIGNEE, i.BK_NO, i.SET_NO,i.IC_NO, i.IC_DT from T13_PO_MASTER m,T05_VENDOR v,V06_CONSIGNEE c, T03_CITY t, T20_IC i, T40_CONSIGNEE_COMPLAINTS comp where m.VEND_CD=v.VEND_CD and v.VEND_CITY_CD=t.CITY_CD And i.CONSIGNEE_CD=c.CONSIGNEE_CD(+) and m.CASE_NO=i.CASE_NO and i.CASE_NO=comp.CASE_NO and i.BK_NO=comp.BK_NO and i.SET_NO=comp.SET_NO and upper(trim(PO_NO)) LIKE upper(trim('%" + txtPONo.Text.Trim() + "%')) and TO_CHAR(PO_DT,'dd/mm/yyyy')='" + txtPODate.Text.Trim() + "') ORDER BY CASE_NO,IC_DT,BK_NO,SET_NO ";
				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				DataSet dsP1 = new DataSet();
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DGCompMod.Visible = false;
					lblICDetails.Visible = false;
				}
				else
				{

					DgCompCaseSearch.DataSource = dsP1;
					DgCompCaseSearch.DataBind();
					DgCompCaseSearch.Visible = true;
					lblICDetails.Visible = true;


				}
				conn1.Close();

				string str2 = "Select c.COMPLAINT_ID,c.JI_SNO,c.CASE_NO,c.BK_NO,c.SET_NO,m.PO_NO, to_char(m.PO_DT,'dd/mm/yyyy') PO_DT, c.IC_NO, to_char(c.IC_DT,'dd/mm/yyyy') IC_DATE, c.REJ_MEMO_NO, to_char(c.REJ_MEMO_DT,'dd/mm/yyyy') REJ_MEMO_DATE from T13_PO_MASTER m,V40_CONSIGNEE_COMPLAINTS c where m.CASE_NO=c.CASE_NO and upper(trim(m.PO_NO)) LIKE upper(trim('%" + txtPONo.Text.Trim() + "%')) and TO_CHAR(m.PO_DT,'dd/mm/yyyy')='" + txtPODate.Text.Trim() + "' ORDER BY CASE_NO,COMPLAINT_ID ASC";
				OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
				DataSet dsP2 = new DataSet();
				OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				if (dsP2.Tables[0].Rows.Count == 0)
				{

					DGCompMod.Visible = false;
					lblCompDetails.Visible = false;


				}
				else
				{

					DGCompMod.DataSource = dsP2;
					DGCompMod.DataBind();
					DGCompMod.Visible = true;
					lblCompDetails.Visible = true;



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
			Panel_3.Visible = true;
		}

		protected void btnS1_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = true;
			lblSearchStatus.Text = "1";
		}
		protected void btnS2_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = true;
			lblSearchStatus.Text = "2";
		}

		protected void btnProceed1_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd = new OracleCommand("select CASE_NO from T20_IC where CASE_NO='" + txtCaseNo.Text.Trim() + "' and BK_NO='" + txtBkNo.Text.Trim() + "' and SET_NO='" + txtSetNo.Text.Trim() + "'", conn1);
			string cs_no = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			conn1.Dispose();
			if (cs_no != "")
			{
				Response.Redirect("complaint_Entry.aspx?CASE_NO=" + txtCaseNo.Text.Trim() + "&BK_NO=" + txtBkNo.Text.Trim() + "&SET_NO=" + txtSetNo.Text.Trim());
			}
			else
			{
				DisplayAlert("No Data Found!!!");
			}
		}

		protected void btnProceed2_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd = new OracleCommand("select CASE_NO from T40_CONSIGNEE_COMPLAINTS where COMPLAINT_ID='" + txtCompID.Text.Trim() + "'", conn1);
			string cs_no = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			conn1.Dispose();
			if (cs_no != "")
			{
				Response.Redirect("complaint_Entry.aspx?COMPLAINT_ID=" + txtCompID.Text.Trim());
			}
			else
			{
				DisplayAlert("No Data Found!!!");
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Complaint_Case_Detail_Search.aspx");
		}
	}
}