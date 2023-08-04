using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Complaint_Entry
{
	public partial class Complaint_Entry : System.Web.UI.Page
	{
		OracleConnection Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.Label lblConsCity;
		protected System.Web.UI.WebControls.TextBox txtKAPA;
		OracleConnection MyConn = null;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnCancelJI.Attributes.Add("OnClick", "JavaScript:confirmAction();");
			btnJIChoice.Attributes.Add("OnClick", "JavaScript:CheckJiRegion();");
			btnJIOutcome.Attributes.Add("OnClick", "JavaScript:validate2();");
			if (!(IsPostBack))
			{
				if ((Convert.ToString(Request.Params["CASE_NO"]) != null) & (Convert.ToString(Request.Params["BK_NO"]) != null) & (Convert.ToString(Request.Params["SET_NO"]) != null))
				{
					lblCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"].Trim());
					lblBkNo.Text = Convert.ToString(Request.Params["BK_NO"].Trim());
					lblSetNo.Text = Convert.ToString(Request.Params["SET_NO"].Trim());
					fill_lstCO();
					FindIE();

					//				
					string wRegion = Convert.ToString(Session["REGION"]);
					if (wRegion == "N") { lblRegion.Text = "Northern Region"; }
					else if (wRegion == "E") { lblRegion.Text = "Eastern Region"; }
					else if (wRegion == "W") { lblRegion.Text = "Western Region"; }
					else if (wRegion == "S") { lblRegion.Text = "Southern Region"; }
					else if (wRegion == "C") { lblRegion.Text = "Central Region"; }
					else { lblRegion.Text = ""; }
					lblCompRecvRgn.Text = wRegion;

					rbs.SetFocus(txtComplaintDt);
				}
				else if (Convert.ToString(Request.Params["COMPLAINT_ID"]) != null)
				{
					lblComplaintId.Text = Convert.ToString(Request.Params["COMPLAINT_ID"].Trim());
					getComplaintDetails();
					if (lblJiSno.Text.Trim() != "")
					{
						lstPoItems.Visible = false;
						btnSave.Enabled = false;
						lstJIRequired.Enabled = false;
						lstJiRegion.Enabled = false;
						lblJiSrNo.Visible = true;
						fill_lstDefectCd();
						fill_lstClassification();

						if (lstJiRegion.SelectedValue == Session["Region"].ToString())
						{
							btnJIChoice.Enabled = true;
							btnCancelJI.Enabled = true;
							btnJIOutcome.Enabled = true;

						}
						else if (lblCompRecvRgn.Text == Session["Region"].ToString())
						{
							btnJIChoice.Enabled = false;
							btnCancelJI.Enabled = false;
							btnJIOutcome.Enabled = false;


						}
						else
						{
							btnJIChoice.Enabled = false;
							btnCancelJI.Enabled = false;
							btnJIOutcome.Enabled = false;

						}

						if (Session["Region"].ToString() == lblCaseNo.Text.Substring(0, 1))
						{
							btnFinalDisposal.Enabled = true;
						}
						else
						{
							btnFinalDisposal.Enabled = false;
						}


						string fpath1 = Server.MapPath("/RBS/COMPLAINTS_REPORT/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".TIF");
						string fpath11 = Server.MapPath("/RBS/COMPLAINTS_REPORT/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".PDF");
						if (File.Exists(fpath1) == false && File.Exists(fpath11) == false)
						{
							Label38.Visible = true;
							File2.Visible = true;
							HypReport.Visible = false;
						}
						else if (File.Exists(fpath1) == false && File.Exists(fpath11) == true)
						{
							HypReport.NavigateUrl = "/RBS/COMPLAINTS_REPORT/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".PDF";
							HypReport.Visible = true;
							Label38.Visible = true;
							File2.Visible = true;
						}
						else
						{
							HypReport.NavigateUrl = "/RBS/COMPLAINTS_REPORT/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".TIF";
							HypReport.Visible = true;
							Label38.Visible = true;
							File2.Visible = true;


						}


						string fpath44 = Server.MapPath("/RBS/COMPLAINTS_TECH_REF/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".PDF");
						if (File.Exists(fpath44) == false)
						{
							Label46.Visible = true;
							File4.Visible = true;
							HypTech_Ref.Visible = false;
						}
						else if (File.Exists(fpath44) == true)
						{
							HypTech_Ref.NavigateUrl = "/RBS/COMPLAINTS_TECH_REF/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".PDF";
							HypTech_Ref.Visible = true;
							Label46.Visible = true;
							File4.Visible = true;
						}

					}
					string fpath2 = Server.MapPath("/RBS/COMPLAINTS_CASES/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".TIF");
					string fpath22 = Server.MapPath("/RBS/COMPLAINTS_CASES/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".PDF");
					if (File.Exists(fpath2) == false && File.Exists(fpath22) == false)
					{
						Label37.Visible = true;
						File1.Visible = true;
						btnUploadCase.Visible = true;
						HypCase.Visible = false;
					}
					else if (File.Exists(fpath2) == false && File.Exists(fpath22) == true)
					{
						HypCase.NavigateUrl = "/RBS/COMPLAINTS_CASES/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".PDF";
						HypCase.Visible = true;
						Label37.Visible = false;
						File1.Visible = false;
						btnUploadCase.Visible = false;
					}
					else
					{
						HypCase.NavigateUrl = "/RBS/COMPLAINTS_CASES/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".TIF";
						HypCase.Visible = true;
						Label37.Visible = false;
						File1.Visible = false;
						btnUploadCase.Visible = false;

					}

					string fpath3 = Server.MapPath("/RBS/REJECTION_MEMO/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".TIF");
					string fpath33 = Server.MapPath("/RBS/REJECTION_MEMO/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".PDF");
					if (File.Exists(fpath3) == false && File.Exists(fpath33) == false)
					{
						Label40.Visible = true;
						File3.Visible = true;
						btnRejMemo.Visible = true;
						HypRejMemo.Visible = false;
					}
					else if (File.Exists(fpath3) == false && File.Exists(fpath33) == true)
					{
						HypRejMemo.NavigateUrl = "/RBS/REJECTION_MEMO/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".PDF";
						HypRejMemo.Visible = true;
						Label40.Visible = false;
						File3.Visible = false;
						btnRejMemo.Visible = false;
					}
					else
					{
						HypRejMemo.NavigateUrl = "/RBS/REJECTION_MEMO/" + lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim() + ".TIF";
						HypRejMemo.Visible = true;
						Label40.Visible = false;
						File3.Visible = false;
						btnRejMemo.Visible = false;

					}
					fill_lstCO();
				}

				fill_lstPoItems();
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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			if ((Convert.ToString(Request.Params["COMPLAINT_ID"]) == null) & (generate_complaint_id().Trim() == "-1"))
			{
				DisplayAlert("Unable to Generate Complaint Id");
			}
			else
			{
				try
				{
					Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					Conn.Open();
					OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", Conn);
					string wDate = Convert.ToString(MyCmd.ExecuteScalar());
					string MySql = "";
					string MyMsg = "";
					//					string str="SELECT NVL(COUNT(*),0) FROM T40_CONSIGNEE_COMPLAINTS WHERE CASE_NO='"+lblCaseNo.Text+"' AND BK_NO='"+lblBkNo.Text+"' AND SET_NO='"+lblSetNo.Text+"'";
					//					OracleCommand CheckCmd = new OracleCommand(str,Conn);
					//					int compcount=Convert.ToInt16(CheckCmd.ExecuteScalar());


					//
					if (lblComplaintId.Text == " -x-")
					{

						lblComplaintId.Text = generate_complaint_id();
						MySql = "Insert into T40_CONSIGNEE_COMPLAINTS(COMPLAINT_ID,COMPLAINT_DT,REJ_MEMO_NO,REJ_MEMO_DT,CASE_NO," +
							"BK_NO,SET_NO,INSP_REGION,IE_CD,IE_CO_CD,COMP_RECV_REGION,CONSIGNEE_CD,VEND_CD,ITEM_SRNO_PO,ITEM_DESC," +
							"QTY_OFFERED,QTY_REJECTED,UOM_CD,RATE,REJECTION_VALUE,REJECTION_REASON,USER_ID,DATETIME) " +
							"values " +
							"('" + lblComplaintId.Text + "',to_date('" + txtComplaintDt.Text + "','dd/mm/yyyy'),'" + txtMemoNo.Text + "',to_date('" + txtMemoDt.Text + "','dd/mm/yyyy'),'" + lblCaseNo.Text +
							"','" + lblBkNo.Text + "','" + lblSetNo.Text + "',substr('" + lblCaseNo.Text + "',1,1)," + lblIECd.Text + "," + lstCO.SelectedValue + ",'" + lblCompRecvRgn.Text + "'," + lblConsigneeCd.Text +
							"," + lblVendorCd.Text + "," + lblItemSrnoPo.Text + ",'" + lblItemDesc.Text + "'," + txtQtyOffered.Text + "," + txtQtyRej.Text + "," + lblUOM.Text + "," + lblRate.Text + "," + txtValueRej.Text + ",'" + txtRejReason.Text +
							"','" + Session["Uname"] + "',to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS'))";
						MyMsg = "Complaint Id -> " + lblComplaintId.Text;


					}
					else
					{
						MySql = "Update T40_CONSIGNEE_COMPLAINTS " +
							"Set IE_CO_CD=" + lstCO.SelectedValue + ",REJ_MEMO_NO='" + txtMemoNo.Text + "',REJ_MEMO_DT=to_date('" + txtMemoDt.Text + "','dd/mm/yyyy'),ITEM_SRNO_PO=" + lblItemSrnoPo.Text + ",ITEM_DESC='" + lblItemDesc.Text + "'," +
							"QTY_OFFERED=" + txtQtyOffered.Text + ",QTY_REJECTED=" + txtQtyRej.Text + ",UOM_CD=" + lblUOM.Text + ",RATE=" + lblRate.Text + ",REJECTION_VALUE=" + txtValueRej.Text + "," +
							"REJECTION_REASON='" + txtRejReason.Text + "',USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
							"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
						MyMsg = "Record Updated";
					}
					//
					OracleCommand cmd = new OracleCommand(MySql, Conn);
					cmd.ExecuteNonQuery();
					DisplayAlert(MyMsg);
					btnSave.Enabled = false;

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
					Conn.Close();
					Conn.Dispose();
				}
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}


		private void FindIE()
		{
			lblIE.Text = "";
			lblPoNo.Text = "";
			lblRly.Text = "";
			lblConsignee.Text = "";
			lblIECd.Text = "";
			lblConsigneeCd.Text = "";
			if (lblCaseNo.Text.Trim() == "" || lblBkNo.Text.Trim() == "" || lblSetNo.Text.Trim() == "") { }
			else
			{
				//Populate PO NO,PO Date, Railway,IE Name and Consignee//
				string MySql = "Select t09.IE_CD, t09.IE_NAME,trim(t13.PO_NO)||' dated- '||to_char(t13.PO_DT,'dd/mm/yyyy') PO,t13.RLY_CD,t20.CONSIGNEE_CD,to_char(t20.IC_DT,'dd/mm/yyyy') IC_DT,v06.CONSIGNEE,t13.VEND_CD,v05.VENDOR, NVL(t20.CO_CD,0) CO_CD " +
							"From T09_IE t09,T13_PO_MASTER t13,T20_IC t20,V06_CONSIGNEE v06,V05_VENDOR v05 " +
							"Where t20.CASE_NO='" + lblCaseNo.Text + "' and t20.BK_NO='" + lblBkNo.Text + "' and t20.SET_NO='" + lblSetNo.Text + "' " +
							"and t20.IE_CD=t09.IE_CD and t13.CASE_NO=t20.CASE_NO and t13.VEND_CD=v05.VEND_CD and t20.CONSIGNEE_CD=v06.CONSIGNEE_CD";
				try
				{
					Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					OracleCommand cmd = new OracleCommand(MySql, Conn);
					Conn.Open();
					OracleDataReader MyReader = cmd.ExecuteReader();
					while (MyReader.Read())
					{
						lblIE.Text = MyReader["IE_NAME"].ToString();
						lblPoNo.Text = MyReader["PO"].ToString();
						lblRly.Text = MyReader["RLY_CD"].ToString();
						lblConsignee.Text = MyReader["CONSIGNEE"].ToString();
						lblVendor.Text = MyReader["VENDOR"].ToString();
						lblIECd.Text = MyReader["IE_CD"].ToString();
						lblConsigneeCd.Text = MyReader["CONSIGNEE_CD"].ToString();
						lblVendorCd.Text = MyReader["VEND_CD"].ToString();
						lblIcDate.Text = MyReader["IC_DT"].ToString();
						lstCO.SelectedValue = MyReader["CO_CD"].ToString();
					}
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
					Conn.Close();
					Conn.Dispose();
				}
			}
		}
		private void getComplaintDetails()
		{
			try
			{
				Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				Conn.Open();
				string MySql = "Select to_char(COMPLAINT_DT,'dd/mm/yyyy')COMPLAINT_DATE,REJ_MEMO_NO,to_char(REJ_MEMO_DT,'dd/mm/yyyy')REJ_MEMO_DATE,CASE_NO,BK_NO,SET_NO," +
							 "trim(PO_NO)||' dated- '||to_char(PO_DT,'dd/mm/yyyy') PO,RLY_CD,to_char(IC_DT,'dd/mm/yyyy') IC_DT,INSP_REGION_NAME,IE_NAME,IE_CO_CD,COMP_RECV_REGION,COMP_RECV_REGN_NAME," +
							 "(CONSIGNEE_NAME||'/'||CONSIGNEE_ADDR)CONSIGNEE,VENDOR,ITEM_SRNO_PO,ITEM_DESC,QTY_OFFERED,QTY_REJECTED,UOM_CD,UOM_S_DESC,RATE,REJECTION_VALUE,ROOT_CAUSE_ANALYSIS,TECH_REF,CHKSHEET_STATUS,ANY_OTHER,CAPA_STATUS,DANDAR_STATUS," +
							 "REJECTION_REASON,STATUS,JI_REQUIRED,JI_REGION,NO_JI_REASON,NO_JI_OTHER,JI_IE_CD,REMARKS,JI_SNO,to_char(JI_FIX_DT,'dd/mm/yyyy') JI_FIX_DT,to_char(JI_DT,'dd/mm/yyyy') JI_DT,DEFECT_CD,JI_STATUS_CD,to_char(CONCLUSION_DT,'dd/mm/yyyy')CONCLUSION_DT,ACTION_PROPOSED,to_char(ACTION_PROPOSED_DT,'dd/mm/yyyy')ACTION_PROPOSED_DT,PENALTY_TYPE,to_char(PENALTY_DT,'dd/mm/yyyy')PENALTY_DT,ACTION " +
							 "From V40_CONSIGNEE_COMPLAINTS Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
				OracleCommand cmd = new OracleCommand(MySql, Conn);
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					lblRegion.Text = MyReader["COMP_RECV_REGN_NAME"].ToString();
					lblCompRecvRgn.Text = MyReader["COMP_RECV_REGION"].ToString();
					txtComplaintDt.Text = MyReader["COMPLAINT_DATE"].ToString();
					txtComplaintDt.Enabled = false;
					lblCaseNo.Text = MyReader["CASE_NO"].ToString();
					lblBkNo.Text = MyReader["BK_NO"].ToString();
					lblSetNo.Text = MyReader["SET_NO"].ToString();
					lblIE.Text = MyReader["IE_NAME"].ToString();
					lblCO.Text = MyReader["IE_CO_CD"].ToString();
					lblPoNo.Text = MyReader["PO"].ToString();
					lblRly.Text = MyReader["RLY_CD"].ToString();
					lblIcDate.Text = MyReader["IC_DT"].ToString();
					lblConsignee.Text = MyReader["CONSIGNEE"].ToString();
					lblVendor.Text = MyReader["VENDOR"].ToString();
					txtMemoNo.Text = MyReader["REJ_MEMO_NO"].ToString();
					txtMemoDt.Text = MyReader["REJ_MEMO_DATE"].ToString();
					lblItemSrnoPo.Text = MyReader["ITEM_SRNO_PO"].ToString();
					lblItemDesc.Text = MyReader["ITEM_DESC"].ToString();
					txtQtyOffered.Text = MyReader["QTY_OFFERED"].ToString();
					txtQtyRej.Text = MyReader["QTY_REJECTED"].ToString();
					lblUOM.Text = MyReader["UOM_CD"].ToString();
					lblUOMDesc.Text = MyReader["UOM_S_DESC"].ToString();
					lblRate.Text = MyReader["RATE"].ToString();
					lblUomRate.Text = " per " + lblUOMDesc.Text;
					txtValueRej.Text = MyReader["REJECTION_VALUE"].ToString();
					txtRejReason.Text = MyReader["REJECTION_REASON"].ToString();
					lstJIRequired.SelectedValue = MyReader["JI_REQUIRED"].ToString();
					lstJiRegion.SelectedValue = MyReader["JI_REGION"].ToString();
					lslNOJIReasons.SelectedValue = MyReader["NO_JI_REASON"].ToString();
					txtNoJIOthers.Text = MyReader["NO_JI_OTHER"].ToString();
					if (lslNOJIReasons.SelectedValue == "K")
					{
						txtNoJIOthers.Visible = true;
					}
					else
					{
						txtNoJIOthers.Visible = false;
					}
					if (lstJIRequired.SelectedValue == "N")
					{
						lslNOJIReasons.Visible = true;
						Label39.Visible = true;
					}
					fill_JIIE_Cd();
					lstJIIE.SelectedValue = MyReader["JI_IE_CD"].ToString();
					txtRemarks.Text = MyReader["REMARKS"].ToString();
					lblJiSno.Text = MyReader["JI_SNO"].ToString();
					txtJIFixDT.Text = MyReader["JI_FIX_DT"].ToString();
					txtDtJi.Text = MyReader["JI_DT"].ToString();
					if (lblJiSno.Text.Trim() != "")
					{
						txtDtJi.Enabled = false;
					}
					lblDefectCD.Text = MyReader["DEFECT_CD"].ToString();
					lblClassification.Text = MyReader["JI_STATUS_CD"].ToString();
					txtStatus.Text = MyReader["STATUS"].ToString();
					txtConclusionDt.Text = MyReader["CONCLUSION_DT"].ToString();
					lstAction.SelectedValue = MyReader["ACTION_PROPOSED"].ToString();
					txtDtIssue.Text = MyReader["ACTION_PROPOSED_DT"].ToString();
					fill_penalty();
					lstPenaltyType.SelectedValue = MyReader["PENALTY_TYPE"].ToString();
					txtPenaltyDt.Text = MyReader["PENALTY_DT"].ToString();
					txtAction.Text = MyReader["ACTION"].ToString();
					txtRootCAnalysis.Text = MyReader["ROOT_CAUSE_ANALYSIS"].ToString();
					txtTech_Ref.Text = MyReader["TECH_REF"].ToString();
					ddlChksheet.SelectedValue = MyReader["CHKSHEET_STATUS"].ToString();
					txtAnyOther.Text = MyReader["ANY_OTHER"].ToString();
					txtCAPA.Text = MyReader["CAPA_STATUS"].ToString();
					txtDARStatus.Text = MyReader["DANDAR_STATUS"].ToString();
				}
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
				Conn.Close();
				Conn.Dispose();
			}
		}
		void send_IE_Email()
		{
			Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string wRegion = "";
				if (Session["Region"].ToString() == "N") { wRegion = "CONTROLLING MANAGER (JI/NR) \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : 011-22029101 \n Fax : 011-22024665"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "CONTROLLING MANAGER (JI/SR) \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292807/044- 28292817 \n Fax : 044-28290359"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "CONTROLLING MANAGER (JI/ER) \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "CONTROLLING MANAGER (JI/WR) \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "CONTROLLING MANAGER (JI/CR)"; }

				OracleCommand cmd_vend = new OracleCommand("Select IE_NAME,IE_EMAIL,CO_EMAIL from T20_IC T20, T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T20.IE_CD=T09.IE_CD and T20.CO_CD=T08.CO_CD(+) and CASE_NO='" + lblCaseNo.Text.Trim() + "' and BK_NO='" + lblBkNo.Text.Trim() + "' and SET_NO='" + lblSetNo.Text.Trim() + "'", Conn);
				Conn.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string ie_name = "", ie_email = "", co_email = "";
				while (reader.Read())
				{
					ie_name = Convert.ToString(reader["IE_NAME"]);
					ie_email = Convert.ToString(reader["IE_EMAIL"]);
					co_email = Convert.ToString(reader["CO_EMAIL"]);

				}
				Conn.Close();
				string mail_body = "";
				if (lblCaseNo.Text.Substring(0, 1) == Session["Region"].ToString())
				{
					mail_body = "Dear " + ie_name + ",\n\n Complaint has Registered Vide Complaint No: " + lblComplaintId.Text + ", Dated:" + txtComplaintDt.Text + " \n Consignee: " + lblConsignee.Text + " \n PO No. - " + lblPoNo.Text + " \n Book No -  " + lblBkNo.Text + " & Set No - " + lblSetNo.Text + " \n Vendor -" + lblVendor.Text + " \n Item- " + lstPoItems.SelectedItem.Text + " \n Rejected Qty -" + txtQtyRej.Text + " \n Rejection Memo No. " + txtMemoDt.Text + " Dated: " + txtMemoDt.Text + " \n Reason for Rejection -" + txtRejReason.Text + ". \n\n You are requested to send your comments on the rejection at TOP Prioity. \n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). \n\n " + wRegion + ".";
				}
				else
				{
					if (lblCaseNo.Text.Substring(0, 1) == "N")
					{
						mail_body = "Controlling Manager (JI/NR), \n\n ";
					}
					else if (lblCaseNo.Text.Substring(0, 1) == "W")
					{
						mail_body = "Controlling Manager (JI/WR), \n\n ";
					}
					else if (lblCaseNo.Text.Substring(0, 1) == "E")
					{
						mail_body = "Controlling Manager (JI/ER), \n\n ";
					}
					else if (lblCaseNo.Text.Substring(0, 1) == "S")
					{
						mail_body = "Controlling Manager (JI/SR), \n\n ";
					}
					mail_body = mail_body + " Complaint has Registered Vide Complaint No: " + lblComplaintId.Text + ", Dated:" + txtComplaintDt.Text + " \n Consignee: " + lblConsignee.Text + " \n PO No. - " + lblPoNo.Text + " \n Book No -  " + lblBkNo.Text + " & Set No - " + lblSetNo.Text + " \n Vendor -" + lblVendor.Text + " \n Item- " + lstPoItems.SelectedItem.Text + " \n Rejected Qty -" + txtQtyRej.Text + " \n Rejection Memo No. " + txtMemoDt.Text + " Dated: " + txtMemoDt.Text + " \n Reason for Rejection -" + txtRejReason.Text + ". \n\n You are requested to send complete Inspection Case with comments for arranging JI at TOP Prioity. \n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). \n\n" + wRegion + ".";
					mail_body = mail_body + "\n\n THIS IS AN AUTO GENERATED EMAIL. PLEASE DO NOT REPLY. USE EMAIL GIVEN IN THE REGION ADDRESS";
				}
				string sender = "";
				if (Session["Region"].ToString() == "N")
				{
					sender = "nrcomplaints@gmail.com";
				}
				else if (Session["Region"].ToString() == "W")
				{
					sender = "wrinspn@rites.com";
				}
				else if (Session["Region"].ToString() == "E")
				{
					sender = "erinspn@rites.com";
				}
				else if (Session["Region"].ToString() == "S")
				{
					sender = "srinspn@rites.com";
				}
				string cc = "";

				if (lblCaseNo.Text.Substring(0, 1) == "N")
				{
					cc = "nrcomplaints@gmail.com;pklal@rites.com";
				}
				else if (lblCaseNo.Text.Substring(0, 1) == "W")
				{
					cc = "wrinspn@rites.com;harisankarprasad@rites.com";
				}
				else if (lblCaseNo.Text.Substring(0, 1) == "E")
				{
					cc = "erinspn@rites.com;ercomplaints@gmail.com";
				}
				else if (lblCaseNo.Text.Substring(0, 1) == "S")
				{
					cc = "srinspn@rites.com;ravis@rites.com;ravis@rites.com";
				}

				Conn.Open();
				OracleCommand myCommand = new OracleCommand("select IE_EMAIL from T09_IE where IE_CD= " + lstJIIE.SelectedValue, Conn);
				string JI_IE = Convert.ToString(myCommand.ExecuteScalar());
				Conn.Close();

				if (lblCaseNo.Text.Substring(0, 1) == Session["Region"].ToString())
				{
                    System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
                    mail.To = ie_email + ";" + co_email;
					mail.Cc = cc + ";" + JI_IE;
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Consignee Complaint Has Been Registered for Joint Inspection (JI)";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = (System.Web.Mail.MailPriority)System.Net.Mail.MailPriority.High;
					SmtpMail.Send(mail);
				}
				else
				{
					if (Session["Region"].ToString() == "N")
					{
						cc = cc + ";nrcomplaints@gmail.com;pklal@rites.com";
					}
					else if (Session["Region"].ToString() == "S")
					{
						cc = cc + ";srinspn@rites.com;ravis@rites.com";
					}
					else if (Session["Region"].ToString() == "W")
					{
						cc = cc + ";wrinspn@rites.com;ravis@rites.com";
					}
					else if (Session["Region"].ToString() == "E")
					{
						cc = cc + ";erinspn@rites.com;ercomplaints@gmail.com";
					}
                    System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
					mail.To = cc + ";" + JI_IE;
					mail.Cc = ie_email + ";" + co_email;
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Consignee Complaint Has Been Registered for Joint Inspection (JI)";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = (System.Web.Mail.MailPriority)System.Net.Mail.MailPriority.High;
					SmtpMail.Send(mail);

				}


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
		}

		void send_Conclusion_Email()
		{
			Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string wRegion = "";
				if (Session["Region"].ToString() == "N") { wRegion = "CONTROLLING MANAGER (JI/NR) \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : 011-22029101 \n Fax : 011-22024665"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "CONTROLLING MANAGER (JI/SR) \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292807/044- 28292817 \n Fax : 044-28290359"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "CONTROLLING MANAGER (JI/ER) \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "CONTROLLING MANAGER (JI/WR) \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "CONTROLLING MANAGER (JI/CR)"; }

				OracleCommand cmd_vend = new OracleCommand("Select IE_NAME,IE_EMAIL,CO_EMAIL from T20_IC T20, T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T20.IE_CD=T09.IE_CD and T20.CO_CD=T08.CO_CD(+) and CASE_NO='" + lblCaseNo.Text.Trim() + "' and BK_NO='" + lblBkNo.Text.Trim() + "' and SET_NO='" + lblSetNo.Text.Trim() + "'", Conn);
				Conn.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string ie_name = "", ie_email = "", co_email = "";
				while (reader.Read())
				{
					ie_name = Convert.ToString(reader["IE_NAME"]);
					ie_email = Convert.ToString(reader["IE_EMAIL"]);
					co_email = Convert.ToString(reader["CO_EMAIL"]);

				}
				Conn.Close();
				string mail_body = "";
				//				if(lblCaseNo.Text.Substring(0,1)==Session["Region"].ToString())
				//				{		
				mail_body = "Dear Sir,<br><br> Complaint No: " + lblComplaintId.Text + ", Dated:" + txtComplaintDt.Text + " <br> Consignee: " + lblConsignee.Text + " <br> PO No. - " + lblPoNo.Text + " <br> Book No -  " + lblBkNo.Text + " & Set No - " + lblSetNo.Text + " <br> Vendor -" + lblVendor.Text + " <br> Item- " + lstPoItems.SelectedItem.Text + " <br> Rejected Qty -" + txtQtyRej.Text + " <br> Rejection Memo No. " + txtMemoDt.Text + " Dated: " + txtMemoDt.Text + " <br> Reason for Rejection -" + txtRejReason.Text + ". <br><br> The JI case No." + lblJiSno.Text + " has been concluded as " + lstClassification.SelectedItem.Text + ". <br>Details of the case  has been uploaded on following link: <a href='http://rites.ritesinsp.com/RBS/COMPLAINTS_REPORT/" + lblJi_Rep_Path.Text + "'><b>JI Report</b></a> <br> NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). <br><br> " + wRegion + ".";
				//				}
				//				else
				//				{
				//					if(lblCaseNo.Text.Substring(0,1)=="N")
				//					{
				//						mail_body="Controlling Manager (JI/NR), \n\n " ;
				//					}
				//					else if(lblCaseNo.Text.Substring(0,1)=="W")
				//					{
				//						mail_body="Controlling Manager (JI/WR), \n\n " ;
				//					}
				//					else if(lblCaseNo.Text.Substring(0,1)=="E")
				//					{
				//						mail_body="Controlling Manager (JI/ER), \n\n " ;
				//					}
				//					else if(lblCaseNo.Text.Substring(0,1)=="S")
				//					{
				//						mail_body="Controlling Manager (JI/SR), \n\n " ;
				//					}
				//					mail_body=mail_body +" Complaint has Registered Vide Complaint No: "+lblComplaintId.Text+", Dated:"+txtComplaintDt.Text+" \n Consignee: "+lblConsignee.Text+" \n PO No. - "+lblPoNo.Text+" \n Book No -  " + lblBkNo.Text +" & Set No - "+lblSetNo.Text+" \n Vendor -"+lblVendor.Text+" \n Item- "+lstPoItems.SelectedItem.Text+" \n Rejected Qty -"+txtQtyRej.Text+" \n Rejection Memo No. "+txtMemoDt.Text+" Dated: "+txtMemoDt.Text+" \n Reason for Rejection -"+txtRejReason.Text+". \n\n You are requested to send complete Inspection Case with comments for arranging JI at TOP Prioity. \n NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). \n\n"+ wRegion +"." ;
				mail_body = mail_body + "\n\n THIS IS AN AUTO GENERATED EMAIL. PLEASE DO NOT REPLY. USE EMAIL GIVEN IN THE REGION ADDRESS";
				//				}
				string sender = "";
				if (Session["Region"].ToString() == "N")
				{
					sender = "nrcomplaints@gmail.com";
				}
				else if (Session["Region"].ToString() == "W")
				{
					sender = "wrinspn@rites.com";
				}
				else if (Session["Region"].ToString() == "E")
				{
					sender = "erinspn@rites.com";
				}
				else if (Session["Region"].ToString() == "S")
				{
					sender = "srinspn@rites.com";
				}
				string cc = "";

				if (lblCaseNo.Text.Substring(0, 1) == "N")
				{
					cc = "nrcomplaints@gmail.com;pklal@rites.com;sbu.ninsp@rites.com";
				}
				else if (lblCaseNo.Text.Substring(0, 1) == "W")
				{
					cc = "wrinspn@rites.com;harisankarprasad@rites.com;sbu.winsp@rites.com";
				}
				else if (lblCaseNo.Text.Substring(0, 1) == "E")
				{
					cc = "erinspn@rites.com;ercomplaints@gmail.com;sbu.einsp@rites.com";
				}
				else if (lblCaseNo.Text.Substring(0, 1) == "S")
				{
					cc = "srinspn@rites.com;ravis@rites.com;ravis@rites.com;k.sbu.sinsp@rites.com";
				}

				Conn.Open();
				OracleCommand myCommand = new OracleCommand("select IE_EMAIL from T09_IE where IE_CD= " + lstJIIE.SelectedValue, Conn);
				string JI_IE = Convert.ToString(myCommand.ExecuteScalar());
				Conn.Close();

				if (lblCaseNo.Text.Substring(0, 1) == Session["Region"].ToString())
				{
                    System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
					mail.To = ie_email + ";" + co_email;
					mail.Cc = cc + ";" + JI_IE + ";" + "nrinspn@gmail.com";
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Consignee Complaint Has Concluded";
					mail.BodyFormat = MailFormat.Html;
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = (System.Web.Mail.MailPriority)System.Net.Mail.MailPriority.High;
					SmtpMail.Send(mail);
				}
				else
				{
					if (Session["Region"].ToString() == "N")
					{
						cc = cc + ";nrcomplaints@gmail.com;pklal@rites.com";
					}
					else if (Session["Region"].ToString() == "S")
					{
						cc = cc + ";srinspn@rites.com;ravis@rites.com";
					}
					else if (Session["Region"].ToString() == "W")
					{
						cc = cc + ";wrinspn@rites.com;ravis@rites.com";
					}
					else if (Session["Region"].ToString() == "E")
					{
						cc = cc + ";erinspn@rites.com;ercomplaints@gmail.com";
					}
                    System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
					mail.To = cc + ";" + JI_IE;
					mail.Cc = ie_email + ";" + co_email + ";" + "nrinspn@gmail.com";
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Consignee Complaint Has Concluded";
					mail.BodyFormat = MailFormat.Html;
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = (System.Web.Mail.MailPriority)System.Net.Mail.MailPriority.High;
					SmtpMail.Send(mail);

				}


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Complaint_Case_Detail_Search.aspx");
		}
		void upload_case()
		{
			if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
			{
				string fn = "", MyFile = "", fx = "";
				MyFile = lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim();
				fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				if (fx == "PDF")
				{
					SaveLocation = Server.MapPath("COMPLAINTS_CASES/" + MyFile + ".PDF");
				}
				else
				{
					SaveLocation = Server.MapPath("COMPLAINTS_CASES/" + MyFile + ".TIF");
				}

				File1.PostedFile.SaveAs(SaveLocation);
				DisplayAlert("Case Uploaded!!!");

			}

		}

		void upload_rej_memo()
		{
			if (File3.PostedFile != null && File3.PostedFile.ContentLength > 0)
			{
				string fn = "", MyFile = "", fx = "";
				MyFile = lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim();
				fn = System.IO.Path.GetFileName(File3.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File3.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				if (fx == "PDF")
				{
					SaveLocation = Server.MapPath("REJECTION_MEMO/" + MyFile + ".PDF");
				}
				else
				{
					SaveLocation = Server.MapPath("REJECTION_MEMO/" + MyFile + ".TIF");
				}

				File3.PostedFile.SaveAs(SaveLocation);
				DisplayAlert("Rejection Memo Uploaded!!!");

			}

		}

		void upload_report()
		{
			if (File2.PostedFile != null && File2.PostedFile.ContentLength > 0)
			{
				string fn = "", MyFile = "", fx = "";
				MyFile = lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim();
				fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File2.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				if (fx == "PDF")
				{
					SaveLocation = Server.MapPath("COMPLAINTS_REPORT/" + MyFile + ".PDF");
				}
				else
				{
					SaveLocation = Server.MapPath("COMPLAINTS_REPORT/" + MyFile + ".TIF");
				}

				//SaveLocation = Server.MapPath("COMPLAINTS_REPORT/" + MyFile+".TIF");
				File2.PostedFile.SaveAs(SaveLocation);
				lblJi_Rep_Path.Text = MyFile + "." + fx;
				DisplayAlert("Case Report Uploaded!!!");

			}

		}

		void upload_tech_ref()
		{
			if (File4.PostedFile != null && File4.PostedFile.ContentLength > 0)
			{
				string fn = "", MyFile = "", fx = "";
				MyFile = lblCaseNo.Text.Trim() + "-" + lblBkNo.Text.Trim() + "-" + lblSetNo.Text.Trim();
				fn = System.IO.Path.GetFileName(File4.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File4.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				if (fx == "PDF")
				{
					SaveLocation = Server.MapPath("COMPLAINTS_TECH_REF/" + MyFile + ".PDF");
				}


				//SaveLocation = Server.MapPath("COMPLAINTS_REPORT/" + MyFile+".TIF");
				File4.PostedFile.SaveAs(SaveLocation);
				lblJi_Rep_Path.Text = MyFile + "." + fx;
				DisplayAlert("Case Report Uploaded!!!");

			}

		}
		protected void btnJIChoice_Click(object sender, System.EventArgs e)
		{

			if (lstJIRequired.SelectedValue != "C")
			{
				try
				{
					Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					Conn.Open();
					OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", Conn);
					string wDate = Convert.ToString(MyCmd.ExecuteScalar());
					Conn.Close();
					//
					if ((lstJIRequired.SelectedValue == "Y") & (lstJiRegion.SelectedValue != "") & (lblJiSno.Text.Trim() == ""))
					{
						txtDtJi.Text = wDate;
						txtDtJi.Enabled = false;
						lblJiSno.Text = generate_ji_sno();
						lblJiSrNo.Visible = true;
						lstPoItems.Visible = false;
						btnSave.Enabled = false;
						lstJIRequired.Enabled = false;
						lstJiRegion.Enabled = false;
						btnJIChoice.Visible = false;
						btnCancelJI.Visible = true;
						fill_lstDefectCd();
						fill_lstClassification();
						if (Convert.ToInt16(txtComplaintDt.Text.Substring(6, 4)) >= 2013)
						{
							send_IE_Email();
						}
					}
					//
					string MySql = "";
					if (lstJIRequired.SelectedValue == "Y")
					{
						if (lstClassification.SelectedValue != "")
						{
							MySql = "Update T40_CONSIGNEE_COMPLAINTS " +
								"Set JI_REQUIRED='" + lstJIRequired.SelectedValue + "',JI_REGION='" + lstJiRegion.SelectedValue + "',REMARKS='" + txtRemarks.Text + "',JI_SNO='" + lblJiSno.Text + "',JI_IE_CD='" + lstJIIE.SelectedValue + "',JI_DT=to_date('" + txtDtJi.Text + "','dd/mm/yyyy'),JI_FIX_DT=to_date('" + txtJIFixDT.Text + "','dd/mm/yyyy'),USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
								"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
						}
						else
						{
							MySql = "Update T40_CONSIGNEE_COMPLAINTS " +
								"Set JI_REQUIRED='" + lstJIRequired.SelectedValue + "',JI_REGION='" + lstJiRegion.SelectedValue + "',REMARKS='" + txtRemarks.Text + "',JI_SNO='" + lblJiSno.Text + "',JI_IE_CD='" + lstJIIE.SelectedValue + "',JI_DT=to_date('" + txtDtJi.Text + "','dd/mm/yyyy'),JI_FIX_DT=to_date('" + txtJIFixDT.Text + "','dd/mm/yyyy'),JI_STATUS_CD=0,USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
								"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
						}
					}
					else
					{
						string no_ji_other = "";

						if (lslNOJIReasons.SelectedValue == "K")
						{
							no_ji_other = txtNoJIOthers.Text;
						}
						else
						{
							no_ji_other = "";
						}

						MySql = "Update T40_CONSIGNEE_COMPLAINTS " +
							"Set JI_REQUIRED='" + lstJIRequired.SelectedValue + "',NO_JI_REASON='" + lslNOJIReasons.SelectedValue + "',NO_JI_OTHER='" + no_ji_other + "',JI_REGION='" + lstJiRegion.SelectedValue + "',REMARKS='" + txtRemarks.Text + "',JI_SNO='" + lblJiSno.Text + "',JI_IE_CD='" + lstJIIE.SelectedValue + "',JI_DT=to_date('" + txtDtJi.Text + "','dd/mm/yyyy'),JI_FIX_DT=to_date('" + txtJIFixDT.Text + "','dd/mm/yyyy'),USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
							"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
					}
					//
					Conn.Open();
					OracleCommand cmd = new OracleCommand(MySql, Conn);
					cmd.ExecuteNonQuery();
					DisplayAlert("Data saved");




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
					Conn.Close();
					Conn.Dispose();
				}
			}
			else
			{
				DisplayAlert("Invalid Selection.\\n\\n Valid options are --> [Yes / No] ");

			}
		}

		protected void btnJIOutcome_Click(object sender, System.EventArgs e)
		{
			if ((txtConclusionDt.Text != "" && File2.PostedFile != null && File2.PostedFile.ContentLength > 0))
			{
				try
				{

					Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					Conn.Open();
					OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", Conn);
					string wDate = Convert.ToString(MyCmd.ExecuteScalar());
					//
					//
					string wClassification = "null";
					if (lstClassification.SelectedValue != "") { wClassification = lstClassification.SelectedValue; }
					string MySql = "Update T40_CONSIGNEE_COMPLAINTS " +
						"Set REJECTION_REASON='" + txtRejReason.Text.Trim() + "',JI_DT=to_date('" + txtDtJi.Text + "','dd/mm/yyyy'),DEFECT_CD='" + lstDefectCd.SelectedValue + "',JI_STATUS_CD=" + wClassification + "," +
						"STATUS='" + txtStatus.Text + "',CONCLUSION_DT=to_date('" + txtConclusionDt.Text + "','dd/mm/yyyy'),USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
						"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
					//
					OracleCommand cmd = new OracleCommand(MySql, Conn);
					cmd.ExecuteNonQuery();
					DisplayAlert("Data saved");

					upload_report();
					send_Conclusion_Email();

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
					Conn.Close();
					Conn.Dispose();
				}
			}
			else
			{
				DisplayAlert("Please Enter the Conclusion Date & Select the JI Report to upload!!!");
			}
		}

		protected void btnCancelJI_Click(object sender, System.EventArgs e)
		{
			if (lstJIRequired.SelectedValue != "C")
			{
				if (txtRemarks.Text.Trim() != "")
				{
					try
					{
						Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
						Conn.Open();
						OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", Conn);
						string wDate = Convert.ToString(MyCmd.ExecuteScalar());
						//
						lstJIRequired.SelectedValue = "C";
						string MySql = "Update T40_CONSIGNEE_COMPLAINTS " +
							"Set JI_REQUIRED='" + lstJIRequired.SelectedValue + "',REMARKS='" + txtRemarks.Text + "',USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
							"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
						//
						OracleCommand cmd = new OracleCommand(MySql, Conn);
						cmd.ExecuteNonQuery();
						DisplayAlert("Data saved");
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
						Conn.Close();
						Conn.Dispose();
					}
				}
				else
				{
					DisplayAlert("Record The Reasons For Cancellation of Joint Inspection.");
				}
			}
		}

		private void fill_lstCO()
		{
			Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstCO.Items.Clear();
			DataSet ds = new DataSet();
			OracleCommand cmd = new OracleCommand("Select CO_CD,CO_NAME From T08_IE_CONTROLL_OFFICER Where CO_REGION=substr('" + lblCaseNo.Text + "',1,1) Order By CO_NAME", Conn);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			ListItem lst;
			da.SelectCommand = cmd;
			da.Fill(ds, "Table");
			//
			lst = new ListItem();
			lst.Value = "0";
			lst.Text = " ";
			lstCO.Items.Add(lst);
			//
			for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Value = ds.Tables[0].Rows[i]["CO_CD"].ToString();
				lst.Text = ds.Tables[0].Rows[i]["CO_NAME"].ToString();
				lstCO.Items.Add(lst);
			}
			if (lblCO.Text.Trim() != "") { lstCO.SelectedValue = lblCO.Text; }
		}

		private string generate_complaint_id()
		{
			string wComplaintId = "";
			try
			{
				MyConn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

				OracleCommand cmd = new OracleCommand("GENERATE_COMPLAINT_NO", MyConn);
				cmd.CommandType = CommandType.StoredProcedure;
				MyConn.Open();

				OracleParameter prm1 = new OracleParameter("IN_REGION_CD", OracleDbType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = lblCompRecvRgn.Text;
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_COMPLAINT_DT", OracleDbType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = Convert.ToString(txtComplaintDt.Text);
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("OUT_COMPLAINT_NO", OracleDbType.Char, 12);
				prm3.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32, ParameterDirection.Output);
				prm4.Size = 1;
				
				cmd.Parameters.Add(prm4);

				cmd.ExecuteNonQuery();

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					wComplaintId = "-1";
				}
				else
				{
					wComplaintId = Convert.ToString(cmd.Parameters["OUT_COMPLAINT_NO"].Value);
				}
				MyConn.Close();
				return (wComplaintId);
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
				return ("-1");
			}
			finally
			{
				MyConn.Close();
				MyConn.Dispose();
			}
		}

		private string generate_ji_sno()
		{
			string wJiSno = "";
			try
			{
				MyConn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

				OracleCommand cmd = new OracleCommand("GENERATE_JI_SNO", MyConn);
				cmd.CommandType = CommandType.StoredProcedure;
				MyConn.Open();

				OracleParameter prm1 = new OracleParameter("IN_INSP_REGION", OracleDbType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = lblCaseNo.Text.Substring(0, 1);
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_JI_REGION", OracleDbType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = lstJiRegion.SelectedValue;
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("IN_COMPLAINT_DT", OracleDbType.Char);
				prm3.Direction = ParameterDirection.Input;
				prm3.Value = Convert.ToString(txtDtJi.Text);
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_JI_SNO", OracleDbType.Char, 13);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				OracleParameter prm5 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32, ParameterDirection.Output);
				prm5.Size = 1;
				prm5.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm5);

				cmd.ExecuteNonQuery();

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					wJiSno = "-1";
				}
				else
				{
					wJiSno = Convert.ToString(cmd.Parameters["OUT_JI_SNO"].Value);
				}
				MyConn.Close();
				return (wJiSno);
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
				return ("-1");
			}
			finally
			{
				MyConn.Close();
				MyConn.Dispose();
			}
		}

		private void fill_lstDefectCd()
		{
			MyConn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstDefectCd.Items.Clear();
			DataSet ds = new DataSet();
			OracleCommand cmd = new OracleCommand("Select DEFECT_CD,DEFECT_DESC From T38_DEFECT_CODES", MyConn);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			ListItem lst;
			//
			lst = new ListItem();
			lst.Value = null;
			lst.Text = null;
			lstDefectCd.Items.Add(lst);
			//
			da.SelectCommand = cmd;
			da.Fill(ds, "Table");
			for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Value = ds.Tables[0].Rows[i]["DEFECT_CD"].ToString();
				lst.Text = ds.Tables[0].Rows[i]["DEFECT_DESC"].ToString();
				lstDefectCd.Items.Add(lst);
			}
			MyConn.Close();
			MyConn.Dispose();
			lstDefectCd.SelectedValue = lblDefectCD.Text;
		}
		private void fill_JIIE_Cd()
		{
			MyConn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstJIIE.Items.Clear();
			DataSet ds = new DataSet();
			OracleCommand cmd = new OracleCommand("Select IE_CD,IE_NAME From T09_IE where IE_REGION='" + lstJiRegion.SelectedValue + "' order by IE_NAME", MyConn);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			ListItem lst;
			//
			lst = new ListItem();
			lst.Value = null;
			lst.Text = null;
			lstJIIE.Items.Add(lst);
			//
			da.SelectCommand = cmd;
			da.Fill(ds, "Table");
			for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Value = ds.Tables[0].Rows[i]["IE_CD"].ToString();
				lst.Text = ds.Tables[0].Rows[i]["IE_NAME"].ToString();
				lstJIIE.Items.Add(lst);
			}
			MyConn.Close();
			MyConn.Dispose();

		}
		private void fill_lstClassification()
		{
			MyConn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstClassification.Items.Clear();
			DataSet ds = new DataSet();
			OracleCommand cmd = new OracleCommand("Select JI_STATUS_CD,JI_STATUS_DESC From T39_JI_STATUS_CODES", MyConn);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			ListItem lst;
			//
			lst = new ListItem();
			lst.Value = null;
			lst.Text = null;
			lstClassification.Items.Add(lst);
			//
			da.SelectCommand = cmd;
			da.Fill(ds, "Table");
			for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Value = ds.Tables[0].Rows[i]["JI_STATUS_CD"].ToString();
				lst.Text = ds.Tables[0].Rows[i]["JI_STATUS_DESC"].ToString();
				lstClassification.Items.Add(lst);
			}
			MyConn.Close();
			MyConn.Dispose();
			if ((Convert.ToString(Request.Params["COMPLAINT_ID"]) == "" || Convert.ToString(Request.Params["COMPLAINT_ID"]) == null) && lblClassification.Text == "")
			{
				lstClassification.SelectedValue = "0";

			}
			else
			{
				lstClassification.SelectedValue = lblClassification.Text;
			}
		}

		private void fill_lstPoItems()
		{
			MyConn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstPoItems.Items.Clear();
			DataSet ds = new DataSet();
			string MySql = "Select t18.ITEM_SRNO_PO,t18.ITEM_DESC_PO From T18_CALL_DETAILS t18,T20_IC t20 " +
						 "Where t18.CASE_NO=t20.CASE_NO and t18.CALL_RECV_DT=t20.CALL_RECV_DT and t18.CALL_SNO=t20.CALL_SNO and t18.CONSIGNEE_CD=t20.CONSIGNEE_CD and " +
						 "t20.CASE_NO='" + lblCaseNo.Text + "' and t20.BK_NO='" + lblBkNo.Text + "' and t20.SET_NO='" + lblSetNo.Text + "'";
			OracleCommand cmd = new OracleCommand(MySql, MyConn);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			ListItem lst;
			//
			lst = new ListItem();
			lst.Value = null;
			lst.Text = null;
			lstPoItems.Items.Add(lst);
			//
			da.SelectCommand = cmd;
			da.Fill(ds, "Table");
			for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Value = ds.Tables[0].Rows[i]["ITEM_SRNO_PO"].ToString();
				lst.Text = ds.Tables[0].Rows[i]["ITEM_DESC_PO"].ToString();
				lstPoItems.Items.Add(lst);
			}
			MyConn.Close();
			MyConn.Dispose();
			lstPoItems.SelectedValue = lblItemSrnoPo.Text;
		}

		protected void lstPoItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblItemDesc.Text = lstPoItems.SelectedItem.Text;
			lblItemSrnoPo.Text = lstPoItems.SelectedValue;
			try
			{
				string MySql = "Select t15.UOM_CD,round(t15.VALUE/t15.QTY,4)RATE,t04.UOM_S_DESC From T15_PO_DETAIL t15,T04_UOM t04 Where t15.UOM_CD=t04.UOM_CD and t15.CASE_NO='" + lblCaseNo.Text + "' and t15.ITEM_SRNO=" + lblItemSrnoPo.Text;
				MyConn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				MyConn.Open();
				OracleCommand cmd = new OracleCommand(MySql, MyConn);
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					lblUOM.Text = MyReader["UOM_CD"].ToString();
					lblUOMDesc.Text = MyReader["UOM_S_DESC"].ToString();
					lblRate.Text = MyReader["RATE"].ToString();
					lblUomRate.Text = " per " + lblUOMDesc.Text;
				}
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
				MyConn.Close();
				MyConn.Dispose();
			}
			rbs.SetFocus(txtQtyOffered);
		}
		protected void txtQtyRej_TextChanged(object sender, System.EventArgs e)
		{
			txtValueRej.Text = Convert.ToString((Convert.ToDecimal(lblRate.Text) * Convert.ToDecimal(txtQtyRej.Text)));
			rbs.SetFocus(txtRejReason);
		}

		protected void btnFinalDisposal_Click(object sender, System.EventArgs e)
		{
			try
			{
				Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				Conn.Open();
				OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", Conn);
				string wDate = Convert.ToString(MyCmd.ExecuteScalar());
				//
				//


				string MySql = "";
				if (lstAction.SelectedValue == "I" || lstAction.SelectedValue == "J")
				{
					MySql = "Update T40_CONSIGNEE_COMPLAINTS " +
						"Set ROOT_CAUSE_ANALYSIS='" + txtRootCAnalysis.Text + "', TECH_REF='" + txtTech_Ref.Text + "', CHKSHEET_STATUS='" + ddlChksheet.SelectedValue + "',ANY_OTHER='" + txtAnyOther.Text + "',CAPA_STATUS='" + txtCAPA.Text + "',DANDAR_STATUS='" + txtDARStatus.Text + "', ACTION_PROPOSED='" + lstAction.SelectedValue + "',ACTION_PROPOSED_DT=to_date('" + txtDtIssue.Text + "','dd/mm/yyyy'),PENALTY_TYPE='" + lstPenaltyType.SelectedValue + "',PENALTY_DT=to_date('" + txtPenaltyDt.Text + "','dd/mm/yyyy'),ACTION='" + txtAction.Text + "'," +
						"USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
						"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";
				}
				else
				{
					MySql = "Update T40_CONSIGNEE_COMPLAINTS " +
						"Set ROOT_CAUSE_ANALYSIS='" + txtRootCAnalysis.Text + "', TECH_REF='" + txtTech_Ref.Text + "', CHKSHEET_STATUS='" + ddlChksheet.SelectedValue + "',ANY_OTHER='" + txtAnyOther.Text + "',CAPA_STATUS='" + txtCAPA.Text + "',DANDAR_STATUS='" + txtDARStatus.Text + "', ACTION_PROPOSED='" + lstAction.SelectedValue + "',ACTION_PROPOSED_DT=to_date('" + txtDtIssue.Text + "','dd/mm/yyyy'),ACTION='" + txtAction.Text + "',USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS') " +
						"Where COMPLAINT_ID='" + lblComplaintId.Text + "'";

				}
				//
				OracleCommand cmd = new OracleCommand(MySql, Conn);
				cmd.ExecuteNonQuery();
				DisplayAlert("Data saved");
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
				Conn.Close();
				Conn.Dispose();
			}

			upload_tech_ref();
		}
		void fill_penalty()
		{
			ListItem lst1 = new ListItem();
			if (lstAction.SelectedValue == "I")
			{
				lstPenaltyType.Items.Clear();
				lst1.Text = "Censure";
				lst1.Value = "IC";
				lstPenaltyType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Withholding of Increment of pay";
				lst1.Value = "II";
				lstPenaltyType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Withholding of promotion";
				lst1.Value = "IP";
				lstPenaltyType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Recovery from pay";
				lst1.Value = "IR";
				lstPenaltyType.Items.Add(lst1);
				lstPenaltyType.Items.Insert(0, "");

				Label31.Visible = true;
				lstPenaltyType.Visible = true;
				txtPenaltyDt.Visible = true;
			}
			else if (lstAction.SelectedValue == "J")
			{
				lstPenaltyType.Items.Clear();
				lst1.Text = "Reduction to a lower grade or post";
				lst1.Value = "JL";
				lstPenaltyType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Removal from service";
				lst1.Value = "JR";
				lstPenaltyType.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "Dismissal";
				lst1.Value = "JD";
				lstPenaltyType.Items.Add(lst1);
				lstPenaltyType.Items.Insert(0, "");

				Label31.Visible = true;
				lstPenaltyType.Visible = true;
				txtPenaltyDt.Visible = true;
			}
			else
			{
				Label31.Visible = false;
				lstPenaltyType.Visible = false;
				txtPenaltyDt.Visible = false;

			}

		}
		protected void lstAction_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_penalty();

		}

		protected void lstJiRegion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstJiRegion.SelectedValue == Session["Region"].ToString())
			{
				fill_JIIE_Cd();
				btnJIChoice.Enabled = true;
				btnCancelJI.Enabled = true;
				btnJIOutcome.Enabled = true;
				btnFinalDisposal.Enabled = true;
			}
			else
			{
				lstJIIE.Items.Clear();
				btnJIChoice.Enabled = false;
				btnCancelJI.Enabled = false;
				btnJIOutcome.Enabled = false;
				btnFinalDisposal.Enabled = false;
			}
		}

		protected void btnUploadCase_Click(object sender, System.EventArgs e)
		{
			upload_case();
		}

		protected void lstJIRequired_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstJIRequired.SelectedValue == "N")
			{
				Label39.Visible = true;
				lslNOJIReasons.Visible = true;
				Label3.Visible = false;
				lstJiRegion.Visible = false;
				Label32.Visible = false;
				lstJIIE.Visible = false;
				Label29.Visible = false;
				txtJIFixDT.Visible = false;
				Label24.Visible = false;
				Label33.Visible = false;
				txtRemarks.Visible = false;
				lblJiSrNo.Visible = false;
				lblJiSno.Visible = false;
				Label39.Visible = true;
				lslNOJIReasons.Visible = true;


			}
			else if (lstJIRequired.SelectedValue == "Y")
			{
				Label39.Visible = false;
				lslNOJIReasons.Visible = false;
				Label24.Visible = false;
				Label33.Visible = false;
				txtRemarks.Visible = false;
				Label3.Visible = true;
				lstJiRegion.Visible = true;
				Label32.Visible = true;
				lstJIIE.Visible = true;
				Label29.Visible = true;
				txtJIFixDT.Visible = true;
				Label39.Visible = false;
				lslNOJIReasons.Visible = false;


			}
			else if (lstJIRequired.SelectedValue == "C")
			{
				Label9.Visible = false;
				lslNOJIReasons.Visible = false;
				Label14.Visible = false;
				lstJiRegion.Visible = false;
				Label32.Visible = false;
				lstJIIE.Visible = false;
				Label29.Visible = false;
				txtJIFixDT.Visible = false;
				Label24.Visible = true;
				Label33.Visible = true;
				txtRemarks.Visible = true;
				Label3.Visible = true;
				lstJiRegion.Visible = true;
				Label39.Visible = false;
				lslNOJIReasons.Visible = false;
			}
		}

		protected void btnRejMemo_Click(object sender, System.EventArgs e)
		{
			upload_rej_memo();
		}

		protected void lslNOJIReasons_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lslNOJIReasons.SelectedValue == "K")
			{
				txtNoJIOthers.Visible = true;
				Label53.Visible = true;
			}
			else
			{
				txtNoJIOthers.Visible = false;
				Label53.Visible = false;
			}
		}
	}
}