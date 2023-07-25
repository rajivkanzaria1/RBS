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
    public partial class Vendor_Call_Register_Edit : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		DataSet dsP = new DataSet();
		//	string CNO,DT;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected Tittle.Controls.CustomDataGrid grdCNO;
		protected System.Web.UI.WebControls.TextBox txtCaseNo;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Button btnSearch1;
		string CNO, DT, CSNO;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtPONO;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblCDateMess;
		protected System.Web.UI.WebControls.Label lblCSNO;
		protected System.Web.UI.WebControls.TextBox txtCSNO;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label lblDtOfReciept;
		protected System.Web.UI.WebControls.TextBox txtDtOfReciept;
		protected System.Web.UI.WebControls.Label Label51;
		protected System.Web.UI.WebControls.RadioButton rdbStage;
		protected System.Web.UI.WebControls.RadioButton rdbFinal;
		protected System.Web.UI.WebControls.Label Label52;
		protected System.Web.UI.WebControls.Label Label8;

		private void Page_Load(object sender, System.EventArgs e)
		{
			btnAdd.Attributes.Add("OnClick", "JavaScript:validate3();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate1();");


			if (!(IsPostBack))
			{
				conn1.Open();
				OracleCommand cmd = new OracleCommand("SELECT to_char(sysdate,'DD/MM/YYYY') CDATE, to_char(sysdate,'D') CDAY, to_char(sysdate,'HH24MI')CTYM FROM dual", conn1);
				string ss = "";
				int W_Cday = 0;
				int W_cTym = 0;
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					ss = reader["CDATE"].ToString();
					W_Cday = Convert.ToInt16(reader["CDAY"].ToString());
					W_cTym = Convert.ToInt16(reader["CTYM"].ToString());

				}
				conn1.Close();

				if (W_Cday == 1)
				{
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("select to_char(sysdate+1,'DD/MM/YYYY') from dual", conn1);
					ss = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();
					lblCDateMess.Text = "* Calls submitted on Sunday will be registered on Monday.";
				}
				// As Per Instructions of GGM(I) Dated: 29-08-2012, Calls Registered till Saturday 3:00 PM will be registered on same Date.
				//				else  if(W_Cday==7)
				//				{
				//					conn1.Open();
				//					OracleCommand cmd2 =new OracleCommand("select to_char(sysdate+2,'DD/MM/YYYY') from dual",conn1);
				//					ss=Convert.ToString(cmd2.ExecuteScalar());
				//					conn1.Close();
				//					lblCDateMess.Text="* Calls submitted after 1500 HRS on Friday till Sunday will be registered on Monday.";
				//				}
				//				else if(W_Cday==7 && W_cTym>1500)
				//				{
				//					conn1.Open();
				//					OracleCommand cmd2 =new OracleCommand("select to_char(sysdate+2,'DD/MM/YYYY') from dual",conn1);
				//					ss=Convert.ToString(cmd2.ExecuteScalar());
				//					conn1.Close();
				//					lblCDateMess.Text="* Calls submitted after 1500 HRS on Saturday till Sunday will be registered on Monday.";
				//				}
				//				else if(W_Cday>1 && W_Cday<7 && W_cTym>1500)
				//				{
				//					conn1.Open();
				//					OracleCommand cmd2 =new OracleCommand("select to_char(sysdate+1,'DD/MM/YYYY') from dual",conn1);
				//					ss=Convert.ToString(cmd2.ExecuteScalar());
				//					conn1.Close();
				//					lblCDateMess.Text="* Calls submitted after 1500 HRS will be registered on next working day.";
				//				}

				// As Per Instructions of GGM(I) Dated: 28-05-2012

				//				conn1.Open();
				//				OracleCommand cmd =new OracleCommand("SELECT to_char(sysdate,'DD/MM/YYYY') FROM dual",conn1);
				//				string ss=Convert.ToString(cmd.ExecuteScalar());
				//				conn1.Close();
				if (Convert.ToString(Request.Params["CASE_NO"]) == null || Convert.ToString(Request.Params["CALL_RECV_DT"]) == null)
				{
					CNO = "";
					DT = "";
					if (ss == "26/01/2023")
					{
						txtDtOfReciept.Text = "27/01/2023";
						lblDtOfReciept.Text = "27/01/2023";
					}
					else if (ss == "15/08/2023")
					{
						txtDtOfReciept.Text = "16/08/2023";
						lblDtOfReciept.Text = "16/08/2023";
					}
					else if (ss == "02/10/2023")
					{
						txtDtOfReciept.Text = "03/10/2023";
						lblDtOfReciept.Text = "03/10/2023";
					}
					//					else if(ss=="29/03/2018")				AS DESIRED BY GGM/I/NR
					//					{
					//						txtDtOfReciept.Text="31/03/2018";	
					//						lblDtOfReciept.Text="31/03/2018";
					//					}
					//					else if(ss=="30/03/2018")				AS DESIRED BY GGM/I/NR
					//					{
					//						txtDtOfReciept.Text="31/03/2018";
					//						lblDtOfReciept.Text="31/03/2018";
					//					}
					//					else if(ss=="30/04/2018")
					//					{
					//						txtDtOfReciept.Text="01/05/2018";
					//						lblDtOfReciept.Text="01/05/2018";
					//					}
					//					else if(ss=="16/06/2018")
					//					{
					//						txtDtOfReciept.Text="18/06/2018";
					//						lblDtOfReciept.Text="18/06/2018";
					//					}
					//					else if(ss=="15/08/2018")
					//					{
					//						txtDtOfReciept.Text="16/08/2018";
					//						lblDtOfReciept.Text="16/08/2018";
					//					}
					//					else if(ss=="22/08/2018")
					//					{
					//						txtDtOfReciept.Text="23/08/2018";
					//						lblDtOfReciept.Text="23/08/2018";
					//					}
					//					else if(ss=="03/09/2018")
					//					{
					//						txtDtOfReciept.Text="04/09/2018";
					//						lblDtOfReciept.Text="04/09/2018";
					//					}
					//					else if(ss=="21/09/2018")
					//					{
					//						txtDtOfReciept.Text="22/09/2018";
					//						lblDtOfReciept.Text="22/09/2018";
					//					}
					//					else if(ss=="02/10/2018")
					//					{
					//						txtDtOfReciept.Text="03/10/2018";
					//						lblDtOfReciept.Text="03/10/2018";
					//					}
					//					else if(ss=="19/10/2018")
					//					{
					//						txtDtOfReciept.Text="20/10/2018";
					//						lblDtOfReciept.Text="20/10/2018";
					//					}
					//					else if(ss=="07/11/2018")
					//					{
					//						txtDtOfReciept.Text="08/11/2018";
					//						lblDtOfReciept.Text="08/11/2018";
					//					}
					//					else if(ss=="21/11/2018")
					//					{
					//						txtDtOfReciept.Text="22/11/2018";
					//						lblDtOfReciept.Text="22/11/2018";
					//					}
					//					else if(ss=="23/11/2018")
					//					{
					//						txtDtOfReciept.Text="24/11/2018";
					//						lblDtOfReciept.Text="24/11/2018";
					//					}
					//					else if(ss=="25/12/2018")
					//					{
					//						txtDtOfReciept.Text="26/12/2018";
					//						lblDtOfReciept.Text="26/12/2018";
					//					}
					else
					{
						txtDtOfReciept.Text = ss;
						lblDtOfReciept.Text = ss;
					}


				}
				else
				{
					CNO = Convert.ToString(Request.Params["CASE_NO"].Trim());
					DT = Convert.ToString(Request.Params["CALL_RECV_DT"].Trim());
					CSNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
					txtCaseNo.Text = CNO;
					txtDtOfReciept.Text = DT;
					lblDtOfReciept.Text = DT;
					txtCSNO.Text = CSNO;
					lblCSNO.Text = CSNO;
					Label9.Visible = true;
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
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnSearch.Click += new System.EventHandler(this.txtSearch_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			OracleDataReader or1;
			string bpotype = "";
			int w_pending = 0;
			conn1.Open();
			OracleCommand cmd = new OracleCommand("Select RLY_NONRLY,INSPECTING_AGENCY,REMARKS, PO_OR_LETTER,NVL(PENDING_CHARGES,0) PENDING from T13_PO_MASTER where CASE_NO='" + txtCaseNo.Text.Trim() + "'", conn1);
			or1 = cmd.ExecuteReader();
			string w_inspby = "";
			string w_insp_remarks = "";
			string po_or_letter = "";
			while (or1.Read())
			{
				w_inspby = or1["INSPECTING_AGENCY"].ToString();
				w_insp_remarks = or1["REMARKS"].ToString();
				bpotype = or1["RLY_NONRLY"].ToString();
				po_or_letter = or1["PO_OR_LETTER"].ToString();
				w_pending = Convert.ToInt16(or1["PENDING"].ToString());
			}
			conn1.Close();

			// As Per Instructions of GGM(I) Dated: 28-05-2012

			//				conn1.Open();
			//				OracleCommand cmd2 =new OracleCommand("SELECT sign(sysdate - TO_DATE('"+txtDtOfReciept.Text.Trim()+"','DD/MM/YYYY')) FROM dual",conn1);
			//				int ss=Convert.ToInt32(cmd2.ExecuteScalar());
			//				conn1.Close();
			//				if(ss==1)
			//				{

			string w_stage_or_final = "";
			if (rdbStage.Checked == true)
			{
				w_stage_or_final = "S";
			}
			else
			{
				w_stage_or_final = "F";
			}

			if (w_inspby == "R")
			{
				if (po_or_letter == "P")
				{
					if (w_pending > 0)
					{
						DisplayAlert("Call Cancellation/Rejection charges are pending, Kindly submit the pending charges before submitting the call.");
					}
					else
					{
						string check = match1();
						if (check == "2")
						{
							string code = txtCaseNo.Text.Trim();
							string dt = txtDtOfReciept.Text.Trim();

							conn1.Open();
							//						OracleCommand cmd2 =new OracleCommand("select NVL(count(*),0) CALL from T17_CALL_REGISTER where CASE_NO='"+txtCaseNo.Text.Trim()+"' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')",conn1);
							OracleCommand cmd2 = new OracleCommand("select NVL(count(*),0) CALL from T17_CALL_REGISTER where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_STATUS='M' and FINAL_OR_STAGE='" + w_stage_or_final + "'", conn1);
							int cno = Convert.ToInt16(cmd2.ExecuteScalar());
							conn1.Close();
							if (cno == 0)
							{
								if (bpotype == "R" || bpotype == "U")
								{
									int dp = show2(code);
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
										Response.Redirect("Vendor_Call_Register_Form.aspx?Action=A&Case_No=" + code + "&DT_RECIEPT=" + dt + "&FOS=" + w_stage_or_final);
									}
								}
								else
								{
									Response.Redirect("Vendor_Call_Register_Form.aspx?Action=A&Case_No=" + code + "&DT_RECIEPT=" + dt + "&FOS=" + w_stage_or_final);
								}
							}
							else
							{
								DisplayAlert("Call is already registered against given Case No. and the Call Status is still Pending, so New Call shall not be accepted.");
							}
						}
						else if (check == "0")
						{
							DisplayAlert("No Record Present for the Given Case No.!!! ");
						}
						else
						{
							DisplayAlert("You are not Authorised to Add The Call For Other Vendors.!!! ");
						}
					}
				}
				else if (po_or_letter == "L")
				{
					string code = txtCaseNo.Text.Trim();
					string dt = txtDtOfReciept.Text.Trim();

					if (bpotype == "R" || bpotype == "U")
					{
						int dp = show2(code);
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
							Response.Redirect("Vendor_Call_Register_Form.aspx?Action=A&Case_No=" + code + "&DT_RECIEPT=" + dt + "&FOS=" + w_stage_or_final);
						}
					}
					else
					{
						Response.Redirect("Vendor_Call_Register_Form.aspx?Action=A&Case_No=" + code + "&DT_RECIEPT=" + dt + "&FOS=" + w_stage_or_final);
					}


				}
				else
				{
					DisplayAlert("Online Call cannot be registered as Purchase Order OR Letter of Offer is Blank.");
				}
				//				}
				//				else
				//				{
				//					DisplayAlert("The Call Date Cannot be greater then Current Date.");
				//				}
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
				System.DateTime w_dt2 = new System.DateTime(Convert.ToInt32(lblDtOfReciept.Text.Substring(6, 4)), Convert.ToInt32(lblDtOfReciept.Text.Substring(3, 2)), Convert.ToInt32(lblDtOfReciept.Text.Substring(0, 2)));
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


		public string match1()
		{
			OracleCommand cmd = new OracleCommand("select VEND_CD from T13_PO_MASTER where CASE_NO='" + txtCaseNo.Text.Trim() + "'", conn1);
			string test = "";
			conn1.Open();
			test = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			if (test == "\0" || test == "")
			{
				test = "0";
			}
			else if (test == Session["VEND_CD"].ToString())
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
		private void txtSearch_Click(object sender, System.EventArgs e)
		{
			//string str1 = "select C.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT from T17_CALL_REGISTER C, T80_PO_MASTER P where C.CASE_NO=P.CASE_NO "; 
			string str1 = "select P.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,C.CALL_INSTALL_NO,C.CALL_SNO,decode(C.CALL_STATUS,'M','Pending','A','Accepted','R','Rejection','C','Cancelled','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection')||decode(C.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','')CALL_STATUS,C.CALL_LETTER_NO,P.REMARKS,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT,I.IE_SNAME,(V.VEND_NAME||'('||NVL2(T.LOCATION,T.LOCATION||' : '||T.CITY,T.CITY)||')')VENDOR from T17_CALL_REGISTER C, T13_PO_MASTER P,T09_IE I, T05_VENDOR V,T03_CITY T where P.CASE_NO=C.CASE_NO(+) and C.IE_CD=I.IE_CD(+) and P.VEND_CD=V.VEND_CD and V.VEND_CITY_CD=T.CITY_CD and P.VEND_CD='" + Session["VEND_CD"].ToString() + "'";
			if (txtCaseNo.Text.Trim() != "")
			{
				str1 = str1 + " and P.CASE_NO='" + txtCaseNo.Text.Trim() + "'";
			}
			if (txtPONO.Text.Trim() != "")
			{
				str1 = str1 + " and upper(P.PO_NO) LIKE upper('%" + txtPONO.Text.Trim() + "%')";
			}

			//					if(txtDtOfReciept.Text.Trim()!="")
			//					{
			//
			//						str1 = str1 + " and C.CALL_RECV_DT=to_date('"+txtDtOfReciept.Text.Trim()+"','dd/mm/yyyy')"; 
			//					}


			str1 = str1 + " order by C.CALL_RECV_DT,C.CALL_SNO";

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


		private void btnIns_Click(object sender, System.EventArgs e)
		{
			string code = txtCaseNo.Text.Trim();
			string dt = txtDtOfReciept.Text.Trim();
			Response.Redirect("Inspection_Certificate_Form.aspx?Action=A&Case_No=" + code + "&CALL_RECV_DT=" + dt);
		}

		private void grdCNO_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}





	}
}
