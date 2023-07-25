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
    public partial class Search_Form : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		//	string CNO,DT;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.Button btnSearch1;
		int ecode;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate();");
			btnFC_List.Attributes.Add("OnClick", "JavaScript:validate1(txtBPO);");
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1(txtVend);");
			btnSCon.Attributes.Add("OnClick", "JavaScript:validate1(txtSCon);");

			if (!(IsPostBack))
			{
				DataSet dsP1 = new DataSet();
				string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				ListItem lst3;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
				{
					lst3 = new ListItem();
					lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString();
					lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString();
					lstIE.Items.Add(lst3);
				}
				lstIE.Items.Insert(0, "");
				conn1.Close();

				//				DataSet dsP = new DataSet();
				//				string str2;
				//				str2="Select C.CONSIGNEE_CD,(nvl2(trim(C.CONSIGNEE_DESIG),trim(C.CONSIGNEE_DESIG)||'/','')||nvl2(trim(C.CONSIGNEE_DEPT),trim(C.CONSIGNEE_DEPT)||'/','')||nvl2(trim(C.CONSIGNEE_FIRM),trim(C.CONSIGNEE_FIRM)||'/','')||D.CITY) CONSIGNEE_NAME from t06_consignee C,T03_CITY D where C.CONSIGNEE_CITY=D.CITY_CD";
				//				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1); 
				//				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1); 
				//				ListItem lst; 
				//				conn1.Open();
				//				da1.SelectCommand = myOracleCommand1; 
				//				da1.Fill(dsP, "Table"); 
				//				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++) 
				//				{ 
				//					lst = new ListItem(); 
				//					lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString(); 
				//					lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
				//					lstConsignee.Items.Add(lst); 
				//				}
				//				lstConsignee.Items.Insert(0,"");
				//				conn1.Close();


			}

		}
		protected void btnFC_List_Click(object sender, System.EventArgs e)
		{
			try
			{

				lstBPO.Visible = true;
				int a = fill_BPO(txtBPO.Text);
				if (a == 1)
				{
					lstBPO.Visible = false;
					DisplayAlert("No BPO Found!!!");
					rbs.SetFocus(txtBPO);
				}
				else
				{
					rbs.SetFocus(lstBPO);
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str2);

			}
			finally
			{
				conn1.Close();
			}
		}

		protected void lstBPO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtBPO.Text = lstBPO.SelectedValue;
			//rbs.SetFocus(txtNarrat);
		}
		int fill_BPO(string bpo)
		{
			lstBPO.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "";

			str1 = "select BPO_CD,(BPO_CD||'-'||BPO_NAME||'/'||BPO_ADD||'/'||BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER where (trim(upper(BPO_CD))=upper('" + txtBPO.Text.Trim() + "') or trim(upper(BPO_NAME)) LIKE upper('" + txtBPO.Text.Trim() + "%')) ORDER BY BPO_NAME";

			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				ecode = 1;
				return (ecode);
				//DisplayAlert("Invalid Search Data");
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["BPO_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["BPO_CD"].ToString();
					lstBPO.Items.Add(lst);
				}

				lstBPO.Visible = true;
				lstBPO.SelectedIndex = 0;
				txtBPO.Text = lstBPO.SelectedValue;
				ecode = 2;
				return (ecode);

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



		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		private void txtSearch_Click(object sender, System.EventArgs e)
		{
			//string str1 = "select C.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT from T17_CALL_REGISTER C, T13_PO_MASTER P where C.CASE_NO=P.CASE_NO "; 


		}

		protected void btnFCList_Click(object sender, System.EventArgs e)
		{
			ddlVender.Visible = true;

			try
			{
				if (Convert.ToInt32(txtVend.Text) >= 1 && Convert.ToInt32(txtVend.Text) <= 999999)
				{

					string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + txtVend.Text.Trim() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_vendor(str1);
					if (a == 1)
					{
						ddlVender.Visible = false;
						DisplayAlert("No Vendor Found!!!");
						rbs.SetFocus(txtVend);
					}
					else if (a == 2)
					{
						rbs.SetFocus(ddlVender);
					}
				}
				else
				{
					DisplayAlert("Invalid Vendor Code!!!");
					ddlVender.Items.Clear();
					ddlVender.Visible = false;
				}


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "Input string was not in a correct format.";
				if (str.Equals(str1))
				{
					string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(upper(VEND_NAME)) LIKE upper('" + txtVend.Text.Trim() + "%') and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_vendor(str2);
					if (a == 1)
					{
						ddlVender.Visible = false;
						DisplayAlert("No Vendor Found!!!");
						rbs.SetFocus(txtVend);
					}
					else if (a == 2)
					{

						rbs.SetFocus(ddlVender);

					}
				}
				else
				{
					string str2 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str2);
				}

			}
			finally
			{
				conn1.Close();
			}
		}



		int fill_vendor(string str1)
		{
			ddlVender.Items.Clear();
			DataSet dsP = new DataSet();
			//string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and (trim(upper(VEND_CD))=upper('"+vend.Trim()+"') or trim(upper(VEND_NAME)) LIKE upper('"+vend.Trim()+"%')) and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME"; 
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				ecode = 1;
				return (ecode);
				//DisplayAlert("Invalid Search Data");
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["VEND_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["VEND_CD"].ToString();
					ddlVender.Items.Add(lst);
				}

				ddlVender.Visible = true;
				ddlVender.SelectedIndex = 0;
				txtVend.Text = ddlVender.SelectedValue;
				//rbs.SetFocus(ddlVender);
				ecode = 2;
				return (ecode);

			}
		}
		private void grdCNO_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		protected void ddlVender_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtVend.Text = ddlVender.SelectedValue;
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{

			string str1 = "select T13.CASE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DT, T14.Consignee_CD, T14.BPO_CD, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT, T17.CALL_SNO,T20.BK_NO,T20.SET_NO,T22.BILL_NO,to_char(T22.BILL_DT,'dd/mm/yyyy')BILL_DT, T09.IE_SNAME,V06.CONSIGNEE_CD||'-'||V06.CONSIGNEE CONSIGNEE, T22.INSP_FEE, T22.BILL_AMOUNT from T13_PO_MASTER T13, T14_PO_BPO T14, T17_CALL_REGISTER T17, T20_IC T20, T22_BILL T22, T09_IE T09, V06_CONSIGNEE V06 where T13.CASE_NO=T14.CASE_NO and T13.CASE_NO=T17.CASE_NO and T17.CASE_NO = T20.CASE_NO and T17.CALL_RECV_DT=T20.CALL_RECV_DT and T17.CALL_SNO=T20.CALL_SNO and T14.CONSIGNEE_CD = T20.CONSIGNEE_CD and T20.BILL_NO=T22.BILL_NO and T20.IE_CD=T09.IE_CD and T20.CONSIGNEE_CD=V06.CONSIGNEE_CD ";
			if (txtCaseNo.Text.Trim() != "")
			{
				str1 = str1 + " and T13.CASE_NO='" + txtCaseNo.Text.Trim() + "'";
			}


			if (txtPONO.Text.Trim() != "")
			{
				str1 = str1 + "  and upper(T13.PO_NO) LIKE upper('%" + txtPONO.Text.Trim() + "%')";
			}

			if (txtPODT.Text.Trim() != "")
			{
				str1 = str1 + "  and T13.PO_DT=to_date('" + txtPODT.Text.Trim() + "','dd/mm/yyyy')";
			}


			if (lstConsignee.SelectedValue != "")
			{

				str1 = str1 + "  and T14.CONSIGNEE_CD=" + lstConsignee.SelectedValue + "";
			}
			if (lstBPO.SelectedValue != "")
			{

				str1 = str1 + "  and T14.BPO_CD=" + lstBPO.SelectedValue + "";
			}
			if (ddlVender.SelectedValue != "")
			{

				str1 = str1 + "  and T13.VEND_CD=" + ddlVender.SelectedValue + "";
			}
			if (txtDtOfReciept.Text.Trim() != "")
			{

				str1 = str1 + "  and T17.CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')";
			}
			if (txtCSNO.Text.Trim() != "")
			{

				str1 = str1 + "  and T17.CALL_SNO='" + txtCSNO.Text.Trim() + "'";
			}
			if (lstIE.SelectedValue != "")
			{

				str1 = str1 + "  and T17.IE_CD=" + lstIE.SelectedValue + "";
			}
			if (txtBKNo.Text.Trim() != "")
			{

				str1 = str1 + "  and T20.BK_NO='" + txtBKNo.Text.Trim() + "'";
			}
			if (txtSetNo.Text.Trim() != "")
			{

				str1 = str1 + "  and T20.SET_NO='" + txtSetNo.Text.Trim() + "'";
			}
			if (txtBNO.Text.Trim() != "")
			{

				str1 = str1 + "  and T22.BILL_NO='" + txtBNO.Text.Trim() + "'";
			}
			if (txtBDT.Text.Trim() != "")
			{

				str1 = str1 + "  and to_char(T22.BILL_DT,'dd/mm/yyyy')='" + txtBDT.Text.Trim() + "'";
			}

			if (txtBAMT.Text.Trim() != "")
			{

				str1 = str1 + "  and T22.BILL_AMOUNT='" + txtBAMT.Text.Trim() + "'";
			}

			str1 = str1 + "and T13.REGION_CODE='" + Session["Region"] + "' order by T13.CASE_NO,T17.CALL_RECV_DT";
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				grdCNO.Visible = false;
				//Label4.Visible=true;
				DisplayAlert("No Data Found!!!");
			}
			else
			{
				grdCNO.DataSource = dsP;
				//int rr=Convert.ToInt32(dsP.Tables[0].Rows.Count)*30 + 50 ;
				//grdCNO.Height=rr;
				grdCNO.DataBind();
				grdCNO.Visible = true;

			}
		}

		protected void btnSCon_Click(object sender, System.EventArgs e)
		{
			lstConsignee.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "Select CONSIGNEE_CD, (CONSIGNEE_CD||'-'||CONSIGNEE) CONSIGNEE from V06_CONSIGNEE where upper(trim(CONSIGNEE)) like trim(upper('" + txtSCon.Text.Trim() + "%')) order by V06_CONSIGNEE.CONSIGNEE";
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("No Consignee Found!!!");
				//ddlConsigneeCD.Visible=false;
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["CONSIGNEE"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["CONSIGNEE_CD"].ToString();
					lstConsignee.Items.Add(lst);
				}
				lstConsignee.Visible = true;
				lstConsignee.SelectedIndex = 0;
				txtSCon.Text = lstConsignee.SelectedValue;
				//rbs.SetFocus(ddlVender);
			}



		}

		protected void lstConsignee_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtSCon.Text = lstConsignee.SelectedValue;
		}
	}
}
