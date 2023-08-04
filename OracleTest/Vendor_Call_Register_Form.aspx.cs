using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Vendor_Call_Register_Form
{
	public partial class Vendor_Call_Register_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		//protected System.Web.UI.WebControls.Button btnSave;
		//protected System.Web.UI.WebControls.Label Label1;
		public string CNO, DT, Action, CSNO, cstatus;
		//protected System.Web.UI.WebControls.Button btnCancel;
		//protected System.Web.UI.WebControls.Label Label6;
		//protected System.Web.UI.WebControls.TextBox txtCaseNo;
		//protected System.Web.UI.WebControls.Label Label3;
		//protected System.Web.UI.WebControls.Label Label26;
		//protected System.Web.UI.WebControls.Label Label10;
		//protected System.Web.UI.WebControls.TextBox txtMName;
		//protected System.Web.UI.WebControls.Label Label24;
		//protected System.Web.UI.WebControls.TextBox txtMPOI;
		//protected System.Web.UI.WebControls.Label Label11;
		//protected System.Web.UI.WebControls.TextBox txtMConPer;
		//protected System.Web.UI.WebControls.Label label20;
		//protected System.Web.UI.WebControls.TextBox txtMPNo;
		//protected System.Web.UI.WebControls.Label Label14;
		//protected System.Web.UI.WebControls.Label Label15;
		//protected System.Web.UI.WebControls.Label Label16;
		//protected System.Web.UI.WebControls.Label Label17;
		//protected System.Web.UI.WebControls.TextBox txtCallDt;
		//protected System.Web.UI.WebControls.Label Label4;
		//protected System.Web.UI.WebControls.Label Label18;
		//protected System.Web.UI.WebControls.TextBox txtCallNO;
		//protected System.Web.UI.WebControls.Label Label2;
		//protected System.Web.UI.WebControls.TextBox txtDtMark;
		//protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		//protected System.Web.UI.WebControls.TextBox txtExpOfIns;
		//protected System.Web.UI.WebControls.Label Label9;
		//protected System.Web.UI.WebControls.DropDownList lstIE;
		//protected System.Web.UI.WebControls.Label Label7;
		//protected System.Web.UI.WebControls.Label Label8;
		//protected System.Web.UI.WebControls.Label Label23;
		//protected System.Web.UI.WebControls.TextBox txtDtOfCan;
		//protected System.Web.UI.WebControls.Label Label19;
		//protected System.Web.UI.WebControls.Label Label21;
		//protected System.Web.UI.WebControls.Label Label22;
		//protected System.Web.UI.WebControls.Label Label25;
		//protected System.Web.UI.WebControls.Label Label27;
		//protected System.Web.UI.WebControls.Label Label28;
		//protected System.Web.UI.WebControls.TextBox txtDtOfReciept;
		//protected System.Web.UI.WebControls.Label Label12;
		//protected System.Web.UI.WebControls.TextBox txtCInstallNo;
		//protected System.Web.UI.WebControls.Label Label30;
		//protected System.Web.UI.WebControls.DropDownList lstCallRStatus;
		int CD = 0;
		string ss, status;
		//protected System.Web.UI.WebControls.Label Label5;
		//protected System.Web.UI.WebControls.Label Label13;
		//protected System.Web.UI.WebControls.Label Label31;
		//protected System.Web.UI.WebControls.Label txtCallStatus;
		//protected System.Web.UI.WebControls.DropDownList ddlManufac;
		//protected System.Web.UI.WebControls.Button btnFCList;
		//protected System.Web.UI.WebControls.Label Label29;
		//protected System.Web.UI.WebControls.Button btnUManuf;
		//protected System.Web.UI.WebControls.Label lblCUpdateStatus;
		//protected System.Web.UI.WebControls.CheckBox chkManuf;
		//protected System.Web.UI.WebControls.Label Label32;
		//protected System.Web.UI.WebControls.TextBox txtRemarks;
		//protected System.Web.UI.WebControls.Label Label33;
		//protected System.Web.UI.WebControls.TextBox txtMEmail;
		//protected System.Web.UI.WebControls.Label lblIE;
		//protected Tittle.Controls.CustomDataGrid grdCDetails;
		//protected System.Web.UI.WebControls.Button btnDelete;
		int ecode = 0;
		void show1()
		{
			DataSet dsP4 = new DataSet();
			string str5 = "select (C.CONSIGNEE_CD||'-'||trim(C.CONSIGNEE_DESIG)||'/'||trim(C.CONSIGNEE_DEPT)||'/'||trim(C.CONSIGNEE_FIRM)) PURCHASER_CD, V.VEND_NAME VEND_CD, P.PO_NO, to_char(P.PO_DT,'dd/mm/yyyy') PO_DT from T13_PO_MASTER P,T06_CONSIGNEE C,T05_VENDOR V where P.PURCHASER_CD=C.CONSIGNEE_CD(+) and P.VEND_CD=V.VEND_CD and CASE_NO= '" + CNO + "' ";
			OracleDataAdapter da4 = new OracleDataAdapter(str5, conn1);
			OracleCommand myOracleCommand4 = new OracleCommand(str5, conn1);
			conn1.Open();
			da4.SelectCommand = myOracleCommand4;
			da4.Fill(dsP4, "Table");
			if (dsP4.Tables[0].Rows.Count == 0)
			{
				Label19.Visible = false;
				Label21.Visible = false;
				Label25.Visible = false;
				Label22.Visible = false;
			}
			else
			{
				Label19.Visible = true;
				Label21.Visible = true;
				Label25.Visible = true;
				Label22.Visible = true;
				Label19.Text = dsP4.Tables[0].Rows[0]["PURCHASER_CD"].ToString();
				Label21.Text = dsP4.Tables[0].Rows[0]["VEND_CD"].ToString();
				Label25.Text = dsP4.Tables[0].Rows[0]["PO_NO"].ToString();
				Label22.Text = dsP4.Tables[0].Rows[0]["PO_DT"].ToString();
			}
			//			txtPurchaser.Enabled=false;
			//			txtVendor.Enabled=false;
			//			txtPONO.Enabled =false;
			//			txtPODT.Enabled =false;
			conn1.Close();



		}

		void show()
		{
			try
			{
				string str1 = "SELECT 'Marked' Status,T18.ITEM_SRNO_PO ITEM_SRNO_PO,T18.ITEM_DESC_PO ITEM_DESC_PO ,T18.QTY_ORDERED,T18.CUM_QTY_PREV_OFFERED,T18.CUM_QTY_PREV_PASSED,T18.QTY_TO_INSP,T18.QTY_PASSED,T18.QTY_REJECTED,T18.QTY_DUE, (T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE  FROM T18_CALL_DETAILS T18,T06_CONSIGNEE T06, T03_CITY T03  where T18.CONSIGNEE_CD=T06.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD and T18.CASE_NO='" + CNO + "' AND T18.CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text;
				//str1=str1 + " union SELECT 'Available' Status,T15.ITEM_SRNO ITEM_SRNO_PO,T15.ITEM_DESC ITEM_DESC_PO,T15.QTY QTY_ORDERED,(null) CUM_QTY_PREV_OFFERED,(null) CUM_QTY_PREV_PASSED, (null) QTY_TO_INSP,(null) QTY_PASSED,(null) QTY_REJECTED,(null) QTY_DUE  FROM T15_PO_DETAIL T15  where T15.CASE_NO='"+CNO+"'"; 
				str1 = str1 + " union SELECT 'Available' Status,T15.ITEM_SRNO ITEM_SRNO_PO,T15.ITEM_DESC ITEM_DESC_PO,T15.QTY QTY_ORDERED,(0) CUM_QTY_PREV_OFFERED,(0) CUM_QTY_PREV_PASSED, (0) QTY_TO_INSP,(0) QTY_PASSED,(0) QTY_REJECTED,(0) QTY_DUE,(T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE FROM T15_PO_DETAIL T15,T06_CONSIGNEE T06,T03_CITY T03 where T15.CONSIGNEE_CD=T06.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD and T15.CASE_NO='" + CNO + "'";
				str1 = str1 + " and T15.ITEM_SRNO not in (select ITEM_SRNO_PO from T18_CALL_DETAILS  where CASE_NO='" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text + ") order by Status DESC, ITEM_SRNO_PO";
				//				string str1 = "select CASE_NO, to_char(CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_ORDERED,CUM_QTY_PREV_OFFERED,CUM_QTY_PREV_PASSED,QTY_TO_INSP,QTY_PASSED,QTY_REJECTED,QTY_DUE from T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy')"; 
				//string str1 = "select CASE_NO, TO_CHAR(CALL_RECV_DT,'dd/mm/yy') CALL_RECV_DT,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_INSP from T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT='"+ DT +"'"; 
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCDetails.Visible = false;
					Label24.Visible = false;
				}
				else
				{
					grdCDetails.Visible = true;
					Label24.Visible = true;
					grdCDetails.DataSource = dsP;
					grdCDetails.DataBind();
					conn1.Close();
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
			}


		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1();");



			if (Convert.ToString(Request.Params["Case_No"]) == null || Convert.ToString(Request.Params["DT_RECIEPT"]) == null)
			{
				CNO = "";
				DT = "";

			}
			else
			{
				CNO = Convert.ToString(Request.Params["Case_No"].Trim());
				DT = Convert.ToString(Request.Params["DT_RECIEPT"].Trim());
				Action = Convert.ToString(Request.Params["Action"]);
				//				CSNO=Convert.ToString(Request.Params ["CALL_SNO"].Trim());

			}

			if (!(IsPostBack))
			{

				try
				{
					if (Action == "A")
					{

						DataSet dsP2 = new DataSet();
						string str2 = "select to_char(C.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,C.CALL_SNO,I.IE_NAME from T17_CALL_REGISTER C, T09_IE I where C.IE_CD=I.IE_CD and CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy')";
						OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
						OracleCommand myCommand1 = new OracleCommand(str2, conn1);
						da2.SelectCommand = myCommand1;
						da2.Fill(dsP2, "Table");
						conn1.Close();
						if (dsP2.Tables[0].Rows.Count != 0)
						{
							//throw new System.Exception("The Record is Already Present for the Given Case No and Call Date and It is issued to IE="+dsP2.Tables[0].Rows[0]["IE_NAME"].ToString()+" vide Call Serial No.="+dsP2.Tables[0].Rows[0]["CALL_SNO"].ToString()+"and Call Mark Date="+dsP2.Tables[0].Rows[0]["CALL_MARK_DT"].ToString());
							string msg = "The Call Already Present for the Given Case No and Call Date -: \\n";
							for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
							{
								msg = msg + (i + 1) + ") Marked To: " + dsP2.Tables[0].Rows[i]["IE_NAME"].ToString() + " vide Call Serial No.=" + dsP2.Tables[0].Rows[i]["CALL_SNO"].ToString() + " and Call Mark Date=" + dsP2.Tables[0].Rows[i]["CALL_MARK_DT"].ToString() + ". \\n";
							}

							DisplayAlert1(msg);
							show1();
						}
						else
						{

							show1();
						}

						conn1.Open();
						OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
						string ss = Convert.ToString(cmd2.ExecuteScalar());
						conn1.Close();
						txtDtMark.Text = DT;
						txtExpOfIns.Text = DT;
						txtDtOfCan.Text = DT;
						txtDtMark.Enabled = false;
						txtDtOfCan.Enabled = false;
						fill_Region(CNO.Substring(0, 1).ToString());
						txtCallStatus.Text = "Marked";

					}

					txtCaseNo.Text = CNO;
					txtCaseNo.Visible = false;
					txtCaseNo.Enabled = false;
					Label27.Text = CNO;
					Label27.Visible = true;
					txtDtOfReciept.Text = DT;
					//txtDtOfReciept.Visible=false;
					//txtDtOfReciept.Enabled =false;
					Label28.Text = DT;
					Label28.Visible = true;
					//lstCallStatus.SelectedValue ="M";
					//lstCallStatus.Enabled =false;

					//txtCallSno.Enabled =false;
					Label29.Visible = false;
					//txtCallSno.Visible=false;

					DataSet dsP1 = new DataSet();
					string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + CNO.Substring(0, 1) + "' order by IE_NAME ";
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
					conn1.Close();
					lstIE.Items.Insert(0, "");



					ListItem lst = new ListItem();
					lst = new ListItem();
					lst.Text = "1st  Re-Mark";
					lst.Value = "1";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "2nd  Re-Mark";
					lst.Value = "2";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "3rd  Re-Mark";
					lst.Value = "3";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "4th  Re-Mark";
					lst.Value = "4";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "5th  Re-Mark";
					lst.Value = "5";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "6th  Re-Mark";
					lst.Value = "6";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "7th  Re-Mark";
					lst.Value = "7";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "8th  Re-Mark";
					lst.Value = "8";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "9th  Re-Mark";
					lst.Value = "9";
					lstCallRStatus.Items.Add(lst);
					lstCallRStatus.Items.Insert(0, "");

					//					
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					//					Response.Redirect("rbs/Error_Form.aspx?err="+str1); 
				}
				finally
				{
					conn1.Close();
				}

				if (Action == "M" || Action == "D")
				{


					try
					{
						CSNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
						show1();
						DataSet dsP1 = new DataSet();
						string str1 = "select CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,CALL_LETTER_NO,to_char(CALL_LETTER_DT,'dd/mm/yyyy')CALL_LETTER_DT,to_char(CALL_MARK_DT,'dd/mm/yyyy')CALL_MARK_DT,CALL_SNO,IE_CD,to_char(DT_INSP_DESIRE,'dd/mm/yyyy') DT_INSP_DESIRE,decode(CALL_STATUS,'M','Marked','C','Cancelled','A','Accepted','R','Rejected','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection')||decode(CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,to_char(CALL_STATUS_DT,'dd/mm/yyyy')CALL_STATUS_DT,CALL_REMARK_STATUS,CALL_INSTALL_NO,REGION_CODE,MFG_CD,MFG_PLACE,NVL(UPDATE_ALLOWED,'Y')UPDATE_ALLOWED,REMARKS from T17_CALL_REGISTER where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + CSNO;
						OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
						OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
						conn1.Open();
						da1.SelectCommand = myOracleCommand1;
						da1.Fill(dsP1, "Table");
						conn1.Close();
						if (dsP1.Tables[0].Rows.Count == 0)
						{
							throw new System.Exception("Record not found for the given Case No. and Call Recieve Date. !!! ");
							//DisplayAlert("Record not found for the given Case No. and Call Recieve Date. !!! ");
						}
						else
						{

							txtCaseNo.Text = dsP1.Tables[0].Rows[0]["CASE_NO"].ToString();
							txtCaseNo.Visible = false;
							Label27.Text = dsP1.Tables[0].Rows[0]["CASE_NO"].ToString();
							txtDtOfReciept.Text = dsP1.Tables[0].Rows[0]["CALL_RECV_DT"].ToString();
							//txtDtOfReciept.Visible=false;
							Label28.Text = dsP1.Tables[0].Rows[0]["CALL_RECV_DT"].ToString();
							txtCallNO.Text = dsP1.Tables[0].Rows[0]["CALL_LETTER_NO"].ToString();
							txtCallDt.Text = dsP1.Tables[0].Rows[0]["CALL_LETTER_DT"].ToString();
							txtDtMark.Text = dsP1.Tables[0].Rows[0]["CALL_MARK_DT"].ToString();
							//txtCallSno.Text=dsP1.Tables[0].Rows[0]["CALL_SNO"].ToString (); 
							Label29.Visible = true;
							Label29.Text = dsP1.Tables[0].Rows[0]["CALL_SNO"].ToString();
							try
							{
								lstIE.SelectedValue = dsP1.Tables[0].Rows[0]["IE_CD"].ToString();
								if (lstIE.SelectedValue != "")
								{
									IE_NAME(lstIE.SelectedValue);
								}

							}
							catch (Exception ex)
							{
								string str;
								str = ex.Message;
								string str2 = str.Substring(0, 56);
								if (str2.CompareTo("Specified argument was out of the range of valid values.") == 0)
								{
									IE_NAME(dsP1.Tables[0].Rows[0]["IE_CD"].ToString());
								}

							}
							txtExpOfIns.Text = dsP1.Tables[0].Rows[0]["DT_INSP_DESIRE"].ToString();
							//lstCallStatus.SelectedValue = dsP1.Tables[0].Rows[0]["CALL_STATUS"].ToString (); 
							txtCallStatus.Text = dsP1.Tables[0].Rows[0]["CALL_STATUS"].ToString();
							txtDtOfCan.Text = dsP1.Tables[0].Rows[0]["CALL_STATUS_DT"].ToString();
							lstCallRStatus.SelectedValue = dsP1.Tables[0].Rows[0]["CALL_REMARK_STATUS"].ToString();
							txtCInstallNo.Text = dsP1.Tables[0].Rows[0]["CALL_INSTALL_NO"].ToString();
							txtRemarks.Text = dsP1.Tables[0].Rows[0]["REMARKS"].ToString();
							txtMPOI.Text = dsP1.Tables[0].Rows[0]["MFG_PLACE"].ToString();
							lblCUpdateStatus.Text = dsP1.Tables[0].Rows[0]["UPDATE_ALLOWED"].ToString();
							fill_Region(dsP1.Tables[0].Rows[0]["REGION_CODE"].ToString());
							if (dsP1.Tables[0].Rows[0]["MFG_CD"].ToString() != "")
							{
								string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + dsP1.Tables[0].Rows[0]["MFG_CD"].ToString() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
								fill_manufacturer(str2);

								//fill_manufacturer(dsP1.Tables[0].Rows[0]["MFG_CD"].ToString ());
								ddlManufac.Visible = true;
								txtMName.Text = dsP1.Tables[0].Rows[0]["MFG_CD"].ToString();
								OracleCommand cmd = new OracleCommand("select VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1,VEND_EMAIL from T05_VENDOR where VEND_CD='" + ddlManufac.SelectedValue + "'", conn1);
								conn1.Open();
								OracleDataReader reader = cmd.ExecuteReader();
								while (reader.Read())
								{
									//txtMPOI.Text=Convert.ToString(reader["VEND_ADD1"]);
									txtMConPer.Text = Convert.ToString(reader["VEND_CONTACT_PER_1"]);
									txtMPNo.Text = Convert.ToString(reader["VEND_CONTACT_TEL_1"]);
									txtMEmail.Text = Convert.ToString(reader["VEND_EMAIL"]);
								}
								conn1.Close();

							}
							txtDtMark.Enabled = false;
							txtDtOfCan.Enabled = false;
						}
						if (Action == "M")
						{
							//if(txtCallStatus.Text=="Accepted" || txtCallStatus.Text=="Rejected" ||txtCallStatus.Text=="Cancelled")
							if (lblCUpdateStatus.Text == "N")
							{
								btnSave.Enabled = false;
								btnDelete.Enabled = false;
								status = "N";
							}
							else
							{
								btnSave.Enabled = true;
								btnSave.Visible = true;
								btnDelete.Enabled = true;
								btnDelete.Visible = true;
								status = "M";
							}
							//							btnDelete.Visible =false;
							//							btnCDetails.Visible =true;

							//							if(Session["Role_CD"].ToString()=="4")
							//							{
							//								btnSave.Visible=false;
							//								btnDelete.Visible=false;
							//								btnFCList.Visible=false;
							//								btnUManuf.Visible=false;
							//								
							//							}

						}
						//						else if(Action=="D")
						//						{
						//							//if(txtCallStatus.Text=="Accepted" || txtCallStatus.Text=="Rejected" ||txtCallStatus.Text=="Cancelled")
						//							if(lblCUpdateStatus.Text=="N")
						//							{
						//								btnDelete.Enabled=false;
						//								btnSave.Enabled=false;
						//								status="N";
						//							}
						//							else
						//							{
						//								btnDelete.Enabled=true;
						//								btnDelete.Visible=true;
						//								status="M";
						//								
						//							}
						//							btnSave.Visible =false;
						////							btnCDetails.Visible =true;
						//						}
						txtCaseNo.Enabled = false;
						conn1.Close();

					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						string str1 = str.Replace("\n", "");
						Response.Redirect(("rbs/Error_Form.aspx?err=" + str1));
					}
					finally
					{
						conn1.Close();
					}
					show();
				}
				else
					btnDelete.Visible = false;
			}

		}
		void IE_NAME(string ie_cd)
		{
			lstIE.Visible = false;
			string query1 = "Select IE_NAME,IE_STATUS from T09_IE where IE_CD=" + ie_cd;
			conn1.Open();
			OracleCommand Command1 = new OracleCommand(query1, conn1);
			OracleDataReader reader1 = Command1.ExecuteReader();
			lblIE.Visible = true;
			while (reader1.Read())
			{
				lblIE.Text = reader1["IE_NAME"].ToString();

				if (reader1["IE_STATUS"].ToString() == "L")
				{
					lblIE.Text = lblIE.Text + "(Status:Left)";
				}
				else if (reader1["IE_STATUS"].ToString() == "R")
				{
					lblIE.Text = lblIE.Text + "(Status:Retired)";
				}

			}
			conn1.Close();
			reader1.Close();
			if (lblIE.Text != "")
			{
				Label7.Visible = true;
			}
		}

		public void grdCDetails_Edit(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			btnSave.Visible = false;
			grdCDetails.EditItemIndex = e.Item.ItemIndex;
			show();

		}

		public void grdCDetails_Cancel(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			btnSave.Visible = true;
			grdCDetails.EditItemIndex = -1;
			show();
		}

		public void grdCDetails_Update(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			decimal isrno = Convert.ToDecimal(e.Item.Cells[2].Text);
			decimal qoff = 0;
			if ((e.Item.FindControl("txtQTYOFFNOW") as TextBox).Text.Trim() != "")
			{
				qoff = Convert.ToDecimal((e.Item.FindControl("txtQTYOFFNOW") as TextBox).Text.Trim());

			}
			conn1.Open();
			OracleCommand cmd1 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd1.ExecuteScalar());

			OracleCommand cmd2 = new OracleCommand("Select NVL(CASE_NO,'X') from T18_CALL_DETAILS where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + Label28.Text + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text.Trim() + " AND ITEM_SRNO_PO=" + isrno, conn1);
			string itemstatus = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			if (itemstatus == "")
			{

				string str = "Select CONSIGNEE_CD from T15_PO_DETAIL WHERE CASE_NO='" + txtCaseNo.Text + "' AND ITEM_SRNO=" + isrno;
				OracleCommand cmd = new OracleCommand(str, conn1);
				conn1.Open();
				long ccd = Convert.ToInt64(cmd.ExecuteScalar());
				//string myInsertQuery = "INSERT INTO T18_CALL_DETAILS values('" + txtCaseNo.Text + "', to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy')," + txtSerialNo.Text + ", '" + txtIDesc.Text  + "'," + txtQOrd.Text + "," + txtCQty.Text + "," + txtQPrePassed.Text + "," + txtQuanInsp.Text + ","+txtQPass.Text +","+txtQRej.Text +","+ txtQtyDue.Text +",'"+Session["Uname"]+"', to_date('" +ss+ "','dd/mm/yyyy-HH:MI:SS'))"; 
				string myInsertQuery = "INSERT INTO T18_CALL_DETAILS values('" + txtCaseNo.Text + "', to_date('" + Label28.Text + "','dd/mm/yyyy')," + Label29.Text + "," + isrno + ", upper('" + Convert.ToString(e.Item.Cells[4].Text) + "')," + ccd + "," + Convert.ToDecimal(e.Item.Cells[6].Text) + "," + Convert.ToDecimal(e.Item.Cells[7].Text) + "," + Convert.ToDecimal(e.Item.Cells[8].Text) + "," + qoff + ",'" + null + "','" + null + "','" + null + "','" + Session["VEND_CD"] + "', to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS'))";
				OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
				myInsertCommand.Connection = conn1;
				myInsertCommand.ExecuteNonQuery();
				conn1.Close();

			}
			else
			{
				string myUpdateQuery = "Update T18_CALL_DETAILS set QTY_TO_INSP=" + qoff + " where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + Label28.Text + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text.Trim() + " and ITEM_SRNO_PO=" + isrno;
				OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
				myUpdateCommand.Connection = conn1;
				conn1.Open();
				myUpdateCommand.ExecuteNonQuery();
				conn1.Close();
			}
			grdCDetails.EditItemIndex = -1;
			show();
			btnSave.Visible = true;
		}

		public void fill_Region(string reg)
		{
			try
			{
				if (reg == "N")
				{
					Label31.Text = "Northern";
				}
				else if (reg == "S")
				{
					Label31.Text = "Southern";
				}
				else if (reg == "E")
				{
					Label31.Text = "Eastern";
				}
				else if (reg == "W")
				{
					Label31.Text = "Western";
				}
				else if (reg == "C")
				{
					Label31.Text = "Central";
				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("rbs/Error_Form.aspx?err=" + str1));
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
			this.chkManuf.CheckedChanged += new System.EventHandler(this.chkManuf_CheckedChanged);
			this.btnFCList.Click += new System.EventHandler(this.btnFCList_Click);
			this.ddlManufac.SelectedIndexChanged += new System.EventHandler(this.ddlManufac_SelectedIndexChanged);
			this.btnUManuf.Click += new System.EventHandler(this.btnUManuf_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.grdCDetails.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grdCDetails_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				//if(lstCallRStatus.SelectedValue=="")
				if (ddlManufac.Visible == false)
				{
					DisplayAlert("Plz select Manufacturer first and then save it");
				}
				else
				{
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH:MI:SS') from dual", conn1);
					ss = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();
					if (Action == "A")
					{
						conn1.Open();

						OracleCommand cmdCL = new OracleCommand("Select NVL(count(*),0) COUNT from T17_CALL_REGISTER where CASE_NO= '" + Label27.Text.Trim() + "' and CALL_LETTER_NO=trim(upper('" + txtCallNO.Text + "')) and REGION_CODE='" + CNO.Substring(0, 1) + "'", conn1);
						int CL = Convert.ToInt32(cmdCL.ExecuteScalar());
						if (CL == 0)
						{
							string str3 = "select NVL(max(CALL_SNO),0)CALL_SNO from T17_CALL_REGISTER where CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and REGION_CODE='" + CNO.Substring(0, 1) + "'";
							OracleCommand myCommand = new OracleCommand();
							myCommand.CommandText = str3;
							myCommand.Connection = conn1;
							CD = Convert.ToInt32(myCommand.ExecuteScalar());
							CD = (CD + 1);

							//							if(txtCInstallNo.Text=="")
							//							{
							//								txtCInstallNo.Text="null";
							//							}
							string myInsertQuery = "INSERT INTO T17_CALL_REGISTER(CASE_NO, CALL_RECV_DT, CALL_SNO, CALL_LETTER_NO, CALL_LETTER_DT,CALL_MARK_DT, IE_CD, DT_INSP_DESIRE, CALL_STATUS, CALL_STATUS_DT, CALL_REMARK_STATUS,CALL_INSTALL_NO, REGION_CODE, MFG_CD, USER_ID, DATETIME,MFG_PLACE,REMARKS) values('" + txtCaseNo.Text.Trim() + "', to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')," + CD + ",trim(upper('" + txtCallNO.Text + "')),to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),to_date('" + txtDtMark.Text + "','dd/mm/yyyy'), null,to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy') ,'M',to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),'" + lstCallRStatus.SelectedValue + "','" + txtCInstallNo.Text + "',upper('" + txtCaseNo.Text.Substring(0, 1) + "'),'" + ddlManufac.SelectedValue + "','" + Session["VEND_CD"] + "', to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS'),'" + txtMPOI.Text + "','" + txtRemarks.Text + "')";
							OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
							myInsertCommand.Connection = conn1;
							myInsertCommand.ExecuteNonQuery();
							conn1.Close();
							DisplayAlert("Your Record Has Been Saved!!!");
							//txtCallSno.Visible=false;
							Label29.Text = CD.ToString();
							Label29.Visible = true;
							btnSave.Visible = false;
							show();
							//btnSave.Enabled=false;

							//						string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Saved and Your Call Serial No is" + CD + "' , 'CustomPopUp', " + "'width=330, height=120, menubar=no, resizable=no')" + "</script>";
							//						Page.RegisterStartupScript("PopupScript", popupScript);
						}
						else
						{
							DisplayAlert("The Call Letter No. is already present for this Case No.");
						}
					}
					else if (Action == "M")
					{
						string Ucode = txtCaseNo.Text;
						//							if(txtCInstallNo.Text=="")
						//							{
						//								txtCInstallNo.Text="null";
						//							}
						string myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('" + txtCallNO.Text + "')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='" + lstCallRStatus.SelectedValue + "',CALL_INSTALL_NO='" + txtCInstallNo.Text + "',REMARKS='" + txtRemarks.Text + "',MFG_CD='" + ddlManufac.SelectedValue + "',MFG_PLACE='" + txtMPOI.Text + "',USER_ID='" + Session["VEND_CD"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS') where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
						myUpdateCommand.Connection = conn1;
						conn1.Open();
						myUpdateCommand.ExecuteNonQuery();
						CD = Convert.ToInt32(Label29.Text);
						conn1.Close();
						DisplayAlert("Your Record Has Been Saved!!!");

					}
					//						btnCDetails.Visible =true;
					//if(txtCallStatus.Text=="Accepted" || txtCallStatus.Text=="Rejected" ||txtCallStatus.Text=="Cancelled")
					if (lblCUpdateStatus.Text == "N")
					{
						btnSave.Enabled = false;
						btnDelete.Enabled = false;

					}
					else
					{
						btnSave.Enabled = true;
					}
				}
				//					send_IE_Email();
				send_Vendor_Email();
			}
			catch (OracleException ex)
			{
				string str;
				str = ex.Message;
				if (ex.ErrorCode == 00001)
				{
					DisplayAlert("This Call is already registered. so go back and use modify to update it");
				}
				else
				{
					string str1 = str.Replace("\n", "");
					Response.Redirect(("rbs/Error_Form.aspx?err=" + str1));
				}
			}
			finally
			{
				conn1.Close();
			}
			//Response.Redirect("Call_Register_Edit.aspx");

		}

		void send_Vendor_Email()
		{
			try
			{
				string wRegion = "";
				if (CNO.Substring(0, 1).ToString() == "N") { wRegion = "NORTHERN REGION \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : 011-22029110/011-22029101 \n Fax : 011-22024665"; }
				else if (CNO.Substring(0, 1).ToString() == "S") { wRegion = "SOUTHERN REGION \n 758 ANNA SALAI [MOUNT CHAMBER], CHENNAI - 600 002 \n Phone : 044-28523364/044-28524128 \n Fax : 044-28525408"; }
				else if (CNO.Substring(0, 1).ToString() == "E") { wRegion = "EASTERN REGION \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; }
				else if (CNO.Substring(0, 1).ToString() == "W") { wRegion = "WESTERN REGION \n CHURCHGATE STATION BLDG., 2nd FLOOR, M.K ROAD,MUMBAI-400 020 \n Phone : 022-22012523/022-22015573 \n Fax : 022-22081455/022-22016220"; }
				else if (CNO.Substring(0, 1).ToString() == "C") { wRegion = "Central Region"; }

				OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1)||'/'||T03.CITY VEND_ADDRESS, T05.VEND_EMAIL from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + Label27.Text.Trim() + "'", conn1);
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

				OracleCommand cmd = new OracleCommand("Select VEND_EMAIL from T05_VENDOR where VEND_CD=" + ddlManufac.SelectedValue, conn1);
				conn1.Open();
				string manu_mail = Convert.ToString(cmd.ExecuteScalar());
				conn1.Close();

				OracleCommand cmd1 = new OracleCommand("Select IE_PHONE_NO from T09_IE where IE_CD=" + lstIE.SelectedValue, conn1);
				conn1.Open();
				string ie_phone = Convert.ToString(cmd1.ExecuteScalar());
				conn1.Close();
				string mail_body = "Dear Sir/Madam,\n\n In Reference to your Call dated  " + txtCallDt.Text + " for inspection of material against PO No. - " + Label25.Text + " & date - " + Label22.Text + ", call has been registered vide Case No -  " + Label27.Text + ". " + lstIE.SelectedItem.Text + ", Contact No. " + ie_phone + " has been assigned the inspection task.\n For any correspondence in future, please quote Case No. only. \n\n Thanks for using RITES Inspection Services. \n\n" + wRegion + ".";
				string sender = "";
				if (CNO.Substring(0, 1).ToString() == "N")
				{
					sender = "nrinspn@rites.com";
				}
				else if (CNO.Substring(0, 1).ToString() == "W")
				{
					sender = "wrinspn@rites.com";
				}
				else if (CNO.Substring(0, 1).ToString() == "E")
				{
					sender = "erinspn@rites.com";
				}
				else if (CNO.Substring(0, 1).ToString() == "S")
				{
					sender = "srinspn@rites.com";
				}
				if (vend_cd == ddlManufac.SelectedValue && manu_mail != "")
				{
                    System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
					mail.To = manu_mail;
					mail.From = sender;
					mail.Subject = "Your Call for Inspection By RITES";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = System.Web.Mail.MailPriority.High;
					SmtpMail.Send(mail);
				}
				else if (vend_cd != ddlManufac.SelectedValue)
				{

					if (vend_email != "")
					{
                        System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
						mail.To = vend_email;
						mail.From = sender;
						mail.Subject = "Your Call for Inspection By RITES";
						mail.Body = mail_body;
						mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
						SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
						mail.Priority = System.Web.Mail.MailPriority.High;
						SmtpMail.Send(mail);

					}
					else if (manu_mail != "")
					{
                        System.Web.Mail.MailMessage mail1 = new System.Web.Mail.MailMessage();
						mail1.To = manu_mail;
						mail1.From = sender;
						mail1.Subject = "Your Call for Inspection By RITES";
						mail1.Body = mail_body;
						mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
						SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
						mail1.Priority = System.Web.Mail.MailPriority.High;
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


		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			//			OracleCommand cmdcall=new OracleCommand("select nvl(count(CASE_NO),0) from T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') AND CALL_SNO="+Label29.Text,conn1);
			//			conn1.Open();
			//			int delstatus=Convert.ToInt16(cmdcall.ExecuteScalar());
			//			conn1.Close();
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();

			try
			{


				//				if(delstatus==0)
				//				{
				//				string myDeleteQuery4 = "Delete T21_IC_DATES where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy')"; 
				//				OracleCommand myOracleCommand4 = new OracleCommand(myDeleteQuery4); 
				//				myOracleCommand4.Transaction=myTrans;
				//				myOracleCommand4.Connection = conn1; 
				//				myOracleCommand4.ExecuteNonQuery(); 

				//					string myDeleteQuery3 = "Delete T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy')"; 
				//					OracleCommand myOracleCommand3 = new OracleCommand(myDeleteQuery3); 
				//					myOracleCommand3.Transaction=myTrans;
				//					myOracleCommand3.Connection = conn1; 
				//					myOracleCommand3.ExecuteNonQuery(); 
				//							
				//					string myDeleteQuery2 = "Delete T19_CALL_CANCEL where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') AND CALL_SNO="+Label29.Text; 
				//					OracleCommand myOracleCommand2 = new OracleCommand(myDeleteQuery2); 
				//					myOracleCommand2.Transaction=myTrans;
				//					myOracleCommand2.Connection = conn1; 
				//					myOracleCommand2.ExecuteNonQuery(); 
				//				
				//
				//					string myDeleteQuery1 = "Delete T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') AND CALL_SNO="+Label29.Text; 
				//					OracleCommand myOracleCommand1 = new OracleCommand(myDeleteQuery1); 
				//					myOracleCommand1.Transaction=myTrans;
				//					myOracleCommand1.Connection = conn1; 
				//					myOracleCommand1.ExecuteNonQuery(); 

				string myDeleteQuery = "Delete T17_CALL_REGISTER where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text;
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Transaction = myTrans;
				myOracleCommand.Connection = conn1;
				myOracleCommand.ExecuteNonQuery();

				myTrans.Commit();

				conn1.Close();
				DisplayAlert("Your Record Has Been Deleted!!!");
				//				}
				//				else
				//				{
				//					DisplayAlert("This Call cannot be deleted. because IC is present for this call!!!");
				//				}

				//string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Deleted!!!', 'CustomPopUp', " + "'width=330, height=100, menubar=no, resizable=no')" + "</script>";
				//Page.RegisterStartupScript("PopupScript", popupScript);


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
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Vendor_Call_Register_Edit.aspx");
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void DisplayAlert1(string msg)
		{
			msg = msg + " Do You Still Want to Register This Call?";
			Response.Write("<script language=JavaScript> var d=confirm('" + msg + "'); if(d==false) location.href='/RBS/Call_Register_Edit.aspx';</script>");
		}


		private void btnCDetails_Click(object sender, System.EventArgs e)
		{
			string code = txtCaseNo.Text;
			string dt = txtDtOfReciept.Text;
			string cs = Label29.Text;
			if (btnSave.Enabled == true || btnDelete.Enabled == true)
			{
				status = "M";
			}
			else
			{
				status = "N";
			}
			Response.Redirect("Vendor_Call_Details_Form.aspx?Case_No=" + code + "&DT_RECIEPT=" + dt + "&CALL_SNO=" + cs + "&cstatus=" + status);
		}

		int fill_manufacturer(string str1)
		{
			ddlManufac.Items.Clear();
			DataSet dsP = new DataSet();
			//string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME,VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1 from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and (trim(upper(VEND_CD))=upper('"+vend.Trim()+"') or trim(upper(VEND_NAME)) LIKE upper('"+vend.Trim()+"%')) and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME"; 
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
					ddlManufac.Items.Add(lst);
				}
				ddlManufac.Visible = true;
				ddlManufac.SelectedIndex = 0;
				//rbs.SetFocus(ddlManufac);
				ecode = 2;
				return (ecode);

			}

		}

		private void btnFCList_Click(object sender, System.EventArgs e)
		{
			ddlManufac.Visible = true;

			try
			{
				if (Convert.ToInt32(txtMName.Text) >= 1 && Convert.ToInt32(txtMName.Text) <= 999999)
				{

					string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + txtMName.Text.Trim() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_manufacturer(str1);
					if (a == 1)
					{
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						txtMConPer.Text = "";
						txtMPNo.Text = "";
						txtMEmail.Text = "";
						btnUManuf.Enabled = false;
						DisplayAlert("No Manufacturer Found!!!");
						rbs.SetFocus(txtMPOI);
					}
					else if (a == 2)
					{
						txtMName.Text = ddlManufac.SelectedValue;
						manufac_details();
						rbs.SetFocus(ddlManufac);
					}
				}
				else
				{
					DisplayAlert("Invalid Manufacturer Code!!!");
					ddlManufac.Items.Clear();
					ddlManufac.Visible = false;
					txtMPOI.Text = "";
					txtMConPer.Text = "";
					txtMEmail.Text = "";
					txtMPNo.Text = "";
					btnUManuf.Enabled = false;


				}



			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "Input string was not in a correct format.";
				if (str.Equals(str1))
				{
					string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(upper(VEND_NAME)) LIKE upper('" + txtMName.Text.Trim() + "%') and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_manufacturer(str2);
					if (a == 1)
					{
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						txtMConPer.Text = "";
						txtMPNo.Text = "";
						txtMEmail.Text = "";
						btnUManuf.Enabled = false;
						DisplayAlert("No Manufacturer Found!!!");
						rbs.SetFocus(txtMPOI);
					}
					else if (a == 2)
					{
						txtMName.Text = ddlManufac.SelectedValue;
						manufac_details();
						rbs.SetFocus(ddlManufac);


					}
				}
				else
				{
					string str2 = str.Replace("\n", "");
					Response.Redirect("rbs/Error_Form.aspx?err=" + str2);
				}

			}
			finally
			{
				conn1.Close();
			}
		}

		private void ddlManufac_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtMName.Text = ddlManufac.SelectedValue;
			manufac_details();
			rbs.SetFocus(txtMPOI);
		}


		void manufac_details()
		{

			OracleCommand cmd = new OracleCommand("select VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1,VEND_STATUS,to_char(VEND_STATUS_DT_FR,'dd/mm/yyyy')VEND_STATUS_FR,to_char(VEND_STATUS_DT_TO,'dd/mm/yyyy')VEND_STATUS_TO,VEND_EMAIL from T05_VENDOR where VEND_CD=" + ddlManufac.SelectedValue, conn1);
			conn1.Open();
			OracleDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows == true)
			{
				while (reader.Read())
				{
					if (Convert.ToString(reader["VEND_STATUS"]) == "B")
					{
						DisplayAlert("This Manufacturer is Blaclisted From:" + Convert.ToString(reader["VEND_STATUS_FR"]) + " TO: " + Convert.ToString(reader["VEND_STATUS_TO"]));
						txtMName.Text = "";
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						txtMConPer.Text = "";
						txtMPNo.Text = "";
						txtMEmail.Text = "";
						btnUManuf.Enabled = false;
					}
					else
					{
						txtMPOI.Text = Convert.ToString(reader["VEND_ADD1"]);
						txtMConPer.Text = Convert.ToString(reader["VEND_CONTACT_PER_1"]);
						txtMPNo.Text = Convert.ToString(reader["VEND_CONTACT_TEL_1"]);
						txtMEmail.Text = Convert.ToString(reader["VEND_EMAIL"]);
						btnUManuf.Enabled = true;
					}

				}
			}
			else
			{
				txtMPOI.Text = "";
				txtMConPer.Text = "";
				txtMPNo.Text = "";
				txtMEmail.Text = "";
				btnUManuf.Enabled = false;
			}
			conn1.Close();
		}

		private void btnUManuf_Click(object sender, System.EventArgs e)
		{
			OracleCommand cmd = new OracleCommand("update T05_VENDOR set VEND_CONTACT_PER_1='" + txtMConPer.Text + "',VEND_CONTACT_TEL_1='" + txtMPNo.Text + "',VEND_EMAIL='" + txtMEmail.Text.Trim() + "' where VEND_CD=" + txtMName.Text, conn1);
			conn1.Open();
			cmd.ExecuteNonQuery();
			DisplayAlert("This Manufacturer details has been updated!!!");
			conn1.Close();
		}

		private void chkManuf_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkManuf.Checked == true)
			{
				try
				{
					OracleCommand cmd = new OracleCommand("select T13.VEND_CD from T13_PO_MASTER T13, T05_VENDOR T05 where T13.VEND_CD=T05.VEND_CD and CASE_NO='" + Label27.Text.Trim() + "'", conn1);
					conn1.Open();
					int vcode = Convert.ToInt32(cmd.ExecuteScalar());
					conn1.Close();

					if (Convert.ToInt32(vcode) >= 1 && Convert.ToInt32(vcode) <= 999999)
					{

						string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + vcode + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
						int a = fill_manufacturer(str1);
						if (a == 1)
						{
							ddlManufac.Visible = false;
							txtMPOI.Text = "";
							txtMConPer.Text = "";
							txtMPNo.Text = "";
							txtMEmail.Text = "";
							btnUManuf.Enabled = false;
							DisplayAlert("No Manufacturer Found!!!");
							rbs.SetFocus(txtMPOI);
						}
						else if (a == 2)
						{
							txtMName.Text = ddlManufac.SelectedValue;
							manufac_details();
							rbs.SetFocus(ddlManufac);
						}
					}
					else
					{
						DisplayAlert("Invalid Manufacturer Code!!!");
						ddlManufac.Items.Clear();
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						txtMConPer.Text = "";
						txtMPNo.Text = "";
						txtMEmail.Text = "";
						btnUManuf.Enabled = false;


					}
					txtMName.Enabled = false;
					ddlManufac.Enabled = false;
					btnFCList.Visible = false;



				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					Response.Redirect(("rbs/Error_Form.aspx?err=" + str1));
				}
				finally
				{
					conn1.Close();
				}
			}
			else
			{
				btnFCList.Visible = true;
				txtMName.Enabled = true;
				txtMName.Text = "";
				ddlManufac.Items.Clear();
				ddlManufac.Visible = false;
				txtMPOI.Text = "";
				txtMConPer.Text = "";
				txtMPNo.Text = "";
				txtMEmail.Text = "";
				btnUManuf.Enabled = false;

			}
		}

		private void grdCDetails_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if (Convert.ToString(e.Item.Cells[3].Text) != "Available")
				{
					decimal isrno = Convert.ToDecimal(e.Item.Cells[2].Text);
					string myDeleteQuery = "Delete T18_CALL_DETAILS where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text + " and ITEM_SRNO_PO=" + isrno;
					OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
					myOracleCommand.Connection = conn1;
					conn1.Open();
					myOracleCommand.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("Your Item is UnMarked!!!");
				}
				else
				{
					DisplayAlert("Your Item is Already Available!!!");

				}

			}

			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
			finally
			{
				conn1.Close();
			}
			show();
		}







	}
}
