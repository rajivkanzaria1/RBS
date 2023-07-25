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
    public partial class Call_Register_Edit : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		//	string CNO,DT;
		protected System.Web.UI.WebControls.Button btnSearch1;
		string CNO, DT, CSNO;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnAdd.Attributes.Add("OnClick", "JavaScript:validate3();");
			btnMod.Attributes.Add("OnClick", "JavaScript:validate();");
			btnCallStatus.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnCCancellation.Attributes.Add("OnClick", "JavaScript:validate();");

			if (!(IsPostBack))
			{
				if (Convert.ToString(Request.Params["CASE_NO"]) == null || Convert.ToString(Request.Params["CALL_RECV_DT"]) == null)
				{
					CNO = "";
					DT = "";

				}
				else
				{
					CNO = Convert.ToString(Request.Params["CASE_NO"].Trim());
					DT = Convert.ToString(Request.Params["CALL_RECV_DT"].Trim());
					CSNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
					txtCaseNo.Text = CNO;
					txtDtOfReciept.Text = DT;
					txtCSNO.Text = CSNO;
				}

				if (Session["Role_CD"].ToString() == "1")
				{
					btnCallStatus.Visible = true;
				}
				else if (Session["Role_CD"].ToString() == "4")
				{
					btnAdd.Visible = false;
					btnCallStatus.Visible = false;
					btnMod.Text = "View Call";
					btnDelete.Visible = false;
					btnCCancellation.Visible = false;
				}
				else
				{
					btnCallStatus.Visible = false;
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

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			OracleDataReader or1;
			conn1.Open();
			OracleCommand cmd = new OracleCommand("Select T13.INSPECTING_AGENCY,T13.REMARKS,T13.RLY_NONRLY,T05.VEND_CD,T05.VEND_INSP_STOPPED, T05.VEND_REMARKS from T13_PO_MASTER T13, T05_VENDOR T05 where T13.VEND_CD=T05.VEND_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "'", conn1);
			or1 = cmd.ExecuteReader();
			string w_inspby = "";
			string w_insp_remarks = "";
			string w_itemBlocked = "";
			string w_remarksVend = "";
			string bpotype = "";
			while (or1.Read())
			{
				w_inspby = or1["INSPECTING_AGENCY"].ToString();
				w_insp_remarks = or1["REMARKS"].ToString();
				w_itemBlocked = or1["VEND_INSP_STOPPED"].ToString();
				w_remarksVend = or1["VEND_REMARKS"].ToString();
				bpotype = or1["RLY_NONRLY"].ToString();
			}
			conn1.Close();

			if (w_inspby == "R")
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("SELECT sign(sysdate - TO_DATE('" + txtDtOfReciept.Text.Trim() + "','DD/MM/YYYY')) FROM dual", conn1);
				int ss = Convert.ToInt32(cmd2.ExecuteScalar());
				conn1.Close();
				if (ss == 1)
				{
					string check = match1();
					if (check == "2")
					{
						string code = txtCaseNo.Text.Trim();
						string dt = txtDtOfReciept.Text.Trim();
						if (w_itemBlocked == "Y")
						{
							string msg = "Some Items of the Vendor have been blocked due to following reasons :\\n" + w_remarksVend + "\\nDo You Still Want to Register/Update This Call?";
							Response.Write("<script language=JavaScript> var d=confirm('" + msg + "'); if(d==false) location.href='/RBS/Call_Register_Edit.aspx'; else location.href='Call_Register_Form.aspx?Action=A&Case_No=" + code + "&DT_RECIEPT=" + dt + "'</script>");
						}
						else
						{
							if (bpotype == "R" || bpotype == "U")
							{
								int dp = show2(txtCaseNo.Text.Trim());
								if (dp == 0)
								{
									DisplayAlert("Please ensure Inspection Call is submitted at least five(5) working days before the expiry of the delivery period , otherwise Call shall not be accepted.");
								}
								else if (dp == 2)
								{
									DisplayAlert("Delivery Period not available, so Call shall not be accepted.");
								}
								else
								{
									Response.Redirect("Call_Register_Form.aspx?Action=A&Case_No=" + code + "&DT_RECIEPT=" + dt);
								}
							}
							else
							{
								Response.Redirect("Call_Register_Form.aspx?Action=A&Case_No=" + code + "&DT_RECIEPT=" + dt);
							}


						}
					}
					else if (check == "0")
					{
						DisplayAlert("No Record Present for the Given Case No.!!! ");
					}
					else
					{
						DisplayAlert("You are not Authorised to Add The Call For Other Regions.!!! ");
					}
				}
				else
				{
					DisplayAlert("The Call Date Cannot be greater then Current Date.");
				}
			}
			else
			{
				if (w_inspby == "C")
				{
					if (w_insp_remarks == "")
					{
						DisplayAlert("RITES is not the Inspection Agency for this CASE.");
					}
					else
					{
						DisplayAlert("RITES is not the Inspection Agency for this CASE. Kindly see the comments below : " + "\\n" + w_insp_remarks.Trim());
					}
				}
				else if (w_inspby == "X")
				{
					if (w_insp_remarks == "")
					{
						DisplayAlert("Railways has cancelled the PO for this CASE.");
					}
					else
					{
						DisplayAlert("Railways has cancelled the PO for this CASE. Kindly see the comments below : " + "\\n" + w_insp_remarks.Trim());
					}
				}
				else if (w_inspby == "S")
				{
					if (w_insp_remarks == "")
					{
						DisplayAlert("RITES has Suspended the Inspection against this PO.");
					}
					else
					{
						DisplayAlert("RITES has Suspended the Inspection against this PO. Kindly see the comments below : " + "\\n" + w_insp_remarks.Trim());
					}
				}
			}

		}

		int show2(string CNO)
		{
			conn1.Open();
			OracleCommand cmd22 = new OracleCommand("Select NVL(to_char(max(EXT_DELV_DT),'dd/mm/yyyy'),'01-JAN-01') EXT_DELV_DT from T15_PO_DETAIL where CASE_NO='" + CNO + "'", conn1);
			OracleDataReader or2 = cmd22.ExecuteReader();
			string ext_delv_dt = "";
			while (or2.Read())
			{

				ext_delv_dt = or2["EXT_DELV_DT"].ToString();
			}
			conn1.Close();
			if (ext_delv_dt == "01-JAN-01")
			{
				return (2);
			}
			else
			{
				System.DateTime w_dt1 = new System.DateTime(Convert.ToInt32(ext_delv_dt.Substring(6, 4)), Convert.ToInt32(ext_delv_dt.Substring(3, 2)), Convert.ToInt32(ext_delv_dt.Substring(0, 2)));
				System.DateTime w_dt2 = new System.DateTime(Convert.ToInt32(txtDtOfReciept.Text.Substring(6, 4)), Convert.ToInt32(txtDtOfReciept.Text.Substring(3, 2)), Convert.ToInt32(txtDtOfReciept.Text.Substring(0, 2)));
				TimeSpan ts = w_dt1 - w_dt2;
				int differenceInDays = ts.Days;
				if (differenceInDays < 5)
				{
					return (0);
				}
				else
				{
					return (1);
				}
			}

		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			OracleDataReader or1;
			conn1.Open();
			OracleCommand cmd = new OracleCommand("Select T05.VEND_CD,T05.VEND_INSP_STOPPED, T05.VEND_REMARKS from T13_PO_MASTER T13, T05_VENDOR T05 where T13.VEND_CD=T05.VEND_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "'", conn1);
			or1 = cmd.ExecuteReader();

			string w_itemBlocked = "";
			string w_remarksVend = "";
			while (or1.Read())
			{
				w_itemBlocked = or1["VEND_INSP_STOPPED"].ToString();
				w_remarksVend = or1["VEND_REMARKS"].ToString();
			}
			conn1.Close();
			string check = match();
			if (check == "2")
			{
				string code = txtCaseNo.Text.Trim();
				string dt = txtDtOfReciept.Text.Trim();
				string csno = txtCSNO.Text.Trim();
				if (w_itemBlocked == "Y")
				{
					string msg = "Some Items of the Vendor have been blocked due to following reasons :\\n" + w_remarksVend + "\\nDo You Still Want to Register/Update This Call?";
					Response.Write("<script language=JavaScript> var d=confirm('" + msg + "'); if(d==false) location.href='/RBS/Call_Register_Edit.aspx'; else location.href='Call_Register_Form.aspx?Action=M&Case_No=" + code + "&DT_RECIEPT=" + dt + "&CALL_SNO=" + csno + "'</script>");
				}
				else
				{
					Response.Redirect("Call_Register_Form.aspx?Action=M&Case_No=" + code + "&DT_RECIEPT=" + dt + "&CALL_SNO=" + csno);
				}
			}
			//			else
			//			{
			//				DisplayAlert("No Record Present for the Given Case No, Call Date and Call SNo!!! ");
			//			}
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			string check = match();
			if (check == "2")
			{
				string code = txtCaseNo.Text.Trim();
				string dt = txtDtOfReciept.Text.Trim();
				string csno = txtCSNO.Text.Trim();
				Response.Redirect("Call_Register_Form.aspx?Action=D&Case_No=" + code + "&DT_RECIEPT=" + dt + "&CALL_SNO=" + csno);
			}
			//			else
			//			{
			//				DisplayAlert("No Record Present for the Given Case No, Call Date and Call SNo!!! ");
			//			}

		}

		protected void btnCCancellation_Click(object sender, System.EventArgs e)
		{
			string check = match();
			OracleCommand cmd = new OracleCommand("select CASE_NO from T19_CALL_CANCEL where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + txtCSNO.Text.Trim(), conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			if (check == "2")
			{
				string code = txtCaseNo.Text.Trim();
				string dt = txtDtOfReciept.Text.Trim();
				string csno = txtCSNO.Text.Trim();
				if (test == "")
				{
					Response.Redirect("Call_Cancellation_Form.aspx?Action=A&Case_No=" + code + "&DT_RECIEPT=" + dt + "&CALL_SNO=" + csno);
				}
				else
				{
					Response.Redirect("Call_Cancellation_Form.aspx?Action=M&Case_No=" + code + "&DT_RECIEPT=" + dt + "&CALL_SNO=" + csno);
				}

			}
			//			else
			//			{
			//				DisplayAlert("No Record Present for the Given Case No, Call Date and Call SNo!!! ");
			//			}

		}

		public string match()
		{
			OracleCommand cmd = new OracleCommand("select REGION_CODE from T17_CALL_REGISTER where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + txtCSNO.Text.Trim(), conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			if (test == "\0" || test == "")
			{
				test = "0";
				DisplayAlert("No Record Present for the Given Case No, Call Date and Call SNo!!! ");
			}
			else if (test == Session["Region"].ToString())
			{
				test = "2";

			}
			else
			{
				test = "1";
				DisplayAlert("You are not Authorised to Update/Delete/Cancel The Call For Other Regions.!!! ");
			}
			return test;

		}

		public string match1()
		{
			OracleCommand cmd = new OracleCommand("select REGION_CODE from T13_PO_MASTER where CASE_NO='" + txtCaseNo.Text.Trim() + "'", conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			if (test == "\0" || test == "")
			{
				test = "0";
			}
			else if (test == Session["Region"].ToString())
			{
				test = "2";
			}
			else
			{
				test = "1";
			}
			return test;
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void txtSearch_Click(object sender, System.EventArgs e)
		{
			//			string str1 = "select P.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,C.CALL_INSTALL_NO,C.CALL_SNO,decode(C.CALL_STATUS,'M','Pending','A','Accepted','R','Rejection','C','Cancelled'||decode(C.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)',''),'U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection')CALL_STATUS,C.CALL_LETTER_NO,C.REMARKS,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT,I.IE_SNAME,(V.VEND_NAME||'('||NVL2(T.LOCATION,T.LOCATION||' : '||T.CITY,T.CITY)||')')VENDOR from T17_CALL_REGISTER C, T13_PO_MASTER P,T09_IE I, T05_VENDOR V,T03_CITY T where P.CASE_NO=C.CASE_NO(+) and C.IE_CD=I.IE_CD(+) and P.VEND_CD=V.VEND_CD and V.VEND_CITY_CD=T.CITY_CD and P.REGION_CODE='"+Session["Region"].ToString()+"'"; 
			string str1 = "select P.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,C.CALL_INSTALL_NO,C.CALL_SNO,decode(S.CALL_STATUS_CD,'C',S.CALL_STATUS_DESC||decode(C.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)'||'@'||C.CALL_CANCEL_CHARGES||'+ S.T.',''),'R',NVL2(C.REJ_CHARGES,S.CALL_STATUS_DESC||'@'||REJ_CHARGES||'+ GST',S.CALL_STATUS_DESC),S.CALL_STATUS_DESC)CALL_STATUS,C.CALL_LETTER_NO,C.REMARKS,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT,I.IE_SNAME,(V.VEND_NAME||'('||NVL2(T.LOCATION,T.LOCATION||' : '||T.CITY,T.CITY)||')')VENDOR from T17_CALL_REGISTER C, T13_PO_MASTER P,T09_IE I, T05_VENDOR V,T03_CITY T,T21_CALL_STATUS_CODES S where P.CASE_NO=C.CASE_NO(+) and C.IE_CD=I.IE_CD(+) and P.VEND_CD=V.VEND_CD and V.VEND_CITY_CD=T.CITY_CD and C.CALL_STATUS=S.CALL_STATUS_CD(+) and P.REGION_CODE='" + Session["Region"].ToString() + "'";
			if (txtCaseNo.Text.Trim() != "")
			{
				str1 = str1 + " and P.CASE_NO='" + txtCaseNo.Text.Trim() + "'";
			}
			if (txtDtOfReciept.Text.Trim() != "")
			{

				str1 = str1 + " and C.CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')";
			}

			if (txtPONO.Text.Trim() != "")
			{
				str1 = str1 + " and upper(P.PO_NO) LIKE upper('%" + txtPONO.Text.Trim() + "%')";
			}

			if (txtPODT.Text.Trim() != "")
			{
				str1 = str1 + " and PO_DT=to_date('" + txtPODT.Text.Trim() + "','dd/mm/yyyy')";
			}
			if (txtVendName.Text != "")
			{
				str1 = str1 + " and UPPER(TRIM(V.VEND_NAME)) like UPPER('" + txtVendName.Text.Trim() + "%')";
			}
			if (txtCallLetNo.Text != "")
			{
				str1 = str1 + " and UPPER(TRIM(C.CALL_LETTER_NO)) like UPPER('" + txtCallLetNo.Text.Trim() + "')";
			}
			if (txtDtOfReciept.Text.Trim() != "" && txtPONO.Text.Trim() == "" && txtPODT.Text.Trim() == "" && txtCaseNo.Text.Trim() == "")
			{
				str1 = str1 + " order by C.CALL_RECV_DT,C.CALL_SNO";
			}
			else
			{
				str1 = str1 + " order by P.CASE_NO,C.CALL_RECV_DT";
			}
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				grdCNO.Visible = false;
				//Label4.Visible=true;
				DisplayAlert("Case Not Registered!!!");
			}
			else
			{
				grdCNO.DataSource = dsP;
				//int rr=Convert.ToInt32(dsP.Tables[0].Rows.Count)*30 + 50 ;
				//grdCNO.Height=rr;
				grdCNO.DataBind();
				grdCNO.Visible = true;
				Label4.Visible = false;
			}
		}

		private void btnSearch1_Click(object sender, System.EventArgs e)
		{
			string str1 = "select P.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT from T17_CALL_REGISTER C, T13_PO_MASTER P where P.CASE_NO=C.CASE_NO(+) ";
			if (txtPONO.Text.Trim() != "")
			{
				str1 = str1 + " and upper(P.PO_NO) LIKE upper('%" + txtPONO.Text.Trim() + "%')";
			}

			if (txtPODT.Text.Trim() != "")
			{
				str1 = str1 + " and PO_DT=to_date('" + txtPODT.Text.Trim() + "','dd/mm/yyyy')";
			}


			str1 = str1 + " order by CALL_RECV_DT,P.CASE_NO";
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				grdCNO.Visible = false;
				Label4.Visible = true;
			}
			else
			{
				grdCNO.DataSource = dsP;
				//int rr=Convert.ToInt32(dsP.Tables[0].Rows.Count)*30 + 50 ;
				//grdCNO.Height=rr;
				grdCNO.DataBind();
				grdCNO.Visible = true;
				Label4.Visible = false;
			}
		}

		private void btnIns_Click(object sender, System.EventArgs e)
		{
			string code = txtCaseNo.Text.Trim();
			string dt = txtDtOfReciept.Text.Trim();
			Response.Redirect("Inspection_Certificate_Form.aspx?Action=A&Case_No=" + code + "&CALL_RECV_DT=" + dt);
		}

		private void grdCNO_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		protected void btnCallStatus_Click(object sender, System.EventArgs e)
		{
			string check = match();

			if (check == "2")
			{
				string code = txtCaseNo.Text.Trim();
				string dt = txtDtOfReciept.Text.Trim();
				string csno = txtCSNO.Text.Trim();
				Response.Redirect("Call_Status_Edit_Form_Admin.aspx?CASE_NO=" + code + "&CALL_RECV_DT=" + dt + "&CALL_SNO=" + csno);

			}
		}



	}
}