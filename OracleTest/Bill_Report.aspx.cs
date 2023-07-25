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

namespace RBS
{
    public partial class Bill_Report : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		int ecode = 0;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnPrint.Attributes.Add("OnClick", "JavaScript:validate();");
			btnView.Attributes.Add("OnClick", "JavaScript:validate();");
			btnPrintBill_No.Attributes.Add("OnClick", "JavaScript:validate();");
			if (!(IsPostBack))
			{
				ListItem lst = new ListItem();
				lst.Text = "Railways";
				lst.Value = "R";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Private";
				lst.Value = "P";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "PSU";
				lst.Value = "U";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "State Govt.";
				lst.Value = "S";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Foreign Railways";
				lst.Value = "F";

				ListItem lst1 = new ListItem();
				lst1.Text = "All Bills";
				lst1.Value = "A";
				lstBillType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Updated Bills";
				lst1.Value = "U";
				lstBillType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Only New Bills";
				lst1.Value = "N";
				lstBillType.Items.Add(lst1);


				lblFrom.Visible = false;
				lblTo.Visible = false;
				txtBillFr.Visible = false;
				txtBillTo.Visible = false;
				frmDt.Visible = false;
				toDt.Visible = false;
				txtBPO.Visible = false;
				btnFC_List.Visible = false;
				lstBPO.Visible = false;
				rdbBPO.Visible = false;
				Label6.Visible = false;
				lstBillType.Visible = false;
				lblBtype.Visible = false;

				if (Session["Role_CD"].ToString() == "1" || Session["Role_CD"].ToString() == "2")
				{
					btnPrint.Visible = true;
				}
				else
				{
					btnPrint.Visible = false;
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
		void fill_bpo_rly()
		{
			try
			{
				lstBPO1.Items.Clear();
				DataSet dsP = new DataSet();
				string str1 = "Select DISTINCT(BPO_RLY) from T12_BILL_PAYING_OFFICER where BPO_TYPE='" + lstClientType.SelectedValue + "' order by BPO_RLY";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("Invalid Search Data");
				}
				else
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["BPO_RLY"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["BPO_RLY"].ToString();
						lstBPO1.Items.Add(lst);
					}
					lstBPO1.Visible = true;
					lstBPO1.SelectedIndex = 0;
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
		//void showrep(string formula, string str)
		//{
		//	CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = null;
		//	if (Session["Region"].ToString() == "N")
		//	{
		//		rpt = new NR_Bill();
		//	}
		//	else if (Session["Region"].ToString() == "S")
		//	{
		//		rpt = new SR_Bill();
		//	}
		//	else
		//	{
		//		rpt = new Bill();
		//	}
		//	MyPannel.Visible = false;
		//	MemoryStream oStream = new MemoryStream();
		//	//rpt.RecordSelectionFormula = "{V22_BILL.BILL_NO} >='" + txtBillFr.Text + "' and {V22_BILL.BILL_NO} <='" + txtBillTo.Text + "'";
		//	rpt.RecordSelectionFormula = formula;
		//	CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();
		//	rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.NoDestination;
		//	rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
		//	rpt.SetDataSource("qa");
		//	rpt.SetDatabaseLogon("qa", "qa");
		//	oStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
		//	Response.Clear();
		//	Response.Buffer = true;
		//	Response.ContentType = "application/doc";
		//	try
		//	{
		//		Response.BinaryWrite(oStream.ToArray());
		//		Response.End();
		//	}
		//	catch (Exception err)
		//	{
		//		OracleCommand myUpdateCommand = new OracleCommand(str);
		//		myUpdateCommand.Connection = conn1;
		//		conn1.Open();
		//		myUpdateCommand.ExecuteNonQuery();
		//		conn1.Close();
		//		Response.Write("< BR >");
		//		Response.Write(err.Message.ToString());
		//	}
		//}

		//void showrep1(string formula)
		//{
		//	CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = null;
		//	if (rdbBefore.Checked == true)
		//	{
		//		if (Session["Region"].ToString() == "N")
		//		{
		//			rpt = new NR_Bill();

		//		}
		//		else if (Session["Region"].ToString() == "S")
		//		{
		//			rpt = new SR_Bill();
		//		}
		//		else
		//		{
		//			rpt = new Bill();
		//		}
		//	}
		//	else
		//	{
		//		if (Session["Region"].ToString() == "N")
		//		{
		//			rpt = new NR_Bill_GST();

		//		}
		//		else if (Session["Region"].ToString() == "S")
		//		{
		//			rpt = new SR_Bill_GST();
		//		}
		//		else
		//		{
		//			rpt = new Bill_GST();
		//		}

		//	}

		//	MyPannel.Visible = false;
		//	MemoryStream oStream = new MemoryStream();
		//	//rpt.RecordSelectionFormula = "{V22_BILL.BILL_NO} >='" + txtBillFr.Text + "' and {V22_BILL.BILL_NO} <='" + txtBillTo.Text + "'";
		//	rpt.RecordSelectionFormula = formula;
		//	CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();
		//	rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.NoDestination;
		//	rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
		//	rpt.SetDataSource("qa");
		//	rpt.SetDatabaseLogon("qa", "qa");
		//	oStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
		//	Response.Clear();
		//	Response.Buffer = true;
		//	Response.ContentType = "application/doc";
		//	try
		//	{
		//		Response.BinaryWrite(oStream.ToArray());
		//		Response.End();
		//	}
		//	catch (Exception err)
		//	{
		//		Response.Write("< BR >");
		//		Response.Write(err.Message.ToString());

		//	}

		//}

		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			string formula = "", str = "";
			if (rdbBNO.Checked == true)
			{
				if (txtBillTo.Text.Trim() == "")
				{
					txtBillTo.Text = txtBillFr.Text;
				}
				str = "update T22_BILL set BILL_STATUS='P' where BILL_NO >='" + txtBillFr.Text + "' and BILL_NO <='" + txtBillTo.Text + "' and substr(BILL_NO,1,1)='" + Session["Region"] + "'";
				formula = "{V22_BILL.BILL_NO} >='" + txtBillFr.Text + "' and {V22_BILL.BILL_NO} <='" + txtBillTo.Text + "' and {V22_BILL.REGION_CODE}='" + Session["Region"] + "'";
				if (rdbBPO.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_CD} ='" + txtBPO.Text + "'";

				}
			}
			else if (rdbPER.Checked == true)
			{
				string from = "", to = "";
				if (frmDt.Text.Trim() == "")
				{
					from = "01/01/1900";
					to = toDt.Text.Trim();
				}
				else if (toDt.Text.Trim() == "")
				{
					to = "31/12/2100";
					from = frmDt.Text.Trim();
				}
				else
				{
					to = toDt.Text.Trim();
					from = frmDt.Text.Trim();
				}

				if (rdbRLY.Checked == true)
				{
					str = "update T22_BILL T22 set BILL_STATUS='P' where BILL_NO IN (SELECT BILL_NO FROM V22_BILL WHERE BILL_DT between to_date('" + from + "','dd/mm/yyyy') and to_date('" + to + "','dd/mm/yyyy') and REGION_CODE='" + Session["Region"] + "' AND BPO_TYPE='R' and (BPO_RLY IN ('RCF','ICF','RWF') OR PO_LETTER='L') ) ";

				}
				else if (rdbNonRly.Checked == true)
				{
					str = "update T22_BILL T22 set BILL_STATUS='P' where BILL_NO IN (SELECT BILL_NO FROM V22_BILL WHERE BILL_DT between to_date('" + from + "','dd/mm/yyyy') and to_date('" + to + "','dd/mm/yyyy') and REGION_CODE='" + Session["Region"] + "' AND BPO_TYPE<>'R') ";
				}
				else
				{
					str = "update T22_BILL set BILL_STATUS='P' where T22_BILL.BILL_DT between to_date('" + from + "','dd/mm/yyyy') and to_date('" + to + "','dd/mm/yyyy') and substr(BILL_NO,1,1)='" + Session["Region"] + "'";
				}
				from = dateconcate(from);
				to = dateconcate(to);
				formula = "ToText({V22_BILL.BILL_DT},'yyyyMMdd')>='" + from + "' and ToText({V22_BILL.BILL_DT},'yyyyMMdd')<='" + to + "' and {V22_BILL.REGION_CODE}='" + Session["Region"] + "'";



				if (lstBillType.SelectedValue == "N")
				{
					formula = formula + " and IsNull({V22_BILL.BILL_STATUS})";
					str = str + " and BILL_STATUS IS NULL";
				}
				else if (lstBillType.SelectedValue == "U")
				{
					formula = formula + " and {V22_BILL.BILL_STATUS}='U'";
					str = str + " and BILL_STATUS='U'";
				}
				if (rdbBPO.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_CD} ='" + txtBPO.Text + "'";
				}
				if (rdbRLY.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_TYPE}='R' AND ({V22_BILL.BPO_RLY} ='ICF' OR {V22_BILL.BPO_RLY} ='RCF' OR {V22_BILL.BPO_RLY} ='RWF' OR {V22_BILL.PO_OR_LETTER}='L')";

				}
				if (rdbNonRly.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_TYPE} <>'R'";
				}
			}
			//showrep(formula, str);
			//			OracleCommand myUpdateCommand = new OracleCommand(str); 
			//			myUpdateCommand.Connection = conn1; 
			//			conn1.Open();
			//			myUpdateCommand.ExecuteNonQuery(); 
			//			conn1.Close(); 


		}
		string dateconcate(string dt)
		{
			string myYear, myMonth, myDay;

			myYear = dt.Substring(6, 4);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;
			return (dt1);
		}
		int fill_BPO(string bpo)
		{
			lstBPO.Items.Clear();
			DataSet dsP = new DataSet();
			string str1 = "";

			str1 = "select BPO_CD,(BPO_NAME||'/'||BPO_ADD||'/'||BPO_RLY) BPO_NAME from T12_BILL_PAYING_OFFICER where (trim(upper(BPO_CD))=upper('" + txtBPO.Text.Trim() + "') or trim(upper(BPO_NAME)) LIKE upper('" + txtBPO.Text.Trim() + "%')) ORDER BY BPO_NAME";

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
		private void btnFC_List_Click(object sender, System.EventArgs e)
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void lstBPO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtBPO.Text = lstBPO.SelectedValue;
		}
		void rdg1change()
		{
			if (rdbBNO.Checked == true)
			{
				lblFrom.Visible = true;
				lblTo.Visible = true;
				txtBillFr.Visible = true;
				txtBillTo.Visible = true;
				frmDt.Visible = false;
				toDt.Visible = false;
				lstBillType.Visible = false;
				lblBtype.Visible = false;
				rdbRLY.Visible = false;
				rdbNonRly.Visible = false;
				rdbAll.Visible = false;

			}
			else if (rdbPER.Checked == true)
			{
				lblFrom.Visible = true;
				lblTo.Visible = true;
				txtBillFr.Visible = false;
				txtBillTo.Visible = false;
				frmDt.Visible = true;
				toDt.Visible = true;
				lstBillType.Visible = true;
				lblBtype.Visible = true;
				rdbRLY.Visible = true;
				rdbNonRly.Visible = true;
				rdbAll.Visible = true;

			}
			else
			{

				lblFrom.Visible = false;
				lblTo.Visible = false;
				frmDt.Visible = false;
				toDt.Visible = false;
				txtBillFr.Visible = false;
				txtBillTo.Visible = false;
				lstBillType.Visible = false;
				lblBtype.Visible = false;
				rdbAll.Visible = false;

			}
		}
		protected void rdbBNO_CheckedChanged(object sender, System.EventArgs e)
		{
			rdg1change();
		}

		protected void rdbPER_CheckedChanged(object sender, System.EventArgs e)
		{
			rdg1change();
			rdbPClient.Visible = true;
		}

		protected void rdbBPO_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbBPO.Checked == true)
			{
				txtBPO.Visible = true;
				btnFC_List.Visible = true;
				lstBPO.Visible = false;
			}


		}

		protected void btnView_Click(object sender, System.EventArgs e)
		{
			string formula = "";
			if (rdbBNO.Checked == true)
			{
				if (txtBillTo.Text.Trim() == "")
				{
					txtBillTo.Text = txtBillFr.Text;
				}
				//str="update T22_BILL set BILL_STATUS='P' where BILL_NO >='"+txtBillFr.Text +"' and BILL_NO <='"+txtBillTo.Text+"' and substr(BILL_NO,1,1)='"+Session["Region"]+"'";
				formula = "{V22_BILL.BILL_NO} >='" + txtBillFr.Text + "' and {V22_BILL.BILL_NO} <='" + txtBillTo.Text + "' and {V22_BILL.REGION_CODE}='" + Session["Region"] + "'";
				//				formula=formula+" and ({V22_BILL.BPO_RLY} <> 'RCF' and {V22_BILL.BPO_RLY} <> 'RE' and {V22_BILL.BPO_RLY} <> 'NR' and {V22_BILL.BPO_RLY} <> 'ICF' and {V22_BILL.BPO_RLY} <> 'BIS' and {V22_BILL.BPO_RLY} <> 'JVVNL' and {V22_BILL.BPO_RLY} <> 'NER')";
				if (rdbBPO.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_CD} ='" + txtBPO.Text + "'";

				}

				if (rdbPar_User.Checked == true)
				{
					formula = formula + " and Trim({V22_BILL.USER_ID}) ='" + lstUID.SelectedItem.Text.ToString().Trim() + "'";
				}

			}

			else if (rdbPER.Checked == true)
			{
				string from = "", to = "";
				if (frmDt.Text.Trim() == "")
				{
					from = "01/01/1900";
					to = toDt.Text.Trim();
				}
				else if (toDt.Text.Trim() == "")
				{
					to = "31/12/2100";
					from = frmDt.Text.Trim();
				}
				else
				{
					to = toDt.Text.Trim();
					from = frmDt.Text.Trim();
				}
				//str="update T22_BILL set BILL_STATUS='P' where T22_BILL.BILL_DT between to_date('"+from+"','dd/mm/yyyy') and to_date('"+to+"','dd/mm/yyyy') and substr(BILL_NO,1,1)='"+Session["Region"]+"'";
				from = dateconcate(from);
				to = dateconcate(to);
				formula = "ToText({V22_BILL.BILL_DT},'yyyyMMdd')>='" + from + "' and ToText({V22_BILL.BILL_DT},'yyyyMMdd')<='" + to + "' and {V22_BILL.REGION_CODE}='" + Session["Region"] + "'";
				if (rdbPClient.Checked == true)
				{
					formula = formula + " and Trim({V22_BILL.BPO_TYPE}) ='" + lstClientType.SelectedItem.Value.ToString().Trim() + "' and Trim({V22_BILL.BPO_RLY}) ='" + lstBPO1.SelectedItem.Text.ToString().Trim() + "'";
				}
				//				formula=formula+" and ({V22_BILL.BPO_RLY} = 'RCF' or {V22_BILL.BPO_RLY} = 'RE' or {V22_BILL.BPO_RLY} = 'NR' or {V22_BILL.BPO_RLY} = 'ICF' or {V22_BILL.BPO_RLY} = 'BIS' or {V22_BILL.BPO_RLY} = 'JVVNL' or {V22_BILL.BPO_RLY} = 'NER')";
				if (lstBillType.SelectedValue == "N")
				{
					formula = formula + " and IsNull({V22_BILL.BILL_STATUS})";
				}
				else if (lstBillType.SelectedValue == "U")
				{
					formula = formula + " and {V22_BILL.BILL_STATUS}='U'";
				}
				if (rdbBPO.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_CD} ='" + txtBPO.Text + "'";
				}

				if (rdbRLY.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_TYPE}='R' AND ({V22_BILL.BPO_RLY} ='ICF' OR {V22_BILL.BPO_RLY} ='RCF' OR {V22_BILL.BPO_RLY} ='RWF' OR {V22_BILL.PO_OR_LETTER}='L')";

				}
				if (rdbNonRly.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_TYPE} <>'R'";
				}

				if (rdbPar_User.Checked == true)
				{
					formula = formula + " and Trim({V22_BILL.USER_ID}) ='" + lstUID.SelectedValue.ToString().Trim() + "'";
				}
			}
			//showrep1(formula);

		}

		protected void btnPrintBill_No_Click(object sender, System.EventArgs e)
		{
			if (rdbPER.Checked == true)
			{
				if (rdbPClient.Checked == true)
				{
					Response.Write("<script language=JavaScript>var oWin= window.open('rptPrint_Bill_Nos.aspx?FRM_DT=" + frmDt.Text + "&TO_DT=" + toDt.Text + "&REGION=" + Session["Region"].ToString() + "&Status=" + lstBillType.SelectedValue + "&CTYPE=" + lstClientType.SelectedValue + "&CLIENT=" + lstBPO1.SelectedValue + "&Type=Null','', 'fullscreen=yes, scrollbars=yes');");
				}
				else
				{
					Response.Write("<script language=JavaScript>var oWin= window.open('rptPrint_Bill_Nos.aspx?FRM_DT=" + frmDt.Text + "&TO_DT=" + toDt.Text + "&REGION=" + Session["Region"].ToString() + "&Status=" + lstBillType.SelectedValue + "&Type=Null','', 'fullscreen=yes, scrollbars=yes');");
				}
				Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
			}
			else
			{
				Response.Write("<script language=JavaScript>var oWin= window.open('rptPrint_Bill_Nos.aspx?FRM_BNO=" + txtBillFr.Text + "&TO_BNO=" + txtBillTo.Text + "&REGION=" + Session["Region"].ToString() + "&Status=Null&Type=Null','', 'fullscreen=yes, scrollbars=yes');");
				Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
			}
		}

		protected void btnPrintBill_No_UID_Click(object sender, System.EventArgs e)
		{
			if (rdbPER.Checked == true)
			{
				if (rdbPClient.Checked == true)
				{
					Response.Write("<script language=JavaScript>var oWin= window.open('rptPrint_Bill_Nos.aspx?FRM_DT=" + frmDt.Text + "&TO_DT=" + toDt.Text + "&REGION=" + Session["Region"].ToString() + "&Status=" + lstBillType.SelectedValue + "&CTYPE=" + lstClientType.SelectedValue + "&CLIENT=" + lstBPO1.SelectedValue + "&Type=U','', 'fullscreen=yes, scrollbars=yes');");
				}
				else
				{
					Response.Write("<script language=JavaScript>var oWin= window.open('rptPrint_Bill_Nos.aspx?FRM_DT=" + frmDt.Text + "&TO_DT=" + toDt.Text + "&REGION=" + Session["Region"].ToString() + "&Status=" + lstBillType.SelectedValue + "&Type=U','', 'fullscreen=yes, scrollbars=yes');");
				}
				Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
			}
			else
			{
				Response.Write("<script language=JavaScript>var oWin= window.open('rptPrint_Bill_Nos.aspx?FRM_BNO=" + txtBillFr.Text + "&TO_BNO=" + txtBillTo.Text + "&REGION=" + Session["Region"].ToString() + "&Status=Null&Type=U','', 'fullscreen=yes, scrollbars=yes');");
				Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
			}
		}

		private void btnView_UID_Click(object sender, System.EventArgs e)
		{
			string formula = "";
			if (rdbBNO.Checked == true)
			{
				if (txtBillTo.Text.Trim() == "")
				{
					txtBillTo.Text = txtBillFr.Text;
				}
				//str="update T22_BILL set BILL_STATUS='P' where BILL_NO >='"+txtBillFr.Text +"' and BILL_NO <='"+txtBillTo.Text+"' and substr(BILL_NO,1,1)='"+Session["Region"]+"'";
				formula = "{V22_BILL.BILL_NO} >='" + txtBillFr.Text + "' and {V22_BILL.BILL_NO} <='" + txtBillTo.Text + "' and {V22_BILL.REGION_CODE}='" + Session["Region"] + "'";
				//				formula=formula+" and ({V22_BILL.BPO_RLY} <> 'RCF' and {V22_BILL.BPO_RLY} <> 'RE' and {V22_BILL.BPO_RLY} <> 'NR' and {V22_BILL.BPO_RLY} <> 'ICF' and {V22_BILL.BPO_RLY} <> 'BIS' and {V22_BILL.BPO_RLY} <> 'JVVNL' and {V22_BILL.BPO_RLY} <> 'NER')";
				if (rdbBPO.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_CD} ='" + txtBPO.Text + "'";

				}
			}

			else if (rdbPER.Checked == true)
			{
				string from = "", to = "";
				if (frmDt.Text.Trim() == "")
				{
					from = "01/01/1900";
					to = toDt.Text.Trim();
				}
				else if (toDt.Text.Trim() == "")
				{
					to = "31/12/2100";
					from = frmDt.Text.Trim();
				}
				else
				{
					to = toDt.Text.Trim();
					from = frmDt.Text.Trim();
				}
				//str="update T22_BILL set BILL_STATUS='P' where T22_BILL.BILL_DT between to_date('"+from+"','dd/mm/yyyy') and to_date('"+to+"','dd/mm/yyyy') and substr(BILL_NO,1,1)='"+Session["Region"]+"'";
				from = dateconcate(from);
				to = dateconcate(to);
				formula = "ToText({V22_BILL.BILL_DT},'yyyyMMdd')>='" + from + "' and ToText({V22_BILL.BILL_DT},'yyyyMMdd')<='" + to + "' and {V22_BILL.REGION_CODE}='" + Session["Region"] + "'";
				//				formula=formula+" and ({V22_BILL.BPO_RLY} = 'RCF' or {V22_BILL.BPO_RLY} = 'RE' or {V22_BILL.BPO_RLY} = 'NR' or {V22_BILL.BPO_RLY} = 'ICF' or {V22_BILL.BPO_RLY} = 'BIS' or {V22_BILL.BPO_RLY} = 'JVVNL' or {V22_BILL.BPO_RLY} = 'NER')";
				if (lstBillType.SelectedValue == "N")
				{
					formula = formula + " and IsNull({V22_BILL.BILL_STATUS})";
				}
				else if (lstBillType.SelectedValue == "U")
				{
					formula = formula + " and {V22_BILL.BILL_STATUS}='U'";
				}
				if (rdbBPO.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_CD} ='" + txtBPO.Text + "'";
				}

				if (rdbRLY.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_TYPE}='R' AND ({V22_BILL.BPO_RLY} ='ICF' OR {V22_BILL.BPO_RLY} ='RCF' OR {V22_BILL.BPO_RLY} ='RWF' OR {V22_BILL.PO_OR_LETTER}='L')";

				}
				if (rdbNonRly.Checked == true)
				{
					formula = formula + " and {V22_BILL.BPO_TYPE} <>'R'";
				}
			}
			//showrep1(formula);
		}
		void fill_users()
		{
			try
			{
				lstBPO.Items.Clear();
				DataSet dsP = new DataSet();
				string str1 = "select DISTINCT V22.USER_ID, T02.USER_NAME FROM V22_BILL V22,T02_USERS T02 WHERE V22.USER_ID=T02.USER_ID AND (BILL_DT BETWEEN to_date('" + frmDt.Text + "','dd/mm/yyyy') AND to_date('" + toDt.Text + "','dd/mm/yyyy')) AND SUBSTR(BILL_NO,1,1)='" + Session["Region"] + "' order by V22.USER_ID";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("Invalid Search Data");
				}
				else
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["USER_NAME"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["USER_ID"].ToString();
						lstUID.Items.Add(lst);
					}
					//lstBPO.Visible=true;
					lstUID.SelectedIndex = 0;
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
		protected void rdbPar_User_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbPar_User.Checked == true)
			{
				fill_users();
				lstUID.Visible = true;
			}
			else
			{
				lstUID.Visible = false;
			}
		}

		private void lstClientType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_bpo_rly();
		}

		protected void rdbPClient_CheckedChanged(object sender, System.EventArgs e)
		{
			lstClientType.Visible = true;
			fill_bpo_rly();

		}

	}
}
