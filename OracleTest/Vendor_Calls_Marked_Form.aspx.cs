using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class Vendor_Calls_Marked_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = null;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		DataSet dsP = new DataSet();
		//	string CNO,DT;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.Button btnSearch1;
		string CNO, DT, CSNO;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label txtCaseNo;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label txtDtOfReciept;
		protected System.Web.UI.WebControls.Label lblCSNO;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label lblPONO;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label lblPODT;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label lblVend;
		protected Tittle.Controls.CustomDataGrid grdCNO;
		protected System.Web.UI.WebControls.DropDownList lstIE;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.RadioButton Radiobutton3;
		protected System.Web.UI.WebControls.Button Submit;
		protected System.Web.UI.WebControls.TextBox txtRunDt;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.Label Label23;
		public string wchk_val, wrun_dt;
		protected System.Web.UI.WebControls.RadioButton Radiobutton1;
		protected System.Web.UI.WebControls.Button btnCancel3;
		protected System.Web.UI.WebControls.Button btnCancel1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblITEM;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblQTYORD;
		protected System.Web.UI.WebControls.Label lblQTYOFF;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblMfg;
		protected System.Web.UI.WebControls.Button btnSendMail;
		protected System.Web.UI.WebControls.Label lblCall1;
		protected System.Web.UI.WebControls.Label lblCall2;
		protected System.Web.UI.WebControls.Label lblHeadPCallsMarked;
		protected System.Web.UI.WebControls.Label lblL5noPo;
		protected System.Web.UI.WebControls.Label lblRly;
		protected System.Web.UI.WebControls.Label lblManuf;
		protected System.Web.UI.WebControls.Label lblREG_TIME;
		protected System.Web.UI.WebControls.TextBox txtCALLLETTERDT;
		protected System.Web.UI.WebControls.Button btnCaseHistory;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblCallMatValue;
		protected System.Web.UI.WebControls.Button btnReject;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Button btnSaveReject;
		protected System.Web.UI.WebControls.TextBox txtRejReason;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtRemarks;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label lblStagDP;
		protected System.Web.UI.WebControls.Label lblLot_DP_1;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label lblLot_DP_2;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label lblDesireDt;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label lblDepartment;
		protected System.Web.UI.WebControls.Label Label51;
		protected System.Web.UI.WebControls.Label lblFinalORStage;
		protected System.Web.UI.WebControls.Label lblDept_CD;
		protected System.Web.UI.WebControls.Label lblIE_CD;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.RadioButton Radiobutton2;

		private void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSaveReject.Attributes.Add("OnClick", "JavaScript:validate1();");

			//			if(Convert.ToString(Request.Params["CASE_NO"])== null ||Convert.ToString(Request.Params ["CALL_RECV_DT"])== null)
			//			{
			//				CNO="";
			//				DT="";
			//				
			//			}
			//			else
			//			{
			//				
			//			}
			if (!(IsPostBack))
			{

				//ddlDept.Items.Insert(0, new ListItem("-Select Departmentlist item-", ""));
				ListItem lst5 = new ListItem();
				lst5 = new ListItem();
				lst5.Text = "Mechanical";
				lst5.Value = "M";
				//lst5.Selected=true;
				ddlDept.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Electrical";
				lst5.Value = "E";
				ddlDept.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Civil";
				lst5.Value = "C";
				ddlDept.Items.Add(lst5);
				//				lst5 = new ListItem(); 
				//				lst5.Text = "Metallurgy"; 
				//				lst5.Value = "L"; 
				//				Dropdownlist1.Items.Add(lst5); 
				lst5 = new ListItem();
				lst5.Text = "Textiles";
				lst5.Value = "T";
				ddlDept.Items.Add(lst5);
				//				lst5 = new ListItem(); 
				//				lst5.Text = "Power Engineering"; 

				//				lst5.Value = "P"; 
				//				Dropdownlist1.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "M & P";
				lst5.Value = "Z";
				ddlDept.Items.Add(lst5);


				if (Convert.ToString(Request.Params["CASE_NO"]) == null || Convert.ToString(Request.Params["CALL_RECV_DT"]) == null)
				{
					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					CNO = "";
					DT = "";
					if (Convert.ToString(Request.Params["CHECK_SELECTED"]) != null || Convert.ToString(Request.Params["CHECK_SELECTED"]) == "")
					{
						wchk_val = Convert.ToString(Request.Params["CHECK_SELECTED"].Trim());
						wrun_dt = Convert.ToString(Request.Params["RUN_DT"].Trim());
						txtRunDt.Text = wrun_dt;
						if (wchk_val == "1")
						{
							Radiobutton1.Checked = true;
						}
						else if (wchk_val == "2")
						{
							Radiobutton2.Checked = true;
						}
						else if (wchk_val == "3")
						{
							Radiobutton3.Checked = true;
						}
						fillgrid();
						Panel3.Visible = true;
						Panel2.Visible = false;
						Panel1.Visible = false;
					}
					else
					{

						Panel3.Visible = false;
						Panel2.Visible = false;
						Panel1.Visible = true;
						conn1.Open();
						OracleCommand cmd = new OracleCommand("SELECT to_char(sysdate,'DD/MM/YYYY') FROM dual", conn1);
						string ss = Convert.ToString(cmd.ExecuteScalar());
						conn1.Close();
						conn1.Dispose();
						txtRunDt.Text = ss;
					}
				}
				else
				{
					CNO = Convert.ToString(Request.Params["CASE_NO"].Trim());
					DT = Convert.ToString(Request.Params["CALL_RECV_DT"].Trim());
					CSNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
					wchk_val = Convert.ToString(Request.Params["CHECK_SELECTED"].Trim());
					wrun_dt = Convert.ToString(Request.Params["RUN_DT"].Trim());

					if (wchk_val == "1")
					{
						Radiobutton1.Checked = true;
					}
					else if (wchk_val == "2")
					{
						Radiobutton2.Checked = true;
					}
					else if (wchk_val == "3")
					{
						Radiobutton3.Checked = true;
					}
					txtRunDt.Text = wrun_dt;
					txtCaseNo.Text = CNO;
					txtDtOfReciept.Text = DT;
					show();
					Panel2.Visible = true;
					Panel1.Visible = false;
					Panel3.Visible = false;
					Label8.Visible = false;
					txtRejReason.Visible = false;
					btnSaveReject.Visible = false;
				}
				get_cluster_ie_list();
				//				if(Session["Role_CD"].ToString()=="4")
				//				{
				//					btnSave.Enabled=false;
				//					grdCNO.Columns[0].Visible=false;
				//				}
				//				fillgrid();
			}
		}
		void get_cluster_ie_list()
		{
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				lstIE.Items.Clear();
				DataSet dsP1 = new DataSet();
				//				string str3 = "select IE_CD, T03.CITY||'  ___________  '||IE_NAME IE from T09_IE T09, T03_CITY T03 where T09.IE_CITY_CD=T03.CITY_CD and IE_STATUS is null and IE_REGION='"+Session["REGION"]+"' order by T03.CITY, IE_NAME "; 
				string str3 = "select (t99.cluster_name||' ('||t09.ie_name||')') CLUSTER_NAME, t09.IE_CD,t99.CLUSTER_CODE  from t99_cluster_master t99,t101_ie_Cluster t101,t09_ie t09 where t99.cluster_code= t101.cluster_code" +
					" and t101.ie_code= t09.ie_cd and t99.REGION_CODE='" + Session["REGION"] + "' and t09.ie_status is null and t99.DEPARTMENT_NAME='" + ddlDept.SelectedValue + "'  order by t99.cluster_name,T09.ie_name";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				ListItem lst3;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
				{
					lst3 = new ListItem();
					lst3.Text = dsP1.Tables[0].Rows[i]["CLUSTER_NAME"].ToString();
					lst3.Value = dsP1.Tables[0].Rows[i]["CLUSTER_CODE"].ToString();
					lstIE.Items.Add(lst3);
				}
				conn1.Close();
				lstIE.Items.Insert(0, "");
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
				conn1.Close();
				conn1.Dispose();
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
			this.Submit.Click += new System.EventHandler(this.Submit_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel1.Click += new System.EventHandler(this.btnCancel1_Click);
			this.btnCaseHistory.Click += new System.EventHandler(this.btnCaseHistory_Click);
			this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
			this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
			this.btnSaveReject.Click += new System.EventHandler(this.btnSaveReject_Click);
			this.grdCNO.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdCNO_ItemDataBound);
			this.btnCancel3.Click += new System.EventHandler(this.btnCancel3_Click);
			this.ddlDept.SelectedIndexChanged += new System.EventHandler(this.ddlDept_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		void Last2Calls_Marked()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP1 = new DataSet();
				string str3 = "select (rownum||'. Call Dated: '||to_char(CALL_RECV_DT,'dd/mm/yyyy')||', Marked To: '||T09.IE_NAME||', Status: '||T21.CALL_STATUS_DESC||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','')) CALL from T17_CALL_REGISTER T17, T09_IE T09, T21_CALL_STATUS_CODES T21 where T17.IE_CD=T09.IE_CD AND T17.CALL_STATUS=T21.CALL_STATUS_CD and T17.CASE_NO= '" + txtCaseNo.Text + "' and rownum <3 order by CALL_RECV_DT DESC";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				if (dsP1.Tables[0].Rows.Count > 0)
				{
					lblCall1.Text = dsP1.Tables[0].Rows[0]["CALL"].ToString();
					if (dsP1.Tables[0].Rows.Count == 2)
					{
						lblCall2.Text = dsP1.Tables[0].Rows[1]["CALL"].ToString();
					}
					lblHeadPCallsMarked.Visible = true;
				}
				else
				{
					lblHeadPCallsMarked.Visible = false;
					lblCall1.Visible = false;
					lblCall2.Visible = false;
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

		void get_call_mat_value()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			double wCall_Mat_value = 0;
			try
			{

				string str3 = "select T15.QTY,T15.VALUE, T18.QTY_TO_INSP from T15_PO_DETAIL T15, T18_CALL_DETAILS T18 where T18.CASE_NO=T15.CASE_NO and T18.ITEM_SRNO_PO=T15.ITEM_SRNO and T18.CASE_NO= '" + CNO + "' and T18.CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and T18.CALL_SNO=" + CSNO;
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader = myOracleCommand.ExecuteReader();
				while (reader.Read())
				{

					double val = (Convert.ToDouble(reader["VALUE"].ToString()) / Convert.ToDouble(reader["QTY"].ToString())) * Convert.ToDouble(reader["QTY_TO_INSP"].ToString());
					wCall_Mat_value = wCall_Mat_value + val;
				}
				conn1.Close();
				lblCallMatValue.Text = Convert.ToString(Math.Round(wCall_Mat_value, 2));
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

		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str3 = "select P.PO_NO,to_char(P.PO_DT,'dd/mm/yyyy') PO_DT, substr(P.RLY_CD,1,7)RLY,P.L5NO_PO,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME,V.VEND_REMARKS,T17.CASE_NO, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy')INSP_DESIRE_DATE, T17.CALL_SNO,to_char(T17.CALL_LETTER_DT,'dd/mm/yyyy') LETTER_DT,T17.REMARKS,(trim(V05.VEND_NAME)||'/'||trim(V05.VEND_ADD1)||'/'||NVL2(CV.LOCATION,CV.LOCATION||' / '||CV.CITY,CV.CITY)) MFG,NVL(V05.VEND_REMARKS,'') MFG_REMARKS, T18.ITEM_SRNO_PO,T18.ITEM_DESC_PO, T18.QTY_ORDERED,T18.QTY_TO_INSP,T17.MFG_CD,decode(T17.STAGGERED_DP,'Y','YES','N','NO','N.A.') STAGG_DP, LOT_DP_1, LOT_DP_2,to_char(T17.DATETIME,'HH24:MI:SS') REG_TIME, decode(T17.DEPARTMENT_CODE,'M','Mechanical','E','Electrical','C','Civil','T','Textiles','M & P') DEPARTMENT, T17.DEPARTMENT_CODE, decode(T17.FINAL_OR_STAGE,'S','Stage','Final')FINAL_OR_STAGE  from T05_VENDOR V, T03_CITY C,T13_PO_MASTER P,T17_CALL_REGISTER T17, T18_CALL_DETAILS T18,T05_VENDOR V05,T03_CITY CV where (T17.CASE_NO=P.CASE_NO and P.VEND_CD=V.VEND_CD and V.VEND_CITY_CD=C.CITY_CD and T17.CASE_NO=T18.CASE_NO(+) AND T17.CALL_RECV_DT=T18.CALL_RECV_DT(+) AND T17.CALL_SNO=T18.CALL_SNO(+) and T17.MFG_CD=V05.VEND_CD and V05.VEND_CITY_CD=CV.CITY_CD) and T17.CASE_NO= '" + CNO + "' and T17.CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and T17.CALL_SNO=" + CSNO;

				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				OracleDataReader reader = myOracleCommand3.ExecuteReader();
				while (reader.Read())
				{
					lblPONO.Text = reader["PO_NO"].ToString();
					lblPODT.Text = reader["PO_DT"].ToString();
					lblVend.Text = reader["VEND_NAME"].ToString();
					if (reader["VEND_REMARKS"].ToString() != "")
					{
						lblVend.Text = lblVend.Text + "<br><font color='crimson'> Remarks: " + reader["VEND_REMARKS"].ToString();
					}
					txtCaseNo.Text = reader["CASE_NO"].ToString();
					txtDtOfReciept.Text = reader["CALL_RECV_DATE"].ToString();
					txtRemarks.Text = reader["REMARKS"].ToString();
					lblREG_TIME.Text = "(" + reader["REG_TIME"].ToString() + ")";
					lblCSNO.Text = reader["CALL_SNO"].ToString();
					lblQTYORD.Text = reader["QTY_ORDERED"].ToString();
					lblQTYOFF.Text = reader["QTY_TO_INSP"].ToString();
					lblITEM.Text = reader["ITEM_DESC_PO"].ToString();
					lblMfg.Text = reader["MFG"].ToString();
					if (reader["MFG_REMARKS"].ToString() != "")
					{
						lblMfg.Text = lblMfg.Text + "<br><font color='crimson'> Remarks: " + reader["MFG_REMARKS"].ToString();
					}
					lblRly.Text = reader["RLY"].ToString();
					lblL5noPo.Text = reader["L5NO_PO"].ToString();
					lblManuf.Text = reader["MFG_CD"].ToString();
					txtCALLLETTERDT.Text = reader["LETTER_DT"].ToString();
					lblStagDP.Text = reader["STAGG_DP"].ToString();
					lblLot_DP_1.Text = reader["LOT_DP_1"].ToString();
					lblLot_DP_2.Text = reader["LOT_DP_2"].ToString();
					lblDesireDt.Text = reader["INSP_DESIRE_DATE"].ToString();
					//lblDepartment.Text=reader["DEPARTMENT"].ToString();
					ddlDept.SelectedValue = reader["DEPARTMENT_CODE"].ToString();
					lblDept_CD.Text = reader["DEPARTMENT_CODE"].ToString();
					lblDept_CD.Visible = false;
					lblFinalORStage.Text = reader["FINAL_OR_STAGE"].ToString();
				}
				reader.Close();
				conn1.Close();
				if (lblITEM.Text.Trim() == "" || lblQTYOFF.Text.Trim() == "" || lblQTYOFF.Text.Trim() == "0")
				{
					btnSendMail.Visible = true;
				}
				else
				{
					btnSendMail.Visible = false;
				}
				string fpath = Server.MapPath("/RBS/Vendor/CALLS_DOCUMENTS/" + txtCaseNo.Text + "-" + txtDtOfReciept.Text.Substring(6, 4) + txtDtOfReciept.Text.Substring(3, 2) + txtDtOfReciept.Text.Substring(0, 2) + "-" + lblCSNO.Text.Trim() + ".pdf");
				//SaveLocation = Server.MapPath("CALLS_DOCUMENTS/" + Label27.Text+"-"+txtDtOfReciept.Text.Substring(6,4)+txtDtOfReciept.Text.Substring(3,2)+txtDtOfReciept.Text.Substring(0,2)+"-"+lblCSNO.Text.Trim()+".pdf");
				if (File.Exists(fpath) == true)
				{
					HyperLink1.Visible = true;
					HyperLink1.NavigateUrl = "/RBS/Vendor/CALLS_DOCUMENTS/" + txtCaseNo.Text + "-" + txtDtOfReciept.Text.Substring(6, 4) + txtDtOfReciept.Text.Substring(3, 2) + txtDtOfReciept.Text.Substring(0, 2) + "-" + lblCSNO.Text.Trim() + ".pdf";
				}
				else
				{
					HyperLink1.Visible = false;
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
				conn1.Close();
				conn1.Dispose();
			}
			Last2Calls_Marked();
			get_call_mat_value();
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}


		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				if (Radiobutton1.Checked == true)
				{
					wchk_val = "1";
				}
				else if (Radiobutton2.Checked == true)
				{
					wchk_val = "2";
				}
				else if (Radiobutton3.Checked == true)
				{
					wchk_val = "3";
				}
				wrun_dt = txtRunDt.Text;
				//				string str1 = "select P.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,C.CALL_INSTALL_NO,C.CALL_SNO,decode(C.CALL_STATUS,'M','Pending','A','Accepted','R','Rejection','C','Cancelled','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection')||decode(C.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','')CALL_STATUS,C.CALL_LETTER_NO,C.REMARKS,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT,(V.VEND_NAME||'('||NVL2(T.LOCATION,T.LOCATION||' : '||T.CITY,T.CITY)||')')VENDOR, I.IE_NAME from T17_CALL_REGISTER C, T13_PO_MASTER P, T05_VENDOR V,T03_CITY T, T09_IE I where C.CASE_NO=P.CASE_NO(+) and C.IE_CD=I.IE_CD(+) and P.VEND_CD=V.VEND_CD and V.VEND_CITY_CD=T.CITY_CD and P.REGION_CODE='"+Session["Region"].ToString()+"'"; 
				string str1 = "select P.CASE_NO,TO_CHAR(C.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,C.CALL_INSTALL_NO,C.CALL_SNO,to_char(C.DATETIME,'dd/mm/yyyy-HH24:MI:SS') DATE_TIME,decode(S.CALL_STATUS_CD,'C',S.CALL_STATUS_DESC||decode(C.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)',''),S.CALL_STATUS_DESC)CALL_STATUS,C.CALL_LETTER_NO,C.REMARKS,P.PO_NO,TO_CHAR(P.PO_DT,'dd/mm/yyyy') PO_DT,(V.VEND_NAME||'('||NVL2(T.LOCATION,T.LOCATION||' : '||T.CITY,T.CITY)||')')VENDOR, I.IE_NAME from T17_CALL_REGISTER C, T13_PO_MASTER P,T09_IE I, T05_VENDOR V,T03_CITY T,T21_CALL_STATUS_CODES S where C.CASE_NO=P.CASE_NO(+) and C.IE_CD=I.IE_CD(+) and P.VEND_CD=V.VEND_CD and V.VEND_CITY_CD=T.CITY_CD and C.CALL_STATUS=S.CALL_STATUS_CD(+) and P.REGION_CODE='" + Session["Region"].ToString() + "' and ONLINE_CALL='Y'";
				if (Radiobutton3.Checked == true)
				{
					str1 = str1 + " and (C.CALL_RECV_DT=to_date('" + txtRunDt.Text + "','dd/mm/yyyy'))";

				}
				if (Radiobutton1.Checked == true)
				{
					str1 = str1 + " and (C.CALL_RECV_DT=to_date('" + txtRunDt.Text + "','dd/mm/yyyy')) and (NVL(C.IE_CD,0)!=0) ";

				}
				if (Radiobutton3.Checked == true || Radiobutton2.Checked == true)
				{
					str1 = str1 + " and (C.IE_CD is null)";
				}
				if (Radiobutton2.Checked == true)
				{
					str1 = str1 + " and (C.CALL_RECV_DT<=to_date('" + txtRunDt.Text + "','dd/mm/yyyy'))";
				}
				if (Radiobutton1.Checked == true || Radiobutton3.Checked == true)
				{
					str1 = str1 + " order by P.CASE_NO,C.CALL_RECV_DT,C.CALL_SNO";
				}
				else
				{
					str1 = str1 + " order by C.CALL_RECV_DT desc,C.CALL_SNO";
				}
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCNO.Visible = false;
					Label4.Visible = true;
					//					throw new System.Exception("No Call found. !!! ");
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

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{

				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				cmd2.Transaction = myTrans;
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				int cl_exist = 0;

				OracleCommand Comm1 = new OracleCommand("select NVL(count(distinct(b.Cluster_code)),0) from T100_vender_cluster a inner join t99_cluster_master b  on a.cluster_code=b.cluster_code where a.vendor_code=" + lblManuf.Text + "  and a.DEPARTMENT_NAME='" + ddlDept.SelectedValue + "' and b.region_code='" + txtCaseNo.Text.Substring(0, 1).ToString() + "'", conn1);
				Comm1.Transaction = myTrans;
				cl_exist = Convert.ToInt32(Comm1.ExecuteScalar());

				OracleCommand cmdIE = new OracleCommand("Select IE_CODE from T101_IE_CLUSTER where CLUSTER_CODE=" + lstIE.SelectedValue + " AND DEPARTMENT_CODE='" + ddlDept.SelectedValue + "'", conn1);
				cmdIE.Transaction = myTrans;
				int IE = Convert.ToInt32(cmdIE.ExecuteScalar());
				lblIE_CD.Text = IE.ToString();
				OracleCommand cmdCO = new OracleCommand("Select IE_CO_CD from T09_IE where IE_CD=" + IE, conn1);
				cmdCO.Transaction = myTrans;
				int CO = Convert.ToInt32(cmdCO.ExecuteScalar());
				string updateQuery = "";
				if (lblDept_CD.Text == ddlDept.SelectedValue)
				{
					updateQuery = "Update T17_CALL_REGISTER set REMARKS='" + txtRemarks.Text + "',IE_CD=" + IE + ",CLUSTER_CODE=" + lstIE.SelectedValue + ",CO_CD=" + CO + ",USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + "";
				}
				else
				{
					updateQuery = "Update T17_CALL_REGISTER set REMARKS='" + txtRemarks.Text + "',IE_CD=" + IE + ",CLUSTER_CODE=" + lstIE.SelectedValue + ",CO_CD=" + CO + ",DEPARTMENT_CODE='" + ddlDept.SelectedValue + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + "";
				}
				OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn1);
				myUpdateCommand.Transaction = myTrans;
				myUpdateCommand.ExecuteNonQuery();

				if (cl_exist == 0)
				{
					string myInsertQuery_Cluster = "INSERT into T100_VENDER_CLUSTER values('" + lblManuf.Text + "', '" + ddlDept.SelectedValue + "'," + lstIE.SelectedValue + ",'" + Session["UName"] + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand_Cluster = new OracleCommand(myInsertQuery_Cluster);
					myInsertCommand_Cluster.Transaction = myTrans;
					myInsertCommand_Cluster.Connection = conn1;
					myInsertCommand_Cluster.ExecuteNonQuery();
				}

				OracleCommand cmd1 = new OracleCommand("Select NVL(COUNT(*),0) from T60_IE_POI_MAPPING WHERE IE_CD=" + lblIE_CD.Text + " AND POI_CD='" + lblManuf.Text + "'", conn1);
				cmd1.Transaction = myTrans;
				int ietopoicount = Convert.ToInt16(cmd1.ExecuteScalar());
				if (ietopoicount == 0)
				{
					string myInsertQuery = "INSERT into T60_IE_POI_MAPPING values('" + IE + "', '" + lblManuf.Text + "')";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Transaction = myTrans;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
				}
				myTrans.Commit();
				conn1.Close();


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				myTrans.Rollback();
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}

			Panel2.Visible = false;
			Panel1.Visible = false;
			Panel3.Visible = true;
			send_Vendor_Email();
			//if ((lstIE.SelectedValue.Trim()!="") & (Session["Region"].ToString()=="N")) {send_IE_sms();}
			if ((lstIE.SelectedValue.Trim() != ""))
			{
				send_IE_sms();
			}
			fillgrid();

		}

		void send_IE_sms()
		{
			string sender = "";
			string wIEMobile = "", wIEName = "", wVendor = "", wCOMobile = "", wVendMobile = "", wIEMobile_for_SMS = "";
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleCommand cmd = new OracleCommand();
			if (Session["Region"].ToString() == "N") { sender = "NR"; }
			else if (Session["Region"].ToString() == "W") { sender = "WR"; }
			else if (Session["Region"].ToString() == "E") { sender = "ER"; }
			else if (Session["Region"].ToString() == "S") { sender = "SR"; }
			else if (Session["Region"].ToString() == "C") { sender = "CR"; }
			else { sender = "RITES"; }
			//
			conn1.Open();
			cmd.CommandText = "Select trim(SUBSTR(t09.IE_NAME,1,20)) IE_NAME,trim(substr(t09.IE_PHONE_NO,1,10)) IE_PHONE_NO, trim(substr(t08.CO_PHONE_NO,1,10)) CO_PHONE_NO from T09_IE t09,T08_IE_CONTROLL_OFFICER t08 where t08.CO_CD(+)=t09.IE_CO_CD and t09.IE_CD=" + lblIE_CD.Text;
			cmd.Connection = conn1;
			OracleDataReader reader1 = cmd.ExecuteReader();
			while (reader1.Read())
			{
				wIEName = reader1["IE_NAME"].ToString();
				wIEMobile = reader1["IE_PHONE_NO"].ToString();
				wIEMobile_for_SMS = reader1["IE_PHONE_NO"].ToString();
				wCOMobile = reader1["CO_PHONE_NO"].ToString();
			}
			cmd.Dispose();
			//
			//cmd.CommandText="select substr(V.VEND_NAME,1,30)||','||substr(C.CITY,1,12) VEND_NAME,trim(substr(VEND_CONTACT_TEL_1,1,10)) VEND_TEL from T05_VENDOR V, T03_CITY C where VEND_CD="+lblManuf.Text+" and V.VEND_CITY_CD=C.CITY_CD"; 
			cmd.CommandText = "select replace(substr(V.VEND_NAME,1,30),'&','AND') VEND_NAME,trim(substr(VEND_CONTACT_TEL_1,1,10)) VEND_TEL from T05_VENDOR V, T03_CITY C where VEND_CD=" + lblManuf.Text + " and V.VEND_CITY_CD=C.CITY_CD";
			cmd.Connection = conn1;
			OracleDataReader reader2 = cmd.ExecuteReader();
			while (reader2.Read())
			{
				wVendor = reader2["VEND_NAME"].ToString();
				wVendMobile = reader2["VEND_TEL"].ToString();
			}
			cmd.Dispose();
			//
			if (wCOMobile != "") { wIEMobile = wIEMobile + "," + wCOMobile; }
			if (wVendMobile != "") { wIEMobile = wIEMobile + "," + wVendMobile; }
			//
			//string message="RITES LTD - QA CALL MARKED,IE-"+wIEName+",Contact No.:"+wIEMobile_for_SMS+",RLY-"+lblRly.Text+",PO-"+lblL5noPo.Text+",DT-"+lblPODT.Text+",FIRM NAME-"+wVendor+",Call Sno-"+lblCSNO.Text+",DT-"+txtDtOfReciept.Text+"- RITES/"+sender;
			string message = "RITES LTD - QA Call Marked, IE-" + wIEName + ",Contact No.:" + wIEMobile_for_SMS + ",RLY-" + lblRly.Text + ",PO-" + lblL5noPo.Text + ",DT- " + lblPODT.Text + ", Firm Name-" + wVendor + ", Call Sno - " + lblCSNO.Text + ",DT- " + txtDtOfReciept.Text + "- RITES/" + sender;
			//
			WebClient client = new WebClient();
			//string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=ritesinsp&password=754347474&sendername=RITESQ&mobileno="+wIEMobile+"&message="+message;
			//string baseurl = "http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=1ritesltd&password=R1te3@lxt&sender=RITESQ&to="+wIEMobile+"&message="+message+"&reqid=1&format={json|text}&route_id=23";
			//string baseurl = "http://103.247.98.91/API/SendMsg.aspx?uname=20181896&pass=9eBWwFz9&send=RITESQ&dest="+wIEMobile+"&msg="+message+"&priority=1";
			//string baseurl = "http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=2ritesltd&password=Ag@14rtd&sender=RITESQ&to="+wIEMobile+"&message="+message+"&reqid=1&format={json|text}&route_id=23";
			//string baseurl = "http://nimbusit.co.in/api/swsendSingle.asp?username=t1RitesLtd&password=104848267&sender=RITESQ&sendto="+wIEMobile+"&message="+message+"&entityID=1501484780000011007";
			//string baseurl = "http://nimbusit.co.in/api/swsend.asp?username=t1RitesLtd&password=104848267&sender=RITESQ&sendto="+wIEMobile+"&message="+message;


			//string baseurl = "http://nimbusit.co.in/api/swsend.asp?username=t1RitesLtd&password=104848267&sender=RITESI&sendto="+wIEMobile+"&entityID=1501628520000011823&templateID=1707161588918541674&message="+message;

			string baseurl = "http://apin.onex-aura.com/api/sms?key=QtPr681q&to=" + wIEMobile + "&from=RITESI&body=" + message + "&entityid=1501628520000011823&templateid=1707161588918541674";
			Stream data = client.OpenRead(baseurl);
			StreamReader smsreader = new StreamReader(data);
			string s = smsreader.ReadToEnd();
			data.Close();
			smsreader.Close();
		}

		void send_Vendor_Email()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string wRegion = "";

				string sender = "";
				if (Session["Region"].ToString() == "N") { wRegion = "NORTHERN REGION <BR>12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 <BR>Phone : +918800018691-95 <BR>Fax : 011-22024665"; sender = "nrinspn@rites.com"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "SOUTHERN REGION <BR>CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 <BR>Phone : 044-28292807/044- 28292817 <BR>Fax : 044-28290359"; sender = "srinspn@rites.com"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "EASTERN REGION <BR>CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  <BR>Fax : 033-22348704"; sender = "erinspn@rites.com"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "WESTERN REGION <BR>5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 <BR>Phone : 022-68943400/68943445 <BR>"; sender = "wrinspn@rites.com"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

				OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1)||'/'||T03.CITY VEND_ADDRESS, T05.VEND_EMAIL from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string vend_cd = "", vend_add = "", vend_email = "";
				while (reader.Read())
				{
					vend_cd = Convert.ToString(reader["VEND_CD"]);
					vend_add = Convert.ToString(reader["VEND_ADDRESS"]);
					vend_email = Convert.ToString(reader["VEND_EMAIL"]);

				}
				conn1.Close();

				OracleCommand cmd = new OracleCommand("Select T05.VEND_EMAIL,T17.MFG_CD,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy')DESIRE_DT from T05_VENDOR T05,T17_CALL_REGISTER T17 where T05.VEND_CD=T17.MFG_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text, conn1);
				conn1.Open();
				string manu_mail = "";
				string mfg_cd = "";
				string desire_dt = "";
				OracleDataReader reader1 = cmd.ExecuteReader();
				while (reader1.Read())
				{
					manu_mail = Convert.ToString(reader1["VEND_EMAIL"]);
					mfg_cd = Convert.ToString(reader1["MFG_CD"]);
					desire_dt = Convert.ToString(reader1["DESIRE_DT"]);
				}

				conn1.Close();
				//				OracleCommand cmd1 =new OracleCommand("Select IE_PHONE_NO from T09_IE where IE_CD="+lstIE.SelectedValue,conn1);
				//				conn1.Open();
				//				string ie_phone=Convert.ToString(cmd1.ExecuteScalar());
				//				conn1.Close();

				OracleCommand cmd1 = new OracleCommand("SELECT IE_PHONE_NO, CO_NAME, CO_PHONE_NO, IE_NAME, IE_EMAIL FROM T09_IE T09, T08_IE_CONTROLL_OFFICER T08 WHERE T09.IE_CO_CD=T08.CO_CD AND IE_CD=" + lblIE_CD.Text, conn1);
				conn1.Open();
				OracleDataReader reader2 = cmd1.ExecuteReader();
				string ie_phone = "", co_name = "", co_mobile = "", ie_name = "", ie_email = "";
				while (reader2.Read())
				{
					ie_phone = Convert.ToString(reader2["IE_PHONE_NO"]);
					co_name = Convert.ToString(reader2["CO_NAME"]);
					co_mobile = Convert.ToString(reader2["CO_PHONE_NO"]);
					ie_name = Convert.ToString(reader2["IE_NAME"]);
					ie_email = Convert.ToString(reader2["IE_EMAIL"]);

				}
				conn1.Close();
				//				NO OF DAYS TO ATTEND THE CALL

				OracleCommand cmd11 = new OracleCommand("SELECT TO_CHAR(DT_INSP_DESIRE + (SELECT ROUND(COUNT(*)/1.5) DAYS FROM T17_CALL_REGISTER WHERE (CALL_RECV_DT>'01-APR-2017') AND CALL_STATUS IN ('M','S') AND IE_CD=" + lblIE_CD.Text + "),'DD/MM/YYYY') INSP_DATE FROM T17_CALL_REGISTER WHERE CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text, conn1);
				conn1.Open();
				string dateto_attend = Convert.ToString(cmd11.ExecuteScalar());

				string updateQuery = "Update T17_CALL_REGISTER set EXP_INSP_DT=TO_DATE('" + dateto_attend + "','dd/mm/yyyy') where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text;
				OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn1);
				myUpdateCommand.ExecuteNonQuery();

				OracleCommand cmd21 = new OracleCommand("SELECT NVL(max(TIME_FOR_INSP),0) DAYS_TO_IC, T61.ITEM_CD FROM T18_CALL_DETAILS T18, T15_PO_DETAIL T15, T61_ITEM_MASTER T61 WHERE T18.CASE_NO=T15.CASE_NO AND T18.ITEM_SRNO_PO=T15.ITEM_SRNO AND T15.ITEM_CD=T61.ITEM_CD AND T15.CASE_NO='" + txtCaseNo.Text.Trim() + "' GROUP BY T61.ITEM_CD", conn1);
				OracleDataReader reader21 = cmd21.ExecuteReader();
				int days_to_ic = 0;
				string item_cd = "";
				while (reader21.Read())
				{
					days_to_ic = Convert.ToInt32(reader21["DAYS_TO_IC"]);
					item_cd = Convert.ToString(reader21["ITEM_CD"]);
				}
				conn1.Close();


				string call_letter_dt = "";
				if (txtCALLLETTERDT.Text.Trim() == "")
				{
					call_letter_dt = "NIL";
				}
				else
				{
					call_letter_dt = txtCALLLETTERDT.Text;
				}
				string mail_body = "Dear Sir/Madam,<br><br> In Reference to your Call Letter dated:  " + call_letter_dt + " for inspection of material against PO No. - " + lblPONO.Text + " & date - " + lblPODT.Text + ", Call has been registered vide Case No -  " + txtCaseNo.Text + ", on date: " + txtDtOfReciept.Text + ", at SNo. " + lblCSNO.Text + ".<br> ";
				if (txtDtOfReciept.Text.Trim() != desire_dt.Trim())
				{
					mail_body = mail_body + "The Desired Inspection Date of this call shall be on or after: " + desire_dt.Trim() + ".<br>";
				}

				if (days_to_ic == 0)
				{
					mail_body = mail_body + "The inspection call has been assigned to Inspecting Engineer Sh. " + ie_name + ", Contact No. " + ie_phone + ", Email ID: " + ie_email + ". Based on the current workload with the IE, Inspection is likely to be attended on or before " + dateto_attend + " or next working day (In case the above date happens to be a holiday). Dates are subject to last minute changes due to  exigencies of work and overriding Client priorities. <br> Name of Controlling Manager of concerned IE Sh.: " + co_name + ", Contact No." + co_mobile + ". <br>Offered Material as per registration should be readily available on the indicated date along with all related documents and internal test reports.<br><a href='http://rites.ritesinsp.com/RBS/Guidelines for Vendors.pdf'>Guidelines for Vendors</a>.<br>For Inspection related information please visit : http://ritesinsp.com. <br> For any correspondence in future, please quote Case No. only. <br><br>Thanks for using RITES Inspection Services. <br><br>" + wRegion + ".";
				}
				else if (days_to_ic > 0)
				{
					System.DateTime w_dt1 = new System.DateTime(Convert.ToInt32(dateto_attend.Substring(6, 4)), Convert.ToInt32(dateto_attend.Substring(3, 2)), Convert.ToInt32(dateto_attend.Substring(0, 2)));
					System.DateTime w_dt2 = w_dt1.AddDays(days_to_ic);
					string date_to_ic = w_dt2.ToString("dd/MM/yyyy");
					mail_body = mail_body + "The inspection call has been assigned to Inspecting Engineer Sh. " + ie_name + ", Contact No. " + ie_phone + ", Email ID: " + ie_email + ". Based on the current workload with the IE, Inspection is likely to be attended on or before " + dateto_attend + " or next working day (In case the above date happens to be a holiday) and Inspection certificate is likely to issued by " + date_to_ic + ". Dates are subject to last minute changes due to  exigencies of work and overriding Client priorities. <br> Name of Controlling Manager of concerned IE Sh.: " + co_name + ", Contact No." + co_mobile + ". <br>Offered Material as per registration should be readily available on the indicated date along with all related documents and internal test reports. Inspection is proposed to be conducted as per inspection plan: <a href='http://rites.ritesinsp.com/RBS/MASTER_ITEMS_CHECKSHEETS/" + item_cd + ".RAR'>Inspection Plan</a>.<br><a href='http://rites.ritesinsp.com/RBS/Guidelines for Vendors.pdf'>Guidelines for Vendors</a>.<br>For Inspection related information please visit : http://ritesinsp.com. <br> For any correspondence in future, please quote Case No. only. <br><br> Thanks for using RITES Inspection Services. <br><br>" + wRegion + ".";
				}
				//mail_body=mail_body+ "The inspection call has been assigned to Inspecting Engineer Sh. " + ie_name+", Contact No. "+ie_phone +", Email ID: "+ie_email+". Based on the current workload with the IE, Inspection is likely to be attended on or before "+dateto_attend+" or next working day (In case the above date happens to be a holiday). Dates are subject to last minute changes due to  exigencies of work and overriding Client priorities. \n Name of Controlling Manager of concerned IE Sh.: "+ co_name +", Contact No."+co_mobile+". \nOffered Material as per registration should be readily available on the indicated date along with all related documents and internal test reports. \nFor Inspection related information please visit : http://ritesinsp.com. \n For any correspondence in future, please quote Case No. only. \n\n Thanks for using RITES Inspection Services. \n\n"+ wRegion +"." ;

				mail_body = mail_body + "<br><br> THIS IS AN AUTO GENERATED EMAIL. PLEASE DO NOT REPLY. USE EMAIL GIVEN IN THE REGION ADDRESS.<BR>NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE)";

				if (vend_cd == mfg_cd && manu_mail != "")
				{
					MailMessage mail = new MailMessage();
					mail.To = manu_mail;
					mail.Bcc = "nrinspn@gmail.com";
					mail.From = sender;
					mail.Subject = "Your Call for Inspection By RITES";
					mail.BodyFormat = MailFormat.Html;
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																												//					SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
					SmtpMail.SmtpServer = "10.60.50.81";
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);
				}
				else if (vend_cd != mfg_cd && vend_email != "" && manu_mail != "")
				{

					MailMessage mail = new MailMessage();
					mail.To = vend_email + ";" + manu_mail;
					mail.Bcc = "nrinspn@gmail.com";
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Your Call for Inspection By RITES";
					mail.Body = mail_body;
					mail.BodyFormat = MailFormat.Html;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																												//					SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
					SmtpMail.SmtpServer = "10.60.50.81";
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);

				}
				else if (vend_cd != mfg_cd && (vend_email == "" || manu_mail == ""))
				{
					MailMessage mail = new MailMessage();
					if (vend_email == "")
					{
						mail.To = manu_mail;
					}
					else if (manu_mail == "")
					{
						mail.To = vend_email;
					}
					mail.Bcc = "nrinspn@gmail.com";
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Your Call for Inspection By RITES";
					mail.BodyFormat = MailFormat.Html;
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																												//					SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
					SmtpMail.SmtpServer = "10.60.50.81";
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);

				}
				OracleCommand cmd2 = new OracleCommand("Select CO_EMAIL from T08_IE_CONTROLL_OFFICER T08, T09_IE T09 where T09.IE_CO_CD=T08.CO_CD and IE_CD=" + lblIE_CD.Text, conn1);
				conn1.Open();
				string controlling_email = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();

				OracleCommand cmd_manu = new OracleCommand("Select T05.VEND_NAME,T03.CITY VEND_ADDRESS from T17_CALL_REGISTER T17,T05_VENDOR T05, T03_CITY T03 where T17.MFG_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text, conn1);
				conn1.Open();
				OracleDataReader readerm = cmd_manu.ExecuteReader();
				string manu_name = "", manu_add = "";
				while (readerm.Read())
				{
					manu_name = Convert.ToString(readerm["VEND_NAME"]);
					manu_add = Convert.ToString(readerm["VEND_ADDRESS"]);
				}
				conn1.Close();

				if (controlling_email != "")
				{
					MailMessage mail2 = new MailMessage();
					mail2.To = controlling_email;
					if (ie_email != "")
					{
						mail2.Cc = ie_email;
					}
					//mail2.Bcc = "nrinspn@gmail.com";
					//mail2.From=sender;
					mail2.From = "nrinspn@gmail.com";
					mail2.Subject = "Your Call (" + manu_name + " - " + manu_add + ") for Inspection By RITES";
					mail2.BodyFormat = MailFormat.Html;
					mail2.Body = mail_body;
					mail2.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
																												//					SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
					SmtpMail.SmtpServer = "10.60.50.81";
					mail2.Priority = MailPriority.High;
					SmtpMail.Send(mail2);
				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//				Response.Write(ex);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}


		}

		void send_Vendor_Email_for_Incomplete_Call_Details()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string wRegion = "";

				string sender = "";
				if (Session["Region"].ToString() == "N") { wRegion = "NORTHERN REGION \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : +918800018691-95 \n Fax : 011-22024665"; sender = "nrinspn@rites.com"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "SOUTHERN REGION \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292807/044- 28292817 \n Fax : 044-28290359"; sender = "srinspn@rites.com"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "EASTERN REGION \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; sender = "erinspn@rites.com"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "WESTERN REGION \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445 <BR>"; sender = "wrinspn@rites.com"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

				OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1)||'/'||T03.CITY VEND_ADDRESS, T05.VEND_EMAIL from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string vend_cd = "", vend_add = "", vend_email = "";
				while (reader.Read())
				{
					vend_cd = Convert.ToString(reader["VEND_CD"]);
					vend_add = Convert.ToString(reader["VEND_ADDRESS"]);
					vend_email = Convert.ToString(reader["VEND_EMAIL"]);

				}
				conn1.Close();

				OracleCommand cmd = new OracleCommand("Select T05.VEND_EMAIL,T17.MFG_CD from T05_VENDOR T05,T17_CALL_REGISTER T17 where T05.VEND_CD=T17.MFG_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text, conn1);
				conn1.Open();
				string manu_mail = "";
				string mfg_cd = "";
				OracleDataReader reader1 = cmd.ExecuteReader();
				while (reader1.Read())
				{
					manu_mail = Convert.ToString(reader1["VEND_EMAIL"]);
					mfg_cd = Convert.ToString(reader1["MFG_CD"]);

				}

				conn1.Close();
				//				OracleCommand cmd1 =new OracleCommand("Select IE_PHONE_NO from T09_IE where IE_CD="+lstIE.SelectedValue,conn1);
				//				conn1.Open();
				//				string ie_phone=Convert.ToString(cmd1.ExecuteScalar());
				//				conn1.Close();
				string call_letter_dt = "";
				if (txtCALLLETTERDT.Text.Trim() == "")
				{
					call_letter_dt = "NIL";
				}
				else
				{
					call_letter_dt = txtCALLLETTERDT.Text;
				}
				string mail_body = "Dear Sir/Madam,\n\n Call Letter dated:  " + call_letter_dt + " for inspection of material against PO No. - " + lblPONO.Text + " dated - " + lblPODT.Text + ", Case No -  " + txtCaseNo.Text + ", on date: " + txtDtOfReciept.Text + ", at SNo. " + lblCSNO.Text + ". The Call submitted with incomplete details, so not marked and deleted.\n\nPlease re-submit with complete details.\n\n Thanks for using RITES Inspection Services. \n\n" + wRegion + ".";



				if (vend_cd == mfg_cd && manu_mail != "")
				{
					MailMessage mail = new MailMessage();
					mail.To = manu_mail;
					mail.Bcc = "nrinspn@gmail.com";
					mail.From = sender;
					mail.Subject = "Your Call for Inspection By RITES";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																												//					SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
					SmtpMail.SmtpServer = "10.60.50.81";
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);
				}
				else if (vend_cd != mfg_cd)
				{

					if (vend_email != "")
					{
						MailMessage mail = new MailMessage();
						mail.To = vend_email;
						mail.Bcc = "nrinspn@gmail.com";
						mail.From = sender;
						mail.Subject = "Your Call for Inspection By RITES";
						mail.Body = mail_body;
						mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																													//						SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
						SmtpMail.SmtpServer = "10.60.50.81";
						mail.Priority = MailPriority.High;
						SmtpMail.Send(mail);

					}
					else if (manu_mail != "")
					{
						MailMessage mail1 = new MailMessage();
						mail1.To = manu_mail;
						mail1.Bcc = "nrinspn@gmail.com";
						mail1.From = sender;
						mail1.Subject = "Your Call for Inspection By RITES";
						mail1.Body = mail_body;
						mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
																													//						SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
						SmtpMail.SmtpServer = "10.60.50.81";
						mail1.Priority = MailPriority.High;
						SmtpMail.Send(mail1);
					}

				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//				Response.Write(ex);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}


		}

		void send_Vendor_Email_for_Rejected_Calls()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string wRegion = "";

				string sender = "";
				if (Session["Region"].ToString() == "N") { wRegion = "NORTHERN REGION \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : +918800018691-95 \n Fax : 011-22024665"; sender = "nrinspn@rites.com"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "SOUTHERN REGION \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292807/044- 28292817 \n Fax : 044-28290359"; sender = "srinspn@rites.com"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "EASTERN REGION \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; sender = "erinspn@rites.com"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "WESTERN REGION \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445 <BR>"; sender = "wrinspn@rites.com"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

				OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1)||'/'||T03.CITY VEND_ADDRESS, T05.VEND_EMAIL from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string vend_cd = "", vend_add = "", vend_email = "";
				while (reader.Read())
				{
					vend_cd = Convert.ToString(reader["VEND_CD"]);
					vend_add = Convert.ToString(reader["VEND_ADDRESS"]);
					vend_email = Convert.ToString(reader["VEND_EMAIL"]);

				}
				conn1.Close();

				OracleCommand cmd = new OracleCommand("Select T05.VEND_EMAIL,T17.MFG_CD from T05_VENDOR T05,T17_CALL_REGISTER T17 where T05.VEND_CD=T17.MFG_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text, conn1);
				conn1.Open();
				string manu_mail = "";
				string mfg_cd = "";
				OracleDataReader reader1 = cmd.ExecuteReader();
				while (reader1.Read())
				{
					manu_mail = Convert.ToString(reader1["VEND_EMAIL"]);
					mfg_cd = Convert.ToString(reader1["MFG_CD"]);

				}

				conn1.Close();
				//				OracleCommand cmd1 =new OracleCommand("Select IE_PHONE_NO from T09_IE where IE_CD="+lstIE.SelectedValue,conn1);
				//				conn1.Open();
				//				string ie_phone=Convert.ToString(cmd1.ExecuteScalar());
				//				conn1.Close();
				string call_letter_dt = "";
				if (txtCALLLETTERDT.Text.Trim() == "")
				{
					call_letter_dt = "NIL";
				}
				else
				{
					call_letter_dt = txtCALLLETTERDT.Text;
				}
				string mail_body = "Dear Sir/Madam,\n\n Call Letter dated:  " + call_letter_dt + " for inspection of material against PO No. - " + lblPONO.Text + " dated - " + lblPODT.Text + ", Case No -  " + txtCaseNo.Text + ", on date: " + txtDtOfReciept.Text + ", at SNo. " + lblCSNO.Text + ". The Call is rejected due to following Reason:- " + txtRejReason.Text + ", so not marked and deleted. Please Resubmit the call after making necessary corrections. \n\n Thanks for using RITES Inspection Services. \n\n" + wRegion + ".";

				mail_body = mail_body + "\n\n THIS IS AN AUTO GENERATED EMAIL. PLEASE DO NOT REPLY. USE EMAIL GIVEN IN THE REGION ADDRESS";

				if (vend_cd == mfg_cd && manu_mail != "")
				{
					MailMessage mail = new MailMessage();
					mail.To = manu_mail;
					mail.Bcc = "nrinspn@gmail.com";
					mail.From = sender;
					mail.Subject = "Your Call for Inspection By RITES";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																												//					SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
					SmtpMail.SmtpServer = "10.60.50.81";
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);
				}
				else if (vend_cd != mfg_cd)
				{

					if (vend_email == "")
					{
						MailMessage mail = new MailMessage();
						mail.To = manu_mail;
						mail.Bcc = "nrinspn@gmail.com";
						mail.From = sender;
						mail.Subject = "Your Call for Inspection By RITES";
						mail.Body = mail_body;
						mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																													//						SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
						SmtpMail.SmtpServer = "10.60.50.81";
						mail.Priority = MailPriority.High;
						SmtpMail.Send(mail);

					}
					else if (manu_mail == "")
					{
						MailMessage mail1 = new MailMessage();
						mail1.To = vend_email;
						mail1.Bcc = "nrinspn@gmail.com";
						mail1.From = sender;
						mail1.Subject = "Your Call for Inspection By RITES";
						mail1.Body = mail_body;
						mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
																													//						SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
						SmtpMail.SmtpServer = "10.60.50.81";
						mail1.Priority = MailPriority.High;
						SmtpMail.Send(mail1);
					}
					else
					{
						MailMessage mail2 = new MailMessage();
						mail2.To = vend_email + ";" + manu_mail;
						mail2.Bcc = "nrinspn@gmail.com";
						mail2.From = sender;
						mail2.Subject = "Your Call for Inspection By RITES";
						mail2.Body = mail_body;
						mail2.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
																													//						SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
						SmtpMail.SmtpServer = "10.60.50.81";
						mail2.Priority = MailPriority.High;
						SmtpMail.Send(mail2);
					}

				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//				Response.Write(ex);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}


		}
		private void Submit_Click(object sender, System.EventArgs e)
		{


			if (Radiobutton1.Checked == true)
			{
				wchk_val = "1";
			}
			else if (Radiobutton2.Checked == true)
			{
				wchk_val = "2";
			}
			else if (Radiobutton3.Checked == true)
			{
				wchk_val = "3";
			}
			wrun_dt = txtRunDt.Text.Trim();
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			int ss = 0;
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("SELECT sign(sysdate - TO_DATE('" + wrun_dt + "','DD/MM/YYYY')) FROM dual", conn1);
				ss = Convert.ToInt32(cmd2.ExecuteScalar());
				conn1.Close();
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
				conn1.Close();
				conn1.Dispose();
			}
			if (ss == 1)
			{
				Panel1.Visible = false;
				Panel2.Visible = false;
				Panel3.Visible = true;
				fillgrid();
			}
			else
			{
				DisplayAlert("The Call Date Cannot be greater then Current Date.");
			}
		}



		private void btnCancel1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Vendor_Calls_Marked_Form.aspx?CHECK_SELECTED=" + Request.Params["CHECK_SELECTED"].ToString() + "&RUN_DT=" + Request.Params["RUN_DT"].ToString());
			//			Panel2.Visible=false;
			//			Panel1.Visible=false;
			//			Panel3.Visible=true;
			//			fillgrid();
		}

		private void btnCancel3_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Vendor_Calls_Marked_Form.aspx");
		}

		private void btnSendMail_Click(object sender, System.EventArgs e)
		{
			send_Vendor_Email_for_Incomplete_Call_Details();
			Delete_Incomplete_Call(); // As Per Instructions By GM(I-NR) Dated: 15-May-2012.
		}

		void Delete_Incomplete_Call()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleCommand cmdcall = new OracleCommand("select nvl(count(CASE_NO),0) from T18_CALL_DETAILS where CASE_NO= '" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text.Trim(), conn1);
			conn1.Open();
			int detailstatus = Convert.ToInt16(cmdcall.ExecuteScalar());
			conn1.Close();

			OracleCommand cmdcall1 = new OracleCommand("select nvl(count(CASE_NO),0) from T17_CALL_REGISTER where NVL(IE_CD,0)=0 and NVL(CALL_STATUS,'X') = 'M' and CASE_NO= '" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text.Trim(), conn1);
			conn1.Open();
			int callmarkstatus = Convert.ToInt16(cmdcall1.ExecuteScalar());
			conn1.Close();

			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{

				if (detailstatus == 0 && callmarkstatus == 1)
				{

					//					string myDeleteQuery2 = "Delete T19_CALL_CANCEL where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') AND CALL_SNO="+CSNO; 
					//					OracleCommand myOracleCommand2 = new OracleCommand(myDeleteQuery2); 
					//					myOracleCommand2.Transaction=myTrans;
					//					myOracleCommand2.Connection = conn1; 
					//					myOracleCommand2.ExecuteNonQuery(); 

					string myDeleteQuery1 = "Delete T18_CALL_DETAILS where CASE_NO= '" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text.Trim();
					OracleCommand myOracleCommand1 = new OracleCommand(myDeleteQuery1);
					myOracleCommand1.Transaction = myTrans;
					myOracleCommand1.Connection = conn1;
					myOracleCommand1.ExecuteNonQuery();

					string myDeleteQuery = "Delete T17_CALL_REGISTER where CASE_NO= '" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text.Trim();
					OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
					myOracleCommand.Transaction = myTrans;
					myOracleCommand.Connection = conn1;
					myOracleCommand.ExecuteNonQuery();

					myTrans.Commit();

					conn1.Close();
					DisplayAlert("This Call Has Been Deleted!!!");
				}
				else
				{
					DisplayAlert("This Call cannot be Deleted,Whether Item is their in the Call or The Call is Marked to IE or The Call Status is Other then Pending!!!");
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				myTrans.Rollback();
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}



		private void grdCNO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				if (e.Item.Cells[7].Text != "&nbsp;")
				{
					e.Item.Cells[0].Text = "";
				}


			}
		}

		private void btnCaseHistory_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Query/qryUnInspectedQty.aspx?CASE_NO=" + txtCaseNo.Text.Trim() + "&ACTION=CHI");
		}

		private void btnSaveReject_Click(object sender, System.EventArgs e)
		{
			send_Vendor_Email_for_Rejected_Calls();
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{

				string myDeleteQuery1 = "Delete T18_CALL_DETAILS where CASE_NO= '" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text.Trim();
				OracleCommand myOracleCommand1 = new OracleCommand(myDeleteQuery1);
				myOracleCommand1.Transaction = myTrans;
				myOracleCommand1.Connection = conn1;
				myOracleCommand1.ExecuteNonQuery();

				string myDeleteQuery = "Delete T17_CALL_REGISTER where CASE_NO= '" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text.Trim();
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Transaction = myTrans;
				myOracleCommand.Connection = conn1;
				myOracleCommand.ExecuteNonQuery();

				myTrans.Commit();

				conn1.Close();
				DisplayAlert("This Call Has Been Deleted!!!");

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				myTrans.Rollback();
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}

		}

		private void btnReject_Click(object sender, System.EventArgs e)
		{
			Label8.Visible = true;
			txtRejReason.Visible = true;
			btnSaveReject.Visible = true;
		}

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			get_cluster_ie_list();
		}
	}
}