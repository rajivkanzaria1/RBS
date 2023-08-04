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

namespace RBS.Call_Register_Form
{
	public partial class Call_Register_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		string CNO, DT, Action, CSNO;
		int CD = 0;
		string ss, status;
		int ecode = 0;
		void show1()
		{
			DataSet dsP4 = new DataSet();
			string str5 = "select (C.CONSIGNEE_CD||'-'||trim(C.CONSIGNEE_DESIG)||'/'||trim(C.CONSIGNEE_DEPT)||'/'||trim(C.CONSIGNEE_FIRM)) PURCHASER_CD, V.VEND_NAME VEND_CD, P.PO_NO, to_char(P.PO_DT,'dd/mm/yyyy') PO_DT,substr(P.RLY_CD,1,7)RLY, P.L5NO_PO,P.RLY_NONRLY from T13_PO_MASTER P,T06_CONSIGNEE C,T05_VENDOR V where P.PURCHASER_CD=C.CONSIGNEE_CD(+) and P.VEND_CD=V.VEND_CD and CASE_NO= '" + CNO + "' ";
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
				lblL5noPo.Text = dsP4.Tables[0].Rows[0]["L5NO_PO"].ToString();
				lblRly.Text = dsP4.Tables[0].Rows[0]["RLY"].ToString();
				lblRLYNONRLY.Text = dsP4.Tables[0].Rows[0]["RLY_NONRLY"].ToString();
			}
			conn1.Close();
		}
		protected void Page_Load(object sender, System.EventArgs e)
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
			}

			if (!(IsPostBack))
			{

				try
				{
					ddlDept.Items.Insert(0, new ListItem("-Select Departmentlist item-", ""));
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

					if (Action == "A")
					{
						DataSet dsP2 = new DataSet();
						string str2 = "select to_char(C.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,C.CALL_SNO,NVL(I.IE_NAME,'NIL')IE_NAME from T17_CALL_REGISTER C, T09_IE I where C.IE_CD=I.IE_CD(+) and CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy')";
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

						btnCDetails.Visible = false;
						conn1.Open();
						OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
						string ss = Convert.ToString(cmd2.ExecuteScalar());
						conn1.Close();
						txtDtMark.Text = DT;
						txtExpOfIns.Text = DT;
						txtDtOfCan.Text = DT;
						txtDtMark.Enabled = false;
						txtDtOfCan.Enabled = false;
						fill_Region(Session["Region"].ToString());
						txtCallStatus.Text = "Marked";

					}

					txtCaseNo.Text = CNO;
					txtCaseNo.Visible = false;
					txtCaseNo.Enabled = false;
					Label27.Text = CNO;
					Label27.Visible = true;
					txtDtOfReciept.Text = DT;
					Label28.Text = DT;
					Label28.Visible = true;
					Label29.Visible = false;

					DataSet dsP1 = new DataSet();
					//string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='"+Session["REGION"]+"' order by IE_NAME "; 
					string str3 = "select (t99.cluster_name||' ('||t09.ie_name||')') CLUSTER_NAME, t09.IE_CD,t99.CLUSTER_CODE  from t99_cluster_master t99,t101_ie_Cluster t101,t09_ie t09 where t99.cluster_code= t101.cluster_code" +
						" and t101.ie_code= t09.ie_cd and t99.REGION_CODE='" + Session["REGION"] + "' and t09.ie_status is null order by t99.cluster_name,T09.ie_name";
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
					if (lblRLYNONRLY.Text == "R")
					{
						lblIRFC.Visible = true;
						ddlIRFC.Visible = true;
					}
					else
					{
						lblIRFC.Visible = false;
						ddlIRFC.Visible = false;
					}
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
				}


				if (Action == "M" || Action == "D")
				{

					try
					{
						CSNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
						show1();
						if (lblRLYNONRLY.Text == "R")
						{
							lblIRFC.Visible = true;
							ddlIRFC.Visible = true;
						}
						else
						{
							lblIRFC.Visible = false;
							ddlIRFC.Visible = false;
						}
						DataSet dsP1 = new DataSet();
						//						string str1 = "select CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,CALL_LETTER_NO,to_char(CALL_LETTER_DT,'dd/mm/yyyy')CALL_LETTER_DT,to_char(CALL_MARK_DT,'dd/mm/yyyy')CALL_MARK_DT,CALL_SNO,IE_CD,to_char(DT_INSP_DESIRE,'dd/mm/yyyy') DT_INSP_DESIRE,decode(CALL_STATUS,'M','Marked','C','Cancelled','A','Accepted','R','Rejected','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection')||decode(CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,to_char(CALL_STATUS_DT,'dd/mm/yyyy')CALL_STATUS_DT,CALL_REMARK_STATUS,CALL_INSTALL_NO,REGION_CODE,MFG_CD,MFG_PLACE,NVL(UPDATE_ALLOWED,'Y')UPDATE_ALLOWED,REMARKS from T17_CALL_REGISTER where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and CALL_SNO="+CSNO; 
						string str1 = "select T17.CASE_NO CASE_NO,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,T17.CALL_LETTER_NO CALL_LETTER_NO,to_char(T17.CALL_LETTER_DT,'dd/mm/yyyy')CALL_LETTER_DT,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy')CALL_MARK_DT,T17.CALL_SNO CALL_SNO,T17.IE_CD IE_CD,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy') DT_INSP_DESIRE,T21.CALL_STATUS_DESC||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy')CALL_STATUS_DT,T17.CALL_REMARK_STATUS CALL_REMARK_STATUS,T17.CALL_INSTALL_NO CALL_INSTALL_NO,T17.REGION_CODE REGION_CODE,T17.MFG_CD MFG_CD,T17.MFG_PLACE MFG_PLACE,NVL(T17.UPDATE_ALLOWED,'Y')UPDATE_ALLOWED,T17.REMARKS REMARKS, T17.REJ_CAN_CALL, FINAL_OR_STAGE,NVL(NEW_VENDOR,'X') NEW_VENDOR,NVL(COUNT_DT,0) COUNT_DT,IRFC_FUNDED, DEPARTMENT_CODE,CLUSTER_CODE from T17_CALL_REGISTER T17, T21_CALL_STATUS_CODES T21 where T17.CALL_STATUS=T21.CALL_STATUS_CD and T17.CASE_NO= '" + CNO + "' and T17.CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and T17.CALL_SNO=" + CSNO;
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
							ddlDept.SelectedValue = dsP1.Tables[0].Rows[0]["DEPARTMENT_CODE"].ToString();
							try
							{
								lblEIE.Text = dsP1.Tables[0].Rows[0]["IE_CD"].ToString();
								lblIE_CD.Text = dsP1.Tables[0].Rows[0]["IE_CD"].ToString();
								//								if(dsP1.Tables[0].Rows[0]["CLUSTER_CODE"].ToString()==null || dsP1.Tables[0].Rows[0]["CLUSTER_CODE"].ToString()=="")
								//								{
								OracleCommand cmd2 = new OracleCommand("select CLUSTER_CODE from T101_IE_CLUSTER where IE_CODE=" + dsP1.Tables[0].Rows[0]["IE_CD"].ToString() + "  and DEPARTMENT_CODE='" + dsP1.Tables[0].Rows[0]["DEPARTMENT_CODE"].ToString() + "'", conn1);
								conn1.Open();
								lstIE.SelectedValue = Convert.ToString(cmd2.ExecuteScalar());
								conn1.Close();
								//								}
								//								else
								//								{
								//									lstIE.SelectedValue =dsP1.Tables[0].Rows[0]["CLUSTER_CODE"].ToString (); 
								//								}

							}
							catch (Exception ex)
							{
								string str;
								str = ex.Message;
								string str2 = str.Substring(0, 56);
								if (str2.CompareTo("Specified argument was out of the range of valid values.") == 0)
								{
									lstIE.Visible = false;
									string query1 = "Select IE_NAME,IE_STATUS from T09_IE where IE_CD=" + dsP1.Tables[0].Rows[0]["IE_CD"].ToString();
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
								}

							}
							//Added Kamta 28012020 start//
							if (Convert.ToInt16(dsP1.Tables[0].Rows[0]["COUNT_DT"]) > 0)
							{
								txtExpOfIns.Text = dsP1.Tables[0].Rows[0]["DT_INSP_DESIRE"].ToString();
								txtExpOfIns.Enabled = false;
								Label_des_dt.Text = dsP1.Tables[0].Rows[0]["DT_INSP_DESIRE"].ToString();
							}
							else
							{
								txtExpOfIns.Text = dsP1.Tables[0].Rows[0]["DT_INSP_DESIRE"].ToString();
								txtExpOfIns.Enabled = true;
								Label_des_dt.Text = dsP1.Tables[0].Rows[0]["DT_INSP_DESIRE"].ToString();
							}
							//End Kamta 28012020//
							//lstCallStatus.SelectedValue = dsP1.Tables[0].Rows[0]["CALL_STATUS"].ToString (); 
							txtCallStatus.Text = dsP1.Tables[0].Rows[0]["CALL_STATUS"].ToString();
							txtDtOfCan.Text = dsP1.Tables[0].Rows[0]["CALL_STATUS_DT"].ToString();
							lstCallRStatus.SelectedValue = dsP1.Tables[0].Rows[0]["CALL_REMARK_STATUS"].ToString();
							txtCInstallNo.Text = dsP1.Tables[0].Rows[0]["CALL_INSTALL_NO"].ToString();
							txtRemarks.Text = dsP1.Tables[0].Rows[0]["REMARKS"].ToString();
							txtMPOI.Text = dsP1.Tables[0].Rows[0]["MFG_PLACE"].ToString();
							lblCUpdateStatus.Text = dsP1.Tables[0].Rows[0]["UPDATE_ALLOWED"].ToString();

							if (dsP1.Tables[0].Rows[0]["REJ_CAN_CALL"].ToString() == "Y")
							{
								CHKRejCan.Checked = true;
							}
							CHKRejCan.Enabled = false;
							if (dsP1.Tables[0].Rows[0]["NEW_VENDOR"].ToString() == "Y")
							{
								chkNewVendor.Checked = true;
							}
							chkNewVendor.Enabled = false;
							if (dsP1.Tables[0].Rows[0]["FINAL_OR_STAGE"].ToString() == "S")
							{
								rdbStage.Checked = true;
							}
							else
							{
								rdbFinal.Checked = true;
							}


							if (dsP1.Tables[0].Rows[0]["IRFC_FUNDED"].ToString() == "Y")
							{
								ddlIRFC.SelectedValue = "Y";

							}
							else
							{
								ddlIRFC.SelectedValue = "N";
							}
							ddlIRFC.Enabled = false;

							rdbStage.Enabled = false;
							rdbFinal.Enabled = false;
							fill_Region(dsP1.Tables[0].Rows[0]["REGION_CODE"].ToString());
							if (dsP1.Tables[0].Rows[0]["MFG_CD"].ToString() != "")
							{
								string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + dsP1.Tables[0].Rows[0]["MFG_CD"].ToString() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
								fill_manufacturer(str2);

								//fill_manufacturer(dsP1.Tables[0].Rows[0]["MFG_CD"].ToString ());
								ddlManufac.Visible = true;
								txtMName.Text = dsP1.Tables[0].Rows[0]["MFG_CD"].ToString();
								lblMFG_CD.Text = dsP1.Tables[0].Rows[0]["MFG_CD"].ToString();
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
								status = "M";
							}
							btnDelete.Visible = false;
							btnCDetails.Visible = true;

							if (Session["Role_CD"].ToString() == "4")
							{
								btnSave.Visible = false;
								btnDelete.Visible = false;
								btnFCList.Visible = false;
								btnUManuf.Visible = false;

							}

						}
						else if (Action == "D")
						{
							//if(txtCallStatus.Text=="Accepted" || txtCallStatus.Text=="Rejected" ||txtCallStatus.Text=="Cancelled")
							if (lblCUpdateStatus.Text == "N")
							{
								btnDelete.Enabled = false;
								btnSave.Enabled = false;
								status = "N";
							}
							else
							{
								btnDelete.Enabled = true;
								btnDelete.Visible = true;
								status = "M";

							}
							btnSave.Visible = false;
							btnCDetails.Visible = true;
						}
						txtCaseNo.Enabled = false;
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
				}
				else
					btnDelete.Visible = false;
			}

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
				Response.Redirect(("Error_Form.aspx?err=" + str1));
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
			int e_status = 0;
			try
			{
				if (ddlManufac.Visible == false)
				{
					DisplayAlert("Plz select Manufacturer first and then save it");
				}
				else if (lblRLYNONRLY.Text == "R" && ddlIRFC.SelectedValue == "")
				{
					DisplayAlert("Select The project is IRFC Funded [Yes/No] !!!");
				}
				else
				{
					if (lstIE.SelectedValue != "")
					{
						conn1.Open();
						OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
						ss = Convert.ToString(cmd2.ExecuteScalar());

						string w_irfc_funded = "";
						if (lblRLYNONRLY.Text == "R")
						{
							w_irfc_funded = ddlIRFC.SelectedValue.ToString();
						}
						else
						{
							w_irfc_funded = "N";
						}

						string department1 = "";
						int Clustercode = 0;
						int vcode = 0;
						department1 = ddlDept.SelectedItem.Value;
						if (department1 == "M")
						{
							department1 = "M";
						}
						else if (department1 == "E")
						{
							department1 = "E";
						}
						else if (department1 == "C")
						{
							department1 = "C";
						}
						else
							department1 = "M";
						int cl_exist = 0;
						vcode = Convert.ToInt32(ddlManufac.SelectedItem.Value);
						System.Data.OracleClient.OracleConnection cone = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
						string Command = "select distinct(b.Cluster_code) from T100_vender_cluster a inner join t99_cluster_master b  on a.cluster_code=b.cluster_code where a.vendor_code=" + vcode + "  and a.DEPARTMENT_NAME='" + department1.ToString() + "' and b.region_code='" + txtCaseNo.Text.Substring(0, 1).ToString() + "'";
						OracleCommand Comm1 = new OracleCommand(Command, conn1);
						cone.Open();
						DataSet ds = new DataSet();
						OracleDataAdapter da = new OracleDataAdapter(Comm1);
						da.Fill(ds);
						if (ds.Tables[0].Rows.Count == 0)
						{
							//Clustercode= Convert.ToInt32(ds.Tables[0].Rows[0]["Cluster_code"]);
							cl_exist = 1;
						}
						else
						{
							Clustercode = Convert.ToInt16(lstIE.SelectedValue);
						}

						OracleCommand cmdIE = new OracleCommand("Select IE_CODE from T101_IE_CLUSTER where CLUSTER_CODE=" + lstIE.SelectedValue + " AND DEPARTMENT_CODE='" + department1.ToString() + "'", conn1);

						int IE = Convert.ToInt32(cmdIE.ExecuteScalar());
						lblIE_CD.Text = IE.ToString();
						OracleCommand cmdCO = new OracleCommand("Select IE_CO_CD from T09_IE where IE_CD=" + IE, conn1);
						int CO = Convert.ToInt32(cmdCO.ExecuteScalar());
						conn1.Close();
						if (cl_exist == 1 && CHKRejCan.Checked == false)
						{
							conn1.Open();
							string myInsertQuery_Cluster = "INSERT into T100_VENDER_CLUSTER values('" + txtMName.Text + "', '" + department1 + "'," + lstIE.SelectedValue + ",'" + Session["UName"] + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
							OracleCommand myInsertCommand_Cluster = new OracleCommand(myInsertQuery_Cluster);
							myInsertCommand_Cluster.Connection = conn1;
							myInsertCommand_Cluster.ExecuteNonQuery();
							conn1.Close();
							Clustercode = Convert.ToInt16(lstIE.SelectedValue);
						}
						if (Action == "A")
						{
							conn1.Open();

							OracleCommand cmdCL = new OracleCommand("Select NVL(count(*),0) COUNT from T17_CALL_REGISTER where CASE_NO= '" + Label27.Text.Trim() + "' and CALL_LETTER_NO=trim(upper('" + txtCallNO.Text + "')) and REGION_CODE='" + Session["Region"].ToString() + "'", conn1);
							int CL = Convert.ToInt32(cmdCL.ExecuteScalar());

							//							OracleCommand cmdCO =new OracleCommand("Select IE_CO_CD from T09_IE where IE_CD="+lstIE.SelectedValue,conn1);
							//							int CO=Convert.ToInt32(cmdCO.ExecuteScalar());
							conn1.Close();



							if (CL == 0)
							{
								conn1.Open();
								OracleTransaction myTrans = conn1.BeginTransaction();
								try
								{
									string str3 = "select NVL(max(CALL_SNO),0)+1 CALL_SNO from T17_CALL_REGISTER where CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and REGION_CODE='" + Session["Region"].ToString() + "'";
									OracleCommand myCommand = new OracleCommand();
									myCommand.CommandText = str3;
									myCommand.Transaction = myTrans;
									myCommand.Connection = conn1;
									CD = Convert.ToInt32(myCommand.ExecuteScalar());
									string rej_can_call = "";
									if (CHKRejCan.Checked == true)
									{
										rej_can_call = "Y";
									}

									string w_stage_or_final = "";
									if (rdbStage.Checked == true)
									{
										w_stage_or_final = "S";
									}
									else
									{
										w_stage_or_final = "F";
									}
									string w_New_Vendor = "";
									if (chkNewVendor.Checked == true)
									{
										w_New_Vendor = "Y";
									}
									string myInsertQuery = "INSERT INTO T17_CALL_REGISTER(CASE_NO, CALL_RECV_DT, CALL_SNO, CALL_LETTER_NO, CALL_LETTER_DT,CALL_MARK_DT, IE_CD, DT_INSP_DESIRE, CALL_STATUS, CALL_STATUS_DT, CALL_REMARK_STATUS,CALL_INSTALL_NO, REGION_CODE, MFG_CD, USER_ID, DATETIME,MFG_PLACE,REMARKS,CO_CD,REJ_CAN_CALL,FINAL_OR_STAGE,NEW_VENDOR,IRFC_FUNDED,CLUSTER_CODE,DEPARTMENT_CODE) values('" + txtCaseNo.Text.Trim() + "', to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')," + CD + ",trim(upper('" + txtCallNO.Text + "')),to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),to_date('" + txtDtMark.Text + "','dd/mm/yyyy'), " + lblIE_CD.Text + ",to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy') ,'M',to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),'" + lstCallRStatus.SelectedValue + "','" + txtCInstallNo.Text + "','" + Session["Region"].ToString() + "','" + ddlManufac.SelectedValue + "','" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + txtMPOI.Text + "','" + txtRemarks.Text + "'," + CO + ",'" + rej_can_call + "','" + w_stage_or_final + "','" + w_New_Vendor + "','" + w_irfc_funded + "'," + Clustercode + ",'" + department1 + "')";
									OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
									myInsertCommand.Transaction = myTrans;
									myInsertCommand.Connection = conn1;
									myInsertCommand.ExecuteNonQuery();
									myTrans.Commit();
									conn1.Close();
									DisplayAlert("Your Record Has Been Saved!!!");
									e_status = 1;
									Label29.Text = CD.ToString();
									Label29.Visible = true;
									btnSave.Visible = false;
								}
								catch (Exception ex)
								{
									string str;
									str = ex.Message;
									myTrans.Rollback();
									e_status = 0;
									DisplayAlert("Your Record Has Not Been Saved, So Try Again!!!");
								}
								finally
								{
									conn1.Close();
								}
							}
							else
							{
								DisplayAlert("The Call Letter No. is already present for this Case No.");
							}
						}
						else if (Action == "M")
						{
							string Ucode = txtCaseNo.Text;
							string myUpdateQuery = "";
							if (lblEIE.Text == lblIE_CD.Text)
							{
								if (txtMName.Text != lblMFG_CD.Text)
								{
									if (Label_des_dt.Text == txtExpOfIns.Text)
									{
										myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('" + txtCallNO.Text + "')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='" + lstCallRStatus.SelectedValue + "',CALL_INSTALL_NO='" + txtCInstallNo.Text + "',REMARKS='" + txtRemarks.Text + "',MFG_CD='" + ddlManufac.SelectedValue + "',MFG_PLACE='" + txtMPOI.Text + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), CLUSTER_CODE='" + Clustercode + "', DEPARTMENT_CODE='" + department1 + "' where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
									}
									else
									{
										myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('" + txtCallNO.Text + "')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='" + lstCallRStatus.SelectedValue + "',CALL_INSTALL_NO='" + txtCInstallNo.Text + "',REMARKS='" + txtRemarks.Text + "',MFG_CD='" + ddlManufac.SelectedValue + "',MFG_PLACE='" + txtMPOI.Text + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),COUNT_DT=1, CLUSTER_CODE='" + Clustercode + "', DEPARTMENT_CODE='" + department1 + "' where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
										txtExpOfIns.Enabled = false;

									}
								}
								else
								{
									if (Label_des_dt.Text == txtExpOfIns.Text)
									{
										myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('" + txtCallNO.Text + "')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='" + lstCallRStatus.SelectedValue + "',CALL_INSTALL_NO='" + txtCInstallNo.Text + "',REMARKS='" + txtRemarks.Text + "',MFG_CD='" + ddlManufac.SelectedValue + "',MFG_PLACE='" + txtMPOI.Text + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), DEPARTMENT_CODE='" + department1 + "' where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
									}
									else
									{
										myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('" + txtCallNO.Text + "')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='" + lstCallRStatus.SelectedValue + "',CALL_INSTALL_NO='" + txtCInstallNo.Text + "',REMARKS='" + txtRemarks.Text + "',MFG_CD='" + ddlManufac.SelectedValue + "',MFG_PLACE='" + txtMPOI.Text + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),COUNT_DT=1, DEPARTMENT_CODE='" + department1 + "' where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
										txtExpOfIns.Enabled = false;

									}
								}

							}
							else if (lblEIE.Text != lblIE_CD.Text)
							{
								//								conn1.Open();
								//								OracleCommand cmdCO =new OracleCommand("Select IE_CO_CD from T09_IE where IE_CD="+lstIE.SelectedValue,conn1);
								//								int CO=Convert.ToInt32(cmdCO.ExecuteScalar());
								//								conn1.Close();
								if (txtMName.Text != lblMFG_CD.Text)
								{
									if (Label_des_dt.Text == txtExpOfIns.Text)
									{
										myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('" + txtCallNO.Text + "')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",IE_CD=" + lblIE_CD.Text + ",CO_CD=" + CO + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='" + lstCallRStatus.SelectedValue + "',CALL_INSTALL_NO='" + txtCInstallNo.Text + "',REMARKS='" + txtRemarks.Text + "',MFG_CD='" + ddlManufac.SelectedValue + "',MFG_PLACE='" + txtMPOI.Text + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), CLUSTER_CODE='" + Clustercode + "', DEPARTMENT_CODE='" + department1 + "' where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
									}
									else
									{
										myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('" + txtCallNO.Text + "')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",IE_CD=" + lblIE_CD.Text + ",CO_CD=" + CO + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='" + lstCallRStatus.SelectedValue + "',CALL_INSTALL_NO='" + txtCInstallNo.Text + "',REMARKS='" + txtRemarks.Text + "',MFG_CD='" + ddlManufac.SelectedValue + "',MFG_PLACE='" + txtMPOI.Text + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),COUNT_DT=1, CLUSTER_CODE='" + Clustercode + "', DEPARTMENT_CODE='" + department1 + "' where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
										txtExpOfIns.Enabled = false;
									}
								}
								else
								{
									if (Label_des_dt.Text == txtExpOfIns.Text)
									{
										myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('" + txtCallNO.Text + "')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",IE_CD=" + lblIE_CD.Text + ",CO_CD=" + CO + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='" + lstCallRStatus.SelectedValue + "',CALL_INSTALL_NO='" + txtCInstallNo.Text + "',REMARKS='" + txtRemarks.Text + "',MFG_CD='" + ddlManufac.SelectedValue + "',MFG_PLACE='" + txtMPOI.Text + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), DEPARTMENT_CODE='" + department1 + "' where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
									}
									else
									{
										myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('" + txtCallNO.Text + "')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",IE_CD=" + lblIE_CD.Text + ",CO_CD=" + CO + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='" + lstCallRStatus.SelectedValue + "',CALL_INSTALL_NO='" + txtCInstallNo.Text + "',REMARKS='" + txtRemarks.Text + "',MFG_CD='" + ddlManufac.SelectedValue + "',MFG_PLACE='" + txtMPOI.Text + "',USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),COUNT_DT=1, DEPARTMENT_CODE='" + department1 + "' where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
										txtExpOfIns.Enabled = false;
									}
								}
							}
							OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
							myUpdateCommand.Connection = conn1;
							conn1.Open();
							myUpdateCommand.ExecuteNonQuery();
							CD = Convert.ToInt32(Label29.Text);
							conn1.Close();
							e_status = 1;
							DisplayAlert("Your Record Has Been Saved!!!");

						}
						btnCDetails.Visible = true;
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
					else
					{
						DisplayAlert("Kndly Select The Inspecting Engineer to whom Call is marked before Saving!!!");
					}
				}
				//				send_IE_Email();
				if (e_status == 1 && CHKRejCan.Checked == false)
				{
					send_Vendor_Email();
					if ((lstIE.SelectedValue.Trim() != ""))
					{
						send_IE_sms();
					}
				}
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
					Response.Redirect(("Error_Form.aspx?err=" + str1));
				}
			}
			finally
			{
				conn1.Close();
			}
		}
		//		void send_IE_Email()
		//		{
		//			try
		//			{
		//				string sender="";
		//				OracleCommand cmd =new OracleCommand("Select IE_EMAIL from T09_IE where IE_CD="+lstIE.SelectedValue,conn1);
		//				conn1.Open();
		//				string ie_mail=Convert.ToString(cmd.ExecuteScalar());
		//				conn1.Close();
		//				if(ie_mail!="")
		//				{
		//					MailMessage mail = new MailMessage();
		//					mail.To = ie_mail;
		//					if(Session["Region"].ToString()=="N")
		//					{
		//						sender="nrinspn@rites.com";
		//					}
		//					else if(Session["Region"].ToString()=="W")
		//					{
		//						sender="wrinspn@rites.com";
		//					}
		//					else if(Session["Region"].ToString()=="E")
		//					{
		//						sender="erinspn@rites.com";
		//					}
		//					else if(Session["Region"].ToString()=="S")
		//					{
		//						sender="srinspn@rites.com";
		//					}
		//
		//					mail.From = sender;
		//					mail.Subject ="Call Marked With Case NO:" + Label27.Text +" , Call Date:"+Label28.Text+" & S No.:"+Label29.Text;
		//					string mail_body="Call Marked With Case NO:" + Label27.Text +" , Call Date:"+Label28.Text+" & S No.:"+Label29.Text+". \\nPurchase Order No."+Label25.Text+" Dated: "+Label22.Text+"\\nThe Manufacturer is :" +ddlManufac.SelectedItem.Text.Substring(0,ddlManufac.SelectedItem.Text.IndexOf("/",0)) +". Place Of Inspection is :"+ txtMPOI.Text + ".";
		//					if(txtMPNo.Text.Trim()!="")
		//					{
		//						mail_body=mail_body+" \\nContact Person is :" +txtMConPer.Text+ ",  Telephone No. :"+ txtMPNo.Text;
		//					}
		//
		//					mail.Body = mail_body;
		//					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");	//basic authentication
		//					SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
		//					mail.Priority = MailPriority.High;
		//					SmtpMail.Send(mail);
		//					
		//				}
		//			}
		//			catch (Exception ex)
		//			{
		//				string str; 
		//				str = ex.Message; 
		////				Response.Write(ex);
		//			}
		//		
		//		
		//		}
		void send_Vendor_Email()
		{
			try
			{
				string wRegion = "";
				if (Session["Region"].ToString() == "N") { wRegion = "NORTHERN REGION <BR>12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 <BR>Phone : +918800018691-95 <BR>Fax : 011-22024665"; }
				else if (Session["Region"].ToString() == "S") { wRegion = "SOUTHERN REGION <BR>CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 <BR>Phone : 044-28292807/044- 28292817 <BR>Fax : 044-28290359"; }
				else if (Session["Region"].ToString() == "E") { wRegion = "EASTERN REGION <BR>CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  <BR>Fax : 033-22348704"; }
				else if (Session["Region"].ToString() == "W") { wRegion = "WESTERN REGION <BR>5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 <BR>Phone : 022-68943400/68943445 <BR>"; }
				else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

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

				OracleCommand cmd1 = new OracleCommand("SELECT IE_NAME,IE_PHONE_NO, CO_NAME, CO_PHONE_NO, IE_EMAIL FROM T09_IE T09, T08_IE_CONTROLL_OFFICER T08 WHERE T09.IE_CO_CD=T08.CO_CD AND IE_CD=" + lblIE_CD.Text, conn1);
				conn1.Open();
				OracleDataReader reader1 = cmd1.ExecuteReader();
				string ie_phone = "", co_name = "", co_mobile = "", ie_email = "", ie_name = "";
				while (reader1.Read())
				{
					ie_phone = Convert.ToString(reader1["IE_PHONE_NO"]);
					co_name = Convert.ToString(reader1["CO_NAME"]);
					co_mobile = Convert.ToString(reader1["CO_PHONE_NO"]);
					ie_email = Convert.ToString(reader1["IE_EMAIL"]);
					ie_name = Convert.ToString(reader1["IE_NAME"]);
				}
				conn1.Close();


				//				conn1.Open();
				//				string ie_phone=Convert.ToString(cmd1.ExecuteScalar());
				//				conn1.Close();
				//				NO OF DAYS TO ATTEND THE CALL

				OracleCommand cmd11 = new OracleCommand("SELECT TO_CHAR(DT_INSP_DESIRE + (SELECT ROUND(COUNT(*)/1.5) DAYS FROM T17_CALL_REGISTER WHERE (CALL_RECV_DT>'01-APR-2017') AND CALL_STATUS IN ('M','S') AND IE_CD=" + lblIE_CD.Text + "),'DD/MM/YYYY') INSP_DATE FROM T17_CALL_REGISTER WHERE CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text, conn1);
				conn1.Open();
				string dateto_attend = Convert.ToString(cmd11.ExecuteScalar());

				string updateQuery = "Update T17_CALL_REGISTER set EXP_INSP_DT=TO_DATE('" + dateto_attend + "','dd/mm/yyyy') where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text;
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
				if (txtCallDt.Text.Trim() == "")
				{
					call_letter_dt = "NIL";
				}
				else
				{
					call_letter_dt = txtCallDt.Text;
				}
				string mail_body = mail_body = "Dear Sir/Madam,<br><br> In Reference to your Call Letter dated:  " + call_letter_dt + " for inspection of material against PO No. - " + Label25.Text + " & date - " + Label22.Text + ", call has been registered vide Case No -  " + Label27.Text + ", on date " + Label28.Text + ", at SNo. " + Label29.Text + ".<br> ";
				if (Label28.Text.Trim() != txtExpOfIns.Text.Trim())
				{
					mail_body = mail_body + "The Desired Inspection Date of this call shall be on or after: " + txtExpOfIns.Text.Trim() + ".<br>";
				}
				//mail_body=mail_body +"Inspecting Engineer: "+ lstIE.SelectedItem.Text+", Contact No. "+ie_phone +", Controlling Officer: "+ co_name +", Contact No."+co_mobile+" has been assigned the inspection task. \n For any correspondence in future, please quote Case No. only. \n\n Thanks for using RITES Inspection Services. \n\n"+ wRegion +"." ;

				//mail_body=mail_body+ "Inspecting Engineer: " + lstIE.SelectedItem.Text+", Contact No. "+ie_phone +", Controlling Officer: "+ co_name +", Contact No."+co_mobile+" has been assigned the inspection task. \nBased on the current workload with the IE, Inspection is likely to be attended on or before "+dateto_attend+" or next working day (In case the above date happens to be a holiday). Dates are subject to last minute changes due to  exigencies of work and overriding Client priorities. Material should be ready on the indicated date along with all related Documents & Internal Test reports. \n For any correspondence in future, please quote Case No. only. \n\n Thanks for using RITES Inspection Services. \n\n"+ wRegion +"." ;
				//mail_body=mail_body+ "The inspection call has been assigned to Inspecting Engineer Sh. " + lstIE.SelectedItem.Text+", Contact No. "+ie_phone +". Based on the current workload with the IE, Inspection is likely to be attended on or before "+dateto_attend+" or next working day (In case the above date happens to be a holiday). Dates are subject to last minute changes due to  exigencies of work and overriding Client priorities. \n Name of Controlling Manager of concerned IE Sh.: "+ co_name +", Contact No."+co_mobile+". \nOffered Material as per registration should be readily available on the indicated date along with all related documents and internal test reports. \nFor Inspection related information please visit : http://ritesinsp.com. \n For any correspondence in future, please quote Case No. only. \n\n Thanks for using RITES Inspection Services. \n\n"+ wRegion +"." ;

				if (days_to_ic == 0)
				{
					mail_body = mail_body + "The inspection call has been assigned to Inspecting Engineer Sh. " + ie_name + ", Contact No. " + ie_phone + ", Email ID: " + ie_email + ". Based on the current workload with the IE, Inspection is likely to be attended on or before " + dateto_attend + " or next working day (In case the above date happens to be a holiday). Dates are subject to last minute changes due to  exigencies of work and overriding Client priorities. <br> Name of Controlling Manager of concerned IE Sh.: " + co_name + ", Contact No." + co_mobile + ". <br>Offered Material as per registration should be readily available on the indicated date along with all related documents and internal test reports.<br><a href='http://rites.ritesinsp.com/RBS/Guidelines for Vendors.pdf'>Guidelines for Vendors</a>.<br>For Inspection related information please visit : http://ritesinsp.com. <br>For any correspondence in future, please quote Case No. only. <br><br> Thanks for using RITES Inspection Services. <br><br>" + wRegion + ".";
				}
				else if (days_to_ic > 0)
				{
					System.DateTime w_dt1 = new System.DateTime(Convert.ToInt32(dateto_attend.Substring(6, 4)), Convert.ToInt32(dateto_attend.Substring(3, 2)), Convert.ToInt32(dateto_attend.Substring(0, 2)));
					System.DateTime w_dt2 = w_dt1.AddDays(days_to_ic);
					string date_to_ic = w_dt2.ToString("dd/MM/yyyy");
					mail_body = mail_body + "The inspection call has been assigned to Inspecting Engineer Sh. " + ie_name + ", Contact No. " + ie_phone + ", Email ID: " + ie_email + ". Based on the current workload with the IE, Inspection is likely to be attended on or before " + dateto_attend + " or next working day (In case the above date happens to be a holiday) and Inspection certificate is likely to issued by " + date_to_ic + ". Dates are subject to last minute changes due to  exigencies of work and overriding Client priorities. <br> Name of Controlling Manager of concerned IE Sh.: " + co_name + ", Contact No." + co_mobile + ". <br>Offered Material as per registration should be readily available on the indicated date along with all related documents and internal test reports. Inspection is proposed to be conducted as per inspection plan: <a href='http://rites.ritesinsp.com/RBS/MASTER_ITEMS_CHECKSHEETS/" + item_cd + ".RAR'>Inspection Plan</a>.<br><a href='http://rites.ritesinsp.com/RBS/Guidelines for Vendors.pdf'>Guidelines for Vendors</a>.<br>For Inspection related information please visit : http://ritesinsp.com. <br>For any correspondence in future, please quote Case No. only. <br><br>Thanks for using RITES Inspection Services. <br><br>" + wRegion + ".";
				}
				mail_body = mail_body + "<br><br> THIS IS AN AUTO GENERATED EMAIL. PLEASE DO NOT REPLY. USE EMAIL GIVEN IN THE REGION ADDRESS.<BR>NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE)";
				string sender = "";
				if (Session["Region"].ToString() == "N")
				{
					sender = "nrinspn@rites.com";
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
				if (vend_cd == ddlManufac.SelectedValue && manu_mail != "")
				{
					MailMessage mail = new MailMessage();
					mail.To = manu_mail;
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
				else if (vend_cd != ddlManufac.SelectedValue && vend_email != "" && manu_mail != "")
				{

					MailMessage mail = new MailMessage();
					mail.To = vend_email + ";" + manu_mail;
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
				else if (vend_cd != ddlManufac.SelectedValue && (vend_email == "" || manu_mail == ""))
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

					//mail.To = vend_email+";"+manu_mail;
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

				OracleCommand cmd_manu = new OracleCommand("Select T05.VEND_NAME,T03.CITY VEND_ADDRESS from T17_CALL_REGISTER T17,T05_VENDOR T05, T03_CITY T03 where T17.MFG_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + Label27.Text.Trim() + "' and CALL_RECV_DT=to_date('" + Label28.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text, conn1);
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
			}
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			OracleCommand cmdcall = new OracleCommand("select nvl(count(CASE_NO),0) from T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text, conn1);
			conn1.Open();
			int delstatus = Convert.ToInt16(cmdcall.ExecuteScalar());
			conn1.Close();

			conn1.Open();
		OracleTransaction myTrans = conn1.BeginTransaction();

			try
			{
				if (delstatus == 0)
				{
					string myDeleteQuery2 = "Delete T19_CALL_CANCEL where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text;
					OracleCommand myOracleCommand2 = new OracleCommand(myDeleteQuery2);
					myOracleCommand2.Transaction = myTrans;
					myOracleCommand2.Connection = conn1;
					myOracleCommand2.ExecuteNonQuery();

					string myDeleteQuery1 = "Delete T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text;
					OracleCommand myOracleCommand1 = new OracleCommand(myDeleteQuery1);
					myOracleCommand1.Transaction = myTrans;
					myOracleCommand1.Connection = conn1;
					myOracleCommand1.ExecuteNonQuery();

					string myDeleteQuery = "Delete T17_CALL_REGISTER where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text;
					OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
					myOracleCommand.Transaction = myTrans;
					myOracleCommand.Connection = conn1;
					myOracleCommand.ExecuteNonQuery();

					myTrans.Commit();

					conn1.Close();
					DisplayAlert("Your Record Has Been Deleted!!!");
				}
				else
				{
					DisplayAlert("This Call cannot be deleted. because IC is present for this call!!!");
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
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Call_Register_Edit.aspx");
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


		protected void btnCDetails_Click(object sender, System.EventArgs e)
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
			Response.Redirect("Call_Details_Form.aspx?Case_No=" + code + "&DT_RECIEPT=" + dt + "&CALL_SNO=" + cs + "&cstatus=" + status);
		}

		int fill_manufacturer(string str1)
		{
			ddlManufac.Items.Clear();
			DataSet dsP = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				ecode = 1;
				return (ecode);
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
				ecode = 2;
				return (ecode);

			}

		}

		protected void btnFCList_Click(object sender, System.EventArgs e)
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
					Response.Redirect("Error_Form.aspx?err=" + str2);
				}

			}
			finally
			{
				conn1.Close();
			}
		}

		protected void ddlManufac_SelectedIndexChanged(object sender, System.EventArgs e)
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

		protected void btnUManuf_Click(object sender, System.EventArgs e)
		{
			OracleCommand cmd = new OracleCommand("update T05_VENDOR set VEND_CONTACT_PER_1='" + txtMConPer.Text + "',VEND_CONTACT_TEL_1='" + txtMPNo.Text + "',VEND_EMAIL='" + txtMEmail.Text.Trim() + "' where VEND_CD=" + txtMName.Text, conn1);
			conn1.Open();
			cmd.ExecuteNonQuery();
			DisplayAlert("This Manufacturer details has been updated!!!");
			conn1.Close();
		}

		protected void chkManuf_CheckedChanged(object sender, System.EventArgs e)
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
					Response.Redirect(("Error_Form.aspx?err=" + str1));
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

		void send_IE_sms()
		{
			string sender = "";
			string wIEMobile = "", wIEName = "", wVendor = "", wCOMobile = "", wVendMobile = "", wIEMobile_for_SMS = "";
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
			//cmd.CommandText="select substr(V.VEND_NAME,1,30)||','||substr(C.CITY,1,12) VEND_NAME,trim(substr(VEND_CONTACT_TEL_1,1,10)) VEND_TEL from T05_VENDOR V, T03_CITY C where VEND_CD="+txtMName.Text+" and V.VEND_CITY_CD=C.CITY_CD"; 
			cmd.CommandText = "select replace(substr(V.VEND_NAME,1,30),'&','AND') VEND_NAME,trim(substr(VEND_CONTACT_TEL_1,1,10)) VEND_TEL from T05_VENDOR V, T03_CITY C where VEND_CD=" + txtMName.Text + " and V.VEND_CITY_CD=C.CITY_CD";
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
			//string message="RITES LTD - QA CALL MARKED,IE-"+wIEName+",Contact No.:"+wIEMobile_for_SMS+",RLY-"+lblRly.Text+",PO-"+lblL5noPo.Text+",DT-"+Label22.Text+",FIRM NAME-"+wVendor+",Call Sno-"+Label29.Text+",DT-"+Label28.Text+"- RITES/"+sender;
			string message = "RITES LTD - QA Call Marked, IE-" + wIEName + ",Contact No.:" + wIEMobile_for_SMS + ",RLY-" + lblRly.Text + ",PO-" + lblL5noPo.Text + ",DT- " + Label22.Text + ", Firm Name-" + wVendor + ", Call Sno - " + Label29.Text + ",DT- " + Label28.Text + "- RITES/" + sender;
			//
			WebClient client = new WebClient();
			//string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=ritesinsp&password=754347474&sendername=RITESQ&mobileno="+wIEMobile+"&message="+message;
			//string baseurl = "http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=1ritesltd&password=R1te3@lxt&sender=RITESQ&to="+wIEMobile+"&message="+message+"&reqid=1&format={json|text}&route_id=23";
			//string baseurl = "http://103.247.98.91/API/SendMsg.aspx?uname=20181896&pass=9eBWwFz9&send=RITESQ&dest="+wIEMobile+"&msg="+message+"&priority=1";
			//string baseurl = "http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=2ritesltd&password=Ag@14rtd&sender=RITESQ&to="+wIEMobile+"&message="+message+"&reqid=1&format={json|text}&route_id=23";
			//string baseurl = "https://apps.sandeshlive.com/API/WebSMS/Http/v1.0a/index.php?userid=532&password=Aa4cHZ5QFfKJEVzI&sender=RITESQ&to="+wIEMobile+"&message="+message+"&reqid=1&format={json|text}&route_id=3";
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

		protected void btnUpload_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
				{
					String fn = "", fx = "";
					fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper();
					if (fx == ".PDF")
					{
						string myYear1, myMonth1, myDay1;
						myYear1 = Label28.Text.Substring(6, 4);
						myMonth1 = Label28.Text.Substring(3, 2);
						myDay1 = Label28.Text.Substring(0, 2);
						string calldt = myYear1 + myMonth1 + myDay1;
						String SaveLocation = null;
						SaveLocation = Server.MapPath("CALLS_DOCUMENTS/" + Label27.Text + "-" + calldt + "-" + Label29.Text.Trim() + ".pdf");

						//SaveLocation = Server.MapPath("PO/" + fn);
						//SaveLocation = "//172.16.7.76/madan/"+fn;
						File1.PostedFile.SaveAs(SaveLocation);
						DisplayAlert("The file has been uploaded.");
					}
					else
					{ DisplayAlert("Only pdf files are accepted."); }
				}
				else
				{
					DisplayAlert("Please select a file to upload.");
				}
			}
			catch (FileNotFoundException fe)
			{ Response.Write("File not found" + fe); }
			catch (System.IO.DirectoryNotFoundException de)
			{ Response.Write("Directry not found" + de); }
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				Response.Write(ex);
			}
		}
	}
}