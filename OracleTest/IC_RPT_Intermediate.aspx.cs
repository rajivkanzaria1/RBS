using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace RBS
{
    enum EnmAmend
    {
        Amendments = 0,
        AddUpdateDate = 1,
        AddUpdateBy = 2
    }

    public partial class IC_RPT_Intermediate : System.Web.UI.Page
	{

		CrystalDecisions.CrystalReports.Engine.ReportDocument crystalReport = null;		
		string wIECD;		
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string CASE_NO, CALL_RECV_DT, CALL_SNO, PCONSIGNEE_CD, ACTIONAR;
		
		string man_type_o = "";		

		private void DisableCtrl()
		{
			txtBKNO1.Enabled = false;
			txtSetNo1.Enabled = false;
		}

		private void FillItems()
		{

			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			DataSet ds = new DataSet();
			string str = "SELECT BK_NO,SET_NO,IE_STAMPS_DETAIL ,IE_STAMPS_DETAIL,IE_STAMPS_DETAIL2,to_char(LAB_TST_RECT_DT,'dd/mm/yyyy') LAB_TST_RECT_DT,PASSED_INST_NO,REMARK,HOLOGRAM FROM IC_INTERMEDIATE WHERE CONSIGNEE_CD='" + Convert.ToString(ddlCondignee.SelectedValue) + "' AND CASE_NO='" + CASE_NO.Trim() + "' AND CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO='" + CALL_SNO + "' ORDER BY DATETIME DESC";
			OracleDataAdapter da = new OracleDataAdapter(str, conn);
			OracleCommand myOracleCommand = new OracleCommand(str, conn);
			conn.Open();
			da.SelectCommand = myOracleCommand;
			conn.Close();
			da.Fill(ds, "Table");


			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					foreach (DataRow itemDR in ds.Tables[0].Rows)
					{
						//if (Convert.ToString(ddlCondignee.SelectedValue) == Convert.ToString(itemDR["CONSIGNEE_CD"]))
						{
							txtBKNO1.Text = Convert.ToString(itemDR["BK_NO"]);
							txtSetNo1.Text = Convert.ToString(itemDR["SET_NO"]).PadLeft(3, '0');
							FillItemsCombo(Convert.ToString(ddlCondignee.SelectedValue));
							if (Convert.ToString(itemDR["IE_STAMPS_DETAIL"]) != "")
							{
								ddlIELST.SelectedValue = Convert.ToString(itemDR["IE_STAMPS_DETAIL"]);
							}

							if (Convert.ToString(itemDR["IE_STAMPS_DETAIL2"]) != "")
							{
								ddlIELST2.SelectedValue = Convert.ToString(itemDR["IE_STAMPS_DETAIL2"]);
							}

							if (Convert.ToString(itemDR["LAB_TST_RECT_DT"]) != null || Convert.ToString(itemDR["LAB_TST_RECT_DT"]) != "")
								txtLabtstrptdt.Text = Convert.ToString(itemDR["LAB_TST_RECT_DT"]);

							txtPassed_Inst_NO.Text = Convert.ToString(itemDR["PASSED_INST_NO"]) == "" ? Convert.ToString(itemDR["PASSED_INST_NO"]) : Convert.ToString(itemDR["PASSED_INST_NO"]);

							txtRemarks.Text = Convert.ToString(itemDR["REMARK"]);
							txtHologram.Text = Convert.ToString(itemDR["HOLOGRAM"]);

							//txtPassed_Inst_NO.Text =  ;

							setItemVal();
							break;
						}
					}
				}
				else
				{
					Reset();
				}
			}
		}

		private void FillItemsCombo(string condignee)
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string itemSql = "";

			//itemSql += "select 0 as ITEM_SRNO_PO,'Select Items' as ITEM_DESC_PO  from dual union SELECT CDT.ITEM_SRNO_PO,CASE WHEN CONSGN_CALL_STATUS ='Z' THEN ICI.ITEM_DESC_PO ELSE CDT.ITEM_DESC_PO END AS ITEM_DESC_PO ";
			itemSql += " SELECT DISTINCT CDT.ITEM_SRNO_PO";
			itemSql += " FROM RPT_PRM_INSPECTION_CERTIFICATE PRM INNER JOIN ";
			itemSql += " T17_CALL_REGISTER CLR ON CLR.CASE_NO = PRM.CASE_NO AND CLR.CALL_RECV_DT = PRM.CALL_RECV_DT  AND CLR.CALL_SNO = PRM.CALL_SNO ";
			itemSql += " INNER JOIN T18_CALL_DETAILS CDT ON CLR.CASE_NO = CDT.CASE_NO AND CLR.CALL_RECV_DT = CDT.CALL_RECV_DT  ";
			itemSql += " AND CLR.CALL_SNO = CDT.CALL_SNO ";
			itemSql += " AND CDT.CONSIGNEE_CD = '" + condignee + "' AND CDT.CASE_NO='" + CASE_NO.Trim() + "' AND CDT.CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CDT.CALL_SNO='" + CALL_SNO + "' ";
			itemSql += " INNER JOIN IC_INTERMEDIATE ICI ON CDT.ITEM_SRNO_PO = ICI.ITEM_SRNO_PO ";
			itemSql += " WHERE ICI.CASE_NO='" + CASE_NO.Trim() + "' AND ICI.CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND ICI.CALL_SNO='" + CALL_SNO + "' AND ICI.CONSIGNEE_CD ='" + ddlCondignee.SelectedValue + "'";
			itemSql += " ORDER BY CDT.ITEM_SRNO_PO";			

			DataSet ds = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(itemSql, conn);
			OracleCommand myOracleCommand = new OracleCommand(itemSql, conn);
			conn.Open();
			da.SelectCommand = myOracleCommand;
			conn.Close();
			da.Fill(ds, "Table");
			ddlItems.DataValueField = "ITEM_SRNO_PO";
			ddlItems.DataTextField = "ITEM_SRNO_PO";
			ddlItems.DataSource = ds;
			ddlItems.DataBind();
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			//12254,11810
			
			if (Convert.ToString(Request.Params["CASE_NO"]) == null || Convert.ToString(Request.Params["CALL_RECV_DT"]) == null)
			{				
				CASE_NO = "";
				CALL_RECV_DT = "";
				CALL_SNO = "";
				PCONSIGNEE_CD = "";
				ACTIONAR = "";
			}
			else
			{				
				CASE_NO = Convert.ToString(Request.Params["CASE_NO"].Trim());
				CALL_RECV_DT = Convert.ToString(Request.Params["CALL_RECV_DT"].Trim());
				CALL_SNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
				PCONSIGNEE_CD = Convert.ToString(Request.Params["CONSIGNEE_CD"].Trim());
				ACTIONAR = Convert.ToString(Request.Params["ACTIONAR"].Trim());
			}

			if (Request.QueryString["filename"] != null)
			{
				string filename = Request.QueryString["filename"];

				XmlDocument XmlDoc = new XmlDocument();
				XmlDoc.Load(Server.MapPath("IC_XML/" + filename + ".xml"));
				
				string dsic = "";
				XmlNode node;
				byte[] imageBytes;
				try
				{
					node = XmlDoc.DocumentElement.SelectSingleNode("/response/data");
					dsic = node.InnerText;
					imageBytes = Convert.FromBase64String(node.InnerText);
					FileStream fs = new FileStream(Server.MapPath("..") + @"/RBS/BILL_IC/" + filename + ".PDF", FileMode.OpenOrCreate);
					fs.Write(imageBytes, 0, imageBytes.Length);
					fs.Close();
				}
				catch (Exception ex)
				{
					node = XmlDoc.DocumentElement.SelectSingleNode("/request/data");
					dsic = node.InnerText;
					imageBytes = Convert.FromBase64String(node.InnerText);
				}

				Response.Clear();
				Response.Buffer = true;
				Response.ContentType = "application/pdf";
				Response.BinaryWrite(imageBytes);
				Response.End();

			}
			
			CASE_NO = Request.Params["CASE_NO"].ToString();
			CALL_RECV_DT = Request.Params["CALL_RECV_DT"].ToString();
			CALL_SNO = Request.Params["CALL_SNO"].ToString();
			ACTIONAR = Request.Params["ACTIONAR"].ToString();
			wIECD = Session["IE_CD"].ToString();

			//ACTIONAR = Session["ACTIONAR"].ToString();
			if (ACTIONAR == "R")
			{
				Label32.Visible = true;
				txtRemarks.Visible = true;
				Label4.Visible = true;
				lblRemarks.Visible = true;
			}

			AcceptedFun();
			GetVisitsChanges(true);

			//Kamta Code for Central 05-12-2019 start//

			if (Session["Region"].ToString() == "C")
			{
				Man_type.Visible = true;
				GBPO_DES.Visible = true;
				OFF_INST_NO.Visible = false;
				I_UOM.Visible = false;
				Labelqtyod.Text = "QUANTITY ORDERED(MT)";
				Labelcumqtyoffer.Text = "CUM QTY DISPATCHED PREV(MT)";
				Labelqtypass.Text = "QTY NOW DISPATCHED(MT)";
				LabelVT.Text = "Dates of Dispatch";
				LAB_RE.Visible = false;
				Labelinst.Text = "INSTALLMENT NO.";
				DIS_PAC_NO.Visible = true;
				INVOICE_NO.Visible = true;
				NAME_INS_ENG.Visible = true;
				CONS_DESG.Visible = true;
				lstman();

			}
			else
			{
				Man_type.Visible = false;
				GBPO_DES.Visible = false;
				OFF_INST_NO.Visible = true;
				I_UOM.Visible = true;
				Labelqtyod.Text = "QTY ORDERED";
				Labelcumqtyoffer.Text = "CUM QTY PREV OFFERED";
				Labelqtypass.Text = "QTY PASSED";
				LabelVT.Text = "Visits Dates";
				LAB_RE.Visible = true;
				Labelinst.Text = "Passed instt. Note";
				DIS_PAC_NO.Visible = false;
				INVOICE_NO.Visible = false;
				NAME_INS_ENG.Visible = false;
				CONS_DESG.Visible = false;

			}
			
			string str = "";
			if (!(IsPostBack))
			{
				
				btnViewIC.Attributes.Add("onclick", "return CheckDoubleCLK();");
				//lstman();
				DataSet ds = new DataSet();
				//str = "SELECT 0 AS IE_STAMP_CD,'BLANK' AS IE_STAMPS_DETAIL FROM DUAL UNION SELECT IE_STAMP_CD, IE_STAMPS_DETAIL FROM IE_STAMPS";
				str = " SELECT 0 AS IE_STAMP_CD,'SELECT STAMP' AS IE_STAMPS_DETAIL FROM DUAL UNION SELECT IE_STAMP_CD, IE_STAMPS_DETAIL FROM IE_STAMPS ORDER BY IE_STAMP_CD";
				OracleDataAdapter da = new OracleDataAdapter(str, conn);
				OracleCommand myOracleCommand = new OracleCommand(str, conn);
				if (conn.State != ConnectionState.Open)
					conn.Open();
				da.SelectCommand = myOracleCommand;
				if (conn.State != ConnectionState.Closed)
					conn.Close();
				da.Fill(ds, "Table");
				ddlIELST.DataValueField = "IE_STAMPS_DETAIL";
				ddlIELST.DataTextField = "IE_STAMPS_DETAIL";
				ddlIELST.DataSource = ds;
				ddlIELST.DataBind();

				ddlIELST2.DataValueField = "IE_STAMPS_DETAIL";
				ddlIELST2.DataTextField = "IE_STAMPS_DETAIL";
				ddlIELST2.DataSource = ds;
				ddlIELST2.DataBind();
				
				ds = new DataSet();
				str = "select 0 as consignee_cd,'Select Consignee' as consignee_firm from dual union select distinct csn.consignee_cd,CSN.consignee_cd ||'-'|| csn.consignee consignee_firm   from t18_call_details CDT inner join V06_CONSIGNEE CSN ";
				str += " on cdt.consignee_cd = csn.consignee_cd where case_no = '" + CASE_NO + "' and call_recv_dt = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') and call_sno = '" + CALL_SNO + "' ";
				da = new OracleDataAdapter(str, conn);
				myOracleCommand = new OracleCommand(str, conn);
				if (conn.State != ConnectionState.Open)
					conn.Open();
				da.SelectCommand = myOracleCommand;
				if (conn.State != ConnectionState.Closed)
					conn.Close();
				conn.Close();
				da.Fill(ds, "Table");
				ddlCondignee.DataValueField = "consignee_cd";
				ddlCondignee.DataTextField = "consignee_firm";
				ddlCondignee.DataSource = ds;
				ddlCondignee.DataBind();
				ddlCondignee.SelectedValue = PCONSIGNEE_CD;

				txtBKNO1.Text = "";
				txtSetNo1.Text = "";

				FillItems();				
			}

			FillAMENDMENTS(CASE_NO, lblPONO.Text);

			SetAccepted();
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
			this.ddlCondignee.SelectedIndexChanged += new System.EventHandler(this.DdlCondignee_SelectedIndexChanged);
			this.ddlItems.SelectedIndexChanged += new System.EventHandler(this.DdlItems_SelectedIndexChanged);
			this.lstmantype.SelectedIndexChanged += new System.EventHandler(this.lstmantype_SelectedIndexChanged);
			//this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnViewIC.Click += new System.EventHandler(this.btnViewIC_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			//this.btnCancelFiles.Click += new System.EventHandler(this.btnCancelFiles_Click);

			this.btnSaveICData.Click += new System.EventHandler(this.btnSaveICData_Click);

			this.BtnSaveAmnd.Click += new System.EventHandler(this.BtnSaveAmnd_Click); ;

			this.btnRefresh.Click += new EventHandler(btnRefresh_Click);
			this.ChkConsdtl.CheckedChanged += new System.EventHandler(this.ChkConsdtl_CheckedChanged);
			this.ChkBPOdtl.CheckedChanged += new System.EventHandler(this.ChkBPOdtl_CheckedChanged);
			this.ChecGBPOdt1.CheckedChanged += new System.EventHandler(this.ChecGBPOdt1_CheckedChanged);
			this.ChkManufacturerdtl.CheckedChanged += new System.EventHandler(this.ChkManufacturerdtl_CheckedChanged);
			this.ChkPurchasingAuthoritydtl.CheckedChanged += new System.EventHandler(this.ChkPurchasingAuthoritydtl_CheckedChanged);
			this.ChkOFINtlhk.CheckedChanged += new System.EventHandler(this.ChkOFINtlhk_CheckedChanged);
			this.ChkUnitdtl.CheckedChanged += new System.EventHandler(this.ChkUnitdtl_CheckedChanged);
		}


		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IC_Intermediate.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + wIECD + "&ACTIONAR=" + ACTIONAR + "&ACTION=" + Request.Params["ACTION"].Trim() + "' Font-Names='Verdana' Font-Size='8pt'");
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}




		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				string w_call_cancel_status = "";
				conn.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn.Close();





				//if (lblCallStatus.Text == "C" && lstCallStatus.SelectedValue != "C")
				//{
				//    string DQuery = "Delete T19_CALL_CANCEL where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
				//    OracleCommand myDCommand = new OracleCommand(DQuery, conn);
				//    conn.Open();
				//    myDCommand.ExecuteNonQuery();
				//    conn.Close();
				//    w_call_cancel_status = "";

				//}
				//else if (lstCallStatus.SelectedValue == "C" && lstCallCancelStatus.SelectedValue == "C")
				//{
				//    w_call_cancel_status = "C";

				//}
				//else if (lstCallStatus.SelectedValue == "C" && lstCallCancelStatus.SelectedValue == "N")
				//{
				//    w_call_cancel_status = "N";

				//}
				//else
				//{
				w_call_cancel_status = "";

				//}

				//if (lstCallStatus.SelectedValue == "A" || lstCallStatus.SelectedValue == "R")
				{
					string bscheck = "";
					//					w_call_cancel_status="";
					if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
					{
						conn.Open();
						OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + wIECD, conn);
						bscheck = Convert.ToString(cmd.ExecuteScalar());
						conn.Close();
					}
					//if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck != "" && txtHologram.Text.Trim() != "" && File1.Value != "")
					if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck != "" && txtHologram.Text.Trim() != "")
					{
						string str = "select NVL(count(*),0) from T49_IC_PHOTO_ENCLOSED where CASE_NO='" + lblCSNO.Text.Trim() + "' and BK_NO='" + txtBKNO1.Text + "' and SET_NO='" + txtSetNo1.Text + "'";
						OracleCommand cmd1 = new OracleCommand(str, conn);
						conn.Open();
						int count = Convert.ToInt16(cmd1.ExecuteScalar());
						conn.Close();
						if (count > 0)
						{
							string updateQuery = "";
							string updateQuery1 = "";
							conn.Open();
							OracleTransaction myTrans = conn.BeginTransaction();
							//if (lstCallStatus.SelectedValue == "A")
							{
								//updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
								updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='A',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";

								updateQuery1 = "Update IC_INTERMEDIATE set consgn_call_status = 'A' where CASE_NO = '" + lblCSNO.Text.Trim() + "' and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";
							}
							//else if (lstCallStatus.SelectedValue == "R")
							//{
							//    if (lblRemarks.Text.Trim() != "")
							//    {
							//        updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',REMARKS='" + lblRemarks.Text.Trim() + "'||', '||'" + txtRemarks.Text.Trim() + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
							//    }
							//    else
							//    {
							//        updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',REMARKS='" + txtRemarks.Text.Trim() + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
							//    }
							//}
							//OracleCommand myUpdateCommand = new OracleCommand(updateQuery);
							//myUpdateCommand.Transaction = myTrans;
							//myUpdateCommand.Connection = conn;
							//myUpdateCommand.ExecuteNonQuery();


							OracleCommand myUpdateCommand = new OracleCommand(updateQuery1);
							myUpdateCommand.Transaction = myTrans;
							myUpdateCommand.Connection = conn;
							myUpdateCommand.ExecuteNonQuery();

							//if (lstCallStatus.SelectedValue == "R")
							//{
							//    string updateQuery1 = "Update T13_PO_MASTER set PENDING_CHARGES=NVL(PENDING_CHARGES,0)+1 where CASE_NO='" + lblCSNO.Text.Trim() + "'";
							//    OracleCommand myUpdateCommand1 = new OracleCommand(updateQuery1, conn);
							//    myUpdateCommand1.Transaction = myTrans;
							//    myUpdateCommand1.Connection = conn;
							//    myUpdateCommand1.ExecuteNonQuery();
							//}
							myTrans.Commit();
							conn.Close();
							//photo_upload(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
							DisplayAlert("Your Record is Saved!!!");
						}
						else
						{
							DisplayAlert("Photos against given Case No, Book No & Set No are not uploaded, So Upload Photos before changing the Call Status to [Aceepted OR Rejection]!!!");
						}
					}
					else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
					{
						DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
					}
					//else if (txtBKNO1.Text.Trim() == "" || txtSetNo1.Text.Trim() == "" || txtHologram.Text == "" || File1.Value == "")
					else if (txtBKNO1.Text.Trim() == "" || txtSetNo1.Text.Trim() == "" || txtHologram.Text == "")
					{

						DisplayAlert("Book No. , Set No., Holograms OR IC Photo cannot be left blank!!!");
						//						string updateQuery="Update T17_CALL_REGISTER set CALL_STATUS='"+lstCallStatus.SelectedValue+"',CALL_STATUS_DT=to_date('"+txtSTDT.Text+"','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='"+txtBKNO1.Text+"',SET_NO='"+txtSetNo1.Text+"',USER_ID='"+Session["IE_EMP_NO"].ToString()+"',DATETIME=to_date('"+ss+"','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO="+lblSNO.Text+"";
						//						OracleCommand myUpdateCommand=new OracleCommand(updateQuery,conn);
						//						conn.Open();
						//						myUpdateCommand.ExecuteNonQuery();
						//						conn.Close(); 
					}
				}
				//else
				//{
				//    string updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS='" + w_call_cancel_status + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
				//    OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn);
				//    conn.Open();
				//    myUpdateCommand.ExecuteNonQuery();
				//    conn.Close();
				//    DisplayAlert("Your Record is Saved!!!");
				//}

				//if (lstCallStatus.SelectedValue == "C")
				//{
				//    Panel_1.Visible = true;
				//    Call_Cancellation_Entry();

				//}
				////				else if(lstCallStatus.SelectedValue=="A" || lstCallStatus.SelectedValue=="R")
				////				{
				////					HyperLink1.Visible=true;
				////				}
				//else
				//{
				//    Panel_1.Visible = false;
				//}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn.Close();
			}

			AcceptedFun();
		}

		//        void send_Vendor_Email()
		//        {
		//            try
		//            {
		//                string wRegion = "";
		//                string wPCity = "";
		//                string sender = "";
		//                OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1) VEND_ADDRESS,T03.CITY VEND_CITY, T05.VEND_EMAIL,T13.REGION_CODE,T13.RLY_CD from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + lblCSNO.Text.Trim() + "'", conn);
		//                conn.Open();
		//                OracleDataReader reader = cmd_vend.ExecuteReader();
		//                string vend_cd = "", vend_name = "", vend_email = "", rly_cd = "", vend_city = "";
		//                while (reader.Read())
		//                {
		//                    vend_cd = Convert.ToString(reader["VEND_CD"]);
		//                    vend_name = Convert.ToString(reader["VEND_NAME"]);
		//                    vend_city = Convert.ToString(reader["VEND_CITY"]);
		//                    vend_email = Convert.ToString(reader["VEND_EMAIL"]);
		//                    rly_cd = Convert.ToString(reader["RLY_CD"]);
		//                    if (reader["REGION_CODE"].ToString() == "N") { wRegion = "NORTHERN REGION <br> 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092<br> Phone : 011-22029119 <br> Fax : 011-22024665"; sender = "nrinspn@rites.com"; wPCity = "New Delhi"; }
		//                    else if (reader["REGION_CODE"].ToString() == "S") { wRegion = "SOUTHERN REGION <br> 758 ANNA SALAI [MOUNT CHAMBER], CHENNAI - 600 002 <br> Phone : 044-28523364/044-28524128 <br> Fax : 044-28525408"; sender = "srinspn@rites.com"; wPCity = "Chennai"; }
		//                    else if (reader["REGION_CODE"].ToString() == "E") { wRegion = "EASTERN REGION <br> CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  <br> Fax : 033-22348704"; sender = "erinspn@rites.com"; wPCity = "Kolkata"; }
		//                    else if (reader["REGION_CODE"].ToString() == "W") { wRegion = "WESTERN REGION <br> CHURCHGATE STATION BLDG., 2nd FLOOR, M.K ROAD,MUMBAI-400 020 <br> Phone : 022-22012523/022-22015573 <br> Fax : 022-22081455/022-22016220"; sender = "wrinspn@rites.com"; wPCity = "Mumbai"; }
		//                    else if (reader["REGION_CODE"].ToString() == "C") { wRegion = "Central Region"; }
		//                }
		//                conn.Close();
		//
		//                OracleCommand cmd = new OracleCommand("Select T05.VEND_NAME MFG_NAME,T03.CITY MFG_CITY,T05.VEND_EMAIL,T17.MFG_CD from T05_VENDOR T05,T17_CALL_REGISTER T17,T03_CITY T03 where T05.VEND_CD=T17.MFG_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text, conn);
		//                conn.Open();
		//                string manu_mail = "", mfg_cd = "", manu_name = "", manu_city = "";
		//                OracleDataReader reader1 = cmd.ExecuteReader();
		//                while (reader1.Read())
		//                {
		//                    manu_mail = Convert.ToString(reader1["VEND_EMAIL"]);
		//                    mfg_cd = Convert.ToString(reader1["MFG_CD"]);
		//                    manu_name = Convert.ToString(reader1["MFG_NAME"]);
		//                    manu_city = Convert.ToString(reader1["MFG_CITY"]);
		//
		//                }
		//
		//                conn.Close();
		//                OracleCommand cmd1 = new OracleCommand("Select T09.IE_NAME,T09.IE_PHONE_NO,T09.IE_EMAIL,T08.CO_EMAIL  from T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_CD=" + Request.Params["IE_CD"].ToString(), conn);
		//                conn.Open();
		//                string ie_phone = "", ie_name = "", ie_email = "", ie_co_email = "";
		//                OracleDataReader reader2 = cmd1.ExecuteReader();
		//                while (reader2.Read())
		//                {
		//                    ie_phone = Convert.ToString(reader2["IE_PHONE_NO"]);
		//                    ie_name = Convert.ToString(reader2["IE_NAME"]);
		//                    ie_email = Convert.ToString(reader2["IE_EMAIL"]);
		//                    ie_co_email = Convert.ToString(reader2["CO_EMAIL"]);
		//                }
		//                conn.Close();
		//                string can_reasons = "";
		//                //if (lstCallStatus.SelectedValue == "C")
		//                //{
		//                //    can_reasons = get_cancel_reasons();
		//                //}
		//                string call_letter_dt = "";
		//                if (lblCLettDT.Text.Trim() == "")
		//                {
		//                    call_letter_dt = "NIL";
		//                }
		//                else
		//                {
		//                    call_letter_dt = lblCLettDT.Text.Trim();
		//                }
		//                string mail_body = "";
		//                if (lstCallCancelStatus.SelectedValue == "C")
		//                {
		//                    mail_body = vend_name + ", " + vend_city + " / " + manu_name + ", " + manu_city + ",<br><br> Your Call Letter Dated:  " + call_letter_dt + " for inspection of material against Agency.-" + rly_cd + ", PO No. - " + lblPONO.Text + " & Date - " + lblPODT.Text + ", Case NO. -" + lblCSNO.Text + ", registered on date: " + lblCallDT.Text + ", at SNo. " + lblSNO.Text + ". is Cancelled (" + lstCallCancelStatus.SelectedItem.Text + ") on Date.-" + txtSTDT.Text + " by the concerned Inspection Engineer. - " + ie_name + " Contact No. " + ie_phone + ", Due to the following reasons.<br>" + can_reasons + "<br>";
		//                    if (lstCallCancelCharges.SelectedValue == "0")
		//                    {
		//                        mail_body = mail_body + "You are requested to submit call cancellation charges through Demand Draft for the amount calculated based on Railway Board order no. 99/RS(G)/709/4 Dated. 12-02-2016. </b> in f/o RITES LTD, Payble at " + wPCity + " along with next call.<br><b><u>Please note that call letter without call cancellation charges will not be accepted.</u></b><br>";
		//
		//                    }
		//                    else
		//                    {
		//                        mail_body = mail_body + "You are requested to submit call cancellation charges through Demand Draft for <b> Rs." + lstCallCancelCharges.SelectedValue + " + S.T. </b> in f/o RITES LTD, Payble at " + wPCity + " along with next call.<br><b><u>Please note that call letter without call cancellation charges will not be accepted.</u></b><br>";
		//                    }
		//
		//
		//                    mail_body = mail_body + "This is for your information and necessary corrective measures please. <br><br> Thanks for using RITES Inspection Services. <br><br>" + wRegion + ".";
		//                }
		//                else
		//                {
		//                    mail_body = vend_name + ", " + vend_city + " / " + manu_name + ", " + manu_city + ",<br><br> Your Call Letter Dated:  " + call_letter_dt + " for inspection of material against Agency.-" + rly_cd + ", PO No. - " + lblPONO.Text + " & Date - " + lblPODT.Text + ", Case NO. -" + lblCSNO.Text + ", registered on date: " + lblCallDT.Text + ", at SNo. " + lblSNO.Text + ". is Cancelled (" + lstCallCancelStatus.SelectedItem.Text + ") on Date.-" + txtSTDT.Text + " by the concerned Inspection Engineer. - " + ie_name + " Contact No. " + ie_phone + "<br>";
		//                    mail_body = mail_body + "This is for your information and necessary corrective measures please. <br><br> Thanks for using RITES Inspection Services. <br><br>" + wRegion + ".";
		//                }
		//                if (vend_cd == mfg_cd && manu_mail != "")
		//                {
		//                    MailMessage mail = new MailMessage();
		//                    mail.To = manu_mail;
		//                    mail.Cc = ie_co_email;
		//                    mail.Bcc = ie_email + ";nrinspn@gmail.com";
		//                    mail.BodyFormat = MailFormat.Html;
		//                    mail.From = sender;
		//                    mail.Subject = "Your Call for Inspection By RITES has Cancelled.";
		//                    mail.Body = mail_body;
		//                    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
		//                    SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
		//                    mail.Priority = MailPriority.High;
		//                    SmtpMail.Send(mail);
		//                }
		//                else if (vend_cd != mfg_cd)
		//                {
		//
		//                    if (vend_email != "")
		//                    {
		//                        MailMessage mail = new MailMessage();
		//                        mail.To = vend_email;
		//                        mail.Cc = ie_co_email;
		//                        mail.Bcc = ie_email + ";nrinspn@gmail.com";
		//                        mail.BodyFormat = MailFormat.Html;
		//                        mail.From = sender;
		//                        mail.Subject = "Your Call for Inspection By RITES has Cancelled.";
		//                        mail.Body = mail_body;
		//                        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
		//                        SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
		//                        mail.Priority = MailPriority.High;
		//                        SmtpMail.Send(mail);
		//
		//                    }
		//                    else if (manu_mail != "")
		//                    {
		//                        MailMessage mail1 = new MailMessage();
		//                        mail1.To = manu_mail;
		//                        mail1.Cc = ie_co_email;
		//                        mail1.Bcc = ie_email + ";nrinspn@gmail.com";
		//                        mail1.BodyFormat = MailFormat.Html;
		//                        mail1.From = sender;
		//                        mail1.Subject = "Your Call for Inspection By RITES has Cancelled.";
		//                        mail1.Body = mail_body;
		//                        mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
		//                        SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
		//                        mail1.Priority = MailPriority.High;
		//                        SmtpMail.Send(mail1);
		//                    }
		//
		//
		//                }
		//
		//                if (vend_email == "" && manu_mail == "")
		//                {
		//                    mail_body = mail_body + "\n As their is no email-id available for Vendor/Manufacturer, So the email cannot be send to Vendor/Manufacturer.";
		//                    MailMessage mail1 = new MailMessage();
		//                    mail1.To = ie_co_email;
		//                    mail1.Bcc = ie_email + ";nrinspn@gmail.com";
		//                    mail1.BodyFormat = MailFormat.Html;
		//                    mail1.From = sender;
		//                    mail1.Subject = "Your Call for Inspection By RITES has Cancelled.";
		//                    mail1.Body = mail_body;
		//                    mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
		//                    SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
		//                    mail1.Priority = MailPriority.High;
		//                    SmtpMail.Send(mail1);
		//
		//
		//                }
		//
		//            }
		//            catch (Exception ex)
		//            {
		//                string str;
		//                str = ex.Message;
		//                //				Response.Write(ex);
		//            }
		//            finally
		//            {
		//                conn.Close();
		//                conn.Dispose();
		//            }
		//
		//
		//        }

		private void btnViewIC_Click(object sender, System.EventArgs e)
		{

			//File2OleDbBlob();//Commented for Blob IC Report issue-29102018 

			//            conn.Open();
			//            OracleDataReader ord;
			//            string qry = "Delete from RPT_PRM_Inspection_Certificate Where Request_TS < CURRENT_TIMESTAMP - INTERVAL '1' MINUTE";
			//            OracleCommand myOracleCommand1 = new OracleCommand(qry, conn);
			//            ord = myOracleCommand1.ExecuteReader();
			//            conn.Close();
			//updateQuery="Update T17_CALL_REGISTER set CALL_STATUS='"+lstCallStatus.SelectedValue+"',CALL_STATUS_DT=to_date('"+txtSTDT.Text+"','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='"+txtBKNO1.Text+"',SET_NO='"+txtSetNo1.Text+"',USER_ID='"+Session["IE_EMP_NO"].ToString()+"',DATETIME=to_date('"+ss+"','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='"+txtHologram.Text.Trim()+"' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO="+lblSNO.Text+"";
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string str1 = "SELECT man_type FROM IC_INTERMEDIATE WHERE CONSIGNEE_CD='" + Convert.ToString(ddlCondignee.SelectedValue) + "' AND CASE_NO='" + CASE_NO.Trim() + "' AND CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO='" + CALL_SNO + "' ORDER BY DATETIME DESC";
			OracleCommand cmd31 = new OracleCommand(str1, conn);
			conn.Open();
			System.Data.DataSet ds = new DataSet();
			OracleDataAdapter adapter = new OracleDataAdapter(cmd31);
			adapter.Fill(ds);
			string Manu_Type = "";
			Manu_Type = Convert.ToString(ds.Tables[0].Rows[0][0]);
			conn.Close();

			CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = null;
			//			rbs my_rbs=null;

			string caseNo = lblCSNO.Text.Trim();
			string callSNo = lblSNO.Text;
			string myYear, myMonth, myDay;
			myYear = lblCallDT.Text.Substring(6, 4);
			myMonth = lblCallDT.Text.Substring(3, 2);
			myDay = lblCallDT.Text.Substring(0, 2);
			string recvDtRpt = myMonth + "/" + myDay + "/" + myYear;
			try
			{
				crystalReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
				cristalview.DisplayGroupTree = false;
				DataSet dsCustom = new DataSet();
				if (Session["Region"].ToString() == "C")
				{
					if (Manu_Type == "B")
					{
						crystalReport.Load(Server.MapPath("~/Reports/InspectionCertificateNew_CR.rpt"));
						dsCustom = funInspectionCertificate_cr(caseNo, callSNo, recvDtRpt, ddlCondignee.SelectedValue, Convert.ToString(Session["Region"]));
					}
					else if (Manu_Type == "J")
					{
						crystalReport.Load(Server.MapPath("~/Reports/InspectionCertificateNew_CR_R.rpt"));
						dsCustom = funInspectionCertificate_cr_r(caseNo, callSNo, recvDtRpt, ddlCondignee.SelectedValue, Convert.ToString(Session["Region"]));

					}
					else if (Manu_Type == "O")
					{
						crystalReport.Load(Server.MapPath("~/Reports/InspectionCertificateNew.rpt"));
						dsCustom = funInspectionCertificate(caseNo, callSNo, recvDtRpt, ddlCondignee.SelectedValue, Convert.ToString(Session["Region"]));

					}
				}
				else
				{
					crystalReport.Load(Server.MapPath("~/Reports/InspectionCertificateNew.rpt"));
					dsCustom = funInspectionCertificate(caseNo, callSNo, recvDtRpt, ddlCondignee.SelectedValue, Convert.ToString(Session["Region"]));
				}
				crystalReport.SetDataSource(dsCustom);
				cristalview.ReportSource = crystalReport;

				//string recvDtQry = "26-NOV-2010";

				//            conn.Open();
				//            qry = "INSERT INTO RPT_PRM_Inspection_Certificate VALUES ('" + caseNo + "', to_date('" + recvDtRpt + "','mm/dd/yyyy'), " + callSNo + " , NULL, NULL , CURRENT_TIMESTAMP)";
				//            myOracleCommand1 = new OracleCommand(qry, conn);
				//            ord = myOracleCommand1.ExecuteReader();
				//            conn.Close();


				//            qry = "MERGE INTO RPT_PRM_Inspection_Certificate RP USING ";
				//            qry += "( SELECT CASE_NO, CALL_SNO, CALL_RECV_DT, COUNT(*) as NUM_VISITS, LISTAGG(TO_CHAR(Visit_DT, 'DD.MM.YYYY'), ', ') within group (order by Visit_DT ) as VISIT_DATES ";
				//            qry += "    FROM T47_IE_WORK_PLAN ";
				//            qry += "   WHERE CASE_NO = '" + caseNo + "' and CALL_SNO = " + callSNo + " and CALL_RECV_DT = to_date('" + recvDtRpt + "','mm/dd/yyyy') ";
				//            qry += "  GROUP BY CASE_NO, CALL_SNO, CALL_RECV_DT) WP ";
				//            qry += "ON(RP.CASE_NO = WP.CASE_NO AND RP.CALL_SNO = WP.CALL_SNO AND RP.CALL_RECV_DT = WP.CALL_RECV_DT) ";
				//            qry += "WHEN MATCHED THEN UPDATE SET ";
				//            qry += "RP.NUM_VISITS = WP.NUM_VISITS, ";
				//            qry += "RP.VISIT_DATES = WP.VISIT_DATES";
				//            conn.Open();
				//            myOracleCommand1 = new OracleCommand(qry, conn);
				//
				//            ord = myOracleCommand1.ExecuteReader();
				//            conn.Close();

				//				 my_rbs = new rbs();
				//           
				//				rpt = new Reports.InspectionCertificate();
				//				//			rpt.RecordSelectionFormula ="ToText({V22_BILL.BILL_DT},'yyyyMMdd')>='"+wDtFr+"' and ToText({V22_BILL.BILL_DT},'yyyyMMdd')<='"+wDtTo+"' and {V22_BILL.REGION_CODE}='"+Session["Region"]+"' and ("+wFormula+")";
				//				//			rpt.SetParameterValue(0,Session["Region"]);
				//				//			rpt.SetParameterValue(1,txtDateFr.Text);
				//				//			rpt.SetParameterValue(2,txtDateTo.Text);
				//				rpt.SetParameterValue("caseno", caseNo);
				//				rpt.SetParameterValue(1, callSNo);
				//				rpt.SetParameterValue(2, recvDtRpt);
				//
				//				rpt.SetParameterValue(3, caseNo);
				//
				//				rpt.SetParameterValue(4, Convert.ToString(Session["Region"]));
				//
				//				rpt.SetParameterValue(5, ddlCondignee.SelectedValue);
				//
				//				MemoryStream oStream = my_rbs.showpdfrep(rpt);
				//				Response.Clear();
				//				Response.Buffer = true;
				//				Response.ContentType = "application/pdf";
				//           
				//				Response.BinaryWrite(oStream.ToArray());


				//File2OleDbBlob2Null();//Commented for Blob IC Report issue-29102018 
				//Response.End();
				//            }
				//            catch (Exception err)
				//            {
				//                Response.Write("< BR >");
				//                Response.Write(err.Message.ToString());
				//            }
			}
			catch (Exception exErr)
			{

				//ExceptionLogging.SendErrorToText(exErr);

			}
			finally
			{
				CrystalDecisions.Shared.ExportFormatType formatType = CrystalDecisions.Shared.ExportFormatType.NoFormat;
				formatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
				//crystalReport.ExportToHttpResponse(formatType, Response, true, "Crystal");


				MemoryStream oStream = new MemoryStream();
				CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();

				crystalReport.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.NoDestination;
				//rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;



				crystalReport.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
				oStream = (MemoryStream)crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
				//				Response.Clear();
				//				Response.Buffer = true;
				//				Response.ContentType = "application/pdf";
				//
				//				Response.BinaryWrite(oStream.ToArray());
				//
				//				Response.End();
				String file = Convert.ToBase64String(oStream.ToArray());
				XmlDocument doc = new XmlDocument();
				XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
				doc.AppendChild(docNode);

				XmlNode requestNode = doc.CreateElement("request");
				doc.AppendChild(requestNode);



				XmlNode commandNode = doc.CreateElement("command");
				commandNode.AppendChild(doc.CreateTextNode("pkiNetworkSign"));
				requestNode.AppendChild(commandNode);

				XmlNode tsNode = doc.CreateElement("ts");
				//tsNode.AppendChild(doc.CreateTextNode("2019-03-25T12:23:11.3820412+05:30"));
				string tym = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
				tsNode.AppendChild(doc.CreateTextNode(tym));
				requestNode.AppendChild(tsNode);
				Random random = new Random();
				string otp = Convert.ToString(random.Next(1000, 9999));

				XmlNode txnNode = doc.CreateElement("txn");
				txnNode.AppendChild(doc.CreateTextNode(otp));
				requestNode.AppendChild(txnNode);

				XmlNode certNode = doc.CreateElement("certificate");
				requestNode.AppendChild(certNode);


				XmlNode nameNode1 = doc.CreateElement("attribute");
				XmlAttribute nameNode1Attr = doc.CreateAttribute("name");
				nameNode1Attr.Value = "CN";
				nameNode1.Attributes.Append(nameNode1Attr);
				//nameNode1.AppendChild(doc.CreateTextNode("IC"));
				certNode.AppendChild(nameNode1);

				XmlNode nameNode2 = doc.CreateElement("attribute");
				XmlAttribute nameNode2Attr = doc.CreateAttribute("name");
				nameNode2Attr.Value = "O";
				nameNode2.Attributes.Append(nameNode2Attr);
				//nameNode2.AppendChild(doc.CreateTextNode("RITES LTD"));
				certNode.AppendChild(nameNode2);

				XmlNode nameNode3 = doc.CreateElement("attribute");
				XmlAttribute nameNode3Attr = doc.CreateAttribute("name");
				nameNode3Attr.Value = "OU";
				nameNode3.Attributes.Append(nameNode3Attr);
				//nameNode3.AppendChild(doc.CreateTextNode("QA DIVISION"));
				certNode.AppendChild(nameNode3);

				XmlNode nameNode4 = doc.CreateElement("attribute");
				XmlAttribute nameNode4Attr = doc.CreateAttribute("name");
				nameNode4Attr.Value = "T";
				nameNode4.Attributes.Append(nameNode4Attr);
				//nameNode4.AppendChild(doc.CreateTextNode("IE"));
				certNode.AppendChild(nameNode4);

				XmlNode nameNode5 = doc.CreateElement("attribute");
				XmlAttribute nameNode5Attr = doc.CreateAttribute("name");
				nameNode5Attr.Value = "E";
				nameNode5.Attributes.Append(nameNode5Attr);
				//nameNode5.AppendChild(doc.CreateTextNode("IC"));
				certNode.AppendChild(nameNode5);

				XmlNode nameNode6 = doc.CreateElement("attribute");
				XmlAttribute nameNode6Attr = doc.CreateAttribute("name");
				nameNode6Attr.Value = "SN";
				nameNode6.Attributes.Append(nameNode6Attr);
				//nameNode6.AppendChild(doc.CreateTextNode("IC"));
				certNode.AppendChild(nameNode6);

				XmlNode nameNode7 = doc.CreateElement("attribute");
				XmlAttribute nameNode7Attr = doc.CreateAttribute("name");
				nameNode7Attr.Value = "CA";
				nameNode7.Attributes.Append(nameNode7Attr);
				//nameNode7.AppendChild(doc.CreateTextNode("IC"));
				certNode.AppendChild(nameNode7);

				XmlNode nameNode8 = doc.CreateElement("attribute");
				XmlAttribute nameNode8Attr = doc.CreateAttribute("name");
				nameNode8Attr.Value = "TC";
				nameNode8.Attributes.Append(nameNode8Attr);
				nameNode8.AppendChild(doc.CreateTextNode("SG"));
				certNode.AppendChild(nameNode8);

				XmlNode nameNode9 = doc.CreateElement("attribute");
				XmlAttribute nameNode9Attr = doc.CreateAttribute("name");
				nameNode9Attr.Value = "AP";
				nameNode9.Attributes.Append(nameNode9Attr);
				nameNode9.AppendChild(doc.CreateTextNode("1"));
				certNode.AppendChild(nameNode9);

				XmlNode nameNode10 = doc.CreateElement("attribute");
				XmlAttribute nameNode10Attr = doc.CreateAttribute("name");
				nameNode10Attr.Value = "VD";
				nameNode10.Attributes.Append(nameNode10Attr);
				//nameNode10.AppendChild(doc.CreateTextNode("IC"));
				certNode.AppendChild(nameNode10);

				XmlNode fileNode = doc.CreateElement("file");
				requestNode.AppendChild(fileNode);

				XmlNode nameNode11 = doc.CreateElement("attribute");
				XmlAttribute nameNode11Attr = doc.CreateAttribute("name");
				nameNode11Attr.Value = "type";
				nameNode11.Attributes.Append(nameNode11Attr);
				nameNode11.AppendChild(doc.CreateTextNode("pdf"));
				fileNode.AppendChild(nameNode11);

				XmlNode pdfNode = doc.CreateElement("pdf");
				requestNode.AppendChild(pdfNode);


				XmlNode pageNode = doc.CreateElement("page");
				pageNode.AppendChild(doc.CreateTextNode("1"));
				pdfNode.AppendChild(pageNode);

				XmlNode coodNode = doc.CreateElement("cood");
				if (Session["Region"].ToString() == "C")
				{
					coodNode.AppendChild(doc.CreateTextNode("450,40"));
				}
				else
				{
					coodNode.AppendChild(doc.CreateTextNode("400,45"));
				}
				pdfNode.AppendChild(coodNode);


				XmlNode sizeNode = doc.CreateElement("size");
				if (Session["Region"].ToString() == "C")
				{
					sizeNode.AppendChild(doc.CreateTextNode("120,60"));
				}
				else
				{
					sizeNode.AppendChild(doc.CreateTextNode("165,60"));
				}


				pdfNode.AppendChild(sizeNode);

				XmlNode dataNode = doc.CreateElement("data");
				dataNode.AppendChild(doc.CreateTextNode(file));
				requestNode.AppendChild(dataNode);

				StringWriter sw = new StringWriter();
				XmlTextWriter tx = new XmlTextWriter(sw);
				doc.WriteTo(tx);

				string aa = sw.ToString();// 
										  //string aa="<request><command>pkiNetworkSign</command> <ts>2019-03-25T12:23:11.3820412+05:30</ts> <txn>unique id</txn> ";
										  //				doc.Save(Server.MapPath("filedddddddde.xml"));	
										  //				
										  //				RegisterStartupScript("abc","<script language=JavaScript> abc('"+aa+"'); </script>");   


				string fname = lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim();
				doc.Save(Server.MapPath("IC_XML/" + fname + ".xml"));


				RegisterStartupScript("abc", "<script language=JavaScript> abc('" + aa + "','" + fname + "'); </script>");


				conn.Close();
				conn.Dispose();
				GC.Collect();

			}

		}




		#region File Upload 

		private void MoveMatchingFile(string sourceFile, string destinationFile)
		{
			if (!File.Exists(destinationFile)) File.Copy(sourceFile, destinationFile);
		}


		private string[] GetAmendment()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn.Open();

			string str = "SELECT AMENDMENT_DETAIL FROM IC_PO_AMENDMENT WHERE CASE_NO = '" + CASE_NO + "' AND PO_NO = '" + lblPONO.Text + "'";

			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet ds = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(str, conn);
			OracleCommand myOracleCommand = new OracleCommand(str, conn);
			conn.Open();
			da.SelectCommand = myOracleCommand;
			//conn.Close();
			da.Fill(ds, "Table");
			string[] finalamend = null;
			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					string[] arramend = Convert.ToString(ds.Tables[0].Rows[0][0]).Split('#');

					finalamend = new string[arramend.Length];
					finalamend = Amendments(arramend, getSorteddated(arramend));
				}
			}

			return finalamend;

		}


		private DateTime[] getSorteddated(string[] arramend)
		{
			try
			{
				DateTime[] arramendSortedated = new DateTime[arramend.Length];

				for (int i = 0; i < arramend.Length; i++)
				{
					//
					if (arramend[i] == "") continue;
					//
					string[] dataamnd = arramend[i].Split(';')[1].Split('/');

					string actualdt = dataamnd[1] + "/" + dataamnd[0] + "/" + dataamnd[2];

					arramendSortedated[i] = Convert.ToDateTime(actualdt);
					//arramendSortedated[i] = Convert.ToDateTime(arramend[i].Split(';')[1]);
				}

				if (arramendSortedated != null) { Array.Sort(arramendSortedated); }
				return arramendSortedated;
			}
			catch (Exception ex)
			{
				throw;
			}

		}
		private string[] Amendments(string[] amendments, DateTime[] amenddates)
		{
			string[] Arramendments = new string[amendments.Length];
			string[] ArramendmentsSelected = new string[amendments.Length];
			int i = 0;

			if (amenddates == null) return null;

			foreach (DateTime item in amenddates)
			{
				for (int j = 0; j < amendments.Length; j++)
				{
					if (amendments[j] == "") continue;

					string[] dataamnd = amendments[j].Split(';')[1].Split('/');

					string actualdt = dataamnd[1] + "/" + dataamnd[0] + "/" + dataamnd[2];


					string dtstr1 = Convert.ToDateTime(actualdt).ToShortDateString();


					//string dtstr1 = Convert.ToDateTime(amendments[j].Split(';')[1]).ToShortDateString();
					if (DateTime.Compare(Convert.ToDateTime(dtstr1), Convert.ToDateTime(item)) == 0 && getselectedamend(ArramendmentsSelected, j.ToString()))
					{
						Arramendments[i] = amendments[j];
						ArramendmentsSelected[i] = j.ToString();
					}
				}
				i++;
			}
			return Arramendments;
		}

		private bool getselectedamend(string[] selectedamend, string newamnd)
		{
			foreach (string item in selectedamend)
			{
				if (item == newamnd)
				{
					return false;
				}
			}
			return true;
		}

		private bool IsValidQty(double pinspqty, double prejectedqty, double ppassedqty)
		{
			//TxtQTY_TO_INSP
			//TxtQTY_REJECTED
			//TxtQTY_PASSED
			double inspqty = 0;
			double rejectedqty = 0;
			double passedqty = 0;

			inspqty = Convert.ToDouble(pinspqty);
			rejectedqty = Convert.ToDouble(prejectedqty);
			passedqty = Convert.ToDouble(ppassedqty);

			if ((rejectedqty + passedqty) > inspqty)
			{
				return false;

			}
			return true;

		}

		private static string RemoveSpecChr(string pstr)
		{
			string rtnStr = "";
			rtnStr = Regex.Replace(pstr, "[ ](?=[ ])|[^-_A-Za-z0-9 ]+", new MatchEvaluator(CapText));
			//Regex.Replace(
			return rtnStr;
		}

		static string CapText(Match m)
		{
			//////			// Get the matched string.
			//////			string x = m.ToString();
			//////			// If the first char is lower case...
			//////			if (char.IsLower(x[0])) 
			//////			{
			//////				// Capitalize it.
			//////				return char.ToUpper(x[0]) + x.Substring(1, x.Length-1);
			//////			}
			//////			return x;
			return "";
		}


		private void btnSaveICData_Click(object sender, System.EventArgs e)
		{

			//TxtItemDesc.Text = RemoveSpecChr(TxtItemDesc.Text.Trim());

			//TxtItemRemarkeh.Text = RemoveSpecChr(TxtItemRemarkeh.Text.Trim());


			//txtRemarks.Text = RemoveSpecChr(txtRemarks.Text.Trim());


			//txtHologram.Text = RemoveSpecChr(txtHologram.Text.Trim());

			if (ddlCondignee.SelectedValue == "0")
			{
				DisplayAlert("Please select consignee !");

				return;
			}
			if (!IsValidQty(Convert.ToDouble(TxtQTY_TO_INSP.Text), Convert.ToDouble(TxtQTY_REJECTED.Text), Convert.ToDouble(TxtQTY_PASSED.Text)))
			{
				DisplayAlert(" QTY REJECTED + QTY PASSED should not be greater than (>) QTY TO INSP !");
				return;
			}
			if (txtLabtstrptdt.Text != "")
			{
				string[] arrLabtstrptdt = txtLabtstrptdt.Text.Trim().Split('/');

				string dtlabtr = arrLabtstrptdt[1] + "/" + arrLabtstrptdt[0] + "/" + arrLabtstrptdt[2];

				DateTime Labtstrptdt = Convert.ToDateTime(dtlabtr);

				if (DateTime.Compare(DateTime.Now, Labtstrptdt) < 0)
				{
					DisplayAlert("Please enter valid date for Case Lab report receipt Date!");
					return;
				}
			}

			//            string[] amend1 = GetAmendment();
			//            string amend2 = "";
			//            string amend3 = "";
			//            string amend4 = "";
			//            string amend5 = "";
			//
			//            if (amend1.Length >= 1)
			//            {
			//                amend2 = amend1[amend1.Length - 1];
			//                if (amend1.Length >= 2)
			//                {
			//                    amend3 = amend1[amend1.Length - 2];
			//                    if (amend1.Length >= 3)
			//                    {
			//                        amend4 = amend1[amend1.Length - 3];
			//                        if (amend1.Length >= 4)
			//                            amend5 = amend1[amend1.Length - 4];
			//                        else amend3 = amend1[3];
			//                    }
			//                    else amend3 = amend1[2];
			//                }
			//                else amend3 = amend1[1];
			//            }
			//            else amend2 = amend1[0];

			string strpath = Server.MapPath("IE_IMAGES") + @"\Default" + @"\Blank.jpg";
			string strpath2 = Server.MapPath("IE_IMAGES") + @"\Default" + @"\Blank.jpg";


			if (ddlIELST.SelectedValue != "SELECT STAMP")
			{
				strpath = Server.MapPath("IE_IMAGES") + @"\" + wIECD + @"\" + ddlIELST.SelectedValue + ".jpg";
			}

			if (ddlIELST2.SelectedValue != "SELECT STAMP")
			{
				strpath2 = Server.MapPath("IE_IMAGES") + @"\" + wIECD + @"\" + ddlIELST2.SelectedValue + ".jpg";
			}

			//string IEImage = LoadImage(strpath);

			//			File2OleDbBlob(strpath);

			//kamta start here//
			if (Session["Region"].ToString() == "C")
			{
				man_type_o = Convert.ToString(lstmantype.SelectedValue);
			}
			else
			{
				man_type_o = "";
			}
			//kamta end here//

			string str = (TxtCUM_QTY_PREV_OFFERED.Text.Trim() == "") ? "0" : TxtCUM_QTY_PREV_OFFERED.Text.Trim();

			string updateQuery1 = "Update IC_INTERMEDIATE set consgn_call_status = 'Z' ";

			//updateQuery1 += ", IE_CD = " + wIECD + "  ";
			//updateQuery1 += ", IE_STAMPS_DETAIL   = '" + ddlIELST.SelectedValue + "' ";

			updateQuery1 += ", ITEM_SRNO_PO = " + ddlItems.SelectedValue.Trim() + " ";
			updateQuery1 += ", ITEM_DESC_PO = '" + TxtItemDesc.Text.Trim() + "' ";
			updateQuery1 += ", ITEM_REMARK = '" + TxtItemRemarkeh.Text.Trim() + "' ";
			updateQuery1 += ", QTY_ORDERED = " + TxtQTYORDERED.Text.Trim() + " ";
			updateQuery1 += ", CUM_QTY_PREV_OFFERED = " + TxtCUM_QTY_PREV_OFFERED.Text.Trim() + " ";
			updateQuery1 += ", CUM_QTY_PREV_PASSED = " + TxtCUM_QTY_PREV_PASSED.Text.Trim() + " ";
			updateQuery1 += ", QTY_TO_INSP = " + TxtQTY_TO_INSP.Text.Trim() + " ";
			updateQuery1 += ", QTY_PASSED = " + TxtQTY_PASSED.Text.Trim() + " ";
			updateQuery1 += ", QTY_REJECTED = " + TxtQTY_REJECTED.Text.Trim() + " ";
			updateQuery1 += ", QTY_DUE = " + TxtQTY_DUE.Text.Trim() + "  ";
			updateQuery1 += ", PO_NO = '" + lblPONO.Text.Trim() + "'  ";


			if (ChkUnitdtl.Checked == true)
				updateQuery1 += " , UNIT_DTL = '" + TxtUnit.Text.Trim() + "' ";
			//updateQuery1 += ", LAB_TST_RECT_DT = TO_date('" + txtLabtstrptdt.Text.Trim() + "', 'dd/mm/yyyy')  ";
			//updateQuery1 += ", REASON_OF_REJECTION = '" + txtRemarks.Text.Trim() + "'  ";
			//updateQuery1 += ", REMARK = '" + txtRemarks.Text.Trim() + "'  ";
			//updateQuery1 += ", HOLOGRAM = '" + txtHologram.Text.Trim() + "'  ";
			//updateQuery1 += ", LAB_TST_RECT_DT = '" + txtLabtstrptdt.Text.Trim() + "' ";



			//updateQuery1 += ", LAB_TST_RECT_DT =  TO_date('" + txtLabtstrptdt.Text.Trim() + "', 'dd/mm/yyyy') ";



			updateQuery1 += " where ITEM_SRNO_PO = '" + ddlItems.SelectedValue.Trim() + "' and  CASE_NO = '" + CASE_NO.Trim() + "' and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";

			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn.Open();
			OracleTransaction myTrans = conn.BeginTransaction();

			try
			{


				OracleCommand myUpdateCommand = new OracleCommand(updateQuery1);
				myUpdateCommand.Transaction = myTrans;
				myUpdateCommand.Connection = conn;
				myUpdateCommand.ExecuteNonQuery();

				//myTrans.Commit();
				//conn.Close();

				updateQuery1 = " Update IC_INTERMEDIATE set IE_STAMP = '" + strpath + "',IE_STAMP2 = '" + strpath2 + "'  , IE_STAMPS_DETAIL   = '" + ddlIELST.SelectedValue + "', IE_STAMPS_DETAIL2   = '" + ddlIELST2.SelectedValue + "' ";
				updateQuery1 += " where IE_CD = " + wIECD + " ";
				//conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				//conn.Open();
				//OracleTransaction myTrans = conn.BeginTransaction();
				myUpdateCommand = new OracleCommand(updateQuery1);
				myUpdateCommand.Transaction = myTrans;
				myUpdateCommand.Connection = conn;
				myUpdateCommand.ExecuteNonQuery();


				updateQuery1 = " Update IC_INTERMEDIATE set REASON_OF_REJECTION = '" + txtRemarks.Text.Trim() + "' ,PASSED_INST_NO = '" + txtPassed_Inst_NO.Text.Trim() + "', LAB_TST_RECT_DT = TO_date('" + txtLabtstrptdt.Text.Trim() + "', 'dd/mm/yyyy'), HOLOGRAM = '" + txtHologram.Text.Trim() + "', REMARK = '" + txtRemarks.Text.Trim() + "', MAN_TYPE = '" + man_type_o + "', DISPATCH_PACKING_NO = '" + Textdispac.Text.Trim() + "', INVOICE_NO = '" + Textinvoice.Text.Trim() + "', NAME_OF_IE = '" + Textnameie.Text.Trim() + "', CONSIGNEE_DESG = '" + Textconsdesc.Text.Trim() + "' ";
				//updateQuery1 = " Update IC_INTERMEDIATE set REASON_OF_REJECTION = '" + txtRemarks.Text.Trim() + "' , LAB_TST_RECT_DT = TO_date('" + txtLabtstrptdt.Text.Trim() + "', 'dd/mm/yyyy'), HOLOGRAM = '" + txtHologram.Text.Trim() + "', REMARK = '" + txtRemarks.Text.Trim() + "'   ";
				updateQuery1 += " where CASE_NO = '" + CASE_NO.Trim() + "' and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "'";
				//updateQuery1 += " where CASE_NO = '" + CASE_NO.Trim() + "' and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";
				//conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				//conn.Open();
				//OracleTransaction myTrans = conn.BeginTransaction();
				myUpdateCommand = new OracleCommand(updateQuery1);
				myUpdateCommand.Transaction = myTrans;
				myUpdateCommand.Connection = conn;
				myUpdateCommand.ExecuteNonQuery();

				string upteditbl = " ";

				if (ChkConsdtl.Checked == true)
					upteditbl += " , CONSIGNEE_DTL = '" + TxtCondigneedtl.Text.Trim() + "' ";
				if (ChkBPOdtl.Checked == true)
					upteditbl += " , BPO_DTL = '" + TxtBPO.Text.Trim() + "' ";
				if (ChecGBPOdt1.Checked == true)
					upteditbl += " , GOV_BILL_AUTH = '" + TextGBPO.Text.Trim() + "' ";
				if (ChkManufacturerdtl.Checked == true)
					upteditbl += " , PUR_DTL = '" + TxtManufacturer.Text.Trim() + "' ";
				if (ChkPurchasingAuthoritydtl.Checked == true)
					upteditbl += " , PUR_AUT_DTL = '" + TxtPurchasingAuthority.Text.Trim() + "' ";
				//				if(ChkOFINtlhk.Checked==true)
				upteditbl += " , OFF_INST_NO_DTL = '" + TxtOFIN.Text.Trim() + "' ";
				//if(ChkUnitdtl.Checked==true)
				//upteditbl += " , UNIT_DTL = '" + TxtUnit.Text.Trim() + "' ";


				if (upteditbl.Trim() != "")
				{
					updateQuery1 = " Update IC_INTERMEDIATE set  " + upteditbl.Trim().Substring(1);
					updateQuery1 += " where CASE_NO = '" + CASE_NO.Trim() + "' and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "'";
					myUpdateCommand = new OracleCommand(updateQuery1);
					myUpdateCommand.Transaction = myTrans;
					myUpdateCommand.Connection = conn;
					myUpdateCommand.ExecuteNonQuery();
				}


				myTrans.Commit();
				conn.Close();


				SaveUpdateVisits(TXTVISITS_DATES.Text.Trim());

				BtnSaveAmnd_Click(null, null);

				//if (myTrans.Connection != null)
				//                {
				//
				//                }

				DisplayAlert("Changes are done Successfully!!!");

			}
			catch (Exception ex)
			{
				myTrans.Rollback();
				conn.Close();
				conn.Dispose();
				DisplayAlert("Changes are not done Successfully!!!");

			}



			//Reset();
		}

		//
		private void File2OleDbBlob()
		{
			string SourceFilePath = "";
			string SourceFilePath2 = "";

			SourceFilePath = Server.MapPath("IE_IMAGES") + @"\Default" + @"\Blank.jpg";
			SourceFilePath2 = Server.MapPath("IE_IMAGES") + @"\Default" + @"\Blank.jpg";
			//
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			DataSet ds = new DataSet();
			string str = "SELECT * FROM IC_INTERMEDIATE WHERE IE_CD=" + wIECD + " ";

			OracleDataAdapter da = new OracleDataAdapter(str, conn);
			OracleCommand myOracleCommand = new OracleCommand(str, conn);
			conn.Open();
			da.SelectCommand = myOracleCommand;
			conn.Close();
			da.Fill(ds, "Table");

			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					foreach (DataRow itemDR in ds.Tables[0].Rows)
					{
						//SourceFilePath =@"D:\RBS\IE_IMAGES\Default\Blank.jpg";
						//SourceFilePath2 =@"D:\RBS\IE_IMAGES\Default\Blank.jpg";

						if (Convert.ToString(itemDR["IE_STAMP"]) != "")
							SourceFilePath = Convert.ToString(itemDR["IE_STAMP"]);
						if (Convert.ToString(itemDR["IE_STAMP2"]) != "")
							SourceFilePath2 = Convert.ToString(itemDR["IE_STAMP2"]);
						break;
					}
				}
			}
			//

			if (SourceFilePath == "") return;

			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn.Open();
			//OracleTransaction myTrans = conn.BeginTransaction();
			OracleCommand myUpdateCommand = new OracleCommand("UPDATE IC_INTERMEDIATE SET IE_STAMP_IMAGE=:Picture , IE_STAMP_IMAGE1=:Picture1 where case_no = '" + CASE_NO + "' and CALL_SNO ='" + CALL_SNO + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') and CONSIGNEE_CD = '" + ddlCondignee.SelectedValue + "'");
			//myUpdateCommand.Transaction = myTrans;
			myUpdateCommand.Connection = conn;


			//OleDbConnection cn = new OleDbConnection("provider=sqloledb;server=localhost;user id=myuser;password=mypassword;initial catalog=NorthWind");
			//OleDbCommand cmd = new OleDbCommand("UPDATE IC_INTERMEDIATE SET IE_STAMP_IMAGE=? ", cn);
			System.IO.FileStream fs = new System.IO.FileStream(SourceFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
			byte[] b = new byte[fs.Length];
			fs.Read(b, 0, b.Length);
			fs.Close();

			fs = new System.IO.FileStream(SourceFilePath2, System.IO.FileMode.Open, System.IO.FileAccess.Read);
			byte[] b1 = new byte[fs.Length];
			fs.Read(b1, 0, b1.Length);
			fs.Close();

			//OleDbParameter P = new OleDbParameter("@Picture", OleDbType.LongVarBinary, b.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b);

			OracleParameter p = new OracleParameter("Picture", OracleDbType.Blob, b.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b);

			OracleParameter p1 = new OracleParameter("Picture1", OracleDbType.Blob, b1.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b1);

			myUpdateCommand.Parameters.Add(p);
			myUpdateCommand.Parameters.Add(p1);
			//conn.Open();
			//cmd.ExecuteNonQuery();
			//conn.Close();

			try
			{
				myUpdateCommand.ExecuteNonQuery();



				//				if (myTrans.Connection != null)
				//				{
				//					myTrans.Commit();
				conn.Close();
				//				}

			}
			catch (Exception ex)
			{
				//myTrans.Rollback();
				conn.Close();

				DisplayAlert("Changes are not done Successfully!!!" + ex.Message);

			}


			////			OleDbConnection cn = new OleDbConnection("provider=sqloledb;server=localhost;user id=myuser;password=mypassword;initial catalog=NorthWind");
			////			OleDbCommand cmd = new OleDbCommand("UPDATE IC_INTERMEDIATE SET IE_STAMP_IMAGE=? ", cn);
			////			System.IO.FileStream fs = new System.IO.FileStream(SourceFilePath, IO.FileMode.Open, IO.FileAccess.Read);
			////			byte b;
			////			fs.Read(b, 0, b.Length);
			////			fs.Close();
			////			OleDbParameter P = new OleDbParameter("@Picture", OleDbType.LongVarBinary, b.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b);
			////			cmd.Parameters.Add(P);
			////			cn.Open();
			////			cmd.ExecuteNonQuery();
			////			cn.Close();
		}


		//=======================================================
		//Service provided by Telerik (www.telerik.com)
		//Conversion powered by Refactoring Essentials.
		//Twitter: @telerik
		//Facebook: facebook.com/telerik
		//=======================================================

		//

		private void File2OleDbBlob2Null()
		{

			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn.Open();
			//OracleTransaction myTrans = conn.BeginTransaction();
			// //OracleCommand myUpdateCommand = new OracleCommand("UPDATE IC_INTERMEDIATE SET IE_STAMP_IMAGE=:Picture,IE_STAMP_IMAGE1=:Picture1  where case_no = '" + CASE_NO + "' and CALL_SNO ='" + CALL_SNO + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') and CONSIGNEE_CD = '"+ ddlCondignee.SelectedValue +"' ");

			OracleCommand myUpdateCommand = new OracleCommand("UPDATE IC_INTERMEDIATE SET IE_STAMP_IMAGE=EMPTY_BLOB(),IE_STAMP_IMAGE1=EMPTY_BLOB()  where case_no = '" + CASE_NO + "' and CALL_SNO ='" + CALL_SNO + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') and CONSIGNEE_CD = '" + ddlCondignee.SelectedValue + "' ");

			// //OracleCommand myUpdateCommand = new OracleCommand("UPDATE IC_INTERMEDIATE SET IE_STAMP_IMAGE=:Picture,IE_STAMP_IMAGE1=:Picture1  where case_no = '" + CASE_NO + "' and CALL_SNO ='" + CALL_SNO + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') ");
			//myUpdateCommand.Transaction = myTrans;
			myUpdateCommand.Connection = conn;


			//OleDbConnection cn = new OleDbConnection("provider=sqloledb;server=localhost;user id=myuser;password=mypassword;initial catalog=NorthWind");
			//OleDbCommand cmd = new OleDbCommand("UPDATE IC_INTERMEDIATE SET IE_STAMP_IMAGE=? ", cn);
			//			System.IO.FileStream fs = new System.IO.FileStream(SourceFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
			//			byte[] b= new byte[fs.Length];
			//			fs.Read(b, 0, b.Length);
			//			fs.Close();
			//OleDbParameter P = new OleDbParameter("@Picture", OleDbType.LongVarBinary, b.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b);
			////	////byte[] b= new byte[" ".Length];
			////	////byte[] b1= new byte[" ".Length];
			////	////OracleParameter p = new OracleParameter("Picture",OracleType.Blob,b.Length,ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current,   b);
			////	////OracleParameter p1 = new OracleParameter("Picture",OracleType.Blob,b1.Length,ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b1);
			////	////		
			////	////myUpdateCommand.Parameters.Add(p);
			////	////myUpdateCommand.Parameters.Add(p1);
			//conn.Open();
			//cmd.ExecuteNonQuery();
			//conn.Close();

			try
			{
				myUpdateCommand.ExecuteNonQuery();



				//				if (myTrans.Connection != null)
				//				{
				//					myTrans.Commit();
				conn.Close();
				//				}

			}
			catch (Exception ex)
			{
				//myTrans.Rollback();
				conn.Close();

				DisplayAlert("Changes are not done Successfully!!!" + ex.Message);

			}


			////			OleDbConnection cn = new OleDbConnection("provider=sqloledb;server=localhost;user id=myuser;password=mypassword;initial catalog=NorthWind");
			////			OleDbCommand cmd = new OleDbCommand("UPDATE IC_INTERMEDIATE SET IE_STAMP_IMAGE=? ", cn);
			////			System.IO.FileStream fs = new System.IO.FileStream(SourceFilePath, IO.FileMode.Open, IO.FileAccess.Read);
			////			byte b;
			////			fs.Read(b, 0, b.Length);
			////			fs.Close();
			////			OleDbParameter P = new OleDbParameter("@Picture", OleDbType.LongVarBinary, b.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b);
			////			cmd.Parameters.Add(P);
			////			cn.Open();
			////			cmd.ExecuteNonQuery();
			////			cn.Close();
		}

		private string LoadImage(string FilePath)
		{
			byte[] Image = null;
			string str = "";
			try
			{
				FileStream fs = new FileStream(FilePath,
					System.IO.FileMode.Open, System.IO.FileAccess.Read);
				Image = new byte[fs.Length];
				fs.Read(Image, 0, Convert.ToInt32(fs.Length));
				fs.Close();
				str = System.Text.Encoding.ASCII.GetString(Image, 0, Image.Length);

				//objDataRow[strImageField] = Image;


			}
			catch (Exception ex)
			{
				Response.Write("<font color=red>" + ex.Message + "</font>");
			}
			return str;
		}		

		private void UpdateAmend()
		{
			try
			{
				string[] amend1 = GetAmendment();
				string amend2 = "";
				string amend3 = "";
				string amend4 = "";
				string amend5 = "";

				if (amend1 == null) return;

				if (amend1.Length >= 1)
				{
					amend2 = amend1[amend1.Length - 1];
					if (amend1.Length >= 2)
					{
						amend3 = amend1[amend1.Length - 2];
						if (amend1.Length >= 3)
						{
							amend4 = amend1[amend1.Length - 3];
							if (amend1.Length >= 4)
								amend5 = amend1[amend1.Length - 4];
							//else amend3 = amend1[3];
						}
						//else amend3 = amend1[2];
					}
					//else amend3 = amend1[1];
				}
				//else amend2 = amend1[0];



				string updateQuery1 = "Update IC_INTERMEDIATE set ";
				updateQuery1 += " AMENDMENT_1 = '" + GetFormatedAmend(amend2) + "'  ";
				updateQuery1 += ", AMENDMENT_2 = '" + GetFormatedAmend(amend3) + "'  ";
				updateQuery1 += ", AMENDMENT_3 = '" + GetFormatedAmend(amend4) + "'  ";
				updateQuery1 += ", AMENDMENT_4 = '" + GetFormatedAmend(amend5) + "'  ";


				//updateQuery1 += ", LAB_TST_RECT_DT =  TO_date('" + txtLabtstrptdt.Text.Trim() + "', 'dd/mm/yyyy') ";



				//updateQuery1 += " where CASE_NO = '" + CASE_NO.Trim() + "' AND PO_NO = '" + lblPONO.Text + "'";
				updateQuery1 += " where CASE_NO = '" + CASE_NO.Trim() + "'";

				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn.Open();
				OracleTransaction myTrans1 = conn.BeginTransaction();
				OracleCommand myUpdateCommand = new OracleCommand(updateQuery1);
				myUpdateCommand.Transaction = myTrans1;
				myUpdateCommand.Connection = conn;

				try
				{
					myUpdateCommand.ExecuteNonQuery();


					//SaveUpdateVisits(TXTVISITS_DATES.Text.Trim(), myTrans);

					if (myTrans1.Connection != null)
					{
						myTrans1.Commit();
						conn.Close();
					}

					//DisplayAlert("Changes are done Successfully!!!");

				}
				catch (Exception ex)
				{
					myTrans1.Rollback();
					conn.Close();
					DisplayAlert(ex.Message);
				}
			}
			catch (Exception ex)
			{
				DisplayAlert(ex.Message);
			}
		}

		private string GetFormatedAmend(string amend)
		{
			string formatedamend = "";
			string[] arrformatamenddt = null;
			if (amend != null && amend.Trim() != "")
			{
				string[] arrAmend = amend.Split(';');

				if (arrAmend != null)
				{
					//for(int i=0;i<=1;i++)
					{
						formatedamend += arrAmend[0].PadRight(100, ' ');
						//arrformatamenddt = arrAmend[1].Split('/');
						formatedamend += " " + arrAmend[1];
						//formatedamend+=" "+arrformatamenddt[1]+"/"+arrformatamenddt[0]+"/"+arrformatamenddt[2];
					}
				}
			}
			return formatedamend;
		}

		private void SetAccepted()
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			DataSet ds = new DataSet();
			//string str = "SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO='" + CASE_NO.Trim() + "' AND CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO='" + CALL_SNO + "' AND CONSIGNEE_CD ='" + ddlCondignee.SelectedValue + "'";
			string str = "SELECT * FROM IC_INTERMEDIATE WHERE (CONSGN_CALL_STATUS = 'A' OR CONSGN_CALL_STATUS = 'R') AND consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "' AND CASE_NO='" + CASE_NO.Trim() + "' AND CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO='" + CALL_SNO + "' ORDER BY DATETIME DESC";
			OracleDataAdapter da = new OracleDataAdapter(str, conn);
			OracleCommand myOracleCommand = new OracleCommand(str, conn);
			conn.Open();
			da.SelectCommand = myOracleCommand;
			conn.Close();
			da.Fill(ds, "Table");

			btnSaveICData.Enabled = true;
			btnRefresh.Enabled = true;
			BtnSaveAmnd.Enabled = true;

			bool oneonly = false;
			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					btnSaveICData.Enabled = false;
					btnRefresh.Enabled = false;
					BtnSaveAmnd.Enabled = false;
				}
			}
		}

		private void DdlCondignee_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtBKNO1.Text = "";
			txtSetNo1.Text = "";
			Reset();

			FillItems();

			SetAccepted();
		}

		private void setItemVal()
		{
			string str = "";
			str += " SELECT     CLR.CASE_NO, CLR.Call_SNO, CLR.Call_Recv_dt, POM.Region_Code, POM.RLY_CD, CLR.Call_Install_No, TIE.IE_Sname, VND.Vend_Name, 					 ";
			str += " VND.Vend_Add1, NVL(VND.Vend_Add2, ' ') AS Vend_Add2, VCT.City AS Vend_City, MFG.Vend_Name AS MFG_Name, MFG.Vend_Add1 AS MFG_Add1,                           ";
			str += " NVL(MFG.Vend_Add2, ' ') AS MFG_Add2, NVL(MCT.City, ' ') AS MFG_City, CLR.MFG_PLACE, POM.PO_NO, POM.PO_DT, NVL(CON.CONSIGNEE_DESIG,                          ";
			str += " ' ') AS CONSIGNEE_DESIG, CON.CONSIGNEE_CD, CCT.City AS CONSIGNEE_CITYNAME, NVL(CON.CONSIGNEE_DEPT, ' ') AS CONSIGNEE_DEPT,                                  ";
			str += " NVL(CON.CONSIGNEE_FIRM, ' ') AS CONSIGNEE_FIRM, NVL(PUR.CONSIGNEE_DESIG, ' ') AS PUR_DESIG, PUR.CONSIGNEE_CD AS PUR_CD,                                     ";
			str += " NVL(PUR.CONSIGNEE_DEPT, ' ') AS PUR_DEPT, NVL(PUR.CONSIGNEE_FIRM, ' ') AS PUR_FIRM, NVL(PCT.City, ' ') AS PUR_City, CDT.ITEM_SRNO_PO,                       ";
			str += " CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.ITEM_DESC_PO ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.ITEM_DESC_PO ELSE                                 ";
			str += " CDT.ITEM_DESC_PO END END AS ITEM_DESC_PO, UOM.UOM_S_DESC, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_ORDERED, 0)                                   ";
			str += " ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_ORDERED, 0) ELSE NVL(CDT.QTY_ORDERED, 0) END END AS QTY_ORDERED,                                   ";
			str += " CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.CUM_QTY_PREV_OFFERED, 0)                                                                                    ";
			str += " ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.CUM_QTY_PREV_OFFERED, 0) ELSE NVL(CDT.CUM_QTY_PREV_OFFERED, 0)                                         ";
			str += " END END AS CUM_QTY_PREV_OFFERED, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.CUM_QTY_PREV_PASSED, 0)                                                    ";
			str += " ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.CUM_QTY_PREV_PASSED, 0) ELSE NVL(CDT.CUM_QTY_PREV_PASSED, 0)                                           ";
			str += " END END AS CUM_QTY_PREV_PASSED, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_TO_INSP, 0)                                                             ";
			str += " ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_TO_INSP, 0) ELSE NVL(CDT.QTY_TO_INSP, 0) END END AS QTY_TO_INSP,                                   ";
			str += " CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_PASSED, 0)                                                                                              ";
			str += " ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_PASSED, 0) ELSE NVL(CDT.QTY_PASSED, 0) END END AS QTY_PASSED,                                      ";
			str += " CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_REJECTED, 0)                                                                                            ";
			str += " ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_REJECTED, 0) ELSE NVL(CDT.QTY_REJECTED, 0) END END AS QTY_REJECTED,                                ";
			str += " CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_DUE, 0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_DUE, 0)                                ";
			str += " ELSE NVL(CDT.QTY_DUE, 0) END END AS QTY_DUE,                                                                                                                ";
			str += " CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.HOLOGRAM ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN ICI.HOLOGRAM ELSE ICI.HOLOGRAM                            ";
			str += " END END AS HOLOGRAM, ICI.NUM_VISITS, PRM.VISIT_DATES, BOF.BPO_NAME, BOF.BPO_ORGN, BCT.City, NVL(CLR.HOLOGRAM, '    ')                                       ";
			str += " AS HOLOGRAMORG, NVL(ICI.REMARK, ' ') AS REMARK, CLR.DT_INSP_DESIRE, NVL(ICI.ITEM_REMARK, 'NO REMARK') AS ITEM_REMARK,                                       ";
			str += " substr(ICI.AMENDMENT_1, 0, 99) AS AMENDMENT_1, substr(ICI.AMENDMENT_1, 100, 20) AS AMENDMENTDT_1, substr(ICI.AMENDMENT_2, 0, 99)                            ";
			str += " AS AMENDMENT_2, substr(ICI.AMENDMENT_2, 100, 20) AS AMENDMENTDT_2, substr(ICI.AMENDMENT_3, 0, 99) AS AMENDMENT_3,                                           ";
			str += " substr(ICI.AMENDMENT_3, 100, 20) AS AMENDMENTDT_3, substr(ICI.AMENDMENT_4, 0, 99) AS AMENDMENT_4, substr(ICI.AMENDMENT_4, 100, 20)                          ";
			str += " AS AMENDMENTDT_4, ICI.BK_NO, ICI.SET_NO, ICI.VISITS_DATES, ICI.LAB_TST_RECT_DT,                                                                             ";
			str += " ICI.PASSED_INST_NO                                                                                                                                          ";
			str += " , NVL(CONSIGNEE_DTL, '') AS CONSIGNEE_DTL, NVL(BPO_DTL, '') AS BPO_DTL, NVL(PUR_DTL, '') AS PUR_DTL,														 ";
			str += "  NVL(PUR_AUT_DTL, '') AS PUR_AUT_DTL, NVL(OFF_INST_NO_DTL, '') AS OFF_INST_NO_DTL, NVL(UNIT_DTL, '') AS UNIT_DTL, NVL(DISPATCH_PACKING_NO, '') AS DISPATCH_PACKING_NO, NVL(INVOICE_NO, '') AS INVOICE_NO, NVL(NAME_OF_IE, '') AS NAME_OF_IE, NVL(GOV_BILL_AUTH, '') AS GOV_BILL_AUTH, NVL(MAN_TYPE, '') AS MAN_TYPE, NVL(CONSIGNEE_DESG, '') AS CONSIGNEE_DESG											 ";
			str += " FROM         RPT_PRM_Inspection_Certificate PRM INNER JOIN                                                                                                  ";
			str += " T17_Call_Register CLR ON CLR.CASE_NO = PRM.CASE_NO AND CLR.Call_Recv_dt = PRM.CALL_RECV_DT AND                                                              ";
			str += " CLR.Call_SNO = PRM.Call_SNO INNER JOIN                                                                                                                      ";
			str += " T18_Call_Details CDT ON CLR.CASE_NO = CDT.CASE_NO AND CLR.Call_Recv_dt = CDT.Call_Recv_dt AND CLR.Call_SNO = CDT.Call_SNO INNER JOIN                        ";
			str += " T13_PO_Master POM ON CLR.CASE_NO = POM.CASE_NO LEFT OUTER JOIN                                                                                              ";
			str += " T15_PO_DETAIL POD ON CLR.CASE_NO = POD.CASE_NO AND CDT.ITEM_SRNO_PO = POD.ITEM_SRNO LEFT OUTER JOIN                                                         ";
			str += " T04_UOM UOM ON POD.UOM_CD = UOM.UOM_CD LEFT OUTER JOIN                                                                                                      ";
			str += " T09_IE TIE ON CLR.IE_CD = TIE.IE_CD LEFT OUTER JOIN                                                                                                         ";
			str += " T05_Vendor VND ON POM.Vend_Cd = VND.Vend_Cd LEFT OUTER JOIN                                                                                                 ";
			str += " T03_City VCT ON VND.Vend_City_Cd = VCT.City_Cd LEFT OUTER JOIN                                                                                              ";
			str += " T05_Vendor MFG ON CLR.MFG_CD = MFG.Vend_Cd LEFT OUTER JOIN                                                                                                  ";
			str += " T03_City MCT ON MFG.Vend_City_Cd = MCT.City_Cd LEFT OUTER JOIN                                                                                              ";
			str += " T14_PO_BPO BPO ON CLR.CASE_NO = BPO.CASE_NO AND CDT.CONSIGNEE_CD = BPO.CONSIGNEE_CD LEFT OUTER JOIN                                                         ";
			str += " T12_BILL_PAYING_OFFICER BOF ON BPO.BPO_CD = BOF.BPO_CD LEFT OUTER JOIN                                                                                      ";
			str += " T03_City BCT ON BOF.BPO_City_Cd = BCT.City_Cd LEFT OUTER JOIN                                                                                               ";
			str += " T06_Consignee CON ON BPO.CONSIGNEE_CD = CON.CONSIGNEE_CD LEFT OUTER JOIN                                                                                    ";
			str += " T03_City CCT ON CON.CONSIGNEE_CITY = CCT.City_Cd LEFT OUTER JOIN                                                                                            ";
			str += " T06_Consignee PUR ON POM.PURCHASER_CD = PUR.CONSIGNEE_CD LEFT OUTER JOIN                                                                                    ";
			str += " T03_City PCT ON PUR.CONSIGNEE_CITY = PCT.City_Cd INNER JOIN                                                                                                 ";
			str += " IC_INTERMEDIATE ICI ON ICI.CASE_NO = CDT.CASE_NO AND ICI.Call_Recv_dt = CDT.Call_Recv_dt AND ICI.Call_SNO = CDT.Call_SNO AND                                ";
			str += " CDT.CONSIGNEE_CD = ICI.CONSIGNEE_CD AND CDT.ITEM_SRNO_PO = ICI.ITEM_SRNO_PO AND PRM.CONSIGNEE_CD = ICI.CONSIGNEE_CD                                         ";
			str += " WHERE     ICI.ITEM_SRNO_PO IS NOT NULL                                                                                                                      ";
			str += " AND CDT.ITEM_SRNO_PO = '" + ddlItems.SelectedValue.Trim() + "' and  CDT.CASE_NO = '" + CASE_NO.Trim() + "'                                                  ";
			str += " AND CDT.CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CDT.CALL_SNO = '" + CALL_SNO + "'                                                  ";
			str += " and ICI.consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'                                                                               ";
			str += " ORDER BY CON.CONSIGNEE_CD, POD.ITEM_SRNO                                                                                                                    ";



			////////            str += "Select CLR.CASE_NO, CLR.Call_SNO, CLR.Call_Recv_dt, POM.Region_Code, POM.RLY_CD, CLR.Call_Install_No, TIE.IE_Sname,                        ";
			////////            str += "VND.Vend_Name, VND.Vend_Add1, NVL(VND.Vend_Add2, ' ') as Vend_Add2, VCT.City as Vend_City,                                                 ";
			////////            str += "MFG.Vend_Name as MFG_Name, MFG.Vend_Add1 as MFG_Add1, NVL(MFG.Vend_Add2, ' ') as MFG_Add2, MCT.City as MFG_City,                           ";
			////////            str += "CLR.MFG_PLACE, POM.PO_NO, POM.PO_DT, NVL(CON.CONSIGNEE_DESIG, ' ') as CONSIGNEE_DESIG, CON.CONSIGNEE_CD, CCT.City as CONSIGNEE_CITYNAME,   ";
			////////            str += "NVL(CON.CONSIGNEE_DEPT, ' ') as CONSIGNEE_DEPT, NVL(CON.CONSIGNEE_FIRM, ' ') as CONSIGNEE_FIRM,                                            ";
			////////            str += "NVL(PUR.CONSIGNEE_DESIG, ' ') AS PUR_DESIG, PUR.CONSIGNEE_CD AS PUR_CD,                                                                    ";
			////////            str += "NVL(PUR.CONSIGNEE_DEPT, ' ') AS PUR_DEPT, NVL(PUR.CONSIGNEE_FIRM, ' ') as PUR_FIRM, NVL(PCT.City, ' ') as PUR_City,                        ";
			////////            str += "CDT.ITEM_SRNO_PO,CASE WHEN CONSGN_CALL_STATUS ='Z' THEN ICI.ITEM_DESC_PO ELSE CDT.ITEM_DESC_PO END AS ITEM_DESC_PO, UOM.UOM_S_DESC,        ";
			////////            str += "CASE WHEN CONSGN_CALL_STATUS ='Z' THEN NVL(ICI.QTY_ORDERED,0) ELSE NVL(CDT.QTY_ORDERED, 0) END AS QTY_ORDERED	,						   ";
			////////            str += "CASE WHEN CONSGN_CALL_STATUS ='Z' THEN NVL(ICI.CUM_QTY_PREV_OFFERED,0) ELSE NVL(CDT.CUM_QTY_PREV_OFFERED, 0) END AS CUM_QTY_PREV_OFFERED , ";
			////////            str += "CASE WHEN CONSGN_CALL_STATUS ='Z' THEN NVL(ICI.CUM_QTY_PREV_PASSED,0) ELSE NVL(CDT.CUM_QTY_PREV_PASSED, 0) END AS CUM_QTY_PREV_PASSED	,  ";
			////////            str += "CASE WHEN CONSGN_CALL_STATUS ='Z' THEN NVL(ICI.QTY_TO_INSP,0) ELSE NVL(CDT.QTY_TO_INSP, 0) END AS QTY_TO_INSP ,							   ";
			////////            str += "CASE WHEN CONSGN_CALL_STATUS ='Z' THEN NVL(ICI.QTY_PASSED,0) ELSE NVL(CDT.QTY_PASSED, 0) END AS QTY_PASSED	,							   ";
			////////            str += "CASE WHEN CONSGN_CALL_STATUS ='Z' THEN NVL(ICI.QTY_REJECTED,0) ELSE NVL(CDT.QTY_REJECTED, 0) END AS QTY_REJECTED ,						   ";
			////////            str += "CASE WHEN CONSGN_CALL_STATUS ='Z' THEN NVL(ICI.QTY_DUE,0) ELSE NVL(CDT.QTY_DUE, 0) END AS QTY_DUE	,									   ";
			////////			str += "CASE WHEN CONSGN_CALL_STATUS ='Z' THEN NVL(ICI.HOLOGRAM,'    ') ELSE NVL(CLR.HOLOGRAM, '    ') END AS HOLOGRAM	, NVL(ICI.ITEM_REMARK,'NO REMARK') AS ITEM_REMARK,				";
			////////			str += "PRM.NUM_VISITS,PRM.VISIT_DATES, BOF.BPO_NAME, BOF.BPO_ORGN, BCT.City, NVL(CLR.HOLOGRAM, '    ') as HOLOGRAMORG,NVL(ICI.REMARK,' ') as REMARK, CLR.DT_INSP_DESIRE         ";
			////////			str += "From RPT_PRM_Inspection_Certificate PRM                                                                                                    ";
			////////			str += "Inner Join T17_Call_Register CLR ON CLR.CASE_NO = PRM.CASE_NO And CLR.Call_Recv_dt = PRM.CALL_RECV_DT  and CLR.Call_SNO = PRM.Call_SNO     ";
			////////			str += "Inner Join T18_Call_Details CDT ON CLR.CASE_NO = CDT.CASE_NO And CLR.Call_Recv_dt = CDT.Call_Recv_dt                                       ";
			////////			str += "And CLR.Call_SNO = CDT.Call_SNO                                                                                                            ";
			////////			str += "Inner Join T13_PO_Master POM ON CLR.CASE_NO = POM.CASE_NO                                                                                  ";
			////////			str += "Left Outer Join T15_PO_DETAIL POD ON CLR.CASE_NO = POD.CASE_NO and CDT.ITEM_SRNO_PO = POD.ITEM_SRNO                                        ";
			////////			str += "Left Outer Join T04_UOM UOM ON POD.UOM_CD = UOM.UOM_CD                                                                                     ";
			////////			str += "Left Outer Join T09_IE TIE ON CLR.IE_CD = TIE.IE_CD                                                                                        ";
			////////			str += "Left Outer Join T05_Vendor VND ON POM.Vend_Cd = VND.Vend_Cd                                                                                ";
			////////			str += "Left Outer Join T03_City VCT ON VND.Vend_City_Cd = VCT.City_Cd                                                                             ";
			////////			str += "Left Outer Join T05_Vendor MFG ON CLR.MFG_CD = MFG.Vend_Cd                                                                                 ";
			////////			str += "Left Outer Join T03_City MCT ON MFG.Vend_City_Cd = MCT.City_Cd                                                                             ";
			////////			str += "Left Outer Join T14_PO_BPO BPO ON CLR.CASE_NO = BPO.CASE_NO  And CDT.CONSIGNEE_CD = BPO.CONSIGNEE_CD                                       ";
			////////			str += "Left Outer Join T12_BILL_PAYING_OFFICER BOF ON BPO.BPO_CD = BOF.BPO_CD                                                                     ";
			////////			str += "Left Outer Join T03_City BCT ON BOF.BPO_City_Cd = BCT.City_Cd                                                                              ";
			////////			str += "Left Outer Join T06_Consignee CON ON BPO.CONSIGNEE_CD = CON.CONSIGNEE_CD                                                                   ";
			////////			str += "Left Outer Join T03_City CCT ON CON.CONSIGNEE_CITY = CCT.City_Cd                                                                           ";
			////////			str += "Left Outer Join T06_Consignee PUR ON POM.PURCHASER_CD = PUR.CONSIGNEE_CD                                                                   ";
			////////			str += "Left Outer Join T03_City PCT ON PUR.CONSIGNEE_CITY = PCT.City_Cd                                                                           ";
			////////			str += "left outer join IC_INTERMEDIATE ICI ON CDT.ITEM_SRNO_PO = ICI.ITEM_SRNO_PO                                                                 ";
			////////			str += " where CDT.ITEM_SRNO_PO = '" + ddlItems.SelectedValue.Trim() + "' and  CDT.CASE_NO = '" + CASE_NO.Trim() + "' AND CDT.CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CDT.CALL_SNO = '" + CALL_SNO + "' and ICI.consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";
			////////			//str += "where CDT.CONSIGNEE_CD = '" + ddlCondignee.SelectedValue + "' and CDT.ITEM_SRNO_PO ='" + ddlItems.SelectedValue + "'                       ";
			////////			str += "Order By CON.CONSIGNEE_CD, POD.ITEM_SRNO                                                                                                   ";


			//			str += SELECT     CLR.CASE_NO, CLR.Call_SNO, CLR.Call_Recv_dt, POM.Region_Code, POM.RLY_CD, CLR.Call_Install_No, TIE.IE_Sname, VND.Vend_Name, 
			//			str += VND.Vend_Add1, NVL(VND.Vend_Add2, ' ') AS Vend_Add2, VCT.City AS Vend_City, MFG.Vend_Name AS MFG_Name, MFG.Vend_Add1 AS MFG_Add1, 
			//			str += NVL(MFG.Vend_Add2, ' ') AS MFG_Add2, MCT.City AS MFG_City, CLR.MFG_PLACE, POM.PO_NO, POM.PO_DT, NVL(CON.CONSIGNEE_DESIG, ' ') 
			//			str += AS CONSIGNEE_DESIG, CON.CONSIGNEE_CD, CCT.City AS CONSIGNEE_CITYNAME, NVL(CON.CONSIGNEE_DEPT, ' ') AS CONSIGNEE_DEPT, 
			//			str += NVL(CON.CONSIGNEE_FIRM, ' ') AS CONSIGNEE_FIRM, NVL(PUR.CONSIGNEE_DESIG, ' ') AS PUR_DESIG, PUR.CONSIGNEE_CD AS PUR_CD, 
			//			str += NVL(PUR.CONSIGNEE_DEPT, ' ') AS PUR_DEPT, NVL(PUR.CONSIGNEE_FIRM, ' ') AS PUR_FIRM, NVL(PCT.City, ' ') AS PUR_City, CDT.ITEM_SRNO_PO, 
			//			str += CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.ITEM_DESC_PO ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.ITEM_DESC_PO ELSE
			//			str += CDT.ITEM_DESC_PO END END AS ITEM_DESC_PO, UOM.UOM_S_DESC, 
			//			str += CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.QTY_ORDERED ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.QTY_ORDERED ELSE
			//			str += CDT.QTY_ORDERED END END AS QTY_ORDERED, 
			//			str += CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.CUM_QTY_PREV_OFFERED ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.CUM_QTY_PREV_OFFERED
			//			str += ELSE CDT.CUM_QTY_PREV_OFFERED END END AS CUM_QTY_PREV_OFFERED, 
			//			str += CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.CUM_QTY_PREV_PASSED ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.CUM_QTY_PREV_PASSED
			//			str += ELSE CDT.CUM_QTY_PREV_PASSED END END AS CUM_QTY_PREV_PASSED, 
			//			str += CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.QTY_TO_INSP ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.QTY_TO_INSP ELSE CDT.QTY_TO_INSP
			//			str += END END AS QTY_TO_INSP, 
			//			str += CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.QTY_PASSED ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.QTY_PASSED ELSE CDT.QTY_PASSED
			//			str += END END AS QTY_PASSED, 
			//			str += CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.QTY_REJECTED ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.QTY_REJECTED ELSE
			//			str += CDT.QTY_REJECTED END END AS QTY_REJECTED, 
			//			str += CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.QTY_DUE ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.QTY_DUE ELSE CDT.QTY_DUE
			//			str += END END AS QTY_DUE, 
			//			str += CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.HOLOGRAM ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN ICI.HOLOGRAM ELSE ICI.HOLOGRAM
			//			str += END END AS HOLOGRAM, PRM.NUM_VISITS, PRM.VISIT_DATES, BOF.BPO_NAME, BOF.BPO_ORGN, BCT.City, NVL(CLR.HOLOGRAM, '    ') 
			//			str += AS HOLOGRAMORG, NVL(ICI.REMARK, ' ') AS REMARK, CLR.DT_INSP_DESIRE, NVL(ICI.ITEM_REMARK, 'NO REMARK') AS ITEM_REMARK, 
			//			str += substr(ICI.AMENDMENT_1, 0, 99) AS AMENDMENT_1, substr(ICI.AMENDMENT_1, 100, 20) AS AMENDMENTDT_1, substr(ICI.AMENDMENT_2, 0, 99) 
			//			str += AS AMENDMENT_2, substr(ICI.AMENDMENT_2, 100, 20) AS AMENDMENTDT_2, substr(ICI.AMENDMENT_3, 0, 99) AS AMENDMENT_3, 
			//			substr(ICI.AMENDMENT_3, 100, 20) AS AMENDMENTDT_3, substr(ICI.AMENDMENT_4, 0, 99) AS AMENDMENT_4, substr(ICI.AMENDMENT_4, 100, 20) 
			//			str += AS AMENDMENTDT_4, ICI.BK_NO, ICI.SET_NO, ICI.VISITS_DATES, ICI.IE_STAMP_IMAGE
			//			str += FROM         RPT_PRM_Inspection_Certificate PRM INNER JOIN
			//			str += T17_Call_Register CLR ON CLR.CASE_NO = PRM.CASE_NO AND CLR.Call_Recv_dt = PRM.CALL_RECV_DT AND 
			//			str += CLR.Call_SNO = PRM.Call_SNO INNER JOIN
			//			str += T18_Call_Details CDT ON CLR.CASE_NO = CDT.CASE_NO AND CLR.Call_Recv_dt = CDT.Call_Recv_dt AND CLR.Call_SNO = CDT.Call_SNO INNER JOIN
			//			str += T13_PO_Master POM ON CLR.CASE_NO = POM.CASE_NO LEFT OUTER JOIN
			//			str += T15_PO_DETAIL POD ON CLR.CASE_NO = POD.CASE_NO AND CDT.ITEM_SRNO_PO = POD.ITEM_SRNO LEFT OUTER JOIN
			//			str += T04_UOM UOM ON POD.UOM_CD = UOM.UOM_CD LEFT OUTER JOIN
			//			str += T09_IE TIE ON CLR.IE_CD = TIE.IE_CD LEFT OUTER JOIN
			//			str += T05_Vendor VND ON POM.Vend_Cd = VND.Vend_Cd LEFT OUTER JOIN
			//			str += T03_City VCT ON VND.Vend_City_Cd = VCT.City_Cd LEFT OUTER JOIN
			//			str += T05_Vendor MFG ON CLR.MFG_CD = MFG.Vend_Cd LEFT OUTER JOIN
			//			str += T03_City MCT ON MFG.Vend_City_Cd = MCT.City_Cd LEFT OUTER JOIN
			//			str += T14_PO_BPO BPO ON CLR.CASE_NO = BPO.CASE_NO AND CDT.CONSIGNEE_CD = BPO.CONSIGNEE_CD LEFT OUTER JOIN
			//			str += T12_BILL_PAYING_OFFICER BOF ON BPO.BPO_CD = BOF.BPO_CD LEFT OUTER JOIN
			//			T03_City BCT ON BOF.BPO_City_Cd = BCT.City_Cd LEFT OUTER JOIN
			//			T06_Consignee CON ON BPO.CONSIGNEE_CD = CON.CONSIGNEE_CD LEFT OUTER JOIN
			//			T03_City CCT ON CON.CONSIGNEE_CITY = CCT.City_Cd LEFT OUTER JOIN
			//			T06_Consignee PUR ON POM.PURCHASER_CD = PUR.CONSIGNEE_CD LEFT OUTER JOIN
			//			T03_City PCT ON PUR.CONSIGNEE_CITY = PCT.City_Cd INNER JOIN
			//			IC_INTERMEDIATE ICI ON ICI.CASE_NO = CDT.CASE_NO AND ICI.Call_Recv_dt = CDT.Call_Recv_dt AND ICI.Call_SNO = CDT.Call_SNO AND 
			//			CDT.CONSIGNEE_CD = ICI.CONSIGNEE_CD AND CDT.ITEM_SRNO_PO = ICI.ITEM_SRNO_PO
			//			WHERE     ICI.ITEM_SRNO_PO IS NOT NULL
			//			ORDER BY CON.CONSIGNEE_CD, POD.ITEM_SRNO

			//CASE WHEN CONSGN_CALL_STATUS ='Z' THEN ICI.ITEM_DESC_PO ELSE CDT.ITEM_DESC_PO END AS ITEM_DESC_PO
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet ds = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(str, conn);
			OracleCommand myOracleCommand = new OracleCommand(str, conn);
			conn.Open();
			da.SelectCommand = myOracleCommand;
			//conn.Close();
			da.Fill(ds, "Table");

			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					foreach (DataRow itemDR in ds.Tables[0].Rows)
					{
						TxtItemDesc.Text = Convert.ToString(itemDR["ITEM_DESC_PO"]);
						TxtItemRemarkeh.Text = Convert.ToString(itemDR["ITEM_REMARK"]);
						TxtQTYORDERED.Text = Convert.ToString(itemDR["QTY_ORDERED"]);
						TxtCUM_QTY_PREV_OFFERED.Text = Convert.ToString(itemDR["CUM_QTY_PREV_OFFERED"]);
						TxtCUM_QTY_PREV_PASSED.Text = Convert.ToString(itemDR["CUM_QTY_PREV_PASSED"]);
						TxtQTY_TO_INSP.Text = Convert.ToString(itemDR["QTY_TO_INSP"]);
						TxtQTY_PASSED.Text = Convert.ToString(itemDR["QTY_PASSED"]);
						TxtQTY_REJECTED.Text = Convert.ToString(itemDR["QTY_REJECTED"]);
						TxtQTY_DUE.Text = Convert.ToString(itemDR["QTY_DUE"]);

						//KAMTA START CODE FOR DATA CAPTURING//
						Textdispac.Text = Convert.ToString(itemDR["DISPATCH_PACKING_NO"]);
						Textinvoice.Text = Convert.ToString(itemDR["INVOICE_NO"]);
						Textnameie.Text = Convert.ToString(itemDR["NAME_OF_IE"]);
						Textconsdesc.Text = Convert.ToString(itemDR["CONSIGNEE_DESG"]);
						if (Session["Region"].ToString() == "C")
						{
							if (Convert.ToString(itemDR["MAN_TYPE"]) != "")
							{
								lstmantype.SelectedValue = Convert.ToString(itemDR["MAN_TYPE"]);
								lstman();
								lstmantype.Enabled = false;

							}
							else
							{
								lstmantype.Enabled = true;

							}
						}
						//

						//
						if (Convert.ToString(itemDR["CONSIGNEE_DTL"]).Trim() != "")
							TxtCondigneedtl.Text = Convert.ToString(itemDR["CONSIGNEE_DTL"]);
						else
							TxtCondigneedtl.Text = Convert.ToString(itemDR["CONSIGNEE_DESIG"]) + "/" + Convert.ToString(itemDR["CONSIGNEE_DEPT"]) + "/" + Convert.ToString(itemDR["CONSIGNEE_FIRM"]) + "/" + Convert.ToString(itemDR["CONSIGNEE_CITYNAME"]);

						if (Convert.ToString(itemDR["BPO_DTL"]).Trim() != "")
							TxtBPO.Text = Convert.ToString(itemDR["BPO_DTL"]);
						else
							TxtBPO.Text = Convert.ToString(itemDR["BPO_NAME"]) + "/" + Convert.ToString(itemDR["BPO_ORGN"]) + "/" + Convert.ToString(itemDR["CITY"]);

						//ADD KAMTA FOR GOVERNING BILL AUTHORITY//
						if (Convert.ToString(itemDR["GOV_BILL_AUTH"]).Trim() != "")
							TextGBPO.Text = Convert.ToString(itemDR["GOV_BILL_AUTH"]);
						else
							TextGBPO.Text = Convert.ToString(itemDR["BPO_NAME"]) + "/" + Convert.ToString(itemDR["BPO_ORGN"]) + "/" + Convert.ToString(itemDR["CITY"]);
						//END KAMTA//


						if (Convert.ToString(itemDR["PUR_DTL"]).Trim() != "")
							TxtManufacturer.Text = "M/s " + Convert.ToString(itemDR["PUR_DTL"]);
						else
							TxtManufacturer.Text = "M/s " + Convert.ToString(itemDR["MFG_NAME"]);

						if (Convert.ToString(itemDR["PUR_AUT_DTL"]).Trim() != "")
							TxtPurchasingAuthority.Text = Convert.ToString(itemDR["PUR_AUT_DTL"]);
						else
							TxtPurchasingAuthority.Text = Convert.ToString(itemDR["PUR_DESIG"]) + "/" + Convert.ToString(itemDR["PUR_FIRM"]) + "/" + Convert.ToString(itemDR["PUR_CITY"]);


						if (Convert.ToString(itemDR["OFF_INST_NO_DTL"]).Trim() != "")
							TxtOFIN.Text = Convert.ToString(itemDR["OFF_INST_NO_DTL"]);
						else
							TxtOFIN.Text = Convert.ToString(itemDR["CALL_INSTALL_NO"]);

						if (Convert.ToString(itemDR["UNIT_DTL"]).Trim() != "")
							TxtUnit.Text = Convert.ToString(itemDR["UNIT_DTL"]);
						else
							TxtUnit.Text = Convert.ToString(itemDR["UOM_S_DESC"]);



					}
				}
			}
		}


		private void DdlItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Reset();
			setItemVal();
			//FillItems(false);
		}

		private void btnCancelFiles_Click(object sender, System.EventArgs e)
		{

			ddlCondignee.SelectedValue = "0";
			//ddlItems.SelectedValue = "0";
			txtBKNO1.Text = "";
			txtSetNo1.Text = "";
			Reset();
			FillItems();
			//Call_Cancellation_Entry();


		}

		private void lstCallStatus_SelectedIndexChanged()
		{
			Label32.Visible = true;
			//txtRemarks.Visible = false;
			Label4.Visible = false;
			Label5.Visible = true;
			txtHologram.Visible = true;
			Label6.Visible = true;
			//Label9.Visible = true;
			//File1.Visible = true;
			//File2.Visible = true;
			//File3.Visible = true;
			//Label7.Visible = true;
			//Label10.Visible = true;
			btnViewIC.Visible = true;
		}
		private void AcceptedFun()
		{
			string str = "";
			string sql = "Select Distinct T051.VEND_NAME,(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE," +
				"T18.ITEM_DESC_PO,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,to_char(DT_INSP_DESIRE,'dd/mm/yyyy')DESIRE_DT," +
				"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,to_char(T17.CALL_LETTER_DT,'dd/mm/yyyy') CALL_LETTER_DT," +
				"T17.CALL_LETTER_NO,T17.CALL_STATUS,to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy') CALL_STATUS_DT,T17.CALL_CANCEL_STATUS,T17.CALL_CANCEL_CHARGES,T17.BK_NO,T17.SET_NO,T17.REMARKS,T17.HOLOGRAM, T052.VEND_CONTACT_PER_1 MFG_PERS,T052.VEND_CONTACT_TEL_1 MFG_PHONE,T17.CALL_SNO," +
				"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT) COUNT " +
				"From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052 " +
				"Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO  and " +
				"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT AND T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and " +
				"(T17.CASE_NO='" + CASE_NO + "' and T17.CALL_RECV_DT=to_date('" + CALL_RECV_DT + "','dd/mm/yyyy') and T17.CALL_SNO='" + CALL_SNO + "') and " +
				"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) " +
				"Order by T051.VEND_NAME,CALL_MARK_DT";

			try
			{
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

				OracleCommand cmd = new OracleCommand();
				cmd.CommandText = sql;
				cmd.Connection = conn;
				if (conn.State != ConnectionState.Open)
					conn.Open();
				OracleDataReader readerB = cmd.ExecuteReader();
				
				while (readerB.Read())
				{
					
					lblCallDT.Text = Convert.ToString(readerB["CALL_RECV_DT"]);
					
					lblPONO.Text = Convert.ToString(readerB["PO_NO"]);
					lblPODT.Text = Convert.ToString(readerB["PO_DATE"]);
					lblCSNO.Text = Convert.ToString(readerB["CASE_NO"]);
					
					lblSNO.Text = Convert.ToString(readerB["CALL_SNO"]);					
					{						
					}
										
					if (Convert.ToString(readerB["CALL_STATUS"]) == "A")
					{						
						conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

						DataSet ds = new DataSet();
						str = "SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO = '" + lblCSNO.Text.Trim() + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";

						OracleDataAdapter da = new OracleDataAdapter(str, conn);
						OracleCommand myOracleCommand = new OracleCommand(str, conn);
						conn.Open();
						da.SelectCommand = myOracleCommand;
						//conn.Close();
						da.Fill(ds, "Table");

						if (ds.Tables.Count > 0)
						{
							if (ds.Tables[0].Rows.Count > 0)
							{
								foreach (DataRow itemDR in ds.Tables[0].Rows)
								{
									if (Convert.ToString(itemDR["CONSGN_CALL_STATUS"]) == "A")
									{										
										txtRemarks.Text = Convert.ToString(readerB["REMARKS"]);
										txtHologram.Text = Convert.ToString(readerB["HOLOGRAM"]);
									}
								}
							}
						}						
						btnViewIC.Visible = true;
					}
					else
					{
						
					}					
					txtSTDT.Text = Convert.ToString(readerB["CALL_STATUS_DT"]);					
				}
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
				txtSTDT.Text = Convert.ToString(cmd2.ExecuteScalar());
				conn.Close();				
			}
			catch (Exception ex)
			{
				//					string str; 
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn.Close();
			}
		}

		private void Reset()
		{

			//txtBKNO1.Text = "";
			//txtSetNo1.Text = "";
			txtBKNO1.Enabled = false;
			txtSetNo1.Enabled = false;
			TxtItemDesc.Text = "";
			TxtItemRemarkeh.Text = "";
			TxtQTYORDERED.Text = "";
			TxtCUM_QTY_PREV_OFFERED.Text = "";
			TxtCUM_QTY_PREV_PASSED.Text = "";
			TxtQTY_TO_INSP.Text = "";
			TxtQTY_PASSED.Text = "";
			TxtQTY_REJECTED.Text = "";
			TxtQTY_DUE.Text = "";
			Textdispac.Text = "";
			Textinvoice.Text = "";
			Textnameie.Text = "";
			Textconsdesc.Text = "";

			//txtRemarks.Text = "";
			//txtHologram.Text = "";
			//ddlIELST.SelectedValue = "0";
		}

		private string UpdateSet(DataTable dtTables)
		{
			string rtnStr = "";
			string actualRec = "";
			if (dtTables.Rows.Count > 0)
			{
				actualRec = Convert.ToString(dtTables.Rows[0]["AMENDMENT_DETAIL"]);

				string[] arractualRecHash = actualRec.Split('#');


				for (int i = 0; i < arractualRecHash.Length; i++)
				{
					string[] arrItem = Convert.ToString(arractualRecHash[i]).Split(';');
					////rtnStr += "#";
					//for (int j = 0; j < arrItem.Length - 1; j++)
					{
						try
						{
							////TextBox tb = (TextBox)Page.FindControl("TXTLblRow0_" + i + "Col_" + 0);
							////rtnStr += tb.Text.Trim().PadRight(100,' ') + ";";

							////tb = (TextBox)Page.FindControl("TXTLblRow0_" + i + "Col_" + 1);
							//DateTime datetimevd =  Convert.ToDateTime(tb.Text.Trim());
							////rtnStr += tb.Text.Trim().PadRight(10,' ')  + ";";
							///

							TextBox tb = (TextBox)Page.FindControl("TXTLblRow0_" + i + "Col_" + 0);

							TextBox tb1 = (TextBox)Page.FindControl("TXTLblRow0_" + i + "Col_" + 1);

							if (tb == null || tb1 == null) continue;

							if (tb.Text.Trim() != "" && tb1.Text.Trim() != "")
							{
								//string tbdate = "TXTLblRow0_" + i + "Col_" + 1;
								//tb1.Attributes.Add("OnBlur", "JavaScript:check_date(" + tbdate + ");");
								rtnStr += "#" + tb.Text.Trim().PadRight(100, ' ') + ";";
								rtnStr += tb1.Text.Trim().PadRight(10, ' ') + ";";
								rtnStr += wIECD;

							}
						}
						catch (Exception ex)
						{
							DisplayAlert(ex.Message);
						}
						//tb = (TextBox)Page.FindControl("TXTLblRow0_" + i + "Col_1");
						//rtnStr += tb.Text.Trim() + ";";

					}
					////rtnStr += wIECD;
				}
			}

			if (TxtAmnds.Text.Trim() != "")
			{
				try
				{
					//DateTime datetimevd =  Convert.ToDateTime(TxtAmndsdt.Text.Trim());

					rtnStr += "#" + TxtAmnds.Text.Trim().PadRight(100, ' ') + ";" + TxtAmndsdt.Text.Trim().PadRight(10, ' ') + ";" + wIECD;
				}
				catch (Exception ex)
				{
					DisplayAlert(ex.Message);
				}
			}

			if (rtnStr.Length > 1)
				return rtnStr.Substring(1);
			else return rtnStr;

		}
		//		private bool validateAmenddate(string amnddate)
		//		{
		//			string[] arramnddate = amnddate.Split('/');
		//			
		//	
		//			
		//
		//		}

		private bool validateAmendments()
		{

			if (TxtAmnds.Text.Trim() == "" || TxtAmndsdt.Text.Trim() == "")
			{
				return false;
			}
			return true;
		}


		private void BtnSaveAmnd_Click(object sender, EventArgs e)
		{
			
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string sqlQuery = "";

			//string itemSql = "select * from IC_PO_AMENDMENT where case_no = '" + CASE_NO + "' and po_no ='" + lblPONO.Text + "' ";
			string itemSql = "select * from IC_PO_AMENDMENT where case_no = '" + CASE_NO + "'";

			DataSet ds = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(itemSql, conn);
			OracleCommand myOracleCommand = new OracleCommand(itemSql, conn);
			conn.Open();
			da.SelectCommand = myOracleCommand;
			//conn.Close();
			da.Fill(ds, "Table");
			string strUpdateSet = "";
			if (ds.Tables.Count > 0)
			{
				strUpdateSet = UpdateSet(ds.Tables[0]);

				if (ds.Tables[0].Rows.Count > 0)
				{
					//sqlQuery += "Update IC_PO_AMENDMENT set AMENDMENT_DETAIL = '" + strUpdateSet + "' where case_no = '" + CASE_NO + "' and po_no ='" + lblPONO.Text + "' ";
					sqlQuery += "Update IC_PO_AMENDMENT set AMENDMENT_DETAIL = '" + strUpdateSet + "' where case_no = '" + CASE_NO + "' ";
				}
				else
				{
					if (!validateAmendments())
					{
						//DisplayAlert("Amendment or Amendment date can not be blanked!");
						return;
					}
					try
					{
						//DateTime datetimevd =  Convert.ToDateTime(TxtAmndsdt.Text.Trim());
					}
					catch (Exception ex)
					{
						DisplayAlert("Please enter valid amendment date -(DD/MM/YYYY)!");
						DisplayAlert(ex.Message);
						return;
					}

					sqlQuery += "Insert into  IC_PO_AMENDMENT (case_no,po_no,AMENDMENT_DETAIL) values ('" + CASE_NO + "' , '" + lblPONO.Text + "','" + TxtAmnds.Text.Trim().PadRight(100, ' ') + ";" + TxtAmndsdt.Text.Trim() + ";" + wIECD + "' ) ";
				}
			}

			OracleTransaction myTrans = conn.BeginTransaction();
			OracleCommand myUpdateCommand = new OracleCommand(sqlQuery);
			myUpdateCommand.Transaction = myTrans;
			myUpdateCommand.Connection = conn;

			try
			{
				myUpdateCommand.ExecuteNonQuery();

				if (myTrans.Connection != null)
				{
					myTrans.Commit();
					conn.Close();
				}

				UpdateAmend();


				DisplayAlert("Amendments are done Successfully!!!");

			}
			catch (Exception ex)
			{
				myTrans.Rollback();
				conn.Close();
				string err = ex.StackTrace;
				Response.Write(err);
				Response.End();
				DisplayAlert("Changes are not done Successfully!!!");				
			}
			FillAMENDMENTS(CASE_NO, lblPONO.Text);
			TxtAmnds.Text = "";
			TxtAmndsdt.Text = "";
		}



		private void FillAMENDMENTS(string caseNo, string poNo)
		{

			//TableAMNDSaved.Visible = false;
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string itemSql = "";

			//itemSql += "select * from IC_PO_AMENDMENT where case_no = '" + caseNo + "' and po_no ='" + poNo + "' ";

			itemSql += "select * from IC_PO_AMENDMENT where case_no = '" + caseNo + "' ";

			DataSet ds = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(itemSql, conn);
			OracleCommand myOracleCommand = new OracleCommand(itemSql, conn);
			conn.Open();
			da.SelectCommand = myOracleCommand;
			conn.Close();
			da.Fill(ds, "Table");

			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					PanelAmned.Controls.Clear();
					//Panel panel = (Panel)Page.FindControl("PanelAmned");
					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{

						FillHtmlTab(PanelAmned, ds.Tables[0].Rows[i]);
					}
				}
			}
		}

		private void FillHtmlTab(Panel panel, DataRow dr)
		{

			//Creat the Table and Add it to the Page
			Table table = new Table();
			table.ID = "TableAmends";
			table.Style.Add("border", "1");
			//table.Style.Add("bordercolor", "#b0c4de");
			table.Style.Add("cellspacing", "0");
			table.Style.Add("cellpadding", "0");
			//table.Style.Add("bgcolor", "aliceblue");

			table.BorderWidth = new Unit(2);
			table.BorderStyle = BorderStyle.Solid;

			TableRow tblhr = new TableRow();
			TableCell cell = new TableCell();
			Label lbl = new Label();

			lbl.Style.Add("font-weight", "bold");
			lbl.Style.Add("font-size", "8pt");
			lbl.Style.Add("color", "darkblue");
			lbl.Style.Add("font-family", "Verdana");

			lbl.ID = "hdLblRow_0";
			lbl.Text = "SNO.";
			// Add the control to the TableCell
			cell.Controls.Add(lbl);
			// Add the TableCell to the TableRow
			tblhr.Cells.Add(cell);

			cell = new TableCell();
			lbl = new Label();
			lbl.Style.Add("font-weight", "bold");
			lbl.Style.Add("font-size", "8pt");
			lbl.Style.Add("color", "darkblue");
			lbl.Style.Add("font-family", "Verdana");
			// Set a unique ID for each TextBox added
			lbl.ID = "hdLblRow_1";
			lbl.Text = "Amendments";
			// Add the control to the TableCell
			cell.Controls.Add(lbl);
			// Add the TableCell to the TableRow
			tblhr.Cells.Add(cell);

			cell = new TableCell();
			lbl = new Label();
			lbl.Style.Add("font-weight", "bold");
			lbl.Style.Add("font-size", "8pt");
			lbl.Style.Add("color", "darkblue");
			lbl.Style.Add("font-family", "Verdana");
			// Set a unique ID for each TextBox added
			lbl.ID = "hdLblRow_2";
			lbl.Text = "Date";
			// Add the control to the TableCell
			cell.Controls.Add(lbl);
			// Add the TableCell to the TableRow
			tblhr.Cells.Add(cell);

			table.Rows.Add(tblhr);
			panel.Controls.Add(table);
			//Page.Form.Controls.Add(table);

			if (table != null)
			{
				string[] arrAmnd = Convert.ToString(dr["AMENDMENT_DETAIL"]).Split('#');

				for (int i = 0; i < arrAmnd.Length; i++)
				{
					string[] arrdetail = Convert.ToString(arrAmnd[i]).Split(';');

					TableRow row = new TableRow();
					for (int j = 0; j < arrdetail.Length; j++)
					{
						if (arrdetail[j] != "")
							CreateAmdmtRows(row, arrdetail[j], i, j, (EnmAmend)j);
					}
					// And finally, add the TableRow to the Table
					table.Rows.Add(row);
					//TableAMNDSaved.Visible = true;
				}

			}
		}

		private void CreateAmdmtRows(TableRow row, string arrdetail, int i, int j, EnmAmend enmAmend)
		{
			switch (enmAmend)
			{
				case EnmAmend.Amendments:
					TableCell cell = new TableCell();
					Label lbl = new Label();
					//TextBox lbl = new TextBox();
					lbl.Style.Add("font-weight", "bold");
					lbl.Style.Add("font-size", "8pt");
					lbl.Style.Add("color", "darkblue");
					lbl.Style.Add("font-family", "Verdana");

					// Set a unique ID for each TextBox added
					lbl.ID = "LblRow0_" + i + "Col_" + j;
					lbl.Text = i.ToString();
					// Add the control to the TableCell
					cell.Controls.Add(lbl);
					// Add the TableCell to the TableRow
					row.Cells.Add(cell);

					cell = new TableCell();
					//lbl = new Label();
					TextBox Tlbl = new TextBox();
					Tlbl.Style.Add("font-weight", "bold");
					Tlbl.Style.Add("font-size", "8pt");
					Tlbl.Style.Add("color", "darkblue");
					Tlbl.Style.Add("font-family", "Verdana");
					// Set a unique ID for each TextBox added
					Tlbl.ID = "TXTLblRow0_" + i + "Col_" + j;
					Tlbl.Text = Convert.ToString(arrdetail);
					// Add the control to the TableCell
					cell.Controls.Add(Tlbl);
					// Add the TableCell to the TableRow
					row.Cells.Add(cell);
					break;
				case EnmAmend.AddUpdateDate:
					cell = new TableCell();
					Tlbl = new TextBox();
					Tlbl.Style.Add("font-weight", "bold");
					Tlbl.Style.Add("font-size", "8pt");
					Tlbl.Style.Add("color", "darkblue");
					Tlbl.Style.Add("font-family", "Verdana");
					// Set a unique ID for each TextBox added
					Tlbl.ID = "TXTLblRow0_" + i + "Col_" + j;
					Tlbl.Text = Convert.ToString(arrdetail);
					string tbdate = "TXTLblRow0_" + i + "Col_" + j;
					Tlbl.Attributes.Add("OnBlur", "JavaScript:check_date(" + tbdate + ");");
					// Add the control to the TableCell
					cell.Controls.Add(Tlbl);
					// Add the TableCell to the TableRow
					row.Cells.Add(cell);
					break;
				case EnmAmend.AddUpdateBy:
					//cell = new TableCell();
					//lbl = new Label();
					//// Set a unique ID for each TextBox added
					//lbl.ID = "TXTLblRow0_" + i + "Col_" + j;
					//lbl.Text = Convert.ToString(arrdetail);
					//// Add the control to the TableCell
					//cell.Controls.Add(lbl);
					//// Add the TableCell to the TableRow
					//row.Cells.Add(cell);
					break;
				default:
					break;
			}
		}

		private void FillVisites(string caseNo, string date, string callno)
		{

			//TableAMNDSaved.Visible = false;
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string itemSql = "";

			itemSql += "select * from IC_VISITS where case_no = '" + caseNo + "' and CALL_SNO ='" + callno + "' AND CALL_RECV_DT = TO_date('" + date + "', 'dd/mm/yyyy')  ";

			DataSet ds = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(itemSql, conn);
			OracleCommand myOracleCommand = new OracleCommand(itemSql, conn);
			conn.Open();
			da.SelectCommand = myOracleCommand;
			conn.Close();
			da.Fill(ds, "Table");

			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					//Panel panel = (Panel)Page.FindControl("PanelAmned");
					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{
						FillHtmlTab1(PanelVists, Convert.ToString(ds.Tables[0].Rows[i]["VISITS_DATES"]));
					}
				}
			}
		}



		private void FillHtmlTab1(Panel panel, string pVISITS_DATES)
		{

			//Creat the Table and Add it to the Page
			Table table = new Table();
			table.ID = "TableVisits";
			table.Style.Add("border", "1");
			table.Style.Add("bordercolor", "#b0c4de");
			table.Style.Add("cellspacing", "0");
			table.Style.Add("cellpadding", "0");
			table.Style.Add("bgcolor", "aliceblue");

			table.BorderWidth = new Unit(1);
			table.BorderStyle = BorderStyle.Solid;

			TableRow tblhr = new TableRow();
			TableCell cell = new TableCell();
			Label lbl = new Label();
			lbl.Style.Add("font-weight", "bold");
			lbl.Style.Add("font-size", "8pt");
			lbl.Style.Add("color", "darkblue");
			lbl.Style.Add("font-family", "Verdana");

			lbl.ID = "hdLblRow1_0";
			lbl.Text = "SNO.";
			// Add the control to the TableCell
			cell.Controls.Add(lbl);
			// Add the TableCell to the TableRow
			tblhr.Cells.Add(cell);

			cell = new TableCell();
			lbl = new Label();
			lbl.Style.Add("font-weight", "bold");
			lbl.Style.Add("font-size", "8pt");
			lbl.Style.Add("color", "darkblue");
			lbl.Style.Add("font-family", "Verdana");
			// Set a unique ID for each TextBox added
			lbl.ID = "hdLblRow1_1";
			lbl.Text = "Visits";
			// Add the control to the TableCell
			cell.Controls.Add(lbl);
			// Add the TableCell to the TableRow
			tblhr.Cells.Add(cell);

			//cell = new TableCell();
			//lbl = new Label();
			//// Set a unique ID for each TextBox added
			//lbl.ID = "hdLblRow_2";
			//lbl.Text = "Date";
			//// Add the control to the TableCell
			//cell.Controls.Add(lbl);
			//// Add the TableCell to the TableRow
			//tblhr.Cells.Add(cell);

			//cell = new TableCell();
			//lbl = new Label();
			//// Set a unique ID for each TextBox added
			//lbl.ID = "hdLblRow_3";
			//lbl.Text = "IE";
			//// Add the control to the TableCell
			//cell.Controls.Add(lbl);
			//// Add the TableCell to the TableRow
			//tblhr.Cells.Add(cell);



			table.Rows.Add(tblhr);
			panel.Controls.Add(table);
			//Page.Form.Controls.Add(table);

			if (table != null)
			{
				//string[] arrvisits = pVISITS_DATES.Split('#');

				//for (int i = 0; i < arrvisits.Length; i++)
				{
					string[] arrdetail = pVISITS_DATES.Split(',');

					//TableRow row = new TableRow();
					for (int j = 0; j < arrdetail.Length; j++)
					{
						TableRow row = new TableRow();
						CreateVIsitsRows(row, arrdetail[j], j, j);
						table.Rows.Add(row);
					}
					// And finally, add the TableRow to the Table

					//TableAMNDSaved.Visible = true;

					//Extracting the Dynamic Controls from the Table
					//TextBox tb = (TextBox)table.Rows[i].Cells[0].FindControl("TextBoxRow_" + i + "Col_" + j);
					//Use Request objects for getting the previous data of the dynamic textbox
					//tb.Text = Request.Form["TextBoxRow_" + i + "Col_" + j];

				}

			}
		}

		private void CreateVIsitsRows(TableRow row, string arrdetail, int i, int j)
		{
			TableCell cell = new TableCell();
			Label lbl = new Label();
			lbl.Style.Add("font-weight", "bold");
			lbl.Style.Add("font-size", "8pt");
			lbl.Style.Add("color", "darkblue");
			lbl.Style.Add("font-family", "Verdana");
			// Set a unique ID for each TextBox added
			lbl.ID = "LblRow_" + i + "Col_" + j;
			lbl.Text = (i + 1).ToString();
			// Add the control to the TableCell
			cell.Controls.Add(lbl);
			// Add the TableCell to the TableRow
			row.Cells.Add(cell);

			cell = new TableCell();
			TextBox txt = new TextBox();
			txt.Style.Add("font-weight", "bold");
			txt.Style.Add("font-size", "8pt");
			txt.Style.Add("color", "darkblue");
			txt.Style.Add("font-family", "Verdana");
			// Set a unique ID for each TextBox added
			txt.ID = "TXTLblRow_" + i + "Col_" + j;
			txt.Text = Convert.ToString(arrdetail);
			// Add the control to the TableCell
			cell.Controls.Add(txt);
			// Add the TableCell to the TableRow
			row.Cells.Add(cell);
		}
		
		private void GetVisitsChanges(bool pIsdefault)
		{
			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string visitChange = TXTVISITS_DATES.Text;

			string visitChangeleng = TXTVISITS_DATES.Text.Split(',').Length.ToString();

			string strvisits = "";

			strvisits += " SELECT CASE_NO, ";
			strvisits += " CALL_SNO, ";
			strvisits += " CALL_RECV_DT, ";
			strvisits += " COUNT(*) AS NUM_VISITS, ";
			strvisits += " LISTAGG(TO_CHAR(Visit_DT, 'DD.MM.YYYY'), ', ') within GROUP( ";
			strvisits += " ORDER BY Visit_DT ) AS VISIT_DATES ";
			strvisits += " FROM T47_IE_WORK_PLAN ";
			strvisits += " WHERE CASE_NO = '" + CASE_NO + "' ";
			strvisits += " AND CALL_SNO = " + CALL_SNO + " ";
			strvisits += " AND CALL_RECV_DT = to_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') ";
			strvisits += " GROUP BY CASE_NO, ";
			strvisits += " CALL_SNO, ";
			strvisits += " CALL_RECV_DT ";

			DataSet ds = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(strvisits, conn);
			OracleCommand myOracleCommand = new OracleCommand(strvisits, conn);
			conn.Open();
			da.SelectCommand = myOracleCommand;
			conn.Close();
			da.Fill(ds, "Table");

			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{
						visitChange = Convert.ToString(ds.Tables[0].Rows[i]["VISIT_DATES"]);
						SaveUpdateVisits(visitChange);
						//FillVisites(CASE_NO, CALL_RECV_DT, CALL_SNO);
					}
				}
				else
				{
					SaveUpdateVisits(visitChange);
				}
			}

		}

		private void SaveUpdateVisits(string visitChange)
		{

			OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string sqlQuery = "";


			sqlQuery += "select * from IC_INTERMEDIATE where case_no = '" + CASE_NO + "' and CALL_SNO ='" + CALL_SNO + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND VISITS_DATES IS NOT NULL ";

			DataSet ds = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(sqlQuery, conn1);
			OracleCommand myOracleCommand = new OracleCommand(sqlQuery, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			conn1.Close();
			da.Fill(ds, "Table");
			sqlQuery = "";
			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					if (TXTVISITS_DATES.Text.Trim() != "")
						sqlQuery += "Update IC_INTERMEDIATE set NUM_VISITS = " + TXTVISITS_DATES.Text.Trim().Split(',').Length + " , VISITS_DATES = '" + TXTVISITS_DATES.Text.Trim() + "' where case_no = '" + CASE_NO + "' and CALL_SNO ='" + CALL_SNO + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') ";
					else
					{
						sqlQuery += "Update IC_INTERMEDIATE set VISITS_DATES = VISITS_DATES,NUM_VISITS=NUM_VISITS where case_no = '" + CASE_NO + "' and CALL_SNO ='" + CALL_SNO + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') ";
						TXTVISITS_DATES.Text = Convert.ToString(ds.Tables[0].Rows[0]["VISITS_DATES"]);
					}
				}
				else
				{
					sqlQuery += "Update IC_INTERMEDIATE set NUM_VISITS = " + visitChange.Split(',').Length + ", VISITS_DATES = '" + visitChange + "' where case_no = '" + CASE_NO + "' and CALL_SNO ='" + CALL_SNO + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') ";
					TXTVISITS_DATES.Text = visitChange;
				}
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				//if (conn1.State != ConnectionState.Open)
				{
					conn1.Open();
					//myTrans = conn.BeginTransaction();
				}

				OracleTransaction myTrans1 = null;
				OracleCommand myUpdateCommand = null;
				//if (myTrans == null || myTrans.Connection == null)
				{
					myTrans1 = conn1.BeginTransaction();

					myUpdateCommand = new OracleCommand(sqlQuery);
					myUpdateCommand.Transaction = myTrans1;
				}
				//                else
				//                {
				//                    myUpdateCommand = new OracleCommand(sqlQuery);
				//                    myUpdateCommand.Transaction = myTrans;
				//                }
				myUpdateCommand.Connection = conn1;

				try
				{
					myUpdateCommand.ExecuteNonQuery();
					//if (myTrans == null || myTrans.Connection == null) 

					myTrans1.Commit();
					conn1.Close();
					//else myTrans.Commit();


					//myTrans.Commit();
					//conn.Close();
					//DisplayAlert("Changes are done Successfully!!!");

				}
				catch (Exception ex)
				{

					//if (myTrans == null) 
					myTrans1.Rollback();
					//                    else
					//myTrans.Rollback();
					conn1.Close();
					//DisplayAlert("Changes are not done Successfully!!!");
				}
				//FillVisites(CASE_NO, CALL_RECV_DT, CALL_SNO);
			}
			#endregion
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			conn.Open();
			OracleCommand cmdss = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			string ssd = Convert.ToString(cmdss.ExecuteScalar());
			conn.Close();



			OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//New Changes
			DataSet ds = new DataSet();
			string strt18 = "SELECT CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy') as CALL_RECV_DT,CALL_SNO,CONSIGNEE_CD,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_ORDERED,CUM_QTY_PREV_OFFERED,CUM_QTY_PREV_PASSED,QTY_TO_INSP,QTY_PASSED,QTY_REJECTED,QTY_DUE FROM T18_Call_Details WHERE CASE_NO = '" + lblCSNO.Text.Trim() + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";
			// //cmd = new OracleCommand("SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO = '" + CASE_NO.Trim() + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CONSIGNEE_CD = '" + CONSIGNEE_CD + "'", conn);
			OracleDataAdapter da = new OracleDataAdapter(strt18, conn1);
			OracleCommand myOracleCommand = new OracleCommand(strt18, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			conn1.Close();
			da.Fill(ds, "Table");

			OracleCommand myInsertCommand1 = null;
			OracleTransaction myTrans = null;

			//DeleteNotReq();

			conn1.Open();

			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					double dblQTY_TO_INSP = 0;
					double dblQTY_REJECTED = 0;
					double dblQTY_PASSED = 0;
					myTrans = conn1.BeginTransaction();
					foreach (DataRow itemDR in ds.Tables[0].Rows)
					{

						dblQTY_TO_INSP = itemDR.IsNull("QTY_TO_INSP") ? 0 : Convert.ToDouble(itemDR["QTY_TO_INSP"]);
						dblQTY_REJECTED = itemDR.IsNull("QTY_REJECTED") ? 0 : Convert.ToDouble(itemDR["QTY_REJECTED"]);
						dblQTY_PASSED = itemDR.IsNull("QTY_PASSED") ? 0 : Convert.ToDouble(itemDR["QTY_PASSED"]);

						if (!IsValidQty(dblQTY_TO_INSP, dblQTY_REJECTED, dblQTY_PASSED))
						{
							DisplayAlert(" QTY REJECTED + QTY PASSED should not be greater than (>) QTY TO INSP !");
							continue;
						}

						string strIC = "SELECT ITEM_SRNO_PO FROM IC_INTERMEDIATE WHERE CASE_NO = '" + Convert.ToString(itemDR["CASE_NO"]) + "' AND CALL_SNO = '" + Convert.ToString(itemDR["CALL_SNO"]) + "' AND CALL_RECV_DT =  TO_date('" + Convert.ToString(itemDR["CALL_RECV_DT"]) + "', 'dd/mm/yyyy') and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CONSIGNEE_CD = '" + Convert.ToString(itemDR["CONSIGNEE_CD"]) + "' AND ITEM_SRNO_PO = '" + Convert.ToString(itemDR["ITEM_SRNO_PO"]) + "'";

						//conn1.Open();
						OracleCommand cmd2 = new OracleCommand(strIC, conn1);
						cmd2.Transaction = myTrans;
						cmd2.Connection = conn1;
						string ss = Convert.ToString(cmd2.ExecuteScalar());
						//conn.Close();

						if (ss.Trim() != "")
						{
							if (Convert.ToString(itemDR["ITEM_SRNO_PO"]) == ddlItems.SelectedValue.Trim())
							{
								string sqlQuery = "";

								if (conn1.State != ConnectionState.Open)
								{
									conn1.Open();
								}


								sqlQuery = "Update IC_INTERMEDIATE set QTY_ORDERED          = '" + Convert.ToString(itemDR["QTY_ORDERED"]) + "',CUM_QTY_PREV_OFFERED = '" + Convert.ToString(itemDR["CUM_QTY_PREV_OFFERED"]) + "',CUM_QTY_PREV_PASSED  = '" + Convert.ToString(itemDR["CUM_QTY_PREV_PASSED"]) + "',QTY_TO_INSP          = '" + Convert.ToString(itemDR["QTY_TO_INSP"]) + "',QTY_PASSED           = '" + Convert.ToString(itemDR["QTY_PASSED"]) + "',QTY_REJECTED         = '" + Convert.ToString(itemDR["QTY_REJECTED"]) + "',QTY_DUE   			 = '" + Convert.ToString(itemDR["QTY_DUE"]) + "',ITEM_DESC_PO = '" + Convert.ToString(itemDR["ITEM_DESC_PO"]) + "', ITEM_REMARK ='', UNIT_DTL = null , OFF_INST_NO_DTL = null, PUR_AUT_DTL=null, PUR_DTL= null, CONSIGNEE_DTL = null, BPO_DTL = null where CASE_NO = '" + lblCSNO.Text.Trim() + "' and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "' AND ITEM_SRNO_PO = '" + ddlItems.SelectedValue.Trim() + "'  ";
								myInsertCommand1 = new OracleCommand(sqlQuery);
								myInsertCommand1.Transaction = myTrans;
								myInsertCommand1.Connection = conn1;
							}
						}
						else
						{
							string sqlQuery = "";
							if (conn1.State != ConnectionState.Open)
							{
								conn1.Open();
							}
							//myTrans = conn1.BeginTransaction();

							// //sqlQuery = " Insert into IC_INTERMEDIATE(CASE_NO,CALL_RECV_DT,CALL_SNO,BK_NO,SET_NO,PO_NO,CONSIGNEE_CD,USER_ID,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_ORDERED,CUM_QTY_PREV_OFFERED,CUM_QTY_PREV_PASSED,QTY_TO_INSP,QTY_PASSED,QTY_REJECTED,QTY_DUE,IE_CD,DATETIME,FILE_1,FILE_2,FILE_3,FILE_4,FILE_5,FILE_6,FILE_7,FILE_8,FILE_9,FILE_10,CONSGN_CALL_STATUS,LAB_TST_RECT_DT,REASON_OF_REJECTION,REMARK,HOLOGRAM,IE_STAMP,IE_STAMP2,IE_STAMP_CD,VISITS_DATES,AMENDMENT_1,AMENDMENT_2,AMENDMENT_3,AMENDMENT_4,ITEM_REMARK,IE_STAMP_IMAGE,IE_STAMP_IMAGE1,NUM_VISITS,IE_STAMPS_DETAIL,IE_STAMPS_DETAIL2,PASSED_INST_NO,BPO_DTL,PUR_DTL,PUR_AUT_DTL,OFF_INST_NO_DTL,UNIT_DTL,CONSIGNEE_DTL) " +
							// //	" select CASE_NO,CALL_RECV_DT,CALL_SNO,BK_NO,SET_NO,PO_NO,CONSIGNEE_CD,USER_ID,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_ORDERED,CUM_QTY_PREV_OFFERED,CUM_QTY_PREV_PASSED,QTY_TO_INSP,QTY_PASSED,QTY_REJECTED,QTY_DUE,IE_CD,DATETIME,FILE_1,FILE_2,FILE_3,FILE_4,FILE_5,FILE_6,FILE_7,FILE_8,FILE_9,FILE_10,CONSGN_CALL_STATUS,LAB_TST_RECT_DT,REASON_OF_REJECTION,REMARK,HOLOGRAM,IE_STAMP,IE_STAMP2,IE_STAMP_CD,VISITS_DATES,AMENDMENT_1,AMENDMENT_2,AMENDMENT_3,AMENDMENT_4,ITEM_REMARK,IE_STAMP_IMAGE,IE_STAMP_IMAGE1,NUM_VISITS,IE_STAMPS_DETAIL,IE_STAMPS_DETAIL2,PASSED_INST_NO,BPO_DTL,PUR_DTL,PUR_AUT_DTL,OFF_INST_NO_DTL,UNIT_DTL,CONSIGNEE_DTL " + " from ("+
							// //	" select '" + Convert.ToString(itemDR["CASE_NO"]) + "' as CASE_NO,to_date('" + Convert.ToString(itemDR["CALL_RECV_DT"]) + "','dd/mm/yyyy') as CALL_RECV_DT ,'" + Convert.ToString(itemDR["CALL_SNO"]) + "' as CALL_SNO,'" + txtBKNO1.Text + "' as BK_NO,'" + txtSetNo1.Text + "' as SET_NO,'" + lblPONO.Text + "' as PO_NO,'" + Convert.ToString(itemDR["CONSIGNEE_CD"]) + "' as CONSIGNEE_CD,USER_ID,'"+Convert.ToString(itemDR["ITEM_SRNO_PO"])+"' as ITEM_SRNO_PO , '"+Convert.ToString(itemDR["ITEM_DESC_PO"])+"' as ITEM_DESC_PO,'"+Convert.ToString(itemDR["QTY_ORDERED"])+"' as QTY_ORDERED,'"+Convert.ToString(itemDR["CUM_QTY_PREV_OFFERED"])+"' as CUM_QTY_PREV_OFFERED,'"+Convert.ToString(itemDR["CUM_QTY_PREV_PASSED"])+"' as CUM_QTY_PREV_PASSED,'"+Convert.ToString(itemDR["QTY_TO_INSP"])+"' as QTY_TO_INSP,'"+Convert.ToString(itemDR["QTY_PASSED"])+"' as QTY_PASSED,'"+Convert.ToString(itemDR["QTY_REJECTED"])+"' as QTY_REJECTED,'"+Convert.ToString(itemDR["QTY_DUE"])+"' as QTY_DUE," + wIECD + " as IE_CD,to_date('" + ss + "','dd/mm/yyyy') as DATETIME,FILE_1,FILE_2,FILE_3,FILE_4,FILE_5,FILE_6,FILE_7,FILE_8,FILE_9,FILE_10,CONSGN_CALL_STATUS,LAB_TST_RECT_DT,REASON_OF_REJECTION,REMARK,HOLOGRAM,IE_STAMP,IE_STAMP2,IE_STAMP_CD,VISITS_DATES,AMENDMENT_1,AMENDMENT_2,AMENDMENT_3,AMENDMENT_4,ITEM_REMARK,IE_STAMP_IMAGE,IE_STAMP_IMAGE1,NUM_VISITS,IE_STAMPS_DETAIL,IE_STAMPS_DETAIL2,PASSED_INST_NO,BPO_DTL,PUR_DTL,PUR_AUT_DTL,OFF_INST_NO_DTL,UNIT_DTL,CONSIGNEE_DTL, row_number() over (order by CASE_NO) as rn WHERE CASE_NO = '" + Convert.ToString(itemDR["CASE_NO"]) + "' AND CALL_SNO = '" + Convert.ToString(itemDR["CALL_SNO"]) + "' AND CALL_RECV_DT =  TO_date('" + Convert.ToString(itemDR["CALL_RECV_DT"]) + "', 'dd/mm/yyyy') and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CONSIGNEE_CD = '" + Convert.ToString(itemDR["CONSIGNEE_CD"]) + "') where rn = 1";

							sqlQuery = " Insert into IC_INTERMEDIATE(CASE_NO,CALL_RECV_DT,CALL_SNO,BK_NO,SET_NO,PO_NO,CONSIGNEE_CD,USER_ID,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_ORDERED,CUM_QTY_PREV_OFFERED,CUM_QTY_PREV_PASSED,QTY_TO_INSP,QTY_PASSED,QTY_REJECTED,QTY_DUE,IE_CD,DATETIME,FILE_1,FILE_2,FILE_3,FILE_4,FILE_5,FILE_6,FILE_7,FILE_8,FILE_9,FILE_10,CONSGN_CALL_STATUS,LAB_TST_RECT_DT,REASON_OF_REJECTION,REMARK,HOLOGRAM,IE_STAMP,IE_STAMP2,IE_STAMP_CD,VISITS_DATES,AMENDMENT_1,AMENDMENT_2,AMENDMENT_3,AMENDMENT_4,ITEM_REMARK,IE_STAMP_IMAGE,IE_STAMP_IMAGE1,NUM_VISITS,IE_STAMPS_DETAIL,IE_STAMPS_DETAIL2,PASSED_INST_NO,BPO_DTL,PUR_DTL,PUR_AUT_DTL,OFF_INST_NO_DTL,UNIT_DTL,CONSIGNEE_DTL,DISPATCH_PACKING_NO,INVOICE_NO,NAME_OF_IE,GOV_BILL_AUTH,MAN_TYPE,CONSIGNEE_DESG) " +
								" select CASE_NO,CALL_RECV_DT,CALL_SNO,BK_NO,SET_NO,PO_NO,CONSIGNEE_CD,USER_ID,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_ORDERED,CUM_QTY_PREV_OFFERED,CUM_QTY_PREV_PASSED,QTY_TO_INSP,QTY_PASSED,QTY_REJECTED,QTY_DUE,IE_CD,DATETIME,FILE_1,FILE_2,FILE_3,FILE_4,FILE_5,FILE_6,FILE_7,FILE_8,FILE_9,FILE_10,CONSGN_CALL_STATUS,LAB_TST_RECT_DT,REASON_OF_REJECTION,REMARK,HOLOGRAM,IE_STAMP,IE_STAMP2,IE_STAMP_CD,VISITS_DATES,AMENDMENT_1,AMENDMENT_2,AMENDMENT_3,AMENDMENT_4,ITEM_REMARK,IE_STAMP_IMAGE,IE_STAMP_IMAGE1,NUM_VISITS,IE_STAMPS_DETAIL,IE_STAMPS_DETAIL2,PASSED_INST_NO,BPO_DTL,PUR_DTL,PUR_AUT_DTL,OFF_INST_NO_DTL,UNIT_DTL,CONSIGNEE_DTL,DISPATCH_PACKING_NO,INVOICE_NO,NAME_OF_IE,GOV_BILL_AUTH,MAN_TYPE,CONSIGNEE_DESG " + " from (" +
								" select '" + Convert.ToString(itemDR["CASE_NO"]) + "' as CASE_NO,to_date('" + Convert.ToString(itemDR["CALL_RECV_DT"]) + "','dd/mm/yyyy') as CALL_RECV_DT ,'" + Convert.ToString(itemDR["CALL_SNO"]) + "' as CALL_SNO,'" + txtBKNO1.Text + "' as BK_NO,'" + txtSetNo1.Text + "' as SET_NO,'" + lblPONO.Text + "' as PO_NO,'" + Convert.ToString(itemDR["CONSIGNEE_CD"]) + "' as CONSIGNEE_CD,USER_ID,'" + Convert.ToString(itemDR["ITEM_SRNO_PO"]) + "' as ITEM_SRNO_PO , '" + Convert.ToString(itemDR["ITEM_DESC_PO"]) + "' as ITEM_DESC_PO,'" + Convert.ToString(itemDR["QTY_ORDERED"]) + "' as QTY_ORDERED,'" + Convert.ToString(itemDR["CUM_QTY_PREV_OFFERED"]) + "' as CUM_QTY_PREV_OFFERED,'" + Convert.ToString(itemDR["CUM_QTY_PREV_PASSED"]) + "' as CUM_QTY_PREV_PASSED,'" + Convert.ToString(itemDR["QTY_TO_INSP"]) + "' as QTY_TO_INSP,'" + Convert.ToString(itemDR["QTY_PASSED"]) + "' as QTY_PASSED,'" + Convert.ToString(itemDR["QTY_REJECTED"]) + "' as QTY_REJECTED,'" + Convert.ToString(itemDR["QTY_DUE"]) + "' as QTY_DUE," + wIECD + " as IE_CD,to_date('" + ssd + "','dd/mm/yyyy') as DATETIME,FILE_1,FILE_2,FILE_3,FILE_4,FILE_5,FILE_6,FILE_7,FILE_8,FILE_9,FILE_10,CONSGN_CALL_STATUS,LAB_TST_RECT_DT,REASON_OF_REJECTION,REMARK,HOLOGRAM,IE_STAMP,IE_STAMP2,IE_STAMP_CD,VISITS_DATES,AMENDMENT_1,AMENDMENT_2,AMENDMENT_3,AMENDMENT_4,ITEM_REMARK,IE_STAMP_IMAGE,IE_STAMP_IMAGE1,NUM_VISITS,IE_STAMPS_DETAIL,IE_STAMPS_DETAIL2,PASSED_INST_NO,BPO_DTL,PUR_DTL,PUR_AUT_DTL,OFF_INST_NO_DTL,UNIT_DTL,CONSIGNEE_DTL,DISPATCH_PACKING_NO,INVOICE_NO,NAME_OF_IE,GOV_BILL_AUTH,MAN_TYPE,CONSIGNEE_DESG row_number() over (order by CASE_NO) as rn FROM IC_INTERMEDIATE WHERE CASE_NO = '" + Convert.ToString(itemDR["CASE_NO"]) + "' AND CALL_SNO = '" + Convert.ToString(itemDR["CALL_SNO"]) + "' AND CALL_RECV_DT =  TO_date('" + Convert.ToString(itemDR["CALL_RECV_DT"]) + "', 'dd/mm/yyyy') and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CONSIGNEE_CD = '" + Convert.ToString(itemDR["CONSIGNEE_CD"]) + "') where rn = 1";

							myInsertCommand1 = new OracleCommand(sqlQuery);
							myInsertCommand1.Transaction = myTrans;
							myInsertCommand1.Connection = conn1;
						}
					}
				}
			}
			//New Changes
			try
			{
				if (myInsertCommand1 != null)
				{
					myInsertCommand1.ExecuteNonQuery();
					if (myTrans != null)
						myTrans.Commit();
					conn1.Close();

					DeleteNotReq();

					txtBKNO1.Text = "";
					txtSetNo1.Text = "";

					Reset();

					FillItems();

					SetAccepted();

					DisplayAlert("Your request has been accepted!");
				}
			}
			catch (Exception ex)
			{
				myTrans.Rollback();
				conn1.Close();
				DisplayAlert("Your request is denied due to " + ex.Message);
			}
		}


		private void DeleteNotReq()
		{
			OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//New Changes
			DataSet ds = new DataSet();
			string strt18 = "SELECT CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy') as CALL_RECV_DT,CALL_SNO,CONSIGNEE_CD,ITEM_SRNO_PO FROM IC_INTERMEDIATE WHERE CASE_NO = '" + lblCSNO.Text.Trim() + "' and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "' ";
			// //cmd = new OracleCommand("SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO = '" + CASE_NO.Trim() + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CONSIGNEE_CD = '" + CONSIGNEE_CD + "'", conn);
			OracleDataAdapter da = new OracleDataAdapter(strt18, conn1);
			OracleCommand myOracleCommand = new OracleCommand(strt18, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			conn1.Close();
			da.Fill(ds, "Table");

			OracleCommand myInsertCommand1 = null;
			OracleTransaction myTrans = null;

			conn1.Open();
			if (ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					foreach (DataRow itemDR in ds.Tables[0].Rows)
					{
						string strIC = "SELECT ITEM_SRNO_PO FROM T18_Call_Details WHERE CASE_NO = '" + Convert.ToString(itemDR["CASE_NO"]) + "' AND CALL_SNO = '" + Convert.ToString(itemDR["CALL_SNO"]) + "' AND CALL_RECV_DT =  TO_date('" + Convert.ToString(itemDR["CALL_RECV_DT"]) + "', 'dd/mm/yyyy') AND CONSIGNEE_CD = '" + Convert.ToString(itemDR["CONSIGNEE_CD"]) + "' AND ITEM_SRNO_PO = '" + Convert.ToString(itemDR["ITEM_SRNO_PO"]) + "'";


						OracleCommand cmd2 = new OracleCommand(strIC, conn1);
						string ss = Convert.ToString(cmd2.ExecuteScalar());


						if (ss.Trim() == "")
						{
							string sqlQuery = "";
							if (conn1.State != ConnectionState.Open)
							{
								conn1.Open();
							}

							myTrans = conn1.BeginTransaction();
							sqlQuery = "DELETE FROM IC_INTERMEDIATE WHERE CASE_NO = '" + Convert.ToString(itemDR["CASE_NO"]) + "' AND CALL_SNO = '" + Convert.ToString(itemDR["CALL_SNO"]) + "' AND CALL_RECV_DT =  TO_date('" + Convert.ToString(itemDR["CALL_RECV_DT"]) + "', 'dd/mm/yyyy') and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CONSIGNEE_CD = '" + Convert.ToString(itemDR["CONSIGNEE_CD"]) + "' AND ITEM_SRNO_PO = '" + Convert.ToString(itemDR["ITEM_SRNO_PO"]) + "' ";
							myInsertCommand1 = new OracleCommand(sqlQuery);
							myInsertCommand1.Transaction = myTrans;
							myInsertCommand1.Connection = conn1;
						}
					}
				}
			}
			//New Changes
			try
			{
				if (myInsertCommand1 != null)
				{
					myInsertCommand1.ExecuteNonQuery();
					if (myTrans != null)
						myTrans.Commit();
					conn1.Close();
				}
			}
			catch (Exception ex)
			{
				myTrans.Rollback();
				conn1.Close();
			}
		}


		private void ChkConsdtl_CheckedChanged(object sender, EventArgs e)
		{
			TxtCondigneedtl.Enabled = ChkConsdtl.Checked;
		}

		private void ChkBPOdtl_CheckedChanged(object sender, EventArgs e)
		{
			TxtBPO.Enabled = ChkBPOdtl.Checked;
		}

		private void ChkManufacturerdtl_CheckedChanged(object sender, EventArgs e)
		{
			TxtManufacturer.Enabled = ChkManufacturerdtl.Checked;
		}

		private void ChkPurchasingAuthoritydtl_CheckedChanged(object sender, EventArgs e)
		{
			TxtPurchasingAuthority.Enabled = ChkPurchasingAuthoritydtl.Checked;
		}

		private void ChkOFINtlhk_CheckedChanged(object sender, EventArgs e)
		{
			TxtOFIN.Enabled = ChkOFINtlhk.Checked;
		}

		private void ChkUnitdtl_CheckedChanged(object sender, EventArgs e)
		{
			TxtUnit.Enabled = ChkUnitdtl.Checked;
		}

		private DataSet funInspectionCertificate_cr_r(string pcaseno_cr_r, string pcsno_cr_r, string recvdt_cr_r, string pconsidecd_cr_r, string pregion_cr_r)
		{
			DataSet dsReports = new DataSet();
			string sql_cr_r = "SELECT     CLR.CASE_NO, CLR.Call_SNO, to_date(TO_CHAR(CLR.Call_Recv_dt, 'mm/dd/yyyy'), 'mm/dd/yyyy')Call_Recv_dt, POM.Region_Code, BOF.BPO_RLY as RLY_CD, CLR.Call_Install_No, TIE.IE_Sname, VND.Vend_Name, VND.Vend_Add1, NVL(VND.Vend_Add2, ' ') AS Vend_Add2,VCT.City AS Vend_City, MFG.Vend_Name AS MFG_Name, MFG.Vend_Add1 AS MFG_Add1,NVL(MFG.Vend_Add2, ' ') AS MFG_Add2, NVL( MCT.City,' ') AS MFG_City, CLR.MFG_PLACE, POM.PO_NO, TO_CHAR(POM.PO_DT,'dd/mm/yyyy') PO_DT, NVL(CON.CONSIGNEE_DESIG, ' ')  AS CONSIGNEE_DESIG, " +
				" CON.CONSIGNEE_CD, CCT.City AS CONSIGNEE_CITYNAME, NVL(CON.CONSIGNEE_DEPT, ' ') AS CONSIGNEE_DEPT, NVL(CON.CONSIGNEE_FIRM, ' ') AS CONSIGNEE_FIRM, NVL(PUR.CONSIGNEE_DESIG, ' ') AS PUR_DESIG, PUR.CONSIGNEE_CD AS PUR_CD,  NVL(PUR.CONSIGNEE_DEPT, ' ') AS PUR_DEPT, NVL(PUR.CONSIGNEE_FIRM, ' ') AS PUR_FIRM, NVL(PCT.City, ' ') AS PUR_City, CDT.ITEM_SRNO_PO, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.ITEM_DESC_PO ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN  " +
				" CDT.ITEM_DESC_PO ELSE CDT.ITEM_DESC_PO END END AS ITEM_DESC_PO, UOM.UOM_S_DESC, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_ORDERED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_ORDERED,0) ELSE NVL(CDT.QTY_ORDERED,0) END END AS QTY_ORDERED, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.CUM_QTY_PREV_OFFERED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.CUM_QTY_PREV_OFFERED,0)  ELSE NVL(CDT.CUM_QTY_PREV_OFFERED,0) END END AS CUM_QTY_PREV_OFFERED,  " +
				" CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.CUM_QTY_PREV_PASSED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.CUM_QTY_PREV_PASSED,0) ELSE NVL(CDT.CUM_QTY_PREV_PASSED,0) END END AS CUM_QTY_PREV_PASSED,  CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_TO_INSP,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_TO_INSP,0) ELSE NVL(CDT.QTY_TO_INSP,0) END END AS QTY_TO_INSP, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_PASSED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' " +
				" THEN NVL(CDT.QTY_PASSED,0) ELSE NVL(CDT.QTY_PASSED,0) END END AS QTY_PASSED,   CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_REJECTED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_REJECTED,0) ELSE NVL(CDT.QTY_REJECTED,0) END END AS QTY_REJECTED,  CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_DUE,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_DUE,0) ELSE NVL(CDT.QTY_DUE,0)END END AS QTY_DUE, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.HOLOGRAM ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN ICI.HOLOGRAM ELSE ICI.HOLOGRAM " +
				" END END AS HOLOGRAM, ICI.NUM_VISITS, PRM.VISIT_DATES, BOF.BPO_NAME, BOF.BPO_ORGN, BCT.City, NVL(CLR.HOLOGRAM, '    ')  AS HOLOGRAMORG, NVL(ICI.REMARK, ' ') AS REMARK, CLR.DT_INSP_DESIRE, NVL(ICI.ITEM_REMARK, 'NO REMARK') AS ITEM_REMARK, substr(ICI.AMENDMENT_1, 0, 99) AS AMENDMENT_1, substr(ICI.AMENDMENT_1, 100, 20) AS AMENDMENTDT_1, substr(ICI.AMENDMENT_2, 0, 99) AS AMENDMENT_2, substr(ICI.AMENDMENT_2, 100, 20) AS AMENDMENTDT_2, substr(ICI.AMENDMENT_3, 0, 99) AS AMENDMENT_3, substr(ICI.AMENDMENT_3, 100, 20) AS AMENDMENTDT_3, substr(ICI.AMENDMENT_4, 0, 99) AS AMENDMENT_4, substr(ICI.AMENDMENT_4, 100, 20) " +
				" AS AMENDMENTDT_4, ICI.BK_NO, ICI.SET_NO, ICI.VISITS_DATES, ICI.IE_STAMP_IMAGE, ICI.IE_STAMP_IMAGE1, TO_CHAR(ICI.LAB_TST_RECT_DT,'dd/mm/yyyy') LAB_TST_RECT_DT,ICI.PASSED_INST_NO, NVL(CONSIGNEE_DTL, '') AS CONSIGNEE_DTL, NVL(BPO_DTL, '') AS BPO_DTL,NVL(GOV_BILL_AUTH, '') AS GOV_BILL_AUTH, NVL(PUR_DTL, '') AS PUR_DTL, NVL(PUR_AUT_DTL, '') AS PUR_AUT_DTL, NVL(OFF_INST_NO_DTL, '') AS OFF_INST_NO_DTL, NVL(UNIT_DTL, '') AS UNIT_DTL, NVL(DISPATCH_PACKING_NO, '') As DISPATCH_PACKING_NO, NVL(INVOICE_NO, '') As INVOICE_NO, NVL(NAME_OF_IE, '') As NAME_OF_IE, NVL(MAN_TYPE, '') As MAN_TYPE, NVL(CONSIGNEE_DESG, '') As CONSIGNEE_DESG,TO_CHAR(ICI.DATETIME,'dd/mm/yyyy') DATETIME,ICI.CONSGN_CALL_STATUS FROM RPT_PRM_Inspection_Certificate PRM INNER JOIN  T17_Call_Register CLR ON CLR.CASE_NO = PRM.CASE_NO AND CLR.Call_Recv_dt = PRM.CALL_RECV_DT AND " +
				" CLR.Call_SNO = PRM.Call_SNO INNER JOIN T18_Call_Details CDT ON CLR.CASE_NO = CDT.CASE_NO AND CLR.Call_Recv_dt = CDT.Call_Recv_dt AND CLR.Call_SNO = CDT.Call_SNO INNER JOIN T13_PO_Master POM ON CLR.CASE_NO = POM.CASE_NO LEFT OUTER JOIN T15_PO_DETAIL POD ON CLR.CASE_NO = POD.CASE_NO AND CDT.ITEM_SRNO_PO = POD.ITEM_SRNO LEFT OUTER JOIN T04_UOM UOM ON POD.UOM_CD = UOM.UOM_CD LEFT OUTER JOIN " +
				" T09_IE TIE ON CLR.IE_CD = TIE.IE_CD LEFT OUTER JOIN T05_Vendor VND ON POM.Vend_Cd = VND.Vend_Cd LEFT OUTER JOIN   T03_City VCT ON VND.Vend_City_Cd = VCT.City_Cd LEFT OUTER JOIN T05_Vendor MFG ON CLR.MFG_CD = MFG.Vend_Cd LEFT OUTER JOIN  T03_City MCT ON MFG.Vend_City_Cd = MCT.City_Cd LEFT OUTER JOIN T14_PO_BPO BPO ON CLR.CASE_NO = BPO.CASE_NO AND CDT.CONSIGNEE_CD = BPO.CONSIGNEE_CD LEFT OUTER  " +
				" JOIN T12_BILL_PAYING_OFFICER BOF ON BPO.BPO_CD = BOF.BPO_CD LEFT OUTER JOIN  T03_City BCT ON BOF.BPO_City_Cd = BCT.City_Cd LEFT OUTER JOIN  T06_Consignee CON ON BPO.CONSIGNEE_CD = CON.CONSIGNEE_CD LEFT OUTER JOIN T03_City CCT ON CON.CONSIGNEE_CITY = CCT.City_Cd LEFT OUTER JOIN  T06_Consignee PUR ON POM.PURCHASER_CD = PUR.CONSIGNEE_CD LEFT OUTER JOIN T03_City PCT ON PUR.CONSIGNEE_CITY = PCT.City_Cd INNER JOIN " +
				" IC_INTERMEDIATE ICI ON ICI.CASE_NO = CDT.CASE_NO AND ICI.Call_Recv_dt = CDT.Call_Recv_dt AND ICI.Call_SNO = CDT.Call_SNO AND CDT.CONSIGNEE_CD = ICI.CONSIGNEE_CD AND CDT.ITEM_SRNO_PO = ICI.ITEM_SRNO_PO AND PRM.CONSIGNEE_CD = ICI.CONSIGNEE_CD WHERE ICI.ITEM_SRNO_PO IS NOT NULL and ICI.CASE_NO='" + pcaseno_cr_r + "' " +
				" and CLR.Call_SNO=" + pcsno_cr_r + " and CLR.Call_Recv_dt=to_date('" + recvdt_cr_r + "','mm/dd/yyyy')  and CON.CONSIGNEE_CD='" + pconsidecd_cr_r + "' ORDER BY CON.CONSIGNEE_CD, POD.ITEM_SRNO";
			OracleCommand cmd_cr_r = new OracleCommand();
			cmd_cr_r.CommandText = sql_cr_r;
			cmd_cr_r.Connection = conn;
			if (conn.State == ConnectionState.Closed)
				conn.Open();
			OracleDataReader readerB_cr_r = cmd_cr_r.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Columns.Add("CASE_NO", typeof(string));
			dt.Columns.Add("Call_SNO", typeof(string));
			dt.Columns.Add("Call_Recv_dt", typeof(string));
			dt.Columns.Add("Region_Code", typeof(string));
			dt.Columns.Add("RLY_CD", typeof(string));
			dt.Columns.Add("Call_Install_No", typeof(string));
			dt.Columns.Add("IE_Sname", typeof(string));
			dt.Columns.Add("Vend_Name", typeof(string));
			dt.Columns.Add("Vend_Add1", typeof(string));
			dt.Columns.Add("Vend_Add2", typeof(string));
			dt.Columns.Add("Vend_City", typeof(string));
			dt.Columns.Add("MFG_Name", typeof(string));
			dt.Columns.Add("MFG_Add1", typeof(string));
			dt.Columns.Add("MFG_Add2", typeof(string));
			dt.Columns.Add("MFG_City", typeof(string));
			dt.Columns.Add("MFG_PLACE", typeof(string));
			dt.Columns.Add("PO_NO", typeof(string));
			dt.Columns.Add("PO_DT", typeof(string));
			dt.Columns.Add("CONSIGNEE_DESIG", typeof(string));
			dt.Columns.Add("CONSIGNEE_CD", typeof(Int32));
			dt.Columns.Add("CONSIGNEE_CITYNAME", typeof(string));
			dt.Columns.Add("CONSIGNEE_DEPT", typeof(string));
			dt.Columns.Add("CONSIGNEE_FIRM", typeof(string));
			dt.Columns.Add("PUR_DESIG", typeof(string));
			dt.Columns.Add("PUR_CD", typeof(string));
			dt.Columns.Add("PUR_DEPT", typeof(string));
			dt.Columns.Add("PUR_FIRM", typeof(string));
			dt.Columns.Add("PUR_City", typeof(string));
			dt.Columns.Add("ITEM_SRNO_PO", typeof(string));
			dt.Columns.Add("ITEM_DESC_PO", typeof(string));
			dt.Columns.Add("UOM_S_DESC", typeof(string));
			dt.Columns.Add("QTY_ORDERED", typeof(double));
			dt.Columns.Add("CUM_QTY_PREV_OFFERED", typeof(double));
			dt.Columns.Add("CUM_QTY_PREV_PASSED", typeof(double));
			dt.Columns.Add("QTY_TO_INSP", typeof(double));
			dt.Columns.Add("QTY_PASSED", typeof(double));
			dt.Columns.Add("QTY_REJECTED", typeof(double));
			dt.Columns.Add("QTY_DUE", typeof(double));
			dt.Columns.Add("HOLOGRAM", typeof(string));
			dt.Columns.Add("NUM_VISITS", typeof(Int32));
			dt.Columns.Add("VISIT_DATES", typeof(string));
			dt.Columns.Add("BPO_NAME", typeof(string));
			dt.Columns.Add("BPO_ORGN", typeof(string));
			dt.Columns.Add("City", typeof(string));
			dt.Columns.Add("HOLOGRAMORG", typeof(string));
			dt.Columns.Add("REMARK", typeof(string));
			dt.Columns.Add("DT_INSP_DESIRE", typeof(string));
			dt.Columns.Add("ITEM_REMARK", typeof(string));
			dt.Columns.Add("AMENDMENT_1", typeof(string));
			dt.Columns.Add("AMENDMENTDT_1", typeof(string));
			dt.Columns.Add("AMENDMENT_2", typeof(string));
			dt.Columns.Add("AMENDMENTDT_2", typeof(string));
			dt.Columns.Add("AMENDMENT_3", typeof(string));
			dt.Columns.Add("AMENDMENTDT_3", typeof(string));
			dt.Columns.Add("AMENDMENT_4", typeof(string));
			dt.Columns.Add("AMENDMENTDT_4", typeof(string));
			dt.Columns.Add("BK_NO", typeof(string));
			dt.Columns.Add("SET_NO", typeof(string));
			dt.Columns.Add("VISITS_DATES", typeof(string));
			dt.Columns.Add("IE_STAMP_IMAGE", typeof(string));
			dt.Columns.Add("IE_STAMP_IMAGE1", typeof(string));
			dt.Columns.Add("LAB_TST_RECT_DT", typeof(string));
			dt.Columns.Add("PASSED_INST_NO", typeof(string));
			dt.Columns.Add("CONSIGNEE_DTL", typeof(string));
			dt.Columns.Add("BPO_DTL", typeof(string));
			dt.Columns.Add("GOV_BILL_AUTH", typeof(string));
			dt.Columns.Add("PUR_DTL", typeof(string));
			dt.Columns.Add("PUR_AUT_DTL", typeof(string));
			dt.Columns.Add("OFF_INST_NO_DTL", typeof(string));
			dt.Columns.Add("UNIT_DTL", typeof(string));
			dt.Columns.Add("DISPATCH_PACKING_NO", typeof(string));
			dt.Columns.Add("INVOICE_NO", typeof(string));
			dt.Columns.Add("NAME_OF_IE", typeof(string));
			dt.Columns.Add("MAN_TYPE", typeof(string));
			dt.Columns.Add("CONSIGNEE_DESG", typeof(string));
			dt.Columns.Add("DATETIME", typeof(string));
			dt.Columns.Add("CONSGN_CALL_STATUS", typeof(string));
			dt.Columns.Add("pRegion", typeof(string));
			dt.TableName = "Command";
			while (readerB_cr_r.Read())
			{
				DataRow dr_cr_r = dt.NewRow();// dsReports.Tables["Command"].Rows.Add();
				dr_cr_r["CASE_NO"] = Convert.ToString(readerB_cr_r["CASE_NO"]);
				dr_cr_r["Call_SNO"] = Convert.ToString(readerB_cr_r["Call_SNO"]);
				dr_cr_r["Call_Recv_dt"] = Convert.ToString(readerB_cr_r["Call_Recv_dt"]);
				dr_cr_r["Region_Code"] = Convert.ToString(readerB_cr_r["Region_Code"]);
				dr_cr_r["RLY_CD"] = Convert.ToString(readerB_cr_r["RLY_CD"]);
				dr_cr_r["Call_Install_No"] = Convert.ToString(readerB_cr_r["Call_Install_No"]);
				dr_cr_r["IE_Sname"] = Convert.ToString(readerB_cr_r["IE_Sname"]);
				dr_cr_r["Vend_Name"] = Convert.ToString(readerB_cr_r["Vend_Name"]);
				dr_cr_r["Vend_Add1"] = Convert.ToString(readerB_cr_r["Vend_Add1"]);
				dr_cr_r["Vend_Add2"] = Convert.ToString(readerB_cr_r["Vend_Add2"]);
				dr_cr_r["Vend_City"] = Convert.ToString(readerB_cr_r["Vend_City"]);
				dr_cr_r["MFG_Name"] = Convert.ToString(readerB_cr_r["MFG_Name"]);
				dr_cr_r["MFG_Add1"] = Convert.ToString(readerB_cr_r["MFG_Add1"]);
				dr_cr_r["MFG_Add2"] = Convert.ToString(readerB_cr_r["MFG_Add2"]);
				dr_cr_r["MFG_City"] = Convert.ToString(readerB_cr_r["MFG_City"]);
				dr_cr_r["MFG_PLACE"] = Convert.ToString(readerB_cr_r["MFG_PLACE"]);
				dr_cr_r["PO_NO"] = Convert.ToString(readerB_cr_r["PO_NO"]);
				dr_cr_r["PO_DT"] = Convert.ToString(readerB_cr_r["PO_DT"]);
				dr_cr_r["CONSIGNEE_DESIG"] = Convert.ToString(readerB_cr_r["CONSIGNEE_DESIG"]);
				dr_cr_r["CONSIGNEE_CD"] = Convert.ToString(readerB_cr_r["CONSIGNEE_CD"]);
				dr_cr_r["CONSIGNEE_CITYNAME"] = Convert.ToString(readerB_cr_r["CONSIGNEE_CITYNAME"]);
				dr_cr_r["CONSIGNEE_DEPT"] = Convert.ToString(readerB_cr_r["CONSIGNEE_DEPT"]);
				dr_cr_r["CONSIGNEE_FIRM"] = Convert.ToString(readerB_cr_r["CONSIGNEE_FIRM"]);
				dr_cr_r["PUR_DESIG"] = Convert.ToString(readerB_cr_r["PUR_DESIG"]);
				dr_cr_r["PUR_CD"] = Convert.ToString(readerB_cr_r["PUR_CD"]);
				dr_cr_r["PUR_DEPT"] = Convert.ToString(readerB_cr_r["PUR_DEPT"]);
				dr_cr_r["PUR_FIRM"] = Convert.ToString(readerB_cr_r["PUR_FIRM"]);
				dr_cr_r["PUR_City"] = Convert.ToString(readerB_cr_r["PUR_City"]);
				dr_cr_r["ITEM_SRNO_PO"] = Convert.ToString(readerB_cr_r["ITEM_SRNO_PO"]);
				dr_cr_r["ITEM_DESC_PO"] = Convert.ToString(readerB_cr_r["ITEM_DESC_PO"]);
				dr_cr_r["UOM_S_DESC"] = Convert.ToString(readerB_cr_r["UOM_S_DESC"]);
				dr_cr_r["QTY_ORDERED"] = Convert.ToString(readerB_cr_r["QTY_ORDERED"]);
				dr_cr_r["CUM_QTY_PREV_OFFERED"] = Convert.ToString(readerB_cr_r["CUM_QTY_PREV_OFFERED"]);
				dr_cr_r["CUM_QTY_PREV_PASSED"] = Convert.ToString(readerB_cr_r["CUM_QTY_PREV_PASSED"]);
				dr_cr_r["QTY_TO_INSP"] = Convert.ToString(readerB_cr_r["QTY_TO_INSP"]);
				dr_cr_r["QTY_PASSED"] = Convert.ToString(readerB_cr_r["QTY_PASSED"]);
				dr_cr_r["QTY_REJECTED"] = Convert.ToString(readerB_cr_r["QTY_REJECTED"]);
				dr_cr_r["QTY_DUE"] = Convert.ToString(readerB_cr_r["QTY_DUE"]);
				dr_cr_r["HOLOGRAM"] = Convert.ToString(readerB_cr_r["HOLOGRAM"]);
				dr_cr_r["NUM_VISITS"] = Convert.ToString(readerB_cr_r["NUM_VISITS"]);
				dr_cr_r["VISIT_DATES"] = Convert.ToString(readerB_cr_r["VISIT_DATES"]);
				dr_cr_r["BPO_NAME"] = Convert.ToString(readerB_cr_r["BPO_NAME"]);
				dr_cr_r["BPO_ORGN"] = Convert.ToString(readerB_cr_r["BPO_ORGN"]);
				dr_cr_r["City"] = Convert.ToString(readerB_cr_r["City"]);
				dr_cr_r["HOLOGRAMORG"] = Convert.ToString(readerB_cr_r["HOLOGRAMORG"]);
				dr_cr_r["REMARK"] = Convert.ToString(readerB_cr_r["REMARK"]);
				dr_cr_r["DT_INSP_DESIRE"] = Convert.ToString(readerB_cr_r["DT_INSP_DESIRE"]);
				dr_cr_r["ITEM_REMARK"] = Convert.ToString(readerB_cr_r["ITEM_REMARK"]);
				dr_cr_r["AMENDMENT_1"] = Convert.ToString(readerB_cr_r["AMENDMENT_1"]);
				dr_cr_r["AMENDMENTDT_1"] = Convert.ToString(readerB_cr_r["AMENDMENTDT_1"]);
				dr_cr_r["AMENDMENT_2"] = Convert.ToString(readerB_cr_r["AMENDMENT_2"]);
				dr_cr_r["AMENDMENTDT_2"] = Convert.ToString(readerB_cr_r["AMENDMENTDT_2"]);
				dr_cr_r["AMENDMENT_3"] = Convert.ToString(readerB_cr_r["AMENDMENT_3"]);
				dr_cr_r["AMENDMENTDT_3"] = Convert.ToString(readerB_cr_r["AMENDMENTDT_3"]);
				dr_cr_r["AMENDMENT_4"] = Convert.ToString(readerB_cr_r["AMENDMENT_4"]);
				dr_cr_r["AMENDMENTDT_4"] = Convert.ToString(readerB_cr_r["AMENDMENTDT_4"]);
				dr_cr_r["BK_NO"] = Convert.ToString(readerB_cr_r["BK_NO"]);
				dr_cr_r["SET_NO"] = Convert.ToString(readerB_cr_r["SET_NO"]);
				dr_cr_r["VISITS_DATES"] = Convert.ToString(readerB_cr_r["VISITS_DATES"]);
				dr_cr_r["IE_STAMP_IMAGE"] = Convert.ToString(readerB_cr_r["IE_STAMP_IMAGE"]);
				dr_cr_r["IE_STAMP_IMAGE1"] = Convert.ToString(readerB_cr_r["IE_STAMP_IMAGE1"]);
				dr_cr_r["LAB_TST_RECT_DT"] = Convert.ToString(readerB_cr_r["LAB_TST_RECT_DT"]);
				dr_cr_r["PASSED_INST_NO"] = Convert.ToString(readerB_cr_r["PASSED_INST_NO"]);
				dr_cr_r["CONSIGNEE_DTL"] = Convert.ToString(readerB_cr_r["CONSIGNEE_DTL"]);
				dr_cr_r["BPO_DTL"] = Convert.ToString(readerB_cr_r["BPO_DTL"]);
				dr_cr_r["GOV_BILL_AUTH"] = Convert.ToString(readerB_cr_r["GOV_BILL_AUTH"]);
				dr_cr_r["PUR_DTL"] = Convert.ToString(readerB_cr_r["PUR_DTL"]);
				dr_cr_r["PUR_AUT_DTL"] = Convert.ToString(readerB_cr_r["PUR_AUT_DTL"]);
				dr_cr_r["OFF_INST_NO_DTL"] = Convert.ToString(readerB_cr_r["OFF_INST_NO_DTL"]);
				dr_cr_r["UNIT_DTL"] = Convert.ToString(readerB_cr_r["UNIT_DTL"]);
				dr_cr_r["DISPATCH_PACKING_NO"] = Convert.ToString(readerB_cr_r["DISPATCH_PACKING_NO"]);
				dr_cr_r["INVOICE_NO"] = Convert.ToString(readerB_cr_r["INVOICE_NO"]);
				dr_cr_r["NAME_OF_IE"] = Convert.ToString(readerB_cr_r["NAME_OF_IE"]);
				dr_cr_r["MAN_TYPE"] = Convert.ToString(readerB_cr_r["MAN_TYPE"]);
				dr_cr_r["CONSIGNEE_DESG"] = Convert.ToString(readerB_cr_r["CONSIGNEE_DESG"]);
				dr_cr_r["DATETIME"] = Convert.ToString(readerB_cr_r["DATETIME"]);
				dr_cr_r["CONSGN_CALL_STATUS"] = Convert.ToString(readerB_cr_r["CONSGN_CALL_STATUS"]);
				dr_cr_r["pRegion"] = pregion_cr_r;
				dt.Rows.Add(dr_cr_r);
			}
			dsReports.Tables.Add(dt);
			return dsReports;

		}

		private DataSet funInspectionCertificate_cr(string pcaseno_cr, string pcsno_cr, string recvdt_cr, string pconsidecd_cr, string pregion_cr)
		{
			DataSet dsReports = new DataSet();
			string sql_cr = "SELECT     CLR.CASE_NO, CLR.Call_SNO, to_date(TO_CHAR(CLR.Call_Recv_dt, 'mm/dd/yyyy'), 'mm/dd/yyyy')Call_Recv_dt, POM.Region_Code, BOF.BPO_RLY as RLY_CD, CLR.Call_Install_No, TIE.IE_Sname, VND.Vend_Name, VND.Vend_Add1, NVL(VND.Vend_Add2, ' ') AS Vend_Add2,VCT.City AS Vend_City, MFG.Vend_Name AS MFG_Name, MFG.Vend_Add1 AS MFG_Add1,NVL(MFG.Vend_Add2, ' ') AS MFG_Add2, NVL( MCT.City,' ') AS MFG_City, CLR.MFG_PLACE, POM.PO_NO, TO_CHAR(POM.PO_DT,'dd/mm/yyyy') PO_DT, NVL(CON.CONSIGNEE_DESIG, ' ')  AS CONSIGNEE_DESIG, " +
				" CON.CONSIGNEE_CD, CCT.City AS CONSIGNEE_CITYNAME, NVL(CON.CONSIGNEE_DEPT, ' ') AS CONSIGNEE_DEPT, NVL(CON.CONSIGNEE_FIRM, ' ') AS CONSIGNEE_FIRM, NVL(PUR.CONSIGNEE_DESIG, ' ') AS PUR_DESIG, PUR.CONSIGNEE_CD AS PUR_CD,  NVL(PUR.CONSIGNEE_DEPT, ' ') AS PUR_DEPT, NVL(PUR.CONSIGNEE_FIRM, ' ') AS PUR_FIRM, NVL(PCT.City, ' ') AS PUR_City, CDT.ITEM_SRNO_PO, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.ITEM_DESC_PO ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN  " +
				" CDT.ITEM_DESC_PO ELSE CDT.ITEM_DESC_PO END END AS ITEM_DESC_PO, UOM.UOM_S_DESC, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_ORDERED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_ORDERED,0) ELSE NVL(CDT.QTY_ORDERED,0) END END AS QTY_ORDERED, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.CUM_QTY_PREV_OFFERED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.CUM_QTY_PREV_OFFERED,0)  ELSE NVL(CDT.CUM_QTY_PREV_OFFERED,0) END END AS CUM_QTY_PREV_OFFERED,  " +
				" CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.CUM_QTY_PREV_PASSED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.CUM_QTY_PREV_PASSED,0) ELSE NVL(CDT.CUM_QTY_PREV_PASSED,0) END END AS CUM_QTY_PREV_PASSED,  CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_TO_INSP,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_TO_INSP,0) ELSE NVL(CDT.QTY_TO_INSP,0) END END AS QTY_TO_INSP, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_PASSED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' " +
				" THEN NVL(CDT.QTY_PASSED,0) ELSE NVL(CDT.QTY_PASSED,0) END END AS QTY_PASSED,   CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_REJECTED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_REJECTED,0) ELSE NVL(CDT.QTY_REJECTED,0) END END AS QTY_REJECTED,  CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_DUE,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_DUE,0) ELSE NVL(CDT.QTY_DUE,0)END END AS QTY_DUE, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.HOLOGRAM ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN ICI.HOLOGRAM ELSE ICI.HOLOGRAM " +
				" END END AS HOLOGRAM, ICI.NUM_VISITS, PRM.VISIT_DATES, BOF.BPO_NAME, BOF.BPO_ORGN, BCT.City, NVL(CLR.HOLOGRAM, '    ')  AS HOLOGRAMORG, NVL(ICI.REMARK, ' ') AS REMARK, CLR.DT_INSP_DESIRE, NVL(ICI.ITEM_REMARK, 'NO REMARK') AS ITEM_REMARK, substr(ICI.AMENDMENT_1, 0, 99) AS AMENDMENT_1, substr(ICI.AMENDMENT_1, 100, 20) AS AMENDMENTDT_1, substr(ICI.AMENDMENT_2, 0, 99) AS AMENDMENT_2, substr(ICI.AMENDMENT_2, 100, 20) AS AMENDMENTDT_2, substr(ICI.AMENDMENT_3, 0, 99) AS AMENDMENT_3, substr(ICI.AMENDMENT_3, 100, 20) AS AMENDMENTDT_3, substr(ICI.AMENDMENT_4, 0, 99) AS AMENDMENT_4, substr(ICI.AMENDMENT_4, 100, 20) " +
				" AS AMENDMENTDT_4, ICI.BK_NO, ICI.SET_NO, ICI.VISITS_DATES, ICI.IE_STAMP_IMAGE, ICI.IE_STAMP_IMAGE1, TO_CHAR(ICI.LAB_TST_RECT_DT,'dd/mm/yyyy') LAB_TST_RECT_DT,ICI.PASSED_INST_NO, NVL(CONSIGNEE_DTL, '') AS CONSIGNEE_DTL, NVL(BPO_DTL, '') AS BPO_DTL,NVL(GOV_BILL_AUTH, '') AS GOV_BILL_AUTH, NVL(PUR_DTL, '') AS PUR_DTL, NVL(PUR_AUT_DTL, '') AS PUR_AUT_DTL, NVL(OFF_INST_NO_DTL, '') AS OFF_INST_NO_DTL, NVL(UNIT_DTL, '') AS UNIT_DTL, NVL(DISPATCH_PACKING_NO, '') As DISPATCH_PACKING_NO, NVL(INVOICE_NO, '') As INVOICE_NO, NVL(NAME_OF_IE, '') As NAME_OF_IE, NVL(MAN_TYPE, '') As MAN_TYPE, NVL(CONSIGNEE_DESG, '') As CONSIGNEE_DESG,TO_CHAR(ICI.DATETIME,'dd/mm/yyyy') DATETIME,ICI.CONSGN_CALL_STATUS FROM RPT_PRM_Inspection_Certificate PRM INNER JOIN  T17_Call_Register CLR ON CLR.CASE_NO = PRM.CASE_NO AND CLR.Call_Recv_dt = PRM.CALL_RECV_DT AND " +
				" CLR.Call_SNO = PRM.Call_SNO INNER JOIN T18_Call_Details CDT ON CLR.CASE_NO = CDT.CASE_NO AND CLR.Call_Recv_dt = CDT.Call_Recv_dt AND CLR.Call_SNO = CDT.Call_SNO INNER JOIN T13_PO_Master POM ON CLR.CASE_NO = POM.CASE_NO LEFT OUTER JOIN T15_PO_DETAIL POD ON CLR.CASE_NO = POD.CASE_NO AND CDT.ITEM_SRNO_PO = POD.ITEM_SRNO LEFT OUTER JOIN T04_UOM UOM ON POD.UOM_CD = UOM.UOM_CD LEFT OUTER JOIN " +
				" T09_IE TIE ON CLR.IE_CD = TIE.IE_CD LEFT OUTER JOIN T05_Vendor VND ON POM.Vend_Cd = VND.Vend_Cd LEFT OUTER JOIN   T03_City VCT ON VND.Vend_City_Cd = VCT.City_Cd LEFT OUTER JOIN T05_Vendor MFG ON CLR.MFG_CD = MFG.Vend_Cd LEFT OUTER JOIN  T03_City MCT ON MFG.Vend_City_Cd = MCT.City_Cd LEFT OUTER JOIN T14_PO_BPO BPO ON CLR.CASE_NO = BPO.CASE_NO AND CDT.CONSIGNEE_CD = BPO.CONSIGNEE_CD LEFT OUTER  " +
				" JOIN T12_BILL_PAYING_OFFICER BOF ON BPO.BPO_CD = BOF.BPO_CD LEFT OUTER JOIN  T03_City BCT ON BOF.BPO_City_Cd = BCT.City_Cd LEFT OUTER JOIN  T06_Consignee CON ON BPO.CONSIGNEE_CD = CON.CONSIGNEE_CD LEFT OUTER JOIN T03_City CCT ON CON.CONSIGNEE_CITY = CCT.City_Cd LEFT OUTER JOIN  T06_Consignee PUR ON POM.PURCHASER_CD = PUR.CONSIGNEE_CD LEFT OUTER JOIN T03_City PCT ON PUR.CONSIGNEE_CITY = PCT.City_Cd INNER JOIN " +
				" IC_INTERMEDIATE ICI ON ICI.CASE_NO = CDT.CASE_NO AND ICI.Call_Recv_dt = CDT.Call_Recv_dt AND ICI.Call_SNO = CDT.Call_SNO AND CDT.CONSIGNEE_CD = ICI.CONSIGNEE_CD AND CDT.ITEM_SRNO_PO = ICI.ITEM_SRNO_PO AND PRM.CONSIGNEE_CD = ICI.CONSIGNEE_CD WHERE ICI.ITEM_SRNO_PO IS NOT NULL and ICI.CASE_NO='" + pcaseno_cr + "' " +
				" and CLR.Call_SNO=" + pcsno_cr + " and CLR.Call_Recv_dt=to_date('" + recvdt_cr + "','mm/dd/yyyy')  and CON.CONSIGNEE_CD='" + pconsidecd_cr + "' ORDER BY CON.CONSIGNEE_CD, POD.ITEM_SRNO";
			OracleCommand cmd_cr = new OracleCommand();
			cmd_cr.CommandText = sql_cr;
			cmd_cr.Connection = conn;
			if (conn.State == ConnectionState.Closed)
				conn.Open();
			OracleDataReader readerB_cr = cmd_cr.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Columns.Add("CASE_NO", typeof(string));
			dt.Columns.Add("Call_SNO", typeof(string));
			dt.Columns.Add("Call_Recv_dt", typeof(string));
			dt.Columns.Add("Region_Code", typeof(string));
			dt.Columns.Add("RLY_CD", typeof(string));
			dt.Columns.Add("Call_Install_No", typeof(string));
			dt.Columns.Add("IE_Sname", typeof(string));
			dt.Columns.Add("Vend_Name", typeof(string));
			dt.Columns.Add("Vend_Add1", typeof(string));
			dt.Columns.Add("Vend_Add2", typeof(string));
			dt.Columns.Add("Vend_City", typeof(string));
			dt.Columns.Add("MFG_Name", typeof(string));
			dt.Columns.Add("MFG_Add1", typeof(string));
			dt.Columns.Add("MFG_Add2", typeof(string));
			dt.Columns.Add("MFG_City", typeof(string));
			dt.Columns.Add("MFG_PLACE", typeof(string));
			dt.Columns.Add("PO_NO", typeof(string));
			dt.Columns.Add("PO_DT", typeof(string));
			dt.Columns.Add("CONSIGNEE_DESIG", typeof(string));
			dt.Columns.Add("CONSIGNEE_CD", typeof(Int32));
			dt.Columns.Add("CONSIGNEE_CITYNAME", typeof(string));
			dt.Columns.Add("CONSIGNEE_DEPT", typeof(string));
			dt.Columns.Add("CONSIGNEE_FIRM", typeof(string));
			dt.Columns.Add("PUR_DESIG", typeof(string));
			dt.Columns.Add("PUR_CD", typeof(string));
			dt.Columns.Add("PUR_DEPT", typeof(string));
			dt.Columns.Add("PUR_FIRM", typeof(string));
			dt.Columns.Add("PUR_City", typeof(string));
			dt.Columns.Add("ITEM_SRNO_PO", typeof(string));
			dt.Columns.Add("ITEM_DESC_PO", typeof(string));
			dt.Columns.Add("UOM_S_DESC", typeof(string));
			dt.Columns.Add("QTY_ORDERED", typeof(double));
			dt.Columns.Add("CUM_QTY_PREV_OFFERED", typeof(double));
			dt.Columns.Add("CUM_QTY_PREV_PASSED", typeof(double));
			dt.Columns.Add("QTY_TO_INSP", typeof(double));
			dt.Columns.Add("QTY_PASSED", typeof(double));
			dt.Columns.Add("QTY_REJECTED", typeof(double));
			dt.Columns.Add("QTY_DUE", typeof(double));
			dt.Columns.Add("HOLOGRAM", typeof(string));
			dt.Columns.Add("NUM_VISITS", typeof(Int32));
			dt.Columns.Add("VISIT_DATES", typeof(string));
			dt.Columns.Add("BPO_NAME", typeof(string));
			dt.Columns.Add("BPO_ORGN", typeof(string));
			dt.Columns.Add("City", typeof(string));
			dt.Columns.Add("HOLOGRAMORG", typeof(string));
			dt.Columns.Add("REMARK", typeof(string));
			dt.Columns.Add("DT_INSP_DESIRE", typeof(string));
			dt.Columns.Add("ITEM_REMARK", typeof(string));
			dt.Columns.Add("AMENDMENT_1", typeof(string));
			dt.Columns.Add("AMENDMENTDT_1", typeof(string));
			dt.Columns.Add("AMENDMENT_2", typeof(string));
			dt.Columns.Add("AMENDMENTDT_2", typeof(string));
			dt.Columns.Add("AMENDMENT_3", typeof(string));
			dt.Columns.Add("AMENDMENTDT_3", typeof(string));
			dt.Columns.Add("AMENDMENT_4", typeof(string));
			dt.Columns.Add("AMENDMENTDT_4", typeof(string));
			dt.Columns.Add("BK_NO", typeof(string));
			dt.Columns.Add("SET_NO", typeof(string));
			dt.Columns.Add("VISITS_DATES", typeof(string));
			dt.Columns.Add("IE_STAMP_IMAGE", typeof(string));
			dt.Columns.Add("IE_STAMP_IMAGE1", typeof(string));
			dt.Columns.Add("LAB_TST_RECT_DT", typeof(string));
			dt.Columns.Add("PASSED_INST_NO", typeof(string));
			dt.Columns.Add("CONSIGNEE_DTL", typeof(string));
			dt.Columns.Add("BPO_DTL", typeof(string));
			dt.Columns.Add("GOV_BILL_AUTH", typeof(string));
			dt.Columns.Add("PUR_DTL", typeof(string));
			dt.Columns.Add("PUR_AUT_DTL", typeof(string));
			dt.Columns.Add("OFF_INST_NO_DTL", typeof(string));
			dt.Columns.Add("UNIT_DTL", typeof(string));
			dt.Columns.Add("DISPATCH_PACKING_NO", typeof(string));
			dt.Columns.Add("INVOICE_NO", typeof(string));
			dt.Columns.Add("NAME_OF_IE", typeof(string));
			dt.Columns.Add("MAN_TYPE", typeof(string));
			dt.Columns.Add("CONSIGNEE_DESG", typeof(string));
			dt.Columns.Add("DATETIME", typeof(string));
			dt.Columns.Add("CONSGN_CALL_STATUS", typeof(string));
			dt.Columns.Add("pRegion", typeof(string));
			dt.TableName = "Command";
			while (readerB_cr.Read())
			{
				DataRow dr_cr = dt.NewRow();// dsReports.Tables["Command"].Rows.Add();
				dr_cr["CASE_NO"] = Convert.ToString(readerB_cr["CASE_NO"]);
				dr_cr["Call_SNO"] = Convert.ToString(readerB_cr["Call_SNO"]);
				dr_cr["Call_Recv_dt"] = Convert.ToString(readerB_cr["Call_Recv_dt"]);
				dr_cr["Region_Code"] = Convert.ToString(readerB_cr["Region_Code"]);
				dr_cr["RLY_CD"] = Convert.ToString(readerB_cr["RLY_CD"]);
				dr_cr["Call_Install_No"] = Convert.ToString(readerB_cr["Call_Install_No"]);
				dr_cr["IE_Sname"] = Convert.ToString(readerB_cr["IE_Sname"]);
				dr_cr["Vend_Name"] = Convert.ToString(readerB_cr["Vend_Name"]);
				dr_cr["Vend_Add1"] = Convert.ToString(readerB_cr["Vend_Add1"]);
				dr_cr["Vend_Add2"] = Convert.ToString(readerB_cr["Vend_Add2"]);
				dr_cr["Vend_City"] = Convert.ToString(readerB_cr["Vend_City"]);
				dr_cr["MFG_Name"] = Convert.ToString(readerB_cr["MFG_Name"]);
				dr_cr["MFG_Add1"] = Convert.ToString(readerB_cr["MFG_Add1"]);
				dr_cr["MFG_Add2"] = Convert.ToString(readerB_cr["MFG_Add2"]);
				dr_cr["MFG_City"] = Convert.ToString(readerB_cr["MFG_City"]);
				dr_cr["MFG_PLACE"] = Convert.ToString(readerB_cr["MFG_PLACE"]);
				dr_cr["PO_NO"] = Convert.ToString(readerB_cr["PO_NO"]);
				dr_cr["PO_DT"] = Convert.ToString(readerB_cr["PO_DT"]);
				dr_cr["CONSIGNEE_DESIG"] = Convert.ToString(readerB_cr["CONSIGNEE_DESIG"]);
				dr_cr["CONSIGNEE_CD"] = Convert.ToString(readerB_cr["CONSIGNEE_CD"]);
				dr_cr["CONSIGNEE_CITYNAME"] = Convert.ToString(readerB_cr["CONSIGNEE_CITYNAME"]);
				dr_cr["CONSIGNEE_DEPT"] = Convert.ToString(readerB_cr["CONSIGNEE_DEPT"]);
				dr_cr["CONSIGNEE_FIRM"] = Convert.ToString(readerB_cr["CONSIGNEE_FIRM"]);
				dr_cr["PUR_DESIG"] = Convert.ToString(readerB_cr["PUR_DESIG"]);
				dr_cr["PUR_CD"] = Convert.ToString(readerB_cr["PUR_CD"]);
				dr_cr["PUR_DEPT"] = Convert.ToString(readerB_cr["PUR_DEPT"]);
				dr_cr["PUR_FIRM"] = Convert.ToString(readerB_cr["PUR_FIRM"]);
				dr_cr["PUR_City"] = Convert.ToString(readerB_cr["PUR_City"]);
				dr_cr["ITEM_SRNO_PO"] = Convert.ToString(readerB_cr["ITEM_SRNO_PO"]);
				dr_cr["ITEM_DESC_PO"] = Convert.ToString(readerB_cr["ITEM_DESC_PO"]);
				dr_cr["UOM_S_DESC"] = Convert.ToString(readerB_cr["UOM_S_DESC"]);
				dr_cr["QTY_ORDERED"] = Convert.ToString(readerB_cr["QTY_ORDERED"]);
				dr_cr["CUM_QTY_PREV_OFFERED"] = Convert.ToString(readerB_cr["CUM_QTY_PREV_OFFERED"]);
				dr_cr["CUM_QTY_PREV_PASSED"] = Convert.ToString(readerB_cr["CUM_QTY_PREV_PASSED"]);
				dr_cr["QTY_TO_INSP"] = Convert.ToString(readerB_cr["QTY_TO_INSP"]);
				dr_cr["QTY_PASSED"] = Convert.ToString(readerB_cr["QTY_PASSED"]);
				dr_cr["QTY_REJECTED"] = Convert.ToString(readerB_cr["QTY_REJECTED"]);
				dr_cr["QTY_DUE"] = Convert.ToString(readerB_cr["QTY_DUE"]);
				dr_cr["HOLOGRAM"] = Convert.ToString(readerB_cr["HOLOGRAM"]);
				dr_cr["NUM_VISITS"] = Convert.ToString(readerB_cr["NUM_VISITS"]);
				dr_cr["VISIT_DATES"] = Convert.ToString(readerB_cr["VISIT_DATES"]);
				dr_cr["BPO_NAME"] = Convert.ToString(readerB_cr["BPO_NAME"]);
				dr_cr["BPO_ORGN"] = Convert.ToString(readerB_cr["BPO_ORGN"]);
				dr_cr["City"] = Convert.ToString(readerB_cr["City"]);
				dr_cr["HOLOGRAMORG"] = Convert.ToString(readerB_cr["HOLOGRAMORG"]);
				dr_cr["REMARK"] = Convert.ToString(readerB_cr["REMARK"]);
				dr_cr["DT_INSP_DESIRE"] = Convert.ToString(readerB_cr["DT_INSP_DESIRE"]);
				dr_cr["ITEM_REMARK"] = Convert.ToString(readerB_cr["ITEM_REMARK"]);
				dr_cr["AMENDMENT_1"] = Convert.ToString(readerB_cr["AMENDMENT_1"]);
				dr_cr["AMENDMENTDT_1"] = Convert.ToString(readerB_cr["AMENDMENTDT_1"]);
				dr_cr["AMENDMENT_2"] = Convert.ToString(readerB_cr["AMENDMENT_2"]);
				dr_cr["AMENDMENTDT_2"] = Convert.ToString(readerB_cr["AMENDMENTDT_2"]);
				dr_cr["AMENDMENT_3"] = Convert.ToString(readerB_cr["AMENDMENT_3"]);
				dr_cr["AMENDMENTDT_3"] = Convert.ToString(readerB_cr["AMENDMENTDT_3"]);
				dr_cr["AMENDMENT_4"] = Convert.ToString(readerB_cr["AMENDMENT_4"]);
				dr_cr["AMENDMENTDT_4"] = Convert.ToString(readerB_cr["AMENDMENTDT_4"]);
				dr_cr["BK_NO"] = Convert.ToString(readerB_cr["BK_NO"]);
				dr_cr["SET_NO"] = Convert.ToString(readerB_cr["SET_NO"]);
				dr_cr["VISITS_DATES"] = Convert.ToString(readerB_cr["VISITS_DATES"]);
				dr_cr["IE_STAMP_IMAGE"] = Convert.ToString(readerB_cr["IE_STAMP_IMAGE"]);
				dr_cr["IE_STAMP_IMAGE1"] = Convert.ToString(readerB_cr["IE_STAMP_IMAGE1"]);
				dr_cr["LAB_TST_RECT_DT"] = Convert.ToString(readerB_cr["LAB_TST_RECT_DT"]);
				dr_cr["PASSED_INST_NO"] = Convert.ToString(readerB_cr["PASSED_INST_NO"]);
				dr_cr["CONSIGNEE_DTL"] = Convert.ToString(readerB_cr["CONSIGNEE_DTL"]);
				dr_cr["BPO_DTL"] = Convert.ToString(readerB_cr["BPO_DTL"]);
				dr_cr["GOV_BILL_AUTH"] = Convert.ToString(readerB_cr["GOV_BILL_AUTH"]);
				dr_cr["PUR_DTL"] = Convert.ToString(readerB_cr["PUR_DTL"]);
				dr_cr["PUR_AUT_DTL"] = Convert.ToString(readerB_cr["PUR_AUT_DTL"]);
				dr_cr["OFF_INST_NO_DTL"] = Convert.ToString(readerB_cr["OFF_INST_NO_DTL"]);
				dr_cr["UNIT_DTL"] = Convert.ToString(readerB_cr["UNIT_DTL"]);
				dr_cr["DISPATCH_PACKING_NO"] = Convert.ToString(readerB_cr["DISPATCH_PACKING_NO"]);
				dr_cr["INVOICE_NO"] = Convert.ToString(readerB_cr["INVOICE_NO"]);
				dr_cr["NAME_OF_IE"] = Convert.ToString(readerB_cr["NAME_OF_IE"]);
				dr_cr["MAN_TYPE"] = Convert.ToString(readerB_cr["MAN_TYPE"]);
				dr_cr["CONSIGNEE_DESG"] = Convert.ToString(readerB_cr["CONSIGNEE_DESG"]);
				dr_cr["DATETIME"] = Convert.ToString(readerB_cr["DATETIME"]);
				dr_cr["CONSGN_CALL_STATUS"] = Convert.ToString(readerB_cr["CONSGN_CALL_STATUS"]);
				dr_cr["pRegion"] = pregion_cr;
				dt.Rows.Add(dr_cr);
			}
			dsReports.Tables.Add(dt);
			return dsReports;

		}
		private DataSet funInspectionCertificate(string pcaseno, string pcsno, string recvdt, string pconsidecd, string pregion)
		{
			DataSet dsReports = new DataSet();
			//			string sql = "SELECT     CLR.CASE_NO, CLR.Call_SNO, to_date(TO_CHAR(CLR.Call_Recv_dt, 'mm/dd/yyyy'), 'mm/dd/yyyy')Call_Recv_dt, POM.Region_Code, BOF.BPO_RLY as RLY_CD, CLR.Call_Install_No, TIE.IE_Sname, VND.Vend_Name, VND.Vend_Add1, NVL(VND.Vend_Add2, ' ') AS Vend_Add2,VCT.City AS Vend_City, MFG.Vend_Name AS MFG_Name, MFG.Vend_Add1 AS MFG_Add1,NVL(MFG.Vend_Add2, ' ') AS MFG_Add2, NVL( MCT.City,' ') AS MFG_City, CLR.MFG_PLACE, POM.PO_NO, TO_CHAR(POM.PO_DT,'dd/mm/yyyy') PO_DT, NVL(CON.CONSIGNEE_DESIG, ' ')  AS CONSIGNEE_DESIG, "+
			//				" CON.CONSIGNEE_CD, CCT.City AS CONSIGNEE_CITYNAME, NVL(CON.CONSIGNEE_DEPT, ' ') AS CONSIGNEE_DEPT, NVL(CON.CONSIGNEE_FIRM, ' ') AS CONSIGNEE_FIRM, NVL(PUR.CONSIGNEE_DESIG, ' ') AS PUR_DESIG, PUR.CONSIGNEE_CD AS PUR_CD,  NVL(PUR.CONSIGNEE_DEPT, ' ') AS PUR_DEPT, NVL(PUR.CONSIGNEE_FIRM, ' ') AS PUR_FIRM, NVL(PCT.City, ' ') AS PUR_City, CDT.ITEM_SRNO_PO, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.ITEM_DESC_PO ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN  "+
			//				" CDT.ITEM_DESC_PO ELSE CDT.ITEM_DESC_PO END END AS ITEM_DESC_PO, UOM.UOM_S_DESC, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_ORDERED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_ORDERED,0) ELSE NVL(CDT.QTY_ORDERED,0) END END AS QTY_ORDERED, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.CUM_QTY_PREV_OFFERED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.CUM_QTY_PREV_OFFERED,0)  ELSE NVL(CDT.CUM_QTY_PREV_OFFERED,0) END END AS CUM_QTY_PREV_OFFERED,  "+
			//				" CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.CUM_QTY_PREV_PASSED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.CUM_QTY_PREV_PASSED,0) ELSE NVL(CDT.CUM_QTY_PREV_PASSED,0) END END AS CUM_QTY_PREV_PASSED,  CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_TO_INSP,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_TO_INSP,0) ELSE NVL(CDT.QTY_TO_INSP,0) END END AS QTY_TO_INSP, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_PASSED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' "+
			//				" THEN NVL(CDT.QTY_PASSED,0) ELSE NVL(CDT.QTY_PASSED,0) END END AS QTY_PASSED,   CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_REJECTED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_REJECTED,0) ELSE NVL(CDT.QTY_REJECTED,0) END END AS QTY_REJECTED,  CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_DUE,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_DUE,0) ELSE NVL(CDT.QTY_DUE,0)END END AS QTY_DUE, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.HOLOGRAM ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN ICI.HOLOGRAM ELSE ICI.HOLOGRAM "+
			//				" END END AS HOLOGRAM, ICI.NUM_VISITS, PRM.VISIT_DATES, BOF.BPO_NAME, BOF.BPO_ORGN, BCT.City, NVL(CLR.HOLOGRAM, '    ')  AS HOLOGRAMORG, NVL(ICI.REMARK, ' ') AS REMARK, CLR.DT_INSP_DESIRE, NVL(ICI.ITEM_REMARK, 'NO REMARK') AS ITEM_REMARK, substr(ICI.AMENDMENT_1, 0, 99) AS AMENDMENT_1, substr(ICI.AMENDMENT_1, 100, 20) AS AMENDMENTDT_1, substr(ICI.AMENDMENT_2, 0, 99) AS AMENDMENT_2, substr(ICI.AMENDMENT_2, 100, 20) AS AMENDMENTDT_2, substr(ICI.AMENDMENT_3, 0, 99) AS AMENDMENT_3, substr(ICI.AMENDMENT_3, 100, 20) AS AMENDMENTDT_3, substr(ICI.AMENDMENT_4, 0, 99) AS AMENDMENT_4, substr(ICI.AMENDMENT_4, 100, 20) "+
			//				" AS AMENDMENTDT_4, ICI.BK_NO, ICI.SET_NO, ICI.VISITS_DATES, ICI.IE_STAMP_IMAGE, ICI.IE_STAMP_IMAGE1, TO_CHAR(ICI.LAB_TST_RECT_DT,'dd/mm/yyyy') LAB_TST_RECT_DT,ICI.PASSED_INST_NO, NVL(CONSIGNEE_DTL, '') AS CONSIGNEE_DTL, NVL(BPO_DTL, '') AS BPO_DTL, NVL(PUR_DTL, '') AS PUR_DTL, NVL(PUR_AUT_DTL, '') AS PUR_AUT_DTL, NVL(OFF_INST_NO_DTL, '') AS OFF_INST_NO_DTL, NVL(UNIT_DTL, '') AS UNIT_DTL  ,TO_CHAR(ICI.DATETIME,'dd/mm/yyyy') DATETIME,ICI.CONSGN_CALL_STATUS FROM RPT_PRM_Inspection_Certificate PRM INNER JOIN  T17_Call_Register CLR ON CLR.CASE_NO = PRM.CASE_NO AND CLR.Call_Recv_dt = PRM.CALL_RECV_DT AND "+
			//				" CLR.Call_SNO = PRM.Call_SNO INNER JOIN T18_Call_Details CDT ON CLR.CASE_NO = CDT.CASE_NO AND CLR.Call_Recv_dt = CDT.Call_Recv_dt AND CLR.Call_SNO = CDT.Call_SNO INNER JOIN T13_PO_Master POM ON CLR.CASE_NO = POM.CASE_NO LEFT OUTER JOIN T15_PO_DETAIL POD ON CLR.CASE_NO = POD.CASE_NO AND CDT.ITEM_SRNO_PO = POD.ITEM_SRNO LEFT OUTER JOIN T04_UOM UOM ON POD.UOM_CD = UOM.UOM_CD LEFT OUTER JOIN "+
			//				" T09_IE TIE ON CLR.IE_CD = TIE.IE_CD LEFT OUTER JOIN T05_Vendor VND ON POM.Vend_Cd = VND.Vend_Cd LEFT OUTER JOIN   T03_City VCT ON VND.Vend_City_Cd = VCT.City_Cd LEFT OUTER JOIN T05_Vendor MFG ON CLR.MFG_CD = MFG.Vend_Cd LEFT OUTER JOIN  T03_City MCT ON MFG.Vend_City_Cd = MCT.City_Cd LEFT OUTER JOIN T14_PO_BPO BPO ON CLR.CASE_NO = BPO.CASE_NO AND CDT.CONSIGNEE_CD = BPO.CONSIGNEE_CD LEFT OUTER  "+
			//				" JOIN T12_BILL_PAYING_OFFICER BOF ON BPO.BPO_CD = BOF.BPO_CD LEFT OUTER JOIN  T03_City BCT ON BOF.BPO_City_Cd = BCT.City_Cd LEFT OUTER JOIN  T06_Consignee CON ON BPO.CONSIGNEE_CD = CON.CONSIGNEE_CD LEFT OUTER JOIN T03_City CCT ON CON.CONSIGNEE_CITY = CCT.City_Cd LEFT OUTER JOIN  T06_Consignee PUR ON POM.PURCHASER_CD = PUR.CONSIGNEE_CD LEFT OUTER JOIN T03_City PCT ON PUR.CONSIGNEE_CITY = PCT.City_Cd INNER JOIN "+
			//				" IC_INTERMEDIATE ICI ON ICI.CASE_NO = CDT.CASE_NO AND ICI.Call_Recv_dt = CDT.Call_Recv_dt AND ICI.Call_SNO = CDT.Call_SNO AND CDT.CONSIGNEE_CD = ICI.CONSIGNEE_CD AND CDT.ITEM_SRNO_PO = ICI.ITEM_SRNO_PO AND PRM.CONSIGNEE_CD = ICI.CONSIGNEE_CD WHERE ICI.ITEM_SRNO_PO IS NOT NULL and ICI.CASE_NO='"+pcaseno+"' "+
			//				" and CLR.Call_SNO="+pcsno+" and CLR.Call_Recv_dt=to_date('"+recvdt+"','mm/dd/yyyy')  and CON.CONSIGNEE_CD='"+pconsidecd+"' ORDER BY CON.CONSIGNEE_CD, POD.ITEM_SRNO";

			string sql = "SELECT     CLR.CASE_NO, CLR.Call_SNO, to_date(TO_CHAR(CLR.Call_Recv_dt, 'mm/dd/yyyy'), 'mm/dd/yyyy')Call_Recv_dt, to_char(CLR.Call_Recv_dt, 'dd/mm/yyyy')Call_Recv_dt_conv,POM.Region_Code, BOF.BPO_RLY as RLY_CD, CLR.Call_Install_No, TIE.IE_Sname, VND.Vend_Name, VND.Vend_Add1, NVL(VND.Vend_Add2, ' ') AS Vend_Add2,VCT.City AS Vend_City, MFG.Vend_Name AS MFG_Name, MFG.Vend_Add1 AS MFG_Add1,NVL(MFG.Vend_Add2, ' ') AS MFG_Add2, NVL( MCT.City,' ') AS MFG_City, CLR.MFG_PLACE, POM.PO_NO, TO_CHAR(POM.PO_DT,'dd/mm/yyyy') PO_DT, NVL(CON.CONSIGNEE_DESIG, ' ')  AS CONSIGNEE_DESIG, " +
				" CON.CONSIGNEE_CD, CCT.City AS CONSIGNEE_CITYNAME, NVL(CON.CONSIGNEE_DEPT, ' ') AS CONSIGNEE_DEPT, NVL(CON.CONSIGNEE_FIRM, ' ') AS CONSIGNEE_FIRM, NVL(PUR.CONSIGNEE_DESIG, ' ') AS PUR_DESIG, PUR.CONSIGNEE_CD AS PUR_CD,  NVL(PUR.CONSIGNEE_DEPT, ' ') AS PUR_DEPT, NVL(PUR.CONSIGNEE_FIRM, ' ') AS PUR_FIRM, NVL(PCT.City, ' ') AS PUR_City, CDT.ITEM_SRNO_PO, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.ITEM_DESC_PO ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN  " +
				" CDT.ITEM_DESC_PO ELSE CDT.ITEM_DESC_PO END END AS ITEM_DESC_PO, UOM.UOM_S_DESC, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_ORDERED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_ORDERED,0) ELSE NVL(CDT.QTY_ORDERED,0) END END AS QTY_ORDERED, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.CUM_QTY_PREV_OFFERED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.CUM_QTY_PREV_OFFERED,0)  ELSE NVL(CDT.CUM_QTY_PREV_OFFERED,0) END END AS CUM_QTY_PREV_OFFERED,  " +
				" CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.CUM_QTY_PREV_PASSED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.CUM_QTY_PREV_PASSED,0) ELSE NVL(CDT.CUM_QTY_PREV_PASSED,0) END END AS CUM_QTY_PREV_PASSED,  CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_TO_INSP,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_TO_INSP,0) ELSE NVL(CDT.QTY_TO_INSP,0) END END AS QTY_TO_INSP, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_PASSED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' " +
				" THEN NVL(CDT.QTY_PASSED,0) ELSE NVL(CDT.QTY_PASSED,0) END END AS QTY_PASSED,   CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_REJECTED,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_REJECTED,0) ELSE NVL(CDT.QTY_REJECTED,0) END END AS QTY_REJECTED,  CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN NVL(ICI.QTY_DUE,0) ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN NVL(CDT.QTY_DUE,0) ELSE NVL(CDT.QTY_DUE,0)END END AS QTY_DUE, CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.HOLOGRAM ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN ICI.HOLOGRAM ELSE ICI.HOLOGRAM " +
				" END END AS HOLOGRAM, ICI.NUM_VISITS, PRM.VISIT_DATES, BOF.BPO_NAME, BOF.BPO_ORGN, BCT.City, NVL(CLR.HOLOGRAM, '    ')  AS HOLOGRAMORG, NVL(ICI.REMARK, ' ') AS REMARK, CLR.DT_INSP_DESIRE, to_char(CLR.DT_INSP_DESIRE, 'dd/mm/yyyy')DT_INSP_DESIRE_conv, NVL(ICI.ITEM_REMARK, 'NO REMARK') AS ITEM_REMARK, substr(ICI.AMENDMENT_1, 0, 99) AS AMENDMENT_1, substr(ICI.AMENDMENT_1, 100, 20) AS AMENDMENTDT_1, substr(ICI.AMENDMENT_2, 0, 99) AS AMENDMENT_2, substr(ICI.AMENDMENT_2, 100, 20) AS AMENDMENTDT_2, substr(ICI.AMENDMENT_3, 0, 99) AS AMENDMENT_3, substr(ICI.AMENDMENT_3, 100, 20) AS AMENDMENTDT_3, substr(ICI.AMENDMENT_4, 0, 99) AS AMENDMENT_4, substr(ICI.AMENDMENT_4, 100, 20) " +
				" AS AMENDMENTDT_4, ICI.BK_NO, ICI.SET_NO, ICI.VISITS_DATES, ICI.IE_STAMP_IMAGE, ICI.IE_STAMP_IMAGE1, TO_CHAR(ICI.LAB_TST_RECT_DT,'dd/mm/yyyy') LAB_TST_RECT_DT,ICI.PASSED_INST_NO, NVL(CONSIGNEE_DTL, '') AS CONSIGNEE_DTL, NVL(BPO_DTL, '') AS BPO_DTL, NVL(PUR_DTL, '') AS PUR_DTL, NVL(PUR_AUT_DTL, '') AS PUR_AUT_DTL, NVL(OFF_INST_NO_DTL, '') AS OFF_INST_NO_DTL, NVL(UNIT_DTL, '') AS UNIT_DTL  ,TO_CHAR(ICI.DATETIME,'dd/mm/yyyy') DATETIME,ICI.CONSGN_CALL_STATUS FROM RPT_PRM_Inspection_Certificate PRM INNER JOIN  T17_Call_Register CLR ON CLR.CASE_NO = PRM.CASE_NO AND CLR.Call_Recv_dt = PRM.CALL_RECV_DT AND " +
				" CLR.Call_SNO = PRM.Call_SNO INNER JOIN T18_Call_Details CDT ON CLR.CASE_NO = CDT.CASE_NO AND CLR.Call_Recv_dt = CDT.Call_Recv_dt AND CLR.Call_SNO = CDT.Call_SNO INNER JOIN T13_PO_Master POM ON CLR.CASE_NO = POM.CASE_NO LEFT OUTER JOIN T15_PO_DETAIL POD ON CLR.CASE_NO = POD.CASE_NO AND CDT.ITEM_SRNO_PO = POD.ITEM_SRNO LEFT OUTER JOIN T04_UOM UOM ON POD.UOM_CD = UOM.UOM_CD LEFT OUTER JOIN " +
				" T09_IE TIE ON CLR.IE_CD = TIE.IE_CD LEFT OUTER JOIN T05_Vendor VND ON POM.Vend_Cd = VND.Vend_Cd LEFT OUTER JOIN   T03_City VCT ON VND.Vend_City_Cd = VCT.City_Cd LEFT OUTER JOIN T05_Vendor MFG ON CLR.MFG_CD = MFG.Vend_Cd LEFT OUTER JOIN  T03_City MCT ON MFG.Vend_City_Cd = MCT.City_Cd LEFT OUTER JOIN T14_PO_BPO BPO ON CLR.CASE_NO = BPO.CASE_NO AND CDT.CONSIGNEE_CD = BPO.CONSIGNEE_CD LEFT OUTER  " +
				" JOIN T12_BILL_PAYING_OFFICER BOF ON BPO.BPO_CD = BOF.BPO_CD LEFT OUTER JOIN  T03_City BCT ON BOF.BPO_City_Cd = BCT.City_Cd LEFT OUTER JOIN  T06_Consignee CON ON BPO.CONSIGNEE_CD = CON.CONSIGNEE_CD LEFT OUTER JOIN T03_City CCT ON CON.CONSIGNEE_CITY = CCT.City_Cd LEFT OUTER JOIN  T06_Consignee PUR ON POM.PURCHASER_CD = PUR.CONSIGNEE_CD LEFT OUTER JOIN T03_City PCT ON PUR.CONSIGNEE_CITY = PCT.City_Cd INNER JOIN " +
				" IC_INTERMEDIATE ICI ON ICI.CASE_NO = CDT.CASE_NO AND ICI.Call_Recv_dt = CDT.Call_Recv_dt AND ICI.Call_SNO = CDT.Call_SNO AND CDT.CONSIGNEE_CD = ICI.CONSIGNEE_CD AND CDT.ITEM_SRNO_PO = ICI.ITEM_SRNO_PO AND PRM.CONSIGNEE_CD = ICI.CONSIGNEE_CD WHERE ICI.ITEM_SRNO_PO IS NOT NULL and ICI.CASE_NO='" + pcaseno + "' " +
				" and CLR.Call_SNO=" + pcsno + " and CLR.Call_Recv_dt=to_date('" + recvdt + "','mm/dd/yyyy')  and CON.CONSIGNEE_CD='" + pconsidecd + "' ORDER BY CON.CONSIGNEE_CD, POD.ITEM_SRNO";
			//
			OracleCommand cmd = new OracleCommand();
			cmd.CommandText = sql;
			cmd.Connection = conn;
			if (conn.State == ConnectionState.Closed)
				conn.Open();
			OracleDataReader readerB = cmd.ExecuteReader();
			DataTable dt = new DataTable(); ;
			dt.Columns.Add("CASE_NO", typeof(string));
			dt.Columns.Add("Call_SNO", typeof(string));
			dt.Columns.Add("Call_Recv_dt", typeof(string));
			dt.Columns.Add("Region_Code", typeof(string));
			dt.Columns.Add("RLY_CD", typeof(string));
			dt.Columns.Add("Call_Install_No", typeof(string));
			dt.Columns.Add("IE_Sname", typeof(string));
			dt.Columns.Add("Vend_Name", typeof(string));
			dt.Columns.Add("Vend_Add1", typeof(string));
			dt.Columns.Add("Vend_Add2", typeof(string));
			dt.Columns.Add("Vend_City", typeof(string));
			dt.Columns.Add("MFG_Name", typeof(string));
			dt.Columns.Add("MFG_Add1", typeof(string));
			dt.Columns.Add("MFG_Add2", typeof(string));
			dt.Columns.Add("MFG_City", typeof(string));
			dt.Columns.Add("MFG_PLACE", typeof(string));
			dt.Columns.Add("PO_NO", typeof(string));
			dt.Columns.Add("PO_DT", typeof(string));
			dt.Columns.Add("CONSIGNEE_DESIG", typeof(string));
			dt.Columns.Add("CONSIGNEE_CD", typeof(Int32));
			dt.Columns.Add("CONSIGNEE_CITYNAME", typeof(string));
			dt.Columns.Add("CONSIGNEE_DEPT", typeof(string));
			dt.Columns.Add("CONSIGNEE_FIRM", typeof(string));
			dt.Columns.Add("PUR_DESIG", typeof(string));
			dt.Columns.Add("PUR_CD", typeof(string));
			dt.Columns.Add("PUR_DEPT", typeof(string));
			dt.Columns.Add("PUR_FIRM", typeof(string));
			dt.Columns.Add("PUR_City", typeof(string));
			dt.Columns.Add("ITEM_SRNO_PO", typeof(string));
			dt.Columns.Add("ITEM_DESC_PO", typeof(string));
			dt.Columns.Add("UOM_S_DESC", typeof(string));
			dt.Columns.Add("QTY_ORDERED", typeof(double));
			dt.Columns.Add("CUM_QTY_PREV_OFFERED", typeof(double));
			dt.Columns.Add("CUM_QTY_PREV_PASSED", typeof(double));
			dt.Columns.Add("QTY_TO_INSP", typeof(double));
			dt.Columns.Add("QTY_PASSED", typeof(double));
			dt.Columns.Add("QTY_REJECTED", typeof(double));
			dt.Columns.Add("QTY_DUE", typeof(double));
			dt.Columns.Add("HOLOGRAM", typeof(string));
			dt.Columns.Add("NUM_VISITS", typeof(Int32));
			dt.Columns.Add("VISIT_DATES", typeof(string));
			dt.Columns.Add("BPO_NAME", typeof(string));
			dt.Columns.Add("BPO_ORGN", typeof(string));
			dt.Columns.Add("City", typeof(string));
			dt.Columns.Add("HOLOGRAMORG", typeof(string));
			dt.Columns.Add("REMARK", typeof(string));
			dt.Columns.Add("DT_INSP_DESIRE", typeof(string));
			dt.Columns.Add("ITEM_REMARK", typeof(string));
			dt.Columns.Add("AMENDMENT_1", typeof(string));
			dt.Columns.Add("AMENDMENTDT_1", typeof(string));
			dt.Columns.Add("AMENDMENT_2", typeof(string));
			dt.Columns.Add("AMENDMENTDT_2", typeof(string));
			dt.Columns.Add("AMENDMENT_3", typeof(string));
			dt.Columns.Add("AMENDMENTDT_3", typeof(string));
			dt.Columns.Add("AMENDMENT_4", typeof(string));
			dt.Columns.Add("AMENDMENTDT_4", typeof(string));
			dt.Columns.Add("BK_NO", typeof(string));
			dt.Columns.Add("SET_NO", typeof(string));
			dt.Columns.Add("VISITS_DATES", typeof(string));
			dt.Columns.Add("IE_STAMP_IMAGE", typeof(string));
			dt.Columns.Add("IE_STAMP_IMAGE1", typeof(string));
			dt.Columns.Add("LAB_TST_RECT_DT", typeof(string));
			dt.Columns.Add("PASSED_INST_NO", typeof(string));
			dt.Columns.Add("CONSIGNEE_DTL", typeof(string));
			dt.Columns.Add("BPO_DTL", typeof(string));
			dt.Columns.Add("PUR_DTL", typeof(string));
			dt.Columns.Add("PUR_AUT_DTL", typeof(string));
			dt.Columns.Add("OFF_INST_NO_DTL", typeof(string));
			dt.Columns.Add("UNIT_DTL", typeof(string));
			dt.Columns.Add("DATETIME", typeof(string));
			dt.Columns.Add("CONSGN_CALL_STATUS", typeof(string));
			dt.Columns.Add("pRegion", typeof(string));
			dt.Columns.Add("Call_Recv_dt_conv", typeof(string));
			dt.Columns.Add("DT_INSP_DESIRE_conv", typeof(string));
			dt.TableName = "Command";
			while (readerB.Read())
			{
				DataRow dr = dt.NewRow();// dsReports.Tables["Command"].Rows.Add();
				dr["CASE_NO"] = Convert.ToString(readerB["CASE_NO"]);
				dr["Call_SNO"] = Convert.ToString(readerB["Call_SNO"]);
				dr["Call_Recv_dt"] = Convert.ToString(readerB["Call_Recv_dt"]);
				dr["Region_Code"] = Convert.ToString(readerB["Region_Code"]);
				dr["RLY_CD"] = Convert.ToString(readerB["RLY_CD"]);
				dr["Call_Install_No"] = Convert.ToString(readerB["Call_Install_No"]);
				dr["IE_Sname"] = Convert.ToString(readerB["IE_Sname"]);
				dr["Vend_Name"] = Convert.ToString(readerB["Vend_Name"]);
				dr["Vend_Add1"] = Convert.ToString(readerB["Vend_Add1"]);
				dr["Vend_Add2"] = Convert.ToString(readerB["Vend_Add2"]);
				dr["Vend_City"] = Convert.ToString(readerB["Vend_City"]);
				dr["MFG_Name"] = Convert.ToString(readerB["MFG_Name"]);
				dr["MFG_Add1"] = Convert.ToString(readerB["MFG_Add1"]);
				dr["MFG_Add2"] = Convert.ToString(readerB["MFG_Add2"]);
				dr["MFG_City"] = Convert.ToString(readerB["MFG_City"]);
				dr["MFG_PLACE"] = Convert.ToString(readerB["MFG_PLACE"]);
				dr["PO_NO"] = Convert.ToString(readerB["PO_NO"]);
				dr["PO_DT"] = Convert.ToString(readerB["PO_DT"]);
				dr["CONSIGNEE_DESIG"] = Convert.ToString(readerB["CONSIGNEE_DESIG"]);
				dr["CONSIGNEE_CD"] = Convert.ToString(readerB["CONSIGNEE_CD"]);
				dr["CONSIGNEE_CITYNAME"] = Convert.ToString(readerB["CONSIGNEE_CITYNAME"]);
				dr["CONSIGNEE_DEPT"] = Convert.ToString(readerB["CONSIGNEE_DEPT"]);
				dr["CONSIGNEE_FIRM"] = Convert.ToString(readerB["CONSIGNEE_FIRM"]);
				dr["PUR_DESIG"] = Convert.ToString(readerB["PUR_DESIG"]);
				dr["PUR_CD"] = Convert.ToString(readerB["PUR_CD"]);
				dr["PUR_DEPT"] = Convert.ToString(readerB["PUR_DEPT"]);
				dr["PUR_FIRM"] = Convert.ToString(readerB["PUR_FIRM"]);
				dr["PUR_City"] = Convert.ToString(readerB["PUR_City"]);
				dr["ITEM_SRNO_PO"] = Convert.ToString(readerB["ITEM_SRNO_PO"]);
				dr["ITEM_DESC_PO"] = Convert.ToString(readerB["ITEM_DESC_PO"]);
				dr["UOM_S_DESC"] = Convert.ToString(readerB["UOM_S_DESC"]);
				dr["QTY_ORDERED"] = Convert.ToString(readerB["QTY_ORDERED"]);
				dr["CUM_QTY_PREV_OFFERED"] = Convert.ToString(readerB["CUM_QTY_PREV_OFFERED"]);
				dr["CUM_QTY_PREV_PASSED"] = Convert.ToString(readerB["CUM_QTY_PREV_PASSED"]);
				dr["QTY_TO_INSP"] = Convert.ToString(readerB["QTY_TO_INSP"]);
				dr["QTY_PASSED"] = Convert.ToString(readerB["QTY_PASSED"]);
				dr["QTY_REJECTED"] = Convert.ToString(readerB["QTY_REJECTED"]);
				dr["QTY_DUE"] = Convert.ToString(readerB["QTY_DUE"]);
				dr["HOLOGRAM"] = Convert.ToString(readerB["HOLOGRAM"]);
				dr["NUM_VISITS"] = Convert.ToString(readerB["NUM_VISITS"]);
				dr["VISIT_DATES"] = Convert.ToString(readerB["VISIT_DATES"]);
				dr["BPO_NAME"] = Convert.ToString(readerB["BPO_NAME"]);
				dr["BPO_ORGN"] = Convert.ToString(readerB["BPO_ORGN"]);
				dr["City"] = Convert.ToString(readerB["City"]);
				dr["HOLOGRAMORG"] = Convert.ToString(readerB["HOLOGRAMORG"]);
				dr["REMARK"] = Convert.ToString(readerB["REMARK"]);
				dr["DT_INSP_DESIRE"] = Convert.ToString(readerB["DT_INSP_DESIRE"]);
				dr["ITEM_REMARK"] = Convert.ToString(readerB["ITEM_REMARK"]);
				dr["AMENDMENT_1"] = Convert.ToString(readerB["AMENDMENT_1"]);
				dr["AMENDMENTDT_1"] = Convert.ToString(readerB["AMENDMENTDT_1"]);
				dr["AMENDMENT_2"] = Convert.ToString(readerB["AMENDMENT_2"]);
				dr["AMENDMENTDT_2"] = Convert.ToString(readerB["AMENDMENTDT_2"]);
				dr["AMENDMENT_3"] = Convert.ToString(readerB["AMENDMENT_3"]);
				dr["AMENDMENTDT_3"] = Convert.ToString(readerB["AMENDMENTDT_3"]);
				dr["AMENDMENT_4"] = Convert.ToString(readerB["AMENDMENT_4"]);
				dr["AMENDMENTDT_4"] = Convert.ToString(readerB["AMENDMENTDT_4"]);
				dr["BK_NO"] = Convert.ToString(readerB["BK_NO"]);
				dr["SET_NO"] = Convert.ToString(readerB["SET_NO"]);
				dr["VISITS_DATES"] = Convert.ToString(readerB["VISITS_DATES"]);
				dr["IE_STAMP_IMAGE"] = Convert.ToString(readerB["IE_STAMP_IMAGE"]);
				dr["IE_STAMP_IMAGE1"] = Convert.ToString(readerB["IE_STAMP_IMAGE1"]);
				dr["LAB_TST_RECT_DT"] = Convert.ToString(readerB["LAB_TST_RECT_DT"]);
				dr["PASSED_INST_NO"] = Convert.ToString(readerB["PASSED_INST_NO"]);
				dr["CONSIGNEE_DTL"] = Convert.ToString(readerB["CONSIGNEE_DTL"]);
				dr["BPO_DTL"] = Convert.ToString(readerB["BPO_DTL"]);
				dr["PUR_DTL"] = Convert.ToString(readerB["PUR_DTL"]);
				dr["PUR_AUT_DTL"] = Convert.ToString(readerB["PUR_AUT_DTL"]);
				dr["OFF_INST_NO_DTL"] = Convert.ToString(readerB["OFF_INST_NO_DTL"]);
				dr["UNIT_DTL"] = Convert.ToString(readerB["UNIT_DTL"]);
				dr["DATETIME"] = Convert.ToString(readerB["DATETIME"]);
				dr["CONSGN_CALL_STATUS"] = Convert.ToString(readerB["CONSGN_CALL_STATUS"]);
				dr["pRegion"] = pregion;
				dr["Call_Recv_dt_conv"] = Convert.ToString(readerB["Call_Recv_dt_conv"]);
				dr["DT_INSP_DESIRE_conv"] = Convert.ToString(readerB["DT_INSP_DESIRE_conv"]);
				dt.Rows.Add(dr);
			}
			dsReports.Tables.Add(dt);
			return dsReports;
		}

		private void cristalview_Unload(object sender, System.EventArgs e)
		{
			//			this.cristalview.ReportSource = null;
			//			cristalview.Dispose();
			//			if (crystalReport != null)
			//			{
			//				crystalReport.Close();
			//				crystalReport.Dispose();
			//
			//				crystalReport = null;
			//
			//			}
			//			GC.Collect();
			//			GC.WaitForPendingFinalizers();
		}

		private void ChecGBPOdt1_CheckedChanged(object sender, System.EventArgs e)
		{
			TextGBPO.Enabled = ChecGBPOdt1.Checked;
		}

		private void lstmantype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstmantype.SelectedValue == "B")
			{
				Label_dis_pac.Text = "Dispatch Adive No.";
			}
			else if (lstmantype.SelectedValue == "J")
			{
				Label_dis_pac.Text = "Packing List No.";
			}
			else
			{
				//Man_type.Visible=false;
				GBPO_DES.Visible = false;
				OFF_INST_NO.Visible = true;
				I_UOM.Visible = true;
				Labelqtyod.Text = "QTY ORDERED";
				Labelcumqtyoffer.Text = "CUM QTY PREV OFFERED";
				Labelqtypass.Text = "QTY PASSED";
				LabelVT.Text = "Visits Dates";
				LAB_RE.Visible = true;
				Labelinst.Text = "Passed instt. Note";
				DIS_PAC_NO.Visible = false;
				INVOICE_NO.Visible = false;
				NAME_INS_ENG.Visible = false;
				CONS_DESG.Visible = false;
			}


		}

		private void lstman()
		{
			if (lstmantype.SelectedValue == "B")
			{
				Label_dis_pac.Text = "Dispatch Adive No.";
			}
			else if (lstmantype.SelectedValue == "J")
			{
				Label_dis_pac.Text = "Packing List No.";
			}
			else
			{
				//Man_type.Visible=false;
				GBPO_DES.Visible = false;
				OFF_INST_NO.Visible = true;
				I_UOM.Visible = true;
				Labelqtyod.Text = "QTY ORDERED";
				Labelcumqtyoffer.Text = "CUM QTY PREV OFFERED";
				Labelqtypass.Text = "QTY PASSED";
				LabelVT.Text = "Visits Dates";
				LAB_RE.Visible = true;
				Labelinst.Text = "Passed instt. Note";
				DIS_PAC_NO.Visible = false;
				INVOICE_NO.Visible = false;
				NAME_INS_ENG.Visible = false;
				CONS_DESG.Visible = false;
			}

		}
	}
}

